using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Rags;

public class RagsImageMap : UserControl
{
	public delegate void RegionClickDelegate(int index, string key);

	private GraphicsPath m_a;

	private int m_b = -1;

	private ArrayList c;

	private ToolTip d;

	private Graphics e;

	private int f;

	private int g;

	private PictureBox h;

	[CompilerGenerated]
	private RegionClickDelegate i;

	private IContainer j;

	[Category("Appearance")]
	public Image Image
	{
		get
		{
			return h.Image;
		}
		set
		{
			h.Image = value;
		}
	}

	public PictureBoxSizeMode SizeMode
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return h.SizeMode;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			h.SizeMode = value;
		}
	}

	[Category("Appearance")]
	public override Image BackgroundImage
	{
		get
		{
			return ((Control)h).BackgroundImage;
		}
		set
		{
			((Control)h).BackgroundImage = value;
		}
	}

	[Category("Action")]
	public event RegionClickDelegate RegionClick
	{
		[CompilerGenerated]
		add
		{
			RegionClickDelegate regionClickDelegate = i;
			RegionClickDelegate regionClickDelegate2;
			do
			{
				regionClickDelegate2 = regionClickDelegate;
				RegionClickDelegate value2 = (RegionClickDelegate)Delegate.Combine(regionClickDelegate2, value);
				regionClickDelegate = Interlocked.CompareExchange(ref i, value2, regionClickDelegate2);
			}
			while ((object)regionClickDelegate != regionClickDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			RegionClickDelegate regionClickDelegate = i;
			RegionClickDelegate regionClickDelegate2;
			do
			{
				regionClickDelegate2 = regionClickDelegate;
				RegionClickDelegate value2 = (RegionClickDelegate)Delegate.Remove(regionClickDelegate2, value);
				regionClickDelegate = Interlocked.CompareExchange(ref i, value2, regionClickDelegate2);
			}
			while ((object)regionClickDelegate != regionClickDelegate2);
		}
	}

	public RagsImageMap()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		a();
		c = new ArrayList();
		this.m_a = new GraphicsPath();
		this.m_a.FillMode = (FillMode)1;
		j = new Container();
		d = new ToolTip(j);
		d.AutoPopDelay = 5000;
		d.InitialDelay = 1000;
		d.ReshowDelay = 500;
		e = Graphics.FromHwnd(((Control)h).Handle);
	}

	public int AddElipse(string key, Point center, int radius)
	{
		return AddElipse(key, center.X, center.Y, radius);
	}

	public int AddElipse(string key, int x, int y, int radius)
	{
		if (c.Count > 0)
		{
			this.m_a.SetMarkers();
		}
		this.m_a.AddEllipse(x - radius, y - radius, radius * 2, radius * 2);
		return c.Add(key);
	}

	public int AddRectangle(string key, int x1, int y1, int x2, int y2)
	{
		return AddRectangle(key, new Rectangle(x1, y1, x2 - x1, y2 - y1));
	}

	public int AddRectangle(string key, Rectangle rectangle)
	{
		if (c.Count > 0)
		{
			this.m_a.SetMarkers();
		}
		this.m_a.AddRectangle(rectangle);
		return c.Add(key);
	}

	public int AddPolygon(string key, Point[] points)
	{
		if (c.Count > 0)
		{
			this.m_a.SetMarkers();
		}
		this.m_a.AddPolygon(points);
		return c.Add(key);
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		if ((int)A_1.Button == 1048576)
		{
			e.FillEllipse((Brush)new SolidBrush(Color.Blue), new Rectangle(f, g, A_1.X, A_1.Y));
			return;
		}
		int num = a(new Point(A_1.X, A_1.Y));
		if (num > -1)
		{
			((Control)h).Cursor = Cursors.Hand;
			if (this.m_b != num)
			{
				d.SetToolTip((Control)(object)h, c[num].ToString());
			}
		}
		else
		{
			((Control)h).Cursor = Cursors.Default;
			d.RemoveAll();
		}
		this.m_b = num;
	}

	private void b(object A_0, EventArgs A_1)
	{
		this.m_b = -1;
		((Control)this).Cursor = Cursors.Default;
	}

	private void a(object A_0, EventArgs A_1)
	{
		e.Clear(SystemColors.Control);
		Point point = ((Control)this).PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
		f = point.X;
		g = point.Y;
		Point a_ = ((Control)this).PointToClient(Cursor.Position);
		if (this.m_b == -1)
		{
			a(a_);
		}
		if (this.m_b > -1 && i != null)
		{
			i(this.m_b, c[this.m_b].ToString());
		}
	}

	private int a(Point A_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		GraphicsPath val = new GraphicsPath();
		GraphicsPathIterator val2 = new GraphicsPathIterator(this.m_a);
		val2.Rewind();
		for (int i = 0; i < val2.SubpathCount; i++)
		{
			val2.NextMarker(val);
			if (val.IsVisible(A_0, e))
			{
				return i;
			}
		}
		return -1;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && j != null)
		{
			j.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		j = new Container();
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		h = new PictureBox();
		((Control)this).SuspendLayout();
		((Control)h).Dock = (DockStyle)5;
		((Control)h).Name = "pictureBox";
		((Control)h).Size = new Size(150, 150);
		h.SizeMode = (PictureBoxSizeMode)4;
		((Control)h).BackgroundImageLayout = (ImageLayout)4;
		h.TabIndex = 0;
		h.TabStop = false;
		((Control)h).Click += a;
		((Control)h).MouseMove += a;
		((Control)h).MouseLeave += b;
		((Control)this).Controls.AddRange(new Control[1] { (Control)h });
		((Control)this).Name = "ImageMap";
		((Control)this).ResumeLayout(false);
	}
}
