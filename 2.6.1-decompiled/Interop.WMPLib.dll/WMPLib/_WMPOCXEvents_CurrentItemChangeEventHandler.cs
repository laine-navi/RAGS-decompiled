using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CurrentItemChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pdispMedia);
