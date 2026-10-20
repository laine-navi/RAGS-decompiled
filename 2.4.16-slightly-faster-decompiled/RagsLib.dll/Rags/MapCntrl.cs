using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class MapCntrl : UserControl
{
	public Game TheGame;

	private Pen cc4c1bd9ace4c9094852ac3cdb54d532c = new Pen(Brushes.Red);

	private FontFamily cbb16b5e7d61c5e46fe8af853a8e3c6e8 = new FontFamily((GenericFontFamilies)0);

	private Font c0e43349a05a7fbae7001bdcd57489270;

	private SolidBrush cc64732ed49c31817ca4fa053816344f7 = new SolidBrush(Color.Red);

	private ArrayList c331769ad21820dd36c2120c10c9a5d36 = new ArrayList();

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Panel c5e74b6ad19335af023c0fb124e8b9948;

	private ComboBox c01e034a3fd0ce41ce875d855434fcb44;

	private Label c300c24b05030c9258d5792c1ed7c590d;

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
		cffa44bb0cb8be4c595ec865afadbafa5();
		c0e43349a05a7fbae7001bdcd57489270 = new Font(cbb16b5e7d61c5e46fe8af853a8e3c6e8, 8f);
	}

	private void c08032fea21d8eca3afe5bd3627f7f737(object P_0, EventArgs P_1)
	{
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Width = 0;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Height = 0;
		cc8eb44c4c1c97f8e1ebcd5feda9b9bca();
		c01e034a3fd0ce41ce875d855434fcb44.Items.Clear();
		IEnumerator enumerator = c331769ad21820dd36c2120c10c9a5d36.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.c08032fea21d8eca3afe5bd3627f7f737(object, EventArgs));
				RoomGroup roomGroup = (RoomGroup)enumerator.Current;
				if (roomGroup == null)
				{
					__ldtoken(MapCntrl.c08032fea21d8eca3afe5bd3627f7f737(object, EventArgs));
				}
				else
				{
					roomGroup.OrigStart.X += roomGroup.minx * -1;
					roomGroup.OrigStart.Y += roomGroup.miny * -1;
					roomGroup.maxx += roomGroup.minx * -1;
					roomGroup.maxy += roomGroup.miny * -1;
					IEnumerator enumerator2 = roomGroup.DrawRooms.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							RoomData roomData = (RoomData)enumerator2.Current;
							roomData.pos.X += roomGroup.minx * -1;
							roomData.pos.Y += roomGroup.miny * -1;
						}
					}
					finally
					{
						if (!(enumerator2 is IDisposable disposable))
						{
							__ldtoken(MapCntrl.c08032fea21d8eca3afe5bd3627f7f737(object, EventArgs));
						}
						else
						{
							disposable.Dispose();
						}
					}
				}
				c01e034a3fd0ce41ce875d855434fcb44.Items.Add((object)roomGroup.MapGroupName);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.c08032fea21d8eca3afe5bd3627f7f737(object, EventArgs));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		if (c01e034a3fd0ce41ce875d855434fcb44.Items.Count > 0)
		{
			((ListControl)c01e034a3fd0ce41ce875d855434fcb44).SelectedIndex = 0;
			_ = (RoomGroup)c331769ad21820dd36c2120c10c9a5d36[0];
		}
	}

	private void c4edcfbb487de8181f0e3e23eb12eb842(object P_0, PaintEventArgs P_1)
	{
		P_1.Graphics.Clear(((Control)c5e74b6ad19335af023c0fb124e8b9948).BackColor);
		RoomGroup roomGroup = null;
		IEnumerator enumerator = c331769ad21820dd36c2120c10c9a5d36.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RoomGroup roomGroup2 = (RoomGroup)enumerator.Current;
				if (!(roomGroup2.MapGroupName == c01e034a3fd0ce41ce875d855434fcb44.SelectedItem.ToString()))
				{
					__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
					continue;
				}
				roomGroup = roomGroup2;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (roomGroup == null)
		{
			return;
		}
		if (((Control)c5e74b6ad19335af023c0fb124e8b9948).Width == roomGroup.maxx)
		{
			__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
		}
		else
		{
			((Control)c5e74b6ad19335af023c0fb124e8b9948).Width = roomGroup.maxx + 20;
		}
		if (((Control)c5e74b6ad19335af023c0fb124e8b9948).Height == roomGroup.maxy)
		{
			__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
		}
		else
		{
			((Control)c5e74b6ad19335af023c0fb124e8b9948).Height = roomGroup.maxy + 20;
		}
		IEnumerator enumerator2 = roomGroup.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
				RoomData roomData = (RoomData)enumerator2.Current;
				roomData.DrawnAlready = false;
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.c4edcfbb487de8181f0e3e23eb12eb842(object, PaintEventArgs));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		c6252017bd9b6c417999feb3c5738abc9(P_1.Graphics, roomGroup);
	}

	private void cc8eb44c4c1c97f8e1ebcd5feda9b9bca()
	{
		if (TheGame == null)
		{
			__ldtoken(MapCntrl.cc8eb44c4c1c97f8e1ebcd5feda9b9bca());
			return;
		}
		Room startingRoom = TheGame.ThePlayer.StartingRoom;
		RoomGroup roomGroup = new RoomGroup(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117916));
		c331769ad21820dd36c2120c10c9a5d36.Add(roomGroup);
		c5b0fb4edd8a21aeb902980c3c0cf5cee(startingRoom, roomGroup);
	}

	private void c5b0fb4edd8a21aeb902980c3c0cf5cee(Room P_0, RoomGroup P_1)
	{
		RoomData roomData = new RoomData(default, P_0);
		P_1.DrawRooms.Add(roomData);
		if (roomData != null)
		{
			roomData.DrawThisRoom = true;
			c720492472ca40f9e3bc65fc4b7ddd376(null, roomData);
			c926f43948ac14aedbe45477d8cba5a08(null, roomData, P_1);
		}
	}

	private RoomData ced5817c77d73b5cd6aad7eac340af37b(Room P_0, RoomGroup P_1)
	{
		RoomData result = null;
		IEnumerator enumerator = P_1.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RoomData roomData = (RoomData)enumerator.Current;
				if (!(P_0.UniqueID == roomData.TheRoom.UniqueID))
				{
					__ldtoken(MapCntrl.ced5817c77d73b5cd6aad7eac340af37b(Room, RoomGroup));
					continue;
				}
				result = roomData;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(MapCntrl.ced5817c77d73b5cd6aad7eac340af37b(Room, RoomGroup));
			}
			else
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	private void c6252017bd9b6c417999feb3c5738abc9(Graphics P_0, RoomGroup P_1)
	{
		if (TheGame == null)
		{
			return;
		}
		IEnumerator enumerator = P_1.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
				RoomData roomData = (RoomData)enumerator.Current;
				if (!roomData.DrawThisRoom)
				{
					continue;
				}
				c720492472ca40f9e3bc65fc4b7ddd376(P_0, roomData);
				IEnumerator enumerator2 = roomData.TheRoom.Exits.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						Exit exit = (Exit)enumerator2.Current;
						RoomData roomData2 = null;
						if (exit.DestinationRoom == null)
						{
							__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
						}
						else
						{
							roomData2 = ced5817c77d73b5cd6aad7eac340af37b(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), P_1);
						}
						if (exit.DestinationRoom == null)
						{
							__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
							continue;
						}
						if (roomData2 == null)
						{
							__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
							continue;
						}
						if (!roomData2.DrawThisRoom)
						{
							__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
							continue;
						}
						switch (exit.Direction)
						{
						case Exit.Directions.North:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X + 50, roomData.pos.Y), new Point(roomData2.pos.X + 50, roomData2.pos.Y + 100));
							break;
						case Exit.Directions.South:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X + 50, roomData.pos.Y + 100), new Point(roomData2.pos.X + 50, roomData2.pos.Y));
							break;
						case Exit.Directions.East:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X + 100, roomData.pos.Y + 50), new Point(roomData2.pos.X, roomData2.pos.Y + 50));
							break;
						case Exit.Directions.West:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X, roomData.pos.Y + 50), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 50));
							break;
						case Exit.Directions.NorthWest:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X, roomData.pos.Y), new Point(roomData2.pos.X + 100, roomData2.pos.Y + 100));
							break;
						case Exit.Directions.NorthEast:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X + 100, roomData.pos.Y), new Point(roomData2.pos.X, roomData2.pos.Y + 100));
							break;
						case Exit.Directions.SouthWest:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X, roomData.pos.Y + 100), new Point(roomData2.pos.X + 100, roomData2.pos.Y));
							break;
						case Exit.Directions.SouthEast:
							P_0.DrawLine(cc4c1bd9ace4c9094852ac3cdb54d532c, new Point(roomData.pos.X + 100, roomData.pos.Y + 100), new Point(roomData2.pos.X, roomData2.pos.Y));
							break;
						}
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.c6252017bd9b6c417999feb3c5738abc9(Graphics, RoomGroup));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c926f43948ac14aedbe45477d8cba5a08(Graphics P_0, RoomData P_1, RoomGroup P_2)
	{
		Point point = default;
		IEnumerator enumerator = P_1.TheRoom.Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				Exit exit = (Exit)enumerator.Current;
				if (exit.DestinationRoom == null)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					continue;
				}
				RoomData roomData = ced5817c77d73b5cd6aad7eac340af37b(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), P_2);
				if (roomData == null)
				{
					if (exit.Direction == Exit.Directions.In)
					{
						__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					}
					else if (exit.Direction == Exit.Directions.Out)
					{
						__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					}
					else if (exit.Direction == Exit.Directions.Up)
					{
						__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					}
					else
					{
						if (exit.Direction != Exit.Directions.Down)
						{
							roomData = new RoomData(default, TheGame.GetRoomByID(new Guid(exit.DestinationRoom)));
							P_2.DrawRooms.Add(roomData);
							goto IL_01ac;
						}
						__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					}
				}
				if (roomData != null)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else if (!cb628c4a9b0443b195a8a7c3927fb5c96(TheGame.GetRoomByID(new Guid(exit.DestinationRoom))))
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else
				{
					RoomGroup roomGroup = new RoomGroup(exit.Direction.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117941) + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name);
					c331769ad21820dd36c2120c10c9a5d36.Add(roomGroup);
					c5b0fb4edd8a21aeb902980c3c0cf5cee(TheGame.GetRoomByID(new Guid(exit.DestinationRoom)), roomGroup);
				}
				goto IL_01ac;
				IL_01ac:
				if (roomData == null)
				{
					continue;
				}
				if (roomData.DrawnAlready)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
					continue;
				}
				switch (exit.Direction)
				{
				case Exit.Directions.North:
					point = new Point(P_1.pos.X, P_1.pos.Y - 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.North, P_2);
					break;
				case Exit.Directions.South:
					point = new Point(P_1.pos.X, P_1.pos.Y + 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.South, P_2);
					break;
				case Exit.Directions.West:
					point = new Point(P_1.pos.X - 120, P_1.pos.Y);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.West, P_2);
					break;
				case Exit.Directions.East:
					point = new Point(P_1.pos.X + 120, P_1.pos.Y);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.East, P_2);
					break;
				case Exit.Directions.NorthEast:
					point = new Point(P_1.pos.X + 120, P_1.pos.Y - 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.NorthEast, P_2);
					break;
				case Exit.Directions.NorthWest:
					point = new Point(P_1.pos.X - 120, P_1.pos.Y - 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.NorthWest, P_2);
					break;
				case Exit.Directions.SouthEast:
					point = new Point(P_1.pos.X + 120, P_1.pos.Y + 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.SouthEast, P_2);
					break;
				case Exit.Directions.SouthWest:
					point = new Point(P_1.pos.X - 120, P_1.pos.Y + 120);
					c0d3a56806c7c0f8feb7eae9900bd3f89(point, Exit.Directions.SouthWest, P_2);
					break;
				}
				roomData.pos = point;
				roomData.DrawThisRoom = true;
				c720492472ca40f9e3bc65fc4b7ddd376(P_0, roomData);
				c926f43948ac14aedbe45477d8cba5a08(P_0, roomData, P_2);
				if (roomData.pos.X + 100 <= P_2.maxx)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else
				{
					P_2.maxx = roomData.pos.X + 100;
				}
				if (roomData.pos.Y + 100 <= P_2.maxy)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else
				{
					P_2.maxy = roomData.pos.Y + 100;
				}
				if (roomData.pos.X >= P_2.minx)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else
				{
					P_2.minx = roomData.pos.X;
				}
				if (roomData.pos.Y >= P_2.miny)
				{
					__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
				}
				else
				{
					P_2.miny = roomData.pos.Y;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(MapCntrl.c926f43948ac14aedbe45477d8cba5a08(Graphics, RoomData, RoomGroup));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c720492472ca40f9e3bc65fc4b7ddd376(Graphics P_0, RoomData P_1)
	{
		if (P_0 == null)
		{
			__ldtoken(MapCntrl.c720492472ca40f9e3bc65fc4b7ddd376(Graphics, RoomData));
		}
		else
		{
			P_0.DrawRectangle(cc4c1bd9ace4c9094852ac3cdb54d532c, new Rectangle(P_1.pos.X, P_1.pos.Y, 100, 100));
			P_0.DrawString(P_1.TheRoom.Name, c0e43349a05a7fbae7001bdcd57489270, (Brush)(object)cc64732ed49c31817ca4fa053816344f7, (float)P_1.pos.X, (float)(P_1.pos.Y + 25));
		}
		P_1.DrawnAlready = true;
	}

	private void c0d3a56806c7c0f8feb7eae9900bd3f89(Point P_0, Exit.Directions P_1, RoomGroup P_2)
	{
		bool flag = false;
		IEnumerator enumerator = P_2.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				RoomData roomData = (RoomData)enumerator.Current;
				if (roomData.pos == P_0)
				{
					flag = true;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (!flag)
		{
			__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
			return;
		}
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		switch (P_1)
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
		IEnumerator enumerator2 = P_2.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				RoomData roomData2 = (RoomData)enumerator2.Current;
				if (!flag2)
				{
					__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				}
				else if (roomData2.pos.Y <= P_0.Y)
				{
					roomData2.pos.Y -= 120;
				}
				if (!flag3)
				{
					__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				}
				else if (roomData2.pos.Y >= P_0.Y)
				{
					roomData2.pos.Y += 120;
				}
				if (!flag5)
				{
					__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				}
				else if (roomData2.pos.X <= P_0.X)
				{
					roomData2.pos.X -= 120;
				}
				if (!flag4)
				{
					__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				}
				else if (roomData2.pos.X < P_0.X)
				{
					__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
				}
				else
				{
					roomData2.pos.X += 120;
				}
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.c0d3a56806c7c0f8feb7eae9900bd3f89(Point, Exit.Directions, RoomGroup));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c99d2d87909f5985fa0ab1c17cf5b6fe6(object P_0, EventArgs P_1)
	{
		Graphics val = ((Control)c5e74b6ad19335af023c0fb124e8b9948).CreateGraphics();
		val.Clear(((Control)c5e74b6ad19335af023c0fb124e8b9948).BackColor);
		RoomGroup roomGroup = null;
		IEnumerator enumerator = c331769ad21820dd36c2120c10c9a5d36.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
				RoomGroup roomGroup2 = (RoomGroup)enumerator.Current;
				if (!(roomGroup2.MapGroupName == c01e034a3fd0ce41ce875d855434fcb44.SelectedItem.ToString()))
				{
					__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
					continue;
				}
				roomGroup = roomGroup2;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (roomGroup == null)
		{
			__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
			return;
		}
		if (((Control)c5e74b6ad19335af023c0fb124e8b9948).Width == roomGroup.maxx)
		{
			__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
		}
		else
		{
			((Control)c5e74b6ad19335af023c0fb124e8b9948).Width = roomGroup.maxx + 20;
		}
		if (((Control)c5e74b6ad19335af023c0fb124e8b9948).Height == roomGroup.maxy)
		{
			__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
		}
		else
		{
			((Control)c5e74b6ad19335af023c0fb124e8b9948).Height = roomGroup.maxy + 20;
		}
		IEnumerator enumerator2 = roomGroup.DrawRooms.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
				RoomData roomData = (RoomData)enumerator2.Current;
				roomData.DrawnAlready = false;
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.c99d2d87909f5985fa0ab1c17cf5b6fe6(object, EventArgs));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		c6252017bd9b6c417999feb3c5738abc9(val, roomGroup);
	}

	private bool cb628c4a9b0443b195a8a7c3927fb5c96(Room P_0)
	{
		IEnumerator enumerator = c331769ad21820dd36c2120c10c9a5d36.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(MapCntrl.cb628c4a9b0443b195a8a7c3927fb5c96(Room));
				RoomGroup roomGroup = (RoomGroup)enumerator.Current;
				IEnumerator enumerator2 = roomGroup.DrawRooms.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(MapCntrl.cb628c4a9b0443b195a8a7c3927fb5c96(Room));
						RoomData roomData = (RoomData)enumerator2.Current;
						if (!(roomData.TheRoom.UniqueID == P_0.UniqueID))
						{
							__ldtoken(MapCntrl.cb628c4a9b0443b195a8a7c3927fb5c96(Room));
							continue;
						}
						return false;
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(MapCntrl.cb628c4a9b0443b195a8a7c3927fb5c96(Room));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(MapCntrl.cb628c4a9b0443b195a8a7c3927fb5c96(Room));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		return true;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(MapCntrl.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		c5e74b6ad19335af023c0fb124e8b9948 = new Panel();
		c01e034a3fd0ce41ce875d855434fcb44 = new ComboBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		((Control)this).SuspendLayout();
		((ScrollableControl)c5e74b6ad19335af023c0fb124e8b9948).AutoScroll = true;
		c5e74b6ad19335af023c0fb124e8b9948.BorderStyle = (BorderStyle)1;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Location = new Point(3, 49);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Size = new Size(347, 208);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).TabIndex = 0;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Paint += c4edcfbb487de8181f0e3e23eb12eb842;
		((ListControl)c01e034a3fd0ce41ce875d855434fcb44).FormattingEnabled = true;
		((Control)c01e034a3fd0ce41ce875d855434fcb44).Location = new Point(3, 22);
		((Control)c01e034a3fd0ce41ce875d855434fcb44).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117950);
		((Control)c01e034a3fd0ce41ce875d855434fcb44).Size = new Size(191, 21);
		((Control)c01e034a3fd0ce41ce875d855434fcb44).TabIndex = 1;
		c01e034a3fd0ce41ce875d855434fcb44.SelectedIndexChanged += c99d2d87909f5985fa0ab1c17cf5b6fe6;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(3, 6);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(64, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 2;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117963);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((ScrollableControl)this).AutoScroll = true;
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c01e034a3fd0ce41ce875d855434fcb44);
		((Control)this).Controls.Add((Control)(object)c5e74b6ad19335af023c0fb124e8b9948);
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(117986);
		((Control)this).Size = new Size(356, 260);
		((UserControl)this).Load += c08032fea21d8eca3afe5bd3627f7f737;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
