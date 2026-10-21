using System;
using System.Collections;
using System.Xml.Serialization;
using RagsDesigner.ragsgame.com;

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
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():Response"] = "Read3_HelloWorldResponse";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():OutHeaders"] = "Read4_HelloWorldResponseOutHeaders";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():Response"] = "Read5_CheckVersionResponse";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():OutHeaders"] = "Read6_CheckVersionResponseOutHeaders";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():Response"] = "Read7_CheckBetaVersionResponse";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():OutHeaders"] = "Read8_Item";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):Response"] = "Read9_RegisterResponse";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):OutHeaders"] = "Read10_RegisterResponseOutHeaders";
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
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld()"] = "Write3_HelloWorld";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():InHeaders"] = "Write4_HelloWorldInHeaders";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion()"] = "Write5_CheckVersion";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():InHeaders"] = "Write6_CheckVersionInHeaders";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion()"] = "Write7_CheckBetaVersion";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():InHeaders"] = "Write8_CheckBetaVersionInHeaders";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String)"] = "Write9_Register";
				hashtable["RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):InHeaders"] = "Write10_RegisterInHeaders";
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
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():InHeaders", new ArrayOfObjectSerializer2());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion()", new ArrayOfObjectSerializer8());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer13());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():Response", new ArrayOfObjectSerializer5());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer15());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String)", new ArrayOfObjectSerializer12());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():Response", new ArrayOfObjectSerializer9());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():OutHeaders", new ArrayOfObjectSerializer3());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion()", new ArrayOfObjectSerializer4());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld()", new ArrayOfObjectSerializer());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:RagsDesigner.ragsgame.com.RegData Register(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer14());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String HelloWorld():Response", new ArrayOfObjectSerializer1());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():InHeaders", new ArrayOfObjectSerializer6());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckVersion():OutHeaders", new ArrayOfObjectSerializer7());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():OutHeaders", new ArrayOfObjectSerializer11());
				hashtable.Add("RagsDesigner.ragsgame.com.CheckUpdates:System.String CheckBetaVersion():InHeaders", new ArrayOfObjectSerializer10());
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
