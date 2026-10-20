using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ColorPickerPalettePopup", Type = typeof(Popup))]
[TemplatePart(Name = "PART_AvailableColors", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_RecentColors", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_ColorPickerToggleButton", Type = typeof(ToggleButton))]
[TemplatePart(Name = "PART_ColorModeButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_StandardColors", Type = typeof(ListBox))]
public class ColorPicker : Control
{
	private const string PART_AvailableColors = "PART_AvailableColors";

	private const string PART_StandardColors = "PART_StandardColors";

	private const string PART_RecentColors = "PART_RecentColors";

	private const string PART_ColorPickerToggleButton = "PART_ColorPickerToggleButton";

	private const string PART_ColorPickerPalettePopup = "PART_ColorPickerPalettePopup";

	private const string PART_ColorModeButton = "PART_ColorModeButton";

	private ListBox _availableColors;

	private ListBox _standardColors;

	private ListBox _recentColors;

	private ToggleButton _toggleButton;

	private Popup _popup;

	private Button _colorModeButton;

	public static readonly DependencyProperty AvailableColorsProperty;

	public static readonly DependencyProperty AvailableColorsHeaderProperty;

	public static readonly DependencyProperty ButtonStyleProperty;

	public static readonly DependencyProperty DisplayColorAndNameProperty;

	public static readonly DependencyProperty ColorModeProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty RecentColorsProperty;

	public static readonly DependencyProperty RecentColorsHeaderProperty;

	public static readonly DependencyProperty SelectedColorProperty;

	public static readonly DependencyProperty SelectedColorTextProperty;

	public static readonly DependencyProperty ShowAdvancedButtonProperty;

	public static readonly DependencyProperty ShowAvailableColorsProperty;

	public static readonly DependencyProperty ShowRecentColorsProperty;

	public static readonly DependencyProperty ShowStandardColorsProperty;

	public static readonly DependencyProperty ShowDropDownButtonProperty;

	public static readonly DependencyProperty StandardColorsProperty;

	public static readonly DependencyProperty StandardColorsHeaderProperty;

	public static readonly DependencyProperty UsingAlphaChannelProperty;

	public static readonly RoutedEvent SelectedColorChangedEvent;

