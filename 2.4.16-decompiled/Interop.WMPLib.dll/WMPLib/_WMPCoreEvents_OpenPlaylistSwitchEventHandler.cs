using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_OpenPlaylistSwitchEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pItem);
