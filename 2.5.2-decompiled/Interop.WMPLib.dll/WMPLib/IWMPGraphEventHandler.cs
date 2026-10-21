using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("6B550945-018F-11D3-B14A-00C04F79FAA6")]
[ComConversionLoss]
public interface IWMPGraphEventHandler
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8151)]
	void NotifyGraphStateChange([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lGraphState);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8173)]
	void AsyncNotifyGraphStateChange([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lGraphState);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8153)]
	void NotifyRateChange([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] double dRate);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8157)]
	void NotifyPlaybackEnd([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [MarshalAs(UnmanagedType.BStr)] string bstrQueuedUrl, [ComAliasName("WMPLib.ULONG_PTR")] uint dwCurrentContext);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8156)]
	void NotifyStreamEnd([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8158)]
	void NotifyScriptCommand([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][MarshalAs(UnmanagedType.BStr)] string bstrCommand, [In][MarshalAs(UnmanagedType.BStr)] string bstrParam);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8172)]
	void NotifyEarlyScriptCommand([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][MarshalAs(UnmanagedType.BStr)] string bstrCommand, [In][MarshalAs(UnmanagedType.BStr)] string bstrParam, [In] double dTime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8159)]
	void NotifyMarkerHit([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lMarker);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8160)]
	void NotifyGraphError([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lErrMajor, [In] int lErrMinor, [In] int lCondition, [In][MarshalAs(UnmanagedType.BStr)] string bstrInfo, [In][MarshalAs(UnmanagedType.IUnknown)] object punkGraphData);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8161)]
	void NotifyAcquireCredentials([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][MarshalAs(UnmanagedType.BStr)] string bstrRealm, [In][MarshalAs(UnmanagedType.BStr)] string bstrSite, [In][Out] IntPtr bstrUser, [In][Out] IntPtr bstrPassword, [In][Out] ref uint pdwFlags, out bool pfCancel);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8178)]
	void NotifyUntrustedLicense([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][MarshalAs(UnmanagedType.BStr)] string bstrURL, out bool pfCancel);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8162)]
	void NotifyLicenseDialog([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][MarshalAs(UnmanagedType.BStr)] string bstrURL, [In][MarshalAs(UnmanagedType.BStr)] string bstrContent, [In] ref byte pPostData, [In] uint dwPostDataSize, [In] int lResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8163)]
	void NotifyNeedsIndividualization([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, out bool pfResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8165)]
	void NotifyNewMetadata([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8166)]
	void NotifyNewMediaCaps([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8167)]
	void NotifyDisconnect([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8168)]
	void NotifySave([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int fStarted, [In] int lResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8169)]
	void NotifyDelayClose([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] bool fDelay);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8170)]
	void NotifyDVD([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int lEventCode, [In] int lParam1, [In] int lParam2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8171)]
	void NotifyRequestAppThreadAction([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] uint dwAction);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8174)]
	void NotifyPrerollReady([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8177)]
	void NotifyNewIcons([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8179)]
	void NotifyStepComplete([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8180)]
	void NotifyNewBitrate([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] uint dwBitrate);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8181)]
	void NotifyGraphCreationPreRender([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][ComAliasName("WMPLib.ULONG_PTR")] uint punkFilterGraph, [In][ComAliasName("WMPLib.ULONG_PTR")] uint punkCardeaEncConfig, [In][ComAliasName("WMPLib.ULONG_PTR")] uint phrContinue, [In][ComAliasName("WMPLib.ULONG_PTR")] uint hEventToSet);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8182)]
	void NotifyGraphCreationPostRender([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][ComAliasName("WMPLib.ULONG_PTR")] uint punkFilterGraph, [In][ComAliasName("WMPLib.ULONG_PTR")] uint phrContinue, [In][ComAliasName("WMPLib.ULONG_PTR")] uint hEventToSet);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8186)]
	void NotifyGraphUserEvent([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In] int EventCode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8183)]
	void NotifyRevocation([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, out bool pfResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8184)]
	void NotifyNeedsWMGraphIndividualization([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph, [In][ComAliasName("WMPLib.ULONG_PTR")] uint phWnd, [In][ComAliasName("WMPLib.ULONG_PTR")] uint hIndivEvent, out bool pfCancel, out bool pfResult);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8185)]
	void NotifyNeedsFullscreen([In][ComAliasName("WMPLib.ULONG_PTR")] uint punkGraph);
}
