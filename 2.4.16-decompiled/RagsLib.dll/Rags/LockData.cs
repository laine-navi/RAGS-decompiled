using System;
using System.IO;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using A;

namespace Rags;

[Serializable]
public sealed class LockData
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
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23040));
			ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(LockData.GetMacAddress());
					ManagementObject val2 = (ManagementObject)enumerator.Current;
					if (((ManagementBaseObject)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23105)].ToString() == Directory.GetDirectoryRoot(Application.ExecutablePath).Substring(0, 2))
					{
						stringBuilder.Append(((ManagementBaseObject)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23122)].ToString());
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
			stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23159));
		}
		return stringBuilder.ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929), "");
	}

	public static string GetExpirationDate()
	{
		string result = DateTime.Now.ToString();
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
			if (Directory.Exists(text))
			{
				__ldtoken(LockData.GetExpirationDate());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			if (!File.Exists(text2))
			{
				__ldtoken(LockData.GetExpirationDate());
			}
			else
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
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			if (!File.Exists(text2))
			{
				__ldtoken(LockData.GetNickName());
			}
			else
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
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			if (!File.Exists(text2))
			{
				__ldtoken(LockData.GetEmail());
			}
			else
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
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
			if (Directory.Exists(text))
			{
				__ldtoken(LockData.GetKey());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			if (!File.Exists(text2))
			{
				__ldtoken(LockData.GetKey());
			}
			else
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
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		try
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			string text3 = Path.Combine(text2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23181));
			if (File.Exists(text))
			{
				if (File.Exists(text3))
				{
					__ldtoken(LockData.IsLicensed(bool, string));
				}
				else
				{
					File.Copy(text, text3);
				}
			}
			if (!File.Exists(text3))
			{
				__ldtoken(LockData.IsLicensed(bool, string));
			}
			else
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
				if (lockData == null)
				{
					__ldtoken(LockData.IsLicensed(bool, string));
				}
				else if (lockData.id != GetMacAddress())
				{
					if (bdisplay)
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23198));
					}
				}
				else
				{
					Version version = new Version(Game.ObjectVersionNumber);
					Version version2 = new Version(lockData.VersionNumber);
					if (version > version2)
					{
						if (!(DateTime.Now > lockData.ExpirationDate))
						{
							__ldtoken(LockData.IsLicensed(bool, string));
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
						else if (!bdisplay)
						{
							__ldtoken(LockData.IsLicensed(bool, string));
						}
						else
						{
							MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23388));
						}
					}
					else
					{
						result = true;
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
