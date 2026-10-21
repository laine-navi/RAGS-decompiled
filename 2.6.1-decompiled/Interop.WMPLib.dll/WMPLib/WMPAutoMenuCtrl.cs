using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("1AD13E0B-4F3A-41DF-9BE2-F9E6FE0A7875")]
[CoClass(typeof(WMPAutoMenuCtrlClass))]
public interface WMPAutoMenuCtrl : IWMPAutoMenuCtrl
{
}
