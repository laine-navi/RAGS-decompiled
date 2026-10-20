using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class GetGenderFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private GroupBox ca80957da81788ac8a6f393ba3899a63f;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	public RadioButton radioButton1;

	public RadioButton radioButton2;

	public RadioButton radioButton3;

	public GetGenderFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(GetGenderFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(GetGenderFrm.Dispose(bool));
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
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetGenderFrm));
		ca80957da81788ac8a6f393ba3899a63f = new GroupBox();
		radioButton1 = new RadioButton();
		radioButton2 = new RadioButton();
		radioButton3 = new RadioButton();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		((Control)ca80957da81788ac8a6f393ba3899a63f).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton1);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton2);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton3);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Location = new Point(12, 12);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1720);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Size = new Size(208, 100);
		((Control)ca80957da81788ac8a6f393ba3899a63f).TabIndex = 1;
		ca80957da81788ac8a6f393ba3899a63f.TabStop = false;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1739);
		((Control)radioButton1).AutoSize = true;
		((Control)radioButton1).Location = new Point(75, 25);
		((Control)radioButton1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1776);
		((Control)radioButton1).Size = new Size(48, 17);
		((Control)radioButton1).TabIndex = 3;
		radioButton1.TabStop = true;
		((Control)radioButton1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1801);
		((ButtonBase)radioButton1).UseVisualStyleBackColor = true;
		((Control)radioButton2).AutoSize = true;
		((Control)radioButton2).Location = new Point(75, 48);
		((Control)radioButton2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1810);
		((Control)radioButton2).Size = new Size(59, 17);
		((Control)radioButton2).TabIndex = 4;
		radioButton2.TabStop = true;
		((Control)radioButton2).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1835);
		((ButtonBase)radioButton2).UseVisualStyleBackColor = true;
		((Control)radioButton3).AutoSize = true;
		((Control)radioButton3).Location = new Point(75, 71);
		((Control)radioButton3).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1848);
		((Control)radioButton3).Size = new Size(51, 17);
		((Control)radioButton3).TabIndex = 5;
		radioButton3.TabStop = true;
		((Control)radioButton3).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1873);
		((ButtonBase)radioButton3).UseVisualStyleBackColor = true;
		c79769badd3b3f4571a08b51317e02dcc.DialogResult = (DialogResult)1;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(79, 123);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1884);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 2;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1899);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)c79769badd3b3f4571a08b51317e02dcc;
		((Form)this).ClientSize = new Size(232, 164);
		((Control)this).Controls.Add((Control)(object)ca80957da81788ac8a6f393ba3899a63f);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1908);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1933);
		((Control)ca80957da81788ac8a6f393ba3899a63f).ResumeLayout(false);
		((Control)ca80957da81788ac8a6f393ba3899a63f).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
