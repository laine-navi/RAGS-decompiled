using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPCoreEvents_MediaCollectionAttributeStringChangedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrOldAttribVal, [In][MarshalAs(UnmanagedType.BStr)] string bstrNewAttribVal);
