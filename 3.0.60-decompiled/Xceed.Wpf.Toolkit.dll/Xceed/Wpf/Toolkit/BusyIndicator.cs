using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Xceed.Wpf.Toolkit;

[TemplateVisualState(Name = "Visible", GroupName = "VisibilityStates")]
[StyleTypedProperty(Property = "OverlayStyle", StyleTargetType = typeof(Rectangle))]
[TemplateVisualState(Name = "Idle", GroupName = "BusyStatusStates")]
[TemplateVisualState(Name = "Busy", GroupName = "BusyStatusStates")]
[StyleTypedProperty(Property = "ProgressBarStyle", StyleTargetType = typeof(ProgressBar))]
[TemplateVisualState(Name = "Hidden", GroupName = "VisibilityStates")]
public class BusyIndicator : ContentControl
{
	private DispatcherTimer _displayAfterTimer = new DispatcherTimer();

	public static readonly DependencyProperty IsBusyProperty;

	public static readonly DependencyProperty BusyContentProperty;

	public static readonly DependencyProperty BusyContentTemplateProperty;

	public static readonly DependencyProperty DisplayAfterProperty;

	public static readonly DependencyProperty FocusAferBusyProperty;

	public static readonly DependencyProperty OverlayStyleProperty;

	public static readonly DependencyProperty ProgressBarStyleProperty;

	protected bool IsContentVisible { get; set; }

	public bool IsBusy
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsBusyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsBusyProperty, (object)value);
		}
	}

	public object BusyContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(BusyContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BusyContentProperty, value);
		}
	}

	public DataTemplate BusyContentTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(BusyContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BusyContentTemplateProperty, (object)value);
		}
	}

	public TimeSpan DisplayAfter
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(DisplayAfterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayAfterProperty, (object)value);
		}
	}

	public Control FocusAferBusy
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Control)((DependencyObject)this).GetValue(FocusAferBusyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusAferBusyProperty, (object)value);
		}
	}

	public Style OverlayStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(OverlayStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayStyleProperty, (object)value);
		}
	}

	public Style ProgressBarStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(ProgressBarStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ProgressBarStyleProperty, (object)value);
		}
	}

	static BusyIndicator()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected Obj, but got Unknown
		IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(BusyIndicator), new PropertyMetadata((object)false, (PropertyChangedCallback)OnIsBusyChanged));
		BusyContentProperty = DependencyProperty.Register("BusyContent", typeof(object), typeof(BusyIndicator), new PropertyMetadata((PropertyChangedCallback)null));
		BusyContentTemplateProperty = DependencyProperty.Register("BusyContentTemplate", typeof(DataTemplate), typeof(BusyIndicator), new PropertyMetadata((PropertyChangedCallback)null));
		DisplayAfterProperty = DependencyProperty.Register("DisplayAfter", typeof(TimeSpan), typeof(BusyIndicator), new PropertyMetadata((object)TimeSpan.FromSeconds(0.1)));
		FocusAferBusyProperty = DependencyProperty.Register("FocusAferBusy", typeof(Control), typeof(BusyIndicator), new PropertyMetadata((PropertyChangedCallback)null));
		OverlayStyleProperty = DependencyProperty.Register("OverlayStyle", typeof(Style), typeof(BusyIndicator), new PropertyMetadata((PropertyChangedCallback)null));
		ProgressBarStyleProperty = DependencyProperty.Register("ProgressBarStyle", typeof(Style), typeof(BusyIndicator), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BusyIndicator), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(BusyIndicator)));
	}

	public BusyIndicator()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		_displayAfterTimer.Tick += DisplayAfterTimerElapsed;
	}

	public override void OnApplyTemplate()
	{
		((FrameworkElement)this).OnApplyTemplate();
		ChangeVisualState(useTransitions: false);
	}

	private static void OnIsBusyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((BusyIndicator)(object)d).OnIsBusyChanged(e);
	}

	protected virtual void OnIsBusyChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsBusy)
		{
			if (DisplayAfter.Equals(TimeSpan.Zero))
			{
				IsContentVisible = true;
			}
			else
			{
				_displayAfterTimer.Interval = DisplayAfter;
				_displayAfterTimer.Start();
			}
		}
		else
		{
			_displayAfterTimer.Stop();
			IsContentVisible = false;
			if (FocusAferBusy != null)
			{
				((DispatcherObject)FocusAferBusy).Dispatcher.BeginInvoke((DispatcherPriority)5, (Delegate)(Action)(() =>
				{
					((UIElement)FocusAferBusy).Focus();
					FocusAferBusy = null;
				}));
			}
		}
		ChangeVisualState(useTransitions: true);
	}

	private void DisplayAfterTimerElapsed(object sender, EventArgs e)
	{
		_displayAfterTimer.Stop();
		IsContentVisible = true;
		ChangeVisualState(useTransitions: true);
	}

	protected virtual void ChangeVisualState(bool useTransitions)
	{
		VisualStateManager.GoToState((FrameworkElement)(object)this, IsBusy ? "Busy" : "Idle", useTransitions);
		VisualStateManager.GoToState((FrameworkElement)(object)this, IsContentVisible ? "Visible" : "Hidden", useTransitions);
	}
}
