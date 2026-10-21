using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;

namespace System.Data.SqlServerCe;

internal sealed class ConStringUtil
{
	private enum PARSERSTATE
	{
		NothingYet = 1,
		Key,
		KeyEqual,
		KeyEnd,
		UnquotedValue,
		DoubleQuoteValue,
		DoubleQuoteValueQuote,
		DoubleQuoteValueEnd,
		SingleQuoteValue,
		SingleQuoteValueQuote,
		SingleQuoteValueEnd,
		NullTermination
	}

	private const int CONNECTION_OPTIONS = 16;

	private const int CONNECTION_SYNONYMS = 40;

	private const int ENCRYPTION_MODE_OPTIONS = 3;

	internal const string EM_ENGINE_DEFAULT_KEY = "engine default";

	internal const string EM_PLATFORM_DEFAULT_KEY = "platform default";

	internal const string EM_PPC2003_COMPATIBILITY_KEY = "ppc2003 compatibility";

	private const int BOOL_YES_NO_OPTIONS = 4;

	private const string YES_KEY = "yes";

	private const string NO_KEY = "no";

	private const string TRUE_KEY = "true";

	private const string FALSE_KEY = "false";

	internal const string DATA_SOURCE_KEY = "data source";

	internal const string LCID_KEY = "locale identifier";

	internal const string PERSIST_SECURITY_INFO_KEY = "persist security info";

	internal const string PASSWORD_KEY = "ssce:database password";

	internal const string ENCRYPT_DB_KEY = "ssce:encrypt database";

	internal const string ENLIST_KEY = "ssce:enlist";

	internal const string ENCRYPTION_MODE_KEY = "ssce:encryption mode";

	internal const string MAX_BUFFER_SIZE_KEY = "ssce:max buffer size";

	internal const string TEMP_FILE_DIR_KEY = "ssce:temp file directory";

	internal const string TEMP_FILE_MAX_SIZE_KEY = "ssce:temp file max size";

	internal const string AUTO_SHRINK_THRESHOLD_KEY = "ssce:autoshrink threshold";

	internal const string FLUSH_INTERVAL_KEY = "ssce:flush interval";

	internal const string MAX_DATABASE_SIZE_KEY = "ssce:max database size";

	internal const string DEFAULT_LOCK_ESCALATION_KEY = "ssce:default lock escalation";

	internal const string DEFAULT_LOCK_TIMEOUT_KEY = "ssce:default lock timeout";

	internal const string MODE_KEY = "ssce:mode";

	internal const string CASE_SENSITIVE_KEY = "ssce:case sensitive";

	internal const string CASE_SENSITIVE_SYNONYM = "case sensitive";

	internal const string ENCRYPTION_MODE_SYNONYM = "encryption mode";

	internal const string PWD_SYNONYM = "pwd";

	internal const string PASSWORD_SYNONYM = "password";

	internal const string READ_ONLY = "read only";

	internal const string READ_WRITE = "read write";

	internal const string EXCLUSIVE = "exclusive";

	internal const string SHARED_READ = "shared read";

	internal const string DATADIRECTORY_MACRO = "|DataDirectory|";

	internal const string DATADIRECTORY = "DataDirectory";

	private const int SE_CB_DEFAULT_BUFFER_POOL = 4194304;

	private const int SE_CB_MIN_BUFFER_POOL = 262144;

	private const int SE_CB_MAX_BUFFER_POOL = 268431360;

	private const int SE_AUTO_SHRINK_THRESHOLD_DEFAULT = 60;

	private const int SE_AUTO_SHRINK_OFF = 0;

	private const int SE_AUTO_SHRINK_THRESHOLD_MAX = 100;

	private const int SE_C_DEFAULT_LOCK_ESCALATION = 100;

	private const int SE_C_MIN_LOCK_ESCALATION = 50;

	private const int SE_FLUSH_INTERVAL_DEFAULT = 10;

	private const int SE_FLUSH_INTERVAL_MIN = 1;

