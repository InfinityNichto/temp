namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
public sealed class DecimalConstantAttribute : Attribute
{
	private readonly decimal _dec;

	public decimal Value => _dec;

	[CLSCompliant(false)]
	public DecimalConstantAttribute(byte scale, byte sign, uint hi, uint mid, uint low)
	{
		_dec = new decimal((int)low, (int)mid, (int)hi, sign != 0, scale);
	}

	public DecimalConstantAttribute(byte scale, byte sign, int hi, int mid, int low)
	{
		_dec = new decimal(low, mid, hi, sign != 0, scale);
	}
}
