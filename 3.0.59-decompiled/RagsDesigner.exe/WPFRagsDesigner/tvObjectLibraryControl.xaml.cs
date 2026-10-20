using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WPFRagsDesigner;

public partial class tvObjectLibraryControl : UserControl, IComponentConnector
{
	internal tvObjectLibraryControl UserControl;

	internal Grid LayoutRoot;

	public tvObjectLibraryControl()
	{
		InitializeComponent();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			UserControl = (tvObjectLibraryControl)target;
			break;
		case 2:
			LayoutRoot = (Grid)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
