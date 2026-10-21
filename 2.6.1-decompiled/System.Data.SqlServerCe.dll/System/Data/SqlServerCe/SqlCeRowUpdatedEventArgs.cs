using System.Data.Common;

namespace System.Data.SqlServerCe;

public sealed class SqlCeRowUpdatedEventArgs : RowUpdatedEventArgs
{
	public new SqlCeCommand Command => (SqlCeCommand)base.Command;

	public SqlCeRowUpdatedEventArgs(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		: base(dataRow, command, statementType, tableMapping)
	{
	}
}
