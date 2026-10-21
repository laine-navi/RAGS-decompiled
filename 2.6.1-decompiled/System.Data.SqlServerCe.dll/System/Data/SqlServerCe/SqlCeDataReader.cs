using System.Collections;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

public class SqlCeDataReader : DbDataReader
{
	private object thisLock = new object();

	private int currAccessor;

	internal int[] bindingIndex;

	internal int[] accessorIndex;

	internal int recordsAffected;

	internal ResultSetOptions cursorCapabilities;

	internal CursorPosition cursorPosition;

	private int fieldCount;

	private int lastBlobColumn;

	private int indexColumnCount;

	private bool sequentialAccess;

	internal bool isDisposed;

	private bool isFinalized;

	private int sequentialOrdinal;

	private long sequentialUnitsRead;

	internal FETCH fetchDirection;

	internal bool isBaseTableCursor;

	internal bool isOnRow;

	private bool isClosed;

	private bool useIndex;

	private bool isHostControlled;

	internal SqlCeConnection connection;

	internal SqlCeTransaction transaction;

	internal Accessor[] accessorArray;

	internal IntPtr pSeCursor;

	internal IntPtr pError;

	private CommandBehavior behavior;

	private DataTable dbSchemaTable;

	internal MetaData[] metadata;

	internal FieldNameLookup fieldNameLookup;

	public override int Depth => 0;

