using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPPlaylistCtrlClass))]
[Guid("5F9CFD92-8CAD-11D3-9A7E-00C04F8EFB70")]
public interface WMPPlaylistCtrl : IWMPPlaylistCtrl
{
}
