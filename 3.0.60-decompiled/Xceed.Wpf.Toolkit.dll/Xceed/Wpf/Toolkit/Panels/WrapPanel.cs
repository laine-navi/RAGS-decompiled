using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public class WrapPanel : AnimationPanel
{
	public static readonly DependencyProperty OrientationProperty = StackPanel.OrientationProperty.AddOwner(typeof(WrapPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)(Orientation)0, (PropertyChangedCallback)OnOrientationChanged));

	private Orientation _orientation;

	public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register("ItemWidth", typeof(double), typeof(WrapPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)double.NaN, (PropertyChangedCallback)OnInvalidateMeasure), (ValidateValueCallback)IsWidthHeightValid);

	public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register("ItemHeight", typeof(double), typeof(WrapPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)double.NaN, (PropertyChangedCallback)OnInvalidateMeasure), (ValidateValueCallback)IsWidthHeightValid);

	public static readonly DependencyProperty IsStackReversedProperty = DependencyProperty.Register("IsChildOrderReversed", typeof(bool), typeof(WrapPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)OnInvalidateMeasure));

	public Orientation Orientation
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _orientation;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	[TypeConverter(typeof(LengthConverter))]
	public double ItemWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ItemWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemWidthProperty, (object)value);
		}
	}

	[TypeConverter(typeof(LengthConverter))]
	public double ItemHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ItemHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemHeightProperty, (object)value);
		}
	}

	public bool IsChildOrderReversed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsStackReversedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsStackReversedProperty, (object)value);
		}
	}

	private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		WrapPanel wrapPanel = (WrapPanel)(object)d;
		wrapPanel._orientation = (Orientation)e.NewValue;
		wrapPanel.InvalidateMeasure();
	}

	protected override Size MeasureChildrenOverride(UIElementCollection children, Size constraint)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		double val = 0.0;
		double num = 0.0;
		bool flag = (int)Orientation == 0;
		double num2 = (flag ? constraint.Width : constraint.Height);
		double itemWidth = ItemWidth;
		double itemHeight = ItemHeight;
		bool flag2 = !double.IsNaN(itemWidth);
		bool flag3 = !double.IsNaN(itemHeight);
		double num3 = 0.0;
		double num4 = 0.0;
		Size val2 = new Size(flag2 ? itemWidth : constraint.Width, flag3 ? itemHeight : constraint.Height);
		bool isChildOrderReversed = IsChildOrderReversed;
		int num5 = (isChildOrderReversed ? (children.Count - 1) : 0);
		if (!isChildOrderReversed)
		{
			_ = children.Count;
		}
		int num6 = ((!isChildOrderReversed) ? 1 : (-1));
		int num7 = num5;
		for (int i = 0; i < children.Count; i++)
		{
			UIElement val3 = children[num7];
			val3.Measure(val2);
			double num8;
			if (!flag)
			{
				if (!flag3)
				{
					Size desiredSize = val3.DesiredSize;
					num8 = desiredSize.Height;
				}
				else
				{
					num8 = itemHeight;
				}
			}
			else if (!flag2)
			{
				Size desiredSize2 = val3.DesiredSize;
				num8 = desiredSize2.Width;
			}
			else
			{
				num8 = itemWidth;
			}
			double num9 = num8;
			double num10;
			if (!flag)
			{
				if (!flag2)
				{
					Size desiredSize3 = val3.DesiredSize;
					num10 = desiredSize3.Width;
				}
				else
				{
					num10 = itemWidth;
				}
			}
			else if (!flag3)
			{
				Size desiredSize4 = val3.DesiredSize;
				num10 = desiredSize4.Height;
			}
			else
			{
				num10 = itemHeight;
			}
			double num11 = num10;
			if (num3 + num9 > num2)
			{
				val = Math.Max(num3, val);
				num += num4;
				num3 = num9;
				num4 = num11;
				if (num9 > num2)
				{
					val = Math.Max(num9, val);
					num += num11;
					num3 = 0.0;
					num4 = 0.0;
				}
			}
			else
			{
				num3 += num9;
				num4 = Math.Max(num11, num4);
			}
			num7 += num6;
		}
		val = Math.Max(num3, val);
		num += num4;
		if (!flag)
		{
			return new Size(num, val);
		}
		return new Size(val, num);
	}

	protected override Size ArrangeChildrenOverride(UIElementCollection children, Size finalSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		bool flag = (int)Orientation == 0;
		double num = (flag ? finalSize.Width : finalSize.Height);
		double itemWidth = ItemWidth;
		double itemHeight = ItemHeight;
		double itemExtent = (flag ? itemWidth : itemHeight);
		bool flag2 = !double.IsNaN(itemWidth);
		bool flag3 = !double.IsNaN(itemHeight);
		bool useItemExtent = (flag ? flag2 : flag3);
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = (IsChildOrderReversed ? (children.Count - 1) : 0);
		if (!IsChildOrderReversed)
		{
			_ = children.Count;
		}
		int num6 = ((!IsChildOrderReversed) ? 1 : (-1));
		Collection<UIElement> collection = new Collection<UIElement>();
		int num7 = num5;
		for (int i = 0; i < children.Count; i++)
		{
			UIElement val = children[num7];
			double num8;
			if (!flag)
			{
				if (!flag3)
				{
					Size desiredSize = val.DesiredSize;
					num8 = desiredSize.Height;
				}
				else
				{
					num8 = itemHeight;
				}
			}
			else if (!flag2)
			{
				Size desiredSize2 = val.DesiredSize;
				num8 = desiredSize2.Width;
			}
			else
			{
				num8 = itemWidth;
			}
			double num9 = num8;
			double num10;
			if (!flag)
			{
				if (!flag2)
				{
					Size desiredSize3 = val.DesiredSize;
					num10 = desiredSize3.Width;
				}
				else
				{
					num10 = itemWidth;
				}
			}
			else if (!flag3)
			{
				Size desiredSize4 = val.DesiredSize;
				num10 = desiredSize4.Height;
			}
			else
			{
				num10 = itemHeight;
			}
			double num11 = num10;
			if (num2 + num9 > num)
			{
				ArrangeLineOfChildren(collection, flag, num3, num4, itemExtent, useItemExtent);
				num4 += num3;
				num2 = num9;
				if (num9 > num)
				{
					collection.Add(val);
					ArrangeLineOfChildren(collection, flag, num11, num4, itemExtent, useItemExtent);
					num4 += num11;
					num2 = 0.0;
				}
				collection.Add(val);
			}
			else
			{
				collection.Add(val);
				num2 += num9;
				num3 = Math.Max(num11, num3);
			}
			num7 += num6;
		}
		if (collection.Count > 0)
		{
			ArrangeLineOfChildren(collection, flag, num3, num4, itemExtent, useItemExtent);
		}
		return finalSize;
	}

	private void ArrangeLineOfChildren(Collection<UIElement> children, bool isHorizontal, double lineStack, double lineStackSum, double itemExtent, bool useItemExtent)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		foreach (UIElement child in children)
		{
			double num2;
			if (!isHorizontal)
			{
				Size desiredSize = child.DesiredSize;
				num2 = desiredSize.Height;
			}
			else
			{
				Size desiredSize2 = child.DesiredSize;
				num2 = desiredSize2.Width;
			}
			double num3 = num2;
			double num4 = (useItemExtent ? itemExtent : num3);
			ArrangeChild(child, isHorizontal ? new Rect(num, lineStackSum, num4, lineStack) : new Rect(lineStackSum, num, lineStack, num4));
			num += num4;
		}
		children.Clear();
	}

	private static void OnInvalidateMeasure(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnimationPanel)(object)d).InvalidateMeasure();
	}

	private static bool IsWidthHeightValid(object value)
	{
		double num = (double)value;
		if (!DoubleHelper.IsNaN(num))
		{
			if (num >= 0.0)
			{
				return !double.IsPositiveInfinity(num);
			}
			return false;
		}
		return true;
	}

	static WrapPanel()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0079: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
	}
}
