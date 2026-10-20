namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ShortUpDownEditor : UpDownEditor<ShortUpDown, short?>
{
	protected override ShortUpDown CreateEditor()
	{
		return new PropertyGridEditorShortUpDown();
	}
}
