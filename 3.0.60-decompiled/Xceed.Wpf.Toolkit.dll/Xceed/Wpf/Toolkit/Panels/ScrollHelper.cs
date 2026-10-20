using System;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

internal static class ScrollHelper
{
	public static bool ScrollLeastAmount(Rect physViewRect, Rect itemRect, out Vector newPhysOffset)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		newPhysOffset = default;
		if (!physViewRect.Contains(itemRect))
		{
			if ((itemRect.Left > physViewRect.Left && itemRect.Right < physViewRect.Right) || DoubleHelper.AreVirtuallyEqual(itemRect.Left, physViewRect.Left))
			{
				newPhysOffset.X = itemRect.Left;
			}
			else if (itemRect.Left < physViewRect.Left || itemRect.Width > physViewRect.Width)
			{
				newPhysOffset.X = itemRect.Left;
			}
			else
			{
				newPhysOffset.X = Math.Max(0.0, physViewRect.Left + (itemRect.Right - physViewRect.Right));
			}
			if ((itemRect.Top > physViewRect.Top && itemRect.Bottom < physViewRect.Bottom) || DoubleHelper.AreVirtuallyEqual(itemRect.Top, physViewRect.Top))
			{
				newPhysOffset.Y = itemRect.Top;
			}
			else if (itemRect.Top < physViewRect.Top || itemRect.Height > physViewRect.Height)
			{
				newPhysOffset.Y = itemRect.Top;
			}
			else
			{
				newPhysOffset.Y = Math.Max(0.0, physViewRect.Top + (itemRect.Bottom - physViewRect.Bottom));
			}
			result = true;
		}
		return result;
	}
}
