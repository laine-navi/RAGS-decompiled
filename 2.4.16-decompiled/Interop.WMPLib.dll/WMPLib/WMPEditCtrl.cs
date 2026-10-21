using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[CoClass(typeof(WMPEditCtrlClass))]
[Guid("70E1217C-C617-4CFD-BD8A-69CA2043E70B")]
public interface WMPEditCtrl : IWMPEditCtrl
{
}
