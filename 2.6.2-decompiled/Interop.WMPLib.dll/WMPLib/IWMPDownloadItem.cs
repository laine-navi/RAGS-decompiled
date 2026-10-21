using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("C9470E8E-3F6B-46A9-A0A9-452815C34297")]
public interface IWMPDownloadItem
{
	[DispId(1251)]
	string sourceURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1251)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1252)]
	int size
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1252)]
		get;
	}

	[DispId(1253)]
	string type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1253)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1254)]
	int progress
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1254)]
		get;
	}

	[DispId(1255)]
	WMPSubscriptionDownloadState downloadState
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1255)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1256)]
	void pause();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1257)]
	void resume();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1258)]
	void cancel();
}
