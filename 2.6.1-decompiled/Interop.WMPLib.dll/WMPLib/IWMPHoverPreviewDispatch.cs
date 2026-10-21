using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("946B023E-044C-4473-8018-74954F09DC7E")]
public interface IWMPHoverPreviewDispatch
{
	[DispId(3150)]
	string title
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3150)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3151)]
	string album
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3151)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3153)]
	string URL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3153)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3152)]
	object image
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3152)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(3155)]
	bool autoClick
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3155)]
		[param: In]
		set;
	}

	[DispId(3154)]
	bool previewClick
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3154)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3156)]
	void dismiss();
}
