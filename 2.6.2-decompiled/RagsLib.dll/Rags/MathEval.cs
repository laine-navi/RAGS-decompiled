using System;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Rags;

public class MathEval
{
	private static VsaEngine m_a;

	public static void Initialize()
	{
		if (MathEval.m_a == null)
		{
			MathEval.m_a = VsaEngine.CreateEngine();
		}
	}

	public static void Close()
	{
		if (MathEval.m_a != null)
		{
			((BaseVsaEngine)MathEval.m_a).Close();
		}
	}

	public static void EvaluateString(ref object result, string sStringToEvaluate)
	{
		if (sStringToEvaluate.Trim() == string.Empty)
		{
			result = -1;
			return;
		}
		try
		{
			if (MathEval.m_a == null)
			{
				MathEval.m_a = VsaEngine.CreateEngine();
			}
			result = Eval.JScriptEvaluate((object)b(sStringToEvaluate), MathEval.m_a);
			if (result == null)
			{
				result = "Null value returned from evaluate.";
			}
		}
		catch (Exception ex)
		{
			result = ex.StackTrace;
			if (MathEval.m_a != null)
			{
				((BaseVsaEngine)MathEval.m_a).Reset();
			}
		}
	}

	private static string b(string A_0)
	{
		_ = string.Empty;
		return A_0.Replace("Scripting.FileSystemObject", string.Empty);
	}

	internal static double a(string A_0)
	{
		object result = null;
		EvaluateString(ref result, A_0);
		return Convert.ToDouble(result);
	}

	static MathEval()
	{
		MathEval.m_a = VsaEngine.CreateEngine();
	}
}
