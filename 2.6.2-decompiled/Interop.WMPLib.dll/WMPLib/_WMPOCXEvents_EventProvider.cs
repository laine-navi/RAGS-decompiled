using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class _WMPOCXEvents_EventProvider : _WMPOCXEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			81, 42, 245, 107, 74, 57, 211, 17, 177, 83,
			0, 192, 79, 121, 250, 166
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_OpenStateChange(_WMPOCXEvents_OpenStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_OpenStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_OpenStateChange(_WMPOCXEvents_OpenStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_OpenStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_OpenStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlayStateChange(_WMPOCXEvents_PlayStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlayStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlayStateChange(_WMPOCXEvents_PlayStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlayStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlayStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_AudioLanguageChange(_WMPOCXEvents_AudioLanguageChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_AudioLanguageChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_AudioLanguageChange(_WMPOCXEvents_AudioLanguageChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_AudioLanguageChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_AudioLanguageChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_StatusChange(_WMPOCXEvents_StatusChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_StatusChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_StatusChange(_WMPOCXEvents_StatusChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_StatusChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_StatusChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_ScriptCommand(_WMPOCXEvents_ScriptCommandEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_ScriptCommandDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ScriptCommand(_WMPOCXEvents_ScriptCommandEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_ScriptCommandDelegate != null && ((wMPOCXEvents_SinkHelper.m_ScriptCommandDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_NewStream(_WMPOCXEvents_NewStreamEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_NewStreamDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_NewStream(_WMPOCXEvents_NewStreamEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_NewStreamDelegate != null && ((wMPOCXEvents_SinkHelper.m_NewStreamDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_Disconnect(_WMPOCXEvents_DisconnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DisconnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Disconnect(_WMPOCXEvents_DisconnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DisconnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_DisconnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_Buffering(_WMPOCXEvents_BufferingEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_BufferingDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Buffering(_WMPOCXEvents_BufferingEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_BufferingDelegate != null && ((wMPOCXEvents_SinkHelper.m_BufferingDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_Error(_WMPOCXEvents_ErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_ErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Error(_WMPOCXEvents_ErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_ErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_ErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_Warning(_WMPOCXEvents_WarningEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_WarningDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Warning(_WMPOCXEvents_WarningEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_WarningDelegate != null && ((wMPOCXEvents_SinkHelper.m_WarningDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_EndOfStream(_WMPOCXEvents_EndOfStreamEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_EndOfStreamDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_EndOfStream(_WMPOCXEvents_EndOfStreamEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_EndOfStreamDelegate != null && ((wMPOCXEvents_SinkHelper.m_EndOfStreamDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PositionChange(_WMPOCXEvents_PositionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PositionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PositionChange(_WMPOCXEvents_PositionChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PositionChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_PositionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MarkerHit(_WMPOCXEvents_MarkerHitEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MarkerHitDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MarkerHit(_WMPOCXEvents_MarkerHitEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MarkerHitDelegate != null && ((wMPOCXEvents_SinkHelper.m_MarkerHitDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DurationUnitChange(_WMPOCXEvents_DurationUnitChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DurationUnitChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DurationUnitChange(_WMPOCXEvents_DurationUnitChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DurationUnitChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_DurationUnitChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromMediaChange(_WMPOCXEvents_CdromMediaChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromMediaChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromMediaChange(_WMPOCXEvents_CdromMediaChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromMediaChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromMediaChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistChange(_WMPOCXEvents_PlaylistChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlaylistChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistChange(_WMPOCXEvents_PlaylistChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlaylistChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlaylistChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentPlaylistChange(_WMPOCXEvents_CurrentPlaylistChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CurrentPlaylistChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentPlaylistChange(_WMPOCXEvents_CurrentPlaylistChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CurrentPlaylistChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_CurrentPlaylistChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentPlaylistItemAvailable(_WMPOCXEvents_CurrentPlaylistItemAvailableEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentPlaylistItemAvailable(_WMPOCXEvents_CurrentPlaylistItemAvailableEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate != null && ((wMPOCXEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaChange(_WMPOCXEvents_MediaChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaChange(_WMPOCXEvents_MediaChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentMediaItemAvailable(_WMPOCXEvents_CurrentMediaItemAvailableEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentMediaItemAvailable(_WMPOCXEvents_CurrentMediaItemAvailableEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate != null && ((wMPOCXEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentItemChange(_WMPOCXEvents_CurrentItemChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CurrentItemChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentItemChange(_WMPOCXEvents_CurrentItemChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CurrentItemChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_CurrentItemChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionChange(_WMPOCXEvents_MediaCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionChange(_WMPOCXEvents_MediaCollectionChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringAdded(_WMPOCXEvents_MediaCollectionAttributeStringAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringAdded(_WMPOCXEvents_MediaCollectionAttributeStringAddedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringRemoved(_WMPOCXEvents_MediaCollectionAttributeStringRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringRemoved(_WMPOCXEvents_MediaCollectionAttributeStringRemovedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringChanged(_WMPOCXEvents_MediaCollectionAttributeStringChangedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringChanged(_WMPOCXEvents_MediaCollectionAttributeStringChangedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionChange(_WMPOCXEvents_PlaylistCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlaylistCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionChange(_WMPOCXEvents_PlaylistCollectionChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlaylistCollectionChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlaylistCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionPlaylistAdded(_WMPOCXEvents_PlaylistCollectionPlaylistAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistAdded(_WMPOCXEvents_PlaylistCollectionPlaylistAddedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionPlaylistRemoved(_WMPOCXEvents_PlaylistCollectionPlaylistRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistRemoved(_WMPOCXEvents_PlaylistCollectionPlaylistRemovedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionPlaylistSetAsDeleted(_WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistSetAsDeleted(_WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_ModeChange(_WMPOCXEvents_ModeChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_ModeChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ModeChange(_WMPOCXEvents_ModeChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_ModeChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_ModeChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaError(_WMPOCXEvents_MediaErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaError(_WMPOCXEvents_MediaErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_OpenPlaylistSwitch(_WMPOCXEvents_OpenPlaylistSwitchEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_OpenPlaylistSwitchDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_OpenPlaylistSwitch(_WMPOCXEvents_OpenPlaylistSwitchEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_OpenPlaylistSwitchDelegate != null && ((wMPOCXEvents_SinkHelper.m_OpenPlaylistSwitchDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DomainChange(_WMPOCXEvents_DomainChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DomainChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DomainChange(_WMPOCXEvents_DomainChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DomainChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_DomainChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_SwitchedToPlayerApplication(_WMPOCXEvents_SwitchedToPlayerApplicationEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_SwitchedToPlayerApplicationDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_SwitchedToPlayerApplication(_WMPOCXEvents_SwitchedToPlayerApplicationEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_SwitchedToPlayerApplicationDelegate != null && ((wMPOCXEvents_SinkHelper.m_SwitchedToPlayerApplicationDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_SwitchedToControl(_WMPOCXEvents_SwitchedToControlEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_SwitchedToControlDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_SwitchedToControl(_WMPOCXEvents_SwitchedToControlEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_SwitchedToControlDelegate != null && ((wMPOCXEvents_SinkHelper.m_SwitchedToControlDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlayerDockedStateChange(_WMPOCXEvents_PlayerDockedStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlayerDockedStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlayerDockedStateChange(_WMPOCXEvents_PlayerDockedStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlayerDockedStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlayerDockedStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_PlayerReconnect(_WMPOCXEvents_PlayerReconnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_PlayerReconnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlayerReconnect(_WMPOCXEvents_PlayerReconnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_PlayerReconnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_PlayerReconnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_Click(_WMPOCXEvents_ClickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_ClickDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Click(_WMPOCXEvents_ClickEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_ClickDelegate != null && ((wMPOCXEvents_SinkHelper.m_ClickDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DoubleClick(_WMPOCXEvents_DoubleClickEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DoubleClickDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DoubleClick(_WMPOCXEvents_DoubleClickEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DoubleClickDelegate != null && ((wMPOCXEvents_SinkHelper.m_DoubleClickDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_KeyDown(_WMPOCXEvents_KeyDownEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_KeyDownDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_KeyDown(_WMPOCXEvents_KeyDownEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_KeyDownDelegate != null && ((wMPOCXEvents_SinkHelper.m_KeyDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_KeyPress(_WMPOCXEvents_KeyPressEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_KeyPressDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_KeyPress(_WMPOCXEvents_KeyPressEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_KeyPressDelegate != null && ((wMPOCXEvents_SinkHelper.m_KeyPressDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_KeyUp(_WMPOCXEvents_KeyUpEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_KeyUpDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_KeyUp(_WMPOCXEvents_KeyUpEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_KeyUpDelegate != null && ((wMPOCXEvents_SinkHelper.m_KeyUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MouseDown(_WMPOCXEvents_MouseDownEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MouseDownDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MouseDown(_WMPOCXEvents_MouseDownEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MouseDownDelegate != null && ((wMPOCXEvents_SinkHelper.m_MouseDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MouseMove(_WMPOCXEvents_MouseMoveEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MouseMoveDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MouseMove(_WMPOCXEvents_MouseMoveEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MouseMoveDelegate != null && ((wMPOCXEvents_SinkHelper.m_MouseMoveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MouseUp(_WMPOCXEvents_MouseUpEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MouseUpDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MouseUp(_WMPOCXEvents_MouseUpEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MouseUpDelegate != null && ((wMPOCXEvents_SinkHelper.m_MouseUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceConnect(_WMPOCXEvents_DeviceConnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceConnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceConnect(_WMPOCXEvents_DeviceConnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceConnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceConnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceDisconnect(_WMPOCXEvents_DeviceDisconnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceDisconnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceDisconnect(_WMPOCXEvents_DeviceDisconnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceDisconnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceDisconnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceStatusChange(_WMPOCXEvents_DeviceStatusChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceStatusChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceStatusChange(_WMPOCXEvents_DeviceStatusChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceStatusChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceStatusChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceSyncStateChange(_WMPOCXEvents_DeviceSyncStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceSyncStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceSyncStateChange(_WMPOCXEvents_DeviceSyncStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceSyncStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceSyncStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceSyncError(_WMPOCXEvents_DeviceSyncErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceSyncErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceSyncError(_WMPOCXEvents_DeviceSyncErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceSyncErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceSyncErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CreatePartnershipComplete(_WMPOCXEvents_CreatePartnershipCompleteEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CreatePartnershipCompleteDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CreatePartnershipComplete(_WMPOCXEvents_CreatePartnershipCompleteEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CreatePartnershipCompleteDelegate != null && ((wMPOCXEvents_SinkHelper.m_CreatePartnershipCompleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_DeviceEstimation(_WMPOCXEvents_DeviceEstimationEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_DeviceEstimationDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DeviceEstimation(_WMPOCXEvents_DeviceEstimationEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_DeviceEstimationDelegate != null && ((wMPOCXEvents_SinkHelper.m_DeviceEstimationDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromRipStateChange(_WMPOCXEvents_CdromRipStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromRipStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromRipStateChange(_WMPOCXEvents_CdromRipStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromRipStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromRipStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromRipMediaError(_WMPOCXEvents_CdromRipMediaErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromRipMediaErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromRipMediaError(_WMPOCXEvents_CdromRipMediaErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromRipMediaErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromRipMediaErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromBurnStateChange(_WMPOCXEvents_CdromBurnStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromBurnStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromBurnStateChange(_WMPOCXEvents_CdromBurnStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromBurnStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromBurnStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromBurnMediaError(_WMPOCXEvents_CdromBurnMediaErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromBurnMediaErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromBurnMediaError(_WMPOCXEvents_CdromBurnMediaErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromBurnMediaErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromBurnMediaErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromBurnError(_WMPOCXEvents_CdromBurnErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_CdromBurnErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromBurnError(_WMPOCXEvents_CdromBurnErrorEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_CdromBurnErrorDelegate != null && ((wMPOCXEvents_SinkHelper.m_CdromBurnErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_LibraryConnect(_WMPOCXEvents_LibraryConnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_LibraryConnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_LibraryConnect(_WMPOCXEvents_LibraryConnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_LibraryConnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_LibraryConnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_LibraryDisconnect(_WMPOCXEvents_LibraryDisconnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_LibraryDisconnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_LibraryDisconnect(_WMPOCXEvents_LibraryDisconnectEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_LibraryDisconnectDelegate != null && ((wMPOCXEvents_SinkHelper.m_LibraryDisconnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_FolderScanStateChange(_WMPOCXEvents_FolderScanStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_FolderScanStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_FolderScanStateChange(_WMPOCXEvents_FolderScanStateChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_FolderScanStateChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_FolderScanStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_StringCollectionChange(_WMPOCXEvents_StringCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_StringCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_StringCollectionChange(_WMPOCXEvents_StringCollectionChangeEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_StringCollectionChangeDelegate != null && ((wMPOCXEvents_SinkHelper.m_StringCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionMediaAdded(_WMPOCXEvents_MediaCollectionMediaAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionMediaAdded(_WMPOCXEvents_MediaCollectionMediaAddedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionMediaRemoved(_WMPOCXEvents_MediaCollectionMediaRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = new _WMPOCXEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPOCXEvents_SinkHelper, out pdwCookie);
			wMPOCXEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPOCXEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPOCXEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionMediaRemoved(_WMPOCXEvents_MediaCollectionMediaRemovedEventHandler P_0)
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
				_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPOCXEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate != null && ((wMPOCXEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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

	public _WMPOCXEvents_EventProvider(object P_0)
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
					_WMPOCXEvents_SinkHelper wMPOCXEvents_SinkHelper = (_WMPOCXEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(wMPOCXEvents_SinkHelper.m_dwCookie);
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
