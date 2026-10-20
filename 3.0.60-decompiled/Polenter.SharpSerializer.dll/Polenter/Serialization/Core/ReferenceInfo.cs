namespace Polenter.Serialization.Core;

public sealed class ReferenceInfo
{
	public int Count { get; set; }

	public int Id { get; set; }

	public bool IsProcessed { get; set; }

	public ReferenceInfo()
	{
		Count = 1;
	}

	public override string ToString()
	{
		return string.Format("{0}, Count={1}, Id={2}, IsProcessed={3}", new object[4]
		{
			GetType().Name,
			Count,
			Id,
			IsProcessed
		});
	}
}
