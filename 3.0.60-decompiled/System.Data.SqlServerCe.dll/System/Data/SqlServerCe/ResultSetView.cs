using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace System.Data.SqlServerCe;

public sealed class ResultSetView : ITypedList, IBindingList, IList, ICollection, IEnumerable, IDisposable
{
	private SqlCeResultSet parent;

	private ArrayList rowViewList;

	private PropertyDescriptorCollection propDescCollection;

	private int[] ordinals;

	private ListChangedEventHandler onListChanged;

	private ResultSetChangedEventHandler onResultSetChanged;

	internal SqlCeResultSet SqlCeResultSet => parent;

	public string[] Columns
	{
		get
		{
			if (ordinals != null)
			{
				string[] array = new string[ordinals.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = parent.GetName(ordinals[i]);
				}
				return array;
			}
			string[] array2 = new string[parent.FieldCount];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = parent.GetName(j);
			}
			return array2;
		}
		set
		{
			try
			{
				if (value == null)
				{
					throw new ArgumentNullException("Columns");
				}
				ordinals = new int[value.Length];
				for (int i = 0; i < value.Length; i++)
				{
					ordinals[i] = parent.GetOrdinal(value[i]);
				}
				FillPropertyDescriptorArray();
			}
			catch (Exception ex)
			{
				ordinals = null;
				throw ex;
			}
		}
	}

	public int[] Ordinals
	{
		get
		{
			if (ordinals == null)
			{
				int fieldCount = parent.FieldCount;
				ordinals = new int[fieldCount];
				for (int i = 0; i < fieldCount; i++)
				{
					ordinals[i] = i;
				}
			}
			return (int[])ordinals.Clone();
		}
		set
		{
			try
			{
				if (value == null)
				{
					throw new ArgumentNullException("Ordinals");
				}
				for (int i = 0; i < value.Length; i++)
				{
					if (value[i] < 0 || value[i] >= parent.FieldCount)
					{
						throw new IndexOutOfRangeException();
					}
				}
				ordinals = value;
				FillPropertyDescriptorArray();
			}
			catch (Exception ex)
			{
				ordinals = null;
				throw ex;
			}
		}
	}

	bool IList.IsFixedSize => !parent.Updatable;

	bool IList.IsReadOnly => !parent.Updatable;

	object IList.this[int index]
	{
		get
		{
			return rowViewList[index];
		}
		set
		{
			string message = string.Format(CultureInfo.InvariantCulture, "IList.set_Item", new object[0]);
			throw new NotSupportedException(message);
		}
	}

	int ICollection.Count => rowViewList.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	bool IBindingList.AllowEdit => parent.Updatable;

	bool IBindingList.AllowNew => parent.Updatable;

	bool IBindingList.AllowRemove => parent.Updatable;

	bool IBindingList.SupportsChangeNotification => true;

	bool IBindingList.SupportsSearching => false;

	bool IBindingList.SupportsSorting => false;

	bool IBindingList.IsSorted
	{
		get
		{
			string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.IsSorted", new object[0]);
			throw new NotSupportedException(message);
		}
	}

	ListSortDirection IBindingList.SortDirection
	{
		get
		{
			string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.SortDirection", new object[0]);
			throw new NotSupportedException(message);
		}
	}

	PropertyDescriptor IBindingList.SortProperty
	{
		get
		{
			string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.SortProperty", new object[0]);
			throw new NotSupportedException(message);
		}
	}

	public event ListChangedEventHandler ListChanged
	{
		add
		{
			onListChanged = (ListChangedEventHandler)Delegate.Combine(onListChanged, value);
		}
		remove
		{
			onListChanged = (ListChangedEventHandler)Delegate.Remove(onListChanged, value);
		}
	}

	internal ResultSetView(SqlCeResultSet resultSet)
	{
		parent = resultSet;
		ArrayList bookmarkArray = parent.BookmarkArray;
		rowViewList = new ArrayList(bookmarkArray.Count);
		for (int i = 0; i < bookmarkArray.Count; i++)
		{
			rowViewList.Add(new RowView(this, (int)bookmarkArray[i]));
		}
		onResultSetChanged = OnResultSetChanged;
		parent.ResultSetChanged += onResultSetChanged;
	}

	void IDisposable.Dispose()
	{
		if (parent != null)
		{
			parent.ResultSetChanged -= onResultSetChanged;
		}
		if (rowViewList != null)
		{
			rowViewList.Clear();
		}
		if (propDescCollection != null)
		{
			propDescCollection.Clear();
		}
		ordinals = null;
		parent = null;
	}

	private void OnListChanged(ListChangedEventArgs e)
	{
		if (onListChanged != null)
		{
			onListChanged(this, e);
		}
	}

	private void OnResultSetChanged(object sender, ResultSetChangedEventArgs e)
	{
		if (onListChanged == null)
		{
			return;
		}
		RowView rowView = new RowView(e.RowView);
		rowView.Parent = this;
		if (ChangeType.RowDeleted != e.ChangeType)
		{
			rowView.Refresh();
		}
		if (e.ChangeType == ChangeType.RowInserted)
		{
			int num = rowViewList.Add(rowView);
			if (-1 != num)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, num));
			}
		}
		else if (ChangeType.RowUpdated == e.ChangeType)
		{
			int num2 = ((IList)this).IndexOf((object?)rowView);
			if (-1 != num2)
			{
				rowViewList[num2] = rowView;
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, num2));
			}
		}
		else if (ChangeType.RowDeleted == e.ChangeType)
		{
			int num3 = ((IList)this).IndexOf((object?)rowView);
			if (-1 != num3)
			{
				rowViewList.RemoveAt(num3);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, num3));
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return rowViewList.GetEnumerator();
	}

	int IList.Add(object value)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IList.Add", new object[0]);
		throw new NotSupportedException(message);
	}

	void IList.Clear()
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IList.Clear", new object[0]);
		throw new NotSupportedException(message);
	}

	bool IList.Contains(object value)
	{
		if (value is RowView && ((RowView)value).Parent == this)
		{
			return rowViewList.Contains(value);
		}
		return false;
	}

	int IList.IndexOf(object value)
	{
		if (value is RowView && ((RowView)value).Parent == this)
		{
			return rowViewList.IndexOf(value);
		}
		return -1;
	}

	void IList.Insert(int index, object value)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IList.Insert", new object[0]);
		throw new NotSupportedException(message);
	}

	void IList.Remove(object value)
	{
		int num = ((IList)this).IndexOf(value);
		if (num >= 0)
		{
			((IList)this).RemoveAt(num);
		}
	}

	void IList.RemoveAt(int index)
	{
		if (!((IBindingList)this).AllowRemove)
		{
			throw new InvalidOperationException();
		}
		if (index < 0 || index >= rowViewList.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		RowView rowView = (RowView)rowViewList[index];
		if (rowView.IsNew)
		{
			rowViewList.RemoveAt(index);
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
			return;
		}
		try
		{
			if (parent.GotoRow(rowView.Bookmark))
			{
				parent.Delete();
				parent.RemoveBookmarkFromCache(rowView.Bookmark);
			}
		}
		catch (SqlCeException ex)
		{
			if (-2147217906 == ex.HResult || -2147217885 == ex.HResult)
			{
				parent.RemoveBookmarkFromCache(rowView.Bookmark);
			}
			else
			{
				rowView.Error = ex.Message;
			}
		}
	}

	void ICollection.CopyTo(Array array, int index)
	{
		for (int i = 0; i < ((ICollection)this).Count; i++)
		{
			array.SetValue(((IList)this)[i], index++);
		}
	}

	string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
	{
		if (listAccessors != null)
		{
			string message = string.Format(CultureInfo.InvariantCulture, "listAccessors", new object[0]);
			throw new ArgumentException(message);
		}
		return string.Empty;
	}

	private void FillPropertyDescriptorArray()
	{
		int num = parent.FieldCount;
		bool flag;
		if (ordinals != null)
		{
			num = ordinals.Length;
			flag = true;
		}
		else
		{
			ordinals = new int[num];
			flag = false;
		}
		int num2 = 0;
		int num3 = 0;
		propDescCollection = null;
		PropertyDescriptor[] array = new PropertyDescriptor[num];
		for (int i = 0; i < num; i++)
		{
			num3 = (flag ? ordinals[i] : (ordinals[i] = i));
			bool isReadOnly = parent.metadata[num3].isReadOnly;
			array[num2++] = new DataColumnPropertyDescriptor(num3, parent, isReadOnly);
		}
		propDescCollection = new PropertyDescriptorCollection(array);
	}

	PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
	{
		if (listAccessors != null)
		{
			string message = string.Format(CultureInfo.InvariantCulture, "listAccessors", new object[0]);
			throw new ArgumentException(message);
		}
		if (propDescCollection == null)
		{
			FillPropertyDescriptorArray();
		}
		return propDescCollection;
	}

	object IBindingList.AddNew()
	{
		if (!((IBindingList)this).AllowNew)
		{
			throw new InvalidOperationException();
		}
		SqlCeUpdatableRecord record = parent.CreateRecord();
		RowView rowView = new RowView(this, -1, record);
		rowView.IsNew = true;
		int newIndex = rowViewList.Add(rowView);
		OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, newIndex));
		return rowView;
	}

	void IBindingList.AddIndex(PropertyDescriptor property)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.AddIndex", new object[0]);
		throw new NotSupportedException(message);
	}

	void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.ApplySort", new object[0]);
		throw new NotSupportedException(message);
	}

	int IBindingList.Find(PropertyDescriptor property, object key)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.Find", new object[0]);
		throw new NotSupportedException(message);
	}

	void IBindingList.RemoveIndex(PropertyDescriptor property)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.RemoveIndex", new object[0]);
		throw new NotSupportedException(message);
	}

	void IBindingList.RemoveSort()
	{
		string message = string.Format(CultureInfo.InvariantCulture, "IBindingList.RemoveSort", new object[0]);
		throw new NotSupportedException(message);
	}
}
