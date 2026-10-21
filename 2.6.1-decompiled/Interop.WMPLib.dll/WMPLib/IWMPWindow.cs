using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("43D5AE92-4332-477C-8883-E0B3B063C5D2")]
[TypeLibType(4160)]
public interface IWMPWindow
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3300)]
	void setWindowPos([In] int x, [In] int y, [In] int height, [In] int width);

	[DispId(3301)]
	int frameRate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3301)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3301)]
		[param: In]
		set;
	}

	[DispId(3302)]
	int mouseX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3302)]
		get;
	}

	[DispId(3303)]
	int mouseY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3303)]
		get;
	}

	[DispId(3304)]
	object onsizing
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3304)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3305)]
	void openViewAlwaysOnTop([MarshalAs(UnmanagedType.BStr)] string bstrViewID);
}
