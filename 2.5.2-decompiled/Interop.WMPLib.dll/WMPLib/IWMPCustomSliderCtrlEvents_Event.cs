using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[TypeLibType(16)]
[ComEventInterface(typeof(IWMPCustomSliderCtrlEvents_0000), typeof(IWMPCustomSliderCtrlEvents_EventProvider_0000))]
public interface IWMPCustomSliderCtrlEvents_Event
{
	event IWMPCustomSliderCtrlEvents_ondragbeginEventHandler ondragbegin;

	event IWMPCustomSliderCtrlEvents_ondragendEventHandler ondragend;

	event IWMPCustomSliderCtrlEvents_onpositionchangeEventHandler onpositionchange;
}
