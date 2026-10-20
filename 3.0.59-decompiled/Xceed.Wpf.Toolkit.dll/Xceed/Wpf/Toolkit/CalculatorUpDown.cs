using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_CalculatorPopup", Type = typeof(Popup))]
[TemplatePart(Name = "PART_Calculator", Type = typeof(Calculator))]
public class CalculatorUpDown : DecimalUpDown
{
	private const string PART_CalculatorPopup = "PART_CalculatorPopup";

	private const string PART_Calculator = "PART_Calculator";

	private Popup _calculatorPopup;

	private Calculator _calculator;

	private decimal? _initialValue;

	public static readonly DependencyProperty DisplayTextProperty;

	public static readonly DependencyProperty EnterClosesCalculatorProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty MemoryProperty;

	public static readonly DependencyProperty PrecisionProperty;

	public string DisplayText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DisplayTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayTextProperty, (object)value);
		}
	}

	public bool EnterClosesCalculator
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnterClosesCalculatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterClosesCalculatorProperty, (object)value);
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

	public decimal Memory
	{
		get
		{
			return (decimal)((DependencyObject)this).GetValue(MemoryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MemoryProperty, (object)value);
		}
	}

	public int Precision
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PrecisionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrecisionProperty, (object)value);
		}
	}

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CalculatorUpDown calculatorUpDown)
		{
			calculatorUpDown.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue = Value;
		}
	}

	static CalculatorUpDown()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(CalculatorUpDown), (PropertyMetadata)new UIPropertyMetadata((object)"0"));
		EnterClosesCalculatorProperty = DependencyProperty.Register("EnterClosesCalculator", typeof(bool), typeof(CalculatorUpDown), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(CalculatorUpDown), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsOpenChanged));
		MemoryProperty = DependencyProperty.Register("Memory", typeof(decimal), typeof(CalculatorUpDown), (PropertyMetadata)new UIPropertyMetadata((object)0m));
		PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(CalculatorUpDown), (PropertyMetadata)new UIPropertyMetadata((object)6));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CalculatorUpDown), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(CalculatorUpDown)));
	}

	public CalculatorUpDown()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_calculatorPopup != null)
		{
			_calculatorPopup.Opened -= CalculatorPopup_Opened;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_CalculatorPopup");
		_calculatorPopup = (Popup)(object)((templateChild is Popup) ? templateChild : null);
		if (_calculatorPopup != null)
		{
			_calculatorPopup.Opened += CalculatorPopup_Opened;
		}
		if (_calculator != null)
		{
			_calculator.ValueChanged -= OnCalculatorValueChanged;
		}
		_calculator = ((FrameworkElement)this).GetTemplateChild("PART_Calculator") as Calculator;
		if (_calculator != null)
		{
			_calculator.ValueChanged += OnCalculatorValueChanged;
		}
	}

	private void OnCalculatorValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (IsValid(_calculator.Value))
		{
			Value = _calculator.Value;
		}
	}

	private void CalculatorPopup_Opened(object sender, EventArgs e)
	{
		if (_calculator != null)
		{
			_calculator.InitializeToValue(Value);
			((UIElement)_calculator).Focus();
		}
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (IsOpen && EnterClosesCalculator)
		{
			Calculator.CalculatorButtonType calculatorButtonTypeFromText = CalculatorUtilities.GetCalculatorButtonTypeFromText(e.Text);
			if (calculatorButtonTypeFromText == Calculator.CalculatorButtonType.Equal)
			{
				CloseCalculatorUpDown(isFocusOnTextBox: true);
			}
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
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
			CloseCalculatorUpDown(isFocusOnTextBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			if (EnterClosesCalculator)
			{
				Value = _initialValue;
			}
			CloseCalculatorUpDown(isFocusOnTextBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseCalculatorUpDown(isFocusOnTextBox: false);
	}

	private void CloseCalculatorUpDown(bool isFocusOnTextBox)
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
}
