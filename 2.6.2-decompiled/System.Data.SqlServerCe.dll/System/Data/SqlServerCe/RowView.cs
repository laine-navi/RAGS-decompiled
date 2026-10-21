using System.Collections;
using System.ComponentModel;

namespace System.Data.SqlServerCe;

public sealed class RowView : IEditableObject, IDataErrorInfo, IDisposable
{
	private int hBookmark = -1;

	private ResultSetView parent;

	private WeakReference weakRefRecord;

	private SqlCeUpdatableRecord record;

	private string error;

	private bool isBeingEdited;

	private bool isNewRow;

	private bool isDeleted;

	internal bool IsNew
	{
		get
		{
			return isNewRow;
		}
		set
		{
			isNewRow = value;
		}
	}

	internal ResultSetView Parent
	{
		get
		{
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	internal int Bookmark => hBookmark;

	public SqlCeUpdatableRecord UpdatableRecord
	{
		get
		{
			if (record != null)
			{
				return record;
			}
			if (ADP.IsAlive(weakRefRecord))
			{
				return (SqlCeUpdatableRecord)weakRefRecord.Target;
			}
			if (isDeleted)
			{
				return null;
			}
			record = null;
			try
			{
				SqlCeResultSet sqlCeResultSet = parent.SqlCeResultSet;
				if (!sqlCeResultSet.GotoRow(hBookmark))
				{
					error = Res.GetString("SQLCE_DeletedRow");
					isDeleted = true;
					return null;
				}
				SqlCeUpdatableRecord currentRecord = sqlCeResultSet.GetCurrentRecord();
				weakRefRecord = new WeakReference(currentRecord);
				return currentRecord;
			}
			catch (SqlCeException ex)
			{
				if (-2147217906 == ex.HResult || -2147217885 == ex.HResult)
				{
					error = Res.GetString("SQLCE_DeletedRow");
					isDeleted = true;
					return null;
				}
				error = ex.Message;
				throw ex;
			}
			catch (Exception ex2)
			{
				if (!ADP.IsCatchableExceptionType(ex2))
				{
					throw ex2;
				}
				error = ex2.Message;
				throw ex2;
			}
		}
	}

	string IDataErrorInfo.this[string colName] => string.Empty;

	string IDataErrorInfo.Error => error;

	internal string Error
	{
		set
		{
			error = value;
		}
	}

	internal RowView(RowView value)
	{
		hBookmark = value.hBookmark;
		parent = value.parent;
		weakRefRecord = value.weakRefRecord;
		error = value.error;
		isBeingEdited = value.isBeingEdited;
		isNewRow = value.isNewRow;
		isDeleted = value.isDeleted;
	}

	internal RowView(int hBookmark)
	{
		this.hBookmark = hBookmark;
		isNewRow = false;
	}

	internal RowView(ResultSetView parent, int hBookmark)
		: this(hBookmark)
	{
		this.parent = parent;
	}

	internal RowView(ResultSetView parent, int hBookmark, SqlCeUpdatableRecord record)
		: this(parent, hBookmark)
	{
		if (-1 == hBookmark)
		{
			isNewRow = true;
			this.record = record;
		}
		weakRefRecord = new WeakReference(record);
	}

	public override int GetHashCode()
	{
		return hBookmark;
	}

	public override bool Equals(object other)
	{
		if (!(other is RowView))
		{
			return false;
		}
		if (((RowView)other).Bookmark == hBookmark)
		{
			return true;
		}
		return false;
	}

	void IDisposable.Dispose()
	{
		hBookmark = -1;
		parent = null;
		record = null;
		weakRefRecord = null;
	}

	void IEditableObject.BeginEdit()
	{
		if (isBeingEdited || isDeleted)
		{
			return;
		}
		try
		{
			isBeingEdited = true;
			if (isNewRow)
			{
				for (int i = 0; i < record.FieldCount; i++)
				{
					record.SetValue(i, DBNull.Value);
					record.ColumnsUpdatedStatus[i] = ColumnUpdatedStatus.None;
				}
				return;
			}
			SqlCeResultSet sqlCeResultSet = parent.SqlCeResultSet;
			if (!sqlCeResultSet.GotoRow(hBookmark))
			{
				error = Res.GetString("SQLCE_DeletedRow");
				isDeleted = true;
			}
			else
			{
				record = sqlCeResultSet.GetCurrentRecord();
				weakRefRecord = new WeakReference(record);
			}
		}
		catch (SqlCeException ex)
		{
			isBeingEdited = false;
			if (-2147217906 == ex.HResult || -2147217885 == ex.HResult)
			{
				error = Res.GetString("SQLCE_DeletedRow");
				isDeleted = true;
			}
			else
			{
				error = ex.Message;
			}
		}
		catch (Exception ex2)
		{
			if (!ADP.IsCatchableExceptionType(ex2))
			{
				throw ex2;
			}
			isBeingEdited = false;
			error = ex2.Message;
		}
	}

	void IEditableObject.CancelEdit()
	{
		if (isNewRow)
		{
			((IList)parent).Remove((object?)this);
			record = null;
			weakRefRecord = null;
		}
		else if (!isDeleted)
		{
			Refresh();
		}
	}

	void IEditableObject.EndEdit()
	{
		if (isDeleted)
		{
			return;
		}
		SqlCeResultSet sqlCeResultSet = parent.SqlCeResultSet;
		error = null;
		if (!isBeingEdited)
		{
			return;
		}
		bool flag = false;
		try
		{
			if (isNewRow)
			{
				int num = sqlCeResultSet.InternalInsert(fMoveTo: false, parent, record);
				((IList)parent).Remove((object?)this);
				isNewRow = false;
				hBookmark = num;
				for (int i = 0; i < record.FieldCount; i++)
				{
					record.ColumnsUpdatedStatus[i] = ColumnUpdatedStatus.None;
				}
				record = null;
				return;
			}
			bool flag2 = false;
			for (int j = 0; j < record.FieldCount; j++)
			{
				if (record.ColumnsUpdatedStatus[j] != ColumnUpdatedStatus.None)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				record = null;
				return;
			}
			if (!sqlCeResultSet.GotoRow(hBookmark))
			{
				error = Res.GetString("SQLCE_DeletedRow");
				isDeleted = true;
				return;
			}
			for (int k = 0; k < record.FieldCount; k++)
			{
				if (record.ColumnsUpdatedStatus[k] != ColumnUpdatedStatus.None)
				{
					sqlCeResultSet.SetValue(k, record.GetValue(k));
				}
			}
			sqlCeResultSet.InternalUpdate(parent);
			for (int l = 0; l < record.FieldCount; l++)
			{
				record.ColumnsUpdatedStatus[l] = ColumnUpdatedStatus.None;
			}
			record = null;
		}
		catch (SqlCeException ex)
		{
			flag = true;
			if (-2147217906 == ex.HResult || -2147217885 == ex.HResult)
			{
				error = Res.GetString("SQLCE_DeletedRow");
				isDeleted = true;
				return;
			}
			throw ex;
		}
		finally
		{
			if (!flag)
			{
				isBeingEdited = false;
			}
		}
	}

	internal void Refresh()
	{
		SqlCeUpdatableRecord sqlCeUpdatableRecord = record;
		WeakReference weakReference = weakRefRecord;
		record = null;
		weakRefRecord = null;
		record = UpdatableRecord;
		if (isDeleted)
		{
			record = sqlCeUpdatableRecord;
			weakRefRecord = weakReference;
		}
	}
}
