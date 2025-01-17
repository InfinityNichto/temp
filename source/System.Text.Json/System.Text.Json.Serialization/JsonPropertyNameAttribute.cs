namespace System.Text.Json.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class JsonPropertyNameAttribute : JsonAttribute
{
	public string Name { get; }

	public JsonPropertyNameAttribute(string name)
	{
		Name = name;
	}
}
