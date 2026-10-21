using System;
using System.Collections;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class Timer : ISerializable
{
	public enum TimerType
	{
		TT_RUNALWAYS,
		TT_LENGTH
	}

	public string Name = string.Empty;

	public TimerType TType;

	public bool Active;

	public bool Restart;

	public ArrayList Actions = new ArrayList();

	public int Length;

	public int TurnNumber;

	public ArrayList CustomProperties = new ArrayList();

	public bool LiveTimer;

	public int TimerSeconds = 1;

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Timer>");
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Type", TType.ToString());
		Game.AddXMLSection(ref CurDoc, "Active", Active.ToString());
		Game.AddXMLSection(ref CurDoc, "Restart", Restart.ToString());
		Game.AddXMLSection(ref CurDoc, "Length", Length.ToString());
		Game.AddXMLSection(ref CurDoc, "LiveTimer", LiveTimer.ToString());
		Game.AddXMLSection(ref CurDoc, "TimerSeconds", TimerSeconds.ToString());
		if (Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Action action in Actions)
			{
				action.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in CustomProperties)
		{
			customProperty.GetXMLData(ref CurDoc);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Timer>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Type");
		if (xMLSection != null)
		{
			TType = (TimerType)Enum.Parse(typeof(TimerType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			Active = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Restart");
		if (xMLSection != null)
		{
			Restart = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Length");
		if (xMLSection != null)
		{
			Length = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "LiveTimer");
		if (xMLSection != null)
		{
			LiveTimer = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "TimerSeconds");
		if (xMLSection != null)
		{
			TimerSeconds = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Actions");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Action action = new Action();
				action.SetXMLData(ref CurNode2);
				foreach (Action action2 in Actions)
				{
					if (action2.name == action.name)
					{
						Actions.Remove(action2);
						break;
					}
				}
				Actions.Add(action);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				CustomProperty customProperty = new CustomProperty();
				customProperty.SetXMLData(ref CurNode3);
				CustomProperties.Add(customProperty);
			}
		}
	}

	public Timer()
	{
		a();
	}

	public Timer(SqlCeDataReader dr)
	{
		Name = dr["Name"].ToString();
		TType = (TimerType)dr["TType"];
		Active = (bool)dr["Active"];
		Restart = (bool)dr["Restart"];
		TurnNumber = (int)dr["TurnNumber"];
		Length = (int)dr["Length"];
		LiveTimer = (bool)dr["LiveTimer"];
		TimerSeconds = (int)dr["TimerSeconds"];
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from TimerProperties where TimerName=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from TimerActions where Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Actions.Add(new Action(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Timer values(\r\n                            @Name,\r\n                            @TType ,\r\n                            @Active ,\r\n                            @Restart ,\r\n                            @TurnNumber ,\r\n                            @Length ,\r\n                            @LiveTimer ,\r\n                            @TimerSeconds )", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		sqlCeCommand.Parameters.AddWithValue("@TType", TType);
		sqlCeCommand.Parameters.AddWithValue("@Active", Active);
		sqlCeCommand.Parameters.AddWithValue("@Restart", Restart);
		sqlCeCommand.Parameters.AddWithValue("@TurnNumber", TurnNumber);
		sqlCeCommand.Parameters.AddWithValue("@Length", Length);
		sqlCeCommand.Parameters.AddWithValue("@LiveTimer", LiveTimer);
		sqlCeCommand.Parameters.AddWithValue("@TimerSeconds", TimerSeconds);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Action action in Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into TimerActions (Name,Data) values(@Name,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", Name);
			StringBuilder CurDoc = new StringBuilder();
			action.GetXMLData(ref CurDoc);
			string value = TextHandlers.Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into TimerProperties (TimerName,Name,Value) values(@TimerName,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@TimerName", Name);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	protected Timer(SerializationInfo info, StreamingContext context)
	{
		try
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			Actions = (ArrayList)info.GetValue("Actions", Actions.GetType());
			Name = (string)info.GetValue("Name", Name.GetType());
			TType = (TimerType)info.GetValue("TType", TType.GetType());
			Active = (bool)info.GetValue("Active", Active.GetType());
			Restart = (bool)info.GetValue("Restart", Restart.GetType());
			TurnNumber = (int)info.GetValue("TurnNumber", TurnNumber.GetType());
			Length = (int)info.GetValue("Length", Length.GetType());
			try
			{
				LiveTimer = (bool)info.GetValue("LiveTimer", LiveTimer.GetType());
			}
			catch
			{
				LiveTimer = false;
			}
			try
			{
				TimerSeconds = (int)info.GetValue("TimerSeconds", TimerSeconds.GetType());
			}
			catch
			{
				TimerSeconds = 1;
			}
		}
		catch
		{
			Name = string.Empty;
			TType = TimerType.TT_RUNALWAYS;
			Active = false;
			Restart = false;
			Actions = new ArrayList();
			TurnNumber = 0;
			Length = 0;
			a();
		}
		try
		{
			CustomProperties = (ArrayList)info.GetValue("CustomProperties", CustomProperties.GetType());
		}
		catch
		{
			CustomProperties = new ArrayList();
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Actions", Actions, Actions.GetType());
		info.AddValue("Name", Name, Name.GetType());
		info.AddValue("TType", TType, TType.GetType());
		info.AddValue("Active", Active, Active.GetType());
		info.AddValue("Restart", Restart, Restart.GetType());
		info.AddValue("TurnNumber", TurnNumber, TurnNumber.GetType());
		info.AddValue("Length", Length, Length.GetType());
		info.AddValue("LiveTimer", LiveTimer, LiveTimer.GetType());
		info.AddValue("TimerSeconds", TimerSeconds, TimerSeconds.GetType());
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
	}

	public Action GetActionByName(string actionname)
	{
		for (int i = 0; i < Actions.Count; i++)
		{
			if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) == 0)
			{
				return (Action)Actions[i];
			}
		}
		return null;
	}

	private void a()
	{
		Action action = new Action();
		action.name = "<<On Each Turn>>";
		Actions.Add(action);
	}

	public override string ToString()
	{
		return Name;
	}

	public void UpdateFromSave(Timer temptimer)
	{
		Active = temptimer.Active;
		TurnNumber = temptimer.TurnNumber;
		foreach (CustomProperty customProperty3 in temptimer.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
		foreach (Action action in temptimer.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Name + "\",");
		A_.Append("\"" + TType.ToString() + "\",");
		A_.Append(Active.ToString().ToLower() + ",");
		A_.Append(Restart.ToString().ToLower() + ",");
		A_.Append(TurnNumber + ",");
		A_.Append(Length + ",");
		A_.Append(LiveTimer.ToString().ToLower() + ",");
		A_.Append(TimerSeconds + ",");
		A_.Append("[");
		int num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + customProperty.Name + "\",");
			A_.Append("\"" + customProperty.Value + "\"");
			A_.Append("]");
		}
		A_.Append("],");
		A_.Append("[");
		num = 0;
		foreach (Action action in Actions)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			action.a(ref A_);
		}
		A_.Append("]");
		A_.Append("]");
		return A_.ToString();
	}
}
