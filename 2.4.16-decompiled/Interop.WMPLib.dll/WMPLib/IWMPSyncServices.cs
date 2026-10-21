using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(256)]
[Guid("8B5050FF-E0A4-4808-B3A8-893A9E1ED894")]
[InterfaceType(1)]
public interface IWMPSyncServices
{
	[DispId(1610678272)]
	int deviceCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPSyncDevice getDevice([In] int lIndex);
}
