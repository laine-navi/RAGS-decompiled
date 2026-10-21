using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("2D7EF888-1D3C-484A-A906-9F49D99BB344")]
[TypeLibType(4160)]
public interface IWMPCDDVDWizardExternal : IWMPExternalColors
{
	[DispId(10005)]
	new string version
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10005)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10012)]
	new string appColorLight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10012)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10018)]
	new object OnColorChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10018)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(10013)]
	new string appColorMedium
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10013)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10014)]
	new string appColorDark
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10014)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10015)]
	new string appColorButtonHighlight
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10015)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10016)]
	new string appColorButtonShadow
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10016)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10017)]
	new string appColorButtonHoverFace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10017)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10001)]
	void WriteNames([In][MarshalAs(UnmanagedType.BStr)] string bstrTOC, [In][MarshalAs(UnmanagedType.BStr)] string bstrMetadata);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10002)]
	void ReturnToMainTask();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10007)]
	void WriteNamesEx([In] WMP_WRITENAMESEX_TYPE type, [In][MarshalAs(UnmanagedType.BStr)] string bstrTypeId, [In][MarshalAs(UnmanagedType.BStr)] string bstrMetadata, [In] bool fRenameRegroupFiles);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10008)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string GetMDQByRequestID([In][MarshalAs(UnmanagedType.BStr)] string bstrRequestID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10011)]
	void EditMetadata();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10010)]
	bool IsMetadataAvailableForEdit();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10023)]
	void BuyCD([In][MarshalAs(UnmanagedType.BStr)] string bstrTitle, [In][MarshalAs(UnmanagedType.BStr)] string bstrArtist, [In][MarshalAs(UnmanagedType.BStr)] string bstrAlbum, [In][MarshalAs(UnmanagedType.BStr)] string bstrUFID, [In][MarshalAs(UnmanagedType.BStr)] string bstrWMID);
}
