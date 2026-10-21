using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_MediaErrorEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pMediaObject);
