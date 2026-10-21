using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;

namespace System.Data.SqlServerCe;

internal abstract class BasicExpressionVisitor : DbExpressionVisitor
{
	protected virtual void VisitUnaryExpression(DbUnaryExpression expression)
	{
		VisitExpression(ADP1.CheckArgumentNull<DbUnaryExpression>(expression, "expression").Argument);
	}

	protected virtual void VisitBinaryExpression(DbBinaryExpression expression)
	{
		ADP1.CheckArgumentNull<DbBinaryExpression>(expression, "expression");
		VisitExpression(expression.Left);
		VisitExpression(expression.Right);
	}

	protected virtual void VisitExpressionBindingPre(DbExpressionBinding binding)
	{
		ADP1.CheckArgumentNull<DbExpressionBinding>(binding, "binding");
		VisitExpression(binding.Expression);
	}

	protected virtual void VisitExpressionBindingPost(DbExpressionBinding binding)
	{
	}

	protected virtual void VisitGroupExpressionBindingPre(DbGroupExpressionBinding binding)
	{
		ADP1.CheckArgumentNull<DbGroupExpressionBinding>(binding, "binding");
		VisitExpression(binding.Expression);
	}

	protected virtual void VisitGroupExpressionBindingMid(DbGroupExpressionBinding binding)
	{
	}

	protected virtual void VisitGroupExpressionBindingPost(DbGroupExpressionBinding binding)
	{
	}

	protected virtual void VisitLambdaFunctionPre(EdmFunction function, DbExpression body)
	{
		ADP1.CheckArgumentNull<EdmFunction>(function, "function");
		ADP1.CheckArgumentNull<DbExpression>(body, "body");
	}

	protected virtual void VisitLambdaFunctionPost(EdmFunction function, DbExpression body)
	{
	}

	public void VisitExpression(DbExpression expression)
	{
		ADP1.CheckArgumentNull<DbExpression>(expression, "expression").Accept((DbExpressionVisitor)(object)this);
	}

	public virtual void VisitExpressionList(IList<DbExpression> expressionList)
	{
		ADP1.CheckArgumentNull(expressionList, "expressionList");
		for (int i = 0; i < expressionList.Count; i++)
		{
			VisitExpression(expressionList[i]);
		}
	}

	public virtual void VisitAggregateList(IList<DbAggregate> aggregates)
	{
		ADP1.CheckArgumentNull(aggregates, "aggregates");
		for (int i = 0; i < aggregates.Count; i++)
		{
			VisitAggregate(aggregates[i]);
		}
	}

	public virtual void VisitAggregate(DbAggregate aggregate)
	{
		VisitExpressionList(ADP1.CheckArgumentNull<DbAggregate>(aggregate, "aggregate").Arguments);
	}

	public override void Visit(DbExpression expression)
	{
		ADP1.CheckArgumentNull<DbExpression>(expression, "expression");
		throw ADP1.NotSupported();
	}

	public override void Visit(DbConstantExpression expression)
	{
		ADP1.CheckArgumentNull<DbConstantExpression>(expression, "expression");
	}

	public override void Visit(DbNullExpression expression)
	{
		ADP1.CheckArgumentNull<DbNullExpression>(expression, "expression");
	}

	public override void Visit(DbVariableReferenceExpression expression)
	{
		ADP1.CheckArgumentNull<DbVariableReferenceExpression>(expression, "expression");
	}

	public override void Visit(DbParameterReferenceExpression expression)
	{
		ADP1.CheckArgumentNull<DbParameterReferenceExpression>(expression, "expression");
	}

	public override void Visit(DbFunctionExpression expression)
	{
		ADP1.CheckArgumentNull<DbFunctionExpression>(expression, "expression");
		VisitExpressionList(expression.Arguments);
	}

	public override void Visit(DbPropertyExpression expression)
	{
		ADP1.CheckArgumentNull<DbPropertyExpression>(expression, "expression");
		if (expression.Instance != null)
		{
			VisitExpression(expression.Instance);
		}
	}

