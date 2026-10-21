using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using TachyonLabs.SharpSpell;
using TachyonLabs.SharpSpell.UI;
using TachyonLabs.SharpSpell.UI.Custom;

[LicenseProvider(typeof(SharpLicenseProvider))]
internal class e : Form, ISpellDialog
{
	private SpellActionEventHandler m_a;

	private SpellDialogHelper m_b;

	private DialogActionEventArgs m_c;

	private TextBoxBase m_d;

	private bool m_e;

	private bool m_f;

	private bool m_g;

	private string m_h;

	private ManualResetEvent m_i = new ManualResetEvent(initialState: false);

	private LicenseInfo j;

	private RichTextBox k;

	private Button l;

	private Button m;

	private Button n;

	private Label o;

	private Label p;

	private Button q;

	private Button r;

	private ComboBox s;

	private Button t;

	private LinkLabel u;

	private Button v;

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	public void a(SpellActionEventHandler A_0)
	{
		this.m_a = (SpellActionEventHandler)Delegate.Combine(this.m_a, A_0);
	}

	void ISpellDialog.add_SpellAction(SpellActionEventHandler A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	public void b(SpellActionEventHandler A_0)
	{
		this.m_a = (SpellActionEventHandler)Delegate.Remove(this.m_a, A_0);
	}

	void ISpellDialog.remove_SpellAction(SpellActionEventHandler A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in b
		this.b(A_0);
	}

	public e()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		j = (LicenseInfo)LicenseManager.Validate(typeof(e), this);
		Control.CheckForIllegalCrossThreadCalls = false;
		a();
	}

	protected override void c(bool A_0)
	{
		if (j != null)
		{
			((License)(object)j).Dispose();
			j = null;
		}
		((Form)this).Dispose(A_0);
	}

