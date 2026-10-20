using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Polenter.Serialization;
using Rags;
using WPFRagsLib;

namespace WPFRagsDesigner;

public partial class QuickMenuItemWindow : Window, IComponentConnector
{
	private List<QuickMenuItem> m_a;

	private Game m_b;

	internal Grid c;

	internal ListBox d;

	internal Button e;

	internal Button f;

	internal Button g;

	internal TextBox h;

	internal CheckBox i;

	internal CheckBox j;

	internal CheckBox k;

	internal CheckBox l;

	internal GroupBox m;

	internal CheckBox n;

	internal CheckBox o;

	internal CheckBox p;

	internal CheckBox q;

	internal CheckBox r;

	internal CheckBox s;

	internal CheckBox t;

	internal CheckBox u;

	private bool v;

	public QuickMenuItemWindow(ref List<QuickMenuItem> commands, ref Game gameobj)
	{
		InitializeComponent();
		this.m_a = commands;
		this.m_b = gameobj;
		a();
	}

	private void a()
	{
		((ItemsControl)this.d).Items.Clear();
		for (int i = 0; i < this.m_a.Count; i++)
		{
			QuickMenuItem quickMenuItem = this.m_a[i];
			((ItemsControl)this.d).Items.Add((object)quickMenuItem);
		}
		if (((CollectionView)((ItemsControl)this.d).Items).Count > 0)
		{
			((Selector)this.d).SelectedIndex = 0;
		}
	}

