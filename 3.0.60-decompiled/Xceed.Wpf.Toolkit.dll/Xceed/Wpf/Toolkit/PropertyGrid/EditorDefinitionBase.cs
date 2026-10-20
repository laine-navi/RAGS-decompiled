using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public abstract class EditorDefinitionBase : PropertyDefinitionBase
{
	internal EditorDefinitionBase()
	{
	}

	internal FrameworkElement GenerateEditingElementInternal(PropertyItemBase propertyItem)
	{
		return GenerateEditingElement(propertyItem);
	}

	protected virtual FrameworkElement GenerateEditingElement(PropertyItemBase propertyItem)
	{
		return null;
	}

	internal void UpdateProperty(FrameworkElement element, DependencyProperty elementProp, DependencyProperty definitionProperty)
	{
		object value = ((DependencyObject)this).GetValue(definitionProperty);
		object obj = ((DependencyObject)this).ReadLocalValue(definitionProperty);
		if (obj != DependencyProperty.UnsetValue || value != ((DependencyObject)element).GetValue(elementProp))
		{
			((DependencyObject)element).SetValue(elementProp, value);
		}
		else
		{
			((DependencyObject)element).ClearValue(elementProp);
		}
	}
}
