using System.Collections.Generic;
using System.Data.Metadata.Edm;

namespace System.Data.SqlServerCe.SqlGen;

internal static class TypeHelpers
{
	internal static readonly EdmProperty[] EmptyArrayEdmProperty = new EdmProperty[0];

	internal static bool TryGetTypeFacetDescriptionByName(EdmType edmType, string facetName, out FacetDescription facetDescription)
	{
		facetDescription = null;
		PrimitiveType val = (PrimitiveType)(object)((edmType is PrimitiveType) ? edmType : null);
		if (val != null)
		{
			foreach (FacetDescription facetDescription2 in val.FacetDescriptions)
			{
				if (facetName.Equals(facetDescription2.FacetName, StringComparison.OrdinalIgnoreCase))
				{
					facetDescription = facetDescription2;
					return true;
				}
			}
		}
		return false;
	}

	internal static bool TryGetBooleanFacetValue(TypeUsage type, string facetName, out bool boolValue)
	{
		boolValue = false;
		Facet val = default;
		if (type.Facets.TryGetValue(facetName, false, ref val) && val.Value != null && !Helper.IsUnboundedFacetValue(val))
		{
			boolValue = (bool)val.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetIntFacetValue(TypeUsage type, string facetName, out int intValue)
	{
		intValue = 0;
		Facet val = default;
		if (type.Facets.TryGetValue(facetName, false, ref val) && val.Value != null && !Helper.IsUnboundedFacetValue(val))
		{
			intValue = (int)val.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetByteFacetValue(TypeUsage type, string facetName, out byte byteValue)
	{
		byteValue = 0;
		Facet val = default;
		if (type.Facets.TryGetValue(facetName, false, ref val) && val.Value != null && !Helper.IsUnboundedFacetValue(val))
		{
			byteValue = (byte)val.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetPrimitiveTypeKind(TypeUsage type, out PrimitiveTypeKind typeKind)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected I4, but got Unknown
		if (type != null && type.EdmType != null && (int)((MetadataItem)type.EdmType).BuiltInTypeKind == 26)
		{
			typeKind = (PrimitiveTypeKind)(int)((PrimitiveType)type.EdmType).PrimitiveTypeKind;
			return true;
		}
		typeKind = (PrimitiveTypeKind)0;
		return false;
	}

	internal static bool TryGetPrecision(TypeUsage type, out byte precision)
	{
		if (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)4))
		{
			precision = 0;
			return false;
		}
		return TryGetByteFacetValue(type, "Precision", out precision);
	}

	internal static bool TryGetScale(TypeUsage type, out byte scale)
	{
		if (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)4))
		{
			scale = 0;
			return false;
		}
		return TryGetByteFacetValue(type, "Scale", out scale);
	}

	internal static bool TryGetIsFixedLength(TypeUsage type, out bool isFixedLength)
	{
		if (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)12) && !TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)0))
		{
			isFixedLength = false;
			return false;
		}
		return TryGetBooleanFacetValue(type, "FixedLength", out isFixedLength);
	}

	internal static bool TryGetIsUnicode(TypeUsage type, out bool isUnicode)
	{
		isUnicode = true;
		if (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)12))
		{
			isUnicode = false;
			return false;
		}
		return true;
	}

	internal static bool IsFacetValueConstant(TypeUsage type, string facetName)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return Helper.GetFacet(((PrimitiveType)type.EdmType).FacetDescriptions, facetName).IsConstant;
	}

	internal static bool TryGetMaxLength(TypeUsage type, out int maxLength)
	{
		if (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)12) && !TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)0))
		{
			maxLength = 0;
			return false;
		}
		return TryGetIntFacetValue(type, "MaxLength", out maxLength);
	}

	internal static bool HasNulledOutFacetValues(TypeUsage type)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		PrimitiveType edmType = TypeHelpers.GetEdmType<PrimitiveType>(type);
		bool flag = true;
		int maxLength = 0;
		byte precision = 0;
		byte scale = 0;
		PrimitiveTypeKind primitiveTypeKind = edmType.PrimitiveTypeKind;
		if ((int)primitiveTypeKind == 0)
		{
			goto IL_0028;
		}
		if ((int)primitiveTypeKind != 4)
		{
			if ((int)primitiveTypeKind == 12)
			{
				goto IL_0028;
			}
			flag = true;
		}
		else
		{
			flag = TryGetPrecision(type, out precision);
			if (flag)
			{
				flag = TryGetScale(type, out scale);
			}
		}
		goto IL_004c;
		IL_004c:
		return !flag;
		IL_0028:
		flag = TryGetMaxLength(type, out maxLength);
		goto IL_004c;
	}

	internal static string PrimitiveTypeName(TypeUsage type)
	{
		PrimitiveType edmType = TypeHelpers.GetEdmType<PrimitiveType>(type);
		return ((EdmType)edmType).Name;
	}

	internal static IList<EdmProperty> GetProperties(TypeUsage typeUsage)
	{
		return GetProperties(typeUsage.EdmType);
	}

	internal static IList<EdmProperty> GetProperties(EdmType edmType)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		BuiltInTypeKind builtInTypeKind = ((MetadataItem)edmType).BuiltInTypeKind;
		if ((int)builtInTypeKind != 8)
		{
			if ((int)builtInTypeKind != 14)
			{
				if ((int)builtInTypeKind == 36)
				{
					return (IList<EdmProperty>)((RowType)edmType).Properties;
				}
				return EmptyArrayEdmProperty;
			}
			return (IList<EdmProperty>)((EntityType)edmType).Properties;
		}
		return (IList<EdmProperty>)((ComplexType)edmType).Properties;
	}

	internal static TypeUsage GetElementTypeUsage(TypeUsage type)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (TypeSemantics.IsCollectionType(type))
		{
			return ((CollectionType)type.EdmType).TypeUsage;
		}
		if (TypeSemantics.IsReferenceType(type))
		{
			throw new NotSupportedException(string.Empty);
		}
		return null;
	}

	internal static bool IsCanonicalFunction(EdmFunction function)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		MetadataProperty val = default;
		if (((MetadataItem)function).MetadataProperties.TryGetValue("DataSpace", false, ref val) && val.Value != null)
		{
			return (int)(DataSpace)val.Value == 1;
		}
		return false;
	}

	internal static TEdmType GetEdmType<TEdmType>(TypeUsage typeUsage) where TEdmType : EdmType
	{
		return (TEdmType)(object)typeUsage.EdmType;
	}

	internal static bool TryGetEdmType<TEdmType>(TypeUsage typeUsage, out TEdmType type) where TEdmType : EdmType
	{
		EdmType edmType = typeUsage.EdmType;
		type = (TEdmType)(object)((edmType is TEdmType) ? edmType : null);
		return type != null;
	}
}
