using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("A9EFAB80-0A60-4C3F-BBD1-4558DD2A9769")]
[CoClass(typeof(WMPEffectsClass))]
public interface WMPEffects : IWMPEffectsCtrl
{
}
