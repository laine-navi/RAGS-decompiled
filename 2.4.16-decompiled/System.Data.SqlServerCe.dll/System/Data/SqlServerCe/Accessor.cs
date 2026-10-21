using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

internal sealed class Accessor : IDisposable
{
	private int index;

	private int count;

	private int bindingIndx;

	private int dataBufferSize;

	private int actualBufferSize;

	private int numValues;

	private IntPtr dataHandle;

	private ulong[] pValueArray;

	private MEDBBINDING[] dbbindings;

	private string[] columnNames;

	internal bool doTruncate;

	internal static readonly Type SByteType = typeof(sbyte);

	internal static readonly Type Int16Type = typeof(short);

	internal static readonly Type Int32Type = typeof(int);

	internal static readonly Type Int64Type = typeof(long);

	internal static readonly Type ByteType = typeof(byte);

	internal static readonly Type SingleType = typeof(float);

	internal static readonly Type DoubleType = typeof(double);

	internal static readonly Type StringType = typeof(string);

	internal static readonly Type GuidType = typeof(Guid);

	internal MEDBBINDING[] DbBinding => dbbindings;

	internal IntPtr DataHandle => dataHandle;

	internal int Count => count;

	internal int NumValues
	{
		set
		{
			numValues = value;
		}
	}

	internal int CurrentIndex
	{
		get
		{
			return index;
		}
		set
		{
			index = value;
			bindingIndx = index % count;
		}
	}

	internal int DataBufferSize => dataBufferSize;

	internal int ActualDataBufferSize
	{
		set
		{
			actualBufferSize = value;
		}
	}

	internal int Ordinal
	{
		set
		{
			dbbindings[bindingIndx].iOrdinal = value;
		}
	}

	internal string ColumnName
	{
		get
		{
			return columnNames[bindingIndx];
		}
		set
		{
			columnNames[bindingIndx] = value;
		}
	}

	internal IntPtr ObjectPtr
	{
		set
		{
			if (IntPtr.Zero != dbbindings[bindingIndx].pObject)
			{
				NativeMethods.CoTaskMemFree(dbbindings[bindingIndx].pObject);
			}
			dbbindings[bindingIndx].pObject = value;
		}
	}

	internal int MaxLen
	{
		get
		{
			return dbbindings[bindingIndx].cbMaxLen;
		}
		set
		{
			dbbindings[bindingIndx].obValue = dataBufferSize;
			dataBufferSize += AlignDataSize(value);
			actualBufferSize = dataBufferSize;
			dbbindings[bindingIndx].cbMaxLen = value;
		}
	}

	internal SETYPE SeType
	{
		get
		{
			return dbbindings[bindingIndx].type;
		}
		set
		{
			dbbindings[bindingIndx].type = value;
		}
	}

	internal byte Precision
	{
		get
		{
			return (byte)dbbindings[bindingIndx].bPrecision;
		}
		set
		{
			dbbindings[bindingIndx].bPrecision = value;
		}
	}

	internal byte Scale
	{
		get
		{
			return (byte)dbbindings[bindingIndx].bScale;
		}
		set
		{
			dbbindings[bindingIndx].bScale = value;
		}
	}

	internal unsafe int SizeValue
	{
		get
		{
			ulong num = (ulong)dbbindings[bindingIndx].obSize;
			return *(int*)(pValueArray[index] + num);
		}
		set
		{
			ulong num = (ulong)dbbindings[bindingIndx].obSize;
			*(int*)(pValueArray[index] + num) = value;
		}
	}

	internal unsafe DBStatus StatusValue
	{
		get
		{
			ulong num = (ulong)dbbindings[bindingIndx].obStatus;
			return *(DBStatus*)(pValueArray[index] + num);
		}
		set
		{
			ulong num = (ulong)dbbindings[bindingIndx].obStatus;
			*(DBStatus*)(pValueArray[index] + num) = value;
		}
	}

