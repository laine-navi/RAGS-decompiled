using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class TextBlockEditor : TypeEditor<TextBlock>
{
	protected override TextBlock CreateEditor()
	{
		return (TextBlock)(object)new PropertyGridEditorTextBlock();
	}

	protected override void SetValueDependencyProperty()
	{
		ValueProperty = TextBlock.TextProperty;
	}

	protected override void SetControlProperties()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)Editor).Margin = new Thickness(5.0, 0.0, 0.0, 0.0);
	}
}
