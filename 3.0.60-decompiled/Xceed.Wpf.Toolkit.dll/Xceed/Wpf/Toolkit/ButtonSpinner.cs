using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

namespace Xceed.Wpf.Toolkit;

[ContentProperty("Content")]
[TemplatePart(Name = "PART_DecreaseButton", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_IncreaseButton", Type = typeof(ButtonBase))]
public class ButtonSpinner : Spinner
{
	private const string PART_IncreaseButton = "PART_IncreaseButton";

	private const string PART_DecreaseButton = "PART_DecreaseButton";

	public static readonly DependencyProperty AllowSpinProperty;

	public static readonly DependencyProperty ContentProperty;

	private ButtonBase _decreaseButton;

	private ButtonBase _increaseButton;

	public static readonly DependencyProperty ShowButtonSpinnerProperty;

	public bool AllowSpin
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSpinProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSpinProperty, (object)value);
		}
	}

	public object Content
	{
		get
		{
			return ((DependencyObject)this).GetValue(ContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentProperty, value);
		}
	}

	private ButtonBase DecreaseButton
	{
		get
		{
			return _decreaseButton;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected Obj, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected Obj, but got Unknown
			if (_decreaseButton != null)
			{
				_decreaseButton.Click -= OnButtonClick;
			}
			_decreaseButton = value;
			if (_decreaseButton != null)
			{
				_decreaseButton.Click += OnButtonClick;
			}
		}
	}

	private ButtonBase IncreaseButton
	{
		get
		{
			return _increaseButton;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected Obj, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected Obj, but got Unknown
			if (_increaseButton != null)
			{
				_increaseButton.Click -= OnButtonClick;
			}
			_increaseButton = value;
			if (_increaseButton != null)
			{
				_increaseButton.Click += OnButtonClick;
			}
		}
	}

	public bool ShowButtonSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowButtonSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowButtonSpinnerProperty, (object)value);
		}
	}

	private static void AllowSpinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		ButtonSpinner buttonSpinner = d as ButtonSpinner;
		buttonSpinner.OnAllowSpinChanged((bool)e.OldValue, (bool)e.NewValue);
	}

	private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		ButtonSpinner buttonSpinner = d as ButtonSpinner;
		buttonSpinner.OnContentChanged(e.OldValue, e.NewValue);
	}

	static ButtonSpinner()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		AllowSpinProperty = DependencyProperty.Register("AllowSpin", typeof(bool), typeof(ButtonSpinner), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)AllowSpinPropertyChanged));
		ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(ButtonSpinner), new PropertyMetadata((object)null, (PropertyChangedCallback)OnContentPropertyChanged));
		ShowButtonSpinnerProperty = DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(ButtonSpinner), (PropertyMetadata)new UIPropertyMetadata((object)true));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonSpinner), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ButtonSpinner)));
	}

	public override void OnApplyTemplate()
	{
		((FrameworkElement)this).OnApplyTemplate();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_IncreaseButton");
		IncreaseButton = (ButtonBase)(object)((templateChild is ButtonBase) ? templateChild : null);
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_DecreaseButton");
		DecreaseButton = (ButtonBase)(object)((templateChild2 is ButtonBase) ? templateChild2 : null);
		SetButtonUsage();
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)this).OnMouseLeftButtonUp(e);
		Point position;
		if (IncreaseButton != null && !((UIElement)IncreaseButton).IsEnabled)
		{
			position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)IncreaseButton);
			if (position.X > 0.0 && position.X < ((FrameworkElement)IncreaseButton).ActualWidth && position.Y > 0.0 && position.Y < ((FrameworkElement)IncreaseButton).ActualHeight)
			{
				((RoutedEventArgs)e).Handled = true;
			}
		}
		if (DecreaseButton != null && !((UIElement)DecreaseButton).IsEnabled)
		{
			position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)DecreaseButton);
			if (position.X > 0.0 && position.X < ((FrameworkElement)DecreaseButton).ActualWidth && position.Y > 0.0 && position.Y < ((FrameworkElement)DecreaseButton).ActualHeight)
			{
				((RoutedEventArgs)e).Handled = true;
			}
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected I4, but got Unknown
		Key key = e.Key;
		switch (key - 24)
		{
		case 0:
			if (AllowSpin)
			{
				OnSpin(new SpinEventArgs(SpinDirection.Increase));
				((RoutedEventArgs)e).Handled = true;
			}
			break;
		case 2:
			if (AllowSpin)
			{
				OnSpin(new SpinEventArgs(SpinDirection.Decrease));
				((RoutedEventArgs)e).Handled = true;
			}
			break;
		case 1:
			break;
		}
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		((UIElement)this).OnMouseWheel(e);
		if (!((RoutedEventArgs)e).Handled && AllowSpin)
		{
			if (e.Delta < 0)
			{
				OnSpin(new SpinEventArgs(SpinDirection.Decrease, usingMouseWheel: true));
			}
			else if (0 < e.Delta)
			{
				OnSpin(new SpinEventArgs(SpinDirection.Increase, usingMouseWheel: true));
			}
			((RoutedEventArgs)e).Handled = true;
		}
	}

	protected override void OnValidSpinDirectionChanged(ValidSpinDirections oldValue, ValidSpinDirections newValue)
	{
		SetButtonUsage();
	}

	private void OnButtonClick(object sender, RoutedEventArgs e)
	{
		if (AllowSpin)
		{
			SpinDirection direction = ((sender != IncreaseButton) ? SpinDirection.Decrease : SpinDirection.Increase);
			OnSpin(new SpinEventArgs(direction));
		}
	}

	protected virtual void OnContentChanged(object oldValue, object newValue)
	{
	}

	protected virtual void OnAllowSpinChanged(bool oldValue, bool newValue)
	{
		SetButtonUsage();
	}

	private void SetButtonUsage()
	{
		if (IncreaseButton != null)
		{
			((UIElement)IncreaseButton).IsEnabled = AllowSpin && (ValidSpinDirection & ValidSpinDirections.Increase) == ValidSpinDirections.Increase;
		}
		if (DecreaseButton != null)
		{
			((UIElement)DecreaseButton).IsEnabled = AllowSpin && (ValidSpinDirection & ValidSpinDirections.Decrease) == ValidSpinDirections.Decrease;
		}
	}
}
