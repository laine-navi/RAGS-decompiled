using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using A;
using Rags.ragsgame.com;

namespace Rags;

public sealed class RagsShare : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private TabControl cff3baebe1925c32e759a585f1b66b4f9;

	private TabPage c8056e03901b460fdcab42036504c5ecb;

	private TabPage c684d59c2456e3f93a0e2883ff138ecf7;

	private WebBrowser cc48a17d37e521fba114004fea66a3741;

	private SplitContainer cfdd28b747afbe52686772d0eed813027;

	private Label cd374ab3d97be3419d92199b45d4d4b91;

	private DataGridView c4112f94ae889e6cf975e86d4bedccaaa;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private TextBox ccb12c65a561c28339d8f330a943ca26a;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private TextBox cf9a8d5a538c08f8dc70e75126110c7b8;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button c4574b5620f144bcd1cf128838e4adda4;

	private Button ce649b36d88e3003984cf5a0a00c32c08;

	private Button c77e4e0ac638e417bc244aac4adcb4747;

	private RichTextBox ce046fbda7c41edce18c2d36bc15662f8;

	private Label cd09080500aac71b8d7141db7ac20e5ef;

	private Label cbf176d04cc17c9e09054110ce9d7da2d;

	private SaveFileDialog c6c063cbe11b4b6925518729f5693f83b;

	private Label c4478cb503205dc21e898d70a4117c8bf;

	private Label c9d4ad01777c9f1fe617730d0b9adf386;

	private TextBox c070383ae7174447baefb8ed5ad1c886e;

	private Label c6761cb7a3178225f4ccff1b5433d216f;

	private Label c12e823c9f22ece17b7d43bff7c6dcd9b;

	private Label cbcebeb7dd4eeeaf3ba6421618ba7f6fa;

	private Button c5ed167eb17fca55759806ad9e6e7cd3b;

	private TextBox cb4c8af2037dfe68d2d54fe37fce6bfb1;

	private DataGridViewTextBoxColumn c3f09decd4f4db03f7e67579a85f50bac;

	private DataGridViewTextBoxColumn c22708ba2ab3d5565a3989b288e68edfb;

	private DataGridViewTextBoxColumn cb40086747c8e2fe1fef5d410a6b358f9;

	private DataGridViewTextBoxColumn c6228c76310d42a63484e6255d032399f;

	private DataGridViewTextBoxColumn cce46b3bbd88c354c9e1c7ae14619996a;

	private DataGridViewCheckBoxColumn c05d23c081e5534e47caab981665eb5fc;

	private DataGridViewTextBoxColumn c4cf0f9cf70221768159e9fcbffa5f0ef;

	private Label c0d947b99f1b2fc91432d24c0054b263f;

	private ProgressBar c81947c6854f1e9fb35737b9e3ad0b00a;

	private Timer c1a8600c9c68783a7d7d474cdb07a5e3a;

	private static bool c5b6b6216cba02f45cdb3abd0d81ee57e;

	public RagsShare()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RagsShare.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(RagsShare.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected Obj, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Obj, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected Obj, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected Obj, but got Unknown
		//IL_108f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1099: Expected Obj, but got Unknown
		//IL_1130: Unknown result type (might be due to invalid IL or missing references)
		//IL_113a: Expected Obj, but got Unknown
		//IL_1650: Unknown result type (might be due to invalid IL or missing references)
		//IL_165a: Expected Obj, but got Unknown
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsShare));
		cff3baebe1925c32e759a585f1b66b4f9 = new TabControl();
		c8056e03901b460fdcab42036504c5ecb = new TabPage();
		cc48a17d37e521fba114004fea66a3741 = new WebBrowser();
		c684d59c2456e3f93a0e2883ff138ecf7 = new TabPage();
		cfdd28b747afbe52686772d0eed813027 = new SplitContainer();
		cd374ab3d97be3419d92199b45d4d4b91 = new Label();
		c4112f94ae889e6cf975e86d4bedccaaa = new DataGridView();
		c3f09decd4f4db03f7e67579a85f50bac = new DataGridViewTextBoxColumn();
		c22708ba2ab3d5565a3989b288e68edfb = new DataGridViewTextBoxColumn();
		cb40086747c8e2fe1fef5d410a6b358f9 = new DataGridViewTextBoxColumn();
		c6228c76310d42a63484e6255d032399f = new DataGridViewTextBoxColumn();
		cce46b3bbd88c354c9e1c7ae14619996a = new DataGridViewTextBoxColumn();
		c05d23c081e5534e47caab981665eb5fc = new DataGridViewCheckBoxColumn();
		c4cf0f9cf70221768159e9fcbffa5f0ef = new DataGridViewTextBoxColumn();
		c0d947b99f1b2fc91432d24c0054b263f = new Label();
		c81947c6854f1e9fb35737b9e3ad0b00a = new ProgressBar();
		c5ed167eb17fca55759806ad9e6e7cd3b = new Button();
		c12e823c9f22ece17b7d43bff7c6dcd9b = new Label();
		cbcebeb7dd4eeeaf3ba6421618ba7f6fa = new Label();
		c4478cb503205dc21e898d70a4117c8bf = new Label();
		c9d4ad01777c9f1fe617730d0b9adf386 = new Label();
		c070383ae7174447baefb8ed5ad1c886e = new TextBox();
		c6761cb7a3178225f4ccff1b5433d216f = new Label();
		ce046fbda7c41edce18c2d36bc15662f8 = new RichTextBox();
		cd09080500aac71b8d7141db7ac20e5ef = new Label();
		cbf176d04cc17c9e09054110ce9d7da2d = new Label();
		cb4c8af2037dfe68d2d54fe37fce6bfb1 = new TextBox();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		ccb12c65a561c28339d8f330a943ca26a = new TextBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		cf9a8d5a538c08f8dc70e75126110c7b8 = new TextBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c4574b5620f144bcd1cf128838e4adda4 = new Button();
		ce649b36d88e3003984cf5a0a00c32c08 = new Button();
		c77e4e0ac638e417bc244aac4adcb4747 = new Button();
		c6c063cbe11b4b6925518729f5693f83b = new SaveFileDialog();
		c1a8600c9c68783a7d7d474cdb07a5e3a = new Timer(c501c89bc63d55bb522eac228aeeebb18);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).SuspendLayout();
		((Control)c8056e03901b460fdcab42036504c5ecb).SuspendLayout();
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).SuspendLayout();
		((ISupportInitialize)c4112f94ae889e6cf975e86d4bedccaaa).BeginInit();
		((Control)this).SuspendLayout();
		cff3baebe1925c32e759a585f1b66b4f9.Alignment = (TabAlignment)1;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)c8056e03901b460fdcab42036504c5ecb);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)c684d59c2456e3f93a0e2883ff138ecf7);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Dock = (DockStyle)5;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Location = new Point(0, 0);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14);
		cff3baebe1925c32e759a585f1b66b4f9.SelectedIndex = 0;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Size = new Size(747, 498);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).TabIndex = 0;
		((Control)c8056e03901b460fdcab42036504c5ecb).Controls.Add((Control)(object)cc48a17d37e521fba114004fea66a3741);
		c8056e03901b460fdcab42036504c5ecb.Location = new Point(4, 4);
		((Control)c8056e03901b460fdcab42036504c5ecb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37);
		((Control)c8056e03901b460fdcab42036504c5ecb).Padding = new Padding(3);
		((Control)c8056e03901b460fdcab42036504c5ecb).Size = new Size(739, 472);
		c8056e03901b460fdcab42036504c5ecb.TabIndex = 0;
		((Control)c8056e03901b460fdcab42036504c5ecb).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109133);
		c8056e03901b460fdcab42036504c5ecb.UseVisualStyleBackColor = true;
		((Control)cc48a17d37e521fba114004fea66a3741).Dock = (DockStyle)5;
		((Control)cc48a17d37e521fba114004fea66a3741).Location = new Point(3, 3);
		((Control)cc48a17d37e521fba114004fea66a3741).MinimumSize = new Size(20, 20);
		((Control)cc48a17d37e521fba114004fea66a3741).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109152);
		((Control)cc48a17d37e521fba114004fea66a3741).Size = new Size(733, 466);
		((Control)cc48a17d37e521fba114004fea66a3741).TabIndex = 0;
		cc48a17d37e521fba114004fea66a3741.Url = new Uri(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109175), UriKind.Absolute);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Controls.Add((Control)(object)cfdd28b747afbe52686772d0eed813027);
		c684d59c2456e3f93a0e2883ff138ecf7.Location = new Point(4, 4);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Padding = new Padding(3);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Size = new Size(739, 472);
		c684d59c2456e3f93a0e2883ff138ecf7.TabIndex = 1;
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109250);
		c684d59c2456e3f93a0e2883ff138ecf7.UseVisualStyleBackColor = true;
		cfdd28b747afbe52686772d0eed813027.BorderStyle = (BorderStyle)1;
		cfdd28b747afbe52686772d0eed813027.Dock = (DockStyle)5;
		((Control)cfdd28b747afbe52686772d0eed813027).Location = new Point(3, 3);
		((Control)cfdd28b747afbe52686772d0eed813027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15938);
		cfdd28b747afbe52686772d0eed813027.Orientation = (Orientation)0;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)cd374ab3d97be3419d92199b45d4d4b91);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c4112f94ae889e6cf975e86d4bedccaaa);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c0d947b99f1b2fc91432d24c0054b263f);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c81947c6854f1e9fb35737b9e3ad0b00a);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c5ed167eb17fca55759806ad9e6e7cd3b);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c12e823c9f22ece17b7d43bff7c6dcd9b);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cbcebeb7dd4eeeaf3ba6421618ba7f6fa);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c4478cb503205dc21e898d70a4117c8bf);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c9d4ad01777c9f1fe617730d0b9adf386);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c070383ae7174447baefb8ed5ad1c886e);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c6761cb7a3178225f4ccff1b5433d216f);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)ce046fbda7c41edce18c2d36bc15662f8);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cd09080500aac71b8d7141db7ac20e5ef);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cbf176d04cc17c9e09054110ce9d7da2d);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cb4c8af2037dfe68d2d54fe37fce6bfb1);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)ccb12c65a561c28339d8f330a943ca26a);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)cf9a8d5a538c08f8dc70e75126110c7b8);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c4574b5620f144bcd1cf128838e4adda4);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)ce649b36d88e3003984cf5a0a00c32c08);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c77e4e0ac638e417bc244aac4adcb4747);
		((Control)cfdd28b747afbe52686772d0eed813027).Size = new Size(733, 466);
		cfdd28b747afbe52686772d0eed813027.SplitterDistance = 248;
		((Control)cfdd28b747afbe52686772d0eed813027).TabIndex = 0;
		((Control)cd374ab3d97be3419d92199b45d4d4b91).AutoSize = true;
		((Control)cd374ab3d97be3419d92199b45d4d4b91).Location = new Point(4, 4);
		((Control)cd374ab3d97be3419d92199b45d4d4b91).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109271);
		((Control)cd374ab3d97be3419d92199b45d4d4b91).Size = new Size(71, 13);
		((Control)cd374ab3d97be3419d92199b45d4d4b91).TabIndex = 1;
		((Control)cd374ab3d97be3419d92199b45d4d4b91).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109296);
		c4112f94ae889e6cf975e86d4bedccaaa.AllowUserToAddRows = false;
		c4112f94ae889e6cf975e86d4bedccaaa.AllowUserToDeleteRows = false;
		((Control)c4112f94ae889e6cf975e86d4bedccaaa).Anchor = (AnchorStyles)15;
		c4112f94ae889e6cf975e86d4bedccaaa.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		c4112f94ae889e6cf975e86d4bedccaaa.Columns.AddRange(new DataGridViewColumn[7]
		{
			(DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac,
			(DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb,
			(DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9,
			(DataGridViewColumn)c6228c76310d42a63484e6255d032399f,
			(DataGridViewColumn)cce46b3bbd88c354c9e1c7ae14619996a,
			(DataGridViewColumn)c05d23c081e5534e47caab981665eb5fc,
			(DataGridViewColumn)c4cf0f9cf70221768159e9fcbffa5f0ef
		});
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Window;
		val.Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.ControlText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)2;
		c4112f94ae889e6cf975e86d4bedccaaa.DefaultCellStyle = val;
		((Control)c4112f94ae889e6cf975e86d4bedccaaa).Location = new Point(0, 23);
		c4112f94ae889e6cf975e86d4bedccaaa.MultiSelect = false;
		((Control)c4112f94ae889e6cf975e86d4bedccaaa).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109321);
		c4112f94ae889e6cf975e86d4bedccaaa.ReadOnly = true;
		c4112f94ae889e6cf975e86d4bedccaaa.RowHeadersWidth = 4;
		c4112f94ae889e6cf975e86d4bedccaaa.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)c4112f94ae889e6cf975e86d4bedccaaa).Size = new Size(728, 223);
		((Control)c4112f94ae889e6cf975e86d4bedccaaa).TabIndex = 0;
		c4112f94ae889e6cf975e86d4bedccaaa.SelectionChanged += cc6584b828af350f2b72eb9fc4b40b1cc;
		((DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac).FillWeight = 20f;
		((DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173);
		((DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109348);
		((DataGridViewBand)c3f09decd4f4db03f7e67579a85f50bac).ReadOnly = true;
		((DataGridViewColumn)c3f09decd4f4db03f7e67579a85f50bac).Width = 60;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).FillWeight = 25f;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109367);
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109384);
		((DataGridViewBand)c22708ba2ab3d5565a3989b288e68edfb).ReadOnly = true;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).Width = 74;
		((DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9).FillWeight = 17f;
		((DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109399);
		((DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109418);
		((DataGridViewBand)cb40086747c8e2fe1fef5d410a6b358f9).ReadOnly = true;
		((DataGridViewColumn)cb40086747c8e2fe1fef5d410a6b358f9).Width = 85;
		((DataGridViewColumn)c6228c76310d42a63484e6255d032399f).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)c6228c76310d42a63484e6255d032399f).FillWeight = 33f;
		((DataGridViewColumn)c6228c76310d42a63484e6255d032399f).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109447);
		((DataGridViewColumn)c6228c76310d42a63484e6255d032399f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109462);
		((DataGridViewBand)c6228c76310d42a63484e6255d032399f).ReadOnly = true;
		((DataGridViewColumn)c6228c76310d42a63484e6255d032399f).Width = 73;
		((DataGridViewColumn)cce46b3bbd88c354c9e1c7ae14619996a).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)cce46b3bbd88c354c9e1c7ae14619996a).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109495);
		((DataGridViewColumn)cce46b3bbd88c354c9e1c7ae14619996a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109504);
		((DataGridViewBand)cce46b3bbd88c354c9e1c7ae14619996a).ReadOnly = true;
		((DataGridViewColumn)cce46b3bbd88c354c9e1c7ae14619996a).Width = 54;
		((DataGridViewColumn)c05d23c081e5534e47caab981665eb5fc).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)c05d23c081e5534e47caab981665eb5fc).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109519);
		((DataGridViewColumn)c05d23c081e5534e47caab981665eb5fc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109536);
		((DataGridViewBand)c05d23c081e5534e47caab981665eb5fc).ReadOnly = true;
		((DataGridViewColumn)c05d23c081e5534e47caab981665eb5fc).Width = 46;
		((DataGridViewColumn)c4cf0f9cf70221768159e9fcbffa5f0ef).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109559);
		((DataGridViewColumn)c4cf0f9cf70221768159e9fcbffa5f0ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109582);
		((DataGridViewBand)c4cf0f9cf70221768159e9fcbffa5f0ef).ReadOnly = true;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).AutoSize = true;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Location = new Point(253, 191);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(723);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Size = new Size(72, 13);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).TabIndex = 20;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109603);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Anchor = (AnchorStyles)13;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = false;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Location = new Point(331, 186);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109628);
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Size = new Size(299, 23);
		c81947c6854f1e9fb35737b9e3ad0b00a.Step = 1;
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).TabIndex = 19;
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Anchor = (AnchorStyles)6;
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Location = new Point(164, 186);
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109653);
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Size = new Size(75, 23);
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).TabIndex = 18;
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12526);
		((ButtonBase)c5ed167eb17fca55759806ad9e6e7cd3b).UseVisualStyleBackColor = true;
		((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Click += c908faed6621ad8016f2abc115719515f;
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).AutoSize = true;
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).Location = new Point(103, 159);
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109672);
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).Size = new Size(13, 13);
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).TabIndex = 17;
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109687);
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).AutoSize = true;
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).Location = new Point(7, 159);
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109690);
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).Size = new Size(61, 13);
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).TabIndex = 16;
		((Control)cbcebeb7dd4eeeaf3ba6421618ba7f6fa).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109703);
		((Control)c4478cb503205dc21e898d70a4117c8bf).AutoSize = true;
		((Control)c4478cb503205dc21e898d70a4117c8bf).Location = new Point(103, 135);
		((Control)c4478cb503205dc21e898d70a4117c8bf).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109726);
		((Control)c4478cb503205dc21e898d70a4117c8bf).Size = new Size(13, 13);
		((Control)c4478cb503205dc21e898d70a4117c8bf).TabIndex = 15;
		((Control)c4478cb503205dc21e898d70a4117c8bf).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109687);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).AutoSize = true;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Location = new Point(7, 135);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(780);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Size = new Size(90, 13);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).TabIndex = 14;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109751);
		((Control)c070383ae7174447baefb8ed5ad1c886e).Location = new Point(79, 109);
		((Control)c070383ae7174447baefb8ed5ad1c886e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109784);
		((TextBoxBase)c070383ae7174447baefb8ed5ad1c886e).ReadOnly = true;
		((Control)c070383ae7174447baefb8ed5ad1c886e).Size = new Size(177, 20);
		((Control)c070383ae7174447baefb8ed5ad1c886e).TabIndex = 13;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).AutoSize = true;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Location = new Point(7, 112);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(875);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Size = new Size(68, 13);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).TabIndex = 12;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109811);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Anchor = (AnchorStyles)15;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Location = new Point(331, 8);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109834);
		((TextBoxBase)ce046fbda7c41edce18c2d36bc15662f8).ReadOnly = true;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Size = new Size(395, 172);
		((Control)ce046fbda7c41edce18c2d36bc15662f8).TabIndex = 11;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Text = "";
		ce046fbda7c41edce18c2d36bc15662f8.LinkClicked += cb41ddf9a3cc564074ea52241298edd51;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).AutoSize = true;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Location = new Point(262, 8);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(938);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Size = new Size(63, 13);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).TabIndex = 10;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17542);
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).AutoSize = true;
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).Location = new Point(7, 84);
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109861);
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).Size = new Size(191, 17);
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).TabIndex = 9;
		((Control)cbf176d04cc17c9e09054110ce9d7da2d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109898);
		((Control)cb4c8af2037dfe68d2d54fe37fce6bfb1).Location = new Point(79, 57);
		((Control)cb4c8af2037dfe68d2d54fe37fce6bfb1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109951);
		((TextBoxBase)cb4c8af2037dfe68d2d54fe37fce6bfb1).ReadOnly = true;
		((Control)cb4c8af2037dfe68d2d54fe37fce6bfb1).Size = new Size(177, 20);
		((Control)cb4c8af2037dfe68d2d54fe37fce6bfb1).TabIndex = 8;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(7, 60);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(995);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(52, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 7;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109972);
		((Control)ccb12c65a561c28339d8f330a943ca26a).Location = new Point(79, 31);
		((Control)ccb12c65a561c28339d8f330a943ca26a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109991);
		((TextBoxBase)ccb12c65a561c28339d8f330a943ca26a).ReadOnly = true;
		((Control)ccb12c65a561c28339d8f330a943ca26a).Size = new Size(177, 20);
		((Control)ccb12c65a561c28339d8f330a943ca26a).TabIndex = 6;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(7, 34);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1050);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(41, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 5;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110018);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Location = new Point(79, 5);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110033);
		((TextBoxBase)cf9a8d5a538c08f8dc70e75126110c7b8).ReadOnly = true;
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Size = new Size(177, 20);
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).TabIndex = 4;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(7, 8);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(69, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 3;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110056);
		((Control)c4574b5620f144bcd1cf128838e4adda4).Anchor = (AnchorStyles)10;
		((Control)c4574b5620f144bcd1cf128838e4adda4).Location = new Point(636, 186);
		((Control)c4574b5620f144bcd1cf128838e4adda4).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110079);
		((Control)c4574b5620f144bcd1cf128838e4adda4).Size = new Size(90, 23);
		((Control)c4574b5620f144bcd1cf128838e4adda4).TabIndex = 2;
		((Control)c4574b5620f144bcd1cf128838e4adda4).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110098);
		((ButtonBase)c4574b5620f144bcd1cf128838e4adda4).UseVisualStyleBackColor = true;
		((Control)c4574b5620f144bcd1cf128838e4adda4).Click += c23b9eb96e1d1678909af611e1514fc42;
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Anchor = (AnchorStyles)6;
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Location = new Point(85, 186);
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110111);
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Size = new Size(75, 23);
		((Control)ce649b36d88e3003984cf5a0a00c32c08).TabIndex = 1;
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110128);
		((ButtonBase)ce649b36d88e3003984cf5a0a00c32c08).UseVisualStyleBackColor = true;
		((Control)ce649b36d88e3003984cf5a0a00c32c08).Click += c55de1ea674af84854b8d9e3279ce9540;
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Anchor = (AnchorStyles)6;
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Location = new Point(6, 186);
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110139);
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Size = new Size(75, 23);
		((Control)c77e4e0ac638e417bc244aac4adcb4747).TabIndex = 0;
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110162);
		((ButtonBase)c77e4e0ac638e417bc244aac4adcb4747).UseVisualStyleBackColor = true;
		((Control)c77e4e0ac638e417bc244aac4adcb4747).Click += ce1dd0b9b8b173b9146aea9655ab4e0e8;
		((FileDialog)c6c063cbe11b4b6925518729f5693f83b).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110179);
		((FileDialog)c6c063cbe11b4b6925518729f5693f83b).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110212);
		c1a8600c9c68783a7d7d474cdb07a5e3a.Enabled = true;
		c1a8600c9c68783a7d7d474cdb07a5e3a.Tick += c6c81e57d710c9ddb0da56132be15a894;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(747, 498);
		((Control)this).Controls.Add((Control)(object)cff3baebe1925c32e759a585f1b66b4f9);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110245);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(109250);
		((Form)this).Load += c4eee079917e648f27f99801353d25ed7;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).ResumeLayout(false);
		((Control)c8056e03901b460fdcab42036504c5ecb).ResumeLayout(false);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).ResumeLayout(false);
		((ISupportInitialize)c4112f94ae889e6cf975e86d4bedccaaa).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void c4eee079917e648f27f99801353d25ed7(object P_0, EventArgs P_1)
	{
		c39da9ea2e8c01283e4fb0983a9896b65();
		c5b6b6216cba02f45cdb3abd0d81ee57e = false;
	}

	private void cf2ead3d3327d6ce01c6c1e2a47c656b9(object P_0, GetShareDataSummaryCompletedEventArgs P_1)
	{
		c4112f94ae889e6cf975e86d4bedccaaa.Rows.Clear();
		if (P_1.Error != null)
		{
			c4112f94ae889e6cf975e86d4bedccaaa.Rows.Add(new object[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110264) + P_1.Error.Message });
		}
		else if (P_1.Result != null)
		{
			__ldtoken(RagsShare.cf2ead3d3327d6ce01c6c1e2a47c656b9(object, GetShareDataSummaryCompletedEventArgs));
			object[] result = P_1.Result;
			object[] array = result;
			for (int i = 0; i < array.Length; i++)
			{
				__ldtoken(RagsShare.cf2ead3d3327d6ce01c6c1e2a47c656b9(object, GetShareDataSummaryCompletedEventArgs));
				object obj = array[i];
				Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)obj;
				int num = c4112f94ae889e6cf975e86d4bedccaaa.Rows.Add(new object[7] { shareData.sharename, shareData.category, shareData.downloads, shareData.lastupdated, shareData.usernickname, shareData.bexplicit, shareData.RagsVersion });
				((DataGridViewBand)c4112f94ae889e6cf975e86d4bedccaaa.Rows[num]).Tag = shareData;
			}
			if (c5b6b6216cba02f45cdb3abd0d81ee57e)
			{
				__ldtoken(RagsShare.cf2ead3d3327d6ce01c6c1e2a47c656b9(object, GetShareDataSummaryCompletedEventArgs));
				return;
			}
			c5b6b6216cba02f45cdb3abd0d81ee57e = true;
			c4112f94ae889e6cf975e86d4bedccaaa.Sort(c4112f94ae889e6cf975e86d4bedccaaa.Columns[3], ListSortDirection.Descending);
		}
		else
		{
			c4112f94ae889e6cf975e86d4bedccaaa.Rows.Add(new object[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110277) });
		}
	}

	private void c39da9ea2e8c01283e4fb0983a9896b65()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		CheckUpdates checkUpdates = new CheckUpdates();
		try
		{
			checkUpdates.GetShareDataSummaryCompleted += cf2ead3d3327d6ce01c6c1e2a47c656b9;
			checkUpdates.GetShareDataSummaryAsync();
		}
		catch
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110374));
		}
		((Component)(object)checkUpdates).Dispose();
		cc6584b828af350f2b72eb9fc4b40b1cc(null, null);
	}

	private void c55de1ea674af84854b8d9e3279ce9540(object P_0, EventArgs P_1)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (LockData.IsLicensed(bdisplay: false, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110518)))
		{
			RagsShareUpload ragsShareUpload = new RagsShareUpload(Update: false, null);
			((Form)ragsShareUpload).ShowDialog();
			c39da9ea2e8c01283e4fb0983a9896b65();
		}
		else
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110575));
		}
	}

	private void c586897bc779b265de3b532e1247e9f9a(object P_0, DownloadShareCompletedEventArgs P_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = false;
		if (P_1.Error != null)
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110702) + P_1.Error.Message);
		}
		else if (P_1.Result != null)
		{
			__ldtoken(RagsShare.c586897bc779b265de3b532e1247e9f9a(object, DownloadShareCompletedEventArgs));
			byte[] result = P_1.Result;
			File.WriteAllBytes(P_1.UserState.ToString(), result);
			c39da9ea2e8c01283e4fb0983a9896b65();
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110735));
		}
		else
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110277));
		}
	}

	private void ce1dd0b9b8b173b9146aea9655ab4e0e8(object P_0, EventArgs P_1)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Invalid comparison between Unknown and I4
		if (((BaseCollection)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows).Count != 1)
		{
			__ldtoken(RagsShare.ce1dd0b9b8b173b9146aea9655ab4e0e8(object, EventArgs));
		}
		else if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110776), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(111958), (MessageBoxButtons)4) == 6)
		{
			Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows[0]).Tag;
			((FileDialog)c6c063cbe11b4b6925518729f5693f83b).FileName = shareData.sharename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(111995);
			if ((int)((CommonDialog)c6c063cbe11b4b6925518729f5693f83b).ShowDialog() != 1)
			{
				__ldtoken(RagsShare.ce1dd0b9b8b173b9146aea9655ab4e0e8(object, EventArgs));
				return;
			}
			CheckUpdates checkUpdates = new CheckUpdates();
			checkUpdates.DownloadShareCompleted += c586897bc779b265de3b532e1247e9f9a;
			checkUpdates.DownloadShareAsync(shareData.index, ((FileDialog)c6c063cbe11b4b6925518729f5693f83b).FileName);
			((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled = true;
		}
	}

	private void cc6584b828af350f2b72eb9fc4b40b1cc(object P_0, EventArgs P_1)
	{
		if (((BaseCollection)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows).Count <= 0)
		{
			__ldtoken(RagsShare.cc6584b828af350f2b72eb9fc4b40b1cc(object, EventArgs));
			return;
		}
		Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows[0]).Tag;
		if (shareData == null)
		{
			__ldtoken(RagsShare.cc6584b828af350f2b72eb9fc4b40b1cc(object, EventArgs));
			return;
		}
		((Control)cf9a8d5a538c08f8dc70e75126110c7b8).Text = shareData.sharename;
		((Control)ccb12c65a561c28339d8f330a943ca26a).Text = shareData.usernickname;
		((Control)cb4c8af2037dfe68d2d54fe37fce6bfb1).Text = shareData.category;
		((Control)ce046fbda7c41edce18c2d36bc15662f8).Text = shareData.description;
		((Control)c4478cb503205dc21e898d70a4117c8bf).Text = shareData.downloads.ToString();
		((Control)c070383ae7174447baefb8ed5ad1c886e).Text = shareData.lastupdated.ToString();
		((Control)c12e823c9f22ece17b7d43bff7c6dcd9b).Text = shareData.size / 1024 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112004);
		if (!(shareData.useremail == LockData.GetEmail()))
		{
			__ldtoken(RagsShare.cc6584b828af350f2b72eb9fc4b40b1cc(object, EventArgs));
			((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Enabled = false;
			((Control)c4574b5620f144bcd1cf128838e4adda4).Enabled = false;
		}
		else
		{
			((Control)c5ed167eb17fca55759806ad9e6e7cd3b).Enabled = true;
			((Control)c4574b5620f144bcd1cf128838e4adda4).Enabled = true;
		}
		if (!shareData.bexplicit)
		{
			__ldtoken(RagsShare.cc6584b828af350f2b72eb9fc4b40b1cc(object, EventArgs));
			((Control)cbf176d04cc17c9e09054110ce9d7da2d).Visible = false;
		}
		else
		{
			((Control)cbf176d04cc17c9e09054110ce9d7da2d).Visible = true;
		}
	}

	private void c908faed6621ad8016f2abc115719515f(object P_0, EventArgs P_1)
	{
		if (((BaseCollection)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows).Count <= 0)
		{
			__ldtoken(RagsShare.c908faed6621ad8016f2abc115719515f(object, EventArgs));
			return;
		}
		Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows[0]).Tag;
		CheckUpdates checkUpdates = new CheckUpdates();
		checkUpdates.RemoveShare(shareData.index, LockData.GetEmail(), LockData.GetKey());
		c39da9ea2e8c01283e4fb0983a9896b65();
	}

	private void c23b9eb96e1d1678909af611e1514fc42(object P_0, EventArgs P_1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110518)))
		{
			__ldtoken(RagsShare.c23b9eb96e1d1678909af611e1514fc42(object, EventArgs));
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(110575));
		}
		else
		{
			RagsShareUpload ragsShareUpload = new RagsShareUpload(Update: true, (Rags.ragsgame.com.ShareData)((DataGridViewBand)c4112f94ae889e6cf975e86d4bedccaaa.SelectedRows[0]).Tag);
			((Form)ragsShareUpload).ShowDialog();
			c39da9ea2e8c01283e4fb0983a9896b65();
		}
	}

	private void cb41ddf9a3cc564074ea52241298edd51(object P_0, LinkClickedEventArgs P_1)
	{
		Process.Start(P_1.LinkText);
	}

	private void c6c81e57d710c9ddb0da56132be15a894(object P_0, EventArgs P_1)
	{
		if (((Control)c81947c6854f1e9fb35737b9e3ad0b00a).Enabled)
		{
			if (c81947c6854f1e9fb35737b9e3ad0b00a.Value != 100)
			{
				__ldtoken(RagsShare.c6c81e57d710c9ddb0da56132be15a894(object, EventArgs));
			}
			else
			{
				c81947c6854f1e9fb35737b9e3ad0b00a.Value = 1;
			}
			c81947c6854f1e9fb35737b9e3ad0b00a.Increment(1);
		}
	}
}
