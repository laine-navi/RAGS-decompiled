using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mshtml;

[ComImport]
[CompilerGenerated]
[TypeIdentifier]
[Guid("332C4427-26CB-11D0-B483-00C04FD90119")]
[DefaultMember("item")]
public interface IHTMLWindow2 : IHTMLFramesCollection2
{
	virtual void _VtblGap1_63();

	[DispId(1167)]
	void scrollBy([In] int x, [In] int y);

	[DispId(1168)]
	void scrollTo([In] int x, [In] int y);
}
