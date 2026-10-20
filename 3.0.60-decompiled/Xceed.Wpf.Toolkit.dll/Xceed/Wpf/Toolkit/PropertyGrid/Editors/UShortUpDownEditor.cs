namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class UShortUpDownEditor : UpDownEditor<UShortUpDown, ushort?>
{
	protected override UShortUpDown CreateEditor()
	{
		return new PropertyGridEditorUShortUpDown();
	}
}
