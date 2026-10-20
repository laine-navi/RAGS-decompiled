using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Rags;

public class SaveGamePicture
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private List<string> c;

	[CompilerGenerated]
	private List<object> d;

	[CompilerGenerated]
	private EnhancedInputData e;

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

	public List<string> LayeredImages
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

	public List<object> Choices
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

	public EnhancedInputData enhinputdata
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

	public SaveGamePicture(GamePicture temp)
	{
		TheName = temp.TheName;
		GroupName = temp.GroupName;
		LayeredImages = temp.LayeredImages;
		Choices = temp.Choices;
		enhinputdata = temp.enhinputdata;
	}

	public SaveGamePicture()
	{
		TheName = string.Empty;
		GroupName = string.Empty;
		LayeredImages = new List<string>();
		Choices = new List<object>();
		enhinputdata = new EnhancedInputData();
	}

	public void SetData(ref GamePicture temp)
	{
		temp.TheName = TheName;
		temp.GroupName = GroupName;
		temp.LayeredImages = LayeredImages;
		temp.Choices = Choices;
		temp.enhinputdata = enhinputdata;
	}
}
