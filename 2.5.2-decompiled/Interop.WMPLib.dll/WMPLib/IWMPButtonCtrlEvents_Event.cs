using System.Runtime.InteropServices;

namespace WMPLib;

[ComEventInterface(typeof(IWMPButtonCtrlEvents_0000), typeof(IWMPButtonCtrlEvents_EventProvider_0000))]
[ComVisible(false)]
[TypeLibType(16)]
public interface IWMPButtonCtrlEvents_Event
{
	event IWMPButtonCtrlEvents_onclickEventHandler onclick;
}
