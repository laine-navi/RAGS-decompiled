using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace WPFRagsDesigner;

public partial class SelectCultureWindow : Window, IComponentConnector
{
	private CultureInfo m_a;

	internal ListBox b;

	private bool m_c;

	[CompilerGenerated]
	private static Comparison<CultureInfo> d;

	public SelectCultureWindow(CultureInfo currcult)
	{
		InitializeComponent();
		this.m_a = currcult;
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		List<CultureInfo> list = new List<CultureInfo>();
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
		foreach (CultureInfo item in cultures)
		{
			list.Add(item);
		}
		list.Sort((CultureInfo cultureInfo, CultureInfo cultureInfo2) =>
		{
			if (cultureInfo.DisplayName == null && cultureInfo2.DisplayName == null)
			{
				return 0;
			}
			if (cultureInfo.DisplayName == null)
			{
				return -1;
			}
			return (cultureInfo2.DisplayName == null) ? 1 : cultureInfo.DisplayName.CompareTo(cultureInfo2.DisplayName);
		});
		foreach (CultureInfo item2 in list)
		{
			int selectedIndex = ((ItemsControl)this.b).Items.Add((object)new CultureData(item2));
			if (item2.Name == this.m_a.Name)
			{
				((Selector)this.b).SelectedIndex = selectedIndex;
			}
		}
		this.b.ScrollIntoView(((Selector)this.b).SelectedItem);
		((UIElement)this.b).Focus();
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
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(SelectCultureWindow)target).Loaded += c;
			break;
		case 2:
			this.b = (ListBox)target;
			break;
		case 3:
			((ButtonBase)(Button)target).Click += b;
			break;
		case 4:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			this.m_c = true;
			break;
		}
	}

	[CompilerGenerated]
	private static int a(CultureInfo A_0, CultureInfo A_1)
	{
		if (A_0.DisplayName == null && A_1.DisplayName == null)
		{
			return 0;
		}
		if (A_0.DisplayName == null)
		{
			return -1;
		}
		if (A_1.DisplayName == null)
		{
			return 1;
		}
		return A_0.DisplayName.CompareTo(A_1.DisplayName);
	}
}
