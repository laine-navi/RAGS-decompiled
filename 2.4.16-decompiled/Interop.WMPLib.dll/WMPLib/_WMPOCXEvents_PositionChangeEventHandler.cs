using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_PositionChangeEventHandler([In] double oldPosition, [In] double newPosition);
