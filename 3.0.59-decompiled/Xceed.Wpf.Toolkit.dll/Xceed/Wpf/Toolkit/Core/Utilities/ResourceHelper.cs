using System.IO;
using System.Reflection;
using System.Resources;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class ResourceHelper
{
	internal static Stream LoadResourceStream(Assembly assembly, string resId)
	{
		string baseName = Path.GetFileNameWithoutExtension(assembly.ManifestModule.Name) + ".g";
		ResourceManager resourceManager = new ResourceManager(baseName, assembly);
		resId = resId.ToLower();
		resId = resId.Replace('\\', '/');
		return resourceManager.GetObject(resId) as Stream;
	}
}
