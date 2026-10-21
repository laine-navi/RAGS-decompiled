using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CdromRipMediaErrorEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromRip pCdromRip, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);
