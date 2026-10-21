using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPSliderCtrlClass))]
[Guid("F2BF2C8F-405F-11D3-BB39-00A0C93CA73A")]
public interface WMPSliderCtrl : IWMPSliderCtrl, IWMPSliderCtrlEvents_Event
{
}
