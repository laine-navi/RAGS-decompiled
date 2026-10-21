using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TachyonLabs.SharpSpell.UI;

[DefaultEvent("DisplayMenu")]
[ToolboxBitmap(typeof(SharpSpellLive))]
[Description("Implements real-time Spell As You Type spell checking for an arbitrary TextBox.")]
[DefaultProperty("TextBox")]
[LicenseProvider(typeof(SharpLicenseProvider))]
public sealed class SharpSpellLive : Component
{
	private TextBoxBase a;

	private c b;

	private int c = 1000;

	private Dictionary d;

	private bool e = true;

	private bool f = true;

	private bool g;

	private bool h;

	private LicenseInfo i;

	private DisplayMenuEventHandler j;

	[DefaultValue(true)]
	[Description("Gets or sets whether to ignore XML markup.")]
	public bool IgnoreXml
	{
		get
		{
			if (b != null)
			{
				return b.d.IgnoreXml;
			}
			return g;
		}
		set
		{
			g = value;
			if (b != null)
			{
				b.d.IgnoreXml = value;
			}
		}
	}

	[DefaultValue(false)]
	[Description("Gets or sets whether to keep the current selection when a user right clicks on the textbox.")]
	public bool KeepSelection
	{
		get
		{
			if (b != null)
			{
				return b.k;
			}
			return h;
		}
		set
		{
			h = value;
			if (b != null)
			{
				b.k = value;
			}
		}
	}

	[DefaultValue(true)]
	[Description("Enables spell-as-you-type.")]
	public bool Enabled
	{
		get
		{
			return f;
		}
		set
		{
			if (!DesignMode && b != null)
			{
				if (f)
				{
					b.b();
				}
				else
				{
					b.d();
				}
			}
			f = value;
		}
	}

	[Description("Sets the text box to be spell checked")]
	public TextBoxBase TextBox
	{
		get
		{
			return a;
		}
		set
		{
			if (value == null)
			{
				if (b != null)
				{
					b.d();
					b.a();
					b = null;
				}
				a = null;
				return;
			}
			a = value;
			if (!DesignMode)
			{
				if (b != null)
				{
					b.d();
					b.a();
					b = null;
				}
				if (e && d == null)
				{
					d = Dictionary.EnglishUS;
				}
				b = new c(this, a, d, c);
				b.b(j);
				b.d.IgnoreXml = g;
				b.k = h;
				if (f)
				{
					b.b();
				}
				((Control)a).Refresh();
			}
		}
	}

	[Description("Specifies the dictionary to be used. Default is English (United States). Can only be set through code.")]
	public Dictionary Dictionary => d;

	[Description("Sets whether to use the default English (United States) dictionary. If you set this to false, you must specify a dictionary.")]
	[DefaultValue(true)]
	public bool UseDefaultDictionary
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

	[DefaultValue(1000)]
	[Description("Represents the number of words to be considered when looking for suggestions")]
	public int SuggestRange
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

	private event DisplayMenuEventHandler displayMenu
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			j = (DisplayMenuEventHandler)Delegate.Combine(j, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			j = (DisplayMenuEventHandler)Delegate.Remove(j, value);
		}
	}

	public event DisplayMenuEventHandler DisplayMenu
	{
		add
		{
			j = (DisplayMenuEventHandler)Delegate.Combine(j, value);
			if (b != null)
			{
				b.b(value);
			}
		}
		remove
		{
			j = (DisplayMenuEventHandler)Delegate.Remove(j, value);
			if (b != null)
			{
				b.a(value);
			}
		}
	}

	public void SetDictionary(Dictionary dictionary)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		d = dictionary;
		TextBox = TextBox;
	}

	public SharpSpellLive()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		i = (LicenseInfo)LicenseManager.Validate(typeof(SharpSpellLive), this);
		if (!i.IsTrial && (int)i.LicenseType == 0 && LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime && !i.LicensedDevelopers.Contains(Environment.MachineName.ToLowerInvariant()))
		{
			throw new LicenseException(typeof(SharpSpellLive), this, "Could not find a valid license for: " + Environment.MachineName);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (i != null)
		{
			((License)(object)i).Dispose();
			i = null;
		}
		base.Dispose(disposing);
	}
}
