using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsLib;

public partial class GetNameWindow : Window, IComponentConnector
{
	internal Label a;

	internal TextBox b;

	private bool c;

	public Label lblTitle
	{
		get
		{
			return this.a;
		}
		set
		{
			this.a = value;
		}
	}

	public TextBox txtEntry
	{
		get
		{
			return this.b;
		}
		set
		{
			this.b = value;
		}
	}

	public GetNameWindow()
	{
		InitializeComponent();
		((UIElement)txtEntry).Focus();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (Label)target;
			break;
		case 2:
			this.b = (TextBox)target;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += b;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			c = true;
			break;
		}
	}
}
