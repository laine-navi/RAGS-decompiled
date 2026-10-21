using System.Collections;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace System.Data.SqlServerCe;

public class SqlCeResultSet : SqlCeDataReader, IEnumerable, IListSource
{
	private bool isInitialized;

	private ArrayList bookmarkArray;

	private SqlCeUpdatableRecord sqlUpdatableRecord;

	private ResultSetChangedEventHandler onResultSetChanged;

	public override object this[int index]
	{
		get
		{
			if (HasColumnChanged(index))
			{
				return sqlUpdatableRecord[index];
			}
			return base[index];
		}
	}

	public override object this[string name]
	{
		get
		{
			if (HasColumnChanged(GetOrdinal(name)))
			{
				return sqlUpdatableRecord[name];
			}
			return base[name];
		}
	}

	public bool Updatable
	{
		get
		{
			if (IsClosed)
			{
				throw new InvalidOperationException(Res.GetString("SQL_SqlResultSetClosed", "Updatable"));
			}
			return 0 != (cursorCapabilities & ResultSetOptions.Updatable);
		}
	}

	public bool Scrollable
	{
		get
		{
			if (IsClosed)
			{
				throw new InvalidOperationException(Res.GetString("SQL_SqlResultSetClosed", "Scrollable"));
			}
			return 0 != (cursorCapabilities & ResultSetOptions.Scrollable);
		}
	}

	public ResultSetSensitivity Sensitivity
	{
		get
		{
			ResultSetOptions resultSetOptions = cursorCapabilities;
			if (IsClosed)
			{
				throw new InvalidOperationException(Res.GetString("SQL_SqlResultSetClosed", "Sensitivity"));
			}
			if ((resultSetOptions & ResultSetOptions.Sensitive) != 0)
			{
				return ResultSetSensitivity.Sensitive;
			}
			if ((resultSetOptions & ResultSetOptions.Insensitive) != 0)
			{
				return ResultSetSensitivity.Insensitive;
			}
			return ResultSetSensitivity.Asensitive;
		}
	}

	internal ArrayList BookmarkArray
	{
		get
		{
			if (!Scrollable)
			{
				throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
			}
			if (bookmarkArray != null)
			{
				return bookmarkArray;
			}
			int num = 0;
			int hBookmark = 0;
			bookmarkArray = new ArrayList();
			if (!Move(DIRECTION.MOVE_FIRST))
			{
				return bookmarkArray;
			}
			bool flag = false;
			while (!flag)
			{
				num = NativeMethods.GetBookmark(pSeCursor, ref hBookmark, pError);
				if (num == 0)
				{
					bookmarkArray.Add(hBookmark);
					num = NativeMethods.Move(pSeCursor, DIRECTION.MOVE_NEXT, pError);
				}
				if (!NativeMethods.Failed(num))
				{
					continue;
				}
				int lMinor = 0;
				num = NativeMethods.GetMinorError(pError, ref lMinor);
				if (25001 != lMinor)
				{
					if (num != 0)
					{
						ProcessResults(num);
					}
				}
				else
				{
					NativeMethods.ClearErrorInfo(pError);
					flag = true;
				}
			}
			Move(DIRECTION.MOVE_FIRST);
			Move(DIRECTION.MOVE_PREVIOUS);
			return bookmarkArray;
		}
	}

	bool IListSource.ContainsListCollection => ContainsListCollection;

	protected bool ContainsListCollection => false;

	public ResultSetView ResultSetView => (ResultSetView)((IListSource)this).GetList();

	internal event ResultSetChangedEventHandler ResultSetChanged
	{
		add
		{
			onResultSetChanged = (ResultSetChangedEventHandler)Delegate.Combine(onResultSetChanged, value);
		}
		remove
		{
			onResultSetChanged = (ResultSetChangedEventHandler)Delegate.Remove(onResultSetChanged, value);
		}
	}

	protected SqlCeResultSet()
	{
		NativeMethods.LoadNativeBinaries();
	}

	internal SqlCeResultSet(SqlCeConnection connection, SqlCeCommand command)
		: base(connection, command)
	{
		NativeMethods.LoadNativeBinaries();
	}

