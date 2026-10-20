using System.Runtime.CompilerServices;

namespace WPFRagsDesigner;

public class SearchResult
{
	public object internalobject;

	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	public string Type
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

	public string Name
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

	public string Data
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

	public SearchResult(string _type, string _name, string _data, object intdata)
	{
		Type = _type;
		Name = _name;
		Data = _data;
		internalobject = intdata;
	}
}
