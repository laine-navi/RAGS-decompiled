using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class TimelinePanel : Panel, IScrollInfo
{
	private List<DateElement> _visibleElements;

	public static readonly DependencyProperty BeginDateProperty;

	public static readonly DependencyProperty EndDateProperty;

	public static readonly DependencyProperty OverlapBehaviorProperty;

	public static readonly DependencyProperty KeepOriginalOrderForOverlapProperty;

	public static readonly DependencyProperty OrientationProperty;

	public static readonly DependencyProperty UnitTimeSpanProperty;

	public static readonly DependencyProperty UnitSizeProperty;

	public static readonly DependencyProperty DateProperty;

	public static readonly DependencyProperty DateEndProperty;

	private bool _allowHorizontal;

	private bool _allowVertical;

	private Vector _computedOffset = new Vector(0.0, 0.0);

	private Size _extent = new Size(0.0, 0.0);

	private Vector _offset = new Vector(0.0, 0.0);

	private ScrollViewer _scrollOwner;

	private Size _viewport;

	private Size _physicalViewport;

	public DateTime BeginDate
	{
		get
		{
			return (DateTime)((DependencyObject)this).GetValue(BeginDateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BeginDateProperty, (object)value);
		}
	}

	public DateTime EndDate
	{
		get
		{
			return (DateTime)((DependencyObject)this).GetValue(EndDateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndDateProperty, (object)value);
		}
	}

	public OverlapBehavior OverlapBehavior
	{
		get
		{
			return (OverlapBehavior)((DependencyObject)this).GetValue(OverlapBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlapBehaviorProperty, (object)value);
		}
	}

	public bool KeepOriginalOrderForOverlap
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepOriginalOrderForOverlapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepOriginalOrderForOverlapProperty, (object)value);
		}
	}

	public Orientation Orientation
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Orientation)((DependencyObject)this).GetValue(OrientationProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	public TimeSpan UnitTimeSpan
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(UnitTimeSpanProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitTimeSpanProperty, (object)value);
		}
	}

	public double UnitSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(UnitSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitSizeProperty, (object)value);
		}
	}

	public bool CanHorizontallyScroll
	{
		get
		{
			return _allowHorizontal;
		}
		set
		{
			_allowHorizontal = value;
		}
	}

	public bool CanVerticallyScroll
	{
		get
		{
			return _allowVertical;
		}
		set
		{
			_allowVertical = value;
		}
	}

	public double ExtentHeight => _extent.Height;

	public double ExtentWidth => _extent.Width;

	public double HorizontalOffset => _offset.X;

	public ScrollViewer ScrollOwner
	{
		get
		{
			return _scrollOwner;
		}
		set
		{
			if (_scrollOwner != value)
			{
				_scrollOwner = value;
				ResetScrollInfo();
			}
		}
	}

	public double VerticalOffset => _offset.Y;

	public double ViewportHeight => _viewport.Height;

	public double ViewportWidth => _viewport.Width;

	private bool IsScrolling => _scrollOwner != null;

	public static DateTime GetDate(DependencyObject obj)
	{
		return (DateTime)obj.GetValue(DateProperty);
	}

	public static void SetDate(DependencyObject obj, DateTime value)
	{
		obj.SetValue(DateProperty, (object)value);
	}

	public static DateTime GetDateEnd(DependencyObject obj)
	{
		return (DateTime)obj.GetValue(DateEndProperty);
	}

	public static void SetDateEnd(DependencyObject obj, DateTime value)
	{
		obj.SetValue(DateEndProperty, (object)value);
	}

	static TimelinePanel()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected Obj, but got Unknown
		BeginDateProperty = DependencyProperty.Register("BeginDate", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MinValue, (FrameworkPropertyMetadataOptions)1));
		EndDateProperty = DependencyProperty.Register("EndDate", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MinValue, (FrameworkPropertyMetadataOptions)1));
		OverlapBehaviorProperty = DependencyProperty.Register("OverlapBehavior", typeof(OverlapBehavior), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)OverlapBehavior.Stack, (FrameworkPropertyMetadataOptions)1));
		KeepOriginalOrderForOverlapProperty = DependencyProperty.Register("KeepOriginalOrderForOverlap", typeof(bool), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (FrameworkPropertyMetadataOptions)1));
		OrientationProperty = StackPanel.OrientationProperty.AddOwner(typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)(Orientation)0, (FrameworkPropertyMetadataOptions)1));
		UnitTimeSpanProperty = DependencyProperty.Register("UnitTimeSpan", typeof(TimeSpan), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)TimeSpan.Zero, (FrameworkPropertyMetadataOptions)1));
		UnitSizeProperty = DependencyProperty.Register("UnitSize", typeof(double), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)0.0, (FrameworkPropertyMetadataOptions)1));
		DateProperty = DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MinValue, (FrameworkPropertyMetadataOptions)4));
		DateEndProperty = DependencyProperty.RegisterAttached("DateEnd", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MinValue, (FrameworkPropertyMetadataOptions)4));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelinePanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(TimelinePanel)));
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Invalid comparison between Unknown and I4
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		DateTime dateTime = DateTime.MaxValue;
		DateTime dateTime2 = DateTime.MinValue;
		foreach (UIElement internalChild in ((Panel)this).InternalChildren)
		{
			UIElement obj = internalChild;
			DateTime date = GetDate((DependencyObject)(object)obj);
			DateTime dateEnd = GetDateEnd((DependencyObject)(object)obj);
			if (date < dateTime)
			{
				dateTime = date;
			}
			if (date > dateTime2)
			{
				dateTime2 = date;
			}
			if (dateEnd > dateTime2)
			{
				dateTime2 = dateEnd;
			}
		}
		if (BeginDate == DateTime.MinValue)
		{
			BeginDate = dateTime;
		}
		if (EndDate == DateTime.MinValue)
		{
			EndDate = dateTime2;
		}
		foreach (UIElement internalChild2 in ((Panel)this).InternalChildren)
		{
			UIElement val = internalChild2;
			DateTime date2 = GetDate((DependencyObject)(object)val);
			DateTime dateEnd2 = GetDateEnd((DependencyObject)(object)val);
			Size val2 = availableSize;
			if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
			{
				if ((int)Orientation == 0)
				{
					if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
					{
						double num = (double)(dateEnd2.Ticks - date2.Ticks) / (double)UnitTimeSpan.Ticks;
						val2.Width = num * UnitSize;
					}
					else if (!double.IsPositiveInfinity(availableSize.Width))
					{
						val2.Width = CalculateTimelineOffset(dateEnd2, availableSize.Width) - CalculateTimelineOffset(date2, availableSize.Width);
					}
				}
				else if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
				{
					double num2 = (double)(dateEnd2.Ticks - date2.Ticks) / (double)UnitTimeSpan.Ticks;
					val2.Height = num2 * UnitSize;
				}
				else if (!double.IsPositiveInfinity(availableSize.Height))
				{
					val2.Height = CalculateTimelineOffset(dateEnd2, availableSize.Height) - CalculateTimelineOffset(date2, availableSize.Height);
				}
			}
			val.Measure(val2);
		}
		Size availableSize2 = new Size(availableSize.Width, availableSize.Height);
		if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
		{
			double num3 = (double)(EndDate.Ticks - BeginDate.Ticks) / (double)UnitTimeSpan.Ticks;
			if ((int)Orientation == 0)
			{
				availableSize2.Width = num3 * UnitSize;
			}
			else
			{
				availableSize2.Height = num3 * UnitSize;
			}
		}
		Size result = default;
		if (((int)Orientation == 1 && double.IsPositiveInfinity(availableSize2.Height)) || ((int)Orientation == 0 && double.IsPositiveInfinity(availableSize2.Width)))
		{
			_visibleElements = null;
		}
		else
		{
			LayoutItems(((Panel)this).InternalChildren, availableSize2);
			Rect val3 = default;
			foreach (DateElement visibleElement in _visibleElements)
			{
				val3.Union(visibleElement.PlacementRectangle);
			}
			if ((int)Orientation == 0)
			{
				result.Width = availableSize2.Width;
				Size size = val3.Size;
				result.Height = size.Height;
			}
			else
			{
				Size size2 = val3.Size;
				result.Width = size2.Width;
				result.Height = availableSize2.Height;
			}
		}
		if (IsScrolling)
		{
			Size viewport = new Size(availableSize.Width, availableSize.Height);
			Size extent = new Size(result.Width, result.Height);
			SetScrollingData(offset: new Vector(Math.Max(0.0, Math.Min(_offset.X, extent.Width - viewport.Width)), Math.Max(0.0, Math.Min(_offset.Y, extent.Height - viewport.Height))), viewport: viewport, extent: extent);
			result.Width = Math.Min(result.Width, availableSize.Width);
			result.Height = Math.Min(result.Height, availableSize.Height);
			_physicalViewport = availableSize;
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		Rect val = default;
		if (_visibleElements == null)
		{
			LayoutItems(((Panel)this).InternalChildren, finalSize);
		}
		foreach (DateElement visibleElement in _visibleElements)
		{
			if (IsScrolling)
			{
				Rect val2 = new Rect(visibleElement.PlacementRectangle.Location, visibleElement.PlacementRectangle.Size);
				val2.Offset(-_offset);
				visibleElement.Element.Arrange(val2);
			}
			else
			{
				visibleElement.Element.Arrange(visibleElement.PlacementRectangle);
			}
			val.Union(visibleElement.PlacementRectangle);
		}
		Size result;
		if ((int)Orientation == 0)
		{
			double width = finalSize.Width;
			Size size = val.Size;
			result = new Size(width, size.Height);
		}
		else
		{
			Size size2 = val.Size;
			result = new Size(size2.Width, finalSize.Height);
		}
		return result;
	}

	private void ResetScrollInfo()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		_offset = default;
		_physicalViewport = (_viewport = (_extent = new Size(0.0, 0.0)));
	}

	private void SetScrollingData(Size viewport, Size extent, Vector offset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		_offset = offset;
		if (!AreVirtuallyEqual(viewport, _viewport) || !AreVirtuallyEqual(extent, _extent) || !AreVirtuallyEqual(offset, _computedOffset))
		{
			_viewport = viewport;
			_extent = extent;
			_offset = offset;
			OnScrollChange();
		}
	}

	private double ValidateInputOffset(double offset, string parameterName)
	{
		if (double.IsNaN(offset))
		{
			throw new ArgumentOutOfRangeException(parameterName);
		}
		return Math.Max(0.0, offset);
	}

	private void OnScrollChange()
	{
		if (ScrollOwner != null)
		{
			ScrollOwner.InvalidateScrollInfo();
		}
	}

	private double CalculateTimelineOffset(DateTime d, double finalWidth)
	{
		long num = EndDate.Ticks - BeginDate.Ticks;
		long num2 = d.Ticks - BeginDate.Ticks;
		if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
		{
			return (double)num2 / (double)UnitTimeSpan.Ticks * UnitSize;
		}
		if (num > 0)
		{
			return (double)num2 / (double)num * finalWidth;
		}
		return 0.0;
	}

	private static int CompareElementsByLeft(DateElement a, DateElement b)
	{
		return a.PlacementRectangle.Left.CompareTo(b.PlacementRectangle.Left);
	}

	private static int CompareElementsByTop(DateElement a, DateElement b)
	{
		return a.PlacementRectangle.Top.CompareTo(b.PlacementRectangle.Top);
	}

	private void LayoutItems(UIElementCollection children, Size availableSize)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_085e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0932: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_097e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		_visibleElements = new List<DateElement>();
		List<DateElement> list = new List<DateElement>();
		int num = 0;
		foreach (UIElement child in children)
		{
			UIElement val = child;
			if (val == null)
			{
				continue;
			}
			DateTime date = GetDate((DependencyObject)(object)val);
			DateTime dateEnd = GetDateEnd((DependencyObject)(object)val);
			if ((int)val.Visibility != 2)
			{
				if (KeepOriginalOrderForOverlap)
				{
					_visibleElements.Add(new DateElement(val, date, dateEnd, num));
				}
				else
				{
					_visibleElements.Add(new DateElement(val, date, dateEnd));
				}
			}
			num++;
		}
		_visibleElements.Sort();
		foreach (DateElement visibleElement in _visibleElements)
		{
			DateTime date2 = GetDate((DependencyObject)(object)visibleElement.Element);
			DateTime dateEnd2 = GetDateEnd((DependencyObject)(object)visibleElement.Element);
			Size desiredSize;
			if ((int)Orientation == 1)
			{
				visibleElement.PlacementRectangle.Y = CalculateTimelineOffset(date2, availableSize.Height);
				if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
				{
					visibleElement.PlacementRectangle.Height = CalculateTimelineOffset(dateEnd2, availableSize.Height) - CalculateTimelineOffset(date2, availableSize.Height);
				}
				else
				{
					ref Rect placementRectangle = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					placementRectangle.Height = desiredSize.Height;
				}
				switch (OverlapBehavior)
				{
				case OverlapBehavior.None:
				{
					visibleElement.PlacementRectangle.X = 0.0;
					ref Rect placementRectangle15 = ref visibleElement.PlacementRectangle;
					Size desiredSize5 = visibleElement.Element.DesiredSize;
					placementRectangle15.Width = desiredSize5.Width;
					break;
				}
				case OverlapBehavior.Hide:
					list.Clear();
					foreach (DateElement visibleElement2 in _visibleElements)
					{
						if (visibleElement != visibleElement2)
						{
							Rect placementRectangle12 = visibleElement.PlacementRectangle;
							Rect placementRectangle13 = visibleElement2.PlacementRectangle;
							if (placementRectangle12.Top >= placementRectangle13.Top && placementRectangle12.Top < placementRectangle13.Bottom)
							{
								list.Add(visibleElement2);
							}
							continue;
						}
						break;
					}
					if (list.Count > 0)
					{
						visibleElement.PlacementRectangle.X = 0.0;
						visibleElement.PlacementRectangle.Y = 0.0;
						visibleElement.PlacementRectangle.Width = 0.0;
						visibleElement.PlacementRectangle.Height = 0.0;
					}
					else
					{
						visibleElement.PlacementRectangle.X = 0.0;
						ref Rect placementRectangle14 = ref visibleElement.PlacementRectangle;
						Size desiredSize4 = visibleElement.Element.DesiredSize;
						placementRectangle14.Width = desiredSize4.Width;
					}
					break;
				case OverlapBehavior.Stretch:
				{
					list.Clear();
					foreach (DateElement visibleElement3 in _visibleElements)
					{
						if (visibleElement != visibleElement3)
						{
							Rect placementRectangle7 = visibleElement.PlacementRectangle;
							Rect placementRectangle8 = visibleElement3.PlacementRectangle;
							if (placementRectangle7.Top >= placementRectangle8.Top && placementRectangle7.Top < placementRectangle8.Bottom)
							{
								list.Add(visibleElement3);
							}
							continue;
						}
						break;
					}
					list.Sort(CompareElementsByLeft);
					double x = 0.0;
					double num2 = availableSize.Width;
					if (list.Count > 0)
					{
						bool flag = false;
						for (int j = 0; j < list.Count; j++)
						{
							Rect placementRectangle9 = list[j].PlacementRectangle;
							if (j == 0 && placementRectangle9.Left > 0.0)
							{
								x = 0.0;
								num2 = placementRectangle9.Left;
								flag = true;
								break;
							}
							if (j == list.Count - 1)
							{
								break;
							}
							Rect placementRectangle10 = list[j + 1].PlacementRectangle;
							if (placementRectangle10.Left - placementRectangle9.Right > 0.0)
							{
								x = placementRectangle9.Right;
								num2 = placementRectangle10.Left - placementRectangle9.Right;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							num2 = Math.Min(availableSize.Width / (double)(list.Count + 1), list[0].PlacementRectangle.Width);
							x = 0.0;
							foreach (DateElement item in list)
							{
								item.PlacementRectangle.Width = num2;
								item.PlacementRectangle.X = x;
								x += num2;
							}
						}
					}
					visibleElement.PlacementRectangle.X = x;
					if (double.IsPositiveInfinity(num2))
					{
						ref Rect placementRectangle11 = ref visibleElement.PlacementRectangle;
						Size desiredSize3 = visibleElement.Element.DesiredSize;
						placementRectangle11.Width = desiredSize3.Width;
					}
					else
					{
						visibleElement.PlacementRectangle.Width = num2;
					}
					break;
				}
				case OverlapBehavior.Stack:
				{
					list.Clear();
					foreach (DateElement visibleElement4 in _visibleElements)
					{
						if (visibleElement != visibleElement4)
						{
							Rect placementRectangle2 = visibleElement.PlacementRectangle;
							Rect placementRectangle3 = visibleElement4.PlacementRectangle;
							if (placementRectangle2.Top >= placementRectangle3.Top && placementRectangle2.Top < placementRectangle3.Bottom)
							{
								list.Add(visibleElement4);
							}
							continue;
						}
						break;
					}
					list.Sort(CompareElementsByLeft);
					double x = 0.0;
					ref Rect placementRectangle4 = ref visibleElement.PlacementRectangle;
					Size desiredSize2 = visibleElement.Element.DesiredSize;
					placementRectangle4.Width = desiredSize2.Width;
					for (int i = 0; i < list.Count; i++)
					{
						Rect placementRectangle5 = list[i].PlacementRectangle;
						if (i == 0 && placementRectangle5.Left >= visibleElement.PlacementRectangle.Width)
						{
							x = 0.0;
							break;
						}
						if (i == list.Count - 1)
						{
							x = placementRectangle5.Right;
							break;
						}
						Rect placementRectangle6 = list[i + 1].PlacementRectangle;
						if (placementRectangle6.Left - placementRectangle5.Right >= visibleElement.PlacementRectangle.Width)
						{
							x = placementRectangle5.Right;
							break;
						}
					}
					visibleElement.PlacementRectangle.X = x;
					break;
				}
				}
				continue;
			}
			visibleElement.PlacementRectangle.X = CalculateTimelineOffset(date2, availableSize.Width);
			if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
			{
				visibleElement.PlacementRectangle.Width = CalculateTimelineOffset(dateEnd2, availableSize.Width) - CalculateTimelineOffset(date2, availableSize.Width);
			}
			else
			{
				ref Rect placementRectangle16 = ref visibleElement.PlacementRectangle;
				Size desiredSize6 = visibleElement.Element.DesiredSize;
				placementRectangle16.Width = desiredSize6.Width;
			}
			switch (OverlapBehavior)
			{
			case OverlapBehavior.None:
			{
				visibleElement.PlacementRectangle.Y = 0.0;
				ref Rect placementRectangle30 = ref visibleElement.PlacementRectangle;
				desiredSize = visibleElement.Element.DesiredSize;
				placementRectangle30.Height = desiredSize.Height;
				break;
			}
			case OverlapBehavior.Hide:
				list.Clear();
				foreach (DateElement visibleElement5 in _visibleElements)
				{
					if (visibleElement != visibleElement5)
					{
						Rect placementRectangle27 = visibleElement.PlacementRectangle;
						Rect placementRectangle28 = visibleElement5.PlacementRectangle;
						if (placementRectangle27.Left >= placementRectangle28.Left && placementRectangle27.Left < placementRectangle28.Right)
						{
							list.Add(visibleElement5);
						}
						continue;
					}
					break;
				}
				if (list.Count > 0)
				{
					visibleElement.PlacementRectangle.X = 0.0;
					visibleElement.PlacementRectangle.Y = 0.0;
					visibleElement.PlacementRectangle.Width = 0.0;
					visibleElement.PlacementRectangle.Height = 0.0;
				}
				else
				{
					visibleElement.PlacementRectangle.Y = 0.0;
					ref Rect placementRectangle29 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					placementRectangle29.Height = desiredSize.Height;
				}
				break;
			case OverlapBehavior.Stretch:
			{
				list.Clear();
				foreach (DateElement visibleElement6 in _visibleElements)
				{
					if (visibleElement != visibleElement6)
					{
						Rect placementRectangle22 = visibleElement.PlacementRectangle;
						Rect placementRectangle23 = visibleElement6.PlacementRectangle;
						if (placementRectangle22.Left >= placementRectangle23.Left && placementRectangle22.Left < placementRectangle23.Right)
						{
							list.Add(visibleElement6);
						}
						continue;
					}
					break;
				}
				list.Sort(CompareElementsByTop);
				double y = 0.0;
				double num3 = availableSize.Height;
				if (list.Count > 0)
				{
					bool flag2 = false;
					for (int l = 0; l < list.Count; l++)
					{
						Rect placementRectangle24 = list[l].PlacementRectangle;
						if (l == 0 && placementRectangle24.Top > 0.0)
						{
							y = 0.0;
							num3 = placementRectangle24.Top;
							flag2 = true;
							break;
						}
						if (l == list.Count - 1)
						{
							break;
						}
						Rect placementRectangle25 = list[l + 1].PlacementRectangle;
						if (placementRectangle25.Top - placementRectangle24.Bottom > 0.0)
						{
							y = placementRectangle24.Bottom;
							num3 = placementRectangle25.Top - placementRectangle24.Bottom;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						num3 = Math.Min(availableSize.Height / (double)(list.Count + 1), list[0].PlacementRectangle.Height);
						y = 0.0;
						foreach (DateElement item2 in list)
						{
							item2.PlacementRectangle.Height = num3;
							item2.PlacementRectangle.Y = y;
							y += num3;
						}
					}
				}
				visibleElement.PlacementRectangle.Y = y;
				if (double.IsPositiveInfinity(num3))
				{
					ref Rect placementRectangle26 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					placementRectangle26.Height = desiredSize.Height;
				}
				else
				{
					visibleElement.PlacementRectangle.Height = num3;
				}
				break;
			}
			case OverlapBehavior.Stack:
			{
				list.Clear();
				foreach (DateElement visibleElement7 in _visibleElements)
				{
					if (visibleElement != visibleElement7)
					{
						Rect placementRectangle17 = visibleElement.PlacementRectangle;
						Rect placementRectangle18 = visibleElement7.PlacementRectangle;
						if (placementRectangle17.Left >= placementRectangle18.Left && placementRectangle17.Left < placementRectangle18.Right)
						{
							list.Add(visibleElement7);
						}
						continue;
					}
					break;
				}
				list.Sort(CompareElementsByTop);
				double y = 0.0;
				ref Rect placementRectangle19 = ref visibleElement.PlacementRectangle;
				desiredSize = visibleElement.Element.DesiredSize;
				placementRectangle19.Height = desiredSize.Height;
				for (int k = 0; k < list.Count; k++)
				{
					Rect placementRectangle20 = list[k].PlacementRectangle;
					if (k == 0 && placementRectangle20.Top >= visibleElement.PlacementRectangle.Height)
					{
						y = 0.0;
						break;
					}
					if (k == list.Count - 1)
					{
						y = placementRectangle20.Bottom;
						break;
					}
					Rect placementRectangle21 = list[k + 1].PlacementRectangle;
					if (placementRectangle21.Top - placementRectangle20.Bottom >= visibleElement.PlacementRectangle.Height)
					{
						y = placementRectangle20.Bottom;
						break;
					}
				}
				visibleElement.PlacementRectangle.Y = y;
				break;
			}
			}
		}
	}

	private static bool AreVirtuallyEqual(double d1, double d2)
	{
		if (double.IsPositiveInfinity(d1))
		{
			return double.IsPositiveInfinity(d2);
		}
		if (double.IsNegativeInfinity(d1))
		{
			return double.IsNegativeInfinity(d2);
		}
		if (double.IsNaN(d1))
		{
			return double.IsNaN(d2);
		}
		double num = d1 - d2;
		double num2 = (Math.Abs(d1) + Math.Abs(d2) + 10.0) * 1E-15;
		if (0.0 - num2 < num)
		{
			return num2 > num;
		}
		return false;
	}

	private static bool AreVirtuallyEqual(Size s1, Size s2)
	{
		if (AreVirtuallyEqual(s1.Width, s2.Width))
		{
			return AreVirtuallyEqual(s1.Height, s2.Height);
		}
		return false;
	}

	private static bool AreVirtuallyEqual(Vector v1, Vector v2)
	{
		if (AreVirtuallyEqual(v1.X, v2.X))
		{
			return AreVirtuallyEqual(v1.Y, v2.Y);
		}
		return false;
	}

	public void LineDown()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		SetVerticalOffset(VerticalOffset + (((int)Orientation == 1) ? 1.0 : 16.0));
	}

	public void LineLeft()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		SetHorizontalOffset(HorizontalOffset - (((int)Orientation == 0) ? 1.0 : 16.0));
	}

	public void LineRight()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		SetHorizontalOffset(HorizontalOffset + (((int)Orientation == 0) ? 1.0 : 16.0));
	}

	public void LineUp()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		SetVerticalOffset(VerticalOffset - (((int)Orientation == 1) ? 1.0 : 16.0));
	}

	public Rect MakeVisible(Visual visual, Rect rectangle)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return rectangle;
	}

	public void MouseWheelDown()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		SetVerticalOffset(VerticalOffset + (double)SystemParameters.WheelScrollLines * (((int)Orientation == 1) ? 1.0 : 16.0));
	}

	public void MouseWheelLeft()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		SetHorizontalOffset(HorizontalOffset - 3.0 * (((int)Orientation == 0) ? 1.0 : 16.0));
	}

	public void MouseWheelRight()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		SetHorizontalOffset(HorizontalOffset + 3.0 * (((int)Orientation == 0) ? 1.0 : 16.0));
	}

	public void MouseWheelUp()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		SetVerticalOffset(VerticalOffset - (double)SystemParameters.WheelScrollLines * (((int)Orientation == 1) ? 1.0 : 16.0));
	}

	public void PageDown()
	{
		SetVerticalOffset(VerticalOffset + ViewportHeight);
	}

	public void PageLeft()
	{
		SetHorizontalOffset(HorizontalOffset - ViewportWidth);
	}

	public void PageRight()
	{
		SetHorizontalOffset(HorizontalOffset + ViewportWidth);
	}

	public void PageUp()
	{
		SetVerticalOffset(VerticalOffset - ViewportHeight);
	}

	public void SetHorizontalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "HorizontalOffset");
		if (!AreVirtuallyEqual(offset, _offset.X))
		{
			_offset.X = offset;
			((UIElement)this).InvalidateMeasure();
		}
	}

	public void SetVerticalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "VerticalOffset");
		if (!AreVirtuallyEqual(offset, _offset.Y))
		{
			_offset.Y = offset;
			((UIElement)this).InvalidateMeasure();
		}
	}

	public TimelinePanel()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
	}
}
