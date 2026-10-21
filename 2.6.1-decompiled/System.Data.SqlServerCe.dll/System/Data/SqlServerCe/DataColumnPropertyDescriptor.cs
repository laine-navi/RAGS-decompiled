using System.ComponentModel;

namespace System.Data.SqlServerCe;

internal class DataColumnPropertyDescriptor : PropertyDescriptor
{
	private int ordinal;

	private bool isReadOnly;

	private SqlCeResultSet parent;

	public override Type ComponentType => typeof(RowView);

	public override bool IsReadOnly => isReadOnly;

	public override Type PropertyType
	{
		get
		{
			SqlCeType sqlCeType = SqlCeType.FromSqlDbType(parent.GetSqlMetaData(ordinal).SqlDbType);
			return sqlCeType.clrType;
		}
	}

	internal DataColumnPropertyDescriptor(int ordinal, SqlCeResultSet resultSet, bool isReadOnly)
		: base(resultSet.GetSqlMetaData(ordinal).Name, null)
	{
		this.isReadOnly = isReadOnly;
		this.ordinal = ordinal;
		parent = resultSet;
	}

	public override bool Equals(object other)
	{
		if (other is DataColumnPropertyDescriptor)
		{
			DataColumnPropertyDescriptor dataColumnPropertyDescriptor = (DataColumnPropertyDescriptor)other;
			return dataColumnPropertyDescriptor.parent == parent;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return parent.GetHashCode();
	}

	public override bool CanResetValue(object component)
	{
		return isReadOnly;
	}

	public override object GetValue(object component)
	{
		RowView rowView = (RowView)component;
		SqlCeUpdatableRecord updatableRecord = rowView.UpdatableRecord;
		if (updatableRecord == null)
		{
			return DBNull.Value;
		}
		if (updatableRecord.IsDBNull(ordinal))
		{
			return DBNull.Value;
		}
		return updatableRecord.GetValue(ordinal);
	}

	public override void ResetValue(object component)
	{
		RowView rowView = (RowView)component;
		SqlCeUpdatableRecord updatableRecord = rowView.UpdatableRecord;
		updatableRecord.SetValue(ordinal, DBNull.Value);
		OnValueChanged(component, EventArgs.Empty);
	}

	public override void SetValue(object component, object value)
	{
		RowView rowView = (RowView)component;
		SqlCeUpdatableRecord updatableRecord = rowView.UpdatableRecord;
		updatableRecord.SetValue(ordinal, value);
		OnValueChanged(component, EventArgs.Empty);
	}

	public override bool ShouldSerializeValue(object component)
	{
		return false;
	}
}
