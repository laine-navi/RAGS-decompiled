using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace RAGSWPFTEST1;

public partial class GetGenderWindow : Window, IComponentConnector
{
	internal RadioButton a;

	internal RadioButton b;

	internal RadioButton c;

	private bool d;

	public GetGenderWindow()
	{
		InitializeComponent();
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
		((Window)this).Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (RadioButton)target;
			break;
		case 2:
			b = (RadioButton)target;
			break;
		case 3:
			c = (RadioButton)target;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			d = true;
			break;
		}
	}
}
