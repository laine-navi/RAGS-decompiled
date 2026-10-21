using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("2BD3716F-A914-49FB-8655-996D5F495498")]
[CoClass(typeof(WMPEqualizerSettingsCtrlClass))]
public interface WMPEqualizerSettingsCtrl : IWMPEqualizerSettingsCtrl
{
}
