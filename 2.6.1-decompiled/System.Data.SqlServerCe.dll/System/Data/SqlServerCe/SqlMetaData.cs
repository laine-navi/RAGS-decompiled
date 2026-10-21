using System.Data.SqlTypes;
using System.Globalization;

namespace System.Data.SqlServerCe;

public sealed class SqlMetaData
{
	private const long x_lMax = -1L;

	private const long x_lServerMaxUnicode = 4000L;

	private const long x_lServerMaxANSI = 8000L;

	private const long x_lServerMaxBinary = 8000L;

	private const SqlCompareOptions x_eDefaultStringCompareOptions = SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth;

	private string m_strName;

	private long m_lMaxLength;

	private SqlDbType m_sqlDbType;

	private byte m_bPrecision;

	private byte m_bScale;

	private long m_lLocale;

	private SqlCompareOptions m_eCompareOptions;

	private bool m_bPartialLength;

	private static byte[] __maxLenFromPrecision = new byte[38]
	{
		5, 5, 5, 5, 5, 5, 5, 5, 5, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 17, 17,
		17, 17, 17, 17, 17, 17, 17, 17
	};

	private static readonly DateTime x_dtSmallMax = new DateTime(2079, 6, 6, 23, 59, 29, 998);

	private static readonly DateTime x_dtSmallMin = new DateTime(1899, 12, 31, 23, 59, 29, 999);

	private static readonly SqlMoney x_smSmallMax = new SqlMoney(214748.3647m);

	private static readonly SqlMoney x_smSmallMin = new SqlMoney(-214748.3648m);

	private static DbType[] sxm_rgSqlDbTypeToDbType = new DbType[30]
	{
		DbType.Int64,
		DbType.Binary,
		DbType.Boolean,
		DbType.AnsiString,
		DbType.DateTime,
		DbType.Decimal,
		DbType.Double,
		DbType.Binary,
		DbType.Int32,
		DbType.Currency,
		DbType.String,
		DbType.String,
		DbType.String,
		DbType.Single,
		DbType.Guid,
		DbType.DateTime,
		DbType.Int16,
		DbType.Currency,
		DbType.AnsiString,
		DbType.Binary,
		DbType.Byte,
		DbType.Binary,
		DbType.AnsiString,
		DbType.Object,
		DbType.Object,
		DbType.Xml,
		DbType.String,
		DbType.String,
		DbType.String,
		DbType.Object
	};