	private const int SE_FLUSH_INTERVAL_MAX = 1000;

	private const int SE_C_MAX_MAX_PAGES = 1047549;

	private const int SE_C_DEFAULT_MAX_PAGES = 65536;

	private const int SE_C_MIN_MAX_PAGES = 4096;

	private const int SE_DBWAIT_NONE = 0;

	private const int SE_DBWAIT_DEFAULT = 5000;

	internal const string DATA_SOURCE = "";

	internal const string PASSWORD = "";

	internal const bool PERSIST_SECURITY_INFO = false;

	internal const bool ENLIST = true;

	private const char EQUAL_SIGN = '=';

	private const char SEMI_COLON = ';';

	private const char SINGLE_QUOTE = '\'';

	private const char DOUBLE_QUOTE = '"';

	private const char SPACE = ' ';

	private const char TAB = '\t';

	private const char BACKSLASH = '\\';

	private static Hashtable _defaultConnectionOptions;

	private static Hashtable _connectionSynonymMapping;

	private static Hashtable _boolYesNoMapping;

	private static Hashtable _EncryptionModeMapping;

	private ConStringUtil()
	{
	}

	internal static Hashtable NullConnectionOptionsTable()
	{
		return new Hashtable(16);
	}

	internal static Hashtable DefaultConnectionOptionsTable()
	{
		Hashtable hashtable = _defaultConnectionOptions;
		if (hashtable == null)
		{
			hashtable = new Hashtable(16);
			hashtable["data source"] = "";
			hashtable["ssce:database password"] = "";
			hashtable["persist security info"] = false;
			hashtable["ssce:enlist"] = true;
			_defaultConnectionOptions = hashtable;
		}
		return hashtable;
	}

	private static void InitMappingsTables()
	{
		if (_connectionSynonymMapping == null)
		{
			Hashtable hashtable = new Hashtable(40);
			hashtable["data source"] = "data source";
			hashtable["datasource"] = "data source";
			hashtable["locale identifier"] = "locale identifier";
			hashtable["initial lcid"] = "locale identifier";
			hashtable["lcid"] = "locale identifier";
			hashtable["database password"] = "ssce:database password";
			hashtable["ssce:database password"] = "ssce:database password";
			hashtable["encrypt database"] = "ssce:encrypt database";
			hashtable["ssce:encrypt database"] = "ssce:encrypt database";
			hashtable["enlist"] = "ssce:enlist";
			hashtable["ssce:enlist"] = "ssce:enlist";
			hashtable["encryption mode"] = "ssce:encryption mode";
			hashtable["ssce:encryption mode"] = "ssce:encryption mode";
			hashtable["password"] = "ssce:database password";
			hashtable["pwd"] = "ssce:database password";
			hashtable["encrypt"] = "ssce:encrypt database";
			hashtable["persist security info"] = "persist security info";
			hashtable["max buffer size"] = "ssce:max buffer size";
			hashtable["ssce:max buffer size"] = "ssce:max buffer size";
			hashtable["temp file directory"] = "ssce:temp file directory";
			hashtable["temp path"] = "ssce:temp file directory";
			hashtable["ssce:temp file directory"] = "ssce:temp file directory";
			hashtable["temp file max size"] = "ssce:temp file max size";
			hashtable["ssce:temp file max size"] = "ssce:temp file max size";
			hashtable["autoshrink threshold"] = "ssce:autoshrink threshold";
			hashtable["ssce:autoshrink threshold"] = "ssce:autoshrink threshold";
			hashtable["flush interval"] = "ssce:flush interval";
			hashtable["ssce:flush interval"] = "ssce:flush interval";
			hashtable["max database size"] = "ssce:max database size";
			hashtable["ssce:max database size"] = "ssce:max database size";
			hashtable["default lock escalation"] = "ssce:default lock escalation";
			hashtable["ssce:default lock escalation"] = "ssce:default lock escalation";
			hashtable["default lock timeout"] = "ssce:default lock timeout";
			hashtable["ssce:default lock timeout"] = "ssce:default lock timeout";
			hashtable["ssce:mode"] = "ssce:mode";
			hashtable["mode"] = "ssce:mode";
			hashtable["file mode"] = "ssce:mode";
			hashtable["ssce:case sensitive"] = "ssce:case sensitive";
			hashtable["case sensitive"] = "ssce:case sensitive";
			hashtable["casesensitive"] = "ssce:case sensitive";
			_connectionSynonymMapping = hashtable;
		}
		if (_boolYesNoMapping == null)
		{
			Hashtable hashtable2 = new Hashtable(4);
			hashtable2["yes"] = true;
			hashtable2["no"] = false;
			hashtable2["true"] = true;
			hashtable2["false"] = false;
			_boolYesNoMapping = hashtable2;
		}
		if (_EncryptionModeMapping == null)
		{
			Hashtable hashtable3 = new Hashtable(3);
			hashtable3["platform default"] = 1;
			hashtable3["engine default"] = 2;
			hashtable3["ppc2003 compatibility"] = 3;
			_EncryptionModeMapping = hashtable3;
		}
	}

