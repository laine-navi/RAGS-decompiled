using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WPFRagsLib;

public partial class WaitWindow : Window, IComponentConnector
{
	internal Label lblTitle;

	internal ProgressBar sbProgress;

	public WaitWindow()
	{
		InitializeComponent();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			lblTitle = (Label)target;
			break;
		case 2:
			sbProgress = (ProgressBar)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
