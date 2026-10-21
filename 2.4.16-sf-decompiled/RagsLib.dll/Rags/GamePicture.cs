using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
public sealed class GamePicture : ISerializable, IComparable
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
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		TheName = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString();
		enhinputdata.BackgroundColor = Color.FromName(((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862)].ToString());
		enhinputdata.TextColor = Color.FromName(((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893)].ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		enhinputdata.TextFont = (Font)converter.ConvertFromString(((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912)].ToString());
		enhinputdata.Imagename = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20929)].ToString();
		enhinputdata.bUseEnhancedGraphics = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948)];
		enhinputdata.NewImage = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987)].ToString();
		try
		{
			GroupName = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
		catch
		{
		}
		SqlCeConnection theCon = Game.TheCon;
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22031), theCon);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), (object)TheName);
		SqlCeDataReader val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			LayeredImages.Add(((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22175)].ToString());
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
	}

	public GamePicture()
	{
		TheImage = null;
		TheName = string.Empty;
	}

	protected GamePicture(SerializationInfo info, StreamingContext context)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected Obj, but got Unknown
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
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
			if (!((object)TheImage.RawFormat).Equals((object?)ImageFormat.Gif) && !((object)TheImage.RawFormat).Equals((object?)ImageFormat.Jpeg) && !((object)TheImage.RawFormat).Equals((object?)ImageFormat.Png))
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
		catch
		{
			TheImage = null;
		}
		try
		{
			ImageData = (byte[])info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19408), typeof(byte[]));
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
		}
	}

	public void UpdatePictureGroup()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19231), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), (object)TheName);
		SqlCeDataReader val2 = val.ExecuteReader();
		if (((DbDataReader)(object)val2).Read())
		{
			GroupName = ((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
	}

	public override string ToString()
	{
		return TheName;
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393));
		if (xMLSection != null)
		{
			TheName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19408));
		if (xMLSection != null)
		{
			ImageData = Convert.FromBase64String(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19427));
		if (xMLSection != null)
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
				XmlNode xmlNode2 = xMLSection.ChildNodes[j];
				Choices.Add(xmlNode2.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469));
		if (xMLSection != null)
		{
			enhinputdata.SetXMLData(ref xMLSection);
		}
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		byte[] array = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19504), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)TheName);
		SqlCeDataReader val2 = val.ExecuteReader();
		if (((DbDataReader)(object)val2).Read())
		{
			array = (byte[])((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)];
		}
		if (array == null)
		{
			return;
		}
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19664), new object[0]));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19393), TheName.ToString());
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19679));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19702) + Convert.ToBase64String(array) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19721));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19728));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19753));
		foreach (string layeredImage in LayeredImages)
		{
			Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19784), layeredImage);
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19809));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19842));
		foreach (object choice in Choices)
		{
			Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19861), choice.ToString());
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19874));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		enhinputdata.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19975));
	}

	public void InsertToDatabase()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19992), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), (object)TheName);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), (object)enhinputdata.BackgroundColor.ToString());
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), (object)enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), (object)converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20929), (object)enhinputdata.Imagename);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), (object)enhinputdata.bUseEnhancedGraphics);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), (object)enhinputdata.NewImage);
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
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655), (object)ImageData);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374), (object)GroupName);
		if (ImageData != null)
		{
			((DbCommand)(object)val).ExecuteNonQuery();
		}
		((Component)(object)val).Dispose();
	}

	internal void c99c4de57cc28b83b24000ba9447c3a36()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_013a: Expected Obj, but got Unknown
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21004), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21808), (object)enhinputdata.BackgroundColor.ToString());
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21841), (object)enhinputdata.TextColor.ToString());
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21862), (object)converter.ConvertToString(((object)enhinputdata.TextFont).ToString()));
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21881), (object)enhinputdata.Imagename);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21902), (object)enhinputdata.bUseEnhancedGraphics);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21943), (object)enhinputdata.NewImage);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)TheName);
		((DbCommand)val).ExecuteNonQuery();
		((Component)val).Dispose();
	}

	private Image c26f3f6e6b186490444b9e185f1837bac(Image A_1, int A_2)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		if (A_1 == null)
		{
			return A_1;
		}
		EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)A_2);
		string text = ImageFormat.Gif.Guid.ToString();
		string text2 = ImageFormat.Png.Guid.ToString();
		string text3 = A_1.RawFormat.Guid.ToString();
		if (text3 == text)
		{
			return A_1;
		}
		ImageCodecInfo val2;
		if (text3 == text2)
		{
			val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21962));
			if (val2 != null)
			{
			}
		}
		else
		{
			val2 = c16aac53cdad270401e5646e1d265fd81(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(21981));
		}
		if (val2 != null)
		{
			EncoderParameters val3 = new EncoderParameters(1);
			val3.Param[0] = val;
			MemoryStream memoryStream = new MemoryStream();
			A_1.Save((Stream)memoryStream, val2, val3);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return Image.FromStream((Stream)memoryStream);
		}
		return A_1;
	}

	private ImageCodecInfo c16aac53cdad270401e5646e1d265fd81(string A_1)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length - 1; i++)
		{
			if (imageEncoders[i].MimeType == A_1)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		byte[] buffer = null;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19504), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)TheName);
		SqlCeDataReader val2 = val.ExecuteReader();
		if (((DbDataReader)(object)val2).Read())
		{
			buffer = (byte[])((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)];
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
		foreach (string layeredImage in LayeredImages)
		{
			if (num > 0)
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929);
			}
			text += layeredImage;
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22019) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22024));
		enhinputdata.cc738ece0e9315f0db703b90a443636ff(ref stringBuilder);
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}

	public int CompareTo(object other)
	{
		return string.Compare(ToString(), other.ToString(), ignoreCase: true);
	}
}
