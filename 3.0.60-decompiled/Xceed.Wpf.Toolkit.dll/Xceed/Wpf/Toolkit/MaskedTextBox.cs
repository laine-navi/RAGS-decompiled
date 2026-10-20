using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Media;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class MaskedTextBox : ValueRangeTextBox
{
	private static readonly char[] MaskChars;

	private static char DefaultPasswordChar;

	private static string NullMaskString;

	public static readonly DependencyProperty AllowPromptAsInputProperty;

	public static readonly DependencyProperty ClipboardMaskFormatProperty;

	public static readonly DependencyProperty HidePromptOnLeaveProperty;

	public static readonly DependencyProperty IncludeLiteralsInValueProperty;

	public static readonly DependencyProperty IncludePromptInValueProperty;

	public static readonly DependencyProperty InsertKeyModeProperty;

	private static readonly DependencyPropertyKey IsMaskCompletedPropertyKey;

	public static readonly DependencyProperty IsMaskCompletedProperty;

	private static readonly DependencyPropertyKey IsMaskFullPropertyKey;

	public static readonly DependencyProperty IsMaskFullProperty;

	public static readonly DependencyProperty MaskProperty;

	public static readonly DependencyProperty PromptCharProperty;

	public static readonly DependencyProperty RejectInputOnFirstFailureProperty;

	public static readonly DependencyProperty ResetOnPromptProperty;

	public static readonly DependencyProperty ResetOnSpaceProperty;

	public static readonly DependencyProperty RestrictToAsciiProperty;

	public static readonly DependencyProperty SkipLiteralsProperty;

	private MaskedTextProvider m_maskedTextProvider;

	private bool m_insertToggled;

	private bool m_maskIsNull = true;

	private bool m_forcingMask;

	private List<int> m_unhandledLiteralsPositions;

	private string m_formatSpecifier;

	private MethodInfo m_valueToStringMethodInfo;

	public bool AllowPromptAsInput
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowPromptAsInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowPromptAsInputProperty, (object)value);
		}
	}

	public MaskFormat ClipboardMaskFormat
	{
		get
		{
			return (MaskFormat)((DependencyObject)this).GetValue(ClipboardMaskFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipboardMaskFormatProperty, (object)value);
		}
	}

	public bool HidePromptOnLeave
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HidePromptOnLeaveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HidePromptOnLeaveProperty, (object)value);
		}
	}

	public bool IncludeLiteralsInValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeLiteralsInValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeLiteralsInValueProperty, (object)value);
		}
	}

	public bool IncludePromptInValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludePromptInValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludePromptInValueProperty, (object)value);
		}
	}

	public InsertKeyMode InsertKeyMode
	{
		get
		{
			return (InsertKeyMode)((DependencyObject)this).GetValue(InsertKeyModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InsertKeyModeProperty, (object)value);
		}
	}

	public bool IsMaskCompleted => (bool)((DependencyObject)this).GetValue(IsMaskCompletedProperty);

	public bool IsMaskFull => (bool)((DependencyObject)this).GetValue(IsMaskFullProperty);

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

	public MaskedTextProvider MaskedTextProvider
	{
		get
		{
			if (!m_maskIsNull)
			{
				return m_maskedTextProvider.Clone() as MaskedTextProvider;
			}
			return null;
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

	public bool RejectInputOnFirstFailure
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RejectInputOnFirstFailureProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RejectInputOnFirstFailureProperty, (object)value);
		}
	}

	public bool ResetOnPrompt
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ResetOnPromptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetOnPromptProperty, (object)value);
		}
	}

	public bool ResetOnSpace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ResetOnSpaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetOnSpaceProperty, (object)value);
		}
	}

	public bool RestrictToAscii
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RestrictToAsciiProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RestrictToAsciiProperty, (object)value);
		}
	}

	public bool SkipLiterals
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SkipLiteralsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SkipLiteralsProperty, (object)value);
		}
	}

	internal bool IsForcingMask => m_forcingMask;

	internal string FormatSpecifier
	{
		get
		{
			return m_formatSpecifier;
		}
		set
		{
			m_formatSpecifier = value;
		}
	}

	internal override bool IsTextReadyToBeParsed => IsMaskCompleted;

	private bool IsOverwriteMode
	{
		get
		{
			if (!m_maskIsNull)
			{
				switch (InsertKeyMode)
				{
				case InsertKeyMode.Default:
					return m_insertToggled;
				case InsertKeyMode.Insert:
					return false;
				case InsertKeyMode.Overwrite:
					return true;
				}
			}
			return false;
		}
	}

	private string MaskedTextOutput => m_maskedTextProvider.ToString();

	public event EventHandler<AutoCompletingMaskEventArgs> AutoCompletingMask;

	private static string GetRawText(MaskedTextProvider provider)
	{
		return provider.ToString(ignorePasswordChar: true, includePrompt: false, includeLiterals: false, 0, provider.Length);
	}

	public static string GetFormatSpecifierFromMask(string mask, IFormatProvider formatProvider)
	{
		List<int> unhandledLiteralsPositions;
		return GetFormatSpecifierFromMask(mask, MaskChars, formatProvider, includeNonSeparatorLiteralsInValue: true, out unhandledLiteralsPositions);
	}

	private static string GetFormatSpecifierFromMask(string mask, char[] maskChars, IFormatProvider formatProvider, bool includeNonSeparatorLiteralsInValue, out List<int> unhandledLiteralsPositions)
	{
		unhandledLiteralsPositions = new List<int>();
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
		StringBuilder stringBuilder = new StringBuilder(32);
		bool flag = false;
		int i = 0;
		int num = 0;
		for (; i < mask.Length; i++)
		{
			char c = mask[i];
			if (c == '\\' && !flag)
			{
				flag = true;
				continue;
			}
			if (flag || Array.IndexOf(maskChars, c) < 0)
			{
				flag = false;
				stringBuilder.Append('\\');
				stringBuilder.Append(c);
				if (!includeNonSeparatorLiteralsInValue && c != ' ')
				{
					unhandledLiteralsPositions.Add(num);
				}
				num++;
				continue;
			}
			switch (c)
			{
			case '#':
			case '0':
			case '9':
				stringBuilder.Append('0');
				num++;
				break;
			case '.':
				stringBuilder.Append('.');
				num += instance.NumberDecimalSeparator.Length;
				break;
			case ',':
				stringBuilder.Append(',');
				num += instance.NumberGroupSeparator.Length;
				break;
			case '$':
			{
				string currencySymbol = instance.CurrencySymbol;
				stringBuilder.Append('"');
				stringBuilder.Append(currencySymbol);
				stringBuilder.Append('"');
				for (int j = 0; j < currencySymbol.Length; j++)
				{
					if (!includeNonSeparatorLiteralsInValue)
					{
						unhandledLiteralsPositions.Add(num);
					}
					num++;
				}
				break;
			}
			default:
				stringBuilder.Append(c);
				if (!includeNonSeparatorLiteralsInValue && c != ' ')
				{
					unhandledLiteralsPositions.Add(num);
				}
				num++;
				break;
			}
		}
		return stringBuilder.ToString();
	}

	static MaskedTextBox()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected Obj, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Obj, but got Unknown
		//IL_0214: Expected Obj, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected Obj, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected Obj, but got Unknown
		//IL_025b: Expected Obj, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected Obj, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected Obj, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected Obj, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected Obj, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Obj, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected Obj, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected Obj, but got Unknown
		//IL_0343: Expected Obj, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected Obj, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected Obj, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected Obj, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected Obj, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected Obj, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected Obj, but got Unknown
		MaskChars = new char[18]
		{
			'0', '9', '#', 'L', '?', '&', 'C', 'A', 'a', '.',
			',', ':', '/', '$', '<', '>', '|', '\\'
		};
		DefaultPasswordChar = '\0';
		NullMaskString = "<>";
		AllowPromptAsInputProperty = DependencyProperty.Register("AllowPromptAsInput", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)AllowPromptAsInputPropertyChangedCallback));
		ClipboardMaskFormatProperty = DependencyProperty.Register("ClipboardMaskFormat", typeof(MaskFormat), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)MaskFormat.IncludeLiterals));
		HidePromptOnLeaveProperty = DependencyProperty.Register("HidePromptOnLeave", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IncludeLiteralsInValueProperty = DependencyProperty.Register("IncludeLiteralsInValue", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)InlcudeLiteralsInValuePropertyChangedCallback));
		IncludePromptInValueProperty = DependencyProperty.Register("IncludePromptInValue", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)IncludePromptInValuePropertyChangedCallback));
		InsertKeyModeProperty = DependencyProperty.Register("InsertKeyMode", typeof(InsertKeyMode), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)InsertKeyMode.Default));
		IsMaskCompletedPropertyKey = DependencyProperty.RegisterReadOnly("IsMaskCompleted", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		IsMaskCompletedProperty = IsMaskCompletedPropertyKey.DependencyProperty;
		IsMaskFullPropertyKey = DependencyProperty.RegisterReadOnly("IsMaskFull", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		IsMaskFullProperty = IsMaskFullPropertyKey.DependencyProperty;
		MaskProperty = DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty, (PropertyChangedCallback)MaskPropertyChangedCallback, (CoerceValueCallback)MaskCoerceValueCallback));
		PromptCharProperty = DependencyProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)'_', (PropertyChangedCallback)PromptCharPropertyChangedCallback, (CoerceValueCallback)PromptCharCoerceValueCallback));
		RejectInputOnFirstFailureProperty = DependencyProperty.Register("RejectInputOnFirstFailure", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ResetOnPromptProperty = DependencyProperty.Register("ResetOnPrompt", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)ResetOnPromptPropertyChangedCallback));
		ResetOnSpaceProperty = DependencyProperty.Register("ResetOnSpace", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)ResetOnSpacePropertyChangedCallback));
		RestrictToAsciiProperty = DependencyProperty.Register("RestrictToAscii", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)RestrictToAsciiPropertyChangedCallback, (CoerceValueCallback)RestrictToAsciiCoerceValueCallback));
		SkipLiteralsProperty = DependencyProperty.Register("SkipLiterals", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)SkipLiteralsPropertyChangedCallback));
		TextBox.TextProperty.OverrideMetadata(typeof(MaskedTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)null, (CoerceValueCallback)TextCoerceValueCallback));
		AutomationProperties.AutomationIdProperty.OverrideMetadata(typeof(MaskedTextBox), (PropertyMetadata)new UIPropertyMetadata((object)"MaskedTextBox"));
	}

	public MaskedTextBox()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected Obj, but got Unknown
		CommandManager.AddPreviewCanExecuteHandler((UIElement)(object)this, (CanExecuteRoutedEventHandler)OnPreviewCanExecuteCommands);
		CommandManager.AddPreviewExecutedHandler((UIElement)(object)this, (ExecutedRoutedEventHandler)OnPreviewExecutedCommands);
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Paste, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecutePaste));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Cut, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteCut));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Copy, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteCopy));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)EditingCommands.ToggleInsert, (ExecutedRoutedEventHandler)ToggleInsertExecutedCallback));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)EditingCommands.Delete, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteDelete));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)EditingCommands.DeletePreviousWord, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteDeletePreviousWord));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)EditingCommands.DeleteNextWord, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteDeleteNextWord));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)EditingCommands.Backspace, (ExecutedRoutedEventHandler)null, (CanExecuteRoutedEventHandler)CanExecuteBackspace));
		DragDrop.AddPreviewQueryContinueDragHandler((DependencyObject)(object)this, (QueryContinueDragEventHandler)PreviewQueryContinueDragCallback);
		((UIElement)this).AllowDrop = false;
	}

	private void InitializeMaskedTextProvider()
	{
		string text = ((TextBox)this).Text;
		string mask = Mask;
		if (mask == string.Empty)
		{
			m_maskedTextProvider = CreateMaskedTextProvider(NullMaskString);
			m_maskIsNull = true;
		}
		else
		{
			m_maskedTextProvider = CreateMaskedTextProvider(mask);
			m_maskIsNull = false;
		}
		if (!m_maskIsNull && text != string.Empty && !m_maskedTextProvider.Add(text) && !DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			throw new InvalidOperationException("An attempt was made to apply a new mask that cannot be applied to the current text.");
		}
	}

	protected override void OnInitialized(EventArgs e)
	{
		InitializeMaskedTextProvider();
		SetIsMaskCompleted(m_maskedTextProvider.MaskCompleted);
		SetIsMaskFull(m_maskedTextProvider.MaskFull);
		base.OnInitialized(e);
	}

	private static void AllowPromptAsInputPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask);
		}
	}

	private static void InlcudeLiteralsInValuePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized)
		{
			maskedTextBox.RefreshConversionHelpers();
			maskedTextBox.RefreshValue();
		}
	}

	private static void IncludePromptInValuePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized)
		{
			maskedTextBox.RefreshValue();
		}
	}

	private void SetIsMaskCompleted(bool value)
	{
		((DependencyObject)this).SetValue(IsMaskCompletedPropertyKey, (object)value);
	}

	private void SetIsMaskFull(bool value)
	{
		((DependencyObject)this).SetValue(IsMaskFullPropertyKey, (object)value);
	}

	private static object MaskCoerceValueCallback(DependencyObject sender, object value)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		if (value.Equals(string.Empty))
		{
			return value;
		}
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!((FrameworkElement)maskedTextBox).IsInitialized)
		{
			return value;
		}
		bool flag;
		try
		{
			MaskedTextProvider maskedTextProvider = maskedTextBox.CreateMaskedTextProvider((string)value);
			string rawText = maskedTextBox.GetRawText();
			flag = maskedTextProvider.VerifyString(rawText);
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("An error occured while testing the current text against the new mask.", innerException);
		}
		if (!flag)
		{
			throw new ArgumentException("The mask cannot be applied to the current text.", "Mask");
		}
		return value;
	}

	private static void MaskPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized)
		{
			MaskedTextProvider maskedTextProvider = null;
			string text = (string)e.NewValue;
			if (text == string.Empty)
			{
				maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(NullMaskString);
				maskedTextBox.m_maskIsNull = true;
			}
			else
			{
				maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(text);
				maskedTextBox.m_maskIsNull = false;
			}
			maskedTextBox.m_maskedTextProvider = maskedTextProvider;
			maskedTextBox.RefreshConversionHelpers();
			if (maskedTextBox.ValueDataType != null)
			{
				string textFromValue = maskedTextBox.GetTextFromValue(maskedTextBox.Value);
				maskedTextBox.m_maskedTextProvider.Set(textFromValue);
			}
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static object PromptCharCoerceValueCallback(object sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!((FrameworkElement)maskedTextBox).IsInitialized)
		{
			return value;
		}
		MaskedTextProvider maskedTextProvider = maskedTextBox.m_maskedTextProvider.Clone() as MaskedTextProvider;
		try
		{
			maskedTextProvider.PromptChar = (char)value;
			return value;
		}
		catch (Exception innerException)
		{
			throw new ArgumentException("The prompt character is invalid.", innerException);
		}
	}

	private static void PromptCharPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.PromptChar = (char)e.NewValue;
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static void ResetOnPromptPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.ResetOnPrompt = (bool)e.NewValue;
		}
	}

	private static void ResetOnSpacePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.ResetOnSpace = (bool)e.NewValue;
		}
	}

	private static object RestrictToAsciiCoerceValueCallback(object sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!((FrameworkElement)maskedTextBox).IsInitialized)
		{
			return value;
		}
		if (maskedTextBox.m_maskIsNull)
		{
			return value;
		}
		bool flag = (bool)value;
		if (!flag)
		{
			return value;
		}
		MaskedTextProvider maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask, maskedTextBox.GetCultureInfo(), maskedTextBox.AllowPromptAsInput, maskedTextBox.PromptChar, DefaultPasswordChar, flag);
		if (!maskedTextProvider.VerifyString(((TextBox)maskedTextBox).Text))
		{
			throw new ArgumentException("The current text cannot be restricted to ASCII characters. The RestrictToAscii property is set to true.", "RestrictToAscii");
		}
		return flag;
	}

	private static void RestrictToAsciiPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask);
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static void SkipLiteralsPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (((FrameworkElement)maskedTextBox).IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.SkipLiterals = (bool)e.NewValue;
		}
	}

	private static object TextCoerceValueCallback(DependencyObject sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!((FrameworkElement)maskedTextBox).IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (maskedTextBox.IsInIMEComposition)
		{
			return value;
		}
		if (value == null)
		{
			value = string.Empty;
		}
		if (maskedTextBox.IsForcingText || maskedTextBox.m_maskIsNull)
		{
			return value;
		}
		return maskedTextBox.ValidateText((string)value);
	}

	private string ValidateText(string text)
	{
		string text2 = text;
		if (RejectInputOnFirstFailure)
		{
			MaskedTextProvider maskedTextProvider = m_maskedTextProvider.Clone() as MaskedTextProvider;
			if (maskedTextProvider.Set(text, out var _, out var _))
			{
				text2 = GetFormattedString(maskedTextProvider);
			}
			else
			{
				text2 = GetFormattedString(m_maskedTextProvider);
				m_maskedTextProvider.Set(text2);
			}
		}
		else
		{
			MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
			if (CanReplace(provider, text, 0, m_maskedTextProvider.Length, RejectInputOnFirstFailure, out var _))
			{
				text2 = GetFormattedString(provider);
			}
			else
			{
				text2 = GetFormattedString(m_maskedTextProvider);
				m_maskedTextProvider.Set(text2);
			}
		}
		return text2;
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		if (!m_maskIsNull && (IsInValueChanged || !IsForcingText))
		{
			string text = ((TextBox)this).Text;
			if (m_maskIsNull)
			{
				((TextBox)this).CaretIndex = text.Length;
			}
			else
			{
				m_maskedTextProvider.Set(text);
				int num = m_maskedTextProvider.FindUnassignedEditPositionFrom(0, direction: true);
				if (num == -1)
				{
					num = m_maskedTextProvider.Length;
				}
				((TextBox)this).CaretIndex = num;
			}
		}
		if (m_maskedTextProvider != null)
		{
			SetIsMaskCompleted(m_maskedTextProvider.MaskCompleted);
			SetIsMaskFull(m_maskedTextProvider.MaskFull);
		}
		base.OnTextChanged(e);
	}

	private void OnPreviewCanExecuteCommands(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		ICommand command = e.Command;
		RoutedUICommand val = (RoutedUICommand)((command is RoutedUICommand) ? command : null);
		if (val != null && (((RoutedCommand)val).Name == "Space" || ((RoutedCommand)val).Name == "ShiftSpace"))
		{
			if (((TextBoxBase)this).IsReadOnly)
			{
				e.CanExecute = false;
			}
			else
			{
				MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
				e.CanExecute = CanReplace(provider, " ", ((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, RejectInputOnFirstFailure, out var _);
			}
			((RoutedEventArgs)e).Handled = true;
		}
		else if (e.Command == ApplicationCommands.Undo || e.Command == ApplicationCommands.Redo)
		{
			e.CanExecute = false;
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnPreviewExecutedCommands(object sender, ExecutedRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		if (e.Command == EditingCommands.Delete)
		{
			((RoutedEventArgs)e).Handled = true;
			Delete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: true);
			return;
		}
		if (e.Command == EditingCommands.DeleteNextWord)
		{
			((RoutedEventArgs)e).Handled = true;
			((RoutedCommand)EditingCommands.SelectRightByWord).Execute((object)null, (IInputElement)(object)this);
			Delete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: true);
			return;
		}
		if (e.Command == EditingCommands.DeletePreviousWord)
		{
			((RoutedEventArgs)e).Handled = true;
			((RoutedCommand)EditingCommands.SelectLeftByWord).Execute((object)null, (IInputElement)(object)this);
			Delete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: false);
			return;
		}
		if (e.Command == EditingCommands.Backspace)
		{
			((RoutedEventArgs)e).Handled = true;
			Delete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: false);
			return;
		}
		if (e.Command == ApplicationCommands.Cut)
		{
			((RoutedEventArgs)e).Handled = true;
			if (((RoutedCommand)ApplicationCommands.Copy).CanExecute((object)null, (IInputElement)(object)this))
			{
				((RoutedCommand)ApplicationCommands.Copy).Execute((object)null, (IInputElement)(object)this);
			}
			Delete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: true);
			return;
		}
		if (e.Command == ApplicationCommands.Copy)
		{
			((RoutedEventArgs)e).Handled = true;
			ExecuteCopy();
			return;
		}
		if (e.Command == ApplicationCommands.Paste)
		{
			((RoutedEventArgs)e).Handled = true;
			string text = (string)Clipboard.GetDataObject().GetData("System.String");
			Replace(text, ((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength);
			return;
		}
		ICommand command = e.Command;
		RoutedUICommand val = (RoutedUICommand)((command is RoutedUICommand) ? command : null);
		if (val != null && (((RoutedCommand)val).Name == "Space" || ((RoutedCommand)val).Name == "ShiftSpace"))
		{
			((RoutedEventArgs)e).Handled = true;
			ProcessTextInput(" ");
		}
	}

	private void CanExecuteDelete(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = CanDelete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: true, MaskedTextProvider.Clone() as MaskedTextProvider);
			((RoutedEventArgs)e).Handled = true;
			if (!e.CanExecute && BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
		}
	}

	private void CanExecuteDeletePreviousWord(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool flag = !((TextBoxBase)this).IsReadOnly && ((RoutedCommand)EditingCommands.SelectLeftByWord).CanExecute((object)null, (IInputElement)(object)this);
		if (flag)
		{
			int selectionStart = ((TextBox)this).SelectionStart;
			int selectionLength = ((TextBox)this).SelectionLength;
			((RoutedCommand)EditingCommands.SelectLeftByWord).Execute((object)null, (IInputElement)(object)this);
			flag = CanDelete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: false, MaskedTextProvider.Clone() as MaskedTextProvider);
			if (!flag)
			{
				((TextBox)this).SelectionStart = selectionStart;
				((TextBox)this).SelectionLength = selectionLength;
			}
		}
		e.CanExecute = flag;
		((RoutedEventArgs)e).Handled = true;
		if (!e.CanExecute && BeepOnError)
		{
			SystemSounds.Beep.Play();
		}
	}

	private void CanExecuteDeleteNextWord(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool flag = !((TextBoxBase)this).IsReadOnly && ((RoutedCommand)EditingCommands.SelectRightByWord).CanExecute((object)null, (IInputElement)(object)this);
		if (flag)
		{
			int selectionStart = ((TextBox)this).SelectionStart;
			int selectionLength = ((TextBox)this).SelectionLength;
			((RoutedCommand)EditingCommands.SelectRightByWord).Execute((object)null, (IInputElement)(object)this);
			flag = CanDelete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: true, MaskedTextProvider.Clone() as MaskedTextProvider);
			if (!flag)
			{
				((TextBox)this).SelectionStart = selectionStart;
				((TextBox)this).SelectionLength = selectionLength;
			}
		}
		e.CanExecute = flag;
		((RoutedEventArgs)e).Handled = true;
		if (!e.CanExecute && BeepOnError)
		{
			SystemSounds.Beep.Play();
		}
	}

	private void CanExecuteBackspace(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = CanDelete(((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, deleteForward: false, MaskedTextProvider.Clone() as MaskedTextProvider);
			((RoutedEventArgs)e).Handled = true;
			if (!e.CanExecute && BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
		}
	}

	private void CanExecuteCut(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			bool flag = !((TextBoxBase)this).IsReadOnly && ((TextBox)this).SelectionLength > 0;
			if (flag)
			{
				int endPosition = ((((TextBox)this).SelectionLength > 0) ? (((TextBox)this).SelectionStart + ((TextBox)this).SelectionLength - 1) : ((TextBox)this).SelectionStart);
				MaskedTextProvider maskedTextProvider = m_maskedTextProvider.Clone() as MaskedTextProvider;
				flag = maskedTextProvider.RemoveAt(((TextBox)this).SelectionStart, endPosition);
			}
			e.CanExecute = flag;
			((RoutedEventArgs)e).Handled = true;
			if (!flag && BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
		}
	}

	private void CanExecutePaste(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool canExecute = false;
		if (!((TextBoxBase)this).IsReadOnly)
		{
			string empty = string.Empty;
			try
			{
				empty = (string)Clipboard.GetDataObject().GetData("System.String");
				if (empty != null)
				{
					MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
					canExecute = CanReplace(provider, empty, ((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, RejectInputOnFirstFailure, out var _);
				}
			}
			catch
			{
			}
		}
		e.CanExecute = canExecute;
		((RoutedEventArgs)e).Handled = true;
		if (!e.CanExecute && BeepOnError)
		{
			SystemSounds.Beep.Play();
		}
	}

	private void CanExecuteCopy(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = !m_maskedTextProvider.IsPassword;
			((RoutedEventArgs)e).Handled = true;
			if (!e.CanExecute && BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
		}
	}

	private void ExecuteCopy()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		string selectedText = GetSelectedText();
		try
		{
			((CodeAccessPermission)new UIPermission((UIPermissionClipboard)2)).Demand();
			if (selectedText.Length == 0)
			{
				Clipboard.Clear();
			}
			else
			{
				Clipboard.SetText(selectedText);
			}
		}
		catch (SecurityException)
		{
		}
	}

	private void ToggleInsertExecutedCallback(object sender, ExecutedRoutedEventArgs e)
	{
		m_insertToggled = !m_insertToggled;
	}

	private void PreviewQueryContinueDragCallback(object sender, QueryContinueDragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Action = (DragAction)2;
			((RoutedEventArgs)e).Handled = true;
		}
	}

	protected override void OnDragEnter(DragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Effects = (DragDropEffects)0;
			((RoutedEventArgs)e).Handled = true;
		}
		((TextBoxBase)this).OnDragEnter(e);
	}

	protected override void OnDragOver(DragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Effects = (DragDropEffects)0;
			((RoutedEventArgs)e).Handled = true;
		}
		((TextBoxBase)this).OnDragOver(e);
	}

	protected override bool QueryValueFromTextCore(string text, out object value)
	{
		Type valueDataType = ValueDataType;
		if (valueDataType != null && m_unhandledLiteralsPositions != null && m_unhandledLiteralsPositions.Count > 0)
		{
			text = m_maskedTextProvider.ToString(ignorePasswordChar: false, includePrompt: false, includeLiterals: true, 0, m_maskedTextProvider.Length);
			for (int num = m_unhandledLiteralsPositions.Count - 1; num >= 0; num--)
			{
				text = text.Remove(m_unhandledLiteralsPositions[num], 1);
			}
		}
		return base.QueryValueFromTextCore(text, out value);
	}

	protected override string QueryTextFromValueCore(object value)
	{
		if (m_valueToStringMethodInfo != null && value != null)
		{
			try
			{
				return (string)m_valueToStringMethodInfo.Invoke(value, new object[2]
				{
					m_formatSpecifier,
					GetActiveFormatProvider()
				});
			}
			catch
			{
			}
		}
		return base.QueryTextFromValueCore(value);
	}

	protected virtual char[] GetMaskCharacters()
	{
		return MaskChars;
	}

	private MaskedTextProvider CreateMaskedTextProvider(string mask)
	{
		return CreateMaskedTextProvider(mask, GetCultureInfo(), AllowPromptAsInput, PromptChar, DefaultPasswordChar, RestrictToAscii);
	}

	protected virtual MaskedTextProvider CreateMaskedTextProvider(string mask, CultureInfo cultureInfo, bool allowPromptAsInput, char promptChar, char passwordChar, bool restrictToAscii)
	{
		MaskedTextProvider maskedTextProvider = new MaskedTextProvider(mask, cultureInfo, allowPromptAsInput, promptChar, passwordChar, restrictToAscii);
		maskedTextProvider.ResetOnPrompt = ResetOnPrompt;
		maskedTextProvider.ResetOnSpace = ResetOnSpace;
		maskedTextProvider.SkipLiterals = SkipLiterals;
		maskedTextProvider.IncludeLiterals = true;
		maskedTextProvider.IncludePrompt = true;
		maskedTextProvider.IsPassword = false;
		return maskedTextProvider;
	}

	internal override void OnIMECompositionEnded(CachedTextInfo cachedTextInfo)
	{
		ForceText(cachedTextInfo.Text, preserveCaret: false);
		((TextBox)this).CaretIndex = cachedTextInfo.CaretIndex;
		((TextBox)this).SelectionStart = cachedTextInfo.SelectionStart;
		((TextBox)this).SelectionLength = cachedTextInfo.SelectionLength;
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (IsInIMEComposition)
		{
			EndIMEComposition();
		}
		if (m_maskIsNull || m_maskedTextProvider == null || ((TextBoxBase)this).IsReadOnly)
		{
			base.OnTextInput(e);
			return;
		}
		((RoutedEventArgs)e).Handled = true;
		ProcessTextInput(e.Text);
		base.OnTextInput(e);
	}

	private void ProcessTextInput(string text)
	{
		if (text.Length == 1)
		{
			string maskedTextOutput = MaskedTextOutput;
			if (PlaceChar(text[0], ((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength, IsOverwriteMode, out var caretIndex))
			{
				if (MaskedTextOutput != maskedTextOutput)
				{
					RefreshCurrentText(preserveCurrentCaretPosition: false);
				}
				((TextBox)this).SelectionStart = caretIndex + 1;
			}
			else if (BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
			if (((TextBox)this).SelectionLength > 0)
			{
				((TextBox)this).SelectionLength = 0;
			}
		}
		else
		{
			Replace(text, ((TextBox)this).SelectionStart, ((TextBox)this).SelectionLength);
		}
	}

	protected override void ValidateValue(object value)
	{
		base.ValidateValue(value);
		if (!m_maskIsNull)
		{
			string textFromValue = GetTextFromValue(value);
			MaskedTextProvider maskedTextProvider = m_maskedTextProvider.Clone() as MaskedTextProvider;
			if (!maskedTextProvider.VerifyString(textFromValue))
			{
				throw new ArgumentException("The value representation '" + textFromValue + "' does not match the mask.", "value");
			}
		}
	}

	internal override bool GetIsEditTextEmpty()
	{
		return MaskedTextProvider.AssignedEditPositionCount == 0;
	}

	internal override string GetCurrentText()
	{
		if (m_maskIsNull)
		{
			return base.GetCurrentText();
		}
		return GetFormattedString(m_maskedTextProvider);
	}

	internal override string GetParsableText()
	{
		if (m_maskIsNull)
		{
			return base.GetParsableText();
		}
		bool flag = false;
		bool flag2 = true;
		if (ValueDataType == typeof(string))
		{
			flag = IncludePromptInValue;
			flag2 = IncludeLiteralsInValue;
		}
		return m_maskedTextProvider.ToString(ignorePasswordChar: false, flag, flag2, 0, m_maskedTextProvider.Length);
	}

	internal override void OnFormatProviderChanged()
	{
		MaskedTextProvider maskedTextProvider = new MaskedTextProvider(Mask);
		m_maskedTextProvider = maskedTextProvider;
		RefreshConversionHelpers();
		RefreshCurrentText(preserveCurrentCaretPosition: true);
		base.OnFormatProviderChanged();
	}

	internal override void RefreshConversionHelpers()
	{
		Type valueDataType = ValueDataType;
		if (valueDataType == null || !IsNumericValueDataType)
		{
			m_formatSpecifier = null;
			m_valueToStringMethodInfo = null;
			m_unhandledLiteralsPositions = null;
			return;
		}
		m_valueToStringMethodInfo = valueDataType.GetMethod("ToString", new Type[2]
		{
			typeof(string),
			typeof(IFormatProvider)
		});
		string mask = m_maskedTextProvider.Mask;
		IFormatProvider activeFormatProvider = GetActiveFormatProvider();
		char[] maskCharacters = GetMaskCharacters();
		m_formatSpecifier = GetFormatSpecifierFromMask(mask, maskCharacters, activeFormatProvider, IncludeLiteralsInValue, out var unhandledLiteralsPositions);
		if (activeFormatProvider.GetFormat(typeof(NumberFormatInfo)) is NumberFormatInfo numberFormatInfo)
		{
			string negativeSign = numberFormatInfo.NegativeSign;
			if (m_formatSpecifier.Contains(negativeSign))
			{
				m_formatSpecifier = m_formatSpecifier + ";" + m_formatSpecifier + ";" + m_formatSpecifier;
			}
		}
		m_unhandledLiteralsPositions = unhandledLiteralsPositions;
	}

	internal void SetValueToStringMethodInfo(MethodInfo valueToStringMethodInfo)
	{
		m_valueToStringMethodInfo = valueToStringMethodInfo;
	}

	internal void ForceMask(string mask)
	{
		m_forcingMask = true;
		try
		{
			Mask = mask;
		}
		finally
		{
			m_forcingMask = false;
		}
	}

	private bool PlaceChar(char ch, int startPosition, int length, bool overwrite, out int caretIndex)
	{
		return PlaceChar(m_maskedTextProvider, ch, startPosition, length, overwrite, out caretIndex);
	}

	private bool PlaceChar(MaskedTextProvider provider, char ch, int startPosition, int length, bool overwrite, out int caretPosition)
	{
		if (ShouldQueryAutoCompleteMask(provider.Clone() as MaskedTextProvider, ch, startPosition))
		{
			AutoCompletingMaskEventArgs e = new AutoCompletingMaskEventArgs(m_maskedTextProvider.Clone() as MaskedTextProvider, startPosition, length, ch.ToString());
			OnAutoCompletingMask(e);
			if (!e.Cancel && e.AutoCompleteStartPosition > -1)
			{
				caretPosition = startPosition;
				for (int i = 0; i < e.AutoCompleteText.Length; i++)
				{
					if (!PlaceCharCore(provider, e.AutoCompleteText[i], e.AutoCompleteStartPosition + i, 0, overwrite: true, out caretPosition))
					{
						return false;
					}
				}
				caretPosition = e.AutoCompleteStartPosition + e.AutoCompleteText.Length;
				return true;
			}
		}
		return PlaceCharCore(provider, ch, startPosition, length, overwrite, out caretPosition);
	}

	private bool ShouldQueryAutoCompleteMask(MaskedTextProvider provider, char ch, int startPosition)
	{
		if (provider.IsEditPosition(startPosition))
		{
			int num = provider.FindNonEditPositionFrom(startPosition, direction: true);
			if (num != -1 && provider[num].Equals(ch))
			{
				int startPosition2 = provider.FindNonEditPositionFrom(startPosition, direction: false);
				if (provider.FindUnassignedEditPositionInRange(startPosition2, num, direction: true) != -1)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected virtual void OnAutoCompletingMask(AutoCompletingMaskEventArgs e)
	{
		if (AutoCompletingMask != null)
		{
			AutoCompletingMask(this, e);
		}
	}

	private bool PlaceCharCore(MaskedTextProvider provider, char ch, int startPosition, int length, bool overwrite, out int caretPosition)
	{
		caretPosition = startPosition;
		if (startPosition < m_maskedTextProvider.Length)
		{
			MaskedTextResultHint resultHint;
			if (length > 0)
			{
				int endPosition = startPosition + length - 1;
				return provider.Replace(ch, startPosition, endPosition, out caretPosition, out resultHint);
			}
			if (overwrite)
			{
				return provider.Replace(ch, startPosition, out caretPosition, out resultHint);
			}
			return provider.InsertAt(ch, startPosition, out caretPosition, out resultHint);
		}
		return false;
	}

	internal void Replace(string text, int startPosition, int selectionLength)
	{
		MaskedTextProvider maskedTextProvider = (MaskedTextProvider)m_maskedTextProvider.Clone();
		if (CanReplace(maskedTextProvider, text, startPosition, selectionLength, RejectInputOnFirstFailure, out var tentativeCaretIndex))
		{
			bool flag = MaskedTextOutput != maskedTextProvider.ToString();
			m_maskedTextProvider = maskedTextProvider;
			if (flag)
			{
				RefreshCurrentText(preserveCurrentCaretPosition: false);
			}
			((TextBox)this).CaretIndex = tentativeCaretIndex + 1;
		}
		else if (BeepOnError)
		{
			SystemSounds.Beep.Play();
		}
	}

	internal virtual bool CanReplace(MaskedTextProvider provider, string text, int startPosition, int selectionLength, bool rejectInputOnFirstFailure, out int tentativeCaretIndex)
	{
		int num = startPosition + selectionLength - 1;
		tentativeCaretIndex = -1;
		bool result = false;
		foreach (char c in text)
		{
			if (!m_maskedTextProvider.VerifyEscapeChar(c, startPosition))
			{
				int num2 = provider.FindEditPositionFrom(startPosition, direction: true);
				if (num2 == MaskedTextProvider.InvalidIndex)
				{
					break;
				}
				startPosition = num2;
			}
			int num3 = ((num >= startPosition) ? 1 : 0);
			bool overwrite = num3 > 0;
			if (PlaceChar(provider, c, startPosition, num3, overwrite, out tentativeCaretIndex))
			{
				result = true;
				startPosition = tentativeCaretIndex + 1;
			}
			else if (rejectInputOnFirstFailure)
			{
				return false;
			}
		}
		if (selectionLength > 0 && startPosition <= num && !provider.RemoveAt(startPosition, num, out var _, out var _))
		{
			result = false;
		}
		return result;
	}

	private bool CanDelete(int startPosition, int selectionLength, bool deleteForward, MaskedTextProvider provider)
	{
		if (((TextBoxBase)this).IsReadOnly)
		{
			return false;
		}
		if (selectionLength == 0)
		{
			if (!deleteForward)
			{
				if (startPosition == 0)
				{
					return false;
				}
				startPosition--;
			}
			else if (startPosition + selectionLength == provider.Length)
			{
				return false;
			}
		}
		int testPosition = startPosition;
		int endPosition = ((selectionLength > 0) ? (startPosition + selectionLength - 1) : startPosition);
		MaskedTextResultHint resultHint;
		return provider.RemoveAt(startPosition, endPosition, out testPosition, out resultHint);
	}

	private void Delete(int startPosition, int selectionLength, bool deleteForward)
	{
		if (((TextBoxBase)this).IsReadOnly)
		{
			return;
		}
		if (selectionLength == 0)
		{
			if (!deleteForward)
			{
				if (startPosition == 0)
				{
					return;
				}
				startPosition--;
			}
			else if (startPosition + selectionLength == m_maskedTextProvider.Length)
			{
				return;
			}
		}
		int testPosition = startPosition;
		int endPosition = ((selectionLength > 0) ? (startPosition + selectionLength - 1) : startPosition);
		string maskedTextOutput = MaskedTextOutput;
		if (!m_maskedTextProvider.RemoveAt(startPosition, endPosition, out testPosition, out var resultHint))
		{
			if (BeepOnError)
			{
				SystemSounds.Beep.Play();
			}
			return;
		}
		if (MaskedTextOutput != maskedTextOutput)
		{
			RefreshCurrentText(preserveCurrentCaretPosition: false);
		}
		else if (selectionLength > 0)
		{
			testPosition = startPosition;
		}
		else if (resultHint == MaskedTextResultHint.NoEffect)
		{
			if (deleteForward)
			{
				testPosition = m_maskedTextProvider.FindEditPositionFrom(startPosition, direction: true);
			}
			else
			{
				testPosition = ((m_maskedTextProvider.FindAssignedEditPositionFrom(startPosition, direction: true) != MaskedTextProvider.InvalidIndex) ? m_maskedTextProvider.FindEditPositionFrom(startPosition, direction: false) : m_maskedTextProvider.FindAssignedEditPositionFrom(startPosition, direction: false));
				if (testPosition != MaskedTextProvider.InvalidIndex)
				{
					testPosition++;
				}
			}
			if (testPosition == MaskedTextProvider.InvalidIndex)
			{
				testPosition = startPosition;
			}
		}
		else if (!deleteForward)
		{
			testPosition = startPosition;
		}
		((TextBox)this).CaretIndex = testPosition;
	}

	private string GetRawText()
	{
		if (m_maskIsNull)
		{
			return ((TextBox)this).Text;
		}
		return GetRawText(m_maskedTextProvider);
	}

	private string GetFormattedString(MaskedTextProvider provider)
	{
		bool flag = !((TextBoxBase)this).IsReadOnly && (!HidePromptOnLeave || ((UIElement)this).IsFocused);
		return provider.ToString(ignorePasswordChar: false, flag, includeLiterals: true, 0, m_maskedTextProvider.Length);
	}

	private string GetSelectedText()
	{
		int selectionLength = ((TextBox)this).SelectionLength;
		if (selectionLength == 0)
		{
			return string.Empty;
		}
		bool flag = (ClipboardMaskFormat & MaskFormat.IncludePrompt) != 0;
		bool flag2 = (ClipboardMaskFormat & MaskFormat.IncludeLiterals) != 0;
		return m_maskedTextProvider.ToString(ignorePasswordChar: true, flag, flag2, ((TextBox)this).SelectionStart, selectionLength);
	}
}
