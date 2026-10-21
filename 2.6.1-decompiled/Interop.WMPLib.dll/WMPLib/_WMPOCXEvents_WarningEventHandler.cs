using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_WarningEventHandler([In] int WarningType, [In] int Param, [In][MarshalAs(UnmanagedType.BStr)] string Description);
