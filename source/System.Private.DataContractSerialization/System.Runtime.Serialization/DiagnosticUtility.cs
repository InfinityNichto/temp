using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.Serialization;

internal static class DiagnosticUtility
{
	internal static class ExceptionUtility
	{
		public static Exception ThrowHelperArgumentNull(string message)
		{
			return new ArgumentNullException(message);
		}

		public static Exception ThrowHelperError(Exception e)
		{
			return e;
		}

		public static Exception ThrowHelperArgument(string message)
		{
			return new ArgumentException(message);
		}

		internal static Exception ThrowHelperFatal(string message, Exception innerException)
		{
			return ThrowHelperError(new Exception(message, innerException));
		}

		internal static Exception ThrowHelperCallback(Exception e)
		{
			return ThrowHelperError(e);
		}
	}

	[Conditional("DEBUG")]
	[DoesNotReturn]
	public static void DebugAssert(string message)
	{
	}

	[Conditional("DEBUG")]
	public static void DebugAssert([DoesNotReturnIf(false)] bool condition, string message)
	{
	}
}
