using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("F8578BFA-CD8F-4CE1-A684-5B7E85FCA7DC")]
public interface IBattery
{
	[DispId(1)]
	int presetCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		get;
	}

	// C# has no syntax for parameterized property 'preset'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(2)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object get_preset([In] int nIndex);
}
