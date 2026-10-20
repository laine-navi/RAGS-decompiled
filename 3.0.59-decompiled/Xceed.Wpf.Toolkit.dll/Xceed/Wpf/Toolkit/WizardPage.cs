using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class WizardPage : ContentControl
{
	public static readonly DependencyProperty BackButtonVisibilityProperty;

	public static readonly DependencyProperty CanCancelProperty;

	public static readonly DependencyProperty CancelButtonVisibilityProperty;

	public static readonly DependencyProperty CanFinishProperty;

	public static readonly DependencyProperty CanHelpProperty;

	public static readonly DependencyProperty CanSelectNextPageProperty;

	public static readonly DependencyProperty CanSelectPreviousPageProperty;

	public static readonly DependencyProperty DescriptionProperty;

	public static readonly DependencyProperty ExteriorPanelBackgroundProperty;

	public static readonly DependencyProperty ExteriorPanelContentProperty;

	public static readonly DependencyProperty FinishButtonVisibilityProperty;

	public static readonly DependencyProperty HeaderBackgroundProperty;

	public static readonly DependencyProperty HeaderImageProperty;

	public static readonly DependencyProperty HelpButtonVisibilityProperty;

	public static readonly DependencyProperty NextButtonVisibilityProperty;

	public static readonly DependencyProperty NextPageProperty;

	public static readonly DependencyProperty PageTypeProperty;

	public static readonly DependencyProperty PreviousPageProperty;

	public static readonly DependencyProperty TitleProperty;

	public static readonly RoutedEvent EnterEvent;

	public static readonly RoutedEvent LeaveEvent;

	public WizardPageButtonVisibility BackButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(BackButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackButtonVisibilityProperty, (object)value);
		}
	}

	public bool? CanCancel
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanCancelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCancelProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility CancelButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(CancelButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonVisibilityProperty, (object)value);
		}
	}

	public bool? CanFinish
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanFinishProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFinishProperty, (object)value);
		}
	}

	public bool? CanHelp
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanHelpProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanHelpProperty, (object)value);
		}
	}

	public bool? CanSelectNextPage
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanSelectNextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectNextPageProperty, (object)value);
		}
	}

	public bool? CanSelectPreviousPage
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(CanSelectPreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectPreviousPageProperty, (object)value);
		}
	}

	public string Description
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionProperty, (object)value);
		}
	}

	public Brush ExteriorPanelBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(ExteriorPanelBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelBackgroundProperty, (object)value);
		}
	}

	public object ExteriorPanelContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(ExteriorPanelContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelContentProperty, value);
		}
	}

	public WizardPageButtonVisibility FinishButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(FinishButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonVisibilityProperty, (object)value);
		}
	}

	public Brush HeaderBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(HeaderBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderBackgroundProperty, (object)value);
		}
	}

	public ImageSource HeaderImage
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ImageSource)((DependencyObject)this).GetValue(HeaderImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderImageProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility HelpButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(HelpButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpButtonVisibilityProperty, (object)value);
		}
	}

	public WizardPageButtonVisibility NextButtonVisibility
	{
		get
		{
			return (WizardPageButtonVisibility)((DependencyObject)this).GetValue(NextButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextButtonVisibilityProperty, (object)value);
		}
	}

	public WizardPage NextPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(NextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextPageProperty, (object)value);
		}
	}

	public WizardPageType PageType
	{
		get
		{
			return (WizardPageType)((DependencyObject)this).GetValue(PageTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PageTypeProperty, (object)value);
		}
	}

	public WizardPage PreviousPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(PreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviousPageProperty, (object)value);
		}
	}

	public string Title
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleProperty, (object)value);
		}
	}

	public event RoutedEventHandler Enter
	{
		add
		{
			((UIElement)this).AddHandler(EnterEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(EnterEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler Leave
	{
		add
		{
			((UIElement)this).AddHandler(LeaveEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(LeaveEvent, (Delegate)(object)value);
		}
	}

	static WizardPage()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected Obj, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected Obj, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected Obj, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected Obj, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected Obj, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected Obj, but got Unknown
		BackButtonVisibilityProperty = DependencyProperty.Register("BackButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		CanCancelProperty = DependencyProperty.Register("CanCancel", typeof(bool?), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CancelButtonVisibilityProperty = DependencyProperty.Register("CancelButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		CanFinishProperty = DependencyProperty.Register("CanFinish", typeof(bool?), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CanHelpProperty = DependencyProperty.Register("CanHelp", typeof(bool?), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CanSelectNextPageProperty = DependencyProperty.Register("CanSelectNextPage", typeof(bool?), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CanSelectPreviousPageProperty = DependencyProperty.Register("CanSelectPreviousPage", typeof(bool?), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(WizardPage));
		ExteriorPanelBackgroundProperty = DependencyProperty.Register("ExteriorPanelBackground", typeof(Brush), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		ExteriorPanelContentProperty = DependencyProperty.Register("ExteriorPanelContent", typeof(object), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		FinishButtonVisibilityProperty = DependencyProperty.Register("FinishButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)Brushes.White));
		HeaderImageProperty = DependencyProperty.Register("HeaderImage", typeof(ImageSource), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		HelpButtonVisibilityProperty = DependencyProperty.Register("HelpButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		NextButtonVisibilityProperty = DependencyProperty.Register("NextButtonVisibility", typeof(WizardPageButtonVisibility), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageButtonVisibility.Inherit));
		NextPageProperty = DependencyProperty.Register("NextPage", typeof(WizardPage), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		PageTypeProperty = DependencyProperty.Register("PageType", typeof(WizardPageType), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((object)WizardPageType.Exterior));
		PreviousPageProperty = DependencyProperty.Register("PreviousPage", typeof(WizardPage), typeof(WizardPage), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(WizardPage));
		EnterEvent = EventManager.RegisterRoutedEvent("Enter", (RoutingStrategy)1, typeof(EventHandler), typeof(WizardPage));
		LeaveEvent = EventManager.RegisterRoutedEvent("Leave", (RoutingStrategy)1, typeof(EventHandler), typeof(WizardPage));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardPage), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(WizardPage)));
	}

	public WizardPage()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		((FrameworkElement)this).Loaded += WizardPage_Loaded;
		((FrameworkElement)this).Unloaded += WizardPage_Unloaded;
	}

	private void WizardPage_Unloaded(object sender, RoutedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		((UIElement)this).RaiseEvent(new RoutedEventArgs(LeaveEvent, (object)this));
	}

	private void WizardPage_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (((UIElement)this).IsVisible)
		{
			((UIElement)this).RaiseEvent(new RoutedEventArgs(EnterEvent, (object)this));
		}
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)this).OnPropertyChanged(e);
		if (e.Property.Name == "CanSelectNextPage" || e.Property.Name == "CanHelp" || e.Property.Name == "CanFinish" || e.Property.Name == "CanCancel" || e.Property.Name == "CanSelectPreviousPage")
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}
}
