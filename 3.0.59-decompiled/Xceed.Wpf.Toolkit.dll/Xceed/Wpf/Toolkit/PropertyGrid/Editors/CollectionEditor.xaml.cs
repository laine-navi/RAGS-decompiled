using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public partial class CollectionEditor : UserControl, ITypeEditor, IComponentConnector
{
	private PropertyItem _item;

	public CollectionEditor()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		CollectionControlDialog collectionControlDialog = new CollectionControlDialog(_item.PropertyType, _item.DescriptorDefinition.NewItemTypes);
		Binding val = new Binding("Value");
		val.Source = _item;
		val.Mode = (BindingMode)(_item.IsReadOnly ? 1 : 0);
		BindingOperations.SetBinding((DependencyObject)(object)collectionControlDialog, CollectionControlDialog.ItemsSourceProperty, (BindingBase)(object)val);
		((Window)collectionControlDialog).ShowDialog();
	}

	public FrameworkElement ResolveEditor(PropertyItem propertyItem)
	{
		_item = propertyItem;
		return (FrameworkElement)(object)this;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		if (connectionId == 1)
		{
			((ButtonBase)(Button)target).Click += Button_Click;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
