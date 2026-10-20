using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class AdvancedOverlayFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private SplitContainer cfdd28b747afbe52686772d0eed813027;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private ComboBox cc19d3d3304cacd0d87b2fe12f698fd8c;

	private PictureBox c7aa975f5e3fcfb6c32bfbf99a9b2ddbd;

	private Button c9912dc5182d7219d9182dd331caae777;

	private FontDialog cc8264b1067fe196be453410d7902dac7;

	private ColorDialog cb50e1b6024cdcdd498e9f83018fc0f18;

	private CheckBox cf2556d3d84ccec46b8e28708ef1383cd;

	private Button c49b1cd625246fab001fe62e22d0dde48;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private NumericUpDown cf775ae2e2afc472a90bd06b4c60599e2;

	private NumericUpDown c1829c87bd60da6a162923d45f3bf7e0d;

	private CheckBox ce546d64397e2f022aed53baf560899a0;

	private EnhancedInputData c622bd47e1fd3261c9776b450a288b1dd;

	private Game c54f9a911545745b85ae6f74355697f8b;

	public AdvancedOverlayFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	public AdvancedOverlayFrm(ref EnhancedInputData thedata, ref Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c622bd47e1fd3261c9776b450a288b1dd = thedata;
		c54f9a911545745b85ae6f74355697f8b = curgame;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(AdvancedOverlayFrm.Dispose(bool));
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
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected Obj, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvancedOverlayFrm));
		cfdd28b747afbe52686772d0eed813027 = new SplitContainer();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		cf775ae2e2afc472a90bd06b4c60599e2 = new NumericUpDown();
		c1829c87bd60da6a162923d45f3bf7e0d = new NumericUpDown();
		cf2556d3d84ccec46b8e28708ef1383cd = new CheckBox();
		c49b1cd625246fab001fe62e22d0dde48 = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		cc19d3d3304cacd0d87b2fe12f698fd8c = new ComboBox();
		c7aa975f5e3fcfb6c32bfbf99a9b2ddbd = new PictureBox();
		c9912dc5182d7219d9182dd331caae777 = new Button();
		cc8264b1067fe196be453410d7902dac7 = new FontDialog();
		cb50e1b6024cdcdd498e9f83018fc0f18 = new ColorDialog();
		ce546d64397e2f022aed53baf560899a0 = new CheckBox();
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).BeginInit();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).SuspendLayout();
		((ISupportInitialize)cf775ae2e2afc472a90bd06b4c60599e2).BeginInit();
		((ISupportInitialize)c1829c87bd60da6a162923d45f3bf7e0d).BeginInit();
		((ISupportInitialize)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).BeginInit();
		((Control)this).SuspendLayout();
		cfdd28b747afbe52686772d0eed813027.BorderStyle = (BorderStyle)1;
		cfdd28b747afbe52686772d0eed813027.Dock = (DockStyle)5;
		((Control)cfdd28b747afbe52686772d0eed813027).Location = new Point(0, 0);
		((Control)cfdd28b747afbe52686772d0eed813027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15938);
		cfdd28b747afbe52686772d0eed813027.Orientation = (Orientation)0;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)ce546d64397e2f022aed53baf560899a0);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)cf775ae2e2afc472a90bd06b4c60599e2);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c1829c87bd60da6a162923d45f3bf7e0d);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)cf2556d3d84ccec46b8e28708ef1383cd);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c49b1cd625246fab001fe62e22d0dde48);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cc19d3d3304cacd0d87b2fe12f698fd8c);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c9912dc5182d7219d9182dd331caae777);
		((Control)cfdd28b747afbe52686772d0eed813027).Size = new Size(506, 423);
		cfdd28b747afbe52686772d0eed813027.SplitterDistance = 99;
		((Control)cfdd28b747afbe52686772d0eed813027).TabIndex = 0;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(166, 43);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(995);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(61, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 7;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108310);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(3, 43);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1050);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(98, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 6;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108333);
		((Control)cf775ae2e2afc472a90bd06b4c60599e2).Location = new Point(233, 41);
		cf775ae2e2afc472a90bd06b4c60599e2.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		((Control)cf775ae2e2afc472a90bd06b4c60599e2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108368);
		((Control)cf775ae2e2afc472a90bd06b4c60599e2).Size = new Size(55, 20);
		((Control)cf775ae2e2afc472a90bd06b4c60599e2).TabIndex = 5;
		cf775ae2e2afc472a90bd06b4c60599e2.ValueChanged += c2a6681ee857eaa4ec721ac5941db35b1;
		((Control)c1829c87bd60da6a162923d45f3bf7e0d).Location = new Point(103, 41);
		c1829c87bd60da6a162923d45f3bf7e0d.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		((Control)c1829c87bd60da6a162923d45f3bf7e0d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108391);
		((Control)c1829c87bd60da6a162923d45f3bf7e0d).Size = new Size(57, 20);
		((Control)c1829c87bd60da6a162923d45f3bf7e0d).TabIndex = 4;
		c1829c87bd60da6a162923d45f3bf7e0d.ValueChanged += c4631939384baabc442f9d1ce8e36e941;
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).AutoSize = true;
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).Location = new Point(13, 13);
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108426);
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).Size = new Size(129, 17);
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).TabIndex = 3;
		((Control)cf2556d3d84ccec46b8e28708ef1383cd).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108451);
		((ButtonBase)cf2556d3d84ccec46b8e28708ef1383cd).UseVisualStyleBackColor = true;
		cf2556d3d84ccec46b8e28708ef1383cd.CheckedChanged += cad53edda99bb36b63b06b23b918ebfa1;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Location = new Point(295, 62);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(278);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Size = new Size(78, 23);
		((Control)c49b1cd625246fab001fe62e22d0dde48).TabIndex = 2;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108492);
		((ButtonBase)c49b1cd625246fab001fe62e22d0dde48).UseVisualStyleBackColor = true;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Click += c1fb1239cdd857215284821a847b763b5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(169, 62);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(254);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(119, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 1;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108515);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(3, 62);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(222);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(157, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 0;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108550);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(3, 0);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(144, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 4;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108597);
		((ListControl)cc19d3d3304cacd0d87b2fe12f698fd8c).FormattingEnabled = true;
		((Control)cc19d3d3304cacd0d87b2fe12f698fd8c).Location = new Point(3, 16);
		((Control)cc19d3d3304cacd0d87b2fe12f698fd8c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108650);
		((Control)cc19d3d3304cacd0d87b2fe12f698fd8c).Size = new Size(169, 21);
		((Control)cc19d3d3304cacd0d87b2fe12f698fd8c).TabIndex = 3;
		cc19d3d3304cacd0d87b2fe12f698fd8c.SelectedIndexChanged += c4a50db7ea2b2da7441662abda8763210;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Anchor = (AnchorStyles)15;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Location = new Point(3, 43);
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108669);
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Size = new Size(498, 246);
		c7aa975f5e3fcfb6c32bfbf99a9b2ddbd.SizeMode = (PictureBoxSizeMode)4;
		c7aa975f5e3fcfb6c32bfbf99a9b2ddbd.TabIndex = 2;
		c7aa975f5e3fcfb6c32bfbf99a9b2ddbd.TabStop = false;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Paint += cfe8ad1b3b7e580ac82032103ddf9027c;
		((Control)c9912dc5182d7219d9182dd331caae777).Anchor = (AnchorStyles)6;
		((Control)c9912dc5182d7219d9182dd331caae777).Location = new Point(0, 295);
		((Control)c9912dc5182d7219d9182dd331caae777).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105956);
		((Control)c9912dc5182d7219d9182dd331caae777).Size = new Size(75, 23);
		((Control)c9912dc5182d7219d9182dd331caae777).TabIndex = 0;
		((Control)c9912dc5182d7219d9182dd331caae777).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108688);
		((ButtonBase)c9912dc5182d7219d9182dd331caae777).UseVisualStyleBackColor = true;
		((Control)c9912dc5182d7219d9182dd331caae777).Click += c4ae2942e8a8490f245d8e62e8457341c;
		cb50e1b6024cdcdd498e9f83018fc0f18.AnyColor = true;
		cb50e1b6024cdcdd498e9f83018fc0f18.FullOpen = true;
		((Control)ce546d64397e2f022aed53baf560899a0).AutoSize = true;
		ce546d64397e2f022aed53baf560899a0.Checked = true;
		ce546d64397e2f022aed53baf560899a0.CheckState = (CheckState)1;
		((Control)ce546d64397e2f022aed53baf560899a0).Location = new Point(148, 13);
		((Control)ce546d64397e2f022aed53baf560899a0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108697);
		((Control)ce546d64397e2f022aed53baf560899a0).Size = new Size(87, 17);
		((Control)ce546d64397e2f022aed53baf560899a0).TabIndex = 8;
		((Control)ce546d64397e2f022aed53baf560899a0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108724);
		((ButtonBase)ce546d64397e2f022aed53baf560899a0).UseVisualStyleBackColor = true;
		ce546d64397e2f022aed53baf560899a0.CheckedChanged += c57f5bdf6487619c1e68e9363c4f6e242;
		((Form)this).AcceptButton = (IButtonControl)(object)c9912dc5182d7219d9182dd331caae777;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(506, 423);
		((Control)this).Controls.Add((Control)(object)cfdd28b747afbe52686772d0eed813027);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108749);
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108786);
		((Form)this).Load += ccb365a173f7b8d50afa0482df5a878c5;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).PerformLayout();
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).EndInit();
		((Control)cfdd28b747afbe52686772d0eed813027).ResumeLayout(false);
		((ISupportInitialize)cf775ae2e2afc472a90bd06b4c60599e2).EndInit();
		((ISupportInitialize)c1829c87bd60da6a162923d45f3bf7e0d).EndInit();
		((ISupportInitialize)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void ccb365a173f7b8d50afa0482df5a878c5(object P_0, EventArgs P_1)
	{
		cf2556d3d84ccec46b8e28708ef1383cd.Checked = c622bd47e1fd3261c9776b450a288b1dd.bUseEnhancedGraphics;
		ce546d64397e2f022aed53baf560899a0.Checked = c622bd47e1fd3261c9776b450a288b1dd.bAllowCancel;
		c1829c87bd60da6a162923d45f3bf7e0d.Value = Convert.ToDecimal(c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor.A);
		cf775ae2e2afc472a90bd06b4c60599e2.Value = Convert.ToDecimal(c622bd47e1fd3261c9776b450a288b1dd.TextColor.A);
		cc19d3d3304cacd0d87b2fe12f698fd8c.Items.Clear();
		cc19d3d3304cacd0d87b2fe12f698fd8c.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108829));
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.PictureList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(AdvancedOverlayFrm.ccb365a173f7b8d50afa0482df5a878c5(object, EventArgs));
				GamePicture gamePicture = (GamePicture)enumerator.Current;
				cc19d3d3304cacd0d87b2fe12f698fd8c.Items.Add((object)gamePicture.TheName);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(AdvancedOverlayFrm.ccb365a173f7b8d50afa0482df5a878c5(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (!(c622bd47e1fd3261c9776b450a288b1dd.NewImage != string.Empty))
		{
			__ldtoken(AdvancedOverlayFrm.ccb365a173f7b8d50afa0482df5a878c5(object, EventArgs));
		}
		else
		{
			if (c622bd47e1fd3261c9776b450a288b1dd.NewImage != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108829))
			{
				cc19d3d3304cacd0d87b2fe12f698fd8c.SelectedItem = c622bd47e1fd3261c9776b450a288b1dd.NewImage;
				return;
			}
			__ldtoken(AdvancedOverlayFrm.ccb365a173f7b8d50afa0482df5a878c5(object, EventArgs));
		}
		((ListControl)cc19d3d3304cacd0d87b2fe12f698fd8c).SelectedIndex = 0;
	}

	private void c4a50db7ea2b2da7441662abda8763210(object P_0, EventArgs P_1)
	{
		c622bd47e1fd3261c9776b450a288b1dd.NewImage = cc19d3d3304cacd0d87b2fe12f698fd8c.SelectedItem.ToString();
		if (((ListControl)cc19d3d3304cacd0d87b2fe12f698fd8c).SelectedIndex > 0)
		{
			PictureBox val = c7aa975f5e3fcfb6c32bfbf99a9b2ddbd;
			object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(cc19d3d3304cacd0d87b2fe12f698fd8c.SelectedItem.ToString());
			val.Image = (Image)((pictureByName is Image) ? pictureByName : null);
			GamePicture gamePictureByName = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(cc19d3d3304cacd0d87b2fe12f698fd8c.SelectedItem.ToString());
			gamePictureByName.enhinputdata = c622bd47e1fd3261c9776b450a288b1dd;
			((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Tag = gamePictureByName;
			gamePictureByName.Choices.Clear();
			gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108848));
			gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108869));
			gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108886));
			gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108903));
			gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108920));
			if (!c622bd47e1fd3261c9776b450a288b1dd.bAllowCancel)
			{
				__ldtoken(AdvancedOverlayFrm.c4a50db7ea2b2da7441662abda8763210(object, EventArgs));
			}
			else
			{
				gamePictureByName.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530));
			}
		}
		else
		{
			GamePicture gamePicture = new GamePicture();
			gamePicture.enhinputdata = c622bd47e1fd3261c9776b450a288b1dd;
			((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Tag = gamePicture;
			gamePicture.Choices.Clear();
			gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108848));
			gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108869));
			gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108886));
			gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108903));
			gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108920));
			if (!c622bd47e1fd3261c9776b450a288b1dd.bAllowCancel)
			{
				__ldtoken(AdvancedOverlayFrm.c4a50db7ea2b2da7441662abda8763210(object, EventArgs));
			}
			else
			{
				gamePicture.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530));
			}
		}
	}

	private void cfe8ad1b3b7e580ac82032103ddf9027c(object P_0, PaintEventArgs P_1)
	{
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected Obj, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected Obj, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected Obj, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected Obj, but got Unknown
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
		}
		else
		{
			if (P_0 == null)
			{
				return;
			}
			__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
			PictureBox val = (PictureBox)((P_0 is PictureBox) ? P_0 : null);
			if (val == null)
			{
				return;
			}
			__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
			object tag = ((Control)val).Tag;
			if (!(tag is GamePicture gamePicture))
			{
				__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
				return;
			}
			using (List<string>.Enumerator enumerator = gamePicture.LayeredImages.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
					string current = enumerator.Current;
					object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(current);
					Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
					if (val2 != null)
					{
						P_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
					}
				}
			}
			if (gamePicture.Choices.Count <= 0)
			{
				__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
				return;
			}
			int count = gamePicture.Choices.Count;
			float num = ((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Width;
			float num2 = ((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Height;
			int num3 = 0;
			for (int num4 = count - 1; num4 >= 0; num4--)
			{
				__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
				Character character = gamePicture.Choices[num4] as Character;
				GameObject gameObject = gamePicture.Choices[num4] as GameObject;
				string empty = string.Empty;
				if (character == null)
				{
					__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
					if (gameObject == null)
					{
						__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
						empty = gamePicture.Choices[num4].ToString();
					}
					else
					{
						empty = gameObject.GetDisplayName();
					}
				}
				else
				{
					empty = character.ToString();
				}
				Font val3 = gamePicture.enhinputdata.TextFont;
				if (num4 != 0)
				{
					__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
				}
				else
				{
					try
					{
						val3 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
				SizeF sizeF = new SizeF(num - 20f, height);
				SizeF sizeF2 = P_1.Graphics.MeasureString(empty, val3, sizeF);
				Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
				Point pt = ((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).PointToClient(Cursor.Position);
				P_1.Graphics.FillRectangle((Brush)new SolidBrush(gamePicture.enhinputdata.BackgroundColor), rectangle);
				if (!rectangle.Contains(pt))
				{
					__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
				}
				else if (num4 != 0)
				{
					__ldtoken(AdvancedOverlayFrm.cfe8ad1b3b7e580ac82032103ddf9027c(object, PaintEventArgs));
					P_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Green), 3f), rectangle);
				}
				else
				{
					P_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Red), 3f), rectangle);
				}
				P_1.Graphics.DrawString(empty, val3, (Brush)new SolidBrush(gamePicture.enhinputdata.TextColor), (RectangleF)rectangle);
				num3 += rectangle.Height + 5;
			}
		}
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		cb50e1b6024cdcdd498e9f83018fc0f18.Color = c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor;
		((CommonDialog)cb50e1b6024cdcdd498e9f83018fc0f18).ShowDialog();
		c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor = cb50e1b6024cdcdd498e9f83018fc0f18.Color;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Invalidate();
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		cb50e1b6024cdcdd498e9f83018fc0f18.Color = c622bd47e1fd3261c9776b450a288b1dd.TextColor;
		((CommonDialog)cb50e1b6024cdcdd498e9f83018fc0f18).ShowDialog();
		c622bd47e1fd3261c9776b450a288b1dd.TextColor = cb50e1b6024cdcdd498e9f83018fc0f18.Color;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Invalidate();
	}

	private void c1fb1239cdd857215284821a847b763b5(object P_0, EventArgs P_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		cc8264b1067fe196be453410d7902dac7.Font = c622bd47e1fd3261c9776b450a288b1dd.TextFont;
		((CommonDialog)cc8264b1067fe196be453410d7902dac7).ShowDialog();
		c622bd47e1fd3261c9776b450a288b1dd.TextFont = cc8264b1067fe196be453410d7902dac7.Font;
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Invalidate();
	}

	private void c4631939384baabc442f9d1ce8e36e941(object P_0, EventArgs P_1)
	{
		c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor = Color.FromArgb(Convert.ToInt32(c1829c87bd60da6a162923d45f3bf7e0d.Value), c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor.R, c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor.G, c622bd47e1fd3261c9776b450a288b1dd.BackgroundColor.B);
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Invalidate();
	}

	private void c2a6681ee857eaa4ec721ac5941db35b1(object P_0, EventArgs P_1)
	{
		c622bd47e1fd3261c9776b450a288b1dd.TextColor = Color.FromArgb(Convert.ToInt32(cf775ae2e2afc472a90bd06b4c60599e2.Value), c622bd47e1fd3261c9776b450a288b1dd.TextColor.R, c622bd47e1fd3261c9776b450a288b1dd.TextColor.G, c622bd47e1fd3261c9776b450a288b1dd.TextColor.B);
		((Control)c7aa975f5e3fcfb6c32bfbf99a9b2ddbd).Invalidate();
	}

	private void c4ae2942e8a8490f245d8e62e8457341c(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void cad53edda99bb36b63b06b23b918ebfa1(object P_0, EventArgs P_1)
	{
		c622bd47e1fd3261c9776b450a288b1dd.bUseEnhancedGraphics = cf2556d3d84ccec46b8e28708ef1383cd.Checked;
	}

	private void c57f5bdf6487619c1e68e9363c4f6e242(object P_0, EventArgs P_1)
	{
		c622bd47e1fd3261c9776b450a288b1dd.bAllowCancel = ce546d64397e2f022aed53baf560899a0.Checked;
	}
}
