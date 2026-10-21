using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("6C497D62-8919-413C-82DB-E935FB3EC584")]
[CoClass(typeof(WindowsMediaPlayerClass))]
public interface WindowsMediaPlayer : IWMPPlayer4, _WMPOCXEvents_Event
{
}
