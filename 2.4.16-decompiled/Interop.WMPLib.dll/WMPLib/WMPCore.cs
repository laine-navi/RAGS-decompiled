using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPCoreClass))]
[Guid("7587C667-628F-499F-88E7-6A6F4E888464")]
public interface WMPCore : IWMPCore3, _WMPCoreEvents_Event
{
}
