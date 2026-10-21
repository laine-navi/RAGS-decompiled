using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class IWMPCustomSliderCtrlEvents_EventProvider : IWMPCustomSliderCtrlEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			164, 90, 244, 149, 10, 237, 210, 17, 186, 103,
			0, 0, 248, 8, 85, 230
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_ondragbegin(IWMPCustomSliderCtrlEvents_ondragbeginEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = new IWMPCustomSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPCustomSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPCustomSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ondragbegin(IWMPCustomSliderCtrlEvents_ondragbeginEventHandler P_0)
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
				IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = (IWMPCustomSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate != null && ((iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public void add_ondragend(IWMPCustomSliderCtrlEvents_ondragendEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = new IWMPCustomSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPCustomSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragendDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPCustomSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ondragend(IWMPCustomSliderCtrlEvents_ondragendEventHandler P_0)
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
				IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = (IWMPCustomSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragendDelegate != null && ((iWMPCustomSliderCtrlEvents_SinkHelper.m_ondragendDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public void add_onpositionchange(IWMPCustomSliderCtrlEvents_onpositionchangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = new IWMPCustomSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPCustomSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPCustomSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPCustomSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onpositionchange(IWMPCustomSliderCtrlEvents_onpositionchangeEventHandler P_0)
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
				IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = (IWMPCustomSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPCustomSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate != null && ((iWMPCustomSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public IWMPCustomSliderCtrlEvents_EventProvider(object P_0)
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
					IWMPCustomSliderCtrlEvents_SinkHelper iWMPCustomSliderCtrlEvents_SinkHelper = (IWMPCustomSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(iWMPCustomSliderCtrlEvents_SinkHelper.m_dwCookie);
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
