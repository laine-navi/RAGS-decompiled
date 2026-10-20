using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_NewItemTypesComboBox", Type = typeof(ComboBox))]
public class CollectionControl : Control
{
	public delegate void ItemDeletingRoutedEventHandler(object sender, ItemDeletingEventArgs e);

	public delegate void ItemDeletedRoutedEventHandler(object sender, ItemEventArgs e);

	public delegate void ItemAddingRoutedEventHandler(object sender, ItemAddingEventArgs e);

	public delegate void ItemAddedRoutedEventHandler(object sender, ItemEventArgs e);

	private const string PART_NewItemTypesComboBox = "PART_NewItemTypesComboBox";

	private ComboBox _newItemTypesComboBox;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty ItemsProperty;

	public static readonly DependencyProperty ItemsSourceProperty;

	public static readonly DependencyProperty ItemsSourceTypeProperty;

	public static readonly DependencyProperty NewItemTypesProperty;

	public static readonly DependencyProperty SelectedItemProperty;

	public static readonly RoutedEvent ItemDeletingEvent;

	public static readonly RoutedEvent ItemDeletedEvent;

	public static readonly RoutedEvent ItemAddingEvent;

	public static readonly RoutedEvent ItemAddedEvent;

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

	public ObservableCollection<object> Items
	{
		get
		{
			return (ObservableCollection<object>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public IList ItemsSource
	{
		get
		{
			return (IList)((DependencyObject)this).GetValue(ItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceProperty, (object)value);
		}
	}

	public Type ItemsSourceType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ItemsSourceTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceTypeProperty, (object)value);
		}
	}

	public IList<Type> NewItemTypes
	{
		get
		{
			return (IList<Type>)((DependencyObject)this).GetValue(NewItemTypesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewItemTypesProperty, (object)value);
		}
	}

