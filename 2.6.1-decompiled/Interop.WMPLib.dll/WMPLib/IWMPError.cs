using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("A12DCF7D-14AB-4C1B-A8CD-63909F06025B")]
[TypeLibType(4160)]
public interface IWMPError
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(851)]
	void clearErrorQueue();

	[DispId(852)]
	int errorCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(852)]
		get;
	}

	// C# has no syntax for parameterized property 'Item'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(853)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(853)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPErrorItem get_Item([In] int dwIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(854)]
	void webHelp();
}
