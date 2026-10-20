using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using Xceed.Wpf.Toolkit.Core;

namespace Xceed.Wpf.Toolkit;

public class Wizard : ItemsControl
{
	public delegate void NextRoutedEventHandler(object sender, CancelRoutedEventArgs e);

	public delegate void PreviousRoutedEventHandler(object sender, CancelRoutedEventArgs e);

	public static readonly DependencyProperty BackButtonContentProperty;

	public static readonly DependencyProperty BackButtonVisibilityProperty;

	public static readonly DependencyProperty CanCancelProperty;

	public static readonly DependencyProperty CancelButtonClosesWindowProperty;

	public static readonly DependencyProperty CancelButtonContentProperty;

	public static readonly DependencyProperty CancelButtonVisibilityProperty;

	public static readonly DependencyProperty CanFinishProperty;

	public static readonly DependencyProperty CanHelpProperty;

	public static readonly DependencyProperty CanSelectNextPageProperty;

	public static readonly DependencyProperty CanSelectPreviousPageProperty;

	public static readonly DependencyProperty CurrentPageProperty;

	public static readonly DependencyProperty ExteriorPanelMinWidthProperty;

	public static readonly DependencyProperty FinishButtonClosesWindowProperty;

	public static readonly DependencyProperty FinishButtonContentProperty;

	public static readonly DependencyProperty FinishButtonVisibilityProperty;

	public static readonly DependencyProperty HelpButtonContentProperty;

	public static readonly DependencyProperty HelpButtonVisibilityProperty;

	public static readonly DependencyProperty NextButtonContentProperty;

	public static readonly DependencyProperty NextButtonVisibilityProperty;

	public static readonly RoutedEvent CancelEvent;

	public static readonly RoutedEvent PageChangedEvent;

	public static readonly RoutedEvent FinishEvent;

	public static readonly RoutedEvent HelpEvent;

	public static readonly RoutedEvent NextEvent;

	public static readonly RoutedEvent PreviousEvent;

