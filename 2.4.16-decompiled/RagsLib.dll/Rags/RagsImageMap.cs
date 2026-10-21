using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class RagsImageMap : UserControl
{
	public delegate void RegionClickDelegate(int index, string key);

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private GraphicsPath cab037a74a57396d7e716e3d6e883ec9c;

	private int c51c8ca3459aed0c20c2059bdb387a2f4 = -1;

	private ArrayList c8a4f62fc32d345426209c9e2910d2e6e;

	private ToolTip c0056cc7f814760adea16b6ddf6bc76e9;

	private Graphics c9921260864cf9c3f0fb057ecf3e027c2;

	private int cc17e2a651bbf46e8daaf2f47b36a2344;

	private int c7dcdf1c212f2d3efd3c35b7bb24dabdd;

	private PictureBox c26b2ae4972fc7bc1195e6aacf4294b60;

	private RegionClickDelegate c7f9a5d33e9564a2897577a60a75c2908;

	[Category("Appearance")]
	public Image Image
	{
		get
		{
			return c26b2ae4972fc7bc1195e6aacf4294b60.Image;
		}
		set
		{
			c26b2ae4972fc7bc1195e6aacf4294b60.Image = value;
		}
	}

	public PictureBoxSizeMode SizeMode
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return c26b2ae4972fc7bc1195e6aacf4294b60.SizeMode;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			c26b2ae4972fc7bc1195e6aacf4294b60.SizeMode = value;
		}
	}

	[Category("Appearance")]
	public override Image BackgroundImage
	{
		get
		{
			return ((Control)c26b2ae4972fc7bc1195e6aacf4294b60).BackgroundImage;
		}
		set
		{
			((Control)c26b2ae4972fc7bc1195e6aacf4294b60).BackgroundImage = value;
		}
	}

	[Category("Action")]
	public event RegionClickDelegate RegionClick
	{
		add
		{
			RegionClickDelegate regionClickDelegate = c7f9a5d33e9564a2897577a60a75c2908;
			while (true)
			{
				RegionClickDelegate regionClickDelegate2 = regionClickDelegate;
				RegionClickDelegate value2 = (RegionClickDelegate)Delegate.Combine(regionClickDelegate2, value);
				regionClickDelegate = Interlocked.CompareExchange(ref c7f9a5d33e9564a2897577a60a75c2908, value2, regionClickDelegate2);
				if ((object)regionClickDelegate == regionClickDelegate2)
				{
					break;
				}
				__ldtoken(RagsImageMap.add_RegionClick(RegionClickDelegate));
			}
		}
		remove
		{
			RegionClickDelegate regionClickDelegate = c7f9a5d33e9564a2897577a60a75c2908;
			while (true)
			{
				RegionClickDelegate regionClickDelegate2 = regionClickDelegate;
				RegionClickDelegate value2 = (RegionClickDelegate)Delegate.Remove(regionClickDelegate2, value);
				regionClickDelegate = Interlocked.CompareExchange(ref c7f9a5d33e9564a2897577a60a75c2908, value2, regionClickDelegate2);
				if ((object)regionClickDelegate == regionClickDelegate2)
				{
					break;
				}
				__ldtoken(RagsImageMap.remove_RegionClick(RegionClickDelegate));
			}
		}
	}

	public RagsImageMap()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		cffa44bb0cb8be4c595ec865afadbafa5();
		c8a4f62fc32d345426209c9e2910d2e6e = new ArrayList();
		cab037a74a57396d7e716e3d6e883ec9c = new GraphicsPath();
		cab037a74a57396d7e716e3d6e883ec9c.FillMode = (FillMode)1;
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		c0056cc7f814760adea16b6ddf6bc76e9 = new ToolTip(c501c89bc63d55bb522eac228aeeebb18);
		c0056cc7f814760adea16b6ddf6bc76e9.AutoPopDelay = 5000;
		c0056cc7f814760adea16b6ddf6bc76e9.InitialDelay = 1000;
		c0056cc7f814760adea16b6ddf6bc76e9.ReshowDelay = 500;
		c9921260864cf9c3f0fb057ecf3e027c2 = Graphics.FromHwnd(((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Handle);
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RagsImageMap.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		c26b2ae4972fc7bc1195e6aacf4294b60 = new PictureBox();
		((Control)this).SuspendLayout();
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Dock = (DockStyle)5;
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23002);
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Size = new Size(150, 150);
		c26b2ae4972fc7bc1195e6aacf4294b60.SizeMode = (PictureBoxSizeMode)4;
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).BackgroundImageLayout = (ImageLayout)4;
		c26b2ae4972fc7bc1195e6aacf4294b60.TabIndex = 0;
		c26b2ae4972fc7bc1195e6aacf4294b60.TabStop = false;
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Click += c9c1ed46486cd0cf6a9880e79867be9df;
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).MouseMove += ccc34d9181a06f982f166557237bd68b3;
		((Control)c26b2ae4972fc7bc1195e6aacf4294b60).MouseLeave += c2e945f2462b3bc6c7c4dc92442045207;
		((Control)this).Controls.AddRange(new Control[1] { (Control)c26b2ae4972fc7bc1195e6aacf4294b60 });
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23023);
		((Control)this).ResumeLayout(false);
	}

	public int AddElipse(string key, Point center, int radius)
	{
		return AddElipse(key, center.X, center.Y, radius);
	}

	public int AddElipse(string key, int x, int y, int radius)
	{
		if (c8a4f62fc32d345426209c9e2910d2e6e.Count <= 0)
		{
			__ldtoken(RagsImageMap.AddElipse(string, int, int, int));
		}
		else
		{
			cab037a74a57396d7e716e3d6e883ec9c.SetMarkers();
		}
		cab037a74a57396d7e716e3d6e883ec9c.AddEllipse(x - radius, y - radius, radius * 2, radius * 2);
		return c8a4f62fc32d345426209c9e2910d2e6e.Add(key);
	}

	public int AddRectangle(string key, int x1, int y1, int x2, int y2)
	{
		return AddRectangle(key, new Rectangle(x1, y1, x2 - x1, y2 - y1));
	}

	public int AddRectangle(string key, Rectangle rectangle)
	{
		if (c8a4f62fc32d345426209c9e2910d2e6e.Count <= 0)
		{
			__ldtoken(RagsImageMap.AddRectangle(string, Rectangle));
		}
		else
		{
			cab037a74a57396d7e716e3d6e883ec9c.SetMarkers();
		}
		cab037a74a57396d7e716e3d6e883ec9c.AddRectangle(rectangle);
		return c8a4f62fc32d345426209c9e2910d2e6e.Add(key);
	}

	public int AddPolygon(string key, Point[] points)
	{
		if (c8a4f62fc32d345426209c9e2910d2e6e.Count <= 0)
		{
			__ldtoken(RagsImageMap.AddPolygon(string, Point[]));
		}
		else
		{
			cab037a74a57396d7e716e3d6e883ec9c.SetMarkers();
		}
		cab037a74a57396d7e716e3d6e883ec9c.AddPolygon(points);
		return c8a4f62fc32d345426209c9e2910d2e6e.Add(key);
	}

	private void ccc34d9181a06f982f166557237bd68b3(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		if ((int)P_1.Button != 1048576)
		{
			__ldtoken(RagsImageMap.ccc34d9181a06f982f166557237bd68b3(object, MouseEventArgs));
			int num = ccad1aa0babcae66bdc2b312d2a3ebd85(new Point(P_1.X, P_1.Y));
			if (num <= -1)
			{
				__ldtoken(RagsImageMap.ccc34d9181a06f982f166557237bd68b3(object, MouseEventArgs));
				((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Cursor = Cursors.Default;
				c0056cc7f814760adea16b6ddf6bc76e9.RemoveAll();
			}
			else
			{
				((Control)c26b2ae4972fc7bc1195e6aacf4294b60).Cursor = Cursors.Hand;
				if (c51c8ca3459aed0c20c2059bdb387a2f4 == num)
				{
					__ldtoken(RagsImageMap.ccc34d9181a06f982f166557237bd68b3(object, MouseEventArgs));
				}
				else
				{
					c0056cc7f814760adea16b6ddf6bc76e9.SetToolTip((Control)(object)c26b2ae4972fc7bc1195e6aacf4294b60, c8a4f62fc32d345426209c9e2910d2e6e[num].ToString());
				}
			}
			c51c8ca3459aed0c20c2059bdb387a2f4 = num;
		}
		else
		{
			c9921260864cf9c3f0fb057ecf3e027c2.FillEllipse((Brush)new SolidBrush(Color.Blue), new Rectangle(cc17e2a651bbf46e8daaf2f47b36a2344, c7dcdf1c212f2d3efd3c35b7bb24dabdd, P_1.X, P_1.Y));
		}
	}

	private void c2e945f2462b3bc6c7c4dc92442045207(object P_0, EventArgs P_1)
	{
		c51c8ca3459aed0c20c2059bdb387a2f4 = -1;
		((Control)this).Cursor = Cursors.Default;
	}

	private void c9c1ed46486cd0cf6a9880e79867be9df(object P_0, EventArgs P_1)
	{
		c9921260864cf9c3f0fb057ecf3e027c2.Clear(SystemColors.Control);
		Point point = ((Control)this).PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
		cc17e2a651bbf46e8daaf2f47b36a2344 = point.X;
		c7dcdf1c212f2d3efd3c35b7bb24dabdd = point.Y;
		Point point2 = ((Control)this).PointToClient(Cursor.Position);
		if (c51c8ca3459aed0c20c2059bdb387a2f4 != -1)
		{
			__ldtoken(RagsImageMap.c9c1ed46486cd0cf6a9880e79867be9df(object, EventArgs));
		}
		else
		{
			ccad1aa0babcae66bdc2b312d2a3ebd85(point2);
		}
		if (c51c8ca3459aed0c20c2059bdb387a2f4 <= -1)
		{
			__ldtoken(RagsImageMap.c9c1ed46486cd0cf6a9880e79867be9df(object, EventArgs));
		}
		else if (c7f9a5d33e9564a2897577a60a75c2908 != null)
		{
			c7f9a5d33e9564a2897577a60a75c2908(c51c8ca3459aed0c20c2059bdb387a2f4, c8a4f62fc32d345426209c9e2910d2e6e[c51c8ca3459aed0c20c2059bdb387a2f4].ToString());
		}
	}

	private int ccad1aa0babcae66bdc2b312d2a3ebd85(Point P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		GraphicsPath val = new GraphicsPath();
		GraphicsPathIterator val2 = new GraphicsPathIterator(cab037a74a57396d7e716e3d6e883ec9c);
		val2.Rewind();
		for (int i = 0; i < val2.SubpathCount; i++)
		{
			__ldtoken(RagsImageMap.ccad1aa0babcae66bdc2b312d2a3ebd85(Point));
			val2.NextMarker(val);
			if (!val.IsVisible(P_0, c9921260864cf9c3f0fb057ecf3e027c2))
			{
				__ldtoken(RagsImageMap.ccad1aa0babcae66bdc2b312d2a3ebd85(Point));
				continue;
			}
			return i;
		}
		return -1;
	}
}
