using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class GameInfoFrm : Form
{
	private IContainer m_a;

	private Label b;

	private Label c;

	private Label d;

	private Label e;

	private Label f;

	private TextBox g;

	private Button h;

	public GameInfoFrm(string autname, string ver, string info)
	{
		a();
		((Control)c).Text = autname;
		((Control)e).Text = ver;
		((Control)g).Text = info;
		((TextBoxBase)g).Select(0, 0);
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
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GameInfoFrm));
		b = new Label();
		c = new Label();
		d = new Label();
		e = new Label();
		f = new Label();
		g = new TextBox();
		h = new Button();
		((Control)this).SuspendLayout();
		((Control)b).AutoSize = true;
		((Control)b).Location = new Point(12, 9);
		((Control)b).Name = "label1";
		((Control)b).Size = new Size(41, 13);
		((Control)b).TabIndex = 0;
		((Control)b).Text = "Author:";
		((Control)c).AutoSize = true;
		((Control)c).Location = new Point(74, 9);
		((Control)c).Name = "lblAuthorName";
		((Control)c).Size = new Size(35, 13);
		((Control)c).TabIndex = 1;
		((Control)c).Text = "label2";
		((Control)d).AutoSize = true;
		((Control)d).Location = new Point(12, 33);
		((Control)d).Name = "label3";
		((Control)d).Size = new Size(45, 13);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Version:";
		((Control)e).AutoSize = true;
		((Control)e).Location = new Point(74, 33);
		((Control)e).Name = "lblVersion";
		((Control)e).Size = new Size(35, 13);
		((Control)e).TabIndex = 3;
		((Control)e).Text = "label4";
		((Control)f).AutoSize = true;
		((Control)f).Location = new Point(15, 65);
		((Control)f).Name = "label2";
		((Control)f).Size = new Size(93, 13);
		((Control)f).TabIndex = 4;
		((Control)f).Text = "Game Information:";
		((Control)g).Anchor = (AnchorStyles)15;
		((Control)g).Location = new Point(18, 82);
		((TextBoxBase)g).Multiline = true;
		((Control)g).Name = "tbGameInfo";
		((TextBoxBase)g).ReadOnly = true;
		g.ScrollBars = (ScrollBars)2;
		((Control)g).Size = new Size(469, 308);
		((Control)g).TabIndex = 5;
		((Control)h).Anchor = (AnchorStyles)2;
		h.DialogResult = (DialogResult)2;
		((Control)h).Location = new Point(213, 396);
		((Control)h).Name = "btnDone";
		((Control)h).Size = new Size(75, 23);
		((Control)h).TabIndex = 6;
		((Control)h).Text = "OK";
		((ButtonBase)h).UseVisualStyleBackColor = true;
		((Control)h).Click += a;
		((Form)this).AcceptButton = (IButtonControl)(object)h;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)h;
		((Form)this).ClientSize = new Size(499, 431);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "GameInfoFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "GameInfoFrm";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
