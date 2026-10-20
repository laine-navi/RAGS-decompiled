using System;

namespace Xceed.Wpf.Toolkit.Core;

public class InvalidTemplateException : Exception
{
	public InvalidTemplateException(string message)
		: base(message)
	{
	}

	public InvalidTemplateException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
