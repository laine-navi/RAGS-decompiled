using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class StatusBarItem
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private bool c;

	[CompilerGenerated]
	private int d;

	public string Name
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

	public string Text
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

	public bool bVisisble
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

	public int Width
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

	public StatusBarItem()
	{
		Name = string.Empty;
		Text = string.Empty;
		bVisisble = true;
		Width = 0;
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append("\"" + Name + "\",");
		stringBuilder.Append("\"" + Text + "\",");
		stringBuilder.Append(bVisisble.ToString().ToLower() + ",");
		stringBuilder.Append(Width.ToString());
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
