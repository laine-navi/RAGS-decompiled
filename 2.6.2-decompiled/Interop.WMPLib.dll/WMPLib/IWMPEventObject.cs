using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("5AF0BEC1-46AA-11D3-BD45-00C04F6EA5AE")]
public interface IWMPEventObject
{
	[DispId(2200)]
	object srcElement
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2200)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(2201)]
	bool altKey
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2201)]
		get;
	}

	[DispId(2202)]
	bool ctrlKey
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2202)]
		get;
	}

	[DispId(2203)]
	bool shiftKey
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2203)]
		get;
	}

	[DispId(2204)]
	object fromElement
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2204)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(2205)]
	object toElement
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2205)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(2206)]
	int keyCode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2206)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2206)]
		[param: In]
		set;
	}

	[DispId(2207)]
	int button
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2207)]
		get;
	}

	[DispId(2208)]
	int x
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2208)]
		get;
	}

	[DispId(2209)]
	int y
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2209)]
		get;
	}

	[DispId(2210)]
	int clientX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2210)]
		get;
	}

	[DispId(2211)]
	int clientY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2211)]
		get;
	}

	[DispId(2212)]
	int offsetX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2212)]
		get;
	}

	[DispId(2213)]
	int offsetY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2213)]
		get;
	}

	[DispId(2214)]
	int screenX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2214)]
		get;
	}

	[DispId(2215)]
	int screenY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2215)]
		get;
	}

	[DispId(2216)]
	int screenWidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2216)]
		get;
	}

	[DispId(2217)]
	int screenHeight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2217)]
		get;
	}

	[DispId(2218)]
	bool penOrTouch
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2218)]
		get;
	}
}
