using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("8BA957F5-FD8C-4791-B82D-F840401EE474")]
public interface IWMPMediaCollection2 : IWMPMediaCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(452)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPMedia add([In][MarshalAs(UnmanagedType.BStr)] string bstrURL);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(453)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getAll();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(454)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getByName([In][MarshalAs(UnmanagedType.BStr)] string bstrName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(455)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getByGenre([In][MarshalAs(UnmanagedType.BStr)] string bstrGenre);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(456)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getByAuthor([In][MarshalAs(UnmanagedType.BStr)] string bstrAuthor);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(457)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getByAlbum([In][MarshalAs(UnmanagedType.BStr)] string bstrAlbum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(458)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPPlaylist getByAttribute([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(459)]
	new void remove([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem, [In] bool varfDeleteFile);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(461)]
	[return: MarshalAs(UnmanagedType.Interface)]
	new IWMPStringCollection getAttributeStringCollection([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrMediaType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(470)]
	new int getMediaAtom([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(471)]
	new void setDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem, [In] bool varfIsDeleted);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(472)]
	new bool isDeleted([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1401)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPQuery createQuery();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1402)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getPlaylistByQuery([In][MarshalAs(UnmanagedType.Interface)] IWMPQuery pQuery, [In][MarshalAs(UnmanagedType.BStr)] string bstrMediaType, [In][MarshalAs(UnmanagedType.BStr)] string bstrSortAttribute, [In] bool fSortAscending);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1403)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPStringCollection getStringCollectionByQuery([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.Interface)] IWMPQuery pQuery, [In][MarshalAs(UnmanagedType.BStr)] string bstrMediaType, [In][MarshalAs(UnmanagedType.BStr)] string bstrSortAttribute, [In] bool fSortAscending);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1404)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist getByAttributeAndMediaType([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrValue, [In][MarshalAs(UnmanagedType.BStr)] string bstrMediaType);
}
