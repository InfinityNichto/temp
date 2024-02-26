namespace System.Reflection;

[Flags]
internal enum INVOCATION_FLAGS : uint
{
	INVOCATION_FLAGS_UNKNOWN = 0u,
	INVOCATION_FLAGS_INITIALIZED = 1u,
	INVOCATION_FLAGS_NO_INVOKE = 2u,
	INVOCATION_FLAGS_RUN_CLASS_CONSTRUCTOR = 4u,
	INVOCATION_FLAGS_NO_CTOR_INVOKE = 8u,
	INVOCATION_FLAGS_IS_CTOR = 0x10u,
	INVOCATION_FLAGS_IS_DELEGATE_CTOR = 0x80u,
	INVOCATION_FLAGS_CONTAINS_STACK_POINTERS = 0x100u,
	INVOCATION_FLAGS_SPECIAL_FIELD = 0x10u,
	INVOCATION_FLAGS_FIELD_SPECIAL_CAST = 0x20u,
	INVOCATION_FLAGS_CONSTRUCTOR_INVOKE = 0x10000000u
}