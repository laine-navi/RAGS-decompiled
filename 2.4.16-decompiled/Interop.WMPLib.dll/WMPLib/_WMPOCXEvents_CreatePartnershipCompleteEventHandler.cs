using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CreatePartnershipCompleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In][MarshalAs(UnmanagedType.Error)] int hrResult);
