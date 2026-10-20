using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class AddTimerActionsFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button cd06b5398b27d091d6962c9c9b75befc4;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	public ListBox lbTimerActions;

	private int c27e66b9141ceee17f5a90ab793d64e2d;

	public AddTimerActionsFrm(int l)
	{
		c27e66b9141ceee17f5a90ab793d64e2d = l;
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(AddTimerActionsFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(AddTimerActionsFrm.Dispose(bool));
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
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AddTimerActionsFrm));
		lbTimerActions = new ListBox();
		cd06b5398b27d091d6962c9c9b75befc4 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		((Control)this).SuspendLayout();
		((ListControl)lbTimerActions).FormattingEnabled = true;
		((Control)lbTimerActions).Location = new Point(12, 12);
		((Control)lbTimerActions).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108937);
		lbTimerActions.SelectionMode = (SelectionMode)3;
		((Control)lbTimerActions).Size = new Size(192, 173);
		((Control)lbTimerActions).TabIndex = 0;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Location = new Point(23, 191);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108966);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Size = new Size(73, 22);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).TabIndex = 1;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108979);
		((ButtonBase)cd06b5398b27d091d6962c9c9b75befc4).UseVisualStyleBackColor = true;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Click += c35f4c9b1f3471abe26d64adf521815be;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(121, 190);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(511);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(73, 22);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Form)this).AcceptButton = (IButtonControl)(object)cd06b5398b27d091d6962c9c9b75befc4;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8;
		((Form)this).ClientSize = new Size(216, 224);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)cd06b5398b27d091d6962c9c9b75befc4);
		((Control)this).Controls.Add((Control)(object)lbTimerActions);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109002);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109039);
		((Form)this).Load += c75e4ee3a53bdd03f76bbf8c5ff1044db;
		((Control)this).ResumeLayout(false);
	}

	private void c75e4ee3a53bdd03f76bbf8c5ff1044db(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < c27e66b9141ceee17f5a90ab793d64e2d; i++)
		{
			__ldtoken(AddTimerActionsFrm.c75e4ee3a53bdd03f76bbf8c5ff1044db(object, EventArgs));
			lbTimerActions.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109074) + (i + 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109095)));
		}
		lbTimerActions.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109100));
	}

	private void c35f4c9b1f3471abe26d64adf521815be(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}
}
