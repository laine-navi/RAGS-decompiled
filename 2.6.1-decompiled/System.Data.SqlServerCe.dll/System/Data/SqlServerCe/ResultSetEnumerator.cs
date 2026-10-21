using System.Collections;

namespace System.Data.SqlServerCe;

public sealed class ResultSetEnumerator : IEnumerator
{
	internal SqlCeResultSet _resultset;

	internal SqlCeUpdatableRecord _current;

	object IEnumerator.Current => _current;

	public SqlCeUpdatableRecord Current => _current;

	public ResultSetEnumerator(SqlCeResultSet resultSet)
	{
		if (resultSet == null)
		{
			throw new ArgumentNullException("resultset");
		}
		_resultset = resultSet;
	}

	public bool MoveNext()
	{
		_current = null;
		if (_resultset.Read())
		{
			_current = _resultset.GetCurrentRecord();
			return true;
		}
		return false;
	}

	public void Reset()
	{
		_current = null;
		_resultset.ReadFirst();
		_resultset.ReadPrevious();
	}
}
