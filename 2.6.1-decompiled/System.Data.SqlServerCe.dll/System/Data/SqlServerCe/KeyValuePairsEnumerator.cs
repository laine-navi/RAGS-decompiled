using System.Collections;
using System.Collections.Generic;

namespace System.Data.SqlServerCe;

internal class KeyValuePairsEnumerator<TKey, TValue> : IEnumerator
{
	private IEnumerator<KeyValuePair<TKey, TValue>> m_collection;

	public object Current => m_collection.Current.Value;

	public KeyValuePairsEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
	{
		m_collection = enumerator;
	}

	public void Reset()
	{
		m_collection.Reset();
	}

	public bool MoveNext()
	{
		return m_collection.MoveNext();
	}
}