	internal static SqlMetaData[] sxm_rgDefaults = new SqlMetaData[30]
	{
		new SqlMetaData("bigint", SqlDbType.BigInt, 8L, 19, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("binary", SqlDbType.Binary, 1L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("bit", SqlDbType.Bit, 1L, 1, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("char", SqlDbType.Char, 1L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("datetime", SqlDbType.DateTime, 8L, 23, 3, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("decimal", SqlDbType.Decimal, 9L, 18, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("float", SqlDbType.Float, 8L, 53, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("image", SqlDbType.Image, -1L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("int", SqlDbType.Int, 4L, 10, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("money", SqlDbType.Money, 8L, 19, 4, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("nchar", SqlDbType.NChar, 1L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("ntext", SqlDbType.NText, -1L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("nvarchar", SqlDbType.NVarChar, 4000L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("real", SqlDbType.Real, 4L, 24, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("uniqueidentifier", SqlDbType.UniqueIdentifier, 16L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("smalldatetime", SqlDbType.SmallDateTime, 4L, 16, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("smallint", SqlDbType.SmallInt, 2L, 5, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("smallmoney", SqlDbType.SmallMoney, 4L, 10, 4, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("text", SqlDbType.Text, -1L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("rowversion", SqlDbType.Timestamp, 8L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("tinyint", SqlDbType.TinyInt, 1L, 3, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("varbinary", SqlDbType.VarBinary, 8000L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		new SqlMetaData("varchar", SqlDbType.VarChar, 8000L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("sql_variant", SqlDbType.Variant, 8016L, 0, 0, 0L, SqlCompareOptions.None, partialLength: false),
		null,
		null,
		new SqlMetaData("nvarchar", SqlDbType.NVarChar, 1L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("nvarchar", SqlDbType.NVarChar, 4000L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		new SqlMetaData("nvarchar", SqlDbType.NVarChar, 4000L, 0, 0, 0L, SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth, partialLength: false),
		null
	};

	public SqlCompareOptions CompareOptions => m_eCompareOptions;

	public DbType DbType => sxm_rgSqlDbTypeToDbType[(int)m_sqlDbType];

	public long LocaleId => m_lLocale;

	public static long Max => -1L;

	public long MaxLength => m_lMaxLength;

	public string Name => m_strName;

	public byte Precision => m_bPrecision;

	public byte Scale => m_bScale;

	public SqlDbType SqlDbType => m_sqlDbType;

	public string TypeName => sxm_rgDefaults[(int)SqlDbType].Name;

	internal bool IsPartialLength => m_bPartialLength;

	public SqlMetaData(string name, SqlDbType dbType)
	{
		Construct(name, dbType);
	}

	public SqlMetaData(string name, SqlDbType dbType, long maxLength)
	{
		Construct(name, dbType, maxLength);
	}

	public SqlMetaData(string name, SqlDbType dbType, byte precision, byte scale)
	{
		Construct(name, dbType, precision, scale);
	}

	public SqlMetaData(string name, SqlDbType dbType, long maxLength, long locale, SqlCompareOptions compareOptions)
	{
		Construct(name, dbType, maxLength, locale, compareOptions);
	}

	public SqlMetaData(string name, SqlDbType dbType, long maxLength, byte precision, byte scale, long localeId, SqlCompareOptions compareOptions, Type userDefinedType)
	{
		switch (dbType)
		{
		case SqlDbType.BigInt:
		case SqlDbType.Bit:
		case SqlDbType.DateTime:
		case SqlDbType.Float:
		case SqlDbType.Image:
		case SqlDbType.Int:
		case SqlDbType.Money:
		case SqlDbType.Real:
		case SqlDbType.UniqueIdentifier:
		case SqlDbType.SmallDateTime:
		case SqlDbType.SmallInt:
		case SqlDbType.SmallMoney:
		case SqlDbType.Timestamp:
		case SqlDbType.TinyInt:
		case SqlDbType.Xml:
			Construct(name, dbType);
			break;
		case SqlDbType.Binary:
		case SqlDbType.VarBinary:
			Construct(name, dbType, maxLength);
			break;
		case SqlDbType.Char:
		case SqlDbType.NChar:
		case SqlDbType.NText:
		case SqlDbType.NVarChar:
		case SqlDbType.Text:
		case SqlDbType.VarChar:
			Construct(name, dbType, maxLength, localeId, compareOptions);
			break;
		case SqlDbType.Decimal:
			Construct(name, dbType, precision, scale);
			break;
		case SqlDbType.Variant:
			Construct(name, dbType);
			break;
		default:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", dbType.ToString()));
		}
	}

	private SqlMetaData(string name, SqlDbType sqlDbType, long maxLength, byte precision, byte scale, long localeId, SqlCompareOptions compareOptions, bool partialLength)
	{
		AssertNameIsValid(name);
		m_strName = name;
		m_sqlDbType = sqlDbType;
		m_lMaxLength = maxLength;
		m_bPrecision = precision;
		m_bScale = scale;
		m_lLocale = localeId;
		m_eCompareOptions = compareOptions;
		m_bPartialLength = partialLength;
	}

	private void Construct(string name, SqlDbType dbType)
	{
		AssertNameIsValid(name);
		if (SqlDbType.Binary == dbType || SqlDbType.Char == dbType || SqlDbType.NChar == dbType || SqlDbType.NVarChar == dbType || SqlDbType.VarBinary == dbType || SqlDbType.VarChar == dbType || SqlDbType.BigInt > dbType)
		{
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", dbType.ToString()));
		}
		SetDefaultsForType(dbType);
		if (SqlDbType.NText == dbType || SqlDbType.Text == dbType)
		{
			m_lLocale = CultureInfo.CurrentCulture.LCID;
		}
		m_strName = name;
	}

	private void Construct(string name, SqlDbType dbType, long maxLength)
	{
		AssertNameIsValid(name);
		long lLocale = 0L;
		if (SqlDbType.Char == dbType)
		{
			if (maxLength > 8000 || maxLength < 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
			lLocale = CultureInfo.CurrentCulture.LCID;
		}
		else if (SqlDbType.VarChar == dbType)
		{
			if ((maxLength > 8000 || maxLength < 0) && maxLength != Max)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
			lLocale = CultureInfo.CurrentCulture.LCID;
		}
		else if (SqlDbType.NChar == dbType)
		{
			if (maxLength > 4000 || maxLength < 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
			lLocale = CultureInfo.CurrentCulture.LCID;
		}
		else if (SqlDbType.NVarChar == dbType)
		{
			if ((maxLength > 4000 || maxLength < 0) && maxLength != Max)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
			lLocale = CultureInfo.CurrentCulture.LCID;
		}
		else if (SqlDbType.NText == dbType || SqlDbType.Text == dbType)
		{
			if (Max != maxLength)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
			lLocale = CultureInfo.CurrentCulture.LCID;
		}
		else if (SqlDbType.Binary == dbType)
		{
			if (maxLength > 8000 || maxLength < 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else if (SqlDbType.VarBinary == dbType)
		{
			if ((maxLength > 8000 || maxLength < 0) && maxLength != Max)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else
		{
			if (SqlDbType.Image != dbType)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataType", dbType.ToString()));
			}
			if (Max != maxLength)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		SetDefaultsForType(dbType);
		m_strName = name;
		m_lMaxLength = maxLength;
		m_lLocale = lLocale;
	}

	private void Construct(string name, SqlDbType dbType, long maxLength, long locale, SqlCompareOptions compareOptions)
	{
		AssertNameIsValid(name);
		if (SqlDbType.Char == dbType)
		{
			if (maxLength > 8000 || maxLength < 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else if (SqlDbType.VarChar == dbType)
		{
			if ((maxLength > 8000 || maxLength < 0) && maxLength != Max)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else if (SqlDbType.NChar == dbType)
		{
			if (maxLength > 4000 || maxLength < 0)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else if (SqlDbType.NVarChar == dbType)
		{
			if ((maxLength > 4000 || maxLength < 0) && maxLength != Max)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		else
		{
			if (SqlDbType.NText != dbType && SqlDbType.Text != dbType)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataType", dbType.ToString()));
			}
			if (Max != maxLength)
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataLength2", maxLength.ToString(CultureInfo.InvariantCulture)), "maxLength");
			}
		}
		if (SqlCompareOptions.BinarySort != compareOptions && (~(SqlCompareOptions.IgnoreCase | SqlCompareOptions.IgnoreNonSpace | SqlCompareOptions.IgnoreKanaType | SqlCompareOptions.IgnoreWidth) & compareOptions) != 0)
		{
			throw new ArgumentException(compareOptions.ToString());
		}
		SetDefaultsForType(dbType);
		m_strName = name;
		m_lMaxLength = maxLength;
		m_lLocale = locale;
		m_eCompareOptions = compareOptions;
	}

	private void Construct(string name, SqlDbType dbType, byte precision, byte scale)
	{
		AssertNameIsValid(name);
		if (SqlDbType.Decimal != dbType)
		{
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", dbType.ToString()));
		}
		if (precision > SqlDecimal.MaxPrecision || scale > precision)
		{
			throw new ArgumentException(Res.GetString("SQL_PrecisionValueOutOfRange", precision));
		}
		if (scale > SqlDecimal.MaxScale)
		{
			throw new ArgumentException(Res.GetString("SQL_ScaleValueOutOfRange", scale));
		}
		SetDefaultsForType(SqlDbType.Decimal);
		m_strName = name;
		m_bPrecision = precision;
		m_bScale = scale;
		m_lMaxLength = __maxLenFromPrecision[precision - 1];
	}

	private void AssertNameIsValid(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
	}

	public short Adjust(short value)
	{
		if (SqlDbType.SmallInt != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public int Adjust(int value)
	{
		if (SqlDbType.Int != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public long Adjust(long value)
	{
		if (SqlDbType != SqlDbType.BigInt)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public float Adjust(float value)
	{
		if (SqlDbType.Real != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public double Adjust(double value)
	{
		if (SqlDbType.Float != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public string Adjust(string value)
	{
		if (SqlDbType.Char == SqlDbType || SqlDbType.NChar == SqlDbType)
		{
			if (value != null && value.Length < MaxLength)
			{
				value = value.PadRight((int)MaxLength);
			}
		}
		else if (SqlDbType.VarChar != SqlDbType && SqlDbType.NVarChar != SqlDbType && SqlDbType.Text != SqlDbType && SqlDbType.NText != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value == null)
		{
			return null;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			value = value.Remove((int)MaxLength, (int)(value.Length - MaxLength));
		}
		return value;
	}

	public decimal Adjust(decimal value)
	{
		if (SqlDbType.Decimal != SqlDbType && SqlDbType.Money != SqlDbType && SqlDbType.SmallMoney != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (SqlDbType.Decimal != SqlDbType)
		{
			VerifyMoneyRange(new SqlMoney(value));
			return value;
		}
		return InternalAdjustSqlDecimal(new SqlDecimal(value)).Value;
	}

	public DateTime Adjust(DateTime value)
	{
		if (SqlDbType.DateTime != SqlDbType && SqlDbType.SmallDateTime != SqlDbType)
		{
			ThrowInvalidType();
		}
		VerifyDateTimeRange(value);
		return value;
	}

	public Guid Adjust(Guid value)
	{
		if (SqlDbType.UniqueIdentifier != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlBoolean Adjust(SqlBoolean value)
	{
		if (SqlDbType.Bit != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlByte Adjust(SqlByte value)
	{
		if (SqlDbType.TinyInt != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlInt16 Adjust(SqlInt16 value)
	{
		if (SqlDbType.SmallInt != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlInt32 Adjust(SqlInt32 value)
	{
		if (SqlDbType.Int != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlInt64 Adjust(SqlInt64 value)
	{
		if (SqlDbType != SqlDbType.BigInt)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlSingle Adjust(SqlSingle value)
	{
		if (SqlDbType.Real != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlDouble Adjust(SqlDouble value)
	{
		if (SqlDbType.Float != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlMoney Adjust(SqlMoney value)
	{
		if (SqlDbType.Money != SqlDbType && SqlDbType.SmallMoney != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (!value.IsNull)
		{
			VerifyMoneyRange(value);
		}
		return value;
	}

	public SqlDateTime Adjust(SqlDateTime value)
	{
		if (SqlDbType.DateTime != SqlDbType && SqlDbType.SmallDateTime != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (!value.IsNull)
		{
			VerifyDateTimeRange(value.Value);
		}
		return value;
	}

	public SqlDecimal Adjust(SqlDecimal value)
	{
		if (SqlDbType.Decimal != SqlDbType)
		{
			ThrowInvalidType();
		}
		return InternalAdjustSqlDecimal(value);
	}

	public SqlString Adjust(SqlString value)
	{
		if (SqlDbType.Char == SqlDbType || SqlDbType.NChar == SqlDbType)
		{
			if (!value.IsNull && value.Value.Length < MaxLength)
			{
				return new SqlString(value.Value.PadRight((int)MaxLength));
			}
		}
		else if (SqlDbType.VarChar != SqlDbType && SqlDbType.NVarChar != SqlDbType && SqlDbType.Text != SqlDbType && SqlDbType.NText != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value.IsNull)
		{
			return value;
		}
		if (value.Value.Length > MaxLength && Max != MaxLength)
		{
			value = new SqlString(value.Value.Remove((int)MaxLength, (int)(value.Value.Length - MaxLength)));
		}
		return value;
	}

	public SqlBinary Adjust(SqlBinary value)
	{
		if (SqlDbType.Binary == SqlDbType || SqlDbType.Timestamp == SqlDbType)
		{
			if (!value.IsNull && value.Length < MaxLength)
			{
				byte[] value2 = value.Value;
				byte[] array = new byte[MaxLength];
				Array.Copy(value2, array, value2.Length);
				Array.Clear(array, value2.Length, array.Length - value2.Length);
				return new SqlBinary(array);
			}
		}
		else if (SqlDbType.VarBinary != SqlDbType && SqlDbType.Image != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value.IsNull)
		{
			return value;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			byte[] value3 = value.Value;
			byte[] array2 = new byte[MaxLength];
			Array.Copy(value3, array2, (int)MaxLength);
			value = new SqlBinary(array2);
		}
		return value;
	}

	public SqlGuid Adjust(SqlGuid value)
	{
		if (SqlDbType.UniqueIdentifier != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public SqlChars Adjust(SqlChars value)
	{
		if (SqlDbType.Char == SqlDbType || SqlDbType.NChar == SqlDbType)
		{
			if (value != null && !value.IsNull)
			{
				long length = value.Length;
				if (length < MaxLength)
				{
					if (value.MaxLength < MaxLength)
					{
						char[] array = new char[(int)MaxLength];
						Array.Copy(value.Buffer, array, (int)length);
						value = new SqlChars(array);
					}
					char[] buffer = value.Buffer;
					for (long num = length; num < MaxLength; num++)
					{
						buffer[num] = ' ';
					}
					value.SetLength(MaxLength);
					return value;
				}
			}
		}
		else if (SqlDbType.VarChar != SqlDbType && SqlDbType.NVarChar != SqlDbType && SqlDbType.Text != SqlDbType && SqlDbType.NText != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value == null || value.IsNull)
		{
			return value;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			value.SetLength(MaxLength);
		}
		return value;
	}

	public SqlBytes Adjust(SqlBytes value)
	{
		if (SqlDbType.Binary == SqlDbType || SqlDbType.Timestamp == SqlDbType)
		{
			if (value != null && !value.IsNull)
			{
				int num = (int)value.Length;
				if (num < MaxLength)
				{
					if (value.MaxLength < MaxLength)
					{
						byte[] array = new byte[MaxLength];
						Array.Copy(value.Buffer, array, num);
						value = new SqlBytes(array);
					}
					byte[] buffer = value.Buffer;
					Array.Clear(buffer, num, buffer.Length - num);
					value.SetLength(MaxLength);
					return value;
				}
			}
		}
		else if (SqlDbType.VarBinary != SqlDbType && SqlDbType.Image != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value == null || value.IsNull)
		{
			return value;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			value.SetLength(MaxLength);
		}
		return value;
	}

	public object Adjust(object value)
	{
		if (value == null)
		{
			return null;
		}
		Type type = value.GetType();
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.Boolean:
			value = Adjust((bool)value);
			break;
		case TypeCode.Byte:
			value = Adjust((byte)value);
			break;
		case TypeCode.Char:
			value = Adjust((char)value);
			break;
		case TypeCode.DateTime:
			value = Adjust((DateTime)value);
			break;
		case TypeCode.Decimal:
			value = Adjust((decimal)value);
			break;
		case TypeCode.Double:
			value = Adjust((double)value);
			break;
		case TypeCode.Empty:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.Empty));
		case TypeCode.Int16:
			value = Adjust((short)value);
			break;
		case TypeCode.Int32:
			value = Adjust((int)value);
			break;
		case TypeCode.Int64:
			value = Adjust((long)value);
			break;
		case TypeCode.SByte:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.SByte));
		case TypeCode.Single:
			value = Adjust((float)value);
			break;
		case TypeCode.String:
			value = Adjust((string)value);
			break;
		case TypeCode.UInt16:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.UInt16));
		case TypeCode.UInt32:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.UInt32));
		case TypeCode.UInt64:
			throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.UInt64));
		case TypeCode.Object:
			if ((object)type == typeof(byte[]))
			{
				value = Adjust((byte[])value);
				break;
			}
			if ((object)type == typeof(char[]))
			{
				value = Adjust((char[])value);
				break;
			}
			if ((object)type == typeof(Guid))
			{
				value = Adjust((Guid)value);
				break;
			}
			if ((object)type == typeof(object))
			{
				throw new ArgumentException(Res.GetString("ADP_InvalidDataType", TypeCode.UInt64));
			}
			if ((object)type == typeof(SqlBinary))
			{
				value = Adjust((SqlBinary)value);
				break;
			}
			if ((object)type == typeof(SqlBoolean))
			{
				value = Adjust((SqlBoolean)value);
				break;
			}
			if ((object)type == typeof(SqlByte))
			{
				value = Adjust((SqlByte)value);
				break;
			}
			if ((object)type == typeof(SqlDateTime))
			{
				value = Adjust((SqlDateTime)value);
				break;
			}
			if ((object)type == typeof(SqlDouble))
			{
				value = Adjust((SqlDouble)value);
				break;
			}
			if ((object)type == typeof(SqlGuid))
			{
				value = Adjust((SqlGuid)value);
				break;
			}
			if ((object)type == typeof(SqlInt16))
			{
				value = Adjust((SqlInt16)value);
				break;
			}
			if ((object)type == typeof(SqlInt32))
			{
				value = Adjust((SqlInt32)value);
				break;
			}
			if ((object)type == typeof(SqlInt64))
			{
				value = Adjust((SqlInt64)value);
				break;
			}
			if ((object)type == typeof(SqlMoney))
			{
				value = Adjust((SqlMoney)value);
				break;
			}
			if ((object)type == typeof(SqlDecimal))
			{
				value = Adjust((SqlDecimal)value);
				break;
			}
			if ((object)type == typeof(SqlSingle))
			{
				value = Adjust((SqlSingle)value);
				break;
			}
			if ((object)type == typeof(SqlString))
			{
				value = Adjust((SqlString)value);
				break;
			}
			if ((object)type == typeof(SqlChars))
			{
				value = Adjust((SqlChars)value);
				break;
			}
			if ((object)type == typeof(SqlBytes))
			{
				value = Adjust((SqlBytes)value);
				break;
			}
			throw new Exception(Res.GetString("ADP_InvalidDataType", type));
		default:
			throw new Exception(Res.GetString("ADP_InvalidDataType", type));
		case TypeCode.DBNull:
			break;
		}
		return value;
	}

	public bool Adjust(bool value)
	{
		if (SqlDbType.Bit != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public byte Adjust(byte value)
	{
		if (SqlDbType.TinyInt != SqlDbType)
		{
			ThrowInvalidType();
		}
		return value;
	}

	public byte[] Adjust(byte[] value)
	{
		if (SqlDbType.Binary == SqlDbType || SqlDbType.Timestamp == SqlDbType)
		{
			if (value != null && value.Length < MaxLength)
			{
				byte[] array = new byte[MaxLength];
				Array.Copy(value, array, value.Length);
				Array.Clear(array, value.Length, array.Length - value.Length);
				return array;
			}
		}
		else if (SqlDbType.VarBinary != SqlDbType && SqlDbType.Image != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value == null)
		{
			return null;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			byte[] array2 = new byte[MaxLength];
			Array.Copy(value, array2, (int)MaxLength);
			value = array2;
		}
		return value;
	}

	public char Adjust(char value)
	{
		if (SqlDbType.Char == SqlDbType || SqlDbType.NChar == SqlDbType)
		{
			if (1 != MaxLength)
			{
				ThrowInvalidType();
			}
		}
		else if (1 > MaxLength || (SqlDbType.VarChar != SqlDbType && SqlDbType.NVarChar != SqlDbType && SqlDbType.Text != SqlDbType && SqlDbType.NText != SqlDbType))
		{
			ThrowInvalidType();
		}
		return value;
	}

	public char[] Adjust(char[] value)
	{
		if (SqlDbType.Char == SqlDbType || SqlDbType.NChar == SqlDbType)
		{
			if (value != null)
			{
				long num = value.Length;
				if (num < MaxLength)
				{
					char[] array = new char[(int)MaxLength];
					Array.Copy(value, array, (int)num);
					for (long num2 = num; num2 < array.Length; num2++)
					{
						array[num2] = ' ';
					}
					return array;
				}
			}
		}
		else if (SqlDbType.VarChar != SqlDbType && SqlDbType.NVarChar != SqlDbType && SqlDbType.Text != SqlDbType && SqlDbType.NText != SqlDbType)
		{
			ThrowInvalidType();
		}
		if (value == null)
		{
			return null;
		}
		if (value.Length > MaxLength && Max != MaxLength)
		{
			char[] array2 = new char[MaxLength];
			Array.Copy(value, array2, (int)MaxLength);
			value = array2;
		}
		return value;
	}

	private static void ThrowInvalidType()
	{
		string message = string.Format(CultureInfo.InvariantCulture, "invalid type", new object[0]);
		throw new ArgumentException(message);
	}

	private void VerifyDateTimeRange(DateTime value)
	{
		if (SqlDbType.SmallDateTime == SqlDbType && (x_dtSmallMax < value || x_dtSmallMin > value))
		{
			ThrowInvalidType();
		}
	}

	private void VerifyMoneyRange(SqlMoney value)
	{
		if (SqlDbType.SmallMoney == SqlDbType && ((x_smSmallMax < value).Value || (x_smSmallMin > value).Value))
		{
			ThrowInvalidType();
		}
	}

	private SqlDecimal InternalAdjustSqlDecimal(SqlDecimal value)
	{
		if (!value.IsNull && (value.Precision != Precision || value.Scale != Scale))
		{
			return SqlDecimal.ConvertToPrecScale(value, Precision, Scale);
		}
		return value;
	}

	private void SetDefaultsForType(SqlDbType dbType)
	{
		if (SqlDbType.BigInt <= dbType && SqlDbType.Udt >= dbType)
		{
			SqlMetaData sqlMetaData = sxm_rgDefaults[(int)dbType];
			m_sqlDbType = dbType;
			m_lMaxLength = sqlMetaData.MaxLength;
			m_bPrecision = sqlMetaData.Precision;
			m_bScale = sqlMetaData.Scale;
			m_lLocale = sqlMetaData.LocaleId;
			m_eCompareOptions = sqlMetaData.CompareOptions;
		}
	}
}
