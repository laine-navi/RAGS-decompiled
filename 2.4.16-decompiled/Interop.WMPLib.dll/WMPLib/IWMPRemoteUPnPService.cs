using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("17E5DC63-E296-4EDE-B9CC-CF57D18ED10E")]
public interface IWMPRemoteUPnPService
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10121)]
	void RegisterEvent([In][MarshalAs(UnmanagedType.BStr)] string bstrVariableName, [In][MarshalAs(UnmanagedType.IDispatch)] object pdispJScriptCode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10122)]
	void UnregisterEvent([In][MarshalAs(UnmanagedType.BStr)] string bstrVariableName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10123)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string ID();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10124)]
	void InvokeAction([In][MarshalAs(UnmanagedType.BStr)] string bstrActionName, [In][MarshalAs(UnmanagedType.IDispatch)] object pdispInArgs, [In][MarshalAs(UnmanagedType.IDispatch)] object pdispOutArgs, [In][MarshalAs(UnmanagedType.IDispatch)] object pdispRetVals);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10125)]
	int LastTransportStatus();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10126)]
	[return: MarshalAs(UnmanagedType.Struct)]
	object QueryStateVariable([In][MarshalAs(UnmanagedType.BStr)] string bstrVariableName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10127)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string ServiceTypeIdentifier();
}
