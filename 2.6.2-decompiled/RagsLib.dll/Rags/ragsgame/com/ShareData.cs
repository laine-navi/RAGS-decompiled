using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Rags.ragsgame.com;

[Serializable]
[GeneratedCode("System.Xml", "4.6.1586.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class ShareData
{
	private int indexField;

	private string useremailField;

	private string usernicknameField;

	private string sharenameField;

	private string categoryField;

	private bool bexplicitField;

	private int sizeField;

	private string descriptionField;

	private DateTime lastupdatedField;

	private int downloadsField;

	private string ragsVersionField;

	public int index
	{
		get
		{
			return indexField;
		}
		set
		{
			indexField = value;
		}
	}

	public string useremail
	{
		get
		{
			return useremailField;
		}
		set
		{
			useremailField = value;
		}
	}

	public string usernickname
	{
		get
		{
			return usernicknameField;
		}
		set
		{
			usernicknameField = value;
		}
	}

	public string sharename
	{
		get
		{
			return sharenameField;
		}
		set
		{
			sharenameField = value;
		}
	}

	public string category
	{
		get
		{
			return categoryField;
		}
		set
		{
			categoryField = value;
		}
	}

	public bool bexplicit
	{
		get
		{
			return bexplicitField;
		}
		set
		{
			bexplicitField = value;
		}
	}

	public int size
	{
		get
		{
			return sizeField;
		}
		set
		{
			sizeField = value;
		}
	}

	public string description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
		}
	}

	public DateTime lastupdated
	{
		get
		{
			return lastupdatedField;
		}
		set
		{
			lastupdatedField = value;
		}
	}

	public int downloads
	{
		get
		{
			return downloadsField;
		}
		set
		{
			downloadsField = value;
		}
	}

	public string RagsVersion
	{
		get
		{
			return ragsVersionField;
		}
		set
		{
			ragsVersionField = value;
		}
	}
}
