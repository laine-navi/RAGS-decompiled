using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rags;

public class RagsEditor : Form
{
	private enum a
	{
		a,
		b,
		c,
		d,
		e
	}

	private a m_a;

	public object controlref;

	private string m_b = string.Empty;

	private Game m_c;

	private Action m_d;

	private IContainer m_e;

	private RichTextBox m_f;

	private ToolStrip m_g;

	private ToolStripButton m_h;

	private ToolStripButton m_i;

	private ToolStripButton m_j;

	private ToolStripSeparator m_k;

	private ToolStripButton l;

	private ToolStripButton m;

	private ColorDialog n;

	private Button o;

	private Button p;

	private ToolStripButton q;

	private Button r;

	private FontDialog s;

	private ToolStripButton t;

	private Button u;

	public RagsEditor(ref TextBox control, Game curgame)
	{
		a();
		this.m_a = RagsEditor.a.a;
		controlref = control;
		((Control)this.m_f).Text = ((Control)control).Text;
		this.m_c = curgame;
	}

	public RagsEditor(ref Action curAction)
	{
		a();
		this.m_a = RagsEditor.a.e;
		this.m_d = curAction;
		StringBuilder CurDoc = new StringBuilder();
		this.m_d.GetAdvancedText(ref CurDoc);
		((Control)this.m_f).Text = CurDoc.ToString();
	}

	public RagsEditor(ref RichTextBox control, Game curgame)
	{
		a();
		this.m_a = RagsEditor.a.c;
		controlref = control;
		((Control)this.m_f).Text = ((Control)control).Text;
		this.m_c = curgame;
	}

	public RagsEditor(ref ComboBox control, Game curgame)
	{
		a();
		this.m_a = RagsEditor.a.b;
		controlref = control;
		((Control)this.m_f).Text = ((Control)control).Text;
		this.m_c = curgame;
	}

	public RagsEditor(ref DataGridViewCell control, Game curgame)
	{
		a();
		this.m_a = RagsEditor.a.d;
		controlref = control;
		if (control.Value != null)
		{
			((Control)this.m_f).Text = control.Value.ToString();
		}
		else
		{
			((Control)this.m_f).Text = string.Empty;
		}
		this.m_c = curgame;
	}

