using System;
using System.Windows.Media;
using Microsoft.Win32;

namespace Xceed.Wpf.Toolkit.Core.Media;

public static class WindowColors
{
	private static Color? _colorizationMode;

	private static bool? _colorizationOpaqueBlend;

	public static Color ColorizationColor
	{
		get
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			if (_colorizationMode.HasValue)
			{
				return _colorizationMode.Value;
			}
			try
			{
				_colorizationMode = GetDWMColorValue("ColorizationColor");
			}
			catch
			{
				_colorizationMode = Color.FromArgb(byte.MaxValue, (byte)175, (byte)175, (byte)175);
			}
			return _colorizationMode.Value;
		}
	}

	public static bool ColorizationOpaqueBlend
	{
		get
		{
			if (_colorizationOpaqueBlend.HasValue)
			{
				return _colorizationOpaqueBlend.Value;
			}
			try
			{
				_colorizationOpaqueBlend = GetDWMBoolValue("ColorizationOpaqueBlend");
			}
			catch
			{
				_colorizationOpaqueBlend = false;
			}
			return _colorizationOpaqueBlend.Value;
		}
	}

	private static int GetDWMIntValue(string keyName)
	{
		RegistryKey currentUser = Registry.CurrentUser;
		RegistryKey registryKey = currentUser.CreateSubKey("Software\\Microsoft\\Windows\\DWM", RegistryKeyPermissionCheck.ReadSubTree, RegistryOptions.None);
		return (int)registryKey.GetValue(keyName);
	}

	private static Color GetDWMColorValue(string keyName)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		int dWMIntValue = GetDWMIntValue(keyName);
		byte[] bytes = BitConverter.GetBytes(dWMIntValue);
		Color result = default;
		result.B = bytes[0];
		result.G = bytes[1];
		result.R = bytes[2];
		result.A = byte.MaxValue;
		return result;
	}

	private static bool GetDWMBoolValue(string keyName)
	{
		int dWMIntValue = GetDWMIntValue(keyName);
		return dWMIntValue != 0;
	}
}
