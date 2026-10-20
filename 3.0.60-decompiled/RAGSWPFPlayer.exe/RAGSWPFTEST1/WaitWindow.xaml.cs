using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace RAGSWPFTEST1;

public partial class WaitWindow : Window, IComponentConnector
{
	internal ProgressBar a;

	private bool b;

	public WaitWindow()
	{
		InitializeComponent();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		if (connectionId == 1)
		{
			a = (ProgressBar)target;
		}
		else
		{
			b = true;
		}
	}
}
