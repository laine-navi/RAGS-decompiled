using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

public sealed class SqlCeCommand : DbCommand, ICloneable
{
	internal enum ExecuteType
	{
		NonQuery,
		DataReader,
		ResultSet
	}

	private object thisLock = new object();

	private int recordsAffected;

	internal uint[] indexColOrdinals;

	private bool dbRangeSet;

	private bool isHostControlled;

	private bool isPrepared;

	private bool isDisposed;

	private bool isFinalized;

	private ExecuteType executeType;

	private IntPtr pQpPlan;

	private IntPtr pQpCommand;

	private IntPtr pError;

	private string commandText;

	private string indexName;

	private object[] dbRangeStart;

	private object[] dbRangeEnd;

	private DbRangeOptions dbRangeOptions;

	internal ResultSetOptions cursorCapabilities;

	private ResultSetOptions resultSetOptions;

	private CommandType type;

	private UpdateRowSource updatedRowSource;

	internal CommandBehavior behavior;

	private Accessor accessor;

	private SqlCeConnection connection;

	private SqlCeTransaction transaction;

	private SqlCeParameterCollection parameters;

	private SqlCeResultSet resultSet;

	private WeakReferenceCache cursorWeakRefList;

	private MetaData[] metadata;

	private SqlCeDataReader cursor;

	public override string CommandText
	{
		get
		{
			if (commandText == null)
			{
				return string.Empty;
			}
			return commandText;
		}
		set
		{
			CloseInternalCommand();
			commandText = value;
		}
	}

	public string IndexName
	{
		get
		{
			if (indexName == null || indexName.Length == 0)
			{
				return null;
			}
			return indexName;
		}
		set
		{
			indexName = value;
		}
	}

	public override int CommandTimeout
	{
		get
		{
			return 0;
		}
		set
		{
			if (value != 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidCommandTimeOut"));
			}
		}
	}

	public override CommandType CommandType
	{
		get
		{
			return type;
		}
		set
		{
			if (type != value)
			{
				CloseInternalCommand();
				if (CommandType.TableDirect == type)
				{
					dbRangeSet = false;
				}
				switch (value)
				{
				case CommandType.Text:
				case CommandType.TableDirect:
					type = value;
					return;
				case CommandType.StoredProcedure:
					throw new ArgumentException(Res.GetString("ADP_InvalidCommandType", "CommandType.StoredProcedure"));
				}
				object[] array = new object[1];
				int num = (int)type;
				array[0] = num.ToString(CultureInfo.CurrentCulture);
				throw new ArgumentException(Res.GetString("ADP_InvalidCommandType", array));
			}
		}
	}

	protected override DbConnection DbConnection
	{
		get
		{
			return Connection;
		}
		set
		{
			Connection = (SqlCeConnection)value;
		}
	}

	public new SqlCeConnection Connection
	{
		get
		{
			return connection;
		}
		set
		{
			if (value == connection)
			{
				return;
			}
			CloseInternalCommand();
			if (connection != null)
			{
				connection.RemoveWeakReference(this);
				if (HasOpenedCursors())
				{
					ClearCursorList();
				}
				Transaction = null;
			}
			connection = value;
			if (connection != null)
			{
				connection.AddWeakReference(this);
			}
		}
	}

	protected override DbParameterCollection DbParameterCollection => Parameters;

	public new SqlCeParameterCollection Parameters
	{
		get
		{
			if (parameters == null)
			{
				parameters = new SqlCeParameterCollection(this);
			}
			return parameters;
		}
	}

	protected override DbTransaction DbTransaction
	{
		get
		{
			return Transaction;
		}
		set
		{
			Transaction = (SqlCeTransaction)value;
		}
	}

	public new SqlCeTransaction Transaction
	{
		get
		{
			return transaction;
		}
		set
		{
			if (transaction != value)
			{
				if (value != null && value.IsZombied)
				{
					throw new InvalidOperationException(Res.GetString("ADP_TransactionZombied", value.GetType().Name));
				}
				if (HasOpenedCursors())
				{
					throw new InvalidOperationException(Res.GetString("SQLCE_OpenedCursorsOnTxChange"));
				}
				CloseInternalCommand();
				transaction = value;
			}
		}
	}

	internal SqlCeTransaction InternalTransaction
	{
		get
		{
			if (connection != null && connection.HasDelegatedTransaction)
			{
				return connection.DelegatedTransaction.SqlCeTransaction;
			}
			return transaction;
		}
	}

