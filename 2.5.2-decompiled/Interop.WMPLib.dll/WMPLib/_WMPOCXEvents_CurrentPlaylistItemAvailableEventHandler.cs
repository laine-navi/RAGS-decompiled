using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_CurrentPlaylistItemAvailableEventHandler([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);
