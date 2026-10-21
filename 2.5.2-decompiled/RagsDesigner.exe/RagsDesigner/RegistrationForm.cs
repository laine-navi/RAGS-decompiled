using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using Rags;
using RagsDesigner.ragsgame.com;

namespace RagsDesigner;

public class RegistrationForm : Form
{
	private string m_a = string.Empty;

	private IContainer m_b;

	private Button m_c;

	private Button m_d;

	private TextBox e;

	private TextBox f;

	private Label g;

	private Label h;

	private Button i;

	private Label j;

	public RegistrationForm(string data)
	{
		a();
		this.m_a = data;
	}

	private void d(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		MessageBox.Show("You will now be directed to the Rags registration page.If you have any troubles getting to the registration site, you can simply go to http://www.ragsgame.com/purchase.aspx.");
		Process.Start("IEXPLORE.EXE", "http://www.ragsgame.com/purchase.aspx");
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		CheckUpdates checkUpdates = new CheckUpdates();
		RegData regData = new RegData();
		try
		{
			regData = checkUpdates.Register(((Control)f).Text, ((Control)e).Text, LockData.GetMacAddress());
			if (regData.retval >= 2)
			{
				MessageBox.Show("I'm sorry, this key has been registered on three computers already.  If you feel this is incorrect, or if you need to register additional computers, please contact support@ragsgame.com for more licenses.");
			}
			else if (regData.retval == 0)
			{
				MessageBox.Show("I'm sorry, this key and email combination has not been registered.  If you feel this is in error, please contact support@ragsgame.com.  If you have not yet purchased a key, please click on the Get A Key button on the Registration form.");
			}
			else if (regData.retval == 1)
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = Path.Combine(text, "lock.lck");
				if (File.Exists(text2))
				{
					File.Copy(text2, text2 + ".bak", overwrite: true);
					File.Delete(text2);
				}
				LockData lockData = new LockData();
				lockData.email = ((Control)e).Text;
				lockData.key = ((Control)f).Text;
				lockData.registrationtime = DateTime.Now;
				lockData.ExpirationDate = regData.expire;
				lockData.id = LockData.GetMacAddress();
				lockData.VersionNumber = Game.ObjectVersionNumber;
				MemoryStream memoryStream = new MemoryStream();
				new BinaryFormatter().Serialize(memoryStream, lockData);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				EncDec.Encrypt(memoryStream, text2, LockData.GetMacAddress());
				MessageBox.Show("Congratulations.  Your copy of Rags Designer is now registered.  Your subscription will expire on " + lockData.ExpirationDate.ToString() + ".");
				((Form)this).DialogResult = (DialogResult)1;
			}
		}
		catch
		{
			MessageBox.Show("Sorry, Rags is unable to communicate with the server.  Please try again later.");
		}
		Cursor.Current = Cursors.Default;
	}

	private void a(object A_0, EventArgs A_1)
	{
		string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lock.lck");
		string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = Path.Combine(text2, "lock.lck");
		if (File.Exists(text) && !File.Exists(text3))
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
			if (lockData != null)
			{
				((Control)e).Text = lockData.email;
				((Control)f).Text = lockData.key;
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
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RegistrationForm));
		this.m_c = new Button();
		this.m_d = new Button();
		e = new TextBox();
		f = new TextBox();
		g = new Label();
		h = new Label();
		i = new Button();
		j = new Label();
		((Control)this).SuspendLayout();
		((Control)this.m_c).Location = new Point(10, 192);
		((Control)this.m_c).Name = "btnRegister";
		((Control)this.m_c).Size = new Size(75, 23);
		((Control)this.m_c).TabIndex = 0;
		((Control)this.m_c).Text = "Register";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += b;
		((Control)this.m_d).Location = new Point(110, 192);
		((Control)this.m_d).Name = "btnGetAKey";
		((Control)this.m_d).Size = new Size(75, 23);
		((Control)this.m_d).TabIndex = 1;
		((Control)this.m_d).Text = "Get A Key";
		((ButtonBase)this.m_d).UseVisualStyleBackColor = true;
		((Control)this.m_d).Click += c;
		((Control)e).Location = new Point(12, 32);
		((Control)e).Name = "tbEmail";
		((Control)e).Size = new Size(268, 20);
		((Control)e).TabIndex = 2;
		((Control)f).Location = new Point(11, 80);
		((Control)f).Name = "tbKey";
		((Control)f).Size = new Size(269, 20);
		((Control)f).TabIndex = 3;
		((Control)g).AutoSize = true;
		((Control)g).Location = new Point(8, 16);
		((Control)g).Name = "label1";
		((Control)g).Size = new Size(174, 13);
		((Control)g).TabIndex = 4;
		((Control)g).Text = "Enter your registered email address:";
		((Control)h).AutoSize = true;
		((Control)h).Location = new Point(8, 64);
		((Control)h).Name = "label2";
		((Control)h).Size = new Size(78, 13);
		((Control)h).TabIndex = 5;
		((Control)h).Text = "Enter your key:";
		i.DialogResult = (DialogResult)2;
		((Control)i).Location = new Point(208, 192);
		((Control)i).Name = "btnCancel";
		((Control)i).Size = new Size(75, 23);
		((Control)i).TabIndex = 6;
		((Control)i).Text = "Cancel";
		((ButtonBase)i).UseVisualStyleBackColor = true;
		((Control)i).Click += d;
		((Control)j).Location = new Point(12, 136);
		((Control)j).Name = "label3";
		((Control)j).Size = new Size(268, 31);
		((Control)j).TabIndex = 7;
		((Control)j).Text = "If you don't have a key yet, you can click the \"Get A Key\" button below to get one.";
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_c;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)i;
		((Form)this).ClientSize = new Size(292, 229);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "RegistrationForm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "RegistrationForm";
		((Form)this).Load += a;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
