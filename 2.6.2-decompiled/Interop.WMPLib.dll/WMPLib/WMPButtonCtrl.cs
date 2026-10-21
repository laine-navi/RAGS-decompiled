using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("87291B50-0C8E-11D3-BB2A-00A0C93CA73A")]
[CoClass(typeof(WMPButtonCtrlClass))]
public interface WMPButtonCtrl : IWMPButtonCtrl, IWMPButtonCtrlEvents_Event
{
}
