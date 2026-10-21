using System.Data.SqlTypes;

namespace System.Data.SqlServerCe;

public sealed class SqlCeType
{
	internal struct DataTypeAlias
	{
		public string dataType;

		public SqlCeType sqlCeType;
	}

	internal static readonly SqlCeType _SByte = new SqlCeType(3, 0, 1, isFixed: true, isBLOB: false, SqlDbType.TinyInt, SETYPE.TINYINT, "TinyInt", DbType.SByte, typeof(sbyte));

	internal static readonly SqlCeType _SmallInt = new SqlCeType(5, 0, 2, isFixed: true, isBLOB: false, SqlDbType.SmallInt, SETYPE.SMALLINT, "SmallInt", DbType.Int16, typeof(short));

	internal static readonly SqlCeType _Int = new SqlCeType(10, 0, 4, isFixed: true, isBLOB: false, SqlDbType.Int, SETYPE.INTEGER, "Int", DbType.Int32, typeof(int));

	internal static readonly SqlCeType _BigInt = new SqlCeType(19, 0, 8, isFixed: true, isBLOB: false, SqlDbType.BigInt, SETYPE.BIGINT, "BigInt", DbType.Int64, typeof(long));

	internal static readonly SqlCeType _TinyInt = new SqlCeType(3, 0, 1, isFixed: true, isBLOB: false, SqlDbType.TinyInt, SETYPE.TINYINT, "TinyInt", DbType.Byte, typeof(byte));

	internal static readonly SqlCeType _UInt16 = new SqlCeType(5, 0, 2, isFixed: true, isBLOB: false, SqlDbType.SmallInt, SETYPE.UI2, "SmallInt", DbType.UInt16, typeof(ushort));

	internal static readonly SqlCeType _UInt32 = new SqlCeType(10, 0, 4, isFixed: true, isBLOB: false, SqlDbType.Int, SETYPE.UI4, "Int", DbType.UInt32, typeof(uint));

	internal static readonly SqlCeType _UInt64 = new SqlCeType(19, 0, 8, isFixed: true, isBLOB: false, SqlDbType.BigInt, SETYPE.UI8, "BigInt", DbType.UInt64, typeof(ulong));

	internal static readonly SqlCeType _Real = new SqlCeType(24, 0, 4, isFixed: true, isBLOB: false, SqlDbType.Real, SETYPE.REAL, "Real", DbType.Single, typeof(float));

	internal static readonly SqlCeType _Float = new SqlCeType(53, 0, 8, isFixed: true, isBLOB: false, SqlDbType.Float, SETYPE.FLOAT, "Float", DbType.Double, typeof(double));

	internal static readonly SqlCeType _Money = new SqlCeType(19, 4, 8, isFixed: true, isBLOB: false, SqlDbType.Money, SETYPE.MONEY, "Money", DbType.Currency, typeof(decimal));

	internal static readonly SqlCeType _Numeric = new SqlCeType(18, 0, 19, isFixed: true, isBLOB: false, SqlDbType.Decimal, SETYPE.NUMERIC, "Numeric", DbType.Decimal, typeof(decimal));

	internal static readonly SqlCeType _Bit = new SqlCeType(1, 0, 2, isFixed: true, isBLOB: false, SqlDbType.Bit, SETYPE.BIT, "Bit", DbType.Boolean, typeof(bool));

	internal static readonly SqlCeType _UniqueIdentifier = new SqlCeType(0, 0, 16, isFixed: true, isBLOB: false, SqlDbType.UniqueIdentifier, SETYPE.UNIQUEIDENTIFIER, "UniqueIdentifier", DbType.Guid, typeof(Guid));

	internal static readonly SqlCeType _Binary = new SqlCeType(0, 0, -1, isFixed: true, isBLOB: false, SqlDbType.Binary, SETYPE.BINARY, "Binary", DbType.Binary, typeof(byte[]));

	internal static readonly SqlCeType _RowVersion = new SqlCeType(0, 0, 8, isFixed: true, isBLOB: false, SqlDbType.Timestamp, SETYPE.ROWVERSION, "RowVersion", DbType.Binary, typeof(byte[]));

	internal static readonly SqlCeType _Image = new SqlCeType(0, 0, -1, isFixed: false, isBLOB: true, SqlDbType.Image, SETYPE.IMAGE, "Image", DbType.Binary, typeof(byte[]));

	internal static readonly SqlCeType _VarBinary = new SqlCeType(0, 0, -1, isFixed: false, isBLOB: false, SqlDbType.VarBinary, SETYPE.VARBINARY, "VarBinary", DbType.Binary, typeof(byte[]));

	internal static readonly SqlCeType _NText = new SqlCeType(0, 0, -1, isFixed: false, isBLOB: true, SqlDbType.NText, SETYPE.NTEXT, "NText", DbType.String, typeof(string));

