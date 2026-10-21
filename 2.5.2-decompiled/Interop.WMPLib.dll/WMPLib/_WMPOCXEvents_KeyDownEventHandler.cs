using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_KeyDownEventHandler([In] short nKeyCode, [In] short nShiftState);
