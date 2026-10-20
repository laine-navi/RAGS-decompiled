using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Rags;

public class MapCntrl : UserControl
{
	public Game TheGame;

	private Pen m_a = new Pen(Brushes.Red);

	private FontFamily m_b = new FontFamily((GenericFontFamilies)0);

	private Font c;

	private SolidBrush d = new SolidBrush(Color.Red);

	private ArrayList e = new ArrayList();

	private IContainer f;

	private Panel g;

	private ComboBox h;

	private Label i;

	public MapCntrl()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		a();
		c = new Font(this.m_b, 8f);
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Control)g).Width = 0;
		((Control)g).Height = 0;
		b();
		h.Items.Clear();
		foreach (RoomGroup item in e)
		{
			if (item != null)
			{
				item.OrigStart.X += item.minx * -1;
				item.OrigStart.Y += item.miny * -1;
				item.maxx += item.minx * -1;
				item.maxy += item.miny * -1;
				foreach (RoomData drawRoom in item.DrawRooms)
				{
					drawRoom.pos.X += item.minx * -1;
					drawRoom.pos.Y += item.miny * -1;
				}
			}
			h.Items.Add((object)item.MapGroupName);
		}
		if (h.Items.Count > 0)
		{
			((ListControl)h).SelectedIndex = 0;
			_ = (RoomGroup)e[0];
		}
	}

	private void a(object A_0, PaintEventArgs A_1)
	{
		A_1.Graphics.Clear(((Control)g).BackColor);
		RoomGroup roomGroup = null;
		foreach (RoomGroup item in e)
		{
			if (item.MapGroupName == h.SelectedItem.ToString())
			{
				roomGroup = item;
				break;
			}
		}
		if (roomGroup == null)
		{
			return;
		}
		if (((Control)g).Width != roomGroup.maxx)
		{
			((Control)g).Width = roomGroup.maxx + 20;
		}
		if (((Control)g).Height != roomGroup.maxy)
		{
			((Control)g).Height = roomGroup.maxy + 20;
		}
		foreach (RoomData drawRoom in roomGroup.DrawRooms)
		{
			drawRoom.DrawnAlready = false;
		}
		a(A_1.Graphics, roomGroup);
	}

	private void b()
	{
		if (TheGame != null)
		{
			Room startingRoom = TheGame.ThePlayer.StartingRoom;
			RoomGroup roomGroup = new RoomGroup("Player Start");
			e.Add(roomGroup);
			b(startingRoom, roomGroup);
		}
	}

	private void b(Room A_0, RoomGroup A_1)
	{
		RoomData roomData = new RoomData(default, A_0);
		A_1.DrawRooms.Add(roomData);
		if (roomData != null)
		{
			roomData.DrawThisRoom = true;
			a(null, roomData);
			a(null, roomData, A_1);
		}
	}

	private RoomData a(Room A_0, RoomGroup A_1)
	{
		RoomData result = null;
		foreach (RoomData drawRoom in A_1.DrawRooms)
		{
			if (A_0.UniqueID == drawRoom.TheRoom.UniqueID)
			{
				result = drawRoom;
				break;
			}
		}
		return result;
	}

	private void a(Graphics A_0, RoomGroup A_1)
	{
		if (TheGame == null)
		{
			return;
		}
		foreach (RoomData drawRoom in A_1.DrawRooms)
		{
			if (!drawRoom.DrawThisRoom)
			{
				continue;
			}
			a(A_0, drawRoom);
			foreach (Exit exit in drawRoom.TheRoom.Exits)
			{
				RoomData roomData2 = null;
				if (exit.DestinationRoom != null)
				{
					roomData2 = a(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), A_1);
				}
				if (exit.DestinationRoom != null && roomData2 != null && roomData2.DrawThisRoom)
				{
					switch (exit.Direction)
					{
					case Exit.Directions.North:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X + 50, drawRoom.pos.Y), new Point(roomData2.pos.X + 50, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.South:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X + 50, drawRoom.pos.Y + 100), new Point(roomData2.pos.X + 50, roomData2.pos.Y));
						break;
					case Exit.Directions.East:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y + 50), new Point(roomData2.pos.X, roomData2.pos.Y + 50));
						break;
					case Exit.Directions.West:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X, drawRoom.pos.Y + 50), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 50));
						break;
					case Exit.Directions.NorthWest:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X, drawRoom.pos.Y), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.NorthEast:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y), new Point(roomData2.pos.X, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.SouthWest:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X, drawRoom.pos.Y + 100), new Point(roomData2.pos.X + 100, roomData2.pos.Y));
						break;
					case Exit.Directions.SouthEast:
						A_0.DrawLine(this.m_a, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y + 100), new Point(roomData2.pos.X, roomData2.pos.Y));
						break;
					}
				}
			}
		}
	}

	private void a(Graphics A_0, RoomData A_1, RoomGroup A_2)
	{
		Point point = default;
		foreach (Exit exit in A_1.TheRoom.Exits)
		{
			if (exit.DestinationRoom == null)
			{
				continue;
			}
			RoomData roomData = a(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), A_2);
			if (roomData == null && exit.Direction != Exit.Directions.In && exit.Direction != Exit.Directions.Out && exit.Direction != Exit.Directions.Up && exit.Direction != Exit.Directions.Down)
			{
				roomData = new RoomData(default, TheGame.GetRoomByID(new Guid(exit.DestinationRoom)));
				A_2.DrawRooms.Add(roomData);
			}
			else if (roomData == null && a(TheGame.GetRoomByID(new Guid(exit.DestinationRoom))))
			{
				RoomGroup roomGroup = new RoomGroup(exit.Direction.ToString() + " to " + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name);
				e.Add(roomGroup);
				b(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), roomGroup);
			}
			if (roomData != null && !roomData.DrawnAlready)
			{
				switch (exit.Direction)
				{
				case Exit.Directions.North:
					point = new Point(A_1.pos.X, A_1.pos.Y - 120);
					a(point, Exit.Directions.North, A_2);
					break;
				case Exit.Directions.South:
					point = new Point(A_1.pos.X, A_1.pos.Y + 120);
					a(point, Exit.Directions.South, A_2);
					break;
				case Exit.Directions.West:
					point = new Point(A_1.pos.X - 120, A_1.pos.Y);
					a(point, Exit.Directions.West, A_2);
					break;
				case Exit.Directions.East:
					point = new Point(A_1.pos.X + 120, A_1.pos.Y);
					a(point, Exit.Directions.East, A_2);
					break;
				case Exit.Directions.NorthEast:
					point = new Point(A_1.pos.X + 120, A_1.pos.Y - 120);
					a(point, Exit.Directions.NorthEast, A_2);
					break;
				case Exit.Directions.NorthWest:
					point = new Point(A_1.pos.X - 120, A_1.pos.Y - 120);
					a(point, Exit.Directions.NorthWest, A_2);
					break;
				case Exit.Directions.SouthEast:
					point = new Point(A_1.pos.X + 120, A_1.pos.Y + 120);
					a(point, Exit.Directions.SouthEast, A_2);
					break;
				case Exit.Directions.SouthWest:
					point = new Point(A_1.pos.X - 120, A_1.pos.Y + 120);
					a(point, Exit.Directions.SouthWest, A_2);
					break;
				}
				roomData.pos = point;
				roomData.DrawThisRoom = true;
				a(A_0, roomData);
				a(A_0, roomData, A_2);
				if (roomData.pos.X + 100 > A_2.maxx)
				{
					A_2.maxx = roomData.pos.X + 100;
				}
				if (roomData.pos.Y + 100 > A_2.maxy)
				{
					A_2.maxy = roomData.pos.Y + 100;
				}
				if (roomData.pos.X < A_2.minx)
				{
					A_2.minx = roomData.pos.X;
				}
				if (roomData.pos.Y < A_2.miny)
				{
					A_2.miny = roomData.pos.Y;
				}
			}
		}
	}

	private void a(Graphics A_0, RoomData A_1)
	{
		if (A_0 != null)
		{
			A_0.DrawRectangle(this.m_a, new Rectangle(A_1.pos.X, A_1.pos.Y, 100, 100));
			A_0.DrawString(A_1.TheRoom.Name, c, (Brush)(object)d, (float)A_1.pos.X, (float)(A_1.pos.Y + 25));
		}
		A_1.DrawnAlready = true;
	}

	private void a(Point A_0, Exit.Directions A_1, RoomGroup A_2)
	{
		bool flag = false;
		foreach (RoomData drawRoom in A_2.DrawRooms)
		{
			if (drawRoom.pos == A_0)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		switch (A_1)
		{
		case Exit.Directions.North:
			flag2 = true;
			break;
		case Exit.Directions.South:
			flag3 = true;
			break;
		case Exit.Directions.East:
			flag4 = true;
			break;
		case Exit.Directions.West:
			flag5 = true;
			break;
		case Exit.Directions.NorthWest:
			flag5 = true;
			flag2 = true;
			break;
		case Exit.Directions.NorthEast:
			flag4 = true;
			flag2 = true;
			break;
		case Exit.Directions.SouthWest:
			flag5 = true;
			flag3 = true;
			break;
		case Exit.Directions.SouthEast:
			flag4 = true;
			flag3 = true;
			break;
		}
		foreach (RoomData drawRoom2 in A_2.DrawRooms)
		{
			if (flag2 && drawRoom2.pos.Y <= A_0.Y)
			{
				drawRoom2.pos.Y -= 120;
			}
			if (flag3 && drawRoom2.pos.Y >= A_0.Y)
			{
				drawRoom2.pos.Y += 120;
			}
			if (flag5 && drawRoom2.pos.X <= A_0.X)
			{
				drawRoom2.pos.X -= 120;
			}
			if (flag4 && drawRoom2.pos.X >= A_0.X)
			{
				drawRoom2.pos.X += 120;
			}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		Graphics val = ((Control)g).CreateGraphics();
		val.Clear(((Control)g).BackColor);
		RoomGroup roomGroup = null;
		foreach (RoomGroup item in e)
		{
			if (item.MapGroupName == h.SelectedItem.ToString())
			{
				roomGroup = item;
				break;
			}
		}
		if (roomGroup == null)
		{
			return;
		}
		if (((Control)g).Width != roomGroup.maxx)
		{
			((Control)g).Width = roomGroup.maxx + 20;
		}
		if (((Control)g).Height != roomGroup.maxy)
		{
			((Control)g).Height = roomGroup.maxy + 20;
		}
		foreach (RoomData drawRoom in roomGroup.DrawRooms)
		{
			drawRoom.DrawnAlready = false;
		}
		a(val, roomGroup);
	}

	private bool a(Room A_0)
	{
		foreach (RoomGroup item in e)
		{
			foreach (RoomData drawRoom in item.DrawRooms)
			{
				if (drawRoom.TheRoom.UniqueID == A_0.UniqueID)
				{
					return false;
				}
			}
		}
		return true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && f != null)
		{
			f.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		g = new Panel();
		h = new ComboBox();
		i = new Label();
		((Control)this).SuspendLayout();
		((ScrollableControl)g).AutoScroll = true;
		g.BorderStyle = (BorderStyle)1;
		((Control)g).Location = new Point(3, 49);
		((Control)g).Name = "panel1";
		((Control)g).Size = new Size(347, 208);
		((Control)g).TabIndex = 0;
		((Control)g).Paint += a;
		((ListControl)h).FormattingEnabled = true;
		((Control)h).Location = new Point(3, 22);
		((Control)h).Name = "cbMaps";
		((Control)h).Size = new Size(191, 21);
		((Control)h).TabIndex = 1;
		h.SelectedIndexChanged += a;
		((Control)i).AutoSize = true;
		((Control)i).Location = new Point(3, 6);
		((Control)i).Name = "label1";
		((Control)i).Size = new Size(64, 13);
		((Control)i).TabIndex = 2;
		((Control)i).Text = "Select Map:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((ScrollableControl)this).AutoScroll = true;
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Name = "MapCntrl";
		((Control)this).Size = new Size(356, 260);
		((UserControl)this).Load += b;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
