using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Rags;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
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
			if (object.ReferenceEquals(a, null))
			{
				ResourceManager resourceManager = new ResourceManager("Rags.Resources", typeof(Resources).Assembly);
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

	internal static Bitmap cancel
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected Obj, but got Unknown
			object obj = ResourceManager.GetObject("cancel", b);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap question
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected Obj, but got Unknown
			object obj = ResourceManager.GetObject("question", b);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap runman
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected Obj, but got Unknown
			object obj = ResourceManager.GetObject("runman", b);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap TaskHS
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected Obj, but got Unknown
			object obj = ResourceManager.GetObject("TaskHS", b);
			return (Bitmap)obj;
		}
	}

	internal Resources()
	{
	}
}
