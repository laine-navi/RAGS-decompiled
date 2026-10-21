using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("10A13217-23A7-439B-B1C0-D847C79B7774")]
public interface IWMPPlaylistCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(552)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist newPlaylist([In][MarshalAs(UnmanagedType.BStr)] string bstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(553)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylistArray getAll();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(554)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylistArray getByName([In][MarshalAs(UnmanagedType.BStr)] string bstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(556)]
	void remove([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(560)]
	void setDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pItem, [In] bool varfIsDeleted);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(561)]
	bool isDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(562)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist importPlaylist([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pItem);
}
