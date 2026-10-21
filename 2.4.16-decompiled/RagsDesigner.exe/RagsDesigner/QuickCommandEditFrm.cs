using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class QuickCommandEditFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c4684edf2f70d0a4c772b3fcba21d73a9;

	public ActionControl QuickCommandActionControl;

	public Label label1;

	public QuickCommandEditFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(QuickCommandEditFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickCommandEditFrm));
		label1 = new Label();
		c4684edf2f70d0a4c772b3fcba21d73a9 = new Button();
		QuickCommandActionControl = new ActionControl();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(273), 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label1).Location = new Point(4, 1);
		((Control)label1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)label1).Size = new Size(191, 17);
		((Control)label1).TabIndex = 1;
		((Control)label1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47469);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Anchor = (AnchorStyles)2;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Location = new Point(292, 459);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(353);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Size = new Size(75, 23);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).TabIndex = 2;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1421);
		((ButtonBase)c4684edf2f70d0a4c772b3fcba21d73a9).UseVisualStyleBackColor = true;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Click += c7f324705348fcc3390003b4be3497293;
		((Control)QuickCommandActionControl).Anchor = (AnchorStyles)15;
		((Control)QuickCommandActionControl).Location = new Point(2, 13);
		((Control)QuickCommandActionControl).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47514);
		((Control)QuickCommandActionControl).Size = new Size(653, 440);
		((Control)QuickCommandActionControl).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(658, 485);
		((Control)this).Controls.Add((Control)(object)c4684edf2f70d0a4c772b3fcba21d73a9);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Controls.Add((Control)(object)QuickCommandActionControl);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47565);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47604);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c7f324705348fcc3390003b4be3497293(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}
}
