using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("58D507B2-2354-11D3-BD41-00C04F6EA5AE")]
[CoClass(typeof(WMPRegionalButtonClass))]
public interface WMPRegionalButton : IWMPRegionalButton, IWMPRegionalButtonEvents_Event
{
}
