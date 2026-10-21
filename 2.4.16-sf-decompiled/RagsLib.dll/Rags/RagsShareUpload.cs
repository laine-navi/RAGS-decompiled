using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using A;
using Rags.ragsgame.com;

namespace Rags;

public sealed class RagsShareUpload : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private TextBox cf9a8d5a538c08f8dc70e75126110c7b8;

	private TextBox cdbab176fa152b0653debd49d1f02d4f9;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private ComboBox ca4bd7f0a6367656d8fd1f33f991e1b3b;

	private CheckBox c4e487fb44633da77e3608e3abdff6fc1;

	private Label cd09080500aac71b8d7141db7ac20e5ef;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private TextBox c9cc0609560eb263025e188e9dcac7d43;

	private Label c6761cb7a3178225f4ccff1b5433d216f;

	private Button c49b1cd625246fab001fe62e22d0dde48;

	private OpenFileDialog c65a80a92021b1ba189aaec42668c1427;

	private RichTextBox ce046fbda7c41edce18c2d36bc15662f8;

	private Label c0d947b99f1b2fc91432d24c0054b263f;

	private ProgressBar c81947c6854f1e9fb35737b9e3ad0b00a;

	private Timer c1a8600c9c68783a7d7d474cdb07a5e3a;

	private bool cf434bc08370661dd1d3c19a33c53efd1;

	private Rags.ragsgame.com.ShareData c6c445bb9263baae897c20f873f3b9900;

	public RagsShareUpload(bool Update, Rags.ragsgame.com.ShareData thedata)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cf434bc08370661dd1d3c19a33c53efd1 = Update;
		c6c445bb9263baae897c20f873f3b9900 = thedata;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RagsShareUpload.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(RagsShareUpload.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
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
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a20: Expected Obj, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6f: Expected Obj, but got Unknown
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsShareUpload));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		cf9a8d5a538c08f8dc70e75126110c7b8 = new TextBox();
		cdbab176fa152b0653debd49d1f02d4f9 = new TextBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		ca4bd7f0a6367656d8fd1f33f991e1b3b = new ComboBox();
		c4e487fb44633da77e3608e3abdff6fc1 = new CheckBox();
		cd09080500aac71b8d7141db7ac20e5ef = new Label();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		c9cc0609560eb263025e188e9dcac7d43 = new TextBox();
		c6761cb7a3178225f4ccff1b5433d216f = new Label();
		c49b1cd625246fab001fe62e22d0dde48 = new Button();
		c65a80a92021b1ba189aaec42668c1427 = new OpenFileDialog();
		ce046fbda7c41edce18c2d36bc15662f8 = new RichTextBox();
		c0d947b99f1b2fc91432d24c0054b263f = new Label();
		c81947c6854f1e9fb35737b9e3ad0b00a = new ProgressBar();
		c1a8600c9c68783a7d7d474cdb07a5e3a = new Timer(c501c89bc63d55bb522eac228aeeebb18);
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(69, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110056);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Location = new Point(118, 6);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110033);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Size = new Size(212, 20);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).TabIndex = 1;
		((Control)cdbab176fa152b0653debd49d1f02d4f9).Location = new Point(118, 32);
		((Control)cdbab176fa152b0653debd49d1f02d4f9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117018);
		((Control)cdbab176fa152b0653debd49d1f02d4f9).Size = new Size(212, 20);
		((Control)cdbab176fa152b0653debd49d1f02d4f9).TabIndex = 3;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(12, 35);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1050);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(100, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 2;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117039);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(12, 61);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(995);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(52, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 4;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109972);
		ca4bd7f0a6367656d8fd1f33f991e1b3b.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)ca4bd7f0a6367656d8fd1f33f991e1b3b).FormattingEnabled = true;
		ca4bd7f0a6367656d8fd1f33f991e1b3b.Items.AddRange(new object[4]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117076),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117101),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117132),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117161)
		});
		((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Location = new Point(118, 58);
		((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117170);
		((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Size = new Size(212, 21);
		((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).TabIndex = 5;
		((Control)c4e487fb44633da77e3608e3abdff6fc1).AutoSize = true;
		((Control)c4e487fb44633da77e3608e3abdff6fc1).Location = new Point(15, 86);
		((Control)c4e487fb44633da77e3608e3abdff6fc1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117191);
		((Control)c4e487fb44633da77e3608e3abdff6fc1).Size = new Size(142, 17);
		((Control)c4e487fb44633da77e3608e3abdff6fc1).TabIndex = 6;
		((Control)c4e487fb44633da77e3608e3abdff6fc1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117226);
		((ButtonBase)c4e487fb44633da77e3608e3abdff6fc1).UseVisualStyleBackColor = true;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).AutoSize = true;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Location = new Point(12, 135);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(938);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Size = new Size(63, 13);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).TabIndex = 7;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17542);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(100, 378);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(222);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 9;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117277);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		ce2761d6abd4d4150fc608452cc32c744.DialogResult = (DialogResult)2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(337, 378);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(254);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(75, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 10;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)c9cc0609560eb263025e188e9dcac7d43).Anchor = (AnchorStyles)13;
		((Control)c9cc0609560eb263025e188e9dcac7d43).Location = new Point(118, 109);
		((Control)c9cc0609560eb263025e188e9dcac7d43).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117290);
		((Control)c9cc0609560eb263025e188e9dcac7d43).Size = new Size(343, 20);
		((Control)c9cc0609560eb263025e188e9dcac7d43).TabIndex = 12;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).AutoSize = true;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Location = new Point(12, 112);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(875);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Size = new Size(54, 13);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).TabIndex = 11;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117319);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Anchor = (AnchorStyles)9;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Location = new Point(467, 109);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(278);
		((Control)c49b1cd625246fab001fe62e22d0dde48).Size = new Size(27, 20);
		((Control)c49b1cd625246fab001fe62e22d0dde48).TabIndex = 13;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4383);
		((ButtonBase)c49b1cd625246fab001fe62e22d0dde48).TextAlign = (ContentAlignment)2;
		((ButtonBase)c49b1cd625246fab001fe62e22d0dde48).UseVisualStyleBackColor = true;
		((Control)c49b1cd625246fab001fe62e22d0dde48).Click += c1fb1239cdd857215284821a847b763b5;
		((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117340);
		((FileDialog)c65a80a92021b1ba189aaec42668c1427).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110179);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Anchor = (AnchorStyles)15;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Location = new Point(118, 135);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109834);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Size = new Size(376, 208);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).TabIndex = 14;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Text = "";
		((Control)c0d947b99f1b2fc91432d24c0054b263f).AutoSize = true;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Location = new Point(117, 354);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(723);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Size = new Size(58, 13);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).TabIndex = 22;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117371);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Anchor = (AnchorStyles)13;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = false;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Location = new Point(195, 349);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109628);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Size = new Size(299, 23);
		c81947c6854f1e9fb35737b9e3ad0b00a.Step = 1;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).TabIndex = 21;
		c1a8600c9c68783a7d7d474cdb07a5e3a.Enabled = true;
		c1a8600c9c68783a7d7d474cdb07a5e3a.Tick += c6c81e57d710c9ddb0da56132be15a894;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(506, 410);
		((Control)this).Controls.Add((Control)(object)c0d947b99f1b2fc91432d24c0054b263f);
		((Control)this).Controls.Add((Control)(object)c81947c6854f1e9fb35737b9e3ad0b00a);
		((Control)this).Controls.Add((Control)(object)ce046fbda7c41edce18c2d36bc15662f8);
		((Control)this).Controls.Add((Control)(object)c49b1cd625246fab001fe62e22d0dde48);
		((Control)this).Controls.Add((Control)(object)c9cc0609560eb263025e188e9dcac7d43);
		((Control)this).Controls.Add((Control)(object)c6761cb7a3178225f4ccff1b5433d216f);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)cd09080500aac71b8d7141db7ac20e5ef);
		((Control)this).Controls.Add((Control)(object)c4e487fb44633da77e3608e3abdff6fc1);
		((Control)this).Controls.Add((Control)(object)ca4bd7f0a6367656d8fd1f33f991e1b3b);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)cdbab176fa152b0653debd49d1f02d4f9);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)cf9a8d5a538c08f8dc70e75126110c7b8);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117392);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117423);
		((Form)this).Load += c6900f7c6c1aebfc769cf7d3eca35944e;
		((Form)this).FormClosing += c1e7dfc6969244f652d6bfebd720c2c6e;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c324589b9ccecb3b5b439c9e86eacc3eb(object P_0, AsyncCompletedEventArgs P_1)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = false;
		Cursor.Current = Cursors.Default;
		if (P_1.Error == null)
		{
			__ldtoken(RagsShareUpload.c324589b9ccecb3b5b439c9e86eacc3eb(object, AsyncCompletedEventArgs));
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117487));
			((Form)this).DialogResult = (DialogResult)1;
		}
		else
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117458) + P_1.Error.Message);
		}
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		string text = string.Empty;
		if (!(((Control)c9cc0609560eb263025e188e9dcac7d43).Text.Trim() != string.Empty))
		{
			__ldtoken(RagsShareUpload.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			if (c6c445bb9263baae897c20f873f3b9900 != null)
			{
				text = c6c445bb9263baae897c20f873f3b9900.RagsVersion;
			}
		}
		else
		{
			text = c2ab2b8a540a9848cd43ecce9783e3a76();
		}
		if (text == string.Empty)
		{
			return;
		}
		CheckUpdates checkUpdates = new CheckUpdates();
		checkUpdates.UploadShareCompleted += c324589b9ccecb3b5b439c9e86eacc3eb;
		Rags.ragsgame.com.ShareData shareData = new Rags.ragsgame.com.ShareData();
		try
		{
			if (!cf434bc08370661dd1d3c19a33c53efd1)
			{
				__ldtoken(RagsShareUpload.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
				shareData.useremail = LockData.GetEmail();
				shareData.usernickname = ((Control)cdbab176fa152b0653debd49d1f02d4f9).Text;
				shareData.sharename = ((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Text;
				shareData.category = ((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Text;
				shareData.bexplicit = c4e487fb44633da77e3608e3abdff6fc1.Checked;
				shareData.description = ((Control)ce046fbda7c41edce18c2d36bc15662f8).Text;
				((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = true;
				checkUpdates.UploadShareAsync(shareData, File.ReadAllBytes(((Control)c9cc0609560eb263025e188e9dcac7d43).Text), LockData.GetKey(), text);
				return;
			}
			shareData.index = c6c445bb9263baae897c20f873f3b9900.index;
			shareData.useremail = LockData.GetEmail();
			shareData.usernickname = ((Control)cdbab176fa152b0653debd49d1f02d4f9).Text;
			shareData.sharename = ((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Text;
			shareData.category = ((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Text;
			shareData.bexplicit = c4e487fb44633da77e3608e3abdff6fc1.Checked;
			shareData.description = ((Control)ce046fbda7c41edce18c2d36bc15662f8).Text;
			if (((Control)c9cc0609560eb263025e188e9dcac7d43).Text.Trim() == string.Empty)
			{
				((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = true;
				checkUpdates.UploadShareAsync(shareData, null, LockData.GetKey(), text);
			}
			else
			{
				((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = true;
				checkUpdates.UploadShareAsync(shareData, File.ReadAllBytes(((Control)c9cc0609560eb263025e188e9dcac7d43).Text), LockData.GetKey(), text);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117524) + ex.Message);
		}
	}

	private string c2ab2b8a540a9848cd43ecce9783e3a76()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		string result = string.Empty;
		if (((Control)c9cc0609560eb263025e188e9dcac7d43).Text.Trim().Length <= 0)
		{
			__ldtoken(RagsShareUpload.c2ab2b8a540a9848cd43ecce9783e3a76());
		}
		else
		{
			byte[] array = EncDec.Decrypt(File.ReadAllBytes(((Control)c9cc0609560eb263025e188e9dcac7d43).Text), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117607));
			if (array == null)
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117628));
				return string.Empty;
			}
			MemoryStream memoryStream = new MemoryStream(array);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				memoryStream.Seek(0L, SeekOrigin.Begin);
				_ = (Game)binaryFormatter.Deserialize(memoryStream);
				result = Game.CurrentObjectVersionNumber;
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117628));
				result = string.Empty;
			}
		}
		return result;
	}

	private void c1fb1239cdd857215284821a847b763b5(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((CommonDialog)c65a80a92021b1ba189aaec42668c1427).ShowDialog() != 1)
		{
			__ldtoken(RagsShareUpload.c1fb1239cdd857215284821a847b763b5(object, EventArgs));
		}
		else if (Path.GetExtension(((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName).ToUpper() != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117709))
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117718));
		}
		else
		{
			((Control)c9cc0609560eb263025e188e9dcac7d43).Text = ((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName;
		}
	}

	private void c6900f7c6c1aebfc769cf7d3eca35944e(object P_0, EventArgs P_1)
	{
		if (!cf434bc08370661dd1d3c19a33c53efd1)
		{
			__ldtoken(RagsShareUpload.c6900f7c6c1aebfc769cf7d3eca35944e(object, EventArgs));
			return;
		}
		if (c6c445bb9263baae897c20f873f3b9900 == null)
		{
			__ldtoken(RagsShareUpload.c6900f7c6c1aebfc769cf7d3eca35944e(object, EventArgs));
			return;
		}
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Text = c6c445bb9263baae897c20f873f3b9900.sharename;
		((Control)cdbab176fa152b0653debd49d1f02d4f9).Text = c6c445bb9263baae897c20f873f3b9900.usernickname;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Text = c6c445bb9263baae897c20f873f3b9900.description;
		((Control)ca4bd7f0a6367656d8fd1f33f991e1b3b).Text = c6c445bb9263baae897c20f873f3b9900.category;
		c4e487fb44633da77e3608e3abdff6fc1.Checked = c6c445bb9263baae897c20f873f3b9900.bexplicit;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110098);
	}

	private void c6c81e57d710c9ddb0da56132be15a894(object P_0, EventArgs P_1)
	{
		if (!((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled)
		{
			__ldtoken(RagsShareUpload.c6c81e57d710c9ddb0da56132be15a894(object, EventArgs));
			return;
		}
		if (c81947c6854f1e9fb35737b9e3ad0b00a.Value == 100)
		{
			c81947c6854f1e9fb35737b9e3ad0b00a.Value = 1;
		}
		c81947c6854f1e9fb35737b9e3ad0b00a.Increment(1);
	}

	private void c1e7dfc6969244f652d6bfebd720c2c6e(object P_0, FormClosingEventArgs P_1)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (!((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled)
		{
			__ldtoken(RagsShareUpload.c1e7dfc6969244f652d6bfebd720c2c6e(object, FormClosingEventArgs));
			return;
		}
		((CancelEventArgs)(object)P_1).Cancel = true;
		MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117805));
	}
}
