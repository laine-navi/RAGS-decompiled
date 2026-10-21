using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_CdromMediaChangeEventHandler([In] int CdromNum);
