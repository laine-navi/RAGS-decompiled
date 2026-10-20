using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public class SwitchPresenter : FrameworkElement
{
	private struct DelaySwitchParams
	{
		public DataTemplate Template;

		public bool BeginAnimation;
	}

	public static readonly DependencyProperty DelaySwitchProperty = DependencyProperty.Register("DelaySwitch", typeof(bool), typeof(SwitchPresenter), (PropertyMetadata)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty DelayPriorityProperty = DependencyProperty.Register("DelayPriority", typeof(DispatcherPriority), typeof(SwitchPresenter), (PropertyMetadata)new UIPropertyMetadata((object)(DispatcherPriority)4));

	internal static readonly DependencyProperty SwitchParentProperty = DependencyProperty.Register("SwitchParent", typeof(SwitchPanel), typeof(SwitchPresenter), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnSwitchParentChanged));

	internal UIElement _switchRoot;

	internal Dictionary<string, FrameworkElement> _knownIDs = new Dictionary<string, FrameworkElement>();

	private ContentPresenter _contentPresenter = new ContentPresenter();

	private bool _isMeasured;

	private DataTemplate _currentTemplate;

	public bool DelaySwitch
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DelaySwitchProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DelaySwitchProperty, (object)value);
		}
	}

	public DispatcherPriority DelayPriority
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (DispatcherPriority)((DependencyObject)this).GetValue(DelayPriorityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(DelayPriorityProperty, (object)value);
		}
	}

	internal SwitchPanel SwitchParent
	{
		get
		{
			return (SwitchPanel)((DependencyObject)this).GetValue(SwitchParentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchParentProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => 1;

	public SwitchPresenter()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		((Visual)this).AddVisualChild((Visual)(object)_contentPresenter);
		((FrameworkElement)this).Loaded += SwitchPresenter_Loaded;
		((FrameworkElement)this).Unloaded += SwitchPresenter_Unloaded;
	}

	private static void OnSwitchParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPresenter)(object)d).OnSwitchParentChanged(e);
	}

	protected virtual void OnSwitchParentChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		if (e.OldValue != null)
		{
			(e.OldValue as SwitchPanel).UnregisterPresenter(this, (DependencyObject)(object)_switchRoot);
			_switchRoot = null;
			BindingOperations.ClearAllBindings((DependencyObject)(object)_contentPresenter);
		}
		if (e.NewValue != null)
		{
			((FrameworkElement)_contentPresenter).SetBinding(ContentPresenter.ContentProperty, (BindingBase)new Binding());
			_switchRoot = (e.NewValue as SwitchPanel).RegisterPresenter(this);
		}
	}

	private static void OnLoaded(object sender, RoutedEventArgs e)
	{
		SwitchPresenter switchPresenter = sender as SwitchPresenter;
		if (switchPresenter._switchRoot == null)
		{
			switchPresenter.SwitchParent = VisualTreeHelperEx.FindAncestorByType((DependencyObject)(object)switchPresenter, typeof(SwitchPanel), specificTypeOnly: false) as SwitchPanel;
		}
	}

	private static void OnUnloaded(object sender, RoutedEventArgs e)
	{
		(sender as SwitchPresenter).SwitchParent = null;
	}

	internal void RegisterID(string id, FrameworkElement element)
	{
		if (element != null)
		{
			_knownIDs[id] = element;
		}
	}

	internal void SwapTheTemplate(DataTemplate template, bool beginAnimation)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (DelaySwitch)
		{
			_currentTemplate = template;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)new Action<DelaySwitchParams>(OnSwapTemplate), DelayPriority, new object[1]
			{
				new DelaySwitchParams
				{
					Template = template,
					BeginAnimation = beginAnimation
				}
			});
		}
		else
		{
			DoSwapTemplate(template, beginAnimation);
		}
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (!_isMeasured && _switchRoot == null)
		{
			OnLoaded(this, null);
			_isMeasured = true;
		}
		((UIElement)_contentPresenter).Measure(constraint);
		return ((UIElement)_contentPresenter).DesiredSize;
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)_contentPresenter).Arrange(new Rect(arrangeBounds));
		return arrangeBounds;
	}

	protected override Visual GetVisualChild(int index)
	{
		if (index != 0)
		{
			throw new ArgumentOutOfRangeException("index", index, "");
		}
		return (Visual)(object)_contentPresenter;
	}

	private void OnSwapTemplate(DelaySwitchParams data)
	{
		if (data.Template == _currentTemplate)
		{
			DoSwapTemplate(data.Template, data.BeginAnimation);
			_currentTemplate = null;
		}
	}

	private void DoSwapTemplate(DataTemplate template, bool beginAnimation)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, Rect> knownLocations = null;
		if (beginAnimation && _knownIDs.Count > 0)
		{
			knownLocations = new Dictionary<string, Rect>();
			foreach (KeyValuePair<string, FrameworkElement> knownID in _knownIDs)
			{
				Size renderSize = ((UIElement)knownID.Value).RenderSize;
				GeneralTransform val = ((Visual)knownID.Value).TransformToAncestor((Visual)(object)SwitchParent);
				Matrix matrix = ((MatrixTransform)((val is MatrixTransform) ? val : null)).Matrix;
				Point[] array = new Point[2]
				{
					default,
					new Point(renderSize.Width, renderSize.Height)
				};
				matrix.Transform(array);
				knownLocations[knownID.Key] = new Rect(array[0], array[1]);
			}
		}
		_knownIDs.Clear();
		_contentPresenter.ContentTemplate = template;
		if (template != null)
		{
			((FrameworkElement)_contentPresenter).ApplyTemplate();
		}
		if (knownLocations == null || _knownIDs.Count <= 0)
		{
			return;
		}
		Dictionary<string, Rect> newLocations = null;
		RoutedEventHandler onLoaded = null;
		onLoaded = (object sender, RoutedEventArgs e) =>
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			FrameworkElement val2 = (FrameworkElement)((sender is FrameworkElement) ? sender : null);
			val2.Loaded -= onLoaded;
			string iD = SwitchTemplate.GetID((DependencyObject)(object)val2);
			if (knownLocations.ContainsKey(iD))
			{
				if (newLocations == null)
				{
					newLocations = SwitchParent.ActiveLayout.GetNewLocationsBasedOnTargetPlacement(this, _switchRoot);
				}
				DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)val2);
				UIElement val3 = (UIElement)(object)((parent is UIElement) ? parent : null);
				if (val3 != null)
				{
					Rect val4 = knownLocations[iD];
					Point[] array2 = new Point[2] { val4.TopLeft, val4.BottomRight };
					GeneralTransform val5 = ((Visual)SwitchParent).TransformToDescendant((Visual)(object)val3);
					Matrix matrix2 = ((MatrixTransform)((val5 is MatrixTransform) ? val5 : null)).Matrix;
					matrix2.Transform(array2);
					Rect currentRect = new Rect(array2[0], array2[1]);
					Rect placementRect = newLocations[iD];
					SwitchParent.ActiveLayout.BeginGrandchildAnimation(val2, currentRect, placementRect);
				}
			}
		};
		foreach (KeyValuePair<string, FrameworkElement> knownID2 in _knownIDs)
		{
			knownID2.Value.Loaded += onLoaded;
		}
	}

	private void SwitchPresenter_Unloaded(object sender, RoutedEventArgs e)
	{
		SwitchParent = null;
	}

	private void SwitchPresenter_Loaded(object sender, RoutedEventArgs e)
	{
		if (_switchRoot == null)
		{
			SwitchParent = VisualTreeHelperEx.FindAncestorByType((DependencyObject)(object)this, typeof(SwitchPanel), specificTypeOnly: false) as SwitchPanel;
		}
	}

	static SwitchPresenter()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
	}
}