	internal unsafe object Value
	{
		get
		{
			switch (StatusValue)
			{
			case DBStatus.S_OK:
				return SeType switch
				{
					SETYPE.TINYINT => (object)(*(byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.UI2 => *(short*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.UI4 => *(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.UI8 => *(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.SMALLINT => *(short*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.INTEGER => *(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.BIGINT => *(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.REAL => *(float*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.FLOAT => *(double*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.MONEY => (decimal)(*(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)) / 10000m, 
					SETYPE.BIT => 0 != *(short*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue), 
					SETYPE.UNIQUEIDENTIFIER => Value_GUID, 
					SETYPE.NCHAR => new string((char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.NVARCHAR => new string((char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.NTEXT => (IntPtr)(*(void**)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.BINARY => Value_BYTES, 
					SETYPE.ROWVERSION => Value_BYTES, 
					SETYPE.VARBINARY => Value_BYTES, 
					SETYPE.IMAGE => (IntPtr)(*(void**)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.NUMERIC => Value_NUMERIC, 
					SETYPE.DATETIME => Value_DATETIME, 
					_ => throw new InvalidProgramException("Invalid data type"), 
				};
			case DBStatus.S_TRUNCATED:
				return SeType switch
				{
					SETYPE.NCHAR => (object)new string((char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.NVARCHAR => new string((char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.NTEXT => new string((char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), 
					SETYPE.BINARY => Value_BYTES, 
					SETYPE.VARBINARY => Value_BYTES, 
					SETYPE.IMAGE => Value_BYTES, 
					_ => throw new InvalidProgramException("Invalid data type"), 
				};
			case DBStatus.S_ISNULL:
			case DBStatus.S_DEFAULT:
				return DBNull.Value;
			default:
				throw CheckTypeValueStatusValue(SqlCeType.FromSeType(SeType).clrType);
			}
		}
		set
		{
			if (value == null || value == DBNull.Value || (value is INullable && ((INullable)value).IsNull))
			{
				SetValueDBNull();
				return;
			}
			StatusValue = DBStatus.S_OK;
			switch (SeType)
			{
			case SETYPE.SMALLINT:
			case SETYPE.UI2:
				if (value is short)
				{
					Value_I2 = (short)value;
				}
				else if (value is SqlInt16)
				{
					Value_I2 = (short)(SqlInt16)value;
				}
				else
				{
					Value_I2 = ((IConvertible)value).ToInt16(null);
				}
				break;
			case SETYPE.INTEGER:
			case SETYPE.UI4:
				if (value is int)
				{
					Value_I4 = (int)value;
				}
				else if (value is SqlInt32)
				{
					Value_I4 = (int)(SqlInt32)value;
				}
				else
				{
					Value_I4 = ((IConvertible)value).ToInt32(null);
				}
				break;
			case SETYPE.NCHAR:
			case SETYPE.NVARCHAR:
			case SETYPE.NTEXT:
				if (value is string)
				{
					Value_STRING = (string)value;
				}
				else if (value is char[])
				{
					Value_CHARS = (char[])value;
				}
				else if (value is INullable)
				{
					Value_STRING = value.ToString();
				}
				else
				{
					Value_STRING = (string)Convert.ChangeType(value, StringType, CultureInfo.CurrentCulture);
				}
				break;
			case SETYPE.TINYINT:
				if (value is byte)
				{
					Value_TINYINT = (byte)value;
				}
				else if (value is SqlByte)
				{
					Value_TINYINT = (byte)(SqlByte)value;
				}
				else
				{
					Value_TINYINT = ((IConvertible)value).ToByte(null);
				}
				break;
			case SETYPE.BIGINT:
			case SETYPE.UI8:
				if (value is long)
				{
					Value_I8 = (long)value;
				}
				else if (value is SqlInt64)
				{
					Value_I8 = (long)(SqlInt64)value;
				}
				else
				{
					Value_I8 = ((IConvertible)value).ToInt64(null);
				}
				break;
			case SETYPE.REAL:
				if (value is float)
				{
					Value_R4 = (float)value;
				}
				else if (value is SqlSingle)
				{
					Value_R4 = (float)(SqlSingle)value;
				}
				else if (value is SqlDouble)
				{
					Value_R4 = (float)(double)(SqlDouble)value;
				}
				else
				{
					Value_R4 = ((IConvertible)value).ToSingle(null);
				}
				break;
			case SETYPE.FLOAT:
				if (value is double)
				{
					Value_R8 = (double)value;
				}
				else if (value is SqlDouble)
				{
					Value_R8 = (double)(SqlDouble)value;
				}
				else if (value is SqlSingle)
				{
					Value_R8 = (float)(SqlSingle)value;
				}
				else
				{
					Value_R8 = ((IConvertible)value).ToDouble(null);
				}
				break;
			case SETYPE.MONEY:
				if (value is decimal)
				{
					Value_CY = (decimal)value;
				}
				else if (value is SqlMoney)
				{
					Value_CY = (decimal)(SqlMoney)value;
				}
				else if (value is SqlDecimal)
				{
					Value_CY = (decimal)(SqlDecimal)value;
				}
				else
				{
					Value_CY = ((IConvertible)value).ToDecimal(null);
				}
				break;
			case SETYPE.BIT:
				if (value is bool)
				{
					Value_BOOL = (bool)value;
				}
				else if (value is SqlBoolean)
				{
					Value_BOOL = (bool)(SqlBoolean)value;
				}
				else
				{
					Value_BOOL = ((IConvertible)value).ToBoolean(null);
				}
				break;
			case SETYPE.UNIQUEIDENTIFIER:
				if (value is Guid)
				{
					Value_GUID = (Guid)value;
				}
				else if (value is SqlGuid)
				{
					Value_GUID = (Guid)(SqlGuid)value;
				}
				else if (value is string)
				{
					Value_GUID = new Guid((string)value);
				}
				else
				{
					Value_GUID = (Guid)value;
				}
				break;
			case SETYPE.BINARY:
			case SETYPE.VARBINARY:
			case SETYPE.IMAGE:
			case SETYPE.ROWVERSION:
				if (value is SqlBinary)
				{
					Value_BYTES = ((SqlBinary)value).Value;
				}
				else
				{
					Value_BYTES = (byte[])value;
				}
				break;
			case SETYPE.NUMERIC:
				if (value is decimal)
				{
					Value_NUMERIC = new SqlDecimal((decimal)value);
				}
				else if (value is SqlDecimal)
				{
					Value_NUMERIC = (SqlDecimal)value;
				}
				else
				{
					Value_NUMERIC = ((IConvertible)value).ToDecimal(null);
				}
				break;
			case SETYPE.DATETIME:
				if (value is DateTime)
				{
					Value_DATETIME = (DateTime)value;
				}
				else if (value is SqlDateTime)
				{
					Value_DATETIME = ((SqlDateTime)value).Value;
				}
				else
				{
					Value_DATETIME = ((IConvertible)value).ToDateTime(null);
				}
				break;
			}
		}
	}

	private unsafe bool Value_BOOL
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			*(short*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = (short)(value ? (-1) : 0);
		}
	}

	private unsafe byte[] Value_BYTES
	{
		get
		{
			int cbMaxLen = dbbindings[bindingIndx].cbMaxLen;
			int num = Math.Min(SizeValue, cbMaxLen);
			byte[] array = new byte[num];
			byte* ptr = (byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			int num2 = 0;
			while (num2 < num)
			{
				array[num2] = *ptr;
				num2++;
				ptr++;
			}
			return array;
		}
		set
		{
			if (value == null)
			{
				SetValueNull();
				return;
			}
			int num = value.Length;
			if (num > MaxLen)
			{
				if (!doTruncate)
				{
					throw new InvalidOperationException(Res.GetString("ADP_TruncatedBytes", MaxLen));
				}
				num = MaxLen;
			}
			SizeValue = num;
			byte* ptr = (byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			int num2 = 0;
			while (num2 < num)
			{
				*ptr = value[num2];
				num2++;
				ptr++;
			}
		}
	}

	private unsafe decimal Value_CY
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			decimal num = 10000m * value;
			*(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = (long)num;
		}
	}

	private unsafe DateTime Value_DATETIME
	{
		get
		{
			ulong num = (nuint)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			return new DateTime(*(short*)num, *(short*)(num + 2), *(short*)(num + 4), *(short*)(num + 6), *(short*)(num + 8), *(short*)(num + 10)).AddTicks(*(int*)(num + 12) / 100);
		}
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			ulong num = (nuint)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			*(short*)num = (short)value.Year;
			*(short*)(num + 2) = (short)value.Month;
			*(short*)(num + 4) = (short)value.Day;
			*(short*)(num + 6) = (short)value.Hour;
			*(short*)(num + 8) = (short)value.Minute;
			*(short*)(num + 10) = (short)value.Second;
			*(int*)(num + 12) = (int)(value.Ticks % 10000000 * 100);
		}
	}

	private unsafe Guid Value_GUID
	{
		get
		{
			return (Guid)Marshal.PtrToStructure(new IntPtr((void*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), GuidType);
		}
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			Marshal.StructureToPtr((object)value, new IntPtr((void*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), false);
		}
	}

	private unsafe byte Value_TINYINT
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			*(byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = value;
		}
	}

	private unsafe short Value_I2
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			*(short*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = value;
		}
	}

	private unsafe int Value_I4
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = value;
		}
	}

	private unsafe long Value_I8
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			*(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = value;
		}
	}

	private unsafe SqlDecimal Value_NUMERIC
	{
		get
		{
			byte* ptr = (byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			byte bPrecision = *(ptr++);
			byte bScale = *(ptr++);
			byte b = *(ptr++);
			int[] array = new int[4];
			fixed (int* ptr2 = &array[0])
			{
				byte* ptr3 = (byte*)ptr2;
				for (int i = 0; i < 16; i++)
				{
					*(ptr3++) = *(ptr++);
				}
			}
			bool fPositive = b == 1;
			return new SqlDecimal(bPrecision, bScale, fPositive, array);
		}
		set
		{
			byte b = 0;
			int[] array = null;
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			b = (byte)(value.IsPositive ? 1u : 0u);
			array = value.Data;
			byte* ptr = (byte*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			*(ptr++) = value.Precision;
			*(ptr++) = value.Scale;
			*(ptr++) = b;
			fixed (int* ptr2 = &array[0])
			{
				byte* ptr3 = (byte*)ptr2;
				for (int i = 0; i < 16; i++)
				{
					*(ptr++) = *(ptr3++);
				}
			}
		}
	}

	private unsafe float Value_R4
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			Marshal.StructureToPtr((object)value, new IntPtr((void*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), false);
		}
	}

	private unsafe double Value_R8
	{
		set
		{
			*(int*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obSize) = 0;
			Marshal.StructureToPtr((object)value, new IntPtr((void*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue)), false);
		}
	}

	private unsafe string Value_STRING
	{
		set
		{
			if (value == null)
			{
				SetValueNull();
				return;
			}
			int num = value.Length;
			if (SETYPE.NTEXT != dbbindings[bindingIndx].type)
			{
				int num2 = dbbindings[bindingIndx].cbMaxLen / 2 - 1;
				if (num > num2)
				{
					if (!doTruncate)
					{
						throw new InvalidOperationException(Res.GetString("ADP_TruncatedString", num2, num, value));
					}
					num = num2;
				}
			}
			SizeValue = (num + 1) * 2;
			char* ptr = (char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			int num3 = 0;
			while (num3 < num)
			{
				*ptr = value[num3];
				num3++;
				ptr++;
			}
			*ptr = '\0';
		}
	}

	private unsafe char[] Value_CHARS
	{
		set
		{
			if (value == null)
			{
				SetValueNull();
				return;
			}
			int num = value.Length;
			if (SETYPE.NTEXT != dbbindings[bindingIndx].type)
			{
				int num2 = dbbindings[bindingIndx].cbMaxLen / 2 - 1;
				if (num > num2)
				{
					if (!doTruncate)
					{
						throw new InvalidOperationException(Res.GetString("ADP_TruncatedString", num2, num, value));
					}
					num = num2;
				}
			}
			SizeValue = (num + 1) * 2;
			char* ptr = (char*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue);
			int num3 = 0;
			while (num3 < num)
			{
				*ptr = value[num3];
				num3++;
				ptr++;
			}
			*ptr = '\0';
		}
	}

	internal Accessor(int count)
	{
		this.count = count;
		dbbindings = new MEDBBINDING[count];
		columnNames = new string[count];
		int num = 0;
		int num2 = AlignDataSize(count * IntPtr.Size);
		int num3 = 0;
		while (num3 < count)
		{
			dbbindings[num3].obSize = num2;
			dbbindings[num3].obStatus = num;
			num3++;
			num2 += IntPtr.Size;
			num += 4;
		}
		dataBufferSize = AlignDataSize(num2);
		actualBufferSize = DataBufferSize;
	}

	~Accessor()
	{
		Dispose();
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	internal void Dispose()
	{
		if (dbbindings != null)
		{
			for (int i = 0; i < dbbindings.Length; i++)
			{
				if (IntPtr.Zero != dbbindings[i].pObject)
				{
					NativeMethods.CoTaskMemFree(dbbindings[i].pObject);
				}
			}
			dbbindings = null;
			pValueArray = null;
		}
		if (IntPtr.Zero != dataHandle)
		{
			NativeMethods.CoTaskMemFree(dataHandle);
			dataHandle = IntPtr.Zero;
		}
		GC.SuppressFinalize(this);
	}

	internal void AllocData()
	{
		dataHandle = NativeMethods.CoTaskMemAlloc(actualBufferSize);
		if (IntPtr.Zero == dataHandle)
		{
			throw new OutOfMemoryException();
		}
		NativeMethods.uwutil_ZeroMemory(dataHandle, actualBufferSize);
		ulong num = (ulong)(long)dataHandle;
		int num2 = Math.Max(count, numValues);
		pValueArray = new ulong[num2];
		for (int i = 0; i < num2; i++)
		{
			ulong num3 = num + (ulong)(dataBufferSize * (i / count));
			pValueArray[i] = num3;
		}
		GC.KeepAlive(dataHandle);
	}

	private Exception CheckTypeValueStatusValue(Type type)
	{
		if (StatusValue == DBStatus.S_OK)
		{
			return new InvalidCastException(Res.GetString("OleDb_CantConvertValue"));
		}
		switch (StatusValue)
		{
		case DBStatus.E_BADSTATUS:
		{
			string minorErrorMessage = NativeMethods.GetMinorErrorMessage(dbbindings[bindingIndx].minor_pError);
			if (!string.IsNullOrEmpty(minorErrorMessage))
			{
				SqlCeErrorCollection sqlCeErrorCollection = new SqlCeErrorCollection();
				sqlCeErrorCollection.Add(new SqlCeError(-2147467259, minorErrorMessage, dbbindings[bindingIndx].minor_pError, "Sql Server Compact ADO.NET Data Provider", 0, 0, 0, null, null, null));
				return SqlCeException.CreateException(sqlCeErrorCollection);
			}
			return new InvalidOperationException(Res.GetString("OleDb_BadStatus"));
		}
		case DBStatus.E_BADACCESSOR:
			return new InvalidOperationException(Res.GetString("OleDb_BadAccessor"));
		case DBStatus.E_CANTCONVERTVALUE:
			return new InvalidCastException(Res.GetString("OleDb_CantConvertValue"));
		case DBStatus.S_ISNULL:
			return new InvalidCastException();
		case DBStatus.E_SIGNMISMATCH:
			return new InvalidOperationException(Res.GetString("OleDb_SignMismatch", type.Name));
		case DBStatus.E_DATAOVERFLOW:
			return new InvalidOperationException(Res.GetString("OleDb_DataOverflow", type.Name));
		case DBStatus.E_CANTCREATE:
			return new InvalidOperationException(Res.GetString("OleDb_CantCreate", type.Name));
		case DBStatus.E_UNAVAILABLE:
			return new InvalidOperationException(Res.GetString("OleDb_Unavailable", type.Name));
		default:
			return new InvalidOperationException(Res.GetString("OleDb_UnexpectedStatusValue", StatusValue));
		case DBStatus.S_OK:
		case DBStatus.S_TRUNCATED:
			return new InvalidCastException(Res.GetString("OleDb_CantConvertValue"));
		}
	}

	internal unsafe void SetValueDBNull()
	{
		SizeValue = 0;
		StatusValue = DBStatus.S_ISNULL;
		*(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = 0L;
	}

	internal unsafe void SetValueNull()
	{
		SizeValue = 0;
		StatusValue = DBStatus.S_DEFAULT;
		*(long*)(pValueArray[index] + (ulong)dbbindings[bindingIndx].obValue) = 0L;
	}

	private static int AlignDataSize(int value)
	{
		if (value != 0)
		{
			return (value + 7) & -8;
		}
		return 8;
	}
}
