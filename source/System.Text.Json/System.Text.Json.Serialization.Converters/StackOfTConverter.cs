using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class StackOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : Stack<TElement>
{
	protected override void Add(in TElement value, ref ReadStack state)
	{
		((TCollection)state.Current.ReturnValue).Push(value);
	}

	protected override void CreateCollection(ref Utf8JsonReader reader, ref ReadStack state, JsonSerializerOptions options)
	{
		if (state.Current.JsonTypeInfo.CreateObject == null)
		{
			ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(state.Current.JsonTypeInfo.Type);
		}
		state.Current.ReturnValue = state.Current.JsonTypeInfo.CreateObject();
	}
}
