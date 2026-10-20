using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Polenter.Serialization.Advanced.Deserializing;
using Polenter.Serialization.Advanced.Xml;
using Polenter.Serialization.Core;
using Polenter.Serialization.Serializing;

namespace Polenter.Serialization.Advanced;

public sealed class XmlPropertyDeserializer : IPropertyDeserializer
{
	private readonly IXmlReader _reader;

	private readonly Dictionary<int, ReferenceTargetProperty> _propertyCache = new Dictionary<int, ReferenceTargetProperty>();

	public XmlPropertyDeserializer(IXmlReader reader)
	{
		_reader = reader;
	}

	public void Open(Stream stream)
	{
		_reader.Open(stream);
	}

	public Property Deserialize()
	{
		string name = _reader.ReadElement();
		PropertyArt propertyArtFromString = getPropertyArtFromString(name);
		if (propertyArtFromString == PropertyArt.Unknown)
		{
			return null;
		}
		return deserialize(propertyArtFromString, null);
	}

	public void Close()
	{
		_reader.Close();
	}

	private Property deserialize(PropertyArt propertyArt, Type expectedType)
	{
		string attributeAsString = _reader.GetAttributeAsString("name");
		Type type = _reader.GetAttributeAsType("type");
		if ((object)type == null)
		{
			type = expectedType;
		}
		Property property = Property.CreateInstance(propertyArt, attributeAsString, type);
		if (property is NullProperty result)
		{
			return result;
		}
		if (property is SimpleProperty simpleProperty)
		{
			parseSimpleProperty(_reader, simpleProperty);
			return simpleProperty;
		}
		int attributeAsInt = _reader.GetAttributeAsInt("id");
		if (property is ReferenceTargetProperty referenceTargetProperty && attributeAsInt > 0)
		{
			referenceTargetProperty.Reference = new ReferenceInfo
			{
				Id = attributeAsInt,
				IsProcessed = true
			};
			_propertyCache.Add(attributeAsInt, referenceTargetProperty);
		}
		if (property == null)
		{
			if (attributeAsInt < 1)
			{
				return null;
			}
			property = createProperty(attributeAsInt, attributeAsString, type);
			if (property == null)
			{
				return null;
			}
			return property;
		}
		if (property is MultiDimensionalArrayProperty multiDimensionalArrayProperty)
		{
			parseMultiDimensionalArrayProperty(multiDimensionalArrayProperty);
			return multiDimensionalArrayProperty;
		}
		if (property is SingleDimensionalArrayProperty singleDimensionalArrayProperty)
		{
			parseSingleDimensionalArrayProperty(singleDimensionalArrayProperty);
			return singleDimensionalArrayProperty;
		}
		if (property is DictionaryProperty dictionaryProperty)
		{
			parseDictionaryProperty(dictionaryProperty);
			return dictionaryProperty;
		}
		if (property is CollectionProperty collectionProperty)
		{
			parseCollectionProperty(collectionProperty);
			return collectionProperty;
		}
		if (property is ComplexProperty complexProperty)
		{
			parseComplexProperty(complexProperty);
			return complexProperty;
		}
		return property;
	}

