namespace System.Net.Mail;

public enum SmtpStatusCode
{
	SystemStatus = 211,
	HelpMessage = 214,
	ServiceReady = 220,
	ServiceClosingTransmissionChannel = 221,
	Ok = 250,
	UserNotLocalWillForward = 251,
	CannotVerifyUserWillAttemptDelivery = 252,
	StartMailInput = 354,
	ServiceNotAvailable = 421,
	MailboxBusy = 450,
	LocalErrorInProcessing = 451,
	InsufficientStorage = 452,
	ClientNotPermitted = 454,
	CommandUnrecognized = 500,
	SyntaxError = 501,
	CommandNotImplemented = 502,
	BadCommandSequence = 503,
	MustIssueStartTlsFirst = 530,
	CommandParameterNotImplemented = 504,
	MailboxUnavailable = 550,
	UserNotLocalTryAlternatePath = 551,
	ExceededStorageAllocation = 552,
	MailboxNameNotAllowed = 553,
	TransactionFailed = 554,
	GeneralFailure = -1
}
