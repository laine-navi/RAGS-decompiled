using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("9FBB3336-6DA3-479D-B8FF-67D46E20A987")]
[TypeLibType(4160)]
public interface IWMPDownloadItem2 : IWMPDownloadItem
{
	[DispId(1251)]
	new string sourceURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1251)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1252)]
	new int size
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1252)]
		get;
	}

	[DispId(1253)]
	new string type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1253)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1254)]
	new int progress
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1254)]
		get;
	}

	[DispId(1255)]
	new WMPSubscriptionDownloadState downloadState
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1255)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1256)]
	new void pause();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1257)]
	new void resume();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1258)]
	new void cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1301)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);
}
