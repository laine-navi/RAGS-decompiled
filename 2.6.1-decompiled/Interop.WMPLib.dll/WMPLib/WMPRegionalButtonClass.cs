using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[ClassInterface(0)]
[ComSourceInterfaces("WMPLib.IWMPRegionalButtonEvents\0\0")]
[Guid("09AEFF11-69EF-11D3-BD4D-00C04F6EA5AE")]
public class WMPRegionalButtonClass : IWMPRegionalButton, WMPRegionalButton, IWMPRegionalButtonEvents_Event
{
	[DispId(5330)]
	public virtual extern string upToolTip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5330)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5330)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5331)]
	public virtual extern string downToolTip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5331)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5331)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5332)]
	public virtual extern string mappingColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5332)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5332)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5333)]
	public virtual extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5333)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5333)]
		[param: In]
		set;
	}

	[DispId(5339)]
	public virtual extern bool sticky
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5339)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5339)]
		[param: In]
		set;
	}

	[DispId(5340)]
	public virtual extern bool down
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5340)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5340)]
		[param: In]
		set;
	}

	[DispId(5341)]
	public virtual extern int index
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5341)]
		get;
	}

	[DispId(5342)]
	public virtual extern bool tabStop
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5342)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5342)]
		[param: In]
		set;
	}

	[DispId(5343)]
	public virtual extern string cursor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5343)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5343)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5345)]
	public virtual extern string accName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5345)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5345)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5346)]
	public virtual extern string accDescription
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5346)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5346)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5347)]
	public virtual extern string accKeyboardShortcut
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5347)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5347)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	public virtual extern event IWMPRegionalButtonEvents_onblurEventHandler onblur;

	public virtual extern event IWMPRegionalButtonEvents_onfocusEventHandler onfocus;

	public virtual extern event IWMPRegionalButtonEvents_onclickEventHandler onclick;

	public virtual extern event IWMPRegionalButtonEvents_ondblclickEventHandler ondblclick;

	public virtual extern event IWMPRegionalButtonEvents_onmousedownEventHandler onmousedown;

	public virtual extern event IWMPRegionalButtonEvents_onmouseupEventHandler onmouseup;

	public virtual extern event IWMPRegionalButtonEvents_onmousemoveEventHandler onmousemove;

	public virtual extern event IWMPRegionalButtonEvents_onmouseoverEventHandler onmouseover;

	public virtual extern event IWMPRegionalButtonEvents_onmouseoutEventHandler onmouseout;

	public virtual extern event IWMPRegionalButtonEvents_onkeypressEventHandler onkeypress;

	public virtual extern event IWMPRegionalButtonEvents_onkeydownEventHandler onkeydown;

	public virtual extern event IWMPRegionalButtonEvents_onkeyupEventHandler onkeyup;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5344)]
	public virtual extern void Click();
}
