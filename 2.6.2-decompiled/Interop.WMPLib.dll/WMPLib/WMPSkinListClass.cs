using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("A8A55FAC-82EA-4BD7-BD7B-11586A4D99E4")]
[ClassInterface(0)]
public class WMPSkinListClass : IWMPSkinList, WMPSkinList
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6050)]
	public virtual extern void updateBasketColumns();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6051)]
	public virtual extern void highContrastChange();
}
