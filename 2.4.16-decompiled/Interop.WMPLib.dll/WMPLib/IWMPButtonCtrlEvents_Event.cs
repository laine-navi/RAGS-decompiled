using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(16)]
[ComEventInterface(typeof(IWMPButtonCtrlEvents_0000), typeof(IWMPButtonCtrlEvents_EventProvider_0000))]
[ComVisible(false)]
public interface IWMPButtonCtrlEvents_Event
{
	event IWMPButtonCtrlEvents_onclickEventHandler onclick;
}
