using System.Data.Common;

namespace System.Data.SqlServerCe;

public sealed class SqlCeDataAdapter : DbDataAdapter, ICloneable
{
	public new SqlCeCommand DeleteCommand
	{
		get
		{
			return base.DeleteCommand as SqlCeCommand;
		}
		set
		{
			base.DeleteCommand = value;
		}
	}

	public new SqlCeCommand InsertCommand
	{
		get
		{
			return base.InsertCommand as SqlCeCommand;
		}
		set
		{
			base.InsertCommand = value;
		}
	}

	public new SqlCeCommand SelectCommand
	{
		get
		{
			return base.SelectCommand as SqlCeCommand;
		}
		set
		{
			base.SelectCommand = value;
		}
	}

	public new SqlCeCommand UpdateCommand
	{
		get
		{
			return base.UpdateCommand as SqlCeCommand;
		}
		set
		{
			base.UpdateCommand = value;
		}
	}

	public event SqlCeRowUpdatedEventHandler RowUpdated
	{
		add
		{
			Events.AddHandler(ADP.EventRowUpdated, value);
		}
		remove
		{
			Events.RemoveHandler(ADP.EventRowUpdated, value);
		}
	}

	public event SqlCeRowUpdatingEventHandler RowUpdating
	{
		add
		{
			Events.AddHandler(ADP.EventRowUpdating, value);
		}
		remove
		{
			Events.RemoveHandler(ADP.EventRowUpdating, value);
		}
	}

	public SqlCeDataAdapter()
	{
		GC.SuppressFinalize(this);
	}

	public SqlCeDataAdapter(SqlCeCommand selectCommand)
	{
		GC.SuppressFinalize(this);
		SelectCommand = selectCommand;
	}

	public SqlCeDataAdapter(string selectCommandText, string selectConnectionString)
	{
		GC.SuppressFinalize(this);
		SelectCommand = new SqlCeCommand(selectCommandText, new SqlCeConnection(selectConnectionString));
	}

	public SqlCeDataAdapter(string selectCommandText, SqlCeConnection selectConnection)
	{
		GC.SuppressFinalize(this);
		SelectCommand = new SqlCeCommand(selectCommandText, selectConnection);
	}

	private SqlCeDataAdapter(SqlCeDataAdapter from)
		: base(from)
	{
		GC.SuppressFinalize(this);
	}

	object ICloneable.Clone()
	{
		return new SqlCeDataAdapter(this);
	}

	protected override RowUpdatedEventArgs CreateRowUpdatedEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
	{
		return new SqlCeRowUpdatedEventArgs(dataRow, command, statementType, tableMapping);
	}

	protected override RowUpdatingEventArgs CreateRowUpdatingEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
	{
		return new SqlCeRowUpdatingEventArgs(dataRow, command, statementType, tableMapping);
	}

	protected override void OnRowUpdated(RowUpdatedEventArgs value)
	{
		SqlCeRowUpdatedEventHandler sqlCeRowUpdatedEventHandler = (SqlCeRowUpdatedEventHandler)Events[ADP.EventRowUpdated];
		if (sqlCeRowUpdatedEventHandler != null && value is SqlCeRowUpdatedEventArgs)
		{
			sqlCeRowUpdatedEventHandler(this, (SqlCeRowUpdatedEventArgs)value);
		}
	}

	protected override void OnRowUpdating(RowUpdatingEventArgs value)
	{
		SqlCeRowUpdatingEventHandler sqlCeRowUpdatingEventHandler = (SqlCeRowUpdatingEventHandler)Events[ADP.EventRowUpdating];
		if (sqlCeRowUpdatingEventHandler != null && value is SqlCeRowUpdatingEventArgs)
		{
			sqlCeRowUpdatingEventHandler(this, (SqlCeRowUpdatingEventArgs)value);
		}
	}
}
