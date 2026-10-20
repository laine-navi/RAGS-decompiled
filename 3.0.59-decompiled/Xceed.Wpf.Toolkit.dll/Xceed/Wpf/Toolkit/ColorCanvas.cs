using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ColorShadingCanvas", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_ColorShadeSelector", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_SpectrumSlider", Type = typeof(ColorSpectrumSlider))]
[TemplatePart(Name = "PART_HexadecimalTextBox", Type = typeof(TextBox))]
public class ColorCanvas : Control
{
	private const string PART_ColorShadingCanvas = "PART_ColorShadingCanvas";

	private const string PART_ColorShadeSelector = "PART_ColorShadeSelector";

	private const string PART_SpectrumSlider = "PART_SpectrumSlider";

	private const string PART_HexadecimalTextBox = "PART_HexadecimalTextBox";

	private TranslateTransform _colorShadeSelectorTransform = new TranslateTransform();

	private Canvas _colorShadingCanvas;

	private Canvas _colorShadeSelector;

	private ColorSpectrumSlider _spectrumSlider;

	private TextBox _hexadecimalTextBox;

	private Point? _currentColorPosition;

	private bool _surpressPropertyChanged;

	public static readonly DependencyProperty SelectedColorProperty;

	public static readonly DependencyProperty AProperty;

	public static readonly DependencyProperty RProperty;

	public static readonly DependencyProperty GProperty;

	public static readonly DependencyProperty BProperty;

	public static readonly DependencyProperty HexadecimalStringProperty;

	public static readonly DependencyProperty UsingAlphaChannelProperty;

	public static readonly RoutedEvent SelectedColorChangedEvent;

