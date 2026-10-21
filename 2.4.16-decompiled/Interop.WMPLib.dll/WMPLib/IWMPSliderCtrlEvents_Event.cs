using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[ComEventInterface(typeof(IWMPSliderCtrlEvents_0000), typeof(IWMPSliderCtrlEvents_EventProvider_0000))]
[TypeLibType(16)]
public interface IWMPSliderCtrlEvents_Event
{
	event IWMPSliderCtrlEvents_ondragbeginEventHandler ondragbegin;

	event IWMPSliderCtrlEvents_ondragendEventHandler ondragend;

	event IWMPSliderCtrlEvents_onpositionchangeEventHandler onpositionchange;
}
