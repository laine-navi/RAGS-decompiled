using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RagsDesigner;

public class GetDimensionWidthFrm : Form
{
	private IContainer m_a;

	private Button m_b;

	private Button c;

	private Label d;

	public NumericUpDown udWidth;

	private Label e;

	public GetDimensionWidthFrm()
	{
		a();
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GetDimensionWidthFrm));
		this.m_b = new Button();
		c = new Button();
		d = new Label();
		udWidth = new NumericUpDown();
		e = new Label();
		((ISupportInitialize)udWidth).BeginInit();
		((Control)this).SuspendLayout();
		((Control)this.m_b).Location = new Point(37, 89);
		((Control)this.m_b).Name = "button1";
		((Control)this.m_b).Size = new Size(69, 23);
		((Control)this.m_b).TabIndex = 0;
		((Control)this.m_b).Text = "OK";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_b).Click += b;
		c.DialogResult = (DialogResult)2;
		((Control)c).Location = new Point(181, 89);
		((Control)c).Name = "button2";
		((Control)c).Size = new Size(75, 23);
		((Control)c).TabIndex = 1;
		((Control)c).Text = "Cancel";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Control)c).Click += a;
		((Control)d).AutoSize = true;
		((Control)d).Location = new Point(47, 24);
		((Control)d).Name = "label1";
		((Control)d).Size = new Size(186, 13);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Please Choose The Dimension Width:";
		((Control)udWidth).Location = new Point(110, 53);
		udWidth.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		((Control)udWidth).Name = "udWidth";
		((Control)udWidth).Size = new Size(61, 20);
		((Control)udWidth).TabIndex = 3;
		udWidth.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		((Control)e).AutoSize = true;
		((Control)e).Location = new Point(23, 37);
		((Control)e).Name = "label2";
		((Control)e).Size = new Size(234, 13);
		((Control)e).TabIndex = 4;
		((Control)e).Text = "(Note: You can add as many rows as you'd like.)";
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)c;
		((Form)this).ClientSize = new Size(281, 124);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)udWidth);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "GetDimensionWidthFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Dimensional Array Width";
		((ISupportInitialize)udWidth).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
