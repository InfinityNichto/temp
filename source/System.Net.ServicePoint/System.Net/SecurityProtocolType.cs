namespace System.Net;

[Flags]
public enum SecurityProtocolType
{
	SystemDefault = 0,
	Ssl3 = 0x30,
	Tls = 0xC0,
	Tls11 = 0x300,
	Tls12 = 0xC00,
	Tls13 = 0x3000
}
