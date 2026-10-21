using System.Runtime.InteropServices;

namespace WMPLib;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class IWMPSliderCtrlEvents_SinkHelper : IWMPSliderCtrlEvents
{
	public IWMPSliderCtrlEvents_ondragbeginEventHandler m_ondragbeginDelegate;

	public IWMPSliderCtrlEvents_ondragendEventHandler m_ondragendDelegate;

	public IWMPSliderCtrlEvents_onpositionchangeEventHandler m_onpositionchangeDelegate;

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

	internal IWMPSliderCtrlEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_ondragbeginDelegate = null;
		m_ondragendDelegate = null;
		m_onpositionchangeDelegate = null;
	}
}
