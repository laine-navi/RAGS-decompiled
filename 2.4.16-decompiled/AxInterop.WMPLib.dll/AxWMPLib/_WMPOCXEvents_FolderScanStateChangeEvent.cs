using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_FolderScanStateChangeEvent
{
	public WMPFolderScanState wmpfss;

	public _WMPOCXEvents_FolderScanStateChangeEvent(WMPFolderScanState wmpfss)
	{
		this.wmpfss = wmpfss;
	}
}
