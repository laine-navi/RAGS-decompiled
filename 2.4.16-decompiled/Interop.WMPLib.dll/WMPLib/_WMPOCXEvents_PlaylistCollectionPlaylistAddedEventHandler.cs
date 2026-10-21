using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_PlaylistCollectionPlaylistAddedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName);
