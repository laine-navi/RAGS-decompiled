using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public class ZoomboxCursors
{
	private static readonly Cursor _zoom;

	private static readonly Cursor _zoomRelative;

	public static Cursor Zoom => _zoom;

	public static Cursor ZoomRelative => _zoomRelative;

	static ZoomboxCursors()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		_zoom = Cursors.Arrow;
		_zoomRelative = Cursors.Arrow;
		try
		{
			((CodeAccessPermission)new EnvironmentPermission(PermissionState.Unrestricted)).Demand();
			_zoom = new Cursor(ResourceHelper.LoadResourceStream(Assembly.GetExecutingAssembly(), "Zoombox/Resources/Zoom.cur"));
			_zoomRelative = new Cursor(ResourceHelper.LoadResourceStream(Assembly.GetExecutingAssembly(), "Zoombox/Resources/ZoomRelative.cur"));
		}
		catch (SecurityException)
		{
		}
	}
}
