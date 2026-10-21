using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[ClassInterface(0)]
[Guid("6B28F900-8D64-4B80-9963-CC52DDD1FBB4")]
public class WMPAutoMenuCtrlClass : IWMPAutoMenuCtrl, WMPAutoMenuCtrl
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6501)]
	public virtual extern void show([In][MarshalAs(UnmanagedType.BStr)] string newVal);
}
