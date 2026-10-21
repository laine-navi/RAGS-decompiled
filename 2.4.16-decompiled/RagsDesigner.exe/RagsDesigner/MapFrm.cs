using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class MapFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private MapCntrl ca484cb1292fe73443459c89cc14df2a6;

	public MapFrm(ref Game CurGame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		ca484cb1292fe73443459c89cc14df2a6.TheGame = CurGame;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(MapFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(MapFrm.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MapFrm));
		ca484cb1292fe73443459c89cc14df2a6 = new MapCntrl();
		((Control)this).SuspendLayout();
		((ScrollableControl)ca484cb1292fe73443459c89cc14df2a6).AutoScroll = true;
		((UserControl)ca484cb1292fe73443459c89cc14df2a6).BorderStyle = (BorderStyle)1;
		((Control)ca484cb1292fe73443459c89cc14df2a6).Dock = (DockStyle)5;
		((Control)ca484cb1292fe73443459c89cc14df2a6).Location = new Point(0, 0);
		((Control)ca484cb1292fe73443459c89cc14df2a6).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1654);
		((Control)ca484cb1292fe73443459c89cc14df2a6).Size = new Size(590, 391);
		((Control)ca484cb1292fe73443459c89cc14df2a6).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(590, 391);
		((Control)this).Controls.Add((Control)(object)ca484cb1292fe73443459c89cc14df2a6);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1673);
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1673);
		((Control)this).ResumeLayout(false);
	}
}
