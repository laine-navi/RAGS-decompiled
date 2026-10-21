using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("94D55E95-3FAC-11D3-B155-00C04F79FAA6")]
public interface IWMPMedia
{
	// C# has no syntax for parameterized property 'isIdentical'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(763)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(763)]
	bool get_isIdentical([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pIWMPMedia);

	[DispId(751)]
	string sourceURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(751)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(764)]
	string name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(764)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(764)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(752)]
	int imageSourceWidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(752)]
		get;
	}

	[DispId(753)]
	int imageSourceHeight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(753)]
		get;
	}

	[DispId(754)]
	int markerCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(754)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(755)]
	double getMarkerTime([In] int MarkerNum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(756)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getMarkerName([In] int MarkerNum);

	[DispId(757)]
	double duration
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(757)]
		get;
	}

	[DispId(758)]
	string durationString
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(758)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(759)]
	int attributeCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(759)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(760)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getAttributeName([In] int lIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(761)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(762)]
	void setItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName, [In][MarshalAs(UnmanagedType.BStr)] string bstrVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(765)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getItemInfoByAtom([In] int lAtom);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(766)]
	bool isMemberOf([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pPlaylist);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(767)]
	bool isReadOnlyItem([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);
}
