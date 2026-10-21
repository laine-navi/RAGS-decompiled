using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;

namespace System.Data.SqlServerCe;

public sealed class SqlCeParameterCollection : DbParameterCollection
{
	private SqlCeCommand parent;

	private Dictionary<string, SqlCeParameter> m_KeyValuePairs;

	private List<SqlCeParameter> m_Values;

	private ADP.DstComparer m_KeyComparer;

	public override bool IsSynchronized => false;

	public override object SyncRoot => this;

	public override bool IsReadOnly => false;

	public override bool IsFixedSize => false;

	public override int Count
	{
		get
		{
			if (m_Values == null)
			{
				return 0;
			}
			return m_Values.Count;
		}
	}

	private Type ItemType => typeof(SqlCeParameter);

	public new SqlCeParameter this[int index]
	{
		get
		{
			RangeCheck(index);
			return m_Values[index];
		}
		set
		{
			OnDataBindingChange();
			RangeCheck(index);
			Replace(index, value);
		}
	}

	public new SqlCeParameter this[string parameterName]
	{
		get
		{
			SqlCeParameter param = null;
			RangeCheck(parameterName, out param);
			return param;
		}
		set
		{
			OnDataBindingChange();
			SqlCeParameter param = null;
			RangeCheck(parameterName, out param);
			Replace(IndexOf(param), value);
		}
	}

	internal SqlCeParameterCollection(SqlCeCommand parent)
	{
		this.parent = parent;
	}

	private Exception ThrowParamterExistsException()
	{
		throw new ArgumentException(Res.GetString("ADP_CollectionIsParent", ItemType.Name, GetType().Name));
	}

	private Exception ThrowParamterNotFoundException(string parameterName)
	{
		throw new IndexOutOfRangeException(Res.GetString("ADP_CollectionIndexString", ItemType.Name, "ParameterName", parameterName, GetType().Name));
	}

	private Exception ThrowParamterNotFoundException(int index)
	{
		throw new IndexOutOfRangeException(Res.GetString("ADP_CollectionIndexString", ItemType.Name, "ParameterIndex", index.ToString(CultureInfo.InvariantCulture), GetType().Name));
	}

	private void RangeCheck(int index)
	{
		if (index < 0 || Count <= index)
		{
			ThrowParamterNotFoundException(index);
		}
	}

	private void RangeCheck(string parameterName, out SqlCeParameter param)
	{
		if (string.IsNullOrEmpty(parameterName) || m_KeyValuePairs == null)
		{
			ThrowParamterNotFoundException(parameterName);
		}
		if (parameterName.StartsWith("@"))
		{
			parameterName = parameterName.Substring(1);
		}
		if (!m_KeyValuePairs.TryGetValue(parameterName, out param))
		{
			ThrowParamterNotFoundException(parameterName);
		}
	}

	private int RangeCheckIndex(string parameterName)
	{
		int num = IndexOf(parameterName);
		if (-1 == num)
		{
			ThrowParamterNotFoundException(parameterName);
		}
		return num;
	}

	protected override DbParameter GetParameter(string parameterName)
	{
		return this[parameterName];
	}

	protected override DbParameter GetParameter(int index)
	{
		return this[index];
	}

	protected override void SetParameter(int index, DbParameter value)
	{
		this[index] = (SqlCeParameter)value;
	}

	protected override void SetParameter(string parameterName, DbParameter value)
	{
		this[parameterName] = (SqlCeParameter)value;
	}

	private void Replace(int index, SqlCeParameter newValue)
	{
		Validate(index, newValue);
		SqlCeParameter sqlCeParameter = m_Values[index];
		m_KeyValuePairs.Remove(sqlCeParameter.InternalParameterName);
		m_KeyValuePairs.Add(newValue.InternalParameterName, newValue);
		sqlCeParameter.Parent = null;
		newValue.Parent = this;
		m_Values[index] = newValue;
	}

	internal string OnParameterNameChange(SqlCeParameter param, string newName)
	{
		if (Contains(newName))
		{
			ThrowParamterExistsException();
		}
		int num = IndexOf(param.InternalParameterName);
		if (num >= 0)
		{
			m_KeyValuePairs.Remove(param.InternalParameterName);
			param.InternalParameterName = newName;
			m_KeyValuePairs.Add(param.InternalParameterName, param);
		}
		return newName;
	}

	private List<SqlCeParameter> InitCollections()
	{
		if (m_KeyComparer == null)
		{
			m_KeyComparer = new ADP.DstComparer();
		}
		if (m_Values == null)
		{
			m_Values = new List<SqlCeParameter>();
		}
		if (m_KeyValuePairs == null)
		{
			m_KeyValuePairs = new Dictionary<string, SqlCeParameter>(m_KeyComparer);
		}
		return m_Values;
	}

	internal void AddWithoutEvents(int index, SqlCeParameter value)
	{
		InitCollections();
		Validate(-1, value);
		if (Contains(value.InternalParameterName))
		{
			ThrowParamterExistsException();
		}
		m_KeyValuePairs.Add(value.InternalParameterName, value);
		if (-1 == index)
		{
			m_Values.Add(value);
		}
		else
		{
			m_Values.Insert(index, value);
		}
		value.Parent = this;
	}

	public override void AddRange(Array values)
	{
		OnDataBindingChange();
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		foreach (object value2 in values)
		{
			ValidateType(value2);
		}
		foreach (SqlCeParameter value3 in values)
		{
			Add(value3);
		}
	}

