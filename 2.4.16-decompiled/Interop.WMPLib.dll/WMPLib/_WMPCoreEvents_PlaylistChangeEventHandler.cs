using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_PlaylistChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object Playlist, [In] WMPPlaylistChangeEventType change);
