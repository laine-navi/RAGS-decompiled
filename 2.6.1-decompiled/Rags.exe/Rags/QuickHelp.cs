using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class QuickHelp : Form
{
	private IContainer m_a;

	private PictureBox b;

	private Label c;

	public QuickHelp()
	{
		a();
	}

	private void a(object A_0, EventArgs A_1)
	{
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
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickHelp));
		b = new PictureBox();
		c = new Label();
		((ISupportInitialize)b).BeginInit();
		((Control)this).SuspendLayout();
		b.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		((Control)b).Location = new Point(12, 116);
		((Control)b).Name = "pictureBox1";
		((Control)b).Size = new Size(724, 537);
		b.TabIndex = 0;
		b.TabStop = false;
		((Control)c).Location = new Point(12, 33);
		((Control)c).Name = "label1";
		((Control)c).Size = new Size(724, 80);
		((Control)c).TabIndex = 1;
		((Control)c).Text = componentResourceManager.GetString("label1.Text");
		((Control)c).Click += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(746, 665);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "QuickHelp";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "RAGS Player Quick Help";
		((ISupportInitialize)b).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
