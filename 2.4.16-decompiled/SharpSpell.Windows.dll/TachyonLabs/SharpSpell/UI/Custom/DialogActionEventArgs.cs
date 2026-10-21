using System;

namespace TachyonLabs.SharpSpell.UI.Custom;

public sealed class DialogActionEventArgs : EventArgs
{
	private int a;

	private string b;

	private bool c;

	private SuggestionCollection d;

	private DialogActionType e;

	public int Index
	{
		get
		{
			return a;
		}
		set
		{
			a = value;
		}
	}

	public string Word
	{
		get
		{
			return b;
		}
		set
		{
			b = value;
		}
	}

	public bool Finished
	{
		get
		{
			return c;
		}
		set
		{
			c = value;
		}
	}

	public SuggestionCollection Suggestions
	{
		get
		{
			return d;
		}
		set
		{
			d = value;
		}
	}

	public DialogActionType ActionType
	{
		get
		{
			return e;
		}
		set
		{
			e = value;
		}
	}

	public DialogActionEventArgs(int index, string word, DialogActionType actionType, bool finished)
	{
		a = index;
		b = word;
		e = actionType;
		c = finished;
	}

	public DialogActionEventArgs()
	{
	}
}
