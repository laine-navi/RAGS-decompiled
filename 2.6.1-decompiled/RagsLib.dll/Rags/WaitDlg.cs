using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class WaitDlg : Form
{
	private IContainer m_a;

	public Label label1;

	public ProgressBar progressBar1;

	public WaitDlg()
	{
		a();
	}

	private void b(object A_0, EventArgs A_1)
	{
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		label1 = new Label();
		progressBar1 = new ProgressBar();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label1).Location = new Point(64, 19);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(172, 24);
		((Control)label1).TabIndex = 0;
		((Control)label1).Text = "Please Standby...";
		((Control)progressBar1).Anchor = (AnchorStyles)13;
		((Control)progressBar1).Location = new Point(12, 59);
		progressBar1.MarqueeAnimationSpeed = 30;
		((Control)progressBar1).Name = "progressBar1";
		((Control)progressBar1).Size = new Size(276, 23);
		progressBar1.Style = (ProgressBarStyle)1;
		((Control)progressBar1).TabIndex = 1;
		((Control)progressBar1).Click += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(300, 94);
		((Control)this).Controls.Add((Control)(object)progressBar1);
		((Control)this).Controls.Add((Control)(object)label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = "WaitDlg";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Standby...";
		((Form)this).Load += b;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
