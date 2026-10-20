using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

[StyleTypedProperty(Property = "PropertyContainerStyle", StyleTargetType = typeof(PropertyItemBase))]
[TemplatePart(Name = "PART_DragThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_PropertyItemsControl", Type = typeof(PropertyItemsControl))]
public class PropertyGrid : Control, ISupportInitialize, IPropertyContainer, INotifyPropertyChanged
{
	private const string PART_DragThumb = "PART_DragThumb";

	internal const string PART_PropertyItemsControl = "PART_PropertyItemsControl";

	private static readonly ComponentResourceKey SelectedObjectAdvancedOptionsMenuKey;

	private Thumb _dragThumb;

	private bool _hasPendingSelectedObjectChanged;

	private int _initializationCount;

	private ContainerHelperBase _containerHelper;

	private PropertyDefinitionCollection _propertyDefinitions;

	private EditorDefinitionCollection _editorDefinitions;

	private WeakEventListener<NotifyCollectionChangedEventArgs> _propertyDefinitionsListener;

	private WeakEventListener<NotifyCollectionChangedEventArgs> _editorDefinitionsListener;

	public static readonly DependencyProperty AdvancedOptionsMenuProperty;

	public static readonly DependencyProperty AutoGeneratePropertiesProperty;

	public static readonly DependencyProperty ShowSummaryProperty;

	public static readonly DependencyProperty FilterProperty;

	public static readonly DependencyProperty FilterWatermarkProperty;

	public static readonly DependencyProperty IsCategorizedProperty;

	public static readonly DependencyProperty NameColumnWidthProperty;

	public static readonly DependencyProperty PropertyContainerStyleProperty;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty SelectedObjectProperty;

	public static readonly DependencyProperty SelectedObjectTypeProperty;

	public static readonly DependencyProperty SelectedObjectTypeNameProperty;

	public static readonly DependencyProperty SelectedObjectNameProperty;

	private static readonly DependencyPropertyKey SelectedPropertyItemPropertyKey;

	public static readonly DependencyProperty SelectedPropertyItemProperty;

	public static readonly DependencyProperty SelectedPropertyProperty;

	public static readonly DependencyProperty ShowAdvancedOptionsProperty;

	public static readonly DependencyProperty ShowSearchBoxProperty;

	public static readonly DependencyProperty ShowSortOptionsProperty;

	public static readonly DependencyProperty ShowTitleProperty;

	public static readonly RoutedEvent PropertyValueChangedEvent;

	public static readonly RoutedEvent SelectedPropertyItemChangedEvent;

	public static readonly RoutedEvent SelectedObjectChangedEvent;

	public static readonly RoutedEvent PreparePropertyItemEvent;

	public static readonly RoutedEvent ClearPropertyItemEvent;

