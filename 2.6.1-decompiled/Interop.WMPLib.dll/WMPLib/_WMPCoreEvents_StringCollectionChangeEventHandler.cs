using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_StringCollectionChangeEventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object pdispStringCollection, [In] WMPStringCollectionChangeEventType change, [In] int lCollectionIndex);
