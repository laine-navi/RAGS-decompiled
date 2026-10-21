using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Rags;

public class ActionControl : UserControl
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

	private DateTime m_a = DateTime.Now;

	private ComboBox m_b;

	private object m_c;

	public static Format ActionFormat = DataFormats.GetFormat("RagsAction");

	public static Format ConditonFormat = DataFormats.GetFormat("RagsCondition");

	public static Format CommandFormat = DataFormats.GetFormat("RagsCommand");

	private bool m_d;

	private Game m_e;

	private PageType m_f;

	private string m_g = string.Empty;

	private bool m_h;

	private bool m_i;

	private ArrayList m_j;

	private IContainer m_k;

	private GroupBox m_l;

	private GroupBox m_m;

	private RadioButton m_n;

	private RadioButton m_o;

	private GroupBox m_p;

	private RadioButton m_q;

	private RadioButton m_r;

	private RadioButton m_s;

	private RadioButton m_t;

	private RadioButton m_u;

	private CheckBox m_v;

	public TreeView tvActionsConditions;

	private GroupBox m_w;

	private Label m_x;

	private Label m_y;

	private TextBox m_z;

	private TextBox m_aa;

	private Label m_ab;

	private ComboBox m_ac;

	private Label m_ad;

	private ComboBox m_ae;

	private Label m_af;

	public ComboBox cbConditionStep1;

	private GroupBox m_ag;

	private TextBox m_ah;

	private Label m_ai;

	private Label m_aj;

	private Label m_ak;

	private ComboBox m_al;

	private Label m_am;

	private ComboBox m_an;

	private Label m_ao;

	public ComboBox cbCommandStep1;

	private TextBox m_ap;

	private Label m_aq;

	private ContextMenuStrip m_ar;

	private ContextMenuStrip m_as;

	private ToolStripMenuItem m_at;

	private ToolStripMenuItem m_au;

	private ContextMenuStrip m_av;

	private ToolStripMenuItem m_aw;

	private ToolStripMenuItem m_ax;

	private ImageList m_ay;

	private SplitContainer m_az;

	private SplitContainer m_a0;

	private Button m_a1;

	private ListBox m_a2;

	private Button m_a3;

	private Label a4;

	private ContextMenuStrip a5;

	private ToolStripMenuItem a6;

	private ToolStripMenuItem a7;

	private ToolStripMenuItem a8;

	private Label a9;

	private ListBox ba;

	private Button bb;

	private Button bc;

	private GroupBox bd;

	private Button be;

	private ListBox bf;

	private RadioButton bg;

	private ComboBox bh;

	private ComboBox bi;

	private Button bj;

	private Button bk;

	private RadioButton bl;

	private TreeView bm;

	private SplitContainer bn;

	private Button bo;

	private ToolTip bp;

	private Label bq;

	private TextBox br;

	private Button bs;

	private Button bt;

	private Button bu;

	private Label bv;

	private TextBox bw;

	private GroupBox bx;

	private ComboBox by;

	public ActionControl()
	{
		a();
		Command.PopulateComboWithCommands(cbCommandStep1, bFilter: true);
		Command.PopulateTreeViewWithCommands(bm);
		Condition.PopulateComboWithConditions(cbConditionStep1, bFilter: true);
		bn.Panel2Collapsed = true;
		bp.SetToolTip((Control)(object)bo, "Get Help On This Command");
	}

	public void SetGameObject(ref Game CurGame)
	{
		this.m_e = CurGame;
	}

	public void SetPageType(PageType pt)
	{
		this.m_f = pt;
	}

	public void SetObjectName(string name)
	{
		this.m_g = name;
	}

	private void a(TreeView A_0, EventHandler A_1, int A_2, int A_3)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected Obj, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected Obj, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected Obj, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected Obj, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected Obj, but got Unknown
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected Obj, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected Obj, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected Obj, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected Obj, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected Obj, but got Unknown
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Expected Obj, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected Obj, but got Unknown
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected Obj, but got Unknown
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected Obj, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected Obj, but got Unknown
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Expected Obj, but got Unknown
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected Obj, but got Unknown
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Expected Obj, but got Unknown
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected Obj, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected Obj, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected Obj, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected Obj, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Obj, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected Obj, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected Obj, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected Obj, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected Obj, but got Unknown
		//IL_081d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected Obj, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Expected Obj, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Expected Obj, but got Unknown
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Expected Obj, but got Unknown
		//IL_0992: Unknown result type (might be due to invalid IL or missing references)
		//IL_0999: Expected Obj, but got Unknown
		((ToolStrip)this.m_ar).Items.Clear();
		TreeViewHitTestInfo val = A_0.HitTest(A_2, A_3);
		if (val.Node == null)
		{
			ToolStripMenuItem val2 = new ToolStripMenuItem("Add Action", (Image)(object)Resources.runman);
			((ToolStripItem)val2).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val2);
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)new ToolStripSeparator());
			val2 = new ToolStripMenuItem("Paste Action", (Image)(object)Resources.TaskHS);
			Action action = Clipboard.GetDataObject().GetData(ActionFormat.Name) as Action;
			((ToolStripItem)val2).Enabled = action != null;
			((ToolStripItem)val2).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val2);
			ToolStripMenuItem val3 = new ToolStripMenuItem("Expand All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val3).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val3);
			val3 = new ToolStripMenuItem("Collapse All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val3).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val3);
		}
		else if (val.Node.Parent == null)
		{
			A_0.SelectedNode = val.Node;
			ToolStripMenuItem val4 = null;
			if (this.m_f != PageType.timers)
			{
				val4 = new ToolStripMenuItem("Rename Action", (Image)(object)Resources.cancel);
				((ToolStripItem)val4).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			}
			val4 = new ToolStripMenuItem("Add Action", (Image)(object)Resources.runman);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Delete Action", (Image)(object)Resources.cancel);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Add Condition", (Image)(object)Resources.question);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Delete Condition", (Image)(object)Resources.cancel);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Add Command On Success", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Add Command On Failure", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			bool flag = false;
			if (val.Node.Tag is Command)
			{
				flag = true;
				val4 = new ToolStripMenuItem("Delete Command", (Image)(object)Resources.cancel);
				((ToolStripItem)val4).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			}
			ToolStripMenuItem val5 = new ToolStripMenuItem("Expand All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val5).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val5);
			val5 = new ToolStripMenuItem("Collapse All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val5).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val5);
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)new ToolStripSeparator());
			val4 = new ToolStripMenuItem("Copy Action", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Paste Action", (Image)(object)Resources.TaskHS);
			IDataObject dataObject = Clipboard.GetDataObject();
			Action action2 = dataObject.GetData(ActionFormat.Name) as Action;
			((ToolStripItem)val4).Enabled = action2 != null;
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			val4 = new ToolStripMenuItem("Paste Condition", (Image)(object)Resources.TaskHS);
			Condition condition = dataObject.GetData(ConditonFormat.Name) as Condition;
			((ToolStripItem)val4).Enabled = condition != null;
			((ToolStripItem)val4).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			if (flag)
			{
				val4 = new ToolStripMenuItem("Copy Command", (Image)(object)Resources.TaskHS);
				((ToolStripItem)val4).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
				val4 = new ToolStripMenuItem("Paste Command", (Image)(object)Resources.TaskHS);
				Command command = dataObject.GetData(CommandFormat.Name) as Command;
				((ToolStripItem)val4).Enabled = command != null;
				((ToolStripItem)val4).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val4);
			}
		}
		else
		{
			A_0.SelectedNode = val.Node;
			ToolStripMenuItem val6 = null;
			if (this.m_f != PageType.timers)
			{
				val6 = new ToolStripMenuItem("Rename Action", (Image)(object)Resources.cancel);
				((ToolStripItem)val6).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			}
			val6 = new ToolStripMenuItem("Add Action");
			((ToolStripItem)val6).Click += al;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Delete Action");
			((ToolStripItem)val6).Click += al;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Add Condition", (Image)(object)Resources.question);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Delete Condition", (Image)(object)Resources.cancel);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Add Command On Success", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Add Command On Failure", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			bool flag2 = false;
			if (val.Node.Tag is Command)
			{
				flag2 = true;
				val6 = new ToolStripMenuItem("Delete Command", (Image)(object)Resources.cancel);
				((ToolStripItem)val6).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
				flag2 = true;
			}
			ToolStripMenuItem val7 = new ToolStripMenuItem("Expand All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val7).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val7);
			val7 = new ToolStripMenuItem("Collapse All", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val7).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val7);
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)new ToolStripSeparator());
			val6 = new ToolStripMenuItem("Copy Action", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Paste Action", (Image)(object)Resources.TaskHS);
			IDataObject dataObject2 = Clipboard.GetDataObject();
			Action action3 = dataObject2.GetData(ActionFormat.Name) as Action;
			((ToolStripItem)val6).Enabled = action3 != null;
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Copy Condition", (Image)(object)Resources.TaskHS);
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			val6 = new ToolStripMenuItem("Paste Condition", (Image)(object)Resources.TaskHS);
			Condition condition2 = dataObject2.GetData(ConditonFormat.Name) as Condition;
			((ToolStripItem)val6).Enabled = condition2 != null;
			((ToolStripItem)val6).Click += A_1;
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			if (flag2)
			{
				val6 = new ToolStripMenuItem("Copy Command", (Image)(object)Resources.TaskHS);
				((ToolStripItem)val6).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			}
			if (A_0.SelectedNode.Parent.Text == "Commands on Success" || A_0.SelectedNode.Text == "Commands on Success" || A_0.SelectedNode.Parent.Text == "Commands on Failure" || A_0.SelectedNode.Text == "Commands on Failure")
			{
				val6 = new ToolStripMenuItem("Paste Command", (Image)(object)Resources.TaskHS);
				Command command2 = dataObject2.GetData(CommandFormat.Name) as Command;
				((ToolStripItem)val6).Enabled = command2 != null;
				((ToolStripItem)val6).Click += A_1;
				((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val6);
			}
		}
		if (this.m_f != PageType.timers)
		{
			ToolStripSeparator val8 = new ToolStripSeparator();
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val8);
			ToolStripMenuItem val9 = new ToolStripMenuItem("Add Default Actions:");
			((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val9);
			for (int i = 0; i < this.m_e.QuickCommands.Count; i++)
			{
				QuickMenuItem quickMenuItem = (QuickMenuItem)this.m_e.QuickCommands[i];
				switch (this.m_f)
				{
				case PageType.characters:
					if (quickMenuItem.bCharacters)
					{
						val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)Resources.runman);
						((ToolStripItem)val9).Click += A_1;
						((ToolStripItem)val9).Tag = quickMenuItem;
						((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val9);
					}
					break;
				case PageType.objects:
					if (quickMenuItem.bObjects)
					{
						val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)Resources.runman);
						((ToolStripItem)val9).Click += A_1;
						((ToolStripItem)val9).Tag = quickMenuItem;
						((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val9);
					}
					break;
				case PageType.player:
					if (quickMenuItem.bPlayer)
					{
						val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)Resources.runman);
						((ToolStripItem)val9).Click += A_1;
						((ToolStripItem)val9).Tag = quickMenuItem;
						((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val9);
					}
					break;
				case PageType.room:
					if (quickMenuItem.bRooms)
					{
						val9 = new ToolStripMenuItem(quickMenuItem.Name, (Image)(object)Resources.runman);
						((ToolStripItem)val9).Click += A_1;
						((ToolStripItem)val9).Tag = quickMenuItem;
						((ToolStrip)this.m_ar).Items.Add((ToolStripItem)(object)val9);
					}
					break;
				}
			}
		}
		((ToolStripDropDown)this.m_ar).Show((Control)(object)A_0, A_2, A_3);
	}

	private void i(object A_0, MouseEventArgs A_1)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		((Control)tvActionsConditions).Focus();
		if ((int)A_1.Button == 2097152 && ((Control)tvActionsConditions).Enabled)
		{
			a(tvActionsConditions, al, A_1.X, A_1.Y);
		}
		if ((int)A_1.Button == 1048576)
		{
			TreeViewHitTestInfo val = tvActionsConditions.HitTest(A_1.X, A_1.Y);
			if (val.Node != null)
			{
				tvActionsConditions.SelectedNode = val.Node;
			}
			this.m_d = true;
		}
	}

	private void b(object A_0, TreeViewEventArgs A_1)
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (selectedNode.Tag is Command)
		{
			((Control)this.m_ag).Visible = true;
			((Control)this.m_w).Visible = false;
			((Control)bd).Visible = false;
			cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, ((Command)selectedNode.Tag).cmdtype);
		}
		else if (m() && !(tvActionsConditions.SelectedNode.Tag is Condition))
		{
			((Control)this.m_ag).Visible = false;
			((Control)this.m_w).Visible = false;
			((Control)bd).Visible = true;
		}
		else
		{
			((Control)this.m_ag).Visible = false;
			((Control)this.m_w).Visible = true;
			((Control)bd).Visible = false;
		}
		if (selectedNode == null)
		{
			((Control)this.m_aa).Text = "";
			((Control)this.m_ag).Visible = false;
			((Control)this.m_w).Visible = false;
			((Control)bd).Visible = false;
		}
		else if (selectedNode.Tag is Action)
		{
			((Control)this.m_aa).Text = "";
			((Control)this.m_v).Enabled = true;
			((Control)this.m_p).Enabled = true;
			((Control)this.m_m).Enabled = true;
		}
		else
		{
			((Control)this.m_aa).Text = selectedNode.Text;
			((Control)this.m_v).Enabled = false;
			((Control)this.m_p).Enabled = false;
			((Control)this.m_m).Enabled = false;
		}
		r();
	}

	private void a3(object A_0, EventArgs A_1)
	{
		Command command = new Command();
		command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		command.CommandPart2 = ((Control)this.m_an).Text;
		command.CommandPart3 = ((Control)this.m_al).Text;
		command.CommandText = ((Control)this.m_ap).Text;
		if (tvActionsConditions.SelectedNode == null)
		{
			return;
		}
		if (tvActionsConditions.SelectedNode.Parent == null)
		{
			switch (this.m_f)
			{
			case PageType.objects:
				this.m_e.GetObjectByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.player:
				this.m_e.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.room:
				this.m_e.GetRoomByID(new Guid(this.m_g))?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.characters:
				this.m_e.GetCharacterByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.timers:
				this.m_e.GetTimerByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.quickcommand:
				this.m_e.GetMenuItemByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			}
		}
		else
		{
			switch (this.m_f)
			{
			case PageType.objects:
				this.m_e.GetObjectByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.player:
				this.m_e.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.characters:
				this.m_e.GetCharacterByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.room:
				this.m_e.GetRoomByID(new Guid(this.m_g))?.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.timers:
				this.m_e.GetTimerByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			case PageType.quickcommand:
				this.m_e.GetMenuItemByName(this.m_g)?.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text)?.GetConditionByName(tvActionsConditions.SelectedNode.Text)?.PassCommands.Add(command);
				break;
			}
		}
		r();
	}

	private void s()
	{
		Action action = p();
		if (action == null)
		{
			return;
		}
		by.Items.Clear();
		by.Items.Add((object)"None");
		if (action.actionparent == "None")
		{
			((ListControl)by).SelectedIndex = 0;
		}
		ArrayList arrayList = j();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Action action2 = (Action)arrayList[i];
			if (!action2.name.Contains("<<") && action2.name != action.name)
			{
				int selectedIndex = by.Items.Add((object)action2.name);
				if (action.actionparent == action2.name)
				{
					((ListControl)by).SelectedIndex = selectedIndex;
				}
			}
		}
	}

	private void r()
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			((Control)this.m_ag).Enabled = true;
			((Control)this.m_w).Enabled = true;
			((Control)bd).Enabled = true;
			((Control)this.m_m).Enabled = true;
			((Control)this.m_ae).Visible = false;
			((Control)this.m_ad).Visible = false;
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_z).Visible = false;
			if (m() && !(tvActionsConditions.SelectedNode.Tag is Condition))
			{
				Action action = p();
				((Control)br).Text = action.CustomChoiceTitle;
				((Control)bw).Text = action.overridename;
				s();
				bf.Items.Clear();
				foreach (string customChoice in action.CustomChoices)
				{
					bf.Items.Add((object)customChoice);
				}
				this.m_v.Checked = action.bActive;
				if (action.bConditionFailOnFirst)
				{
					this.m_o.Checked = true;
				}
				else
				{
					this.m_n.Checked = true;
				}
				((Control)bd).Enabled = false;
				switch (action.InputType)
				{
				case Action.ActionInputType.None:
					this.m_u.Checked = true;
					((Control)bd).Enabled = false;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = false;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				case Action.ActionInputType.Character:
					this.m_s.Checked = true;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = true;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				case Action.ActionInputType.Object:
					this.m_t.Checked = true;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = true;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				case Action.ActionInputType.ObjectOrCharacter:
					this.m_r.Checked = true;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = true;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				case Action.ActionInputType.Text:
					this.m_q.Checked = true;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = true;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				case Action.ActionInputType.Custom:
					bg.Checked = true;
					((Control)bd).Enabled = true;
					((Control)br).Text = action.CustomChoiceTitle;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = true;
					((Control)br).Enabled = true;
					((Control)be).Enabled = true;
					((Control)bk).Enabled = true;
					((Control)bs).Enabled = true;
					break;
				case Action.ActionInputType.Inventory:
					bl.Checked = true;
					((Control)bd).Enabled = true;
					((Control)bf).Enabled = false;
					((Control)br).Enabled = true;
					((Control)be).Enabled = false;
					((Control)bk).Enabled = false;
					((Control)bs).Enabled = false;
					break;
				}
			}
			else
			{
				Condition condition = q();
				if (condition != null)
				{
					a(condition);
					((Control)this.m_aa).Text = condition.conditionname;
					((ListControl)this.m_a2).SelectedIndex = 0;
				}
			}
			if (!(tvActionsConditions.SelectedNode.Tag is Command command))
			{
				return;
			}
			ba.Items.Clear();
			foreach (string customChoice2 in command.CustomChoices)
			{
				ba.Items.Add((object)customChoice2);
			}
			((Control)this.m_ap).Text = command.CommandText;
			((Control)this.m_ah).Text = command.CommandPart4;
			cbConditionStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, command.cmdtype);
			a0(null, null);
			try
			{
				Guid guid = new Guid(command.CommandPart2);
				foreach (RoomComboItem item in this.m_an.Items)
				{
					if (item.UniqueID == guid)
					{
						this.m_an.SelectedItem = item;
						break;
					}
				}
			}
			catch
			{
				((Control)this.m_an).Text = command.CommandPart2;
			}
			try
			{
				Guid guid2 = new Guid(command.CommandPart3);
				foreach (RoomComboItem item2 in this.m_al.Items)
				{
					if (item2.UniqueID == guid2)
					{
						this.m_al.SelectedItem = item2;
						break;
					}
				}
			}
			catch
			{
				((Control)this.m_al).Text = command.CommandPart3;
			}
			try
			{
				Guid guid3 = new Guid(command.CommandPart4);
				for (int i = 0; i < bh.Items.Count; i++)
				{
					RoomComboItem roomComboItem3 = null;
					try
					{
						roomComboItem3 = (RoomComboItem)bh.Items[i];
					}
					catch
					{
						roomComboItem3 = null;
					}
					if (roomComboItem3 != null && roomComboItem3.UniqueID == guid3)
					{
						bh.SelectedItem = roomComboItem3;
						break;
					}
				}
				return;
			}
			catch
			{
				((Control)bh).Text = command.CommandPart4;
				return;
			}
		}
		((Control)this.m_ag).Enabled = false;
		((Control)this.m_w).Enabled = false;
		((Control)bd).Enabled = false;
		((Control)this.m_m).Enabled = false;
	}

	private void a(Condition A_0)
	{
		this.m_a2.Items.Clear();
		foreach (Check check in A_0.Checks)
		{
			if (check.CkType != CheckType.CT_Uninitialized)
			{
				this.m_a2.Items.Add((object)(check.CkType.ToString() + " " + Condition.GetConditionName(check.CondType)));
			}
			else
			{
				this.m_a2.Items.Add((object)Condition.GetConditionName(check.CondType));
			}
		}
	}

	private Condition q()
	{
		Condition condition = null;
		if (tvActionsConditions.SelectedNode.Level >= 1)
		{
			TreeNode val = tvActionsConditions.SelectedNode;
			condition = val.Tag as Condition;
			while (condition == null && val.Level >= 1)
			{
				val = val.Parent;
				condition = val.Tag as Condition;
			}
		}
		return condition;
	}

	private Action p()
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			TreeNode val = tvActionsConditions.SelectedNode;
			while (val.Parent != null)
			{
				val = val.Parent;
			}
			return val.Tag as Action;
		}
		return null;
	}

	private TreeNode o()
	{
		TreeNode val = tvActionsConditions.SelectedNode;
		while (val.Parent != null)
		{
			val = val.Parent;
		}
		return val;
	}

	private TreeNode n()
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (selectedNode.Text.IndexOf("Commands on") > -1)
		{
			return selectedNode;
		}
		return selectedNode.Parent;
	}

	private bool m()
	{
		TreeNode selectedNode = tvActionsConditions.SelectedNode;
		if (string.Compare(selectedNode.Text, "Commands On Success", ignoreCase: true) != 0 && string.Compare(selectedNode.Text, "Commands On Failure", ignoreCase: true) != 0)
		{
			if (selectedNode.Tag is Action)
			{
				return true;
			}
			if ((selectedNode.Tag is Command && selectedNode.Level == 2) || (selectedNode.Tag is Condition && selectedNode.Level == 2))
			{
				return true;
			}
		}
		else if (selectedNode.Parent.Tag is Action)
		{
			return true;
		}
		return false;
	}

	private void a2(object A_0, EventArgs A_1)
	{
		Command command = new Command();
		command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		command.CommandPart2 = ((Control)this.m_an).Text;
		command.CommandPart3 = ((Control)this.m_al).Text;
		command.CommandText = ((Control)this.m_ap).Text;
		if (tvActionsConditions.SelectedNode.Parent == null)
		{
			Action action = null;
			switch (this.m_f)
			{
			case PageType.objects:
			{
				GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
				if (objectByName != null)
				{
					action = objectByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.player:
				action = this.m_e.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Text);
				break;
			case PageType.characters:
			{
				Character characterByName = this.m_e.GetCharacterByName(this.m_g);
				if (characterByName != null)
				{
					action = characterByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = this.m_e.GetRoomByID(new Guid(this.m_g));
				if (roomByID != null)
				{
					action = roomByID.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = this.m_e.GetTimerByName(this.m_g);
				if (timerByName != null)
				{
					action = timerByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName = this.m_e.GetMenuItemByName(this.m_g);
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
			switch (this.m_f)
			{
			case PageType.objects:
			{
				GameObject objectByName2 = this.m_e.GetObjectByName(this.m_g);
				if (objectByName2 != null)
				{
					action2 = objectByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.player:
				action2 = this.m_e.ThePlayer.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				break;
			case PageType.characters:
			{
				Character characterByName2 = this.m_e.GetCharacterByName(this.m_g);
				if (characterByName2 != null)
				{
					action2 = characterByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID2 = this.m_e.GetRoomByID(new Guid(this.m_g));
				if (roomByID2 != null)
				{
					action2 = roomByID2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName2 = this.m_e.GetTimerByName(this.m_g);
				if (timerByName2 != null)
				{
					action2 = timerByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName2 = this.m_e.GetMenuItemByName(this.m_g);
				if (menuItemByName2 != null)
				{
					action2 = menuItemByName2.GetActionByName(tvActionsConditions.SelectedNode.Parent.Text);
				}
				break;
			}
			}
			if (action2 != null)
			{
				condition = action2.GetConditionByName(tvActionsConditions.SelectedNode.Text);
			}
			condition?.FailCommands.Add(command);
		}
		r();
	}

	private void a1(object A_0, EventArgs A_1)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition != null)
		{
			if (cbConditionStep1.SelectedItem != null && (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Rooms || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Characters || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Items) && condition.Checks.Count > 1)
			{
				MessageBox.Show("Sorry, a loop check must be the only check in your condition.");
				cbConditionStep1.SelectedItem = Condition.GetConditionItem(cbConditionStep1, Condition.ConditionType.CT_Character_In_Room);
			}
			else
			{
				l();
			}
		}
	}

	private void l()
	{
		//IL_167a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1680: Invalid comparison between Unknown and I4
		((Control)bi).Visible = false;
		switch (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex)
		{
		case Condition.ConditionType.CT_Item_InGroup:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Text = "Choose Item Group:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			aa(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_MultiMedia_InGroup:
			((Control)this.m_ad).Text = "Choose Media:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			ac(ref this.m_ae);
			((Control)this.m_y).Text = "Choose Media Group:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			ab(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Character_In_Room:
		{
			((Control)this.m_ad).Text = "Choose Character:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			s(ref this.m_ae);
			((Control)this.m_y).Text = "Choose Room:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			n(ref this.m_ac);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = "<CurrentRoom>";
			this.m_ac.Items.Insert(0, (object)roomComboItem2);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		}
		case Condition.ConditionType.CT_Character_In_RoomGroup:
			((Control)this.m_ad).Text = "Choose Character:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			s(ref this.m_ae);
			((Control)this.m_y).Text = "Choose Room Group:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			m(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Character_Gender:
			((Control)this.m_ad).Text = "Choose Character:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			s(ref this.m_ae);
			this.m_ac.Items.Clear();
			this.m_ac.Items.Add((object)"Male");
			this.m_ac.Items.Add((object)"Female");
			this.m_ac.Items.Add((object)"Other");
			((Control)this.m_y).Text = "Is Gender:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Character:
			((Control)this.m_ad).Text = "Choose Character:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			s(ref this.m_ae);
			((Control)this.m_y).Text = "Choose Carryable Item:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			w(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_Not_In_Object:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			((Control)this.m_y).Text = "Not Inside object:";
			y(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			((Control)this.m_y).Text = "Inside object:";
			y(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_Gender:
			((Control)this.m_ad).Text = "Is Gender:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			this.m_ae.Items.Clear();
			this.m_ae.Items.Add((object)"Male");
			this.m_ae.Items.Add((object)"Female");
			this.m_ae.Items.Add((object)"Other");
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_y).Text = "Inside object:";
			y(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			((Control)this.m_ad).Text = "Choose Character:";
			s(ref this.m_ae);
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_In_Room:
		{
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			n(ref this.m_ac);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = "<CurrentRoom>";
			this.m_ac.Items.Insert(0, (object)roomComboItem);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		}
		case Condition.ConditionType.CT_Item_In_RoomGroup:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Text = "In Room Group:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			m(ref this.m_ac);
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			((Control)this.m_ad).Text = "Choose Room:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			n(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Exits:
			((Control)this.m_ad).Text = "Choose Room:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			n(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_In_RoomGroup:
			((Control)this.m_ad).Text = "Choose Room Group:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			m(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Player_Moving:
			((Control)this.m_ad).Text = "Moving In Which Direction:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			o(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			z(ref this.m_ae);
			((Control)this.m_y).Text = "State Must Be:";
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			this.m_ac.Items.Clear();
			this.m_ac.Items.Add((object)"Open");
			this.m_ac.Items.Add((object)"Closed");
			this.m_ac.Items.Add((object)"Locked");
			this.m_ac.Items.Add((object)"Unlocked");
			this.m_ac.Items.Add((object)"Worn");
			this.m_ac.Items.Add((object)"Removed");
			this.m_ac.Items.Add((object)"Read");
			this.m_ac.Items.Add((object)"Unread");
			this.m_ac.Items.Add((object)"Visible");
			this.m_ac.Items.Add((object)"Invisible");
			break;
		case Condition.ConditionType.CT_Loop_Characters:
		case Condition.ConditionType.CT_Loop_Items:
		case Condition.ConditionType.CT_Loop_Rooms:
			((Control)this.m_ad).Text = "Choose Item:";
			((Control)this.m_ad).Visible = false;
			((Control)this.m_ae).Visible = false;
			z(ref this.m_ae);
			((Control)this.m_y).Text = "State Must Be:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_While:
			((Control)this.m_ad).Text = "Choose Variable:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			f(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Loop_Item_Group:
			((Control)this.m_ad).Text = "Choose Item Group:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			aa(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Container:
			((Control)this.m_ad).Text = "Choose Container:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			y(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Room:
			((Control)this.m_ad).Text = "Choose Room:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			n(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
			((Control)this.m_ad).Text = "Choose Character:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			s(ref this.m_ae);
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Loop_Item_Inventory:
			((Control)this.m_ad).Text = "Choose Item Group:";
			((Control)this.m_ad).Visible = false;
			((Control)this.m_ae).Visible = false;
			((Control)this.m_y).Text = "In Room:";
			((Control)this.m_y).Visible = false;
			((Control)this.m_ac).Visible = false;
			((Control)this.m_x).Visible = false;
			((Control)this.m_z).Visible = false;
			break;
		case Condition.ConditionType.CT_Room_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			l(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			j(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			i(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Character_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			k(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Item_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			h(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Player_CustomPropertyCheck:
			((Control)this.m_ad).Text = "Choose Property:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			g(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
			((Control)this.m_ad).Text = "Choose Variable:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			f(ref this.m_ae);
			if (((Control)this.m_ac).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Value:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
			((Control)this.m_ad).Text = "Choose Variable:";
			((Control)this.m_ad).Visible = true;
			((Control)this.m_ae).Visible = true;
			((Control)this.m_x).Text = "Compared to Variable:";
			c(ref this.m_ae);
			c(ref bi);
			if (((Control)bi).Text.Trim() != "")
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = true;
				((Control)this.m_ac).Visible = true;
				((Control)this.m_x).Text = "Compared to Variable:";
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = false;
				((Control)bi).Visible = true;
			}
			else
			{
				((Control)this.m_y).Text = "Comparison Type:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
			}
			break;
		case Condition.ConditionType.CT_AdditionalDataCheck:
			if (p().InputType == Action.ActionInputType.None)
			{
				if ((int)MessageBox.Show("This action is currently not defined to accept additional input.  Would you like to define the additional input now?", "No Additional Input", (MessageBoxButtons)4) != 6)
				{
					if (cbConditionStep1.Items.Count > 0)
					{
						((ListControl)cbConditionStep1).SelectedIndex = 0;
					}
					break;
				}
				tvActionsConditions.SelectedNode = o();
				((Control)this.m_p).Select();
			}
			switch (p().InputType)
			{
			case Action.ActionInputType.Text:
				((Control)this.m_ad).Text = "Choose Item:";
				((Control)this.m_ad).Visible = false;
				((Control)this.m_ae).Visible = false;
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = true;
				((Control)this.m_z).Visible = true;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			case Action.ActionInputType.Character:
				((Control)this.m_ad).Text = "Which character should the player choose:";
				((Control)this.m_ad).Visible = true;
				((Control)this.m_ae).Visible = true;
				s(ref this.m_ae);
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			case Action.ActionInputType.Object:
				((Control)this.m_ad).Text = "Which object should the player choose:";
				((Control)this.m_ad).Visible = true;
				((Control)this.m_ae).Visible = true;
				z(ref this.m_ae);
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			case Action.ActionInputType.Inventory:
				((Control)this.m_ad).Text = "Which object should the player choose:";
				((Control)this.m_ad).Visible = true;
				((Control)this.m_ae).Visible = true;
				w(ref this.m_ae);
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			case Action.ActionInputType.ObjectOrCharacter:
				((Control)this.m_ad).Text = "Which object or character should the player choose:";
				((Control)this.m_ad).Visible = true;
				((Control)this.m_ae).Visible = true;
				x(ref this.m_ae);
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			case Action.ActionInputType.Custom:
				((Control)this.m_ad).Text = "Which choice should the user make:";
				((Control)this.m_ad).Visible = true;
				((Control)this.m_ae).Visible = true;
				this.m_ae.Items.Clear();
				foreach (string item in bf.Items)
				{
					this.m_ae.Items.Add((object)item);
				}
				((Control)this.m_y).Text = "State Must Be:";
				((Control)this.m_y).Visible = false;
				((Control)this.m_ac).Visible = false;
				((Control)this.m_x).Visible = false;
				((Control)this.m_z).Visible = false;
				((Control)this.m_x).Text = "What should the user enter or select:";
				break;
			}
			break;
		}
	}

	private void a0(object A_0, EventArgs A_1)
	{
		bn.Panel2Collapsed = true;
		Command a_ = tvActionsConditions.SelectedNode.Tag as Command;
		k();
		if (tvActionsConditions.SelectedNode != null)
		{
			tvActionsConditions.SelectedNode.Text = a(a_);
		}
	}

	private string a(Command A_0)
	{
		string text = string.Empty;
		if (A_0 != null)
		{
			text = Command.GetCommandName(A_0.cmdtype);
			if (A_0.CommandPart2 != string.Empty)
			{
				try
				{
					Guid guid = new Guid(A_0.CommandPart2);
					if (guid == Room.CurrentRoomGuid)
					{
						text += ": <CurrentRoom>";
					}
					else if (guid == Room.VoidRoomGuid)
					{
						text += ": <Void>";
					}
					else if (guid == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((this.m_e.GetRoomByID(guid) == null) ? (text + ": " + this.m_e.GetObjectByName(guid.ToString()).name) : (text + ": " + this.m_e.GetRoomByID(guid).Name));
					}
				}
				catch
				{
					text = text + ": " + A_0.CommandPart2;
				}
			}
			if (A_0.CommandPart3 != string.Empty)
			{
				try
				{
					Guid guid2 = new Guid(A_0.CommandPart3);
					if (guid2 == Room.CurrentRoomGuid)
					{
						text += ", <CurrentRoom>";
					}
					else if (guid2 == Room.VoidRoomGuid)
					{
						text += ", <Void>";
					}
					else if (guid2 == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((this.m_e.GetRoomByID(guid2) == null) ? (text + ", " + this.m_e.GetObjectByName(guid2.ToString()).name) : (text + ", " + this.m_e.GetRoomByID(guid2).Name));
					}
				}
				catch
				{
					text = text + ", " + A_0.CommandPart3;
				}
			}
			if (A_0.CommandPart4 != string.Empty)
			{
				try
				{
					Guid guid3 = new Guid(A_0.CommandPart4);
					if (guid3 == Room.CurrentRoomGuid)
					{
						text += ", <CurrentRoom>";
					}
					else if (guid3 == Room.VoidRoomGuid)
					{
						text += ", <Void>";
					}
					else if (guid3 == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((this.m_e.GetRoomByID(guid3) == null) ? (text + ", " + this.m_e.GetObjectByName(guid3.ToString()).name) : (text + ", " + this.m_e.GetRoomByID(guid3).Name));
					}
				}
				catch
				{
					text = text + ", " + A_0.CommandPart4;
				}
			}
			if (A_0.CommandText != string.Empty)
			{
				text = ((A_0.CommandText.Length <= 20) ? (text + ", " + A_0.CommandText) : (text + ", " + A_0.CommandText.Substring(0, 20) + "..."));
			}
		}
		return text;
	}

	private void k()
	{
		if (cbCommandStep1.SelectedItem == null)
		{
			return;
		}
		((Control)a9).Visible = false;
		((Control)ba).Visible = false;
		((Control)bc).Visible = false;
		((Control)bj).Visible = false;
		((Control)bb).Visible = false;
		((Control)bh).Visible = false;
		switch (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex)
		{
		case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
			((Control)this.m_am).Text = "Select Variable:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			b(ref this.m_an);
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Item Group:";
			aa(ref this.m_al);
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_MM_GETRANDOMGROUP:
			((Control)this.m_am).Text = "Select Variable:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			b(ref this.m_an);
			ab(ref this.m_al);
			((Control)this.m_aj).Text = "Select Media Group:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_CANCELMOVE:
			((Control)this.m_am).Text = "Select Action:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_Status_ItemVisibleInvisible:
			((Control)this.m_am).Text = "Select Status Bar Item:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Visible/Invisible:";
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			foreach (StatusBarItem statusBarItem in this.m_e.StatusBarItems)
			{
				this.m_an.Items.Add((object)statusBarItem.Name);
			}
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Visible");
			this.m_al.Items.Add((object)"Invisible");
			break;
		case Command.CommandType.CT_LOOP_BREAK:
			((Control)this.m_am).Text = "Select Action:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
			((Control)this.m_am).Text = "Select Action:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			t(ref this.m_an);
			break;
		case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			((Control)this.m_am).Text = "Select Action:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			this.m_an.Items.Clear();
			t(ref this.m_an);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_ADD:
		case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
			((Control)this.m_am).Text = "Select Base Image:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Select Image to Add/Remove:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			ac(ref this.m_an);
			ac(ref this.m_al);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
			((Control)this.m_am).Text = "Select Base Image:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Select Layered Image to Replace:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)bh).Visible = true;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ai).Text = "Select New Layered Image:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			ac(ref this.m_an);
			ac(ref this.m_al);
			ac(ref bh);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
			((Control)this.m_am).Text = "Select Base Image To Clear:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Select Image to Add/Remove:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_ITEM_SET_VISIBILITY:
			((Control)this.m_am).Text = "Select Item:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Select Visibility State:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Visible");
			this.m_al.Items.Add((object)"Invisible");
			break;
		case Command.CommandType.CT_ITEM_LAYERED_WEAR:
			((Control)this.m_am).Text = "Item to Wear:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			v(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bWearable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
			((Control)this.m_am).Text = "Item to Remove:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			v(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bWearable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			((Control)this.m_am).Text = "Select Source Container Item:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Select Dest Container Item:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			this.m_al.Items.Clear();
			y(ref this.m_an);
			y(ref this.m_al);
			if (this.m_f == PageType.objects)
			{
				GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
				if (objectByName != null && objectByName.bContainer)
				{
					this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
					this.m_al.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
				}
			}
			break;
		case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
			((Control)this.m_am).Text = "Select Numeric Variable:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "New Custom Choice:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			a(ref this.m_an);
			break;
		case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			((Control)this.m_am).Text = "Select Action:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Text = "Custom Choice To Remove:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			this.m_an.Items.Clear();
			t(ref this.m_an);
			break;
		case Command.CommandType.CT_SETPLAYERDESC:
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			break;
		case Command.CommandType.CT_SETPLAYERNAME:
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_SETPLAYERGENDER:
			((Control)this.m_am).Text = "Select Gender:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_an.Items.Clear();
			this.m_an.Items.Add((object)"Male");
			this.m_an.Items.Add((object)"Female");
			this.m_an.Items.Add((object)"Other");
			break;
		case Command.CommandType.CT_CHAR_SET_GENDER:
			((Control)this.m_am).Text = "Select Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_aj).Text = "Select Gender:";
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ai).Text = "Player's Name:";
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			s(ref this.m_an);
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Male");
			this.m_al.Items.Add((object)"Female");
			this.m_al.Items.Add((object)"Other");
			break;
		case Command.CommandType.CT_CHAR_SET_NAME:
			((Control)this.m_am).Text = "Select Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_aj).Text = "Select Gender:";
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ai).Text = "Character's Name:";
			((Control)this.m_ah).Visible = true;
			s(ref this.m_an);
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
			((Control)this.m_am).Text = "Select Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_aj).Text = "Select Gender:";
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ai).Text = "Room's Name:";
			((Control)this.m_ah).Visible = true;
			n(ref this.m_an);
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
			((Control)this.m_am).Text = "Select Item:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_aj).Text = "Select Gender:";
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ai).Text = "Item's Name:";
			((Control)this.m_ah).Visible = true;
			z(ref this.m_an);
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_PAUSEGAME:
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			break;
		case Command.CommandType.CT_EXECUTETIMER:
			((Control)this.m_am).Text = "Timer:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Active/Inactive:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			r(ref this.m_an);
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Active");
			this.m_al.Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_RESETTIMER:
			((Control)this.m_am).Text = "Timer:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Active/Inactive:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			r(ref this.m_an);
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Active");
			this.m_al.Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_SETTIMER:
			((Control)this.m_am).Text = "Timer:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Active/Inactive:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			r(ref this.m_an);
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Active");
			this.m_al.Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_SETVARIABLEBYINPUT:
			((Control)a9).Visible = true;
			((Control)ba).Visible = true;
			((Control)bc).Visible = true;
			((Control)bj).Visible = true;
			((Control)bb).Visible = true;
			((Control)this.m_am).Text = "Entry Type:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Variable To Set:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ah).Visible = true;
			((Control)this.m_ai).Text = "Title Of Entry Form:";
			this.m_an.Items.Clear();
			this.m_an.Items.Add((object)"Text");
			this.m_an.Items.Add((object)"Characters");
			this.m_an.Items.Add((object)"Objects");
			this.m_an.Items.Add((object)"Characters And Objects");
			this.m_an.Items.Add((object)"Custom");
			this.m_an.Items.Add((object)"Inventory");
			b(ref this.m_al);
			break;
		case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
			((Control)a9).Visible = true;
			((Control)ba).Visible = true;
			((Control)bc).Visible = true;
			((Control)bj).Visible = true;
			((Control)bb).Visible = true;
			((Control)this.m_am).Text = "Entry Type:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Variable To Set:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ah).Visible = true;
			((Control)this.m_ai).Text = "Title Of Entry Form:";
			this.m_an.Items.Clear();
			this.m_an.Items.Add((object)"Text");
			this.m_an.Items.Add((object)"Custom");
			a(ref this.m_al);
			break;
		case Command.CommandType.CT_SETCHARDESC:
			((Control)this.m_am).Text = "Character to change:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_SETROOMDESCRIPTION:
		{
			((Control)this.m_am).Text = "Room to change:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ak).Text = "New Room Description:";
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem9 = new RoomComboItem();
			roomComboItem9.UniqueID = Room.CurrentRoomGuid;
			roomComboItem9.RoomName = "<CurrentRoom>";
			this.m_an.Items.Insert(0, (object)roomComboItem9);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
		{
			((Control)this.m_am).Text = "Room's Description to Display:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ak).Text = "New Room Description:";
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem8 = new RoomComboItem();
			roomComboItem8.UniqueID = Room.CurrentRoomGuid;
			roomComboItem8.RoomName = "<CurrentRoom>";
			this.m_an.Items.Insert(0, (object)roomComboItem8);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMPICTURE:
		{
			((Control)this.m_am).Text = "Room's Picture to Display:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ak).Text = "New Room Description:";
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem10 = new RoomComboItem();
			roomComboItem10.UniqueID = Room.CurrentRoomGuid;
			roomComboItem10.RoomName = "<CurrentRoom>";
			this.m_an.Items.Insert(0, (object)roomComboItem10);
			break;
		}
		case Command.CommandType.CT_SETITEMDESC:
			((Control)this.m_am).Text = "Item to change description:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			l(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			k(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			j(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			this.i(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			h(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Custom Property Value:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)bh).Visible = false;
			((Control)this.m_ah).Visible = false;
			c(ref this.m_an);
			g(ref this.m_al);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_aj).Text = "Set Type";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_ai).Text = "Select Numeric Variable:";
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Variable data:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)bh).Visible = true;
				((Control)this.m_ah).Visible = false;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Variable data:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			d(ref this.m_an);
			a(ref bh);
			if (tvActionsConditions.SelectedNode.Tag is Command command)
			{
				((Control)bh).Text = command.CommandPart4;
			}
			break;
		case Command.CommandType.CT_SETVARIABLE:
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Variable data:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Variable data:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Variable data:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			f(ref this.m_an);
			if (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
			{
				break;
			}
			{
				foreach (GameVariable variable in this.m_e.VariableList)
				{
					switch (variable.vartype)
					{
					case GameVariable.VarType.VT_NUMBERARRAY:
					case GameVariable.VarType.VT_STRINGARRAY:
					case GameVariable.VarType.VT_DATETIMEARRAY:
						this.m_an.Items.Add((object)("Array:" + variable.varname));
						break;
					}
				}
				break;
			}
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Room Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Property Value:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Property Value:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			l(ref this.m_an);
			break;
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Timer Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Property Value:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Property Value:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			j(ref this.m_an);
			break;
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Variable Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Property Value:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Property Value:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			this.i(ref this.m_an);
			break;
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Character Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Property Value:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Property Value:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			k(ref this.m_an);
			break;
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Item Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Property Value:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ah).Visible = true;
			h(ref this.m_an);
			break;
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_am).Text = "Player Property To Set:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_ai).Text = "Property Value:";
			((Control)this.m_an).Visible = true;
			if (((Control)this.m_ah).Text.Trim() != "")
			{
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ak).Text = "Property Value:";
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
			}
			else
			{
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ak).Text = "Property Value:";
				if (((Control)this.m_ap).Text.Trim() != "")
				{
					((Control)this.m_ak).Visible = true;
					((Control)this.m_ap).Visible = true;
				}
				else
				{
					((Control)this.m_ak).Visible = false;
					((Control)this.m_ap).Visible = false;
				}
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
			}
			g(ref this.m_an);
			break;
		case Command.CommandType.CT_IMPORTVARIABLE:
			((Control)this.m_am).Text = "Variable to Import:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			f(ref this.m_an);
			break;
		case Command.CommandType.CT_EXPORTVARIABLE:
			((Control)this.m_am).Text = "Variable to Export:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			e(ref this.m_an);
			break;
		case Command.CommandType.CT_DEBUGTEXT:
		case Command.CommandType.CT_DISPLAYTEXT:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		case Command.CommandType.CT_JAVA_SET_RAGS:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Javascript to run:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		case Command.CommandType.CT_COMMENT:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Rags Designer Comment:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		case Command.CommandType.CT_DISPLAYPLAYERDESC:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		case Command.CommandType.CT_DISPLAYITEMDESC:
			((Control)this.m_am).Text = "Item to display:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_MOVEITEMTOINV:
			((Control)this.m_am).Text = "Item to Move:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			w(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bCarryable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
			((Control)this.m_am).Text = "Which Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_MOVEITEMTOOBJ:
			((Control)this.m_am).Text = "Select Item To Move:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Container Item:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			y(ref this.m_al);
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOROOM:
		{
			((Control)this.m_am).Text = "Which Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem7 = new RoomComboItem();
			roomComboItem7.RoomName = "<CurrentRoom>";
			roomComboItem7.UniqueID = Room.CurrentRoomGuid;
			this.m_an.Items.Insert(0, (object)roomComboItem7);
			roomComboItem7 = new RoomComboItem();
			roomComboItem7.RoomName = "<Void>";
			roomComboItem7.UniqueID = Room.VoidRoomGuid;
			this.m_an.Items.Insert(0, (object)roomComboItem7);
			break;
		}
		case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
		{
			((Control)this.m_am).Text = "Which Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem6 = new RoomComboItem();
			roomComboItem6.RoomName = "<CurrentRoom>";
			roomComboItem6.UniqueID = Room.CurrentRoomGuid;
			this.m_an.Items.Insert(0, (object)roomComboItem6);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOROOM:
		{
			((Control)this.m_am).Text = "Item to Move:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Destination Room:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			n(ref this.m_al);
			RoomComboItem roomComboItem5 = new RoomComboItem();
			roomComboItem5.UniqueID = Room.CurrentRoomGuid;
			roomComboItem5.RoomName = "<CurrentRoom>";
			this.m_al.Items.Insert(0, (object)roomComboItem5);
			roomComboItem5 = new RoomComboItem();
			roomComboItem5.UniqueID = Room.VoidRoomGuid;
			roomComboItem5.RoomName = "<Void>";
			this.m_al.Items.Insert(0, (object)roomComboItem5);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOCHAR:
			((Control)this.m_am).Text = "Item to Move:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Destination Character:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			s(ref this.m_al);
			break;
		case Command.CommandType.CT_SETEXIT:
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Direction to modify:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			((ListControl)this.m_an).SelectedIndex = 0;
			a(ref this.m_al, ((RoomComboItem)this.m_an.SelectedItem).UniqueID);
			break;
		case Command.CommandType.CT_SETEXITDESTINATION:
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Direction to modify:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Text = "New Destination Room";
			((Control)bh).Visible = true;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			o(ref this.m_al);
			n(ref bh);
			bh.Items.Insert(0, (object)"<None>");
			break;
		case Command.CommandType.CT_DISPLAYVARIABLE:
			((Control)this.m_am).Text = "Variable to display:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Direction to modify:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			f(ref this.m_an);
			break;
		case Command.CommandType.CT_SETROOMPIC:
		{
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem4 = new RoomComboItem();
			roomComboItem4.UniqueID = Room.CurrentRoomGuid;
			roomComboItem4.RoomName = "<CurrentRoom>";
			this.m_an.Items.Insert(0, (object)roomComboItem4);
			ac(ref this.m_al);
			break;
		}
		case Command.CommandType.CT_CHAR_SETPORT:
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			ac(ref this.m_al);
			break;
		case Command.CommandType.CT_CHAR_DISPLAYPORT:
			((Control)this.m_am).Text = "Character's Picture to Display:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ak).Text = "New Room Description:";
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_SETROOMLAYEREDPIC:
		{
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = Room.CurrentRoomGuid;
			roomComboItem3.RoomName = "<CurrentRoom>";
			this.m_an.Items.Insert(0, (object)roomComboItem3);
			ac(ref this.m_al);
			this.m_al.Items.Insert(0, (object)"<None>");
			break;
		}
		case Command.CommandType.CT_SETPLAYERPORTRAIT:
			((Control)this.m_am).Text = "Picture:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
			((Control)this.m_am).Text = "Picture:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			this.m_an.Items.Insert(0, (object)"<Default>");
			break;
		case Command.CommandType.CT_MM_SET_UD_COMPASS:
			((Control)this.m_am).Text = "Picture:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			this.m_an.Items.Insert(0, (object)"<Default>");
			break;
		case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
			((Control)this.m_am).Text = "Picture:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			this.m_an.Items.Insert(0, (object)"<None>");
			break;
		case Command.CommandType.CT_DISPLAYPICTURE:
			((Control)this.m_am).Text = "Media:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
			((Control)this.m_am).Text = "Media:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
			((Control)this.m_am).Text = "Media:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
			((Control)this.m_am).Text = "Media:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
			((Control)this.m_am).Text = "Picture:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Picture:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			ac(ref this.m_an);
			break;
		case Command.CommandType.CT_SETOBJECTACTION:
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Action:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			if (this.m_f == PageType.objects)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			else if (this.m_f == PageType.quickcommand)
			{
				this.m_an.Items.Insert(0, (object)"[Self]");
			}
			break;
		case Command.CommandType.CT_SETCHARACTION:
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Action:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_SETPLAYERACTION:
		{
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Action and State:";
			this.m_al.Items.Clear();
			for (int i = 0; i < this.m_e.ThePlayer.Actions.Count; i++)
			{
				Action action = (Action)this.m_e.ThePlayer.Actions[i];
				this.m_al.Items.Add((object)(action.name + "-Active"));
				this.m_al.Items.Add((object)(action.name + "-Inactive"));
			}
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		}
		case Command.CommandType.CT_SETROOMACTION:
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Action:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			break;
		case Command.CommandType.CT_SETLOCKEDUNLOCKED:
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "State:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			q(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bLockable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Locked");
			this.m_al.Items.Add((object)"Unlocked");
			break;
		case Command.CommandType.CT_SETOPENCLOSED:
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "State:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			p(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bOpenable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Open");
			this.m_al.Items.Add((object)"Closed");
			break;
		case Command.CommandType.CT_SETITEMTOWORN:
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "State:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			v(ref this.m_an);
			if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).bWearable)
			{
				this.m_an.Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Worn");
			this.m_al.Items.Add((object)"Removed");
			break;
		case Command.CommandType.CT_DISPLAYCHARDESC:
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "State:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_MOVECHAR:
		{
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Room:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			n(ref this.m_al);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = "<CurrentRoom>";
			this.m_al.Items.Insert(0, (object)roomComboItem2);
			roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.VoidRoomGuid;
			roomComboItem2.RoomName = "<Void>";
			this.m_al.Items.Insert(0, (object)roomComboItem2);
			break;
		}
		case Command.CommandType.CT_MOVECHARINVTOPLAYER:
		{
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Room:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			n(ref this.m_al);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = "<CurrentRoom>";
			this.m_al.Items.Insert(0, (object)roomComboItem);
			roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.VoidRoomGuid;
			roomComboItem.RoomName = "<Void>";
			this.m_al.Items.Insert(0, (object)roomComboItem);
			break;
		}
		case Command.CommandType.CT_MOVEPLAYER:
			((Control)this.m_am).Text = "Room:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Room:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			n(ref this.m_an);
			break;
		case Command.CommandType.CT_MOVETOCHAR:
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Room:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			break;
		case Command.CommandType.CT_MOVETOOBJ:
			((Control)this.m_am).Text = "Object:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Room:";
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			z(ref this.m_an);
			break;
		case Command.CommandType.CT_CHAR_MOVETOOBJ:
			((Control)this.m_am).Text = "Character:";
			((Control)this.m_am).Visible = true;
			((Control)this.m_an).Visible = true;
			((Control)this.m_aj).Text = "Object:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ak).Text = "Text to display:";
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			s(ref this.m_an);
			z(ref this.m_al);
			break;
		case Command.CommandType.CT_ENDGAME:
			((Control)this.m_am).Text = "Variable to set:";
			((Control)this.m_am).Visible = false;
			((Control)this.m_an).Visible = false;
			((Control)this.m_aj).Visible = false;
			((Control)this.m_al).Visible = false;
			((Control)this.m_ak).Text = "Text to display at completion:";
			((Control)this.m_ak).Visible = true;
			((Control)this.m_ap).Visible = true;
			((Control)this.m_ai).Visible = false;
			((Control)this.m_ah).Visible = false;
			break;
		}
	}

	private void ac(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.PictureList.Count; i++)
		{
			A_0.Items.Add((object)((GamePicture)this.m_e.PictureList[i]).TheName);
		}
	}

	private void ab(ref ComboBox A_0)
	{
		try
		{
			A_0.Items.Clear();
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeDataReader sqlCeDataReader = new SqlCeCommand("select Name from MediaGroups", dBConnection).ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				A_0.Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void aa(ref ComboBox A_0)
	{
		try
		{
			A_0.Items.Clear();
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeDataReader sqlCeDataReader = new SqlCeCommand("select Name from ItemGroups", dBConnection).ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				A_0.Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void z(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			GameObject gameObject = (GameObject)this.m_e.ObjectList[i];
			A_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void y(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (GameObject @object in this.m_e.ObjectList)
		{
			if (@object.bContainer)
			{
				A_0.Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void x(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			GameObject gameObject = (GameObject)this.m_e.ObjectList[i];
			A_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
		for (int j = 0; j < this.m_e.CharacterList.Count; j++)
		{
			A_0.Items.Add((object)((Character)this.m_e.CharacterList[j]).Charname);
		}
	}

	private void w(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			if (((GameObject)this.m_e.ObjectList[i]).bCarryable)
			{
				A_0.Items.Add((object)new RoomComboItem(((GameObject)this.m_e.ObjectList[i]).UniqueIdentifier, ((GameObject)this.m_e.ObjectList[i]).name));
			}
		}
	}

	private void v(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			if (((GameObject)this.m_e.ObjectList[i]).bWearable)
			{
				GameObject gameObject = (GameObject)this.m_e.ObjectList[i];
				A_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void u(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (Character character in this.m_e.CharacterList)
		{
			foreach (Action action4 in character.Actions)
			{
				_ = action4;
			}
		}
		foreach (GameObject @object in this.m_e.ObjectList)
		{
			foreach (Action action5 in @object.Actions)
			{
				if (action5.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Obj:" + @object.name + ":" + action5.name));
				}
			}
		}
		foreach (Action action6 in this.m_e.ThePlayer.Actions)
		{
			if (action6.InputType == Action.ActionInputType.Custom)
			{
				A_0.Items.Add((object)("Player:" + action6.name));
			}
		}
		foreach (Room room in this.m_e.RoomList)
		{
			foreach (Action action7 in room.Actions)
			{
				if (action7.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Room:" + room.Name + ":" + action7.name));
				}
			}
		}
	}

	private void t(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (Character character in this.m_e.CharacterList)
		{
			foreach (Action action6 in character.Actions)
			{
				if (action6.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Chr:" + character.Charname + ":" + action6.name));
				}
			}
		}
		foreach (GameObject @object in this.m_e.ObjectList)
		{
			foreach (Action action7 in @object.Actions)
			{
				if (action7.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Obj:" + @object.name + ":" + action7.name));
				}
			}
		}
		foreach (Action action8 in this.m_e.ThePlayer.Actions)
		{
			if (action8.InputType == Action.ActionInputType.Custom)
			{
				A_0.Items.Add((object)("Player:" + action8.name));
			}
		}
		foreach (Room room in this.m_e.RoomList)
		{
			foreach (Action action9 in room.Actions)
			{
				if (action9.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Room:" + room.Name + ":" + action9.name));
				}
			}
		}
		foreach (Timer timer in this.m_e.TimerList)
		{
			foreach (Action action10 in timer.Actions)
			{
				if (action10.InputType == Action.ActionInputType.Custom)
				{
					A_0.Items.Add((object)("Timer:" + timer.Name + ":" + action10.name));
				}
			}
		}
	}

	private void s(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.CharacterList.Count; i++)
		{
			A_0.Items.Add((object)((Character)this.m_e.CharacterList[i]).Charname);
		}
	}

	private void r(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.TimerList.Count; i++)
		{
			A_0.Items.Add((object)((Timer)this.m_e.TimerList[i]).Name);
		}
	}

	private void q(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			if (((GameObject)this.m_e.ObjectList[i]).bLockable)
			{
				GameObject gameObject = (GameObject)this.m_e.ObjectList[i];
				A_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void p(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.ObjectList.Count; i++)
		{
			if (((GameObject)this.m_e.ObjectList[i]).bOpenable)
			{
				GameObject gameObject = (GameObject)this.m_e.ObjectList[i];
				A_0.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void a(ref ComboBox A_0, Guid A_1)
	{
		A_0.Items.Clear();
		Room roomByID = this.m_e.GetRoomByID(A_1);
		if (roomByID == null)
		{
			return;
		}
		foreach (Exit exit in roomByID.Exits)
		{
			if (exit.DestinationRoom != string.Empty)
			{
				A_0.Items.Add((object)(exit.Direction.ToString() + "-Active-To:" + this.m_e.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
				A_0.Items.Add((object)(exit.Direction.ToString() + "-InActive-To:" + this.m_e.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
			}
		}
	}

	private void o(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		A_0.Items.Add((object)"North");
		A_0.Items.Add((object)"South");
		A_0.Items.Add((object)"East");
		A_0.Items.Add((object)"West");
		A_0.Items.Add((object)"Up");
		A_0.Items.Add((object)"Down");
		A_0.Items.Add((object)"NorthEast");
		A_0.Items.Add((object)"NorthWest");
		A_0.Items.Add((object)"SouthEast");
		A_0.Items.Add((object)"SouthWest");
		A_0.Items.Add((object)"In");
		A_0.Items.Add((object)"Out");
	}

	private void n(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (Room room in this.m_e.RoomList)
		{
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = room.UniqueID;
			if (room.SDesc.Trim().Length > 0)
			{
				roomComboItem.RoomName = room.Name + "-" + room.SDesc;
			}
			else
			{
				roomComboItem.RoomName = room.Name;
			}
			A_0.Items.Add((object)roomComboItem);
		}
	}

	private void m(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (string roomGroup in this.m_e.RoomGroups)
		{
			A_0.Items.Add((object)roomGroup);
		}
	}

	private void l(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		if (this.m_e.RoomList.Count <= 0)
		{
			return;
		}
		int num = 0;
		foreach (Room room in this.m_e.RoomList)
		{
			if (num == 0)
			{
				foreach (CustomProperty customProperty3 in room.CustomProperties)
				{
					A_0.Items.Add((object)("<CurrentRoom>:" + customProperty3.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty4 in room.CustomProperties)
			{
				A_0.Items.Add((object)(room.Name + ":" + customProperty4.Name));
			}
		}
	}

	private void k(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		if (this.m_e.CharacterList.Count <= 0)
		{
			return;
		}
		foreach (Character character in this.m_e.CharacterList)
		{
			foreach (CustomProperty customProperty in character.CustomProperties)
			{
				A_0.Items.Add((object)(character.Charname + ":" + customProperty.Name));
			}
		}
	}

	private void j(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		if (this.m_e.TimerList.Count <= 0)
		{
			return;
		}
		foreach (Timer timer in this.m_e.TimerList)
		{
			foreach (CustomProperty customProperty in timer.CustomProperties)
			{
				A_0.Items.Add((object)(timer.Name + ":" + customProperty.Name));
			}
		}
	}

	private void i(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		if (this.m_e.VariableList.Count <= 0)
		{
			return;
		}
		foreach (GameVariable variable in this.m_e.VariableList)
		{
			foreach (CustomProperty customProperty in variable.CustomProperties)
			{
				A_0.Items.Add((object)(variable.varname + ":" + customProperty.Name));
			}
		}
	}

	private void h(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		if (this.m_e.ObjectList.Count <= 0)
		{
			return;
		}
		int num = 0;
		foreach (GameObject @object in this.m_e.ObjectList)
		{
			if (num == 0 && this.m_f == PageType.objects)
			{
				foreach (CustomProperty customProperty3 in @object.CustomProperties)
				{
					A_0.Items.Add((object)("<Self>:" + customProperty3.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty4 in @object.CustomProperties)
			{
				A_0.Items.Add((object)(@object.name + ":" + customProperty4.Name));
			}
		}
	}

	private void g(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (CustomProperty customProperty in this.m_e.ThePlayer.CustomProperties)
		{
			A_0.Items.Add((object)customProperty.Name);
		}
	}

	private void f(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)this.m_e.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
			else
			{
				A_0.Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void e(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)this.m_e.VariableList[i];
			A_0.Items.Add((object)gameVariable.varname);
		}
	}

	private void d(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (GameVariable variable in this.m_e.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_DATETIME || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				A_0.Items.Add((object)variable.varname);
			}
			else
			{
				if (variable.vartype != GameVariable.VarType.VT_NUMBERARRAY && variable.vartype != GameVariable.VarType.VT_DATETIMEARRAY)
				{
					continue;
				}
				for (int i = 0; i < variable.VarArray.Count; i++)
				{
					if (variable.VarArray[i] is ArrayList)
					{
						A_0.Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						A_0.Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void c(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		foreach (GameVariable variable in this.m_e.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_STRING || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				A_0.Items.Add((object)variable.varname);
			}
			else
			{
				if (variable.vartype != GameVariable.VarType.VT_STRINGARRAY && variable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
				{
					continue;
				}
				for (int i = 0; i < variable.VarArray.Count; i++)
				{
					if (variable.VarArray[i] is ArrayList)
					{
						A_0.Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						A_0.Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void b(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)this.m_e.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_STRING)
			{
				A_0.Items.Add((object)gameVariable.varname);
			}
			else
			{
				if (gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
				{
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void a(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < this.m_e.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)this.m_e.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				A_0.Items.Add((object)gameVariable.varname);
			}
			else
			{
				if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
				{
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						A_0.Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void az(object A_0, EventArgs A_1)
	{
		Action action = p();
		if (action != null)
		{
			action.bActive = this.m_v.Checked;
		}
	}

	private ArrayList b(bool A_0)
	{
		ArrayList result = null;
		if (m())
		{
			result = ((!A_0) ? p().FailCommands : p().PassCommands);
		}
		else
		{
			Condition condition = q();
			if (condition != null)
			{
				result = ((!A_0) ? condition.FailCommands : condition.PassCommands);
			}
		}
		return result;
	}

	private ArrayList j()
	{
		ArrayList result = null;
		switch (this.m_f)
		{
		case PageType.characters:
			result = this.m_e.GetCharacterByName(this.m_g).Actions;
			break;
		case PageType.objects:
			result = this.m_e.GetObjectByName(this.m_g).Actions;
			break;
		case PageType.player:
			result = this.m_e.ThePlayer.Actions;
			break;
		case PageType.room:
			result = this.m_e.GetRoomByID(new Guid(this.m_g)).Actions;
			break;
		case PageType.timers:
			result = this.m_e.GetTimerByName(this.m_g).Actions;
			break;
		case PageType.quickcommand:
			result = this.m_e.GetMenuItemByName(this.m_g).Actions;
			break;
		}
		return result;
	}

	private void ay(object A_0, EventArgs A_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null && tvActionsConditions.SelectedNode.Parent != null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (condition != null)
		{
			((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).CondType = ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex;
			if (((ListControl)this.m_a2).SelectedIndex > 0)
			{
				this.m_a2.Items[((ListControl)this.m_a2).SelectedIndex] = ((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).CkType.ToString() + " " + ((Control)cbConditionStep1).Text;
			}
			else
			{
				this.m_a2.Items[((ListControl)this.m_a2).SelectedIndex] = ((Control)cbConditionStep1).Text;
			}
		}
	}

	private void ax(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode == null)
		{
			return;
		}
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (condition != null)
		{
			if (this.m_ae.SelectedItem is RoomComboItem roomComboItem)
			{
				((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep2 = roomComboItem.UniqueID.ToString();
				return;
			}
			((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep2 = ((Control)this.m_ae).Text;
			this.m_e.ValidateText(((Control)this.m_ae).Text);
		}
	}

	private void aw(object A_0, EventArgs A_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (this.m_ac.SelectedItem is RoomComboItem roomComboItem)
		{
			((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep3 = roomComboItem.UniqueID.ToString();
			return;
		}
		((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep3 = ((Control)this.m_ac).Text;
		this.m_e.ValidateText(((Control)this.m_ac).Text);
	}

	private void av(object A_0, EventArgs A_1)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Variable_Comparison || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While)
		{
			GameVariable variableByName = this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_ae).Text, null));
			if (variableByName != null && variableByName.vartype == GameVariable.VarType.VT_NUMBER)
			{
				try
				{
					Convert.ToDouble(this.m_e.PerformTextReplacements(((Control)this.m_z).Text, null));
				}
				catch
				{
					MessageBox.Show("Warning: Step 4 did not contain a valid number.");
				}
			}
		}
		if (condition != null)
		{
			((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep4 = ((Control)this.m_z).Text;
			this.m_e.ValidateText(((Control)this.m_z).Text);
		}
	}

	private void au(object A_0, EventArgs A_1)
	{
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Room_CustomPropertyCheck || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Player_CustomPropertyCheck || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Item_CustomPropertyCheck || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Character_CustomPropertyCheck || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Timer_CustomPropertyCheck || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Variable_CustomPropertyCheck)
		{
			((Control)this.m_y).Visible = true;
			((Control)this.m_ac).Visible = true;
			((Control)this.m_x).Visible = true;
			((Control)this.m_z).Visible = true;
			((Control)this.m_x).Text = "Value:";
			this.m_ac.Items.Clear();
			this.m_ac.Items.Add((object)"Equals");
			this.m_ac.Items.Add((object)"Not Equals");
			this.m_ac.Items.Add((object)"Contains");
			this.m_ac.Items.Add((object)"Greater Than");
			this.m_ac.Items.Add((object)"Less Than");
			this.m_ac.Items.Add((object)"Less Than or Equals");
			this.m_ac.Items.Add((object)"Greater Than or Equals");
		}
		else if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Variable_Comparison || ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While)
		{
			GameVariable variableByName = this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_ae).Text, null));
			if (variableByName != null)
			{
				switch (variableByName.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					((Control)this.m_y).Visible = true;
					((Control)this.m_ac).Visible = true;
					((Control)this.m_x).Visible = true;
					((Control)this.m_z).Visible = true;
					((Control)this.m_x).Text = "Value:";
					this.m_ac.Items.Clear();
					this.m_ac.Items.Add((object)"Equals");
					this.m_ac.Items.Add((object)"Not Equals");
					this.m_ac.Items.Add((object)"Greater Than");
					this.m_ac.Items.Add((object)"Greater Than or Equals");
					this.m_ac.Items.Add((object)"Less Than");
					this.m_ac.Items.Add((object)"Less Than or Equals");
					this.m_ac.Items.Add((object)"DayOfWeek Is");
					this.m_ac.Items.Add((object)"Hour Equals");
					this.m_ac.Items.Add((object)"Hour Is Greater Than");
					this.m_ac.Items.Add((object)"Hour Is Less Than");
					this.m_ac.Items.Add((object)"Minute Equals");
					this.m_ac.Items.Add((object)"Minute Is Greater Than");
					this.m_ac.Items.Add((object)"Minute Is Less Than");
					this.m_ac.Items.Add((object)"Seconds Equals");
					this.m_ac.Items.Add((object)"Seconds Is Greater Than");
					this.m_ac.Items.Add((object)"Seconds Is Less Than");
					break;
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					((Control)this.m_y).Visible = true;
					((Control)this.m_ac).Visible = true;
					((Control)this.m_x).Visible = true;
					((Control)this.m_z).Visible = true;
					((Control)this.m_x).Text = "Value:";
					this.m_ac.Items.Clear();
					this.m_ac.Items.Add((object)"Equals");
					this.m_ac.Items.Add((object)"Not Equals");
					this.m_ac.Items.Add((object)"Greater Than");
					this.m_ac.Items.Add((object)"Less Than");
					this.m_ac.Items.Add((object)"Less Than or Equals");
					this.m_ac.Items.Add((object)"Greater Than or Equals");
					break;
				case GameVariable.VarType.VT_STRING:
				case GameVariable.VarType.VT_STRINGARRAY:
					((Control)this.m_y).Visible = true;
					((Control)this.m_ac).Visible = true;
					((Control)this.m_x).Visible = true;
					((Control)this.m_z).Visible = true;
					((Control)this.m_x).Text = "Value:";
					this.m_ac.Items.Clear();
					this.m_ac.Items.Add((object)"Equals");
					this.m_ac.Items.Add((object)"Not Equals");
					this.m_ac.Items.Add((object)"Contains");
					this.m_ac.Items.Add((object)"Greater Than");
					this.m_ac.Items.Add((object)"Less Than");
					break;
				}
			}
		}
		else
		{
			if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_To_Variable_Comparison)
			{
				return;
			}
			GameVariable variableByName2 = this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_ae).Text, null));
			if (variableByName2 != null)
			{
				switch (variableByName2.vartype)
				{
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					((Control)this.m_y).Visible = true;
					((Control)this.m_ac).Visible = true;
					((Control)this.m_x).Visible = true;
					((Control)this.m_z).Visible = false;
					((Control)bi).Visible = true;
					this.m_ac.Items.Clear();
					this.m_ac.Items.Add((object)"Equals");
					this.m_ac.Items.Add((object)"Not Equals");
					this.m_ac.Items.Add((object)"Greater Than");
					this.m_ac.Items.Add((object)"Less Than");
					this.m_ac.Items.Add((object)"Less Than or Equals");
					this.m_ac.Items.Add((object)"Greater Than or Equals");
					break;
				case GameVariable.VarType.VT_STRING:
				case GameVariable.VarType.VT_STRINGARRAY:
					((Control)this.m_y).Visible = true;
					((Control)this.m_ac).Visible = true;
					((Control)this.m_x).Visible = true;
					((Control)this.m_z).Visible = false;
					((Control)bi).Visible = true;
					this.m_ac.Items.Clear();
					this.m_ac.Items.Add((object)"Equals");
					this.m_ac.Items.Add((object)"Not Equals");
					break;
				case GameVariable.VarType.VT_DATETIME:
					break;
				}
			}
		}
	}

	private void at(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode != null && cbCommandStep1.SelectedItem != null)
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			if (command != null)
			{
				command.cmdtype = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
			}
			tvActionsConditions.SelectedNode.Text = a(command);
		}
	}

	private void @as(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			if (this.m_an.SelectedItem is RoomComboItem roomComboItem)
			{
				command.CommandPart2 = roomComboItem.UniqueID.ToString();
			}
			else
			{
				command.CommandPart2 = ((Control)this.m_an).Text;
				this.m_e.ValidateText(((Control)this.m_an).Text);
			}
			tvActionsConditions.SelectedNode.Text = a(command);
		}
	}

	private void ar(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			if (this.m_al.SelectedItem is RoomComboItem roomComboItem)
			{
				command.CommandPart3 = roomComboItem.UniqueID.ToString();
			}
			else
			{
				command.CommandPart3 = ((Control)this.m_al).Text;
				this.m_e.ValidateText(((Control)this.m_al).Text);
			}
			tvActionsConditions.SelectedNode.Text = a(command);
		}
	}

	private void aq(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			command.CommandText = ((Control)this.m_ap).Text;
			tvActionsConditions.SelectedNode.Text = a(command);
			this.m_e.ValidateText(((Control)this.m_ap).Text);
		}
	}

	private void ap(object A_0, EventArgs A_1)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		Command.CommandType ctindex = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		if (ctindex == Command.CommandType.CT_SETVARIABLE || ctindex == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			if (((Control)this.m_an).Text == string.Empty)
			{
				return;
			}
			string text = this.m_e.PerformTextReplacements(((Control)this.m_an).Text, null);
			int num = text.IndexOf("Array:");
			if (num > -1)
			{
				text = text.Remove(num, 6);
			}
			GameVariable variableByName = this.m_e.GetVariableByName(text);
			if (variableByName != null)
			{
				switch (variableByName.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					if (this.m_al.SelectedItem.ToString() == "Equals")
					{
						try
						{
							Convert.ToDateTime(this.m_e.PerformTextReplacements(((Control)this.m_ah).Text, null), Game.myDTFI);
						}
						catch
						{
							MessageBox.Show("Please enter a properly formatted datetime value in step 4.");
							((Control)this.m_ah).Focus();
							return;
						}
					}
					else
					{
						try
						{
							Convert.ToInt32(this.m_e.PerformTextReplacements(((Control)this.m_ah).Text, null));
						}
						catch
						{
							MessageBox.Show("Warning: Step 4 did not contain a valid number.");
						}
					}
					break;
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					try
					{
						if (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
						{
							Convert.ToDouble(this.m_e.PerformTextReplacements(((Control)this.m_ah).Text, null));
						}
					}
					catch
					{
						MessageBox.Show("Warning: Step 4 did not contain a valid number.");
					}
					break;
				}
			}
		}
		Command command = tvActionsConditions.SelectedNode.Tag as Command;
		command.CommandPart4 = ((Control)this.m_ah).Text;
		tvActionsConditions.SelectedNode.Text = a(command);
		this.m_e.ValidateText(((Control)this.m_ah).Text);
	}

	private void ao(object A_0, EventArgs A_1)
	{
		switch (((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex)
		{
		case Command.CommandType.CT_SETVARIABLEBYINPUT:
		case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
			if (this.m_an.SelectedItem.ToString() == "Custom")
			{
				((Control)a9).Visible = true;
				((Control)ba).Visible = true;
				((Control)bc).Visible = true;
				((Control)bj).Visible = true;
				((Control)bb).Visible = true;
				bn.Panel2Collapsed = false;
			}
			else
			{
				bn.Panel2Collapsed = true;
				((Control)a9).Visible = false;
				((Control)ba).Visible = false;
				((Control)bc).Visible = false;
				((Control)bj).Visible = false;
				((Control)bb).Visible = false;
			}
			break;
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
			((Control)this.m_aj).Text = "Set Type:";
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_ai).Visible = true;
			((Control)this.m_ah).Visible = true;
			((Control)this.m_ak).Visible = false;
			((Control)this.m_ap).Visible = false;
			this.m_al.Items.Clear();
			this.m_al.Items.Add((object)"Equals");
			this.m_al.Items.Add((object)"Add");
			this.m_al.Items.Add((object)"Subtract");
			this.m_al.Items.Add((object)"Multiply");
			this.m_al.Items.Add((object)"Divide");
			break;
		case Command.CommandType.CT_SETVARIABLE:
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
		{
			if (this.m_an.SelectedItem == null)
			{
				return;
			}
			string text = this.m_e.PerformTextReplacements(((Control)this.m_an).Text, null);
			bool flag = false;
			int num = text.IndexOf("Array:");
			if (num > -1)
			{
				flag = true;
				text = text.Remove(num, 6);
			}
			GameVariable variableByName = this.m_e.GetVariableByName(text);
			if (variableByName == null)
			{
				return;
			}
			((Control)this.m_aj).Text = "Set Type:";
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				this.m_al.Items.Clear();
				this.m_al.Items.Add((object)"Equals");
				if (!flag)
				{
					this.m_al.Items.Add((object)"Add Days");
					this.m_al.Items.Add((object)"Add Hours");
					this.m_al.Items.Add((object)"Add Minutes");
					this.m_al.Items.Add((object)"Add Seconds");
					this.m_al.Items.Add((object)"Subtract Days");
					this.m_al.Items.Add((object)"Subtract Hours");
					this.m_al.Items.Add((object)"Subtract Minutes");
					this.m_al.Items.Add((object)"Subtract Seconds");
					this.m_al.Items.Add((object)"Set Day Of Month To");
					this.m_al.Items.Add((object)"Set Hours To");
					this.m_al.Items.Add((object)"Set Minutes To");
					this.m_al.Items.Add((object)"Set Seconds To");
				}
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = true;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				this.m_al.Items.Clear();
				this.m_al.Items.Add((object)"Equals");
				if (!flag)
				{
					this.m_al.Items.Add((object)"Add");
					this.m_al.Items.Add((object)"Subtract");
					this.m_al.Items.Add((object)"Multiply");
					this.m_al.Items.Add((object)"Divide");
				}
				break;
			case GameVariable.VarType.VT_STRING:
			case GameVariable.VarType.VT_STRINGARRAY:
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
				((Control)this.m_ak).Visible = true;
				((Control)this.m_ap).Visible = true;
				break;
			}
			break;
		}
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			switch (this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_an).Text, null)).vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = false;
				((Control)bh).Visible = true;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				this.m_al.Items.Clear();
				this.m_al.Items.Add((object)"Add Days");
				this.m_al.Items.Add((object)"Add Hours");
				this.m_al.Items.Add((object)"Add Minutes");
				this.m_al.Items.Add((object)"Add Seconds");
				this.m_al.Items.Add((object)"Subtract Days");
				this.m_al.Items.Add((object)"Subtract Hours");
				this.m_al.Items.Add((object)"Subtract Minutes");
				this.m_al.Items.Add((object)"Subtract Seconds");
				this.m_al.Items.Add((object)"Set Day Of Month To");
				this.m_al.Items.Add((object)"Set Hours To");
				this.m_al.Items.Add((object)"Set Minutes To");
				this.m_al.Items.Add((object)"Set Seconds To");
				break;
			case GameVariable.VarType.VT_NUMBER:
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ai).Visible = true;
				((Control)this.m_ah).Visible = false;
				((Control)bh).Visible = true;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				this.m_al.Items.Clear();
				this.m_al.Items.Add((object)"Equals");
				this.m_al.Items.Add((object)"Add");
				this.m_al.Items.Add((object)"Subtract");
				this.m_al.Items.Add((object)"Multiply");
				this.m_al.Items.Add((object)"Divide");
				break;
			}
			break;
		case Command.CommandType.CT_DISPLAYVARIABLE:
			switch (this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_an).Text, null)).vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				((Control)this.m_aj).Text = "DateTime Display Type";
				((Control)this.m_aj).Visible = true;
				((Control)this.m_al).Visible = true;
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				this.m_al.Items.Clear();
				this.m_al.Items.Add((object)"Display Date & Time");
				this.m_al.Items.Add((object)"Display Date Only");
				this.m_al.Items.Add((object)"Display Time Only");
				this.m_al.Items.Add((object)"Display Weekday Only");
				((ListControl)this.m_al).SelectedIndex = 0;
				ar(null, null);
				break;
			case GameVariable.VarType.VT_NUMBER:
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				break;
			case GameVariable.VarType.VT_STRING:
				((Control)this.m_aj).Visible = false;
				((Control)this.m_al).Visible = false;
				((Control)this.m_ai).Visible = false;
				((Control)this.m_ah).Visible = false;
				((Control)this.m_ak).Visible = false;
				((Control)this.m_ap).Visible = false;
				break;
			}
			break;
		case Command.CommandType.CT_SETOBJECTACTION:
		{
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Action and State:";
			this.m_al.Items.Clear();
			GameObject gameObject = null;
			if (this.m_an.SelectedItem.ToString() == "<<Self>>")
			{
				gameObject = this.m_e.GetObjectByName(this.m_g);
			}
			else if (this.m_an.SelectedItem.ToString() == "[Self]" && this.m_f == PageType.quickcommand)
			{
				foreach (Action action5 in this.m_e.GetMenuItemByName(this.m_g).Actions)
				{
					this.m_al.Items.Add((object)(action5.name + "-Active"));
					this.m_al.Items.Add((object)(action5.name + "-Inactive"));
				}
				gameObject = null;
			}
			else
			{
				gameObject = this.m_e.GetObjectByName(((RoomComboItem)this.m_an.SelectedItem).UniqueID.ToString());
			}
			if (gameObject != null)
			{
				for (int k = 0; k < gameObject.Actions.Count; k++)
				{
					Action action4 = (Action)gameObject.Actions[k];
					this.m_al.Items.Add((object)(action4.name + "-Active"));
					this.m_al.Items.Add((object)(action4.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETCHARACTION:
		{
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Action and State:";
			this.m_al.Items.Clear();
			Character characterByName = this.m_e.GetCharacterByName(this.m_an.SelectedItem.ToString());
			if (characterByName != null)
			{
				for (int j = 0; j < characterByName.Actions.Count; j++)
				{
					Action action2 = (Action)characterByName.Actions[j];
					this.m_al.Items.Add((object)(action2.name + "-Active"));
					this.m_al.Items.Add((object)(action2.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETROOMACTION:
		{
			((Control)this.m_aj).Visible = true;
			((Control)this.m_al).Visible = true;
			((Control)this.m_aj).Text = "Select Action and State:";
			this.m_al.Items.Clear();
			Room roomByID = this.m_e.GetRoomByID(((RoomComboItem)this.m_an.SelectedItem).UniqueID);
			if (roomByID != null)
			{
				for (int i = 0; i < roomByID.Actions.Count; i++)
				{
					Action action = (Action)roomByID.Actions[i];
					this.m_al.Items.Add((object)(action.name + "-Active"));
					this.m_al.Items.Add((object)(action.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETEXIT:
			a(ref this.m_al, ((RoomComboItem)this.m_an.SelectedItem).UniqueID);
			break;
		}
		_ = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		_ = 86;
		_ = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		_ = 41;
	}

	private void an(object A_0, EventArgs A_1)
	{
		Action action = p();
		if (action != null)
		{
			action.bConditionFailOnFirst = this.m_o.Checked;
		}
	}

	private void am(object A_0, EventArgs A_1)
	{
		Action action = p();
		if (action != null)
		{
			if (this.m_u.Checked)
			{
				action.InputType = Action.ActionInputType.None;
			}
			else if (this.m_s.Checked)
			{
				action.InputType = Action.ActionInputType.Character;
			}
			else if (this.m_r.Checked)
			{
				action.InputType = Action.ActionInputType.ObjectOrCharacter;
			}
			else if (this.m_q.Checked)
			{
				action.InputType = Action.ActionInputType.Text;
			}
			else if (this.m_t.Checked)
			{
				action.InputType = Action.ActionInputType.Object;
			}
			else if (bg.Checked)
			{
				action.InputType = Action.ActionInputType.Custom;
			}
			else if (bl.Checked)
			{
				action.InputType = Action.ActionInputType.Inventory;
			}
		}
	}

	private void al(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		if (((ToolStripItem)val).Tag != null && ((ToolStripItem)val).Tag is QuickMenuItem)
		{
			c();
			QuickMenuItem quickMenuItem = ((ToolStripItem)val).Tag as QuickMenuItem;
			{
				foreach (Action action3 in quickMenuItem.Actions)
				{
					if (quickMenuItem.bOverwrite)
					{
						ArrayList arrayList = this.j();
						for (int i = 0; i < arrayList.Count; i++)
						{
							if (action3.name == ((Action)arrayList[i]).name)
							{
								arrayList.RemoveAt(i);
								RefreshActions();
								break;
							}
						}
					}
					if (a(this.m_f, action3.name))
					{
						Clipboard.SetDataObject((object)new DataObject(ActionFormat.Name, (object)action3));
						if (!(Clipboard.GetDataObject().GetData(ActionFormat.Name) is Action action2))
						{
							continue;
						}
						for (int j = 0; j < action2.PassCommands.Count; j++)
						{
							Command A_2 = action2.PassCommands[j] as Command;
							Condition A_3 = action2.PassCommands[j] as Condition;
							if (A_2 != null)
							{
								a(ref A_2);
							}
							if (A_3 != null)
							{
								a(ref A_3);
							}
						}
						for (int k = 0; k < action2.FailCommands.Count; k++)
						{
							Command A_4 = action2.FailCommands[k] as Command;
							Condition A_5 = action2.FailCommands[k] as Condition;
							if (A_4 != null)
							{
								a(ref A_4);
							}
							if (A_5 != null)
							{
								a(ref A_5);
							}
						}
						for (int l = 0; l < action2.Conditions.Count; l++)
						{
							Condition A_6 = (Condition)action2.Conditions[l];
							a(ref A_6);
						}
						this.j().Add(action2);
						a(action2, -1, A_2: false);
						if (this.m_f != PageType.objects)
						{
							continue;
						}
						GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
						if (objectByName != null)
						{
							string text = string.Empty;
							if (quickMenuItem.bCarryable && !objectByName.bCarryable)
							{
								objectByName.bCarryable = true;
								text += "The object attribute carryable has been set.\r\n";
							}
							if (quickMenuItem.bContainer && !objectByName.bContainer)
							{
								objectByName.bContainer = true;
								text += "The object attribute container has been set.\r\n";
							}
							if (quickMenuItem.bEnterable && !objectByName.bEnterable)
							{
								objectByName.bEnterable = true;
								text += "The object attribute enterable has been set.\r\n";
							}
							if (quickMenuItem.bLockable && !objectByName.bLockable)
							{
								objectByName.bLockable = true;
								text += "The object attribute lockable has been set.\r\n";
							}
							if (quickMenuItem.bOpenable && !objectByName.bOpenable)
							{
								objectByName.bOpenable = true;
								text += "The object attribute openable has been set.\r\n";
							}
							if (quickMenuItem.bReadable && !objectByName.bReadable)
							{
								objectByName.bReadable = true;
								text += "The object attribute readable has been set.\r\n";
							}
							if (quickMenuItem.bWearable && !objectByName.bWearable)
							{
								objectByName.bWearable = true;
								text += "The object attribute wearable has been set.\r\n";
							}
							if (text != string.Empty)
							{
								MessageBox.Show(text, "Attributes Changed");
							}
						}
					}
					else
					{
						MessageBox.Show("There is already an action called " + action3.name + ".  No action was taken.");
					}
				}
				return;
			}
		}
		c();
		b(this.m_f, ((ToolStripItem)val).Text);
	}

	private void b(PageType A_0, string A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Invalid comparison between Unknown and I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected Obj, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected Obj, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Invalid comparison between Unknown and I4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected Obj, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected Obj, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected Obj, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Invalid comparison between Unknown and I4
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Expected Obj, but got Unknown
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected Obj, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected Obj, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7f: Invalid comparison between Unknown and I4
		//IL_105f: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1093: Invalid comparison between Unknown and I4
		//IL_166c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1672: Invalid comparison between Unknown and I4
		//IL_19ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d4: Invalid comparison between Unknown and I4
		switch (A_1)
		{
		case "Rename Action":
		{
			GetNameFrm getNameFrm2 = new GetNameFrm("Please Enter New Action Name:");
			if ((int)((Form)getNameFrm2).ShowDialog() == 1)
			{
				if (a(this.m_f, ((Control)getNameFrm2.txtEntry).Text))
				{
					Action action2 = p();
					TreeNode val = o();
					action2.name = ((Control)getNameFrm2.txtEntry).Text;
					val.Text = ((Control)getNameFrm2.txtEntry).Text;
				}
				else
				{
					MessageBox.Show("Sorry, that action name is already taken.  Please choose a different action name.");
				}
			}
			break;
		}
		case "Add Action":
		{
			Action action4 = null;
			if (this.m_f != PageType.timers)
			{
				GetNameFrm getNameFrm3 = new GetNameFrm("Please Enter Action Name:");
				if ((int)((Form)getNameFrm3).ShowDialog() == 1)
				{
					if (a(A_0, ((Control)getNameFrm3.txtEntry).Text))
					{
						action4 = new Action();
						action4.name = ((Control)getNameFrm3.txtEntry).Text;
						j().Add(action4);
						TreeNode val2 = new TreeNode(action4.name, 0, 0);
						val2.Tag = action4;
						val2.ForeColor = Color.DarkBlue;
						tvActionsConditions.Nodes.Add(val2);
						TreeNode val3 = new TreeNode("Commands on Success", 5, 5);
						val2.Nodes.Add(val3);
						val3.ForeColor = Color.Gray;
						TreeNode val4 = new TreeNode("Commands on Failure", 4, 4);
						val2.Nodes.Add(val4);
						val4.ForeColor = Color.Gray;
						tvActionsConditions.SelectedNode = val2;
					}
					else
					{
						MessageBox.Show("Sorry, that action name already exists.");
					}
					break;
				}
				return;
			}
			if (this.m_e.GetTimerByName(this.m_g).TType == Timer.TimerType.TT_RUNALWAYS)
			{
				MessageBox.Show("There are no more available actions for a timer set to run always.  If you'd like to change the timer type, please go to the timer's general page.");
				break;
			}
			AddTimerActionsFrm addTimerActionsFrm = new AddTimerActionsFrm(this.m_e.GetTimerByName(this.m_g).Length);
			if ((int)((Form)addTimerActionsFrm).ShowDialog() != 1)
			{
				break;
			}
			foreach (string selectedItem in addTimerActionsFrm.lbTimerActions.SelectedItems)
			{
				action4 = new Action();
				action4.name = selectedItem;
				j().Add(action4);
				TreeNode val5 = new TreeNode(action4.name, 0, 0);
				val5.Tag = action4;
				val5.ForeColor = Color.DarkBlue;
				tvActionsConditions.Nodes.Add(val5);
				TreeNode val6 = new TreeNode("Commands on Success", 5, 5);
				val5.Nodes.Add(val6);
				val6.ForeColor = Color.Gray;
				TreeNode val7 = new TreeNode("Commands on Failure", 4, 4);
				val5.Nodes.Add(val7);
				val7.ForeColor = Color.Gray;
				tvActionsConditions.SelectedNode = val5;
			}
			break;
		}
		case "Copy Action":
		{
			Action action3 = p();
			if (action3 != null)
			{
				Clipboard.SetDataObject((object)new DataObject(ActionFormat.Name, (object)action3));
			}
			break;
		}
		case "Expand All":
			tvActionsConditions.ExpandAll();
			break;
		case "Collapse All":
			tvActionsConditions.CollapseAll();
			break;
		case "Paste Action":
			if (!(Clipboard.GetDataObject().GetData(ActionFormat.Name) is Action action))
			{
				break;
			}
			if (a(A_0, action.name))
			{
				j().Add(action);
				a(action, -1, A_2: true);
			}
			else
			{
				if ((int)MessageBox.Show("There is already an action name " + action.name + ".  Would you like to rename this action?", "Duplicate Name", (MessageBoxButtons)4) != 6)
				{
					break;
				}
				GetNameFrm getNameFrm = new GetNameFrm("Please Enter Action Name:");
				if ((int)((Form)getNameFrm).ShowDialog() == 1)
				{
					if (a(A_0, ((Control)getNameFrm.txtEntry).Text))
					{
						action.name = ((Control)getNameFrm.txtEntry).Text;
						j().Add(action);
						a(action, -1, A_2: true);
					}
					else
					{
						MessageBox.Show("Sorry, that action name already exists.");
					}
				}
			}
			break;
		case "Copy Condition":
		{
			Condition condition = q();
			if (condition != null)
			{
				Clipboard.SetDataObject((object)new DataObject(ConditonFormat.Name, (object)condition));
			}
			break;
		}
		case "Paste Condition":
			if (Clipboard.GetDataObject().GetData(ConditonFormat.Name) is Condition)
			{
				g();
			}
			break;
		case "Copy Command":
			if (tvActionsConditions.SelectedNode.Tag is Command command)
			{
				Clipboard.SetDataObject((object)new DataObject(CommandFormat.Name, (object)command));
			}
			break;
		case "Paste Command":
			if (tvActionsConditions.SelectedNode.Tag is Condition || tvActionsConditions.SelectedNode.Tag is Action)
			{
				MessageBox.Show("Sorry, you can't paste a command here.");
				return;
			}
			if (Clipboard.GetDataObject().GetData(CommandFormat.Name) is Command command2)
			{
				ArrayList arrayList = b(tvActionsConditions.SelectedNode.Parent.Text == "Commands on Success" || tvActionsConditions.SelectedNode.Text == "Commands on Success");
				if (arrayList != null)
				{
					arrayList.Add(command2);
					a(command2, n());
				}
			}
			break;
		case "Delete Action":
			switch (A_0)
			{
			case PageType.objects:
			{
				GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
				if (objectByName != null)
				{
					Action obj4 = p();
					objectByName.Actions.Remove(obj4);
				}
				break;
			}
			case PageType.player:
			{
				Action obj = p();
				this.m_e.ThePlayer.Actions.Remove(obj);
				break;
			}
			case PageType.characters:
			{
				Character characterByName = this.m_e.GetCharacterByName(this.m_g);
				if (characterByName != null)
				{
					Action obj2 = p();
					characterByName.Actions.Remove(obj2);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = this.m_e.GetRoomByID(new Guid(this.m_g));
				if (roomByID != null)
				{
					Action obj5 = p();
					roomByID.Actions.Remove(obj5);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = this.m_e.GetTimerByName(this.m_g);
				if (timerByName != null)
				{
					Action obj3 = p();
					timerByName.Actions.Remove(obj3);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName = this.m_e.GetMenuItemByName(this.m_g);
				if (menuItemByName != null)
				{
					Action actionByName = menuItemByName.GetActionByName(tvActionsConditions.SelectedNode.Text);
					if (actionByName != null)
					{
						menuItemByName.Actions.Remove(actionByName);
					}
				}
				break;
			}
			}
			tvActionsConditions.Nodes.Remove(o());
			break;
		}
		switch (A_1)
		{
		case "Delete Condition":
		{
			if (tvActionsConditions.SelectedNode.Tag == null || !(tvActionsConditions.SelectedNode.Tag.GetType() == typeof(Condition)))
			{
				break;
			}
			if (tvActionsConditions.SelectedNode.Level <= 1)
			{
				p().Conditions.Remove(q());
				o().Nodes.Remove(tvActionsConditions.SelectedNode);
				break;
			}
			TreeNode selectedNode = tvActionsConditions.SelectedNode;
			object tag = tvActionsConditions.SelectedNode.Tag;
			if (this.m_d && tvActionsConditions.SelectedNode.Tag is Condition && tvActionsConditions.SelectedNode.Level != 2)
			{
				tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
			}
			ArrayList arrayList4 = b(f());
			if (arrayList4 != null)
			{
				tvActionsConditions.SelectedNode = selectedNode;
				arrayList4.Remove(tag);
				e().Nodes.Remove(tvActionsConditions.SelectedNode);
			}
			break;
		}
		case "Add Condition":
		{
			GetNameFrm getNameFrm4 = new GetNameFrm("Please Enter Condition Name:");
			if ((int)((Form)getNameFrm4).ShowDialog() != 1)
			{
				break;
			}
			Condition condition2 = null;
			TreeNode val8 = null;
			if (tvActionsConditions.SelectedNode.Level == 0)
			{
				val8 = o();
				Action action8 = p();
				if (action8 != null)
				{
					condition2 = new Condition(((Control)getNameFrm4.txtEntry).Text);
					((Check)condition2.Checks[0]).CondType = Condition.ConditionType.CT_Item_Held_By_Player;
					action8.Conditions.Add(condition2);
				}
			}
			else
			{
				ArrayList arrayList3 = b(f());
				condition2 = new Condition(((Control)getNameFrm4.txtEntry).Text);
				((Check)condition2.Checks[0]).CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				arrayList3.Add(condition2);
				val8 = e();
			}
			TreeNode val9 = new TreeNode(((Control)getNameFrm4.txtEntry).Text, 2, 2);
			val9.Tag = condition2;
			val9.ForeColor = Color.DarkRed;
			if (m())
			{
				val8.Nodes.Insert(val8.Nodes.Count - 2, val9);
			}
			else
			{
				val8.Nodes.Add(val9);
			}
			TreeNode val10 = new TreeNode("Commands on Success", 5, 5);
			val9.Nodes.Add(val10);
			val10.ForeColor = Color.Gray;
			TreeNode val11 = new TreeNode("Commands on Failure", 4, 4);
			val9.Nodes.Add(val11);
			val11.ForeColor = Color.Gray;
			tvActionsConditions.SelectedNode = val9;
			break;
		}
		case "Add Command On Success":
			ai(null, null);
			break;
		case "Add Command On Failure":
			ak(null, null);
			break;
		case "Delete Command":
			aj(null, null);
			break;
		case "Examine":
		{
			Action action7 = null;
			switch (A_0)
			{
			case PageType.characters:
			{
				Character characterByName2 = this.m_e.GetCharacterByName(this.m_g);
				if (characterByName2 != null && a(A_0, "Examine"))
				{
					action7 = new Action();
					characterByName2.Actions.Add(action7);
					action7.name = "Examine";
					action7.bActive = true;
					Command command6 = new Command();
					action7.PassCommands.Add(command6);
					command6.CommandName = "Display Char Data";
					command6.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
					command6.CommandPart2 = characterByName2.Charname;
				}
				break;
			}
			case PageType.objects:
			{
				GameObject objectByName3 = this.m_e.GetObjectByName(this.m_g);
				if (objectByName3 != null && a(A_0, "Examine"))
				{
					action7 = new Action();
					objectByName3.Actions.Add(action7);
					action7.name = "Examine";
					action7.bActive = true;
					Command command7 = new Command();
					action7.PassCommands.Add(command7);
					command7.CommandName = "Display Item Data";
					command7.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
					command7.CommandPart2 = objectByName3.name;
				}
				break;
			}
			case PageType.player:
				if (a(A_0, "Examine"))
				{
					action7 = new Action();
					this.m_e.ThePlayer.Actions.Add(action7);
					action7.name = "Examine";
					action7.bActive = true;
					Command command8 = new Command();
					action7.PassCommands.Add(command8);
					command8.CommandName = "Display Player Description";
					command8.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
				}
				break;
			case PageType.room:
			{
				Room roomByID2 = this.m_e.GetRoomByID(new Guid(this.m_g));
				if (roomByID2 != null && a(A_0, "Examine"))
				{
					action7 = new Action();
					roomByID2.Actions.Add(action7);
					action7.name = "Examine";
					action7.bActive = true;
					Command command5 = new Command();
					action7.PassCommands.Add(command5);
					command5.CommandName = "Display Room Data";
					command5.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
					command5.CommandPart2 = Room.CurrentRoomGuid.ToString();
					command5 = new Command();
					action7.PassCommands.Add(command5);
					command5.CommandName = "Display Room Pic";
					command5.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
					command5.CommandPart2 = Room.CurrentRoomGuid.ToString();
				}
				break;
			}
			}
			a(action7, -1, A_2: true);
			break;
		}
		case "Open/Close":
		{
			ArrayList arrayList5 = j();
			string text2 = this.m_g;
			if (this.m_f == PageType.objects)
			{
				GameObject objectByName4 = this.m_e.GetObjectByName(this.m_g);
				if (!objectByName4.bOpenable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as openable.  Would you like to make this object openable?", "Not Openable", (MessageBoxButtons)4) != 6)
					{
						break;
					}
					objectByName4.bOpenable = true;
				}
			}
			if (a(A_0, "Open"))
			{
				Action action9 = new Action();
				arrayList5.Add(action9);
				action9.name = "Open";
				action9.bActive = true;
				Command command9 = new Command();
				action9.PassCommands.Add(command9);
				command9.CommandName = "Set Item To Open";
				command9.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command9.CommandPart2 = text2;
				command9.CommandPart3 = "Open";
				command9 = new Command();
				command9.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command9.CommandName = "Display Result";
				command9.CommandText = "The " + text2 + " is now open.";
				action9.PassCommands.Add(command9);
				Condition condition3 = new Condition("Check For Open");
				action9.Conditions.Add(condition3);
				Check obj6 = condition3.Checks[0] as Check;
				obj6.CondType = Condition.ConditionType.CT_Item_State_Check;
				obj6.ConditionStep2 = text2;
				obj6.ConditionStep3 = "Closed";
				command9 = new Command();
				command9.CommandName = "Display already open";
				command9.CommandText = "The " + text2 + " is already open.";
				command9.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition3.FailCommands.Add(command9);
				a(action9, -1, A_2: true);
			}
			if (a(A_0, "Close"))
			{
				Action action10 = new Action();
				arrayList5.Add(action10);
				action10.name = "Close";
				action10.bActive = true;
				Command command10 = new Command();
				action10.PassCommands.Add(command10);
				command10.CommandName = "Set Item To Closed";
				command10.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command10.CommandPart2 = text2;
				command10.CommandPart3 = "Closed";
				command10 = new Command();
				command10.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command10.CommandName = "Display Result";
				command10.CommandText = "The " + text2 + " is now closed.";
				action10.PassCommands.Add(command10);
				Condition condition4 = new Condition("Check For Closed");
				action10.Conditions.Add(condition4);
				Check obj7 = condition4.Checks[0] as Check;
				obj7.CondType = Condition.ConditionType.CT_Item_State_Check;
				obj7.ConditionStep2 = text2;
				obj7.ConditionStep3 = "Open";
				command10 = new Command();
				command10.CommandName = "Display already closed";
				command10.CommandText = "The " + text2 + " is already closed.";
				command10.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition4.FailCommands.Add(command10);
				a(action10, -1, A_2: true);
			}
			break;
		}
		case "Action Wizard...":
			ah(null, null);
			break;
		case "Wear/Remove":
		{
			ArrayList arrayList6 = null;
			string text3 = "";
			if (A_0 != PageType.objects)
			{
				MessageBox.Show("You may only wear object types.");
				break;
			}
			GameObject objectByName5 = this.m_e.GetObjectByName(this.m_g);
			if (!objectByName5.bWearable)
			{
				if ((int)MessageBox.Show("This object is not currently marked as wearable.  Would you like to make this object wearable?", "Not Wearable", (MessageBoxButtons)4) != 6)
				{
					break;
				}
				objectByName5.bWearable = true;
			}
			arrayList6 = objectByName5.Actions;
			text3 = objectByName5.name;
			if (a(A_0, "Wear"))
			{
				Action action11 = new Action();
				arrayList6.Add(action11);
				action11.name = "Wear";
				action11.bActive = true;
				Command command11 = new Command();
				action11.PassCommands.Add(command11);
				command11.CommandName = "Set Item To Worn";
				command11.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command11.CommandPart2 = text3;
				command11.CommandPart3 = "Worn";
				command11 = new Command();
				command11.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command11.CommandName = "Enable Remove";
				command11.CommandPart2 = this.m_g;
				command11.CommandPart3 = "Remove-Active";
				action11.PassCommands.Add(command11);
				command11 = new Command();
				command11.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command11.CommandName = "Disable Wear";
				command11.CommandPart2 = this.m_g;
				command11.CommandPart3 = "Wear-Inactive";
				action11.PassCommands.Add(command11);
				command11 = new Command();
				command11.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command11.CommandName = "Display Result";
				if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).preposition != string.Empty)
				{
					command11.CommandText = "You are now wearing " + this.m_e.GetObjectByName(this.m_g).preposition + " " + text3 + ".";
				}
				else
				{
					command11.CommandText = "You are now wearing the " + text3 + ".";
				}
				action11.PassCommands.Add(command11);
				Condition condition5 = new Condition("Item must be in inventory");
				action11.Conditions.Add(condition5);
				Check obj8 = condition5.Checks[0] as Check;
				obj8.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				obj8.ConditionStep2 = text3;
				obj8.ConditionStep3 = "Open";
				command11 = new Command();
				command11.CommandName = "Display not held";
				if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).preposition != string.Empty)
				{
					command11.CommandText = "You must get " + this.m_e.GetObjectByName(this.m_g).preposition + " " + text3 + ".";
				}
				else
				{
					command11.CommandText = "You must get the " + text3 + " first.";
				}
				command11.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition5.FailCommands.Add(command11);
				a(action11, -1, A_2: true);
			}
			if (a(A_0, "Remove"))
			{
				Action action12 = new Action();
				arrayList6.Add(action12);
				action12.name = "Remove";
				action12.bActive = false;
				Command command12 = new Command();
				action12.PassCommands.Add(command12);
				command12.CommandName = "Set Item To Removed";
				command12.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command12.CommandPart2 = text3;
				command12.CommandPart3 = "Removed";
				command12 = new Command();
				command12.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command12.CommandName = "Enable Wear";
				command12.CommandPart2 = this.m_g;
				command12.CommandPart3 = "Wear-Active";
				action12.PassCommands.Add(command12);
				command12 = new Command();
				command12.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command12.CommandName = "Disable Remove";
				command12.CommandPart2 = this.m_g;
				command12.CommandPart3 = "Remove-Inactive";
				action12.PassCommands.Add(command12);
				command12 = new Command();
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command12.CommandName = "Display Result";
				if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).preposition != string.Empty)
				{
					command12.CommandText = "You have now removed " + this.m_e.GetObjectByName(this.m_g).preposition + " " + text3 + ".";
				}
				else
				{
					command12.CommandText = "You have now removed " + text3 + ".";
				}
				action12.PassCommands.Add(command12);
				Condition condition6 = new Condition("Item must be currently worn");
				action12.Conditions.Add(condition6);
				Check obj9 = condition6.Checks[0] as Check;
				obj9.CondType = Condition.ConditionType.CT_Item_State_Check;
				obj9.ConditionStep2 = text3;
				obj9.ConditionStep3 = "Worn";
				command12 = new Command();
				command12.CommandName = "Display not worn";
				if (this.m_f == PageType.objects && this.m_e.GetObjectByName(this.m_g).preposition != string.Empty)
				{
					command12.CommandText = "You are not wearing " + this.m_e.GetObjectByName(this.m_g).preposition + " " + text3 + ".";
				}
				else
				{
					command12.CommandText = "You are not wearing " + text3 + ".";
				}
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition6.FailCommands.Add(command12);
				a(action12, -1, A_2: true);
			}
			break;
		}
		case "Lock/Unlock":
		{
			if (this.m_f == PageType.objects)
			{
				GameObject objectByName6 = this.m_e.GetObjectByName(this.m_g);
				if (!objectByName6.bLockable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as lockable.  Would you like to make this object lockable?", "Not Lockable", (MessageBoxButtons)4) != 6)
					{
						break;
					}
					objectByName6.bLockable = true;
				}
			}
			ArrayList arrayList7 = null;
			string text4 = "";
			switch (A_0)
			{
			case PageType.objects:
				arrayList7 = this.m_e.GetObjectByName(this.m_g).Actions;
				text4 = this.m_e.GetObjectByName(this.m_g).name;
				break;
			case PageType.characters:
				arrayList7 = this.m_e.GetCharacterByName(this.m_g).Actions;
				text4 = this.m_e.GetCharacterByName(this.m_g).Charname;
				break;
			}
			if (a(A_0, "Lock"))
			{
				Action action13 = new Action();
				arrayList7.Add(action13);
				action13.name = "Lock";
				action13.bActive = true;
				Command command13 = new Command();
				action13.PassCommands.Add(command13);
				command13.CommandName = "Set Item To Locked";
				command13.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command13.CommandPart2 = text4;
				command13.CommandPart3 = "Locked";
				command13 = new Command();
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command13.CommandName = "Display Result";
				command13.CommandText = "The " + text4 + " is now locked.";
				action13.PassCommands.Add(command13);
				Condition condition7 = new Condition("Check For Locked");
				action13.Conditions.Add(condition7);
				Check obj10 = condition7.Checks[0] as Check;
				obj10.CondType = Condition.ConditionType.CT_Item_State_Check;
				obj10.ConditionStep2 = text4;
				obj10.ConditionStep3 = "Unlocked";
				command13 = new Command();
				command13.CommandName = "Display already locked";
				command13.CommandText = "The " + text4 + " is already locked.";
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition7.FailCommands.Add(command13);
				a(action13, -1, A_2: true);
			}
			if (a(A_0, "Unlock"))
			{
				Action action14 = new Action();
				arrayList7.Add(action14);
				action14.name = "Unlock";
				action14.bActive = true;
				Command command14 = new Command();
				action14.PassCommands.Add(command14);
				command14.CommandName = "Set Item To Unlocked";
				command14.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command14.CommandPart2 = text4;
				command14.CommandPart3 = "Unlocked";
				command14 = new Command();
				command14.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command14.CommandName = "Display Result";
				command14.CommandText = "The " + text4 + " is now unlocked.";
				action14.PassCommands.Add(command14);
				Condition condition8 = new Condition("Check For Unlocked");
				action14.Conditions.Add(condition8);
				Check obj11 = condition8.Checks[0] as Check;
				obj11.CondType = Condition.ConditionType.CT_Item_State_Check;
				obj11.ConditionStep2 = text4;
				obj11.ConditionStep3 = "Locked";
				command14 = new Command();
				command14.CommandName = "Display already unlocked";
				command14.CommandText = "The " + text4 + " is already unlocked.";
				command14.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition8.FailCommands.Add(command14);
				a(action14, -1, A_2: true);
			}
			break;
		}
		case "Take/Drop":
		{
			if (this.m_f == PageType.objects)
			{
				GameObject objectByName2 = this.m_e.GetObjectByName(this.m_g);
				if (!objectByName2.bCarryable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as carryable.  Would you like to make this object carryable?", "Not Carryable", (MessageBoxButtons)4) != 6)
					{
						break;
					}
					objectByName2.bCarryable = true;
				}
			}
			ArrayList arrayList2 = null;
			string text = "";
			switch (A_0)
			{
			case PageType.objects:
				arrayList2 = this.m_e.GetObjectByName(this.m_g).Actions;
				text = this.m_e.GetObjectByName(this.m_g).name;
				break;
			case PageType.characters:
				arrayList2 = this.m_e.GetCharacterByName(this.m_g).Actions;
				text = this.m_e.GetCharacterByName(this.m_g).Charname;
				break;
			}
			if (a(A_0, "Take"))
			{
				Action action5 = new Action();
				arrayList2.Add(action5);
				action5.name = "Take";
				action5.bActive = true;
				Command command3 = new Command();
				action5.PassCommands.Add(command3);
				command3.CommandName = "Pick Item Up";
				command3.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
				command3.CommandPart2 = text;
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command3.CommandName = "Display Result";
				command3.CommandText = "You pick up the " + text + ".";
				action5.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Enable Drop";
				command3.CommandPart2 = this.m_g;
				command3.CommandPart3 = "Drop-Active";
				action5.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Disable Take";
				command3.CommandPart2 = this.m_g;
				command3.CommandPart3 = "Take-Inactive";
				action5.PassCommands.Add(command3);
				a(action5, -1, A_2: true);
			}
			if (a(A_0, "Drop"))
			{
				Action action6 = new Action();
				arrayList2.Add(action6);
				action6.name = "Drop";
				action6.bActive = false;
				Command command4 = new Command();
				action6.PassCommands.Add(command4);
				command4.CommandName = "Drop Item";
				command4.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
				command4.CommandPart2 = text;
				command4.CommandPart3 = Room.CurrentRoomGuid.ToString();
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command4.CommandName = "Display Result";
				command4.CommandText = "You dropped the " + text + ".";
				action6.PassCommands.Add(command4);
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Enable Take";
				command4.CommandPart2 = text;
				command4.CommandPart3 = "Take-Active";
				action6.PassCommands.Add(command4);
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Disable Drop";
				command4.CommandPart2 = text;
				command4.CommandPart3 = "Drop-Inactive";
				action6.PassCommands.Add(command4);
				a(action6, -1, A_2: true);
			}
			break;
		}
		}
	}

	private void a(ref Command A_0)
	{
		string text = string.Empty;
		if (A_0.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY || A_0.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
		{
			text = this.m_e.GetObjectByName(this.m_g).name;
		}
		else if (A_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY || A_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
		{
			text = this.m_e.GetRoomByID(new Guid(this.m_g)).Name;
		}
		else if (A_0.cmdtype == Command.CommandType.CT_SETVARIABLE || A_0.cmdtype == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			text = h();
		}
		for (int num = A_0.CommandPart2.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart2.ToUpper().IndexOf("[SELF]"))
		{
			Command obj = A_0;
			obj.CommandPart2 = obj.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj2 = A_0;
				obj2.CommandPart2 = obj2.CommandPart2.Insert(num, text);
			}
			else
			{
				Command obj3 = A_0;
				obj3.CommandPart2 = obj3.CommandPart2.Insert(num, h());
			}
		}
		for (int num = A_0.CommandPart2.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart2.ToUpper().IndexOf("[NAME]"))
		{
			Command obj4 = A_0;
			obj4.CommandPart2 = obj4.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj5 = A_0;
				obj5.CommandPart2 = obj5.CommandPart2.Insert(num, text);
			}
			else
			{
				Command obj6 = A_0;
				obj6.CommandPart2 = obj6.CommandPart2.Insert(num, h());
			}
		}
		for (int num = A_0.CommandPart3.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart3.ToUpper().IndexOf("[SELF]"))
		{
			Command obj7 = A_0;
			obj7.CommandPart3 = obj7.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj8 = A_0;
				obj8.CommandPart3 = obj8.CommandPart3.Insert(num, text);
			}
			else
			{
				Command obj9 = A_0;
				obj9.CommandPart3 = obj9.CommandPart3.Insert(num, h());
			}
		}
		for (int num = A_0.CommandPart3.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart3.ToUpper().IndexOf("[NAME]"))
		{
			Command obj10 = A_0;
			obj10.CommandPart3 = obj10.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj11 = A_0;
				obj11.CommandPart3 = obj11.CommandPart3.Insert(num, text);
			}
			else
			{
				Command obj12 = A_0;
				obj12.CommandPart3 = obj12.CommandPart3.Insert(num, h());
			}
		}
		for (int num = A_0.CommandPart4.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart4.ToUpper().IndexOf("[SELF]"))
		{
			Command obj13 = A_0;
			obj13.CommandPart4 = obj13.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj14 = A_0;
				obj14.CommandPart4 = obj14.CommandPart4.Insert(num, text);
			}
			else
			{
				Command obj15 = A_0;
				obj15.CommandPart4 = obj15.CommandPart4.Insert(num, h());
			}
		}
		for (int num = A_0.CommandPart4.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart4.ToUpper().IndexOf("[NAME]"))
		{
			Command obj16 = A_0;
			obj16.CommandPart4 = obj16.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj17 = A_0;
				obj17.CommandPart4 = obj17.CommandPart4.Insert(num, text);
			}
			else
			{
				Command obj18 = A_0;
				obj18.CommandPart4 = obj18.CommandPart4.Insert(num, h());
			}
		}
		for (int num = A_0.CommandText.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandText.ToUpper().IndexOf("[SELF]"))
		{
			Command obj19 = A_0;
			obj19.CommandText = obj19.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj20 = A_0;
				obj20.CommandText = obj20.CommandText.Insert(num, text);
			}
			else
			{
				Command obj21 = A_0;
				obj21.CommandText = obj21.CommandText.Insert(num, i());
			}
		}
		for (int num = A_0.CommandText.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandText.ToUpper().IndexOf("[NAME]"))
		{
			Command obj22 = A_0;
			obj22.CommandText = obj22.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				Command obj23 = A_0;
				obj23.CommandText = obj23.CommandText.Insert(num, text);
			}
			else
			{
				Command obj24 = A_0;
				obj24.CommandText = obj24.CommandText.Insert(num, h());
			}
		}
	}

	private string i()
	{
		string result = string.Empty;
		switch (this.m_f)
		{
		case PageType.characters:
			result = this.m_e.GetCharacterByName(this.m_g).ToString();
			break;
		case PageType.objects:
			result = this.m_e.GetObjectByName(this.m_g).GetDisplayStringNameOnly();
			break;
		case PageType.room:
			result = this.m_e.GetRoomByID(new Guid(this.m_g)).Name;
			break;
		}
		return result;
	}

	private string h()
	{
		string result = string.Empty;
		switch (this.m_f)
		{
		case PageType.characters:
			result = this.m_e.GetCharacterByName(this.m_g).Charname;
			break;
		case PageType.objects:
			result = this.m_e.GetObjectByName(this.m_g).name;
			break;
		case PageType.room:
			result = this.m_e.GetRoomByID(new Guid(this.m_g)).Name;
			break;
		}
		return result;
	}

	private void a(ref Condition A_0)
	{
		for (int i = 0; i < A_0.Checks.Count; i++)
		{
			Check check = (Check)A_0.Checks[i];
			string text = string.Empty;
			if (check.CondType == Condition.ConditionType.CT_Item_CustomPropertyCheck)
			{
				text = this.m_e.GetObjectByName(this.m_g).name;
			}
			else if (check.CondType == Condition.ConditionType.CT_Room_CustomPropertyCheck)
			{
				text = this.m_e.GetRoomByID(new Guid(this.m_g)).Name;
			}
			int num = check.ConditionStep2.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, h());
				}
			}
			num = check.ConditionStep2.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, h());
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, h());
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, h());
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, h());
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, h());
				}
			}
		}
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command A_1 = A_0.PassCommands[j] as Command;
			Condition A_2 = A_0.PassCommands[j] as Condition;
			if (A_1 != null)
			{
				a(ref A_1);
			}
			if (A_2 != null)
			{
				a(ref A_2);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command A_3 = A_0.FailCommands[k] as Command;
			Condition A_4 = A_0.FailCommands[k] as Condition;
			if (A_3 != null)
			{
				a(ref A_3);
			}
			if (A_4 != null)
			{
				a(ref A_4);
			}
		}
	}

	private bool a(PageType A_0, string A_1)
	{
		bool result = true;
		switch (A_0)
		{
		case PageType.objects:
		{
			GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
			if (objectByName != null)
			{
				for (int l = 0; l < objectByName.Actions.Count; l++)
				{
					if (string.Compare(A_1, ((Action)objectByName.Actions[l]).name) == 0)
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
			for (int k = 0; k < this.m_e.ThePlayer.Actions.Count; k++)
			{
				if (string.Compare(A_1, ((Action)this.m_e.ThePlayer.Actions[k]).name) == 0)
				{
					result = false;
					break;
				}
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = this.m_e.GetCharacterByName(this.m_g);
			if (characterByName != null)
			{
				for (int j = 0; j < characterByName.Actions.Count; j++)
				{
					if (string.Compare(A_1, ((Action)characterByName.Actions[j]).name) == 0)
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
		case PageType.room:
		{
			Room roomByID = this.m_e.GetRoomByID(new Guid(this.m_g));
			if (roomByID != null)
			{
				for (int m = 0; m < roomByID.Actions.Count; m++)
				{
					if (string.Compare(A_1, ((Action)roomByID.Actions[m]).name) == 0)
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
		case PageType.timers:
		{
			Timer timerByName = this.m_e.GetTimerByName(this.m_g);
			if (timerByName != null)
			{
				for (int i = 0; i < timerByName.Actions.Count; i++)
				{
					if (string.Compare(A_1, ((Action)timerByName.Actions[i]).name) == 0)
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
		}
		return result;
	}

	private void ak(object A_0, EventArgs A_1)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		if (tvActionsConditions.SelectedNode.Tag is Condition)
		{
			tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Nodes[0];
		}
		ArrayList arrayList = b(A_0: false);
		Command command = new Command
		{
			cmdtype = Command.CommandType.CT_DISPLAYTEXT
		};
		arrayList.Add(command);
		TreeNode val = a(A_0: false);
		TreeNode val2 = new TreeNode(Command.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), 3, 3);
		val2.Tag = command;
		val2.ForeColor = Color.DarkGoldenrod;
		val.Nodes.Add(val2);
		tvActionsConditions.SelectedNode = val2;
		cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, Command.CommandType.CT_DISPLAYTEXT);
		a0(null, null);
	}

	private TreeNode a(bool A_0)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Obj, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		TreeNode val = null;
		if (m())
		{
			val = tvActionsConditions.SelectedNode;
			while (val.Parent != null)
			{
				val = val.Parent;
			}
			if (A_0)
			{
				foreach (TreeNode node in val.Nodes)
				{
					TreeNode val2 = node;
					if (val2.Text == "Commands on Success")
					{
						val = val2;
						break;
					}
				}
			}
			else
			{
				foreach (TreeNode node2 in val.Nodes)
				{
					TreeNode val3 = node2;
					if (val3.Text == "Commands on Failure")
					{
						val = val3;
						break;
					}
				}
			}
		}
		else
		{
			if (tvActionsConditions.SelectedNode.Level >= 1)
			{
				if (!(tvActionsConditions.SelectedNode.Tag is Condition))
				{
					TreeNode val4 = tvActionsConditions.SelectedNode;
					while (!(val4.Tag is Condition))
					{
						val4 = val4.Parent;
					}
					val = val4;
				}
				else
				{
					val = tvActionsConditions.SelectedNode;
				}
			}
			if (A_0)
			{
				foreach (TreeNode node3 in val.Nodes)
				{
					TreeNode val5 = node3;
					if (val5.Text == "Commands on Success")
					{
						val = val5;
						break;
					}
				}
			}
			else
			{
				foreach (TreeNode node4 in val.Nodes)
				{
					TreeNode val6 = node4;
					if (val6.Text == "Commands on Failure")
					{
						val = val6;
						break;
					}
				}
			}
		}
		return val;
	}

	private void aj(object A_0, EventArgs A_1)
	{
		b(tvActionsConditions.SelectedNode.Parent.Text == "Commands on Success").Remove(tvActionsConditions.SelectedNode.Tag);
		tvActionsConditions.SelectedNode.Parent.Nodes.Remove(tvActionsConditions.SelectedNode);
		b((object)null, (TreeViewEventArgs)null);
	}

	private void ai(object A_0, EventArgs A_1)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		if (tvActionsConditions.SelectedNode.Tag is Condition)
		{
			tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Nodes[0];
		}
		ArrayList arrayList = b(A_0: true);
		Command command = null;
		command = new Command
		{
			cmdtype = Command.CommandType.CT_DISPLAYTEXT
		};
		arrayList.Add(command);
		TreeNode val = a(A_0: true);
		TreeNode val2 = new TreeNode(Command.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), 3, 3);
		val2.Tag = command;
		val2.ForeColor = Color.DarkGoldenrod;
		val.Nodes.Add(val2);
		tvActionsConditions.SelectedNode = val2;
		cbCommandStep1.SelectedItem = Command.GetCommandItem(cbCommandStep1, Command.CommandType.CT_DISPLAYTEXT);
		a0(null, null);
	}

	private void a(Condition A_0, TreeNode A_1, int A_2)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		TreeNode val = new TreeNode(A_0.conditionname, 2, 2);
		val.Tag = A_0;
		val.ForeColor = Color.DarkRed;
		TreeNode val2 = new TreeNode("Commands on Success", 5, 5);
		val.Nodes.Add(val2);
		val2.ForeColor = Color.Gray;
		TreeNode val3 = new TreeNode("Commands on Failure", 4, 4);
		val.Nodes.Add(val3);
		val3.ForeColor = Color.Gray;
		for (int i = 0; i < A_0.PassCommands.Count; i++)
		{
			if (A_0.PassCommands[i] is Command a_)
			{
				a(a_, val2);
			}
			else if (A_0.PassCommands[i] is Condition a_2)
			{
				a(a_2, val2, -1);
			}
		}
		for (int j = 0; j < A_0.FailCommands.Count; j++)
		{
			if (A_0.FailCommands[j] is Command a_3)
			{
				a(a_3, val3);
			}
			else if (A_0.FailCommands[j] is Condition a_4)
			{
				a(a_4, val3, -1);
			}
		}
		if (A_2 == -1)
		{
			A_1.Nodes.Add(val);
		}
		else
		{
			A_1.Nodes.Insert(A_2, val);
		}
		tvActionsConditions.SelectedNode = val;
	}

	private void a(Command A_0, TreeNode A_1)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		TreeNode val = new TreeNode(a(A_0), 3, 3);
		val.Tag = A_0;
		val.ForeColor = Color.DarkGoldenrod;
		A_1.Nodes.Add(val);
	}

	private void a(Action A_0, int A_1, bool A_2)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		if (A_0 == null)
		{
			return;
		}
		TreeNode val = new TreeNode(A_0.name, 0, 0);
		val.Tag = A_0;
		val.ForeColor = Color.DarkBlue;
		for (int i = 0; i < A_0.Conditions.Count; i++)
		{
			a((Condition)A_0.Conditions[i], val, -1);
		}
		TreeNode val2 = new TreeNode("Commands on Success", 5, 5);
		val.Nodes.Add(val2);
		val2.ForeColor = Color.Gray;
		TreeNode val3 = new TreeNode("Commands on Failure", 4, 4);
		val.Nodes.Add(val3);
		val3.ForeColor = Color.Gray;
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command command = A_0.PassCommands[j] as Command;
			Condition condition = A_0.PassCommands[j] as Condition;
			if (command != null)
			{
				a(command, val2);
			}
			else if (condition != null)
			{
				a(condition, val2, -1);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command command2 = A_0.FailCommands[k] as Command;
			Condition condition2 = A_0.FailCommands[k] as Condition;
			if (command2 != null)
			{
				a(command2, val3);
			}
			else if (condition2 != null)
			{
				a(condition2, val3, -1);
			}
		}
		if (A_1 == -1)
		{
			tvActionsConditions.Nodes.Add(val);
		}
		else
		{
			tvActionsConditions.Nodes.Insert(A_1, val);
		}
		if (A_2)
		{
			tvActionsConditions.SelectedNode = val;
		}
	}

	public void RefreshActions()
	{
		((Control)tvActionsConditions).Enabled = true;
		tvActionsConditions.Nodes.Clear();
		ArrayList arrayList = j();
		try
		{
			tvActionsConditions.BeginUpdate();
			for (int i = 0; i < arrayList.Count; i++)
			{
				Action a_ = (Action)arrayList[i];
				a(a_, -1, A_2: false);
			}
		}
		finally
		{
			tvActionsConditions.EndUpdate();
		}
		tvActionsConditions.ExpandAll();
		r();
	}

	private void ah(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new AddActionWizard()).ShowDialog();
	}

	private void ag(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode.Tag is Condition condition)
		{
			condition.conditionname = ((Control)this.m_aa).Text;
			tvActionsConditions.SelectedNode.Text = ((Control)this.m_aa).Text;
		}
	}

	private void af(object A_0, EventArgs A_1)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition == null)
		{
			return;
		}
		bool flag = false;
		foreach (Check check3 in condition.Checks)
		{
			if (check3.CondType == Condition.ConditionType.CT_Loop_While || check3.CondType == Condition.ConditionType.CT_Loop_Rooms || check3.CondType == Condition.ConditionType.CT_Loop_Characters || check3.CondType == Condition.ConditionType.CT_Loop_Items)
			{
				flag = true;
				MessageBox.Show("Sorry, you can not add additional checks to a loop.");
				break;
			}
		}
		if (!flag)
		{
			Check check2 = new Check();
			check2.CkType = CheckType.And;
			int selectedIndex = q().Checks.Add(check2);
			a(q());
			((ListControl)this.m_a2).SelectedIndex = selectedIndex;
		}
	}

	private void ae(object A_0, EventArgs A_1)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition == null)
		{
			return;
		}
		bool flag = false;
		foreach (Check check3 in condition.Checks)
		{
			if (check3.CondType == Condition.ConditionType.CT_Loop_While || check3.CondType == Condition.ConditionType.CT_Loop_Rooms || check3.CondType == Condition.ConditionType.CT_Loop_Characters || check3.CondType == Condition.ConditionType.CT_Loop_Items)
			{
				flag = true;
				MessageBox.Show("Sorry, you can not add additional checks to a loop.");
				break;
			}
		}
		if (!flag)
		{
			Check check2 = new Check();
			check2.CkType = CheckType.Or;
			int selectedIndex = q().Checks.Add(check2);
			a(q());
			((ListControl)this.m_a2).SelectedIndex = selectedIndex;
		}
	}

	private void ad(object A_0, EventArgs A_1)
	{
		if (((ListControl)this.m_a2).SelectedIndex <= -1 || !(q().Checks[((ListControl)this.m_a2).SelectedIndex] is Check check))
		{
			return;
		}
		cbConditionStep1.SelectedItem = Condition.GetConditionItem(cbConditionStep1, check.CondType);
		try
		{
			Guid guid = new Guid(check.ConditionStep2);
			foreach (RoomComboItem item in this.m_ae.Items)
			{
				if (item.UniqueID == guid)
				{
					this.m_ae.SelectedItem = item;
					break;
				}
			}
		}
		catch
		{
			((Control)this.m_ae).Text = check.ConditionStep2;
		}
		try
		{
			Guid guid2 = new Guid(check.ConditionStep3);
			foreach (RoomComboItem item2 in this.m_ac.Items)
			{
				if (item2.UniqueID == guid2)
				{
					this.m_ac.SelectedItem = item2;
					break;
				}
			}
		}
		catch
		{
			((Control)this.m_ac).Text = check.ConditionStep3;
		}
		((Control)this.m_z).Text = check.ConditionStep4;
		((Control)bi).Text = check.ConditionStep4;
		a1(null, null);
	}

	private void ac(object A_0, EventArgs A_1)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (((ListControl)this.m_a2).SelectedIndex == 0)
		{
			MessageBox.Show("You cannot delete the initial check in the list.");
			return;
		}
		q().Checks.RemoveAt(((ListControl)this.m_a2).SelectedIndex);
		this.m_a2.Items.RemoveAt(((ListControl)this.m_a2).SelectedIndex);
		((ListControl)this.m_a2).SelectedIndex = 0;
	}

	private void h(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_d && tvActionsConditions.SelectedNode != null)
		{
			((Control)this).DoDragDrop((object)"tvNode", (DragDropEffects)(-2147483645));
		}
		if (tvActionsConditions.SelectedNode != null)
		{
			_ = A_1.Location;
		}
	}

	private void f(object A_0, DragEventArgs A_1)
	{
		A_1.Effect = (DragDropEffects)0;
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat) || !((string)A_1.Data.GetData(DataFormats.StringFormat) == "tvNode"))
		{
			return;
		}
		TreeViewHitTestInfo val = tvActionsConditions.HitTest(((Control)tvActionsConditions).PointToClient(new Point(A_1.X, A_1.Y)));
		if (val.Node == null)
		{
			return;
		}
		if (val.Node.Tag is Command || val.Node.Text == "Commands on Success" || val.Node.Text == "Commands on Failure")
		{
			if (tvActionsConditions.SelectedNode.Tag is Command || tvActionsConditions.SelectedNode.Tag is Condition)
			{
				A_1.Effect = (DragDropEffects)(-2147483645);
			}
		}
		else if (val.Node.Tag is Condition)
		{
			if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				A_1.Effect = (DragDropEffects)(-2147483645);
			}
		}
		else if (val.Node.Tag is Action)
		{
			if (tvActionsConditions.SelectedNode.Tag is Action)
			{
				A_1.Effect = (DragDropEffects)(-2147483645);
			}
			if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				A_1.Effect = (DragDropEffects)(-2147483645);
			}
		}
	}

	private void g()
	{
		TreeNode val = null;
		ArrayList arrayList = null;
		int num = 0;
		Action action = p();
		if (tvActionsConditions.SelectedNode.Level <= 1)
		{
			arrayList = action.Conditions;
			val = o();
			num = 0;
		}
		else
		{
			TreeNode val2 = null;
			if (tvActionsConditions.SelectedNode.Tag != null)
			{
				val2 = tvActionsConditions.SelectedNode;
				tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
			}
			arrayList = b(f());
			if (val2 != null)
			{
				tvActionsConditions.SelectedNode = val2;
			}
			val = e();
			num = 0;
		}
		Condition condition = Clipboard.GetDataObject().GetData(ConditonFormat.Name) as Condition;
		if (arrayList.Count == 0)
		{
			arrayList.Add(condition);
		}
		else
		{
			arrayList.Insert(num, condition);
		}
		a(condition, val, num);
	}

	private void e(object A_0, DragEventArgs A_1)
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		c();
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		TreeViewHitTestInfo val = tvActionsConditions.HitTest(((Control)tvActionsConditions).PointToClient(new Point(A_1.X, A_1.Y)));
		if (tvActionsConditions.SelectedNode.Tag is Command command)
		{
			Command command2 = val.Node.Tag as Command;
			if (command2 == command)
			{
				return;
			}
			if (command2 != null || val.Node.Text == "Commands on Success" || val.Node.Text == "Commands on Failure")
			{
				b(this.m_f, "Copy Command");
				b(this.m_f, "Delete Command");
				tvActionsConditions.SelectedNode = val.Node;
				int i = 0;
				ArrayList arrayList = b(tvActionsConditions.SelectedNode.Parent.Text == "Commands on Success" || tvActionsConditions.SelectedNode.Text == "Commands on Success");
				if (command2 != null)
				{
					for (i = 0; i < arrayList.Count && (arrayList[i] as Command != command2 || !(arrayList[i] is Command)); i++)
					{
					}
				}
				Command command3 = Clipboard.GetDataObject().GetData(CommandFormat.Name) as Command;
				arrayList.Insert(i, command3);
				TreeNode val2 = new TreeNode(a(command3), 3, 3);
				val2.Tag = command3;
				val2.ForeColor = Color.DarkGoldenrod;
				if (command2 != null)
				{
					val.Node.Parent.Nodes.Insert(i, val2);
				}
				else
				{
					val.Node.Nodes.Insert(i, val2);
				}
			}
		}
		if (tvActionsConditions.SelectedNode.Tag is Condition condition)
		{
			Condition condition2 = val.Node.Tag as Condition;
			if (condition2 == condition)
			{
				return;
			}
			Command command4 = val.Node.Tag as Command;
			TreeNode val3 = null;
			ArrayList arrayList2 = null;
			b(this.m_f, "Copy Condition");
			b(this.m_f, "Delete Condition");
			tvActionsConditions.SelectedNode = val.Node;
			int num = 0;
			Action action = p();
			if (val.Node.Level <= 1)
			{
				arrayList2 = action.Conditions;
				val3 = o();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else
				{
					for (num = 0; num < arrayList2.Count && (Condition)action.Conditions[num] != condition2; num++)
					{
					}
				}
			}
			else
			{
				TreeNode val4 = null;
				if (tvActionsConditions.SelectedNode.Tag != null)
				{
					val4 = tvActionsConditions.SelectedNode;
					tvActionsConditions.SelectedNode = tvActionsConditions.SelectedNode.Parent;
				}
				arrayList2 = b(f());
				if (val4 != null)
				{
					tvActionsConditions.SelectedNode = val4;
				}
				val3 = e();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else
				{
					for (num = 0; num < arrayList2.Count && (arrayList2[num] as Command != command4 || !(arrayList2[num] is Command)) && (arrayList2[num] as Condition != condition2 || !(arrayList2[num] is Condition)); num++)
					{
					}
				}
			}
			Condition condition3 = Clipboard.GetDataObject().GetData(ConditonFormat.Name) as Condition;
			if (arrayList2.Count == 0)
			{
				arrayList2.Add(condition3);
			}
			else
			{
				arrayList2.Insert(num, condition3);
			}
			a(condition3, val3, num);
		}
		if (!(tvActionsConditions.SelectedNode.Tag is Action action2))
		{
			return;
		}
		Action action3 = val.Node.Tag as Action;
		if (action3 != action2)
		{
			b(this.m_f, "Copy Action");
			b(this.m_f, "Delete Action");
			tvActionsConditions.SelectedNode = val.Node;
			int num2 = 0;
			ArrayList arrayList3 = j();
			for (num2 = 0; num2 < arrayList3.Count && (Action)arrayList3[num2] != action3; num2++)
			{
			}
			num2++;
			Action action4 = Clipboard.GetDataObject().GetData(ActionFormat.Name) as Action;
			arrayList3.Insert(num2, action4);
			a(action4, num2, A_2: true);
		}
	}

	private void ab(object A_0, EventArgs A_1)
	{
		Command.CommandType ctindex = ((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex;
		if (ctindex != Command.CommandType.CT_SETVARIABLE && ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			return;
		}
		string text = this.m_e.PerformTextReplacements(((Control)this.m_an).Text, null);
		int num = text.IndexOf("Array:");
		if (num > -1)
		{
			text = text.Remove(num, 6);
		}
		GameVariable variableByName = this.m_e.GetVariableByName(text);
		if (variableByName.vartype == GameVariable.VarType.VT_DATETIME && this.m_al.SelectedItem.ToString() == "Equals")
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			if (command.CommandPart4 == string.Empty)
			{
				((Control)this.m_ah).Text = variableByName.dtDateTime.ToString();
				ap(null, null);
			}
			else
			{
				((Control)this.m_ah).Text = command.CommandPart4;
			}
		}
	}

	private void aa(object A_0, EventArgs A_1)
	{
		if (((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Variable_Comparison && ((CommandConditionComboItem)cbConditionStep1.SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
		{
			return;
		}
		GameVariable variableByName = this.m_e.GetVariableByName(this.m_e.PerformTextReplacements(((Control)this.m_ae).Text, null));
		if (variableByName == null)
		{
			return;
		}
		GameVariable.VarType vartype = variableByName.vartype;
		if (vartype != GameVariable.VarType.VT_DATETIME)
		{
			return;
		}
		if (((Check)q().Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep4 == string.Empty)
		{
			switch (this.m_e.PerformTextReplacements(((Control)this.m_ac).Text, null))
			{
			case "Equals":
			case "Not Equals":
			case "Greater Than":
			case "Less Than":
				((Control)this.m_z).Text = variableByName.dtDateTime.ToString();
				break;
			case "DayOfWeek Is":
				((Control)this.m_z).Text = "Monday";
				break;
			default:
				((Control)this.m_z).Text = "1";
				break;
			}
		}
		else
		{
			((Control)this.m_z).Text = ((Check)q().Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep4;
		}
		av(null, null);
	}

	private void z(object A_0, EventArgs A_1)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm("Enter choice:", ref this.m_e);
		if ((int)((Form)getNameFrm).ShowDialog() != 1 || !(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty) || !(tvActionsConditions.SelectedNode.Tag is Command command))
		{
			return;
		}
		if (command.cmdtype == Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT)
		{
			try
			{
				Convert.ToDouble(((Control)getNameFrm.txtEntry).Text);
				ba.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
				command.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
				return;
			}
			catch
			{
				MessageBox.Show("Sorry, you must enter a valid number.");
				return;
			}
		}
		ba.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
		command.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
	}

	private void y(object A_0, EventArgs A_1)
	{
		for (int num = ba.SelectedItems.Count - 1; num >= 0; num--)
		{
			string text = ba.SelectedItems[num].ToString();
			if (tvActionsConditions.SelectedNode.Tag is Command command)
			{
				command.CustomChoices.Remove(text);
			}
			ba.Items.Remove((object)text);
		}
	}

	private void x(object A_0, EventArgs A_1)
	{
		if (bg.Checked)
		{
			((Control)bd).Enabled = true;
			((Control)bf).Enabled = true;
			((Control)br).Enabled = true;
			((Control)be).Enabled = true;
			((Control)bk).Enabled = true;
			((Control)bs).Enabled = true;
		}
	}

	private void w(object A_0, EventArgs A_1)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		GetNameFrm getNameFrm = new GetNameFrm("Enter choice:", ref this.m_e);
		if ((int)((Form)getNameFrm).ShowDialog() == 1 && ((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty)
		{
			bf.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
			if (tvActionsConditions.SelectedNode.Tag is Action action)
			{
				action.CustomChoices.Add(((Control)getNameFrm.txtEntry).Text);
			}
		}
	}

	private void v(object A_0, EventArgs A_1)
	{
		for (int num = bf.SelectedItems.Count - 1; num >= 0; num--)
		{
			string text = bf.SelectedItems[num].ToString();
			if (tvActionsConditions.SelectedNode.Tag is Action action)
			{
				action.CustomChoices.Remove(text);
			}
			bf.Items.Remove((object)text);
		}
	}

	private void u(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode != null)
		{
			Command command = tvActionsConditions.SelectedNode.Tag as Command;
			if (bh.SelectedItem is RoomComboItem roomComboItem)
			{
				command.CommandPart4 = roomComboItem.UniqueID.ToString();
			}
			else
			{
				command.CommandPart4 = ((Control)bh).Text;
			}
			tvActionsConditions.SelectedNode.Text = a(command);
		}
	}

	private void t(object A_0, EventArgs A_1)
	{
		Condition condition = tvActionsConditions.SelectedNode.Tag as Condition;
		if (condition == null)
		{
			condition = tvActionsConditions.SelectedNode.Parent.Tag as Condition;
		}
		p();
		((Check)condition.Checks[((ListControl)this.m_a2).SelectedIndex]).ConditionStep4 = ((Control)bi).Text;
	}

	private void s(object A_0, EventArgs A_1)
	{
	}

	public string insertVariableToolStripMenuItem()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref this.m_e);
		TextHandlers.PopulateVariableMenu(ref tempfrm, ref this.m_e);
		if ((int)((Form)tempfrm).ShowDialog() == 1)
		{
			switch (tempfrm.tabControl1.SelectedIndex)
			{
			case 0:
				if (tempfrm.lbSysVariables.SelectedItem != null)
				{
					result = tempfrm.lbSysVariables.SelectedItem.ToString();
				}
				break;
			case 1:
				if (tempfrm.lbVariables.SelectedItem != null)
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

	private void r(object A_0, EventArgs A_1)
	{
		this.m_c = A_0;
	}

	private void a(object A_0, KeyPressEventArgs A_1)
	{
	}

	private void b(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = val2.SelectionStart;
		}
		if (val != null)
		{
			startIndex = ((TextBoxBase)val).SelectionStart;
		}
		string text = insertVariableToolStripMenuItem();
		if (text != string.Empty)
		{
			if (val != null)
			{
				((Control)val).Text = ((Control)val).Text.Insert(startIndex, text);
			}
			else if (val2 != null)
			{
				((Control)val2).Text = ((Control)val2).Text.Insert(startIndex, text);
			}
		}
	}

	private void g(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			this.m_h = true;
		}
	}

	private void f(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_h && bf.SelectedItems.Count > 0)
		{
			((Control)this).DoDragDrop((object)"lbActionCustomChoices", (DragDropEffects)(-2147483645));
		}
	}

	private void e(object A_0, MouseEventArgs A_1)
	{
		this.m_h = false;
	}

	private void d(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "lbActionCustomChoices")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void c(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			int num = bf.IndexFromPoint(((Control)bf).PointToClient(new Point(A_1.X, A_1.Y)));
			if (num > -1)
			{
				Action action = p();
				int selectedIndex = ((ListControl)bf).SelectedIndex;
				string value = action.CustomChoices[selectedIndex].ToString();
				action.CustomChoices.RemoveAt(selectedIndex);
				action.CustomChoices.Insert(num, value);
				r();
			}
		}
	}

	private void d(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			this.m_i = true;
		}
	}

	private void c(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_i && ba.SelectedItems.Count > 0)
		{
			((Control)this).DoDragDrop((object)"lbCustomChoices", (DragDropEffects)(-2147483645));
		}
	}

	private void b(object A_0, MouseEventArgs A_1)
	{
		this.m_i = false;
	}

	private void b(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "lbCustomChoices")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void a(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			int num = ba.IndexFromPoint(((Control)ba).PointToClient(new Point(A_1.X, A_1.Y)));
			if (num > -1 && tvActionsConditions.SelectedNode.Tag is Command command)
			{
				int selectedIndex = ((ListControl)ba).SelectedIndex;
				string value = command.CustomChoices[selectedIndex].ToString();
				command.CustomChoices.RemoveAt(selectedIndex);
				command.CustomChoices.Insert(num, value);
				r();
			}
		}
	}

	private void q(object A_0, EventArgs A_1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (((ListControl)ba).SelectedIndex <= -1)
		{
			return;
		}
		int selectedIndex = ((ListControl)ba).SelectedIndex;
		GetNameFrm getNameFrm = new GetNameFrm("Update Custom Choice:", ref this.m_e);
		((Control)getNameFrm.txtEntry).Text = ba.SelectedItem.ToString();
		if ((int)((Form)getNameFrm).ShowDialog() == 1 && ((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty)
		{
			if (tvActionsConditions.SelectedNode.Tag is Command command)
			{
				command.CustomChoices.RemoveAt(selectedIndex);
				command.CustomChoices.Insert(selectedIndex, ((Control)getNameFrm.txtEntry).Text);
			}
			r();
		}
	}

	private void p(object A_0, EventArgs A_1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (((ListControl)bf).SelectedIndex <= -1)
		{
			return;
		}
		int selectedIndex = ((ListControl)bf).SelectedIndex;
		GetNameFrm getNameFrm = new GetNameFrm("Update Custom Choice:", ref this.m_e);
		((Control)getNameFrm.txtEntry).Text = bf.SelectedItem.ToString();
		if ((int)((Form)getNameFrm).ShowDialog() == 1 && ((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty)
		{
			if (tvActionsConditions.SelectedNode.Tag is Action action)
			{
				action.CustomChoices.RemoveAt(selectedIndex);
				action.CustomChoices.Insert(selectedIndex, ((Control)getNameFrm.txtEntry).Text);
			}
			r();
		}
	}

	private bool f()
	{
		bool result = false;
		TreeNode val = tvActionsConditions.SelectedNode;
		string text = val.Text;
		while (text != "Commands on Success" && text != "Commands on Failure" && val.Parent != null)
		{
			val = val.Parent;
			text = val.Text;
		}
		if (text == "Commands on Success")
		{
			result = true;
		}
		return result;
	}

	private TreeNode e()
	{
		TreeNode val = tvActionsConditions.SelectedNode;
		string text = val.Text;
		while (val.Parent != null && !(text == "Commands on Success") && !(text == "Commands on Failure"))
		{
			val = val.Parent;
			text = val.Text;
		}
		return val;
	}

	private void d()
	{
		IDataObject dataObject = Clipboard.GetDataObject();
		if (dataObject.GetData(CommandFormat.Name) is Command)
		{
			b(this.m_f, "Paste Command");
		}
		else if (dataObject.GetData(ConditonFormat.Name) is Condition)
		{
			b(this.m_f, "Paste Condition");
		}
		else if (dataObject.GetData(ActionFormat.Name) is Action)
		{
			b(this.m_f, "Paste Action");
		}
	}

	private void c()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		switch (this.m_f)
		{
		case PageType.objects:
		{
			GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
			if (objectByName != null)
			{
				binaryFormatter.Serialize(memoryStream, objectByName.Actions);
			}
			break;
		}
		case PageType.player:
			binaryFormatter.Serialize(memoryStream, this.m_e.ThePlayer.Actions);
			break;
		case PageType.room:
		{
			Room roomByID = this.m_e.GetRoomByID(new Guid(this.m_g));
			if (roomByID != null)
			{
				binaryFormatter.Serialize(memoryStream, roomByID.Actions);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = this.m_e.GetCharacterByName(this.m_g);
			if (characterByName != null)
			{
				binaryFormatter.Serialize(memoryStream, characterByName.Actions);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = this.m_e.GetTimerByName(this.m_g);
			if (timerByName != null)
			{
				binaryFormatter.Serialize(memoryStream, timerByName.Actions);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = this.m_e.GetMenuItemByName(this.m_g);
			if (menuItemByName != null)
			{
				binaryFormatter.Serialize(memoryStream, menuItemByName.Actions);
			}
			break;
		}
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		this.m_j = (ArrayList)binaryFormatter.Deserialize(memoryStream);
	}

	private void b()
	{
		if (this.m_j == null)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream();
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(memoryStream, this.m_j);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		switch (this.m_f)
		{
		case PageType.objects:
		{
			GameObject objectByName = this.m_e.GetObjectByName(this.m_g);
			if (objectByName != null)
			{
				objectByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.player:
			this.m_e.ThePlayer.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			break;
		case PageType.room:
		{
			Room roomByID = this.m_e.GetRoomByID(new Guid(this.m_g));
			if (roomByID != null)
			{
				roomByID.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = this.m_e.GetCharacterByName(this.m_g);
			if (characterByName != null)
			{
				characterByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = this.m_e.GetTimerByName(this.m_g);
			if (timerByName != null)
			{
				timerByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = this.m_e.GetMenuItemByName(this.m_g);
			if (menuItemByName != null)
			{
				menuItemByName.Actions = (ArrayList)binaryFormatter.Deserialize(memoryStream);
			}
			break;
		}
		}
		RefreshActions();
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Invalid comparison between Unknown and I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Invalid comparison between Unknown and I4
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Invalid comparison between Unknown and I4
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Invalid comparison between Unknown and I4
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Invalid comparison between Unknown and I4
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Invalid comparison between Unknown and I4
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Invalid comparison between Unknown and I4
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Invalid comparison between Unknown and I4
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Invalid comparison between Unknown and I4
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Invalid comparison between Unknown and I4
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Invalid comparison between Unknown and I4
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Invalid comparison between Unknown and I4
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Invalid comparison between Unknown and I4
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Invalid comparison between Unknown and I4
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Invalid comparison between Unknown and I4
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Invalid comparison between Unknown and I4
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Invalid comparison between Unknown and I4
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Invalid comparison between Unknown and I4
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Invalid comparison between Unknown and I4
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Invalid comparison between Unknown and I4
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData == 131158)
		{
			c();
			d();
		}
		if ((int)A_1.KeyData == 131162)
		{
			b();
		}
		else if ((int)A_1.KeyData == 131139)
		{
			if (tvActionsConditions.SelectedNode.Tag is Command)
			{
				b(this.m_f, "Copy Command");
			}
			else if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				b(this.m_f, "Copy Condition");
			}
			else if (tvActionsConditions.SelectedNode.Tag is Action)
			{
				b(this.m_f, "Copy Action");
			}
		}
		else if ((int)A_1.KeyData == 131160)
		{
			c();
			if (tvActionsConditions.SelectedNode.Tag is Command)
			{
				b(this.m_f, "Copy Command");
				b(this.m_f, "Delete Command");
			}
			else if (tvActionsConditions.SelectedNode.Tag is Condition)
			{
				b(this.m_f, "Copy Condition");
				b(this.m_f, "Delete Condition");
			}
			else if (tvActionsConditions.SelectedNode.Tag is Action)
			{
				b(this.m_f, "Copy Action");
				b(this.m_f, "Delete Action");
			}
		}
		else if ((int)A_1.KeyData == 46)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				c();
				if (tvActionsConditions.SelectedNode.Tag is Command)
				{
					b(this.m_f, "Delete Command");
				}
				else if (tvActionsConditions.SelectedNode.Tag is Condition)
				{
					b(this.m_f, "Delete Condition");
				}
				else if (tvActionsConditions.SelectedNode.Tag is Action)
				{
					b(this.m_f, "Delete Action");
				}
			}
		}
		else if ((int)A_1.KeyData == 196656)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(0, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196657)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(1, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196658)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(2, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196659)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(3, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196660)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(4, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196661)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(5, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196662)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(6, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196663)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(7, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196664)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(8, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 196665)
		{
			if (tvActionsConditions.SelectedNode != null && tvActionsConditions.SelectedNode.Tag != null)
			{
				this.m_e.AssignHotKey(9, tvActionsConditions.SelectedNode.Tag);
			}
		}
		else if ((int)A_1.KeyData == 131120)
		{
			if (this.m_e.SetClipboardData(0))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131121)
		{
			if (this.m_e.SetClipboardData(1))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131122)
		{
			if (this.m_e.SetClipboardData(2))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131123)
		{
			if (this.m_e.SetClipboardData(3))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131124)
		{
			if (this.m_e.SetClipboardData(4))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131125)
		{
			if (this.m_e.SetClipboardData(5))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131126)
		{
			if (this.m_e.SetClipboardData(6))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131127)
		{
			if (this.m_e.SetClipboardData(7))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131128)
		{
			if (this.m_e.SetClipboardData(8))
			{
				c();
				d();
			}
		}
		else if ((int)A_1.KeyData == 131129 && this.m_e.SetClipboardData(9))
		{
			c();
			d();
		}
	}

	private void o(object A_0, EventArgs A_1)
	{
		((Control)bm).Height = 190;
		((Control)bm).Width = ((Control)this.m_ag).Width - 10;
	}

	private void n(object A_0, EventArgs A_1)
	{
		((Control)bm).Height = 69;
		((Control)bm).Width = ((Control)this.m_an).Width;
	}

	private void a(object A_0, TreeViewEventArgs A_1)
	{
		if (bm.SelectedNode == null)
		{
			return;
		}
		Command.CommandType commandType = Command.CommandType.CT_UNINITIALIZED;
		try
		{
			commandType = (Command.CommandType)bm.SelectedNode.Tag;
		}
		catch
		{
			commandType = Command.CommandType.CT_UNINITIALIZED;
		}
		if (commandType != Command.CommandType.CT_UNINITIALIZED)
		{
			((Control)bm).Height = 69;
			((Control)bm).Width = ((Control)this.m_an).Width;
			if (commandType == Command.CommandType.CT_SETVARIABLEBYINPUT)
			{
				bn.Panel2Collapsed = false;
				((Control)a9).Visible = true;
				((Control)ba).Visible = true;
				((Control)bc).Visible = true;
				((Control)bj).Visible = true;
				((Control)bb).Visible = true;
			}
			else
			{
				bn.Panel2Collapsed = true;
				((Control)a9).Visible = false;
				((Control)ba).Visible = false;
				((Control)bc).Visible = false;
				((Control)bj).Visible = false;
				((Control)bb).Visible = false;
			}
			bm.TopNode = bm.SelectedNode.Parent;
		}
	}

	private void m(object A_0, EventArgs A_1)
	{
	}

	private void l(object A_0, EventArgs A_1)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		HelpFrm helpFrm = new HelpFrm();
		((Control)helpFrm.lblTitle).Text = ((Control)cbCommandStep1).Text;
		((TextBoxBase)helpFrm.rtText).AppendText(Command.GetCommandHelpText(((CommandConditionComboItem)cbCommandStep1.SelectedItem).ctindex));
		((Form)helpFrm).ShowDialog();
		((Component)(object)helpFrm).Dispose();
	}

	private void k(object A_0, EventArgs A_1)
	{
	}

	private void j(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode.Tag is Action action)
		{
			action.CustomChoiceTitle = ((Control)br).Text;
		}
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		TextBox control = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox control2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		RagsEditor ragsEditor = null;
		if (control != null)
		{
			ragsEditor = new RagsEditor(ref control, this.m_e);
		}
		else if (control2 != null)
		{
			ragsEditor = new RagsEditor(ref control2, this.m_e);
		}
		if (ragsEditor != null)
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void i(object A_0, EventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		TextBox control = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox control2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		RagsEditor ragsEditor = null;
		if (control != null)
		{
			ragsEditor = new RagsEditor(ref control, this.m_e);
		}
		else if (control2 != null)
		{
			ragsEditor = new RagsEditor(ref control2, this.m_e);
		}
		if (ragsEditor != null)
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void h(object A_0, EventArgs A_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		ComboBox control = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		if (this.m_b == control)
		{
			TimeSpan timeSpan = DateTime.Now - this.m_a;
			TimeSpan timeSpan2 = TimeSpan.FromMilliseconds((double)SystemInformation.DoubleClickTime);
			if (timeSpan.TotalMilliseconds <= timeSpan2.TotalMilliseconds)
			{
				RagsEditor ragsEditor = new RagsEditor(ref control, this.m_e);
				if (ragsEditor != null)
				{
					((Form)ragsEditor).ShowDialog();
				}
			}
		}
		else
		{
			this.m_b = control;
		}
		this.m_a = DateTime.Now;
	}

	private void g(object A_0, EventArgs A_1)
	{
		if (this.m_u.Checked)
		{
			((Control)bd).Enabled = false;
			((Control)bf).Enabled = false;
			((Control)br).Enabled = false;
			((Control)be).Enabled = false;
			((Control)bk).Enabled = false;
			((Control)bs).Enabled = false;
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		RadioButton val = (RadioButton)A_0;
		if (val != null && val.Checked)
		{
			((Control)bd).Enabled = true;
			((Control)bf).Enabled = false;
			((Control)br).Enabled = true;
			((Control)be).Enabled = false;
			((Control)bk).Enabled = false;
			((Control)bs).Enabled = false;
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		((Form)new AdvancedOverlayFrm(ref p().EnhInputData, ref this.m_e)).ShowDialog();
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedNode.Tag is Command command)
		{
			((Form)new AdvancedOverlayFrm(ref command.EnhInputData, ref this.m_e)).ShowDialog();
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (tvActionsConditions.SelectedNode.Tag is Action action)
		{
			action.overridename = ((Control)bw).Text;
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		p().actionparent = ((Control)by).Text;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_k != null)
		{
			this.m_k.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void a()
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
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Obj, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected Obj, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected Obj, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected Obj, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected Obj, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected Obj, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected Obj, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected Obj, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected Obj, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected Obj, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected Obj, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected Obj, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected Obj, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected Obj, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected Obj, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected Obj, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected Obj, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected Obj, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected Obj, but got Unknown
		//IL_0fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Expected Obj, but got Unknown
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_105f: Expected Obj, but got Unknown
		//IL_106c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1076: Expected Obj, but got Unknown
		//IL_1083: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Expected Obj, but got Unknown
		//IL_109a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a4: Expected Obj, but got Unknown
		//IL_10b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bb: Expected Obj, but got Unknown
		//IL_10c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d2: Expected Obj, but got Unknown
		//IL_10e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ed: Expected Obj, but got Unknown
		//IL_19b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19be: Expected Obj, but got Unknown
		//IL_1bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd8: Expected Obj, but got Unknown
		//IL_1d6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d75: Expected Obj, but got Unknown
		//IL_1f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f55: Expected Obj, but got Unknown
		//IL_2410: Unknown result type (might be due to invalid IL or missing references)
		//IL_241a: Expected Obj, but got Unknown
		//IL_2682: Unknown result type (might be due to invalid IL or missing references)
		//IL_268c: Expected Obj, but got Unknown
		//IL_2921: Unknown result type (might be due to invalid IL or missing references)
		//IL_292b: Expected Obj, but got Unknown
		//IL_2a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a58: Expected Obj, but got Unknown
		//IL_2b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b17: Expected Obj, but got Unknown
		//IL_2bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c08: Expected Obj, but got Unknown
		//IL_2c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c1f: Expected Obj, but got Unknown
		//IL_2c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c5f: Expected Obj, but got Unknown
		//IL_2d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d78: Expected Obj, but got Unknown
		//IL_2d85: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8f: Expected Obj, but got Unknown
		//IL_2d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2da6: Expected Obj, but got Unknown
		//IL_2db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dbd: Expected Obj, but got Unknown
		//IL_2dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd4: Expected Obj, but got Unknown
		//IL_2e5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e68: Expected Obj, but got Unknown
		//IL_2f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f18: Expected Obj, but got Unknown
		//IL_2fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fc7: Expected Obj, but got Unknown
		//IL_3402: Unknown result type (might be due to invalid IL or missing references)
		//IL_340c: Expected Obj, but got Unknown
		//IL_362f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3639: Expected Obj, but got Unknown
		//IL_3646: Unknown result type (might be due to invalid IL or missing references)
		//IL_3650: Expected Obj, but got Unknown
		//IL_365d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3667: Expected Obj, but got Unknown
		//IL_3674: Unknown result type (might be due to invalid IL or missing references)
		//IL_367e: Expected Obj, but got Unknown
		//IL_368b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3695: Expected Obj, but got Unknown
		this.m_k = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ActionControl));
		bs = new Button();
		this.m_l = new GroupBox();
		bv = new Label();
		bw = new TextBox();
		this.m_p = new GroupBox();
		bu = new Button();
		bl = new RadioButton();
		bg = new RadioButton();
		this.m_q = new RadioButton();
		this.m_r = new RadioButton();
		this.m_s = new RadioButton();
		this.m_t = new RadioButton();
		this.m_u = new RadioButton();
		this.m_v = new CheckBox();
		this.m_m = new GroupBox();
		this.m_n = new RadioButton();
		this.m_o = new RadioButton();
		bx = new GroupBox();
		by = new ComboBox();
		tvActionsConditions = new TreeView();
		this.m_ay = new ImageList(this.m_k);
		this.m_w = new GroupBox();
		this.m_az = new SplitContainer();
		this.m_aa = new TextBox();
		this.m_ab = new Label();
		this.m_a0 = new SplitContainer();
		a4 = new Label();
		this.m_a3 = new Button();
		this.m_a1 = new Button();
		this.m_a2 = new ListBox();
		a5 = new ContextMenuStrip(this.m_k);
		a6 = new ToolStripMenuItem();
		a7 = new ToolStripMenuItem();
		a8 = new ToolStripMenuItem();
		this.m_ac = new ComboBox();
		this.m_ad = new Label();
		this.m_x = new Label();
		this.m_ae = new ComboBox();
		cbConditionStep1 = new ComboBox();
		this.m_z = new TextBox();
		this.m_y = new Label();
		this.m_af = new Label();
		bi = new ComboBox();
		this.m_ag = new GroupBox();
		bn = new SplitContainer();
		bo = new Button();
		this.m_al = new ComboBox();
		this.m_ai = new Label();
		this.m_am = new Label();
		this.m_ak = new Label();
		this.m_an = new ComboBox();
		this.m_aj = new Label();
		this.m_ao = new Label();
		cbCommandStep1 = new ComboBox();
		bm = new TreeView();
		bh = new ComboBox();
		this.m_ah = new TextBox();
		this.m_ap = new TextBox();
		bt = new Button();
		ba = new ListBox();
		a9 = new Label();
		bj = new Button();
		bc = new Button();
		bb = new Button();
		this.m_aq = new Label();
		this.m_ar = new ContextMenuStrip(this.m_k);
		this.m_as = new ContextMenuStrip(this.m_k);
		this.m_at = new ToolStripMenuItem();
		this.m_au = new ToolStripMenuItem();
		this.m_av = new ContextMenuStrip(this.m_k);
		this.m_aw = new ToolStripMenuItem();
		this.m_ax = new ToolStripMenuItem();
		bd = new GroupBox();
		br = new TextBox();
		bq = new Label();
		bk = new Button();
		be = new Button();
		bf = new ListBox();
		bp = new ToolTip(this.m_k);
		((Control)this.m_l).SuspendLayout();
		((Control)this.m_p).SuspendLayout();
		((Control)this.m_m).SuspendLayout();
		((Control)bx).SuspendLayout();
		((Control)this.m_w).SuspendLayout();
		((ISupportInitialize)this.m_az).BeginInit();
		((Control)this.m_az.Panel1).SuspendLayout();
		((Control)this.m_az.Panel2).SuspendLayout();
		((Control)this.m_az).SuspendLayout();
		((ISupportInitialize)this.m_a0).BeginInit();
		((Control)this.m_a0.Panel1).SuspendLayout();
		((Control)this.m_a0.Panel2).SuspendLayout();
		((Control)this.m_a0).SuspendLayout();
		((Control)a5).SuspendLayout();
		((Control)this.m_ag).SuspendLayout();
		((ISupportInitialize)bn).BeginInit();
		((Control)bn.Panel1).SuspendLayout();
		((Control)bn.Panel2).SuspendLayout();
		((Control)bn).SuspendLayout();
		((Control)this.m_as).SuspendLayout();
		((Control)this.m_av).SuspendLayout();
		((Control)bd).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)bs).Anchor = (AnchorStyles)9;
		((Control)bs).Location = new Point(113, 281);
		((Control)bs).Name = "btnActionCustomDelete";
		((Control)bs).Size = new Size(35, 23);
		((Control)bs).TabIndex = 10;
		((Control)bs).Text = "Del";
		((ButtonBase)bs).UseVisualStyleBackColor = true;
		((Control)bs).Click += v;
		((Control)this.m_l).Anchor = (AnchorStyles)6;
		((Control)this.m_l).Controls.Add((Control)(object)bv);
		((Control)this.m_l).Controls.Add((Control)(object)bw);
		((Control)this.m_l).Controls.Add((Control)(object)this.m_p);
		((Control)this.m_l).Controls.Add((Control)(object)this.m_v);
		((Control)this.m_l).Controls.Add((Control)(object)this.m_m);
		((Control)this.m_l).Controls.Add((Control)(object)bx);
		((Control)this.m_l).Location = new Point(4, 248);
		((Control)this.m_l).Name = "groupBox2";
		((Control)this.m_l).Size = new Size(194, 317);
		((Control)this.m_l).TabIndex = 1;
		this.m_l.TabStop = false;
		((Control)this.m_l).Text = "Action Attributes";
		((Control)bv).AutoSize = true;
		((Control)bv).Location = new Point(6, 14);
		((Control)bv).Name = "label3";
		((Control)bv).Size = new Size(114, 13);
		((Control)bv).TabIndex = 45;
		((Control)bv).Text = "Action Name Override:";
		((Control)bw).Location = new Point(7, 30);
		((Control)bw).Name = "tbActionNameOverride";
		((Control)bw).Size = new Size(181, 20);
		((Control)bw).TabIndex = 0;
		((Control)bw).DoubleClick += i;
		((Control)bw).KeyDown += b;
		((Control)bw).Leave += b;
		((Control)this.m_p).Controls.Add((Control)(object)bu);
		((Control)this.m_p).Controls.Add((Control)(object)bl);
		((Control)this.m_p).Controls.Add((Control)(object)bg);
		((Control)this.m_p).Controls.Add((Control)(object)this.m_q);
		((Control)this.m_p).Controls.Add((Control)(object)this.m_r);
		((Control)this.m_p).Controls.Add((Control)(object)this.m_s);
		((Control)this.m_p).Controls.Add((Control)(object)this.m_t);
		((Control)this.m_p).Controls.Add((Control)(object)this.m_u);
		((Control)this.m_p).Enabled = false;
		((Control)this.m_p).Location = new Point(7, 173);
		((Control)this.m_p).Name = "groupBox3";
		((Control)this.m_p).Size = new Size(181, 138);
		((Control)this.m_p).TabIndex = 4;
		this.m_p.TabStop = false;
		((Control)this.m_p).Text = "Additional Input";
		((Control)this.m_p).Leave += am;
		((Control)bu).Location = new Point(97, 93);
		((Control)bu).Name = "btnAdvancedOverlayOptions";
		((Control)bu).Size = new Size(78, 38);
		((Control)bu).TabIndex = 7;
		((Control)bu).Text = "Advanced Options";
		((ButtonBase)bu).UseVisualStyleBackColor = true;
		((Control)bu).Click += d;
		((Control)bl).AutoSize = true;
		((Control)bl).Location = new Point(7, 109);
		((Control)bl).Name = "rbAddInputInventory";
		((Control)bl).Size = new Size(69, 17);
		((Control)bl).TabIndex = 3;
		((Control)bl).Text = "Inventory";
		((ButtonBase)bl).UseVisualStyleBackColor = true;
		bl.CheckedChanged += f;
		((Control)bg).AutoSize = true;
		((Control)bg).Location = new Point(98, 69);
		((Control)bg).Name = "rbaddinputCustom";
		((Control)bg).Size = new Size(60, 17);
		((Control)bg).TabIndex = 6;
		((Control)bg).Text = "Custom";
		((ButtonBase)bg).UseVisualStyleBackColor = true;
		bg.CheckedChanged += x;
		((Control)this.m_q).AutoSize = true;
		((Control)this.m_q).Location = new Point(98, 44);
		((Control)this.m_q).Name = "rbaddinputText";
		((Control)this.m_q).Size = new Size(46, 17);
		((Control)this.m_q).TabIndex = 5;
		((Control)this.m_q).Text = "Text";
		((ButtonBase)this.m_q).UseVisualStyleBackColor = true;
		this.m_q.CheckedChanged += f;
		((Control)this.m_r).AutoSize = true;
		((Control)this.m_r).Location = new Point(7, 79);
		((Control)this.m_r).Name = "rbaddinputObjectorCharacter";
		((Control)this.m_r).Size = new Size(80, 17);
		((Control)this.m_r).TabIndex = 2;
		((Control)this.m_r).Text = "Obj Or Char";
		((ButtonBase)this.m_r).UseVisualStyleBackColor = true;
		this.m_r.CheckedChanged += f;
		((Control)this.m_s).AutoSize = true;
		((Control)this.m_s).Location = new Point(7, 49);
		((Control)this.m_s).Name = "rbaddinputCharacter";
		((Control)this.m_s).Size = new Size(71, 17);
		((Control)this.m_s).TabIndex = 1;
		((Control)this.m_s).Text = "Character";
		((ButtonBase)this.m_s).UseVisualStyleBackColor = true;
		this.m_s.CheckedChanged += f;
		((Control)this.m_t).AutoSize = true;
		((Control)this.m_t).Location = new Point(98, 19);
		((Control)this.m_t).Name = "rbaddinputObject";
		((Control)this.m_t).Size = new Size(56, 17);
		((Control)this.m_t).TabIndex = 4;
		((Control)this.m_t).Text = "Object";
		((ButtonBase)this.m_t).UseVisualStyleBackColor = true;
		this.m_t.CheckedChanged += f;
		((Control)this.m_u).AutoSize = true;
		this.m_u.Checked = true;
		((Control)this.m_u).Location = new Point(7, 19);
		((Control)this.m_u).Name = "rbaddinputnone";
		((Control)this.m_u).Size = new Size(51, 17);
		((Control)this.m_u).TabIndex = 0;
		this.m_u.TabStop = true;
		((Control)this.m_u).Text = "None";
		((ButtonBase)this.m_u).UseVisualStyleBackColor = true;
		this.m_u.CheckedChanged += g;
		((Control)this.m_v).AutoSize = true;
		((Control)this.m_v).Enabled = false;
		((Control)this.m_v).Location = new Point(7, 53);
		((Control)this.m_v).Name = "cbActionActive";
		((Control)this.m_v).Size = new Size(168, 17);
		((Control)this.m_v).TabIndex = 1;
		((Control)this.m_v).Text = "Selected Action Initially Active";
		((ButtonBase)this.m_v).UseVisualStyleBackColor = true;
		this.m_v.CheckedChanged += az;
		((Control)this.m_m).Controls.Add((Control)(object)this.m_n);
		((Control)this.m_m).Controls.Add((Control)(object)this.m_o);
		((Control)this.m_m).Location = new Point(7, 117);
		((Control)this.m_m).Name = "groupBox4";
		((Control)this.m_m).Size = new Size(181, 56);
		((Control)this.m_m).TabIndex = 3;
		this.m_m.TabStop = false;
		((Control)this.m_m).Text = "Condition Behavior";
		((Control)this.m_m).Leave += an;
		((Control)this.m_n).Location = new Point(7, 33);
		((Control)this.m_n).Name = "rbRunAll";
		((Control)this.m_n).Size = new Size(166, 17);
		((Control)this.m_n).TabIndex = 1;
		((Control)this.m_n).Text = "Run all - pass on any success";
		((ButtonBase)this.m_n).UseVisualStyleBackColor = true;
		((Control)this.m_o).AutoSize = true;
		this.m_o.Checked = true;
		((Control)this.m_o).Location = new Point(7, 13);
		((Control)this.m_o).Name = "rbFailOnFirst";
		((Control)this.m_o).Size = new Size(97, 17);
		((Control)this.m_o).TabIndex = 0;
		this.m_o.TabStop = true;
		((Control)this.m_o).Text = "Stop on first fail";
		((ButtonBase)this.m_o).UseVisualStyleBackColor = true;
		((Control)bx).Controls.Add((Control)(object)by);
		((Control)bx).Location = new Point(8, 71);
		((Control)bx).Name = "gbActionParent";
		((Control)bx).Size = new Size(180, 42);
		((Control)bx).TabIndex = 2;
		bx.TabStop = false;
		((Control)bx).Text = "Action Parent";
		((ListControl)by).FormattingEnabled = true;
		((Control)by).Location = new Point(7, 16);
		((Control)by).Name = "cbActionParent";
		((Control)by).Size = new Size(167, 21);
		((Control)by).TabIndex = 0;
		by.SelectedIndexChanged += a;
		((Control)tvActionsConditions).AllowDrop = true;
		((Control)tvActionsConditions).Anchor = (AnchorStyles)15;
		((Control)tvActionsConditions).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvActionsConditions.HideSelection = false;
		tvActionsConditions.HotTracking = true;
		tvActionsConditions.ImageIndex = 0;
		tvActionsConditions.ImageList = this.m_ay;
		((Control)tvActionsConditions).Location = new Point(4, 20);
		((Control)tvActionsConditions).Name = "tvActionsConditions";
		tvActionsConditions.SelectedImageIndex = 0;
		tvActionsConditions.ShowNodeToolTips = true;
		((Control)tvActionsConditions).Size = new Size(637, 222);
		((Control)tvActionsConditions).TabIndex = 0;
		tvActionsConditions.AfterSelect += b;
		((Control)tvActionsConditions).DragDrop += e;
		((Control)tvActionsConditions).DragOver += f;
		((Control)tvActionsConditions).KeyDown += a;
		((Control)tvActionsConditions).MouseDown += i;
		((Control)tvActionsConditions).MouseMove += h;
		this.m_ay.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("ilTreeview.ImageStream");
		this.m_ay.TransparentColor = Color.Transparent;
		this.m_ay.Images.SetKeyName(0, "runman.jpg");
		this.m_ay.Images.SetKeyName(1, "cancel.JPG");
		this.m_ay.Images.SetKeyName(2, "question.jpg");
		this.m_ay.Images.SetKeyName(3, "TaskHS.png");
		this.m_ay.Images.SetKeyName(4, "Flag_redHS.png");
		this.m_ay.Images.SetKeyName(5, "Flag_greenHS.png");
		((Control)this.m_w).Anchor = (AnchorStyles)14;
		((Control)this.m_w).Controls.Add((Control)(object)this.m_az);
		((Control)this.m_w).Location = new Point(208, 248);
		((Control)this.m_w).Name = "gbConditionData";
		((Control)this.m_w).Size = new Size(434, 314);
		((Control)this.m_w).TabIndex = 2;
		this.m_w.TabStop = false;
		((Control)this.m_w).Text = "Condition Data";
		this.m_az.Dock = (DockStyle)5;
		((Control)this.m_az).Location = new Point(3, 16);
		((Control)this.m_az).Name = "splitContainer1";
		this.m_az.Orientation = (Orientation)0;
		((Control)this.m_az.Panel1).Controls.Add((Control)(object)this.m_aa);
		((Control)this.m_az.Panel1).Controls.Add((Control)(object)this.m_ab);
		((Control)this.m_az.Panel2).Controls.Add((Control)(object)this.m_a0);
		((Control)this.m_az).Size = new Size(428, 295);
		this.m_az.SplitterDistance = 42;
		((Control)this.m_az).TabIndex = 15;
		((Control)this.m_aa).Anchor = (AnchorStyles)13;
		((Control)this.m_aa).Location = new Point(97, 7);
		((Control)this.m_aa).Name = "txtConditionName";
		((Control)this.m_aa).Size = new Size(518, 20);
		((Control)this.m_aa).TabIndex = 0;
		((Control)this.m_aa).DoubleClick += i;
		((Control)this.m_aa).Enter += e;
		((Control)this.m_aa).Leave += ag;
		((Control)this.m_ab).AutoSize = true;
		((Control)this.m_ab).Location = new Point(3, 10);
		((Control)this.m_ab).Name = "label34";
		((Control)this.m_ab).Size = new Size(85, 13);
		((Control)this.m_ab).TabIndex = 8;
		((Control)this.m_ab).Text = "Condition Name:";
		this.m_a0.BorderStyle = (BorderStyle)1;
		this.m_a0.Dock = (DockStyle)5;
		((Control)this.m_a0).Location = new Point(0, 0);
		((Control)this.m_a0).Name = "splitContainer2";
		((Control)this.m_a0.Panel1).Controls.Add((Control)(object)a4);
		((Control)this.m_a0.Panel1).Controls.Add((Control)(object)this.m_a3);
		((Control)this.m_a0.Panel1).Controls.Add((Control)(object)this.m_a1);
		((Control)this.m_a0.Panel1).Controls.Add((Control)(object)this.m_a2);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_ac);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_ad);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_x);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_ae);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)cbConditionStep1);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_z);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_y);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)this.m_af);
		((Control)this.m_a0.Panel2).Controls.Add((Control)(object)bi);
		((Control)this.m_a0).Size = new Size(428, 249);
		this.m_a0.SplitterDistance = 155;
		((Control)this.m_a0).TabIndex = 15;
		((Control)a4).Location = new Point(1, 0);
		((Control)a4).Name = "label1";
		((Control)a4).Size = new Size(46, 11);
		((Control)a4).TabIndex = 3;
		((Control)a4).Text = "Checks:";
		((Control)this.m_a3).Location = new Point(77, 219);
		((Control)this.m_a3).Name = "bOr";
		((Control)this.m_a3).Size = new Size(44, 23);
		((Control)this.m_a3).TabIndex = 3;
		((Control)this.m_a3).Text = "Or";
		((ButtonBase)this.m_a3).UseVisualStyleBackColor = true;
		((Control)this.m_a3).Click += ae;
		((Control)this.m_a1).Location = new Point(31, 219);
		((Control)this.m_a1).Name = "bAnd";
		((Control)this.m_a1).Size = new Size(42, 23);
		((Control)this.m_a1).TabIndex = 2;
		((Control)this.m_a1).Text = "And";
		((ButtonBase)this.m_a1).UseVisualStyleBackColor = true;
		((Control)this.m_a1).Click += af;
		((Control)this.m_a2).Anchor = (AnchorStyles)13;
		((Control)this.m_a2).ContextMenuStrip = a5;
		((ListControl)this.m_a2).FormattingEnabled = true;
		((Control)this.m_a2).Location = new Point(3, 15);
		((Control)this.m_a2).Name = "lbChecks";
		((Control)this.m_a2).Size = new Size(147, 199);
		((Control)this.m_a2).TabIndex = 1;
		this.m_a2.SelectedIndexChanged += ad;
		((ToolStrip)a5).Items.AddRange(new ToolStripItem[3]
		{
			(ToolStripItem)a6,
			(ToolStripItem)a7,
			(ToolStripItem)a8
		});
		((Control)a5).Name = "cntxConditionChecks";
		((Control)a5).Size = new Size(182, 70);
		((ToolStripItem)a6).Name = "addAndCheckToolStripMenuItem";
		((ToolStripItem)a6).Size = new Size(181, 22);
		((ToolStripItem)a6).Text = "Add \"And\" Check";
		((ToolStripItem)a6).Click += af;
		((ToolStripItem)a7).Name = "addOrCheckToolStripMenuItem";
		((ToolStripItem)a7).Size = new Size(181, 22);
		((ToolStripItem)a7).Text = "Add \"Or\" Check";
		((ToolStripItem)a7).Click += ae;
		((ToolStripItem)a8).Name = "deleteSelectedItemToolStripMenuItem";
		((ToolStripItem)a8).Size = new Size(181, 22);
		((ToolStripItem)a8).Text = "Delete Selected Item";
		((ToolStripItem)a8).Click += ac;
		((Control)this.m_ac).Anchor = (AnchorStyles)13;
		((ListControl)this.m_ac).FormattingEnabled = true;
		this.m_ac.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)this.m_ac).Location = new Point(3, 133);
		((Control)this.m_ac).Name = "cbConditionStep3";
		((Control)this.m_ac).Size = new Size(260, 21);
		this.m_ac.Sorted = true;
		((Control)this.m_ac).TabIndex = 6;
		((Control)this.m_ac).Visible = false;
		this.m_ac.SelectedIndexChanged += aa;
		((Control)this.m_ac).Click += h;
		((Control)this.m_ac).KeyDown += b;
		((Control)this.m_ac).Leave += aw;
		((Control)this.m_ad).AutoSize = true;
		((Control)this.m_ad).Location = new Point(3, 61);
		((Control)this.m_ad).Name = "lblConditionStep2";
		((Control)this.m_ad).Size = new Size(38, 13);
		((Control)this.m_ad).TabIndex = 5;
		((Control)this.m_ad).Text = "Step 2";
		((Control)this.m_ad).Visible = false;
		((Control)this.m_x).AutoSize = true;
		((Control)this.m_x).Location = new Point(3, 183);
		((Control)this.m_x).Name = "lblConditionStep4";
		((Control)this.m_x).Size = new Size(38, 13);
		((Control)this.m_x).TabIndex = 14;
		((Control)this.m_x).Text = "Step 4";
		((Control)this.m_x).Visible = false;
		((Control)this.m_ae).Anchor = (AnchorStyles)13;
		((ListControl)this.m_ae).FormattingEnabled = true;
		this.m_ae.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)this.m_ae).Location = new Point(3, 78);
		((Control)this.m_ae).Name = "cbConditionStep2";
		((Control)this.m_ae).Size = new Size(260, 21);
		this.m_ae.Sorted = true;
		((Control)this.m_ae).TabIndex = 5;
		((Control)this.m_ae).Visible = false;
		this.m_ae.SelectedIndexChanged += au;
		this.m_ae.TextUpdate += au;
		((Control)this.m_ae).Click += h;
		((Control)this.m_ae).KeyDown += b;
		((Control)this.m_ae).Leave += ax;
		((Control)cbConditionStep1).Anchor = (AnchorStyles)13;
		cbConditionStep1.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)cbConditionStep1).FormattingEnabled = true;
		cbConditionStep1.Items.AddRange(new object[6] { "Additional Input Check", "Item Held By Player", "Item In Room", "Item State Check", "Player In Room", "Variable Comparison" });
		((Control)cbConditionStep1).Location = new Point(3, 25);
		((Control)cbConditionStep1).Name = "cbConditionStep1";
		((Control)cbConditionStep1).Size = new Size(260, 21);
		((Control)cbConditionStep1).TabIndex = 4;
		cbConditionStep1.SelectedIndexChanged += a1;
		((Control)cbConditionStep1).Leave += ay;
		((Control)this.m_z).Anchor = (AnchorStyles)13;
		((Control)this.m_z).Location = new Point(3, 199);
		((Control)this.m_z).Name = "txtConditionStep4";
		((Control)this.m_z).Size = new Size(260, 20);
		((Control)this.m_z).TabIndex = 7;
		((Control)this.m_z).Visible = false;
		((Control)this.m_z).DoubleClick += i;
		((Control)this.m_z).Enter += e;
		((Control)this.m_z).KeyDown += b;
		((Control)this.m_z).Leave += av;
		((Control)this.m_y).AutoSize = true;
		((Control)this.m_y).Location = new Point(3, 116);
		((Control)this.m_y).Name = "lblConditionStep3";
		((Control)this.m_y).Size = new Size(38, 13);
		((Control)this.m_y).TabIndex = 13;
		((Control)this.m_y).Text = "Step 3";
		((Control)this.m_y).Visible = false;
		((Control)this.m_af).AutoSize = true;
		((Control)this.m_af).Location = new Point(3, 8);
		((Control)this.m_af).Name = "lblConditionStep1";
		((Control)this.m_af).Size = new Size(38, 13);
		((Control)this.m_af).TabIndex = 3;
		((Control)this.m_af).Text = "Step 1";
		((Control)bi).Anchor = (AnchorStyles)13;
		((ListControl)bi).FormattingEnabled = true;
		bi.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)bi).Location = new Point(4, 200);
		((Control)bi).Name = "cbConditionStep4";
		((Control)bi).Size = new Size(260, 21);
		bi.Sorted = true;
		((Control)bi).TabIndex = 15;
		((Control)bi).Visible = false;
		((Control)bi).Click += h;
		((Control)bi).KeyDown += b;
		((Control)bi).Leave += t;
		((Control)this.m_ag).Anchor = (AnchorStyles)14;
		((Control)this.m_ag).Controls.Add((Control)(object)bn);
		((Control)this.m_ag).Location = new Point(207, 248);
		((Control)this.m_ag).Name = "gbCommands";
		((Control)this.m_ag).Size = new Size(434, 315);
		((Control)this.m_ag).TabIndex = 5;
		this.m_ag.TabStop = false;
		((Control)this.m_ag).Text = "Add Commands";
		bn.Dock = (DockStyle)5;
		((Control)bn).Location = new Point(3, 16);
		((Control)bn).Name = "splitContainer3";
		((Control)bn.Panel1).Controls.Add((Control)(object)bo);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_al);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_ai);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_am);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_ak);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_an);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_aj);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_ao);
		((Control)bn.Panel1).Controls.Add((Control)(object)cbCommandStep1);
		((Control)bn.Panel1).Controls.Add((Control)(object)bm);
		((Control)bn.Panel1).Controls.Add((Control)(object)bh);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_ah);
		((Control)bn.Panel1).Controls.Add((Control)(object)this.m_ap);
		((Control)bn.Panel2).Controls.Add((Control)(object)bt);
		((Control)bn.Panel2).Controls.Add((Control)(object)ba);
		((Control)bn.Panel2).Controls.Add((Control)(object)a9);
		((Control)bn.Panel2).Controls.Add((Control)(object)bj);
		((Control)bn.Panel2).Controls.Add((Control)(object)bc);
		((Control)bn.Panel2).Controls.Add((Control)(object)bb);
		((Control)bn).Size = new Size(428, 296);
		bn.SplitterDistance = 270;
		((Control)bn).TabIndex = 27;
		((Control)bo).Anchor = (AnchorStyles)10;
		((Control)bo).Location = new Point(244, 268);
		((Control)bo).Name = "btnHelp";
		((Control)bo).Size = new Size(21, 23);
		((Control)bo).TabIndex = 12;
		((Control)bo).Text = "?";
		((ButtonBase)bo).UseVisualStyleBackColor = true;
		((Control)bo).Click += l;
		((Control)bo).MouseHover += m;
		((Control)this.m_al).Anchor = (AnchorStyles)13;
		((ListControl)this.m_al).FormattingEnabled = true;
		this.m_al.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)this.m_al).Location = new Point(0, 168);
		((Control)this.m_al).Name = "cbCommandStep3";
		((Control)this.m_al).Size = new Size(267, 21);
		this.m_al.Sorted = true;
		((Control)this.m_al).TabIndex = 10;
		((Control)this.m_al).Visible = false;
		this.m_al.SelectedIndexChanged += ab;
		((Control)this.m_al).Click += h;
		((Control)this.m_al).KeyDown += b;
		((Control)this.m_al).Leave += ar;
		((Control)this.m_ai).AutoSize = true;
		((Control)this.m_ai).Location = new Point(-2, 215);
		((Control)this.m_ai).Name = "lblStep4";
		((Control)this.m_ai).Size = new Size(38, 13);
		((Control)this.m_ai).TabIndex = 18;
		((Control)this.m_ai).Text = "Step 4";
		((Control)this.m_ai).Visible = false;
		((Control)this.m_am).AutoSize = true;
		((Control)this.m_am).Location = new Point(-3, 70);
		((Control)this.m_am).Name = "lblCommandStep2";
		((Control)this.m_am).Size = new Size(38, 13);
		((Control)this.m_am).TabIndex = 5;
		((Control)this.m_am).Text = "Step 2";
		((Control)this.m_am).Visible = false;
		((Control)this.m_ak).AutoSize = true;
		((Control)this.m_ak).Location = new Point(-2, 116);
		((Control)this.m_ak).Name = "lblCommandText";
		((Control)this.m_ak).Size = new Size(63, 13);
		((Control)this.m_ak).TabIndex = 14;
		((Control)this.m_ak).Text = "Description:";
		((Control)this.m_ak).Visible = false;
		((Control)this.m_an).Anchor = (AnchorStyles)13;
		((ListControl)this.m_an).FormattingEnabled = true;
		this.m_an.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)this.m_an).Location = new Point(-1, 87);
		((Control)this.m_an).Name = "cbCommandStep2";
		((Control)this.m_an).Size = new Size(266, 21);
		this.m_an.Sorted = true;
		((Control)this.m_an).TabIndex = 8;
		((Control)this.m_an).Visible = false;
		this.m_an.SelectedIndexChanged += ao;
		((Control)this.m_an).Click += h;
		((Control)this.m_an).KeyDown += b;
		((Control)this.m_an).Leave += @as;
		((Control)this.m_aj).AutoSize = true;
		((Control)this.m_aj).Location = new Point(-2, 151);
		((Control)this.m_aj).Name = "lblCommandStep3";
		((Control)this.m_aj).Size = new Size(38, 13);
		((Control)this.m_aj).TabIndex = 16;
		((Control)this.m_aj).Text = "Step 3";
		((Control)this.m_aj).Visible = false;
		((Control)this.m_ao).AutoSize = true;
		((Control)this.m_ao).Location = new Point(-2, 5);
		((Control)this.m_ao).Name = "label33";
		((Control)this.m_ao).Size = new Size(38, 13);
		((Control)this.m_ao).TabIndex = 3;
		((Control)this.m_ao).Text = "Step 1";
		((Control)cbCommandStep1).Anchor = (AnchorStyles)13;
		cbCommandStep1.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)cbCommandStep1).FormattingEnabled = true;
		cbCommandStep1.Items.AddRange(new object[16]
		{
			"Display Item Description", "Display Picture", "Display Player Description", "Display Text", "Display Variable Data", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Object's Action To Active/Inactive", "Set Object's State To Locked/Unlocked",
			"Set Object's State To Open/Closed", "Set Player Description", "Set Player Portrait", "Set Room Exit To Active/Inactive", "Set Room Picture", "Set Variable"
		});
		((Control)cbCommandStep1).Location = new Point(0, 26);
		((Control)cbCommandStep1).Name = "cbCommandStep1";
		((Control)cbCommandStep1).Size = new Size(267, 21);
		((Control)cbCommandStep1).TabIndex = 7;
		cbCommandStep1.SelectedIndexChanged += a0;
		((Control)cbCommandStep1).Leave += at;
		((Control)bm).Anchor = (AnchorStyles)13;
		bm.HideSelection = false;
		((Control)bm).Location = new Point(0, 20);
		((Control)bm).Name = "tvCommands";
		((Control)bm).Size = new Size(267, 55);
		((Control)bm).TabIndex = 6;
		((Control)bm).Visible = false;
		bm.AfterSelect += a;
		((Control)bm).Enter += o;
		((Control)bm).Leave += n;
		((Control)bh).Anchor = (AnchorStyles)13;
		((ListControl)bh).FormattingEnabled = true;
		bh.Items.AddRange(new object[8] { "Display Player Description", "Display Text", "Move Item To Inventory", "Move Item To Room", "Set Item Description", "Set Player Description", "Set Room Exit To Active/Inactive", "Set Variable" });
		((Control)bh).Location = new Point(1, 233);
		((Control)bh).Name = "cbCommandStep4";
		((Control)bh).Size = new Size(266, 21);
		bh.Sorted = true;
		((Control)bh).TabIndex = 11;
		((Control)bh).Visible = false;
		((Control)bh).Click += h;
		((Control)bh).KeyDown += b;
		((Control)bh).Leave += u;
		((Control)this.m_ah).Anchor = (AnchorStyles)13;
		((Control)this.m_ah).Location = new Point(1, 232);
		((Control)this.m_ah).Name = "txtStep4";
		((Control)this.m_ah).Size = new Size(267, 20);
		((Control)this.m_ah).TabIndex = 10;
		((Control)this.m_ah).Visible = false;
		((Control)this.m_ah).DoubleClick += i;
		((Control)this.m_ah).Enter += e;
		((Control)this.m_ah).KeyDown += b;
		((Control)this.m_ah).Leave += ap;
		((Control)this.m_ap).Anchor = (AnchorStyles)13;
		((Control)this.m_ap).Location = new Point(0, 134);
		((TextBoxBase)this.m_ap).Multiline = true;
		((Control)this.m_ap).Name = "txtCommandText";
		this.m_ap.ScrollBars = (ScrollBars)3;
		((Control)this.m_ap).Size = new Size(267, 128);
		((Control)this.m_ap).TabIndex = 9;
		((Control)this.m_ap).Visible = false;
		((Control)this.m_ap).TextChanged += s;
		((Control)this.m_ap).DoubleClick += i;
		((Control)this.m_ap).Enter += r;
		((Control)this.m_ap).KeyDown += b;
		((Control)this.m_ap).KeyPress += a;
		((Control)this.m_ap).Leave += aq;
		((Control)bt).Anchor = (AnchorStyles)2;
		((Control)bt).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)bt).Location = new Point(105, 267);
		((Control)bt).Name = "button2";
		((Control)bt).Size = new Size(45, 23);
		((Control)bt).TabIndex = 17;
		((Control)bt).Text = "Adv...";
		((ButtonBase)bt).UseVisualStyleBackColor = true;
		((Control)bt).Click += c;
		((Control)ba).AllowDrop = true;
		((Control)ba).Anchor = (AnchorStyles)15;
		((ListControl)ba).FormattingEnabled = true;
		((Control)ba).Location = new Point(4, 20);
		((Control)ba).Name = "lbCustomChoices";
		ba.SelectionMode = (SelectionMode)3;
		((Control)ba).Size = new Size(150, 238);
		((Control)ba).TabIndex = 13;
		((Control)ba).Visible = false;
		((Control)ba).DragDrop += a;
		((Control)ba).DragOver += b;
		((Control)ba).MouseDown += d;
		((Control)ba).MouseMove += c;
		((Control)ba).MouseUp += b;
		((Control)a9).AutoSize = true;
		((Control)a9).Location = new Point(3, 6);
		((Control)a9).Name = "lblCustomChoices";
		((Control)a9).Size = new Size(86, 13);
		((Control)a9).TabIndex = 21;
		((Control)a9).Text = "Custom Choices:";
		((Control)a9).Visible = false;
		((Control)bj).Anchor = (AnchorStyles)2;
		((Control)bj).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)bj).Location = new Point(37, 267);
		((Control)bj).Name = "btnUpdateCustom";
		((Control)bj).Size = new Size(35, 23);
		((Control)bj).TabIndex = 15;
		((Control)bj).Text = "Upd";
		((ButtonBase)bj).UseVisualStyleBackColor = true;
		((Control)bj).Visible = false;
		((Control)bj).Click += q;
		((Control)bc).Anchor = (AnchorStyles)2;
		((Control)bc).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)bc).Location = new Point(4, 267);
		((Control)bc).Name = "btnAddCustom";
		((Control)bc).Size = new Size(34, 23);
		((Control)bc).TabIndex = 14;
		((Control)bc).Text = "Add";
		((ButtonBase)bc).UseVisualStyleBackColor = true;
		((Control)bc).Visible = false;
		((Control)bc).Click += z;
		((Control)bb).Anchor = (AnchorStyles)2;
		((Control)bb).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)bb).Location = new Point(71, 267);
		((Control)bb).Name = "btnDeleteCustom";
		((Control)bb).Size = new Size(35, 23);
		((Control)bb).TabIndex = 16;
		((Control)bb).Text = "Del";
		((ButtonBase)bb).UseVisualStyleBackColor = true;
		((Control)bb).Visible = false;
		((Control)bb).Click += y;
		((Control)this.m_aq).AutoSize = true;
		((Control)this.m_aq).Location = new Point(3, 4);
		((Control)this.m_aq).Name = "label30";
		((Control)this.m_aq).Size = new Size(118, 13);
		((Control)this.m_aq).TabIndex = 42;
		((Control)this.m_aq).Text = "Actions and Conditions:";
		((Control)this.m_ar).Name = "cmActionsConditions";
		((Control)this.m_ar).Size = new Size(61, 4);
		((ToolStrip)this.m_as).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_at,
			(ToolStripItem)this.m_au
		});
		((Control)this.m_as).Name = "cntxFailCommands";
		((Control)this.m_as).Size = new Size(168, 48);
		((ToolStripItem)this.m_at).Name = "addCommandToolStripMenuItem";
		((ToolStripItem)this.m_at).Size = new Size(167, 22);
		((ToolStripItem)this.m_at).Text = "Add Command";
		((ToolStripItem)this.m_at).Click += ak;
		((ToolStripItem)this.m_au).Name = "deleteCommandToolStripMenuItem";
		((ToolStripItem)this.m_au).Size = new Size(167, 22);
		((ToolStripItem)this.m_au).Text = "Delete Command";
		((ToolStripItem)this.m_au).Click += aj;
		((ToolStrip)this.m_av).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_aw,
			(ToolStripItem)this.m_ax
		});
		((Control)this.m_av).Name = "cntxPassCommands";
		((Control)this.m_av).Size = new Size(168, 48);
		((ToolStripItem)this.m_aw).Name = "addCommandToolStripMenuItem1";
		((ToolStripItem)this.m_aw).Size = new Size(167, 22);
		((ToolStripItem)this.m_aw).Text = "Add Command";
		((ToolStripItem)this.m_aw).Click += ai;
		((ToolStripItem)this.m_ax).Name = "deleteCommandToolStripMenuItem1";
		((ToolStripItem)this.m_ax).Size = new Size(167, 22);
		((ToolStripItem)this.m_ax).Text = "Delete Command";
		((Control)bd).Anchor = (AnchorStyles)6;
		((Control)bd).Controls.Add((Control)(object)br);
		((Control)bd).Controls.Add((Control)(object)bq);
		((Control)bd).Controls.Add((Control)(object)bk);
		((Control)bd).Controls.Add((Control)(object)bs);
		((Control)bd).Controls.Add((Control)(object)be);
		((Control)bd).Controls.Add((Control)(object)bf);
		((Control)bd).Location = new Point(204, 248);
		((Control)bd).Name = "gbCustomChoices";
		((Control)bd).Size = new Size(154, 310);
		((Control)bd).TabIndex = 5;
		bd.TabStop = false;
		((Control)bd).Text = "Custom Choices";
		((Control)br).Anchor = (AnchorStyles)13;
		((Control)br).Location = new Point(5, 30);
		((Control)br).Name = "tbCustomChoiceTitle";
		((Control)br).Size = new Size(143, 20);
		((Control)br).TabIndex = 6;
		((Control)br).Enter += e;
		((Control)br).KeyDown += b;
		((Control)br).Leave += j;
		((Control)bq).AutoSize = true;
		((Control)bq).Location = new Point(6, 14);
		((Control)bq).Name = "label2";
		((Control)bq).Size = new Size(30, 13);
		((Control)bq).TabIndex = 60;
		((Control)bq).Text = "Title:";
		((Control)bq).Click += k;
		((Control)bk).Anchor = (AnchorStyles)9;
		((Control)bk).Location = new Point(59, 281);
		((Control)bk).Name = "btnActionCustomUpdate";
		((Control)bk).Size = new Size(35, 23);
		((Control)bk).TabIndex = 9;
		((Control)bk).Text = "Upd";
		((ButtonBase)bk).UseVisualStyleBackColor = true;
		((Control)bk).Click += p;
		((Control)be).Anchor = (AnchorStyles)9;
		((Control)be).Location = new Point(5, 281);
		((Control)be).Name = "btnActionCustomAdd";
		((Control)be).Size = new Size(35, 23);
		((Control)be).TabIndex = 8;
		((Control)be).Text = "Add";
		((ButtonBase)be).UseVisualStyleBackColor = true;
		((Control)be).Click += w;
		((Control)bf).AllowDrop = true;
		((Control)bf).Anchor = (AnchorStyles)11;
		((ListControl)bf).FormattingEnabled = true;
		((Control)bf).Location = new Point(6, 57);
		((Control)bf).Name = "lbActionCustomChoices";
		bf.SelectionMode = (SelectionMode)3;
		((Control)bf).Size = new Size(142, 212);
		((Control)bf).TabIndex = 7;
		((Control)bf).DragDrop += c;
		((Control)bf).DragOver += d;
		((Control)bf).MouseDown += g;
		((Control)bf).MouseMove += f;
		((Control)bf).MouseUp += e;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)tvActionsConditions);
		((Control)this).Controls.Add((Control)(object)this.m_l);
		((Control)this).Controls.Add((Control)(object)this.m_aq);
		((Control)this).Controls.Add((Control)(object)this.m_w);
		((Control)this).Controls.Add((Control)(object)bd);
		((Control)this).Controls.Add((Control)(object)this.m_ag);
		((Control)this).Name = "ActionControl";
		((Control)this).Size = new Size(650, 568);
		((Control)this.m_l).ResumeLayout(false);
		((Control)this.m_l).PerformLayout();
		((Control)this.m_p).ResumeLayout(false);
		((Control)this.m_p).PerformLayout();
		((Control)this.m_m).ResumeLayout(false);
		((Control)this.m_m).PerformLayout();
		((Control)bx).ResumeLayout(false);
		((Control)this.m_w).ResumeLayout(false);
		((Control)this.m_az.Panel1).ResumeLayout(false);
		((Control)this.m_az.Panel1).PerformLayout();
		((Control)this.m_az.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_az).EndInit();
		((Control)this.m_az).ResumeLayout(false);
		((Control)this.m_a0.Panel1).ResumeLayout(false);
		((Control)this.m_a0.Panel2).ResumeLayout(false);
		((Control)this.m_a0.Panel2).PerformLayout();
		((ISupportInitialize)this.m_a0).EndInit();
		((Control)this.m_a0).ResumeLayout(false);
		((Control)a5).ResumeLayout(false);
		((Control)this.m_ag).ResumeLayout(false);
		((Control)bn.Panel1).ResumeLayout(false);
		((Control)bn.Panel1).PerformLayout();
		((Control)bn.Panel2).ResumeLayout(false);
		((Control)bn.Panel2).PerformLayout();
		((ISupportInitialize)bn).EndInit();
		((Control)bn).ResumeLayout(false);
		((Control)this.m_as).ResumeLayout(false);
		((Control)this.m_av).ResumeLayout(false);
		((Control)bd).ResumeLayout(false);
		((Control)bd).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
