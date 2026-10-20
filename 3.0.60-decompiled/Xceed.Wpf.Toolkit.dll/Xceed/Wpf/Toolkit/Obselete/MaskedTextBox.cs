using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.Obselete;

[Obsolete("Legacy implementation of MaskedTextBox. Use Xceed.Wpf.Toolkit.MaskedTextBox instead.", true)]
public class MaskedTextBox : TextBox
{
	private bool _isSyncingTextAndValueProperties;

	private bool _isInitialized;

	private bool _convertExceptionOccurred;

	public static readonly DependencyProperty IncludePromptProperty;

	public static readonly DependencyProperty IncludeLiteralsProperty;

	public static readonly DependencyProperty MaskProperty;

	public static readonly DependencyProperty PromptCharProperty;

	public static readonly DependencyProperty SelectAllOnGotFocusProperty;

	public static readonly DependencyProperty ValueProperty;

	public static readonly DependencyProperty ValueTypeProperty;

	public static readonly RoutedEvent ValueChangedEvent;

	protected MaskedTextProvider MaskProvider { get; set; }

	public bool IncludePrompt
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludePromptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludePromptProperty, (object)value);
		}
	}

	public bool IncludeLiterals
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeLiteralsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeLiteralsProperty, (object)value);
		}
	}

	public string Mask
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MaskProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaskProperty, (object)value);
		}
	}

	public char PromptChar
	{
		get
		{
			return (char)((DependencyObject)this).GetValue(PromptCharProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PromptCharProperty, (object)value);
		}
	}

	public bool SelectAllOnGotFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectAllOnGotFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllOnGotFocusProperty, (object)value);
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

	public Type ValueType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ValueTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueTypeProperty, (object)value);
		}
	}

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

	private static void OnIncludePromptPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnIncludePromptChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIncludePromptChanged(bool oldValue, bool newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnIncludeLiteralsPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnIncludeLiteralsChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIncludeLiteralsChanged(bool oldValue, bool newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnMaskPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnMaskChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnMaskChanged(string oldValue, string newValue)
	{
		UpdateMaskProvider(newValue);
		UpdateText(0);
	}

	private static void OnPromptCharChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnPromptCharChanged((char)e.OldValue, (char)e.NewValue);
		}
	}

	protected virtual void OnPromptCharChanged(char oldValue, char newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnTextChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(TextBox.TextProperty, newValue);
		}
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnValueChanged(e.OldValue, e.NewValue);
		}
	}

	protected virtual void OnValueChanged(object oldValue, object newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(ValueProperty, newValue);
		}
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
		((RoutedEventArgs)e).RoutedEvent = ValueChangedEvent;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
	}

	private static void OnValueTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnValueTypeChanged((Type)e.OldValue, (Type)e.NewValue);
		}
	}

	protected virtual void OnValueTypeChanged(Type oldValue, Type newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(TextBox.TextProperty, ((TextBox)this).Text);
		}
	}

	static MaskedTextBox()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Obj, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected Obj, but got Unknown
		IncludePromptProperty = DependencyProperty.Register("IncludePrompt", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIncludePromptPropertyChanged));
		IncludeLiteralsProperty = DependencyProperty.Register("IncludeLiterals", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)OnIncludeLiteralsPropertyChanged));
		MaskProperty = DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)"<>", (PropertyChangedCallback)OnMaskPropertyChanged));
		PromptCharProperty = DependencyProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)'_', (PropertyChangedCallback)OnPromptCharChanged));
		SelectAllOnGotFocusProperty = DependencyProperty.Register("SelectAllOnGotFocus", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(MaskedTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnValueChanged));
		ValueTypeProperty = DependencyProperty.Register("ValueType", typeof(Type), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)typeof(string), (PropertyChangedCallback)OnValueTypeChanged));
		ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<object>), typeof(MaskedTextBox));
		TextBox.TextProperty.OverrideMetadata(typeof(MaskedTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnTextChanged));
	}

	public MaskedTextBox()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Paste, (ExecutedRoutedEventHandler)Paste));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Cut, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanCut));
	}

	public override void OnApplyTemplate()
	{
		((TextBoxBase)this).OnApplyTemplate();
		UpdateMaskProvider(Mask);
		UpdateText(0);
	}

	protected override void OnInitialized(EventArgs e)
	{
		((FrameworkElement)this).OnInitialized(e);
		if (!_isInitialized)
		{
			_isInitialized = true;
			SyncTextAndValueProperties(ValueProperty, Value);
		}
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if (SelectAllOnGotFocus)
		{
			((TextBoxBase)this).SelectAll();
		}
		((TextBoxBase)this).OnGotKeyboardFocus(e);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (!((RoutedEventArgs)e).Handled)
		{
			HandlePreviewKeyDown(e);
		}
		((TextBoxBase)this).OnPreviewKeyDown(e);
	}

	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		if (!((RoutedEventArgs)e).Handled)
		{
			HandlePreviewTextInput(e);
		}
		((UIElement)this).OnPreviewTextInput(e);
	}

	private void UpdateText()
	{
		UpdateText(((TextBox)this).SelectionStart);
	}

	private void UpdateText(int position)
	{
		MaskedTextProvider maskProvider = MaskProvider;
		if (maskProvider == null)
		{
			throw new InvalidOperationException();
		}
		((TextBox)this).Text = maskProvider.ToDisplayString();
		((TextBox)this).SelectionLength = 0;
		((TextBox)this).SelectionStart = position;
	}

	private int GetNextCharacterPosition(int startPosition)
	{
		int num = MaskProvider.FindEditPositionFrom(startPosition, direction: true);
		if (num != -1)
		{
			return num;
		}
		return startPosition;
	}

	private void UpdateMaskProvider(string mask)
	{
		if (!string.IsNullOrEmpty(mask))
		{
			MaskProvider = new MaskedTextProvider(mask)
			{
				IncludePrompt = IncludePrompt,
				IncludeLiterals = IncludeLiterals,
				PromptChar = PromptChar,
				ResetOnSpace = false
			};
		}
	}

	private object ConvertTextToValue(string text)
	{
		object obj = null;
		Type valueType = ValueType;
		string text2 = MaskProvider.ToString().Trim();
		try
		{
			if (text2.GetType() == valueType || valueType.IsInstanceOfType(text2))
			{
				obj = text2;
			}
			else if (string.IsNullOrWhiteSpace(text2))
			{
				obj = Activator.CreateInstance(valueType);
			}
			else if (obj == null && text2 != null)
			{
				obj = Convert.ChangeType(text2, valueType);
			}
		}
		catch
		{
			_convertExceptionOccurred = true;
			return Value;
		}
		return obj;
	}

	private string ConvertValueToText(object value)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		if (_convertExceptionOccurred)
		{
			value = Value;
			_convertExceptionOccurred = false;
		}
		if (MaskProvider == null)
		{
			return value.ToString();
		}
		MaskProvider.Set(value.ToString());
		return MaskProvider.ToDisplayString();
	}

	private void SyncTextAndValueProperties(DependencyProperty p, object newValue)
	{
		if (!_isSyncingTextAndValueProperties)
		{
			_isSyncingTextAndValueProperties = true;
			if (TextBox.TextProperty == p && newValue != null)
			{
				((DependencyObject)this).SetValue(ValueProperty, ConvertTextToValue(newValue.ToString()));
			}
			((DependencyObject)this).SetValue(TextBox.TextProperty, (object)ConvertValueToText(newValue));
			_isSyncingTextAndValueProperties = false;
		}
	}

	private void HandlePreviewTextInput(TextCompositionEventArgs e)
	{
		if (!((TextBoxBase)this).IsReadOnly)
		{
			InsertText(e.Text);
		}
		((RoutedEventArgs)e).Handled = true;
	}

	private void HandlePreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		if ((int)e.Key == 32)
		{
			((RoutedEventArgs)e).Handled = ((TextBoxBase)this).IsReadOnly || HandleKeyDownDelete();
		}
		else if ((int)e.Key == 2)
		{
			((RoutedEventArgs)e).Handled = ((TextBoxBase)this).IsReadOnly || HandleKeyDownBack();
		}
		else if ((int)e.Key == 18)
		{
			if (!((TextBoxBase)this).IsReadOnly)
			{
				InsertText(" ");
			}
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 6 || (int)e.Key == 6)
		{
			if (!((TextBoxBase)this).IsReadOnly && ((TextBoxBase)this).AcceptsReturn)
			{
				InsertText("\r");
			}
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 3 && ((TextBoxBase)this).AcceptsTab)
		{
			if (!((TextBoxBase)this).IsReadOnly)
			{
				InsertText("\t");
			}
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private bool HandleKeyDownDelete()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool result = true;
		if ((int)modifiers == 0)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart = ((TextBox)this).SelectionStart;
				if (selectionStart < ((TextBox)this).Text.Length)
				{
					RemoveText(selectionStart, 1);
					UpdateText(selectionStart);
				}
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 2)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart2 = ((TextBox)this).SelectionStart;
				RemoveTextToEnd(selectionStart2);
				UpdateText(selectionStart2);
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 4)
		{
			if (RemoveSelectedText())
			{
				UpdateText();
			}
			else
			{
				result = false;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool HandleKeyDownBack()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool result = true;
		if ((int)modifiers == 0 || (int)modifiers == 4)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart = ((TextBox)this).SelectionStart;
				if (selectionStart > 0)
				{
					int position = selectionStart - 1;
					RemoveText(position, 1);
					UpdateText(position);
				}
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 2)
		{
			if (!RemoveSelectedText())
			{
				RemoveTextFromStart(((TextBox)this).SelectionStart);
				UpdateText(0);
			}
			else
			{
				UpdateText();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private void InsertText(string text)
	{
		int selectionStart = ((TextBox)this).SelectionStart;
		MaskedTextProvider maskProvider = MaskProvider;
		bool flag = RemoveSelectedText();
		selectionStart = GetNextCharacterPosition(selectionStart);
		if (!flag && Keyboard.IsKeyToggled((Key)31))
		{
			if (maskProvider.Replace(text, selectionStart))
			{
				selectionStart += text.Length;
			}
		}
		else if (maskProvider.InsertAt(text, selectionStart))
		{
			selectionStart += text.Length;
		}
		selectionStart = GetNextCharacterPosition(selectionStart);
		UpdateText(selectionStart);
	}

	private void RemoveTextFromStart(int endPosition)
	{
		RemoveText(0, endPosition);
	}

	private void RemoveTextToEnd(int startPosition)
	{
		RemoveText(startPosition, ((TextBox)this).Text.Length - startPosition);
	}

	private void RemoveText(int position, int length)
	{
		if (length != 0)
		{
			MaskProvider.RemoveAt(position, position + length - 1);
		}
	}

	private bool RemoveSelectedText()
	{
		int selectionLength = ((TextBox)this).SelectionLength;
		if (selectionLength == 0)
		{
			return false;
		}
		int selectionStart = ((TextBox)this).SelectionStart;
		return MaskProvider.RemoveAt(selectionStart, selectionStart + selectionLength - 1);
	}

	private void Paste(object sender, RoutedEventArgs e)
	{
		if (((TextBoxBase)this).IsReadOnly)
		{
			return;
		}
		object data = Clipboard.GetData(DataFormats.Text);
		if (data != null)
		{
			string text = data.ToString().Trim();
			if (text.Length > 0)
			{
				int selectionStart = ((TextBox)this).SelectionStart;
				MaskProvider.Set(text);
				UpdateText(selectionStart);
			}
		}
	}

	private void CanCut(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = false;
		((RoutedEventArgs)e).Handled = true;
	}
}
