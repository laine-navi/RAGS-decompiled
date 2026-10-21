using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("3614C646-3B3B-4DE7-A81E-930E3F2127B3")]
public interface IWMPErrorItem
{
	[DispId(901)]
	int errorCode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(901)]
		get;
	}

	[DispId(902)]
	string errorDescription
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(902)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(903)]
	object errorContext
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(903)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
	}

	[DispId(904)]
	int remedy
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(904)]
		get;
	}

	[DispId(905)]
	string customUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(905)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}
}
