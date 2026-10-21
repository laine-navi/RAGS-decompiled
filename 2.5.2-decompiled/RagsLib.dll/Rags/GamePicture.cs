using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class GamePicture : ISerializable
{
	public Image TheImage;

	public string TheName = string.Empty;

	public string GroupName = string.Empty;

	public byte[] ImageData;

	public List<string> LayeredImages = new List<string>();

	public List<object> Choices = new List<object>();

	public EnhancedInputData enhinputdata = new EnhancedInputData();

	public GamePicture(string name, string imagepath)
	{
		TheName = name;
		ImageData = File.ReadAllBytes(imagepath);
		InsertToDatabase();
	}

	public GamePicture(SqlCeDataReader dr)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		TheName = dr["Name"].ToString();
		enhinputdata.BackgroundColor = Color.FromName(dr["BackgroundColor"].ToString());
		enhinputdata.TextColor = Color.FromName(dr["TextColor"].ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		enhinputdata.TextFont = (Font)converter.ConvertFromString(dr["TextFont"].ToString());
		enhinputdata.Imagename = dr["ImageName"].ToString();
		enhinputdata.bUseEnhancedGraphics = (bool)dr["UseEnhancedGraphics"];
		enhinputdata.NewImage = dr["NewImage"].ToString();
		try
		{
			GroupName = dr["GroupName"].ToString();
		}
		catch
		{
		}
		SqlCeConnection theCon = Game.TheCon;
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from MediaLayeredImages where MediaName=@name order by [Order]", theCon);
		sqlCeCommand.Parameters.AddWithValue("@name", TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			LayeredImages.Add(sqlCeDataReader["data"].ToString());
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public GamePicture()
	{
		TheImage = null;
		TheName = string.Empty;
	}

	public void UpdatePictureGroup()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Media\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	public override string ToString()
	{
		return TheName;
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "TheName");
		if (xMLSection != null)
		{
			TheName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "ImageData");
		if (xMLSection != null)
		{
			ImageData = Convert.FromBase64String(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "LayeredImages");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				LayeredImages.Add(xmlNode.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Choices");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode xmlNode2 = xMLSection.ChildNodes[j];
				Choices.Add(xmlNode2.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			enhinputdata.SetXMLData(ref xMLSection);
		}
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		byte[] array = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			array = (byte[])sqlCeDataReader["Data"];
		}
		if (array == null)
		{
			return;
		}
		CurDoc.WriteLine(string.Format("<Image>", Array.Empty<object>()));
		Game.AddXMLSection(ref CurDoc, "TheName", TheName.ToString());
		CurDoc.WriteLine("<ImageData>");
		CurDoc.WriteLine("<![CDATA[" + Convert.ToBase64String(array) + "]]>");
		CurDoc.WriteLine("</ImageData>");
		CurDoc.WriteLine("<LayeredImages>");
		foreach (string layeredImage in LayeredImages)
		{
			Game.AddXMLSection(ref CurDoc, "LayeredImage", layeredImage);
		}
		CurDoc.WriteLine("</LayeredImages>");
		CurDoc.WriteLine("<Choices>");
		foreach (object choice in Choices)
		{
			Game.AddXMLSection(ref CurDoc, "Choice", choice.ToString());
		}
		CurDoc.WriteLine("</Choices>");
		CurDoc.WriteLine("<EnhancedInputData>");
		enhinputdata.a(ref CurDoc);
		CurDoc.WriteLine("</EnhancedInputData>");
		CurDoc.WriteLine("</Image>");
	}

	protected GamePicture(SerializationInfo info, StreamingContext context)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			TheName = info.GetString("TheName");
		}
		catch
		{
			TheName = "None";
		}
		try
		{
			LayeredImages = (List<string>)info.GetValue("LayeredImages", LayeredImages.GetType());
		}
		catch
		{
			LayeredImages = new List<string>();
		}
		try
		{
			TheImage = (Image)info.GetValue("TheImage", typeof(Image));
			if (!((object)TheImage.RawFormat).Equals((object?)ImageFormat.Gif) && !((object)TheImage.RawFormat).Equals((object?)ImageFormat.Jpeg) && !((object)TheImage.RawFormat).Equals((object?)ImageFormat.Png))
			{
				int num = 80;
				EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)num);
				ImageCodecInfo val2 = a("image/jpeg");
				EncoderParameters val3 = new EncoderParameters(1);
				val3.Param[0] = val;
				MemoryStream memoryStream = new MemoryStream();
				TheImage.Save((Stream)memoryStream, val2, val3);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				TheImage = Image.FromStream((Stream)memoryStream);
			}
		}
		catch
		{
			TheImage = null;
		}
		try
		{
			ImageData = (byte[])info.GetValue("ImageData", typeof(byte[]));
		}
		catch
		{
			if (TheImage == null)
			{
				return;
			}
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				TheImage.Save((Stream)memoryStream2, TheImage.RawFormat);
				ImageData = memoryStream2.ToArray();
			}
			catch (Exception)
			{
				try
				{
					Image val4 = a(TheImage, 80);
					val4.Save((Stream)memoryStream2, val4.RawFormat);
					ImageData = memoryStream2.ToArray();
				}
				catch
				{
					ImageData = null;
				}
			}
			TheImage.Dispose();
			memoryStream2.Close();
			memoryStream2.Dispose();
		}
	}

	public void InsertToDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Media values (\r\n                            @Name ,\r\n                            @BackgroundColor ,\r\n                            @TextColor,\r\n                            @TextFont ,\r\n                            @ImageName ,\r\n                            @UseEnhancedGraphics,\r\n                            @NewImage,\r\n                            @Data,\r\n                            @GroupName\r\n                            ) ", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("Name", TheName);
		sqlCeCommand.Parameters.AddWithValue("BackgroundColor", enhinputdata.BackgroundColor.ToString());
		sqlCeCommand.Parameters.AddWithValue("TextColor", enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue("TextFont", converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		sqlCeCommand.Parameters.AddWithValue("ImageName", enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue("UseEnhancedGraphics", enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue("NewImage", enhinputdata.NewImage);
		if (ImageData == null)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				TheImage.Save((Stream)memoryStream, ImageFormat.Gif);
				ImageData = memoryStream.ToArray();
			}
			catch
			{
			}
		}
		sqlCeCommand.Parameters.AddWithValue("Data", ImageData);
		sqlCeCommand.Parameters.AddWithValue("GroupName", GroupName);
		if (ImageData != null)
		{
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand.Dispose();
	}

	internal void a()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update Media set \r\n                            BackgroundColor= @BackgroundColor ,\r\n                           TextColor= @TextColor,\r\n                            TextFont=@TextFont ,\r\n                            ImageName=@ImageName ,\r\n                            UseEnhancedGraphics=@UseEnhancedGraphics,\r\n                            NewImage=@NewImage\r\n                            where Name=@Name ", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@BackgroundColor", enhinputdata.BackgroundColor.ToString());
		sqlCeCommand.Parameters.AddWithValue("@TextColor", enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue("@TextFont", converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		sqlCeCommand.Parameters.AddWithValue("@ImageName", enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue("@UseEnhancedGraphics", enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue("@NewImage", enhinputdata.NewImage);
		sqlCeCommand.Parameters.AddWithValue("@Name", TheName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
	}

	private Image a(Image A_0, int A_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		if (A_0 == null)
		{
			return A_0;
		}
		if (A_1 >= 0)
		{
			_ = 100;
		}
		EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)A_1);
		ImageCodecInfo val2 = null;
		string text = ImageFormat.Gif.Guid.ToString();
		string text2 = ImageFormat.Png.Guid.ToString();
		string text3 = A_0.RawFormat.Guid.ToString();
		if (text3 == text)
		{
			return A_0;
		}
		if (text3 == text2)
		{
			val2 = a("image/png");
			if (val2 != null)
			{
			}
		}
		else
		{
			val2 = a("image/jpeg");
		}
		if (val2 != null)
		{
			EncoderParameters val3 = new EncoderParameters(1);
			val3.Param[0] = val;
			MemoryStream memoryStream = new MemoryStream();
			A_0.Save((Stream)memoryStream, val2, val3);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return Image.FromStream((Stream)memoryStream);
		}
		return A_0;
	}

	private ImageCodecInfo a(string A_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length - 1; i++)
		{
			if (imageEncoders[i].MimeType == A_0)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("TheName", TheName, TheName.GetType());
		if (ImageData != null)
		{
			info.AddValue("ImageData", ImageData, ImageData.GetType());
		}
		info.AddValue("LayeredImages", LayeredImages, LayeredImages.GetType());
	}

	public Image GetTheImage()
	{
		byte[] buffer = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			buffer = (byte[])sqlCeDataReader["Data"];
		}
		MemoryStream memoryStream = new MemoryStream(buffer);
		try
		{
			return Image.FromStream((Stream)memoryStream);
		}
		catch
		{
			return null;
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + TheName + "\",");
		A_.Append("\"" + GroupName + "\",");
		string text = string.Empty;
		int num = 0;
		foreach (string layeredImage in LayeredImages)
		{
			if (num > 0)
			{
				text += ":";
			}
			text += layeredImage;
		}
		A_.Append("[\"" + text + "\"],");
		enhinputdata.c(ref A_);
		A_.Append("]");
		return A_.ToString();
	}
}
