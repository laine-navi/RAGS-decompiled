using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal class ObjectContainerHelper : ObjectContainerHelperBase
{
	private object _selectedObject;

	private object SelectedObject => _selectedObject;

	public ObjectContainerHelper(IPropertyContainer propertyContainer, object selectedObject)
		: base(propertyContainer)
	{
		_selectedObject = selectedObject;
	}

	protected override string GetDefaultPropertyName()
	{
		object selectedObject = SelectedObject;
		if (selectedObject == null)
		{
			return null;
		}
		return ObjectContainerHelperBase.GetDefaultPropertyName(SelectedObject);
	}

	protected override IEnumerable<PropertyItem> GenerateSubPropertiesCore()
	{
		List<PropertyItem> list = new List<PropertyItem>();
		if (SelectedObject != null)
		{
			try
			{
				List<PropertyDescriptor> propertyDescriptors = ObjectContainerHelperBase.GetPropertyDescriptors(SelectedObject);
				foreach (PropertyDescriptor item in propertyDescriptors)
				{
					PropertyDefinition propertyDefinition = GetPropertyDefinition(item);
					bool flag = item.IsBrowsable && PropertyContainer.AutoGenerateProperties;
					if (propertyDefinition != null)
					{
						flag = propertyDefinition.IsBrowsable ?? flag;
					}
					if (flag)
					{
						list.Add(CreatePropertyItem(item, propertyDefinition));
					}
				}
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private PropertyItem CreatePropertyItem(PropertyDescriptor property, PropertyDefinition propertyDef)
	{
		DescriptorPropertyDefinition descriptorPropertyDefinition = new DescriptorPropertyDefinition(property, SelectedObject, PropertyContainer.IsCategorized);
		descriptorPropertyDefinition.InitProperties();
		InitializeDescriptorDefinition(descriptorPropertyDefinition, propertyDef);
		PropertyItem propertyItem = new PropertyItem(descriptorPropertyDefinition);
		propertyItem.Instance = SelectedObject;
		propertyItem.CategoryOrder = GetCategoryOrder(descriptorPropertyDefinition.CategoryValue);
		return propertyItem;
	}

	private int GetCategoryOrder(object categoryValue)
	{
		if (categoryValue == null)
		{
			return int.MaxValue;
		}
		int result = int.MaxValue;
		object selectedObject = SelectedObject;
		CategoryOrderAttribute[] source = ((selectedObject != null) ? ((CategoryOrderAttribute[])selectedObject.GetType().GetCustomAttributes(typeof(CategoryOrderAttribute), inherit: true)) : new CategoryOrderAttribute[0]);
		CategoryOrderAttribute categoryOrderAttribute = source.FirstOrDefault((CategoryOrderAttribute a) => object.Equals(a.CategoryValue, categoryValue));
		if (categoryOrderAttribute != null)
		{
			result = categoryOrderAttribute.Order;
		}
		return result;
	}
}
