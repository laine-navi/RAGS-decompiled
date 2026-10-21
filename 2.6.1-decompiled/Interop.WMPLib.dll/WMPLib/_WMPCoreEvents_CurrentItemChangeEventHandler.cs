using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_CurrentItemChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pdispMedia);
