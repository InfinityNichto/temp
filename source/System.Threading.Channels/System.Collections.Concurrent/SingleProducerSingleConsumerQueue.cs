using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Internal;

namespace System.Collections.Concurrent;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(SingleProducerSingleConsumerQueue<>.SingleProducerSingleConsumerQueue_DebugView))]
internal sealed class SingleProducerSingleConsumerQueue<T> : IEnumerable<T>, IEnumerable
{
	[StructLayout(LayoutKind.Sequential)]
	private sealed class Segment
	{
		internal Segment _next;

		internal readonly T[] _array;

		internal SegmentState _state;

		internal Segment(int size)
		{
			_array = new T[size];
		}
	}

	private struct SegmentState
	{
		internal Internal.PaddingFor32 _pad0;

		internal volatile int _first;

		internal int _lastCopy;

		internal Internal.PaddingFor32 _pad1;

		internal int _firstCopy;

		internal volatile int _last;

		internal Internal.PaddingFor32 _pad2;
	}

	private sealed class SingleProducerSingleConsumerQueue_DebugView
	{
		private readonly SingleProducerSingleConsumerQueue<T> _queue;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items => new List<T>(_queue).ToArray();

		public SingleProducerSingleConsumerQueue_DebugView(SingleProducerSingleConsumerQueue<T> queue)
		{
			_queue = queue;
		}
	}

	private volatile Segment _head;

	private volatile Segment _tail;

	public bool IsEmpty
	{
		get
		{
			Segment head = _head;
			if (head._state._first != head._state._lastCopy)
			{
				return false;
			}
			if (head._state._first != head._state._last)
			{
				return false;
			}
			return head._next == null;
		}
	}

	internal int Count
	{
		get
		{
			int num = 0;
			for (Segment segment = _head; segment != null; segment = segment._next)
			{
				int num2 = segment._array.Length;
				int first;
				int last;
				do
				{
					first = segment._state._first;
					last = segment._state._last;
				}
				while (first != segment._state._first);
				num += (last - first) & (num2 - 1);
			}
			return num;
		}
	}

	public SingleProducerSingleConsumerQueue()
	{
		_head = (_tail = new Segment(32));
	}

	public void Enqueue(T item)
	{
		Segment segment = _tail;
		T[] array = segment._array;
		int last = segment._state._last;
		int num = (last + 1) & (array.Length - 1);
		if (num != segment._state._firstCopy)
		{
			array[last] = item;
			segment._state._last = num;
		}
		else
		{
			EnqueueSlow(item, ref segment);
		}
	}

	private void EnqueueSlow(T item, ref Segment segment)
	{
		if (segment._state._firstCopy != segment._state._first)
		{
			segment._state._firstCopy = segment._state._first;
			Enqueue(item);
			return;
		}
		int num = _tail._array.Length << 1;
		if (num > 16777216)
		{
			num = 16777216;
		}
		Segment segment2 = new Segment(num);
		segment2._array[0] = item;
		segment2._state._last = 1;
		segment2._state._lastCopy = 1;
		try
		{
		}
		finally
		{
			Volatile.Write(ref _tail._next, segment2);
			_tail = segment2;
		}
	}

	public bool TryDequeue([MaybeNullWhen(false)] out T result)
	{
		Segment head = _head;
		T[] array = head._array;
		int first = head._state._first;
		if (first != head._state._lastCopy)
		{
			result = array[first];
			array[first] = default(T);
			head._state._first = (first + 1) & (array.Length - 1);
			return true;
		}
		return TryDequeueSlow(head, array, peek: false, out result);
	}

	public bool TryPeek([MaybeNullWhen(false)] out T result)
	{
		Segment head = _head;
		T[] array = head._array;
		int first = head._state._first;
		if (first != head._state._lastCopy)
		{
			result = array[first];
			return true;
		}
		return TryDequeueSlow(head, array, peek: true, out result);
	}

	private bool TryDequeueSlow(Segment segment, T[] array, bool peek, [MaybeNullWhen(false)] out T result)
	{
		if (segment._state._last != segment._state._lastCopy)
		{
			segment._state._lastCopy = segment._state._last;
			if (!peek)
			{
				return TryDequeue(out result);
			}
			return TryPeek(out result);
		}
		if (segment._next != null && segment._state._first == segment._state._last)
		{
			segment = segment._next;
			array = segment._array;
			_head = segment;
		}
		int first = segment._state._first;
		if (first == segment._state._last)
		{
			result = default(T);
			return false;
		}
		result = array[first];
		if (!peek)
		{
			array[first] = default(T);
			segment._state._first = (first + 1) & (segment._array.Length - 1);
			segment._state._lastCopy = segment._state._last;
		}
		return true;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (Segment segment = _head; segment != null; segment = segment._next)
		{
			for (int pt = segment._state._first; pt != segment._state._last; pt = (pt + 1) & (segment._array.Length - 1))
			{
				yield return segment._array[pt];
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
