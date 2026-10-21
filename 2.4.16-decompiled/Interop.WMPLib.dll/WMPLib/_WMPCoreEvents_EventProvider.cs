using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WMPLib;

internal sealed class _WMPCoreEvents_EventProvider : _WMPCoreEvents_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			150, 202, 76, 216, 226, 204, 210, 17, 158, 204,
			0, 0, 248, 8, 89, 129
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_PlaylistCollectionPlaylistSetAsDeleted(_WMPCoreEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistSetAsDeleted(_WMPCoreEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistSetAsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_ModeChange(_WMPCoreEvents_ModeChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_ModeChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ModeChange(_WMPCoreEvents_ModeChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_ModeChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_ModeChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaError(_WMPCoreEvents_MediaErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaError(_WMPCoreEvents_MediaErrorEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaErrorDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_OpenPlaylistSwitch(_WMPCoreEvents_OpenPlaylistSwitchEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_OpenPlaylistSwitchDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_OpenPlaylistSwitch(_WMPCoreEvents_OpenPlaylistSwitchEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_OpenPlaylistSwitchDelegate != null && ((wMPCoreEvents_SinkHelper.m_OpenPlaylistSwitchDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_DomainChange(_WMPCoreEvents_DomainChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_DomainChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DomainChange(_WMPCoreEvents_DomainChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_DomainChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_DomainChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_StringCollectionChange(_WMPCoreEvents_StringCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_StringCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_StringCollectionChange(_WMPCoreEvents_StringCollectionChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_StringCollectionChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_StringCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionMediaAdded(_WMPCoreEvents_MediaCollectionMediaAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionMediaAdded(_WMPCoreEvents_MediaCollectionMediaAddedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionMediaAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionMediaRemoved(_WMPCoreEvents_MediaCollectionMediaRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionMediaRemoved(_WMPCoreEvents_MediaCollectionMediaRemovedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionMediaRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_OpenStateChange(_WMPCoreEvents_OpenStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_OpenStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_OpenStateChange(_WMPCoreEvents_OpenStateChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_OpenStateChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_OpenStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PlayStateChange(_WMPCoreEvents_PlayStateChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlayStateChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlayStateChange(_WMPCoreEvents_PlayStateChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlayStateChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlayStateChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_AudioLanguageChange(_WMPCoreEvents_AudioLanguageChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_AudioLanguageChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_AudioLanguageChange(_WMPCoreEvents_AudioLanguageChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_AudioLanguageChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_AudioLanguageChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_StatusChange(_WMPCoreEvents_StatusChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_StatusChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_StatusChange(_WMPCoreEvents_StatusChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_StatusChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_StatusChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_ScriptCommand(_WMPCoreEvents_ScriptCommandEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_ScriptCommandDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_ScriptCommand(_WMPCoreEvents_ScriptCommandEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_ScriptCommandDelegate != null && ((wMPCoreEvents_SinkHelper.m_ScriptCommandDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_NewStream(_WMPCoreEvents_NewStreamEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_NewStreamDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_NewStream(_WMPCoreEvents_NewStreamEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_NewStreamDelegate != null && ((wMPCoreEvents_SinkHelper.m_NewStreamDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_Disconnect(_WMPCoreEvents_DisconnectEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_DisconnectDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Disconnect(_WMPCoreEvents_DisconnectEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_DisconnectDelegate != null && ((wMPCoreEvents_SinkHelper.m_DisconnectDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_Buffering(_WMPCoreEvents_BufferingEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_BufferingDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Buffering(_WMPCoreEvents_BufferingEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_BufferingDelegate != null && ((wMPCoreEvents_SinkHelper.m_BufferingDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_Error(_WMPCoreEvents_ErrorEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_ErrorDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Error(_WMPCoreEvents_ErrorEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_ErrorDelegate != null && ((wMPCoreEvents_SinkHelper.m_ErrorDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_Warning(_WMPCoreEvents_WarningEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_WarningDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_Warning(_WMPCoreEvents_WarningEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_WarningDelegate != null && ((wMPCoreEvents_SinkHelper.m_WarningDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_EndOfStream(_WMPCoreEvents_EndOfStreamEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_EndOfStreamDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_EndOfStream(_WMPCoreEvents_EndOfStreamEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_EndOfStreamDelegate != null && ((wMPCoreEvents_SinkHelper.m_EndOfStreamDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PositionChange(_WMPCoreEvents_PositionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PositionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PositionChange(_WMPCoreEvents_PositionChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PositionChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_PositionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MarkerHit(_WMPCoreEvents_MarkerHitEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MarkerHitDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MarkerHit(_WMPCoreEvents_MarkerHitEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MarkerHitDelegate != null && ((wMPCoreEvents_SinkHelper.m_MarkerHitDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_DurationUnitChange(_WMPCoreEvents_DurationUnitChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_DurationUnitChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_DurationUnitChange(_WMPCoreEvents_DurationUnitChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_DurationUnitChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_DurationUnitChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_CdromMediaChange(_WMPCoreEvents_CdromMediaChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_CdromMediaChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CdromMediaChange(_WMPCoreEvents_CdromMediaChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_CdromMediaChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_CdromMediaChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistChange(_WMPCoreEvents_PlaylistChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlaylistChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistChange(_WMPCoreEvents_PlaylistChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlaylistChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlaylistChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentPlaylistChange(_WMPCoreEvents_CurrentPlaylistChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_CurrentPlaylistChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentPlaylistChange(_WMPCoreEvents_CurrentPlaylistChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_CurrentPlaylistChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_CurrentPlaylistChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentPlaylistItemAvailable(_WMPCoreEvents_CurrentPlaylistItemAvailableEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentPlaylistItemAvailable(_WMPCoreEvents_CurrentPlaylistItemAvailableEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate != null && ((wMPCoreEvents_SinkHelper.m_CurrentPlaylistItemAvailableDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaChange(_WMPCoreEvents_MediaChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaChange(_WMPCoreEvents_MediaChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentMediaItemAvailable(_WMPCoreEvents_CurrentMediaItemAvailableEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentMediaItemAvailable(_WMPCoreEvents_CurrentMediaItemAvailableEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate != null && ((wMPCoreEvents_SinkHelper.m_CurrentMediaItemAvailableDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_CurrentItemChange(_WMPCoreEvents_CurrentItemChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_CurrentItemChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_CurrentItemChange(_WMPCoreEvents_CurrentItemChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_CurrentItemChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_CurrentItemChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionChange(_WMPCoreEvents_MediaCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionChange(_WMPCoreEvents_MediaCollectionChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringAdded(_WMPCoreEvents_MediaCollectionAttributeStringAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringAdded(_WMPCoreEvents_MediaCollectionAttributeStringAddedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringRemoved(_WMPCoreEvents_MediaCollectionAttributeStringRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringRemoved(_WMPCoreEvents_MediaCollectionAttributeStringRemovedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_MediaCollectionAttributeStringChanged(_WMPCoreEvents_MediaCollectionAttributeStringChangedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_MediaCollectionAttributeStringChanged(_WMPCoreEvents_MediaCollectionAttributeStringChangedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate != null && ((wMPCoreEvents_SinkHelper.m_MediaCollectionAttributeStringChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionChange(_WMPCoreEvents_PlaylistCollectionChangeEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlaylistCollectionChangeDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionChange(_WMPCoreEvents_PlaylistCollectionChangeEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlaylistCollectionChangeDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlaylistCollectionChangeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionPlaylistAdded(_WMPCoreEvents_PlaylistCollectionPlaylistAddedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistAdded(_WMPCoreEvents_PlaylistCollectionPlaylistAddedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public void add_PlaylistCollectionPlaylistRemoved(_WMPCoreEvents_PlaylistCollectionPlaylistRemovedEventHandler P_0)
	{
		bool lockTaken = default;
		try
		{
			Monitor.Enter(this, ref lockTaken);
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = new _WMPCoreEvents_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(wMPCoreEvents_SinkHelper, out pdwCookie);
			wMPCoreEvents_SinkHelper.m_dwCookie = pdwCookie;
			wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate = P_0;
			m_aEventSinkHelpers.Add(wMPCoreEvents_SinkHelper);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(this);
			}
		}
	}

	public void remove_PlaylistCollectionPlaylistRemoved(_WMPCoreEvents_PlaylistCollectionPlaylistRemovedEventHandler P_0)
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
				_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
				if (wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate != null && ((wMPCoreEvents_SinkHelper.m_PlaylistCollectionPlaylistRemovedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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

	public _WMPCoreEvents_EventProvider(object P_0)
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
					_WMPCoreEvents_SinkHelper wMPCoreEvents_SinkHelper = (_WMPCoreEvents_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(wMPCoreEvents_SinkHelper.m_dwCookie);
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
