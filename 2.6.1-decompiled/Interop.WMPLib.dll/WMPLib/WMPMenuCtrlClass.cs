using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("BAB3768B-8883-4AEC-9F9B-E14C947913EF")]
[ClassInterface(0)]
public class WMPMenuCtrlClass : IWMPMenuCtrl, WMPMenuCtrl
{
	[DispId(6307)]
	public virtual extern int showFlags
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6307)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6307)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6301)]
	public virtual extern void deleteAllItems();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6302)]
	public virtual extern void appendItem([In] int nID, [In][MarshalAs(UnmanagedType.BStr)] string bstrItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6303)]
	public virtual extern void appendSeparator();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6304)]
	public virtual extern void enableItem([In] int nID, [In] bool newVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6305)]
	public virtual extern void checkItem([In] int nID, [In] bool newVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6306)]
	public virtual extern void checkRadioItem([In] int nID, [In] bool newVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6308)]
	public virtual extern int show();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6309)]
	public virtual extern void showEx([In] int nID);
}
