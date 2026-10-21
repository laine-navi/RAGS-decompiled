using System.Data.Common;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

public sealed class SqlCeTransaction : DbTransaction
{
	private object thisLock = new object();

	private bool isZombied;

	private bool isDisposed;

	private bool isFinalized;

	internal SqlCeConnection connection;

	private IsolationLevel isolationLevel;

	private IntPtr pQpSession;

	private IntPtr pTx;

	private IntPtr pError;

	private long ullTransactionBsn;

	private SqlCeChangeTracking m_tracking;

	protected override DbConnection DbConnection => connection;

	internal SeTransactionFlags EngineFlags
	{
		get
		{
			EnterPublicAPI();
			SeTransactionFlags seTxFlags = SeTransactionFlags.NOFLAGS;
			int transactionFlags = NativeMethods.GetTransactionFlags(ITransact, ref seTxFlags);
			ProcessResults(transactionFlags);
			return seTxFlags;
		}
		set
		{
			EnterPublicAPI();
			SeTransactionFlags seTxFlags = SeTransactionFlags.NOFLAGS;
			int num = 0;
			num = NativeMethods.GetTransactionFlags(ITransact, ref seTxFlags);
			ProcessResults(num);
			num = NativeMethods.SetTransactionFlag(ITransact, seTxFlags, fEnable: false, pError);
			ProcessResults(num);
			num = NativeMethods.SetTransactionFlag(ITransact, value, fEnable: true, pError);
			ProcessResults(num);
		}
	}

	private new SqlCeConnection Connection => connection;

	public override IsolationLevel IsolationLevel
	{
		get
		{
			if (IntPtr.Zero == Connection.ITransact)
			{
				throw new InvalidOperationException(Res.GetString("ADP_TransactionZombied", GetType().Name));
			}
			return isolationLevel;
		}
	}

	public Guid TrackingContext
	{
		get
		{
			EnterPublicAPI();
			string empty = string.Empty;
			IntPtr pGuidTrackingContext = (IntPtr)0;
			int trackingContext = NativeMethods.GetTrackingContext(ITransact, out pGuidTrackingContext, pError);
			if (trackingContext != 0)
			{
				ProcessResults(trackingContext);
			}
			empty = Marshal.PtrToStringBSTR(pGuidTrackingContext);
			NativeMethods.uwutil_SysFreeString(pGuidTrackingContext);
			return new Guid(empty);
		}
		set
		{
			EnterPublicAPI();
			string s = "{" + value.ToString() + "}";
			IntPtr pGuidTrackingContext = Marshal.StringToBSTR(s);
			int hr = NativeMethods.SetTrackingContext(ITransact, ref pGuidTrackingContext, pError);
			NativeMethods.uwutil_SysFreeString(pGuidTrackingContext);
			ProcessResults(hr);
		}
	}

	public long CurrentTransactionBsn => ullTransactionBsn;

	internal bool IsZombied => isZombied;

	internal IntPtr ITransact => pTx;

	internal IntPtr IQPSession => pQpSession;

	internal void SetTrackingObject(SqlCeChangeTracking trk)
	{
		m_tracking = trk;
	}

	internal SqlCeTransaction(SqlCeConnection connection, IsolationLevel isolationLevel, IntPtr pTx, IntPtr pQpSession)
	{
		this.pTx = pTx;
		this.pQpSession = pQpSession;
		isZombied = false;
		isDisposed = false;
		isFinalized = false;
		this.isolationLevel = isolationLevel;
		this.connection = connection;
		ullTransactionBsn = 0L;
		m_tracking = null;
		int num = NativeMethods.CreateErrorInstance(ref pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
		num = NativeMethods.GetTransactionBsn(pTx, ref ullTransactionBsn, pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
	}

	~SqlCeTransaction()
	{
		Dispose(disposing: false);
	}

	private void ReleaseNativeInterfaces()
	{
		if (IntPtr.Zero != pQpSession)
		{
			NativeMethods.SafeRelease(ref pQpSession);
		}
		if (IntPtr.Zero != pTx)
		{
			NativeMethods.SafeRelease(ref pTx);
		}
		if (IntPtr.Zero != pError)
		{
			NativeMethods.SafeDelete(ref pError);
		}
	}

	private void EnterPublicAPI()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeTransaction");
		}
		if (Connection == null || IntPtr.Zero == Connection.ITransact)
		{
			isZombied = true;
		}
		if (isZombied)
		{
			throw new InvalidOperationException(Res.GetString("ADP_TransactionZombied", GetType().Name));
		}
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected override void Dispose(bool disposing)
	{
		lock (thisLock)
		{
			if (isFinalized)
			{
				return;
			}
			if (disposing)
			{
				if (IntPtr.Zero != pTx)
				{
					Rollback();
				}
				isDisposed = true;
			}
			ReleaseNativeInterfaces();
			if (!disposing)
			{
				isFinalized = true;
			}
		}
	}

	public override void Commit()
	{
		Commit(CommitMode.Deferred);
	}

	public void Commit(CommitMode mode)
	{
		EnterPublicAPI();
		if (connection.HasOpenedCursors(this))
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_OpenedCursorsOnTxCommit"));
		}
		try
		{
			if (m_tracking != null)
			{
				m_tracking.Dispose(disposing: true);
			}
			int num = NativeMethods.CommitTransaction(pTx, mode, pError);
			isZombied = true;
			if (num != 0)
			{
				ProcessResults(num);
			}
			if (connection != null)
			{
				connection.Zombie(this);
				connection.RemoveWeakReference(this);
			}
		}
		finally
		{
			Dispose(disposing: false);
		}
	}

	public override void Rollback()
	{
		EnterPublicAPI();
		if (connection.HasOpenedCursors(this))
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_OpenedCursorsOnTxAbort"));
		}
		try
		{
			if (m_tracking != null)
			{
				m_tracking.Dispose(disposing: true);
			}
			int num = NativeMethods.AbortTransaction(pTx, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			isZombied = true;
			connection.Zombie(this);
			connection.RemoveWeakReference(this);
		}
		finally
		{
			Dispose(disposing: false);
		}
	}

	private void ProcessResults(int hr)
	{
		Exception ex = connection.ProcessResults(hr, pError, this);
		if (ex != null)
		{
			throw ex;
		}
	}
}
