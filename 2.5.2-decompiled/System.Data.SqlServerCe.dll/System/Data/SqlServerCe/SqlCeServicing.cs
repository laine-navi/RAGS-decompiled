using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace System.Data.SqlServerCe;

internal sealed class SqlCeServicing
{
	internal static void DoBreadcrumbServicing(string modulePath)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			if (string.IsNullOrEmpty(folderPath))
			{
				return;
			}
			string path = Path.Combine(folderPath, string.Format(CultureInfo.InvariantCulture, "Microsoft.SqlServer.Compact.351.{0}.bc", new object[1] { (4 == IntPtr.Size) ? "32" : "64" }));
			stringBuilder.Append("<Breadcrumb>");
			stringBuilder.Append(modulePath).Append(", ");
			stringBuilder.Append("3.5.8080.0").Append(", ");
			stringBuilder.Append(Process.GetCurrentProcess().MainModule.ModuleName);
			stringBuilder.Append("</Breadcrumb>");
			string text = stringBuilder.ToString();
			if (!File.Exists(path))
			{
				using (File.Create(path))
				{
				}
			}
			string[] array = File.ReadAllLines(path, Encoding.UTF8);
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (!string.IsNullOrEmpty(array[num]) && string.Compare(array[num], text, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					return;
				}
			}
			string[] array2 = new string[(array.Length >= 32) ? 32 : (array.Length + 1)];
			int num2 = 0;
			int num3 = ((array.Length >= 32) ? 1 : 0);
			while (num3 < array.Length && num2 < array2.Length)
			{
				array2[num2] = array[num3];
				num3++;
				num2++;
			}
			array2[^1] = text;
			File.WriteAllLines(path, array2, Encoding.UTF8);
		}
		catch
		{
		}
	}
}
