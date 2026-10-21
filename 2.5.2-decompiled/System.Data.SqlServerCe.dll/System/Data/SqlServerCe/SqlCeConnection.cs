using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Transactions;

namespace System.Data.SqlServerCe;

public sealed class SqlCeConnection : DbConnection
{
	private class ObjectLifeTimeTracker : WeakReferenceCache
	{
		internal ObjectLifeTimeTracker(bool trackResurrection)
			: base(trackResurrection)
		{
		}

		internal bool HasOpenedCursors(SqlCeTransaction tx)
		{
			lock (this)
			{
				int num = items.Length;
				for (int i = 0; i < num; i++)
				{
					WeakReference weakReference = items[i];
					if (!ADP.IsAlive(weakReference))
					{
						continue;
					}
					object obj = null;
					try
					{
						obj = weakReference.Target;
						if (obj == null)
						{
							continue;
						}
					}
					catch (InvalidOperationException)
					{
						continue;
					}
					if (obj is SqlCeDataReader)
					{
						SqlCeDataReader sqlCeDataReader = (SqlCeDataReader)obj;
						if (tx == sqlCeDataReader.transaction && !sqlCeDataReader.IsClosed)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		internal void CloseDataRdr(SqlCeTransaction tx)
		{
			ArrayList arrayList = new ArrayList();
			int num = items.Length;
			for (int i = 0; i < num; i++)
			{
				WeakReference weakReference = items[i];
				if (!ADP.IsAlive(weakReference))
				{
					continue;
				}
				object obj = null;
				try
				{
					obj = weakReference.Target;
					if (obj == null)
					{
						continue;
					}
				}
				catch (InvalidOperationException)
				{
					continue;
				}
				if (obj is SqlCeDataReader)
				{
					SqlCeDataReader sqlCeDataReader = (SqlCeDataReader)obj;
					if ((tx == null || tx == sqlCeDataReader.transaction) && !sqlCeDataReader.IsClosed)
					{
						arrayList.Add(obj);
						items[i] = null;
					}
				}
			}
			foreach (SqlCeDataReader item in arrayList)
			{
				item.Dispose();
			}
		}

		internal void Close(bool isDisposing)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			ArrayList arrayList4 = new ArrayList();
			int num = items.Length;
			for (int i = 0; i < num; i++)
			{
				WeakReference weakReference = items[i];
				if (!ADP.IsAlive(weakReference))
				{
					continue;
				}
				object obj = null;
				try
				{
					obj = weakReference.Target;
					if (obj == null)
					{
						continue;
					}
				}
				catch (InvalidOperationException)
				{
					continue;
				}
				if (obj is SqlCeDataReader)
				{
					arrayList3.Add(obj);
					items[i] = null;
				}
				else if (obj is SqlCeCommand)
				{
					arrayList2.Add(obj);
				}
				else if (obj is SqlCeTransaction)
				{
					arrayList.Add(obj);
					items[i] = null;
				}
				else if (obj is SqlCeChangeTracking)
				{
					arrayList4.Add(obj);
					items[i] = null;
				}
			}
			foreach (SqlCeDataReader item in arrayList3)
			{
				item.Dispose();
			}
			foreach (SqlCeChangeTracking item2 in arrayList4)
			{
				item2.Dispose();
			}
			foreach (SqlCeCommand item3 in arrayList2)
			{
				item3.CloseFromConnection();
				if (isDisposing)
				{
					item3.Connection = null;
				}
			}
			foreach (SqlCeTransaction item4 in arrayList)
			{
				item4.Dispose();
			}
		}

		internal void Zombie(SqlCeTransaction tx)
		{
			lock (this)
			{
				int num = items.Length;
				for (int i = 0; i < num; i++)
				{
					WeakReference weakReference = items[i];
					if (!ADP.IsAlive(weakReference))
					{
						continue;
					}
					object obj = null;
					try
					{
						obj = weakReference.Target;
						if (obj == null)
						{
							continue;
						}
					}
					catch (InvalidOperationException)
					{
						continue;
					}
					if (obj is SqlCeCommand && tx == ((SqlCeCommand)obj).Transaction)
					{
						((SqlCeCommand)obj).Transaction = null;
					}
				}
			}
		}
	}

	private static Hashtable connStrCache;

	private Hashtable connTokens;

	private SqlCeDelegatedTransaction _delegatedTransaction;

	private bool isOpened;

	private bool isHostControlled;

	private bool removePwd;

	private IntPtr pStoreService;

	private IntPtr pStoreServer;

	private IntPtr pSeStore;

	private IntPtr pQpServices;

	private IntPtr pQpDatabase;

	private IntPtr pQpSession;

	private IntPtr pTx;

	private IntPtr pStoreEvents;

	private IntPtr pError;

	private string connStr;

	private string dataSource;

	private string modifiedConnStr;

	private ConnectionState state;

	private bool isDisposed;

	private ObjectLifeTimeTracker weakReferenceCache;

	private FlushFailureEventHandler flushFailureEventHandler;

	public string DatabaseIdentifier
	{
		get
		{
			CheckStateOpen("GetDatabaseInfo");
			string empty = string.Empty;
			IntPtr pwszGuidString = (IntPtr)0;
			int databaseInstanceID = NativeMethods.GetDatabaseInstanceID(pSeStore, out pwszGuidString, pError);
			if (databaseInstanceID != 0)
			{
				ProcessResults(databaseInstanceID);
			}
			empty = Marshal.PtrToStringBSTR(pwszGuidString);
			NativeMethods.uwutil_SysFreeString(pwszGuidString);
			return empty;
		}
	}

	public override string ConnectionString
	{
		get
		{
			if (connStr == null || connStr.Trim().Length == 0)
			{
				return connStr = string.Empty;
			}
			if (removePwd)
			{
				if (connTokens == null)
				{
					return string.Empty;
				}
				string text = "ssce:database password";
				string key = "persist security info";
				if (connTokens.Contains(text) && (!connTokens.Contains(key) || !(bool)connTokens[key]))
				{
					connStr = ConStringUtil.RemoveKeyValuesFromString(connStr, text);
				}
				removePwd = false;
			}
			return connStr;
		}
		set
		{
			if (state != ConnectionState.Closed)
			{
				throw new InvalidOperationException(Res.GetString("ADP_OpenConnectionPropertySet", "ConnectionString", state));
			}
			Hashtable hashtable = connStrCache;
			if (hashtable != null && value != null && hashtable.Contains(value))
			{
				object[] array = (object[])hashtable[value];
				modifiedConnStr = (string)array[0];
				if (state != ConnectionState.Closed)
				{
					throw new InvalidOperationException(Res.GetString("ADP_OpenConnectionPropertySet", "ConnectionString", state));
				}
				connTokens = (Hashtable)array[1];
			}
			else if (value != null && value.Length > 0)
			{
				connTokens = ConStringUtil.ParseConnectionString(ref value);
				modifiedConnStr = value;
				if (connTokens != null)
				{
					CachedConnectionStringAdd(value, modifiedConnStr, connTokens);
				}
				else
				{
					modifiedConnStr = null;
				}
			}
			else
			{
				modifiedConnStr = null;
				connTokens = null;
			}
			connStr = value;
			removePwd = false;
			if (connTokens != null)
			{
				dataSource = (string)connTokens["data source"];
			}
		}
	}

	public override int ConnectionTimeout => 0;

	public override string Database => dataSource;

	public override string DataSource => dataSource;

	internal SqlCeDelegatedTransaction DelegatedTransaction
	{
		get
		{
			return _delegatedTransaction;
		}
		set
		{
			_delegatedTransaction = value;
		}
	}

	internal bool HasDelegatedTransaction => null != _delegatedTransaction;

	public override ConnectionState State => state;

	public override string ServerVersion => "3.5.8080.0";

	protected override DbProviderFactory DbProviderFactory => SqlCeProviderFactory.Instance;

	internal IntPtr ITransact => pTx;

	internal IntPtr IQPSession => pQpSession;

	internal IntPtr IQPServices => pQpServices;

	internal bool IsEnlisted => (bool)connTokens["ssce:enlist"];

	internal SqlCeTransaction Transaction
	{
		get
		{
			for (int i = 0; i < weakReferenceCache.Count; i++)
			{
				object obj = weakReferenceCache.GetObject(i);
				if (obj is SqlCeTransaction)
				{
					SqlCeTransaction sqlCeTransaction = (SqlCeTransaction)obj;
					if (!HasDelegatedTransaction || sqlCeTransaction != DelegatedTransaction.SqlCeTransaction)
					{
						return sqlCeTransaction;
					}
				}
			}
			return null;
		}
	}

	public event SqlCeInfoMessageEventHandler InfoMessage
	{
		add
		{
			Events.AddHandler(ADP.EventInfoMessage, value);
		}
		remove
		{
			Events.RemoveHandler(ADP.EventInfoMessage, value);
		}
	}

	public event SqlCeFlushFailureEventHandler FlushFailure
	{
		add
		{
			Events.AddHandler(ADP.EventFlushFailure, value);
		}
		remove
		{
			Events.RemoveHandler(ADP.EventFlushFailure, value);
		}
	}

	[Obsolete("This property is obsolete and will be removed in a future version.")]
	public override event StateChangeEventHandler StateChange
	{
		add
		{
			Events.AddHandler(ADP.EventStateChange, value);
		}
		remove
		{
			Events.RemoveHandler(ADP.EventStateChange, value);
		}
	}

	internal void OnFlushFailure(int hr, IntPtr pError)
	{
		SqlCeFlushFailureEventHandler sqlCeFlushFailureEventHandler = (SqlCeFlushFailureEventHandler)Events[ADP.EventFlushFailure];
		if (sqlCeFlushFailureEventHandler == null)
		{
			return;
		}
		try
		{
			sqlCeFlushFailureEventHandler(this, new SqlCeFlushFailureEventArgs(hr, pError, this));
		}
		catch (Exception ex)
		{
			if (!ADP.IsCatchableExceptionType(ex))
			{
				throw ex;
			}
		}
	}

	public override void EnlistTransaction(Transaction SysTrans)
	{
		if (null == SysTrans)
		{
			string message = string.Format(CultureInfo.InvariantCulture, "SysTrans", new object[0]);
			throw new NullReferenceException(message);
		}
		if (!IsEnlisted)
		{
			return;
		}
		if (Transaction != null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_LocalTransactionPresent"));
		}
		if (DelegatedTransaction == null && ConnectionState.Open == State)
		{
			try
			{
				Enlist(SysTrans);
				SqlCeDelegatedTransaction delegatedTransaction = DelegatedTransaction;
				for (int i = 0; i < weakReferenceCache.Count; i++)
				{
					object obj = weakReferenceCache.GetObject(i);
					if (obj is SqlCeCommand)
					{
						((SqlCeCommand)obj).Transaction = delegatedTransaction.SqlCeTransaction;
					}
				}
				return;
			}
			catch
			{
				throw;
			}
		}
		if (!HasDelegatedTransaction || !(SysTrans == DelegatedTransaction.Transaction))
		{
			throw new InvalidOperationException(Res.GetString("ADP_ConnectionNotEnlisted"));
		}
	}

	internal void Enlist(Transaction tx)
	{
		if (null == tx)
		{
			string message = string.Format(CultureInfo.InvariantCulture, "transaction", new object[0]);
			throw new NullReferenceException(message);
		}
		SqlCeDelegatedTransaction sqlCeDelegatedTransaction = new SqlCeDelegatedTransaction(this, tx);
		if (tx.EnlistPromotableSinglePhase(sqlCeDelegatedTransaction))
		{
			_delegatedTransaction = sqlCeDelegatedTransaction;
			return;
		}
		throw new InvalidOperationException(Res.GetString("ADP_ConnectionNotEnlisted"));
	}

	public SqlCeConnection()
	{
		SqlCeRestriction.CheckExplicitWebHosting();
		NativeMethods.LoadNativeBinaries();
		dataSource = string.Empty;
		isHostControlled = false;
		weakReferenceCache = new ObjectLifeTimeTracker(trackResurrection: true);
		NativeMethods.DllAddRef();
	}

	public SqlCeConnection(string connectionString)
		: this()
	{
		ConnectionString = connectionString;
	}

	~SqlCeConnection()
	{
		Dispose(disposing: false);
	}

	private void ReleaseNativeInterfaces()
	{
		if (IntPtr.Zero != pQpSession)
		{
			NativeMethods.SafeRelease(ref pQpSession);
		}
		if (IntPtr.Zero != pQpDatabase)
		{
			NativeMethods.SafeRelease(ref pQpDatabase);
		}
		if (IntPtr.Zero != pTx)
		{
			NativeMethods.SafeRelease(ref pTx);
		}
		if (IntPtr.Zero != pStoreService)
		{
			NativeMethods.SafeRelease(ref pStoreService);
		}
		if (IntPtr.Zero != pQpServices)
		{
			NativeMethods.SafeRelease(ref pQpServices);
		}
		if (IntPtr.Zero != pStoreServer)
		{
			NativeMethods.SafeRelease(ref pStoreServer);
		}
		if (IntPtr.Zero != pStoreEvents)
		{
			NativeMethods.SafeRelease(ref pStoreEvents);
		}
		if (IntPtr.Zero != pError)
		{
			NativeMethods.SafeDelete(ref pError);
		}
		if (IntPtr.Zero != pSeStore)
		{
			NativeMethods.CloseStore(pSeStore);
			NativeMethods.SafeRelease(ref pSeStore);
		}
	}

	internal void DisposeSqlCeDataRdr(SqlCeTransaction tx)
	{
		if (weakReferenceCache != null)
		{
			weakReferenceCache.CloseDataRdr(tx);
		}
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}
		if (HasDelegatedTransaction)
		{
			if (disposing)
			{
				isDisposed = true;
				state = ConnectionState.Closed;
				if (weakReferenceCache != null)
				{
					weakReferenceCache.CloseDataRdr(null);
				}
			}
			return;
		}
		if (disposing)
		{
			if (isOpened)
			{
				try
				{
					OnStateChange(ConnectionState.Open, ConnectionState.Closed);
				}
				catch (Exception ex)
				{
					if (!ADP.IsCatchableExceptionType(ex))
					{
						throw ex;
					}
				}
			}
			if (weakReferenceCache != null)
			{
				weakReferenceCache.Close(isDisposing: true);
				weakReferenceCache = null;
			}
			connStr = null;
			dataSource = null;
			modifiedConnStr = null;
			NativeMethods.DllRelease();
			isOpened = false;
			isDisposed = true;
			state = ConnectionState.Closed;
		}
		if (!isHostControlled)
		{
			ReleaseNativeInterfaces();
		}
	}

	public override void Close()
	{
		Close(silent: false);
		GC.KeepAlive(this);
	}

	internal void Zombie(SqlCeTransaction tx)
	{
		if (weakReferenceCache != null)
		{
			weakReferenceCache.Zombie(tx);
		}
	}

	private void Close(bool silent)
	{
		if (!isOpened)
		{
			return;
		}
		if (HasDelegatedTransaction)
		{
			state = ConnectionState.Closed;
			if (weakReferenceCache != null)
			{
				weakReferenceCache.CloseDataRdr(null);
			}
			return;
		}
		if (!silent)
		{
			OnStateChange(ConnectionState.Open, ConnectionState.Closed);
		}
		if (weakReferenceCache != null)
		{
			weakReferenceCache.Close(isDisposing: false);
		}
		ReleaseNativeInterfaces();
		isOpened = false;
		state = ConnectionState.Closed;
	}

	public List<KeyValuePair<string, string>> GetDatabaseInfo()
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		int locale = 0;
		CheckStateOpen("GetDatabaseInfo");
		int locale2 = NativeMethods.GetLocale(pSeStore, ref locale, pError);
		if (locale2 != 0)
		{
			ProcessResults(locale2);
		}
		list.Add(new KeyValuePair<string, string>("locale identifier", locale.ToString()));
		int encryptionMode = 0;
		locale2 = NativeMethods.GetEncryptionMode(pSeStore, ref encryptionMode, pError);
		if (locale2 != 0)
		{
			ProcessResults(locale2);
		}
		string value = null;
		switch ((ENCRYPTIONMODE)encryptionMode)
		{
		case ENCRYPTIONMODE.ENCRYPT_MODE_INVALID:
			value = string.Empty;
			break;
		case ENCRYPTIONMODE.ENCRYPT_MODE_PPC2003_COMPAT:
			value = "ppc2003 compatibility";
			break;
		case ENCRYPTIONMODE.ENCRYPT_MODE_ENGINE_DEFAULT:
			value = "engine default";
			break;
		}
		list.Add(new KeyValuePair<string, string>("encryption mode", value));
		int sortFlags = 0;
		locale2 = NativeMethods.GetLocaleFlags(pSeStore, ref sortFlags, pError);
		if (locale2 != 0)
		{
			ProcessResults(locale2);
		}
		string text = null;
		text = ((1 != (sortFlags & 1)) ? bool.TrueString : bool.FalseString);
		list.Add(new KeyValuePair<string, string>("case sensitive", text));
		return list;
	}

