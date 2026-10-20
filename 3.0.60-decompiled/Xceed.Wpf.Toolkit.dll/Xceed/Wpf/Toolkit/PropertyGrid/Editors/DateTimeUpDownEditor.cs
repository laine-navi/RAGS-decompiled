using System;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class DateTimeUpDownEditor : UpDownEditor<DateTimeUpDown, DateTime?>
{
	protected override DateTimeUpDown CreateEditor()
	{
		return new PropertyGridEditorDateTimeUpDown();
	}
}
