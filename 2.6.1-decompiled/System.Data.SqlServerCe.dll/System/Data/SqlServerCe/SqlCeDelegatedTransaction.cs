using System.Transactions;

namespace System.Data.SqlServerCe;

internal sealed class SqlCeDelegatedTransaction : IPromotableSinglePhaseNotification, ITransactionPromoter
{
	private SqlCeConnection _connection;

	private IsolationLevel seIsolationLevel;

	private SqlCeTransaction _sqlCeTransaction;

	private Transaction _atomicTransaction;

	internal Transaction Transaction => _atomicTransaction;

	public SqlCeTransaction SqlCeTransaction
	{
		get
		{
			return _sqlCeTransaction;
		}
		set
		{
			_sqlCeTransaction = value;
		}
	}

	private void CloseDelegatedConnection(SqlCeConnection connection)
	{
		connection.Close();
	}

	internal SqlCeDelegatedTransaction(SqlCeConnection connection, Transaction tx)
	{
		_connection = connection;
		_atomicTransaction = tx;
		System.Transactions.IsolationLevel isolationLevel = tx.IsolationLevel;
		switch (isolationLevel)
		{
		case System.Transactions.IsolationLevel.Unspecified:
			seIsolationLevel = IsolationLevel.Unspecified;
			break;
		case System.Transactions.IsolationLevel.ReadCommitted:
			seIsolationLevel = IsolationLevel.ReadCommitted;
			break;
		case System.Transactions.IsolationLevel.ReadUncommitted:
			seIsolationLevel = IsolationLevel.ReadUncommitted;
			break;
		case System.Transactions.IsolationLevel.RepeatableRead:
			seIsolationLevel = IsolationLevel.RepeatableRead;
			break;
		case System.Transactions.IsolationLevel.Serializable:
			seIsolationLevel = IsolationLevel.Serializable;
			break;
		default:
			throw new ArgumentException(Res.GetString("ADP_InvalidIsolationLevel", isolationLevel.ToString()));
		}
	}

	public void Initialize()
	{
		_sqlCeTransaction = _connection.BeginTransaction(seIsolationLevel);
	}

	internal static TransactionPromotionException PromotionFailed(Exception inner)
	{
		return new TransactionPromotionException();
	}

	public byte[] Promote()
	{
		throw PromotionFailed(null);
	}

	public void Rollback(SinglePhaseEnlistment enlistment)
	{
		if (_sqlCeTransaction == null)
		{
			enlistment.Aborted();
			return;
		}
		if (_connection.HasOpenedCursors(_sqlCeTransaction))
		{
			_connection.DisposeSqlCeDataRdr(_sqlCeTransaction);
		}
		_sqlCeTransaction.Rollback();
		_connection.DelegatedTransaction = null;
		if (_connection.State == ConnectionState.Closed)
		{
			CloseDelegatedConnection(_connection);
		}
		enlistment.Aborted();
	}

	public void SinglePhaseCommit(SinglePhaseEnlistment enlistment)
	{
		if (_sqlCeTransaction == null)
		{
			enlistment.Committed();
			return;
		}
		if (_connection.HasOpenedCursors(_sqlCeTransaction))
		{
			_connection.DisposeSqlCeDataRdr(_sqlCeTransaction);
		}
		_sqlCeTransaction.Commit();
		_connection.DelegatedTransaction = null;
		if (_connection.State == ConnectionState.Closed)
		{
			CloseDelegatedConnection(_connection);
		}
		enlistment.Committed();
	}
}