	private void r(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		if ((int)MessageBox.Show("This will overwrite your current quick commands.  Are you sure you want to proceed?", "Proceed", (MessageBoxButton)4) != 6)
		{
			return;
		}
		SaveLoad.RestoreDefaults(ref this.m_a);
		FileStream fileStream = null;
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string path = Path.Combine(text, "WPFQuickCommands.bin");
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			fileStream = new FileStream(path, FileMode.Create);
			sharpSerializer.Serialize(this.m_a, fileStream);
		}
		finally
		{
			fileStream.Flush();
			fileStream.Close();
			fileStream.Dispose();
		}
		a();
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.d).SelectedItem != null)
		{
			QuickMenuItem quickMenuItem = (QuickMenuItem)((Selector)this.d).SelectedItem;
			this.h.Text = quickMenuItem.Name;
			if (quickMenuItem.bCarryable)
			{
				((ToggleButton)this.n).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.n).IsChecked = false;
			}
			if (quickMenuItem.bCharacters)
			{
				((ToggleButton)this.l).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.l).IsChecked = false;
			}
			if (quickMenuItem.bContainer)
			{
				((ToggleButton)this.p).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.p).IsChecked = false;
			}
			if (quickMenuItem.bEnterable)
			{
				((ToggleButton)s).IsChecked = true;
			}
			else
			{
				((ToggleButton)s).IsChecked = false;
			}
			if (quickMenuItem.bLockable)
			{
				((ToggleButton)this.r).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.r).IsChecked = false;
			}
			if (quickMenuItem.bObjects)
			{
				((ToggleButton)this.k).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.k).IsChecked = false;
			}
			if (quickMenuItem.bOpenable)
			{
				((ToggleButton)this.q).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.q).IsChecked = false;
			}
			if (quickMenuItem.bPlayer)
			{
				((ToggleButton)this.j).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.j).IsChecked = false;
			}
			if (quickMenuItem.bReadable)
			{
				((ToggleButton)t).IsChecked = true;
			}
			else
			{
				((ToggleButton)t).IsChecked = false;
			}
			if (quickMenuItem.bRooms)
			{
				((ToggleButton)this.i).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.i).IsChecked = false;
			}
			if (quickMenuItem.bWearable)
			{
				((ToggleButton)this.o).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.o).IsChecked = false;
			}
			if (quickMenuItem.bOverwrite)
			{
				((ToggleButton)u).IsChecked = true;
			}
			else
			{
				((ToggleButton)u).IsChecked = false;
			}
		}
	}

	private void q(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	private void p(object A_0, RoutedEventArgs A_1)
	{
		if (((ToggleButton)this.k).IsChecked == true)
		{
			((UIElement)this.m).IsEnabled = true;
		}
		else
		{
			((UIElement)this.m).IsEnabled = false;
		}
		((QuickMenuItem)((Selector)this.d).SelectedItem).bObjects = ((ToggleButton)this.k).IsChecked.Value;
	}

	private void o(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bRooms = ((ToggleButton)this.i).IsChecked.Value;
	}

	private void n(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bPlayer = ((ToggleButton)this.j).IsChecked.Value;
	}

	private void m(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bCharacters = ((ToggleButton)this.l).IsChecked.Value;
	}

	private void l(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bCarryable = ((ToggleButton)this.n).IsChecked.Value;
	}

	private void k(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bWearable = ((ToggleButton)this.o).IsChecked.Value;
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bContainer = ((ToggleButton)this.p).IsChecked.Value;
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bOpenable = ((ToggleButton)this.q).IsChecked.Value;
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bLockable = ((ToggleButton)this.r).IsChecked.Value;
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bEnterable = ((ToggleButton)s).IsChecked.Value;
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		((QuickMenuItem)((Selector)this.d).SelectedItem).bReadable = ((ToggleButton)t).IsChecked.Value;
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)((Selector)this.d).SelectedItem;
		if (quickMenuItem != null)
		{
			QuickCommandEditWindow quickCommandEditWindow = new QuickCommandEditWindow();
			((ContentControl)quickCommandEditWindow.a).Content = quickMenuItem.Name;
			quickCommandEditWindow.b.SetObjectName(quickMenuItem.UniqueID.ToString());
			quickCommandEditWindow.b.SetPageType(WPFActionControl.PageType.quickcommand);
			quickCommandEditWindow.b.SetGameObject(ref this.m_b);
			quickCommandEditWindow.b.RefreshActions();
			((Window)quickCommandEditWindow).ShowDialog();
		}
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Name of new quick command:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		if (((Window)getNameWindow).ShowDialog() == true)
		{
			QuickMenuItem quickMenuItem = new QuickMenuItem();
			quickMenuItem.Name = getNameWindow.txtEntry.Text;
			this.m_b.QuickCommands.Add(quickMenuItem);
			a();
		}
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)((Selector)this.d).SelectedItem;
		if (quickMenuItem != null)
		{
			quickMenuItem.Name = this.h.Text;
		}
		a();
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)((Selector)this.d).SelectedItem;
		if (quickMenuItem != null)
		{
			quickMenuItem.bOverwrite = ((ToggleButton)u).IsChecked.Value;
		}
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)((Selector)this.d).SelectedItem;
		if (quickMenuItem != null)
		{
			QuickCommandEditWindow quickCommandEditWindow = new QuickCommandEditWindow();
			((ContentControl)quickCommandEditWindow.a).Content = quickMenuItem.Name;
			quickCommandEditWindow.b.SetObjectName(quickMenuItem.UniqueID.ToString());
			quickCommandEditWindow.b.SetPageType(WPFActionControl.PageType.quickcommand);
			quickCommandEditWindow.b.SetGameObject(ref this.m_b);
			quickCommandEditWindow.b.RefreshActions();
			((Window)quickCommandEditWindow).ShowDialog();
		}
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.d).SelectedItem != null)
		{
			this.m_b.QuickCommands.Remove(((Selector)this.d).SelectedItem as QuickMenuItem);
			a();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected Obj, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected Obj, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected Obj, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected Obj, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected Obj, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected Obj, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected Obj, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected Obj, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected Obj, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected Obj, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected Obj, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected Obj, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected Obj, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.c = (Grid)target;
			break;
		case 2:
			this.d = (ListBox)target;
			((Selector)this.d).SelectionChanged += a;
			((Control)this.d).MouseDoubleClick += a;
			break;
		case 3:
			this.e = (Button)target;
			((ButtonBase)this.e).Click += e;
			break;
		case 4:
			this.f = (Button)target;
			((ButtonBase)this.f).Click += b;
			break;
		case 5:
			this.g = (Button)target;
			((ButtonBase)this.g).Click += a;
			break;
		case 6:
			this.h = (TextBox)target;
			((UIElement)this.h).LostFocus += d;
			break;
		case 7:
			this.i = (CheckBox)target;
			((ButtonBase)this.i).Click += o;
			break;
		case 8:
			this.j = (CheckBox)target;
			((ButtonBase)this.j).Click += n;
			break;
		case 9:
			this.k = (CheckBox)target;
			((ButtonBase)this.k).Click += p;
			break;
		case 10:
			this.l = (CheckBox)target;
			((ButtonBase)this.l).Click += m;
			break;
		case 11:
			this.m = (GroupBox)target;
			break;
		case 12:
			this.n = (CheckBox)target;
			((ButtonBase)this.n).Click += l;
			break;
		case 13:
			this.o = (CheckBox)target;
			((ButtonBase)this.o).Click += k;
			break;
		case 14:
			this.p = (CheckBox)target;
			((ButtonBase)this.p).Click += j;
			break;
		case 15:
			this.q = (CheckBox)target;
			((ButtonBase)this.q).Click += i;
			break;
		case 16:
			this.r = (CheckBox)target;
			((ButtonBase)this.r).Click += h;
			break;
		case 17:
			s = (CheckBox)target;
			((ButtonBase)s).Click += g;
			break;
		case 18:
			t = (CheckBox)target;
			((ButtonBase)t).Click += f;
			break;
		case 19:
			u = (CheckBox)target;
			((ButtonBase)u).Click += c;
			break;
		case 20:
			((ButtonBase)(Button)target).Click += r;
			break;
		case 21:
			((ButtonBase)(Button)target).Click += q;
			break;
		default:
			v = true;
			break;
		}
	}
}
