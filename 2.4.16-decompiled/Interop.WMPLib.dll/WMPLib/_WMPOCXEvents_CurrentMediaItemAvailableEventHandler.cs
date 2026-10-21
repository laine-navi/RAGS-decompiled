using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_CurrentMediaItemAvailableEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);
