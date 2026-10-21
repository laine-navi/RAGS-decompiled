using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Data.SqlServerCe;

internal class ADP
{
	internal class DstComparer : IEqualityComparer<string>
	{
		public bool Equals(string strA, string strB)
		{
			return 0 == CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth);
		}

		public int GetHashCode(string str)
		{
			return str.ToLower(CultureInfo.CurrentCulture).GetHashCode();
		}
	}

	internal const int MaxConnectionStringCacheSize = 250;

	internal const string BeginTransaction = "BeginTransaction";

	internal const string CommandSetEnlistedConnection = "set_Connection";

	internal const string GetDatabaseInfo = "GetDatabaseInfo";

	internal const string ChangeDatabase = "ChangeDatabase";

	internal const string Cancel = "Cancel";

	internal const string Clone = "Clone";

	internal const string CommitTransaction = "CommitTransaction";

	internal const string ConnectionString = "ConnectionString";

	internal const string DataSetColumn = "DataSetColumn";

	internal const string DataSetTable = "DataSetTable";

	internal const string Delete = "Delete";

	internal const string DeleteCommand = "DeleteCommand";

	internal const string DeriveParameters = "DeriveParameters";

	internal const string ExecuteReader = "ExecuteReader";

	internal const string ExecuteNonQuery = "ExecuteNonQuery";

	internal const string ExecuteTableDirect = "ExecuteTableDirect";

	internal const string ExecuteScalar = "ExecuteScalar";

	internal const string ExecuteXmlReader = "ExecuteXmlReader";

	internal const string ExecuteResultSet = "ExecuteResultSet";

	internal const string Fill = "Fill";

	internal const string FillSchema = "FillSchema";

	internal const string GetBytes = "GetBytes";

	internal const string GetChars = "GetChars";

	internal const string Insert = "Insert";

	internal const string Parameter = "Parameter";

	internal const string ParameterName = "ParameterName";

	internal const string ParameterIndex = "ParameterIndex";

	internal const string Prepare = "Prepare";

	internal const string Remove = "Remove";

	internal const string RollbackTransaction = "RollbackTransaction";

	internal const string SaveTransaction = "SaveTransaction";

	internal const string Select = "Select";

	internal const string SelectCommand = "SelectCommand";

	internal const string SourceColumn = "SourceColumn";

	internal const string SourceVersion = "SourceVersion";

	internal const string SourceTable = "SourceTable";

	internal const string Update = "Update";

	internal const string UpdateCommand = "UpdateCommand";

	internal const string sysTableTombstone = "__sysOCSDeletedRows";

	internal const string sysContextColumn = "__sysTrackingContext";

	internal const string sysTableCommitSequence = "__sysTxCommitSequence";

	internal const string sysTableTrackedObjects = "__sysOCSTrackedObjects";

	internal const int DecimalScaleOfMoney = 4;

	internal const string sysTableSyncArticles = "__sysSyncArticles";

	internal const string sysTableSyncSubscriptions = "__sysSyncSubscriptions";

	internal const int DB_E_BADBOOKMARK = -2147217906;

	internal const int DB_E_DELETEDROW = -2147217885;

	internal const int DB_E_NOTFOUND = -2147217895;

	internal const int SSCE_M_LOCKTIMEOUT = 25090;

	internal const int SSCE_M_PENDINGUPDATE = 25126;

	internal const int SSCE_M_DBUPGRADENEEDED = 25138;

	internal const int SSCE_M_NOCURRENTRECORD = 25001;

	internal const int SSCE_M_COLUMNORDINALNOTFOUND = 28527;

	internal const int SSCE_M_MANAGEDEXCEPTION = 27772;

	internal const int SSCE_M_TRANSACTIONABORTED = 27776;

	internal const int SSCE_M_TABLENOTTRACKED = 28543;

	internal const int SQLCE_WrongTrackingVersion = 30001;

	internal const int SQLCE_WrongCleanupSequence = 30002;

	internal const int MAX_PARAMETER_NAME_LENGTH = 128;

	internal const int ExecutedQuery = 1;

	internal const int ExecutedNonQuery = 2;

	internal const int SchemaOnly = 3;

	internal const short VARIANT_TRUE = -1;

	internal const short VARIANT_FALSE = 0;

	internal const int TRUE = 1;

	internal const int FALSE = 0;

	internal const int DBACCESSOR_ROWDATA = 2;

	internal const int DBACCESSOR_PARAMETERDATA = 4;

	internal const int S_OK = 0;

	internal const int SESETCOLUMN_DEFAULT = 2;

	internal const int E_FAIL = -2147467259;

	internal const CompareOptions compareOptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;

	private static readonly Type StackOverflowType = typeof(StackOverflowException);

	private static readonly Type OutOfMemoryType = typeof(OutOfMemoryException);

	private static readonly Type ThreadAbortType = typeof(ThreadAbortException);

	private static readonly Type NullReferenceType = typeof(NullReferenceException);

	internal static readonly object EventRowUpdated = new object();

	internal static readonly object EventRowUpdating = new object();

	internal static readonly object EventInfoMessage = new object();

	internal static readonly object EventStateChange = new object();

	internal static readonly object EventFlushFailure = new object();

	internal static readonly int SizeOf_tagDBOBJECT = Marshal.SizeOf(typeof(tagDBOBJECT));

	internal static readonly Guid IID_ISequentialStream = new Guid(208878128, 10780, 4558, 173, 229, 0, 170, 0, 68, 119, 61);

	internal static readonly Guid IID_ILockBytes = new Guid(10, 0, 0, 192, 0, 0, 0, 0, 0, 0, 70);

	private ADP()
	{
	}

	internal static IntPtr IntPtrOffset(IntPtr pbase, int offset)
	{
		if (4 == IntPtr.Size)
		{
			return (IntPtr)(pbase.ToInt32() + offset);
		}
		return (IntPtr)(pbase.ToInt64() + offset);
	}

	internal static int SrcCompare(string strA, string strB)
	{
		return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
	}

	internal static bool IsEmpty(string str)
	{
		if (str != null)
		{
			return 0 == str.Length;
		}
		return true;
	}

	internal static bool IsAlive(WeakReference value)
	{
		try
		{
			if (value != null && value.IsAlive)
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			if (!IsCatchableExceptionType(ex))
			{
				throw ex;
			}
		}
		return false;
	}

	internal static bool IsCatchableExceptionType(Exception e)
	{
		Type type = e.GetType();
		if ((object)type != StackOverflowType && (object)type != OutOfMemoryType && (object)type != ThreadAbortType)
		{
			return (object)type != NullReferenceType;
		}
		return false;
	}

	internal static List<string> GetTablePrimaryKey(string tableName, SqlCeConnection Connection)
	{
		if (Connection == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
		}
		List<string> list = new List<string>();
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.INDEXES  WHERE PRIMARY_KEY=1 AND TABLE_NAME = @tablename ORDER BY ORDINAL_POSITION ASC";
		sqlCeCommand.Parameters.AddWithValue("@tablename", tableName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			list.Add(sqlCeDataReader.GetString(0));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Parameters.Clear();
		sqlCeCommand.Dispose();
		return list;
	}

	internal static string GetTableRowGuidColumn(string tableName, SqlCeConnection Connection)
	{
		if (Connection == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
		}
		string result = null;
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		sqlCeCommand.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = @tablename and (COLUMN_FLAGS & 0x100) <> 0";
		sqlCeCommand.Parameters.AddWithValue("@tablename", tableName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		try
		{
			if (sqlCeDataReader.Read())
			{
				result = sqlCeDataReader.GetString(0);
			}
		}
		catch (Exception)
		{
			result = null;
		}
		finally
		{
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Parameters.Clear();
			sqlCeCommand.Dispose();
		}
		return result;
	}

	internal static SqlCeTableColumns GetTableColumns(string tableName, SqlCeConnection Connection)
	{
		if (Connection == null)
		{
			throw new InvalidOperationException(Res.GetString("ADP_NoConnectionString"));
		}
		SqlCeTableColumns sqlCeTableColumns = new SqlCeTableColumns(tableName);
		SqlCeInfoSchemaColumn sqlCeInfoSchemaColumn = null;
		SqlCeDataReader sqlCeDataReader = null;
		SqlCeCommand sqlCeCommand = Connection.CreateCommand();
		try
		{
			sqlCeCommand.CommandText = " SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,  COLUMN_DEFAULT, NUMERIC_PRECISION, NUMERIC_SCALE, ORDINAL_POSITION  FROM INFORMATION_SCHEMA.COLUMNS  WHERE COLUMN_NAME NOT LIKE '__sys%' AND TABLE_NAME = @tablename ORDER BY ORDINAL_POSITION ASC";
			sqlCeCommand.Parameters.AddWithValue("@tablename", tableName);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			object[] array = new object[sqlCeDataReader.FieldCount];
			while (sqlCeDataReader.Read())
			{
				sqlCeDataReader.GetValues(array);
				sqlCeInfoSchemaColumn = new SqlCeInfoSchemaColumn();
				sqlCeInfoSchemaColumn.ColumnName = (string)array[0];
				sqlCeInfoSchemaColumn.ParamName = "@_" + sqlCeInfoSchemaColumn.ColumnName;
				sqlCeInfoSchemaColumn.SqlCeType = SqlCeType.FromDataType((string)array[1]);
				if (array[2] != null && DBNull.Value != array[2])
				{
					sqlCeInfoSchemaColumn.MaxLength = (int)array[2];
				}
				sqlCeInfoSchemaColumn.DefaultValue = array[3];
				if (array[4] != null && DBNull.Value != array[4])
				{
					sqlCeInfoSchemaColumn.Precision = Convert.ToByte(array[4], CultureInfo.InvariantCulture);
				}
				if (array[5] != null && DBNull.Value != array[5])
				{
					sqlCeInfoSchemaColumn.Scale = Convert.ToByte(array[5], CultureInfo.InvariantCulture);
				}
				if (array[6] != null && DBNull.Value != array[6])
				{
					sqlCeInfoSchemaColumn.Ordinal = (int)array[6];
				}
				sqlCeTableColumns.Add(sqlCeInfoSchemaColumn);
			}
			return sqlCeTableColumns;
		}
		finally
		{
			if (sqlCeDataReader != null)
			{
				sqlCeDataReader.Close();
				sqlCeDataReader.Dispose();
				sqlCeDataReader = null;
			}
			sqlCeCommand.Parameters.Clear();
			sqlCeCommand.Dispose();
		}
	}

	[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
	internal static object BitConverterGetObject(SqlCeType ceType, byte[] fullBytes, int offset, int length)
	{
		object result = DBNull.Value;
		switch (ceType.SeType)
		{
		case SETYPE.INTEGER:
			result = BitConverter.ToInt32(fullBytes, offset);
			break;
		case SETYPE.BIGINT:
			result = BitConverter.ToInt64(fullBytes, offset);
			break;
		case SETYPE.SMALLINT:
			result = BitConverter.ToInt16(fullBytes, offset);
			break;
		case SETYPE.TINYINT:
			result = fullBytes[offset];
			break;
		case SETYPE.BIT:
			result = BitConverter.ToBoolean(fullBytes, offset);
			break;
		case SETYPE.FLOAT:
			result = BitConverter.ToDouble(fullBytes, offset);
			break;
		case SETYPE.REAL:
			result = BitConverter.ToSingle(fullBytes, offset);
			break;
		case SETYPE.NCHAR:
		case SETYPE.NVARCHAR:
		{
			if (length == 0)
			{
				result = string.Empty;
				break;
			}
			int bytesUsed = 0;
			int charsUsed = 0;
			bool completed = false;
			char[] array3 = new char[Encoding.Unicode.GetMaxCharCount(length)];
			Encoding.Unicode.GetDecoder().Convert(fullBytes, offset, length, array3, 0, array3.Length, flush: true, out bytesUsed, out charsUsed, out completed);
			result = new string(array3, 0, charsUsed);
			break;
		}
		case SETYPE.UNIQUEIDENTIFIER:
		{
			byte[] array2 = new byte[length];
			Buffer.BlockCopy(fullBytes, offset, array2, 0, length);
			result = new Guid(array2);
			break;
		}
		case SETYPE.NUMERIC:
		{
			byte scale = fullBytes[offset + 1];
			bool flag = Convert.ToBoolean(fullBytes[offset + 2]);
			int lo2 = BitConverter.ToInt32(fullBytes, offset + 3);
			int mid = BitConverter.ToInt32(fullBytes, offset + 7);
			int hi = BitConverter.ToInt32(fullBytes, offset + 11);
			result = new decimal(lo2, mid, hi, !flag, scale);
			break;
		}
		case SETYPE.MONEY:
		{
			int lo = BitConverter.ToInt32(fullBytes, offset);
			int num = BitConverter.ToInt32(fullBytes, offset + 4);
			result = new decimal(lo, num, 0, num < 0, 4);
			break;
		}
		case SETYPE.DATETIME:
		{
			DBTIMESTAMP pDbTimestamp = default;
			uint dtTime = BitConverter.ToUInt32(fullBytes, offset);
			int dtDay = BitConverter.ToInt32(fullBytes, offset + 4);
			NativeMethods.uwutil_ConvertToDBTIMESTAMP(ref pDbTimestamp, dtTime, dtDay);
			result = new DateTime(pDbTimestamp.year, pDbTimestamp.month, pDbTimestamp.day, pDbTimestamp.hour, pDbTimestamp.minute, pDbTimestamp.second, (int)(pDbTimestamp.fraction / 1000000));
			break;
		}
		case SETYPE.BINARY:
		case SETYPE.VARBINARY:
		case SETYPE.ROWVERSION:
		{
			byte[] array = new byte[length];
			if (length > 0)
			{
				Buffer.BlockCopy(fullBytes, offset, array, 0, length);
			}
			result = array;
			break;
		}
		}
		return result;
	}

	[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
	internal static byte[] BitConverterGetBytes(SqlCeType ceType, object val, ref int length)
	{
		switch (ceType.SeType)
		{
		case SETYPE.INTEGER:
			length = 4;
			return BitConverter.GetBytes((int)val);
		case SETYPE.BIGINT:
			length = 8;
			return BitConverter.GetBytes((long)val);
		case SETYPE.SMALLINT:
			length = 2;
			return BitConverter.GetBytes((short)val);
		case SETYPE.TINYINT:
			length = 1;
			return new byte[1] { (byte)val };
		case SETYPE.BIT:
			length = 2;
			return new byte[2]
			{
				(byte)(((bool)val) ? 1 : 0),
				0
			};
		case SETYPE.FLOAT:
			length = 8;
			return BitConverter.GetBytes((double)val);
		case SETYPE.REAL:
			length = 4;
			return BitConverter.GetBytes((float)val);
		case SETYPE.NCHAR:
		case SETYPE.NVARCHAR:
		{
			int bytesUsed = 0;
			int charsUsed = 0;
			bool completed = false;
			string text = (string)ValueMapper.GetMappedValue(SqlDbType.NChar, val);
			char[] array6 = text.ToCharArray();
			byte[] array7 = new byte[Encoding.Unicode.GetMaxByteCount(array6.Length)];
			Encoding.Unicode.GetEncoder().Convert(array6, 0, array6.Length, array7, 0, array7.Length, flush: true, out charsUsed, out bytesUsed, out completed);
			length = bytesUsed;
			byte[] array8 = new byte[length];
			Array.Copy(array7, array8, length);
			return array8;
		}
		case SETYPE.UNIQUEIDENTIFIER:
			length = 16;
			return ((Guid)val).ToByteArray();
		case SETYPE.NUMERIC:
		{
			decimal d2 = (decimal)val;
			int[] bits2 = decimal.GetBits(d2);
			int value2 = bits2[0];
			int value3 = bits2[1];
			int value4 = bits2[2];
			bool value5 = bits2[3] >= 0;
			byte b = (byte)((bits2[3] >> 16) & 0xFF);
			length = 19;
			byte[] array5 = new byte[19]
			{
				0,
				b,
				Convert.ToByte(value5),
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			BitConverter.GetBytes(value2).CopyTo(array5, 3);
			BitConverter.GetBytes(value3).CopyTo(array5, 7);
			BitConverter.GetBytes(value4).CopyTo(array5, 11);
			return array5;
		}
		case SETYPE.MONEY:
		{
			decimal d = (decimal)val;
			int[] bits = decimal.GetBits(d);
			int num = bits[0];
			int num2 = bits[1];
			long value = (num + num2) * 10000;
			byte[] array4 = new byte[8];
			BitConverter.GetBytes(value).CopyTo(array4, 0);
			length = 8;
			return array4;
		}
		case SETYPE.DATETIME:
		{
			DateTime dateTime = (DateTime)val;
			DBTIMESTAMP pDbTimestamp = new DBTIMESTAMP
			{
				year = (short)dateTime.Year,
				month = (ushort)dateTime.Month,
				day = (ushort)dateTime.Day,
				hour = (ushort)dateTime.Hour,
				minute = (ushort)dateTime.Minute,
				second = (ushort)dateTime.Second,
				fraction = (uint)(dateTime.Millisecond * 1000000)
			};
			length = 8;
			byte[] array3 = new byte[8];
			uint dtTime = 0u;
			int dtDay = 0;
			NativeMethods.uwutil_ConvertFromDBTIMESTAMP(pDbTimestamp, ref dtTime, ref dtDay);
			BitConverter.GetBytes(dtTime).CopyTo(array3, 0);
			BitConverter.GetBytes(dtDay).CopyTo(array3, 4);
			return array3;
		}
		case SETYPE.BINARY:
		case SETYPE.VARBINARY:
		case SETYPE.ROWVERSION:
		{
			byte[] array = (byte[])val;
			byte[] array2 = new byte[array.Length];
			length = array2.Length;
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			return array2;
		}
		default:
			length = -1;
			return null;
		}
	}
}
