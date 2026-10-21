using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class IWMPVideoCtrlEvents_EventProvider : IWMPVideoCtrlEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			119, 4, 92, 168, 76, 113, 6, 74, 185, 246,
			124, 140, 163, 139, 69, 220
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_onvideostart(IWMPVideoCtrlEvents_onvideostartEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPVideoCtrlEvents_SinkHelper iWMPVideoCtrlEvents_SinkHelper = new IWMPVideoCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPVideoCtrlEvents_SinkHelper, out pdwCookie);
			iWMPVideoCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPVideoCtrlEvents_SinkHelper.m_onvideostartDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPVideoCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onvideostart(IWMPVideoCtrlEvents_onvideostartEventHandler P_0)
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
				IWMPVideoCtrlEvents_SinkHelper iWMPVideoCtrlEvents_SinkHelper = (IWMPVideoCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPVideoCtrlEvents_SinkHelper.m_onvideostartDelegate != null && ((iWMPVideoCtrlEvents_SinkHelper.m_onvideostartDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPVideoCtrlEvents_SinkHelper.m_dwCookie);
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

	public void add_onvideoend(IWMPVideoCtrlEvents_onvideoendEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPVideoCtrlEvents_SinkHelper iWMPVideoCtrlEvents_SinkHelper = new IWMPVideoCtrlEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPVideoCtrlEvents_SinkHelper, out pdwCookie);
			iWMPVideoCtrlEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPVideoCtrlEvents_SinkHelper.m_onvideoendDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPVideoCtrlEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onvideoend(IWMPVideoCtrlEvents_onvideoendEventHandler P_0)
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
				IWMPVideoCtrlEvents_SinkHelper iWMPVideoCtrlEvents_SinkHelper = (IWMPVideoCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPVideoCtrlEvents_SinkHelper.m_onvideoendDelegate != null && ((iWMPVideoCtrlEvents_SinkHelper.m_onvideoendDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPVideoCtrlEvents_SinkHelper.m_dwCookie);
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

	public IWMPVideoCtrlEvents_EventProvider(object P_0)
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
					IWMPVideoCtrlEvents_SinkHelper iWMPVideoCtrlEvents_SinkHelper = (IWMPVideoCtrlEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(iWMPVideoCtrlEvents_SinkHelper.m_dwCookie);
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
