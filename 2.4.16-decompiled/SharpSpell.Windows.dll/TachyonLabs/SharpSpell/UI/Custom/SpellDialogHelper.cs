using System.Collections.Specialized;

namespace TachyonLabs.SharpSpell.UI.Custom;

public sealed class SpellDialogHelper
{
	private StringCollection m_a;

	private StringDictionary b;

	private Dictionary c;

	private TextSpeller d;

	private ISpellDialog e;

	public int SuggestRange
	{
		get
		{
			return d.SuggestRange;
		}
		set
		{
			d.SuggestRange = value;
		}
	}

	public Dictionary Dictionary => c;

	public SpellDialogHelper(ISpellDialog spellDialog, Dictionary dictionary)
		: this(spellDialog, dictionary, 1000)
	{
	}

	public SpellDialogHelper(ISpellDialog spellDialog, Dictionary dictionary, int suggestRange)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		c = dictionary;
		d = new TextSpeller(dictionary);
		d.SuggestRange = suggestRange;
		e = spellDialog;
		this.m_a = new StringCollection();
		b = new StringDictionary();
	}

	private void a(object A_0, WordMisspelledEventArgs A_1)
	{
		if (this.m_a.Contains(A_1.Word))
		{
			return;
		}
		DialogActionEventArgs e;
		if (!A_1.Finished && b.ContainsKey(A_1.Word))
		{
			e = new DialogActionEventArgs(A_1.Index, b[A_1.Word], DialogActionType.Change, finished: false);
		}
		else
		{
			e = new DialogActionEventArgs(A_1.Index, A_1.Word, DialogActionType.None, finished: false);
			e.Suggestions = A_1.Suggestions;
			e.Finished = A_1.Finished;
			this.e.OnMisspelledWord(this, e);
		}
		if (!A_1.Finished)
		{
			string text = this.e.GetText();
			switch (e.ActionType)
			{
			case DialogActionType.Change:
				A_1.ReplacementWord = e.Word;
				this.e.SetText(text.Substring(0, A_1.Index) + A_1.ReplacementWord + text.Substring(A_1.Index + A_1.Word.Length));
				this.e.OnSpellAction(this, new SpellActionEventArgs(A_1.Index, A_1.Word, A_1.ReplacementWord, SpellActionEventType.Change));
				break;
			case DialogActionType.ChangeAll:
				b.Add(A_1.Word, e.Word);
				A_1.ReplacementWord = e.Word;
				this.e.SetText(text.Substring(0, A_1.Index) + A_1.ReplacementWord + text.Substring(A_1.Index + A_1.Word.Length));
				this.e.OnSpellAction(this, new SpellActionEventArgs(A_1.Index, A_1.Word, A_1.ReplacementWord, SpellActionEventType.Change));
				break;
			case DialogActionType.IgnoreAll:
				this.m_a.Add(A_1.Word);
				break;
			case DialogActionType.AddToDictionary:
				c.CustomWordlist.Add(A_1.Word);
				break;
			case DialogActionType.Cancel:
				A_1.Cancel = true;
				break;
			case DialogActionType.Ignore:
				break;
			}
		}
	}

	public void Check()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		d.CheckSpelling(e.GetText(), 0, true, (WordMisspelledCallback)a, true);
	}
}
