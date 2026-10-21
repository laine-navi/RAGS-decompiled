using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Rags;

[Serializable]
public class SaveData : ISerializable
{
	public string versionnumber = string.Empty;

	public string originalfilename = string.Empty;

	public ArrayList RoomList = new ArrayList();

	public Player ThePlayer = new Player();

	public ArrayList ObjectList = new ArrayList();

	public ArrayList VariableList = new ArrayList();

	public ArrayList CharacterList = new ArrayList();

	public ArrayList TimerList = new ArrayList();

	public ArrayList StatusBarList = new ArrayList();

	public SaveData()
	{
	}

	protected SaveData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		versionnumber = (string)info.GetValue("versionnumber", versionnumber.GetType());
		Game.CurrentObjectVersionNumber = versionnumber;
		originalfilename = (string)info.GetValue("originalfilename", originalfilename.GetType());
		RoomList = (ArrayList)info.GetValue("RoomList", RoomList.GetType());
		ThePlayer = (Player)info.GetValue("ThePlayer", ThePlayer.GetType());
		ObjectList = (ArrayList)info.GetValue("ObjectList", ObjectList.GetType());
		VariableList = (ArrayList)info.GetValue("VariableList", VariableList.GetType());
		CharacterList = (ArrayList)info.GetValue("CharacterList", CharacterList.GetType());
		try
		{
			TimerList = (ArrayList)info.GetValue("TimerList", TimerList.GetType());
		}
		catch
		{
			TimerList = new ArrayList();
		}
		try
		{
			StatusBarList = (ArrayList)info.GetValue("StatusBarList", TimerList.GetType());
		}
		catch
		{
			StatusBarList = new ArrayList();
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("versionnumber", versionnumber, versionnumber.GetType());
		info.AddValue("originalfilename", originalfilename, originalfilename.GetType());
		info.AddValue("RoomList", RoomList, RoomList.GetType());
		info.AddValue("ThePlayer", ThePlayer, ThePlayer.GetType());
		info.AddValue("ObjectList", ObjectList, ObjectList.GetType());
		info.AddValue("VariableList", VariableList, VariableList.GetType());
		info.AddValue("CharacterList", CharacterList, CharacterList.GetType());
		info.AddValue("TimerList", TimerList, TimerList.GetType());
		info.AddValue("StatusBarList", StatusBarList, StatusBarList.GetType());
	}
}