	public object SelectedItem
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemProperty, value);
		}
	}

	public event ItemDeletingRoutedEventHandler ItemDeleting
	{
		add
		{
			((UIElement)this).AddHandler(ItemDeletingEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ItemDeletingEvent, (Delegate)value);
		}
	}

	public event ItemDeletedRoutedEventHandler ItemDeleted
	{
		add
		{
			((UIElement)this).AddHandler(ItemDeletedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ItemDeletedEvent, (Delegate)value);
		}
	}

	public event ItemAddingRoutedEventHandler ItemAdding
	{
		add
		{
			((UIElement)this).AddHandler(ItemAddingEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ItemAddingEvent, (Delegate)value);
		}
	}

	public event ItemAddedRoutedEventHandler ItemAdded
	{
		add
		{
			((UIElement)this).AddHandler(ItemAddedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ItemAddedEvent, (Delegate)value);
		}
	}

	private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CollectionControl)(object)d)?.OnItemSourceChanged((IList)e.OldValue, (IList)e.NewValue);
	}

	public void OnItemSourceChanged(IList oldValue, IList newValue)
	{
		if (newValue == null)
		{
			return;
		}
		foreach (object item in newValue)
		{
			Items.Add(CreateClone(item));
		}
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_newItemTypesComboBox != null)
		{
			((FrameworkElement)_newItemTypesComboBox).Loaded -= NewItemTypesComboBox_Loaded;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_NewItemTypesComboBox");
		_newItemTypesComboBox = (ComboBox)(object)((templateChild is ComboBox) ? templateChild : null);
		if (_newItemTypesComboBox != null)
		{
			((FrameworkElement)_newItemTypesComboBox).Loaded += NewItemTypesComboBox_Loaded;
		}
	}

	static CollectionControl()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected Obj, but got Unknown
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((object)false));
		ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<object>), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IList), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnItemsSourceChanged));
		ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(CollectionControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		ItemDeletingEvent = EventManager.RegisterRoutedEvent("ItemDeleting", (RoutingStrategy)1, typeof(ItemDeletingRoutedEventHandler), typeof(CollectionControl));
		ItemDeletedEvent = EventManager.RegisterRoutedEvent("ItemDeleted", (RoutingStrategy)1, typeof(ItemDeletedRoutedEventHandler), typeof(CollectionControl));
		ItemAddingEvent = EventManager.RegisterRoutedEvent("ItemAdding", (RoutingStrategy)1, typeof(ItemAddingRoutedEventHandler), typeof(CollectionControl));
		ItemAddedEvent = EventManager.RegisterRoutedEvent("ItemAdded", (RoutingStrategy)1, typeof(ItemAddedRoutedEventHandler), typeof(CollectionControl));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionControl), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(CollectionControl)));
	}

	public CollectionControl()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0039: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0067: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_0095: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		Items = new ObservableCollection<object>();
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.New, (ExecutedRoutedEventHandler)AddNew, (CanExecuteRoutedEventHandler)CanAddNew));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ApplicationCommands.Delete, (ExecutedRoutedEventHandler)Delete, (CanExecuteRoutedEventHandler)CanDelete));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ComponentCommands.MoveDown, (ExecutedRoutedEventHandler)MoveDown, (CanExecuteRoutedEventHandler)CanMoveDown));
		((UIElement)this).CommandBindings.Add(new CommandBinding((ICommand)ComponentCommands.MoveUp, (ExecutedRoutedEventHandler)MoveUp, (CanExecuteRoutedEventHandler)CanMoveUp));
	}

	private void NewItemTypesComboBox_Loaded(object sender, RoutedEventArgs e)
	{
		if (_newItemTypesComboBox != null)
		{
			((Selector)_newItemTypesComboBox).SelectedIndex = 0;
		}
	}

	private void AddNew(object sender, ExecutedRoutedEventArgs e)
	{
		object itemAdding = CreateNewItem((Type)e.Parameter);
		ItemAddingEventArgs e2 = new ItemAddingEventArgs(ItemAddingEvent, itemAdding);
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
		if (!e2.Cancel)
		{
			itemAdding = e2.Item;
			Items.Add(itemAdding);
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new ItemEventArgs(ItemAddedEvent, itemAdding));
			SelectedItem = itemAdding;
		}
	}

	private void CanAddNew(object sender, CanExecuteRoutedEventArgs e)
	{
		Type type = e.Parameter as Type;
		if (type != null && type.GetConstructor(Type.EmptyTypes) != null && !IsReadOnly)
		{
			e.CanExecute = true;
		}
	}

	private void Delete(object sender, ExecutedRoutedEventArgs e)
	{
		ItemDeletingEventArgs e2 = new ItemDeletingEventArgs(ItemDeletingEvent, e.Parameter);
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
		if (!e2.Cancel)
		{
			Items.Remove(e.Parameter);
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new ItemEventArgs(ItemDeletedEvent, e.Parameter));
		}
	}

	private void CanDelete(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = e.Parameter != null && !IsReadOnly;
	}

	private void MoveDown(object sender, ExecutedRoutedEventArgs e)
	{
		object parameter = e.Parameter;
		int num = Items.IndexOf(parameter);
		Items.RemoveAt(num);
		Items.Insert(++num, parameter);
		SelectedItem = parameter;
	}

	private void CanMoveDown(object sender, CanExecuteRoutedEventArgs e)
	{
		if (e.Parameter != null && Items.IndexOf(e.Parameter) < Items.Count - 1 && !IsReadOnly)
		{
			e.CanExecute = true;
		}
	}

	private void MoveUp(object sender, ExecutedRoutedEventArgs e)
	{
		object parameter = e.Parameter;
		int num = Items.IndexOf(parameter);
		Items.RemoveAt(num);
		Items.Insert(--num, parameter);
		SelectedItem = parameter;
	}

	private void CanMoveUp(object sender, CanExecuteRoutedEventArgs e)
	{
		if (e.Parameter != null && Items.IndexOf(e.Parameter) > 0 && !IsReadOnly)
		{
			e.CanExecute = true;
		}
	}

	private static void CopyValues(object source, object destination)
	{
		Type type = source.GetType();
		while (type != null)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				fieldInfo.SetValue(destination, fieldInfo.GetValue(source));
			}
			type = type.BaseType;
		}
	}

	private object CreateClone(object source)
	{
		object obj = null;
		Type type = source.GetType();
		obj = Activator.CreateInstance(type);
		CopyValues(source, obj);
		return obj;
	}

	private IList CreateItemsSource()
	{
		IList result = null;
		if (ItemsSourceType != null)
		{
			ConstructorInfo constructor = ItemsSourceType.GetConstructor(Type.EmptyTypes);
			result = (IList)constructor.Invoke(null);
		}
		return result;
	}

	private object CreateNewItem(Type type)
	{
		return Activator.CreateInstance(type);
	}

	public void PersistChanges()
	{
		IList list = ComputeItemsSource();
		if (list == null)
		{
			return;
		}
		list.Clear();
		if (list.IsFixedSize)
		{
			for (int i = 0; i < Items.Count; i++)
			{
				list[i] = Items[i];
			}
			return;
		}
		foreach (object item in Items)
		{
			list.Add(item);
		}
	}

	private IList ComputeItemsSource()
	{
		if (ItemsSource == null)
		{
			ItemsSource = CreateItemsSource();
		}
		return ItemsSource;
	}
}
