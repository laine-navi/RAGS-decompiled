using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class IWMPRegionalButtonEvents_EventProvider : IWMPRegionalButtonEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			49, 141, 252, 80, 172, 103, 211, 17, 189, 76,
			0, 192, 79, 110, 165, 174
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_onblur(IWMPRegionalButtonEvents_onblurEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onblurDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onblur(IWMPRegionalButtonEvents_onblurEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onblurDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onblurDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onfocus(IWMPRegionalButtonEvents_onfocusEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onfocusDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onfocus(IWMPRegionalButtonEvents_onfocusEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onfocusDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onfocusDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onclick(IWMPRegionalButtonEvents_onclickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onclickDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onclick(IWMPRegionalButtonEvents_onclickEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onclickDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onclickDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_ondblclick(IWMPRegionalButtonEvents_ondblclickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_ondblclickDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ondblclick(IWMPRegionalButtonEvents_ondblclickEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_ondblclickDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_ondblclickDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onmousedown(IWMPRegionalButtonEvents_onmousedownEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onmousedownDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onmousedown(IWMPRegionalButtonEvents_onmousedownEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onmousedownDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onmousedownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onmouseup(IWMPRegionalButtonEvents_onmouseupEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onmouseupDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onmouseup(IWMPRegionalButtonEvents_onmouseupEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onmouseupDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onmouseupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onmousemove(IWMPRegionalButtonEvents_onmousemoveEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onmousemoveDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onmousemove(IWMPRegionalButtonEvents_onmousemoveEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onmousemoveDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onmousemoveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onmouseover(IWMPRegionalButtonEvents_onmouseoverEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onmouseoverDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onmouseover(IWMPRegionalButtonEvents_onmouseoverEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onmouseoverDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onmouseoverDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onmouseout(IWMPRegionalButtonEvents_onmouseoutEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onmouseoutDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onmouseout(IWMPRegionalButtonEvents_onmouseoutEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onmouseoutDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onmouseoutDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onkeypress(IWMPRegionalButtonEvents_onkeypressEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onkeypressDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onkeypress(IWMPRegionalButtonEvents_onkeypressEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onkeypressDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onkeypressDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onkeydown(IWMPRegionalButtonEvents_onkeydownEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onkeydownDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onkeydown(IWMPRegionalButtonEvents_onkeydownEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onkeydownDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onkeydownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public void add_onkeyup(IWMPRegionalButtonEvents_onkeyupEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = new IWMPRegionalButtonEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(iWMPRegionalButtonEvents_SinkHelper, out pdwCookie);
			iWMPRegionalButtonEvents_SinkHelper.m_dwCookie = pdwCookie;
			iWMPRegionalButtonEvents_SinkHelper.m_onkeyupDelegate = P_0;
			m_aEventSinkHelpers.Add(iWMPRegionalButtonEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_onkeyup(IWMPRegionalButtonEvents_onkeyupEventHandler P_0)
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
				IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (iWMPRegionalButtonEvents_SinkHelper.m_onkeyupDelegate != null && ((iWMPRegionalButtonEvents_SinkHelper.m_onkeyupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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

	public IWMPRegionalButtonEvents_EventProvider(object P_0)
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
					IWMPRegionalButtonEvents_SinkHelper iWMPRegionalButtonEvents_SinkHelper = (IWMPRegionalButtonEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(iWMPRegionalButtonEvents_SinkHelper.m_dwCookie);
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
