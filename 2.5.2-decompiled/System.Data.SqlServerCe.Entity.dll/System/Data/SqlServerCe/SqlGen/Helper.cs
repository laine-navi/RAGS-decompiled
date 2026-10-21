using System.Collections.Generic;
using System.Data.Metadata.Edm;

namespace System.Data.SqlServerCe.SqlGen;

internal static class Helper
{
	internal static FacetDescription GetFacet(IEnumerable<FacetDescription> facetCollection, string facetName)
	{
		foreach (FacetDescription item in facetCollection)
		{
			if (item.FacetName == facetName)
			{
				return item;
			}
		}
		return null;
	}

	internal static bool IsUnboundedFacetValue(Facet facet)
	{
		if (facet.Value != null)
		{
			return facet.Value.GetType().FullName.Equals("System.Data.Metadata.Edm.EdmConstants+Unbounded");
		}
		return true;
	}
}
