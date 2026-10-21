using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_MediaCollectionAttributeStringAddedEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrAttribVal);
