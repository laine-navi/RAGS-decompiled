using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public static class SwitchTemplate
{
	public static readonly DependencyProperty IDProperty = DependencyProperty.RegisterAttached("ID", typeof(string), typeof(SwitchTemplate), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnIDChanged));

	public static string GetID(DependencyObject d)
	{
		return (string)d.GetValue(IDProperty);
	}

	public static void SetID(DependencyObject d, string value)
	{
		d.SetValue(IDProperty, (object)value);
	}

	private static void OnIDChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (e.NewValue == null || !(d is UIElement))
		{
			return;
		}
		SwitchPresenter parentPresenter = VisualTreeHelperEx.FindAncestorByType<SwitchPresenter>(d);
		if (parentPresenter != null)
		{
			SwitchPresenter switchPresenter = parentPresenter;
			string id = e.NewValue as string;
			DependencyObject val = d;
			switchPresenter.RegisterID(id, (FrameworkElement)(object)((val is FrameworkElement) ? val : null));
			return;
		}
		((DispatcherObject)d).Dispatcher.BeginInvoke((DispatcherPriority)6, (Delegate)(ThreadStart)(() =>
		{
			parentPresenter = VisualTreeHelperEx.FindAncestorByType<SwitchPresenter>(d);
			if (parentPresenter != null)
			{
				SwitchPresenter switchPresenter2 = parentPresenter;
				string id2 = e.NewValue as string;
				DependencyObject val2 = d;
				switchPresenter2.RegisterID(id2, (FrameworkElement)(object)((val2 is FrameworkElement) ? val2 : null));
			}
		}));
	}

	static SwitchTemplate()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
	}
}
