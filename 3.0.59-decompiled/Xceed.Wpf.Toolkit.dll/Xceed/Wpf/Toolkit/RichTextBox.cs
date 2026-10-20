using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public class RichTextBox : RichTextBox
{
	private bool _preventDocumentUpdate;

	private bool _preventTextUpdate;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(RichTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)string.Empty, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnTextPropertyChanged, (CoerceValueCallback)CoerceTextProperty, true, (UpdateSourceTrigger)2));

	public static readonly DependencyProperty TextFormatterProperty = DependencyProperty.Register("TextFormatter", typeof(ITextFormatter), typeof(RichTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)new RtfFormatter(), (PropertyChangedCallback)OnTextFormatterPropertyChanged));

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

	public ITextFormatter TextFormatter
	{
		get
		{
			return (ITextFormatter)((DependencyObject)this).GetValue(TextFormatterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextFormatterProperty, (object)value);
		}
	}

	public RichTextBox()
	{
	}

	public RichTextBox(FlowDocument document)
		: base(document)
	{
	}

	private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((RichTextBox)(object)d).UpdateDocumentFromText();
	}

	private static object CoerceTextProperty(DependencyObject d, object value)
	{
		return value ?? "";
	}

	private static void OnTextFormatterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is RichTextBox richTextBox)
		{
			richTextBox.OnTextFormatterPropertyChanged((ITextFormatter)e.OldValue, (ITextFormatter)e.NewValue);
		}
	}

	protected virtual void OnTextFormatterPropertyChanged(ITextFormatter oldValue, ITextFormatter newValue)
	{
		UpdateTextFromDocument();
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		((TextBoxBase)this).OnTextChanged(e);
		UpdateTextFromDocument();
	}

	private void UpdateTextFromDocument()
	{
		if (!_preventTextUpdate)
		{
			_preventDocumentUpdate = true;
			Text = TextFormatter.GetText(((RichTextBox)this).Document);
			_preventDocumentUpdate = false;
		}
	}

	private void UpdateDocumentFromText()
	{
		if (!_preventDocumentUpdate)
		{
			_preventTextUpdate = true;
			TextFormatter.SetText(((RichTextBox)this).Document, Text);
			_preventTextUpdate = false;
		}
	}

	public void Clear()
	{
		((TextElementCollection<Block>)(object)((RichTextBox)this).Document.Blocks).Clear();
	}

	public override void BeginInit()
	{
		((FrameworkElement)this).BeginInit();
		_preventTextUpdate = true;
		_preventDocumentUpdate = true;
	}

	public override void EndInit()
	{
		((FrameworkElement)this).EndInit();
		_preventTextUpdate = false;
		_preventDocumentUpdate = false;
		if (!string.IsNullOrEmpty(Text))
		{
			UpdateDocumentFromText();
		}
		else
		{
			UpdateTextFromDocument();
		}
	}

	static RichTextBox()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0042: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
	}
}
