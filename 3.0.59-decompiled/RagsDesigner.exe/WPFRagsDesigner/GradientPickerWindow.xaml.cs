using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFRagsDesigner;

public partial class GradientPickerWindow : Window, IComponentConnector
{
	private int m_a = 3;

	private int m_b;

	private string[] m_c = new string[10] { "Red", "Green", "Blue", "Black", "White", "Black", "White", "Black", "White", "Black" };

	internal Slider d;

	internal ComboBox e;

	internal Rectangle f;

	internal ComboBox g;

	internal Label h;

	internal TextBox i;

	internal ComboBox j;

	private bool k;

	public GradientPickerWindow()
	{
		InitializeComponent();
	}

	private void b()
	{
		((Selector)g).SelectedIndex = this.m_a - 1;
		((RangeBase)d).Maximum = this.m_a - 1;
		((RangeBase)d).SmallChange = 1.0;
	}

	private void a(object A_0, RoutedPropertyChangedEventArgs<double> A_1)
	{
		this.m_b = (byte)A_1.NewValue;
		j.Text = "System.Windows.Media.Color " + this.m_c[this.m_b];
		b();
	}

	private void c(object A_0, SelectionChangedEventArgs A_1)
	{
		this.m_b = 0;
		this.m_a = ((Selector)g).SelectedIndex + 1;
		((ItemsControl)e).Items.Clear();
		for (int i = 0; i < ((Selector)g).SelectedIndex + 1; i++)
		{
			((ItemsControl)e).Items.Add((object)(i + 1));
		}
		((Selector)e).SelectedIndex = 0;
		SetGradient();
		b();
	}

	private void b(object A_0, SelectionChangedEventArgs A_1)
	{
		string text = ((Selector)j).SelectedItem.ToString();
		if (text.Length > 0)
		{
			this.m_c[this.m_b] = text.Substring(27);
			SetGradient();
			b();
		}
	}

	public void SetGradient()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (f != null)
		{
			LinearGradientBrush val = (LinearGradientBrush)((Shape)f).Fill;
			GradientStopCollection gradientStops = ((GradientBrush)val).GradientStops;
			gradientStops.Clear();
			for (int i = 0; i < this.m_a; i++)
			{
				GradientStop val2 = new GradientStop();
				val2.Color = (Color)ColorConverter.ConvertFromString(this.m_c[i]);
				val2.Offset = (float)i / (float)(this.m_a - 1);
				gradientStops.Add(val2);
			}
			a();
		}
	}

	private void a()
	{
		string text = "";
		double num = 0.0;
		text = "<LinearGradientBrush StartPoint=\"0,0\" EndPoint=\"0,1\">\n";
		for (int i = 0; i < this.m_a; i++)
		{
			num = ((this.m_a <= 0) ? 0.0 : ((double)i / (double)(this.m_a - 1)));
			object obj = text;
			text = string.Concat(new object[6]
			{
				obj,
				"\t<GradientStop Color=\"",
				this.m_c[i],
				"\" Offset=\"",
				num,
				"\" />\n"
			});
		}
		text += "</LinearGradientBrush>\n";
		if (this.i != null)
		{
			this.i.Text = text;
		}
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		if (j != null && ((Selector)e).SelectedIndex != -1)
		{
			this.m_b = ((Selector)e).SelectedIndex;
			j.Text = "System.Windows.Media.Color " + this.m_c[this.m_b];
			b();
		}
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		SetGradient();
		b();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(GradientPickerWindow)target).Loaded += a;
			break;
		case 2:
			d = (Slider)target;
			((RangeBase)d).ValueChanged += a;
			break;
		case 3:
			e = (ComboBox)target;
			((Selector)e).SelectionChanged += a;
			break;
		case 4:
			f = (Rectangle)target;
			break;
		case 5:
			g = (ComboBox)target;
			((Selector)g).SelectionChanged += c;
			break;
		case 6:
			h = (Label)target;
			break;
		case 7:
			i = (TextBox)target;
			break;
		case 8:
			j = (ComboBox)target;
			((Selector)j).SelectionChanged += b;
			break;
		case 9:
			((ButtonBase)(Button)target).Click += c;
			break;
		case 10:
			((ButtonBase)(Button)target).Click += b;
			break;
		default:
			k = true;
			break;
		}
	}
}
