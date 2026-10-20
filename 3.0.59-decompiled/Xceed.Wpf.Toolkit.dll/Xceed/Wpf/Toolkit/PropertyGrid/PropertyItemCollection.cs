using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyItemCollection : ReadOnlyObservableCollection<PropertyItem>
{
	internal static readonly string CategoryPropertyName;

	internal static readonly string CategoryOrderPropertyName;

	internal static readonly string PropertyOrderPropertyName;

	internal static readonly string DisplayNamePropertyName;

	private bool _preventNotification;

	internal Predicate<object> FilterPredicate
	{
		get
		{
			return GetDefaultView().Filter;
		}
		set
		{
			GetDefaultView().Filter = value;
		}
	}

	public ObservableCollection<PropertyItem> EditableCollection { get; private set; }

	static PropertyItemCollection()
	{
		PropertyItem p = null;
		CategoryPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.Category);
		CategoryOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.CategoryOrder);
		PropertyOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.PropertyOrder);
		DisplayNamePropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.DisplayName);
	}

	public PropertyItemCollection(ObservableCollection<PropertyItem> editableCollection)
		: base(editableCollection)
	{
		EditableCollection = editableCollection;
	}

	private ICollectionView GetDefaultView()
	{
		return CollectionViewSource.GetDefaultView((object)this);
	}

	public void GroupBy(string name)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		GetDefaultView().GroupDescriptions.Add((GroupDescription)new PropertyGroupDescription(name));
	}

	public void SortBy(string name, ListSortDirection sortDirection)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		((Collection<SortDescription>)(object)GetDefaultView().SortDescriptions).Add(new SortDescription(name, sortDirection));
	}

	public void Filter(string text)
	{
		Predicate<object> filter = CreateFilter(text);
		GetDefaultView().Filter = filter;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
	{
		if (!_preventNotification)
		{
			base.OnCollectionChanged(args);
		}
	}

	internal void UpdateItems(IEnumerable<PropertyItem> newItems)
	{
		if (newItems == null)
		{
			throw new ArgumentNullException("newItems");
		}
		_preventNotification = true;
		using (GetDefaultView().DeferRefresh())
		{
			EditableCollection.Clear();
			foreach (PropertyItem newItem in newItems)
			{
				EditableCollection.Add(newItem);
			}
		}
		_preventNotification = false;
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	internal void UpdateCategorization(GroupDescription groupDescription, bool isPropertyGridCategorized)
	{
		foreach (PropertyItem item in Items)
		{
			item.DescriptorDefinition.DisplayOrder = item.DescriptorDefinition.ComputeDisplayOrderInternal(isPropertyGridCategorized);
			item.PropertyOrder = item.DescriptorDefinition.DisplayOrder;
		}
		ICollectionView defaultView = GetDefaultView();
		using (defaultView.DeferRefresh())
		{
			defaultView.GroupDescriptions.Clear();
			((Collection<SortDescription>)(object)defaultView.SortDescriptions).Clear();
			if (groupDescription != null)
			{
				defaultView.GroupDescriptions.Add(groupDescription);
				SortBy(CategoryOrderPropertyName, ListSortDirection.Ascending);
				SortBy(CategoryPropertyName, ListSortDirection.Ascending);
			}
			SortBy(PropertyOrderPropertyName, ListSortDirection.Ascending);
			SortBy(DisplayNamePropertyName, ListSortDirection.Ascending);
		}
	}

	internal void RefreshView()
	{
		GetDefaultView().Refresh();
	}

	internal static Predicate<object> CreateFilter(string text)
	{
		Predicate<object> result = null;
		if (!string.IsNullOrEmpty(text))
		{
			result = (object item) =>
			{
				PropertyItem propertyItem = item as PropertyItem;
				return propertyItem.DisplayName != null && propertyItem.DisplayName.ToLower().StartsWith(text.ToLower());
			};
		}
		return result;
	}
}
