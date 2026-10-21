using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPOCXEvents_MediaCollectionAttributeStringChangedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrOldAttribVal, [In][MarshalAs(UnmanagedType.BStr)] string bstrNewAttribVal);
