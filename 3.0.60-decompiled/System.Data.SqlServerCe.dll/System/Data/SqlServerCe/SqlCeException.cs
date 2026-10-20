using System.Text;

namespace System.Data.SqlServerCe;

[Serializable]
public class SqlCeException : SystemException
{
	internal SqlCeErrorCollection errors;

	public SqlCeErrorCollection Errors
	{
		get
		{
			if (errors == null)
			{
				errors = new SqlCeErrorCollection();
			}
			return errors;
		}
	}

	public new int HResult
	{
		get
		{
			if (Errors.Count > 0)
			{
				return Errors[0].HResult;
			}
			return -1;
		}
	}

	public int NativeError
	{
		get
		{
			if (Errors.Count > 0)
			{
				return Errors[0].NativeError;
			}
			return -1;
		}
	}

	public override string Message
	{
		get
		{
			if (!string.IsNullOrEmpty(BuildExceptionMessage(Errors)))
			{
				return BuildExceptionMessage(Errors);
			}
			return base.Message;
		}
	}

	public override string Source
	{
		get
		{
			if (Errors.Count > 0)
			{
				return Errors[0].Source;
			}
			return string.Empty;
		}
	}

	internal SqlCeException()
		: this(string.Empty)
	{
	}

	private SqlCeException(string msg)
		: base(msg)
	{
	}

	private SqlCeException(string msg, Exception inner)
		: base(msg, inner)
	{
	}

	private static string BuildExceptionMessage(SqlCeErrorCollection errors)
	{
		if (errors != null && errors.Count > 0)
		{
			return errors[0].Message;
		}
		return string.Empty;
	}

	internal static SqlCeException FillErrorInformation(int hr, IntPtr pIError)
	{
		SqlCeErrorCollection sqlCeErrorCollection = new SqlCeErrorCollection();
		sqlCeErrorCollection.FillErrorInformation(hr, pIError);
		return CreateException(sqlCeErrorCollection);
	}

	internal static SqlCeException FillErrorCollection(int hr, IntPtr pISSCEErrors)
	{
		SqlCeErrorCollection sqlCeErrorCollection = new SqlCeErrorCollection();
		sqlCeErrorCollection.FillErrorCollection(hr, pISSCEErrors);
		return CreateException(sqlCeErrorCollection);
	}

	internal static SqlCeException CreateException(SqlCeErrorCollection errors)
	{
		SqlCeException ex = null;
		ex = errors[0].NativeError switch
		{
			25090 => new SqlCeLockTimeoutException(), 
			25126 => new SqlCeTransactionInProgressException(), 
			25138 => new SqlCeInvalidDatabaseFormatException(), 
			_ => new SqlCeException(BuildExceptionMessage(errors)), 
		};
		ex.errors = errors;
		return ex;
	}

	internal static SqlCeException CreateException(string message)
	{
		return new SqlCeException(message);
	}

	internal static SqlCeException CreateException(string message, Exception inner)
	{
		return new SqlCeException(message, inner);
	}

	public override string ToString()
	{
		if (Errors.Count == 0)
		{
			return Message;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Errors.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append("; ");
			}
			stringBuilder.Append(Errors[i].Message);
		}
		return stringBuilder.ToString();
	}
}
