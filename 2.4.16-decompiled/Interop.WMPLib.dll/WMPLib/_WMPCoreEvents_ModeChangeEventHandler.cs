using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_ModeChangeEventHandler([In][MarshalAs(UnmanagedType.BStr)] string ModeName, [In] bool NewValue);
