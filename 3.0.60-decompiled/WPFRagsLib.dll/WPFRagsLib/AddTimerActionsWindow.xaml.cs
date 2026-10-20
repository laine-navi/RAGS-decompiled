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
	private int m_a;

	internal ListBox b;

	private bool m_c;

	public AddTimerActionsWindow(int l)
	{
		InitializeComponent();
		this.m_a = l;
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		for (int i = 0; i < this.m_a; i++)
		{
			((ItemsControl)this.b).Items.Add((object)("<<On Turn " + (i + 1) + ">>"));
		}
		((ItemsControl)this.b).Items.Add((object)"<<On Last Turn>>");
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
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
			((FrameworkElement)(AddTimerActionsWindow)target).Loaded += c;
			break;
		case 2:
			this.b = (ListBox)target;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += b;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			this.m_c = true;
			break;
		}
	}
}
