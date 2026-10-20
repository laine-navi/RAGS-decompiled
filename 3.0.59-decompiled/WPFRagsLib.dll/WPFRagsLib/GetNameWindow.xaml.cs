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
	internal Label lbTitle;

	internal TextBox txEntry;

	public Label lblTitle
	{
		get
		{
			return lbTitle;
		}
		set
		{
			lbTitle = value;
		}
	}

	public TextBox txtEntry
	{
		get
		{
			return txEntry;
		}
		set
		{
			txEntry = value;
		}
	}

	public GetNameWindow()
	{
		InitializeComponent();
		((UIElement)txtEntry).Focus();
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
			lbTitle = (Label)target;
			break;
		case 2:
			txEntry = (TextBox)target;
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
