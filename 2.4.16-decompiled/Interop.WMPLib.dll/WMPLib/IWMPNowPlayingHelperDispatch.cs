using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("504F112E-77CC-4E3C-A073-5371B31D9B36")]
[TypeLibType(4160)]
public interface IWMPNowPlayingHelperDispatch
{
	// C# has no syntax for parameterized property 'viewFriendlyName'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2901)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2901)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string get_viewFriendlyName([In][MarshalAs(UnmanagedType.BStr)] string bstrView);

	// C# has no syntax for parameterized property 'viewPresetCount'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2902)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2902)]
	int get_viewPresetCount([In][MarshalAs(UnmanagedType.BStr)] string bstrView);

	// C# has no syntax for parameterized property 'viewPresetName'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2903)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2903)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string get_viewPresetName([In][MarshalAs(UnmanagedType.BStr)] string bstrView, [In] int nPresetIndex);

	// C# has no syntax for parameterized property 'effectFriendlyName'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2904)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2904)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string get_effectFriendlyName([In][MarshalAs(UnmanagedType.BStr)] string bstrEffect);

	// C# has no syntax for parameterized property 'effectPresetName'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2905)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2905)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string get_effectPresetName([In][MarshalAs(UnmanagedType.BStr)] string bstrEffect, [In] int nPresetIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2909)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string resolveDisplayView([In] bool fSafe);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2910)]
	bool isValidDisplayView([In][MarshalAs(UnmanagedType.BStr)] string bstrView);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2911)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getSkinFile();

	[DispId(2912)]
	bool captionsAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2912)]
		get;
	}

	[DispId(2913)]
	int linkAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2913)]
		get;
	}

	[DispId(2914)]
	int linkRequest
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2914)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2914)]
		[param: In]
		set;
	}

	[DispId(2915)]
	string linkRequestParams
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2915)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2915)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2917)]
	int getCurrentArtID([In] bool fLargeArt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2918)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getTimeString([In] double dTime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2919)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getCurrentScriptCommand([In][MarshalAs(UnmanagedType.BStr)] string bstrType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2920)]
	void calcLayout([In] int lWidth, [In] int lHeight, [In] bool vbCaptions, [In] bool vbBanner);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2921)]
	int getLayoutSize([In] int nProp);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2922)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object getRootPlaylist([In][MarshalAs(UnmanagedType.IDispatch)] object pPlaylist);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2923)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getHTMLViewURL();

	[DispId(2924)]
	bool canSendLink
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2924)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2925)]
	void sendLink([In] double dblStartTime, [In] double dblEndTime);

	[DispId(2926)]
	object editObj
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2926)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2926)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IUnknown)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2927)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getStatusString([In][MarshalAs(UnmanagedType.BStr)] string bstrStatusId);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2939)]
	int getStatusPct([In][MarshalAs(UnmanagedType.BStr)] string bstrStatusId);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2940)]
	int getStatusResult([In][MarshalAs(UnmanagedType.BStr)] string bstrStatusId);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2941)]
	int getStatusIcon([In][MarshalAs(UnmanagedType.BStr)] string bstrStatusId);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2942)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getStatusIdList();

	[DispId(2928)]
	string notificationString
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2928)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2930)]
	string htmlViewBaseURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2930)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2930)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(2933)]
	string htmlViewFullURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2933)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2933)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(2929)]
	int htmlViewSecureLock
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2929)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2929)]
		[param: In]
		set;
	}

	[DispId(2931)]
	bool htmlViewBusy
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2931)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2931)]
		[param: In]
		set;
	}

	[DispId(2932)]
	bool htmlViewShowCert
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2932)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2932)]
		[param: In]
		set;
	}

	[DispId(2934)]
	bool previousEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2934)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2934)]
		[param: In]
		set;
	}

	[DispId(2935)]
	bool doPreviousNow
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2935)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2935)]
		[param: In]
		set;
	}

	[DispId(2936)]
	int DPI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2936)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2937)]
	void clearColors();

	[DispId(2938)]
	string lastMessage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2938)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2938)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(2943)]
	bool inVistaPlus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2943)]
		get;
	}

	[DispId(2944)]
	bool isBidi
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2944)]
		get;
	}
}
