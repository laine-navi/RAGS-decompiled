using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf.Util;

public class GridViewSort
{
	private class a : Adorner
	{
		private GridViewColumnHeader m_a;

		private ListSortDirection b;

		private ImageSource c;

		public a(GridViewColumnHeader A_0, ListSortDirection A_1, ImageSource A_2)
			: base((UIElement)(object)A_0)
		{
			this.m_a = A_0;
			b = A_1;
			c = A_2;
		}

		private Geometry a()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected Obj, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected Obj, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected Obj, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected Obj, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected Obj, but got Unknown
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected Obj, but got Unknown
			double num = ((FrameworkElement)this.m_a).ActualWidth - 13.0;
			double num2 = num + 10.0;
			double num3 = num + 5.0;
			double num4 = ((FrameworkElement)this.m_a).ActualHeight / 2.0 - 3.0;
			double num5 = num4 + 5.0;
			if (b == ListSortDirection.Ascending)
			{
				double num6 = num4;
				num4 = num5;
				num5 = num6;
			}
			PathSegmentCollection val = new PathSegmentCollection();
			val.Add((PathSegment)new LineSegment(new Point(num2, num4), true));
			val.Add((PathSegment)new LineSegment(new Point(num3, num5), true));
			PathFigure val2 = new PathFigure(new Point(num, num4), (IEnumerable<PathSegment>)val, true);
			PathFigureCollection val3 = new PathFigureCollection();
			val3.Add(val2);
			return (Geometry)new PathGeometry((IEnumerable<PathFigure>)val3);
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected Obj, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			((UIElement)this).OnRender(drawingContext);
			if (c != null)
			{
				double num = ((FrameworkElement)this.m_a).ActualWidth - 13.0;
				double num2 = ((FrameworkElement)this.m_a).ActualHeight / 2.0 - 5.0;
				Rect val = new Rect(num, num2, 10.0, 10.0);
				drawingContext.DrawImage(c, val);
			}
			else
			{
				drawingContext.DrawGeometry((Brush)(object)Brushes.LightGray, new Pen((Brush)(object)Brushes.Gray, 1.0), a());
			}
		}
	}

	public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)((DependencyObject A_0, DependencyPropertyChangedEventArgs A_1) =>
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		ItemsControl val = (ItemsControl)(object)((A_0 is ItemsControl) ? A_0 : null);
		if (val != null && !GetAutoSort((DependencyObject)(object)val))
		{
			if (A_1.OldValue != null && A_1.NewValue == null)
			{
				((UIElement)val).RemoveHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
			if (A_1.OldValue == null && A_1.NewValue != null)
			{
				((UIElement)val).AddHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
		}
	})));

	public static readonly DependencyProperty AutoSortProperty = DependencyProperty.RegisterAttached("AutoSort", typeof(bool), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)((DependencyObject A_0, DependencyPropertyChangedEventArgs A_1) =>
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		ListView val = (ListView)(object)((A_0 is ListView) ? A_0 : null);
		if (val != null && GetCommand((DependencyObject)(object)val) == null)
		{
			bool flag = (bool)A_1.OldValue;
			bool flag2 = (bool)A_1.NewValue;
			if (flag && !flag2)
			{
				((UIElement)val).RemoveHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
			if (!flag && flag2)
			{
				((UIElement)val).AddHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
		}
	})));

	public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.RegisterAttached("PropertyName", typeof(string), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ShowSortGlyphProperty = DependencyProperty.RegisterAttached("ShowSortGlyph", typeof(bool), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((object)true));

	public static readonly DependencyProperty SortGlyphAscendingProperty = DependencyProperty.RegisterAttached("SortGlyphAscending", typeof(ImageSource), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty SortGlyphDescendingProperty = DependencyProperty.RegisterAttached("SortGlyphDescending", typeof(ImageSource), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	private static readonly DependencyProperty m_a;

	[CompilerGenerated]
	private static PropertyChangedCallback m_b;

	[CompilerGenerated]
	private static PropertyChangedCallback c;

	public static ICommand GetCommand(DependencyObject obj)
	{
		return (ICommand)obj.GetValue(CommandProperty);
	}

	public static void SetCommand(DependencyObject obj, ICommand value)
	{
		obj.SetValue(CommandProperty, (object)value);
	}

	public static bool GetAutoSort(DependencyObject obj)
	{
		return (bool)obj.GetValue(AutoSortProperty);
	}

	public static void SetAutoSort(DependencyObject obj, bool value)
	{
		obj.SetValue(AutoSortProperty, (object)value);
	}

	public static string GetPropertyName(DependencyObject obj)
	{
		return (string)obj.GetValue(PropertyNameProperty);
	}

	public static void SetPropertyName(DependencyObject obj, string value)
	{
		obj.SetValue(PropertyNameProperty, (object)value);
	}

	public static bool GetShowSortGlyph(DependencyObject obj)
	{
		return (bool)obj.GetValue(ShowSortGlyphProperty);
	}

	public static void SetShowSortGlyph(DependencyObject obj, bool value)
	{
		obj.SetValue(ShowSortGlyphProperty, (object)value);
	}

	public static ImageSource GetSortGlyphAscending(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		return (ImageSource)obj.GetValue(SortGlyphAscendingProperty);
	}

	public static void SetSortGlyphAscending(DependencyObject obj, ImageSource value)
	{
		obj.SetValue(SortGlyphAscendingProperty, (object)value);
	}

	public static ImageSource GetSortGlyphDescending(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		return (ImageSource)obj.GetValue(SortGlyphDescendingProperty);
	}

	public static void SetSortGlyphDescending(DependencyObject obj, ImageSource value)
	{
		obj.SetValue(SortGlyphDescendingProperty, (object)value);
	}

	private static GridViewColumnHeader a(DependencyObject A_0)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		return (GridViewColumnHeader)A_0.GetValue(GridViewSort.m_a);
	}

	private static void a(DependencyObject A_0, GridViewColumnHeader A_1)
	{
		A_0.SetValue(GridViewSort.m_a, (object)A_1);
	}

	private static void a(object A_0, RoutedEventArgs A_1)
	{
		object originalSource = A_1.OriginalSource;
		GridViewColumnHeader val = (GridViewColumnHeader)((originalSource is GridViewColumnHeader) ? originalSource : null);
		if (val == null || val.Column == null)
		{
			return;
		}
		string propertyName = GetPropertyName((DependencyObject)(object)val.Column);
		if (string.IsNullOrEmpty(propertyName))
		{
			return;
		}
		ListView ancestor = GridViewSort.GetAncestor<ListView>((DependencyObject)(object)val);
		if (ancestor == null)
		{
			return;
		}
		ICommand command = GetCommand((DependencyObject)(object)ancestor);
		if (command != null)
		{
			if (command.CanExecute(propertyName))
			{
				command.Execute(propertyName);
			}
		}
		else if (GetAutoSort((DependencyObject)(object)ancestor))
		{
			ApplySort((ICollectionView)(object)((ItemsControl)ancestor).Items, propertyName, ancestor, val);
		}
	}

	public static T GetAncestor<T>(DependencyObject reference) where T : DependencyObject
	{
		DependencyObject parent = VisualTreeHelper.GetParent(reference);
		while (!(parent is T))
		{
			parent = VisualTreeHelper.GetParent(parent);
		}
		if (parent != null)
		{
			return (T)(object)parent;
		}
		return default;
	}

	public static void ApplySort(ICollectionView view, string propertyName, ListView listView, GridViewColumnHeader sortedColumnHeader)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if (((Collection<SortDescription>)(object)view.SortDescriptions).Count > 0)
		{
			SortDescription val = ((Collection<SortDescription>)(object)view.SortDescriptions)[0];
			if (val.PropertyName == propertyName)
			{
				listSortDirection = ((val.Direction == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
			}
			((Collection<SortDescription>)(object)view.SortDescriptions).Clear();
			GridViewColumnHeader val2 = a((DependencyObject)(object)listView);
			if (val2 != null)
			{
				a(val2);
			}
		}
		if (!string.IsNullOrEmpty(propertyName))
		{
			((Collection<SortDescription>)(object)view.SortDescriptions).Add(new SortDescription(propertyName, listSortDirection));
			if (GetShowSortGlyph((DependencyObject)(object)listView))
			{
				a(sortedColumnHeader, listSortDirection, (listSortDirection == ListSortDirection.Ascending) ? GetSortGlyphAscending((DependencyObject)(object)listView) : GetSortGlyphDescending((DependencyObject)(object)listView));
			}
			a((DependencyObject)(object)listView, sortedColumnHeader);
		}
	}

	private static void a(GridViewColumnHeader A_0, ListSortDirection A_1, ImageSource A_2)
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)(object)A_0);
		adornerLayer.Add((Adorner)(object)new a(A_0, A_1, A_2));
	}

	private static void a(GridViewColumnHeader A_0)
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)(object)A_0);
		Adorner[] adorners = adornerLayer.GetAdorners((UIElement)(object)A_0);
		if (adorners == null)
		{
			return;
		}
		Adorner[] array = adorners;
		foreach (Adorner val in array)
		{
			if (val is a)
			{
				adornerLayer.Remove(val);
			}
		}
	}

	static GridViewSort()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		GridViewSort.m_a = DependencyProperty.RegisterAttached("SortedColumnHeader", typeof(GridViewColumnHeader), typeof(GridViewSort), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
	}

	[CompilerGenerated]
	private static void b(DependencyObject A_0, DependencyPropertyChangedEventArgs A_1)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		ItemsControl val = (ItemsControl)(object)((A_0 is ItemsControl) ? A_0 : null);
		if (val != null && !GetAutoSort((DependencyObject)(object)val))
		{
			if (A_1.OldValue != null && A_1.NewValue == null)
			{
				((UIElement)val).RemoveHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
			if (A_1.OldValue == null && A_1.NewValue != null)
			{
				((UIElement)val).AddHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
		}
	}

	[CompilerGenerated]
	private static void a(DependencyObject A_0, DependencyPropertyChangedEventArgs A_1)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		ListView val = (ListView)(object)((A_0 is ListView) ? A_0 : null);
		if (val != null && GetCommand((DependencyObject)(object)val) == null)
		{
			bool flag = (bool)A_1.OldValue;
			bool flag2 = (bool)A_1.NewValue;
			if (flag && !flag2)
			{
				((UIElement)val).RemoveHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
			if (!flag && flag2)
			{
				((UIElement)val).AddHandler(ButtonBase.ClickEvent, (Delegate)new RoutedEventHandler(a));
			}
		}
	}
}
