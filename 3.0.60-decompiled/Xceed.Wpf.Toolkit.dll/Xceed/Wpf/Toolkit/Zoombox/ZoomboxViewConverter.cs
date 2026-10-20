using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public sealed class ZoomboxViewConverter : TypeConverter
{
	private static ZoomboxViewConverter _converter;

	internal static ZoomboxViewConverter Converter
	{
		get
		{
			if (_converter == null)
			{
				_converter = new ZoomboxViewConverter();
			}
			return _converter;
		}
	}

	public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		if (!(type == typeof(string)) && !(type == typeof(double)) && !(type == typeof(Point)) && !(type == typeof(Rect)))
		{
			return base.CanConvertFrom(typeDescriptorContext, type);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		if (!(type == typeof(string)))
		{
			return base.CanConvertTo(typeDescriptorContext, type);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		ZoomboxView zoomboxView = null;
		if (value is double)
		{
			zoomboxView = new ZoomboxView((double)value);
		}
		else if (value is Point)
		{
			zoomboxView = new ZoomboxView((Point)value);
		}
		else if (value is Rect)
		{
			zoomboxView = new ZoomboxView((Rect)value);
		}
		else if (value is string)
		{
			if (string.IsNullOrEmpty((value as string).Trim()))
			{
				zoomboxView = ZoomboxView.Empty;
			}
			else
			{
				switch ((value as string).Trim().ToLower())
				{
				case "center":
					zoomboxView = ZoomboxView.Center;
					break;
				case "empty":
					zoomboxView = ZoomboxView.Empty;
					break;
				case "fill":
					zoomboxView = ZoomboxView.Fill;
					break;
				case "fit":
					zoomboxView = ZoomboxView.Fit;
					break;
				default:
				{
					List<double> list = new List<double>();
					string[] array = (value as string).Split(new char[3] { ' ', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
					foreach (string s in array)
					{
						if (double.TryParse(s, out var result))
						{
							list.Add(result);
						}
						if (list.Count >= 4)
						{
							break;
						}
					}
					switch (list.Count)
					{
					case 1:
						zoomboxView = new ZoomboxView(list[0]);
						break;
					case 2:
						zoomboxView = new ZoomboxView(list[0], list[1]);
						break;
					case 3:
						zoomboxView = new ZoomboxView(list[0], list[1], list[2]);
						break;
					case 4:
						zoomboxView = new ZoomboxView(list[0], list[1], list[2], list[3]);
						break;
					}
					break;
				}
				}
			}
		}
		if (!(zoomboxView == null))
		{
			return zoomboxView;
		}
		return base.ConvertFrom(typeDescriptorContext, cultureInfo, value);
	}

	public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		object obj = null;
		ZoomboxView zoomboxView = value as ZoomboxView;
		if (zoomboxView != null && destinationType == typeof(string))
		{
			obj = "Empty";
			switch (zoomboxView.ViewKind)
			{
			case ZoomboxViewKind.Absolute:
			{
				if (PointHelper.IsEmpty(zoomboxView.Position))
				{
					if (!DoubleHelper.IsNaN(zoomboxView.Scale))
					{
						obj = zoomboxView.Scale.ToString();
					}
					break;
				}
				if (DoubleHelper.IsNaN(zoomboxView.Scale))
				{
					Point position = zoomboxView.Position;
					string text = position.X.ToString();
					Point position2 = zoomboxView.Position;
					obj = text + "," + position2.Y;
					break;
				}
				string[] array2 = new string[5]
				{
					zoomboxView.Scale.ToString(),
					",",
					null,
					null,
					null
				};
				Point position3 = zoomboxView.Position;
				array2[2] = position3.X.ToString();
				array2[3] = ",";
				Point position4 = zoomboxView.Position;
				array2[4] = position4.Y.ToString();
				obj = string.Concat(array2);
				break;
			}
			case ZoomboxViewKind.Center:
				obj = "Center";
				break;
			case ZoomboxViewKind.Fill:
				obj = "Fill";
				break;
			case ZoomboxViewKind.Fit:
				obj = "Fit";
				break;
			case ZoomboxViewKind.Region:
			{
				string[] array = new string[7];
				Rect region = zoomboxView.Region;
				array[0] = region.X.ToString();
				array[1] = ",";
				Rect region2 = zoomboxView.Region;
				array[2] = region2.Y.ToString();
				array[3] = ",";
				Rect region3 = zoomboxView.Region;
				array[4] = region3.Width.ToString();
				array[5] = ",";
				Rect region4 = zoomboxView.Region;
				array[6] = region4.Height.ToString();
				obj = string.Concat(array);
				break;
			}
			}
		}
		if (obj != null)
		{
			return obj;
		}
		return base.ConvertTo(typeDescriptorContext, cultureInfo, value, destinationType);
	}
}
