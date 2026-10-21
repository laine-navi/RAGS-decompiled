using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class RoomDesigner : Form
{
	private Label m_a;

	public TextBox txtDescription;

	private Label m_b;

	private Label m_c;

	private ListBox m_d;

	private Label m_e;

	private ListBox m_f;

	private Button g;

	private ContextMenu h;

	private MenuItem i;

	private MenuItem j;

	public TextBox txtSDesc;

	public TextBox txtRoomName;

	private Label k;

	public PictureBox picRoom;

	private OpenFileDialog l;

	private Button m;

	public Room CurRoom;

	private Button n;

	private Container o;

	public RoomDesigner(Room TheRoom)
	{
		a();
		CurRoom = TheRoom;
		if (TheRoom != null)
		{
			((Control)txtRoomName).Text = TheRoom.Name;
			((Control)txtDescription).Text = TheRoom.Description;
			((Control)txtSDesc).Text = TheRoom.SDesc;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && o != null)
		{
			o.Dispose();
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
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RoomDesigner));
		this.m_a = new Label();
		txtDescription = new TextBox();
		txtSDesc = new TextBox();
		this.m_b = new Label();
		this.m_d = new ListBox();
		h = new ContextMenu();
		i = new MenuItem();
		j = new MenuItem();
		this.m_c = new Label();
		this.m_e = new Label();
		this.m_f = new ListBox();
		g = new Button();
		txtRoomName = new TextBox();
		k = new Label();
		picRoom = new PictureBox();
		l = new OpenFileDialog();
		m = new Button();
		n = new Button();
		((ISupportInitialize)picRoom).BeginInit();
		((Control)this).SuspendLayout();
		((Control)this.m_a).Location = new Point(16, 33);
		((Control)this.m_a).Name = "label1";
		((Control)this.m_a).Size = new Size(64, 16);
		((Control)this.m_a).TabIndex = 0;
		((Control)this.m_a).Text = "Description:";
		((Control)txtDescription).Location = new Point(80, 25);
		((Control)txtDescription).Name = "txtDescription";
		((Control)txtDescription).Size = new Size(296, 20);
		((Control)txtDescription).TabIndex = 1;
		((Control)txtDescription).Text = "textBox1";
		((Control)txtSDesc).Location = new Point(80, 49);
		((Control)txtSDesc).Name = "txtSDesc";
		((Control)txtSDesc).Size = new Size(296, 20);
		((Control)txtSDesc).TabIndex = 3;
		((Control)txtSDesc).Text = "textBox1";
		((Control)this.m_b).Location = new Point(16, 57);
		((Control)this.m_b).Name = "label2";
		((Control)this.m_b).Size = new Size(64, 16);
		((Control)this.m_b).TabIndex = 2;
		((Control)this.m_b).Text = "Short Desc:";
		((Control)this.m_d).ContextMenu = h;
		((Control)this.m_d).Location = new Point(16, 104);
		((Control)this.m_d).Name = "lbExits";
		((Control)this.m_d).Size = new Size(120, 199);
		((Control)this.m_d).TabIndex = 4;
		this.m_d.SelectedIndexChanged += f;
		((Menu)h).MenuItems.AddRange(new MenuItem[2] { i, j });
		h.Popup += e;
		i.Index = 0;
		i.Text = "&Add";
		i.Click += d;
		j.Index = 1;
		j.Text = "&Delete";
		((Control)this.m_c).Location = new Point(16, 81);
		((Control)this.m_c).Name = "label3";
		((Control)this.m_c).Size = new Size(100, 16);
		((Control)this.m_c).TabIndex = 5;
		((Control)this.m_c).Text = "Exits:";
		((Control)this.m_e).Location = new Point(240, 82);
		((Control)this.m_e).Name = "label4";
		((Control)this.m_e).Size = new Size(100, 16);
		((Control)this.m_e).TabIndex = 7;
		((Control)this.m_e).Text = "Objects:";
		((Control)this.m_f).ContextMenu = h;
		((Control)this.m_f).Location = new Point(240, 104);
		((Control)this.m_f).Name = "lbObjects";
		((Control)this.m_f).Size = new Size(120, 199);
		((Control)this.m_f).TabIndex = 6;
		((Control)g).Location = new Point(152, 304);
		((Control)g).Name = "btnApply";
		((Control)g).Size = new Size(75, 23);
		((Control)g).TabIndex = 8;
		((Control)g).Text = "Apply";
		((Control)g).Click += c;
		((Control)txtRoomName).Location = new Point(80, 1);
		((Control)txtRoomName).Name = "txtRoomName";
		((Control)txtRoomName).Size = new Size(296, 20);
		((Control)txtRoomName).TabIndex = 10;
		((Control)txtRoomName).Text = "textBox1";
		((Control)k).Location = new Point(8, 9);
		((Control)k).Name = "label5";
		((Control)k).Size = new Size(72, 16);
		((Control)k).TabIndex = 9;
		((Control)k).Text = "Room Name:";
		picRoom.BorderStyle = (BorderStyle)1;
		((Control)picRoom).Location = new Point(376, 112);
		((Control)picRoom).Name = "picRoom";
		((Control)picRoom).Size = new Size(160, 192);
		picRoom.SizeMode = (PictureBoxSizeMode)1;
		picRoom.TabIndex = 11;
		picRoom.TabStop = false;
		((Control)m).Location = new Point(376, 80);
		((Control)m).Name = "button1";
		((Control)m).Size = new Size(75, 23);
		((Control)m).TabIndex = 12;
		((Control)m).Text = "Load Pic...";
		((Control)m).Click += b;
		((Control)n).Location = new Point(256, 304);
		((Control)n).Name = "button2";
		((Control)n).Size = new Size(75, 23);
		((Control)n).TabIndex = 13;
		((Control)n).Text = "Cancel";
		((Control)n).Click += a;
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Form)this).ClientSize = new Size(688, 398);
		((Control)this).Controls.Add((Control)(object)n);
		((Control)this).Controls.Add((Control)(object)m);
		((Control)this).Controls.Add((Control)(object)picRoom);
		((Control)this).Controls.Add((Control)(object)txtRoomName);
		((Control)this).Controls.Add((Control)(object)txtSDesc);
		((Control)this).Controls.Add((Control)(object)txtDescription);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_f);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)this.m_a);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "RoomDesigner";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "RoomDesigner";
		((ISupportInitialize)picRoom).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void f(object A_0, EventArgs A_1)
	{
	}

	private void e(object A_0, EventArgs A_1)
	{
	}

	private void d(object A_0, EventArgs A_1)
	{
		if (!((Control)this.m_d).Focused)
		{
			_ = ((Control)this.m_f).Focused;
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)l).ShowDialog() != 2)
		{
			picRoom.Image = Image.FromFile(((FileDialog)l).FileName);
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}
}