	public override int Add(object value)
	{
		ValidateType(value);
		Add((SqlCeParameter)value);
		return Count - 1;
	}

	public SqlCeParameter Add(SqlCeParameter value)
	{
		OnDataBindingChange();
		AddWithoutEvents(-1, value);
		return value;
	}

	public SqlCeParameter AddWithValue(string parameterName, object value)
	{
		return Add(new SqlCeParameter(parameterName, value));
	}

	public SqlCeParameter Add(string parameterName, object value)
	{
		return Add(new SqlCeParameter(parameterName, value));
	}

	public SqlCeParameter Add(string parameterName, SqlDbType type)
	{
		return Add(new SqlCeParameter(parameterName, type));
	}

	public SqlCeParameter Add(string parameterName, SqlDbType type, int size)
	{
		return Add(new SqlCeParameter(parameterName, type, size));
	}

	public SqlCeParameter Add(string parameterName, SqlDbType type, int size, string sourceColumn)
	{
		return Add(new SqlCeParameter(parameterName, type, size, sourceColumn));
	}

	public override bool Contains(string value)
	{
		if (string.IsNullOrEmpty(value) || m_KeyValuePairs == null)
		{
			return false;
		}
		return m_KeyValuePairs.ContainsKey(value.StartsWith("@") ? value.Substring(1) : value);
	}

	public override bool Contains(object value)
	{
		if (m_KeyValuePairs == null)
		{
			return false;
		}
		ValidateType(value);
		return m_KeyValuePairs.ContainsValue((SqlCeParameter)value);
	}

	public override void Clear()
	{
		if (0 < Count)
		{
			OnDataBindingChange();
			ClearWithoutEvents();
		}
	}

	internal void ClearWithoutEvents()
	{
		if (m_Values != null)
		{
			int count = m_Values.Count;
			for (int i = 0; i < count; i++)
			{
				m_Values[i].Parent = null;
			}
			m_Values.Clear();
			m_KeyValuePairs.Clear();
		}
	}

	public override void CopyTo(Array array, int index)
	{
		((ICollection)InitCollections()).CopyTo(array, index);
	}

	public override IEnumerator GetEnumerator()
	{
		return InitCollections().GetEnumerator();
	}

	public override int IndexOf(string parameterName)
	{
		if (m_Values != null && parameterName != null)
		{
			if (parameterName.StartsWith("@"))
			{
				parameterName = parameterName.Substring(1);
			}
			int count = m_Values.Count;
			for (int i = 0; i < count; i++)
			{
				if (m_Values[i].InternalParameterName != null)
				{
					string internalParameterName = m_Values[i].InternalParameterName;
					if (m_KeyComparer.Equals(parameterName, internalParameterName))
					{
						return i;
					}
				}
			}
		}
		return -1;
	}

	public override int IndexOf(object value)
	{
		if (value != null)
		{
			ValidateType(value);
			if (m_Values != null)
			{
				int count = m_Values.Count;
				for (int i = 0; i < count; i++)
				{
					if (value == m_Values[i])
					{
						return i;
					}
				}
			}
		}
		return -1;
	}

	public override void Insert(int index, object value)
	{
		OnDataBindingChange();
		ValidateType(value);
		AddWithoutEvents(index, (SqlCeParameter)value);
	}

	internal void OnDataBindingChange()
	{
		if (parent != null)
		{
			parent.OnDataBindingChange();
		}
	}

	public override void RemoveAt(int index)
	{
		OnDataBindingChange();
		RangeCheck(index);
		RemoveIndex(index);
	}

	public override void RemoveAt(string parameterName)
	{
		OnDataBindingChange();
		RemoveIndex(RangeCheckIndex(parameterName));
	}

	private void RemoveIndex(int index)
	{
		SqlCeParameter sqlCeParameter = m_Values[index];
		sqlCeParameter.Parent = null;
		m_KeyValuePairs.Remove(sqlCeParameter.InternalParameterName);
		m_Values.RemoveAt(index);
	}

	public override void Remove(object value)
	{
		OnDataBindingChange();
		ValidateType(value);
		int num = IndexOf((SqlCeParameter)value);
		if (-1 != num)
		{
			RemoveIndex(num);
			return;
		}
		throw new ArgumentException(Res.GetString("ADP_CollectionRemoveInvalidObject", ItemType.Name, GetType().Name));
	}

	private void ValidateType(object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value", Res.GetString("ADP_CollectionNullValue", GetType().Name, ItemType.Name));
		}
		if (!ItemType.IsInstanceOfType(value))
		{
			throw new InvalidCastException(Res.GetString("ADP_CollectionInvalidType", GetType().Name, ItemType.Name, value.GetType().Name));
		}
	}

	private void Validate(int index, SqlCeParameter value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value", Res.GetString("ADP_CollectionNullValue", GetType().Name, ItemType.Name));
		}
		if (value.Parent != null)
		{
			if (this != value.Parent)
			{
				throw new ArgumentException(Res.GetString("ADP_CollectionIsNotParent", ItemType.Name, GetType().Name));
			}
			if (index != IndexOf(value))
			{
				throw new ArgumentException(Res.GetString("ADP_CollectionIsParent", ItemType.Name, GetType().Name));
			}
		}
		string internalParameterName = value.InternalParameterName;
		if (ADP.IsEmpty(internalParameterName))
		{
			index = 1;
			do
			{
				internalParameterName = "Parameter" + index.ToString(CultureInfo.CurrentCulture);
				index++;
			}
			while (-1 != IndexOf(internalParameterName));
			value.ParameterName = internalParameterName;
		}
	}
}
