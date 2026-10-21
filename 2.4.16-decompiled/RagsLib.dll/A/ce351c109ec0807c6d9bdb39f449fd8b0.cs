using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;

namespace A;

internal sealed class ce351c109ec0807c6d9bdb39f449fd8b0
{
	internal static byte[] c7a8d5e973c17e5684fb07726c4034633(Stream P_0)
	{
		byte b = (byte)P_0.ReadByte();
		byte[] array = new byte[P_0.Length - 1];
		P_0.Read(array, 0, array.Length);
		if ((b & 1) == 0)
		{
			__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
		}
		else
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array2 = new byte[8];
			Buffer.BlockCopy(array, 0, array2, 0, 8);
			dESCryptoServiceProvider.IV = array2;
			byte[] array3 = new byte[8];
			Buffer.BlockCopy(array, 8, array3, 0, 8);
			bool flag = true;
			byte[] array4 = array3;
			for (int i = 0; i < array4.Length; i++)
			{
				__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
				if (array4[i] == 0)
				{
					__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				array3 = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
			}
			dESCryptoServiceProvider.Key = array3;
			array = dESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 16, array.Length - 16);
		}
		if ((b & 2) == 0)
		{
			__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
		}
		else
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream(array);
				DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
				MemoryStream memoryStream2 = new MemoryStream((int)memoryStream.Length * 2);
				int num = 1000;
				byte[] buffer = new byte[num];
				while (true)
				{
					int num2 = deflateStream.Read(buffer, 0, num);
					if (num2 <= 0)
					{
						__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
					}
					else
					{
						memoryStream2.Write(buffer, 0, num2);
					}
					if (num2 < num)
					{
						break;
					}
					__ldtoken(ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(Stream));
				}
				array = memoryStream2.ToArray();
			}
			catch (Exception)
			{
			}
		}
		return array;
	}
}
