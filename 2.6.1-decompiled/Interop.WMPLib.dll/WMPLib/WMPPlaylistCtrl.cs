using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("5F9CFD92-8CAD-11D3-9A7E-00C04F8EFB70")]
[CoClass(typeof(WMPPlaylistCtrlClass))]
public interface WMPPlaylistCtrl : IWMPPlaylistCtrl
{
}
