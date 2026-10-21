using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName, [In] bool varfIsDeleted);
