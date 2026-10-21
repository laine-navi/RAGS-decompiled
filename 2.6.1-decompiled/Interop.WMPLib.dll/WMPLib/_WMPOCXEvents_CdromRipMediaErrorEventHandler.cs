using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_CdromRipMediaErrorEventHandler([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromRip pCdromRip, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);
