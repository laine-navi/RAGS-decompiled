using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class EndGameDialog : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Button c49b1cd625246fab001fe62e22d0dde48;

	public EndGameDialog()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)6;
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)5;
	}

	private void c1fb1239cdd857215284821a847b763b5(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)7;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(EndGameDialog.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EndGameDialog));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		c49b1cd625246fab001fe62e22d0dde48 = new Button();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(24, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(256, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1974);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(18, 43);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1884);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 1;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2075);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(114, 43);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2090);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(75, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2105);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Location = new Point(210, 43);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2114);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Size = new Size(75, 23);
		((Control)c49b1cd625246fab001fe62e22d0dde48).TabIndex = 3;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2129);
		((ButtonBase)c49b1cd625246fab001fe62e22d0dde48).UseVisualStyleBackColor = true;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Click += c1fb1239cdd857215284821a847b763b5;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(302, 81);
		((Control)this).Controls.Add((Control)(object)c49b1cd625246fab001fe62e22d0dde48);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2134);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2161);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
