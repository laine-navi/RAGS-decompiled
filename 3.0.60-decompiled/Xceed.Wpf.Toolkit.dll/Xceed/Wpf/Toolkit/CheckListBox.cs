using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class CheckListBox : Selector
{
	static CheckListBox()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckListBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(CheckListBox)));
	}
}
