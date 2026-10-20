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

	private Pen redPen = new Pen(Brushes.Red);

	private FontFamily fontfml = new FontFamily((GenericFontFamilies)0);

	private Font font;

	private SolidBrush brush = new SolidBrush(Color.Red);

	private ArrayList MapGroups = new ArrayList();

	private IContainer components;

	private Panel panel1;

	private ComboBox cbMaps;

	private Label label1;

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
		InitializeComponent();
		font = new Font(fontfml, 8f);
	}

	private void MapCntrl_Load(object sender, EventArgs e)
	{
		((Control)panel1).Width = 0;
		((Control)panel1).Height = 0;
		CalcTotalSize();
		cbMaps.Items.Clear();
		foreach (RoomGroup mapGroup in MapGroups)
		{
			if (mapGroup != null)
			{
				mapGroup.OrigStart.X += mapGroup.minx * -1;
				mapGroup.OrigStart.Y += mapGroup.miny * -1;
				mapGroup.maxx += mapGroup.minx * -1;
				mapGroup.maxy += mapGroup.miny * -1;
				foreach (RoomData drawRoom in mapGroup.DrawRooms)
				{
					drawRoom.pos.X += mapGroup.minx * -1;
					drawRoom.pos.Y += mapGroup.miny * -1;
				}
			}
			cbMaps.Items.Add((object)mapGroup.MapGroupName);
		}
		if (cbMaps.Items.Count > 0)
		{
			((ListControl)cbMaps).SelectedIndex = 0;
			_ = (RoomGroup)MapGroups[0];
		}
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.Clear(((Control)panel1).BackColor);
		RoomGroup roomGroup = null;
		foreach (RoomGroup mapGroup in MapGroups)
		{
			if (mapGroup.MapGroupName == cbMaps.SelectedItem.ToString())
			{
				roomGroup = mapGroup;
				break;
			}
		}
		if (roomGroup == null)
		{
			return;
		}
		if (((Control)panel1).Width != roomGroup.maxx)
		{
			((Control)panel1).Width = roomGroup.maxx + 20;
		}
		if (((Control)panel1).Height != roomGroup.maxy)
		{
			((Control)panel1).Height = roomGroup.maxy + 20;
		}
		foreach (RoomData drawRoom in roomGroup.DrawRooms)
		{
			drawRoom.DrawnAlready = false;
		}
		DrawAllRooms(e.Graphics, roomGroup);
	}

	private void CalcTotalSize()
	{
		if (TheGame != null)
		{
			Room startingRoom = TheGame.ThePlayer.StartingRoom;
			RoomGroup roomGroup = new RoomGroup("Player Start");
			MapGroups.Add(roomGroup);
			ProcessStartingRoom(startingRoom, roomGroup);
		}
	}

	private void ProcessStartingRoom(Room start, RoomGroup curgroup)
	{
		RoomData roomData = new RoomData(default, start);
		curgroup.DrawRooms.Add(roomData);
		if (roomData != null)
		{
			roomData.DrawThisRoom = true;
			DrawRoom(null, roomData);
			DrawExits(null, roomData, curgroup);
		}
	}

	private RoomData GetData(Room temproom, RoomGroup curgroup)
	{
		RoomData result = null;
		foreach (RoomData drawRoom in curgroup.DrawRooms)
		{
			if (temproom.UniqueID == drawRoom.TheRoom.UniqueID)
			{
				result = drawRoom;
				break;
			}
		}
		return result;
	}

	private void DrawAllRooms(Graphics surface, RoomGroup curgroup)
	{
		if (TheGame == null)
		{
			return;
		}
		foreach (RoomData drawRoom in curgroup.DrawRooms)
		{
			if (!drawRoom.DrawThisRoom)
			{
				continue;
			}
			DrawRoom(surface, drawRoom);
			foreach (Exit exit in drawRoom.TheRoom.Exits)
			{
				RoomData roomData2 = null;
				if (exit.DestinationRoom != null)
				{
					roomData2 = GetData(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), curgroup);
				}
				if (exit.DestinationRoom != null && roomData2 != null && roomData2.DrawThisRoom)
				{
					switch (exit.Direction)
					{
					case Exit.Directions.North:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X + 50, drawRoom.pos.Y), new Point(roomData2.pos.X + 50, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.South:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X + 50, drawRoom.pos.Y + 100), new Point(roomData2.pos.X + 50, roomData2.pos.Y));
						break;
					case Exit.Directions.East:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y + 50), new Point(roomData2.pos.X, roomData2.pos.Y + 50));
						break;
					case Exit.Directions.West:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X, drawRoom.pos.Y + 50), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 50));
						break;
					case Exit.Directions.NorthWest:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X, drawRoom.pos.Y), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.NorthEast:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y), new Point(roomData2.pos.X, roomData2.pos.Y + 100));
						break;
					case Exit.Directions.SouthWest:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X, drawRoom.pos.Y + 100), new Point(roomData2.pos.X + 100, roomData2.pos.Y));
						break;
					case Exit.Directions.SouthEast:
						surface.DrawLine(redPen, new Point(drawRoom.pos.X + 100, drawRoom.pos.Y + 100), new Point(roomData2.pos.X, roomData2.pos.Y));
						break;
					}
				}
			}
		}
	}

	private void DrawExits(Graphics surface, RoomData tempdata, RoomGroup curgroup)
	{
		Point point = default;
		foreach (Exit exit in tempdata.TheRoom.Exits)
		{
			if (exit.DestinationRoom == null)
			{
				continue;
			}
			RoomData roomData = GetData(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), curgroup);
			if (roomData == null && exit.Direction != Exit.Directions.In && exit.Direction != Exit.Directions.Out && exit.Direction != Exit.Directions.Up && exit.Direction != Exit.Directions.Down)
			{
				roomData = new RoomData(default, TheGame.GetRoomByID(new Guid(exit.DestinationRoom)));
				curgroup.DrawRooms.Add(roomData);
			}
			else if (roomData == null && OKToAdd(TheGame.GetRoomByID(new Guid(exit.DestinationRoom))))
			{
				RoomGroup roomGroup = new RoomGroup(exit.Direction.ToString() + " to " + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name);
				MapGroups.Add(roomGroup);
				ProcessStartingRoom(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), roomGroup);
			}
			if (roomData != null && !roomData.DrawnAlready)
			{
				switch (exit.Direction)
				{
				case Exit.Directions.North:
					point = new Point(tempdata.pos.X, tempdata.pos.Y - 120);
					CheckForCollision(point, Exit.Directions.North, curgroup);
					break;
				case Exit.Directions.South:
					point = new Point(tempdata.pos.X, tempdata.pos.Y + 120);
					CheckForCollision(point, Exit.Directions.South, curgroup);
					break;
				case Exit.Directions.West:
					point = new Point(tempdata.pos.X - 120, tempdata.pos.Y);
					CheckForCollision(point, Exit.Directions.West, curgroup);
					break;
				case Exit.Directions.East:
					point = new Point(tempdata.pos.X + 120, tempdata.pos.Y);
					CheckForCollision(point, Exit.Directions.East, curgroup);
					break;
				case Exit.Directions.NorthEast:
					point = new Point(tempdata.pos.X + 120, tempdata.pos.Y - 120);
					CheckForCollision(point, Exit.Directions.NorthEast, curgroup);
					break;
				case Exit.Directions.NorthWest:
					point = new Point(tempdata.pos.X - 120, tempdata.pos.Y - 120);
					CheckForCollision(point, Exit.Directions.NorthWest, curgroup);
					break;
				case Exit.Directions.SouthEast:
					point = new Point(tempdata.pos.X + 120, tempdata.pos.Y + 120);
					CheckForCollision(point, Exit.Directions.SouthEast, curgroup);
					break;
				case Exit.Directions.SouthWest:
					point = new Point(tempdata.pos.X - 120, tempdata.pos.Y + 120);
					CheckForCollision(point, Exit.Directions.SouthWest, curgroup);
					break;
				}
				roomData.pos = point;
				roomData.DrawThisRoom = true;
				DrawRoom(surface, roomData);
				DrawExits(surface, roomData, curgroup);
				if (roomData.pos.X + 100 > curgroup.maxx)
				{
					curgroup.maxx = roomData.pos.X + 100;
				}
				if (roomData.pos.Y + 100 > curgroup.maxy)
				{
					curgroup.maxy = roomData.pos.Y + 100;
				}
				if (roomData.pos.X < curgroup.minx)
				{
					curgroup.minx = roomData.pos.X;
				}
				if (roomData.pos.Y < curgroup.miny)
				{
					curgroup.miny = roomData.pos.Y;
				}
			}
		}
	}

	private void DrawRoom(Graphics surface, RoomData tempdata)
	{
		if (surface != null)
		{
			surface.DrawRectangle(redPen, new Rectangle(tempdata.pos.X, tempdata.pos.Y, 100, 100));
			surface.DrawString(tempdata.TheRoom.Name, font, (Brush)(object)brush, (float)tempdata.pos.X, (float)(tempdata.pos.Y + 25));
		}
		tempdata.DrawnAlready = true;
	}

	private void CheckForCollision(Point temppoint, Exit.Directions dir, RoomGroup curgroup)
	{
		bool flag = false;
		foreach (RoomData drawRoom in curgroup.DrawRooms)
		{
			if (drawRoom.pos == temppoint)
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
		switch (dir)
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
		foreach (RoomData drawRoom2 in curgroup.DrawRooms)
		{
			if (flag2 && drawRoom2.pos.Y <= temppoint.Y)
			{
				drawRoom2.pos.Y -= 120;
			}
			if (flag3 && drawRoom2.pos.Y >= temppoint.Y)
			{
				drawRoom2.pos.Y += 120;
			}
			if (flag5 && drawRoom2.pos.X <= temppoint.X)
			{
				drawRoom2.pos.X -= 120;
			}
			if (flag4 && drawRoom2.pos.X >= temppoint.X)
			{
				drawRoom2.pos.X += 120;
			}
		}
	}

	private void cbMaps_SelectedIndexChanged(object sender, EventArgs e)
	{
		Graphics val = ((Control)panel1).CreateGraphics();
		val.Clear(((Control)panel1).BackColor);
		RoomGroup roomGroup = null;
		foreach (RoomGroup mapGroup in MapGroups)
		{
			if (mapGroup.MapGroupName == cbMaps.SelectedItem.ToString())
			{
				roomGroup = mapGroup;
				break;
			}
		}
		if (roomGroup == null)
		{
			return;
		}
		if (((Control)panel1).Width != roomGroup.maxx)
		{
			((Control)panel1).Width = roomGroup.maxx + 20;
		}
		if (((Control)panel1).Height != roomGroup.maxy)
		{
			((Control)panel1).Height = roomGroup.maxy + 20;
		}
		foreach (RoomData drawRoom in roomGroup.DrawRooms)
		{
			drawRoom.DrawnAlready = false;
		}
		DrawAllRooms(val, roomGroup);
	}

	private bool OKToAdd(Room RoomToCheck)
	{
		foreach (RoomGroup mapGroup in MapGroups)
		{
			foreach (RoomData drawRoom in mapGroup.DrawRooms)
			{
				if (drawRoom.TheRoom.UniqueID == RoomToCheck.UniqueID)
				{
					return false;
				}
			}
		}
		return true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		panel1 = new Panel();
		cbMaps = new ComboBox();
		label1 = new Label();
		((Control)this).SuspendLayout();
		((ScrollableControl)panel1).AutoScroll = true;
		panel1.BorderStyle = (BorderStyle)1;
		((Control)panel1).Location = new Point(3, 49);
		((Control)panel1).Name = "panel1";
		((Control)panel1).Size = new Size(347, 208);
		((Control)panel1).TabIndex = 0;
		((Control)panel1).Paint += panel1_Paint;
		((ListControl)cbMaps).FormattingEnabled = true;
		((Control)cbMaps).Location = new Point(3, 22);
		((Control)cbMaps).Name = "cbMaps";
		((Control)cbMaps).Size = new Size(191, 21);
		((Control)cbMaps).TabIndex = 1;
		cbMaps.SelectedIndexChanged += cbMaps_SelectedIndexChanged;
		((Control)label1).AutoSize = true;
		((Control)label1).Location = new Point(3, 6);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(64, 13);
		((Control)label1).TabIndex = 2;
		((Control)label1).Text = "Select Map:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((ScrollableControl)this).AutoScroll = true;
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Controls.Add((Control)(object)cbMaps);
		((Control)this).Controls.Add((Control)(object)panel1);
		((Control)this).Name = "MapCntrl";
		((Control)this).Size = new Size(356, 260);
		((UserControl)this).Load += MapCntrl_Load;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
