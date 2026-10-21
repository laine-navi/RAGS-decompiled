using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class HelpFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button cfb161b7d53a34ca465d546e89559aa86;

	private Panel c5e74b6ad19335af023c0fb124e8b9948;

	public Label lblTitle;

	public RichTextBox rtText;

	public HelpFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	private void cae5d311ccae5f42a5309e3afd77dfd28(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(HelpFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(HelpFrm.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Obj, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpFrm));
		cfb161b7d53a34ca465d546e89559aa86 = new Button();
		c5e74b6ad19335af023c0fb124e8b9948 = new Panel();
		lblTitle = new Label();
		rtText = new RichTextBox();
		((Control)c5e74b6ad19335af023c0fb124e8b9948).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)cfb161b7d53a34ca465d546e89559aa86).Anchor = (AnchorStyles)2;
		cfb161b7d53a34ca465d546e89559aa86.DialogResult = (DialogResult)2;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Location = new Point(219, 309);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19088);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Size = new Size(75, 23);
		((Control)cfb161b7d53a34ca465d546e89559aa86).TabIndex = 0;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19099);
		((ButtonBase)cfb161b7d53a34ca465d546e89559aa86).UseVisualStyleBackColor = true;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Click += cae5d311ccae5f42a5309e3afd77dfd28;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Anchor = (AnchorStyles)15;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)lblTitle);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)rtText);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Location = new Point(12, 12);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Size = new Size(488, 291);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).TabIndex = 1;
		((Control)lblTitle).Anchor = (AnchorStyles)1;
		((Control)lblTitle).AutoSize = true;
		((Control)lblTitle).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblTitle).Location = new Point(3, 0);
		((Control)lblTitle).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19104);
		((Control)lblTitle).Size = new Size(286, 20);
		((Control)lblTitle).TabIndex = 1;
		((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19121);
		((Control)rtText).Location = new Point(3, 23);
		((Control)rtText).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19184);
		((TextBoxBase)rtText).ReadOnly = true;
		((Control)rtText).Size = new Size(482, 265);
		((Control)rtText).TabIndex = 0;
		((Control)rtText).Text = "";
		((Form)this).AcceptButton = (IButtonControl)(object)cfb161b7d53a34ca465d546e89559aa86;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)cfb161b7d53a34ca465d546e89559aa86;
		((Form)this).ClientSize = new Size(512, 344);
		((Control)this).Controls.Add((Control)(object)c5e74b6ad19335af023c0fb124e8b9948);
		((Control)this).Controls.Add((Control)(object)cfb161b7d53a34ca465d546e89559aa86);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19197);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19212);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).ResumeLayout(false);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
