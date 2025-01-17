using System.Runtime.Serialization;

namespace System.Reflection;

public sealed class Missing : ISerializable
{
	public static readonly Missing Value = new Missing();

	private Missing()
	{
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}
}
