using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	TValue this[TKey key] { get; set; }

	ICollection<TKey> Keys { get; }

	ICollection<TValue> Values { get; }

	bool ContainsKey(TKey key);

	void Add(TKey key, TValue value);

	bool Remove(TKey key);

	bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
}
