using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_CdromBurnStateChangeEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In] WMPBurnState wmpbs);