	public new SqlCeTransaction BeginTransaction(IsolationLevel isolationLevel)
	{
		int num = 0;
		if (HasDelegatedTransaction)
		{
			throw new InvalidOperationException(Res.GetString("ADP_ParallelTransactionsNotSupported", GetType().Name));
		}
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		CheckStateOpen("BeginTransaction");
		SEISOLATION isoLevel;
		switch (isolationLevel)
		{
		case IsolationLevel.Unspecified:
		case IsolationLevel.ReadCommitted:
			isoLevel = SEISOLATION.ISO_READ_COMMITTED;
			break;
		case IsolationLevel.RepeatableRead:
			isoLevel = SEISOLATION.ISO_REPEATABLE_READ;
			break;
		case IsolationLevel.Serializable:
			isoLevel = SEISOLATION.ISO_SERIALIZABLE;
			break;
		default:
			throw new ArgumentException(Res.GetString("ADP_InvalidIsolationLevel", isolationLevel.ToString()));
		}
		SqlCeTransaction sqlCeTransaction = null;
		IntPtr ppUnknown = IntPtr.Zero;
		IntPtr ppUnknown2 = IntPtr.Zero;
		try
		{
			num = NativeMethods.OpenTransaction(pSeStore, pQpDatabase, isoLevel, ref ppUnknown, ref ppUnknown2, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			sqlCeTransaction = new SqlCeTransaction(this, isolationLevel, ppUnknown, ppUnknown2);
			AddWeakReference(sqlCeTransaction);
			return sqlCeTransaction;
		}
		catch (Exception ex)
		{
			if (IntPtr.Zero != ppUnknown2)
			{
				NativeMethods.SafeRelease(ref ppUnknown2);
			}
			if (IntPtr.Zero != ppUnknown)
			{
				NativeMethods.SafeRelease(ref ppUnknown);
			}
			throw ex;
		}
	}

	protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
	{
		return BeginTransaction(isolationLevel);
	}

	public new SqlCeTransaction BeginTransaction()
	{
		return BeginTransaction(IsolationLevel.ReadCommitted);
	}

	public override void ChangeDatabase(string value)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		CheckStateOpen("ChangeDatabase");
		if (value == null || value.Trim().Length == 0)
		{
			throw new ArgumentException(Res.GetString("ADP_EmptyDatabaseName"));
		}
		string text = dataSource;
		try
		{
			dataSource = value;
			Close(silent: true);
			Open(silent: true);
		}
		catch (Exception ex)
		{
			dataSource = text;
			throw ex;
		}
	}