	public override void Visit(DbComparisonExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbLikeExpression expression)
	{
		ADP1.CheckArgumentNull<DbLikeExpression>(expression, "expression");
		VisitExpression(expression.Argument);
		VisitExpression(expression.Pattern);
		VisitExpression(expression.Escape);
	}

	public override void Visit(DbLimitExpression expression)
	{
		ADP1.CheckArgumentNull<DbLimitExpression>(expression, "expression");
		VisitExpression(expression.Argument);
		VisitExpression(expression.Limit);
	}

	public override void Visit(DbIsNullExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbArithmeticExpression expression)
	{
		VisitExpressionList(ADP1.CheckArgumentNull<DbArithmeticExpression>(expression, "expression").Arguments);
	}

	public override void Visit(DbAndExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbOrExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbNotExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbDistinctExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbElementExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbIsEmptyExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbUnionAllExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbIntersectExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbExceptExpression expression)
	{
		VisitBinaryExpression((DbBinaryExpression)(object)expression);
	}

	public override void Visit(DbOfTypeExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbTreatExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbCastExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbIsOfExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbCaseExpression expression)
	{
		ADP1.CheckArgumentNull<DbCaseExpression>(expression, "expression");
		VisitExpressionList(expression.When);
		VisitExpressionList(expression.Then);
		VisitExpression(expression.Else);
	}

	public override void Visit(DbNewInstanceExpression expression)
	{
		VisitExpressionList(ADP1.CheckArgumentNull<DbNewInstanceExpression>(expression, "expression").Arguments);
	}

	public override void Visit(DbRefExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbRelationshipNavigationExpression expression)
	{
		VisitExpression(ADP1.CheckArgumentNull<DbRelationshipNavigationExpression>(expression, "expression").NavigationSource);
	}

	public override void Visit(DbDerefExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbRefKeyExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbEntityRefExpression expression)
	{
		VisitUnaryExpression((DbUnaryExpression)(object)expression);
	}

	public override void Visit(DbScanExpression expression)
	{
		ADP1.CheckArgumentNull<DbScanExpression>(expression, "expression");
	}

	public override void Visit(DbFilterExpression expression)
	{
		ADP1.CheckArgumentNull<DbFilterExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Predicate);
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbProjectExpression expression)
	{
		ADP1.CheckArgumentNull<DbProjectExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Projection);
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbCrossJoinExpression expression)
	{
		ADP1.CheckArgumentNull<DbCrossJoinExpression>(expression, "expression");
		foreach (DbExpressionBinding input in expression.Inputs)
		{
			VisitExpressionBindingPre(input);
		}
		foreach (DbExpressionBinding input2 in expression.Inputs)
		{
			VisitExpressionBindingPost(input2);
		}
	}

	public override void Visit(DbJoinExpression expression)
	{
		ADP1.CheckArgumentNull<DbJoinExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Left);
		VisitExpressionBindingPre(expression.Right);
		VisitExpression(expression.JoinCondition);
		VisitExpressionBindingPost(expression.Left);
		VisitExpressionBindingPost(expression.Right);
	}

	public override void Visit(DbApplyExpression expression)
	{
		ADP1.CheckArgumentNull<DbApplyExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		if (expression.Apply != null)
		{
			VisitExpression(expression.Apply.Expression);
		}
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbGroupByExpression expression)
	{
		ADP1.CheckArgumentNull<DbGroupByExpression>(expression, "expression");
		VisitGroupExpressionBindingPre(expression.Input);
		VisitExpressionList(expression.Keys);
		VisitGroupExpressionBindingMid(expression.Input);
		VisitAggregateList(expression.Aggregates);
		VisitGroupExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbSortExpression expression)
	{
		ADP1.CheckArgumentNull<DbSortExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		for (int i = 0; i < expression.SortOrder.Count; i++)
		{
			VisitExpression(expression.SortOrder[i].Expression);
		}
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbQuantifierExpression expression)
	{
		ADP1.CheckArgumentNull<DbQuantifierExpression>(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Predicate);
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbSkipExpression e)
	{
		throw ADP1.SkipNotSupportedException();
	}
}
