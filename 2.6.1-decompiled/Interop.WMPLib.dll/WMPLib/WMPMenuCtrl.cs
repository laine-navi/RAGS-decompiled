using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("158A7ADC-33DA-4039-A553-BDDBBE389F5C")]
[CoClass(typeof(WMPMenuCtrlClass))]
public interface WMPMenuCtrl : IWMPMenuCtrl
{
}
