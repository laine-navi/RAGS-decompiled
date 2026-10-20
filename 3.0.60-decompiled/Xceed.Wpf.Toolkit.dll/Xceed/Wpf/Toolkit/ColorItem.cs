using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class ColorItem
{
	public Color Color
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return field;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			field = value;
		}
	}

	public string Name { get; set; }

	public ColorItem(Color color, string name)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Color = color;
		Name = name;
	}

	public override bool Equals(object obj)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (!(obj is ColorItem { Color: var color } colorItem))
		{
			return false;
		}
		if (color.Equals(Color))
		{
			return colorItem.Name.Equals(Name);
		}
		return false;
	}

	public override int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color/*cast due to constrained. prefix*/).GetHashCode() ^ Name.GetHashCode();
	}
}