	internal static string RemoveKeyValuesFromString(string conString, string removeKey)
	{
		string text = conString;
		int index = 0;
		int num = 0;
		int num2 = 0;
		SkipWhiteSpace(text, ref index);
		while (index < text.Length)
		{
			if (text[index] == ';')
			{
				index++;
				num2 = index;
				SkipWhiteSpace(text, ref index);
				continue;
			}
			num = text.IndexOf('=', index);
			string text2 = text.Substring(index, num - index).TrimEnd(null).ToLower(CultureInfo.InvariantCulture);
			index = num + 1;
			if (removeKey == "ssce:database password" && ("password" == text2 || "pwd" == text2 || "ssce:database password" == text2))
			{
				string text3 = text.Substring(0, num2);
				SkipValue(text, ref index);
				if (index < text.Length && text[index] == ';')
				{
					index++;
				}
				text = text3 + text.Substring(index);
				index = num2;
				SkipWhiteSpace(text, ref index);
			}
			else
			{
				SkipValue(text, ref index);
				if (index < text.Length && text[index] == ';')
				{
					index++;
					num2 = index;
					SkipWhiteSpace(text, ref index);
				}
			}
		}
		return text;
	}

	private static void SkipValue(string conString, ref int index)
	{
		SkipWhiteSpace(conString, ref index);
		if (index == conString.Length)
		{
			return;
		}
		char c = conString[index];
		switch (c)
		{
		case '"':
		case '\'':
			do
			{
				int num = conString.IndexOf(c, index + 1);
				index = num + 1;
			}
			while (index < conString.Length && conString[index] == c);
			SkipWhiteSpace(conString, ref index);
			break;
		default:
			index = conString.IndexOf(';', index + 1);
			if (index == -1)
			{
				index = conString.Length;
			}
			break;
		case ';':
			break;
		}
	}

