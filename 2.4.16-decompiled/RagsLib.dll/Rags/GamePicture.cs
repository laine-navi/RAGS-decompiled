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
using A;

namespace Rags;

[Serializable]
public sealed class GamePicture : ISerializable
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
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		TheName = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString();
		enhinputdata.BackgroundColor = Color.FromName(dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862)].ToString());
		enhinputdata.TextColor = Color.FromName(dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893)].ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		enhinputdata.TextFont = (Font)converter.ConvertFromString(dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912)].ToString());
		enhinputdata.Imagename = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20929)].ToString();
		enhinputdata.bUseEnhancedGraphics = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948)];
		enhinputdata.NewImage = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987)].ToString();
		try
		{
			GroupName = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
		catch
		{
		}
		SqlCeConnection theCon = Game.TheCon;
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22031), theCon);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			__ldtoken(GamePicture._002Ector(SqlCeDataReader));
			LayeredImages.Add(sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22175)].ToString());
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

	protected GamePicture(SerializationInfo info, StreamingContext context)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Obj, but got Unknown
		if (info != null)
		{
			__ldtoken(GamePicture._002Ector(SerializationInfo, StreamingContext));
			try
			{
				TheName = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393));
			}
			catch
			{
				TheName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
			}
			try
			{
				LayeredImages = (List<string>)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19427), LayeredImages.GetType());
			}
			catch
			{
				LayeredImages = new List<string>();
			}
			try
			{
				TheImage = (Image)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22184), typeof(Image));
				if (((object)TheImage.RawFormat).Equals((object?)ImageFormat.Gif))
				{
					__ldtoken(GamePicture._002Ector(SerializationInfo, StreamingContext));
				}
				else if (!((object)TheImage.RawFormat).Equals((object?)ImageFormat.Jpeg))
				{
					if (((object)TheImage.RawFormat).Equals((object?)ImageFormat.Png))
					{
						__ldtoken(GamePicture._002Ector(SerializationInfo, StreamingContext));
					}
					else
					{
						int num = 80;
						EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)num);
						ImageCodecInfo val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21981));
						EncoderParameters val3 = new EncoderParameters(1);
						val3.Param[0] = val;
						MemoryStream memoryStream = new MemoryStream();
						TheImage.Save((Stream)memoryStream, val2, val3);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						TheImage = Image.FromStream((Stream)memoryStream);
					}
				}
			}
			catch
			{
				TheImage = null;
			}
			try
			{
				ImageData = (byte[])info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19408), typeof(byte[]));
				return;
			}
			catch
			{
				if (TheImage == null)
				{
					__ldtoken(GamePicture._002Ector(SerializationInfo, StreamingContext));
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
						Image val4 = c26f3f6e6b186490444b9e185f1837bac(TheImage, 80);
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
				return;
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public void UpdatePictureGroup()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19231), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(GamePicture.UpdatePictureGroup());
		}
		else
		{
			GroupName = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
	}

	public override string ToString()
	{
		return TheName;
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393));
		if (xMLSection == null)
		{
			__ldtoken(GamePicture.SetXMLData(ref XmlNode));
		}
		else
		{
			TheName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19408));
		if (xMLSection == null)
		{
			__ldtoken(GamePicture.SetXMLData(ref XmlNode));
		}
		else
		{
			ImageData = Convert.FromBase64String(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19427));
		if (xMLSection == null)
		{
			__ldtoken(GamePicture.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				LayeredImages.Add(xmlNode.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19454));
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(GamePicture.SetXMLData(ref XmlNode));
				XmlNode xmlNode2 = xMLSection.ChildNodes[j];
				Choices.Add(xmlNode2.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469));
		if (xMLSection == null)
		{
			__ldtoken(GamePicture.SetXMLData(ref XmlNode));
		}
		else
		{
			enhinputdata.SetXMLData(ref xMLSection);
		}
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		byte[] array = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19504), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(GamePicture.GetXMLData(ref StreamWriter));
		}
		else
		{
			array = (byte[])sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)];
		}
		if (array == null)
		{
			return;
		}
		__ldtoken(GamePicture.GetXMLData(ref StreamWriter));
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19664), new object[0]));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393), TheName.ToString());
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19679));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19702) + Convert.ToBase64String(array) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19721));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19728));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19753));
		using (List<string>.Enumerator enumerator = LayeredImages.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GamePicture.GetXMLData(ref StreamWriter));
				string current = enumerator.Current;
				Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19784), current);
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19809));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19842));
		using (List<object>.Enumerator enumerator2 = Choices.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(GamePicture.GetXMLData(ref StreamWriter));
				object current2 = enumerator2.Current;
				Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19861), current2.ToString());
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19874));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		enhinputdata.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19975));
	}

	public void InsertToDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19992), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), TheName);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), enhinputdata.BackgroundColor.ToString());
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20929), enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), enhinputdata.NewImage);
		if (ImageData != null)
		{
			__ldtoken(GamePicture.InsertToDatabase());
		}
		else
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
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655), ImageData);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374), GroupName);
		if (ImageData != null)
		{
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand.Dispose();
	}

	internal void c99c4de57cc28b83b24000ba9447c3a36()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21004), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21808), enhinputdata.BackgroundColor.ToString());
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21841), enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21862), converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21881), enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21902), enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21943), enhinputdata.NewImage);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), TheName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
	}

	private Image c26f3f6e6b186490444b9e185f1837bac(Image P_0, int P_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		if (P_0 != null)
		{
			__ldtoken(GamePicture.c26f3f6e6b186490444b9e185f1837bac(Image, int));
			if (P_1 < 0)
			{
				__ldtoken(GamePicture.c26f3f6e6b186490444b9e185f1837bac(Image, int));
			}
			else
			{
				_ = 100;
			}
			EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)P_1);
			ImageCodecInfo val2 = null;
			string text = ImageFormat.Gif.Guid.ToString();
			string text2 = ImageFormat.Png.Guid.ToString();
			string text3 = P_0.RawFormat.Guid.ToString();
			if (!(text3 == text))
			{
				__ldtoken(GamePicture.c26f3f6e6b186490444b9e185f1837bac(Image, int));
				if (!(text3 == text2))
				{
					__ldtoken(GamePicture.c26f3f6e6b186490444b9e185f1837bac(Image, int));
					val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21981));
				}
				else
				{
					val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21962));
					if (val2 != null)
					{
					}
				}
				if (val2 == null)
				{
					__ldtoken(GamePicture.c26f3f6e6b186490444b9e185f1837bac(Image, int));
					return P_0;
				}
				EncoderParameters val3 = new EncoderParameters(1);
				val3.Param[0] = val;
				MemoryStream memoryStream = new MemoryStream();
				P_0.Save((Stream)memoryStream, val2, val3);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				return Image.FromStream((Stream)memoryStream);
			}
			return P_0;
		}
		return P_0;
	}

	private ImageCodecInfo c16aac53cdad270401e5646e1d265fd81(string P_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length - 1; i++)
		{
			__ldtoken(GamePicture.c16aac53cdad270401e5646e1d265fd81(string));
			if (!(imageEncoders[i].MimeType == P_0))
			{
				__ldtoken(GamePicture.c16aac53cdad270401e5646e1d265fd81(string));
				continue;
			}
			return imageEncoders[i];
		}
		return null;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393), TheName, TheName.GetType());
		if (ImageData != null)
		{
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19408), ImageData, ImageData.GetType());
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19427), LayeredImages, LayeredImages.GetType());
	}

	public Image GetTheImage()
	{
		byte[] buffer = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19504), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(GamePicture.GetTheImage());
		}
		else
		{
			buffer = (byte[])sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)];
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
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + TheName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + GroupName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		string text = string.Empty;
		int num = 0;
		using (List<string>.Enumerator enumerator = LayeredImages.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GamePicture.GetJSData());
				string current = enumerator.Current;
				if (num <= 0)
				{
					__ldtoken(GamePicture.GetJSData());
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929);
				}
				text += current;
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22019) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22024));
		enhinputdata.cc738ece0e9315f0db703b90a443636ff(ref stringBuilder);
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}
}
