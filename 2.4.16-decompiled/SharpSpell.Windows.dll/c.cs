using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TachyonLabs.SharpSpell;
using TachyonLabs.SharpSpell.UI;

internal class c : IDisposable
{
	private SharpSpellLive m_a;

	private DisplayMenuEventHandler m_b;

	private Bitmap m_c;

	internal TextSpeller d;

	private Graphics e;

	private Graphics f;

	private b g;

	private MisspellingCollection h;

	private Misspelling i;

	private Dictionary j;

	internal bool k;

	internal TextBoxBase l;

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	public void b(DisplayMenuEventHandler A_0)
	{
		this.m_b = (DisplayMenuEventHandler)Delegate.Combine(this.m_b, A_0);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	public void a(DisplayMenuEventHandler A_0)
	{
		this.m_b = (DisplayMenuEventHandler)Delegate.Remove(this.m_b, A_0);
	}

	public c(SharpSpellLive A_0, TextBoxBase A_1, Dictionary A_2, int A_3)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		this.m_a = A_0;
		if (A_1 == null)
		{
			throw new ArgumentNullException("textBox", "Cannot initialize to a null TextBox.");
		}
		l = A_1;
		j = A_2;
		this.m_c = new Bitmap(((Control)A_1).Width, ((Control)A_1).Height);
		f = Graphics.FromImage((Image)(object)this.m_c);
		f.Clip = new Region(((Control)A_1).ClientRectangle);
		e = Graphics.FromHwnd(((Control)A_1).Handle);
		this.d = new TextSpeller(j);
		this.d.SuggestRange = A_3;
		g = new b(this);
	}

	public void b()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		d();
		((Control)l).MouseDown += b;
		((Control)l).SizeChanged += a;
		((Control)l).MouseUp += a;
		((Control)l).KeyUp += a;
		((NativeWindow)g).AssignHandle(((Control)l).Handle);
	}

	public void d()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		((Control)l).MouseDown -= b;
		((Control)l).SizeChanged -= a;
		((Control)l).MouseUp -= a;
		((Control)l).KeyUp -= a;
		((NativeWindow)g).ReleaseHandle();
		((Control)l).Refresh();
	}

	internal void c()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		int num = 1;
		int a_ = global::a.a(l);
		a_ = global::a.a(l, a_);
		f.Clear(Color.Transparent);
		h = this.d.CheckSpelling(((Control)l).Text, a_, false);
		foreach (Misspelling item in h)
		{
			Misspelling val = item;
			Point a_2 = global::a.b(l, val.Index);
			Point a_3 = global::a.b(l, val.Index + val.Value.Length);
			if (a_3.X == -1 && a_3.Y == -1)
			{
				a_3 = global::a.b(l, val.Index + val.Value.Length - 1);
			}
			a_3.X++;
			a_2.Y += global::a.c(l, val.Index);
			a_3.Y += global::a.c(l, val.Index + val.Value.Length);
			a_2.Y -= num;
			a_3.Y -= num;
			if (a_2.Y > ((Control)l).Height)
			{
				continue;
			}
			if (a_2.Y != a_3.Y)
			{
				bool flag = false;
				int num2 = val.Index;
				while (!flag)
				{
					int num3 = 0;
					for (int i = num2; i < val.Index + val.Value.Length; i++)
					{
						Point point = global::a.b(l, i);
						point.Y += global::a.c(l, i) - num;
						if (point.Y != a_2.Y)
						{
							num3 = i - 1;
							break;
						}
					}
					if (num3 == 0)
					{
						num3 = val.Index + val.Value.Length;
						flag = true;
					}
					a_3 = global::a.b(l, num3);
					a_3.Y += global::a.c(l, num3) - num;
					a(a_2, a_3);
					num2 = num3 + 1;
					a_2 = global::a.b(l, num2);
					a_2.Y += global::a.c(l, num2) - num;
				}
			}
			else
			{
				a(a_2, a_3);
			}
		}
		e.DrawImageUnscaled((Image)(object)this.m_c, 0, 0);
	}

	private void a(Point A_0, Point A_1)
	{
		Pen red = Pens.Red;
		if (A_1.X - A_0.X > 4)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = A_0.X; i <= A_1.X - 2; i += 4)
			{
				arrayList.Add(new Point(i, A_0.Y));
				arrayList.Add(new Point(i + 2, A_0.Y + 2));
			}
			Point[] array = (Point[])arrayList.ToArray(typeof(Point));
			f.DrawLines(red, array);
		}
		else
		{
			f.DrawLine(red, A_0, A_1);
		}
	}

	private void b(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button != 2097152 || (!(l is RichTextBox) && !(l is TextBox)))
		{
			return;
		}
		Point point = new Point(A_1.X, A_1.Y);
		int num;
		if (l is RichTextBox)
		{
			RichTextBox val = (RichTextBox)l;
			num = ((TextBoxBase)val).GetCharIndexFromPosition(point);
		}
		else
		{
			TextBox a_ = (TextBox)l;
			num = global::a.a((TextBoxBase)(object)a_, point);
		}
		if (!k)
		{
			l.Select(num, 0);
		}
		i = a(num);
		if (this.m_b == null)
		{
			if (j.ValidateWord(i.Value))
			{
				return;
			}
			ContextMenu val2 = new ContextMenu();
			SuggestionCollection val3 = new SuggestionCollection(j, i.Value);
			foreach (Suggestion item in val3)
			{
				Suggestion val4 = item;
				((Menu)val2).MenuItems.Add(val4.Value, (EventHandler)b);
			}
			val2.Show((Control)(object)l, point);
		}
		else
		{
			this.m_b(this.m_a, new DisplayMenuEventArgs(i, j, point));
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		MenuItem val = (MenuItem)((A_0 is MenuItem) ? A_0 : null);
		string text = val.Text;
		l.Select(i.Index, i.Value.Length);
		l.SelectedText = text;
	}

	private Misspelling a(int A_0)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		if (h != null && h.Count > 0)
		{
			for (int i = 0; i < h.Count; i++)
			{
				if (h[i].Index < A_0 && h[i].Index + h[i].Value.Length > A_0)
				{
					return h[i];
				}
			}
		}
		return new Misspelling(0, "");
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		if (((Control)l).Width > 0 && ((Control)l).Height > 0)
		{
			f.Dispose();
			((Image)this.m_c).Dispose();
			e.Dispose();
			f = null;
			e = null;
			this.m_c = null;
			this.m_c = new Bitmap(((Control)l).Width, ((Control)l).Height);
			this.m_c.MakeTransparent();
			f = Graphics.FromImage((Image)(object)this.m_c);
			f.Clip = new Region(((Control)l).ClientRectangle);
			e = Graphics.FromHwnd(((Control)l).Handle);
		}
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		if (l is TextBox)
		{
			((Control)l).Refresh();
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		if (l is TextBox)
		{
			((Control)l).Refresh();
		}
	}

	public void a()
	{
		d();
		((Image)this.m_c).Dispose();
		e.Dispose();
		f.Dispose();
		((Control)l).Refresh();
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in a
		this.a();
	}
}
