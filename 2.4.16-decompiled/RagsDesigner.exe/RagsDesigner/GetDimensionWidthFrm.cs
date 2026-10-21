using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace RagsDesigner;

public sealed class GetDimensionWidthFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	public NumericUpDown udWidth;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	public GetDimensionWidthFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(GetDimensionWidthFrm.Dispose(bool));
			}
			else
			{
				c501c89bc63d55bb522eac228aeeebb18.Dispose();
			}
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
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetDimensionWidthFrm));
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		udWidth = new NumericUpDown();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		((ISupportInitialize)udWidth).BeginInit();
		((Control)this).SuspendLayout();
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(37, 89);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(69, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 0;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(493);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		ce2761d6abd4d4150fc608452cc32c744.DialogResult = (DialogResult)2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(181, 89);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(75, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 1;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(47, 24);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(186, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 2;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72384);
		((Control)udWidth).Location = new Point(110, 53);
		udWidth.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		((Control)udWidth).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72453);
		((Control)udWidth).Size = new Size(61, 20);
		((Control)udWidth).TabIndex = 3;
		udWidth.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(23, 37);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(234, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 4;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72468);
		((Form)this).AcceptButton = (IButtonControl)(object)c79769badd3b3f4571a08b51317e02dcc;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)ce2761d6abd4d4150fc608452cc32c744;
		((Form)this).ClientSize = new Size(281, 124);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)udWidth);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72563);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72604);
		((ISupportInitialize)udWidth).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}
}
