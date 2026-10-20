using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class PropertyGridEditorULongUpDown : ULongUpDown
{
	static PropertyGridEditorULongUpDown()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorULongUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorULongUpDown)));
	}
}
