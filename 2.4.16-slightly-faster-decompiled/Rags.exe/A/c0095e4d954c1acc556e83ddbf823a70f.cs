using System;
using System.IO;
using System.Reflection;

namespace A;

internal sealed class c0095e4d954c1acc556e83ddbf823a70f
{
	private static readonly Assembly c851c565b1664bb56b38ee3768be40c30;

	static c0095e4d954c1acc556e83ddbf823a70f()
	{
		if ((object)c851c565b1664bb56b38ee3768be40c30 != null)
		{
			__ldtoken(c0095e4d954c1acc556e83ddbf823a70f._002Ecctor());
			return;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = executingAssembly.GetName().Name;
		string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
		for (int i = 0; i < manifestResourceNames.Length; i++)
		{
			__ldtoken(c0095e4d954c1acc556e83ddbf823a70f._002Ecctor());
			string text = manifestResourceNames[i];
			if (name == text)
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				byte[] rawAssembly = ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(manifestResourceStream);
				c851c565b1664bb56b38ee3768be40c30 = Assembly.Load(rawAssembly);
				break;
			}
		}
	}

	internal static void c9a983174aeb83a0195571964eff0c4e6()
	{
		AppDomain.CurrentDomain.ResourceResolve += cf753c9c5e626c50010b18e66c029bb84;
	}

	private static Assembly cf753c9c5e626c50010b18e66c029bb84(object P_0, ResolveEventArgs P_1)
	{
		if ((object)c851c565b1664bb56b38ee3768be40c30 != null)
		{
			string[] manifestResourceNames = c851c565b1664bb56b38ee3768be40c30.GetManifestResourceNames();
			for (int i = 0; i < manifestResourceNames.Length; i++)
			{
				__ldtoken(c0095e4d954c1acc556e83ddbf823a70f.cf753c9c5e626c50010b18e66c029bb84(object, ResolveEventArgs));
				string text = manifestResourceNames[i];
				if (!(text == P_1.Name))
				{
					__ldtoken(c0095e4d954c1acc556e83ddbf823a70f.cf753c9c5e626c50010b18e66c029bb84(object, ResolveEventArgs));
					continue;
				}
				return c851c565b1664bb56b38ee3768be40c30;
			}
			return null;
		}
		return c851c565b1664bb56b38ee3768be40c30;
	}
}
