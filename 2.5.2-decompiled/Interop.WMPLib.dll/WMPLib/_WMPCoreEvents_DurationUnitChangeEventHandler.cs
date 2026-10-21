using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void _WMPCoreEvents_DurationUnitChangeEventHandler([In] int NewDurationUnit);
