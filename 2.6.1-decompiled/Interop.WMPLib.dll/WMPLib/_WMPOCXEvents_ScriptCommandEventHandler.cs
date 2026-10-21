using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_ScriptCommandEventHandler([In][MarshalAs(UnmanagedType.BStr)] string scType, [In][MarshalAs(UnmanagedType.BStr)] string Param);
