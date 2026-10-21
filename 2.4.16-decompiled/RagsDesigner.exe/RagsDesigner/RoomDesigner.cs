using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class RoomDesigner : Form
{
	private Label c300c24b05030c9258d5792c1ed7c590d;

	public TextBox txtDescription;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private ListBox cf67682eb346c8a3250035943f6d9267f;

	private Label cd09080500aac71b8d7141db7ac20e5ef;

	private ListBox cf58bb0948d4ea9890ad4587b3edbb984;

	private Button c9912dc5182d7219d9182dd331caae777;

	private ContextMenu cd91978c9b1c1d8f7c47726fc43d5e9e9;

	private MenuItem cbc3a44d9db35ee5fa09665bbd8cf839f;

	private MenuItem c3ba7f2ab0fe50e26fa846436440aea5f;

	public TextBox txtSDesc;

	public TextBox txtRoomName;

	private Label c6761cb7a3178225f4ccff1b5433d216f;

	public PictureBox picRoom;

	private OpenFileDialog c65a80a92021b1ba189aaec42668c1427;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	public Room CurRoom;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	private Container c501c89bc63d55bb522eac228aeeebb18;

	public RoomDesigner(Room TheRoom)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		CurRoom = TheRoom;
		if (TheRoom == null)
		{
			__ldtoken(RoomDesigner._002Ector(Room));
			return;
		}
		((Control)txtRoomName).Text = TheRoom.Name;
		((Control)txtDescription).Text = TheRoom.Description;
		((Control)txtSDesc).Text = TheRoom.SDesc;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RoomDesigner.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(RoomDesigner.Dispose(bool));
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
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RoomDesigner));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		txtDescription = new TextBox();
		txtSDesc = new TextBox();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		cf67682eb346c8a3250035943f6d9267f = new ListBox();
		cd91978c9b1c1d8f7c47726fc43d5e9e9 = new ContextMenu();
		cbc3a44d9db35ee5fa09665bbd8cf839f = new MenuItem();
		c3ba7f2ab0fe50e26fa846436440aea5f = new MenuItem();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		cd09080500aac71b8d7141db7ac20e5ef = new Label();
		cf58bb0948d4ea9890ad4587b3edbb984 = new ListBox();
		c9912dc5182d7219d9182dd331caae777 = new Button();
		txtRoomName = new TextBox();
		c6761cb7a3178225f4ccff1b5433d216f = new Label();
		picRoom = new PictureBox();
		c65a80a92021b1ba189aaec42668c1427 = new OpenFileDialog();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		((ISupportInitialize)picRoom).BeginInit();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(16, 33);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(64, 16);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11064);
		((Control)txtDescription).Location = new Point(80, 25);
		((Control)txtDescription).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74279);
		((Control)txtDescription).Size = new Size(296, 20);
		((Control)txtDescription).TabIndex = 1;
		((Control)txtDescription).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72941);
		((Control)txtSDesc).Location = new Point(80, 49);
		((Control)txtSDesc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74308);
		((Control)txtSDesc).Size = new Size(296, 20);
		((Control)txtSDesc).TabIndex = 3;
		((Control)txtSDesc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72941);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(16, 57);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(64, 16);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 2;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74325);
		((Control)cf67682eb346c8a3250035943f6d9267f).ContextMenu = cd91978c9b1c1d8f7c47726fc43d5e9e9;
		((Control)cf67682eb346c8a3250035943f6d9267f).Location = new Point(16, 104);
		((Control)cf67682eb346c8a3250035943f6d9267f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74348);
		((Control)cf67682eb346c8a3250035943f6d9267f).Size = new Size(120, 199);
		((Control)cf67682eb346c8a3250035943f6d9267f).TabIndex = 4;
		cf67682eb346c8a3250035943f6d9267f.SelectedIndexChanged += c3597667c72af851d9c9ea6deb7fe0ad4;
		((Menu)cd91978c9b1c1d8f7c47726fc43d5e9e9).MenuItems.AddRange(new MenuItem[2] { cbc3a44d9db35ee5fa09665bbd8cf839f, c3ba7f2ab0fe50e26fa846436440aea5f });
		cd91978c9b1c1d8f7c47726fc43d5e9e9.Popup += c981363b2b346ef10f28438ee52142634;
		cbc3a44d9db35ee5fa09665bbd8cf839f.Index = 0;
		cbc3a44d9db35ee5fa09665bbd8cf839f.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2985);
		cbc3a44d9db35ee5fa09665bbd8cf839f.Click += c24f9edf5d0fb0ad5746c4118fa03a98e;
		c3ba7f2ab0fe50e26fa846436440aea5f.Index = 1;
		c3ba7f2ab0fe50e26fa846436440aea5f.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2994);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(16, 81);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9893);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(100, 16);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 5;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74363);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Location = new Point(240, 82);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9847);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Size = new Size(100, 16);
		((Control)cd09080500aac71b8d7141db7ac20e5ef).TabIndex = 7;
		((Control)cd09080500aac71b8d7141db7ac20e5ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13601);
		((Control)cf58bb0948d4ea9890ad4587b3edbb984).ContextMenu = cd91978c9b1c1d8f7c47726fc43d5e9e9;
		((Control)cf58bb0948d4ea9890ad4587b3edbb984).Location = new Point(240, 104);
		((Control)cf58bb0948d4ea9890ad4587b3edbb984).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74376);
		((Control)cf58bb0948d4ea9890ad4587b3edbb984).Size = new Size(120, 199);
		((Control)cf58bb0948d4ea9890ad4587b3edbb984).TabIndex = 6;
		((Control)c9912dc5182d7219d9182dd331caae777).Location = new Point(152, 304);
		((Control)c9912dc5182d7219d9182dd331caae777).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73099);
		((Control)c9912dc5182d7219d9182dd331caae777).Size = new Size(75, 23);
		((Control)c9912dc5182d7219d9182dd331caae777).TabIndex = 8;
		((Control)c9912dc5182d7219d9182dd331caae777).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74395);
		((Control)c9912dc5182d7219d9182dd331caae777).Click += c4ae2942e8a8490f245d8e62e8457341c;
		((Control)txtRoomName).Location = new Point(80, 1);
		((Control)txtRoomName).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10884);
		((Control)txtRoomName).Size = new Size(296, 20);
		((Control)txtRoomName).TabIndex = 10;
		((Control)txtRoomName).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72941);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Location = new Point(8, 9);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(25933);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Size = new Size(72, 16);
		((Control)c6761cb7a3178225f4ccff1b5433d216f).TabIndex = 9;
		((Control)c6761cb7a3178225f4ccff1b5433d216f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10945);
		picRoom.BorderStyle = (BorderStyle)1;
		((Control)picRoom).Location = new Point(376, 112);
		((Control)picRoom).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11206);
		((Control)picRoom).Size = new Size(160, 192);
		picRoom.SizeMode = (PictureBoxSizeMode)1;
		picRoom.TabIndex = 11;
		picRoom.TabStop = false;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(376, 80);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 12;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74406);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(256, 304);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(75, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 13;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Form)this).ClientSize = new Size(688, 398);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)picRoom);
		((Control)this).Controls.Add((Control)(object)txtRoomName);
		((Control)this).Controls.Add((Control)(object)txtSDesc);
		((Control)this).Controls.Add((Control)(object)txtDescription);
		((Control)this).Controls.Add((Control)(object)c6761cb7a3178225f4ccff1b5433d216f);
		((Control)this).Controls.Add((Control)(object)c9912dc5182d7219d9182dd331caae777);
		((Control)this).Controls.Add((Control)(object)cd09080500aac71b8d7141db7ac20e5ef);
		((Control)this).Controls.Add((Control)(object)cf58bb0948d4ea9890ad4587b3edbb984);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)cf67682eb346c8a3250035943f6d9267f);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74429);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74429);
		((ISupportInitialize)picRoom).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c3597667c72af851d9c9ea6deb7fe0ad4(object P_0, EventArgs P_1)
	{
	}

	private void c981363b2b346ef10f28438ee52142634(object P_0, EventArgs P_1)
	{
	}

	private void c24f9edf5d0fb0ad5746c4118fa03a98e(object P_0, EventArgs P_1)
	{
		if (!((Control)cf67682eb346c8a3250035943f6d9267f).Focused)
		{
			__ldtoken(RoomDesigner.c24f9edf5d0fb0ad5746c4118fa03a98e(object, EventArgs));
			_ = ((Control)cf58bb0948d4ea9890ad4587b3edbb984).Focused;
		}
	}

	private void c4ae2942e8a8490f245d8e62e8457341c(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)c65a80a92021b1ba189aaec42668c1427).ShowDialog() != 2)
		{
			picRoom.Image = Image.FromFile(((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName);
		}
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}
}
