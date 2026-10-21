using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_WarningEventHandler([In] int WarningType, [In] int Param, [In][MarshalAs(UnmanagedType.BStr)] string Description);
