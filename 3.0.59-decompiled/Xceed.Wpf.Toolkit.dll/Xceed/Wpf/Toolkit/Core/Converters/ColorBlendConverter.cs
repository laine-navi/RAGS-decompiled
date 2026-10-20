using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class ColorBlendConverter : IValueConverter
{
	private double _blendedColorRatio;

	public double BlendedColorRatio
	{
		get
		{
			return _blendedColorRatio;
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentException("BlendedColorRatio must greater than or equal to 0 and lower than or equal to 1 ");
			}
			_blendedColorRatio = value;
		}
	}

	public Color BlendedColor
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return field;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			field = value;
		}
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (value == null || value.GetType() != typeof(Color))
		{
			return null;
		}
		Color val = (Color)value;
		Color val2 = default;
		byte a = val.A;
		Color blendedColor = BlendedColor;
		val2.A = BlendValue(a, blendedColor.A);
		byte r = val.R;
		Color blendedColor2 = BlendedColor;
		val2.R = BlendValue(r, blendedColor2.R);
		byte g = val.G;
		Color blendedColor3 = BlendedColor;
		val2.G = BlendValue(g, blendedColor3.G);
		byte b = val.B;
		Color blendedColor4 = BlendedColor;
		val2.B = BlendValue(b, blendedColor4.B);
		return val2;
	}

	private byte BlendValue(byte original, byte blend)
	{
		double blendedColorRatio = BlendedColorRatio;
		double num = 1.0 - blendedColorRatio;
		double a = (double)(int)original * num + (double)(int)blend * blendedColorRatio;
		a = Math.Round(a);
		a = Math.Min(255.0, Math.Max(0.0, a));
		return System.Convert.ToByte(a);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
