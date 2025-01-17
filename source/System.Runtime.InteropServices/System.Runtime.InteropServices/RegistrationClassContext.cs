namespace System.Runtime.InteropServices;

[Flags]
public enum RegistrationClassContext
{
	InProcessServer = 1,
	InProcessHandler = 2,
	LocalServer = 4,
	InProcessServer16 = 8,
	RemoteServer = 0x10,
	InProcessHandler16 = 0x20,
	Reserved1 = 0x40,
	Reserved2 = 0x80,
	Reserved3 = 0x100,
	Reserved4 = 0x200,
	NoCodeDownload = 0x400,
	Reserved5 = 0x800,
	NoCustomMarshal = 0x1000,
	EnableCodeDownload = 0x2000,
	NoFailureLog = 0x4000,
	DisableActivateAsActivator = 0x8000,
	EnableActivateAsActivator = 0x10000,
	FromDefaultContext = 0x20000
}
