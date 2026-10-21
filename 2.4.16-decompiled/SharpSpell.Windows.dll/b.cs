using System.Security.Permissions;
using System.Windows.Forms;

internal class b : NativeWindow
{
	private c m_a;

	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	protected override void a(ref Message A_0)
	{
		switch (A_0.Msg)
		{
		case 15:
			((Control)this.m_a.l).Invalidate();
			((NativeWindow)this).WndProc(ref A_0);
			this.m_a.c();
			break;
		case 20:
			((NativeWindow)this).WndProc(ref A_0);
			break;
		default:
			((NativeWindow)this).WndProc(ref A_0);
			break;
		}
	}

	public b(c A_0)
	{
		this.m_a = A_0;
	}
}
