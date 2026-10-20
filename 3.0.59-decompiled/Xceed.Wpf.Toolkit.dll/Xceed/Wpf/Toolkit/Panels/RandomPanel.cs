using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Panels;

public class RandomPanel : AnimationPanel
{
	public static readonly DependencyProperty MinimumWidthProperty = DependencyProperty.Register("MinimumWidth", typeof(double), typeof(RandomPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)10.0, (PropertyChangedCallback)OnMinimumWidthChanged, (CoerceValueCallback)CoerceMinimumWidth));

	public static readonly DependencyProperty MinimumHeightProperty = DependencyProperty.Register("MinimumHeight", typeof(double), typeof(RandomPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)10.0, (PropertyChangedCallback)OnMinimumHeightChanged, (CoerceValueCallback)CoerceMinimumHeight));

	public static readonly DependencyProperty MaximumWidthProperty = DependencyProperty.Register("MaximumWidth", typeof(double), typeof(RandomPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)100.0, (PropertyChangedCallback)OnMaximumWidthChanged, (CoerceValueCallback)CoerceMaximumWidth));

	public static readonly DependencyProperty MaximumHeightProperty = DependencyProperty.Register("MaximumHeight", typeof(double), typeof(RandomPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)100.0, (PropertyChangedCallback)OnMaximumHeightChanged, (CoerceValueCallback)CoerceMaximumHeight));

	public static readonly DependencyProperty SeedProperty = DependencyProperty.Register("Seed", typeof(int), typeof(RandomPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)0, (PropertyChangedCallback)SeedChanged));

	private static readonly DependencyProperty ActualSizeProperty = DependencyProperty.RegisterAttached("ActualSize", typeof(Size), typeof(RandomPanel), (PropertyMetadata)new UIPropertyMetadata((object)default(Size)));

	private Random _random = new Random();

	public double MinimumWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumWidthProperty, (object)value);
		}
	}

	public double MinimumHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumHeightProperty, (object)value);
		}
	}

	public double MaximumWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumWidthProperty, (object)value);
		}
	}

	public double MaximumHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumHeightProperty, (object)value);
		}
	}

	public int Seed
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SeedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SeedProperty, (object)value);
		}
	}

	private static void OnMinimumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		((DependencyObject)randomPanel).CoerceValue(MaximumWidthProperty);
		randomPanel.InvalidateMeasure();
	}

	private static object CoerceMinimumWidth(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double maximumWidth = randomPanel.MaximumWidth;
		if (num > maximumWidth)
		{
			return maximumWidth;
		}
		return baseValue;
	}

	private static void OnMinimumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		((DependencyObject)randomPanel).CoerceValue(MaximumHeightProperty);
		randomPanel.InvalidateMeasure();
	}

	private static object CoerceMinimumHeight(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double maximumHeight = randomPanel.MaximumHeight;
		if (num > maximumHeight)
		{
			return maximumHeight;
		}
		return baseValue;
	}

	private static void OnMaximumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		((DependencyObject)randomPanel).CoerceValue(MinimumWidthProperty);
		randomPanel.InvalidateMeasure();
	}

	private static object CoerceMaximumWidth(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double minimumWidth = randomPanel.MinimumWidth;
		if (num < minimumWidth)
		{
			return minimumWidth;
		}
		return baseValue;
	}

	private static void OnMaximumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		((DependencyObject)randomPanel).CoerceValue(MinimumHeightProperty);
		randomPanel.InvalidateMeasure();
	}

	private static object CoerceMaximumHeight(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double minimumHeight = randomPanel.MinimumHeight;
		if (num < minimumHeight)
		{
			return minimumHeight;
		}
		return baseValue;
	}

	private static void SeedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		if (obj is RandomPanel)
		{
			RandomPanel randomPanel = (RandomPanel)(object)obj;
			randomPanel._random = new Random((int)args.NewValue);
			randomPanel.InvalidateArrange();
		}
	}

	private static Size GetActualSize(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return (Size)obj.GetValue(ActualSizeProperty);
	}

	private static void SetActualSize(DependencyObject obj, Size value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		obj.SetValue(ActualSizeProperty, (object)value);
	}

	protected override Size MeasureChildrenOverride(UIElementCollection children, Size constraint)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		new Size(double.PositiveInfinity, double.PositiveInfinity);
		foreach (UIElement child in children)
		{
			UIElement val = child;
			if (val != null)
			{
				Size val2 = new Size(1.0 * (double)_random.Next(Convert.ToInt32(MinimumWidth), Convert.ToInt32(MaximumWidth)), 1.0 * (double)_random.Next(Convert.ToInt32(MinimumHeight), Convert.ToInt32(MaximumHeight)));
				val.Measure(val2);
				SetActualSize((DependencyObject)(object)val, val2);
			}
		}
		return default;
	}

	protected override Size ArrangeChildrenOverride(UIElementCollection children, Size finalSize)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		foreach (UIElement child in children)
		{
			UIElement val = child;
			if (val != null)
			{
				Size actualSize = GetActualSize((DependencyObject)(object)val);
				double num = _random.Next(0, (int)Math.Max(finalSize.Width - actualSize.Width, 0.0));
				double num2 = _random.Next(0, (int)Math.Max(finalSize.Height - actualSize.Height, 0.0));
				double num3 = Math.Min(finalSize.Width, actualSize.Width);
				double num4 = Math.Min(finalSize.Height, actualSize.Height);
				ArrangeChild(val, new Rect(new Point(num, num2), new Size(num3, num4)));
			}
		}
		return finalSize;
	}

	static RandomPanel()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0044: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_0092: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected Obj, but got Unknown
		//IL_00e0: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_012e: Expected Obj, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
	}
}
