using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class GamePicture
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private byte[] c;

	[CompilerGenerated]
	private List<string> d;

	[CompilerGenerated]
	private List<object> e;

	[CompilerGenerated]
	private EnhancedInputData f;

	public string TheName
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	public string GroupName
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

	public byte[] ImageData
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

	public List<string> LayeredImages
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

	public List<object> Choices
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

	public EnhancedInputData enhinputdata
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

	public GamePicture(string name, string imagepath)
	{
		TheName = name;
		GroupName = string.Empty;
		LayeredImages = new List<string>();
		Choices = new List<object>();
		enhinputdata = new EnhancedInputData();
	}

	public GamePicture()
	{
		TheName = string.Empty;
		GroupName = string.Empty;
		LayeredImages = new List<string>();
		Choices = new List<object>();
		enhinputdata = new EnhancedInputData();
	}

	public override string ToString()
	{
		return TheName;
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + TheName + "\",");
		A_.Append("\"" + GroupName + "\",");
		string text = string.Empty;
		int num = 0;
		foreach (string layeredImage in LayeredImages)
		{
			if (num > 0)
			{
				text += ":";
			}
			text += layeredImage;
		}
		A_.Append("[\"" + text + "\"],");
		enhinputdata.a(ref A_);
		A_.Append("]");
		return A_.ToString();
	}
}
