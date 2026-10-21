using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class IWMPButtonCtrlEvents_SinkHelper : IWMPButtonCtrlEvents
{
	public IWMPButtonCtrlEvents_onclickEventHandler m_onclickDelegate;

	public int m_dwCookie;

	public void onclick()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_onclickDelegate != null)
		{
			m_onclickDelegate();
		}
	}

	internal IWMPButtonCtrlEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_onclickDelegate = null;
	}
}
