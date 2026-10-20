using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsDesigner;

public partial class GetDimensionWidthWindow : Window, IComponentConnector
{
	internal TextBox a;

	private bool m_b;

	public GetDimensionWidthWindow()
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

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.a = (TextBox)target;
			break;
		case 2:
			((ButtonBase)(Button)target).Click += a;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += b;
			break;
		default:
			this.m_b = true;
			break;
		}
	}
}
