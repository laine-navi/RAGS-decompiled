using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal class DescriptorPropertyDefinition : DescriptorPropertyDefinitionBase
{
	private readonly object _selectedObject;

	private readonly PropertyDescriptor _propertyDescriptor;

	private readonly DependencyPropertyDescriptor _dpDescriptor;

	private readonly MarkupObject _markupObject;

	internal override PropertyDescriptor PropertyDescriptor => _propertyDescriptor;

	private object SelectedObject => _selectedObject;

	internal DescriptorPropertyDefinition(PropertyDescriptor propertyDescriptor, object selectedObject, bool isPropertyGridCategorized)
		: base(isPropertyGridCategorized)
	{
		if (propertyDescriptor == null)
		{
			throw new ArgumentNullException("propertyDescriptor");
		}
		if (selectedObject == null)
		{
			throw new ArgumentNullException("selectedObject");
		}
		_propertyDescriptor = propertyDescriptor;
		_selectedObject = selectedObject;
		_dpDescriptor = DependencyPropertyDescriptor.FromProperty(propertyDescriptor);
		_markupObject = MarkupWriter.GetMarkupObjectFor(SelectedObject);
	}

	internal override ObjectContainerHelperBase CreateContainerHelper(IPropertyContainer parent)
	{
		return new ObjectContainerHelper(parent, Value);
	}

	internal override void OnValueChanged(object oldValue, object newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		RaiseContainerHelperInvalidated();
	}

	protected override BindingBase CreateValueBinding()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		Binding val = new Binding(PropertyDescriptor.Name);
		val.Source = SelectedObject;
		val.Mode = (BindingMode)(PropertyDescriptor.IsReadOnly ? 1 : 0);
		val.ValidatesOnDataErrors = true;
		val.ValidatesOnExceptions = true;
		return (BindingBase)(object)val;
	}

	protected override bool ComputeIsReadOnly()
	{
		return PropertyDescriptor.IsReadOnly;
	}

	internal override ITypeEditor CreateDefaultEditor()
	{
		return PropertyGridUtilities.CreateDefaultEditor(PropertyDescriptor.PropertyType, PropertyDescriptor.Converter);
	}

	protected override bool ComputeCanResetValue()
	{
		if (PropertyDescriptor.CanResetValue(SelectedObject))
		{
			return !PropertyDescriptor.IsReadOnly;
		}
		return false;
	}

	protected override object ComputeAdvancedOptionsTooltip()
	{
		MarkupObject markupObject = _markupObject;
		object selectedObject = SelectedObject;
		UpdateAdvanceOptionsForItem(markupObject, (DependencyObject)((selectedObject is DependencyObject) ? selectedObject : null), _dpDescriptor, out var tooltip);
		return tooltip;
	}

	protected override string ComputeCategory()
	{
		return PropertyDescriptor.Category;
	}

	protected override string ComputeCategoryValue()
	{
		return PropertyDescriptor.Category;
	}

	protected override bool ComputeExpandableAttribute()
	{
		return (bool)ComputeExpandableAttributeForItem(PropertyDescriptor);
	}

	protected override bool ComputeIsExpandable()
	{
		return Value != null;
	}

	protected override IList<Type> ComputeNewItemTypes()
	{
		return (IList<Type>)ComputeNewItemTypesForItem(PropertyDescriptor);
	}

	protected override string ComputeDescription()
	{
		return (string)ComputeDescriptionForItem(PropertyDescriptor);
	}

	protected override int ComputeDisplayOrder(bool isPropertyGridCategorized)
	{
		IsPropertyGridCategorized = isPropertyGridCategorized;
		return (int)ComputeDisplayOrderForItem(PropertyDescriptor);
	}

	protected override void ResetValue()
	{
		PropertyDescriptor.ResetValue(SelectedObject);
	}

	internal override ITypeEditor CreateAttributeEditor()
	{
		EditorAttribute attribute = GetAttribute<EditorAttribute>();
		if (attribute != null)
		{
			Type type = Type.GetType(attribute.EditorTypeName);
			if (typeof(ITypeEditor).IsAssignableFrom(type) && type.GetConstructor(new Type[0]) != null && Activator.CreateInstance(type) is ITypeEditor result)
			{
				return result;
			}
		}
		ItemsSourceAttribute attribute2 = GetAttribute<ItemsSourceAttribute>();
		if (attribute2 != null)
		{
			return new ItemsSourceAttributeEditor(attribute2);
		}
		return null;
	}

	private T GetAttribute<T>() where T : Attribute
	{
		return PropertyGridUtilities.GetAttribute<T>(PropertyDescriptor);
	}
}
