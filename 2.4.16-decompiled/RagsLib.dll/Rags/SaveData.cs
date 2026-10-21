using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;
using A;

namespace Rags;

[Serializable]
public sealed class SaveData : ISerializable
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
		if (info != null)
		{
			__ldtoken(SaveData._002Ector(SerializationInfo, StreamingContext));
			versionnumber = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118003), versionnumber.GetType());
			Game.CurrentObjectVersionNumber = versionnumber;
			originalfilename = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118030), originalfilename.GetType());
			RoomList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49711), RoomList.GetType());
			ThePlayer = (Player)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49728), ThePlayer.GetType());
			ObjectList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49770), ObjectList.GetType());
			VariableList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49791), VariableList.GetType());
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
				return;
			}
			catch
			{
				StatusBarList = new ArrayList();
				return;
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
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
