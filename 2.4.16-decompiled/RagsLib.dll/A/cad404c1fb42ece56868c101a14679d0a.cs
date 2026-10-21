using System.IO;
using System.Reflection;
using System.Text;

namespace A;

internal sealed class cad404c1fb42ece56868c101a14679d0a
{
	internal static readonly byte[] cb6d933f0fb8111c1867eda0375281699;

	static cad404c1fb42ece56868c101a14679d0a()
	{
		if (cb6d933f0fb8111c1867eda0375281699 != null)
		{
			__ldtoken(cad404c1fb42ece56868c101a14679d0a._002Ecctor());
			return;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + executingAssembly.GetName().Name);
		cb6d933f0fb8111c1867eda0375281699 = ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(manifestResourceStream);
	}

	internal static string cd2153e78b9a71234f45fec6fab6c38be(int P_0)
	{
		int num = 0;
		if ((cb6d933f0fb8111c1867eda0375281699[P_0] & 0x80) != 0)
		{
			__ldtoken(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(int));
			if ((cb6d933f0fb8111c1867eda0375281699[P_0] & 0x40) != 0)
			{
				__ldtoken(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(int));
				num = (cb6d933f0fb8111c1867eda0375281699[P_0] & -193) << 24;
				num |= cb6d933f0fb8111c1867eda0375281699[P_0 + 1] << 16;
				num |= cb6d933f0fb8111c1867eda0375281699[P_0 + 2] << 8;
				num |= cb6d933f0fb8111c1867eda0375281699[P_0 + 3];
				P_0 += 4;
			}
			else
			{
				num = (cb6d933f0fb8111c1867eda0375281699[P_0] & -129) << 8;
				num |= cb6d933f0fb8111c1867eda0375281699[P_0 + 1];
				P_0 += 2;
			}
		}
		else
		{
			num = cb6d933f0fb8111c1867eda0375281699[P_0];
			P_0++;
		}
		if (num >= 1)
		{
			__ldtoken(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(int));
			string str = Encoding.Unicode.GetString(cb6d933f0fb8111c1867eda0375281699, P_0, num);
			return string.Intern(str);
		}
		return string.Empty;
	}
}
