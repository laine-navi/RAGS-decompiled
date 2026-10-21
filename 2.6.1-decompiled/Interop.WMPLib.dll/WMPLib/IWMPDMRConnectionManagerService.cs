using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("FB61CD38-8DE7-4479-8B76-A8D097C20C70")]
public interface IWMPDMRConnectionManagerService
{
	[DispId(1)]
	string SourceProtocolInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2)]
	string SinkProtocolInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3)]
	string CurrentConnectionIDs
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(4)]
	string A_ARG_TYPE_ConnectionStatus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5)]
	string A_ARG_TYPE_ConnectionManager
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(6)]
	string A_ARG_TYPE_Direction
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(7)]
	string A_ARG_TYPE_ProtocolInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(8)]
	int A_ARG_TYPE_ConnectionID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		get;
	}

	[DispId(9)]
	int A_ARG_TYPE_AVTransportID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		get;
	}

	[DispId(10)]
	int A_ARG_TYPE_RcsID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(11)]
	void GetProtocolInfo([In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrSource, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrSink);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	void GetCurrentConnectionIDs([In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrConnectionIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(13)]
	void GetCurrentConnectionInfo([In] int lConnectionID, [In][Out] ref int plResID, [In][Out] ref int plAVTransportID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrProtocolInfo, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrPeerConnectionManager, [In][Out] ref int plPeerConnectionID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrDirection, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrStatus);
}
