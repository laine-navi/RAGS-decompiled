using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal static class CalculatorUtilities
{
	public static Calculator.CalculatorButtonType GetCalculatorButtonTypeFromText(string text)
	{
		switch (text)
		{
		case "0":
			return Calculator.CalculatorButtonType.Zero;
		case "1":
			return Calculator.CalculatorButtonType.One;
		case "2":
			return Calculator.CalculatorButtonType.Two;
		case "3":
			return Calculator.CalculatorButtonType.Three;
		case "4":
			return Calculator.CalculatorButtonType.Four;
		case "5":
			return Calculator.CalculatorButtonType.Five;
		case "6":
			return Calculator.CalculatorButtonType.Six;
		case "7":
			return Calculator.CalculatorButtonType.Seven;
		case "8":
			return Calculator.CalculatorButtonType.Eight;
		case "9":
			return Calculator.CalculatorButtonType.Nine;
		case "+":
			return Calculator.CalculatorButtonType.Add;
		case "-":
			return Calculator.CalculatorButtonType.Subtract;
		case "*":
			return Calculator.CalculatorButtonType.Multiply;
		case "/":
			return Calculator.CalculatorButtonType.Divide;
		case "%":
			return Calculator.CalculatorButtonType.Percent;
		case "\b":
			return Calculator.CalculatorButtonType.Back;
		case "\r":
		case "=":
			return Calculator.CalculatorButtonType.Equal;
		default:
			if (text == CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
			{
				return Calculator.CalculatorButtonType.Decimal;
			}
			if (text == '\u001b'.ToString())
			{
				return Calculator.CalculatorButtonType.Clear;
			}
			return Calculator.CalculatorButtonType.None;
		}
	}

	public static Button FindButtonByCalculatorButtonType(DependencyObject parent, Calculator.CalculatorButtonType type)
	{
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(parent, i);
			object value = child.GetValue(ButtonBase.CommandParameterProperty);
			if (value != null && (Calculator.CalculatorButtonType)value == type)
			{
				return (Button)(object)((child is Button) ? child : null);
			}
			Button val = FindButtonByCalculatorButtonType(child, type);
			if (val != null)
			{
				return val;
			}
		}
		return null;
	}

	public static string GetCalculatorButtonContent(Calculator.CalculatorButtonType type)
	{
		string result = string.Empty;
		switch (type)
		{
		case Calculator.CalculatorButtonType.Add:
			result = "+";
			break;
		case Calculator.CalculatorButtonType.Back:
			result = "Back";
			break;
		case Calculator.CalculatorButtonType.Cancel:
			result = "CE";
			break;
		case Calculator.CalculatorButtonType.Clear:
			result = "C";
			break;
		case Calculator.CalculatorButtonType.Decimal:
			result = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
			break;
		case Calculator.CalculatorButtonType.Divide:
			result = "/";
			break;
		case Calculator.CalculatorButtonType.Eight:
			result = "8";
			break;
		case Calculator.CalculatorButtonType.Equal:
			result = "=";
			break;
		case Calculator.CalculatorButtonType.Five:
			result = "5";
			break;
		case Calculator.CalculatorButtonType.Four:
			result = "4";
			break;
		case Calculator.CalculatorButtonType.Fraction:
			result = "1/x";
			break;
		case Calculator.CalculatorButtonType.MAdd:
			result = "M+";
			break;
		case Calculator.CalculatorButtonType.MC:
			result = "MC";
			break;
		case Calculator.CalculatorButtonType.MR:
			result = "MR";
			break;
		case Calculator.CalculatorButtonType.MS:
			result = "MS";
			break;
		case Calculator.CalculatorButtonType.MSub:
			result = "M-";
			break;
		case Calculator.CalculatorButtonType.Multiply:
			result = "*";
			break;
		case Calculator.CalculatorButtonType.Nine:
			result = "9";
			break;
		case Calculator.CalculatorButtonType.One:
			result = "1";
			break;
		case Calculator.CalculatorButtonType.Percent:
			result = "%";
			break;
		case Calculator.CalculatorButtonType.Seven:
			result = "7";
			break;
		case Calculator.CalculatorButtonType.Negate:
			result = "+/-";
			break;
		case Calculator.CalculatorButtonType.Six:
			result = "6";
			break;
		case Calculator.CalculatorButtonType.Sqrt:
			result = "Sqrt";
			break;
		case Calculator.CalculatorButtonType.Subtract:
			result = "-";
			break;
		case Calculator.CalculatorButtonType.Three:
			result = "3";
			break;
		case Calculator.CalculatorButtonType.Two:
			result = "2";
			break;
		case Calculator.CalculatorButtonType.Zero:
			result = "0";
			break;
		}
		return result;
	}

	public static bool IsDigit(Calculator.CalculatorButtonType buttonType)
	{
		switch (buttonType)
		{
		case Calculator.CalculatorButtonType.Decimal:
		case Calculator.CalculatorButtonType.Eight:
		case Calculator.CalculatorButtonType.Five:
		case Calculator.CalculatorButtonType.Four:
		case Calculator.CalculatorButtonType.Nine:
		case Calculator.CalculatorButtonType.One:
		case Calculator.CalculatorButtonType.Seven:
		case Calculator.CalculatorButtonType.Six:
		case Calculator.CalculatorButtonType.Three:
		case Calculator.CalculatorButtonType.Two:
		case Calculator.CalculatorButtonType.Zero:
			return true;
		default:
			return false;
		}
	}

	public static bool IsMemory(Calculator.CalculatorButtonType buttonType)
	{
		switch (buttonType)
		{
		case Calculator.CalculatorButtonType.MAdd:
		case Calculator.CalculatorButtonType.MC:
		case Calculator.CalculatorButtonType.MR:
		case Calculator.CalculatorButtonType.MS:
		case Calculator.CalculatorButtonType.MSub:
			return true;
		default:
			return false;
		}
	}

	public static decimal ParseDecimal(string text)
	{
		return decimal.Parse(text, CultureInfo.CurrentCulture);
	}

	public static decimal Add(decimal firstNumber, decimal secondNumber)
	{
		return firstNumber + secondNumber;
	}

	public static decimal Subtract(decimal firstNumber, decimal secondNumber)
	{
		return firstNumber - secondNumber;
	}

	public static decimal Multiply(decimal firstNumber, decimal secondNumber)
	{
		return firstNumber * secondNumber;
	}

	public static decimal Divide(decimal firstNumber, decimal secondNumber)
	{
		return firstNumber / secondNumber;
	}

	public static decimal Percent(decimal firstNumber, decimal secondNumber)
	{
		return firstNumber * secondNumber / 100m;
	}

	public static decimal SquareRoot(decimal operand)
	{
		return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(operand)));
	}

	public static decimal Fraction(decimal operand)
	{
		return 1m / operand;
	}

	public static decimal Negate(decimal operand)
	{
		return operand * -1m;
	}
}
