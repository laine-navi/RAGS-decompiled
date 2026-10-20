namespace System.Data.SqlServerCe;

internal class WeakReferenceCache
{
	private bool _trackResurrection;

	protected WeakReference[] items;

	internal int Count
	{
		get
		{
			lock (this)
			{
				return items.Length;
			}
		}
	}

	internal WeakReferenceCache(bool trackResurrection)
	{
		items = new WeakReference[20];
		_trackResurrection = trackResurrection;
	}

	internal int Add(object value)
	{
		lock (this)
		{
			int num = items.Length;
			for (int i = 0; i < num; i++)
			{
				WeakReference weakReference = items[i];
				if (weakReference == null)
				{
					items[i] = new WeakReference(value, _trackResurrection);
					return i;
				}
				if (!ADP.IsAlive(weakReference))
				{
					weakReference.Target = value;
					return i;
				}
			}
			int num2 = ((5 == num) ? 15 : (num + 15));
			WeakReference[] array = new WeakReference[num2];
			for (int j = 0; j < num; j++)
			{
				array[j] = items[j];
			}
			array[num] = new WeakReference(value, _trackResurrection);
			items = array;
			return num;
		}
	}

	internal object GetObject(int indx)
	{
		lock (this)
		{
			try
			{
				WeakReference weakReference = items[indx];
				if (ADP.IsAlive(weakReference))
				{
					return weakReference.Target;
				}
				return null;
			}
			catch (InvalidOperationException)
			{
				return null;
			}
		}
	}

	internal void Remove(object value)
	{
		lock (this)
		{
			int num = items.Length;
			for (int i = 0; i < num; i++)
			{
				WeakReference weakReference = items[i];
				try
				{
					if (!ADP.IsAlive(weakReference) || value != weakReference.Target)
					{
						continue;
					}
					items[i] = null;
					break;
				}
				catch (InvalidOperationException)
				{
				}
			}
		}
	}

	internal void RemoveAt(int index)
	{
		lock (this)
		{
			items[index] = null;
		}
	}
}
