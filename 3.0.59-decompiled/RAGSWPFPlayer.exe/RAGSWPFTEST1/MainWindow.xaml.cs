using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.JScript;
using Microsoft.Win32;
using Polenter.Serialization;
using RAGSWPFPlayer;
using Rags;
using WPFRagsLib;
using mshtml;

namespace RAGSWPFTEST1;

public partial class MainWindow : Window, IComponentConnector
{
	public delegate void LiveTimer(object sender);

	private enum b
	{
		a,
		b
	}

	private enum a
	{
		a,
		b,
		c,
		d,
		e
	}

	private ContextMenu m_a;

	private int m_b;

	private int m_c;

	private Game m_d = new Game();

	private static bool m_e;

	private bool m_f;

	private static bool m_g;

	private static string m_h;

	private List<RagsThread> m_i = new List<RagsThread>();

	private static bool m_j;

	private LiveTimer m_k;

	private Exit.Directions m_l;

	private Random m_m = new Random();

	private bool m_n;

	private string m_o = string.Empty;

	private a m_p;

	private string m_q = "²µ±±³àòå²²";

	private DebugDataWindow m_r;

	internal Grid s;

	internal MenuItem t;

	internal Grid u;

	internal Border v;

	internal MediaElement w;

	internal Border x;

	internal WebBrowser y;

	internal Button z;

	internal Grid aa;

	internal Border ab;

	internal MediaElement ac;

	internal Label ad;

	internal Border ae;

	internal StatusBar af;

	internal Grid ag;

	internal ColumnDefinition ah;

	internal ColumnDefinition ai;

	internal ColumnDefinition aj;

	internal ColumnDefinition ak;

	internal ColumnDefinition al;

	internal ColumnDefinition am;

	internal Grid an;

	internal Image ao;

	internal Button ap;

	internal Button aq;

	internal Grid ar;

	internal Image @as;

	internal Button at;

	internal Button au;

	internal Button av;

	internal Button aw;

	internal Button ax;

	internal Button ay;

	internal Button az;

	internal Button a0;

	internal Button a1;

	internal Button a2;

	internal Grid a3;

	internal Border a4;

	internal MediaElement a5;

	internal Grid a6;

	internal ListBox a7;

	internal Grid a8;

	internal ListBox a9;

	internal Grid ba;

	internal ListBox bb;

	internal MediaElement bc;

	internal MediaElement bd;

	private bool be;

	[CompilerGenerated]
	private static System.Action bf;

	[CompilerGenerated]
	private static System.Action bg;

	[CompilerGenerated]
	private static System.Action bh;

	[CompilerGenerated]
	private static System.Action bi;

	[CompilerGenerated]
	private static System.Action bj;

	[CompilerGenerated]
	private static System.Action bk;

	[CompilerGenerated]
	private static System.Action bl;

	[CompilerGenerated]
	private static System.Action bm;

	[CompilerGenerated]
	private static System.Action bn;

	[CompilerGenerated]
	private static System.Action bo;

	public event LiveTimer OnLiveTimerEvent
	{
		add
		{
			LiveTimer liveTimer = this.m_k;
			LiveTimer liveTimer2;
			do
			{
				liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Combine(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref this.m_k, value2, liveTimer2);
			}
			while ((object)liveTimer != liveTimer2);
		}
		remove
		{
			LiveTimer liveTimer = this.m_k;
			LiveTimer liveTimer2;
			do
			{
				liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Remove(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref this.m_k, value2, liveTimer2);
			}
			while ((object)liveTimer != liveTimer2);
		}
	}

	public MainWindow()
	{
		InitializeComponent();
		this.m_d = new Game();
		OnLiveTimerEvent += a;
		this.y.NavigateToString("</br>");
	}

	private void p(object A_0, RoutedEventArgs A_1)
	{
		((UIElement)an).IsEnabled = true;
		((UIElement)ar).IsEnabled = true;
		((UIElement)this.w).IsEnabled = true;
		((UIElement)this.aa).IsEnabled = true;
		((UIElement)a3).IsEnabled = true;
		((UIElement)a6).IsEnabled = true;
		((UIElement)a8).IsEnabled = true;
		((UIElement)ba).IsEnabled = true;
		((UIElement)this.z).IsEnabled = false;
	}

