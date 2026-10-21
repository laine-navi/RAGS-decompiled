using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace RagsDesigner;

public sealed class NewGameFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private GroupBox ca80957da81788ac8a6f393ba3899a63f;

	private Button c8cf3720cdbcbf5d06e85d7000bdd8c8d;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	public RadioButton radioButton3;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public CheckBox checkBox1;

	public NewGameFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	private void c412d36ba1556e20056e6b3b3be349425(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(NewGameFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NewGameFrm));
		ca80957da81788ac8a6f393ba3899a63f = new GroupBox();
		radioButton3 = new RadioButton();
		radioButton2 = new RadioButton();
		radioButton1 = new RadioButton();
		c8cf3720cdbcbf5d06e85d7000bdd8c8d = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		checkBox1 = new CheckBox();
		((Control)ca80957da81788ac8a6f393ba3899a63f).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton3);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton2);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)radioButton1);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Location = new Point(3, 4);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(526);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Size = new Size(287, 212);
		((Control)ca80957da81788ac8a6f393ba3899a63f).TabIndex = 0;
		ca80957da81788ac8a6f393ba3899a63f.TabStop = false;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47156);
		((Control)radioButton3).AutoSize = true;
		((Control)radioButton3).Location = new Point(9, 103);
		((Control)radioButton3).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14609);
		((Control)radioButton3).Size = new Size(153, 17);
		((Control)radioButton3).TabIndex = 2;
		((Control)radioButton3).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47183);
		((ButtonBase)radioButton3).UseVisualStyleBackColor = true;
		((Control)radioButton2).AutoSize = true;
		((Control)radioButton2).Location = new Point(9, 66);
		((Control)radioButton2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14645);
		((Control)radioButton2).Size = new Size(142, 17);
		((Control)radioButton2).TabIndex = 1;
		((Control)radioButton2).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47234);
		((ButtonBase)radioButton2).UseVisualStyleBackColor = true;
		((Control)radioButton1).AutoSize = true;
		radioButton1.Checked = true;
		((Control)radioButton1).Location = new Point(9, 29);
		((Control)radioButton1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14683);
		((Control)radioButton1).Size = new Size(83, 17);
		((Control)radioButton1).TabIndex = 0;
		radioButton1.TabStop = true;
		((Control)radioButton1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47275);
		((ButtonBase)radioButton1).UseVisualStyleBackColor = true;
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).Location = new Point(84, 223);
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47296);
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).Size = new Size(83, 26);
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).TabIndex = 1;
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47315);
		((ButtonBase)c8cf3720cdbcbf5d06e85d7000bdd8c8d).UseVisualStyleBackColor = true;
		((Control)c8cf3720cdbcbf5d06e85d7000bdd8c8d).Click += c412d36ba1556e20056e6b3b3be349425;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(200, 223);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47338);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(83, 26);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Control)checkBox1).Location = new Point(3, 219);
		((Control)checkBox1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47357);
		((Control)checkBox1).Size = new Size(75, 36);
		((Control)checkBox1).TabIndex = 3;
		((Control)checkBox1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47376);
		((ButtonBase)checkBox1).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)c8cf3720cdbcbf5d06e85d7000bdd8c8d;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8;
		((Form)this).ClientSize = new Size(292, 260);
		((Control)this).Controls.Add((Control)(object)checkBox1);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)c8cf3720cdbcbf5d06e85d7000bdd8c8d);
		((Control)this).Controls.Add((Control)(object)ca80957da81788ac8a6f393ba3899a63f);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47413);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47434);
		((Control)ca80957da81788ac8a6f393ba3899a63f).ResumeLayout(false);
		((Control)ca80957da81788ac8a6f393ba3899a63f).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
