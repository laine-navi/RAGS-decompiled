using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("2E922378-EE70-4CEB-BBAB-CE7CE4A04816")]
[TypeLibType(4160)]
public interface IWMPSubscriptionServiceExternal : IWMPSubscriptionServiceLimited
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
	IWMPDownloadManager DownloadManager
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
