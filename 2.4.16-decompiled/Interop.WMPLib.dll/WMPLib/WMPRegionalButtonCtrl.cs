using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("58D507B1-2354-11D3-BD41-00C04F6EA5AE")]
[CoClass(typeof(WMPRegionalButtonCtrlClass))]
public interface WMPRegionalButtonCtrl : IWMPRegionalButtonCtrl
{
}
