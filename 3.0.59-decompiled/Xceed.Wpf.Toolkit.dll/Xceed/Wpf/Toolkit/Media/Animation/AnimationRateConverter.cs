using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Xceed.Wpf.Toolkit.Media.Animation;

public class AnimationRateConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext td, Type t)
	{
		if (!(t == typeof(string)) && !(t == typeof(double)) && !(t == typeof(int)))
		{
			return t == typeof(TimeSpan);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(InstanceDescriptor)) && !(destinationType == typeof(string)) && !(destinationType == typeof(double)))
		{
			return destinationType == typeof(TimeSpan);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext td, CultureInfo cultureInfo, object value)
	{
		Type type = value.GetType();
		if (value is string)
		{
			if ((value as string).Contains(":"))
			{
				TimeSpan zero = TimeSpan.Zero;
				zero = (TimeSpan)TypeDescriptor.GetConverter(zero).ConvertFrom(td, cultureInfo, value);
				return new AnimationRate(zero);
			}
			double num = 0.0;
			num = (double)TypeDescriptor.GetConverter(num).ConvertFrom(td, cultureInfo, value);
			return new AnimationRate(num);
		}
		if (type == typeof(double))
		{
			return (AnimationRate)(double)value;
		}
		if (type == typeof(int))
		{
			return (AnimationRate)(int)value;
		}
		return (AnimationRate)(TimeSpan)value;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo cultureInfo, object value, Type destinationType)
	{
		if (destinationType != null && value is AnimationRate animationRate)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (animationRate.HasDuration)
				{
					MemberInfo constructor = typeof(AnimationRate).GetConstructor(new Type[1] { typeof(TimeSpan) });
					return new InstanceDescriptor(constructor, new object[1] { animationRate.Duration });
				}
				if (animationRate.HasSpeed)
				{
					MemberInfo constructor = typeof(AnimationRate).GetConstructor(new Type[1] { typeof(double) });
					return new InstanceDescriptor(constructor, new object[1] { animationRate.Speed });
				}
			}
			else
			{
				if (destinationType == typeof(string))
				{
					return animationRate.ToString();
				}
				if (destinationType == typeof(double))
				{
					return animationRate.HasSpeed ? animationRate.Speed : 0.0;
				}
				if (destinationType == typeof(TimeSpan))
				{
					return animationRate.HasDuration ? animationRate.Duration : TimeSpan.FromSeconds(0.0);
				}
			}
		}
		return base.ConvertTo(context, cultureInfo, value, destinationType);
	}
}
