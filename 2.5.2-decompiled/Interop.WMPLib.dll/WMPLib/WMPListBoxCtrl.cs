using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("FC1880CE-83B9-43A7-A066-C44CE8C82583")]
[CoClass(typeof(WMPListBoxCtrlClass))]
public interface WMPListBoxCtrl : IWMPListBoxCtrl
{
}
