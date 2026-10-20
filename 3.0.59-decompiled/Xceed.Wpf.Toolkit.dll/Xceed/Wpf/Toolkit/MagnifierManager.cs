using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class MagnifierManager : DependencyObject
{
	private MagnifierAdorner _adorner;

	private UIElement _element;

	public static readonly DependencyProperty CurrentProperty = DependencyProperty.RegisterAttached("Magnifier", typeof(Magnifier), typeof(UIElement), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnMagnifierChanged));

	public static void SetMagnifier(UIElement element, Magnifier value)
	{
		((DependencyObject)element).SetValue(CurrentProperty, (object)value);
	}

	public static Magnifier GetMagnifier(UIElement element)
	{
		return (Magnifier)((DependencyObject)element).GetValue(CurrentProperty);
	}

	private static void OnMagnifierChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		UIElement val = (UIElement)(object)((d is UIElement) ? d : null);
		if (val == null)
		{
			throw new ArgumentException("Magnifier can only be attached to a UIElement.");
		}
		MagnifierManager magnifierManager = new MagnifierManager();
		magnifierManager.AttachToMagnifier(val, e.NewValue as Magnifier);
	}

	private void Element_MouseLeave(object sender, MouseEventArgs e)
	{
		HideAdorner();
	}

	private void Element_MouseEnter(object sender, MouseEventArgs e)
	{
		ShowAdorner();
	}

	private void AttachToMagnifier(UIElement element, Magnifier magnifier)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		_element = element;
		_element.MouseEnter += Element_MouseEnter;
		_element.MouseLeave += Element_MouseLeave;
		magnifier.Target = _element;
		_adorner = new MagnifierAdorner(_element, magnifier);
	}

	private void ShowAdorner()
	{
		VerifyAdornerLayer();
		((UIElement)_adorner).Visibility = (Visibility)0;
	}

	private bool VerifyAdornerLayer()
	{
		if (((FrameworkElement)_adorner).Parent != null)
		{
			return true;
		}
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)(object)_element);
		if (adornerLayer == null)
		{
			return false;
		}
		adornerLayer.Add((Adorner)(object)_adorner);
		return true;
	}

	private void HideAdorner()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((UIElement)_adorner).Visibility == 0)
		{
			((UIElement)_adorner).Visibility = (Visibility)2;
		}
	}

	static MagnifierManager()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
	}
}
