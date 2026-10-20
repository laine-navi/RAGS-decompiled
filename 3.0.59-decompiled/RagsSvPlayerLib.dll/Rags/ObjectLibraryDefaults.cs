using System.Collections.Generic;

namespace Rags;

public class ObjectLibraryDefaults
{
	public static List<GameObject> GetObjLibDefaults()
	{
		List<GameObject> list = new List<GameObject>();
		GameObject gameObject = new GameObject();
		list.Add(gameObject);
		gameObject.name = "door";
		return list;
	}
}
