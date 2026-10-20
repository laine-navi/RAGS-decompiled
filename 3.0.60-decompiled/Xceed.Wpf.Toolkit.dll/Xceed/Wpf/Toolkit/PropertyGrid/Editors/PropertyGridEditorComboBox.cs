using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorComboBox : ComboBox
{
	static PropertyGridEditorComboBox()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorComboBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorComboBox)));
	}
}
