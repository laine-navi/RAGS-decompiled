using System.Collections;
using System.Globalization;

namespace System.Data.SqlServerCe;

internal sealed class FieldNameLookup
{
	private Hashtable _fieldNameLookup;

	private string[] _fieldNames;

	private CompareInfo _compareInfo;

	private int _defaultLocaleID;

	public FieldNameLookup(string[] fieldNames, int defaultLocaleID)
	{
		if (fieldNames == null)
		{
			throw new ArgumentNullException("fieldNames");
		}
		_fieldNames = fieldNames;
		_defaultLocaleID = defaultLocaleID;
	}

	public FieldNameLookup(IDataReader reader, int defaultLocaleID)
	{
		int fieldCount = reader.FieldCount;
		string[] array = new string[fieldCount];
		for (int i = 0; i < fieldCount; i++)
		{
			array[i] = reader.GetName(i);
		}
		_fieldNames = array;
		_defaultLocaleID = defaultLocaleID;
	}

	public int GetOrdinal(string fieldName)
	{
		if (fieldName == null)
		{
			throw new ArgumentNullException("fieldName");
		}
		int num = IndexOf(fieldName);
		if (-1 == num)
		{
			throw new IndexOutOfRangeException(fieldName);
		}
		return num;
	}

	public int IndexOfName(string fieldName)
	{
		if (_fieldNameLookup == null)
		{
			GenerateLookup();
		}
		object obj = _fieldNameLookup[fieldName];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	public int IndexOf(string fieldName)
	{
		if (_fieldNameLookup == null)
		{
			GenerateLookup();
		}
		object obj = _fieldNameLookup[fieldName];
		int num;
		if (obj != null)
		{
			num = (int)obj;
		}
		else
		{
			num = LinearIndexOf(fieldName, CompareOptions.IgnoreCase);
			if (-1 == num)
			{
				num = LinearIndexOf(fieldName, CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth);
			}
		}
		return num;
	}

	private int LinearIndexOf(string fieldName, CompareOptions compareOptions)
	{
		CompareInfo compareInfo = _compareInfo;
		if (compareInfo == null)
		{
			if (-1 != _defaultLocaleID)
			{
				compareInfo = CompareInfo.GetCompareInfo(_defaultLocaleID);
			}
			if (compareInfo == null)
			{
				compareInfo = CultureInfo.InvariantCulture.CompareInfo;
			}
			_compareInfo = compareInfo;
		}
		int num = _fieldNames.Length;
		for (int i = 0; i < num; i++)
		{
			if (compareInfo.Compare(fieldName, _fieldNames[i], compareOptions) == 0)
			{
				_fieldNameLookup[fieldName] = i;
				return i;
			}
		}
		return -1;
	}

	private void GenerateLookup()
	{
		int num = _fieldNames.Length;
		Hashtable hashtable = new Hashtable(num);
		int num2 = num - 1;
		while (0 <= num2)
		{
			string key = _fieldNames[num2];
			hashtable[key] = num2;
			num2--;
		}
		_fieldNameLookup = hashtable;
	}
}
