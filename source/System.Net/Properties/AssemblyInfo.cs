using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.PeerToPeer;
using System.Net.PeerToPeer.Collaboration;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

[assembly: CLSCompliant(true)]
[assembly: AssemblyDefaultAlias("System.Net")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.Net")]
[assembly: AssemblyFileVersion("6.0.21.52210")]
[assembly: AssemblyInformationalVersion("6.0.0+4822e3c3aa77eb82b2fb33c9321f923cf11ddde6")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Net")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("4.0.0.0")]
[assembly: TypeForwardedTo(typeof(Cookie))]
[assembly: TypeForwardedTo(typeof(CookieCollection))]
[assembly: TypeForwardedTo(typeof(CookieContainer))]
[assembly: TypeForwardedTo(typeof(CookieException))]
[assembly: TypeForwardedTo(typeof(DnsEndPoint))]
[assembly: TypeForwardedTo(typeof(DownloadProgressChangedEventArgs))]
[assembly: TypeForwardedTo(typeof(DownloadProgressChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(DownloadStringCompletedEventArgs))]
[assembly: TypeForwardedTo(typeof(DownloadStringCompletedEventHandler))]
[assembly: TypeForwardedTo(typeof(EndPoint))]
[assembly: TypeForwardedTo(typeof(HttpRequestHeader))]
[assembly: TypeForwardedTo(typeof(HttpStatusCode))]
[assembly: TypeForwardedTo(typeof(HttpWebRequest))]
[assembly: TypeForwardedTo(typeof(HttpWebResponse))]
[assembly: TypeForwardedTo(typeof(ICredentials))]
[assembly: TypeForwardedTo(typeof(IPAddress))]
[assembly: TypeForwardedTo(typeof(IPEndPoint))]
[assembly: TypeForwardedTo(typeof(IWebRequestCreate))]
[assembly: TypeForwardedTo(typeof(NetworkCredential))]
[assembly: TypeForwardedTo(typeof(NetworkAddressChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(NetworkChange))]
[assembly: TypeForwardedTo(typeof(NetworkInterface))]
[assembly: TypeForwardedTo(typeof(OpenReadCompletedEventArgs))]
[assembly: TypeForwardedTo(typeof(OpenReadCompletedEventHandler))]
[assembly: TypeForwardedTo(typeof(OpenWriteCompletedEventArgs))]
[assembly: TypeForwardedTo(typeof(OpenWriteCompletedEventHandler))]
[assembly: TypeForwardedTo(typeof(PeerCollaborationPermission))]
[assembly: TypeForwardedTo(typeof(PeerCollaborationPermissionAttribute))]
[assembly: TypeForwardedTo(typeof(PnrpPermission))]
[assembly: TypeForwardedTo(typeof(PnrpPermissionAttribute))]
[assembly: TypeForwardedTo(typeof(PnrpScope))]
[assembly: TypeForwardedTo(typeof(ProtocolViolationException))]
[assembly: TypeForwardedTo(typeof(SocketAddress))]
[assembly: TypeForwardedTo(typeof(AddressFamily))]
[assembly: TypeForwardedTo(typeof(ProtocolType))]
[assembly: TypeForwardedTo(typeof(Socket))]
[assembly: TypeForwardedTo(typeof(SocketAsyncEventArgs))]
[assembly: TypeForwardedTo(typeof(SocketAsyncOperation))]
[assembly: TypeForwardedTo(typeof(SocketError))]
[assembly: TypeForwardedTo(typeof(SocketException))]
[assembly: TypeForwardedTo(typeof(SocketShutdown))]
[assembly: TypeForwardedTo(typeof(SocketType))]
[assembly: TypeForwardedTo(typeof(UploadProgressChangedEventArgs))]
[assembly: TypeForwardedTo(typeof(UploadProgressChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(UploadStringCompletedEventArgs))]
[assembly: TypeForwardedTo(typeof(UploadStringCompletedEventHandler))]
[assembly: TypeForwardedTo(typeof(WebClient))]
[assembly: TypeForwardedTo(typeof(WebException))]
[assembly: TypeForwardedTo(typeof(WebExceptionStatus))]
[assembly: TypeForwardedTo(typeof(WebHeaderCollection))]
[assembly: TypeForwardedTo(typeof(WebRequest))]
[assembly: TypeForwardedTo(typeof(WebResponse))]
[assembly: TypeForwardedTo(typeof(WriteStreamClosedEventArgs))]
[assembly: TypeForwardedTo(typeof(WriteStreamClosedEventHandler))]
[module: SkipLocalsInit]