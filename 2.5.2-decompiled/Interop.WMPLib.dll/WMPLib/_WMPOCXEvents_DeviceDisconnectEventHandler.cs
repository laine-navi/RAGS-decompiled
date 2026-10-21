using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_DeviceDisconnectEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice);
