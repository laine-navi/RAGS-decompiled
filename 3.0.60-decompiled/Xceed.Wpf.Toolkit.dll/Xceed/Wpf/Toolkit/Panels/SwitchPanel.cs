using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

public class SwitchPanel : PanelBase, IScrollInfo
{
	private enum CacheBits
	{
		HasLoaded = 1
	}

	private static readonly Vector ZeroVector = default;

	public static readonly DependencyProperty AreLayoutSwitchesAnimatedProperty = DependencyProperty.Register("AreLayoutSwitchesAnimated", typeof(bool), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)true));

	private static readonly DependencyPropertyKey ActiveLayoutPropertyKey = DependencyProperty.RegisterReadOnly("ActiveLayout", typeof(AnimationPanel), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)1, (PropertyChangedCallback)OnActiveLayoutChanged));

	public static readonly DependencyProperty ActiveLayoutProperty = ActiveLayoutPropertyKey.DependencyProperty;

	public static readonly DependencyProperty ActiveLayoutIndexProperty = DependencyProperty.Register("ActiveLayoutIndex", typeof(int), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)(-1), (PropertyChangedCallback)OnActiveLayoutIndexChanged, (CoerceValueCallback)CoerceActiveLayoutIndexValue));

	private static readonly DependencyPropertyKey ActiveSwitchTemplatePropertyKey = DependencyProperty.RegisterReadOnly("ActiveSwitchTemplate", typeof(DataTemplate), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnActiveSwitchTemplateChanged));

	public static readonly DependencyProperty ActiveSwitchTemplateProperty = ActiveSwitchTemplatePropertyKey.DependencyProperty;

	public static readonly DependencyProperty DefaultAnimationRateProperty = AnimationPanel.DefaultAnimationRateProperty.AddOwner(typeof(SwitchPanel));

	public static readonly DependencyProperty DefaultAnimatorProperty = AnimationPanel.DefaultAnimatorProperty.AddOwner(typeof(SwitchPanel));

	public static readonly DependencyProperty EnterAnimationRateProperty = AnimationPanel.EnterAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty EnterAnimatorProperty = AnimationPanel.EnterAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty ExitAnimationRateProperty = AnimationPanel.ExitAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty ExitAnimatorProperty = AnimationPanel.ExitAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty LayoutAnimationRateProperty = AnimationPanel.LayoutAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty LayoutAnimatorProperty = AnimationPanel.LayoutAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private static readonly DependencyPropertyKey LayoutsPropertyKey = DependencyProperty.RegisterReadOnly("Layouts", typeof(ObservableCollection<AnimationPanel>), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)2, (PropertyChangedCallback)OnLayoutsChanged));

	public static readonly DependencyProperty LayoutsProperty = LayoutsPropertyKey.DependencyProperty;

	public static readonly DependencyProperty SwitchAnimationRateProperty = AnimationPanel.SwitchAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty SwitchAnimatorProperty = AnimationPanel.SwitchAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty SwitchTemplateProperty = DependencyProperty.Register("SwitchTemplate", typeof(DataTemplate), typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnSwitchTemplateChanged));

	public static readonly DependencyProperty TemplateAnimationRateProperty = AnimationPanel.TemplateAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty TemplateAnimatorProperty = AnimationPanel.TemplateAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private readonly List<UIElement> _exitingChildren = new List<UIElement>();

	public static readonly RoutedEvent ActiveLayoutChangedEvent = EventManager.RegisterRoutedEvent("ActiveLayoutChanged", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(SwitchPanel));

	public static readonly RoutedEvent SwitchAnimationBegunEvent = EventManager.RegisterRoutedEvent("SwitchAnimationBegun", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(SwitchPanel));

	public static readonly RoutedEvent SwitchAnimationCompletedEvent = EventManager.RegisterRoutedEvent("SwitchAnimationCompleted", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(SwitchPanel));

	internal AnimationPanel _currentLayoutPanel;

	private readonly AnimationPanel _defaultLayoutCanvas = new WrapPanel();

	private readonly Collection<SwitchPresenter> _presenters = new Collection<SwitchPresenter>();

	private BitVector32 _cacheBits = new BitVector32(0);

	private bool _allowHorizontal;

	private bool _allowVertical;

	private Vector _computedOffset = new Vector(0.0, 0.0);

	private Size _extent = new Size(0.0, 0.0);

	private Vector _offset = new Vector(0.0, 0.0);

	private ScrollViewer _scrollOwner;

	private Size _viewport;

	public bool AreLayoutSwitchesAnimated
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AreLayoutSwitchesAnimatedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AreLayoutSwitchesAnimatedProperty, (object)value);
		}
	}

	public AnimationPanel ActiveLayout => (AnimationPanel)((DependencyObject)this).GetValue(ActiveLayoutProperty);

	public int ActiveLayoutIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ActiveLayoutIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveLayoutIndexProperty, (object)value);
		}
	}

	public DataTemplate ActiveSwitchTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(ActiveSwitchTemplateProperty);
		}
	}

	public AnimationRate DefaultAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(DefaultAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator DefaultAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(DefaultAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultAnimatorProperty, (object)value);
		}
	}

	public AnimationRate EnterAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(EnterAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator EnterAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(EnterAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterAnimatorProperty, (object)value);
		}
	}

	public AnimationRate ExitAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(ExitAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExitAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator ExitAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(ExitAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExitAnimatorProperty, (object)value);
		}
	}

	public AnimationRate LayoutAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(LayoutAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator LayoutAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(LayoutAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutAnimatorProperty, (object)value);
		}
	}

	public ObservableCollection<AnimationPanel> Layouts => (ObservableCollection<AnimationPanel>)((DependencyObject)this).GetValue(LayoutsProperty);

	public AnimationRate SwitchAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(SwitchAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator SwitchAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(SwitchAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchAnimatorProperty, (object)value);
		}
	}

	public DataTemplate SwitchTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(SwitchTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchTemplateProperty, (object)value);
		}
	}

	public AnimationRate TemplateAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(TemplateAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator TemplateAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(TemplateAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateAnimatorProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount
	{
		get
		{
			int num = 0;
			if (HasLoaded && _currentLayoutPanel != null)
			{
				return _currentLayoutPanel.VisualChildrenCountInternal;
			}
			return ((Panel)this).VisualChildrenCount;
		}
	}

	internal List<UIElement> ExitingChildren => _exitingChildren;

	internal UIElementCollection ChildrenInternal => ((Panel)this).InternalChildren;

	internal bool HasLoaded
	{
		get
		{
			return _cacheBits[1];
		}
		set
		{
			_cacheBits[1] = value;
		}
	}

	private bool IsScrollingPhysically
	{
		get
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			bool result = false;
			if (_scrollOwner != null)
			{
				result = true;
				if (ActiveLayout != null && ActiveLayout is IScrollInfo)
				{
					result = ((IScrollInfo)ActiveLayout).ScrollOwner == null;
				}
			}
			return result;
		}
	}

	public bool CanHorizontallyScroll
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).CanHorizontallyScroll;
			}
			return _allowHorizontal;
		}
		set
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				((IScrollInfo)ActiveLayout).CanHorizontallyScroll = value;
			}
			else
			{
				_allowHorizontal = value;
			}
		}
	}

	public bool CanVerticallyScroll
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).CanVerticallyScroll;
			}
			return _allowVertical;
		}
		set
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				((IScrollInfo)ActiveLayout).CanVerticallyScroll = value;
			}
			else
			{
				_allowVertical = value;
			}
		}
	}

	public double ExtentHeight
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ExtentHeight;
			}
			return _extent.Height;
		}
	}

	public double ExtentWidth
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ExtentWidth;
			}
			return _extent.Width;
		}
	}

	public double HorizontalOffset
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).HorizontalOffset;
			}
			return _offset.X;
		}
	}

	public ScrollViewer ScrollOwner
	{
		get
		{
			return _scrollOwner;
		}
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			foreach (AnimationPanel layout in Layouts)
			{
				if (layout != null && layout is IScrollInfo)
				{
					((IScrollInfo)layout).ScrollOwner = value;
				}
			}
			if (_scrollOwner != value)
			{
				_scrollOwner = value;
				ResetScrollInfo();
			}
		}
	}

	public double VerticalOffset
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).VerticalOffset;
			}
			return _offset.Y;
		}
	}

	public double ViewportHeight
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ViewportHeight;
			}
			return _viewport.Height;
		}
	}

	public double ViewportWidth
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ViewportWidth;
			}
			return _viewport.Width;
		}
	}

	public event RoutedEventHandler ActiveLayoutChanged
	{
		add
		{
			((UIElement)this).AddHandler(ActiveLayoutChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ActiveLayoutChangedEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler SwitchAnimationBegun
	{
		add
		{
			((UIElement)this).AddHandler(SwitchAnimationBegunEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(SwitchAnimationBegunEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler SwitchAnimationCompleted
	{
		add
		{
			((UIElement)this).AddHandler(SwitchAnimationCompletedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(SwitchAnimationCompletedEvent, (Delegate)(object)value);
		}
	}

	public SwitchPanel()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		SetLayouts(new ObservableCollection<AnimationPanel>());
		((FrameworkElement)this).Loaded += OnLoaded;
	}

	protected void SetActiveLayout(AnimationPanel value)
	{
		((DependencyObject)this).SetValue(ActiveLayoutPropertyKey, (object)value);
	}

	private static void OnActiveLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveLayoutChanged(e);
	}

	protected virtual void OnActiveLayoutChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_currentLayoutPanel != null)
		{
			_currentLayoutPanel.DeactivateLayout();
		}
		_currentLayoutPanel = e.NewValue as AnimationPanel;
		if (_currentLayoutPanel != null)
		{
			AnimationPanel currentLayoutPanel = _currentLayoutPanel;
			IScrollInfo val = (IScrollInfo)(object)((currentLayoutPanel is IScrollInfo) ? currentLayoutPanel : null);
			if (val != null && val.ScrollOwner != null)
			{
				val.ScrollOwner.InvalidateScrollInfo();
			}
			_currentLayoutPanel.ActivateLayout();
		}
		RaiseActiveLayoutChangedEvent();
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)9, (Delegate)(ThreadStart)(() =>
		{
			UpdateSwitchTemplate();
		}));
	}

	private static void OnActiveLayoutIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveLayoutIndexChanged(e);
	}

	protected virtual void OnActiveLayoutIndexChanged(DependencyPropertyChangedEventArgs e)
	{
		SetActiveLayout((Layouts.Count == 0) ? null : Layouts[ActiveLayoutIndex]);
	}

	private static object CoerceActiveLayoutIndexValue(DependencyObject d, object value)
	{
		int count = (d as SwitchPanel).Layouts.Count;
		int num = (int)value;
		if (num < 0 && count > 0)
		{
			num = 0;
		}
		else if (num >= count)
		{
			num = count - 1;
		}
		return num;
	}

	protected void SetActiveSwitchTemplate(DataTemplate value)
	{
		((DependencyObject)this).SetValue(ActiveSwitchTemplatePropertyKey, (object)value);
	}

	private static void OnActiveSwitchTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveSwitchTemplateChanged(e);
	}

	protected virtual void OnActiveSwitchTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		if (_presenters.Count <= 0)
		{
			return;
		}
		object newValue = e.NewValue;
		DataTemplate template = (DataTemplate)((newValue is DataTemplate) ? newValue : null);
		List<UIElement> list = new List<UIElement>(((Panel)this).InternalChildren.Count);
		foreach (UIElement internalChild in ((Panel)this).InternalChildren)
		{
			UIElement val = internalChild;
			if (val != null)
			{
				list.Add(val);
			}
		}
		foreach (SwitchPresenter presenter in _presenters)
		{
			if (presenter._switchRoot != null && list.Contains(presenter._switchRoot))
			{
				presenter.SwapTheTemplate(template, AreLayoutSwitchesAnimated);
			}
		}
	}

	protected void SetLayouts(ObservableCollection<AnimationPanel> value)
	{
		((DependencyObject)this).SetValue(LayoutsPropertyKey, (object)value);
	}

	private static void OnLayoutsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnLayoutsChanged(e);
	}

	protected virtual void OnLayoutsChanged(DependencyPropertyChangedEventArgs e)
	{
		if (e.NewValue != null)
		{
			(e.NewValue as ObservableCollection<AnimationPanel>).CollectionChanged += LayoutsCollectionChanged;
		}
		if (e.OldValue != null)
		{
			(e.OldValue as ObservableCollection<AnimationPanel>).CollectionChanged -= LayoutsCollectionChanged;
		}
	}

	private static void OnSwitchTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnSwitchTemplateChanged(e);
	}

	protected virtual void OnSwitchTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateSwitchTemplate();
	}

	protected RoutedEventArgs RaiseActiveLayoutChangedEvent()
	{
		return RaiseActiveLayoutChangedEvent((UIElement)(object)this);
	}

	internal static RoutedEventArgs RaiseActiveLayoutChangedEvent(UIElement target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = ActiveLayoutChangedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchAnimationBegunEvent()
	{
		return RaiseSwitchAnimationBegunEvent((UIElement)(object)this);
	}

	private static RoutedEventArgs RaiseSwitchAnimationBegunEvent(UIElement target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchAnimationBegunEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchAnimationCompletedEvent()
	{
		return RaiseSwitchAnimationCompletedEvent((UIElement)(object)this);
	}

	private static RoutedEventArgs RaiseSwitchAnimationCompletedEvent(UIElement target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchAnimationCompletedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		AnimationPanel animationPanel = ((Layouts.Count == 0) ? _defaultLayoutCanvas : ActiveLayout);
		Size val = animationPanel.MeasureChildrenCore(((Panel)this).InternalChildren, availableSize);
		if (IsScrollingPhysically)
		{
			Size viewport = availableSize;
			Size extent = val;
			SetScrollingData(offset: new Vector(Math.Max(0.0, Math.Min(_offset.X, extent.Width - viewport.Width)), Math.Max(0.0, Math.Min(_offset.Y, extent.Height - viewport.Height))), viewport: viewport, extent: extent);
		}
		return val;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		AnimationPanel animationPanel = ((Layouts.Count == 0) ? _defaultLayoutCanvas : ActiveLayout);
		if (IsScrollingPhysically)
		{
			animationPanel.PhysicalScrollOffset = _offset;
		}
		else
		{
			animationPanel.PhysicalScrollOffset = ZeroVector;
		}
		return animationPanel.ArrangeChildrenCore(((Panel)this).InternalChildren, finalSize);
	}

	protected override Visual GetVisualChild(int index)
	{
		if (HasLoaded && _currentLayoutPanel != null)
		{
			return _currentLayoutPanel.GetVisualChildInternal(index);
		}
		return ((Panel)this).GetVisualChild(index);
	}

	protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		if (visualAdded is UIElement)
		{
			if (_currentLayoutPanel == null || !_currentLayoutPanel.IsRemovingInternalChild)
			{
				foreach (AnimationPanel layout in Layouts)
				{
					layout.OnNotifyVisualChildAddedInternal((UIElement)(object)((visualAdded is UIElement) ? visualAdded : null));
				}
			}
		}
		else if (visualRemoved is UIElement)
		{
			foreach (AnimationPanel layout2 in Layouts)
			{
				layout2.OnNotifyVisualChildRemovedInternal((UIElement)(object)((visualRemoved is UIElement) ? visualRemoved : null));
			}
		}
		if (_currentLayoutPanel != null)
		{
			_currentLayoutPanel.OnSwitchParentVisualChildrenChanged(visualAdded, visualRemoved);
		}
		else
		{
			((Panel)this).OnVisualChildrenChanged(visualAdded, visualRemoved);
		}
	}

	internal void AddVisualChildInternal(Visual child)
	{
		((Visual)this).AddVisualChild(child);
	}

	internal void BeginLayoutSwitch()
	{
		RaiseSwitchAnimationBegunEvent();
	}

	internal void EndLayoutSwitch()
	{
		RaiseSwitchAnimationCompletedEvent();
	}

	internal Visual GetVisualChildInternal(int index)
	{
		return ((Panel)this).GetVisualChild(index);
	}

	internal void OnVisualChildrenChangedInternal(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		((Panel)this).OnVisualChildrenChanged(visualAdded, visualRemoved);
	}

	internal UIElement RegisterPresenter(SwitchPresenter presenter)
	{
		UIElement val = null;
		val = AnimationPanel.FindAncestorChildOfAnimationPanel((DependencyObject)(object)presenter, out var _);
		if (val != null)
		{
			_presenters.Add(presenter);
			presenter.SwapTheTemplate(ActiveSwitchTemplate, beginAnimation: false);
		}
		return val;
	}

	internal void RemoveVisualChildInternal(Visual child)
	{
		((Visual)this).RemoveVisualChild(child);
	}

	internal void UnregisterPresenter(SwitchPresenter presenter, DependencyObject container)
	{
		if (container != null)
		{
			_presenters.Remove(presenter);
			presenter.SwapTheTemplate(null, beginAnimation: false);
		}
	}

	internal void UpdateSwitchTemplate()
	{
		SetActiveSwitchTemplate((ActiveLayout == null || ActiveLayout.SwitchTemplate == null) ? SwitchTemplate : ActiveLayout.SwitchTemplate);
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		HasLoaded = true;
		((UIElement)this).InvalidateArrange();
	}

	private void LayoutsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		if (e.Action != NotifyCollectionChangedAction.Move)
		{
			if (e.NewItems != null)
			{
				foreach (AnimationPanel newItem in e.NewItems)
				{
					((FrameworkElement)this).AddLogicalChild((object)newItem);
					newItem.SetSwitchParent(this);
					if (newItem is IScrollInfo)
					{
						((IScrollInfo)newItem).ScrollOwner = ScrollOwner;
					}
					if (!((FrameworkElement)this).IsLoaded)
					{
						continue;
					}
					foreach (UIElement internalChild in ((Panel)this).InternalChildren)
					{
						UIElement val = internalChild;
						if (val != null)
						{
							newItem.OnNotifyVisualChildAddedInternal(val);
						}
					}
				}
			}
			if (e.OldItems != null)
			{
				foreach (AnimationPanel oldItem in e.OldItems)
				{
					if (((FrameworkElement)this).IsLoaded)
					{
						foreach (UIElement internalChild2 in ((Panel)this).InternalChildren)
						{
							UIElement val2 = internalChild2;
							if (val2 != null)
							{
								oldItem.OnNotifyVisualChildRemovedInternal(val2);
							}
						}
					}
					((FrameworkElement)this).RemoveLogicalChild((object)oldItem);
					oldItem.SetSwitchParent(null);
					if (oldItem is IScrollInfo)
					{
						((IScrollInfo)oldItem).ScrollOwner = null;
					}
				}
			}
		}
		((DependencyObject)this).CoerceValue(ActiveLayoutIndexProperty);
		SetActiveLayout((Layouts.Count == 0) ? null : Layouts[ActiveLayoutIndex]);
	}

	private void ResetScrollInfo()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		_offset = default;
		_viewport = (_extent = new Size(0.0, 0.0));
	}

	private void OnScrollChange()
	{
		if (ScrollOwner != null)
		{
			ScrollOwner.InvalidateScrollInfo();
		}
	}

	private void SetScrollingData(Size viewport, Size extent, Vector offset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		_offset = offset;
		if (!DoubleHelper.AreVirtuallyEqual(viewport, _viewport) || !DoubleHelper.AreVirtuallyEqual(extent, _extent) || !DoubleHelper.AreVirtuallyEqual(offset, _computedOffset))
		{
			_viewport = viewport;
			_extent = extent;
			_computedOffset = offset;
			OnScrollChange();
		}
	}

	private double ValidateInputOffset(double offset, string parameterName)
	{
		if (double.IsNaN(offset))
		{
			throw new ArgumentOutOfRangeException(parameterName);
		}
		return Math.Max(0.0, offset);
	}

	private int FindChildFromVisual(Visual vis)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		int result = -1;
		DependencyObject val = (DependencyObject)(object)vis;
		DependencyObject val2 = null;
		do
		{
			val2 = val;
			val = VisualTreeHelper.GetParent(val2);
		}
		while (val != null && (object)val != this);
		if ((object)val == this)
		{
			result = ((Panel)this).Children.IndexOf((UIElement)val2);
		}
		return result;
	}

	public void LineDown()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 1.0);
		}
	}

	public void LineLeft()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineLeft();
		}
		else
		{
			SetHorizontalOffset(VerticalOffset - 1.0);
		}
	}

	public void LineRight()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineRight();
		}
		else
		{
			SetHorizontalOffset(VerticalOffset + 1.0);
		}
	}

	public void LineUp()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 1.0);
		}
	}

	public Rect MakeVisible(Visual visual, Rect rectangle)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			return ((IScrollInfo)ActiveLayout).MakeVisible(visual, rectangle);
		}
		if (rectangle.IsEmpty || visual == null || (object)visual == this || !((Visual)this).IsAncestorOf((DependencyObject)(object)visual))
		{
			return Rect.Empty;
		}
		rectangle = visual.TransformToAncestor((Visual)(object)this).TransformBounds(rectangle);
		if (!IsScrollingPhysically)
		{
			return rectangle;
		}
		int num = FindChildFromVisual(visual);
		if (num == -1)
		{
			throw new ArgumentException("visual");
		}
		Rect itemRect = rectangle;
		itemRect.Offset(_offset);
		Rect physViewRect = new Rect(new Point(_offset.X, _offset.Y), _viewport);
		if (ScrollHelper.ScrollLeastAmount(physViewRect, itemRect, out var newPhysOffset))
		{
			SetHorizontalOffset(newPhysOffset.X);
			SetVerticalOffset(newPhysOffset.Y);
		}
		return rectangle;
	}

	public void MouseWheelDown()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + (double)SystemParameters.WheelScrollLines);
		}
	}

	public void MouseWheelLeft()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelLeft();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - 3.0);
		}
	}

	public void MouseWheelRight()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelRight();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 3.0);
		}
	}

	public void MouseWheelUp()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - (double)SystemParameters.WheelScrollLines);
		}
	}

	public void PageDown()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + ViewportHeight);
		}
	}

	public void PageLeft()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageLeft();
		}
		else
		{
			SetHorizontalOffset(HorizontalOffset - ViewportWidth);
		}
	}

	public void PageRight()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageRight();
		}
		else
		{
			SetHorizontalOffset(HorizontalOffset + ViewportWidth);
		}
	}

	public void PageUp()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - ViewportHeight);
		}
	}

	public void SetHorizontalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "HorizontalOffset");
		offset = Math.Min(offset, ExtentWidth - ViewportWidth);
		if (!DoubleHelper.AreVirtuallyEqual(offset, _offset.X))
		{
			_offset.X = offset;
			((UIElement)this).InvalidateMeasure();
		}
	}

	public void SetVerticalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "VerticalOffset");
		offset = Math.Min(offset, ExtentHeight - ViewportHeight);
		if (!DoubleHelper.AreVirtuallyEqual(offset, _offset.Y))
		{
			_offset.Y = offset;
			((UIElement)this).InvalidateMeasure();
		}
	}

	static SwitchPanel()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected Obj, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected Obj, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected Obj, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected Obj, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected Obj, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected Obj, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected Obj, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected Obj, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected Obj, but got Unknown
	}
}
