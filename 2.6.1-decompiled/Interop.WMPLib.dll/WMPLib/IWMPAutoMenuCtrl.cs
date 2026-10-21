using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("1AD13E0B-4F3A-41DF-9BE2-F9E6FE0A7875")]
[TypeLibType(4160)]
public interface IWMPAutoMenuCtrl
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6501)]
	void show([In][MarshalAs(UnmanagedType.BStr)] string newVal);
}
