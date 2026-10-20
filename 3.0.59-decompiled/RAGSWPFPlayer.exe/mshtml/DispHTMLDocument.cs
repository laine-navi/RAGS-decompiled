using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mshtml;

[ComImport]
[TypeIdentifier]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
[Guid("3050F55F-98B5-11CF-BB82-00AA00BDCE0B")]
[CompilerGenerated]
public interface DispHTMLDocument
{
	virtual void _VtblGap1_101();

	IHTMLWindow2 parentWindow
	{
		[PreserveSig]
		[DispId(1034)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
