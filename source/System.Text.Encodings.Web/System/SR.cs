using System.Resources;
using FxResources.System.Text.Encodings.Web;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string TextEncoderDoesNotImplementMaxOutputCharsPerInputChar => GetResourceString("TextEncoderDoesNotImplementMaxOutputCharsPerInputChar");

	private static bool UsingResourceKeys()
	{
		return s_usingResourceKeys;
	}

	internal static string GetResourceString(string resourceKey)
	{
		if (UsingResourceKeys())
		{
			return resourceKey;
		}
		string result = null;
		try
		{
			result = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		return result;
	}
}