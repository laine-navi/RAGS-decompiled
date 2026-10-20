using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class GameVariable
{
	public enum VarType
	{
		VT_UNINITIALIZED,
		VT_NUMBER,
		VT_STRING,
		VT_DATETIME,
		VT_NUMBERARRAY,
		VT_STRINGARRAY,
		VT_DATETIMEARRAY
	}

	[CompilerGenerated]
	private double m_a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private bool g;

	[CompilerGenerated]
	private DateTime h;

	[CompilerGenerated]
	private VarType i;

	[CompilerGenerated]
	private string j;

	[CompilerGenerated]
	private List<object> k;

	[CompilerGenerated]
	private List<CustomProperty> l;

	public double dNumType
	{
		[CompilerGenerated]
		get
		{
			return this.m_a;
		}
		[CompilerGenerated]
		set
		{
			this.m_a = value;
		}
	}

	public string dMin
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	public string dMax
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	public string sString
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	public string varname
	{
		[CompilerGenerated]
		get
		{
			return e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	public string GroupName
	{
		[CompilerGenerated]
		get
		{
			return f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	public bool bEnforceRestrictions
	{
		[CompilerGenerated]
		get
		{
			return g;
		}
		[CompilerGenerated]
		set
		{
			g = value;
		}
	}

	public DateTime dtDateTime
	{
		[CompilerGenerated]
		get
		{
			return h;
		}
		[CompilerGenerated]
		set
		{
			h = value;
		}
	}

	public VarType vartype
	{
		[CompilerGenerated]
		get
		{
			return i;
		}
		[CompilerGenerated]
		set
		{
			i = value;
		}
	}

	public string VarComment
	{
		[CompilerGenerated]
		get
		{
			return j;
		}
		[CompilerGenerated]
		set
		{
			j = value;
		}
	}

	public List<object> VarArray
	{
		[CompilerGenerated]
		get
		{
			return k;
		}
		[CompilerGenerated]
		set
		{
			k = value;
		}
	}

	public List<CustomProperty> CustomProperties
	{
		[CompilerGenerated]
		get
		{
			return l;
		}
		[CompilerGenerated]
		set
		{
			l = value;
		}
	}

	public string DisplayName => varname;

	public string DisplayValue => vartype switch
	{
		VarType.VT_DATETIME => dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt"), 
		VarType.VT_NUMBER => dNumType.ToString(), 
		VarType.VT_STRING => sString, 
		VarType.VT_DATETIMEARRAY => "DateTimeArray", 
		VarType.VT_NUMBERARRAY => "NumberArray", 
		VarType.VT_STRINGARRAY => "StringArray", 
		_ => string.Empty, 
	};

	public GameVariable(string vname)
	{
		varname = vname;
		VarArray = new List<object>();
		CustomProperties = new List<CustomProperty>();
		dNumType = 0.0;
		dMin = "0.0";
		dMax = "100.0";
		sString = "";
		GroupName = string.Empty;
		bEnforceRestrictions = false;
		dtDateTime = DateTime.Now;
		vartype = VarType.VT_UNINITIALIZED;
		VarComment = string.Empty;
	}

	public GameVariable()
	{
		varname = string.Empty;
		VarArray = new List<object>();
		CustomProperties = new List<CustomProperty>();
		dNumType = 0.0;
		dMin = "0.0";
		dMax = "100.0";
		sString = "";
		GroupName = string.Empty;
		bEnforceRestrictions = false;
		dtDateTime = DateTime.Now;
		vartype = VarType.VT_UNINITIALIZED;
		VarComment = string.Empty;
	}

	public void UpdateFromSave(GameVariable tempvar)
	{
		dNumType = tempvar.dNumType;
		sString = tempvar.sString;
		dtDateTime = tempvar.dtDateTime;
		VarArray = tempvar.VarArray;
		foreach (CustomProperty customProperty in tempvar.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
	}

	private string a()
	{
		bool flag = false;
		bool flag2 = true;
		switch (vartype)
		{
		case VarType.VT_NUMBERARRAY:
			flag2 = false;
			flag = true;
			break;
		case VarType.VT_STRINGARRAY:
		case VarType.VT_DATETIMEARRAY:
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
			for (int i = 0; i < VarArray.Count; i++)
			{
				num++;
				if (num > 0)
				{
					text += ",";
				}
				if (!(VarArray[i] is List<string> list))
				{
					text = ((!flag2) ? (text + VarArray[i].ToString()) : (text + "\"" + VarArray[i].ToString().Replace("'", "\\'").Replace("\"", "\\\"")
						.Replace("\r\n", "<br>")
						.Replace("\n", "<br>") + "\""));
					continue;
				}
				text += "[";
				int num2 = -1;
				foreach (string item in list)
				{
					num2++;
					if (num2 > 0)
					{
						text += ",";
					}
					text = ((!flag2) ? (text + item.ToString()) : (text + "\"" + item.ToString().Replace("'", "\\'").Replace("\"", "\\\"")
						.Replace("\r\n", "<br>")
						.Replace("\n", "<br>") + "\""));
				}
				text += "]";
			}
			text += "]";
		}
		catch
		{
		}
		return text;
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append(dNumType + ",");
		stringBuilder.Append("\"" + dMin + "\",");
		stringBuilder.Append("\"" + dMax + "\",");
		stringBuilder.Append("\"" + sString.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		stringBuilder.Append("\"" + varname.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		stringBuilder.Append("\"" + GroupName + "\",");
		stringBuilder.Append(bEnforceRestrictions.ToString().ToLower() + ",");
		stringBuilder.Append("\"" + dtDateTime.ToString() + "\",");
		stringBuilder.Append("\"" + vartype.ToString() + "\",");
		stringBuilder.Append("\"" + VarComment.ToString().Replace("'", "\\'").Replace("\"", "\\\"")
			.Replace("\r\n", "<br>") + "\",");
		stringBuilder.Append(a());
		stringBuilder.Append(",");
		stringBuilder.Append("[");
		int num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				stringBuilder.Append(",");
			}
			num++;
			stringBuilder.Append("[");
			stringBuilder.Append("\"" + customProperty.Name + "\",");
			stringBuilder.Append("\"" + customProperty.Value + "\"");
			stringBuilder.Append("]");
		}
		stringBuilder.Append("]");
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public void CorrectVariableData()
	{
		if (VarArray.Count > 0)
		{
			for (int i = 0; i < VarArray.Count; i++)
			{
				if (VarArray[i] is List<string>)
				{
					_ = string.Empty;
					int num = 0;
					for (int j = 0; j < ((List<string>)VarArray[i]).Count; j++)
					{
						((List<string>)VarArray[i])[j] = Game.UpdateStringToHTML(((List<string>)VarArray[i])[j]);
						num++;
					}
				}
				else if (VarArray[i] is string)
				{
					VarArray[i] = Game.UpdateStringToHTML((string)VarArray[i]);
				}
			}
		}
		sString = Game.UpdateStringToHTML(sString);
	}
}
