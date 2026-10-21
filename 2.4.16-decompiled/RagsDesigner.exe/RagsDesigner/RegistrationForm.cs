using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using A;
using Rags;
using RagsDesigner.ragsgame.com;

namespace RagsDesigner;

public sealed class RegistrationForm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c471dc5523c1ce286d4ca044388c7d6c1;

	private Button c1686aee79bfd9a00c697ce5af776aca0;

	private TextBox c5130c91e13e93c1861065d7c33981de1;

	private TextBox c8b9316761e11c9be2c439d6d5f2efd3a;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	private string cfdc2f2caff5063c037a2bd204de0d9af = string.Empty;

	public RegistrationForm(string data)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cfdc2f2caff5063c037a2bd204de0d9af = data;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RegistrationForm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(RegistrationForm.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
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
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RegistrationForm));
		c471dc5523c1ce286d4ca044388c7d6c1 = new Button();
		c1686aee79bfd9a00c697ce5af776aca0 = new Button();
		c5130c91e13e93c1861065d7c33981de1 = new TextBox();
		c8b9316761e11c9be2c439d6d5f2efd3a = new TextBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		((Control)this).SuspendLayout();
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).Location = new Point(10, 192);
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47651);
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).Size = new Size(75, 23);
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).TabIndex = 0;
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47674);
		((ButtonBase)c471dc5523c1ce286d4ca044388c7d6c1).UseVisualStyleBackColor = true;
		((Control)c471dc5523c1ce286d4ca044388c7d6c1).Click += c021b380d0f9b5acc54aa5b3ad1575356;
		((Control)c1686aee79bfd9a00c697ce5af776aca0).Location = new Point(110, 192);
		((Control)c1686aee79bfd9a00c697ce5af776aca0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47691);
		((Control)c1686aee79bfd9a00c697ce5af776aca0).Size = new Size(75, 23);
		((Control)c1686aee79bfd9a00c697ce5af776aca0).TabIndex = 1;
		((Control)c1686aee79bfd9a00c697ce5af776aca0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47712);
		((ButtonBase)c1686aee79bfd9a00c697ce5af776aca0).UseVisualStyleBackColor = true;
		((Control)c1686aee79bfd9a00c697ce5af776aca0).Click += c01a58b0ba85d39ac34dfb3f8e177a67d;
		((Control)c5130c91e13e93c1861065d7c33981de1).Location = new Point(12, 32);
		((Control)c5130c91e13e93c1861065d7c33981de1).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47731);
		((Control)c5130c91e13e93c1861065d7c33981de1).Size = new Size(268, 20);
		((Control)c5130c91e13e93c1861065d7c33981de1).TabIndex = 2;
		((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Location = new Point(11, 80);
		((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47746);
		((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Size = new Size(269, 20);
		((Control)c8b9316761e11c9be2c439d6d5f2efd3a).TabIndex = 3;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(8, 16);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(174, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 4;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47757);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(8, 64);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(78, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 5;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47830);
		cad062cb240d8f3ea2aa4cedf8f7b42c8.DialogResult = (DialogResult)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(208, 192);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47338);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(75, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 6;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(12, 136);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9893);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(268, 31);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 7;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47861);
		((Form)this).AcceptButton = (IButtonControl)(object)c471dc5523c1ce286d4ca044388c7d6c1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8;
		((Form)this).ClientSize = new Size(292, 229);
		((Control)this).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c8b9316761e11c9be2c439d6d5f2efd3a);
		((Control)this).Controls.Add((Control)(object)c5130c91e13e93c1861065d7c33981de1);
		((Control)this).Controls.Add((Control)(object)c1686aee79bfd9a00c697ce5af776aca0);
		((Control)this).Controls.Add((Control)(object)c471dc5523c1ce286d4ca044388c7d6c1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48029);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48029);
		((Form)this).Load += cf610a680d19e1cbca054fcb779f505f4;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c01a58b0ba85d39ac34dfb3f8e177a67d(object P_0, EventArgs P_1)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48062));
		Process.Start(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(31994), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48410));
	}

	private void c021b380d0f9b5acc54aa5b3ad1575356(object P_0, EventArgs P_1)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		CheckUpdates checkUpdates = new CheckUpdates();
		RegData regData = new RegData();
		try
		{
			regData = checkUpdates.Register(((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Text, ((Control)c5130c91e13e93c1861065d7c33981de1).Text, LockData.GetMacAddress());
			if (regData.retval < 2)
			{
				__ldtoken(RegistrationForm.c021b380d0f9b5acc54aa5b3ad1575356(object, EventArgs));
				if (regData.retval != 0)
				{
					__ldtoken(RegistrationForm.c021b380d0f9b5acc54aa5b3ad1575356(object, EventArgs));
					if (regData.retval != 1)
					{
						__ldtoken(RegistrationForm.c021b380d0f9b5acc54aa5b3ad1575356(object, EventArgs));
					}
					else
					{
						string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(897));
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49365));
						if (File.Exists(text2))
						{
							File.Copy(text2, text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(27027), overwrite: true);
							File.Delete(text2);
						}
						LockData lockData = new LockData();
						lockData.email = ((Control)c5130c91e13e93c1861065d7c33981de1).Text;
						lockData.key = ((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Text;
						lockData.registrationtime = DateTime.Now;
						lockData.ExpirationDate = regData.expire;
						lockData.id = LockData.GetMacAddress();
						lockData.VersionNumber = Game.ObjectVersionNumber;
						MemoryStream memoryStream = new MemoryStream();
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.Serialize(memoryStream, lockData);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						EncDec.Encrypt(memoryStream, text2, LockData.GetMacAddress());
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49382) + lockData.ExpirationDate.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49580));
						((Form)this).DialogResult = (DialogResult)1;
					}
				}
				else
				{
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48893));
				}
			}
			else
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48485));
			}
		}
		catch
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49583));
		}
		Cursor.Current = Cursors.Default;
	}

	private void cf610a680d19e1cbca054fcb779f505f4(object P_0, EventArgs P_1)
	{
		string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49365));
		string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(897));
		if (Directory.Exists(text2))
		{
			__ldtoken(RegistrationForm.cf610a680d19e1cbca054fcb779f505f4(object, EventArgs));
		}
		else
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = Path.Combine(text2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49365));
		if (!File.Exists(text))
		{
			__ldtoken(RegistrationForm.cf610a680d19e1cbca054fcb779f505f4(object, EventArgs));
		}
		else if (File.Exists(text3))
		{
			__ldtoken(RegistrationForm.cf610a680d19e1cbca054fcb779f505f4(object, EventArgs));
		}
		else
		{
			File.Copy(text, text3);
		}
		if (File.Exists(text3))
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			EncDec.Decrypt(text3, ref memst, ref cs, LockData.GetMacAddress());
			memst.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memst);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			LockData lockData = null;
			try
			{
				lockData = (LockData)binaryFormatter.Deserialize(streamReader.BaseStream);
			}
			catch
			{
			}
			if (lockData == null)
			{
				__ldtoken(RegistrationForm.cf610a680d19e1cbca054fcb779f505f4(object, EventArgs));
			}
			else
			{
				((Control)c5130c91e13e93c1861065d7c33981de1).Text = lockData.email;
				((Control)c8b9316761e11c9be2c439d6d5f2efd3a).Text = lockData.key;
			}
			streamReader.Close();
			streamReader.Dispose();
			try
			{
				cs.Close();
				cs.Dispose();
			}
			catch
			{
			}
		}
	}
}