	private void o(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).Close();
	}

	private void a(object A_0, NavigationEventArgs A_1)
	{
		HTMLDocument hTMLDocument = this.y.Document as HTMLDocument;
		if (!this.t.IsChecked)
		{
			bool flag = false;
			if (this.m_c < this.m_d.TurnCount)
			{
				this.m_c = this.m_d.TurnCount;
				flag = true;
			}
			if (this.m_b > 0)
			{
				hTMLDocument.parentWindow.scrollTo(0, this.m_b + Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0));
				object obj = this.y.InvokeScript("getVerticalScrollPosition");
				if (flag)
				{
					this.m_b = Convert.ToInt32(obj.ToString());
				}
			}
			try
			{
				object obj2 = this.y.InvokeScript("atbottom");
				bool flag2 = Convert.ToBoolean(obj2.ToString());
				while (!flag2)
				{
					u();
					hTMLDocument.parentWindow.scrollBy(0, Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0));
					object obj3 = this.y.InvokeScript("getVerticalScrollPosition");
					if (Convert.ToInt32(obj3.ToString()) - this.m_b > Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0))
					{
						this.m_b = Convert.ToInt32(obj3.ToString());
					}
					obj2 = this.y.InvokeScript("atbottom");
					flag2 = Convert.ToBoolean(obj2.ToString());
				}
				return;
			}
			catch (Exception ex)
			{
				_ = ex.Message;
				return;
			}
		}
		try
		{
			object obj4 = this.y.InvokeScript("atbottom");
			bool flag3 = Convert.ToBoolean(obj4.ToString());
			while (!flag3)
			{
				hTMLDocument.parentWindow.scrollBy(0, Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0));
				object obj5 = this.y.InvokeScript("getVerticalScrollPosition");
				if (Convert.ToInt32(obj5.ToString()) - this.m_b > Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0))
				{
					this.m_b = Convert.ToInt32(obj5.ToString());
				}
				obj4 = this.y.InvokeScript("atbottom");
				flag3 = Convert.ToBoolean(obj4.ToString());
			}
		}
		catch (Exception ex2)
		{
			_ = ex2.Message;
		}
	}

	private void n(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).Filter = "Rags Game Files|*.rag|All Files|*.*";
		if (((CommonDialog)val).ShowDialog() == true)
		{
			this.m_n = true;
			this.m_o = ((FileDialog)val).FileName;
			((UIElement)an).IsEnabled = true;
			((UIElement)ar).IsEnabled = true;
			((UIElement)this.w).IsEnabled = true;
			((UIElement)this.aa).IsEnabled = true;
			((UIElement)a3).IsEnabled = true;
			((UIElement)a6).IsEnabled = true;
			((UIElement)a8).IsEnabled = true;
			((UIElement)ba).IsEnabled = true;
			((UIElement)this.z).IsEnabled = false;
			p();
			e(((FileDialog)val).FileName);
		}
	}

	private void e(string A_0)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected Obj, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		try
		{
			this.m_d = SaveLoad.Game_LoadGame(A_0);
		}
		catch
		{
			flag = true;
		}
		if (flag)
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			EncDec.Decrypt(A_0, ref memst, ref cs, this.m_q);
			memst.Seek(0L, SeekOrigin.Begin);
			try
			{
				this.m_d = null;
				SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
				if (this.m_d == null)
				{
					memst.Seek(0L, SeekOrigin.Begin);
					this.m_d = (Game)sharpSerializer.Deserialize(memst);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Sorry, this RAGS game file is incompatible.");
				return;
			}
			memst.Close();
			memst.Dispose();
			if (cs != null)
			{
				cs.Close();
				cs.Dispose();
			}
		}
		if (this.m_d == null)
		{
			return;
		}
		GameObject.TheGame = this.m_d;
		Character.TheGame = this.m_d;
		aa();
		z();
		((Window)this).Title = "Rapid Game Development System " + Path.GetFileName(A_0) + " " + Game.CurrentObjectVersionNumber;
		GameObject.TheGame = this.m_d;
		Character.TheGame = this.m_d;
		if (this.m_d.ThePlayer.bPromptForGender)
		{
			GetGenderWindow getGenderWindow = new GetGenderWindow();
			((ToggleButton)getGenderWindow.a).IsChecked = true;
			DoubleAnimation val = new DoubleAnimation();
			val.From = 0.0;
			val.To = 1.0;
			((Timeline)val).Duration = new Duration(TimeSpan.FromSeconds(0.5));
			((UIElement)getGenderWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val);
			if (((Window)getGenderWindow).ShowDialog() == true)
			{
				if (((ToggleButton)getGenderWindow.a).IsChecked == true)
				{
					this.m_d.ThePlayer.PlayerGender = Player.Gender.Male;
				}
				if (((ToggleButton)getGenderWindow.b).IsChecked == true)
				{
					this.m_d.ThePlayer.PlayerGender = Player.Gender.Female;
				}
				if (((ToggleButton)getGenderWindow.c).IsChecked == true)
				{
					this.m_d.ThePlayer.PlayerGender = Player.Gender.Other;
				}
			}
		}
		if (this.m_d.ThePlayer.bPromptForName)
		{
			AdditionalInputWindow additionalInputWindow = new AdditionalInputWindow(Rags.Action.ActionInputType.Text, ref bb, ref a7, ref a9);
			((Window)additionalInputWindow).Owner = (Window)(object)this;
			Point val2 = ((UIElement)this.v).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this);
			val2 = ((Visual)this).PointToScreen(val2);
			((Window)additionalInputWindow).Left = val2.X;
			((Window)additionalInputWindow).Top = val2.Y;
			((FrameworkElement)additionalInputWindow).Height = ((FrameworkElement)this.v).ActualHeight;
			((FrameworkElement)additionalInputWindow).Width = ((FrameworkElement)this.v).ActualWidth;
			((ContentControl)additionalInputWindow.d).Content = "Enter your character's name:";
			DoubleAnimation val3 = new DoubleAnimation();
			val3.From = 0.0;
			val3.To = 1.0;
			((Timeline)val3).Duration = new Duration(TimeSpan.FromSeconds(0.5));
			((UIElement)additionalInputWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val3);
			if (((Window)additionalInputWindow).ShowDialog() == true)
			{
				this.m_d.ThePlayer.Name = additionalInputWindow.e.Text;
			}
		}
		if (this.m_d.ThePlayer.StartingRoom == null)
		{
			return;
		}
		this.m_d.ThePlayer.CurrentRoom = this.m_d.GetRoomByID(this.m_d.ThePlayer.StartingRoom.UniqueID);
		a(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
		a(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
		this.m_n = false;
		SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, this.m_d.Title + "</br>" + this.m_d.OpeningMessage + "</br>");
		a(A_0: true, A_1: true);
		x();
		w();
		v();
		b("<<On Game Start>>");
		if (this.m_d == null)
		{
			return;
		}
		if (this.m_d.bgMusic != string.Empty)
		{
			object pictureByName = SaveLoad.GetPictureByName(this.m_d.bgMusic, ref this.m_d);
			if (pictureByName != null && pictureByName is string uriString)
			{
				bc.Source = new Uri(uriString);
			}
		}
		y();
	}

	private void ab()
	{
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (@object.locationtype != GameObject.LocationType.LT_ROOM)
			{
				continue;
			}
			try
			{
				new Guid(@object.locationname);
			}
			catch
			{
				if (this.m_d.GetRoomByName(@object.locationname) != null)
				{
					@object.locationname = this.m_d.GetRoomByName(@object.locationname).UniqueID.ToString();
				}
			}
		}
		foreach (Character character in this.m_d.CharacterList)
		{
			if (character.CurrentRoom == "<None>")
			{
				character.CurrentRoom = Room.VoidRoomGuid.ToString();
				continue;
			}
			try
			{
				new Guid(character.CurrentRoom);
			}
			catch
			{
				if (character.CurrentRoom == string.Empty)
				{
					character.CurrentRoom = Room.VoidRoomGuid.ToString();
				}
				else if (this.m_d.GetRoomByName(character.CurrentRoom) != null)
				{
					character.CurrentRoom = this.m_d.GetRoomByName(character.CurrentRoom).UniqueID.ToString();
				}
			}
		}
	}

	private void aa()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		if (this.m_d == null)
		{
			return;
		}
		((ItemsControl)af).Items.Clear();
		foreach (StatusBarItem statusBarItem in this.m_d.StatusBarItems)
		{
			StatusBarItem val = new StatusBarItem();
			((ContentControl)val).Content = statusBarItem.Text;
			((ItemsControl)af).Items.Add((object)val);
			((ItemsControl)af).Items.Add((object)new Separator());
		}
		for (int i = 0; i < this.m_d.TimerList.Count; i++)
		{
			Rags.Timer atimer = this.m_d.TimerList[i];
			if (!atimer.LiveTimer)
			{
				continue;
			}
			Thread athread = new Thread(RunTestThread);
			bool flag = true;
			foreach (RagsThread item in this.m_i)
			{
				if (item.CurTimer.Name == atimer.Name)
				{
					flag = false;
					item.CurTimer = atimer;
					break;
				}
			}
			if (flag)
			{
				RagsThread ragsThread = new RagsThread(ref athread, ref atimer);
				this.m_i.Add(ragsThread);
				athread.Start(ragsThread);
			}
		}
	}

	private void z()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		if (this.m_d == null)
		{
			return;
		}
		((ItemsControl)af).Items.Clear();
		foreach (StatusBarItem statusBarItem in this.m_d.StatusBarItems)
		{
			if (statusBarItem.bVisisble)
			{
				StatusBarItem val = new StatusBarItem();
				((ContentControl)val).Content = this.m_d.PerformTextReplacements(statusBarItem.Text, null);
				((ItemsControl)af).Items.Add((object)val);
				((ItemsControl)af).Items.Add((object)new Separator());
			}
		}
	}

	public void RunTestThread(object data)
	{
		RagsThread ragsThread = data as RagsThread;
		int num = 0;
		while (!ragsThread.bTerminate)
		{
			Thread.Sleep(500);
			num += 500;
			if (num < ragsThread.CurTimer.TimerSeconds * 1000)
			{
				continue;
			}
			num = 0;
			try
			{
				if (ragsThread.CurTimer.Active)
				{
					((DispatcherObject)this.s).Dispatcher.Invoke((Delegate)this.m_k, new object[1] { ragsThread.CurTimer });
				}
			}
			catch
			{
				break;
			}
		}
	}

	private void a(object A_0)
	{
		if (A_0 is Rags.Timer a_)
		{
			a(a_);
		}
		y();
		x();
		w();
		v();
	}

	private bool a(Rags.Timer A_0)
	{
		bool result = true;
		MainWindow.m_g = false;
		if (A_0.Active)
		{
			if (this.m_r != null)
			{
				this.m_r.AddExecutionData("TIMER: " + A_0.Name, bBold: false);
			}
			A_0.TurnNumber++;
			if (A_0.TurnNumber > A_0.Length && A_0.TType == Rags.Timer.TimerType.TT_LENGTH)
			{
				if (!A_0.Restart)
				{
					A_0.Active = false;
				}
				A_0.TurnNumber = 0;
			}
			else
			{
				Rags.Action A_1 = A_0.GetActionByName("<<On Each Turn>>");
				if (A_1 != null)
				{
					a(ref A_1, null);
				}
				if (MainWindow.m_g)
				{
					return false;
				}
				A_1 = A_0.GetActionByName("<<On Turn " + A_0.TurnNumber + ">>");
				if (A_1 != null)
				{
					a(ref A_1, null);
				}
				if (MainWindow.m_g)
				{
					return false;
				}
				if (A_0.TurnNumber == A_0.Length)
				{
					A_1 = A_0.GetActionByName("<<On Last Turn>>");
					if (A_1 != null)
					{
						a(ref A_1, null);
					}
				}
			}
			z();
		}
		return result;
	}

	private bool a(ref Rags.Action A_0, GameObject A_1)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected Obj, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Obj, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		if (this.m_d == null)
		{
			return false;
		}
		if (this.m_r != null)
		{
			this.m_r.AddExecutionData("ACTION: " + A_0.name, bBold: true);
		}
		string text = "";
		this.m_d.AdditionalData = "";
		AdditionalInputWindow additionalInputWindow = null;
		if (A_0.InputType != Rags.Action.ActionInputType.None)
		{
			if (A_0.InputType == Rags.Action.ActionInputType.Custom)
			{
				ListBox inv = new ListBox();
				foreach (string customChoice in A_0.CustomChoices)
				{
					((ItemsControl)inv).Items.Add((object)this.m_d.PerformTextReplacements(customChoice, null));
				}
				additionalInputWindow = new AdditionalInputWindow(A_0.InputType, ref inv, ref a7, ref a9);
				((Window)additionalInputWindow).Owner = (Window)(object)this;
				((ContentControl)additionalInputWindow.d).Content = this.m_d.PerformTextReplacements(A_0.CustomChoiceTitle, null);
			}
			else
			{
				additionalInputWindow = new AdditionalInputWindow(A_0.InputType, ref bb, ref a7, ref a9);
				((Window)additionalInputWindow).Owner = (Window)(object)this;
				if (A_0.CustomChoiceTitle != string.Empty)
				{
					((ContentControl)additionalInputWindow.d).Content = this.m_d.PerformTextReplacements(A_0.CustomChoiceTitle, null);
				}
			}
			if (!this.m_d.bHideMainPicDisplay)
			{
				Point val = ((UIElement)this.v).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this);
				val = ((Visual)this).PointToScreen(val);
				((Window)additionalInputWindow).Left = val.X;
				((Window)additionalInputWindow).Top = val.Y;
				((FrameworkElement)additionalInputWindow).Height = ((FrameworkElement)this.v).ActualHeight;
				((FrameworkElement)additionalInputWindow).Width = ((FrameworkElement)this.v).ActualWidth;
				DoubleAnimation val2 = new DoubleAnimation();
				val2.From = 0.0;
				val2.To = 1.0;
				((Timeline)val2).Duration = new Duration(TimeSpan.FromSeconds(0.5));
				((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
				{
				}));
				object obj = this.y.InvokeScript("atbottom");
				bool flag = Convert.ToBoolean(obj.ToString());
				while (!flag)
				{
					((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
					{
					}));
					flag = Convert.ToBoolean(obj.ToString());
				}
				((UIElement)additionalInputWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val2);
				if (((Window)additionalInputWindow).ShowDialog() != true)
				{
					return false;
				}
			}
			else
			{
				DoubleAnimation val3 = new DoubleAnimation();
				val3.From = 0.0;
				val3.To = 1.0;
				((Timeline)val3).Duration = new Duration(TimeSpan.FromSeconds(0.5));
				((UIElement)additionalInputWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val3);
				if (((Window)additionalInputWindow).ShowDialog() != true)
				{
					return false;
				}
			}
			text = string.Empty;
			switch (A_0.InputType)
			{
			case Rags.Action.ActionInputType.Object:
			case Rags.Action.ActionInputType.Character:
			case Rags.Action.ActionInputType.ObjectOrCharacter:
			case Rags.Action.ActionInputType.Custom:
			case Rags.Action.ActionInputType.Inventory:
				if (((Selector)additionalInputWindow.f).SelectedItem != null)
				{
					GameObject gameObject = ((Selector)additionalInputWindow.f).SelectedItem as GameObject;
					Character character = ((Selector)additionalInputWindow.f).SelectedItem as Character;
					if (gameObject == null)
					{
						text = ((character == null) ? ((Selector)additionalInputWindow.f).SelectedItem.ToString() : character.Charname);
					}
					else
					{
						text = gameObject.name;
					}
				}
				break;
			case Rags.Action.ActionInputType.Text:
				text = additionalInputWindow.e.Text;
				break;
			}
			this.m_d.AdditionalData = text;
			GameObject objectByName = this.m_d.GetObjectByName(text);
			string empty = string.Empty;
			SaveLoad.AddTextToRTF(text: (objectByName == null) ? text : objectByName.name, rtcontrol: ref this.y, TheGame: ref this.m_d);
		}
		bool flag2 = true;
		if (A_0.bConditionFailOnFirst)
		{
			for (int num = 0; num < A_0.Conditions.Count; num++)
			{
				Condition condition = A_0.Conditions[num];
				if (a(condition, text, A_0.InputType, A_1, ref A_0, null))
				{
					if (condition.Checks.Count != 1 || (condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_While && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Rooms && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Characters && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Items && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Exits && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Char_Inventory && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Container && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Inventory && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Room && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Group))
					{
						a(condition.PassCommands, A_1, text, ref A_0, null);
					}
					continue;
				}
				flag2 = false;
				a(condition.FailCommands, A_1, text, ref A_0, null);
				break;
			}
		}
		else
		{
			flag2 = false;
			if (A_0.Conditions.Count == 0)
			{
				flag2 = true;
			}
			for (int num2 = 0; num2 < A_0.Conditions.Count; num2++)
			{
				Condition condition2 = A_0.Conditions[num2];
				bool flag3 = a(condition2, text, A_0.InputType, A_1, ref A_0, null);
				if (flag3)
				{
					flag2 = flag3;
					a(condition2.PassCommands, A_1, text, ref A_0, null);
				}
				else
				{
					a(condition2.FailCommands, A_1, text, ref A_0, null);
				}
			}
		}
		if (flag2)
		{
			a(A_0.PassCommands, A_1, text, ref A_0, null);
		}
		else
		{
			a(A_0.FailCommands, A_1, text, ref A_0, null);
		}
		return true;
	}

	private void y()
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected Obj, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if (this.m_d == null)
		{
			return;
		}
		foreach (Rags.Action action in this.m_d.ThePlayer.Actions)
		{
			if (action.name.Substring(0, 2) != "<<" && action.bActive)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			a4.BorderBrush = (Brush)new SolidColorBrush(Colors.Green);
			a4.BorderThickness = new Thickness(3.0);
		}
		else
		{
			a4.BorderBrush = (Brush)new SolidColorBrush(Colors.Black);
			a4.BorderThickness = new Thickness(1.0);
		}
		flag = false;
		if (this.m_d.ThePlayer.CurrentRoom == null)
		{
			return;
		}
		foreach (Rags.Action action2 in this.m_d.ThePlayer.CurrentRoom.Actions)
		{
			if (action2.name.Substring(0, 2) != "<<" && action2.bActive)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			this.ab.BorderBrush = (Brush)new SolidColorBrush(Colors.Green);
			this.ab.BorderThickness = new Thickness(3.0);
		}
		else
		{
			this.ab.BorderBrush = (Brush)new SolidColorBrush(Colors.Black);
			this.ab.BorderThickness = new Thickness(1.0);
		}
	}

	private bool a(List<object> A_0, GameObject A_1, string A_2, ref Rags.Action A_3, object A_4)
	{
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_7844: Unknown result type (might be due to invalid IL or missing references)
		//IL_8019: Unknown result type (might be due to invalid IL or missing references)
		//IL_80a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_765a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7660: Unknown result type (might be due to invalid IL or missing references)
		//IL_7665: Unknown result type (might be due to invalid IL or missing references)
		//IL_766a: Unknown result type (might be due to invalid IL or missing references)
		//IL_766e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7673: Unknown result type (might be due to invalid IL or missing references)
		//IL_76c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_76cc: Expected Obj, but got Unknown
		//IL_770c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2009: Unknown result type (might be due to invalid IL or missing references)
		//IL_71a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected Obj, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected Obj, but got Unknown
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Expected Obj, but got Unknown
		//IL_163f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b31: Expected Obj, but got Unknown
		//IL_2b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b87: Expected Obj, but got Unknown
		//IL_7b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b34: Expected Obj, but got Unknown
		//IL_753e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7547: Expected Obj, but got Unknown
		//IL_7c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7caf: Expected Obj, but got Unknown
		//IL_7cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_185d: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		for (int i = 0; i < A_0.Count; i++)
		{
			Command command = A_0[i] as Command;
			if (A_0[i] is Condition condition)
			{
				if (a(condition, A_2, A_3.InputType, A_1, ref A_3, A_4))
				{
					if (condition.Checks.Count != 1 || (condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_While && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Rooms && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Characters && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Items && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Exits && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Char_Inventory && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Container && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Inventory && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Room && condition.Checks[0].CondType != Condition.ConditionType.CT_Loop_Item_Group))
					{
						result = a(condition.PassCommands, A_1, A_2, ref A_3, A_4);
					}
				}
				else
				{
					result = a(condition.FailCommands, A_1, A_2, ref A_3, A_4);
				}
			}
			else
			{
				if (command == null)
				{
					continue;
				}
				if (this.m_d == null)
				{
					return false;
				}
				string text = this.m_d.PerformTextReplacements(command.CommandPart2, A_4);
				string text2 = this.m_d.PerformTextReplacements(command.CommandPart3, A_4);
				string text3 = this.m_d.PerformTextReplacements(command.CommandPart4, A_4);
				string text4 = this.m_d.PerformTextReplacements(command.CommandText, A_4);
				if (this.m_r != null)
				{
					this.m_r.AddExecutionData("COMMAND: " + command.cmdtype.ToString() + ":" + text + ":" + text2 + ":" + text3 + " Executing", bBold: false);
				}
				try
				{
					switch (command.cmdtype)
					{
					case Command.CommandType.CT_Execute_SQL:
					{
						GameVariable variableByName9 = this.m_d.GetVariableByName(text);
						if (variableByName9 == null)
						{
							break;
						}
						try
						{
							SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
							SqlCeCommand sqlCeCommand = new SqlCeCommand(text4, dBConnection);
							SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
							variableByName9.VarArray = new List<object>();
							while (sqlCeDataReader.Read())
							{
								List<string> list = new List<string>();
								variableByName9.VarArray.Add(list);
								for (int num21 = 0; num21 < sqlCeDataReader.FieldCount; num21++)
								{
									list.Add(sqlCeDataReader.GetValue(num21).ToString());
								}
							}
						}
						catch (Exception ex)
						{
							variableByName9.VarArray = new List<object>();
							List<string> list2 = new List<string>();
							variableByName9.VarArray.Add(list2);
							list2.Add(ex.Message);
						}
						break;
					}
					case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
					{
						GameVariable variableByName18 = this.m_d.GetVariableByName(text);
						if (variableByName18 == null)
						{
							break;
						}
						List<string> A_16 = new List<string>();
						a(ref A_16, text2, MainWindow.b.a);
						if (A_16.Count > 0)
						{
							string text54 = A_16[this.m_m.Next(0, A_16.Count)];
							int num45 = d(text);
							int num46 = c(text);
							if (num45 == -1)
							{
								variableByName18.sString = text54;
							}
							else if (num46 != -1)
							{
								((List<string>)variableByName18.VarArray[num45])[num46] = text54;
							}
							else
							{
								variableByName18.VarArray[num45] = text54;
							}
						}
						else
						{
							variableByName18.sString = string.Empty;
						}
						break;
					}
					case Command.CommandType.CT_MM_GETRANDOMGROUP:
					{
						GameVariable variableByName17 = this.m_d.GetVariableByName(text);
						if (variableByName17 == null)
						{
							break;
						}
						List<string> A_15 = new List<string>();
						a(ref A_15, text2, MainWindow.b.b);
						if (A_15.Count > 0)
						{
							string text53 = A_15[this.m_m.Next(0, A_15.Count)];
							int num42 = d(text);
							int num43 = c(text);
							if (num42 == -1)
							{
								variableByName17.sString = text53;
							}
							else if (num43 != -1)
							{
								((List<string>)variableByName17.VarArray[num42])[num43] = text53;
							}
							else
							{
								variableByName17.VarArray[num42] = text53;
							}
						}
						else
						{
							variableByName17.sString = string.Empty;
						}
						break;
					}
					case Command.CommandType.CT_Status_ItemVisibleInvisible:
						foreach (StatusBarItem statusBarItem in this.m_d.StatusBarItems)
						{
							if (string.Compare(statusBarItem.Name, text, ignoreCase: true) == 0)
							{
								if (string.Compare(text2, "Visible", ignoreCase: true) == 0)
								{
									statusBarItem.bVisisble = true;
								}
								else
								{
									statusBarItem.bVisisble = false;
								}
								break;
							}
						}
						break;
					case Command.CommandType.CT_DISPLAYITEMDESC:
					{
						if (text == "00000000-0000-0000-0000-000000000004")
						{
							if (A_1 != null)
							{
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, A_1.Display(this.m_d.ObjectList));
							}
							break;
						}
						GameObject gameObject11 = this.m_d.GetObjectByName(text);
						if (gameObject11 == null)
						{
							gameObject11 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject11 != null)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, gameObject11.Display(this.m_d.ObjectList));
						}
						break;
					}
					case Command.CommandType.CT_LOOP_BREAK:
						return true;
					case Command.CommandType.CT_EXPORTVARIABLE:
					{
						SaveFileDialog val7 = new SaveFileDialog();
						((FileDialog)val7).Title = "Export Game Data";
						((FileDialog)val7).Filter = "Rags Export|*.rxp|All Files|*.*";
						GameVariable variableByName12 = this.m_d.GetVariableByName(text);
						if (variableByName12 != null && ((CommonDialog)val7).ShowDialog() == true)
						{
							try
							{
								StreamWriter streamWriter = new StreamWriter(((FileDialog)val7).FileName);
								SharpSerializer sharpSerializer2 = new SharpSerializer(binarySerialization: true);
								sharpSerializer2.Serialize(variableByName12, streamWriter.BaseStream);
								streamWriter.Close();
							}
							catch
							{
								MessageBox.Show("Unable to save your game data.");
							}
						}
						((FileDialog)val7).Filter = "Rich Text File|*.rtf|All Files|*.*";
						break;
					}
					case Command.CommandType.CT_IMPORTVARIABLE:
					{
						OpenFileDialog val4 = new OpenFileDialog();
						((FileDialog)val4).Title = "Import Game Data";
						string filter = ((FileDialog)val4).Filter;
						((FileDialog)val4).Filter = "Rags Export|*.rxp|All Files|*.*";
						if (((CommonDialog)val4).ShowDialog() == true)
						{
							try
							{
								StreamReader streamReader = new StreamReader(((FileDialog)val4).FileName);
								streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
								SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
								GameVariable gameVariable2 = (GameVariable)sharpSerializer.Deserialize(streamReader.BaseStream);
								streamReader.Close();
								GameVariable variableByName7 = this.m_d.GetVariableByName(gameVariable2.varname);
								if (variableByName7 != null)
								{
									this.m_d.VariableList.Remove(variableByName7);
								}
								this.m_d.VariableList.Add(gameVariable2);
							}
							catch
							{
								MessageBox.Show("Unable to load your game data.");
							}
						}
						((FileDialog)val4).Filter = filter;
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
					{
						GameVariable variableByName13 = this.m_d.GetVariableByName(text);
						if (variableByName13 != null)
						{
							int num33 = d(text);
							int num34 = c(text);
							if (num33 == -1)
							{
								variableByName13.dNumType = Convert.ToDouble(this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMax, null))) + 1));
							}
							else if (num34 != -1)
							{
								((List<string>)variableByName13.VarArray[num33])[num34] = this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMax, null))) + 1).ToString();
							}
							else
							{
								variableByName13.VarArray[num33] = Convert.ToDouble(this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName13.dMax, null))) + 1));
							}
						}
						break;
					}
					case Command.CommandType.CT_CANCELMOVE:
						this.m_f = true;
						break;
					case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
					{
						string text27 = text;
						string[] array7 = text27.Split(new char[1] { ':' }, StringSplitOptions.None);
						Rags.Action action2 = null;
						if (array7.Length > 2)
						{
							action2 = c(array7[0], array7[1], array7[2]);
						}
						else if (array7.Length == 2)
						{
							action2 = c(array7[0], "", array7[1]);
						}
						action2?.CustomChoices.Clear();
						break;
					}
					case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
					{
						string text42 = text;
						string[] array13 = text42.Split(new char[1] { ':' }, StringSplitOptions.None);
						Rags.Action action3 = null;
						if (array13.Length > 2)
						{
							action3 = c(array13[0], array13[1], array13[2]);
						}
						else if (array13.Length == 2)
						{
							action3 = c(array13[0], "", array13[1]);
						}
						if (action3 == null)
						{
							break;
						}
						bool flag10 = false;
						foreach (string customChoice in action3.CustomChoices)
						{
							if (customChoice.Equals(text4))
							{
								flag10 = true;
								break;
							}
						}
						if (!flag10)
						{
							action3.CustomChoices.Add(text4);
						}
						break;
					}
					case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
					{
						string text10 = text;
						string[] array2 = text10.Split(new char[1] { ':' }, StringSplitOptions.None);
						Rags.Action action = null;
						if (array2.Length > 2)
						{
							action = c(array2[0], array2[1], array2[2]);
						}
						else if (array2.Length == 2)
						{
							action = c(array2[0], "", array2[1]);
						}
						action?.CustomChoices.Remove(text4);
						break;
					}
					case Command.CommandType.CT_SETPLAYERGENDER:
						this.m_d.ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), text, ignoreCase: true);
						break;
					case Command.CommandType.CT_PAUSEGAME:
						this.m_n = false;
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "--------------------------------</br>");
						u();
						if (this.m_n)
						{
							return false;
						}
						break;
					case Command.CommandType.CT_LAYEREDIMAGE_ADD:
					{
						GamePicture gamePictureByName4 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName4 != null)
						{
							gamePictureByName4.LayeredImages.Add(text2);
							k();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
					{
						GamePicture gamePictureByName5 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName5 == null)
						{
							break;
						}
						foreach (string layeredImage in gamePictureByName5.LayeredImages)
						{
							if (layeredImage == text2)
							{
								gamePictureByName5.LayeredImages.Remove(layeredImage);
								break;
							}
						}
						k();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
					{
						GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						GamePicture gamePictureByName2 = SaveLoad.GetGamePictureByName(text3, ref this.m_d);
						if (gamePictureByName == null || gamePictureByName2 == null)
						{
							break;
						}
						int num29 = -1;
						bool flag8 = false;
						foreach (string layeredImage2 in gamePictureByName.LayeredImages)
						{
							num29++;
							if (layeredImage2 == text2)
							{
								flag8 = true;
								gamePictureByName.LayeredImages.Remove(layeredImage2);
								break;
							}
						}
						if (flag8)
						{
							gamePictureByName.LayeredImages.Insert(num29, text3);
							k();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
					{
						GamePicture gamePictureByName3 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName3 != null)
						{
							gamePictureByName3.LayeredImages.Clear();
							k();
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERNAME:
						this.m_d.ThePlayer.Name = this.m_d.PerformTextReplacements(text3, null);
						break;
					case Command.CommandType.CT_DISPLAYPLAYERDESC:
					{
						string text11 = this.m_d.PerformTextReplacements(this.m_d.ThePlayer.Description, null);
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text11 + "</br>");
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
					{
						GameObject gameObject15 = this.m_d.GetObjectByName(text);
						if (gameObject15 == null)
						{
							gameObject15 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject15 == null)
						{
							break;
						}
						GameObject.LocationType locationtype2 = gameObject15.locationtype;
						string locationname = gameObject15.locationname;
						bool flag13 = true;
						string text50 = string.Empty;
						foreach (string layeredZoneLevel in gameObject15.LayeredZoneLevels)
						{
							string[] array15 = layeredZoneLevel.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject @object in this.m_d.ObjectList)
							{
								if (!@object.bWorn || @object.locationtype != locationtype2 || (locationtype2 == GameObject.LocationType.LT_CHARACTER && locationname != @object.locationname))
								{
									continue;
								}
								foreach (string layeredZoneLevel2 in @object.LayeredZoneLevels)
								{
									string[] array16 = layeredZoneLevel2.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (!(gameObject15.UniqueIdentifier != @object.UniqueIdentifier) || !(array16[0] == array15[0]) || Convert.ToInt32(array16[1]) < Convert.ToInt32(array15[1]))
									{
										continue;
									}
									flag13 = false;
									if (text50.IndexOf(gameObject15.GetDisplayStringNameOnly()) != -1)
									{
										continue;
									}
									if (text50 == string.Empty)
									{
										if (locationtype2 != GameObject.LocationType.LT_CHARACTER)
										{
											string text37 = text50;
											text50 = text37 + "You cannot remove " + gameObject15.GetDisplayStringNameOnly() + ".  You need to remove " + @object.GetDisplayStringNameOnly();
										}
										else
										{
											string text37 = text50;
											text50 = text37 + locationname + " cannot remove " + gameObject15.GetDisplayStringNameOnly() + ".  " + locationname + " will need to remove " + @object.GetDisplayStringNameOnly();
										}
									}
									else
									{
										text50 = text50 + " and " + @object.GetDisplayStringNameOnly();
									}
								}
							}
						}
						if (!flag13)
						{
							text50 += " first.";
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text50 + "</br>");
							break;
						}
						if (locationtype2 != GameObject.LocationType.LT_CHARACTER)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "You take off " + gameObject15.GetDisplayStringNameOnly() + ".</br>");
						}
						else
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, locationname = locationname + " takes off " + gameObject15.GetDisplayStringNameOnly() + ".</br>");
						}
						gameObject15.bWorn = false;
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_WEAR:
					{
						GameObject gameObject10 = this.m_d.GetObjectByName(text);
						if (gameObject10 == null)
						{
							gameObject10 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject10 == null)
						{
							break;
						}
						GameObject.LocationType locationtype = gameObject10.locationtype;
						string text35 = gameObject10.locationname;
						bool flag9 = true;
						string text36 = string.Empty;
						foreach (string layeredZoneLevel3 in gameObject10.LayeredZoneLevels)
						{
							string[] array10 = layeredZoneLevel3.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject object2 in this.m_d.ObjectList)
							{
								if (!object2.bWorn || object2.locationtype != locationtype)
								{
									continue;
								}
								foreach (string layeredZoneLevel4 in object2.LayeredZoneLevels)
								{
									string[] array11 = layeredZoneLevel4.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (!(array11[0] == array10[0]) || Convert.ToInt32(array11[1]) < Convert.ToInt32(array10[1]) || (locationtype == GameObject.LocationType.LT_CHARACTER && text35 != object2.locationname))
									{
										continue;
									}
									flag9 = false;
									if (text36.IndexOf(gameObject10.GetDisplayStringNameOnly()) != -1)
									{
										continue;
									}
									if (text36 == string.Empty)
									{
										if (locationtype != GameObject.LocationType.LT_CHARACTER)
										{
											string text37 = text36;
											text36 = text37 + "You cannot wear " + gameObject10.GetDisplayStringNameOnly() + ".  You will need to remove " + object2.GetDisplayStringNameOnly();
										}
										else
										{
											string text38 = text36;
											string text37 = text35;
											text36 = text38 + (text35 = text37 + " cannot wear " + gameObject10.GetDisplayStringNameOnly() + ".  " + text35 + " will need to remove " + object2.GetDisplayStringNameOnly());
										}
									}
									else
									{
										text36 = text36 + " and " + object2.GetDisplayStringNameOnly();
									}
								}
							}
						}
						if (!flag9)
						{
							text36 += " first.";
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text36 + "<br/>");
							break;
						}
						if (locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "You put on " + gameObject10.GetDisplayStringNameOnly() + ".</br>");
						}
						else
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text35 + " puts on " + gameObject10.GetDisplayStringNameOnly() + ".</br>");
						}
						gameObject10.bWorn = true;
						break;
					}
					case Command.CommandType.CT_DEBUGTEXT:
					{
						string[] commandLineArgs = Environment.GetCommandLineArgs();
						if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "<b><span style=\"color:red\">DBG>" + text4 + "</span></b><br/>");
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYTEXT:
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text4 + "<br/>");
						break;
					case Command.CommandType.CT_ENDGAME:
					{
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text4 + "<br/>");
						DoubleAnimation val8 = new DoubleAnimation();
						val8.From = 0.0;
						val8.To = 1.0;
						((Timeline)val8).Duration = new Duration(TimeSpan.FromSeconds(0.5));
						EndGameWindow endGameWindow = new EndGameWindow();
						((Window)endGameWindow).Owner = (Window)(object)this;
						((UIElement)endGameWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val8);
						if (((Window)endGameWindow).ShowDialog() == true)
						{
							switch (endGameWindow.TheResult)
							{
							case EndGameWindow.EndGameReturn.Reset:
								MainWindow.m_e = true;
								l();
								return false;
							case EndGameWindow.EndGameReturn.Load:
								a(A_0: false);
								return false;
							case EndGameWindow.EndGameReturn.QuickLoad:
								n();
								return false;
							default:
								this.m_d = null;
								((UIElement)an).IsEnabled = false;
								((UIElement)ar).IsEnabled = false;
								((UIElement)this.w).IsEnabled = false;
								((UIElement)this.aa).IsEnabled = false;
								((UIElement)a3).IsEnabled = false;
								((UIElement)a6).IsEnabled = false;
								((UIElement)a8).IsEnabled = false;
								((UIElement)ba).IsEnabled = false;
								return false;
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOINV:
					{
						GameObject gameObject17 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject17 = A_1;
							}
						}
						else
						{
							gameObject17 = this.m_d.GetObjectByName(text);
							if (gameObject17 == null)
							{
								gameObject17 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject17 == null)
						{
							break;
						}
						if (this.m_d.ThePlayer.bEnforceWeight)
						{
							double num44 = 0.0;
							foreach (GameObject object3 in this.m_d.ObjectList)
							{
								if (object3.locationtype == GameObject.LocationType.LT_PLAYER)
								{
									num44 += this.m_d.GetItemWeight(object3.UniqueIdentifier);
								}
							}
							num44 += this.m_d.GetItemWeight(gameObject17.UniqueIdentifier);
							if (num44 > this.m_d.ThePlayer.dWeightLimit)
							{
								MessageBox.Show("The " + gameObject17.name + " is too heavy to lift at the moment.  unload some stuff first.");
								return false;
							}
						}
						gameObject17.locationtype = GameObject.LocationType.LT_PLAYER;
						break;
					}
					case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
					{
						GameObject gameObject4 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject4 = A_1;
							}
						}
						else
						{
							gameObject4 = this.m_d.GetObjectByName(text);
							if (gameObject4 == null)
							{
								gameObject4 = this.m_d.GetObjectByNameOld(text);
							}
						}
						GameObject gameObject5 = null;
						if (text2.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject5 = A_1;
							}
						}
						else
						{
							gameObject5 = this.m_d.GetObjectByName(text2);
							if (gameObject5 == null)
							{
								gameObject5 = this.m_d.GetObjectByNameOld(text2);
							}
						}
						if (gameObject4 == null || gameObject5 == null)
						{
							break;
						}
						foreach (GameObject object4 in this.m_d.ObjectList)
						{
							if (object4.locationtype == GameObject.LocationType.LT_IN_OBJECT && object4.locationname == gameObject4.UniqueIdentifier.ToString())
							{
								object4.locationname = gameObject5.UniqueIdentifier.ToString();
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_VISIBILITY:
					{
						GameObject gameObject = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject = A_1;
							}
						}
						else
						{
							gameObject = this.m_d.GetObjectByName(text);
							if (gameObject == null)
							{
								gameObject = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject != null)
						{
							if (text2.Equals("Visible"))
							{
								gameObject.bVisible = true;
							}
							else
							{
								gameObject.bVisible = false;
							}
							w();
						}
						break;
					}
					case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
						foreach (GameObject object5 in this.m_d.ObjectList)
						{
							if (object5.locationtype == GameObject.LocationType.LT_PLAYER)
							{
								object5.locationtype = GameObject.LocationType.LT_CHARACTER;
								object5.locationname = text;
							}
						}
						break;
					case Command.CommandType.CT_MOVEINVENTORYTOROOM:
						foreach (GameObject object6 in this.m_d.ObjectList)
						{
							if (object6.locationtype == GameObject.LocationType.LT_PLAYER)
							{
								if (text == Room.CurrentRoomGuid.ToString())
								{
									object6.locationtype = GameObject.LocationType.LT_ROOM;
									object6.locationname = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
								}
								else if (text == Room.VoidRoomGuid.ToString())
								{
									object6.locationtype = GameObject.LocationType.LT_NULL;
								}
								else
								{
									object6.locationtype = GameObject.LocationType.LT_ROOM;
									object6.locationname = text;
								}
							}
						}
						break;
					case Command.CommandType.CT_MOVECHARINVTOPLAYER:
					{
						Character character = null;
						character = this.m_d.GetCharacterByName(text);
						if (character == null)
						{
							break;
						}
						foreach (GameObject object7 in this.m_d.ObjectList)
						{
							if (object7.locationtype == GameObject.LocationType.LT_CHARACTER && object7.locationname == character.Charname && object7.bCarryable && object7.bVisible)
							{
								object7.locationtype = GameObject.LocationType.LT_PLAYER;
							}
						}
						break;
					}
					case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
					{
						Room room = null;
						room = ((!(text == Room.CurrentRoomGuid.ToString())) ? this.m_d.GetRoomByID(new Guid(text)) : this.m_d.ThePlayer.CurrentRoom);
						if (room == null)
						{
							break;
						}
						foreach (GameObject object8 in this.m_d.ObjectList)
						{
							if (object8.locationtype == GameObject.LocationType.LT_ROOM && object8.locationname == room.UniqueID.ToString() && object8.bCarryable && object8.bVisible)
							{
								object8.locationtype = GameObject.LocationType.LT_PLAYER;
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
					{
						if (text == Room.CurrentRoomGuid.ToString())
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, this.m_d.ThePlayer.CurrentRoom.Description + "</br>");
							break;
						}
						Room room10 = null;
						try
						{
							room10 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room10 = this.m_d.GetRoomByName(text);
						}
						if (room10 != null)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, room10.Description + "</br>");
						}
						break;
					}
					case Command.CommandType.CT_CHAR_DISPLAYPORT:
					{
						Character character3 = null;
						character3 = this.m_d.GetCharacterByName(text);
						if (character3 == null)
						{
							break;
						}
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							object obj18 = SaveLoad.GetPictureByName(character3.CharPortrait, ref this.m_d) as string;
							if (obj18 != string.Empty)
							{
								this.w.Source = new Uri(obj18 as string);
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMPICTURE:
					{
						if (text == Room.CurrentRoomGuid.ToString())
						{
							if (this.m_d.bHideMainPicDisplay)
							{
								_ = this.m_d.bUseInlineImages;
							}
							if (!this.m_d.bHideMainPicDisplay)
							{
								object obj9 = SaveLoad.GetPictureByName(this.m_d.ThePlayer.CurrentRoom.RoomPic, ref this.m_d) as string;
								this.w.Source = new Uri(obj9 as string);
							}
							break;
						}
						Room room4 = null;
						try
						{
							room4 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room4 = this.m_d.GetRoomByName(text);
						}
						if (room4 == null)
						{
							break;
						}
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							object obj11 = SaveLoad.GetPictureByName(room4.RoomPic, ref this.m_d) as string;
							if (obj11 != string.Empty)
							{
								this.w.Source = new Uri(obj11 as string);
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOROOM:
					{
						GameObject gameObject14 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject14 = A_1;
							}
						}
						else
						{
							gameObject14 = this.m_d.GetObjectByName(text);
							if (gameObject14 == null)
							{
								gameObject14 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject14 == null)
						{
							break;
						}
						gameObject14.locationtype = GameObject.LocationType.LT_ROOM;
						if (text2 == Room.CurrentRoomGuid.ToString())
						{
							gameObject14.locationname = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
							break;
						}
						if (text2 == Room.VoidRoomGuid.ToString())
						{
							gameObject14.locationtype = GameObject.LocationType.LT_NULL;
							break;
						}
						string text47 = string.Empty;
						try
						{
							new Guid(text2);
							text47 = text2;
						}
						catch
						{
							Room roomByName3 = this.m_d.GetRoomByName(text2);
							if (roomByName3 != null)
							{
								text47 = roomByName3.UniqueID.ToString();
							}
						}
						if (text47 == string.Empty)
						{
							MessageBox.Show("Error in command CT_MoveItemToRoom.  Could not locate a room called " + text2);
						}
						else
						{
							gameObject14.locationname = text47;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOOBJ:
					{
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 == null)
							{
								break;
							}
							string text32 = string.Empty;
							try
							{
								text32 = new Guid(text2).ToString();
							}
							catch
							{
								GameObject objectByNameOld = this.m_d.GetObjectByNameOld(text2);
								if (objectByNameOld != null)
								{
									text32 = objectByNameOld.UniqueIdentifier.ToString();
								}
							}
							if (text32 != string.Empty)
							{
								A_1.locationtype = GameObject.LocationType.LT_IN_OBJECT;
								A_1.locationname = text32;
							}
							break;
						}
						GameObject gameObject9 = this.m_d.GetObjectByName(text);
						if (gameObject9 == null)
						{
							gameObject9 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject9 == null)
						{
							break;
						}
						string text33 = string.Empty;
						try
						{
							text33 = new Guid(text2).ToString();
						}
						catch
						{
							GameObject objectByNameOld2 = this.m_d.GetObjectByNameOld(text2);
							if (objectByNameOld2 != null)
							{
								text33 = objectByNameOld2.UniqueIdentifier.ToString();
							}
						}
						if (text33 != string.Empty)
						{
							gameObject9.locationtype = GameObject.LocationType.LT_IN_OBJECT;
							gameObject9.locationname = text33;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOCHAR:
					{
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								A_1.locationtype = GameObject.LocationType.LT_CHARACTER;
								A_1.locationname = text2;
							}
							break;
						}
						GameObject gameObject3 = this.m_d.GetObjectByName(text);
						if (gameObject3 == null)
						{
							gameObject3 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject3 != null)
						{
							gameObject3.locationtype = GameObject.LocationType.LT_CHARACTER;
							gameObject3.locationname = text2;
						}
						break;
					}
					case Command.CommandType.CT_SETEXIT:
					{
						Room room3 = null;
						try
						{
							room3 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room3 = this.m_d.GetRoomByName(text);
						}
						if (room3 == null)
						{
							break;
						}
						int num10 = text2.IndexOf('-');
						string text9 = text2.Substring(0, num10);
						int num11 = text2.IndexOf('-', num10 + 1);
						string empty2 = string.Empty;
						empty2 = ((num11 <= -1) ? text2.Substring(num10 + 1) : text2.Substring(num10 + 1, num11 - num10 - 1));
						empty2 = empty2.Trim();
						bool bActive = false;
						if (empty2 == "Active")
						{
							bActive = true;
						}
						for (int num12 = 0; num12 < room3.Exits.Count; num12++)
						{
							if (room3.Exits[num12].Direction.ToString() == text9)
							{
								room3.Exits[num12].bActive = bActive;
								break;
							}
						}
						t();
						break;
					}
					case Command.CommandType.CT_SETEXITDESTINATION:
					{
						Room room12 = null;
						try
						{
							room12 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room12 = this.m_d.GetRoomByName(text);
						}
						if (room12 == null)
						{
							break;
						}
						Exit exit = null;
						for (int num39 = 0; num39 < room12.Exits.Count; num39++)
						{
							if (room12.Exits[num39].Direction.ToString() == text2)
							{
								exit = room12.Exits[num39];
								break;
							}
						}
						if (exit != null)
						{
							if (text3 == "<None>")
							{
								exit.DestinationRoom = string.Empty;
								exit.bActive = false;
							}
							else
							{
								Room room13 = null;
								try
								{
									room13 = this.m_d.GetRoomByID(new Guid(text3));
								}
								catch
								{
									room13 = this.m_d.GetRoomByName(text3);
								}
								if (room13 != null)
								{
									exit.DestinationRoom = room13.UniqueID.ToString();
									exit.bActive = true;
								}
							}
						}
						t();
						break;
					}
					case Command.CommandType.CT_EXECUTETIMER:
					{
						bool flag12 = MainWindow.m_j;
						string text46 = MainWindow.m_h;
						MainWindow.m_j = true;
						MainWindow.m_g = false;
						MainWindow.m_h = string.Empty;
						Rags.Timer timerByName3 = this.m_d.GetTimerByName(text);
						if (timerByName3 != null)
						{
							MainWindow.m_h = timerByName3.Name;
							Rags.Action A_14 = timerByName3.GetActionByName("<<On Each Turn>>");
							if (A_14 != null)
							{
								a(ref A_14, null);
								while (MainWindow.m_g)
								{
									MainWindow.m_g = false;
									a(ref A_14, null);
								}
							}
						}
						MainWindow.m_j = flag12;
						MainWindow.m_h = text46;
						break;
					}
					case Command.CommandType.CT_RESETTIMER:
					{
						Rags.Timer timerByName = this.m_d.GetTimerByName(text);
						if (timerByName != null)
						{
							timerByName.TurnNumber = 0;
							if (MainWindow.m_j && MainWindow.m_h == timerByName.Name)
							{
								MainWindow.m_g = true;
								return false;
							}
							MainWindow.m_g = false;
							return false;
						}
						break;
					}
					case Command.CommandType.CT_SETTIMER:
					{
						Rags.Timer timerByName2 = this.m_d.GetTimerByName(text);
						if (timerByName2 != null)
						{
							if (string.Compare(text2, "Active", ignoreCase: true) == 0)
							{
								timerByName2.Active = true;
							}
							else
							{
								timerByName2.Active = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETITEMDESC:
					{
						GameObject gameObject8 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject8 = A_1;
							}
						}
						else
						{
							gameObject8 = this.m_d.GetObjectByName(text);
							if (gameObject8 == null)
							{
								gameObject8 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject8 != null)
						{
							gameObject8.description = text4;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERDESC:
						this.m_d.ThePlayer.Description = text4;
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
					{
						GameVariable variableByName10 = this.m_d.GetVariableByName(text);
						if (variableByName10 == null)
						{
							break;
						}
						string[] array5 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text19 = string.Empty;
						if (array5.Length == 2)
						{
							string text20 = array5[0];
							string text21 = array5[1];
							Room room6 = null;
							room6 = ((!(text20 == "<CurrentRoom>")) ? this.m_d.GetRoomByName(text20) : this.m_d.ThePlayer.CurrentRoom);
							if (room6 != null)
							{
								foreach (CustomProperty customProperty in room6.CustomProperties)
								{
									if (customProperty.Name == text21)
									{
										text19 = customProperty.Value;
										break;
									}
								}
							}
						}
						int num24 = d(text);
						int num25 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName10.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num24 == -1)
							{
								variableByName10.sString = text19;
							}
							else if (num25 != -1)
							{
								((List<string>)variableByName10.VarArray[num24])[num25] = text19;
							}
							else
							{
								variableByName10.VarArray[num24] = text19;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num24 == -1)
								{
									variableByName10.dNumType = Convert.ToDouble(text19);
								}
								else if (num25 != -1)
								{
									((List<string>)variableByName10.VarArray[num24])[num25] = text19;
								}
								else
								{
									variableByName10.VarArray[num24] = text19;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Room Property Value " + text19 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE:
					{
						GameVariable variableByName8 = this.m_d.GetVariableByName(text);
						if (variableByName8 == null)
						{
							break;
						}
						string[] array3 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text12 = string.Empty;
						if (array3.Length == 2)
						{
							string timername = array3[0];
							string text13 = array3[1];
							Rags.Timer timer = null;
							timer = this.m_d.GetTimerByName(timername);
							if (timer != null)
							{
								foreach (CustomProperty customProperty2 in timer.CustomProperties)
								{
									if (customProperty2.Name == text13)
									{
										text12 = customProperty2.Value;
										break;
									}
								}
							}
						}
						int num19 = d(text);
						int num20 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName8.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num19 == -1)
							{
								variableByName8.sString = text12;
							}
							else if (num20 != -1)
							{
								((List<string>)variableByName8.VarArray[num19])[num20] = text12;
							}
							else
							{
								variableByName8.VarArray[num19] = text12;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num19 == -1)
								{
									variableByName8.dNumType = Convert.ToDouble(text12);
								}
								else if (num20 != -1)
								{
									((List<string>)variableByName8.VarArray[num19])[num20] = text12;
								}
								else
								{
									variableByName8.VarArray[num19] = text12;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Timer Property Value " + text12 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE:
					{
						GameVariable variableByName3 = this.m_d.GetVariableByName(text);
						if (variableByName3 == null)
						{
							break;
						}
						string[] array = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text6 = string.Empty;
						if (array.Length == 2)
						{
							string varname = array[0];
							string text7 = array[1];
							GameVariable gameVariable = null;
							gameVariable = this.m_d.GetVariableByName(varname);
							if (gameVariable != null)
							{
								foreach (CustomProperty customProperty3 in gameVariable.CustomProperties)
								{
									if (customProperty3.Name == text7)
									{
										text6 = customProperty3.Value;
										break;
									}
								}
							}
						}
						int num5 = d(text);
						int num6 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName3.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num5 == -1)
							{
								variableByName3.sString = text6;
							}
							else if (num6 != -1)
							{
								((List<string>)variableByName3.VarArray[num5])[num6] = text6;
							}
							else
							{
								variableByName3.VarArray[num5] = text6;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num5 == -1)
								{
									variableByName3.dNumType = Convert.ToDouble(text6);
								}
								else if (num6 != -1)
								{
									((List<string>)variableByName3.VarArray[num5])[num6] = text6;
								}
								else
								{
									variableByName3.VarArray[num5] = text6;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Variable Property Value " + text6 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
						if (!(text == "<Default>"))
						{
							BitmapImage val3 = new BitmapImage();
							val3.BeginInit();
							val3.UriSource = new Uri(SaveLoad.GetPictureByName(text, ref this.m_d) as string);
							val3.EndInit();
							@as.Source = (ImageSource)(object)val3;
						}
						break;
					case Command.CommandType.CT_MM_SET_UD_COMPASS:
						if (!(text == "<Default>"))
						{
							BitmapImage val9 = new BitmapImage();
							val9.BeginInit();
							val9.UriSource = new Uri(SaveLoad.GetPictureByName(text, ref this.m_d) as string);
							val9.EndInit();
							ao.Source = (ImageSource)(object)val9;
						}
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
					{
						GameVariable variableByName16 = this.m_d.GetVariableByName(text);
						if (variableByName16 == null)
						{
							break;
						}
						string[] array17 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text51 = string.Empty;
						if (array17.Length == 2)
						{
							string charname2 = array17[0];
							string text52 = array17[1];
							Character character4 = null;
							character4 = this.m_d.GetCharacterByName(charname2);
							if (character4 != null)
							{
								foreach (CustomProperty customProperty4 in character4.CustomProperties)
								{
									if (customProperty4.Name == text52)
									{
										text51 = customProperty4.Value;
										break;
									}
								}
							}
						}
						int num40 = d(text);
						int num41 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName16.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num40 == -1)
							{
								variableByName16.sString = text51;
							}
							else if (num41 != -1)
							{
								((List<string>)variableByName16.VarArray[num40])[num41] = text51;
							}
							else
							{
								variableByName16.VarArray[num40] = text51;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num40 == -1)
								{
									variableByName16.dNumType = Convert.ToDouble(text51);
								}
								else if (num41 != -1)
								{
									((List<string>)variableByName16.VarArray[num40])[num41] = text51;
								}
								else
								{
									variableByName16.VarArray[num40] = text51;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Character Property Value " + text51 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE:
					{
						GameVariable variableByName14 = this.m_d.GetVariableByName(text);
						if (variableByName14 == null)
						{
							break;
						}
						string[] array14 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text43 = string.Empty;
						if (array14.Length == 2)
						{
							string text44 = array14[0];
							string text45 = array14[1];
							GameObject gameObject13 = null;
							if (text44 == "<Self>")
							{
								if (A_1 != null)
								{
									gameObject13 = A_1;
								}
							}
							else
							{
								gameObject13 = this.m_d.GetObjectByNameOld(text44);
							}
							if (gameObject13 != null)
							{
								foreach (CustomProperty customProperty5 in gameObject13.CustomProperties)
								{
									if (customProperty5.Name == text45)
									{
										text43 = customProperty5.Value;
										break;
									}
								}
							}
						}
						int num35 = d(text);
						int num36 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName14.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num35 == -1)
							{
								variableByName14.sString = text43;
							}
							else if (num36 != -1)
							{
								((List<string>)variableByName14.VarArray[num35])[num36] = text43;
							}
							else
							{
								variableByName14.VarArray[num35] = text43;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num35 == -1)
								{
									variableByName14.dNumType = Convert.ToDouble(text43);
								}
								else if (num36 != -1)
								{
									((List<string>)variableByName14.VarArray[num35])[num36] = text43;
								}
								else
								{
									variableByName14.VarArray[num35] = text43;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Item Property Value " + text43 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE:
					{
						GameVariable variableByName15 = this.m_d.GetVariableByName(text);
						if (variableByName15 == null)
						{
							break;
						}
						string text48 = string.Empty;
						string text49 = text2;
						foreach (CustomProperty customProperty6 in this.m_d.ThePlayer.CustomProperties)
						{
							if (customProperty6.Name == text49)
							{
								text48 = customProperty6.Value;
								break;
							}
						}
						int num37 = d(text);
						int num38 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName15.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num37 == -1)
							{
								variableByName15.sString = text48;
							}
							else if (num38 != -1)
							{
								((List<string>)variableByName15.VarArray[num37])[num38] = text48;
							}
							else
							{
								variableByName15.VarArray[num37] = text48;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num37 == -1)
								{
									variableByName15.dNumType = Convert.ToDouble(text48);
								}
								else if (num38 != -1)
								{
									((List<string>)variableByName15.VarArray[num37])[num38] = text48;
								}
								else
								{
									variableByName15.VarArray[num37] = text48;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Player Property Value " + text48 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
					{
						string text39 = this.m_d.PerformTextReplacements(text3, null);
						string[] array12 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array12.Length != 2)
						{
							break;
						}
						string text40 = array12[0];
						string text41 = array12[1];
						Room room8 = null;
						room8 = ((!(text40 == "<CurrentRoom>")) ? this.m_d.GetRoomByName(text40) : this.m_d.ThePlayer.CurrentRoom);
						if (room8 == null)
						{
							break;
						}
						for (int num32 = 0; num32 < room8.CustomProperties.Count; num32++)
						{
							CustomProperty A_13 = room8.CustomProperties[num32];
							if (A_13 != null && A_13.Name == text41)
							{
								if (command.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
								{
									object result9 = null;
									SaveLoad.EvaluateString(ref result9, text39);
									text39 = result9.ToString();
								}
								a(ref A_13, text2, text39);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
					{
						string text30 = this.m_d.PerformTextReplacements(text3, null);
						string[] array9 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array9.Length != 2)
						{
							break;
						}
						string timername2 = array9[0];
						string text31 = array9[1];
						Rags.Timer timer2 = null;
						timer2 = this.m_d.GetTimerByName(timername2);
						if (timer2 == null)
						{
							break;
						}
						for (int num31 = 0; num31 < timer2.CustomProperties.Count; num31++)
						{
							CustomProperty A_9 = timer2.CustomProperties[num31];
							if (A_9 != null && A_9.Name == text31)
							{
								if (command.cmdtype == Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS)
								{
									object result8 = null;
									SaveLoad.EvaluateString(ref result8, text30);
									text30 = result8.ToString();
								}
								a(ref A_9, text2, text30);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
					{
						string text28 = this.m_d.PerformTextReplacements(text3, null);
						string[] array8 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array8.Length != 2)
						{
							break;
						}
						string varname2 = array8[0];
						string text29 = array8[1];
						GameVariable gameVariable3 = null;
						gameVariable3 = this.m_d.GetVariableByName(varname2);
						if (gameVariable3 == null)
						{
							break;
						}
						for (int num30 = 0; num30 < gameVariable3.CustomProperties.Count; num30++)
						{
							CustomProperty A_8 = gameVariable3.CustomProperties[num30];
							if (A_8 != null && A_8.Name == text29)
							{
								if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS)
								{
									object result7 = null;
									SaveLoad.EvaluateString(ref result7, text28);
									text28 = result7.ToString();
								}
								a(ref A_8, text2, text28);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
					{
						string text24 = this.m_d.PerformTextReplacements(text3, null);
						string[] array6 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array6.Length != 2)
						{
							break;
						}
						string text25 = array6[0];
						string text26 = array6[1];
						GameObject gameObject7 = null;
						if (text25 == "<Self>")
						{
							if (A_1 != null)
							{
								gameObject7 = A_1;
							}
						}
						else
						{
							gameObject7 = this.m_d.GetObjectByNameOld(text25);
						}
						if (gameObject7 == null)
						{
							break;
						}
						for (int num28 = 0; num28 < gameObject7.CustomProperties.Count; num28++)
						{
							CustomProperty A_7 = gameObject7.CustomProperties[num28];
							if (A_7 != null && A_7.Name == text26)
							{
								if (command.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
								{
									object result5 = null;
									SaveLoad.EvaluateString(ref result5, text24);
									text24 = result5.ToString();
								}
								a(ref A_7, text2, text24);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
					{
						string text17 = this.m_d.PerformTextReplacements(text3, null);
						string[] array4 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array4.Length != 2)
						{
							break;
						}
						string charname = array4[0];
						string text18 = array4[1];
						Character character2 = null;
						character2 = this.m_d.GetCharacterByName(charname);
						if (character2 == null)
						{
							break;
						}
						for (int num23 = 0; num23 < character2.CustomProperties.Count; num23++)
						{
							CustomProperty A_6 = character2.CustomProperties[num23];
							if (A_6 != null && A_6.Name == text18)
							{
								if (command.cmdtype == Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS)
								{
									object result4 = null;
									SaveLoad.EvaluateString(ref result4, text17);
									text17 = result4.ToString();
								}
								a(ref A_6, text2, text17);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
					{
						string text15 = this.m_d.PerformTextReplacements(text3, null);
						string text16 = text;
						for (int num22 = 0; num22 < this.m_d.ThePlayer.CustomProperties.Count; num22++)
						{
							CustomProperty A_5 = this.m_d.ThePlayer.CustomProperties[num22];
							if (A_5 != null && A_5.Name == text16)
							{
								if (command.cmdtype == Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS)
								{
									object result3 = null;
									SaveLoad.EvaluateString(ref result3, text15);
									text15 = result3.ToString();
								}
								a(ref A_5, text2, text15);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETVARIABLE:
					case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
					{
						bool flag2 = false;
						if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
						{
							flag2 = true;
						}
						bool flag3 = false;
						int num7 = text.IndexOf("Array:");
						if (num7 > -1)
						{
							flag3 = true;
							text = text.Remove(num7, 6);
						}
						GameVariable variableByName4 = this.m_d.GetVariableByName(text);
						if (variableByName4 == null)
						{
							break;
						}
						int num8 = d(text);
						int num9 = c(text);
						string text8 = this.m_d.PerformTextReplacements(text3, null);
						text4 = this.m_d.PerformTextReplacements(text4, null);
						object result2 = null;
						if (flag2)
						{
							text8 = text8.Replace("</br>", "").Replace("<br/>", "");
							text8 = text8.Replace("</br>", "").Replace("<br/>", "");
							SaveLoad.EvaluateString(ref result2, text8);
							if (!flag3 && result2 != null)
							{
								text8 = result2.ToString();
							}
						}
						switch (variableByName4.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (text2)
							{
							case "Equals":
								if (flag3)
								{
									a(variableByName4, ref result2);
								}
								else if (num8 == -1)
								{
									variableByName4.dtDateTime = Convert.ToDateTime(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = text8;
								}
								else
								{
									variableByName4.VarArray[num8] = Convert.ToDateTime(text8);
								}
								break;
							case "Add Days":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddDays(Convert.ToInt32(text8));
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = Convert.ToDateTime(((List<string>)variableByName4.VarArray[num8])[num9]).AddDays(Convert.ToInt32(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = ((DateTime)variableByName4.VarArray[num8]).AddDays(Convert.ToInt32(text8));
								}
								break;
							case "Add Hours":
							{
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8));
									break;
								}
								if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8)).ToString();
									break;
								}
								List<object> varArray = variableByName4.VarArray;
								object value = (variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8)));
								varArray[num8] = value;
								break;
							}
							case "Add Minutes":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8));
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8));
								}
								break;
							case "Add Seconds":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8));
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8));
								}
								break;
							case "Subtract Days":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddDays(Convert.ToInt32(text8) * -1);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddDays(Convert.ToInt32(text8) * -1).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddDays(Convert.ToInt32(text8) * -1);
								}
								break;
							case "Subtract Hours":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8) * -1);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8) * -1).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddHours(Convert.ToInt32(text8) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8) * -1);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8) * -1).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddMinutes(Convert.ToInt32(text8) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8) * -1);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8) * -1).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = variableByName4.dtDateTime.AddSeconds(Convert.ToInt32(text8) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, Convert.ToInt32(text8), variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, Convert.ToInt32(text8), variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, Convert.ToInt32(text8), variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, Convert.ToInt32(text8), variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, Convert.ToInt32(text8), variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, Convert.ToInt32(text8), variableByName4.dtDateTime.Minute, variableByName4.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, Convert.ToInt32(text8), variableByName4.dtDateTime.Second);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, Convert.ToInt32(text8), variableByName4.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, Convert.ToInt32(text8), variableByName4.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num8 == -1)
								{
									variableByName4.dtDateTime = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, Convert.ToInt32(text8));
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, Convert.ToInt32(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = new DateTime(variableByName4.dtDateTime.Year, variableByName4.dtDateTime.Month, variableByName4.dtDateTime.Day, variableByName4.dtDateTime.Hour, variableByName4.dtDateTime.Minute, Convert.ToInt32(text8));
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							switch (text2)
							{
							case "Equals":
								if (flag3)
								{
									a(variableByName4, ref result2);
								}
								else if (num8 == -1)
								{
									variableByName4.dNumType = Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = text8;
								}
								else
								{
									variableByName4.VarArray[num8] = Convert.ToDouble(text8);
								}
								break;
							case "Add":
								if (num8 == -1)
								{
									variableByName4.dNumType += Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) + Convert.ToDouble(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = (double)variableByName4.VarArray[num8] + Convert.ToDouble(text8);
								}
								break;
							case "Subtract":
								if (num8 == -1)
								{
									variableByName4.dNumType -= Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) - Convert.ToDouble(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = (double)variableByName4.VarArray[num8] - Convert.ToDouble(text8);
								}
								break;
							case "Multiply":
								if (num8 == -1)
								{
									variableByName4.dNumType *= Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) * Convert.ToDouble(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = (double)variableByName4.VarArray[num8] * Convert.ToDouble(text8);
								}
								break;
							case "Divide":
								if (num8 == -1)
								{
									variableByName4.dNumType /= Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) / Convert.ToDouble(text8)).ToString();
								}
								else
								{
									variableByName4.VarArray[num8] = (double)variableByName4.VarArray[num8] / Convert.ToDouble(text8);
								}
								break;
							}
							if (!variableByName4.bEnforceRestrictions)
							{
								break;
							}
							if (num8 == -1)
							{
								if (variableByName4.dNumType < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMin, null)))
								{
									variableByName4.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMin, null));
								}
								if (variableByName4.dNumType > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMax, null)))
								{
									variableByName4.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMax, null));
								}
							}
							else if (num9 != -1)
							{
								if (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMin, null)))
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = this.m_d.PerformTextReplacements(variableByName4.dMin, null).ToString();
								}
								if (Convert.ToDouble(((List<string>)variableByName4.VarArray[num8])[num9]) > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMax, null)))
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = this.m_d.PerformTextReplacements(variableByName4.dMax, null).ToString();
								}
							}
							else
							{
								if ((double)variableByName4.VarArray[num8] < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMin, null)))
								{
									variableByName4.VarArray[num8] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMin, null));
								}
								if ((double)variableByName4.VarArray[num8] > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMax, null)))
								{
									variableByName4.VarArray[num8] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName4.dMax, null));
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (flag2)
							{
								text4 = text4.Replace("</br>", "");
								text4 = text4.Replace("</br>", "");
								SaveLoad.EvaluateString(ref result2, text4);
								if (!flag3 && result2 != null)
								{
									text4 = result2.ToString();
								}
							}
							if (flag3)
							{
								a(variableByName4, ref result2);
							}
							else if (num8 == -1)
							{
								variableByName4.sString = text4;
							}
							else if (num9 != -1)
							{
								((List<string>)variableByName4.VarArray[num8])[num9] = text4;
							}
							else
							{
								variableByName4.VarArray[num8] = text4;
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
					{
						GameVariable variableByName5 = this.m_d.GetVariableByName(text);
						GameVariable variableByName6 = this.m_d.GetVariableByName(text3);
						int num13 = d(text3);
						int num14 = c(text3);
						int num15 = 0;
						double num16 = 0.0;
						if (num13 == -1)
						{
							num15 = Convert.ToInt32(variableByName6.dNumType);
							num16 = Convert.ToDouble(variableByName6.dNumType);
						}
						else if (num14 != -1)
						{
							num15 = Convert.ToInt32(((List<string>)variableByName6.VarArray[num13])[num14]);
							num16 = Convert.ToDouble(((List<string>)variableByName6.VarArray[num13])[num14]);
						}
						else
						{
							num15 = Convert.ToInt32((double)variableByName6.VarArray[num13]);
							num16 = Convert.ToDouble((double)variableByName6.VarArray[num13]);
						}
						num13 = d(text);
						int num17 = c(text);
						if (variableByName5 == null)
						{
							break;
						}
						switch (variableByName5.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (text2)
							{
							case "Equals":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = Convert.ToDateTime(num15);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = num15.ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = Convert.ToDateTime(num15);
								}
								break;
							case "Add Days":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15));
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15)).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15));
								}
								break;
							case "Add Hours":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15));
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15)).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15));
								}
								break;
							case "Add Minutes":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15));
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15)).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15));
								}
								break;
							case "Add Seconds":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15));
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15)).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15));
								}
								break;
							case "Subtract Days":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15) * -1);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15) * -1).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddDays(Convert.ToInt32(num15) * -1);
								}
								break;
							case "Subtract Hours":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15) * -1);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15) * -1).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddHours(Convert.ToInt32(num15) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15) * -1);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15) * -1).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddMinutes(Convert.ToInt32(num15) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15) * -1);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15) * -1).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = variableByName5.dtDateTime.AddSeconds(Convert.ToInt32(num15) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, Convert.ToInt32(num15), variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, Convert.ToInt32(num15), variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, Convert.ToInt32(num15), variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, Convert.ToInt32(num15), variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, Convert.ToInt32(num15), variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, Convert.ToInt32(num15), variableByName5.dtDateTime.Minute, variableByName5.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, Convert.ToInt32(num15), variableByName5.dtDateTime.Second);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, Convert.ToInt32(num15), variableByName5.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, Convert.ToInt32(num15), variableByName5.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num13 == -1)
								{
									variableByName5.dtDateTime = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, Convert.ToInt32(num15));
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, Convert.ToInt32(num15)).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = new DateTime(variableByName5.dtDateTime.Year, variableByName5.dtDateTime.Month, variableByName5.dtDateTime.Day, variableByName5.dtDateTime.Hour, variableByName5.dtDateTime.Minute, Convert.ToInt32(num15));
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							switch (text2)
							{
							case "Equals":
								if (num13 == -1)
								{
									variableByName5.dNumType = num16;
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = num15.ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = num16;
								}
								break;
							case "Add":
								if (num13 == -1)
								{
									variableByName5.dNumType += num16;
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = ((double)variableByName5.VarArray[num13] + num16).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = (double)variableByName5.VarArray[num13] + num16;
								}
								break;
							case "Subtract":
								if (num13 == -1)
								{
									variableByName5.dNumType -= num16;
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = ((double)variableByName5.VarArray[num13] - num16).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = (double)variableByName5.VarArray[num13] - num16;
								}
								break;
							case "Multiply":
								if (num13 == -1)
								{
									variableByName5.dNumType *= Convert.ToDouble(num16);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = ((double)variableByName5.VarArray[num13] * num16).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = (double)variableByName5.VarArray[num13] * num16;
								}
								break;
							case "Divide":
								if (num13 == -1)
								{
									variableByName5.dNumType /= Convert.ToDouble(num15);
								}
								else if (num17 != -1)
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = ((double)variableByName5.VarArray[num13] / num16).ToString();
								}
								else
								{
									variableByName5.VarArray[num13] = (double)variableByName5.VarArray[num13] / num16;
								}
								break;
							}
							if (!variableByName5.bEnforceRestrictions)
							{
								break;
							}
							if (num13 == -1)
							{
								if (variableByName5.dNumType < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMin, null)))
								{
									variableByName5.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMin, null));
								}
								if (variableByName5.dNumType > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMax, null)))
								{
									variableByName5.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMax, null));
								}
							}
							else if (num17 != -1)
							{
								double num18 = Convert.ToDouble(((List<string>)variableByName5.VarArray[num13])[num17]);
								if (num18 < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMin, null)))
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = this.m_d.PerformTextReplacements(variableByName5.dMin, null);
								}
								if (num18 > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMax, null)))
								{
									((List<string>)variableByName5.VarArray[num13])[num17] = this.m_d.PerformTextReplacements(variableByName5.dMax, null);
								}
							}
							else
							{
								if ((double)variableByName5.VarArray[num13] < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMin, null)))
								{
									variableByName5.VarArray[num13] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMin, null));
								}
								if ((double)variableByName5.VarArray[num13] > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMax, null)))
								{
									variableByName5.VarArray[num13] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName5.dMax, null));
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							break;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYVARIABLE:
					{
						GameVariable variableByName2 = this.m_d.GetVariableByName(text);
						int num3 = d(text);
						int num4 = c(text);
						if (variableByName2 == null)
						{
							break;
						}
						switch (variableByName2.vartype)
						{
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (num3 == -1)
							{
								break;
							}
							switch (text2)
							{
							case "Display Date & Time":
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName2.VarArray[num3])[num4].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName2.VarArray[num3]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") + "</br>");
								}
								break;
							case "Display Date Only":
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName2.VarArray[num3])[num4]).ToString("dddd, MMMM, dd yyyy") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName2.VarArray[num3]).ToString("dddd, MMMM, dd yyyy") + "</br>");
								}
								break;
							case "Display Time Only":
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName2.VarArray[num3])[num4]).ToString("hh:mm:ss tt") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName2.VarArray[num3]).ToString("hh:mm:ss tt") + "</br>");
								}
								break;
							case "Display Weekday Only":
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName2.VarArray[num3])[num4]).ToString("dddd") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName2.VarArray[num3]).ToString("dddd") + "</br>");
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							switch (text2)
							{
							case "Display Date & Time":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") + "</br>");
								break;
							case "Display Date Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy") + "</br>");
								break;
							case "Display Time Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.dtDateTime.ToString("hh:mm:ss tt") + "</br>");
								break;
							case "Display Weekday Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.dtDateTime.ToString("dddd") + "</br>");
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (num3 != -1)
							{
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName2.VarArray[num3])[num4].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, (double)variableByName2.VarArray[num3] + "</br>");
								}
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.dNumType + "</br>");
							break;
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num3 != -1)
							{
								if (num4 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName2.VarArray[num3])[num4].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.VarArray[num3].ToString() + "</br>");
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName2.sString + "</br>");
							break;
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SETPORT:
					{
						Character character5 = null;
						character5 = this.m_d.GetCharacterByName(text);
						if (character5 != null)
						{
							character5.CharPortrait = text2;
						}
						break;
					}
					case Command.CommandType.CT_SETROOMPIC:
					{
						Room room11 = null;
						if (text == Room.CurrentRoomGuid.ToString())
						{
							room11 = this.m_d.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room11 = this.m_d.GetRoomByID(new Guid(text));
							}
							catch
							{
								room11 = this.m_d.GetRoomByName(text);
							}
						}
						if (room11 == null)
						{
							break;
						}
						room11.RoomPic = text2;
						if (room11 == this.m_d.ThePlayer.CurrentRoom)
						{
							if (this.m_d.bHideMainPicDisplay)
							{
								_ = this.m_d.bUseInlineImages;
							}
							if (!this.m_d.bHideMainPicDisplay)
							{
								this.w.Source = new Uri(SaveLoad.GetPictureByName(room11.RoomPic, ref this.m_d) as string);
							}
						}
						break;
					}
					case Command.CommandType.CT_SETROOMLAYEREDPIC:
					{
						Room room9 = null;
						if (text == Room.CurrentRoomGuid.ToString())
						{
							room9 = this.m_d.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room9 = this.m_d.GetRoomByID(new Guid(text));
							}
							catch
							{
								room9 = this.m_d.GetRoomByName(text);
							}
						}
						if (room9 == null)
						{
							break;
						}
						if (text2 == "<None>")
						{
							text2 = "";
						}
						room9.LayeredRoomPic = text2;
						if (room9 == this.m_d.ThePlayer.CurrentRoom)
						{
							if (this.m_d.bHideMainPicDisplay)
							{
								_ = this.m_d.bUseInlineImages;
							}
							if (!this.m_d.bHideMainPicDisplay)
							{
								this.w.Source = new Uri(SaveLoad.GetPictureByName(room9.LayeredRoomPic, ref this.m_d) as string);
							}
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERPORTRAIT:
						this.m_d.ThePlayer.PlayerPortrait = text;
						a(text, A_1: false);
						break;
					case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
						if (text == "<None>")
						{
							text = "";
						}
						this.m_d.ThePlayer.PlayerLayeredImage = text;
						a(text, A_1: true);
						break;
					case Command.CommandType.CT_DISPLAYPICTURE:
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							object pictureByName3 = SaveLoad.GetPictureByName(text, ref this.m_d);
							this.w.Source = new Uri(pictureByName3 as string);
						}
						break;
					case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
					{
						object pictureByName = SaveLoad.GetPictureByName(text, ref this.m_d);
						bc.Source = new Uri(pictureByName as string);
						break;
					}
					case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
						bc.Stop();
						break;
					case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
					{
						object pictureByName2 = SaveLoad.GetPictureByName(text, ref this.m_d);
						bd.Source = new Uri(pictureByName2 as string);
						break;
					}
					case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							this.w.Source = new Uri(SaveLoad.GetPictureByName(text, ref this.m_d) as string);
						}
						break;
					case Command.CommandType.CT_SETOBJECTACTION:
					{
						GameObject gameObject6 = null;
						if (text == "00000000-0000-0000-0000-000000000004")
						{
							if (A_1 != null)
							{
								gameObject6 = A_1;
							}
						}
						else
						{
							gameObject6 = this.m_d.GetObjectByName(text);
							if (gameObject6 == null)
							{
								gameObject6 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject6 == null)
						{
							break;
						}
						string actionname4 = text2.Substring(0, text2.LastIndexOf('-'));
						string text23 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName4 = gameObject6.GetActionByName(actionname4);
						if (actionByName4 != null)
						{
							if (text23 == "Active")
							{
								actionByName4.bActive = true;
							}
							else
							{
								actionByName4.bActive = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETCHARACTION:
					{
						Character characterByName3 = this.m_d.GetCharacterByName(text);
						if (characterByName3 == null)
						{
							break;
						}
						string actionname3 = text2.Substring(0, text2.LastIndexOf('-'));
						string text22 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName3 = characterByName3.GetActionByName(actionname3);
						if (actionByName3 != null)
						{
							if (text22 == "Active")
							{
								actionByName3.bActive = true;
							}
							else
							{
								actionByName3.bActive = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_GENDER:
					{
						Character characterByName2 = this.m_d.GetCharacterByName(text);
						if (characterByName2 != null)
						{
							characterByName2.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), text2);
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_NAME:
					{
						Character characterByName = this.m_d.GetCharacterByName(text);
						if (characterByName != null)
						{
							characterByName.CharnameOverride = text3;
						}
						break;
					}
					case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
					{
						Room room5 = null;
						try
						{
							room5 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room5 = this.m_d.GetRoomByName(text);
						}
						if (room5 != null)
						{
							room5.SDesc = text3;
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
					{
						GameObject gameObject2 = null;
						try
						{
							new Guid(text);
							gameObject2 = this.m_d.GetObjectByName(text);
						}
						catch
						{
							gameObject2 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject2 != null)
						{
							gameObject2.sdesc = text3;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERACTION:
					{
						if (this.m_d.ThePlayer == null)
						{
							break;
						}
						string actionname2 = text2.Substring(0, text2.LastIndexOf('-'));
						string text14 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName2 = this.m_d.ThePlayer.GetActionByName(actionname2);
						if (actionByName2 != null)
						{
							if (text14 == "Active")
							{
								actionByName2.bActive = true;
							}
							else
							{
								actionByName2.bActive = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETROOMACTION:
					{
						Room room2 = null;
						try
						{
							room2 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room2 = this.m_d.GetRoomByName(text);
						}
						if (room2 == null)
						{
							break;
						}
						string actionname = text2.Substring(0, text2.LastIndexOf('-'));
						string text5 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName = room2.GetActionByName(actionname);
						if (actionByName != null)
						{
							if (text5 == "Active")
							{
								actionByName.bActive = true;
							}
							else
							{
								actionByName.bActive = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETLOCKEDUNLOCKED:
					{
						GameObject gameObject18 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject18 = A_1;
							}
						}
						else
						{
							gameObject18 = this.m_d.GetObjectByName(text);
							if (gameObject18 == null)
							{
								gameObject18 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject18 != null)
						{
							if (text2 == "Locked")
							{
								gameObject18.bLocked = true;
							}
							else
							{
								gameObject18.bLocked = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETOPENCLOSED:
					{
						GameObject gameObject16 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject16 = A_1;
							}
						}
						else
						{
							gameObject16 = this.m_d.GetObjectByName(text);
							if (gameObject16 == null)
							{
								gameObject16 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject16 != null)
						{
							if (text2 == "Open")
							{
								gameObject16.bOpen = true;
							}
							else
							{
								gameObject16.bOpen = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETITEMTOWORN:
					{
						GameObject gameObject12 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject12 = A_1;
							}
						}
						else
						{
							gameObject12 = this.m_d.GetObjectByName(text);
							if (gameObject12 == null)
							{
								gameObject12 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject12 != null)
						{
							if (text2 == "Worn")
							{
								gameObject12.bWorn = true;
							}
							else
							{
								gameObject12.bWorn = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYCHARDESC:
					{
						Character characterByName7 = this.m_d.GetCharacterByName(text);
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, characterByName7.Description + "</br>");
						bool flag11 = false;
						if (this.m_d.bTurnOffNotifications)
						{
							break;
						}
						foreach (GameObject object9 in this.m_d.ObjectList)
						{
							if (object9.locationtype == GameObject.LocationType.LT_CHARACTER && object9.locationname == text && object9.bWorn && object9.bVisible)
							{
								if (!flag11)
								{
									flag11 = true;
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, characterByName7.ToString() + " is wearing:</br>");
								}
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, object9.GetDisplayString() + "</br>");
							}
						}
						flag11 = false;
						foreach (GameObject object10 in this.m_d.ObjectList)
						{
							if (object10.locationtype == GameObject.LocationType.LT_CHARACTER && object10.locationname == text && !object10.bWorn && object10.bVisible)
							{
								if (!flag11)
								{
									flag11 = true;
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, characterByName7.ToString() + " is carrying:</br>");
								}
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, object10.GetDisplayString() + "</br>");
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVECHAR:
					{
						Character characterByName6 = this.m_d.GetCharacterByName(text);
						if (characterByName6 == null)
						{
							break;
						}
						if (characterByName6.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString())
						{
							Rags.Action A_10 = characterByName6.GetActionByName("<<On Character Leave>>");
							if (A_10 != null)
							{
								a(ref A_10, null);
							}
						}
						string text34 = string.Empty;
						try
						{
							new Guid(text2);
							text34 = text2;
						}
						catch
						{
							Room roomByName = this.m_d.GetRoomByName(text2);
							if (roomByName != null)
							{
								text34 = roomByName.UniqueID.ToString();
								text2 = text34;
							}
						}
						if (text2 == Room.CurrentRoomGuid.ToString())
						{
							characterByName6.CurrentRoom = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
							Rags.Action A_11 = characterByName6.GetActionByName("<<On Character Enter>>");
							if (A_11 != null)
							{
								a(ref A_11, null);
							}
						}
						else if (text2 == Room.VoidRoomGuid.ToString())
						{
							this.m_d.GetCharacterByName(text).CurrentRoom = Room.VoidRoomGuid.ToString();
						}
						else
						{
							try
							{
								new Guid(text2);
								text34 = text2;
							}
							catch
							{
								Room roomByName2 = this.m_d.GetRoomByName(text2);
								if (roomByName2 != null)
								{
									text34 = roomByName2.UniqueID.ToString();
								}
							}
							if (text34 == string.Empty)
							{
								MessageBox.Show("Error in command CT_MoveChar.  Could not locate a room called " + text2);
								break;
							}
							this.m_d.GetCharacterByName(text).CurrentRoom = text34;
							if (text2 == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString())
							{
								Rags.Action A_12 = characterByName6.GetActionByName("<<On Character Enter>>");
								if (A_12 != null)
								{
									a(ref A_12, null);
								}
							}
						}
						v();
						break;
					}
					case Command.CommandType.CT_MOVEPLAYER:
						try
						{
							this.m_d.ThePlayer.CurrentRoom = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							this.m_d.ThePlayer.CurrentRoom = this.m_d.GetRoomByName(text);
						}
						if (this.m_d.ThePlayer.CurrentRoom != null)
						{
							a(A_0: false, A_1: true);
						}
						break;
					case Command.CommandType.CT_MOVETOCHAR:
						try
						{
							Character characterByName5 = this.m_d.GetCharacterByName(text);
							if (characterByName5 != null)
							{
								if (characterByName5.CurrentRoom != Room.VoidRoomGuid.ToString() && characterByName5.CurrentRoom != Room.CurrentRoomGuid.ToString())
								{
									this.m_d.ThePlayer.CurrentRoom = this.m_d.GetRoomByID(new Guid(characterByName5.CurrentRoom));
								}
								if (this.m_d.ThePlayer.CurrentRoom != null)
								{
									a(A_0: false, A_1: true);
								}
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_MOVETOOBJ:
						try
						{
							GameObject objectByName2 = this.m_d.GetObjectByName(text);
							if (objectByName2 != null)
							{
								if (objectByName2.locationtype == GameObject.LocationType.LT_ROOM)
								{
									this.m_d.ThePlayer.CurrentRoom = this.m_d.GetRoomByID(new Guid(objectByName2.locationname));
								}
								if (this.m_d.ThePlayer.CurrentRoom != null)
								{
									a(A_0: false, A_1: true);
								}
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_CHAR_MOVETOOBJ:
						try
						{
							Character characterByName4 = this.m_d.GetCharacterByName(text);
							GameObject objectByName = this.m_d.GetObjectByName(text2);
							if (objectByName != null && characterByName4 != null)
							{
								if (objectByName.locationtype == GameObject.LocationType.LT_ROOM)
								{
									characterByName4.CurrentRoom = objectByName.locationname;
								}
								if (this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() == objectByName.locationname)
								{
									a(A_0: false, A_1: false);
								}
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_SETCHARDESC:
						this.m_d.GetCharacterByName(text).Description = text4;
						break;
					case Command.CommandType.CT_SETROOMDESCRIPTION:
					{
						Room room7 = null;
						if (text == Room.CurrentRoomGuid.ToString())
						{
							room7 = this.m_d.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room7 = this.m_d.GetRoomByID(new Guid(text));
							}
							catch
							{
								room7 = this.m_d.GetRoomByName(text);
							}
						}
						if (room7 != null)
						{
							room7.Description = text4;
						}
						break;
					}
					case Command.CommandType.CT_JAVA_SET_RAGS:
					{
						text4 = this.m_d.PerformTextReplacements(text4, null);
						object result6 = null;
						SaveLoad.EvaluateString(ref result6, text4);
						a(ref result6);
						break;
					}
					case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
					{
						AdditionalInputWindow additionalInputWindow2 = null;
						Rags.Action.ActionInputType actionInputType2 = Rags.Action.ActionInputType.None;
						if (text.Equals("Text"))
						{
							actionInputType2 = Rags.Action.ActionInputType.Text;
						}
						else if (text.Equals("Custom"))
						{
							actionInputType2 = Rags.Action.ActionInputType.Custom;
						}
						bool flag4 = false;
						if (actionInputType2 == Rags.Action.ActionInputType.Custom)
						{
							ListBox inv2 = new ListBox();
							foreach (string customChoice2 in command.CustomChoices)
							{
								((ItemsControl)inv2).Items.Add((object)this.m_d.PerformTextReplacements(customChoice2, null));
							}
							additionalInputWindow2 = new AdditionalInputWindow(actionInputType2, ref inv2, ref a7, ref a9);
							((Window)additionalInputWindow2).Owner = (Window)(object)this;
						}
						else
						{
							additionalInputWindow2 = new AdditionalInputWindow(actionInputType2, ref bb, ref a7, ref a9);
							((Window)additionalInputWindow2).Owner = (Window)(object)this;
						}
						if (additionalInputWindow2 != null)
						{
							((ContentControl)additionalInputWindow2.d).Content = this.m_d.PerformTextReplacements(text3, null);
							((UIElement)additionalInputWindow2.h).IsEnabled = command.EnhInputData.bAllowCancel;
						}
						bool flag5 = false;
						while (!flag5)
						{
							Point val5 = ((UIElement)this.v).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this);
							val5 = ((Visual)this).PointToScreen(val5);
							((Window)additionalInputWindow2).Left = val5.X;
							((Window)additionalInputWindow2).Top = val5.Y;
							((FrameworkElement)additionalInputWindow2).Height = ((FrameworkElement)this.v).ActualHeight;
							((FrameworkElement)additionalInputWindow2).Width = ((FrameworkElement)this.v).ActualWidth;
							DoubleAnimation val6 = new DoubleAnimation();
							val6.From = 0.0;
							val6.To = 1.0;
							((Timeline)val6).Duration = new Duration(TimeSpan.FromSeconds(0.5));
							((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
							{
							}));
							object obj14 = this.y.InvokeScript("atbottom");
							bool flag6 = Convert.ToBoolean(obj14.ToString());
							while (!flag6)
							{
								((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
								{
								}));
								flag6 = Convert.ToBoolean(obj14.ToString());
							}
							((UIElement)additionalInputWindow2).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val6);
							bool? flag7 = ((Window)additionalInputWindow2).ShowDialog();
							string empty3 = string.Empty;
							empty3 = ((actionInputType2 != Rags.Action.ActionInputType.Custom) ? additionalInputWindow2.e.Text : ((Selector)additionalInputWindow2.f).SelectedItem.ToString());
							if (flag7 == true)
							{
								try
								{
									Convert.ToDouble(empty3);
									flag5 = true;
								}
								catch
								{
									MessageBox.Show("Sorry, you must enter a valid number.");
									flag5 = false;
								}
							}
							else if (flag7 != true)
							{
								return false;
							}
						}
						GameVariable variableByName11 = this.m_d.GetVariableByName(text2);
						int num26 = d(text2);
						int num27 = c(text2);
						if (variableByName11 == null)
						{
							break;
						}
						switch (actionInputType2)
						{
						case Rags.Action.ActionInputType.Custom:
						{
							string empty4 = string.Empty;
							variableByName11.sString = string.Empty;
							if (empty4 != string.Empty)
							{
								if (num26 == -1)
								{
									variableByName11.dNumType = a(variableByName11, empty4);
								}
								else if (num27 != -1)
								{
									((List<string>)variableByName11.VarArray[num26])[num27] = string.Empty;
									((List<string>)variableByName11.VarArray[num26])[num27] = a(variableByName11, empty4).ToString();
								}
								else
								{
									variableByName11.VarArray[num26] = string.Empty;
									variableByName11.VarArray[num26] = a(variableByName11, empty4).ToString();
								}
							}
							break;
						}
						case Rags.Action.ActionInputType.Text:
							if (num26 == -1)
							{
								variableByName11.dNumType = a(variableByName11, additionalInputWindow2.e.Text);
							}
							else if (num27 != -1)
							{
								((List<string>)variableByName11.VarArray[num26])[num27] = a(variableByName11, additionalInputWindow2.e.Text).ToString();
							}
							else
							{
								variableByName11.VarArray[num26] = a(variableByName11, additionalInputWindow2.e.Text).ToString();
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_SETVARIABLEBYINPUT:
					{
						AdditionalInputWindow additionalInputWindow = null;
						Rags.Action.ActionInputType actionInputType = Rags.Action.ActionInputType.None;
						if (text.Equals("Text"))
						{
							actionInputType = Rags.Action.ActionInputType.Text;
						}
						else if (text.Equals("Characters"))
						{
							actionInputType = Rags.Action.ActionInputType.Character;
						}
						else if (text.Equals("Characters And Objects"))
						{
							actionInputType = Rags.Action.ActionInputType.ObjectOrCharacter;
						}
						else if (text.Equals("Objects"))
						{
							actionInputType = Rags.Action.ActionInputType.Object;
						}
						else if (text.Equals("Custom"))
						{
							actionInputType = Rags.Action.ActionInputType.Custom;
						}
						else if (text.Equals("Inventory"))
						{
							actionInputType = Rags.Action.ActionInputType.Inventory;
						}
						if (actionInputType == Rags.Action.ActionInputType.Custom)
						{
							ListBox inv = new ListBox();
							foreach (string customChoice3 in command.CustomChoices)
							{
								((ItemsControl)inv).Items.Add((object)this.m_d.PerformTextReplacements(customChoice3, null));
							}
							additionalInputWindow = new AdditionalInputWindow(actionInputType, ref inv, ref a7, ref a9);
							((Window)additionalInputWindow).Owner = (Window)(object)this;
						}
						else
						{
							additionalInputWindow = new AdditionalInputWindow(actionInputType, ref bb, ref a7, ref a9);
							((Window)additionalInputWindow).Owner = (Window)(object)this;
						}
						if (additionalInputWindow != null)
						{
							((ContentControl)additionalInputWindow.d).Content = this.m_d.PerformTextReplacements(text3, null);
							((UIElement)additionalInputWindow.h).IsEnabled = false;
						}
						Point val = ((UIElement)this.v).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this);
						((Window)additionalInputWindow).Owner = (Window)(object)this;
						val = ((Visual)this).PointToScreen(val);
						((Window)additionalInputWindow).Left = val.X;
						((Window)additionalInputWindow).Top = val.Y;
						((FrameworkElement)additionalInputWindow).Height = ((FrameworkElement)this.v).ActualHeight;
						((FrameworkElement)additionalInputWindow).Width = ((FrameworkElement)this.v).ActualWidth;
						DoubleAnimation val2 = new DoubleAnimation();
						val2.From = 0.0;
						val2.To = 1.0;
						((Timeline)val2).Duration = new Duration(TimeSpan.FromSeconds(0.5));
						((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
						{
						}));
						object obj = this.y.InvokeScript("atbottom");
						bool flag = Convert.ToBoolean(obj.ToString());
						while (!flag)
						{
							((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
							{
							}));
							flag = Convert.ToBoolean(obj.ToString());
						}
						((UIElement)additionalInputWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val2);
						if (((Window)additionalInputWindow).ShowDialog() != true)
						{
							return false;
						}
						GameVariable variableByName = this.m_d.GetVariableByName(text2);
						int num = d(text2);
						int num2 = c(text2);
						if (variableByName == null)
						{
							break;
						}
						switch (actionInputType)
						{
						case Rags.Action.ActionInputType.Object:
						case Rags.Action.ActionInputType.Character:
						case Rags.Action.ActionInputType.ObjectOrCharacter:
						case Rags.Action.ActionInputType.Custom:
						case Rags.Action.ActionInputType.Inventory:
						{
							string empty = string.Empty;
							if (((Selector)additionalInputWindow.f).SelectedItem is GameObject)
							{
								empty = ((GameObject)((Selector)additionalInputWindow.f).SelectedItem).name;
							}
							else
							{
								empty = ((!(((Selector)additionalInputWindow.f).SelectedItem is Character)) ? ((Selector)additionalInputWindow.f).SelectedItem.ToString() : ((Character)((Selector)additionalInputWindow.f).SelectedItem).Charname);
							}
							variableByName.sString = string.Empty;
							if (empty != string.Empty)
							{
								if (num == -1)
								{
									variableByName.sString = empty;
								}
								else if (num2 != -1)
								{
									((List<string>)variableByName.VarArray[num])[num2] = string.Empty;
									((List<string>)variableByName.VarArray[num])[num2] = empty;
								}
								else
								{
									variableByName.VarArray[num] = string.Empty;
									variableByName.VarArray[num] = empty;
								}
							}
							break;
						}
						case Rags.Action.ActionInputType.Text:
							if (num == -1)
							{
								variableByName.sString = additionalInputWindow.e.Text;
							}
							else if (num2 != -1)
							{
								((List<string>)variableByName.VarArray[num])[num2] = additionalInputWindow.e.Text;
							}
							else
							{
								variableByName.VarArray[num] = additionalInputWindow.e.Text;
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_COMMENT:
						break;
					}
				}
				catch
				{
					MessageBox.Show("Rags can not process the command correctly.  Please try running one of the RAGS legacy versions.  This game was created using Rags version " + Game.CurrentObjectVersionNumber + ".  Rags Legacy versions are available at http://www.ragsgame.com/downloads.aspx");
					MessageBox.Show(command.cmdtype.ToString() + ":" + command.CommandPart2 + ":" + command.CommandPart3 + ":" + command.CommandPart4 + ":" + command.CommandText);
				}
			}
		}
		return result;
	}

	private void x()
	{
		GameObject a_ = null;
		((ItemsControl)bb).Items.Clear();
		if (this.m_d == null)
		{
			return;
		}
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_PLAYER && @object.bVisible)
			{
				if (@object.bImportant)
				{
					((ItemsControl)bb).Items.Insert(0, (object)@object);
				}
				else
				{
					((ItemsControl)bb).Items.Add((object)@object);
				}
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref bb, a_);
				}
			}
		}
		for (int num = ((CollectionView)((ItemsControl)bb).Items).Count - 1; num >= 0; num--)
		{
			if (((ItemsControl)bb).Items[num] is GameObject { bImportant: not false } gameObject)
			{
				((ItemsControl)bb).Items.Remove((object)gameObject);
				((ItemsControl)bb).Items.Insert(0, (object)gameObject);
			}
		}
	}

	private void w()
	{
		GameObject a_ = null;
		((ItemsControl)a7).Items.Clear();
		if (this.m_d == null)
		{
			return;
		}
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (this.m_d.ThePlayer.CurrentRoom != null && @object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() && @object.bVisible)
			{
				((ItemsControl)a7).Items.Add((object)@object);
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref a7, a_);
				}
			}
		}
		for (int num = ((CollectionView)((ItemsControl)a7).Items).Count - 1; num >= 0; num--)
		{
			if (((ItemsControl)a7).Items[num] is GameObject { bImportant: not false } gameObject)
			{
				((ItemsControl)a7).Items.Remove((object)gameObject);
				((ItemsControl)a7).Items.Insert(0, (object)gameObject);
			}
		}
		if (this.m_d.ThePlayer.CurrentRoom == null)
		{
			return;
		}
		foreach (Exit exit in this.m_d.ThePlayer.CurrentRoom.Exits)
		{
			if (!(exit.PortalObjectName != "<None>"))
			{
				continue;
			}
			bool flag = false;
			foreach (GameObject item in (IEnumerable)((ItemsControl)a7).Items)
			{
				if (item.name.IndexOf(exit.PortalObjectName) == 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			GameObject gameObject3 = this.m_d.GetObjectByName(exit.PortalObjectName);
			if (gameObject3 == null)
			{
				gameObject3 = this.m_d.GetObjectByNameOld(exit.PortalObjectName);
			}
			if (gameObject3 != null && gameObject3.bVisible)
			{
				((ItemsControl)a7).Items.Add((object)gameObject3);
				if (gameObject3.bContainer && (!gameObject3.bOpenable || gameObject3.bOpen))
				{
					a(gameObject3, ref a7, a_);
				}
			}
		}
	}

	private void v()
	{
		if (this.m_d == null)
		{
			return;
		}
		if (((Selector)a9).SelectedItem != null)
		{
			_ = ((Selector)a9).SelectedItem;
		}
		((ItemsControl)a9).Items.Clear();
		foreach (Character character in this.m_d.CharacterList)
		{
			if (this.m_d.ThePlayer.CurrentRoom == null || !(character.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			((ItemsControl)a9).Items.Add((object)character);
			if (!character.bAllowInventoryInteraction)
			{
				continue;
			}
			foreach (GameObject @object in this.m_d.ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_CHARACTER && @object.locationname == character.Charname && @object.bVisible)
				{
					if (@object.bImportant)
					{
						((ItemsControl)a9).Items.Insert(0, (object)@object);
					}
					else
					{
						((ItemsControl)a9).Items.Add((object)@object);
					}
				}
			}
		}
		for (int num = ((CollectionView)((ItemsControl)a9).Items).Count - 1; num >= 0; num--)
		{
			if (((ItemsControl)a9).Items[num] is GameObject { bImportant: not false } gameObject)
			{
				((ItemsControl)a9).Items.Remove((object)gameObject);
				((ItemsControl)a9).Items.Insert(0, (object)gameObject);
			}
		}
	}

	private bool a(Condition A_0, string A_1, Rags.Action.ActionInputType A_2, GameObject A_3, ref Rags.Action A_4, object A_5)
	{
		//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		int num = 0;
		foreach (Check check in A_0.Checks)
		{
			try
			{
				if (num <= 0)
				{
					goto IL_0044;
				}
				if (check.CkType == CheckType.Or)
				{
					if (flag)
					{
						break;
					}
					goto IL_0044;
				}
				if (check.CkType != CheckType.And || flag)
				{
					goto IL_0044;
				}
				goto end_IL_001e;
				IL_0044:
				num++;
				if (this.m_d == null)
				{
					return false;
				}
				string text = this.m_d.PerformTextReplacements(check.ConditionStep2, A_5);
				string text2 = this.m_d.PerformTextReplacements(check.ConditionStep3, A_5);
				string text3 = this.m_d.PerformTextReplacements(check.ConditionStep4, A_5);
				switch (check.CondType)
				{
				case Condition.ConditionType.CT_Item_InGroup:
					flag = a(text, text2, MainWindow.b.a);
					break;
				case Condition.ConditionType.CT_MultiMedia_InGroup:
					flag = a(text, text2, MainWindow.b.b);
					break;
				case Condition.ConditionType.CT_Item_Held_By_Player:
				{
					GameObject A_6 = this.m_d.GetObjectByName(text);
					if (A_6 == null)
					{
						A_6 = this.m_d.GetObjectByNameOld(text);
					}
					flag = A_6 != null && (A_6.locationtype == GameObject.LocationType.LT_PLAYER || (A_6.locationtype == GameObject.LocationType.LT_IN_OBJECT && a(ref A_6)));
					break;
				}
				case Condition.ConditionType.CT_Player_Moving:
				{
					Exit.Directions directions = (Exit.Directions)Enum.Parse(typeof(Exit.Directions), text);
					flag = this.m_l == directions;
					break;
				}
				case Condition.ConditionType.CT_Player_Gender:
					if (text.Equals("Male"))
					{
						flag = this.m_d.ThePlayer.PlayerGender == Player.Gender.Male;
					}
					else
					{
						flag = ((!text.Equals("Female")) ? (this.m_d.ThePlayer.PlayerGender == Player.Gender.Other) : (this.m_d.ThePlayer.PlayerGender == Player.Gender.Female));
					}
					break;
				case Condition.ConditionType.CT_Character_Gender:
				{
					Character characterByName3 = this.m_d.GetCharacterByName(text);
					if (characterByName3 != null)
					{
						if (text2.Equals("Male"))
						{
							flag = characterByName3.CharGender == Player.Gender.Male;
						}
						else
						{
							flag = ((!text2.Equals("Female")) ? (characterByName3.CharGender == Player.Gender.Other) : (characterByName3.CharGender == Player.Gender.Female));
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Character_In_Room:
				{
					Character characterByName2 = this.m_d.GetCharacterByName(text);
					flag = ((!(text2 == Room.CurrentRoomGuid.ToString())) ? (characterByName2.CurrentRoom == text2) : (characterByName2.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()));
					break;
				}
				case Condition.ConditionType.CT_Character_In_RoomGroup:
				{
					flag = false;
					Character characterByName4 = this.m_d.GetCharacterByName(text);
					Room roomByID2 = this.m_d.GetRoomByID(new Guid(characterByName4.CurrentRoom));
					if (roomByID2 != null && roomByID2.Group == text2)
					{
						flag = true;
					}
					break;
				}
				case Condition.ConditionType.CT_Item_Held_By_Character:
				{
					GameObject gameObject3 = this.m_d.GetObjectByName(text2);
					if (gameObject3 == null)
					{
						gameObject3 = this.m_d.GetObjectByNameOld(text2);
					}
					flag = gameObject3 != null && ((gameObject3.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject3.locationname == text) ? true : false);
					break;
				}
				case Condition.ConditionType.CT_Item_Not_Held_By_Player:
				{
					GameObject gameObject4 = this.m_d.GetObjectByName(text);
					if (gameObject4 == null)
					{
						gameObject4 = this.m_d.GetObjectByNameOld(text);
					}
					flag = gameObject4 != null && gameObject4.locationtype != GameObject.LocationType.LT_PLAYER;
					break;
				}
				case Condition.ConditionType.CT_Item_In_Object:
				{
					GameObject gameObject8 = this.m_d.GetObjectByName(text);
					if (gameObject8 == null)
					{
						gameObject8 = this.m_d.GetObjectByNameOld(text);
					}
					flag = gameObject8 != null && gameObject8.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject8.locationname == text2;
					break;
				}
				case Condition.ConditionType.CT_Item_Not_In_Object:
				{
					GameObject gameObject7 = this.m_d.GetObjectByName(text);
					if (gameObject7 == null)
					{
						gameObject7 = this.m_d.GetObjectByNameOld(text);
					}
					if (gameObject7 != null)
					{
						bool flag2 = gameObject7.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject7.locationname == text2;
						flag = !flag2;
					}
					else
					{
						flag = true;
					}
					break;
				}
				case Condition.ConditionType.CT_Item_In_Room:
					if (text2 == Room.CurrentRoomGuid.ToString())
					{
						GameObject gameObject5 = this.m_d.GetObjectByName(text);
						if (gameObject5 == null)
						{
							gameObject5 = this.m_d.GetObjectByNameOld(text);
						}
						flag = gameObject5 != null && gameObject5.locationtype == GameObject.LocationType.LT_ROOM && gameObject5.locationname == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
					}
					else
					{
						GameObject gameObject6 = this.m_d.GetObjectByName(text);
						if (gameObject6 == null)
						{
							gameObject6 = this.m_d.GetObjectByNameOld(text);
						}
						flag = gameObject6 != null && gameObject6.locationtype == GameObject.LocationType.LT_ROOM && gameObject6.locationname == text2;
					}
					break;
				case Condition.ConditionType.CT_Item_In_RoomGroup:
				{
					flag = false;
					GameObject objectByName = this.m_d.GetObjectByName(text);
					if (objectByName != null && objectByName.locationtype == GameObject.LocationType.LT_ROOM)
					{
						Room roomByID = this.m_d.GetRoomByID(new Guid(objectByName.locationname));
						if (roomByID != null && roomByID.Group == text2)
						{
							flag = true;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Player_In_Room:
					flag = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() == text;
					break;
				case Condition.ConditionType.CT_Player_In_RoomGroup:
					flag = this.m_d.ThePlayer.CurrentRoom.Group == text;
					break;
				case Condition.ConditionType.CT_Player_In_Same_Room_As:
					flag = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() == this.m_d.GetCharacterByName(text).CurrentRoom;
					break;
				case Condition.ConditionType.CT_Loop_While:
					while (b(text, text2, text3) && !a(A_0.PassCommands, A_3, A_1, ref A_4, A_5) && !this.m_n)
					{
					}
					break;
				case Condition.ConditionType.CT_Loop_Rooms:
					foreach (Room room3 in this.m_d.RoomList)
					{
						if (a(A_0.PassCommands, A_3, A_1, ref A_4, room3) || this.m_n)
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Exits:
				{
					Room room = null;
					try
					{
						room = this.m_d.GetRoomByID(new Guid(text));
					}
					catch
					{
						room = this.m_d.GetRoomByName(text);
					}
					if (room == null)
					{
						break;
					}
					foreach (Exit exit in room.Exits)
					{
						if (a(A_0.PassCommands, A_3, A_1, ref A_4, exit) || this.m_n)
						{
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Loop_Characters:
					foreach (Character character2 in this.m_d.CharacterList)
					{
						if (a(A_0.PassCommands, A_3, A_1, ref A_4, character2) || this.m_n)
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Group:
					foreach (GameObject @object in this.m_d.ObjectList)
					{
						if (@object.GroupName == text && (a(A_0.PassCommands, A_3, A_1, ref A_4, @object) || this.m_n))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
					foreach (GameObject object2 in this.m_d.ObjectList)
					{
						if (object2.locationtype == GameObject.LocationType.LT_CHARACTER && object2.locationname == text && (a(A_0.PassCommands, A_3, A_1, ref A_4, object2) || this.m_n))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Container:
					foreach (GameObject object3 in this.m_d.ObjectList)
					{
						if (object3.locationtype == GameObject.LocationType.LT_IN_OBJECT && object3.locationname == text && (a(A_0.PassCommands, A_3, A_1, ref A_4, object3) || this.m_n))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Inventory:
					foreach (GameObject object4 in this.m_d.ObjectList)
					{
						if (object4.locationtype == GameObject.LocationType.LT_PLAYER && (a(A_0.PassCommands, A_3, A_1, ref A_4, object4) || this.m_n))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Room:
					foreach (GameObject object5 in this.m_d.ObjectList)
					{
						if (object5.locationtype == GameObject.LocationType.LT_ROOM && object5.locationname == text && (a(A_0.PassCommands, A_3, A_1, ref A_4, object5) || this.m_n))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Items:
					foreach (GameObject object6 in this.m_d.ObjectList)
					{
						if (a(A_0.PassCommands, A_3, A_1, ref A_4, object6) || this.m_n)
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Room_CustomPropertyCheck:
				{
					string[] array5 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array5.Length != 2)
					{
						break;
					}
					string text11 = array5[0];
					string text12 = array5[1];
					Room room2 = null;
					room2 = ((!(text11 == "<CurrentRoom>")) ? this.m_d.GetRoomByName(text11) : this.m_d.ThePlayer.CurrentRoom);
					if (room2 == null)
					{
						break;
					}
					foreach (CustomProperty customProperty in room2.CustomProperties)
					{
						if (customProperty.Name == text12)
						{
							flag = a(customProperty.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Character_CustomPropertyCheck:
				{
					string[] array4 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array4.Length != 2)
					{
						break;
					}
					string charname = array4[0];
					string text10 = array4[1];
					Character character = null;
					character = this.m_d.GetCharacterByName(charname);
					if (character == null)
					{
						break;
					}
					foreach (CustomProperty customProperty2 in character.CustomProperties)
					{
						if (customProperty2.Name == text10)
						{
							flag = a(customProperty2.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
				{
					string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array.Length != 2)
					{
						break;
					}
					string timername = array[0];
					string text4 = array[1];
					Rags.Timer timer = null;
					timer = this.m_d.GetTimerByName(timername);
					if (timer == null)
					{
						break;
					}
					foreach (CustomProperty customProperty3 in timer.CustomProperties)
					{
						if (customProperty3.Name == text4)
						{
							flag = a(customProperty3.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
				{
					string[] array3 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array3.Length != 2)
					{
						break;
					}
					string varname = array3[0];
					string text9 = array3[1];
					GameVariable gameVariable = null;
					gameVariable = this.m_d.GetVariableByName(varname);
					if (gameVariable == null)
					{
						break;
					}
					foreach (CustomProperty customProperty4 in gameVariable.CustomProperties)
					{
						if (customProperty4.Name == text9)
						{
							flag = a(customProperty4.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Item_CustomPropertyCheck:
				{
					string[] array2 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array2.Length != 2)
					{
						break;
					}
					string text7 = array2[0];
					string text8 = array2[1];
					GameObject gameObject = null;
					if (text7 == "<Self>")
					{
						if (A_3 != null)
						{
							gameObject = A_3;
						}
					}
					else
					{
						gameObject = this.m_d.GetObjectByNameOld(text7);
					}
					if (gameObject == null)
					{
						break;
					}
					foreach (CustomProperty customProperty5 in gameObject.CustomProperties)
					{
						if (customProperty5.Name == text8)
						{
							flag = a(customProperty5.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Player_CustomPropertyCheck:
				{
					string text6 = text;
					foreach (CustomProperty customProperty6 in this.m_d.ThePlayer.CustomProperties)
					{
						if (customProperty6.Name == text6)
						{
							flag = a(customProperty6.Value, text2, text3);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Variable_Comparison:
					flag = b(text, text2, text3);
					break;
				case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
				{
					GameVariable variableByName = this.m_d.GetVariableByName(text);
					GameVariable variableByName2 = this.m_d.GetVariableByName(text3);
					int num2 = d(text);
					int num3 = c(text);
					int num4 = d(text3);
					int num5 = c(text3);
					string text5 = string.Empty;
					switch (variableByName2.vartype)
					{
					case GameVariable.VarType.VT_NUMBER:
					case GameVariable.VarType.VT_NUMBERARRAY:
						if (num4 != -1)
						{
							text5 = ((num5 == -1) ? variableByName2.VarArray[num4].ToString() : ((List<string>)variableByName2.VarArray[num4])[num5].ToString());
						}
						else
						{
							text5 = variableByName2.dNumType.ToString();
						}
						break;
					case GameVariable.VarType.VT_STRING:
					case GameVariable.VarType.VT_STRINGARRAY:
						if (num4 != -1)
						{
							text5 = ((num5 == -1) ? variableByName2.VarArray[num4].ToString() : ((List<string>)variableByName2.VarArray[num4])[num5].ToString());
						}
						else
						{
							text5 = variableByName2.sString;
						}
						break;
					}
					if (variableByName == null)
					{
						break;
					}
					switch (variableByName.vartype)
					{
					case GameVariable.VarType.VT_NUMBER:
					case GameVariable.VarType.VT_NUMBERARRAY:
					{
						if (num2 != -1)
						{
							if (num3 != -1)
							{
								variableByName.dNumType = Convert.ToDouble(((List<string>)variableByName.VarArray[num2])[num3]);
							}
							else
							{
								variableByName.dNumType = Convert.ToDouble(variableByName.VarArray[num2]);
							}
						}
						double num6 = 0.0;
						double num7 = 0.0;
						try
						{
							num7 = Convert.ToDouble(text5);
						}
						catch
						{
							num7 = 0.0;
						}
						num6 = variableByName.dNumType;
						switch (text2)
						{
						case "Equals":
							flag = num6 == num7;
							break;
						case "Not Equals":
							flag = num6 != num7;
							break;
						case "Greater Than":
							flag = num6 > num7;
							break;
						case "Greater Than or Equals":
							flag = num6 >= num7;
							break;
						case "Less Than":
							flag = num6 < num7;
							break;
						case "Less Than or Equals":
							flag = num6 <= num7;
							break;
						}
						break;
					}
					case GameVariable.VarType.VT_STRING:
					case GameVariable.VarType.VT_STRINGARRAY:
					{
						string strB = TextHandlers.TextOnly(variableByName.sString);
						if (num2 != -1)
						{
							strB = ((num3 == -1) ? TextHandlers.TextOnly(variableByName.VarArray[num2].ToString()) : TextHandlers.TextOnly(((List<string>)variableByName.VarArray[num2])[num3].ToString()));
						}
						if (text2 == "Equals")
						{
							flag = string.Compare(text5, strB, ignoreCase: true) == 0;
						}
						else if (text2 == "Not Equals")
						{
							flag = string.Compare(text5, strB, ignoreCase: true) != 0;
						}
						break;
					}
					case GameVariable.VarType.VT_DATETIME:
						break;
					}
					break;
				}
				case Condition.ConditionType.CT_Item_State_Check:
				{
					GameObject gameObject2 = this.m_d.GetObjectByName(text);
					if (gameObject2 == null)
					{
						gameObject2 = this.m_d.GetObjectByNameOld(text);
					}
					if (gameObject2 != null)
					{
						if (text2 == "Open")
						{
							flag = gameObject2.bOpen;
						}
						if (text2 == "Closed")
						{
							flag = !gameObject2.bOpen;
						}
						if (text2 == "Locked")
						{
							flag = gameObject2.bLocked;
						}
						if (text2 == "Unlocked")
						{
							flag = !gameObject2.bLocked;
						}
						if (text2 == "Worn")
						{
							flag = gameObject2.bWorn;
						}
						if (text2 == "Removed")
						{
							flag = !gameObject2.bWorn;
						}
						if (text2 == "Read")
						{
							flag = gameObject2.bRead;
						}
						if (text2 == "Unread")
						{
							flag = !gameObject2.bRead;
						}
						if (text2 == "Visible")
						{
							flag = gameObject2.bVisible;
						}
						if (text2 == "Invisible")
						{
							flag = !gameObject2.bVisible;
						}
					}
					else
					{
						flag = false;
					}
					break;
				}
				case Condition.ConditionType.CT_AdditionalDataCheck:
				{
					if (A_2 == Rags.Action.ActionInputType.Text)
					{
						flag = string.Compare(text3, A_1.ToString(), ignoreCase: true) == 0;
						break;
					}
					if (string.Compare(text, A_1, ignoreCase: true) == 0)
					{
						flag = true;
						break;
					}
					GameObject objectByNameOld = this.m_d.GetObjectByNameOld(A_1);
					Character characterByName = this.m_d.GetCharacterByName(text);
					if (objectByNameOld != null)
					{
						flag = string.Compare(text, objectByNameOld.UniqueIdentifier.ToString(), ignoreCase: true) == 0;
						break;
					}
					if (characterByName != null)
					{
						flag = string.Compare(A_1, characterByName.ToString(), ignoreCase: true) == 0;
						break;
					}
					objectByNameOld = this.m_d.GetObjectByName(A_1);
					flag = ((objectByNameOld != null && string.Compare(text, objectByNameOld.name, ignoreCase: true) == 0) ? true : false);
					break;
				}
				}
				end_IL_001e:;
			}
			catch (Exception)
			{
				MessageBox.Show("Rags can not process the condition check correctly.  If you are the game author, please correct the error in this conditon:" + A_0.conditionname + " check:" + check.CondType.ToString() + " - " + check.ConditionStep2 + " - " + check.ConditionStep3 + " - " + check.ConditionStep4);
			}
		}
		if (this.m_r != null)
		{
			string text13 = " Passed";
			if (!flag)
			{
				text13 = " Failed";
			}
			this.m_r.AddExecutionData("CONDITION: " + A_0.conditionname + text13, bBold: false);
		}
		return flag;
	}

	private void a(ref List<string> A_0, string A_1, b A_2)
	{
		string text = "Media";
		string text2 = "MediaGroups";
		if (A_2 == MainWindow.b.a)
		{
			text = "Items";
			text2 = "ItemGroups";
		}
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from " + text + " where\r\n                GroupName=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", A_1);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		_ = string.Empty;
		while (sqlCeDataReader.Read())
		{
			A_0.Add(sqlCeDataReader["Name"].ToString());
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		string empty = string.Empty;
		empty = "Select Name from " + text2 + " where\r\n                        parent=@parent";
		sqlCeCommand = new SqlCeCommand(empty, dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@parent", A_1);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			a(ref A_0, sqlCeDataReader["Name"].ToString(), A_2);
		}
	}

	private int d(string A_0)
	{
		int result = -1;
		int num = A_0.IndexOf("(");
		if (num > -1)
		{
			int num2 = A_0.IndexOf(")", num);
			if (num2 > -1)
			{
				string value = A_0.Substring(num + 1, num2 - (num + 1));
				try
				{
					result = Convert.ToInt32(value);
				}
				catch
				{
					result = -1;
				}
			}
		}
		return result;
	}

	private int c(string A_0)
	{
		int result = -1;
		int num = A_0.IndexOf("(");
		if (num > -1)
		{
			num = A_0.IndexOf("(", num + 1);
			if (num > -1)
			{
				int num2 = A_0.IndexOf(")", num);
				if (num2 > -1)
				{
					string value = A_0.Substring(num + 1, num2 - (num + 1));
					try
					{
						result = Convert.ToInt32(value);
					}
					catch
					{
						result = -1;
					}
				}
			}
		}
		return result;
	}

	private Rags.Action c(string A_0, string A_1, string A_2)
	{
		Rags.Action result = null;
		if (A_0.Equals("Chr"))
		{
			result = this.m_d.GetCharacterByName(A_1).GetActionByName(A_2);
		}
		else if (A_0.Equals("Obj"))
		{
			GameObject gameObject = this.m_d.GetObjectByName(A_1);
			if (gameObject == null)
			{
				gameObject = this.m_d.GetObjectByNameOld(A_1);
			}
			if (gameObject != null)
			{
				result = gameObject.GetActionByName(A_2);
			}
		}
		else if (A_0.Equals("Player"))
		{
			result = this.m_d.ThePlayer.GetActionByName(A_2);
		}
		else if (A_0.Equals("Room"))
		{
			Room room = null;
			try
			{
				room = this.m_d.GetRoomByID(new Guid(A_1));
			}
			catch
			{
				room = this.m_d.GetRoomByName(A_1);
			}
			if (room != null)
			{
				result = room.GetActionByName(A_2);
			}
		}
		else if (A_0.Equals("Timer"))
		{
			Rags.Timer timer = null;
			timer = this.m_d.GetTimerByName(A_1);
			if (timer != null)
			{
				result = timer.GetActionByName(A_2);
			}
		}
		return result;
	}

	private void u()
	{
		((UIElement)this.z).IsEnabled = true;
		((UIElement)this.z).Focus();
		((UIElement)an).IsEnabled = false;
		((UIElement)ar).IsEnabled = false;
		((UIElement)this.w).IsEnabled = false;
		((UIElement)this.aa).IsEnabled = false;
		((UIElement)a3).IsEnabled = false;
		((UIElement)a6).IsEnabled = false;
		((UIElement)a8).IsEnabled = false;
		((UIElement)ba).IsEnabled = false;
		while (((UIElement)this.z).IsEnabled && !this.m_n)
		{
			((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
			{
			}));
		}
	}

	private void t()
	{
		for (int i = 0; i < this.m_d.ThePlayer.CurrentRoom.Exits.Count; i++)
		{
			Exit exit = this.m_d.ThePlayer.CurrentRoom.Exits[i];
			switch (exit.Direction)
			{
			case Exit.Directions.North:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)at).Visibility = (Visibility)0;
					((FrameworkElement)at).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)at).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.South:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)au).Visibility = (Visibility)0;
					((FrameworkElement)au).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)au).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.West:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)aw).Visibility = (Visibility)0;
					((FrameworkElement)aw).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)aw).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.East:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)av).Visibility = (Visibility)0;
					((FrameworkElement)av).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)av).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.Up:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)ap).Visibility = (Visibility)0;
					((FrameworkElement)ap).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)ap).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.Down:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)aq).Visibility = (Visibility)0;
					((FrameworkElement)aq).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)aq).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.NorthWest:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)ax).Visibility = (Visibility)0;
					((FrameworkElement)ax).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)ax).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.NorthEast:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)ay).Visibility = (Visibility)0;
					((FrameworkElement)ay).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)ay).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.SouthWest:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)az).Visibility = (Visibility)0;
					((FrameworkElement)az).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)az).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.SouthEast:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)a0).Visibility = (Visibility)0;
					((FrameworkElement)a0).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)a0).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.In:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)a1).Visibility = (Visibility)0;
					((FrameworkElement)a1).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)a1).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.Out:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)a2).Visibility = (Visibility)0;
					((FrameworkElement)a2).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)a2).Visibility = (Visibility)1;
				}
				break;
			}
		}
	}

	private void a(string A_0, bool A_1)
	{
		if (!(A_0 == string.Empty))
		{
			A_0 = this.m_d.PerformTextReplacements(A_0, null);
			object pictureByName = SaveLoad.GetPictureByName(A_0, ref this.m_d);
			if (pictureByName != null)
			{
				a5.Source = new Uri(pictureByName as string);
			}
		}
	}

	private void a(ref CustomProperty A_0, string A_1, string A_2)
	{
		bool flag = false;
		double num = 0.0;
		double num2 = 0.0;
		try
		{
			num2 = Convert.ToDouble(A_0.Value);
			num = Convert.ToDouble(A_2);
			flag = true;
		}
		catch
		{
			flag = false;
		}
		switch (A_1)
		{
		case "Equals":
			A_0.Value = A_2;
			break;
		case "Add":
			if (flag)
			{
				A_0.Value = Convert.ToString(num + num2);
			}
			break;
		case "Subtract":
			if (flag)
			{
				A_0.Value = Convert.ToString(num2 - num);
			}
			Convert.ToDouble(A_2);
			break;
		case "Multiply":
			if (flag)
			{
				A_0.Value = Convert.ToString(num * num2);
			}
			break;
		case "Divide":
			if (flag)
			{
				A_0.Value = Convert.ToString(num2 / num);
			}
			break;
		}
	}

	private double a(GameVariable A_0, string A_1)
	{
		if (A_0.bEnforceRestrictions)
		{
			double num = Convert.ToDouble(this.m_d.PerformTextReplacements(A_0.dMin, null));
			double num2 = Convert.ToDouble(this.m_d.PerformTextReplacements(A_0.dMax, null));
			if (Convert.ToDouble(A_1) < num)
			{
				return num;
			}
			if (Convert.ToDouble(A_1) > num2)
			{
				return num2;
			}
			return Convert.ToDouble(A_1);
		}
		return Convert.ToDouble(A_1);
	}

	private void a(GameVariable A_0, ref object A_1)
	{
		try
		{
			if (A_0.VarArray.Count > 0 && A_0.VarArray[0] is List<string> list)
			{
				_ = list.Count;
			}
			A_0.VarArray.Clear();
			object obj = A_1;
			ArrayObject val = (ArrayObject)((obj is ArrayObject) ? obj : null);
			if (val == null)
			{
				return;
			}
			for (int i = 0; i < Convert.ToInt32(val.length); i++)
			{
				object obj2 = ((ScriptObject)val)[i];
				ArrayObject val2 = (ArrayObject)((obj2 is ArrayObject) ? obj2 : null);
				if (val2 != null)
				{
					for (int j = 0; j < Convert.ToInt32(val2.length); j++)
					{
						if (j == 0)
						{
							A_0.VarArray.Add(new List<string>());
						}
						object obj3 = ((ScriptObject)val2)[j];
						((List<string>)A_0.VarArray[i]).Add(obj3.ToString());
					}
					continue;
				}
				object item = null;
				switch (A_0.vartype)
				{
				case GameVariable.VarType.VT_DATETIMEARRAY:
					try
					{
						item = Convert.ToDateTime(((ScriptObject)val)[i].ToString());
					}
					catch
					{
						item = DateTime.MinValue;
					}
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
					try
					{
						item = Convert.ToDouble(((ScriptObject)val)[i].ToString());
					}
					catch
					{
						item = -1;
					}
					break;
				case GameVariable.VarType.VT_STRINGARRAY:
					item = ((ScriptObject)val)[i].ToString();
					break;
				}
				A_0.VarArray.Add(item);
			}
		}
		catch
		{
		}
	}

	private void a(bool A_0, bool A_1)
	{
		if (this.m_d == null)
		{
			return;
		}
		string text = string.Empty;
		if (this.m_d.ThePlayer.CurrentRoom != null)
		{
			text = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
		}
		if (this.m_d.ThePlayer.CurrentRoom != null)
		{
			object pictureByName = SaveLoad.GetPictureByName(this.m_d.ThePlayer.CurrentRoom.RoomPic, ref this.m_d);
			if (pictureByName != null)
			{
				string text2 = SaveLoad.GetPictureByName(this.m_d.ThePlayer.CurrentRoom.RoomPic, ref this.m_d) as string;
				if (text2 != string.Empty)
				{
					ac.Source = new Uri(text2);
				}
				else
				{
					ac.Source = null;
				}
				if (this.m_d.bHideMainPicDisplay)
				{
					_ = this.m_d.bUseInlineImages;
				}
				if (!this.m_d.bHideMainPicDisplay)
				{
					text2 = SaveLoad.GetPictureByName(this.m_d.ThePlayer.CurrentRoom.RoomPic, ref this.m_d) as string;
					if (text2 != string.Empty)
					{
						this.w.Source = new Uri(text2);
					}
					else
					{
						this.w.Source = null;
					}
				}
			}
			((ContentControl)ad).Content = this.m_d.ThePlayer.CurrentRoom.GetName();
		}
		Guid uniqueID = this.m_d.ThePlayer.CurrentRoom.UniqueID;
		if (A_1)
		{
			if (!this.m_d.ThePlayer.CurrentRoom.bEnterFirstTime)
			{
				this.m_d.ThePlayer.CurrentRoom.bEnterFirstTime = true;
				b("<<On Player Enter First Time>>");
			}
			b("<<On Player Enter>>");
		}
		if (this.m_d == null)
		{
			return;
		}
		if (text == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString())
		{
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, this.m_d.ThePlayer.CurrentRoom.Description + "</br>");
		}
		if (uniqueID == this.m_d.ThePlayer.CurrentRoom.UniqueID)
		{
			w();
			if (!this.m_d.bTurnOffNotifications)
			{
				s();
			}
			r();
			t();
			if (A_0)
			{
				q();
			}
			z();
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "</br>");
			y();
			x();
			w();
			v();
		}
	}

	private void a(ref object A_0)
	{
		object obj = A_0;
		ArrayObject val = (ArrayObject)((obj is ArrayObject) ? obj : null);
		if (val != null)
		{
			for (int i = 0; i < Convert.ToInt32(val.length); i++)
			{
				object obj2 = ((ScriptObject)val)[i];
				ArrayObject val2 = (ArrayObject)((obj2 is ArrayObject) ? obj2 : null);
				if (val2 != null)
				{
					string text = "[" + ((ScriptObject)val2)[0].ToString() + "]";
					string text2 = ((ScriptObject)val2)[1].ToString();
					if (text2 == string.Empty)
					{
						text2 = " ";
					}
					this.m_d.PerformTextReplacements(text, null, text2);
				}
			}
		}
		a(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
		t();
	}

	private void a(GameObject A_0, ref ListBox A_1, GameObject A_2)
	{
		for (int i = 0; i < this.m_d.ObjectList.Count; i++)
		{
			GameObject gameObject = this.m_d.ObjectList[i];
			if (gameObject.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject.locationname == A_0.UniqueIdentifier.ToString() && gameObject.bVisible)
			{
				((ItemsControl)A_1).Items.Add((object)gameObject);
				if (gameObject == A_2)
				{
					((Selector)A_1).SelectedItem = gameObject;
				}
				if (gameObject.bOpenable && gameObject.bOpen)
				{
					a(gameObject, ref A_1, A_2);
				}
			}
		}
	}

	private bool a(string A_0, string A_1, b A_2)
	{
		string text = "Media";
		string text2 = "MediaGroups";
		if (A_2 == MainWindow.b.a)
		{
			text = "Items";
			text2 = "ItemGroups";
		}
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select GroupName from " + text + " where\r\n                Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", A_0);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		string text3 = string.Empty;
		if (sqlCeDataReader.Read())
		{
			text3 = sqlCeDataReader["GroupName"].ToString();
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		if (text3 == A_1)
		{
			return true;
		}
		string empty = string.Empty;
		empty = "Select Name from " + text2 + " where\r\n                        parent=@parent";
		sqlCeCommand = new SqlCeCommand(empty, dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@parent", A_1);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			bool flag = a(A_0, sqlCeDataReader["Name"].ToString(), A_2);
			if (flag)
			{
				return flag;
			}
		}
		return false;
	}

	private bool a(ref GameObject A_0)
	{
		GameObject A_1 = null;
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (@object.name == A_0.locationname)
			{
				A_1 = @object;
				break;
			}
		}
		if (A_1 != null)
		{
			if (A_1.locationtype == GameObject.LocationType.LT_PLAYER)
			{
				return true;
			}
			if (A_1.locationtype == GameObject.LocationType.LT_IN_OBJECT)
			{
				return a(ref A_1);
			}
			return false;
		}
		return false;
	}

	private void b(string A_0)
	{
		try
		{
			if (this.m_d == null)
			{
				return;
			}
			Guid uniqueID = this.m_d.ThePlayer.CurrentRoom.UniqueID;
			Rags.Action A_1 = this.m_d.ThePlayer.CurrentRoom.GetActionByName(A_0);
			if (A_1 != null)
			{
				a(ref A_1, null);
			}
			if (this.m_d == null)
			{
				return;
			}
			A_1 = this.m_d.ThePlayer.GetActionByName(A_0);
			if (A_1 != null)
			{
				a(ref A_1, null);
			}
			if (this.m_d == null)
			{
				return;
			}
			for (int i = 0; i < this.m_d.ObjectList.Count; i++)
			{
				GameObject gameObject = this.m_d.ObjectList[i];
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM || !(gameObject.locationname == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					continue;
				}
				if (A_0.IndexOf("Player Enter") > -1)
				{
					if (!gameObject.bEnterFirstTime)
					{
						A_1 = gameObject.GetActionByName("<<On Player Enter First Time>>");
						gameObject.bEnterFirstTime = true;
						if (A_1 != null)
						{
							a(ref A_1, gameObject);
						}
					}
				}
				else if (A_0.IndexOf("Player Leave") > -1 && !gameObject.bLeaveFirstTime)
				{
					A_1 = gameObject.GetActionByName("<<On Player Leave First Time>>");
					gameObject.bLeaveFirstTime = true;
					if (A_1 != null)
					{
						a(ref A_1, gameObject);
					}
				}
				A_1 = gameObject.GetActionByName(A_0);
				if (A_1 != null && (A_0.Equals("<<On Player Enter>>") || A_0.Equals("<<On Player Leave>>")))
				{
					if (A_0.Equals("<<On Player Enter>>"))
					{
						if (uniqueID == this.m_d.ThePlayer.CurrentRoom.UniqueID)
						{
							a(ref A_1, gameObject);
						}
					}
					else
					{
						a(ref A_1, gameObject);
					}
				}
				if (!gameObject.bContainer || (gameObject.bOpenable && !gameObject.bOpen))
				{
					continue;
				}
				for (int j = 0; j < this.m_d.ObjectList.Count; j++)
				{
					GameObject gameObject2 = this.m_d.ObjectList[j];
					if (gameObject2.locationtype != GameObject.LocationType.LT_IN_OBJECT || !(gameObject2.locationname == gameObject.UniqueIdentifier.ToString()))
					{
						continue;
					}
					if (A_0.IndexOf("Player Enter") > -1)
					{
						if (!gameObject2.bEnterFirstTime)
						{
							A_1 = gameObject2.GetActionByName("<<On Player Enter First Time>>");
							gameObject2.bEnterFirstTime = true;
							if (A_1 != null)
							{
								a(ref A_1, gameObject2);
							}
						}
					}
					else if (A_0.IndexOf("Player Leave") > -1 && !gameObject2.bLeaveFirstTime)
					{
						A_1 = gameObject2.GetActionByName("<<On Player Leave First Time>>");
						gameObject2.bLeaveFirstTime = true;
						if (A_1 != null)
						{
							a(ref A_1, gameObject2);
						}
					}
					A_1 = gameObject2.GetActionByName(A_0);
					if (A_1 == null || (!A_0.Equals("<<On Player Enter>>") && !A_0.Equals("<<On Player Leave>>")))
					{
						continue;
					}
					if (A_0.Equals("<<On Player Enter>>"))
					{
						if (uniqueID == this.m_d.ThePlayer.CurrentRoom.UniqueID)
						{
							a(ref A_1, gameObject2);
						}
					}
					else
					{
						a(ref A_1, gameObject2);
					}
				}
			}
			if (this.m_d == null)
			{
				return;
			}
			for (int k = 0; k < this.m_d.CharacterList.Count; k++)
			{
				Character character = this.m_d.CharacterList[k];
				if (!(character.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					continue;
				}
				if (A_0.IndexOf("Player Enter") > -1)
				{
					if (!character.bEnterFirstTime)
					{
						A_1 = character.GetActionByName("<<On Player Enter First Time>>");
						character.bEnterFirstTime = true;
						if (A_1 != null)
						{
							a(ref A_1, null);
						}
					}
				}
				else if (A_0.IndexOf("Player Leave") > -1 && !character.bLeaveFirstTime)
				{
					A_1 = character.GetActionByName("<<On Player Leave First Time>>");
					character.bLeaveFirstTime = true;
					if (A_1 != null)
					{
						a(ref A_1, null);
					}
				}
				A_1 = character.GetActionByName(A_0);
				if (A_1 == null || (!A_0.Equals("<<On Player Enter>>") && !A_0.Equals("<<On Player Leave>>")))
				{
					continue;
				}
				if (A_0.Equals("<<On Player Enter>>"))
				{
					if (uniqueID == this.m_d.ThePlayer.CurrentRoom.UniqueID)
					{
						a(ref A_1, null);
					}
				}
				else
				{
					a(ref A_1, null);
				}
			}
		}
		catch
		{
		}
	}

	private bool b(string A_0, string A_1, string A_2)
	{
		bool result = true;
		GameVariable variableByName = this.m_d.GetVariableByName(A_0);
		if (variableByName != null)
		{
			int num = d(A_0);
			int num2 = c(A_0);
			string text = this.m_d.PerformTextReplacements(A_2, null);
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (num != -1)
				{
					if (num2 != -1)
					{
						variableByName.dtDateTime = Convert.ToDateTime(((List<string>)variableByName.VarArray[num])[num2]);
					}
					else
					{
						variableByName.dtDateTime = (DateTime)variableByName.VarArray[num];
					}
				}
				switch (A_1)
				{
				case "Equals":
					result = Convert.ToDateTime(text) == variableByName.dtDateTime;
					break;
				case "Not Equals":
					result = Convert.ToDateTime(text) != variableByName.dtDateTime;
					break;
				case "Greater Than":
					result = variableByName.dtDateTime > Convert.ToDateTime(text);
					break;
				case "Greater Than or Equals":
					result = variableByName.dtDateTime >= Convert.ToDateTime(text);
					break;
				case "Less Than":
					result = variableByName.dtDateTime < Convert.ToDateTime(text);
					break;
				case "Less Than or Equals":
					result = variableByName.dtDateTime < Convert.ToDateTime(text);
					break;
				case "DayOfWeek Is":
					result = string.Compare(text, variableByName.dtDateTime.ToString("dddd"), ignoreCase: true) == 0;
					break;
				case "Hour Equals":
					result = variableByName.dtDateTime.Hour == Convert.ToInt32(text);
					break;
				case "Hour Is Greater Than":
					result = variableByName.dtDateTime.Hour > Convert.ToInt32(text);
					break;
				case "Hour Is Less Than":
					result = variableByName.dtDateTime.Hour < Convert.ToInt32(text);
					break;
				case "Minute Equals":
					result = variableByName.dtDateTime.Minute == Convert.ToInt32(text);
					break;
				case "Minute Is Greater Than":
					result = variableByName.dtDateTime.Minute > Convert.ToInt32(text);
					break;
				case "Minute Is Less Than":
					result = variableByName.dtDateTime.Minute < Convert.ToInt32(text);
					break;
				case "Seconds Equals":
					result = variableByName.dtDateTime.Second == Convert.ToInt32(text);
					break;
				case "Seconds Is Greater Than":
					result = variableByName.dtDateTime.Second > Convert.ToInt32(text);
					break;
				case "Seconds Is Less Than":
					result = variableByName.dtDateTime.Second < Convert.ToInt32(text);
					break;
				}
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
				if (num != -1)
				{
					if (num2 != -1)
					{
						variableByName.dNumType = Convert.ToDouble(((List<string>)variableByName.VarArray[num])[num2]);
					}
					else
					{
						variableByName.dNumType = (double)variableByName.VarArray[num];
					}
				}
				switch (A_1)
				{
				case "Equals":
					result = Convert.ToDouble(text) == variableByName.dNumType;
					break;
				case "Not Equals":
					result = Convert.ToDouble(text) != variableByName.dNumType;
					break;
				case "Greater Than":
					result = variableByName.dNumType > Convert.ToDouble(text);
					break;
				case "Greater Than or Equals":
					result = variableByName.dNumType >= Convert.ToDouble(text);
					break;
				case "Less Than":
					result = variableByName.dNumType < Convert.ToDouble(text);
					break;
				case "Less Than or Equals":
					result = variableByName.dNumType <= Convert.ToDouble(text);
					break;
				}
				break;
			case GameVariable.VarType.VT_STRING:
			case GameVariable.VarType.VT_STRINGARRAY:
				if (num != -1)
				{
					if (num2 != -1)
					{
						variableByName.sString = ((List<string>)variableByName.VarArray[num])[num2].ToString();
					}
					else
					{
						variableByName.sString = variableByName.VarArray[num].ToString();
					}
				}
				switch (A_1)
				{
				case "Equals":
					result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) == 0;
					break;
				case "Not Equals":
					result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) != 0;
					break;
				case "Contains":
					result = TextHandlers.TextOnly(variableByName.sString).IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
					break;
				case "Greater Than":
					result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) < 0;
					break;
				case "Less Than":
					result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) > 0;
					break;
				}
				break;
			}
		}
		return result;
	}

	private bool a(string A_0, string A_1, string A_2)
	{
		bool result = true;
		string text = this.m_d.PerformTextReplacements(A_2, null);
		bool flag = false;
		double num = 0.0;
		double num2 = 0.0;
		try
		{
			num = Convert.ToDouble(A_0);
			num2 = Convert.ToDouble(text);
			flag = true;
		}
		catch
		{
			flag = false;
		}
		switch (A_1)
		{
		case "Equals":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) == 0) : (num2 == num));
			break;
		case "Not Equals":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) != 0) : (num2 != num));
			break;
		case "Contains":
			result = A_0.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
			break;
		case "Greater Than":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) > 0) : (num > num2));
			break;
		case "Greater Than or Equals":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) >= 0) : (num >= num2));
			break;
		case "Less Than":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) < 0) : (num < num2));
			break;
		case "Less Than or Equals":
			result = ((!flag) ? (string.Compare(text, A_0, ignoreCase: true) <= 0) : (num <= num2));
			break;
		}
		return result;
	}

	private void s()
	{
		int num = 0;
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() && @object.bVisible)
			{
				if (num == 0)
				{
					SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "You can see ");
				}
				if (num > 0)
				{
					SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ", ");
				}
				if (@object.preposition.Trim().Length > 0)
				{
					SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, @object.preposition + " " + @object.ToString());
				}
				else
				{
					SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, @object.ToString());
				}
				num++;
			}
		}
		if (num > 0)
		{
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "</br>");
		}
	}

	private void r()
	{
		if (((Selector)a9).SelectedItem != null)
		{
			_ = ((Selector)a9).SelectedItem;
		}
		((ItemsControl)a9).Items.Clear();
		foreach (Character character in this.m_d.CharacterList)
		{
			if (!(character.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			((ItemsControl)a9).Items.Add((object)character);
			if (!this.m_d.bTurnOffNotifications)
			{
				SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, character.ToString());
				SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, " is here.</br>");
			}
			if (!character.bAllowInventoryInteraction)
			{
				continue;
			}
			foreach (GameObject @object in this.m_d.ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_CHARACTER && @object.locationname == character.Charname && @object.bVisible)
				{
					((ItemsControl)a9).Items.Add((object)@object);
				}
			}
		}
		for (int num = ((CollectionView)((ItemsControl)a9).Items).Count - 1; num >= 0; num--)
		{
			if (((ItemsControl)a9).Items[num] is GameObject { bImportant: not false } gameObject)
			{
				((ItemsControl)a9).Items.Remove((object)gameObject);
				((ItemsControl)a9).Items.Insert(0, (object)gameObject);
			}
		}
		for (int i = 0; i < ((CollectionView)((ItemsControl)a9).Items).Count; i++)
		{
			object obj = ((ItemsControl)a9).Items[i];
		}
	}

	private void q()
	{
		try
		{
			MainWindow.m_j = true;
			MainWindow.m_g = false;
			MainWindow.m_h = string.Empty;
			if (this.m_d == null)
			{
				return;
			}
			for (int i = 0; i < this.m_d.TimerList.Count; i++)
			{
				Rags.Timer timer = this.m_d.TimerList[i];
				if (timer != null)
				{
					MainWindow.m_h = timer.Name;
					bool flag = false;
					if (!timer.LiveTimer)
					{
						flag = a(timer);
						while (!flag)
						{
							flag = a(timer);
						}
					}
				}
				if (this.m_d == null)
				{
					return;
				}
			}
			if (this.m_r != null)
			{
				this.m_r.RefreshVars();
			}
			y();
			x();
			w();
			v();
		}
		finally
		{
			MainWindow.m_j = false;
		}
	}

	private void m(object A_0, RoutedEventArgs A_1)
	{
		m();
		this.m_f = false;
		if (A_0 == at)
		{
			this.m_l = Exit.Directions.North;
		}
		else if (A_0 == au)
		{
			this.m_l = Exit.Directions.South;
		}
		else if (A_0 == av)
		{
			this.m_l = Exit.Directions.East;
		}
		else if (A_0 == aw)
		{
			this.m_l = Exit.Directions.West;
		}
		else if (A_0 == ax)
		{
			this.m_l = Exit.Directions.NorthWest;
		}
		else if (A_0 == ay)
		{
			this.m_l = Exit.Directions.NorthEast;
		}
		else if (A_0 == az)
		{
			this.m_l = Exit.Directions.SouthWest;
		}
		else if (A_0 == a0)
		{
			this.m_l = Exit.Directions.SouthEast;
		}
		else if (A_0 == a1)
		{
			this.m_l = Exit.Directions.In;
		}
		else if (A_0 == a2)
		{
			this.m_l = Exit.Directions.Out;
		}
		else if (A_0 == ap)
		{
			this.m_l = Exit.Directions.Up;
		}
		else if (A_0 == aq)
		{
			this.m_l = Exit.Directions.Down;
		}
		SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "</br><b>" + this.m_l.ToString() + "</b></br>");
		if (!this.m_d.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			this.m_d.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			b("<<On Player Leave First Time>>");
		}
		b("<<On Player Leave>>");
		if (!this.m_f)
		{
			if (this.m_d == null)
			{
				return;
			}
			this.m_d.MovePlayer(this.m_l);
			a(A_0: true, A_1: true);
		}
		this.m_l = Exit.Directions.Empty;
	}

	private void a(List<Rags.Action> A_0, string A_1, MenuItem A_2, ref ContextMenu A_3, string A_4)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
		for (int i = 0; i < A_0.Count; i++)
		{
			Rags.Action action = A_0[i];
			if (!action.bActive || (action.name.Length > 2 && action.name.Substring(0, 2) == "<<"))
			{
				continue;
			}
			if (action.actionparent == A_1)
			{
				string text = action.name;
				if (action.overridename != string.Empty)
				{
					text = this.m_d.PerformTextReplacements(action.overridename, null);
				}
				MenuItem val = new MenuItem();
				((HeaderedItemsControl)val).Header = A_4 + text;
				((FrameworkElement)val).Tag = action;
				val.Click += b;
				if (A_2 == null)
				{
					((ItemsControl)A_3).Items.Add((object)val);
				}
				else
				{
					((ItemsControl)A_2).Items.Add((object)val);
				}
				a(A_0, action.name, val, ref A_3, A_4 + "  ");
			}
			A_3.IsOpen = true;
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		MenuItem val = (MenuItem)A_0;
		GameObject gameObject = null;
		MenuItem val2 = val;
		while (!(((FrameworkElement)val2).Parent is ContextMenu) && ((FrameworkElement)val2).Parent != null)
		{
			DependencyObject parent = ((FrameworkElement)val2).Parent;
			val2 = (MenuItem)(object)((parent is MenuItem) ? parent : null);
		}
		DependencyObject parent2 = ((FrameworkElement)val2).Parent;
		ContextMenu val3 = (ContextMenu)(object)((parent2 is ContextMenu) ? parent2 : null);
		gameObject = ((FrameworkElement)val3).Tag as GameObject;
		string text = string.Empty;
		switch (this.m_p)
		{
		case MainWindow.a.d:
			if (gameObject != null)
			{
				text = string.Concat(new object[4]
				{
					gameObject.ToString(),
					" - ",
					((HeaderedItemsControl)val).Header,
					"</br>"
				});
			}
			break;
		case MainWindow.a.e:
			if (gameObject != null)
			{
				text = string.Concat(new object[4]
				{
					a(gameObject.ToString()),
					" - ",
					((HeaderedItemsControl)val).Header,
					"</br>"
				});
			}
			break;
		case MainWindow.a.c:
			if (gameObject != null)
			{
				text = string.Concat(new object[4]
				{
					a(gameObject.ToString()),
					" - ",
					((HeaderedItemsControl)val).Header,
					"</br>"
				});
			}
			break;
		case MainWindow.a.b:
			text = string.Concat("Player - ", ((HeaderedItemsControl)val).Header, "</br>");
			break;
		case MainWindow.a.a:
			text = string.Concat(new object[5]
			{
				"Room: ",
				this.m_d.ThePlayer.CurrentRoom.GetName(),
				" - ",
				((HeaderedItemsControl)val).Header,
				"</br>"
			});
			break;
		}
		Rags.Action A_2 = ((FrameworkElement)val).Tag as Rags.Action;
		if (A_2 != null)
		{
			m();
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text);
			if (!a(ref A_2, gameObject))
			{
				return;
			}
			if (!MainWindow.m_e)
			{
				q();
				z();
			}
			else
			{
				MainWindow.m_e = false;
			}
			y();
			x();
			w();
			v();
		}
		val3.IsOpen = false;
	}

	private string a(string A_0)
	{
		string text = A_0;
		int num = A_0.IndexOf("(");
		if (num > -1)
		{
			text = A_0.Substring(0, num);
		}
		return text.Trim();
	}

	private void c(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		if (((Selector)a7).SelectedItem is GameObject gameObject)
		{
			this.m_a = new ContextMenu();
			((FrameworkElement)this.m_a).Tag = gameObject;
			a(gameObject.Actions, "None", null, ref this.m_a, "");
			this.m_p = MainWindow.a.c;
			this.m_a.IsOpen = true;
		}
	}

	private void b(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		ContextMenu A_2 = new ContextMenu();
		Character character = ((Selector)a9).SelectedItem as Character;
		GameObject gameObject = ((Selector)a9).SelectedItem as GameObject;
		List<Rags.Action> list = null;
		if (character != null)
		{
			list = character.Actions;
			((FrameworkElement)A_2).Tag = character;
			this.m_p = MainWindow.a.d;
		}
		else if (gameObject != null)
		{
			list = gameObject.Actions;
			((FrameworkElement)A_2).Tag = gameObject;
			this.m_p = MainWindow.a.c;
		}
		if (list != null)
		{
			a(list, "None", null, ref A_2, "");
			A_2.IsOpen = true;
		}
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		if (((Selector)bb).SelectedItem is GameObject gameObject)
		{
			ContextMenu A_2 = new ContextMenu();
			((FrameworkElement)A_2).Tag = gameObject;
			a(gameObject.Actions, "None", null, ref A_2, "");
			this.m_p = MainWindow.a.e;
			A_2.IsOpen = true;
		}
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
		this.m_n = true;
		this.m_d = null;
		A_1.Cancel = false;
		p();
	}

	private void b(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected Obj, but got Unknown
		if (this.m_d != null)
		{
			ContextMenu A_2 = new ContextMenu();
			a(this.m_d.ThePlayer.Actions, "None", null, ref A_2, "");
			this.m_p = MainWindow.a.b;
			A_2.IsOpen = true;
		}
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		ContextMenu A_2 = new ContextMenu();
		if (this.m_d != null && this.m_d.ThePlayer.CurrentRoom != null)
		{
			a(this.m_d.ThePlayer.CurrentRoom.Actions, "None", null, ref A_2, "");
			this.m_p = MainWindow.a.a;
			A_2.IsOpen = true;
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		Application.Current.Shutdown();
	}

	private void p()
	{
		this.m_n = true;
		bool flag = false;
		while (!flag)
		{
			flag = true;
			foreach (RagsThread item in this.m_i)
			{
				item.bTerminate = true;
				if (item.TheThread.IsAlive)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
				{
				}));
				Thread.Sleep(50);
			}
		}
		this.m_i.Clear();
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I4, but got Unknown
		Key key = A_1.Key;
		switch (key - 97)
		{
		case 0:
			o();
			break;
		case 1:
			n();
			break;
		}
	}

	private void o()
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "QuickSave.rsv");
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = this.m_o;
			saveData.CharacterList = this.m_d.CharacterList;
			saveData.ObjectList = this.m_d.ObjectList;
			saveData.RoomList = this.m_d.RoomList;
			saveData.ThePlayer = this.m_d.ThePlayer;
			saveData.VariableList = this.m_d.VariableList;
			saveData.TimerList = this.m_d.TimerList;
			saveData.StatusBarList = this.m_d.StatusBarItems;
			foreach (GamePicture picture in this.m_d.PictureList)
			{
				saveData.SaveGamePictureList.Add(new SaveGamePicture(picture));
			}
			if (File.Exists(text2))
			{
				File.Copy(text2, text2 + ".bak", overwrite: true);
				File.Delete(text2);
			}
			string tempFileName = Path.GetTempFileName();
			StreamWriter streamWriter = new StreamWriter(tempFileName);
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			sharpSerializer.Serialize(saveData, streamWriter.BaseStream);
			streamWriter.Close();
			EncDec.Encrypt(tempFileName, text2, this.m_q);
			File.Delete(tempFileName);
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "Quicksave...</br>");
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error saving game." + ex.Message);
		}
	}

	private void n()
	{
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Invalid comparison between Unknown and I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Invalid comparison between Unknown and I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		try
		{
			this.m_n = true;
			p();
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string fileIn = Path.Combine(text, "QuickSave.rsv");
			EncDec.Decrypt(fileIn, ref memst, ref cs, this.m_q);
			memst.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memst);
			streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			SaveData saveData = (SaveData)sharpSerializer.Deserialize(streamReader.BaseStream);
			streamReader.Close();
			streamReader.Dispose();
			cs.Close();
			cs.Dispose();
			if (saveData.originalfilename != this.m_o)
			{
				MessageBoxResult val = (MessageBoxResult)7;
				if (this.m_o != string.Empty)
				{
					val = MessageBox.Show("This save is associated with the game file " + saveData.originalfilename + ".  Would you like to load the save with the currently loaded game?", "Save file mismatch", (MessageBoxButton)3);
				}
				if ((int)val == 2)
				{
					return;
				}
				if ((int)val == 7)
				{
					if (!File.Exists(saveData.originalfilename))
					{
						MessageBox.Show("Can not find the RAGS game " + saveData.originalfilename + ".  Please update the game file's location.", "Error loading RAGS game");
						OpenFileDialog val2 = new OpenFileDialog();
						((FileDialog)val2).Filter = "Rags Game Files|*.rag|All Files|*.*";
						((FileDialog)val2).FileName = Path.GetFileName(saveData.originalfilename);
						if (((CommonDialog)val2).ShowDialog() != true)
						{
							return;
						}
						saveData.originalfilename = ((FileDialog)val2).FileName;
					}
					bool flag = false;
					try
					{
						this.m_o = saveData.originalfilename;
						SaveLoad.DBName = saveData.originalfilename;
						SaveLoad.GetDBConnection();
						this.m_d = SaveLoad.Game_LoadGame(this.m_o);
						GameObject.TheGame = this.m_d;
						Character.TheGame = this.m_d;
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
						MemoryStream memst2 = new MemoryStream();
						CryptoStream cs2 = null;
						EncDec.Decrypt(saveData.originalfilename, ref memst2, ref cs2, this.m_q);
						memst2.Seek(0L, SeekOrigin.Begin);
						this.m_d = null;
						if (this.m_d == null)
						{
							memst2.Seek(0L, SeekOrigin.Begin);
							sharpSerializer = new SharpSerializer(binarySerialization: true);
							this.m_d = (Game)sharpSerializer.Deserialize(memst2);
							GameObject.TheGame = this.m_d;
							Character.TheGame = this.m_d;
						}
						memst2.Close();
						memst2.Dispose();
						cs2.Close();
						cs2.Dispose();
					}
				}
			}
			this.m_o = saveData.originalfilename;
			this.m_d.CharacterList = saveData.CharacterList;
			this.m_d.ObjectList = saveData.ObjectList;
			this.m_d.RoomList = saveData.RoomList;
			this.m_d.ThePlayer = saveData.ThePlayer;
			this.m_d.VariableList = saveData.VariableList;
			this.m_d.TimerList = saveData.TimerList;
			this.m_d.StatusBarItems = saveData.StatusBarList;
			foreach (SaveGamePicture saveGamePicture in saveData.SaveGamePictureList)
			{
				GamePicture temp = SaveLoad.GetGamePictureByName(saveGamePicture.TheName, ref this.m_d);
				if (temp != null)
				{
					saveGamePicture.SetData(ref temp);
				}
			}
			_ = "Rapid Game Development System " + Path.GetFileName(saveData.originalfilename) + " " + Game.CurrentObjectVersionNumber;
			((UIElement)an).IsEnabled = true;
			((UIElement)ar).IsEnabled = true;
			((UIElement)this.w).IsEnabled = true;
			((UIElement)this.aa).IsEnabled = true;
			((UIElement)a3).IsEnabled = true;
			((UIElement)a6).IsEnabled = true;
			((UIElement)a8).IsEnabled = true;
			((UIElement)ba).IsEnabled = true;
			((UIElement)this.z).IsEnabled = false;
			aa();
			x();
			w();
			a(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
			a(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
			a(A_0: true, A_1: false);
			if (this.m_d.bgMusic != string.Empty)
			{
				object pictureByName = SaveLoad.GetPictureByName(this.m_d.bgMusic, ref this.m_d);
				if (pictureByName != null && pictureByName is string uriString)
				{
					bc.Source = new Uri(uriString);
				}
			}
			SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "Quickloaded...</br>");
			this.m_n = false;
			if (this.m_r != null)
			{
				this.m_r.Window_Loaded(null, null);
			}
			k();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error trying to quickload:" + ex.Message);
		}
	}

	private void l(object A_0, RoutedEventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		SaveFileDialog val = new SaveFileDialog();
		((FileDialog)val).Filter = "Rags Saved Game|*.rsv|All Files|*.*";
		if (((CommonDialog)val).ShowDialog() != true)
		{
			return;
		}
		SaveData saveData = new SaveData();
		saveData.versionnumber = Game.ObjectVersionNumber;
		saveData.originalfilename = this.m_o;
		saveData.CharacterList = this.m_d.CharacterList;
		saveData.ObjectList = this.m_d.ObjectList;
		saveData.RoomList = this.m_d.RoomList;
		saveData.ThePlayer = this.m_d.ThePlayer;
		saveData.VariableList = this.m_d.VariableList;
		saveData.TimerList = this.m_d.TimerList;
		saveData.StatusBarList = this.m_d.StatusBarItems;
		foreach (GamePicture picture in this.m_d.PictureList)
		{
			saveData.SaveGamePictureList.Add(new SaveGamePicture(picture));
		}
		string fileName = ((FileDialog)val).FileName;
		if (File.Exists(fileName))
		{
			File.Copy(fileName, fileName + ".bak", overwrite: true);
			File.Delete(fileName);
		}
		string tempFileName = Path.GetTempFileName();
		StreamWriter streamWriter = new StreamWriter(tempFileName);
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		sharpSerializer.Serialize(saveData, streamWriter.BaseStream);
		streamWriter.Close();
		EncDec.Encrypt(tempFileName, fileName, this.m_q);
		File.Delete(tempFileName);
	}

	private void a(bool A_0 = true)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Invalid comparison between Unknown and I4
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
		{
			A_0 = false;
		}
		if (A_0)
		{
			MessageBoxResult val = MessageBox.Show("Would you like to save your current game?", "Save", (MessageBoxButton)3);
			if ((int)val == 6)
			{
				l(null, null);
				this.m_n = true;
				this.m_n = true;
				p();
			}
			else
			{
				if ((int)val == 2)
				{
					return;
				}
				this.m_n = true;
				p();
			}
		}
		OpenFileDialog val2 = new OpenFileDialog();
		((FileDialog)val2).Filter = "Rags Saved Game|*.rsv|All Files|*.*";
		if (((CommonDialog)val2).ShowDialog() != true)
		{
			return;
		}
		this.m_n = true;
		p(null, null);
		p();
		MemoryStream memst = new MemoryStream();
		CryptoStream cs = null;
		EncDec.Decrypt(((FileDialog)val2).FileName, ref memst, ref cs, this.m_q);
		memst.Seek(0L, SeekOrigin.Begin);
		StreamReader streamReader = new StreamReader(memst);
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		SaveData saveData = (SaveData)sharpSerializer.Deserialize(streamReader.BaseStream);
		streamReader.Close();
		streamReader.Dispose();
		cs.Close();
		cs.Dispose();
		if (saveData.originalfilename != this.m_o)
		{
			MessageBoxResult val3 = (MessageBoxResult)7;
			if (this.m_o != string.Empty)
			{
				val3 = MessageBox.Show("This save is associated with the game file " + saveData.originalfilename + ".  Would you like to load the save with the currently loaded game?", "Save file mismatch", (MessageBoxButton)3);
			}
			if ((int)val3 == 2)
			{
				return;
			}
			if ((int)val3 == 7)
			{
				if (!File.Exists(saveData.originalfilename))
				{
					MessageBox.Show("Can not find the RAGS game " + saveData.originalfilename + ".  Please update the game file's location.", "Error loading RAGS game");
					OpenFileDialog val4 = new OpenFileDialog();
					((FileDialog)val4).Filter = "Rags Game Files|*.rag|All Files|*.*";
					((FileDialog)val4).FileName = Path.GetFileName(saveData.originalfilename);
					if (((CommonDialog)val4).ShowDialog() != true)
					{
						return;
					}
					saveData.originalfilename = ((FileDialog)val4).FileName;
				}
				bool flag = false;
				try
				{
					this.m_o = saveData.originalfilename;
					SaveLoad.DBName = saveData.originalfilename;
					SaveLoad.GetDBConnection();
					this.m_d = SaveLoad.Game_LoadGame(this.m_o);
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
					MemoryStream memst2 = new MemoryStream();
					CryptoStream cs2 = null;
					EncDec.Decrypt(saveData.originalfilename, ref memst2, ref cs2, this.m_q);
					memst2.Seek(0L, SeekOrigin.Begin);
					this.m_d = null;
					if (this.m_d == null)
					{
						memst2.Seek(0L, SeekOrigin.Begin);
						sharpSerializer = new SharpSerializer(binarySerialization: true);
						this.m_d = (Game)sharpSerializer.Deserialize(memst2);
						GameObject.TheGame = this.m_d;
						Character.TheGame = this.m_d;
					}
					memst2.Close();
					memst2.Dispose();
					cs2.Close();
					cs2.Dispose();
				}
			}
		}
		if (!(saveData.originalfilename != this.m_o))
		{
			this.m_o = saveData.originalfilename;
			this.m_d.CharacterList = saveData.CharacterList;
			this.m_d.ObjectList = saveData.ObjectList;
			this.m_d.RoomList = saveData.RoomList;
			this.m_d.ThePlayer = saveData.ThePlayer;
			this.m_d.VariableList = saveData.VariableList;
			this.m_d.TimerList = saveData.TimerList;
			this.m_d.StatusBarItems = saveData.StatusBarList;
			foreach (SaveGamePicture saveGamePicture in saveData.SaveGamePictureList)
			{
				GamePicture temp = SaveLoad.GetGamePictureByName(saveGamePicture.TheName, ref this.m_d);
				if (temp != null)
				{
					saveGamePicture.SetData(ref temp);
				}
			}
		}
		((Window)this).Title = "Rapid Game Development System " + Path.GetFileName(saveData.originalfilename) + " " + Game.CurrentObjectVersionNumber;
		((UIElement)an).IsEnabled = true;
		((UIElement)ar).IsEnabled = true;
		((UIElement)this.w).IsEnabled = true;
		((UIElement)this.aa).IsEnabled = true;
		((UIElement)a3).IsEnabled = true;
		((UIElement)a6).IsEnabled = true;
		((UIElement)a8).IsEnabled = true;
		((UIElement)ba).IsEnabled = true;
		((UIElement)this.z).IsEnabled = false;
		aa();
		x();
		w();
		a(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
		a(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
		a(A_0: true, A_1: false);
		if (this.m_d.bgMusic != string.Empty)
		{
			object pictureByName = SaveLoad.GetPictureByName(this.m_d.bgMusic, ref this.m_d);
			if (pictureByName != null && pictureByName is string uriString)
			{
				bc.Source = new Uri(uriString);
			}
		}
		this.m_n = false;
		if (this.m_r != null)
		{
			this.m_r.Window_Loaded(null, null);
		}
	}

	private void k(object A_0, RoutedEventArgs A_1)
	{
		bool a_ = true;
		if (this.m_d == null)
		{
			a_ = false;
		}
		a(a_);
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		AboutWindow aboutWindow = new AboutWindow();
		((Window)aboutWindow).Owner = (Window)(object)this;
		((Window)aboutWindow).ShowDialog();
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length <= 1)
		{
			return;
		}
		string text = Environment.GetCommandLineArgs()[1];
		if (text != null)
		{
			this.m_o = text;
			if (!File.Exists(text))
			{
				MessageBox.Show("Sorry, unable to locate the game " + text + ".  Please ensure the file exists and try again.");
				return;
			}
			e(text);
		}
		if (Environment.GetCommandLineArgs().Length > 2 && Environment.GetCommandLineArgs()[2] == "DEBUG")
		{
			this.m_r = new DebugDataWindow(ref this.m_d);
			((Window)this.m_r).Owner = (Window)(object)this;
			((Window)this.m_r).Show();
		}
	}

	private void m()
	{
		if (this.m_d != null)
		{
			this.m_d.TurnCount++;
			HTMLDocument hTMLDocument = this.y.Document as HTMLDocument;
			hTMLDocument.parentWindow.scrollTo(0, this.m_b + Convert.ToInt32(((FrameworkElement)this.y).ActualHeight - 10.0));
			object obj = this.y.InvokeScript("getVerticalScrollPosition");
			this.m_b = Convert.ToInt32(obj.ToString());
		}
	}

	private void l()
	{
		e(this.m_o);
	}

	private void k()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.PlayerPortrait, ref this.m_d);
		if (gamePictureByName != null)
		{
			if (((Panel)a3).Children.Count > 1)
			{
				((Panel)a3).Children.RemoveRange(1, ((Panel)a3).Children.Count - 1);
			}
			for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
			{
				Image val = new Image();
				val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]));
				((Panel)a3).Children.Add((UIElement)(object)val);
			}
		}
		if (this.w.Source != null)
		{
			gamePictureByName = SaveLoad.GetGamePictureByName(Path.GetFileName(this.w.Source.ToString()), ref this.m_d);
			if (gamePictureByName != null)
			{
				if (((Panel)this.u).Children.Count > 1)
				{
					((Panel)this.u).Children.RemoveRange(1, ((Panel)this.u).Children.Count - 1);
				}
				for (int j = 0; j < gamePictureByName.LayeredImages.Count; j++)
				{
					Image val2 = new Image();
					val2.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[j]));
					((Panel)this.u).Children.Add((UIElement)(object)val2);
				}
			}
		}
		gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.CurrentRoom.Name, ref this.m_d);
		if (gamePictureByName != null)
		{
			if (((Panel)this.aa).Children.Count > 1)
			{
				((Panel)this.aa).Children.RemoveRange(1, ((Panel)this.aa).Children.Count - 1);
			}
			for (int k = 0; k < gamePictureByName.LayeredImages.Count; k++)
			{
				Image val3 = new Image();
				val3.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[k]));
				((Panel)this.aa).Children.Add((UIElement)(object)val3);
			}
		}
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.PlayerPortrait, ref this.m_d);
		if (gamePictureByName != null)
		{
			if (((Panel)a3).Children.Count > 1)
			{
				((Panel)a3).Children.RemoveRange(1, ((Panel)a3).Children.Count - 1);
			}
			for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
			{
				Image val = new Image();
				val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]));
				((Panel)a3).Children.Add((UIElement)(object)val);
			}
		}
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(Path.GetFileName(this.w.Source.ToString()), ref this.m_d);
		if (gamePictureByName != null)
		{
			if (((Panel)this.u).Children.Count > 1)
			{
				((Panel)this.u).Children.RemoveRange(1, ((Panel)this.u).Children.Count - 1);
			}
			for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
			{
				Image val = new Image();
				val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]));
				((Panel)this.u).Children.Add((UIElement)(object)val);
			}
		}
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.CurrentRoom.Name, ref this.m_d);
		if (gamePictureByName != null)
		{
			if (((Panel)this.aa).Children.Count > 1)
			{
				((Panel)this.aa).Children.RemoveRange(1, ((Panel)this.aa).Children.Count - 1);
			}
			for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
			{
				Image val = new Image();
				val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]));
				((Panel)this.aa).Children.Add((UIElement)(object)val);
			}
		}
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		o();
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		n();
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		SaveLoad.CorrectCommandAndConditions(ref this.m_d);
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		bd.Play();
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		bc.Play();
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		((Selector)a7).SelectedIndex = -1;
		((Selector)bb).SelectedIndex = -1;
		((Selector)a9).SelectedIndex = -1;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected Obj, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Obj, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected Obj, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected Obj, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected Obj, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected Obj, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected Obj, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected Obj, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected Obj, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected Obj, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected Obj, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected Obj, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected Obj, but got Unknown
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected Obj, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected Obj, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected Obj, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected Obj, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected Obj, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected Obj, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected Obj, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected Obj, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected Obj, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected Obj, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected Obj, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected Obj, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected Obj, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected Obj, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected Obj, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected Obj, but got Unknown
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected Obj, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected Obj, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected Obj, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected Obj, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected Obj, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected Obj, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Expected Obj, but got Unknown
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected Obj, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected Obj, but got Unknown
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected Obj, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected Obj, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Expected Obj, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected Obj, but got Unknown
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected Obj, but got Unknown
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected Obj, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected Obj, but got Unknown
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Expected Obj, but got Unknown
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected Obj, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected Obj, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected Obj, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Expected Obj, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected Obj, but got Unknown
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Expected Obj, but got Unknown
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Expected Obj, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected Obj, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected Obj, but got Unknown
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected Obj, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected Obj, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected Obj, but got Unknown
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_062e: Expected Obj, but got Unknown
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected Obj, but got Unknown
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected Obj, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected Obj, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected Obj, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected Obj, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Expected Obj, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected Obj, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected Obj, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected Obj, but got Unknown
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((Window)(MainWindow)target).Closing += a;
			((Window)(MainWindow)target).Closed += a;
			((UIElement)(MainWindow)target).KeyDown += a;
			((FrameworkElement)(MainWindow)target).Loaded += i;
			break;
		case 2:
			this.s = (Grid)target;
			break;
		case 3:
			((MenuItem)target).Click += n;
			break;
		case 4:
			((MenuItem)target).Click += l;
			break;
		case 5:
			((MenuItem)target).Click += k;
			break;
		case 6:
			((MenuItem)target).Click += o;
			break;
		case 7:
			((MenuItem)target).Click += e;
			break;
		case 8:
			((MenuItem)target).Click += d;
			break;
		case 9:
			((MenuItem)target).Click += c;
			break;
		case 10:
			this.t = (MenuItem)target;
			break;
		case 11:
			((MenuItem)target).Click += j;
			break;
		case 12:
			this.u = (Grid)target;
			break;
		case 13:
			this.v = (Border)target;
			break;
		case 14:
			this.w = (MediaElement)target;
			this.w.MediaOpened += g;
			break;
		case 15:
			this.x = (Border)target;
			break;
		case 16:
			this.y = (WebBrowser)target;
			this.y.LoadCompleted += a;
			break;
		case 17:
			this.z = (Button)target;
			((ButtonBase)this.z).Click += p;
			break;
		case 18:
			this.aa = (Grid)target;
			((UIElement)this.aa).MouseDown += a;
			break;
		case 19:
			this.ab = (Border)target;
			break;
		case 20:
			ac = (MediaElement)target;
			ac.MediaOpened += f;
			break;
		case 21:
			ad = (Label)target;
			break;
		case 22:
			ae = (Border)target;
			break;
		case 23:
			af = (StatusBar)target;
			break;
		case 24:
			ag = (Grid)target;
			break;
		case 25:
			ah = (ColumnDefinition)target;
			break;
		case 26:
			ai = (ColumnDefinition)target;
			break;
		case 27:
			aj = (ColumnDefinition)target;
			break;
		case 28:
			ak = (ColumnDefinition)target;
			break;
		case 29:
			al = (ColumnDefinition)target;
			break;
		case 30:
			am = (ColumnDefinition)target;
			break;
		case 31:
			an = (Grid)target;
			break;
		case 32:
			ao = (Image)target;
			break;
		case 33:
			ap = (Button)target;
			((ButtonBase)ap).Click += m;
			break;
		case 34:
			aq = (Button)target;
			((ButtonBase)aq).Click += m;
			break;
		case 35:
			ar = (Grid)target;
			break;
		case 36:
			@as = (Image)target;
			break;
		case 37:
			at = (Button)target;
			((ButtonBase)at).Click += m;
			break;
		case 38:
			au = (Button)target;
			((ButtonBase)au).Click += m;
			break;
		case 39:
			av = (Button)target;
			((ButtonBase)av).Click += m;
			break;
		case 40:
			aw = (Button)target;
			((ButtonBase)aw).Click += m;
			break;
		case 41:
			ax = (Button)target;
			((ButtonBase)ax).Click += m;
			break;
		case 42:
			ay = (Button)target;
			((ButtonBase)ay).Click += m;
			break;
		case 43:
			az = (Button)target;
			((ButtonBase)az).Click += m;
			break;
		case 44:
			a0 = (Button)target;
			((ButtonBase)a0).Click += m;
			break;
		case 45:
			a1 = (Button)target;
			((ButtonBase)a1).Click += m;
			break;
		case 46:
			a2 = (Button)target;
			((ButtonBase)a2).Click += m;
			break;
		case 47:
			a3 = (Grid)target;
			((UIElement)a3).MouseDown += b;
			break;
		case 48:
			a4 = (Border)target;
			break;
		case 49:
			a5 = (MediaElement)target;
			a5.MediaOpened += h;
			break;
		case 50:
			a6 = (Grid)target;
			break;
		case 51:
			a7 = (ListBox)target;
			((Selector)a7).SelectionChanged += c;
			((UIElement)a7).MouseEnter += a;
			break;
		case 52:
			a8 = (Grid)target;
			break;
		case 53:
			a9 = (ListBox)target;
			((Selector)a9).SelectionChanged += b;
			((UIElement)a9).MouseEnter += a;
			break;
		case 54:
			ba = (Grid)target;
			break;
		case 55:
			bb = (ListBox)target;
			((Selector)bb).SelectionChanged += a;
			((UIElement)bb).MouseEnter += a;
			break;
		case 56:
			bc = (MediaElement)target;
			((FrameworkElement)bc).Loaded += a;
			break;
		case 57:
			bd = (MediaElement)target;
			((FrameworkElement)bd).Loaded += b;
			break;
		default:
			be = true;
			break;
		}
	}

	[CompilerGenerated]
	private static void j()
	{
	}

	[CompilerGenerated]
	private static void i()
	{
	}

	[CompilerGenerated]
	private static void h()
	{
	}

	[CompilerGenerated]
	private static void g()
	{
	}

	[CompilerGenerated]
	private static void f()
	{
	}

	[CompilerGenerated]
	private static void e()
	{
	}

	[CompilerGenerated]
	private static void d()
	{
	}

	[CompilerGenerated]
	private static void c()
	{
	}

	[CompilerGenerated]
	private static void b()
	{
	}

	[CompilerGenerated]
	private static void a()
	{
	}

	static MainWindow()
	{
		MainWindow.m_e = false;
		MainWindow.m_g = true;
		MainWindow.m_h = string.Empty;
		MainWindow.m_j = false;
	}
}
