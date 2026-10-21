using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class AddTimerActionsFrm : Form
{
	private int m_a;

	private IContainer m_b;

	private Button m_c;

	private Button d;

	public ListBox lbTimerActions;

	public AddTimerActionsFrm(int l)
	{
		this.m_a = l;
		a();
	}

	private void c(object A_0, EventArgs A_1)
	{
		for (int i = 0; i < this.m_a; i++)
		{
			lbTimerActions.Items.Add((object)("<<On Turn " + (i + 1) + ">>"));
		}
		lbTimerActions.Items.Add((object)"<<On Last Turn>>");
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void a(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_b != null)
		{
			this.m_b.Dispose();
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
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AddTimerActionsFrm));
		lbTimerActions = new ListBox();
		this.m_c = new Button();
		d = new Button();
		((Control)this).SuspendLayout();
		((ListControl)lbTimerActions).FormattingEnabled = true;
		((Control)lbTimerActions).Location = new Point(12, 12);
		((Control)lbTimerActions).Name = "lbTimerActions";
		lbTimerActions.SelectionMode = (SelectionMode)3;
		((Control)lbTimerActions).Size = new Size(192, 173);
		((Control)lbTimerActions).TabIndex = 0;
		((Control)this.m_c).Location = new Point(23, 191);
		((Control)this.m_c).Name = "btnAdd";
		((Control)this.m_c).Size = new Size(73, 22);
		((Control)this.m_c).TabIndex = 1;
		((Control)this.m_c).Text = "Add Actions";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += b;
		d.DialogResult = (DialogResult)2;
		((Control)d).Location = new Point(121, 190);
		((Control)d).Name = "btnCancel";
		((Control)d).Size = new Size(73, 22);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Cancel";
		((ButtonBase)d).UseVisualStyleBackColor = true;
		((Control)d).Click += a;
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_c;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)d;
		((Form)this).ClientSize = new Size(216, 224);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)lbTimerActions);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AddTimerActionsFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Add Timer Actions";
		((Form)this).Load += c;
		((Control)this).ResumeLayout(false);
	}
}
