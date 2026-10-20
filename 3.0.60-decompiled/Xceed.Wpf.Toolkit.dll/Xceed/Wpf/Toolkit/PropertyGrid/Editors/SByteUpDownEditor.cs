namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class SByteUpDownEditor : UpDownEditor<SByteUpDown, sbyte?>
{
	protected override SByteUpDown CreateEditor()
	{
		return new PropertyGridEditorSByteUpDown();
	}
}
