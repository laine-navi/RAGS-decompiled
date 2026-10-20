using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Polenter.Serialization.Advanced;
using Polenter.Serialization.Core;

namespace Polenter.Serialization.Serializing;

public sealed class PropertyFactory
{
	private readonly object[] _emptyObjectArray = new object[0];

	private readonly PropertyProvider _propertyProvider;

	private readonly Dictionary<object, ReferenceTargetProperty> _propertyCache = new Dictionary<object, ReferenceTargetProperty>();

	private int _currentReferenceId = 1;

	public PropertyFactory(PropertyProvider propertyProvider)
	{
		_propertyProvider = propertyProvider;
	}

	public Property CreateProperty(string name, object value)
	{
		if (value == null)
		{
			return new NullProperty(name);
		}
		TypeInfo typeInfo = TypeInfo.GetTypeInfo(value);
		Property property = createSimpleProperty(name, typeInfo, value);
		if (property != null)
		{
			return property;
		}
		ReferenceTargetProperty referenceTargetProperty = createReferenceTargetInstance(name, typeInfo);
		if (_propertyCache.TryGetValue(value, out var value2))
		{
			value2.Reference.Count++;
			referenceTargetProperty.MakeFlatCopyFrom(value2);
			return referenceTargetProperty;
		}
		referenceTargetProperty.Reference = new ReferenceInfo();
		referenceTargetProperty.Reference.Id = _currentReferenceId++;
		_propertyCache.Add(value, referenceTargetProperty);
		if (!fillSingleDimensionalArrayProperty(referenceTargetProperty as SingleDimensionalArrayProperty, typeInfo, value) && !fillMultiDimensionalArrayProperty(referenceTargetProperty as MultiDimensionalArrayProperty, typeInfo, value) && !fillDictionaryProperty(referenceTargetProperty as DictionaryProperty, typeInfo, value) && !fillCollectionProperty(referenceTargetProperty as CollectionProperty, typeInfo, value) && !fillComplexProperty(referenceTargetProperty as ComplexProperty, typeInfo, value))
		{
			throw new InvalidOperationException($"Property cannot be filled. Property: {referenceTargetProperty}");
		}
		return referenceTargetProperty;
	}

	private static ReferenceTargetProperty createReferenceTargetInstance(string name, TypeInfo typeInfo)
	{
		if (typeInfo.IsArray)
		{
			if (typeInfo.ArrayDimensionCount < 2)
			{
				return new SingleDimensionalArrayProperty(name, typeInfo.Type);
			}
			return new MultiDimensionalArrayProperty(name, typeInfo.Type);
		}
		if (typeInfo.IsDictionary)
		{
			return new DictionaryProperty(name, typeInfo.Type);
		}
		if (typeInfo.IsCollection)
		{
			return new CollectionProperty(name, typeInfo.Type);
		}
		if (typeInfo.IsEnumerable)
		{
			return new CollectionProperty(name, typeInfo.Type);
		}
		return new ComplexProperty(name, typeInfo.Type);
	}

	private bool fillComplexProperty(ComplexProperty property, TypeInfo typeInfo, object value)
	{
		if (property == null)
		{
			return false;
		}
		parseProperties(property, typeInfo, value);
		return true;
	}

	private void parseProperties(ComplexProperty property, TypeInfo typeInfo, object value)
	{
		IList<PropertyInfo> properties = _propertyProvider.GetProperties(typeInfo);
		foreach (PropertyInfo item2 in properties)
		{
			object value2 = item2.GetValue(value, _emptyObjectArray);
			Property item = CreateProperty(item2.Name, value2);
			property.Properties.Add(item);
		}
	}

	private bool fillCollectionProperty(CollectionProperty property, TypeInfo info, object value)
	{
		if (property == null)
		{
			return false;
		}
		parseProperties(property, info, value);
		parseCollectionItems(property, info, value);
		return true;
	}

	private void parseCollectionItems(CollectionProperty property, TypeInfo info, object value)
	{
		property.ElementType = info.ElementType;
		IEnumerable enumerable = (IEnumerable)value;
		foreach (object item2 in enumerable)
		{
			Property item = CreateProperty(null, item2);
			property.Items.Add(item);
		}
	}

	private bool fillDictionaryProperty(DictionaryProperty property, TypeInfo info, object value)
	{
		if (property == null)
		{
			return false;
		}
		parseProperties(property, info, value);
		parseDictionaryItems(property, info, value);
		return true;
	}

	private void parseDictionaryItems(DictionaryProperty property, TypeInfo info, object value)
	{
		property.KeyType = info.KeyType;
		property.ValueType = info.ElementType;
		IDictionary dictionary = (IDictionary)value;
		foreach (DictionaryEntry item in dictionary)
		{
			Property key = CreateProperty(null, item.Key);
			Property value2 = CreateProperty(null, item.Value);
			property.Items.Add(new KeyValueItem(key, value2));
		}
	}

	private bool fillMultiDimensionalArrayProperty(MultiDimensionalArrayProperty property, TypeInfo info, object value)
	{
		if (property == null)
		{
			return false;
		}
		property.ElementType = info.ElementType;
		ArrayAnalyzer arrayAnalyzer = new ArrayAnalyzer(value);
		property.DimensionInfos = arrayAnalyzer.ArrayInfo.DimensionInfos;
		foreach (int[] index in arrayAnalyzer.GetIndexes())
		{
			object value2 = ((Array)value).GetValue(index);
			Property value3 = CreateProperty(null, value2);
			property.Items.Add(new MultiDimensionalArrayItem(index, value3));
		}
		return true;
	}

	private bool fillSingleDimensionalArrayProperty(SingleDimensionalArrayProperty property, TypeInfo info, object value)
	{
		if (property == null)
		{
			return false;
		}
		property.ElementType = info.ElementType;
		ArrayAnalyzer arrayAnalyzer = new ArrayAnalyzer(value);
		DimensionInfo dimensionInfo = arrayAnalyzer.ArrayInfo.DimensionInfos[0];
		property.LowerBound = dimensionInfo.LowerBound;
		foreach (object value2 in arrayAnalyzer.GetValues())
		{
			Property item = CreateProperty(null, value2);
			property.Items.Add(item);
		}
		return true;
	}

	private static Property createSimpleProperty(string name, TypeInfo typeInfo, object value)
	{
		if (!typeInfo.IsSimple)
		{
			return null;
		}
		SimpleProperty simpleProperty = new SimpleProperty(name, typeInfo.Type);
		simpleProperty.Value = value;
		return simpleProperty;
	}
}
