using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(256)]
[InterfaceType(1)]
[Guid("DD578A4E-79B1-426C-BF8F-3ADD9072500B")]
public interface IWMPLibrary2 : IWMPLibrary
{
	[DispId(1610678272)]
	new string name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1610678273)]
	new WMPLibraryType type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[DispId(1610678274)]
	new IWMPMediaCollection mediaCollection
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new bool isIdentical([In][MarshalAs(UnmanagedType.Interface)] IWMPLibrary pIWMPLibrary);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);
}
