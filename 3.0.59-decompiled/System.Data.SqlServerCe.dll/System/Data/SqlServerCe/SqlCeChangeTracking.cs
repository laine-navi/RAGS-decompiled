using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System.Data.SqlServerCe;

public sealed class SqlCeChangeTracking : IDisposable
{
	private object thisLock = new object();

	private IntPtr pTracking;

	private IntPtr pError;

	private SqlCeTransaction m_transaction;

	private SqlCeConnection m_connection;

	private bool isFinalized;

	private static int trackingOptionsMask = 16;

	private TrackingVersion iTrackingVersion;

	private bool hasLocalTransaction;

	private string m_tableName;

	private List<string> m_primaryKeyColumns;

	private Dictionary<string, byte> m_numericPrecisions;

	private SqlCeTableColumns m_tableColumns;

	private TrackingKeyType m_keyType;

	private SqlCeConnection Connection
	{
		get
		{
			if (m_connection != null)
			{
				return m_connection;
			}
			if (m_transaction != null)
			{
				return (SqlCeConnection)m_transaction.Connection;
			}
			return null;
		}
	}

	[Obsolete("Obsolete method. Not to be used")]
	internal long CurrentTxBsn
	{
		get
		{
			bool fCommit = true;
			int num = InitChangeTracking(ref pTracking, ref pError);
			long txBsn = 0L;
			try
			{
				if (num != 0)
				{
					ProcessResults(num);
				}
				VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
				NativeMethods.GetCurrentTrackingTxBsn(pTracking, ref txBsn, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			catch (Exception)
			{
				fCommit = false;
				throw;
			}
			finally
			{
				num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			return txBsn;
		}
	}

	[Obsolete("Obsolete method. Use the new, public method GetLastCommittedCsn() instead")]
	internal long CurrentTxCsn
	{
		get
		{
			bool fCommit = true;
			int num = InitChangeTracking(ref pTracking, ref pError);
			long txCsn = 0L;
			try
			{
				if (num != 0)
				{
					ProcessResults(num);
				}
				VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
				num = NativeMethods.GetCurrentTrackingTxCsn(pTracking, ref txCsn, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			catch (Exception)
			{
				fCommit = false;
				throw;
			}
			finally
			{
				num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			return txCsn;
		}
	}

	internal TrackingVersion DetectTrackingType()
	{
		iTrackingVersion = TrackingVersion.Unknown;
		if (!TableExists("__sysOCSTrackedObjects"))
		{
			return iTrackingVersion;
		}
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.Transaction = m_transaction;
		sqlCeCommand.CommandText = "select count(*) from __sysOCSTrackedObjects";
		if ((int)sqlCeCommand.ExecuteScalar() == 0)
		{
			sqlCeCommand.Dispose();
			return iTrackingVersion;
		}
		sqlCeCommand.CommandText = "select count(*) from __sysOCSTrackedObjects where __sysTrackOpt > 0xf";
		if ((int)sqlCeCommand.ExecuteScalar() == 0)
		{
			iTrackingVersion = TrackingVersion.TypeV1;
			sqlCeCommand.Dispose();
			return iTrackingVersion;
		}
		sqlCeCommand.CommandText = "select count(*) from __sysOCSTrackedObjects where __sysTrackOpt = 0xf";
		if ((int)sqlCeCommand.ExecuteScalar() == 0)
		{
			iTrackingVersion = TrackingVersion.TypeV2;
			sqlCeCommand.Dispose();
			return iTrackingVersion;
		}
		sqlCeCommand.Dispose();
		ProcessResults(30001);
		return iTrackingVersion;
	}

	internal void VersionCheck(ref TrackingVersion iCurrentVersion, TrackingVersion tSupportedVersion, TrackingVersion tUnsupportedVersion)
	{
		if (iCurrentVersion == tUnsupportedVersion)
		{
			ProcessResults(30001);
		}
		if (iCurrentVersion == TrackingVersion.Unknown)
		{
			iCurrentVersion = tSupportedVersion;
		}
	}

	private void ProcessResults(int hr)
	{
		switch (hr)
		{
		case 30001:
			throw new InvalidOperationException(Res.GetString("SQLCE_WrongTrackingVersion"));
		case 30002:
			throw new InvalidOperationException(Res.GetString("SQLCE_WrongCleanupSequence"));
		}
		if (Connection != null)
		{
			Exception ex = ((Connection != null) ? Connection.ProcessResults(hr, pError, this) : null);
			if (ex != null)
			{
				throw ex;
			}
			return;
		}
		throw new NullReferenceException("Connection");
	}

	public SqlCeChangeTracking(SqlCeTransaction transaction)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("Transaction");
		}
		if (transaction.Connection == null)
		{
			throw new ArgumentException("Connection");
		}
		if (ConnectionState.Open != transaction.Connection.State)
		{
			throw new InvalidOperationException(Res.GetString("ADP_OpenConnectionRequired_Prepare", "SqlCeChangeTracking", transaction.Connection.State));
		}
		if (transaction.IsZombied)
		{
			throw new InvalidOperationException(Res.GetString("ADP_TransactionZombied", "Transaction"));
		}
		isFinalized = false;
		transaction.SetTrackingObject(this);
		NativeMethods.LoadNativeBinaries();
		int num = NativeMethods.InitChangeTracking(transaction.ITransact, ref pTracking, ref pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
		m_transaction = transaction;
		Connection.AddWeakReference(this);
		m_connection = null;
		hasLocalTransaction = false;
		DetectTrackingType();
	}

	private int InitChangeTracking(ref IntPtr pTracking, ref IntPtr pError)
	{
		if (!hasLocalTransaction)
		{
			if (m_transaction == null || m_transaction.IsZombied)
			{
				throw new InvalidOperationException(Res.GetString("ADP_TransactionZombied", "Transaction"));
			}
			return 0;
		}
		SqlCeTransaction sqlCeTransaction = Connection.BeginTransaction();
		int num = NativeMethods.InitChangeTracking(sqlCeTransaction.ITransact, ref pTracking, ref pError);
		if (num == 0)
		{
			m_transaction = sqlCeTransaction;
		}
		return num;
	}

	private int ExitChangeTracking(ref IntPtr pTracking, ref IntPtr pError, bool fCommit)
	{
		if (!hasLocalTransaction)
		{
			return 0;
		}
		int result = NativeMethods.ExitChangeTracking(ref pTracking, ref pError);
		if (m_transaction != null && !m_transaction.IsZombied)
		{
			if (fCommit)
			{
				m_transaction.Commit();
			}
			else
			{
				m_transaction.Rollback();
			}
			m_transaction.Dispose();
			m_transaction = null;
		}
		return result;
	}

	public SqlCeChangeTracking(SqlCeConnection connection)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("Connection");
		}
		if (ConnectionState.Open != connection.State)
		{
			throw new InvalidOperationException(Res.GetString("ADP_OpenConnectionRequired_Prepare", "SqlCeChangeTracking", connection.State));
		}
		m_connection = connection;
		isFinalized = false;
		NativeMethods.LoadNativeBinaries();
		Connection.AddWeakReference(this);
		hasLocalTransaction = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
		DetectTrackingType();
		num = ExitChangeTracking(ref pTracking, ref pError, fCommit: true);
		if (num != 0)
		{
			ProcessResults(num);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~SqlCeChangeTracking()
	{
		Dispose(disposing: false);
	}

	public void Dispose(bool disposing)
	{
		lock (thisLock)
		{
			if (isFinalized)
			{
				return;
			}
			if (IntPtr.Zero != pTracking || IntPtr.Zero != pError)
			{
				int num = NativeMethods.ExitChangeTracking(ref pTracking, ref pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			if (disposing && Connection != null)
			{
				Connection.RemoveWeakReference(this);
				if (m_transaction != null)
				{
					m_transaction.SetTrackingObject(null);
				}
				hasLocalTransaction = false;
				m_transaction = null;
			}
			if (!disposing)
			{
				isFinalized = true;
			}
		}
	}

	[Obsolete("Obsolete method. Use the new, public EnableTracking method instead")]
	internal void EnableTracking(string tableName, SETRACKINGTYPE trackType, SEOCSTRACKOPTIONS trackOpts)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
			num = NativeMethods.EnableChangeTracking(pTracking, tableName, trackType, trackOpts, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	public void EnableTracking(string tableName, TrackingKeyType trackingKeyType, TrackingOptions trackingOptions)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
			if (trackingOptions <= TrackingOptions.None || trackingOptions >= TrackingOptions.Max)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "trackingOptions", 0, 7));
			}
			if (trackingKeyType <= TrackingKeyType.None || trackingKeyType >= TrackingKeyType.Max)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "trackingKeyType", 0, 2));
			}
			num = NativeMethods.EnableChangeTracking(pTracking, tableName, (SETRACKINGTYPE)trackingKeyType, (SEOCSTRACKOPTIONS)((int)trackingOptions * trackingOptionsMask), pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	public bool GetTrackingOptions(string tableName, out TrackingOptions trackingOptions)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
			SEOCSTRACKOPTIONSV2 iTrackingOptions = SEOCSTRACKOPTIONSV2.NONE;
			num = 0;
			trackingOptions = TrackingOptions.None;
			num = NativeMethods.GetTrackingOptions(pTracking, tableName, ref iTrackingOptions, pError);
			try
			{
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			catch (SqlCeException ex)
			{
				if (ex != null && ex.Errors != null && ex.Errors.Count == 1 && ex.Errors[0].NativeError == 28543)
				{
					return false;
				}
				throw;
			}
			trackingOptions = (TrackingOptions)((int)iTrackingOptions / trackingOptionsMask);
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		return true;
	}

	public void DisableTracking(string tableName)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			num = NativeMethods.DisableChangeTracking(pTracking, tableName, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	[Obsolete("Obsolete method. Use the new, public GetTrackingOptions method instead")]
	internal bool IsTableTracked(string tableName)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		bool fTableTracked = false;
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
			num = NativeMethods.IsTableChangeTracked(pTracking, tableName, ref fTableTracked, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		return fTableTracked;
	}

	[Obsolete("Obsolete method. Use the new, public GetTrackingOptions method instead")]
	internal SETRACKINGTYPE GetTrackingType(string tableName)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		SETRACKINGTYPE trackType = SETRACKINGTYPE.INVALID;
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
			SEOCSTRACKOPTIONS trackOptions = SEOCSTRACKOPTIONS.NONE;
			long trackOrdinal = 0L;
			num = NativeMethods.GetChangeTrackingInfo(pTracking, tableName, ref trackOptions, ref trackType, ref trackOrdinal, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		return trackType;
	}

	public void PurgeTombstoneTableData(string tableName, PurgeType pType, long retentionValue)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			if (retentionValue < 0)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "retentionValue", 0u, uint.MaxValue));
			}
			if (pType <= PurgeType.None || pType >= PurgeType.Max)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "pType", 0, 2));
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
			num = ((pType != PurgeType.TimeBased) ? NativeMethods.CleanupTombstoneData(pTracking, tableName, 0, retentionValue, pError) : NativeMethods.CleanupTombstoneData(pTracking, tableName, (int)retentionValue, 0L, pError));
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	private void CheckIfDataIsPresentInTombstone(long retentionValue, PurgeType pType)
	{
		if (Connection == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
		}
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.Transaction = m_transaction;
		if (pType == PurgeType.CsnBased)
		{
			sqlCeCommand.CommandText = "select count(*) from __sysOCSDeletedRows where __sysDeleteTxBsn in  (select __sysTxBsn from __sysTxCommitSequence where __sysTxCsn >= 0 and __sysTxCsn < @RETENTION_VALUE ) or  (__sysDeleteTxBsn not in (select __sysTxBsn from __sysTxCommitSequence) and  __sysDeleteTxBsn < @RETENTION_VALUE )";
			sqlCeCommand.Parameters.Clear();
			sqlCeCommand.Parameters.AddWithValue("@RETENTION_VALUE", retentionValue);
		}
		else
		{
			sqlCeCommand.CommandText = "select count(*) from __sysOCSDeletedRows where __sysDeletedTime < @RETENTION_DATE";
			sqlCeCommand.Parameters.Clear();
			sqlCeCommand.Parameters.AddWithValue("@RETENTION_DATE", DateTime.Now.AddDays((int)(-retentionValue)));
		}
		object obj = sqlCeCommand.ExecuteScalar();
		sqlCeCommand.Dispose();
		if (!obj.ToString().Equals("0"))
		{
			ProcessResults(30002);
		}
	}

	public void PurgeTransactionSequenceData(PurgeType pType, long retentionValue)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
			if (retentionValue < 0)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "retentionValue", 0u, uint.MaxValue));
			}
			if (pType <= PurgeType.None || pType >= PurgeType.Max)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_ArgumentOutOfRange", "pType", 0, 2));
			}
			CheckIfDataIsPresentInTombstone(retentionValue, pType);
			num = ((pType != PurgeType.TimeBased) ? NativeMethods.CleanupTransactionData(pTracking, 0, retentionValue, pError) : NativeMethods.CleanupTransactionData(pTracking, (int)retentionValue, 0L, pError));
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	public long GetLastCommittedCsn()
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		long txCsn = 0L;
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
			num = NativeMethods.GetCurrentTrackingTxCsn(pTracking, ref txCsn, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		return txCsn - 1;
	}

	[Obsolete("Obsolete method. Use the new, public Purge methods instead")]
	internal void CleanupMetadata(string tableName, int retentionPeriod, long cutOffTxCsn, long leastTxCsn)
	{
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV1, TrackingVersion.TypeV2);
			num = NativeMethods.CleanupTrackingMetadata(pTracking, tableName, retentionPeriod, cutOffTxCsn, leastTxCsn, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
	}

	internal byte GetPrecision(string tableName, string columnName)
	{
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.CommandText = "select numeric_precision from information_schema.columns where table_name = @TABLE_NAME and column_name = @COLUMN_NAME";
		sqlCeCommand.Parameters.Clear();
		sqlCeCommand.Parameters.AddWithValue("@TABLE_NAME", tableName);
		sqlCeCommand.Parameters.AddWithValue("@COLUMN_NAME", columnName);
		object obj = sqlCeCommand.ExecuteScalar();
		sqlCeCommand.Dispose();
		return (byte)(short)obj;
	}

	internal TrackingKeyType GetTrackingKeyType(string tableName)
	{
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.CommandText = "select __sysTrackType from __sysOCSTrackedObjects where __sysTName = @TABLE_NAME ";
		sqlCeCommand.Parameters.Clear();
		sqlCeCommand.Parameters.AddWithValue("@TABLE_NAME", tableName);
		object obj = sqlCeCommand.ExecuteScalar();
		sqlCeCommand.Dispose();
		if ((int)obj == 1)
		{
			return TrackingKeyType.PrimaryKey;
		}
		if ((int)obj == 2)
		{
			return TrackingKeyType.Guid;
		}
		throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "trackingKeyType", 0, 2));
	}

	internal bool TableExists(string tableName)
	{
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.Transaction = m_transaction;
		sqlCeCommand.CommandText = "select count(*) from information_schema.tables where table_name = @TABLE_NAME";
		sqlCeCommand.Parameters.Clear();
		sqlCeCommand.Parameters.AddWithValue("@TABLE_NAME", tableName);
		int num = (int)sqlCeCommand.ExecuteScalar();
		sqlCeCommand.Dispose();
		if (num > 0)
		{
			return true;
		}
		return false;
	}

	internal bool SystemCommandExecuteNonQuery(string commandText)
	{
		SqlCeCommand sqlCeCommand = null;
		SeTransactionFlags engineFlags = SeTransactionFlags.NOFLAGS;
		bool fCommit = true;
		int num = InitChangeTracking(ref pTracking, ref pError);
		try
		{
			if (num != 0)
			{
				ProcessResults(num);
			}
			sqlCeCommand = Connection.CreateCommand();
			sqlCeCommand.CommandText = commandText;
			sqlCeCommand.Transaction = m_transaction;
			engineFlags = m_transaction.EngineFlags;
			m_transaction.EngineFlags |= SeTransactionFlags.SYSTEM;
			sqlCeCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
			fCommit = false;
			throw;
		}
		finally
		{
			m_transaction.EngineFlags = engineFlags;
			sqlCeCommand?.Dispose();
			num = ExitChangeTracking(ref pTracking, ref pError, fCommit);
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		return true;
	}

	public static bool UpgradePublicTracking(string connectionString)
	{
		if (connectionString == null)
		{
			throw new ArgumentNullException("connectionString");
		}
		SqlCeConnection sqlCeConnection = null;
		SqlCeTransaction sqlCeTransaction = null;
		SqlCeChangeTracking sqlCeChangeTracking = null;
		SqlCeCommand sqlCeCommand = null;
		SqlCeCommand sqlCeCommand2 = null;
		SqlCeDataReader sqlCeDataReader = null;
		bool flag = true;
		try
		{
			sqlCeConnection = new SqlCeConnection(connectionString);
			sqlCeConnection.Open();
			sqlCeTransaction = sqlCeConnection.BeginTransaction();
			sqlCeChangeTracking = new SqlCeChangeTracking(sqlCeTransaction);
			if (!sqlCeChangeTracking.TableExists("__sysOCSTrackedObjects"))
			{
				return true;
			}
			bool flag2 = false;
			sqlCeCommand = sqlCeConnection.CreateCommand();
			sqlCeCommand.CommandText = "select __sysTName, __sysTrackType, __sysTrackOpt, __sysTrackColOrd from __sysOCSTrackedObjects";
			sqlCeCommand.Transaction = sqlCeTransaction;
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			object[] array = new object[4];
			while (sqlCeDataReader.Read())
			{
				flag2 = true;
				sqlCeDataReader.GetValues(array);
				flag = flag && sqlCeChangeTracking.SystemCommandExecuteNonQuery("update __sysOCSTrackedObjects set __sysTrackOpt = 0x70 where __sysTrackOpt = 0xf and __sysTName = '" + (string)array[0] + "'");
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeDataReader = null;
			sqlCeCommand.Dispose();
			sqlCeCommand = null;
			if (!flag2)
			{
				if (sqlCeChangeTracking.TableExists("__sysSyncArticles"))
				{
					sqlCeChangeTracking.SystemCommandExecuteNonQuery("drop table __sysSyncArticles");
				}
				if (sqlCeChangeTracking.TableExists("__sysSyncSubscriptions"))
				{
					sqlCeChangeTracking.SystemCommandExecuteNonQuery("drop table __sysSyncSubscriptions");
				}
				return true;
			}
			sqlCeCommand = sqlCeConnection.CreateCommand();
			sqlCeCommand.CommandText = "select table_name from information_schema.tables where table_name in (select table_name from information_schema.columns where column_name = '__sysTrackingContext') and table_name <> '__sysOCSDeletedRows' and table_name not in (select __sysTName from __sysOCSTrackedObjects)";
			sqlCeCommand.Transaction = sqlCeTransaction;
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			array = new object[1];
			while (sqlCeDataReader.Read())
			{
				sqlCeDataReader.GetValues(array);
				flag = flag && sqlCeChangeTracking.SystemCommandExecuteNonQuery("alter table " + (string)array[0] + " drop column __sysTrackingContext");
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeDataReader = null;
			sqlCeCommand.Dispose();
			sqlCeCommand = null;
			if (sqlCeChangeTracking.TableExists("__sysSyncSubscriptions"))
			{
				if (!sqlCeChangeTracking.TableExists("__syncSubscriptions"))
				{
					sqlCeCommand2 = sqlCeConnection.CreateCommand();
					sqlCeCommand2.CommandText = "CREATE TABLE __syncSubscriptions (ClientId uniqueidentifier NOT NULL, ServerId uniqueidentifier NOT NULL, MachineId uniqueidentifier NOT NULL, CONSTRAINT __syncSubscriptions_PK PRIMARY KEY(ClientId));";
					sqlCeCommand2.Transaction = sqlCeTransaction;
					sqlCeCommand2.ExecuteNonQuery();
				}
				sqlCeCommand = sqlCeConnection.CreateCommand();
				sqlCeCommand.Transaction = sqlCeTransaction;
				sqlCeCommand.CommandText = "select * from __sysSyncSubscriptions";
				sqlCeDataReader = sqlCeCommand.ExecuteReader();
				array = new object[sqlCeDataReader.FieldCount];
				while (sqlCeDataReader.Read())
				{
					sqlCeDataReader.GetValues(array);
					sqlCeCommand2.Parameters.Clear();
					sqlCeCommand2.CommandText = "insert into __syncSubscriptions (ClientID, ServerId, MachineId) values (@CID, @SID, @MID)";
					sqlCeCommand2.Parameters.AddWithValue("@CID", array[0]);
					sqlCeCommand2.Parameters.AddWithValue("@SID", array[1]);
					sqlCeCommand2.Parameters.AddWithValue("@MID", array[2]);
					sqlCeCommand2.ExecuteNonQuery();
				}
				sqlCeCommand2.Parameters.Clear();
				sqlCeCommand2.Dispose();
				sqlCeCommand2 = null;
				sqlCeDataReader.Close();
				sqlCeDataReader.Dispose();
				sqlCeDataReader = null;
				sqlCeCommand.Dispose();
				sqlCeCommand = null;
			}
			if (sqlCeChangeTracking.TableExists("__sysSyncArticles"))
			{
				if (!sqlCeChangeTracking.TableExists("__syncArticles"))
				{
					sqlCeCommand2 = sqlCeConnection.CreateCommand();
					sqlCeCommand2.CommandText = "CREATE TABLE __syncArticles (TableName nvarchar(128) NOT NULL, SentAnchor image, ReceivedAnchor image, ClientId uniqueidentifier NOT NULL, CONSTRAINT __syncArticles_PK PRIMARY KEY (TableName), CONSTRAINT __syncArticles_FK FOREIGN KEY (ClientId) REFERENCES __syncSubscriptions (ClientId) ON DELETE CASCADE ON UPDATE CASCADE);";
					sqlCeCommand2.Transaction = sqlCeTransaction;
					sqlCeCommand2.ExecuteNonQuery();
				}
				sqlCeCommand = sqlCeConnection.CreateCommand();
				sqlCeCommand.Transaction = sqlCeTransaction;
				sqlCeCommand.CommandText = "select * from __sysSyncArticles";
				sqlCeDataReader = sqlCeCommand.ExecuteReader();
				array = new object[sqlCeDataReader.FieldCount];
				while (sqlCeDataReader.Read())
				{
					sqlCeDataReader.GetValues(array);
					sqlCeCommand2.Parameters.Clear();
					sqlCeCommand2.CommandText = "insert into __syncArticles (TableName, SentAnchor, ReceivedAnchor, ClientID) values (@TN, @SA, @RA, @CID)";
					sqlCeCommand2.Parameters.AddWithValue("@TN", array[0]);
					sqlCeCommand2.Parameters.AddWithValue("@SA", array[1]);
					sqlCeCommand2.Parameters.AddWithValue("@RA", array[2]);
					sqlCeCommand2.Parameters.AddWithValue("@CID", array[3]);
					sqlCeCommand2.ExecuteNonQuery();
				}
				sqlCeCommand2.Parameters.Clear();
				sqlCeCommand2.Dispose();
				sqlCeCommand2 = null;
				sqlCeDataReader.Close();
				sqlCeDataReader.Dispose();
				sqlCeDataReader = null;
				sqlCeCommand.Dispose();
				sqlCeCommand = null;
			}
			if (sqlCeChangeTracking.TableExists("__sysSyncArticles"))
			{
				sqlCeChangeTracking.SystemCommandExecuteNonQuery("drop table __sysSyncArticles");
			}
			if (sqlCeChangeTracking.TableExists("__sysSyncSubscriptions"))
			{
				sqlCeChangeTracking.SystemCommandExecuteNonQuery("drop table __sysSyncSubscriptions");
			}
		}
		catch (Exception)
		{
			flag = false;
		}
		finally
		{
			if (sqlCeDataReader != null)
			{
				sqlCeDataReader.Close();
				sqlCeDataReader.Dispose();
			}
			if (sqlCeCommand2 != null)
			{
				sqlCeCommand2.Parameters.Clear();
				sqlCeCommand2.Dispose();
			}
			sqlCeCommand?.Dispose();
			sqlCeChangeTracking.Dispose();
			if (flag)
			{
				sqlCeTransaction.Commit();
			}
			else
			{
				sqlCeTransaction.Rollback();
			}
			sqlCeTransaction.Dispose();
			sqlCeConnection.Close();
			sqlCeConnection.Dispose();
		}
		return flag;
	}

	public byte[] PackTombstoneKey(string tableName, object[] columnValues)
	{
		VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
		if (tableName == null)
		{
			throw new ArgumentNullException("tableName");
		}
		if (columnValues == null || columnValues.Length == 0)
		{
			throw new ArgumentNullException("columnValues");
		}
		if (!tableName.Equals(m_tableName))
		{
			if (!TableExists(tableName))
			{
				throw new ArgumentException(Res.GetString("SQLCE_NoTable", tableName));
			}
			m_tableColumns = ADP.GetTableColumns(tableName, Connection);
			m_keyType = GetTrackingKeyType(tableName);
			m_tableName = tableName;
			string tableRowGuidColumn = ADP.GetTableRowGuidColumn(tableName, Connection);
			if (m_keyType == TrackingKeyType.Guid)
			{
				m_primaryKeyColumns = new List<string>(1);
				m_primaryKeyColumns.Add(tableRowGuidColumn);
			}
			else
			{
				m_primaryKeyColumns = ADP.GetTablePrimaryKey(tableName, Connection);
			}
			m_numericPrecisions = new Dictionary<string, byte>();
			foreach (SqlCeInfoSchemaColumn tableColumn in m_tableColumns)
			{
				if (tableColumn.SqlCeType.SeType == SETYPE.NUMERIC)
				{
					m_numericPrecisions.Add(tableColumn.ColumnName, GetPrecision(tableName, tableColumn.ColumnName));
				}
			}
			if (m_primaryKeyColumns.Count == 0)
			{
				throw new ArgumentException(Res.GetString("SQLCE_NoPrimaryKey", tableName));
			}
		}
		byte[] array = null;
		if (m_primaryKeyColumns.Count != columnValues.Length)
		{
			throw new ArgumentException(Res.GetString("SQLCE_IncorrectValue", "columnValues", columnValues.Length, m_primaryKeyColumns.Count));
		}
		ArrayList arrayList = new ArrayList();
		int length = 0;
		int count = m_primaryKeyColumns.Count;
		int num = 0;
		if (m_keyType != TrackingKeyType.Guid)
		{
			arrayList.Add(BitConverter.GetBytes(count));
			num = 4;
		}
		for (int i = 0; i < count; i++)
		{
			byte[] array2 = null;
			string text = m_primaryKeyColumns[i].ToString();
			SqlCeInfoSchemaColumn valueByColumnName = m_tableColumns.GetValueByColumnName(text);
			int num2 = valueByColumnName.MaxLength;
			if (columnValues[i] == null)
			{
				throw new ArgumentNullException("columnValues[" + i + "]");
			}
			if (valueByColumnName.SqlCeType.SeType == SETYPE.NCHAR || valueByColumnName.SqlCeType.SeType == SETYPE.NVARCHAR)
			{
				num2 = Encoding.Unicode.GetMaxByteCount(valueByColumnName.MaxLength);
				if (valueByColumnName.MaxLength > 0 && ((string)columnValues[i]).Length > valueByColumnName.MaxLength)
				{
					throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "columnValues[" + i + "].Length", 0, valueByColumnName.MaxLength));
				}
			}
			array2 = ADP.BitConverterGetBytes(valueByColumnName.SqlCeType, columnValues[i], ref length);
			if (valueByColumnName.SqlCeType.SeType == SETYPE.NUMERIC)
			{
				array2[0] = m_numericPrecisions[text];
			}
			if (num2 > 0 && length > num2)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "columnValues[" + i + "].Length", 0, valueByColumnName.MaxLength));
			}
			if (m_keyType != TrackingKeyType.Guid)
			{
				arrayList.Add(BitConverter.GetBytes(length));
				num += 4;
			}
			arrayList.Add(array2);
			num += length;
		}
		array = new byte[num];
		num = 0;
		for (int j = 0; j < arrayList.Count; j++)
		{
			byte[] array3 = (byte[])arrayList[j];
			Array.Copy(array3, 0, array, num, array3.Length);
			num += array3.Length;
		}
		return array;
	}

	public object[] UnpackTombstoneKey(string tableName, byte[] tombstoneKey)
	{
		VersionCheck(ref iTrackingVersion, TrackingVersion.TypeV2, TrackingVersion.TypeV1);
		if (tableName == null)
		{
			throw new ArgumentNullException("tableName");
		}
		if (tombstoneKey == null || tombstoneKey.Length == 0)
		{
			throw new ArgumentNullException("tombstoneKey");
		}
		if (tombstoneKey.Length <= 4)
		{
			throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "tombstoneKey", 5, uint.MaxValue));
		}
		ArrayList arrayList = null;
		if (!tableName.Equals(m_tableName))
		{
			if (!TableExists(tableName))
			{
				throw new ArgumentException(Res.GetString("SQLCE_NoTable", tableName));
			}
			m_tableColumns = ADP.GetTableColumns(tableName, Connection);
			m_keyType = GetTrackingKeyType(tableName);
			m_tableName = tableName;
			string tableRowGuidColumn = ADP.GetTableRowGuidColumn(tableName, Connection);
			if (m_keyType == TrackingKeyType.Guid)
			{
				m_primaryKeyColumns = new List<string>(1);
				m_primaryKeyColumns.Add(tableRowGuidColumn);
			}
			else
			{
				m_primaryKeyColumns = ADP.GetTablePrimaryKey(tableName, Connection);
			}
			if (m_primaryKeyColumns.Count == 0)
			{
				throw new ArgumentException(Res.GetString("SQLCE_NoPrimaryKey", tableName));
			}
		}
		int num = 0;
		arrayList = new ArrayList(m_primaryKeyColumns.Count);
		for (int i = 0; i < m_primaryKeyColumns.Count; i++)
		{
			arrayList.Add(DBNull.Value);
		}
		int num2;
		if (m_keyType != TrackingKeyType.Guid)
		{
			num2 = BitConverter.ToInt32(tombstoneKey, num);
			num += 4;
		}
		else
		{
			num2 = 1;
		}
		if (num2 != m_primaryKeyColumns.Count)
		{
			throw new ArgumentException(Res.GetString("SQLCE_FormatException", "tombstoneKey"));
		}
		for (int j = 0; j < num2; j++)
		{
			int num3;
			if (m_keyType != TrackingKeyType.Guid)
			{
				num3 = BitConverter.ToInt32(tombstoneKey, num);
				num += 4;
			}
			else
			{
				num3 = 16;
			}
			if (num3 > tombstoneKey.Length - num)
			{
				throw new InvalidOperationException(Res.GetString("SQL_InvalidBufferSizeOrIndex", num, num3));
			}
			string columnName = m_primaryKeyColumns[j].ToString();
			SqlCeInfoSchemaColumn valueByColumnName = m_tableColumns.GetValueByColumnName(columnName);
			arrayList[j] = ADP.BitConverterGetObject(valueByColumnName.SqlCeType, tombstoneKey, num, num3);
			num += num3;
		}
		if (num < tombstoneKey.Length)
		{
			throw new ArgumentException(Res.GetString("SQLCE_FormatException", "tombstoneKey"));
		}
		return arrayList.ToArray();
	}
}
