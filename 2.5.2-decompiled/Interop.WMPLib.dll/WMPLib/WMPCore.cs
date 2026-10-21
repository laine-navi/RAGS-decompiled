using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("7587C667-628F-499F-88E7-6A6F4E888464")]
[CoClass(typeof(WMPCoreClass))]
public interface WMPCore : IWMPCore3, _WMPCoreEvents_Event
{
}
