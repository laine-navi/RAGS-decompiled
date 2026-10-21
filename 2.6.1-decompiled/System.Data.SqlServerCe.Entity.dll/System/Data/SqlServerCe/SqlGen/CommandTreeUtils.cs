using System.Collections.Generic;
using System.Data.Common.CommandTrees;

namespace System.Data.SqlServerCe.SqlGen;

internal static class CommandTreeUtils
{
	private static readonly Queue<DbExpressionKind> _associativeExpressionKinds = new Queue<DbExpressionKind>(new DbExpressionKind[4]
	{
		(DbExpressionKind)41,
		(DbExpressionKind)1,
		(DbExpressionKind)44,
		(DbExpressionKind)34
	});

	internal static IEnumerable<DbExpression> FlattenAssociativeExpression(DbExpression expression)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return FlattenAssociativeExpression(expression.ExpressionKind, expression);
	}

	internal static IEnumerable<DbExpression> FlattenAssociativeExpression(DbExpressionKind expressionKind, params DbExpression[] arguments)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!_associativeExpressionKinds.Contains(expressionKind))
		{
			return arguments;
		}
		List<DbExpression> list = new List<DbExpression>();
		foreach (DbExpression expression in arguments)
		{
			ExtractAssociativeArguments(expressionKind, list, expression);
		}
		return list;
	}

	private static void ExtractAssociativeArguments(DbExpressionKind expressionKind, List<DbExpression> argumentList, DbExpression expression)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (expression.ExpressionKind != expressionKind)
		{
			argumentList.Add(expression);
			return;
		}
		DbBinaryExpression val = (DbBinaryExpression)(object)((expression is DbBinaryExpression) ? expression : null);
		if (val != null)
		{
			ExtractAssociativeArguments(expressionKind, argumentList, val.Left);
			ExtractAssociativeArguments(expressionKind, argumentList, val.Right);
		}
		else
		{
			DbArithmeticExpression val2 = (DbArithmeticExpression)expression;
			ExtractAssociativeArguments(expressionKind, argumentList, val2.Arguments[0]);
			ExtractAssociativeArguments(expressionKind, argumentList, val2.Arguments[1]);
		}
	}
}
