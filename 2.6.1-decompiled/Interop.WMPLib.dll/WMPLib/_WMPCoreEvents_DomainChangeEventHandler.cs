using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_DomainChangeEventHandler([In][MarshalAs(UnmanagedType.BStr)] string strDomain);
