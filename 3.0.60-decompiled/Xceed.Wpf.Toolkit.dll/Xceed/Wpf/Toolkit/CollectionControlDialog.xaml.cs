using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Xceed.Wpf.Toolkit;

public partial class CollectionControlDialog : Window, IComponentConnector
{
	public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IList), typeof(CollectionControlDialog), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControlDialog), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControlDialog), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControlDialog), (PropertyMetadata)new UIPropertyMetadata((object)false));

	internal CollectionControl _propertyGrid;

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

	public CollectionControlDialog()
	{
		InitializeComponent();
	}

	public CollectionControlDialog(Type itemsourceType)
		: this()
	{
		ItemsSourceType = itemsourceType;
	}

	public CollectionControlDialog(Type itemsourceType, IList<Type> newItemTypes)
		: this(itemsourceType)
	{
		NewItemTypes = newItemTypes;
	}

	private void OkButton_Click(object sender, RoutedEventArgs e)
	{
		_propertyGrid.PersistChanges();
		((Window)this).Close();
	}

	private void CancelButton_Click(object sender, RoutedEventArgs e)
	{
		((Window)this).Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			_propertyGrid = (CollectionControl)target;
			break;
		case 2:
			((ButtonBase)(Button)target).Click += OkButton_Click;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += CancelButton_Click;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	static CollectionControlDialog()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
	}
}
