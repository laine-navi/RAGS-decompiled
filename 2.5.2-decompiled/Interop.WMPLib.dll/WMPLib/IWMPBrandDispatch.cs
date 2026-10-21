using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("98BB02D4-ED74-43CC-AD6A-45888F2E0DCC")]
[TypeLibType(4160)]
public interface IWMPBrandDispatch
{
	[DispId(3040)]
	string fullServiceName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3040)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3000)]
	string friendlyName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3000)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3001)]
	string guideButtonText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3001)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3002)]
	string guideButtonTip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3002)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3003)]
	string guideMenuText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3003)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3004)]
	string guideAccText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3004)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3005)]
	string task1ButtonText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3005)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3006)]
	string task1ButtonTip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3006)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3007)]
	string task1MenuText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3007)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3008)]
	string task1AccText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3008)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3017)]
	string guideUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3017)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3018)]
	string task1Url
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3018)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3021)]
	string imageLargeUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3021)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3022)]
	string imageSmallUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3022)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3023)]
	string imageMenuUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3023)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3024)]
	string infoCenterUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3024)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3025)]
	string albumInfoUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3025)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3026)]
	string buyCDUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3026)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3027)]
	string htmlViewUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3027)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3028)]
	string navigateUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3028)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3029)]
	string cookieUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3029)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3030)]
	string downloadStatusUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3030)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3031)]
	string colorPlayer
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3031)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3032)]
	string colorPlayerText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3032)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3035)]
	int navigateDispid
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3035)]
		get;
	}

	[DispId(3036)]
	string navigateParams
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3036)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3037)]
	string navigatePane
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3037)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3038)]
	string selectedPane
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3038)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3038)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3041)]
	void setNavigateProps([In][MarshalAs(UnmanagedType.BStr)] string bstrPane, [In] int lDispid, [In][MarshalAs(UnmanagedType.BStr)] string bstrParams);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3042)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getMediaParams([In][MarshalAs(UnmanagedType.IUnknown)] object pObject, [In][MarshalAs(UnmanagedType.BStr)] string bstrURL);

	[DispId(3039)]
	int selectedTask
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3039)]
		[param: In]
		set;
	}

	[DispId(3043)]
	bool contentPartnerSelected
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3043)]
		get;
	}
}
