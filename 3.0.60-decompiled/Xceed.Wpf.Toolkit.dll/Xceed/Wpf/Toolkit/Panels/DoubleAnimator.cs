using System;
using System.Windows;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

public class DoubleAnimator : IterativeAnimator
{
	private readonly IterativeEquation<double> _equation;

	public DoubleAnimator(IterativeEquation<double> equation)
	{
		_equation = equation;
	}

	public override Rect GetInitialChildPlacement(UIElement child, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, ref AnimationRate animationRate, out object placementArgs, out bool isDone)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		isDone = (animationRate.HasSpeed && animationRate.Speed <= 0.0) || (animationRate.HasDuration && animationRate.Duration.Ticks == 0);
		if (!isDone)
		{
			Vector val = new Vector(currentPlacement.Left + currentPlacement.Width / 2.0, currentPlacement.Top + currentPlacement.Height / 2.0);
			Vector val2 = new Vector(targetPlacement.Left + targetPlacement.Width / 2.0, targetPlacement.Top + targetPlacement.Height / 2.0);
			Vector val3 = val - val2;
			animationRate = new AnimationRate(animationRate.HasDuration ? animationRate.Duration : TimeSpan.FromMilliseconds(val3.Length / animationRate.Speed));
		}
		placementArgs = currentPlacement;
		return currentPlacement;
	}

	public override Rect GetNextChildPlacement(UIElement child, TimeSpan currentTime, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, AnimationRate animationRate, ref object placementArgs, out bool isDone)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		Rect result = targetPlacement;
		isDone = true;
		if (_equation != null)
		{
			Rect val = (Rect)placementArgs;
			TimeSpan duration = animationRate.Duration;
			isDone = currentTime >= duration;
			if (!isDone)
			{
				double num = _equation.Evaluate(currentTime, val.Left, targetPlacement.Left, duration);
				double num2 = _equation.Evaluate(currentTime, val.Top, targetPlacement.Top, duration);
				double num3 = Math.Max(0.0, _equation.Evaluate(currentTime, val.Width, targetPlacement.Width, duration));
				double num4 = Math.Max(0.0, _equation.Evaluate(currentTime, val.Height, targetPlacement.Height, duration));
				result = new Rect(num, num2, num3, num4);
			}
		}
		return result;
	}
}
