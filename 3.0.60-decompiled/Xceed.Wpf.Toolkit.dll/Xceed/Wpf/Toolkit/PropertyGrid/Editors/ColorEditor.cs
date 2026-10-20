using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ColorEditor : TypeEditor<ColorPicker>
{
	protected override ColorPicker CreateEditor()
	{
		return new PropertyGridEditorColorPicker();
	}

	protected override void SetControlProperties()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		((Control)Editor).BorderThickness = new Thickness(0.0);
		Editor.DisplayColorAndName = true;
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = ColorPicker.SelectedColorProperty;
	}
}
