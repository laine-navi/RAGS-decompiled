using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class EndGameDialog : Form
{
	private IContainer m_a;

	private Label m_b;

	private Button m_c;

	private Button d;

	private Button e;

	public EndGameDialog()
	{
		a();
	}

	private void c(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)6;
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)5;
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)7;
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
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EndGameDialog));
		this.m_b = new Label();
		this.m_c = new Button();
		d = new Button();
		e = new Button();
		((Control)this).SuspendLayout();
		((Control)this.m_b).AutoSize = true;
		((Control)this.m_b).Location = new Point(24, 9);
		((Control)this.m_b).Name = "label1";
		((Control)this.m_b).Size = new Size(256, 13);
		((Control)this.m_b).TabIndex = 0;
		((Control)this.m_b).Text = "The game has ended.  Would you like to play again?";
		((Control)this.m_c).Location = new Point(18, 43);
		((Control)this.m_c).Name = "button1";
		((Control)this.m_c).Size = new Size(75, 23);
		((Control)this.m_c).TabIndex = 1;
		((Control)this.m_c).Text = "Restart";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += c;
		((Control)d).Location = new Point(114, 43);
		((Control)d).Name = "button2";
		((Control)d).Size = new Size(75, 23);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Load";
		((ButtonBase)d).UseVisualStyleBackColor = true;
		((Control)d).Click += b;
		((Control)e).Location = new Point(210, 43);
		((Control)e).Name = "button3";
		((Control)e).Size = new Size(75, 23);
		((Control)e).TabIndex = 3;
		((Control)e).Text = "No";
		((ButtonBase)e).UseVisualStyleBackColor = true;
		((Control)e).Click += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(302, 81);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "EndGameDialog";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Game Over";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
