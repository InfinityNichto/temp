namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public sealed class ReferenceAssemblyAttribute : Attribute
{
	public string? Description { get; }

	public ReferenceAssemblyAttribute()
	{
	}

	public ReferenceAssemblyAttribute(string? description)
	{
		Description = description;
	}
}
