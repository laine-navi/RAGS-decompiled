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
	private string EditData = string.Empty;

	private object TheSender;

	private Game TheGame;

	internal Menu mnuMain;

	internal MenuItem btnBold;

	internal MenuItem btnItalic;

	internal MenuItem btnUnderscore;

	internal MenuItem btnColor;

	internal MenuItem btnFont;

	internal MenuItem btnMiddle;

	internal MenuItem btnVariables;

	internal WebBrowser wbData;

	internal TextBox tbData;

	internal Button btnPreview;

	internal Button btnApply;

	internal Button btnCancel;

	internal Button btnTest;

	public string TBDATA
	{
		get
		{
			return tbData.Text;
		}
		set
		{
			tbData.Text = value;
		}
	}

	public RagsEditor(object sender, Game curgame)
	{
		InitializeComponent();
		TheGame = curgame;
		TheSender = sender;
		wbData.NavigateToString("<html> </html>");
	}

	private void btnBold_Click(object sender, RoutedEventArgs e)
	{
		int selectionStart = tbData.SelectionStart;
		int num = selectionStart + tbData.SelectionLength + 3;
		tbData.Text = tbData.Text.Insert(tbData.SelectionStart, "<b>");
		tbData.Text = tbData.Text.Insert(num, "</b>");
		tbData.SelectionStart = selectionStart;
		tbData.SelectionLength = num + 4 - selectionStart;
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (((ContentControl)btnPreview).Content == "Edit View")
		{
			tbData.Clear();
			tbData.Text = EditData.Replace("</br>", "\r\n");
			((ContentControl)btnPreview).Content = "Preview View";
			((UIElement)btnApply).IsEnabled = true;
			((UIElement)btnCancel).IsEnabled = true;
			((UIElement)mnuMain).IsEnabled = true;
			((UIElement)btnTest).IsEnabled = false;
			((TextBoxBase)tbData).IsReadOnly = false;
			((UIElement)wbData).Visibility = (Visibility)1;
			((UIElement)tbData).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)btnApply).IsEnabled = false;
			((UIElement)btnCancel).IsEnabled = false;
			((UIElement)mnuMain).IsEnabled = false;
			((UIElement)btnTest).IsEnabled = true;
			((UIElement)wbData).Visibility = (Visibility)0;
			((UIElement)tbData).Visibility = (Visibility)1;
			EditData = tbData.Text.Replace("\r\n", "</br>");
			tbData.Clear();
			wbData.NavigateToString("<html/>");
			((TextBoxBase)tbData).IsReadOnly = true;
			TheGame.TheContent.Clear();
			SaveLoad.AddTextToRTF(ref wbData, ref TheGame, EditData);
			((ContentControl)btnPreview).Content = "Edit View";
		}
	}

	private void btnItalic_Click(object sender, RoutedEventArgs e)
	{
		int selectionStart = tbData.SelectionStart;
		int num = selectionStart + tbData.SelectionLength + 3;
		tbData.Text = tbData.Text.Insert(tbData.SelectionStart, "<i>");
		tbData.Text = tbData.Text.Insert(num, "</i>");
		tbData.SelectionStart = selectionStart;
		tbData.SelectionLength = num + 4 - selectionStart;
	}

	private void btnUnderscore_Click(object sender, RoutedEventArgs e)
	{
		int selectionStart = tbData.SelectionStart;
		int num = selectionStart + tbData.SelectionLength + 3;
		tbData.Text = tbData.Text.Insert(tbData.SelectionStart, "<u>");
		tbData.Text = tbData.Text.Insert(num, "</u>");
		tbData.SelectionStart = selectionStart;
		tbData.SelectionLength = num + 4 - selectionStart;
	}

	private void btnColor_Click(object sender, RoutedEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		ColorDialog val = new ColorDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			int selectionStart = tbData.SelectionStart;
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
			int num = selectionStart + tbData.SelectionLength + text.Length;
			tbData.Text = tbData.Text.Insert(tbData.SelectionStart, text);
			tbData.Text = tbData.Text.Insert(num, "</span>");
			tbData.SelectionStart = selectionStart;
			tbData.SelectionLength = num + 7 - selectionStart;
		}
	}

	private void btnFont_Click(object sender, RoutedEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		FontDialog val = new FontDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			int selectionStart = tbData.SelectionStart;
			string text = "<span style=\"font-family:" + val.Font.Name + ";font size:" + val.Font.Size + "\">";
			int num = selectionStart + tbData.SelectionLength + text.Length;
			tbData.Text = tbData.Text.Insert(tbData.SelectionStart, text);
			tbData.Text = tbData.Text.Insert(num, "</span>");
			tbData.SelectionStart = selectionStart;
			tbData.SelectionLength = num + 7 - selectionStart;
		}
	}

	private void btnMiddle_Click(object sender, RoutedEventArgs e)
	{
		int selectionStart = tbData.SelectionStart;
		int num = selectionStart + tbData.SelectionLength + 3;
		tbData.Text = tbData.Text.Insert(tbData.SelectionStart, "<center>");
		tbData.Text = tbData.Text.Insert(num, "</center>");
		tbData.SelectionStart = selectionStart;
		tbData.SelectionLength = num + 9 - selectionStart;
	}

	private void btnVariables_Click(object sender, RoutedEventArgs e)
	{
	}

	private void btnApply_Click(object sender, RoutedEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (TheSender is TextBox)
		{
			((TextBox)TheSender).Text = tbData.Text;
			((Window)this).Close();
		}
		else if (TheSender is ComboBox)
		{
			((ComboBox)TheSender).Text = tbData.Text;
			((Window)this).Close();
		}
	}

	private void tbData_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.SystemKey != 65 || (!Keyboard.IsKeyDown((Key)120) && !Keyboard.IsKeyDown((Key)121)))
		{
			return;
		}
		((RoutedEventArgs)e).Handled = true;
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		ComboBox val2 = (ComboBox)((sender is ComboBox) ? sender : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = 0;
		}
		if (val != null)
		{
			startIndex = val.SelectionStart;
		}
		InsertVariableWindow insertVariableWindow = new InsertVariableWindow(ref TheGame);
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

	private void btnTest_Click(object sender, RoutedEventArgs e)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		string sStringToEvaluate = TheGame.TheContent.ToString().Replace("</br>", "").Replace("<br/>", "");
		SaveLoad.EvaluateString(ref result, sStringToEvaluate);
		MessageBox.Show(result.ToString(), "Evaluation Results");
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
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
			mnuMain = (Menu)target;
			break;
		case 2:
			btnBold = (MenuItem)target;
			btnBold.Click += btnBold_Click;
			break;
		case 3:
			btnItalic = (MenuItem)target;
			btnItalic.Click += btnItalic_Click;
			break;
		case 4:
			btnUnderscore = (MenuItem)target;
			btnUnderscore.Click += btnUnderscore_Click;
			break;
		case 5:
			btnColor = (MenuItem)target;
			btnColor.Click += btnColor_Click;
			break;
		case 6:
			btnFont = (MenuItem)target;
			btnFont.Click += btnFont_Click;
			break;
		case 7:
			btnMiddle = (MenuItem)target;
			btnMiddle.Click += btnMiddle_Click;
			break;
		case 8:
			btnVariables = (MenuItem)target;
			btnVariables.Click += btnVariables_Click;
			break;
		case 9:
			wbData = (WebBrowser)target;
			break;
		case 10:
			tbData = (TextBox)target;
			((UIElement)tbData).KeyDown += tbData_KeyDown;
			break;
		case 11:
			btnPreview = (Button)target;
			((ButtonBase)btnPreview).Click += Button_Click;
			break;
		case 12:
			btnApply = (Button)target;
			((ButtonBase)btnApply).Click += btnApply_Click;
			break;
		case 13:
			btnCancel = (Button)target;
			break;
		case 14:
			btnTest = (Button)target;
			((ButtonBase)btnTest).Click += btnTest_Click;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
