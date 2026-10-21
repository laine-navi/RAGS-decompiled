using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("8DA61686-4668-4A5C-AE5D-803193293DBE")]
public interface IWMPDVD
{
	// C# has no syntax for parameterized property 'isAvailable'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(1001)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1001)]
	bool get_isAvailable([In][MarshalAs(UnmanagedType.BStr)] string bstrItem);

	[DispId(1002)]
	string domain
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1002)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1003)]
	void topMenu();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1004)]
	void titleMenu();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1005)]
	void back();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1006)]
	void resume();
}
