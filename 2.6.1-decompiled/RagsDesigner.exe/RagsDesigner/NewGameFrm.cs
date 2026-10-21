using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RagsDesigner;

public class NewGameFrm : Form
{
	private IContainer m_a;

	private GroupBox m_b;

	private Button c;

	private Button d;

	public RadioButton radioButton3;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public CheckBox checkBox1;

	public NewGameFrm()
	{
		a();
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_a != null)
		{
			this.m_a.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NewGameFrm));
		this.m_b = new GroupBox();
		radioButton3 = new RadioButton();
		radioButton2 = new RadioButton();
		radioButton1 = new RadioButton();
		c = new Button();
		d = new Button();
		checkBox1 = new CheckBox();
		((Control)this.m_b).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)this.m_b).Controls.Add((Control)(object)radioButton3);
		((Control)this.m_b).Controls.Add((Control)(object)radioButton2);
		((Control)this.m_b).Controls.Add((Control)(object)radioButton1);
		((Control)this.m_b).Location = new Point(3, 4);
		((Control)this.m_b).Name = "groupBox1";
		((Control)this.m_b).Size = new Size(287, 212);
		((Control)this.m_b).TabIndex = 0;
		this.m_b.TabStop = false;
		((Control)this.m_b).Text = "New Game Type";
		((Control)radioButton3).AutoSize = true;
		((Control)radioButton3).Location = new Point(9, 103);
		((Control)radioButton3).Name = "radioButton3";
		((Control)radioButton3).Size = new Size(153, 17);
		((Control)radioButton3).TabIndex = 2;
		((Control)radioButton3).Text = "Slightly Larger Demo Game";
		((ButtonBase)radioButton3).UseVisualStyleBackColor = true;
		((Control)radioButton2).AutoSize = true;
		((Control)radioButton2).Location = new Point(9, 66);
		((Control)radioButton2).Name = "radioButton2";
		((Control)radioButton2).Size = new Size(142, 17);
		((Control)radioButton2).TabIndex = 1;
		((Control)radioButton2).Text = "Simple Two Room Game";
		((ButtonBase)radioButton2).UseVisualStyleBackColor = true;
		((Control)radioButton1).AutoSize = true;
		radioButton1.Checked = true;
		((Control)radioButton1).Location = new Point(9, 29);
		((Control)radioButton1).Name = "radioButton1";
		((Control)radioButton1).Size = new Size(83, 17);
		((Control)radioButton1).TabIndex = 0;
		radioButton1.TabStop = true;
		((Control)radioButton1).Text = "Blank Game";
		((ButtonBase)radioButton1).UseVisualStyleBackColor = true;
		((Control)c).Location = new Point(84, 223);
		((Control)c).Name = "btnCreate";
		((Control)c).Size = new Size(83, 26);
		((Control)c).TabIndex = 1;
		((Control)c).Text = "Create Game";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Control)c).Click += b;
		d.DialogResult = (DialogResult)2;
		((Control)d).Location = new Point(200, 223);
		((Control)d).Name = "btnCancel";
		((Control)d).Size = new Size(83, 26);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Cancel";
		((ButtonBase)d).UseVisualStyleBackColor = true;
		((Control)d).Click += a;
		((Control)checkBox1).Location = new Point(3, 219);
		((Control)checkBox1).Name = "checkBox1";
		((Control)checkBox1).Size = new Size(75, 36);
		((Control)checkBox1).TabIndex = 3;
		((Control)checkBox1).Text = "Display At Startup";
		((ButtonBase)checkBox1).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)c;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)d;
		((Form)this).ClientSize = new Size(292, 260);
		((Control)this).Controls.Add((Control)(object)checkBox1);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "NewGameFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Create A New Game";
		((Control)this.m_b).ResumeLayout(false);
		((Control)this.m_b).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
