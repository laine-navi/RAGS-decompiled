using System.Windows;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

public class ContextMenuUtilities
{
	public static readonly DependencyProperty OpenOnMouseLeftButtonClickProperty = DependencyProperty.RegisterAttached("OpenOnMouseLeftButtonClick", typeof(bool), typeof(ContextMenuUtilities), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)OpenOnMouseLeftButtonClickChanged));

	public static void SetOpenOnMouseLeftButtonClick(FrameworkElement element, bool value)
	{
		((DependencyObject)element).SetValue(OpenOnMouseLeftButtonClickProperty, (object)value);
	}

	public static bool GetOpenOnMouseLeftButtonClick(FrameworkElement element)
	{
		return (bool)((DependencyObject)element).GetValue(OpenOnMouseLeftButtonClickProperty);
	}

	public static void OpenOnMouseLeftButtonClickChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		MouseButtonEventHandler val = null;
		FrameworkElement control = (FrameworkElement)sender;
		if (!(bool)e.NewValue)
		{
			return;
		}
		FrameworkElement val2 = control;
		if (val == null)
		{
			val = (object s, MouseButtonEventArgs args) =>
			{
				if (control.ContextMenu != null)
				{
					control.ContextMenu.PlacementTarget = (UIElement)(object)control;
					control.ContextMenu.IsOpen = true;
				}
			};
		}
		((UIElement)val2).PreviewMouseLeftButtonDown += val;
	}

	static ContextMenuUtilities()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
	}
}
