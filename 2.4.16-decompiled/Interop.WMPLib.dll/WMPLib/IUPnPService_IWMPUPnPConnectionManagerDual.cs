using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("1AF41667-542C-42EA-BF53-DC101168C503")]
public interface IUPnPService_IWMPUPnPConnectionManagerDual
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
	void GetProtocolInfo([In][Out][MarshalAs(UnmanagedType.BStr)] ref string pSourceProtocol, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pSinkProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	void PrepareForConnection([In][MarshalAs(UnmanagedType.BStr)] string remoteProtocolInfo, [In][MarshalAs(UnmanagedType.BStr)] string peerConnectionManager, [In] int peerConnectionID, [In][MarshalAs(UnmanagedType.BStr)] string direction, [In][Out] ref int pConnectionID, [In][Out] ref int pAVTransportID, [In][Out] ref int pResID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(13)]
	void ConnectionComplete([In] int connectionID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(14)]
	void GetCurrentConnectionIDs([In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentConnectionIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(15)]
	void GetCurrentConnectionInfo([In] int connectionID, [In][Out] ref int pResID, [In][Out] ref int pAVTransportID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pProtocolInfo, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pPeerConnectionManager, [In][Out] ref int pPeerConnectionID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pDirection, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pStatus);
}
