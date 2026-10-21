using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("D255DFB8-C22A-42CF-B8B7-F15D7BCF65D6")]
public interface IWMPListBoxItem
{
	[DispId(6119)]
	string value
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6119)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}
}
