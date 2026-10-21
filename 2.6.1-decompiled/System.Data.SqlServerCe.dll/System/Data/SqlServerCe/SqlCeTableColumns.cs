using System.Collections;
using System.Collections.Generic;

namespace System.Data.SqlServerCe;

internal class SqlCeTableColumns : IEnumerable
{
	public string TableName;

	private readonly Dictionary<string, SqlCeInfoSchemaColumn> columns;

	private readonly Dictionary<string, SqlCeInfoSchemaColumn> parameters;

	private readonly StringComparer _comparer = StringComparer.OrdinalIgnoreCase;

	public int Count
	{
		get
		{
			if (columns != null)
			{
				return columns.Count;
			}
			return 0;
		}
	}

	private SqlCeTableColumns()
	{
	}

	public SqlCeTableColumns(string tableName)
	{
		TableName = tableName;
		columns = new Dictionary<string, SqlCeInfoSchemaColumn>(_comparer);
		parameters = new Dictionary<string, SqlCeInfoSchemaColumn>(_comparer);
	}

	public void Add(SqlCeInfoSchemaColumn column)
	{
		columns.Add(column.ColumnName, column);
		parameters.Add(column.ParamName, column);
	}

	public void Clear(string newTableName)
	{
		columns.Clear();
		parameters.Clear();
		TableName = newTableName;
	}

	public SqlCeInfoSchemaColumn GetValueByParameterName(string paramName)
	{
		SqlCeInfoSchemaColumn value = null;
		if (!parameters.TryGetValue(paramName, out value))
		{
			throw new InvalidOperationException("SqlCeTableColumns.GetValueByParameterName");
		}
		return value;
	}

	public SqlCeInfoSchemaColumn GetValueByColumnName(string columnName)
	{
		SqlCeInfoSchemaColumn value = null;
		if (!columns.TryGetValue(columnName, out value))
		{
			throw new InvalidOperationException("SqlCeTableColumns.GetValueByColumnName");
		}
		return value;
	}

	public string ParameterNameOf(string columnName)
	{
		SqlCeInfoSchemaColumn value = null;
		columns.TryGetValue(columnName, out value);
		return value?.ParamName;
	}

	public IEnumerator GetEnumerator()
	{
		return new KeyValuePairsEnumerator<string, SqlCeInfoSchemaColumn>(columns.GetEnumerator());
	}
}
