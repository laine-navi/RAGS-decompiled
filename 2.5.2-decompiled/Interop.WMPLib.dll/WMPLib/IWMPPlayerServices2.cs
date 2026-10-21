using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("1BB1592F-F040-418A-9F71-17C7512B4D70")]
[InterfaceType(1)]
public interface IWMPPlayerServices2 : IWMPPlayerServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void activateUIPlugin([In][MarshalAs(UnmanagedType.BStr)] string bstrPlugin);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void setTaskPane([In][MarshalAs(UnmanagedType.BStr)] string bstrTaskPane);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void setTaskPaneURL([In][MarshalAs(UnmanagedType.BStr)] string bstrTaskPane, [In][MarshalAs(UnmanagedType.BStr)] string bstrURL, [In][MarshalAs(UnmanagedType.BStr)] string bstrFriendlyName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void setBackgroundProcessingPriority([In][MarshalAs(UnmanagedType.BStr)] string bstrPriority);
}
