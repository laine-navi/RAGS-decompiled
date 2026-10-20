using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

public abstract class Spinner : Control
{
	public static readonly DependencyProperty ValidSpinDirectionProperty = DependencyProperty.Register("ValidSpinDirection", typeof(ValidSpinDirections), typeof(Spinner), new PropertyMetadata((object)(ValidSpinDirections.Increase | ValidSpinDirections.Decrease), (PropertyChangedCallback)OnValidSpinDirectionPropertyChanged));

	public ValidSpinDirections ValidSpinDirection
	{
		get
		{
			return (ValidSpinDirections)((DependencyObject)this).GetValue(ValidSpinDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValidSpinDirectionProperty, (object)value);
		}
	}

	public event EventHandler<SpinEventArgs> Spin;

	private static void OnValidSpinDirectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Spinner spinner = (Spinner)(object)d;
		ValidSpinDirections oldValue = (ValidSpinDirections)e.OldValue;
		ValidSpinDirections newValue = (ValidSpinDirections)e.NewValue;
		spinner.OnValidSpinDirectionChanged(oldValue, newValue);
	}

	protected virtual void OnSpin(SpinEventArgs e)
	{
		ValidSpinDirections validSpinDirections = ((e.Direction == SpinDirection.Increase) ? ValidSpinDirections.Increase : ValidSpinDirections.Decrease);
		if ((ValidSpinDirection & validSpinDirections) == validSpinDirections)
		{
			Spin?.Invoke(this, e);
		}
	}

	protected virtual void OnValidSpinDirectionChanged(ValidSpinDirections oldValue, ValidSpinDirections newValue)
	{
	}

	static Spinner()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
	}
}
