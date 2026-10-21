using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_DeviceStatusChangeEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In] WMPDeviceStatus NewStatus);
