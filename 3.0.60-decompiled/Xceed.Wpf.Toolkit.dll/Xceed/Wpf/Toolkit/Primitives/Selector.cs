using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Primitives;

public class Selector : ItemsControl, IWeakEventListener
{
	private class ValueEqualityComparer : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			return string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
		}

		public int GetHashCode(string obj)
		{
			return 1;
		}
	}

	private bool _surpressItemSelectionChanged;

	private bool _ignoreSelectedItemChanged;

	private bool _ignoreSelectedValueChanged;

	private int _ignoreSelectedItemsCollectionChanged;

	private int _ignoreSelectedMemberPathValuesChanged;

	private IList _selectedItems;

	private ValueChangeHelper _selectedMemberPathValuesHelper;

	private ValueChangeHelper _valueMemberPathValuesHelper;

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(Selector), new PropertyMetadata((object)null));

	public static readonly DependencyProperty DelimiterProperty = DependencyProperty.Register("Delimiter", typeof(string), typeof(Selector), (PropertyMetadata)new UIPropertyMetadata((object)",", (PropertyChangedCallback)OnDelimiterChanged));

	public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Selector), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedItemChanged));

	public static readonly DependencyProperty SelectedItemsOverrideProperty = DependencyProperty.Register("SelectedItemsOverride", typeof(IList), typeof(Selector), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)SelectedItemsOverrideChanged));

	public static readonly DependencyProperty SelectedMemberPathProperty = DependencyProperty.Register("SelectedMemberPath", typeof(string), typeof(Selector), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnSelectedMemberPathChanged));

	public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(string), typeof(Selector), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnSelectedValueChanged));

	public static readonly DependencyProperty ValueMemberPathProperty = DependencyProperty.Register("ValueMemberPath", typeof(string), typeof(Selector), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)OnValueMemberPathChanged));

	public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("SelectedEvent", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(Selector));

	public static readonly RoutedEvent UnSelectedEvent = EventManager.RegisterRoutedEvent("UnSelectedEvent", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(Selector));

	public static readonly RoutedEvent ItemSelectionChangedEvent = EventManager.RegisterRoutedEvent("ItemSelectionChanged", (RoutingStrategy)1, typeof(ItemSelectionChangedEventHandler), typeof(Selector));

	[TypeConverter(typeof(CommandConverter))]
	public ICommand Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public string Delimiter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DelimiterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DelimiterProperty, (object)value);
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

	public IList SelectedItems
	{
		get
		{
			return _selectedItems;
		}
		private set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			INotifyCollectionChanged notifyCollectionChanged = _selectedItems as INotifyCollectionChanged;
			INotifyCollectionChanged notifyCollectionChanged2 = value as INotifyCollectionChanged;
			if (notifyCollectionChanged != null)
			{
				CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
			}
			if (notifyCollectionChanged2 != null)
			{
				CollectionChangedEventManager.AddListener(notifyCollectionChanged2, (IWeakEventListener)(object)this);
			}
			_selectedItems = value;
		}
	}

	public IList SelectedItemsOverride
	{
		get
		{
			return (IList)((DependencyObject)this).GetValue(SelectedItemsOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemsOverrideProperty, (object)value);
		}
	}

	public string SelectedMemberPath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedMemberPathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMemberPathProperty, (object)value);
		}
	}

	public string SelectedValue
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedValueProperty, (object)value);
		}
	}

	public string ValueMemberPath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ValueMemberPathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueMemberPathProperty, (object)value);
		}
	}

	protected IEnumerable ItemsCollection => (IEnumerable)(((ItemsControl)this).ItemsSource ?? ((object)((ItemsControl)this).Items) ?? ((object)new object[0]));

	public event ItemSelectionChangedEventHandler ItemSelectionChanged
	{
		add
		{
			((UIElement)this).AddHandler(ItemSelectionChangedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ItemSelectionChangedEvent, (Delegate)value);
		}
	}

	public Selector()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		RoutedEventHandler val = null;
		RoutedEventHandler val2 = null;
		((ItemsControl)this)._002Ector();
		SelectedItems = new ObservableCollection<object>();
		RoutedEvent selectedEvent = SelectedEvent;
		if (val == null)
		{
			val = (object s, RoutedEventArgs args) =>
			{
				OnItemSelectionChangedCore(args, unselected: false);
			};
		}
		((UIElement)this).AddHandler(selectedEvent, (Delegate)(object)val);
		RoutedEvent unSelectedEvent = UnSelectedEvent;
		if (val2 == null)
		{
			val2 = (object s, RoutedEventArgs args) =>
			{
				OnItemSelectionChangedCore(args, unselected: true);
			};
		}
		((UIElement)this).AddHandler(unSelectedEvent, (Delegate)(object)val2);
		_selectedMemberPathValuesHelper = new ValueChangeHelper(OnSelectedMemberPathValuesChanged);
		_valueMemberPathValuesHelper = new ValueChangeHelper(OnValueMemberPathValuesChanged);
	}

	private static void OnDelimiterChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Selector)(object)o).UpdateSelectedValue();
	}

	private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((Selector)(object)sender).OnSelectedItemChanged(args.OldValue, args.NewValue);
	}

	protected virtual void OnSelectedItemChanged(object oldValue, object newValue)
	{
		if (((FrameworkElement)this).IsInitialized && !_ignoreSelectedItemChanged)
		{
			_ignoreSelectedItemsCollectionChanged++;
			SelectedItems.Clear();
			if (newValue != null)
			{
				SelectedItems.Add(newValue);
			}
			UpdateFromSelectedItems();
			_ignoreSelectedItemsCollectionChanged--;
		}
	}

	private static void SelectedItemsOverrideChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((Selector)(object)sender).OnSelectedItemsOverrideChanged((IList)args.OldValue, (IList)args.NewValue);
	}

	protected virtual void OnSelectedItemsOverrideChanged(IList oldValue, IList newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SelectedItems = ((newValue != null) ? newValue : new ObservableCollection<object>());
			UpdateFromSelectedItems();
		}
	}

	private static void OnSelectedMemberPathChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Selector selector = (Selector)(object)o;
		selector.OnSelectedMemberPathChanged((string)e.OldValue, (string)e.NewValue);
	}

	protected virtual void OnSelectedMemberPathChanged(string oldValue, string newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			UpdateSelectedMemberPathValuesBindings();
		}
	}

	private static void OnSelectedValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Selector selector)
		{
			selector.OnSelectedValueChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnSelectedValueChanged(string oldValue, string newValue)
	{
		if (((FrameworkElement)this).IsInitialized && !_ignoreSelectedValueChanged)
		{
			UpdateFromSelectedValue();
		}
	}

	private static void OnValueMemberPathChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Selector selector = (Selector)(object)o;
		selector.OnValueMemberPathChanged((string)e.OldValue, (string)e.NewValue);
	}

	protected virtual void OnValueMemberPathChanged(string oldValue, string newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			UpdateValueMemberPathValuesBindings();
		}
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is SelectorItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new SelectorItem();
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		((ItemsControl)this).PrepareContainerForItemOverride(element, item);
		_surpressItemSelectionChanged = true;
		FrameworkElement val = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
		((DependencyObject)val).SetValue(SelectorItem.IsSelectedProperty, (object)SelectedItems.Contains(item));
		_surpressItemSelectionChanged = false;
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		((ItemsControl)this).OnItemsSourceChanged(oldValue, newValue);
		INotifyCollectionChanged notifyCollectionChanged = oldValue as INotifyCollectionChanged;
		INotifyCollectionChanged notifyCollectionChanged2 = newValue as INotifyCollectionChanged;
		if (notifyCollectionChanged != null)
		{
			CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
		}
		if (notifyCollectionChanged2 != null)
		{
			CollectionChangedEventManager.AddListener(notifyCollectionChanged2, (IWeakEventListener)(object)this);
		}
		if (((FrameworkElement)this).IsInitialized)
		{
			RemoveUnavailableSelectedItems();
			UpdateSelectedMemberPathValuesBindings();
			UpdateValueMemberPathValuesBindings();
		}
	}

	public override void EndInit()
	{
		((ItemsControl)this).EndInit();
		if (SelectedItemsOverride != null)
		{
			OnSelectedItemsOverrideChanged(null, SelectedItemsOverride);
		}
		else if (SelectedMemberPath != null)
		{
			OnSelectedMemberPathChanged(null, SelectedMemberPath);
		}
		else if (SelectedValue != null)
		{
			OnSelectedValueChanged(null, SelectedValue);
		}
		else if (SelectedItem != null)
		{
			OnSelectedItemChanged((object)null, SelectedItem);
		}
		if (ValueMemberPath != null)
		{
			OnValueMemberPathChanged(null, ValueMemberPath);
		}
	}

	protected object GetItemValue(object item)
	{
		if (!string.IsNullOrEmpty(ValueMemberPath) && item != null)
		{
			PropertyInfo property = item.GetType().GetProperty(ValueMemberPath);
			if (property != null)
			{
				return property.GetValue(item, null);
			}
		}
		return item;
	}

	protected object ResolveItemByValue(string value)
	{
		if (!string.IsNullOrEmpty(ValueMemberPath))
		{
			foreach (object item in ItemsCollection)
			{
				PropertyInfo property = item.GetType().GetProperty(ValueMemberPath);
				if (property != null)
				{
					object value2 = property.GetValue(item, null);
					if (value.Equals(value2.ToString(), StringComparison.InvariantCultureIgnoreCase))
					{
						return item;
					}
				}
			}
		}
		return value;
	}

	private bool? GetSelectedMemberPathValue(object item)
	{
		PropertyInfo selectedMemberPathProperty = GetSelectedMemberPathProperty(item);
		if (!(selectedMemberPathProperty != null))
		{
			return null;
		}
		return (bool)selectedMemberPathProperty.GetValue(item, null);
	}

	private void SetSelectedMemberPathValue(object item, bool value)
	{
		PropertyInfo selectedMemberPathProperty = GetSelectedMemberPathProperty(item);
		if (selectedMemberPathProperty != null)
		{
			selectedMemberPathProperty.SetValue(item, value, null);
		}
	}

	private PropertyInfo GetSelectedMemberPathProperty(object item)
	{
		PropertyInfo result = null;
		if (!string.IsNullOrEmpty(SelectedMemberPath) && item != null)
		{
			PropertyInfo property = item.GetType().GetProperty(SelectedMemberPath);
			if (property != null && property.PropertyType == typeof(bool))
			{
				result = property;
			}
		}
		return result;
	}

	private void OnSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_ignoreSelectedItemsCollectionChanged <= 0)
		{
			UpdateFromSelectedItems();
		}
	}

	private void OnItemSelectionChangedCore(RoutedEventArgs args, bool unselected)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		object obj = ((ItemsControl)this).ItemContainerGenerator.ItemFromContainer((DependencyObject)args.OriginalSource);
		if (obj == DependencyProperty.UnsetValue)
		{
			obj = args.OriginalSource;
		}
		if (unselected)
		{
			while (SelectedItems.Contains(obj))
			{
				SelectedItems.Remove(obj);
			}
		}
		else if (!SelectedItems.Contains(obj))
		{
			SelectedItems.Add(obj);
		}
		OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, obj, !unselected));
	}

	private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		RemoveUnavailableSelectedItems();
		UpdateSelectedMemberPathValuesBindings();
		UpdateValueMemberPathValuesBindings();
	}

	private void OnSelectedMemberPathValuesChanged()
	{
		if (_ignoreSelectedMemberPathValuesChanged <= 0)
		{
			UpdateFromSelectedMemberPathValues();
		}
	}

	private void OnValueMemberPathValuesChanged()
	{
		UpdateSelectedValue();
	}

	private void UpdateSelectedMemberPathValuesBindings()
	{
		_selectedMemberPathValuesHelper.UpdateValueSource(ItemsCollection, SelectedMemberPath);
	}

	private void UpdateValueMemberPathValuesBindings()
	{
		_valueMemberPathValuesHelper.UpdateValueSource(ItemsCollection, ValueMemberPath);
	}

	protected virtual void OnItemSelectionChanged(ItemSelectionChangedEventArgs args)
	{
		if (!_surpressItemSelectionChanged)
		{
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)args);
			if (Command != null)
			{
				Command.Execute(args.Item);
			}
		}
	}

	private void UpdateSelectedValue()
	{
		string text = string.Join(Delimiter, from object x in SelectedItems
			select GetItemValue(x));
		if (string.IsNullOrEmpty(SelectedValue) || !SelectedValue.Equals(text))
		{
			_ignoreSelectedValueChanged = true;
			SelectedValue = text;
			_ignoreSelectedValueChanged = false;
		}
	}

	private void UpdateSelectedItem()
	{
		if (!SelectedItems.Contains(SelectedItem))
		{
			_ignoreSelectedItemChanged = true;
			SelectedItem = ((SelectedItems.Count > 0) ? SelectedItems[0] : null);
			_ignoreSelectedItemChanged = false;
		}
	}

	private void UpdateFromSelectedMemberPathValues()
	{
		_ignoreSelectedItemsCollectionChanged++;
		foreach (object item in ItemsCollection)
		{
			bool? selectedMemberPathValue = GetSelectedMemberPathValue(item);
			if (!selectedMemberPathValue.HasValue)
			{
				continue;
			}
			if (selectedMemberPathValue.Value)
			{
				if (!SelectedItems.Contains(item))
				{
					SelectedItems.Add(item);
				}
			}
			else if (SelectedItems.Contains(item))
			{
				SelectedItems.Remove(item);
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateFromSelectedItems();
	}

	private void UpdateFromSelectedItems()
	{
		foreach (object item in ItemsCollection)
		{
			bool flag = SelectedItems.Contains(item);
			_ignoreSelectedMemberPathValuesChanged++;
			SetSelectedMemberPathValue(item, flag);
			_ignoreSelectedMemberPathValuesChanged--;
			if (((ItemsControl)this).ItemContainerGenerator.ContainerFromItem(item) is SelectorItem selectorItem)
			{
				selectorItem.IsSelected = flag;
			}
		}
		UpdateSelectedItem();
		UpdateSelectedValue();
	}

	private void RemoveUnavailableSelectedItems()
	{
		_ignoreSelectedItemsCollectionChanged++;
		HashSet<object> hashSet = new HashSet<object>(ItemsCollection.Cast<object>());
		for (int i = 0; i < SelectedItems.Count; i++)
		{
			if (!hashSet.Contains(SelectedItems[i]))
			{
				SelectedItems.RemoveAt(i);
				i--;
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateSelectedItem();
		UpdateSelectedValue();
	}

	private void UpdateFromSelectedValue()
	{
		_ignoreSelectedItemsCollectionChanged++;
		SelectedItems.Clear();
		if (!string.IsNullOrEmpty(SelectedValue))
		{
			List<string> source = SelectedValue.Split(new string[1] { Delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
			ValueEqualityComparer comparer = new ValueEqualityComparer();
			foreach (object item in ItemsCollection)
			{
				object itemValue = GetItemValue(item);
				if (itemValue != null && source.Contains(itemValue.ToString(), comparer))
				{
					SelectedItems.Add(item);
				}
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateFromSelectedItems();
	}

	public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
	{
		if (managerType == typeof(CollectionChangedEventManager))
		{
			if (object.ReferenceEquals(_selectedItems, sender))
			{
				OnSelectedItemsCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
				return true;
			}
			if (object.ReferenceEquals(ItemsCollection, sender))
			{
				OnItemsSourceCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
				return true;
			}
		}
		return false;
	}

	static Selector()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected Obj, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
	}
}
