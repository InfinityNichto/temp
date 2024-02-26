using System.Runtime.Versioning;

namespace System;

[RequiresPreviewFeatures("Generic Math is in preview.", Url = "https://aka.ms/dotnet-warnings/generic-math-preview")]
public interface IAdditionOperators<TSelf, TOther, TResult> where TSelf : IAdditionOperators<TSelf, TOther, TResult>
{
	static abstract TResult operator +(TSelf left, TOther right);
}