	public override UpdateRowSource UpdatedRowSource
	{
		get
		{
			return updatedRowSource;
		}
		set
		{
			switch (value)
			{
			case UpdateRowSource.None:
			case UpdateRowSource.OutputParameters:
			case UpdateRowSource.FirstReturnedRecord:
			case UpdateRowSource.Both:
				updatedRowSource = value;
				break;
			default:
				throw new ArgumentException(Res.GetString("ADP_InvalidUpdateRowSource", value.ToString()));
			}
		}
	}

	internal IntPtr IQPSession
	{
		get
		{
			if (InternalTransaction != null)
			{
				return InternalTransaction.IQPSession;
			}
			if (connection != null)
			{
				return connection.IQPSession;
			}
			return IntPtr.Zero;
		}
	}

	internal IntPtr ITransact
	{
		get
		{
			if (InternalTransaction != null)
			{
				return InternalTransaction.ITransact;
			}
			if (connection != null)
			{
				return connection.ITransact;
			}
			return IntPtr.Zero;
		}
	}

	internal IntPtr IQPPlan => pQpPlan;

	public override bool DesignTimeVisible
	{
		get
		{
			return false;
		}
		set
		{
			string message = string.Format(CultureInfo.InvariantCulture, "DesignTimeVisible", new object[0]);
			throw new NotSupportedException(message);
		}
	}

	internal SqlCeCommand(bool isHostControlled)
	{
		NativeMethods.LoadNativeBinaries();
		this.isHostControlled = isHostControlled;
	}

