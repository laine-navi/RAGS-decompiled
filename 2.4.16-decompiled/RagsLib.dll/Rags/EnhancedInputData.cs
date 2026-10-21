using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class EnhancedInputData : ISerializable
{
	public Color BackgroundColor = Color.FromArgb(140, Color.White);

	public Color TextColor = Color.Black;

	public Font TextFont = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22246), 12f);

	public string Imagename = string.Empty;

	public bool bUseEnhancedGraphics = true;

	public string NewImage = string.Empty;

	public bool bAllowCancel = true;

	public EnhancedInputData()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
	}

	protected EnhancedInputData(SerializationInfo info, StreamingContext context)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected Obj, but got Unknown
		if (info != null)
		{
			__ldtoken(EnhancedInputData._002Ector(SerializationInfo, StreamingContext));
			bUseEnhancedGraphics = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948));
			if (!bUseEnhancedGraphics)
			{
				__ldtoken(EnhancedInputData._002Ector(SerializationInfo, StreamingContext));
				return;
			}
			BackgroundColor = (Color)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), BackgroundColor.GetType());
			TextColor = (Color)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), TextColor.GetType());
			TextFont = (Font)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), ((object)TextFont).GetType());
			Imagename = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201));
			bUseEnhancedGraphics = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948));
			try
			{
				NewImage = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987));
			}
			catch
			{
				NewImage = string.Empty;
			}
			try
			{
				bAllowCancel = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220));
				return;
			}
			catch
			{
				bAllowCancel = true;
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
			__ldtoken(EnhancedInputData.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), BackgroundColor, BackgroundColor.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), TextColor, TextColor.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), TextFont, ((object)TextFont).GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201), Imagename, Imagename.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), bUseEnhancedGraphics, bUseEnhancedGraphics.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), NewImage, NewImage.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220), bAllowCancel, bAllowCancel.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948));
		if (xMLSection == null)
		{
			__ldtoken(EnhancedInputData.SetXMLData(ref XmlNode));
		}
		else
		{
			bUseEnhancedGraphics = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220));
		if (xMLSection == null)
		{
			__ldtoken(EnhancedInputData.SetXMLData(ref XmlNode));
		}
		else
		{
			bAllowCancel = Convert.ToBoolean(xMLSection.InnerText);
		}
		if (!bUseEnhancedGraphics)
		{
			return;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862));
		if (xMLSection != null)
		{
			try
			{
				BackgroundColor = Color.FromArgb(Convert.ToInt32(xMLSection.InnerText));
			}
			catch
			{
				BackgroundColor = Color.FromArgb(-1929379841);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893));
		if (xMLSection == null)
		{
			__ldtoken(EnhancedInputData.SetXMLData(ref XmlNode));
		}
		else
		{
			try
			{
				TextColor = Color.FromArgb(Convert.ToInt32(xMLSection.InnerText));
			}
			catch
			{
				TextColor = Color.Black;
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201));
		if (xMLSection != null)
		{
			Imagename = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987));
		if (xMLSection == null)
		{
			__ldtoken(EnhancedInputData.SetXMLData(ref XmlNode));
		}
		else
		{
			NewImage = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912));
	}

	internal void c83abeab8711e52857623283ffa75d603(ref StreamWriter P_0)
	{
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), BackgroundColor.ToArgb().ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), TextColor.ToArgb().ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201), Imagename);
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220), bAllowCancel.ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), converter.ConvertToString(TextFont));
	}

	internal void c83abeab8711e52857623283ffa75d603(ref StringBuilder P_0)
	{
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), BackgroundColor.ToArgb().ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), TextColor.ToArgb().ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201), Imagename);
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220), bAllowCancel.ToString());
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddXMLSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), converter.ConvertToString(TextFont));
	}

	internal void ccef548bf55bee990390aeff0f78d8f5f(ref StringBuilder P_0)
	{
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20862), BackgroundColor.ToArgb().ToString());
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20893), TextColor.ToArgb().ToString());
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22201), Imagename);
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20948), bUseEnhancedGraphics.ToString());
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22220), bAllowCancel.ToString());
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20987), NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddAdvSection(ref P_0, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(20912), converter.ConvertToString(TextFont));
	}

	internal void cc738ece0e9315f0db703b90a443636ff(ref StringBuilder P_0)
	{
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + BackgroundColor.ToArgb() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + TextColor.ToArgb() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Imagename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(bUseEnhancedGraphics.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		P_0.Append(bAllowCancel.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + NewImage + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + converter.ConvertToString(TextFont) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
	}
}
