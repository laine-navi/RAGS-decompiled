using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class GetNameFrm : Form
{
	private Label c300c24b05030c9258d5792c1ed7c590d;

	public TextBox txtEntry;

	private Button cfb161b7d53a34ca465d546e89559aa86;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	private Game c54f9a911545745b85ae6f74355697f8b;

	private Container c501c89bc63d55bb522eac228aeeebb18;

	public GetNameFrm(string caption, ref Game CurGame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c54f9a911545745b85ae6f74355697f8b = CurGame;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = caption;
	}

	public GetNameFrm(string caption)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = caption;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(GetNameFrm.Dispose(bool));
			}
			else
			{
				c501c89bc63d55bb522eac228aeeebb18.Dispose();
			}
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected Obj, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetNameFrm));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		txtEntry = new TextBox();
		cfb161b7d53a34ca465d546e89559aa86 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(14, 15);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(168, 16);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116912);
		((Control)txtEntry).Location = new Point(16, 39);
		((Control)txtEntry).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116959);
		((Control)txtEntry).Size = new Size(192, 20);
		((Control)txtEntry).TabIndex = 1;
		((Control)txtEntry).KeyDown += c837d278a1a27460b4197df5899388214;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Location = new Point(24, 72);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19088);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Size = new Size(75, 23);
		((Control)cfb161b7d53a34ca465d546e89559aa86).TabIndex = 2;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19099);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Click += cae5d311ccae5f42a5309e3afd77dfd28;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(128, 72);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(511);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(75, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 3;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Form)this).AcceptButton = (IButtonControl)(object)cfb161b7d53a34ca465d546e89559aa86;
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Form)this).CancelButton = (IButtonControl)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8;
		((Form)this).ClientSize = new Size(224, 110);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)cfb161b7d53a34ca465d546e89559aa86);
		((Control)this).Controls.Add((Control)(object)txtEntry);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116976);
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116997);
		((Control)this).KeyDown += c3745ac1cc1b8c47a01dc86e96dd644f1;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void cae5d311ccae5f42a5309e3afd77dfd28(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c3745ac1cc1b8c47a01dc86e96dd644f1(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyCode != 13)
		{
			__ldtoken(GetNameFrm.c3745ac1cc1b8c47a01dc86e96dd644f1(object, KeyEventArgs));
		}
		else
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private void c7205929dd03c512505953a00bd110d78(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyCode == 13)
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private void c837d278a1a27460b4197df5899388214(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyData != 262230)
		{
			__ldtoken(GetNameFrm.c837d278a1a27460b4197df5899388214(object, KeyEventArgs));
			return;
		}
		TextBox val = (TextBox)((P_0 is TextBox) ? P_0 : null);
		ComboBox val2 = (ComboBox)((P_0 is ComboBox) ? P_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = val2.SelectionStart;
		}
		string text = cf9332ce8b6f3aed7f82fc705c911e5c1();
		if (!(text != string.Empty))
		{
			__ldtoken(GetNameFrm.c837d278a1a27460b4197df5899388214(object, KeyEventArgs));
		}
		else if (val == null)
		{
			__ldtoken(GetNameFrm.c837d278a1a27460b4197df5899388214(object, KeyEventArgs));
			if (val2 == null)
			{
				__ldtoken(GetNameFrm.c837d278a1a27460b4197df5899388214(object, KeyEventArgs));
			}
			else
			{
				((Control)val2).Text = ((Control)val2).Text.Insert(startIndex, text);
			}
		}
		else
		{
			((Control)val).Text = ((Control)val).Text.Insert(((TextBoxBase)val).SelectionStart, text);
		}
	}

	private string cf9332ce8b6f3aed7f82fc705c911e5c1()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref c54f9a911545745b85ae6f74355697f8b);
		TextHandlers.PopulateVariableMenu(ref tempfrm, ref c54f9a911545745b85ae6f74355697f8b);
		if ((int)((Form)tempfrm).ShowDialog() != 1)
		{
			__ldtoken(GetNameFrm.cf9332ce8b6f3aed7f82fc705c911e5c1());
		}
		else if (tempfrm.lbSysVariables.SelectedItem == null)
		{
			__ldtoken(GetNameFrm.cf9332ce8b6f3aed7f82fc705c911e5c1());
		}
		else
		{
			result = tempfrm.lbSysVariables.SelectedItem.ToString();
		}
		return result;
	}
}
