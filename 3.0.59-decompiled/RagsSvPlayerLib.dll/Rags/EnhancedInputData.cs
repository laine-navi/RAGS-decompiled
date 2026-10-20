using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class EnhancedInputData
{
	[CompilerGenerated]
	private string m_a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private bool e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private bool g;

	public string BackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return this.m_a;
		}
		[CompilerGenerated]
		set
		{
			this.m_a = value;
		}
	}

	public string TextColor
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	public string TextFont
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	public string Imagename
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	public bool bUseEnhancedGraphics
	{
		[CompilerGenerated]
		get
		{
			return e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	public string NewImage
	{
		[CompilerGenerated]
		get
		{
			return f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	public bool bAllowCancel
	{
		[CompilerGenerated]
		get
		{
			return g;
		}
		[CompilerGenerated]
		set
		{
			g = value;
		}
	}

	public EnhancedInputData()
	{
		Imagename = string.Empty;
		bUseEnhancedGraphics = true;
		NewImage = string.Empty;
		bAllowCancel = true;
	}

	internal void a(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"" + Imagename + "\",");
		A_0.Append(bUseEnhancedGraphics.ToString().ToLower() + ",");
		A_0.Append(bAllowCancel.ToString().ToLower() + ",");
		A_0.Append("\"" + NewImage + "\"");
		A_0.Append("]");
	}
}
