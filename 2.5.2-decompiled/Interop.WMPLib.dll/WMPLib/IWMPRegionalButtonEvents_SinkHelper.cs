using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class IWMPRegionalButtonEvents_SinkHelper : IWMPRegionalButtonEvents
{
	public IWMPRegionalButtonEvents_onblurEventHandler m_onblurDelegate;

	public IWMPRegionalButtonEvents_onfocusEventHandler m_onfocusDelegate;

	public IWMPRegionalButtonEvents_onclickEventHandler m_onclickDelegate;

	public IWMPRegionalButtonEvents_ondblclickEventHandler m_ondblclickDelegate;

	public IWMPRegionalButtonEvents_onmousedownEventHandler m_onmousedownDelegate;

	public IWMPRegionalButtonEvents_onmouseupEventHandler m_onmouseupDelegate;

	public IWMPRegionalButtonEvents_onmousemoveEventHandler m_onmousemoveDelegate;

	public IWMPRegionalButtonEvents_onmouseoverEventHandler m_onmouseoverDelegate;

	public IWMPRegionalButtonEvents_onmouseoutEventHandler m_onmouseoutDelegate;

	public IWMPRegionalButtonEvents_onkeypressEventHandler m_onkeypressDelegate;

	public IWMPRegionalButtonEvents_onkeydownEventHandler m_onkeydownDelegate;

	public IWMPRegionalButtonEvents_onkeyupEventHandler m_onkeyupDelegate;

	public int m_dwCookie;

	public void onblur()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onblurDelegate != null)
		{
			m_onblurDelegate();
		}
	}

	public void onfocus()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onfocusDelegate != null)
		{
			m_onfocusDelegate();
		}
	}

	public void onclick()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onclickDelegate != null)
		{
			m_onclickDelegate();
		}
	}

	public void ondblclick()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ondblclickDelegate != null)
		{
			m_ondblclickDelegate();
		}
	}

	public void onmousedown()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onmousedownDelegate != null)
		{
			m_onmousedownDelegate();
		}
	}

	public void onmouseup()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onmouseupDelegate != null)
		{
			m_onmouseupDelegate();
		}
	}

	public void onmousemove()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onmousemoveDelegate != null)
		{
			m_onmousemoveDelegate();
		}
	}

	public void onmouseover()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onmouseoverDelegate != null)
		{
			m_onmouseoverDelegate();
		}
	}

	public void onmouseout()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onmouseoutDelegate != null)
		{
			m_onmouseoutDelegate();
		}
	}

	public void onkeypress()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onkeypressDelegate != null)
		{
			m_onkeypressDelegate();
		}
	}

	public void onkeydown()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onkeydownDelegate != null)
		{
			m_onkeydownDelegate();
		}
	}

	public void onkeyup()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onkeyupDelegate != null)
		{
			m_onkeyupDelegate();
		}
	}

	internal IWMPRegionalButtonEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_onblurDelegate = null;
		m_onfocusDelegate = null;
		m_onclickDelegate = null;
		m_ondblclickDelegate = null;
		m_onmousedownDelegate = null;
		m_onmouseupDelegate = null;
		m_onmousemoveDelegate = null;
		m_onmouseoverDelegate = null;
		m_onmouseoutDelegate = null;
		m_onkeypressDelegate = null;
		m_onkeydownDelegate = null;
		m_onkeyupDelegate = null;
	}
}
