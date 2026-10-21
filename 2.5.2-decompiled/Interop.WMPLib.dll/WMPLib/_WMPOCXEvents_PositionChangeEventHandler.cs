using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_PositionChangeEventHandler([In] double oldPosition, [In] double newPosition);
