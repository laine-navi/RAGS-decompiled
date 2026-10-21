using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("F75CCEC0-C67C-475C-931E-8719870BEE7D")]
[TypeLibType(4160)]
public interface IWMPErrorItem2 : IWMPErrorItem
{
	[DispId(901)]
	new int errorCode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(901)]
		get;
	}

	[DispId(902)]
	new string errorDescription
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(902)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(903)]
	new object errorContext
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(903)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
	}

	[DispId(904)]
	new int remedy
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(904)]
		get;
	}

	[DispId(905)]
	new string customUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(905)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(906)]
	int condition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(906)]
		get;
	}
}
