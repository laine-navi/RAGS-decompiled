using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void _WMPOCXEvents_FolderScanStateChangeEventHandler([In] WMPFolderScanState wmpfss);
