using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using WPFRagsLib;

namespace WPFRagsDesigner;

public partial class QuickCommandEditWindow : Window, IComponentConnector
{
	internal Label a;

	internal WPFActionControl b;

	private bool c;

	public QuickCommandEditWindow()
	{
		InitializeComponent();
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (Label)target;
			break;
		case 2:
			b = (WPFActionControl)target;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			c = true;
			break;
		}
	}
}
