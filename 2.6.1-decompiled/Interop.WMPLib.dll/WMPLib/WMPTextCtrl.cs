using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("237DAC8E-0E32-11D3-A2E2-00C04F79F88E")]
[CoClass(typeof(WMPTextCtrlClass))]
public interface WMPTextCtrl : IWMPTextCtrl
{
}
