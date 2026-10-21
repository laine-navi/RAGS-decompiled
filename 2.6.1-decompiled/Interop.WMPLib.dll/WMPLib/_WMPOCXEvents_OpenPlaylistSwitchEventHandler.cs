using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_OpenPlaylistSwitchEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pItem);