	internal void CheckStateOpen(string method)
	{
		if (ConnectionState.Open != State)
		{
			string name = null;
			switch (method)
			{
			case "BeginTransaction":
				name = "ADP_OpenConnectionRequired_BeginTransaction";
				break;
			case "ChangeDatabase":
				name = "ADP_OpenConnectionRequired_ChangeDatabase";
				break;
			case "CommitTransaction":
				name = "ADP_OpenConnectionRequired_CommitTransaction";
				break;
			case "RollbackTransaction":
				name = "ADP_OpenConnectionRequired_RollbackTransaction";
				break;
			case "set_Connection":
				name = "ADP_OpenConnectionRequired_SetConnection";
				break;
			case "GetDatabaseInfo":
				name = "ADP_OpenConnectionRequired_GetDatabaseInfo";
				break;
			}
			throw new InvalidOperationException(Res.GetString(name, method, State));
		}
	}

	internal void AddWeakReference(object value)
	{
		if (isDisposed || weakReferenceCache == null)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		weakReferenceCache.Add(value);
	}

	internal void RemoveWeakReference(object value)
	{
		if (weakReferenceCache == null)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		weakReferenceCache.Remove(value);
	}

	internal bool HasOpenedCursors(SqlCeTransaction tx)
	{
		if (weakReferenceCache != null)
		{
			return weakReferenceCache.HasOpenedCursors(tx);
		}
		return false;
	}

