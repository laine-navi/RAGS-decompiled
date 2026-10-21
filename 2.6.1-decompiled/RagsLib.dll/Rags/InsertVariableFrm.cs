using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class InsertVariableFrm : Form
{
	private Game m_a;

	private IContainer m_b;

	private Label m_c;

	private Button m_d;

	private Button m_e;

	public ListBox lbSysVariables;

	private TabPage m_f;

	private TabPage m_g;

	public ListBox lbVariables;

	private TabPage m_h;

	public ListBox lbCustProp;

	private TabPage i;

	public TabControl tabControl1;

	private Label j;

	private ComboBox k;

	private Label l;

	private ComboBox m;

	private Label n;

	private ComboBox o;

	private Label p;

	private ComboBox q;

	private Label r;

	private Label s;

	private ComboBox t;

	public TextBox tbText;

	public InsertVariableFrm(ref Game curgame)
	{
		a();
		this.m_a = curgame;
		((ListControl)q).SelectedIndex = 0;
	}

	private void h(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void g(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void f(object A_0, EventArgs A_1)
	{
		h(null, null);
	}

	private void e(object A_0, EventArgs A_1)
	{
		o.Items.Clear();
		((Control)o).Enabled = true;
		if (q.SelectedItem == "IA")
		{
			foreach (GameObject @object in this.m_a.ObjectList)
			{
				o.Items.Add((object)@object);
			}
		}
		else if (q.SelectedItem == "CA")
		{
			foreach (Character character in this.m_a.CharacterList)
			{
				o.Items.Add((object)character);
			}
		}
		else if (q.SelectedItem == "PA")
		{
			((Control)o).Enabled = false;
			m.Items.Clear();
			m.Items.Add((object)"Name");
			m.Items.Add((object)"Gender");
			m.Items.Add((object)"CurRoom");
			m.Items.Add((object)"CurPortrait");
			m.Items.Add((object)"Action");
		}
		else if (q.SelectedItem == "TA")
		{
			foreach (Timer timer in this.m_a.TimerList)
			{
				o.Items.Add((object)timer);
			}
		}
		else if (q.SelectedItem == "RA")
		{
			foreach (Room room in this.m_a.RoomList)
			{
				o.Items.Add((object)room);
			}
		}
		if (((Control)o).Enabled && o.Items.Count > 0)
		{
			((ListControl)o).SelectedIndex = 0;
		}
		else if (m.Items.Count > 0)
		{
			((ListControl)m).SelectedIndex = 0;
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		m.Items.Clear();
		Timer timer = o.SelectedItem as Timer;
		Character character = o.SelectedItem as Character;
		GameObject obj = o.SelectedItem as GameObject;
		Room room = o.SelectedItem as Room;
		if (obj != null)
		{
			m.Items.Add((object)"Name");
			m.Items.Add((object)"NameOverride");
			m.Items.Add((object)"ID");
			m.Items.Add((object)"ClothingLayers");
			m.Items.Add((object)"Action");
			m.Items.Add((object)"Preposition");
			m.Items.Add((object)"Description");
			m.Items.Add((object)"Important");
			m.Items.Add((object)"Carryable");
			m.Items.Add((object)"Wearable");
			m.Items.Add((object)"Worn");
			m.Items.Add((object)"Container");
			m.Items.Add((object)"Openable");
			m.Items.Add((object)"Open");
			m.Items.Add((object)"Lockable");
			m.Items.Add((object)"Locked");
			m.Items.Add((object)"Visible");
			m.Items.Add((object)"Enterable");
			m.Items.Add((object)"Readable");
			m.Items.Add((object)"Weight");
		}
		else if (room != null)
		{
			m.Items.Add((object)"Name");
			m.Items.Add((object)"Description");
			m.Items.Add((object)"Action");
			m.Items.Add((object)"Exit");
			m.Items.Add((object)"SDesc");
			m.Items.Add((object)"RoomPic");
			m.Items.Add((object)"EnteredFirstTime");
			m.Items.Add((object)"LeftFirstTime");
			m.Items.Add((object)"ID");
		}
		else if (character != null)
		{
			m.Items.Add((object)"Name");
			m.Items.Add((object)"OverrideName");
			m.Items.Add((object)"Action");
			m.Items.Add((object)"Gender");
			m.Items.Add((object)"CurrentRoom");
			m.Items.Add((object)"AllowInvInteraction");
		}
		else if (timer != null)
		{
			m.Items.Add((object)"Name");
			m.Items.Add((object)"Active");
			m.Items.Add((object)"TimerType");
			m.Items.Add((object)"Action");
			m.Items.Add((object)"Length");
			m.Items.Add((object)"TurnNumber");
			m.Items.Add((object)"LiveTimer");
			m.Items.Add((object)"TimerSeconds");
		}
		if (m.Items.Count > 0)
		{
			((ListControl)m).SelectedIndex = 0;
		}
		b();
	}

	private void c(object A_0, EventArgs A_1)
	{
		((Control)k).Enabled = false;
		((Control)t).Enabled = false;
		k.Items.Clear();
		t.Items.Clear();
		Timer timer = o.SelectedItem as Timer;
		Character character = o.SelectedItem as Character;
		GameObject gameObject = o.SelectedItem as GameObject;
		Room room = o.SelectedItem as Room;
		if (m.SelectedItem == "Action")
		{
			((Control)k).Enabled = true;
			((Control)t).Enabled = true;
			ArrayList arrayList = null;
			if (q.SelectedItem == "PA")
			{
				arrayList = this.m_a.ThePlayer.Actions;
			}
			else if (gameObject != null)
			{
				arrayList = gameObject.Actions;
			}
			else if (character != null)
			{
				arrayList = character.Actions;
			}
			else if (timer != null)
			{
				arrayList = timer.Actions;
			}
			else if (room != null)
			{
				arrayList = room.Actions;
			}
			if (arrayList != null)
			{
				foreach (Action item in arrayList)
				{
					k.Items.Add((object)item);
				}
			}
			if (k.Items.Count > 0)
			{
				((ListControl)k).SelectedIndex = 0;
			}
		}
		else if (m.SelectedItem == "Exit")
		{
			((Control)k).Enabled = true;
			((Control)t).Enabled = true;
			string[] names = Enum.GetNames(typeof(Exit.Directions));
			foreach (string text in names)
			{
				k.Items.Add((object)text);
			}
			if (k.Items.Count > 0)
			{
				((ListControl)k).SelectedIndex = 0;
			}
		}
		b();
	}

	private void b(object A_0, EventArgs A_1)
	{
		b();
	}

	private void a(object A_0, EventArgs A_1)
	{
		t.Items.Clear();
		if (m.SelectedItem == "Exit")
		{
			t.Items.Add((object)"Active");
			t.Items.Add((object)"Destination");
			t.Items.Add((object)"Portal");
			((ListControl)t).SelectedIndex = 0;
		}
		else
		{
			t.Items.Add((object)"Active");
			t.Items.Add((object)"OverrideName");
			t.Items.Add((object)"ActionParent");
			t.Items.Add((object)"InputType");
			((ListControl)t).SelectedIndex = 0;
		}
		b();
	}

	private void b()
	{
		string empty = string.Empty;
		try
		{
			empty = string.Concat("[", q.SelectedItem, ":");
			if (o.SelectedItem != null)
			{
				empty = empty + o.SelectedItem.ToString() + ":";
			}
			empty += m.SelectedItem.ToString();
			if (((Control)k).Enabled)
			{
				empty = empty + ":" + k.SelectedItem.ToString() + ":" + t.SelectedItem.ToString();
			}
			empty += "]";
		}
		catch
		{
			empty = string.Empty;
		}
		((Control)tbText).Text = empty;
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
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InsertVariableFrm));
		lbSysVariables = new ListBox();
		this.m_c = new Label();
		this.m_d = new Button();
		this.m_e = new Button();
		tabControl1 = new TabControl();
		this.m_f = new TabPage();
		this.m_g = new TabPage();
		lbVariables = new ListBox();
		this.m_h = new TabPage();
		lbCustProp = new ListBox();
		i = new TabPage();
		r = new Label();
		tbText = new TextBox();
		s = new Label();
		t = new ComboBox();
		j = new Label();
		k = new ComboBox();
		l = new Label();
		m = new ComboBox();
		n = new Label();
		o = new ComboBox();
		p = new Label();
		q = new ComboBox();
		((Control)tabControl1).SuspendLayout();
		((Control)this.m_f).SuspendLayout();
		((Control)this.m_g).SuspendLayout();
		((Control)this.m_h).SuspendLayout();
		((Control)i).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lbSysVariables).Dock = (DockStyle)5;
		((ListControl)lbSysVariables).FormattingEnabled = true;
		((Control)lbSysVariables).Location = new Point(3, 3);
		((Control)lbSysVariables).Name = "lbSysVariables";
		((Control)lbSysVariables).Size = new Size(445, 315);
		((Control)lbSysVariables).TabIndex = 0;
		((Control)lbSysVariables).DoubleClick += f;
		((Control)this.m_c).AutoSize = true;
		((Control)this.m_c).Location = new Point(12, 9);
		((Control)this.m_c).Name = "label1";
		((Control)this.m_c).Size = new Size(157, 13);
		((Control)this.m_c).TabIndex = 1;
		((Control)this.m_c).Text = "Select Variable Name To Insert:";
		((Control)this.m_d).Anchor = (AnchorStyles)2;
		((Control)this.m_d).Location = new Point(104, 378);
		((Control)this.m_d).Name = "btnInsert";
		((Control)this.m_d).Size = new Size(86, 23);
		((Control)this.m_d).TabIndex = 2;
		((Control)this.m_d).Text = "Insert Variable";
		((ButtonBase)this.m_d).UseVisualStyleBackColor = true;
		((Control)this.m_d).Click += h;
		((Control)this.m_e).Anchor = (AnchorStyles)2;
		this.m_e.DialogResult = (DialogResult)2;
		((Control)this.m_e).Location = new Point(292, 378);
		((Control)this.m_e).Name = "btnCancel";
		((Control)this.m_e).Size = new Size(86, 23);
		((Control)this.m_e).TabIndex = 3;
		((Control)this.m_e).Text = "Cancel";
		((ButtonBase)this.m_e).UseVisualStyleBackColor = true;
		((Control)this.m_e).Click += g;
		tabControl1.Alignment = (TabAlignment)1;
		((Control)tabControl1).Anchor = (AnchorStyles)15;
		((Control)tabControl1).Controls.Add((Control)(object)this.m_f);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_g);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_h);
		((Control)tabControl1).Controls.Add((Control)(object)i);
		((Control)tabControl1).Location = new Point(12, 25);
		((Control)tabControl1).Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(459, 347);
		((Control)tabControl1).TabIndex = 4;
		((Control)this.m_f).Controls.Add((Control)(object)lbSysVariables);
		this.m_f.Location = new Point(4, 4);
		((Control)this.m_f).Name = "tabPage1";
		((Control)this.m_f).Padding = new Padding(3);
		((Control)this.m_f).Size = new Size(451, 321);
		this.m_f.TabIndex = 0;
		((Control)this.m_f).Text = "System Variables";
		this.m_f.UseVisualStyleBackColor = true;
		((Control)this.m_g).Controls.Add((Control)(object)lbVariables);
		this.m_g.Location = new Point(4, 4);
		((Control)this.m_g).Name = "tabPage2";
		((Control)this.m_g).Padding = new Padding(3);
		((Control)this.m_g).Size = new Size(451, 321);
		this.m_g.TabIndex = 1;
		((Control)this.m_g).Text = "Variables";
		this.m_g.UseVisualStyleBackColor = true;
		((Control)lbVariables).Dock = (DockStyle)5;
		((ListControl)lbVariables).FormattingEnabled = true;
		((Control)lbVariables).Location = new Point(3, 3);
		((Control)lbVariables).Name = "lbVariables";
		((Control)lbVariables).Size = new Size(445, 315);
		((Control)lbVariables).TabIndex = 1;
		((Control)lbVariables).DoubleClick += f;
		((Control)this.m_h).Controls.Add((Control)(object)lbCustProp);
		this.m_h.Location = new Point(4, 4);
		((Control)this.m_h).Name = "tabPage3";
		((Control)this.m_h).Padding = new Padding(3);
		((Control)this.m_h).Size = new Size(451, 321);
		this.m_h.TabIndex = 2;
		((Control)this.m_h).Text = "Custom Properties";
		this.m_h.UseVisualStyleBackColor = true;
		((Control)lbCustProp).Dock = (DockStyle)5;
		((ListControl)lbCustProp).FormattingEnabled = true;
		((Control)lbCustProp).Location = new Point(3, 3);
		((Control)lbCustProp).Name = "lbCustProp";
		((Control)lbCustProp).Size = new Size(445, 315);
		((Control)lbCustProp).TabIndex = 2;
		((Control)lbCustProp).DoubleClick += f;
		((Control)i).Controls.Add((Control)(object)r);
		((Control)i).Controls.Add((Control)(object)tbText);
		((Control)i).Controls.Add((Control)(object)s);
		((Control)i).Controls.Add((Control)(object)t);
		((Control)i).Controls.Add((Control)(object)j);
		((Control)i).Controls.Add((Control)(object)k);
		((Control)i).Controls.Add((Control)(object)l);
		((Control)i).Controls.Add((Control)(object)m);
		((Control)i).Controls.Add((Control)(object)n);
		((Control)i).Controls.Add((Control)(object)o);
		((Control)i).Controls.Add((Control)(object)p);
		((Control)i).Controls.Add((Control)(object)q);
		i.Location = new Point(4, 4);
		((Control)i).Name = "tabPage4";
		((Control)i).Padding = new Padding(3);
		((Control)i).Size = new Size(451, 321);
		i.TabIndex = 3;
		((Control)i).Text = "Objects";
		i.UseVisualStyleBackColor = true;
		((Control)r).AutoSize = true;
		((Control)r).Location = new Point(6, 279);
		((Control)r).Name = "label7";
		((Control)r).Size = new Size(76, 13);
		((Control)r).TabIndex = 11;
		((Control)r).Text = "Text To Insert:";
		((Control)tbText).Anchor = (AnchorStyles)14;
		((Control)tbText).Location = new Point(6, 295);
		((Control)tbText).Name = "tbText";
		((Control)tbText).Size = new Size(439, 20);
		((Control)tbText).TabIndex = 10;
		((Control)s).AutoSize = true;
		((Control)s).Location = new Point(179, 66);
		((Control)s).Name = "label6";
		((Control)s).Size = new Size(103, 13);
		((Control)s).TabIndex = 9;
		((Control)s).Text = "Secondary Attribute:";
		((Control)t).Enabled = false;
		((ListControl)t).FormattingEnabled = true;
		((Control)t).Location = new Point(179, 82);
		((Control)t).Name = "cbSecondaryAttribute";
		((Control)t).Size = new Size(214, 21);
		t.Sorted = true;
		((Control)t).TabIndex = 8;
		t.SelectedIndexChanged += b;
		((Control)j).AutoSize = true;
		((Control)j).Location = new Point(6, 66);
		((Control)j).Name = "label5";
		((Control)j).Size = new Size(71, 13);
		((Control)j).TabIndex = 7;
		((Control)j).Text = "Action Name:";
		((Control)k).Enabled = false;
		((ListControl)k).FormattingEnabled = true;
		((Control)k).Location = new Point(6, 82);
		((Control)k).Name = "cbActionName";
		((Control)k).Size = new Size(151, 21);
		k.Sorted = true;
		((Control)k).TabIndex = 6;
		k.SelectedIndexChanged += a;
		((Control)l).AutoSize = true;
		((Control)l).Location = new Point(256, 10);
		((Control)l).Name = "label4";
		((Control)l).Size = new Size(49, 13);
		((Control)l).TabIndex = 5;
		((Control)l).Text = "Attribute:";
		((ListControl)m).FormattingEnabled = true;
		((Control)m).Location = new Point(256, 26);
		((Control)m).Name = "cbAttribute";
		((Control)m).Size = new Size(189, 21);
		m.Sorted = true;
		((Control)m).TabIndex = 4;
		m.SelectedIndexChanged += c;
		((Control)n).AutoSize = true;
		((Control)n).Location = new Point(85, 10);
		((Control)n).Name = "label3";
		((Control)n).Size = new Size(72, 13);
		((Control)n).TabIndex = 3;
		((Control)n).Text = "Object Name:";
		((ListControl)o).FormattingEnabled = true;
		((Control)o).Location = new Point(85, 26);
		((Control)o).Name = "cbObject";
		((Control)o).Size = new Size(165, 21);
		o.Sorted = true;
		((Control)o).TabIndex = 2;
		o.SelectedIndexChanged += d;
		((Control)p).AutoSize = true;
		((Control)p).Location = new Point(6, 10);
		((Control)p).Name = "label2";
		((Control)p).Size = new Size(68, 13);
		((Control)p).TabIndex = 1;
		((Control)p).Text = "Object Type:";
		((ListControl)q).FormattingEnabled = true;
		q.Items.AddRange(new object[5] { "CA", "IA", "PA", "RA", "TA" });
		((Control)q).Location = new Point(6, 26);
		((Control)q).Name = "cbObjectType";
		((Control)q).Size = new Size(68, 21);
		q.Sorted = true;
		((Control)q).TabIndex = 0;
		q.SelectedIndexChanged += e;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(483, 411);
		((Control)this).Controls.Add((Control)(object)tabControl1);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "InsertVariableFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Insert Variable";
		((Control)tabControl1).ResumeLayout(false);
		((Control)this.m_f).ResumeLayout(false);
		((Control)this.m_g).ResumeLayout(false);
		((Control)this.m_h).ResumeLayout(false);
		((Control)i).ResumeLayout(false);
		((Control)i).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
