using System;

namespace TachyonLabs.SharpSpell.UI;

public class SpellActionEventArgs : EventArgs
{
	private int a;

	private string b;

	private string c;

	private SpellActionEventType d;

	public int Index => a;

	public string WordBefore => b;

	public string WordAfter => c;

	public SpellActionEventType EventType => d;

	public SpellActionEventArgs(int index, string wordBefore, string wordAfter, SpellActionEventType eventType)
	{
		a = index;
		b = wordBefore;
		c = wordAfter;
		d = eventType;
	}
}
