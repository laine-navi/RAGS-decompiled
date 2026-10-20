using System.Data.Common;

namespace System.Data.SqlServerCe;

public sealed class SqlCeRowUpdatingEventArgs : RowUpdatingEventArgs
{
	public new SqlCeCommand Command
	{
		get
		{
			return (SqlCeCommand)base.Command;
		}
		set
		{
			base.Command = value;
		}
	}

	public SqlCeRowUpdatingEventArgs(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		: base(dataRow, command, statementType, tableMapping)
	{
	}
}
