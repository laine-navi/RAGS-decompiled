using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPRegionalButtonClass))]
[Guid("58D507B2-2354-11D3-BD41-00C04F6EA5AE")]
public interface WMPRegionalButton : IWMPRegionalButton, IWMPRegionalButtonEvents_Event
{
}
