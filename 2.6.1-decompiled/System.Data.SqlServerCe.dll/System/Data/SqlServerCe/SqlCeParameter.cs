using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;

namespace System.Data.SqlServerCe;

public sealed class SqlCeParameter : DbParameter, ICloneable
{
	private byte precision;

	private byte scale;

	private int size;

	private bool designNullable;

	private bool userSpecifiedType;

	private bool userSpecifiedScale;

	private bool valueConverted;

	private bool inferType = true;

	private string parameterName;

	private string sourceColumn;

	private object value;

	private object convertedValue;

	private SqlCeParameterCollection parent;

	private SqlCeType typeMap;

	private DataRowVersion sourceVersion;

	public override DbType DbType
	{
		get
		{
			return typeMap.dbType;
		}
		set
		{
			if (!userSpecifiedType || typeMap.dbType != value)
			{
				BindingChange();
				NativeType = SqlCeType.FromDbType(value);
			}
			inferType = false;
		}
	}

	public override ParameterDirection Direction
	{
		get
		{
			return ParameterDirection.Input;
		}
		set
		{
			if (ParameterDirection.Input != value)
			{
				throw new InvalidOperationException(Res.GetString("ADP_InvalidParameterDirection", value, ParameterName));
			}
		}
	}

	public override bool IsNullable
	{
		get
		{
			return designNullable;
		}
		set
		{
			designNullable = value;
		}
	}

	public int Offset
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override bool SourceColumnNullMapping
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[DbProviderSpecificTypeProperty(true)]
	public SqlDbType SqlDbType
	{
		get
		{
			return typeMap.sqlDbType;
		}
		set
		{
			if (!userSpecifiedType || typeMap.sqlDbType != value)
			{
				BindingChange();
				NativeType = SqlCeType.FromSqlDbType(value);
			}
			inferType = false;
		}
	}

	internal SqlCeType NativeType
	{
		get
		{
			return typeMap;
		}
		set
		{
			typeMap = value;
			userSpecifiedType = true;
		}
	}

	internal bool IsUserSpecifiedType => userSpecifiedType;

