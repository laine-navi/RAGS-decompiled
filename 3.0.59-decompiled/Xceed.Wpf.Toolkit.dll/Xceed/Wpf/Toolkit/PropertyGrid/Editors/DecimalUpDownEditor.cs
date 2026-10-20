namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class DecimalUpDownEditor : UpDownEditor<DecimalUpDown, decimal?>
{
	protected override DecimalUpDown CreateEditor()
	{
		return new PropertyGridEditorDecimalUpDown();
	}
}
