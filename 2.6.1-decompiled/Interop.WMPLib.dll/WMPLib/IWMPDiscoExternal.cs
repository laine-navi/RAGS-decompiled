using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("A915CEA2-72DF-41E1-A576-EF0BAE5E5169")]
public interface IWMPDiscoExternal : IWMPSubscriptionServiceExternal
{
	[DispId(10005)]
	new string version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10005)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10012)]
	new string appColorLight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10012)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10018)]
	new object OnColorChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10018)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(10013)]
	new string appColorMedium
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10013)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10014)]
	new string appColorDark
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10014)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10015)]
	new string appColorButtonHighlight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10015)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10016)]
	new string appColorButtonShadow
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10016)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10017)]
	new string appColorButtonHoverFace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10017)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10026)]
	new void NavigateTaskPaneURL([In][MarshalAs(UnmanagedType.BStr)] string bstrKeyName, [In][MarshalAs(UnmanagedType.BStr)] string bstrTaskPane, [In][MarshalAs(UnmanagedType.BStr)] string bstrParams);

	[DispId(10027)]
	new string SelectedTaskPane
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10027)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10027)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(10009)]
	new IWMPDownloadManager DownloadManager
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(10028)]
	object OnLoginChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10028)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(10029)]
	bool userLoggedIn
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10029)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10030)]
	void attemptLogin();

	[DispId(10031)]
	string accountType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10031)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10032)]
	object OnViewChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10032)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10033)]
	void changeView([In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationID, [In][MarshalAs(UnmanagedType.BStr)] string bstrFilter, [In][MarshalAs(UnmanagedType.BStr)] string bstrViewParams);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10034)]
	void changeViewOnlineList([In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationID, [In][MarshalAs(UnmanagedType.BStr)] string bstrParams, [In][MarshalAs(UnmanagedType.BStr)] string bstrFriendlyName, [In][MarshalAs(UnmanagedType.BStr)] string bstrListType, [In][MarshalAs(UnmanagedType.BStr)] string bstrViewMode);

	[DispId(10035)]
	string libraryLocationType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10035)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10036)]
	string libraryLocationID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10036)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10037)]
	string selectedItemType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10037)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10038)]
	string selectedItemID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10038)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10039)]
	string filter
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10039)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10040)]
	string task
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10040)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10041)]
	string viewParameters
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10041)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10042)]
	void cancelNavigate();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10043)]
	void showPopup([In] int lPopupIndex, [In][MarshalAs(UnmanagedType.BStr)] string bstrParameters);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10044)]
	void addToBasket([In][MarshalAs(UnmanagedType.BStr)] string bstrViewType, [In][MarshalAs(UnmanagedType.BStr)] string bstrViewIDs);

	[DispId(10045)]
	string basketTitle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10045)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10046)]
	void play([In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLibraryLocationIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10047)]
	void download([In][MarshalAs(UnmanagedType.BStr)] string bstrViewType, [In][MarshalAs(UnmanagedType.BStr)] string bstrViewIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10048)]
	void buy([In][MarshalAs(UnmanagedType.BStr)] string bstrViewType, [In][MarshalAs(UnmanagedType.BStr)] string bstrViewIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10049)]
	void saveCurrentViewToLibrary([In][MarshalAs(UnmanagedType.BStr)] string bstrFriendlyListType, [In] bool fDynamic);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10050)]
	void authenticate([In] int lAuthenticationIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10051)]
	void sendMessage([In][MarshalAs(UnmanagedType.BStr)] string bstrMsg, [In][MarshalAs(UnmanagedType.BStr)] string bstrParam);

	[DispId(10052)]
	object OnSendMessageComplete
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10052)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(10053)]
	bool ignoreIEHistory
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10053)]
		[param: In]
		set;
	}

	[DispId(10054)]
	bool pluginRunning
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10054)]
		get;
	}

	[DispId(10055)]
	bool templateBeingDisplayedInLocalLibrary
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10055)]
		get;
	}

	[DispId(10056)]
	object OnChangeViewError
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10056)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(10057)]
	object OnChangeViewOnlineListError
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10057)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}
}
