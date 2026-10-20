using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core;

namespace Xceed.Wpf.Toolkit.Primitives;

public class ValueRangeTextBox : AutoSelectTextBox
{
	[Flags]
	private enum ValueRangeTextBoxFlags
	{
		IsFinalizingInitialization = 1,
		IsForcingText = 2,
		IsForcingValue = 4,
		IsInValueChanged = 8,
		IsNumericValueDataType = 0x10
	}

	public static readonly DependencyProperty BeepOnErrorProperty;

	public static readonly DependencyProperty FormatProviderProperty;

	public static readonly DependencyProperty MinValueProperty;

	public static readonly DependencyProperty MaxValueProperty;

	public static readonly DependencyProperty NullValueProperty;

	public static readonly DependencyProperty ValueProperty;

	public static readonly DependencyProperty ValueDataTypeProperty;

	private static readonly DependencyPropertyKey HasValidationErrorPropertyKey;

	public static readonly DependencyProperty HasValidationErrorProperty;

	private static readonly DependencyPropertyKey HasParsingErrorPropertyKey;

	public static readonly DependencyProperty HasParsingErrorProperty;

	private static readonly DependencyPropertyKey IsValueOutOfRangePropertyKey;

	public static readonly DependencyProperty IsValueOutOfRangeProperty;

	private BitVector32 m_flags;

	private CachedTextInfo m_imePreCompositionCachedTextInfo;

