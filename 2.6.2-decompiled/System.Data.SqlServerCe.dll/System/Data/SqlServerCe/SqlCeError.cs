using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Data.SqlServerCe;

public sealed class SqlCeError
{
	private int hResult;

	private string message;

	private string formattedMessage;

	private int nativeError;

	private string source;

	private int[] numericErrorParameters = new int[3];

	private string[] errorParameters = new string[3]
	{
		string.Empty,
		string.Empty,
		string.Empty
	};

	internal static Regex ParamInfoRegex = new Regex("(?<=[\\[])[^\\[\\]]+(?=[\\]][\\s]*$)", RegexOptions.IgnoreCase);

	public int HResult => hResult;

	public string Message
	{
		get
		{
			if (formattedMessage != null)
			{
				return formattedMessage;
			}
			try
			{
				formattedMessage = FormatErrorMessage(this);
				return formattedMessage;
			}
			catch (Exception ex)
			{
				if (!ADP.IsCatchableExceptionType(ex))
				{
					throw ex;
				}
				return (message != null) ? message : string.Empty;
			}
		}
	}

	public int NativeError => nativeError;

	public string Source
	{
		get
		{
			if (source == null)
			{
				return string.Empty;
			}
			return source;
		}
	}

	public int[] NumericErrorParameters => numericErrorParameters;

	public string[] ErrorParameters => errorParameters;

	internal SqlCeError(int hResult, string message, int nativeError, string source, int numericParameter1, int numericParameter2, int numericParameter3, string errorParameter1, string errorParameter2, string errorParameter3)
	{
		this.hResult = hResult;
		this.message = message;
		this.nativeError = nativeError;
		this.source = source;
		numericErrorParameters[0] = numericParameter1;
		numericErrorParameters[1] = numericParameter2;
		numericErrorParameters[2] = numericParameter3;
		if (errorParameter1 == null)
		{
			errorParameters[0] = string.Empty;
		}
		else
		{
			errorParameters[0] = errorParameter1;
		}
		if (errorParameter2 == null)
		{
			errorParameters[1] = string.Empty;
		}
		else
		{
			errorParameters[1] = errorParameter2;
		}
		if (errorParameter3 == null)
		{
			errorParameters[2] = string.Empty;
		}
		else
		{
			errorParameters[2] = errorParameter3;
		}
	}

	public override string ToString()
	{
		return typeof(SqlCeError).ToString() + ": " + Message;
	}

	internal static SqlCeError GetDefaultError(int hr)
	{
		return new SqlCeError(hr, Res.GetString("ADP_NoErrorInfoPresent"), -1, string.Empty, 0, 0, 0, string.Empty, string.Empty, string.Empty);
	}

	private string FormatErrorMessage(SqlCeError err)
	{
		Match match = null;
		string text = null;
		string text2 = err.message;
		string[] array = new string[6] { "", "", "", "", "", "" };
		if ((match = ParamInfoRegex.Match(text2)).Success)
		{
			text = match.Value;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				num2 = text.IndexOf(',', num);
				if (-1 != num2)
				{
					array[i] = text.Substring(num, num2 - num);
					num = num2 + 1;
				}
				else
				{
					array[i] = text.Substring(num);
				}
			}
			text2 = text2.Substring(0, match.Index - 1).Trim();
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		for (int j = 0; j < 3; j++)
		{
			int num3 = err.NumericErrorParameters[j];
			if (array[j].Trim().Length > 0)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(array[j]);
				stringBuilder.Append(" = ");
				stringBuilder.Append(num3);
				flag = false;
			}
			else if (num3 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(num3);
				flag = false;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			string text3 = err.ErrorParameters[k];
			if (array[k + 3].Trim().Length > 0)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(array[k + 3]);
				stringBuilder.Append(" = ");
				stringBuilder.Append(text3);
				flag = false;
			}
			else if (text3.Length > 0)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(text3);
				flag = false;
			}
		}
		string text4 = stringBuilder.ToString();
		if (text4.Length > 0)
		{
			return string.Format(CultureInfo.CurrentCulture, "{0} [ {1} ]", new object[2]
			{
				text2,
				stringBuilder.ToString()
			});
		}
		return text2;
	}
}
