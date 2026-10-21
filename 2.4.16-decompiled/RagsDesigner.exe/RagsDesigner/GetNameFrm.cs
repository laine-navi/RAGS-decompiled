using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace RagsDesigner;

public sealed class GetNameFrm : Form
{
	private Label c300c24b05030c9258d5792c1ed7c590d;

	public TextBox txtEntry;

	private Button cfb161b7d53a34ca465d546e89559aa86;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	private Container c501c89bc63d55bb522eac228aeeebb18;

	public GetNameFrm(string caption)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = caption;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(GetNameFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(GetNameFrm.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
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
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected Obj, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetNameFrm));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		txtEntry = new TextBox();
		cfb161b7d53a34ca465d546e89559aa86 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(14, 15);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(168, 16);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(28631);
		((Control)txtEntry).Location = new Point(16, 39);
		((Control)txtEntry).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74610);
		((Control)txtEntry).Size = new Size(192, 20);
		((Control)txtEntry).TabIndex = 1;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Location = new Point(24, 72);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74627);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Size = new Size(75, 23);
		((Control)cfb161b7d53a34ca465d546e89559aa86).TabIndex = 2;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(493);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Click += cae5d311ccae5f42a5309e3afd77dfd28;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(128, 72);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47338);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(75, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 3;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
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
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74638);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74659);
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
		if ((int)P_1.KeyCode == 13)
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private void c7205929dd03c512505953a00bd110d78(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyCode != 13)
		{
			__ldtoken(GetNameFrm.c7205929dd03c512505953a00bd110d78(object, KeyEventArgs));
		}
		else
		{
			((Form)this).DialogResult = (DialogResult)1;
		}
	}
}
