using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CdromBurnMediaErrorEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);