	public override int FieldCount
	{
		get
		{
			if (isClosed)
			{
				throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "FieldCount"));
			}
			return fieldCount;
		}
	}

	public override bool IsClosed => isClosed;

	public override int RecordsAffected => recordsAffected;

	public override object this[int index] => GetValue(index);

	public override object this[string name] => GetValue(GetOrdinal(name));

	public override bool HasRows
	{
		get
		{
			if (isClosed)
			{
				throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "HasRows"));
			}
			if (!isBaseTableCursor && (cursorCapabilities & ResultSetOptions.Scrollable) == 0)
			{
				throw new InvalidOperationException(Res.GetString("SQLCE_HasRowsScrollabilityRequirement"));
			}
			if (IntPtr.Zero == pSeCursor)
			{
				return false;
			}
			bool result = Move(DIRECTION.MOVE_FIRST);
			Move(DIRECTION.MOVE_PREVIOUS);
			return result;
		}
	}

	public int HiddenFieldCount
	{
		get
		{
			if (isClosed)
			{
				throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "FieldCount"));
			}
			return 0;
		}
	}

	internal SqlCeDataReader()
	{
		NativeMethods.LoadNativeBinaries();
		int num = NativeMethods.CreateErrorInstance(ref pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
	}

	internal SqlCeDataReader(SqlCeConnection connection, SqlCeCommand command)
		: this()
	{
		InitializeReader(connection, command);
	}

	internal void InitializeReader(SqlCeConnection connection, SqlCeCommand command)
	{
		this.connection = connection;
		isHostControlled = false;
		currAccessor = -1;
		recordsAffected = -1;
		lastBlobColumn = -1;
		fieldCount = 0;
		useIndex = false;
		isOnRow = false;
		isBaseTableCursor = false;
		cursorPosition = CursorPosition.Undefined;
		isFinalized = false;
		if (command != null)
		{
			transaction = command.InternalTransaction;
			if (command.indexColOrdinals != null)
			{
				indexColumnCount = command.indexColOrdinals.Length;
			}
			cursorCapabilities = command.cursorCapabilities;
			fetchDirection = FETCH.UNKNOWN;
			behavior = command.behavior;
			if (command.IndexName != null && command.IndexName.Length > 0)
			{
				useIndex = true;
			}
		}
		else
		{
			behavior = CommandBehavior.SingleRow;
		}
		sequentialAccess = 0 != (CommandBehavior.SequentialAccess & behavior);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~SqlCeDataReader()
	{
		Dispose(disposing: false);
	}

	private void ReleaseNativeInterfaces()
	{
		if (IntPtr.Zero != pSeCursor)
		{
			NativeMethods.SafeRelease(ref pSeCursor);
		}
		if (IntPtr.Zero != pError)
		{
			NativeMethods.SafeDelete(ref pError);
		}
	}

	private new void Dispose(bool disposing)
	{
		lock (thisLock)
		{
			if (isFinalized)
			{
				return;
			}
			if (disposing)
			{
				if (metadata != null)
				{
					MetaData[] array = metadata;
					foreach (MetaData metaData in array)
					{
						metaData.Dispose();
					}
				}
				if (connection != null)
				{
					connection.RemoveWeakReference(this);
					isClosed = true;
				}
				if (accessorArray != null)
				{
					int num = accessorArray.Length;
					for (int j = 0; j < num; j++)
					{
						if (accessorArray[j] != null)
						{
							accessorArray[j].Dispose();
							accessorArray[j] = null;
						}
					}
					accessorArray = null;
				}
				transaction = null;
				isClosed = true;
				isOnRow = false;
				isDisposed = true;
				bindingIndex = null;
				accessorIndex = null;
				dbSchemaTable = null;
				accessorArray = null;
				metadata = null;
				fieldNameLookup = null;
				currAccessor = -1;
				sequentialOrdinal = 0;
				sequentialAccess = false;
				cursorPosition = CursorPosition.Undefined;
				fieldCount = -1;
			}
			if (!isHostControlled)
			{
				ReleaseNativeInterfaces();
			}
			if ((CommandBehavior.CloseConnection & behavior) != 0 && connection != null)
			{
				connection.Close();
			}
			connection = null;
			if (!disposing)
			{
				isFinalized = true;
			}
		}
	}

	public override void Close()
	{
		Dispose();
	}

	public override DataTable GetSchemaTable()
	{
		if (dbSchemaTable == null)
		{
			if (0 < fieldCount)
			{
				BuildSchemaTable();
			}
			else
			{
				if (isClosed)
				{
					throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "GetSchemaTable"));
				}
				if (fieldCount < 0)
				{
					return null;
				}
			}
		}
		return dbSchemaTable;
	}

	public unsafe bool Seek(DbSeekOptions dbSeekOptions, params object[] index)
	{
		if (index == null)
		{
			throw new ArgumentException("index");
		}
		if (indexColumnCount == 0)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_IndexNameNotSpecified"));
		}
		if (index.Length > indexColumnCount)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_TooManyParameters"));
		}
		int num = accessorArray.Length - 1;
		Accessor accessor = accessorArray[num];
		for (int i = 0; i < index.Length; i++)
		{
			accessor.CurrentIndex = i;
			accessor.Value = index[i];
		}
		fixed (void* dbBinding = accessor.DbBinding)
		{
			IntPtr prgBinding = (IntPtr)dbBinding;
			int num2 = NativeMethods.Seek(pSeCursor, connection.IQPServices, prgBinding, accessor.Count, accessor.DataHandle, index.Length, (int)dbSeekOptions, pError);
			if (!NativeMethods.Failed(num2))
			{
				if (isOnRow)
				{
					ReleaseCurrentRow();
				}
				cursorPosition = CursorPosition.OnRow;
				return true;
			}
			if (-2147217895 != num2)
			{
				ProcessResults(num2);
			}
			return false;
		}
	}

	internal unsafe void SetRange(DbRangeOptions dbRangeOptions, object[] startData, object[] endData)
	{
		if (indexColumnCount == 0)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_IndexNameNotSpecified"));
		}
		if ((startData != null && startData.Length > indexColumnCount) || (endData != null && endData.Length > indexColumnCount))
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_TooManyParameters"));
		}
		IntPtr pStartData = IntPtr.Zero;
		IntPtr pEndData = IntPtr.Zero;
		int cStartKeyValues = 0;
		int cEndKeyValues = 0;
		int num = accessorArray.Length - 1;
		Accessor accessor = accessorArray[num];
		if (startData != null)
		{
			cStartKeyValues = startData.Length;
			for (int i = 0; i < startData.Length; i++)
			{
				accessor.CurrentIndex = i;
				accessor.Value = startData[i];
			}
		}
		if (endData != null)
		{
			cEndKeyValues = endData.Length;
			for (int j = 0; j < endData.Length; j++)
			{
				accessor.CurrentIndex = j + accessor.Count;
				accessor.Value = endData[j];
			}
		}
		IntPtr dataHandle = accessor.DataHandle;
		if (startData != null)
		{
			pStartData = dataHandle;
		}
		if (endData != null)
		{
			pEndData = ADP.IntPtrOffset(dataHandle, accessor.DataBufferSize);
		}
		fixed (void* dbBinding = accessor.DbBinding)
		{
			IntPtr prgBinding = (IntPtr)dbBinding;
			int num2 = NativeMethods.SetRange(pSeCursor, connection.IQPServices, prgBinding, accessor.Count, pStartData, cStartKeyValues, pEndData, cEndKeyValues, (int)dbRangeOptions, pError);
			if (num2 != 0)
			{
				ProcessResults(num2);
			}
		}
	}

	internal void BuildSchemaTable()
	{
		if (metadata == null)
		{
			return;
		}
		DataTable dataTable = new DataTable("SchemaTable");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.MinimumCapacity = fieldCount;
		DataColumn column = new DataColumn("ColumnName", typeof(string));
		DataColumn dataColumn = new DataColumn("ColumnOrdinal", typeof(int));
		DataColumn column2 = new DataColumn("ColumnSize", typeof(int));
		DataColumn dataColumn2 = new DataColumn("NumericPrecision", typeof(short));
		DataColumn dataColumn3 = new DataColumn("NumericScale", typeof(short));
		DataColumn dataColumn4 = new DataColumn("IsUnique", typeof(bool));
		DataColumn dataColumn5 = new DataColumn("IsKey", typeof(bool));
		DataColumn column3 = new DataColumn("BaseColumnName", typeof(string));
		DataColumn column4 = new DataColumn("BaseTableName", typeof(string));
		DataColumn column5 = new DataColumn("DataType", typeof(Type));
		DataColumn column6 = new DataColumn("AllowDBNull", typeof(bool));
		DataColumn column7 = new DataColumn("ProviderType", typeof(SqlCeType));
		DataColumn column8 = new DataColumn("IsAutoIncrement", typeof(bool));
		DataColumn column9 = new DataColumn("IsRowVersion", typeof(bool));
		DataColumn dataColumn6 = new DataColumn("IsLong", typeof(bool));
		DataColumn column10 = new DataColumn("IsReadOnly", typeof(bool));
		DataColumn column11 = new DataColumn("IsAliased", typeof(bool));
		DataColumn column12 = new DataColumn("IsExpression", typeof(bool));
		DataColumn column13 = new DataColumn("IsIdentity", typeof(bool));
		dataColumn.DefaultValue = 0;
		dataColumn6.DefaultValue = false;
		dataColumn2.DefaultValue = null;
		dataColumn3.DefaultValue = null;
		dataColumn4.DefaultValue = null;
		dataColumn5.DefaultValue = null;
		DataColumnCollection columns = dataTable.Columns;
		columns.Add(column);
		columns.Add(dataColumn);
		columns.Add(column2);
		columns.Add(dataColumn2);
		columns.Add(dataColumn3);
		columns.Add(dataColumn4);
		columns.Add(dataColumn5);
		columns.Add(column3);
		columns.Add(column4);
		columns.Add(column5);
		columns.Add(column6);
		columns.Add(column7);
		columns.Add(column11);
		columns.Add(column12);
		columns.Add(column13);
		columns.Add(column8);
		columns.Add(column9);
		columns.Add(dataColumn6);
		columns.Add(column10);
		bool flag = false;
		DataRow dataRow = null;
		DataRow dataRow2 = null;
		for (int i = 0; i < fieldCount; i++)
		{
			MetaData metaData = metadata[i];
			DataRow dataRow3 = dataTable.NewRow();
			dataRow3[column] = metaData.ColumnName;
			dataRow3[dataColumn] = metaData.ordinal;
			if ((object)typeof(string) == metaData.typeMap.clrType)
			{
				if (metaData.typeMap.isBLOB)
				{
					dataRow3[column2] = SqlCeType.MAX_NTEXT_COLUMN_SIZE;
				}
				else
				{
					dataRow3[column2] = metaData.size / 2;
				}
			}
			else if (metaData.typeMap.isBLOB)
			{
				dataRow3[column2] = SqlCeType.MAX_IMAGE_COLUMN_SIZE;
			}
			else
			{
				dataRow3[column2] = metaData.size;
			}
			if (SETYPE.NUMERIC == metaData.typeMap.seType || SETYPE.MONEY == metaData.typeMap.seType)
			{
				dataRow3[dataColumn2] = metaData.SqlMetaData.Precision;
				dataRow3[dataColumn3] = metaData.SqlMetaData.Scale;
			}
			dataRow3[column5] = metaData.typeMap.clrType;
			dataRow3[dataColumn6] = metaData.typeMap.isBLOB;
			dataRow3[column10] = metaData.isReadOnly;
			dataRow3[column9] = metaData.isRowVersion;
			if ((behavior & CommandBehavior.KeyInfo) != 0)
			{
				if (metaData.isRowVersion && dataRow2 == null)
				{
					dataRow2 = dataRow3;
				}
				dataRow3[dataColumn4] = metaData.isUnique;
				if (metaData.isUnique && dataRow == null)
				{
					dataRow = dataRow3;
				}
				dataRow3[dataColumn5] = metaData.isKey;
				flag |= metaData.isKey;
			}
			dataRow3[column8] = metaData.isIdentity;
			dataRow3[column7] = metaData.typeMap;
			dataRow3[column11] = IsAliased(metaData);
			dataRow3[column12] = metaData.isExpression;
			dataRow3[column13] = metaData.isIdentity;
			dataRow3[column6] = metaData.isNullable;
			if (metaData.baseTableName != null)
			{
				dataRow3[column4] = metaData.baseTableName;
			}
			if (metaData.baseColumnName != null)
			{
				dataRow3[column3] = metaData.baseColumnName;
			}
			dataTable.Rows.Add(dataRow3);
			dataRow3.AcceptChanges();
		}
		if ((behavior & CommandBehavior.KeyInfo) != 0 && !flag)
		{
			if (dataRow != null)
			{
				dataRow[dataColumn5] = true;
			}
			else if (dataRow2 != null)
			{
				dataRow2[dataColumn5] = true;
			}
		}
		for (int j = 0; j < columns.Count; j++)
		{
			columns[j].ReadOnly = true;
		}
		dbSchemaTable = dataTable;
	}

	private static bool IsAliased(MetaData info)
	{
		if (info.ColumnName == null || info.baseColumnName == null)
		{
			return false;
		}
		if (info.ColumnName.Equals(info.baseColumnName))
		{
			return false;
		}
		return true;
	}

	protected bool IsCommandBehavior(CommandBehavior condition)
	{
		return condition == (condition & behavior);
	}

	internal unsafe void FillMetaData(SqlCeCommand command)
	{
		int num = 0;
		if (metadata != null)
		{
			return;
		}
		if ((behavior & CommandBehavior.SchemaOnly) == 0)
		{
			FillMetaData(pSeCursor);
		}
		else if (CommandType.TableDirect == command.CommandType)
		{
			FillMetaData(pSeCursor);
			NativeMethods.SafeRelease(ref pSeCursor);
		}
		else
		{
			FillMetaData(command.IQPPlan);
			if (metadata == null)
			{
				return;
			}
		}
		string text = null;
		for (int i = 0; i < fieldCount; i++)
		{
			MetaData metaData = metadata[i];
			if (metaData.baseTableName != null && 0 < metaData.baseTableName.Length)
			{
				if (text == null)
				{
					text = metaData.baseTableName;
				}
				else if (ADP.SrcCompare(text, metaData.baseTableName) != 0)
				{
					text = null;
					break;
				}
			}
		}
		if (text == null)
		{
			return;
		}
		MEDBKEYINFO[] array = new MEDBKEYINFO[fieldCount];
		try
		{
			for (int j = 0; j < fieldCount; j++)
			{
				string baseColumnName = metadata[j].baseColumnName;
				array[j].pwszBaseColumnName = ((baseColumnName.Length == 0) ? IntPtr.Zero : NativeMethods.MarshalStringToLPWSTR(baseColumnName));
			}
			fixed (void* ptr = array)
			{
				IntPtr prgDbKeyInfo = (IntPtr)ptr;
				num = NativeMethods.GetKeyInfo(pSeCursor, command.ITransact, text, prgDbKeyInfo, fieldCount, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
				for (int k = 0; k < fieldCount; k++)
				{
					if (metadata[k].baseColumnName.Length != 0)
					{
						metadata[k].isKey = array[k].isKey != 0;
						metadata[k].isUnique = array[k].isUnique != 0;
						metadata[k].isReadOnly = array[k].isReadOnly != 0;
						metadata[k].isIdentity = array[k].isIdentity != 0;
					}
				}
			}
		}
		finally
		{
			for (int l = 0; l < array.Length; l++)
			{
				NativeMethods.CoTaskMemFree(array[l].pwszBaseColumnName);
			}
		}
	}

	private void FillMetaData(IntPtr pIUnknown)
	{
		int columnCount = 0;
		IntPtr prgColumnInfo = IntPtr.Zero;
		try
		{
			int columnInfo = NativeMethods.GetColumnInfo(pIUnknown, ref columnCount, ref prgColumnInfo, pError);
			if (NativeMethods.Failed(columnInfo))
			{
				int lMinor = 0;
				NativeMethods.GetMinorError(pError, ref lMinor);
				if (lMinor != 0)
				{
					if (28527 != lMinor)
					{
						ProcessResults(columnInfo);
					}
				}
				else if (-2147467259 != columnInfo)
				{
					ProcessResults(columnInfo);
				}
				NativeMethods.ClearErrorInfo(pError);
			}
			if (0 < columnCount)
			{
				PopulateMetaData(columnCount, prgColumnInfo);
			}
		}
		finally
		{
			NativeMethods.DeleteArray(ref prgColumnInfo);
		}
	}

	private void PopulateMetaData(int columnCount, IntPtr prgColumnInfo)
	{
		int num = 0;
		int num2 = 1;
		MetaData[] array = null;
		array = new MetaData[columnCount];
		SECOLUMNINFO sECOLUMNINFO = new SECOLUMNINFO();
		int num3 = Marshal.SizeOf(typeof(SECOLUMNINFO));
		_ = 8;
		_ = IntPtr.Size;
		int num4 = 0;
		int num5 = 0;
		while (num4 < columnCount)
		{
			Marshal.PtrToStructure(ADP.IntPtrOffset(prgColumnInfo, num5), (object)sECOLUMNINFO);
			try
			{
				string text = Marshal.PtrToStringUni(sECOLUMNINFO.pwszColumn);
				string text2 = Marshal.PtrToStringUni(sECOLUMNINFO.pwszBaseTable);
				if (text.StartsWith("#", StringComparison.InvariantCulture))
				{
					string value = text.Substring(1);
					try
					{
						Convert.ToInt32(value, CultureInfo.CurrentCulture);
						text = "Column" + num2++;
					}
					catch (FormatException)
					{
					}
					catch (OverflowException)
					{
					}
				}
				MetaData metaData = null;
				SqlCeType sqlCeType = SqlCeType.FromSeType(sECOLUMNINFO.type);
				if (array[num] != null)
				{
					metaData = array[num];
				}
				else
				{
					string databaseName = ((connection != null) ? connection.Database : string.Empty);
					int num6 = -1;
					if (!sqlCeType.isBLOB)
					{
						num6 = (((object)typeof(string) != sqlCeType.clrType) ? ((int)sECOLUMNINFO.ulSize) : ((int)sECOLUMNINFO.ulSize / 2));
					}
					metaData = new MetaData(text, sqlCeType, (byte)sECOLUMNINFO.bPrecision, (byte)sECOLUMNINFO.bScale, num6, databaseName, text2);
				}
				metaData.ordinal = (uint)num4;
				metaData.size = sECOLUMNINFO.ulSize;
				metaData.isReadOnly = sECOLUMNINFO.fIsWriteable != 1;
				metaData.isRowVersion = sECOLUMNINFO.fIsRowVersion == 1;
				metaData.isIdentity = sECOLUMNINFO.fIsIdentity == 1;
				metaData.isExpression = sECOLUMNINFO.fIsExpression == 1;
				metaData.isNullable = sECOLUMNINFO.fIsNullable == 1;
				metaData.hasDefault = sECOLUMNINFO.fHasDefault == 1;
				metaData.baseTableName = text2;
				metaData.baseColumnName = Marshal.PtrToStringUni(sECOLUMNINFO.pwszBaseColumn);
				metaData.value = null;
				metaData.isUnique = false;
				metaData.isKey = false;
				metaData.typeMap = sqlCeType;
				array[num] = metaData;
				num++;
			}
			finally
			{
				NativeMethods.SafeDelete(ref sECOLUMNINFO.pwszColumn);
				NativeMethods.SafeDelete(ref sECOLUMNINFO.pwszBaseTable);
				NativeMethods.SafeDelete(ref sECOLUMNINFO.pwszBaseColumn);
			}
			num4++;
			num5 += num3;
		}
		if (num < columnCount)
		{
			MetaData[] array2 = new MetaData[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = array[i];
			}
			array = array2;
		}
		fieldCount = num;
		metadata = array;
	}

	private unsafe Accessor FetchValue(int index)
	{
		int num = 0;
		MetaData metaData = metadata[index];
		int num2 = accessorIndex[index];
		Accessor accessor = null;
		if (currAccessor != num2)
		{
			currAccessor = num2;
			if (-1 != lastBlobColumn)
			{
				MetaData metaData2 = metadata[lastBlobColumn];
				if (metaData2.value != null)
				{
					IntPtr ppUnknown = (IntPtr)metaData2.value;
					NativeMethods.SafeRelease(ref ppUnknown);
					int currentIndex = accessorArray[num2].CurrentIndex;
					accessorArray[num2].CurrentIndex = bindingIndex[lastBlobColumn];
					accessorArray[num2].CurrentIndex = currentIndex;
					metaData2.value = null;
				}
			}
			accessor = accessorArray[num2];
			fixed (void* dbBinding = accessor.DbBinding)
			{
				IntPtr prgBinding = (IntPtr)dbBinding;
				num = NativeMethods.GetValues(pSeCursor, 0, prgBinding, accessor.Count, accessor.DataHandle, pError);
			}
			if (num != 0)
			{
				ProcessResults(num);
			}
		}
		if (accessor == null)
		{
			accessor = accessorArray[num2];
		}
		accessor.CurrentIndex = bindingIndex[index];
		metaData.value = accessor.Value;
		if (!metaData.typeMap.isFixed)
		{
			metaData.size = (uint)accessor.SizeValue;
		}
		if (metaData.typeMap.isBLOB && !(metaData.value is DBNull))
		{
			lastBlobColumn = index;
		}
		return accessor;
	}

	internal void ProcessResults(int hr)
	{
		Exception ex = null;
		if (connection != null)
		{
			ex = connection.ProcessResults(hr, pError, this);
		}
		if (ex != null)
		{
			throw ex;
		}
	}

	public override bool NextResult()
	{
		return false;
	}

	protected virtual void OnMove()
	{
	}

	public override bool Read()
	{
		if (IntPtr.Zero != pSeCursor)
		{
			if (CursorPosition.AfterLast == cursorPosition)
			{
				return false;
			}
			bool result = Move(DIRECTION.MOVE_NEXT);
			OnMove();
			if ((CommandBehavior.SingleRow & behavior) != 0)
			{
				cursorPosition = CursorPosition.AfterLast;
			}
			return result;
		}
		if (isClosed)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "Read"));
		}
		return false;
	}

	internal bool Move(DIRECTION direction)
	{
		int num = 0;
		if (isOnRow)
		{
			ReleaseCurrentRow();
		}
		sequentialOrdinal = -1;
		sequentialUnitsRead = 0L;
		if (CursorPosition.AfterLast == cursorPosition && direction == DIRECTION.MOVE_NEXT)
		{
			return false;
		}
		if (CursorPosition.BeforeFirst == cursorPosition && DIRECTION.MOVE_PREVIOUS == direction)
		{
			return false;
		}
		if (CursorPosition.OnRow != cursorPosition || DIRECTION.MOVE_LAST == direction || DIRECTION.MOVE_FIRST == direction)
		{
			if (isBaseTableCursor)
			{
				num = NativeMethods.Move(pSeCursor, direction, pError);
				if (IsEndOfRowset(num))
				{
					return false;
				}
				cursorPosition = CursorPosition.OnRow;
				isOnRow = true;
				return true;
			}
			FETCH fETCH = FETCH.UNKNOWN;
			switch (direction)
			{
			case DIRECTION.MOVE_NEXT:
			case DIRECTION.MOVE_FIRST:
			case DIRECTION.MOVE_LAST:
				fETCH = FETCH.FORWARD;
				break;
			case DIRECTION.MOVE_PREVIOUS:
				fETCH = FETCH.BACKWARD;
				break;
			}
			num = Move(pSeCursor, direction);
			if (IsEndOfRowset(num))
			{
				if (FETCH.FORWARD == fETCH)
				{
					fetchDirection = FETCH.BACKWARD;
					cursorPosition = CursorPosition.AfterLast;
				}
				else
				{
					fetchDirection = FETCH.FORWARD;
					cursorPosition = CursorPosition.BeforeFirst;
				}
				return false;
			}
			if (fetchDirection != fETCH)
			{
				fetchDirection = fETCH;
				num = Move(pSeCursor, direction);
				if (IsEndOfRowset(num))
				{
					if (FETCH.FORWARD == fETCH)
					{
						fetchDirection = FETCH.BACKWARD;
						cursorPosition = CursorPosition.AfterLast;
					}
					else
					{
						fetchDirection = FETCH.FORWARD;
						cursorPosition = CursorPosition.BeforeFirst;
					}
					return false;
				}
			}
		}
		cursorPosition = CursorPosition.OnRow;
		isOnRow = true;
		return true;
	}

	private int Move(IntPtr pSeCursor, DIRECTION direction)
	{
		int num = NativeMethods.Move(this.pSeCursor, direction, pError);
		if (-2147217906 == num || -2147217885 == num)
		{
			if (DIRECTION.MOVE_FIRST == direction)
			{
				direction = DIRECTION.MOVE_NEXT;
			}
			else if (DIRECTION.MOVE_LAST == direction)
			{
				direction = DIRECTION.MOVE_PREVIOUS;
			}
		}
		while (-2147217906 == num || -2147217885 == num)
		{
			num = NativeMethods.Move(this.pSeCursor, direction, pError);
		}
		return num;
	}

	private bool IsEndOfRowset(int hr)
	{
		if (NativeMethods.Failed(hr))
		{
			int lMinor = 0;
			NativeMethods.GetMinorError(pError, ref lMinor);
			if (25001 == lMinor)
			{
				NativeMethods.ClearErrorInfo(pError);
				return true;
			}
			ProcessResults(hr);
		}
		return false;
	}

	internal void ReleaseCurrentRow()
	{
		if (cursorPosition == CursorPosition.Undefined)
		{
			return;
		}
		currAccessor = -1;
		lastBlobColumn = -1;
		for (int i = 0; i < fieldCount; i++)
		{
			MetaData metaData = metadata[i];
			if (metaData.value != null && metaData.value is IntPtr && metaData.typeMap.isBLOB)
			{
				IntPtr ppUnknown = (IntPtr)metaData.value;
				NativeMethods.SafeRelease(ref ppUnknown);
			}
			metaData.value = null;
		}
		isOnRow = false;
		cursorPosition = CursorPosition.Undefined;
	}

	internal void CreateAccessors(SqlCeCommand command, int columnCount, bool allowMultipleAccessor)
	{
		CreateBindingsFromMetaData(command, columnCount, allowMultipleAccessor);
		for (int i = 0; i < accessorArray.Length; i++)
		{
			if (accessorArray[i] != null)
			{
				accessorArray[i].AllocData();
			}
		}
	}

	private void CreateBindingsFromMetaData(SqlCeCommand command, int columnCount, bool allowMultipleAccessor)
	{
		int num = 0;
		int num2 = 0;
		accessorIndex = new int[columnCount];
		bindingIndex = new int[columnCount];
		int num3 = 0;
		int num4 = 1;
		int num5 = 0;
		if (allowMultipleAccessor)
		{
			for (int i = 0; i < columnCount; i++)
			{
				if (metadata[i].typeMap.isBLOB)
				{
					accessorIndex[i] = num4++;
					bindingIndex[i] = 0;
				}
				else
				{
					accessorIndex[i] = 0;
					bindingIndex[i] = num3++;
				}
			}
		}
		else
		{
			for (int j = 0; j < columnCount; j++)
			{
				accessorIndex[j] = 0;
				bindingIndex[j] = num3++;
			}
			num5 = 1;
		}
		if (useIndex)
		{
			num4++;
		}
		accessorArray = new Accessor[num4];
		Accessor accessor;
		for (int k = 0; k < columnCount; k++)
		{
			num2 = accessorIndex[k];
			accessor = accessorArray[num2];
			if (accessor == null)
			{
				num5 = 1;
				if (num2 == 0 && num3 > 0)
				{
					num5 = num3;
				}
				accessor = (accessorArray[num2] = new Accessor(num5));
			}
			MetaData metaData = metadata[k];
			num = bindingIndex[k];
			accessor.CurrentIndex = num;
			accessor.Ordinal = (int)metaData.ordinal;
			if (metaData.typeMap.isBLOB)
			{
				tagDBOBJECT tagDBOBJECT2 = new tagDBOBJECT
				{
					dwFlags = 0
				};
				if (sequentialAccess)
				{
					tagDBOBJECT2.iid = ADP.IID_ISequentialStream;
				}
				else
				{
					tagDBOBJECT2.iid = ADP.IID_ILockBytes;
				}
				IntPtr intPtr = NativeMethods.CoTaskMemAlloc(ADP.SizeOf_tagDBOBJECT);
				if (IntPtr.Zero == intPtr)
				{
					throw new OutOfMemoryException();
				}
				Marshal.StructureToPtr((object)tagDBOBJECT2, intPtr, false);
				accessor.ObjectPtr = intPtr;
			}
			int num6 = metaData.typeMap.fixlen;
			if (metaData.typeMap.isBLOB)
			{
				num6 = IntPtr.Size;
			}
			else if (-1 == num6)
			{
				num6 = (int)(((object)typeof(string) != metaData.typeMap.clrType) ? metaData.size : (metaData.size + 2));
			}
			accessor.MaxLen = num6;
			accessor.SeType = metaData.typeMap.seType;
			accessor.Precision = metaData.SqlMetaData.Precision;
			accessor.Scale = metaData.SqlMetaData.Scale;
		}
		if (!useIndex)
		{
			return;
		}
		num2 = num4 - 1;
		MetaData metaData2 = null;
		accessor = (accessorArray[num2] = new Accessor(indexColumnCount));
		for (int l = 0; l < indexColumnCount; l++)
		{
			for (int m = 0; m < metadata.Length; m++)
			{
				if (metadata[m].ordinal == command.indexColOrdinals[l])
				{
					metaData2 = metadata[m];
					break;
				}
			}
			int num7 = metaData2.typeMap.fixlen;
			SETYPE seType = metaData2.typeMap.seType;
			if (-1 == num7)
			{
				num7 = (int)(((object)typeof(string) != metaData2.typeMap.clrType) ? metaData2.size : (metaData2.size + 2));
			}
			accessor.CurrentIndex = l;
			accessor.Ordinal = (int)metaData2.ordinal;
			accessor.MaxLen = num7;
			accessor.SeType = seType;
			accessor.Precision = metaData2.SqlMetaData.Precision;
			accessor.Scale = metaData2.SqlMetaData.Scale;
		}
		accessor.NumValues = accessor.Count * 2;
		accessor.ActualDataBufferSize = accessor.DataBufferSize * 2;
	}

	public override bool GetBoolean(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (bool)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override decimal GetDecimal(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			if (metaData.value is SqlDecimal)
			{
				return (decimal)(SqlDecimal)metaData.value;
			}
			return (decimal)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override byte GetByte(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (byte)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	private void DoSequentialCheck(int ordinal, long dataIndex, string method)
	{
		if (sequentialOrdinal != ordinal)
		{
			sequentialOrdinal = ordinal;
			sequentialUnitsRead = 0L;
			if (0 != dataIndex)
			{
				throw new InvalidOperationException(Res.GetString("ADP_NonSeqByteAccess", dataIndex.ToString(CultureInfo.CurrentCulture), sequentialUnitsRead.ToString(CultureInfo.CurrentCulture), method));
			}
		}
		else if (sequentialUnitsRead != dataIndex)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NonSeqByteAccess", dataIndex.ToString(CultureInfo.CurrentCulture), sequentialUnitsRead.ToString(CultureInfo.CurrentCulture), method));
		}
	}

	public override long GetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (IntPtr.Zero == pSeCursor)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		if ((object)metaData.typeMap.clrType != typeof(byte[]))
		{
			throw new InvalidCastException(Res.GetString("SQLCE_InvalidBaseColumnType", "GetBytes", metaData.typeMap.SqlDbType.ToString()));
		}
		if (buffer == null)
		{
			return metaData.size;
		}
		if (sequentialAccess)
		{
			DoSequentialCheck(ordinal, dataIndex, "SqlCeDataReader:GetBytes");
		}
		if ((int)dataIndex > metaData.size || metaData.size == 0)
		{
			return 0L;
		}
		if (dataIndex < 0)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", buffer.Length, dataIndex));
		}
		if (bufferIndex < 0 || bufferIndex >= buffer.Length)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidDestinationBufferIndex", buffer.Length, bufferIndex));
		}
		int num = buffer.Length - bufferIndex;
		int num2 = (int)(metaData.size - dataIndex);
		if (length > num && num2 > num)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_TooManyBytesAvailable", num2, num));
		}
		int num3 = Math.Min(buffer.Length - bufferIndex, length);
		if (num3 < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.CurrentCulture)));
		}
		if (dataIndex > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", num3.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (!metaData.typeMap.isBLOB)
		{
			byte[] array = (byte[])metaData.value;
			if (array.Length - dataIndex < num3)
			{
				num3 = array.Length - (int)dataIndex;
			}
			Buffer.BlockCopy(array, (int)dataIndex, buffer, bufferIndex, num3);
			sequentialUnitsRead = dataIndex + num3;
			return num3;
		}
		num3 = GetBytes(metaData, buffer, (int)dataIndex, bufferIndex, num3);
		if (num3 > 0)
		{
			sequentialUnitsRead = bufferIndex + num3;
			return num3;
		}
		return 0L;
	}

	public override long GetChars(int ordinal, long dataIndex, char[] buffer, int bufferIndex, int length)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (IntPtr.Zero == pSeCursor)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		if ((object)metaData.typeMap.clrType != typeof(string))
		{
			throw new InvalidCastException(Res.GetString("SQLCE_InvalidBaseColumnType", "GetChars", metaData.typeMap.SqlDbType.ToString()));
		}
		if (buffer == null)
		{
			return metaData.size / 2;
		}
		if (sequentialAccess)
		{
			DoSequentialCheck(ordinal, dataIndex, "GetChars");
		}
		if ((int)dataIndex > metaData.size / 2 || metaData.size == 0)
		{
			return 0L;
		}
		if (dataIndex < 0)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", buffer.Length, dataIndex));
		}
		if (bufferIndex < 0 || bufferIndex >= buffer.Length)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidDestinationBufferIndex", buffer.Length, bufferIndex));
		}
		int num = buffer.Length - bufferIndex;
		int num2 = (int)(metaData.size / 2 - dataIndex);
		if (length > num && num2 > num)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_TooManyCharsAvailable", num2, num));
		}
		int num3 = Math.Min(buffer.Length - bufferIndex, length);
		if (dataIndex > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", num3.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (num3 < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.CurrentCulture)));
		}
		if (!metaData.typeMap.isBLOB)
		{
			string text = (string)metaData.value;
			if (text.Length - dataIndex < length)
			{
				num3 = text.Length - (int)dataIndex;
			}
			text.CopyTo((int)dataIndex, buffer, bufferIndex, num3);
			sequentialUnitsRead = dataIndex + num3;
			return num3;
		}
		num3 = GetChars(metaData, buffer, (int)dataIndex, bufferIndex, num3);
		if (num3 > 0)
		{
			sequentialUnitsRead = bufferIndex + num3;
			return num3;
		}
		return 0L;
	}

	public override string GetDataTypeName(int index)
	{
		if (metadata != null)
		{
			return metadata[index].typeMap.ToString();
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override DateTime GetDateTime(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (DateTime)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override double GetDouble(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (double)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override Type GetFieldType(int ordinal)
	{
		if (metadata != null)
		{
			return metadata[ordinal].typeMap.clrType;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override Type GetProviderSpecificFieldType(int ordinal)
	{
		if (metadata != null)
		{
			SqlDbType sqlDbType = metadata[ordinal].typeMap.sqlDbType;
			return SqlCeType.SqlDbType2SqlType(sqlDbType);
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override float GetFloat(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (float)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override Guid GetGuid(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (Guid)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override short GetInt16(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (short)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override int GetInt32(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value is int)
		{
			return (int)metaData.value;
		}
		if (metaData.value is uint)
		{
			return Convert.ToInt32((uint)metaData.value, CultureInfo.CurrentCulture);
		}
		if (metaData.value != null)
		{
			throw new InvalidCastException();
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override long GetInt64(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			return (long)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override string GetName(int index)
	{
		if (metadata != null)
		{
			return metadata[index].ColumnName;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override int GetOrdinal(string name)
	{
		if (fieldNameLookup == null)
		{
			if (metadata == null)
			{
				throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
			}
			fieldNameLookup = new FieldNameLookup(this, -1);
		}
		return fieldNameLookup.GetOrdinal(name);
	}

	public override string GetString(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException(Res.GetString("SQLCE_ColumnContainsDbNullValue", ordinal));
		}
		MetaData metaData = metadata[ordinal];
		if (IntPtr.Zero != pSeCursor)
		{
			if (metaData.typeMap.isBLOB)
			{
				return (string)GetLongValue(metaData, ordinal);
			}
			return (string)metaData.value;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public override object GetValue(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return DBNull.Value;
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.typeMap.isBLOB)
		{
			return GetLongValue(metaData, ordinal);
		}
		if (metaData.value is SqlDecimal)
		{
			return (decimal)(SqlDecimal)metaData.value;
		}
		return metaData.value;
	}

	public override int GetValues(object[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (!isOnRow || IntPtr.Zero == pSeCursor)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		int num = Math.Min(values.Length, FieldCount);
		if (IntPtr.Zero != pSeCursor)
		{
			for (int i = 0; i < num; i++)
			{
				MetaData metaData = metadata[i];
				if (metaData.value == null)
				{
					FetchValue(i);
				}
				if (metaData.typeMap.isBLOB)
				{
					values[i] = GetLongValue(metaData, i);
				}
				else if (metaData.value is SqlDecimal)
				{
					values[i] = (decimal)(SqlDecimal)metaData.value;
				}
				else
				{
					values[i] = metaData.value;
				}
			}
			return num;
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	private object GetLongValue(MetaData info, int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return DBNull.Value;
		}
		if ((object)typeof(byte[]) == info.typeMap.clrType)
		{
			byte[] array = new byte[info.size];
			GetBytes(info, array, 0, 0, (int)info.size);
			return array;
		}
		int num = (int)info.size / 2;
		char[] array2 = new char[num];
		GetChars(info, array2, 0, 0, num);
		return new string(array2);
	}

	private unsafe int GetBytes(MetaData info, byte[] buffer, int dataIndex, int bufferIndex, int cb)
	{
		int num = 0;
		int bytesRead = 0;
		if (buffer.Length == 0)
		{
			return 0;
		}
		fixed (void* pBuffer = buffer)
		{
			num = (sequentialAccess ? NativeMethods.Read((IntPtr)info.value, pBuffer, bufferIndex, cb, out bytesRead, pError) : NativeMethods.ReadAt((IntPtr)info.value, dataIndex, pBuffer, bufferIndex, cb, out bytesRead, pError));
		}
		if (num != 0)
		{
			ProcessResults(num);
		}
		return bytesRead;
	}

	private unsafe int GetChars(MetaData info, char[] buffer, int dataIndex, int bufferIndex, int cch)
	{
		int num = 0;
		int bytesRead = 0;
		if (buffer.Length == 0)
		{
			return 0;
		}
		fixed (void* pBuffer = buffer)
		{
			num = (sequentialAccess ? NativeMethods.Read((IntPtr)info.value, pBuffer, bufferIndex * 2, cch * 2, out bytesRead, pError) : NativeMethods.ReadAt((IntPtr)info.value, dataIndex * 2, pBuffer, bufferIndex * 2, cch * 2, out bytesRead, pError));
		}
		if (num != 0)
		{
			ProcessResults(num);
		}
		return bytesRead / 2;
	}

	public virtual SqlBoolean GetSqlBoolean(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlBoolean.Null;
		}
		return new SqlBoolean(GetBoolean(ordinal));
	}

	public virtual SqlMoney GetSqlMoney(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlMoney.Null;
		}
		return new SqlMoney(GetDecimal(ordinal));
	}

	public virtual SqlDecimal GetSqlDecimal(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDecimal.Null;
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value != null)
		{
			if (metaData.value is SqlDecimal)
			{
				return (SqlDecimal)metaData.value;
			}
			return new SqlDecimal((decimal)metaData.value);
		}
		throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
	}

	public virtual SqlByte GetSqlByte(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlByte.Null;
		}
		return new SqlByte(GetByte(ordinal));
	}

	public virtual SqlBinary GetSqlBinary(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlBinary.Null;
		}
		int num = (int)GetBytes(ordinal, 0L, null, 0, 0);
		byte[] array = new byte[num];
		if (num > 0)
		{
			GetBytes(ordinal, 0L, array, 0, num);
		}
		return new SqlBinary(array);
	}

	public virtual SqlDateTime GetSqlDateTime(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDateTime.Null;
		}
		return new SqlDateTime(GetDateTime(ordinal));
	}

	public virtual SqlDouble GetSqlDouble(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDouble.Null;
		}
		return new SqlDouble(GetDouble(ordinal));
	}

	public virtual SqlSingle GetSqlSingle(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlSingle.Null;
		}
		return new SqlSingle(GetFloat(ordinal));
	}

	public virtual SqlGuid GetSqlGuid(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlGuid.Null;
		}
		return new SqlGuid(GetGuid(ordinal));
	}

	public virtual SqlInt16 GetSqlInt16(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt16.Null;
		}
		return new SqlInt16(GetInt16(ordinal));
	}

	public virtual SqlInt32 GetSqlInt32(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt32.Null;
		}
		return new SqlInt32(GetInt32(ordinal));
	}

	public virtual SqlInt64 GetSqlInt64(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt64.Null;
		}
		return new SqlInt64(GetInt64(ordinal));
	}

	public virtual SqlString GetSqlString(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlString.Null;
		}
		return new SqlString(GetString(ordinal));
	}

	public override bool IsDBNull(int ordinal)
	{
		if (!isOnRow || IntPtr.Zero == pSeCursor)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		if (sequentialAccess && ordinal != sequentialOrdinal)
		{
			if (ordinal < sequentialOrdinal)
			{
				throw new InvalidOperationException(Res.GetString("ADP_NonSequentialColumnAccess", ordinal.ToString(CultureInfo.CurrentCulture), sequentialOrdinal.ToString(CultureInfo.CurrentCulture)));
			}
			sequentialOrdinal = ordinal;
			sequentialUnitsRead = 0L;
		}
		MetaData metaData = metadata[ordinal];
		if (metaData.value == null && IntPtr.Zero != pSeCursor)
		{
			FetchValue(ordinal);
		}
		return metaData.value is DBNull;
	}

	public override IEnumerator GetEnumerator()
	{
		return new DbEnumerator((IDataReader)this, IsCommandBehavior(CommandBehavior.CloseConnection));
	}

	public override char GetChar(int ordinal)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "GetChar", new object[0]);
		throw new NotSupportedException(message);
	}
}
