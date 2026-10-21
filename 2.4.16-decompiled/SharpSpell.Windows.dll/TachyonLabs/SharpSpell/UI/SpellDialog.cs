using System;
using System.Windows.Forms;
using TachyonLabs.SharpSpell.UI.Custom;

namespace TachyonLabs.SharpSpell.UI;

public sealed class SpellDialog : IDisposable
{
	internal ISpellDialog a;

	public bool AllowCompleteDialog
	{
		get
		{
			return a.AllowCompleteDialog;
		}
		set
		{
			a.AllowCompleteDialog = value;
		}
	}

	public string Text => a.GetText();

	public int SuggestRange
	{
		get
		{
			return a.SuggestRange;
		}
		set
		{
			a.SuggestRange = value;
		}
	}

	public event SpellActionEventHandler SpellAction
	{
		add
		{
			a.SpellAction += value;
		}
		remove
		{
			a.SpellAction -= value;
		}
	}

	public SpellDialog(Dictionary dictionary)
	{
		a = new e();
		a.SetDictionary(dictionary);
	}

	public SpellDialog(ISpellDialog spellDialog, Dictionary dictionary)
	{
		if (spellDialog == null)
		{
			throw new ArgumentNullException("spellDialog");
		}
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		a = spellDialog;
		a.SetDictionary(dictionary);
	}

	public string Show(string textToCheck)
	{
		return a.Show(textToCheck);
	}

	public void Show(TextBoxBase textBox)
	{
		a.Show(textBox);
	}

	public void Show(TextBoxBase textBox, bool asModal)
	{
		a.Show(textBox, asModal);
	}

	public void Dispose()
	{
		a.Dispose();
	}
}
