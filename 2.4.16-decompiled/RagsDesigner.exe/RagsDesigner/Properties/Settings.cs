using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using A;

namespace RagsDesigner.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => defaultInstance;

	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("http://www.ragsgame.com/CheckUpdates.asmx")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string RagsDesigner_com_ragsgame_www_CheckUpdates => (string)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45885)];

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0, 0")]
	public Point Location
	{
		get
		{
			return (Point)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45970)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45970)] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("0, 0")]
	[DebuggerNonUserCode]
	public Size Size
	{
		get
		{
			return (Size)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45987)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45987)] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("Normal")]
	[UserScopedSetting]
	public FormWindowState State
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			return (FormWindowState)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45996)];
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45996)] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("True")]
	public bool CheckForUpdates
	{
		get
		{
			return (bool)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46007)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46007)] = value;
		}
	}

	[DefaultSettingValue("True")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public bool RunGameCheckOnSave
	{
		get
		{
			return (bool)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46038)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46038)] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	[UserScopedSetting]
	public bool displayNewGameDialogAtStartup
	{
		get
		{
			return (bool)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46075)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46075)] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int Splitcontainer2
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46134)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46134)] = value;
		}
	}

	[DefaultSettingValue("0")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public int Splitter2Height
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46165)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46165)] = value;
		}
	}

	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	[UserScopedSetting]
	public int Splitter3Height
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196)] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int Splitcontainer4
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227)] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("0")]
	[DebuggerNonUserCode]
	public int Splitcontainer5
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46258)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46258)] = value;
		}
	}

	[DefaultSettingValue("0")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public int Splitcontainer6
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46289)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46289)] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int Splitcontainer7
	{
		get
		{
			return (int)((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46320)];
		}
		set
		{
			((SettingsBase)this)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46320)] = value;
		}
	}
}
