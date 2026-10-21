using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class GetGenderFrm : Form
{
	private IContainer m_a;

	private GroupBox b;

	private Button c;

	public RadioButton radioButton1;

	public RadioButton radioButton2;

	public RadioButton radioButton3;

	public GetGenderFrm()
	{
		a();
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
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetGenderFrm));
		b = new GroupBox();
		radioButton1 = new RadioButton();
		radioButton2 = new RadioButton();
		radioButton3 = new RadioButton();
		c = new Button();
		((Control)b).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)b).Controls.Add((Control)(object)radioButton1);
		((Control)b).Controls.Add((Control)(object)radioButton2);
		((Control)b).Controls.Add((Control)(object)radioButton3);
		((Control)b).Location = new Point(12, 12);
		((Control)b).Name = "groupBox1";
		((Control)b).Size = new Size(208, 100);
		((Control)b).TabIndex = 1;
		b.TabStop = false;
		((Control)b).Text = "Enter Your Gender:";
		((Control)radioButton1).AutoSize = true;
		((Control)radioButton1).Location = new Point(75, 25);
		((Control)radioButton1).Name = "radioButton1";
		((Control)radioButton1).Size = new Size(48, 17);
		((Control)radioButton1).TabIndex = 3;
		radioButton1.TabStop = true;
		((Control)radioButton1).Text = "Male";
		((ButtonBase)radioButton1).UseVisualStyleBackColor = true;
		((Control)radioButton2).AutoSize = true;
		((Control)radioButton2).Location = new Point(75, 48);
		((Control)radioButton2).Name = "radioButton2";
		((Control)radioButton2).Size = new Size(59, 17);
		((Control)radioButton2).TabIndex = 4;
		radioButton2.TabStop = true;
		((Control)radioButton2).Text = "Female";
		((ButtonBase)radioButton2).UseVisualStyleBackColor = true;
		((Control)radioButton3).AutoSize = true;
		((Control)radioButton3).Location = new Point(75, 71);
		((Control)radioButton3).Name = "radioButton3";
		((Control)radioButton3).Size = new Size(51, 17);
		((Control)radioButton3).TabIndex = 5;
		radioButton3.TabStop = true;
		((Control)radioButton3).Text = "Other";
		((ButtonBase)radioButton3).UseVisualStyleBackColor = true;
		c.DialogResult = (DialogResult)1;
		((Control)c).Location = new Point(79, 123);
		((Control)c).Name = "button1";
		((Control)c).Size = new Size(75, 23);
		((Control)c).TabIndex = 2;
		((Control)c).Text = "Done";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)c;
		((Form)this).ClientSize = new Size(232, 164);
		((Control)this).Controls.Add((Control)(object)b);
		((Control)this).Controls.Add((Control)(object)c);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "GetGenderFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Select Player Gender";
		((Control)b).ResumeLayout(false);
		((Control)b).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
