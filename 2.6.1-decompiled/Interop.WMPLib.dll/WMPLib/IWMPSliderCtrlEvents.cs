using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(2)]
[Guid("CDAC14D2-8BE4-11D3-BB48-00A0C93CA73A")]
[TypeLibType(4096)]
public interface IWMPSliderCtrlEvents
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5430)]
	void ondragbegin();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5431)]
	void ondragend();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5432)]
	void onpositionchange();
}
