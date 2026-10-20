using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_SpectrumDisplay", Type = typeof(Rectangle))]
public class ColorSpectrumSlider : Slider
{
	private const string PART_SpectrumDisplay = "PART_SpectrumDisplay";

	private Rectangle _spectrumDisplay;

	private LinearGradientBrush _pickerBrush;

	public static readonly DependencyProperty SelectedColorProperty;

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

	static ColorSpectrumSlider()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorSpectrumSlider), new PropertyMetadata((object)Colors.Transparent));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSpectrumSlider), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ColorSpectrumSlider)));
	}

	public override void OnApplyTemplate()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		((Slider)this).OnApplyTemplate();
		_spectrumDisplay = (Rectangle)((FrameworkElement)this).GetTemplateChild("PART_SpectrumDisplay");
		CreateSpectrum();
		((RangeBase)this).OnValueChanged(double.NaN, ((RangeBase)this).Value);
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		((Slider)this).OnValueChanged(oldValue, newValue);
		Color selectedColor = ColorUtilities.ConvertHsvToRgb(360.0 - newValue, 1.0, 1.0);
		SelectedColor = selectedColor;
	}

	private void CreateSpectrum()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		_pickerBrush = new LinearGradientBrush();
		_pickerBrush.StartPoint = new Point(0.5, 0.0);
		_pickerBrush.EndPoint = new Point(0.5, 1.0);
		((GradientBrush)_pickerBrush).ColorInterpolationMode = (ColorInterpolationMode)1;
		List<Color> list = ColorUtilities.GenerateHsvSpectrum();
		double num = 1.0 / (double)list.Count;
		int i;
		for (i = 0; i < list.Count; i++)
		{
			((GradientBrush)_pickerBrush).GradientStops.Add(new GradientStop(list[i], (double)i * num));
		}
		((GradientBrush)_pickerBrush).GradientStops[i - 1].Offset = 1.0;
		((Shape)_spectrumDisplay).Fill = (Brush)(object)_pickerBrush;
	}
}
