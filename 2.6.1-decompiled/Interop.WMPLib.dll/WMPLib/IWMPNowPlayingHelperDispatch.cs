using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("504F112E-77CC-4E3C-A073-5371B31D9B36")]
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

	[DispId(2945)]
	bool isOCX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2945)]
		get;
	}

	[DispId(2946)]
	bool hoverTransportsEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2946)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2947)]
	void initRipHelper();

	[DispId(2948)]
	bool isAudioCD
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2948)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2948)]
		[param: In]
		set;
	}

	[DispId(2949)]
	bool canRip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2949)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2949)]
		[param: In]
		set;
	}

	[DispId(2950)]
	bool isRipping
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2950)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2950)]
		[param: In]
		set;
	}

	[DispId(2951)]
	string currentDrive
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2951)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2951)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2952)]
	void startRip();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2953)]
	void stopRip();

	[DispId(2954)]
	bool showMMO
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2954)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2954)]
		[param: In]
		set;
	}

	[DispId(2971)]
	bool MMOVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2971)]
		get;
	}

	[DispId(2955)]
	bool suggestionsVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2955)]
		get;
	}

	[DispId(2956)]
	string suggestionsTextColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2956)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2964)]
	string fontFace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2964)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2965)]
	int fontSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2965)]
		get;
	}

	[DispId(2966)]
	string backgroundColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2966)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2957)]
	int doubleClickTime
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2957)]
		get;
	}

	[DispId(2958)]
	bool playAgain
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2958)]
		get;
	}

	[DispId(2959)]
	bool previousPlaylistAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2959)]
		get;
	}

	[DispId(2960)]
	bool nextPlaylistAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2960)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2961)]
	void nextPlaylist();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2962)]
	void previousPlaylist();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2972)]
	void playOffsetMedia([In] int iOffset);

	[DispId(2963)]
	bool basketVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2963)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2963)]
		[param: In]
		set;
	}

	[DispId(2967)]
	string mmoTextColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2967)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2968)]
	bool backgroundVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2968)]
		get;
	}

	[DispId(2969)]
	bool backgroundEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2969)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2969)]
		[param: In]
		set;
	}

	[DispId(2970)]
	int backgroundIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2970)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2970)]
		[param: In]
		set;
	}

	[DispId(2973)]
	string upNext
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2973)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2974)]
	bool playbackOverlayVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2974)]
		get;
	}

	[DispId(2975)]
	bool remoted
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2975)]
		get;
	}

	[DispId(2976)]
	bool glassEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2976)]
		get;
	}

	[DispId(2977)]
	bool highContrast
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2977)]
		get;
	}

	[DispId(2978)]
	string testHighContrast
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2978)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2979)]
	void sessionPlaylistCount(out int pVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2980)]
	void setGestureStatus([In][MarshalAs(UnmanagedType.IDispatch)] object pObject, [In] int newVal);

	[DispId(2981)]
	string metadataString
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2981)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2981)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(2982)]
	int albumArtAlpha
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2982)]
		get;
	}

	[DispId(2983)]
	bool playerModeAlbumArtSelected
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2983)]
		get;
	}

	[DispId(2984)]
	bool inFullScreen
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2984)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2985)]
	void syncToAlbumArt([In][MarshalAs(UnmanagedType.IDispatch)] object pObject, [In] int iOffsetFromCurrentMedia, [In][MarshalAs(UnmanagedType.BStr)] string bstrFallbackImage);
}
