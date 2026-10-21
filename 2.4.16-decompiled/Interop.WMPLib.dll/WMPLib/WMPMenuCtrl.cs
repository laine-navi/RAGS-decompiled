using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPMenuCtrlClass))]
[Guid("158A7ADC-33DA-4039-A553-BDDBBE389F5C")]
public interface WMPMenuCtrl : IWMPMenuCtrl
{
}
