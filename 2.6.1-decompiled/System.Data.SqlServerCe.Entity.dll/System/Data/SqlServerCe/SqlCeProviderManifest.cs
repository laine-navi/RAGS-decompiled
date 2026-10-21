using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Metadata.Edm;
using System.Data.SqlServerCe.SqlGen;
using System.Reflection;
using System.Xml;

namespace System.Data.SqlServerCe;

internal class SqlCeProviderManifest : DbXmlEnabledProviderManifest
{
	internal const string ProviderInvariantName = "System.Data.SqlServerCe.3.5";

	internal const string Token35 = "3.5";

	private const string _token = "3.5";

	private const int nvarcharMaxSize = 4000;

	private const int binaryMaxSize = 8000;

	private const string providerManifestFile = "System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.ProviderManifest.xml";

	private const string storeSchemaMappingFile = "System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.StoreSchemaMapping.msl";

	private const string storeSchemaDescriptionFile = "System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.StoreSchemaDefinition.ssdl";

	private const string storeSchemaDescriptionFileForRDP = "Microsoft.SqlServerCe.Client.Resources.Entity.SqlCeProviderServices.StoreSchemaDefinition.ssdl";

	internal static readonly SqlCeProviderManifest Instance = new SqlCeProviderManifest("3.5", isLocalProvider: true);

	internal bool _isLocalProvider = true;

	private ReadOnlyCollection<PrimitiveType> _primitiveTypes;

	private ReadOnlyCollection<EdmFunction> _functions;

	public SqlCeProviderManifest(string manifestToken, bool isLocalProvider)
		: base(GetProviderManifest())
	{
		_isLocalProvider = isLocalProvider;
	}

	private static XmlReader GetProviderManifest()
	{
		return GetXmlResource("System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.ProviderManifest.xml");
	}

	protected override XmlReader GetDbInformation(string informationType)
	{
		if (informationType == ProviderManifest.StoreSchemaDefinition)
		{
			return GetStoreSchemaDescription();
		}
		if (informationType == ProviderManifest.StoreSchemaMapping)
		{
			return GetStoreSchemaMapping();
		}
		if (informationType == ProviderManifest.ConceptualSchemaDefinition)
		{
			return null;
		}
		throw ADP1.ProviderIncompatible(Res.GetString("ProviderReturnedNullForGetDbInformation", informationType));
	}

	public override ReadOnlyCollection<PrimitiveType> GetStoreTypes()
	{
		if (_primitiveTypes == null)
		{
			_primitiveTypes = ((DbXmlEnabledProviderManifest)this).GetStoreTypes();
		}
		return _primitiveTypes;
	}

	public override ReadOnlyCollection<EdmFunction> GetStoreFunctions()
	{
		if (_functions == null)
		{
			_functions = ((DbXmlEnabledProviderManifest)this).GetStoreFunctions();
		}
		return _functions;
	}

