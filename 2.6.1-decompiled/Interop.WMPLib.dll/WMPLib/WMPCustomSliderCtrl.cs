using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPCustomSliderCtrlClass))]
[Guid("95F45AA2-ED0A-11D2-BA67-0000F80855E6")]
public interface WMPCustomSliderCtrl : IWMPCustomSlider, IWMPCustomSliderCtrlEvents_Event
{
}
