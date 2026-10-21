using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("93EB32F5-87B1-45AD-ACC6-0F2483DB83BB")]
[ClassInterface(0)]
public class WMPEqualizerSettingsCtrlClass : IWMPEqualizerSettingsCtrl, WMPEqualizerSettingsCtrl
{
	[DispId(5800)]
	public virtual extern bool bypass
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5800)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5800)]
		[param: In]
		set;
	}

	[DispId(5804)]
	public virtual extern float gainLevel1
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5804)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5804)]
		[param: In]
		set;
	}

	[DispId(5805)]
	public virtual extern float gainLevel2
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5805)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5805)]
		[param: In]
		set;
	}

	[DispId(5806)]
	public virtual extern float gainLevel3
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5806)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5806)]
		[param: In]
		set;
	}

	[DispId(5807)]
	public virtual extern float gainLevel4
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5807)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5807)]
		[param: In]
		set;
	}

	[DispId(5808)]
	public virtual extern float gainLevel5
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5808)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5808)]
		[param: In]
		set;
	}

	[DispId(5809)]
	public virtual extern float gainLevel6
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5809)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5809)]
		[param: In]
		set;
	}

	[DispId(5810)]
	public virtual extern float gainLevel7
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5810)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5810)]
		[param: In]
		set;
	}

	[DispId(5811)]
	public virtual extern float gainLevel8
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5811)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5811)]
		[param: In]
		set;
	}

	[DispId(5812)]
	public virtual extern float gainLevel9
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5812)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5812)]
		[param: In]
		set;
	}

	[DispId(5813)]
	public virtual extern float gainLevel10
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5813)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5813)]
		[param: In]
		set;
	}

	// C# has no syntax for parameterized property 'gainLevels'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(5815)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5815)]
	public virtual extern float get_gainLevels([In] int iIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5815)]
	public virtual extern void set_gainLevels([In] int iIndex, [In] float pflLevel);

	[DispId(5801)]
	public virtual extern int bands
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5801)]
		get;
	}

	[DispId(5818)]
	public virtual extern int currentPreset
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5818)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5818)]
		[param: In]
		set;
	}

	[DispId(5819)]
	public virtual extern string currentPresetTitle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5819)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5820)]
	public virtual extern int presetCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5820)]
		get;
	}

	[DispId(5821)]
	public virtual extern bool enhancedAudio
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5821)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5821)]
		[param: In]
		set;
	}

	[DispId(5822)]
	public virtual extern int speakerSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5822)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5822)]
		[param: In]
		set;
	}

	[DispId(5823)]
	public virtual extern string currentSpeakerName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5823)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5824)]
	public virtual extern int truBassLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5824)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5824)]
		[param: In]
		set;
	}

	[DispId(5825)]
	public virtual extern int wowLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5825)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5825)]
		[param: In]
		set;
	}

	[DispId(5827)]
	public virtual extern float splineTension
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5827)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5827)]
		[param: In]
		set;
	}

	[DispId(5826)]
	public virtual extern bool enableSplineTension
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5826)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5826)]
		[param: In]
		set;
	}

	// C# has no syntax for parameterized property 'presetTitle'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(5828)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5828)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string get_presetTitle([In] int iIndex);

	[DispId(5829)]
	public virtual extern bool normalization
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5829)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5829)]
		[param: In]
		set;
	}

	[DispId(5830)]
	public virtual extern float normalizationAverage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5830)]
		get;
	}

	[DispId(5831)]
	public virtual extern float normalizationPeak
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5831)]
		get;
	}

	[DispId(5832)]
	public virtual extern bool crossFade
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5832)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5832)]
		[param: In]
		set;
	}

	[DispId(5833)]
	public virtual extern int crossFadeWindow
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5833)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5833)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5814)]
	public virtual extern void reset();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5816)]
	public virtual extern void nextPreset();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5817)]
	public virtual extern void previousPreset();
}
