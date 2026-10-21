using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("A00918F3-A6B0-4BFB-9189-FD834C7BC5A5")]
public interface IWMPQuery
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1351)]
	void addCondition([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribute, [In][MarshalAs(UnmanagedType.BStr)] string bstrOperator, [In][MarshalAs(UnmanagedType.BStr)] string bstrValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1352)]
	void beginNextGroup();
}
