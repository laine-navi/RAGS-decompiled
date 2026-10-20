using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace RAGSWPFTEST1;

public partial class AboutWindow : Window, IComponentConnector
{
	internal TextBox a;

	private bool b;

	public AboutWindow()
	{
		InitializeComponent();
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Version version = executingAssembly.GetName().Version;
		a.Text = "Rags Game System Player\r\n                 Version:" + version.ToString() + "\r\n                 2014\r\n                 Rags Game LLC";
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
			a = (TextBox)target;
		}
		else
		{
			b = true;
		}
	}
}
