namespace Internal.Cryptography.Pal.Native;

internal enum ContentType
{
	CERT_QUERY_CONTENT_CERT = 1,
	CERT_QUERY_CONTENT_CTL,
	CERT_QUERY_CONTENT_CRL,
	CERT_QUERY_CONTENT_SERIALIZED_STORE,
	CERT_QUERY_CONTENT_SERIALIZED_CERT,
	CERT_QUERY_CONTENT_SERIALIZED_CTL,
	CERT_QUERY_CONTENT_SERIALIZED_CRL,
	CERT_QUERY_CONTENT_PKCS7_SIGNED,
	CERT_QUERY_CONTENT_PKCS7_UNSIGNED,
	CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED,
	CERT_QUERY_CONTENT_PKCS10,
	CERT_QUERY_CONTENT_PFX,
	CERT_QUERY_CONTENT_CERT_PAIR,
	CERT_QUERY_CONTENT_PFX_AND_LOAD
}