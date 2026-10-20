using System.Globalization;

namespace WPFRagsDesigner;

public class CultureData
{
	public CultureInfo Data;

	public CultureData(CultureInfo ci)
	{
		Data = ci;
	}

	public override string ToString()
	{
		return Data.DisplayName;
	}
}
