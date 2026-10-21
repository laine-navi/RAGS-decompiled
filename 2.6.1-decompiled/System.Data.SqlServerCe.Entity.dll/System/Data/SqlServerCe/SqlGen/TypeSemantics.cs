using System.Data.Metadata.Edm;

namespace System.Data.SqlServerCe.SqlGen;

internal static class TypeSemantics
{
	internal static bool IsCollectionType(TypeUsage type)
	{
		return IsCollectionType(type.EdmType);
	}

	internal static bool IsRowType(TypeUsage type)
	{
		return IsRowType(type.EdmType);
	}

	internal static bool IsPrimitiveType(TypeUsage type)
	{
		return IsPrimitiveType(type.EdmType);
	}

	internal static bool IsReferenceType(TypeUsage type)
	{
		return IsRefType(type.EdmType);
	}

	internal static bool IsCollectionType(EdmType type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between I4 and Unknown
		return 6 == (int)((MetadataItem)type).BuiltInTypeKind;
	}

	internal static bool IsRowType(EdmType type)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between I4 and Unknown
		return 36 == (int)((MetadataItem)type).BuiltInTypeKind;
	}

	internal static bool IsPrimitiveType(EdmType type)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between I4 and Unknown
		return 26 == (int)((MetadataItem)type).BuiltInTypeKind;
	}

	internal static bool IsRefType(EdmType type)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between I4 and Unknown
		return 31 == (int)((MetadataItem)type).BuiltInTypeKind;
	}

	internal static bool IsPrimitiveType(TypeUsage type, PrimitiveTypeKind primitiveType)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (TypeHelpers.TryGetPrimitiveTypeKind(type, out var typeKind))
		{
			return typeKind == primitiveType;
		}
		return false;
	}

	internal static bool IsNullable(TypeUsage type)
	{
		Facet val = default;
		if (type.Facets.TryGetValue("Nullable", false, ref val))
		{
			return (bool)val.Value;
		}
		return false;
	}

	internal static PrimitiveTypeKind GetPrimitiveTypeKind(TypeUsage typeUsage)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		PrimitiveType val = (PrimitiveType)typeUsage.EdmType;
		return val.PrimitiveTypeKind;
	}

	internal static DbType GetDbType(PrimitiveTypeKind primitiveType)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected I4, but got Unknown
		return (int)primitiveType switch
		{
			0 => DbType.Binary, 
			1 => DbType.Boolean, 
			2 => DbType.Byte, 
			3 => DbType.DateTime, 
			4 => DbType.Decimal, 
			5 => DbType.Double, 
			7 => DbType.Single, 
			6 => DbType.Guid, 
			9 => DbType.Int16, 
			10 => DbType.Int32, 
			11 => DbType.Int64, 
			12 => DbType.String, 
			_ => throw ADP1.InvalidOperation(string.Empty), 
		};
	}
}
