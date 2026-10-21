using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("F2BF2C8F-405F-11D3-BB39-00A0C93CA73A")]
[CoClass(typeof(WMPSliderCtrlClass))]
public interface WMPSliderCtrl : IWMPSliderCtrl, IWMPSliderCtrlEvents_Event
{
}
