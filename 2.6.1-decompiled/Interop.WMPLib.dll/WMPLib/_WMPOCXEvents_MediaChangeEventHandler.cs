using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_MediaChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object Item);