	public SqlCeCommand()
	{
		NativeMethods.LoadNativeBinaries();
		isDisposed = false;
		isFinalized = false;
		isPrepared = false;
		dbRangeSet = false;
		isHostControlled = false;
		type = CommandType.Text;
		updatedRowSource = UpdateRowSource.Both;
		cursorWeakRefList = new WeakReferenceCache(trackResurrection: false);
		int num = NativeMethods.CreateErrorInstance(ref pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
	}

	public SqlCeCommand(string commandText)
		: this()
	{
		CommandText = commandText;
	}

	public SqlCeCommand(string commandText, SqlCeConnection connection)
		: this(commandText)
	{
		Connection = connection;
	}

	public SqlCeCommand(string commandText, SqlCeConnection connection, SqlCeTransaction transaction)
		: this(commandText, connection)
	{
		Transaction = transaction;
	}

	~SqlCeCommand()
	{
		Dispose(disposing: false);
	}

	private void ReleaseNativeInterfaces()
	{
		if (IntPtr.Zero != pQpPlan)
		{
			NativeMethods.SafeRelease(ref pQpPlan);
		}
		if (IntPtr.Zero != pQpCommand)
		{
			NativeMethods.SafeRelease(ref pQpCommand);
		}
		if (IntPtr.Zero != pError)
		{
			NativeMethods.SafeDelete(ref pError);
		}
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
				if (connection != null)
				{
					connection.RemoveWeakReference(this);
					connection = null;
				}
				if (accessor != null)
				{
					accessor.Dispose();
					accessor = null;
				}
				if (transaction != null)
				{
					transaction = null;
				}
				cursor = null;
				commandText = null;
				parameters = null;
				indexName = null;
				indexColOrdinals = null;
				dbRangeStart = null;
				dbRangeEnd = null;
				isDisposed = true;
			}
			ReleaseNativeInterfaces();
			if (!disposing)
			{
				isFinalized = true;
			}
		}
	}

	public void SetRange(DbRangeOptions dbRangeOptions, object[] startData, object[] endData)
	{
		dbRangeSet = true;
		this.dbRangeOptions = dbRangeOptions;
		dbRangeStart = startData;
		dbRangeEnd = endData;
	}

	private void CreateAccessorFromParameterList()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < parameters.Count; i++)
		{
			if (parameters[i].IsUserSpecifiedType)
			{
				num++;
			}
		}
		Accessor accessor = new Accessor(num);
		for (int j = 0; j < parameters.Count; j++)
		{
			SqlCeParameter sqlCeParameter = parameters[j];
			if (!sqlCeParameter.IsUserSpecifiedType)
			{
				continue;
			}
			bool flag = sqlCeParameter.ParameterName != null;
			bool flag2 = (((object)sqlCeParameter.NativeType.clrType == typeof(string)) ? true : false);
			accessor.CurrentIndex = num2;
			accessor.Ordinal = j;
			if (flag)
			{
				accessor.ColumnName = (sqlCeParameter.ParameterName.StartsWith("@") ? sqlCeParameter.ParameterName.Substring(1) : sqlCeParameter.ParameterName);
			}
			else
			{
				accessor.ColumnName = null;
			}
			accessor.SeType = sqlCeParameter.NativeType.seType;
			if (sqlCeParameter.NativeType.fixlen < 0)
			{
				if (sqlCeParameter.Size == 0)
				{
					accessor.MaxLen = 0;
				}
				else
				{
					accessor.MaxLen = (flag2 ? ((sqlCeParameter.Size + 1) * 2) : sqlCeParameter.Size);
				}
			}
			else
			{
				accessor.MaxLen = sqlCeParameter.NativeType.fixlen;
			}
			if (sqlCeParameter.SqlDbType == SqlDbType.Decimal && sqlCeParameter.Value != null && sqlCeParameter.Value != DBNull.Value && (!(sqlCeParameter.Value is INullable) || !((INullable)sqlCeParameter.Value).IsNull))
			{
				accessor.Precision = sqlCeParameter.Precision;
				accessor.Scale = sqlCeParameter.Scale;
			}
			num2++;
		}
		accessor.AllocData();
		this.accessor = accessor;
	}

	private void CreateParameterAccessor(MetaData[] metadata)
	{
		int num = metadata.Length;
		Accessor accessor = new Accessor(num);
		for (int i = 0; i < num; i++)
		{
			MetaData metaData = metadata[i];
			SqlCeParameter sqlCeParameter = null;
			bool flag = false;
			if (metaData.ColumnName.StartsWith("?_", StringComparison.InvariantCultureIgnoreCase))
			{
				sqlCeParameter = parameters[i];
			}
			else
			{
				flag = true;
				sqlCeParameter = parameters[metaData.ColumnName];
			}
			if (sqlCeParameter.IsUserSpecifiedType && sqlCeParameter.SqlDbType != metaData.typeMap.sqlDbType)
			{
				SqlCeType.ValidateDataConversion(metaData.typeMap.sqlDbType, sqlCeParameter.SqlDbType);
			}
			accessor.CurrentIndex = i;
			accessor.Ordinal = (int)metaData.ordinal;
			if (flag)
			{
				accessor.ColumnName = (metaData.ColumnName.StartsWith("@") ? metaData.ColumnName.Substring(1) : metaData.ColumnName);
			}
			else
			{
				accessor.ColumnName = null;
			}
			accessor.SeType = metaData.typeMap.seType;
			accessor.MaxLen = GetParameterSize(metaData, sqlCeParameter);
			accessor.Precision = metaData.SqlMetaData.Precision;
			accessor.Scale = metaData.SqlMetaData.Scale;
		}
		accessor.AllocData();
		this.accessor = accessor;
	}

	private static int GetParameterSize(MetaData info, SqlCeParameter p)
	{
		int num = 0;
		if (info.typeMap.fixlen < 0)
		{
			bool isBLOB = info.typeMap.isBLOB;
			bool flag = (((object)info.typeMap.clrType == typeof(string)) ? true : false);
			bool flag2 = ((info.typeMap.sqlDbType != p.SqlDbType) ? true : false);
			if (flag && !isBLOB && flag2)
			{
				if (p.Size == 0)
				{
					return (int)(info.size + 2);
				}
				return Math.Min((p.Size + 1) * 2, (int)(info.size + 2));
			}
			if (p.Size == 0)
			{
				int parameterLength = p.GetParameterLength();
				if (flag)
				{
					return Math.Min((parameterLength + 1) * 2, (int)(info.size + 2));
				}
				return Math.Min(parameterLength, (int)info.size);
			}
			if (flag)
			{
				return Math.Min((p.Size + 1) * 2, (int)(info.size + 2));
			}
			return Math.Min(p.Size, (int)info.size);
		}
		return info.typeMap.fixlen;
	}

	public override void Cancel()
	{
		string message = string.Format(CultureInfo.InvariantCulture, "Cancel", new object[0]);
		throw new NotSupportedException(message);
	}

	object ICloneable.Clone()
	{
		SqlCeCommand sqlCeCommand = (SqlCeCommand)Activator.CreateInstance(GetType());
		sqlCeCommand.Connection = Connection;
		sqlCeCommand.CommandText = CommandText;
		sqlCeCommand.CommandTimeout = CommandTimeout;
		sqlCeCommand.CommandType = CommandType;
		sqlCeCommand.Transaction = Transaction;
		sqlCeCommand.UpdatedRowSource = UpdatedRowSource;
		if (parameters != null && 0 < parameters.Count)
		{
			SqlCeParameterCollection sqlCeParameterCollection = sqlCeCommand.Parameters;
			foreach (ICloneable parameter in Parameters)
			{
				sqlCeParameterCollection.Add(parameter.Clone());
			}
		}
		return sqlCeCommand;
	}

	internal void CloseFromConnection()
	{
		lock (thisLock)
		{
			if (!isFinalized)
			{
				CloseInternalCommand();
				transaction = null;
			}
		}
	}

	private void CloseInternalCommand()
	{
		behavior = CommandBehavior.SequentialAccess;
		isPrepared = false;
		cursor = null;
		if (metadata != null)
		{
			MetaData[] array = metadata;
			for (int i = 0; i < array.Length; i++)
			{
				array[i]?.Dispose();
			}
			Array.Clear(metadata, 0, metadata.Length);
			metadata = null;
		}
		if (accessor != null)
		{
			accessor.Dispose();
			accessor = null;
		}
		if (IntPtr.Zero != pQpPlan)
		{
			NativeMethods.SafeRelease(ref pQpPlan);
		}
		if (IntPtr.Zero != pQpCommand)
		{
			NativeMethods.SafeRelease(ref pQpCommand);
		}
	}

	protected override DbParameter CreateDbParameter()
	{
		return CreateParameter();
	}

	public new SqlCeParameter CreateParameter()
	{
		return new SqlCeParameter();
	}

	protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
	{
		return ExecuteReader(behavior);
	}

	public new SqlCeDataReader ExecuteReader()
	{
		return ExecuteReader(CommandBehavior.Default);
	}

	public new SqlCeDataReader ExecuteReader(CommandBehavior behavior)
	{
		executeType = ExecuteType.DataReader;
		return ExecuteCommand(behavior, "ExecuteReader", ResultSetOptions.None);
	}

	public SqlCeResultSet ExecuteResultSet(ResultSetOptions options)
	{
		return ExecuteResultSet(options, null);
	}

	public SqlCeResultSet ExecuteResultSet(ResultSetOptions options, SqlCeResultSet resultSet)
	{
		executeType = ExecuteType.ResultSet;
		this.resultSet = resultSet;
		return (SqlCeResultSet)ExecuteCommand(CommandBehavior.KeyInfo, "ExecuteResultSet", options);
	}

	private SqlCeDataReader ExecuteCommand(CommandBehavior behavior, string method, ResultSetOptions options)
	{
		int num = 0;
		IntPtr pCursor = IntPtr.Zero;
		SqlCeDataReader sqlCeDataReader = null;
		try
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException("SqlCeCommand");
			}
			if (isPrepared && resultSetOptions != options)
			{
				CloseInternalCommand();
			}
			if (cursor != null && !cursor.IsClosed)
			{
				CloseInternalCommand();
			}
			SetResultSetOptions(options);
			this.behavior = behavior;
			ValidateCommand(method);
			transaction = ValidateTransaction();
			bool isBaseTableCursor = false;
			switch (type)
			{
			case CommandType.Text:
				if (!isPrepared)
				{
					InitializeCommand(behavior, "Prepare");
					CompileQueryPlan();
				}
				if (accessor != null && (CommandBehavior.SchemaOnly & this.behavior) == 0)
				{
					FillParameterDataBindings(verifyValue: true);
					if (!isPrepared)
					{
						CloseInternalCommand();
						InitializeCommand(behavior, "Prepare");
						CompileQueryPlan();
						FillParameterDataBindings(verifyValue: false);
					}
				}
				num = (((CommandBehavior.SchemaOnly & this.behavior) == 0) ? ExecuteCommandText(ref pCursor, ref isBaseTableCursor) : 3);
				break;
			case CommandType.TableDirect:
				OpenCursor(behavior, method, ref pCursor);
				isBaseTableCursor = true;
				num = (((CommandBehavior.SchemaOnly & this.behavior) == 0) ? 1 : 3);
				break;
			default:
				throw new ArgumentException(Res.GetString("ADP_InvalidCommandType", CommandType.ToString()));
			}
			if (ExecuteType.DataReader == executeType)
			{
				sqlCeDataReader = new SqlCeDataReader(connection, this);
				sqlCeDataReader.fetchDirection = FETCH.FORWARD;
			}
			else if (ExecuteType.ResultSet == executeType)
			{
				if (resultSet == null)
				{
					sqlCeDataReader = new SqlCeResultSet(connection, this);
				}
				else
				{
					sqlCeDataReader = resultSet;
					sqlCeDataReader.InitializeReader(connection, this);
				}
				if (!isBaseTableCursor)
				{
					sqlCeDataReader.fetchDirection = FETCH.FORWARD;
					sqlCeDataReader.cursorPosition = MoveFirst(pCursor);
				}
			}
			if (sqlCeDataReader != null)
			{
				cursor = sqlCeDataReader;
				sqlCeDataReader.pSeCursor = pCursor;
				pCursor = IntPtr.Zero;
				sqlCeDataReader.isBaseTableCursor = isBaseTableCursor;
				InitializeDataReader(sqlCeDataReader, num);
				cursorWeakRefList.Add(sqlCeDataReader);
			}
		}
		finally
		{
			if (IntPtr.Zero != pCursor)
			{
				NativeMethods.SafeRelease(ref pCursor);
			}
		}
		return sqlCeDataReader;
	}

	internal bool HasOpenedCursors()
	{
		int count = cursorWeakRefList.Count;
		for (int i = 0; i < count; i++)
		{
			object obj = cursorWeakRefList.GetObject(i);
			if (obj != null)
			{
				SqlCeDataReader sqlCeDataReader = (SqlCeDataReader)obj;
				if (!sqlCeDataReader.IsClosed)
				{
					return true;
				}
				cursorWeakRefList.RemoveAt(i);
			}
		}
		return false;
	}

	internal void ClearCursorList()
	{
		int count = cursorWeakRefList.Count;
		for (int i = 0; i < count; i++)
		{
			object obj = cursorWeakRefList.GetObject(i);
			if (obj != null)
			{
				cursorWeakRefList.RemoveAt(i);
			}
		}
	}

	private void SetResultSetOptions(ResultSetOptions options)
	{
		if ((ResultSetOptions.Sensitive & options) != 0 && (ResultSetOptions.Insensitive & options) != 0)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_ConflictingSensitivityOptions"));
		}
		if (CommandType.TableDirect == type)
		{
			if ((ResultSetOptions.Insensitive & options) != 0)
			{
				throw new InvalidOperationException(Res.GetString("SQLCE_InsensitiveBaseTableCursor"));
			}
			resultSetOptions = options | ResultSetOptions.Sensitive;
		}
		else
		{
			resultSetOptions = options;
		}
	}

	private CursorPosition MoveFirst(IntPtr pSeCursor)
	{
		if (IntPtr.Zero == pSeCursor)
		{
			return CursorPosition.Undefined;
		}
		int hr = NativeMethods.Move(pSeCursor, DIRECTION.MOVE_FIRST, pError);
		if (NativeMethods.Failed(hr))
		{
			int lMinor = 0;
			NativeMethods.GetMinorError(pError, ref lMinor);
			if (25001 == lMinor)
			{
				NativeMethods.ClearErrorInfo(pError);
				return CursorPosition.Undefined;
			}
			ProcessResults(hr);
		}
		return CursorPosition.OnRow;
	}

	private SqlCeDataReader InitializeDataReader(SqlCeDataReader reader, int resultType)
	{
		switch (resultType)
		{
		case 2:
			reader.recordsAffected = recordsAffected;
			break;
		case 1:
		{
			reader.recordsAffected = recordsAffected;
			reader.FillMetaData(this);
			int fieldCount = reader.FieldCount;
			if ((CommandBehavior.SchemaOnly & behavior) != 0)
			{
				reader.BuildSchemaTable();
			}
			else if (0 < fieldCount)
			{
				reader.CreateAccessors(this, fieldCount, allowMultipleAccessor: true);
			}
			break;
		}
		case 3:
			reader.FillMetaData(this);
			reader.BuildSchemaTable();
			break;
		}
		connection.AddWeakReference(reader);
		if (dbRangeSet && (CommandBehavior.SchemaOnly & behavior) == 0)
		{
			reader.SetRange(dbRangeOptions, dbRangeStart, dbRangeEnd);
		}
		return reader;
	}

	private unsafe int ExecuteCommandText(ref IntPtr pCursor, ref bool isBaseTableCursor)
	{
		int num = 0;
		isBaseTableCursor = false;
		if (accessor != null)
		{
			fixed (void* dbBinding = accessor.DbBinding)
			{
				IntPtr prgBinding = (IntPtr)dbBinding;
				int cDbBinding = 0;
				IntPtr pData = IntPtr.Zero;
				if (accessor != null)
				{
					cDbBinding = accessor.Count;
					pData = accessor.DataHandle;
				}
				int fIsBaseTableCursor = 0;
				num = NativeMethods.ExecuteQueryPlan(ITransact, connection.IQPServices, pQpCommand, pQpPlan, prgBinding, cDbBinding, pData, ref recordsAffected, ref cursorCapabilities, ref pCursor, ref fIsBaseTableCursor, pError);
				isBaseTableCursor = ((1 == fIsBaseTableCursor) ? true : false);
			}
		}
		else
		{
			int fIsBaseTableCursor2 = 0;
			num = NativeMethods.ExecuteQueryPlan(ITransact, connection.IQPServices, pQpCommand, pQpPlan, IntPtr.Zero, 0, IntPtr.Zero, ref recordsAffected, ref cursorCapabilities, ref pCursor, ref fIsBaseTableCursor2, pError);
			isBaseTableCursor = ((1 == fIsBaseTableCursor2) ? true : false);
		}
		if (num != 0)
		{
			ProcessResults(num);
		}
		if (IntPtr.Zero != pCursor)
		{
			recordsAffected = -1;
		}
		if (IntPtr.Zero != pCursor)
		{
			return 1;
		}
		return 2;
	}

	public override int ExecuteNonQuery()
	{
		executeType = ExecuteType.NonQuery;
		ExecuteCommand(CommandBehavior.Default, "ExecuteNonQuery", ResultSetOptions.None);
		return recordsAffected;
	}

	public override object ExecuteScalar()
	{
		object result = null;
		SqlCeDataReader sqlCeDataReader = null;
		try
		{
			executeType = ExecuteType.DataReader;
			sqlCeDataReader = ExecuteCommand(CommandBehavior.Default, "ExecuteScalar", ResultSetOptions.None);
			if (sqlCeDataReader.Read() && 0 < sqlCeDataReader.FieldCount)
			{
				result = sqlCeDataReader.GetValue(0);
			}
		}
		finally
		{
			sqlCeDataReader?.Dispose();
		}
		return result;
	}

	private unsafe void OpenCursor(CommandBehavior behavior, string method, ref IntPtr pSeCursor)
	{
		this.behavior = behavior;
		string source = ExpandCommandText(method);
		IntPtr priOrdinals = IntPtr.Zero;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = NativeMethods.MarshalStringToLPWSTR(source);
			intPtr2 = NativeMethods.MarshalStringToLPWSTR(IndexName);
			int num = NativeMethods.OpenCursor(ITransact, intPtr, intPtr2, ref pSeCursor, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			cursorCapabilities = resultSetOptions;
			if (IndexName == null || IndexName.Length <= 0)
			{
				return;
			}
			uint cColumns = 0u;
			num = NativeMethods.GetIndexColumnOrdinals(pSeCursor, intPtr2, ref cColumns, ref priOrdinals, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			indexColOrdinals = new uint[cColumns];
			fixed (uint* ptr = indexColOrdinals)
			{
				uint* ptr2 = (uint*)(void*)priOrdinals;
				for (int i = 0; i < cColumns; i++)
				{
					ptr[i] = ptr2[i];
				}
			}
		}
		finally
		{
			NativeMethods.CoTaskMemFree(intPtr);
			NativeMethods.CoTaskMemFree(intPtr2);
			NativeMethods.DeleteArray(ref priOrdinals);
			recordsAffected = -1;
		}
	}

	private string ExpandCommandText(string method)
	{
		if (commandText == null || commandText.Length == 0)
		{
			throw new InvalidOperationException(Res.GetString("ADP_CommandTextRequired", method));
		}
		CommandType commandType = CommandType;
		if (commandType == CommandType.Text || commandType == CommandType.TableDirect)
		{
			return commandText;
		}
		throw new ArgumentException(Res.GetString("ADP_InvalidCommandType", ((int)CommandType).ToString(CultureInfo.CurrentCulture)));
	}

	private void FillParameterDataBindings(bool verifyValue)
	{
		SqlCeParameter sqlCeParameter = null;
		int count = accessor.Count;
		if (count == 0)
		{
			return;
		}
		if (verifyValue)
		{
			for (int i = 0; i < count; i++)
			{
				accessor.CurrentIndex = i;
				string columnName = accessor.ColumnName;
				sqlCeParameter = ((columnName == null) ? parameters[i] : parameters[columnName]);
				if (!metadata[i].typeMap.isFixed)
				{
					int parameterSize = GetParameterSize(metadata[i], sqlCeParameter);
					if (parameterSize > accessor.MaxLen)
					{
						OnDataBindingChange();
						return;
					}
				}
				if (sqlCeParameter.SqlDbType == SqlDbType.Decimal && sqlCeParameter.Value != null && DBNull.Value != sqlCeParameter.Value && (!(sqlCeParameter.Value is INullable) || !((INullable)sqlCeParameter.Value).IsNull) && (sqlCeParameter.Precision - sqlCeParameter.Scale > accessor.Precision - accessor.Scale || sqlCeParameter.Scale > accessor.Scale))
				{
					OnDataBindingChange();
					return;
				}
			}
		}
		for (int j = 0; j < count; j++)
		{
			accessor.CurrentIndex = j;
			string columnName2 = accessor.ColumnName;
			sqlCeParameter = ((columnName2 == null) ? parameters[j] : parameters[columnName2]);
			object parameterValue = sqlCeParameter.GetParameterValue();
			if (parameterValue == null)
			{
				throw new ArgumentNullException(sqlCeParameter.ParameterName, string.Format(CultureInfo.CurrentCulture, Res.GetString("ADP_ParameterNotSpecified"), new object[1] { commandText }));
			}
			try
			{
				if (sqlCeParameter.Size > 0)
				{
					accessor.doTruncate = true;
				}
				else
				{
					accessor.doTruncate = false;
				}
				accessor.Value = parameterValue;
			}
			catch (InvalidOperationException ex)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "{0} : {1}", new object[2] { sqlCeParameter.ParameterName, ex.Message }));
			}
			catch (InvalidCastException ex2)
			{
				throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, "{0} : {1}", new object[2] { sqlCeParameter.ParameterName, ex2.Message }));
			}
			catch (FormatException ex3)
			{
				throw new FormatException(string.Format(CultureInfo.CurrentCulture, "{0} : {1} - {2}", new object[3]
				{
					sqlCeParameter.ParameterName,
					parameterValue.ToString(),
					ex3.Message
				}));
			}
		}
	}

	private void FillParameterDataBindings()
	{
		FillParameterDataBindings(verifyValue: true);
	}

	private void InitializeCommand(CommandBehavior behavior, string method)
	{
		bool flag = false;
		try
		{
			this.behavior = behavior;
			if (IntPtr.Zero == pQpCommand)
			{
				int num = NativeMethods.CreateCommand(IQPSession, ref pQpCommand, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			if (accessor != null)
			{
				accessor.Dispose();
				accessor = null;
			}
		}
		catch (Exception ex)
		{
			flag = true;
			throw ex;
		}
		finally
		{
			if (flag)
			{
				if (accessor != null)
				{
					accessor.Dispose();
					accessor = null;
				}
				CloseInternalCommand();
			}
		}
	}

	internal void OnDataBindingChange()
	{
		if (accessor != null)
		{
			accessor.Dispose();
			accessor = null;
			isPrepared = false;
		}
	}

	public override void Prepare()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeCommand");
		}
		ValidateCommand("Prepare");
		transaction = ValidateTransaction();
		CloseInternalCommand();
		isPrepared = false;
	}

	internal SqlCeTransaction ValidateTransaction()
	{
		SqlCeTransaction sqlCeTransaction = Transaction;
		if (sqlCeTransaction == null)
		{
			return null;
		}
		if (sqlCeTransaction != null && Connection == sqlCeTransaction.Connection)
		{
			return sqlCeTransaction;
		}
		throw new InvalidOperationException(Res.GetString("ADP_TransactionConnectionMismatch"));
	}

	private unsafe void CompileQueryPlan()
	{
		bool flag = false;
		try
		{
			isPrepared = false;
			if (IntPtr.Zero == pQpPlan)
			{
				CreateDataBindings();
				string pwszCommandText = ExpandCommandText("Prepare");
				int num = 0;
				if (accessor != null)
				{
					int count = accessor.Count;
					IntPtr[] array = new IntPtr[count];
					try
					{
						fixed (void* dbBinding = accessor.DbBinding)
						{
							IntPtr prgBinding = (IntPtr)dbBinding;
							for (int i = 0; i < count; i++)
							{
								accessor.CurrentIndex = i;
								ref IntPtr reference = ref array[i];
								reference = NativeMethods.MarshalStringToLPWSTR(accessor.ColumnName);
							}
							num = NativeMethods.CompileQueryPlan(pQpCommand, pwszCommandText, resultSetOptions, array, prgBinding, count, ref pQpPlan, pError);
						}
					}
					finally
					{
						for (int j = 0; j < count; j++)
						{
							if (IntPtr.Zero != array[j])
							{
								NativeMethods.CoTaskMemFree(array[j]);
							}
						}
					}
				}
				else
				{
					num = NativeMethods.CompileQueryPlan(pQpCommand, pwszCommandText, resultSetOptions, new IntPtr[0], IntPtr.Zero, 0, ref pQpPlan, pError);
				}
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			OnDataBindingChange();
			isPrepared = true;
			CreateDataBindings();
		}
		catch (Exception ex)
		{
			flag = true;
			throw ex;
		}
		finally
		{
			if (flag)
			{
				if (accessor != null)
				{
					accessor.Dispose();
					accessor = null;
				}
				CloseInternalCommand();
			}
		}
	}

	private void CreateDataBindings()
	{
		if (parameters == null || parameters.Count == 0)
		{
			return;
		}
		if (isPrepared)
		{
			metadata = GetQueryParameters(pQpCommand);
			if (metadata != null)
			{
				if (accessor != null)
				{
					accessor.Dispose();
					accessor = null;
				}
				CreateParameterAccessor(metadata);
			}
		}
		else
		{
			if (accessor != null)
			{
				accessor.Dispose();
				accessor = null;
			}
			if (parameters != null && parameters.Count != 0)
			{
				CreateAccessorFromParameterList();
			}
		}
	}

	private MetaData[] GetQueryParameters(IntPtr pQpCommand)
	{
		uint columnCount = 0u;
		IntPtr prgParamInfo = IntPtr.Zero;
		MetaData[] array = null;
		try
		{
			int parameterInfo = NativeMethods.GetParameterInfo(pQpCommand, ref columnCount, ref prgParamInfo, pError);
			if (parameterInfo != 0)
			{
				ProcessResults(parameterInfo);
			}
			if (columnCount == 0)
			{
				return null;
			}
			array = new MetaData[columnCount];
			QPPARAMINFO qPPARAMINFO = new QPPARAMINFO();
			int num = Marshal.SizeOf(typeof(QPPARAMINFO));
			int num2 = 0;
			int num3 = 0;
			while (num2 < columnCount)
			{
				try
				{
					Marshal.PtrToStructure(ADP.IntPtrOffset(prgParamInfo, num3), (object)qPPARAMINFO);
					string name = Marshal.PtrToStringUni(qPPARAMINFO.pwszParam).ToLower(CultureInfo.CurrentCulture);
					SqlCeType sqlCeType = SqlCeType.FromSeType(qPPARAMINFO.type);
					uint num4 = ((sqlCeType.SqlDbType == SqlDbType.NVarChar || sqlCeType.SqlDbType == SqlDbType.NChar) ? (qPPARAMINFO.ulSize / 2) : qPPARAMINFO.ulSize);
					MetaData metaData = new MetaData(name, sqlCeType, qPPARAMINFO.bPrecision, qPPARAMINFO.bScale, num4, null, null);
					metaData.ordinal = qPPARAMINFO.iOrdinal;
					metaData.size = qPPARAMINFO.ulSize;
					metaData.typeMap = sqlCeType;
					array[metaData.ordinal] = metaData;
				}
				finally
				{
					NativeMethods.SafeDelete(ref qPPARAMINFO.pwszParam);
				}
				num2++;
				num3 += num;
			}
			return array;
		}
		finally
		{
			NativeMethods.DeleteArray(ref prgParamInfo);
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

	internal void ValidateCommand(string method)
	{
		if (connection == null)
		{
			string name = null;
			switch (method)
			{
			case "Prepare":
				name = "ADP_ConnectionRequired_Prepare";
				break;
			case "ExecuteReader":
				name = "ADP_ConnectionRequired_ExecuteReader";
				break;
			case "ExecuteNonQuery":
				name = "ADP_ConnectionRequired_ExecuteNonQuery";
				break;
			case "ExecuteScalar":
				name = "ADP_ConnectionRequired_ExecuteScalar";
				break;
			case "ExecuteResultSet":
				name = "ADP_ConnectionRequired_ExecuteReader";
				break;
			}
			throw new InvalidOperationException(Res.GetString(name, method));
		}
		if (ConnectionState.Open != connection.State)
		{
			string name2 = null;
			switch (method)
			{
			case "Prepare":
				name2 = "ADP_OpenConnectionRequired_Prepare";
				break;
			case "ExecuteReader":
				name2 = "ADP_OpenConnectionRequired_ExecuteReader";
				break;
			case "ExecuteNonQuery":
				name2 = "ADP_OpenConnectionRequired_ExecuteNonQuery";
				break;
			case "ExecuteScalar":
				name2 = "ADP_OpenConnectionRequired_ExecuteScalar";
				break;
			case "ExecuteResultSet":
				name2 = "ADP_ConnectionRequired_ExecuteReader";
				break;
			}
			throw new InvalidOperationException(Res.GetString(name2, method, connection.State));
		}
	}
}
