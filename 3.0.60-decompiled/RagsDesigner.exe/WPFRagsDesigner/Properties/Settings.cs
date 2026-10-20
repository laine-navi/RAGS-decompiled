using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace WPFRagsDesigner.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings a = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => a;

	[DefaultSettingValue("True")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool UseAutoSave
	{
		get
		{
			return (bool)((SettingsBase)this)["UseAutoSave"];
		}
		set
		{
			((SettingsBase)this)["UseAutoSave"] = value;
		}
	}

	[DefaultSettingValue("5")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public int AutoSaveMinutes
	{
		get
		{
			return (int)((SettingsBase)this)["AutoSaveMinutes"];
		}
		set
		{
			((SettingsBase)this)["AutoSaveMinutes"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public bool AutoSaveInitiallySet
	{
		get
		{
			return (bool)((SettingsBase)this)["AutoSaveInitiallySet"];
		}
		set
		{
			((SettingsBase)this)["AutoSaveInitiallySet"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush GeneralGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["GeneralGrid"];
		}
		set
		{
			((SettingsBase)this)["GeneralGrid"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush RoomGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["RoomGrid"];
		}
		set
		{
			((SettingsBase)this)["RoomGrid"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush PlayerGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["PlayerGrid"];
		}
		set
		{
			((SettingsBase)this)["PlayerGrid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	public LinearGradientBrush ObjectGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["ObjectGrid"];
		}
		set
		{
			((SettingsBase)this)["ObjectGrid"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush CharacterGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["CharacterGrid"];
		}
		set
		{
			((SettingsBase)this)["CharacterGrid"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush VariableGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["VariableGrid"];
		}
		set
		{
			((SettingsBase)this)["VariableGrid"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public LinearGradientBrush TimerGrid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (LinearGradientBrush)((SettingsBase)this)["TimerGrid"];
		}
		set
		{
			((SettingsBase)this)["TimerGrid"] = value;
		}
	}

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string GeneralTest
	{
		get
		{
			return (string)((SettingsBase)this)["GeneralTest"];
		}
		set
		{
			((SettingsBase)this)["GeneralTest"] = value;
		}
	}
}
