using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PrimitiveTypeCollectionEditor : TypeEditor<PrimitiveTypeCollectionControl>
{
	protected override void SetControlProperties()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		((Control)Editor).BorderThickness = new Thickness(0.0);
		((ContentControl)Editor).Content = "(Collection)";
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = PrimitiveTypeCollectionControl.ItemsSourceProperty;
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		Type propertyType = propertyItem.PropertyType;
		Editor.ItemsSourceType = propertyType;
		if (propertyType.BaseType == typeof(Array))
		{
			Editor.ItemType = propertyType.GetElementType();
		}
		else
		{
			Editor.ItemType = propertyType.GetGenericArguments()[0];
		}
		base.ResolveValueBinding(propertyItem);
	}
}
