using System;

namespace Xceed.Wpf.Toolkit.Media.Animation;

public delegate T IterativeAnimationEquationDelegate<T>(TimeSpan currentTime, T from, T to, TimeSpan duration);
