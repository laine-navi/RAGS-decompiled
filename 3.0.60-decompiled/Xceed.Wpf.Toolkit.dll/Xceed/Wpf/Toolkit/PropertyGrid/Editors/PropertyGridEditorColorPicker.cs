using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorColorPicker : ColorPicker
{
	static PropertyGridEditorColorPicker()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorColorPicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorColorPicker)));
	}
}
