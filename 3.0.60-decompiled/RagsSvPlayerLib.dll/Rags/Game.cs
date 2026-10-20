using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Game
{
	public enum SortOrder
	{
		SO_NATURAL,
		SO_ALPHA,
		SO_LILO
	}

	public static string InitialJavaScript = "<script>function getVerticalScrollPosition() {\r\nreturn document.body.scrollTop.toString();\r\n}\r\nfunction setVerticalScrollPosition(position) {\r\ndocument.body.scrollTop = position;\r\n}\r\nfunction pagedown(){\r\ndocument.body.scrollTop = document.body.scrollTop + document.body.clientHeight;\r\n}\r\nfunction atbottom()\r\n{\r\nif ((document.body.scrollTop + document.body.clientHeight) >= document.body.scrollHeight)\r\n    return true;\r\nelse\r\n{\r\n\r\nreturn false;\r\n}\r\n\r\n}\r\n</script>";

	public StringBuilder TheContent = new StringBuilder();

	public static int PercentageComplete = 0;

	public string GameFont = "Microsoft Sans Serif";

	public static bool bUpgrading = false;

	public static string ObjectVersionNumber;

	public static string CurrentObjectVersionNumber = string.Empty;

	public bool bPasswordProtected;

	public string GamePassword = string.Empty;

	public SortOrder SortOrderRoomObjects;

	public SortOrder SortOrderCharacters;

	public SortOrder SortOrderInventory;

	public List<QuickMenuItem> QuickCommands = new List<QuickMenuItem>();

	private List<object> m_a = new List<object>();

	[CompilerGenerated]
	private List<Room> m_b;

	[CompilerGenerated]
	private Player m_c;

	[CompilerGenerated]
	private List<GamePicture> m_d;

	[CompilerGenerated]
	private List<GameObject> m_e;

	[CompilerGenerated]
	private List<GameVariable> m_f;

	[CompilerGenerated]
	private List<Character> m_g;

	[CompilerGenerated]
	private List<Timer> m_h;

	[CompilerGenerated]
	private List<StatusBarItem> m_i;

	[CompilerGenerated]
	private List<string> m_j;

	[CompilerGenerated]
	private List<string> m_k;

	[CompilerGenerated]
	private string m_l;

	[CompilerGenerated]
	private string m;

	[CompilerGenerated]
	private string n;

	[CompilerGenerated]
	private int o;

	[CompilerGenerated]
	private bool p;

	[CompilerGenerated]
	private bool q;

	[CompilerGenerated]
	private bool r;

	[CompilerGenerated]
	private string s;

	[CompilerGenerated]
	private bool t;

	[CompilerGenerated]
	private bool u;

	[CompilerGenerated]
	private string v;

	[CompilerGenerated]
	private string w;

	[CompilerGenerated]
	private string x;

	public List<Room> RoomList
	{
		[CompilerGenerated]
		get
		{
			return this.m_b;
		}
		[CompilerGenerated]
		set
		{
			this.m_b = value;
		}
	}

	public Player ThePlayer
	{
		[CompilerGenerated]
		get
		{
			return this.m_c;
		}
		[CompilerGenerated]
		set
		{
			this.m_c = value;
		}
	}

	public List<GamePicture> PictureList
	{
		[CompilerGenerated]
		get
		{
			return this.m_d;
		}
		[CompilerGenerated]
		set
		{
			this.m_d = value;
		}
	}

	public List<GameObject> ObjectList
	{
		[CompilerGenerated]
		get
		{
			return this.m_e;
		}
		[CompilerGenerated]
		set
		{
			this.m_e = value;
		}
	}

	public List<GameVariable> VariableList
	{
		[CompilerGenerated]
		get
		{
			return this.m_f;
		}
		[CompilerGenerated]
		set
		{
			this.m_f = value;
		}
	}

	public List<Character> CharacterList
	{
		[CompilerGenerated]
		get
		{
			return this.m_g;
		}
		[CompilerGenerated]
		set
		{
			this.m_g = value;
		}
	}

	public List<Timer> TimerList
	{
		[CompilerGenerated]
		get
		{
			return this.m_h;
		}
		[CompilerGenerated]
		set
		{
			this.m_h = value;
		}
	}

	public List<StatusBarItem> StatusBarItems
	{
		[CompilerGenerated]
		get
		{
			return this.m_i;
		}
		[CompilerGenerated]
		set
		{
			this.m_i = value;
		}
	}

	public List<string> LayeredClothingZones
	{
		[CompilerGenerated]
		get
		{
			return this.m_j;
		}
		[CompilerGenerated]
		set
		{
			this.m_j = value;
		}
	}

	public List<string> RoomGroups
	{
		[CompilerGenerated]
		get
		{
			return this.m_k;
		}
		[CompilerGenerated]
		set
		{
			this.m_k = value;
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return this.m_l;
		}
		[CompilerGenerated]
		set
		{
			this.m_l = value;
		}
	}

	public string OpeningMessage
	{
		[CompilerGenerated]
		get
		{
			return m;
		}
		[CompilerGenerated]
		set
		{
			m = value;
		}
	}

	public string AdditionalData
	{
		[CompilerGenerated]
		get
		{
			return n;
		}
		[CompilerGenerated]
		set
		{
			n = value;
		}
	}

	public int TurnCount
	{
		[CompilerGenerated]
		get
		{
			return o;
		}
		[CompilerGenerated]
		set
		{
			o = value;
		}
	}

	public bool bHideMainPicDisplay
	{
		[CompilerGenerated]
		get
		{
			return p;
		}
		[CompilerGenerated]
		set
		{
			p = value;
		}
	}

	public bool bUseInlineImages
	{
		[CompilerGenerated]
		get
		{
			return q;
		}
		[CompilerGenerated]
		set
		{
			q = value;
		}
	}

	public bool bHidePortrait
	{
		[CompilerGenerated]
		get
		{
			return r;
		}
		[CompilerGenerated]
		set
		{
			r = value;
		}
	}

	public string bgMusic
	{
		[CompilerGenerated]
		get
		{
			return s;
		}
		[CompilerGenerated]
		set
		{
			s = value;
		}
	}

	public bool bRepeatbgMusic
	{
		[CompilerGenerated]
		get
		{
			return t;
		}
		[CompilerGenerated]
		set
		{
			t = value;
		}
	}

	public bool bTurnOffNotifications
	{
		[CompilerGenerated]
		get
		{
			return u;
		}
		[CompilerGenerated]
		set
		{
			u = value;
		}
	}

	public string AuthorName
	{
		[CompilerGenerated]
		get
		{
			return v;
		}
		[CompilerGenerated]
		set
		{
			v = value;
		}
	}

	public string GameVersion
	{
		[CompilerGenerated]
		get
		{
			return w;
		}
		[CompilerGenerated]
		set
		{
			w = value;
		}
	}

	public string GameInformation
	{
		[CompilerGenerated]
		get
		{
			return x;
		}
		[CompilerGenerated]
		set
		{
			x = value;
		}
	}

	public Game()
	{
		RoomList = new List<Room>();
		ThePlayer = new Player();
		PictureList = new List<GamePicture>();
		ObjectList = new List<GameObject>();
		VariableList = new List<GameVariable>();
		CharacterList = new List<Character>();
		TimerList = new List<Timer>();
		StatusBarItems = new List<StatusBarItem>();
		LayeredClothingZones = new List<string>();
		RoomGroups = new List<string>();
		Title = string.Empty;
		OpeningMessage = string.Empty;
		AdditionalData = string.Empty;
		TurnCount = 0;
		bHideMainPicDisplay = false;
		bUseInlineImages = false;
		bHidePortrait = false;
		bgMusic = string.Empty;
		bRepeatbgMusic = false;
		bTurnOffNotifications = false;
		AuthorName = string.Empty;
		GameVersion = "1.0";
		GameInformation = string.Empty;
		LayeredClothingZones.Add("Upper Body");
		LayeredClothingZones.Add("Mid Body");
		LayeredClothingZones.Add("Lower Body");
		TheContent.Clear();
		TheContent.Append(InitialJavaScript);
	}

	public static void AddXMLSection(ref StreamWriter CurDoc, string titlename, string value)
	{
		CurDoc.WriteLine("<" + titlename + ">");
		CurDoc.WriteLine($"<![CDATA[{value}]]>");
		CurDoc.WriteLine("</" + titlename + ">");
	}

	public static void AddXMLSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append($"<![CDATA[{value}]]>");
		CurDoc.Append("</" + titlename + ">");
	}

	public static void AddAdvSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append(value);
		CurDoc.Append("</" + titlename + ">\r\n");
	}

	public Room GetRoomForValidation(string rmid)
	{
		Room room = null;
		try
		{
			return GetRoomByID(new Guid(rmid));
		}
		catch
		{
			return null;
		}
	}

	public void RemoveRoomObject(Guid RoomID, string ObjectName)
	{
		Room roomByID = GetRoomByID(RoomID);
		if (roomByID == null)
		{
			return;
		}
		foreach (GameObject @object in ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == RoomID.ToString() && @object.name == ObjectName)
			{
				@object.locationtype = GameObject.LocationType.LT_NULL;
			}
		}
	}

	public GameVariable GetVariableByName(string varname)
	{
		if (varname.IndexOf("(") > -1)
		{
			varname = varname.Substring(0, varname.IndexOf("("));
		}
		for (int i = 0; i < VariableList.Count; i++)
		{
			if (string.Compare(varname, VariableList[i].varname, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return VariableList[i];
			}
		}
		return null;
	}

	public StatusBarItem GetStatusBarItemByName(string name)
	{
		for (int i = 0; i < StatusBarItems.Count; i++)
		{
			if (string.Compare(name, StatusBarItems[i].Name, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return StatusBarItems[i];
			}
		}
		return null;
	}

	public Room GetRoomByName(string roomname)
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			if (string.Compare(roomname, RoomList[i].Name, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return RoomList[i];
			}
		}
		return null;
	}

	public Room GetRoomByID(Guid roomid)
	{
		foreach (Room room in RoomList)
		{
			if (roomid.CompareTo(room.UniqueID) == 0)
			{
				return room;
			}
		}
		return null;
	}

	public Character GetCharacterByName(string charname)
	{
		for (int i = 0; i < CharacterList.Count; i++)
		{
			if (string.Compare(charname, CharacterList[i].Charname, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return CharacterList[i];
			}
		}
		return null;
	}

	public GameObject GetObjectByName(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			if (string.Compare(objectname, ObjectList[i].UniqueIdentifier.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
			{
				return ObjectList[i];
			}
		}
		return null;
	}

	public GameObject GetObjectByNameOld(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			if (string.Compare(objectname, ObjectList[i].name, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return ObjectList[i];
			}
		}
		return null;
	}

	public QuickMenuItem GetMenuItemByName(string mnuitemguid)
	{
		for (int i = 0; i < QuickCommands.Count; i++)
		{
			if (string.Compare(mnuitemguid, QuickCommands[i].UniqueID.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
			{
				return QuickCommands[i];
			}
		}
		return null;
	}

	public Timer GetTimerByName(string timername)
	{
		for (int i = 0; i < TimerList.Count; i++)
		{
			if (string.Compare(timername, TimerList[i].Name, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return TimerList[i];
			}
		}
		return null;
	}

	public void MovePlayer(Exit.Directions dir)
	{
		for (int i = 0; i < ThePlayer.CurrentRoom.Exits.Count; i++)
		{
			Exit exit = ThePlayer.CurrentRoom.Exits[i];
			if (exit.Direction == dir)
			{
				ThePlayer.CurrentRoom = GetRoomByID(new Guid(exit.DestinationRoom));
				break;
			}
		}
	}

	public static void CorrectAction(ref Action tempact)
	{
		for (int i = 0; i < tempact.PassCommands.Count; i++)
		{
			Command tempcmd = tempact.PassCommands[i] as Command;
			Condition tempcond = tempact.PassCommands[i] as Condition;
			if (tempcmd != null)
			{
				CorrectCommand(ref tempcmd);
			}
			else if (tempcond != null)
			{
				CorrectCondition(ref tempcond);
			}
		}
		for (int j = 0; j < tempact.FailCommands.Count; j++)
		{
			Command tempcmd2 = tempact.FailCommands[j] as Command;
			Condition tempcond2 = tempact.FailCommands[j] as Condition;
			if (tempcmd2 != null)
			{
				CorrectCommand(ref tempcmd2);
			}
			else if (tempcond2 != null)
			{
				CorrectCondition(ref tempcond2);
			}
		}
		for (int k = 0; k < tempact.Conditions.Count; k++)
		{
			Condition tempcond3 = tempact.Conditions[k];
			CorrectCondition(ref tempcond3);
		}
	}

	public static void CorrectCondition(ref Condition tempcond)
	{
		for (int i = 0; i < tempcond.Checks.Count; i++)
		{
			Check tempchk = tempcond.Checks[i];
			CorrectCheck(ref tempchk);
		}
		for (int j = 0; j < tempcond.PassCommands.Count; j++)
		{
			Command tempcmd = tempcond.PassCommands[j] as Command;
			Condition tempcond2 = tempcond.PassCommands[j] as Condition;
			if (tempcmd != null)
			{
				CorrectCommand(ref tempcmd);
			}
			if (tempcond2 != null)
			{
				CorrectCondition(ref tempcond2);
			}
		}
		for (int k = 0; k < tempcond.FailCommands.Count; k++)
		{
			Command tempcmd2 = tempcond.FailCommands[k] as Command;
			Condition tempcond3 = tempcond.FailCommands[k] as Condition;
			if (tempcmd2 != null)
			{
				CorrectCommand(ref tempcmd2);
			}
			if (tempcond3 != null)
			{
				CorrectCondition(ref tempcond3);
			}
		}
	}

	public static void CorrectCheck(ref Check tempchk)
	{
		tempchk.ConditionStep2 = UpdateStringToHTML(tempchk.ConditionStep2);
		tempchk.ConditionStep3 = UpdateStringToHTML(tempchk.ConditionStep3);
		tempchk.ConditionStep4 = UpdateStringToHTML(tempchk.ConditionStep4);
	}

	public static void CorrectCommand(ref Command tempcmd)
	{
		tempcmd.CommandPart2 = UpdateStringToHTML(tempcmd.CommandPart2);
		tempcmd.CommandPart3 = UpdateStringToHTML(tempcmd.CommandPart3);
		tempcmd.CommandPart4 = UpdateStringToHTML(tempcmd.CommandPart4);
		tempcmd.CommandText = UpdateStringToHTML(tempcmd.CommandText);
	}

	public static string UpdateStringToHTML(string data)
	{
		string text = data.Replace("[b]", "<b>");
		text = text.Replace("[/b]", "</b>");
		text = text.Replace("[i]", "<i>");
		text = text.Replace("[/i]", "</i>");
		text = text.Replace("\r\n", "<br/>");
		text = text.Replace("\n", "<br/>");
		int num = text.IndexOf("[c ");
		while (num > -1)
		{
			int num2 = text.IndexOf("]", num) + 1;
			if (num2 != 0)
			{
				string text2 = text.Substring(num, num2 - num);
				if (text2.Contains(","))
				{
					text2 = text2.Replace("[c ", "<span style=\"color:rgb(");
					text2 = text2.Replace("]", ")\">");
				}
				else
				{
					text2 = text2.Replace("[c ", "<span style=\"color:");
					text2 = text2.Replace("]", "\">");
				}
				text = text.Remove(num, num2 - num);
				text = text.Insert(num, text2);
				num = text.IndexOf("[c ");
			}
			else
			{
				num = text.IndexOf("[c ", num + 2);
			}
		}
		text = text.Replace("[/c]", "</span>");
		for (num = text.IndexOf("[f "); num > -1; num = text.IndexOf("[f "))
		{
			int num3 = text.IndexOf("]", num) + 1;
			if (num3 != -1)
			{
				string text3 = text.Substring(num, num3 - num);
				if (text3.Contains(","))
				{
					string text4 = text3.Substring(2, text3.Length - 3);
					string[] array = text4.Split(new string[1] { "," }, StringSplitOptions.None);
					text3 = "<span style=\"font-family:" + array[0] + ";font size:" + array[1] + "\">";
				}
				text = text.Remove(num, num3 - num);
				text = text.Insert(num, text3);
			}
		}
		text = text.Replace("[/f]", "</span>");
		text = text.Replace("[middle]", "<center>");
		text = text.Replace("[/middle]", "</center>");
		text = text.Replace("[u]", "<u>");
		return text.Replace("[/u]", "</u>");
	}

	private string a(ref Action A_0, ref Game A_1)
	{
		string text = string.Empty;
		for (int i = 0; i < A_0.PassCommands.Count; i++)
		{
			Command tempcmd = A_0.PassCommands[i] as Command;
			Condition condition = A_0.PassCommands[i] as Condition;
			if (tempcmd != null)
			{
				text += Command.ValidateCommand(ref tempcmd, ref A_1);
			}
		}
		for (int j = 0; j < A_0.FailCommands.Count; j++)
		{
			Command tempcmd2 = A_0.FailCommands[j] as Command;
			Condition condition2 = A_0.FailCommands[j] as Condition;
			if (tempcmd2 != null)
			{
				text += Command.ValidateCommand(ref tempcmd2, ref A_1);
			}
		}
		for (int k = 0; k < A_0.Conditions.Count; k++)
		{
			bool flag = false;
			Condition condition3 = A_0.Conditions[k];
			for (int l = 0; l < condition3.Checks.Count; l++)
			{
				Check tempcheck = condition3.Checks[l];
				string text2 = Check.ValidateCheck(ref tempcheck, ref A_1);
				if (text2.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
					}
					text += text2;
				}
			}
			for (int m = 0; m < condition3.PassCommands.Count; m++)
			{
				Command tempcmd3 = condition3.PassCommands[m] as Command;
				Condition condition4 = condition3.PassCommands[m] as Condition;
				if (tempcmd3 == null)
				{
					continue;
				}
				string text3 = Command.ValidateCommand(ref tempcmd3, ref A_1);
				if (text3.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
					}
					text += text3;
				}
			}
			for (int n = 0; n < condition3.FailCommands.Count; n++)
			{
				Command tempcmd4 = condition3.FailCommands[n] as Command;
				Condition condition5 = condition3.FailCommands[n] as Condition;
				if (tempcmd4 == null)
				{
					continue;
				}
				string text4 = Command.ValidateCommand(ref tempcmd4, ref A_1);
				if (text4.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
					}
					text += text4;
				}
			}
		}
		return text;
	}

	public string ValidateCommandsAndConditions()
	{
		bool flag = false;
		string text = string.Empty;
		for (int i = 0; i < RoomList.Count; i++)
		{
			Room room = RoomList[i];
			flag = false;
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Action A_ = room.Actions[j];
				Game A_2 = this;
				string text2 = a(ref A_, ref A_2);
				if (text2.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in room " + room.Name + " Actions\r\n";
					}
					text += text2;
				}
			}
			for (int k = 0; k < room.Exits.Count; k++)
			{
				Exit exit = room.Exits[k];
				if (exit != null && exit.bActive && exit.DestinationRoom == null)
				{
					exit.bActive = false;
				}
			}
		}
		for (int l = 0; l < ObjectList.Count; l++)
		{
			GameObject gameObject = ObjectList[l];
			flag = false;
			for (int m = 0; m < gameObject.Actions.Count; m++)
			{
				Action A_3 = gameObject.Actions[m];
				Game A_4 = this;
				string text3 = a(ref A_3, ref A_4);
				if (text3.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Object " + gameObject.name + " Actions\r\n";
					}
					text += text3;
				}
			}
		}
		flag = false;
		for (int n = 0; n < ThePlayer.Actions.Count; n++)
		{
			Action A_5 = ThePlayer.Actions[n];
			Game A_6 = this;
			string text4 = a(ref A_5, ref A_6);
			if (text4.Length > 0)
			{
				if (!flag)
				{
					flag = true;
					text += "Problem/s in Player Actions\r\n";
				}
				text += text4;
			}
		}
		for (int num = 0; num < CharacterList.Count; num++)
		{
			Character character = CharacterList[num];
			flag = false;
			for (int num2 = 0; num2 < character.Actions.Count; num2++)
			{
				Action A_7 = character.Actions[num2];
				Game A_8 = this;
				string text5 = a(ref A_7, ref A_8);
				if (text5.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Character " + character.Charname + " Actions\r\n";
					}
					text += text5;
				}
			}
		}
		for (int num3 = 0; num3 < TimerList.Count; num3++)
		{
			Timer timer = TimerList[num3];
			flag = false;
			for (int num4 = 0; num4 < timer.Actions.Count; num4++)
			{
				Action A_9 = timer.Actions[num4];
				Game A_10 = this;
				string text6 = a(ref A_9, ref A_10);
				if (text6.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Timer " + timer.Name + " Actions\r\n";
					}
					text += text6;
				}
			}
		}
		return text;
	}

	public void RefactorObject(string oldname, string newname)
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			Room room = RoomList[i];
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Action tempact = room.Actions[j];
				RefactorAction(ref tempact, oldname, newname);
			}
		}
		for (int k = 0; k < ObjectList.Count; k++)
		{
			GameObject gameObject = ObjectList[k];
			for (int l = 0; l < gameObject.Actions.Count; l++)
			{
				Action tempact2 = gameObject.Actions[l];
				RefactorAction(ref tempact2, oldname, newname);
			}
		}
		for (int m = 0; m < ThePlayer.Actions.Count; m++)
		{
			Action tempact3 = ThePlayer.Actions[m];
			RefactorAction(ref tempact3, oldname, newname);
		}
		for (int n = 0; n < CharacterList.Count; n++)
		{
			Character character = CharacterList[n];
			for (int num = 0; num < character.Actions.Count; num++)
			{
				Action tempact4 = character.Actions[num];
				RefactorAction(ref tempact4, oldname, newname);
			}
		}
		for (int num2 = 0; num2 < TimerList.Count; num2++)
		{
			Timer timer = TimerList[num2];
			for (int num3 = 0; num3 < timer.Actions.Count; num3++)
			{
				Action tempact5 = timer.Actions[num3];
				RefactorAction(ref tempact5, oldname, newname);
			}
		}
	}

	public void RefactorAction(ref Action tempact, string oldname, string newname)
	{
		for (int i = 0; i < tempact.PassCommands.Count; i++)
		{
			Command A_ = tempact.PassCommands[i] as Command;
			Condition A_2 = tempact.PassCommands[i] as Condition;
			if (A_ != null)
			{
				a(ref A_, oldname, newname);
			}
			else
			{
				a(ref A_2, oldname, newname);
			}
		}
		for (int j = 0; j < tempact.FailCommands.Count; j++)
		{
			Command A_3 = tempact.FailCommands[j] as Command;
			Condition A_4 = tempact.FailCommands[j] as Condition;
			if (A_3 != null)
			{
				a(ref A_3, oldname, newname);
			}
			else
			{
				a(ref A_4, oldname, newname);
			}
		}
		for (int k = 0; k < tempact.Conditions.Count; k++)
		{
			Condition A_5 = tempact.Conditions[k];
			a(ref A_5, oldname, newname);
		}
	}

	private void a(ref Condition A_0, string A_1, string A_2)
	{
		for (int i = 0; i < A_0.Checks.Count; i++)
		{
			Check A_3 = A_0.Checks[i];
			a(ref A_3, A_1, A_2);
		}
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command A_4 = A_0.PassCommands[j] as Command;
			Condition A_5 = A_0.PassCommands[j] as Condition;
			if (A_4 != null)
			{
				a(ref A_4, A_1, A_2);
			}
			else
			{
				a(ref A_5, A_1, A_2);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command A_6 = A_0.FailCommands[k] as Command;
			Condition A_7 = A_0.FailCommands[k] as Condition;
			if (A_6 != null)
			{
				a(ref A_6, A_1, A_2);
			}
			else
			{
				a(ref A_7, A_1, A_2);
			}
		}
	}

	private void a(ref Check A_0, string A_1, string A_2)
	{
		if (A_0.ConditionStep2 == A_1)
		{
			A_0.ConditionStep2 = A_2;
		}
		if (A_0.ConditionStep3 == A_1)
		{
			A_0.ConditionStep3 = A_2;
		}
		if (A_0.ConditionStep4 == A_1)
		{
			A_0.ConditionStep4 = A_2;
		}
	}

	private void a(ref Command A_0, string A_1, string A_2)
	{
		if (A_0.CommandPart2 == A_1)
		{
			A_0.CommandPart2 = A_2;
		}
		if (A_0.CommandPart3 == A_1)
		{
			A_0.CommandPart3 = A_2;
		}
		if (A_0.CommandPart4 == A_1)
		{
			A_0.CommandPart4 = A_2;
		}
		if (A_0.CommandText == A_1)
		{
			A_0.CommandText = A_2;
		}
	}

	private string a(ref GameVariable A_0)
	{
		bool flag = false;
		bool flag2 = true;
		switch (A_0.vartype)
		{
		case GameVariable.VarType.VT_NUMBERARRAY:
			flag2 = false;
			flag = true;
			break;
		case GameVariable.VarType.VT_STRINGARRAY:
		case GameVariable.VarType.VT_DATETIMEARRAY:
			flag = true;
			break;
		}
		if (!flag)
		{
			return string.Empty;
		}
		string text = string.Empty;
		try
		{
			int num = -1;
			text = "[";
			for (int i = 0; i < A_0.VarArray.Count; i++)
			{
				num++;
				if (num > 0)
				{
					text += ",";
				}
				if (!(A_0.VarArray[i] is List<string> list))
				{
					text = ((!flag2) ? (text + A_0.VarArray[i].ToString()) : (text + "\"" + A_0.VarArray[i].ToString().Replace("\"", "\\\"") + "\""));
					continue;
				}
				text += "[";
				int num2 = -1;
				foreach (string item in list)
				{
					num2++;
					string text2 = string.Empty;
					if (item != null)
					{
						text2 = item.ToString();
					}
					if (num2 > 0)
					{
						text += ",";
					}
					text = ((!flag2) ? (text + text2.ToString()) : (text + "\"" + text2.ToString().Replace("\"", "\\\"") + "\""));
				}
				text += "]";
			}
			text += "];";
		}
		catch
		{
		}
		return text;
	}

	private void l(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 3);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		int num2 = A_0.IndexOf("(", A_1, StringComparison.OrdinalIgnoreCase);
		if (num2 < num && num2 != -1)
		{
			int num3 = A_0.IndexOf(")", A_1, StringComparison.OrdinalIgnoreCase);
			if (num3 == -1)
			{
				return;
			}
			string text = A_0.Substring(A_1, num2 - A_1).Trim();
			if (num3 - (num2 + 1) < 0)
			{
				return;
			}
			string text2 = A_0.Substring(num2 + 1, num3 - (num2 + 1)).Trim();
			int num4 = 0;
			try
			{
				num4 = Convert.ToInt32(PerformTextReplacements(text2, null));
			}
			catch
			{
				num4 = -1;
			}
			int num5 = A_0.IndexOf(")", num3 + 1, StringComparison.OrdinalIgnoreCase);
			int num6 = -1;
			if (num5 != -1)
			{
				try
				{
					string text3 = A_0.Substring(num3 + 2, num5 - (num3 + 2));
					num6 = Convert.ToInt32(PerformTextReplacements(text3, null));
				}
				catch
				{
					num6 = -1;
					num5 = -1;
				}
			}
			if (num4 <= -1)
			{
				return;
			}
			string text4 = string.Empty;
			if (text.IndexOf(":") > -1)
			{
				text4 = text.Substring(text.IndexOf(":") + 1);
				text = text.Substring(0, text.IndexOf(":"));
			}
			GameVariable variableByName = GetVariableByName(text);
			if (variableByName == null)
			{
				return;
			}
			int num7 = 0;
			num7 = ((num5 <= -1) ? (num3 - A_1 + 2) : (num5 - A_1 + 2));
			A_0 = A_0.Remove(A_1, num7);
			if (num4 >= variableByName.VarArray.Count)
			{
				return;
			}
			string value = string.Empty;
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_NUMBERARRAY:
			case GameVariable.VarType.VT_STRINGARRAY:
				if (num6 > -1)
				{
					try
					{
						value = ((List<string>)variableByName.VarArray[num4])[num6].ToString();
						if (flag)
						{
							((List<string>)variableByName.VarArray[num4])[num6] = A_2;
						}
					}
					catch
					{
						value = "<invalid variable reference>";
					}
					break;
				}
				value = variableByName.VarArray[num4].ToString();
				if (flag)
				{
					if (variableByName.vartype == GameVariable.VarType.VT_NUMBERARRAY)
					{
						variableByName.VarArray[num4] = Convert.ToDouble(A_2);
					}
					else
					{
						variableByName.VarArray[num4] = A_2;
					}
				}
				break;
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (num6 > -1)
				{
					string value2 = ((List<object>)variableByName.VarArray[num4])[num6].ToString();
					if (flag)
					{
						((List<object>)variableByName.VarArray[num4])[num6] = A_2;
					}
					DateTime dateTime = Convert.ToDateTime(value2);
					value = ((!(text4 != string.Empty)) ? dateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") : dateTime.ToString(text4));
				}
				else if (text4 != string.Empty)
				{
					value = ((DateTime)variableByName.VarArray[num4]).ToString(text4);
					if (flag)
					{
						try
						{
							variableByName.VarArray[num4] = Convert.ToDateTime(A_2);
						}
						catch
						{
							variableByName.VarArray[num4] = "bad value";
						}
					}
				}
				else
				{
					value = ((DateTime)variableByName.VarArray[num4]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt");
				}
				break;
			}
			if (!flag)
			{
				A_0 = A_0.Insert(A_1, value);
			}
		}
		else
		{
			if (num <= -1)
			{
				return;
			}
			string text5 = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			string text6 = string.Empty;
			if (text5.IndexOf(":") > -1)
			{
				text6 = text5.Substring(text5.IndexOf(":") + 1);
				text5 = text5.Substring(0, text5.IndexOf(":"));
			}
			GameVariable variableByName2 = GetVariableByName(text5);
			if (variableByName2 == null)
			{
				return;
			}
			string text7 = string.Empty;
			switch (variableByName2.vartype)
			{
			case GameVariable.VarType.VT_NUMBER:
				text7 = variableByName2.dNumType.ToString();
				if (flag)
				{
					try
					{
						variableByName2.dNumType = Convert.ToDouble(A_2);
					}
					catch
					{
						variableByName2.dNumType = -1.0;
					}
				}
				break;
			case GameVariable.VarType.VT_STRING:
				text7 = variableByName2.sString;
				if (flag)
				{
					variableByName2.sString = A_2;
				}
				break;
			case GameVariable.VarType.VT_DATETIME:
				if (text6 != string.Empty)
				{
					text7 = variableByName2.dtDateTime.ToString(text6);
					if (flag)
					{
						try
						{
							variableByName2.dtDateTime = Convert.ToDateTime(A_2);
						}
						catch
						{
							variableByName2.dtDateTime = DateTime.Now;
						}
					}
					break;
				}
				text7 = variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt");
				if (flag)
				{
					try
					{
						variableByName2.dtDateTime = Convert.ToDateTime(A_2);
					}
					catch
					{
						variableByName2.dtDateTime = DateTime.Now;
					}
				}
				break;
			}
			if (flag)
			{
				text7 = PerformTextReplacements(text7, null);
			}
			A_0 = A_0.Insert(A_1, text7);
		}
	}

	private void a(ref string A_0, int A_1, string A_2, ref object A_3)
	{
		if (A_1 >= 0 && A_2.Contains("[PLAYERNAME]"))
		{
			A_0 = A_0.Remove(A_1, 12);
			A_0 = A_0.Insert(A_1, ThePlayer.Name);
			A_1 = A_0.IndexOf("[playername", 0, StringComparison.OrdinalIgnoreCase);
		}
		if (A_1 >= 0 && A_2.Contains("[INPUTDATA]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			A_0 = A_0.Insert(A_1, AdditionalData);
			A_1 = A_0.IndexOf("[inputdata]", 0, StringComparison.OrdinalIgnoreCase);
		}
		if (A_1 >= 0 && A_2.Contains("[MAXCARRY]"))
		{
			A_0 = A_0.Remove(A_1, 10);
			A_0 = A_0.Insert(A_1, ThePlayer.dWeightLimit.ToString());
			A_1 = A_0.IndexOf("[maxcarry]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[TURNS]"))
		{
			A_0 = A_0.Remove(A_1, 7);
			A_0 = A_0.Insert(A_1, TurnCount.ToString());
			A_1 = A_0.IndexOf("[turns]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[CURRENTCARRY]"))
		{
			A_0 = A_0.Remove(A_1, 14);
			double num = 0.0;
			foreach (GameObject @object in ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_PLAYER)
				{
					num += GetItemWeight(@object.UniqueIdentifier);
				}
			}
			A_0 = A_0.Insert(A_1, num.ToString());
			A_1 = A_0.IndexOf("[currentcarry]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[MAN/WOMAN]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "woman");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "man");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "thing");
				break;
			}
			A_1 = A_0.IndexOf("[man/woman]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[MALE/FEMALE]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "female");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "male");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "other");
				break;
			}
			A_1 = A_0.IndexOf("[male/female]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[BOY/GIRL]"))
		{
			A_0 = A_0.Remove(A_1, 10);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "girl");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "boy");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "thing");
				break;
			}
			A_1 = A_0.IndexOf("[boy/girl]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[LEN("))
		{
			A_1 = A_0.IndexOf("[LEN(", 0, StringComparison.OrdinalIgnoreCase);
			GameVariable gameVariable = null;
			int num2 = A_0.IndexOf(")]", A_1);
			if (num2 >= 0)
			{
				A_1 += 5;
				string varname = A_0.Substring(A_1 + 1, num2 - A_1 - 2);
				gameVariable = GetVariableByName(varname);
			}
			if (gameVariable != null)
			{
				A_0 = A_0.Remove(A_1 - 5, num2 + 2 - (A_1 - 5));
				switch (gameVariable.vartype)
				{
				case GameVariable.VarType.VT_STRING:
					A_0 = A_0.Insert(A_1 - 5, gameVariable.sString.Length.ToString());
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
				case GameVariable.VarType.VT_STRINGARRAY:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					A_0 = A_0.Insert(A_1 - 5, gameVariable.VarArray.Count.ToString());
					break;
				}
			}
			else
			{
				A_0 = A_0.Remove(A_1, 5);
			}
			A_1 = A_0.IndexOf("[len(", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[COLLEN("))
		{
			A_1 = A_0.IndexOf("[COLLEN(", 0, StringComparison.OrdinalIgnoreCase);
			GameVariable gameVariable2 = null;
			int num3 = A_0.IndexOf(")]", A_1);
			if (num3 >= 0)
			{
				A_1 += 8;
				string varname2 = A_0.Substring(A_1, num3 - A_1);
				gameVariable2 = GetVariableByName(varname2);
			}
			if (gameVariable2 != null)
			{
				A_0 = A_0.Remove(A_1 - 8, num3 + 2 - (A_1 - 8));
				switch (gameVariable2.vartype)
				{
				case GameVariable.VarType.VT_NUMBERARRAY:
				case GameVariable.VarType.VT_STRINGARRAY:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					if (gameVariable2.VarArray.Count > 0 && gameVariable2.VarArray[0] is List<string>)
					{
						A_0 = A_0.Insert(A_1 - 8, ((List<string>)gameVariable2.VarArray[0]).Count.ToString());
					}
					break;
				}
			}
			else
			{
				A_0 = A_0.Remove(A_1, 8);
			}
			A_1 = A_0.IndexOf("[COLLEN(", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ROOM.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is Room room)
			{
				A_0 = A_0.Insert(A_1, room.Name);
			}
			else if (ThePlayer.CurrentRoom != null)
			{
				A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.Name);
			}
			A_1 = A_0.IndexOf("[room.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ROOM.ID]"))
		{
			A_0 = A_0.Remove(A_1, 9);
			if (A_3 is Room room2)
			{
				A_0 = A_0.Insert(A_1, room2.UniqueID.ToString());
			}
			else if (ThePlayer.CurrentRoom != null)
			{
				A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.UniqueID.ToString());
			}
			A_1 = A_0.IndexOf("[room.id]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.ACTIVE]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			if (A_3 is Exit exit)
			{
				string value = "N";
				if (exit.bActive)
				{
					value = "Y";
				}
				A_0 = A_0.Insert(A_1, value);
			}
			A_1 = A_0.IndexOf("[exit.active]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DIRECTION]"))
		{
			A_0 = A_0.Remove(A_1, 16);
			if (A_3 is Exit exit2)
			{
				A_0 = A_0.Insert(A_1, exit2.Direction.ToString());
			}
			A_1 = A_0.IndexOf("[exit.direction]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DESTNAME]"))
		{
			A_0 = A_0.Remove(A_1, 15);
			if (A_3 is Exit exit3)
			{
				string empty = string.Empty;
				try
				{
					empty = GetRoomByID(new Guid(exit3.DestinationRoom)).GetName();
				}
				catch
				{
					empty = string.Empty;
				}
				A_0 = A_0.Insert(A_1, empty);
			}
			A_1 = A_0.IndexOf("[Exit.DestName]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DESTID]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			if (A_3 is Exit exit4)
			{
				string empty2 = string.Empty;
				try
				{
					empty2 = exit4.DestinationRoom;
				}
				catch
				{
					empty2 = string.Empty;
				}
				A_0 = A_0.Insert(A_1, empty2);
			}
			A_1 = A_0.IndexOf("[Exit.DestID]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ITEM.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is GameObject gameObject)
			{
				A_0 = A_0.Insert(A_1, gameObject.name);
			}
			A_1 = A_0.IndexOf("[item.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ITEM.ID]"))
		{
			A_0 = A_0.Remove(A_1, 9);
			if (A_3 is GameObject gameObject2)
			{
				A_0 = A_0.Insert(A_1, gameObject2.UniqueIdentifier.ToString());
			}
			A_1 = A_0.IndexOf("[item.id]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[CHAR.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is Character character)
			{
				A_0 = A_0.Insert(A_1, character.Charname);
			}
			A_1 = A_0.IndexOf("[char.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else
		{
			if (A_1 < 0 || !A_2.Contains("[A/AN]"))
			{
				return;
			}
			A_0 = A_0.Remove(A_1, 6);
			string text = A_0.Substring(A_1).Trim();
			if (text.Length >= 1)
			{
				if (string.Compare(text[0].ToString(), "a", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text[0].ToString(), "e", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text[0].ToString(), "i", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text[0].ToString(), "o", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text[0].ToString(), "u", StringComparison.OrdinalIgnoreCase) == 0)
				{
					A_0 = A_0.Insert(A_1, "an");
				}
				else
				{
					A_0 = A_0.Insert(A_1, "a");
				}
			}
			A_1 = A_0.IndexOf("[a/an]", 0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private void a(ref string A_0, int A_1)
	{
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 5);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string varname = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			GameVariable A_2 = GetVariableByName(varname);
			if (A_2 != null)
			{
				string text = a(ref A_2);
				text = text.Replace("\r", "\\r");
				text = text.Replace("\n", "\\n");
				A_0 = A_0.Insert(A_1, text);
			}
		}
		A_1 = A_0.LastIndexOf("[jsa:", StringComparison.OrdinalIgnoreCase);
	}

	private void k(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Room room = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf("(") > -1)
				{
					string text2 = array[0].Substring(0, array[0].IndexOf("("));
					room = GetRoomByID(new Guid(text2));
				}
				else
				{
					room = GetRoomByName(array[0]);
				}
				if (room != null)
				{
					foreach (CustomProperty customProperty in room.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), StringComparison.OrdinalIgnoreCase) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[rp:", StringComparison.OrdinalIgnoreCase);
	}

	private void j(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			GameObject gameObject = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf("(") > -1)
				{
					string objectname = array[0].Substring(0, array[0].IndexOf("("));
					gameObject = GetObjectByName(objectname);
				}
				else
				{
					gameObject = GetObjectByNameOld(array[0]);
				}
				if (gameObject != null)
				{
					foreach (CustomProperty customProperty in gameObject.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), StringComparison.OrdinalIgnoreCase) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ip:", StringComparison.OrdinalIgnoreCase);
	}

	private void i(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string strB = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			foreach (CustomProperty customProperty in ThePlayer.CustomProperties)
			{
				if (string.Compare(customProperty.Name, strB, StringComparison.OrdinalIgnoreCase) == 0)
				{
					A_0 = A_0.Insert(A_1, customProperty.Value);
					if (flag)
					{
						customProperty.Value = A_2;
					}
					break;
				}
			}
		}
		A_1 = A_0.LastIndexOf("[pp:", StringComparison.OrdinalIgnoreCase);
	}

	private void h(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Character character = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				character = GetCharacterByName(array[0]);
				if (character != null)
				{
					foreach (CustomProperty customProperty in character.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), StringComparison.OrdinalIgnoreCase) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[cp:", StringComparison.OrdinalIgnoreCase);
	}

	private void g(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			GameVariable gameVariable = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				gameVariable = GetVariableByName(array[0]);
				if (gameVariable != null)
				{
					foreach (CustomProperty customProperty in gameVariable.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), StringComparison.OrdinalIgnoreCase) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[vp:", StringComparison.OrdinalIgnoreCase);
	}

	private void f(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer != null)
				{
					foreach (CustomProperty customProperty in timer.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), StringComparison.OrdinalIgnoreCase) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[tp:", StringComparison.OrdinalIgnoreCase);
	}

	private void e(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer != null)
				{
					if (array[1].ToUpper() == "ACTIVE")
					{
						A_0 = A_0.Insert(A_1, timer.Active.ToString());
						if (flag)
						{
							try
							{
								timer.Active = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, timer.Name.ToString());
						if (flag)
						{
							timer.Name = A_2;
						}
					}
					else if (array[1].ToUpper() == "TIMERTYPE")
					{
						A_0 = A_0.Insert(A_1, timer.TType.ToString());
						if (flag)
						{
							try
							{
								timer.TType = (Timer.TimerType)Enum.Parse(typeof(Timer.TimerType), A_2, ignoreCase: true);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LENGTH")
					{
						A_0 = A_0.Insert(A_1, timer.Length.ToString());
						if (flag)
						{
							try
							{
								timer.Length = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "TURNNUMBER")
					{
						A_0 = A_0.Insert(A_1, timer.TurnNumber.ToString());
						if (flag)
						{
							try
							{
								timer.TurnNumber = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "TIMERSECONDS")
					{
						A_0 = A_0.Insert(A_1, timer.TimerSeconds.ToString());
						if (flag)
						{
							try
							{
								timer.TimerSeconds = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LIVETIMER")
					{
						A_0 = A_0.Insert(A_1, timer.LiveTimer.ToString());
						if (flag)
						{
							try
							{
								timer.LiveTimer = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = timer.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ta:", StringComparison.OrdinalIgnoreCase);
	}

	private void d(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Room room = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				try
				{
					room = GetRoomByID(new Guid(array[0]));
				}
				catch
				{
					room = null;
				}
				if (room == null)
				{
					room = GetRoomByName(array[0]);
				}
				if (room != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, room.Name.ToString());
						if (flag)
						{
							room.Name = A_2;
						}
					}
					else if (array[1].ToUpper() == "DESCRIPTION")
					{
						A_0 = A_0.Insert(A_1, room.Description.ToString());
						if (flag)
						{
							room.Description = A_2;
						}
					}
					else if (array[1].ToUpper() == "SDESC")
					{
						A_0 = A_0.Insert(A_1, room.SDesc.ToString());
						if (flag)
						{
							room.SDesc = A_2;
						}
					}
					else if (array[1].ToUpper() == "ROOMPIC")
					{
						A_0 = A_0.Insert(A_1, room.RoomPic.ToString());
						if (flag)
						{
							room.RoomPic = A_2;
						}
					}
					else if (array[1].ToUpper() == "ENTEREDFIRSTTIME")
					{
						A_0 = A_0.Insert(A_1, room.bEnterFirstTime.ToString());
						if (flag)
						{
							try
							{
								room.bEnterFirstTime = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LEFTFIRSTTIME")
					{
						A_0 = A_0.Insert(A_1, room.bLeaveFirstTime.ToString());
						if (flag)
						{
							try
							{
								room.bLeaveFirstTime = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ID")
					{
						A_0 = A_0.Insert(A_1, room.UniqueID.ToString());
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = room.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
					else if (array[1].ToUpper() == "EXIT")
					{
						Exit exit = null;
						try
						{
							exit = room.GetExit((Exit.Directions)Enum.Parse(typeof(Exit.Directions), array[2], ignoreCase: true));
						}
						catch
						{
							exit = null;
						}
						if (exit != null)
						{
							if (array[3].ToUpper() == "ACTIVE")
							{
								A_0 = A_0.Insert(A_1, exit.bActive.ToString());
								if (flag)
								{
									try
									{
										exit.bActive = Convert.ToBoolean(A_2);
									}
									catch
									{
									}
								}
							}
							else if (array[3].ToUpper() == "DESTINATIONID")
							{
								A_0 = A_0.Insert(A_1, exit.DestinationRoom.ToString());
								if (flag)
								{
									exit.DestinationRoom = A_2;
								}
							}
							else if (array[3].ToUpper() == "DESTINATIONNAME")
							{
								try
								{
									A_0 = A_0.Insert(A_1, GetRoomByID(new Guid(exit.DestinationRoom)).Name);
								}
								catch
								{
									A_0 = A_0.Insert(A_1, exit.DestinationRoom.ToString());
								}
								if (flag)
								{
									try
									{
										exit.DestinationRoom = GetRoomByName(A_2).UniqueID.ToString();
									}
									catch
									{
									}
								}
							}
							else if (array[3].ToUpper() == "PORTAL")
							{
								A_0 = A_0.Insert(A_1, exit.PortalObjectName.ToString());
								if (flag)
								{
									exit.PortalObjectName = A_2;
								}
							}
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ra:", StringComparison.OrdinalIgnoreCase);
	}

	private void c(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			GameObject gameObject = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				try
				{
					gameObject = GetObjectByName(array[0]);
				}
				catch
				{
					gameObject = null;
				}
				if (gameObject == null)
				{
					gameObject = GetObjectByNameOld(array[0]);
				}
				if (gameObject != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, gameObject.name.ToString());
						if (flag)
						{
							gameObject.name = A_2;
						}
					}
					else if (array[1].ToUpper() == "NAMEOVERRIDE")
					{
						A_0 = A_0.Insert(A_1, gameObject.sdesc.ToString());
						if (flag)
						{
							gameObject.sdesc = A_2;
						}
					}
					else if (array[1].ToUpper() == "CLOTHINGLAYERS")
					{
						string text2 = "[";
						int num2 = 0;
						foreach (string layeredZoneLevel in gameObject.LayeredZoneLevels)
						{
							if (num2 > 0)
							{
								text2 += ",";
							}
							num2++;
							text2 += "[";
							string[] array2 = layeredZoneLevel.Split(new string[1] { ":" }, StringSplitOptions.None);
							if (array2.Length > 0)
							{
								for (int i = 0; i < array2.Length; i++)
								{
									if (i > 0)
									{
										text2 += ",";
									}
									text2 = text2 + "\"" + array2[i] + "\"";
								}
							}
							text2 += "]";
						}
						text2 += "]";
						A_0 = A_0.Insert(A_1, text2);
					}
					else if (array[1].ToUpper() == "ID")
					{
						A_0 = A_0.Insert(A_1, gameObject.UniqueIdentifier.ToString());
					}
					else if (array[1].ToUpper() == "PREPOSITION")
					{
						A_0 = A_0.Insert(A_1, gameObject.preposition.ToString());
						if (flag)
						{
							gameObject.preposition = A_2;
						}
					}
					else if (array[1].ToUpper() == "DESCRIPTION")
					{
						A_0 = A_0.Insert(A_1, gameObject.description.ToString());
						if (flag)
						{
							gameObject.description = A_2;
						}
					}
					else if (array[1].ToUpper() == "IMPORTANT")
					{
						A_0 = A_0.Insert(A_1, gameObject.bImportant.ToString());
						if (flag)
						{
							try
							{
								gameObject.bImportant = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CARRYABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bCarryable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bCarryable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WEARABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bWearable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bWearable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WORN")
					{
						A_0 = A_0.Insert(A_1, gameObject.bWorn.ToString());
						if (flag)
						{
							try
							{
								gameObject.bWorn = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CONTAINER")
					{
						A_0 = A_0.Insert(A_1, gameObject.bContainer.ToString());
						if (flag)
						{
							try
							{
								gameObject.bContainer = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "OPENABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bOpenable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bOpenable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "OPEN")
					{
						A_0 = A_0.Insert(A_1, gameObject.bOpen.ToString());
						if (flag)
						{
							try
							{
								gameObject.bOpen = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LOCKABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bLockable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bLockable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LOCKED")
					{
						A_0 = A_0.Insert(A_1, gameObject.bLocked.ToString());
						if (flag)
						{
							try
							{
								gameObject.bLocked = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "VISIBLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bVisible.ToString());
						if (flag)
						{
							try
							{
								gameObject.bVisible = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ENTERABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bEnterable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bEnterable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "READABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bReadable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bReadable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WEIGHT")
					{
						A_0 = A_0.Insert(A_1, gameObject.dWeight.ToString());
						if (flag)
						{
							try
							{
								gameObject.dWeight = Convert.ToDouble(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = gameObject.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ia:", StringComparison.OrdinalIgnoreCase);
	}

	private void b(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Character character = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				try
				{
					character = GetCharacterByName(array[0]);
				}
				catch
				{
					character = null;
				}
				if (character != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, character.Charname.ToString());
						if (flag)
						{
							character.Charname = A_2;
						}
					}
					else if (array[1].ToUpper() == "OVERRIDENAME")
					{
						A_0 = A_0.Insert(A_1, character.CharnameOverride.ToString());
						if (flag)
						{
							character.CharnameOverride = A_2;
						}
					}
					else if (array[1].ToUpper() == "GENDER")
					{
						A_0 = A_0.Insert(A_1, character.CharGender.ToString());
						if (flag)
						{
							try
							{
								character.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), A_2, ignoreCase: true);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CURRENTROOM")
					{
						A_0 = A_0.Insert(A_1, character.CurrentRoom.ToString());
						if (flag)
						{
							character.CurrentRoom = A_2;
						}
					}
					else if (array[1].ToUpper() == "ALLOWINVINTERACTION")
					{
						A_0 = A_0.Insert(A_1, character.bAllowInventoryInteraction.ToString());
						if (flag)
						{
							try
							{
								character.bAllowInventoryInteraction = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = character.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ca:", StringComparison.OrdinalIgnoreCase);
	}

	private void a(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			if (array.Length >= 1 && ThePlayer != null)
			{
				if (array[0].ToUpper() == "NAME")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.Name.ToString());
					if (flag)
					{
						ThePlayer.Name = A_2;
					}
				}
				else if (array[0].ToUpper() == "GENDER")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.PlayerGender.ToString());
					if (flag)
					{
						try
						{
							ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), A_2, ignoreCase: true);
						}
						catch
						{
						}
					}
				}
				else if (array[0].ToUpper() == "CURROOM")
				{
					if (ThePlayer.CurrentRoom != null)
					{
						A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.ToString());
					}
					else
					{
						A_0 = A_0.Insert(A_1, "<Null>");
					}
					if (flag)
					{
						try
						{
							ThePlayer.CurrentRoom = GetRoomByName(A_2);
						}
						catch
						{
						}
					}
				}
				else if (array[0].ToUpper() == "CURPORTRAIT")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.PlayerPortrait.ToString());
					if (flag)
					{
						ThePlayer.PlayerPortrait = A_2;
					}
				}
				else if (array[0].ToUpper() == "ACTION")
				{
					Action tempact = ThePlayer.GetActionByName(array[1]);
					if (tempact != null)
					{
						A_0 = GetActionData(ref tempact, array[2], ref A_0, A_1, A_2);
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[pa:", StringComparison.OrdinalIgnoreCase);
	}

	public string GetActionData(ref Action tempact, string part3, ref string text, int tempindex, string replacementvalue = "")
	{
		bool flag = false;
		if (replacementvalue != "")
		{
			flag = true;
		}
		if (part3.ToUpper() == "ACTIVE")
		{
			text = text.Insert(tempindex, tempact.bActive.ToString());
			if (flag)
			{
				try
				{
					tempact.bActive = Convert.ToBoolean(replacementvalue);
				}
				catch
				{
				}
			}
		}
		else if (part3.ToUpper() == "OVERRIDENAME")
		{
			text = text.Insert(tempindex, tempact.overridename.ToString());
			if (flag)
			{
				tempact.overridename = replacementvalue;
			}
		}
		else if (part3.ToUpper() == "ACTIONPARENT")
		{
			text = text.Insert(tempindex, tempact.actionparent.ToString());
			if (flag)
			{
				tempact.actionparent = replacementvalue;
			}
		}
		else if (part3.ToUpper() == "INPUTTYPE")
		{
			text = text.Insert(tempindex, tempact.InputType.ToString());
			if (flag)
			{
				try
				{
					tempact.InputType = (Action.ActionInputType)Enum.Parse(typeof(Action.ActionInputType), replacementvalue, ignoreCase: true);
				}
				catch
				{
				}
			}
		}
		return text;
	}

	public string PerformTextReplacements(string text, object loopobject, string newvalue = "")
	{
		bool flag = true;
		while (flag)
		{
			flag = false;
			int num = text.Length;
			int num2 = text.LastIndexOf("[", num, StringComparison.OrdinalIgnoreCase);
			List<int> list = new List<int>();
			while (num2 >= 0)
			{
				int num3 = text.IndexOf("]", num2);
				if (num3 != -1)
				{
					string text2 = text.Substring(num2, num3 - num2 + 1).ToUpper();
					int num4 = text2.IndexOf(":", 0);
					if (num4 != -1)
					{
						flag = true;
						switch (text2.Substring(0, num4 + 1).ToUpper())
						{
						case "[V:":
							l(ref text, num2, newvalue);
							break;
						case "[JSA:":
							a(ref text, num2);
							break;
						case "[RP:":
							k(ref text, num2, newvalue);
							break;
						case "[IP:":
							j(ref text, num2, newvalue);
							break;
						case "[PP:":
							i(ref text, num2, newvalue);
							break;
						case "[CP:":
							h(ref text, num2, newvalue);
							break;
						case "[VP:":
							g(ref text, num2, newvalue);
							break;
						case "[TP:":
							f(ref text, num2, newvalue);
							break;
						case "[IA:":
							c(ref text, num2, newvalue);
							break;
						case "[TA:":
							e(ref text, num2, newvalue);
							break;
						case "[CA:":
							b(ref text, num2, newvalue);
							break;
						case "[RA:":
							d(ref text, num2, newvalue);
							break;
						case "[PA:":
							a(ref text, num2, newvalue);
							break;
						default:
							flag = false;
							break;
						}
					}
					else if (text2.Contains("[/B]") || text2.Contains("[/I]") || text2.Contains("[/U]") || text2.Contains("[/F]") || text2.Contains("[/C]") || text2.Contains("[/MIDDLE]") || text2.Contains("[B]") || text2.Contains("[I]") || text2.Contains("[U]") || text2.Contains("[F ") || text2.Contains("[C ") || text2.Contains("[MIDDLE]"))
					{
						num = num2 - 1;
					}
					else
					{
						a(ref text, num2, text2, ref loopobject);
					}
				}
				if (num > text.Length)
				{
					if (num2 == 0)
					{
						num2 = -1;
						continue;
					}
					list.Add(num2);
					num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					if (list.Contains(num2))
					{
						num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					}
				}
				else if (num == -1)
				{
					num2 = -1;
				}
				else if (num2 == 0)
				{
					num2 = -1;
				}
				else
				{
					list.Add(num2);
					num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					if (list.Contains(num2))
					{
						num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					}
				}
			}
		}
		return text;
	}

	public void AssignHotKey(int index, object data)
	{
		if (this.m_a == null)
		{
			this.m_a = new List<object>();
		}
		if (this.m_a.Count != 10)
		{
			this.m_a.Clear();
			for (int i = 0; i < 10; i++)
			{
				this.m_a.Add(null);
			}
		}
		this.m_a[index] = data;
	}

	public double GetItemWeight(Guid objid)
	{
		double num = 0.0;
		GameObject objectByName = GetObjectByName(objid.ToString());
		if (objectByName != null)
		{
			num += objectByName.dWeight;
			if (objectByName.bContainer)
			{
				foreach (GameObject @object in ObjectList)
				{
					if (@object.locationtype == GameObject.LocationType.LT_IN_OBJECT && @object.locationname == objectByName.UniqueIdentifier.ToString())
					{
						num += GetItemWeight(@object.UniqueIdentifier);
					}
				}
			}
		}
		return num;
	}
}
