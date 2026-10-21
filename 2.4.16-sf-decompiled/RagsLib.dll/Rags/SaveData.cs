using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;
using A;

namespace Rags;

[Serializable]
public sealed class SaveData : ISerializable
{
	public string versionnumber;

	public string originalfilename;

	public ArrayList RoomList;

	public Player ThePlayer;

	public ArrayList ObjectList;

	public ArrayList VariableList;

	public ArrayList CharacterList;

	public ArrayList TimerList;

	public ArrayList StatusBarList;

	public SaveData()
	{
		versionnumber = string.Empty;
		originalfilename = string.Empty;
		RoomList = new ArrayList();
		ThePlayer = new Player();
		ObjectList = new ArrayList();
		VariableList = new ArrayList();
		CharacterList = new ArrayList();
		TimerList = new ArrayList();
		StatusBarList = new ArrayList();
		base._002Ector();
	}

	protected SaveData(SerializationInfo info, StreamingContext context)
	{
		versionnumber = string.Empty;
		originalfilename = string.Empty;
		RoomList = new ArrayList();
		ThePlayer = new Player();
		ObjectList = new ArrayList();
		VariableList = new ArrayList();
		CharacterList = new ArrayList();
		TimerList = new ArrayList();
		StatusBarList = new ArrayList();
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		versionnumber = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118003), versionnumber.GetType());
		Game.CurrentObjectVersionNumber = versionnumber;
		originalfilename = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118030), originalfilename.GetType());
		RoomList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49711), RoomList.GetType());
		ThePlayer = (Player)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49728), ThePlayer.GetType());
		ObjectList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49770), ObjectList.GetType());
		VariableList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49791), VariableList.GetType());
		VariableList.Sort();
		CharacterList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49816), CharacterList.GetType());
		try
		{
			TimerList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49843), TimerList.GetType());
		}
		catch
		{
			TimerList = new ArrayList();
		}
		try
		{
			StatusBarList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118063), TimerList.GetType());
		}
		catch
		{
			StatusBarList = new ArrayList();
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(SaveData.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118003), versionnumber, versionnumber.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118030), originalfilename, originalfilename.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49711), RoomList, RoomList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49728), ThePlayer, ThePlayer.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49770), ObjectList, ObjectList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49791), VariableList, VariableList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49816), CharacterList, CharacterList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49843), TimerList, TimerList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118063), StatusBarList, StatusBarList.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}
}
