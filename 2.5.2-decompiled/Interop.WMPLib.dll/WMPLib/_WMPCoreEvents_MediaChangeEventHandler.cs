using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_MediaChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object Item);
