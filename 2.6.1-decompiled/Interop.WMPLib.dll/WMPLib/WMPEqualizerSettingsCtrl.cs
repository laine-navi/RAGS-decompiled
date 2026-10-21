using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPEqualizerSettingsCtrlClass))]
[Guid("2BD3716F-A914-49FB-8655-996D5F495498")]
public interface WMPEqualizerSettingsCtrl : IWMPEqualizerSettingsCtrl
{
}
