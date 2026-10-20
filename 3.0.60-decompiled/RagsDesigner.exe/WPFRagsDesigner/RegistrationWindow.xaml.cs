using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Rags;
using WPFRagsDesigner.ServiceReference1;
using WPFRagsLib.RagsGame.com;

namespace WPFRagsDesigner;

public partial class RegistrationWindow : Window, IComponentConnector
{
	internal TextBox a;

	internal TextBox b;

	internal Button c;

	internal Button d;

	internal Button e;

	private bool f;

	public RegistrationWindow()
	{
		InitializeComponent();
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		WPFRagsDesigner.ServiceReference1.CheckUpdatesSoapClient checkUpdatesSoapClient = new WPFRagsDesigner.ServiceReference1.CheckUpdatesSoapClient();
		RegData regData = new RegData();
		try
		{
			regData = checkUpdatesSoapClient.Register(this.b.Text, this.a.Text, LockData.GetMacAddress());
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
				string text2 = Path.Combine(text, "wpflock.lck");
				if (File.Exists(text2))
				{
					File.Copy(text2, text2 + ".bak", overwrite: true);
					File.Delete(text2);
				}
				LockData lockData = new LockData();
				lockData.email = this.a.Text;
				lockData.key = this.b.Text;
				lockData.registrationtime = DateTime.Now;
				lockData.ExpirationDate = regData.expire;
				lockData.id = LockData.GetMacAddress();
				lockData.VersionNumber = Game.ObjectVersionNumber;
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, lockData);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				EncDec.Encrypt(memoryStream, text2, LockData.GetMacAddress());
				MessageBox.Show("Congratulations.  Your copy of Rags Designer is now registered.  Your subscription will expire on " + lockData.ExpirationDate.ToString() + ".");
				((Window)this).DialogResult = true;
			}
		}
		catch
		{
			MessageBox.Show("Sorry, Rags is unable to communicate with the server.  Please try again later.");
		}
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wpflock.lck");
		string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = Path.Combine(text2, "wpflock.lck");
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
				this.a.Text = lockData.email;
				this.b.Text = lockData.key;
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

	private void a(object A_0, RoutedEventArgs A_1)
	{
		Process.Start("http://www.ragsgame.com/?page_id=285");
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(RegistrationWindow)target).Loaded += b;
			break;
		case 2:
			this.a = (TextBox)target;
			break;
		case 3:
			this.b = (TextBox)target;
			break;
		case 4:
			this.c = (Button)target;
			((ButtonBase)this.c).Click += c;
			break;
		case 5:
			d = (Button)target;
			((ButtonBase)d).Click += a;
			break;
		case 6:
			e = (Button)target;
			break;
		default:
			f = true;
			break;
		}
	}
}
