using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPVideoCtrlClass))]
[Guid("61CECF10-FC3A-11D2-A1CD-005004602752")]
public interface WMPVideoCtrl : IWMPVideoCtrl, IWMPVideoCtrlEvents_Event
{
}
