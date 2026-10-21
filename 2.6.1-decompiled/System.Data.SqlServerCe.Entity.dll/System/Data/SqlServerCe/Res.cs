using System.Globalization;
using System.Resources;

namespace System.Data.SqlServerCe;

internal sealed class Res
{
	internal const string InvalidStringArgument = "InvalidStringArgument";

	internal const string Mapping_Provider_WrongConnectionType = "Mapping_Provider_WrongConnectionType";

	internal const string Update_SqlEntitySetWithoutDmlFunctions = "Update_SqlEntitySetWithoutDmlFunctions";

	internal const string Mapping_Provider_WrongManifestType = "Mapping_Provider_WrongManifestType";

	internal const string ProviderReturnedNullForGetDbInformation = "ProviderReturnedNullForGetDbInformation";

	internal const string UnableToDetermineStoreVersion = "UnableToDetermineStoreVersion";

	internal const string InvalidDatePartArgumentExpression = "InvalidDatePartArgumentExpression";

	internal const string InvalidDatePartArgumentValue = "InvalidDatePartArgumentValue";

	internal const string NiladicFunctionsCannotHaveParameters = "NiladicFunctionsCannotHaveParameters";

	internal const string UnknownExpressionType = "UnknownExpressionType";

	internal const string FullOuterJoinNotSupported = "FullOuterJoinNotSupported";

	internal const string CollateInOrderByNotSupported = "CollateInOrderByNotSupported";

	internal const string DMLQueryCannotReturnResults = "DMLQueryCannotReturnResults";

	internal const string SkipNotSupportedException = "SkipNotSupportedException";

	internal const string WithTiesNotSupportedException = "WithTiesNotSupportedException";

	internal const string UserDefinedFunctionsNotSupported = "UserDefinedFunctionsNotSupported";

	internal const string TVFsNotSupported = "TVFsNotSupported";

	internal const string DistinctAggregatesNotSupported = "DistinctAggregatesNotSupported";

	internal const string ProviderDoesNotSupportType = "ProviderDoesNotSupportType";

	internal const string NoStoreTypeForEdmType = "NoStoreTypeForEdmType";

	internal const string StoredProceduresNotSupported = "StoredProceduresNotSupported";

	internal const string FunctionNotSupported = "FunctionNotSupported";

	internal const string UpdateStatementCannotBeGeneratedForAcquiringLock = "UpdateStatementCannotBeGeneratedForAcquiringLock";

	internal const string ADP_InternalProviderError = "ADP_InternalProviderError";

	internal const string ADP_InvalidEnumerationValue = "ADP_InvalidEnumerationValue";

	internal const string ADP_NotSupportedEnumerationValue = "ADP_NotSupportedEnumerationValue";

	internal const string ADP_ConnectionStringSyntax = "ADP_ConnectionStringSyntax";

	internal const string ADP_InvalidConnectionOptionValue = "ADP_InvalidConnectionOptionValue";

	private static Res loader;

	private ResourceManager resources;

	private Res()
	{
		resources = new ResourceManager("System.Data.SqlServerCe.Entity", GetType().Module.Assembly);
	}

	private static Res GetLoader()
	{
		if (loader == null)
		{
			lock (typeof(Res))
			{
				if (loader == null)
				{
					loader = new Res();
				}
			}
		}
		return loader;
	}

	public static string GetString(string name, params object[] args)
	{
		return GetString(null, name, args);
	}

	public static string GetString(CultureInfo culture, string name, params object[] args)
	{
		string text = null;
		try
		{
			Res res = GetLoader();
			if (res == null)
			{
				return null;
			}
			text = res.resources.GetString(name, culture);
			if (args != null && args.Length > 0)
			{
				return string.Format(CultureInfo.CurrentCulture, text, args);
			}
			return text;
		}
		catch (FormatException)
		{
			return text;
		}
	}

	public static string GetString(string name)
	{
		return GetString(null, name);
	}

	public static string GetString(CultureInfo culture, string name)
	{
		return GetLoader()?.resources.GetString(name, culture);
	}
}
