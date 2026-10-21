using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RagsDesigner;

public class ExportXMLSelectionFrm : Form
{
	private IContainer m_a;

	private Button m_b;

	private Button c;

	private GroupBox d;

	public CheckBox cbRooms;

	public CheckBox cbStatusBarItems;

	public CheckBox cbTimers;

	public CheckBox cbVariables;

	public CheckBox cbObjects;

	public CheckBox cbCharacters;

	public CheckBox cbPlayer;

	public CheckBox cbImages;

	public ExportXMLSelectionFrm()
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
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ExportXMLSelectionFrm));
		cbRooms = new CheckBox();
		this.m_b = new Button();
		c = new Button();
		d = new GroupBox();
		cbPlayer = new CheckBox();
		cbStatusBarItems = new CheckBox();
		cbTimers = new CheckBox();
		cbVariables = new CheckBox();
		cbObjects = new CheckBox();
		cbCharacters = new CheckBox();
		cbImages = new CheckBox();
		((Control)d).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)cbRooms).AutoSize = true;
		cbRooms.Checked = true;
		cbRooms.CheckState = (CheckState)1;
		((Control)cbRooms).Location = new Point(21, 55);
		((Control)cbRooms).Name = "cbRooms";
		((Control)cbRooms).Size = new Size(59, 17);
		((Control)cbRooms).TabIndex = 0;
		((Control)cbRooms).Text = "Rooms";
		((ButtonBase)cbRooms).UseVisualStyleBackColor = true;
		((Control)this.m_b).Location = new Point(33, 265);
		((Control)this.m_b).Name = "button1";
		((Control)this.m_b).Size = new Size(70, 29);
		((Control)this.m_b).TabIndex = 1;
		((Control)this.m_b).Text = "OK";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_b).Click += b;
		c.DialogResult = (DialogResult)2;
		((Control)c).Location = new Point(151, 265);
		((Control)c).Name = "button2";
		((Control)c).Size = new Size(70, 29);
		((Control)c).TabIndex = 2;
		((Control)c).Text = "Cancel";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Control)c).Click += a;
		((Control)d).Controls.Add((Control)(object)cbImages);
		((Control)d).Controls.Add((Control)(object)cbPlayer);
		((Control)d).Controls.Add((Control)(object)cbStatusBarItems);
		((Control)d).Controls.Add((Control)(object)cbTimers);
		((Control)d).Controls.Add((Control)(object)cbVariables);
		((Control)d).Controls.Add((Control)(object)cbObjects);
		((Control)d).Controls.Add((Control)(object)cbCharacters);
		((Control)d).Controls.Add((Control)(object)cbRooms);
		((Control)d).Location = new Point(12, 12);
		((Control)d).Name = "groupBox1";
		((Control)d).Size = new Size(230, 247);
		((Control)d).TabIndex = 3;
		d.TabStop = false;
		((Control)d).Text = "Items To Export";
		((Control)cbPlayer).AutoSize = true;
		cbPlayer.Checked = true;
		cbPlayer.CheckState = (CheckState)1;
		((Control)cbPlayer).Location = new Point(21, 27);
		((Control)cbPlayer).Name = "cbPlayer";
		((Control)cbPlayer).Size = new Size(55, 17);
		((Control)cbPlayer).TabIndex = 6;
		((Control)cbPlayer).Text = "Player";
		((ButtonBase)cbPlayer).UseVisualStyleBackColor = true;
		((Control)cbStatusBarItems).AutoSize = true;
		cbStatusBarItems.Checked = true;
		cbStatusBarItems.CheckState = (CheckState)1;
		((Control)cbStatusBarItems).Location = new Point(21, 195);
		((Control)cbStatusBarItems).Name = "cbStatusBarItems";
		((Control)cbStatusBarItems).Size = new Size(103, 17);
		((Control)cbStatusBarItems).TabIndex = 5;
		((Control)cbStatusBarItems).Text = "Status Bar Items";
		((ButtonBase)cbStatusBarItems).UseVisualStyleBackColor = true;
		((Control)cbTimers).AutoSize = true;
		cbTimers.Checked = true;
		cbTimers.CheckState = (CheckState)1;
		((Control)cbTimers).Location = new Point(21, 167);
		((Control)cbTimers).Name = "cbTimers";
		((Control)cbTimers).Size = new Size(57, 17);
		((Control)cbTimers).TabIndex = 4;
		((Control)cbTimers).Text = "Timers";
		((ButtonBase)cbTimers).UseVisualStyleBackColor = true;
		((Control)cbVariables).AutoSize = true;
		cbVariables.Checked = true;
		cbVariables.CheckState = (CheckState)1;
		((Control)cbVariables).Location = new Point(21, 139);
		((Control)cbVariables).Name = "cbVariables";
		((Control)cbVariables).Size = new Size(69, 17);
		((Control)cbVariables).TabIndex = 3;
		((Control)cbVariables).Text = "Variables";
		((ButtonBase)cbVariables).UseVisualStyleBackColor = true;
		((Control)cbObjects).AutoSize = true;
		cbObjects.Checked = true;
		cbObjects.CheckState = (CheckState)1;
		((Control)cbObjects).Location = new Point(21, 111);
		((Control)cbObjects).Name = "cbObjects";
		((Control)cbObjects).Size = new Size(62, 17);
		((Control)cbObjects).TabIndex = 2;
		((Control)cbObjects).Text = "Objects";
		((ButtonBase)cbObjects).UseVisualStyleBackColor = true;
		((Control)cbCharacters).AutoSize = true;
		cbCharacters.Checked = true;
		cbCharacters.CheckState = (CheckState)1;
		((Control)cbCharacters).Location = new Point(21, 83);
		((Control)cbCharacters).Name = "cbCharacters";
		((Control)cbCharacters).Size = new Size(77, 17);
		((Control)cbCharacters).TabIndex = 1;
		((Control)cbCharacters).Text = "Characters";
		((ButtonBase)cbCharacters).UseVisualStyleBackColor = true;
		((Control)cbImages).AutoSize = true;
		cbImages.Checked = true;
		cbImages.CheckState = (CheckState)1;
		((Control)cbImages).Location = new Point(21, 221);
		((Control)cbImages).Name = "cbImages";
		((Control)cbImages).Size = new Size(60, 17);
		((Control)cbImages).TabIndex = 7;
		((Control)cbImages).Text = "Images";
		((ButtonBase)cbImages).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)c;
		((Form)this).ClientSize = new Size(254, 305);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "ExportXMLSelectionFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Items To Export";
		((Control)d).ResumeLayout(false);
		((Control)d).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
