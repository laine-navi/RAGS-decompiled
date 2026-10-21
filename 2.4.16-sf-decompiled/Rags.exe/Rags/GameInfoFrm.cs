using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class GameInfoFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Label c56076c92a284588d30dc8f5f9c7d923e;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private Label cf2a8ae26f120f2fef8648d9216cd39c2;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private TextBox c0860e91ae586fccb2306aa566c2d56db;

	private Button c4684edf2f70d0a4c772b3fcba21d73a9;

	public GameInfoFrm(string autname, string ver, string info)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		((Control)c56076c92a284588d30dc8f5f9c7d923e).Text = autname;
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).Text = ver;
		((Control)c0860e91ae586fccb2306aa566c2d56db).Text = info;
		((TextBoxBase)c0860e91ae586fccb2306aa566c2d56db).Select(0, 0);
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(GameInfoFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(GameInfoFrm.Dispose(bool));
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GameInfoFrm));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c56076c92a284588d30dc8f5f9c7d923e = new Label();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		cf2a8ae26f120f2fef8648d9216cd39c2 = new Label();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c0860e91ae586fccb2306aa566c2d56db = new TextBox();
		c4684edf2f70d0a4c772b3fcba21d73a9 = new Button();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(41, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2180);
		((Control)c56076c92a284588d30dc8f5f9c7d923e).AutoSize = true;
		((Control)c56076c92a284588d30dc8f5f9c7d923e).Location = new Point(74, 9);
		((Control)c56076c92a284588d30dc8f5f9c7d923e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2195);
		((Control)c56076c92a284588d30dc8f5f9c7d923e).Size = new Size(35, 13);
		((Control)c56076c92a284588d30dc8f5f9c7d923e).TabIndex = 1;
		((Control)c56076c92a284588d30dc8f5f9c7d923e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2222);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(12, 33);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2235);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(45, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 2;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2248);
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).AutoSize = true;
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).Location = new Point(74, 33);
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2265);
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).Size = new Size(35, 13);
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).TabIndex = 3;
		((Control)cf2a8ae26f120f2fef8648d9216cd39c2).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2286);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(15, 65);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2222);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(93, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 4;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2299);
		((Control)c0860e91ae586fccb2306aa566c2d56db).Anchor = (AnchorStyles)15;
		((Control)c0860e91ae586fccb2306aa566c2d56db).Location = new Point(18, 82);
		((TextBoxBase)c0860e91ae586fccb2306aa566c2d56db).Multiline = true;
		((Control)c0860e91ae586fccb2306aa566c2d56db).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2334);
		((TextBoxBase)c0860e91ae586fccb2306aa566c2d56db).ReadOnly = true;
		c0860e91ae586fccb2306aa566c2d56db.ScrollBars = (ScrollBars)2;
		((Control)c0860e91ae586fccb2306aa566c2d56db).Size = new Size(469, 308);
		((Control)c0860e91ae586fccb2306aa566c2d56db).TabIndex = 5;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Anchor = (AnchorStyles)2;
		c4684edf2f70d0a4c772b3fcba21d73a9.DialogResult = (DialogResult)2;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Location = new Point(213, 396);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2355);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Size = new Size(75, 23);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).TabIndex = 6;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1129);
		((ButtonBase)c4684edf2f70d0a4c772b3fcba21d73a9).UseVisualStyleBackColor = true;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Click += c7f324705348fcc3390003b4be3497293;
		((Form)this).AcceptButton = (IButtonControl)(object)c4684edf2f70d0a4c772b3fcba21d73a9;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)c4684edf2f70d0a4c772b3fcba21d73a9;
		((Form)this).ClientSize = new Size(499, 431);
		((Control)this).Controls.Add((Control)(object)c4684edf2f70d0a4c772b3fcba21d73a9);
		((Control)this).Controls.Add((Control)(object)c0860e91ae586fccb2306aa566c2d56db);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)cf2a8ae26f120f2fef8648d9216cd39c2);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)c56076c92a284588d30dc8f5f9c7d923e);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2370);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2370);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c7f324705348fcc3390003b4be3497293(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}
}
