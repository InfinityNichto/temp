using System.ComponentModel;

namespace System.Diagnostics;

[Flags]
public enum SourceLevels
{
	Off = 0,
	Critical = 1,
	Error = 3,
	Warning = 7,
	Information = 0xF,
	Verbose = 0x1F,
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ActivityTracing = 0xFF00,
	All = -1
}
