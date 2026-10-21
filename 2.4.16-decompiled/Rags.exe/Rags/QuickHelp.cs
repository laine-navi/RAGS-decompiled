using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class QuickHelp : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private PictureBox c9c86181d01d6e5321a041362bffece16;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	public QuickHelp()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(QuickHelp.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(QuickHelp.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickHelp));
		c9c86181d01d6e5321a041362bffece16 = new PictureBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		((ISupportInitialize)c9c86181d01d6e5321a041362bffece16).BeginInit();
		((Control)this).SuspendLayout();
		c9c86181d01d6e5321a041362bffece16.Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1));
		((Control)c9c86181d01d6e5321a041362bffece16).Location = new Point(12, 116);
		((Control)c9c86181d01d6e5321a041362bffece16).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(36);
		((Control)c9c86181d01d6e5321a041362bffece16).Size = new Size(724, 537);
		c9c86181d01d6e5321a041362bffece16.TabIndex = 0;
		c9c86181d01d6e5321a041362bffece16.TabStop = false;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 33);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(724, 80);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 1;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = componentResourceManager.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72));
		((Control)c300c24b05030c9258d5792c1ed7c590d).Click += c660301bb4a0def167beea2323ca1130b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(746, 665);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c9c86181d01d6e5321a041362bffece16);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(135);
		((ISupportInitialize)c9c86181d01d6e5321a041362bffece16).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void c660301bb4a0def167beea2323ca1130b(object P_0, EventArgs P_1)
	{
	}
}
