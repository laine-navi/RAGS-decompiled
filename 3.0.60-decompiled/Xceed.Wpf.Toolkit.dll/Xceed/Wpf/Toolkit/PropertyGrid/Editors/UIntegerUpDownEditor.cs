namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class UIntegerUpDownEditor : UpDownEditor<UIntegerUpDown, uint?>
{
	protected override UIntegerUpDown CreateEditor()
	{
		return new PropertyGridEditorUIntegerUpDown();
	}
}
