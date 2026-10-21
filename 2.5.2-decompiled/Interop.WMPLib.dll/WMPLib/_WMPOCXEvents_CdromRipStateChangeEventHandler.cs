using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CdromRipStateChangeEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromRip pCdromRip, [In] WMPRipState wmprs);
