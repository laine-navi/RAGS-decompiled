using System;
using System.Collections.Generic;
using System.Reflection;
using Polenter.Serialization.Core;

namespace Polenter.Serialization.Deserializing;

public sealed class ObjectFactory
{
	private class MultiDimensionalArrayCreatingInfo
	{
		public int[] Lengths { get; set; }

		public int[] LowerBounds { get; set; }
	}

	private readonly object[] _emptyObjectArray = new object[0];

	private readonly Dictionary<int, object> _objectCache = new Dictionary<int, object>();

	public object CreateObject(Property property)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		if (property is NullProperty)
		{
			return null;
		}
		if ((object)property.Type == null)
		{
			throw new InvalidOperationException($"Property type is not defined. Property: \"{property.Name}\"");
		}
		if (property is SimpleProperty property2)
		{
			return createObjectFromSimpleProperty(property2);
		}
		if (!(property is ReferenceTargetProperty referenceTargetProperty))
		{
			return null;
		}
		if (referenceTargetProperty.Reference != null && !referenceTargetProperty.Reference.IsProcessed)
		{
			return _objectCache[referenceTargetProperty.Reference.Id];
		}
		object obj = createObjectCore(referenceTargetProperty);
		if (obj != null)
		{
			return obj;
		}
		throw new InvalidOperationException($"Unknown Property type: {property.GetType().Name}");
	}

	private object createObjectCore(ReferenceTargetProperty property)
	{
		if (property is MultiDimensionalArrayProperty property2)
		{
			return createObjectFromMultidimensionalArrayProperty(property2);
		}
		if (property is SingleDimensionalArrayProperty property3)
		{
			return createObjectFromSingleDimensionalArrayProperty(property3);
		}
		if (property is DictionaryProperty property4)
		{
			return createObjectFromDictionaryProperty(property4);
		}
		if (property is CollectionProperty property5)
		{
			return createObjectFromCollectionProperty(property5);
		}
		if (property is ComplexProperty property6)
		{
			return createObjectFromComplexProperty(property6);
		}
		return null;
	}

	private static object createObjectFromSimpleProperty(SimpleProperty property)
	{
		return property.Value;
	}

	private object createObjectFromComplexProperty(ComplexProperty property)
	{
		object obj = Tools.CreateInstance(property.Type);
		if (property.Reference != null)
		{
			_objectCache.Add(property.Reference.Id, obj);
		}
		fillProperties(obj, property.Properties);
		return obj;
	}

	private object createObjectFromCollectionProperty(CollectionProperty property)
	{
		Type type = property.Type;
		object obj = Tools.CreateInstance(type);
		if (property.Reference != null)
		{
			_objectCache.Add(property.Reference.Id, obj);
		}
		fillProperties(obj, property.Properties);
		MethodInfo method = obj.GetType().GetMethod("Add");
		if ((object)method != null)
		{
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 1)
			{
				foreach (Property item in property.Items)
				{
					object obj2 = CreateObject(item);
					method.Invoke(obj, new object[1] { obj2 });
				}
			}
		}
		return obj;
	}

	private object createObjectFromDictionaryProperty(DictionaryProperty property)
	{
		object obj = Tools.CreateInstance(property.Type);
		if (property.Reference != null)
		{
			_objectCache.Add(property.Reference.Id, obj);
		}
		fillProperties(obj, property.Properties);
		MethodInfo method = obj.GetType().GetMethod("Add");
		if ((object)method != null)
		{
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 2)
			{
				foreach (KeyValueItem item in property.Items)
				{
					object obj2 = CreateObject(item.Key);
					object obj3 = CreateObject(item.Value);
					method.Invoke(obj, new object[2] { obj2, obj3 });
				}
			}
		}
		return obj;
	}

	private void fillProperties(object obj, IEnumerable<Property> properties)
	{
		foreach (Property property2 in properties)
		{
			PropertyInfo property = obj.GetType().GetProperty(property2.Name);
			if ((object)property != null)
			{
				object obj2 = CreateObject(property2);
				if (obj2 != null)
				{
					property.SetValue(obj, obj2, _emptyObjectArray);
				}
			}
		}
	}

	private object createObjectFromSingleDimensionalArrayProperty(SingleDimensionalArrayProperty property)
	{
		int count = property.Items.Count;
		Array array = createArrayInstance(property.ElementType, new int[1] { count }, new int[1] { property.LowerBound });
		if (property.Reference != null)
		{
			_objectCache.Add(property.Reference.Id, array);
		}
		for (int i = property.LowerBound; i < property.LowerBound + count; i++)
		{
			Property property2 = property.Items[i];
			object obj = CreateObject(property2);
			if (obj != null)
			{
				array.SetValue(obj, i);
			}
		}
		return array;
	}

	private object createObjectFromMultidimensionalArrayProperty(MultiDimensionalArrayProperty property)
	{
		MultiDimensionalArrayCreatingInfo multiDimensionalArrayCreatingInfo = getMultiDimensionalArrayCreatingInfo(property.DimensionInfos);
		Array array = createArrayInstance(property.ElementType, multiDimensionalArrayCreatingInfo.Lengths, multiDimensionalArrayCreatingInfo.LowerBounds);
		if (property.Reference != null)
		{
			_objectCache.Add(property.Reference.Id, array);
		}
		foreach (MultiDimensionalArrayItem item in property.Items)
		{
			object obj = CreateObject(item.Value);
			if (obj != null)
			{
				array.SetValue(obj, item.Indexes);
			}
		}
		return array;
	}

	private static Array createArrayInstance(Type elementType, int[] lengths, int[] lowerBounds)
	{
		return Array.CreateInstance(elementType, lengths, lowerBounds);
	}

	private static MultiDimensionalArrayCreatingInfo getMultiDimensionalArrayCreatingInfo(IEnumerable<DimensionInfo> infos)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (DimensionInfo info in infos)
		{
			list.Add(info.Length);
			list2.Add(info.LowerBound);
		}
		MultiDimensionalArrayCreatingInfo multiDimensionalArrayCreatingInfo = new MultiDimensionalArrayCreatingInfo();
		multiDimensionalArrayCreatingInfo.Lengths = list.ToArray();
		multiDimensionalArrayCreatingInfo.LowerBounds = list2.ToArray();
		return multiDimensionalArrayCreatingInfo;
	}
}
