namespace System.Data.SqlServerCe;

public sealed class SqlCeFlushFailureEventArgs : EventArgs
{
	private object src;

	private SqlCeErrorCollection errors;

	public SqlCeErrorCollection Errors => errors;

	public string Message => Errors[0].Message;

	internal SqlCeFlushFailureEventArgs(int hr, IntPtr pError, object src)
	{
		this.src = src;
		errors = new SqlCeErrorCollection();
		errors.FillErrorInformation(hr, pError);
	}

	public override string ToString()
	{
		return Message;
	}
}
