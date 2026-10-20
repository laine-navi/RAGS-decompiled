using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using Rags;

namespace WPFRagsLib;

public partial class RagsEditor : Window, IComponentConnector
{
	private string m_a = string.Empty;

	private object m_b;

	private Game m_c;

	internal Menu d;

	internal MenuItem e;

	internal MenuItem f;

	internal MenuItem g;

	internal MenuItem h;

	internal MenuItem i;

	internal MenuItem j;

	internal MenuItem k;

	internal WebBrowser l;

	internal TextBox m;

	internal Button n;

	internal Button o;

	internal Button p;

	internal Button q;

	private bool r;

	public string TBDATA
	{
		get
		{
			return m.Text;
		}
		set
		{
			m.Text = value;
		}
	}

	public RagsEditor(object sender, Game curgame)
	{
		InitializeComponent();
		this.m_c = curgame;
		this.m_b = sender;
		l.NavigateToString("<html> </html>");
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		int selectionStart = m.SelectionStart;
		int num = selectionStart + m.SelectionLength + 3;
		m.Text = m.Text.Insert(m.SelectionStart, "<b>");
		m.Text = m.Text.Insert(num, "</b>");
		m.SelectionStart = selectionStart;
		m.SelectionLength = num + 4 - selectionStart;
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		if (((ContentControl)n).Content == "Edit View")
		{
			m.Clear();
			m.Text = this.m_a.Replace("</br>", "\r\n");
			((ContentControl)n).Content = "Preview View";
			((UIElement)o).IsEnabled = true;
			((UIElement)p).IsEnabled = true;
			((UIElement)this.d).IsEnabled = true;
			((UIElement)q).IsEnabled = false;
			((TextBoxBase)m).IsReadOnly = false;
			((UIElement)l).Visibility = (Visibility)1;
			((UIElement)m).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)o).IsEnabled = false;
			((UIElement)p).IsEnabled = false;
			((UIElement)this.d).IsEnabled = false;
			((UIElement)q).IsEnabled = true;
			((UIElement)l).Visibility = (Visibility)0;
			((UIElement)m).Visibility = (Visibility)1;
			this.m_a = m.Text.Replace("\r\n", "</br>");
			m.Clear();
			l.NavigateToString("<html/>");
			((TextBoxBase)m).IsReadOnly = true;
			this.m_c.TheContent.Clear();
			SaveLoad.AddTextToRTF(ref l, ref this.m_c, this.m_a);
			((ContentControl)n).Content = "Edit View";
		}
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		int selectionStart = m.SelectionStart;
		int num = selectionStart + m.SelectionLength + 3;
		m.Text = m.Text.Insert(m.SelectionStart, "<i>");
		m.Text = m.Text.Insert(num, "</i>");
		m.SelectionStart = selectionStart;
		m.SelectionLength = num + 4 - selectionStart;
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		int selectionStart = m.SelectionStart;
		int num = selectionStart + m.SelectionLength + 3;
		m.Text = m.Text.Insert(m.SelectionStart, "<u>");
		m.Text = m.Text.Insert(num, "</u>");
		m.SelectionStart = selectionStart;
		m.SelectionLength = num + 4 - selectionStart;
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		ColorDialog val = new ColorDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			int selectionStart = m.SelectionStart;
			string text = "<span style=\"color:";
			if (val.Color.IsNamedColor)
			{
				text = text + val.Color.Name + "\">";
			}
			else
			{
				string text2 = text;
				text = text2 + "rgb(" + val.Color.R + "," + val.Color.G + "," + val.Color.B + ")\">";
			}
			int num = selectionStart + m.SelectionLength + text.Length;
			m.Text = m.Text.Insert(m.SelectionStart, text);
			m.Text = m.Text.Insert(num, "</span>");
			m.SelectionStart = selectionStart;
			m.SelectionLength = num + 7 - selectionStart;
		}
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		FontDialog val = new FontDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			int selectionStart = m.SelectionStart;
			string text = "<span style=\"font-family:" + val.Font.Name + ";font size:" + val.Font.Size + "\">";
			int num = selectionStart + m.SelectionLength + text.Length;
			m.Text = m.Text.Insert(m.SelectionStart, text);
			m.Text = m.Text.Insert(num, "</span>");
			m.SelectionStart = selectionStart;
			m.SelectionLength = num + 7 - selectionStart;
		}
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		int selectionStart = m.SelectionStart;
		int num = selectionStart + m.SelectionLength + 3;
		m.Text = m.Text.Insert(m.SelectionStart, "<center>");
		m.Text = m.Text.Insert(num, "</center>");
		m.SelectionStart = selectionStart;
		m.SelectionLength = num + 9 - selectionStart;
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (this.m_b is TextBox)
		{
			((TextBox)this.m_b).Text = m.Text;
			((Window)this).Close();
		}
		else if (this.m_b is ComboBox)
		{
			((ComboBox)this.m_b).Text = m.Text;
			((Window)this).Close();
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.SystemKey != 65 || (!Keyboard.IsKeyDown((Key)120) && !Keyboard.IsKeyDown((Key)121)))
		{
			return;
		}
		((RoutedEventArgs)A_1).Handled = true;
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = 0;
		}
		if (val != null)
		{
			startIndex = val.SelectionStart;
		}
		InsertVariableWindow insertVariableWindow = new InsertVariableWindow(ref this.m_c);
		((Window)insertVariableWindow).Owner = (Window)(object)this;
		string text = string.Empty;
		if (((Window)insertVariableWindow).ShowDialog() == true)
		{
			switch (((Selector)insertVariableWindow.thetabctrl).SelectedIndex)
			{
			case 0:
				if (((Selector)insertVariableWindow.sysvars).SelectedItem != null)
				{
					text = ((ContentControl)(ListBoxItem)((Selector)insertVariableWindow.sysvars).SelectedItem).Content.ToString();
				}
				break;
			case 1:
				if (((Selector)insertVariableWindow.vars).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.vars).SelectedItem.ToString();
				}
				break;
			case 2:
				if (((Selector)insertVariableWindow.custprop).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.custprop).SelectedItem.ToString();
				}
				break;
			case 3:
				text = insertVariableWindow.thetext.Text;
				break;
			}
		}
		if (text != string.Empty)
		{
			if (val != null)
			{
				val.Text = val.Text.Insert(startIndex, text);
			}
			else if (val2 != null)
			{
				val2.Text = val2.Text.Insert(startIndex, text);
			}
		}
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		string sStringToEvaluate = this.m_c.TheContent.ToString().Replace("</br>", "").Replace("<br/>", "");
		SaveLoad.EvaluateString(ref result, sStringToEvaluate);
		MessageBox.Show(result.ToString(), "Evaluation Results");
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected Obj, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected Obj, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.d = (Menu)target;
			break;
		case 2:
			this.e = (MenuItem)target;
			this.e.Click += j;
			break;
		case 3:
			this.f = (MenuItem)target;
			this.f.Click += h;
			break;
		case 4:
			this.g = (MenuItem)target;
			this.g.Click += g;
			break;
		case 5:
			this.h = (MenuItem)target;
			this.h.Click += f;
			break;
		case 6:
			this.i = (MenuItem)target;
			this.i.Click += e;
			break;
		case 7:
			this.j = (MenuItem)target;
			this.j.Click += d;
			break;
		case 8:
			k = (MenuItem)target;
			k.Click += c;
			break;
		case 9:
			l = (WebBrowser)target;
			break;
		case 10:
			m = (TextBox)target;
			((UIElement)m).KeyDown += a;
			break;
		case 11:
			n = (Button)target;
			((ButtonBase)n).Click += i;
			break;
		case 12:
			o = (Button)target;
			((ButtonBase)o).Click += b;
			break;
		case 13:
			p = (Button)target;
			break;
		case 14:
			q = (Button)target;
			((ButtonBase)q).Click += a;
			break;
		default:
			r = true;
			break;
		}
	}
}
