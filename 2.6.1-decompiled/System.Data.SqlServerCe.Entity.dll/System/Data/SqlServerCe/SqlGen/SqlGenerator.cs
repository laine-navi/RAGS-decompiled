using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;
using System.Globalization;
using System.Text;

namespace System.Data.SqlServerCe.SqlGen;

internal sealed class SqlGenerator : DbExpressionVisitor<ISqlFragment>
{
	private delegate ISqlFragment FunctionHandler(SqlGenerator sqlgen, DbFunctionExpression functionExpr);

	private const byte defaultDecimalPrecision = 18;

	private Stack<SqlSelectStatement> selectStatementStack;

	private Stack<bool> isParentAJoinStack;

	private Dictionary<string, int> allExtentNames;

	private Dictionary<string, int> allColumnNames;

	private SymbolTable symbolTable = new SymbolTable();

	private bool isVarRefSingle;

	private static readonly Dictionary<string, FunctionHandler> _storeFunctionHandlers = InitializeStoreFunctionHandlers();

	private static readonly Dictionary<string, FunctionHandler> _canonicalFunctionHandlers = InitializeCanonicalFunctionHandlers();

	private static readonly Dictionary<string, string> _functionNameToOperatorDictionary = InitializeFunctionNameToOperatorDictionary();

	private static readonly Dictionary<string, object> _datepartKeywords = InitializeDatepartKeywords();

	private static readonly char[] hexDigits = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private static readonly Queue<string> _functionRequiresReturnTypeCast = new Queue<string>(new string[6] { "SqlServer.LEN", "SqlServer.PATINDEX", "SqlServer.CHARINDEX", "SqlServer.DATALENGTH", "Edm.IndexOf", "Edm.Length" });

	private bool topElementExpression;

	private List<string> listOfScalarSubQueryTables = new List<string>();

	private static readonly Queue<string> _maxTypeNames = new Queue<string>(new string[2] { "ntext", "image" });

	private SqlSelectStatement CurrentSelectStatement => selectStatementStack.Peek();

	private bool IsParentAJoin
	{
		get
		{
			if (isParentAJoinStack.Count != 0)
			{
				return isParentAJoinStack.Peek();
			}
			return false;
		}
	}

	internal Dictionary<string, int> AllExtentNames => allExtentNames;

	internal Dictionary<string, int> AllColumnNames => allColumnNames;

	private static Dictionary<string, FunctionHandler> InitializeStoreFunctionHandlers()
	{
		Dictionary<string, FunctionHandler> dictionary = new Dictionary<string, FunctionHandler>(5, StringComparer.Ordinal);
		dictionary.Add("CONCAT", HandleConcatFunction);
		dictionary.Add("DATEADD", HandleDatepartDateFunction);
		dictionary.Add("DATEDIFF", HandleDatepartDateFunction);
		dictionary.Add("DATENAME", HandleDatepartDateFunction);
		dictionary.Add("DATEPART", HandleDatepartDateFunction);
		return dictionary;
	}

	private static Dictionary<string, FunctionHandler> InitializeCanonicalFunctionHandlers()
	{
		Dictionary<string, FunctionHandler> dictionary = new Dictionary<string, FunctionHandler>(16, StringComparer.Ordinal);
		dictionary.Add("IndexOf", HandleCanonicalFunctionIndexOf);
		dictionary.Add("Length", HandleCanonicalFunctionLength);
		dictionary.Add("NewGuid", HandleCanonicalFunctionNewGuid);
		dictionary.Add("Round", HandleCanonicalFunctionRound);
		dictionary.Add("ToLower", HandleCanonicalFunctionToLower);
		dictionary.Add("ToUpper", HandleCanonicalFunctionToUpper);
		dictionary.Add("Trim", HandleCanonicalFunctionTrim);
		dictionary.Add("Year", HandleCanonicalFunctionDatepart);
		dictionary.Add("Month", HandleCanonicalFunctionDatepart);
		dictionary.Add("Day", HandleCanonicalFunctionDatepart);
		dictionary.Add("Hour", HandleCanonicalFunctionDatepart);
		dictionary.Add("Minute", HandleCanonicalFunctionDatepart);
		dictionary.Add("Second", HandleCanonicalFunctionDatepart);
		dictionary.Add("Millisecond", HandleCanonicalFunctionDatepart);
		dictionary.Add("CurrentDateTime", HandleCanonicalFunctionCurrentDateTime);
		dictionary.Add("Concat", HandleConcatFunction);
		dictionary.Add("BitwiseAnd", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseNot", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseOr", HandleCanonicalFunctionBitwise);
		dictionary.Add("BitwiseXor", HandleCanonicalFunctionBitwise);
		dictionary.Add("Left", HandleUnsupportedFunction);
		dictionary.Add("Right", HandleUnsupportedFunction);
		dictionary.Add("StDev", HandleUnsupportedFunction);
		dictionary.Add("Reverse", HandleUnsupportedFunction);
		dictionary.Add("CurrentUtcDateTime", HandleUnsupportedFunction);
		dictionary.Add("CurrentDateTimeOffset", HandleUnsupportedFunction);
		dictionary.Add("GetTotalOffsetMinutes", HandleUnsupportedFunction);
		return dictionary;
	}

