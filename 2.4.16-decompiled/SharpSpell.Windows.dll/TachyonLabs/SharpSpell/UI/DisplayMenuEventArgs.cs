using System;
using System.Drawing;

namespace TachyonLabs.SharpSpell.UI;

public class DisplayMenuEventArgs : EventArgs
{
	private Misspelling a;

	private Dictionary b;

	private Point c;

	public Misspelling Word => a;

	public Dictionary Dictionary => b;

	public Point MousePosition => c;

	public DisplayMenuEventArgs(Misspelling word, Dictionary dictionary, Point mousePosition)
	{
		a = word;
		b = dictionary;
		c = mousePosition;
	}
}