	public ContextMenu AdvancedOptionsMenu
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ContextMenu)((DependencyObject)this).GetValue(AdvancedOptionsMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsMenuProperty, (object)value);
		}
	}

	public bool AutoGenerateProperties
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoGeneratePropertiesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoGeneratePropertiesProperty, (object)value);
		}
	}

	public bool ShowSummary
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSummaryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSummaryProperty, (object)value);
		}
	}

	public EditorDefinitionCollection EditorDefinitions
	{
		get
		{
			return _editorDefinitions;
		}
		set
		{
			if (_editorDefinitions != value)
			{
				EditorDefinitionCollection editorDefinitions = _editorDefinitions;
				_editorDefinitions = value;
				OnEditorDefinitionsChanged(editorDefinitions, value);
			}
		}
	}

	public string Filter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FilterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilterProperty, (object)value);
		}
	}

	public string FilterWatermark
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FilterWatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilterWatermarkProperty, (object)value);
		}
	}

	public bool IsCategorized
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCategorizedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCategorizedProperty, (object)value);
		}
	}

	public double NameColumnWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(NameColumnWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NameColumnWidthProperty, (object)value);
		}
	}

	public IList Properties => _containerHelper.Properties;

	public Style PropertyContainerStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(PropertyContainerStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyContainerStyleProperty, (object)value);
		}
	}

	public PropertyDefinitionCollection PropertyDefinitions
	{
		get
		{
			return _propertyDefinitions;
		}
		set
		{
			if (_propertyDefinitions != value)
			{
				PropertyDefinitionCollection propertyDefinitions = _propertyDefinitions;
				_propertyDefinitions = value;
				OnPropertyDefinitionsChanged(propertyDefinitions, value);
			}
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

	public object SelectedObject
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedObjectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectProperty, value);
		}
	}

	public Type SelectedObjectType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(SelectedObjectTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectTypeProperty, (object)value);
		}
	}

	public string SelectedObjectTypeName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedObjectTypeNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectTypeNameProperty, (object)value);
		}
	}

	public string SelectedObjectName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedObjectNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectNameProperty, (object)value);
		}
	}

	public PropertyItemBase SelectedPropertyItem
	{
		get
		{
			return (PropertyItemBase)((DependencyObject)this).GetValue(SelectedPropertyItemProperty);
		}
		internal set
		{
			((DependencyObject)this).SetValue(SelectedPropertyItemPropertyKey, (object)value);
		}
	}

	public object SelectedProperty
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedPropertyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPropertyProperty, value);
		}
	}

	public bool ShowAdvancedOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAdvancedOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAdvancedOptionsProperty, (object)value);
		}
	}

	public bool ShowSearchBox
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSearchBoxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSearchBoxProperty, (object)value);
		}
	}

	public bool ShowSortOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSortOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSortOptionsProperty, (object)value);
		}
	}

	public bool ShowTitle
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTitleProperty, (object)value);
		}
	}

	FilterInfo IPropertyContainer.FilterInfo => new FilterInfo
	{
		Predicate = CreateFilter(Filter),
		InputString = Filter
	};

	ContainerHelperBase IPropertyContainer.ContainerHelper => _containerHelper;

	public event PropertyChangedEventHandler PropertyChanged;

	public event PropertyValueChangedEventHandler PropertyValueChanged
	{
		add
		{
			((UIElement)this).AddHandler(PropertyValueChangedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(PropertyValueChangedEvent, (Delegate)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<PropertyItemBase> SelectedPropertyItemChanged
	{
		add
		{
			((UIElement)this).AddHandler(SelectedPropertyItemChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(SelectedPropertyItemChangedEvent, (Delegate)(object)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<object> SelectedObjectChanged
	{
		add
		{
			((UIElement)this).AddHandler(SelectedObjectChangedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(SelectedObjectChangedEvent, (Delegate)(object)value);
		}
	}

	public event PropertyItemEventHandler PreparePropertyItem
	{
		add
		{
			((UIElement)this).AddHandler(PreparePropertyItemEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(PreparePropertyItemEvent, (Delegate)value);
		}
	}

	public event PropertyItemEventHandler ClearPropertyItem
	{
		add
		{
			((UIElement)this).AddHandler(ClearPropertyItemEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ClearPropertyItemEvent, (Delegate)value);
		}
	}

	protected virtual void OnEditorDefinitionsChanged(EditorDefinitionCollection oldValue, EditorDefinitionCollection newValue)
	{
		if (oldValue != null)
		{
			CollectionChangedEventManager.RemoveListener((INotifyCollectionChanged)oldValue, (IWeakEventListener)(object)_editorDefinitionsListener);
		}
		if (newValue != null)
		{
			CollectionChangedEventManager.AddListener((INotifyCollectionChanged)newValue, (IWeakEventListener)(object)_editorDefinitionsListener);
		}
		this.Notify(PropertyChanged, () => EditorDefinitions);
	}

	private void OnEditorDefinitionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		_containerHelper.NotifyEditorDefinitionsCollectionChanged();
	}

	private static void OnFilterChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnFilterChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnFilterChanged(string oldValue, string newValue)
	{
		this.Notify(PropertyChanged, () => ((IPropertyContainer)this).FilterInfo);
	}

	private static void OnIsCategorizedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnIsCategorizedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsCategorizedChanged(bool oldValue, bool newValue)
	{
		UpdateThumb();
	}

	private static void OnNameColumnWidthChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnNameColumnWidthChanged((double)e.OldValue, (double)e.NewValue);
		}
	}

	protected virtual void OnNameColumnWidthChanged(double oldValue, double newValue)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (_dragThumb != null)
		{
			((TranslateTransform)((UIElement)_dragThumb).RenderTransform).X = newValue;
		}
	}

	private static void OnPropertyContainerStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Expected Obj, but got Unknown
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnPropertyContainerStyleChanged((Style)e.OldValue, (Style)e.NewValue);
		}
	}

	protected virtual void OnPropertyContainerStyleChanged(Style oldValue, Style newValue)
	{
	}

	protected virtual void OnPropertyDefinitionsChanged(PropertyDefinitionCollection oldValue, PropertyDefinitionCollection newValue)
	{
		if (oldValue != null)
		{
			CollectionChangedEventManager.RemoveListener((INotifyCollectionChanged)oldValue, (IWeakEventListener)(object)_propertyDefinitionsListener);
		}
		if (newValue != null)
		{
			CollectionChangedEventManager.AddListener((INotifyCollectionChanged)newValue, (IWeakEventListener)(object)_propertyDefinitionsListener);
		}
		this.Notify(PropertyChanged, () => PropertyDefinitions);
	}

	private void OnPropertyDefinitionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		_containerHelper.NotifyPropertyDefinitionsCollectionChanged();
	}

	private static void OnSelectedObjectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedObjectChanged(e.OldValue, e.NewValue);
		}
	}

	protected virtual void OnSelectedObjectChanged(object oldValue, object newValue)
	{
		if (_initializationCount != 0)
		{
			_hasPendingSelectedObjectChanged = true;
			return;
		}
		UpdateContainerHelper();
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, SelectedObjectChangedEvent));
	}

	private static void OnSelectedObjectTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedObjectTypeChanged((Type)e.OldValue, (Type)e.NewValue);
		}
	}

	protected virtual void OnSelectedObjectTypeChanged(Type oldValue, Type newValue)
	{
	}

	private static object OnCoerceSelectedObjectName(DependencyObject o, object baseValue)
	{
		if (o is PropertyGrid propertyGrid && propertyGrid.SelectedObject is FrameworkElement && string.IsNullOrEmpty((string)baseValue))
		{
			return "<no name>";
		}
		return baseValue;
	}

	private static void OnSelectedObjectNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.SelectedObjectNameChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void SelectedObjectNameChanged(string oldValue, string newValue)
	{
	}

	private static void OnSelectedPropertyItemChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedPropertyItemChanged((PropertyItemBase)e.OldValue, (PropertyItemBase)e.NewValue);
		}
	}

	protected virtual void OnSelectedPropertyItemChanged(PropertyItemBase oldValue, PropertyItemBase newValue)
	{
		if (oldValue != null)
		{
			oldValue.IsSelected = false;
		}
		if (newValue != null)
		{
			newValue.IsSelected = true;
		}
		SelectedProperty = ((newValue != null) ? _containerHelper.ItemFromContainer(newValue) : null);
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new RoutedPropertyChangedEventArgs<PropertyItemBase>(oldValue, newValue, SelectedPropertyItemChangedEvent));
	}

	private static void OnSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedPropertyChanged(args.OldValue, args.NewValue);
		}
	}

	private void OnSelectedPropertyChanged(object oldValue, object newValue)
	{
		object objA = _containerHelper.ItemFromContainer(SelectedPropertyItem);
		if (!object.Equals(objA, newValue))
		{
			SelectedPropertyItem = _containerHelper.ContainerFromItem(newValue);
		}
	}

	static PropertyGrid()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected Obj, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected Obj, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected Obj, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected Obj, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected Obj, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected Obj, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected Obj, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected Obj, but got Unknown
		//IL_02b1: Expected Obj, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected Obj, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected Obj, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected Obj, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected Obj, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected Obj, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected Obj, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected Obj, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected Obj, but got Unknown
		SelectedObjectAdvancedOptionsMenuKey = new ComponentResourceKey(typeof(PropertyGrid), (object)"SelectedObjectAdvancedOptionsMenu");
		AdvancedOptionsMenuProperty = DependencyProperty.Register("AdvancedOptionsMenu", typeof(ContextMenu), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		AutoGeneratePropertiesProperty = DependencyProperty.Register("AutoGenerateProperties", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowSummaryProperty = DependencyProperty.Register("ShowSummary", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true));
		FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnFilterChanged));
		FilterWatermarkProperty = DependencyProperty.Register("FilterWatermark", typeof(string), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)"Search"));
		IsCategorizedProperty = DependencyProperty.Register("IsCategorized", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)OnIsCategorizedChanged));
		NameColumnWidthProperty = DependencyProperty.Register("NameColumnWidth", typeof(double), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)150.0, (PropertyChangedCallback)OnNameColumnWidthChanged));
		PropertyContainerStyleProperty = DependencyProperty.Register("PropertyContainerStyle", typeof(Style), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnPropertyContainerStyleChanged));
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)false));
		SelectedObjectProperty = DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedObjectChanged));
		SelectedObjectTypeProperty = DependencyProperty.Register("SelectedObjectType", typeof(Type), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedObjectTypeChanged));
		SelectedObjectTypeNameProperty = DependencyProperty.Register("SelectedObjectTypeName", typeof(string), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty));
		SelectedObjectNameProperty = DependencyProperty.Register("SelectedObjectName", typeof(string), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty, (PropertyChangedCallback)OnSelectedObjectNameChanged, (CoerceValueCallback)OnCoerceSelectedObjectName));
		SelectedPropertyItemPropertyKey = DependencyProperty.RegisterReadOnly("SelectedPropertyItem", typeof(PropertyItemBase), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedPropertyItemChanged));
		SelectedPropertyItemProperty = SelectedPropertyItemPropertyKey.DependencyProperty;
		SelectedPropertyProperty = DependencyProperty.Register("SelectedProperty", typeof(object), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedPropertyChanged));
		ShowAdvancedOptionsProperty = DependencyProperty.Register("ShowAdvancedOptions", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)false));
		ShowSearchBoxProperty = DependencyProperty.Register("ShowSearchBox", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowSortOptionsProperty = DependencyProperty.Register("ShowSortOptions", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true));
		ShowTitleProperty = DependencyProperty.Register("ShowTitle", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)new UIPropertyMetadata((object)true));
		PropertyValueChangedEvent = EventManager.RegisterRoutedEvent("PropertyValueChanged", (RoutingStrategy)1, typeof(PropertyValueChangedEventHandler), typeof(PropertyGrid));
		SelectedPropertyItemChangedEvent = EventManager.RegisterRoutedEvent("SelectedPropertyItemChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<PropertyItemBase>), typeof(PropertyGrid));
		SelectedObjectChangedEvent = EventManager.RegisterRoutedEvent("SelectedObjectChanged", (RoutingStrategy)1, typeof(RoutedPropertyChangedEventHandler<object>), typeof(PropertyGrid));
		PreparePropertyItemEvent = EventManager.RegisterRoutedEvent("PreparePropertyItem", (RoutingStrategy)1, typeof(PropertyItemEventHandler), typeof(PropertyGrid));
		ClearPropertyItemEvent = EventManager.RegisterRoutedEvent("ClearPropertyItem", (RoutingStrategy)1, typeof(PropertyItemEventHandler), typeof(PropertyGrid));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGrid), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(PropertyGrid)));
	}

	public PropertyGrid()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_00bd: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		_propertyDefinitionsListener = new WeakEventListener<NotifyCollectionChangedEventArgs>(OnPropertyDefinitionsCollectionChanged);
		_editorDefinitionsListener = new WeakEventListener<NotifyCollectionChangedEventArgs>(OnEditorDefinitionsCollectionChanged);
		UpdateContainerHelper();
		EditorDefinitions = new EditorDefinitionCollection();
		PropertyDefinitions = new PropertyDefinitionCollection();
		((UIElement)this).AddHandler(PropertyItemBase.ItemSelectionChangedEvent, (Delegate)new RoutedEventHandler(OnItemSelectionChanged));
		((UIElement)this).AddHandler(PropertyItemsControl.PreparePropertyItemEvent, (Delegate)new PropertyItemEventHandler(OnPreparePropertyItemInternal));
		((UIElement)this).AddHandler(PropertyItemsControl.ClearPropertyItemEvent, (Delegate)new PropertyItemEventHandler(OnClearPropertyItemInternal));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)PropertyGridCommands.ClearFilter, (ExecutedRoutedEventHandler)ClearFilter, (CanExecuteRoutedEventHandler)CanClearFilter));
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_dragThumb != null)
		{
			_dragThumb.DragDelta -= DragThumb_DragDelta;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_DragThumb");
		_dragThumb = (Thumb)(object)((templateChild is Thumb) ? templateChild : null);
		if (_dragThumb != null)
		{
			_dragThumb.DragDelta += DragThumb_DragDelta;
		}
		_containerHelper.ChildrenItemsControl = (ItemsControl)(object)(((FrameworkElement)this).GetTemplateChild("PART_PropertyItemsControl") as PropertyItemsControl);
		TranslateTransform val = new TranslateTransform();
		val.X = NameColumnWidth;
		((UIElement)_dragThumb).RenderTransform = (Transform)(object)val;
		UpdateThumb();
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedPropertyItem == null || (int)e.Key != 6 || !(((RoutedEventArgs)e).OriginalSource is TextBox))
		{
			return;
		}
		object originalSource = ((RoutedEventArgs)e).OriginalSource;
		if (!((TextBoxBase)((originalSource is TextBox) ? originalSource : null)).AcceptsReturn)
		{
			BindingExpression bindingExpression = ((FrameworkElement)(TextBox)((RoutedEventArgs)e).OriginalSource).GetBindingExpression(TextBox.TextProperty);
			if (bindingExpression != null)
			{
				((BindingExpressionBase)bindingExpression).UpdateSource();
			}
		}
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)this).OnPropertyChanged(e);
		if (ReflectionHelper.IsPublicInstanceProperty(((object)this).GetType(), e.Property.Name))
		{
			this.Notify(PropertyChanged, e.Property.Name);
		}
	}

	private void OnItemSelectionChanged(object sender, RoutedEventArgs args)
	{
		PropertyItemBase propertyItemBase = (PropertyItemBase)args.OriginalSource;
		if (propertyItemBase.IsSelected)
		{
			SelectedPropertyItem = propertyItemBase;
		}
		else if (object.ReferenceEquals(propertyItemBase, SelectedPropertyItem))
		{
			SelectedPropertyItem = null;
		}
	}

	private void OnPreparePropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		_containerHelper.PrepareChildrenPropertyItem(args.PropertyItem, args.Item);
		((RoutedEventArgs)args).Handled = true;
	}

	private void OnClearPropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		_containerHelper.ClearChildrenPropertyItem(args.PropertyItem, args.Item);
		((RoutedEventArgs)args).Handled = true;
	}

	private void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
	{
		NameColumnWidth = Math.Max(0.0, NameColumnWidth + e.HorizontalChange);
	}

	private void ClearFilter(object sender, ExecutedRoutedEventArgs e)
	{
		Filter = string.Empty;
	}

	private void CanClearFilter(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = !string.IsNullOrEmpty(Filter);
	}

	private void UpdateContainerHelper()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		ItemsControl childrenItemsControl = null;
		if (_containerHelper != null)
		{
			childrenItemsControl = _containerHelper.ChildrenItemsControl;
			_containerHelper.ClearHelper();
			if (_containerHelper is ObjectContainerHelperBase)
			{
				ContextMenu val = (ContextMenu)((FrameworkElement)this).FindResource((object)SelectedObjectAdvancedOptionsMenuKey);
				if (AdvancedOptionsMenu == val)
				{
					AdvancedOptionsMenu = null;
				}
			}
		}
		_containerHelper = new ObjectContainerHelper(this, SelectedObject);
		((ObjectContainerHelper)_containerHelper).GenerateProperties();
		_containerHelper.ChildrenItemsControl = childrenItemsControl;
		this.Notify(PropertyChanged, () => Properties);
	}

	private void UpdateThumb()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (_dragThumb != null)
		{
			if (IsCategorized)
			{
				((FrameworkElement)_dragThumb).Margin = new Thickness(6.0, 0.0, 0.0, 0.0);
			}
			else
			{
				((FrameworkElement)_dragThumb).Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
			}
		}
	}

	protected virtual Predicate<object> CreateFilter(string filter)
	{
		return null;
	}

	public void Update()
	{
		_containerHelper.UpdateValuesFromSource();
	}

	public static void AddPreparePropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.AddHandler(PreparePropertyItemEvent, (Delegate)handler);
	}

	public static void RemovePreparePropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.RemoveHandler(PreparePropertyItemEvent, (Delegate)handler);
	}

	internal static void RaisePreparePropertyItemEvent(UIElement source, PropertyItemBase propertyItem, object item)
	{
		source.RaiseEvent((RoutedEventArgs)(object)new PropertyItemEventArgs(PreparePropertyItemEvent, source, propertyItem, item));
	}

	public static void AddClearPropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.AddHandler(ClearPropertyItemEvent, (Delegate)handler);
	}

	public static void RemoveClearPropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.RemoveHandler(ClearPropertyItemEvent, (Delegate)handler);
	}

	internal static void RaiseClearPropertyItemEvent(UIElement source, PropertyItemBase propertyItem, object item)
	{
		source.RaiseEvent((RoutedEventArgs)(object)new PropertyItemEventArgs(ClearPropertyItemEvent, source, propertyItem, item));
	}

	public override void BeginInit()
	{
		((FrameworkElement)this).BeginInit();
		_initializationCount++;
	}

	public override void EndInit()
	{
		((FrameworkElement)this).EndInit();
		if (--_initializationCount == 0)
		{
			if (_hasPendingSelectedObjectChanged)
			{
				UpdateContainerHelper();
				_hasPendingSelectedObjectChanged = false;
			}
			_containerHelper.OnEndInit();
		}
	}
}
