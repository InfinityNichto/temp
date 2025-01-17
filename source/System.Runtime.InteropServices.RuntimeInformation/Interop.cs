using System;
using System.Runtime.InteropServices;

internal static class Interop
{
	internal static class Kernel32
	{
		internal struct SYSTEM_INFO
		{
			internal ushort wProcessorArchitecture;

			internal ushort wReserved;

			internal int dwPageSize;

			internal IntPtr lpMinimumApplicationAddress;

			internal IntPtr lpMaximumApplicationAddress;

			internal IntPtr dwActiveProcessorMask;

			internal int dwNumberOfProcessors;

			internal int dwProcessorType;

			internal int dwAllocationGranularity;

			internal short wProcessorLevel;

			internal short wProcessorRevision;
		}

		internal enum ProcessorArchitecture : ushort
		{
			Processor_Architecture_INTEL = 0,
			Processor_Architecture_ARM = 5,
			Processor_Architecture_IA64 = 6,
			Processor_Architecture_AMD64 = 9,
			Processor_Architecture_ARM64 = 12,
			Processor_Architecture_UNKNOWN = ushort.MaxValue
		}

		[DllImport("kernel32.dll")]
		internal static extern void GetNativeSystemInfo(out SYSTEM_INFO lpSystemInfo);

		[DllImport("kernel32.dll")]
		internal static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
	}
}
