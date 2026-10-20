using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorTextBox : WatermarkTextBox
{
	static PropertyGridEditorTextBox()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorTextBox)));
	}
}
