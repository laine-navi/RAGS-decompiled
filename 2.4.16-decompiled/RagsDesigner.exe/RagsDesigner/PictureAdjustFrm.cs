using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class PictureAdjustFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private NumericUpDown c7acaeeea12eed9f5683e09309e9b8aaa;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button c9912dc5182d7219d9182dd331caae777;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	private ListBox cc7ec70b770e0c2b026fe759bb99b2b70;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private NumericUpDown c41a66d6164b55e1b2aea2f3cafead82e;

	private ComboBox ca8b9bb05a272ba884aa844f624f2d96b;

	private Label cd09080500aac71b8d7141db7ac20e5ef;

	private GroupBox ca80957da81788ac8a6f393ba3899a63f;

	private Label c8475a831a422a7a9166bccdb5ffd0ee0;

	private Label caef83607ff3e72e2b887b48e0ece411c;

	private Label ce48562bb358a91eeef71cbfa62c88f4a;

	private Label c2671d66aaa3292cae54af1c286842b28;

	private Label c29b8fdb8021855005c04ecd03dcdc6f3;

	private Label ca1ecddf3782a35a5feb56b1b330818da;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private PictureBox c217da03c86f85b7308aedcd0dd311fcd;

	private SplitContainer cfdd28b747afbe52686772d0eed813027;

	private PictureBox ca925d511b7693cd86af82b6d473fb027;

	private Label c6761cb7a3178225f4ccff1b5433d216f;

	private Label c9d4ad01777c9f1fe617730d0b9adf386;

	private Label c1c26b17a43b0adbc277059584f711551;

	private ArrayList c1943c851c83b6077e5dd40531fc60e04;

	private string c4401f5a363c9f5fa1a776534d29209c6 = string.Empty;

	private double ce3f6b220861949ad7c9a8caad4d3de72;

	private double c4c6826eb2f2d96b6cbc3884338b6eac9;

	private IntPtr cd11842f6f358714f1bf3366b3bf5784d;

	private int c6dc80483c80bfddc5b4e07abce776cc1;

	public PictureAdjustFrm(ref ArrayList PictureList, string adjustname)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c1943c851c83b6077e5dd40531fc60e04 = PictureList;
		c4401f5a363c9f5fa1a776534d29209c6 = adjustname;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(PictureAdjustFrm.Dispose(bool));
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_0e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Expected Obj, but got Unknown
		//IL_101c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1026: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PictureAdjustFrm));
		c7acaeeea12eed9f5683e09309e9b8aaa = new NumericUpDown();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c9912dc5182d7219d9182dd331caae777 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		cc7ec70b770e0c2b026fe759bb99b2b70 = new ListBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		c41a66d6164b55e1b2aea2f3cafead82e = new NumericUpDown();
		ca8b9bb05a272ba884aa844f624f2d96b = new ComboBox();
		cd09080500aac71b8d7141db7ac20e5ef = new Label();
		ca80957da81788ac8a6f393ba3899a63f = new GroupBox();
		c29b8fdb8021855005c04ecd03dcdc6f3 = new Label();
		ca1ecddf3782a35a5feb56b1b330818da = new Label();
		ce48562bb358a91eeef71cbfa62c88f4a = new Label();
		c2671d66aaa3292cae54af1c286842b28 = new Label();
		c8475a831a422a7a9166bccdb5ffd0ee0 = new Label();
		caef83607ff3e72e2b887b48e0ece411c = new Label();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		c217da03c86f85b7308aedcd0dd311fcd = new PictureBox();
		cfdd28b747afbe52686772d0eed813027 = new SplitContainer();
		c9d4ad01777c9f1fe617730d0b9adf386 = new Label();
		ca925d511b7693cd86af82b6d473fb027 = new PictureBox();
		c6761cb7a3178225f4ccff1b5433d216f = new Label();
		c1c26b17a43b0adbc277059584f711551 = new Label();
		((ISupportInitialize)c7acaeeea12eed9f5683e09309e9b8aaa).BeginInit();
		((ISupportInitialize)c41a66d6164b55e1b2aea2f3cafead82e).BeginInit();
		((Control)ca80957da81788ac8a6f393ba3899a63f).SuspendLayout();
		((ISupportInitialize)c217da03c86f85b7308aedcd0dd311fcd).BeginInit();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).SuspendLayout();
		((ISupportInitialize)ca925d511b7693cd86af82b6d473fb027).BeginInit();
		((Control)this).SuspendLayout();
		((Control)c7acaeeea12eed9f5683e09309e9b8aaa).Location = new Point(189, 22);
		c7acaeeea12eed9f5683e09309e9b8aaa.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)c7acaeeea12eed9f5683e09309e9b8aaa).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73063);
		((Control)c7acaeeea12eed9f5683e09309e9b8aaa).Size = new Size(91, 20);
		((Control)c7acaeeea12eed9f5683e09309e9b8aaa).TabIndex = 2;
		c7acaeeea12eed9f5683e09309e9b8aaa.Value = new decimal(new int[4] { 80, 0, 0, 0 });
		c7acaeeea12eed9f5683e09309e9b8aaa.ValueChanged += cf93a78207a27caf5ad68cbaeb1ed6ec7;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(186, 6);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(42, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 3;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73082);
		((Control)c9912dc5182d7219d9182dd331caae777).Anchor = (AnchorStyles)6;
		((Control)c9912dc5182d7219d9182dd331caae777).Location = new Point(12, 553);
		((Control)c9912dc5182d7219d9182dd331caae777).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73099);
		((Control)c9912dc5182d7219d9182dd331caae777).Size = new Size(76, 23);
		((Control)c9912dc5182d7219d9182dd331caae777).TabIndex = 4;
		((Control)c9912dc5182d7219d9182dd331caae777).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73116);
		((ButtonBase)c9912dc5182d7219d9182dd331caae777).UseVisualStyleBackColor = true;
		((Control)c9912dc5182d7219d9182dd331caae777).Click += c4ae2942e8a8490f245d8e62e8457341c;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Anchor = (AnchorStyles)6;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(662, 553);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47338);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(47, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 5;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(368);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Control)cc7ec70b770e0c2b026fe759bb99b2b70).Anchor = (AnchorStyles)7;
		((ListControl)cc7ec70b770e0c2b026fe759bb99b2b70).FormattingEnabled = true;
		((Control)cc7ec70b770e0c2b026fe759bb99b2b70).Location = new Point(11, 23);
		((Control)cc7ec70b770e0c2b026fe759bb99b2b70).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73141);
		cc7ec70b770e0c2b026fe759bb99b2b70.SelectionMode = (SelectionMode)3;
		((Control)cc7ec70b770e0c2b026fe759bb99b2b70).Size = new Size(131, 524);
		((Control)cc7ec70b770e0c2b026fe759bb99b2b70).TabIndex = 6;
		cc7ec70b770e0c2b026fe759bb99b2b70.SelectedIndexChanged += c61f2b38a5f8903a9c5f6251eb1ddfd81;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(8, 6);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(48, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 7;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73162);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(319, 6);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9893);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(137, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 9;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73181);
		((Control)c41a66d6164b55e1b2aea2f3cafead82e).Location = new Point(322, 22);
		c41a66d6164b55e1b2aea2f3cafead82e.Maximum = new decimal(new int[4] { 200, 0, 0, 0 });
		c41a66d6164b55e1b2aea2f3cafead82e.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)c41a66d6164b55e1b2aea2f3cafead82e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73240);
		((Control)c41a66d6164b55e1b2aea2f3cafead82e).Size = new Size(134, 20);
		((Control)c41a66d6164b55e1b2aea2f3cafead82e).TabIndex = 8;
		c41a66d6164b55e1b2aea2f3cafead82e.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		c41a66d6164b55e1b2aea2f3cafead82e.ValueChanged += ccfef7a1d32a65ced89ee45e9339c9182;
		ca8b9bb05a272ba884aa844f624f2d96b.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)ca8b9bb05a272ba884aa844f624f2d96b).FormattingEnabled = true;
		ca8b9bb05a272ba884aa844f624f2d96b.Items.AddRange(new object[2]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73265),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73284)
		});
		((Control)ca8b9bb05a272ba884aa844f624f2d96b).Location = new Point(247, 64);
		((Control)ca8b9bb05a272ba884aa844f624f2d96b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73307);
		((Control)ca8b9bb05a272ba884aa844f624f2d96b).Size = new Size(121, 21);
		((Control)ca8b9bb05a272ba884aa844f624f2d96b).TabIndex = 10;
		ca8b9bb05a272ba884aa844f624f2d96b.SelectedIndexChanged += c8f10b0134bf4b547c19c20f83dff5ec3;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).AutoSize = true;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Location = new Point(247, 47);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9847);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Size = new Size(99, 13);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).TabIndex = 11;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73328);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c29b8fdb8021855005c04ecd03dcdc6f3);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)ca1ecddf3782a35a5feb56b1b330818da);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)ce48562bb358a91eeef71cbfa62c88f4a);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c2671d66aaa3292cae54af1c286842b28);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c8475a831a422a7a9166bccdb5ffd0ee0);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)caef83607ff3e72e2b887b48e0ece411c);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Location = new Point(471, 3);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(526);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Size = new Size(238, 82);
		((Control)ca80957da81788ac8a6f393ba3899a63f).TabIndex = 12;
		ca80957da81788ac8a6f393ba3899a63f.TabStop = false;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73365);
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).AutoSize = true;
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Location = new Point(114, 61);
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73394);
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Size = new Size(67, 13);
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).TabIndex = 5;
		((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73419);
		((Control)ca1ecddf3782a35a5feb56b1b330818da).AutoSize = true;
		((Control)ca1ecddf3782a35a5feb56b1b330818da).Location = new Point(6, 61);
		((Control)ca1ecddf3782a35a5feb56b1b330818da).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73442);
		((Control)ca1ecddf3782a35a5feb56b1b330818da).Size = new Size(64, 13);
		((Control)ca1ecddf3782a35a5feb56b1b330818da).TabIndex = 4;
		((Control)ca1ecddf3782a35a5feb56b1b330818da).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73467);
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).AutoSize = true;
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).Location = new Point(114, 41);
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73492);
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).Size = new Size(82, 13);
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).TabIndex = 3;
		((Control)ce48562bb358a91eeef71cbfa62c88f4a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73513);
		((Control)c2671d66aaa3292cae54af1c286842b28).AutoSize = true;
		((Control)c2671d66aaa3292cae54af1c286842b28).Location = new Point(114, 21);
		((Control)c2671d66aaa3292cae54af1c286842b28).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73544);
		((Control)c2671d66aaa3292cae54af1c286842b28).Size = new Size(79, 13);
		((Control)c2671d66aaa3292cae54af1c286842b28).TabIndex = 2;
		((Control)c2671d66aaa3292cae54af1c286842b28).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73567);
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).AutoSize = true;
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Location = new Point(6, 41);
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73596);
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Size = new Size(41, 13);
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).TabIndex = 1;
		((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73629);
		((Control)caef83607ff3e72e2b887b48e0ece411c).AutoSize = true;
		((Control)caef83607ff3e72e2b887b48e0ece411c).Location = new Point(6, 21);
		((Control)caef83607ff3e72e2b887b48e0ece411c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73644);
		((Control)caef83607ff3e72e2b887b48e0ece411c).Size = new Size(38, 13);
		((Control)caef83607ff3e72e2b887b48e0ece411c).TabIndex = 0;
		((Control)caef83607ff3e72e2b887b48e0ece411c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73677);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Anchor = (AnchorStyles)6;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(319, 553);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(108, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 13;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73690);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		c217da03c86f85b7308aedcd0dd311fcd.BorderStyle = (BorderStyle)1;
		((Control)c217da03c86f85b7308aedcd0dd311fcd).Location = new Point(2, 16);
		((Control)c217da03c86f85b7308aedcd0dd311fcd).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(25998);
		((Control)c217da03c86f85b7308aedcd0dd311fcd).Size = new Size(274, 437);
		c217da03c86f85b7308aedcd0dd311fcd.SizeMode = (PictureBoxSizeMode)4;
		c217da03c86f85b7308aedcd0dd311fcd.TabIndex = 1;
		c217da03c86f85b7308aedcd0dd311fcd.TabStop = false;
		((Control)c217da03c86f85b7308aedcd0dd311fcd).Click += c20e9924908c9f53c02aeb212c6fdeecc;
		((Control)cfdd28b747afbe52686772d0eed813027).Anchor = (AnchorStyles)15;
		((Control)cfdd28b747afbe52686772d0eed813027).Location = new Point(148, 91);
		((Control)cfdd28b747afbe52686772d0eed813027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11018);
		((ScrollableControl)cfdd28b747afbe52686772d0eed813027.Panel1).AutoScroll = true;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c9d4ad01777c9f1fe617730d0b9adf386);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)ca925d511b7693cd86af82b6d473fb027);
		((ScrollableControl)cfdd28b747afbe52686772d0eed813027.Panel2).AutoScroll = true;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c6761cb7a3178225f4ccff1b5433d216f);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c217da03c86f85b7308aedcd0dd311fcd);
		((Control)cfdd28b747afbe52686772d0eed813027).Size = new Size(561, 456);
		cfdd28b747afbe52686772d0eed813027.SplitterDistance = 278;
		((Control)cfdd28b747afbe52686772d0eed813027).TabIndex = 15;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).AutoSize = true;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Location = new Point(3, -1);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10932);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Size = new Size(45, 13);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).TabIndex = 3;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73725);
		ca925d511b7693cd86af82b6d473fb027.BorderStyle = (BorderStyle)1;
		((Control)ca925d511b7693cd86af82b6d473fb027).Location = new Point(3, 16);
		((Control)ca925d511b7693cd86af82b6d473fb027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73744);
		((Control)ca925d511b7693cd86af82b6d473fb027).Size = new Size(272, 437);
		ca925d511b7693cd86af82b6d473fb027.SizeMode = (PictureBoxSizeMode)4;
		ca925d511b7693cd86af82b6d473fb027.TabIndex = 2;
		ca925d511b7693cd86af82b6d473fb027.TabStop = false;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).AutoSize = true;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Location = new Point(3, -1);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(25933);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Size = new Size(51, 13);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).TabIndex = 2;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73767);
		((Control)c1c26b17a43b0adbc277059584f711551).AutoSize = true;
		((Control)c1c26b17a43b0adbc277059584f711551).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(273), 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)c1c26b17a43b0adbc277059584f711551).Location = new Point(151, 558);
		((Control)c1c26b17a43b0adbc277059584f711551).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73786);
		((Control)c1c26b17a43b0adbc277059584f711551).Size = new Size(130, 13);
		((Control)c1c26b17a43b0adbc277059584f711551).TabIndex = 16;
		((Control)c1c26b17a43b0adbc277059584f711551).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73786);
		((Control)c1c26b17a43b0adbc277059584f711551).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(721, 579);
		((Control)this).Controls.Add((Control)(object)c1c26b17a43b0adbc277059584f711551);
		((Control)this).Controls.Add((Control)(object)cfdd28b747afbe52686772d0eed813027);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)ca80957da81788ac8a6f393ba3899a63f);
		((Control)this).Controls.Add((Control)(object)cd09080500aac71b8d7141db7ac20e5ef);
		((Control)this).Controls.Add((Control)(object)ca8b9bb05a272ba884aa844f624f2d96b);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)c41a66d6164b55e1b2aea2f3cafead82e);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)cc7ec70b770e0c2b026fe759bb99b2b70);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)c9912dc5182d7219d9182dd331caae777);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c7acaeeea12eed9f5683e09309e9b8aaa);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73827);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73827);
		((Form)this).Load += c13a9bdd91a292e40f84fdbbb0f591348;
		((ISupportInitialize)c7acaeeea12eed9f5683e09309e9b8aaa).EndInit();
		((ISupportInitialize)c41a66d6164b55e1b2aea2f3cafead82e).EndInit();
		((Control)ca80957da81788ac8a6f393ba3899a63f).ResumeLayout(false);
		((Control)ca80957da81788ac8a6f393ba3899a63f).PerformLayout();
		((ISupportInitialize)c217da03c86f85b7308aedcd0dd311fcd).EndInit();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).ResumeLayout(false);
		((ISupportInitialize)ca925d511b7693cd86af82b6d473fb027).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void cf93a78207a27caf5ad68cbaeb1ed6ec7(object P_0, EventArgs P_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (!(cc7ec70b770e0c2b026fe759bb99b2b70.SelectedItem is GamePicture gamePicture))
			{
				__ldtoken(PictureAdjustFrm.cf93a78207a27caf5ad68cbaeb1ed6ec7(object, EventArgs));
				return;
			}
			Image theImage = gamePicture.GetTheImage();
			c217da03c86f85b7308aedcd0dd311fcd.Image = ResizeBitmap(theImage, Convert.ToInt32(c41a66d6164b55e1b2aea2f3cafead82e.Value));
			c217da03c86f85b7308aedcd0dd311fcd.Image = c26f3f6e6b186490444b9e185f1837bac(c217da03c86f85b7308aedcd0dd311fcd.Image, Convert.ToInt32(c7acaeeea12eed9f5683e09309e9b8aaa.Value));
			((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73860) + theImage.Height;
			((Control)caef83607ff3e72e2b887b48e0ece411c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73877) + theImage.Width;
			((Control)c2671d66aaa3292cae54af1c286842b28).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73892) + c217da03c86f85b7308aedcd0dd311fcd.Image.Width;
			((Control)ce48562bb358a91eeef71cbfa62c88f4a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73923) + c217da03c86f85b7308aedcd0dd311fcd.Image.Height;
			byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
			byte[] array2 = (byte[])TypeDescriptor.GetConverter(c217da03c86f85b7308aedcd0dd311fcd.Image).ConvertTo(c217da03c86f85b7308aedcd0dd311fcd.Image, typeof(byte[]));
			_ = array.Length / 1024;
			((Control)ca1ecddf3782a35a5feb56b1b330818da).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73956), array.Length / 1024);
			((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74005), array2.Length / 1024);
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private Image c26f3f6e6b186490444b9e185f1837bac(Image P_0, int P_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		if (P_0 != null)
		{
			__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
			if (P_1 < 0)
			{
				__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
			}
			else
			{
				_ = 100;
			}
			EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)P_1);
			ImageCodecInfo val2 = null;
			string text = ImageFormat.Gif.Guid.ToString();
			string text2 = ImageFormat.Png.Guid.ToString();
			string text3 = ca925d511b7693cd86af82b6d473fb027.Image.RawFormat.Guid.ToString();
			((Control)c1c26b17a43b0adbc277059584f711551).Visible = false;
			if (!(text3 == text))
			{
				__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
				if (!(text3 == text2))
				{
					__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
					val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37170));
				}
				else
				{
					val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74050));
					if (val2 != null)
					{
						__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
					}
					else
					{
						((Control)c1c26b17a43b0adbc277059584f711551).Visible = true;
						((Control)c1c26b17a43b0adbc277059584f711551).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74069);
					}
				}
				if (val2 == null)
				{
					__ldtoken(PictureAdjustFrm.c26f3f6e6b186490444b9e185f1837bac(Image, int));
					return P_0;
				}
				EncoderParameters val3 = new EncoderParameters(1);
				val3.Param[0] = val;
				MemoryStream memoryStream = new MemoryStream();
				P_0.Save((Stream)memoryStream, val2, val3);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				return Image.FromStream((Stream)memoryStream);
			}
			return P_0;
		}
		return P_0;
	}

	private ImageCodecInfo c16aac53cdad270401e5646e1d265fd81(string P_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length; i++)
		{
			if (!(imageEncoders[i].MimeType == P_0))
			{
				__ldtoken(PictureAdjustFrm.c16aac53cdad270401e5646e1d265fd81(string));
				continue;
			}
			return imageEncoders[i];
		}
		return null;
	}

	private void c61f2b38a5f8903a9c5f6251eb1ddfd81(object P_0, EventArgs P_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (!(cc7ec70b770e0c2b026fe759bb99b2b70.SelectedItem is GamePicture gamePicture))
			{
				__ldtoken(PictureAdjustFrm.c61f2b38a5f8903a9c5f6251eb1ddfd81(object, EventArgs));
				return;
			}
			Image theImage = gamePicture.GetTheImage();
			if (theImage == null)
			{
				__ldtoken(PictureAdjustFrm.c61f2b38a5f8903a9c5f6251eb1ddfd81(object, EventArgs));
				return;
			}
			ca925d511b7693cd86af82b6d473fb027.Image = theImage;
			c217da03c86f85b7308aedcd0dd311fcd.Image = ResizeBitmap(theImage, Convert.ToInt32(c41a66d6164b55e1b2aea2f3cafead82e.Value));
			c217da03c86f85b7308aedcd0dd311fcd.Image = c26f3f6e6b186490444b9e185f1837bac(c217da03c86f85b7308aedcd0dd311fcd.Image, Convert.ToInt32(c7acaeeea12eed9f5683e09309e9b8aaa.Value));
			((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73860) + theImage.Height;
			((Control)caef83607ff3e72e2b887b48e0ece411c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73877) + theImage.Width;
			((Control)c2671d66aaa3292cae54af1c286842b28).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73892) + c217da03c86f85b7308aedcd0dd311fcd.Image.Width;
			((Control)ce48562bb358a91eeef71cbfa62c88f4a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73923) + c217da03c86f85b7308aedcd0dd311fcd.Image.Height;
			byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
			byte[] array2 = (byte[])TypeDescriptor.GetConverter(c217da03c86f85b7308aedcd0dd311fcd.Image).ConvertTo(c217da03c86f85b7308aedcd0dd311fcd.Image, typeof(byte[]));
			_ = array.Length / 1024;
			((Control)ca1ecddf3782a35a5feb56b1b330818da).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73956), array.Length / 1024);
			((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74005), array2.Length / 1024);
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private void c13a9bdd91a292e40f84fdbbb0f591348(object P_0, EventArgs P_1)
	{
		c595bc5ff00258ef47124e08bef39c7fd();
	}

	private void c595bc5ff00258ef47124e08bef39c7fd()
	{
		((ListControl)ca8b9bb05a272ba884aa844f624f2d96b).SelectedIndex = 0;
		cc7ec70b770e0c2b026fe759bb99b2b70.Items.Clear();
		for (int i = 0; i < c1943c851c83b6077e5dd40531fc60e04.Count; i++)
		{
			cc7ec70b770e0c2b026fe759bb99b2b70.Items.Add(c1943c851c83b6077e5dd40531fc60e04[i]);
		}
		if (cc7ec70b770e0c2b026fe759bb99b2b70.Items.Count <= 0)
		{
			__ldtoken(PictureAdjustFrm.c595bc5ff00258ef47124e08bef39c7fd());
		}
		else
		{
			((ListControl)cc7ec70b770e0c2b026fe759bb99b2b70).SelectedIndex = 0;
		}
	}

	private void c4ae2942e8a8490f245d8e62e8457341c(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < c1943c851c83b6077e5dd40531fc60e04.Count; i++)
		{
			__ldtoken(PictureAdjustFrm.c4ae2942e8a8490f245d8e62e8457341c(object, EventArgs));
			if (!(c1943c851c83b6077e5dd40531fc60e04[i] is GamePicture gamePicture))
			{
				__ldtoken(PictureAdjustFrm.c4ae2942e8a8490f245d8e62e8457341c(object, EventArgs));
				continue;
			}
			Image val = ResizeBitmap(gamePicture.GetTheImage(), Convert.ToInt32(c41a66d6164b55e1b2aea2f3cafead82e.Value));
			if (val != null)
			{
				val = c26f3f6e6b186490444b9e185f1837bac(val, Convert.ToInt32(c7acaeeea12eed9f5683e09309e9b8aaa.Value));
				MemoryStream memoryStream = new MemoryStream();
				val.Save((Stream)memoryStream, val.RawFormat);
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74120), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74268), memoryStream.ToArray());
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37610), gamePicture.TheName);
				sqlCeCommand.ExecuteNonQuery();
				memoryStream.Close();
				memoryStream.Dispose();
			}
		}
		c41a66d6164b55e1b2aea2f3cafead82e.Value = 100m;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	public bool ThumbnailCallback()
	{
		return false;
	}

	public unsafe Image ResizeBitmap(Image b, int percentage)
	{
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		if (b != null)
		{
			__ldtoken(PictureAdjustFrm.ResizeBitmap(Image, int));
			if ((int)b.PixelFormat == 198659)
			{
				__ldtoken(PictureAdjustFrm.ResizeBitmap(Image, int));
				Bitmap val = new Bitmap(Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)), b.PixelFormat);
				((Image)val).Palette = b.Palette;
				BitmapData val2 = ((Bitmap)b).LockBits(new Rectangle(0, 0, b.Width, b.Height), (ImageLockMode)1, b.PixelFormat);
				try
				{
					BitmapData val3 = val.LockBits(new Rectangle(0, 0, ((Image)val).Width, ((Image)val).Height), (ImageLockMode)2, ((Image)val).PixelFormat);
					try
					{
						ce3f6b220861949ad7c9a8caad4d3de72 = (double)b.Width / (double)((Image)val).Width;
						c4c6826eb2f2d96b6cbc3884338b6eac9 = (double)b.Height / (double)((Image)val).Height;
						c6dc80483c80bfddc5b4e07abce776cc1 = val2.Stride;
						cd11842f6f358714f1bf3366b3bf5784d = val2.Scan0;
						int stride = val3.Stride;
						IntPtr scan = val3.Scan0;
						byte* ptr = (byte*)(void*)scan;
						int num = stride - ((Image)val).Width;
						int width = ((Image)val).Width;
						for (int i = 0; i < ((Image)val).Height; i++)
						{
							__ldtoken(PictureAdjustFrm.ResizeBitmap(Image, int));
							for (int j = 0; j < width; j++)
							{
								__ldtoken(PictureAdjustFrm.ResizeBitmap(Image, int));
								*ptr = c697a2a1ddcf69f4e278d1d89ccfbba1a(j, i);
								ptr++;
							}
							ptr += num;
						}
					}
					finally
					{
						val.UnlockBits(val3);
					}
				}
				finally
				{
					((Bitmap)b).UnlockBits(val2);
				}
				return (Image)(object)val;
			}
			try
			{
				Bitmap val4 = new Bitmap(Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)), b.PixelFormat);
				try
				{
					((Image)val4).Palette = b.Palette;
				}
				catch
				{
				}
				Graphics val5 = Graphics.FromImage((Image)(object)val4);
				try
				{
					val5.InterpolationMode = (InterpolationMode)7;
					val5.DrawImage(b, 0, 0, Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)));
				}
				finally
				{
					if (val5 == null)
					{
						__ldtoken(PictureAdjustFrm.ResizeBitmap(Image, int));
					}
					else
					{
						((IDisposable)val5).Dispose();
					}
				}
				return (Image)(object)val4;
			}
			catch
			{
				return b;
			}
		}
		return b;
	}

	private unsafe byte c697a2a1ddcf69f4e278d1d89ccfbba1a(int P_0, int P_1)
	{
		return *(byte*)((int)cd11842f6f358714f1bf3366b3bf5784d + (int)(Math.Floor((double)P_1 * c4c6826eb2f2d96b6cbc3884338b6eac9) * (double)c6dc80483c80bfddc5b4e07abce776cc1) + (int)Math.Floor((double)P_0 * ce3f6b220861949ad7c9a8caad4d3de72));
	}

	private void c8f10b0134bf4b547c19c20f83dff5ec3(object P_0, EventArgs P_1)
	{
		if (((ListControl)ca8b9bb05a272ba884aa844f624f2d96b).SelectedIndex != 0)
		{
			__ldtoken(PictureAdjustFrm.c8f10b0134bf4b547c19c20f83dff5ec3(object, EventArgs));
			((Control)ca925d511b7693cd86af82b6d473fb027).Anchor = (AnchorStyles)5;
			((Control)c217da03c86f85b7308aedcd0dd311fcd).Anchor = (AnchorStyles)5;
			c217da03c86f85b7308aedcd0dd311fcd.SizeMode = (PictureBoxSizeMode)2;
			ca925d511b7693cd86af82b6d473fb027.SizeMode = (PictureBoxSizeMode)2;
		}
		else
		{
			((Control)c217da03c86f85b7308aedcd0dd311fcd).Width = cfdd28b747afbe52686772d0eed813027.Panel2.Width;
			((Control)c217da03c86f85b7308aedcd0dd311fcd).Height = cfdd28b747afbe52686772d0eed813027.Panel2.Height;
			((Control)c217da03c86f85b7308aedcd0dd311fcd).Anchor = (AnchorStyles)15;
			c217da03c86f85b7308aedcd0dd311fcd.SizeMode = (PictureBoxSizeMode)4;
			((Control)ca925d511b7693cd86af82b6d473fb027).Width = cfdd28b747afbe52686772d0eed813027.Panel1.Width;
			((Control)ca925d511b7693cd86af82b6d473fb027).Height = cfdd28b747afbe52686772d0eed813027.Panel1.Height;
			((Control)ca925d511b7693cd86af82b6d473fb027).Anchor = (AnchorStyles)15;
			ca925d511b7693cd86af82b6d473fb027.SizeMode = (PictureBoxSizeMode)4;
		}
	}

	private void ccfef7a1d32a65ced89ee45e9339c9182(object P_0, EventArgs P_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (!(cc7ec70b770e0c2b026fe759bb99b2b70.SelectedItem is GamePicture gamePicture))
			{
				__ldtoken(PictureAdjustFrm.ccfef7a1d32a65ced89ee45e9339c9182(object, EventArgs));
				return;
			}
			Image theImage = gamePicture.GetTheImage();
			c217da03c86f85b7308aedcd0dd311fcd.Image = ResizeBitmap(theImage, Convert.ToInt32(c41a66d6164b55e1b2aea2f3cafead82e.Value));
			c217da03c86f85b7308aedcd0dd311fcd.Image = c26f3f6e6b186490444b9e185f1837bac(c217da03c86f85b7308aedcd0dd311fcd.Image, Convert.ToInt32(c7acaeeea12eed9f5683e09309e9b8aaa.Value));
			((Control)c8475a831a422a7a9166bccdb5ffd0ee0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73860) + theImage.Height;
			((Control)caef83607ff3e72e2b887b48e0ece411c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73877) + theImage.Width;
			((Control)c2671d66aaa3292cae54af1c286842b28).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73892) + c217da03c86f85b7308aedcd0dd311fcd.Image.Width;
			((Control)ce48562bb358a91eeef71cbfa62c88f4a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73923) + c217da03c86f85b7308aedcd0dd311fcd.Image.Height;
			byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
			byte[] array2 = (byte[])TypeDescriptor.GetConverter(c217da03c86f85b7308aedcd0dd311fcd.Image).ConvertTo(c217da03c86f85b7308aedcd0dd311fcd.Image, typeof(byte[]));
			_ = array.Length / 1024;
			((Control)ca1ecddf3782a35a5feb56b1b330818da).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73956), array.Length / 1024);
			((Control)c29b8fdb8021855005c04ecd03dcdc6f3).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74005), array2.Length / 1024);
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		IEnumerator enumerator = cc7ec70b770e0c2b026fe759bb99b2b70.SelectedItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GamePicture gamePicture = (GamePicture)enumerator.Current;
				if (gamePicture == null)
				{
					__ldtoken(PictureAdjustFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
					continue;
				}
				Image theImage = gamePicture.GetTheImage();
				if (theImage == null)
				{
					__ldtoken(PictureAdjustFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
					continue;
				}
				theImage = ResizeBitmap(theImage, Convert.ToInt32(c41a66d6164b55e1b2aea2f3cafead82e.Value));
				theImage = c26f3f6e6b186490444b9e185f1837bac(theImage, Convert.ToInt32(c7acaeeea12eed9f5683e09309e9b8aaa.Value));
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					theImage.Save((Stream)memoryStream, theImage.RawFormat);
					SqlCeConnection dBConnection = Game.GetDBConnection();
					SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74120), dBConnection);
					sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74268), memoryStream.ToArray());
					sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37610), gamePicture.TheName);
					sqlCeCommand.ExecuteNonQuery();
					memoryStream.Close();
					memoryStream.Dispose();
				}
				catch
				{
				}
				theImage.Dispose();
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(PictureAdjustFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		c41a66d6164b55e1b2aea2f3cafead82e.Value = 100m;
		c7acaeeea12eed9f5683e09309e9b8aaa.Value = 80m;
		c61f2b38a5f8903a9c5f6251eb1ddfd81(null, null);
	}

	private void c20e9924908c9f53c02aeb212c6fdeecc(object P_0, EventArgs P_1)
	{
	}
}
