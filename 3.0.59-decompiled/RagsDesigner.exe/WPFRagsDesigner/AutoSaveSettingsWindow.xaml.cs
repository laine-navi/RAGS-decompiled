using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using WPFRagsDesigner.Properties;

namespace WPFRagsDesigner;

public partial class AutoSaveSettingsWindow : Window, IComponentConnector
{
	internal CheckBox a;

	internal TextBox b;

	private bool c;

	public AutoSaveSettingsWindow()
	{
		InitializeComponent();
		((ToggleButton)this.a).IsChecked = Settings.Default.UseAutoSave;
		this.b.Text = Settings.Default.AutoSaveMinutes.ToString();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		Settings.Default.UseAutoSave = ((ToggleButton)this.a).IsChecked.Value;
		try
		{
			int a_ = Convert.ToInt32(this.b.Text);
			Settings.Default.AutoSaveMinutes = a_;
			((Window)this).DialogResult = true;
		}
		catch
		{
			MessageBox.Show("You must enter a valid number for the auto save minutes.");
			((UIElement)this.b).Focus();
		}
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
			this.a = (CheckBox)target;
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