	private static Dictionary<string, object> InitializeDatepartKeywords()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(30, StringComparer.OrdinalIgnoreCase);
		dictionary.Add("d", null);
		dictionary.Add("day", null);
		dictionary.Add("dayofyear", null);
		dictionary.Add("dd", null);
		dictionary.Add("dw", null);
		dictionary.Add("dy", null);
		dictionary.Add("hh", null);
		dictionary.Add("hour", null);
		dictionary.Add("m", null);
		dictionary.Add("mi", null);
		dictionary.Add("millisecond", null);
		dictionary.Add("minute", null);
		dictionary.Add("mm", null);
		dictionary.Add("month", null);
		dictionary.Add("ms", null);
		dictionary.Add("n", null);
		dictionary.Add("q", null);
		dictionary.Add("qq", null);
		dictionary.Add("quarter", null);
		dictionary.Add("s", null);
		dictionary.Add("second", null);
		dictionary.Add("ss", null);
		dictionary.Add("week", null);
		dictionary.Add("weekday", null);
		dictionary.Add("wk", null);
		dictionary.Add("ww", null);
		dictionary.Add("y", null);
		dictionary.Add("year", null);
		dictionary.Add("yy", null);
		dictionary.Add("yyyy", null);
		return dictionary;
	}

	private static Dictionary<string, string> InitializeFunctionNameToOperatorDictionary()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(5, StringComparer.Ordinal);
		dictionary.Add("Concat", "+");
		dictionary.Add("CONCAT", "+");
		dictionary.Add("BitwiseAnd", "&");
		dictionary.Add("BitwiseNot", "~");
		dictionary.Add("BitwiseOr", "|");
		dictionary.Add("BitwiseXor", "^");
		return dictionary;
	}

	private SqlGenerator()
	{
	}

	internal static string GenerateSql(DbCommandTree tree, out List<DbParameter> parameters, out CommandType commandType, bool isLocalProvider)
	{
		commandType = CommandType.Text;
		DbQueryCommandTree val = (DbQueryCommandTree)(object)((tree is DbQueryCommandTree) ? tree : null);
		DbInsertCommandTree val2 = (DbInsertCommandTree)(object)((tree is DbInsertCommandTree) ? tree : null);
		DbUpdateCommandTree val3 = (DbUpdateCommandTree)(object)((tree is DbUpdateCommandTree) ? tree : null);
		DbDeleteCommandTree val4 = (DbDeleteCommandTree)(object)((tree is DbDeleteCommandTree) ? tree : null);
		DbFunctionCommandTree val5 = (DbFunctionCommandTree)(object)((tree is DbFunctionCommandTree) ? tree : null);
		if (val != null)
		{
			SqlGenerator sqlGenerator = new SqlGenerator();
			parameters = null;
			return sqlGenerator.GenerateSql(val);
		}
		if (val2 != null)
		{
			return DmlSqlGenerator.GenerateInsertSql(val2, out parameters, isLocalProvider);
		}
		if (val3 != null)
		{
			return DmlSqlGenerator.GenerateUpdateSql(val3, out parameters, isLocalProvider);
		}
		if (val4 != null)
		{
			return DmlSqlGenerator.GenerateDeleteSql(val4, out parameters, isLocalProvider);
		}
		if (val5 != null)
		{
			throw ADP1.NotSupported(Res.GetString("StoredProceduresNotSupported"));
		}
		throw ADP1.NotImplemented(string.Empty);
	}

	private string GenerateSql(DbQueryCommandTree tree)
	{
		selectStatementStack = new Stack<SqlSelectStatement>();
		isParentAJoinStack = new Stack<bool>();
		allExtentNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		allColumnNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		ISqlFragment sqlStatement;
		if (TypeSemantics.IsCollectionType(tree.Query.ResultType))
		{
			SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(tree.Query);
			sqlSelectStatement.IsTopMost = true;
			sqlStatement = sqlSelectStatement;
		}
		else
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append("SELECT ");
			sqlBuilder.Append(tree.Query.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			sqlStatement = sqlBuilder;
		}
		if (isVarRefSingle)
		{
			throw ADP1.NotSupported();
		}
		return WriteSql(sqlStatement);
	}

	private string WriteSql(ISqlFragment sqlStatement)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		using (SqlWriter writer = new SqlWriter(stringBuilder))
		{
			sqlStatement.WriteSql(writer, this);
		}
		return stringBuilder.ToString();
	}

	public override ISqlFragment Visit(DbAndExpression e)
	{
		return VisitBinaryExpression(" AND ", (DbExpressionKind)1, ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
	}

	public override ISqlFragment Visit(DbApplyExpression e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		List<DbExpressionBinding> list = new List<DbExpressionBinding>();
		list.Add(e.Input);
		list.Add(e.Apply);
		DbExpressionKind expressionKind = ((DbExpression)e).ExpressionKind;
		string joinString;
		if ((int)expressionKind != 6)
		{
			if ((int)expressionKind != 42)
			{
				throw ADP1.InvalidOperation(string.Empty);
			}
			joinString = "OUTER APPLY";
		}
		else
		{
			joinString = "CROSS APPLY";
		}
		return VisitJoinExpression(list, (DbExpressionKind)7, joinString, null);
	}

	public override ISqlFragment Visit(DbArithmeticExpression e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected I4, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DbExpressionKind expressionKind = ((DbExpression)e).ExpressionKind;
		SqlBuilder sqlBuilder;
		if ((int)expressionKind <= 34)
		{
			if ((int)expressionKind != 10)
			{
				switch (expressionKind - 32)
				{
				case 0:
					break;
				case 1:
					goto IL_009e;
				case 2:
					goto IL_00cd;
				default:
					goto IL_015b;
				}
				sqlBuilder = VisitBinaryExpression(" - ", ((DbExpression)e).ExpressionKind, e.Arguments[0], e.Arguments[1]);
			}
			else
			{
				sqlBuilder = VisitBinaryExpression(" / ", ((DbExpression)e).ExpressionKind, e.Arguments[0], e.Arguments[1]);
			}
		}
		else if ((int)expressionKind != 44)
		{
			if ((int)expressionKind != 54)
			{
				goto IL_015b;
			}
			sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(" -(");
			sqlBuilder.Append(e.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			sqlBuilder.Append(")");
		}
		else
		{
			sqlBuilder = VisitBinaryExpression(" + ", ((DbExpression)e).ExpressionKind, e.Arguments[0], e.Arguments[1]);
		}
		goto IL_0166;
		IL_009e:
		sqlBuilder = VisitBinaryExpression(" % ", ((DbExpression)e).ExpressionKind, e.Arguments[0], e.Arguments[1]);
		goto IL_0166;
		IL_0166:
		return sqlBuilder;
		IL_00cd:
		sqlBuilder = VisitBinaryExpression(" * ", ((DbExpression)e).ExpressionKind, e.Arguments[0], e.Arguments[1]);
		goto IL_0166;
		IL_015b:
		throw ADP1.InvalidOperation(string.Empty);
	}

	public override ISqlFragment Visit(DbCaseExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("CASE");
		for (int i = 0; i < e.When.Count; i++)
		{
			sqlBuilder.Append(" WHEN (");
			sqlBuilder.Append(e.When[i].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			sqlBuilder.Append(") THEN ");
			sqlBuilder.Append(e.Then[i].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		}
		if (e.Else != null && !(e.Else is DbNullExpression))
		{
			sqlBuilder.Append(" ELSE ");
			sqlBuilder.Append(e.Else.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		}
		sqlBuilder.Append(" END");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbCastExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(" CAST( ");
		sqlBuilder.Append(((DbUnaryExpression)e).Argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		sqlBuilder.Append(" AS ");
		sqlBuilder.Append(GetSqlPrimitiveType(((DbExpression)e).ResultType));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbComparisonExpression e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected I4, but got Unknown
		DbExpressionKind expressionKind = ((DbExpression)e).ExpressionKind;
		if ((int)expressionKind <= 19)
		{
			if ((int)expressionKind == 13)
			{
				return VisitComparisonExpression(" = ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			}
			switch (expressionKind - 18)
			{
			case 0:
				return VisitComparisonExpression(" > ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			case 1:
				return VisitComparisonExpression(" >= ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			}
		}
		else
		{
			switch (expressionKind - 28)
			{
			case 0:
				return VisitComparisonExpression(" < ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			case 1:
				return VisitComparisonExpression(" <= ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			}
			if ((int)expressionKind == 37)
			{
				return VisitComparisonExpression(" <> ", ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
			}
		}
		throw ADP1.InvalidOperation(string.Empty);
	}

	private ISqlFragment VisitConstant(DbConstantExpression e, bool isCastOptional)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected I4, but got Unknown
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (TypeHelpers.TryGetPrimitiveTypeKind(((DbExpression)e).ResultType, out var typeKind))
		{
			PrimitiveTypeKind val = typeKind;
			switch ((int)val)
			{
			case 10:
				sqlBuilder.Append(e.Value.ToString());
				break;
			case 0:
				sqlBuilder.Append(" 0x");
				sqlBuilder.Append(ByteArrayToBinaryString((byte[])e.Value));
				sqlBuilder.Append(" ");
				break;
			case 1:
				WrapWithCastIfNeeded(!isCastOptional, ((bool)e.Value) ? "1" : "0", "bit", sqlBuilder);
				break;
			case 2:
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "tinyint", sqlBuilder);
				break;
			case 3:
				sqlBuilder.Append("convert(");
				sqlBuilder.Append("datetime");
				sqlBuilder.Append(", ");
				sqlBuilder.Append(EscapeSingleQuote(((DateTime)e.Value).ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), isUnicode: false));
				sqlBuilder.Append(", 121)");
				break;
			case 4:
			{
				string text = ((decimal)e.Value).ToString(CultureInfo.InvariantCulture);
				bool cast = -1 == text.IndexOf('.') && text.TrimStart(new char[1] { '-' }).Length < 20;
				string typeName = "decimal(" + Math.Max((byte)text.Length, (byte)18).ToString(CultureInfo.InvariantCulture) + ")";
				WrapWithCastIfNeeded(cast, text, typeName, sqlBuilder);
				break;
			}
			case 5:
				WrapWithCastIfNeeded(cast: true, ((double)e.Value).ToString("R", CultureInfo.InvariantCulture), "float", sqlBuilder);
				break;
			case 6:
				WrapWithCastIfNeeded(cast: true, EscapeSingleQuote(e.Value.ToString(), isUnicode: false), "uniqueidentifier", sqlBuilder);
				break;
			case 9:
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "smallint", sqlBuilder);
				break;
			case 11:
				WrapWithCastIfNeeded(!isCastOptional, e.Value.ToString(), "bigint", sqlBuilder);
				break;
			case 7:
				WrapWithCastIfNeeded(cast: true, ((float)e.Value).ToString("R", CultureInfo.InvariantCulture), "real", sqlBuilder);
				break;
			case 12:
			{
				if (!TypeHelpers.TryGetIsUnicode(((DbExpression)e).ResultType, out var isUnicode))
				{
					isUnicode = true;
				}
				sqlBuilder.Append(EscapeSingleQuote(e.Value as string, isUnicode));
				break;
			}
			case 13:
				throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "Time"));
			case 14:
				throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "DateTimeOffset"));
			default:
				throw ADP1.NotSupported();
			}
			return sqlBuilder;
		}
		throw ADP1.NotSupported();
	}

	private static void WrapWithCastIfNeeded(bool cast, string value, string typeName, SqlBuilder result)
	{
		if (!cast)
		{
			result.Append(value);
			return;
		}
		result.Append("cast(");
		result.Append(value);
		result.Append(" as ");
		result.Append(typeName);
		result.Append(")");
	}

	public override ISqlFragment Visit(DbConstantExpression e)
	{
		return VisitConstant(e, isCastOptional: false);
	}

	public override ISqlFragment Visit(DbDerefExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbDistinctExpression e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(((DbUnaryExpression)e).Argument);
		if (!IsCompatible(sqlSelectStatement, ((DbExpression)e).ExpressionKind))
		{
			TypeUsage elementTypeUsage = TypeHelpers.GetElementTypeUsage(((DbUnaryExpression)e).Argument.ResultType);
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "distinct", elementTypeUsage, out var fromSymbol);
			AddFromSymbol(sqlSelectStatement, "distinct", fromSymbol, addToSymbolTable: false);
		}
		sqlSelectStatement.IsDistinct = true;
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbElementExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("(");
		sqlBuilder.Append(VisitExpressionEnsureSqlStatement(((DbUnaryExpression)e).Argument));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbExceptExpression e)
	{
		return TransformIntersectOrExcept(((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right, isExcept: true);
	}

	public override ISqlFragment Visit(DbExpression e)
	{
		throw ADP1.InvalidOperation(Res.GetString("UnknownExpressionType", ((object)e).GetType().ToString()));
	}

	public override ISqlFragment Visit(DbScanExpression e)
	{
		EntitySetBase target = e.Target;
		if (IsParentAJoin)
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(GetTargetTSql(target));
			return sqlBuilder;
		}
		SqlSelectStatement sqlSelectStatement = new SqlSelectStatement();
		sqlSelectStatement.From.Append(GetTargetTSql(target));
		return sqlSelectStatement;
	}

	internal static string GetTargetTSql(EntitySetBase entitySetBase)
	{
		MetadataProperty val = default;
		if (((MetadataItem)entitySetBase).MetadataProperties.TryGetValue("DefiningQuery", false, ref val) && val.Value != null)
		{
			return "(" + (string)val.Value + ")";
		}
		StringBuilder stringBuilder = new StringBuilder(50);
		MetadataProperty val2 = default;
		if (((MetadataItem)entitySetBase).MetadataProperties.TryGetValue("Table", false, ref val2) && !string.IsNullOrEmpty((string)val2.Value))
		{
			stringBuilder.Append(QuoteIdentifier((string)val2.Value));
		}
		else
		{
			stringBuilder.Append(QuoteIdentifier(entitySetBase.Name));
		}
		return stringBuilder.ToString();
	}

	public override ISqlFragment Visit(DbFilterExpression e)
	{
		return VisitFilterExpression(e.Input, e.Predicate, negatePredicate: false);
	}

	public override ISqlFragment Visit(DbFunctionExpression e)
	{
		if (IsSpecialCanonicalFunction(e))
		{
			return HandleSpecialCanonicalFunction(e);
		}
		if (IsSpecialStoreFunction(e))
		{
			return HandleSpecialStoreFunction(e);
		}
		return HandleFunctionDefault(e);
	}

	public override ISqlFragment Visit(DbEntityRefExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbRefKeyExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbGroupByExpression e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out var fromSymbol);
		if (!IsCompatible(sqlSelectStatement, ((DbExpression)e).ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		symbolTable.Add(e.Input.GroupVariableName, fromSymbol);
		RowType edmType = TypeHelpers.GetEdmType<RowType>(TypeHelpers.GetEdmType<CollectionType>(((DbExpression)e).ResultType).TypeUsage);
		bool flag = GroupByAggregatesNeedInnerQuery(e.Aggregates, e.Input.GroupVariableName) || GroupByKeysNeedInnerQuery(e.Keys, e.Input.VariableName);
		SqlSelectStatement sqlSelectStatement2;
		if (flag)
		{
			sqlSelectStatement2 = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, finalizeOldStatement: false, out fromSymbol);
			AddFromSymbol(sqlSelectStatement2, e.Input.VariableName, fromSymbol, addToSymbolTable: false);
		}
		else
		{
			sqlSelectStatement2 = sqlSelectStatement;
		}
		using (IEnumerator<EdmProperty> enumerator = (IEnumerator<EdmProperty>)(object)edmType.Properties.GetEnumerator())
		{
			enumerator.MoveNext();
			string s = "";
			foreach (DbExpression key in e.Keys)
			{
				EdmProperty current2 = enumerator.Current;
				string s2 = QuoteIdentifier(((EdmMember)current2).Name);
				sqlSelectStatement2.GroupBy.Append(s);
				ISqlFragment s3 = key.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
				if (!flag)
				{
					sqlSelectStatement2.Select.Append(s);
					sqlSelectStatement2.Select.AppendLine();
					sqlSelectStatement2.Select.Append(s3);
					sqlSelectStatement2.Select.Append(" AS ");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.GroupBy.Append(s3);
				}
				else
				{
					sqlSelectStatement.Select.Append(s);
					sqlSelectStatement.Select.AppendLine();
					sqlSelectStatement.Select.Append(s3);
					sqlSelectStatement.Select.Append(" AS ");
					sqlSelectStatement.Select.Append(s2);
					sqlSelectStatement2.Select.Append(s);
					sqlSelectStatement2.Select.AppendLine();
					sqlSelectStatement2.Select.Append(fromSymbol);
					sqlSelectStatement2.Select.Append(".");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.Select.Append(" AS ");
					sqlSelectStatement2.Select.Append(s2);
					sqlSelectStatement2.GroupBy.Append(s2);
				}
				s = ", ";
				enumerator.MoveNext();
			}
			foreach (DbAggregate aggregate in e.Aggregates)
			{
				EdmProperty current4 = enumerator.Current;
				string s4 = QuoteIdentifier(((EdmMember)current4).Name);
				ISqlFragment sqlFragment = aggregate.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
				object aggregateArgument;
				if (flag)
				{
					SqlBuilder sqlBuilder = new SqlBuilder();
					sqlBuilder.Append(fromSymbol);
					sqlBuilder.Append(".");
					sqlBuilder.Append(s4);
					aggregateArgument = sqlBuilder;
					sqlSelectStatement.Select.Append(s);
					sqlSelectStatement.Select.AppendLine();
					sqlSelectStatement.Select.Append(sqlFragment);
					sqlSelectStatement.Select.Append(" AS ");
					sqlSelectStatement.Select.Append(s4);
				}
				else
				{
					aggregateArgument = sqlFragment;
				}
				ISqlFragment s5 = VisitAggregate(aggregate, aggregateArgument);
				sqlSelectStatement2.Select.Append(s);
				sqlSelectStatement2.Select.AppendLine();
				sqlSelectStatement2.Select.Append(s5);
				sqlSelectStatement2.Select.Append(" AS ");
				sqlSelectStatement2.Select.Append(s4);
				s = ", ";
				enumerator.MoveNext();
			}
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement2;
	}

	public override ISqlFragment Visit(DbIntersectExpression e)
	{
		return TransformIntersectOrExcept(((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right, isExcept: false);
	}

	public override ISqlFragment Visit(DbIsEmptyExpression e)
	{
		return VisitIsEmptyExpression(e, negate: false);
	}

	public override ISqlFragment Visit(DbIsNullExpression e)
	{
		return VisitIsNullExpression(e, negate: false);
	}

	public override ISqlFragment Visit(DbIsOfExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbCrossJoinExpression e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return VisitJoinExpression(e.Inputs, ((DbExpression)e).ExpressionKind, "CROSS JOIN", null);
	}

	public override ISqlFragment Visit(DbJoinExpression e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((DbExpression)e).ExpressionKind == 16)
		{
			throw ADP1.FullOuterJoinNotSupportedException();
		}
		DbExpressionKind expressionKind = ((DbExpression)e).ExpressionKind;
		string joinString;
		if ((int)expressionKind == 21)
		{
			joinString = "INNER JOIN";
		}
		else
		{
			joinString = (((int)expressionKind != 27) ? null : "LEFT OUTER JOIN");
		}
		List<DbExpressionBinding> list = new List<DbExpressionBinding>(2);
		list.Add(e.Left);
		list.Add(e.Right);
		return VisitJoinExpression(list, ((DbExpression)e).ExpressionKind, joinString, e.JoinCondition);
	}

	public override ISqlFragment Visit(DbLikeExpression e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(e.Argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		sqlBuilder.Append(" LIKE ");
		sqlBuilder.Append(e.Pattern.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		if ((int)e.Escape.ExpressionKind != 38)
		{
			sqlBuilder.Append(" ESCAPE ");
			sqlBuilder.Append(e.Escape.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbLimitExpression e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (e.WithTies)
		{
			throw ADP1.WithTiesNotSupportedException();
		}
		SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(e.Argument, addDefaultColumns: false);
		if (!IsCompatible(sqlSelectStatement, ((DbExpression)e).ExpressionKind))
		{
			TypeUsage elementTypeUsage = TypeHelpers.GetElementTypeUsage(e.Argument.ResultType);
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "top", elementTypeUsage, out var fromSymbol);
			AddFromSymbol(sqlSelectStatement, "top", fromSymbol, addToSymbolTable: false);
		}
		ISqlFragment topCount = HandleCountExpression(e.Limit);
		sqlSelectStatement.Top = new TopClause(topCount, withTies: false);
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbNewInstanceExpression e)
	{
		if (TypeSemantics.IsCollectionType(((DbExpression)e).ResultType))
		{
			return VisitCollectionConstructor(e);
		}
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbNotExpression e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		DbExpression argument = ((DbUnaryExpression)e).Argument;
		DbNotExpression val = (DbNotExpression)(object)((argument is DbNotExpression) ? argument : null);
		if (val != null)
		{
			return ((DbUnaryExpression)val).Argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
		}
		DbExpression argument2 = ((DbUnaryExpression)e).Argument;
		DbIsEmptyExpression val2 = (DbIsEmptyExpression)(object)((argument2 is DbIsEmptyExpression) ? argument2 : null);
		if (val2 != null)
		{
			return VisitIsEmptyExpression(val2, negate: true);
		}
		DbExpression argument3 = ((DbUnaryExpression)e).Argument;
		DbIsNullExpression val3 = (DbIsNullExpression)(object)((argument3 is DbIsNullExpression) ? argument3 : null);
		if (val3 != null)
		{
			return VisitIsNullExpression(val3, negate: true);
		}
		DbExpression argument4 = ((DbUnaryExpression)e).Argument;
		DbComparisonExpression val4 = (DbComparisonExpression)(object)((argument4 is DbComparisonExpression) ? argument4 : null);
		if (val4 != null && (int)((DbExpression)val4).ExpressionKind == 13)
		{
			return VisitBinaryExpression(" <> ", (DbExpressionKind)37, ((DbBinaryExpression)val4).Left, ((DbBinaryExpression)val4).Right);
		}
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(" NOT (");
		sqlBuilder.Append(((DbUnaryExpression)e).Argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbNullExpression e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("CAST(NULL AS ");
		TypeUsage resultType = ((DbExpression)e).ResultType;
		EdmType edmType = resultType.EdmType;
		PrimitiveType val = (PrimitiveType)(object)((edmType is PrimitiveType) ? edmType : null);
		PrimitiveTypeKind primitiveTypeKind = val.PrimitiveTypeKind;
		if ((int)primitiveTypeKind != 0)
		{
			if ((int)primitiveTypeKind == 12)
			{
				sqlBuilder.Append("nvarchar(1)");
			}
			else
			{
				sqlBuilder.Append(GetSqlPrimitiveType(resultType));
			}
		}
		else
		{
			sqlBuilder.Append("varbinary(1)");
		}
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbOfTypeExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbOrExpression e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return VisitBinaryExpression(" OR ", ((DbExpression)e).ExpressionKind, ((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right);
	}

	public override ISqlFragment Visit(DbParameterReferenceExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("@" + e.ParameterName);
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbProjectExpression e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out var fromSymbol);
		if (!IsCompatible(sqlSelectStatement, ((DbExpression)e).ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		string s = " OUTER APPLY";
		int num = 0;
		bool flag = false;
		DbExpression projection = e.Projection;
		DbNewInstanceExpression val = (DbNewInstanceExpression)(object)((projection is DbNewInstanceExpression) ? projection : null);
		if (val != null)
		{
			for (int i = 0; i < val.Arguments.Count; i++)
			{
				DbExpression val2 = val.Arguments[i];
				if ((int)val2.ExpressionKind != 11)
				{
					continue;
				}
				if (!flag)
				{
					flag = true;
					if (topElementExpression)
					{
						throw ADP1.NotSupported();
					}
					topElementExpression = true;
				}
				sqlSelectStatement.From.AppendLine();
				sqlSelectStatement.From.Append(s);
				sqlSelectStatement.From.AppendLine();
				sqlSelectStatement.From.Append(val2.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
				string text;
				do
				{
					num++;
					text = "SSQTAB" + num;
				}
				while (symbolTable.Lookup(text) != null);
				Symbol fromSymbol2 = new Symbol(text, val2.ResultType);
				AddFromSymbol(sqlSelectStatement, text, fromSymbol2);
				listOfScalarSubQueryTables.Add(text);
				s = ", ";
			}
			sqlSelectStatement.Select.Append(VisitNewInstanceExpression(val));
		}
		else
		{
			sqlSelectStatement.Select.Append(e.Projection.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		}
		if (flag && topElementExpression)
		{
			topElementExpression = false;
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbPropertyExpression e)
	{
		ISqlFragment sqlFragment = e.Instance.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
		DbExpression instance = e.Instance;
		DbVariableReferenceExpression val = (DbVariableReferenceExpression)(object)((instance is DbVariableReferenceExpression) ? instance : null);
		if (val != null)
		{
			isVarRefSingle = false;
		}
		if (sqlFragment is JoinSymbol joinSymbol)
		{
			if (joinSymbol.IsNestedJoin)
			{
				return new SymbolPair(joinSymbol, joinSymbol.NameToExtent[e.Property.Name]);
			}
			return joinSymbol.NameToExtent[e.Property.Name];
		}
		SqlBuilder sqlBuilder;
		if (sqlFragment is SymbolPair symbolPair)
		{
			if (symbolPair.Column is JoinSymbol joinSymbol2)
			{
				symbolPair.Column = joinSymbol2.NameToExtent[e.Property.Name];
				return symbolPair;
			}
			if (symbolPair.Column.Columns.ContainsKey(e.Property.Name))
			{
				sqlBuilder = new SqlBuilder();
				sqlBuilder.Append(symbolPair.Source);
				sqlBuilder.Append(".");
				sqlBuilder.Append(symbolPair.Column.Columns[e.Property.Name]);
				return sqlBuilder;
			}
		}
		sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(sqlFragment);
		sqlBuilder.Append(".");
		if (sqlFragment is Symbol { OutputColumnsRenamed: not false } symbol)
		{
			sqlBuilder.Append(symbol.Columns[e.Property.Name]);
		}
		else
		{
			sqlBuilder.Append(QuoteIdentifier(e.Property.Name));
		}
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbQuantifierExpression e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool negatePredicate = (int)((DbExpression)e).ExpressionKind == 0;
		if ((int)((DbExpression)e).ExpressionKind == 2)
		{
			sqlBuilder.Append("EXISTS (");
		}
		else
		{
			sqlBuilder.Append("NOT EXISTS (");
		}
		SqlSelectStatement sqlSelectStatement = VisitFilterExpression(e.Input, e.Predicate, negatePredicate);
		if (sqlSelectStatement.Select.IsEmpty)
		{
			AddDefaultColumns(sqlSelectStatement);
		}
		sqlBuilder.Append(sqlSelectStatement);
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	public override ISqlFragment Visit(DbRefExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbRelationshipNavigationExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbSkipExpression e)
	{
		throw ADP1.SkipNotSupportedException();
	}

	public override ISqlFragment Visit(DbSortExpression e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(e.Input.Expression, e.Input.VariableName, e.Input.VariableType, out var fromSymbol);
		if (!IsCompatible(sqlSelectStatement, ((DbExpression)e).ExpressionKind))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, e.Input.VariableName, e.Input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, e.Input.VariableName, fromSymbol);
		AddSortKeys(sqlSelectStatement.OrderBy, e.SortOrder);
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	public override ISqlFragment Visit(DbTreatExpression e)
	{
		throw ADP1.NotSupported();
	}

	public override ISqlFragment Visit(DbUnionAllExpression e)
	{
		return VisitSetOpExpression(((DbBinaryExpression)e).Left, ((DbBinaryExpression)e).Right, "UNION ALL");
	}

	public override ISqlFragment Visit(DbVariableReferenceExpression e)
	{
		if (isVarRefSingle)
		{
			throw ADP1.NotSupported();
		}
		isVarRefSingle = true;
		Symbol symbol = symbolTable.Lookup(e.VariableName);
		if (!CurrentSelectStatement.FromExtents.Contains(symbol))
		{
			CurrentSelectStatement.OuterExtents[symbol] = true;
		}
		return symbol;
	}

	private static SqlBuilder VisitAggregate(DbAggregate aggregate, object aggregateArgument)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		DbFunctionAggregate val = (DbFunctionAggregate)(object)((aggregate is DbFunctionAggregate) ? aggregate : null);
		if (val == null)
		{
			throw ADP1.NotSupported(string.Empty);
		}
		if (TypeHelpers.IsCanonicalFunction(val.Function) && string.Equals(((EdmType)val.Function).Name, "BigCount", StringComparison.Ordinal))
		{
			throw ADP1.NotSupported(Res.GetString("FunctionNotSupported", "BigCount"));
		}
		WriteFunctionName(sqlBuilder, val.Function);
		sqlBuilder.Append("(");
		DbFunctionAggregate val2 = val;
		if (val2 != null && val2.Distinct)
		{
			throw ADP1.NotSupported(Res.GetString("DistinctAggregatesNotSupported"));
		}
		sqlBuilder.Append(aggregateArgument);
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private void ParanthesizeExpressionIfNeeded(DbExpression e, SqlBuilder result)
	{
		if (IsComplexExpression(e))
		{
			result.Append("(");
			result.Append(e.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			result.Append(")");
		}
		else
		{
			result.Append(e.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		}
	}

	private SqlBuilder VisitBinaryExpression(string op, DbExpressionKind expressionKind, DbExpression left, DbExpression right)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool flag = true;
		foreach (DbExpression item in CommandTreeUtils.FlattenAssociativeExpression(expressionKind, left, right))
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				sqlBuilder.Append(op);
			}
			ParanthesizeExpressionIfNeeded(item, sqlBuilder);
		}
		return sqlBuilder;
	}

	private SqlBuilder VisitComparisonExpression(string op, DbExpression left, DbExpression right)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool isCastOptional = left.ResultType.EdmType == right.ResultType.EdmType;
		if ((int)left.ExpressionKind == 5)
		{
			sqlBuilder.Append(VisitConstant((DbConstantExpression)left, isCastOptional));
		}
		else
		{
			ParanthesizeExpressionIfNeeded(left, sqlBuilder);
		}
		sqlBuilder.Append(op);
		if ((int)right.ExpressionKind == 5)
		{
			sqlBuilder.Append(VisitConstant((DbConstantExpression)right, isCastOptional));
		}
		else
		{
			ParanthesizeExpressionIfNeeded(right, sqlBuilder);
		}
		return sqlBuilder;
	}

	private SqlSelectStatement VisitInputExpression(DbExpression inputExpression, string inputVarName, TypeUsage inputVarType, out Symbol fromSymbol)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		ISqlFragment sqlFragment = inputExpression.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
		SqlSelectStatement sqlSelectStatement = sqlFragment as SqlSelectStatement;
		if (sqlSelectStatement == null)
		{
			sqlSelectStatement = new SqlSelectStatement();
			WrapNonQueryExtent(sqlSelectStatement, sqlFragment, inputExpression.ExpressionKind);
		}
		if (sqlSelectStatement.FromExtents.Count == 0)
		{
			fromSymbol = new Symbol(inputVarName, inputVarType);
		}
		else if (sqlSelectStatement.FromExtents.Count == 1)
		{
			fromSymbol = sqlSelectStatement.FromExtents[0];
		}
		else
		{
			JoinSymbol joinSymbol = new JoinSymbol(inputVarName, inputVarType, sqlSelectStatement.FromExtents);
			joinSymbol.FlattenedExtentList = sqlSelectStatement.AllJoinExtents;
			fromSymbol = joinSymbol;
			sqlSelectStatement.FromExtents.Clear();
			sqlSelectStatement.FromExtents.Add(fromSymbol);
		}
		return sqlSelectStatement;
	}

	private SqlBuilder VisitIsEmptyExpression(DbIsEmptyExpression e, bool negate)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (!negate)
		{
			sqlBuilder.Append(" NOT");
		}
		sqlBuilder.Append(" EXISTS (");
		sqlBuilder.Append(VisitExpressionEnsureSqlStatement(((DbUnaryExpression)e).Argument));
		sqlBuilder.AppendLine();
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private ISqlFragment VisitCollectionConstructor(DbNewInstanceExpression e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if (e.Arguments.Count == 1 && (int)e.Arguments[0].ExpressionKind == 11)
		{
			DbExpression val = e.Arguments[0];
			DbElementExpression val2 = (DbElementExpression)(object)((val is DbElementExpression) ? val : null);
			SqlSelectStatement sqlSelectStatement = VisitExpressionEnsureSqlStatement(((DbUnaryExpression)val2).Argument);
			if (!IsCompatible(sqlSelectStatement, (DbExpressionKind)11))
			{
				TypeUsage elementTypeUsage = TypeHelpers.GetElementTypeUsage(((DbUnaryExpression)val2).Argument.ResultType);
				sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, "element", elementTypeUsage, out var fromSymbol);
				AddFromSymbol(sqlSelectStatement, "element", fromSymbol, addToSymbolTable: false);
			}
			sqlSelectStatement.Top = new TopClause(1, withTies: false);
			return sqlSelectStatement;
		}
		CollectionType edmType = TypeHelpers.GetEdmType<CollectionType>(((DbExpression)e).ResultType);
		bool flag = TypeSemantics.IsPrimitiveType(edmType.TypeUsage);
		SqlBuilder sqlBuilder = new SqlBuilder();
		string s = "";
		if (e.Arguments.Count == 0)
		{
			sqlBuilder.Append(" SELECT CAST(null as ");
			sqlBuilder.Append(GetSqlPrimitiveType(edmType.TypeUsage));
			sqlBuilder.Append(") AS X FROM (SELECT 1) AS Y WHERE 1=0");
		}
		foreach (DbExpression argument in e.Arguments)
		{
			sqlBuilder.Append(s);
			sqlBuilder.Append(" SELECT ");
			sqlBuilder.Append(argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			if (flag)
			{
				sqlBuilder.Append(" AS X ");
			}
			s = " UNION ALL ";
		}
		return sqlBuilder;
	}

	private SqlBuilder VisitIsNullExpression(DbIsNullExpression e, bool negate)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(((DbUnaryExpression)e).Argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		if (!negate)
		{
			sqlBuilder.Append(" IS NULL");
		}
		else
		{
			sqlBuilder.Append(" IS NOT NULL");
		}
		return sqlBuilder;
	}

	private ISqlFragment VisitJoinExpression(IList<DbExpressionBinding> inputs, DbExpressionKind joinKind, string joinString, DbExpression joinCondition)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Invalid comparison between Unknown and I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Invalid comparison between Unknown and I4
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Invalid comparison between Unknown and I4
		SqlSelectStatement sqlSelectStatement;
		if (!IsParentAJoin)
		{
			sqlSelectStatement = new SqlSelectStatement();
			sqlSelectStatement.AllJoinExtents = new List<Symbol>();
			selectStatementStack.Push(sqlSelectStatement);
		}
		else
		{
			sqlSelectStatement = CurrentSelectStatement;
		}
		symbolTable.EnterScope();
		string text = "";
		bool flag = true;
		int count = inputs.Count;
		for (int i = 0; i < count; i++)
		{
			DbExpressionBinding val = inputs[i];
			if (text.Length != 0)
			{
				sqlSelectStatement.From.AppendLine();
			}
			sqlSelectStatement.From.Append(text + " ");
			bool flag2 = (int)val.Expression.ExpressionKind == 50 || (flag && (IsJoinExpression(val.Expression) || IsApplyExpression(val.Expression)));
			isParentAJoinStack.Push(flag2 ? true : false);
			int count2 = sqlSelectStatement.FromExtents.Count;
			ISqlFragment fromExtentFragment = val.Expression.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
			isParentAJoinStack.Pop();
			ProcessJoinInputResult(fromExtentFragment, sqlSelectStatement, val, count2);
			text = joinString;
			flag = false;
		}
		if ((int)joinKind == 16 || (int)joinKind == 21 || (int)joinKind == 27)
		{
			sqlSelectStatement.From.Append(" ON ");
			isParentAJoinStack.Push(item: false);
			sqlSelectStatement.From.Append(joinCondition.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			isParentAJoinStack.Pop();
		}
		symbolTable.ExitScope();
		if (!IsParentAJoin)
		{
			selectStatementStack.Pop();
		}
		return sqlSelectStatement;
	}

	private void ProcessJoinInputResult(ISqlFragment fromExtentFragment, SqlSelectStatement result, DbExpressionBinding input, int fromSymbolStart)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		Symbol symbol = null;
		if (result != fromExtentFragment)
		{
			if (fromExtentFragment is SqlSelectStatement sqlSelectStatement)
			{
				if (sqlSelectStatement.Select.IsEmpty)
				{
					List<Symbol> columnList = AddDefaultColumns(sqlSelectStatement);
					if (IsJoinExpression(input.Expression) || IsApplyExpression(input.Expression))
					{
						List<Symbol> fromExtents = sqlSelectStatement.FromExtents;
						JoinSymbol joinSymbol = new JoinSymbol(input.VariableName, input.VariableType, fromExtents);
						joinSymbol.IsNestedJoin = true;
						joinSymbol.ColumnList = columnList;
						symbol = joinSymbol;
					}
					else if (sqlSelectStatement.FromExtents[0] is JoinSymbol joinSymbol2)
					{
						JoinSymbol joinSymbol3 = new JoinSymbol(input.VariableName, input.VariableType, joinSymbol2.ExtentList);
						joinSymbol3.IsNestedJoin = true;
						joinSymbol3.ColumnList = columnList;
						joinSymbol3.FlattenedExtentList = joinSymbol2.FlattenedExtentList;
						symbol = joinSymbol3;
					}
					else if (sqlSelectStatement.FromExtents[0].OutputColumnsRenamed)
					{
						symbol = new Symbol(input.VariableName, input.VariableType, sqlSelectStatement.FromExtents[0].Columns);
					}
				}
				else if (sqlSelectStatement.OutputColumnsRenamed)
				{
					symbol = new Symbol(input.VariableName, input.VariableType, sqlSelectStatement.OutputColumns);
				}
				result.From.Append(" (");
				result.From.Append(sqlSelectStatement);
				result.From.Append(" )");
			}
			else if (input.Expression is DbScanExpression)
			{
				result.From.Append(fromExtentFragment);
			}
			else
			{
				WrapNonQueryExtent(result, fromExtentFragment, input.Expression.ExpressionKind);
			}
			if (symbol == null)
			{
				symbol = new Symbol(input.VariableName, input.VariableType);
			}
			AddFromSymbol(result, input.VariableName, symbol);
			result.AllJoinExtents.Add(symbol);
		}
		else
		{
			List<Symbol> list = new List<Symbol>();
			for (int i = fromSymbolStart; i < result.FromExtents.Count; i++)
			{
				list.Add(result.FromExtents[i]);
			}
			result.FromExtents.RemoveRange(fromSymbolStart, result.FromExtents.Count - fromSymbolStart);
			symbol = new JoinSymbol(input.VariableName, input.VariableType, list);
			result.FromExtents.Add(symbol);
			symbolTable.Add(input.VariableName, symbol);
		}
	}

	private string getAliasFromElementExpression(DbElementExpression exp)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		DbExpression argument = ((DbUnaryExpression)exp).Argument;
		RowType edmType = TypeHelpers.GetEdmType<RowType>(TypeHelpers.GetEdmType<CollectionType>(argument.ResultType).TypeUsage);
		IEnumerator<EdmProperty> enumerator = (IEnumerator<EdmProperty>)(object)edmType.Properties.GetEnumerator();
		enumerator.MoveNext();
		EdmProperty current = enumerator.Current;
		return QuoteIdentifier(((EdmMember)current).Name);
	}

	private ISqlFragment VisitNewInstanceExpression(DbNewInstanceExpression e)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		SqlBuilder sqlBuilder = new SqlBuilder();
		EdmType edmType = ((DbExpression)e).ResultType.EdmType;
		RowType val = (RowType)(object)((edmType is RowType) ? edmType : null);
		if (val != null)
		{
			ReadOnlyMetadataCollection<EdmProperty> properties = val.Properties;
			string s = "";
			for (int i = 0; i < e.Arguments.Count; i++)
			{
				DbExpression val2 = e.Arguments[i];
				if (TypeSemantics.IsRowType(val2.ResultType))
				{
					throw ADP1.NotSupported();
				}
				EdmProperty val3 = ((ReadOnlyCollection<EdmProperty>)(object)properties)[i];
				sqlBuilder.Append(s);
				sqlBuilder.AppendLine();
				if ((int)val2.ExpressionKind == 11)
				{
					string text = listOfScalarSubQueryTables[0];
					Symbol s2 = symbolTable.Lookup(text);
					sqlBuilder.Append(s2);
					sqlBuilder.Append(".");
					sqlBuilder.Append(getAliasFromElementExpression((DbElementExpression)val2));
					listOfScalarSubQueryTables.Remove(text);
				}
				else
				{
					sqlBuilder.Append(val2.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
				}
				sqlBuilder.Append(" AS ");
				sqlBuilder.Append(QuoteIdentifier(((EdmMember)val3).Name));
				s = ", ";
			}
			return sqlBuilder;
		}
		throw ADP1.NotSupported();
	}

	private ISqlFragment VisitSetOpExpression(DbExpression left, DbExpression right, string separator)
	{
		SqlSelectStatement s = VisitExpressionEnsureSqlStatement(left);
		SqlSelectStatement s2 = VisitExpressionEnsureSqlStatement(right);
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(s);
		sqlBuilder.AppendLine();
		sqlBuilder.Append(separator);
		sqlBuilder.AppendLine();
		sqlBuilder.Append(s2);
		return sqlBuilder;
	}

	private static bool IsSpecialStoreFunction(DbFunctionExpression e)
	{
		if (IsStoreFunction(e.Function))
		{
			return _storeFunctionHandlers.ContainsKey(((EdmType)e.Function).Name);
		}
		return false;
	}

	private static bool IsSpecialCanonicalFunction(DbFunctionExpression e)
	{
		if (TypeHelpers.IsCanonicalFunction(e.Function))
		{
			return _canonicalFunctionHandlers.ContainsKey(((EdmType)e.Function).Name);
		}
		return false;
	}

	private ISqlFragment HandleFunctionDefault(DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool flag = CastReturnTypeToInt32(e);
		if (flag)
		{
			sqlBuilder.Append(" CAST(");
		}
		WriteFunctionName(sqlBuilder, e.Function);
		HandleFunctionArgumentsDefault(e, sqlBuilder);
		if (flag)
		{
			sqlBuilder.Append(" AS int)");
		}
		return sqlBuilder;
	}

	private ISqlFragment HandleFunctionDefaultGivenName(DbFunctionExpression e, string functionName)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		bool flag = CastReturnTypeToInt32(e);
		if (flag)
		{
			sqlBuilder.Append("CAST(");
		}
		sqlBuilder.Append(functionName);
		HandleFunctionArgumentsDefault(e, sqlBuilder);
		if (flag)
		{
			sqlBuilder.Append(" AS int)");
		}
		return sqlBuilder;
	}

	private void HandleFunctionArgumentsDefault(DbFunctionExpression e, SqlBuilder result)
	{
		MetadataProperty val = default;
		bool flag = ((MetadataItem)e.Function).MetadataProperties.TryGetValue("NiladicFunctionAttribute", false, ref val) && val.Value != null && (bool)val.Value;
		if (flag && e.Arguments.Count > 0)
		{
			ADP1.Metadata(Res.GetString("NiladicFunctionsCannotHaveParameters"));
		}
		if (flag)
		{
			return;
		}
		result.Append("(");
		string s = "";
		foreach (DbExpression argument in e.Arguments)
		{
			result.Append(s);
			result.Append(argument.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			s = ", ";
		}
		result.Append(")");
	}

	private ISqlFragment HandleSpecialStoreFunction(DbFunctionExpression e)
	{
		return HandleSpecialFunction(_storeFunctionHandlers, e);
	}

	private ISqlFragment HandleSpecialCanonicalFunction(DbFunctionExpression e)
	{
		return HandleSpecialFunction(_canonicalFunctionHandlers, e);
	}

	private ISqlFragment HandleSpecialFunction(Dictionary<string, FunctionHandler> handlers, DbFunctionExpression e)
	{
		return handlers[((EdmType)e.Function).Name](this, e);
	}

	private ISqlFragment HandleSpecialFunctionToOperator(DbFunctionExpression e, bool parenthesiseArguments)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (e.Arguments.Count > 1)
		{
			if (parenthesiseArguments)
			{
				sqlBuilder.Append("(");
			}
			sqlBuilder.Append(e.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			if (parenthesiseArguments)
			{
				sqlBuilder.Append(")");
			}
		}
		sqlBuilder.Append(" ");
		sqlBuilder.Append(_functionNameToOperatorDictionary[((EdmType)e.Function).Name]);
		sqlBuilder.Append(" ");
		if (parenthesiseArguments)
		{
			sqlBuilder.Append("(");
		}
		sqlBuilder.Append(e.Arguments[e.Arguments.Count - 1].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		if (parenthesiseArguments)
		{
			sqlBuilder.Append(")");
		}
		return sqlBuilder;
	}

	private static ISqlFragment HandleConcatFunction(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleSpecialFunctionToOperator(e, parenthesiseArguments: false);
	}

	private static ISqlFragment HandleCanonicalFunctionBitwise(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleSpecialFunctionToOperator(e, parenthesiseArguments: true);
	}

	private static ISqlFragment HandleUnsupportedFunction(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		throw ADP1.NotSupported(Res.GetString("FunctionNotSupported", ((EdmType)e.Function).Name));
	}

	private static ISqlFragment HandleDatepartDateFunction(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		DbExpression val = e.Arguments[0];
		DbConstantExpression val2 = (DbConstantExpression)(object)((val is DbConstantExpression) ? val : null);
		if (val2 == null)
		{
			throw ADP1.InvalidOperation(Res.GetString("InvalidDatePartArgumentExpression", ((EdmType)e.Function).NamespaceName, ((EdmType)e.Function).Name));
		}
		if (!(val2.Value is string text))
		{
			throw ADP1.InvalidOperation(Res.GetString("InvalidDatePartArgumentExpression", ((EdmType)e.Function).NamespaceName, ((EdmType)e.Function).Name));
		}
		SqlBuilder sqlBuilder = new SqlBuilder();
		if (!_datepartKeywords.ContainsKey(text))
		{
			throw ADP1.InvalidOperation(Res.GetString("InvalidDatePartArgumentValue", text, ((EdmType)e.Function).NamespaceName, ((EdmType)e.Function).Name));
		}
		WriteFunctionName(sqlBuilder, e.Function);
		sqlBuilder.Append("(");
		sqlBuilder.Append(text);
		string s = ", ";
		for (int i = 1; i < e.Arguments.Count; i++)
		{
			sqlBuilder.Append(s);
			sqlBuilder.Append(e.Arguments[i].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)sqlgen));
		}
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionDatepart(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleCanonicalFunctionDatepart(((EdmType)e.Function).Name.ToLowerInvariant(), e);
	}

	private ISqlFragment HandleCanonicalFunctionDatepart(string datepart, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("DATEPART (");
		sqlBuilder.Append(datepart);
		sqlBuilder.Append(", ");
		sqlBuilder.Append(e.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		sqlBuilder.Append(")");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionCurrentDateTime(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "GetDate");
	}

	private static ISqlFragment HandleCanonicalFunctionIndexOf(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "CHARINDEX");
	}

	private static ISqlFragment HandleCanonicalFunctionNewGuid(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "NEWID");
	}

	private static ISqlFragment HandleCanonicalFunctionLength(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "LEN");
	}

	private static ISqlFragment HandleCanonicalFunctionRound(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("ROUND(");
		sqlBuilder.Append(e.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)sqlgen));
		sqlBuilder.Append(", 0)");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionTrim(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append("LTRIM(RTRIM(");
		sqlBuilder.Append(e.Arguments[0].Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)sqlgen));
		sqlBuilder.Append("))");
		return sqlBuilder;
	}

	private static ISqlFragment HandleCanonicalFunctionToLower(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "LOWER");
	}

	private static ISqlFragment HandleCanonicalFunctionToUpper(SqlGenerator sqlgen, DbFunctionExpression e)
	{
		return sqlgen.HandleFunctionDefaultGivenName(e, "UPPER");
	}

	private static void WriteFunctionName(SqlBuilder result, EdmFunction function)
	{
		MetadataProperty val = default;
		string text = ((!((MetadataItem)function).MetadataProperties.TryGetValue("StoreFunctionNameAttribute", false, ref val) || val.Value == null) ? ((EdmType)function).Name : ((string)val.Value));
		if (TypeHelpers.IsCanonicalFunction(function))
		{
			result.Append(text.ToUpperInvariant());
			return;
		}
		if (IsStoreFunction(function))
		{
			result.Append(text);
			return;
		}
		throw ADP1.NotSupported(Res.GetString("UserDefinedFunctionsNotSupported"));
	}

	private void AddColumns(SqlSelectStatement selectStatement, Symbol symbol, List<Symbol> columnList, Dictionary<string, Symbol> columnDictionary, ref string separator)
	{
		if (symbol is JoinSymbol joinSymbol)
		{
			if (!joinSymbol.IsNestedJoin)
			{
				foreach (Symbol extent in joinSymbol.ExtentList)
				{
					if (extent.Type != null && !TypeSemantics.IsPrimitiveType(extent.Type))
					{
						AddColumns(selectStatement, extent, columnList, columnDictionary, ref separator);
					}
				}
				return;
			}
			{
				foreach (Symbol column in joinSymbol.ColumnList)
				{
					selectStatement.Select.Append(separator);
					selectStatement.Select.Append(symbol);
					selectStatement.Select.Append(".");
					selectStatement.Select.Append(column);
					if (columnDictionary.ContainsKey(column.Name))
					{
						columnDictionary[column.Name].NeedsRenaming = true;
						column.NeedsRenaming = true;
					}
					else
					{
						columnDictionary[column.Name] = column;
					}
					columnList.Add(column);
					separator = ", ";
				}
				return;
			}
		}
		if (symbol.OutputColumnsRenamed)
		{
			selectStatement.OutputColumnsRenamed = true;
			selectStatement.OutputColumns = new Dictionary<string, Symbol>();
		}
		if (symbol.Type == null || TypeSemantics.IsPrimitiveType(symbol.Type))
		{
			AddColumn(selectStatement, symbol, columnList, columnDictionary, ref separator, "X");
			return;
		}
		foreach (EdmProperty property in TypeHelpers.GetProperties(symbol.Type))
		{
			AddColumn(selectStatement, symbol, columnList, columnDictionary, ref separator, ((EdmMember)property).Name);
		}
	}

	private void AddColumn(SqlSelectStatement selectStatement, Symbol symbol, List<Symbol> columnList, Dictionary<string, Symbol> columnDictionary, ref string separator, string columnName)
	{
		allColumnNames[columnName] = 0;
		if (!symbol.Columns.TryGetValue(columnName, out var value))
		{
			value = new Symbol(columnName, null);
			symbol.Columns.Add(columnName, value);
		}
		selectStatement.Select.Append(separator);
		selectStatement.Select.Append(symbol);
		selectStatement.Select.Append(".");
		if (symbol.OutputColumnsRenamed)
		{
			selectStatement.Select.Append(value);
			selectStatement.OutputColumns.Add(value.Name, value);
		}
		else
		{
			selectStatement.Select.Append(QuoteIdentifier(columnName));
		}
		selectStatement.Select.Append(" AS ");
		selectStatement.Select.Append(value);
		if (columnDictionary.ContainsKey(columnName))
		{
			columnDictionary[columnName].NeedsRenaming = true;
			value.NeedsRenaming = true;
		}
		else
		{
			columnDictionary[columnName] = symbol.Columns[columnName];
		}
		columnList.Add(value);
		separator = ", ";
	}

	private List<Symbol> AddDefaultColumns(SqlSelectStatement selectStatement)
	{
		List<Symbol> list = new List<Symbol>();
		Dictionary<string, Symbol> columnDictionary = new Dictionary<string, Symbol>(StringComparer.OrdinalIgnoreCase);
		string separator = "";
		if (!selectStatement.Select.IsEmpty)
		{
			separator = ", ";
		}
		foreach (Symbol fromExtent in selectStatement.FromExtents)
		{
			AddColumns(selectStatement, fromExtent, list, columnDictionary, ref separator);
		}
		return list;
	}

	private void AddFromSymbol(SqlSelectStatement selectStatement, string inputVarName, Symbol fromSymbol)
	{
		AddFromSymbol(selectStatement, inputVarName, fromSymbol, addToSymbolTable: true);
	}

	private void AddFromSymbol(SqlSelectStatement selectStatement, string inputVarName, Symbol fromSymbol, bool addToSymbolTable)
	{
		if (selectStatement.FromExtents.Count == 0 || fromSymbol != selectStatement.FromExtents[0])
		{
			selectStatement.FromExtents.Add(fromSymbol);
			selectStatement.From.Append(" AS ");
			selectStatement.From.Append(fromSymbol);
			allExtentNames[fromSymbol.Name] = 0;
		}
		if (addToSymbolTable)
		{
			symbolTable.Add(inputVarName, fromSymbol);
		}
	}

	private void AddSortKeys(SqlBuilder orderByClause, IList<DbSortClause> sortKeys)
	{
		string s = "";
		foreach (DbSortClause sortKey in sortKeys)
		{
			orderByClause.Append(s);
			orderByClause.Append(sortKey.Expression.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
			if (!string.IsNullOrEmpty(sortKey.Collation))
			{
				throw ADP1.CollateInOrderByNotSupportedException();
			}
			orderByClause.Append(sortKey.Ascending ? " ASC" : " DESC");
			s = ", ";
		}
	}

	private SqlSelectStatement CreateNewSelectStatement(SqlSelectStatement oldStatement, string inputVarName, TypeUsage inputVarType, out Symbol fromSymbol)
	{
		return CreateNewSelectStatement(oldStatement, inputVarName, inputVarType, finalizeOldStatement: true, out fromSymbol);
	}

	private SqlSelectStatement CreateNewSelectStatement(SqlSelectStatement oldStatement, string inputVarName, TypeUsage inputVarType, bool finalizeOldStatement, out Symbol fromSymbol)
	{
		fromSymbol = null;
		if (finalizeOldStatement && oldStatement.Select.IsEmpty)
		{
			List<Symbol> columnList = AddDefaultColumns(oldStatement);
			if (oldStatement.FromExtents[0] is JoinSymbol joinSymbol)
			{
				JoinSymbol joinSymbol2 = new JoinSymbol(inputVarName, inputVarType, joinSymbol.ExtentList);
				joinSymbol2.IsNestedJoin = true;
				joinSymbol2.ColumnList = columnList;
				joinSymbol2.FlattenedExtentList = joinSymbol.FlattenedExtentList;
				fromSymbol = joinSymbol2;
			}
		}
		if (fromSymbol == null)
		{
			if (oldStatement.OutputColumnsRenamed)
			{
				fromSymbol = new Symbol(inputVarName, inputVarType, oldStatement.OutputColumns);
			}
			else
			{
				fromSymbol = new Symbol(inputVarName, inputVarType);
			}
		}
		SqlSelectStatement sqlSelectStatement = new SqlSelectStatement();
		sqlSelectStatement.From.Append("( ");
		sqlSelectStatement.From.Append(oldStatement);
		sqlSelectStatement.From.AppendLine();
		sqlSelectStatement.From.Append(") ");
		return sqlSelectStatement;
	}

	private static string EscapeSingleQuote(string s, bool isUnicode)
	{
		return (isUnicode ? "N'" : "'") + s.Replace("'", "''") + "'";
	}

	private string GetSqlPrimitiveType(TypeUsage type)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected I4, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected I4, but got Unknown
		TypeUsage storeType = ((DbProviderManifest)SqlCeProviderManifest.Instance).GetStoreType(type);
		string text = storeType.EdmType.Name;
		int maxLength = 0;
		byte precision = 0;
		byte scale = 0;
		PrimitiveTypeKind primitiveTypeKind = ((PrimitiveType)storeType.EdmType).PrimitiveTypeKind;
		PrimitiveTypeKind val = primitiveTypeKind;
		switch ((int)val)
		{
		default:
			switch (val - 12)
			{
			case 0:
				if (!TypeHelpers.IsFacetValueConstant(storeType, "MaxLength"))
				{
					TypeHelpers.TryGetMaxLength(storeType, out maxLength);
					text = text + "(" + maxLength.ToString(CultureInfo.InvariantCulture) + ")";
				}
				break;
			case 1:
				throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "Time"));
			case 2:
				throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "DateTimeOffset"));
			}
			break;
		case 0:
			if (!TypeHelpers.IsFacetValueConstant(storeType, "MaxLength"))
			{
				TypeHelpers.TryGetMaxLength(storeType, out maxLength);
				text = text + "(" + maxLength.ToString(CultureInfo.InvariantCulture) + ")";
			}
			break;
		case 3:
			text = "datetime";
			break;
		case 4:
			if (!TypeHelpers.IsFacetValueConstant(storeType, "Precision"))
			{
				TypeHelpers.TryGetPrecision(storeType, out precision);
				TypeHelpers.TryGetScale(storeType, out scale);
				text = text + "(" + precision + "," + scale + ")";
			}
			break;
		case 1:
		case 2:
			break;
		}
		return text;
	}

	private ISqlFragment HandleCountExpression(DbExpression e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.ExpressionKind == 5)
		{
			SqlBuilder sqlBuilder = new SqlBuilder();
			sqlBuilder.Append(((DbConstantExpression)e).Value.ToString());
			return sqlBuilder;
		}
		return e.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this);
	}

	private static bool IsApplyExpression(DbExpression e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between I4 and Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between I4 and Unknown
		if (6 != (int)e.ExpressionKind)
		{
			return 42 == (int)e.ExpressionKind;
		}
		return true;
	}

	private static bool IsJoinExpression(DbExpression e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between I4 and Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between I4 and Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between I4 and Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between I4 and Unknown
		if (7 != (int)e.ExpressionKind && 16 != (int)e.ExpressionKind && 21 != (int)e.ExpressionKind)
		{
			return 27 == (int)e.ExpressionKind;
		}
		return true;
	}

	private static bool IsComplexExpression(DbExpression e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		DbExpressionKind expressionKind = e.ExpressionKind;
		if ((int)expressionKind == 5 || (int)expressionKind == 43 || (int)expressionKind == 46)
		{
			return false;
		}
		return true;
	}

	private static bool IsCompatible(SqlSelectStatement result, DbExpressionKind expressionKind)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected I4, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected I4, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		if ((int)expressionKind <= 20)
		{
			switch (expressionKind - 9)
			{
			case 0:
				goto IL_0051;
			case 2:
				goto IL_00cd;
			case 1:
				goto IL_0163;
			}
			if ((int)expressionKind == 15)
			{
				if (result.Select.IsEmpty && result.Where.IsEmpty && result.GroupBy.IsEmpty)
				{
					return result.Top == null;
				}
				return false;
			}
			if ((int)expressionKind == 20)
			{
				if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
				{
					return result.Top == null;
				}
				return false;
			}
		}
		else
		{
			if ((int)expressionKind == 31)
			{
				goto IL_00cd;
			}
			if ((int)expressionKind == 45)
			{
				if (result.Select.IsEmpty && result.GroupBy.IsEmpty)
				{
					return !result.IsDistinct;
				}
				return false;
			}
			switch (expressionKind - 51)
			{
			case 0:
				if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
				{
					return !result.IsDistinct;
				}
				return false;
			case 1:
				if (result.Select.IsEmpty && result.GroupBy.IsEmpty && result.OrderBy.IsEmpty)
				{
					return !result.IsDistinct;
				}
				return false;
			}
		}
		goto IL_0163;
		IL_0163:
		throw ADP1.InvalidOperation(string.Empty);
		IL_0051:
		if (result.Top == null)
		{
			return result.OrderBy.IsEmpty;
		}
		return false;
		IL_00cd:
		return result.Top == null;
	}

	internal static string QuoteIdentifier(string name)
	{
		return "[" + name.Replace("]", "]]") + "]";
	}

	private ISqlFragment TransformIntersectOrExcept(DbExpression left, DbExpression right, bool isExcept)
	{
		SqlSelectStatement oldStatement = VisitExpressionEnsureSqlStatement(right);
		CollectionType edmType = TypeHelpers.GetEdmType<CollectionType>(right.ResultType);
		SqlSelectStatement sqlSelectStatement = CreateNewSelectStatement(oldStatement, "b", edmType.TypeUsage, out var fromSymbol);
		sqlSelectStatement.FromExtents.Add(fromSymbol);
		sqlSelectStatement.Select.Append("0");
		sqlSelectStatement.From.Append(" AS ");
		sqlSelectStatement.From.Append(fromSymbol);
		List<Symbol> list = AddDefaultColumns(sqlSelectStatement);
		SqlSelectStatement oldStatement2 = VisitExpressionEnsureSqlStatement(left);
		CollectionType edmType2 = TypeHelpers.GetEdmType<CollectionType>(left.ResultType);
		SqlSelectStatement sqlSelectStatement2 = CreateNewSelectStatement(oldStatement2, "a", edmType2.TypeUsage, out var fromSymbol2);
		sqlSelectStatement2.FromExtents.Add(fromSymbol2);
		sqlSelectStatement2.IsDistinct = true;
		sqlSelectStatement2.From.Append(" AS ");
		sqlSelectStatement2.From.Append(fromSymbol2);
		List<Symbol> list2 = AddDefaultColumns(sqlSelectStatement2);
		bool flag = true;
		for (int i = 0; i < list2.Count; i++)
		{
			if (!flag)
			{
				sqlSelectStatement.Where.Append(" AND ");
			}
			else
			{
				flag = false;
			}
			sqlSelectStatement.Where.Append("( ");
			sqlSelectStatement.Where.Append(fromSymbol2);
			sqlSelectStatement.Where.Append(".");
			sqlSelectStatement.Where.Append(list2[i]);
			sqlSelectStatement.Where.Append(" = ");
			sqlSelectStatement.Where.Append(fromSymbol);
			sqlSelectStatement.Where.Append(".");
			sqlSelectStatement.Where.Append(list[i]);
			sqlSelectStatement.Where.Append(" OR (");
			sqlSelectStatement.Where.Append(fromSymbol2);
			sqlSelectStatement.Where.Append(".");
			sqlSelectStatement.Where.Append(list2[i]);
			sqlSelectStatement.Where.Append(" IS NULL AND ");
			sqlSelectStatement.Where.Append(fromSymbol);
			sqlSelectStatement.Where.Append(".");
			sqlSelectStatement.Where.Append(list[i]);
			sqlSelectStatement.Where.Append(" IS NULL");
			sqlSelectStatement.Where.Append(") )");
		}
		if (isExcept)
		{
			sqlSelectStatement2.Where.Append(" NOT ");
		}
		sqlSelectStatement2.Where.Append(" EXISTS ( ");
		sqlSelectStatement2.Where.Append(sqlSelectStatement);
		sqlSelectStatement2.Where.Append(" ) ");
		return sqlSelectStatement2;
	}

	private SqlSelectStatement VisitExpressionEnsureSqlStatement(DbExpression e)
	{
		return VisitExpressionEnsureSqlStatement(e, addDefaultColumns: true);
	}

	private SqlSelectStatement VisitExpressionEnsureSqlStatement(DbExpression e, bool addDefaultColumns)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected I4, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		DbExpressionKind expressionKind = e.ExpressionKind;
		if ((int)expressionKind <= 20)
		{
			if ((int)expressionKind == 15 || (int)expressionKind == 20)
			{
				goto IL_0028;
			}
		}
		else if ((int)expressionKind == 45 || (int)expressionKind == 52)
		{
			goto IL_0028;
		}
		string inputVarName = "c";
		symbolTable.EnterScope();
		TypeUsage val = null;
		DbExpressionKind expressionKind2 = e.ExpressionKind;
		if ((int)expressionKind2 <= 21)
		{
			switch (expressionKind2 - 6)
			{
			case 0:
			case 1:
				goto IL_008c;
			}
			if ((int)expressionKind2 == 16 || (int)expressionKind2 == 21)
			{
				goto IL_008c;
			}
		}
		else if ((int)expressionKind2 == 27 || (int)expressionKind2 == 42 || (int)expressionKind2 == 50)
		{
			goto IL_008c;
		}
		val = TypeHelpers.GetEdmType<CollectionType>(e.ResultType).TypeUsage;
		goto IL_00ab;
		IL_008c:
		val = TypeHelpers.GetElementTypeUsage(e.ResultType);
		goto IL_00ab;
		IL_00cb:
		SqlSelectStatement sqlSelectStatement;
		if (addDefaultColumns && sqlSelectStatement.Select.IsEmpty)
		{
			AddDefaultColumns(sqlSelectStatement);
		}
		return sqlSelectStatement;
		IL_0028:
		sqlSelectStatement = e.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this) as SqlSelectStatement;
		goto IL_00cb;
		IL_00ab:
		sqlSelectStatement = VisitInputExpression(e, inputVarName, val, out var fromSymbol);
		AddFromSymbol(sqlSelectStatement, inputVarName, fromSymbol);
		symbolTable.ExitScope();
		goto IL_00cb;
	}

	private SqlSelectStatement VisitFilterExpression(DbExpressionBinding input, DbExpression predicate, bool negatePredicate)
	{
		SqlSelectStatement sqlSelectStatement = VisitInputExpression(input.Expression, input.VariableName, input.VariableType, out var fromSymbol);
		if (!IsCompatible(sqlSelectStatement, (DbExpressionKind)15))
		{
			sqlSelectStatement = CreateNewSelectStatement(sqlSelectStatement, input.VariableName, input.VariableType, out fromSymbol);
		}
		selectStatementStack.Push(sqlSelectStatement);
		symbolTable.EnterScope();
		AddFromSymbol(sqlSelectStatement, input.VariableName, fromSymbol);
		if (negatePredicate)
		{
			sqlSelectStatement.Where.Append("NOT (");
		}
		sqlSelectStatement.Where.Append(predicate.Accept<ISqlFragment>((DbExpressionVisitor<ISqlFragment>)this));
		if (negatePredicate)
		{
			sqlSelectStatement.Where.Append(")");
		}
		symbolTable.ExitScope();
		selectStatementStack.Pop();
		return sqlSelectStatement;
	}

	private static void WrapNonQueryExtent(SqlSelectStatement result, ISqlFragment sqlFragment, DbExpressionKind expressionKind)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Invalid comparison between Unknown and I4
		if ((int)expressionKind == 17)
		{
			throw ADP1.NotSupported(Res.GetString("TVFsNotSupported"));
		}
		result.From.Append(" (");
		result.From.Append(sqlFragment);
		result.From.Append(")");
	}

	private static bool IsStoreFunction(EdmFunction function)
	{
		if ((bool)((MetadataItem)function).MetadataProperties["BuiltInAttribute"].Value)
		{
			return !TypeHelpers.IsCanonicalFunction(function);
		}
		return false;
	}

	private static string ByteArrayToBinaryString(byte[] binaryArray)
	{
		StringBuilder stringBuilder = new StringBuilder(binaryArray.Length * 2);
		for (int i = 0; i < binaryArray.Length; i++)
		{
			stringBuilder.Append(hexDigits[(binaryArray[i] & 0xF0) >> 4]).Append(hexDigits[binaryArray[i] & 0xF]);
		}
		return stringBuilder.ToString();
	}

	private static bool GroupByAggregatesNeedInnerQuery(IList<DbAggregate> aggregates, string inputVarRefName)
	{
		foreach (DbAggregate aggregate in aggregates)
		{
			if (GroupByAggregateNeedsInnerQuery(aggregate.Arguments[0], inputVarRefName))
			{
				return true;
			}
		}
		return false;
	}

	private static bool GroupByAggregateNeedsInnerQuery(DbExpression expression, string inputVarRefName)
	{
		return GroupByExpressionNeedsInnerQuery(expression, inputVarRefName, allowConstants: true);
	}

	private static bool GroupByKeysNeedInnerQuery(IList<DbExpression> keys, string inputVarRefName)
	{
		foreach (DbExpression key in keys)
		{
			if (GroupByKeyNeedsInnerQuery(key, inputVarRefName))
			{
				return true;
			}
		}
		return false;
	}

	private static bool GroupByKeyNeedsInnerQuery(DbExpression expression, string inputVarRefName)
	{
		return GroupByExpressionNeedsInnerQuery(expression, inputVarRefName, allowConstants: false);
	}

	private static bool GroupByExpressionNeedsInnerQuery(DbExpression expression, string inputVarRefName, bool allowConstants)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		if (allowConstants && (int)expression.ExpressionKind == 5)
		{
			return false;
		}
		if ((int)expression.ExpressionKind == 4)
		{
			DbCastExpression val = (DbCastExpression)expression;
			return GroupByExpressionNeedsInnerQuery(((DbUnaryExpression)val).Argument, inputVarRefName, allowConstants);
		}
		if ((int)expression.ExpressionKind == 46)
		{
			DbPropertyExpression val2 = (DbPropertyExpression)expression;
			return GroupByExpressionNeedsInnerQuery(val2.Instance, inputVarRefName, allowConstants);
		}
		if ((int)expression.ExpressionKind == 56)
		{
			DbVariableReferenceExpression val3 = (DbVariableReferenceExpression)(object)((expression is DbVariableReferenceExpression) ? expression : null);
			return !val3.VariableName.Equals(inputVarRefName);
		}
		return true;
	}

	private bool CastReturnTypeToInt32(DbFunctionExpression e)
	{
		if (!_functionRequiresReturnTypeCast.Contains(((EdmType)e.Function).FullName))
		{
			return false;
		}
		for (int i = 0; i < e.Arguments.Count; i++)
		{
			TypeUsage storeType = ((DbProviderManifest)SqlCeProviderManifest.Instance).GetStoreType(e.Arguments[i].ResultType);
			if (_maxTypeNames.Contains(storeType.EdmType.Name))
			{
				return true;
			}
		}
		return false;
	}
}
