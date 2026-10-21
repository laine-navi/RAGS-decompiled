using System.Data.SqlTypes;

namespace System.Data.SqlServerCe;

internal class MetaData : IDisposable
{
	internal uint ordinal;

	internal uint size;

	internal object value;

	internal bool isReadOnly;

	internal bool isRowVersion;

	internal bool isExpression;

	internal bool isIdentity;

	internal bool isUnique;

	internal bool isKey;

	internal bool isNullable;

	internal bool hasDefault;

	internal string baseTableName;

	internal string baseColumnName;

	internal SqlCeType typeMap;

	private SqlMetaData sqlMetaData;

	public SqlMetaData SqlMetaData => sqlMetaData;

	public string ColumnName => sqlMetaData.Name;

	private MetaData()
	{
	}

	public MetaData(string name, SqlCeType typeMap, byte precision, byte scale, long maxLength, string databaseName, string schemaName)
	{
		this.typeMap = typeMap;
		SqlDbType sqlDbType = typeMap.sqlDbType;
		if (precision == 0)
		{
			precision = typeMap.maxpre;
		}
		if (0 == maxLength)
		{
			maxLength = typeMap.fixlen;
		}
		if (scale == 0)
		{
			scale = typeMap.scale;
		}
		if (sqlDbType == SqlDbType.NText || sqlDbType == SqlDbType.Image)
		{
			maxLength = -1L;
		}
		if (sqlDbType == SqlDbType.NVarChar && maxLength > 4000)
		{
			maxLength = 4000L;
		}
		else if (sqlDbType == SqlDbType.VarBinary && maxLength > 8000)
		{
			maxLength = 8000L;
		}
		sqlMetaData = new SqlMetaData(name, sqlDbType, maxLength, precision, scale, 0L, SqlCompareOptions.None, null);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~MetaData()
	{
		Dispose(disposing: false);
	}

	private void Dispose(bool disposing)
	{
		if (value != null && value is IntPtr && typeMap.isBLOB)
		{
			IntPtr ppUnknown = (IntPtr)value;
			if (IntPtr.Zero != ppUnknown)
			{
				NativeMethods.SafeRelease(ref ppUnknown);
				value = null;
			}
		}
		if (disposing)
		{
			value = null;
			sqlMetaData = null;
			baseTableName = null;
			baseColumnName = null;
			typeMap = null;
		}
	}
}
