using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
public sealed class IUnknownConstantAttribute : CustomConstantAttribute
{
	public override object Value => new UnknownWrapper(null);
}
