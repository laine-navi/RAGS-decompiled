using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class WaitDlg : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	public Label label1;

	public ProgressBar progressBar1;

	public WaitDlg()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(WaitDlg.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		label1 = new Label();
		progressBar1 = new ProgressBar();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label1).Location = new Point(64, 19);
		((Control)label1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)label1).Size = new Size(172, 24);
		((Control)label1).TabIndex = 0;
		((Control)label1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112011);
		((Control)progressBar1).Anchor = (AnchorStyles)13;
		((Control)progressBar1).Location = new Point(12, 59);
		progressBar1.MarqueeAnimationSpeed = 30;
		((Control)progressBar1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109628);
		((Control)progressBar1).Size = new Size(276, 23);
		progressBar1.Style = (ProgressBarStyle)1;
		((Control)progressBar1).TabIndex = 1;
		((Control)progressBar1).Click += c530bfdd586aa183df1979b23ba9d1138;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(300, 94);
		((Control)this).Controls.Add((Control)(object)progressBar1);
		((Control)this).Controls.Add((Control)(object)label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112046);
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112061);
		((Form)this).Load += cb2cd213be1751c9b35e1edd32d25de41;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void cb2cd213be1751c9b35e1edd32d25de41(object P_0, EventArgs P_1)
	{
	}

	private void c530bfdd586aa183df1979b23ba9d1138(object P_0, EventArgs P_1)
	{
	}
}
