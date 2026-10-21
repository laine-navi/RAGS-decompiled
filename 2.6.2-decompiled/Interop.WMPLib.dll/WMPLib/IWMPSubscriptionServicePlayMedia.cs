using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("5F0248C1-62B3-42D7-B927-029119E6AD14")]
public interface IWMPSubscriptionServicePlayMedia : IWMPSubscriptionServiceLimited
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

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10004)]
	void playMedia([In][MarshalAs(UnmanagedType.BStr)] string bstrURL);
}
