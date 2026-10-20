using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Primitives;

public abstract class InputBase : Control
{
	public static readonly DependencyProperty CultureInfoProperty = DependencyProperty.Register("CultureInfo", typeof(CultureInfo), typeof(InputBase), (PropertyMetadata)new UIPropertyMetadata((object)CultureInfo.CurrentCulture, (PropertyChangedCallback)OnCultureInfoChanged));

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(InputBase), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnReadOnlyChanged));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(InputBase), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnTextChanged, (CoerceValueCallback)null, false, (UpdateSourceTrigger)2));

	public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(InputBase), (PropertyMetadata)new UIPropertyMetadata((object)(TextAlignment)0));

	public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(InputBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(InputBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public CultureInfo CultureInfo
	{
		get
		{
			return (CultureInfo)((DependencyObject)this).GetValue(CultureInfoProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CultureInfoProperty, (object)value);
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public TextAlignment TextAlignment
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (TextAlignment)((DependencyObject)this).GetValue(TextAlignmentProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(TextAlignmentProperty, (object)value);
		}
	}

	public object Watermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(WatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkProperty, value);
		}
	}

	public DataTemplate WatermarkTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(WatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkTemplateProperty, (object)value);
		}
	}

	private static void OnCultureInfoChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnCultureInfoChanged((CultureInfo)e.OldValue, (CultureInfo)e.NewValue);
		}
	}

	protected virtual void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
	}

	private static void OnReadOnlyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnReadOnlyChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnReadOnlyChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnTextChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
	}

	static InputBase()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
	}
}
