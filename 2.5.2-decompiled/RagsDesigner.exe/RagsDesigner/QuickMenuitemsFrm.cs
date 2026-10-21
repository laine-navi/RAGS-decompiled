using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class QuickMenuitemsFrm : Form
{
	private ArrayList m_a;

	private IContainer m_b;

	private Label m_c;

	private Button m_d;

	private Button m_e;

	private GroupBox m_f;

	private CheckBox m_g;

	private CheckBox m_h;

	private CheckBox m_i;

	private CheckBox m_j;

	private CheckBox m_k;

	private CheckBox m_l;

	private CheckBox m_m;

	private GroupBox m_n;

	private CheckBox m_o;

	private CheckBox m_p;

	private CheckBox m_q;

	private CheckBox m_r;

	public ListBox lbMenuItems;

	private Button m_s;

	private Button m_t;

	private Button u;

	private Label v;

	private Label w;

	private TextBox x;

	private GroupBox y;

	private CheckBox z;

	public QuickMenuitemsFrm(ref ArrayList commands)
	{
		a();
		this.m_a = commands;
		b();
	}

	private void t(object A_0, EventArgs A_1)
	{
		if (lbMenuItems.SelectedItem != null)
		{
			Form1.TheGame.QuickCommands.Remove(lbMenuItems.SelectedItem);
			b();
		}
	}

	private void s(object A_0, EventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		((Control)x).Text = quickMenuItem.Name;
		if (quickMenuItem.bCarryable)
		{
			this.m_m.Checked = true;
		}
		else
		{
			this.m_m.Checked = false;
		}
		if (quickMenuItem.bCharacters)
		{
			this.m_p.Checked = true;
		}
		else
		{
			this.m_p.Checked = false;
		}
		if (quickMenuItem.bContainer)
		{
			this.m_g.Checked = true;
		}
		else
		{
			this.m_g.Checked = false;
		}
		if (quickMenuItem.bEnterable)
		{
			this.m_i.Checked = true;
		}
		else
		{
			this.m_i.Checked = false;
		}
		if (quickMenuItem.bLockable)
		{
			this.m_j.Checked = true;
		}
		else
		{
			this.m_j.Checked = false;
		}
		if (quickMenuItem.bObjects)
		{
			this.m_o.Checked = true;
		}
		else
		{
			this.m_o.Checked = false;
		}
		if (quickMenuItem.bOpenable)
		{
			this.m_k.Checked = true;
		}
		else
		{
			this.m_k.Checked = false;
		}
		if (quickMenuItem.bPlayer)
		{
			this.m_q.Checked = true;
		}
		else
		{
			this.m_q.Checked = false;
		}
		if (quickMenuItem.bReadable)
		{
			this.m_h.Checked = true;
		}
		else
		{
			this.m_h.Checked = false;
		}
		if (quickMenuItem.bRooms)
		{
			this.m_r.Checked = true;
		}
		else
		{
			this.m_r.Checked = false;
		}
		if (quickMenuItem.bWearable)
		{
			this.m_l.Checked = true;
		}
		else
		{
			this.m_l.Checked = false;
		}
		if (quickMenuItem.bOverwrite)
		{
			z.Checked = true;
		}
		else
		{
			z.Checked = false;
		}
	}

	private void r(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void q(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		if ((int)MessageBox.Show("This will overwrite your current quick commands.  Are you sure you want to proceed?", "Proceed", (MessageBoxButtons)4) == 6)
		{
			Game.RestoreDefaults(ref this.m_a);
			b();
		}
	}

	private void b()
	{
		lbMenuItems.Items.Clear();
		for (int i = 0; i < this.m_a.Count; i++)
		{
			QuickMenuItem quickMenuItem = (QuickMenuItem)this.m_a[i];
			lbMenuItems.Items.Add((object)quickMenuItem);
		}
		if (lbMenuItems.Items.Count > 0)
		{
			((ListControl)lbMenuItems).SelectedIndex = 0;
		}
	}

	private void p(object A_0, EventArgs A_1)
	{
	}

	private void o(object A_0, EventArgs A_1)
	{
		if (this.m_o.Checked)
		{
			((Control)this.m_f).Enabled = true;
		}
		else
		{
			((Control)this.m_f).Enabled = false;
		}
		((QuickMenuItem)lbMenuItems.SelectedItem).bObjects = this.m_o.Checked;
	}

	private void n(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bRooms = this.m_r.Checked;
	}

	private void m(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bPlayer = this.m_q.Checked;
	}

	private void l(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bCharacters = this.m_p.Checked;
	}

	private void k(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bCarryable = this.m_m.Checked;
	}

	private void j(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bWearable = this.m_l.Checked;
	}

	private void i(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bContainer = this.m_g.Checked;
	}

	private void h(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bOpenable = this.m_k.Checked;
	}

	private void g(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bLockable = this.m_j.Checked;
	}

	private void f(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bEnterable = this.m_i.Checked;
	}

	private void e(object A_0, EventArgs A_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bReadable = this.m_h.Checked;
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem != null)
		{
			QuickCommandEditFrm quickCommandEditFrm = new QuickCommandEditFrm();
			((Control)quickCommandEditFrm.label1).Text = quickMenuItem.Name;
			quickCommandEditFrm.QuickCommandActionControl.SetObjectName(quickMenuItem.UniqueID.ToString());
			quickCommandEditFrm.QuickCommandActionControl.SetPageType(ActionControl.PageType.quickcommand);
			quickCommandEditFrm.QuickCommandActionControl.SetGameObject(ref Form1.TheGame);
			quickCommandEditFrm.QuickCommandActionControl.RefreshActions();
			((Form)quickCommandEditFrm).ShowDialog();
			((Component)(object)quickCommandEditFrm).Dispose();
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		GetNameFrm getNameFrm = new GetNameFrm("Name of new quick command:");
		if ((int)((Form)getNameFrm).ShowDialog() == 1)
		{
			QuickMenuItem quickMenuItem = new QuickMenuItem();
			quickMenuItem.Name = ((Control)getNameFrm.txtEntry).Text;
			Form1.TheGame.QuickCommands.Add(quickMenuItem);
			b();
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem != null)
		{
			quickMenuItem.Name = ((Control)x).Text;
		}
		b();
	}

	private void a(object A_0, EventArgs A_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem != null)
		{
			quickMenuItem.bOverwrite = z.Checked;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_b != null)
		{
			this.m_b.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_1012: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickMenuitemsFrm));
		lbMenuItems = new ListBox();
		this.m_c = new Label();
		this.m_d = new Button();
		this.m_e = new Button();
		this.m_f = new GroupBox();
		this.m_g = new CheckBox();
		this.m_h = new CheckBox();
		this.m_i = new CheckBox();
		this.m_j = new CheckBox();
		this.m_k = new CheckBox();
		this.m_l = new CheckBox();
		this.m_m = new CheckBox();
		this.m_n = new GroupBox();
		this.m_o = new CheckBox();
		this.m_p = new CheckBox();
		this.m_q = new CheckBox();
		this.m_r = new CheckBox();
		this.m_s = new Button();
		this.m_t = new Button();
		u = new Button();
		v = new Label();
		w = new Label();
		x = new TextBox();
		y = new GroupBox();
		z = new CheckBox();
		((Control)this.m_f).SuspendLayout();
		((Control)this.m_n).SuspendLayout();
		((Control)y).SuspendLayout();
		((Control)this).SuspendLayout();
		((ListControl)lbMenuItems).FormattingEnabled = true;
		((Control)lbMenuItems).Location = new Point(15, 25);
		((Control)lbMenuItems).Name = "lbMenuItems";
		((Control)lbMenuItems).Size = new Size(199, 316);
		((Control)lbMenuItems).TabIndex = 0;
		lbMenuItems.SelectedIndexChanged += s;
		((Control)lbMenuItems).DoubleClick += d;
		((Control)this.m_c).AutoSize = true;
		((Control)this.m_c).Location = new Point(12, 9);
		((Control)this.m_c).Name = "label1";
		((Control)this.m_c).Size = new Size(65, 13);
		((Control)this.m_c).TabIndex = 1;
		((Control)this.m_c).Text = "Menu Items:";
		((Control)this.m_d).Location = new Point(15, 352);
		((Control)this.m_d).Name = "btnAdd";
		((Control)this.m_d).Size = new Size(49, 23);
		((Control)this.m_d).TabIndex = 2;
		((Control)this.m_d).Text = "Add";
		((ButtonBase)this.m_d).UseVisualStyleBackColor = true;
		((Control)this.m_d).Click += c;
		((Control)this.m_e).Location = new Point(165, 352);
		((Control)this.m_e).Name = "btnDelete";
		((Control)this.m_e).Size = new Size(49, 23);
		((Control)this.m_e).TabIndex = 3;
		((Control)this.m_e).Text = "Delete";
		((ButtonBase)this.m_e).UseVisualStyleBackColor = true;
		((Control)this.m_e).Click += t;
		((Control)this.m_f).Anchor = (AnchorStyles)6;
		((Control)this.m_f).Controls.Add((Control)(object)this.m_g);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_h);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_i);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_j);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_k);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_l);
		((Control)this.m_f).Controls.Add((Control)(object)this.m_m);
		((Control)this.m_f).Location = new Point(357, 56);
		((Control)this.m_f).Name = "groupBox1";
		((Control)this.m_f).Size = new Size(158, 190);
		((Control)this.m_f).TabIndex = 8;
		this.m_f.TabStop = false;
		((Control)this.m_f).Text = "Required Object Attributes";
		((Control)this.m_g).AutoSize = true;
		((Control)this.m_g).Location = new Point(6, 69);
		((Control)this.m_g).Name = "cbObjectContainer";
		((Control)this.m_g).RightToLeft = (RightToLeft)0;
		((Control)this.m_g).Size = new Size(71, 17);
		((Control)this.m_g).TabIndex = 11;
		((Control)this.m_g).Text = "Container";
		((ButtonBase)this.m_g).UseVisualStyleBackColor = true;
		this.m_g.CheckedChanged += i;
		((Control)this.m_h).AutoSize = true;
		((Control)this.m_h).Location = new Point(6, 161);
		((Control)this.m_h).Name = "cbObjectReadable";
		((Control)this.m_h).RightToLeft = (RightToLeft)0;
		((Control)this.m_h).Size = new Size(72, 17);
		((Control)this.m_h).TabIndex = 5;
		((Control)this.m_h).Text = "Readable";
		((ButtonBase)this.m_h).UseVisualStyleBackColor = true;
		this.m_h.CheckedChanged += e;
		((Control)this.m_i).AutoSize = true;
		((Control)this.m_i).Location = new Point(6, 138);
		((Control)this.m_i).Name = "cbObjectEnterable";
		((Control)this.m_i).RightToLeft = (RightToLeft)0;
		((Control)this.m_i).Size = new Size(71, 17);
		((Control)this.m_i).TabIndex = 4;
		((Control)this.m_i).Text = "Enterable";
		((ButtonBase)this.m_i).UseVisualStyleBackColor = true;
		this.m_i.CheckedChanged += f;
		((Control)this.m_j).AutoSize = true;
		((Control)this.m_j).Location = new Point(6, 115);
		((Control)this.m_j).Name = "cbObjectLockable";
		((Control)this.m_j).RightToLeft = (RightToLeft)0;
		((Control)this.m_j).Size = new Size(70, 17);
		((Control)this.m_j).TabIndex = 3;
		((Control)this.m_j).Text = "Lockable";
		((ButtonBase)this.m_j).UseVisualStyleBackColor = true;
		this.m_j.CheckedChanged += g;
		((Control)this.m_k).AutoSize = true;
		((Control)this.m_k).Location = new Point(6, 92);
		((Control)this.m_k).Name = "cbObjectOpenable";
		((Control)this.m_k).RightToLeft = (RightToLeft)0;
		((Control)this.m_k).Size = new Size(72, 17);
		((Control)this.m_k).TabIndex = 2;
		((Control)this.m_k).Text = "Openable";
		((ButtonBase)this.m_k).UseVisualStyleBackColor = true;
		this.m_k.CheckedChanged += h;
		((Control)this.m_l).AutoSize = true;
		((Control)this.m_l).Location = new Point(6, 46);
		((Control)this.m_l).Name = "cbObjectWearable";
		((Control)this.m_l).RightToLeft = (RightToLeft)0;
		((Control)this.m_l).Size = new Size(72, 17);
		((Control)this.m_l).TabIndex = 1;
		((Control)this.m_l).Text = "Wearable";
		((ButtonBase)this.m_l).UseVisualStyleBackColor = true;
		this.m_l.CheckedChanged += j;
		((Control)this.m_m).AutoSize = true;
		((Control)this.m_m).Location = new Point(6, 23);
		((Control)this.m_m).Name = "cbObjectCarryable";
		((Control)this.m_m).RightToLeft = (RightToLeft)0;
		((Control)this.m_m).Size = new Size(70, 17);
		((Control)this.m_m).TabIndex = 0;
		((Control)this.m_m).Text = "Carryable";
		((ButtonBase)this.m_m).UseVisualStyleBackColor = true;
		this.m_m.CheckedChanged += k;
		((Control)this.m_n).Anchor = (AnchorStyles)6;
		((Control)this.m_n).Controls.Add((Control)(object)this.m_o);
		((Control)this.m_n).Controls.Add((Control)(object)this.m_p);
		((Control)this.m_n).Controls.Add((Control)(object)this.m_q);
		((Control)this.m_n).Controls.Add((Control)(object)this.m_r);
		((Control)this.m_n).Location = new Point(221, 56);
		((Control)this.m_n).Name = "groupBox2";
		((Control)this.m_n).Size = new Size(130, 118);
		((Control)this.m_n).TabIndex = 9;
		this.m_n.TabStop = false;
		((Control)this.m_n).Text = "Show Command For";
		((Control)this.m_o).AutoSize = true;
		((Control)this.m_o).Location = new Point(6, 69);
		((Control)this.m_o).Name = "cbObjects";
		((Control)this.m_o).RightToLeft = (RightToLeft)0;
		((Control)this.m_o).Size = new Size(62, 17);
		((Control)this.m_o).TabIndex = 11;
		((Control)this.m_o).Text = "Objects";
		((ButtonBase)this.m_o).UseVisualStyleBackColor = true;
		this.m_o.CheckedChanged += o;
		this.m_o.CheckStateChanged += p;
		((Control)this.m_p).AutoSize = true;
		((Control)this.m_p).Location = new Point(6, 92);
		((Control)this.m_p).Name = "cbCharacters";
		((Control)this.m_p).RightToLeft = (RightToLeft)0;
		((Control)this.m_p).Size = new Size(77, 17);
		((Control)this.m_p).TabIndex = 2;
		((Control)this.m_p).Text = "Characters";
		((ButtonBase)this.m_p).UseVisualStyleBackColor = true;
		this.m_p.CheckedChanged += l;
		((Control)this.m_q).AutoSize = true;
		((Control)this.m_q).Location = new Point(6, 46);
		((Control)this.m_q).Name = "cbPlayer";
		((Control)this.m_q).RightToLeft = (RightToLeft)0;
		((Control)this.m_q).Size = new Size(55, 17);
		((Control)this.m_q).TabIndex = 1;
		((Control)this.m_q).Text = "Player";
		((ButtonBase)this.m_q).UseVisualStyleBackColor = true;
		this.m_q.CheckedChanged += m;
		((Control)this.m_r).AutoSize = true;
		((Control)this.m_r).Location = new Point(6, 23);
		((Control)this.m_r).Name = "cbRooms";
		((Control)this.m_r).RightToLeft = (RightToLeft)0;
		((Control)this.m_r).Size = new Size(59, 17);
		((Control)this.m_r).TabIndex = 0;
		((Control)this.m_r).Text = "Rooms";
		((ButtonBase)this.m_r).UseVisualStyleBackColor = true;
		this.m_r.CheckedChanged += n;
		this.m_s.DialogResult = (DialogResult)2;
		((Control)this.m_s).Location = new Point(440, 352);
		((Control)this.m_s).Name = "button1";
		((Control)this.m_s).Size = new Size(75, 23);
		((Control)this.m_s).TabIndex = 10;
		((Control)this.m_s).Text = "Close";
		((ButtonBase)this.m_s).UseVisualStyleBackColor = true;
		((Control)this.m_s).Click += r;
		((Control)this.m_t).Location = new Point(276, 352);
		((Control)this.m_t).Name = "button2";
		((Control)this.m_t).Size = new Size(98, 23);
		((Control)this.m_t).TabIndex = 11;
		((Control)this.m_t).Text = "Restore Defaults";
		((ButtonBase)this.m_t).UseVisualStyleBackColor = true;
		((Control)this.m_t).Click += q;
		((Control)u).Location = new Point(80, 352);
		((Control)u).Name = "btnEdit";
		((Control)u).Size = new Size(67, 23);
		((Control)u).TabIndex = 12;
		((Control)u).Text = "View/Edit";
		((ButtonBase)u).UseVisualStyleBackColor = true;
		((Control)u).Click += d;
		((Control)v).Location = new Point(221, 262);
		((Control)v).Name = "label2";
		((Control)v).Size = new Size(294, 69);
		((Control)v).TabIndex = 13;
		((Control)v).Text = componentResourceManager.GetString("label2.Text");
		((Control)w).AutoSize = true;
		((Control)w).Location = new Point(224, 9);
		((Control)w).Name = "label3";
		((Control)w).Size = new Size(91, 13);
		((Control)w).TabIndex = 14;
		((Control)w).Text = "Menu Item Name:";
		((Control)x).Location = new Point(227, 25);
		((Control)x).Name = "tbMenuItemName";
		((Control)x).Size = new Size(268, 20);
		((Control)x).TabIndex = 15;
		((Control)x).Leave += b;
		((Control)y).Controls.Add((Control)(object)z);
		((Control)y).Location = new Point(221, 181);
		((Control)y).Name = "groupBox3";
		((Control)y).Size = new Size(130, 65);
		((Control)y).TabIndex = 16;
		y.TabStop = false;
		((Control)y).Text = "Overwrite Commands";
		((Control)z).Location = new Point(6, 19);
		((Control)z).Name = "cbOverwrite";
		((Control)z).Size = new Size(118, 40);
		((Control)z).TabIndex = 0;
		((Control)z).Text = "Overwrite Actions Without Warning";
		((ButtonBase)z).UseVisualStyleBackColor = true;
		z.CheckedChanged += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)this.m_s;
		((Form)this).ClientSize = new Size(527, 387);
		((Control)this).Controls.Add((Control)(object)y);
		((Control)this).Controls.Add((Control)(object)x);
		((Control)this).Controls.Add((Control)(object)w);
		((Control)this).Controls.Add((Control)(object)v);
		((Control)this).Controls.Add((Control)(object)u);
		((Control)this).Controls.Add((Control)(object)this.m_t);
		((Control)this).Controls.Add((Control)(object)this.m_s);
		((Control)this).Controls.Add((Control)(object)this.m_n);
		((Control)this).Controls.Add((Control)(object)this.m_f);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)lbMenuItems);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "QuickMenuitemsFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "QuickMenuitemsFrm";
		((Control)this.m_f).ResumeLayout(false);
		((Control)this.m_f).PerformLayout();
		((Control)this.m_n).ResumeLayout(false);
		((Control)this.m_n).PerformLayout();
		((Control)y).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
