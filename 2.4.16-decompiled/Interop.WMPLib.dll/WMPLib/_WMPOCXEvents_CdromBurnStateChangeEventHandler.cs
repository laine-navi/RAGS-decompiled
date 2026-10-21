using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CdromBurnStateChangeEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In] WMPBurnState wmpbs);
