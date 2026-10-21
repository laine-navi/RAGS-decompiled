using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class MapFrm : Form
{
	private IContainer m_a;

	private MapCntrl b;

	public MapFrm(ref Game CurGame)
	{
		a();
		b.TheGame = CurGame;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_a != null)
		{
			this.m_a.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MapFrm));
		b = new MapCntrl();
		((Control)this).SuspendLayout();
		((ScrollableControl)b).AutoScroll = true;
		((UserControl)b).BorderStyle = (BorderStyle)1;
		((Control)b).Dock = (DockStyle)5;
		((Control)b).Location = new Point(0, 0);
		((Control)b).Name = "mapCntrl1";
		((Control)b).Size = new Size(590, 391);
		((Control)b).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(590, 391);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "MapFrm";
		((Control)this).Text = "MapFrm";
		((Control)this).ResumeLayout(false);
	}
}
