namespace System.Text.Json.Serialization.Converters;

internal sealed class UInt64Converter : JsonConverter<ulong>
{
	public UInt64Converter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetUInt64();
	}

	public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}

	internal override ulong ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetUInt64WithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options, bool isWritingExtensionDataProperty)
	{
		writer.WritePropertyName(value);
	}

	internal override ulong ReadNumberWithCustomHandling(ref Utf8JsonReader reader, JsonNumberHandling handling, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & handling) != 0)
		{
			return reader.GetUInt64WithQuotes();
		}
		return reader.GetUInt64();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter writer, ulong value, JsonNumberHandling handling)
	{
		if ((JsonNumberHandling.WriteAsString & handling) != 0)
		{
			writer.WriteNumberValueAsString(value);
		}
		else
		{
			writer.WriteNumberValue(value);
		}
	}
}
