using System;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ItemsSourceAttributeEditor : TypeEditor<ComboBox>
{
	private readonly ItemsSourceAttribute _attribute;

	public ItemsSourceAttributeEditor(ItemsSourceAttribute attribute)
	{
		_attribute = attribute;
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = Selector.SelectedValueProperty;
	}

	protected override ComboBox CreateEditor()
	{
		return (ComboBox)(object)new PropertyGridEditorComboBox();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		SetItemsSource();
		base.ResolveValueBinding(propertyItem);
	}

	protected override void SetControlProperties()
	{
		((ItemsControl)Editor).DisplayMemberPath = "DisplayName";
		((Selector)Editor).SelectedValuePath = "Value";
	}

	private void SetItemsSource()
	{
		((ItemsControl)Editor).ItemsSource = CreateItemsSource();
	}

	private IEnumerable CreateItemsSource()
	{
		object obj = Activator.CreateInstance(_attribute.Type);
		return (obj as IItemsSource).GetValues();
	}
}
