using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("46AD648D-53F1-4A74-92E2-2A1B68D63FD4")]
public interface IWMPStringCollection2 : IWMPStringCollection
{
	[DispId(401)]
	new int count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(401)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(402)]
	[return: MarshalAs(UnmanagedType.BStr)]
	new string Item([In] int lIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1451)]
	bool isIdentical([In][MarshalAs(UnmanagedType.Interface)] IWMPStringCollection2 pIWMPStringCollection2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1452)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string getItemInfo([In] int lCollectionIndex, [In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1453)]
	int getAttributeCountByType([In] int lCollectionIndex, [In][MarshalAs(UnmanagedType.BStr)] string bstrType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLanguage);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1454)]
	[return: MarshalAs(UnmanagedType.Struct)]
	object getItemInfoByType([In] int lCollectionIndex, [In][MarshalAs(UnmanagedType.BStr)] string bstrType, [In][MarshalAs(UnmanagedType.BStr)] string bstrLanguage, [In] int lAttributeIndex);
}
