namespace System.IO.Compression;

internal enum InflaterState
{
	ReadingHeader = 0,
	ReadingBFinal = 2,
	ReadingBType = 3,
	ReadingNumLitCodes = 4,
	ReadingNumDistCodes = 5,
	ReadingNumCodeLengthCodes = 6,
	ReadingCodeLengthCodes = 7,
	ReadingTreeCodesBefore = 8,
	ReadingTreeCodesAfter = 9,
	DecodeTop = 10,
	HaveInitialLength = 11,
	HaveFullLength = 12,
	HaveDistCode = 13,
	UncompressedAligning = 15,
	UncompressedByte1 = 16,
	UncompressedByte2 = 17,
	UncompressedByte3 = 18,
	UncompressedByte4 = 19,
	DecodingUncompressed = 20,
	StartReadingFooter = 21,
	ReadingFooter = 22,
	VerifyingFooter = 23,
	Done = 24
}