	public override string ParameterName
	{
		get
		{
			if (parameterName == null)
			{
				return string.Empty;
			}
			return parameterName;
		}
		set
		{
			int num = 128;
			if (value != null && value.Length > num)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQL_InvalidParameterNameLength", value));
			}
			if (string.Compare(value, parameterName, ignoreCase: false, CultureInfo.InvariantCulture) != 0)
			{
				if (Parent != null)
				{
					value = Parent.OnParameterNameChange(this, value);
				}
				parameterName = value;
			}
		}
	}

	internal string InternalParameterName
	{
		get
		{
			if (parameterName != null)
			{
				if (!parameterName.StartsWith("@"))
				{
					return parameterName;
				}
				return parameterName.Substring(1);
			}
			return string.Empty;
		}
		set
		{
			parameterName = value;
		}
	}

	internal SqlCeParameterCollection Parent
	{
		get
		{
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	public new byte Precision
	{
		get
		{
			if (precision == 0 && SqlDbType == SqlDbType.Decimal)
			{
				object obj = Value;
				if (obj != null && obj != DBNull.Value && (!(obj is INullable) || !((INullable)obj).IsNull))
				{
					return ((obj is decimal) ? new SqlDecimal((decimal)obj) : ((!(obj is SqlDecimal)) ? ((SqlDecimal)((IConvertible)obj).ToDecimal(null)) : ((SqlDecimal)obj))).Precision;
				}
			}
			return precision;
		}
		set
		{
			if (value > SqlDecimal.MaxPrecision)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SQL_PrecisionValueOutOfRange", value));
			}
			if (precision != value)
			{
				BindingChange();
				precision = value;
			}
		}
	}

	public new byte Scale
	{
		get
		{
			byte b = scale;
			if (b == 0 && SqlDbType == SqlDbType.Decimal)
			{
				object obj = Value;
				if (obj != null && obj != DBNull.Value && (!(obj is INullable) || !((INullable)obj).IsNull))
				{
					b = ((obj is decimal) ? new SqlDecimal((decimal)obj) : ((!(obj is SqlDecimal)) ? ((SqlDecimal)((IConvertible)obj).ToDecimal(null)) : ((SqlDecimal)obj))).Scale;
				}
			}
			return b;
		}
		set
		{
			if (value > Precision)
			{
				throw new ArgumentOutOfRangeException(Res.GetString("SqlMisc_InvalidPrecScaleMessage", value));
			}
			if (scale != value)
			{
				BindingChange();
				scale = value;
			}
			userSpecifiedScale = true;
		}
	}

	public override int Size
	{
		get
		{
			return size;
		}
		set
		{
			if (size != value)
			{
				BindingChange();
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidSizeValue", value.ToString(CultureInfo.CurrentCulture)));
				}
				int val = int.MaxValue;
				switch (typeMap.sqlDbType)
				{
				case SqlDbType.SmallInt:
					val = SqlCeType._SmallInt.fixlen;
					break;
				case SqlDbType.Int:
					val = SqlCeType._Int.fixlen;
					break;
				case SqlDbType.Real:
					val = SqlCeType._Real.fixlen;
					break;
				case SqlDbType.Float:
					val = SqlCeType._Float.fixlen;
					break;
				case SqlDbType.Money:
					val = SqlCeType._Money.fixlen;
					break;
				case SqlDbType.Bit:
					val = SqlCeType._Bit.fixlen;
					break;
				case SqlDbType.TinyInt:
					val = SqlCeType._TinyInt.fixlen;
					break;
				case SqlDbType.BigInt:
					val = SqlCeType._BigInt.fixlen;
					break;
				case SqlDbType.UniqueIdentifier:
					val = SqlCeType._UniqueIdentifier.fixlen;
					break;
				case SqlDbType.Binary:
					val = SqlCeType.MAX_BINARY_COLUMN_SIZE;
					break;
				case SqlDbType.VarBinary:
					val = SqlCeType.MAX_BINARY_COLUMN_SIZE;
					break;
				case SqlDbType.Timestamp:
					val = SqlCeType._RowVersion.fixlen;
					break;
				case SqlDbType.Image:
					val = SqlCeType.MAX_IMAGE_COLUMN_SIZE;
					break;
				case SqlDbType.NText:
					val = SqlCeType.MAX_NTEXT_COLUMN_SIZE;
					break;
				case SqlDbType.NChar:
					val = SqlCeType.MAX_NCHAR_COLUMN_SIZE;
					break;
				case SqlDbType.NVarChar:
					val = SqlCeType.MAX_NCHAR_COLUMN_SIZE;
					break;
				case SqlDbType.Decimal:
					val = SqlCeType._Numeric.fixlen;
					break;
				case SqlDbType.DateTime:
					val = SqlCeType._DateTime.fixlen;
					break;
				}
				size = Math.Min(value, val);
			}
		}
	}

	public override string SourceColumn
	{
		get
		{
			if (sourceColumn == null)
			{
				return string.Empty;
			}
			return sourceColumn;
		}
		set
		{
			sourceColumn = value;
		}
	}

	public override DataRowVersion SourceVersion
	{
		get
		{
			return sourceVersion;
		}
		set
		{
			switch (value)
			{
			case DataRowVersion.Original:
			case DataRowVersion.Current:
			case DataRowVersion.Proposed:
			case DataRowVersion.Default:
				sourceVersion = value;
				break;
			default:
				throw new ArgumentOutOfRangeException(Res.GetString("ADP_InvalidDataRowVersion", ParameterName, value.ToString()));
			}
		}
	}

	public override object Value
	{
		get
		{
			return value;
		}
		set
		{
			if (inferType && value != null && !Convert.IsDBNull(value))
			{
				typeMap = SqlCeType.FromClrType(value);
			}
			valueConverted = false;
			convertedValue = null;
			this.value = value;
		}
	}

	public SqlCeParameter()
	{
		inferType = true;
		typeMap = SqlCeType.Default;
		sourceVersion = DataRowVersion.Current;
	}

	public SqlCeParameter(string name, object value)
		: this()
	{
		ParameterName = name;
		Value = value;
	}

	public SqlCeParameter(string name, SqlDbType dataType)
		: this()
	{
		ParameterName = name;
		SqlDbType = dataType;
	}

	public SqlCeParameter(string name, SqlDbType dataType, int size)
		: this()
	{
		ParameterName = name;
		SqlDbType = dataType;
		Size = size;
	}

	public SqlCeParameter(string name, SqlDbType dataType, int size, string sourceColumn)
		: this()
	{
		ParameterName = name;
		SqlDbType = dataType;
		Size = size;
		SourceColumn = sourceColumn;
	}

	public SqlCeParameter(string parameterName, SqlDbType dbType, int size, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		: this(parameterName, dbType, size, ParameterDirection.Input, isNullable, precision, scale, sourceColumn, sourceVersion, value)
	{
	}

	public SqlCeParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
	{
		ParameterName = parameterName;
		SqlDbType = dbType;
		Size = size;
		Direction = direction;
		IsNullable = isNullable;
		Precision = precision;
		Scale = scale;
		SourceColumn = sourceColumn;
		SourceVersion = sourceVersion;
		Value = value;
	}

	public override void ResetDbType()
	{
		BindingChange();
		NativeType = SqlCeType.Default;
		inferType = false;
	}

	private void CopyTo(DbParameter destination)
	{
		if (destination == null)
		{
			throw new NullReferenceException("destination");
		}
		SqlCeParameter sqlCeParameter = (SqlCeParameter)destination;
		sqlCeParameter.precision = precision;
		sqlCeParameter.scale = scale;
		sqlCeParameter.size = size;
		sqlCeParameter.designNullable = designNullable;
		sqlCeParameter.userSpecifiedType = userSpecifiedType;
		sqlCeParameter.userSpecifiedScale = userSpecifiedScale;
		sqlCeParameter.valueConverted = valueConverted;
		sqlCeParameter.inferType = inferType;
		sqlCeParameter.ParameterName = ParameterName;
		sqlCeParameter.sourceColumn = sourceColumn;
		sqlCeParameter.convertedValue = convertedValue;
		sqlCeParameter.parent = null;
		sqlCeParameter.typeMap = typeMap;
		sqlCeParameter.sourceVersion = sourceVersion;
		if (value is ICloneable)
		{
			sqlCeParameter.value = ((ICloneable)value).Clone();
		}
		else
		{
			sqlCeParameter.value = value;
		}
	}

	object ICloneable.Clone()
	{
		SqlCeParameter sqlCeParameter = (SqlCeParameter)Activator.CreateInstance(GetType());
		CopyTo(sqlCeParameter);
		return sqlCeParameter;
	}

	private void BindingChange()
	{
		valueConverted = false;
		convertedValue = null;
		if (parent != null)
		{
			parent.OnDataBindingChange();
		}
	}

	internal int GetParameterLength()
	{
		if (-1 != typeMap.fixlen)
		{
			return typeMap.fixlen;
		}
		if (0 < Size)
		{
			return Size;
		}
		object parameterValue = GetParameterValue();
		if ((object)typeof(string) == typeMap.clrType)
		{
			if (parameterValue is string)
			{
				return ((string)parameterValue).Length;
			}
			if (parameterValue is SqlString sqlString)
			{
				return sqlString.Value.Length;
			}
		}
		else if ((object)typeof(byte[]) == typeMap.clrType)
		{
			if (parameterValue is byte[])
			{
				return ((byte[])parameterValue).Length;
			}
			if (parameterValue is SqlBinary sqlBinary)
			{
				return sqlBinary.Length;
			}
		}
		return 0;
	}

	internal object GetParameterValue()
	{
		if (!valueConverted)
		{
			convertedValue = value;
			if (userSpecifiedType && value != null)
			{
				ConvertValue();
			}
		}
		valueConverted = true;
		return convertedValue;
	}

	private void ConvertValue()
	{
		if (value is DBNull)
		{
			return;
		}
		Type type = value.GetType();
		if ((object)type != typeMap.clrType && !type.IsArray)
		{
			if ((object)typeMap.clrType == typeof(string))
			{
				if (value is IConvertible)
				{
					convertedValue = ((IConvertible)value).ToString(CultureInfo.CurrentCulture);
					return;
				}
				if (!(value is SqlString))
				{
					throw new InvalidCastException(ParameterName);
				}
				convertedValue = value.ToString();
			}
			else if (value is INullable && ((INullable)value).IsNull)
			{
				convertedValue = DBNull.Value;
			}
			else if ((object)typeMap.clrType == typeof(Guid))
			{
				if (value is SqlGuid)
				{
					convertedValue = (Guid)(SqlGuid)value;
				}
				else
				{
					convertedValue = new Guid((string)value);
				}
			}
		}
		else
		{
			convertedValue = value;
		}
	}

	public override string ToString()
	{
		return ParameterName;
	}
}
