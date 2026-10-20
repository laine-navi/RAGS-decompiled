using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class TextBoxEditor : TypeEditor<WatermarkTextBox>
{
	protected override WatermarkTextBox CreateEditor()
	{
		return new PropertyGridEditorTextBox();
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = TextBox.TextProperty;
	}
}