	public override TypeUsage GetEdmType(TypeUsage storeType)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Invalid comparison between Unknown and I4
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Invalid comparison between Unknown and I4
		ADP1.CheckArgumentNull<TypeUsage>(storeType, "storeType");
		string text = storeType.EdmType.Name.ToLowerInvariant();
		if (!((DbXmlEnabledProviderManifest)this).StoreTypeNameToEdmPrimitiveType.ContainsKey(text))
		{
			throw ADP1.Argument(Res.GetString("ProviderDoesNotSupportType", text));
		}
		PrimitiveType val = ((DbXmlEnabledProviderManifest)this).StoreTypeNameToEdmPrimitiveType[text];
		int maxLength = 0;
		bool flag = true;
		bool flag2 = false;
		bool flag3 = true;
		PrimitiveTypeKind val2;
		switch (text)
		{
		case "tinyint":
		case "smallint":
		case "bigint":
		case "bit":
		case "uniqueidentifier":
		case "int":
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)val);
		case "nvarchar":
			val2 = (PrimitiveTypeKind)12;
			flag3 = !TypeHelpers.TryGetMaxLength(storeType, out maxLength);
			flag = true;
			flag2 = false;
			break;
		case "nchar":
			val2 = (PrimitiveTypeKind)12;
			flag3 = !TypeHelpers.TryGetMaxLength(storeType, out maxLength);
			flag = true;
			flag2 = true;
			break;
		case "ntext":
			val2 = (PrimitiveTypeKind)12;
			flag3 = true;
			flag = true;
			flag2 = false;
			break;
		case "binary":
			val2 = (PrimitiveTypeKind)0;
			flag3 = !TypeHelpers.TryGetMaxLength(storeType, out maxLength);
			flag2 = true;
			break;
		case "varbinary":
			val2 = (PrimitiveTypeKind)0;
			flag3 = !TypeHelpers.TryGetMaxLength(storeType, out maxLength);
			flag2 = false;
			break;
		case "image":
			val2 = (PrimitiveTypeKind)0;
			flag3 = true;
			flag2 = false;
			break;
		case "timestamp":
		case "rowversion":
			return TypeUsage.CreateBinaryTypeUsage(val, true, 8);
		case "float":
		case "real":
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)val);
		case "decimal":
		case "numeric":
		{
			if (TypeHelpers.TryGetPrecision(storeType, out var precision) && TypeHelpers.TryGetScale(storeType, out var scale))
			{
				return TypeUsage.CreateDecimalTypeUsage(val, precision, scale);
			}
			return TypeUsage.CreateDecimalTypeUsage(val);
		}
		case "money":
			return TypeUsage.CreateDecimalTypeUsage(val, (byte)19, (byte)4);
		case "datetime":
			return TypeUsage.CreateDateTimeTypeUsage(val, (byte?)null);
		default:
			throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", text));
		}
		PrimitiveTypeKind val3 = val2;
		if ((int)val3 != 0)
		{
			if ((int)val3 == 12)
			{
				if (!flag3)
				{
					return TypeUsage.CreateStringTypeUsage(val, flag, flag2, maxLength);
				}
				return TypeUsage.CreateStringTypeUsage(val, flag, flag2);
			}
			throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", text));
		}
		if (!flag3)
		{
			return TypeUsage.CreateBinaryTypeUsage(val, flag2, maxLength);
		}
		return TypeUsage.CreateBinaryTypeUsage(val, flag2);
	}

	public override TypeUsage GetStoreType(TypeUsage edmType)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected I4, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		ADP1.CheckArgumentNull<TypeUsage>(edmType, "edmType");
		EdmType edmType2 = edmType.EdmType;
		PrimitiveType val = (PrimitiveType)(object)((edmType2 is PrimitiveType) ? edmType2 : null);
		if (val == null)
		{
			throw ADP1.Argument(Res.GetString("ProviderDoesNotSupportType", edmType.EdmType));
		}
		ReadOnlyMetadataCollection<Facet> facets = edmType.Facets;
		PrimitiveTypeKind primitiveTypeKind = val.PrimitiveTypeKind;
		switch ((int)primitiveTypeKind)
		{
		case 1:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["bit"]);
		case 2:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["tinyint"]);
		case 9:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["smallint"]);
		case 10:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["int"]);
		case 11:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["bigint"]);
		case 6:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["uniqueidentifier"]);
		case 5:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["float"]);
		case 7:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["real"]);
		case 4:
		{
			if (!TypeHelpers.TryGetPrecision(edmType, out var precision))
			{
				precision = 18;
			}
			if (!TypeHelpers.TryGetScale(edmType, out var scale))
			{
				scale = 0;
			}
			return TypeUsage.CreateDecimalTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["decimal"], precision, scale);
		}
		case 0:
		{
			bool flag3 = facets["FixedLength"].Value != null && (bool)facets["FixedLength"].Value;
			Facet val3 = facets["MaxLength"];
			bool flag4 = Helper.IsUnboundedFacetValue(val3) || val3.Value == null || (int)val3.Value > 8000;
			int num2 = ((!flag4) ? ((int)val3.Value) : int.MinValue);
			if (flag3)
			{
				return TypeUsage.CreateBinaryTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["binary"], true, flag4 ? 8000 : num2);
			}
			if (flag4)
			{
				return TypeUsage.CreateBinaryTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["varbinary"], false, 8000);
			}
			return TypeUsage.CreateBinaryTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["varbinary"], false, num2);
		}
		case 12:
		{
			if (facets["Unicode"].Value != null)
			{
				_ = (bool)facets["Unicode"].Value;
			}
			bool flag = facets["FixedLength"].Value != null && (bool)facets["FixedLength"].Value;
			Facet val2 = facets["MaxLength"];
			bool flag2 = Helper.IsUnboundedFacetValue(val2) || val2.Value == null || (int)val2.Value > 4000;
			int num = ((!flag2) ? ((int)val2.Value) : int.MinValue);
			if (flag)
			{
				return TypeUsage.CreateStringTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["nchar"], true, true, flag2 ? 4000 : num);
			}
			if (flag2)
			{
				return TypeUsage.CreateStringTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["nvarchar"], true, false, 4000);
			}
			return TypeUsage.CreateStringTypeUsage(((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["nvarchar"], true, false, num);
		}
		case 3:
			return TypeUsage.CreateDefaultTypeUsage((EdmType)(object)((DbXmlEnabledProviderManifest)this).StoreTypeNameToStorePrimitiveType["datetime"]);
		default:
			throw ADP1.NotSupported(Res.GetString("NoStoreTypeForEdmType", val.PrimitiveTypeKind));
		}
	}

	private XmlReader GetStoreSchemaMapping()
	{
		return GetXmlResource("System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.StoreSchemaMapping.msl");
	}

	private XmlReader GetStoreSchemaDescription()
	{
		if (_isLocalProvider)
		{
			return GetXmlResource("System.Data.Resources.SqlServerCe.Entity.SqlCeProviderServices.StoreSchemaDefinition.ssdl");
		}
		return GetXmlResource("Microsoft.SqlServerCe.Client.Resources.Entity.SqlCeProviderServices.StoreSchemaDefinition.ssdl");
	}

	private static XmlReader GetXmlResource(string resourceName)
	{
		return XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName), null, resourceName);
	}
}