	private static string ReplaceDataDirectory(string inputString)
	{
		string result = inputString;
		if (!string.IsNullOrEmpty(inputString) && inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
		{
			string text = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
			if (string.IsNullOrEmpty(text))
			{
				text = AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = string.Empty;
			}
			int num = "|DataDirectory|".Length;
			if (inputString.Length > "|DataDirectory|".Length && '\\' == inputString["|DataDirectory|".Length])
			{
				num++;
			}
			result = Path.Combine(text, inputString.Substring(num));
		}
		return result;
	}

	internal static Hashtable ParseConnectionString(ref string connectionString)
	{
		InitMappingsTables();
		Hashtable hashtable;
		if (connectionString != null && connectionString.Length != 0)
		{
			hashtable = NullConnectionOptionsTable();
			ParseStringIntoHashtable(connectionString, hashtable);
			VerifyValues(hashtable);
		}
		else
		{
			hashtable = DefaultConnectionOptionsTable();
		}
		return hashtable;
	}

	private static void ParseStringIntoHashtable(string conString, Hashtable values)
	{
		int num = 0;
		int vallength = 0;
		bool isempty = false;
		string key = string.Empty;
		string empty = string.Empty;
		char[] connectionString = conString.ToCharArray();
		char[] array = new char[conString.Length];
		while (num < conString.Length)
		{
			num = GetKeyValuePair(connectionString, num, out key, array, out vallength, out isempty);
			if (!isempty)
			{
				empty = new string(array, 0, vallength);
				if (!InsertKeyValueIntoHash(values, ref key, empty))
				{
					throw new ArgumentException(Res.GetString("SQL_InvalidConStringOption", key));
				}
			}
		}
	}

	private static Exception ConnectionStringSyntax(int index, char[] connectionString)
	{
		return new ArgumentException(Res.GetString("ADP_ConnectionStringSyntax", index));
	}

	private static int GetKeyValuePair(char[] connectionString, int currentPosition, out string key, char[] valuebuf, out int vallength, out bool isempty)
	{
		PARSERSTATE pARSERSTATE = PARSERSTATE.NothingYet;
		int num = 0;
		int index = currentPosition;
		key = null;
		vallength = -1;
		isempty = false;
		char c = '\0';
		if (connectionString.Length >= int.MaxValue)
		{
			throw new OverflowException();
		}
		while (true)
		{
			if (currentPosition < connectionString.Length)
			{
				c = connectionString[currentPosition];
				switch (pARSERSTATE)
				{
				case PARSERSTATE.NothingYet:
					if (';' == c || char.IsWhiteSpace(c))
					{
						goto IL_01f2;
					}
					index = currentPosition;
					if (c == '\0')
					{
						pARSERSTATE = PARSERSTATE.NullTermination;
						goto IL_01f2;
					}
					if (char.IsControl(c))
					{
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					pARSERSTATE = PARSERSTATE.Key;
					num = 0;
					goto default;
				case PARSERSTATE.Key:
					if ('=' == c)
					{
						pARSERSTATE = PARSERSTATE.KeyEqual;
						goto IL_01f2;
					}
					if (!char.IsWhiteSpace(c) && char.IsControl(c))
					{
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					goto default;
				case PARSERSTATE.KeyEqual:
					if ('=' == c)
					{
						pARSERSTATE = PARSERSTATE.Key;
						goto default;
					}
					key = GetKey(valuebuf, num);
					num = 0;
					pARSERSTATE = PARSERSTATE.KeyEnd;
					goto case PARSERSTATE.KeyEnd;
				case PARSERSTATE.KeyEnd:
					if (char.IsWhiteSpace(c))
					{
						goto IL_01f2;
					}
					if ('\'' == c)
					{
						pARSERSTATE = PARSERSTATE.SingleQuoteValue;
						goto IL_01f2;
					}
					if ('"' == c)
					{
						pARSERSTATE = PARSERSTATE.DoubleQuoteValue;
						goto IL_01f2;
					}
					if (';' == c || c == '\0')
					{
						break;
					}
					if (char.IsControl(c))
					{
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					pARSERSTATE = PARSERSTATE.UnquotedValue;
					goto default;
				case PARSERSTATE.UnquotedValue:
					if (!char.IsWhiteSpace(c) && (char.IsControl(c) || ';' == c))
					{
						break;
					}
					goto default;
				case PARSERSTATE.DoubleQuoteValue:
					if ('"' == c)
					{
						pARSERSTATE = PARSERSTATE.DoubleQuoteValueQuote;
						goto IL_01f2;
					}
					if (c == '\0')
					{
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					goto default;
				case PARSERSTATE.DoubleQuoteValueQuote:
					if ('"' == c)
					{
						pARSERSTATE = PARSERSTATE.DoubleQuoteValue;
						goto default;
					}
					pARSERSTATE = PARSERSTATE.DoubleQuoteValueEnd;
					goto case PARSERSTATE.DoubleQuoteValueEnd;
				case PARSERSTATE.DoubleQuoteValueEnd:
					if (char.IsWhiteSpace(c))
					{
						goto IL_01f2;
					}
					if (';' != c)
					{
						if (c == '\0')
						{
							pARSERSTATE = PARSERSTATE.NullTermination;
							goto IL_01f2;
						}
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					break;
				case PARSERSTATE.SingleQuoteValue:
					if ('\'' == c)
					{
						pARSERSTATE = PARSERSTATE.SingleQuoteValueQuote;
						goto IL_01f2;
					}
					if (c == '\0')
					{
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					goto default;
				case PARSERSTATE.SingleQuoteValueQuote:
					if ('\'' == c)
					{
						pARSERSTATE = PARSERSTATE.SingleQuoteValue;
						goto default;
					}
					pARSERSTATE = PARSERSTATE.SingleQuoteValueEnd;
					goto case PARSERSTATE.SingleQuoteValueEnd;
				case PARSERSTATE.SingleQuoteValueEnd:
					if (char.IsWhiteSpace(c))
					{
						goto IL_01f2;
					}
					if (';' != c)
					{
						if (c == '\0')
						{
							pARSERSTATE = PARSERSTATE.NullTermination;
							goto IL_01f2;
						}
						throw ConnectionStringSyntax(currentPosition, connectionString);
					}
					break;
				case PARSERSTATE.NullTermination:
					if (c == '\0' || char.IsWhiteSpace(c))
					{
						goto IL_01f2;
					}
					throw ConnectionStringSyntax(index, connectionString);
				default:
					valuebuf[num++] = c;
					goto IL_01f2;
				}
				break;
			}
			if (PARSERSTATE.KeyEqual == pARSERSTATE)
			{
				key = GetKey(valuebuf, num);
				num = 0;
			}
			if (PARSERSTATE.Key != pARSERSTATE && PARSERSTATE.DoubleQuoteValue != pARSERSTATE && PARSERSTATE.SingleQuoteValue != pARSERSTATE)
			{
				break;
			}
			throw ConnectionStringSyntax(index, connectionString);
			IL_01f2:
			currentPosition++;
		}
		if (PARSERSTATE.UnquotedValue == pARSERSTATE)
		{
			num = TrimWhiteSpace(valuebuf, num);
			if ('\'' == valuebuf[num - 1] || '"' == valuebuf[num - 1])
			{
				throw ConnectionStringSyntax(currentPosition - 1, connectionString);
			}
		}
		else if (PARSERSTATE.KeyEqual != pARSERSTATE && PARSERSTATE.KeyEnd != pARSERSTATE)
		{
			isempty = 0 == num;
		}
		if (';' == c && currentPosition < connectionString.Length)
		{
			currentPosition++;
		}
		vallength = num;
		return currentPosition;
	}

	private static string GetKey(char[] valuebuf, int bufPosition)
	{
		bufPosition = TrimWhiteSpace(valuebuf, bufPosition);
		byte[] bytes = Encoding.Unicode.GetBytes(valuebuf, 0, bufPosition);
		string text = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
		return text.ToLower(CultureInfo.InvariantCulture);
	}

	private static int TrimWhiteSpace(char[] valuebuf, int bufPosition)
	{
		while (0 < bufPosition && char.IsWhiteSpace(valuebuf[bufPosition - 1]))
		{
			bufPosition--;
		}
		return bufPosition;
	}

	private static void SkipWhiteSpace(string conString, ref int index)
	{
		while (index < conString.Length)
		{
			char c = conString[index];
			if (c != ' ' && c != '\t')
			{
				break;
			}
			index++;
		}
	}

	private static bool InsertKeyValueIntoHash(Hashtable values, ref string key, string value)
	{
		bool result = true;
		if (string.Empty == value)
		{
			value = null;
		}
		if (values.ContainsKey(key))
		{
			values[key] = value;
		}
		else if (_connectionSynonymMapping.ContainsKey(key))
		{
			key = (string)_connectionSynonymMapping[key];
			values[key] = value;
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal static int MapEncryptionMode(string value)
	{
		if (value != null && _EncryptionModeMapping.ContainsKey(value))
		{
			return (int)_EncryptionModeMapping[value];
		}
		return 0;
	}

	private static void VerifyValues(Hashtable values)
	{
		SetDataSource(values);
		SetPersistSecurityInfo(values);
		SetEncryptDataBase(values);
		SetEncryptionMode(values);
		SetEnlistDataBase(values);
		SetMaxBufferSize(values);
		SetLocale(values);
		SetAutoShrinkThreshold(values);
		SetMaxDatabaseSize(values);
		SetDefaultLockEscalation(values);
		SetDefaultLockTimeout(values);
		SetFlushInterval(values);
		SetFileMode(values);
		SetTempFileMaxSize(values);
		SetCaseSensitivity(values);
		SetStringType("data source", values);
		SetStringType("ssce:database password", values);
	}

	private static void SetCaseSensitivity(Hashtable table)
	{
		string text = (string)table["ssce:case sensitive"];
		string text2 = text;
		if (text != null)
		{
			text2 = text.ToLower(CultureInfo.InvariantCulture);
		}
		if (text2 != null)
		{
			if (!_boolYesNoMapping.ContainsKey(text2))
			{
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "ssce:case sensitive", text));
			}
			table["ssce:case sensitive"] = (bool)_boolYesNoMapping[text2];
		}
	}

	private static void SetDataSource(Hashtable table)
	{
		string text = (string)table["data source"];
		if (text != null)
		{
			table["data source"] = ReplaceDataDirectory(text);
		}
	}

	private static void SetLocale(Hashtable table)
	{
		string text = (string)table["locale identifier"];
		if (text != null)
		{
			int num = SetIntType(text, "locale identifier");
			if (num < 0)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "locale identifier", 0, int.MaxValue));
			}
			table["locale identifier"] = num;
		}
	}

	private static void SetTempFileMaxSize(Hashtable table)
	{
		string text = (string)table["ssce:temp file max size"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:temp file max size");
			if (16 > num || 4091 < num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:temp file max size", 16, 4091));
			}
		}
		else
		{
			num = 256;
		}
		table["ssce:temp file max size"] = num;
	}

	private static void SetMaxBufferSize(Hashtable table)
	{
		string text = (string)table["ssce:max buffer size"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:max buffer size");
			if (256 > num || 262140 < num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:max buffer size", 256, 262140));
			}
		}
		else
		{
			num = 4096;
		}
		table["ssce:max buffer size"] = num;
	}

	private static void SetEnlistDataBase(Hashtable table)
	{
		string text = (string)table["ssce:enlist"];
		string text2 = text;
		if (text != null)
		{
			text2 = text.ToLower(CultureInfo.InvariantCulture);
		}
		if (text2 != null)
		{
			if (!_boolYesNoMapping.ContainsKey(text2))
			{
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "ssce:enlist", text));
			}
			table["ssce:enlist"] = (bool)_boolYesNoMapping[text2];
		}
		else
		{
			table["ssce:enlist"] = true;
		}
	}

	private static void SetEncryptionMode(Hashtable table)
	{
		string text = (string)table["ssce:encryption mode"];
		string text2 = text;
		if (text != null)
		{
			text2 = text.ToLower(CultureInfo.InvariantCulture);
		}
		if (text2 != null)
		{
			if (!_EncryptionModeMapping.ContainsKey(text2))
			{
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "ssce:encryption mode", text));
			}
			table["ssce:encryption mode"] = text2;
		}
	}

