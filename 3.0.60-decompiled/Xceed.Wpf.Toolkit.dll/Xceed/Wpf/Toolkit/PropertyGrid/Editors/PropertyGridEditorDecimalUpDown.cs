using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorDecimalUpDown : DecimalUpDown
{
	static PropertyGridEditorDecimalUpDown()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorDecimalUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorDecimalUpDown)));
	}
}
