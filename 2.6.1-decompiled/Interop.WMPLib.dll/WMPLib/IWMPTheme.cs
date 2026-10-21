using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("6FCAE13D-E492-4584-9C21-D2C052A2A33A")]
public interface IWMPTheme
{
	[DispId(2500)]
	string title
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2500)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2501)]
	float version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2501)]
		get;
	}

	[DispId(2502)]
	string authorVersion
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2502)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2503)]
	string author
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2503)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2504)]
	string copyright
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2504)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2505)]
	string currentViewID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2505)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2505)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2506)]
	void showErrorDialog();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2507)]
	void logString([In][MarshalAs(UnmanagedType.BStr)] string stringVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2508)]
	void openView([In][MarshalAs(UnmanagedType.BStr)] string viewID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2515)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object openViewRelative([In][MarshalAs(UnmanagedType.BStr)] string viewID, [In] int x, [In] int y);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2509)]
	void closeView([In][MarshalAs(UnmanagedType.BStr)] string viewID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2510)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string openDialog([In][MarshalAs(UnmanagedType.BStr)] string dialogType, [In][MarshalAs(UnmanagedType.BStr)] string parameters);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2511)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string loadString([In][MarshalAs(UnmanagedType.BStr)] string bstrString);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2512)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string loadPreference([In][MarshalAs(UnmanagedType.BStr)] string bstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2513)]
	void savePreference([In][MarshalAs(UnmanagedType.BStr)] string bstrName, [In][MarshalAs(UnmanagedType.BStr)] string bstrValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2514)]
	void playSound([MarshalAs(UnmanagedType.BStr)] string bstrFilename);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2516)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object openViewRelativeInternal([In][MarshalAs(UnmanagedType.BStr)] string viewID, [In] int nIndex, [In] int x, [In] int y, [In] int nWidth, [In] int nHeight, [In][MarshalAs(UnmanagedType.BStr)] string bstrHorizontalAlignment, [In][MarshalAs(UnmanagedType.BStr)] string bstrVerticalAlignment);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2518)]
	void setViewPosition([In][MarshalAs(UnmanagedType.BStr)] string viewID, [In] int nIndex, [In] int x, [In] int y, [In] int nWidth, [In] int nHeight, [In][MarshalAs(UnmanagedType.BStr)] string bstrHorizontalAlignment, [In][MarshalAs(UnmanagedType.BStr)] string bstrVerticalAlignment);
}
