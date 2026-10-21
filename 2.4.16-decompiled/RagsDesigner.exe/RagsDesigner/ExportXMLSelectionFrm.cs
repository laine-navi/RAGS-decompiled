using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace RagsDesigner;

public sealed class ExportXMLSelectionFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private GroupBox ca80957da81788ac8a6f393ba3899a63f;

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
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(ExportXMLSelectionFrm.Dispose(bool));
			}
			else
			{
				c501c89bc63d55bb522eac228aeeebb18.Dispose();
			}
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
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ExportXMLSelectionFrm));
		cbRooms = new CheckBox();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		ca80957da81788ac8a6f393ba3899a63f = new GroupBox();
		cbPlayer = new CheckBox();
		cbStatusBarItems = new CheckBox();
		cbTimers = new CheckBox();
		cbVariables = new CheckBox();
		cbObjects = new CheckBox();
		cbCharacters = new CheckBox();
		cbImages = new CheckBox();
		((Control)ca80957da81788ac8a6f393ba3899a63f).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)cbRooms).AutoSize = true;
		cbRooms.Checked = true;
		cbRooms.CheckState = (CheckState)1;
		((Control)cbRooms).Location = new Point(21, 55);
		((Control)cbRooms).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(452);
		((Control)cbRooms).Size = new Size(59, 17);
		((Control)cbRooms).TabIndex = 0;
		((Control)cbRooms).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(467);
		((ButtonBase)cbRooms).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(33, 265);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(70, 29);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 1;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(493);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		ce2761d6abd4d4150fc608452cc32c744.DialogResult = (DialogResult)2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(151, 265);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(70, 29);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 2;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbImages);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbPlayer);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbStatusBarItems);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbTimers);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbVariables);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbObjects);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbCharacters);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cbRooms);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Location = new Point(12, 12);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(526);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Size = new Size(230, 247);
		((Control)ca80957da81788ac8a6f393ba3899a63f).TabIndex = 3;
		ca80957da81788ac8a6f393ba3899a63f.TabStop = false;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(545);
		((Control)cbPlayer).AutoSize = true;
		cbPlayer.Checked = true;
		cbPlayer.CheckState = (CheckState)1;
		((Control)cbPlayer).Location = new Point(21, 27);
		((Control)cbPlayer).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(576);
		((Control)cbPlayer).Size = new Size(55, 17);
		((Control)cbPlayer).TabIndex = 6;
		((Control)cbPlayer).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(593);
		((ButtonBase)cbPlayer).UseVisualStyleBackColor = true;
		((Control)cbStatusBarItems).AutoSize = true;
		cbStatusBarItems.Checked = true;
		cbStatusBarItems.CheckState = (CheckState)1;
		((Control)cbStatusBarItems).Location = new Point(21, 195);
		((Control)cbStatusBarItems).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(606);
		((Control)cbStatusBarItems).Size = new Size(103, 17);
		((Control)cbStatusBarItems).TabIndex = 5;
		((Control)cbStatusBarItems).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(639);
		((ButtonBase)cbStatusBarItems).UseVisualStyleBackColor = true;
		((Control)cbTimers).AutoSize = true;
		cbTimers.Checked = true;
		cbTimers.CheckState = (CheckState)1;
		((Control)cbTimers).Location = new Point(21, 167);
		((Control)cbTimers).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(672);
		((Control)cbTimers).Size = new Size(57, 17);
		((Control)cbTimers).TabIndex = 4;
		((Control)cbTimers).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(689);
		((ButtonBase)cbTimers).UseVisualStyleBackColor = true;
		((Control)cbVariables).AutoSize = true;
		cbVariables.Checked = true;
		cbVariables.CheckState = (CheckState)1;
		((Control)cbVariables).Location = new Point(21, 139);
		((Control)cbVariables).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(702);
		((Control)cbVariables).Size = new Size(69, 17);
		((Control)cbVariables).TabIndex = 3;
		((Control)cbVariables).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(725);
		((ButtonBase)cbVariables).UseVisualStyleBackColor = true;
		((Control)cbObjects).AutoSize = true;
		cbObjects.Checked = true;
		cbObjects.CheckState = (CheckState)1;
		((Control)cbObjects).Location = new Point(21, 111);
		((Control)cbObjects).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(744);
		((Control)cbObjects).Size = new Size(62, 17);
		((Control)cbObjects).TabIndex = 2;
		((Control)cbObjects).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(763);
		((ButtonBase)cbObjects).UseVisualStyleBackColor = true;
		((Control)cbCharacters).AutoSize = true;
		cbCharacters.Checked = true;
		cbCharacters.CheckState = (CheckState)1;
		((Control)cbCharacters).Location = new Point(21, 83);
		((Control)cbCharacters).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(778);
		((Control)cbCharacters).Size = new Size(77, 17);
		((Control)cbCharacters).TabIndex = 1;
		((Control)cbCharacters).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(803);
		((ButtonBase)cbCharacters).UseVisualStyleBackColor = true;
		((Control)cbImages).AutoSize = true;
		cbImages.Checked = true;
		cbImages.CheckState = (CheckState)1;
		((Control)cbImages).Location = new Point(21, 221);
		((Control)cbImages).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(824);
		((Control)cbImages).Size = new Size(60, 17);
		((Control)cbImages).TabIndex = 7;
		((Control)cbImages).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(841);
		((ButtonBase)cbImages).UseVisualStyleBackColor = true;
		((Form)this).AcceptButton = (IButtonControl)(object)c79769badd3b3f4571a08b51317e02dcc;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)ce2761d6abd4d4150fc608452cc32c744;
		((Form)this).ClientSize = new Size(254, 305);
		((Control)this).Controls.Add((Control)(object)ca80957da81788ac8a6f393ba3899a63f);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(854);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(545);
		((Control)ca80957da81788ac8a6f393ba3899a63f).ResumeLayout(false);
		((Control)ca80957da81788ac8a6f393ba3899a63f).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