	public ObservableCollection<ColorItem> AvailableColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(AvailableColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableColorsProperty, (object)value);
		}
	}

	public string AvailableColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AvailableColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableColorsHeaderProperty, (object)value);
		}
	}

	public Style ButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(ButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonStyleProperty, (object)value);
		}
	}

	public bool DisplayColorAndName
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayColorAndNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayColorAndNameProperty, (object)value);
		}
	}

	public ColorMode ColorMode
	{
		get
		{
			return (ColorMode)((DependencyObject)this).GetValue(ColorModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorModeProperty, (object)value);
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

	public ObservableCollection<ColorItem> RecentColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(RecentColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentColorsProperty, (object)value);
		}
	}

	public string RecentColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(RecentColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentColorsHeaderProperty, (object)value);
		}
	}

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

	public string SelectedColorText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedColorTextProperty);
		}
		protected set
		{
			((DependencyObject)this).SetValue(SelectedColorTextProperty, (object)value);
		}
	}

	public bool ShowAdvancedButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAdvancedButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAdvancedButtonProperty, (object)value);
		}
	}

	public bool ShowAvailableColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAvailableColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAvailableColorsProperty, (object)value);
		}
	}

	public bool ShowRecentColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowRecentColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRecentColorsProperty, (object)value);
		}
	}

	public bool ShowStandardColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowStandardColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowStandardColorsProperty, (object)value);
		}
	}

	public bool ShowDropDownButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowDropDownButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowDropDownButtonProperty, (object)value);
		}
	}

	public ObservableCollection<ColorItem> StandardColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(StandardColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardColorsProperty, (object)value);
		}
	}

	public string StandardColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(StandardColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardColorsHeaderProperty, (object)value);
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

	private static void OnSelectedColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		((ColorPicker)(object)d)?.OnSelectedColorChanged((Color)e.OldValue, (Color)e.NewValue);
	}

	private void OnSelectedColorChanged(Color oldValue, Color newValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		SelectedColorText = GetFormatedColorString(newValue);
		RoutedPropertyChangedEventArgs<Color> e = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
		((RoutedEventArgs)e).RoutedEvent = SelectedColorChangedEvent;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
	}

	private static void OnUsingAlphaChannelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorPicker)(object)d)?.OnUsingAlphaChannelChanged();
	}

	private void OnUsingAlphaChannelChanged()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		SelectedColorText = GetFormatedColorString(SelectedColor);
	}

	static ColorPicker()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected Obj, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Obj, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected Obj, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Obj, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Obj, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected Obj, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected Obj, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected Obj, but got Unknown
		AvailableColorsProperty = DependencyProperty.Register("AvailableColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)CreateAvailableColors()));
		AvailableColorsHeaderProperty = DependencyProperty.Register("AvailableColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)"Available Colors"));
		ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(ColorPicker));
		DisplayColorAndNameProperty = DependencyProperty.Register("DisplayColorAndName", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)false));
		ColorModeProperty = DependencyProperty.Register("ColorMode", typeof(ColorMode), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)ColorMode.ColorPalette));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)false));
		RecentColorsProperty = DependencyProperty.Register("RecentColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		RecentColorsHeaderProperty = DependencyProperty.Register("RecentColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)"Recent Colors"));
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)Colors.Black, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnSelectedColorPropertyChanged));
		SelectedColorTextProperty = DependencyProperty.Register("SelectedColorText", typeof(string), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)"Black"));
		ShowAdvancedButtonProperty = DependencyProperty.Register("ShowAdvancedButton", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowAvailableColorsProperty = DependencyProperty.Register("ShowAvailableColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowRecentColorsProperty = DependencyProperty.Register("ShowRecentColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)false));
		ShowStandardColorsProperty = DependencyProperty.Register("ShowStandardColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowDropDownButtonProperty = DependencyProperty.Register("ShowDropDownButton", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)true));
		StandardColorsProperty = DependencyProperty.Register("StandardColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)CreateStandardColors()));
		StandardColorsHeaderProperty = DependencyProperty.Register("StandardColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)new UIPropertyMetadata((object)"Standard Colors"));
		UsingAlphaChannelProperty = DependencyProperty.Register("UsingAlphaChannel", typeof(bool), typeof(ColorPicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)true, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnUsingAlphaChannelPropertyChanged));
		SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ColorPicker)));
	}

	public ColorPicker()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		RecentColors = new ObservableCollection<ColorItem>();
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_availableColors != null)
		{
			((Selector)_availableColors).SelectionChanged -= Color_SelectionChanged;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_AvailableColors");
		_availableColors = (ListBox)(object)((templateChild is ListBox) ? templateChild : null);
		if (_availableColors != null)
		{
			((Selector)_availableColors).SelectionChanged += Color_SelectionChanged;
		}
		if (_standardColors != null)
		{
			((Selector)_standardColors).SelectionChanged -= Color_SelectionChanged;
		}
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_StandardColors");
		_standardColors = (ListBox)(object)((templateChild2 is ListBox) ? templateChild2 : null);
		if (_standardColors != null)
		{
			((Selector)_standardColors).SelectionChanged += Color_SelectionChanged;
		}
		if (_recentColors != null)
		{
			((Selector)_recentColors).SelectionChanged -= Color_SelectionChanged;
		}
		DependencyObject templateChild3 = ((FrameworkElement)this).GetTemplateChild("PART_RecentColors");
		_recentColors = (ListBox)(object)((templateChild3 is ListBox) ? templateChild3 : null);
		if (_recentColors != null)
		{
			((Selector)_recentColors).SelectionChanged += Color_SelectionChanged;
		}
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		DependencyObject templateChild4 = ((FrameworkElement)this).GetTemplateChild("PART_ColorPickerPalettePopup");
		_popup = (Popup)(object)((templateChild4 is Popup) ? templateChild4 : null);
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
		object obj = ((FrameworkTemplate)((Control)this).Template).FindName("PART_ColorPickerToggleButton", (FrameworkElement)(object)this);
		_toggleButton = (ToggleButton)((obj is ToggleButton) ? obj : null);
		if (_colorModeButton != null)
		{
			((ButtonBase)_colorModeButton).Click -= ColorModeButton_Clicked;
		}
		object obj2 = ((FrameworkTemplate)((Control)this).Template).FindName("PART_ColorModeButton", (FrameworkElement)(object)this);
		_colorModeButton = (Button)((obj2 is Button) ? obj2 : null);
		if (_colorModeButton != null)
		{
			((ButtonBase)_colorModeButton).Click += ColorModeButton_Clicked;
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
			CloseColorPicker(isFocusOnColorPicker: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			CloseColorPicker(isFocusOnColorPicker: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseColorPicker(isFocusOnColorPicker: false);
	}

	private void Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		ListBox val = (ListBox)sender;
		if (e.AddedItems.Count > 0)
		{
			ColorItem colorItem = (ColorItem)e.AddedItems[0];
			SelectedColor = colorItem.Color;
			UpdateRecentColors(colorItem);
			CloseColorPicker(isFocusOnColorPicker: true);
			((Selector)val).SelectedIndex = -1;
		}
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		if (_availableColors != null && ShowAvailableColors)
		{
			FocusOnListBoxItem(_availableColors);
		}
		else if (_standardColors != null && ShowStandardColors)
		{
			FocusOnListBoxItem(_standardColors);
		}
		else if (_recentColors != null && ShowRecentColors)
		{
			FocusOnListBoxItem(_recentColors);
		}
	}

	private void FocusOnListBoxItem(ListBox listBox)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		ListBoxItem val = (ListBoxItem)((ItemsControl)listBox).ItemContainerGenerator.ContainerFromItem(((Selector)listBox).SelectedItem);
		if (val == null && ((CollectionView)((ItemsControl)listBox).Items).Count > 0)
		{
			val = (ListBoxItem)((ItemsControl)listBox).ItemContainerGenerator.ContainerFromItem(((ItemsControl)listBox).Items[0]);
		}
		if (val != null)
		{
			((UIElement)val).Focus();
		}
	}

	private void ColorModeButton_Clicked(object sender, RoutedEventArgs e)
	{
		ColorMode = ((ColorMode == ColorMode.ColorPalette) ? ColorMode.ColorCanvas : ColorMode.ColorPalette);
	}

	private void CloseColorPicker(bool isFocusOnColorPicker)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (IsOpen)
		{
			IsOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
		if (isFocusOnColorPicker && _toggleButton != null)
		{
			((UIElement)_toggleButton).Focus();
		}
		UpdateRecentColors(new ColorItem(SelectedColor, SelectedColorText));
	}

	private void UpdateRecentColors(ColorItem colorItem)
	{
		if (!RecentColors.Contains(colorItem))
		{
			RecentColors.Add(colorItem);
		}
		if (RecentColors.Count > 10)
		{
			RecentColors.RemoveAt(0);
		}
	}

	private string GetFormatedColorString(Color colorToFormat)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return ColorUtilities.FormatColorString(colorToFormat.GetColorName(), UsingAlphaChannel);
	}

	private static ObservableCollection<ColorItem> CreateStandardColors()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		ObservableCollection<ColorItem> observableCollection = new ObservableCollection<ColorItem>();
		observableCollection.Add(new ColorItem(Colors.Transparent, "Transparent"));
		observableCollection.Add(new ColorItem(Colors.White, "White"));
		observableCollection.Add(new ColorItem(Colors.Gray, "Gray"));
		observableCollection.Add(new ColorItem(Colors.Black, "Black"));
		observableCollection.Add(new ColorItem(Colors.Red, "Red"));
		observableCollection.Add(new ColorItem(Colors.Green, "Green"));
		observableCollection.Add(new ColorItem(Colors.Blue, "Blue"));
		observableCollection.Add(new ColorItem(Colors.Yellow, "Yellow"));
		observableCollection.Add(new ColorItem(Colors.Orange, "Orange"));
		observableCollection.Add(new ColorItem(Colors.Purple, "Purple"));
		return observableCollection;
	}

	private static ObservableCollection<ColorItem> CreateAvailableColors()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		ObservableCollection<ColorItem> observableCollection = new ObservableCollection<ColorItem>();
		foreach (KeyValuePair<string, Color> knownColor in ColorUtilities.KnownColors)
		{
			if (!string.Equals(knownColor.Key, "Transparent"))
			{
				ColorItem item = new ColorItem(knownColor.Value, knownColor.Key);
				if (!observableCollection.Contains(item))
				{
					observableCollection.Add(item);
				}
			}
		}
		return observableCollection;
	}
}
