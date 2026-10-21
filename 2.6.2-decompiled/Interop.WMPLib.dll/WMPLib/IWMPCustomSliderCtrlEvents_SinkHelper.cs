using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class IWMPCustomSliderCtrlEvents_SinkHelper : IWMPCustomSliderCtrlEvents
{
	public IWMPCustomSliderCtrlEvents_ondragbeginEventHandler m_ondragbeginDelegate;

	public IWMPCustomSliderCtrlEvents_ondragendEventHandler m_ondragendDelegate;

	public IWMPCustomSliderCtrlEvents_onpositionchangeEventHandler m_onpositionchangeDelegate;

	public int m_dwCookie;

	public void ondragbegin()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ondragbeginDelegate != null)
		{
			m_ondragbeginDelegate();
		}
	}

	public void ondragend()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ondragendDelegate != null)
		{
			m_ondragendDelegate();
		}
	}

	public void onpositionchange()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onpositionchangeDelegate != null)
		{
			m_onpositionchangeDelegate();
		}
	}

	internal IWMPCustomSliderCtrlEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_ondragbeginDelegate = null;
		m_ondragendDelegate = null;
		m_onpositionchangeDelegate = null;
	}
}
