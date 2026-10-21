using System.Runtime.InteropServices;

namespace WMPLib;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class IWMPVideoCtrlEvents_SinkHelper : IWMPVideoCtrlEvents
{
	public IWMPVideoCtrlEvents_onvideostartEventHandler m_onvideostartDelegate;

	public IWMPVideoCtrlEvents_onvideoendEventHandler m_onvideoendDelegate;

	public int m_dwCookie;

	public void onvideostart()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onvideostartDelegate != null)
		{
			m_onvideostartDelegate();
		}
	}

	public void onvideoend()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onvideoendDelegate != null)
		{
			m_onvideoendDelegate();
		}
	}

	internal IWMPVideoCtrlEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_onvideostartDelegate = null;
		m_onvideoendDelegate = null;
	}
}
