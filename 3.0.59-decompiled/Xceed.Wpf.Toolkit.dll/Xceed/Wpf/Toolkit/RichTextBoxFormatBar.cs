using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class RichTextBoxFormatBar : Control, IRichTextBoxFormatBar
{
	private ComboBox _cmbFontFamilies;

	private ComboBox _cmbFontSizes;

	private ColorPicker _cmbFontBackgroundColor;

	private ColorPicker _cmbFontColor;

	private ToggleButton _btnNumbers;

	private ToggleButton _btnBullets;

	private ToggleButton _btnBold;

	private ToggleButton _btnItalic;

	private ToggleButton _btnUnderline;

	private ToggleButton _btnAlignLeft;

	private ToggleButton _btnAlignCenter;

	private ToggleButton _btnAlignRight;

	private Thumb _dragWidget;

	private bool _waitingForMouseOver;

	public static readonly DependencyProperty TargetProperty;

	public static double[] FontSizes => new double[54]
	{
		3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0,
		9.5, 10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0,
		15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0,
		30.0, 32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0,
		60.0, 64.0, 68.0, 72.0, 76.0, 80.0, 88.0, 96.0, 104.0, 112.0,
		120.0, 128.0, 136.0, 144.0
	};

	public RichTextBox Target
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (RichTextBox)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	public bool PreventDisplayFadeOut
	{
		get
		{
			if (!_cmbFontFamilies.IsDropDownOpen && !_cmbFontSizes.IsDropDownOpen && !_cmbFontBackgroundColor.IsOpen && !_cmbFontColor.IsOpen)
			{
				return _waitingForMouseOver;
			}
			return true;
		}
	}

	static RichTextBoxFormatBar()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		TargetProperty = DependencyProperty.Register("Target", typeof(RichTextBox), typeof(RichTextBoxFormatBar), new PropertyMetadata((object)null, (PropertyChangedCallback)OnRichTextBoxPropertyChanged));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(RichTextBoxFormatBar), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(RichTextBoxFormatBar)));
	}

	private void FontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		if (e.AddedItems.Count != 0)
		{
			FontFamily value = (FontFamily)e.AddedItems[0];
			ApplyPropertyValueToSelectedText(TextElement.FontFamilyProperty, value);
			_waitingForMouseOver = true;
		}
	}

	private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count != 0)
		{
			ApplyPropertyValueToSelectedText(TextElement.FontSizeProperty, e.AddedItems[0]);
			_waitingForMouseOver = true;
		}
	}

	private void FontColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		Color newValue = e.NewValue;
		ApplyPropertyValueToSelectedText(TextElement.ForegroundProperty, (object)new SolidColorBrush(newValue));
		_waitingForMouseOver = true;
	}

	private void FontBackgroundColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		Color newValue = e.NewValue;
		ApplyPropertyValueToSelectedText(TextElement.BackgroundProperty, (object)new SolidColorBrush(newValue));
		_waitingForMouseOver = true;
	}

	private void Bullets_Clicked(object sender, RoutedEventArgs e)
	{
		if (BothSelectionListsAreChecked())
		{
			_btnNumbers.IsChecked = false;
		}
	}

	private void Numbers_Clicked(object sender, RoutedEventArgs e)
	{
		if (BothSelectionListsAreChecked())
		{
			_btnBullets.IsChecked = false;
		}
	}

	private void DragWidget_DragDelta(object sender, DragDeltaEventArgs e)
	{
		ProcessMove(e);
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		((UIElement)this).OnMouseEnter(e);
		_waitingForMouseOver = false;
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected Obj, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_dragWidget != null)
		{
			_dragWidget.DragDelta -= DragWidget_DragDelta;
		}
		if (_cmbFontFamilies != null)
		{
			((Selector)_cmbFontFamilies).SelectionChanged -= FontFamily_SelectionChanged;
		}
		if (_cmbFontSizes != null)
		{
			((Selector)_cmbFontSizes).SelectionChanged -= FontSize_SelectionChanged;
		}
		if (_btnBullets != null)
		{
			((ButtonBase)_btnBullets).Click -= Bullets_Clicked;
		}
		if (_btnNumbers != null)
		{
			((ButtonBase)_btnNumbers).Click -= Numbers_Clicked;
		}
		if (_cmbFontBackgroundColor != null)
		{
			_cmbFontBackgroundColor.SelectedColorChanged -= FontBackgroundColor_SelectedColorChanged;
		}
		if (_cmbFontColor != null)
		{
			_cmbFontColor.SelectedColorChanged -= FontColor_SelectedColorChanged;
		}
		GetTemplateComponent(ref _cmbFontFamilies, "_cmbFontFamilies");
		GetTemplateComponent(ref _cmbFontSizes, "_cmbFontSizes");
		GetTemplateComponent(ref _cmbFontBackgroundColor, "_cmbFontBackgroundColor");
		GetTemplateComponent(ref _cmbFontColor, "_cmbFontColor");
		GetTemplateComponent(ref _btnNumbers, "_btnNumbers");
		GetTemplateComponent(ref _btnBullets, "_btnBullets");
		GetTemplateComponent(ref _btnBold, "_btnBold");
		GetTemplateComponent(ref _btnItalic, "_btnItalic");
		GetTemplateComponent(ref _btnUnderline, "_btnUnderline");
		GetTemplateComponent(ref _btnAlignLeft, "_btnAlignLeft");
		GetTemplateComponent(ref _btnAlignCenter, "_btnAlignCenter");
		GetTemplateComponent(ref _btnAlignRight, "_btnAlignRight");
		GetTemplateComponent(ref _dragWidget, "_dragWidget");
		if (_dragWidget != null)
		{
			_dragWidget.DragDelta += DragWidget_DragDelta;
		}
		if (_cmbFontFamilies != null)
		{
			((ItemsControl)_cmbFontFamilies).ItemsSource = FontUtilities.Families.OrderBy((FontFamily fontFamily) => fontFamily.Source);
			((Selector)_cmbFontFamilies).SelectionChanged += FontFamily_SelectionChanged;
		}
		if (_cmbFontSizes != null)
		{
			((ItemsControl)_cmbFontSizes).ItemsSource = FontSizes;
			((Selector)_cmbFontSizes).SelectionChanged += FontSize_SelectionChanged;
		}
		if (_btnBullets != null)
		{
			((ButtonBase)_btnBullets).Click += Bullets_Clicked;
		}
		if (_btnNumbers != null)
		{
			((ButtonBase)_btnNumbers).Click += Numbers_Clicked;
		}
		if (_cmbFontBackgroundColor != null)
		{
			_cmbFontBackgroundColor.SelectedColorChanged += FontBackgroundColor_SelectedColorChanged;
		}
		if (_cmbFontColor != null)
		{
			_cmbFontColor.SelectedColorChanged += FontColor_SelectedColorChanged;
		}
		Update();
	}

	private void GetTemplateComponent<T>(ref T partMember, string partName) where T : class
	{
		partMember = ((((Control)this).Template != null) ? (((FrameworkTemplate)((Control)this).Template).FindName(partName, (FrameworkElement)(object)this) as T) : null);
	}

	private void UpdateToggleButtonState()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		UpdateItemCheckedState(_btnBold, TextElement.FontWeightProperty, FontWeights.Bold);
		UpdateItemCheckedState(_btnItalic, TextElement.FontStyleProperty, FontStyles.Italic);
		UpdateItemCheckedState(_btnUnderline, Inline.TextDecorationsProperty, TextDecorations.Underline);
		UpdateItemCheckedState(_btnAlignLeft, Block.TextAlignmentProperty, (object)(TextAlignment)0);
		UpdateItemCheckedState(_btnAlignCenter, Block.TextAlignmentProperty, (object)(TextAlignment)2);
		UpdateItemCheckedState(_btnAlignRight, Block.TextAlignmentProperty, (object)(TextAlignment)1);
	}

	private void UpdateItemCheckedState(ToggleButton button, DependencyProperty formattingProperty, object expectedValue)
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = ((TextRange)Target.Selection).GetPropertyValue(formattingProperty);
		}
		button.IsChecked = obj != null && obj != DependencyProperty.UnsetValue && (obj?.Equals(expectedValue) ?? false);
	}

	private void UpdateSelectedFontFamily()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = ((TextRange)Target.Selection).GetPropertyValue(TextElement.FontFamilyProperty);
		}
		FontFamily val = (FontFamily)((obj == null || obj == DependencyProperty.UnsetValue) ? null : obj);
		if (val != null)
		{
			((Selector)_cmbFontFamilies).SelectedItem = val;
		}
	}

	private void UpdateSelectedFontSize()
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = ((TextRange)Target.Selection).GetPropertyValue(TextElement.FontSizeProperty);
		}
		((Selector)_cmbFontSizes).SelectedValue = ((obj == null || obj == DependencyProperty.UnsetValue) ? null : obj);
	}

	private void UpdateFontColor()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = ((TextRange)Target.Selection).GetPropertyValue(TextElement.ForegroundProperty);
		}
		Color selectedColor = ((obj == null || obj == DependencyProperty.UnsetValue) ? Colors.Black : ((SolidColorBrush)obj).Color);
		_cmbFontColor.SelectedColor = selectedColor;
	}

	private void UpdateFontBackgroundColor()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = ((TextRange)Target.Selection).GetPropertyValue(TextElement.BackgroundProperty);
		}
		Color selectedColor = ((obj == null || obj == DependencyProperty.UnsetValue) ? Colors.Transparent : ((SolidColorBrush)obj).Color);
		_cmbFontBackgroundColor.SelectedColor = selectedColor;
	}

	private void UpdateSelectionListType()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Invalid comparison between Unknown and I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Invalid comparison between Unknown and I4
		_btnBullets.IsChecked = false;
		_btnNumbers.IsChecked = false;
		Paragraph val = ((Target != null && Target.Selection != null) ? ((TextRange)Target.Selection).Start.Paragraph : null);
		Paragraph val2 = ((Target != null && Target.Selection != null) ? ((TextRange)Target.Selection).End.Paragraph : null);
		if (val != null && val2 != null && ((FrameworkContentElement)val).Parent is ListItem && ((FrameworkContentElement)val2).Parent is ListItem && object.ReferenceEquals(((ListItem)((FrameworkContentElement)val).Parent).List, ((ListItem)((FrameworkContentElement)val2).Parent).List))
		{
			TextMarkerStyle markerStyle = ((ListItem)((FrameworkContentElement)val).Parent).List.MarkerStyle;
			if ((int)markerStyle == 1)
			{
				_btnBullets.IsChecked = true;
			}
			else if ((int)markerStyle == 9)
			{
				_btnNumbers.IsChecked = true;
			}
		}
	}

	private bool BothSelectionListsAreChecked()
	{
		if (_btnBullets.IsChecked == true)
		{
			return _btnNumbers.IsChecked == true;
		}
		return false;
	}

	private void ApplyPropertyValueToSelectedText(DependencyProperty formattingProperty, object value)
	{
		if (value != null && Target != null && Target.Selection != null)
		{
			((TextRange)Target.Selection).ApplyPropertyValue(formattingProperty, value);
		}
	}

	private void ProcessMove(DragDeltaEventArgs e)
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)(object)Target);
		UIElementAdorner<Control> uIElementAdorner = adornerLayer.GetAdorners((UIElement)(object)Target)[0] as UIElementAdorner<Control>;
		uIElementAdorner.SetOffsets(uIElementAdorner.OffsetLeft + e.HorizontalChange, uIElementAdorner.OffsetTop + e.VerticalChange);
	}

	private static void OnRichTextBoxPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
	}

	public void Update()
	{
		UpdateToggleButtonState();
		UpdateSelectedFontFamily();
		UpdateSelectedFontSize();
		UpdateFontColor();
		UpdateFontBackgroundColor();
		UpdateSelectionListType();
	}
}
