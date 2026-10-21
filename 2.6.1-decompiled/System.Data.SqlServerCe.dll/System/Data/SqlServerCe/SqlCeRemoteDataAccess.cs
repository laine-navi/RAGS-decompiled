using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.SqlServerCe;

public sealed class SqlCeRemoteDataAccess : IDisposable
{
	private IntPtr pIRda = IntPtr.Zero;

	private IntPtr pIErrors = IntPtr.Zero;

	public string LocalConnectionString
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_LocalConnectionString(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			string text = null;
			StringBuilder stringBuilder = new StringBuilder();
			Hashtable hashtable = ConStringUtil.ParseConnectionString(ref value);
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text = (string)enumerator.Current;
				stringBuilder.Append(text);
				stringBuilder.Append("=\"");
				stringBuilder.Append(hashtable[text]);
				stringBuilder.Append("\";");
			}
			int hr = uwrda_put_LocalConnectionString(pIRda, stringBuilder.ToString());
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetUrl
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetUrl(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetUrl(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetLogin
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetLogin(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetLogin(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetPassword
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetPassword(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetPassword(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public bool ConnectionManager
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			bool ConnectionManager = false;
			int hr = uwrda_get_ConnectionManager(pIRda, ref ConnectionManager);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ConnectionManager;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ConnectionManager(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyServer
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetProxyServer(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetProxyServer(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyLogin
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetProxyLogin(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetProxyLogin(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyPassword
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrda_get_InternetProxyPassword(pIRda, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_InternetProxyPassword(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int ConnectTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int connectTimeout = 0;
			int hr = uwrda_get_ConnectTimeout(pIRda, ref connectTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return connectTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ConnectTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int SendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int SendTimeout = 0;
			int hr = uwrda_get_SendTimeout(pIRda, ref SendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return SendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_SendTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int ReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int ReceiveTimeout = 0;
			int hr = uwrda_get_ReceiveTimeout(pIRda, ref ReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ReceiveTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int DataSendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int DataSendTimeout = 0;
			int hr = uwrda_get_DataSendTimeout(pIRda, ref DataSendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DataSendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_DataSendTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int DataReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int DataReceiveTimeout = 0;
			int hr = uwrda_get_DataReceiveTimeout(pIRda, ref DataReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DataReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_DataReceiveTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int ControlSendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int ControlSendTimeout = 0;
			int hr = uwrda_get_ControlSendTimeout(pIRda, ref ControlSendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ControlSendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ControlSendTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int ControlReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int ControlReceiveTimeout = 0;
			int hr = uwrda_get_ControlReceiveTimeout(pIRda, ref ControlReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ControlReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ControlReceiveTimeout(pIRda, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public short ConnectionRetryTimeout
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			ushort ConnectionRetryTimeout = 0;
			int hr = uwrda_get_ConnectionRetryTimeout(pIRda, ref ConnectionRetryTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)ConnectionRetryTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_ConnectionRetryTimeout(pIRda, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public short CompressionLevel
	{
		get
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			ushort CompressionLevel = 0;
			int hr = uwrda_get_CompressionLevel(pIRda, ref CompressionLevel);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)CompressionLevel;
		}
		set
		{
			if (IntPtr.Zero == pIRda)
			{
				throw new ObjectDisposedException("SqlCeRemoteDataAccess");
			}
			int hr = uwrda_put_CompressionLevel(pIRda, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public SqlCeRemoteDataAccess()
	{
		NativeMethods.LoadNativeBinaries();
		pIRda = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrda_RemoteDataAccess(ref pIRda, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrda_get_ErrorPointer(pIRda, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		NativeMethods.DllAddRef();
	}

	public SqlCeRemoteDataAccess(string internetUrl, string localConnectionString)
	{
		NativeMethods.LoadNativeBinaries();
		pIRda = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrda_RemoteDataAccess(ref pIRda, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrda_get_ErrorPointer(pIRda, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		InternetUrl = internetUrl;
		LocalConnectionString = localConnectionString;
		NativeMethods.DllAddRef();
	}

	public SqlCeRemoteDataAccess(string internetUrl, string internetLogin, string internetPassword, string localConnectionString)
	{
		NativeMethods.LoadNativeBinaries();
		pIRda = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrda_RemoteDataAccess(ref pIRda, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrda_get_ErrorPointer(pIRda, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		InternetUrl = internetUrl;
		LocalConnectionString = localConnectionString;
		InternetLogin = internetLogin;
		InternetPassword = internetPassword;
		NativeMethods.DllAddRef();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~SqlCeRemoteDataAccess()
	{
		Dispose(disposing: false);
	}

	private void Dispose(bool disposing)
	{
		if (IntPtr.Zero != pIRda)
		{
			NativeMethods.uwutil_ReleaseCOMPtr(pIRda);
			pIRda = IntPtr.Zero;
		}
		if (IntPtr.Zero != pIErrors)
		{
			NativeMethods.uwutil_ReleaseCOMPtr(pIErrors);
			pIErrors = IntPtr.Zero;
		}
		GC.KeepAlive(pIRda);
		GC.KeepAlive(pIErrors);
		if (disposing)
		{
			NativeMethods.DllRelease();
		}
	}

	public void Pull(string localTableName, string sqlSelectString, string oleDBConnectionString)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_Pull(pIRda, localTableName, sqlSelectString, oleDBConnectionString, RdaTrackOption.TrackingOff, "");
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void Pull(string localTableName, string sqlSelectString, string oleDBConnectionString, RdaTrackOption trackOption)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_Pull(pIRda, localTableName, sqlSelectString, oleDBConnectionString, trackOption, "");
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void Pull(string localTableName, string sqlSelectString, string oleDBConnectionString, RdaTrackOption trackOption, string errorTable)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_Pull(pIRda, localTableName, sqlSelectString, oleDBConnectionString, trackOption, errorTable);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void Push(string localTableName, string oleDBConnectionString)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_Push(pIRda, localTableName, oleDBConnectionString, RdaBatchOption.BatchingOff);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void Push(string localTableName, string oleDBConnectionString, RdaBatchOption batchOption)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_Push(pIRda, localTableName, oleDBConnectionString, batchOption);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void SubmitSql(string sqlString, string oleDBConnectionString)
	{
		if (IntPtr.Zero == pIRda)
		{
			throw new ObjectDisposedException("SqlCeRemoteDataAccess");
		}
		int hr = uwrda_SubmitSql(pIRda, sqlString, oleDBConnectionString);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_RemoteDataAccess(ref IntPtr pIRda, ref IntPtr pCreationIError);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ErrorPointer(IntPtr pIRda, ref IntPtr pIErrors);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_LocalConnectionString(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_LocalConnectionString(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string zLocalConnectionString);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetUrl(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetUrl(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetUrl);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetLogin(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetLogin(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetPassword(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetPassword(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetProxyServer(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetProxyServer(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyServer);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetProxyLogin(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetProxyLogin(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_InternetProxyPassword(IntPtr pIRda, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_InternetProxyPassword(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ConnectTimeout(IntPtr pIRda, ref int connectTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ConnectTimeout(IntPtr pIRda, int connectTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_SendTimeout(IntPtr pIRda, ref int SendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_SendTimeout(IntPtr pIRda, int SendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ReceiveTimeout(IntPtr pIRda, ref int ReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ReceiveTimeout(IntPtr pIRda, int ReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_DataSendTimeout(IntPtr pIRda, ref int DataSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_DataSendTimeout(IntPtr pIRda, int DataSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_DataReceiveTimeout(IntPtr pIRda, ref int DataReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_DataReceiveTimeout(IntPtr pIRda, int DataReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ControlSendTimeout(IntPtr pIRda, ref int ControlSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ControlSendTimeout(IntPtr pIRda, int ControlSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ControlReceiveTimeout(IntPtr pIRda, ref int ControlReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ControlReceiveTimeout(IntPtr pIRda, int ControlReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ConnectionRetryTimeout(IntPtr pIRda, ref ushort ConnectionRetryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ConnectionRetryTimeout(IntPtr pIRda, ushort ConnectionRetryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_CompressionLevel(IntPtr pIRda, ref ushort CompressionLevel);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_CompressionLevel(IntPtr pIRda, ushort CompressionLevel);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_get_ConnectionManager(IntPtr pIRda, ref bool ConnectionManager);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_put_ConnectionManager(IntPtr pIRda, bool ConnectionManager);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_Pull(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string zLocalTableName, [MarshalAs(UnmanagedType.LPWStr)] string zSqlSelectString, [MarshalAs(UnmanagedType.LPWStr)] string zOleDbConnectionString, RdaTrackOption trackOption, [MarshalAs(UnmanagedType.LPWStr)] string zErrorTable);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_Push(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string zLocalTableName, [MarshalAs(UnmanagedType.LPWStr)] string zOleDbConnectionString, RdaBatchOption batchOption);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrda_SubmitSql(IntPtr pIRda, [MarshalAs(UnmanagedType.LPWStr)] string zSqlString, [MarshalAs(UnmanagedType.LPWStr)] string zOleDbConnectionString);
}
