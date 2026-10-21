using System;
using System.Data;

namespace Rags;

public class ShareData
{
	public int index;

	public string useremail = string.Empty;

	public string usernickname = string.Empty;

	public string sharename = string.Empty;

	public string category = string.Empty;

	public bool bexplicit;

	public int size;

	public string description = string.Empty;

	public DateTime lastupdated = DateTime.MinValue;

	public int downloads;

	public string RagsVersion = string.Empty;

	public ShareData()
	{
	}

	public ShareData(IDataReader dread)
	{
		index = dread.GetInt32(0);
		useremail = dread.GetString(1);
		usernickname = dread.GetString(2);
		sharename = dread.GetString(3);
		category = dread.GetString(4);
		bexplicit = Convert.ToBoolean(dread[5].ToString());
		description = dread.GetString(6);
		size = dread.GetInt32(7);
		try
		{
			lastupdated = dread.GetDateTime(8);
		}
		catch
		{
			lastupdated = DateTime.MinValue;
		}
		try
		{
			downloads = dread.GetInt32(9);
		}
		catch
		{
			downloads = 0;
		}
		try
		{
			RagsVersion = dread.GetString(10);
		}
		catch
		{
			RagsVersion = string.Empty;
		}
	}
}
