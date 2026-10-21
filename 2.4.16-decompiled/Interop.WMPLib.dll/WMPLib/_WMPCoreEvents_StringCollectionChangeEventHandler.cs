using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_StringCollectionChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pdispStringCollection, [In] WMPStringCollectionChangeEventType change, [In] int lCollectionIndex);
