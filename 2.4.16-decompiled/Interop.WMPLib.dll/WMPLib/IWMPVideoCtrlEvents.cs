using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(2)]
[TypeLibType(4096)]
[Guid("A85C0477-714C-4A06-B9F6-7C8CA38B45DC")]
public interface IWMPVideoCtrlEvents
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5720)]
	void onvideostart();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5721)]
	void onvideoend();
}
