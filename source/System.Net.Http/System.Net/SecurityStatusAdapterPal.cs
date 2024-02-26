using System.Collections.Generic;
using System.ComponentModel;

namespace System.Net;

internal static class SecurityStatusAdapterPal
{
	private static readonly System.Collections.Generic.BidirectionalDictionary<global::Interop.SECURITY_STATUS, System.Net.SecurityStatusPalErrorCode> s_statusDictionary = new System.Collections.Generic.BidirectionalDictionary<global::Interop.SECURITY_STATUS, System.Net.SecurityStatusPalErrorCode>(43)
	{
		{
			global::Interop.SECURITY_STATUS.AlgorithmMismatch,
			System.Net.SecurityStatusPalErrorCode.AlgorithmMismatch
		},
		{
			global::Interop.SECURITY_STATUS.ApplicationProtocolMismatch,
			System.Net.SecurityStatusPalErrorCode.ApplicationProtocolMismatch
		},
		{
			global::Interop.SECURITY_STATUS.BadBinding,
			System.Net.SecurityStatusPalErrorCode.BadBinding
		},
		{
			global::Interop.SECURITY_STATUS.BufferNotEnough,
			System.Net.SecurityStatusPalErrorCode.BufferNotEnough
		},
		{
			global::Interop.SECURITY_STATUS.CannotInstall,
			System.Net.SecurityStatusPalErrorCode.CannotInstall
		},
		{
			global::Interop.SECURITY_STATUS.CannotPack,
			System.Net.SecurityStatusPalErrorCode.CannotPack
		},
		{
			global::Interop.SECURITY_STATUS.CertExpired,
			System.Net.SecurityStatusPalErrorCode.CertExpired
		},
		{
			global::Interop.SECURITY_STATUS.CertUnknown,
			System.Net.SecurityStatusPalErrorCode.CertUnknown
		},
		{
			global::Interop.SECURITY_STATUS.CompAndContinue,
			System.Net.SecurityStatusPalErrorCode.CompAndContinue
		},
		{
			global::Interop.SECURITY_STATUS.CompleteNeeded,
			System.Net.SecurityStatusPalErrorCode.CompleteNeeded
		},
		{
			global::Interop.SECURITY_STATUS.ContextExpired,
			System.Net.SecurityStatusPalErrorCode.ContextExpired
		},
		{
			global::Interop.SECURITY_STATUS.ContinueNeeded,
			System.Net.SecurityStatusPalErrorCode.ContinueNeeded
		},
		{
			global::Interop.SECURITY_STATUS.CredentialsNeeded,
			System.Net.SecurityStatusPalErrorCode.CredentialsNeeded
		},
		{
			global::Interop.SECURITY_STATUS.DecryptFailure,
			System.Net.SecurityStatusPalErrorCode.DecryptFailure
		},
		{
			global::Interop.SECURITY_STATUS.DowngradeDetected,
			System.Net.SecurityStatusPalErrorCode.DowngradeDetected
		},
		{
			global::Interop.SECURITY_STATUS.IllegalMessage,
			System.Net.SecurityStatusPalErrorCode.IllegalMessage
		},
		{
			global::Interop.SECURITY_STATUS.IncompleteCredentials,
			System.Net.SecurityStatusPalErrorCode.IncompleteCredentials
		},
		{
			global::Interop.SECURITY_STATUS.IncompleteMessage,
			System.Net.SecurityStatusPalErrorCode.IncompleteMessage
		},
		{
			global::Interop.SECURITY_STATUS.InternalError,
			System.Net.SecurityStatusPalErrorCode.InternalError
		},
		{
			global::Interop.SECURITY_STATUS.InvalidHandle,
			System.Net.SecurityStatusPalErrorCode.InvalidHandle
		},
		{
			global::Interop.SECURITY_STATUS.InvalidToken,
			System.Net.SecurityStatusPalErrorCode.InvalidToken
		},
		{
			global::Interop.SECURITY_STATUS.LogonDenied,
			System.Net.SecurityStatusPalErrorCode.LogonDenied
		},
		{
			global::Interop.SECURITY_STATUS.MessageAltered,
			System.Net.SecurityStatusPalErrorCode.MessageAltered
		},
		{
			global::Interop.SECURITY_STATUS.NoAuthenticatingAuthority,
			System.Net.SecurityStatusPalErrorCode.NoAuthenticatingAuthority
		},
		{
			global::Interop.SECURITY_STATUS.NoImpersonation,
			System.Net.SecurityStatusPalErrorCode.NoImpersonation
		},
		{
			global::Interop.SECURITY_STATUS.NoCredentials,
			System.Net.SecurityStatusPalErrorCode.NoCredentials
		},
		{
			global::Interop.SECURITY_STATUS.NotOwner,
			System.Net.SecurityStatusPalErrorCode.NotOwner
		},
		{
			global::Interop.SECURITY_STATUS.OK,
			System.Net.SecurityStatusPalErrorCode.OK
		},
		{
			global::Interop.SECURITY_STATUS.OutOfMemory,
			System.Net.SecurityStatusPalErrorCode.OutOfMemory
		},
		{
			global::Interop.SECURITY_STATUS.OutOfSequence,
			System.Net.SecurityStatusPalErrorCode.OutOfSequence
		},
		{
			global::Interop.SECURITY_STATUS.PackageNotFound,
			System.Net.SecurityStatusPalErrorCode.PackageNotFound
		},
		{
			global::Interop.SECURITY_STATUS.QopNotSupported,
			System.Net.SecurityStatusPalErrorCode.QopNotSupported
		},
		{
			global::Interop.SECURITY_STATUS.Renegotiate,
			System.Net.SecurityStatusPalErrorCode.Renegotiate
		},
		{
			global::Interop.SECURITY_STATUS.SecurityQosFailed,
			System.Net.SecurityStatusPalErrorCode.SecurityQosFailed
		},
		{
			global::Interop.SECURITY_STATUS.SmartcardLogonRequired,
			System.Net.SecurityStatusPalErrorCode.SmartcardLogonRequired
		},
		{
			global::Interop.SECURITY_STATUS.TargetUnknown,
			System.Net.SecurityStatusPalErrorCode.TargetUnknown
		},
		{
			global::Interop.SECURITY_STATUS.TimeSkew,
			System.Net.SecurityStatusPalErrorCode.TimeSkew
		},
		{
			global::Interop.SECURITY_STATUS.UnknownCredentials,
			System.Net.SecurityStatusPalErrorCode.UnknownCredentials
		},
		{
			global::Interop.SECURITY_STATUS.UnsupportedPreauth,
			System.Net.SecurityStatusPalErrorCode.UnsupportedPreauth
		},
		{
			global::Interop.SECURITY_STATUS.Unsupported,
			System.Net.SecurityStatusPalErrorCode.Unsupported
		},
		{
			global::Interop.SECURITY_STATUS.UntrustedRoot,
			System.Net.SecurityStatusPalErrorCode.UntrustedRoot
		},
		{
			global::Interop.SECURITY_STATUS.WrongPrincipal,
			System.Net.SecurityStatusPalErrorCode.WrongPrincipal
		},
		{
			global::Interop.SECURITY_STATUS.NoRenegotiation,
			System.Net.SecurityStatusPalErrorCode.NoRenegotiation
		}
	};

	internal static System.Net.SecurityStatusPal GetSecurityStatusPalFromInterop(global::Interop.SECURITY_STATUS win32SecurityStatus, bool attachException = false)
	{
		if (!s_statusDictionary.TryGetForward(win32SecurityStatus, out var item))
		{
			throw new System.Net.InternalException(win32SecurityStatus);
		}
		if (attachException)
		{
			return new System.Net.SecurityStatusPal(item, new Win32Exception((int)win32SecurityStatus));
		}
		return new System.Net.SecurityStatusPal(item);
	}

	internal static global::Interop.SECURITY_STATUS GetInteropFromSecurityStatusPal(System.Net.SecurityStatusPal status)
	{
		if (!s_statusDictionary.TryGetBackward(status.ErrorCode, out var item))
		{
			throw new System.Net.InternalException(status.ErrorCode);
		}
		return item;
	}
}