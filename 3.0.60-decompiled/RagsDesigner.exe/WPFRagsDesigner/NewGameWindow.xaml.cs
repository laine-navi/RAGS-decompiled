using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsDesigner;

public partial class NewGameWindow : Window, IComponentConnector
{
	internal RadioButton a;

	internal RadioButton b;

	internal CheckBox c;

	private bool d;

	public NewGameWindow()
	{
		InitializeComponent();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (RadioButton)target;
			break;
		case 2:
			this.b = (RadioButton)target;
			break;
		case 3:
			c = (CheckBox)target;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += a;
			break;
		case 5:
			((ButtonBase)(Button)target).Click += b;
			break;
		default:
			d = true;
			break;
		}
	}
}
