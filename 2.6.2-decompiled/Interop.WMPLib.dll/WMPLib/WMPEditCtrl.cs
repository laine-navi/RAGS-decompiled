using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("70E1217C-C617-4CFD-BD8A-69CA2043E70B")]
[CoClass(typeof(WMPEditCtrlClass))]
public interface WMPEditCtrl : IWMPEditCtrl
{
}
