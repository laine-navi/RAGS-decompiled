using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("F118EFC7-F03A-4FB4-99C9-1C02A5C1065B")]
[TypeLibType(4160)]
public interface IWMPMedia3 : IWMPMedia2
{
	// C# has no syntax for parameterized property 'isIdentical'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(763)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(763)]
	bool get_isIdentical([In][MarshalAs(UnmanagedType.Interface)] IWMPMedia pIWMPMedia);

	[DispId(751)]
	new string sourceURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(751)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(764)]
	new string name
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
	new int imageSourceWidth
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(752)]
		get;
	}

	[DispId(753)]
	new int imageSourceHeight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(753)]
		get;
	}

	[DispId(754)]
	new int markerCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(754)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(755)]
	new double getMarkerTime([In] int MarkerNum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(756)]
	[return: MarshalAs(UnmanagedType.BStr)]
	new string getMarkerName([In] int MarkerNum);

	[DispId(757)]
	new double duration
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(757)]
		get;
	}

	[DispId(758)]
	new string durationString
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(758)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(759)]
	new int attributeCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(759)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(760)]
	[return: MarshalAs(UnmanagedType.BStr)]
	new string getAttributeName([In] int lIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(761)]
	[return: MarshalAs(UnmanagedType.BStr)]
	new string getItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(762)]
	new void setItemInfo([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName, [In][MarshalAs(UnmanagedType.BStr)] string bstrVal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(765)]
	[return: MarshalAs(UnmanagedType.BStr)]
	new string getItemInfoByAtom([In] int lAtom);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(766)]
	new bool isMemberOf([In][MarshalAs(UnmanagedType.Interface)] IWMPPlaylist pPlaylist);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(767)]
	new bool isReadOnlyItem([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[DispId(768)]
	new IWMPErrorItem Error
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(768)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(769)]
	int getAttributeCountByType([In][MarshalAs(UnmanagedType.BStr)] string bstrType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLanguage);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(770)]
	[return: MarshalAs(UnmanagedType.Struct)]
	object getItemInfoByType([In][MarshalAs(UnmanagedType.BStr)] string bstrType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLanguage, [In] int lIndex);
}
