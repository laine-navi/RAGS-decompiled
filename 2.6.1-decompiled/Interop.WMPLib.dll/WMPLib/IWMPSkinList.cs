using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("8CEA03A2-D0C5-4E97-9C38-A676A639A51D")]
public interface IWMPSkinList
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6050)]
	void updateBasketColumns();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6051)]
	void highContrastChange();
}
