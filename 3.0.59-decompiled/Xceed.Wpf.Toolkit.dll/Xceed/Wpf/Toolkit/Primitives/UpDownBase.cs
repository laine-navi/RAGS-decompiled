using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Input;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_Spinner", Type = typeof(Spinner))]
public abstract class UpDownBase<T> : InputBase, IValidateInput
{
	internal const string PART_TextBox = "PART_TextBox";

	internal const string PART_Spinner = "PART_Spinner";

	private bool _isSyncingTextAndValueProperties;

	private bool _isTextChangedFromUI;

	public static readonly DependencyProperty AllowSpinProperty = DependencyProperty.Register("AllowSpin", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)true));

	public static readonly DependencyProperty ClipValueToMinMaxProperty = DependencyProperty.Register("ClipValueToMinMax", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty DisplayDefaultValueOnEmptyTextProperty = DependencyProperty.Register("DisplayDefaultValueOnEmptyText", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnDisplayDefaultValueOnEmptyTextChanged));

	public static readonly DependencyProperty DefaultValueProperty = DependencyProperty.Register("DefaultValue", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)default(T), (PropertyChangedCallback)OnDefaultValueChanged));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)default(T), (PropertyChangedCallback)OnMaximumChanged, (CoerceValueCallback)OnCoerceMaximum));

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)default(T), (PropertyChangedCallback)OnMinimumChanged, (CoerceValueCallback)OnCoerceMinimum));

	public static readonly DependencyProperty MouseWheelActiveTriggerProperty = DependencyProperty.Register("MouseWheelActiveTrigger", typeof(MouseWheelActiveTrigger), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)MouseWheelActiveTrigger.Focused));

	[Obsolete("Use MouseWheelActiveTrigger property instead")]
	public static readonly DependencyProperty MouseWheelActiveOnFocusProperty = DependencyProperty.Register("MouseWheelActiveOnFocus", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)OnMouseWheelActiveOnFocusChanged));

	public static readonly DependencyProperty ShowButtonSpinnerProperty = DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)new UIPropertyMetadata((object)true));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)new FrameworkPropertyMetadata((object)default(T), (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnValueChanged, (CoerceValueCallback)OnCoerceValue, false, (UpdateSourceTrigger)1));

	public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<object>), typeof(UpDownBase<T>));

	protected Spinner Spinner { get; private set; }

	protected TextBox TextBox { get; private set; }

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

	public bool ClipValueToMinMax
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClipValueToMinMaxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipValueToMinMaxProperty, (object)value);
		}
	}

	public bool DisplayDefaultValueOnEmptyText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayDefaultValueOnEmptyTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayDefaultValueOnEmptyTextProperty, (object)value);
		}
	}

	public T DefaultValue
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(DefaultValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultValueProperty, (object)value);
		}
	}

	public T Maximum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public T Minimum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public MouseWheelActiveTrigger MouseWheelActiveTrigger
	{
		get
		{
			return (MouseWheelActiveTrigger)((DependencyObject)this).GetValue(MouseWheelActiveTriggerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseWheelActiveTriggerProperty, (object)value);
		}
	}

	[Obsolete("Use MouseWheelActiveTrigger property instead")]
	public bool MouseWheelActiveOnFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(MouseWheelActiveOnFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseWheelActiveOnFocusProperty, (object)value);
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

	public T Value
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public event InputValidationErrorEventHandler InputValidationError;

	public event RoutedPropertyChangedEventHandler<object> ValueChanged
	{
		add
		{
			((UIElement)this).AddHandler(ValueChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ValueChangedEvent, (Delegate)(object)value);
		}
	}

	private static void OnDisplayDefaultValueOnEmptyTextChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
	{
		((UpDownBase<T>)(object)source).OnDisplayDefaultValueOnEmptyTextChanged((bool)args.OldValue, (bool)args.NewValue);
	}

	private void OnDisplayDefaultValueOnEmptyTextChanged(bool oldValue, bool newValue)
	{
		if (((FrameworkElement)this).IsInitialized && string.IsNullOrEmpty(Text))
		{
			SyncTextAndValueProperties(updateValueFromText: true, Text);
		}
	}

	private static void OnDefaultValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
	{
		((UpDownBase<T>)(object)source).OnDefaultValueChanged((T)args.OldValue, (T)args.NewValue);
	}

	private void OnDefaultValueChanged(T oldValue, T newValue)
	{
		if (((FrameworkElement)this).IsInitialized && string.IsNullOrEmpty(Text))
		{
			SyncTextAndValueProperties(updateValueFromText: true, Text);
		}
	}

	private static void OnMaximumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnMaximumChanged((T)e.OldValue, (T)e.NewValue);
		}
	}

	protected virtual void OnMaximumChanged(T oldValue, T newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceMaximum(DependencyObject d, object baseValue)
	{
		if (d is UpDownBase<T> upDownBase)
		{
			return upDownBase.OnCoerceMaximum((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceMaximum(T baseValue)
	{
		return baseValue;
	}

	private static void OnMinimumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnMinimumChanged((T)e.OldValue, (T)e.NewValue);
		}
	}

	protected virtual void OnMinimumChanged(T oldValue, T newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceMinimum(DependencyObject d, object baseValue)
	{
		if (d is UpDownBase<T> upDownBase)
		{
			return upDownBase.OnCoerceMinimum((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceMinimum(T baseValue)
	{
		return baseValue;
	}

	private static void OnMouseWheelActiveOnFocusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.MouseWheelActiveTrigger = ((!(bool)e.NewValue) ? MouseWheelActiveTrigger.MouseOver : MouseWheelActiveTrigger.Focused);
		}
	}

	private static object OnCoerceValue(DependencyObject o, object basevalue)
	{
		return ((UpDownBase<T>)(object)o).OnCoerceValue(basevalue);
	}

	protected virtual object OnCoerceValue(object newValue)
	{
		return newValue;
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnValueChanged((T)e.OldValue, (T)e.NewValue);
		}
	}

	protected virtual void OnValueChanged(T oldValue, T newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
		}
		SetValidSpinDirection();
		RaiseValueChangedEvent(oldValue, newValue);
	}

	internal UpDownBase()
	{
	}

	protected override void OnAccessKey(AccessKeyEventArgs e)
	{
		if (TextBox != null)
		{
			((UIElement)TextBox).Focus();
		}
		((UIElement)this).OnAccessKey(e);
	}

	public override void OnApplyTemplate()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_TextBox");
		TextBox = (TextBox)(object)((templateChild is TextBox) ? templateChild : null);
		if (TextBox != null)
		{
			TextBox.Text = Text;
			((UIElement)TextBox).LostFocus += TextBox_LostFocus;
			((TextBoxBase)TextBox).TextChanged += TextBox_TextChanged;
		}
		if (Spinner != null)
		{
			Spinner.Spin -= OnSpinnerSpin;
		}
		Spinner = ((FrameworkElement)this).GetTemplateChild("PART_Spinner") as Spinner;
		if (Spinner != null)
		{
			Spinner.Spin += OnSpinnerSpin;
		}
		SetValidSpinDirection();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		Key key = e.Key;
		if ((int)key == 6)
		{
			bool flag = CommitInput();
			((RoutedEventArgs)e).Handled = !flag;
		}
	}

	protected override void OnTextChanged(string oldValue, string newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: true, Text);
		}
	}

	protected override void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
		}
	}

	protected override void OnReadOnlyChanged(bool oldValue, bool newValue)
	{
		SetValidSpinDirection();
	}

	private void OnSpinnerSpin(object sender, SpinEventArgs e)
	{
		if (AllowSpin && !IsReadOnly)
		{
			MouseWheelActiveTrigger mouseWheelActiveTrigger = MouseWheelActiveTrigger;
			bool flag = !e.UsingMouseWheel;
			flag |= mouseWheelActiveTrigger == MouseWheelActiveTrigger.MouseOver;
			if (flag | (((UIElement)TextBox).IsFocused && mouseWheelActiveTrigger == MouseWheelActiveTrigger.Focused))
			{
				OnSpin(e);
			}
		}
	}

	protected virtual void OnSpin(SpinEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (e.Direction == SpinDirection.Increase)
		{
			DoIncrement();
		}
		else
		{
			DoDecrement();
		}
	}

	protected virtual void RaiseValueChangedEvent(T oldValue, T newValue)
	{
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>((object)oldValue, (object)newValue);
		((RoutedEventArgs)e).RoutedEvent = ValueChangedEvent;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
	}

	protected override void OnInitialized(EventArgs e)
	{
		((FrameworkElement)this).OnInitialized(e);
		bool flag = ((DependencyObject)this).ReadLocalValue(ValueProperty) == DependencyProperty.UnsetValue && BindingOperations.GetBinding((DependencyObject)(object)this, ValueProperty) == null && object.Equals(Value, ValueProperty.DefaultMetadata.DefaultValue);
		SyncTextAndValueProperties(flag, Text, !flag);
	}

	internal void DoDecrement()
	{
		if (Spinner == null || (Spinner.ValidSpinDirection & ValidSpinDirections.Decrease) == ValidSpinDirections.Decrease)
		{
			OnDecrement();
		}
	}

	internal void DoIncrement()
	{
		if (Spinner == null || (Spinner.ValidSpinDirection & ValidSpinDirections.Increase) == ValidSpinDirections.Increase)
		{
			OnIncrement();
		}
	}

	private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (!((UIElement)this).IsKeyboardFocusWithin)
		{
			return;
		}
		try
		{
			_isTextChangedFromUI = true;
			Text = ((TextBox)sender).Text;
		}
		finally
		{
			_isTextChangedFromUI = false;
		}
	}

	private void TextBox_LostFocus(object sender, RoutedEventArgs e)
	{
		CommitInput();
	}

	private void RaiseInputValidationError(Exception e)
	{
		if (InputValidationError != null)
		{
			InputValidationErrorEventArgs e2 = new InputValidationErrorEventArgs(e);
			InputValidationError(this, e2);
			if (e2.ThrowException)
			{
				throw e2.Exception;
			}
		}
	}

	public bool CommitInput()
	{
		return SyncTextAndValueProperties(updateValueFromText: true, Text);
	}

	protected bool SyncTextAndValueProperties(bool updateValueFromText, string text)
	{
		return SyncTextAndValueProperties(updateValueFromText, text, forceTextUpdate: false);
	}

	private bool SyncTextAndValueProperties(bool updateValueFromText, string text, bool forceTextUpdate)
	{
		if (_isSyncingTextAndValueProperties)
		{
			return true;
		}
		_isSyncingTextAndValueProperties = true;
		bool flag = true;
		try
		{
			if (updateValueFromText)
			{
				if (string.IsNullOrEmpty(text))
				{
					Value = DefaultValue;
				}
				else
				{
					try
					{
						Value = ConvertTextToValue(text);
					}
					catch (Exception e)
					{
						flag = false;
						if (!_isTextChangedFromUI)
						{
							RaiseInputValidationError(e);
						}
					}
				}
			}
			if (!_isTextChangedFromUI)
			{
				if (forceTextUpdate || !string.IsNullOrEmpty(Text) || !object.Equals(Value, DefaultValue) || DisplayDefaultValueOnEmptyText)
				{
					Text = ConvertValueToText();
				}
				if (TextBox != null)
				{
					TextBox.Text = Text;
				}
			}
			if (_isTextChangedFromUI && !flag)
			{
				if (Spinner != null)
				{
					Spinner.ValidSpinDirection = ValidSpinDirections.None;
				}
			}
			else
			{
				SetValidSpinDirection();
			}
		}
		finally
		{
			_isSyncingTextAndValueProperties = false;
		}
		return flag;
	}

	protected abstract T ConvertTextToValue(string text);

	protected abstract string ConvertValueToText();

	protected abstract void OnIncrement();

	protected abstract void OnDecrement();

	protected abstract void SetValidSpinDirection();

	static UpDownBase()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
		//IL_011c: Expected Obj, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_016a: Expected Obj, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected Obj, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected Obj, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Obj, but got Unknown
		//IL_0255: Expected Obj, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
	}
}
