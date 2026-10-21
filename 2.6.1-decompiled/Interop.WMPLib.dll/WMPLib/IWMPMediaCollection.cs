using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("8363BC22-B4B4-4B19-989D-1CD765749DD1")]
public interface IWMPMediaCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(452)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPMedia add([In][MarshalAs(UnmanagedType.BStr)] string bstrURL);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(453)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getAll();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(454)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByName([In][MarshalAs(UnmanagedType.BStr)] string bstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(455)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByGenre([In][MarshalAs(UnmanagedType.BStr)] string bstrGenre);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(456)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByAuthor([In][MarshalAs(UnmanagedType.BStr)] string bstrAuthor);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(457)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByAlbum([In][MarshalAs(UnmanagedType.BStr)] string bstrAlbum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(458)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByAttribute([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(459)]
	void remove([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem, [In] bool varfDeleteFile);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(461)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPStringCollection getAttributeStringCollection([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrMediaType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(470)]
	int getMediaAtom([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(471)]
	void setDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem, [In] bool varfIsDeleted);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(472)]
	bool isDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem);
}
