using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPListBoxCtrlClass))]
[Guid("FC1880CE-83B9-43A7-A066-C44CE8C82583")]
public interface WMPListBoxCtrl : IWMPListBoxCtrl
{
}
