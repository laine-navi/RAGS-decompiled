using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class IWMPSliderCtrlEvents_EventProvider : IWMPSliderCtrlEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			210, 20, 172, 205, 228, 139, 211, 17, 187, 72,
			0, 160, 201, 60, 167, 58
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_ondragbegin(IWMPSliderCtrlEvents_ondragbeginEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = new IWMPSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ondragbegin(IWMPSliderCtrlEvents_ondragbeginEventHandler P_0)
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
				IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = (IWMPSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate != null && ((iWMPSliderCtrlEvents_SinkHelper.m_ondragbeginDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public void add_ondragend(IWMPSliderCtrlEvents_ondragendEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = new IWMPSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPSliderCtrlEvents_SinkHelper.m_ondragendDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ondragend(IWMPSliderCtrlEvents_ondragendEventHandler P_0)
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
				IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = (IWMPSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPSliderCtrlEvents_SinkHelper.m_ondragendDelegate != null && ((iWMPSliderCtrlEvents_SinkHelper.m_ondragendDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public void add_onpositionchange(IWMPSliderCtrlEvents_onpositionchangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = new IWMPSliderCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPSliderCtrlEvents_SinkHelper, out pdwCookie);
			iWMPSliderCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPSliderCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onpositionchange(IWMPSliderCtrlEvents_onpositionchangeEventHandler P_0)
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
				IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = (IWMPSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate != null && ((iWMPSliderCtrlEvents_SinkHelper.m_onpositionchangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPSliderCtrlEvents_SinkHelper.m_dwCookie);
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

	public IWMPSliderCtrlEvents_EventProvider(object P_0)
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
					IWMPSliderCtrlEvents_SinkHelper iWMPSliderCtrlEvents_SinkHelper = (IWMPSliderCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(iWMPSliderCtrlEvents_SinkHelper.m_dwCookie);
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
