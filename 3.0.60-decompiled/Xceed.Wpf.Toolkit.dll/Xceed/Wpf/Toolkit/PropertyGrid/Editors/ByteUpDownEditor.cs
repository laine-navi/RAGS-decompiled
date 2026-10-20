namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ByteUpDownEditor : UpDownEditor<ByteUpDown, byte?>
{
	protected override ByteUpDown CreateEditor()
	{
		return new PropertyGridEditorByteUpDown();
	}
}
