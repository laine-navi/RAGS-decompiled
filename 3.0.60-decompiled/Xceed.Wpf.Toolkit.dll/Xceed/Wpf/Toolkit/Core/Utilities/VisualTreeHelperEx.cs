using System;
using System.Windows;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

public static class VisualTreeHelperEx
{
	public static DependencyObject FindAncestorByType(DependencyObject element, Type type, bool specificTypeOnly)
	{
		if (element == null)
		{
			return null;
		}
		bool num;
		if (!specificTypeOnly)
		{
			if (((object)element).GetType() == type)
			{
				goto IL_0035;
			}
			num = ((object)element).GetType().IsSubclassOf(type);
		}
		else
		{
			num = ((object)element).GetType() == type;
		}
		if (!num)
		{
			return FindAncestorByType(VisualTreeHelper.GetParent(element), type, specificTypeOnly);
		}
		goto IL_0035;
		IL_0035:
		return element;
	}

	public static T FindAncestorByType<T>(DependencyObject depObj) where T : DependencyObject
	{
		if (depObj == null)
		{
			return default;
		}
		if (depObj is T)
		{
			return (T)(object)depObj;
		}
		T val = default;
		return FindAncestorByType<T>(VisualTreeHelper.GetParent(depObj));
	}

	public static Visual FindDescendantByName(Visual element, string name)
	{
		if (element != null && element is FrameworkElement && ((FrameworkElement)((element is FrameworkElement) ? element : null)).Name == name)
		{
			return element;
		}
		Visual val = null;
		if (element is FrameworkElement)
		{
			((FrameworkElement)((element is FrameworkElement) ? element : null)).ApplyTemplate();
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)element, i);
			Visual element2 = (Visual)(object)((child is Visual) ? child : null);
			val = FindDescendantByName(element2, name);
			if (val != null)
			{
				break;
			}
		}
		return val;
	}

	public static Visual FindDescendantByType(Visual element, Type type)
	{
		return FindDescendantByType(element, type, specificTypeOnly: true);
	}

	public static Visual FindDescendantByType(Visual element, Type type, bool specificTypeOnly)
	{
		if (element == null)
		{
			return null;
		}
		bool num;
		if (!specificTypeOnly)
		{
			if (((object)element).GetType() == type)
			{
				goto IL_0035;
			}
			num = ((object)element).GetType().IsSubclassOf(type);
		}
		else
		{
			num = ((object)element).GetType() == type;
		}
		if (!num)
		{
			Visual val = null;
			if (element is FrameworkElement)
			{
				((FrameworkElement)((element is FrameworkElement) ? element : null)).ApplyTemplate();
			}
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)element, i);
				Visual element2 = (Visual)(object)((child is Visual) ? child : null);
				val = FindDescendantByType(element2, type, specificTypeOnly);
				if (val != null)
				{
					break;
				}
			}
			return val;
		}
		goto IL_0035;
		IL_0035:
		return element;
	}

	public static T FindDescendantByType<T>(Visual element) where T : Visual
	{
		Visual val = FindDescendantByType(element, typeof(T));
		return (T)(object)val;
	}

	public static Visual FindDescendantWithPropertyValue(Visual element, DependencyProperty dp, object value)
	{
		if (element == null)
		{
			return null;
		}
		if (((DependencyObject)element).GetValue(dp).Equals(value))
		{
			return element;
		}
		Visual val = null;
		if (element is FrameworkElement)
		{
			((FrameworkElement)((element is FrameworkElement) ? element : null)).ApplyTemplate();
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)element, i);
			Visual element2 = (Visual)(object)((child is Visual) ? child : null);
			val = FindDescendantWithPropertyValue(element2, dp, value);
			if (val != null)
			{
				break;
			}
		}
		return val;
	}
}
