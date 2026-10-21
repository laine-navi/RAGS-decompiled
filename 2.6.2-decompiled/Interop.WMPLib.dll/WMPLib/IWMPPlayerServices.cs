using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(1)]
[Guid("1D01FBDB-ADE2-4C8D-9842-C190B95C3306")]
public interface IWMPPlayerServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void activateUIPlugin([In][MarshalAs(UnmanagedType.BStr)] string bstrPlugin);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void setTaskPane([In][MarshalAs(UnmanagedType.BStr)] string bstrTaskPane);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void setTaskPaneURL([In][MarshalAs(UnmanagedType.BStr)] string bstrTaskPane, [In][MarshalAs(UnmanagedType.BStr)] string bstrURL, [In][MarshalAs(UnmanagedType.BStr)] string bstrFriendlyName);
}
