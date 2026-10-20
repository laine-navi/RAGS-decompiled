using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using Rags;

namespace RAGSWPFTEST1;

public partial class AdditionalInputWindow : Window, IComponentConnector
{
	private ListBox m_a;

	private ListBox m_b;

	private Action.ActionInputType m_c;

	public bool bstarted;

	internal Label d;

	internal TextBox e;

	internal ListBox f;

	internal Button g;

	internal Button h;

	private bool i;

	public AdditionalInputWindow(Action.ActionInputType intype, ref ListBox inv, ref ListBox rmobj, ref ListBox chars)
	{
		InitializeComponent();
		this.m_c = intype;
		this.m_a = inv;
		this.m_b = rmobj;
		switch (intype)
		{
		case Action.ActionInputType.Character:
		{
			((UIElement)f).Visibility = (Visibility)0;
			((UIElement)e).Visibility = (Visibility)1;
			((ContentControl)d).Content = "Please select a character:";
			for (int l = 0; l < ((CollectionView)((ItemsControl)chars).Items).Count; l++)
			{
				if (((ItemsControl)chars).Items[l] is Character character2)
				{
					((ItemsControl)f).Items.Add((object)character2);
				}
			}
			break;
		}
		case Action.ActionInputType.Object:
		{
			((UIElement)f).Visibility = (Visibility)0;
			((UIElement)e).Visibility = (Visibility)1;
			((ContentControl)d).Content = "Please select an object:";
			for (int m = 0; m < ((CollectionView)((ItemsControl)this.m_a).Items).Count; m++)
			{
				((ItemsControl)f).Items.Add((object)(GameObject)((ItemsControl)this.m_a).Items[m]);
			}
			for (int n = 0; n < ((CollectionView)((ItemsControl)this.m_b).Items).Count; n++)
			{
				((ItemsControl)f).Items.Add((object)(GameObject)((ItemsControl)this.m_b).Items[n]);
			}
			for (int num = 0; num < ((CollectionView)((ItemsControl)chars).Items).Count; num++)
			{
				if (((ItemsControl)chars).Items[num] is GameObject gameObject2)
				{
					((ItemsControl)f).Items.Add((object)gameObject2);
				}
			}
			break;
		}
		case Action.ActionInputType.Inventory:
		{
			((UIElement)f).Visibility = (Visibility)0;
			((UIElement)e).Visibility = (Visibility)1;
			((ContentControl)d).Content = "Please select an object:";
			for (int num2 = 0; num2 < ((CollectionView)((ItemsControl)this.m_a).Items).Count; num2++)
			{
				((ItemsControl)f).Items.Add((object)(GameObject)((ItemsControl)this.m_a).Items[num2]);
			}
			break;
		}
		case Action.ActionInputType.ObjectOrCharacter:
		{
			((UIElement)f).Visibility = (Visibility)0;
			((UIElement)e).Visibility = (Visibility)1;
			((ContentControl)d).Content = "Please select an object:";
			for (int i = 0; i < ((CollectionView)((ItemsControl)this.m_a).Items).Count; i++)
			{
				((ItemsControl)f).Items.Add((object)(GameObject)((ItemsControl)this.m_a).Items[i]);
			}
			for (int j = 0; j < ((CollectionView)((ItemsControl)this.m_b).Items).Count; j++)
			{
				((ItemsControl)f).Items.Add((object)(GameObject)((ItemsControl)this.m_b).Items[j]);
			}
			for (int k = 0; k < ((CollectionView)((ItemsControl)chars).Items).Count; k++)
			{
				Character character = ((ItemsControl)chars).Items[k] as Character;
				if (((ItemsControl)chars).Items[k] is GameObject gameObject)
				{
					((ItemsControl)f).Items.Add((object)gameObject.GetDisplayName());
				}
				else if (character != null)
				{
					((ItemsControl)f).Items.Add((object)character.Charname);
				}
			}
			break;
		}
		case Action.ActionInputType.Text:
			((UIElement)f).Visibility = (Visibility)1;
			((UIElement)e).Visibility = (Visibility)0;
			((ContentControl)d).Content = "Please enter your text here:";
			break;
		case Action.ActionInputType.Custom:
			((UIElement)f).Visibility = (Visibility)0;
			((UIElement)e).Visibility = (Visibility)1;
			((ContentControl)d).Content = "Please make a selection:";
			{
				foreach (string item in (IEnumerable)((ItemsControl)inv).Items)
				{
					string text2 = item;
					((ItemsControl)f).Items.Add((object)text2);
				}
				break;
			}
		}
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		if (this.m_c != Action.ActionInputType.Text)
		{
			if (((Selector)f).SelectedIndex > -1)
			{
				((Window)this).DialogResult = true;
				((Window)this).Close();
			}
		}
		else
		{
			((Window)this).DialogResult = true;
			((Window)this).Close();
		}
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
		((Window)this).Close();
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		if (((UIElement)e).IsVisible)
		{
			((UIElement)e).Focus();
		}
		else
		{
			((UIElement)f).Focus();
		}
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)f).SelectedIndex > -1)
		{
			((Window)this).DialogResult = true;
			((Window)this).Close();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(AdditionalInputWindow)target).Loaded += a;
			break;
		case 2:
			d = (Label)target;
			break;
		case 3:
			e = (TextBox)target;
			break;
		case 4:
			f = (ListBox)target;
			((Selector)f).SelectionChanged += a;
			break;
		case 5:
			g = (Button)target;
			((ButtonBase)g).Click += c;
			break;
		case 6:
			h = (Button)target;
			((ButtonBase)h).Click += b;
			break;
		default:
			i = true;
			break;
		}
	}
}