	internal static readonly SqlCeType _NChar = new SqlCeType(0, 0, -1, isFixed: true, isBLOB: false, SqlDbType.NChar, SETYPE.NCHAR, "NChar", DbType.StringFixedLength, typeof(string));

	internal static readonly SqlCeType _NVarChar = new SqlCeType(0, 0, -1, isFixed: false, isBLOB: false, SqlDbType.NVarChar, SETYPE.NVARCHAR, "NVarChar", DbType.String, typeof(string));

	internal static readonly SqlCeType _DateTime = new SqlCeType(23, 3, 16, isFixed: true, isBLOB: false, SqlDbType.DateTime, SETYPE.DATETIME, "DateTime", DbType.DateTime, typeof(DateTime));

	internal static readonly SqlCeType Default = _NVarChar;

	internal static DataTypeAlias[] _aliasTypes;

	internal static readonly SqlCeType[] _AllTypes = new SqlCeType[22]
	{
		_SmallInt, _Int, _BigInt, _TinyInt, _Real, _Float, _Money, _Numeric, _Bit, _UniqueIdentifier,
		_VarBinary, _Binary, _Image, _NVarChar, _NText, _NChar, _DateTime, _RowVersion, _SByte, _UInt16,
		_UInt32, _UInt64
	};

	internal static readonly int MAX_BINARY_COLUMN_SIZE = 8000;

	internal static readonly int MAX_IMAGE_COLUMN_SIZE = 1073741823;

	internal static readonly int MAX_NCHAR_COLUMN_SIZE = 4000;

	internal static readonly int MAX_NTEXT_COLUMN_SIZE = 536870911;

	internal readonly SETYPE seType;

	internal readonly string dataType;

	internal readonly Type clrType;

	internal readonly DbType dbType;

	internal readonly SqlDbType sqlDbType;

	internal readonly bool isFixed;

	internal readonly bool isBLOB;

	internal readonly byte maxpre;

	internal readonly byte scale;

	internal readonly int fixlen;

	internal static int[] SqlDbTypeConversionMatrix = new int[24]
	{
		1130341, 2637954, 1130341, 0, 7184, 1130341, 1130341, 2637954, 1130341, 1130341,
		1146743, 1146743, 1146743, 1130341, 2120834, 0, 1130341, 0, 0, 2621570,
		1130341, 2637954, 0, 0
	};

	private static DataTypeAlias[] _AliasTypes
	{
		get
		{
			if (_aliasTypes == null)
			{
				_aliasTypes = new DataTypeAlias[2];
				_aliasTypes[0].dataType = "TimeStamp";
				_aliasTypes[0].sqlCeType = _RowVersion;
				_aliasTypes[1].dataType = "Decimal";
				_aliasTypes[1].sqlCeType = _Numeric;
			}
			return _aliasTypes;
		}
	}

	public SqlDbType SqlDbType => sqlDbType;

	internal SETYPE SeType => seType;

	internal string DataType => dataType;

	internal Type ClrType => clrType;

	internal DbType DbType => dbType;

	internal bool IsLongValue => isBLOB;

	internal bool IsFixed => isFixed;

	private SqlCeType(byte maxpre, byte scale, int fixlen, bool isFixed, bool isBLOB, SqlDbType sqlDbType, SETYPE seType, string dataType, DbType dbType, Type clrType)
	{
		this.isFixed = isFixed;
		this.isBLOB = isBLOB;
		this.maxpre = maxpre;
		this.scale = scale;
		this.fixlen = fixlen;
		this.sqlDbType = sqlDbType;
		this.seType = seType;
		this.dataType = dataType;
		this.dbType = dbType;
		this.clrType = clrType;
	}

	internal static SqlCeType FromSeType(SETYPE type)
	{
		for (int i = 0; i < _AllTypes.Length; i++)
		{
			if (type == _AllTypes[i].SeType)
			{
				return _AllTypes[i];
			}
		}
		_ = 22;
		return _NChar;
	}

	internal static SqlCeType FromDbType(DbType type)
	{
		for (int i = 0; i < _AllTypes.Length; i++)
		{
			if (type == _AllTypes[i].DbType)
			{
				return _AllTypes[i];
			}
		}
		throw new ArgumentException(Res.GetString("ADP_UnknownDataType", type.ToString(), typeof(SqlDbType).Name));
	}

	internal static SqlCeType FromSqlDbType(SqlDbType type)
	{
		for (int i = 0; i < _AllTypes.Length; i++)
		{
			if (type == _AllTypes[i].SqlDbType)
			{
				return _AllTypes[i];
			}
		}
		throw new ArgumentException(type.ToString());
	}

	internal static SqlCeType FromDataType(string dataType)
	{
		for (int i = 0; i < _AllTypes.Length; i++)
		{
			if (dataType.Equals(_AllTypes[i].DataType, StringComparison.OrdinalIgnoreCase))
			{
				return _AllTypes[i];
			}
		}
		for (int j = 0; j < _AliasTypes.Length; j++)
		{
			if (dataType.Equals(_AliasTypes[j].dataType, StringComparison.OrdinalIgnoreCase))
			{
				return _AliasTypes[j].sqlCeType;
			}
		}
		throw new ArgumentException(dataType);
	}

