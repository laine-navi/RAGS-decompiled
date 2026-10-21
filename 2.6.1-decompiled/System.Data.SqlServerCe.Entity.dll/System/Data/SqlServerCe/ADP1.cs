using System.Globalization;

namespace System.Data.SqlServerCe;

internal static class ADP1
{
	internal enum InternalErrorCode
	{
		SqlGenParametersNotPermitted = 1017
	}

	internal const string Parameter = "Parameter";

	internal const string ParameterName = "ParameterName";

	internal const CompareOptions compareOptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;

	internal static ArgumentException Argument(string error)
	{
		return new ArgumentException(error);
	}

	internal static ArgumentNullException ArgumentNull(string parameter)
	{
		return new ArgumentNullException(parameter);
	}

	internal static InvalidOperationException InvalidOperation(string error)
	{
		return new InvalidOperationException(error);
	}

	internal static NotImplementedException NotImplemented(string error)
	{
		return new NotImplementedException(error);
	}

	internal static NotSupportedException NotSupported()
	{
		return new NotSupportedException();
	}

	internal static NotSupportedException NotSupported(string error)
	{
		return new NotSupportedException(error);
	}

	internal static MetadataException Metadata(string message)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		return new MetadataException(message);
	}

	internal static Exception InternalError(InternalErrorCode internalError)
	{
		return InvalidOperation(Res.GetString("ADP_InternalProviderError", (int)internalError));
	}

	internal static NotSupportedException FullOuterJoinNotSupportedException()
	{
		return NotSupported(Res.GetString("FullOuterJoinNotSupported"));
	}

	internal static NotSupportedException CollateInOrderByNotSupportedException()
	{
		return NotSupported(Res.GetString("CollateInOrderByNotSupported"));
	}

	internal static NotSupportedException DMLQueryCannotReturnResultsException()
	{
		return NotSupported(Res.GetString("DMLQueryCannotReturnResults"));
	}

	internal static NotSupportedException SkipNotSupportedException()
	{
		return NotSupported(Res.GetString("SkipNotSupportedException"));
	}

	internal static NotSupportedException WithTiesNotSupportedException()
	{
		return NotSupported(Res.GetString("WithTiesNotSupportedException"));
	}

	internal static UpdateException Update(string message, Exception innerException)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		return new UpdateException(message, innerException);
	}

	internal static ProviderIncompatibleException ProviderIncompatible(string message)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		return new ProviderIncompatibleException(message);
	}

	internal static T CheckArgumentNull<T>(T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw ArgumentNull(parameterName);
		}
		return value;
	}
}
