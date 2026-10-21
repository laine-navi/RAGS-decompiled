using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class HelpFrm : Form
{
	private IContainer m_a;

	private Button b;

	private Panel c;

	public Label lblTitle;

	public RichTextBox rtText;

	public HelpFrm()
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
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected Obj, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpFrm));
		b = new Button();
		c = new Panel();
		lblTitle = new Label();
		rtText = new RichTextBox();
		((Control)c).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)b).Anchor = (AnchorStyles)2;
		b.DialogResult = (DialogResult)2;
		((Control)b).Location = new Point(219, 309);
		((Control)b).Name = "btnOK";
		((Control)b).Size = new Size(75, 23);
		((Control)b).TabIndex = 0;
		((Control)b).Text = "OK";
		((ButtonBase)b).UseVisualStyleBackColor = true;
		((Control)b).Click += a;
		((Control)c).Anchor = (AnchorStyles)15;
		((Control)c).Controls.Add((Control)(object)lblTitle);
		((Control)c).Controls.Add((Control)(object)rtText);
		((Control)c).Location = new Point(12, 12);
		((Control)c).Name = "panel1";
		((Control)c).Size = new Size(488, 291);
		((Control)c).TabIndex = 1;
		((Control)lblTitle).Anchor = (AnchorStyles)1;
		((Control)lblTitle).AutoSize = true;
		((Control)lblTitle).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblTitle).Location = new Point(3, 0);
		((Control)lblTitle).Name = "lblTitle";
		((Control)lblTitle).Size = new Size(286, 20);
		((Control)lblTitle).TabIndex = 1;
		((Control)lblTitle).Text = "Item: Move To Inventory Command";
		((Control)rtText).Location = new Point(3, 23);
		((Control)rtText).Name = "rtText";
		((TextBoxBase)rtText).ReadOnly = true;
		((Control)rtText).Size = new Size(482, 265);
		((Control)rtText).TabIndex = 0;
		((Control)rtText).Text = "";
		((Form)this).AcceptButton = (IButtonControl)(object)b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)b;
		((Form)this).ClientSize = new Size(512, 344);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "HelpFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "RAGS Help";
		((Control)c).ResumeLayout(false);
		((Control)c).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
