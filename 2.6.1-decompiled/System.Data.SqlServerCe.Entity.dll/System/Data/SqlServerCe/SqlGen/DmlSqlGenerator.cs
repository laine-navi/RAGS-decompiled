using System.Collections.Generic;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;
using System.Text;

namespace System.Data.SqlServerCe.SqlGen;

internal static class DmlSqlGenerator
{
	private class ExpressionTranslator : BasicExpressionVisitor
	{
		private readonly StringBuilder _commandText;

		private readonly DbModificationCommandTree _commandTree;

		private readonly List<DbParameter> _parameters;

		private readonly Dictionary<EdmMember, DbParameter> _memberValues;

		private static readonly AliasGenerator s_parameterNames = new AliasGenerator("@", 1000);

		private readonly bool _isLocalProvider;

		internal List<DbParameter> Parameters => _parameters;

		internal Dictionary<EdmMember, DbParameter> MemberValues => _memberValues;

		internal ExpressionTranslator(StringBuilder commandText, DbModificationCommandTree commandTree, bool preserveMemberValues, bool isLocalProvider)
		{
			_commandText = commandText;
			_commandTree = commandTree;
			_parameters = new List<DbParameter>();
			_memberValues = (preserveMemberValues ? new Dictionary<EdmMember, DbParameter>() : null);
			_isLocalProvider = isLocalProvider;
		}

		internal DbParameter CreateParameter(object value, TypeUsage type)
		{
			DbParameter dbParameter = SqlCeProviderServices.CreateSqlCeParameter(s_parameterNames.GetName(_parameters.Count), type, (ParameterMode)0, value, ignoreMaxLengthFacet: true, _isLocalProvider);
			_parameters.Add(dbParameter);
			return dbParameter;
		}

		public override void Visit(DbAndExpression expression)
		{
			VisitBinary((DbBinaryExpression)(object)expression, " and ");
		}

		public override void Visit(DbOrExpression expression)
		{
			VisitBinary((DbBinaryExpression)(object)expression, " or ");
		}

		public override void Visit(DbComparisonExpression expression)
		{
			VisitBinary((DbBinaryExpression)(object)expression, " = ");
			RegisterMemberValue(((DbBinaryExpression)expression).Left, ((DbBinaryExpression)expression).Right);
		}

		internal void RegisterMemberValue(DbExpression propertyExpression, DbExpression value)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Invalid comparison between Unknown and I4
			if (_memberValues != null)
			{
				EdmMember property = ((DbPropertyExpression)propertyExpression).Property;
				if ((int)value.ExpressionKind != 38)
				{
					_memberValues[property] = _parameters[_parameters.Count - 1];
				}
			}
		}

		public override void Visit(DbIsNullExpression expression)
		{
			((DbUnaryExpression)expression).Argument.Accept((DbExpressionVisitor)(object)this);
			_commandText.Append(" is null");
		}

		public override void Visit(DbNotExpression expression)
		{
			_commandText.Append("not (");
			((DbExpression)expression).Accept((DbExpressionVisitor)(object)this);
			_commandText.Append(")");
		}

		public override void Visit(DbConstantExpression expression)
		{
			DbParameter dbParameter = CreateParameter(expression.Value, ((DbExpression)expression).ResultType);
			_commandText.Append(dbParameter.ParameterName);
		}

		public override void Visit(DbScanExpression expression)
		{
			MetadataProperty val = default;
			if (((MetadataItem)expression.Target).MetadataProperties.TryGetValue("DefiningQuery", false, ref val) && val.Value != null)
			{
				DbModificationCommandTree commandTree = _commandTree;
				DbInsertCommandTree val2 = (DbInsertCommandTree)(object)((commandTree is DbInsertCommandTree) ? commandTree : null);
				DbModificationCommandTree commandTree2 = _commandTree;
				DbDeleteCommandTree val3 = (DbDeleteCommandTree)(object)((commandTree2 is DbDeleteCommandTree) ? commandTree2 : null);
				string text;
				if (val3 != null)
				{
					text = "DeleteFunction";
				}
				else
				{
					text = ((val2 == null) ? "UpdateFunction" : "InsertFunction");
				}
				throw ADP1.Update(Res.GetString("Update_SqlEntitySetWithoutDmlFunctions", expression.Target.Name, text, "ModificationFunctionMapping"), null);
			}
			_commandText.Append(SqlGenerator.GetTargetTSql(expression.Target));
		}

		public override void Visit(DbPropertyExpression expression)
		{
			_commandText.Append(GenerateMemberTSql(expression.Property));
		}

		public override void Visit(DbNullExpression expression)
		{
			_commandText.Append("null");
		}

