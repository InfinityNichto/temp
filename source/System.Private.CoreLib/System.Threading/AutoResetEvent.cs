namespace System.Threading;

public sealed class AutoResetEvent : EventWaitHandle
{
	public AutoResetEvent(bool initialState)
		: base(initialState, EventResetMode.AutoReset)
	{
	}
}
