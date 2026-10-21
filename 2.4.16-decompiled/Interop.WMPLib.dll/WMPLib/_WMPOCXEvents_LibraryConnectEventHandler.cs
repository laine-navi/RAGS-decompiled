using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_LibraryConnectEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPLibrary pLibrary);