	private void a()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(e));
		k = new RichTextBox();
		l = new Button();
		m = new Button();
		n = new Button();
		o = new Label();
		p = new Label();
		q = new Button();
		r = new Button();
		t = new Button();
		s = new ComboBox();
		u = new LinkLabel();
		v = new Button();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(k, "originalText");
		((Control)k).BackColor = SystemColors.Window;
		k.DetectUrls = false;
		((Control)k).Name = "originalText";
		((TextBoxBase)k).ReadOnly = true;
		componentResourceManager.ApplyResources(l, "IgnoreOnce");
		((Control)l).Name = "IgnoreOnce";
		((Control)l).Click += h;
		componentResourceManager.ApplyResources(m, "IgnoreAll");
		((Control)m).Name = "IgnoreAll";
		((Control)m).Click += e;
		componentResourceManager.ApplyResources(n, "AddToDictionary");
		((Control)n).Name = "AddToDictionary";
		((Control)n).Click += g;
		componentResourceManager.ApplyResources(o, "label1");
		((Control)o).Name = "label1";
		componentResourceManager.ApplyResources(p, "label2");
		((Control)p).Name = "label2";
		componentResourceManager.ApplyResources(q, "ChangeAll");
		((Control)q).Name = "ChangeAll";
		((Control)q).Click += c;
		componentResourceManager.ApplyResources(r, "Change");
		((Control)r).Name = "Change";
		((Control)r).Click += f;
		componentResourceManager.ApplyResources(t, "CloseDialog");
		t.DialogResult = (DialogResult)2;
		((Control)t).Name = "CloseDialog";
		((Control)t).Click += d;
		componentResourceManager.ApplyResources(s, "suggestionList");
		s.DropDownStyle = (ComboBoxStyle)0;
		((Control)s).Name = "suggestionList";
		componentResourceManager.ApplyResources(u, "Register");
		((Control)u).Name = "Register";
		((Label)u).TabStop = true;
		u.LinkClicked += a;
		componentResourceManager.ApplyResources(v, "Resume");
		((Control)v).Name = "Resume";
		((Control)v).Click += a;
		((Form)this).AcceptButton = (IButtonControl)(object)r;
		componentResourceManager.ApplyResources(this, "$this");
		((Form)this).CancelButton = (IButtonControl)(object)t;
		((Control)this).Controls.Add((Control)(object)v);
		((Control)this).Controls.Add((Control)(object)u);
		((Control)this).Controls.Add((Control)(object)s);
		((Control)this).Controls.Add((Control)(object)t);
		((Control)this).Controls.Add((Control)(object)p);
		((Control)this).Controls.Add((Control)(object)q);
		((Control)this).Controls.Add((Control)(object)r);
		((Control)this).Controls.Add((Control)(object)o);
		((Control)this).Controls.Add((Control)(object)n);
		((Control)this).Controls.Add((Control)(object)m);
		((Control)this).Controls.Add((Control)(object)l);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Name = "DefaultSpellCheckDialog";
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).Closing += a;
		((Form)this).Load += i;
		((Control)this).ResumeLayout(false);
	}

	private void i(object A_0, EventArgs A_1)
	{
		this.m_b.Check();
		((Control)u).Visible = j.IsTrial;
	}

	private void a(int A_0, int A_1)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		Control activeControl = ((ContainerControl)this).ActiveControl;
		((TextBoxBase)k).Select(A_0, A_1);
		k.SelectionColor = Color.Red;
		k.SelectionFont = new Font(k.SelectionFont, (FontStyle)2);
		((TextBoxBase)k).Select(A_0, 0);
		((Control)k).Update();
		((Control)k).Select();
		((TextBoxBase)k).ScrollToCaret();
		((ContainerControl)this).ActiveControl = activeControl;
	}

	private void h(object A_0, EventArgs A_1)
	{
		this.m_c.ActionType = DialogActionType.Ignore;
		this.m_i.Set();
	}

	private void g(object A_0, EventArgs A_1)
	{
		this.m_c.ActionType = DialogActionType.AddToDictionary;
		this.m_i.Set();
	}

	private void f(object A_0, EventArgs A_1)
	{
		this.m_c.Word = ((Control)s).Text;
		this.m_c.ActionType = DialogActionType.Change;
		this.m_i.Set();
	}

	private void e(object A_0, EventArgs A_1)
	{
		this.m_c.ActionType = DialogActionType.IgnoreAll;
		this.m_i.Set();
	}

	private void d(object A_0, EventArgs A_1)
	{
		if (this.m_a != null)
		{
			this.m_a(this.m_b, new SpellActionEventArgs(0, "", "", SpellActionEventType.Cancel));
		}
		this.m_c.ActionType = DialogActionType.Cancel;
		this.m_i.Set();
		((Control)this).Hide();
	}

	private void c(object A_0, EventArgs A_1)
	{
		this.m_c.ActionType = DialogActionType.ChangeAll;
		this.m_c.Word = ((Control)s).Text;
		this.m_i.Set();
	}

	private void a(object A_0, LinkLabelLinkClickedEventArgs A_1)
	{
		Process.Start("http://www.tachyon-labs.com/sharpspell/");
	}

	[SpecialName]
	public int d()
	{
		return this.m_b.SuggestRange;
	}

	int ISpellDialog.get_SuggestRange()
	{
		//ILSpy generated this explicit interface implementation from .override directive in d
		return this.d();
	}

	[SpecialName]
	public void a(int A_0)
	{
		if (A_0 < 0)
		{
			throw new ArgumentOutOfRangeException("value", "Value cannot be less than 0.");
		}
		this.m_b.SuggestRange = A_0;
	}

	void ISpellDialog.set_SuggestRange(int A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	[SpecialName]
	public bool f()
	{
		return ((Control)this).Visible;
	}

	bool ISpellDialog.get_InProgress()
	{
		//ILSpy generated this explicit interface implementation from .override directive in f
		return this.f();
	}

	public string b()
	{
		return this.m_h;
	}

	string ISpellDialog.GetText()
	{
		//ILSpy generated this explicit interface implementation from .override directive in b
		return this.b();
	}

	public void a(string A_0)
	{
		((Control)k).Text = A_0;
		this.m_h = A_0;
	}

	void ISpellDialog.SetText(string A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	[SpecialName]
	public bool c()
	{
		return this.m_e;
	}

	bool ISpellDialog.get_IsDirty()
	{
		//ILSpy generated this explicit interface implementation from .override directive in c
		return this.c();
	}

	[SpecialName]
	public bool g()
	{
		return this.m_g;
	}

	bool ISpellDialog.get_AllowCompleteDialog()
	{
		//ILSpy generated this explicit interface implementation from .override directive in g
		return this.g();
	}

	[SpecialName]
	public void a(bool A_0)
	{
		this.m_g = A_0;
	}

	void ISpellDialog.set_AllowCompleteDialog(bool A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	public void b(bool A_0)
	{
		this.m_e = A_0;
		if (A_0)
		{
			((Control)v).Visible = true;
			((Control)l).Enabled = false;
			((Control)m).Enabled = false;
			((Control)n).Enabled = false;
			((Control)r).Enabled = false;
			((Control)q).Enabled = false;
		}
		else
		{
			((Control)v).Visible = false;
			((Control)l).Enabled = true;
			((Control)m).Enabled = true;
			((Control)n).Enabled = true;
			((Control)r).Enabled = true;
			((Control)q).Enabled = true;
		}
	}

	void ISpellDialog.SetDirty(bool A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in b
		this.b(A_0);
	}

	public string b(string A_0)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		a(A_0);
		((Form)this).ShowDialog();
		return b();
	}

	string ISpellDialog.Show(string A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in b
		return this.b(A_0);
	}

	public void e()
	{
		((Control)this).Show();
	}

	void ISpellDialog.Show()
	{
		//ILSpy generated this explicit interface implementation from .override directive in e
		this.e();
	}

	public void a(TextBoxBase A_0)
	{
		a(((Control)A_0).Text);
		this.m_d = A_0;
		((Control)A_0).TextChanged += b;
		this.m_a = (SpellActionEventHandler)Delegate.Combine(this.m_a, new SpellActionEventHandler(a));
		e();
	}

	void ISpellDialog.Show(TextBoxBase A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	public void a(TextBoxBase A_0, bool A_1)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		a(((Control)A_0).Text);
		this.m_d = A_0;
		((Control)A_0).TextChanged += b;
		this.m_a = (SpellActionEventHandler)Delegate.Combine(this.m_a, new SpellActionEventHandler(a));
		if (A_1)
		{
			((Form)this).ShowDialog();
		}
		else
		{
			e();
		}
	}

	void ISpellDialog.Show(TextBoxBase A_0, bool A_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0, A_1);
	}

	public void a(Dictionary A_0)
	{
		this.m_b = new SpellDialogHelper(this, A_0);
	}

	void ISpellDialog.SetDictionary(Dictionary A_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0);
	}

	public void a(object A_0, DialogActionEventArgs A_1)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		this.m_c = A_1;
		if (A_1.Finished)
		{
			if (g())
			{
				MessageBox.Show((IWin32Window)(object)this, "Spell-check finished.", "Spell Checker", (MessageBoxButtons)0, (MessageBoxIcon)64);
			}
			if (this.m_a != null)
			{
				this.m_a(this.m_b, new SpellActionEventArgs(0, "", "", SpellActionEventType.Complete));
			}
			((Control)this).Hide();
			return;
		}
		((TextBoxBase)k).SelectAll();
		k.SelectionColor = SystemColors.WindowText;
		k.SelectionFont = new Font(k.SelectionFont, (FontStyle)0);
		((TextBoxBase)k).Select(0, 0);
		a(A_1.Index, A_1.Word.Length);
		if (this.m_a != null)
		{
			this.m_a(this.m_b, new SpellActionEventArgs(A_1.Index, A_1.Word, "", SpellActionEventType.Select));
		}
		s.Items.Clear();
		foreach (Suggestion suggestion in A_1.Suggestions)
		{
			Suggestion val = suggestion;
			s.Items.Add((object)val.Value);
		}
		if (A_1.Suggestions.Count > 0)
		{
			((ListControl)s).SelectedIndex = 0;
			ComboBox val2 = s;
			Suggestion val3 = A_1.Suggestions[0];
			((Control)val2).Text = val3.Value;
		}
		((Control)this).Enabled = true;
		this.m_i.WaitOne();
		this.m_i.Reset();
		((Control)this).Enabled = false;
	}

	void ISpellDialog.OnMisspelledWord(object A_0, DialogActionEventArgs A_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a(A_0, A_1);
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (!this.m_f)
		{
			b(A_0: true);
		}
	}

	private void a(object A_0, SpellActionEventArgs A_1)
	{
		switch (A_1.EventType)
		{
		case SpellActionEventType.Change:
			this.m_d.Select(A_1.Index, A_1.WordBefore.Length);
			this.m_f = true;
			this.m_d.SelectedText = A_1.WordAfter;
			this.m_f = false;
			break;
		case SpellActionEventType.Select:
			this.m_d.Select(A_1.Index, A_1.WordBefore.Length);
			break;
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		a(((Control)this.m_d).Text);
		b(A_0: false);
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
		A_1.Cancel = true;
		t.PerformClick();
	}

	public void b(object A_0, SpellActionEventArgs A_1)
	{
		if (this.m_a != null)
		{
			this.m_a(A_0, A_1);
		}
	}

	void ISpellDialog.OnSpellAction(object A_0, SpellActionEventArgs A_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in b
		this.b(A_0, A_1);
	}
}
