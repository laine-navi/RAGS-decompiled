using System;
using System.Collections;
using System.Xml.Serialization;
using Rags.ragsgame.com;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public class XmlSerializerContract : XmlSerializerImplementation
{
	private Hashtable readMethods;

	private Hashtable writeMethods;

	private Hashtable typedSerializers;

	public override XmlSerializationReader Reader => new XmlSerializationReaderCheckUpdates();

	public override XmlSerializationWriter Writer => new XmlSerializationWriterCheckUpdates();

	public override Hashtable ReadMethods
	{
		get
		{
			if (readMethods == null)
			{
				Hashtable hashtable = new Hashtable();
				hashtable["Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():Response"] = "Read4_CheckVersionResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():OutHeaders"] = "Read5_CheckVersionResponseOutHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):Response"] = "Read6_RegisterResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):OutHeaders"] = "Read7_RegisterResponseOutHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():Response"] = "Read8_GetShareDataSummaryResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():OutHeaders"] = "Read9_Item";
				hashtable["Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):Response"] = "Read10_DownloadShareResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):OutHeaders"] = "Read11_Item";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):Response"] = "Read12_UploadShareResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):OutHeaders"] = "Read13_UploadShareResponseOutHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):Response"] = "Read14_RemoveShareResponse";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):OutHeaders"] = "Read15_RemoveShareResponseOutHeaders";
				if (readMethods == null)
				{
					readMethods = hashtable;
				}
			}
			return readMethods;
		}
	}

	public override Hashtable WriteMethods
	{
		get
		{
			if (writeMethods == null)
			{
				Hashtable hashtable = new Hashtable();
				hashtable["Rags.ragsgame.com.CheckUpdates:System.String CheckVersion()"] = "Write4_CheckVersion";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():InHeaders"] = "Write5_CheckVersionInHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String)"] = "Write6_Register";
				hashtable["Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):InHeaders"] = "Write7_RegisterInHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary()"] = "Write8_GetShareDataSummary";
				hashtable["Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():InHeaders"] = "Write9_GetShareDataSummaryInHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32)"] = "Write10_DownloadShare";
				hashtable["Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):InHeaders"] = "Write11_DownloadShareInHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String)"] = "Write12_UploadShare";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):InHeaders"] = "Write13_UploadShareInHeaders";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String)"] = "Write14_RemoveShare";
				hashtable["Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):InHeaders"] = "Write15_RemoveShareInHeaders";
				if (writeMethods == null)
				{
					writeMethods = hashtable;
				}
			}
			return writeMethods;
		}
	}

	public override Hashtable TypedSerializers
	{
		get
		{
			if (typedSerializers == null)
			{
				Hashtable hashtable = new Hashtable();
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer5());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):OutHeaders", new ArrayOfObjectSerializer19());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():OutHeaders", new ArrayOfObjectSerializer11());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32)", new ArrayOfObjectSerializer12());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():InHeaders", new ArrayOfObjectSerializer2());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():InHeaders", new ArrayOfObjectSerializer10());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.String CheckVersion()", new ArrayOfObjectSerializer());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):InHeaders", new ArrayOfObjectSerializer18());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary():Response", new ArrayOfObjectSerializer9());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):Response", new ArrayOfObjectSerializer21());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer6());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.Object[] GetShareDataSummary()", new ArrayOfObjectSerializer8());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):Response", new ArrayOfObjectSerializer13());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):InHeaders", new ArrayOfObjectSerializer22());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):OutHeaders", new ArrayOfObjectSerializer15());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String)", new ArrayOfObjectSerializer4());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():OutHeaders", new ArrayOfObjectSerializer3());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Rags.ragsgame.com.RegData Register(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer7());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String):Response", new ArrayOfObjectSerializer17());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String)", new ArrayOfObjectSerializer20());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void UploadShare(Rags.ragsgame.com.ShareData, Byte[], System.String)", new ArrayOfObjectSerializer16());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Byte[] DownloadShare(Int32):InHeaders", new ArrayOfObjectSerializer14());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:System.String CheckVersion():Response", new ArrayOfObjectSerializer1());
				hashtable.Add("Rags.ragsgame.com.CheckUpdates:Void RemoveShare(Int32, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer23());
				if (typedSerializers == null)
				{
					typedSerializers = hashtable;
				}
			}
			return typedSerializers;
		}
	}

	public override bool CanSerialize(Type type)
	{
		if (type == typeof(CheckUpdates))
		{
			return true;
		}
		return false;
	}

	public override XmlSerializer GetSerializer(Type type)
	{
		return null;
	}
}