	public object BackButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(BackButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackButtonContentProperty, value);
		}
	}

	public Visibility BackButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(BackButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(BackButtonVisibilityProperty, (object)value);
		}
	}

	public bool CanCancel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanCancelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCancelProperty, (object)value);
		}
	}

	public bool CancelButtonClosesWindow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CancelButtonClosesWindowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonClosesWindowProperty, (object)value);
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

	public Visibility CancelButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(CancelButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(CancelButtonVisibilityProperty, (object)value);
		}
	}

	public bool CanFinish
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanFinishProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFinishProperty, (object)value);
		}
	}

	public bool CanHelp
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanHelpProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanHelpProperty, (object)value);
		}
	}

	public bool CanSelectNextPage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSelectNextPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectNextPageProperty, (object)value);
		}
	}

	public bool CanSelectPreviousPage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSelectPreviousPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSelectPreviousPageProperty, (object)value);
		}
	}

	public WizardPage CurrentPage
	{
		get
		{
			return (WizardPage)((DependencyObject)this).GetValue(CurrentPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentPageProperty, (object)value);
		}
	}

	public double ExteriorPanelMinWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ExteriorPanelMinWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExteriorPanelMinWidthProperty, (object)value);
		}
	}

	public bool FinishButtonClosesWindow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FinishButtonClosesWindowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonClosesWindowProperty, (object)value);
		}
	}

	public object FinishButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(FinishButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FinishButtonContentProperty, value);
		}
	}

	public Visibility FinishButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(FinishButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(FinishButtonVisibilityProperty, (object)value);
		}
	}

	public object HelpButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(HelpButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpButtonContentProperty, value);
		}
	}

	public Visibility HelpButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(HelpButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(HelpButtonVisibilityProperty, (object)value);
		}
	}

	public object NextButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(NextButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextButtonContentProperty, value);
		}
	}

	public Visibility NextButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(NextButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(NextButtonVisibilityProperty, (object)value);
		}
	}

	public event RoutedEventHandler Cancel
	{
		add
		{
			((UIElement)this).AddHandler(CancelEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(CancelEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler PageChanged
	{
		add
		{
			((UIElement)this).AddHandler(PageChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(PageChangedEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler Finish
	{
		add
		{
			((UIElement)this).AddHandler(FinishEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(FinishEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler Help
	{
		add
		{
			((UIElement)this).AddHandler(HelpEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HelpEvent, (Delegate)(object)value);
		}
	}

	public event NextRoutedEventHandler Next
	{
		add
		{
			((UIElement)this).AddHandler(NextEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(NextEvent, (Delegate)value);
		}
	}

	public event PreviousRoutedEventHandler Previous
	{
		add
		{
			((UIElement)this).AddHandler(PreviousEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(PreviousEvent, (Delegate)value);
		}
	}

	private static void OnCurrentPageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Wizard wizard)
		{
			wizard.OnCurrentPageChanged((WizardPage)e.OldValue, (WizardPage)e.NewValue);
		}
	}

	protected virtual void OnCurrentPageChanged(WizardPage oldValue, WizardPage newValue)
	{
		RaiseRoutedEvent(PageChangedEvent);
	}

	static Wizard()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected Obj, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected Obj, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected Obj, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected Obj, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected Obj, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected Obj, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected Obj, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected Obj, but got Unknown
		BackButtonContentProperty = DependencyProperty.Register("BackButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)"< Back"));
		BackButtonVisibilityProperty = DependencyProperty.Register("BackButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)(Visibility)0));
		CanCancelProperty = DependencyProperty.Register("CanCancel", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		CancelButtonClosesWindowProperty = DependencyProperty.Register("CancelButtonClosesWindow", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		CancelButtonContentProperty = DependencyProperty.Register("CancelButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)"Cancel"));
		CancelButtonVisibilityProperty = DependencyProperty.Register("CancelButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)(Visibility)0));
		CanFinishProperty = DependencyProperty.Register("CanFinish", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)false));
		CanHelpProperty = DependencyProperty.Register("CanHelp", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		CanSelectNextPageProperty = DependencyProperty.Register("CanSelectNextPage", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		CanSelectPreviousPageProperty = DependencyProperty.Register("CanSelectPreviousPage", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(WizardPage), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnCurrentPageChanged));
		ExteriorPanelMinWidthProperty = DependencyProperty.Register("ExteriorPanelMinWidth", typeof(double), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)165.0));
		FinishButtonClosesWindowProperty = DependencyProperty.Register("FinishButtonClosesWindow", typeof(bool), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)true));
		FinishButtonContentProperty = DependencyProperty.Register("FinishButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)"Finish"));
		FinishButtonVisibilityProperty = DependencyProperty.Register("FinishButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)(Visibility)0));
		HelpButtonContentProperty = DependencyProperty.Register("HelpButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)"Help"));
		HelpButtonVisibilityProperty = DependencyProperty.Register("HelpButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)(Visibility)0));
		NextButtonContentProperty = DependencyProperty.Register("NextButtonContent", typeof(object), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)"Next >"));
		NextButtonVisibilityProperty = DependencyProperty.Register("NextButtonVisibility", typeof(Visibility), typeof(Wizard), (PropertyMetadata)new UIPropertyMetadata((object)(Visibility)0));
		CancelEvent = EventManager.RegisterRoutedEvent("Cancel", (RoutingStrategy)1, typeof(EventHandler), typeof(Wizard));
		PageChangedEvent = EventManager.RegisterRoutedEvent("PageChanged", (RoutingStrategy)1, typeof(EventHandler), typeof(Wizard));
		FinishEvent = EventManager.RegisterRoutedEvent("Finish", (RoutingStrategy)1, typeof(EventHandler), typeof(Wizard));
		HelpEvent = EventManager.RegisterRoutedEvent("Help", (RoutingStrategy)1, typeof(EventHandler), typeof(Wizard));
		NextEvent = EventManager.RegisterRoutedEvent("Next", (RoutingStrategy)1, typeof(NextRoutedEventHandler), typeof(Wizard));
		PreviousEvent = EventManager.RegisterRoutedEvent("Previous", (RoutingStrategy)1, typeof(PreviousRoutedEventHandler), typeof(Wizard));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Wizard), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(Wizard)));
	}

	public Wizard()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_002e: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_005c: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_008a: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		//IL_00b8: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
		//IL_00e6: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)WizardCommands.Cancel, (ExecutedRoutedEventHandler)ExecuteCancelWizard, (CanExecuteRoutedEventHandler)CanExecuteCancelWizard));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)WizardCommands.Finish, (ExecutedRoutedEventHandler)ExecuteFinishWizard, (CanExecuteRoutedEventHandler)CanExecuteFinishWizard));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)WizardCommands.Help, (ExecutedRoutedEventHandler)ExecuteRequestHelp, (CanExecuteRoutedEventHandler)CanExecuteRequestHelp));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)WizardCommands.NextPage, (ExecutedRoutedEventHandler)ExecuteSelectNextPage, (CanExecuteRoutedEventHandler)CanExecuteSelectNextPage));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)WizardCommands.PreviousPage, (ExecutedRoutedEventHandler)ExecuteSelectPreviousPage, (CanExecuteRoutedEventHandler)CanExecuteSelectPreviousPage));
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new WizardPage();
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is WizardPage;
	}

	protected override void OnInitialized(EventArgs e)
	{
		((FrameworkElement)this).OnInitialized(e);
		if (((CollectionView)((ItemsControl)this).Items).Count > 0 && CurrentPage == null)
		{
			CurrentPage = ((ItemsControl)this).Items[0] as WizardPage;
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

	private void ExecuteCancelWizard(object sender, ExecutedRoutedEventArgs e)
	{
		RaiseRoutedEvent(CancelEvent);
		if (CancelButtonClosesWindow)
		{
			CloseParentWindow(dialogResult: false);
		}
	}

	private void CanExecuteCancelWizard(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanCancel.HasValue)
			{
				e.CanExecute = CurrentPage.CanCancel.Value;
			}
			else
			{
				e.CanExecute = CanCancel;
			}
		}
	}

	private void ExecuteFinishWizard(object sender, ExecutedRoutedEventArgs e)
	{
		RaiseRoutedEvent(FinishEvent);
		if (FinishButtonClosesWindow)
		{
			CloseParentWindow(dialogResult: true);
		}
	}

	private void CanExecuteFinishWizard(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanFinish.HasValue)
			{
				e.CanExecute = CurrentPage.CanFinish.Value;
			}
			else
			{
				e.CanExecute = CanFinish;
			}
		}
	}

	private void ExecuteRequestHelp(object sender, ExecutedRoutedEventArgs e)
	{
		RaiseRoutedEvent(HelpEvent);
	}

	private void CanExecuteRequestHelp(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage != null)
		{
			if (CurrentPage.CanHelp.HasValue)
			{
				e.CanExecute = CurrentPage.CanHelp.Value;
			}
			else
			{
				e.CanExecute = CanHelp;
			}
		}
	}

	private void ExecuteSelectNextPage(object sender, ExecutedRoutedEventArgs e)
	{
		WizardPage currentPage = null;
		if (CurrentPage != null)
		{
			CancelRoutedEventArgs e2 = new CancelRoutedEventArgs(NextEvent);
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
			if (e2.Cancel)
			{
				return;
			}
			if (CurrentPage.NextPage != null)
			{
				currentPage = CurrentPage.NextPage;
			}
			else
			{
				int num = ((CollectionView)((ItemsControl)this).Items).IndexOf((object)CurrentPage);
				int num2 = num + 1;
				if (num2 < ((CollectionView)((ItemsControl)this).Items).Count)
				{
					currentPage = ((ItemsControl)this).Items[num2] as WizardPage;
				}
			}
		}
		CurrentPage = currentPage;
	}

	private void CanExecuteSelectNextPage(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage == null)
		{
			return;
		}
		if (CurrentPage.CanSelectNextPage.HasValue)
		{
			if (CurrentPage.CanSelectNextPage.Value)
			{
				e.CanExecute = NextPageExists();
			}
		}
		else if (CanSelectNextPage)
		{
			e.CanExecute = NextPageExists();
		}
	}

	private void ExecuteSelectPreviousPage(object sender, ExecutedRoutedEventArgs e)
	{
		WizardPage currentPage = null;
		if (CurrentPage != null)
		{
			CancelRoutedEventArgs e2 = new CancelRoutedEventArgs(PreviousEvent);
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
			if (e2.Cancel)
			{
				return;
			}
			if (CurrentPage.PreviousPage != null)
			{
				currentPage = CurrentPage.PreviousPage;
			}
			else
			{
				int num = ((CollectionView)((ItemsControl)this).Items).IndexOf((object)CurrentPage);
				int num2 = num - 1;
				if (num2 >= 0 && num2 < ((CollectionView)((ItemsControl)this).Items).Count)
				{
					currentPage = ((ItemsControl)this).Items[num2] as WizardPage;
				}
			}
		}
		CurrentPage = currentPage;
	}

	private void CanExecuteSelectPreviousPage(object sender, CanExecuteRoutedEventArgs e)
	{
		if (CurrentPage == null)
		{
			return;
		}
		if (CurrentPage.CanSelectPreviousPage.HasValue)
		{
			if (CurrentPage.CanSelectPreviousPage.Value)
			{
				e.CanExecute = PreviousPageExists();
			}
		}
		else if (CanSelectPreviousPage)
		{
			e.CanExecute = PreviousPageExists();
		}
	}

	private void CloseParentWindow(bool dialogResult)
	{
		Window window = Window.GetWindow((DependencyObject)(object)this);
		if (window != null)
		{
			if (ComponentDispatcher.IsThreadModal)
			{
				window.DialogResult = dialogResult;
			}
			window.Close();
		}
	}

	private bool NextPageExists()
	{
		bool result = false;
		if (CurrentPage.NextPage != null)
		{
			result = true;
		}
		else
		{
			int num = ((CollectionView)((ItemsControl)this).Items).IndexOf((object)CurrentPage);
			int num2 = num + 1;
			if (num2 < ((CollectionView)((ItemsControl)this).Items).Count)
			{
				result = true;
			}
		}
		return result;
	}

	private bool PreviousPageExists()
	{
		bool result = false;
		if (CurrentPage.PreviousPage != null)
		{
			result = true;
		}
		else
		{
			int num = ((CollectionView)((ItemsControl)this).Items).IndexOf((object)CurrentPage);
			int num2 = num - 1;
			if (num2 >= 0 && num2 < ((CollectionView)((ItemsControl)this).Items).Count)
			{
				result = true;
			}
		}
		return result;
	}

	private void RaiseRoutedEvent(RoutedEvent routedEvent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		RoutedEventArgs e = new RoutedEventArgs(routedEvent, (object)this);
		((UIElement)this).RaiseEvent(e);
	}
}
