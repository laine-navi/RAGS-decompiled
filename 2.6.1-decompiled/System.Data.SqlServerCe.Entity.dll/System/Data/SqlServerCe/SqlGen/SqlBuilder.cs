using System.Collections.Generic;

namespace System.Data.SqlServerCe.SqlGen;

internal sealed class SqlBuilder : ISqlFragment
{
	private List<object> _sqlFragments;

	private List<object> sqlFragments
	{
		get
		{
			if (_sqlFragments == null)
			{
				_sqlFragments = new List<object>();
			}
			return _sqlFragments;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (_sqlFragments != null)
			{
				return 0 == _sqlFragments.Count;
			}
			return true;
		}
	}

	public void Append(object s)
	{
		sqlFragments.Add(s);
	}

	public void AppendLine()
	{
		sqlFragments.Add("\r\n");
	}

	public void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator)
	{
		if (_sqlFragments == null)
		{
			return;
		}
		foreach (object sqlFragment2 in _sqlFragments)
		{
			if (sqlFragment2 is string value)
			{
				writer.Write(value);
				continue;
			}
			if (sqlFragment2 is ISqlFragment sqlFragment)
			{
				sqlFragment.WriteSql(writer, sqlGenerator);
				continue;
			}
			throw new InvalidOperationException();
		}
	}
}
