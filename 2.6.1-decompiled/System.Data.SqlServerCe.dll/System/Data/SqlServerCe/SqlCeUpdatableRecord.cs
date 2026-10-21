using System.Data.SqlTypes;
using System.Globalization;

namespace System.Data.SqlServerCe;

public class SqlCeUpdatableRecord : IDataRecord
{
	internal object[] values;

	private SqlMetaData[] sqlMetaDatas;

	private bool updatable;

	private bool[] boundFields;

	private string[] fieldNames;

	private FieldNameLookup fieldNameLookup;

	private int hiddenFieldCount;

	private ColumnUpdatedStatus[] columnsUpdated;

	private Type SqlBinaryType = typeof(SqlBinary);

	private Type SqlBooleanType = typeof(SqlBoolean);

	private Type SqlByteType = typeof(SqlByte);

	private Type SqlDateTimeType = typeof(SqlDateTime);

	private Type SqlDecimalType = typeof(SqlDecimal);

	private Type SqlDoubleType = typeof(SqlDouble);

	private Type SqlGuidType = typeof(SqlGuid);

	private Type SqlInt16Type = typeof(SqlInt16);

	private Type SqlInt32Type = typeof(SqlInt32);

	private Type SqlInt64Type = typeof(SqlInt64);

	private Type SqlMoneyType = typeof(SqlMoney);

	private Type SqlSingleType = typeof(SqlSingle);

	private Type SqlStringType = typeof(SqlString);

	public int FieldCount => sqlMetaDatas.Length;

	public int HiddenFieldCount => hiddenFieldCount;

	public bool Updatable => updatable;

	internal ColumnUpdatedStatus[] ColumnsUpdatedStatus => columnsUpdated;

	public object this[int ordinal]
	{
		get
		{
			return GetValue(ordinal);
		}
		set
		{
			SetValue(ordinal, value);
		}
	}

	public object this[string name]
	{
		get
		{
			return GetValue(GetOrdinal(name));
		}
		set
		{
			SetValue(GetOrdinal(name), value);
		}
	}

	internal SqlCeUpdatableRecord(MetaData[] metaData, object[] values, bool updatable, int hiddenFieldCount, FieldNameLookup fieldNameLookup)
	{
		NativeMethods.LoadNativeBinaries();
		int num = metaData.Length;
		this.values = values;
		this.updatable = updatable;
		this.fieldNameLookup = fieldNameLookup;
		this.hiddenFieldCount = hiddenFieldCount;
		sqlMetaDatas = new SqlMetaData[num];
		columnsUpdated = new ColumnUpdatedStatus[num];
		fieldNames = new string[num];
		for (int i = 0; i < num; i++)
		{
			sqlMetaDatas[i] = metaData[i].SqlMetaData;
			fieldNames[i] = metaData[i].baseColumnName;
			columnsUpdated[i] = ColumnUpdatedStatus.None;
		}
		if (this.fieldNameLookup == null)
		{
			this.fieldNameLookup = new FieldNameLookup(fieldNames, -1);
		}
		boundFields = new bool[num];
	}

	public void SetDefault(int ordinal)
	{
		EnsureObjectArray(ordinal, "SetDefault");
		columnsUpdated[ordinal] = ColumnUpdatedStatus.ServerDefault;
	}

