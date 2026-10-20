using System;
using A;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Rags;

public sealed class MathEval
{
	private static VsaEngine c393cb451edf794cb4586dd102949702e = VsaEngine.CreateEngine();

	public static void Initialize()
	{
		if (c393cb451edf794cb4586dd102949702e != null)
		{
			__ldtoken(MathEval.Initialize());
		}
		else
		{
			c393cb451edf794cb4586dd102949702e = VsaEngine.CreateEngine();
		}
	}

	public static void Close()
	{
		if (c393cb451edf794cb4586dd102949702e == null)
		{
			__ldtoken(MathEval.Close());
		}
		else
		{
			((BaseVsaEngine)c393cb451edf794cb4586dd102949702e).Close();
		}
	}

	public static void EvaluateString(ref object result, string sStringToEvaluate)
	{
		if (!(sStringToEvaluate.Trim() == string.Empty))
		{
			__ldtoken(MathEval.EvaluateString(ref object, string));
			try
			{
				if (c393cb451edf794cb4586dd102949702e != null)
				{
					__ldtoken(MathEval.EvaluateString(ref object, string));
				}
				else
				{
					c393cb451edf794cb4586dd102949702e = VsaEngine.CreateEngine();
				}
				result = Eval.JScriptEvaluate((object)ca288e5431558cce402a3dd859ac53eaf(sStringToEvaluate), c393cb451edf794cb4586dd102949702e);
				if (result != null)
				{
					__ldtoken(MathEval.EvaluateString(ref object, string));
				}
				else
				{
					result = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58616);
				}
				return;
			}
			catch (Exception ex)
			{
				result = ex.StackTrace;
				if (c393cb451edf794cb4586dd102949702e == null)
				{
					__ldtoken(MathEval.EvaluateString(ref object, string));
				}
				else
				{
					((BaseVsaEngine)c393cb451edf794cb4586dd102949702e).Reset();
				}
				return;
			}
		}
		result = -1;
	}

	private static string ca288e5431558cce402a3dd859ac53eaf(string P_0)
	{
		string empty = string.Empty;
		return P_0.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58685), string.Empty);
	}

	internal static double c80e54f2b332dd2f601331d2cf3f8eaaa(string P_0)
	{
		object result = null;
		EvaluateString(ref result, P_0);
		return Convert.ToDouble(result);
	}
}
