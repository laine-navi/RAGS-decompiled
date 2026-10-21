using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("95F45AA2-ED0A-11D2-BA67-0000F80855E6")]
[CoClass(typeof(WMPCustomSliderCtrlClass))]
public interface WMPCustomSliderCtrl : IWMPCustomSlider, IWMPCustomSliderCtrlEvents_Event
{
}