	private void k(object A_0, EventArgs A_1)
	{
		int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + 3;
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, "[b]");
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "[/b]");
		((TextBoxBase)this.m_f).SelectionStart = selectionStart;
		((TextBoxBase)this.m_f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)this.m_f).ScrollToCaret();
	}

	private void j(object A_0, EventArgs A_1)
	{
		string text = ((Control)this.m_f).Text;
		text = text.Replace("\n", "\r\n");
		switch (this.m_a)
		{
		case RagsEditor.a.a:
		{
			object obj4 = controlref;
			((Control)((obj4 is TextBox) ? obj4 : null)).Text = text;
			break;
		}
		case RagsEditor.a.b:
		{
			object obj3 = controlref;
			((Control)((obj3 is ComboBox) ? obj3 : null)).Text = text;
			break;
		}
		case RagsEditor.a.c:
		{
			object obj2 = controlref;
			((Control)((obj2 is RichTextBox) ? obj2 : null)).Text = text;
			break;
		}
		case RagsEditor.a.d:
		{
			object obj = controlref;
			((DataGridViewCell)((obj is DataGridViewCell) ? obj : null)).Value = text;
			break;
		}
		case RagsEditor.a.e:
			_ = this.m_d;
			break;
		}
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void i(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void h(object A_0, EventArgs A_1)
	{
		if (((Control)r).Text == "Edit View")
		{
			((TextBoxBase)this.m_f).Clear();
			((Control)this.m_f).Text = this.m_b;
			((Control)r).Text = "Preview View";
			((Control)o).Enabled = true;
			((Control)p).Enabled = true;
			((Control)this.m_g).Enabled = true;
			((Control)u).Enabled = false;
			((TextBoxBase)this.m_f).ReadOnly = false;
		}
		else
		{
			((Control)o).Enabled = false;
			((Control)p).Enabled = false;
			((Control)this.m_g).Enabled = false;
			((Control)u).Enabled = true;
			this.m_b = ((Control)this.m_f).Text;
			((TextBoxBase)this.m_f).Clear();
			((TextBoxBase)this.m_f).ReadOnly = true;
			TextHandlers.AddTextToRTF(ref this.m_f, ref this.m_c, this.m_b, Color.Black, (FontStyle)0);
			((Control)r).Text = "Edit View";
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + 3;
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, "[i]");
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "[/i]");
		((TextBoxBase)this.m_f).SelectionStart = selectionStart;
		((TextBoxBase)this.m_f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)this.m_f).ScrollToCaret();
	}

	private void f(object A_0, EventArgs A_1)
	{
		int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + 3;
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, "[u]");
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "[/u]");
		((TextBoxBase)this.m_f).SelectionStart = selectionStart;
		((TextBoxBase)this.m_f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)this.m_f).ScrollToCaret();
	}

	private void e(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)n).ShowDialog() == 1)
		{
			int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
			string text = "<span style=\"color:";
			text = ((!n.Color.IsNamedColor) ? (text + "rgb(" + n.Color.R + "," + n.Color.G + "," + n.Color.B + ")\">") : (text + n.Color.Name + "\">"));
			int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + text.Length;
			((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, text);
			((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "</span>");
			((TextBoxBase)this.m_f).SelectionStart = selectionStart;
			((TextBoxBase)this.m_f).SelectionLength = num + 4 - selectionStart;
			((TextBoxBase)this.m_f).ScrollToCaret();
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + 8;
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, "[middle]");
		((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "[/middle]");
		((TextBoxBase)this.m_f).SelectionStart = selectionStart;
		((TextBoxBase)this.m_f).SelectionLength = num + 9 - selectionStart;
		((TextBoxBase)this.m_f).ScrollToCaret();
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)s).ShowDialog() == 1)
		{
			int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
			string text = "[f " + s.Font.Name + "," + s.Font.Size + "]";
			int num = selectionStart + ((TextBoxBase)this.m_f).SelectionLength + text.Length;
			((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(((TextBoxBase)this.m_f).SelectionStart, text);
			((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(num, "[/f]");
			((TextBoxBase)this.m_f).SelectionStart = selectionStart;
			((TextBoxBase)this.m_f).SelectionLength = num + 4 - selectionStart;
			((TextBoxBase)this.m_f).ScrollToCaret();
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		int selectionStart = ((TextBoxBase)this.m_f).SelectionStart;
		string text = TextHandlers.insertVariableToolStripMenuItem(this.m_c);
		if (text != string.Empty)
		{
			((Control)this.m_f).Text = ((Control)this.m_f).Text.Insert(selectionStart, text);
			((TextBoxBase)this.m_f).SelectionStart = selectionStart + text.Length;
			((TextBoxBase)this.m_f).ScrollToCaret();
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		MathEval.EvaluateString(ref result, ((Control)this.m_f).Text);
		MessageBox.Show(result.ToString(), "Evaluation Results");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_e != null)
		{
			this.m_e.Dispose();
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
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected Obj, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected Obj, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected Obj, but got Unknown
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected Obj, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected Obj, but got Unknown
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected Obj, but got Unknown
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsEditor));
		this.m_f = new RichTextBox();
		this.m_g = new ToolStrip();
		this.m_h = new ToolStripButton();
		this.m_i = new ToolStripButton();
		this.m_j = new ToolStripButton();
		this.m_k = new ToolStripSeparator();
		l = new ToolStripButton();
		m = new ToolStripButton();
		q = new ToolStripButton();
		t = new ToolStripButton();
		n = new ColorDialog();
		o = new Button();
		p = new Button();
		r = new Button();
		s = new FontDialog();
		u = new Button();
		((Control)this.m_g).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)this.m_f).Anchor = (AnchorStyles)15;
		((Control)this.m_f).Location = new Point(12, 28);
		((Control)this.m_f).Name = "rtEdit";
		((Control)this.m_f).Size = new Size(564, 394);
		((Control)this.m_f).TabIndex = 0;
		((Control)this.m_f).Text = "";
		this.m_g.Items.AddRange(new ToolStripItem[8]
		{
			(ToolStripItem)this.m_h,
			(ToolStripItem)this.m_i,
			(ToolStripItem)this.m_j,
			(ToolStripItem)this.m_k,
			(ToolStripItem)l,
			(ToolStripItem)m,
			(ToolStripItem)q,
			(ToolStripItem)t
		});
		((Control)this.m_g).Location = new Point(0, 0);
		((Control)this.m_g).Name = "toolStrip1";
		((Control)this.m_g).Size = new Size(588, 25);
		((Control)this.m_g).TabIndex = 1;
		((Control)this.m_g).Text = "toolStrip1";
		((ToolStripItem)this.m_h).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)this.m_h).Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
		((ToolStripItem)this.m_h).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)this.m_h).Name = "toolStripButton1";
		((ToolStripItem)this.m_h).Size = new Size(35, 22);
		((ToolStripItem)this.m_h).Text = "Bold";
		((ToolStripItem)this.m_h).Click += k;
		((ToolStripItem)this.m_i).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)this.m_i).Image = (Image)componentResourceManager.GetObject("toolStripButton2.Image");
		((ToolStripItem)this.m_i).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)this.m_i).Name = "toolStripButton2";
		((ToolStripItem)this.m_i).Size = new Size(36, 22);
		((ToolStripItem)this.m_i).Text = "Italic";
		((ToolStripItem)this.m_i).Click += g;
		((ToolStripItem)this.m_j).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)this.m_j).Image = (Image)componentResourceManager.GetObject("toolStripButton3.Image");
		((ToolStripItem)this.m_j).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)this.m_j).Name = "toolStripButton3";
		((ToolStripItem)this.m_j).Size = new Size(71, 22);
		((ToolStripItem)this.m_j).Text = "Underscore";
		((ToolStripItem)this.m_j).Click += f;
		((ToolStripItem)this.m_k).Name = "toolStripSeparator1";
		((ToolStripItem)this.m_k).Size = new Size(6, 25);
		((ToolStripItem)l).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)l).Image = (Image)componentResourceManager.GetObject("toolStripButton4.Image");
		((ToolStripItem)l).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)l).Name = "toolStripButton4";
		((ToolStripItem)l).Size = new Size(40, 22);
		((ToolStripItem)l).Text = "Color";
		((ToolStripItem)l).Click += e;
		((ToolStripItem)m).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)m).Image = (Image)componentResourceManager.GetObject("toolStripButton5.Image");
		((ToolStripItem)m).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)m).Name = "toolStripButton5";
		((ToolStripItem)m).Size = new Size(35, 22);
		((ToolStripItem)m).Text = "Font";
		((ToolStripItem)m).Click += c;
		((ToolStripItem)q).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)q).Image = (Image)componentResourceManager.GetObject("toolStripButton6.Image");
		((ToolStripItem)q).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)q).Name = "toolStripButton6";
		((ToolStripItem)q).Size = new Size(48, 22);
		((ToolStripItem)q).Text = "Middle";
		((ToolStripItem)q).Click += d;
		((ToolStripItem)t).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)t).Image = (Image)componentResourceManager.GetObject("toolStripButton7.Image");
		((ToolStripItem)t).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)t).Name = "toolStripButton7";
		((ToolStripItem)t).Size = new Size(58, 22);
		((ToolStripItem)t).Text = "&Variables";
		((ToolStripItem)t).Click += b;
		((Control)o).Anchor = (AnchorStyles)2;
		((Control)o).Location = new Point(200, 429);
		((Control)o).Name = "btnApply";
		((Control)o).Size = new Size(75, 23);
		((Control)o).TabIndex = 2;
		((Control)o).Text = "Apply";
		((ButtonBase)o).UseVisualStyleBackColor = true;
		((Control)o).Click += j;
		((Control)p).Anchor = (AnchorStyles)2;
		((Control)p).Location = new Point(314, 429);
		((Control)p).Name = "btnCancel";
		((Control)p).Size = new Size(75, 23);
		((Control)p).TabIndex = 3;
		((Control)p).Text = "Cancel";
		((ButtonBase)p).UseVisualStyleBackColor = true;
		((Control)p).Click += i;
		((Control)r).Anchor = (AnchorStyles)6;
		((Control)r).Location = new Point(12, 429);
		((Control)r).Name = "btnPreviewEdit";
		((Control)r).Size = new Size(100, 23);
		((Control)r).TabIndex = 4;
		((Control)r).Text = "Preview View";
		((ButtonBase)r).UseVisualStyleBackColor = true;
		((Control)r).Click += h;
		s.ShowEffects = false;
		((Control)u).Anchor = (AnchorStyles)10;
		((Control)u).Enabled = false;
		((Control)u).Location = new Point(484, 428);
		((Control)u).Name = "btnTestJS";
		((Control)u).Size = new Size(91, 23);
		((Control)u).TabIndex = 5;
		((Control)u).Text = "Test JavaScript";
		((ButtonBase)u).UseVisualStyleBackColor = true;
		((Control)u).Click += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(588, 454);
		((Control)this).Controls.Add((Control)(object)u);
		((Control)this).Controls.Add((Control)(object)r);
		((Control)this).Controls.Add((Control)(object)p);
		((Control)this).Controls.Add((Control)(object)o);
		((Control)this).Controls.Add((Control)(object)this.m_g);
		((Control)this).Controls.Add((Control)(object)this.m_f);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "RagsEditor";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Rags Editor";
		((Control)this.m_g).ResumeLayout(false);
		((Control)this.m_g).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
