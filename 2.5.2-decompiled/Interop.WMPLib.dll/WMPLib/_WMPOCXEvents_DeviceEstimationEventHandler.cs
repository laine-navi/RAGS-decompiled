using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_DeviceEstimationEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In][MarshalAs(UnmanagedType.Error)] int hrResult, [In] long qwEstimatedUsedSpace, [In] long qwEstimatedSpace);
