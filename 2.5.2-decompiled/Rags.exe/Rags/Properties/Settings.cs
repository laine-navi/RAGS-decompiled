using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rags.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings a = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => a;

	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("http://www.ragsgame.com/CheckUpdates.asmx")]
	public string Rags_ragsgame_com_CheckUpdates => (string)((SettingsBase)this)["Rags_ragsgame_com_CheckUpdates"];
}
