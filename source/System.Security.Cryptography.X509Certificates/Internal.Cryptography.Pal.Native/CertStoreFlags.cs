using System;

namespace Internal.Cryptography.Pal.Native;

[Flags]
internal enum CertStoreFlags
{
	CERT_STORE_NO_CRYPT_RELEASE_FLAG = 1,
	CERT_STORE_SET_LOCALIZED_NAME_FLAG = 2,
	CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG = 4,
	CERT_STORE_DELETE_FLAG = 0x10,
	CERT_STORE_UNSAFE_PHYSICAL_FLAG = 0x20,
	CERT_STORE_SHARE_STORE_FLAG = 0x40,
	CERT_STORE_SHARE_CONTEXT_FLAG = 0x80,
	CERT_STORE_MANIFOLD_FLAG = 0x100,
	CERT_STORE_ENUM_ARCHIVED_FLAG = 0x200,
	CERT_STORE_UPDATE_KEYID_FLAG = 0x400,
	CERT_STORE_BACKUP_RESTORE_FLAG = 0x800,
	CERT_STORE_READONLY_FLAG = 0x8000,
	CERT_STORE_OPEN_EXISTING_FLAG = 0x4000,
	CERT_STORE_CREATE_NEW_FLAG = 0x2000,
	CERT_STORE_MAXIMUM_ALLOWED_FLAG = 0x1000,
	CERT_SYSTEM_STORE_CURRENT_USER = 0x10000,
	CERT_SYSTEM_STORE_LOCAL_MACHINE = 0x20000,
	None = 0
}
