using System.Collections;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public abstract class ComboBoxEditor : TypeEditor<ComboBox>
{
	protected override void SetValueDependencyProperty()
	{
		ValueProperty = Selector.SelectedItemProperty;
	}

	protected override ComboBox CreateEditor()
	{
		return (ComboBox)(object)new PropertyGridEditorComboBox();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		SetItemsSource(propertyItem);
		base.ResolveValueBinding(propertyItem);
	}

	protected abstract IEnumerable CreateItemsSource(PropertyItem propertyItem);

	private void SetItemsSource(PropertyItem propertyItem)
	{
		((ItemsControl)Editor).ItemsSource = CreateItemsSource(propertyItem);
	}
}
