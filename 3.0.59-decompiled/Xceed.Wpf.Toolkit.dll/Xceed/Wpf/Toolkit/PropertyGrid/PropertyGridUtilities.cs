using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal class PropertyGridUtilities
{
	internal static T GetAttribute<T>(PropertyDescriptor property) where T : Attribute
	{
		return property.Attributes.OfType<T>().FirstOrDefault();
	}

	internal static ITypeEditor CreateDefaultEditor(Type propertyType, TypeConverter typeConverter)
	{
		ITypeEditor typeEditor = null;
		if (propertyType == typeof(string))
		{
			return new TextBoxEditor();
		}
		if (propertyType == typeof(bool) || propertyType == typeof(bool?))
		{
			return new CheckBoxEditor();
		}
		if (propertyType == typeof(decimal) || propertyType == typeof(decimal?))
		{
			return new DecimalUpDownEditor();
		}
		if (propertyType == typeof(double) || propertyType == typeof(double?))
		{
			return new DoubleUpDownEditor();
		}
		if (propertyType == typeof(int) || propertyType == typeof(int?))
		{
			return new IntegerUpDownEditor();
		}
		if (propertyType == typeof(short) || propertyType == typeof(short?))
		{
			return new ShortUpDownEditor();
		}
		if (propertyType == typeof(long) || propertyType == typeof(long?))
		{
			return new LongUpDownEditor();
		}
		if (propertyType == typeof(float) || propertyType == typeof(float?))
		{
			return new SingleUpDownEditor();
		}
		if (propertyType == typeof(byte) || propertyType == typeof(byte?))
		{
			return new ByteUpDownEditor();
		}
		if (propertyType == typeof(sbyte) || propertyType == typeof(sbyte?))
		{
			return new SByteUpDownEditor();
		}
		if (propertyType == typeof(uint) || propertyType == typeof(uint?))
		{
			return new UIntegerUpDownEditor();
		}
		if (propertyType == typeof(ulong) || propertyType == typeof(ulong?))
		{
			return new ULongUpDownEditor();
		}
		if (propertyType == typeof(ushort) || propertyType == typeof(ushort?))
		{
			return new UShortUpDownEditor();
		}
		if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
		{
			return new DateTimeUpDownEditor();
		}
		if (propertyType == typeof(Color))
		{
			return new ColorEditor();
		}
		if (propertyType.IsEnum)
		{
			return new EnumComboBoxEditor();
		}
		if (propertyType == typeof(TimeSpan))
		{
			return new TimeSpanEditor();
		}
		if (propertyType == typeof(FontFamily) || propertyType == typeof(FontWeight) || propertyType == typeof(FontStyle) || propertyType == typeof(FontStretch))
		{
			return new FontComboBoxEditor();
		}
		if (propertyType == typeof(object))
		{
			return new TextBoxEditor();
		}
		Type listItemType = ListUtilities.GetListItemType(propertyType);
		if (listItemType != null)
		{
			if (!listItemType.IsPrimitive && !listItemType.Equals(typeof(string)))
			{
				return new CollectionEditor();
			}
			return new PrimitiveTypeCollectionEditor();
		}
		object result;
		if (typeConverter == null || !typeConverter.CanConvertFrom(typeof(string)))
		{
			ITypeEditor typeEditor2 = new TextBlockEditor();
			result = typeEditor2;
		}
		else
		{
			result = new TextBoxEditor();
		}
		return (ITypeEditor)result;
	}
}