	public bool BeepOnError
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(BeepOnErrorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BeepOnErrorProperty, (object)value);
		}
	}

	public IFormatProvider FormatProvider
	{
		get
		{
			return (IFormatProvider)((DependencyObject)this).GetValue(FormatProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatProviderProperty, (object)value);
		}
	}

	public object MinValue
	{
		get
		{
			return ((DependencyObject)this).GetValue(MinValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinValueProperty, value);
		}
	}

	public object MaxValue
	{
		get
		{
			return ((DependencyObject)this).GetValue(MaxValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxValueProperty, value);
		}
	}

	public object NullValue
	{
		get
		{
			return ((DependencyObject)this).GetValue(NullValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NullValueProperty, value);
		}
	}

	public object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public Type ValueDataType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ValueDataTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueDataTypeProperty, (object)value);
		}
	}

	public bool HasValidationError => (bool)((DependencyObject)this).GetValue(HasValidationErrorProperty);

	public bool HasParsingError => (bool)((DependencyObject)this).GetValue(HasParsingErrorProperty);

	public bool IsValueOutOfRange => (bool)((DependencyObject)this).GetValue(IsValueOutOfRangeProperty);

	internal bool IsInValueChanged
	{
		get
		{
			return m_flags[8];
		}
		private set
		{
			m_flags[8] = value;
		}
	}

	internal bool IsForcingValue
	{
		get
		{
			return m_flags[4];
		}
		private set
		{
			m_flags[4] = value;
		}
	}

	internal bool IsForcingText
	{
		get
		{
			return m_flags[2];
		}
		private set
		{
			m_flags[2] = value;
		}
	}

	internal bool IsNumericValueDataType
	{
		get
		{
			return m_flags[16];
		}
		private set
		{
			m_flags[16] = value;
		}
	}

	internal virtual bool IsTextReadyToBeParsed => true;

	internal bool IsInIMEComposition => m_imePreCompositionCachedTextInfo != null;

	private bool IsFinalizingInitialization
	{
		get
		{
			return m_flags[1];
		}
		set
		{
			m_flags[1] = value;
		}
	}

	public event EventHandler<QueryTextFromValueEventArgs> QueryTextFromValue;

	public event EventHandler<QueryValueFromTextEventArgs> QueryValueFromText;

	static ValueRangeTextBox()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0106: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		//IL_014c: Expected Obj, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected Obj, but got Unknown
		//IL_018d: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected Obj, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected Obj, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected Obj, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected Obj, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected Obj, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Obj, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected Obj, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected Obj, but got Unknown
		BeepOnErrorProperty = DependencyProperty.Register("BeepOnError", typeof(bool), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		FormatProviderProperty = DependencyProperty.Register("FormatProvider", typeof(IFormatProvider), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)FormatProviderPropertyChangedCallback));
		MinValueProperty = DependencyProperty.Register("MinValue", typeof(object), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)null, (CoerceValueCallback)MinValueCoerceValueCallback));
		MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(object), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)null, (CoerceValueCallback)MaxValueCoerceValueCallback));
		NullValueProperty = DependencyProperty.Register("NullValue", typeof(object), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)NullValuePropertyChangedCallback, (CoerceValueCallback)NullValueCoerceValueCallback));
		ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(ValueRangeTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)ValuePropertyChangedCallback, (CoerceValueCallback)ValueCoerceValueCallback));
		ValueDataTypeProperty = DependencyProperty.Register("ValueDataType", typeof(Type), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)ValueDataTypePropertyChangedCallback, (CoerceValueCallback)ValueDataTypeCoerceValueCallback));
		HasValidationErrorPropertyKey = DependencyProperty.RegisterReadOnly("HasValidationError", typeof(bool), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		HasValidationErrorProperty = HasValidationErrorPropertyKey.DependencyProperty;
		HasParsingErrorPropertyKey = DependencyProperty.RegisterReadOnly("HasParsingError", typeof(bool), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		HasParsingErrorProperty = HasParsingErrorPropertyKey.DependencyProperty;
		IsValueOutOfRangePropertyKey = DependencyProperty.RegisterReadOnly("IsValueOutOfRange", typeof(bool), typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IsValueOutOfRangeProperty = IsValueOutOfRangePropertyKey.DependencyProperty;
		TextBox.TextProperty.OverrideMetadata(typeof(ValueRangeTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)null, (CoerceValueCallback)TextCoerceValueCallback));
		TextBoxBase.AcceptsReturnProperty.OverrideMetadata(typeof(ValueRangeTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)null, (CoerceValueCallback)AcceptsReturnCoerceValueCallback));
		TextBoxBase.AcceptsTabProperty.OverrideMetadata(typeof(ValueRangeTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)null, (CoerceValueCallback)AcceptsTabCoerceValueCallback));
		AutomationProperties.AutomationIdProperty.OverrideMetadata(typeof(ValueRangeTextBox), (PropertyMetadata)new UIPropertyMetadata((object)"ValueRangeTextBox"));
	}

	private static object AcceptsReturnCoerceValueCallback(DependencyObject sender, object value)
	{
		if ((bool)value)
		{
			throw new NotSupportedException("The ValueRangeTextBox does not support the AcceptsReturn property.");
		}
		return false;
	}

	private static object AcceptsTabCoerceValueCallback(DependencyObject sender, object value)
	{
		if ((bool)value)
		{
			throw new NotSupportedException("The ValueRangeTextBox does not support the AcceptsTab property.");
		}
		return false;
	}

	private static void FormatProviderPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		ValueRangeTextBox valueRangeTextBox = (ValueRangeTextBox)(object)sender;
		if (((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			valueRangeTextBox.OnFormatProviderChanged();
		}
	}

	internal virtual void OnFormatProviderChanged()
	{
		RefreshConversionHelpers();
		RefreshCurrentText(preserveCurrentCaretPosition: false);
		RefreshValue();
	}

	private static object MinValueCoerceValueCallback(DependencyObject sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (value == null)
		{
			return value;
		}
		Type valueDataType = valueRangeTextBox.ValueDataType;
		if (valueDataType == null)
		{
			throw new InvalidOperationException("An attempt was made to set a minimum value when the ValueDataType property is null.");
		}
		if (valueRangeTextBox.IsFinalizingInitialization)
		{
			value = ConvertValueToDataType(value, valueRangeTextBox.ValueDataType);
		}
		if (value.GetType() != valueDataType)
		{
			throw new ArgumentException("The value is not of type " + valueDataType.Name + ".", "MinValue");
		}
		if (!(value is IComparable))
		{
			throw new InvalidOperationException("MinValue does not implement the IComparable interface.");
		}
		object maxValue = valueRangeTextBox.MaxValue;
		valueRangeTextBox.ValidateValueInRange(value, maxValue, valueRangeTextBox.Value);
		return value;
	}

	private static object MaxValueCoerceValueCallback(DependencyObject sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (value == null)
		{
			return value;
		}
		Type valueDataType = valueRangeTextBox.ValueDataType;
		if (valueDataType == null)
		{
			throw new InvalidOperationException("An attempt was made to set a maximum value when the ValueDataType property is null.");
		}
		if (valueRangeTextBox.IsFinalizingInitialization)
		{
			value = ConvertValueToDataType(value, valueRangeTextBox.ValueDataType);
		}
		if (value.GetType() != valueDataType)
		{
			throw new ArgumentException("The value is not of type " + valueDataType.Name + ".", "MinValue");
		}
		if (!(value is IComparable))
		{
			throw new InvalidOperationException("MaxValue does not implement the IComparable interface.");
		}
		object minValue = valueRangeTextBox.MinValue;
		valueRangeTextBox.ValidateValueInRange(minValue, value, valueRangeTextBox.Value);
		return value;
	}

	private static object NullValueCoerceValueCallback(DependencyObject sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (value == null || value == DBNull.Value)
		{
			return value;
		}
		Type valueDataType = valueRangeTextBox.ValueDataType;
		if (valueDataType == null)
		{
			throw new InvalidOperationException("An attempt was made to set a null value when the ValueDataType property is null.");
		}
		if (valueRangeTextBox.IsFinalizingInitialization)
		{
			value = ConvertValueToDataType(value, valueRangeTextBox.ValueDataType);
		}
		if (value.GetType() != valueDataType)
		{
			throw new ArgumentException("The value is not of type " + valueDataType.Name + ".", "NullValue");
		}
		return value;
	}

	private static void NullValuePropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (e.OldValue == null)
		{
			if (valueRangeTextBox.Value == null)
			{
				valueRangeTextBox.RefreshValue();
			}
		}
		else if (e.OldValue.Equals(valueRangeTextBox.Value))
		{
			valueRangeTextBox.RefreshValue();
		}
	}

	private static object ValueCoerceValueCallback(object sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (valueRangeTextBox.IsFinalizingInitialization)
		{
			value = ConvertValueToDataType(value, valueRangeTextBox.ValueDataType);
		}
		if (!valueRangeTextBox.IsForcingValue)
		{
			valueRangeTextBox.ValidateValue(value);
		}
		return value;
	}

	private static void ValuePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (valueRangeTextBox.IsForcingValue || object.Equals(e.NewValue, e.OldValue))
		{
			return;
		}
		valueRangeTextBox.IsInValueChanged = true;
		try
		{
			((TextBox)valueRangeTextBox).Text = valueRangeTextBox.GetTextFromValue(e.NewValue);
		}
		finally
		{
			valueRangeTextBox.IsInValueChanged = false;
		}
	}

	private static object ValueDataTypeCoerceValueCallback(DependencyObject sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		Type type = value as Type;
		try
		{
			valueRangeTextBox.ValidateDataType(type);
			return value;
		}
		catch (Exception innerException)
		{
			throw new ArgumentException("An error occured while trying to change the ValueDataType.", innerException);
		}
	}

	private static void ValueDataTypePropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		Type type = e.NewValue as Type;
		valueRangeTextBox.IsNumericValueDataType = IsNumericType(type);
		valueRangeTextBox.RefreshConversionHelpers();
		valueRangeTextBox.ConvertValuesToDataType(type);
	}

	internal virtual void ValidateDataType(Type type)
	{
		if (type == null)
		{
			return;
		}
		object obj = MinValue;
		if (obj != null && obj.GetType() != type)
		{
			obj = Convert.ChangeType(obj, type, CultureInfo.InvariantCulture);
		}
		object obj2 = MaxValue;
		if (obj2 != null && obj2.GetType() != type)
		{
			obj2 = Convert.ChangeType(obj2, type, CultureInfo.InvariantCulture);
		}
		object obj3 = NullValue;
		if (obj3 != null && obj3 != DBNull.Value && obj3.GetType() != type)
		{
			obj3 = Convert.ChangeType(obj3, type, CultureInfo.InvariantCulture);
		}
		object value = Value;
		if (value != null && value != DBNull.Value && value.GetType() != type)
		{
			value = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
		}
		if (obj != null || obj2 != null || (obj3 != null && obj3 != DBNull.Value))
		{
			Type type2 = type.GetInterface("IComparable");
			if (type2 == null)
			{
				throw new InvalidOperationException("MinValue, MaxValue, and NullValue must implement the IComparable interface.");
			}
		}
	}

	private void ConvertValuesToDataType(Type type)
	{
		if (type == null)
		{
			MinValue = null;
			MaxValue = null;
			NullValue = null;
			Value = null;
			return;
		}
		object minValue = MinValue;
		if (minValue != null && minValue.GetType() != type)
		{
			MinValue = ConvertValueToDataType(minValue, type);
		}
		object maxValue = MaxValue;
		if (maxValue != null && maxValue.GetType() != type)
		{
			MaxValue = ConvertValueToDataType(maxValue, type);
		}
		object nullValue = NullValue;
		if (nullValue != null && nullValue != DBNull.Value && nullValue.GetType() != type)
		{
			NullValue = ConvertValueToDataType(nullValue, type);
		}
		object value = Value;
		if (value != null && value != DBNull.Value && value.GetType() != type)
		{
			Value = ConvertValueToDataType(value, type);
		}
	}

	private static object TextCoerceValueCallback(object sender, object value)
	{
		ValueRangeTextBox valueRangeTextBox = sender as ValueRangeTextBox;
		if (!((FrameworkElement)valueRangeTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (value == null)
		{
			return string.Empty;
		}
		return value;
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		RefreshValue();
		base.OnTextChanged(e);
	}

	private void SetHasValidationError(bool value)
	{
		((DependencyObject)this).SetValue(HasValidationErrorPropertyKey, (object)value);
	}

	internal void SetHasParsingError(bool value)
	{
		((DependencyObject)this).SetValue(HasParsingErrorPropertyKey, (object)value);
	}

	private void SetIsValueOutOfRange(bool value)
	{
		((DependencyObject)this).SetValue(IsValueOutOfRangePropertyKey, (object)value);
	}

	internal string GetTextFromValue(object value)
	{
		string text = QueryTextFromValueCore(value);
		QueryTextFromValueEventArgs e = new QueryTextFromValueEventArgs(value, text);
		OnQueryTextFromValue(e);
		return e.Text;
	}

	protected virtual string QueryTextFromValueCore(object value)
	{
		if (value == null || value == DBNull.Value)
		{
			return string.Empty;
		}
		IFormatProvider activeFormatProvider = GetActiveFormatProvider();
		if (activeFormatProvider is CultureInfo culture)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(value.GetType());
			if (converter.CanConvertTo(typeof(string)))
			{
				return (string)converter.ConvertTo(null, culture, value, typeof(string));
			}
		}
		try
		{
			return Convert.ToString(value, activeFormatProvider);
		}
		catch
		{
		}
		return value.ToString();
	}

	private void OnQueryTextFromValue(QueryTextFromValueEventArgs e)
	{
		if (QueryTextFromValue != null)
		{
			QueryTextFromValue(this, e);
		}
	}

	internal object GetValueFromText(string text, out bool hasParsingError)
	{
		object value = null;
		bool flag = QueryValueFromTextCore(text, out value);
		QueryValueFromTextEventArgs e = new QueryValueFromTextEventArgs(text, value);
		e.HasParsingError = !flag;
		OnQueryValueFromText(e);
		hasParsingError = e.HasParsingError;
		return e.Value;
	}

	protected virtual bool QueryValueFromTextCore(string text, out object value)
	{
		value = null;
		Type valueDataType = ValueDataType;
		text = text.Trim();
		if (valueDataType == null)
		{
			return true;
		}
		if (!valueDataType.IsValueType && valueDataType != typeof(string))
		{
			return false;
		}
		try
		{
			value = Convert.ChangeType(text, valueDataType, GetActiveFormatProvider());
		}
		catch
		{
			return false;
		}
		return true;
	}

	private void OnQueryValueFromText(QueryValueFromTextEventArgs e)
	{
		if (QueryValueFromText != null)
		{
			QueryValueFromText(this, e);
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.ImeProcessedKey != 0 && !IsInIMEComposition)
		{
			StartIMEComposition();
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		((FrameworkElement)this).OnGotFocus(e);
		RefreshCurrentText(preserveCurrentCaretPosition: true);
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		((TextBoxBase)this).OnLostFocus(e);
		RefreshCurrentText(preserveCurrentCaretPosition: true);
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (IsInIMEComposition)
		{
			EndIMEComposition();
		}
		((TextBoxBase)this).OnTextInput(e);
	}

	protected virtual void ValidateValue(object value)
	{
		if (value != null)
		{
			Type valueDataType = ValueDataType;
			if (valueDataType == null)
			{
				throw new InvalidOperationException("An attempt was made to set a value when the ValueDataType property is null.");
			}
			if (value != DBNull.Value && value.GetType() != valueDataType)
			{
				throw new ArgumentException("The value is not of type " + valueDataType.Name + ".", "Value");
			}
			ValidateValueInRange(MinValue, MaxValue, value);
		}
	}

	internal static bool IsNumericType(Type type)
	{
		if (type == null)
		{
			return false;
		}
		if (type.IsValueType && (type == typeof(int) || type == typeof(double) || type == typeof(decimal) || type == typeof(float) || type == typeof(short) || type == typeof(long) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong) || type == typeof(byte)))
		{
			return true;
		}
		return false;
	}

	internal void StartIMEComposition()
	{
		m_imePreCompositionCachedTextInfo = new CachedTextInfo((TextBox)(object)this);
	}

	internal void EndIMEComposition()
	{
		CachedTextInfo cachedTextInfo = m_imePreCompositionCachedTextInfo.Clone() as CachedTextInfo;
		m_imePreCompositionCachedTextInfo = null;
		OnIMECompositionEnded(cachedTextInfo);
	}

	internal virtual void OnIMECompositionEnded(CachedTextInfo cachedTextInfo)
	{
	}

	internal virtual void RefreshConversionHelpers()
	{
	}

	internal IFormatProvider GetActiveFormatProvider()
	{
		IFormatProvider formatProvider = FormatProvider;
		if (formatProvider != null)
		{
			return formatProvider;
		}
		return CultureInfo.CurrentCulture;
	}

	internal CultureInfo GetCultureInfo()
	{
		if (GetActiveFormatProvider() is CultureInfo result)
		{
			return result;
		}
		return CultureInfo.CurrentCulture;
	}

	internal virtual string GetCurrentText()
	{
		return ((TextBox)this).Text;
	}

	internal virtual string GetParsableText()
	{
		return ((TextBox)this).Text;
	}

	internal void ForceText(string text, bool preserveCaret)
	{
		IsForcingText = true;
		try
		{
			int caretIndex = ((TextBox)this).CaretIndex;
			((TextBox)this).Text = text;
			if (preserveCaret && ((FrameworkElement)this).IsLoaded)
			{
				try
				{
					((TextBox)this).SelectionStart = caretIndex;
					return;
				}
				catch (NullReferenceException)
				{
					return;
				}
			}
		}
		finally
		{
			IsForcingText = false;
		}
	}

	internal bool IsValueNull(object value)
	{
		if (value == null || value == DBNull.Value)
		{
			return true;
		}
		Type valueDataType = ValueDataType;
		if (value.GetType() != valueDataType)
		{
			value = Convert.ChangeType(value, valueDataType);
		}
		object obj = NullValue;
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != valueDataType)
		{
			obj = Convert.ChangeType(obj, valueDataType);
		}
		return obj.Equals(value);
	}

	internal void ForceValue(object value)
	{
		IsForcingValue = true;
		try
		{
			Value = value;
		}
		finally
		{
			IsForcingValue = false;
		}
	}

	internal void RefreshCurrentText(bool preserveCurrentCaretPosition)
	{
		string currentText = GetCurrentText();
		if (!string.Equals(currentText, ((TextBox)this).Text))
		{
			ForceText(currentText, preserveCurrentCaretPosition);
		}
	}

	internal void RefreshValue()
	{
		if (IsForcingValue || ValueDataType == null || IsInIMEComposition)
		{
			return;
		}
		object obj;
		bool hasParsingError;
		if (IsTextReadyToBeParsed)
		{
			string parsableText = GetParsableText();
			obj = GetValueFromText(parsableText, out hasParsingError);
			if (IsValueNull(obj))
			{
				obj = NullValue;
			}
		}
		else
		{
			hasParsingError = !GetIsEditTextEmpty();
			obj = NullValue;
		}
		SetHasParsingError(hasParsingError);
		bool hasValidationError = hasParsingError;
		try
		{
			ValidateValue(obj);
			SetIsValueOutOfRange(value: false);
		}
		catch (Exception ex)
		{
			hasValidationError = true;
			if (ex is ArgumentOutOfRangeException)
			{
				SetIsValueOutOfRange(value: true);
			}
			obj = NullValue;
		}
		if (!object.Equals(obj, Value))
		{
			ForceValue(obj);
		}
		SetHasValidationError(hasValidationError);
	}

	internal virtual bool GetIsEditTextEmpty()
	{
		return ((TextBox)this).Text == string.Empty;
	}

	private static object ConvertValueToDataType(object value, Type type)
	{
		if (type == null)
		{
			return null;
		}
		if (value != null && value != DBNull.Value && value.GetType() != type)
		{
			return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
		}
		return value;
	}

	private void CanEnterLineBreak(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = false;
		((RoutedEventArgs)e).Handled = true;
	}

	private void CanEnterParagraphBreak(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = false;
		((RoutedEventArgs)e).Handled = true;
	}

	private void ValidateValueInRange(object minValue, object maxValue, object value)
	{
		if (IsValueNull(value))
		{
			return;
		}
		Type valueDataType = ValueDataType;
		if (value.GetType() != valueDataType)
		{
			value = Convert.ChangeType(value, valueDataType);
		}
		if (minValue != null)
		{
			IComparable comparable = (IComparable)minValue;
			if (maxValue != null && comparable.CompareTo(maxValue) > 0)
			{
				throw new ArgumentOutOfRangeException("minValue", "MaxValue must be greater than MinValue.");
			}
			if (comparable.CompareTo(value) > 0)
			{
				throw new ArgumentOutOfRangeException("minValue", "Value must be greater than MinValue.");
			}
		}
		if (maxValue != null)
		{
			IComparable comparable2 = (IComparable)maxValue;
			if (comparable2.CompareTo(value) < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue", "Value must be less than MaxValue.");
			}
		}
	}

	protected override void OnInitialized(EventArgs e)
	{
		IsFinalizingInitialization = true;
		try
		{
			((DependencyObject)this).CoerceValue(ValueDataTypeProperty);
			IsNumericValueDataType = IsNumericType(ValueDataType);
			RefreshConversionHelpers();
			((DependencyObject)this).CoerceValue(MinValueProperty);
			((DependencyObject)this).CoerceValue(MaxValueProperty);
			((DependencyObject)this).CoerceValue(ValueProperty);
			((DependencyObject)this).CoerceValue(NullValueProperty);
			((DependencyObject)this).CoerceValue(TextBox.TextProperty);
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Initialization of the ValueRangeTextBox failed.", innerException);
		}
		finally
		{
			IsFinalizingInitialization = false;
		}
		((FrameworkElement)this).OnInitialized(e);
	}
}
