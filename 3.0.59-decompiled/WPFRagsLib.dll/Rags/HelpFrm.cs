using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class HelpFrm : Form
{
	private IContainer components;

	private Button btnOK;

	private Panel panel1;

	public Label lblTitle;

	public RichTextBox rtText;

	public HelpFrm()
	{
		InitializeComponent();
	}

	private void btnOK_Click(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
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
		btnOK = new Button();
		panel1 = new Panel();
		lblTitle = new Label();
		rtText = new RichTextBox();
		((Control)panel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)btnOK).Anchor = (AnchorStyles)2;
		btnOK.DialogResult = (DialogResult)2;
		((Control)btnOK).Location = new Point(219, 309);
		((Control)btnOK).Name = "btnOK";
		((Control)btnOK).Size = new Size(75, 23);
		((Control)btnOK).TabIndex = 0;
		((Control)btnOK).Text = "OK";
		((ButtonBase)btnOK).UseVisualStyleBackColor = true;
		((Control)btnOK).Click += btnOK_Click;
		((Control)panel1).Anchor = (AnchorStyles)15;
		((Control)panel1).Controls.Add((Control)(object)lblTitle);
		((Control)panel1).Controls.Add((Control)(object)rtText);
		((Control)panel1).Location = new Point(12, 12);
		((Control)panel1).Name = "panel1";
		((Control)panel1).Size = new Size(488, 291);
		((Control)panel1).TabIndex = 1;
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
		((Form)this).AcceptButton = (IButtonControl)(object)btnOK;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)btnOK;
		((Form)this).ClientSize = new Size(512, 344);
		((Control)this).Controls.Add((Control)(object)panel1);
		((Control)this).Controls.Add((Control)(object)btnOK);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "HelpFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "RAGS Help";
		((Control)panel1).ResumeLayout(false);
		((Control)panel1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
