using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class IWMPButtonCtrlEvents_EventProvider : IWMPButtonCtrlEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			247, 255, 23, 187, 146, 22, 85, 69, 145, 138,
			106, 247, 191, 172, 237, 210
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_onclick(IWMPButtonCtrlEvents_onclickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPButtonCtrlEvents_SinkHelper iWMPButtonCtrlEvents_SinkHelper = new IWMPButtonCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPButtonCtrlEvents_SinkHelper, out pdwCookie);
			iWMPButtonCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPButtonCtrlEvents_SinkHelper.m_onclickDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPButtonCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onclick(IWMPButtonCtrlEvents_onclickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				IWMPButtonCtrlEvents_SinkHelper iWMPButtonCtrlEvents_SinkHelper = (IWMPButtonCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPButtonCtrlEvents_SinkHelper.m_onclickDelegate != null && ((iWMPButtonCtrlEvents_SinkHelper.m_onclickDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPButtonCtrlEvents_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public IWMPButtonCtrlEvents_EventProvider(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_ConnectionPointContainer = (IConnectionPointContainer)P_0;
	}

	public void Finalize()
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 < count)
			{
				do
				{
					IWMPButtonCtrlEvents_SinkHelper iWMPButtonCtrlEvents_SinkHelper = (IWMPButtonCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(iWMPButtonCtrlEvents_SinkHelper.m_dwCookie);
					num++;
				}
				while (num < count);
			}
			Marshal.ReleaseComObject(m_ConnectionPoint);
		}
		catch (Exception)
		{
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void Dispose()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		Finalize();
		GC.SuppressFinalize(this);
	}
}
