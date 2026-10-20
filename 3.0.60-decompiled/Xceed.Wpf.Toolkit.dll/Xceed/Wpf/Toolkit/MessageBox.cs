using System;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_NoButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_OkButton", Type = typeof(Button))]
[TemplateVisualState(Name = "OKCancel", GroupName = "MessageBoxButtonsGroup")]
[TemplateVisualState(Name = "YesNo", GroupName = "MessageBoxButtonsGroup")]
[TemplateVisualState(Name = "OK", GroupName = "MessageBoxButtonsGroup")]
[TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_YesButton", Type = typeof(Button))]
[TemplateVisualState(Name = "YesNoCancel", GroupName = "MessageBoxButtonsGroup")]
[TemplatePart(Name = "PART_WindowControl", Type = typeof(WindowControl))]
public class MessageBox : WindowControl
{
	private const string PART_CancelButton = "PART_CancelButton";

	private const string PART_NoButton = "PART_NoButton";

	private const string PART_OkButton = "PART_OkButton";

	private const string PART_YesButton = "PART_YesButton";

	private const string PART_CloseButton = "PART_CloseButton";

	private const string PART_WindowControl = "PART_WindowControl";

	private MessageBoxButton _button;

	private MessageBoxResult _defaultResult;

	private MessageBoxResult _dialogResult;

	private Window _owner;

	private WindowControl _windowControl;

	public static readonly DependencyProperty ButtonRegionBackgroundProperty;

	public static readonly DependencyProperty CancelButtonContentProperty;

	public static readonly DependencyProperty CancelButtonStyleProperty;

	public static readonly DependencyProperty ImageSourceProperty;

	public static readonly DependencyProperty OkButtonContentProperty;

	public static readonly DependencyProperty OkButtonStyleProperty;

	public static readonly DependencyProperty NoButtonContentProperty;

	public static readonly DependencyProperty NoButtonStyleProperty;

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty YesButtonContentProperty;

	public static readonly DependencyProperty YesButtonStyleProperty;

	protected Window Container
	{
		get
		{
			DependencyObject parent = ((FrameworkElement)this).Parent;
			return (Window)(object)((parent is Window) ? parent : null);
		}
	}

	public Brush ButtonRegionBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(ButtonRegionBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonRegionBackgroundProperty, (object)value);
		}
	}

	public object CancelButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(CancelButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonContentProperty, value);
		}
	}

	public Style CancelButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(CancelButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonStyleProperty, (object)value);
		}
	}

	public ImageSource ImageSource
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ImageSource)((DependencyObject)this).GetValue(ImageSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageSourceProperty, (object)value);
		}
	}

	public object OkButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(OkButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OkButtonContentProperty, value);
		}
	}

	public Style OkButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(OkButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OkButtonStyleProperty, (object)value);
		}
	}

	public MessageBoxResult MessageBoxResult
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _dialogResult;
		}
	}

	public object NoButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(NoButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoButtonContentProperty, value);
		}
	}

	public Style NoButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(NoButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoButtonStyleProperty, (object)value);
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

	public object YesButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(YesButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(YesButtonContentProperty, value);
		}
	}

	public Style YesButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(YesButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(YesButtonStyleProperty, (object)value);
		}
	}

	internal override bool AllowPublicIsActiveChange => false;

	public event EventHandler Closed;

	static MessageBox()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected Obj, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		ButtonRegionBackgroundProperty = DependencyProperty.Register("ButtonRegionBackground", typeof(Brush), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		CancelButtonContentProperty = DependencyProperty.Register("CancelButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)"Cancel"));
		CancelButtonStyleProperty = DependencyProperty.Register("CancelButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)null));
		OkButtonContentProperty = DependencyProperty.Register("OkButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)"OK"));
		OkButtonStyleProperty = DependencyProperty.Register("OkButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		NoButtonContentProperty = DependencyProperty.Register("NoButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)"No"));
		NoButtonStyleProperty = DependencyProperty.Register("NoButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty));
		YesButtonContentProperty = DependencyProperty.Register("YesButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)new UIPropertyMetadata((object)"Yes"));
		YesButtonStyleProperty = DependencyProperty.Register("YesButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(MessageBox)));
	}

	public MessageBox()
	{
		((UIElement)this).Visibility = (Visibility)2;
		InitHandlers();
	}

	public override void OnApplyTemplate()
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		DragDeltaEventHandler val = null;
		MouseButtonEventHandler val2 = null;
		RoutedEventHandler val3 = null;
		DragDeltaEventHandler val4 = null;
		MouseButtonEventHandler val5 = null;
		RoutedEventHandler val6 = null;
		base.OnApplyTemplate();
		if (_windowControl != null)
		{
			WindowControl windowControl = _windowControl;
			if (val == null)
			{
				val = (object o, DragDeltaEventArgs e) =>
				{
					OnHeaderDragDelta(e);
				};
			}
			windowControl.HeaderDragDelta -= val;
			WindowControl windowControl2 = _windowControl;
			if (val2 == null)
			{
				val2 = (object o, MouseButtonEventArgs e) =>
				{
					OnHeaderIconDoubleClicked(e);
				};
			}
			windowControl2.HeaderIconDoubleClicked -= val2;
			WindowControl windowControl3 = _windowControl;
			if (val3 == null)
			{
				val3 = (object o, RoutedEventArgs e) =>
				{
					OnCloseButtonClicked(e);
				};
			}
			windowControl3.CloseButtonClicked -= val3;
		}
		_windowControl = ((FrameworkElement)this).GetTemplateChild("PART_WindowControl") as WindowControl;
		if (_windowControl != null)
		{
			WindowControl windowControl4 = _windowControl;
			if (val4 == null)
			{
				val4 = (object o, DragDeltaEventArgs e) =>
				{
					OnHeaderDragDelta(e);
				};
			}
			windowControl4.HeaderDragDelta += val4;
			WindowControl windowControl5 = _windowControl;
			if (val5 == null)
			{
				val5 = (object o, MouseButtonEventArgs e) =>
				{
					OnHeaderIconDoubleClicked(e);
				};
			}
			windowControl5.HeaderIconDoubleClicked += val5;
			WindowControl windowControl6 = _windowControl;
			if (val6 == null)
			{
				val6 = (object o, RoutedEventArgs e) =>
				{
					OnCloseButtonClicked(e);
				};
			}
			windowControl6.CloseButtonClicked += val6;
		}
		UpdateBlockMouseInputsPanel();
		ChangeVisualState(((object)_button).ToString(), useTransitions: true);
		Button messageBoxButton = GetMessageBoxButton("PART_CloseButton");
		if (messageBoxButton != null)
		{
			((UIElement)messageBoxButton).IsEnabled = !object.Equals(_button, (object)(MessageBoxButton)4);
		}
		Button messageBoxButton2 = GetMessageBoxButton("PART_OkButton");
		if (messageBoxButton2 != null)
		{
			messageBoxButton2.IsCancel = object.Equals(_button, (object)(MessageBoxButton)0);
		}
		SetDefaultResult();
	}

	protected override object OnCoerceCloseButtonVisibility(Visibility newValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)newValue != 0)
		{
			throw new InvalidOperationException("Close button on MessageBox is always Visible.");
		}
		return newValue;
	}

	protected override object OnCoerceWindowStyle(WindowStyle newValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)newValue != 1)
		{
			throw new InvalidOperationException("Window style on MessageBox is not available.");
		}
		return newValue;
	}

	internal override void UpdateBlockMouseInputsPanel()
	{
		if (_windowControl != null)
		{
			_windowControl.IsBlockMouseInputsPanelActive = IsBlockMouseInputsPanelActive;
		}
	}

	public static MessageBoxResult Show(string messageText)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Show(messageText, string.Empty, (MessageBoxButton)0, (Style)null);
	}

	public static MessageBoxResult Show(Window owner, string messageText)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, string.Empty, (MessageBoxButton)0, (Style)null);
	}

	public static MessageBoxResult Show(string messageText, string caption)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return Show(messageText, caption, (MessageBoxButton)0, (Style)null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, caption, (Style)null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, Style messageBoxStyle)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, caption, (MessageBoxButton)0, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return Show(messageText, caption, button, (Style)null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(null, messageText, caption, button, (MessageBoxImage)0, (MessageBoxResult)0, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, caption, button, (Style)null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(owner, messageText, caption, button, (MessageBoxImage)0, (MessageBoxResult)0, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return Show(messageText, caption, button, icon, (Style)null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(null, messageText, caption, button, icon, (MessageBoxResult)0, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, caption, button, icon, (Style)null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(owner, messageText, caption, button, icon, (MessageBoxResult)0, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return Show(messageText, caption, button, icon, defaultResult, null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(null, messageText, caption, button, icon, defaultResult, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return Show(owner, messageText, caption, button, icon, defaultResult, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		return ShowCore(owner, messageText, caption, button, icon, defaultResult, messageBoxStyle);
	}

	public void ShowMessageBox()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (Container != null || ((FrameworkElement)this).Parent == null)
		{
			throw new InvalidOperationException("This method is not intended to be called while displaying a MessageBox outside of a WindowContainer. Use ShowDialog() instead in that case.");
		}
		if (!(((FrameworkElement)this).Parent is WindowContainer))
		{
			throw new InvalidOperationException("The MessageBox instance is not intended to be displayed in a container other than a WindowContainer.");
		}
		_dialogResult = (MessageBoxResult)0;
		((UIElement)this).Visibility = (Visibility)0;
	}

	public void ShowMessageBox(string messageText)
	{
		ShowMessageBoxCore(messageText, string.Empty, (MessageBoxButton)0, (MessageBoxImage)0, (MessageBoxResult)0);
	}

	public void ShowMessageBox(string messageText, string caption)
	{
		ShowMessageBoxCore(messageText, caption, (MessageBoxButton)0, (MessageBoxImage)0, (MessageBoxResult)0);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		ShowMessageBoxCore(messageText, caption, button, (MessageBoxImage)0, (MessageBoxResult)0);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		ShowMessageBoxCore(messageText, caption, button, icon, (MessageBoxResult)0);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		ShowMessageBoxCore(messageText, caption, button, icon, defaultResult);
	}

	public bool? ShowDialog()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)this).Parent != null)
		{
			throw new InvalidOperationException("This method is not intended to be called while displaying a Message Box inside a WindowContainer. Use 'ShowMessageBox()' instead.");
		}
		_dialogResult = (MessageBoxResult)0;
		((UIElement)this).Visibility = (Visibility)0;
		CreateContainer();
		return Container.ShowDialog();
	}

	protected void InitializeMessageBox(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Text = text;
		Caption = caption;
		_button = button;
		_defaultResult = defaultResult;
		_owner = owner;
		SetImageSource(image);
	}

	protected void ChangeVisualState(string name, bool useTransitions)
	{
		VisualStateManager.GoToState((FrameworkElement)(object)this, name, useTransitions);
	}

	private bool IsCurrentWindow(object windowtoTest)
	{
		return object.Equals(_windowControl, windowtoTest);
	}

	private void Close()
	{
		if (Container != null)
		{
			Container.Close();
		}
		else
		{
			OnClose();
		}
	}

	private void SetDefaultResult()
	{
		Button defaultButtonFromDefaultResult = GetDefaultButtonFromDefaultResult();
		if (defaultButtonFromDefaultResult != null)
		{
			defaultButtonFromDefaultResult.IsDefault = true;
			((UIElement)defaultButtonFromDefaultResult).Focus();
		}
	}

	private Button GetDefaultButtonFromDefaultResult()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		Button result = null;
		MessageBoxResult defaultResult = _defaultResult;
		switch ((int)defaultResult)
		{
		case 2:
			result = GetMessageBoxButton("PART_CancelButton");
			break;
		case 7:
			result = GetMessageBoxButton("PART_NoButton");
			break;
		case 1:
			result = GetMessageBoxButton("PART_OkButton");
			break;
		case 6:
			result = GetMessageBoxButton("PART_YesButton");
			break;
		case 0:
			result = GetDefaultButton();
			break;
		}
		return result;
	}

	private Button GetDefaultButton()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected I4, but got Unknown
		Button result = null;
		MessageBoxButton button = _button;
		switch ((int)button)
		{
		case 0:
		case 1:
			result = GetMessageBoxButton("PART_OkButton");
			break;
		case 3:
		case 4:
			result = GetMessageBoxButton("PART_YesButton");
			break;
		}
		return result;
	}

	private Button GetMessageBoxButton(string name)
	{
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild(name);
		return (Button)(object)((templateChild is Button) ? templateChild : null);
	}

	private void ShowMessageBoxCore(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		InitializeMessageBox(null, messageText, caption, button, icon, defaultResult);
		ShowMessageBox();
	}

	private void InitHandlers()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		((UIElement)this).AddHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(Button_Click));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Copy, (ExecutedRoutedEventHandler)ExecuteCopy));
	}

	private static MessageBoxResult ShowCore(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (BrowserInteropHelper.IsBrowserHosted)
		{
			throw new InvalidOperationException("Static methods for MessageBoxes are not available in XBAP. Use the instance ShowMessageBox methods instead.");
		}
		MessageBox messageBox = new MessageBox();
		messageBox.InitializeMessageBox(owner, messageText, caption, button, icon, defaultResult);
		if (messageBoxStyle != null)
		{
			((FrameworkElement)messageBox).Style = messageBoxStyle;
		}
		messageBox.ShowDialog();
		return messageBox.MessageBoxResult;
	}

	private static Window ComputeOwnerWindow()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		Window result = null;
		if (Application.Current != null)
		{
			foreach (Window window in Application.Current.Windows)
			{
				Window val = window;
				if (val.IsActive)
				{
					result = val;
					break;
				}
			}
		}
		return result;
	}

	private void SetImageSource(MessageBoxImage image)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		string empty = string.Empty;
		if ((int)image <= 16)
		{
			if ((int)image == 0 || (int)image != 16)
			{
				return;
			}
			empty = "Error48.png";
		}
		else if ((int)image != 32)
		{
			if ((int)image != 48)
			{
				if ((int)image != 64)
				{
					return;
				}
				empty = "Information48.png";
			}
			else
			{
				empty = "Warning48.png";
			}
		}
		else
		{
			empty = "Question48.png";
		}
		ImageSource = (ImageSource)new BitmapImage(new Uri($"/Xceed.Wpf.Toolkit;component/MessageBox/Icons/{empty}", UriKind.RelativeOrAbsolute));
	}

	private Window CreateContainer()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		Window val = new Window();
		val.AllowsTransparency = true;
		((Control)val).Background = (Brush)(object)Brushes.Transparent;
		((ContentControl)val).Content = this;
		val.Owner = _owner ?? ComputeOwnerWindow();
		if (val.Owner != null)
		{
			val.WindowStartupLocation = (WindowStartupLocation)2;
		}
		else
		{
			val.WindowStartupLocation = (WindowStartupLocation)1;
		}
		val.ShowInTaskbar = false;
		val.SizeToContent = (SizeToContent)3;
		val.ResizeMode = (ResizeMode)0;
		val.WindowStyle = (WindowStyle)0;
		val.Closed += OnContainerClosed;
		return val;
	}

	protected virtual void OnHeaderDragDelta(DragDeltaEventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		if (!IsCurrentWindow(((RoutedEventArgs)e).OriginalSource))
		{
			return;
		}
		((RoutedEventArgs)e).Handled = true;
		DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
		((RoutedEventArgs)e2).RoutedEvent = WindowControl.HeaderDragDeltaEvent;
		((RoutedEventArgs)e2).Source = this;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
		if (!((RoutedEventArgs)e2).Handled)
		{
			if (Container == null)
			{
				double num = 0.0;
				num = (((int)((FrameworkElement)this).FlowDirection != 1) ? (Left + e.HorizontalChange) : (Left - e.HorizontalChange));
				Left = num;
				Top += e.VerticalChange;
			}
			else
			{
				double num2 = 0.0;
				num2 = (((int)((FrameworkElement)this).FlowDirection != 1) ? (Container.Left + e.HorizontalChange) : (Container.Left - e.HorizontalChange));
				Container.Left = num2;
				Window container = Container;
				container.Top += e.VerticalChange;
			}
		}
	}

	protected virtual void OnHeaderIconDoubleClicked(MouseButtonEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		if (IsCurrentWindow(((RoutedEventArgs)e).OriginalSource))
		{
			((RoutedEventArgs)e).Handled = true;
			MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, (MouseButton)0);
			((RoutedEventArgs)e2).RoutedEvent = WindowControl.HeaderIconDoubleClickedEvent;
			((RoutedEventArgs)e2).Source = this;
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
			if (!((RoutedEventArgs)e2).Handled)
			{
				Close();
			}
		}
	}

	protected virtual void OnCloseButtonClicked(RoutedEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			_dialogResult = (MessageBoxResult)(object.Equals(_button, (object)(MessageBoxButton)0) ? 1 : 2);
			RoutedEventArgs e2 = new RoutedEventArgs(WindowControl.CloseButtonClickedEvent, (object)this);
			((UIElement)this).RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		Button val = (Button)((originalSource is Button) ? originalSource : null);
		if (val != null)
		{
			switch (((FrameworkElement)val).Name)
			{
			case "PART_NoButton":
				_dialogResult = (MessageBoxResult)7;
				Close();
				break;
			case "PART_YesButton":
				_dialogResult = (MessageBoxResult)6;
				Close();
				break;
			case "PART_CancelButton":
				_dialogResult = (MessageBoxResult)2;
				Close();
				break;
			case "PART_OkButton":
				_dialogResult = (MessageBoxResult)1;
				Close();
				break;
			}
			e.Handled = true;
		}
	}

	private void OnContainerClosed(object sender, EventArgs e)
	{
		Container.Closed -= OnContainerClosed;
		((ContentControl)Container).Content = null;
		OnClose();
	}

	private void OnClose()
	{
		((UIElement)this).Visibility = (Visibility)2;
		OnClosed(EventArgs.Empty);
	}

	protected virtual void OnClosed(EventArgs e)
	{
		if (Closed != null)
		{
			Closed(this, e);
		}
	}

	private void ExecuteCopy(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected I4, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		stringBuilder.Append(Caption);
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		stringBuilder.Append(Text);
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		MessageBoxButton button = _button;
		switch ((int)button)
		{
		case 0:
			stringBuilder.Append(OkButtonContent.ToString());
			break;
		case 1:
			stringBuilder.Append(string.Concat(OkButtonContent, "     ", CancelButtonContent));
			break;
		case 4:
			stringBuilder.Append(string.Concat(YesButtonContent, "     ", NoButtonContent));
			break;
		case 3:
			stringBuilder.Append(string.Concat(new object[5] { YesButtonContent, "     ", NoButtonContent, "     ", CancelButtonContent }));
			break;
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		try
		{
			((CodeAccessPermission)new UIPermission((UIPermissionClipboard)2)).Demand();
			Clipboard.SetText(stringBuilder.ToString());
		}
		catch (SecurityException)
		{
			throw new SecurityException();
		}
	}
}
