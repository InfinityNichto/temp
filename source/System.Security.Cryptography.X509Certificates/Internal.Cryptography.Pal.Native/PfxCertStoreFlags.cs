using System;

namespace Internal.Cryptography.Pal.Native;

[Flags]
internal enum PfxCertStoreFlags
{
	CRYPT_EXPORTABLE = 1,
	CRYPT_USER_PROTECTED = 2,
	CRYPT_MACHINE_KEYSET = 0x20,
	CRYPT_USER_KEYSET = 0x1000,
	PKCS12_PREFER_CNG_KSP = 0x100,
	PKCS12_ALWAYS_CNG_KSP = 0x200,
	PKCS12_ALLOW_OVERWRITE_KEY = 0x4000,
	PKCS12_NO_PERSIST_KEY = 0x8000,
	PKCS12_INCLUDE_EXTENDED_PROPERTIES = 0x10,
	None = 0
}
