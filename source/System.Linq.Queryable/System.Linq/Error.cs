namespace System.Linq;

internal static class Error
{
	internal static Exception ArgumentNull(string message)
	{
		return new ArgumentNullException(message);
	}

	internal static Exception ArgumentNotIEnumerableGeneric(string message)
	{
		return new ArgumentException(Strings.ArgumentNotIEnumerableGeneric(message));
	}

	internal static Exception ArgumentNotValid(string message)
	{
		return new ArgumentException(Strings.ArgumentNotValid(message));
	}

	internal static Exception ArgumentOutOfRange(string message)
	{
		return new ArgumentOutOfRangeException(message);
	}

	internal static Exception NoMethodOnType(string name, object type)
	{
		return new InvalidOperationException(Strings.NoMethodOnType(name, type));
	}

	internal static Exception NoMethodOnTypeMatchingArguments(string name, object type)
	{
		return new InvalidOperationException(Strings.NoMethodOnTypeMatchingArguments(name, type));
	}

	internal static Exception EnumeratingNullEnumerableExpression()
	{
		return new InvalidOperationException(Strings.EnumeratingNullEnumerableExpression());
	}
}
