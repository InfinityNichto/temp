namespace System.Reflection;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
public sealed class AssemblyDefaultAliasAttribute : Attribute
{
	public string DefaultAlias { get; }

	public AssemblyDefaultAliasAttribute(string defaultAlias)
	{
		DefaultAlias = defaultAlias;
	}
}
