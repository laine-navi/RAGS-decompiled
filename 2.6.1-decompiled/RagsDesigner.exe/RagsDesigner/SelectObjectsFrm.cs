using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RagsDesigner;

public class SelectObjectsFrm : Form
{
	public ListBox lbObjectsToAdd;

	private IContainer m_a;

	private Label m_b;

	private Button c;

	private Button d;

	public SelectObjectsFrm(ref ArrayList objectnames)
	{
		a();
		for (int i = 0; i < objectnames.Count; i++)
		{
			lbObjectsToAdd.Items.Add(objectnames[i]);
		}
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
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SelectObjectsFrm));
		lbObjectsToAdd = new ListBox();
		this.m_b = new Label();
		c = new Button();
		d = new Button();
		((Control)this).SuspendLayout();
		((ListControl)lbObjectsToAdd).FormattingEnabled = true;
		((Control)lbObjectsToAdd).Location = new Point(12, 27);
		((Control)lbObjectsToAdd).Name = "lbObjectsToAdd";
		lbObjectsToAdd.ScrollAlwaysVisible = true;
		lbObjectsToAdd.SelectionMode = (SelectionMode)3;
		((Control)lbObjectsToAdd).Size = new Size(262, 251);
		((Control)lbObjectsToAdd).TabIndex = 0;
		((Control)this.m_b).AutoSize = true;
		((Control)this.m_b).Location = new Point(12, 9);
		((Control)this.m_b).Name = "label1";
		((Control)this.m_b).Size = new Size(84, 13);
		((Control)this.m_b).TabIndex = 1;
		((Control)this.m_b).Text = "Objects To Add:";
		((Control)c).Location = new Point(35, 323);
		((Control)c).Name = "button1";
		((Control)c).Size = new Size(75, 23);
		((Control)c).TabIndex = 2;
		((Control)c).Text = "OK";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Control)c).Click += b;
		d.DialogResult = (DialogResult)2;
		((Control)d).Location = new Point(182, 323);
		((Control)d).Name = "button2";
		((Control)d).Size = new Size(75, 23);
		((Control)d).TabIndex = 3;
		((Control)d).Text = "Cancel";
		((ButtonBase)d).UseVisualStyleBackColor = true;
		((Control)d).Click += a;
		((Form)this).AcceptButton = (IButtonControl)(object)c;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)d;
		((Form)this).ClientSize = new Size(292, 365);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)lbObjectsToAdd);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "SelectObjectsFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "SelectObjectsFrm";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
