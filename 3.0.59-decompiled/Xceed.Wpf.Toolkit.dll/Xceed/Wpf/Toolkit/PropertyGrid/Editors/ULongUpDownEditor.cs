namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class ULongUpDownEditor : UpDownEditor<ULongUpDown, ulong?>
{
	protected override ULongUpDown CreateEditor()
	{
		return new PropertyGridEditorULongUpDown();
	}
}
