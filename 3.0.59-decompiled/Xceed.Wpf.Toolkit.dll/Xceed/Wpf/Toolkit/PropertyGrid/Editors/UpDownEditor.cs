using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class UpDownEditor<TEditor, TType> : TypeEditor<TEditor> where TEditor : UpDownBase<TType>, new()
{
	protected override void SetControlProperties()
	{
		TEditor editor = Editor;
		editor.TextAlignment = (TextAlignment)0;
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = UpDownBase<TType>.ValueProperty;
	}
}