	public int GetValues(object[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		int num = ((values.Length < sqlMetaDatas.Length) ? values.Length : sqlMetaDatas.Length);
		num = ((num < this.values.Length) ? num : this.values.Length);
		for (int i = 0; i < num; i++)
		{
			object obj = this.values[i];
			if (obj is SqlDecimal)
			{
				values[i] = (decimal)(SqlDecimal)obj;
			}
			else
			{
				values[i] = obj;
			}
		}
		return num;
	}

	public int SetValues(object[] values)
	{
		EnsureObjectArray(values.Length, "SetValues");
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] != null)
			{
				SetValue(i, values[i]);
			}
		}
		return values.Length;
	}

	public string GetName(int ordinal)
	{
		return fieldNames[ordinal];
	}

	public object GetValue(int ordinal)
	{
		object obj = values[ordinal];
		if (obj is SqlDecimal)
		{
			return (decimal)(SqlDecimal)obj;
		}
		return obj;
	}

	public string GetDataTypeName(int ordinal)
	{
		return sqlMetaDatas[ordinal].TypeName;
	}

	public Type GetFieldType(int ordinal)
	{
		SqlCeType sqlCeType = SqlCeType.FromSqlDbType(sqlMetaDatas[ordinal].SqlDbType);
		return sqlCeType.clrType;
	}

	public IDataReader GetData(int ordinal)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "GetData", new object[0]);
		throw new NotSupportedException(message);
	}

	public int GetOrdinal(string name)
	{
		return fieldNameLookup.GetOrdinal(name);
	}

	public bool IsSetAsDefault(int ordinal)
	{
		if (ColumnUpdatedStatus.ServerDefault == columnsUpdated[ordinal])
		{
			return true;
		}
		return false;
	}

	public bool IsDBNull(int ordinal)
	{
		if (values == null)
		{
			EnsureObjectArray(ordinal, "IsDBNull");
		}
		object obj = values[ordinal];
		if (obj is INullable)
		{
			return ((INullable)obj).IsNull;
		}
		if (obj != null)
		{
			return obj == DBNull.Value;
		}
		return true;
	}

	private void EnsureObjectArray(int ordinal, string method)
	{
		if (ordinal > sqlMetaDatas.Length)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQLCE_OrdinalOutOfRange", ordinal, method));
		}
		if (!Updatable)
		{
			throw new InvalidOperationException(Res.GetString("SQL_SqlRecordReadOnly", method));
		}
		if (values == null)
		{
			values = new object[sqlMetaDatas.Length];
		}
		if (columnsUpdated == null)
		{
			columnsUpdated = new ColumnUpdatedStatus[sqlMetaDatas.Length];
		}
	}

	private void SetClrTypeValue(int ordinal, object value, string method)
	{
		EnsureObjectArray(ordinal, method);
		if (value == DBNull.Value)
		{
			values[ordinal] = DBNull.Value;
			boundFields[ordinal] = false;
			columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
			return;
		}
		SqlDbType sqlDbType = SqlCeType.FromClrType(value).SqlDbType;
		SqlDbType sqlDbType2 = sqlMetaDatas[ordinal].SqlDbType;
		SqlCeType.ValidateDataConversion(sqlDbType2, sqlDbType);
		switch (sqlDbType2)
		{
		case SqlDbType.Int:
			if (!(value is int))
			{
				value = Convert.ToInt32(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.SmallInt:
			if (!(value is short))
			{
				value = Convert.ToInt16((ushort)value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.BigInt:
			if (!(value is long))
			{
				value = Convert.ToInt64(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.Bit:
			if (!(value is bool))
			{
				value = Convert.ToBoolean(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.DateTime:
		case SqlDbType.SmallDateTime:
			if (!(value is DateTime))
			{
				value = Convert.ToDateTime(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.Float:
			if (!(value is double))
			{
				value = Convert.ToDouble(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.Real:
			if (!(value is float))
			{
				value = Convert.ToSingle(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.Decimal:
			if (!(value is SqlDecimal))
			{
				value = new SqlDecimal(Convert.ToDecimal(value, CultureInfo.CurrentCulture));
			}
			break;
		case SqlDbType.Money:
		case SqlDbType.SmallMoney:
			if (!(value is decimal))
			{
				value = Convert.ToDecimal(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.NChar:
		case SqlDbType.NText:
		case SqlDbType.NVarChar:
			if (!(value is string))
			{
				value = Convert.ToString(value, CultureInfo.CurrentCulture);
			}
			break;
		case SqlDbType.Binary:
		case SqlDbType.Image:
		case SqlDbType.Timestamp:
		case SqlDbType.VarBinary:
			if (!(value is byte[]))
			{
				throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], typeof(byte[])));
			}
			break;
		case SqlDbType.UniqueIdentifier:
			if (value is Guid)
			{
				break;
			}
			if (value is string)
			{
				value = new Guid((string)value);
				break;
			}
			if (value is byte[])
			{
				value = new Guid((byte[])value);
				break;
			}
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], SqlDbType.UniqueIdentifier));
		case SqlDbType.TinyInt:
			if (value is string)
			{
				value = Convert.ToByte((string)value, CultureInfo.CurrentCulture);
				break;
			}
			try
			{
				value = (byte)value;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], SqlDbType.TinyInt));
			}
			break;
		}
		values[ordinal] = value;
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	private void SetSqlTypeValue(int ordinal, INullable value, string method)
	{
		EnsureObjectArray(ordinal, method);
		if (value.IsNull)
		{
			values[ordinal] = DBNull.Value;
		}
		else
		{
			object obj = null;
			Type type = value.GetType();
			if ((object)type == SqlBinaryType)
			{
				obj = ((SqlBinary)(object)value).Value;
			}
			else if ((object)type == SqlBooleanType)
			{
				obj = ((SqlBoolean)(object)value).Value;
			}
			else if ((object)type == SqlByteType)
			{
				obj = ((SqlByte)(object)value).Value;
			}
			else if ((object)type == SqlDateTimeType)
			{
				obj = ((SqlDateTime)(object)value).Value;
			}
			else if ((object)type == SqlDecimalType)
			{
				obj = (SqlDecimal)(object)value;
			}
			else if ((object)type == SqlDoubleType)
			{
				obj = ((SqlDouble)(object)value).Value;
			}
			else if ((object)type == SqlGuidType)
			{
				obj = ((SqlGuid)(object)value).Value;
			}
			else if ((object)type == SqlInt16Type)
			{
				obj = ((SqlInt16)(object)value).Value;
			}
			else if ((object)type == SqlInt32Type)
			{
				obj = ((SqlInt32)(object)value).Value;
			}
			else if ((object)type == SqlInt64Type)
			{
				obj = ((SqlInt64)(object)value).Value;
			}
			else if ((object)type == SqlMoneyType)
			{
				obj = ((SqlMoney)(object)value).Value;
			}
			else if ((object)type == SqlSingleType)
			{
				obj = ((SqlSingle)(object)value).Value;
			}
			else if ((object)type == SqlStringType)
			{
				obj = ((SqlString)(object)value).Value;
			}
			values[ordinal] = obj;
		}
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	private void ValidateType(int ordinal, object value, SqlDbType type)
	{
		if (sqlMetaDatas[ordinal].SqlDbType != type)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], sqlMetaDatas[ordinal].SqlDbType));
		}
	}

	public bool GetBoolean(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (bool)values[ordinal];
	}

	public byte GetByte(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (byte)values[ordinal];
	}

	public long GetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		byte[] array = (byte[])values[ordinal];
		if (buffer == null)
		{
			return array.Length;
		}
		if ((int)dataIndex > array.Length || array.Length == 0)
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
		int num2 = (int)(array.Length - dataIndex);
		if (length > num && num2 > num)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_TooManyBytesAvailable", num2, num));
		}
		int num3 = Math.Min(buffer.Length - bufferIndex, length);
		if (dataIndex > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", num3.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (array.Length - dataIndex < num3)
		{
			num3 = array.Length - (int)dataIndex;
		}
		if (num3 < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.CurrentCulture)));
		}
		Array.Copy(array, (int)dataIndex, buffer, bufferIndex, num3);
		return num3;
	}

	public long GetChars(int ordinal, long dataIndex, char[] buffer, int bufferIndex, int length)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		string text = (string)values[ordinal];
		char[] array = text.ToCharArray();
		if (buffer == null)
		{
			return array.Length;
		}
		if ((int)dataIndex > array.Length || array.Length == 0)
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
		int num2 = (int)(array.Length - dataIndex);
		if (length > num && num2 > num)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("SQLCE_TooManyCharsAvailable", num2, num));
		}
		int num3 = Math.Min(buffer.Length - bufferIndex, length);
		if (dataIndex > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", num3.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (array.Length - dataIndex < num3)
		{
			num3 = array.Length - (int)dataIndex;
		}
		if (num3 < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.CurrentCulture)));
		}
		Array.Copy(array, (int)dataIndex, buffer, bufferIndex, num3);
		return num3;
	}

	public char GetChar(int ordinal)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "GetChar", new object[0]);
		throw new NotSupportedException(message);
	}

	public Guid GetGuid(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (Guid)values[ordinal];
	}

	public short GetInt16(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (short)values[ordinal];
	}

	public int GetInt32(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (int)values[ordinal];
	}

	public long GetInt64(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (long)values[ordinal];
	}

	public float GetFloat(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (float)values[ordinal];
	}

	public double GetDouble(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (double)values[ordinal];
	}

	public string GetString(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		object obj = values[ordinal];
		if (obj is char[])
		{
			return new string((char[])obj);
		}
		return (string)obj;
	}

	public decimal GetDecimal(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return GetSqlDecimal(ordinal).Value;
	}

	public DateTime GetDateTime(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			throw new SqlNullValueException();
		}
		return (DateTime)values[ordinal];
	}

	public SqlMetaData GetSqlMetaData(int ordinal)
	{
		return sqlMetaDatas[ordinal];
	}

	public SqlBoolean GetSqlBoolean(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlBoolean.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((bool)values[ordinal]);
		}
		return new SqlBoolean((bool)values[ordinal]);
	}

	public SqlBinary GetSqlBinary(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlBinary.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((byte[])values[ordinal]);
		}
		return new SqlBinary((byte[])values[ordinal]);
	}

	public SqlByte GetSqlByte(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlByte.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((byte)values[ordinal]);
		}
		return new SqlByte((byte)values[ordinal]);
	}

	public SqlInt16 GetSqlInt16(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt16.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((short)values[ordinal]);
		}
		return new SqlInt16((short)values[ordinal]);
	}

	public SqlInt32 GetSqlInt32(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt32.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((int)values[ordinal]);
		}
		return new SqlInt32((int)values[ordinal]);
	}

	public SqlInt64 GetSqlInt64(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlInt64.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((long)values[ordinal]);
		}
		return new SqlInt64((long)values[ordinal]);
	}

	public SqlSingle GetSqlSingle(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlSingle.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((float)values[ordinal]);
		}
		return new SqlSingle((float)values[ordinal]);
	}

	public SqlDouble GetSqlDouble(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDouble.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((double)values[ordinal]);
		}
		return new SqlDouble((double)values[ordinal]);
	}

	public SqlString GetSqlString(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlString.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((string)values[ordinal]);
		}
		return new SqlString((string)values[ordinal]);
	}

	public SqlMoney GetSqlMoney(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlMoney.Null;
		}
		return new SqlMoney(GetSqlDecimal(ordinal).Value);
	}

	public SqlDecimal GetSqlDecimal(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDecimal.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((SqlDecimal)values[ordinal]);
		}
		return (SqlDecimal)values[ordinal];
	}

	public SqlDateTime GetSqlDateTime(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlDateTime.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((DateTime)values[ordinal]);
		}
		return new SqlDateTime((DateTime)values[ordinal]);
	}

	public SqlGuid GetSqlGuid(int ordinal)
	{
		if (IsDBNull(ordinal))
		{
			return SqlGuid.Null;
		}
		if (boundFields[ordinal])
		{
			values[ordinal] = sqlMetaDatas[ordinal].Adjust((Guid)values[ordinal]);
		}
		return new SqlGuid((Guid)values[ordinal]);
	}

	public SqlChars GetSqlCharsRef(int ordinal)
	{
		return (SqlChars)values[ordinal];
	}

	public SqlBytes GetSqlBytesRef(int ordinal)
	{
		return (SqlBytes)values[ordinal];
	}

	public void SetObjectRef(int ordinal, object value)
	{
		EnsureObjectArray(ordinal, "SetObjectRef");
		if (!(value is char[]) && !(value is byte[]))
		{
			throw new ArgumentException(Res.GetString("SQLCE_InvalidDataType", value.GetType().ToString(), "SetObjectRef"));
		}
		values[ordinal] = value;
		boundFields[ordinal] = true;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	public void SetValue(int ordinal, object value)
	{
		if (value == null)
		{
			value = DBNull.Value;
		}
		if (value is INullable)
		{
			SetSqlTypeValue(ordinal, (INullable)value, "SetValue");
		}
		else
		{
			SetClrTypeValue(ordinal, value, "SetValue");
		}
	}

	public void SetBoolean(int ordinal, bool value)
	{
		ValidateType(ordinal, value, SqlDbType.Bit);
		SetClrTypeValue(ordinal, value, "SetBoolean");
	}

	public void SetByte(int ordinal, byte value)
	{
		ValidateType(ordinal, value, SqlDbType.TinyInt);
		SetClrTypeValue(ordinal, value, "SetByte");
	}

	public void SetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
	{
		EnsureObjectArray(ordinal, "SetBytes");
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.VarBinary && sqlDbType != SqlDbType.Image && sqlDbType != SqlDbType.Binary)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", buffer.GetType().ToString(), fieldNames[ordinal], sqlDbType.ToString()));
		}
		if (buffer == null)
		{
			values[ordinal] = DBNull.Value;
			return;
		}
		if (length < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.InvariantCulture)));
		}
		if (dataIndex < 0)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", length.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (bufferIndex < 0 || bufferIndex >= buffer.Length)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidDestinationBufferIndex", length.ToString(CultureInfo.InvariantCulture), bufferIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (dataIndex + length > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", int.MaxValue.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (buffer.Length - bufferIndex < length)
		{
			length = buffer.Length - bufferIndex;
		}
		byte[] array = null;
		byte[] array2 = (IsDBNull(ordinal) ? new byte[0] : ((byte[])values[ordinal]));
		int num = Math.Max((int)dataIndex + length, array2.Length);
		int num2 = (int)sqlMetaDatas[ordinal].MaxLength;
		if (num2 != -1 && num > num2)
		{
			throw new InvalidOperationException(Res.GetString("ADP_TruncatedBytes", num2));
		}
		if (num > array2.Length)
		{
			array = new byte[num];
			for (int i = 0; i < array2.Length; i++)
			{
				array[i] = array2[i];
			}
		}
		else
		{
			array = array2;
		}
		for (int j = 0; j < length; j++)
		{
			array[j + dataIndex] = buffer[j + bufferIndex];
		}
		values[ordinal] = array;
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	public void SetChar(int ordinal, char value)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "SetChar", new object[0]);
		throw new NotSupportedException(message);
	}

	public void SetChars(int ordinal, long dataIndex, char[] buffer, int bufferIndex, int length)
	{
		EnsureObjectArray(ordinal, "SetChars");
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.NChar && sqlDbType != SqlDbType.NText && sqlDbType != SqlDbType.NVarChar)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", buffer.GetType().ToString(), fieldNames[ordinal], sqlDbType.ToString()));
		}
		if (buffer == null)
		{
			values[ordinal] = DBNull.Value;
			return;
		}
		if (length < 0)
		{
			throw new IndexOutOfRangeException(Res.GetString("SQL_InvalidDataLength", length.ToString(CultureInfo.InvariantCulture)));
		}
		if (dataIndex < 0)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", length.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (bufferIndex < 0 || bufferIndex >= buffer.Length)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidDestinationBufferIndex", buffer.Length.ToString(CultureInfo.InvariantCulture), bufferIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (dataIndex + length > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSourceBufferIndex", int.MaxValue.ToString(CultureInfo.InvariantCulture), dataIndex.ToString(CultureInfo.InvariantCulture)));
		}
		if (buffer.Length - bufferIndex < length)
		{
			length = buffer.Length - bufferIndex;
		}
		char[] array = null;
		string text = (IsDBNull(ordinal) ? string.Empty : ((string)values[ordinal]));
		int num = Math.Max((int)dataIndex + length, text.Length);
		int num2 = (int)sqlMetaDatas[ordinal].MaxLength;
		array = new char[num];
		for (int i = 0; i < text.Length; i++)
		{
			array[i] = text[i];
		}
		for (int j = 0; j < length; j++)
		{
			array[j + dataIndex] = buffer[j + bufferIndex];
		}
		string text2 = new string(array);
		if (num2 != -1 && num > num2)
		{
			throw new InvalidOperationException(Res.GetString("ADP_TruncatedString", num2, num, text2));
		}
		values[ordinal] = text2;
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	public void SetGuid(int ordinal, Guid value)
	{
		ValidateType(ordinal, value, SqlDbType.UniqueIdentifier);
		SetClrTypeValue(ordinal, value, "SetGuid");
	}

	public void SetInt16(int ordinal, short value)
	{
		ValidateType(ordinal, value, SqlDbType.SmallInt);
		SetClrTypeValue(ordinal, value, "SetInt16");
	}

	public void SetInt32(int ordinal, int value)
	{
		ValidateType(ordinal, value, SqlDbType.Int);
		SetClrTypeValue(ordinal, value, "SetInt32");
	}

	public void SetInt64(int ordinal, long value)
	{
		ValidateType(ordinal, value, SqlDbType.BigInt);
		SetClrTypeValue(ordinal, value, "SetInt64");
	}

	public void SetFloat(int ordinal, float value)
	{
		ValidateType(ordinal, value, SqlDbType.Real);
		SetClrTypeValue(ordinal, value, "SetFloat");
	}

	public void SetDouble(int ordinal, double value)
	{
		ValidateType(ordinal, value, SqlDbType.Float);
		SetClrTypeValue(ordinal, value, "SetDouble");
	}

	public void SetString(int ordinal, string value)
	{
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.NText && sqlDbType != SqlDbType.NChar && sqlDbType != SqlDbType.NVarChar)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], sqlDbType));
		}
		SetClrTypeValue(ordinal, value, "SetString");
	}

	public void SetDecimal(int ordinal, decimal value)
	{
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.Decimal && sqlDbType != SqlDbType.Money)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], sqlDbType));
		}
		EnsureObjectArray(ordinal, "SetDecimal");
		value = sqlMetaDatas[ordinal].Adjust(value);
		values[ordinal] = new SqlDecimal(value);
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	public void SetDateTime(int ordinal, DateTime value)
	{
		ValidateType(ordinal, value, SqlDbType.DateTime);
		SetClrTypeValue(ordinal, value, "SetDateTime");
	}

	public void SetSqlBoolean(int ordinal, SqlBoolean value)
	{
		ValidateType(ordinal, value, SqlDbType.Bit);
		SetSqlTypeValue(ordinal, value, "SetSqlBoolean");
	}

	public void SetSqlBinary(int ordinal, SqlBinary value)
	{
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.VarBinary && sqlDbType != SqlDbType.Image && sqlDbType != SqlDbType.Binary)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], sqlDbType.ToString()));
		}
		SetSqlTypeValue(ordinal, value, "SetSqlBinary");
	}

	public void SetSqlByte(int ordinal, SqlByte value)
	{
		ValidateType(ordinal, value, SqlDbType.TinyInt);
		SetSqlTypeValue(ordinal, value, "SetSqlByte");
	}

	public void SetSqlInt16(int ordinal, SqlInt16 value)
	{
		ValidateType(ordinal, value, SqlDbType.SmallInt);
		SetSqlTypeValue(ordinal, value, "SetSqlInt16");
	}

	public void SetSqlInt32(int ordinal, SqlInt32 value)
	{
		ValidateType(ordinal, value, SqlDbType.Int);
		SetSqlTypeValue(ordinal, value, "SetSqlInt32");
	}

	public void SetSqlInt64(int ordinal, SqlInt64 value)
	{
		ValidateType(ordinal, value, SqlDbType.BigInt);
		SetSqlTypeValue(ordinal, value, "SetSqlInt64");
	}

	public void SetSqlSingle(int ordinal, SqlSingle value)
	{
		ValidateType(ordinal, value, SqlDbType.Real);
		SetSqlTypeValue(ordinal, value, "SetSqlSingle");
	}

	public void SetSqlDouble(int ordinal, SqlDouble value)
	{
		ValidateType(ordinal, value, SqlDbType.Float);
		SetSqlTypeValue(ordinal, value, "SetSqlDouble");
	}

	public void SetSqlString(int ordinal, SqlString value)
	{
		SqlDbType sqlDbType = sqlMetaDatas[ordinal].SqlDbType;
		if (sqlDbType != SqlDbType.NText && sqlDbType != SqlDbType.NChar && sqlDbType != SqlDbType.NVarChar)
		{
			throw new ArgumentException(Res.GetString("SQLCE_DataColumn_SetFailed", value.GetType().ToString(), fieldNames[ordinal], sqlDbType));
		}
		SetSqlTypeValue(ordinal, value, "SetSqlString");
	}

	public void SetSqlMoney(int ordinal, SqlMoney value)
	{
		ValidateType(ordinal, value, SqlDbType.Money);
		SetSqlTypeValue(ordinal, value, "SetSqlMoney");
	}

	public void SetSqlDecimal(int ordinal, SqlDecimal value)
	{
		EnsureObjectArray(ordinal, "SetSqlDecimal");
		ValidateType(ordinal, value, SqlDbType.Decimal);
		if (value.IsNull)
		{
			values[ordinal] = DBNull.Value;
		}
		else
		{
			value = sqlMetaDatas[ordinal].Adjust(value);
			int[] data = value.Data;
			values[ordinal] = new SqlDecimal(value.Precision, value.Scale, value.IsPositive, data[0], data[1], data[2], data[3]);
		}
		boundFields[ordinal] = false;
		columnsUpdated[ordinal] = ColumnUpdatedStatus.NewValue;
	}

	public void SetSqlDateTime(int ordinal, SqlDateTime value)
	{
		ValidateType(ordinal, value, SqlDbType.DateTime);
		SetSqlTypeValue(ordinal, value, "SetSqlDateTime");
	}

	public void SetSqlGuid(int ordinal, SqlGuid value)
	{
		ValidateType(ordinal, value, SqlDbType.UniqueIdentifier);
		SetSqlTypeValue(ordinal, value, "SetSqlGuid");
	}
}