	protected override DbCommand CreateDbCommand()
	{
		return CreateCommand();
	}

	public new SqlCeCommand CreateCommand()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		return new SqlCeCommand("", this);
	}

	private void OnStateChange(ConnectionState original, ConnectionState state)
	{
		StateChangeEventHandler stateChangeEventHandler = (StateChangeEventHandler)Events[ADP.EventStateChange];
		if (stateChangeEventHandler == null)
		{
			return;
		}
		try
		{
			stateChangeEventHandler(this, new StateChangeEventArgs(original, state));
		}
		catch (Exception ex)
		{
			if (!ADP.IsCatchableExceptionType(ex))
			{
				throw ex;
			}
		}
	}

	public override void Open()
	{
		if (HasDelegatedTransaction)
		{
			throw new InvalidOperationException(Res.GetString("ADP_ConnectionNotEnlisted"));
		}
		Open(silent: false);
		if (!IsEnlisted || !(null != System.Transactions.Transaction.Current))
		{
			return;
		}
		try
		{
			Enlist(System.Transactions.Transaction.Current);
			SqlCeDelegatedTransaction delegatedTransaction = DelegatedTransaction;
			for (int i = 0; i < weakReferenceCache.Count; i++)
			{
				object obj = weakReferenceCache.GetObject(i);
				if (obj is SqlCeCommand)
				{
					((SqlCeCommand)obj).Transaction = delegatedTransaction.SqlCeTransaction;
				}
			}
		}
		catch
		{
			Close();
			throw;
		}
	}

