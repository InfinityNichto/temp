namespace System.Text.Json.Serialization.Converters;

internal sealed class ByteConverter : JsonConverter<byte>
{
	public ByteConverter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override byte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetByte();
	}

	public override void Write(Utf8JsonWriter writer, byte value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}

	internal override byte ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetByteWithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter writer, byte value, JsonSerializerOptions options, bool isWritingExtensionDataProperty)
	{
		writer.WritePropertyName(value);
	}

	internal override byte ReadNumberWithCustomHandling(ref Utf8JsonReader reader, JsonNumberHandling handling, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & handling) != 0)
		{
			return reader.GetByteWithQuotes();
		}
		return reader.GetByte();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter writer, byte value, JsonNumberHandling handling)
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
