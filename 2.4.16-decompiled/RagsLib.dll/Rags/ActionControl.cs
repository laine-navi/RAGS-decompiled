using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using A;
using TachyonLabs.SharpSpell;
using TachyonLabs.SharpSpell.UI;

namespace Rags;

public sealed class ActionControl : UserControl
{
	public enum PageType
	{
		objects,
		characters,
		room,
		player,
		timers,
		quickcommand
	}

	private Misspelling c7bb5165260e0c08dddb1e063c4ff940b;

	private DateTime c1a179b2093c6cfe2c1432a0a01f90fa6 = DateTime.Now;

	private ComboBox cac746b88c8c90ee4aab23a1126b66c7a;

	private object c6142b4080fdb112e2e031ff1a2ddbbad;

	public static Format ActionFormat = DataFormats.GetFormat(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19017));

	public static Format ConditonFormat = DataFormats.GetFormat(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19038));

	public static Format CommandFormat = DataFormats.GetFormat(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19065));

	private bool c09339147ff81a8d975d8fcf141910684;

	private Game c54f9a911545745b85ae6f74355697f8b;

	private PageType c966c316b5de02c6ef56a4713e8bdaeea;

	private string c1e2ad2c4b8f893c83053fbfc829e5cac = string.Empty;

	private bool c21866eb25aee37e6f752f82def05d536;

	private bool c5c3023d84324dc6ac5cbb7910e689ef9;

	private ArrayList c9904ed3a443d66bdab40215e344af583;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private GroupBox c283bbab44b3fca5d39367f132894644e;

	private GroupBox ce3a976124811ba8f18adc6cb8899b0e8;

	private RadioButton c8854d358ef39133e603ce658d3c732b9;

	private RadioButton c602cc87b31944701be94229b41e8bb82;

	private GroupBox ca97c16bb25e579acbfca5f9ec5f38762;

	private RadioButton c789be2065ed12ebb629dcfca687809c5;

	private RadioButton c602fc3992403e5cdad0409e1900aed07;

	private RadioButton c1a3979b2807ce107cbb855fb8ff7202b;

	private RadioButton c4f77bfbc101bbe9d822a90c9ec242f9b;

	private RadioButton cc931d55a79f75a3ad8eeff54cc492876;

	private CheckBox c225aaa2c7205152650b3b8a11c5c00c3;

	public TreeView tvActionsConditions;

	private GroupBox ce0af834a86d4a32667002a2e1c9c4359;

	private Label cae81a39c04741469eb9b7f14cd68b352;

	private Label c1ff7ab8162850bc386a55daadfc620be;

	private TextBox ce461a44e2020b57573abdc365294fa10;

	private TextBox cca635a57d99b03a02717c239805e2524;

	private Label cee63b5aaa73084c565be53403d6d78a5;

	private ComboBox cb14d51ac8530fe4463993959ce4a6d75;

	private Label cdcc543dc83800ba1d24d764066e3005e;

	private ComboBox c428ebf94dee726b1e31b460540bbbc1f;

	private Label c57eeb71d9b376ae36eb2d1b058003c64;

	public ComboBox cbConditionStep1;

	private GroupBox c1844ff8515e2e1bb16edc45f8622b8bb;

	private TextBox c4053b9b7d85ea311db9e2c9a464192fb;

	private Label c43a2d1ff6560b2051d7cf8dfa9309b98;

	private Label c85ec63372a2560632b32285c85e56156;

	private Label c86cb42b5f2066de273d56833f0cfcf54;

	private ComboBox c2332b911806c4b9e235af5bfdc94f97d;

	private Label c0409bb493de758becfc185d928829028;

	private ComboBox c962ce47954ab1816402cab8d8ab59271;

	private Label cb515fc292bfc8c27f12c9a825983cfd4;

	public ComboBox cbCommandStep1;

	private TextBox c7366ee5636b59024f2e8b9b7ba28fcec;

	private Label ca682b8c5c7d2bfaac844245d6ad7a15d;

	private ContextMenuStrip c30a1afe18fa8ade4415ebdf1fe821777;

	private ContextMenuStrip cbbc887de9f5ea470255e15cc298c7942;

	private ToolStripMenuItem cd5960a6d819462b79433c8fb6bcbc7c8;

	private ToolStripMenuItem c218905ada22e5e6f0335e6dbf5db6b9c;

	private ContextMenuStrip c98d6867393e88ba8ec22c0c28b73b18d;

	private ToolStripMenuItem c27df608f4ca3131ea673455fe08bc608;

	private ToolStripMenuItem ce55fd3799a0de16dd3b2992bce9aad39;

	private ImageList c04dcf0368a2156705fbbc1fedf6f193e;

	private SplitContainer cfdd28b747afbe52686772d0eed813027;

	private SplitContainer c98dd8245994cd868d7cdfd180f7f9422;

	private Button c4861c86b27c29b83354ab24250603283;

	private ListBox c4e7f938e7e498f7339be7ccf18e84053;

	private Button c1dfd66f09bc1eca582c72926f1f2451c;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private ContextMenuStrip c3a8094646f27dd51898bdb4dfaa78e09;

	private ToolStripMenuItem c9a160b3483ca491f08d14af12abc7625;

	private ToolStripMenuItem c7184c85f3188ef6bb4961cf9c847fbfa;

	private ToolStripMenuItem c944661025bdf591000e92f861eadb21b;

	private Label cba88c834a279c3e211d684cb838406e9;

	private ListBox c3834cad3fa310a2ecdf84f4b34e287f5;

	private Button c0483f8f42ff39d5f74e69515eb6ba2f0;

	private Button c7fc17de416b5bf7ec20d075233fc568b;

	private GroupBox cafd1491656d4be80c61872cf7780040d;

	private Button cd8c2e9bd4cb7b2a770566b2f66754b3b;

	private ListBox cbe61056f04fc0861514479244d36e741;

	private RadioButton ce71e85e952218edc33bda5326c37ed93;

	private ComboBox c1ae51f04467ab9b62260d376b5dc5cba;

	private ComboBox cb110e655831717067e74b6e01e57f651;

	private Button c77967f9eb311ee3d9905b43b5337f9ad;

	private Button c89c23d9240530bb50613c4c2d81fbaad;

	private RadioButton c8af24b3132c3f9bc521cb9cccc12a224;

	private TreeView c4743068129d058c0158648be0270ef9d;

	private SplitContainer c2a161da002bb8cdd90af79c65bcd8c5f;

	private Button c745b25e1019649e3ccbbb38d595446ae;

	private ToolTip cc2b2196e6c009b5ea6d986a89947275c;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private TextBox cecee52f098b12876894cea6eddb9401d;

	private Button cd5530af334f348c1867bbc6535f2ccff;

	private SharpSpellLive c1ef940cdb8be768145bbb7ae47e0f539;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Button c345fb42ff93f6376eb2f0cb2c093e67e;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private TextBox c07e860d38468b4c3820b72fd82b8c479;

	private GroupBox ccd86f2a93b81505af97aa59a0c4f0545;

	private ComboBox c857dba7e8960ec53f0faacb2f0142d89;

	public ActionControl()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		Command.PopulateComboWithCommands(cbCommandStep1, bFilter: true);
		Command.PopulateTreeViewWithCommands(c4743068129d058c0158648be0270ef9d);
		Condition.PopulateComboWithConditions(cbConditionStep1, bFilter: true);
		c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = true;
		cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c745b25e1019649e3ccbbb38d595446ae, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18968));
	}

	public void SetGameObject(ref Game CurGame)
	{
		c54f9a911545745b85ae6f74355697f8b = CurGame;
	}

	public void SetPageType(PageType pt)
	{
		c966c316b5de02c6ef56a4713e8bdaeea = pt;
	}

	public void SetObjectName(string name)
	{
		c1e2ad2c4b8f893c83053fbfc829e5cac = name;
	}

	private void c4f2e382b13c41b1c7008963bc15489bf(TreeView P_0, EventHandler P_1, int P_2, int P_3)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected Obj, but got Unknown
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Expected Obj, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected Obj, but got Unknown
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected Obj, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected Obj, but got Unknown
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected Obj, but got Unknown
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected Obj, but got Unknown
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Expected Obj, but got Unknown
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected Obj, but got Unknown
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Expected Obj, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected Obj, but got Unknown
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected Obj, but got Unknown
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Expected Obj, but got Unknown
		//IL_0907: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Expected Obj, but got Unknown
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Expected Obj, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected Obj, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected Obj, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected Obj, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad3: Expected Obj, but got Unknown
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Expected Obj, but got Unknown
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_097e: Expected Obj, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected Obj, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected Obj, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected Obj, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected Obj, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected Obj, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected Obj, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected Obj, but got Unknown
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6e: Expected Obj, but got Unknown
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Expected Obj, but got Unknown
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected Obj, but got Unknown
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Expected Obj, but got Unknown
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected Obj, but got Unknown
		//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Expected Obj, but got Unknown
		//IL_0c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected Obj, but got Unknown
		((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Clear();
		TreeViewHitTestInfo val = P_0.HitTest(P_2, P_3);
		if (val.Node != null)
		{
			__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
			if (val.Node.Parent == null)
			{
				P_0.SelectedNode = val.Node;
				ToolStripMenuItem val2 = null;
				if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.timers)
				{
					__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				}
				else
				{
					val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2027), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
					((ToolStripItem)val2).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				}
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1935), (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2081), (Image)(object)c00a60cf5907463226976953aca8f695d.question);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2141), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2186), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				bool flag = false;
				if (!(val.Node.Tag is Command))
				{
					__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				}
				else
				{
					flag = true;
					val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
					((ToolStripItem)val2).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				}
				ToolStripMenuItem val3 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1981), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val3).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val3);
				val3 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2002), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val3).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val3);
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)new ToolStripSeparator());
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1956), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				IDataObject dataObject = Clipboard.GetDataObject();
				Action action = dataObject.GetData(ActionFormat.Name) as Action;
				((ToolStripItem)val2).Enabled = action != null;
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2283), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				Condition condition = dataObject.GetData(ConditonFormat.Name) as Condition;
				((ToolStripItem)val2).Enabled = condition != null;
				((ToolStripItem)val2).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				if (!flag)
				{
					__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				}
				else
				{
					val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
					((ToolStripItem)val2).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
					val2 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2339), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
					Command command = dataObject.GetData(CommandFormat.Name) as Command;
					((ToolStripItem)val2).Enabled = command != null;
					((ToolStripItem)val2).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val2);
				}
			}
			else
			{
				P_0.SelectedNode = val.Node;
				ToolStripMenuItem val4 = null;
				if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.timers)
				{
					val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2027), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
					((ToolStripItem)val4).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				}
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1935));
				((ToolStripItem)val4).Click += c68a54b096879bec8c3cab2e8e07786ea;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054));
				((ToolStripItem)val4).Click += c68a54b096879bec8c3cab2e8e07786ea;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2081), (Image)(object)c00a60cf5907463226976953aca8f695d.question);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2141), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2186), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				bool flag2 = false;
				if (val.Node.Tag is Command)
				{
					flag2 = true;
					val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231), (Image)(object)c00a60cf5907463226976953aca8f695d.cancel);
					((ToolStripItem)val4).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
					flag2 = true;
				}
				ToolStripMenuItem val5 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1981), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val5).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val5);
				val5 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2002), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val5).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val5);
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)new ToolStripSeparator());
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1956), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				IDataObject dataObject2 = Clipboard.GetDataObject();
				Action action2 = dataObject2.GetData(ActionFormat.Name) as Action;
				((ToolStripItem)val4).Enabled = action2 != null;
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2366), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2283), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				Condition condition2 = dataObject2.GetData(ConditonFormat.Name) as Condition;
				((ToolStripItem)val4).Enabled = condition2 != null;
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				if (!flag2)
				{
					__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				}
				else
				{
					val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
					((ToolStripItem)val4).Click += P_1;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
				}
				if (P_0.SelectedNode.Parent.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
				{
					__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				}
				else if (!(P_0.SelectedNode.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)))
				{
					if (P_0.SelectedNode.Parent.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434))
					{
						__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
					}
					else if (!(P_0.SelectedNode.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434)))
					{
						__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
						goto IL_0ab6;
					}
				}
				val4 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2339), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
				Command command2 = dataObject2.GetData(CommandFormat.Name) as Command;
				((ToolStripItem)val4).Enabled = command2 != null;
				((ToolStripItem)val4).Click += P_1;
				((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val4);
			}
		}
		else
		{
			ToolStripMenuItem val6 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1935), (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
			((ToolStripItem)val6).Click += P_1;
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val6);
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)new ToolStripSeparator());
			val6 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1956), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
			IDataObject dataObject3 = Clipboard.GetDataObject();
			Action action3 = dataObject3.GetData(ActionFormat.Name) as Action;
			((ToolStripItem)val6).Enabled = action3 != null;
			((ToolStripItem)val6).Click += P_1;
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val6);
			ToolStripMenuItem val7 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1981), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
			((ToolStripItem)val7).Click += P_1;
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val7);
			val7 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2002), (Image)(object)c00a60cf5907463226976953aca8f695d.TaskHS);
			((ToolStripItem)val7).Click += P_1;
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val7);
		}
		goto IL_0ab6;
		IL_0ab6:
		if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.timers)
		{
			__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
		}
		else
		{
			ToolStripSeparator val8 = new ToolStripSeparator();
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val8);
			ToolStripMenuItem val9 = new ToolStripMenuItem(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2473));
			((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val9);
			for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.QuickCommands.Count; i++)
			{
				__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
				QuickMenuItem quickMenuItem = (QuickMenuItem)c54f9a911545745b85ae6f74355697f8b.QuickCommands[i];
				switch (c966c316b5de02c6ef56a4713e8bdaeea)
				{
				case PageType.characters:
					if (!quickMenuItem.bCharacters)
					{
						__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
						break;
					}
					val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
					((ToolStripItem)val9).Click += P_1;
					((ToolStripItem)val9).Tag = quickMenuItem;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val9);
					break;
				case PageType.objects:
					if (!quickMenuItem.bObjects)
					{
						__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
						break;
					}
					val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
					((ToolStripItem)val9).Click += P_1;
					((ToolStripItem)val9).Tag = quickMenuItem;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val9);
					break;
				case PageType.player:
					if (!quickMenuItem.bPlayer)
					{
						__ldtoken(ActionControl.c4f2e382b13c41b1c7008963bc15489bf(TreeView, EventHandler, int, int));
						break;
					}
					val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
					((ToolStripItem)val9).Click += P_1;
					((ToolStripItem)val9).Tag = quickMenuItem;
					((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val9);
					break;
				case PageType.room:
					if (quickMenuItem.bRooms)
					{
						val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)c00a60cf5907463226976953aca8f695d.runman);
						((ToolStripItem)val9).Click += P_1;
						((ToolStripItem)val9).Tag = quickMenuItem;
						((ToolStrip)c30a1afe18fa8ade4415ebdf1fe821777).Items.Add((ToolStripItem)(object)val9);
					}
					break;
				}
			}
		}
		((ToolStripDropDown)c30a1afe18fa8ade4415ebdf1fe821777).Show((Control)(object)P_0, P_2, P_3);
	}

	private void cdacb012587b0ace610fd6eefd327fa91(object P_0, MouseEventArgs P_1)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		((Control)tvActionsConditions).Focus();
		if ((int)P_1.Button == 2097152 && ((Control)tvActionsConditions).Enabled)
		{
			c4f2e382b13c41b1c7008963bc15489bf(tvActionsConditions, c68a54b096879bec8c3cab2e8e07786ea, P_1.X, P_1.Y);
		}
		if ((int)P_1.Button == 1048576)
		{
			TreeViewHitTestInfo val = tvActionsConditions.HitTest(P_1.X, P_1.Y);
			if (val.Node == null)
			{
				__ldtoken(ActionControl.cdacb012587b0ace610fd6eefd327fa91(object, MouseEventArgs));
			}
			else
			{
				tvActionsConditions.SelectedNode = val.Node;
			}
			c09339147ff81a8d975d8fcf141910684 = true;
		}
	}

	private void c30e90c805842ce4651af61f353033dce(object P_0, TreeViewEventArgs P_1)
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (!(selectedNode.Tag is Command))
		{
			__ldtoken(ActionControl.c30e90c805842ce4651af61f353033dce(object, TreeViewEventArgs));
			if (c521610853650504f145dd1cf178b1d8f())
			{
				if (!(tvActionsConditions.SelectedNode.Tag is Condition))
				{
					((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Visible = false;
					((Control)ce0af834a86d4a32667002a2e1c9c4359).Visible = false;
					((Control)cafd1491656d4be80c61872cf7780040d).Visible = true;
					goto IL_00f1;
				}
				__ldtoken(ActionControl.c30e90c805842ce4651af61f353033dce(object, TreeViewEventArgs));
			}
			((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Visible = false;
			((Control)ce0af834a86d4a32667002a2e1c9c4359).Visible = true;
			((Control)cafd1491656d4be80c61872cf7780040d).Visible = false;
		}
		else
		{
			((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Visible = true;
			((Control)ce0af834a86d4a32667002a2e1c9c4359).Visible = false;
			((Control)cafd1491656d4be80c61872cf7780040d).Visible = false;
			cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, ((Command)selectedNode.Tag).cmdtype);
		}
		goto IL_00f1;
		IL_00f1:
		if (selectedNode == null)
		{
			((Control)cca635a57d99b03a02717c239805e2524).Text = "";
			((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Visible = false;
			((Control)ce0af834a86d4a32667002a2e1c9c4359).Visible = false;
			((Control)cafd1491656d4be80c61872cf7780040d).Visible = false;
		}
		else if (!(selectedNode.Tag is Action))
		{
			__ldtoken(ActionControl.c30e90c805842ce4651af61f353033dce(object, TreeViewEventArgs));
			((Control)cca635a57d99b03a02717c239805e2524).Text = selectedNode.Text;
			((Control)c225aaa2c7205152650b3b8a11c5c00c3).Enabled = false;
			((Control)ca97c16bb25e579acbfca5f9ec5f38762).Enabled = false;
			((Control)ce3a976124811ba8f18adc6cb8899b0e8).Enabled = false;
		}
		else
		{
			((Control)cca635a57d99b03a02717c239805e2524).Text = "";
			((Control)c225aaa2c7205152650b3b8a11c5c00c3).Enabled = true;
			((Control)ca97c16bb25e579acbfca5f9ec5f38762).Enabled = true;
			((Control)ce3a976124811ba8f18adc6cb8899b0e8).Enabled = true;
		}
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void cac35fa0cd361ed717e3b5c9cfde09695(object P_0, EventArgs P_1)
	{
		Command command = new Command();
		command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		command.CommandPart2 = ((Control)c962ce47954ab1816402cab8d8ab59271).Text;
		command.CommandPart3 = ((Control)c2332b911806c4b9e235af5bfdc94f97d).Text;
		command.CommandText = ((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text;
		if (tvActionsConditions.SelectedNode == null)
		{
			return;
		}
		if (tvActionsConditions.SelectedNode.Parent != null)
		{
			__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
			switch (c966c316b5de02c6ef56a4713e8bdaeea)
			{
			case PageType.objects:
			{
				GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (objectByName == null)
				{
					break;
				}
				Action actionByName3 = objectByName.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				if (actionByName3 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Condition conditionByName2 = actionByName3.GetConditionByName(tvActionsConditions.SelectedNode.Text);
				if (conditionByName2 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					conditionByName2.PassCommands.Add(command);
				}
				break;
			}
			case PageType.player:
			{
				Action actionByName = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				if (actionByName == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Condition conditionByName = actionByName.GetConditionByName(tvActionsConditions.SelectedNode.Text);
				if (conditionByName == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					conditionByName.PassCommands.Add(command);
				}
				break;
			}
			case PageType.characters:
			{
				Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (characterByName != null)
				{
					Action actionByName2 = characterByName.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
					if (actionByName2 == null)
					{
						__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					}
					else
					{
						actionByName2.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
					}
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
				if (roomByID == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Action actionByName4 = roomByID.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				if (actionByName4 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Condition conditionByName3 = actionByName4.GetConditionByName(tvActionsConditions.SelectedNode.Text);
				if (conditionByName3 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					conditionByName3.PassCommands.Add(command);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (timerByName == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Action actionByName5 = timerByName.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				if (actionByName5 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Condition conditionByName4 = actionByName5.GetConditionByName(tvActionsConditions.SelectedNode.Text);
				if (conditionByName4 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					conditionByName4.PassCommands.Add(command);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (menuItemByName == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					menuItemByName.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				}
				break;
			}
			}
		}
		else
		{
			switch (c966c316b5de02c6ef56a4713e8bdaeea)
			{
			case PageType.objects:
			{
				GameObject objectByName2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (objectByName2 != null)
				{
					Action actionByName8 = objectByName2.GetActionByName(tvActionsConditions.SelectedNode.Text);
					if (actionByName8 == null)
					{
						__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					}
					else
					{
						actionByName8.PassCommands.Add(command);
					}
				}
				break;
			}
			case PageType.player:
			{
				Action actionByName7 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Text);
				if (actionByName7 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					actionByName7.PassCommands.Add(command);
				}
				break;
			}
			case PageType.room:
				c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac))?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.characters:
			{
				Character characterByName2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (characterByName2 != null)
				{
					Action actionByName10 = characterByName2.GetActionByName(tvActionsConditions.SelectedNode.Text);
					if (actionByName10 == null)
					{
						__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					}
					else
					{
						actionByName10.PassCommands.Add(command);
					}
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName2 = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (timerByName2 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					break;
				}
				Action actionByName9 = timerByName2.GetActionByName(tvActionsConditions.SelectedNode.Text);
				if (actionByName9 == null)
				{
					__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
				}
				else
				{
					actionByName9.PassCommands.Add(command);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName2 = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (menuItemByName2 != null)
				{
					Action actionByName6 = menuItemByName2.GetActionByName(tvActionsConditions.SelectedNode.Text);
					if (actionByName6 == null)
					{
						__ldtoken(ActionControl.cac35fa0cd361ed717e3b5c9cfde09695(object, EventArgs));
					}
					else
					{
						actionByName6.PassCommands.Add(command);
					}
				}
				break;
			}
			}
		}
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c22d9d49ad16278c84fc9c7782bef188b()
	{
		Action action = c48d5625ef051338905ddc110c05a3e45();
		if (action == null)
		{
			__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
			return;
		}
		c857dba7e8960ec53f0faacb2f0142d89.Items.Clear();
		c857dba7e8960ec53f0faacb2f0142d89.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514));
		if (!(action.actionparent == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514)))
		{
			__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
		}
		else
		{
			((ListControl)c857dba7e8960ec53f0faacb2f0142d89).SelectedIndex = 0;
		}
		ArrayList arrayList = c9ace99d5d5238fce319298fe34c80436();
		for (int i = 0; i < arrayList.Count; i++)
		{
			__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
			Action action2 = (Action)arrayList[i];
			if (action2.name.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2523)))
			{
				__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
				continue;
			}
			if (!(action2.name != action.name))
			{
				__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
				continue;
			}
			int selectedIndex = c857dba7e8960ec53f0faacb2f0142d89.Items.Add((object)action2.name);
			if (!(action.actionparent == action2.name))
			{
				__ldtoken(ActionControl.c22d9d49ad16278c84fc9c7782bef188b());
			}
			else
			{
				((ListControl)c857dba7e8960ec53f0faacb2f0142d89).SelectedIndex = selectedIndex;
			}
		}
	}

	private void c7797903c3b20f17c77f70c8fde465600()
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Enabled = true;
			((Control)ce0af834a86d4a32667002a2e1c9c4359).Enabled = true;
			((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
			((Control)ce3a976124811ba8f18adc6cb8899b0e8).Enabled = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = false;
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = false;
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			if (!c521610853650504f145dd1cf178b1d8f())
			{
				__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
			}
			else
			{
				if (!(tvActionsConditions.SelectedNode.Tag is Condition))
				{
					Action action = c48d5625ef051338905ddc110c05a3e45();
					((Control)cecee52f098b12876894cea6eddb9401d).Text = action.CustomChoiceTitle;
					((Control)c07e860d38468b4c3820b72fd82b8c479).Text = action.overridename;
					c22d9d49ad16278c84fc9c7782bef188b();
					cbe61056f04fc0861514479244d36e741.Items.Clear();
					IEnumerator enumerator = action.CustomChoices.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
							string text = (string)enumerator.Current;
							cbe61056f04fc0861514479244d36e741.Items.Add((object)text);
						}
					}
					finally
					{
						if (!(enumerator is IDisposable disposable))
						{
							__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
						}
						else
						{
							disposable.Dispose();
						}
					}
					c225aaa2c7205152650b3b8a11c5c00c3.Checked = action.bActive;
					if (!action.bConditionFailOnFirst)
					{
						__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
						c8854d358ef39133e603ce658d3c732b9.Checked = true;
					}
					else
					{
						c602cc87b31944701be94229b41e8bb82.Checked = true;
					}
					((Control)cafd1491656d4be80c61872cf7780040d).Enabled = false;
					switch (action.InputType)
					{
					case Action.ActionInputType.None:
						cc931d55a79f75a3ad8eeff54cc492876.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = false;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = false;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					case Action.ActionInputType.Character:
						c1a3979b2807ce107cbb855fb8ff7202b.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					case Action.ActionInputType.Object:
						c4f77bfbc101bbe9d822a90c9ec242f9b.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					case Action.ActionInputType.ObjectOrCharacter:
						c602fc3992403e5cdad0409e1900aed07.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					case Action.ActionInputType.Text:
						c789be2065ed12ebb629dcfca687809c5.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					case Action.ActionInputType.Custom:
						ce71e85e952218edc33bda5326c37ed93.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cecee52f098b12876894cea6eddb9401d).Text = action.CustomChoiceTitle;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = true;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = true;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = true;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = true;
						break;
					case Action.ActionInputType.Inventory:
						c8af24b3132c3f9bc521cb9cccc12a224.Checked = true;
						((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
						((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
						((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
						((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
						((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
						((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
						break;
					}
					goto IL_04ec;
				}
				__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
			}
			Condition condition = ce934006d23f9c541701af4a7e1dab46f();
			if (condition != null)
			{
				cf321bad81366defd5fe03ced8501524f(condition);
				((Control)cca635a57d99b03a02717c239805e2524).Text = condition.conditionname;
				((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex = 0;
			}
			goto IL_04ec;
		}
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Enabled = false;
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Enabled = false;
		((Control)cafd1491656d4be80c61872cf7780040d).Enabled = false;
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Enabled = false;
		return;
		IL_04ec:
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (!(selectedNode.Tag is Command command))
		{
			return;
		}
		c3834cad3fa310a2ecdf84f4b34e287f5.Items.Clear();
		IEnumerator enumerator2 = command.CustomChoices.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
				string text2 = (string)enumerator2.Current;
				c3834cad3fa310a2ecdf84f4b34e287f5.Items.Add((object)text2);
			}
		}
		finally
		{
			IDisposable disposable3 = enumerator2 as IDisposable;
			if (disposable3 != null)
			{
				disposable3.Dispose();
			}
		}
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text = command.CommandText;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text = command.CommandPart4;
		cbConditionStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, command.cmdtype);
		c2c95007c30beadab9f3e3e2216adc4a7(null, null);
		try
		{
			Guid guid = new Guid(command.CommandPart2);
			foreach (RoomComboItem item in c962ce47954ab1816402cab8d8ab59271.Items)
			{
				if (!(item.UniqueID == guid))
				{
					__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
					continue;
				}
				c962ce47954ab1816402cab8d8ab59271.SelectedItem = item;
				break;
			}
		}
		catch
		{
			((Control)c962ce47954ab1816402cab8d8ab59271).Text = command.CommandPart2;
		}
		try
		{
			Guid guid2 = new Guid(command.CommandPart3);
			IEnumerator enumerator4 = c2332b911806c4b9e235af5bfdc94f97d.Items.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
					RoomComboItem roomComboItem2 = (RoomComboItem)enumerator4.Current;
					if (!(roomComboItem2.UniqueID == guid2))
					{
						__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
						continue;
					}
					c2332b911806c4b9e235af5bfdc94f97d.SelectedItem = roomComboItem2;
					break;
				}
			}
			finally
			{
				if (!(enumerator4 is IDisposable disposable2))
				{
					__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		catch
		{
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Text = command.CommandPart3;
		}
		try
		{
			Guid guid3 = new Guid(command.CommandPart4);
			for (int i = 0; i < c1ae51f04467ab9b62260d376b5dc5cba.Items.Count; i++)
			{
				__ldtoken(ActionControl.c7797903c3b20f17c77f70c8fde465600());
				RoomComboItem roomComboItem3 = null;
				try
				{
					roomComboItem3 = (RoomComboItem)c1ae51f04467ab9b62260d376b5dc5cba.Items[i];
				}
				catch
				{
					roomComboItem3 = null;
				}
				if (roomComboItem3 != null && roomComboItem3.UniqueID == guid3)
				{
					c1ae51f04467ab9b62260d376b5dc5cba.SelectedItem = roomComboItem3;
					break;
				}
			}
		}
		catch
		{
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Text = command.CommandPart4;
		}
	}

	private void cf321bad81366defd5fe03ced8501524f(Condition P_0)
	{
		c4e7f938e7e498f7339be7ccf18e84053.Items.Clear();
		IEnumerator enumerator = P_0.Checks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.cf321bad81366defd5fe03ced8501524f(Condition));
				Check check = (Check)enumerator.Current;
				if (check.CkType != CheckType.CT_Uninitialized)
				{
					c4e7f938e7e498f7339be7ccf18e84053.Items.Add((object)(check.CkType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + Condition.GetConditionName(check.CondType)));
				}
				else
				{
					c4e7f938e7e498f7339be7ccf18e84053.Items.Add((object)Condition.GetConditionName(check.CondType));
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private Condition ce934006d23f9c541701af4a7e1dab46f()
	{
		Condition condition = null;
		if (tvActionsConditions.SelectedNode.Level < 1)
		{
			__ldtoken(ActionControl.ce934006d23f9c541701af4a7e1dab46f());
		}
		else
		{
			TreeNode val = tvActionsConditions.SelectedNode;
			condition = val.Tag as Condition;
			while (true)
			{
				if (condition != null)
				{
					__ldtoken(ActionControl.ce934006d23f9c541701af4a7e1dab46f());
					break;
				}
				if (val.Level < 1)
				{
					break;
				}
				__ldtoken(ActionControl.ce934006d23f9c541701af4a7e1dab46f());
				val = val.Parent;
				condition = val.Tag as Condition;
			}
		}
		return condition;
	}

	private Action c48d5625ef051338905ddc110c05a3e45()
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.c48d5625ef051338905ddc110c05a3e45());
			return null;
		}
		TreeNode val = tvActionsConditions.SelectedNode;
		while (val.Parent != null)
		{
			__ldtoken(ActionControl.c48d5625ef051338905ddc110c05a3e45());
			val = val.Parent;
		}
		return val.Tag as Action;
	}

	private TreeNode c3ede567c56bcc31cebb9f8c7704be790()
	{
		TreeNode val = tvActionsConditions.SelectedNode;
		while (val.Parent != null)
		{
			__ldtoken(ActionControl.c3ede567c56bcc31cebb9f8c7704be790());
			val = val.Parent;
		}
		return val;
	}

	private TreeNode c67f2c94c1591123712e95dd345bf1b6e()
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (selectedNode.Text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2531)) <= -1)
		{
			__ldtoken(ActionControl.c67f2c94c1591123712e95dd345bf1b6e());
			return selectedNode.Parent;
		}
		return selectedNode;
	}

	private bool c521610853650504f145dd1cf178b1d8f()
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (string.Compare(selectedNode.Text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2554), ignoreCase: true) == 0)
		{
			__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
		}
		else if (string.Compare(selectedNode.Text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2593), ignoreCase: true) != 0)
		{
			if (selectedNode.Tag is Action)
			{
				return true;
			}
			if (!(selectedNode.Tag is Command))
			{
				__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
			}
			else if (selectedNode.Level == 2)
			{
				__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
				goto IL_00c3;
			}
			if (!(selectedNode.Tag is Condition))
			{
				__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
			}
			else
			{
				if (selectedNode.Level == 2)
				{
					goto IL_00c3;
				}
				__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
			}
			goto IL_00e7;
		}
		if (!(selectedNode.Parent.Tag is Action))
		{
			__ldtoken(ActionControl.c521610853650504f145dd1cf178b1d8f());
			goto IL_00e7;
		}
		return true;
		IL_00c3:
		return true;
		IL_00e7:
		return false;
	}

	private void c150dff9346792f633d858de446fd6918(object P_0, EventArgs P_1)
	{
		Command command = new Command();
		command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		command.CommandPart2 = ((Control)c962ce47954ab1816402cab8d8ab59271).Text;
		command.CommandPart3 = ((Control)c2332b911806c4b9e235af5bfdc94f97d).Text;
		command.CommandText = ((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text;
		if (tvActionsConditions.SelectedNode.Parent == null)
		{
			Action action = null;
			switch (c966c316b5de02c6ef56a4713e8bdaeea)
			{
			case PageType.objects:
			{
				GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (objectByName == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action = objectByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.player:
				action = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Text);
				break;
			case PageType.characters:
			{
				Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (characterByName != null)
				{
					action = characterByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
				if (roomByID != null)
				{
					action = roomByID.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (timerByName == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action = timerByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (menuItemByName != null)
				{
					action = menuItemByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			}
			action?.FailCommands.Add(command);
		}
		else
		{
			Condition condition = null;
			Action action2 = null;
			switch (c966c316b5de02c6ef56a4713e8bdaeea)
			{
			case PageType.objects:
			{
				GameObject objectByName2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (objectByName2 == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action2 = objectByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.player:
				action2 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				break;
			case PageType.characters:
			{
				Character characterByName2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (characterByName2 == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action2 = characterByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
				if (roomByID2 == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action2 = roomByID2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName2 = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (timerByName2 == null)
				{
					__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
				}
				else
				{
					action2 = timerByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName2 = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
				if (menuItemByName2 != null)
				{
					action2 = menuItemByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			}
			if (action2 == null)
			{
				__ldtoken(ActionControl.c150dff9346792f633d858de446fd6918(object, EventArgs));
			}
			else
			{
				condition = action2.GetConditionByName(tvActionsConditions.SelectedNode.Text);
			}
			condition?.FailCommands.Add(command);
		}
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c9525f87619a24b52bdeb6362d08a5560(object P_0, EventArgs P_1)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ce934006d23f9c541701af4a7e1dab46f();
		if (condition == null)
		{
			return;
		}
		if (cbConditionStep1.SelectedItem == null)
		{
			__ldtoken(ActionControl.c9525f87619a24b52bdeb6362d08a5560(object, EventArgs));
		}
		else
		{
			if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
			{
				if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Rooms)
				{
					__ldtoken(ActionControl.c9525f87619a24b52bdeb6362d08a5560(object, EventArgs));
				}
				else if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_Characters && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_Items)
				{
					__ldtoken(ActionControl.c9525f87619a24b52bdeb6362d08a5560(object, EventArgs));
					goto IL_00f1;
				}
			}
			if (condition.Checks.Count > 1)
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2632));
				cbConditionStep1.SelectedItem = Condition.GetConditionItem(cbConditionStep1, Condition.ConditionType.CT_Character_In_Room);
				return;
			}
			__ldtoken(ActionControl.c9525f87619a24b52bdeb6362d08a5560(object, EventArgs));
		}
		goto IL_00f1;
		IL_00f1:
		cf6b4fe95d8a6bb4545e52d36ae84112c();
	}

	private void cf6b4fe95d8a6bb4545e52d36ae84112c()
	{
		//IL_19c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Invalid comparison between Unknown and I4
		((Control)cb110e655831717067e74b6e01e57f651).Visible = false;
		switch (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex)
		{
		case Condition.ConditionType.CT_Item_InGroup:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2780);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			cfa596a2962cb6f1785076102cb425102(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_MultiMedia_InGroup:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2817);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2844);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			ca43abf32ab310331d932276c8ccc4578(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Character_In_Room:
		{
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2918);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref cb14d51ac8530fe4463993959ce4a6d75);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			cb14d51ac8530fe4463993959ce4a6d75.Items.Insert(0, (object)roomComboItem2);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		}
		case Condition.ConditionType.CT_Character_In_RoomGroup:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2970);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			c23a6919f2505954c7e73cda8c53f77de(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Character_Gender:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3007));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3016));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3029));
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3040);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Character:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3061);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			cb8a0198efb03167ef7b9f2a7bd07af0f(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Not_In_Object:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3106);
			ceebd82bf878924f11c72a3e53f146fee(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3143);
			ceebd82bf878924f11c72a3e53f146fee(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_Gender:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3040);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c428ebf94dee726b1e31b460540bbbc1f.Items.Clear();
			c428ebf94dee726b1e31b460540bbbc1f.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3007));
			c428ebf94dee726b1e31b460540bbbc1f.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3016));
			c428ebf94dee726b1e31b460540bbbc1f.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3029));
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3143);
			ceebd82bf878924f11c72a3e53f146fee(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_In_Room:
		{
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref cb14d51ac8530fe4463993959ce4a6d75);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			cb14d51ac8530fe4463993959ce4a6d75.Items.Insert(0, (object)roomComboItem);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		}
		case Condition.ConditionType.CT_Item_In_RoomGroup:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3189);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			c23a6919f2505954c7e73cda8c53f77de(ref cb14d51ac8530fe4463993959ce4a6d75);
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2918);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Exits:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2918);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_RoomGroup:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2970);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c23a6919f2505954c7e73cda8c53f77de(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_Moving:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3218);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cdae9c86e90fc7d836057f17172d875dc(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3345));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3354));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490));
			cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3367));
			break;
		case Condition.ConditionType.CT_Loop_Characters:
		case Condition.ConditionType.CT_Loop_Items:
		case Condition.ConditionType.CT_Loop_Rooms:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = false;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_While:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3386);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c1985e1304d050ba10dd39629ba81048a(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != "")
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Loop_Item_Group:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2780);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cfa596a2962cb6f1785076102cb425102(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Container:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3465);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			ceebd82bf878924f11c72a3e53f146fee(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Room:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2918);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Inventory:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2780);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = false;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = false;
			((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3172);
			((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
			((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			break;
		case Condition.ConditionType.CT_Room_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cbbe3d3ac6416ab1a3b8fd501057c8841(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c17ab3e11ed468fe553bac32282eab55a(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c07b2117eb006f9191002462e31cf4c0e(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Character_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			cf7b68ad2ce9ea6aac91d5ad84db29c41(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Item_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c4d68ff6c62e95ee31d8365d3920e5dce(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Player_CustomPropertyCheck:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3500);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c1f78a843c1565fbb971a2e5253d8909e(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (!(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3386);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			c1985e1304d050ba10dd39629ba81048a(ref c428ebf94dee726b1e31b460540bbbc1f);
			if (((Control)cb14d51ac8530fe4463993959ce4a6d75).Text.Trim() != "")
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
			((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3386);
			((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
			((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3533);
			ce2c5ced6c431d24a05e28933584533d6(ref c428ebf94dee726b1e31b460540bbbc1f);
			ce2c5ced6c431d24a05e28933584533d6(ref cb110e655831717067e74b6e01e57f651);
			if (((Control)cb110e655831717067e74b6e01e57f651).Text.Trim() != "")
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3533);
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cb110e655831717067e74b6e01e57f651).Visible = true;
			}
			else
			{
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3419);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_AdditionalDataCheck:
			if (c48d5625ef051338905ddc110c05a3e45().InputType != Action.ActionInputType.None)
			{
				__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
			}
			else
			{
				if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3576), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3810), (MessageBoxButtons)4) != 6)
				{
					if (cbConditionStep1.Items.Count <= 0)
					{
						__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
					}
					else
					{
						((ListControl)cbConditionStep1).SelectedIndex = 0;
					}
					break;
				}
				tvActionsConditions.SelectedNode = c3ede567c56bcc31cebb9f8c7704be790();
				((Control)ca97c16bb25e579acbfca5f9ec5f38762).Select();
			}
			switch (c48d5625ef051338905ddc110c05a3e45().InputType)
			{
			case Action.ActionInputType.Text:
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2755);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = false;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = false;
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			case Action.ActionInputType.Character:
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3924);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
				c9a877e27f5e26ffc6a1c719698489fb2(ref c428ebf94dee726b1e31b460540bbbc1f);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			case Action.ActionInputType.Object:
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4007);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
				ce3c00b0a0517e9e31c103c4ba2455e93(ref c428ebf94dee726b1e31b460540bbbc1f);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			case Action.ActionInputType.Inventory:
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4007);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
				cb8a0198efb03167ef7b9f2a7bd07af0f(ref c428ebf94dee726b1e31b460540bbbc1f);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			case Action.ActionInputType.ObjectOrCharacter:
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4084);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
				c7503c041a1d4533d3d0ac1d3e68374d5(ref c428ebf94dee726b1e31b460540bbbc1f);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			case Action.ActionInputType.Custom:
			{
				((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4187);
				((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = true;
				((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = true;
				c428ebf94dee726b1e31b460540bbbc1f.Items.Clear();
				IEnumerator enumerator = cbe61056f04fc0861514479244d36e741.Items.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
						string text = (string)enumerator.Current;
						c428ebf94dee726b1e31b460540bbbc1f.Items.Add((object)text);
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(ActionControl.cf6b4fe95d8a6bb4545e52d36ae84112c());
					}
					else
					{
						disposable.Dispose();
					}
				}
				((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3271);
				((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
				((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
				((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
				((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3849);
				break;
			}
			}
			break;
		}
	}

	private void c2c95007c30beadab9f3e3e2216adc4a7(object P_0, EventArgs P_1)
	{
		c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = true;
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		c4cdb686be356c8c4a17fd4b8ecfdbdc8();
		if (tvActionsConditions.SelectedNode != null)
		{
			__ldtoken(ActionControl.c2c95007c30beadab9f3e3e2216adc4a7(object, EventArgs));
			tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
		}
	}

	private string cee63400536b49afc634b51f621e13ca3(Command P_0)
	{
		string text = string.Empty;
		if (P_0 == null)
		{
			__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
		}
		else
		{
			text = Command.GetCommandName(P_0.cmdtype);
			if (!(P_0.CommandPart2 != string.Empty))
			{
				__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
			}
			else
			{
				try
				{
					Guid guid = new Guid(P_0.CommandPart2);
					if (!(guid == Room.CurrentRoomGuid))
					{
						__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
						if (!(guid == Room.VoidRoomGuid))
						{
							__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
							if (guid == GameObject.SelfObjectGuid)
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4304);
							}
							else if (c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid) == null)
							{
								__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
								text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4325) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(guid.ToString()).name;
							}
							else
							{
								text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4325) + c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid).Name;
							}
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4287);
						}
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4256);
					}
				}
				catch
				{
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4325) + P_0.CommandPart2;
				}
			}
			if (!(P_0.CommandPart3 != string.Empty))
			{
				__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
			}
			else
			{
				try
				{
					Guid guid2 = new Guid(P_0.CommandPart3);
					if (!(guid2 == Room.CurrentRoomGuid))
					{
						__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
						if (!(guid2 == Room.VoidRoomGuid))
						{
							__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
							if (!(guid2 == GameObject.SelfObjectGuid))
							{
								__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
								if (c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid2) == null)
								{
									__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
									text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(guid2.ToString()).name;
								}
								else
								{
									text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid2).Name;
								}
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4304);
							}
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4361);
						}
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4330);
					}
				}
				catch
				{
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + P_0.CommandPart3;
				}
			}
			if (!(P_0.CommandPart4 != string.Empty))
			{
				__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
			}
			else
			{
				try
				{
					Guid guid3 = new Guid(P_0.CommandPart4);
					if (!(guid3 == Room.CurrentRoomGuid))
					{
						__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
						if (!(guid3 == Room.VoidRoomGuid))
						{
							__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
							if (!(guid3 == GameObject.SelfObjectGuid))
							{
								__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
								if (c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid3) == null)
								{
									__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
									text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(guid3.ToString()).name;
								}
								else
								{
									text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + c54f9a911545745b85ae6f74355697f8b.GetRoomByID(guid3).Name;
								}
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4304);
							}
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4361);
						}
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4330);
					}
				}
				catch
				{
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + P_0.CommandPart4;
				}
			}
			if (!(P_0.CommandText != string.Empty))
			{
				__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
			}
			else if (P_0.CommandText.Length <= 20)
			{
				__ldtoken(ActionControl.cee63400536b49afc634b51f621e13ca3(Command));
				text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + P_0.CommandText;
			}
			else
			{
				text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4378) + P_0.CommandText.Substring(0, 20) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4383);
			}
		}
		return text;
	}

	private void c4cdb686be356c8c4a17fd4b8ecfdbdc8()
	{
		if (cbCommandStep1.SelectedItem == null)
		{
			return;
		}
		__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
		((Control)cba88c834a279c3e211d684cb838406e9).Visible = false;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = false;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = false;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = false;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = false;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
		switch (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex)
		{
		case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4390);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			c8afe3d488c3b0e8fc1e9387a526eeb58(ref c962ce47954ab1816402cab8d8ab59271);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4423);
			cfa596a2962cb6f1785076102cb425102(ref c2332b911806c4b9e235af5bfdc94f97d);
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_MM_GETRANDOMGROUP:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4390);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			c8afe3d488c3b0e8fc1e9387a526eeb58(ref c962ce47954ab1816402cab8d8ab59271);
			ca43abf32ab310331d932276c8ccc4578(ref c2332b911806c4b9e235af5bfdc94f97d);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4526);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_CANCELMOVE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4565);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_Status_ItemVisibleInvisible:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4594);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4641);
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.StatusBarItems.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					StatusBarItem statusBarItem = (StatusBarItem)enumerator.Current;
					c962ce47954ab1816402cab8d8ab59271.Items.Add((object)statusBarItem.Name);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				}
				else
				{
					disposable.Dispose();
				}
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3367));
			break;
		}
		case Command.CommandType.CT_LOOP_BREAK:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4565);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4565);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c6cb86b472b34cb9adb974fc37a575fd8(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4565);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c6cb86b472b34cb9adb974fc37a575fd8(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_ADD:
		case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4692);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4729);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4692);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4784);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4849);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c2332b911806c4b9e235af5bfdc94f97d);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c1ae51f04467ab9b62260d376b5dc5cba);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4900);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4729);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_ITEM_SET_VISIBILITY:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4955);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4980);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3367));
			break;
		case Command.CommandType.CT_ITEM_LAYERED_WEAR:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5046);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c349a21a2335626aa7e1314e32f94ac14(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects && c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bWearable)
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5106);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c349a21a2335626aa7e1314e32f94ac14(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else if (!c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bWearable)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5137);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5196);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			ceebd82bf878924f11c72a3e53f146fee(ref c962ce47954ab1816402cab8d8ab59271);
			ceebd82bf878924f11c72a3e53f146fee(ref c2332b911806c4b9e235af5bfdc94f97d);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				break;
			}
			GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (objectByName == null)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else if (objectByName.bContainer)
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		}
		case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5251);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4489);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			caa690c86d25f84e2a237e7236d7c1fa3(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4565);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5300);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c6cb86b472b34cb9adb974fc37a575fd8(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETPLAYERDESC:
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			break;
		case Command.CommandType.CT_SETPLAYERNAME:
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_SETPLAYERGENDER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5349);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3007));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3016));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3029));
			break;
		case Command.CommandType.CT_CHAR_SET_GENDER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5378);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5349);
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4460);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3007));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3016));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3029));
			break;
		case Command.CommandType.CT_CHAR_SET_NAME:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5378);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5349);
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5413);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5448);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5349);
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5473);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4955);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5349);
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5498);
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_PAUSEGAME:
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case Command.CommandType.CT_EXECUTETIMER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5523);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5536);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cd2d3de29640e9e8d9ddf4f38c453655d(ref c962ce47954ab1816402cab8d8ab59271);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5569));
			break;
		case Command.CommandType.CT_RESETTIMER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5523);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5536);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cd2d3de29640e9e8d9ddf4f38c453655d(ref c962ce47954ab1816402cab8d8ab59271);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5569));
			break;
		case Command.CommandType.CT_SETTIMER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5523);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5536);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cd2d3de29640e9e8d9ddf4f38c453655d(ref c962ce47954ab1816402cab8d8ab59271);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5569));
			break;
		case Command.CommandType.CT_SETVARIABLEBYINPUT:
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = true;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = true;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = true;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = true;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = true;
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5586);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5609);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5642);
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5683));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5692));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(708));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5713));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5758));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5771));
			c8afe3d488c3b0e8fc1e9387a526eeb58(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = true;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = true;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = true;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = true;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = true;
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5586);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5609);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5642);
			c962ce47954ab1816402cab8d8ab59271.Items.Clear();
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5683));
			c962ce47954ab1816402cab8d8ab59271.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5758));
			caa690c86d25f84e2a237e7236d7c1fa3(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_SETCHARDESC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5790);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETROOMDESCRIPTION:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5831);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5862);
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem5 = new RoomComboItem();
			roomComboItem5.UniqueID = Room.CurrentRoomGuid;
			roomComboItem5.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem5);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5905);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5862);
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem4 = new RoomComboItem();
			roomComboItem4.UniqueID = Room.CurrentRoomGuid;
			roomComboItem4.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem4);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMPICTURE:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5966);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5862);
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = Room.CurrentRoomGuid;
			roomComboItem3.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem3);
			break;
		}
		case Command.CommandType.CT_SETITEMDESC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6019);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects)
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			cbbe3d3ac6416ab1a3b8fd501057c8841(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			cf7b68ad2ce9ea6aac91d5ad84db29c41(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			c17ab3e11ed468fe553bac32282eab55a(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			c07b2117eb006f9191002462e31cf4c0e(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			c4d68ff6c62e95ee31d8365d3920e5dce(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6107);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce2c5ced6c431d24a05e28933584533d6(ref c962ce47954ab1816402cab8d8ab59271);
			c1f78a843c1565fbb971a2e5253d8909e(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6152);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5251);
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6169);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6169);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			c78fbc4d9f720fc39652d378873e33e16(ref c962ce47954ab1816402cab8d8ab59271);
			caa690c86d25f84e2a237e7236d7c1fa3(ref c1ae51f04467ab9b62260d376b5dc5cba);
			if (!(tvActionsConditions.SelectedNode.Tag is Command command))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				((Control)c1ae51f04467ab9b62260d376b5dc5cba).Text = command.CommandPart4;
			}
			break;
		case Command.CommandType.CT_SETVARIABLE:
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6169);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6169);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6169);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			c1985e1304d050ba10dd39629ba81048a(ref c962ce47954ab1816402cab8d8ab59271);
			if (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				break;
			}
			IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.VariableList.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					GameVariable gameVariable = (GameVariable)enumerator2.Current;
					switch (gameVariable.vartype)
					{
					case GameVariable.VarType.VT_NUMBERARRAY:
					case GameVariable.VarType.VT_STRINGARRAY:
					case GameVariable.VarType.VT_DATETIMEARRAY:
						c962ce47954ab1816402cab8d8ab59271.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6198) + gameVariable.varname));
						break;
					}
				}
				break;
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6211);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			cbbe3d3ac6416ab1a3b8fd501057c8841(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6285);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			c17ab3e11ed468fe553bac32282eab55a(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6330);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			c07b2117eb006f9191002462e31cf4c0e(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6381);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (!(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != ""))
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			cf7b68ad2ce9ea6aac91d5ad84db29c41(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6434);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			c4d68ff6c62e95ee31d8365d3920e5dce(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6477);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			if (((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text.Trim() != "")
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			}
			else
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6254);
				if (!(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text.Trim() != ""))
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				}
				else
				{
					((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
					((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
				}
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			}
			c1f78a843c1565fbb971a2e5253d8909e(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_IMPORTVARIABLE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6524);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c1985e1304d050ba10dd39629ba81048a(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_EXPORTVARIABLE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6563);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c8459d47c5bfc33eb1a5ef873381d0121(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_DEBUGTEXT:
		case Command.CommandType.CT_DISPLAYTEXT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		case Command.CommandType.CT_JAVA_SET_RAGS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6602);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		case Command.CommandType.CT_COMMENT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6639);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		case Command.CommandType.CT_DISPLAYPLAYERDESC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		case Command.CommandType.CT_DISPLAYITEMDESC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6684);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_MOVEITEMTOINV:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6717);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cb8a0198efb03167ef7b9f2a7bd07af0f(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects && c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bCarryable)
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6744);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MOVEITEMTOOBJ:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6777);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6818);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			ceebd82bf878924f11c72a3e53f146fee(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOROOM:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6863);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem10 = new RoomComboItem();
			roomComboItem10.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			roomComboItem10.UniqueID = Room.CurrentRoomGuid;
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem10);
			roomComboItem10 = new RoomComboItem();
			roomComboItem10.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886);
			roomComboItem10.UniqueID = Room.VoidRoomGuid;
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem10);
			break;
		}
		case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6863);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem9 = new RoomComboItem();
			roomComboItem9.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			roomComboItem9.UniqueID = Room.CurrentRoomGuid;
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem9);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOROOM:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6717);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6899);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c2332b911806c4b9e235af5bfdc94f97d);
			RoomComboItem roomComboItem8 = new RoomComboItem();
			roomComboItem8.UniqueID = Room.CurrentRoomGuid;
			roomComboItem8.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem8);
			roomComboItem8 = new RoomComboItem();
			roomComboItem8.UniqueID = Room.VoidRoomGuid;
			roomComboItem8.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem8);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOCHAR:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6717);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6934);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			c9a877e27f5e26ffc6a1c719698489fb2(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_SETEXIT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6990);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			((ListControl)c962ce47954ab1816402cab8d8ab59271).SelectedIndex = 0;
			c6f2dc844180cf7f055c8a4e1c61e7d18(ref c2332b911806c4b9e235af5bfdc94f97d, ((RoomComboItem)c962ce47954ab1816402cab8d8ab59271.SelectedItem).UniqueID);
			break;
		case Command.CommandType.CT_SETEXITDESTINATION:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6990);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7031);
			((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			cdae9c86e90fc7d836057f17172d875dc(ref c2332b911806c4b9e235af5bfdc94f97d);
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c1ae51f04467ab9b62260d376b5dc5cba);
			c1ae51f04467ab9b62260d376b5dc5cba.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7072));
			break;
		case Command.CommandType.CT_DISPLAYVARIABLE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7085);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6990);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c1985e1304d050ba10dd39629ba81048a(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETROOMPIC:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem7 = new RoomComboItem();
			roomComboItem7.UniqueID = Room.CurrentRoomGuid;
			roomComboItem7.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem7);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		}
		case Command.CommandType.CT_CHAR_SETPORT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_CHAR_DISPLAYPORT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7164);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5862);
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETROOMLAYEREDPIC:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			RoomComboItem roomComboItem6 = new RoomComboItem();
			roomComboItem6.UniqueID = Room.CurrentRoomGuid;
			roomComboItem6.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)roomComboItem6);
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c2332b911806c4b9e235af5bfdc94f97d);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7072));
			break;
		}
		case Command.CommandType.CT_SETPLAYERPORTRAIT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7227));
			break;
		case Command.CommandType.CT_MM_SET_UD_COMPASS:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7227));
			break;
		case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7072));
			break;
		case Command.CommandType.CT_DISPLAYPICTURE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7246);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7246);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7246);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7246);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7126);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETOBJECTACTION:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7274);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.quickcommand)
				{
					__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
				}
				else
				{
					c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289));
				}
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			break;
		case Command.CommandType.CT_SETCHARACTION:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7274);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETPLAYERACTION:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7302);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.Count; i++)
			{
				Action action = (Action)c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions[i];
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7351)));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7366)));
			}
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		}
		case Command.CommandType.CT_SETROOMACTION:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7274);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_SETLOCKEDUNLOCKED:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7385);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c15cf4e80b5f3b272777d8e14d648a125(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else if (!c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bLockable)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313));
			break;
		case Command.CommandType.CT_SETOPENCLOSED:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7385);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c682cfa44cc8a4e63db421df2e153e621(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects && c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bOpenable)
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300));
			break;
		case Command.CommandType.CT_SETITEMTOWORN:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7385);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c349a21a2335626aa7e1314e32f94ac14(ref c962ce47954ab1816402cab8d8ab59271);
			if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else if (!c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).bWearable)
			{
				__ldtoken(ActionControl.c4cdb686be356c8c4a17fd4b8ecfdbdc8());
			}
			else
			{
				c962ce47954ab1816402cab8d8ab59271.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)));
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330));
			break;
		case Command.CommandType.CT_DISPLAYCHARDESC:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7385);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MOVECHAR:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c2332b911806c4b9e235af5bfdc94f97d);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem2);
			roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.VoidRoomGuid;
			roomComboItem2.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem2);
			break;
		}
		case Command.CommandType.CT_MOVECHARINVTOPLAYER:
		{
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c2332b911806c4b9e235af5bfdc94f97d);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem);
			roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.VoidRoomGuid;
			roomComboItem.RoomName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Insert(0, (object)roomComboItem);
			break;
		}
		case Command.CommandType.CT_MOVEPLAYER:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			cbaa0bdae0fbe840f3f76cbd7f541a35f(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MOVETOCHAR:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_MOVETOOBJ:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c962ce47954ab1816402cab8d8ab59271);
			break;
		case Command.CommandType.CT_CHAR_MOVETOOBJ:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7143);
			((Control)c0409bb493de758becfc185d928829028).Visible = true;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7259);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5073);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			c9a877e27f5e26ffc6a1c719698489fb2(ref c962ce47954ab1816402cab8d8ab59271);
			ce3c00b0a0517e9e31c103c4ba2455e93(ref c2332b911806c4b9e235af5bfdc94f97d);
			break;
		case Command.CommandType.CT_ENDGAME:
			((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6074);
			((Control)c0409bb493de758becfc185d928829028).Visible = false;
			((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7398);
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			break;
		}
	}

	private void c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.PictureList.Count; i++)
		{
			__ldtoken(ActionControl.c3cd0ee532d77e1e7d4b6aeca6e1777ad(ref ComboBox));
			P_0.Items.Add((object)((GamePicture)c54f9a911545745b85ae6f74355697f8b.PictureList[i]).TheName);
		}
	}

	private void ca43abf32ab310331d932276c8ccc4578(ref ComboBox P_0)
	{
		try
		{
			P_0.Items.Clear();
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7459), dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(ActionControl.ca43abf32ab310331d932276c8ccc4578(ref ComboBox));
				P_0.Items.Add((object)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString());
			}
		}
		catch
		{
		}
	}

	private void cfa596a2962cb6f1785076102cb425102(ref ComboBox P_0)
	{
		try
		{
			P_0.Items.Clear();
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7516), dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				P_0.Items.Add((object)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString());
			}
		}
		catch
		{
		}
	}

	private void ce3c00b0a0517e9e31c103c4ba2455e93(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			__ldtoken(ActionControl.ce3c00b0a0517e9e31c103c4ba2455e93(ref ComboBox));
			GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
			P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void ceebd82bf878924f11c72a3e53f146fee(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.ceebd82bf878924f11c72a3e53f146fee(ref ComboBox));
				GameObject gameObject = (GameObject)enumerator.Current;
				if (!gameObject.bContainer)
				{
					__ldtoken(ActionControl.ceebd82bf878924f11c72a3e53f146fee(ref ComboBox));
				}
				else
				{
					P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void c7503c041a1d4533d3d0ac1d3e68374d5(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			__ldtoken(ActionControl.c7503c041a1d4533d3d0ac1d3e68374d5(ref ComboBox));
			GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
			P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
		for (int j = 0; j < c54f9a911545745b85ae6f74355697f8b.CharacterList.Count; j++)
		{
			__ldtoken(ActionControl.c7503c041a1d4533d3d0ac1d3e68374d5(ref ComboBox));
			P_0.Items.Add((object)((Character)c54f9a911545745b85ae6f74355697f8b.CharacterList[j]).Charname);
		}
	}

	private void cb8a0198efb03167ef7b9f2a7bd07af0f(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			if (!((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).bCarryable)
			{
				__ldtoken(ActionControl.cb8a0198efb03167ef7b9f2a7bd07af0f(ref ComboBox));
			}
			else
			{
				P_0.Items.Add((object)new RoomComboItem(((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).UniqueIdentifier, ((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).name));
			}
		}
	}

	private void c349a21a2335626aa7e1314e32f94ac14(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			__ldtoken(ActionControl.c349a21a2335626aa7e1314e32f94ac14(ref ComboBox));
			if (!((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).bWearable)
			{
				__ldtoken(ActionControl.c349a21a2335626aa7e1314e32f94ac14(ref ComboBox));
				continue;
			}
			GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
			P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void c0d5d9bba605abef3543e557396474566(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		foreach (Character character in c54f9a911545745b85ae6f74355697f8b.CharacterList)
		{
			{
				IEnumerator enumerator2 = character.Actions.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
						_ = (Action)enumerator2.Current;
					}
				}
				finally
				{
					IDisposable disposable5 = enumerator2 as IDisposable;
					if (disposable5 != null)
					{
						disposable5.Dispose();
					}
				}
			}
		}
		IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
				GameObject gameObject = (GameObject)enumerator3.Current;
				IEnumerator enumerator4 = gameObject.Actions.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
						Action action = (Action)enumerator4.Current;
						if (action.InputType != Action.ActionInputType.Custom)
						{
							__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
						}
						else
						{
							P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7571) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action.name));
						}
					}
				}
				finally
				{
					if (!(enumerator4 is IDisposable disposable))
					{
						__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable2))
			{
				__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator5 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
				Action action2 = (Action)enumerator5.Current;
				if (action2.InputType != Action.ActionInputType.Custom)
				{
					__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
				}
				else
				{
					P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7580) + action2.name));
				}
			}
		}
		finally
		{
			if (!(enumerator5 is IDisposable disposable3))
			{
				__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator6 = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
				Room room = (Room)enumerator6.Current;
				IEnumerator enumerator7 = room.Actions.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						Action action3 = (Action)enumerator7.Current;
						if (action3.InputType != Action.ActionInputType.Custom)
						{
							__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
						}
						else
						{
							P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action3.name));
						}
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable4))
					{
						__ldtoken(ActionControl.c0d5d9bba605abef3543e557396474566(ref ComboBox));
					}
					else
					{
						disposable4.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable6 = enumerator6 as IDisposable;
			if (disposable6 != null)
			{
				disposable6.Dispose();
			}
		}
	}

	private void c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		foreach (Character character in c54f9a911545745b85ae6f74355697f8b.CharacterList)
		{
			IEnumerator enumerator2 = character.Actions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
					Action action = (Action)enumerator2.Current;
					if (action.InputType == Action.ActionInputType.Custom)
					{
						P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7595) + character.Charname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action.name));
					}
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable))
				{
					__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				GameObject gameObject = (GameObject)enumerator3.Current;
				{
					IEnumerator enumerator4 = gameObject.Actions.GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
							Action action2 = (Action)enumerator4.Current;
							if (action2.InputType != Action.ActionInputType.Custom)
							{
								__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
							}
							else
							{
								P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7571) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action2.name));
							}
						}
					}
					finally
					{
						IDisposable disposable8 = enumerator4 as IDisposable;
						if (disposable8 != null)
						{
							disposable8.Dispose();
						}
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable2))
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator5 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				Action action3 = (Action)enumerator5.Current;
				if (action3.InputType != Action.ActionInputType.Custom)
				{
					__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				}
				else
				{
					P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7580) + action3.name));
				}
			}
		}
		finally
		{
			if (!(enumerator5 is IDisposable disposable3))
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator6 = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				Room room = (Room)enumerator6.Current;
				IEnumerator enumerator7 = room.Actions.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
						Action action4 = (Action)enumerator7.Current;
						if (action4.InputType != Action.ActionInputType.Custom)
						{
							__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
						}
						else
						{
							P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6979) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action4.name));
						}
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable4))
					{
						__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
					}
					else
					{
						disposable4.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator6 is IDisposable disposable5))
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
			}
			else
			{
				disposable5.Dispose();
			}
		}
		IEnumerator enumerator8 = c54f9a911545745b85ae6f74355697f8b.TimerList.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
				Timer timer = (Timer)enumerator8.Current;
				IEnumerator enumerator9 = timer.Actions.GetEnumerator();
				try
				{
					while (enumerator9.MoveNext())
					{
						Action action5 = (Action)enumerator9.Current;
						if (action5.InputType != Action.ActionInputType.Custom)
						{
							__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
						}
						else
						{
							P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5523) + timer.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + action5.name));
						}
					}
				}
				finally
				{
					if (!(enumerator9 is IDisposable disposable6))
					{
						__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
					}
					else
					{
						disposable6.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator8 is IDisposable disposable7))
			{
				__ldtoken(ActionControl.c6cb86b472b34cb9adb974fc37a575fd8(ref ComboBox));
			}
			else
			{
				disposable7.Dispose();
			}
		}
	}

	private void c9a877e27f5e26ffc6a1c719698489fb2(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.CharacterList.Count; i++)
		{
			__ldtoken(ActionControl.c9a877e27f5e26ffc6a1c719698489fb2(ref ComboBox));
			P_0.Items.Add((object)((Character)c54f9a911545745b85ae6f74355697f8b.CharacterList[i]).Charname);
		}
	}

	private void cd2d3de29640e9e8d9ddf4f38c453655d(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.TimerList.Count; i++)
		{
			__ldtoken(ActionControl.cd2d3de29640e9e8d9ddf4f38c453655d(ref ComboBox));
			P_0.Items.Add((object)((Timer)c54f9a911545745b85ae6f74355697f8b.TimerList[i]).Name);
		}
	}

	private void c15cf4e80b5f3b272777d8e14d648a125(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			__ldtoken(ActionControl.c15cf4e80b5f3b272777d8e14d648a125(ref ComboBox));
			if (!((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).bLockable)
			{
				__ldtoken(ActionControl.c15cf4e80b5f3b272777d8e14d648a125(ref ComboBox));
				continue;
			}
			GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
			P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void c682cfa44cc8a4e63db421df2e153e621(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			if (!((GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i]).bOpenable)
			{
				__ldtoken(ActionControl.c682cfa44cc8a4e63db421df2e153e621(ref ComboBox));
				continue;
			}
			GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
			P_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void c6f2dc844180cf7f055c8a4e1c61e7d18(ref ComboBox P_0, Guid P_1)
	{
		P_0.Items.Clear();
		Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(P_1);
		if (roomByID == null)
		{
			__ldtoken(ActionControl.c6f2dc844180cf7f055c8a4e1c61e7d18(ref ComboBox, Guid));
			return;
		}
		IEnumerator enumerator = roomByID.Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c6f2dc844180cf7f055c8a4e1c61e7d18(ref ComboBox, Guid));
				Exit exit = (Exit)enumerator.Current;
				if (!(exit.DestinationRoom != string.Empty))
				{
					__ldtoken(ActionControl.c6f2dc844180cf7f055c8a4e1c61e7d18(ref ComboBox, Guid));
					continue;
				}
				P_0.Items.Add((object)(exit.Direction.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7604) + c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
				P_0.Items.Add((object)(exit.Direction.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7627) + c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.c6f2dc844180cf7f055c8a4e1c61e7d18(ref ComboBox, Guid));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void cdae9c86e90fc7d836057f17172d875dc(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7654));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7665));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7676));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7685));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7694));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7699));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7708));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7727));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7746));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7765));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7784));
		P_0.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7789));
	}

	private void cbaa0bdae0fbe840f3f76cbd7f541a35f(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.cbaa0bdae0fbe840f3f76cbd7f541a35f(ref ComboBox));
				Room room = (Room)enumerator.Current;
				RoomComboItem roomComboItem = new RoomComboItem();
				roomComboItem.UniqueID = room.UniqueID;
				if (room.SDesc.Trim().Length <= 0)
				{
					__ldtoken(ActionControl.cbaa0bdae0fbe840f3f76cbd7f541a35f(ref ComboBox));
					roomComboItem.RoomName = room.Name;
				}
				else
				{
					roomComboItem.RoomName = room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7796) + room.SDesc;
				}
				P_0.Items.Add((object)roomComboItem);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.cbaa0bdae0fbe840f3f76cbd7f541a35f(ref ComboBox));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c23a6919f2505954c7e73cda8c53f77de(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.RoomGroups.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c23a6919f2505954c7e73cda8c53f77de(ref ComboBox));
				string text = (string)enumerator.Current;
				P_0.Items.Add((object)text);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.c23a6919f2505954c7e73cda8c53f77de(ref ComboBox));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b.RoomList.Count <= 0)
		{
			__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
			return;
		}
		int num = 0;
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
				Room room = (Room)enumerator.Current;
				if (num != 0)
				{
					__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
				}
				else
				{
					IEnumerator enumerator2 = room.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
							CustomProperty customProperty = (CustomProperty)enumerator2.Current;
							P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7799) + customProperty.Name));
							num++;
						}
					}
					finally
					{
						if (!(enumerator2 is IDisposable disposable))
						{
							__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
						}
						else
						{
							disposable.Dispose();
						}
					}
				}
				IEnumerator enumerator3 = room.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
						CustomProperty customProperty2 = (CustomProperty)enumerator3.Current;
						P_0.Items.Add((object)(room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty2.Name));
					}
				}
				finally
				{
					if (!(enumerator3 is IDisposable disposable2))
					{
						__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
					}
					else
					{
						disposable2.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable3))
			{
				__ldtoken(ActionControl.cbbe3d3ac6416ab1a3b8fd501057c8841(ref ComboBox));
			}
			else
			{
				disposable3.Dispose();
			}
		}
	}

	private void cf7b68ad2ce9ea6aac91d5ad84db29c41(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b.CharacterList.Count <= 0)
		{
			__ldtoken(ActionControl.cf7b68ad2ce9ea6aac91d5ad84db29c41(ref ComboBox));
			return;
		}
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Character character = (Character)enumerator.Current;
				IEnumerator enumerator2 = character.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(ActionControl.cf7b68ad2ce9ea6aac91d5ad84db29c41(ref ComboBox));
						CustomProperty customProperty = (CustomProperty)enumerator2.Current;
						P_0.Items.Add((object)(character.Charname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty.Name));
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(ActionControl.cf7b68ad2ce9ea6aac91d5ad84db29c41(ref ComboBox));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(ActionControl.cf7b68ad2ce9ea6aac91d5ad84db29c41(ref ComboBox));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c17ab3e11ed468fe553bac32282eab55a(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b.TimerList.Count <= 0)
		{
			__ldtoken(ActionControl.c17ab3e11ed468fe553bac32282eab55a(ref ComboBox));
			return;
		}
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.TimerList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Timer timer = (Timer)enumerator.Current;
				IEnumerator enumerator2 = timer.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						CustomProperty customProperty = (CustomProperty)enumerator2.Current;
						P_0.Items.Add((object)(timer.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty.Name));
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(ActionControl.c17ab3e11ed468fe553bac32282eab55a(ref ComboBox));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(ActionControl.c17ab3e11ed468fe553bac32282eab55a(ref ComboBox));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c07b2117eb006f9191002462e31cf4c0e(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b.VariableList.Count <= 0)
		{
			__ldtoken(ActionControl.c07b2117eb006f9191002462e31cf4c0e(ref ComboBox));
			return;
		}
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.VariableList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c07b2117eb006f9191002462e31cf4c0e(ref ComboBox));
				GameVariable gameVariable = (GameVariable)enumerator.Current;
				IEnumerator enumerator2 = gameVariable.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(ActionControl.c07b2117eb006f9191002462e31cf4c0e(ref ComboBox));
						CustomProperty customProperty = (CustomProperty)enumerator2.Current;
						P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty.Name));
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(ActionControl.c07b2117eb006f9191002462e31cf4c0e(ref ComboBox));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}
	}

	private void c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b.ObjectList.Count <= 0)
		{
			__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
			return;
		}
		int num = 0;
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
				GameObject gameObject = (GameObject)enumerator.Current;
				if (num != 0)
				{
					__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
				}
				else if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
				{
					__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
				}
				else
				{
					{
						IEnumerator enumerator2 = gameObject.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
								CustomProperty customProperty = (CustomProperty)enumerator2.Current;
								P_0.Items.Add((object)(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7828) + customProperty.Name));
								num++;
							}
						}
						finally
						{
							IDisposable disposable3 = enumerator2 as IDisposable;
							if (disposable3 != null)
							{
								disposable3.Dispose();
							}
						}
					}
				}
				IEnumerator enumerator3 = gameObject.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
						CustomProperty customProperty2 = (CustomProperty)enumerator3.Current;
						P_0.Items.Add((object)(gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty2.Name));
					}
				}
				finally
				{
					if (!(enumerator3 is IDisposable disposable))
					{
						__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(ActionControl.c4d68ff6c62e95ee31d8365d3920e5dce(ref ComboBox));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c1f78a843c1565fbb971a2e5253d8909e(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				P_0.Items.Add((object)customProperty.Name);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.c1f78a843c1565fbb971a2e5253d8909e(ref ComboBox));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c1985e1304d050ba10dd39629ba81048a(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.VariableList.Count; i++)
		{
			__ldtoken(ActionControl.c1985e1304d050ba10dd39629ba81048a(ref ComboBox));
			GameVariable gameVariable = (GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY)
			{
				__ldtoken(ActionControl.c1985e1304d050ba10dd39629ba81048a(ref ComboBox));
			}
			else if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY && gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
			{
				__ldtoken(ActionControl.c1985e1304d050ba10dd39629ba81048a(ref ComboBox));
				P_0.Items.Add((object)gameVariable.varname);
				continue;
			}
			for (int j = 0; j < gameVariable.VarArray.Count; j++)
			{
				__ldtoken(ActionControl.c1985e1304d050ba10dd39629ba81048a(ref ComboBox));
				if (!(gameVariable.VarArray[j] is ArrayList))
				{
					__ldtoken(ActionControl.c1985e1304d050ba10dd39629ba81048a(ref ComboBox));
					P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
					continue;
				}
				P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
			}
		}
	}

	private void c8459d47c5bfc33eb1a5ef873381d0121(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i];
			P_0.Items.Add((object)gameVariable.varname);
		}
	}

	private void c78fbc4d9f720fc39652d378873e33e16(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.VariableList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
				GameVariable gameVariable = (GameVariable)enumerator.Current;
				if (gameVariable.vartype == GameVariable.VarType.VT_DATETIME)
				{
					__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
				}
				else if (gameVariable.vartype != GameVariable.VarType.VT_NUMBER)
				{
					__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
					if (gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY)
					{
						__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
					}
					else if (gameVariable.vartype != GameVariable.VarType.VT_DATETIMEARRAY)
					{
						__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
						continue;
					}
					for (int i = 0; i < gameVariable.VarArray.Count; i++)
					{
						__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
						if (!(gameVariable.VarArray[i] is ArrayList))
						{
							__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
							P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
							continue;
						}
						P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[i]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
					}
					continue;
				}
				P_0.Items.Add((object)gameVariable.varname);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.c78fbc4d9f720fc39652d378873e33e16(ref ComboBox));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void ce2c5ced6c431d24a05e28933584533d6(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.VariableList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
				GameVariable gameVariable = (GameVariable)enumerator.Current;
				if (gameVariable.vartype == GameVariable.VarType.VT_STRING)
				{
					__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
				}
				else if (gameVariable.vartype != GameVariable.VarType.VT_NUMBER)
				{
					if (gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
					{
						__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
					}
					else if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
					{
						__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
						continue;
					}
					for (int i = 0; i < gameVariable.VarArray.Count; i++)
					{
						__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
						if (!(gameVariable.VarArray[i] is ArrayList))
						{
							__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
							P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
							continue;
						}
						P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[i]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
					}
					continue;
				}
				P_0.Items.Add((object)gameVariable.varname);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.ce2c5ced6c431d24a05e28933584533d6(ref ComboBox));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.VariableList.Count; i++)
		{
			__ldtoken(ActionControl.c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox));
			GameVariable gameVariable = (GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i];
			if (gameVariable.vartype != GameVariable.VarType.VT_STRING)
			{
				__ldtoken(ActionControl.c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox));
				if (gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
				{
					__ldtoken(ActionControl.c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox));
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					__ldtoken(ActionControl.c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox));
					if (!(gameVariable.VarArray[j] is ArrayList))
					{
						__ldtoken(ActionControl.c8afe3d488c3b0e8fc1e9387a526eeb58(ref ComboBox));
						P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
						continue;
					}
					P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
				}
			}
			else
			{
				P_0.Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void caa690c86d25f84e2a237e7236d7c1fa3(ref ComboBox P_0)
	{
		P_0.Items.Clear();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i];
			if (gameVariable.vartype != GameVariable.VarType.VT_NUMBER)
			{
				__ldtoken(ActionControl.caa690c86d25f84e2a237e7236d7c1fa3(ref ComboBox));
				if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
				{
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					__ldtoken(ActionControl.caa690c86d25f84e2a237e7236d7c1fa3(ref ComboBox));
					if (!(gameVariable.VarArray[j] is ArrayList))
					{
						__ldtoken(ActionControl.caa690c86d25f84e2a237e7236d7c1fa3(ref ComboBox));
						P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
						continue;
					}
					P_0.Items.Add((object)(gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857)));
				}
			}
			else
			{
				P_0.Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void c72069955080f0b49a01145da2cff927b(object P_0, EventArgs P_1)
	{
		Action action = c48d5625ef051338905ddc110c05a3e45();
		if (action == null)
		{
			__ldtoken(ActionControl.c72069955080f0b49a01145da2cff927b(object, EventArgs));
		}
		else
		{
			action.bActive = c225aaa2c7205152650b3b8a11c5c00c3.Checked;
		}
	}

	private ArrayList c7f49c36388f468bae9971fa86acff3b7(bool P_0)
	{
		ArrayList result = null;
		if (!c521610853650504f145dd1cf178b1d8f())
		{
			__ldtoken(ActionControl.c7f49c36388f468bae9971fa86acff3b7(bool));
			Condition condition = ce934006d23f9c541701af4a7e1dab46f();
			if (condition != null)
			{
				if (!P_0)
				{
					__ldtoken(ActionControl.c7f49c36388f468bae9971fa86acff3b7(bool));
					result = condition.FailCommands;
				}
				else
				{
					result = condition.PassCommands;
				}
			}
		}
		else
		{
			result = ((!P_0) ? c48d5625ef051338905ddc110c05a3e45().FailCommands : c48d5625ef051338905ddc110c05a3e45().PassCommands);
		}
		return result;
	}

	private ArrayList c9ace99d5d5238fce319298fe34c80436()
	{
		ArrayList result = null;
		switch (c966c316b5de02c6ef56a4713e8bdaeea)
		{
		case PageType.characters:
			result = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
			break;
		case PageType.objects:
			result = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
			break;
		case PageType.player:
			result = c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions;
			break;
		case PageType.room:
			result = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac)).Actions;
			break;
		case PageType.timers:
			result = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
			break;
		case PageType.quickcommand:
			result = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
			break;
		}
		return result;
	}

	private void c968e06d031374e326a9af015b02f7b7b(object P_0, EventArgs P_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition != null)
		{
			__ldtoken(ActionControl.c968e06d031374e326a9af015b02f7b7b(object, EventArgs));
		}
		else if (tvActionsConditions.SelectedNode.Parent == null)
		{
			__ldtoken(ActionControl.c968e06d031374e326a9af015b02f7b7b(object, EventArgs));
		}
		else
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (condition != null)
		{
			((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).CondType = ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex;
			if (((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex <= 0)
			{
				__ldtoken(ActionControl.c968e06d031374e326a9af015b02f7b7b(object, EventArgs));
				c4e7f938e7e498f7339be7ccf18e84053.Items[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex] = ((Control)cbConditionStep1).Text;
			}
			else
			{
				c4e7f938e7e498f7339be7ccf18e84053.Items[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex] = ((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).CkType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + ((Control)cbConditionStep1).Text;
			}
		}
	}

	private void cd945a70e7b257dcbab3e68919917d667(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			__ldtoken(ActionControl.cd945a70e7b257dcbab3e68919917d667(object, EventArgs));
			Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
			if (condition == null)
			{
				condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
			}
			if (condition == null)
			{
				__ldtoken(ActionControl.cd945a70e7b257dcbab3e68919917d667(object, EventArgs));
			}
			else if (!(c428ebf94dee726b1e31b460540bbbc1f.SelectedItem is RoomComboItem roomComboItem))
			{
				__ldtoken(ActionControl.cd945a70e7b257dcbab3e68919917d667(object, EventArgs));
				((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep2 = ((Control)c428ebf94dee726b1e31b460540bbbc1f).Text;
				c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)c428ebf94dee726b1e31b460540bbbc1f).Text);
			}
			else
			{
				((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep2 = roomComboItem.UniqueID.ToString();
			}
		}
	}

	private void c8934b7d402770ca156a6b328abdbe716(object P_0, EventArgs P_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition != null)
		{
			__ldtoken(ActionControl.c8934b7d402770ca156a6b328abdbe716(object, EventArgs));
		}
		else
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (cb14d51ac8530fe4463993959ce4a6d75.SelectedItem is RoomComboItem roomComboItem)
		{
			((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep3 = roomComboItem.UniqueID.ToString();
			return;
		}
		((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep3 = ((Control)cb14d51ac8530fe4463993959ce4a6d75).Text;
		c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text);
	}

	private void c7350437f8d195123268cc15c01f24dc0(object P_0, EventArgs P_1)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition != null)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
		}
		else
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Variable_Comparison)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
		}
		else if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
			goto IL_011e;
		}
		GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c428ebf94dee726b1e31b460540bbbc1f).Text, null));
		if (variableByName == null)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
		}
		else if (variableByName.vartype != GameVariable.VarType.VT_NUMBER)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
		}
		else
		{
			try
			{
				Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)ce461a44e2020b57573abdc365294fa10).Text, null));
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7860));
			}
		}
		goto IL_011e;
		IL_011e:
		if (condition == null)
		{
			__ldtoken(ActionControl.c7350437f8d195123268cc15c01f24dc0(object, EventArgs));
			return;
		}
		((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep4 = ((Control)ce461a44e2020b57573abdc365294fa10).Text;
		c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)ce461a44e2020b57573abdc365294fa10).Text);
	}

	private void c5240ae5e92313584a5051ae9f628ea81(object P_0, EventArgs P_1)
	{
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Room_CustomPropertyCheck && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Player_CustomPropertyCheck && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Item_CustomPropertyCheck)
		{
			if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Character_CustomPropertyCheck)
			{
				__ldtoken(ActionControl.c5240ae5e92313584a5051ae9f628ea81(object, EventArgs));
			}
			else if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Timer_CustomPropertyCheck && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_CustomPropertyCheck)
			{
				__ldtoken(ActionControl.c5240ae5e92313584a5051ae9f628ea81(object, EventArgs));
				if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_Comparison && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
				{
					__ldtoken(ActionControl.c5240ae5e92313584a5051ae9f628ea81(object, EventArgs));
					if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_To_Variable_Comparison)
					{
						__ldtoken(ActionControl.c5240ae5e92313584a5051ae9f628ea81(object, EventArgs));
						return;
					}
					GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c428ebf94dee726b1e31b460540bbbc1f).Text, null));
					if (variableByName != null)
					{
						switch (variableByName.vartype)
						{
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
							((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
							((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
							((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
							((Control)cb110e655831717067e74b6e01e57f651).Visible = true;
							cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8050));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8089));
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
							((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
							((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
							((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
							((Control)cb110e655831717067e74b6e01e57f651).Visible = true;
							cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
							cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
					}
					return;
				}
				GameVariable variableByName2 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c428ebf94dee726b1e31b460540bbbc1f).Text, null));
				if (variableByName2 == null)
				{
					__ldtoken(ActionControl.c5240ae5e92313584a5051ae9f628ea81(object, EventArgs));
					return;
				}
				switch (variableByName2.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
					((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
					((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
					cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8089));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8050));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8134));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8159));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8182));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8223));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8258));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8285));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8330));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8369));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8398));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8445));
					break;
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
					((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
					((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
					cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8050));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8089));
					break;
				case GameVariable.VarType.VT_STRING:
				case GameVariable.VarType.VT_STRINGARRAY:
					((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
					((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
					((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
					((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
					cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7989));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006));
					cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031));
					break;
				}
				return;
			}
		}
		((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = true;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = true;
		((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = true;
		((Control)ce461a44e2020b57573abdc365294fa10).Visible = true;
		((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3452);
		cb14d51ac8530fe4463993959ce4a6d75.Items.Clear();
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7989));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8050));
		cb14d51ac8530fe4463993959ce4a6d75.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8089));
	}

	private void c9c9b3b1dacae3d22d1860c955fd1e1b5(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.c9c9b3b1dacae3d22d1860c955fd1e1b5(object, EventArgs));
			return;
		}
		if (cbCommandStep1.SelectedItem == null)
		{
			__ldtoken(ActionControl.c9c9b3b1dacae3d22d1860c955fd1e1b5(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		if (command != null)
		{
			command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		}
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
	}

	private void c0cffdd760696ebfce4d68790e2a83844(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.c0cffdd760696ebfce4d68790e2a83844(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		if (!(c962ce47954ab1816402cab8d8ab59271.SelectedItem is RoomComboItem roomComboItem))
		{
			__ldtoken(ActionControl.c0cffdd760696ebfce4d68790e2a83844(object, EventArgs));
			command.CommandPart2 = ((Control)c962ce47954ab1816402cab8d8ab59271).Text;
			c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)c962ce47954ab1816402cab8d8ab59271).Text);
		}
		else
		{
			command.CommandPart2 = roomComboItem.UniqueID.ToString();
		}
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
	}

	private void cf473f222f97b40ce274d65e3f12994f0(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.cf473f222f97b40ce274d65e3f12994f0(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		if (!(c2332b911806c4b9e235af5bfdc94f97d.SelectedItem is RoomComboItem roomComboItem))
		{
			__ldtoken(ActionControl.cf473f222f97b40ce274d65e3f12994f0(object, EventArgs));
			command.CommandPart3 = ((Control)c2332b911806c4b9e235af5bfdc94f97d).Text;
			c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)c2332b911806c4b9e235af5bfdc94f97d).Text);
		}
		else
		{
			command.CommandPart3 = roomComboItem.UniqueID.ToString();
		}
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
	}

	private void cd31d74df2dacbbda6ae8269f0fca27f9(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.cd31d74df2dacbbda6ae8269f0fca27f9(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		command.CommandText = ((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text;
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
		c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Text);
	}

	private void cddc1ea294279bcdb05adc9c1a6e727ec(object P_0, EventArgs P_1)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		Command.CommandType ctindex = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		if (ctindex == Command.CommandType.CT_SETVARIABLE)
		{
			__ldtoken(ActionControl.cddc1ea294279bcdb05adc9c1a6e727ec(object, EventArgs));
		}
		else if (ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			goto IL_0209;
		}
		if (((Control)c962ce47954ab1816402cab8d8ab59271).Text == string.Empty)
		{
			return;
		}
		string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c962ce47954ab1816402cab8d8ab59271).Text, null);
		int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6198));
		if (num <= -1)
		{
			__ldtoken(ActionControl.cddc1ea294279bcdb05adc9c1a6e727ec(object, EventArgs));
		}
		else
		{
			text = text.Remove(num, 6);
		}
		GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(text);
		if (variableByName == null)
		{
			__ldtoken(ActionControl.cddc1ea294279bcdb05adc9c1a6e727ec(object, EventArgs));
		}
		else
		{
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (c2332b911806c4b9e235af5bfdc94f97d.SelectedItem.ToString() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955))
				{
					try
					{
						Convert.ToDateTime(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text, null), Game.myDTFI);
					}
					catch
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8486));
						((Control)c4053b9b7d85ea311db9e2c9a464192fb).Focus();
						return;
					}
				}
				else
				{
					try
					{
						Convert.ToInt32(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text, null));
					}
					catch
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7860));
					}
				}
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
				try
				{
					if (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
					{
						__ldtoken(ActionControl.cddc1ea294279bcdb05adc9c1a6e727ec(object, EventArgs));
					}
					else
					{
						Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text, null));
					}
				}
				catch
				{
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7860));
				}
				break;
			}
		}
		goto IL_0209;
		IL_0209:
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		command.CommandPart4 = ((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text;
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
		c54f9a911545745b85ae6f74355697f8b.ValidateText(((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text);
	}

	private void caf9388bdcca545ad2b074bb1de5ca97b(object P_0, EventArgs P_1)
	{
		Command.CommandType ctindex = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		if (ctindex > Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
		{
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
			switch (ctindex)
			{
			case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
				break;
			case Command.CommandType.CT_SETVARIABLEBYINPUT:
			case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
				goto IL_00ee;
			case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
			case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
			case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
			case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
			case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
			case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
			case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
			case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
				goto IL_01b9;
			case Command.CommandType.CT_SETVARIABLE:
			case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
				goto IL_02ca;
			case Command.CommandType.CT_DISPLAYVARIABLE:
				goto IL_0a1f;
			case Command.CommandType.CT_SETROOMACTION:
			{
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7302);
				c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
				Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(((RoomComboItem)c962ce47954ab1816402cab8d8ab59271.SelectedItem).UniqueID);
				if (roomByID != null)
				{
					for (int i = 0; i < roomByID.Actions.Count; i++)
					{
						__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
						Action action = (Action)roomByID.Actions[i];
						c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7351)));
						c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7366)));
					}
				}
				goto IL_10a0;
			}
			case Command.CommandType.CT_SETEXIT:
				c6f2dc844180cf7f055c8a4e1c61e7d18(ref c2332b911806c4b9e235af5bfdc94f97d, ((RoomComboItem)c962ce47954ab1816402cab8d8ab59271.SelectedItem).UniqueID);
				goto IL_10a0;
			default:
				goto IL_10a0;
			}
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
			GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c962ce47954ab1816402cab8d8ab59271).Text, null));
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
				((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8678));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8695));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8714));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8737));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8760));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8787));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8816));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8849));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8882));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8921));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8946));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8975));
				break;
			case GameVariable.VarType.VT_NUMBER:
				((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
				((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
				((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
				((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
				((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = true;
				((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
				((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
				c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8624));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8631));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8648));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8665));
				break;
			}
			goto IL_10a0;
		}
		switch (ctindex)
		{
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
			break;
		case Command.CommandType.CT_SETOBJECTACTION:
			goto IL_0c0d;
		case Command.CommandType.CT_SETCHARACTION:
		{
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7302);
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c962ce47954ab1816402cab8d8ab59271.SelectedItem.ToString());
			if (characterByName != null)
			{
				for (int j = 0; j < characterByName.Actions.Count; j++)
				{
					Action action2 = (Action)characterByName.Actions[j];
					c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action2.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7351)));
					c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action2.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7366)));
				}
			}
			goto IL_10a0;
		}
		default:
			goto IL_10a0;
		}
		goto IL_01b9;
		IL_01b9:
		((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8605);
		((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
		c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
		c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
		c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8624));
		c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8631));
		c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8648));
		c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8665));
		goto IL_10a0;
		IL_02ca:
		if (c962ce47954ab1816402cab8d8ab59271.SelectedItem == null)
		{
			return;
		}
		__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
		string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c962ce47954ab1816402cab8d8ab59271).Text, null);
		bool flag = false;
		int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6198));
		if (num <= -1)
		{
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
		}
		else
		{
			flag = true;
			text = text.Remove(num, 6);
		}
		GameVariable variableByName2 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(text);
		if (variableByName2 == null)
		{
			return;
		}
		__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
		((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8605);
		switch (variableByName2.vartype)
		{
		case GameVariable.VarType.VT_DATETIME:
		case GameVariable.VarType.VT_DATETIMEARRAY:
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
			if (flag)
			{
				__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
				break;
			}
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8678));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8695));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8714));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8737));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8760));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8787));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8816));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8849));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8882));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8921));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8946));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8975));
			break;
		case GameVariable.VarType.VT_NUMBER:
		case GameVariable.VarType.VT_NUMBERARRAY:
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = true;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = true;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955));
			if (!flag)
			{
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8624));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8631));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8648));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8665));
			}
			break;
		case GameVariable.VarType.VT_STRING:
		case GameVariable.VarType.VT_STRINGARRAY:
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = true;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = true;
			break;
		}
		goto IL_10a0;
		IL_0c0d:
		((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
		((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7302);
		c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
		GameObject gameObject = null;
		if (!(c962ce47954ab1816402cab8d8ab59271.SelectedItem.ToString() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
		{
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
			if (c962ce47954ab1816402cab8d8ab59271.SelectedItem.ToString() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289))
			{
				if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.quickcommand)
				{
					QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
					{
						IEnumerator enumerator = menuItemByName.Actions.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
								Action action3 = (Action)enumerator.Current;
								c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action3.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7351)));
								c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action3.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7366)));
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					gameObject = null;
					goto IL_0dd2;
				}
				__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
			}
			gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(((RoomComboItem)c962ce47954ab1816402cab8d8ab59271.SelectedItem).UniqueID.ToString());
		}
		else
		{
			gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
		}
		goto IL_0dd2;
		IL_00ee:
		if (!(c962ce47954ab1816402cab8d8ab59271.SelectedItem.ToString() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5758)))
		{
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = true;
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = false;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = false;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = false;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = false;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = false;
		}
		else
		{
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = true;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = true;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = true;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = true;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = true;
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = false;
		}
		goto IL_10a0;
		IL_0dd2:
		if (gameObject == null)
		{
			__ldtoken(ActionControl.caf9388bdcca545ad2b074bb1de5ca97b(object, EventArgs));
		}
		else
		{
			for (int k = 0; k < gameObject.Actions.Count; k++)
			{
				Action action4 = (Action)gameObject.Actions[k];
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action4.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7351)));
				c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)(action4.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7366)));
			}
		}
		goto IL_10a0;
		IL_10a0:
		_ = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		_ = 86;
		_ = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		_ = 41;
		return;
		IL_0a1f:
		GameVariable variableByName3 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c962ce47954ab1816402cab8d8ab59271).Text, null));
		switch (variableByName3.vartype)
		{
		case GameVariable.VarType.VT_DATETIME:
			((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9004);
			((Control)c85ec63372a2560632b32285c85e56156).Visible = true;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = true;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			c2332b911806c4b9e235af5bfdc94f97d.Items.Clear();
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9047));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9086));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9121));
			c2332b911806c4b9e235af5bfdc94f97d.Items.Add((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9156));
			((ListControl)c2332b911806c4b9e235af5bfdc94f97d).SelectedIndex = 0;
			cf473f222f97b40ce274d65e3f12994f0(null, null);
			break;
		case GameVariable.VarType.VT_NUMBER:
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		case GameVariable.VarType.VT_STRING:
			((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
			((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
			((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
			((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
			((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
			break;
		}
		goto IL_10a0;
	}

	private void c754dba63f980058cc3e8dd216d2423e9(object P_0, EventArgs P_1)
	{
		Action action = c48d5625ef051338905ddc110c05a3e45();
		if (action != null)
		{
			action.bConditionFailOnFirst = c602cc87b31944701be94229b41e8bb82.Checked;
		}
	}

	private void c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object P_0, EventArgs P_1)
	{
		Action action = c48d5625ef051338905ddc110c05a3e45();
		if (action == null)
		{
			__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
		}
		else if (!cc931d55a79f75a3ad8eeff54cc492876.Checked)
		{
			__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
			if (!c1a3979b2807ce107cbb855fb8ff7202b.Checked)
			{
				__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
				if (!c602fc3992403e5cdad0409e1900aed07.Checked)
				{
					__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
					if (!c789be2065ed12ebb629dcfca687809c5.Checked)
					{
						__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
						if (c4f77bfbc101bbe9d822a90c9ec242f9b.Checked)
						{
							action.InputType = Action.ActionInputType.Object;
						}
						else if (ce71e85e952218edc33bda5326c37ed93.Checked)
						{
							action.InputType = Action.ActionInputType.Custom;
						}
						else if (!c8af24b3132c3f9bc521cb9cccc12a224.Checked)
						{
							__ldtoken(ActionControl.c3be7ad6f4930b3f9a2d4e70f4fde2ad0(object, EventArgs));
						}
						else
						{
							action.InputType = Action.ActionInputType.Inventory;
						}
					}
					else
					{
						action.InputType = Action.ActionInputType.Text;
					}
				}
				else
				{
					action.InputType = Action.ActionInputType.ObjectOrCharacter;
				}
			}
			else
			{
				action.InputType = Action.ActionInputType.Character;
			}
		}
		else
		{
			action.InputType = Action.ActionInputType.None;
		}
	}

	private void c68a54b096879bec8c3cab2e8e07786ea(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		if (((ToolStripItem)val).Tag == null)
		{
			__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
		}
		else
		{
			if (((ToolStripItem)val).Tag is QuickMenuItem)
			{
				cda013117bea2e25bc784a82617db97c6();
				QuickMenuItem quickMenuItem = ((ToolStripItem)val).Tag as QuickMenuItem;
				IEnumerator enumerator = quickMenuItem.Actions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Action action = (Action)enumerator.Current;
						if (quickMenuItem.bOverwrite)
						{
							ArrayList arrayList = c9ace99d5d5238fce319298fe34c80436();
							for (int i = 0; i < arrayList.Count; i++)
							{
								if (!(action.name == ((Action)arrayList[i]).name))
								{
									__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
									continue;
								}
								arrayList.RemoveAt(i);
								RefreshActions();
								break;
							}
						}
						if (!c2435eee62d338cc2af28737dd8de3be9(c966c316b5de02c6ef56a4713e8bdaeea, action.name))
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9877) + action.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9946));
							continue;
						}
						Clipboard.SetDataObject((object)new DataObject(ActionFormat.Name, (object)action));
						IDataObject dataObject = Clipboard.GetDataObject();
						if (!(dataObject.GetData(ActionFormat.Name) is Action action2))
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							continue;
						}
						for (int j = 0; j < action2.PassCommands.Count; j++)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							Command command = action2.PassCommands[j] as Command;
							Condition condition = action2.PassCommands[j] as Condition;
							if (command == null)
							{
								__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							}
							else
							{
								c30e5a792e85b329210d85e8811e8cff8(ref command);
							}
							if (condition != null)
							{
								c981fba2a54bb4c86a99159b7cf6ff67f(ref condition);
							}
						}
						for (int k = 0; k < action2.FailCommands.Count; k++)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							Command command2 = action2.FailCommands[k] as Command;
							Condition condition2 = action2.FailCommands[k] as Condition;
							if (command2 != null)
							{
								c30e5a792e85b329210d85e8811e8cff8(ref command2);
							}
							if (condition2 == null)
							{
								__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							}
							else
							{
								c981fba2a54bb4c86a99159b7cf6ff67f(ref condition2);
							}
						}
						for (int l = 0; l < action2.Conditions.Count; l++)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							Condition condition3 = (Condition)action2.Conditions[l];
							c981fba2a54bb4c86a99159b7cf6ff67f(ref condition3);
						}
						c9ace99d5d5238fce319298fe34c80436().Add(action2);
						cb08e057efb6abeb46f9124049d0ce710(action2, -1, false);
						if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							continue;
						}
						GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
						if (objectByName == null)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
							continue;
						}
						string text = string.Empty;
						if (!quickMenuItem.bCarryable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bCarryable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bCarryable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9197);
						}
						if (!quickMenuItem.bContainer)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bContainer)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bContainer = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9290);
						}
						if (!quickMenuItem.bEnterable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bEnterable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bEnterable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9383);
						}
						if (!quickMenuItem.bLockable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bLockable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bLockable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9476);
						}
						if (!quickMenuItem.bOpenable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bOpenable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bOpenable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9567);
						}
						if (!quickMenuItem.bReadable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bReadable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bReadable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9658);
						}
						if (!quickMenuItem.bWearable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else if (objectByName.bWearable)
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							objectByName.bWearable = true;
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9749);
						}
						if (!(text != string.Empty))
						{
							__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
						}
						else
						{
							MessageBox.Show(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9840));
						}
					}
					return;
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			__ldtoken(ActionControl.c68a54b096879bec8c3cab2e8e07786ea(object, EventArgs));
		}
		cda013117bea2e25bc784a82617db97c6();
		cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, ((ToolStripItem)val).Text);
	}

	private void cbd21f246e244eb8156d8c5f6f4cb65ce(PageType P_0, string P_1)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Invalid comparison between Unknown and I4
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected Obj, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Invalid comparison between Unknown and I4
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Obj, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected Obj, but got Unknown
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdf: Invalid comparison between Unknown and I4
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected Obj, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected Obj, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected Obj, but got Unknown
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Expected Obj, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Invalid comparison between Unknown and I4
		//IL_0cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdb: Expected Obj, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Invalid comparison between Unknown and I4
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected Obj, but got Unknown
		//IL_0d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4a: Expected Obj, but got Unknown
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Expected Obj, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f8: Invalid comparison between Unknown and I4
		//IL_15d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15de: Unknown result type (might be due to invalid IL or missing references)
		//IL_1621: Unknown result type (might be due to invalid IL or missing references)
		//IL_1626: Unknown result type (might be due to invalid IL or missing references)
		//IL_1629: Invalid comparison between Unknown and I4
		//IL_1e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e15: Invalid comparison between Unknown and I4
		//IL_2293: Unknown result type (might be due to invalid IL or missing references)
		//IL_2298: Unknown result type (might be due to invalid IL or missing references)
		//IL_229b: Invalid comparison between Unknown and I4
		if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2027)))
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		else
		{
			GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9993));
			if ((int)((Form)getNameFrm).ShowDialog() != 1)
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
			}
			else if (c2435eee62d338cc2af28737dd8de3be9(c966c316b5de02c6ef56a4713e8bdaeea, ((Control)getNameFrm.txtEntry).Text))
			{
				Action action = c48d5625ef051338905ddc110c05a3e45();
				TreeNode val = c3ede567c56bcc31cebb9f8c7704be790();
				action.name = ((Control)getNameFrm.txtEntry).Text;
				val.Text = ((Control)getNameFrm.txtEntry).Text;
			}
			else
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10052));
			}
		}
		if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1935)))
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
			if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260)))
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1981)))
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2002)))
					{
						__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
						if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1956)))
						{
							__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2366)))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2283)))
								{
									__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
									if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314))
									{
										if (tvActionsConditions.SelectedNode.Tag is Command command)
										{
											Clipboard.SetDataObject((object)new DataObject(CommandFormat.Name, (object)command));
										}
									}
									else if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2339)))
									{
										__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054))
										{
											switch (P_0)
											{
											case PageType.objects:
											{
												GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
												if (objectByName == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													break;
												}
												Action obj = c48d5625ef051338905ddc110c05a3e45();
												objectByName.Actions.Remove(obj);
												break;
											}
											case PageType.player:
											{
												Action obj3 = c48d5625ef051338905ddc110c05a3e45();
												c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.Remove(obj3);
												break;
											}
											case PageType.characters:
											{
												Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
												if (characterByName == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													break;
												}
												Action obj4 = c48d5625ef051338905ddc110c05a3e45();
												characterByName.Actions.Remove(obj4);
												break;
											}
											case PageType.room:
											{
												Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
												if (roomByID == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													break;
												}
												Action obj2 = c48d5625ef051338905ddc110c05a3e45();
												roomByID.Actions.Remove(obj2);
												break;
											}
											case PageType.timers:
											{
												Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
												if (timerByName == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													break;
												}
												Action obj5 = c48d5625ef051338905ddc110c05a3e45();
												timerByName.Actions.Remove(obj5);
												break;
											}
											case PageType.quickcommand:
											{
												QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
												if (menuItemByName == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													break;
												}
												Action actionByName = menuItemByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
												if (actionByName == null)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
												}
												else
												{
													menuItemByName.Actions.Remove(actionByName);
												}
												break;
											}
											}
											tvActionsConditions.Nodes.Remove(c3ede567c56bcc31cebb9f8c7704be790());
										}
									}
									else
									{
										if (tvActionsConditions.SelectedNode.Tag is Condition || tvActionsConditions.SelectedNode.Tag is Action)
										{
											MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10815));
											return;
										}
										IDataObject dataObject = Clipboard.GetDataObject();
										if (!(dataObject.GetData(CommandFormat.Name) is Command command2))
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										}
										else
										{
											int num;
											if (tvActionsConditions.SelectedNode.Parent.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
											{
												__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
												num = 1;
											}
											else
											{
												num = ((tvActionsConditions.SelectedNode.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)) ? 1 : 0);
											}
											ArrayList arrayList = c7f49c36388f468bae9971fa86acff3b7((byte)num != 0);
											if (arrayList == null)
											{
												__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											}
											else
											{
												arrayList.Add(command2);
												c1a8da0d75dd7c4b1020266a0d387daf6(command2, c67f2c94c1591123712e95dd345bf1b6e());
											}
										}
									}
								}
								else
								{
									IDataObject dataObject2 = Clipboard.GetDataObject();
									if (!(dataObject2.GetData(ConditonFormat.Name) is Condition))
									{
										__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
									}
									else
									{
										c976b838f4ac677954c6de4b09b7529ab();
									}
								}
							}
							else
							{
								Condition condition2 = ce934006d23f9c541701af4a7e1dab46f();
								if (condition2 != null)
								{
									Clipboard.SetDataObject((object)new DataObject(ConditonFormat.Name, (object)condition2));
								}
							}
						}
						else
						{
							IDataObject dataObject3 = Clipboard.GetDataObject();
							if (!(dataObject3.GetData(ActionFormat.Name) is Action action2))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							}
							else if (c2435eee62d338cc2af28737dd8de3be9(P_0, action2.name))
							{
								c9ace99d5d5238fce319298fe34c80436().Add(action2);
								cb08e057efb6abeb46f9124049d0ce710(action2, -1, true);
							}
							else if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10640) + action2.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10705), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10786), (MessageBoxButtons)4) != 6)
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							}
							else
							{
								GetNameFrm getNameFrm2 = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10216));
								if ((int)((Form)getNameFrm2).ShowDialog() != 1)
								{
									__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								}
								else if (c2435eee62d338cc2af28737dd8de3be9(P_0, ((Control)getNameFrm2.txtEntry).Text))
								{
									action2.name = ((Control)getNameFrm2.txtEntry).Text;
									c9ace99d5d5238fce319298fe34c80436().Add(action2);
									cb08e057efb6abeb46f9124049d0ce710(action2, -1, true);
								}
								else
								{
									MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10267));
								}
							}
						}
					}
					else
					{
						tvActionsConditions.CollapseAll();
					}
				}
				else
				{
					tvActionsConditions.ExpandAll();
				}
			}
			else
			{
				Action action3 = c48d5625ef051338905ddc110c05a3e45();
				if (action3 == null)
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				}
				else
				{
					Clipboard.SetDataObject((object)new DataObject(ActionFormat.Name, (object)action3));
				}
			}
		}
		else
		{
			Action action4 = null;
			if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.timers)
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				if (c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac).TType != Timer.TimerType.TT_RUNALWAYS)
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					AddTimerActionsFrm addTimerActionsFrm = new AddTimerActionsFrm(c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Length);
					if ((int)((Form)addTimerActionsFrm).ShowDialog() != 1)
					{
						__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					}
					else
					{
						IEnumerator enumerator = addTimerActionsFrm.lbTimerActions.SelectedItems.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								string name = (string)enumerator.Current;
								action4 = new Action();
								action4.name = name;
								c9ace99d5d5238fce319298fe34c80436().Add(action4);
								TreeNode val2 = new TreeNode(action4.name, 0, 0);
								val2.Tag = action4;
								val2.ForeColor = Color.DarkBlue;
								tvActionsConditions.Nodes.Add(val2);
								TreeNode val3 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395), 5, 5);
								val2.Nodes.Add(val3);
								val3.ForeColor = Color.Gray;
								TreeNode val4 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434), 4, 4);
								val2.Nodes.Add(val4);
								val4.ForeColor = Color.Gray;
								tvActionsConditions.SelectedNode = val2;
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							}
							else
							{
								disposable.Dispose();
							}
						}
					}
				}
				else
				{
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10346));
				}
			}
			else
			{
				GetNameFrm getNameFrm3 = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10216));
				if ((int)((Form)getNameFrm3).ShowDialog() != 1)
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					return;
				}
				if (!c2435eee62d338cc2af28737dd8de3be9(P_0, ((Control)getNameFrm3.txtEntry).Text))
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10267));
				}
				else
				{
					action4 = new Action();
					action4.name = ((Control)getNameFrm3.txtEntry).Text;
					c9ace99d5d5238fce319298fe34c80436().Add(action4);
					TreeNode val5 = new TreeNode(action4.name, 0, 0);
					val5.Tag = action4;
					val5.ForeColor = Color.DarkBlue;
					tvActionsConditions.Nodes.Add(val5);
					TreeNode val6 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395), 5, 5);
					val5.Nodes.Add(val6);
					val6.ForeColor = Color.Gray;
					TreeNode val7 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434), 4, 4);
					val5.Nodes.Add(val7);
					val7.ForeColor = Color.Gray;
					tvActionsConditions.SelectedNode = val5;
				}
			}
		}
		ArrayList arrayList2;
		string text;
		Action action5;
		Command command3;
		if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108)))
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
			if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2081)))
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2141)))
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2186)))
					{
						__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
						if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231))
						{
							cd05c561cba1614916c4a1d8f8cdee891(null, null);
							return;
						}
						if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949)))
						{
							__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11155)))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11790)))
								{
									__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
									if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11823))
									{
										arrayList2 = null;
										text = "";
										if (P_0 == PageType.objects)
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											GameObject objectByName2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
											if (objectByName2.bWearable)
											{
												__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											}
											else
											{
												if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11909), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12099), (MessageBoxButtons)4) != 6)
												{
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
													return;
												}
												objectByName2.bWearable = true;
											}
											arrayList2 = objectByName2.Actions;
											text = objectByName2.name;
											if (c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12124)))
											{
												action5 = new Action();
												arrayList2.Add(action5);
												action5.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12124);
												action5.bActive = true;
												command3 = new Command();
												action5.PassCommands.Add(command3);
												command3.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12133);
												command3.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
												command3.CommandPart2 = text;
												command3.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
												command3 = new Command();
												command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
												command3.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12166);
												command3.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
												command3.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12193);
												action5.PassCommands.Add(command3);
												command3 = new Command();
												command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
												command3.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12220);
												command3.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
												command3.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12245);
												action5.PassCommands.Add(command3);
												command3 = new Command();
												command3.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
												command3.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
												if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects)
												{
													if (c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition != string.Empty)
													{
														command3.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12272) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
														goto IL_1878;
													}
													__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
												}
												command3.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12316) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
												goto IL_1878;
											}
											goto IL_19eb;
										}
										MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11846));
										return;
									}
									if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12856)))
									{
										__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13506)))
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											return;
										}
										if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										}
										else
										{
											GameObject objectByName3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
											if (objectByName3.bCarryable)
											{
												__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											}
											else
											{
												if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13525), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13719), (MessageBoxButtons)4) != 6)
												{
													return;
												}
												objectByName3.bCarryable = true;
											}
										}
										ArrayList arrayList3 = null;
										string text2 = "";
										switch (P_0)
										{
										case PageType.objects:
											arrayList3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
											text2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).name;
											break;
										case PageType.characters:
											arrayList3 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
											text2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Charname;
											break;
										}
										if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13746)))
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										}
										else
										{
											Action action6 = new Action();
											arrayList3.Add(action6);
											action6.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13746);
											action6.bActive = true;
											Command command4 = new Command();
											action6.PassCommands.Add(command4);
											command4.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13755);
											command4.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
											command4.CommandPart2 = text2;
											command4 = new Command();
											command4.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
											command4.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
											command4.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13780) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
											action6.PassCommands.Add(command4);
											command4 = new Command();
											command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
											command4.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13813);
											command4.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
											command4.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13836);
											action6.PassCommands.Add(command4);
											command4 = new Command();
											command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
											command4.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13859);
											command4.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
											command4.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13884);
											action6.PassCommands.Add(command4);
											cb08e057efb6abeb46f9124049d0ce710(action6, -1, true);
										}
										if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13911)))
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
											return;
										}
										Action action7 = new Action();
										arrayList3.Add(action7);
										action7.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13911);
										action7.bActive = false;
										Command command5 = new Command();
										action7.PassCommands.Add(command5);
										command5.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13920);
										command5.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
										command5.CommandPart2 = text2;
										command5.CommandPart3 = Room.CurrentRoomGuid.ToString();
										command5 = new Command();
										command5.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
										command5.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
										command5.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13939) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
										action7.PassCommands.Add(command5);
										command5 = new Command();
										command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
										command5.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13972);
										command5.CommandPart2 = text2;
										command5.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13995);
										action7.PassCommands.Add(command5);
										command5 = new Command();
										command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
										command5.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14018);
										command5.CommandPart2 = text2;
										command5.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14043);
										action7.PassCommands.Add(command5);
										cb08e057efb6abeb46f9124049d0ce710(action7, -1, true);
										return;
									}
									if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects)
									{
										GameObject objectByName4 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
										if (objectByName4.bLockable)
										{
											__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										}
										else
										{
											if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12879), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13069), (MessageBoxButtons)4) != 6)
											{
												__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
												return;
											}
											objectByName4.bLockable = true;
										}
									}
									ArrayList arrayList4 = null;
									string text3 = "";
									switch (P_0)
									{
									case PageType.objects:
										arrayList4 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
										text3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).name;
										break;
									case PageType.characters:
										arrayList4 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Actions;
										text3 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Charname;
										break;
									}
									if (c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13094)))
									{
										Action action8 = new Action();
										arrayList4.Add(action8);
										action8.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13094);
										action8.bActive = true;
										Command command6 = new Command();
										action8.PassCommands.Add(command6);
										command6.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13103);
										command6.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
										command6.CommandPart2 = text3;
										command6.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477);
										command6 = new Command();
										command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
										command6.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
										command6.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13140);
										action8.PassCommands.Add(command6);
										Condition condition3 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13171));
										action8.Conditions.Add(condition3);
										Check check = condition3.Checks[0] as Check;
										check.CondType = Condition.ConditionType.CT_Item_State_Check;
										check.ConditionStep2 = text3;
										check.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313);
										command6 = new Command();
										command6.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13204);
										command6.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13249);
										command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
										condition3.FailCommands.Add(command6);
										cb08e057efb6abeb46f9124049d0ce710(action8, -1, true);
									}
									if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13288)))
									{
										__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										return;
									}
									Action action9 = new Action();
									arrayList4.Add(action9);
									action9.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13288);
									action9.bActive = true;
									Command command7 = new Command();
									action9.PassCommands.Add(command7);
									command7.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13301);
									command7.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
									command7.CommandPart2 = text3;
									command7.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313);
									command7 = new Command();
									command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
									command7.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
									command7.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13342);
									action9.PassCommands.Add(command7);
									Condition condition4 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13377));
									action9.Conditions.Add(condition4);
									Check check2 = condition4.Checks[0] as Check;
									check2.CondType = Condition.ConditionType.CT_Item_State_Check;
									check2.ConditionStep2 = text3;
									check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477);
									command7 = new Command();
									command7.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13414);
									command7.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13463);
									command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
									condition4.FailCommands.Add(command7);
									cb08e057efb6abeb46f9124049d0ce710(action9, -1, true);
									return;
								}
								c301c7f73d6a27a3ce702fb0155a52a9a(null, null);
								return;
							}
							ArrayList arrayList5 = c9ace99d5d5238fce319298fe34c80436();
							string text4 = c1e2ad2c4b8f893c83053fbfc829e5cac;
							if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects)
							{
								GameObject objectByName5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
								if (objectByName5.bOpenable)
								{
									__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								}
								else
								{
									if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11176), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11366), (MessageBoxButtons)4) != 6)
									{
										__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
										return;
									}
									objectByName5.bOpenable = true;
								}
							}
							if (c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451)))
							{
								Action action10 = new Action();
								arrayList5.Add(action10);
								action10.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
								action10.bActive = true;
								Command command8 = new Command();
								action10.PassCommands.Add(command8);
								command8.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11391);
								command8.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
								command8.CommandPart2 = text4;
								command8.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
								command8 = new Command();
								command8.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
								command8.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
								command8.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11462);
								action10.PassCommands.Add(command8);
								Condition condition5 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11489));
								action10.Conditions.Add(condition5);
								Check check3 = condition5.Checks[0] as Check;
								check3.CondType = Condition.ConditionType.CT_Item_State_Check;
								check3.ConditionStep2 = text4;
								check3.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300);
								command8 = new Command();
								command8.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11518);
								command8.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11559);
								command8.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
								condition5.FailCommands.Add(command8);
								cb08e057efb6abeb46f9124049d0ce710(action10, -1, true);
							}
							if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11594)))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								return;
							}
							Action action11 = new Action();
							arrayList5.Add(action11);
							action11.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11594);
							action11.bActive = true;
							Command command9 = new Command();
							action11.PassCommands.Add(command9);
							command9.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11605);
							command9.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
							command9.CommandPart2 = text4;
							command9.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300);
							command9 = new Command();
							command9.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
							command9.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
							command9.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11642);
							action11.PassCommands.Add(command9);
							Condition condition6 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11673));
							action11.Conditions.Add(condition6);
							Check check4 = condition6.Checks[0] as Check;
							check4.CondType = Condition.ConditionType.CT_Item_State_Check;
							check4.ConditionStep2 = text4;
							check4.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
							command9 = new Command();
							command9.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11706);
							command9.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11453) + text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11751);
							command9.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
							condition6.FailCommands.Add(command9);
							cb08e057efb6abeb46f9124049d0ce710(action11, -1, true);
							return;
						}
						Action action12 = null;
						switch (P_0)
						{
						case PageType.characters:
						{
							Character characterByName2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
							if (characterByName2 == null)
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								break;
							}
							if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949)))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								break;
							}
							action12 = new Action();
							characterByName2.Actions.Add(action12);
							action12.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
							action12.bActive = true;
							Command command12 = new Command();
							action12.PassCommands.Add(command12);
							command12.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10964);
							command12.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
							command12.CommandPart2 = characterByName2.Charname;
							break;
						}
						case PageType.objects:
						{
							GameObject objectByName6 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
							if (objectByName6 != null)
							{
								if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949)))
								{
									__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
									break;
								}
								action12 = new Action();
								objectByName6.Actions.Add(action12);
								action12.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
								action12.bActive = true;
								Command command13 = new Command();
								action12.PassCommands.Add(command13);
								command13.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10999);
								command13.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
								command13.CommandPart2 = objectByName6.name;
							}
							break;
						}
						case PageType.player:
						{
							if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949)))
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
								break;
							}
							action12 = new Action();
							c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.Add(action12);
							action12.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
							action12.bActive = true;
							Command command11 = new Command();
							action12.PassCommands.Add(command11);
							command11.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034);
							command11.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
							break;
						}
						case PageType.room:
						{
							Room roomByID2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
							if (roomByID2 == null)
							{
								__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
							}
							else if (c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949)))
							{
								action12 = new Action();
								roomByID2.Actions.Add(action12);
								action12.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
								action12.bActive = true;
								Command command10 = new Command();
								action12.PassCommands.Add(command10);
								command10.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11087);
								command10.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
								command10.CommandPart2 = Room.CurrentRoomGuid.ToString();
								command10 = new Command();
								action12.PassCommands.Add(command10);
								command10.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11122);
								command10.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
								command10.CommandPart2 = Room.CurrentRoomGuid.ToString();
							}
							break;
						}
						}
						cb08e057efb6abeb46f9124049d0ce710(action12, -1, true);
						return;
					}
					c998840448a951a77b88579668615a934(null, null);
					return;
				}
				cd7e036f3d88c3afef58cf1d8edf2c3d9(null, null);
				return;
			}
			GetNameFrm getNameFrm4 = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10892));
			if ((int)((Form)getNameFrm4).ShowDialog() != 1)
			{
				return;
			}
			Condition condition7 = null;
			TreeNode val8 = null;
			if (tvActionsConditions.SelectedNode.Level != 0)
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				ArrayList arrayList6 = c7f49c36388f468bae9971fa86acff3b7(c70fc5e11ebdc77a9c3dfb7b8ebc35173());
				condition7 = new Condition(((Control)getNameFrm4.txtEntry).Text);
				((Check)condition7.Checks[0]).CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				arrayList6.Add(condition7);
				val8 = cd1e3095bc2b5a0be843f7e7e55131995();
			}
			else
			{
				val8 = c3ede567c56bcc31cebb9f8c7704be790();
				Action action13 = c48d5625ef051338905ddc110c05a3e45();
				if (action13 == null)
				{
					__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				}
				else
				{
					condition7 = new Condition(((Control)getNameFrm4.txtEntry).Text);
					((Check)condition7.Checks[0]).CondType = Condition.ConditionType.CT_Item_Held_By_Player;
					action13.Conditions.Add(condition7);
				}
			}
			TreeNode val9 = new TreeNode(((Control)getNameFrm4.txtEntry).Text, 2, 2);
			val9.Tag = condition7;
			val9.ForeColor = Color.DarkRed;
			if (!c521610853650504f145dd1cf178b1d8f())
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				val8.Nodes.Add(val9);
			}
			else
			{
				val8.Nodes.Insert(val8.Nodes.Count - 2, val9);
			}
			TreeNode val10 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395), 5, 5);
			val9.Nodes.Add(val10);
			val10.ForeColor = Color.Gray;
			TreeNode val11 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434), 4, 4);
			val9.Nodes.Add(val11);
			val11.ForeColor = Color.Gray;
			tvActionsConditions.SelectedNode = val9;
			return;
		}
		if (tvActionsConditions.SelectedNode.Tag == null)
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		else if (!(tvActionsConditions.SelectedNode.Tag.GetType() == typeof(Condition)))
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		else if (tvActionsConditions.SelectedNode.Level > 1)
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
			TreeNode selectedNode = tvActionsConditions.SelectedNode;
			object tag = tvActionsConditions.SelectedNode.Tag;
			if (c09339147ff81a8d975d8fcf141910684 && tvActionsConditions.SelectedNode.Tag is Condition && tvActionsConditions.SelectedNode.Level != 2)
			{
				tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
			}
			ArrayList arrayList7 = c7f49c36388f468bae9971fa86acff3b7(c70fc5e11ebdc77a9c3dfb7b8ebc35173());
			if (arrayList7 == null)
			{
				__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
				return;
			}
			tvActionsConditions.SelectedNode = selectedNode;
			arrayList7.Remove(tag);
			cd1e3095bc2b5a0be843f7e7e55131995().Nodes.Remove(tvActionsConditions.SelectedNode);
		}
		else
		{
			c48d5625ef051338905ddc110c05a3e45().Conditions.Remove(ce934006d23f9c541701af4a7e1dab46f());
			c3ede567c56bcc31cebb9f8c7704be790().Nodes.Remove(tvActionsConditions.SelectedNode);
		}
		return;
		IL_19c7:
		command3.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		Condition condition8;
		condition8.FailCommands.Add(command3);
		cb08e057efb6abeb46f9124049d0ce710(action5, -1, true);
		goto IL_19eb;
		IL_1c23:
		Action action14;
		Command command14;
		action14.PassCommands.Add(command14);
		Condition condition9 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12727));
		action14.Conditions.Add(condition9);
		Check check5 = condition9.Checks[0] as Check;
		check5.CondType = Condition.ConditionType.CT_Item_State_Check;
		check5.ConditionStep2 = text;
		check5.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command14 = new Command();
		command14.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12782);
		if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition != string.Empty)
			{
				command14.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12815) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
				goto IL_1d80;
			}
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		command14.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12815) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
		goto IL_1d80;
		IL_1878:
		action5.PassCommands.Add(command3);
		condition8 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12365));
		action5.Conditions.Add(condition8);
		Check check6 = condition8.Checks[0] as Check;
		check6.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		check6.ConditionStep2 = text;
		check6.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		command3 = new Command();
		command3.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12416);
		if (c966c316b5de02c6ef56a4713e8bdaeea == PageType.objects)
		{
			if (c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition != string.Empty)
			{
				command3.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12449) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
				goto IL_19c7;
			}
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		command3.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12476) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12511);
		goto IL_19c7;
		IL_1d80:
		command14.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition9.FailCommands.Add(command14);
		cb08e057efb6abeb46f9124049d0ce710(action14, -1, true);
		return;
		IL_19eb:
		if (!c2435eee62d338cc2af28737dd8de3be9(P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12526)))
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
			return;
		}
		action14 = new Action();
		arrayList2.Add(action14);
		action14.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12526);
		action14.bActive = false;
		command14 = new Command();
		action14.PassCommands.Add(command14);
		command14.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12539);
		command14.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
		command14.CommandPart2 = text;
		command14.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		command14 = new Command();
		command14.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command14.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12578);
		command14.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
		command14.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12601);
		action14.PassCommands.Add(command14);
		command14 = new Command();
		command14.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command14.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624);
		command14.CommandPart2 = c1e2ad2c4b8f893c83053fbfc829e5cac;
		command14.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12653);
		action14.PassCommands.Add(command14);
		command14 = new Command();
		command14.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command14.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		if (c966c316b5de02c6ef56a4713e8bdaeea != PageType.objects)
		{
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition != string.Empty)
			{
				command14.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12684) + c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
				goto IL_1c23;
			}
			__ldtoken(ActionControl.cbd21f246e244eb8156d8c5f6f4cb65ce(PageType, string));
		}
		command14.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12684) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
		goto IL_1c23;
	}

	private void c30e5a792e85b329210d85e8811e8cff8(ref Command P_0)
	{
		string text = string.Empty;
		if (P_0.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY)
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
		}
		else if (P_0.cmdtype != Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			if (P_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY || P_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
			{
				text = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac)).Name;
			}
			else if (P_0.cmdtype != Command.CommandType.CT_SETVARIABLE && P_0.cmdtype != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			}
			else
			{
				text = ce7ea9b14dc4bab43e4cb717b69560901();
			}
			goto IL_00a8;
		}
		text = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).name;
		goto IL_00a8;
		IL_00a8:
		for (int num = P_0.CommandPart2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)); num > -1; num = P_0.CommandPart2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandPart2 = P_0.CommandPart2.Remove(num, 6);
			if (!(text != string.Empty))
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
				P_0.CommandPart2 = P_0.CommandPart2.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
			else
			{
				P_0.CommandPart2 = P_0.CommandPart2.Insert(num, text);
			}
		}
		for (int num = P_0.CommandPart2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)); num > -1; num = P_0.CommandPart2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandPart2 = P_0.CommandPart2.Remove(num, 6);
			if (!(text != string.Empty))
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
				P_0.CommandPart2 = P_0.CommandPart2.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
			else
			{
				P_0.CommandPart2 = P_0.CommandPart2.Insert(num, text);
			}
		}
		for (int num = P_0.CommandPart3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)); num > -1; num = P_0.CommandPart3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)))
		{
			P_0.CommandPart3 = P_0.CommandPart3.Remove(num, 6);
			if (!(text != string.Empty))
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
				P_0.CommandPart3 = P_0.CommandPart3.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
			else
			{
				P_0.CommandPart3 = P_0.CommandPart3.Insert(num, text);
			}
		}
		for (int num = P_0.CommandPart3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)); num > -1; num = P_0.CommandPart3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandPart3 = P_0.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				P_0.CommandPart3 = P_0.CommandPart3.Insert(num, text);
			}
			else
			{
				P_0.CommandPart3 = P_0.CommandPart3.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
		}
		for (int num = P_0.CommandPart4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)); num > -1; num = P_0.CommandPart4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandPart4 = P_0.CommandPart4.Remove(num, 6);
			if (!(text != string.Empty))
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
				P_0.CommandPart4 = P_0.CommandPart4.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
			else
			{
				P_0.CommandPart4 = P_0.CommandPart4.Insert(num, text);
			}
		}
		for (int num = P_0.CommandPart4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)); num > -1; num = P_0.CommandPart4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)))
		{
			P_0.CommandPart4 = P_0.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				P_0.CommandPart4 = P_0.CommandPart4.Insert(num, text);
			}
			else
			{
				P_0.CommandPart4 = P_0.CommandPart4.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
		}
		for (int num = P_0.CommandText.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)); num > -1; num = P_0.CommandText.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandText = P_0.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				P_0.CommandText = P_0.CommandText.Insert(num, text);
			}
			else
			{
				P_0.CommandText = P_0.CommandText.Insert(num, c36d0b2f2aa5dddb7fc9d877fae409a81());
			}
		}
		for (int num = P_0.CommandText.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)); num > -1; num = P_0.CommandText.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083)))
		{
			__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
			P_0.CommandText = P_0.CommandText.Remove(num, 6);
			if (!(text != string.Empty))
			{
				__ldtoken(ActionControl.c30e5a792e85b329210d85e8811e8cff8(ref Command));
				P_0.CommandText = P_0.CommandText.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
			}
			else
			{
				P_0.CommandText = P_0.CommandText.Insert(num, text);
			}
		}
	}

	private string c36d0b2f2aa5dddb7fc9d877fae409a81()
	{
		string result = string.Empty;
		switch (c966c316b5de02c6ef56a4713e8bdaeea)
		{
		case PageType.characters:
			result = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).ToString();
			break;
		case PageType.objects:
			result = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).GetDisplayStringNameOnly();
			break;
		case PageType.room:
			result = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac)).Name;
			break;
		}
		return result;
	}

	private string ce7ea9b14dc4bab43e4cb717b69560901()
	{
		string result = string.Empty;
		switch (c966c316b5de02c6ef56a4713e8bdaeea)
		{
		case PageType.characters:
			result = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac).Charname;
			break;
		case PageType.objects:
			result = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).name;
			break;
		case PageType.room:
			result = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac)).Name;
			break;
		}
		return result;
	}

	private void c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition P_0)
	{
		for (int i = 0; i < P_0.Checks.Count; i++)
		{
			__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			Check check = (Check)P_0.Checks[i];
			string text = string.Empty;
			if (check.CondType != Condition.ConditionType.CT_Item_CustomPropertyCheck)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
				if (check.CondType != Condition.ConditionType.CT_Room_CustomPropertyCheck)
				{
					__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
				}
				else
				{
					text = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac)).Name;
				}
			}
			else
			{
				text = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac).name;
			}
			int num = check.ConditionStep2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070));
			if (num <= -1)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			}
			else
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
			}
			num = check.ConditionStep2.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083));
			if (num <= -1)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			}
			else
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (!(text != string.Empty))
				{
					__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
					check.ConditionStep2 = check.ConditionStep2.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070));
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (!(text != string.Empty))
				{
					__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
					check.ConditionStep3 = check.ConditionStep3.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083));
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (!(text != string.Empty))
				{
					__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
					check.ConditionStep3 = check.ConditionStep3.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14070));
			if (num <= -1)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			}
			else
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14083));
			if (num > -1)
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (!(text != string.Empty))
				{
					__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
					check.ConditionStep4 = check.ConditionStep4.Insert(num, ce7ea9b14dc4bab43e4cb717b69560901());
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
			}
		}
		for (int j = 0; j < P_0.PassCommands.Count; j++)
		{
			__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			Command command = P_0.PassCommands[j] as Command;
			Condition condition = P_0.PassCommands[j] as Condition;
			if (command == null)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			}
			else
			{
				c30e5a792e85b329210d85e8811e8cff8(ref command);
			}
			if (condition != null)
			{
				c981fba2a54bb4c86a99159b7cf6ff67f(ref condition);
			}
		}
		for (int k = 0; k < P_0.FailCommands.Count; k++)
		{
			__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			Command command2 = P_0.FailCommands[k] as Command;
			Condition condition2 = P_0.FailCommands[k] as Condition;
			if (command2 != null)
			{
				c30e5a792e85b329210d85e8811e8cff8(ref command2);
			}
			if (condition2 == null)
			{
				__ldtoken(ActionControl.c981fba2a54bb4c86a99159b7cf6ff67f(ref Condition));
			}
			else
			{
				c981fba2a54bb4c86a99159b7cf6ff67f(ref condition2);
			}
		}
	}

	private bool c2435eee62d338cc2af28737dd8de3be9(PageType P_0, string P_1)
	{
		bool result = true;
		switch (P_0)
		{
		case PageType.objects:
		{
			GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (objectByName != null)
			{
				for (int l = 0; l < objectByName.Actions.Count; l++)
				{
					__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
					if (string.Compare(P_1, ((Action)objectByName.Actions[l]).name) == 0)
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			break;
		}
		case PageType.player:
		{
			for (int k = 0; k < c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.Count; k++)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				if (string.Compare(P_1, ((Action)c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions[k]).name) != 0)
				{
					__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
					continue;
				}
				result = false;
				break;
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (characterByName == null)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				result = false;
				break;
			}
			for (int j = 0; j < characterByName.Actions.Count; j++)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				if (string.Compare(P_1, ((Action)characterByName.Actions[j]).name) != 0)
				{
					__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
					continue;
				}
				result = false;
				break;
			}
			break;
		}
		case PageType.room:
		{
			Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
			if (roomByID == null)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				result = false;
				break;
			}
			for (int m = 0; m < roomByID.Actions.Count; m++)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				if (string.Compare(P_1, ((Action)roomByID.Actions[m]).name) != 0)
				{
					__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
					continue;
				}
				result = false;
				break;
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (timerByName == null)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				result = false;
				break;
			}
			for (int i = 0; i < timerByName.Actions.Count; i++)
			{
				__ldtoken(ActionControl.c2435eee62d338cc2af28737dd8de3be9(PageType, string));
				if (string.Compare(P_1, ((Action)timerByName.Actions[i]).name) == 0)
				{
					result = false;
					break;
				}
			}
			break;
		}
		}
		return result;
	}

	private void c998840448a951a77b88579668615a934(object P_0, EventArgs P_1)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		if (tvActionsConditions.SelectedNode.Tag is Condition)
		{
			tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Nodes[0];
		}
		ArrayList arrayList = c7f49c36388f468bae9971fa86acff3b7(false);
		Command command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		arrayList.Add(command);
		TreeNode val = cb7707f4ecb6fe12daf4e04af4cc32f1e(false);
		TreeNode val2 = new TreeNode(Command.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), 3, 3);
		val2.Tag = command;
		val2.ForeColor = Color.DarkGoldenrod;
		val.Nodes.Add(val2);
		tvActionsConditions.SelectedNode = val2;
		cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, Command.CommandType.CT_DISPLAYTEXT);
		c2c95007c30beadab9f3e3e2216adc4a7(null, null);
	}

	private TreeNode cb7707f4ecb6fe12daf4e04af4cc32f1e(bool P_0)
	{
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected Obj, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		TreeNode val = null;
		if (!c521610853650504f145dd1cf178b1d8f())
		{
			__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
			if (tvActionsConditions.SelectedNode.Level < 1)
			{
				__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
			}
			else if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
				val = tvActionsConditions.SelectedNode;
			}
			else
			{
				TreeNode val2 = tvActionsConditions.SelectedNode;
				while (!(val2.Tag is Condition))
				{
					__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
					val2 = val2.Parent;
				}
				val = val2;
			}
			if (P_0)
			{
				IEnumerator enumerator = val.Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						TreeNode val3 = (TreeNode)enumerator.Current;
						if (!(val3.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)))
						{
							__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
							continue;
						}
						val = val3;
						break;
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			else
			{
				IEnumerator enumerator2 = val.Nodes.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
						TreeNode val4 = (TreeNode)enumerator2.Current;
						if (!(val4.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434)))
						{
							__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
							continue;
						}
						val = val4;
						break;
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable2))
					{
						__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
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
			val = tvActionsConditions.SelectedNode;
			while (val.Parent != null)
			{
				__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
				val = val.Parent;
			}
			if (!P_0)
			{
				__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
				{
					IEnumerator enumerator3 = val.Nodes.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
							TreeNode val5 = (TreeNode)enumerator3.Current;
							if (val5.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434))
							{
								val = val5;
								break;
							}
						}
					}
					finally
					{
						IDisposable disposable4 = enumerator3 as IDisposable;
						if (disposable4 != null)
						{
							disposable4.Dispose();
						}
					}
				}
			}
			else
			{
				IEnumerator enumerator4 = val.Nodes.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
						TreeNode val6 = (TreeNode)enumerator4.Current;
						if (!(val6.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)))
						{
							__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
							continue;
						}
						val = val6;
						break;
					}
				}
				finally
				{
					if (!(enumerator4 is IDisposable disposable3))
					{
						__ldtoken(ActionControl.cb7707f4ecb6fe12daf4e04af4cc32f1e(bool));
					}
					else
					{
						disposable3.Dispose();
					}
				}
			}
		}
		return val;
	}

	private void cd05c561cba1614916c4a1d8f8cdee891(object P_0, EventArgs P_1)
	{
		ArrayList arrayList = c7f49c36388f468bae9971fa86acff3b7(tvActionsConditions.SelectedNode.Parent.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395));
		arrayList.Remove(tvActionsConditions.SelectedNode.Tag);
		tvActionsConditions.SelectedNode.Parent.Nodes.Remove(tvActionsConditions.SelectedNode);
		c30e90c805842ce4651af61f353033dce(null, null);
	}

	private void cd7e036f3d88c3afef58cf1d8edf2c3d9(object P_0, EventArgs P_1)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		if (!(tvActionsConditions.SelectedNode.Tag is Condition))
		{
			__ldtoken(ActionControl.cd7e036f3d88c3afef58cf1d8edf2c3d9(object, EventArgs));
		}
		else
		{
			tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Nodes[0];
		}
		ArrayList arrayList = c7f49c36388f468bae9971fa86acff3b7(true);
		Command command = null;
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		arrayList.Add(command);
		TreeNode val = cb7707f4ecb6fe12daf4e04af4cc32f1e(true);
		TreeNode val2 = new TreeNode(Command.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), 3, 3);
		val2.Tag = command;
		val2.ForeColor = Color.DarkGoldenrod;
		val.Nodes.Add(val2);
		tvActionsConditions.SelectedNode = val2;
		cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, Command.CommandType.CT_DISPLAYTEXT);
		c2c95007c30beadab9f3e3e2216adc4a7(null, null);
	}

	private void ca407d0f5d0cd104f6f38637c29c4bb1a(Condition P_0, TreeNode P_1, int P_2)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		TreeNode val = new TreeNode(P_0.conditionname, 2, 2);
		val.Tag = P_0;
		val.ForeColor = Color.DarkRed;
		TreeNode val2 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395), 5, 5);
		val.Nodes.Add(val2);
		val2.ForeColor = Color.Gray;
		TreeNode val3 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434), 4, 4);
		val.Nodes.Add(val3);
		val3.ForeColor = Color.Gray;
		for (int i = 0; i < P_0.PassCommands.Count; i++)
		{
			__ldtoken(ActionControl.ca407d0f5d0cd104f6f38637c29c4bb1a(Condition, TreeNode, int));
			if (!(P_0.PassCommands[i] is Command command))
			{
				__ldtoken(ActionControl.ca407d0f5d0cd104f6f38637c29c4bb1a(Condition, TreeNode, int));
				if (!(P_0.PassCommands[i] is Condition condition))
				{
					__ldtoken(ActionControl.ca407d0f5d0cd104f6f38637c29c4bb1a(Condition, TreeNode, int));
				}
				else
				{
					ca407d0f5d0cd104f6f38637c29c4bb1a(condition, val2, -1);
				}
			}
			else
			{
				c1a8da0d75dd7c4b1020266a0d387daf6(command, val2);
			}
		}
		for (int j = 0; j < P_0.FailCommands.Count; j++)
		{
			__ldtoken(ActionControl.ca407d0f5d0cd104f6f38637c29c4bb1a(Condition, TreeNode, int));
			if (!(P_0.FailCommands[j] is Command command2))
			{
				__ldtoken(ActionControl.ca407d0f5d0cd104f6f38637c29c4bb1a(Condition, TreeNode, int));
				if (P_0.FailCommands[j] is Condition condition2)
				{
					ca407d0f5d0cd104f6f38637c29c4bb1a(condition2, val3, -1);
				}
			}
			else
			{
				c1a8da0d75dd7c4b1020266a0d387daf6(command2, val3);
			}
		}
		if (P_2 == -1)
		{
			P_1.Nodes.Add(val);
		}
		else
		{
			P_1.Nodes.Insert(P_2, val);
		}
		tvActionsConditions.SelectedNode = val;
	}

	private void c1a8da0d75dd7c4b1020266a0d387daf6(Command P_0, TreeNode P_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		TreeNode val = new TreeNode(cee63400536b49afc634b51f621e13ca3(P_0), 3, 3);
		val.Tag = P_0;
		val.ForeColor = Color.DarkGoldenrod;
		P_1.Nodes.Add(val);
	}

	private void cb08e057efb6abeb46f9124049d0ce710(Action P_0, int P_1, bool P_2)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		if (P_0 == null)
		{
			return;
		}
		__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
		TreeNode val = new TreeNode(P_0.name, 0, 0);
		val.Tag = P_0;
		val.ForeColor = Color.DarkBlue;
		for (int i = 0; i < P_0.Conditions.Count; i++)
		{
			__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
			ca407d0f5d0cd104f6f38637c29c4bb1a((Condition)P_0.Conditions[i], val, -1);
		}
		TreeNode val2 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395), 5, 5);
		val.Nodes.Add(val2);
		val2.ForeColor = Color.Gray;
		TreeNode val3 = new TreeNode(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434), 4, 4);
		val.Nodes.Add(val3);
		val3.ForeColor = Color.Gray;
		for (int j = 0; j < P_0.PassCommands.Count; j++)
		{
			__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
			Command command = P_0.PassCommands[j] as Command;
			Condition condition = P_0.PassCommands[j] as Condition;
			if (command == null)
			{
				__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
				if (condition == null)
				{
					__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
				}
				else
				{
					ca407d0f5d0cd104f6f38637c29c4bb1a(condition, val2, -1);
				}
			}
			else
			{
				c1a8da0d75dd7c4b1020266a0d387daf6(command, val2);
			}
		}
		for (int k = 0; k < P_0.FailCommands.Count; k++)
		{
			__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
			Command command2 = P_0.FailCommands[k] as Command;
			Condition condition2 = P_0.FailCommands[k] as Condition;
			if (command2 == null)
			{
				__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
				if (condition2 == null)
				{
					__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
				}
				else
				{
					ca407d0f5d0cd104f6f38637c29c4bb1a(condition2, val3, -1);
				}
			}
			else
			{
				c1a8da0d75dd7c4b1020266a0d387daf6(command2, val3);
			}
		}
		if (P_1 != -1)
		{
			__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
			tvActionsConditions.Nodes.Insert(P_1, val);
		}
		else
		{
			tvActionsConditions.Nodes.Add(val);
		}
		if (!P_2)
		{
			__ldtoken(ActionControl.cb08e057efb6abeb46f9124049d0ce710(Action, int, bool));
		}
		else
		{
			tvActionsConditions.SelectedNode = val;
		}
	}

	public void RefreshActions()
	{
		((Control)tvActionsConditions).Enabled = true;
		tvActionsConditions.Nodes.Clear();
		ArrayList arrayList = c9ace99d5d5238fce319298fe34c80436();
		try
		{
			tvActionsConditions.BeginUpdate();
			for (int i = 0; i < arrayList.Count; i++)
			{
				Action action = (Action)arrayList[i];
				cb08e057efb6abeb46f9124049d0ce710(action, -1, false);
			}
		}
		finally
		{
			tvActionsConditions.EndUpdate();
		}
		tvActionsConditions.ExpandAll();
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c301c7f73d6a27a3ce702fb0155a52a9a(object P_0, EventArgs P_1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		AddActionWizard addActionWizard = new AddActionWizard();
		((Form)addActionWizard).ShowDialog();
	}

	private void cac1cea50638f4836e000e8aa95301a1b(object P_0, EventArgs P_1)
	{
		if (!(tvActionsConditions.SelectedNode.Tag is Condition condition))
		{
			__ldtoken(ActionControl.cac1cea50638f4836e000e8aa95301a1b(object, EventArgs));
			return;
		}
		condition.conditionname = ((Control)cca635a57d99b03a02717c239805e2524).Text;
		tvActionsConditions.SelectedNode.Text = ((Control)cca635a57d99b03a02717c239805e2524).Text;
	}

	private void c3af9bf9be84c0a38c1e2fbcebb2f738c(object P_0, EventArgs P_1)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ce934006d23f9c541701af4a7e1dab46f();
		if (condition == null)
		{
			__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
			return;
		}
		bool flag = false;
		IEnumerator enumerator = condition.Checks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
				Check check = (Check)enumerator.Current;
				if (check.CondType == Condition.ConditionType.CT_Loop_While)
				{
					__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
				}
				else if (check.CondType == Condition.ConditionType.CT_Loop_Rooms)
				{
					__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
				}
				else if (check.CondType == Condition.ConditionType.CT_Loop_Characters)
				{
					__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
				}
				else if (check.CondType != Condition.ConditionType.CT_Loop_Items)
				{
					__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
					continue;
				}
				flag = true;
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14096));
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (flag)
		{
			__ldtoken(ActionControl.c3af9bf9be84c0a38c1e2fbcebb2f738c(object, EventArgs));
			return;
		}
		Check check2 = new Check();
		check2.CkType = CheckType.And;
		int selectedIndex = ce934006d23f9c541701af4a7e1dab46f().Checks.Add(check2);
		cf321bad81366defd5fe03ced8501524f(ce934006d23f9c541701af4a7e1dab46f());
		((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex = selectedIndex;
	}

	private void cb795342ba98121b7f10c0795fcf29ec8(object P_0, EventArgs P_1)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ce934006d23f9c541701af4a7e1dab46f();
		if (condition == null)
		{
			__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
			return;
		}
		bool flag = false;
		IEnumerator enumerator = condition.Checks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
				Check check = (Check)enumerator.Current;
				if (check.CondType == Condition.ConditionType.CT_Loop_While)
				{
					__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
				}
				else if (check.CondType == Condition.ConditionType.CT_Loop_Rooms)
				{
					__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
				}
				else if (check.CondType != Condition.ConditionType.CT_Loop_Characters && check.CondType != Condition.ConditionType.CT_Loop_Items)
				{
					__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
					continue;
				}
				flag = true;
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14096));
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (flag)
		{
			__ldtoken(ActionControl.cb795342ba98121b7f10c0795fcf29ec8(object, EventArgs));
			return;
		}
		Check check2 = new Check();
		check2.CkType = CheckType.Or;
		int selectedIndex = ce934006d23f9c541701af4a7e1dab46f().Checks.Add(check2);
		cf321bad81366defd5fe03ced8501524f(ce934006d23f9c541701af4a7e1dab46f());
		((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex = selectedIndex;
	}

	private void c4d89de75bfe6d52cb05f3fdc6ef40c09(object P_0, EventArgs P_1)
	{
		if (((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex <= -1)
		{
			return;
		}
		Condition condition = ce934006d23f9c541701af4a7e1dab46f();
		if (!(condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex] is Check check))
		{
			return;
		}
		cbConditionStep1.SelectedItem = Condition.GetConditionItem(cbConditionStep1, check.CondType);
		try
		{
			Guid guid = new Guid(check.ConditionStep2);
			IEnumerator enumerator = c428ebf94dee726b1e31b460540bbbc1f.Items.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
					RoomComboItem roomComboItem = (RoomComboItem)enumerator.Current;
					if (!(roomComboItem.UniqueID == guid))
					{
						__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
						continue;
					}
					c428ebf94dee726b1e31b460540bbbc1f.SelectedItem = roomComboItem;
					break;
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		catch
		{
			((Control)c428ebf94dee726b1e31b460540bbbc1f).Text = check.ConditionStep2;
		}
		try
		{
			Guid guid2 = new Guid(check.ConditionStep3);
			IEnumerator enumerator2 = cb14d51ac8530fe4463993959ce4a6d75.Items.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
					RoomComboItem roomComboItem2 = (RoomComboItem)enumerator2.Current;
					if (!(roomComboItem2.UniqueID == guid2))
					{
						__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
						continue;
					}
					cb14d51ac8530fe4463993959ce4a6d75.SelectedItem = roomComboItem2;
					break;
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(ActionControl.c4d89de75bfe6d52cb05f3fdc6ef40c09(object, EventArgs));
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		catch
		{
			((Control)cb14d51ac8530fe4463993959ce4a6d75).Text = check.ConditionStep3;
		}
		((Control)ce461a44e2020b57573abdc365294fa10).Text = check.ConditionStep4;
		((Control)cb110e655831717067e74b6e01e57f651).Text = check.ConditionStep4;
		c9525f87619a24b52bdeb6362d08a5560(null, null);
	}

	private void c5837264648ff03146ea3cba9217d7031(object P_0, EventArgs P_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex != 0)
		{
			__ldtoken(ActionControl.c5837264648ff03146ea3cba9217d7031(object, EventArgs));
			ce934006d23f9c541701af4a7e1dab46f().Checks.RemoveAt(((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex);
			c4e7f938e7e498f7339be7ccf18e84053.Items.RemoveAt(((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex);
			((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex = 0;
		}
		else
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14199));
		}
	}

	private void c06f8f7d67d4cc846a066fee2e3b8fcaa(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(ActionControl.c06f8f7d67d4cc846a066fee2e3b8fcaa(object, MouseEventArgs));
		}
		else if (!c09339147ff81a8d975d8fcf141910684)
		{
			__ldtoken(ActionControl.c06f8f7d67d4cc846a066fee2e3b8fcaa(object, MouseEventArgs));
		}
		else if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.c06f8f7d67d4cc846a066fee2e3b8fcaa(object, MouseEventArgs));
		}
		else
		{
			((Control)this).DoDragDrop((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14296), (DragDropEffects)(-2147483645));
		}
	}

	private void c6765c98cf5c0381b87714b921a078d31(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = (DragDropEffects)0;
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
			return;
		}
		string text = (string)P_1.Data.GetData(DataFormats.StringFormat);
		if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14296)))
		{
			__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
			return;
		}
		TreeViewHitTestInfo val = tvActionsConditions.HitTest(((Control)tvActionsConditions).PointToClient(new Point(P_1.X, P_1.Y)));
		if (val.Node == null)
		{
			__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
		}
		else if (!(val.Node.Tag is Command) && !(val.Node.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)) && !(val.Node.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434)))
		{
			__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
			if (!(val.Node.Tag is Condition))
			{
				__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
				if (!(val.Node.Tag is Action))
				{
					__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
					return;
				}
				if (!(tvActionsConditions.SelectedNode.Tag is Action))
				{
					__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
				}
				else
				{
					P_1.Effect = (DragDropEffects)(-2147483645);
				}
				if (!(tvActionsConditions.SelectedNode.Tag is Condition))
				{
					__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
				}
				else
				{
					P_1.Effect = (DragDropEffects)(-2147483645);
				}
			}
			else if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				P_1.Effect = (DragDropEffects)(-2147483645);
			}
		}
		else
		{
			if (tvActionsConditions.SelectedNode.Tag is Command)
			{
				__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
			}
			else if (!(tvActionsConditions.SelectedNode.Tag is Condition))
			{
				__ldtoken(ActionControl.c6765c98cf5c0381b87714b921a078d31(object, DragEventArgs));
				return;
			}
			P_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void c976b838f4ac677954c6de4b09b7529ab()
	{
		TreeNode val = null;
		ArrayList arrayList = null;
		int num = 0;
		Action action = c48d5625ef051338905ddc110c05a3e45();
		if (tvActionsConditions.SelectedNode.Level > 1)
		{
			__ldtoken(ActionControl.c976b838f4ac677954c6de4b09b7529ab());
			TreeNode val2 = null;
			if (tvActionsConditions.SelectedNode.Tag == null)
			{
				__ldtoken(ActionControl.c976b838f4ac677954c6de4b09b7529ab());
			}
			else
			{
				val2 = tvActionsConditions.SelectedNode;
				tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
			}
			arrayList = c7f49c36388f468bae9971fa86acff3b7(c70fc5e11ebdc77a9c3dfb7b8ebc35173());
			if (val2 == null)
			{
				__ldtoken(ActionControl.c976b838f4ac677954c6de4b09b7529ab());
			}
			else
			{
				tvActionsConditions.SelectedNode = val2;
			}
			val = cd1e3095bc2b5a0be843f7e7e55131995();
			num = 0;
		}
		else
		{
			arrayList = action.Conditions;
			val = c3ede567c56bcc31cebb9f8c7704be790();
			num = 0;
		}
		IDataObject dataObject = Clipboard.GetDataObject();
		Condition condition = dataObject.GetData(ConditonFormat.Name) as Condition;
		if (arrayList.Count != 0)
		{
			__ldtoken(ActionControl.c976b838f4ac677954c6de4b09b7529ab());
			arrayList.Insert(num, condition);
		}
		else
		{
			arrayList.Add(condition);
		}
		ca407d0f5d0cd104f6f38637c29c4bb1a(condition, val, num);
	}

	private void c8f233cbe223d95f4d6ce268c0436d5ff(object P_0, DragEventArgs P_1)
	{
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected Obj, but got Unknown
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			return;
		}
		cda013117bea2e25bc784a82617db97c6();
		_ = (string)P_1.Data.GetData(DataFormats.StringFormat);
		TreeViewHitTestInfo val = tvActionsConditions.HitTest(((Control)tvActionsConditions).PointToClient(new Point(P_1.X, P_1.Y)));
		if (!(tvActionsConditions.SelectedNode.Tag is Command command))
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
		}
		else
		{
			Command command2 = val.Node.Tag as Command;
			if (command2 == command)
			{
				return;
			}
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			if (command2 == null)
			{
				if (val.Node.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				}
				else if (!(val.Node.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434)))
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
					goto IL_02bd;
				}
			}
			cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314));
			cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231));
			tvActionsConditions.SelectedNode = val.Node;
			int i = 0;
			int num;
			if (tvActionsConditions.SelectedNode.Parent.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				num = 1;
			}
			else
			{
				num = ((tvActionsConditions.SelectedNode.Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395)) ? 1 : 0);
			}
			ArrayList arrayList = c7f49c36388f468bae9971fa86acff3b7((byte)num != 0);
			if (command2 == null)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			else
			{
				for (i = 0; i < arrayList.Count; i++)
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
					if (arrayList[i] as Command != command2)
					{
						__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
					}
					else if (arrayList[i] is Command)
					{
						__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
						break;
					}
				}
			}
			IDataObject dataObject = Clipboard.GetDataObject();
			Command command3 = dataObject.GetData(CommandFormat.Name) as Command;
			arrayList.Insert(i, command3);
			TreeNode val2 = new TreeNode(cee63400536b49afc634b51f621e13ca3(command3), 3, 3);
			val2.Tag = command3;
			val2.ForeColor = Color.DarkGoldenrod;
			if (command2 == null)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				val.Node.Nodes.Insert(i, val2);
			}
			else
			{
				val.Node.Parent.Nodes.Insert(i, val2);
			}
		}
		goto IL_02bd;
		IL_0515:
		IDataObject dataObject2 = Clipboard.GetDataObject();
		Condition condition = dataObject2.GetData(ConditonFormat.Name) as Condition;
		ArrayList arrayList2;
		int j;
		if (arrayList2.Count != 0)
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			arrayList2.Insert(j, condition);
		}
		else
		{
			arrayList2.Add(condition);
		}
		TreeNode val3;
		ca407d0f5d0cd104f6f38637c29c4bb1a(condition, val3, j);
		goto IL_0574;
		IL_0574:
		if (!(tvActionsConditions.SelectedNode.Tag is Action action))
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			return;
		}
		Action action2 = val.Node.Tag as Action;
		if (action2 == action)
		{
			return;
		}
		cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260));
		cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054));
		tvActionsConditions.SelectedNode = val.Node;
		int num2 = 0;
		ArrayList arrayList3 = c9ace99d5d5238fce319298fe34c80436();
		for (num2 = 0; num2 < arrayList3.Count; num2++)
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			if ((Action)arrayList3[num2] == action2)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				break;
			}
		}
		num2++;
		IDataObject dataObject3 = Clipboard.GetDataObject();
		Action action3 = dataObject3.GetData(ActionFormat.Name) as Action;
		arrayList3.Insert(num2, action3);
		cb08e057efb6abeb46f9124049d0ce710(action3, num2, true);
		return;
		IL_02bd:
		if (!(tvActionsConditions.SelectedNode.Tag is Condition condition2))
		{
			__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			goto IL_0574;
		}
		Condition condition3 = val.Node.Tag as Condition;
		if (condition3 == condition2)
		{
			return;
		}
		__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
		Command command4 = val.Node.Tag as Command;
		val3 = null;
		arrayList2 = null;
		cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2366));
		cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108));
		tvActionsConditions.SelectedNode = val.Node;
		j = 0;
		Action action4 = c48d5625ef051338905ddc110c05a3e45();
		if (val.Node.Level <= 1)
		{
			arrayList2 = action4.Conditions;
			val3 = c3ede567c56bcc31cebb9f8c7704be790();
			if (command4 != null)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			else
			{
				if (condition3 == null)
				{
					j = 0;
					goto IL_0515;
				}
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			for (j = 0; j < arrayList2.Count; j++)
			{
				if ((Condition)action4.Conditions[j] == condition3)
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
					break;
				}
			}
		}
		else
		{
			TreeNode val4 = null;
			if (tvActionsConditions.SelectedNode.Tag == null)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			else
			{
				val4 = tvActionsConditions.SelectedNode;
				tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
			}
			arrayList2 = c7f49c36388f468bae9971fa86acff3b7(c70fc5e11ebdc77a9c3dfb7b8ebc35173());
			if (val4 != null)
			{
				tvActionsConditions.SelectedNode = val4;
			}
			val3 = cd1e3095bc2b5a0be843f7e7e55131995();
			if (command4 != null)
			{
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			else
			{
				if (condition3 == null)
				{
					j = 0;
					goto IL_0515;
				}
				__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
			}
			for (j = 0; j < arrayList2.Count; j++)
			{
				if (arrayList2[j] as Command != command4)
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				}
				else if (arrayList2[j] is Command)
				{
					break;
				}
				if (arrayList2[j] as Condition != condition3)
				{
					__ldtoken(ActionControl.c8f233cbe223d95f4d6ce268c0436d5ff(object, DragEventArgs));
				}
				else if (arrayList2[j] is Condition)
				{
					break;
				}
			}
		}
		goto IL_0515;
	}

	private void cb3e98f01ab302041452d7a8dbe1a83b5(object P_0, EventArgs P_1)
	{
		switch (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex)
		{
		default:
			return;
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
			__ldtoken(ActionControl.cb3e98f01ab302041452d7a8dbe1a83b5(object, EventArgs));
			break;
		case Command.CommandType.CT_SETVARIABLE:
			break;
		}
		string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c962ce47954ab1816402cab8d8ab59271).Text, null);
		int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6198));
		if (num <= -1)
		{
			__ldtoken(ActionControl.cb3e98f01ab302041452d7a8dbe1a83b5(object, EventArgs));
		}
		else
		{
			text = text.Remove(num, 6);
		}
		GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(text);
		if (variableByName.vartype != GameVariable.VarType.VT_DATETIME)
		{
			return;
		}
		if (!(c2332b911806c4b9e235af5bfdc94f97d.SelectedItem.ToString() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955)))
		{
			__ldtoken(ActionControl.cb3e98f01ab302041452d7a8dbe1a83b5(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		if (!(command.CommandPart4 == string.Empty))
		{
			__ldtoken(ActionControl.cb3e98f01ab302041452d7a8dbe1a83b5(object, EventArgs));
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text = command.CommandPart4;
		}
		else
		{
			((Control)c4053b9b7d85ea311db9e2c9a464192fb).Text = variableByName.dtDateTime.ToString();
			cddc1ea294279bcdb05adc9c1a6e727ec(null, null);
		}
	}

	private void cfedc4f9e023fac8c77e0a73a51803621(object P_0, EventArgs P_1)
	{
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_Comparison && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
		{
			__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
			return;
		}
		GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)c428ebf94dee726b1e31b460540bbbc1f).Text, null));
		if (variableByName == null)
		{
			__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
			return;
		}
		GameVariable.VarType vartype = variableByName.vartype;
		if (vartype != GameVariable.VarType.VT_DATETIME)
		{
			return;
		}
		__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
		if (!(((Check)ce934006d23f9c541701af4a7e1dab46f().Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep4 == string.Empty))
		{
			__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
			((Control)ce461a44e2020b57573abdc365294fa10).Text = ((Check)ce934006d23f9c541701af4a7e1dab46f().Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep4;
		}
		else
		{
			string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(((Control)cb14d51ac8530fe4463993959ce4a6d75).Text, null);
			if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7955))
			{
				__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
			}
			else if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7968)))
			{
				if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8006))
				{
					__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
				}
				else if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8031)))
				{
					__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
					if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8134)))
					{
						__ldtoken(ActionControl.cfedc4f9e023fac8c77e0a73a51803621(object, EventArgs));
						((Control)ce461a44e2020b57573abdc365294fa10).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14322);
					}
					else
					{
						((Control)ce461a44e2020b57573abdc365294fa10).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14309);
					}
					goto IL_020d;
				}
			}
			((Control)ce461a44e2020b57573abdc365294fa10).Text = variableByName.dtDateTime.ToString();
		}
		goto IL_020d;
		IL_020d:
		c7350437f8d195123268cc15c01f24dc0(null, null);
	}

	private void c4174d1b058f63b1956e3f161fc3dbada(object P_0, EventArgs P_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14325), ref c54f9a911545745b85ae6f74355697f8b);
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			__ldtoken(ActionControl.c4174d1b058f63b1956e3f161fc3dbada(object, EventArgs));
			return;
		}
		if (!(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty))
		{
			__ldtoken(ActionControl.c4174d1b058f63b1956e3f161fc3dbada(object, EventArgs));
			return;
		}
		if (!(tvActionsConditions.SelectedNode.Tag is Command command))
		{
			__ldtoken(ActionControl.c4174d1b058f63b1956e3f161fc3dbada(object, EventArgs));
			return;
		}
		if (command.cmdtype != Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT)
		{
			__ldtoken(ActionControl.c4174d1b058f63b1956e3f161fc3dbada(object, EventArgs));
			c3834cad3fa310a2ecdf84f4b34e287f5.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
			command.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
			return;
		}
		try
		{
			Convert.ToDouble(((Control)getNameFrm.txtEntry).Text);
			c3834cad3fa310a2ecdf84f4b34e287f5.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
			command.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
		}
		catch
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14352));
		}
	}

	private void c26c3611ef95c21783f5f8291e9bea272(object P_0, EventArgs P_1)
	{
		for (int num = c3834cad3fa310a2ecdf84f4b34e287f5.SelectedItems.Count - 1; num >= 0; num--)
		{
			__ldtoken(ActionControl.c26c3611ef95c21783f5f8291e9bea272(object, EventArgs));
			string text = c3834cad3fa310a2ecdf84f4b34e287f5.SelectedItems[num].ToString();
			if (!(tvActionsConditions.SelectedNode.Tag is Command command))
			{
				__ldtoken(ActionControl.c26c3611ef95c21783f5f8291e9bea272(object, EventArgs));
			}
			else
			{
				command.CustomChoices.Remove(text);
			}
			c3834cad3fa310a2ecdf84f4b34e287f5.Items.Remove((object)text);
		}
	}

	private void c1b8d6f44ec1e60f1d989e8b70c960f86(object P_0, EventArgs P_1)
	{
		if (!ce71e85e952218edc33bda5326c37ed93.Checked)
		{
			__ldtoken(ActionControl.c1b8d6f44ec1e60f1d989e8b70c960f86(object, EventArgs));
			return;
		}
		((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
		((Control)cbe61056f04fc0861514479244d36e741).Enabled = true;
		((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = true;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = true;
		((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = true;
	}

	private void ca2854c0e204333325680d57aca8854ca(object P_0, EventArgs P_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14325), ref c54f9a911545745b85ae6f74355697f8b);
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			__ldtoken(ActionControl.ca2854c0e204333325680d57aca8854ca(object, EventArgs));
			return;
		}
		if (!(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty))
		{
			__ldtoken(ActionControl.ca2854c0e204333325680d57aca8854ca(object, EventArgs));
			return;
		}
		cbe61056f04fc0861514479244d36e741.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
		if (!(tvActionsConditions.SelectedNode.Tag is Action action))
		{
			__ldtoken(ActionControl.ca2854c0e204333325680d57aca8854ca(object, EventArgs));
		}
		else
		{
			action.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
		}
	}

	private void cf58e46b399715d8f1604adf24cb895e3(object P_0, EventArgs P_1)
	{
		for (int num = cbe61056f04fc0861514479244d36e741.SelectedItems.Count - 1; num >= 0; num--)
		{
			__ldtoken(ActionControl.cf58e46b399715d8f1604adf24cb895e3(object, EventArgs));
			string text = cbe61056f04fc0861514479244d36e741.SelectedItems[num].ToString();
			if (!(tvActionsConditions.SelectedNode.Tag is Action action))
			{
				__ldtoken(ActionControl.cf58e46b399715d8f1604adf24cb895e3(object, EventArgs));
			}
			else
			{
				action.CustomChoices.Remove(text);
			}
			cbe61056f04fc0861514479244d36e741.Items.Remove((object)text);
		}
	}

	private void cc08f08633ff1da0837b78c41d7285c35(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			__ldtoken(ActionControl.cc08f08633ff1da0837b78c41d7285c35(object, EventArgs));
			return;
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		if (!(c1ae51f04467ab9b62260d376b5dc5cba.SelectedItem is RoomComboItem roomComboItem))
		{
			__ldtoken(ActionControl.cc08f08633ff1da0837b78c41d7285c35(object, EventArgs));
			command.CommandPart4 = ((Control)c1ae51f04467ab9b62260d376b5dc5cba).Text;
		}
		else
		{
			command.CommandPart4 = roomComboItem.UniqueID.ToString();
		}
		tvActionsConditions.SelectedNode.Text = cee63400536b49afc634b51f621e13ca3(command);
	}

	private void cfb3fc7b44bdcf977af7a8ed78b3b63a7(object P_0, EventArgs P_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		c48d5625ef051338905ddc110c05a3e45();
		((Check)condition.Checks[((ListControl)c4e7f938e7e498f7339be7ccf18e84053).SelectedIndex]).ConditionStep4 = ((Control)cb110e655831717067e74b6e01e57f651).Text;
	}

	private void caebdb7abd181397ed857770c2d66faad(object P_0, EventArgs P_1)
	{
	}

	public string insertVariableToolStripMenuItem()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref c54f9a911545745b85ae6f74355697f8b);
		TextHandlers.PopulateVariableMenu(ref tempfrm, ref c54f9a911545745b85ae6f74355697f8b);
		if ((int)((Form)tempfrm).ShowDialog() != 1)
		{
			__ldtoken(ActionControl.insertVariableToolStripMenuItem());
		}
		else
		{
			switch (tempfrm.tabControl1.SelectedIndex)
			{
			case 0:
				if (tempfrm.lbSysVariables.SelectedItem == null)
				{
					__ldtoken(ActionControl.insertVariableToolStripMenuItem());
				}
				else
				{
					result = tempfrm.lbSysVariables.SelectedItem.ToString();
				}
				break;
			case 1:
				if (tempfrm.lbVariables.SelectedItem == null)
				{
					__ldtoken(ActionControl.insertVariableToolStripMenuItem());
				}
				else
				{
					result = tempfrm.lbVariables.SelectedItem.ToString();
				}
				break;
			case 2:
				if (tempfrm.lbCustProp.SelectedItem != null)
				{
					result = tempfrm.lbCustProp.SelectedItem.ToString();
				}
				break;
			case 3:
				result = ((Control)tempfrm.tbText).Text;
				break;
			}
		}
		return result;
	}

	private void c9c904811161e9d2ffac7cee9283aaa20(object P_0, EventArgs P_1)
	{
		c6142b4080fdb112e2e031ff1a2ddbbad = P_0;
	}

	private void c66fe0c92881d31048880fc7f060cc864(object P_0, KeyPressEventArgs P_1)
	{
	}

	private void cd0fe0ff1c6f563cd312050269e1750cf(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyData != 262230)
		{
			__ldtoken(ActionControl.cd0fe0ff1c6f563cd312050269e1750cf(object, KeyEventArgs));
			return;
		}
		TextBox val = (TextBox)((P_0 is TextBox) ? P_0 : null);
		ComboBox val2 = (ComboBox)((P_0 is ComboBox) ? P_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = val2.SelectionStart;
		}
		if (val == null)
		{
			__ldtoken(ActionControl.cd0fe0ff1c6f563cd312050269e1750cf(object, KeyEventArgs));
		}
		else
		{
			startIndex = ((TextBoxBase)val).SelectionStart;
		}
		string text = insertVariableToolStripMenuItem();
		if (!(text != string.Empty))
		{
			__ldtoken(ActionControl.cd0fe0ff1c6f563cd312050269e1750cf(object, KeyEventArgs));
		}
		else if (val == null)
		{
			__ldtoken(ActionControl.cd0fe0ff1c6f563cd312050269e1750cf(object, KeyEventArgs));
			if (val2 != null)
			{
				((Control)val2).Text = ((Control)val2).Text.Insert(startIndex, text);
			}
		}
		else
		{
			((Control)val).Text = ((Control)val).Text.Insert(startIndex, text);
		}
	}

	private void c3f138fb1e61dc12c8b4d8cb2f696d886(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(ActionControl.c3f138fb1e61dc12c8b4d8cb2f696d886(object, MouseEventArgs));
		}
		else
		{
			c21866eb25aee37e6f752f82def05d536 = true;
		}
	}

	private void cd788b973e5976cd98f99d9a2b365af5a(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(ActionControl.cd788b973e5976cd98f99d9a2b365af5a(object, MouseEventArgs));
		}
		else if (c21866eb25aee37e6f752f82def05d536 && cbe61056f04fc0861514479244d36e741.SelectedItems.Count > 0)
		{
			((Control)this).DoDragDrop((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14427), (DragDropEffects)(-2147483645));
		}
	}

	private void cd547d27a1546bf39f0dee4d03bab53e9(object P_0, MouseEventArgs P_1)
	{
		c21866eb25aee37e6f752f82def05d536 = false;
	}

	private void ce931c6a7d9f3b19edcf779e866e6c5f1(object P_0, DragEventArgs P_1)
	{
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.ce931c6a7d9f3b19edcf779e866e6c5f1(object, DragEventArgs));
			return;
		}
		string text = (string)P_1.Data.GetData(DataFormats.StringFormat);
		if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14427)))
		{
			__ldtoken(ActionControl.ce931c6a7d9f3b19edcf779e866e6c5f1(object, DragEventArgs));
		}
		else
		{
			P_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void c2f7761ae251e25a553c22ed7ffb1e135(object P_0, DragEventArgs P_1)
	{
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.c2f7761ae251e25a553c22ed7ffb1e135(object, DragEventArgs));
			return;
		}
		int num = cbe61056f04fc0861514479244d36e741.IndexFromPoint(((Control)cbe61056f04fc0861514479244d36e741).PointToClient(new Point(P_1.X, P_1.Y)));
		if (num <= -1)
		{
			__ldtoken(ActionControl.c2f7761ae251e25a553c22ed7ffb1e135(object, DragEventArgs));
			return;
		}
		Action action = c48d5625ef051338905ddc110c05a3e45();
		int selectedIndex = ((ListControl)cbe61056f04fc0861514479244d36e741).SelectedIndex;
		string value = action.CustomChoices[selectedIndex].ToString();
		action.CustomChoices.RemoveAt(selectedIndex);
		action.CustomChoices.Insert(num, value);
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c59535723c41b6efaf3adcb12666a4ac4(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(ActionControl.c59535723c41b6efaf3adcb12666a4ac4(object, MouseEventArgs));
		}
		else
		{
			c5c3023d84324dc6ac5cbb7910e689ef9 = true;
		}
	}

	private void c9bb9b39786d1e8a5518508d90e386976(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(ActionControl.c9bb9b39786d1e8a5518508d90e386976(object, MouseEventArgs));
		}
		else if (!c5c3023d84324dc6ac5cbb7910e689ef9)
		{
			__ldtoken(ActionControl.c9bb9b39786d1e8a5518508d90e386976(object, MouseEventArgs));
		}
		else if (c3834cad3fa310a2ecdf84f4b34e287f5.SelectedItems.Count <= 0)
		{
			__ldtoken(ActionControl.c9bb9b39786d1e8a5518508d90e386976(object, MouseEventArgs));
		}
		else
		{
			((Control)this).DoDragDrop((object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14470), (DragDropEffects)(-2147483645));
		}
	}

	private void c846b16fceea38788e816341268ce6d1f(object P_0, MouseEventArgs P_1)
	{
		c5c3023d84324dc6ac5cbb7910e689ef9 = false;
	}

	private void c4dd9a51648843df150a95836bd898122(object P_0, DragEventArgs P_1)
	{
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.c4dd9a51648843df150a95836bd898122(object, DragEventArgs));
			return;
		}
		string text = (string)P_1.Data.GetData(DataFormats.StringFormat);
		if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14470)))
		{
			__ldtoken(ActionControl.c4dd9a51648843df150a95836bd898122(object, DragEventArgs));
		}
		else
		{
			P_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void cfe80ddd6816d9b09a7250ef65e23a439(object P_0, DragEventArgs P_1)
	{
		if (!P_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			__ldtoken(ActionControl.cfe80ddd6816d9b09a7250ef65e23a439(object, DragEventArgs));
			return;
		}
		int num = c3834cad3fa310a2ecdf84f4b34e287f5.IndexFromPoint(((Control)c3834cad3fa310a2ecdf84f4b34e287f5).PointToClient(new Point(P_1.X, P_1.Y)));
		if (num <= -1)
		{
			__ldtoken(ActionControl.cfe80ddd6816d9b09a7250ef65e23a439(object, DragEventArgs));
			return;
		}
		if (!(tvActionsConditions.SelectedNode.Tag is Command command))
		{
			__ldtoken(ActionControl.cfe80ddd6816d9b09a7250ef65e23a439(object, DragEventArgs));
			return;
		}
		int selectedIndex = ((ListControl)c3834cad3fa310a2ecdf84f4b34e287f5).SelectedIndex;
		string value = command.CustomChoices[selectedIndex].ToString();
		command.CustomChoices.RemoveAt(selectedIndex);
		command.CustomChoices.Insert(num, value);
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c66d5436ed2d607fbbd3c77901c90b372(object P_0, EventArgs P_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		if (((ListControl)c3834cad3fa310a2ecdf84f4b34e287f5).SelectedIndex <= -1)
		{
			__ldtoken(ActionControl.c66d5436ed2d607fbbd3c77901c90b372(object, EventArgs));
			return;
		}
		int selectedIndex = ((ListControl)c3834cad3fa310a2ecdf84f4b34e287f5).SelectedIndex;
		GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14501), ref c54f9a911545745b85ae6f74355697f8b);
		((Control)getNameFrm.txtEntry).Text = c3834cad3fa310a2ecdf84f4b34e287f5.SelectedItem.ToString();
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			__ldtoken(ActionControl.c66d5436ed2d607fbbd3c77901c90b372(object, EventArgs));
			return;
		}
		if (!(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty))
		{
			__ldtoken(ActionControl.c66d5436ed2d607fbbd3c77901c90b372(object, EventArgs));
			return;
		}
		if (tvActionsConditions.SelectedNode.Tag is Command command)
		{
			command.CustomChoices.RemoveAt(selectedIndex);
			command.CustomChoices.Insert(selectedIndex, ((Control)getNameFrm.txtEntry).Text);
		}
		c7797903c3b20f17c77f70c8fde465600();
	}

	private void c055b4f9350ecf550bbdfdc8183550d2b(object P_0, EventArgs P_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		if (((ListControl)cbe61056f04fc0861514479244d36e741).SelectedIndex <= -1)
		{
			__ldtoken(ActionControl.c055b4f9350ecf550bbdfdc8183550d2b(object, EventArgs));
			return;
		}
		int selectedIndex = ((ListControl)cbe61056f04fc0861514479244d36e741).SelectedIndex;
		GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14501), ref c54f9a911545745b85ae6f74355697f8b);
		((Control)getNameFrm.txtEntry).Text = cbe61056f04fc0861514479244d36e741.SelectedItem.ToString();
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			__ldtoken(ActionControl.c055b4f9350ecf550bbdfdc8183550d2b(object, EventArgs));
			return;
		}
		if (!(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty))
		{
			__ldtoken(ActionControl.c055b4f9350ecf550bbdfdc8183550d2b(object, EventArgs));
			return;
		}
		if (!(tvActionsConditions.SelectedNode.Tag is Action action))
		{
			__ldtoken(ActionControl.c055b4f9350ecf550bbdfdc8183550d2b(object, EventArgs));
		}
		else
		{
			action.CustomChoices.RemoveAt(selectedIndex);
			action.CustomChoices.Insert(selectedIndex, ((Control)getNameFrm.txtEntry).Text);
		}
		c7797903c3b20f17c77f70c8fde465600();
	}

	private bool c70fc5e11ebdc77a9c3dfb7b8ebc35173()
	{
		bool result = false;
		TreeNode val = tvActionsConditions.SelectedNode;
		string text = val.Text;
		while (text != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
		{
			if (!(text != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434)))
			{
				__ldtoken(ActionControl.c70fc5e11ebdc77a9c3dfb7b8ebc35173());
				break;
			}
			if (val.Parent == null)
			{
				break;
			}
			__ldtoken(ActionControl.c70fc5e11ebdc77a9c3dfb7b8ebc35173());
			val = val.Parent;
			text = val.Text;
		}
		if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
		{
			result = true;
		}
		return result;
	}

	private TreeNode cd1e3095bc2b5a0be843f7e7e55131995()
	{
		TreeNode val = tvActionsConditions.SelectedNode;
		string text = val.Text;
		while (val.Parent != null)
		{
			__ldtoken(ActionControl.cd1e3095bc2b5a0be843f7e7e55131995());
			if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2395))
			{
				__ldtoken(ActionControl.cd1e3095bc2b5a0be843f7e7e55131995());
				break;
			}
			if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2434))
			{
				__ldtoken(ActionControl.cd1e3095bc2b5a0be843f7e7e55131995());
				break;
			}
			val = val.Parent;
			text = val.Text;
		}
		return val;
	}

	private void c29af5bbcc0a4899d32106bddd5c7863b()
	{
		IDataObject dataObject = Clipboard.GetDataObject();
		if (!(dataObject.GetData(CommandFormat.Name) is Command))
		{
			__ldtoken(ActionControl.c29af5bbcc0a4899d32106bddd5c7863b());
			if (dataObject.GetData(ConditonFormat.Name) is Condition)
			{
				cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2283));
			}
			else if (!(dataObject.GetData(ActionFormat.Name) is Action))
			{
				__ldtoken(ActionControl.c29af5bbcc0a4899d32106bddd5c7863b());
			}
			else
			{
				cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1956));
			}
		}
		else
		{
			cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2339));
		}
	}

	private void cda013117bea2e25bc784a82617db97c6()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		switch (c966c316b5de02c6ef56a4713e8bdaeea)
		{
		case PageType.objects:
		{
			GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (objectByName == null)
			{
				__ldtoken(ActionControl.cda013117bea2e25bc784a82617db97c6());
			}
			else
			{
				binaryFormatter.Serialize(memoryStream, objectByName.Actions);
			}
			break;
		}
		case PageType.player:
			binaryFormatter.Serialize(memoryStream, c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions);
			break;
		case PageType.room:
		{
			Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
			if (roomByID == null)
			{
				__ldtoken(ActionControl.cda013117bea2e25bc784a82617db97c6());
			}
			else
			{
				binaryFormatter.Serialize(memoryStream, roomByID.Actions);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (characterByName != null)
			{
				binaryFormatter.Serialize(memoryStream, characterByName.Actions);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (timerByName == null)
			{
				__ldtoken(ActionControl.cda013117bea2e25bc784a82617db97c6());
			}
			else
			{
				binaryFormatter.Serialize(memoryStream, timerByName.Actions);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (menuItemByName == null)
			{
				__ldtoken(ActionControl.cda013117bea2e25bc784a82617db97c6());
			}
			else
			{
				binaryFormatter.Serialize(memoryStream, menuItemByName.Actions);
			}
			break;
		}
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		c9904ed3a443d66bdab40215e344af583 = (ArrayList)binaryFormatter.Deserialize(memoryStream);
	}

	private void c0bed368ca3d701e136539d3289387a4a()
	{
		if (c9904ed3a443d66bdab40215e344af583 == null)
		{
			__ldtoken(ActionControl.c0bed368ca3d701e136539d3289387a4a());
			return;
		}
		MemoryStream memoryStream = new MemoryStream();
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(memoryStream, c9904ed3a443d66bdab40215e344af583);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		switch (c966c316b5de02c6ef56a4713e8bdaeea)
		{
		case PageType.objects:
		{
			GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (objectByName != null)
			{
				objectByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.player:
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			break;
		case PageType.room:
		{
			Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(c1e2ad2c4b8f893c83053fbfc829e5cac));
			if (roomByID == null)
			{
				__ldtoken(ActionControl.c0bed368ca3d701e136539d3289387a4a());
			}
			else
			{
				roomByID.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (characterByName == null)
			{
				__ldtoken(ActionControl.c0bed368ca3d701e136539d3289387a4a());
			}
			else
			{
				characterByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (timerByName == null)
			{
				__ldtoken(ActionControl.c0bed368ca3d701e136539d3289387a4a());
			}
			else
			{
				timerByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = c54f9a911545745b85ae6f74355697f8b.GetMenuItemByName(c1e2ad2c4b8f893c83053fbfc829e5cac);
			if (menuItemByName == null)
			{
				__ldtoken(ActionControl.c0bed368ca3d701e136539d3289387a4a());
			}
			else
			{
				menuItemByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		}
		RefreshActions();
	}

	private void cb7f2e667f84948aa8b3810fe787cd071(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Invalid comparison between Unknown and I4
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Invalid comparison between Unknown and I4
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Invalid comparison between Unknown and I4
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Invalid comparison between Unknown and I4
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Invalid comparison between Unknown and I4
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Invalid comparison between Unknown and I4
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Invalid comparison between Unknown and I4
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Invalid comparison between Unknown and I4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Invalid comparison between Unknown and I4
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Invalid comparison between Unknown and I4
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Invalid comparison between Unknown and I4
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Invalid comparison between Unknown and I4
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Invalid comparison between Unknown and I4
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Invalid comparison between Unknown and I4
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Invalid comparison between Unknown and I4
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Invalid comparison between Unknown and I4
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Invalid comparison between Unknown and I4
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Invalid comparison between Unknown and I4
		//IL_08c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Invalid comparison between Unknown and I4
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Invalid comparison between Unknown and I4
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0952: Invalid comparison between Unknown and I4
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_097e: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyData != 131158)
		{
			__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
		}
		else
		{
			cda013117bea2e25bc784a82617db97c6();
			c29af5bbcc0a4899d32106bddd5c7863b();
		}
		if ((int)P_1.KeyData != 131162)
		{
			__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
			if ((int)P_1.KeyData != 131139)
			{
				__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
				if ((int)P_1.KeyData == 131160)
				{
					cda013117bea2e25bc784a82617db97c6();
					if (!(tvActionsConditions.SelectedNode.Tag is Command))
					{
						__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
						if (!(tvActionsConditions.SelectedNode.Tag is Condition))
						{
							__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
							if (!(tvActionsConditions.SelectedNode.Tag is Action))
							{
								__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
								return;
							}
							cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260));
							cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054));
						}
						else
						{
							cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2366));
							cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108));
						}
					}
					else
					{
						cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314));
						cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231));
					}
				}
				else if ((int)P_1.KeyData != 46)
				{
					__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
					if ((int)P_1.KeyData != 196656)
					{
						__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
						if ((int)P_1.KeyData != 196657)
						{
							__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
							if ((int)P_1.KeyData != 196658)
							{
								__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
								if ((int)P_1.KeyData != 196659)
								{
									__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
									if ((int)P_1.KeyData != 196660)
									{
										__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
										if ((int)P_1.KeyData != 196661)
										{
											__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
											if ((int)P_1.KeyData == 196662)
											{
												if (tvActionsConditions.SelectedNode != null)
												{
													__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
													if (tvActionsConditions.SelectedNode.Tag != null)
													{
														__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
														c54f9a911545745b85ae6f74355697f8b.AssignHotKey(6, tvActionsConditions.SelectedNode.Tag);
													}
												}
											}
											else if ((int)P_1.KeyData != 196663)
											{
												__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
												if ((int)P_1.KeyData != 196664)
												{
													__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
													if ((int)P_1.KeyData != 196665)
													{
														__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
														if ((int)P_1.KeyData != 131120)
														{
															__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
															if ((int)P_1.KeyData != 131121)
															{
																__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																if ((int)P_1.KeyData == 131122)
																{
																	if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(2))
																	{
																		__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																		return;
																	}
																	cda013117bea2e25bc784a82617db97c6();
																	c29af5bbcc0a4899d32106bddd5c7863b();
																}
																else if ((int)P_1.KeyData == 131123)
																{
																	if (c54f9a911545745b85ae6f74355697f8b.SetClipboardData(3))
																	{
																		cda013117bea2e25bc784a82617db97c6();
																		c29af5bbcc0a4899d32106bddd5c7863b();
																	}
																}
																else if ((int)P_1.KeyData != 131124)
																{
																	__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																	if ((int)P_1.KeyData == 131125)
																	{
																		if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(5))
																		{
																			__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																			return;
																		}
																		cda013117bea2e25bc784a82617db97c6();
																		c29af5bbcc0a4899d32106bddd5c7863b();
																	}
																	else if ((int)P_1.KeyData != 131126)
																	{
																		__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																		if ((int)P_1.KeyData != 131127)
																		{
																			__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																			if ((int)P_1.KeyData == 131128)
																			{
																				if (c54f9a911545745b85ae6f74355697f8b.SetClipboardData(8))
																				{
																					cda013117bea2e25bc784a82617db97c6();
																					c29af5bbcc0a4899d32106bddd5c7863b();
																				}
																			}
																			else if ((int)P_1.KeyData != 131129)
																			{
																				__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																			}
																			else if (c54f9a911545745b85ae6f74355697f8b.SetClipboardData(9))
																			{
																				cda013117bea2e25bc784a82617db97c6();
																				c29af5bbcc0a4899d32106bddd5c7863b();
																			}
																		}
																		else if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(7))
																		{
																			__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																		}
																		else
																		{
																			cda013117bea2e25bc784a82617db97c6();
																			c29af5bbcc0a4899d32106bddd5c7863b();
																		}
																	}
																	else if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(6))
																	{
																		__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																	}
																	else
																	{
																		cda013117bea2e25bc784a82617db97c6();
																		c29af5bbcc0a4899d32106bddd5c7863b();
																	}
																}
																else if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(4))
																{
																	__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
																}
																else
																{
																	cda013117bea2e25bc784a82617db97c6();
																	c29af5bbcc0a4899d32106bddd5c7863b();
																}
															}
															else if (c54f9a911545745b85ae6f74355697f8b.SetClipboardData(1))
															{
																cda013117bea2e25bc784a82617db97c6();
																c29af5bbcc0a4899d32106bddd5c7863b();
															}
														}
														else if (!c54f9a911545745b85ae6f74355697f8b.SetClipboardData(0))
														{
															__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
														}
														else
														{
															cda013117bea2e25bc784a82617db97c6();
															c29af5bbcc0a4899d32106bddd5c7863b();
														}
													}
													else if (tvActionsConditions.SelectedNode != null)
													{
														__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
														if (tvActionsConditions.SelectedNode.Tag != null)
														{
															c54f9a911545745b85ae6f74355697f8b.AssignHotKey(9, tvActionsConditions.SelectedNode.Tag);
														}
													}
												}
												else if (tvActionsConditions.SelectedNode != null)
												{
													__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
													if (tvActionsConditions.SelectedNode.Tag != null)
													{
														__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
														c54f9a911545745b85ae6f74355697f8b.AssignHotKey(8, tvActionsConditions.SelectedNode.Tag);
													}
												}
											}
											else if (tvActionsConditions.SelectedNode != null)
											{
												__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
												if (tvActionsConditions.SelectedNode.Tag != null)
												{
													__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
													c54f9a911545745b85ae6f74355697f8b.AssignHotKey(7, tvActionsConditions.SelectedNode.Tag);
												}
											}
										}
										else if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
										{
											__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
											c54f9a911545745b85ae6f74355697f8b.AssignHotKey(5, tvActionsConditions.SelectedNode.Tag);
										}
									}
									else if (tvActionsConditions.SelectedNode != null)
									{
										__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
										if (tvActionsConditions.SelectedNode.Tag != null)
										{
											__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
											c54f9a911545745b85ae6f74355697f8b.AssignHotKey(4, tvActionsConditions.SelectedNode.Tag);
										}
									}
								}
								else if (tvActionsConditions.SelectedNode != null)
								{
									__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
									if (tvActionsConditions.SelectedNode.Tag != null)
									{
										__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
										c54f9a911545745b85ae6f74355697f8b.AssignHotKey(3, tvActionsConditions.SelectedNode.Tag);
									}
								}
							}
							else if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
							{
								__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
								c54f9a911545745b85ae6f74355697f8b.AssignHotKey(2, tvActionsConditions.SelectedNode.Tag);
							}
						}
						else if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
						{
							__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
							c54f9a911545745b85ae6f74355697f8b.AssignHotKey(1, tvActionsConditions.SelectedNode.Tag);
						}
					}
					else if (tvActionsConditions.SelectedNode != null)
					{
						__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
						if (tvActionsConditions.SelectedNode.Tag != null)
						{
							__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
							c54f9a911545745b85ae6f74355697f8b.AssignHotKey(0, tvActionsConditions.SelectedNode.Tag);
						}
					}
				}
				else
				{
					if (tvActionsConditions.SelectedNode == null)
					{
						return;
					}
					__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
					if (tvActionsConditions.SelectedNode.Tag == null)
					{
						return;
					}
					cda013117bea2e25bc784a82617db97c6();
					if (!(tvActionsConditions.SelectedNode.Tag is Command))
					{
						__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
						if (!(tvActionsConditions.SelectedNode.Tag is Condition))
						{
							__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
							if (tvActionsConditions.SelectedNode.Tag is Action)
							{
								cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2054));
							}
						}
						else
						{
							cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2108));
						}
					}
					else
					{
						cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231));
					}
				}
			}
			else if (!(tvActionsConditions.SelectedNode.Tag is Command))
			{
				__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
				if (!(tvActionsConditions.SelectedNode.Tag is Condition))
				{
					__ldtoken(ActionControl.cb7f2e667f84948aa8b3810fe787cd071(object, KeyEventArgs));
					if (tvActionsConditions.SelectedNode.Tag is Action)
					{
						cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2260));
					}
				}
				else
				{
					cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2366));
				}
			}
			else
			{
				cbd21f246e244eb8156d8c5f6f4cb65ce(c966c316b5de02c6ef56a4713e8bdaeea, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2314));
			}
		}
		else
		{
			c0bed368ca3d701e136539d3289387a4a();
		}
	}

	private void c572a87c04d90f537c2aff1f1ede42143(object P_0, EventArgs P_1)
	{
		((Control)c4743068129d058c0158648be0270ef9d).Height = 190;
		((Control)c4743068129d058c0158648be0270ef9d).Width = ((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Width - 10;
	}

	private void c71f86529f09e31e52be9aa687567576d(object P_0, EventArgs P_1)
	{
		((Control)c4743068129d058c0158648be0270ef9d).Height = 69;
		((Control)c4743068129d058c0158648be0270ef9d).Width = ((Control)c962ce47954ab1816402cab8d8ab59271).Width;
	}

	private void cefacf560f93e949601c1977bee8551c0(object P_0, TreeViewEventArgs P_1)
	{
		if (c4743068129d058c0158648be0270ef9d.SelectedNode == null)
		{
			return;
		}
		Command.CommandType commandType = Command.CommandType.CT_UNINITIALIZED;
		try
		{
			commandType = (Command.CommandType)c4743068129d058c0158648be0270ef9d.SelectedNode.Tag;
		}
		catch
		{
			commandType = Command.CommandType.CT_UNINITIALIZED;
		}
		if (commandType == Command.CommandType.CT_UNINITIALIZED)
		{
			__ldtoken(ActionControl.cefacf560f93e949601c1977bee8551c0(object, TreeViewEventArgs));
			return;
		}
		((Control)c4743068129d058c0158648be0270ef9d).Height = 69;
		((Control)c4743068129d058c0158648be0270ef9d).Width = ((Control)c962ce47954ab1816402cab8d8ab59271).Width;
		if (commandType == Command.CommandType.CT_SETVARIABLEBYINPUT)
		{
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = false;
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = true;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = true;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = true;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = true;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = true;
		}
		else
		{
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel2Collapsed = true;
			((Control)cba88c834a279c3e211d684cb838406e9).Visible = false;
			((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = false;
			((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = false;
			((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = false;
			((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = false;
		}
		c4743068129d058c0158648be0270ef9d.TopNode = c4743068129d058c0158648be0270ef9d.SelectedNode.Parent;
	}

	private void c1941439fb25f381b46d3267873b5d71b(object P_0, EventArgs P_1)
	{
	}

	private void c060792b476a87a1b6c0bdb7a33d567b0(object P_0, EventArgs P_1)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		HelpFrm helpFrm = new HelpFrm();
		((Control)helpFrm.lblTitle).Text = ((Control)cbCommandStep1).Text;
		((TextBoxBase)helpFrm.rtText).AppendText(Command.GetCommandHelpText(((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex));
		((Form)helpFrm).ShowDialog();
		((Component)(object)helpFrm).Dispose();
	}

	private void cf6e18d491ff9efbfc316a9006da7ecdf(object P_0, EventArgs P_1)
	{
	}

	private void c0e1c8d982fa307dae7c7cb2e885716b3(object P_0, EventArgs P_1)
	{
		if (tvActionsConditions.SelectedNode.Tag is Action action)
		{
			action.CustomChoiceTitle = ((Control)cecee52f098b12876894cea6eddb9401d).Text;
		}
	}

	private void c07d7dd03cb6178d4636324d67d944c94(object P_0, MouseEventArgs P_1)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		TextBox control = (TextBox)((P_0 is TextBox) ? P_0 : null);
		ComboBox control2 = (ComboBox)((P_0 is ComboBox) ? P_0 : null);
		RagsEditor ragsEditor = null;
		if (control == null)
		{
			__ldtoken(ActionControl.c07d7dd03cb6178d4636324d67d944c94(object, MouseEventArgs));
			if (control2 == null)
			{
				__ldtoken(ActionControl.c07d7dd03cb6178d4636324d67d944c94(object, MouseEventArgs));
			}
			else
			{
				ragsEditor = new RagsEditor(ref control2, c54f9a911545745b85ae6f74355697f8b);
			}
		}
		else
		{
			ragsEditor = new RagsEditor(ref control, c54f9a911545745b85ae6f74355697f8b);
		}
		if (ragsEditor != null)
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void c5cc2a9913f91a63cd8f8f1e8d1cadd50(object P_0, EventArgs P_1)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		TextBox control = (TextBox)((P_0 is TextBox) ? P_0 : null);
		ComboBox control2 = (ComboBox)((P_0 is ComboBox) ? P_0 : null);
		RagsEditor ragsEditor = null;
		if (control == null)
		{
			__ldtoken(ActionControl.c5cc2a9913f91a63cd8f8f1e8d1cadd50(object, EventArgs));
			if (control2 == null)
			{
				__ldtoken(ActionControl.c5cc2a9913f91a63cd8f8f1e8d1cadd50(object, EventArgs));
			}
			else
			{
				ragsEditor = new RagsEditor(ref control2, c54f9a911545745b85ae6f74355697f8b);
			}
		}
		else
		{
			ragsEditor = new RagsEditor(ref control, c54f9a911545745b85ae6f74355697f8b);
		}
		if (ragsEditor == null)
		{
			__ldtoken(ActionControl.c5cc2a9913f91a63cd8f8f1e8d1cadd50(object, EventArgs));
		}
		else
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void ce27061b04c48dba77b5c3eb990add15d(object P_0, EventArgs P_1)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		ComboBox control = (ComboBox)((P_0 is ComboBox) ? P_0 : null);
		if (cac746b88c8c90ee4aab23a1126b66c7a == control)
		{
			TimeSpan timeSpan = DateTime.Now - c1a179b2093c6cfe2c1432a0a01f90fa6;
			TimeSpan timeSpan2 = TimeSpan.FromMilliseconds((double)SystemInformation.DoubleClickTime);
			if (timeSpan.TotalMilliseconds <= timeSpan2.TotalMilliseconds)
			{
				RagsEditor ragsEditor = new RagsEditor(ref control, c54f9a911545745b85ae6f74355697f8b);
				if (ragsEditor == null)
				{
					__ldtoken(ActionControl.ce27061b04c48dba77b5c3eb990add15d(object, EventArgs));
				}
				else
				{
					((Form)ragsEditor).ShowDialog();
				}
			}
		}
		else
		{
			cac746b88c8c90ee4aab23a1126b66c7a = control;
		}
		c1a179b2093c6cfe2c1432a0a01f90fa6 = DateTime.Now;
	}

	private void c20841035a81f05c8ba9640811deaa1bd(object P_0, EventArgs P_1)
	{
		if (!cc931d55a79f75a3ad8eeff54cc492876.Checked)
		{
			__ldtoken(ActionControl.c20841035a81f05c8ba9640811deaa1bd(object, EventArgs));
			return;
		}
		((Control)cafd1491656d4be80c61872cf7780040d).Enabled = false;
		((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
		((Control)cecee52f098b12876894cea6eddb9401d).Enabled = false;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
		((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
	}

	private void ca1a5380ec45f35679d403f6bc392f959(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		RadioButton val = (RadioButton)P_0;
		if (val == null)
		{
			__ldtoken(ActionControl.ca1a5380ec45f35679d403f6bc392f959(object, EventArgs));
		}
		else if (val.Checked)
		{
			((Control)cafd1491656d4be80c61872cf7780040d).Enabled = true;
			((Control)cbe61056f04fc0861514479244d36e741).Enabled = false;
			((Control)cecee52f098b12876894cea6eddb9401d).Enabled = true;
			((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Enabled = false;
			((Control)c89c23d9240530bb50613c4c2d81fbaad).Enabled = false;
			((Control)cd5530af334f348c1867bbc6535f2ccff).Enabled = false;
		}
	}

	private void cad9bf09f89721b295fdc85110a553076(object P_0, DisplayMenuEventArgs P_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		c7bb5165260e0c08dddb1e063c4ff940b = P_1.Word;
		SharpSpellLive sharpSpellLive = P_0 as SharpSpellLive;
		ContextMenu val = new ContextMenu();
		SuggestionCollection val2 = new SuggestionCollection(P_1.Dictionary, P_1.Word.Value);
		IEnumerator enumerator = val2.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Suggestion val3 = (Suggestion)enumerator.Current;
				MenuItem val4 = ((Menu)val).MenuItems.Add(val3.Value, (EventHandler)ca4e335072b967e9996ac5dca4004baf2);
				((Menu)val4).Tag = sharpSpellLive.TextBox;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ActionControl.cad9bf09f89721b295fdc85110a553076(object, DisplayMenuEventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		((Menu)val).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7796));
		((Menu)val).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14544), (EventHandler)ccf9235c13e1467d8d55b264e625660af);
		((Menu)val).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14579), (EventHandler)cef7c459267e17f22371448e7bfd608f9);
		val.Show((Control)(object)sharpSpellLive.TextBox, P_1.MousePosition);
	}

	private void ca4e335072b967e9996ac5dca4004baf2(object P_0, EventArgs P_1)
	{
		MenuItem val = (MenuItem)((P_0 is MenuItem) ? P_0 : null);
		string text = val.Text;
		object tag = ((Menu)val).Tag;
		TextBox val2 = (TextBox)((tag is TextBox) ? tag : null);
		object tag2 = ((Menu)val).Tag;
		RichTextBox val3 = (RichTextBox)((tag2 is RichTextBox) ? tag2 : null);
		if (val2 != null)
		{
			((TextBoxBase)val2).Select(c7bb5165260e0c08dddb1e063c4ff940b.Index, c7bb5165260e0c08dddb1e063c4ff940b.Value.Length);
			((TextBoxBase)val2).SelectedText = text;
		}
		else if (val3 != null)
		{
			((TextBoxBase)val3).Select(c7bb5165260e0c08dddb1e063c4ff940b.Index, c7bb5165260e0c08dddb1e063c4ff940b.Value.Length);
			((TextBoxBase)val3).SelectedText = text;
		}
	}

	private void ccf9235c13e1467d8d55b264e625660af(object P_0, EventArgs P_1)
	{
	}

	private void cef7c459267e17f22371448e7bfd608f9(object P_0, EventArgs P_1)
	{
	}

	private void c61f4a1cc3280e8604b56906412a018db(object P_0, EventArgs P_1)
	{
	}

	private void c6a2759991a28c75a4b14f98ba7461616(object P_0, EventArgs P_1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		AdvancedOverlayFrm advancedOverlayFrm = new AdvancedOverlayFrm(ref c48d5625ef051338905ddc110c05a3e45().EnhInputData, ref c54f9a911545745b85ae6f74355697f8b);
		((Form)advancedOverlayFrm).ShowDialog();
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (!(tvActionsConditions.SelectedNode.Tag is Command command))
		{
			__ldtoken(ActionControl.c7abee227c4ea05d5e309cce1e3d77c65(object, EventArgs));
			return;
		}
		AdvancedOverlayFrm advancedOverlayFrm = new AdvancedOverlayFrm(ref command.EnhInputData, ref c54f9a911545745b85ae6f74355697f8b);
		((Form)advancedOverlayFrm).ShowDialog();
	}

	private void ce965c126375cc16d84817400f647ea14(object P_0, EventArgs P_1)
	{
		if (!(tvActionsConditions.SelectedNode.Tag is Action action))
		{
			__ldtoken(ActionControl.ce965c126375cc16d84817400f647ea14(object, EventArgs));
		}
		else
		{
			action.overridename = ((Control)c07e860d38468b4c3820b72fd82b8c479).Text;
		}
	}

	private void cffdc4e00965273e3ab62d58a4afb5899(object P_0, EventArgs P_1)
	{
		Action action = c48d5625ef051338905ddc110c05a3e45();
		action.actionparent = ((Control)c857dba7e8960ec53f0faacb2f0142d89).Text;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
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
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected Obj, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Obj, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected Obj, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected Obj, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected Obj, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Obj, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected Obj, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected Obj, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected Obj, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected Obj, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected Obj, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected Obj, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected Obj, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected Obj, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected Obj, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected Obj, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected Obj, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected Obj, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected Obj, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected Obj, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected Obj, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected Obj, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected Obj, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected Obj, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected Obj, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected Obj, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected Obj, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected Obj, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected Obj, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected Obj, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected Obj, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected Obj, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected Obj, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected Obj, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected Obj, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected Obj, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected Obj, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected Obj, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected Obj, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected Obj, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected Obj, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected Obj, but got Unknown
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Expected Obj, but got Unknown
		//IL_10c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d0: Expected Obj, but got Unknown
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1184: Expected Obj, but got Unknown
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_119b: Expected Obj, but got Unknown
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b2: Expected Obj, but got Unknown
		//IL_11bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c9: Expected Obj, but got Unknown
		//IL_11d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e0: Expected Obj, but got Unknown
		//IL_11ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f7: Expected Obj, but got Unknown
		//IL_1211: Unknown result type (might be due to invalid IL or missing references)
		//IL_121b: Expected Obj, but got Unknown
		//IL_1c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c15: Expected Obj, but got Unknown
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e88: Expected Obj, but got Unknown
		//IL_205d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2067: Expected Obj, but got Unknown
		//IL_22a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_22aa: Expected Obj, but got Unknown
		//IL_2803: Unknown result type (might be due to invalid IL or missing references)
		//IL_280d: Expected Obj, but got Unknown
		//IL_29dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e6: Expected Obj, but got Unknown
		//IL_2c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c4d: Expected Obj, but got Unknown
		//IL_2fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb2: Expected Obj, but got Unknown
		//IL_3048: Unknown result type (might be due to invalid IL or missing references)
		//IL_3052: Expected Obj, but got Unknown
		//IL_3157: Unknown result type (might be due to invalid IL or missing references)
		//IL_3161: Expected Obj, but got Unknown
		//IL_316e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3178: Expected Obj, but got Unknown
		//IL_31b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_31bf: Expected Obj, but got Unknown
		//IL_32e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_32eb: Expected Obj, but got Unknown
		//IL_32f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3302: Expected Obj, but got Unknown
		//IL_330f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3319: Expected Obj, but got Unknown
		//IL_3326: Unknown result type (might be due to invalid IL or missing references)
		//IL_3330: Expected Obj, but got Unknown
		//IL_333d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3347: Expected Obj, but got Unknown
		//IL_33e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ee: Expected Obj, but got Unknown
		//IL_34a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b3: Expected Obj, but got Unknown
		//IL_356b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3575: Expected Obj, but got Unknown
		//IL_3a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a4c: Expected Obj, but got Unknown
		//IL_3c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ca6: Expected Obj, but got Unknown
		//IL_3cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cbd: Expected Obj, but got Unknown
		//IL_3cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd4: Expected Obj, but got Unknown
		//IL_3ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ceb: Expected Obj, but got Unknown
		//IL_3cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d02: Expected Obj, but got Unknown
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ActionControl));
		cd5530af334f348c1867bbc6535f2ccff = new Button();
		c283bbab44b3fca5d39367f132894644e = new GroupBox();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		c07e860d38468b4c3820b72fd82b8c479 = new TextBox();
		ca97c16bb25e579acbfca5f9ec5f38762 = new GroupBox();
		c345fb42ff93f6376eb2f0cb2c093e67e = new Button();
		c8af24b3132c3f9bc521cb9cccc12a224 = new RadioButton();
		ce71e85e952218edc33bda5326c37ed93 = new RadioButton();
		c789be2065ed12ebb629dcfca687809c5 = new RadioButton();
		c602fc3992403e5cdad0409e1900aed07 = new RadioButton();
		c1a3979b2807ce107cbb855fb8ff7202b = new RadioButton();
		c4f77bfbc101bbe9d822a90c9ec242f9b = new RadioButton();
		cc931d55a79f75a3ad8eeff54cc492876 = new RadioButton();
		c225aaa2c7205152650b3b8a11c5c00c3 = new CheckBox();
		ce3a976124811ba8f18adc6cb8899b0e8 = new GroupBox();
		c8854d358ef39133e603ce658d3c732b9 = new RadioButton();
		c602cc87b31944701be94229b41e8bb82 = new RadioButton();
		ccd86f2a93b81505af97aa59a0c4f0545 = new GroupBox();
		c857dba7e8960ec53f0faacb2f0142d89 = new ComboBox();
		tvActionsConditions = new TreeView();
		c04dcf0368a2156705fbbc1fedf6f193e = new ImageList(c501c89bc63d55bb522eac228aeeebb18);
		ce0af834a86d4a32667002a2e1c9c4359 = new GroupBox();
		cfdd28b747afbe52686772d0eed813027 = new SplitContainer();
		cca635a57d99b03a02717c239805e2524 = new TextBox();
		cee63b5aaa73084c565be53403d6d78a5 = new Label();
		c98dd8245994cd868d7cdfd180f7f9422 = new SplitContainer();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c1dfd66f09bc1eca582c72926f1f2451c = new Button();
		c4861c86b27c29b83354ab24250603283 = new Button();
		c4e7f938e7e498f7339be7ccf18e84053 = new ListBox();
		c3a8094646f27dd51898bdb4dfaa78e09 = new ContextMenuStrip(c501c89bc63d55bb522eac228aeeebb18);
		c9a160b3483ca491f08d14af12abc7625 = new ToolStripMenuItem();
		c7184c85f3188ef6bb4961cf9c847fbfa = new ToolStripMenuItem();
		c944661025bdf591000e92f861eadb21b = new ToolStripMenuItem();
		cb14d51ac8530fe4463993959ce4a6d75 = new ComboBox();
		cdcc543dc83800ba1d24d764066e3005e = new Label();
		cae81a39c04741469eb9b7f14cd68b352 = new Label();
		c428ebf94dee726b1e31b460540bbbc1f = new ComboBox();
		cbConditionStep1 = new ComboBox();
		ce461a44e2020b57573abdc365294fa10 = new TextBox();
		c1ff7ab8162850bc386a55daadfc620be = new Label();
		c57eeb71d9b376ae36eb2d1b058003c64 = new Label();
		cb110e655831717067e74b6e01e57f651 = new ComboBox();
		c1844ff8515e2e1bb16edc45f8622b8bb = new GroupBox();
		c2a161da002bb8cdd90af79c65bcd8c5f = new SplitContainer();
		c745b25e1019649e3ccbbb38d595446ae = new Button();
		c2332b911806c4b9e235af5bfdc94f97d = new ComboBox();
		c43a2d1ff6560b2051d7cf8dfa9309b98 = new Label();
		c1ae51f04467ab9b62260d376b5dc5cba = new ComboBox();
		c0409bb493de758becfc185d928829028 = new Label();
		c86cb42b5f2066de273d56833f0cfcf54 = new Label();
		c962ce47954ab1816402cab8d8ab59271 = new ComboBox();
		c85ec63372a2560632b32285c85e56156 = new Label();
		cb515fc292bfc8c27f12c9a825983cfd4 = new Label();
		cbCommandStep1 = new ComboBox();
		c4053b9b7d85ea311db9e2c9a464192fb = new TextBox();
		c4743068129d058c0158648be0270ef9d = new TreeView();
		c7366ee5636b59024f2e8b9b7ba28fcec = new TextBox();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		c3834cad3fa310a2ecdf84f4b34e287f5 = new ListBox();
		cba88c834a279c3e211d684cb838406e9 = new Label();
		c77967f9eb311ee3d9905b43b5337f9ad = new Button();
		c7fc17de416b5bf7ec20d075233fc568b = new Button();
		c0483f8f42ff39d5f74e69515eb6ba2f0 = new Button();
		ca682b8c5c7d2bfaac844245d6ad7a15d = new Label();
		c30a1afe18fa8ade4415ebdf1fe821777 = new ContextMenuStrip(c501c89bc63d55bb522eac228aeeebb18);
		cbbc887de9f5ea470255e15cc298c7942 = new ContextMenuStrip(c501c89bc63d55bb522eac228aeeebb18);
		cd5960a6d819462b79433c8fb6bcbc7c8 = new ToolStripMenuItem();
		c218905ada22e5e6f0335e6dbf5db6b9c = new ToolStripMenuItem();
		c98d6867393e88ba8ec22c0c28b73b18d = new ContextMenuStrip(c501c89bc63d55bb522eac228aeeebb18);
		c27df608f4ca3131ea673455fe08bc608 = new ToolStripMenuItem();
		ce55fd3799a0de16dd3b2992bce9aad39 = new ToolStripMenuItem();
		cafd1491656d4be80c61872cf7780040d = new GroupBox();
		cecee52f098b12876894cea6eddb9401d = new TextBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c89c23d9240530bb50613c4c2d81fbaad = new Button();
		cd8c2e9bd4cb7b2a770566b2f66754b3b = new Button();
		cbe61056f04fc0861514479244d36e741 = new ListBox();
		cc2b2196e6c009b5ea6d986a89947275c = new ToolTip(c501c89bc63d55bb522eac228aeeebb18);
		c1ef940cdb8be768145bbb7ae47e0f539 = new SharpSpellLive();
		((Control)c283bbab44b3fca5d39367f132894644e).SuspendLayout();
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).SuspendLayout();
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).SuspendLayout();
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).SuspendLayout();
		((Control)ce0af834a86d4a32667002a2e1c9c4359).SuspendLayout();
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).BeginInit();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).SuspendLayout();
		((ISupportInitialize)c98dd8245994cd868d7cdfd180f7f9422).BeginInit();
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).SuspendLayout();
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).SuspendLayout();
		((Control)c98dd8245994cd868d7cdfd180f7f9422).SuspendLayout();
		((Control)c3a8094646f27dd51898bdb4dfaa78e09).SuspendLayout();
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).SuspendLayout();
		((ISupportInitialize)c2a161da002bb8cdd90af79c65bcd8c5f).BeginInit();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).SuspendLayout();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).SuspendLayout();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).SuspendLayout();
		((Control)cbbc887de9f5ea470255e15cc298c7942).SuspendLayout();
		((Control)c98d6867393e88ba8ec22c0c28b73b18d).SuspendLayout();
		((Control)cafd1491656d4be80c61872cf7780040d).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)cd5530af334f348c1867bbc6535f2ccff).Anchor = (AnchorStyles)9;
		((Control)cd5530af334f348c1867bbc6535f2ccff).Location = new Point(113, 281);
		((Control)cd5530af334f348c1867bbc6535f2ccff).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14592);
		((Control)cd5530af334f348c1867bbc6535f2ccff).Size = new Size(35, 23);
		((Control)cd5530af334f348c1867bbc6535f2ccff).TabIndex = 10;
		((Control)cd5530af334f348c1867bbc6535f2ccff).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14635);
		((ButtonBase)cd5530af334f348c1867bbc6535f2ccff).UseVisualStyleBackColor = true;
		((Control)cd5530af334f348c1867bbc6535f2ccff).Click += cf58e46b399715d8f1604adf24cb895e3;
		((Control)c283bbab44b3fca5d39367f132894644e).Anchor = (AnchorStyles)6;
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c07e860d38468b4c3820b72fd82b8c479);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)ca97c16bb25e579acbfca5f9ec5f38762);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c225aaa2c7205152650b3b8a11c5c00c3);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)ce3a976124811ba8f18adc6cb8899b0e8);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)ccd86f2a93b81505af97aa59a0c4f0545);
		((Control)c283bbab44b3fca5d39367f132894644e).Location = new Point(4, 248);
		((Control)c283bbab44b3fca5d39367f132894644e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14642);
		((Control)c283bbab44b3fca5d39367f132894644e).Size = new Size(194, 317);
		((Control)c283bbab44b3fca5d39367f132894644e).TabIndex = 1;
		c283bbab44b3fca5d39367f132894644e.TabStop = false;
		((Control)c283bbab44b3fca5d39367f132894644e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14661);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(6, 14);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(995);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(114, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 45;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14696);
		((Control)c07e860d38468b4c3820b72fd82b8c479).Location = new Point(7, 30);
		((Control)c07e860d38468b4c3820b72fd82b8c479).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14739);
		((Control)c07e860d38468b4c3820b72fd82b8c479).Size = new Size(181, 20);
		((Control)c07e860d38468b4c3820b72fd82b8c479).TabIndex = 0;
		((Control)c07e860d38468b4c3820b72fd82b8c479).DoubleClick += c5cc2a9913f91a63cd8f8f1e8d1cadd50;
		((Control)c07e860d38468b4c3820b72fd82b8c479).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c07e860d38468b4c3820b72fd82b8c479).Leave += ce965c126375cc16d84817400f647ea14;
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c345fb42ff93f6376eb2f0cb2c093e67e);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c8af24b3132c3f9bc521cb9cccc12a224);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)ce71e85e952218edc33bda5326c37ed93);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c789be2065ed12ebb629dcfca687809c5);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c602fc3992403e5cdad0409e1900aed07);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c1a3979b2807ce107cbb855fb8ff7202b);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c4f77bfbc101bbe9d822a90c9ec242f9b);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)cc931d55a79f75a3ad8eeff54cc492876);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Enabled = false;
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Location = new Point(7, 173);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14780);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Size = new Size(181, 138);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).TabIndex = 4;
		ca97c16bb25e579acbfca5f9ec5f38762.TabStop = false;
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14799);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Leave += c3be7ad6f4930b3f9a2d4e70f4fde2ad0;
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).Location = new Point(97, 93);
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14832);
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).Size = new Size(78, 38);
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).TabIndex = 7;
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14883);
		((ButtonBase)c345fb42ff93f6376eb2f0cb2c093e67e).UseVisualStyleBackColor = true;
		((Control)c345fb42ff93f6376eb2f0cb2c093e67e).Click += c6a2759991a28c75a4b14f98ba7461616;
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).AutoSize = true;
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).Location = new Point(7, 109);
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14916);
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).Size = new Size(69, 17);
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).TabIndex = 3;
		((Control)c8af24b3132c3f9bc521cb9cccc12a224).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5771);
		((ButtonBase)c8af24b3132c3f9bc521cb9cccc12a224).UseVisualStyleBackColor = true;
		c8af24b3132c3f9bc521cb9cccc12a224.CheckedChanged += ca1a5380ec45f35679d403f6bc392f959;
		((Control)ce71e85e952218edc33bda5326c37ed93).AutoSize = true;
		((Control)ce71e85e952218edc33bda5326c37ed93).Location = new Point(98, 69);
		((Control)ce71e85e952218edc33bda5326c37ed93).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14955);
		((Control)ce71e85e952218edc33bda5326c37ed93).Size = new Size(60, 17);
		((Control)ce71e85e952218edc33bda5326c37ed93).TabIndex = 6;
		((Control)ce71e85e952218edc33bda5326c37ed93).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5758);
		((ButtonBase)ce71e85e952218edc33bda5326c37ed93).UseVisualStyleBackColor = true;
		ce71e85e952218edc33bda5326c37ed93.CheckedChanged += c1b8d6f44ec1e60f1d989e8b70c960f86;
		((Control)c789be2065ed12ebb629dcfca687809c5).AutoSize = true;
		((Control)c789be2065ed12ebb629dcfca687809c5).Location = new Point(98, 44);
		((Control)c789be2065ed12ebb629dcfca687809c5).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14988);
		((Control)c789be2065ed12ebb629dcfca687809c5).Size = new Size(46, 17);
		((Control)c789be2065ed12ebb629dcfca687809c5).TabIndex = 5;
		((Control)c789be2065ed12ebb629dcfca687809c5).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5683);
		((ButtonBase)c789be2065ed12ebb629dcfca687809c5).UseVisualStyleBackColor = true;
		c789be2065ed12ebb629dcfca687809c5.CheckedChanged += ca1a5380ec45f35679d403f6bc392f959;
		((Control)c602fc3992403e5cdad0409e1900aed07).AutoSize = true;
		((Control)c602fc3992403e5cdad0409e1900aed07).Location = new Point(7, 79);
		((Control)c602fc3992403e5cdad0409e1900aed07).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15017);
		((Control)c602fc3992403e5cdad0409e1900aed07).Size = new Size(80, 17);
		((Control)c602fc3992403e5cdad0409e1900aed07).TabIndex = 2;
		((Control)c602fc3992403e5cdad0409e1900aed07).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15072);
		((ButtonBase)c602fc3992403e5cdad0409e1900aed07).UseVisualStyleBackColor = true;
		c602fc3992403e5cdad0409e1900aed07.CheckedChanged += ca1a5380ec45f35679d403f6bc392f959;
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).AutoSize = true;
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).Location = new Point(7, 49);
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15095);
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).Size = new Size(71, 17);
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).TabIndex = 1;
		((Control)c1a3979b2807ce107cbb855fb8ff7202b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15134);
		((ButtonBase)c1a3979b2807ce107cbb855fb8ff7202b).UseVisualStyleBackColor = true;
		c1a3979b2807ce107cbb855fb8ff7202b.CheckedChanged += ca1a5380ec45f35679d403f6bc392f959;
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).AutoSize = true;
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).Location = new Point(98, 19);
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15153);
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).Size = new Size(56, 17);
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).TabIndex = 4;
		((Control)c4f77bfbc101bbe9d822a90c9ec242f9b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15186);
		((ButtonBase)c4f77bfbc101bbe9d822a90c9ec242f9b).UseVisualStyleBackColor = true;
		c4f77bfbc101bbe9d822a90c9ec242f9b.CheckedChanged += ca1a5380ec45f35679d403f6bc392f959;
		((Control)cc931d55a79f75a3ad8eeff54cc492876).AutoSize = true;
		cc931d55a79f75a3ad8eeff54cc492876.Checked = true;
		((Control)cc931d55a79f75a3ad8eeff54cc492876).Location = new Point(7, 19);
		((Control)cc931d55a79f75a3ad8eeff54cc492876).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15199);
		((Control)cc931d55a79f75a3ad8eeff54cc492876).Size = new Size(51, 17);
		((Control)cc931d55a79f75a3ad8eeff54cc492876).TabIndex = 0;
		cc931d55a79f75a3ad8eeff54cc492876.TabStop = true;
		((Control)cc931d55a79f75a3ad8eeff54cc492876).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
		((ButtonBase)cc931d55a79f75a3ad8eeff54cc492876).UseVisualStyleBackColor = true;
		cc931d55a79f75a3ad8eeff54cc492876.CheckedChanged += c20841035a81f05c8ba9640811deaa1bd;
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).AutoSize = true;
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).Enabled = false;
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).Location = new Point(7, 53);
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15228);
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).Size = new Size(168, 17);
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).TabIndex = 1;
		((Control)c225aaa2c7205152650b3b8a11c5c00c3).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15257);
		((ButtonBase)c225aaa2c7205152650b3b8a11c5c00c3).UseVisualStyleBackColor = true;
		c225aaa2c7205152650b3b8a11c5c00c3.CheckedChanged += c72069955080f0b49a01145da2cff927b;
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Controls.Add((Control)(object)c8854d358ef39133e603ce658d3c732b9);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Controls.Add((Control)(object)c602cc87b31944701be94229b41e8bb82);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Location = new Point(7, 117);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15322);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Size = new Size(181, 56);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).TabIndex = 3;
		ce3a976124811ba8f18adc6cb8899b0e8.TabStop = false;
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15341);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).Leave += c754dba63f980058cc3e8dd216d2423e9;
		((Control)c8854d358ef39133e603ce658d3c732b9).Location = new Point(7, 33);
		((Control)c8854d358ef39133e603ce658d3c732b9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15378);
		((Control)c8854d358ef39133e603ce658d3c732b9).Size = new Size(166, 17);
		((Control)c8854d358ef39133e603ce658d3c732b9).TabIndex = 1;
		((Control)c8854d358ef39133e603ce658d3c732b9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15395);
		((ButtonBase)c8854d358ef39133e603ce658d3c732b9).UseVisualStyleBackColor = true;
		((Control)c602cc87b31944701be94229b41e8bb82).AutoSize = true;
		c602cc87b31944701be94229b41e8bb82.Checked = true;
		((Control)c602cc87b31944701be94229b41e8bb82).Location = new Point(7, 13);
		((Control)c602cc87b31944701be94229b41e8bb82).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15454);
		((Control)c602cc87b31944701be94229b41e8bb82).Size = new Size(97, 17);
		((Control)c602cc87b31944701be94229b41e8bb82).TabIndex = 0;
		c602cc87b31944701be94229b41e8bb82.TabStop = true;
		((Control)c602cc87b31944701be94229b41e8bb82).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15481);
		((ButtonBase)c602cc87b31944701be94229b41e8bb82).UseVisualStyleBackColor = true;
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).Controls.Add((Control)(object)c857dba7e8960ec53f0faacb2f0142d89);
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).Location = new Point(8, 71);
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15518);
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).Size = new Size(180, 42);
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).TabIndex = 2;
		ccd86f2a93b81505af97aa59a0c4f0545.TabStop = false;
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15547);
		((ListControl)c857dba7e8960ec53f0faacb2f0142d89).FormattingEnabled = true;
		((Control)c857dba7e8960ec53f0faacb2f0142d89).Location = new Point(7, 16);
		((Control)c857dba7e8960ec53f0faacb2f0142d89).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15574);
		((Control)c857dba7e8960ec53f0faacb2f0142d89).Size = new Size(167, 21);
		((Control)c857dba7e8960ec53f0faacb2f0142d89).TabIndex = 0;
		c857dba7e8960ec53f0faacb2f0142d89.SelectedIndexChanged += cffdc4e00965273e3ab62d58a4afb5899;
		((Control)tvActionsConditions).AllowDrop = true;
		((Control)tvActionsConditions).Anchor = (AnchorStyles)15;
		((Control)tvActionsConditions).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvActionsConditions.HideSelection = false;
		tvActionsConditions.HotTracking = true;
		tvActionsConditions.ImageIndex = 0;
		tvActionsConditions.ImageList = c04dcf0368a2156705fbbc1fedf6f193e;
		((Control)tvActionsConditions).Location = new Point(4, 20);
		((Control)tvActionsConditions).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15644);
		tvActionsConditions.SelectedImageIndex = 0;
		tvActionsConditions.ShowNodeToolTips = true;
		((Control)tvActionsConditions).Size = new Size(637, 222);
		((Control)tvActionsConditions).TabIndex = 0;
		tvActionsConditions.AfterSelect += c30e90c805842ce4651af61f353033dce;
		((Control)tvActionsConditions).DragDrop += c8f233cbe223d95f4d6ce268c0436d5ff;
		((Control)tvActionsConditions).DragOver += c6765c98cf5c0381b87714b921a078d31;
		((Control)tvActionsConditions).KeyDown += cb7f2e667f84948aa8b3810fe787cd071;
		((Control)tvActionsConditions).MouseDown += cdacb012587b0ace610fd6eefd327fa91;
		((Control)tvActionsConditions).MouseMove += c06f8f7d67d4cc846a066fee2e3b8fcaa;
		c04dcf0368a2156705fbbc1fedf6f193e.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15683));
		c04dcf0368a2156705fbbc1fedf6f193e.TransparentColor = Color.Transparent;
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15728));
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15749));
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15770));
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(3, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15795));
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(4, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15816));
		c04dcf0368a2156705fbbc1fedf6f193e.Images.SetKeyName(5, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15845));
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Anchor = (AnchorStyles)14;
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Controls.Add((Control)(object)cfdd28b747afbe52686772d0eed813027);
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Location = new Point(208, 248);
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15878);
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Size = new Size(434, 314);
		((Control)ce0af834a86d4a32667002a2e1c9c4359).TabIndex = 2;
		ce0af834a86d4a32667002a2e1c9c4359.TabStop = false;
		((Control)ce0af834a86d4a32667002a2e1c9c4359).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15909);
		cfdd28b747afbe52686772d0eed813027.Dock = (DockStyle)5;
		((Control)cfdd28b747afbe52686772d0eed813027).Location = new Point(3, 16);
		((Control)cfdd28b747afbe52686772d0eed813027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15938);
		cfdd28b747afbe52686772d0eed813027.Orientation = (Orientation)0;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)cca635a57d99b03a02717c239805e2524);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)cee63b5aaa73084c565be53403d6d78a5);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)c98dd8245994cd868d7cdfd180f7f9422);
		((Control)cfdd28b747afbe52686772d0eed813027).Size = new Size(428, 295);
		cfdd28b747afbe52686772d0eed813027.SplitterDistance = 42;
		((Control)cfdd28b747afbe52686772d0eed813027).TabIndex = 15;
		((Control)cca635a57d99b03a02717c239805e2524).Anchor = (AnchorStyles)13;
		((Control)cca635a57d99b03a02717c239805e2524).Location = new Point(97, 7);
		((Control)cca635a57d99b03a02717c239805e2524).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15969);
		((Control)cca635a57d99b03a02717c239805e2524).Size = new Size(518, 20);
		((Control)cca635a57d99b03a02717c239805e2524).TabIndex = 0;
		((Control)cca635a57d99b03a02717c239805e2524).DoubleClick += c5cc2a9913f91a63cd8f8f1e8d1cadd50;
		((Control)cca635a57d99b03a02717c239805e2524).Enter += c61f4a1cc3280e8604b56906412a018db;
		((Control)cca635a57d99b03a02717c239805e2524).Leave += cac1cea50638f4836e000e8aa95301a1b;
		((Control)cee63b5aaa73084c565be53403d6d78a5).AutoSize = true;
		((Control)cee63b5aaa73084c565be53403d6d78a5).Location = new Point(3, 10);
		((Control)cee63b5aaa73084c565be53403d6d78a5).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16002);
		((Control)cee63b5aaa73084c565be53403d6d78a5).Size = new Size(85, 13);
		((Control)cee63b5aaa73084c565be53403d6d78a5).TabIndex = 8;
		((Control)cee63b5aaa73084c565be53403d6d78a5).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16017);
		c98dd8245994cd868d7cdfd180f7f9422.BorderStyle = (BorderStyle)1;
		c98dd8245994cd868d7cdfd180f7f9422.Dock = (DockStyle)5;
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Location = new Point(0, 0);
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16048);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c1dfd66f09bc1eca582c72926f1f2451c);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c4861c86b27c29b83354ab24250603283);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c4e7f938e7e498f7339be7ccf18e84053);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cb14d51ac8530fe4463993959ce4a6d75);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cdcc543dc83800ba1d24d764066e3005e);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cae81a39c04741469eb9b7f14cd68b352);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)c428ebf94dee726b1e31b460540bbbc1f);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cbConditionStep1);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)ce461a44e2020b57573abdc365294fa10);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)c1ff7ab8162850bc386a55daadfc620be);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)c57eeb71d9b376ae36eb2d1b058003c64);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cb110e655831717067e74b6e01e57f651);
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Size = new Size(428, 249);
		c98dd8245994cd868d7cdfd180f7f9422.SplitterDistance = 155;
		((Control)c98dd8245994cd868d7cdfd180f7f9422).TabIndex = 15;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(1, 0);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(46, 11);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 3;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16079);
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).Location = new Point(77, 219);
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16094);
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).Size = new Size(44, 23);
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).TabIndex = 3;
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16101);
		((ButtonBase)c1dfd66f09bc1eca582c72926f1f2451c).UseVisualStyleBackColor = true;
		((Control)c1dfd66f09bc1eca582c72926f1f2451c).Click += cb795342ba98121b7f10c0795fcf29ec8;
		((Control)c4861c86b27c29b83354ab24250603283).Location = new Point(31, 219);
		((Control)c4861c86b27c29b83354ab24250603283).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16106);
		((Control)c4861c86b27c29b83354ab24250603283).Size = new Size(42, 23);
		((Control)c4861c86b27c29b83354ab24250603283).TabIndex = 2;
		((Control)c4861c86b27c29b83354ab24250603283).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16115);
		((ButtonBase)c4861c86b27c29b83354ab24250603283).UseVisualStyleBackColor = true;
		((Control)c4861c86b27c29b83354ab24250603283).Click += c3af9bf9be84c0a38c1e2fbcebb2f738c;
		((Control)c4e7f938e7e498f7339be7ccf18e84053).Anchor = (AnchorStyles)13;
		((Control)c4e7f938e7e498f7339be7ccf18e84053).ContextMenuStrip = c3a8094646f27dd51898bdb4dfaa78e09;
		((ListControl)c4e7f938e7e498f7339be7ccf18e84053).FormattingEnabled = true;
		((Control)c4e7f938e7e498f7339be7ccf18e84053).Location = new Point(3, 15);
		((Control)c4e7f938e7e498f7339be7ccf18e84053).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16122);
		((Control)c4e7f938e7e498f7339be7ccf18e84053).Size = new Size(147, 199);
		((Control)c4e7f938e7e498f7339be7ccf18e84053).TabIndex = 1;
		c4e7f938e7e498f7339be7ccf18e84053.SelectedIndexChanged += c4d89de75bfe6d52cb05f3fdc6ef40c09;
		((ToolStrip)c3a8094646f27dd51898bdb4dfaa78e09).Items.AddRange(new ToolStripItem[3]
		{
			(ToolStripItem)c9a160b3483ca491f08d14af12abc7625,
			(ToolStripItem)c7184c85f3188ef6bb4961cf9c847fbfa,
			(ToolStripItem)c944661025bdf591000e92f861eadb21b
		});
		((Control)c3a8094646f27dd51898bdb4dfaa78e09).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16139);
		((Control)c3a8094646f27dd51898bdb4dfaa78e09).Size = new Size(182, 70);
		((ToolStripItem)c9a160b3483ca491f08d14af12abc7625).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16178);
		((ToolStripItem)c9a160b3483ca491f08d14af12abc7625).Size = new Size(181, 22);
		((ToolStripItem)c9a160b3483ca491f08d14af12abc7625).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16235);
		((ToolStripItem)c9a160b3483ca491f08d14af12abc7625).Click += c3af9bf9be84c0a38c1e2fbcebb2f738c;
		((ToolStripItem)c7184c85f3188ef6bb4961cf9c847fbfa).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16266);
		((ToolStripItem)c7184c85f3188ef6bb4961cf9c847fbfa).Size = new Size(181, 22);
		((ToolStripItem)c7184c85f3188ef6bb4961cf9c847fbfa).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16321);
		((ToolStripItem)c7184c85f3188ef6bb4961cf9c847fbfa).Click += cb795342ba98121b7f10c0795fcf29ec8;
		((ToolStripItem)c944661025bdf591000e92f861eadb21b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16350);
		((ToolStripItem)c944661025bdf591000e92f861eadb21b).Size = new Size(181, 22);
		((ToolStripItem)c944661025bdf591000e92f861eadb21b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16421);
		((ToolStripItem)c944661025bdf591000e92f861eadb21b).Click += c5837264648ff03146ea3cba9217d7031;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Anchor = (AnchorStyles)13;
		((ListControl)cb14d51ac8530fe4463993959ce4a6d75).FormattingEnabled = true;
		cb14d51ac8530fe4463993959ce4a6d75.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Location = new Point(3, 133);
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16743);
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Size = new Size(260, 21);
		cb14d51ac8530fe4463993959ce4a6d75.Sorted = true;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).TabIndex = 6;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Visible = false;
		cb14d51ac8530fe4463993959ce4a6d75.SelectedIndexChanged += cfedc4f9e023fac8c77e0a73a51803621;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)cb14d51ac8530fe4463993959ce4a6d75).Leave += c8934b7d402770ca156a6b328abdbe716;
		((Control)cdcc543dc83800ba1d24d764066e3005e).AutoSize = true;
		((Control)cdcc543dc83800ba1d24d764066e3005e).Location = new Point(3, 61);
		((Control)cdcc543dc83800ba1d24d764066e3005e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16776);
		((Control)cdcc543dc83800ba1d24d764066e3005e).Size = new Size(38, 13);
		((Control)cdcc543dc83800ba1d24d764066e3005e).TabIndex = 5;
		((Control)cdcc543dc83800ba1d24d764066e3005e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16811);
		((Control)cdcc543dc83800ba1d24d764066e3005e).Visible = false;
		((Control)cae81a39c04741469eb9b7f14cd68b352).AutoSize = true;
		((Control)cae81a39c04741469eb9b7f14cd68b352).Location = new Point(3, 183);
		((Control)cae81a39c04741469eb9b7f14cd68b352).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16824);
		((Control)cae81a39c04741469eb9b7f14cd68b352).Size = new Size(38, 13);
		((Control)cae81a39c04741469eb9b7f14cd68b352).TabIndex = 14;
		((Control)cae81a39c04741469eb9b7f14cd68b352).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16859);
		((Control)cae81a39c04741469eb9b7f14cd68b352).Visible = false;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Anchor = (AnchorStyles)13;
		((ListControl)c428ebf94dee726b1e31b460540bbbc1f).FormattingEnabled = true;
		c428ebf94dee726b1e31b460540bbbc1f.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Location = new Point(3, 78);
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16872);
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Size = new Size(260, 21);
		c428ebf94dee726b1e31b460540bbbc1f.Sorted = true;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).TabIndex = 5;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Visible = false;
		c428ebf94dee726b1e31b460540bbbc1f.SelectedIndexChanged += c5240ae5e92313584a5051ae9f628ea81;
		c428ebf94dee726b1e31b460540bbbc1f.TextUpdate += c5240ae5e92313584a5051ae9f628ea81;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c428ebf94dee726b1e31b460540bbbc1f).Leave += cd945a70e7b257dcbab3e68919917d667;
		((Control)cbConditionStep1).Anchor = (AnchorStyles)13;
		cbConditionStep1.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)cbConditionStep1).FormattingEnabled = true;
		cbConditionStep1.Items.AddRange(new object[6]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16905),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16950),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16989),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17014),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17047),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17076)
		});
		((Control)cbConditionStep1).Location = new Point(3, 25);
		((Control)cbConditionStep1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17115);
		((Control)cbConditionStep1).Size = new Size(260, 21);
		((Control)cbConditionStep1).TabIndex = 4;
		cbConditionStep1.SelectedIndexChanged += c9525f87619a24b52bdeb6362d08a5560;
		((Control)cbConditionStep1).Leave += c968e06d031374e326a9af015b02f7b7b;
		((Control)ce461a44e2020b57573abdc365294fa10).Anchor = (AnchorStyles)13;
		((Control)ce461a44e2020b57573abdc365294fa10).Location = new Point(3, 199);
		((Control)ce461a44e2020b57573abdc365294fa10).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17148);
		((Control)ce461a44e2020b57573abdc365294fa10).Size = new Size(260, 20);
		((Control)ce461a44e2020b57573abdc365294fa10).TabIndex = 7;
		((Control)ce461a44e2020b57573abdc365294fa10).Visible = false;
		((Control)ce461a44e2020b57573abdc365294fa10).DoubleClick += c5cc2a9913f91a63cd8f8f1e8d1cadd50;
		((Control)ce461a44e2020b57573abdc365294fa10).Enter += c61f4a1cc3280e8604b56906412a018db;
		((Control)ce461a44e2020b57573abdc365294fa10).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)ce461a44e2020b57573abdc365294fa10).Leave += c7350437f8d195123268cc15c01f24dc0;
		((Control)c1ff7ab8162850bc386a55daadfc620be).AutoSize = true;
		((Control)c1ff7ab8162850bc386a55daadfc620be).Location = new Point(3, 116);
		((Control)c1ff7ab8162850bc386a55daadfc620be).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17183);
		((Control)c1ff7ab8162850bc386a55daadfc620be).Size = new Size(38, 13);
		((Control)c1ff7ab8162850bc386a55daadfc620be).TabIndex = 13;
		((Control)c1ff7ab8162850bc386a55daadfc620be).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17218);
		((Control)c1ff7ab8162850bc386a55daadfc620be).Visible = false;
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).AutoSize = true;
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).Location = new Point(3, 8);
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17231);
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).Size = new Size(38, 13);
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).TabIndex = 3;
		((Control)c57eeb71d9b376ae36eb2d1b058003c64).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17266);
		((Control)cb110e655831717067e74b6e01e57f651).Anchor = (AnchorStyles)13;
		((ListControl)cb110e655831717067e74b6e01e57f651).FormattingEnabled = true;
		cb110e655831717067e74b6e01e57f651.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)cb110e655831717067e74b6e01e57f651).Location = new Point(4, 200);
		((Control)cb110e655831717067e74b6e01e57f651).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17279);
		((Control)cb110e655831717067e74b6e01e57f651).Size = new Size(260, 21);
		cb110e655831717067e74b6e01e57f651.Sorted = true;
		((Control)cb110e655831717067e74b6e01e57f651).TabIndex = 15;
		((Control)cb110e655831717067e74b6e01e57f651).Visible = false;
		((Control)cb110e655831717067e74b6e01e57f651).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)cb110e655831717067e74b6e01e57f651).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)cb110e655831717067e74b6e01e57f651).Leave += cfb3fc7b44bdcf977af7a8ed78b3b63a7;
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Anchor = (AnchorStyles)14;
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Controls.Add((Control)(object)c2a161da002bb8cdd90af79c65bcd8c5f);
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Location = new Point(207, 248);
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17312);
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Size = new Size(434, 315);
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).TabIndex = 5;
		c1844ff8515e2e1bb16edc45f8622b8bb.TabStop = false;
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17333);
		c2a161da002bb8cdd90af79c65bcd8c5f.Dock = (DockStyle)5;
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Location = new Point(3, 16);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17358);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c745b25e1019649e3ccbbb38d595446ae);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c2332b911806c4b9e235af5bfdc94f97d);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c43a2d1ff6560b2051d7cf8dfa9309b98);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c0409bb493de758becfc185d928829028);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c86cb42b5f2066de273d56833f0cfcf54);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c962ce47954ab1816402cab8d8ab59271);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c85ec63372a2560632b32285c85e56156);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)cb515fc292bfc8c27f12c9a825983cfd4);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)cbCommandStep1);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c4743068129d058c0158648be0270ef9d);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c1ae51f04467ab9b62260d376b5dc5cba);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c4053b9b7d85ea311db9e2c9a464192fb);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c7366ee5636b59024f2e8b9b7ba28fcec);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)c3834cad3fa310a2ecdf84f4b34e287f5);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)cba88c834a279c3e211d684cb838406e9);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)c77967f9eb311ee3d9905b43b5337f9ad);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)c7fc17de416b5bf7ec20d075233fc568b);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)c0483f8f42ff39d5f74e69515eb6ba2f0);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Size = new Size(428, 296);
		c2a161da002bb8cdd90af79c65bcd8c5f.SplitterDistance = 270;
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).TabIndex = 27;
		((Control)c745b25e1019649e3ccbbb38d595446ae).Anchor = (AnchorStyles)10;
		((Control)c745b25e1019649e3ccbbb38d595446ae).Location = new Point(244, 268);
		((Control)c745b25e1019649e3ccbbb38d595446ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17389);
		((Control)c745b25e1019649e3ccbbb38d595446ae).Size = new Size(21, 23);
		((Control)c745b25e1019649e3ccbbb38d595446ae).TabIndex = 12;
		((Control)c745b25e1019649e3ccbbb38d595446ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17404);
		((ButtonBase)c745b25e1019649e3ccbbb38d595446ae).UseVisualStyleBackColor = true;
		((Control)c745b25e1019649e3ccbbb38d595446ae).Click += c060792b476a87a1b6c0bdb7a33d567b0;
		((Control)c745b25e1019649e3ccbbb38d595446ae).MouseHover += c1941439fb25f381b46d3267873b5d71b;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Anchor = (AnchorStyles)13;
		((ListControl)c2332b911806c4b9e235af5bfdc94f97d).FormattingEnabled = true;
		c2332b911806c4b9e235af5bfdc94f97d.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Location = new Point(0, 168);
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17407);
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Size = new Size(267, 21);
		c2332b911806c4b9e235af5bfdc94f97d.Sorted = true;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).TabIndex = 10;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Visible = false;
		c2332b911806c4b9e235af5bfdc94f97d.SelectedIndexChanged += cb3e98f01ab302041452d7a8dbe1a83b5;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c2332b911806c4b9e235af5bfdc94f97d).Leave += cf473f222f97b40ce274d65e3f12994f0;
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).AutoSize = true;
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Location = new Point(-2, 215);
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17436);
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Size = new Size(38, 13);
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).TabIndex = 18;
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16859);
		((Control)c43a2d1ff6560b2051d7cf8dfa9309b98).Visible = false;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Anchor = (AnchorStyles)13;
		((ListControl)c1ae51f04467ab9b62260d376b5dc5cba).FormattingEnabled = true;
		c1ae51f04467ab9b62260d376b5dc5cba.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Location = new Point(1, 233);
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17453);
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Size = new Size(266, 21);
		c1ae51f04467ab9b62260d376b5dc5cba.Sorted = true;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).TabIndex = 11;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Visible = false;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c1ae51f04467ab9b62260d376b5dc5cba).Leave += cc08f08633ff1da0837b78c41d7285c35;
		((Control)c0409bb493de758becfc185d928829028).AutoSize = true;
		((Control)c0409bb493de758becfc185d928829028).Location = new Point(-3, 70);
		((Control)c0409bb493de758becfc185d928829028).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17482);
		((Control)c0409bb493de758becfc185d928829028).Size = new Size(38, 13);
		((Control)c0409bb493de758becfc185d928829028).TabIndex = 5;
		((Control)c0409bb493de758becfc185d928829028).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16811);
		((Control)c0409bb493de758becfc185d928829028).Visible = false;
		((Control)c86cb42b5f2066de273d56833f0cfcf54).AutoSize = true;
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Location = new Point(-2, 116);
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17513);
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Size = new Size(63, 13);
		((Control)c86cb42b5f2066de273d56833f0cfcf54).TabIndex = 14;
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17542);
		((Control)c86cb42b5f2066de273d56833f0cfcf54).Visible = false;
		((Control)c962ce47954ab1816402cab8d8ab59271).Anchor = (AnchorStyles)13;
		((ListControl)c962ce47954ab1816402cab8d8ab59271).FormattingEnabled = true;
		c962ce47954ab1816402cab8d8ab59271.Items.AddRange(new object[8]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)c962ce47954ab1816402cab8d8ab59271).Location = new Point(-1, 87);
		((Control)c962ce47954ab1816402cab8d8ab59271).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17567);
		((Control)c962ce47954ab1816402cab8d8ab59271).Size = new Size(266, 21);
		c962ce47954ab1816402cab8d8ab59271.Sorted = true;
		((Control)c962ce47954ab1816402cab8d8ab59271).TabIndex = 8;
		((Control)c962ce47954ab1816402cab8d8ab59271).Visible = false;
		c962ce47954ab1816402cab8d8ab59271.SelectedIndexChanged += caf9388bdcca545ad2b074bb1de5ca97b;
		((Control)c962ce47954ab1816402cab8d8ab59271).Click += ce27061b04c48dba77b5c3eb990add15d;
		((Control)c962ce47954ab1816402cab8d8ab59271).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c962ce47954ab1816402cab8d8ab59271).Leave += c0cffdd760696ebfce4d68790e2a83844;
		((Control)c85ec63372a2560632b32285c85e56156).AutoSize = true;
		((Control)c85ec63372a2560632b32285c85e56156).Location = new Point(-2, 151);
		((Control)c85ec63372a2560632b32285c85e56156).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17596);
		((Control)c85ec63372a2560632b32285c85e56156).Size = new Size(38, 13);
		((Control)c85ec63372a2560632b32285c85e56156).TabIndex = 16;
		((Control)c85ec63372a2560632b32285c85e56156).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17218);
		((Control)c85ec63372a2560632b32285c85e56156).Visible = false;
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).AutoSize = true;
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).Location = new Point(-2, 5);
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17627);
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).Size = new Size(38, 13);
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).TabIndex = 3;
		((Control)cb515fc292bfc8c27f12c9a825983cfd4).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17266);
		((Control)cbCommandStep1).Anchor = (AnchorStyles)13;
		cbCommandStep1.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)cbCommandStep1).FormattingEnabled = true;
		cbCommandStep1.Items.AddRange(new object[16]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17642),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17691),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17722),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16487),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16532),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16567),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17765),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17842),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17917),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16608),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17984),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16653),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18023),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16718)
		});
		((Control)cbCommandStep1).Location = new Point(0, 26);
		((Control)cbCommandStep1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18056);
		((Control)cbCommandStep1).Size = new Size(267, 21);
		((Control)cbCommandStep1).TabIndex = 7;
		cbCommandStep1.SelectedIndexChanged += c2c95007c30beadab9f3e3e2216adc4a7;
		((Control)cbCommandStep1).Leave += c9c9b3b1dacae3d22d1860c955fd1e1b5;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Anchor = (AnchorStyles)13;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Location = new Point(1, 232);
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18085);
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Size = new Size(267, 20);
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).TabIndex = 10;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Visible = false;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).DoubleClick += c5cc2a9913f91a63cd8f8f1e8d1cadd50;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Enter += c61f4a1cc3280e8604b56906412a018db;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c4053b9b7d85ea311db9e2c9a464192fb).Leave += cddc1ea294279bcdb05adc9c1a6e727ec;
		((Control)c4743068129d058c0158648be0270ef9d).Anchor = (AnchorStyles)13;
		c4743068129d058c0158648be0270ef9d.HideSelection = false;
		((Control)c4743068129d058c0158648be0270ef9d).Location = new Point(0, 20);
		((Control)c4743068129d058c0158648be0270ef9d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18102);
		((Control)c4743068129d058c0158648be0270ef9d).Size = new Size(267, 55);
		((Control)c4743068129d058c0158648be0270ef9d).TabIndex = 6;
		((Control)c4743068129d058c0158648be0270ef9d).Visible = false;
		c4743068129d058c0158648be0270ef9d.AfterSelect += cefacf560f93e949601c1977bee8551c0;
		((Control)c4743068129d058c0158648be0270ef9d).Enter += c572a87c04d90f537c2aff1f1ede42143;
		((Control)c4743068129d058c0158648be0270ef9d).Leave += c71f86529f09e31e52be9aa687567576d;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Anchor = (AnchorStyles)13;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Location = new Point(0, 134);
		((TextBoxBase)c7366ee5636b59024f2e8b9b7ba28fcec).Multiline = true;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18123);
		c7366ee5636b59024f2e8b9b7ba28fcec.ScrollBars = (ScrollBars)3;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Size = new Size(267, 128);
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).TabIndex = 9;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Visible = false;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).TextChanged += caebdb7abd181397ed857770c2d66faad;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).DoubleClick += c5cc2a9913f91a63cd8f8f1e8d1cadd50;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Enter += c9c904811161e9d2ffac7cee9283aaa20;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).KeyPress += c66fe0c92881d31048880fc7f060cc864;
		((Control)c7366ee5636b59024f2e8b9b7ba28fcec).Leave += cd31d74df2dacbbda6ae8269f0fca27f9;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Anchor = (AnchorStyles)2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(105, 267);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(254);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(45, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 17;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18152);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).AllowDrop = true;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Anchor = (AnchorStyles)15;
		((ListControl)c3834cad3fa310a2ecdf84f4b34e287f5).FormattingEnabled = true;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Location = new Point(4, 20);
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14470);
		c3834cad3fa310a2ecdf84f4b34e287f5.SelectionMode = (SelectionMode)3;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Size = new Size(150, 238);
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).TabIndex = 13;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).Visible = false;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).DragDrop += cfe80ddd6816d9b09a7250ef65e23a439;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).DragOver += c4dd9a51648843df150a95836bd898122;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).MouseDown += c59535723c41b6efaf3adcb12666a4ac4;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).MouseMove += c9bb9b39786d1e8a5518508d90e386976;
		((Control)c3834cad3fa310a2ecdf84f4b34e287f5).MouseUp += c846b16fceea38788e816341268ce6d1f;
		((Control)cba88c834a279c3e211d684cb838406e9).AutoSize = true;
		((Control)cba88c834a279c3e211d684cb838406e9).Location = new Point(3, 6);
		((Control)cba88c834a279c3e211d684cb838406e9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18165);
		((Control)cba88c834a279c3e211d684cb838406e9).Size = new Size(86, 13);
		((Control)cba88c834a279c3e211d684cb838406e9).TabIndex = 21;
		((Control)cba88c834a279c3e211d684cb838406e9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18198);
		((Control)cba88c834a279c3e211d684cb838406e9).Visible = false;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Anchor = (AnchorStyles)2;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Location = new Point(37, 267);
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18229);
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Size = new Size(35, 23);
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).TabIndex = 15;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18260);
		((ButtonBase)c77967f9eb311ee3d9905b43b5337f9ad).UseVisualStyleBackColor = true;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Visible = false;
		((Control)c77967f9eb311ee3d9905b43b5337f9ad).Click += c66d5436ed2d607fbbd3c77901c90b372;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Anchor = (AnchorStyles)2;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Location = new Point(4, 267);
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18267);
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Size = new Size(34, 23);
		((Control)c7fc17de416b5bf7ec20d075233fc568b).TabIndex = 14;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8624);
		((ButtonBase)c7fc17de416b5bf7ec20d075233fc568b).UseVisualStyleBackColor = true;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Visible = false;
		((Control)c7fc17de416b5bf7ec20d075233fc568b).Click += c4174d1b058f63b1956e3f161fc3dbada;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Anchor = (AnchorStyles)2;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Location = new Point(71, 267);
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18292);
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Size = new Size(35, 23);
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).TabIndex = 16;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14635);
		((ButtonBase)c0483f8f42ff39d5f74e69515eb6ba2f0).UseVisualStyleBackColor = true;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Visible = false;
		((Control)c0483f8f42ff39d5f74e69515eb6ba2f0).Click += c26c3611ef95c21783f5f8291e9bea272;
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).AutoSize = true;
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).Location = new Point(3, 4);
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18323);
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).Size = new Size(118, 13);
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).TabIndex = 42;
		((Control)ca682b8c5c7d2bfaac844245d6ad7a15d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18338);
		((Control)c30a1afe18fa8ade4415ebdf1fe821777).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18385);
		((Control)c30a1afe18fa8ade4415ebdf1fe821777).Size = new Size(61, 4);
		((ToolStrip)cbbc887de9f5ea470255e15cc298c7942).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)cd5960a6d819462b79433c8fb6bcbc7c8,
			(ToolStripItem)c218905ada22e5e6f0335e6dbf5db6b9c
		});
		((Control)cbbc887de9f5ea470255e15cc298c7942).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18424);
		((Control)cbbc887de9f5ea470255e15cc298c7942).Size = new Size(167, 70);
		((ToolStripItem)cd5960a6d819462b79433c8fb6bcbc7c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18457);
		((ToolStripItem)cd5960a6d819462b79433c8fb6bcbc7c8).Size = new Size(167, 22);
		((ToolStripItem)cd5960a6d819462b79433c8fb6bcbc7c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18512);
		((ToolStripItem)cd5960a6d819462b79433c8fb6bcbc7c8).Click += c998840448a951a77b88579668615a934;
		((ToolStripItem)c218905ada22e5e6f0335e6dbf5db6b9c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18535);
		((ToolStripItem)c218905ada22e5e6f0335e6dbf5db6b9c).Size = new Size(167, 22);
		((ToolStripItem)c218905ada22e5e6f0335e6dbf5db6b9c).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231);
		((ToolStripItem)c218905ada22e5e6f0335e6dbf5db6b9c).Click += cd05c561cba1614916c4a1d8f8cdee891;
		((ToolStrip)c98d6867393e88ba8ec22c0c28b73b18d).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)c27df608f4ca3131ea673455fe08bc608,
			(ToolStripItem)ce55fd3799a0de16dd3b2992bce9aad39
		});
		((Control)c98d6867393e88ba8ec22c0c28b73b18d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18596);
		((Control)c98d6867393e88ba8ec22c0c28b73b18d).Size = new Size(168, 48);
		((ToolStripItem)c27df608f4ca3131ea673455fe08bc608).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18629);
		((ToolStripItem)c27df608f4ca3131ea673455fe08bc608).Size = new Size(167, 22);
		((ToolStripItem)c27df608f4ca3131ea673455fe08bc608).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18512);
		((ToolStripItem)c27df608f4ca3131ea673455fe08bc608).Click += cd7e036f3d88c3afef58cf1d8edf2c3d9;
		((ToolStripItem)ce55fd3799a0de16dd3b2992bce9aad39).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18686);
		((ToolStripItem)ce55fd3799a0de16dd3b2992bce9aad39).Size = new Size(167, 22);
		((ToolStripItem)ce55fd3799a0de16dd3b2992bce9aad39).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2231);
		((Control)cafd1491656d4be80c61872cf7780040d).Anchor = (AnchorStyles)6;
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)cecee52f098b12876894cea6eddb9401d);
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)c89c23d9240530bb50613c4c2d81fbaad);
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)cd5530af334f348c1867bbc6535f2ccff);
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)cd8c2e9bd4cb7b2a770566b2f66754b3b);
		((Control)cafd1491656d4be80c61872cf7780040d).Controls.Add((Control)(object)cbe61056f04fc0861514479244d36e741);
		((Control)cafd1491656d4be80c61872cf7780040d).Location = new Point(204, 248);
		((Control)cafd1491656d4be80c61872cf7780040d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18749);
		((Control)cafd1491656d4be80c61872cf7780040d).Size = new Size(154, 310);
		((Control)cafd1491656d4be80c61872cf7780040d).TabIndex = 5;
		cafd1491656d4be80c61872cf7780040d.TabStop = false;
		((Control)cafd1491656d4be80c61872cf7780040d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18780);
		((Control)cecee52f098b12876894cea6eddb9401d).Anchor = (AnchorStyles)13;
		((Control)cecee52f098b12876894cea6eddb9401d).Location = new Point(5, 30);
		((Control)cecee52f098b12876894cea6eddb9401d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18809);
		((Control)cecee52f098b12876894cea6eddb9401d).Size = new Size(143, 20);
		((Control)cecee52f098b12876894cea6eddb9401d).TabIndex = 6;
		((Control)cecee52f098b12876894cea6eddb9401d).Enter += c61f4a1cc3280e8604b56906412a018db;
		((Control)cecee52f098b12876894cea6eddb9401d).KeyDown += cd0fe0ff1c6f563cd312050269e1750cf;
		((Control)cecee52f098b12876894cea6eddb9401d).Leave += c0e1c8d982fa307dae7c7cb2e885716b3;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(6, 14);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1050);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(30, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 60;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18848);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Click += cf6e18d491ff9efbfc316a9006da7ecdf;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Anchor = (AnchorStyles)9;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Location = new Point(59, 281);
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18861);
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Size = new Size(35, 23);
		((Control)c89c23d9240530bb50613c4c2d81fbaad).TabIndex = 9;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18260);
		((ButtonBase)c89c23d9240530bb50613c4c2d81fbaad).UseVisualStyleBackColor = true;
		((Control)c89c23d9240530bb50613c4c2d81fbaad).Click += c055b4f9350ecf550bbdfdc8183550d2b;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Anchor = (AnchorStyles)9;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Location = new Point(5, 281);
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18904);
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Size = new Size(35, 23);
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).TabIndex = 8;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8624);
		((ButtonBase)cd8c2e9bd4cb7b2a770566b2f66754b3b).UseVisualStyleBackColor = true;
		((Control)cd8c2e9bd4cb7b2a770566b2f66754b3b).Click += ca2854c0e204333325680d57aca8854ca;
		((Control)cbe61056f04fc0861514479244d36e741).AllowDrop = true;
		((Control)cbe61056f04fc0861514479244d36e741).Anchor = (AnchorStyles)11;
		((ListControl)cbe61056f04fc0861514479244d36e741).FormattingEnabled = true;
		((Control)cbe61056f04fc0861514479244d36e741).Location = new Point(6, 57);
		((Control)cbe61056f04fc0861514479244d36e741).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14427);
		cbe61056f04fc0861514479244d36e741.SelectionMode = (SelectionMode)3;
		((Control)cbe61056f04fc0861514479244d36e741).Size = new Size(142, 212);
		((Control)cbe61056f04fc0861514479244d36e741).TabIndex = 7;
		((Control)cbe61056f04fc0861514479244d36e741).DragDrop += c2f7761ae251e25a553c22ed7ffb1e135;
		((Control)cbe61056f04fc0861514479244d36e741).DragOver += ce931c6a7d9f3b19edcf779e866e6c5f1;
		((Control)cbe61056f04fc0861514479244d36e741).MouseDown += c3f138fb1e61dc12c8b4d8cb2f696d886;
		((Control)cbe61056f04fc0861514479244d36e741).MouseMove += cd788b973e5976cd98f99d9a2b365af5a;
		((Control)cbe61056f04fc0861514479244d36e741).MouseUp += cd547d27a1546bf39f0dee4d03bab53e9;
		c1ef940cdb8be768145bbb7ae47e0f539.IgnoreXml = false;
		c1ef940cdb8be768145bbb7ae47e0f539.TextBox = null;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)tvActionsConditions);
		((Control)this).Controls.Add((Control)(object)c283bbab44b3fca5d39367f132894644e);
		((Control)this).Controls.Add((Control)(object)ca682b8c5c7d2bfaac844245d6ad7a15d);
		((Control)this).Controls.Add((Control)(object)cafd1491656d4be80c61872cf7780040d);
		((Control)this).Controls.Add((Control)(object)c1844ff8515e2e1bb16edc45f8622b8bb);
		((Control)this).Controls.Add((Control)(object)ce0af834a86d4a32667002a2e1c9c4359);
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(18941);
		((Control)this).Size = new Size(650, 568);
		((Control)c283bbab44b3fca5d39367f132894644e).ResumeLayout(false);
		((Control)c283bbab44b3fca5d39367f132894644e).PerformLayout();
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).ResumeLayout(false);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).PerformLayout();
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).ResumeLayout(false);
		((Control)ce3a976124811ba8f18adc6cb8899b0e8).PerformLayout();
		((Control)ccd86f2a93b81505af97aa59a0c4f0545).ResumeLayout(false);
		((Control)ce0af834a86d4a32667002a2e1c9c4359).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).PerformLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).ResumeLayout(false);
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).EndInit();
		((Control)cfdd28b747afbe52686772d0eed813027).ResumeLayout(false);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).ResumeLayout(false);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).ResumeLayout(false);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).PerformLayout();
		((ISupportInitialize)c98dd8245994cd868d7cdfd180f7f9422).EndInit();
		((Control)c98dd8245994cd868d7cdfd180f7f9422).ResumeLayout(false);
		((Control)c3a8094646f27dd51898bdb4dfaa78e09).ResumeLayout(false);
		((Control)c1844ff8515e2e1bb16edc45f8622b8bb).ResumeLayout(false);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).ResumeLayout(false);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).PerformLayout();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).ResumeLayout(false);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).PerformLayout();
		((ISupportInitialize)c2a161da002bb8cdd90af79c65bcd8c5f).EndInit();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).ResumeLayout(false);
		((Control)cbbc887de9f5ea470255e15cc298c7942).ResumeLayout(false);
		((Control)c98d6867393e88ba8ec22c0c28b73b18d).ResumeLayout(false);
		((Control)cafd1491656d4be80c61872cf7780040d).ResumeLayout(false);
		((Control)cafd1491656d4be80c61872cf7780040d).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
