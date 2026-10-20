using System;
using System.IO;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Rags;

[Serializable]
public class LockData
{
	public string key = string.Empty;

	public string email = string.Empty;

	public string id = string.Empty;

	public string nickname = string.Empty;

	public DateTime registrationtime = DateTime.Now;

	public DateTime ExpirationDate = DateTime.Now;

	public string VersionNumber = string.Empty;

	public static string GetMacAddress()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("select *  from win32_logicaldisk");
			ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ManagementObject val2 = (ManagementObject)enumerator.Current;
					if (((ManagementBaseObject)val2)["DeviceID"].ToString() == Directory.GetDirectoryRoot(Environment.GetCommandLineArgs()[0]).Substring(0, 2))
					{
						stringBuilder.Append(((ManagementBaseObject)val2)["VolumeSerialNumber"].ToString());
						break;
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
		}
		catch
		{
			stringBuilder = new StringBuilder();
			stringBuilder.Append("DEF001");
		}
		return stringBuilder.ToString().Replace(":", "");
	}

	public static string GetExpirationDate()
	{
		string result = DateTime.Now.ToString();
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "wpflock.lck");
			if (File.Exists(text2))
			{
				MemoryStream memst = new MemoryStream();
				CryptoStream cs = null;
				EncDec.Decrypt(text2, ref memst, ref cs, GetMacAddress());
				memst.Seek(0L, SeekOrigin.Begin);
				StreamReader streamReader = new StreamReader(memst);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				LockData lockData = null;
				try
				{
					lockData = (LockData)binaryFormatter.Deserialize(streamReader.BaseStream);
					result = lockData.ExpirationDate.ToString();
				}
				catch
				{
				}
				streamReader.Close();
				streamReader.Dispose();
				cs.Close();
				cs.Dispose();
			}
		}
		catch
		{
			result = DateTime.Now.ToString();
		}
		return result;
	}

	public static string GetNickName()
	{
		string empty = string.Empty;
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "wpflock.lck");
			if (File.Exists(text2))
			{
				MemoryStream memst = new MemoryStream();
				CryptoStream cs = null;
				EncDec.Decrypt(text2, ref memst, ref cs, GetMacAddress());
				memst.Seek(0L, SeekOrigin.Begin);
				StreamReader streamReader = new StreamReader(memst);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				LockData lockData = null;
				try
				{
					lockData = (LockData)binaryFormatter.Deserialize(streamReader.BaseStream);
					empty = lockData.nickname;
				}
				catch
				{
				}
				streamReader.Close();
				streamReader.Dispose();
				cs.Close();
				cs.Dispose();
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static string GetEmail()
	{
		string empty = string.Empty;
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "wpflock.lck");
			if (File.Exists(text2))
			{
				MemoryStream memst = new MemoryStream();
				CryptoStream cs = null;
				EncDec.Decrypt(text2, ref memst, ref cs, GetMacAddress());
				memst.Seek(0L, SeekOrigin.Begin);
				StreamReader streamReader = new StreamReader(memst);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				LockData lockData = null;
				try
				{
					lockData = (LockData)binaryFormatter.Deserialize(streamReader.BaseStream);
					empty = lockData.email;
				}
				catch
				{
				}
				streamReader.Close();
				streamReader.Dispose();
				cs.Close();
				cs.Dispose();
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static string GetKey()
	{
		string empty = string.Empty;
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "wpflock.lck");
			if (File.Exists(text2))
			{
				MemoryStream memst = new MemoryStream();
				CryptoStream cs = null;
				EncDec.Decrypt(text2, ref memst, ref cs, GetMacAddress());
				memst.Seek(0L, SeekOrigin.Begin);
				StreamReader streamReader = new StreamReader(memst);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				LockData lockData = null;
				try
				{
					lockData = (LockData)binaryFormatter.Deserialize(streamReader.BaseStream);
					empty = lockData.key;
				}
				catch
				{
				}
				streamReader.Close();
				streamReader.Dispose();
				cs.Close();
				cs.Dispose();
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static bool IsLicensed(bool bdisplay, string test2)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		try
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
				EncDec.Decrypt(text3, ref memst, ref cs, GetMacAddress());
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
				streamReader.Close();
				streamReader.Dispose();
				cs.Close();
				cs.Dispose();
				if (lockData != null)
				{
					if (lockData.id != GetMacAddress())
					{
						if (bdisplay)
						{
							MessageBox.Show("Your Rags installation seems to have moved.  Please register again in the Help->Register form.");
						}
					}
					else
					{
						Version version = new Version(Game.ObjectVersionNumber);
						Version version2 = new Version(lockData.VersionNumber);
						if (version > version2)
						{
							if (DateTime.Now > lockData.ExpirationDate)
							{
								if (bdisplay)
								{
									MessageBox.Show("Please re-register this new version of Rags Designer in the Help->Register menu.  Your subscription has expired.");
								}
							}
							else
							{
								lockData.VersionNumber = Game.ObjectVersionNumber;
								memst = new MemoryStream();
								binaryFormatter = new BinaryFormatter();
								binaryFormatter.Serialize(memst, lockData);
								memst.Seek(0L, SeekOrigin.Begin);
								EncDec.Encrypt(memst, text3, GetMacAddress());
								result = true;
								memst.Close();
								memst.Dispose();
							}
						}
						else
						{
							result = true;
						}
					}
				}
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