	private void parseCollectionProperty(CollectionProperty property)
	{
		property.ElementType = (((object)property.Type != null) ? Polenter.Serialization.Serializing.TypeInfo.GetTypeInfo(property.Type).ElementType : null);
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Properties")
			{
				readProperties(property.Properties, property.Type);
			}
			else if (item == "Items")
			{
				readItems(property.Items, property.ElementType);
			}
		}
	}

	private void parseDictionaryProperty(DictionaryProperty property)
	{
		if ((object)property.Type != null)
		{
			Polenter.Serialization.Serializing.TypeInfo typeInfo = Polenter.Serialization.Serializing.TypeInfo.GetTypeInfo(property.Type);
			property.KeyType = typeInfo.KeyType;
			property.ValueType = typeInfo.ElementType;
		}
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Properties")
			{
				readProperties(property.Properties, property.Type);
			}
			else if (item == "Items")
			{
				readDictionaryItems(property.Items, property.KeyType, property.ValueType);
			}
		}
	}

	private void readDictionaryItems(IList<KeyValueItem> items, Type expectedKeyType, Type expectedValueType)
	{
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Item")
			{
				readDictionaryItem(items, expectedKeyType, expectedValueType);
			}
		}
	}

	private void readDictionaryItem(IList<KeyValueItem> items, Type expectedKeyType, Type expectedValueType)
	{
		Property property = null;
		Property property2 = null;
		foreach (string item2 in _reader.ReadSubElements())
		{
			if (property != null && property2 != null)
			{
				break;
			}
			PropertyArt propertyArtFromString = getPropertyArtFromString(item2);
			if (propertyArtFromString != PropertyArt.Unknown)
			{
				if (property == null)
				{
					property = deserialize(propertyArtFromString, expectedKeyType);
				}
				else
				{
					property2 = deserialize(propertyArtFromString, expectedValueType);
				}
			}
		}
		KeyValueItem item = new KeyValueItem(property, property2);
		items.Add(item);
	}

	private void parseMultiDimensionalArrayProperty(MultiDimensionalArrayProperty property)
	{
		property.ElementType = (((object)property.Type != null) ? Polenter.Serialization.Serializing.TypeInfo.GetTypeInfo(property.Type).ElementType : null);
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Dimensions")
			{
				readDimensionInfos(property.DimensionInfos);
			}
			if (item == "Items")
			{
				readMultiDimensionalArrayItems(property.Items, property.ElementType);
			}
		}
	}

	private void readMultiDimensionalArrayItems(IList<MultiDimensionalArrayItem> items, Type expectedElementType)
	{
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Item")
			{
				readMultiDimensionalArrayItem(items, expectedElementType);
			}
		}
	}

	private void readMultiDimensionalArrayItem(IList<MultiDimensionalArrayItem> items, Type expectedElementType)
	{
		int[] attributeAsArrayOfInt = _reader.GetAttributeAsArrayOfInt("indexes");
		foreach (string item2 in _reader.ReadSubElements())
		{
			PropertyArt propertyArtFromString = getPropertyArtFromString(item2);
			if (propertyArtFromString != PropertyArt.Unknown)
			{
				Property value = deserialize(propertyArtFromString, expectedElementType);
				MultiDimensionalArrayItem item = new MultiDimensionalArrayItem(attributeAsArrayOfInt, value);
				items.Add(item);
			}
		}
	}

	private void readDimensionInfos(IList<DimensionInfo> dimensionInfos)
	{
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Dimension")
			{
				readDimensionInfo(dimensionInfos);
			}
		}
	}

	private void readDimensionInfo(IList<DimensionInfo> dimensionInfos)
	{
		DimensionInfo dimensionInfo = new DimensionInfo();
		dimensionInfo.Length = _reader.GetAttributeAsInt("length");
		dimensionInfo.LowerBound = _reader.GetAttributeAsInt("lowerBound");
		dimensionInfos.Add(dimensionInfo);
	}

	private void parseSingleDimensionalArrayProperty(SingleDimensionalArrayProperty property)
	{
		property.ElementType = (((object)property.Type != null) ? Polenter.Serialization.Serializing.TypeInfo.GetTypeInfo(property.Type).ElementType : null);
		property.LowerBound = _reader.GetAttributeAsInt("lowerBound");
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Items")
			{
				readItems(property.Items, property.ElementType);
			}
		}
	}

	private void readItems(ICollection<Property> items, Type expectedElementType)
	{
		foreach (string item2 in _reader.ReadSubElements())
		{
			PropertyArt propertyArtFromString = getPropertyArtFromString(item2);
			if (propertyArtFromString != PropertyArt.Unknown)
			{
				Property item = deserialize(propertyArtFromString, expectedElementType);
				items.Add(item);
			}
		}
	}

	private void parseComplexProperty(ComplexProperty property)
	{
		foreach (string item in _reader.ReadSubElements())
		{
			if (item == "Properties")
			{
				readProperties(property.Properties, property.Type);
			}
		}
	}

	private void readProperties(PropertyCollection properties, Type ownerType)
	{
		foreach (string item2 in _reader.ReadSubElements())
		{
			PropertyArt propertyArtFromString = getPropertyArtFromString(item2);
			if (propertyArtFromString == PropertyArt.Unknown)
			{
				continue;
			}
			string attributeAsString = _reader.GetAttributeAsString("name");
			if (!string.IsNullOrEmpty(attributeAsString))
			{
				PropertyInfo property = ownerType.GetProperty(attributeAsString);
				if ((object)property != null)
				{
					Property item = deserialize(propertyArtFromString, property.PropertyType);
					properties.Add(item);
				}
			}
		}
	}

	private void parseSimpleProperty(IXmlReader reader, SimpleProperty property)
	{
		property.Value = _reader.GetAttributeAsObject("value", property.Type);
	}

	private Property createProperty(int referenceId, string propertyName, Type propertyType)
	{
		ReferenceTargetProperty referenceTargetProperty = _propertyCache[referenceId];
		ReferenceTargetProperty referenceTargetProperty2 = (ReferenceTargetProperty)Property.CreateInstance(referenceTargetProperty.Art, propertyName, propertyType);
		referenceTargetProperty.Reference.Count++;
		referenceTargetProperty2.MakeFlatCopyFrom(referenceTargetProperty);
		referenceTargetProperty2.Reference = new ReferenceInfo
		{
			Id = referenceId
		};
		return referenceTargetProperty2;
	}

	private static PropertyArt getPropertyArtFromString(string name)
	{
		return name switch
		{
			"Simple" => PropertyArt.Simple, 
			"Complex" => PropertyArt.Complex, 
			"Collection" => PropertyArt.Collection, 
			"SingleArray" => PropertyArt.SingleDimensionalArray, 
			"Null" => PropertyArt.Null, 
			"Dictionary" => PropertyArt.Dictionary, 
			"MultiArray" => PropertyArt.MultiDimensionalArray, 
			"ComplexReference" => PropertyArt.Reference, 
			"Reference" => PropertyArt.Reference, 
			_ => PropertyArt.Unknown, 
		};
	}
}
