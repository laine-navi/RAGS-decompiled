using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPRegionalButtonCtrlClass))]
[Guid("58D507B1-2354-11D3-BD41-00C04F6EA5AE")]
public interface WMPRegionalButtonCtrl : IWMPRegionalButtonCtrl
{
}
