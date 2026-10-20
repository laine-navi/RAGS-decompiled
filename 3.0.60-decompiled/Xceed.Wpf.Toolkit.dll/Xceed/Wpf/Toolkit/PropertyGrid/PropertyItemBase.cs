using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

[TemplatePart(Name = "PART_ValueContainer", Type = typeof(ContentControl))]
[TemplatePart(Name = "PART_PropertyItemsControl", Type = typeof(PropertyItemsControl))]
public abstract class PropertyItemBase : Control, IPropertyContainer, INotifyPropertyChanged
{
	internal const string PART_ValueContainer = "PART_ValueContainer";

	private ContentControl _valueContainer;

	private ContainerHelperBase _containerHelper;

	private IPropertyContainer _parentNode;

	public static readonly DependencyProperty AdvancedOptionsIconProperty;

	public static readonly DependencyProperty AdvancedOptionsTooltipProperty;

	public static readonly DependencyProperty DescriptionProperty;

	public static readonly DependencyProperty DisplayNameProperty;

	public static readonly DependencyProperty EditorProperty;

	public static readonly DependencyProperty IsExpandedProperty;

	public static readonly DependencyProperty IsExpandableProperty;

	public static readonly DependencyProperty IsSelectedProperty;

	internal static readonly RoutedEvent ItemSelectionChangedEvent;

	public ImageSource AdvancedOptionsIcon
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ImageSource)((DependencyObject)this).GetValue(AdvancedOptionsIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsIconProperty, (object)value);
		}
	}

	public object AdvancedOptionsTooltip
	{
		get
		{
			return ((DependencyObject)this).GetValue(AdvancedOptionsTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsTooltipProperty, value);
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

	public string DisplayName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DisplayNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayNameProperty, (object)value);
		}
	}

	public FrameworkElement Editor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (FrameworkElement)((DependencyObject)this).GetValue(EditorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorProperty, (object)value);
		}
	}

	public bool IsExpanded
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsExpandedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsExpandedProperty, (object)value);
		}
	}

	public bool IsExpandable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsExpandableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsExpandableProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public FrameworkElement ParentElement
	{
		get
		{
			IPropertyContainer parentNode = ParentNode;
			return (FrameworkElement)((parentNode is FrameworkElement) ? parentNode : null);
		}
	}

	internal IPropertyContainer ParentNode
	{
		get
		{
			return _parentNode;
		}
		set
		{
			_parentNode = value;
		}
	}

	internal ContentControl ValueContainer => _valueContainer;

	public int Level { get; internal set; }

	public IList Properties => _containerHelper.Properties;

	public Style PropertyContainerStyle
	{
		get
		{
			if (ParentNode == null)
			{
				return null;
			}
			return ParentNode.PropertyContainerStyle;
		}
	}

	internal ContainerHelperBase ContainerHelper
	{
		get
		{
			return _containerHelper;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_containerHelper = value;
			RaisePropertyChanged(() => Properties);
		}
	}

	Style IPropertyContainer.PropertyContainerStyle => PropertyContainerStyle;

	EditorDefinitionCollection IPropertyContainer.EditorDefinitions => ParentNode.EditorDefinitions;

	PropertyDefinitionCollection IPropertyContainer.PropertyDefinitions => null;

	ContainerHelperBase IPropertyContainer.ContainerHelper => ContainerHelper;

	bool IPropertyContainer.IsCategorized => false;

	bool IPropertyContainer.AutoGenerateProperties => true;

	FilterInfo IPropertyContainer.FilterInfo => default;

	public event PropertyChangedEventHandler PropertyChanged;

	private static void OnEditorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Expected Obj, but got Unknown
		if (o is PropertyItem propertyItem)
		{
			propertyItem.OnEditorChanged((FrameworkElement)e.OldValue, (FrameworkElement)e.NewValue);
		}
	}

	protected virtual void OnEditorChanged(FrameworkElement oldValue, FrameworkElement newValue)
	{
	}

	private static void OnIsExpandedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyItemBase propertyItemBase)
		{
			propertyItemBase.OnIsExpandedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsExpandedChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyItemBase propertyItemBase)
		{
			propertyItemBase.OnIsSelectedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsSelectedChanged(bool oldValue, bool newValue)
	{
		RaiseItemSelectionChangedEvent();
	}

	private void RaiseItemSelectionChangedEvent()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		((UIElement)this).RaiseEvent(new RoutedEventArgs(ItemSelectionChangedEvent));
	}

	internal void RaisePropertyChanged<TMember>(Expression<Func<TMember>> propertyExpression)
	{
		this.Notify(PropertyChanged, propertyExpression);
	}

	internal void RaisePropertyChanged(string name)
	{
		this.Notify(PropertyChanged, name);
	}

	static PropertyItemBase()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected Obj, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected Obj, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		AdvancedOptionsIconProperty = DependencyProperty.Register("AdvancedOptionsIcon", typeof(ImageSource), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		AdvancedOptionsTooltipProperty = DependencyProperty.Register("AdvancedOptionsTooltip", typeof(object), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		DisplayNameProperty = DependencyProperty.Register("DisplayName", typeof(string), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		EditorProperty = DependencyProperty.Register("Editor", typeof(FrameworkElement), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnEditorChanged));
		IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsExpandedChanged));
		IsExpandableProperty = DependencyProperty.Register("IsExpandable", typeof(bool), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(PropertyItemBase), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsSelectedChanged));
		ItemSelectionChangedEvent = EventManager.RegisterRoutedEvent("ItemSelectionChangedEvent", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(PropertyItemBase));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyItemBase), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyItemBase)));
	}

	internal PropertyItemBase()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		_containerHelper = new ObjectContainerHelper(this, null);
		((UIElement)this).GotFocus += PropertyItemBase_GotFocus;
		((UIElement)this).AddHandler(PropertyItemsControl.PreparePropertyItemEvent, (Delegate)new PropertyItemEventHandler(OnPreparePropertyItemInternal));
		((UIElement)this).AddHandler(PropertyItemsControl.ClearPropertyItemEvent, (Delegate)new PropertyItemEventHandler(OnClearPropertyItemInternal));
	}

	private void OnPreparePropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		args.PropertyItem.Level = Level + 1;
		_containerHelper.PrepareChildrenPropertyItem(args.PropertyItem, args.Item);
		((RoutedEventArgs)args).Handled = true;
	}

	private void OnClearPropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		_containerHelper.ClearChildrenPropertyItem(args.PropertyItem, args.Item);
		args.PropertyItem.Level = 0;
		((RoutedEventArgs)args).Handled = true;
	}

	public override void OnApplyTemplate()
	{
		((FrameworkElement)this).OnApplyTemplate();
		_containerHelper.ChildrenItemsControl = (ItemsControl)(object)(((FrameworkElement)this).GetTemplateChild("PART_PropertyItemsControl") as PropertyItemsControl);
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_ValueContainer");
		_valueContainer = (ContentControl)(object)((templateChild is ContentControl) ? templateChild : null);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		IsSelected = true;
		if (!((UIElement)this).IsKeyboardFocusWithin)
		{
			((UIElement)this).Focus();
		}
		((RoutedEventArgs)e).Handled = true;
	}

	private void PropertyItemBase_GotFocus(object sender, RoutedEventArgs e)
	{
		IsSelected = true;
		e.Handled = true;
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)this).OnPropertyChanged(e);
		if (ReflectionHelper.IsPublicInstanceProperty(((object)this).GetType(), e.Property.Name))
		{
			RaisePropertyChanged(e.Property.Name);
		}
	}
}
