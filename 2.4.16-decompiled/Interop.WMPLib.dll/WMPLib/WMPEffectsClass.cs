using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("47DEA830-D619-4154-B8D8-6B74845D6A2D")]
[ClassInterface(0)]
public class WMPEffectsClass : IWMPEffectsCtrl, WMPEffects
{
	[DispId(5500)]
	public virtual extern bool windowed
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5500)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5500)]
		[param: In]
		set;
	}

	[DispId(5501)]
	public virtual extern bool allowAll
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5501)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5501)]
		[param: In]
		set;
	}

	[DispId(5507)]
	public virtual extern string currentEffectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5507)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5507)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(5506)]
	public virtual extern string currentEffectTitle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5506)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5505)]
	public virtual extern object currentEffect
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5505)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5505)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(5513)]
	public virtual extern int currentPreset
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5513)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5513)]
		[param: In]
		set;
	}

	[DispId(5514)]
	public virtual extern string currentPresetTitle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5514)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5515)]
	public virtual extern int currentEffectPresetCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5515)]
		get;
	}

	[DispId(5516)]
	public virtual extern bool fullScreen
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5516)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5516)]
		[param: In]
		set;
	}

	[DispId(5517)]
	public virtual extern bool effectCanGoFullScreen
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5517)]
		get;
	}

	[DispId(5518)]
	public virtual extern bool effectHasPropertyPage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5518)]
		get;
	}

	[DispId(5520)]
	public virtual extern int effectCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5520)]
		get;
	}

	// C# has no syntax for parameterized property 'effectTitle'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(5521)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5521)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string get_effectTitle([In] int index);

	// C# has no syntax for parameterized property 'effectType'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(5522)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5522)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string get_effectType([In] int index);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5502)]
	public virtual extern void next();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5503)]
	public virtual extern void previous();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5504)]
	public virtual extern void settings();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5509)]
	public virtual extern void nextEffect();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5510)]
	public virtual extern void previousEffect();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5511)]
	public virtual extern void nextPreset();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5512)]
	public virtual extern void previousPreset();
}