	internal unsafe void Open(bool silent)
	{
		int num = 0;
		int lcidLocale = -1;
		int cbBufferPool = -1;
		int dwAutoShrinkPercent = -1;
		int cMaxPages = -1;
		int cMaxTmpPages = -1;
		int dwDefaultEscalation = -1;
		int dwDefaultTimeout = -1;
		int dwFlushInterval = -1;
		object obj = null;
		string source = null;
		string source2 = null;
		string value = null;
		SEOPENFLAGS dwFlags = SEOPENFLAGS.MODE_READ | SEOPENFLAGS.MODE_WRITE;
		bool flag = false;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeConnection");
		}
		if (ConnectionString == null || ConnectionString.Length == 0)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
		}
		if (dataSource == null || dataSource.Trim().Length == 0)
		{
			throw new ArgumentException(Res.GetString("ADP_EmptyDatabaseName"));
		}
		if (isOpened)
		{
			throw new InvalidOperationException(Res.GetString("ADP_ConnectionAlreadyOpen", ConnectionState.Open.ToString()));
		}
		MEOPENINFO mEOPENINFO = default;
		IntPtr intPtr = NativeMethods.CoTaskMemAlloc(sizeof(MEOPENINFO));
		if (IntPtr.Zero == intPtr)
		{
			throw new OutOfMemoryException();
		}
		try
		{
			if (ADP.IsEmpty(modifiedConnStr))
			{
				throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
			}
			obj = connTokens["locale identifier"];
			if (obj != null)
			{
				lcidLocale = (int)obj;
			}
			obj = connTokens["ssce:max buffer size"];
			if (obj != null)
			{
				cbBufferPool = (int)obj * 1024;
			}
			obj = connTokens["ssce:autoshrink threshold"];
			if (obj != null)
			{
				dwAutoShrinkPercent = (int)obj;
			}
			obj = connTokens["ssce:max database size"];
			if (obj != null)
			{
				cMaxPages = (int)obj * 256;
			}
			obj = connTokens["ssce:temp file max size"];
			if (obj != null)
			{
				cMaxTmpPages = (int)obj * 256;
			}
			obj = connTokens["ssce:flush interval"];
			if (obj != null)
			{
				dwFlushInterval = (int)obj;
			}
			obj = connTokens["ssce:default lock escalation"];
			if (obj != null)
			{
				dwDefaultEscalation = (int)obj;
			}
			obj = connTokens["ssce:default lock timeout"];
			if (obj != null)
			{
				dwDefaultTimeout = (int)obj;
			}
			obj = connTokens["ssce:temp file directory"];
			if (obj != null)
			{
				source2 = (string)obj;
			}
			obj = connTokens["ssce:encryption mode"];
			if (obj != null)
			{
				value = (string)obj;
			}
			obj = connTokens["ssce:database password"];
			if (obj != null)
			{
				string text = (string)obj;
				if (text.Length > 0)
				{
					source = text;
				}
			}
			obj = connTokens["ssce:case sensitive"];
			if (obj != null)
			{
				flag = (bool)obj;
			}
			string text2 = null;
			obj = connTokens["ssce:mode"];
			if (obj != null)
			{
				text2 = (string)obj;
			}
			if (text2 != null)
			{
				switch (text2.ToLower(CultureInfo.CurrentCulture))
				{
				case "read only":
					dwFlags = SEOPENFLAGS.MODE_READ;
					break;
				case "read write":
					dwFlags = SEOPENFLAGS.MODE_READ | SEOPENFLAGS.MODE_WRITE;
					break;
				case "exclusive":
					dwFlags = SEOPENFLAGS.MODE_READ | SEOPENFLAGS.MODE_WRITE | SEOPENFLAGS.MODE_SHARE_DENY_READ | SEOPENFLAGS.MODE_SHARE_DENY_WRITE;
					break;
				case "shared read":
					dwFlags = SEOPENFLAGS.MODE_READ | SEOPENFLAGS.MODE_WRITE | SEOPENFLAGS.MODE_SHARE_DENY_WRITE;
					break;
				}
			}
			mEOPENINFO.pwszFileName = NativeMethods.MarshalStringToLPWSTR(dataSource);
			mEOPENINFO.pwszPassword = NativeMethods.MarshalStringToLPWSTR(source);
			mEOPENINFO.pwszTempPath = NativeMethods.MarshalStringToLPWSTR(source2);
			mEOPENINFO.lcidLocale = lcidLocale;
			mEOPENINFO.cbBufferPool = cbBufferPool;
			mEOPENINFO.dwAutoShrinkPercent = dwAutoShrinkPercent;
			mEOPENINFO.dwFlushInterval = dwFlushInterval;
			mEOPENINFO.cMaxPages = cMaxPages;
			mEOPENINFO.cMaxTmpPages = cMaxTmpPages;
			mEOPENINFO.dwDefaultTimeout = dwDefaultTimeout;
			mEOPENINFO.dwDefaultEscalation = dwDefaultEscalation;
			mEOPENINFO.dwFlags = dwFlags;
			mEOPENINFO.dwEncryptionMode = ConStringUtil.MapEncryptionMode(value);
			mEOPENINFO.dwLocaleFlags = 0;
			if (flag)
			{
				mEOPENINFO.dwLocaleFlags &= 1;
			}
			flushFailureEventHandler = OnFlushFailure;
			Marshal.StructureToPtr((object)mEOPENINFO, intPtr, false);
			num = NativeMethods.OpenStore(intPtr, Marshal.GetFunctionPointerForDelegate((Delegate)flushFailureEventHandler), ref pStoreService, ref pStoreServer, ref pQpServices, ref pSeStore, ref pTx, ref pQpDatabase, ref pQpSession, ref pStoreEvents, ref pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			removePwd = true;
			state = ConnectionState.Open;
			isOpened = true;
		}
		finally
		{
			NativeMethods.CoTaskMemFree(mEOPENINFO.pwszFileName);
			NativeMethods.CoTaskMemFree(mEOPENINFO.pwszPassword);
			NativeMethods.CoTaskMemFree(mEOPENINFO.pwszTempPath);
			NativeMethods.CoTaskMemFree(intPtr);
			if (ConnectionState.Open != state)
			{
				Close();
				removePwd = false;
				state = ConnectionState.Closed;
			}
		}
		if (!silent)
		{
			OnStateChange(ConnectionState.Closed, ConnectionState.Open);
		}
	}

	private static void CachedConnectionStringAdd(string connStr, string modifiedConnStr, Hashtable connTokens)
	{
		Hashtable hashtable = connStrCache;
		lock (typeof(SqlCeConnection))
		{
			if (hashtable == null)
			{
				hashtable = new Hashtable();
				hashtable[connStr] = new object[2] { modifiedConnStr, connTokens };
				connStrCache = hashtable;
				return;
			}
		}
		lock (hashtable.SyncRoot)
		{
			if (!hashtable.Contains(connStr))
			{
				if (hashtable.Count < 250)
				{
					hashtable[connStr] = new object[2] { modifiedConnStr, connTokens };
				}
				else
				{
					connStrCache = null;
				}
			}
		}
	}

	private void ProcessResults(int hr)
	{
		Exception ex = ProcessResults(hr, pError, this);
		if (ex != null)
		{
			throw ex;
		}
	}

	internal SqlCeException ProcessResults(int hr, IntPtr pError, object src)
	{
		if (hr == 0)
		{
			return null;
		}
		if (NativeMethods.Failed(hr))
		{
			return SqlCeException.FillErrorInformation(hr, pError);
		}
		if ((object)Events[ADP.EventInfoMessage] != null)
		{
			SqlCeInfoMessageEventHandler sqlCeInfoMessageEventHandler = (SqlCeInfoMessageEventHandler)Events[ADP.EventInfoMessage];
			if (sqlCeInfoMessageEventHandler != null)
			{
				try
				{
					sqlCeInfoMessageEventHandler(this, new SqlCeInfoMessageEventArgs(hr, pError, src));
				}
				catch (Exception ex)
				{
					if (!ADP.IsCatchableExceptionType(ex))
					{
						throw ex;
					}
				}
			}
		}
		else
		{
			NativeMethods.ClearErrorInfo(pError);
		}
		return null;
	}
}
