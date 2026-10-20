namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class IntegerUpDownEditor : UpDownEditor<IntegerUpDown, int?>
{
	protected override IntegerUpDown CreateEditor()
	{
		return new PropertyGridEditorIntegerUpDown();
	}
}
