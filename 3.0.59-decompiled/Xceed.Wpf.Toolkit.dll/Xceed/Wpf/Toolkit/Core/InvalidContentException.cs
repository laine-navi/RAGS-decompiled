using System;

namespace Xceed.Wpf.Toolkit.Core;

public class InvalidContentException : Exception
{
	public InvalidContentException(string message)
		: base(message)
	{
	}

	public InvalidContentException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
