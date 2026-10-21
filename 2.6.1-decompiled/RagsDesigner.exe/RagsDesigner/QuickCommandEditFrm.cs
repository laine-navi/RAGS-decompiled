using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class QuickCommandEditFrm : Form
{
	private IContainer m_a;

	private Button b;

	public ActionControl QuickCommandActionControl;

	public Label label1;

	public QuickCommandEditFrm()
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
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickCommandEditFrm));
		label1 = new Label();
		b = new Button();
		QuickCommandActionControl = new ActionControl();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label1).Location = new Point(4, 1);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(191, 17);
		((Control)label1).TabIndex = 1;
		((Control)label1).Text = "Command We Are Editing";
		((Control)b).Anchor = (AnchorStyles)2;
		((Control)b).Location = new Point(292, 459);
		((Control)b).Name = "btnDone";
		((Control)b).Size = new Size(75, 23);
		((Control)b).TabIndex = 2;
		((Control)b).Text = "Finished";
		((ButtonBase)b).UseVisualStyleBackColor = true;
		((Control)b).Click += a;
		((Control)QuickCommandActionControl).Anchor = (AnchorStyles)15;
		((Control)QuickCommandActionControl).Location = new Point(2, 13);
		((Control)QuickCommandActionControl).Name = "QuickCommandActionControl";
		((Control)QuickCommandActionControl).Size = new Size(653, 440);
		((Control)QuickCommandActionControl).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(658, 485);
		((Control)this).Controls.Add((Control)(object)b);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Controls.Add((Control)(object)QuickCommandActionControl);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "QuickCommandEditFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Quick Command Edit Form";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
