using System.Collections;

namespace Rags;

public class ObjectLibraryDefaults
{
	public static ArrayList GetObjLibDefaults()
	{
		ArrayList arrayList = new ArrayList();
		GameObject gameObject = new GameObject();
		arrayList.Add(gameObject);
		gameObject.name = "door";
		return arrayList;
	}
}
