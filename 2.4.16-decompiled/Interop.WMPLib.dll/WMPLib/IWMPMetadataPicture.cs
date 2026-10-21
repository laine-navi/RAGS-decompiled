using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("5C29BBE0-F87D-4C45-AA28-A70F0230FFA9")]
public interface IWMPMetadataPicture
{
	[DispId(1051)]
	string mimeType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1051)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1052)]
	string pictureType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1052)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1053)]
	string Description
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1053)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1054)]
	string URL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1054)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}
}
