using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class CheckBoxEditor : TypeEditor<CheckBox>
{
	protected override CheckBox CreateEditor()
	{
		return (CheckBox)(object)new PropertyGridEditorCheckBox();
	}

	protected override void SetControlProperties()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)Editor).Margin = new Thickness(5.0, 0.0, 0.0, 0.0);
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = ToggleButton.IsCheckedProperty;
	}
}
