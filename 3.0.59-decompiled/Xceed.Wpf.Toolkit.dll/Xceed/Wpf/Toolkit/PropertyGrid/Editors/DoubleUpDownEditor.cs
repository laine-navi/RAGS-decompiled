namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class DoubleUpDownEditor : UpDownEditor<DoubleUpDown, double?>
{
	protected override DoubleUpDown CreateEditor()
	{
		return new PropertyGridEditorDoubleUpDown();
	}

	protected override void SetControlProperties()
	{
		base.SetControlProperties();
		Editor.AllowInputSpecialValues = AllowedSpecialValues.Any;
	}
}
