namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class LongUpDownEditor : UpDownEditor<LongUpDown, long?>
{
	protected override LongUpDown CreateEditor()
	{
		return new PropertyGridEditorLongUpDown();
	}
}
