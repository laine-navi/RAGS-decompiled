using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WPFRagsLib.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
	private static ResourceManager a;

	private static CultureInfo b;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (a == null)
			{
				ResourceManager resourceManager = new ResourceManager("WPFRagsLib.Properties.Resources", typeof(Resources).Assembly);
				a = resourceManager;
			}
			return a;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return b;
		}
		set
		{
			b = value;
		}
	}

	internal Resources()
	{
	}
}
