using System.Globalization;

namespace System.Data.SqlServerCe;

internal class ValueMapper
{
	private delegate object ValueMapperDelegate(SqlDbType paramType, object value);

	private static ValueMapperDelegate _typeMapperInternal = (((object)Type.GetType("System.DateTimeOffset") == null) ? new ValueMapperDelegate(GetMappedValueNET20RTM) : new ValueMapperDelegate(GetMappedValueNET20SP1));

	public static object GetMappedValue(SqlDbType paramType, object value)
	{
		return _typeMapperInternal(paramType, value);
	}

	private static object GetMappedValueNET20RTM(SqlDbType paramType, object value)
	{
		if (value == null)
		{
			return null;
		}
		if (value is DateTime)
		{
			return DateTimeMapper(paramType, value);
		}
		if (value is TimeSpan)
		{
			return TimeSpanMapper(paramType, value);
		}
		return value;
	}

	private static object GetMappedValueNET20SP1(SqlDbType paramType, object value)
	{
		if (value == null)
		{
			return null;
		}
		if (value is DateTime)
		{
			return DateTimeMapper(paramType, value);
		}
		if (value is DateTimeOffset)
		{
			return DateTimeOffsetMapper(paramType, value);
		}
		if (value is TimeSpan)
		{
			return TimeSpanMapper(paramType, value);
		}
		return value;
	}

	private static object DateTimeMapper(SqlDbType paramType, object value)
	{
		if (paramType == SqlDbType.NChar || paramType == SqlDbType.NVarChar)
		{
			return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
		}
		return value;
	}

	private static object TimeSpanMapper(SqlDbType paramType, object value)
	{
		if (paramType == SqlDbType.NChar || paramType == SqlDbType.NVarChar)
		{
			TimeSpan value2 = (TimeSpan)value;
			DateTime minValue = DateTime.MinValue;
			return minValue.Add(value2).ToString("HH:mm:ss.fffffff");
		}
		return value;
	}

	private static object DateTimeOffsetMapper(SqlDbType paramType, object value)
	{
		if (paramType == SqlDbType.NChar || paramType == SqlDbType.NVarChar)
		{
			return ((DateTimeOffset)value).ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz", CultureInfo.InvariantCulture);
		}
		return value;
	}
}
