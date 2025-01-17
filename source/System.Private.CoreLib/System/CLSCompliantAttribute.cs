namespace System;

[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public sealed class CLSCompliantAttribute : Attribute
{
	private readonly bool _compliant;

	public bool IsCompliant => _compliant;

	public CLSCompliantAttribute(bool isCompliant)
	{
		_compliant = isCompliant;
	}
}
