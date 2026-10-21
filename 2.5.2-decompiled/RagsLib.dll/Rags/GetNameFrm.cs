using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class GetNameFrm : Form
{
	private Label m_a;

	public TextBox txtEntry;

	private Button m_b;

	private Button m_c;

	private Game d;

	private Container e;

	public GetNameFrm(string caption, ref Game CurGame)
	{
		b();
		d = CurGame;
		((Control)this.m_a).Text = caption;
	}

	public GetNameFrm(string caption)
	{
		b();
		((Control)this.m_a).Text = caption;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && e != null)
		{
			e.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void b()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected Obj, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetNameFrm));
		this.m_a = new Label();
		txtEntry = new TextBox();
		this.m_b = new Button();
		this.m_c = new Button();
		((Control)this).SuspendLayout();
		((Control)this.m_a).Location = new Point(14, 15);
		((Control)this.m_a).Name = "label1";
		((Control)this.m_a).Size = new Size(168, 16);
		((Control)this.m_a).TabIndex = 0;
		((Control)this.m_a).Text = "Please Enter Room Name:";
		((Control)txtEntry).Location = new Point(16, 39);
		((Control)txtEntry).Name = "txtEntry";
		((Control)txtEntry).Size = new Size(192, 20);
		((Control)txtEntry).TabIndex = 1;
		((Control)txtEntry).KeyDown += a;
		((Control)this.m_b).Location = new Point(24, 72);
		((Control)this.m_b).Name = "btnOK";
		((Control)this.m_b).Size = new Size(75, 23);
		((Control)this.m_b).TabIndex = 2;
		((Control)this.m_b).Text = "OK";
		((Control)this.m_b).Click += b;
		this.m_c.DialogResult = (DialogResult)2;
		((Control)this.m_c).Location = new Point(128, 72);
		((Control)this.m_c).Name = "btnCancel";
		((Control)this.m_c).Size = new Size(75, 23);
		((Control)this.m_c).TabIndex = 3;
		((Control)this.m_c).Text = "Cancel";
		((Control)this.m_c).Click += a;
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_b;
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Form)this).CancelButton = (IButtonControl)(object)this.m_c;
		((Form)this).ClientSize = new Size(224, 110);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)txtEntry);
		((Control)this).Controls.Add((Control)(object)this.m_a);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "GetNameFrm";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Enter Name";
		((Control)this).KeyDown += c;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyCode == 13)
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private void b(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyCode == 13)
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = val2.SelectionStart;
		}
		string text = a();
		if (text != string.Empty)
		{
			if (val != null)
			{
				((Control)val).Text = ((Control)val).Text.Insert(((TextBoxBase)val).SelectionStart, text);
			}
			else if (val2 != null)
			{
				((Control)val2).Text = ((Control)val2).Text.Insert(startIndex, text);
			}
		}
	}

	private string a()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref d);
		TextHandlers.PopulateVariableMenu(ref tempfrm, ref d);
		if ((int)((Form)tempfrm).ShowDialog() == 1 && tempfrm.lbSysVariables.SelectedItem != null)
		{
			result = tempfrm.lbSysVariables.SelectedItem.ToString();
		}
		return result;
	}
}