	private void OnResultSetChanged(object sender, ResultSetChangedEventArgs e)
	{
		if (onResultSetChanged != null)
		{
			onResultSetChanged(sender, e);
		}
	}

	IList IListSource.GetList()
	{
		return GetList();
	}

	protected IList GetList()
	{
		return new ResultSetView(this);
	}

	internal bool GotoRow(int hBookmark)
	{
		int num = 0;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeResultSet");
		}
		if (isOnRow)
		{
			ReleaseCurrentRow();
		}
		num = NativeMethods.GotoBookmark(pSeCursor, hBookmark, pError);
		if (NativeMethods.Failed(num))
		{
			if (-2147217906 == num)
			{
				return false;
			}
			SqlCeException ex = connection.ProcessResults(num, pError, this);
			throw ex;
		}
		cursorPosition = CursorPosition.OnRow;
		isOnRow = true;
		fetchDirection = FETCH.FORWARD;
		OnMove();
		return true;
	}

	private void InitializeMetaData()
	{
		if (metadata == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		if (fieldNameLookup == null)
		{
			fieldNameLookup = new FieldNameLookup(this, -1);
		}
		isInitialized = true;
	}

	internal void InternalUpdate(object sender)
	{
		int hBookmark = -1;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeResultSet");
		}
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotUpdatable"));
		}
		if (!isOnRow)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		if (sqlUpdatableRecord == null)
		{
			return;
		}
		int num = NativeMethods.Prepare(pSeCursor, SEPREPAREMODE.PREP_UPDATE, pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
		try
		{
			SetValues(SEPREPAREMODE.PREP_UPDATE, sqlUpdatableRecord);
			num = NativeMethods.UpdateRecord(pSeCursor, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			if (onResultSetChanged != null && bookmarkArray != null)
			{
				num = NativeMethods.GetBookmark(pSeCursor, ref hBookmark, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
				OnResultSetChanged(sender, new ResultSetChangedEventArgs(ChangeType.RowUpdated, new RowView(hBookmark)));
			}
			ReleaseCurrentRow();
			isOnRow = true;
			cursorPosition = CursorPosition.OnRow;
		}
		catch (Exception ex)
		{
			NativeMethods.Prepare(pSeCursor, SEPREPAREMODE.PREP_CANCEL, pError);
			throw ex;
		}
	}

	internal void RemoveBookmarkFromCache(int hBookmark)
	{
		if (bookmarkArray == null)
		{
			return;
		}
		int num = bookmarkArray.IndexOf(hBookmark);
		if (-1 != num)
		{
			bookmarkArray.RemoveAt(num);
			if (onResultSetChanged != null)
			{
				OnResultSetChanged(this, new ResultSetChangedEventArgs(ChangeType.RowDeleted, new RowView(hBookmark)));
			}
		}
	}

	internal int InternalInsert(bool fMoveTo, object sender, SqlCeUpdatableRecord record)
	{
		int num = 0;
		int hBookmark = 0;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeResultSet");
		}
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotUpdatable"));
		}
		num = NativeMethods.Prepare(pSeCursor, SEPREPAREMODE.PREP_INSERT, pError);
		if (num != 0)
		{
			ProcessResults(num);
		}
		try
		{
			SetValues(SEPREPAREMODE.PREP_INSERT, record);
			num = NativeMethods.InsertRecord(fMoveTo ? 1 : 0, pSeCursor, ref hBookmark, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			if (fMoveTo)
			{
				if (isOnRow)
				{
					ReleaseCurrentRow();
				}
				isOnRow = true;
				cursorPosition = CursorPosition.OnRow;
				OnMove();
			}
			if (bookmarkArray != null)
			{
				bookmarkArray.Add(hBookmark);
				if (onResultSetChanged != null)
				{
					OnResultSetChanged(sender, new ResultSetChangedEventArgs(ChangeType.RowInserted, new RowView(null, hBookmark, record)));
				}
			}
			return hBookmark;
		}
		catch (Exception ex)
		{
			NativeMethods.Prepare(pSeCursor, SEPREPAREMODE.PREP_CANCEL, pError);
			throw ex;
		}
	}

	private unsafe void SetValues(SEPREPAREMODE mode, SqlCeUpdatableRecord record)
	{
		int num = 0;
		int num2 = record.FieldCount;
		Accessor accessor = null;
		if (record == null)
		{
			throw new ArgumentException(record.GetType().ToString());
		}
		ColumnUpdatedStatus[] columnsUpdatedStatus = record.ColumnsUpdatedStatus;
		if (columnsUpdatedStatus == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < num2; i++)
			{
				bool flag = false;
				bool flag2 = false;
				SqlCeType typeMap = metadata[i].typeMap;
				if (columnsUpdatedStatus[i] == ColumnUpdatedStatus.None)
				{
					flag = true;
				}
				if (ColumnUpdatedStatus.ServerDefault == columnsUpdatedStatus[i])
				{
					flag2 = true;
				}
				if (!typeMap.isBLOB)
				{
					accessor = accessorArray[accessorIndex[i]];
					accessor.CurrentIndex = bindingIndex[i];
					if (flag)
					{
						accessor.StatusValue = DBStatus.S_IGNORE;
					}
					else if (flag2)
					{
						accessor.StatusValue = DBStatus.S_DEFAULT;
					}
					else
					{
						accessor.Value = record.values[i];
					}
				}
				else
				{
					if (flag)
					{
						continue;
					}
					if (flag2)
					{
						num = NativeMethods.SetValue(pSeCursor, 2, null, i, 0, pError);
						if (num != 0)
						{
							ProcessResults(num);
						}
					}
					else if (record.IsDBNull(i))
					{
						num = NativeMethods.SetValue(pSeCursor, 0, null, i, 0, pError);
						if (num != 0)
						{
							ProcessResults(num);
						}
					}
					else if (SqlDbType.NText == typeMap.sqlDbType)
					{
						object obj = record.values[i];
						if (obj is char[])
						{
							char[] array = (char[])obj;
							int size = array.Length * 2;
							fixed (char* pBuffer = array)
							{
								num = NativeMethods.SetValue(pSeCursor, 0, pBuffer, i, size, pError);
								if (num != 0)
								{
									ProcessResults(num);
								}
							}
						}
						else
						{
							if (!(obj is string))
							{
								continue;
							}
							string text = (string)obj;
							int size2 = text.Length * 2;
							fixed (char* pBuffer2 = text)
							{
								num = NativeMethods.SetValue(pSeCursor, 0, pBuffer2, i, size2, pError);
								if (num != 0)
								{
									ProcessResults(num);
								}
							}
						}
					}
					else
					{
						if (SqlDbType.Image != typeMap.sqlDbType)
						{
							continue;
						}
						byte[] array2 = (byte[])record.values[i];
						int size3 = array2.Length;
						fixed (void* pBuffer3 = array2)
						{
							num = NativeMethods.SetValue(pSeCursor, 0, pBuffer3, i, size3, pError);
							if (num != 0)
							{
								ProcessResults(num);
							}
						}
					}
				}
			}
			if (accessorArray[0] == null)
			{
				return;
			}
			accessor = accessorArray[0];
			fixed (void* dbBinding = accessor.DbBinding)
			{
				IntPtr prgBinding = (IntPtr)dbBinding;
				num = NativeMethods.SetValues(connection.IQPServices, pSeCursor, prgBinding, accessor.Count, accessor.DataHandle, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
		}
		catch (SqlCeException ex)
		{
			NativeMethods.Prepare(pSeCursor, SEPREPAREMODE.PREP_CANCEL, pError);
			throw ex;
		}
	}

	protected override void OnMove()
	{
		if (sqlUpdatableRecord != null)
		{
			ColumnUpdatedStatus[] columnsUpdatedStatus = sqlUpdatableRecord.ColumnsUpdatedStatus;
			for (int i = 0; i < columnsUpdatedStatus.Length; i++)
			{
				columnsUpdatedStatus[i] = ColumnUpdatedStatus.None;
			}
		}
	}

	internal SqlCeUpdatableRecord GetCurrentRecord()
	{
		if (!isInitialized)
		{
			InitializeMetaData();
		}
		SqlCeUpdatableRecord sqlCeUpdatableRecord = new SqlCeUpdatableRecord(metadata, null, updatable: true, 0, fieldNameLookup);
		for (int i = 0; i < FieldCount; i++)
		{
			if (SETYPE.NUMERIC == metadata[i].typeMap.seType)
			{
				sqlCeUpdatableRecord[i] = GetSqlDecimal(i);
			}
			else
			{
				sqlCeUpdatableRecord[i] = GetValue(i);
			}
			sqlCeUpdatableRecord.ColumnsUpdatedStatus[i] = ColumnUpdatedStatus.None;
		}
		return sqlCeUpdatableRecord;
	}

	private void ValidateSet(string method)
	{
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotUpdatable"));
		}
		if (!isInitialized)
		{
			InitializeMetaData();
		}
		if (sqlUpdatableRecord == null)
		{
			if (!isInitialized)
			{
				InitializeMetaData();
			}
			sqlUpdatableRecord = new SqlCeUpdatableRecord(metadata, null, updatable: true, 0, fieldNameLookup);
		}
	}

	private bool HasColumnChanged(int ordinal)
	{
		if (sqlUpdatableRecord == null)
		{
			return false;
		}
		return sqlUpdatableRecord.ColumnsUpdatedStatus[ordinal] switch
		{
			ColumnUpdatedStatus.None => false, 
			ColumnUpdatedStatus.ServerDefault => throw new InvalidOperationException(Res.GetString("SQLCE_UnableToFetchDefaultValue")), 
			_ => true, 
		};
	}

	public SqlCeUpdatableRecord CreateRecord()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeResultSet");
		}
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotUpdatable"));
		}
		if (!isInitialized)
		{
			InitializeMetaData();
		}
		return new SqlCeUpdatableRecord(metadata, null, Updatable, 0, fieldNameLookup);
	}

	public void Update()
	{
		InternalUpdate(this);
	}

	public void Delete()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeResultSet");
		}
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotUpdatable"));
		}
		if (!isOnRow)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		try
		{
			int num = 0;
			int hBookmark = -1;
			if (bookmarkArray != null)
			{
				num = NativeMethods.GetBookmark(pSeCursor, ref hBookmark, pError);
				if (num != 0)
				{
					ProcessResults(num);
				}
			}
			num = NativeMethods.DeleteRecord(pSeCursor, pError);
			if (num != 0)
			{
				ProcessResults(num);
			}
			RemoveBookmarkFromCache(hBookmark);
		}
		finally
		{
			ReleaseCurrentRow();
		}
	}

	public void Insert(SqlCeUpdatableRecord record)
	{
		InternalInsert(fMoveTo: false, this, record);
	}

	public void Insert(SqlCeUpdatableRecord record, DbInsertOptions options)
	{
		if ((DbInsertOptions.PositionOnInsertedRow & options) != 0 && (DbInsertOptions.KeepCurrentPosition & options) != 0)
		{
			throw new ArgumentException(options.ToString());
		}
		bool fMoveTo = ((DbInsertOptions.PositionOnInsertedRow == options) ? true : false);
		InternalInsert(fMoveTo, this, record);
	}

	public bool ReadFirst()
	{
		if (!Scrollable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
		}
		if (IntPtr.Zero != pSeCursor)
		{
			bool result = Move(DIRECTION.MOVE_FIRST);
			OnMove();
			return result;
		}
		if (IsClosed)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "ReadFirst"));
		}
		return false;
	}

	public bool ReadLast()
	{
		if (!Scrollable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
		}
		if (IntPtr.Zero != pSeCursor)
		{
			bool result = Move(DIRECTION.MOVE_LAST);
			OnMove();
			return result;
		}
		if (IsClosed)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "ReadLast"));
		}
		return false;
	}

	public bool ReadPrevious()
	{
		if (!Scrollable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
		}
		if (IntPtr.Zero != pSeCursor)
		{
			if (CursorPosition.BeforeFirst == cursorPosition)
			{
				return false;
			}
			bool result = Move(DIRECTION.MOVE_PREVIOUS);
			OnMove();
			return result;
		}
		if (IsClosed)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "ReadPrevious"));
		}
		return false;
	}

	public bool ReadAbsolute(int position)
	{
		if (!Scrollable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
		}
		ArrayList arrayList = BookmarkArray;
		if (isOnRow)
		{
			ReleaseCurrentRow();
		}
		if (position >= 0 && position < arrayList.Count)
		{
			return GotoRow((int)arrayList[position]);
		}
		if (position < 0 && Math.Abs(position) <= arrayList.Count)
		{
			return GotoRow((int)arrayList[arrayList.Count + position]);
		}
		return false;
	}

	public bool ReadRelative(int position)
	{
		bool flag = true;
		if (!Scrollable)
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_CursorNotScrollable"));
		}
		if (position == 0)
		{
			return isOnRow;
		}
		if (IntPtr.Zero != pSeCursor)
		{
			while (flag && position > 0)
			{
				position--;
				flag = Move(DIRECTION.MOVE_NEXT);
			}
			while (flag && position < 0)
			{
				position++;
				flag = Move(DIRECTION.MOVE_PREVIOUS);
			}
		}
		else if (IsClosed)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderClosed", "ReadRelative"));
		}
		OnMove();
		return flag;
	}

	public void SetDefault(int ordinal)
	{
		ValidateSet("SetDefault");
		sqlUpdatableRecord.ColumnsUpdatedStatus[ordinal] = ColumnUpdatedStatus.ServerDefault;
	}

	public bool IsSetAsDefault(int ordinal)
	{
		ValidateSet("IsSetAsDefault");
		if (ColumnUpdatedStatus.ServerDefault == sqlUpdatableRecord.ColumnsUpdatedStatus[ordinal])
		{
			return true;
		}
		return false;
	}

	public override IEnumerator GetEnumerator()
	{
		return ((IEnumerable)this).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		ResultSetEnumerator resultSetEnumerator = new ResultSetEnumerator(this);
		resultSetEnumerator.Reset();
		return resultSetEnumerator;
	}

	public SqlMetaData GetSqlMetaData(int ordinal)
	{
		if (metadata == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_DataReaderNoData"));
		}
		return metadata[ordinal].SqlMetaData;
	}

	public override bool IsDBNull(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.IsDBNull(ordinal);
		}
		return base.IsDBNull(ordinal);
	}

	public override bool GetBoolean(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetBoolean(ordinal);
		}
		return base.GetBoolean(ordinal);
	}

	public override decimal GetDecimal(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetDecimal(ordinal);
		}
		return base.GetDecimal(ordinal);
	}

	public override byte GetByte(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetByte(ordinal);
		}
		return base.GetByte(ordinal);
	}

	public override long GetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetBytes(ordinal, dataIndex, buffer, bufferIndex, length);
		}
		return base.GetBytes(ordinal, dataIndex, buffer, bufferIndex, length);
	}

	public override long GetChars(int ordinal, long dataIndex, char[] buffer, int bufferIndex, int length)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetChars(ordinal, dataIndex, buffer, bufferIndex, length);
		}
		return base.GetChars(ordinal, dataIndex, buffer, bufferIndex, length);
	}

	public override DateTime GetDateTime(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetDateTime(ordinal);
		}
		return base.GetDateTime(ordinal);
	}

	public override double GetDouble(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetDouble(ordinal);
		}
		return base.GetDouble(ordinal);
	}

	public override float GetFloat(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetFloat(ordinal);
		}
		return base.GetFloat(ordinal);
	}

	public override Guid GetGuid(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetGuid(ordinal);
		}
		return base.GetGuid(ordinal);
	}

	public override short GetInt16(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetInt16(ordinal);
		}
		return base.GetInt16(ordinal);
	}

	public override int GetInt32(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetInt32(ordinal);
		}
		return base.GetInt32(ordinal);
	}

	public override long GetInt64(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetInt64(ordinal);
		}
		return base.GetInt64(ordinal);
	}

	public override string GetString(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetString(ordinal);
		}
		return base.GetString(ordinal);
	}

	public override object GetValue(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetValue(ordinal);
		}
		return base.GetValue(ordinal);
	}

	public override int GetValues(object[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		int num = Math.Min(values.Length, FieldCount);
		for (int i = 0; i < num; i++)
		{
			values[i] = GetValue(i);
		}
		return num;
	}

	public void SetObjectRef(int ordinal, object buffer)
	{
		ValidateSet("SetValue");
		sqlUpdatableRecord.SetObjectRef(ordinal, buffer);
	}

	public int SetValues(object[] values)
	{
		ValidateSet("SetValues");
		return sqlUpdatableRecord.SetValues(values);
	}

	public void SetValue(int ordinal, object value)
	{
		ValidateSet("SetValue");
		sqlUpdatableRecord.SetValue(ordinal, value);
	}

	public void SetBoolean(int ordinal, bool value)
	{
		ValidateSet("SetBoolean");
		sqlUpdatableRecord.SetBoolean(ordinal, value);
	}

	public void SetByte(int ordinal, byte value)
	{
		ValidateSet("SetByte");
		sqlUpdatableRecord.SetByte(ordinal, value);
	}

	public void SetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
	{
		ValidateSet("SetBytes");
		SqlDbType sqlDbType = GetSqlMetaData(ordinal).SqlDbType;
		if (sqlDbType != SqlDbType.VarBinary && sqlDbType != SqlDbType.Image && sqlDbType != SqlDbType.Binary)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", buffer.ToString(), GetName(ordinal), sqlDbType.ToString()));
		}
		long num = 0L;
		if (!IsDBNull(ordinal))
		{
			num = GetBytes(ordinal, 0L, null, 0, 0);
		}
		if (dataIndex > 0 || length < num)
		{
			sqlUpdatableRecord[ordinal] = GetValue(ordinal);
		}
		sqlUpdatableRecord.SetBytes(ordinal, dataIndex, buffer, bufferIndex, length);
	}

	public void SetChar(int ordinal, char c)
	{
		ValidateSet("SetChar");
		sqlUpdatableRecord.SetChar(ordinal, c);
	}

	public void SetChars(int ordinal, long dataIndex, char[] buffer, int bufferIndex, int length)
	{
		ValidateSet("SetChars");
		SqlDbType sqlDbType = GetSqlMetaData(ordinal).SqlDbType;
		if (sqlDbType != SqlDbType.NText && sqlDbType != SqlDbType.NChar && sqlDbType != SqlDbType.NVarChar)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", buffer.ToString(), GetName(ordinal), sqlDbType.ToString()));
		}
		long num = 0L;
		if (!IsDBNull(ordinal))
		{
			num = GetChars(ordinal, 0L, null, 0, 0);
		}
		if (dataIndex > 0 || length < num)
		{
			sqlUpdatableRecord[ordinal] = GetValue(ordinal);
		}
		sqlUpdatableRecord.SetChars(ordinal, dataIndex, buffer, bufferIndex, length);
	}

	public void SetDouble(int ordinal, double value)
	{
		ValidateSet("SetDouble");
		sqlUpdatableRecord.SetDouble(ordinal, value);
	}

	public void SetDecimal(int ordinal, decimal value)
	{
		ValidateSet("SetDecimal");
		sqlUpdatableRecord.SetDecimal(ordinal, value);
	}

	public void SetDateTime(int ordinal, DateTime value)
	{
		ValidateSet("SetDateTime");
		sqlUpdatableRecord.SetDateTime(ordinal, value);
	}

	public void SetGuid(int ordinal, Guid value)
	{
		ValidateSet("SetGuid");
		sqlUpdatableRecord.SetGuid(ordinal, value);
	}

	public void SetInt16(int ordinal, short value)
	{
		ValidateSet("SetInt16");
		sqlUpdatableRecord.SetInt16(ordinal, value);
	}

	public void SetInt32(int ordinal, int value)
	{
		ValidateSet("SetInt32");
		sqlUpdatableRecord.SetInt32(ordinal, value);
	}

	public void SetInt64(int ordinal, long value)
	{
		ValidateSet("SetInt64");
		sqlUpdatableRecord.SetInt64(ordinal, value);
	}

	public void SetFloat(int ordinal, float value)
	{
		ValidateSet("SetFloat");
		sqlUpdatableRecord.SetFloat(ordinal, value);
	}

	public void SetString(int ordinal, string value)
	{
		ValidateSet("SetString");
		sqlUpdatableRecord.SetString(ordinal, value);
	}

	public override SqlBoolean GetSqlBoolean(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlBoolean(ordinal);
		}
		return base.GetSqlBoolean(ordinal);
	}

	public override SqlMoney GetSqlMoney(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlMoney(ordinal);
		}
		return base.GetSqlMoney(ordinal);
	}

	public override SqlDecimal GetSqlDecimal(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlDecimal(ordinal);
		}
		return base.GetSqlDecimal(ordinal);
	}

	public override SqlByte GetSqlByte(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlByte(ordinal);
		}
		return base.GetSqlByte(ordinal);
	}

	public override SqlBinary GetSqlBinary(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlBinary(ordinal);
		}
		return base.GetSqlBinary(ordinal);
	}

	public override SqlDateTime GetSqlDateTime(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlDateTime(ordinal);
		}
		return base.GetSqlDateTime(ordinal);
	}

	public override SqlDouble GetSqlDouble(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlDouble(ordinal);
		}
		return base.GetSqlDouble(ordinal);
	}

	public override SqlSingle GetSqlSingle(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlSingle(ordinal);
		}
		return base.GetSqlSingle(ordinal);
	}

	public override SqlGuid GetSqlGuid(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlGuid(ordinal);
		}
		return base.GetSqlGuid(ordinal);
	}

	public override SqlInt16 GetSqlInt16(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlInt16(ordinal);
		}
		return base.GetSqlInt16(ordinal);
	}

	public override SqlInt32 GetSqlInt32(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlInt32(ordinal);
		}
		return base.GetSqlInt32(ordinal);
	}

	public override SqlInt64 GetSqlInt64(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlInt64(ordinal);
		}
		return base.GetSqlInt64(ordinal);
	}

	public override SqlString GetSqlString(int ordinal)
	{
		if (HasColumnChanged(ordinal))
		{
			return sqlUpdatableRecord.GetSqlString(ordinal);
		}
		return base.GetSqlString(ordinal);
	}

	public void SetSqlBoolean(int ordinal, SqlBoolean value)
	{
		ValidateSet("SetSqlBoolean");
		sqlUpdatableRecord.SetSqlBoolean(ordinal, value);
	}

	public void SetSqlBinary(int ordinal, SqlBinary value)
	{
		ValidateSet("SetSqlBinary");
		sqlUpdatableRecord.SetSqlBinary(ordinal, value);
	}

	public void SetSqlByte(int ordinal, SqlByte value)
	{
		ValidateSet("SetSqlByte");
		sqlUpdatableRecord.SetSqlByte(ordinal, value);
	}

	public void SetSqlInt16(int ordinal, SqlInt16 value)
	{
		ValidateSet("SetSqlInt16");
		sqlUpdatableRecord.SetSqlInt16(ordinal, value);
	}

	public void SetSqlInt32(int ordinal, SqlInt32 value)
	{
		ValidateSet("SetSqlInt32");
		sqlUpdatableRecord.SetSqlInt32(ordinal, value);
	}

	public void SetSqlInt64(int ordinal, SqlInt64 value)
	{
		ValidateSet("SetSqlInt64");
		sqlUpdatableRecord.SetSqlInt64(ordinal, value);
	}

	public void SetSqlSingle(int ordinal, SqlSingle value)
	{
		ValidateSet("SetSqlSingle");
		sqlUpdatableRecord.SetSqlSingle(ordinal, value);
	}

	public void SetSqlDouble(int ordinal, SqlDouble value)
	{
		ValidateSet("SetSqlDouble");
		sqlUpdatableRecord.SetSqlDouble(ordinal, value);
	}

	public void SetSqlString(int ordinal, SqlString value)
	{
		ValidateSet("SetSqlString");
		sqlUpdatableRecord.SetSqlString(ordinal, value);
	}

	public void SetSqlMoney(int ordinal, SqlMoney value)
	{
		ValidateSet("SetSqlMoney");
		sqlUpdatableRecord.SetSqlMoney(ordinal, value);
	}

	public void SetSqlDecimal(int ordinal, SqlDecimal value)
	{
		ValidateSet("SetSqlDecimal");
		sqlUpdatableRecord.SetSqlDecimal(ordinal, value);
	}

	public void SetSqlDateTime(int ordinal, SqlDateTime value)
	{
		ValidateSet("SetSqlDateTime");
		sqlUpdatableRecord.SetSqlDateTime(ordinal, value);
	}

	public void SetSqlGuid(int ordinal, SqlGuid value)
	{
		ValidateSet("SetSqlGuid");
		sqlUpdatableRecord.SetSqlGuid(ordinal, value);
	}
}
