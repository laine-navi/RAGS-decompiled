using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_TimeListItems", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public class TimePicker : Control
{
	private const string PART_TimeListItems = "PART_TimeListItems";

	private const string PART_Popup = "PART_Popup";

	private ListBox _timeListBox;

	private Popup _popup;

	private DateTime? _initialValue;

	internal static readonly TimeSpan EndTimeDefaultValue;

	internal static readonly TimeSpan StartTimeDefaultValue;

	internal static readonly TimeSpan TimeIntervalDefaultValue;

	public static readonly DependencyProperty AllowSpinProperty;

	public static readonly DependencyProperty ClipValueToMinMaxProperty;

	public static readonly DependencyProperty EndTimeProperty;

	public static readonly DependencyProperty FormatProperty;

	public static readonly DependencyProperty FormatStringProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty MaximumProperty;

	public static readonly DependencyProperty MinimumProperty;

	public static readonly DependencyProperty ShowButtonSpinnerProperty;

	public static readonly DependencyProperty StartTimeProperty;

	public static readonly DependencyProperty TextAlignmentProperty;

	public static readonly DependencyProperty TimeIntervalProperty;

	public static readonly DependencyProperty ValueProperty;

	public static readonly DependencyProperty WatermarkProperty;

	public static readonly DependencyProperty WatermarkTemplateProperty;

	public static readonly RoutedEvent ValueChangedEvent;

	private DateTimeFormatInfo DateTimeFormatInfo { get; set; }

	public bool AllowSpin
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSpinProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSpinProperty, (object)value);
		}
	}

	public bool ClipValueToMinMax
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClipValueToMinMaxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipValueToMinMaxProperty, (object)value);
		}
	}

	public TimeSpan EndTime
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(EndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndTimeProperty, (object)value);
		}
	}

	public TimeFormat Format
	{
		get
		{
			return (TimeFormat)((DependencyObject)this).GetValue(FormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatProperty, (object)value);
		}
	}

	public string FormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatStringProperty, (object)value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public DateTime? Maximum
	{
		get
		{
			return (DateTime?)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public DateTime? Minimum
	{
		get
		{
			return (DateTime?)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public bool ShowButtonSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowButtonSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowButtonSpinnerProperty, (object)value);
		}
	}

	public TimeSpan StartTime
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(StartTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartTimeProperty, (object)value);
		}
	}

	public TextAlignment TextAlignment
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (TextAlignment)((DependencyObject)this).GetValue(TextAlignmentProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(TextAlignmentProperty, (object)value);
		}
	}

	public TimeSpan TimeInterval
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(TimeIntervalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeIntervalProperty, (object)value);
		}
	}

	public DateTime? Value
	{
		get
		{
			return (DateTime?)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public object Watermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(WatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkProperty, value);
		}
	}

	public DataTemplate WatermarkTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(WatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkTemplateProperty, (object)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<object> ValueChanged
	{
		add
		{
			((UIElement)this).AddHandler(ValueChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ValueChangedEvent, (Delegate)(object)value);
		}
	}

	private static object OnCoerceEndTime(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceEndTime((TimeSpan)value);
		}
		return value;
	}

	private static void OnEndTimeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnEndTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceEndTime(TimeSpan value)
	{
		ValidateTime(value);
		return value;
	}

	protected virtual void OnEndTimeChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		UpdateListBoxItems();
	}

	private static void OnFormatChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnFormatChanged((TimeFormat)e.OldValue, (TimeFormat)e.NewValue);
		}
	}

	protected virtual void OnFormatChanged(TimeFormat oldValue, TimeFormat newValue)
	{
		UpdateListBoxItems();
	}

	internal static bool IsFormatStringValid(object value)
	{
		return DateTimeUpDown.IsFormatStringValid(value);
	}

	private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnFormatStringChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnFormatStringChanged(string oldValue, string newValue)
	{
		if (Format == TimeFormat.Custom)
		{
			UpdateListBoxItems();
		}
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TimePicker)(object)d)?.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
	}

	private void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue = Value;
		}
	}

	private static object OnCoerceStartTime(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceStartTime((TimeSpan)value);
		}
		return value;
	}

	private static void OnStartTimeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnStartTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceStartTime(TimeSpan value)
	{
		ValidateTime(value);
		return value;
	}

	protected virtual void OnStartTimeChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		UpdateListBoxItems();
	}

	private static object OnCoerceTimeInterval(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceTimeInterval((TimeSpan)value);
		}
		return value;
	}

	private static void OnTimeIntervalChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnTimeIntervalChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceTimeInterval(TimeSpan value)
	{
		ValidateTime(value);
		if (value.Ticks == 0)
		{
			throw new ArgumentException("TimeInterval must be greater than zero");
		}
		return value;
	}

	protected virtual void OnTimeIntervalChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		UpdateListBoxItems();
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnValueChanged((DateTime?)e.OldValue, (DateTime?)e.NewValue);
		}
	}

	protected virtual void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		UpdateListBoxSelectedItem();
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>((object)oldValue, (object)newValue);
		((RoutedEventArgs)e).RoutedEvent = ValueChangedEvent;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
	}

	static TimePicker()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		//IL_0145: Expected Obj, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected Obj, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected Obj, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected Obj, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected Obj, but got Unknown
		//IL_0256: Expected Obj, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected Obj, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected Obj, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Obj, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Obj, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected Obj, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected Obj, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected Obj, but got Unknown
		EndTimeDefaultValue = new TimeSpan(23, 59, 0);
		StartTimeDefaultValue = new TimeSpan(0, 0, 0);
		TimeIntervalDefaultValue = new TimeSpan(1, 0, 0);
		AllowSpinProperty = DependencyProperty.Register("AllowSpin", typeof(bool), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ClipValueToMinMaxProperty = DependencyProperty.Register("ClipValueToMinMax", typeof(bool), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)false));
		EndTimeProperty = DependencyProperty.Register("EndTime", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)EndTimeDefaultValue, (PropertyChangedCallback)OnEndTimeChanged, (CoerceValueCallback)OnCoerceEndTime));
		FormatProperty = DependencyProperty.Register("Format", typeof(TimeFormat), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)TimeFormat.ShortTime, (PropertyChangedCallback)OnFormatChanged));
		FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnFormatStringChanged), (ValidateValueCallback)IsFormatStringValid);
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsOpenChanged));
		MaximumProperty = DependencyProperty.Register("Maximum", typeof(DateTime?), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)DateTime.MaxValue));
		MinimumProperty = DependencyProperty.Register("Minimum", typeof(DateTime?), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)DateTime.MinValue));
		ShowButtonSpinnerProperty = DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		StartTimeProperty = DependencyProperty.Register("StartTime", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)StartTimeDefaultValue, (PropertyChangedCallback)OnStartTimeChanged, (CoerceValueCallback)OnCoerceStartTime));
		TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)(TextAlignment)0));
		TimeIntervalProperty = DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((object)TimeIntervalDefaultValue, (PropertyChangedCallback)OnTimeIntervalChanged));
		ValueProperty = DependencyProperty.Register("Value", typeof(DateTime?), typeof(TimePicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnValueChanged));
		WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(TimePicker), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<object>), typeof(TimePicker));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(TimePicker)));
	}

	public TimePicker()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		DateTimeFormatInfo = DateTimeFormatInfo.GetInstance(CultureInfo.CurrentCulture);
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_Popup");
		_popup = (Popup)(object)((templateChild is Popup) ? templateChild : null);
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
		if (_timeListBox != null)
		{
			((Selector)_timeListBox).SelectionChanged -= TimeListBox_SelectionChanged;
			((UIElement)_timeListBox).MouseUp -= TimeListBox_MouseUp;
		}
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_TimeListItems");
		_timeListBox = (ListBox)(object)((templateChild2 is ListBox) ? templateChild2 : null);
		if (_timeListBox != null)
		{
			((Selector)_timeListBox).SelectionChanged += TimeListBox_SelectionChanged;
			((UIElement)_timeListBox).MouseUp += TimeListBox_MouseUp;
			UpdateListBoxItems();
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				((RoutedEventArgs)e).Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseTimePicker(isFocusOnTimePicker: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 6)
		{
			CloseTimePicker(isFocusOnTimePicker: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			Value = _initialValue;
			CloseTimePicker(isFocusOnTimePicker: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseTimePicker(isFocusOnTimePicker: false);
	}

	private void TimeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count > 0)
		{
			TimeItem timeItem = (TimeItem)e.AddedItems[0];
			TimeSpan time = timeItem.Time;
			DateTime dateTime = Value ?? DateTime.MinValue;
			Value = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
		}
	}

	private void TimeListBox_MouseUp(object sender, MouseButtonEventArgs e)
	{
		CloseTimePicker(isFocusOnTimePicker: true);
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		if (_timeListBox == null)
		{
			return;
		}
		TimeSpan time = (Value.HasValue ? Value.Value.TimeOfDay : StartTimeDefaultValue);
		TimeItem nearestTimeItem = GetNearestTimeItem(time);
		if (nearestTimeItem != null)
		{
			_timeListBox.ScrollIntoView((object)nearestTimeItem);
			ListBoxItem val = (ListBoxItem)((ItemsControl)_timeListBox).ItemContainerGenerator.ContainerFromItem((object)nearestTimeItem);
			if (val != null)
			{
				((UIElement)val).Focus();
			}
		}
	}

	private void ValidateTime(TimeSpan time)
	{
		if (time.TotalHours >= 24.0)
		{
			throw new ArgumentException("Time value cannot be greater than or equal to 24 hours.");
		}
	}

	private void CloseTimePicker(bool isFocusOnTimePicker)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
		if (isFocusOnTimePicker)
		{
			((UIElement)this).Focus();
		}
	}

	public IEnumerable GenerateTimeListItemsSource()
	{
		TimeSpan timeSpan = StartTime;
		TimeSpan timeSpan2 = EndTime;
		if (timeSpan2 <= timeSpan)
		{
			timeSpan2 = EndTimeDefaultValue;
			timeSpan = StartTimeDefaultValue;
		}
		TimeSpan timeInterval = TimeInterval;
		List<TimeItem> list = new List<TimeItem>();
		if (timeInterval.Ticks > 0)
		{
			while (timeSpan <= timeSpan2)
			{
				list.Add(CreateTimeItem(timeSpan));
				timeSpan = timeSpan.Add(timeInterval);
			}
		}
		return list;
	}

	private TimeItem CreateTimeItem(TimeSpan time)
	{
		DateTime minValue = DateTime.MinValue;
		return new TimeItem(minValue.Add(time).ToString(GetTimeFormat(), CultureInfo.CurrentCulture), time);
	}

	private string GetTimeFormat()
	{
		return Format switch
		{
			TimeFormat.Custom => FormatString, 
			TimeFormat.LongTime => DateTimeFormatInfo.LongTimePattern, 
			TimeFormat.ShortTime => DateTimeFormatInfo.ShortTimePattern, 
			_ => DateTimeFormatInfo.ShortTimePattern, 
		};
	}

	private void UpdateListBoxSelectedItem()
	{
		if (_timeListBox == null)
		{
			return;
		}
		TimeItem timeItem = null;
		if (Value.HasValue)
		{
			timeItem = CreateTimeItem(Value.Value.TimeOfDay);
			if (!((CollectionView)((ItemsControl)_timeListBox).Items).Contains((object)timeItem))
			{
				timeItem = null;
			}
		}
		((Selector)_timeListBox).SelectedItem = timeItem;
	}

	private void UpdateListBoxItems()
	{
		if (_timeListBox != null)
		{
			((ItemsControl)_timeListBox).ItemsSource = GenerateTimeListItemsSource();
		}
	}

	private TimeItem GetNearestTimeItem(TimeSpan time)
	{
		if (_timeListBox != null)
		{
			int count = ((CollectionView)((ItemsControl)_timeListBox).Items).Count;
			for (int i = 0; i < count; i++)
			{
				if (((ItemsControl)_timeListBox).Items[i] is TimeItem timeItem && timeItem.Time >= time)
				{
					return timeItem;
				}
			}
			if (count > 0)
			{
				return ((ItemsControl)_timeListBox).Items[count - 1] as TimeItem;
			}
		}
		return null;
	}
}