	private static void SetEncryptDataBase(Hashtable table)
	{
		string text = (string)table["ssce:encrypt database"];
		string text2 = text;
		if (text != null)
		{
			text2 = text.ToLower(CultureInfo.InvariantCulture);
		}
		if (text2 != null)
		{
			if (!_boolYesNoMapping.ContainsKey(text2))
			{
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "ssce:encrypt database", text));
			}
			table["ssce:encrypt database"] = (bool)_boolYesNoMapping[text2];
		}
	}

	private static void SetPersistSecurityInfo(Hashtable table)
	{
		string text = (string)table["persist security info"];
		string text2 = text;
		if (text != null)
		{
			text2 = text.ToLower(CultureInfo.InvariantCulture);
		}
		if (text2 != null)
		{
			if (!_boolYesNoMapping.ContainsKey(text2))
			{
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "persist security info", text));
			}
			table["persist security info"] = (bool)_boolYesNoMapping[text2];
		}
		else if (table.Contains("persist security info"))
		{
			table["persist security info"] = false;
		}
	}

	private static void SetAutoShrinkThreshold(Hashtable table)
	{
		string text = (string)table["ssce:autoshrink threshold"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:autoshrink threshold");
			if (0 > num || 100 < num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:autoshrink threshold", 0, 100));
			}
		}
		else
		{
			num = 60;
		}
		table["ssce:autoshrink threshold"] = num;
	}

	private static void SetMaxDatabaseSize(Hashtable table)
	{
		string text = (string)table["ssce:max database size"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:max database size");
			if (16 > num || 4091 < num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:max database size", 16, 4091));
			}
		}
		else
		{
			num = 256;
		}
		table["ssce:max database size"] = num;
	}

	private static void SetDefaultLockEscalation(Hashtable table)
	{
		string text = (string)table["ssce:default lock escalation"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:default lock escalation");
			if (50 > num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:default lock escalation", 50, int.MaxValue));
			}
		}
		else
		{
			num = 100;
		}
		table["ssce:default lock escalation"] = num;
	}

	private static void SetDefaultLockTimeout(Hashtable table)
	{
		string text = (string)table["ssce:default lock timeout"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:default lock timeout");
			if (0 > num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:default lock timeout", 0, int.MaxValue));
			}
		}
		else
		{
			num = 5000;
		}
		table["ssce:default lock timeout"] = num;
	}

	private static void SetFlushInterval(Hashtable table)
	{
		string text = (string)table["ssce:flush interval"];
		int num;
		if (text != null)
		{
			num = SetIntType(text, "ssce:flush interval");
			if (1 > num || 1000 < num)
			{
				throw new ArgumentException(Res.GetString("SQLCE_ArgumentOutOfRange", "ssce:flush interval", 1, 1000));
			}
		}
		else
		{
			num = 10;
		}
		table["ssce:flush interval"] = num;
	}

	private static int SetIntType(string value, string key)
	{
		if (value != value.Trim())
		{
			throw new ArgumentException(Res.GetString("SQLCE_InvalidValueForKeyValue", key));
		}
		try
		{
			return int.Parse(value, CultureInfo.InvariantCulture);
		}
		catch (Exception innerException)
		{
			throw new ArgumentException(Res.GetString("SQLCE_InvalidValueForKeyValue", key), innerException);
		}
	}

	private static void SetFileMode(Hashtable table)
	{
		string text = (string)table["ssce:mode"];
		string text2 = text;
		if (text2 != null)
		{
			text2 = text2.ToLower(CultureInfo.CurrentCulture);
			switch (text2)
			{
			default:
				throw new ArgumentException(Res.GetString("SQL_InvalidConnectionOptionValue", "ssce:mode", text2));
			case "read only":
			case "read write":
			case "exclusive":
			case "shared read":
				break;
			}
		}
		if (table.Contains("ssce:mode"))
		{
			table["ssce:mode"] = text;
		}
	}

	private static void SetStringType(string key, Hashtable values)
	{
		string text = (string)values[key];
		if (text != null)
		{
			values[key] = text;
		}
	}
}
