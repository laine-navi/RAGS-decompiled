using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(2)]
[TypeLibType(4096)]
[Guid("95F45AA4-ED0A-11D2-BA67-0000F80855E6")]
public interface IWMPCustomSliderCtrlEvents
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5020)]
	void ondragbegin();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5021)]
	void ondragend();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5022)]
	void onpositionchange();
}
