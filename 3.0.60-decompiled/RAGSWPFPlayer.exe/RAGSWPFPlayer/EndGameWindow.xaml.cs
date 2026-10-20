using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace RAGSWPFPlayer;

public partial class EndGameWindow : Window, IComponentConnector
{
	public enum EndGameReturn
	{
		Reset,
		Load,
		QuickLoad,
		No
	}

	public EndGameReturn TheResult = EndGameReturn.No;

	internal Button a;

	internal Button b;

	internal Button c;

	internal Button d;

	private bool e;

	public EndGameWindow()
	{
		InitializeComponent();
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		TheResult = EndGameReturn.Reset;
		((Window)this).DialogResult = true;
		((Window)this).Close();
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		TheResult = EndGameReturn.Load;
		((Window)this).DialogResult = true;
		((Window)this).Close();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		TheResult = EndGameReturn.QuickLoad;
		((Window)this).DialogResult = true;
		((Window)this).Close();
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		TheResult = EndGameReturn.No;
		((Window)this).DialogResult = true;
		((Window)this).Close();
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (Button)target;
			((ButtonBase)this.a).Click += d;
			break;
		case 2:
			this.b = (Button)target;
			((ButtonBase)this.b).Click += c;
			break;
		case 3:
			this.c = (Button)target;
			((ButtonBase)this.c).Click += b;
			break;
		case 4:
			this.d = (Button)target;
			((ButtonBase)this.d).Click += a;
			break;
		default:
			e = true;
			break;
		}
	}
}
