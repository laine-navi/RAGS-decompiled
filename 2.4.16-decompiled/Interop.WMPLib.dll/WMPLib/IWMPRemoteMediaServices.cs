using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("CBB92747-741F-44FE-AB5B-F1A48F3B2A59")]
[InterfaceType(1)]
public interface IWMPRemoteMediaServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetServiceType([MarshalAs(UnmanagedType.BStr)] out string pbstrType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetApplicationName([MarshalAs(UnmanagedType.BStr)] out string pbstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetScriptableObject([MarshalAs(UnmanagedType.BStr)] out string pbstrName, [MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetCustomUIMode([MarshalAs(UnmanagedType.BStr)] out string pbstrFile);
}