		public override void Visit(DbNewInstanceExpression expression)
		{
			bool flag = true;
			foreach (DbExpression argument in expression.Arguments)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					_commandText.Append(", ");
				}
				argument.Accept((DbExpressionVisitor)(object)this);
			}
		}

		private void VisitBinary(DbBinaryExpression expression, string separator)
		{
			_commandText.Append("(");
			expression.Left.Accept((DbExpressionVisitor)(object)this);
			_commandText.Append(separator);
			expression.Right.Accept((DbExpressionVisitor)(object)this);
			_commandText.Append(")");
		}
	}

	private const int s_commandTextBuilderInitialCapacity = 256;

	private static string storeGeneratedPatternString = "StoreGeneratedPattern";

	private static string rowversionString = "rowversion";

	private static bool GetUpdatableColumn(DbUpdateCommandTree tree, out string updatableColumnName)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between I4 and Unknown
		bool result = false;
		updatableColumnName = "";
		EntityType val = (EntityType)((DbModificationCommandTree)tree).Target.VariableType.EdmType;
		Enumerator<EdmProperty> enumerator = val.Properties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				EdmProperty current = enumerator.Current;
				if (((EntityTypeBase)val).KeyMembers.Contains(((EdmMember)current).Name) || rowversionString == ((EdmMember)current).TypeUsage.EdmType.Name)
				{
					continue;
				}
				if (((EdmMember)current).TypeUsage.Facets.Contains(storeGeneratedPatternString))
				{
					Facet value = ((EdmMember)current).TypeUsage.Facets.GetValue(storeGeneratedPatternString, false);
					if (1 == (int)(StoreGeneratedPattern)value.Value)
					{
						continue;
					}
				}
				updatableColumnName = ((EdmMember)current).Name;
				result = true;
				break;
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return result;
	}

	internal static string GenerateUpdateSql(DbUpdateCommandTree tree, out List<DbParameter> parameters, bool isLocalProvider)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, (DbModificationCommandTree)(object)tree, null != tree.Returning, isLocalProvider);
		stringBuilder.Append("update ");
		((DbModificationCommandTree)tree).Target.Expression.Accept((DbExpressionVisitor)(object)expressionTranslator);
		stringBuilder.AppendLine();
		bool flag = true;
		stringBuilder.Append("set ");
		foreach (DbSetClause setClause in tree.SetClauses)
		{
			DbSetClause val = setClause;
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(", ");
			}
			val.Property.Accept((DbExpressionVisitor)(object)expressionTranslator);
			stringBuilder.Append(" = ");
			val.Value.Accept((DbExpressionVisitor)(object)expressionTranslator);
		}
		if (flag)
		{
			if (!GetUpdatableColumn(tree, out var updatableColumnName))
			{
				throw ADP1.Update(Res.GetString("UpdateStatementCannotBeGeneratedForAcquiringLock"), null);
			}
			stringBuilder.Append("[");
			stringBuilder.Append(Utilities.EscapeSquareBraceNames(updatableColumnName));
			stringBuilder.Append("] ");
			stringBuilder.Append(" = ");
			stringBuilder.Append("[");
			stringBuilder.Append(Utilities.EscapeSquareBraceNames(updatableColumnName));
			stringBuilder.Append("] ");
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("where ");
		tree.Predicate.Accept((DbExpressionVisitor)(object)expressionTranslator);
		stringBuilder.AppendLine();
		GenerateReturningSql(stringBuilder, (DbModificationCommandTree)(object)tree, expressionTranslator, tree.Returning);
		parameters = expressionTranslator.Parameters;
		return stringBuilder.ToString();
	}

	internal static string GenerateDeleteSql(DbDeleteCommandTree tree, out List<DbParameter> parameters, bool isLocalProvider)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, (DbModificationCommandTree)(object)tree, preserveMemberValues: false, isLocalProvider);
		stringBuilder.Append("delete ");
		((DbModificationCommandTree)tree).Target.Expression.Accept((DbExpressionVisitor)(object)expressionTranslator);
		stringBuilder.AppendLine();
		stringBuilder.Append("where ");
		tree.Predicate.Accept((DbExpressionVisitor)(object)expressionTranslator);
		parameters = expressionTranslator.Parameters;
		return stringBuilder.ToString();
	}

	internal static string GenerateInsertSql(DbInsertCommandTree tree, out List<DbParameter> parameters, bool isLocalProvider)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		StringBuilder stringBuilder = new StringBuilder(256);
		ExpressionTranslator expressionTranslator = new ExpressionTranslator(stringBuilder, (DbModificationCommandTree)(object)tree, null != tree.Returning, isLocalProvider);
		stringBuilder.Append("insert ");
		((DbModificationCommandTree)tree).Target.Expression.Accept((DbExpressionVisitor)(object)expressionTranslator);
		if (0 < tree.SetClauses.Count)
		{
			stringBuilder.Append("(");
			bool flag = true;
			foreach (DbSetClause setClause in tree.SetClauses)
			{
				DbSetClause val = setClause;
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(", ");
				}
				val.Property.Accept((DbExpressionVisitor)(object)expressionTranslator);
			}
			stringBuilder.AppendLine(")");
			flag = true;
			stringBuilder.Append("values (");
			foreach (DbSetClause setClause2 in tree.SetClauses)
			{
				DbSetClause val2 = setClause2;
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(", ");
				}
				val2.Value.Accept((DbExpressionVisitor)(object)expressionTranslator);
				expressionTranslator.RegisterMemberValue(val2.Property, val2.Value);
			}
			stringBuilder.AppendLine(")");
			GenerateReturningSql(stringBuilder, (DbModificationCommandTree)(object)tree, expressionTranslator, tree.Returning);
			parameters = expressionTranslator.Parameters;
			return stringBuilder.ToString();
		}
		throw ADP1.NotSupported("Default values not supported");
	}

	private static string GenerateMemberTSql(EdmMember member)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_ = (EntityType)member.DeclaringType;
		return SqlGenerator.QuoteIdentifier(member.Name);
	}

	private static void GenerateReturningSql(StringBuilder commandText, DbModificationCommandTree tree, ExpressionTranslator translator, DbExpression returning)
	{
		if (returning != null)
		{
			throw ADP1.DMLQueryCannotReturnResultsException();
		}
	}

	private static bool IsValidIdentityColumnType(TypeUsage typeUsage)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)((MetadataItem)typeUsage.EdmType).BuiltInTypeKind != 26)
		{
			return false;
		}
		string name = typeUsage.EdmType.Name;
		if (name == "int" || name == "bigint")
		{
			return true;
		}
		return false;
	}
}
