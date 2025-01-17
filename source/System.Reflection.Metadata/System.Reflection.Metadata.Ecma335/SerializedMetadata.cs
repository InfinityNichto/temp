using System.Collections.Immutable;

namespace System.Reflection.Metadata.Ecma335;

internal sealed class SerializedMetadata
{
	internal readonly ImmutableArray<int> StringMap;

	internal readonly BlobBuilder StringHeap;

	internal readonly MetadataSizes Sizes;

	public SerializedMetadata(MetadataSizes sizes, BlobBuilder stringHeap, ImmutableArray<int> stringMap)
	{
		Sizes = sizes;
		StringHeap = stringHeap;
		StringMap = stringMap;
	}
}
