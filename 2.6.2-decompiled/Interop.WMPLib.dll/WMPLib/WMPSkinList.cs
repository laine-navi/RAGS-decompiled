using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPSkinListClass))]
[Guid("8CEA03A2-D0C5-4E97-9C38-A676A639A51D")]
public interface WMPSkinList : IWMPSkinList
{
}
