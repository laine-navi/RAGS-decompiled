using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPLibraryTreeCtrlClass))]
[Guid("B738FCAE-F089-45DF-AED6-034B9E7DB632")]
public interface WMPLibraryTreeCtrl : IWMPLibraryTreeCtrl
{
}
