using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsDesigner;

public partial class ExportXMLSelectionWindow : Window, IComponentConnector
{
	internal CheckBox a;

	internal CheckBox b;

	internal CheckBox c;

	internal CheckBox d;

	internal CheckBox e;

	internal CheckBox f;

	internal CheckBox g;

	internal CheckBox h;

	private bool i;

	public ExportXMLSelectionWindow()
	{
		InitializeComponent();
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (CheckBox)target;
			break;
		case 2:
			this.b = (CheckBox)target;
			break;
		case 3:
			c = (CheckBox)target;
			break;
		case 4:
			d = (CheckBox)target;
			break;
		case 5:
			e = (CheckBox)target;
			break;
		case 6:
			f = (CheckBox)target;
			break;
		case 7:
			g = (CheckBox)target;
			break;
		case 8:
			h = (CheckBox)target;
			break;
		case 9:
			((ButtonBase)(Button)target).Click += b;
			break;
		case 10:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			i = true;
			break;
		}
	}
}
