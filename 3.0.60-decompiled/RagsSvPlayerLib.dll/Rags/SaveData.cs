using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Rags;

public class SaveData
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private List<Room> c;

	[CompilerGenerated]
	private Player d;

	[CompilerGenerated]
	private List<GameObject> e;

	[CompilerGenerated]
	private List<GameVariable> f;

	[CompilerGenerated]
	private List<Character> g;

	[CompilerGenerated]
	private List<Timer> h;

	[CompilerGenerated]
	private List<StatusBarItem> i;

	[CompilerGenerated]
	private List<SaveGamePicture> j;

	public string versionnumber
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

	public string originalfilename
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

	public List<Room> RoomList
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

	public Player ThePlayer
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

	public List<GameObject> ObjectList
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

	public List<GameVariable> VariableList
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

	public List<Character> CharacterList
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

	public List<Timer> TimerList
	{
		[CompilerGenerated]
		get
		{
			return h;
		}
		[CompilerGenerated]
		set
		{
			h = value;
		}
	}

	public List<StatusBarItem> StatusBarList
	{
		[CompilerGenerated]
		get
		{
			return i;
		}
		[CompilerGenerated]
		set
		{
			i = value;
		}
	}

	public List<SaveGamePicture> SaveGamePictureList
	{
		[CompilerGenerated]
		get
		{
			return j;
		}
		[CompilerGenerated]
		set
		{
			j = value;
		}
	}

	public SaveData()
	{
		SaveGamePictureList = new List<SaveGamePicture>();
	}
}
