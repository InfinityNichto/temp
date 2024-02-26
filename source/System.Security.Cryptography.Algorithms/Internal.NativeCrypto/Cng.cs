using System;
using System.Runtime.InteropServices;
using Internal.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace Internal.NativeCrypto;

internal static class Cng
{
	[Flags]
	public enum OpenAlgorithmProviderFlags
	{
		NONE = 0,
		BCRYPT_ALG_HANDLE_HMAC_FLAG = 8
	}

	internal static class Interop
	{
		[DllImport("BCrypt.dll", CharSet = CharSet.Unicode)]
		public static extern global::Interop.BCrypt.NTSTATUS BCryptOpenAlgorithmProvider(out SafeAlgorithmHandle phAlgorithm, string pszAlgId, string pszImplementation, int dwFlags);

		[DllImport("BCrypt.dll", CharSet = CharSet.Unicode)]
		public static extern global::Interop.BCrypt.NTSTATUS BCryptSetProperty(SafeAlgorithmHandle hObject, string pszProperty, string pbInput, int cbInput, int dwFlags);

		[DllImport("BCrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "BCryptSetProperty")]
		private static extern global::Interop.BCrypt.NTSTATUS BCryptSetIntPropertyPrivate(SafeBCryptHandle hObject, string pszProperty, ref int pdwInput, int cbInput, int dwFlags);

		public static global::Interop.BCrypt.NTSTATUS BCryptSetIntProperty(SafeBCryptHandle hObject, string pszProperty, ref int pdwInput, int dwFlags)
		{
			return BCryptSetIntPropertyPrivate(hObject, pszProperty, ref pdwInput, 4, dwFlags);
		}
	}

	public static SafeAlgorithmHandle BCryptOpenAlgorithmProvider(string pszAlgId, string pszImplementation, OpenAlgorithmProviderFlags dwFlags)
	{
		SafeAlgorithmHandle phAlgorithm;
		global::Interop.BCrypt.NTSTATUS nTSTATUS = Interop.BCryptOpenAlgorithmProvider(out phAlgorithm, pszAlgId, pszImplementation, (int)dwFlags);
		if (nTSTATUS != 0)
		{
			throw CreateCryptographicException(nTSTATUS);
		}
		return phAlgorithm;
	}

	public static void SetFeedbackSize(this SafeAlgorithmHandle hAlg, int dwFeedbackSize)
	{
		global::Interop.BCrypt.NTSTATUS nTSTATUS = Interop.BCryptSetIntProperty(hAlg, "MessageBlockLength", ref dwFeedbackSize, 0);
		if (nTSTATUS != 0)
		{
			throw CreateCryptographicException(nTSTATUS);
		}
	}

	public static void SetCipherMode(this SafeAlgorithmHandle hAlg, string cipherMode)
	{
		global::Interop.BCrypt.NTSTATUS nTSTATUS = Interop.BCryptSetProperty(hAlg, "ChainingMode", cipherMode, (cipherMode.Length + 1) * 2, 0);
		if (nTSTATUS != 0)
		{
			throw CreateCryptographicException(nTSTATUS);
		}
	}

	public static void SetEffectiveKeyLength(this SafeAlgorithmHandle hAlg, int effectiveKeyLength)
	{
		global::Interop.BCrypt.NTSTATUS nTSTATUS = Interop.BCryptSetIntProperty(hAlg, "EffectiveKeyLength", ref effectiveKeyLength, 0);
		if (nTSTATUS != 0)
		{
			throw CreateCryptographicException(nTSTATUS);
		}
	}

	private static Exception CreateCryptographicException(global::Interop.BCrypt.NTSTATUS ntStatus)
	{
		int hr = (int)(ntStatus | (global::Interop.BCrypt.NTSTATUS)16777216u);
		return hr.ToCryptographicException();
	}
}