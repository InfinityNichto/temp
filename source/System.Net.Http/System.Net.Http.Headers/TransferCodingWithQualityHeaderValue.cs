using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public sealed class TransferCodingWithQualityHeaderValue : TransferCodingHeaderValue, ICloneable
{
	public double? Quality
	{
		get
		{
			return HeaderUtilities.GetQuality((ObjectCollection<NameValueHeaderValue>)base.Parameters);
		}
		set
		{
			HeaderUtilities.SetQuality((ObjectCollection<NameValueHeaderValue>)base.Parameters, value);
		}
	}

	internal TransferCodingWithQualityHeaderValue()
	{
	}

	public TransferCodingWithQualityHeaderValue(string value)
		: base(value)
	{
	}

	public TransferCodingWithQualityHeaderValue(string value, double quality)
		: base(value)
	{
		Quality = quality;
	}

	private TransferCodingWithQualityHeaderValue(TransferCodingWithQualityHeaderValue source)
		: base(source)
	{
	}

	object ICloneable.Clone()
	{
		return new TransferCodingWithQualityHeaderValue(this);
	}

	public new static TransferCodingWithQualityHeaderValue Parse(string? input)
	{
		int index = 0;
		return (TransferCodingWithQualityHeaderValue)TransferCodingHeaderParser.SingleValueWithQualityParser.ParseValue(input, null, ref index);
	}

	public static bool TryParse([NotNullWhen(true)] string? input, [NotNullWhen(true)] out TransferCodingWithQualityHeaderValue? parsedValue)
	{
		int index = 0;
		parsedValue = null;
		if (TransferCodingHeaderParser.SingleValueWithQualityParser.TryParseValue(input, null, ref index, out var parsedValue2))
		{
			parsedValue = (TransferCodingWithQualityHeaderValue)parsedValue2;
			return true;
		}
		return false;
	}
}
