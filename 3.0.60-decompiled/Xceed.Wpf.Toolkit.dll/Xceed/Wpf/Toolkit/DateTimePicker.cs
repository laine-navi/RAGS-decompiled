using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Calendar", Type = typeof(Calendar))]
[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
[TemplatePart(Name = "PART_TimeUpDown", Type = typeof(TimePicker))]
public class DateTimePicker : DateTimeUpDown
{
	private const string PART_Calendar = "PART_Calendar";

	private const string PART_Popup = "PART_Popup";

	private const string PART_TimeUpDown = "PART_TimeUpDown";

	private Calendar _calendar;

	private Popup _popup;

	private DateTime? _initialValue;

	private TimePicker _timePicker;

	public static readonly DependencyProperty AutoCloseCalendarProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty TimeFormatProperty;

	public static readonly DependencyProperty TimeFormatStringProperty;

	public static readonly DependencyProperty TimeWatermarkProperty;

	public static readonly DependencyProperty TimeWatermarkTemplateProperty;

	public bool AutoCloseCalendar
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoCloseCalendarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoCloseCalendarProperty, (object)value);
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

	public TimeFormat TimeFormat
	{
		get
		{
			return (TimeFormat)((DependencyObject)this).GetValue(TimeFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeFormatProperty, (object)value);
		}
	}

	public string TimeFormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TimeFormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeFormatStringProperty, (object)value);
		}
	}

	public object TimeWatermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(TimeWatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeWatermarkProperty, value);
		}
	}

	public DataTemplate TimeWatermarkTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(TimeWatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeWatermarkTemplateProperty, (object)value);
		}
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DateTimePicker)(object)d)?.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
	}

	private void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue = Value;
		}
	}

	private static bool IsTimeFormatStringValid(object value)
	{
		return DateTimeUpDown.IsFormatStringValid(value);
	}

	static DateTimePicker()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		AutoCloseCalendarProperty = DependencyProperty.Register("AutoCloseCalendar", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsOpenChanged));
		TimeFormatProperty = DependencyProperty.Register("TimeFormat", typeof(TimeFormat), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((object)TimeFormat.ShortTime));
		TimeFormatStringProperty = DependencyProperty.Register("TimeFormatString", typeof(string), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((object)null), (ValidateValueCallback)IsTimeFormatStringValid);
		TimeWatermarkProperty = DependencyProperty.Register("TimeWatermark", typeof(object), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		TimeWatermarkTemplateProperty = DependencyProperty.Register("TimeWatermarkTemplate", typeof(DataTemplate), typeof(DateTimePicker), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimePicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(DateTimePicker)));
	}

	public DateTimePicker()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		((UIElement)this).AddHandler(UIElement.KeyDownEvent, (Delegate)new KeyEventHandler(OnKeyDown), true);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
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
		if (_calendar != null)
		{
			_calendar.SelectedDatesChanged -= Calendar_SelectedDatesChanged;
		}
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_Calendar");
		_calendar = (Calendar)(object)((templateChild2 is Calendar) ? templateChild2 : null);
		if (_calendar != null)
		{
			_calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
			Calendar calendar = _calendar;
			DateTime? value = Value;
			calendar.SelectedDate = value;
			_calendar.DisplayDate = Value ?? DateTime.Now;
		}
		_timePicker = ((FrameworkElement)this).GetTemplateChild("PART_TimeUpDown") as TimePicker;
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (Mouse.Captured is CalendarItem)
		{
			Mouse.Capture((IInputElement)null);
			if (AutoCloseCalendar && (int)_calendar.DisplayMode == 0)
			{
				CloseDateTimePicker(isFocusOnTextBox: true);
			}
		}
	}

	protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		if (_calendar != null && _calendar.SelectedDate != newValue)
		{
			_calendar.SelectedDate = newValue;
			_calendar.DisplayDate = newValue ?? DateTime.Now;
		}
		base.OnValueChanged(oldValue, newValue);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (!IsOpen)
		{
			base.OnPreviewKeyDown(e);
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				((RoutedEventArgs)e).Handled = true;
			}
		}
		else if (((UIElement)_calendar).IsKeyboardFocusWithin)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				CloseDateTimePicker(isFocusOnTextBox: true);
				((RoutedEventArgs)e).Handled = true;
			}
			else
			{
				ManageEnterEscapeKeys(e);
			}
		}
		else if (((UIElement)_timePicker).IsKeyboardFocusWithin && !_timePicker.IsOpen && !((RoutedEventArgs)e).Handled)
		{
			ManageEnterEscapeKeys(e);
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseDateTimePicker(isFocusOnTextBox: false);
	}

	private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count > 0)
		{
			DateTime? dateTime = (DateTime?)e.AddedItems[0];
			if (Value.HasValue && dateTime.HasValue && dateTime.HasValue)
			{
				dateTime = dateTime.Value.Date + Value.Value.TimeOfDay;
			}
			if (!object.Equals(dateTime, Value))
			{
				Value = dateTime;
			}
		}
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		if (_calendar != null)
		{
			((UIElement)_calendar).Focus();
		}
	}

	private void CloseDateTimePicker(bool isFocusOnTextBox)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
		if (isFocusOnTextBox && TextBox != null)
		{
			((UIElement)TextBox).Focus();
		}
	}

	private void ManageEnterEscapeKeys(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			CloseDateTimePicker(isFocusOnTextBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			if (!object.Equals(Value, _initialValue))
			{
				Value = _initialValue;
			}
			CloseDateTimePicker(isFocusOnTextBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}
}
