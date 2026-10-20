using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ActionButton", Type = typeof(Button))]
public class SplitButton : DropDownButton
{
	private const string PART_ActionButton = "PART_ActionButton";

	static SplitButton()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButton), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(SplitButton)));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_ActionButton");
		Button = (ButtonBase)(object)((templateChild is Button) ? templateChild : null);
	}
}
