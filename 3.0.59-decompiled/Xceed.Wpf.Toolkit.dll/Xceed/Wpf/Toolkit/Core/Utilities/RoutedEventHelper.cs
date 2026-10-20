using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal static class RoutedEventHelper
{
	internal static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
	{
		if (target is UIElement)
		{
			((UIElement)((target is UIElement) ? target : null)).RaiseEvent(args);
		}
		else if (target is ContentElement)
		{
			((ContentElement)((target is ContentElement) ? target : null)).RaiseEvent(args);
		}
	}

	internal static void AddHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
	{
		UIElement val = (UIElement)(object)((element is UIElement) ? element : null);
		if (val != null)
		{
			val.AddHandler(routedEvent, handler);
			return;
		}
		ContentElement val2 = (ContentElement)(object)((element is ContentElement) ? element : null);
		if (val2 != null)
		{
			val2.AddHandler(routedEvent, handler);
		}
	}

	internal static void RemoveHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
	{
		UIElement val = (UIElement)(object)((element is UIElement) ? element : null);
		if (val != null)
		{
			val.RemoveHandler(routedEvent, handler);
			return;
		}
		ContentElement val2 = (ContentElement)(object)((element is ContentElement) ? element : null);
		if (val2 != null)
		{
			val2.RemoveHandler(routedEvent, handler);
		}
	}
}
