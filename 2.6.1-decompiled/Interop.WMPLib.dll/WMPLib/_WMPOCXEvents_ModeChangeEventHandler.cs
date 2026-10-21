using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_ModeChangeEventHandler([In][MarshalAs(UnmanagedType.BStr)] string ModeName, [In] bool NewValue);
