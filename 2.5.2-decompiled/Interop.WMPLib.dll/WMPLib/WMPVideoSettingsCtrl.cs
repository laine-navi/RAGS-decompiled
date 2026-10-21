using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPVideoSettingsCtrlClass))]
[Guid("07EC23DA-EF73-4BDE-A40F-F269E0B7AFD6")]
public interface WMPVideoSettingsCtrl : IWMPVideoSettingsCtrl
{
}