	public Color SelectedColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Color)((DependencyObject)this).GetValue(SelectedColorProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(SelectedColorProperty, (object)value);
		}
	}

	public byte A
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(AProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AProperty, (object)value);
		}
	}

	public byte R
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(RProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RProperty, (object)value);
		}
	}

	public byte G
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(GProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GProperty, (object)value);
		}
	}

	public byte B
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(BProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BProperty, (object)value);
		}
	}

	public string HexadecimalString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HexadecimalStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HexadecimalStringProperty, (object)value);
		}
	}

	public bool UsingAlphaChannel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UsingAlphaChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UsingAlphaChannelProperty, (object)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<Color> SelectedColorChanged
	{
		add
		{
			((UIElement)this).AddHandler(SelectedColorChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(SelectedColorChangedEvent, (Delegate)(object)value);
		}
	}

	private static void OnSelectedColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnSelectedColorChanged((Color)e.OldValue, (Color)e.NewValue);
		}
	}

	protected virtual void OnSelectedColorChanged(Color oldValue, Color newValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		SetHexadecimalStringProperty(GetFormatedColorString(newValue), modifyFromUI: false);
		UpdateRGBValues(newValue);
		UpdateColorShadeSelectorPosition(newValue);
		RoutedPropertyChangedEventArgs<Color> e = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
		((RoutedEventArgs)e).RoutedEvent = SelectedColorChangedEvent;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
	}

	private static void OnAChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnAChanged((byte)e.OldValue, (byte)e.NewValue);
		}
	}

	protected virtual void OnAChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnRChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnRChanged((byte)e.OldValue, (byte)e.NewValue);
		}
	}

	protected virtual void OnRChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnGChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnGChanged((byte)e.OldValue, (byte)e.NewValue);
		}
	}

	protected virtual void OnGChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnBChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnBChanged((byte)e.OldValue, (byte)e.NewValue);
		}
	}

	protected virtual void OnBChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnHexadecimalStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnHexadecimalStringChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnHexadecimalStringChanged(string oldValue, string newValue)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		string formatedColorString = GetFormatedColorString(newValue);
		string formatedColorString2 = GetFormatedColorString(SelectedColor);
		if (!formatedColorString2.Equals(formatedColorString))
		{
			UpdateSelectedColor((Color)ColorConverter.ConvertFromString(formatedColorString));
		}
		SetHexadecimalTextBoxTextProperty(newValue);
	}

	private static object OnCoerceHexadecimalString(DependencyObject d, object basevalue)
	{
		ColorCanvas colorCanvas = (ColorCanvas)(object)d;
		if (colorCanvas == null)
		{
			return basevalue;
		}
		return colorCanvas.OnCoerceHexadecimalString(basevalue);
	}

	private object OnCoerceHexadecimalString(object newValue)
	{
		string text = newValue as string;
		string result = text;
		try
		{
			ColorConverter.ConvertFromString(text);
			return result;
		}
		catch
		{
			throw new InvalidDataException("Color provided is not in the correct format.");
		}
	}

	private static void OnUsingAlphaChannelPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnUsingAlphaChannelChanged();
		}
	}

	protected virtual void OnUsingAlphaChannelChanged()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		SetHexadecimalStringProperty(GetFormatedColorString(SelectedColor), modifyFromUI: false);
	}

	static ColorCanvas()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_016a: Expected Obj, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorCanvas), (PropertyMetadata)new FrameworkPropertyMetadata((object)Colors.Black, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnSelectedColorChanged));
		AProperty = DependencyProperty.Register("A", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)new UIPropertyMetadata((object)byte.MaxValue, (PropertyChangedCallback)OnAChanged));
		RProperty = DependencyProperty.Register("R", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)new UIPropertyMetadata((object)(byte)0, (PropertyChangedCallback)OnRChanged));
		GProperty = DependencyProperty.Register("G", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)new UIPropertyMetadata((object)(byte)0, (PropertyChangedCallback)OnGChanged));
		BProperty = DependencyProperty.Register("B", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)new UIPropertyMetadata((object)(byte)0, (PropertyChangedCallback)OnBChanged));
		HexadecimalStringProperty = DependencyProperty.Register("HexadecimalString", typeof(string), typeof(ColorCanvas), (PropertyMetadata)new UIPropertyMetadata((object)"#FFFFFFFF", (PropertyChangedCallback)OnHexadecimalStringChanged, (CoerceValueCallback)OnCoerceHexadecimalString));
		UsingAlphaChannelProperty = DependencyProperty.Register("UsingAlphaChannel", typeof(bool), typeof(ColorCanvas), (PropertyMetadata)new FrameworkPropertyMetadata((object)true, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnUsingAlphaChannelPropertyChanged));
		SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorCanvas));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorCanvas), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ColorCanvas)));
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected Obj, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_colorShadingCanvas != null)
		{
			((UIElement)_colorShadingCanvas).MouseLeftButtonDown -= ColorShadingCanvas_MouseLeftButtonDown;
			((UIElement)_colorShadingCanvas).MouseLeftButtonUp -= ColorShadingCanvas_MouseLeftButtonUp;
			((UIElement)_colorShadingCanvas).MouseMove -= ColorShadingCanvas_MouseMove;
			((FrameworkElement)_colorShadingCanvas).SizeChanged -= ColorShadingCanvas_SizeChanged;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_ColorShadingCanvas");
		_colorShadingCanvas = (Canvas)(object)((templateChild is Canvas) ? templateChild : null);
		if (_colorShadingCanvas != null)
		{
			((UIElement)_colorShadingCanvas).MouseLeftButtonDown += ColorShadingCanvas_MouseLeftButtonDown;
			((UIElement)_colorShadingCanvas).MouseLeftButtonUp += ColorShadingCanvas_MouseLeftButtonUp;
			((UIElement)_colorShadingCanvas).MouseMove += ColorShadingCanvas_MouseMove;
			((FrameworkElement)_colorShadingCanvas).SizeChanged += ColorShadingCanvas_SizeChanged;
		}
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_ColorShadeSelector");
		_colorShadeSelector = (Canvas)(object)((templateChild2 is Canvas) ? templateChild2 : null);
		if (_colorShadeSelector != null)
		{
			((UIElement)_colorShadeSelector).RenderTransform = (Transform)(object)_colorShadeSelectorTransform;
		}
		if (_spectrumSlider != null)
		{
			((RangeBase)_spectrumSlider).ValueChanged -= SpectrumSlider_ValueChanged;
		}
		_spectrumSlider = ((FrameworkElement)this).GetTemplateChild("PART_SpectrumSlider") as ColorSpectrumSlider;
		if (_spectrumSlider != null)
		{
			((RangeBase)_spectrumSlider).ValueChanged += SpectrumSlider_ValueChanged;
		}
		if (_hexadecimalTextBox != null)
		{
			((UIElement)_hexadecimalTextBox).LostFocus -= HexadecimalTextBox_LostFocus;
		}
		DependencyObject templateChild3 = ((FrameworkElement)this).GetTemplateChild("PART_HexadecimalTextBox");
		_hexadecimalTextBox = (TextBox)(object)((templateChild3 is TextBox) ? templateChild3 : null);
		if (_hexadecimalTextBox != null)
		{
			((UIElement)_hexadecimalTextBox).LostFocus += HexadecimalTextBox_LostFocus;
		}
		UpdateRGBValues(SelectedColor);
		UpdateColorShadeSelectorPosition(SelectedColor);
		SetHexadecimalTextBoxTextProperty(GetFormatedColorString(SelectedColor));
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		((UIElement)this).OnKeyDown(e);
		if ((int)e.Key == 6 && ((RoutedEventArgs)e).OriginalSource is TextBox)
		{
			TextBox val = (TextBox)((RoutedEventArgs)e).OriginalSource;
			if (((FrameworkElement)val).Name == "PART_HexadecimalTextBox")
			{
				SetHexadecimalStringProperty(val.Text, modifyFromUI: true);
			}
		}
	}

	private void ColorShadingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		Point position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)_colorShadingCanvas);
		UpdateColorShadeSelectorPositionAndCalculateColor(position, calculateColor: true);
		((UIElement)_colorShadingCanvas).CaptureMouse();
	}

	private void ColorShadingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		((UIElement)_colorShadingCanvas).ReleaseMouseCapture();
	}

	private void ColorShadingCanvas_MouseMove(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.LeftButton == 1)
		{
			Point position = e.GetPosition((IInputElement)(object)_colorShadingCanvas);
			UpdateColorShadeSelectorPositionAndCalculateColor(position, calculateColor: true);
			Mouse.Synchronize();
		}
	}

	private void ColorShadingCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (_currentColorPosition.HasValue)
		{
			Point val = default;
			Point value = _currentColorPosition.Value;
			double x = value.X;
			Size newSize = e.NewSize;
			val.X = x * newSize.Width;
			Point value2 = _currentColorPosition.Value;
			double y = value2.Y;
			Size newSize2 = e.NewSize;
			val.Y = y * newSize2.Height;
			Point p = val;
			UpdateColorShadeSelectorPositionAndCalculateColor(p, calculateColor: false);
		}
	}

	private void SpectrumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (_currentColorPosition.HasValue)
		{
			CalculateColor(_currentColorPosition.Value);
		}
	}

	private void HexadecimalTextBox_LostFocus(object sender, RoutedEventArgs e)
	{
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		SetHexadecimalStringProperty(val.Text, modifyFromUI: true);
	}

	private void UpdateSelectedColor()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		SelectedColor = Color.FromArgb(A, R, G, B);
	}

	private void UpdateSelectedColor(Color color)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		SelectedColor = Color.FromArgb(color.A, color.R, color.G, color.B);
	}

	private void UpdateRGBValues(Color color)
	{
		_surpressPropertyChanged = true;
		A = color.A;
		R = color.R;
		G = color.G;
		B = color.B;
		_surpressPropertyChanged = false;
	}

	private void UpdateColorShadeSelectorPositionAndCalculateColor(Point p, bool calculateColor)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		if (p.Y < 0.0)
		{
			p.Y = 0.0;
		}
		if (p.X < 0.0)
		{
			p.X = 0.0;
		}
		if (p.X > ((FrameworkElement)_colorShadingCanvas).ActualWidth)
		{
			p.X = ((FrameworkElement)_colorShadingCanvas).ActualWidth;
		}
		if (p.Y > ((FrameworkElement)_colorShadingCanvas).ActualHeight)
		{
			p.Y = ((FrameworkElement)_colorShadingCanvas).ActualHeight;
		}
		_colorShadeSelectorTransform.X = p.X - ((FrameworkElement)_colorShadeSelector).Width / 2.0;
		_colorShadeSelectorTransform.Y = p.Y - ((FrameworkElement)_colorShadeSelector).Height / 2.0;
		p.X /= ((FrameworkElement)_colorShadingCanvas).ActualWidth;
		p.Y /= ((FrameworkElement)_colorShadingCanvas).ActualHeight;
		_currentColorPosition = p;
		if (calculateColor)
		{
			CalculateColor(p);
		}
	}

	private void UpdateColorShadeSelectorPosition(Color color)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (_spectrumSlider != null && _colorShadingCanvas != null)
		{
			_currentColorPosition = null;
			HsvColor hsvColor = ColorUtilities.ConvertRgbToHsv(color.R, color.G, color.B);
			if (color.R != color.G || color.R != color.B)
			{
				((RangeBase)_spectrumSlider).Value = hsvColor.H;
			}
			Point value = new Point(hsvColor.S, 1.0 - hsvColor.V);
			_currentColorPosition = value;
			_colorShadeSelectorTransform.X = value.X * ((FrameworkElement)_colorShadingCanvas).Width - 5.0;
			_colorShadeSelectorTransform.Y = value.Y * ((FrameworkElement)_colorShadingCanvas).Height - 5.0;
		}
	}

	private void CalculateColor(Point p)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		HsvColor hsvColor = new HsvColor(360.0 - ((RangeBase)_spectrumSlider).Value, 1.0, 1.0);
		hsvColor.S = p.X;
		hsvColor.V = 1.0 - p.Y;
		HsvColor hsvColor2 = hsvColor;
		Color selectedColor = ColorUtilities.ConvertHsvToRgb(hsvColor2.H, hsvColor2.S, hsvColor2.V);
		selectedColor.A = A;
		SelectedColor = selectedColor;
		SetHexadecimalStringProperty(GetFormatedColorString(SelectedColor), modifyFromUI: false);
	}

	private string GetFormatedColorString(Color colorToFormat)
	{
		return ColorUtilities.FormatColorString(((object)colorToFormat/*cast due to constrained. prefix*/).ToString(), UsingAlphaChannel);
	}

	private string GetFormatedColorString(string stringToFormat)
	{
		return ColorUtilities.FormatColorString(stringToFormat, UsingAlphaChannel);
	}

	private void SetHexadecimalStringProperty(string newValue, bool modifyFromUI)
	{
		if (modifyFromUI)
		{
			try
			{
				ColorConverter.ConvertFromString(newValue);
				HexadecimalString = newValue;
				return;
			}
			catch
			{
				SetHexadecimalTextBoxTextProperty(HexadecimalString);
				return;
			}
		}
		HexadecimalString = newValue;
	}

	private void SetHexadecimalTextBoxTextProperty(string newValue)
	{
		if (_hexadecimalTextBox != null)
		{
			_hexadecimalTextBox.Text = newValue;
		}
	}

	public ColorCanvas()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
	}
}
