using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Rags;

namespace RAGSWPFPlayer;

public partial class GameInfoWindow : Window, IComponentConnector
{
	private Game m_a;

	internal TextBlock b;

	internal TextBlock c;

	internal TextBlock d;

	private bool e;

	public GameInfoWindow(ref Game curgame)
	{
		this.m_a = curgame;
		InitializeComponent();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		this.b.Text = this.m_a.AuthorName;
		c.Text = this.m_a.GameVersion;
		d.Text = this.m_a.GameInformation;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).Close();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(GameInfoWindow)target).Loaded += b;
			break;
		case 2:
			this.b = (TextBlock)target;
			break;
		case 3:
			c = (TextBlock)target;
			break;
		case 4:
			d = (TextBlock)target;
			break;
		case 5:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			e = true;
			break;
		}
	}
}
