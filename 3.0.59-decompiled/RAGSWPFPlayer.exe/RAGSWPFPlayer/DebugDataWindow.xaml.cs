using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Rags;

namespace RAGSWPFPlayer;

public partial class DebugDataWindow : Window, IComponentConnector
{
	private Game m_a;

	internal ListBox b;

	internal ListView c;

	internal ListView d;

	private bool e;

	public DebugDataWindow(ref Game tg)
	{
		InitializeComponent();
		this.m_a = tg;
	}

	public void Window_Loaded(object sender, RoutedEventArgs e)
	{
		((ItemsControl)c).ItemsSource = null;
		new List<VariableData>();
		((ItemsControl)c).ItemsSource = this.m_a.VariableList;
		RefreshVars();
	}

	public void RefreshVars()
	{
		try
		{
			((CollectionView)((ItemsControl)c).Items).Refresh();
		}
		catch
		{
		}
	}

	private void a()
	{
	}

	public void AddExecutionData(string str, bool bBold)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		Label val = new Label();
		((ContentControl)val).Content = str;
		if (bBold)
		{
			((Control)val).FontWeight = FontWeights.Bold;
			((Control)val).Background = (Brush)new SolidColorBrush(Colors.Yellow);
		}
		((ItemsControl)b).Items.Add((object)val);
		b.ScrollIntoView((object)val);
	}

	public void AddErrorData(string str)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		Label val = new Label();
		((ContentControl)val).Content = str;
		((Control)val).FontWeight = FontWeights.Bold;
		((Control)val).Background = (Brush)new SolidColorBrush(Colors.Red);
		((ItemsControl)b).Items.Add((object)val);
		b.ScrollIntoView((object)val);
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		DebugNewValWindow debugNewValWindow = new DebugNewValWindow();
		GameVariable gameVariable = null;
		gameVariable = ((Selector)c).SelectedItem as GameVariable;
		if (gameVariable != null)
		{
			((ContentControl)debugNewValWindow.a).Content = gameVariable.DisplayName;
			debugNewValWindow.b.Text = gameVariable.DisplayValue;
		}
		if (((Window)debugNewValWindow).ShowDialog() == true)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				gameVariable.dtDateTime = Convert.ToDateTime(debugNewValWindow.b.Text);
				break;
			case GameVariable.VarType.VT_NUMBER:
				gameVariable.dNumType = Convert.ToDouble(debugNewValWindow.b.Text);
				break;
			case GameVariable.VarType.VT_STRING:
				gameVariable.sString = debugNewValWindow.b.Text;
				break;
			}
			RefreshVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate a(Type A_0, string A_1)
	{
		return Delegate.CreateDelegate(A_0, this, A_1);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(DebugDataWindow)target).Loaded += Window_Loaded;
			break;
		case 2:
			b = (ListBox)target;
			break;
		case 3:
			c = (ListView)target;
			((Control)c).MouseDoubleClick += a;
			break;
		case 4:
			d = (ListView)target;
			break;
		default:
			e = true;
			break;
		}
	}
}
