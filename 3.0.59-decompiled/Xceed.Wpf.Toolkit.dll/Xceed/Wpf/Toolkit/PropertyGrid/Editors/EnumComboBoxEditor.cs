using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class EnumComboBoxEditor : ComboBoxEditor
{
	protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
	{
		return GetValues(propertyItem.PropertyType);
	}

	private static object[] GetValues(Type enumType)
	{
		List<object> list = new List<object>();
		if (enumType != null)
		{
			IEnumerable<FieldInfo> enumerable = from x in enumType.GetFields()
				where x.IsLiteral
				select x;
			foreach (FieldInfo item in enumerable)
			{
				object[] customAttributes = item.GetCustomAttributes(typeof(BrowsableAttribute), inherit: false);
				if (customAttributes.Length == 1)
				{
					BrowsableAttribute browsableAttribute = (BrowsableAttribute)customAttributes[0];
					if (!browsableAttribute.Browsable)
					{
						continue;
					}
				}
				list.Add(item.GetValue(enumType));
			}
		}
		return list.ToArray();
	}
}
