using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Xceed.Wpf.Toolkit;

internal class DateTimeParser
{
	public static bool TryParse(string value, string format, DateTime currentDate, CultureInfo cultureInfo, out DateTime result)
	{
		bool flag = false;
		result = currentDate;
		if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(format))
		{
			return false;
		}
		string text = ComputeDateTimeString(value, format, currentDate, cultureInfo).Trim();
		if (!string.IsNullOrEmpty(text))
		{
			flag = DateTime.TryParse(text, cultureInfo.DateTimeFormat, DateTimeStyles.None, out result);
		}
		if (!flag)
		{
			result = currentDate;
		}
		return flag;
	}

	private static string ComputeDateTimeString(string dateTime, string format, DateTime currentDate, CultureInfo cultureInfo)
	{
		Dictionary<string, string> dateParts = GetDateParts(currentDate, cultureInfo);
		string[] array = new string[3]
		{
			currentDate.Hour.ToString(),
			currentDate.Minute.ToString(),
			currentDate.Second.ToString()
		};
		string text = currentDate.Millisecond.ToString();
		string arg = "";
		string[] separator = new string[7]
		{
			",",
			" ",
			"-",
			".",
			"/",
			cultureInfo.DateTimeFormat.DateSeparator,
			cultureInfo.DateTimeFormat.TimeSeparator
		};
		UpdateSortableDateTimeString(ref dateTime, ref format, cultureInfo);
		List<string> list = dateTime.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
		List<string> list2 = format.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
		if (list.Count != list2.Count)
		{
			return string.Empty;
		}
		for (int i = 0; i < list2.Count; i++)
		{
			string text2 = list2[i];
			if (text2.Contains("ddd") || text2.Contains("GMT"))
			{
				continue;
			}
			if (text2.Contains("M"))
			{
				dateParts["Month"] = list[i];
			}
			else if (text2.Contains("d"))
			{
				dateParts["Day"] = list[i];
			}
			else if (text2.Contains("y"))
			{
				dateParts["Year"] = list[i];
				if (dateParts["Year"].Length == 2)
				{
					dateParts["Year"] = string.Format("{0}{1}", currentDate.Year / 100, dateParts["Year"]);
				}
			}
			else if (text2.Contains("h") || text2.Contains("H"))
			{
				array[0] = list[i];
			}
			else if (text2.Contains("m"))
			{
				array[1] = list[i];
			}
			else if (text2.Contains("s"))
			{
				array[2] = list[i];
			}
			else if (text2.Contains("f"))
			{
				text = list[i];
			}
			else if (text2.Contains("t"))
			{
				arg = list[i];
			}
		}
		string arg2 = string.Join(cultureInfo.DateTimeFormat.DateSeparator, dateParts.Select((KeyValuePair<string, string> x) => x.Value).ToArray());
		string text3 = string.Join(cultureInfo.DateTimeFormat.TimeSeparator, array);
		text3 = text3 + "." + text;
		return $"{arg2} {text3} {arg}";
	}

	private static void UpdateSortableDateTimeString(ref string dateTime, ref string format, CultureInfo cultureInfo)
	{
		if (format == cultureInfo.DateTimeFormat.SortableDateTimePattern)
		{
			format = format.Replace("'", "").Replace("T", " ");
			dateTime = dateTime.Replace("'", "").Replace("T", " ");
		}
		else if (format == cultureInfo.DateTimeFormat.UniversalSortableDateTimePattern)
		{
			format = format.Replace("'", "").Replace("Z", "");
			dateTime = dateTime.Replace("'", "").Replace("Z", "");
		}
	}

	private static Dictionary<string, string> GetDateParts(DateTime currentDate, CultureInfo cultureInfo)
	{
		Dictionary<string, string> dateParts = new Dictionary<string, string>();
		string[] separator = new string[7]
		{
			",",
			" ",
			"-",
			".",
			"/",
			cultureInfo.DateTimeFormat.DateSeparator,
			cultureInfo.DateTimeFormat.TimeSeparator
		};
		List<string> list = cultureInfo.DateTimeFormat.ShortDatePattern.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
		list.ForEach((string item) =>
		{
			string key = string.Empty;
			string value = string.Empty;
			if (item.Contains("M"))
			{
				key = "Month";
				value = currentDate.Month.ToString();
			}
			else if (item.Contains("d"))
			{
				key = "Day";
				value = currentDate.Day.ToString();
			}
			else if (item.Contains("y"))
			{
				key = "Year";
				value = currentDate.Year.ToString("D4");
			}
			dateParts.Add(key, value);
		});
		return dateParts;
	}
}
