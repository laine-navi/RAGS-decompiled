using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace RagsDesigner.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings a = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => a;

	[DefaultSettingValue("http://ragsgame.com/CheckUpdates.asmx")]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string RagsDesigner_com_ragsgame_www_CheckUpdates => (string)((SettingsBase)this)["RagsDesigner_com_ragsgame_www_CheckUpdates"];

	[UserScopedSetting]
	[DefaultSettingValue("0, 0")]
	[DebuggerNonUserCode]
	public Point Location
	{
		get
		{
			return (Point)((SettingsBase)this)["Location"];
		}
		set
		{
			((SettingsBase)this)["Location"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0, 0")]
	public Size Size
	{
		get
		{
			return (Size)((SettingsBase)this)["Size"];
		}
		set
		{
			((SettingsBase)this)["Size"] = value;
		}
	}

	[DefaultSettingValue("Normal")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public FormWindowState State
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (FormWindowState)((SettingsBase)this)["State"];
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((SettingsBase)this)["State"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	[UserScopedSetting]
	public bool CheckForUpdates
	{
		get
		{
			return (bool)((SettingsBase)this)["CheckForUpdates"];
		}
		set
		{
			((SettingsBase)this)["CheckForUpdates"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	[UserScopedSetting]
	public bool RunGameCheckOnSave
	{
		get
		{
			return (bool)((SettingsBase)this)["RunGameCheckOnSave"];
		}
		set
		{
			((SettingsBase)this)["RunGameCheckOnSave"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	[UserScopedSetting]
	public bool displayNewGameDialogAtStartup
	{
		get
		{
			return (bool)((SettingsBase)this)["displayNewGameDialogAtStartup"];
		}
		set
		{
			((SettingsBase)this)["displayNewGameDialogAtStartup"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int Splitcontainer2
	{
		get
		{
			return (int)((SettingsBase)this)["Splitcontainer2"];
		}
		set
		{
			((SettingsBase)this)["Splitcontainer2"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int Splitter2Height
	{
		get
		{
			return (int)((SettingsBase)this)["Splitter2Height"];
		}
		set
		{
			((SettingsBase)this)["Splitter2Height"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int Splitter3Height
	{
		get
		{
			return (int)((SettingsBase)this)["Splitter3Height"];
		}
		set
		{
			((SettingsBase)this)["Splitter3Height"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("0")]
	[DebuggerNonUserCode]
	public int Splitcontainer4
	{
		get
		{
			return (int)((SettingsBase)this)["Splitcontainer4"];
		}
		set
		{
			((SettingsBase)this)["Splitcontainer4"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int Splitcontainer5
	{
		get
		{
			return (int)((SettingsBase)this)["Splitcontainer5"];
		}
		set
		{
			((SettingsBase)this)["Splitcontainer5"] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	[UserScopedSetting]
	public int Splitcontainer6
	{
		get
		{
			return (int)((SettingsBase)this)["Splitcontainer6"];
		}
		set
		{
			((SettingsBase)this)["Splitcontainer6"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int Splitcontainer7
	{
		get
		{
			return (int)((SettingsBase)this)["Splitcontainer7"];
		}
		set
		{
			((SettingsBase)this)["Splitcontainer7"] = value;
		}
	}
}
