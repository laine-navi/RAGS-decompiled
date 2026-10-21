using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_MouseDownEventHandler([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);
