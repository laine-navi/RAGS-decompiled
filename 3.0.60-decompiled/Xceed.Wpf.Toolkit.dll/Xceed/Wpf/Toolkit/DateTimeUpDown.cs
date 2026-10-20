using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class DateTimeUpDown : UpDownBase<DateTime?>
{
	private List<DateTimeInfo> _dateTimeInfoList = new List<DateTimeInfo>();

	private DateTimeInfo _selectedDateTimeInfo;

	private bool _fireSelectionChangedEvent = true;

	private bool _processTextChanged = true;

	public static readonly DependencyProperty FormatProperty;

	public static readonly DependencyProperty FormatStringProperty;

	public DateTimeFormat Format
	{
		get
		{
			return (DateTimeFormat)((DependencyObject)this).GetValue(FormatProperty);
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

	private static void OnFormatChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDown dateTimeUpDown)
		{
			dateTimeUpDown.OnFormatChanged((DateTimeFormat)e.OldValue, (DateTimeFormat)e.NewValue);
		}
	}

	protected virtual void OnFormatChanged(DateTimeFormat oldValue, DateTimeFormat newValue)
	{
		FormatUpdated();
	}

	internal static bool IsFormatStringValid(object value)
	{
		try
		{
			DateTime minValue = DateTime.MinValue;
			minValue.ToString((string)value, CultureInfo.CurrentCulture);
		}
		catch
		{
			return false;
		}
		return true;
	}

	private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDown dateTimeUpDown)
		{
			dateTimeUpDown.OnFormatStringChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnFormatStringChanged(string oldValue, string newValue)
	{
		FormatUpdated();
	}

	static DateTimeUpDown()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_0076: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		FormatProperty = DependencyProperty.Register("Format", typeof(DateTimeFormat), typeof(DateTimeUpDown), (PropertyMetadata)new UIPropertyMetadata((object)DateTimeFormat.FullDateTime, (PropertyChangedCallback)OnFormatChanged));
		FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(DateTimeUpDown), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnFormatStringChanged), (ValidateValueCallback)IsFormatStringValid);
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(DateTimeUpDown)));
		UpDownBase<DateTime?>.MaximumProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MaxValue));
		UpDownBase<DateTime?>.MinimumProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)DateTime.MinValue));
	}

	public DateTimeUpDown()
	{
		InitializeDateTimeInfoList();
	}

	public override void OnApplyTemplate()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		if (TextBox != null)
		{
			((TextBoxBase)TextBox).SelectionChanged -= TextBox_SelectionChanged;
			((UIElement)TextBox).GotFocus -= TextBox_GotFocus;
		}
		base.OnApplyTemplate();
		if (TextBox != null)
		{
			((TextBoxBase)TextBox).SelectionChanged += TextBox_SelectionChanged;
			((UIElement)TextBox).GotFocus += TextBox_GotFocus;
		}
	}

	protected override void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
		FormatUpdated();
	}

	protected override void OnIncrement()
	{
		if (IsCurrentValueValid())
		{
			if (Value.HasValue)
			{
				UpdateDateTime(1);
			}
			else
			{
				Value = DefaultValue ?? DateTime.Now;
			}
		}
	}

	protected override void OnDecrement()
	{
		if (IsCurrentValueValid())
		{
			if (Value.HasValue)
			{
				UpdateDateTime(-1);
			}
			else
			{
				Value = DefaultValue ?? DateTime.Now;
			}
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I4, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected I4, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected I4, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Invalid comparison between Unknown and I4
		int num = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0);
		int num2 = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.Length : 0);
		Key key = e.Key;
		if ((int)key <= 25)
		{
			if ((int)key != 6)
			{
				switch (key - 23)
				{
				case 2:
					break;
				case 0:
					goto IL_016c;
				default:
					goto IL_0194;
				}
				goto IL_014b;
			}
			if (!IsReadOnly)
			{
				_fireSelectionChangedEvent = false;
				BindingExpression bindingExpression = BindingOperations.GetBindingExpression((DependencyObject)(object)TextBox, TextBox.TextProperty);
				((BindingExpressionBase)bindingExpression).UpdateSource();
				_fireSelectionChangedEvent = true;
			}
			return;
		}
		switch (key - 85)
		{
		case 0:
			goto IL_00d3;
		case 2:
			goto IL_00fc;
		case 3:
		case 4:
			goto IL_014b;
		case 1:
			goto IL_0194;
		}
		switch (key - 140)
		{
		default:
			if ((int)key == 152)
			{
				goto IL_014b;
			}
			goto IL_0194;
		case 0:
			break;
		case 2:
		case 3:
		case 4:
			goto IL_014b;
		case 1:
			goto IL_0194;
		}
		if (IsCurrentValueValid() && (int)Keyboard.Modifiers == 4)
		{
			PerformKeyboardSelection(num + num2);
			((RoutedEventArgs)e).Handled = true;
		}
		_fireSelectionChangedEvent = false;
		goto IL_019b;
		IL_014b:
		if (IsCurrentValueValid())
		{
			PerformKeyboardSelection(num + num2);
			((RoutedEventArgs)e).Handled = true;
		}
		_fireSelectionChangedEvent = false;
		goto IL_019b;
		IL_00d3:
		if (AllowSpin && !IsReadOnly)
		{
			DoIncrement();
			((RoutedEventArgs)e).Handled = true;
		}
		_fireSelectionChangedEvent = false;
		goto IL_019b;
		IL_016c:
		if (IsCurrentValueValid())
		{
			PerformKeyboardSelection((num > 0) ? (num - 1) : 0);
			((RoutedEventArgs)e).Handled = true;
		}
		_fireSelectionChangedEvent = false;
		goto IL_019b;
		IL_00fc:
		if (AllowSpin && !IsReadOnly)
		{
			DoDecrement();
			((RoutedEventArgs)e).Handled = true;
		}
		_fireSelectionChangedEvent = false;
		goto IL_019b;
		IL_019b:
		((UIElement)this).OnPreviewKeyDown(e);
		return;
		IL_0194:
		_fireSelectionChangedEvent = false;
		goto IL_019b;
	}

	protected override void OnTextChanged(string previousValue, string currentValue)
	{
		if (_processTextChanged)
		{
			base.OnTextChanged(previousValue, currentValue);
		}
	}

	protected override DateTime? ConvertTextToValue(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		TryParseDateTime(text, out var result);
		if (ClipValueToMinMax)
		{
			return GetClippedMinMaxValue(result);
		}
		ValidateDefaultMinMax(result);
		return result;
	}

	protected override string ConvertValueToText()
	{
		if (!Value.HasValue)
		{
			return string.Empty;
		}
		return Value.Value.ToString(GetFormatString(Format), CultureInfo);
	}

	protected override void SetValidSpinDirection()
	{
		ValidSpinDirections validSpinDirections = ValidSpinDirections.None;
		if (!IsReadOnly)
		{
			if (IsLowerThan(Value, Maximum) || !Value.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Increase;
			}
			if (IsGreaterThan(Value, Minimum) || !Value.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Decrease;
			}
		}
		if (Spinner != null)
		{
			Spinner.ValidSpinDirection = validSpinDirections;
		}
	}

	protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		if (newValue.HasValue)
		{
			ParseValueIntoDateTimeInfo();
		}
		base.OnValueChanged(oldValue, newValue);
	}

	protected override void RaiseValueChangedEvent(DateTime? oldValue, DateTime? newValue)
	{
		if (!(((FrameworkElement)this).TemplatedParent is TimePicker) || !(((FrameworkElement)(TimePicker)(object)((FrameworkElement)this).TemplatedParent).TemplatedParent is DateTimePicker))
		{
			base.RaiseValueChangedEvent(oldValue, newValue);
		}
	}

	private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
	{
		if (_fireSelectionChangedEvent)
		{
			PerformMouseSelection();
		}
		else
		{
			_fireSelectionChangedEvent = true;
		}
	}

	private void TextBox_GotFocus(object sender, RoutedEventArgs e)
	{
		if (_selectedDateTimeInfo == null)
		{
			Select(GetDateTimeInfo(0));
		}
	}

	public void SelectAll()
	{
		_fireSelectionChangedEvent = false;
		((TextBoxBase)TextBox).SelectAll();
		_fireSelectionChangedEvent = true;
	}

	private void FormatUpdated()
	{
		InitializeDateTimeInfoList();
		if (Value.HasValue)
		{
			ParseValueIntoDateTimeInfo();
		}
		_processTextChanged = false;
		SyncTextAndValueProperties(updateValueFromText: false, null);
		_processTextChanged = true;
	}

	private void InitializeDateTimeInfoList()
	{
		_dateTimeInfoList.Clear();
		_selectedDateTimeInfo = null;
		string text = GetFormatString(Format);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		while (text.Length > 0)
		{
			int num = GetElementLengthByFormat(text);
			DateTimeInfo item = null;
			switch (text[0])
			{
			case '"':
			case '\'':
			{
				int num2 = text.IndexOf(text[0], 1);
				DateTimeInfo dateTimeInfo16 = new DateTimeInfo();
				dateTimeInfo16.IsReadOnly = true;
				dateTimeInfo16.Type = DateTimePart.Other;
				dateTimeInfo16.Length = 1;
				dateTimeInfo16.Content = text.Substring(1, Math.Max(1, num2 - 1));
				item = dateTimeInfo16;
				num = Math.Max(1, num2 + 1);
				break;
			}
			case 'D':
			case 'd':
			{
				string text11 = text.Substring(0, num);
				if (num == 1)
				{
					text11 = "%" + text11;
				}
				if (num > 2)
				{
					DateTimeInfo dateTimeInfo13 = new DateTimeInfo();
					dateTimeInfo13.IsReadOnly = true;
					dateTimeInfo13.Type = DateTimePart.DayName;
					dateTimeInfo13.Format = text11;
					item = dateTimeInfo13;
				}
				else
				{
					DateTimeInfo dateTimeInfo14 = new DateTimeInfo();
					dateTimeInfo14.IsReadOnly = false;
					dateTimeInfo14.Type = DateTimePart.Day;
					dateTimeInfo14.Format = text11;
					item = dateTimeInfo14;
				}
				break;
			}
			case 'F':
			case 'f':
			{
				string text6 = text.Substring(0, num);
				if (num == 1)
				{
					text6 = "%" + text6;
				}
				DateTimeInfo dateTimeInfo7 = new DateTimeInfo();
				dateTimeInfo7.IsReadOnly = false;
				dateTimeInfo7.Type = DateTimePart.Millisecond;
				dateTimeInfo7.Format = text6;
				item = dateTimeInfo7;
				break;
			}
			case 'h':
			{
				string text7 = text.Substring(0, num);
				if (num == 1)
				{
					text7 = "%" + text7;
				}
				DateTimeInfo dateTimeInfo8 = new DateTimeInfo();
				dateTimeInfo8.IsReadOnly = false;
				dateTimeInfo8.Type = DateTimePart.Hour12;
				dateTimeInfo8.Format = text7;
				item = dateTimeInfo8;
				break;
			}
			case 'H':
			{
				string text9 = text.Substring(0, num);
				if (num == 1)
				{
					text9 = "%" + text9;
				}
				DateTimeInfo dateTimeInfo10 = new DateTimeInfo();
				dateTimeInfo10.IsReadOnly = false;
				dateTimeInfo10.Type = DateTimePart.Hour24;
				dateTimeInfo10.Format = text9;
				item = dateTimeInfo10;
				break;
			}
			case 'M':
			{
				string text4 = text.Substring(0, num);
				if (num == 1)
				{
					text4 = "%" + text4;
				}
				if (num >= 3)
				{
					DateTimeInfo dateTimeInfo4 = new DateTimeInfo();
					dateTimeInfo4.IsReadOnly = false;
					dateTimeInfo4.Type = DateTimePart.MonthName;
					dateTimeInfo4.Format = text4;
					item = dateTimeInfo4;
				}
				else
				{
					DateTimeInfo dateTimeInfo5 = new DateTimeInfo();
					dateTimeInfo5.IsReadOnly = false;
					dateTimeInfo5.Type = DateTimePart.Month;
					dateTimeInfo5.Format = text4;
					item = dateTimeInfo5;
				}
				break;
			}
			case 'S':
			case 's':
			{
				string text10 = text.Substring(0, num);
				if (num == 1)
				{
					text10 = "%" + text10;
				}
				DateTimeInfo dateTimeInfo11 = new DateTimeInfo();
				dateTimeInfo11.IsReadOnly = false;
				dateTimeInfo11.Type = DateTimePart.Second;
				dateTimeInfo11.Format = text10;
				item = dateTimeInfo11;
				break;
			}
			case 'T':
			case 't':
			{
				string text3 = text.Substring(0, num);
				if (num == 1)
				{
					text3 = "%" + text3;
				}
				DateTimeInfo dateTimeInfo3 = new DateTimeInfo();
				dateTimeInfo3.IsReadOnly = false;
				dateTimeInfo3.Type = DateTimePart.AmPmDesignator;
				dateTimeInfo3.Format = text3;
				item = dateTimeInfo3;
				break;
			}
			case 'Y':
			case 'y':
			{
				string text12 = text.Substring(0, num);
				if (num == 1)
				{
					text12 = "%" + text12;
				}
				DateTimeInfo dateTimeInfo15 = new DateTimeInfo();
				dateTimeInfo15.IsReadOnly = false;
				dateTimeInfo15.Type = DateTimePart.Year;
				dateTimeInfo15.Format = text12;
				item = dateTimeInfo15;
				break;
			}
			case '\\':
				if (text.Length >= 2)
				{
					DateTimeInfo dateTimeInfo12 = new DateTimeInfo();
					dateTimeInfo12.IsReadOnly = true;
					dateTimeInfo12.Content = text.Substring(1, 1);
					dateTimeInfo12.Length = 1;
					dateTimeInfo12.Type = DateTimePart.Other;
					item = dateTimeInfo12;
					num = 2;
				}
				break;
			case 'g':
			{
				string text8 = text.Substring(0, num);
				if (num == 1)
				{
					text8 = "%" + text8;
				}
				DateTimeInfo dateTimeInfo9 = new DateTimeInfo();
				dateTimeInfo9.IsReadOnly = true;
				dateTimeInfo9.Type = DateTimePart.Period;
				dateTimeInfo9.Format = text.Substring(0, num);
				item = dateTimeInfo9;
				break;
			}
			case 'm':
			{
				string text5 = text.Substring(0, num);
				if (num == 1)
				{
					text5 = "%" + text5;
				}
				DateTimeInfo dateTimeInfo6 = new DateTimeInfo();
				dateTimeInfo6.IsReadOnly = false;
				dateTimeInfo6.Type = DateTimePart.Minute;
				dateTimeInfo6.Format = text5;
				item = dateTimeInfo6;
				break;
			}
			case 'z':
			{
				string text2 = text.Substring(0, num);
				if (num == 1)
				{
					text2 = "%" + text2;
				}
				DateTimeInfo dateTimeInfo2 = new DateTimeInfo();
				dateTimeInfo2.IsReadOnly = true;
				dateTimeInfo2.Type = DateTimePart.TimeZone;
				dateTimeInfo2.Format = text2;
				item = dateTimeInfo2;
				break;
			}
			default:
			{
				num = 1;
				DateTimeInfo dateTimeInfo = new DateTimeInfo();
				dateTimeInfo.IsReadOnly = true;
				dateTimeInfo.Length = 1;
				dateTimeInfo.Content = text[0].ToString();
				dateTimeInfo.Type = DateTimePart.Other;
				item = dateTimeInfo;
				break;
			}
			}
			_dateTimeInfoList.Add(item);
			text = text.Substring(num);
		}
	}

	private static int GetElementLengthByFormat(string format)
	{
		for (int i = 1; i < format.Length; i++)
		{
			if (string.Compare(format[i].ToString(), format[0].ToString(), ignoreCase: false) != 0)
			{
				return i;
			}
		}
		return format.Length;
	}

	private void ParseValueIntoDateTimeInfo()
	{
		string text = string.Empty;
		_dateTimeInfoList.ForEach((DateTimeInfo info) =>
		{
			if (info.Format == null)
			{
				info.StartPosition = text.Length;
				info.Length = info.Content.Length;
				text += info.Content;
			}
			else
			{
				DateTime dateTime = DateTime.Parse(Value.ToString());
				info.StartPosition = text.Length;
				info.Content = dateTime.ToString(info.Format, CultureInfo.DateTimeFormat);
				info.Length = info.Content.Length;
				text += info.Content;
			}
		});
	}

	private void PerformMouseSelection()
	{
		Select(GetDateTimeInfo(TextBox.SelectionStart));
	}

	private void PerformKeyboardSelection(int nextSelectionStart)
	{
		((UIElement)TextBox).Focus();
		CommitInput();
		int num = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0);
		int num2 = nextSelectionStart - num;
		if (num2 > 0)
		{
			Select(GetNextDateTimeInfo(nextSelectionStart));
		}
		else
		{
			Select(GetPreviousDateTimeInfo(nextSelectionStart - 1));
		}
	}

	private DateTimeInfo GetDateTimeInfo(int selectionStart)
	{
		return _dateTimeInfoList.FirstOrDefault((DateTimeInfo info) => info.StartPosition <= selectionStart && selectionStart < info.StartPosition + info.Length);
	}

	private DateTimeInfo GetNextDateTimeInfo(int nextSelectionStart)
	{
		DateTimeInfo dateTimeInfo = GetDateTimeInfo(nextSelectionStart);
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList.First();
		}
		DateTimeInfo objB = dateTimeInfo;
		while (dateTimeInfo.Type == DateTimePart.Other)
		{
			dateTimeInfo = GetDateTimeInfo(dateTimeInfo.StartPosition + dateTimeInfo.Length);
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList.First();
			}
			if (object.Equals(dateTimeInfo, objB))
			{
				throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
			}
		}
		return dateTimeInfo;
	}

	private DateTimeInfo GetPreviousDateTimeInfo(int previousSelectionStart)
	{
		DateTimeInfo dateTimeInfo = GetDateTimeInfo(previousSelectionStart);
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList.Last();
		}
		DateTimeInfo objB = dateTimeInfo;
		while (dateTimeInfo.Type == DateTimePart.Other)
		{
			dateTimeInfo = GetDateTimeInfo(dateTimeInfo.StartPosition - 1);
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList.Last();
			}
			if (object.Equals(dateTimeInfo, objB))
			{
				throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
			}
		}
		return dateTimeInfo;
	}

	private void Select(DateTimeInfo info)
	{
		if (info != null)
		{
			_fireSelectionChangedEvent = false;
			TextBox.Select(info.StartPosition, info.Length);
			_fireSelectionChangedEvent = true;
			_selectedDateTimeInfo = info;
		}
	}

	private string GetFormatString(DateTimeFormat dateTimeFormat)
	{
		return dateTimeFormat switch
		{
			DateTimeFormat.ShortDate => CultureInfo.DateTimeFormat.ShortDatePattern, 
			DateTimeFormat.LongDate => CultureInfo.DateTimeFormat.LongDatePattern, 
			DateTimeFormat.ShortTime => CultureInfo.DateTimeFormat.ShortTimePattern, 
			DateTimeFormat.LongTime => CultureInfo.DateTimeFormat.LongTimePattern, 
			DateTimeFormat.FullDateTime => CultureInfo.DateTimeFormat.FullDateTimePattern, 
			DateTimeFormat.MonthDay => CultureInfo.DateTimeFormat.MonthDayPattern, 
			DateTimeFormat.RFC1123 => CultureInfo.DateTimeFormat.RFC1123Pattern, 
			DateTimeFormat.SortableDateTime => CultureInfo.DateTimeFormat.SortableDateTimePattern, 
			DateTimeFormat.UniversalSortableDateTime => CultureInfo.DateTimeFormat.UniversalSortableDateTimePattern, 
			DateTimeFormat.YearMonth => CultureInfo.DateTimeFormat.YearMonthPattern, 
			DateTimeFormat.Custom => FormatString switch
			{
				"d" => CultureInfo.DateTimeFormat.ShortDatePattern, 
				"t" => CultureInfo.DateTimeFormat.ShortTimePattern, 
				"T" => CultureInfo.DateTimeFormat.LongTimePattern, 
				"D" => CultureInfo.DateTimeFormat.LongDatePattern, 
				"f" => CultureInfo.DateTimeFormat.LongDatePattern + " " + CultureInfo.DateTimeFormat.ShortTimePattern, 
				"F" => CultureInfo.DateTimeFormat.FullDateTimePattern, 
				"g" => CultureInfo.DateTimeFormat.ShortDatePattern + " " + CultureInfo.DateTimeFormat.ShortTimePattern, 
				"G" => CultureInfo.DateTimeFormat.ShortDatePattern + " " + CultureInfo.DateTimeFormat.LongTimePattern, 
				"m" => CultureInfo.DateTimeFormat.MonthDayPattern, 
				"y" => CultureInfo.DateTimeFormat.YearMonthPattern, 
				"r" => CultureInfo.DateTimeFormat.RFC1123Pattern, 
				"s" => CultureInfo.DateTimeFormat.SortableDateTimePattern, 
				"u" => CultureInfo.DateTimeFormat.UniversalSortableDateTimePattern, 
				_ => FormatString, 
			}, 
			_ => throw new ArgumentException("Not a supported format"), 
		};
	}

	private void UpdateDateTime(int value)
	{
		_fireSelectionChangedEvent = false;
		DateTimeInfo dateTimeInfo = _selectedDateTimeInfo;
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList[0];
		}
		DateTime? value2 = null;
		try
		{
			switch (dateTimeInfo.Type)
			{
			case DateTimePart.Year:
				value2 = Value.Value.AddYears(value);
				break;
			case DateTimePart.Month:
			case DateTimePart.MonthName:
				value2 = Value.Value.AddMonths(value);
				break;
			case DateTimePart.Day:
			case DateTimePart.DayName:
				value2 = Value.Value.AddDays(value);
				break;
			case DateTimePart.Hour12:
			case DateTimePart.Hour24:
				value2 = Value.Value.AddHours(value);
				break;
			case DateTimePart.Minute:
				value2 = Value.Value.AddMinutes(value);
				break;
			case DateTimePart.Second:
				value2 = Value.Value.AddSeconds(value);
				break;
			case DateTimePart.Millisecond:
				value2 = Value.Value.AddMilliseconds(value);
				break;
			case DateTimePart.AmPmDesignator:
				value2 = Value.Value.AddHours(value * 12);
				break;
			case DateTimePart.Other:
			case DateTimePart.Period:
			case DateTimePart.TimeZone:
				break;
			}
		}
		catch
		{
		}
		Value = CoerceValueMinMax(value2);
		TextBox.Select(dateTimeInfo.StartPosition, dateTimeInfo.Length);
		_fireSelectionChangedEvent = true;
	}

	private DateTime? CoerceValueMinMax(DateTime? value)
	{
		if (IsLowerThan(value, Minimum))
		{
			return Minimum;
		}
		if (IsGreaterThan(value, Maximum))
		{
			return Maximum;
		}
		return value;
	}

	private bool IsLowerThan(DateTime? value1, DateTime? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value < value2.Value;
	}

	private bool IsGreaterThan(DateTime? value1, DateTime? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value > value2.Value;
	}

	private bool TryParseDateTime(string text, out DateTime result)
	{
		bool flag = false;
		result = DateTime.Now;
		DateTime currentDate = (Value.HasValue ? Value.Value : DateTime.Parse(DateTime.Now.ToString(), CultureInfo.DateTimeFormat));
		flag = DateTimeParser.TryParse(text, GetFormatString(Format), currentDate, CultureInfo, out result);
		if (!flag)
		{
			flag = DateTime.TryParseExact(text, GetFormatString(Format), CultureInfo, DateTimeStyles.None, out result);
		}
		return flag;
	}

	private bool IsCurrentValueValid()
	{
		if (string.IsNullOrEmpty(TextBox.Text))
		{
			return true;
		}
		DateTime result;
		return TryParseDateTime(TextBox.Text, out result);
	}

	private void ValidateDefaultMinMax(DateTime? value)
	{
		if (!object.Equals(value, DefaultValue))
		{
			if (IsLowerThan(value, Minimum))
			{
				throw new ArgumentOutOfRangeException("Minimum", $"Value must be greater than MinValue of {Minimum}");
			}
			if (IsGreaterThan(value, Maximum))
			{
				throw new ArgumentOutOfRangeException("Maximum", $"Value must be less than MaxValue of {Maximum}");
			}
		}
	}

	private DateTime? GetClippedMinMaxValue(DateTime? value)
	{
		if (IsGreaterThan(value, Maximum))
		{
			return Maximum;
		}
		if (IsLowerThan(value, Minimum))
		{
			return Minimum;
		}
		return value;
	}
}
