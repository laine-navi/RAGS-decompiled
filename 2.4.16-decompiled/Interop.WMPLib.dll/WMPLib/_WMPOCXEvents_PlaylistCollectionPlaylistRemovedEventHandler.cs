using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_PlaylistCollectionPlaylistRemovedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName);
