using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class AddActionWizard : Form
{
	private IContainer m_a;

	private Panel b;

	private TabControl c;

	private TabPage d;

	private TabPage e;

	private Button f;

	private Button g;

	private Button h;

	private Label i;

	public AddActionWizard()
	{
		a();
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_a != null)
		{
			this.m_a.Dispose();
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
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AddActionWizard));
		b = new Panel();
		c = new TabControl();
		d = new TabPage();
		i = new Label();
		e = new TabPage();
		f = new Button();
		g = new Button();
		h = new Button();
		((Control)b).SuspendLayout();
		((Control)c).SuspendLayout();
		((Control)d).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)b).Controls.Add((Control)(object)c);
		((Control)b).Location = new Point(-3, 0);
		((Control)b).Name = "panel1";
		((Control)b).Size = new Size(559, 378);
		((Control)b).TabIndex = 0;
		c.Alignment = (TabAlignment)1;
		((Control)c).Controls.Add((Control)(object)d);
		((Control)c).Controls.Add((Control)(object)e);
		((Control)c).Cursor = Cursors.Default;
		((Control)c).Dock = (DockStyle)5;
		((Control)c).Location = new Point(0, 0);
		c.Multiline = true;
		((Control)c).Name = "tabControl1";
		c.SelectedIndex = 0;
		((Control)c).Size = new Size(559, 378);
		((Control)c).TabIndex = 1;
		((Control)d).Controls.Add((Control)(object)i);
		d.Location = new Point(4, 4);
		((Control)d).Name = "tabPage1";
		((Control)d).Padding = new Padding(3);
		((Control)d).Size = new Size(551, 352);
		d.TabIndex = 0;
		((Control)d).Text = "tabPage1";
		d.UseVisualStyleBackColor = true;
		((Control)i).AutoSize = true;
		((Control)i).Location = new Point(11, 5);
		((Control)i).Name = "label1";
		((Control)i).Size = new Size(332, 13);
		((Control)i).TabIndex = 0;
		((Control)i).Text = "This wizard will help you complete adding a new action to your game.";
		e.Location = new Point(4, 4);
		((Control)e).Name = "tabPage2";
		((Control)e).Padding = new Padding(3);
		((Control)e).Size = new Size(551, 352);
		e.TabIndex = 1;
		((Control)e).Text = "tabPage2";
		e.UseVisualStyleBackColor = true;
		((Control)f).Location = new Point(216, 384);
		((Control)f).Name = "button1";
		((Control)f).Size = new Size(66, 23);
		((Control)f).TabIndex = 1;
		((Control)f).Text = "Previous";
		((ButtonBase)f).UseVisualStyleBackColor = true;
		((Control)g).Location = new Point(288, 384);
		((Control)g).Name = "button2";
		((Control)g).Size = new Size(66, 23);
		((Control)g).TabIndex = 2;
		((Control)g).Text = "Next";
		((ButtonBase)g).UseVisualStyleBackColor = true;
		((Control)h).Location = new Point(478, 384);
		((Control)h).Name = "button3";
		((Control)h).Size = new Size(66, 23);
		((Control)h).TabIndex = 3;
		((Control)h).Text = "Finish";
		((ButtonBase)h).UseVisualStyleBackColor = true;
		((Control)h).Click += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(556, 412);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AddActionWizard";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Form1";
		((Control)b).ResumeLayout(false);
		((Control)c).ResumeLayout(false);
		((Control)d).ResumeLayout(false);
		((Control)d).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
