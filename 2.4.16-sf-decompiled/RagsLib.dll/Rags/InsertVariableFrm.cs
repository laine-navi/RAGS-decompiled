using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class InsertVariableFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button c1af1b0df6897c5f60041235bc6528b12;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	public ListBox lbSysVariables;

	private TabPage c8056e03901b460fdcab42036504c5ecb;

	private TabPage c684d59c2456e3f93a0e2883ff138ecf7;

	public ListBox lbVariables;

	private TabPage c5f7350fd3246fdffb78d62e89539b883;

	public ListBox lbCustProp;

	private TabPage cd17d0986f8a2a1d498ee138a6487eb60;

	public TabControl tabControl1;

	private Label c6761cb7a3178225f4ccff1b5433d216f;

	private ComboBox c8c29e162c66230cf8f34a6fc8658446f;

	private Label cd09080500aac71b8d7141db7ac20e5ef;

	private ComboBox c697270965529cf3885777182a8102767;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private ComboBox c7f3e39b09538603e028e43b76b67e35e;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private ComboBox c8d30a83c9cb76830bc8f6dc5e64a8ad8;

	private Label c0d947b99f1b2fc91432d24c0054b263f;

	private Label c9d4ad01777c9f1fe617730d0b9adf386;

	private ComboBox cf4a7f4f907aa151be819437098030a95;

	public TextBox tbText;

	private Game c54f9a911545745b85ae6f74355697f8b;

	public InsertVariableFrm(ref Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c54f9a911545745b85ae6f74355697f8b = curgame;
		((ListControl)c8d30a83c9cb76830bc8f6dc5e64a8ad8).SelectedIndex = 0;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(InsertVariableFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
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
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InsertVariableFrm));
		lbSysVariables = new ListBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c1af1b0df6897c5f60041235bc6528b12 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		tabControl1 = new TabControl();
		c8056e03901b460fdcab42036504c5ecb = new TabPage();
		c684d59c2456e3f93a0e2883ff138ecf7 = new TabPage();
		lbVariables = new ListBox();
		c5f7350fd3246fdffb78d62e89539b883 = new TabPage();
		lbCustProp = new ListBox();
		cd17d0986f8a2a1d498ee138a6487eb60 = new TabPage();
		c0d947b99f1b2fc91432d24c0054b263f = new Label();
		tbText = new TextBox();
		c9d4ad01777c9f1fe617730d0b9adf386 = new Label();
		cf4a7f4f907aa151be819437098030a95 = new ComboBox();
		c6761cb7a3178225f4ccff1b5433d216f = new Label();
		c8c29e162c66230cf8f34a6fc8658446f = new ComboBox();
		cd09080500aac71b8d7141db7ac20e5ef = new Label();
		c697270965529cf3885777182a8102767 = new ComboBox();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		c7f3e39b09538603e028e43b76b67e35e = new ComboBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c8d30a83c9cb76830bc8f6dc5e64a8ad8 = new ComboBox();
		((Control)tabControl1).SuspendLayout();
		((Control)c8056e03901b460fdcab42036504c5ecb).SuspendLayout();
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).SuspendLayout();
		((Control)c5f7350fd3246fdffb78d62e89539b883).SuspendLayout();
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lbSysVariables).Dock = (DockStyle)5;
		((ListControl)lbSysVariables).FormattingEnabled = true;
		((Control)lbSysVariables).Location = new Point(3, 3);
		((Control)lbSysVariables).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(369);
		((Control)lbSysVariables).Size = new Size(445, 315);
		((Control)lbSysVariables).TabIndex = 0;
		((Control)lbSysVariables).DoubleClick += c093b6a99a3eaba8e0c2b3d64fcc0206b;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(157, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 1;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(398);
		((Control)c1af1b0df6897c5f60041235bc6528b12).Anchor = (AnchorStyles)2;
		((Control)c1af1b0df6897c5f60041235bc6528b12).Location = new Point(104, 378);
		((Control)c1af1b0df6897c5f60041235bc6528b12).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(461);
		((Control)c1af1b0df6897c5f60041235bc6528b12).Size = new Size(86, 23);
		((Control)c1af1b0df6897c5f60041235bc6528b12).TabIndex = 2;
		((Control)c1af1b0df6897c5f60041235bc6528b12).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(480);
		((ButtonBase)c1af1b0df6897c5f60041235bc6528b12).UseVisualStyleBackColor = true;
		((Control)c1af1b0df6897c5f60041235bc6528b12).Click += cb5ced9bc7b7b8ad854510f110508b401;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Anchor = (AnchorStyles)2;
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(292, 378);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(511);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(86, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 3;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		tabControl1.Alignment = (TabAlignment)1;
		((Control)tabControl1).Anchor = (AnchorStyles)15;
		((Control)tabControl1).Controls.Add((Control)(object)c8056e03901b460fdcab42036504c5ecb);
		((Control)tabControl1).Controls.Add((Control)(object)c684d59c2456e3f93a0e2883ff138ecf7);
		((Control)tabControl1).Controls.Add((Control)(object)c5f7350fd3246fdffb78d62e89539b883);
		((Control)tabControl1).Controls.Add((Control)(object)cd17d0986f8a2a1d498ee138a6487eb60);
		((Control)tabControl1).Location = new Point(12, 25);
		((Control)tabControl1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14);
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(459, 347);
		((Control)tabControl1).TabIndex = 4;
		((Control)c8056e03901b460fdcab42036504c5ecb).Controls.Add((Control)(object)lbSysVariables);
		c8056e03901b460fdcab42036504c5ecb.Location = new Point(4, 4);
		((Control)c8056e03901b460fdcab42036504c5ecb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37);
		((Control)c8056e03901b460fdcab42036504c5ecb).Padding = new Padding(3);
		((Control)c8056e03901b460fdcab42036504c5ecb).Size = new Size(451, 321);
		c8056e03901b460fdcab42036504c5ecb.TabIndex = 0;
		((Control)c8056e03901b460fdcab42036504c5ecb).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(543);
		c8056e03901b460fdcab42036504c5ecb.UseVisualStyleBackColor = true;
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Controls.Add((Control)(object)lbVariables);
		c684d59c2456e3f93a0e2883ff138ecf7.Location = new Point(4, 4);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Padding = new Padding(3);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Size = new Size(451, 321);
		c684d59c2456e3f93a0e2883ff138ecf7.TabIndex = 1;
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(576);
		c684d59c2456e3f93a0e2883ff138ecf7.UseVisualStyleBackColor = true;
		((Control)lbVariables).Dock = (DockStyle)5;
		((ListControl)lbVariables).FormattingEnabled = true;
		((Control)lbVariables).Location = new Point(3, 3);
		((Control)lbVariables).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(595);
		((Control)lbVariables).Size = new Size(445, 315);
		((Control)lbVariables).TabIndex = 1;
		((Control)lbVariables).DoubleClick += c093b6a99a3eaba8e0c2b3d64fcc0206b;
		((Control)c5f7350fd3246fdffb78d62e89539b883).Controls.Add((Control)(object)lbCustProp);
		c5f7350fd3246fdffb78d62e89539b883.Location = new Point(4, 4);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(618);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Padding = new Padding(3);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Size = new Size(451, 321);
		c5f7350fd3246fdffb78d62e89539b883.TabIndex = 2;
		((Control)c5f7350fd3246fdffb78d62e89539b883).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(635);
		c5f7350fd3246fdffb78d62e89539b883.UseVisualStyleBackColor = true;
		((Control)lbCustProp).Dock = (DockStyle)5;
		((ListControl)lbCustProp).FormattingEnabled = true;
		((Control)lbCustProp).Location = new Point(3, 3);
		((Control)lbCustProp).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(670);
		((Control)lbCustProp).Size = new Size(445, 315);
		((Control)lbCustProp).TabIndex = 2;
		((Control)lbCustProp).DoubleClick += c093b6a99a3eaba8e0c2b3d64fcc0206b;
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c0d947b99f1b2fc91432d24c0054b263f);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)tbText);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c9d4ad01777c9f1fe617730d0b9adf386);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)cf4a7f4f907aa151be819437098030a95);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c6761cb7a3178225f4ccff1b5433d216f);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c8c29e162c66230cf8f34a6fc8658446f);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)cd09080500aac71b8d7141db7ac20e5ef);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c697270965529cf3885777182a8102767);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c7f3e39b09538603e028e43b76b67e35e);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c8d30a83c9cb76830bc8f6dc5e64a8ad8);
		cd17d0986f8a2a1d498ee138a6487eb60.Location = new Point(4, 4);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(691);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Padding = new Padding(3);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Size = new Size(451, 321);
		cd17d0986f8a2a1d498ee138a6487eb60.TabIndex = 3;
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(708);
		cd17d0986f8a2a1d498ee138a6487eb60.UseVisualStyleBackColor = true;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).AutoSize = true;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Location = new Point(6, 279);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(723);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Size = new Size(76, 13);
		((Control)c0d947b99f1b2fc91432d24c0054b263f).TabIndex = 11;
		((Control)c0d947b99f1b2fc91432d24c0054b263f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(736);
		((Control)tbText).Anchor = (AnchorStyles)14;
		((Control)tbText).Location = new Point(6, 295);
		((Control)tbText).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(767);
		((Control)tbText).Size = new Size(439, 20);
		((Control)tbText).TabIndex = 10;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).AutoSize = true;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Location = new Point(179, 66);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(780);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Size = new Size(103, 13);
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).TabIndex = 9;
		((Control)c9d4ad01777c9f1fe617730d0b9adf386).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(793);
		((Control)cf4a7f4f907aa151be819437098030a95).Enabled = false;
		((ListControl)cf4a7f4f907aa151be819437098030a95).FormattingEnabled = true;
		((Control)cf4a7f4f907aa151be819437098030a95).Location = new Point(179, 82);
		((Control)cf4a7f4f907aa151be819437098030a95).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(834);
		((Control)cf4a7f4f907aa151be819437098030a95).Size = new Size(214, 21);
		cf4a7f4f907aa151be819437098030a95.Sorted = true;
		((Control)cf4a7f4f907aa151be819437098030a95).TabIndex = 8;
		cf4a7f4f907aa151be819437098030a95.SelectedIndexChanged += cd53e46e19494b699b9c38d9174ae4fe5;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).AutoSize = true;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Location = new Point(6, 66);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(875);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Size = new Size(71, 13);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).TabIndex = 7;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(888);
		((Control)c8c29e162c66230cf8f34a6fc8658446f).Enabled = false;
		((ListControl)c8c29e162c66230cf8f34a6fc8658446f).FormattingEnabled = true;
		((Control)c8c29e162c66230cf8f34a6fc8658446f).Location = new Point(6, 82);
		((Control)c8c29e162c66230cf8f34a6fc8658446f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(913);
		((Control)c8c29e162c66230cf8f34a6fc8658446f).Size = new Size(151, 21);
		c8c29e162c66230cf8f34a6fc8658446f.Sorted = true;
		((Control)c8c29e162c66230cf8f34a6fc8658446f).TabIndex = 6;
		c8c29e162c66230cf8f34a6fc8658446f.SelectedIndexChanged += c30097a2de751d99da4cbac4b6a8d49f9;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).AutoSize = true;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Location = new Point(256, 10);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(938);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Size = new Size(49, 13);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).TabIndex = 5;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(951);
		((ListControl)c697270965529cf3885777182a8102767).FormattingEnabled = true;
		((Control)c697270965529cf3885777182a8102767).Location = new Point(256, 26);
		((Control)c697270965529cf3885777182a8102767).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(972);
		((Control)c697270965529cf3885777182a8102767).Size = new Size(189, 21);
		c697270965529cf3885777182a8102767.Sorted = true;
		((Control)c697270965529cf3885777182a8102767).TabIndex = 4;
		c697270965529cf3885777182a8102767.SelectedIndexChanged += c318b910c2d730d861ae6f06d71ef85c7;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(85, 10);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(995);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(72, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 3;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1008);
		((ListControl)c7f3e39b09538603e028e43b76b67e35e).FormattingEnabled = true;
		((Control)c7f3e39b09538603e028e43b76b67e35e).Location = new Point(85, 26);
		((Control)c7f3e39b09538603e028e43b76b67e35e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1033);
		((Control)c7f3e39b09538603e028e43b76b67e35e).Size = new Size(165, 21);
		c7f3e39b09538603e028e43b76b67e35e.Sorted = true;
		((Control)c7f3e39b09538603e028e43b76b67e35e).TabIndex = 2;
		c7f3e39b09538603e028e43b76b67e35e.SelectedIndexChanged += cf967ae2f72449718b7554da22eb42a68;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(6, 10);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1050);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(68, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 1;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1063);
		((ListControl)c8d30a83c9cb76830bc8f6dc5e64a8ad8).FormattingEnabled = true;
		c8d30a83c9cb76830bc8f6dc5e64a8ad8.Items.AddRange(new object[5]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1088),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1093),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1098),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1103),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1108)
		});
		((Control)c8d30a83c9cb76830bc8f6dc5e64a8ad8).Location = new Point(6, 26);
		((Control)c8d30a83c9cb76830bc8f6dc5e64a8ad8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1113);
		((Control)c8d30a83c9cb76830bc8f6dc5e64a8ad8).Size = new Size(68, 21);
		c8d30a83c9cb76830bc8f6dc5e64a8ad8.Sorted = true;
		((Control)c8d30a83c9cb76830bc8f6dc5e64a8ad8).TabIndex = 0;
		c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedIndexChanged += c82986b3e8ca204cdbb69c9b064340b9c;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(483, 411);
		((Control)this).Controls.Add((Control)(object)tabControl1);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)c1af1b0df6897c5f60041235bc6528b12);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1138);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(480);
		((Control)tabControl1).ResumeLayout(false);
		((Control)c8056e03901b460fdcab42036504c5ecb).ResumeLayout(false);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).ResumeLayout(false);
		((Control)c5f7350fd3246fdffb78d62e89539b883).ResumeLayout(false);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).ResumeLayout(false);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void cb5ced9bc7b7b8ad854510f110508b401(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c093b6a99a3eaba8e0c2b3d64fcc0206b(object P_0, EventArgs P_1)
	{
		cb5ced9bc7b7b8ad854510f110508b401(null, null);
	}

	private void c82986b3e8ca204cdbb69c9b064340b9c(object P_0, EventArgs P_1)
	{
		c7f3e39b09538603e028e43b76b67e35e.Items.Clear();
		((Control)c7f3e39b09538603e028e43b76b67e35e).Enabled = true;
		if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1093))
		{
			IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
					GameObject gameObject = (GameObject)enumerator.Current;
					c7f3e39b09538603e028e43b76b67e35e.Items.Add((object)gameObject);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		else if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1088))
		{
			__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
			if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1098))
			{
				((Control)c7f3e39b09538603e028e43b76b67e35e).Enabled = false;
				c697270965529cf3885777182a8102767.Items.Clear();
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1182));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1195));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1210));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233));
			}
			else if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1108))
			{
				__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
				if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1103))
				{
					__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
				}
				else
				{
					IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
							Room room = (Room)enumerator2.Current;
							c7f3e39b09538603e028e43b76b67e35e.Items.Add((object)room);
						}
					}
					finally
					{
						if (!(enumerator2 is IDisposable disposable2))
						{
							__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
						}
						else
						{
							disposable2.Dispose();
						}
					}
				}
			}
			else
			{
				foreach (Timer timer in c54f9a911545745b85ae6f74355697f8b.TimerList)
				{
					c7f3e39b09538603e028e43b76b67e35e.Items.Add((object)timer);
				}
			}
		}
		else
		{
			IEnumerator enumerator4 = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
					Character character = (Character)enumerator4.Current;
					c7f3e39b09538603e028e43b76b67e35e.Items.Add((object)character);
				}
			}
			finally
			{
				if (!(enumerator4 is IDisposable disposable3))
				{
					__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
				}
				else
				{
					disposable3.Dispose();
				}
			}
		}
		if (!((Control)c7f3e39b09538603e028e43b76b67e35e).Enabled)
		{
			__ldtoken(InsertVariableFrm.c82986b3e8ca204cdbb69c9b064340b9c(object, EventArgs));
		}
		else if (c7f3e39b09538603e028e43b76b67e35e.Items.Count > 0)
		{
			((ListControl)c7f3e39b09538603e028e43b76b67e35e).SelectedIndex = 0;
			return;
		}
		if (c697270965529cf3885777182a8102767.Items.Count > 0)
		{
			((ListControl)c697270965529cf3885777182a8102767).SelectedIndex = 0;
		}
	}

	private void cf967ae2f72449718b7554da22eb42a68(object P_0, EventArgs P_1)
	{
		c697270965529cf3885777182a8102767.Items.Clear();
		Timer timer = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Timer;
		Character character = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Character;
		GameObject gameObject = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as GameObject;
		Room room = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Room;
		if (gameObject == null)
		{
			__ldtoken(InsertVariableFrm.cf967ae2f72449718b7554da22eb42a68(object, EventArgs));
			if (room == null)
			{
				__ldtoken(InsertVariableFrm.cf967ae2f72449718b7554da22eb42a68(object, EventArgs));
				if (character == null)
				{
					__ldtoken(InsertVariableFrm.cf967ae2f72449718b7554da22eb42a68(object, EventArgs));
					if (timer == null)
					{
						__ldtoken(InsertVariableFrm.cf967ae2f72449718b7554da22eb42a68(object, EventArgs));
					}
					else
					{
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1749));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1768));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1781));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1802));
						c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1821));
					}
				}
				else
				{
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1649));
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233));
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1182));
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674));
					c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1697));
				}
			}
			else
			{
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1554));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1589));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1622));
				c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1271));
			}
		}
		else
		{
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1246));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1271));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1276));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1305));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1351));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1370));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1389));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1415));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1434));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1460));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1505));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1524));
			c697270965529cf3885777182a8102767.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1541));
		}
		if (c697270965529cf3885777182a8102767.Items.Count <= 0)
		{
			__ldtoken(InsertVariableFrm.cf967ae2f72449718b7554da22eb42a68(object, EventArgs));
		}
		else
		{
			((ListControl)c697270965529cf3885777182a8102767).SelectedIndex = 0;
		}
		c1314f5c288982074977c3f959c9e3523();
	}

	private void c318b910c2d730d861ae6f06d71ef85c7(object P_0, EventArgs P_1)
	{
		((Control)c8c29e162c66230cf8f34a6fc8658446f).Enabled = false;
		((Control)cf4a7f4f907aa151be819437098030a95).Enabled = false;
		c8c29e162c66230cf8f34a6fc8658446f.Items.Clear();
		cf4a7f4f907aa151be819437098030a95.Items.Clear();
		Timer timer = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Timer;
		Character character = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Character;
		GameObject gameObject = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as GameObject;
		Room room = c7f3e39b09538603e028e43b76b67e35e.SelectedItem as Room;
		if (c697270965529cf3885777182a8102767.SelectedItem == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1233))
		{
			((Control)c8c29e162c66230cf8f34a6fc8658446f).Enabled = true;
			((Control)cf4a7f4f907aa151be819437098030a95).Enabled = true;
			ArrayList arrayList = null;
			if (c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1098))
			{
				__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
				if (gameObject == null)
				{
					__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
					if (character == null)
					{
						__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
						if (timer == null)
						{
							__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
							if (room == null)
							{
								__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
							}
							else
							{
								arrayList = room.Actions;
							}
						}
						else
						{
							arrayList = timer.Actions;
						}
					}
					else
					{
						arrayList = character.Actions;
					}
				}
				else
				{
					arrayList = gameObject.Actions;
				}
			}
			else
			{
				arrayList = c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions;
			}
			if (arrayList == null)
			{
				__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
			}
			else
			{
				IEnumerator enumerator = arrayList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Action action = (Action)enumerator.Current;
						c8c29e162c66230cf8f34a6fc8658446f.Items.Add((object)action);
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			if (c8c29e162c66230cf8f34a6fc8658446f.Items.Count <= 0)
			{
				__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
			}
			else
			{
				((ListControl)c8c29e162c66230cf8f34a6fc8658446f).SelectedIndex = 0;
			}
		}
		else if (c697270965529cf3885777182a8102767.SelectedItem != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1554))
		{
			__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
		}
		else
		{
			((Control)c8c29e162c66230cf8f34a6fc8658446f).Enabled = true;
			((Control)cf4a7f4f907aa151be819437098030a95).Enabled = true;
			string[] names = Enum.GetNames(typeof(Exit.Directions));
			for (int i = 0; i < names.Length; i++)
			{
				__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
				string text = names[i];
				c8c29e162c66230cf8f34a6fc8658446f.Items.Add((object)text);
			}
			if (c8c29e162c66230cf8f34a6fc8658446f.Items.Count <= 0)
			{
				__ldtoken(InsertVariableFrm.c318b910c2d730d861ae6f06d71ef85c7(object, EventArgs));
			}
			else
			{
				((ListControl)c8c29e162c66230cf8f34a6fc8658446f).SelectedIndex = 0;
			}
		}
		c1314f5c288982074977c3f959c9e3523();
	}

	private void cd53e46e19494b699b9c38d9174ae4fe5(object P_0, EventArgs P_1)
	{
		c1314f5c288982074977c3f959c9e3523();
	}

	private void c30097a2de751d99da4cbac4b6a8d49f9(object P_0, EventArgs P_1)
	{
		cf4a7f4f907aa151be819437098030a95.Items.Clear();
		if (c697270965529cf3885777182a8102767.SelectedItem == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1554))
		{
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1846));
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1869));
			((ListControl)cf4a7f4f907aa151be819437098030a95).SelectedIndex = 0;
		}
		else
		{
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1649));
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1882));
			cf4a7f4f907aa151be819437098030a95.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907));
			((ListControl)cf4a7f4f907aa151be819437098030a95).SelectedIndex = 0;
		}
		c1314f5c288982074977c3f959c9e3523();
	}

	private void c1314f5c288982074977c3f959c9e3523()
	{
		string empty = string.Empty;
		try
		{
			empty = string.Concat(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), c8d30a83c9cb76830bc8f6dc5e64a8ad8.SelectedItem, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929));
			if (c7f3e39b09538603e028e43b76b67e35e.SelectedItem == null)
			{
				__ldtoken(InsertVariableFrm.c1314f5c288982074977c3f959c9e3523());
			}
			else
			{
				empty = empty + c7f3e39b09538603e028e43b76b67e35e.SelectedItem.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929);
			}
			empty += c697270965529cf3885777182a8102767.SelectedItem.ToString();
			if (!((Control)c8c29e162c66230cf8f34a6fc8658446f).Enabled)
			{
				__ldtoken(InsertVariableFrm.c1314f5c288982074977c3f959c9e3523());
			}
			else
			{
				string text = empty;
				empty = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + c8c29e162c66230cf8f34a6fc8658446f.SelectedItem.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + cf4a7f4f907aa151be819437098030a95.SelectedItem.ToString();
			}
			empty += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
		}
		catch
		{
			empty = string.Empty;
		}
		((Control)tbText).Text = empty;
	}
}
