using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("BB17FFF7-1692-4555-918A-6AF7BFACEDD2")]
[InterfaceType(2)]
[TypeLibType(4096)]
public interface IWMPButtonCtrlEvents
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5120)]
	void onclick();
}
