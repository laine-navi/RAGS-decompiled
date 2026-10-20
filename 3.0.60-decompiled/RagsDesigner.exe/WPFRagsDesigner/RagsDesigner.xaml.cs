using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Microsoft.Win32;
using Polenter.Serialization;
using Rags;
using WPFRagsDesigner.Properties;
using WPFRagsDesigner.ServiceReference1;
using WPFRagsLib;
using Xceed.Wpf.Toolkit;

namespace WPFRagsDesigner;

public partial class RagsDesigner : Window, IComponentConnector
{
	public static Game TheGame = new Game();

	private string m_a = string.Empty;

	private string m_b = string.Empty;

	private string m_c = "";

	private Point m_d;

	private static bool m_e;

	private static bool m_f;

	private GameObject m_g;

	private DispatcherTimer m_h;

	internal Grid i;

	internal MenuItem j;

	internal MenuItem k;

	internal MenuItem l;

	internal MenuItem m;

	internal MenuItem n;

	internal MenuItem o;

	internal MenuItem p;

	internal MenuItem q;

	internal MenuItem r;

	internal MenuItem s;

	internal MenuItem t;

	internal TabControl u;

	internal TabItem v;

	internal Grid w;

	internal TabItem x;

	internal TextBox y;

	internal CheckBox z;

	internal PasswordBox aa;

	internal CheckBox ab;

	internal ComboBox ac;

	internal CheckBox ad;

	internal TextBox ae;

	internal CheckBox af;

	internal CheckBox ag;

	internal CheckBox ah;

	internal ComboBox ai;

	internal ComboBox aj;

	internal ComboBox ak;

	internal TextBox al;

	internal ListBox am;

	internal TextBox an;

	internal Button ao;

	internal CheckBox ap;

	internal TabItem aq;

	internal TextBox ar;

	internal TextBox @as;

	internal TextBox at;

	internal TabItem au;

	internal ListView av;

	internal MenuItem aw;

	internal MenuItem ax;

	internal MenuItem ay;

	internal MenuItem az;

	internal TabControl a0;

	internal Grid a1;

	internal TextBox a2;

	internal TextBox a3;

	internal TextBox a4;

	internal ComboBox a5;

	internal TextBox a6;

	internal ComboBox a7;

	internal MediaElement a8;

	internal Label a9;

	internal Grid ba;

	internal CheckBox bb;

	internal CheckBox bc;

	internal CheckBox bd;

	internal CheckBox be;

	internal CheckBox bf;

	internal CheckBox bg;

	internal CheckBox bh;

	internal CheckBox bi;

	internal CheckBox bj;

	internal CheckBox bk;

	internal CheckBox bl;

	internal CheckBox bm;

	internal ComboBox bn;

	internal ComboBox bo;

	internal ComboBox bp;

	internal ComboBox bq;

	internal ComboBox br;

	internal ComboBox bs;

	internal ComboBox bt;

	internal ComboBox bu;

	internal ComboBox bv;

	internal ComboBox bw;

	internal ComboBox bx;

	internal ComboBox by;

	internal ComboBox bz;

	internal ComboBox b0;

	internal ComboBox b1;

	internal ComboBox b2;

	internal ComboBox b3;

	internal ComboBox b4;

	internal ComboBox b5;

	internal ComboBox b6;

	internal ComboBox b7;

	internal ComboBox b8;

	internal ComboBox b9;

	internal ComboBox ca;

	internal Grid cb;

	internal Label cc;

	internal ListBox cd;

	internal MenuItem ce;

	internal MenuItem cf;

	internal ListView cg;

	internal TextBox ch;

	internal TextBox ci;

	internal WPFActionControl cj;

	internal TabControl ck;

	internal CheckBox cl;

	internal TextBox cm;

	internal CheckBox cn;

	internal RadioButton co;

	internal RadioButton cp;

	internal RadioButton cq;

	internal CheckBox cr;

	internal TextBox cs;

	internal ComboBox ct;

	internal ListBox cu;

	internal Button cv;

	internal TextBox cw;

	internal ComboBox cx;

	internal MediaElement cy;

	internal ListView cz;

	internal TextBox c0;

	internal TextBox c1;

	internal WPFActionControl c2;

	internal TabControl c3;

	internal TextBox c4;

	internal TextBox c5;

	internal TextBox c6;

	internal TextBox c7;

	internal TextBox c8;

	internal CheckBox c9;

	internal CheckBox da;

	internal CheckBox db;

	internal CheckBox dc;

	internal CheckBox dd;

	internal RadioButton de;

	internal RadioButton df;

	internal RadioButton dg;

	internal RadioButton dh;

	internal RadioButton di;

	internal RadioButton dj;

	internal RadioButton dk;

	internal RadioButton dl;

	internal CheckBox dm;

	internal CheckBox dn;

	internal CheckBox @do;

	internal TextBox dp;

	internal ListBox dq;

	internal Button dr;

	internal Button ds;

	internal ListView dt;

	internal TextBox du;

	internal TextBox dv;

	internal Button dw;

	internal Button dx;

	internal Button dy;

	internal Grid dz;

	internal Label d0;

	internal ListBox d1;

	internal Button d2;

	internal Button d3;

	internal ListBox d4;

	internal ComboBox d5;

	internal ComboBox d6;

	internal Button d7;

	internal Button d8;

	internal TextBox d9;

	internal WPFActionControl ea;

	internal ListView eb;

	internal MenuItem ec;

	internal MenuItem ed;

	internal Button ee;

	internal TabControl ef;

	internal Label eg;

	internal TextBox eh;

	internal ComboBox ei;

	internal CheckBox ej;

	internal GroupBox ek;

	internal RadioButton el;

	internal RadioButton em;

	internal RadioButton en;

	internal TextBox eo;

	internal ListBox ep;

	internal MenuItem eq;

	internal ComboBox er;

	internal MediaElement es;

	internal Button et;

	internal ListView eu;

	internal TextBox ev;

	internal TextBox ew;

	internal Button ex;

	internal Button ey;

	internal Button ez;

	internal WPFActionControl e0;

	internal TreeView e1;

	internal MenuItem e2;

	internal MenuItem e3;

	internal MenuItem e4;

	internal MenuItem e5;

	internal Label e6;

	internal GroupBox e7;

	internal RadioButton e8;

	internal RadioButton e9;

	internal RadioButton fa;

	internal RadioButton fb;

	internal RadioButton fc;

	internal RadioButton fd;

	internal GroupBox fe;

	internal TextBox ff;

	internal GroupBox fg;

	internal TextBox fh;

	internal DateTimePicker fi;

	internal Grid fj;

	internal TextBox fk;

	internal CheckBox fl;

	internal TextBox fm;

	internal TextBox fn;

	internal GroupBox fo;

	internal Button fp;

	internal Button fq;

	internal Button fr;

	internal CheckBox fs;

	internal ListBox ft;

	internal DataGrid fu;

	internal MenuItem fv;

	internal MenuItem fw;

	internal MenuItem fx;

	internal ListView fy;

	internal TextBox fz;

	internal TextBox f0;

	internal Button f1;

	internal Button f2;

	internal Button f3;

	internal ListView f4;

	internal MenuItem f5;

	internal MenuItem f6;

	internal Button f7;

	internal TabControl f8;

	internal Label f9;

	internal GroupBox ga;

	internal TextBox gb;

	internal GroupBox gc;

	internal RadioButton gd;

	internal RadioButton ge;

	internal GroupBox gf;

	internal TextBox gg;

	internal CheckBox gh;

	internal GroupBox gi;

	internal CheckBox gj;

	internal TextBox gk;

	internal CheckBox gl;

	internal ListView gm;

	internal TextBox gn;

	internal TextBox go;

	internal Button gp;

	internal Button gq;

	internal Button gr;

	internal WPFActionControl gs;

	internal ListView gt;

	internal Grid gu;

	internal MediaElement gv;

	internal ListBox gw;

	internal Button gx;

	internal Button gy;

	internal Button gz;

	internal TreeView g0;

	internal MenuItem g1;

	internal MenuItem g2;

	internal MenuItem g3;

	internal MenuItem g4;

	internal MenuItem g5;

	internal MediaElement g6;

	internal TreeView g7;

	internal MenuItem g8;

	internal MenuItem g9;

	internal MenuItem ha;

	internal MenuItem hb;

	internal MenuItem hc;

	internal MenuItem hd;

	internal MenuItem he;

	private bool hf;

	[CompilerGenerated]
	private static System.Action hg;

	[CompilerGenerated]
	private static Comparison<GameVariable> hh;

	[CompilerGenerated]
	private static Comparison<GameObject> hi;

	[CompilerGenerated]
	private static Comparison<GamePicture> hj;

