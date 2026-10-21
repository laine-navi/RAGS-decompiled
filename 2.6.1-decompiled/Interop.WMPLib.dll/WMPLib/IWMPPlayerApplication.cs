using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("40897764-CEAB-47BE-AD4A-8E28537F9BBF")]
[TypeLibType(4160)]
public interface IWMPPlayerApplication
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1101)]
	void switchToPlayerApplication();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1102)]
	void switchToControl();

	[DispId(1103)]
	bool playerDocked
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1103)]
		get;
	}

	[DispId(1104)]
	bool hasDisplay
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1104)]
		get;
	}
}
