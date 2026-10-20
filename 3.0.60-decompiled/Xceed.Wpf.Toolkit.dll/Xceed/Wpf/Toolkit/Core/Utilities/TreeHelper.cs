using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal static class TreeHelper
{
	public static DependencyObject GetParent(DependencyObject element)
	{
		return GetParent(element, recurseIntoPopup: true);
	}

	private static DependencyObject GetParent(DependencyObject element, bool recurseIntoPopup)
	{
		if (recurseIntoPopup)
		{
			Popup val = (Popup)(object)((element is Popup) ? element : null);
			if (val != null && val.PlacementTarget != null)
			{
				return (DependencyObject)(object)val.PlacementTarget;
			}
		}
		Visual val2 = (Visual)(object)((element is Visual) ? element : null);
		DependencyObject val3 = ((val2 == null) ? null : VisualTreeHelper.GetParent((DependencyObject)(object)val2));
		if (val3 == null)
		{
			FrameworkElement val4 = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
			if (val4 != null)
			{
				val3 = val4.Parent;
				if (val3 == null)
				{
					val3 = val4.TemplatedParent;
				}
			}
			else
			{
				FrameworkContentElement val5 = (FrameworkContentElement)(object)((element is FrameworkContentElement) ? element : null);
				if (val5 != null)
				{
					val3 = val5.Parent;
					if (val3 == null)
					{
						val3 = val5.TemplatedParent;
					}
				}
			}
		}
		return val3;
	}

	public static T FindParent<T>(DependencyObject startingObject) where T : DependencyObject
	{
		return FindParent<T>(startingObject, checkStartingObject: false, null);
	}

	public static T FindParent<T>(DependencyObject startingObject, bool checkStartingObject) where T : DependencyObject
	{
		return FindParent<T>(startingObject, checkStartingObject, null);
	}

	public static T FindParent<T>(DependencyObject startingObject, bool checkStartingObject, Func<T, bool> additionalCheck) where T : DependencyObject
	{
		for (DependencyObject val = (checkStartingObject ? startingObject : GetParent(startingObject, recurseIntoPopup: true)); val != null; val = GetParent(val, recurseIntoPopup: true))
		{
			T val2 = (T)(object)((val is T) ? val : null);
			if (val2 != null)
			{
				if (additionalCheck == null)
				{
					return val2;
				}
				if (additionalCheck(val2))
				{
					return val2;
				}
			}
		}
		return default;
	}

	public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
	{
		return FindChild<T>(parent, null);
	}

	public static T FindChild<T>(DependencyObject parent, Func<T, bool> additionalCheck) where T : DependencyObject
	{
		int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
		for (int i = 0; i < childrenCount; i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(parent, i);
			T val = (T)(object)((child is T) ? child : null);
			if (val != null)
			{
				if (additionalCheck == null)
				{
					return val;
				}
				if (additionalCheck(val))
				{
					return val;
				}
			}
		}
		for (int j = 0; j < childrenCount; j++)
		{
			T val = FindChild(VisualTreeHelper.GetChild(parent, j), additionalCheck);
			if (val != null)
			{
				return val;
			}
		}
		return default;
	}

	public static bool IsDescendantOf(DependencyObject element, DependencyObject parent)
	{
		return IsDescendantOf(element, parent, recurseIntoPopup: true);
	}

	public static bool IsDescendantOf(DependencyObject element, DependencyObject parent, bool recurseIntoPopup)
	{
		while (element != null)
		{
			if (element == parent)
			{
				return true;
			}
			element = GetParent(element, recurseIntoPopup);
		}
		return false;
	}
}
