namespace System.Data.SqlServerCe;

internal class ResultSetChangedEventArgs : EventArgs
{
	private RowView rowView;

	private ChangeType changeType;

	internal RowView RowView => rowView;

	internal ChangeType ChangeType => changeType;

	public ResultSetChangedEventArgs(ChangeType type, RowView view)
	{
		rowView = view;
		changeType = type;
	}
}
