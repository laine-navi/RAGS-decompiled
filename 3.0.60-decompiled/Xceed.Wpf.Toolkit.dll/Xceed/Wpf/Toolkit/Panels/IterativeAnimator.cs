using System;
using System.ComponentModel;
using System.Windows;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

[TypeConverter(typeof(AnimatorConverter))]
public abstract class IterativeAnimator
{
	private sealed class DefaultAnimator : IterativeAnimator
	{
		public override Rect GetInitialChildPlacement(UIElement child, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, ref AnimationRate animationRate, out object placementArgs, out bool isDone)
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("DefaultAnimatorCantAnimate"));
		}

		public override Rect GetNextChildPlacement(UIElement child, TimeSpan currentTime, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, AnimationRate animationRate, ref object placementArgs, out bool isDone)
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("DefaultAnimatorCantAnimate"));
		}
	}

	private static readonly IterativeAnimator _default = new DefaultAnimator();

	public static IterativeAnimator Default => _default;

	public abstract Rect GetInitialChildPlacement(UIElement child, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, ref AnimationRate animationRate, out object placementArgs, out bool isDone);

	public abstract Rect GetNextChildPlacement(UIElement child, TimeSpan currentTime, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, AnimationRate animationRate, ref object placementArgs, out bool isDone);
}
