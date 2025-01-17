using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Threading;

[Serializable]
[TypeForwardedFrom("System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SemaphoreFullException : SystemException
{
	public SemaphoreFullException()
		: base(SR.Threading_SemaphoreFullException)
	{
	}

	public SemaphoreFullException(string? message)
		: base(message)
	{
	}

	public SemaphoreFullException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}

	protected SemaphoreFullException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
