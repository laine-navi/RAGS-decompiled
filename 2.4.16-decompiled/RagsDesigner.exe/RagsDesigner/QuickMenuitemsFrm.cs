using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class QuickMenuitemsFrm : Form
{
	private ArrayList c239b33136e59cf175dd14e0dd3fe5f1a;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button cd06b5398b27d091d6962c9c9b75befc4;

	private Button cb4e261ca3b37fecaaeb4e6c758995d76;

	private GroupBox ca80957da81788ac8a6f393ba3899a63f;

	private CheckBox c68f8e8574425be3a5411c8b0c75b4985;

	private CheckBox c9b9c387dfa77bc64691bedad39493f96;

	private CheckBox cd25ee0c5f49b442b0b6825c8f8b3732e;

	private CheckBox c5496e207f15cc8c8b8137161348a1f29;

	private CheckBox c3d7909d4379b5eef1810155b11b78c91;

	private CheckBox c0df35dcbbb394aa4608e86ff81a7665a;

	private CheckBox c0a69009ed9fe4245b45602491cd1e64a;

	private GroupBox c283bbab44b3fca5d39367f132894644e;

	private CheckBox cd15be71e631d305f43afbb3c1b0f6e4a;

	private CheckBox c83cbe56f2b7bee7132b1839eeb8b0961;

	private CheckBox c57aee6ef17ae9d24901d0e04b49a1ff3;

	private CheckBox c432762ed3a6f0f1ffdf40b5f998a43eb;

	public ListBox lbMenuItems;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Button cf75d8a725a0a9a9a86c4a3dd2fefd487;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private TextBox c2f5432c4b3efa84d2eb1592df7281409;

	private GroupBox ca97c16bb25e579acbfca5f9ec5f38762;

	private CheckBox c5c7f6bf19374b3ca8a6002e13d46d379;

	public QuickMenuitemsFrm(ref ArrayList commands)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c239b33136e59cf175dd14e0dd3fe5f1a = commands;
		c709d58b30580c6d6875c978f1e9f1504();
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		if (lbMenuItems.SelectedItem == null)
		{
			__ldtoken(QuickMenuitemsFrm.c7abee227c4ea05d5e309cce1e3d77c65(object, EventArgs));
			return;
		}
		Form1.TheGame.QuickCommands.Remove(lbMenuItems.SelectedItem);
		c709d58b30580c6d6875c978f1e9f1504();
	}

	private void cf2994a437f804524f310337f0ede6ffe(object P_0, EventArgs P_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		((Control)c2f5432c4b3efa84d2eb1592df7281409).Text = quickMenuItem.Name;
		if (!quickMenuItem.bCarryable)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c0a69009ed9fe4245b45602491cd1e64a.Checked = false;
		}
		else
		{
			c0a69009ed9fe4245b45602491cd1e64a.Checked = true;
		}
		if (!quickMenuItem.bCharacters)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c83cbe56f2b7bee7132b1839eeb8b0961.Checked = false;
		}
		else
		{
			c83cbe56f2b7bee7132b1839eeb8b0961.Checked = true;
		}
		if (!quickMenuItem.bContainer)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c68f8e8574425be3a5411c8b0c75b4985.Checked = false;
		}
		else
		{
			c68f8e8574425be3a5411c8b0c75b4985.Checked = true;
		}
		if (!quickMenuItem.bEnterable)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			cd25ee0c5f49b442b0b6825c8f8b3732e.Checked = false;
		}
		else
		{
			cd25ee0c5f49b442b0b6825c8f8b3732e.Checked = true;
		}
		if (quickMenuItem.bLockable)
		{
			c5496e207f15cc8c8b8137161348a1f29.Checked = true;
		}
		else
		{
			c5496e207f15cc8c8b8137161348a1f29.Checked = false;
		}
		if (!quickMenuItem.bObjects)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			cd15be71e631d305f43afbb3c1b0f6e4a.Checked = false;
		}
		else
		{
			cd15be71e631d305f43afbb3c1b0f6e4a.Checked = true;
		}
		if (!quickMenuItem.bOpenable)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c3d7909d4379b5eef1810155b11b78c91.Checked = false;
		}
		else
		{
			c3d7909d4379b5eef1810155b11b78c91.Checked = true;
		}
		if (quickMenuItem.bPlayer)
		{
			c57aee6ef17ae9d24901d0e04b49a1ff3.Checked = true;
		}
		else
		{
			c57aee6ef17ae9d24901d0e04b49a1ff3.Checked = false;
		}
		if (quickMenuItem.bReadable)
		{
			c9b9c387dfa77bc64691bedad39493f96.Checked = true;
		}
		else
		{
			c9b9c387dfa77bc64691bedad39493f96.Checked = false;
		}
		if (!quickMenuItem.bRooms)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c432762ed3a6f0f1ffdf40b5f998a43eb.Checked = false;
		}
		else
		{
			c432762ed3a6f0f1ffdf40b5f998a43eb.Checked = true;
		}
		if (!quickMenuItem.bWearable)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c0df35dcbbb394aa4608e86ff81a7665a.Checked = false;
		}
		else
		{
			c0df35dcbbb394aa4608e86ff81a7665a.Checked = true;
		}
		if (!quickMenuItem.bOverwrite)
		{
			__ldtoken(QuickMenuitemsFrm.cf2994a437f804524f310337f0ede6ffe(object, EventArgs));
			c5c7f6bf19374b3ca8a6002e13d46d379.Checked = false;
		}
		else
		{
			c5c7f6bf19374b3ca8a6002e13d46d379.Checked = true;
		}
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void cac0bf4911c99aa3dc2962dbb8bbad8b3(object P_0, EventArgs P_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49741), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49909), (MessageBoxButtons)4) != 6)
		{
			__ldtoken(QuickMenuitemsFrm.cac0bf4911c99aa3dc2962dbb8bbad8b3(object, EventArgs));
			return;
		}
		Game.RestoreDefaults(ref c239b33136e59cf175dd14e0dd3fe5f1a);
		c709d58b30580c6d6875c978f1e9f1504();
	}

	private void c709d58b30580c6d6875c978f1e9f1504()
	{
		lbMenuItems.Items.Clear();
		for (int i = 0; i < c239b33136e59cf175dd14e0dd3fe5f1a.Count; i++)
		{
			__ldtoken(QuickMenuitemsFrm.c709d58b30580c6d6875c978f1e9f1504());
			QuickMenuItem quickMenuItem = (QuickMenuItem)c239b33136e59cf175dd14e0dd3fe5f1a[i];
			lbMenuItems.Items.Add((object)quickMenuItem);
		}
		if (lbMenuItems.Items.Count > 0)
		{
			((ListControl)lbMenuItems).SelectedIndex = 0;
		}
	}

	private void c1c1c59cf47b1526b46a9815de550c7e5(object P_0, EventArgs P_1)
	{
	}

	private void c15356631c1fa143d9672841fa31105d0(object P_0, EventArgs P_1)
	{
		if (!cd15be71e631d305f43afbb3c1b0f6e4a.Checked)
		{
			__ldtoken(QuickMenuitemsFrm.c15356631c1fa143d9672841fa31105d0(object, EventArgs));
			((Control)ca80957da81788ac8a6f393ba3899a63f).Enabled = false;
		}
		else
		{
			((Control)ca80957da81788ac8a6f393ba3899a63f).Enabled = true;
		}
		((QuickMenuItem)lbMenuItems.SelectedItem).bObjects = cd15be71e631d305f43afbb3c1b0f6e4a.Checked;
	}

	private void c2a2eeab10147d9c1c0620cd1f4830c75(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bRooms = c432762ed3a6f0f1ffdf40b5f998a43eb.Checked;
	}

	private void caf96aeee0134a433b04e8dd016c86780(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bPlayer = c57aee6ef17ae9d24901d0e04b49a1ff3.Checked;
	}

	private void ce0c9f663602618b66c3227ad509bffc5(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bCharacters = c83cbe56f2b7bee7132b1839eeb8b0961.Checked;
	}

	private void c096a298bfe85d18bb4a9b0cd7e935745(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bCarryable = c0a69009ed9fe4245b45602491cd1e64a.Checked;
	}

	private void ca59bdec0264de3e7ad68b623d8d72ec5(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bWearable = c0df35dcbbb394aa4608e86ff81a7665a.Checked;
	}

	private void cd05bb0ae44529f096106c1d980264e18(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bContainer = c68f8e8574425be3a5411c8b0c75b4985.Checked;
	}

	private void c85df24d2ff38c56b32f16a74b05d1541(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bOpenable = c3d7909d4379b5eef1810155b11b78c91.Checked;
	}

	private void c583c6bbcefd5e28bed1e2fa1289ccf24(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bLockable = c5496e207f15cc8c8b8137161348a1f29.Checked;
	}

	private void c5a51bbe4599446c769f337a23831f899(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bEnterable = cd25ee0c5f49b442b0b6825c8f8b3732e.Checked;
	}

	private void c14f3ba1835ac502f3136d8e7492d832e(object P_0, EventArgs P_1)
	{
		((QuickMenuItem)lbMenuItems.SelectedItem).bReadable = c9b9c387dfa77bc64691bedad39493f96.Checked;
	}

	private void c625aba1ddf44ba88235d17a227618ea8(object P_0, EventArgs P_1)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem != null)
		{
			QuickCommandEditFrm quickCommandEditFrm = new QuickCommandEditFrm();
			((Control)quickCommandEditFrm.label1).Text = quickMenuItem.Name;
			quickCommandEditFrm.QuickCommandActionControl.SetObjectName(quickMenuItem.UniqueID.ToString());
			quickCommandEditFrm.QuickCommandActionControl.SetPageType(ActionControl.PageType.quickcommand);
			quickCommandEditFrm.QuickCommandActionControl.SetGameObject(ref Form1.TheGame);
			quickCommandEditFrm.QuickCommandActionControl.RefreshActions();
			((Form)quickCommandEditFrm).ShowDialog();
			((Component)(object)quickCommandEditFrm).Dispose();
		}
	}

	private void c35f4c9b1f3471abe26d64adf521815be(object P_0, EventArgs P_1)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		GetNameFrm getNameFrm = new GetNameFrm(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49924));
		if ((int)((Form)getNameFrm).ShowDialog() == 1)
		{
			QuickMenuItem quickMenuItem = new QuickMenuItem();
			quickMenuItem.Name = ((Control)getNameFrm.txtEntry).Text;
			Form1.TheGame.QuickCommands.Add(quickMenuItem);
			c709d58b30580c6d6875c978f1e9f1504();
		}
	}

	private void c60d478a308ac6925cfad1007164b94c3(object P_0, EventArgs P_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem == null)
		{
			__ldtoken(QuickMenuitemsFrm.c60d478a308ac6925cfad1007164b94c3(object, EventArgs));
		}
		else
		{
			quickMenuItem.Name = ((Control)c2f5432c4b3efa84d2eb1592df7281409).Text;
		}
		c709d58b30580c6d6875c978f1e9f1504();
	}

	private void c558a56c61b6a7311e6e611b7f2783217(object P_0, EventArgs P_1)
	{
		QuickMenuItem quickMenuItem = (QuickMenuItem)lbMenuItems.SelectedItem;
		if (quickMenuItem != null)
		{
			quickMenuItem.bOverwrite = c5c7f6bf19374b3ca8a6002e13d46d379.Checked;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(QuickMenuitemsFrm.Dispose(bool));
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
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_116b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickMenuitemsFrm));
		lbMenuItems = new ListBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		cd06b5398b27d091d6962c9c9b75befc4 = new Button();
		cb4e261ca3b37fecaaeb4e6c758995d76 = new Button();
		ca80957da81788ac8a6f393ba3899a63f = new GroupBox();
		c68f8e8574425be3a5411c8b0c75b4985 = new CheckBox();
		c9b9c387dfa77bc64691bedad39493f96 = new CheckBox();
		cd25ee0c5f49b442b0b6825c8f8b3732e = new CheckBox();
		c5496e207f15cc8c8b8137161348a1f29 = new CheckBox();
		c3d7909d4379b5eef1810155b11b78c91 = new CheckBox();
		c0df35dcbbb394aa4608e86ff81a7665a = new CheckBox();
		c0a69009ed9fe4245b45602491cd1e64a = new CheckBox();
		c283bbab44b3fca5d39367f132894644e = new GroupBox();
		cd15be71e631d305f43afbb3c1b0f6e4a = new CheckBox();
		c83cbe56f2b7bee7132b1839eeb8b0961 = new CheckBox();
		c57aee6ef17ae9d24901d0e04b49a1ff3 = new CheckBox();
		c432762ed3a6f0f1ffdf40b5f998a43eb = new CheckBox();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		cf75d8a725a0a9a9a86c4a3dd2fefd487 = new Button();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		c2f5432c4b3efa84d2eb1592df7281409 = new TextBox();
		ca97c16bb25e579acbfca5f9ec5f38762 = new GroupBox();
		c5c7f6bf19374b3ca8a6002e13d46d379 = new CheckBox();
		((Control)ca80957da81788ac8a6f393ba3899a63f).SuspendLayout();
		((Control)c283bbab44b3fca5d39367f132894644e).SuspendLayout();
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).SuspendLayout();
		((Control)this).SuspendLayout();
		((ListControl)lbMenuItems).FormattingEnabled = true;
		((Control)lbMenuItems).Location = new Point(15, 25);
		((Control)lbMenuItems).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49977);
		((Control)lbMenuItems).Size = new Size(199, 316);
		((Control)lbMenuItems).TabIndex = 0;
		lbMenuItems.SelectedIndexChanged += cf2994a437f804524f310337f0ede6ffe;
		((Control)lbMenuItems).DoubleClick += c625aba1ddf44ba88235d17a227618ea8;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(65, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 1;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50000);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Location = new Point(15, 352);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50023);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Size = new Size(49, 23);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).TabIndex = 2;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3726);
		((ButtonBase)cd06b5398b27d091d6962c9c9b75befc4).UseVisualStyleBackColor = true;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Click += c35f4c9b1f3471abe26d64adf521815be;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Location = new Point(165, 352);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50036);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Size = new Size(49, 23);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).TabIndex = 3;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3782);
		((ButtonBase)cb4e261ca3b37fecaaeb4e6c758995d76).UseVisualStyleBackColor = true;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Anchor = (AnchorStyles)6;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c68f8e8574425be3a5411c8b0c75b4985);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c9b9c387dfa77bc64691bedad39493f96);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)cd25ee0c5f49b442b0b6825c8f8b3732e);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c5496e207f15cc8c8b8137161348a1f29);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c3d7909d4379b5eef1810155b11b78c91);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c0df35dcbbb394aa4608e86ff81a7665a);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Controls.Add((Control)(object)c0a69009ed9fe4245b45602491cd1e64a);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Location = new Point(357, 56);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(526);
		((Control)ca80957da81788ac8a6f393ba3899a63f).Size = new Size(158, 190);
		((Control)ca80957da81788ac8a6f393ba3899a63f).TabIndex = 8;
		ca80957da81788ac8a6f393ba3899a63f.TabStop = false;
		((Control)ca80957da81788ac8a6f393ba3899a63f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50055);
		((Control)c68f8e8574425be3a5411c8b0c75b4985).AutoSize = true;
		((Control)c68f8e8574425be3a5411c8b0c75b4985).Location = new Point(6, 69);
		((Control)c68f8e8574425be3a5411c8b0c75b4985).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16676);
		((Control)c68f8e8574425be3a5411c8b0c75b4985).RightToLeft = (RightToLeft)0;
		((Control)c68f8e8574425be3a5411c8b0c75b4985).Size = new Size(71, 17);
		((Control)c68f8e8574425be3a5411c8b0c75b4985).TabIndex = 11;
		((Control)c68f8e8574425be3a5411c8b0c75b4985).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16711);
		((ButtonBase)c68f8e8574425be3a5411c8b0c75b4985).UseVisualStyleBackColor = true;
		c68f8e8574425be3a5411c8b0c75b4985.CheckedChanged += cd05bb0ae44529f096106c1d980264e18;
		((Control)c9b9c387dfa77bc64691bedad39493f96).AutoSize = true;
		((Control)c9b9c387dfa77bc64691bedad39493f96).Location = new Point(6, 161);
		((Control)c9b9c387dfa77bc64691bedad39493f96).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17195);
		((Control)c9b9c387dfa77bc64691bedad39493f96).RightToLeft = (RightToLeft)0;
		((Control)c9b9c387dfa77bc64691bedad39493f96).Size = new Size(72, 17);
		((Control)c9b9c387dfa77bc64691bedad39493f96).TabIndex = 5;
		((Control)c9b9c387dfa77bc64691bedad39493f96).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17228);
		((ButtonBase)c9b9c387dfa77bc64691bedad39493f96).UseVisualStyleBackColor = true;
		c9b9c387dfa77bc64691bedad39493f96.CheckedChanged += c14f3ba1835ac502f3136d8e7492d832e;
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).AutoSize = true;
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).Location = new Point(6, 138);
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17245);
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).RightToLeft = (RightToLeft)0;
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).Size = new Size(71, 17);
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).TabIndex = 4;
		((Control)cd25ee0c5f49b442b0b6825c8f8b3732e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17280);
		((ButtonBase)cd25ee0c5f49b442b0b6825c8f8b3732e).UseVisualStyleBackColor = true;
		cd25ee0c5f49b442b0b6825c8f8b3732e.CheckedChanged += c5a51bbe4599446c769f337a23831f899;
		((Control)c5496e207f15cc8c8b8137161348a1f29).AutoSize = true;
		((Control)c5496e207f15cc8c8b8137161348a1f29).Location = new Point(6, 115);
		((Control)c5496e207f15cc8c8b8137161348a1f29).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17299);
		((Control)c5496e207f15cc8c8b8137161348a1f29).RightToLeft = (RightToLeft)0;
		((Control)c5496e207f15cc8c8b8137161348a1f29).Size = new Size(70, 17);
		((Control)c5496e207f15cc8c8b8137161348a1f29).TabIndex = 3;
		((Control)c5496e207f15cc8c8b8137161348a1f29).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17332);
		((ButtonBase)c5496e207f15cc8c8b8137161348a1f29).UseVisualStyleBackColor = true;
		c5496e207f15cc8c8b8137161348a1f29.CheckedChanged += c583c6bbcefd5e28bed1e2fa1289ccf24;
		((Control)c3d7909d4379b5eef1810155b11b78c91).AutoSize = true;
		((Control)c3d7909d4379b5eef1810155b11b78c91).Location = new Point(6, 92);
		((Control)c3d7909d4379b5eef1810155b11b78c91).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17349);
		((Control)c3d7909d4379b5eef1810155b11b78c91).RightToLeft = (RightToLeft)0;
		((Control)c3d7909d4379b5eef1810155b11b78c91).Size = new Size(72, 17);
		((Control)c3d7909d4379b5eef1810155b11b78c91).TabIndex = 2;
		((Control)c3d7909d4379b5eef1810155b11b78c91).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17382);
		((ButtonBase)c3d7909d4379b5eef1810155b11b78c91).UseVisualStyleBackColor = true;
		c3d7909d4379b5eef1810155b11b78c91.CheckedChanged += c85df24d2ff38c56b32f16a74b05d1541;
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).AutoSize = true;
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).Location = new Point(6, 46);
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17399);
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).RightToLeft = (RightToLeft)0;
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).Size = new Size(72, 17);
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).TabIndex = 1;
		((Control)c0df35dcbbb394aa4608e86ff81a7665a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17432);
		((ButtonBase)c0df35dcbbb394aa4608e86ff81a7665a).UseVisualStyleBackColor = true;
		c0df35dcbbb394aa4608e86ff81a7665a.CheckedChanged += ca59bdec0264de3e7ad68b623d8d72ec5;
		((Control)c0a69009ed9fe4245b45602491cd1e64a).AutoSize = true;
		((Control)c0a69009ed9fe4245b45602491cd1e64a).Location = new Point(6, 23);
		((Control)c0a69009ed9fe4245b45602491cd1e64a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17449);
		((Control)c0a69009ed9fe4245b45602491cd1e64a).RightToLeft = (RightToLeft)0;
		((Control)c0a69009ed9fe4245b45602491cd1e64a).Size = new Size(70, 17);
		((Control)c0a69009ed9fe4245b45602491cd1e64a).TabIndex = 0;
		((Control)c0a69009ed9fe4245b45602491cd1e64a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17484);
		((ButtonBase)c0a69009ed9fe4245b45602491cd1e64a).UseVisualStyleBackColor = true;
		c0a69009ed9fe4245b45602491cd1e64a.CheckedChanged += c096a298bfe85d18bb4a9b0cd7e935745;
		((Control)c283bbab44b3fca5d39367f132894644e).Anchor = (AnchorStyles)6;
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)cd15be71e631d305f43afbb3c1b0f6e4a);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c83cbe56f2b7bee7132b1839eeb8b0961);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c57aee6ef17ae9d24901d0e04b49a1ff3);
		((Control)c283bbab44b3fca5d39367f132894644e).Controls.Add((Control)(object)c432762ed3a6f0f1ffdf40b5f998a43eb);
		((Control)c283bbab44b3fca5d39367f132894644e).Location = new Point(221, 56);
		((Control)c283bbab44b3fca5d39367f132894644e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16536);
		((Control)c283bbab44b3fca5d39367f132894644e).Size = new Size(130, 118);
		((Control)c283bbab44b3fca5d39367f132894644e).TabIndex = 9;
		c283bbab44b3fca5d39367f132894644e.TabStop = false;
		((Control)c283bbab44b3fca5d39367f132894644e).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50108);
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).AutoSize = true;
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).Location = new Point(6, 69);
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(744);
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).RightToLeft = (RightToLeft)0;
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).Size = new Size(62, 17);
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).TabIndex = 11;
		((Control)cd15be71e631d305f43afbb3c1b0f6e4a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(763);
		((ButtonBase)cd15be71e631d305f43afbb3c1b0f6e4a).UseVisualStyleBackColor = true;
		cd15be71e631d305f43afbb3c1b0f6e4a.CheckedChanged += c15356631c1fa143d9672841fa31105d0;
		cd15be71e631d305f43afbb3c1b0f6e4a.CheckStateChanged += c1c1c59cf47b1526b46a9815de550c7e5;
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).AutoSize = true;
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).Location = new Point(6, 92);
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(778);
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).RightToLeft = (RightToLeft)0;
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).Size = new Size(77, 17);
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).TabIndex = 2;
		((Control)c83cbe56f2b7bee7132b1839eeb8b0961).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(803);
		((ButtonBase)c83cbe56f2b7bee7132b1839eeb8b0961).UseVisualStyleBackColor = true;
		c83cbe56f2b7bee7132b1839eeb8b0961.CheckedChanged += ce0c9f663602618b66c3227ad509bffc5;
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).AutoSize = true;
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).Location = new Point(6, 46);
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(576);
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).RightToLeft = (RightToLeft)0;
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).Size = new Size(55, 17);
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).TabIndex = 1;
		((Control)c57aee6ef17ae9d24901d0e04b49a1ff3).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(593);
		((ButtonBase)c57aee6ef17ae9d24901d0e04b49a1ff3).UseVisualStyleBackColor = true;
		c57aee6ef17ae9d24901d0e04b49a1ff3.CheckedChanged += caf96aeee0134a433b04e8dd016c86780;
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).AutoSize = true;
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).Location = new Point(6, 23);
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(452);
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).RightToLeft = (RightToLeft)0;
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).Size = new Size(59, 17);
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).TabIndex = 0;
		((Control)c432762ed3a6f0f1ffdf40b5f998a43eb).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(467);
		((ButtonBase)c432762ed3a6f0f1ffdf40b5f998a43eb).UseVisualStyleBackColor = true;
		c432762ed3a6f0f1ffdf40b5f998a43eb.CheckedChanged += c2a2eeab10147d9c1c0620cd1f4830c75;
		c79769badd3b3f4571a08b51317e02dcc.DialogResult = (DialogResult)2;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(440, 352);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 10;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50141);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(276, 352);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(98, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 11;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50152);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += cac0bf4911c99aa3dc2962dbb8bbad8b3;
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).Location = new Point(80, 352);
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50185);
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).Size = new Size(67, 23);
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).TabIndex = 12;
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50200);
		((ButtonBase)cf75d8a725a0a9a9a86c4a3dd2fefd487).UseVisualStyleBackColor = true;
		((Control)cf75d8a725a0a9a9a86c4a3dd2fefd487).Click += c625aba1ddf44ba88235d17a227618ea8;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(221, 262);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(294, 69);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 13;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = componentResourceManager.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50219));
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(224, 9);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9893);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(91, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 14;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50242);
		((Control)c2f5432c4b3efa84d2eb1592df7281409).Location = new Point(227, 25);
		((Control)c2f5432c4b3efa84d2eb1592df7281409).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50273);
		((Control)c2f5432c4b3efa84d2eb1592df7281409).Size = new Size(268, 20);
		((Control)c2f5432c4b3efa84d2eb1592df7281409).TabIndex = 15;
		((Control)c2f5432c4b3efa84d2eb1592df7281409).Leave += c60d478a308ac6925cfad1007164b94c3;
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Controls.Add((Control)(object)c5c7f6bf19374b3ca8a6002e13d46d379);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Location = new Point(221, 181);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8898);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Size = new Size(130, 65);
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).TabIndex = 16;
		ca97c16bb25e579acbfca5f9ec5f38762.TabStop = false;
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50302);
		((Control)c5c7f6bf19374b3ca8a6002e13d46d379).Location = new Point(6, 19);
		((Control)c5c7f6bf19374b3ca8a6002e13d46d379).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50339);
		((Control)c5c7f6bf19374b3ca8a6002e13d46d379).Size = new Size(118, 40);
		((Control)c5c7f6bf19374b3ca8a6002e13d46d379).TabIndex = 0;
		((Control)c5c7f6bf19374b3ca8a6002e13d46d379).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50362);
		((ButtonBase)c5c7f6bf19374b3ca8a6002e13d46d379).UseVisualStyleBackColor = true;
		c5c7f6bf19374b3ca8a6002e13d46d379.CheckedChanged += c558a56c61b6a7311e6e611b7f2783217;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)c79769badd3b3f4571a08b51317e02dcc;
		((Form)this).ClientSize = new Size(527, 387);
		((Control)this).Controls.Add((Control)(object)ca97c16bb25e579acbfca5f9ec5f38762);
		((Control)this).Controls.Add((Control)(object)c2f5432c4b3efa84d2eb1592df7281409);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)cf75d8a725a0a9a9a86c4a3dd2fefd487);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)c283bbab44b3fca5d39367f132894644e);
		((Control)this).Controls.Add((Control)(object)ca80957da81788ac8a6f393ba3899a63f);
		((Control)this).Controls.Add((Control)(object)cb4e261ca3b37fecaaeb4e6c758995d76);
		((Control)this).Controls.Add((Control)(object)cd06b5398b27d091d6962c9c9b75befc4);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)lbMenuItems);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50429);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50429);
		((Control)ca80957da81788ac8a6f393ba3899a63f).ResumeLayout(false);
		((Control)ca80957da81788ac8a6f393ba3899a63f).PerformLayout();
		((Control)c283bbab44b3fca5d39367f132894644e).ResumeLayout(false);
		((Control)c283bbab44b3fca5d39367f132894644e).PerformLayout();
		((Control)ca97c16bb25e579acbfca5f9ec5f38762).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
