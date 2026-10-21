using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rags;

public class EncDec
{
	public static int MaxLength = 129;

	public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
	{
		MemoryStream memoryStream = new MemoryStream();
		Rijndael rijndael = Rijndael.Create();
		rijndael.Key = Key;
		rijndael.IV = IV;
		CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(clearData, 0, clearData.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}

	public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
	{
		if (saltBytes == null)
		{
			int minValue = 4;
			int maxValue = 8;
			saltBytes = new byte[new Random().Next(minValue, maxValue)];
			new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		byte[] array = new byte[bytes.Length + saltBytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[i] = bytes[i];
		}
		for (int j = 0; j < saltBytes.Length; j++)
		{
			array[bytes.Length + j] = saltBytes[j];
		}
		if (hashAlgorithm == null)
		{
			hashAlgorithm = "";
		}
		byte[] array2 = (hashAlgorithm.ToUpper() switch
		{
			"SHA1" => (HashAlgorithm)new SHA1Managed(), 
			"SHA256" => new SHA256Managed(), 
			"SHA384" => new SHA384Managed(), 
			"SHA512" => new SHA512Managed(), 
			_ => new MD5CryptoServiceProvider(), 
		}).ComputeHash(array);
		byte[] array3 = new byte[array2.Length + saltBytes.Length];
		for (int k = 0; k < array2.Length; k++)
		{
			array3[k] = array2[k];
		}
		for (int l = 0; l < saltBytes.Length; l++)
		{
			array3[array2.Length + l] = saltBytes[l];
		}
		return Convert.ToBase64String(array3);
	}

	public static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue)
	{
		byte[] array = Convert.FromBase64String(hashValue);
		if (hashAlgorithm == null)
		{
			hashAlgorithm = "";
		}
		int num = hashAlgorithm.ToUpper() switch
		{
			"SHA1" => 160, 
			"SHA256" => 256, 
			"SHA384" => 384, 
			"SHA512" => 512, 
			_ => 128, 
		} / 8;
		if (array.Length < num)
		{
			return false;
		}
		byte[] array2 = new byte[array.Length - num];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[num + i];
		}
		string text = ComputeHash(plainText, hashAlgorithm, array2);
		return hashValue == text;
	}

	public static string Encrypt(string clearText, string Password)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(clearText);
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		return Convert.ToBase64String(Encrypt(bytes, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16)));
	}

	public static byte[] Encrypt(byte[] clearData, string Password)
	{
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		return Encrypt(clearData, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
	}

	public static void Encrypt(string fileIn, string fileOut, string Password)
	{
		FileStream fileStream = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
		FileStream stream = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		Rijndael rijndael = Rijndael.Create();
		rijndael.Key = passwordDeriveBytes.GetBytes(32);
		rijndael.IV = passwordDeriveBytes.GetBytes(16);
		CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
		int num = 4096;
		byte[] buffer = new byte[num];
		int num2;
		do
		{
			num2 = fileStream.Read(buffer, 0, num);
			cryptoStream.Write(buffer, 0, num2);
		}
		while (num2 != 0);
		cryptoStream.Close();
		fileStream.Close();
	}

	public static void Encrypt(MemoryStream fsIn, string fileOut, string Password)
	{
		FileStream stream = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		Rijndael rijndael = Rijndael.Create();
		rijndael.Key = passwordDeriveBytes.GetBytes(32);
		rijndael.IV = passwordDeriveBytes.GetBytes(16);
		CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
		int num = 4096;
		byte[] buffer = new byte[num];
		int num2;
		do
		{
			num2 = fsIn.Read(buffer, 0, num);
			cryptoStream.Write(buffer, 0, num2);
		}
		while (num2 != 0);
		cryptoStream.Close();
		fsIn.Close();
	}

	public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
	{
		byte[] array = null;
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = Key;
			rijndael.IV = IV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(cipherData, 0, cipherData.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return memoryStream.ToArray();
		}
		catch
		{
			return null;
		}
	}

	public static byte[] Decrypt(byte[] cipherData, string Password)
	{
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		return Decrypt(cipherData, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
	}

	public static void Decrypt(string fileIn, ref MemoryStream memst, ref CryptoStream cs, string Password)
	{
		try
		{
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
			{
				73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
				100, 101, 118
			});
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = passwordDeriveBytes.GetBytes(32);
			rijndael.IV = passwordDeriveBytes.GetBytes(16);
			cs = new CryptoStream(memst, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			byte[] array = File.ReadAllBytes(fileIn);
			cs.Write(array, 0, array.Length);
			try
			{
				cs.FlushFinalBlock();
			}
			catch (Exception ex)
			{
				_ = ex.Message;
			}
		}
		catch
		{
			if (cs != null)
			{
				cs.Close();
			}
		}
	}

	public static void Decrypt(string fileIn, ref CryptoStream cs, string Password)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(RagsZone(Password), new byte[13]
			{
				73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
				100, 101, 118
			});
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = passwordDeriveBytes.GetBytes(32);
			rijndael.IV = passwordDeriveBytes.GetBytes(16);
			int num = 4096;
			byte[] buffer = new byte[num];
			int num2;
			do
			{
				num2 = fileStream.Read(buffer, 0, num);
				cs.Write(buffer, 0, num2);
			}
			while (num2 != 0);
			fileStream.Close();
			fileStream = null;
		}
		catch
		{
			if (cs != null)
			{
				cs.Close();
			}
			fileStream?.Close();
		}
	}

	public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(initVector);
		byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
		byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
		byte[] bytes4 = new PasswordDeriveBytes(passPhrase, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
		ICryptoTransform transform = new RijndaelManaged
		{
			Mode = CipherMode.CBC
		}.CreateEncryptor(bytes4, bytes);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(bytes3, 0, bytes3.Length);
		cryptoStream.FlushFinalBlock();
		byte[] inArray = memoryStream.ToArray();
		memoryStream.Close();
		cryptoStream.Close();
		return Convert.ToBase64String(inArray);
	}

	public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(initVector);
		byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
		byte[] array = Convert.FromBase64String(cipherText);
		byte[] bytes3 = new PasswordDeriveBytes(passPhrase, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
		ICryptoTransform transform = new RijndaelManaged
		{
			Mode = CipherMode.CBC
		}.CreateDecryptor(bytes3, bytes);
		MemoryStream memoryStream = new MemoryStream(array);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
		byte[] array2 = new byte[array.Length];
		int count = cryptoStream.Read(array2, 0, array2.Length);
		memoryStream.Close();
		cryptoStream.Close();
		return Encoding.UTF8.GetString(array2, 0, count);
	}

	public static string RagsZone(string data)
	{
		StringBuilder stringBuilder = new StringBuilder(data);
		StringBuilder stringBuilder2 = new StringBuilder(data.Length);
		for (int i = 0; i < data.Length; i++)
		{
			char c = stringBuilder[i];
			c = (char)(c ^ MaxLength);
			stringBuilder2.Append(c);
		}
		return stringBuilder2.ToString();
	}
}