	public RagsDesigner()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		InitializeComponent();
		Game.ObjectVersionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		((ApplicationSettingsBase)Settings.Default).SettingsLoaded += a;
		d9.Text = "Layered Clothing is comprised of zones and levels.\r\n\r\nA zone corresponds to a part of the body and the level is the order in which the clothing should be worn.  Level 1 is the closest to the skin, and level 10 would be the farthest from the skin.  RAGS preloads three body zones for you.  They are \"Lower Body\", \"Mid Body\", and \"Upper Body\".  You can add to these zones, say, a \"Head\" zone, or delete all the zones and create your own custom zones.  \r\n\r\nOne piece of clothing may occupy more then one zone and level.  This is perfectly fine.  Just assign as many zones and levels as required.  \r\n\r\nEx: Socks could be \"Lower Body Level 1\", Shoes could be \"Lower Body Level 2\", and say a dress could be \"Upper Body Level 2 and Mid Body Level 2\".   \r\n\r\nThere are two commands that use the layered clothing scheme.  \r\n\r\nItem: Layered Wear and\r\nItem: Layered Remove\r\n\r\nThese commands enforce layered clothing limits.  \r\nSince clothing may or may not be worn after the command runs, you will need to check the status of the item and see if its worn, if you need to do additional commands after its successfully worn.\r\nAll text displays to the player are automatically handled by the command.  You no longer need to display text telling the player their item is worn or removed.\r\n\r\nHere are the enforced rules by the layered clothes engine using our socks and shoes as an example.\r\nShoes(lvl 2) may be worn without Socks(lvl 1).  Socks(lvl 1) can not be worn if Shoes(lvl 2) are currently worn, or if another pair of Socks(lvl 1) are already worn.  Socks could not be removed if Shoes(lvl 2) are also already worn.  For Items that span multiple zones, the same rules apply, the are enforced at each level.";
		this.c2.ThePageType = WPFActionControl.PageType.player;
		e0.ThePageType = WPFActionControl.PageType.characters;
		ea.ThePageType = WPFActionControl.PageType.objects;
		this.cj.ThePageType = WPFActionControl.PageType.room;
		gs.ThePageType = WPFActionControl.PageType.timers;
		ai();
		this.m_h = new DispatcherTimer();
		this.m_h.IsEnabled = false;
		this.m_h.Tick += a;
	}

	private void a(object A_0, SettingsLoadedEventArgs A_1)
	{
		if (Settings.Default.GeneralGrid != null)
		{
			((Control)this.v).Background = (Brush)(object)Settings.Default.GeneralGrid;
			((Panel)this.w).Background = (Brush)(object)Settings.Default.GeneralGrid;
			((Control)this.x).Background = (Brush)(object)Settings.Default.GeneralGrid;
			((Control)this.aq).Background = (Brush)(object)Settings.Default.GeneralGrid;
		}
	}

	private void d1(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).Close();
	}

	private void @as(object A_0, SelectionChangedEventArgs A_1)
	{
	}

	private void d0(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).Filter = "Rags Game Files|*.rag|All Files|*.*";
		if (((CommonDialog)val).ShowDialog() == true)
		{
			a(((FileDialog)val).FileName);
		}
	}

	private void a(string A_0)
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		try
		{
			SaveLoad.DBName = A_0;
			SaveLoad.GetDBConnection();
			TheGame = SaveLoad.Game_LoadGame(A_0);
			while (!SaveLoad.bDoneWithWaitDlg)
			{
				((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
				{
				}));
			}
		}
		catch
		{
			flag = true;
		}
		if (flag)
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cryptoStream = null;
			try
			{
				EncDec.Decrypt(A_0, ref memst, ref cryptoStream, this.m_a);
			}
			catch
			{
			}
			memst.Seek(0L, SeekOrigin.Begin);
			TheGame = null;
			try
			{
				SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
				TheGame = (Game)sharpSerializer.Deserialize(memst);
				cryptoStream.Close();
				cryptoStream.Dispose();
				MessageBox.Show("This game file must be updated to the new storage system.  We will rename your current file to " + A_0 + ".old  Please click OK to continue.");
				File.Copy(A_0, A_0 + ".old", overwrite: true);
				SaveLoad.Game_CreateDatabase(A_0);
				Path.GetTempPath();
				foreach (GamePicture picture in TheGame.PictureList)
				{
					_ = picture;
				}
				SaveLoad.Game_UpdateDatabase(TheGame);
			}
			catch
			{
				TheGame = null;
				MessageBox.Show("Sorry, This RAGS Game file is unreadable.", "Unreadable game");
				return;
			}
			memst.Close();
			memst.Dispose();
		}
		if (!p())
		{
			MessageBox.Show("This game will be in read only mode due to trial limitations.");
		}
		((ToggleButton)this.ad).IsChecked = TheGame.bRepeatbgMusic;
		if (TheGame.bPasswordProtected)
		{
			int num = 0;
			bool flag2 = false;
			for (; num < 3; num++)
			{
				GetNameWindow getNameWindow = new GetNameWindow();
				((Window)getNameWindow).Owner = (Window)(object)this;
				((ContentControl)getNameWindow.lblTitle).Content = "Enter Password";
				if (((Window)getNameWindow).ShowDialog() != true)
				{
					TheGame = new Game();
					break;
				}
				Version version = new Version();
				if (Game.CurrentObjectVersionNumber != string.Empty)
				{
					version = new Version(Game.CurrentObjectVersionNumber);
				}
				Version version2 = new Version("1.0.9.0");
				if (Game.CurrentObjectVersionNumber != string.Empty && version <= version2)
				{
					if (getNameWindow.txtEntry.Text == TheGame.GamePassword)
					{
						flag2 = true;
						this.aa.Password = getNameWindow.txtEntry.Text;
						TheGame.GamePassword = EncDec.ComputeHash(getNameWindow.txtEntry.Text, "SHA1", null);
						break;
					}
				}
				else if (EncDec.VerifyHash(getNameWindow.txtEntry.Text, "SHA1", TheGame.GamePassword))
				{
					flag2 = true;
					this.aa.Password = getNameWindow.txtEntry.Text;
					break;
				}
				MessageBox.Show("Incorrect Password.  Please Try Again.");
			}
			if (!flag2)
			{
				SaveLoad.DBName = string.Empty;
				TheGame = new Game();
			}
		}
		Game.bUpgrading = false;
		Game.CurrentObjectVersionNumber = Game.ObjectVersionNumber;
		this.m_c = A_0;
		((FrameworkElement)this).DataContext = TheGame;
		ai();
		if (TheGame != null)
		{
			((Selector)this.ac).SelectedItem = TheGame.bgMusic;
		}
	}

	private void ai()
	{
		if (TheGame != null)
		{
			q();
			r();
			((ItemsControl)this.am).Items.Clear();
			((Window)this).Title = "Rags Designer - " + this.m_c;
			ea.SetGameObject(ref TheGame);
			e0.SetGameObject(ref TheGame);
			this.cj.SetGameObject(ref TheGame);
			this.c2.SetGameObject(ref TheGame);
			gs.SetGameObject(ref TheGame);
			o();
			s();
			t();
			y();
			aa();
			ab();
			ac();
			ad();
			ae();
			af();
			ag();
			ah();
			this.c2.RefreshActions();
			if (((CollectionView)((ItemsControl)eb).Items).Count > 0)
			{
				((Selector)eb).SelectedIndex = 0;
				((UIElement)e0).IsEnabled = true;
			}
			if (((CollectionView)((ItemsControl)this.av).Items).Count > 0 && ((ListBox)this.av).SelectedItems.Count < 1)
			{
				((Selector)this.av).SelectedIndex = 0;
			}
		}
		else
		{
			((Window)this).Title = "Rags Designer";
		}
	}

	private void ah()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)fy).Items.Clear();
		if (e1.SelectedItem == null)
		{
			return;
		}
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable)
		{
			foreach (CustomProperty customProperty in gameVariable.CustomProperties)
			{
				((ItemsControl)fy).Items.Add((object)customProperty);
			}
		}
		an((object)null, (SelectionChangedEventArgs)null);
	}

	private void ag()
	{
		((ItemsControl)gm).Items.Clear();
		if (((ListBox)f4).SelectedItems.Count > 0)
		{
			Rags.Timer timer = (Rags.Timer)((Selector)f4).SelectedItem;
			if (timer != null)
			{
				foreach (CustomProperty customProperty in timer.CustomProperties)
				{
					((ItemsControl)gm).Items.Add((object)customProperty);
				}
			}
		}
		ao((object)null, (SelectionChangedEventArgs)null);
	}

	private void af()
	{
		((ItemsControl)f4).Items.Clear();
		for (int i = 0; i < TheGame.TimerList.Count; i++)
		{
			((ItemsControl)f4).Items.Add((object)TheGame.TimerList[i]);
		}
	}

	private void ae()
	{
		((ItemsControl)eu).Items.Clear();
		if (((ListBox)eb).SelectedItems.Count > 0)
		{
			Character character = (Character)((Selector)eb).SelectedItem;
			if (character != null)
			{
				foreach (CustomProperty customProperty in character.CustomProperties)
				{
					((ItemsControl)eu).Items.Add((object)customProperty);
				}
			}
		}
		ap((object)null, (SelectionChangedEventArgs)null);
	}

	private void ad()
	{
		((ItemsControl)eb).Items.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			((ItemsControl)eb).Items.Add((object)character);
		}
	}

	private void ac()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		((ItemsControl)e1).Items.Clear();
		TheGame.VariableList.Sort((GameVariable gameVariable2, GameVariable gameVariable3) =>
		{
			if (gameVariable2.varname == null && gameVariable3.varname == null)
			{
				return 0;
			}
			if (gameVariable2.varname == null)
			{
				return -1;
			}
			return (gameVariable3.varname == null) ? 1 : gameVariable2.varname.CompareTo(gameVariable3.varname);
		});
		TreeViewItem A_ = new TreeViewItem();
		a(ref A_, "Variables");
		int count = ((CollectionView)((ItemsControl)A_).Items).Count;
		for (int num = 0; num < count; num++)
		{
			object obj = ((ItemsControl)A_).Items[0];
			TreeViewItem val = (TreeViewItem)((obj is TreeViewItem) ? obj : null);
			((ItemsControl)A_).Items.Remove((object)val);
			((ItemsControl)e1).Items.Add((object)val);
		}
		for (int num2 = 0; num2 < TheGame.VariableList.Count; num2++)
		{
			GameVariable gameVariable = TheGame.VariableList[num2];
			if (gameVariable.GroupName == string.Empty)
			{
				TreeViewItem val2 = new TreeViewItem();
				StackPanel val3 = new StackPanel();
				val3.Orientation = (Orientation)0;
				((FrameworkElement)val3).Height = 22.0;
				Image val4 = new Image();
				val4.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/object.png"));
				((FrameworkElement)val4).Width = 16.0;
				((FrameworkElement)val4).Height = 16.0;
				Label val5 = new Label();
				((ContentControl)val5).Content = gameVariable.varname;
				((FrameworkElement)val5).VerticalAlignment = (VerticalAlignment)1;
				((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
				((Control)val5).FontSize = 9.0;
				((Panel)val3).Children.Add((UIElement)(object)val4);
				((Panel)val3).Children.Add((UIElement)(object)val5);
				((HeaderedItemsControl)val2).Header = val3;
				((FrameworkElement)val2).Tag = gameVariable;
				((ItemsControl)e1).Items.Add((object)val2);
			}
		}
	}

	private void ab()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)this.dt).Items.Clear();
		if (g7.SelectedItem == null || !(((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject))
		{
			return;
		}
		foreach (CustomProperty customProperty in gameObject.CustomProperties)
		{
			((ItemsControl)this.dt).Items.Add((object)customProperty);
		}
	}

	private void aa()
	{
		z();
		c((object)null, (RoutedPropertyChangedEventArgs<object>)null);
	}

	private void z()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		((ItemsControl)g7).Items.Clear();
		TheGame.ObjectList.Sort((GameObject gameObject2, GameObject gameObject3) =>
		{
			if (gameObject2.name == null && gameObject3.name == null)
			{
				return 0;
			}
			if (gameObject2.name == null)
			{
				return -1;
			}
			return (gameObject3.name == null) ? 1 : gameObject2.name.CompareTo(gameObject3.name);
		});
		TreeViewItem A_ = new TreeViewItem();
		a(ref A_, "Items");
		int count = ((CollectionView)((ItemsControl)A_).Items).Count;
		for (int num = 0; num < count; num++)
		{
			object obj = ((ItemsControl)A_).Items[0];
			TreeViewItem val = (TreeViewItem)((obj is TreeViewItem) ? obj : null);
			((ItemsControl)A_).Items.Remove((object)val);
			((ItemsControl)g7).Items.Add((object)val);
		}
		for (int num2 = 0; num2 < TheGame.ObjectList.Count; num2++)
		{
			GameObject gameObject = TheGame.ObjectList[num2];
			if (gameObject.GroupName == string.Empty)
			{
				TreeViewItem val2 = new TreeViewItem();
				StackPanel val3 = new StackPanel();
				val3.Orientation = (Orientation)0;
				((FrameworkElement)val3).Height = 22.0;
				Image val4 = new Image();
				val4.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/object.png"));
				((FrameworkElement)val4).Width = 16.0;
				((FrameworkElement)val4).Height = 16.0;
				Label val5 = new Label();
				((ContentControl)val5).Content = gameObject.name;
				((FrameworkElement)val5).VerticalAlignment = (VerticalAlignment)1;
				((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
				((Control)val5).FontSize = 9.0;
				((Panel)val3).Children.Add((UIElement)(object)val4);
				((Panel)val3).Children.Add((UIElement)(object)val5);
				((HeaderedItemsControl)val2).Header = val3;
				((FrameworkElement)val2).Tag = gameObject;
				((ItemsControl)g7).Items.Add((object)val2);
			}
		}
	}

	private void y()
	{
		if (TheGame.ThePlayer.StartingRoom != null)
		{
			this.ct.Text = TheGame.ThePlayer.StartingRoom.Name;
		}
		((ToggleButton)this.cl).IsChecked = TheGame.ThePlayer.bPromptForName;
		((ToggleButton)this.cn).IsChecked = TheGame.ThePlayer.bPromptForGender;
		switch (TheGame.ThePlayer.PlayerGender)
		{
		case Player.Gender.Male:
			((ToggleButton)this.co).IsChecked = true;
			break;
		case Player.Gender.Female:
			((ToggleButton)this.cp).IsChecked = true;
			break;
		case Player.Gender.Other:
			((ToggleButton)this.cq).IsChecked = true;
			break;
		}
		this.cm.Text = TheGame.ThePlayer.Name;
		this.cx.Text = TheGame.ThePlayer.PlayerPortrait;
		if (TheGame.ThePlayer.PlayerPortrait != string.Empty)
		{
			((FrameworkElement)this.cy).Tag = SaveLoad.GetGamePictureByName(TheGame.ThePlayer.PlayerPortrait, ref TheGame);
			this.cy.Source = new Uri(SaveLoad.GetPictureByName(TheGame.ThePlayer.PlayerPortrait, ref TheGame).ToString());
		}
		this.cw.Text = TheGame.ThePlayer.Description;
		((ToggleButton)this.cr).IsChecked = TheGame.ThePlayer.bEnforceWeight;
		this.cs.Text = TheGame.ThePlayer.dWeightLimit.ToString();
		((ItemsControl)this.cz).Items.Clear();
		foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
		{
			((ItemsControl)this.cz).Items.Add((object)customProperty);
		}
		x();
	}

	private void x()
	{
		u();
		v();
		w();
		m();
	}

	private void w()
	{
		((ItemsControl)this.cu).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].locationtype == GameObject.LocationType.LT_PLAYER)
			{
				((ItemsControl)this.cu).Items.Add((object)new RoomComboItem(TheGame.ObjectList[i].UniqueIdentifier, TheGame.ObjectList[i].name));
			}
		}
	}

	private void v()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)this.dq).Items.Clear();
		if (g7.SelectedItem == null || !(((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject))
		{
			return;
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_IN_OBJECT && @object.locationname == gameObject.UniqueIdentifier.ToString())
			{
				((ItemsControl)this.dq).Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void u()
	{
		if (((ListBox)eb).SelectedItems.Count <= 0)
		{
			return;
		}
		((ItemsControl)ep).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i];
			if (gameObject.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject.locationname == ((Character)((Selector)eb).SelectedItem).Charname)
			{
				((ItemsControl)ep).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void t()
	{
		((ItemsControl)this.av).Items.Clear();
		((ItemsControl)this.bn).Items.Clear();
		((ItemsControl)this.bp).Items.Clear();
		((ItemsControl)this.bt).Items.Clear();
		((ItemsControl)this.br).Items.Clear();
		((ItemsControl)this.bv).Items.Clear();
		((ItemsControl)this.bx).Items.Clear();
		((ItemsControl)this.b1).Items.Clear();
		((ItemsControl)this.bz).Items.Clear();
		((ItemsControl)this.b3).Items.Clear();
		((ItemsControl)this.b5).Items.Clear();
		((ItemsControl)this.b7).Items.Clear();
		((ItemsControl)this.b9).Items.Clear();
		((ItemsControl)this.ct).Items.Clear();
		((ItemsControl)ei).Items.Clear();
		RoomComboItem roomComboItem = new RoomComboItem();
		roomComboItem.UniqueID = Room.VoidRoomGuid;
		roomComboItem.RoomName = "<None>";
		((ItemsControl)ei).Items.Add((object)roomComboItem);
		RoomComboItem roomComboItem2 = new RoomComboItem();
		roomComboItem2.UniqueID = Guid.Empty;
		roomComboItem2.RoomName = string.Empty;
		((ItemsControl)this.bn).Items.Add((object)roomComboItem2);
		((ItemsControl)this.bp).Items.Add((object)roomComboItem2);
		((ItemsControl)this.bt).Items.Add((object)roomComboItem2);
		((ItemsControl)this.br).Items.Add((object)roomComboItem2);
		((ItemsControl)this.bv).Items.Add((object)roomComboItem2);
		((ItemsControl)this.bx).Items.Add((object)roomComboItem2);
		((ItemsControl)this.b1).Items.Add((object)roomComboItem2);
		((ItemsControl)this.bz).Items.Add((object)roomComboItem2);
		((ItemsControl)this.b3).Items.Add((object)roomComboItem2);
		((ItemsControl)this.b5).Items.Add((object)roomComboItem2);
		((ItemsControl)this.b7).Items.Add((object)roomComboItem2);
		((ItemsControl)this.b9).Items.Add((object)roomComboItem2);
		foreach (Room room in TheGame.RoomList)
		{
			string empty = string.Empty;
			empty = ((!(room.SDesc == string.Empty)) ? (room.Name + " - " + room.SDesc) : room.Name);
			((ItemsControl)this.av).Items.Add((object)room);
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = room.UniqueID;
			roomComboItem3.RoomName = empty;
			((ItemsControl)this.ct).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bn).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bp).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bt).Items.Add((object)roomComboItem3);
			((ItemsControl)this.br).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bv).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bx).Items.Add((object)roomComboItem3);
			((ItemsControl)this.b1).Items.Add((object)roomComboItem3);
			((ItemsControl)this.bz).Items.Add((object)roomComboItem3);
			((ItemsControl)this.b3).Items.Add((object)roomComboItem3);
			((ItemsControl)this.b5).Items.Add((object)roomComboItem3);
			((ItemsControl)this.b7).Items.Add((object)roomComboItem3);
			((ItemsControl)this.b9).Items.Add((object)roomComboItem3);
			((ItemsControl)ei).Items.Add((object)roomComboItem3);
		}
		ar((object)null, (SelectionChangedEventArgs)null);
		if (TheGame.ThePlayer.StartingRoom != null)
		{
			((Selector)this.ct).SelectedItem = TheGame.ThePlayer.StartingRoom.Name;
		}
	}

	private void s()
	{
		((ItemsControl)this.am).Items.Clear();
		this.ae.Text = TheGame.OpeningMessage;
		((FrameworkElement)this.ae).Tag = TheGame.OpeningMessage;
		this.y.Text = TheGame.Title;
		((FrameworkElement)this.y).Tag = TheGame.Title;
		((ToggleButton)this.z).IsChecked = TheGame.bPasswordProtected;
		((FrameworkElement)this.z).Tag = TheGame.bPasswordProtected;
		this.aa.Password = TheGame.GamePassword;
		((FrameworkElement)this.aa).Tag = TheGame.GamePassword;
		((ToggleButton)this.af).IsChecked = TheGame.bHideMainPicDisplay;
		((FrameworkElement)this.af).Tag = TheGame.bHideMainPicDisplay;
		((ToggleButton)this.ag).IsChecked = TheGame.bUseInlineImages;
		((FrameworkElement)this.ag).Tag = TheGame.bUseInlineImages;
		((ToggleButton)this.ah).IsChecked = TheGame.bHidePortrait;
		((FrameworkElement)this.ah).Tag = TheGame.bHidePortrait;
		this.at.Text = TheGame.GameInformation;
		((FrameworkElement)this.at).Tag = TheGame.GameInformation;
		this.@as.Text = TheGame.GameVersion;
		((FrameworkElement)this.@as).Tag = TheGame.GameVersion;
		this.ar.Text = TheGame.AuthorName;
		((FrameworkElement)this.ar).Tag = TheGame.AuthorName;
		((ToggleButton)this.ab).IsChecked = TheGame.bTurnOffNotifications;
		((FrameworkElement)this.ab).Tag = TheGame.bTurnOffNotifications;
		((Selector)this.ak).SelectedIndex = (int)TheGame.SortOrderInventory;
		((FrameworkElement)this.ak).Tag = TheGame.SortOrderInventory;
		((Selector)this.aj).SelectedIndex = (int)TheGame.SortOrderCharacters;
		((FrameworkElement)this.aj).Tag = TheGame.SortOrderCharacters;
		((Selector)this.ai).SelectedIndex = (int)TheGame.SortOrderRoomObjects;
		((FrameworkElement)this.ai).Tag = TheGame.SortOrderRoomObjects;
		foreach (StatusBarItem statusBarItem in TheGame.StatusBarItems)
		{
			((ItemsControl)this.am).Items.Add((object)statusBarItem.Name);
		}
	}

	private void r()
	{
		((ItemsControl)this.d1).Items.Clear();
		((ItemsControl)d5).Items.Clear();
		foreach (string layeredClothingZone in TheGame.LayeredClothingZones)
		{
			((ItemsControl)this.d1).Items.Add((object)layeredClothingZone);
			((ItemsControl)d5).Items.Add((object)layeredClothingZone);
		}
		if (((CollectionView)((ItemsControl)d5).Items).Count > 0)
		{
			((Selector)d5).SelectedIndex = 0;
		}
		((Selector)d6).SelectedIndex = 0;
	}

	private void q()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		((ItemsControl)this.a5).Items.Clear();
		((ItemsControl)this.az).Items.Clear();
		foreach (string roomGroup in TheGame.RoomGroups)
		{
			((ItemsControl)this.a5).Items.Add((object)roomGroup);
			((ItemsControl)this.az).Items.Add((object)roomGroup);
		}
		((ItemsControl)this.a5).Items.Insert(0, (object)"None");
		MenuItem val = new MenuItem();
		((HeaderedItemsControl)val).Header = "None";
		((ItemsControl)this.az).Items.Insert(0, (object)val);
		((ItemsControl)this.a5).Items.Add((object)"<Add New Group>");
		((ItemsControl)this.az).Items.Add((object)"<Add New Group>");
	}

	private bool p()
	{
		if (!LockData.IsLicensed(bdisplay: false, this.m_b))
		{
			if (TheGame.RoomList.Count > 5)
			{
				return false;
			}
			if (TheGame.TimerList.Count > 5)
			{
				return false;
			}
			if (TheGame.CharacterList.Count > 5)
			{
				return false;
			}
			if (TheGame.ObjectList.Count > 10)
			{
				return false;
			}
			if (TheGame.VariableList.Count > 5)
			{
				return false;
			}
			if (TheGame.PictureList.Count > 10)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private void o()
	{
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		n();
		((ItemsControl)gt).Items.Clear();
		((ItemsControl)this.a7).Items.Clear();
		((ItemsControl)this.cx).Items.Clear();
		((ItemsControl)er).Items.Clear();
		((ItemsControl)this.ac).Items.Clear();
		((ItemsControl)this.a7).Items.Add((object)"None");
		((ItemsControl)this.cx).Items.Add((object)"None");
		((ItemsControl)er).Items.Add((object)"None");
		((ItemsControl)this.ac).Items.Add((object)string.Empty);
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			((ItemsControl)gt).Items.Add((object)TheGame.PictureList[i]);
			((ItemsControl)this.a7).Items.Add((object)TheGame.PictureList[i].TheName);
			((ItemsControl)this.cx).Items.Add((object)TheGame.PictureList[i].TheName);
			((ItemsControl)er).Items.Add((object)TheGame.PictureList[i].TheName);
			((ItemsControl)this.ac).Items.Add((object)TheGame.PictureList[i].TheName);
		}
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)gt).Items).SortDescriptions).Clear();
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.a7).Items).SortDescriptions).Clear();
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.cx).Items).SortDescriptions).Clear();
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)er).Items).SortDescriptions).Clear();
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.ac).Items).SortDescriptions).Clear();
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)gt).Items).SortDescriptions).Add(new SortDescription("TheName", ListSortDirection.Ascending));
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.a7).Items).SortDescriptions).Add(new SortDescription("", ListSortDirection.Ascending));
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.cx).Items).SortDescriptions).Add(new SortDescription("", ListSortDirection.Ascending));
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)er).Items).SortDescriptions).Add(new SortDescription("", ListSortDirection.Ascending));
		((Collection<SortDescription>)(object)((CollectionView)((ItemsControl)this.ac).Items).SortDescriptions).Add(new SortDescription("", ListSortDirection.Ascending));
	}

	private void n()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		((ItemsControl)g0).Items.Clear();
		TheGame.PictureList.Sort((GamePicture gamePicture2, GamePicture gamePicture3) =>
		{
			if (gamePicture2.TheName == null && gamePicture3.TheName == null)
			{
				return 0;
			}
			if (gamePicture2.TheName == null)
			{
				return -1;
			}
			return (gamePicture3.TheName == null) ? 1 : gamePicture2.TheName.CompareTo(gamePicture3.TheName);
		});
		TreeViewItem A_ = new TreeViewItem();
		a(ref A_, "Media");
		int count = ((CollectionView)((ItemsControl)A_).Items).Count;
		for (int num = 0; num < count; num++)
		{
			object obj = ((ItemsControl)A_).Items[0];
			TreeViewItem val = (TreeViewItem)((obj is TreeViewItem) ? obj : null);
			((ItemsControl)A_).Items.Remove((object)val);
			((ItemsControl)g0).Items.Add((object)val);
		}
		for (int num2 = 0; num2 < TheGame.PictureList.Count; num2++)
		{
			GamePicture gamePicture = TheGame.PictureList[num2];
			if (gamePicture.GroupName == string.Empty)
			{
				TreeViewItem val2 = new TreeViewItem();
				StackPanel val3 = new StackPanel();
				val3.Orientation = (Orientation)0;
				((FrameworkElement)val3).Height = 22.0;
				Image val4 = new Image();
				val4.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/media-icon.png"));
				((FrameworkElement)val4).Width = 16.0;
				((FrameworkElement)val4).Height = 16.0;
				Label val5 = new Label();
				((ContentControl)val5).Content = gamePicture.TheName;
				((FrameworkElement)val5).VerticalAlignment = (VerticalAlignment)1;
				((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
				((Control)val5).FontSize = 9.0;
				((Panel)val3).Children.Add((UIElement)(object)val4);
				((Panel)val3).Children.Add((UIElement)(object)val5);
				((HeaderedItemsControl)val2).Header = val3;
				((FrameworkElement)val2).Tag = gamePicture;
				((ItemsControl)g0).Items.Add((object)val2);
			}
		}
	}

	private void b(ref TreeViewItem A_0, string A_1)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected Obj, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected Obj, but got Unknown
		List<object> list = null;
		switch (A_1)
		{
		case "Media":
			list = ((IEnumerable<object>)TheGame.PictureList).ToList();
			break;
		case "Items":
			list = ((IEnumerable<object>)TheGame.ObjectList).ToList();
			break;
		case "Variables":
			list = ((IEnumerable<object>)TheGame.VariableList).ToList();
			break;
		}
		for (int i = 0; i < list.Count; i++)
		{
			string text = string.Empty;
			string content = string.Empty;
			switch (A_1)
			{
			case "Media":
			{
				GamePicture gamePicture = list[i] as GamePicture;
				text = gamePicture.GroupName;
				content = gamePicture.TheName;
				break;
			}
			case "Items":
			{
				GameObject gameObject = list[i] as GameObject;
				text = gameObject.GroupName;
				content = gameObject.name;
				break;
			}
			case "Variables":
			{
				GameVariable gameVariable = list[i] as GameVariable;
				text = gameVariable.GroupName;
				content = gameVariable.varname;
				break;
			}
			}
			if (text == ((FrameworkElement)A_0).Tag.ToString())
			{
				TreeViewItem val = new TreeViewItem();
				StackPanel val2 = new StackPanel();
				val2.Orientation = (Orientation)0;
				((FrameworkElement)val2).Height = 22.0;
				Image val3 = new Image();
				if (A_1 == "Media")
				{
					val3.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/media-icon.png"));
				}
				else
				{
					val3.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/object.png"));
				}
				((FrameworkElement)val3).Width = 16.0;
				((FrameworkElement)val3).Height = 16.0;
				Label val4 = new Label();
				((ContentControl)val4).Content = content;
				((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
				((Control)val4).FontSize = 9.0;
				((FrameworkElement)val3).VerticalAlignment = (VerticalAlignment)1;
				((Panel)val2).Children.Add((UIElement)(object)val3);
				((Panel)val2).Children.Add((UIElement)(object)val4);
				((HeaderedItemsControl)val).Header = val2;
				((FrameworkElement)val).Tag = list[i];
				((ItemsControl)A_0).Items.Add((object)val);
			}
		}
	}

	private void a(ref TreeViewItem A_0, string A_1)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Obj, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		try
		{
			string text = "MediaGroups";
			if (A_1 == "Items")
			{
				text = "ItemGroups";
			}
			else if (A_1 == "Variables")
			{
				text = "VariableGroups";
			}
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			string empty = string.Empty;
			empty = ((((HeaderedItemsControl)A_0).Header != null) ? ("Select Name from " + text + " where\r\n                        parent=@parent order by Name") : ("Select Name from " + text + " where\r\n                        parent is null or parent=@parent order by Name"));
			SqlCeCommand sqlCeCommand = new SqlCeCommand(empty, dBConnection);
			string value = string.Empty;
			if (((HeaderedItemsControl)A_0).Header != null)
			{
				object header = ((HeaderedItemsControl)A_0).Header;
				StackPanel val = (StackPanel)((header is StackPanel) ? header : null);
				if (val != null)
				{
					value = ((ContentControl)(Label)((Panel)val).Children[1]).Content.ToString();
				}
			}
			sqlCeCommand.Parameters.AddWithValue("@parent", value);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				TreeViewItem A_2 = new TreeViewItem();
				((FrameworkElement)A_2).Tag = sqlCeDataReader["Name"].ToString();
				StackPanel val2 = new StackPanel();
				val2.Orientation = (Orientation)0;
				((FrameworkElement)val2).Height = 22.0;
				Image val3 = new Image();
				val3.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/taskhs.png"));
				((FrameworkElement)val3).Width = 16.0;
				((FrameworkElement)val3).Height = 16.0;
				Label val4 = new Label();
				((ContentControl)val4).Content = sqlCeDataReader["Name"].ToString();
				((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
				((Control)val4).FontSize = 9.0;
				((FrameworkElement)val3).VerticalAlignment = (VerticalAlignment)1;
				((Panel)val2).Children.Add((UIElement)(object)val3);
				((Panel)val2).Children.Add((UIElement)(object)val4);
				((HeaderedItemsControl)A_2).Header = val2;
				((ItemsControl)A_0).Items.Add((object)A_2);
				b(ref A_2, A_1);
				a(ref A_2, A_1);
			}
		}
		catch
		{
		}
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		MessageBoxResult val = MessageBox.Show("Would you like to save before exiting?", "Save?", (MessageBoxButton)3);
		MessageBoxResult val2 = val;
		if ((int)val2 != 2)
		{
			if ((int)val2 == 6)
			{
				ar((object)null, (RoutedEventArgs)null);
			}
		}
		else
		{
			A_1.Cancel = true;
		}
		((SettingsBase)Settings.Default).Save();
	}

	private void e(object A_0, EventArgs A_1)
	{
		Application.Current.Shutdown();
	}

	private void ar(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)this.av).SelectedItems.Count == 1 && ((Selector)this.av).SelectedItem != null)
		{
			((UIElement)this.a1).IsEnabled = true;
			this.cj.SetObjectName(((Room)((Selector)this.av).SelectedItem).UniqueID.ToString());
			((UIElement)this.cj).IsEnabled = true;
			((UIElement)this.cb).IsEnabled = true;
			((UIElement)this.ba).IsEnabled = true;
			Room roomByID = TheGame.GetRoomByID(((Room)((Selector)this.av).SelectedItem).UniqueID);
			if (roomByID == null)
			{
				return;
			}
			((ContentControl)this.cc).Content = roomByID.Name;
			((ContentControl)this.a9).Content = roomByID.Name;
			this.a3.Text = roomByID.UniqueID.ToString();
			this.a2.Text = roomByID.Name;
			this.a6.Text = roomByID.Description;
			this.a4.Text = roomByID.SDesc;
			((Selector)this.a5).SelectedItem = roomByID.Group;
			if (string.Compare(roomByID.RoomPic, "None", ignoreCase: true) != 0)
			{
				((FrameworkElement)this.a8).Tag = SaveLoad.GetGamePictureByName(roomByID.RoomPic, ref TheGame);
				this.a8.Source = new Uri(SaveLoad.GetPictureByName(roomByID.RoomPic, ref TheGame).ToString());
				((Selector)this.a7).SelectedItem = roomByID.RoomPic;
			}
			else
			{
				if (((CollectionView)((ItemsControl)this.a7).Items).Count > 0)
				{
					((Selector)this.a7).SelectedItem = "None";
				}
				((FrameworkElement)this.a8).Tag = null;
				this.a8.Source = null;
			}
			string.Compare(roomByID.LayeredRoomPic, "None", ignoreCase: true);
			a(roomByID);
			this.cj.RefreshActions();
			l();
			m();
			aq((object)null, (SelectionChangedEventArgs)null);
		}
		else
		{
			((UIElement)this.a1).IsEnabled = false;
			((UIElement)this.cb).IsEnabled = false;
			((UIElement)this.ba).IsEnabled = false;
			((UIElement)this.cj).IsEnabled = false;
		}
	}

	private void m()
	{
		((ItemsControl)this.cd).Items.Clear();
		if (((ListBox)this.av).SelectedItems.Count != 1)
		{
			return;
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			Guid result = default;
			if (Guid.TryParse(@object.locationname, out result) && @object.locationtype == GameObject.LocationType.LT_ROOM && new Guid(@object.locationname) == ((Room)((Selector)this.av).SelectedItem).UniqueID)
			{
				((ItemsControl)this.cd).Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void l()
	{
		((ItemsControl)this.cg).Items.Clear();
		Room roomByID = TheGame.GetRoomByID(((Room)((Selector)this.av).SelectedItem).UniqueID);
		if (roomByID == null)
		{
			return;
		}
		foreach (CustomProperty customProperty in roomByID.CustomProperties)
		{
			((ItemsControl)this.cg).Items.Add((object)customProperty);
		}
	}

	private void a(Room A_0)
	{
		if (A_0.Exits.Count != 12)
		{
			A_0.FixExits();
		}
		((ToggleButton)this.bb).IsChecked = A_0.GetExit(Exit.Directions.North).bActive;
		((ToggleButton)this.bc).IsChecked = A_0.GetExit(Exit.Directions.South).bActive;
		((ToggleButton)this.be).IsChecked = A_0.GetExit(Exit.Directions.East).bActive;
		((ToggleButton)this.bd).IsChecked = A_0.GetExit(Exit.Directions.West).bActive;
		((ToggleButton)this.bf).IsChecked = A_0.GetExit(Exit.Directions.Up).bActive;
		((ToggleButton)this.bg).IsChecked = A_0.GetExit(Exit.Directions.Down).bActive;
		((ToggleButton)this.bh).IsChecked = A_0.GetExit(Exit.Directions.NorthWest).bActive;
		((ToggleButton)this.bi).IsChecked = A_0.GetExit(Exit.Directions.NorthEast).bActive;
		((ToggleButton)this.bj).IsChecked = A_0.GetExit(Exit.Directions.SouthWest).bActive;
		((ToggleButton)this.bk).IsChecked = A_0.GetExit(Exit.Directions.SouthEast).bActive;
		((ToggleButton)this.bl).IsChecked = A_0.GetExit(Exit.Directions.In).bActive;
		((ToggleButton)this.bm).IsChecked = A_0.GetExit(Exit.Directions.Out).bActive;
		a(ref this.bo);
		((ItemsControl)this.bo).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.bq);
		((ItemsControl)this.bq).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.bu);
		((ItemsControl)this.bu).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.bs);
		((ItemsControl)this.bs).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.bw);
		((ItemsControl)this.bw).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.by);
		((ItemsControl)this.by).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.b2);
		((ItemsControl)this.b2).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.b0);
		((ItemsControl)this.b0).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.b4);
		((ItemsControl)this.b4).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.b6);
		((ItemsControl)this.b6).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.b8);
		((ItemsControl)this.b8).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		a(ref this.ca);
		((ItemsControl)this.ca).Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		for (int i = 0; i < ((CollectionView)((ItemsControl)this.ca).Items).Count; i++)
		{
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.North).PortalObjectName)
			{
				((Selector)this.bo).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.South).PortalObjectName)
			{
				((Selector)this.bq).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.East).PortalObjectName)
			{
				((Selector)this.bu).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.West).PortalObjectName)
			{
				((Selector)this.bs).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Up).PortalObjectName)
			{
				((Selector)this.bw).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Down).PortalObjectName)
			{
				((Selector)this.by).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.NorthWest).PortalObjectName)
			{
				((Selector)this.b0).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.NorthEast).PortalObjectName)
			{
				((Selector)this.b2).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.SouthWest).PortalObjectName)
			{
				((Selector)this.b4).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.SouthEast).PortalObjectName)
			{
				((Selector)this.b6).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.In).PortalObjectName)
			{
				((Selector)this.b8).SelectedIndex = i;
			}
			if (((RoomComboItem)((ItemsControl)this.ca).Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Out).PortalObjectName)
			{
				((Selector)this.ca).SelectedIndex = i;
			}
		}
		if (A_0.GetExit(Exit.Directions.North).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.North).DestinationRoom != null)
		{
			a(ref this.bn, new Guid(A_0.GetExit(Exit.Directions.North).DestinationRoom));
		}
		else
		{
			this.bn.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.South).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.South).DestinationRoom != null)
		{
			a(ref this.bp, new Guid(A_0.GetExit(Exit.Directions.South).DestinationRoom));
		}
		else
		{
			this.bp.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.East).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.East).DestinationRoom != null)
		{
			a(ref this.bt, new Guid(A_0.GetExit(Exit.Directions.East).DestinationRoom));
		}
		else
		{
			this.bt.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.West).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.West).DestinationRoom != null)
		{
			a(ref this.br, new Guid(A_0.GetExit(Exit.Directions.West).DestinationRoom));
		}
		else
		{
			this.br.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Up).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Up).DestinationRoom != null)
		{
			a(ref this.bv, new Guid(A_0.GetExit(Exit.Directions.Up).DestinationRoom));
		}
		else
		{
			this.bv.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Down).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Down).DestinationRoom != null)
		{
			a(ref this.bx, new Guid(A_0.GetExit(Exit.Directions.Down).DestinationRoom));
		}
		else
		{
			this.bx.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom != null)
		{
			a(ref this.bz, new Guid(A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom));
		}
		else
		{
			this.bz.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom != null)
		{
			a(ref this.b1, new Guid(A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom));
		}
		else
		{
			this.b1.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom != null)
		{
			a(ref this.b3, new Guid(A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom));
		}
		else
		{
			this.b3.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom != null)
		{
			a(ref this.b5, new Guid(A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom));
		}
		else
		{
			this.b5.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.In).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.In).DestinationRoom != null)
		{
			a(ref this.b7, new Guid(A_0.GetExit(Exit.Directions.In).DestinationRoom));
		}
		else
		{
			this.b7.Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Out).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Out).DestinationRoom != null)
		{
			a(ref this.b9, new Guid(A_0.GetExit(Exit.Directions.Out).DestinationRoom));
		}
		else
		{
			this.b9.Text = "";
		}
	}

	private void a(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bOpenable)
			{
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(TheGame.ObjectList[i].UniqueIdentifier, TheGame.ObjectList[i].name));
			}
		}
	}

	private void a(ref ComboBox A_0, Guid A_1)
	{
		foreach (RoomComboItem item in (IEnumerable)((ItemsControl)A_0).Items)
		{
			if (item.UniqueID == A_1)
			{
				((Selector)A_0).SelectedItem = item;
				break;
			}
		}
	}

	private void aq(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)this.cg).SelectedItems.Count == 1 && ((Selector)this.cg).SelectedItem != null && ((Selector)this.cg).SelectedItem is CustomProperty customProperty)
		{
			this.ch.Text = customProperty.Name;
			this.ci.Text = customProperty.Value;
		}
	}

	private void c(object A_0, RoutedPropertyChangedEventArgs<object> A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
			((UIElement)ea).IsEnabled = true;
			if (gameObject != null)
			{
				((ContentControl)this.d0).Content = gameObject.name;
				this.c5.Text = gameObject.UniqueIdentifier.ToString();
				ea.SetObjectName(gameObject.UniqueIdentifier.ToString());
				this.c4.Text = gameObject.name;
				this.c8.Text = gameObject.description;
				this.c7.Text = gameObject.sdesc;
				this.c6.Text = gameObject.preposition;
				((ToggleButton)this.da).IsChecked = gameObject.bCarryable;
				((ToggleButton)this.dc).IsChecked = gameObject.bContainer;
				((ToggleButton)this.db).IsChecked = gameObject.bWearable;
				((ToggleButton)this.dd).IsChecked = gameObject.bOpenable;
				((UIElement)this.dq).IsEnabled = gameObject.bContainer;
				((ToggleButton)this.dm).IsChecked = gameObject.bLockable;
				((ToggleButton)this.dn).IsChecked = gameObject.bEnterable;
				((ToggleButton)this.@do).IsChecked = gameObject.bReadable;
				this.dp.Text = gameObject.dWeight.ToString();
				x();
				k();
				((UIElement)this.dz).IsEnabled = true;
				if (gameObject.bVisible)
				{
					((ToggleButton)this.dk).IsChecked = true;
				}
				else
				{
					((ToggleButton)this.dl).IsChecked = true;
				}
				if (gameObject.bOpen)
				{
					((ToggleButton)this.de).IsChecked = true;
				}
				else
				{
					((ToggleButton)this.df).IsChecked = true;
				}
				if (gameObject.bLocked)
				{
					((ToggleButton)this.di).IsChecked = true;
				}
				else
				{
					((ToggleButton)this.dj).IsChecked = true;
				}
				if (gameObject.bWorn)
				{
					((ToggleButton)this.dg).IsChecked = true;
				}
				else
				{
					((ToggleButton)this.dh).IsChecked = true;
				}
				((ToggleButton)this.c9).IsChecked = gameObject.bImportant;
				((UIElement)this.c8).IsEnabled = true;
				((UIElement)this.c4).IsEnabled = true;
				((UIElement)this.c7).IsEnabled = true;
				ea.RefreshActions();
				ab();
			}
		}
		else
		{
			((UIElement)this.dz).IsEnabled = false;
			((UIElement)this.c8).IsEnabled = false;
			((UIElement)this.c4).IsEnabled = false;
			((UIElement)this.c7).IsEnabled = false;
			((UIElement)ea).IsEnabled = false;
		}
	}

	private void k()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)d4).Items.Clear();
		if (!(((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject))
		{
			return;
		}
		foreach (string layeredZoneLevel in gameObject.LayeredZoneLevels)
		{
			((ItemsControl)d4).Items.Add((object)layeredZoneLevel);
		}
	}

	private void ap(object A_0, SelectionChangedEventArgs A_1)
	{
		ew.Text = string.Empty;
		ev.Text = string.Empty;
		if (((ListBox)eu).SelectedItems.Count == 1 && ((Selector)eu).SelectedItem != null && ((Selector)eu).SelectedItem is CustomProperty customProperty)
		{
			ev.Text = customProperty.Name;
			ew.Text = customProperty.Value;
		}
	}

	private void ao(object A_0, SelectionChangedEventArgs A_1)
	{
		gn.Text = string.Empty;
		go.Text = string.Empty;
		if (((ListBox)gm).SelectedItems.Count == 1 && ((Selector)gm).SelectedItem is CustomProperty customProperty)
		{
			gn.Text = customProperty.Name;
			go.Text = customProperty.Value;
		}
	}

	private void an(object A_0, SelectionChangedEventArgs A_1)
	{
		fz.Text = string.Empty;
		f0.Text = string.Empty;
		if (((ListBox)fy).SelectedItems.Count == 1 && ((Selector)fy).SelectedItem is CustomProperty customProperty)
		{
			fz.Text = customProperty.Name;
			f0.Text = customProperty.Value;
		}
	}

	private void am(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)eb).SelectedItems.Count == 1)
		{
			if (!(((Selector)eb).SelectedItem is Character character))
			{
				return;
			}
			((ContentControl)eg).Content = character.Charname;
			e0.SetObjectName(character.Charname);
			((ToggleButton)ej).IsChecked = character.bAllowInventoryInteraction;
			if (character == null)
			{
				return;
			}
			foreach (RoomComboItem item in (IEnumerable)((ItemsControl)ei).Items)
			{
				if (item.UniqueID.ToString() == character.CurrentRoom)
				{
					((Selector)ei).SelectedItem = item;
					break;
				}
			}
			((UIElement)er).IsEnabled = true;
			if (character.CharPortrait != string.Empty)
			{
				((Selector)er).SelectedItem = character.CharPortrait;
			}
			else
			{
				((Selector)er).SelectedItem = "None";
			}
			eo.Text = character.Description;
			eh.Text = character.CharnameOverride;
			if (character != null)
			{
				switch (character.CharGender)
				{
				case Player.Gender.Female:
					((ToggleButton)em).IsChecked = true;
					break;
				case Player.Gender.Male:
					((ToggleButton)el).IsChecked = true;
					break;
				case Player.Gender.Other:
					((ToggleButton)en).IsChecked = true;
					break;
				}
				x();
				((UIElement)e0).IsEnabled = true;
				((UIElement)ep).IsEnabled = true;
				((UIElement)ek).IsEnabled = true;
				((UIElement)et).IsEnabled = true;
				((UIElement)e0).IsEnabled = true;
				((UIElement)eo).IsEnabled = true;
				((UIElement)ei).IsEnabled = true;
				((UIElement)ej).IsEnabled = true;
				e0.RefreshActions();
				ae();
			}
		}
		else
		{
			((UIElement)ep).IsEnabled = false;
			((UIElement)er).IsEnabled = false;
			((UIElement)ek).IsEnabled = false;
			((UIElement)et).IsEnabled = false;
			((UIElement)e0).IsEnabled = false;
			((UIElement)ei).IsEnabled = false;
			((UIElement)eo).IsEnabled = false;
			((UIElement)ej).IsEnabled = false;
		}
	}

	private void b(object A_0, RoutedPropertyChangedEventArgs<object> A_1)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)ft).Items.Clear();
		if (e1.SelectedItem != null && ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag != null)
		{
			fh.Text = "";
			((ToggleButton)fs).IsChecked = false;
			((UIElement)fg).IsEnabled = true;
			((UIElement)e7).IsEnabled = true;
			((UIElement)fe).IsEnabled = true;
			((UIElement)fu).IsEnabled = true;
			if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable)
			{
				ff.Text = gameVariable.VarComment;
				((ContentControl)e6).Content = gameVariable.varname;
				switch (gameVariable.vartype)
				{
				case GameVariable.VarType.VT_STRING:
					((ToggleButton)fa).IsChecked = true;
					fh.Text = gameVariable.sString;
					((UIElement)fh).Visibility = (Visibility)0;
					((UIElement)fi).Visibility = (Visibility)1;
					((UIElement)fj).Visibility = (Visibility)1;
					((UIElement)fu).Visibility = (Visibility)1;
					((UIElement)ft).Visibility = (Visibility)0;
					break;
				case GameVariable.VarType.VT_STRINGARRAY:
					((ToggleButton)fb).IsChecked = true;
					fh.Text = gameVariable.sString;
					((UIElement)fh).Visibility = (Visibility)0;
					((UIElement)fi).Visibility = (Visibility)1;
					((UIElement)fj).Visibility = (Visibility)1;
					j();
					break;
				case GameVariable.VarType.VT_NUMBER:
					((ToggleButton)e8).IsChecked = true;
					fk.Text = gameVariable.dNumType.ToString();
					((ToggleButton)fl).IsChecked = gameVariable.bEnforceRestrictions;
					dy(null, null);
					fm.Text = gameVariable.dMin.ToString();
					fn.Text = gameVariable.dMax.ToString();
					((UIElement)fh).Visibility = (Visibility)1;
					((UIElement)fi).Visibility = (Visibility)1;
					((UIElement)fj).Visibility = (Visibility)0;
					((UIElement)fu).Visibility = (Visibility)1;
					((UIElement)ft).Visibility = (Visibility)0;
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
					((ToggleButton)e9).IsChecked = true;
					fk.Text = gameVariable.dNumType.ToString();
					((ToggleButton)fl).IsChecked = gameVariable.bEnforceRestrictions;
					dy(null, null);
					fm.Text = gameVariable.dMin.ToString();
					fn.Text = gameVariable.dMax.ToString();
					((UIElement)fh).Visibility = (Visibility)1;
					((UIElement)fi).Visibility = (Visibility)1;
					((UIElement)fj).Visibility = (Visibility)0;
					j();
					break;
				case GameVariable.VarType.VT_DATETIME:
					((ToggleButton)fc).IsChecked = true;
					fi.Value = gameVariable.dtDateTime;
					((UIElement)fh).Visibility = (Visibility)1;
					((UIElement)fi).Visibility = (Visibility)0;
					((UIElement)fj).Visibility = (Visibility)1;
					((UIElement)fu).Visibility = (Visibility)1;
					((UIElement)ft).Visibility = (Visibility)0;
					break;
				case GameVariable.VarType.VT_DATETIMEARRAY:
					((ToggleButton)fd).IsChecked = true;
					fi.Value = gameVariable.dtDateTime;
					((UIElement)fh).Visibility = (Visibility)1;
					((UIElement)fi).Visibility = (Visibility)0;
					((UIElement)fj).Visibility = (Visibility)1;
					j();
					break;
				}
				ah();
			}
		}
		else
		{
			((ContentControl)e6).Content = "";
			fh.Text = "";
			((UIElement)fg).IsEnabled = false;
			((UIElement)e7).IsEnabled = false;
			((UIElement)fe).IsEnabled = false;
			((UIElement)fu).IsEnabled = false;
		}
	}

	private void j()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int num = ((Selector)ft).SelectedIndex;
		((ItemsControl)ft).Items.Clear();
		if (!(((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable))
		{
			return;
		}
		List<string> list = null;
		if (gameVariable.VarArray.Count > 0)
		{
			list = gameVariable.VarArray[0] as List<string>;
		}
		if (gameVariable.VarArray.Count > 0 && list != null)
		{
			((UIElement)fu).Visibility = (Visibility)0;
			((UIElement)fo).IsEnabled = true;
			((UIElement)fp).IsEnabled = false;
			((UIElement)fq).IsEnabled = false;
			((UIElement)fr).IsEnabled = false;
			((UIElement)ft).Visibility = (Visibility)1;
			((ToggleButton)fs).IsChecked = true;
			DataTable dataTable = new DataTable("TestTable");
			for (int i = 0; i < list.Count; i++)
			{
				dataTable.Columns.Add(i.ToString());
			}
			((ItemsControl)fu).ItemsSource = dataTable.DefaultView;
			for (int j = 0; j < gameVariable.VarArray.Count; j++)
			{
				List<string> list2 = null;
				list2 = gameVariable.VarArray[j] as List<string>;
				dataTable.Rows.Add(list2.ToArray());
			}
		}
		else
		{
			((ToggleButton)fs).IsChecked = false;
			((UIElement)fu).Visibility = (Visibility)1;
			((UIElement)ft).Visibility = (Visibility)0;
			((UIElement)fo).IsEnabled = true;
			((UIElement)fp).IsEnabled = true;
			((UIElement)fq).IsEnabled = true;
			((UIElement)fr).IsEnabled = true;
			GameVariable.VarType vartype = gameVariable.vartype;
			if (vartype == GameVariable.VarType.VT_DATETIMEARRAY)
			{
				foreach (DateTime item in gameVariable.VarArray)
				{
					((ItemsControl)ft).Items.Add((object)(((CollectionView)((ItemsControl)ft).Items).Count.ToString("000") + " : " + item.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt")));
				}
			}
			else
			{
				foreach (object item2 in gameVariable.VarArray)
				{
					((ItemsControl)ft).Items.Add((object)(((CollectionView)((ItemsControl)ft).Items).Count.ToString("000") + " : " + item2.ToString()));
				}
			}
		}
		if (num != -1)
		{
			if (num > ((CollectionView)((ItemsControl)ft).Items).Count - 1)
			{
				num = ((CollectionView)((ItemsControl)ft).Items).Count - 1;
			}
			((Selector)ft).SelectedIndex = num;
		}
	}

	private void dz(object A_0, RoutedEventArgs A_1)
	{
		d((object)null, (EventArgs)null);
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Invalid comparison between Unknown and I4
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		if (((ToggleButton)fs).IsChecked == true)
		{
			GetDimensionWidthWindow getDimensionWidthWindow = new GetDimensionWidthWindow();
			((Window)getDimensionWidthWindow).Owner = (Window)(object)this;
			if (gameVariable.VarArray.Count > 0 && gameVariable.VarArray[0] is ArrayList)
			{
				return;
			}
			if (((Window)getDimensionWidthWindow).ShowDialog() == true)
			{
				((ItemsControl)fu).ItemsSource = null;
				gameVariable.VarArray.Clear();
				((UIElement)fu).Visibility = (Visibility)0;
				((UIElement)ft).Visibility = (Visibility)1;
				DataTable dataTable = new DataTable("TestTable");
				int num = Convert.ToInt32(getDimensionWidthWindow.a.Text);
				for (int i = 0; i < num; i++)
				{
					dataTable.Columns.Add(i.ToString());
				}
				((ItemsControl)fu).ItemsSource = dataTable.DefaultView;
			}
			else
			{
				((ToggleButton)fs).IsChecked = false;
			}
		}
		else if (gameVariable.VarArray.Count > 0 && gameVariable.VarArray[0] is ArrayList)
		{
			if ((int)MessageBox.Show("Warning, this may result in loss of data.  Do you wish to continue?", "Warning", (MessageBoxButton)4, (MessageBoxImage)48) == 6)
			{
				((UIElement)ft).Visibility = (Visibility)0;
				((UIElement)fu).Visibility = (Visibility)1;
				gameVariable.VarArray.Clear();
				b((object)null, (RoutedPropertyChangedEventArgs<object>)null);
			}
			else
			{
				((ToggleButton)fs).IsChecked = true;
			}
		}
		else
		{
			((UIElement)ft).Visibility = (Visibility)0;
			((UIElement)fu).Visibility = (Visibility)1;
			gameVariable.VarArray.Clear();
			b((object)null, (RoutedPropertyChangedEventArgs<object>)null);
		}
	}

	private void dy(object A_0, RoutedEventArgs A_1)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)fm).IsEnabled = ((ToggleButton)fl).IsChecked.Value;
		((UIElement)fn).IsEnabled = ((ToggleButton)fl).IsChecked.Value;
		((GameVariable)((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag).bEnforceRestrictions = ((ToggleButton)fl).IsChecked.Value;
	}

	private void a(object A_0, DataGridRowEventArgs A_1)
	{
		A_1.Row.Header = A_1.Row.GetIndex().ToString("000");
	}

	private void al(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)f4).SelectedItems.Count == 1)
		{
			Rags.Timer timer = (Rags.Timer)((Selector)f4).SelectedItem;
			((UIElement)gs).IsEnabled = true;
			if (timer != null)
			{
				((ContentControl)f9).Content = timer.Name;
				gs.SetObjectName(timer.Name);
				((ToggleButton)gj).IsChecked = timer.LiveTimer;
				if (timer.TType == Rags.Timer.TimerType.TT_RUNALWAYS)
				{
					((ToggleButton)gd).IsChecked = true;
				}
				else
				{
					((ToggleButton)ge).IsChecked = true;
				}
				gg.Text = timer.Length.ToString();
				((ToggleButton)gh).IsChecked = timer.Restart;
				((ToggleButton)gl).IsChecked = timer.Active;
				gk.Text = timer.TimerSeconds.ToString();
				((UIElement)gc).IsEnabled = true;
				((UIElement)gf).IsEnabled = true;
				((UIElement)gl).IsEnabled = true;
				((UIElement)gs).IsEnabled = true;
				((UIElement)ga).IsEnabled = true;
				((UIElement)gf).IsEnabled = !((ToggleButton)gd).IsChecked.Value;
				((UIElement)gi).IsEnabled = true;
				gs.RefreshActions();
				ag();
			}
		}
		else
		{
			((UIElement)gc).IsEnabled = false;
			((UIElement)gf).IsEnabled = false;
			((UIElement)gl).IsEnabled = false;
			((UIElement)gs).IsEnabled = false;
			((UIElement)ga).IsEnabled = false;
			((UIElement)gi).IsEnabled = false;
		}
	}

	private void ak(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Obj, but got Unknown
		((ItemsControl)gw).Items.Clear();
		if (((CollectionView)((ItemsControl)gt).Items).Count <= 0 || ((ListBox)gt).SelectedItems.Count <= 0)
		{
			return;
		}
		GamePicture gamePicture = ((Selector)gt).SelectedItem as GamePicture;
		gv.Source = new Uri(SaveLoad.GetPictureByName(gamePicture.TheName, ref TheGame).ToString());
		if (gamePicture == null)
		{
			return;
		}
		if (((Panel)gu).Children.Count > 1)
		{
			((Panel)gu).Children.RemoveRange(1, ((Panel)gu).Children.Count - 1);
		}
		SaveLoad.GetPictureByName(gamePicture.TheName, ref TheGame);
		foreach (string layeredImage in gamePicture.LayeredImages)
		{
			Image val = new Image();
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), layeredImage));
			((Panel)gu).Children.Add((UIElement)(object)val);
			((ItemsControl)gw).Items.Add((object)SaveLoad.GetGamePictureByName(layeredImage, ref TheGame));
		}
		((FrameworkElement)gv).Tag = gamePicture;
	}

	private void i(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent("MediaFormat") || A_0 == ((RoutedEventArgs)A_1).Source)
		{
			A_1.Effects = (DragDropEffects)0;
		}
	}

	private void h(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent("MediaFormat") || !(A_1.Data.GetData("MediaFormat") is GamePicture gamePicture))
		{
			return;
		}
		bool flag = false;
		foreach (GamePicture item in (IEnumerable)((ItemsControl)gw).Items)
		{
			if (item.TheName == gamePicture.TheName)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			((ItemsControl)gw).Items.Add((object)gamePicture);
			if (((Selector)gt).SelectedItem is GamePicture gamePicture3)
			{
				gamePicture3.LayeredImages.Add(gamePicture.TheName);
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture3.TheName);
				sqlCeCommand.Parameters.AddWithValue("@data", gamePicture.TheName);
				sqlCeCommand.Parameters.AddWithValue("@order", gamePicture3.LayeredImages.Count);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
				ak((object)null, (SelectionChangedEventArgs)null);
			}
		}
	}

	private void e(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		this.m_d = ((MouseEventArgs)A_1).GetPosition((IInputElement)null);
	}

	private void c(object A_0, MouseEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (g0.SelectedItem == null || !((UIElement)(TreeViewItem)g0.SelectedItem).IsMouseOver)
		{
			return;
		}
		Point position = A_1.GetPosition((IInputElement)null);
		Vector val = this.m_d - position;
		if ((int)A_1.LeftButton == 1 && (Math.Abs(val.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(val.Y) > SystemParameters.MinimumVerticalDragDistance))
		{
			if (!(((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture gamePicture))
			{
				object obj = new object();
				DataObject val2 = new DataObject("MediaFormat", obj);
				DragDrop.DoDragDrop((DependencyObject)(object)g0, (object)val2, (DragDropEffects)1);
			}
			else
			{
				DataObject val3 = new DataObject("MediaFormat", (object)gamePicture);
				DragDrop.DoDragDrop((DependencyObject)(object)g0, (object)val3, (DragDropEffects)1);
			}
		}
	}

	private void dx(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)gw).SelectedItem == null || ((ListBox)gt).SelectedItems.Count <= 0 || !(((Selector)gt).SelectedItem is GamePicture gamePicture))
		{
			return;
		}
		foreach (string layeredImage in gamePicture.LayeredImages)
		{
			if (!(layeredImage == ((Selector)gw).SelectedItem.ToString()))
			{
				continue;
			}
			gamePicture.LayeredImages.Remove(layeredImage);
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
			int num = 0;
			foreach (string layeredImage2 in gamePicture.LayeredImages)
			{
				num++;
				sqlCeCommand = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
				sqlCeCommand.Parameters.AddWithValue("@data", layeredImage2);
				sqlCeCommand.Parameters.AddWithValue("@order", num);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
			}
			break;
		}
		ak((object)null, (SelectionChangedEventArgs)null);
	}

	private void dw(object A_0, RoutedEventArgs A_1)
	{
		if (((CollectionView)((ItemsControl)gw).Items).Count <= 1 || ((Selector)gw).SelectedIndex == ((CollectionView)((ItemsControl)gw).Items).Count - 1 || ((ListBox)gt).SelectedItems.Count == 0 || !(((Selector)gt).SelectedItem is GamePicture gamePicture))
		{
			return;
		}
		int selectedIndex = ((Selector)gw).SelectedIndex;
		string text = ((ItemsControl)gw).Items[selectedIndex].ToString();
		gamePicture.LayeredImages.RemoveAt(selectedIndex);
		gamePicture.LayeredImages.Insert(selectedIndex + 1, text);
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		int num = 0;
		foreach (string layeredImage in gamePicture.LayeredImages)
		{
			num++;
			sqlCeCommand = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
			sqlCeCommand.Parameters.AddWithValue("@data", layeredImage);
			sqlCeCommand.Parameters.AddWithValue("@order", num);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		ak((object)null, (SelectionChangedEventArgs)null);
		((Selector)gw).SelectedItem = text;
	}

	private void dv(object A_0, RoutedEventArgs A_1)
	{
		if (((CollectionView)((ItemsControl)gw).Items).Count <= 1 || ((Selector)gw).SelectedIndex == 0 || ((ListBox)gt).SelectedItems.Count == 0 || !(((Selector)gt).SelectedItem is GamePicture gamePicture))
		{
			return;
		}
		int selectedIndex = ((Selector)gw).SelectedIndex;
		string text = ((ItemsControl)gw).Items[selectedIndex].ToString();
		gamePicture.LayeredImages.RemoveAt(selectedIndex);
		gamePicture.LayeredImages.Insert(selectedIndex - 1, text);
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		int num = 0;
		foreach (string layeredImage in gamePicture.LayeredImages)
		{
			num++;
			sqlCeCommand = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@medianame", gamePicture.TheName);
			sqlCeCommand.Parameters.AddWithValue("@data", layeredImage);
			sqlCeCommand.Parameters.AddWithValue("@order", num);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		ak((object)null, (SelectionChangedEventArgs)null);
		((Selector)gw).SelectedItem = text;
	}

	private void a(object A_0, RoutedPropertyChangedEventArgs<object> A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g0.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture gamePicture)
		{
			object pictureByName = SaveLoad.GetPictureByName(gamePicture.TheName, ref TheGame);
			g6.Source = new Uri(pictureByName.ToString());
		}
	}

	private void du(object A_0, RoutedEventArgs A_1)
	{
	}

	private void dt(object A_0, RoutedEventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		DataGridCellInfo val = fu.SelectedCells[0];
		if (val.Item is DataRowView dataRowView)
		{
			DataTable table = ((DataView)((ItemsControl)fu).ItemsSource).Table;
			int index = table.Rows.IndexOf(dataRowView.Row);
			List<string> list = null;
			GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
			gameVariable.VarArray.Insert(index, new List<string>());
			list = (List<string>)gameVariable.VarArray[index];
			for (int i = 0; i < fu.Columns.Count; i++)
			{
				list.Add("");
			}
			j();
		}
	}

	private void ds(object A_0, RoutedEventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		DataGridCellInfo val = fu.SelectedCells[0];
		if (val.Item is DataRowView dataRowView)
		{
			DataTable table = ((DataView)((ItemsControl)fu).ItemsSource).Table;
			int index = table.Rows.IndexOf(dataRowView.Row);
			GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
			gameVariable.VarArray.RemoveAt(index);
			i();
			j();
		}
	}

	private void i()
	{
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (e1.SelectedItem == null || ((FrameworkElement)fu).Tag == null || !(bool)((FrameworkElement)fu).Tag)
		{
			return;
		}
		((FrameworkElement)fu).Tag = false;
		if (!(((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable))
		{
			return;
		}
		gameVariable.VarArray = new List<object>();
		DataTable table = ((DataView)((ItemsControl)fu).ItemsSource).Table;
		foreach (DataRow row in table.Rows)
		{
			List<string> list = new List<string>();
			object[] itemArray = row.ItemArray;
			foreach (object obj in itemArray)
			{
				string item = string.Empty;
				if (obj != null)
				{
					item = obj as string;
				}
				list.Add(item);
			}
			gameVariable.VarArray.Add(list);
		}
	}

	private void a(object A_0, DataGridCellEditEndingEventArgs A_1)
	{
		((FrameworkElement)fu).Tag = true;
	}

	private void b(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.SystemKey != 65 || (!Keyboard.IsKeyDown((Key)120) && !Keyboard.IsKeyDown((Key)121)))
		{
			return;
		}
		((RoutedEventArgs)A_1).Handled = true;
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = 0;
		}
		if (val != null)
		{
			startIndex = val.SelectionStart;
		}
		InsertVariableWindow insertVariableWindow = new InsertVariableWindow(ref TheGame);
		((Window)insertVariableWindow).Owner = (Window)(object)this;
		string text = string.Empty;
		if (((Window)insertVariableWindow).ShowDialog() == true)
		{
			switch (((Selector)insertVariableWindow.thetabctrl).SelectedIndex)
			{
			case 0:
				if (((Selector)insertVariableWindow.sysvars).SelectedItem != null)
				{
					text = ((ContentControl)(ListBoxItem)((Selector)insertVariableWindow.sysvars).SelectedItem).Content.ToString();
				}
				break;
			case 1:
				if (((Selector)insertVariableWindow.vars).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.vars).SelectedItem.ToString();
				}
				break;
			case 2:
				if (((Selector)insertVariableWindow.custprop).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.custprop).SelectedItem.ToString();
				}
				break;
			case 3:
				text = insertVariableWindow.thetext.Text;
				break;
			}
		}
		if (text != string.Empty)
		{
			if (val != null)
			{
				val.Text = val.Text.Insert(startIndex, text);
			}
			else if (val2 != null)
			{
				val2.Text = val2.Text.Insert(startIndex, text);
			}
		}
	}

	private void d(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		RagsEditor ragsEditor = new RagsEditor(A_0, TheGame);
		((Window)ragsEditor).Owner = (Window)(object)this;
		ragsEditor.TBDATA = ((TextBox)A_0).Text;
		((Window)ragsEditor).ShowDialog();
	}

	private void c(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (fu.SelectedCells.Count != 0)
		{
			DataGridCellInfo val = fu.SelectedCells[0];
			DataGridColumn column = val.Column;
			DataGridCellInfo val2 = fu.SelectedCells[0];
			FrameworkElement cellContent = column.GetCellContent(val2.Item);
			TextBox val3 = (TextBox)(object)((cellContent is TextBox) ? cellContent : null);
			if (val3 != null)
			{
				d((object)val3, (MouseButtonEventArgs)null);
			}
		}
	}

	private void dr(object A_0, RoutedEventArgs A_1)
	{
		RegistrationWindow registrationWindow = new RegistrationWindow();
		((Window)registrationWindow).Owner = (Window)(object)this;
		((Window)registrationWindow).ShowDialog();
	}

	private void dq(object A_0, RoutedEventArgs A_1)
	{
		AboutWindow aboutWindow = new AboutWindow();
		((Window)aboutWindow).Owner = (Window)(object)this;
		((Window)aboutWindow).ShowDialog();
	}

	private void dp(object A_0, RoutedEventArgs A_1)
	{
		TheGame.Title = this.y.Text;
	}

	private void @do(object A_0, RoutedEventArgs A_1)
	{
		TheGame.GamePassword = EncDec.ComputeHash(this.aa.Password, "SHA1", null);
	}

	private void dn(object A_0, RoutedEventArgs A_1)
	{
		TheGame.OpeningMessage = this.ae.Text;
	}

	private void dm(object A_0, RoutedEventArgs A_1)
	{
		TheGame.AuthorName = this.ar.Text;
	}

	private void dl(object A_0, RoutedEventArgs A_1)
	{
		TheGame.GameVersion = this.@as.Text;
	}

	private void dk(object A_0, RoutedEventArgs A_1)
	{
		TheGame.GameInformation = this.at.Text;
	}

	private void dj(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bPasswordProtected = ((ToggleButton)this.z).IsChecked.Value;
	}

	private void di(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bTurnOffNotifications = ((ToggleButton)this.ab).IsChecked.Value;
	}

	private void dh(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bRepeatbgMusic = ((ToggleButton)this.ad).IsChecked.Value;
	}

	private void aj(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.ac).SelectedItem != null)
		{
			TheGame.bgMusic = ((Selector)this.ac).SelectedItem.ToString();
		}
	}

	private void dg(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bHideMainPicDisplay = ((ToggleButton)this.af).IsChecked.Value;
	}

	private void df(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bUseInlineImages = ((ToggleButton)this.ag).IsChecked.Value;
	}

	private void de(object A_0, RoutedEventArgs A_1)
	{
		TheGame.bHidePortrait = ((ToggleButton)this.ah).IsChecked.Value;
	}

	private void ai(object A_0, SelectionChangedEventArgs A_1)
	{
		TheGame.SortOrderRoomObjects = (Game.SortOrder)((Selector)this.ai).SelectedIndex;
	}

	private void ah(object A_0, SelectionChangedEventArgs A_1)
	{
		TheGame.SortOrderCharacters = (Game.SortOrder)((Selector)this.aj).SelectedIndex;
	}

	private void ag(object A_0, SelectionChangedEventArgs A_1)
	{
		TheGame.SortOrderInventory = (Game.SortOrder)((Selector)this.ak).SelectedIndex;
	}

	private void dd(object A_0, RoutedEventArgs A_1)
	{
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Add A New Status Item";
		if (((Window)getNameWindow).ShowDialog() == true)
		{
			StatusBarItem statusBarItem = new StatusBarItem();
			statusBarItem.Name = getNameWindow.txtEntry.Text;
			TheGame.StatusBarItems.Add(statusBarItem);
			int selectedIndex = ((ItemsControl)this.am).Items.Add((object)getNameWindow.txtEntry.Text);
			((Selector)this.am).SelectedIndex = selectedIndex;
		}
	}

	private void dc(object A_0, RoutedEventArgs A_1)
	{
		if (this.am.SelectedItems.Count == 1)
		{
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(((Selector)this.am).SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				statusBarItemByName.Text = this.al.Text;
				SaveLoad.ValidateText(this.al.Text, ref TheGame);
			}
		}
	}

	private void db(object A_0, RoutedEventArgs A_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (this.am.SelectedItems.Count == 1)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(this.an.Text);
			}
			catch
			{
				MessageBox.Show("You must enter a valid number in the status width field.");
				((UIElement)this.an).Focus();
				return;
			}
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(((Selector)this.am).SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				statusBarItemByName.Width = num;
			}
		}
	}

	private void da(object A_0, RoutedEventArgs A_1)
	{
		StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(((Selector)this.am).SelectedItem.ToString());
		if (statusBarItemByName != null)
		{
			statusBarItemByName.bVisisble = ((ToggleButton)this.ap).IsChecked.Value;
		}
	}

	private void c9(object A_0, RoutedEventArgs A_1)
	{
		StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(((Selector)this.am).SelectedItem.ToString());
		if (statusBarItemByName != null)
		{
			TheGame.StatusBarItems.Remove(statusBarItemByName);
			((ItemsControl)this.am).Items.Remove(((Selector)this.am).SelectedItem);
			this.al.Text = "";
			this.an.Text = "0";
		}
	}

	private void c8(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.am).SelectedIndex != -1)
		{
			int selectedIndex = ((Selector)this.am).SelectedIndex;
			if (selectedIndex != 0)
			{
				StatusBarItem item = TheGame.StatusBarItems[((Selector)this.am).SelectedIndex];
				TheGame.StatusBarItems.Remove(item);
				TheGame.StatusBarItems.Insert(selectedIndex - 1, item);
				s();
			}
		}
	}

	private void c7(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.am).SelectedIndex != -1)
		{
			int selectedIndex = ((Selector)this.am).SelectedIndex;
			if (selectedIndex != ((CollectionView)((ItemsControl)this.am).Items).Count - 1)
			{
				StatusBarItem item = TheGame.StatusBarItems[((Selector)this.am).SelectedIndex];
				TheGame.StatusBarItems.Remove(item);
				TheGame.StatusBarItems.Insert(selectedIndex + 1, item);
				s();
			}
		}
	}

	private void af(object A_0, SelectionChangedEventArgs A_1)
	{
		if (this.am.SelectedItems.Count == 1)
		{
			((UIElement)this.an).IsEnabled = true;
			((UIElement)this.al).IsEnabled = true;
			((UIElement)this.ap).IsEnabled = true;
			((UIElement)this.ao).IsEnabled = true;
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(((Selector)this.am).SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				this.al.Text = statusBarItemByName.Text;
				this.an.Text = statusBarItemByName.Width.ToString();
				((ToggleButton)this.ap).IsChecked = statusBarItemByName.bVisisble;
			}
		}
		else
		{
			((UIElement)this.an).IsEnabled = false;
			((UIElement)this.al).IsEnabled = false;
			((UIElement)this.ao).IsEnabled = false;
			((UIElement)this.ap).IsEnabled = false;
		}
	}

	private void c6(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.av).SelectedItem is Room room)
		{
			room.SDesc = this.a4.Text;
			SaveLoad.ValidateText(this.a4.Text, ref TheGame);
		}
	}

	private void ae(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.a5).SelectedIndex == -1)
		{
			return;
		}
		if (((Selector)this.a5).SelectedIndex == ((CollectionView)((ItemsControl)this.a5).Items).Count - 1)
		{
			GetNameWindow getNameWindow = new GetNameWindow();
			((ContentControl)getNameWindow.lblTitle).Content = "Enter new room group name:";
			((Window)getNameWindow).Owner = (Window)(object)this;
			if (((Window)getNameWindow).ShowDialog() == true)
			{
				if (getNameWindow.txtEntry.Text.Trim() != string.Empty && getNameWindow.txtEntry.Text.Trim() != "<Add New Room>")
				{
					TheGame.RoomGroups.Add(getNameWindow.txtEntry.Text);
					q();
					((Selector)this.a5).SelectedItem = getNameWindow.txtEntry.Text;
					if (((Selector)this.av).SelectedItem is Room room)
					{
						room.Group = getNameWindow.txtEntry.Text;
					}
				}
			}
			else
			{
				((Selector)this.a5).SelectedItem = "None";
			}
		}
		else if (((Selector)this.av).SelectedItem is Room room2)
		{
			room2.Group = ((Selector)this.a5).SelectedItem.ToString();
		}
	}

	private void c5(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.av).SelectedItem is Room room)
		{
			room.Description = this.a6.Text;
			SaveLoad.ValidateText(this.a6.Text, ref TheGame);
		}
	}

	private void ad(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.a7).SelectedIndex == -1)
		{
			return;
		}
		if (string.Compare(((ItemsControl)this.a7).Items[((Selector)this.a7).SelectedIndex].ToString(), "None", ignoreCase: true) != 0)
		{
			object pictureByName = SaveLoad.GetPictureByName(((Selector)this.a7).SelectedItem.ToString(), ref TheGame);
			this.a8.Source = new Uri(pictureByName.ToString());
			if (((Selector)this.av).SelectedItem is Room room)
			{
				room.RoomPic = ((Selector)this.a7).SelectedItem.ToString();
			}
		}
		else
		{
			((FrameworkElement)this.a8).Tag = null;
			this.a8.Source = null;
			if (((Selector)this.av).SelectedItem is Room room2)
			{
				room2.RoomPic = "None";
			}
		}
	}

	private void c4(object A_0, RoutedEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, this.m_b) && TheGame.RoomList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for rooms.  Please register your copy of RAGS.");
			return;
		}
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Room Name:";
		((Window)getNameWindow).Owner = (Window)(object)this;
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag != true || !flag.HasValue || !(getNameWindow.txtEntry.Text.Trim() != string.Empty))
		{
			return;
		}
		Room room = new Room();
		room.Name = getNameWindow.txtEntry.Text;
		if (TheGame.RoomList.Count > 0)
		{
			Room room2 = TheGame.RoomList[0];
			if (room2 != null)
			{
				foreach (CustomProperty customProperty in room2.CustomProperties)
				{
					room.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
				}
			}
		}
		TheGame.RoomList.Add(room);
		t();
		((Selector)this.av).SelectedIndex = ((CollectionView)((ItemsControl)this.av).Items).Count - 1;
		a(room);
	}

	private void c3(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.North);
	}

	private void a(Exit.Directions A_0)
	{
		if (((Selector)this.av).SelectedItem is Room room)
		{
			Exit exit = room.GetExit(A_0);
			switch (A_0)
			{
			case Exit.Directions.North:
				exit.bActive = ((ToggleButton)this.bb).IsChecked.Value;
				break;
			case Exit.Directions.South:
				exit.bActive = ((ToggleButton)this.bc).IsChecked.Value;
				break;
			case Exit.Directions.East:
				exit.bActive = ((ToggleButton)this.be).IsChecked.Value;
				break;
			case Exit.Directions.West:
				exit.bActive = ((ToggleButton)this.bd).IsChecked.Value;
				break;
			case Exit.Directions.NorthWest:
				exit.bActive = ((ToggleButton)this.bh).IsChecked.Value;
				break;
			case Exit.Directions.NorthEast:
				exit.bActive = ((ToggleButton)this.bi).IsChecked.Value;
				break;
			case Exit.Directions.SouthWest:
				exit.bActive = ((ToggleButton)this.bj).IsChecked.Value;
				break;
			case Exit.Directions.SouthEast:
				exit.bActive = ((ToggleButton)this.bk).IsChecked.Value;
				break;
			case Exit.Directions.Up:
				exit.bActive = ((ToggleButton)this.bf).IsChecked.Value;
				break;
			case Exit.Directions.Down:
				exit.bActive = ((ToggleButton)this.bg).IsChecked.Value;
				break;
			case Exit.Directions.In:
				exit.bActive = ((ToggleButton)this.bl).IsChecked.Value;
				break;
			case Exit.Directions.Out:
				exit.bActive = ((ToggleButton)this.bm).IsChecked.Value;
				break;
			}
		}
	}

	private void c2(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.South);
	}

	private void c1(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.West);
	}

	private void c0(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.East);
	}

	private void cz(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.Up);
	}

	private void cy(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.Down);
	}

	private void cx(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.NorthWest);
	}

	private void cw(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.NorthEast);
	}

	private void cv(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.SouthWest);
	}

	private void cu(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.SouthEast);
	}

	private void ct(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.In);
	}

	private void cs(object A_0, RoutedEventArgs A_1)
	{
		a(Exit.Directions.Out);
	}

	private void ac(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.bn).SelectedItem != null)
		{
			a(Exit.Directions.North, ((RoomComboItem)((Selector)this.bn).SelectedItem).UniqueID);
		}
	}

	private void a(Exit.Directions A_0, Guid A_1)
	{
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Invalid comparison between Unknown and I4
		Exit exit = ((Room)((Selector)this.av).SelectedItem).GetExit(A_0);
		if (A_1 == Guid.Empty)
		{
			if (exit.DestinationRoom != string.Empty)
			{
				TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
			}
			exit.PortalObjectName = "<None>";
			exit.DestinationRoom = string.Empty;
			return;
		}
		if (A_1 == Guid.Empty)
		{
			exit.DestinationRoom = string.Empty;
			return;
		}
		if (exit.DestinationRoom != string.Empty && exit.DestinationRoom != A_1.ToString())
		{
			Room room = ((Selector)this.av).SelectedItem as Room;
			Room room2 = null;
			if (exit.DestinationRoom != null)
			{
				room2 = TheGame.GetRoomByID(new Guid(exit.DestinationRoom));
			}
			if (room2 != null)
			{
				room2.GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
				room2.GetExit(Exit.GetOppositeDir(A_0)).DestinationRoom = null;
			}
			room.GetExit(A_0).PortalObjectName = "<None>";
			((Selector)this.bo).SelectedItem = room.GetExit(Exit.Directions.North).PortalObjectName;
			((Selector)this.bq).SelectedItem = room.GetExit(Exit.Directions.South).PortalObjectName;
			((Selector)this.bu).SelectedItem = room.GetExit(Exit.Directions.East).PortalObjectName;
			((Selector)this.bs).SelectedItem = room.GetExit(Exit.Directions.West).PortalObjectName;
			((Selector)this.bw).SelectedItem = room.GetExit(Exit.Directions.Up).PortalObjectName;
			((Selector)this.by).SelectedItem = room.GetExit(Exit.Directions.Down).PortalObjectName;
			((Selector)this.b0).SelectedItem = room.GetExit(Exit.Directions.NorthWest).PortalObjectName;
			((Selector)this.b2).SelectedItem = room.GetExit(Exit.Directions.NorthEast).PortalObjectName;
			((Selector)this.b4).SelectedItem = room.GetExit(Exit.Directions.SouthWest).PortalObjectName;
			((Selector)this.b6).SelectedItem = room.GetExit(Exit.Directions.SouthEast).PortalObjectName;
			((Selector)this.b8).SelectedItem = room.GetExit(Exit.Directions.In).PortalObjectName;
			((Selector)this.ca).SelectedItem = room.GetExit(Exit.Directions.Out).PortalObjectName;
		}
		if (exit.DestinationRoom == null || exit.DestinationRoom != A_1.ToString())
		{
			exit.DestinationRoom = A_1.ToString();
			if ((int)MessageBox.Show("Would you like the destination room to link back to this room?", "Two way exit?", (MessageBoxButton)4) == 6)
			{
				TheGame.GetRoomByID(A_1).GetExit(Exit.GetOppositeDir(A_0)).DestinationRoom = ((Room)((Selector)this.av).SelectedItem).UniqueID.ToString();
				TheGame.GetRoomByID(A_1).GetExit(Exit.GetOppositeDir(A_0)).bActive = true;
			}
		}
	}

	private void ab(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.South, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void aa(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.West, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void z(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.East, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void y(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Up, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void x(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Down, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void w(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.NorthWest, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void v(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.NorthEast, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void u(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.SouthWest, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void t(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.SouthEast, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void s(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.In, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void r(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Out, ((RoomComboItem)((Selector)(ComboBox)A_0).SelectedItem).UniqueID);
		}
	}

	private void q(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.North, ((RoomComboItem)((Selector)this.bo).SelectedItem).UniqueID.ToString(), ref this.bo);
		}
	}

	private void p(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.South, ((RoomComboItem)((Selector)this.bq).SelectedItem).UniqueID.ToString(), ref this.bq);
		}
	}

	private void o(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.West, ((RoomComboItem)((Selector)this.bs).SelectedItem).UniqueID.ToString(), ref this.bs);
		}
	}

	private void n(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.East, ((RoomComboItem)((Selector)this.bu).SelectedItem).UniqueID.ToString(), ref this.bu);
		}
	}

	private void m(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Up, ((RoomComboItem)((Selector)this.bw).SelectedItem).UniqueID.ToString(), ref this.bw);
		}
	}

	private void l(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Down, ((RoomComboItem)((Selector)this.by).SelectedItem).UniqueID.ToString(), ref this.by);
		}
	}

	private void k(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.In, ((RoomComboItem)((Selector)this.b8).SelectedItem).UniqueID.ToString(), ref this.b8);
		}
	}

	private void j(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.Out, ((RoomComboItem)((Selector)this.ca).SelectedItem).UniqueID.ToString(), ref this.ca);
		}
	}

	private void i(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.NorthWest, ((RoomComboItem)((Selector)this.b0).SelectedItem).UniqueID.ToString(), ref this.b0);
		}
	}

	private void h(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.NorthEast, ((RoomComboItem)((Selector)this.b2).SelectedItem).UniqueID.ToString(), ref this.b2);
		}
	}

	private void g(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.SouthWest, ((RoomComboItem)((Selector)this.b4).SelectedItem).UniqueID.ToString(), ref this.b4);
		}
	}

	private void f(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)(ComboBox)A_0).SelectedItem != null)
		{
			a(Exit.Directions.SouthEast, ((RoomComboItem)((Selector)this.b6).SelectedItem).UniqueID.ToString(), ref this.b6);
		}
	}

	private void a(Exit.Directions A_0, string A_1, ref ComboBox A_2)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		Room room = (Room)((Selector)this.av).SelectedItem;
		if (room.GetExit(A_0).DestinationRoom == null && A_1 != Room.VoidRoomGuid.ToString())
		{
			MessageBox.Show("Sorry, you must specify a destination room before setting the door/portal object.");
			((Selector)A_2).SelectedIndex = 0;
		}
		else if (A_1 == string.Empty || A_1 == Room.VoidRoomGuid.ToString())
		{
			room.GetExit(A_0).PortalObjectName = "<None>";
			if (room.GetExit(A_0).DestinationRoom != string.Empty)
			{
				TheGame.GetRoomByID(new Guid(room.GetExit(A_0).DestinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
			}
		}
		else
		{
			TheGame.GetObjectByName(A_1).locationtype = GameObject.LocationType.LT_PORTAL;
			room.GetExit(A_0).PortalObjectName = A_1;
			TheGame.GetRoomByID(new Guid(room.GetExit(A_0).DestinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = A_1;
		}
	}

	private void b(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		this.m_d = ((MouseEventArgs)A_1).GetPosition((IInputElement)null);
	}

	private void b(object A_0, MouseEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem == null || !((UIElement)(TreeViewItem)g7.SelectedItem).IsMouseOver)
		{
			return;
		}
		Point position = A_1.GetPosition((IInputElement)null);
		Vector val = this.m_d - position;
		if ((int)A_1.LeftButton == 1 && (Math.Abs(val.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(val.Y) > SystemParameters.MinimumVerticalDragDistance))
		{
			if (!(((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject))
			{
				object obj = new object();
				DataObject val2 = new DataObject("ObjectFormat", obj);
				DragDrop.DoDragDrop((DependencyObject)(object)g7, (object)val2, (DragDropEffects)1);
			}
			else
			{
				DataObject val3 = new DataObject("ObjectFormat", (object)gameObject);
				DragDrop.DoDragDrop((DependencyObject)(object)g7, (object)val3, (DragDropEffects)1);
			}
		}
	}

	private void cr(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null)
		{
			GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
			bool flag = false;
			foreach (RoomComboItem item in (IEnumerable)((ItemsControl)this.cd).Items)
			{
				if (gameObject.UniqueIdentifier == item.UniqueID)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				gameObject.locationtype = GameObject.LocationType.LT_ROOM;
				gameObject.locationname = ((Room)((Selector)this.av).SelectedItem).UniqueID.ToString();
			}
		}
		x();
	}

	private void g(object A_0, DragEventArgs A_1)
	{
	}

	private void f(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent("ObjectFormat") || !(A_1.Data.GetData("ObjectFormat") is GameObject gameObject))
		{
			return;
		}
		bool flag = false;
		foreach (RoomComboItem item in (IEnumerable)((ItemsControl)this.cd).Items)
		{
			if (gameObject.UniqueIdentifier == item.UniqueID)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			gameObject.locationtype = GameObject.LocationType.LT_ROOM;
			gameObject.locationname = ((Room)((Selector)this.av).SelectedItem).UniqueID.ToString();
		}
		x();
	}

	private void cq(object A_0, RoutedEventArgs A_1)
	{
		cr(null, null);
	}

	private void cp(object A_0, RoutedEventArgs A_1)
	{
		for (int num = this.cd.SelectedItems.Count - 1; num >= 0; num--)
		{
			TheGame.RemoveRoomObject(((Room)((Selector)this.av).SelectedItem).UniqueID, this.cd.SelectedItems[num].ToString());
		}
		x();
	}

	private void co(object A_0, RoutedEventArgs A_1)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (this.ch.Text.Trim() != string.Empty)
		{
			if (!(((Selector)this.av).SelectedItem is Room room))
			{
				return;
			}
			foreach (CustomProperty customProperty in room.CustomProperties)
			{
				if (customProperty.Name == this.ch.Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + this.ch.Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (Room room2 in TheGame.RoomList)
				{
					room2.CustomProperties.Add(new CustomProperty(this.ch.Text, this.ci.Text));
					l();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void cn(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)this.cg).SelectedItems.Count == 1 && ((Selector)this.cg).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = this.ci.Text;
			l();
		}
	}

	private void cm(object A_0, RoutedEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if (((ListBox)this.cg).SelectedItems.Count != 1 || !(((Selector)this.cg).SelectedItem is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all rooms. Do you wish to continue?", "Warning", (MessageBoxButton)4) != 6)
		{
			return;
		}
		foreach (Room room in TheGame.RoomList)
		{
			foreach (CustomProperty customProperty2 in room.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					room.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		l();
	}

	private void e(object A_0, DragEventArgs A_1)
	{
		cl(null, null);
	}

	private void cl(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null)
		{
			GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
			gameObject.locationtype = GameObject.LocationType.LT_PLAYER;
			gameObject.locationname = "";
		}
		x();
	}

	private void ck(object A_0, RoutedEventArgs A_1)
	{
		foreach (RoomComboItem selectedItem in this.cu.SelectedItems)
		{
			TheGame.GetObjectByName(selectedItem.UniqueID.ToString()).locationtype = GameObject.LocationType.LT_NULL;
		}
		x();
	}

	private void e(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)this.cz).SelectedItems.Count == 1 && ((Selector)this.cz).SelectedItem != null && ((Selector)this.cz).SelectedItem is CustomProperty customProperty)
		{
			this.c0.Text = customProperty.Name;
			this.c1.Text = customProperty.Value;
		}
	}

	private void cj(object A_0, RoutedEventArgs A_1)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		if (this.c0.Text.Trim() != string.Empty)
		{
			foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
			{
				if (customProperty.Name == this.c0.Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + this.c0.Text + " is already in the custom properties list.");
					return;
				}
			}
			TheGame.ThePlayer.CustomProperties.Add(new CustomProperty(this.c0.Text, this.c1.Text));
			y();
		}
		else
		{
			MessageBox.Show("Please fill in a valid property name before clicking the add button.");
		}
	}

	private void ci(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)this.cz).SelectedItems.Count == 1 && ((Selector)this.cz).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = this.c1.Text;
			y();
		}
	}

	private void ch(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)this.cz).SelectedItems.Count != 1 || !(((Selector)this.cz).SelectedItem is CustomProperty customProperty))
		{
			return;
		}
		foreach (CustomProperty customProperty2 in TheGame.ThePlayer.CustomProperties)
		{
			if (customProperty.Name == customProperty2.Name)
			{
				TheGame.ThePlayer.CustomProperties.Remove(customProperty2);
				break;
			}
		}
		y();
	}

	private void cg(object A_0, RoutedEventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, this.m_b) && TheGame.ObjectList.Count >= 10)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for objects.  Please register your copy of RAGS.");
			return;
		}
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Please enter object name:";
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		GameObject gameObject = new GameObject();
		gameObject.name = getNameWindow.txtEntry.Text;
		if (TheGame.ObjectList.Count > 0)
		{
			GameObject gameObject2 = TheGame.ObjectList[0];
			if (gameObject2 != null)
			{
				foreach (CustomProperty customProperty in gameObject2.CustomProperties)
				{
					gameObject.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
				}
			}
		}
		TheGame.ObjectList.Add(gameObject);
		z();
		SelectTreeObject(gameObject.UniqueIdentifier, ((ItemsControl)g7).Items);
	}

	public bool SelectTreeObject(Guid id, ItemCollection data)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		bool flag = false;
		foreach (TreeViewItem item in (IEnumerable)data)
		{
			TreeViewItem val = item;
			if (!(((FrameworkElement)val).Tag is GameObject) && !flag)
			{
				if (((CollectionView)((ItemsControl)val).Items).Count > 0)
				{
					flag = SelectTreeObject(id, ((ItemsControl)val).Items);
				}
			}
			else if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is GameObject && ((GameObject)((FrameworkElement)val).Tag).UniqueIdentifier == id)
			{
				val.IsSelected = true;
				DependencyObject parent = ((FrameworkElement)val).Parent;
				TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
				while (val2 != null)
				{
					val2.IsExpanded = true;
					DependencyObject parent2 = ((FrameworkElement)val2).Parent;
					val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
				}
				return true;
			}
		}
		return flag;
	}

	private void cf(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null && g7.SelectedItem is GameObject gameObject)
		{
			gameObject.preposition = this.c6.Text;
			SaveLoad.ValidateText(this.c6.Text, ref TheGame);
		}
	}

	private void ce(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			gameObject.sdesc = this.c7.Text;
			SaveLoad.ValidateText(this.c7.Text, ref TheGame);
		}
	}

	private void cd(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			gameObject.description = this.c8.Text;
			SaveLoad.ValidateText(this.c8.Text, ref TheGame);
		}
	}

	private void cc(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bImportant = ((ToggleButton)this.c9).IsChecked.Value;
		}
	}

	private void cb(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bCarryable = ((ToggleButton)this.da).IsChecked.Value;
		}
	}

	private void ca(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bWearable = ((ToggleButton)this.db).IsChecked.Value;
		}
	}

	private void b9(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bContainer = ((ToggleButton)this.dc).IsChecked.Value;
		}
	}

	private void b8(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bOpenable = ((ToggleButton)this.dd).IsChecked.Value;
		}
	}

	private void b7(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bLockable = ((ToggleButton)this.dm).IsChecked.Value;
		}
	}

	private void b6(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bEnterable = ((ToggleButton)this.dn).IsChecked.Value;
		}
	}

	private void b5(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bReadable = ((ToggleButton)this.@do).IsChecked.Value;
		}
	}

	private void b4(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).dWeight = Convert.ToDouble(this.dp.Text);
		}
	}

	private void b3(object A_0, RoutedEventArgs A_1)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)this.de).IsChecked.Value)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bOpen = true;
		}
		else
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bOpen = false;
		}
	}

	private void b2(object A_0, RoutedEventArgs A_1)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)this.dg).IsChecked.Value)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bWorn = true;
		}
		else
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bWorn = false;
		}
	}

	private void b1(object A_0, RoutedEventArgs A_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null)
		{
			if (((ToggleButton)this.di).IsChecked.Value)
			{
				((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bLocked = true;
			}
			else
			{
				((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bLocked = false;
			}
		}
	}

	private void b0(object A_0, RoutedEventArgs A_1)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)this.dg).IsChecked.Value)
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bVisible = true;
		}
		else
		{
			((GameObject)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag).bVisible = false;
		}
	}

	private void bz(object A_0, RoutedEventArgs A_1)
	{
		h();
	}

	private void by(object A_0, RoutedEventArgs A_1)
	{
		g();
	}

	private void h()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem == null)
		{
			return;
		}
		ArrayList objectnames = new ArrayList();
		GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (gameObject.UniqueIdentifier != @object.UniqueIdentifier)
			{
				objectnames.Add(new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
		SelectObjectsWindow selectObjectsWindow = new SelectObjectsWindow(ref objectnames);
		((Window)selectObjectsWindow).Owner = (Window)(object)this;
		if (((Window)selectObjectsWindow).ShowDialog() == true)
		{
			for (int i = 0; i < selectObjectsWindow.a.SelectedItems.Count; i++)
			{
				GameObject objectByName = TheGame.GetObjectByName(((RoomComboItem)selectObjectsWindow.a.SelectedItems[i]).UniqueID.ToString());
				if (objectByName != null)
				{
					objectByName.locationtype = GameObject.LocationType.LT_IN_OBJECT;
					objectByName.locationname = gameObject.UniqueIdentifier.ToString();
				}
			}
		}
		c((object)null, (RoutedPropertyChangedEventArgs<object>)null);
	}

	private void g()
	{
		for (int i = 0; i < this.dq.SelectedItems.Count; i++)
		{
			_ = this.dq.SelectedItems[i];
			TheGame.GetObjectByName(((RoomComboItem)this.dq.SelectedItems[i]).UniqueID.ToString()).locationtype = GameObject.LocationType.LT_NULL;
		}
		c((object)null, (RoutedPropertyChangedEventArgs<object>)null);
	}

	private void bx(object A_0, RoutedEventArgs A_1)
	{
		((UIElement)this.dq).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
		((UIElement)this.dr).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
		((UIElement)this.ds).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
	}

	private void bw(object A_0, RoutedEventArgs A_1)
	{
		((UIElement)this.dq).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
		((UIElement)this.dr).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
		((UIElement)this.ds).IsEnabled = ((ToggleButton)this.dc).IsChecked.Value;
	}

	private void d(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)this.dt).SelectedItems.Count == 1 && ((Selector)this.dt).SelectedItem != null && ((Selector)this.dt).SelectedItem is CustomProperty customProperty)
		{
			this.du.Text = customProperty.Name;
			this.dv.Text = customProperty.Value;
		}
	}

	private void bv(object A_0, RoutedEventArgs A_1)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if (this.du.Text.Trim() != string.Empty)
		{
			if (!(((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject))
			{
				return;
			}
			foreach (CustomProperty customProperty in gameObject.CustomProperties)
			{
				if (customProperty.Name == this.du.Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + this.du.Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (GameObject @object in TheGame.ObjectList)
				{
					@object.CustomProperties.Add(new CustomProperty(this.du.Text, this.dv.Text));
					ab();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void bu(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)this.dt).SelectedItems.Count == 1 && ((Selector)this.dt).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = this.dv.Text;
			ab();
		}
	}

	private void bt(object A_0, RoutedEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if (((ListBox)this.dt).SelectedItems.Count != 1 || !(((Selector)this.dt).SelectedItem is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all objects. Do you wish to continue?", "Warning", (MessageBoxButton)4) != 6)
		{
			return;
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			foreach (CustomProperty customProperty2 in @object.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					@object.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		ab();
	}

	private void bs(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)d4).SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			gameObject.LayeredZoneLevels.Remove(((Selector)d4).SelectedItem.ToString());
			k();
		}
	}

	private void br(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)d5).SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			gameObject.LayeredZoneLevels.Add(((Selector)d5).SelectedItem.ToString() + ":" + ((ContentControl)(ComboBoxItem)((Selector)d6).SelectedItem).Content);
			k();
		}
	}

	private void bq(object A_0, RoutedEventArgs A_1)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Name Of The New Zone:";
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		bool flag = false;
		foreach (string layeredClothingZone in TheGame.LayeredClothingZones)
		{
			if (string.Compare(layeredClothingZone, getNameWindow.txtEntry.Text, ignoreCase: true) == 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			MessageBox.Show("Sorry, there is a zone named " + getNameWindow.txtEntry.Text + " already in the zone list.");
			return;
		}
		TheGame.LayeredClothingZones.Add(getNameWindow.txtEntry.Text);
		r();
	}

	private void bp(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.d1).SelectedItem != null)
		{
			TheGame.LayeredClothingZones.Remove(((Selector)this.d1).SelectedItem.ToString());
			r();
		}
	}

	private void bo(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)eb).SelectedItems.Count > 0 && ((Selector)eb).SelectedItem is Character character)
		{
			character.CharnameOverride = eh.Text;
			SaveLoad.ValidateText(eh.Text, ref TheGame);
		}
	}

	private void c(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)eb).SelectedItem is Character character && ((Selector)ei).SelectedItem != null)
		{
			character.CurrentRoom = ((RoomComboItem)((Selector)ei).SelectedItem).UniqueID.ToString();
		}
	}

	private void bn(object A_0, RoutedEventArgs A_1)
	{
		if (((ListBox)eb).SelectedItems.Count > 0 && ((Selector)eb).SelectedItem is Character character)
		{
			character.bAllowInventoryInteraction = ((ToggleButton)ej).IsChecked.Value;
		}
	}

	private void bm(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)eb).SelectedItem is Character character)
		{
			character.Description = eo.Text;
			SaveLoad.ValidateText(eo.Text, ref TheGame);
		}
	}

	private void bl(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)eb).SelectedItem is Character character)
		{
			if (((ToggleButton)em).IsChecked.Value)
			{
				character.CharGender = Player.Gender.Female;
			}
			else if (((ToggleButton)el).IsChecked.Value)
			{
				character.CharGender = Player.Gender.Male;
			}
			else
			{
				character.CharGender = Player.Gender.Other;
			}
		}
	}

	private void b(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)er).SelectedItem == null)
		{
			return;
		}
		if (((Selector)er).SelectedItem.ToString() == "None")
		{
			((FrameworkElement)es).Tag = null;
			es.Source = null;
			if (((Selector)eb).SelectedItem is Character character)
			{
				character.CharPortrait = "";
			}
		}
		else if (((Selector)eb).SelectedItem is Character character2)
		{
			character2.CharPortrait = ((Selector)er).SelectedItem.ToString();
			object pictureByName = SaveLoad.GetPictureByName(((Selector)er).SelectedItem.ToString(), ref TheGame);
			if (pictureByName != null)
			{
				es.Source = new Uri(pictureByName as string);
			}
		}
	}

	private void d(object A_0, DragEventArgs A_1)
	{
		bk(null, null);
	}

	private void bk(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag != null)
		{
			GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
			if (((CollectionView)((ItemsControl)ep).Items).IndexOf((object)gameObject.name) == -1)
			{
				gameObject.locationtype = GameObject.LocationType.LT_CHARACTER;
				gameObject.locationname = ((Character)((Selector)eb).SelectedItem).Charname;
			}
		}
		x();
	}

	private void bj(object A_0, RoutedEventArgs A_1)
	{
		foreach (RoomComboItem selectedItem in ep.SelectedItems)
		{
			for (int i = 0; i < TheGame.ObjectList.Count; i++)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				if (gameObject.UniqueIdentifier == selectedItem.UniqueID && gameObject.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject.locationname == ((Character)((Selector)eb).SelectedItem).Charname)
				{
					gameObject.locationtype = GameObject.LocationType.LT_NULL;
				}
			}
		}
		x();
	}

	private void bi(object A_0, RoutedEventArgs A_1)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		string text = ev.Text;
		string text2 = ew.Text;
		if (text.Trim() != string.Empty)
		{
			if (!(((Selector)eb).SelectedItem is Character character))
			{
				return;
			}
			foreach (CustomProperty customProperty in character.CustomProperties)
			{
				if (customProperty.Name == text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + ev.Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (Character character2 in TheGame.CharacterList)
				{
					character2.CustomProperties.Add(new CustomProperty(text, text2));
					ae();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void bh(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)eb).SelectedItem is Character && ((Selector)eu).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = ew.Text;
			ae();
		}
	}

	private void bg(object A_0, RoutedEventArgs A_1)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		if (!(((Selector)eb).SelectedItem is Character) || !(((Selector)eu).SelectedItem is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all characters. Do you wish to continue?", "Warning", (MessageBoxButton)4) != 6)
		{
			return;
		}
		foreach (Character character2 in TheGame.CharacterList)
		{
			foreach (CustomProperty customProperty2 in character2.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					character2.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		ae();
	}

	private void bf(object A_0, RoutedEventArgs A_1)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Invalid comparison between Unknown and I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Invalid comparison between Unknown and I4
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Invalid comparison between Unknown and I4
		((UIElement)fo).IsEnabled = false;
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag == null)
		{
			return;
		}
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		if (((ToggleButton)fa).IsChecked == true)
		{
			gameVariable.vartype = GameVariable.VarType.VT_STRING;
		}
		else if (((ToggleButton)e8).IsChecked == true)
		{
			gameVariable.vartype = GameVariable.VarType.VT_NUMBER;
		}
		else if (((ToggleButton)fc).IsChecked == true)
		{
			gameVariable.vartype = GameVariable.VarType.VT_DATETIME;
		}
		else if (((ToggleButton)e9).IsChecked == true)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButton)4) == 7)
				{
					b((object)null, (RoutedPropertyChangedEventArgs<object>)null);
					return;
				}
				gameVariable.VarArray.Clear();
				j();
			}
			((UIElement)fo).IsEnabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_NUMBERARRAY;
		}
		else if (((ToggleButton)fb).IsChecked == true)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButton)4) == 7)
				{
					b((object)null, (RoutedPropertyChangedEventArgs<object>)null);
					return;
				}
				gameVariable.VarArray.Clear();
				j();
			}
			((UIElement)fo).IsEnabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_STRINGARRAY;
		}
		else if (((ToggleButton)fd).IsChecked == true)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_DATETIMEARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButton)4) == 7)
				{
					b((object)null, (RoutedPropertyChangedEventArgs<object>)null);
					return;
				}
				gameVariable.VarArray.Clear();
				j();
			}
			((UIElement)fo).IsEnabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_DATETIMEARRAY;
		}
		switch (gameVariable.vartype)
		{
		case GameVariable.VarType.VT_DATETIME:
		case GameVariable.VarType.VT_DATETIMEARRAY:
			((UIElement)fj).Visibility = (Visibility)1;
			((UIElement)fh).Visibility = (Visibility)1;
			((UIElement)fi).Visibility = (Visibility)0;
			break;
		case GameVariable.VarType.VT_NUMBER:
		case GameVariable.VarType.VT_NUMBERARRAY:
			((UIElement)fj).Visibility = (Visibility)0;
			((UIElement)fh).Visibility = (Visibility)1;
			((UIElement)fi).Visibility = (Visibility)1;
			break;
		case GameVariable.VarType.VT_STRING:
		case GameVariable.VarType.VT_STRINGARRAY:
			((UIElement)fj).Visibility = (Visibility)1;
			((UIElement)fh).Visibility = (Visibility)0;
			((UIElement)fi).Visibility = (Visibility)1;
			break;
		}
	}

	private void be(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable)
		{
			gameVariable.VarComment = ff.Text;
		}
	}

	private void bd(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag != null)
		{
			GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
			gameVariable.sString = fh.Text;
			SaveLoad.ValidateText(fh.Text, ref TheGame);
		}
	}

	private void bc(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag == null)
		{
			return;
		}
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		if (gameVariable.vartype == GameVariable.VarType.VT_NUMBER)
		{
			try
			{
				gameVariable.dNumType = Convert.ToDouble(fk.Text);
			}
			catch
			{
				MessageBox.Show("Please enter a valid number in the initial value box.");
				((UIElement)fk).Focus();
			}
		}
	}

	private void bb(object A_0, RoutedEventArgs A_1)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (fi.Value.HasValue)
		{
			((GameVariable)((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag).dtDateTime = fi.Value.Value;
		}
	}

	private void ba(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIMEARRAY:
				gameVariable.VarArray.Add(fi.Value);
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				gameVariable.VarArray.Add(Convert.ToDouble(fk.Text));
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				gameVariable.VarArray.Add(fh.Text);
				break;
			}
			j();
			((Selector)ft).SelectedIndex = ((CollectionView)((ItemsControl)ft).Items).Count - 1;
		}
	}

	private void a9(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		int selectedIndex = ((Selector)ft).SelectedIndex;
		if (selectedIndex > -1 && gameVariable != null)
		{
			gameVariable.VarArray.RemoveAt(selectedIndex);
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIMEARRAY:
				gameVariable.VarArray.Insert(selectedIndex, fi.Value);
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				gameVariable.VarArray.Insert(selectedIndex, Convert.ToDouble(fk.Text));
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				gameVariable.VarArray.Insert(selectedIndex, fh.Text);
				break;
			}
			j();
		}
	}

	private void a8(object A_0, RoutedEventArgs A_1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)ft).SelectedIndex != -1 && ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable)
		{
			gameVariable.VarArray.RemoveAt(((Selector)ft).SelectedIndex);
			j();
		}
	}

	private void a7(object A_0, RoutedEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Obj, but got Unknown
		if (!LockData.IsLicensed(bdisplay: false, this.m_b) && TheGame.VariableList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for variables.  Please register your copy of RAGS.");
			return;
		}
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Variable Name:";
		if (!((Window)getNameWindow).ShowDialog().Value)
		{
			return;
		}
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.varname == getNameWindow.txtEntry.Text)
			{
				MessageBox.Show("Sorry, that variable name is already in use.");
				return;
			}
		}
		GameVariable gameVariable = new GameVariable(getNameWindow.txtEntry.Text);
		if (TheGame.VariableList.Count > 0)
		{
			GameVariable gameVariable2 = TheGame.VariableList[0];
			if (gameVariable2 != null)
			{
				foreach (CustomProperty customProperty in gameVariable2.CustomProperties)
				{
					gameVariable.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
				}
			}
		}
		TheGame.VariableList.Add(gameVariable);
		gameVariable.vartype = GameVariable.VarType.VT_NUMBER;
		ac();
		foreach (TreeViewItem item in (IEnumerable)((ItemsControl)e1).Items)
		{
			TreeViewItem val = item;
			if (((FrameworkElement)val).Tag == gameVariable)
			{
				val.IsSelected = true;
				break;
			}
		}
	}

	private void a6(object A_0, RoutedEventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		c((object)null, (EventArgs)null);
		GetDimensionWidthWindow getDimensionWidthWindow = new GetDimensionWidthWindow();
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		if (((Window)getDimensionWidthWindow).ShowDialog() != true)
		{
			return;
		}
		if (Convert.ToInt32(getDimensionWidthWindow.a.Text) < fu.Columns.Count)
		{
			if ((int)MessageBox.Show("This may result in a loss of data.  Are you sure you wish to remove some columns?", "Warning", (MessageBoxButton)4) == 6)
			{
				foreach (ArrayList item in gameVariable.VarArray)
				{
					for (int i = Convert.ToInt32(getDimensionWidthWindow.a.Text) - 1; i < item.Count; i++)
					{
						item.RemoveAt(Convert.ToInt32(getDimensionWidthWindow.a.Text));
					}
				}
			}
		}
		else
		{
			foreach (List<string> item2 in gameVariable.VarArray)
			{
				for (int j = item2.Count; j < Convert.ToInt32(getDimensionWidthWindow.a.Text); j++)
				{
					item2.Add("");
				}
			}
		}
		this.j();
	}

	private void a5(object A_0, RoutedEventArgs A_1)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		string text = fz.Text;
		string text2 = f0.Text;
		if (text.Trim() != string.Empty)
		{
			if (!(((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable))
			{
				return;
			}
			foreach (CustomProperty customProperty in gameVariable.CustomProperties)
			{
				if (customProperty.Name == text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (GameVariable variable in TheGame.VariableList)
				{
					variable.CustomProperties.Add(new CustomProperty(text, text2));
					ah();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void a4(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable && ((Selector)fy).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = f0.Text;
			ah();
		}
	}

	private void a3(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		if (!(((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable) || !(((Selector)fy).SelectedItem is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all variables. Do you wish to continue?", "Warning", (MessageBoxButton)4) != 6)
		{
			return;
		}
		foreach (GameVariable variable in TheGame.VariableList)
		{
			foreach (CustomProperty customProperty2 in variable.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					variable.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		ah();
	}

	private void a2(object A_0, RoutedEventArgs A_1)
	{
		((UIElement)gf).IsEnabled = !((ToggleButton)gd).IsChecked.Value;
		if (((ToggleButton)gd).IsChecked == true)
		{
			((Rags.Timer)((Selector)f4).SelectedItem).TType = Rags.Timer.TimerType.TT_RUNALWAYS;
			return;
		}
		if (((ToggleButton)gj).IsChecked == true)
		{
			((ToggleButton)gj).IsChecked = false;
		}
		((Rags.Timer)((Selector)f4).SelectedItem).TType = Rags.Timer.TimerType.TT_LENGTH;
	}

	private void a1(object A_0, RoutedEventArgs A_1)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		int result = -1;
		if (int.TryParse(gg.Text, out result))
		{
			if (((Selector)f4).SelectedItem != null)
			{
				((Rags.Timer)((Selector)f4).SelectedItem).Length = result;
			}
		}
		else
		{
			MessageBox.Show("You must enter a valid number for the timer length.");
			gg.Text = "1";
			((UIElement)gg).Focus();
		}
	}

	private void a0(object A_0, RoutedEventArgs A_1)
	{
		((Rags.Timer)((Selector)f4).SelectedItem).Restart = ((ToggleButton)gh).IsChecked.Value;
	}

	private void az(object A_0, RoutedEventArgs A_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		bool flag = true;
		if (((ToggleButton)ge).IsChecked == true)
		{
			if ((int)MessageBox.Show("Live Timer must be set to run always.  This timer is currently set to run a specific length of time.  Would you like to proceed?", "Run Always", (MessageBoxButton)4) == 7)
			{
				flag = false;
			}
			else
			{
				((ToggleButton)gd).IsChecked = true;
			}
		}
		if (flag)
		{
			((Rags.Timer)((Selector)f4).SelectedItem).LiveTimer = ((ToggleButton)gj).IsChecked.Value;
		}
	}

	private void ay(object A_0, RoutedEventArgs A_1)
	{
		try
		{
			((Rags.Timer)((Selector)f4).SelectedItem).TimerSeconds = Convert.ToInt32(gk.Text);
		}
		catch
		{
			((Rags.Timer)((Selector)f4).SelectedItem).TimerSeconds = 1;
		}
	}

	private void ax(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)f4).SelectedItem != null)
		{
			((Rags.Timer)((Selector)f4).SelectedItem).Active = ((ToggleButton)gl).IsChecked.Value;
		}
	}

	private void aw(object A_0, RoutedEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, this.m_b) && TheGame.TimerList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for timers.  Please register your copy of RAGS.");
			return;
		}
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Please enter a name for the timer:";
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		Rags.Timer timer = new Rags.Timer();
		timer.Name = getNameWindow.txtEntry.Text;
		if (TheGame.TimerList.Count > 0)
		{
			Rags.Timer timer2 = TheGame.TimerList[0];
			if (timer2 != null)
			{
				foreach (CustomProperty customProperty in timer2.CustomProperties)
				{
					timer.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
				}
			}
		}
		TheGame.TimerList.Add(timer);
		af();
		((Selector)f4).SelectedItem = timer;
	}

	private void av(object A_0, RoutedEventArgs A_1)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		string text = gn.Text;
		string text2 = go.Text;
		if (text.Trim() != string.Empty)
		{
			Rags.Timer timer = (Rags.Timer)((Selector)f4).SelectedItem;
			if (timer == null)
			{
				return;
			}
			foreach (CustomProperty customProperty in timer.CustomProperties)
			{
				if (customProperty.Name == text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (Rags.Timer timer2 in TheGame.TimerList)
				{
					timer2.CustomProperties.Add(new CustomProperty(text, text2));
					ag();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void au(object A_0, RoutedEventArgs A_1)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		Rags.Timer timer = (Rags.Timer)((Selector)f4).SelectedItem;
		if (timer == null || !(((Selector)gm).SelectedItem is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all timers. Do you wish to continue?", "Warning", (MessageBoxButton)4) != 6)
		{
			return;
		}
		foreach (Rags.Timer timer2 in TheGame.TimerList)
		{
			foreach (CustomProperty customProperty2 in timer2.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					timer2.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		ag();
	}

	private void at(object A_0, RoutedEventArgs A_1)
	{
		Rags.Timer timer = (Rags.Timer)((Selector)f4).SelectedItem;
		if (timer != null && ((Selector)gm).SelectedItem is CustomProperty customProperty)
		{
			customProperty.Value = go.Text;
			ag();
		}
	}

	private void c(object A_0, DragEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		if (!A_1.Data.GetDataPresent("MediaFormat"))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		IInputElement val = ((UIElement)g0).InputHitTest(A_1.GetPosition((IInputElement)(object)g0));
		TextBlock val2 = (TextBlock)(object)((val is TextBlock) ? val : null);
		IInputElement val3 = ((UIElement)g0).InputHitTest(A_1.GetPosition((IInputElement)(object)g0));
		Run val4 = (Run)(object)((val3 is Run) ? val3 : null);
		string empty = string.Empty;
		if (val2 != null)
		{
			empty = val2.Text;
		}
		else
		{
			empty = ((val4 != null) ? val4.Text : "");
		}
		TreeViewItem val5 = d(empty, ((ItemsControl)g0).Items);
		if (val5 != null && ((FrameworkElement)val5).Tag is GamePicture)
		{
			DependencyObject parent = ((FrameworkElement)val5).Parent;
			val5 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		GamePicture gamePicture = ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag as GamePicture;
		_ = string.Empty;
		if (gamePicture != null)
		{
			DependencyObject parent2 = ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Parent;
			TreeViewItem val6 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == gamePicture.TheName || val5 == val6)
				{
					return;
				}
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update media set GroupName=@Groupname\r\n                            where Name=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				sqlCeCommand.Parameters.AddWithValue("@name", gamePicture.TheName);
				sqlCeCommand.ExecuteNonQuery();
				gamePicture.GroupName = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString();
			}
			else
			{
				SqlCeConnection dBConnection2 = SaveLoad.GetDBConnection();
				if (dBConnection2 == null)
				{
					return;
				}
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update media set GroupName=@Groupname\r\n                            where Name=@name", dBConnection2);
				sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
				sqlCeCommand2.Parameters.AddWithValue("@name", gamePicture.TheName);
				sqlCeCommand2.ExecuteNonQuery();
				gamePicture.GroupName = string.Empty;
			}
			n();
			A_1.Data.SetData("None", new object());
		}
		else
		{
			string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)g0.SelectedItem).Header).Children[1]).Content.ToString();
			if (val5 != null && ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
			{
				return;
			}
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
				{
					return;
				}
				SqlCeConnection dBConnection3 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from MediaGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", text);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text2 = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text2 = sqlCeDataReader.GetString(0);
				}
				if (text2.Equals(text))
				{
					sqlCeCommand3 = new SqlCeCommand("select Parent from MediaGroups where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeDataReader = sqlCeCommand3.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					sqlCeCommand3 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@parent", value);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeCommand3.ExecuteNonQuery();
				}
				sqlCeCommand3 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@parent", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				sqlCeCommand3.Parameters.AddWithValue("@name", text);
				sqlCeCommand3.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand4 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand4.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand4.Parameters.AddWithValue("@name", text);
				sqlCeCommand4.ExecuteNonQuery();
			}
			n();
		}
		if (val5 != null && val4 != null)
		{
			c(gamePicture.TheName, ((ItemsControl)g0).Items);
		}
	}

	private TreeViewItem d(string A_0, ItemCollection A_1)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		TreeViewItem val = null;
		foreach (TreeViewItem item in (IEnumerable)A_1)
		{
			TreeViewItem val2 = item;
			if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString() == A_0)
			{
				return val2;
			}
			if (((CollectionView)((ItemsControl)val2).Items).Count > 0 && val == null)
			{
				val = d(A_0, ((ItemsControl)val2).Items);
			}
		}
		return val;
	}

	private bool c(string A_0, ItemCollection A_1)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		bool flag = false;
		foreach (TreeViewItem item in (IEnumerable)A_1)
		{
			TreeViewItem val = item;
			if (!(((FrameworkElement)val).Tag is GamePicture) && !flag)
			{
				if (((CollectionView)((ItemsControl)val).Items).Count > 0)
				{
					flag = c(A_0, ((ItemsControl)val).Items);
				}
			}
			else if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is GamePicture && ((GamePicture)((FrameworkElement)val).Tag).TheName == A_0)
			{
				val.IsSelected = true;
				DependencyObject parent = ((FrameworkElement)val).Parent;
				TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
				while (val2 != null)
				{
					val2.IsExpanded = true;
					DependencyObject parent2 = ((FrameworkElement)val2).Parent;
					val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
				}
				return true;
			}
		}
		return flag;
	}

	private bool b(string A_0, ItemCollection A_1)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		bool flag = false;
		foreach (TreeViewItem item in (IEnumerable)A_1)
		{
			TreeViewItem val = item;
			if (!(((FrameworkElement)val).Tag is GameVariable) && !flag)
			{
				if (((CollectionView)((ItemsControl)val).Items).Count > 0)
				{
					flag = c(A_0, ((ItemsControl)val).Items);
				}
			}
			else if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is GameVariable && ((GameVariable)((FrameworkElement)val).Tag).varname == A_0)
			{
				val.IsSelected = true;
				DependencyObject parent = ((FrameworkElement)val).Parent;
				TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
				while (val2 != null)
				{
					val2.IsExpanded = true;
					DependencyObject parent2 = ((FrameworkElement)val2).Parent;
					val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
				}
				return true;
			}
		}
		return flag;
	}

	private void b(object A_0, DragEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		if (!A_1.Data.GetDataPresent("ObjectFormat"))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		IInputElement val = ((UIElement)g7).InputHitTest(A_1.GetPosition((IInputElement)(object)g7));
		TextBlock val2 = (TextBlock)(object)((val is TextBlock) ? val : null);
		IInputElement val3 = ((UIElement)g7).InputHitTest(A_1.GetPosition((IInputElement)(object)g0));
		Run val4 = (Run)(object)((val3 is Run) ? val3 : null);
		string empty = string.Empty;
		if (val2 != null)
		{
			empty = val2.Text;
		}
		else
		{
			empty = ((val4 != null) ? val4.Text : "");
		}
		TreeViewItem val5 = d(empty, ((ItemsControl)g7).Items);
		if (val5 != null && ((FrameworkElement)val5).Tag is GameObject)
		{
			DependencyObject parent = ((FrameworkElement)val5).Parent;
			val5 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
		_ = string.Empty;
		if (gameObject != null)
		{
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == gameObject.name)
				{
					return;
				}
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update Items set GroupName=@Groupname\r\n                            where Name=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString());
				sqlCeCommand.Parameters.AddWithValue("@name", gameObject.UniqueIdentifier.ToString());
				sqlCeCommand.ExecuteNonQuery();
				gameObject.GroupName = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString();
			}
			else
			{
				SqlCeConnection dBConnection2 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Items set GroupName=@Groupname\r\n                            where Name=@name", dBConnection2);
				sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
				sqlCeCommand2.Parameters.AddWithValue("@name", gameObject.UniqueIdentifier.ToString());
				sqlCeCommand2.ExecuteNonQuery();
				gameObject.GroupName = string.Empty;
			}
			z();
			A_1.Data.SetData("None", new object());
		}
		else
		{
			string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)g7.SelectedItem).Header).Children[1]).Content.ToString();
			if (val5 != null && ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
			{
				return;
			}
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
				{
					return;
				}
				SqlCeConnection dBConnection3 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from ItemGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text2 = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text2 = sqlCeDataReader.GetString(0);
				}
				if (text2.Equals(text))
				{
					sqlCeCommand3 = new SqlCeCommand("select Parent from ItemGroups where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeDataReader = sqlCeCommand3.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					sqlCeCommand3 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@parent", value);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeCommand3.ExecuteNonQuery();
				}
				sqlCeCommand3 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@parent", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				sqlCeCommand3.Parameters.AddWithValue("@name", text);
				sqlCeCommand3.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand4 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand4.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand4.Parameters.AddWithValue("@name", text);
				sqlCeCommand4.ExecuteNonQuery();
			}
			z();
		}
		if (val5 != null && gameObject != null)
		{
			SelectTreeObject(gameObject.UniqueIdentifier, ((ItemsControl)g7).Items);
		}
	}

	private void @as(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		val.Multiselect = true;
		if (((CommonDialog)val).ShowDialog() != true)
		{
			return;
		}
		bool flag = LockData.IsLicensed(bdisplay: false, this.m_b);
		for (int i = 0; i < ((FileDialog)val).FileNames.Length; i++)
		{
			if (!flag && TheGame.PictureList.Count >= 10)
			{
				MessageBox.Show("Sorry, you've reached the trial limit for pictures.  Please register your copy of RAGS.");
				break;
			}
			if (SaveLoad.DBName == string.Empty)
			{
				MessageBox.Show("The game will now be saved to create your image repository.");
				while (SaveLoad.DBName == string.Empty)
				{
					ar((object)null, (RoutedEventArgs)null);
					if (SaveLoad.DBName == string.Empty)
					{
						MessageBox.Show("Image insertion cancelled.");
						return;
					}
				}
			}
			GamePicture gamePicture = new GamePicture(Path.GetFileName(((FileDialog)val).FileNames[i]), ((FileDialog)val).FileNames[i]);
			TheGame.PictureList.Add(gamePicture);
			SaveLoad.GamePicture_InsertToDatabase(((FileDialog)val).FileNames[i], gamePicture);
			try
			{
				File.Copy(((FileDialog)val).FileNames[i], Path.Combine(Path.GetTempPath(), Path.GetFileName(((FileDialog)val).FileNames[i])), overwrite: true);
			}
			catch
			{
			}
		}
		o();
	}

	private void f()
	{
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		if (dBConnection != null && dBConnection.State == ConnectionState.Open)
		{
			dBConnection.Close();
		}
		if (File.Exists(this.m_c))
		{
			File.Copy(this.m_c, this.m_c + ".bak", overwrite: true);
		}
		if (dBConnection != null && dBConnection.State == ConnectionState.Closed)
		{
			dBConnection.Open();
		}
	}

	private void ar(object A_0, RoutedEventArgs A_1)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)this.u).Focus();
		if (!p())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
			return;
		}
		if (this.m_c != "")
		{
			try
			{
				f();
				try
				{
					SaveLoad.Game_UpdateDatabase(TheGame);
					new SharpSerializer(binarySerialization: true);
				}
				catch
				{
				}
				((Window)this).Title = "Rags Designer - " + this.m_c;
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving file " + this.m_c + ". Please try using save as and use a different name.\r\n" + ex.Message);
				return;
			}
		}
		aq((object)null, (RoutedEventArgs)null);
	}

	private void aq(object A_0, RoutedEventArgs A_1)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)this.u).Focus();
		if (!p())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
			return;
		}
		SaveFileDialog val = new SaveFileDialog();
		((FileDialog)val).Filter = "Rags Game Files|*.rag|All Files|*.*";
		if (((CommonDialog)val).ShowDialog() != false)
		{
			this.m_c = ((FileDialog)val).FileName;
			if (SaveLoad.DBName != string.Empty && File.Exists(SaveLoad.DBName))
			{
				File.Copy(SaveLoad.DBName, this.m_c, overwrite: true);
				SaveLoad.TheCon.Close();
				SaveLoad.DBName = this.m_c;
			}
			else
			{
				SaveLoad.Game_CreateDatabase(this.m_c);
			}
			SaveLoad.Game_UpdateDatabase(TheGame);
			((Window)this).Title = "Rags Designer - " + this.m_c;
		}
	}

	private void ap(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (g0.SelectedItem == null || !(((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture))
		{
			return;
		}
		string theName = ((GamePicture)((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag).TheName;
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			if (string.Compare(TheGame.PictureList[i].TheName, theName, ignoreCase: true) == 0)
			{
				TheGame.PictureList.Remove(TheGame.PictureList[i]);
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from Media where Name=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@name", theName);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
				sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@name", theName);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
				break;
			}
		}
		o();
	}

	private void ao(object A_0, RoutedEventArgs A_1)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Enter Group Name:";
		((Window)getNameWindow).Owner = (Window)(object)this;
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = getNameWindow.txtEntry.Text;
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from MediaGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		if (g0.SelectedItem == null || (((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture && ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Parent == null))
		{
			a(getNameWindow.txtEntry.Text, ((ItemsControl)g0).Items);
		}
		else
		{
			object selectedItem = g0.SelectedItem;
			TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
			if (!(((FrameworkElement)val).Tag is GamePicture))
			{
				a(getNameWindow.txtEntry.Text, ((ItemsControl)val).Items);
			}
			else
			{
				DependencyObject parent = ((FrameworkElement)val).Parent;
				TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
				if (val2 == null)
				{
					a(getNameWindow.txtEntry.Text, ((ItemsControl)g0).Items);
				}
				else
				{
					a(getNameWindow.txtEntry.Text, ((ItemsControl)val2).Items);
					value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString();
				}
			}
		}
		dBConnection = SaveLoad.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			ar((object)null, (RoutedEventArgs)null);
			dBConnection = SaveLoad.GetDBConnection();
		}
		sqlCeCommand = new SqlCeCommand("insert into MediaGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		sqlCeCommand.Parameters.AddWithValue("@parent", value);
		sqlCeCommand.ExecuteNonQuery();
		n();
	}

	private void an(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		if (g0.SelectedItem == null || ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture)
		{
			return;
		}
		string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)g0.SelectedItem).Header).Children[1]).Content.ToString();
		DependencyObject parent = ((FrameworkElement)(TreeViewItem)g0.SelectedItem).Parent;
		TreeViewItem val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		if ((int)MessageBox.Show("Are you sure you want to remove group " + text + "?", "Delete Group Confirmation", (MessageBoxButton)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update MediaGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (val != null)
		{
			value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("update Media set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from MediaGroups where name=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GamePicture picture in TheGame.PictureList)
		{
			SaveLoad.GamePicture_UpdatePictureGroup(picture);
		}
		n();
	}

	private void a(string A_0, ItemCollection A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		TreeViewItem val = new TreeViewItem();
		((FrameworkElement)val).Tag = A_0;
		StackPanel val2 = new StackPanel();
		val2.Orientation = (Orientation)0;
		((FrameworkElement)val2).Height = 22.0;
		Image val3 = new Image();
		val3.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/taskhs.png"));
		((FrameworkElement)val3).Width = 16.0;
		((FrameworkElement)val3).Height = 16.0;
		Label val4 = new Label();
		((ContentControl)val4).Content = A_0;
		((FrameworkElement)val4).VerticalAlignment = (VerticalAlignment)1;
		((Control)val4).FontSize = 9.0;
		((FrameworkElement)val3).VerticalAlignment = (VerticalAlignment)1;
		((Panel)val2).Children.Add((UIElement)(object)val3);
		((Panel)val2).Children.Add((UIElement)(object)val4);
		((HeaderedItemsControl)val).Header = val2;
		A_1.Add((object)val);
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (e1.SelectedItem == null || !((UIElement)(TreeViewItem)e1.SelectedItem).IsMouseOver)
		{
			return;
		}
		Point position = A_1.GetPosition((IInputElement)null);
		Vector val = this.m_d - position;
		if ((int)A_1.LeftButton == 1 && (Math.Abs(val.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(val.Y) > SystemParameters.MinimumVerticalDragDistance))
		{
			if (!(((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable gameVariable))
			{
				object obj = new object();
				DataObject val2 = new DataObject("VariableFormat", obj);
				DragDrop.DoDragDrop((DependencyObject)(object)g7, (object)val2, (DragDropEffects)1);
			}
			else
			{
				DataObject val3 = new DataObject("VariableFormat", (object)gameVariable);
				DragDrop.DoDragDrop((DependencyObject)(object)g7, (object)val3, (DragDropEffects)1);
			}
		}
	}

	private void a(object A_0, DragEventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		if (!A_1.Data.GetDataPresent("VariableFormat"))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		IInputElement val = ((UIElement)e1).InputHitTest(A_1.GetPosition((IInputElement)(object)e1));
		TextBlock val2 = (TextBlock)(object)((val is TextBlock) ? val : null);
		IInputElement val3 = ((UIElement)e1).InputHitTest(A_1.GetPosition((IInputElement)(object)g0));
		Run val4 = (Run)(object)((val3 is Run) ? val3 : null);
		string empty = string.Empty;
		if (val2 != null)
		{
			empty = val2.Text;
		}
		else
		{
			empty = ((val4 != null) ? val4.Text : "");
		}
		TreeViewItem val5 = d(empty, ((ItemsControl)e1).Items);
		if (val5 != null && ((FrameworkElement)val5).Tag is GameVariable)
		{
			DependencyObject parent = ((FrameworkElement)val5).Parent;
			val5 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		GameVariable gameVariable = ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag as GameVariable;
		_ = string.Empty;
		if (gameVariable != null)
		{
			if (empty == gameVariable.DisplayName)
			{
				return;
			}
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == gameVariable.varname || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == gameVariable.GroupName)
				{
					return;
				}
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update Variables set GroupName=@Groupname\r\n                            where VarName=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				sqlCeCommand.Parameters.AddWithValue("@name", gameVariable.varname);
				sqlCeCommand.ExecuteNonQuery();
				gameVariable.GroupName = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString();
			}
			else
			{
				SqlCeConnection dBConnection2 = SaveLoad.GetDBConnection();
				if (dBConnection2 != null)
				{
					SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Variables set GroupName=@Groupname\r\n                            where VarName=@name", dBConnection2);
					sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
					sqlCeCommand2.Parameters.AddWithValue("@name", gameVariable.varname);
					sqlCeCommand2.ExecuteNonQuery();
					gameVariable.GroupName = string.Empty;
				}
			}
			ac();
			A_1.Data.SetData("None", new object());
		}
		else
		{
			string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)e1.SelectedItem).Header).Children[1]).Content.ToString();
			if (val5 != null && ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
			{
				return;
			}
			if (val5 != null)
			{
				if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == text)
				{
					return;
				}
				SqlCeConnection dBConnection3 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from VariableGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text2 = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text2 = sqlCeDataReader.GetString(0);
				}
				if (text2.Equals(text))
				{
					sqlCeCommand3 = new SqlCeCommand("select Parent from VariableGroups where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeDataReader = sqlCeCommand3.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					sqlCeCommand3 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand3.Parameters.AddWithValue("@parent", value);
					sqlCeCommand3.Parameters.AddWithValue("@name", text);
					sqlCeCommand3.ExecuteNonQuery();
				}
				sqlCeCommand3 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@parent", ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content);
				sqlCeCommand3.Parameters.AddWithValue("@name", text);
				sqlCeCommand3.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand4 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand4.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand4.Parameters.AddWithValue("@name", text);
				sqlCeCommand4.ExecuteNonQuery();
			}
			ac();
		}
		if (val5 != null && gameVariable != null)
		{
			b(gameVariable.varname, ((ItemsControl)e1).Items);
		}
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		this.m_d = ((MouseEventArgs)A_1).GetPosition((IInputElement)null);
	}

	private void am(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (e1.SelectedItem != null)
		{
			if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable item)
			{
				TheGame.VariableList.Remove(item);
			}
			ac();
		}
	}

	private void al(object A_0, RoutedEventArgs A_1)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Enter Group Name:";
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		if (SaveLoad.DBName == string.Empty)
		{
			MessageBox.Show("The game will now be saved to create your item repository.");
			while (SaveLoad.DBName == string.Empty)
			{
				ar((object)null, (RoutedEventArgs)null);
				if (SaveLoad.DBName == string.Empty)
				{
					MessageBox.Show("Variable insertion cancelled.");
					return;
				}
			}
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = getNameWindow.txtEntry.Text;
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from VariableGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		object selectedItem = e1.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		if (val == null)
		{
			a(getNameWindow.txtEntry.Text, ((ItemsControl)e1).Items);
		}
		else if (((FrameworkElement)val).Tag == null)
		{
			a(getNameWindow.txtEntry.Text, ((ItemsControl)val).Items);
		}
		else
		{
			DependencyObject parent = ((FrameworkElement)val).Parent;
			TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			if (val2 == null)
			{
				a(getNameWindow.txtEntry.Text, ((ItemsControl)e1).Items);
			}
			else
			{
				a(getNameWindow.txtEntry.Text, ((ItemsControl)val2).Items);
				value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString();
			}
		}
		dBConnection = SaveLoad.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			ar((object)null, (RoutedEventArgs)null);
			dBConnection = SaveLoad.GetDBConnection();
		}
		sqlCeCommand = new SqlCeCommand("insert into VariableGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		sqlCeCommand.Parameters.AddWithValue("@parent", value);
		sqlCeCommand.ExecuteNonQuery();
		ac();
	}

	private void ak(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (e1.SelectedItem == null || ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag is GameVariable)
		{
			return;
		}
		string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)e1.SelectedItem).Header).Children[1]).Content.ToString();
		if ((int)MessageBox.Show("Are you sure you want to remove group " + text + "?", "Delete Group Confirmation", (MessageBoxButton)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update VariableGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (((FrameworkElement)(TreeViewItem)e1.SelectedItem).Parent != null && ((FrameworkElement)(TreeViewItem)e1.SelectedItem).Parent is TreeViewItem)
		{
			value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)e1.SelectedItem).Parent).Header).Children[1]).Content.ToString();
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("update Variables set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from VariableGroups where name=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			SaveLoad.GameVariable_UpdateGroupName(variable);
		}
		ac();
	}

	private void aj(object A_0, RoutedEventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		if (g0.SelectedItem == null || !(((FrameworkElement)(TreeViewItem)g0.SelectedItem).Tag is GamePicture gamePicture))
		{
			return;
		}
		SaveFileDialog val = new SaveFileDialog();
		((FileDialog)val).FileName = gamePicture.TheName;
		if (((CommonDialog)val).ShowDialog() == true)
		{
			byte[] bytes = null;
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", gamePicture.TheName);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				bytes = (byte[])sqlCeDataReader["Data"];
			}
			File.WriteAllBytes(((FileDialog)val).FileName, bytes);
		}
	}

	private void ai(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject)
		{
			GameObject gameObject = ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag as GameObject;
			if ((int)MessageBox.Show("Are you sure you want to delete " + gameObject.name + "?", "Delete Confirmation", (MessageBoxButton)4) == 6)
			{
				TheGame.ObjectList.Remove(gameObject);
				z();
			}
		}
	}

	private void ah(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			GetNameWindow getNameWindow = new GetNameWindow();
			((Window)getNameWindow).Owner = (Window)(object)this;
			((ContentControl)getNameWindow.lblTitle).Content = "Please enter object name:";
			if (((Window)getNameWindow).ShowDialog() == true)
			{
				_ = gameObject.name;
				_ = getNameWindow.txtEntry.Text;
				gameObject.name = getNameWindow.txtEntry.Text;
				z();
				SelectTreeObject(gameObject.UniqueIdentifier, ((ItemsControl)g7).Items);
			}
		}
	}

	private void ag(object A_0, RoutedEventArgs A_1)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Enter Group Name:";
		((Window)getNameWindow).Owner = (Window)(object)this;
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		if (SaveLoad.DBName == string.Empty)
		{
			MessageBox.Show("The game will now be saved to create your item repository.");
			while (SaveLoad.DBName == string.Empty)
			{
				ar((object)null, (RoutedEventArgs)null);
				if (SaveLoad.DBName == string.Empty)
				{
					MessageBox.Show("Item insertion cancelled.");
					return;
				}
			}
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = getNameWindow.txtEntry.Text;
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from ItemGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		object selectedItem = g7.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		if (val == null)
		{
			a(getNameWindow.txtEntry.Text, ((ItemsControl)g7).Items);
		}
		else if (((FrameworkElement)val).Tag == null)
		{
			a(getNameWindow.txtEntry.Text, ((ItemsControl)val).Items);
		}
		else
		{
			DependencyObject parent = ((FrameworkElement)val).Parent;
			TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			if (val2 == null)
			{
				a(getNameWindow.txtEntry.Text, ((ItemsControl)g7).Items);
			}
			else
			{
				a(getNameWindow.txtEntry.Text, ((ItemsControl)val2).Items);
				value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString();
			}
		}
		dBConnection = SaveLoad.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			ar((object)null, (RoutedEventArgs)null);
			dBConnection = SaveLoad.GetDBConnection();
		}
		sqlCeCommand = new SqlCeCommand("insert into ItemGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		sqlCeCommand.Parameters.AddWithValue("@parent", value);
		sqlCeCommand.ExecuteNonQuery();
		z();
	}

	private void af(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem == null || ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject)
		{
			return;
		}
		string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)g7.SelectedItem).Header).Children[1]).Content.ToString();
		if ((int)MessageBox.Show("Are you sure you want to remove group " + text + "?", "Delete Group Confirmation", (MessageBoxButton)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update ItemGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (((FrameworkElement)(TreeViewItem)g7.SelectedItem).Parent != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Parent is TreeViewItem)
		{
			value = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)g7.SelectedItem).Parent).Header).Children[1]).Content.ToString();
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("update Items set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemGroups where name=@curparent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@curparent", text);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			SaveLoad.GameObject_UpdateGroupName(@object);
		}
		z();
	}

	private void ae(object A_0, RoutedEventArgs A_1)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		this.m_g = null;
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject data)
		{
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			MemoryStream memoryStream = new MemoryStream();
			sharpSerializer.Serialize(data, memoryStream);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			this.m_g = (GameObject)sharpSerializer.Deserialize(memoryStream);
		}
	}

	private void ad(object A_0, RoutedEventArgs A_1)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		if (this.m_g == null)
		{
			return;
		}
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		MemoryStream memoryStream = new MemoryStream();
		sharpSerializer.Serialize(this.m_g, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		GameObject gameObject = (GameObject)sharpSerializer.Deserialize(memoryStream);
		gameObject.UniqueIdentifier = Guid.NewGuid();
		bool flag = false;
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.UniqueIdentifier == gameObject.UniqueIdentifier)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if ((int)MessageBox.Show("There is already an object named " + this.m_g.name + ".  Would you like to rename this object?", "Duplicate Name", (MessageBoxButton)4) != 6)
			{
				return;
			}
			GetNameWindow getNameWindow = new GetNameWindow();
			((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Object Name:";
			((Window)getNameWindow).Owner = (Window)(object)this;
			if (((Window)getNameWindow).ShowDialog() != true)
			{
				return;
			}
			flag = false;
			gameObject.name = getNameWindow.txtEntry.Text;
			foreach (GameObject object2 in TheGame.ObjectList)
			{
				if (object2.UniqueIdentifier == gameObject.UniqueIdentifier)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				TheGame.ObjectList.Add(gameObject);
				z();
			}
			else
			{
				MessageBox.Show("Sorry, that object already exists.");
			}
		}
		else
		{
			TheGame.ObjectList.Add(gameObject);
			for (int i = 0; i < gameObject.Actions.Count; i++)
			{
				Rags.Action tempact = gameObject.Actions[i];
				TheGame.RefactorAction(ref tempact, this.m_g.UniqueIdentifier.ToString(), gameObject.UniqueIdentifier.ToString());
			}
			z();
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		if ((int)A_1.Key == 46 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			ae((object)null, (RoutedEventArgs)null);
			((RoutedEventArgs)A_1).Handled = true;
		}
		else if ((int)A_1.Key == 65 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			ad((object)null, (RoutedEventArgs)null);
			((RoutedEventArgs)A_1).Handled = true;
		}
	}

	private void ac(object A_0, RoutedEventArgs A_1)
	{
		foreach (Room selectedItem in ((ListBox)this.av).SelectedItems)
		{
			TheGame.RoomList.Remove(selectedItem);
		}
		t();
	}

	private void ab(object A_0, RoutedEventArgs A_1)
	{
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Room Name:";
		((Window)getNameWindow).Owner = (Window)(object)this;
		if (((Window)getNameWindow).ShowDialog() == true)
		{
			Room room = ((Selector)this.av).SelectedItem as Room;
			room.Name = getNameWindow.txtEntry.Text;
			t();
			((Selector)this.av).SelectedItem = room;
			a(room);
		}
	}

	private void aa(object A_0, RoutedEventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		if (((HeaderedItemsControl)(MenuItem)A_1.OriginalSource).Header.ToString() == "<Add New Group>")
		{
			GetNameWindow getNameWindow = new GetNameWindow();
			((ContentControl)getNameWindow.lblTitle).Content = "Enter new room group name:";
			((Window)getNameWindow).Owner = (Window)(object)this;
			bool? flag = ((Window)getNameWindow).ShowDialog();
			if (flag != true || !flag.HasValue || !(getNameWindow.txtEntry.Text.Trim() != string.Empty) || !(getNameWindow.txtEntry.Text.Trim() != "<Add New Group>"))
			{
				return;
			}
			TheGame.RoomGroups.Add(getNameWindow.txtEntry.Text);
			q();
			((Selector)this.a5).SelectedItem = getNameWindow.txtEntry.Text;
			{
				foreach (Room selectedItem in ((ListBox)this.av).SelectedItems)
				{
					selectedItem.Group = getNameWindow.txtEntry.Text;
				}
				return;
			}
		}
		foreach (Room selectedItem2 in ((ListBox)this.av).SelectedItems)
		{
			selectedItem2.Group = ((HeaderedItemsControl)(MenuItem)A_1.OriginalSource).Header.ToString();
		}
		((Selector)this.a5).SelectedItem = ((HeaderedItemsControl)(MenuItem)A_1.OriginalSource).Header.ToString();
	}

	private void z(object A_0, RoutedEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, this.m_b) && TheGame.CharacterList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for characters.  Please register your copy of RAGS.");
			return;
		}
		GetNameWindow getNameWindow = new GetNameWindow();
		((Window)getNameWindow).Owner = (Window)(object)this;
		((ContentControl)getNameWindow.lblTitle).Content = "Please enter character name:";
		if (((Window)getNameWindow).ShowDialog() != true)
		{
			return;
		}
		foreach (Character character3 in TheGame.CharacterList)
		{
			if (character3.Charname.ToUpper() == getNameWindow.txtEntry.Text.ToUpper())
			{
				MessageBox.Show("Sorry, you already have a character named " + getNameWindow.txtEntry.Text + ".  Please use a unique character name.  If you need duplicate character names, please use the override name option in the character's general setup.");
				return;
			}
		}
		Character character = new Character(getNameWindow.txtEntry.Text);
		if (TheGame.CharacterList.Count > 0)
		{
			Character character2 = TheGame.CharacterList[0];
			if (character2 != null)
			{
				foreach (CustomProperty customProperty in character2.CustomProperties)
				{
					character.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
				}
			}
		}
		TheGame.CharacterList.Add(character);
		ad();
		((Selector)eb).SelectedItem = character;
		ae();
	}

	private void y(object A_0, RoutedEventArgs A_1)
	{
		foreach (Character selectedItem in ((ListBox)eb).SelectedItems)
		{
			TheGame.CharacterList.Remove(selectedItem);
		}
		ad();
	}

	private void x(object A_0, RoutedEventArgs A_1)
	{
		foreach (Rags.Timer selectedItem in ((ListBox)f4).SelectedItems)
		{
			TheGame.TimerList.Remove(selectedItem);
		}
		af();
	}

	private void w(object A_0, RoutedEventArgs A_1)
	{
		QuickMenuItemWindow quickMenuItemWindow = new QuickMenuItemWindow(ref TheGame.QuickCommands, ref TheGame);
		((Window)quickMenuItemWindow).ShowDialog();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "WPFQuickCommands.bin");
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			sharpSerializer.Serialize(TheGame.QuickCommands, fileStream);
			fileStream.Flush();
			fileStream.Close();
			fileStream.Dispose();
			fileStream = null;
		}
		finally
		{
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream.Dispose();
			}
		}
	}

	private void v(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)this.ct).SelectedItem != null && this.ct.Text.Trim().Length > 0)
		{
			TheGame.ThePlayer.StartingRoom = TheGame.GetRoomByID(((RoomComboItem)((Selector)this.ct).SelectedItem).UniqueID);
		}
	}

	private void u(object A_0, RoutedEventArgs A_1)
	{
		NewGameWindow newGameWindow = new NewGameWindow();
		((Window)newGameWindow).Owner = (Window)(object)this;
		((ToggleButton)newGameWindow.c).IsChecked = true;
		if (((Window)newGameWindow).ShowDialog() == true)
		{
			this.m_c = string.Empty;
			((Window)this).Title = "Rags Designer - " + this.m_c;
			TheGame = new Game();
			SaveLoad.DBName = string.Empty;
			if (((ToggleButton)newGameWindow.a).IsChecked == true)
			{
				e();
			}
			else if (((ToggleButton)newGameWindow.b).IsChecked == true)
			{
				d();
			}
			ai();
		}
	}

	private void e()
	{
		Room room = new Room();
		room.Description = "Beginning test room.";
		room.Name = "Beginning room";
		TheGame.RoomList.Add(room);
		Room room2 = new Room();
		TheGame.RoomList.Add(room2);
		room.GetExit(Exit.Directions.North).DestinationRoom = room2.UniqueID.ToString();
		room2.GetExit(Exit.Directions.South).DestinationRoom = room.UniqueID.ToString();
		room.GetExit(Exit.Directions.North).bActive = true;
		room2.GetExit(Exit.Directions.South).bActive = true;
		room2.Description = "Destination room.";
		room2.Name = "Destination room";
		TheGame.ThePlayer.StartingRoom = room;
		TheGame.ThePlayer.Name = "Bobby";
		TheGame.Title = "Simple two room game";
		TheGame.OpeningMessage = "This is a simple two room game demonstration.";
	}

	private void d()
	{
		TheGame.Title = "Simple four room game";
		TheGame.OpeningMessage = "This is a simple four room game demonstration.";
		TheGame.ThePlayer.Name = "Bobby";
		Room room = new Room();
		room.Description = "Beginning test room.";
		room.Name = "Beginning room";
		TheGame.RoomList.Add(room);
		Room room2 = new Room();
		TheGame.RoomList.Add(room2);
		room.GetExit(Exit.Directions.North).DestinationRoom = room2.UniqueID.ToString();
		room2.GetExit(Exit.Directions.South).DestinationRoom = room.UniqueID.ToString();
		room.GetExit(Exit.Directions.North).bActive = true;
		room2.GetExit(Exit.Directions.South).bActive = true;
		room2.Description = "Destination room.";
		room2.Name = "Destination room";
		Room room3 = new Room();
		TheGame.RoomList.Add(room3);
		room2.GetExit(Exit.Directions.West).DestinationRoom = room3.UniqueID.ToString();
		room3.GetExit(Exit.Directions.East).DestinationRoom = room2.UniqueID.ToString();
		room2.GetExit(Exit.Directions.West).bActive = true;
		room3.GetExit(Exit.Directions.East).bActive = true;
		room3.Description = "Western room.";
		room3.Name = "Western room";
		Room room4 = new Room();
		TheGame.RoomList.Add(room4);
		room2.GetExit(Exit.Directions.East).DestinationRoom = room4.UniqueID.ToString();
		room4.GetExit(Exit.Directions.West).DestinationRoom = room2.UniqueID.ToString();
		room2.GetExit(Exit.Directions.East).bActive = true;
		room4.GetExit(Exit.Directions.West).bActive = true;
		room4.Description = "Eastern room.";
		room4.Name = "Eastern room";
		TheGame.ThePlayer.StartingRoom = room;
	}

	private void t(object A_0, RoutedEventArgs A_1)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length > 1)
		{
			string text = Environment.GetCommandLineArgs()[1];
			if (text != null)
			{
				a(text);
			}
		}
		SaveLoad.LoadQuickCommands(ref TheGame);
		ThreadPool.QueueUserWorkItem(a, TheGame);
		DispatcherTimer val = new DispatcherTimer();
		val.Tick += b;
		val.Interval = new TimeSpan(0, 0, 30);
		val.Start();
		if (!Settings.Default.AutoSaveInitiallySet)
		{
			MessageBox.Show("It appears that your auto save settings have not been set.  You will now be prompted to set them.");
			AutoSaveSettingsWindow autoSaveSettingsWindow = new AutoSaveSettingsWindow();
			((Window)autoSaveSettingsWindow).Owner = (Window)(object)this;
			((Window)autoSaveSettingsWindow).ShowDialog();
			Settings.Default.AutoSaveInitiallySet = true;
		}
		c();
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		if (RagsDesigner.m_e)
		{
			RagsDesigner.m_e = false;
			if ((int)MessageBox.Show("There is a newer version of the Rags Suite available.  Would you like to update now?", "Update Available", (MessageBoxButton)4) == 6)
			{
				Process.Start("http://www.ragsgame.com/?page_id=6");
			}
		}
		if (RagsDesigner.m_f)
		{
			RagsDesigner.m_f = false;
			if ((int)MessageBox.Show("There is a newer BETA version of the Rags Suite available.  Would you like to update now?", "Update Available", (MessageBoxButton)4) == 6)
			{
				Process.Start("http://www.ragsgame.com/?page_id=6");
			}
		}
	}

	private static void a(object A_0)
	{
		try
		{
			CheckUpdatesSoapClient checkUpdatesSoapClient = new CheckUpdatesSoapClient();
			string version = checkUpdatesSoapClient.CheckVersion();
			string version2 = checkUpdatesSoapClient.CheckBetaVersion();
			Version version3 = new Version(version);
			Version version4 = new Version(version2);
			Version version5 = new Version(Game.ObjectVersionNumber);
			if (version3 > version5)
			{
				RagsDesigner.m_e = true;
			}
			if (version4 > version5)
			{
				RagsDesigner.m_f = true;
			}
		}
		catch
		{
		}
	}

	private void s(object A_0, RoutedEventArgs A_1)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		ar((object)null, (RoutedEventArgs)null);
		DateTime now = DateTime.Now;
		while (!SaveLoad.bDoneWithWaitDlg && !((DateTime.Now - now).TotalSeconds > 5.0))
		{
			Thread.Sleep(30);
		}
		try
		{
			SaveLoad.TheCon.Close();
			string fileName = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "RAGSWPFPlayer.exe");
			Process.Start(fileName, "\"" + this.m_c + "\" DEBUG");
		}
		catch (Exception ex)
		{
			MessageBox.Show("Unable to start the Rags Game in debug mode.  Error Message:" + ex.Message);
		}
	}

	private void r(object A_0, RoutedEventArgs A_1)
	{
		TheGame.ThePlayer.Description = this.cw.Text;
	}

	private void q(object A_0, RoutedEventArgs A_1)
	{
		TheGame.ThePlayer.Name = this.cm.Text;
	}

	private void p(object A_0, RoutedEventArgs A_1)
	{
		TheGame.ThePlayer.bPromptForGender = ((ToggleButton)this.cn).IsChecked.Value;
	}

	private void o(object A_0, RoutedEventArgs A_1)
	{
		TheGame.ThePlayer.bPromptForName = ((ToggleButton)this.cl).IsChecked.Value;
	}

	private void n(object A_0, RoutedEventArgs A_1)
	{
		if (((ToggleButton)this.co).IsChecked == true)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Male;
		}
		else if (((ToggleButton)this.cp).IsChecked == true)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Female;
		}
		else if (((ToggleButton)this.cq).IsChecked == true)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Other;
		}
	}

	private void m(object A_0, RoutedEventArgs A_1)
	{
		TheGame.ThePlayer.bEnforceWeight = ((ToggleButton)this.cr).IsChecked.Value;
	}

	private void l(object A_0, RoutedEventArgs A_1)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		try
		{
			num = Convert.ToDouble(this.cs.Text);
		}
		catch
		{
			MessageBox.Show("Please Enter A Valid Number For Carry Weight Limit.");
			((UIElement)this.cs).Focus();
			return;
		}
		TheGame.ThePlayer.dWeightLimit = num;
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)this.cx).SelectedItem == null)
		{
			return;
		}
		if (((Selector)this.cx).SelectedItem.ToString() == "None")
		{
			((FrameworkElement)this.cy).Tag = null;
			this.cy.Source = null;
			TheGame.ThePlayer.PlayerPortrait = "";
			return;
		}
		TheGame.ThePlayer.PlayerPortrait = ((Selector)this.cx).SelectedItem.ToString();
		object pictureByName = SaveLoad.GetPictureByName(((Selector)this.cx).SelectedItem.ToString(), ref TheGame);
		if (pictureByName != null)
		{
			((FrameworkElement)this.cy).Tag = SaveLoad.GetGamePictureByName(((Selector)this.cx).SelectedItem.ToString(), ref TheGame);
			this.cy.Source = new Uri(pictureByName.ToString());
		}
	}

	private void k(object A_0, RoutedEventArgs A_1)
	{
		SaveLoad.CorrectCommandAndConditions(ref TheGame);
		ai();
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (g7.SelectedItem != null && ((FrameworkElement)(TreeViewItem)g7.SelectedItem).Tag is GameObject gameObject)
		{
			((ToggleButton)this.da).IsChecked = gameObject.bCarryable;
			((ToggleButton)this.dc).IsChecked = gameObject.bContainer;
			((ToggleButton)this.db).IsChecked = gameObject.bWearable;
			((ToggleButton)this.dd).IsChecked = gameObject.bOpenable;
			((UIElement)this.dq).IsEnabled = gameObject.bContainer;
			((ToggleButton)this.dm).IsChecked = gameObject.bLockable;
			((ToggleButton)this.dn).IsChecked = gameObject.bEnterable;
			((ToggleButton)this.@do).IsChecked = gameObject.bReadable;
			((UIElement)this.dz).IsEnabled = true;
			if (gameObject.bVisible)
			{
				((ToggleButton)this.dk).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.dl).IsChecked = true;
			}
			if (gameObject.bOpen)
			{
				((ToggleButton)this.de).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.df).IsChecked = true;
			}
			if (gameObject.bLocked)
			{
				((ToggleButton)this.di).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.dj).IsChecked = true;
			}
			if (gameObject.bWorn)
			{
				((ToggleButton)this.dg).IsChecked = true;
			}
			else
			{
				((ToggleButton)this.dh).IsChecked = true;
			}
			((ToggleButton)this.c9).IsChecked = gameObject.bImportant;
		}
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).Filter = "Xml Files|*.xml|All files|*.*";
		((FileDialog)val).DefaultExt = ".xml";
		if (((CommonDialog)val).ShowDialog() != true)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(File.ReadAllText(((FileDialog)val).FileName));
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("RAGSGAME");
		if (xmlNodeList.Count > 0)
		{
			XmlNode CurNode = xmlNodeList[0];
			TheGame = SaveLoad.Game_SetXMLData(ref CurNode);
			if (!p())
			{
				MessageBox.Show("This game will be in read only mode due to trial limitations.");
			}
		}
		ai();
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		if (!p())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  It can not be exported.");
			return;
		}
		ExportXMLSelectionWindow exportXMLSelectionWindow = new ExportXMLSelectionWindow();
		if (((Window)exportXMLSelectionWindow).ShowDialog() == true)
		{
			SaveFileDialog val = new SaveFileDialog();
			((FileDialog)val).Filter = "Xml Files|*.xml|All files|*.*";
			((FileDialog)val).DefaultExt = ".xml";
			if (((CommonDialog)val).ShowDialog() == true)
			{
				StreamWriter CurDoc = new StreamWriter(((FileDialog)val).FileName);
				SaveLoad.Game_GetXMLData(ref CurDoc, ((ToggleButton)exportXMLSelectionWindow.b).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.c).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.d).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.e).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.f).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.g).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.a).IsChecked.Value, ((ToggleButton)exportXMLSelectionWindow.h).IsChecked.Value, TheGame);
				CurDoc.Close();
			}
		}
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (!p())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
			return;
		}
		FolderBrowserDialog val = new FolderBrowserDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 2)
		{
			return;
		}
		if (TheGame.RoomList.Count <= 0 || TheGame.ThePlayer.StartingRoom == null)
		{
			MessageBox.Show("Unable to create website.  The game may not be complete.  Please verify the game has rooms and a starting room for the player assigned before continuing.");
			return;
		}
		try
		{
			Mouse.OverrideCursor = Cursors.Wait;
			foreach (GamePicture picture in TheGame.PictureList)
			{
				SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Name", picture.TheName);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
				if (sqlCeDataReader.Read())
				{
					picture.ImageData = (byte[])sqlCeDataReader["Data"];
				}
				sqlCeDataReader.Close();
				sqlCeDataReader.Dispose();
				sqlCeCommand.Dispose();
			}
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			string text = TheGame.Title;
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char c in invalidFileNameChars)
			{
				text = text.Replace(c.ToString(), "");
			}
			sharpSerializer.Serialize(TheGame, Path.Combine(val.SelectedPath, "game.bin"));
			foreach (GamePicture picture2 in TheGame.PictureList)
			{
				picture2.ImageData = null;
			}
			a("RagsSvPlayer.xap", val.SelectedPath);
			ZipArchive zipArchive = ZipFile.Open(Path.Combine(val.SelectedPath, "RagsSvPlayer.xap"), ZipArchiveMode.Update);
			zipArchive.GetEntry("game.bin")?.Delete();
			zipArchive.CreateEntryFromFile(Path.Combine(val.SelectedPath, "game.bin"), "game.bin");
			zipArchive.Dispose();
			File.Delete(Path.Combine(val.SelectedPath, "game.bin"));
			a("RagsPlayer.html", val.SelectedPath, text + ".html");
			a("Silverlight.js", val.SelectedPath);
		}
		finally
		{
			Mouse.OverrideCursor = null;
		}
	}

	private void a(string A_0, string A_1, string A_2 = "")
	{
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFRagsDesigner.Resources.Silverlight." + A_0);
		FileStream fileStream = null;
		fileStream = ((!(A_2 != "")) ? new FileStream(Path.Combine(A_1, A_0), FileMode.Create) : new FileStream(Path.Combine(A_1, A_2), FileMode.Create));
		byte[] array = new byte[manifestResourceStream.Length + 1];
		manifestResourceStream.Read(array, 0, array.Length - 1);
		fileStream.Write(array, 0, array.Length - 1);
		fileStream.Flush();
		fileStream.Close();
		fileStream.Dispose();
		manifestResourceStream.Close();
		manifestResourceStream.Dispose();
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		AutoSaveSettingsWindow autoSaveSettingsWindow = new AutoSaveSettingsWindow();
		((Window)autoSaveSettingsWindow).Owner = (Window)(object)this;
		((Window)autoSaveSettingsWindow).ShowDialog();
		c();
	}

	private void c()
	{
		if (Settings.Default.UseAutoSave)
		{
			this.m_h.IsEnabled = true;
			b();
		}
		else
		{
			this.m_h.IsEnabled = false;
		}
	}

	private void b()
	{
		this.m_h.Stop();
		this.m_h.Interval = new TimeSpan(0, Settings.Default.AutoSaveMinutes, 0);
		this.m_h.Start();
	}

	private void a(object A_0, EventArgs A_1)
	{
		ar((object)null, (RoutedEventArgs)null);
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		SearchWindow searchWindow = new SearchWindow(this);
		((Window)searchWindow).Owner = (Window)(object)this;
		((Window)searchWindow).Show();
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		GradientPickerWindow gradientPickerWindow = new GradientPickerWindow();
		((Window)gradientPickerWindow).Owner = (Window)(object)this;
		bool? flag = ((Window)gradientPickerWindow).ShowDialog();
		if (flag == true && flag.HasValue && ((HeaderedItemsControl)(MenuItem)A_1.OriginalSource).Header.ToString() == "General")
		{
			((Control)this.v).Background = ((Shape)gradientPickerWindow.f).Fill;
			((Panel)this.w).Background = ((Shape)gradientPickerWindow.f).Fill;
			((Control)this.x).Background = ((Shape)gradientPickerWindow.f).Fill;
			((Control)this.aq).Background = ((Shape)gradientPickerWindow.f).Fill;
			Settings.Default.GeneralGrid = (LinearGradientBrush)((Shape)gradientPickerWindow.f).Fill;
			((SettingsBase)Settings.Default).Save();
		}
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((GameVariable)((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag).dMax = fn.Text;
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((GameVariable)((FrameworkElement)(TreeViewItem)e1.SelectedItem).Tag).dMin = fm.Text;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		XmlLanguage language = ((FrameworkElement)this.i).Language;
		SelectCultureWindow selectCultureWindow = new SelectCultureWindow(language.GetEquivalentCulture());
		if (((Window)selectCultureWindow).ShowDialog() == true)
		{
			CultureData cultureData = ((Selector)selectCultureWindow.b).SelectedItem as CultureData;
			((FrameworkElement)this.i).Language = XmlLanguage.GetLanguage(cultureData.Data.IetfLanguageTag);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate a(Type A_0, string A_1)
	{
		return Delegate.CreateDelegate(A_0, this, A_1);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected Obj, but got Unknown
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected Obj, but got Unknown
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected Obj, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected Obj, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected Obj, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected Obj, but got Unknown
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected Obj, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected Obj, but got Unknown
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Expected Obj, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected Obj, but got Unknown
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Expected Obj, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected Obj, but got Unknown
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected Obj, but got Unknown
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Expected Obj, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected Obj, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected Obj, but got Unknown
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected Obj, but got Unknown
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Expected Obj, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected Obj, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Expected Obj, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected Obj, but got Unknown
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Expected Obj, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected Obj, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected Obj, but got Unknown
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Expected Obj, but got Unknown
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Expected Obj, but got Unknown
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected Obj, but got Unknown
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected Obj, but got Unknown
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Expected Obj, but got Unknown
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_072d: Expected Obj, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected Obj, but got Unknown
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Expected Obj, but got Unknown
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Expected Obj, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected Obj, but got Unknown
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Expected Obj, but got Unknown
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0785: Expected Obj, but got Unknown
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Expected Obj, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected Obj, but got Unknown
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Expected Obj, but got Unknown
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Expected Obj, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected Obj, but got Unknown
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected Obj, but got Unknown
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Expected Obj, but got Unknown
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected Obj, but got Unknown
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0836: Expected Obj, but got Unknown
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected Obj, but got Unknown
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected Obj, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected Obj, but got Unknown
		//IL_0874: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Expected Obj, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected Obj, but got Unknown
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Expected Obj, but got Unknown
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Expected Obj, but got Unknown
		//IL_08c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Expected Obj, but got Unknown
		//IL_08d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Expected Obj, but got Unknown
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected Obj, but got Unknown
		//IL_08f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Expected Obj, but got Unknown
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Expected Obj, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Expected Obj, but got Unknown
		//IL_0932: Unknown result type (might be due to invalid IL or missing references)
		//IL_093c: Expected Obj, but got Unknown
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0949: Expected Obj, but got Unknown
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Expected Obj, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected Obj, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0984: Expected Obj, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Expected Obj, but got Unknown
		//IL_099e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a8: Expected Obj, but got Unknown
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Expected Obj, but got Unknown
		//IL_09c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cc: Expected Obj, but got Unknown
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected Obj, but got Unknown
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fb: Expected Obj, but got Unknown
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Expected Obj, but got Unknown
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Expected Obj, but got Unknown
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Expected Obj, but got Unknown
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected Obj, but got Unknown
		//IL_0a50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Expected Obj, but got Unknown
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Expected Obj, but got Unknown
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected Obj, but got Unknown
		//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Expected Obj, but got Unknown
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Expected Obj, but got Unknown
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aba: Expected Obj, but got Unknown
		//IL_0abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Expected Obj, but got Unknown
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adf: Expected Obj, but got Unknown
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Expected Obj, but got Unknown
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b03: Expected Obj, but got Unknown
		//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected Obj, but got Unknown
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Expected Obj, but got Unknown
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Expected Obj, but got Unknown
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Expected Obj, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Expected Obj, but got Unknown
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b83: Expected Obj, but got Unknown
		//IL_0b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b90: Expected Obj, but got Unknown
		//IL_0b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba7: Expected Obj, but got Unknown
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbe: Expected Obj, but got Unknown
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Expected Obj, but got Unknown
		//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected Obj, but got Unknown
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Expected Obj, but got Unknown
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c06: Expected Obj, but got Unknown
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Expected Obj, but got Unknown
		//IL_0c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected Obj, but got Unknown
		//IL_0c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c37: Expected Obj, but got Unknown
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Expected Obj, but got Unknown
		//IL_0c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Expected Obj, but got Unknown
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Expected Obj, but got Unknown
		//IL_0c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7f: Expected Obj, but got Unknown
		//IL_0c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c96: Expected Obj, but got Unknown
		//IL_0c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Expected Obj, but got Unknown
		//IL_0cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbb: Expected Obj, but got Unknown
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected Obj, but got Unknown
		//IL_0ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd5: Expected Obj, but got Unknown
		//IL_0ce2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cec: Expected Obj, but got Unknown
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf9: Expected Obj, but got Unknown
		//IL_0cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Expected Obj, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1d: Expected Obj, but got Unknown
		//IL_0d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d34: Expected Obj, but got Unknown
		//IL_0d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Expected Obj, but got Unknown
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d58: Expected Obj, but got Unknown
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6f: Expected Obj, but got Unknown
		//IL_0d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Expected Obj, but got Unknown
		//IL_0d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d93: Expected Obj, but got Unknown
		//IL_0da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0daa: Expected Obj, but got Unknown
		//IL_0db7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc1: Expected Obj, but got Unknown
		//IL_0dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dce: Expected Obj, but got Unknown
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Expected Obj, but got Unknown
		//IL_0de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Expected Obj, but got Unknown
		//IL_0df5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dff: Expected Obj, but got Unknown
		//IL_0e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0c: Expected Obj, but got Unknown
		//IL_0e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e19: Expected Obj, but got Unknown
		//IL_0e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e30: Expected Obj, but got Unknown
		//IL_0e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3d: Expected Obj, but got Unknown
		//IL_0e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Expected Obj, but got Unknown
		//IL_0e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e61: Expected Obj, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Expected Obj, but got Unknown
		//IL_0e7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e85: Expected Obj, but got Unknown
		//IL_0e92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9c: Expected Obj, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Expected Obj, but got Unknown
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec0: Expected Obj, but got Unknown
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecd: Expected Obj, but got Unknown
		//IL_0eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee4: Expected Obj, but got Unknown
		//IL_0ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef1: Expected Obj, but got Unknown
		//IL_0efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Expected Obj, but got Unknown
		//IL_0f0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f15: Expected Obj, but got Unknown
		//IL_0f22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2c: Expected Obj, but got Unknown
		//IL_0f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f39: Expected Obj, but got Unknown
		//IL_0f46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f50: Expected Obj, but got Unknown
		//IL_0f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5d: Expected Obj, but got Unknown
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Expected Obj, but got Unknown
		//IL_0f77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f81: Expected Obj, but got Unknown
		//IL_0f8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f98: Expected Obj, but got Unknown
		//IL_0f9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected Obj, but got Unknown
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Expected Obj, but got Unknown
		//IL_0fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc9: Expected Obj, but got Unknown
		//IL_0fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe0: Expected Obj, but got Unknown
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fed: Expected Obj, but got Unknown
		//IL_0ffa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1004: Expected Obj, but got Unknown
		//IL_1007: Unknown result type (might be due to invalid IL or missing references)
		//IL_1011: Expected Obj, but got Unknown
		//IL_101e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1028: Expected Obj, but got Unknown
		//IL_102b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1035: Expected Obj, but got Unknown
		//IL_1042: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Expected Obj, but got Unknown
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1059: Expected Obj, but got Unknown
		//IL_1066: Unknown result type (might be due to invalid IL or missing references)
		//IL_1070: Expected Obj, but got Unknown
		//IL_1073: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Expected Obj, but got Unknown
		//IL_108a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1094: Expected Obj, but got Unknown
		//IL_1097: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Expected Obj, but got Unknown
		//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b8: Expected Obj, but got Unknown
		//IL_10bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c5: Expected Obj, but got Unknown
		//IL_10d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10dc: Expected Obj, but got Unknown
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e9: Expected Obj, but got Unknown
		//IL_10f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1100: Expected Obj, but got Unknown
		//IL_1103: Unknown result type (might be due to invalid IL or missing references)
		//IL_110d: Expected Obj, but got Unknown
		//IL_111a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1124: Expected Obj, but got Unknown
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1131: Expected Obj, but got Unknown
		//IL_113e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1148: Expected Obj, but got Unknown
		//IL_114b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1155: Expected Obj, but got Unknown
		//IL_1162: Unknown result type (might be due to invalid IL or missing references)
		//IL_116c: Expected Obj, but got Unknown
		//IL_116f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1179: Expected Obj, but got Unknown
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_1190: Expected Obj, but got Unknown
		//IL_1193: Unknown result type (might be due to invalid IL or missing references)
		//IL_119d: Expected Obj, but got Unknown
		//IL_11aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b4: Expected Obj, but got Unknown
		//IL_11b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Expected Obj, but got Unknown
		//IL_11ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d8: Expected Obj, but got Unknown
		//IL_11db: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Expected Obj, but got Unknown
		//IL_11f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fc: Expected Obj, but got Unknown
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1209: Expected Obj, but got Unknown
		//IL_1216: Unknown result type (might be due to invalid IL or missing references)
		//IL_1220: Expected Obj, but got Unknown
		//IL_1223: Unknown result type (might be due to invalid IL or missing references)
		//IL_122d: Expected Obj, but got Unknown
		//IL_123a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Expected Obj, but got Unknown
		//IL_1247: Unknown result type (might be due to invalid IL or missing references)
		//IL_1251: Expected Obj, but got Unknown
		//IL_125e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1268: Expected Obj, but got Unknown
		//IL_126b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Expected Obj, but got Unknown
		//IL_1282: Unknown result type (might be due to invalid IL or missing references)
		//IL_128c: Expected Obj, but got Unknown
		//IL_128f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1299: Expected Obj, but got Unknown
		//IL_12a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b0: Expected Obj, but got Unknown
		//IL_12b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bd: Expected Obj, but got Unknown
		//IL_12ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d4: Expected Obj, but got Unknown
		//IL_12d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e1: Expected Obj, but got Unknown
		//IL_12ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f8: Expected Obj, but got Unknown
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Expected Obj, but got Unknown
		//IL_1312: Unknown result type (might be due to invalid IL or missing references)
		//IL_131c: Expected Obj, but got Unknown
		//IL_131f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1329: Expected Obj, but got Unknown
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1336: Expected Obj, but got Unknown
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_1343: Expected Obj, but got Unknown
		//IL_1350: Unknown result type (might be due to invalid IL or missing references)
		//IL_135a: Expected Obj, but got Unknown
		//IL_1367: Unknown result type (might be due to invalid IL or missing references)
		//IL_1371: Expected Obj, but got Unknown
		//IL_1374: Unknown result type (might be due to invalid IL or missing references)
		//IL_137e: Expected Obj, but got Unknown
		//IL_138b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1395: Expected Obj, but got Unknown
		//IL_1398: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a2: Expected Obj, but got Unknown
		//IL_13af: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b9: Expected Obj, but got Unknown
		//IL_13bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d1: Expected Obj, but got Unknown
		//IL_13d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13de: Expected Obj, but got Unknown
		//IL_13eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f5: Expected Obj, but got Unknown
		//IL_13f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1402: Expected Obj, but got Unknown
		//IL_140f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Expected Obj, but got Unknown
		//IL_1426: Unknown result type (might be due to invalid IL or missing references)
		//IL_1430: Expected Obj, but got Unknown
		//IL_1433: Unknown result type (might be due to invalid IL or missing references)
		//IL_143d: Expected Obj, but got Unknown
		//IL_144a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1454: Expected Obj, but got Unknown
		//IL_1461: Unknown result type (might be due to invalid IL or missing references)
		//IL_146b: Expected Obj, but got Unknown
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_1483: Expected Obj, but got Unknown
		//IL_1485: Unknown result type (might be due to invalid IL or missing references)
		//IL_1491: Unknown result type (might be due to invalid IL or missing references)
		//IL_149b: Expected Obj, but got Unknown
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b3: Expected Obj, but got Unknown
		//IL_14c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cd: Expected Obj, but got Unknown
		//IL_14d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14da: Expected Obj, but got Unknown
		//IL_14e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f1: Expected Obj, but got Unknown
		//IL_14f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fe: Expected Obj, but got Unknown
		//IL_150b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1515: Expected Obj, but got Unknown
		//IL_1522: Unknown result type (might be due to invalid IL or missing references)
		//IL_152c: Expected Obj, but got Unknown
		//IL_1539: Unknown result type (might be due to invalid IL or missing references)
		//IL_1543: Expected Obj, but got Unknown
		//IL_1546: Unknown result type (might be due to invalid IL or missing references)
		//IL_1550: Expected Obj, but got Unknown
		//IL_155d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1567: Expected Obj, but got Unknown
		//IL_156a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1574: Expected Obj, but got Unknown
		//IL_1581: Unknown result type (might be due to invalid IL or missing references)
		//IL_158b: Expected Obj, but got Unknown
		//IL_158e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Expected Obj, but got Unknown
		//IL_15a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15af: Expected Obj, but got Unknown
		//IL_15b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Expected Obj, but got Unknown
		//IL_15c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d3: Expected Obj, but got Unknown
		//IL_15d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e0: Expected Obj, but got Unknown
		//IL_15ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f7: Expected Obj, but got Unknown
		//IL_15fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1604: Expected Obj, but got Unknown
		//IL_1611: Unknown result type (might be due to invalid IL or missing references)
		//IL_161b: Expected Obj, but got Unknown
		//IL_1628: Unknown result type (might be due to invalid IL or missing references)
		//IL_1632: Expected Obj, but got Unknown
		//IL_1635: Unknown result type (might be due to invalid IL or missing references)
		//IL_163f: Expected Obj, but got Unknown
		//IL_164c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1656: Expected Obj, but got Unknown
		//IL_1659: Unknown result type (might be due to invalid IL or missing references)
		//IL_1663: Expected Obj, but got Unknown
		//IL_1670: Unknown result type (might be due to invalid IL or missing references)
		//IL_167a: Expected Obj, but got Unknown
		//IL_167d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1687: Expected Obj, but got Unknown
		//IL_1694: Unknown result type (might be due to invalid IL or missing references)
		//IL_169e: Expected Obj, but got Unknown
		//IL_16a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b6: Expected Obj, but got Unknown
		//IL_16b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c3: Expected Obj, but got Unknown
		//IL_16d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16da: Expected Obj, but got Unknown
		//IL_16e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Expected Obj, but got Unknown
		//IL_16fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1708: Expected Obj, but got Unknown
		//IL_170b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1715: Expected Obj, but got Unknown
		//IL_1722: Unknown result type (might be due to invalid IL or missing references)
		//IL_172c: Expected Obj, but got Unknown
		//IL_172f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1739: Expected Obj, but got Unknown
		//IL_173c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1746: Expected Obj, but got Unknown
		//IL_1753: Unknown result type (might be due to invalid IL or missing references)
		//IL_175d: Expected Obj, but got Unknown
		//IL_1760: Unknown result type (might be due to invalid IL or missing references)
		//IL_176a: Expected Obj, but got Unknown
		//IL_1777: Unknown result type (might be due to invalid IL or missing references)
		//IL_1781: Expected Obj, but got Unknown
		//IL_178e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1798: Expected Obj, but got Unknown
		//IL_179b: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a5: Expected Obj, but got Unknown
		//IL_17b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bc: Expected Obj, but got Unknown
		//IL_17c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d3: Expected Obj, but got Unknown
		//IL_17d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17eb: Expected Obj, but got Unknown
		//IL_17ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1803: Expected Obj, but got Unknown
		//IL_1805: Unknown result type (might be due to invalid IL or missing references)
		//IL_1811: Unknown result type (might be due to invalid IL or missing references)
		//IL_181b: Expected Obj, but got Unknown
		//IL_182b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1835: Expected Obj, but got Unknown
		//IL_1837: Unknown result type (might be due to invalid IL or missing references)
		//IL_1843: Unknown result type (might be due to invalid IL or missing references)
		//IL_184d: Expected Obj, but got Unknown
		//IL_184f: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1865: Expected Obj, but got Unknown
		//IL_1868: Unknown result type (might be due to invalid IL or missing references)
		//IL_1872: Expected Obj, but got Unknown
		//IL_1875: Unknown result type (might be due to invalid IL or missing references)
		//IL_187f: Expected Obj, but got Unknown
		//IL_188c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1896: Expected Obj, but got Unknown
		//IL_1899: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a3: Expected Obj, but got Unknown
		//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ba: Expected Obj, but got Unknown
		//IL_18c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d1: Expected Obj, but got Unknown
		//IL_18de: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e8: Expected Obj, but got Unknown
		//IL_18eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f5: Expected Obj, but got Unknown
		//IL_1902: Unknown result type (might be due to invalid IL or missing references)
		//IL_190c: Expected Obj, but got Unknown
		//IL_1919: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Expected Obj, but got Unknown
		//IL_1930: Unknown result type (might be due to invalid IL or missing references)
		//IL_193a: Expected Obj, but got Unknown
		//IL_193d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1947: Expected Obj, but got Unknown
		//IL_1954: Unknown result type (might be due to invalid IL or missing references)
		//IL_195e: Expected Obj, but got Unknown
		//IL_196b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Expected Obj, but got Unknown
		//IL_1982: Unknown result type (might be due to invalid IL or missing references)
		//IL_198c: Expected Obj, but got Unknown
		//IL_198f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1999: Expected Obj, but got Unknown
		//IL_19a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b0: Expected Obj, but got Unknown
		//IL_19b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bd: Expected Obj, but got Unknown
		//IL_19ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d4: Expected Obj, but got Unknown
		//IL_19d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e1: Expected Obj, but got Unknown
		//IL_19ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f8: Expected Obj, but got Unknown
		//IL_19fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a05: Expected Obj, but got Unknown
		//IL_1a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1c: Expected Obj, but got Unknown
		//IL_1a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a33: Expected Obj, but got Unknown
		//IL_1a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4a: Expected Obj, but got Unknown
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a57: Expected Obj, but got Unknown
		//IL_1a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6e: Expected Obj, but got Unknown
		//IL_1a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7b: Expected Obj, but got Unknown
		//IL_1a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a92: Expected Obj, but got Unknown
		//IL_1a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9f: Expected Obj, but got Unknown
		//IL_1aac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab6: Expected Obj, but got Unknown
		//IL_1ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac3: Expected Obj, but got Unknown
		//IL_1ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ada: Expected Obj, but got Unknown
		//IL_1add: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae7: Expected Obj, but got Unknown
		//IL_1af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afe: Expected Obj, but got Unknown
		//IL_1b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0b: Expected Obj, but got Unknown
		//IL_1b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b22: Expected Obj, but got Unknown
		//IL_1b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2f: Expected Obj, but got Unknown
		//IL_1b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b46: Expected Obj, but got Unknown
		//IL_1b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b53: Expected Obj, but got Unknown
		//IL_1b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6a: Expected Obj, but got Unknown
		//IL_1b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b77: Expected Obj, but got Unknown
		//IL_1b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8e: Expected Obj, but got Unknown
		//IL_1b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9b: Expected Obj, but got Unknown
		//IL_1ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb2: Expected Obj, but got Unknown
		//IL_1bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbf: Expected Obj, but got Unknown
		//IL_1bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd6: Expected Obj, but got Unknown
		//IL_1bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be3: Expected Obj, but got Unknown
		//IL_1bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Expected Obj, but got Unknown
		//IL_1bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c07: Expected Obj, but got Unknown
		//IL_1c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1e: Expected Obj, but got Unknown
		//IL_1c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c35: Expected Obj, but got Unknown
		//IL_1c38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c42: Expected Obj, but got Unknown
		//IL_1c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5a: Expected Obj, but got Unknown
		//IL_1c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c72: Expected Obj, but got Unknown
		//IL_1c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7f: Expected Obj, but got Unknown
		//IL_1c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c96: Expected Obj, but got Unknown
		//IL_1c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca3: Expected Obj, but got Unknown
		//IL_1cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cba: Expected Obj, but got Unknown
		//IL_1cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc7: Expected Obj, but got Unknown
		//IL_1cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cde: Expected Obj, but got Unknown
		//IL_1ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ceb: Expected Obj, but got Unknown
		//IL_1cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d02: Expected Obj, but got Unknown
		//IL_1d0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d19: Expected Obj, but got Unknown
		//IL_1d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d26: Expected Obj, but got Unknown
		//IL_1d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3d: Expected Obj, but got Unknown
		//IL_1d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d54: Expected Obj, but got Unknown
		//IL_1d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d61: Expected Obj, but got Unknown
		//IL_1d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d78: Expected Obj, but got Unknown
		//IL_1d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d85: Expected Obj, but got Unknown
		//IL_1d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9c: Expected Obj, but got Unknown
		//IL_1d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da9: Expected Obj, but got Unknown
		//IL_1db6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc0: Expected Obj, but got Unknown
		//IL_1dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcd: Expected Obj, but got Unknown
		//IL_1dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dda: Expected Obj, but got Unknown
		//IL_1ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de7: Expected Obj, but got Unknown
		//IL_1dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df4: Expected Obj, but got Unknown
		//IL_1e01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0b: Expected Obj, but got Unknown
		//IL_1e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e18: Expected Obj, but got Unknown
		//IL_1e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2f: Expected Obj, but got Unknown
		//IL_1e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3c: Expected Obj, but got Unknown
		//IL_1e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e49: Expected Obj, but got Unknown
		//IL_1e4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e56: Expected Obj, but got Unknown
		//IL_1e59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e63: Expected Obj, but got Unknown
		//IL_1e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7a: Expected Obj, but got Unknown
		//IL_1e7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e87: Expected Obj, but got Unknown
		//IL_1e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9e: Expected Obj, but got Unknown
		//IL_1ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eab: Expected Obj, but got Unknown
		//IL_1ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec5: Expected Obj, but got Unknown
		//IL_1ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edc: Expected Obj, but got Unknown
		//IL_1edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee9: Expected Obj, but got Unknown
		//IL_1ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f00: Expected Obj, but got Unknown
		//IL_1f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0d: Expected Obj, but got Unknown
		//IL_1f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f24: Expected Obj, but got Unknown
		//IL_1f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f31: Expected Obj, but got Unknown
		//IL_1f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f48: Expected Obj, but got Unknown
		//IL_1f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f55: Expected Obj, but got Unknown
		//IL_1f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f62: Expected Obj, but got Unknown
		//IL_1f65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6f: Expected Obj, but got Unknown
		//IL_1f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f86: Expected Obj, but got Unknown
		//IL_1f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9d: Expected Obj, but got Unknown
		//IL_1faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb4: Expected Obj, but got Unknown
		//IL_1fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc1: Expected Obj, but got Unknown
		//IL_1fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd8: Expected Obj, but got Unknown
		//IL_1fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe5: Expected Obj, but got Unknown
		//IL_1ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffc: Expected Obj, but got Unknown
		//IL_1fff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2009: Expected Obj, but got Unknown
		//IL_2016: Unknown result type (might be due to invalid IL or missing references)
		//IL_2020: Expected Obj, but got Unknown
		//IL_2023: Unknown result type (might be due to invalid IL or missing references)
		//IL_202d: Expected Obj, but got Unknown
		//IL_2030: Unknown result type (might be due to invalid IL or missing references)
		//IL_203a: Expected Obj, but got Unknown
		//IL_203d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2047: Expected Obj, but got Unknown
		//IL_204a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2054: Expected Obj, but got Unknown
		//IL_2061: Unknown result type (might be due to invalid IL or missing references)
		//IL_206b: Expected Obj, but got Unknown
		//IL_2078: Unknown result type (might be due to invalid IL or missing references)
		//IL_2082: Expected Obj, but got Unknown
		//IL_208f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2099: Expected Obj, but got Unknown
		//IL_209c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a6: Expected Obj, but got Unknown
		//IL_20b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20bd: Expected Obj, but got Unknown
		//IL_20bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d5: Expected Obj, but got Unknown
		//IL_20d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e2: Expected Obj, but got Unknown
		//IL_20ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f9: Expected Obj, but got Unknown
		//IL_20fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2106: Expected Obj, but got Unknown
		//IL_2113: Unknown result type (might be due to invalid IL or missing references)
		//IL_211d: Expected Obj, but got Unknown
		//IL_2120: Unknown result type (might be due to invalid IL or missing references)
		//IL_212a: Expected Obj, but got Unknown
		//IL_212d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2137: Expected Obj, but got Unknown
		//IL_2144: Unknown result type (might be due to invalid IL or missing references)
		//IL_214e: Expected Obj, but got Unknown
		//IL_2151: Unknown result type (might be due to invalid IL or missing references)
		//IL_215b: Expected Obj, but got Unknown
		//IL_2168: Unknown result type (might be due to invalid IL or missing references)
		//IL_2172: Expected Obj, but got Unknown
		//IL_2175: Unknown result type (might be due to invalid IL or missing references)
		//IL_217f: Expected Obj, but got Unknown
		//IL_218c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2196: Expected Obj, but got Unknown
		//IL_21a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ad: Expected Obj, but got Unknown
		//IL_21b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ba: Expected Obj, but got Unknown
		//IL_21c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Expected Obj, but got Unknown
		//IL_21de: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e8: Expected Obj, but got Unknown
		//IL_21eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f5: Expected Obj, but got Unknown
		//IL_2202: Unknown result type (might be due to invalid IL or missing references)
		//IL_220c: Expected Obj, but got Unknown
		//IL_220f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2219: Expected Obj, but got Unknown
		//IL_2226: Unknown result type (might be due to invalid IL or missing references)
		//IL_2230: Expected Obj, but got Unknown
		//IL_2233: Unknown result type (might be due to invalid IL or missing references)
		//IL_223d: Expected Obj, but got Unknown
		//IL_224a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2254: Expected Obj, but got Unknown
		//IL_2264: Unknown result type (might be due to invalid IL or missing references)
		//IL_226e: Expected Obj, but got Unknown
		//IL_2292: Unknown result type (might be due to invalid IL or missing references)
		//IL_229c: Expected Obj, but got Unknown
		//IL_22a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b3: Expected Obj, but got Unknown
		//IL_22c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ca: Expected Obj, but got Unknown
		//IL_22cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d7: Expected Obj, but got Unknown
		//IL_22e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ee: Expected Obj, but got Unknown
		//IL_22f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fb: Expected Obj, but got Unknown
		//IL_2308: Unknown result type (might be due to invalid IL or missing references)
		//IL_2312: Expected Obj, but got Unknown
		//IL_2315: Unknown result type (might be due to invalid IL or missing references)
		//IL_231f: Expected Obj, but got Unknown
		//IL_232c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2336: Expected Obj, but got Unknown
		//IL_2339: Unknown result type (might be due to invalid IL or missing references)
		//IL_2343: Expected Obj, but got Unknown
		//IL_2350: Unknown result type (might be due to invalid IL or missing references)
		//IL_235a: Expected Obj, but got Unknown
		//IL_235c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2368: Unknown result type (might be due to invalid IL or missing references)
		//IL_2372: Expected Obj, but got Unknown
		//IL_2375: Unknown result type (might be due to invalid IL or missing references)
		//IL_237f: Expected Obj, but got Unknown
		//IL_2382: Unknown result type (might be due to invalid IL or missing references)
		//IL_238c: Expected Obj, but got Unknown
		//IL_238f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2399: Expected Obj, but got Unknown
		//IL_23a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b0: Expected Obj, but got Unknown
		//IL_23b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23bd: Expected Obj, but got Unknown
		//IL_23ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d4: Expected Obj, but got Unknown
		//IL_23d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e1: Expected Obj, but got Unknown
		//IL_23ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f8: Expected Obj, but got Unknown
		//IL_23fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2405: Expected Obj, but got Unknown
		//IL_2412: Unknown result type (might be due to invalid IL or missing references)
		//IL_241c: Expected Obj, but got Unknown
		//IL_241f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2429: Expected Obj, but got Unknown
		//IL_2436: Unknown result type (might be due to invalid IL or missing references)
		//IL_2440: Expected Obj, but got Unknown
		//IL_2443: Unknown result type (might be due to invalid IL or missing references)
		//IL_244d: Expected Obj, but got Unknown
		//IL_245a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2464: Expected Obj, but got Unknown
		//IL_2467: Unknown result type (might be due to invalid IL or missing references)
		//IL_2471: Expected Obj, but got Unknown
		//IL_2474: Unknown result type (might be due to invalid IL or missing references)
		//IL_247e: Expected Obj, but got Unknown
		//IL_248b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2495: Expected Obj, but got Unknown
		//IL_24a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ac: Expected Obj, but got Unknown
		//IL_24b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c3: Expected Obj, but got Unknown
		//IL_24c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d0: Expected Obj, but got Unknown
		//IL_24d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24dd: Expected Obj, but got Unknown
		//IL_24ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f4: Expected Obj, but got Unknown
		//IL_2501: Unknown result type (might be due to invalid IL or missing references)
		//IL_250b: Expected Obj, but got Unknown
		//IL_2518: Unknown result type (might be due to invalid IL or missing references)
		//IL_2522: Expected Obj, but got Unknown
		//IL_253c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2546: Expected Obj, but got Unknown
		//IL_2549: Unknown result type (might be due to invalid IL or missing references)
		//IL_2553: Expected Obj, but got Unknown
		//IL_2556: Unknown result type (might be due to invalid IL or missing references)
		//IL_2560: Expected Obj, but got Unknown
		//IL_256d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2577: Expected Obj, but got Unknown
		//IL_257a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2584: Expected Obj, but got Unknown
		//IL_2591: Unknown result type (might be due to invalid IL or missing references)
		//IL_259b: Expected Obj, but got Unknown
		//IL_259e: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a8: Expected Obj, but got Unknown
		//IL_25b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25bf: Expected Obj, but got Unknown
		//IL_25c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25cc: Expected Obj, but got Unknown
		//IL_25d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e3: Expected Obj, but got Unknown
		//IL_25e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f0: Expected Obj, but got Unknown
		//IL_25f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_25fd: Expected Obj, but got Unknown
		//IL_260a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2614: Expected Obj, but got Unknown
		//IL_2617: Unknown result type (might be due to invalid IL or missing references)
		//IL_2621: Expected Obj, but got Unknown
		//IL_262e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2638: Expected Obj, but got Unknown
		//IL_263b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2645: Expected Obj, but got Unknown
		//IL_2652: Unknown result type (might be due to invalid IL or missing references)
		//IL_265c: Expected Obj, but got Unknown
		//IL_265f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2669: Expected Obj, but got Unknown
		//IL_2676: Unknown result type (might be due to invalid IL or missing references)
		//IL_2680: Expected Obj, but got Unknown
		//IL_2683: Unknown result type (might be due to invalid IL or missing references)
		//IL_268d: Expected Obj, but got Unknown
		//IL_2690: Unknown result type (might be due to invalid IL or missing references)
		//IL_269a: Expected Obj, but got Unknown
		//IL_26ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_26f6: Expected Obj, but got Unknown
		//IL_26f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2703: Expected Obj, but got Unknown
		//IL_2710: Unknown result type (might be due to invalid IL or missing references)
		//IL_271a: Expected Obj, but got Unknown
		//IL_271d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2727: Expected Obj, but got Unknown
		//IL_2734: Unknown result type (might be due to invalid IL or missing references)
		//IL_273e: Expected Obj, but got Unknown
		//IL_2741: Unknown result type (might be due to invalid IL or missing references)
		//IL_274b: Expected Obj, but got Unknown
		//IL_2758: Unknown result type (might be due to invalid IL or missing references)
		//IL_2762: Expected Obj, but got Unknown
		//IL_2765: Unknown result type (might be due to invalid IL or missing references)
		//IL_276f: Expected Obj, but got Unknown
		//IL_277c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2786: Expected Obj, but got Unknown
		//IL_2789: Unknown result type (might be due to invalid IL or missing references)
		//IL_2793: Expected Obj, but got Unknown
		//IL_27a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_27aa: Expected Obj, but got Unknown
		//IL_27b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c1: Expected Obj, but got Unknown
		//IL_27c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ce: Expected Obj, but got Unknown
		//IL_27db: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e5: Expected Obj, but got Unknown
		//IL_27f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fc: Expected Obj, but got Unknown
		//IL_27ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2809: Expected Obj, but got Unknown
		//IL_2816: Unknown result type (might be due to invalid IL or missing references)
		//IL_2820: Expected Obj, but got Unknown
		//IL_2823: Unknown result type (might be due to invalid IL or missing references)
		//IL_282d: Expected Obj, but got Unknown
		//IL_283a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2844: Expected Obj, but got Unknown
		//IL_2847: Unknown result type (might be due to invalid IL or missing references)
		//IL_2851: Expected Obj, but got Unknown
		//IL_285e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2868: Expected Obj, but got Unknown
		//IL_286b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2875: Expected Obj, but got Unknown
		//IL_2882: Unknown result type (might be due to invalid IL or missing references)
		//IL_288c: Expected Obj, but got Unknown
		//IL_288f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2899: Expected Obj, but got Unknown
		//IL_28a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b0: Expected Obj, but got Unknown
		//IL_28b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28bd: Expected Obj, but got Unknown
		//IL_28ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d4: Expected Obj, but got Unknown
		//IL_28d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e1: Expected Obj, but got Unknown
		//IL_28ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f8: Expected Obj, but got Unknown
		//IL_28fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2905: Expected Obj, but got Unknown
		//IL_2908: Unknown result type (might be due to invalid IL or missing references)
		//IL_2912: Expected Obj, but got Unknown
		//IL_2915: Unknown result type (might be due to invalid IL or missing references)
		//IL_291f: Expected Obj, but got Unknown
		//IL_2922: Unknown result type (might be due to invalid IL or missing references)
		//IL_292c: Expected Obj, but got Unknown
		//IL_292f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2939: Expected Obj, but got Unknown
		//IL_293c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2946: Expected Obj, but got Unknown
		//IL_2953: Unknown result type (might be due to invalid IL or missing references)
		//IL_295d: Expected Obj, but got Unknown
		//IL_2960: Unknown result type (might be due to invalid IL or missing references)
		//IL_296a: Expected Obj, but got Unknown
		//IL_2977: Unknown result type (might be due to invalid IL or missing references)
		//IL_2981: Expected Obj, but got Unknown
		//IL_2984: Unknown result type (might be due to invalid IL or missing references)
		//IL_298e: Expected Obj, but got Unknown
		//IL_2991: Unknown result type (might be due to invalid IL or missing references)
		//IL_299b: Expected Obj, but got Unknown
		//IL_29a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_29b2: Expected Obj, but got Unknown
		//IL_29b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29bf: Expected Obj, but got Unknown
		//IL_29cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d6: Expected Obj, but got Unknown
		//IL_29d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e3: Expected Obj, but got Unknown
		//IL_29e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f0: Expected Obj, but got Unknown
		//IL_29fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a07: Expected Obj, but got Unknown
		//IL_2a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a14: Expected Obj, but got Unknown
		//IL_2a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2b: Expected Obj, but got Unknown
		//IL_2a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a38: Expected Obj, but got Unknown
		//IL_2a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a4f: Expected Obj, but got Unknown
		//IL_2a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a5c: Expected Obj, but got Unknown
		//IL_2a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a73: Expected Obj, but got Unknown
		//IL_2a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a80: Expected Obj, but got Unknown
		//IL_2a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a97: Expected Obj, but got Unknown
		//IL_2aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aae: Expected Obj, but got Unknown
		//IL_2ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2abb: Expected Obj, but got Unknown
		//IL_2ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad2: Expected Obj, but got Unknown
		//IL_2adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae9: Expected Obj, but got Unknown
		//IL_2aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af6: Expected Obj, but got Unknown
		//IL_2b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b0d: Expected Obj, but got Unknown
		//IL_2b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b1a: Expected Obj, but got Unknown
		//IL_2b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b31: Expected Obj, but got Unknown
		//IL_2b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b3e: Expected Obj, but got Unknown
		//IL_2b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b55: Expected Obj, but got Unknown
		//IL_2b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b6f: Expected Obj, but got Unknown
		//IL_2b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b86: Expected Obj, but got Unknown
		//IL_2b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b93: Expected Obj, but got Unknown
		//IL_2b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba0: Expected Obj, but got Unknown
		//IL_2ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bad: Expected Obj, but got Unknown
		//IL_2bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc4: Expected Obj, but got Unknown
		//IL_2bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd1: Expected Obj, but got Unknown
		//IL_2bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be8: Expected Obj, but got Unknown
		//IL_2bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bff: Expected Obj, but got Unknown
		//IL_2c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c0c: Expected Obj, but got Unknown
		//IL_2c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c23: Expected Obj, but got Unknown
		//IL_2c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c30: Expected Obj, but got Unknown
		//IL_2c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c47: Expected Obj, but got Unknown
		//IL_2c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c54: Expected Obj, but got Unknown
		//IL_2c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c6b: Expected Obj, but got Unknown
		//IL_2c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c82: Expected Obj, but got Unknown
		//IL_2ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb0: Expected Obj, but got Unknown
		//IL_2cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cbd: Expected Obj, but got Unknown
		//IL_2cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd4: Expected Obj, but got Unknown
		//IL_2cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ce1: Expected Obj, but got Unknown
		//IL_2cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf8: Expected Obj, but got Unknown
		//IL_2cfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d05: Expected Obj, but got Unknown
		//IL_2d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d1c: Expected Obj, but got Unknown
		//IL_2d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d29: Expected Obj, but got Unknown
		//IL_2d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d40: Expected Obj, but got Unknown
		//IL_2d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d4d: Expected Obj, but got Unknown
		//IL_2d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d64: Expected Obj, but got Unknown
		//IL_2d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d71: Expected Obj, but got Unknown
		//IL_2d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d7e: Expected Obj, but got Unknown
		//IL_2da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dac: Expected Obj, but got Unknown
		//IL_2db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc3: Expected Obj, but got Unknown
		//IL_2dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dda: Expected Obj, but got Unknown
		//IL_2de7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2df1: Expected Obj, but got Unknown
		//IL_2df4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dfe: Expected Obj, but got Unknown
		//IL_2e0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e15: Expected Obj, but got Unknown
		//IL_2e18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e22: Expected Obj, but got Unknown
		//IL_2e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e39: Expected Obj, but got Unknown
		//IL_2e3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e46: Expected Obj, but got Unknown
		//IL_2e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e5d: Expected Obj, but got Unknown
		//IL_2e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e6a: Expected Obj, but got Unknown
		//IL_2e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e81: Expected Obj, but got Unknown
		//IL_2e84: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e8e: Expected Obj, but got Unknown
		//IL_2e9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea5: Expected Obj, but got Unknown
		//IL_2ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb2: Expected Obj, but got Unknown
		//IL_2ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ec9: Expected Obj, but got Unknown
		//IL_2ecc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed6: Expected Obj, but got Unknown
		//IL_2ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eed: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((Window)(RagsDesigner)target).Closing += a;
			((Window)(RagsDesigner)target).Closed += e;
			((FrameworkElement)(RagsDesigner)target).Loaded += t;
			break;
		case 2:
			this.i = (Grid)target;
			break;
		case 3:
			((MenuItem)target).Click += u;
			break;
		case 4:
			((MenuItem)target).Click += d0;
			break;
		case 5:
			this.j = (MenuItem)target;
			this.j.Click += ar;
			break;
		case 6:
			this.k = (MenuItem)target;
			this.k.Click += aq;
			break;
		case 7:
			this.l = (MenuItem)target;
			this.l.Click += g;
			break;
		case 8:
			this.m = (MenuItem)target;
			this.m.Click += i;
			break;
		case 9:
			this.n = (MenuItem)target;
			this.n.Click += h;
			break;
		case 10:
			((MenuItem)target).Click += d1;
			break;
		case 11:
			((MenuItem)target).Click += k;
			break;
		case 12:
			((MenuItem)target).Click += w;
			break;
		case 13:
			((MenuItem)target).Click += s;
			break;
		case 14:
			this.o = (MenuItem)target;
			this.o.Click += f;
			break;
		case 15:
			this.p = (MenuItem)target;
			this.p.Click += a;
			break;
		case 16:
			this.q = (MenuItem)target;
			this.q.Click += d;
			break;
		case 17:
			this.r = (MenuItem)target;
			this.r.Click += e;
			break;
		case 18:
			this.s = (MenuItem)target;
			this.s.Click += dq;
			break;
		case 19:
			this.t = (MenuItem)target;
			this.t.Click += dr;
			break;
		case 20:
			this.u = (TabControl)target;
			((Selector)this.u).SelectionChanged += @as;
			break;
		case 21:
			this.v = (TabItem)target;
			break;
		case 22:
			this.w = (Grid)target;
			break;
		case 23:
			this.x = (TabItem)target;
			break;
		case 24:
			this.y = (TextBox)target;
			((UIElement)this.y).KeyDown += b;
			((Control)this.y).MouseDoubleClick += d;
			((UIElement)this.y).LostFocus += dp;
			break;
		case 25:
			this.z = (CheckBox)target;
			((ButtonBase)this.z).Click += dj;
			break;
		case 26:
			this.aa = (PasswordBox)target;
			((UIElement)this.aa).LostFocus += @do;
			break;
		case 27:
			this.ab = (CheckBox)target;
			((ButtonBase)this.ab).Click += di;
			break;
		case 28:
			this.ac = (ComboBox)target;
			((Selector)this.ac).SelectionChanged += aj;
			break;
		case 29:
			this.ad = (CheckBox)target;
			((ButtonBase)this.ad).Click += dh;
			break;
		case 30:
			this.ae = (TextBox)target;
			((UIElement)this.ae).KeyDown += b;
			((Control)this.ae).MouseDoubleClick += d;
			((UIElement)this.ae).LostFocus += dn;
			break;
		case 31:
			this.af = (CheckBox)target;
			((ButtonBase)this.af).Click += dg;
			break;
		case 32:
			this.ag = (CheckBox)target;
			((ButtonBase)this.ag).Click += df;
			break;
		case 33:
			this.ah = (CheckBox)target;
			((ButtonBase)this.ah).Click += de;
			break;
		case 34:
			this.ai = (ComboBox)target;
			((Selector)this.ai).SelectionChanged += ai;
			break;
		case 35:
			this.aj = (ComboBox)target;
			((Selector)this.aj).SelectionChanged += ah;
			break;
		case 36:
			this.ak = (ComboBox)target;
			((Selector)this.ak).SelectionChanged += ag;
			break;
		case 37:
			this.al = (TextBox)target;
			((Control)this.al).MouseDoubleClick += d;
			((UIElement)this.al).LostFocus += dc;
			break;
		case 38:
			((UIElement)(Button)target).KeyDown += b;
			((ButtonBase)(Button)target).Click += dd;
			break;
		case 39:
			this.am = (ListBox)target;
			((Selector)this.am).SelectionChanged += af;
			break;
		case 40:
			this.an = (TextBox)target;
			((UIElement)this.an).LostFocus += db;
			break;
		case 41:
			this.ao = (Button)target;
			((ButtonBase)this.ao).Click += c9;
			break;
		case 42:
			this.ap = (CheckBox)target;
			((ButtonBase)this.ap).Click += da;
			break;
		case 43:
			((ButtonBase)(Button)target).Click += c8;
			break;
		case 44:
			((ButtonBase)(Button)target).Click += c7;
			break;
		case 45:
			this.aq = (TabItem)target;
			break;
		case 46:
			this.ar = (TextBox)target;
			((UIElement)this.ar).KeyDown += b;
			((Control)this.ar).MouseDoubleClick += d;
			((UIElement)this.ar).LostFocus += dm;
			break;
		case 47:
			this.@as = (TextBox)target;
			((UIElement)this.@as).KeyDown += b;
			((Control)this.@as).MouseDoubleClick += d;
			((UIElement)this.@as).LostFocus += dl;
			break;
		case 48:
			this.at = (TextBox)target;
			((UIElement)this.at).KeyDown += b;
			((Control)this.at).MouseDoubleClick += d;
			((UIElement)this.at).LostFocus += dk;
			break;
		case 49:
			this.au = (TabItem)target;
			break;
		case 50:
			this.av = (ListView)target;
			((Selector)this.av).SelectionChanged += ar;
			break;
		case 51:
			this.aw = (MenuItem)target;
			this.aw.Click += c4;
			break;
		case 52:
			this.ax = (MenuItem)target;
			this.ax.Click += ac;
			break;
		case 53:
			this.ay = (MenuItem)target;
			this.ay.Click += ab;
			break;
		case 54:
			this.az = (MenuItem)target;
			this.az.Click += aa;
			break;
		case 55:
			((ButtonBase)(Button)target).Click += c4;
			break;
		case 56:
			this.a0 = (TabControl)target;
			break;
		case 57:
			this.a1 = (Grid)target;
			break;
		case 58:
			this.a2 = (TextBox)target;
			((UIElement)this.a2).KeyDown += b;
			break;
		case 59:
			this.a3 = (TextBox)target;
			break;
		case 60:
			this.a4 = (TextBox)target;
			((UIElement)this.a4).KeyDown += b;
			((UIElement)this.a4).LostFocus += c6;
			((Control)this.a4).MouseDoubleClick += d;
			break;
		case 61:
			this.a5 = (ComboBox)target;
			((Selector)this.a5).SelectionChanged += ae;
			break;
		case 62:
			this.a6 = (TextBox)target;
			((UIElement)this.a6).KeyDown += b;
			((UIElement)this.a6).LostFocus += c5;
			((Control)this.a6).MouseDoubleClick += d;
			break;
		case 63:
			this.a7 = (ComboBox)target;
			((Selector)this.a7).SelectionChanged += ad;
			break;
		case 64:
			this.a8 = (MediaElement)target;
			break;
		case 65:
			this.a9 = (Label)target;
			break;
		case 66:
			this.ba = (Grid)target;
			break;
		case 67:
			this.bb = (CheckBox)target;
			((ButtonBase)this.bb).Click += c3;
			break;
		case 68:
			this.bc = (CheckBox)target;
			((ButtonBase)this.bc).Click += c2;
			break;
		case 69:
			this.bd = (CheckBox)target;
			((ButtonBase)this.bd).Click += c1;
			break;
		case 70:
			this.be = (CheckBox)target;
			((ButtonBase)this.be).Click += c0;
			break;
		case 71:
			this.bf = (CheckBox)target;
			((ButtonBase)this.bf).Click += cz;
			break;
		case 72:
			this.bg = (CheckBox)target;
			((ButtonBase)this.bg).Click += cy;
			break;
		case 73:
			this.bh = (CheckBox)target;
			((ButtonBase)this.bh).Click += cx;
			break;
		case 74:
			this.bi = (CheckBox)target;
			((ButtonBase)this.bi).Click += cw;
			break;
		case 75:
			this.bj = (CheckBox)target;
			((ButtonBase)this.bj).Click += cv;
			break;
		case 76:
			this.bk = (CheckBox)target;
			((ButtonBase)this.bk).Click += cu;
			break;
		case 77:
			this.bl = (CheckBox)target;
			((ButtonBase)this.bl).Click += ct;
			break;
		case 78:
			this.bm = (CheckBox)target;
			((ButtonBase)this.bm).Click += cs;
			break;
		case 79:
			this.bn = (ComboBox)target;
			((Selector)this.bn).SelectionChanged += ac;
			break;
		case 80:
			this.bo = (ComboBox)target;
			((Selector)this.bo).SelectionChanged += q;
			break;
		case 81:
			this.bp = (ComboBox)target;
			((Selector)this.bp).SelectionChanged += ab;
			break;
		case 82:
			this.bq = (ComboBox)target;
			((Selector)this.bq).SelectionChanged += p;
			break;
		case 83:
			this.br = (ComboBox)target;
			((Selector)this.br).SelectionChanged += aa;
			break;
		case 84:
			this.bs = (ComboBox)target;
			((Selector)this.bs).SelectionChanged += o;
			break;
		case 85:
			this.bt = (ComboBox)target;
			((Selector)this.bt).SelectionChanged += z;
			break;
		case 86:
			this.bu = (ComboBox)target;
			((Selector)this.bu).SelectionChanged += n;
			break;
		case 87:
			this.bv = (ComboBox)target;
			((Selector)this.bv).SelectionChanged += y;
			break;
		case 88:
			this.bw = (ComboBox)target;
			((Selector)this.bw).SelectionChanged += m;
			break;
		case 89:
			this.bx = (ComboBox)target;
			((Selector)this.bx).SelectionChanged += x;
			break;
		case 90:
			this.by = (ComboBox)target;
			((Selector)this.by).SelectionChanged += l;
			break;
		case 91:
			this.bz = (ComboBox)target;
			((Selector)this.bz).SelectionChanged += w;
			break;
		case 92:
			this.b0 = (ComboBox)target;
			((Selector)this.b0).SelectionChanged += i;
			break;
		case 93:
			this.b1 = (ComboBox)target;
			((Selector)this.b1).SelectionChanged += v;
			break;
		case 94:
			this.b2 = (ComboBox)target;
			((Selector)this.b2).SelectionChanged += h;
			break;
		case 95:
			this.b3 = (ComboBox)target;
			((Selector)this.b3).SelectionChanged += u;
			break;
		case 96:
			this.b4 = (ComboBox)target;
			((Selector)this.b4).SelectionChanged += g;
			break;
		case 97:
			this.b5 = (ComboBox)target;
			((Selector)this.b5).SelectionChanged += t;
			break;
		case 98:
			this.b6 = (ComboBox)target;
			((Selector)this.b6).SelectionChanged += f;
			break;
		case 99:
			this.b7 = (ComboBox)target;
			((Selector)this.b7).SelectionChanged += s;
			break;
		case 100:
			this.b8 = (ComboBox)target;
			((Selector)this.b8).SelectionChanged += k;
			break;
		case 101:
			this.b9 = (ComboBox)target;
			((Selector)this.b9).SelectionChanged += r;
			break;
		case 102:
			this.ca = (ComboBox)target;
			((Selector)this.ca).SelectionChanged += j;
			break;
		case 103:
			this.cb = (Grid)target;
			break;
		case 104:
			this.cc = (Label)target;
			break;
		case 105:
			this.cd = (ListBox)target;
			((UIElement)this.cd).DragOver += g;
			((UIElement)this.cd).Drop += f;
			break;
		case 106:
			this.ce = (MenuItem)target;
			this.ce.Click += cq;
			break;
		case 107:
			this.cf = (MenuItem)target;
			this.cf.Click += cp;
			break;
		case 108:
			((ButtonBase)(Button)target).Click += cr;
			break;
		case 109:
			this.cg = (ListView)target;
			((Selector)this.cg).SelectionChanged += aq;
			break;
		case 110:
			this.ch = (TextBox)target;
			((UIElement)this.ch).KeyDown += b;
			((Control)this.ch).MouseDoubleClick += d;
			break;
		case 111:
			this.ci = (TextBox)target;
			((UIElement)this.ci).KeyDown += b;
			((Control)this.ci).MouseDoubleClick += d;
			break;
		case 112:
			((ButtonBase)(Button)target).Click += co;
			break;
		case 113:
			((ButtonBase)(Button)target).Click += cn;
			break;
		case 114:
			((ButtonBase)(Button)target).Click += cm;
			break;
		case 115:
			this.cj = (WPFActionControl)target;
			break;
		case 116:
			this.ck = (TabControl)target;
			break;
		case 117:
			this.cl = (CheckBox)target;
			((ButtonBase)this.cl).Click += o;
			break;
		case 118:
			this.cm = (TextBox)target;
			((UIElement)this.cm).KeyDown += b;
			((Control)this.cm).MouseDoubleClick += d;
			((UIElement)this.cm).LostFocus += q;
			break;
		case 119:
			this.cn = (CheckBox)target;
			((ButtonBase)this.cn).Click += p;
			break;
		case 120:
			this.co = (RadioButton)target;
			((UIElement)this.co).LostFocus += n;
			break;
		case 121:
			this.cp = (RadioButton)target;
			((UIElement)this.cp).LostFocus += n;
			break;
		case 122:
			this.cq = (RadioButton)target;
			((UIElement)this.cq).LostFocus += n;
			break;
		case 123:
			this.cr = (CheckBox)target;
			((ButtonBase)this.cr).Click += m;
			break;
		case 124:
			this.cs = (TextBox)target;
			((Control)this.cs).MouseDoubleClick += d;
			((UIElement)this.cs).LostFocus += l;
			break;
		case 125:
			this.ct = (ComboBox)target;
			((UIElement)this.ct).LostFocus += v;
			break;
		case 126:
			this.cu = (ListBox)target;
			((UIElement)this.cu).Drop += e;
			break;
		case 127:
			this.cv = (Button)target;
			((ButtonBase)this.cv).Click += cl;
			break;
		case 128:
			((ButtonBase)(Button)target).Click += ck;
			break;
		case 129:
			this.cw = (TextBox)target;
			((Control)this.cw).MouseDoubleClick += d;
			((UIElement)this.cw).KeyDown += b;
			((UIElement)this.cw).LostFocus += r;
			break;
		case 130:
			this.cx = (ComboBox)target;
			((Selector)this.cx).SelectionChanged += a;
			break;
		case 131:
			this.cy = (MediaElement)target;
			break;
		case 132:
			this.cz = (ListView)target;
			((Selector)this.cz).SelectionChanged += e;
			break;
		case 133:
			this.c0 = (TextBox)target;
			((UIElement)this.c0).KeyDown += b;
			((Control)this.c0).MouseDoubleClick += d;
			break;
		case 134:
			this.c1 = (TextBox)target;
			((UIElement)this.c1).KeyDown += b;
			((Control)this.c1).MouseDoubleClick += d;
			break;
		case 135:
			((ButtonBase)(Button)target).Click += cj;
			break;
		case 136:
			((ButtonBase)(Button)target).Click += ci;
			break;
		case 137:
			((ButtonBase)(Button)target).Click += ch;
			break;
		case 138:
			this.c2 = (WPFActionControl)target;
			break;
		case 139:
			this.c3 = (TabControl)target;
			break;
		case 140:
			((UIElement)(TabItem)target).GotFocus += j;
			break;
		case 141:
			((ButtonBase)(Button)target).Click += cg;
			break;
		case 142:
			this.c4 = (TextBox)target;
			break;
		case 143:
			this.c5 = (TextBox)target;
			((UIElement)this.c5).KeyDown += b;
			break;
		case 144:
			this.c6 = (TextBox)target;
			((UIElement)this.c6).KeyDown += b;
			((Control)this.c6).MouseDoubleClick += d;
			((UIElement)this.c6).LostFocus += cf;
			break;
		case 145:
			this.c7 = (TextBox)target;
			((UIElement)this.c7).KeyDown += b;
			((Control)this.c7).MouseDoubleClick += d;
			((UIElement)this.c7).LostFocus += ce;
			break;
		case 146:
			this.c8 = (TextBox)target;
			((UIElement)this.c8).KeyDown += b;
			((Control)this.c8).MouseDoubleClick += d;
			((UIElement)this.c8).LostFocus += cd;
			break;
		case 147:
			this.c9 = (CheckBox)target;
			((ButtonBase)this.c9).Click += cc;
			break;
		case 148:
			this.da = (CheckBox)target;
			((ButtonBase)this.da).Click += cb;
			break;
		case 149:
			this.db = (CheckBox)target;
			((ButtonBase)this.db).Click += ca;
			break;
		case 150:
			this.dc = (CheckBox)target;
			((ButtonBase)this.dc).Click += b9;
			((ToggleButton)this.dc).Checked += bx;
			((ToggleButton)this.dc).Unchecked += bw;
			break;
		case 151:
			this.dd = (CheckBox)target;
			((ButtonBase)this.dd).Click += b8;
			break;
		case 152:
			this.de = (RadioButton)target;
			((UIElement)this.de).LostFocus += b3;
			break;
		case 153:
			this.df = (RadioButton)target;
			((UIElement)this.df).LostFocus += b3;
			break;
		case 154:
			this.dg = (RadioButton)target;
			((UIElement)this.dg).LostFocus += b2;
			break;
		case 155:
			this.dh = (RadioButton)target;
			((UIElement)this.dh).LostFocus += b2;
			break;
		case 156:
			this.di = (RadioButton)target;
			((UIElement)this.di).LostFocus += b1;
			break;
		case 157:
			this.dj = (RadioButton)target;
			((UIElement)this.dj).LostFocus += b1;
			break;
		case 158:
			this.dk = (RadioButton)target;
			((UIElement)this.dk).LostFocus += b0;
			break;
		case 159:
			this.dl = (RadioButton)target;
			((UIElement)this.dl).LostFocus += b0;
			break;
		case 160:
			this.dm = (CheckBox)target;
			((ButtonBase)this.dm).Click += b7;
			break;
		case 161:
			this.dn = (CheckBox)target;
			((ButtonBase)this.dn).Click += b6;
			break;
		case 162:
			this.@do = (CheckBox)target;
			((ButtonBase)this.@do).Click += b5;
			break;
		case 163:
			this.dp = (TextBox)target;
			((Control)this.dp).MouseDoubleClick += d;
			((UIElement)this.dp).LostFocus += b4;
			break;
		case 164:
			this.dq = (ListBox)target;
			break;
		case 165:
			((MenuItem)target).Click += bz;
			break;
		case 166:
			((MenuItem)target).Click += by;
			break;
		case 167:
			this.dr = (Button)target;
			((ButtonBase)this.dr).Click += bz;
			break;
		case 168:
			this.ds = (Button)target;
			((ButtonBase)this.ds).Click += by;
			break;
		case 169:
			this.dt = (ListView)target;
			((Selector)this.dt).SelectionChanged += d;
			break;
		case 170:
			this.du = (TextBox)target;
			((UIElement)this.du).KeyDown += b;
			((Control)this.du).MouseDoubleClick += d;
			break;
		case 171:
			this.dv = (TextBox)target;
			((UIElement)this.dv).KeyDown += b;
			((Control)this.dv).MouseDoubleClick += d;
			break;
		case 172:
			this.dw = (Button)target;
			((ButtonBase)this.dw).Click += bv;
			break;
		case 173:
			this.dx = (Button)target;
			((ButtonBase)this.dx).Click += bu;
			break;
		case 174:
			this.dy = (Button)target;
			((ButtonBase)this.dy).Click += bt;
			break;
		case 175:
			this.dz = (Grid)target;
			break;
		case 176:
			this.d0 = (Label)target;
			break;
		case 177:
			this.d1 = (ListBox)target;
			break;
		case 178:
			d2 = (Button)target;
			((ButtonBase)d2).Click += bq;
			break;
		case 179:
			d3 = (Button)target;
			((ButtonBase)d3).Click += bp;
			break;
		case 180:
			d4 = (ListBox)target;
			break;
		case 181:
			d5 = (ComboBox)target;
			break;
		case 182:
			d6 = (ComboBox)target;
			break;
		case 183:
			d7 = (Button)target;
			((ButtonBase)d7).Click += br;
			break;
		case 184:
			d8 = (Button)target;
			((ButtonBase)d8).Click += bs;
			break;
		case 185:
			d9 = (TextBox)target;
			break;
		case 186:
			ea = (WPFActionControl)target;
			break;
		case 187:
			eb = (ListView)target;
			((Selector)eb).SelectionChanged += am;
			break;
		case 188:
			ec = (MenuItem)target;
			ec.Click += z;
			break;
		case 189:
			ed = (MenuItem)target;
			ed.Click += y;
			break;
		case 190:
			ee = (Button)target;
			((ButtonBase)ee).Click += z;
			break;
		case 191:
			ef = (TabControl)target;
			break;
		case 192:
			eg = (Label)target;
			break;
		case 193:
			eh = (TextBox)target;
			((UIElement)eh).KeyDown += b;
			((Control)eh).MouseDoubleClick += d;
			((UIElement)eh).LostFocus += bo;
			break;
		case 194:
			ei = (ComboBox)target;
			((Selector)ei).SelectionChanged += c;
			break;
		case 195:
			ej = (CheckBox)target;
			((ButtonBase)ej).Click += bn;
			break;
		case 196:
			ek = (GroupBox)target;
			((UIElement)ek).LostFocus += bl;
			break;
		case 197:
			el = (RadioButton)target;
			break;
		case 198:
			em = (RadioButton)target;
			break;
		case 199:
			en = (RadioButton)target;
			break;
		case 200:
			eo = (TextBox)target;
			((UIElement)eo).KeyDown += b;
			((Control)eo).MouseDoubleClick += d;
			((UIElement)eo).LostFocus += bm;
			break;
		case 201:
			ep = (ListBox)target;
			((UIElement)ep).Drop += d;
			break;
		case 202:
			((MenuItem)target).Click += bk;
			break;
		case 203:
			eq = (MenuItem)target;
			eq.Click += bj;
			break;
		case 204:
			er = (ComboBox)target;
			((Selector)er).SelectionChanged += b;
			break;
		case 205:
			es = (MediaElement)target;
			break;
		case 206:
			et = (Button)target;
			((ButtonBase)et).Click += bk;
			break;
		case 207:
			eu = (ListView)target;
			((Selector)eu).SelectionChanged += ap;
			break;
		case 208:
			ev = (TextBox)target;
			((UIElement)ev).KeyDown += b;
			((Control)ev).MouseDoubleClick += d;
			break;
		case 209:
			ew = (TextBox)target;
			((UIElement)ew).KeyDown += b;
			((Control)ew).MouseDoubleClick += d;
			break;
		case 210:
			ex = (Button)target;
			((ButtonBase)ex).Click += bi;
			break;
		case 211:
			ey = (Button)target;
			((ButtonBase)ey).Click += bh;
			break;
		case 212:
			ez = (Button)target;
			((ButtonBase)ez).Click += bg;
			break;
		case 213:
			e0 = (WPFActionControl)target;
			break;
		case 214:
			e1 = (TreeView)target;
			e1.SelectedItemChanged += b;
			((UIElement)e1).MouseMove += a;
			((UIElement)e1).Drop += a;
			((UIElement)e1).MouseLeftButtonDown += a;
			break;
		case 215:
			e2 = (MenuItem)target;
			e2.Click += a7;
			break;
		case 216:
			e3 = (MenuItem)target;
			e3.Click += am;
			break;
		case 217:
			e4 = (MenuItem)target;
			e4.Click += al;
			break;
		case 218:
			e5 = (MenuItem)target;
			e5.Click += ak;
			break;
		case 219:
			((ButtonBase)(Button)target).Click += a7;
			break;
		case 220:
			e6 = (Label)target;
			break;
		case 221:
			e7 = (GroupBox)target;
			break;
		case 222:
			e8 = (RadioButton)target;
			((ButtonBase)e8).Click += bf;
			break;
		case 223:
			e9 = (RadioButton)target;
			((ButtonBase)e9).Click += bf;
			break;
		case 224:
			fa = (RadioButton)target;
			((ButtonBase)fa).Click += bf;
			break;
		case 225:
			fb = (RadioButton)target;
			((ButtonBase)fb).Click += bf;
			break;
		case 226:
			fc = (RadioButton)target;
			((ButtonBase)fc).Click += bf;
			break;
		case 227:
			fd = (RadioButton)target;
			((ButtonBase)fd).Click += bf;
			break;
		case 228:
			fe = (GroupBox)target;
			break;
		case 229:
			ff = (TextBox)target;
			((UIElement)ff).KeyDown += b;
			((Control)ff).MouseDoubleClick += d;
			((UIElement)ff).LostFocus += be;
			break;
		case 230:
			fg = (GroupBox)target;
			break;
		case 231:
			fh = (TextBox)target;
			((UIElement)fh).KeyDown += b;
			((Control)fh).MouseDoubleClick += d;
			((UIElement)fh).LostFocus += bd;
			break;
		case 232:
			fi = (DateTimePicker)target;
			((UIElement)fi).LostFocus += bb;
			break;
		case 233:
			fj = (Grid)target;
			break;
		case 234:
			fk = (TextBox)target;
			((UIElement)fk).LostFocus += bc;
			break;
		case 235:
			fl = (CheckBox)target;
			((ToggleButton)fl).Checked += dy;
			break;
		case 236:
			fm = (TextBox)target;
			((UIElement)fm).LostFocus += b;
			break;
		case 237:
			fn = (TextBox)target;
			((UIElement)fn).LostFocus += c;
			break;
		case 238:
			fo = (GroupBox)target;
			break;
		case 239:
			fp = (Button)target;
			((ButtonBase)fp).Click += ba;
			break;
		case 240:
			fq = (Button)target;
			((ButtonBase)fq).Click += a9;
			break;
		case 241:
			fr = (Button)target;
			((ButtonBase)fr).Click += a8;
			break;
		case 242:
			fs = (CheckBox)target;
			((ButtonBase)fs).Click += dz;
			break;
		case 243:
			ft = (ListBox)target;
			break;
		case 244:
			fu = (DataGrid)target;
			fu.LoadingRow += a;
			fu.CurrentCellChanged += c;
			fu.CellEditEnding += a;
			((Control)fu).MouseDoubleClick += c;
			break;
		case 245:
			fv = (MenuItem)target;
			fv.Click += a6;
			break;
		case 246:
			fw = (MenuItem)target;
			fw.Click += dt;
			break;
		case 247:
			fx = (MenuItem)target;
			fx.Click += ds;
			break;
		case 248:
			fy = (ListView)target;
			((Selector)fy).SelectionChanged += an;
			break;
		case 249:
			fz = (TextBox)target;
			((UIElement)fz).KeyDown += b;
			((Control)fz).MouseDoubleClick += d;
			break;
		case 250:
			f0 = (TextBox)target;
			((UIElement)f0).KeyDown += b;
			((Control)f0).MouseDoubleClick += d;
			break;
		case 251:
			f1 = (Button)target;
			((ButtonBase)f1).Click += a5;
			break;
		case 252:
			f2 = (Button)target;
			((ButtonBase)f2).Click += a4;
			break;
		case 253:
			f3 = (Button)target;
			((ButtonBase)f3).Click += a3;
			break;
		case 254:
			f4 = (ListView)target;
			((Selector)f4).SelectionChanged += al;
			break;
		case 255:
			f5 = (MenuItem)target;
			f5.Click += aw;
			break;
		case 256:
			f6 = (MenuItem)target;
			f6.Click += x;
			break;
		case 257:
			f7 = (Button)target;
			((ButtonBase)f7).Click += aw;
			break;
		case 258:
			f8 = (TabControl)target;
			break;
		case 259:
			f9 = (Label)target;
			break;
		case 260:
			ga = (GroupBox)target;
			break;
		case 261:
			gb = (TextBox)target;
			break;
		case 262:
			gc = (GroupBox)target;
			break;
		case 263:
			gd = (RadioButton)target;
			((ButtonBase)gd).Click += a2;
			break;
		case 264:
			ge = (RadioButton)target;
			((ButtonBase)ge).Click += a2;
			break;
		case 265:
			gf = (GroupBox)target;
			break;
		case 266:
			gg = (TextBox)target;
			((UIElement)gg).LostFocus += a1;
			break;
		case 267:
			gh = (CheckBox)target;
			((ButtonBase)gh).Click += a0;
			break;
		case 268:
			gi = (GroupBox)target;
			break;
		case 269:
			gj = (CheckBox)target;
			((ButtonBase)gj).Click += az;
			break;
		case 270:
			gk = (TextBox)target;
			((UIElement)gk).LostFocus += ay;
			break;
		case 271:
			gl = (CheckBox)target;
			((ButtonBase)gl).Click += ax;
			break;
		case 272:
			gm = (ListView)target;
			((Selector)gm).SelectionChanged += ao;
			break;
		case 273:
			gn = (TextBox)target;
			((UIElement)gn).KeyDown += b;
			((Control)gn).MouseDoubleClick += d;
			break;
		case 274:
			go = (TextBox)target;
			((UIElement)go).KeyDown += b;
			((Control)go).MouseDoubleClick += d;
			break;
		case 275:
			gp = (Button)target;
			((ButtonBase)gp).Click += av;
			break;
		case 276:
			gq = (Button)target;
			((ButtonBase)gq).Click += at;
			break;
		case 277:
			gr = (Button)target;
			((ButtonBase)gr).Click += au;
			break;
		case 278:
			gs = (WPFActionControl)target;
			break;
		case 279:
			gt = (ListView)target;
			((Selector)gt).SelectionChanged += ak;
			break;
		case 280:
			gu = (Grid)target;
			break;
		case 281:
			gv = (MediaElement)target;
			break;
		case 282:
			gw = (ListBox)target;
			((UIElement)gw).Drop += h;
			break;
		case 283:
			gx = (Button)target;
			((UIElement)gx).DragEnter += i;
			((ButtonBase)gx).Click += dx;
			break;
		case 284:
			gy = (Button)target;
			((ButtonBase)gy).Click += dv;
			break;
		case 285:
			gz = (Button)target;
			((ButtonBase)gz).Click += dw;
			break;
		case 286:
			g0 = (TreeView)target;
			((UIElement)g0).MouseLeftButtonDown += e;
			((UIElement)g0).MouseMove += c;
			g0.SelectedItemChanged += a;
			((UIElement)g0).Drop += c;
			break;
		case 287:
			g1 = (MenuItem)target;
			g1.Click += @as;
			break;
		case 288:
			g2 = (MenuItem)target;
			g2.Click += ap;
			break;
		case 289:
			g3 = (MenuItem)target;
			g3.Click += ao;
			break;
		case 290:
			g4 = (MenuItem)target;
			g4.Click += an;
			break;
		case 291:
			g5 = (MenuItem)target;
			g5.Click += aj;
			break;
		case 292:
			g6 = (MediaElement)target;
			break;
		case 293:
			g7 = (TreeView)target;
			g7.SelectedItemChanged += c;
			((UIElement)g7).MouseLeftButtonDown += b;
			((UIElement)g7).MouseMove += b;
			((UIElement)g7).Drop += b;
			((UIElement)g7).KeyDown += a;
			break;
		case 294:
			g8 = (MenuItem)target;
			g8.Click += cg;
			break;
		case 295:
			g9 = (MenuItem)target;
			g9.Click += ai;
			break;
		case 296:
			ha = (MenuItem)target;
			ha.Click += ah;
			break;
		case 297:
			hb = (MenuItem)target;
			hb.Click += ag;
			break;
		case 298:
			hc = (MenuItem)target;
			hc.Click += af;
			break;
		case 299:
			hd = (MenuItem)target;
			hd.Click += ae;
			break;
		case 300:
			he = (MenuItem)target;
			he.Click += ad;
			break;
		default:
			hf = true;
			break;
		}
	}

	[CompilerGenerated]
	private static void a()
	{
	}

	[CompilerGenerated]
	private static int a(GameVariable A_0, GameVariable A_1)
	{
		if (A_0.varname == null && A_1.varname == null)
		{
			return 0;
		}
		if (A_0.varname == null)
		{
			return -1;
		}
		if (A_1.varname == null)
		{
			return 1;
		}
		return A_0.varname.CompareTo(A_1.varname);
	}

	[CompilerGenerated]
	private static int a(GameObject A_0, GameObject A_1)
	{
		if (A_0.name == null && A_1.name == null)
		{
			return 0;
		}
		if (A_0.name == null)
		{
			return -1;
		}
		if (A_1.name == null)
		{
			return 1;
		}
		return A_0.name.CompareTo(A_1.name);
	}

	[CompilerGenerated]
	private static int a(GamePicture A_0, GamePicture A_1)
	{
		if (A_0.TheName == null && A_1.TheName == null)
		{
			return 0;
		}
		if (A_0.TheName == null)
		{
			return -1;
		}
		if (A_1.TheName == null)
		{
			return 1;
		}
		return A_0.TheName.CompareTo(A_1.TheName);
	}

	static RagsDesigner()
	{
		RagsDesigner.m_e = false;
		RagsDesigner.m_f = false;
	}
}
