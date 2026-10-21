using System.Threading;

namespace Rags;

public class RagsThread
{
	public Thread TheThread;

	public Timer CurTimer;

	public bool bTerminate;

	public RagsThread(ref Thread athread, ref Timer atimer)
	{
		TheThread = athread;
		CurTimer = atimer;
	}
}
