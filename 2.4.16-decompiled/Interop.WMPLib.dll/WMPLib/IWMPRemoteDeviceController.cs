using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("968F36CA-CB43-4F6A-A03B-66A9C05A93EE")]
[TypeLibType(4160)]
public interface IWMPRemoteDeviceController
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10101)]
	void RegisterDeviceSwitch([In][MarshalAs(UnmanagedType.IDispatch)] object pdispJScriptFunction);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10102)]
	void SyncDeviceList();

	[DispId(10103)]
	int numberDevices
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10103)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10104)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object getDevice([In] int lIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10106)]
	void SwitchUIToMatchDevice([In][MarshalAs(UnmanagedType.IDispatch)] object pdispDevice);
}
