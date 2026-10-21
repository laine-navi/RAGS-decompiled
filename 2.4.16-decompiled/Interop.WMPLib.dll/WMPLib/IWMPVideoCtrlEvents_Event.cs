using System.Runtime.InteropServices;

namespace WMPLib;

[ComVisible(false)]
[ComEventInterface(typeof(IWMPVideoCtrlEvents_0000), typeof(IWMPVideoCtrlEvents_EventProvider_0000))]
[TypeLibType(16)]
public interface IWMPVideoCtrlEvents_Event
{
	event IWMPVideoCtrlEvents_onvideostartEventHandler onvideostart;

	event IWMPVideoCtrlEvents_onvideoendEventHandler onvideoend;
}
