using System.Collections.Generic;

namespace System.Linq.Parallel;

internal sealed class ReverseComparer<T> : IComparer<T>
{
	private readonly IComparer<T> _comparer;

	internal ReverseComparer(IComparer<T> comparer)
	{
		_comparer = comparer;
	}

	public int Compare(T x, T y)
	{
		return _comparer.Compare(y, x);
	}
}
