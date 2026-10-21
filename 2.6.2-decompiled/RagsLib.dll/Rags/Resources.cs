using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Rags;

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
				a = new ResourceManager("Rags.Resources", typeof(Resources).Assembly);
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

	internal static Bitmap cancel
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected Obj, but got Unknown
			return (Bitmap)ResourceManager.GetObject("cancel", b);
		}
	}

	internal static Bitmap question
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected Obj, but got Unknown
			return (Bitmap)ResourceManager.GetObject("question", b);
		}
	}

	internal static Bitmap runman
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected Obj, but got Unknown
			return (Bitmap)ResourceManager.GetObject("runman", b);
		}
	}

	internal static Bitmap TaskHS
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected Obj, but got Unknown
			return (Bitmap)ResourceManager.GetObject("TaskHS", b);
		}
	}

	internal Resources()
	{
	}
}
