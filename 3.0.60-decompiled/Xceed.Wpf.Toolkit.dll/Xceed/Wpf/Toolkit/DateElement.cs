using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit;

internal sealed class DateElement : IComparable<DateElement>
{
	private readonly int _originalIndex;

	public readonly UIElement Element;

	public readonly DateTime Date;

	public readonly DateTime DateEnd;

	public Rect PlacementRectangle;

	public int Column;

	public int ColumnSpan = 1;

	internal DateElement(UIElement element, DateTime date, DateTime dateEnd)
		: this(element, date, dateEnd, -1)
	{
	}

	internal DateElement(UIElement element, DateTime date, DateTime dateEnd, int originalIndex)
	{
		Element = element;
		Date = date;
		DateEnd = dateEnd;
		_originalIndex = originalIndex;
	}

	public override string ToString()
	{
		UIElement element = Element;
		FrameworkElement val = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
		if (val == null)
		{
			return base.ToString();
		}
		if (val.Tag != null)
		{
			return val.Tag.ToString();
		}
		return val.Name;
	}

	public int CompareTo(DateElement d)
	{
		DateTime date = Date;
		int num = date.CompareTo(d.Date);
		if (num != 0)
		{
			return num;
		}
		if (_originalIndex >= 0)
		{
			if (_originalIndex >= d._originalIndex)
			{
				return 1;
			}
			return -1;
		}
		DateTime dateEnd = DateEnd;
		return -dateEnd.CompareTo(d.DateEnd);
	}
}
