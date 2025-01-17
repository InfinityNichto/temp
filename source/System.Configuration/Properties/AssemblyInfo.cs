using System;
using System.Configuration;
using System.Configuration.Internal;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

[assembly: CLSCompliant(true)]
[assembly: AssemblyDefaultAlias("System.Configuration")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.Configuration")]
[assembly: AssemblyFileVersion("6.0.21.52210")]
[assembly: AssemblyInformationalVersion("6.0.0+4822e3c3aa77eb82b2fb33c9321f923cf11ddde6")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Configuration")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("4.0.0.0")]
[assembly: TypeForwardedTo(typeof(AppSettingsSection))]
[assembly: TypeForwardedTo(typeof(CallbackValidator))]
[assembly: TypeForwardedTo(typeof(CallbackValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(CommaDelimitedStringCollection))]
[assembly: TypeForwardedTo(typeof(CommaDelimitedStringCollectionConverter))]
[assembly: TypeForwardedTo(typeof(Configuration))]
[assembly: TypeForwardedTo(typeof(ConfigurationAllowDefinition))]
[assembly: TypeForwardedTo(typeof(ConfigurationAllowExeDefinition))]
[assembly: TypeForwardedTo(typeof(ConfigurationCollectionAttribute))]
[assembly: TypeForwardedTo(typeof(ConfigurationConverterBase))]
[assembly: TypeForwardedTo(typeof(ConfigurationElement))]
[assembly: TypeForwardedTo(typeof(ConfigurationElementCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationElementCollectionType))]
[assembly: TypeForwardedTo(typeof(ConfigurationElementProperty))]
[assembly: TypeForwardedTo(typeof(ConfigurationErrorsException))]
[assembly: TypeForwardedTo(typeof(ConfigurationFileMap))]
[assembly: TypeForwardedTo(typeof(ConfigurationLocation))]
[assembly: TypeForwardedTo(typeof(ConfigurationLocationCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationLockCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationManager))]
[assembly: TypeForwardedTo(typeof(ConfigurationPermission))]
[assembly: TypeForwardedTo(typeof(ConfigurationPermissionAttribute))]
[assembly: TypeForwardedTo(typeof(ConfigurationProperty))]
[assembly: TypeForwardedTo(typeof(ConfigurationPropertyAttribute))]
[assembly: TypeForwardedTo(typeof(ConfigurationPropertyCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationPropertyOptions))]
[assembly: TypeForwardedTo(typeof(ConfigurationSaveMode))]
[assembly: TypeForwardedTo(typeof(ConfigurationSection))]
[assembly: TypeForwardedTo(typeof(ConfigurationSectionCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationSectionGroup))]
[assembly: TypeForwardedTo(typeof(ConfigurationSectionGroupCollection))]
[assembly: TypeForwardedTo(typeof(ConfigurationUserLevel))]
[assembly: TypeForwardedTo(typeof(ConfigurationValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(ConfigurationValidatorBase))]
[assembly: TypeForwardedTo(typeof(ConnectionStringSettings))]
[assembly: TypeForwardedTo(typeof(ConnectionStringSettingsCollection))]
[assembly: TypeForwardedTo(typeof(ConnectionStringsSection))]
[assembly: TypeForwardedTo(typeof(ContextInformation))]
[assembly: TypeForwardedTo(typeof(DefaultSection))]
[assembly: TypeForwardedTo(typeof(DefaultValidator))]
[assembly: TypeForwardedTo(typeof(DpapiProtectedConfigurationProvider))]
[assembly: TypeForwardedTo(typeof(ElementInformation))]
[assembly: TypeForwardedTo(typeof(ExeConfigurationFileMap))]
[assembly: TypeForwardedTo(typeof(ExeContext))]
[assembly: TypeForwardedTo(typeof(GenericEnumConverter))]
[assembly: TypeForwardedTo(typeof(IgnoreSection))]
[assembly: TypeForwardedTo(typeof(InfiniteIntConverter))]
[assembly: TypeForwardedTo(typeof(InfiniteTimeSpanConverter))]
[assembly: TypeForwardedTo(typeof(IntegerValidator))]
[assembly: TypeForwardedTo(typeof(IntegerValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(DelegatingConfigHost))]
[assembly: TypeForwardedTo(typeof(IConfigErrorInfo))]
[assembly: TypeForwardedTo(typeof(IConfigSystem))]
[assembly: TypeForwardedTo(typeof(IConfigurationManagerHelper))]
[assembly: TypeForwardedTo(typeof(IConfigurationManagerInternal))]
[assembly: TypeForwardedTo(typeof(IInternalConfigClientHost))]
[assembly: TypeForwardedTo(typeof(IInternalConfigConfigurationFactory))]
[assembly: TypeForwardedTo(typeof(IInternalConfigHost))]
[assembly: TypeForwardedTo(typeof(IInternalConfigRecord))]
[assembly: TypeForwardedTo(typeof(IInternalConfigRoot))]
[assembly: TypeForwardedTo(typeof(IInternalConfigSettingsFactory))]
[assembly: TypeForwardedTo(typeof(IInternalConfigSystem))]
[assembly: TypeForwardedTo(typeof(InternalConfigEventArgs))]
[assembly: TypeForwardedTo(typeof(InternalConfigEventHandler))]
[assembly: TypeForwardedTo(typeof(StreamChangeCallback))]
[assembly: TypeForwardedTo(typeof(KeyValueConfigurationCollection))]
[assembly: TypeForwardedTo(typeof(KeyValueConfigurationElement))]
[assembly: TypeForwardedTo(typeof(LongValidator))]
[assembly: TypeForwardedTo(typeof(LongValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(NameValueConfigurationCollection))]
[assembly: TypeForwardedTo(typeof(NameValueConfigurationElement))]
[assembly: TypeForwardedTo(typeof(OverrideMode))]
[assembly: TypeForwardedTo(typeof(PositiveTimeSpanValidator))]
[assembly: TypeForwardedTo(typeof(PositiveTimeSpanValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(PropertyInformation))]
[assembly: TypeForwardedTo(typeof(PropertyInformationCollection))]
[assembly: TypeForwardedTo(typeof(PropertyValueOrigin))]
[assembly: TypeForwardedTo(typeof(ProtectedConfiguration))]
[assembly: TypeForwardedTo(typeof(ProtectedConfigurationProvider))]
[assembly: TypeForwardedTo(typeof(ProtectedConfigurationProviderCollection))]
[assembly: TypeForwardedTo(typeof(ProtectedConfigurationSection))]
[assembly: TypeForwardedTo(typeof(ProtectedProviderSettings))]
[assembly: TypeForwardedTo(typeof(ProviderBase))]
[assembly: TypeForwardedTo(typeof(ProviderCollection))]
[assembly: TypeForwardedTo(typeof(ProviderException))]
[assembly: TypeForwardedTo(typeof(ProviderSettings))]
[assembly: TypeForwardedTo(typeof(ProviderSettingsCollection))]
[assembly: TypeForwardedTo(typeof(RegexStringValidator))]
[assembly: TypeForwardedTo(typeof(RegexStringValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(RsaProtectedConfigurationProvider))]
[assembly: TypeForwardedTo(typeof(SectionInformation))]
[assembly: TypeForwardedTo(typeof(StringValidator))]
[assembly: TypeForwardedTo(typeof(StringValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(SubclassTypeValidator))]
[assembly: TypeForwardedTo(typeof(SubclassTypeValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(TimeSpanMinutesConverter))]
[assembly: TypeForwardedTo(typeof(TimeSpanMinutesOrInfiniteConverter))]
[assembly: TypeForwardedTo(typeof(TimeSpanSecondsConverter))]
[assembly: TypeForwardedTo(typeof(TimeSpanSecondsOrInfiniteConverter))]
[assembly: TypeForwardedTo(typeof(TimeSpanValidator))]
[assembly: TypeForwardedTo(typeof(TimeSpanValidatorAttribute))]
[assembly: TypeForwardedTo(typeof(TypeNameConverter))]
[assembly: TypeForwardedTo(typeof(ValidatorCallback))]
[assembly: TypeForwardedTo(typeof(WhiteSpaceTrimStringConverter))]
[module: SkipLocalsInit]
