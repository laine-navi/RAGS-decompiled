using System.Runtime.CompilerServices;
using Rags;

namespace RAGSWPFPlayer;

public class VariableData
{
	public GameVariable TheVar;

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

	public VariableData(string name, string val, GameVariable thevar)
	{
		Name = name;
		Value = val;
		TheVar = thevar;
	}
}
