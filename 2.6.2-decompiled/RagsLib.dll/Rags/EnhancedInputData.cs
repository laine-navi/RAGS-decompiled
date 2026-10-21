using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class EnhancedInputData : ISerializable
{
	public Color BackgroundColor = Color.FromArgb(140, Color.White);

	public Color TextColor = Color.Black;

	public Font TextFont = new Font("Times New Roman Bold", 12f);

	public string Imagename = string.Empty;

	public bool bUseEnhancedGraphics = true;

	public string NewImage = string.Empty;

	public bool bAllowCancel = true;

	public EnhancedInputData()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
	}

	protected EnhancedInputData(SerializationInfo info, StreamingContext context)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Obj, but got Unknown
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		bUseEnhancedGraphics = info.GetBoolean("UseEnhancedGraphics");
		if (bUseEnhancedGraphics)
		{
			BackgroundColor = (Color)info.GetValue("BackgroundColor", BackgroundColor.GetType());
			TextColor = (Color)info.GetValue("TextColor", TextColor.GetType());
			TextFont = (Font)info.GetValue("TextFont", ((object)TextFont).GetType());
			Imagename = info.GetString("Imagename");
			bUseEnhancedGraphics = info.GetBoolean("UseEnhancedGraphics");
			try
			{
				NewImage = info.GetString("NewImage");
			}
			catch
			{
				NewImage = string.Empty;
			}
			try
			{
				bAllowCancel = info.GetBoolean("AllowCancel");
			}
			catch
			{
				bAllowCancel = true;
			}
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("BackgroundColor", BackgroundColor, BackgroundColor.GetType());
		info.AddValue("TextColor", TextColor, TextColor.GetType());
		info.AddValue("TextFont", TextFont, ((object)TextFont).GetType());
		info.AddValue("Imagename", Imagename, Imagename.GetType());
		info.AddValue("UseEnhancedGraphics", bUseEnhancedGraphics, bUseEnhancedGraphics.GetType());
		info.AddValue("NewImage", NewImage, NewImage.GetType());
		info.AddValue("AllowCancel", bAllowCancel, bAllowCancel.GetType());
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "UseEnhancedGraphics");
		if (xMLSection != null)
		{
			bUseEnhancedGraphics = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "AllowCancel");
		if (xMLSection != null)
		{
			bAllowCancel = Convert.ToBoolean(xMLSection.InnerText);
		}
		if (!bUseEnhancedGraphics)
		{
			return;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "BackgroundColor");
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
		xMLSection = Game.GetXMLSection(ref CurNode, "TextColor");
		if (xMLSection != null)
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
		xMLSection = Game.GetXMLSection(ref CurNode, "Imagename");
		if (xMLSection != null)
		{
			Imagename = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "NewImage");
		if (xMLSection != null)
		{
			NewImage = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "TextFont");
	}

	internal void a(ref StreamWriter A_0)
	{
		Game.AddXMLSection(ref A_0, "BackgroundColor", BackgroundColor.ToArgb().ToString());
		Game.AddXMLSection(ref A_0, "TextColor", TextColor.ToArgb().ToString());
		Game.AddXMLSection(ref A_0, "Imagename", Imagename);
		Game.AddXMLSection(ref A_0, "UseEnhancedGraphics", bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref A_0, "AllowCancel", bAllowCancel.ToString());
		Game.AddXMLSection(ref A_0, "NewImage", NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddXMLSection(ref A_0, "TextFont", converter.ConvertToString(TextFont));
	}

	internal void a(ref StringBuilder A_0)
	{
		Game.AddXMLSection(ref A_0, "BackgroundColor", BackgroundColor.ToArgb().ToString());
		Game.AddXMLSection(ref A_0, "TextColor", TextColor.ToArgb().ToString());
		Game.AddXMLSection(ref A_0, "Imagename", Imagename);
		Game.AddXMLSection(ref A_0, "UseEnhancedGraphics", bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref A_0, "AllowCancel", bAllowCancel.ToString());
		Game.AddXMLSection(ref A_0, "NewImage", NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddXMLSection(ref A_0, "TextFont", converter.ConvertToString(TextFont));
	}

	internal void b(ref StringBuilder A_0)
	{
		Game.AddAdvSection(ref A_0, "BackgroundColor", BackgroundColor.ToArgb().ToString());
		Game.AddAdvSection(ref A_0, "TextColor", TextColor.ToArgb().ToString());
		Game.AddAdvSection(ref A_0, "Imagename", Imagename);
		Game.AddAdvSection(ref A_0, "UseEnhancedGraphics", bUseEnhancedGraphics.ToString());
		Game.AddAdvSection(ref A_0, "AllowCancel", bAllowCancel.ToString());
		Game.AddAdvSection(ref A_0, "NewImage", NewImage);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		Game.AddAdvSection(ref A_0, "TextFont", converter.ConvertToString(TextFont));
	}

	internal void c(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"" + BackgroundColor.ToArgb() + "\",");
		A_0.Append("\"" + TextColor.ToArgb() + "\",");
		A_0.Append("\"" + Imagename + "\",");
		A_0.Append(bUseEnhancedGraphics.ToString().ToLower() + ",");
		A_0.Append(bAllowCancel.ToString().ToLower() + ",");
		A_0.Append("\"" + NewImage + "\",");
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		A_0.Append("\"" + converter.ConvertToString(TextFont) + "\"");
		A_0.Append("]");
	}
}
