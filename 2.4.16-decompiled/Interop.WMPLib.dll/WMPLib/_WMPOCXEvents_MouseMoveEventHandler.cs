using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_MouseMoveEventHandler([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);
