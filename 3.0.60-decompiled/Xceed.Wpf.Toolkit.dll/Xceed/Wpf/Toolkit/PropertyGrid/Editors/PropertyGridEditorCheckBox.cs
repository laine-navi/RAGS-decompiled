using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorCheckBox : CheckBox
{
	static PropertyGridEditorCheckBox()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorCheckBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorCheckBox)));
	}
}
