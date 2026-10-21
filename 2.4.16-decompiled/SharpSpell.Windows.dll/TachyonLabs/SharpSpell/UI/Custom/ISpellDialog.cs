using System;
using System.Windows.Forms;

namespace TachyonLabs.SharpSpell.UI.Custom;

public interface ISpellDialog : IDisposable
{
	int SuggestRange { get; set; }

	bool InProgress { get; }

	bool IsDirty { get; }

	bool AllowCompleteDialog { get; set; }

	event SpellActionEventHandler SpellAction;

	void SetDictionary(Dictionary dictionary);

	void SetText(string textToCheck);

	string GetText();

	void SetDirty(bool value);

	void Show();

	string Show(string textToCheck);

	void Show(TextBoxBase textBox);

	void Show(TextBoxBase textBox, bool asDialog);

	void OnMisspelledWord(object sender, DialogActionEventArgs e);

	void OnSpellAction(object sender, SpellActionEventArgs e);
}
