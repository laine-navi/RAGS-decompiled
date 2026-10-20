using System.Runtime.CompilerServices;

namespace Rags;

public class CustomProperty
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

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

	public string Value
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

	public CustomProperty()
	{
		Name = string.Empty;
		Value = string.Empty;
	}

	public CustomProperty(string name, string val)
	{
		Name = name;
		Value = val;
	}
}
