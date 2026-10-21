using System.Runtime.InteropServices;

namespace WMPLib;

[ComEventInterface(typeof(IWMPRegionalButtonEvents_0000), typeof(IWMPRegionalButtonEvents_EventProvider_0000))]
[TypeLibType(16)]
[ComVisible(false)]
public interface IWMPRegionalButtonEvents_Event
{
	event IWMPRegionalButtonEvents_onblurEventHandler onblur;

	event IWMPRegionalButtonEvents_onfocusEventHandler onfocus;

	event IWMPRegionalButtonEvents_onclickEventHandler onclick;

	event IWMPRegionalButtonEvents_ondblclickEventHandler ondblclick;

	event IWMPRegionalButtonEvents_onmousedownEventHandler onmousedown;

	event IWMPRegionalButtonEvents_onmouseupEventHandler onmouseup;

	event IWMPRegionalButtonEvents_onmousemoveEventHandler onmousemove;

	event IWMPRegionalButtonEvents_onmouseoverEventHandler onmouseover;

	event IWMPRegionalButtonEvents_onmouseoutEventHandler onmouseout;

	event IWMPRegionalButtonEvents_onkeypressEventHandler onkeypress;

	event IWMPRegionalButtonEvents_onkeydownEventHandler onkeydown;

	event IWMPRegionalButtonEvents_onkeyupEventHandler onkeyup;
}
