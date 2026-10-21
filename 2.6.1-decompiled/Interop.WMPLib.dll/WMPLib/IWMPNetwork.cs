using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("EC21B779-EDEF-462D-BBA4-AD9DDE2B29A7")]
[TypeLibType(4160)]
public interface IWMPNetwork
{
	[DispId(801)]
	int bandWidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(801)]
		get;
	}

	[DispId(802)]
	int recoveredPackets
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(802)]
		get;
	}

	[DispId(803)]
	string sourceProtocol
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(803)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(804)]
	int receivedPackets
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(804)]
		get;
	}

	[DispId(805)]
	int lostPackets
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(805)]
		get;
	}

	[DispId(806)]
	int receptionQuality
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(806)]
		get;
	}

	[DispId(807)]
	int bufferingCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(807)]
		get;
	}

	[DispId(808)]
	int bufferingProgress
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(808)]
		get;
	}

	[DispId(809)]
	int bufferingTime
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(809)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(809)]
		[param: In]
		set;
	}

	[DispId(810)]
	int frameRate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(810)]
		get;
	}

	[DispId(811)]
	int maxBitRate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(811)]
		get;
	}

	[DispId(812)]
	int bitRate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(812)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(813)]
	int getProxySettings([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(814)]
	void setProxySettings([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol, [In] int lProxySetting);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(815)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getProxyName([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(816)]
	void setProxyName([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol, [In][MarshalAs(UnmanagedType.BStr)] string bstrProxyName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(817)]
	int getProxyPort([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(818)]
	void setProxyPort([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol, [In] int lProxyPort);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(819)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getProxyExceptionList([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(820)]
	void setProxyExceptionList([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol, [In][MarshalAs(UnmanagedType.BStr)] string pbstrExceptionList);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(821)]
	bool getProxyBypassForLocal([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(822)]
	void setProxyBypassForLocal([In][MarshalAs(UnmanagedType.BStr)] string bstrProtocol, [In] bool fBypassForLocal);

	[DispId(823)]
	int maxBandwidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(823)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(823)]
		[param: In]
		set;
	}

	[DispId(824)]
	int downloadProgress
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(824)]
		get;
	}

	[DispId(825)]
	int encodedFrameRate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(825)]
		get;
	}

	[DispId(826)]
	int framesSkipped
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(826)]
		get;
	}
}