	internal static Type SqlDbType2SqlType(SqlDbType type)
	{
		return type switch
		{
			SqlDbType.TinyInt => typeof(SqlByte), 
			SqlDbType.SmallInt => typeof(SqlInt16), 
			SqlDbType.Int => typeof(SqlInt32), 
			SqlDbType.BigInt => typeof(SqlInt64), 
			SqlDbType.Real => typeof(SqlSingle), 
			SqlDbType.Float => typeof(SqlDouble), 
			SqlDbType.Money => typeof(SqlMoney), 
			SqlDbType.Bit => typeof(SqlBoolean), 
			SqlDbType.UniqueIdentifier => typeof(SqlGuid), 
			SqlDbType.Binary => typeof(SqlBinary), 
			SqlDbType.Timestamp => typeof(SqlBinary), 
			SqlDbType.VarBinary => typeof(SqlBinary), 
			SqlDbType.Image => typeof(SqlBinary), 
			SqlDbType.NText => typeof(SqlString), 
			SqlDbType.NChar => typeof(SqlString), 
			SqlDbType.NVarChar => typeof(SqlString), 
			SqlDbType.Decimal => typeof(SqlDecimal), 
			SqlDbType.DateTime => typeof(SqlDateTime), 
			_ => throw new ArgumentException(type.ToString()), 
		};
	}

	internal static SqlCeType FromClrType(object value)
	{
		Type type = ((!(value is Type)) ? value.GetType() : ((Type)value));
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.Empty:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.Empty));
		case TypeCode.Object:
			if ((object)type == typeof(byte[]))
			{
				return _VarBinary;
			}
			if ((object)type == typeof(Guid))
			{
				return _UniqueIdentifier;
			}
			if ((object)type == typeof(SqlBinary))
			{
				return _VarBinary;
			}
			if ((object)type == typeof(SqlBoolean))
			{
				return _Bit;
			}
			if ((object)type == typeof(SqlBoolean))
			{
				return _Bit;
			}
			if ((object)type == typeof(SqlByte))
			{
				return _TinyInt;
			}
			if ((object)type == typeof(SqlDateTime))
			{
				return _DateTime;
			}
			if ((object)type == typeof(SqlDouble))
			{
				return _Float;
			}
			if ((object)type == typeof(SqlGuid))
			{
				return _UniqueIdentifier;
			}
			if ((object)type == typeof(SqlInt16))
			{
				return _SmallInt;
			}
			if ((object)type == typeof(SqlInt32))
			{
				return _Int;
			}
			if ((object)type == typeof(SqlInt64))
			{
				return _BigInt;
			}
			if ((object)type == typeof(SqlMoney))
			{
				return _Money;
			}
			if ((object)type == typeof(SqlDecimal))
			{
				return _Numeric;
			}
			if ((object)type == typeof(SqlSingle))
			{
				return _Real;
			}
			if ((object)type == typeof(SqlString))
			{
				return _NVarChar;
			}
			throw new ArgumentException(Res.GetString("ADP_UnknownDataType", type, typeof(SqlCeType).Name));
		case TypeCode.DBNull:
			throw new ArgumentException(Res.GetString("ADP_UnknownDataType", TypeCode.DBNull, typeof(SqlCeType).Name));
		case TypeCode.Boolean:
			return _Bit;
		case TypeCode.Char:
			return _NVarChar;
		case TypeCode.SByte:
			return _SByte;
		case TypeCode.Byte:
			return _TinyInt;
		case TypeCode.Int16:
			return _SmallInt;
		case TypeCode.UInt16:
			return _UInt16;
		case TypeCode.Int32:
			return _Int;
		case TypeCode.UInt32:
			return _UInt32;
		case TypeCode.Int64:
			return _BigInt;
		case TypeCode.UInt64:
			return _UInt64;
		case TypeCode.Single:
			return _Real;
		case TypeCode.Double:
			return _Float;
		case TypeCode.Decimal:
			return _Numeric;
		case TypeCode.DateTime:
			return _DateTime;
		case TypeCode.String:
			return _NVarChar;
		default:
			throw new ArgumentException(Res.GetString("ADP_UnknownDataType", Type.GetTypeCode(type), typeof(SqlCeType).Name));
		}
	}

	public override string ToString()
	{
		return DataType;
	}

	internal static void ValidateDataConversion(SqlDbType expectedType, SqlDbType actualType)
	{
		int num = 1 << (int)actualType;
		if ((num & SqlDbTypeConversionMatrix[(int)expectedType]) == 0)
		{
			throw new ArgumentException(Res.GetString("Expr_DatatypeConvertion", actualType.ToString(), expectedType.ToString()));
		}
	}
}
