using System.Reflection;
using System.Text;

namespace A;

internal sealed class cad404c1fb42ece56868c101a14679d0a
{
	internal static readonly byte[] cb6d933f0fb8111c1867eda0375281699;

	static cad404c1fb42ece56868c101a14679d0a()
	{
		if (cb6d933f0fb8111c1867eda0375281699 == null)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			cb6d933f0fb8111c1867eda0375281699 = ce351c109ec0807c6d9bdb39f449fd8b0.c7a8d5e973c17e5684fb07726c4034633(executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + executingAssembly.GetName().Name));
		}
	}

	internal static string cd2153e78b9a71234f45fec6fab6c38be(int A_0)
	{
		int num;
		if ((cb6d933f0fb8111c1867eda0375281699[A_0] & 0x80) == 0)
		{
			num = cb6d933f0fb8111c1867eda0375281699[A_0];
			A_0++;
		}
		else if ((cb6d933f0fb8111c1867eda0375281699[A_0] & 0x40) == 0)
		{
			num = (cb6d933f0fb8111c1867eda0375281699[A_0] & -129) << 8;
			num |= cb6d933f0fb8111c1867eda0375281699[A_0 + 1];
			A_0 += 2;
		}
		else
		{
			num = (cb6d933f0fb8111c1867eda0375281699[A_0] & -193) << 24;
			num |= cb6d933f0fb8111c1867eda0375281699[A_0 + 1] << 16;
			num |= cb6d933f0fb8111c1867eda0375281699[A_0 + 2] << 8;
			num |= cb6d933f0fb8111c1867eda0375281699[A_0 + 3];
			A_0 += 4;
		}
		if (num < 1)
		{
			return string.Empty;
		}
		return string.Intern(Encoding.Unicode.GetString(cb6d933f0fb8111c1867eda0375281699, A_0, num));
	}
}
