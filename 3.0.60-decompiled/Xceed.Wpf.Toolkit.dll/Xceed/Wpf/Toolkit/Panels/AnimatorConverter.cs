using System;
using System.ComponentModel;
using System.Globalization;

namespace Xceed.Wpf.Toolkit.Panels;

public sealed class AnimatorConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		return type == typeof(string);
	}

	public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		if (!(type == typeof(IterativeAnimator)))
		{
			return type == typeof(DoubleAnimator);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value)
	{
		IterativeAnimator result = null;
		if (value is string)
		{
			switch (value as string)
			{
			case "BackEaseIn":
				result = Animators.BackEaseIn;
				break;
			case "BackEaseInOut":
				result = Animators.BackEaseInOut;
				break;
			case "BackEaseOut":
				result = Animators.BackEaseOut;
				break;
			case "BounceEaseIn":
				result = Animators.BounceEaseIn;
				break;
			case "BounceEaseInOut":
				result = Animators.BounceEaseInOut;
				break;
			case "BounceEaseOut":
				result = Animators.BounceEaseOut;
				break;
			case "CircEaseIn":
				result = Animators.CircEaseIn;
				break;
			case "CircEaseInOut":
				result = Animators.CircEaseInOut;
				break;
			case "CircEaseOut":
				result = Animators.CircEaseOut;
				break;
			case "CubicEaseIn":
				result = Animators.CubicEaseIn;
				break;
			case "CubicEaseInOut":
				result = Animators.CubicEaseInOut;
				break;
			case "CubicEaseOut":
				result = Animators.CubicEaseOut;
				break;
			case "ElasticEaseIn":
				result = Animators.ElasticEaseIn;
				break;
			case "ElasticEaseInOut":
				result = Animators.ElasticEaseInOut;
				break;
			case "ElasticEaseOut":
				result = Animators.ElasticEaseOut;
				break;
			case "ExpoEaseIn":
				result = Animators.ExpoEaseIn;
				break;
			case "ExpoEaseInOut":
				result = Animators.ExpoEaseInOut;
				break;
			case "ExpoEaseOut":
				result = Animators.ExpoEaseOut;
				break;
			case "Linear":
				result = Animators.Linear;
				break;
			case "QuadEaseIn":
				result = Animators.QuadEaseIn;
				break;
			case "QuadEaseInOut":
				result = Animators.QuadEaseInOut;
				break;
			case "QuadEaseOut":
				result = Animators.QuadEaseOut;
				break;
			case "QuartEaseIn":
				result = Animators.QuartEaseIn;
				break;
			case "QuartEaseInOut":
				result = Animators.QuartEaseInOut;
				break;
			case "QuartEaseOut":
				result = Animators.QuartEaseOut;
				break;
			case "QuintEaseIn":
				result = Animators.QuintEaseIn;
				break;
			case "QuintEaseInOut":
				result = Animators.QuintEaseInOut;
				break;
			case "QuintEaseOut":
				result = Animators.QuintEaseOut;
				break;
			case "SineEaseIn":
				result = Animators.SineEaseIn;
				break;
			case "SineEaseInOut":
				result = Animators.SineEaseInOut;
				break;
			case "SineEaseOut":
				result = Animators.SineEaseOut;
				break;
			}
		}
		return result;
	}
}
