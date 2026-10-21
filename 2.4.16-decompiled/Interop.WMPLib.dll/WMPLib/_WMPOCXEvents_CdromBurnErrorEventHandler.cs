using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_CdromBurnErrorEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In][MarshalAs(UnmanagedType.Error)] int hrError);
