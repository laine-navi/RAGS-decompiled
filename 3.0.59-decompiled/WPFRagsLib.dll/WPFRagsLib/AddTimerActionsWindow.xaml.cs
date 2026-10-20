using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsLib;

public partial class AddTimerActionsWindow : Window, IComponentConnector
{
	private int length;

	internal ListBox lbTimerActions;

	public AddTimerActionsWindow(int l)
	{
		InitializeComponent();
		length = l;
	}

	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		for (int i = 0; i < length; i++)
		{
			((ItemsControl)lbTimerActions).Items.Add((object)("<<On Turn " + (i + 1) + ">>"));
		}
		((ItemsControl)lbTimerActions).Items.Add((object)"<<On Last Turn>>");
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		((Window)this).DialogResult = true;
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		((Window)this).DialogResult = false;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(AddTimerActionsWindow)target).Loaded += Window_Loaded;
			break;
		case 2:
			lbTimerActions = (ListBox)target;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += Button_Click;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += Button_Click_1;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
