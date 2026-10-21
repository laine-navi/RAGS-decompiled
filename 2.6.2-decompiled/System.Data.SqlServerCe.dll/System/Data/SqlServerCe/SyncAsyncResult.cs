using System.Runtime.InteropServices;
using System.Threading;

namespace System.Data.SqlServerCe;

internal class SyncAsyncResult : IAsyncResult
{
	private ManualResetEvent completeEvent;

	private object callerContext;

	private AsyncCallback callerCompletionCallback;

	private OnStartTableUpload callerOnStartTableUpload;

	private OnStartTableDownload callerOnStartTableDownload;

	private OnSynchronization callerOnSynchronization;

	private SqlCeReplication callerReplobj;

	private bool isCompleted;

	private Exception exception;

	bool IAsyncResult.IsCompleted => isCompleted;

	bool IAsyncResult.CompletedSynchronously => false;

	WaitHandle IAsyncResult.AsyncWaitHandle => completeEvent;

	object IAsyncResult.AsyncState => callerContext;

	internal SyncAsyncResult(SqlCeReplication replication, AsyncCallback completionCallback, object context)
	{
		completeEvent = new ManualResetEvent(initialState: false);
		callerContext = context;
		callerCompletionCallback = completionCallback;
		callerReplobj = replication;
	}

	internal SyncAsyncResult(SqlCeReplication replication, AsyncCallback completionCallback, OnStartTableUpload onStartTableUpload, OnStartTableDownload onStartTableDownload, OnSynchronization onSynchronization, object context)
	{
		completeEvent = new ManualResetEvent(initialState: false);
		callerReplobj = replication;
		callerCompletionCallback = completionCallback;
		callerOnStartTableUpload = onStartTableUpload;
		callerOnStartTableDownload = onStartTableDownload;
		callerOnSynchronization = onSynchronization;
		callerContext = context;
	}

	internal void SyncThread()
	{
		try
		{
			if (callerOnStartTableUpload == null && callerOnStartTableDownload == null && callerOnSynchronization == null)
			{
				callerReplobj.Synchronize();
			}
			else
			{
				BeginSyncAndStatusReporting();
			}
		}
		catch (Exception ex)
		{
			exception = ex;
		}
		callerCompletionCallback(this);
		isCompleted = true;
		completeEvent.Set();
	}

	private void DispatchEventToCaller(SyncStatus status, string tablename, int percentComplete)
	{
		if (SyncStatus.Uploading == status)
		{
			if (callerOnStartTableUpload != null)
			{
				callerOnStartTableUpload(this, tablename);
			}
		}
		else if (SyncStatus.Downloading == status)
		{
			if (callerOnStartTableDownload != null)
			{
				callerOnStartTableDownload(this, tablename);
			}
		}
		else if (SyncStatus.Synchronizing == status && callerOnSynchronization != null)
		{
			callerOnSynchronization(this, percentComplete);
		}
	}

	private void BeginSyncAndStatusReporting()
	{
		IntPtr pAsyncIReplication = IntPtr.Zero;
		int hr = uwrepl_AsyncReplication(callerReplobj.pIReplication, ref pAsyncIReplication);
		NativeMethods.CheckHRESULT(callerReplobj.pIErrors, hr);
		try
		{
			bool pCompleted;
			do
			{
				SyncStatus pSyncStatus = SyncStatus.Start;
				pCompleted = false;
				IntPtr rbzTableName = new IntPtr(0);
				string tablename = null;
				int pPrecentCompleted = 0;
				hr = uwrepl_WaitForNextStatusReport(pAsyncIReplication, ref pSyncStatus, ref rbzTableName, ref pPrecentCompleted, ref pCompleted);
				try
				{
					NativeMethods.CheckHRESULT(callerReplobj.pIErrors, hr);
					tablename = Marshal.PtrToStringUni(rbzTableName);
				}
				finally
				{
					NativeMethods.uwutil_SysFreeString(rbzTableName);
				}
				DispatchEventToCaller(pSyncStatus, tablename, pPrecentCompleted);
			}
			while (!pCompleted);
			int pHr = 0;
			hr = uwrepl_GetSyncResult(pAsyncIReplication, ref pHr);
			NativeMethods.CheckHRESULT(callerReplobj.pIErrors, hr);
			hr = pHr;
			NativeMethods.CheckHRESULT(callerReplobj.pIErrors, hr);
		}
		finally
		{
			if (IntPtr.Zero != pAsyncIReplication)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pAsyncIReplication);
			}
		}
	}

	public Exception GetException()
	{
		return exception;
	}

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_AsyncReplication(IntPtr pIReplication, ref IntPtr pAsyncIReplication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_WaitForNextStatusReport(IntPtr pAsyncReplication, ref SyncStatus pSyncStatus, ref IntPtr rbzTableName, ref int pPrecentCompleted, ref bool pCompleted);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_GetSyncResult(IntPtr pIReplication, ref int pHr);
}
