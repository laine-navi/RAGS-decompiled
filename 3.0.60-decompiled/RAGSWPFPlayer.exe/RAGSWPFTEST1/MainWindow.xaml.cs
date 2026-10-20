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
using System.Windows.Navigation;
using System.Windows.Threading;
using MSHTML;
using Microsoft.JScript;
using Microsoft.Win32;
using Polenter.Serialization;
using RAGSWPFPlayer;
using Rags;
using WPFRagsLib;

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

	internal MediaElement ao;

	internal Button ap;

	internal Button aq;

	internal Grid ar;

	internal Grid @as;

	internal Border at;

	internal MediaElement au;

	internal Button av;

	internal Button aw;

	internal Button ax;

	internal Button ay;

	internal Button az;

	internal Button a0;

	internal Button a1;

	internal Button a2;

	internal Button a3;

	internal Button a4;

	internal Grid a5;

	internal Border a6;

	internal MediaElement a7;

	internal Grid a8;

	internal ListBox a9;

	internal Grid ba;

	internal ListBox bb;

	internal Grid bc;

	internal ListBox bd;

	internal MediaElement be;

	internal MediaElement bf;

	private bool bg;

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

	[CompilerGenerated]
	private static System.Action bp;

	[CompilerGenerated]
	private static System.Action bq;

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

	private void s(object A_0, RoutedEventArgs A_1)
	{
		((UIElement)an).IsEnabled = true;
		((UIElement)ar).IsEnabled = true;
		((UIElement)this.w).IsEnabled = true;
		((UIElement)this.aa).IsEnabled = true;
		((UIElement)a5).IsEnabled = true;
		((UIElement)a8).IsEnabled = true;
		((UIElement)ba).IsEnabled = true;
		((UIElement)bc).IsEnabled = true;
		((UIElement)this.z).IsEnabled = false;
	}

	private void r(object A_0, RoutedEventArgs A_1)
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

	private void q(object A_0, RoutedEventArgs A_1)
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
			((UIElement)a5).IsEnabled = true;
			((UIElement)a8).IsEnabled = true;
			((UIElement)ba).IsEnabled = true;
			((UIElement)bc).IsEnabled = true;
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
			AdditionalInputWindow additionalInputWindow = new AdditionalInputWindow(Rags.Action.ActionInputType.Text, ref bd, ref a9, ref bb);
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
		c(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
		c(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
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
				be.Source = new Uri(uriString);
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
				additionalInputWindow = new AdditionalInputWindow(A_0.InputType, ref inv, ref a9, ref bb);
				((Window)additionalInputWindow).Owner = (Window)(object)this;
				((ContentControl)additionalInputWindow.d).Content = this.m_d.PerformTextReplacements(A_0.CustomChoiceTitle, null);
			}
			else
			{
				additionalInputWindow = new AdditionalInputWindow(A_0.InputType, ref bd, ref a9, ref bb);
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
			a6.BorderBrush = (Brush)new SolidColorBrush(Colors.Green);
			a6.BorderThickness = new Thickness(3.0);
		}
		else
		{
			a6.BorderBrush = (Brush)new SolidColorBrush(Colors.Black);
			a6.BorderThickness = new Thickness(1.0);
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
		//IL_7808: Unknown result type (might be due to invalid IL or missing references)
		//IL_7fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8069: Unknown result type (might be due to invalid IL or missing references)
		//IL_761e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7624: Unknown result type (might be due to invalid IL or missing references)
		//IL_7629: Unknown result type (might be due to invalid IL or missing references)
		//IL_762e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7632: Unknown result type (might be due to invalid IL or missing references)
		//IL_7637: Unknown result type (might be due to invalid IL or missing references)
		//IL_7687: Unknown result type (might be due to invalid IL or missing references)
		//IL_7690: Expected Obj, but got Unknown
		//IL_76d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2009: Unknown result type (might be due to invalid IL or missing references)
		//IL_7164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected Obj, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected Obj, but got Unknown
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Expected Obj, but got Unknown
		//IL_163f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_7af8: Expected Obj, but got Unknown
		//IL_7502: Unknown result type (might be due to invalid IL or missing references)
		//IL_750b: Expected Obj, but got Unknown
		//IL_7bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c73: Expected Obj, but got Unknown
		//IL_7cb3: Unknown result type (might be due to invalid IL or missing references)
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
						GameVariable variableByName7 = this.m_d.GetVariableByName(text);
						if (variableByName7 == null)
						{
							break;
						}
						try
						{
							SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
							SqlCeCommand sqlCeCommand = new SqlCeCommand(text4, dBConnection);
							SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
							variableByName7.VarArray = new List<object>();
							while (sqlCeDataReader.Read())
							{
								List<string> list = new List<string>();
								variableByName7.VarArray.Add(list);
								for (int num15 = 0; num15 < sqlCeDataReader.FieldCount; num15++)
								{
									list.Add(sqlCeDataReader.GetValue(num15).ToString());
								}
							}
						}
						catch (Exception ex)
						{
							variableByName7.VarArray = new List<object>();
							List<string> list2 = new List<string>();
							variableByName7.VarArray.Add(list2);
							list2.Add(ex.Message);
						}
						break;
					}
					case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
					{
						GameVariable variableByName14 = this.m_d.GetVariableByName(text);
						if (variableByName14 == null)
						{
							break;
						}
						List<string> A_16 = new List<string>();
						a(ref A_16, text2, MainWindow.b.a);
						if (A_16.Count > 0)
						{
							string text50 = A_16[this.m_m.Next(0, A_16.Count)];
							int num33 = d(text);
							int num34 = c(text);
							if (num33 == -1)
							{
								variableByName14.sString = text50;
							}
							else if (num34 != -1)
							{
								((List<string>)variableByName14.VarArray[num33])[num34] = text50;
							}
							else
							{
								variableByName14.VarArray[num33] = text50;
							}
						}
						else
						{
							variableByName14.sString = string.Empty;
						}
						break;
					}
					case Command.CommandType.CT_MM_GETRANDOMGROUP:
					{
						GameVariable variableByName2 = this.m_d.GetVariableByName(text);
						if (variableByName2 == null)
						{
							break;
						}
						List<string> A_5 = new List<string>();
						a(ref A_5, text2, MainWindow.b.b);
						if (A_5.Count > 0)
						{
							string text6 = A_5[this.m_m.Next(0, A_5.Count)];
							int num3 = d(text);
							int num4 = c(text);
							if (num3 == -1)
							{
								variableByName2.sString = text6;
							}
							else if (num4 != -1)
							{
								((List<string>)variableByName2.VarArray[num3])[num4] = text6;
							}
							else
							{
								variableByName2.VarArray[num3] = text6;
							}
						}
						else
						{
							variableByName2.sString = string.Empty;
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
						GameObject gameObject13 = this.m_d.GetObjectByName(text);
						if (gameObject13 == null)
						{
							gameObject13 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject13 != null)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, gameObject13.Display(this.m_d.ObjectList));
						}
						break;
					}
					case Command.CommandType.CT_LOOP_BREAK:
						return true;
					case Command.CommandType.CT_EXPORTVARIABLE:
					{
						SaveFileDialog val6 = new SaveFileDialog();
						((FileDialog)val6).Title = "Export Game Data";
						((FileDialog)val6).Filter = "Rags Export|*.rxp|All Files|*.*";
						GameVariable variableByName10 = this.m_d.GetVariableByName(text);
						if (variableByName10 != null && ((CommonDialog)val6).ShowDialog() == true)
						{
							try
							{
								StreamWriter streamWriter = new StreamWriter(((FileDialog)val6).FileName);
								SharpSerializer sharpSerializer2 = new SharpSerializer(binarySerialization: true);
								sharpSerializer2.Serialize(variableByName10, streamWriter.BaseStream);
								streamWriter.Close();
							}
							catch
							{
								MessageBox.Show("Unable to save your game data.");
							}
						}
						((FileDialog)val6).Filter = "Rich Text File|*.rtf|All Files|*.*";
						break;
					}
					case Command.CommandType.CT_IMPORTVARIABLE:
					{
						OpenFileDialog val3 = new OpenFileDialog();
						((FileDialog)val3).Title = "Import Game Data";
						string filter = ((FileDialog)val3).Filter;
						((FileDialog)val3).Filter = "Rags Export|*.rxp|All Files|*.*";
						if (((CommonDialog)val3).ShowDialog() == true)
						{
							try
							{
								StreamReader streamReader = new StreamReader(((FileDialog)val3).FileName);
								streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
								SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
								GameVariable gameVariable2 = (GameVariable)sharpSerializer.Deserialize(streamReader.BaseStream);
								streamReader.Close();
								GameVariable variableByName5 = this.m_d.GetVariableByName(gameVariable2.varname);
								if (variableByName5 != null)
								{
									this.m_d.VariableList.Remove(variableByName5);
								}
								this.m_d.VariableList.Add(gameVariable2);
							}
							catch
							{
								MessageBox.Show("Unable to load your game data.");
							}
						}
						((FileDialog)val3).Filter = filter;
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
					{
						GameVariable variableByName12 = this.m_d.GetVariableByName(text);
						if (variableByName12 != null)
						{
							int num29 = d(text);
							int num30 = c(text);
							if (num29 == -1)
							{
								variableByName12.dNumType = Convert.ToDouble(this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMax, null))) + 1));
							}
							else if (num30 != -1)
							{
								((List<string>)variableByName12.VarArray[num29])[num30] = this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMax, null))) + 1).ToString();
							}
							else
							{
								variableByName12.VarArray[num29] = Convert.ToDouble(this.m_m.Next(Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMin, null))), Convert.ToInt32(Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName12.dMax, null))) + 1));
							}
						}
						break;
					}
					case Command.CommandType.CT_CANCELMOVE:
						this.m_f = true;
						break;
					case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
					{
						string text28 = text;
						string[] array7 = text28.Split(new char[1] { ':' }, StringSplitOptions.None);
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
						string text43 = text;
						string[] array13 = text43.Split(new char[1] { ':' }, StringSplitOptions.None);
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
						bool flag11 = false;
						foreach (string customChoice in action3.CustomChoices)
						{
							if (customChoice.Equals(text4))
							{
								flag11 = true;
								break;
							}
						}
						if (!flag11)
						{
							action3.CustomChoices.Add(text4);
						}
						break;
					}
					case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
					{
						string text11 = text;
						string[] array2 = text11.Split(new char[1] { ':' }, StringSplitOptions.None);
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
						GamePicture gamePictureByName5 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName5 != null)
						{
							gamePictureByName5.LayeredImages.Add(text2);
							k();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
					{
						GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName == null)
						{
							break;
						}
						foreach (string layeredImage in gamePictureByName.LayeredImages)
						{
							if (layeredImage == text2)
							{
								gamePictureByName.LayeredImages.Remove(layeredImage);
								break;
							}
						}
						k();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
					{
						GamePicture gamePictureByName2 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						GamePicture gamePictureByName3 = SaveLoad.GetGamePictureByName(text3, ref this.m_d);
						if (gamePictureByName2 == null || gamePictureByName3 == null)
						{
							break;
						}
						int num24 = -1;
						bool flag8 = false;
						foreach (string layeredImage2 in gamePictureByName2.LayeredImages)
						{
							num24++;
							if (layeredImage2 == text2)
							{
								flag8 = true;
								gamePictureByName2.LayeredImages.Remove(layeredImage2);
								break;
							}
						}
						if (flag8)
						{
							gamePictureByName2.LayeredImages.Insert(num24, text3);
							k();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
					{
						GamePicture gamePictureByName4 = SaveLoad.GetGamePictureByName(text, ref this.m_d);
						if (gamePictureByName4 != null)
						{
							gamePictureByName4.LayeredImages.Clear();
							k();
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERNAME:
						this.m_d.ThePlayer.Name = this.m_d.PerformTextReplacements(text3, null);
						break;
					case Command.CommandType.CT_DISPLAYPLAYERDESC:
					{
						string text15 = this.m_d.PerformTextReplacements(this.m_d.ThePlayer.Description, null);
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text15 + "</br>");
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
					{
						GameObject gameObject17 = this.m_d.GetObjectByName(text);
						if (gameObject17 == null)
						{
							gameObject17 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject17 == null)
						{
							break;
						}
						GameObject.LocationType locationtype2 = gameObject17.locationtype;
						string locationname = gameObject17.locationname;
						bool flag13 = true;
						string text54 = string.Empty;
						foreach (string layeredZoneLevel in gameObject17.LayeredZoneLevels)
						{
							string[] array16 = layeredZoneLevel.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject @object in this.m_d.ObjectList)
							{
								if (!@object.bWorn || @object.locationtype != locationtype2 || (locationtype2 == GameObject.LocationType.LT_CHARACTER && locationname != @object.locationname))
								{
									continue;
								}
								foreach (string layeredZoneLevel2 in @object.LayeredZoneLevels)
								{
									string[] array17 = layeredZoneLevel2.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (!(gameObject17.UniqueIdentifier != @object.UniqueIdentifier) || !(array17[0] == array16[0]) || Convert.ToInt32(array17[1]) < Convert.ToInt32(array16[1]))
									{
										continue;
									}
									flag13 = false;
									if (text54.IndexOf(gameObject17.GetDisplayStringNameOnly()) != -1)
									{
										continue;
									}
									if (text54 == string.Empty)
									{
										if (locationtype2 != GameObject.LocationType.LT_CHARACTER)
										{
											string text39 = text54;
											text54 = text39 + "You cannot remove " + gameObject17.GetDisplayStringNameOnly() + ".  You need to remove " + @object.GetDisplayStringNameOnly();
										}
										else
										{
											string text39 = text54;
											text54 = text39 + locationname + " cannot remove " + gameObject17.GetDisplayStringNameOnly() + ".  " + locationname + " will need to remove " + @object.GetDisplayStringNameOnly();
										}
									}
									else
									{
										text54 = text54 + " and " + @object.GetDisplayStringNameOnly();
									}
								}
							}
						}
						if (!flag13)
						{
							text54 += " first.";
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text54 + "</br>");
							break;
						}
						if (locationtype2 != GameObject.LocationType.LT_CHARACTER)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "You take off " + gameObject17.GetDisplayStringNameOnly() + ".</br>");
						}
						else
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, locationname = locationname + " takes off " + gameObject17.GetDisplayStringNameOnly() + ".</br>");
						}
						gameObject17.bWorn = false;
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_WEAR:
					{
						GameObject gameObject9 = this.m_d.GetObjectByName(text);
						if (gameObject9 == null)
						{
							gameObject9 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject9 == null)
						{
							break;
						}
						GameObject.LocationType locationtype = gameObject9.locationtype;
						string text37 = gameObject9.locationname;
						bool flag9 = true;
						string text38 = string.Empty;
						foreach (string layeredZoneLevel3 in gameObject9.LayeredZoneLevels)
						{
							string[] array11 = layeredZoneLevel3.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject object2 in this.m_d.ObjectList)
							{
								if (!object2.bWorn || object2.locationtype != locationtype)
								{
									continue;
								}
								foreach (string layeredZoneLevel4 in object2.LayeredZoneLevels)
								{
									string[] array12 = layeredZoneLevel4.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (!(array12[0] == array11[0]) || Convert.ToInt32(array12[1]) < Convert.ToInt32(array11[1]) || (locationtype == GameObject.LocationType.LT_CHARACTER && text37 != object2.locationname))
									{
										continue;
									}
									flag9 = false;
									if (text38.IndexOf(gameObject9.GetDisplayStringNameOnly()) != -1)
									{
										continue;
									}
									if (text38 == string.Empty)
									{
										if (locationtype != GameObject.LocationType.LT_CHARACTER)
										{
											string text39 = text38;
											text38 = text39 + "You cannot wear " + gameObject9.GetDisplayStringNameOnly() + ".  You will need to remove " + object2.GetDisplayStringNameOnly();
										}
										else
										{
											string text40 = text38;
											string text39 = text37;
											text38 = text40 + (text37 = text39 + " cannot wear " + gameObject9.GetDisplayStringNameOnly() + ".  " + text37 + " will need to remove " + object2.GetDisplayStringNameOnly());
										}
									}
									else
									{
										text38 = text38 + " and " + object2.GetDisplayStringNameOnly();
									}
								}
							}
						}
						if (!flag9)
						{
							text38 += " first.";
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text38 + "<br/>");
							break;
						}
						if (locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, "You put on " + gameObject9.GetDisplayStringNameOnly() + ".</br>");
						}
						else
						{
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, text37 + " puts on " + gameObject9.GetDisplayStringNameOnly() + ".</br>");
						}
						gameObject9.bWorn = true;
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
						DoubleAnimation val7 = new DoubleAnimation();
						val7.From = 0.0;
						val7.To = 1.0;
						((Timeline)val7).Duration = new Duration(TimeSpan.FromSeconds(0.5));
						EndGameWindow endGameWindow = new EndGameWindow();
						((Window)endGameWindow).Owner = (Window)(object)this;
						((UIElement)endGameWindow).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val7);
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
								((UIElement)a5).IsEnabled = false;
								((UIElement)a8).IsEnabled = false;
								((UIElement)ba).IsEnabled = false;
								((UIElement)bc).IsEnabled = false;
								return false;
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOINV:
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
						if (gameObject16 == null)
						{
							break;
						}
						if (this.m_d.ThePlayer.bEnforceWeight)
						{
							double num36 = 0.0;
							foreach (GameObject object3 in this.m_d.ObjectList)
							{
								if (object3.locationtype == GameObject.LocationType.LT_PLAYER)
								{
									num36 += this.m_d.GetItemWeight(object3.UniqueIdentifier);
								}
							}
							num36 += this.m_d.GetItemWeight(gameObject16.UniqueIdentifier);
							if (num36 > this.m_d.ThePlayer.dWeightLimit)
							{
								MessageBox.Show("The " + gameObject16.name + " is too heavy to lift at the moment.  unload some stuff first.");
								return false;
							}
						}
						gameObject16.locationtype = GameObject.LocationType.LT_PLAYER;
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
						Room room2 = null;
						room2 = ((!(text == Room.CurrentRoomGuid.ToString())) ? this.m_d.GetRoomByID(new Guid(text)) : this.m_d.ThePlayer.CurrentRoom);
						if (room2 == null)
						{
							break;
						}
						foreach (GameObject object8 in this.m_d.ObjectList)
						{
							if (object8.locationtype == GameObject.LocationType.LT_ROOM && object8.locationname == room2.UniqueID.ToString() && object8.bCarryable && object8.bVisible)
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
							object obj22 = SaveLoad.GetPictureByName(character3.CharPortrait, ref this.m_d) as string;
							if (obj22 != string.Empty)
							{
								this.w.Source = new Uri(obj22 as string);
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
								object obj10 = SaveLoad.GetPictureByName(this.m_d.ThePlayer.CurrentRoom.RoomPic, ref this.m_d) as string;
								this.w.Source = new Uri(obj10 as string);
							}
							break;
						}
						Room room5 = null;
						try
						{
							room5 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room5 = this.m_d.GetRoomByName(text);
						}
						if (room5 == null)
						{
							break;
						}
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							object obj12 = SaveLoad.GetPictureByName(room5.RoomPic, ref this.m_d) as string;
							if (obj12 != string.Empty)
							{
								this.w.Source = new Uri(obj12 as string);
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOROOM:
					{
						GameObject gameObject15 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject15 = A_1;
							}
						}
						else
						{
							gameObject15 = this.m_d.GetObjectByName(text);
							if (gameObject15 == null)
							{
								gameObject15 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject15 == null)
						{
							break;
						}
						gameObject15.locationtype = GameObject.LocationType.LT_ROOM;
						if (text2 == Room.CurrentRoomGuid.ToString())
						{
							gameObject15.locationname = this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString();
							break;
						}
						if (text2 == Room.VoidRoomGuid.ToString())
						{
							gameObject15.locationtype = GameObject.LocationType.LT_NULL;
							break;
						}
						string text51 = string.Empty;
						try
						{
							new Guid(text2);
							text51 = text2;
						}
						catch
						{
							Room roomByName3 = this.m_d.GetRoomByName(text2);
							if (roomByName3 != null)
							{
								text51 = roomByName3.UniqueID.ToString();
							}
						}
						if (text51 == string.Empty)
						{
							MessageBox.Show("Error in command CT_MoveItemToRoom.  Could not locate a room called " + text2);
						}
						else
						{
							gameObject15.locationname = text51;
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
							string text41 = string.Empty;
							try
							{
								text41 = new Guid(text2).ToString();
							}
							catch
							{
								GameObject objectByNameOld = this.m_d.GetObjectByNameOld(text2);
								if (objectByNameOld != null)
								{
									text41 = objectByNameOld.UniqueIdentifier.ToString();
								}
							}
							if (text41 != string.Empty)
							{
								A_1.locationtype = GameObject.LocationType.LT_IN_OBJECT;
								A_1.locationname = text41;
							}
							break;
						}
						GameObject gameObject10 = this.m_d.GetObjectByName(text);
						if (gameObject10 == null)
						{
							gameObject10 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject10 == null)
						{
							break;
						}
						string text42 = string.Empty;
						try
						{
							text42 = new Guid(text2).ToString();
						}
						catch
						{
							GameObject objectByNameOld2 = this.m_d.GetObjectByNameOld(text2);
							if (objectByNameOld2 != null)
							{
								text42 = objectByNameOld2.UniqueIdentifier.ToString();
							}
						}
						if (text42 != string.Empty)
						{
							gameObject10.locationtype = GameObject.LocationType.LT_IN_OBJECT;
							gameObject10.locationname = text42;
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
						GameObject gameObject7 = this.m_d.GetObjectByName(text);
						if (gameObject7 == null)
						{
							gameObject7 = this.m_d.GetObjectByNameOld(text);
						}
						if (gameObject7 != null)
						{
							gameObject7.locationtype = GameObject.LocationType.LT_CHARACTER;
							gameObject7.locationname = text2;
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
						string text10 = text2.Substring(0, num10);
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
							if (room3.Exits[num12].Direction.ToString() == text10)
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
						for (int num35 = 0; num35 < room12.Exits.Count; num35++)
						{
							if (room12.Exits[num35].Direction.ToString() == text2)
							{
								exit = room12.Exits[num35];
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
						string text49 = MainWindow.m_h;
						MainWindow.m_j = true;
						MainWindow.m_g = false;
						MainWindow.m_h = string.Empty;
						Rags.Timer timerByName3 = this.m_d.GetTimerByName(text);
						if (timerByName3 != null)
						{
							MainWindow.m_h = timerByName3.Name;
							Rags.Action A_15 = timerByName3.GetActionByName("<<On Each Turn>>");
							if (A_15 != null)
							{
								a(ref A_15, null);
								while (MainWindow.m_g)
								{
									MainWindow.m_g = false;
									a(ref A_15, null);
								}
							}
						}
						MainWindow.m_j = flag12;
						MainWindow.m_h = text49;
						break;
					}
					case Command.CommandType.CT_RESETTIMER:
					{
						Rags.Timer timerByName2 = this.m_d.GetTimerByName(text);
						if (timerByName2 != null)
						{
							timerByName2.TurnNumber = 0;
							if (MainWindow.m_j && MainWindow.m_h == timerByName2.Name)
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
						Rags.Timer timerByName = this.m_d.GetTimerByName(text);
						if (timerByName != null)
						{
							if (string.Compare(text2, "Active", ignoreCase: true) == 0)
							{
								timerByName.Active = true;
							}
							else
							{
								timerByName.Active = false;
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
						GameVariable variableByName9 = this.m_d.GetVariableByName(text);
						if (variableByName9 == null)
						{
							break;
						}
						string[] array4 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text19 = string.Empty;
						if (array4.Length == 2)
						{
							string text20 = array4[0];
							string text21 = array4[1];
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
						int num19 = d(text);
						int num20 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName9.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num19 == -1)
							{
								variableByName9.sString = text19;
							}
							else if (num20 != -1)
							{
								((List<string>)variableByName9.VarArray[num19])[num20] = text19;
							}
							else
							{
								variableByName9.VarArray[num19] = text19;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num19 == -1)
								{
									variableByName9.dNumType = Convert.ToDouble(text19);
								}
								else if (num20 != -1)
								{
									((List<string>)variableByName9.VarArray[num19])[num20] = text19;
								}
								else
								{
									variableByName9.VarArray[num19] = text19;
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
						GameVariable variableByName6 = this.m_d.GetVariableByName(text);
						if (variableByName6 == null)
						{
							break;
						}
						string[] array3 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text13 = string.Empty;
						if (array3.Length == 2)
						{
							string timername = array3[0];
							string text14 = array3[1];
							Rags.Timer timer = null;
							timer = this.m_d.GetTimerByName(timername);
							if (timer != null)
							{
								foreach (CustomProperty customProperty2 in timer.CustomProperties)
								{
									if (customProperty2.Name == text14)
									{
										text13 = customProperty2.Value;
										break;
									}
								}
							}
						}
						int num13 = d(text);
						int num14 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName6.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num13 == -1)
							{
								variableByName6.sString = text13;
							}
							else if (num14 != -1)
							{
								((List<string>)variableByName6.VarArray[num13])[num14] = text13;
							}
							else
							{
								variableByName6.VarArray[num13] = text13;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num13 == -1)
								{
									variableByName6.dNumType = Convert.ToDouble(text13);
								}
								else if (num14 != -1)
								{
									((List<string>)variableByName6.VarArray[num13])[num14] = text13;
								}
								else
								{
									variableByName6.VarArray[num13] = text13;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Timer Property Value " + text13 + " is not a valid number.");
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
						GameVariable variableByName4 = this.m_d.GetVariableByName(text);
						if (variableByName4 == null)
						{
							break;
						}
						string[] array = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text8 = string.Empty;
						if (array.Length == 2)
						{
							string varname = array[0];
							string text9 = array[1];
							GameVariable gameVariable = null;
							gameVariable = this.m_d.GetVariableByName(varname);
							if (gameVariable != null)
							{
								foreach (CustomProperty customProperty3 in gameVariable.CustomProperties)
								{
									if (customProperty3.Name == text9)
									{
										text8 = customProperty3.Value;
										break;
									}
								}
							}
						}
						int num8 = d(text);
						int num9 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName4.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num8 == -1)
							{
								variableByName4.sString = text8;
							}
							else if (num9 != -1)
							{
								((List<string>)variableByName4.VarArray[num8])[num9] = text8;
							}
							else
							{
								variableByName4.VarArray[num8] = text8;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num8 == -1)
								{
									variableByName4.dNumType = Convert.ToDouble(text8);
								}
								else if (num9 != -1)
								{
									((List<string>)variableByName4.VarArray[num8])[num9] = text8;
								}
								else
								{
									variableByName4.VarArray[num8] = text8;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Variable Property Value " + text8 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
						if (text == "<Default>")
						{
							au.Source = new Uri("300px-Compass_Rose_English_North.png");
						}
						else
						{
							a(text, A_1: false);
						}
						break;
					case Command.CommandType.CT_MM_SET_UD_COMPASS:
						if (text == "<Default>")
						{
							ao.Source = new Uri("300px_Compass_Rose_UD.png");
						}
						else
						{
							b(text, A_1: false);
						}
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
					{
						GameVariable variableByName15 = this.m_d.GetVariableByName(text);
						if (variableByName15 == null)
						{
							break;
						}
						string[] array15 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text52 = string.Empty;
						if (array15.Length == 2)
						{
							string charname2 = array15[0];
							string text53 = array15[1];
							Character character4 = null;
							character4 = this.m_d.GetCharacterByName(charname2);
							if (character4 != null)
							{
								foreach (CustomProperty customProperty4 in character4.CustomProperties)
								{
									if (customProperty4.Name == text53)
									{
										text52 = customProperty4.Value;
										break;
									}
								}
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
								variableByName15.sString = text52;
							}
							else if (num38 != -1)
							{
								((List<string>)variableByName15.VarArray[num37])[num38] = text52;
							}
							else
							{
								variableByName15.VarArray[num37] = text52;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num37 == -1)
								{
									variableByName15.dNumType = Convert.ToDouble(text52);
								}
								else if (num38 != -1)
								{
									((List<string>)variableByName15.VarArray[num37])[num38] = text52;
								}
								else
								{
									variableByName15.VarArray[num37] = text52;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Character Property Value " + text52 + " is not a valid number.");
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
						GameVariable variableByName13 = this.m_d.GetVariableByName(text);
						if (variableByName13 == null)
						{
							break;
						}
						string[] array14 = text2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text46 = string.Empty;
						if (array14.Length == 2)
						{
							string text47 = array14[0];
							string text48 = array14[1];
							GameObject gameObject12 = null;
							if (text47 == "<Self>")
							{
								if (A_1 != null)
								{
									gameObject12 = A_1;
								}
							}
							else
							{
								gameObject12 = this.m_d.GetObjectByNameOld(text47);
							}
							if (gameObject12 != null)
							{
								foreach (CustomProperty customProperty5 in gameObject12.CustomProperties)
								{
									if (customProperty5.Name == text48)
									{
										text46 = customProperty5.Value;
										break;
									}
								}
							}
						}
						int num31 = d(text);
						int num32 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName13.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num31 == -1)
							{
								variableByName13.sString = text46;
							}
							else if (num32 != -1)
							{
								((List<string>)variableByName13.VarArray[num31])[num32] = text46;
							}
							else
							{
								variableByName13.VarArray[num31] = text46;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num31 == -1)
								{
									variableByName13.dNumType = Convert.ToDouble(text46);
								}
								else if (num32 != -1)
								{
									((List<string>)variableByName13.VarArray[num31])[num32] = text46;
								}
								else
								{
									variableByName13.VarArray[num31] = text46;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Item Property Value " + text46 + " is not a valid number.");
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
						GameVariable variableByName11 = this.m_d.GetVariableByName(text);
						if (variableByName11 == null)
						{
							break;
						}
						string text44 = string.Empty;
						string text45 = text2;
						foreach (CustomProperty customProperty6 in this.m_d.ThePlayer.CustomProperties)
						{
							if (customProperty6.Name == text45)
							{
								text44 = customProperty6.Value;
								break;
							}
						}
						int num27 = d(text);
						int num28 = c(text);
						this.m_d.PerformTextReplacements(text3, null);
						switch (variableByName11.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num27 == -1)
							{
								variableByName11.sString = text44;
							}
							else if (num28 != -1)
							{
								((List<string>)variableByName11.VarArray[num27])[num28] = text44;
							}
							else
							{
								variableByName11.VarArray[num27] = text44;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num27 == -1)
								{
									variableByName11.dNumType = Convert.ToDouble(text44);
								}
								else if (num28 != -1)
								{
									((List<string>)variableByName11.VarArray[num27])[num28] = text44;
								}
								else
								{
									variableByName11.VarArray[num27] = text44;
								}
							}
							catch
							{
								if (this.m_r != null)
								{
									this.m_r.AddErrorData("ERROR: Set Variable with Player Property Value " + text44 + " is not a valid number.");
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
						string text34 = this.m_d.PerformTextReplacements(text3, null);
						string[] array10 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array10.Length != 2)
						{
							break;
						}
						string text35 = array10[0];
						string text36 = array10[1];
						Room room8 = null;
						room8 = ((!(text35 == "<CurrentRoom>")) ? this.m_d.GetRoomByName(text35) : this.m_d.ThePlayer.CurrentRoom);
						if (room8 == null)
						{
							break;
						}
						for (int num26 = 0; num26 < room8.CustomProperties.Count; num26++)
						{
							CustomProperty A_14 = room8.CustomProperties[num26];
							if (A_14 != null && A_14.Name == text36)
							{
								if (command.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
								{
									object result9 = null;
									SaveLoad.EvaluateString(ref result9, text34);
									text34 = result9.ToString();
								}
								a(ref A_14, text2, text34);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
					{
						string text32 = this.m_d.PerformTextReplacements(text3, null);
						string[] array9 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array9.Length != 2)
						{
							break;
						}
						string timername2 = array9[0];
						string text33 = array9[1];
						Rags.Timer timer2 = null;
						timer2 = this.m_d.GetTimerByName(timername2);
						if (timer2 == null)
						{
							break;
						}
						for (int num25 = 0; num25 < timer2.CustomProperties.Count; num25++)
						{
							CustomProperty A_13 = timer2.CustomProperties[num25];
							if (A_13 != null && A_13.Name == text33)
							{
								if (command.cmdtype == Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS)
								{
									object result8 = null;
									SaveLoad.EvaluateString(ref result8, text32);
									text32 = result8.ToString();
								}
								a(ref A_13, text2, text32);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
					{
						string text29 = this.m_d.PerformTextReplacements(text3, null);
						string[] array8 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array8.Length != 2)
						{
							break;
						}
						string varname2 = array8[0];
						string text30 = array8[1];
						GameVariable gameVariable3 = null;
						gameVariable3 = this.m_d.GetVariableByName(varname2);
						if (gameVariable3 == null)
						{
							break;
						}
						for (int num23 = 0; num23 < gameVariable3.CustomProperties.Count; num23++)
						{
							CustomProperty A_9 = gameVariable3.CustomProperties[num23];
							if (A_9 != null && A_9.Name == text30)
							{
								if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS)
								{
									object result7 = null;
									SaveLoad.EvaluateString(ref result7, text29);
									text29 = result7.ToString();
								}
								a(ref A_9, text2, text29);
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
						GameObject gameObject3 = null;
						if (text25 == "<Self>")
						{
							if (A_1 != null)
							{
								gameObject3 = A_1;
							}
						}
						else
						{
							gameObject3 = this.m_d.GetObjectByNameOld(text25);
						}
						if (gameObject3 == null)
						{
							break;
						}
						for (int num22 = 0; num22 < gameObject3.CustomProperties.Count; num22++)
						{
							CustomProperty A_8 = gameObject3.CustomProperties[num22];
							if (A_8 != null && A_8.Name == text26)
							{
								if (command.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
								{
									object result5 = null;
									SaveLoad.EvaluateString(ref result5, text24);
									text24 = result5.ToString();
								}
								a(ref A_8, text2, text24);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
					{
						string text22 = this.m_d.PerformTextReplacements(text3, null);
						string[] array5 = text.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array5.Length != 2)
						{
							break;
						}
						string charname = array5[0];
						string text23 = array5[1];
						Character character2 = null;
						character2 = this.m_d.GetCharacterByName(charname);
						if (character2 == null)
						{
							break;
						}
						for (int num21 = 0; num21 < character2.CustomProperties.Count; num21++)
						{
							CustomProperty A_7 = character2.CustomProperties[num21];
							if (A_7 != null && A_7.Name == text23)
							{
								if (command.cmdtype == Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS)
								{
									object result4 = null;
									SaveLoad.EvaluateString(ref result4, text22);
									text22 = result4.ToString();
								}
								a(ref A_7, text2, text22);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
					{
						string text16 = this.m_d.PerformTextReplacements(text3, null);
						string text17 = text;
						for (int num16 = 0; num16 < this.m_d.ThePlayer.CustomProperties.Count; num16++)
						{
							CustomProperty A_6 = this.m_d.ThePlayer.CustomProperties[num16];
							if (A_6 != null && A_6.Name == text17)
							{
								if (command.cmdtype == Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS)
								{
									object result3 = null;
									SaveLoad.EvaluateString(ref result3, text16);
									text16 = result3.ToString();
								}
								a(ref A_6, text2, text16);
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
						int num5 = text.IndexOf("Array:");
						if (num5 > -1)
						{
							flag3 = true;
							text = text.Remove(num5, 6);
						}
						GameVariable variableByName3 = this.m_d.GetVariableByName(text);
						if (variableByName3 == null)
						{
							break;
						}
						int num6 = d(text);
						int num7 = c(text);
						string text7 = this.m_d.PerformTextReplacements(text3, null);
						text4 = this.m_d.PerformTextReplacements(text4, null);
						object result2 = null;
						if (flag2)
						{
							text7 = text7.Replace("</br>", "").Replace("<br/>", "");
							text7 = text7.Replace("</br>", "").Replace("<br/>", "");
							SaveLoad.EvaluateString(ref result2, text7);
							if (!flag3 && result2 != null)
							{
								text7 = result2.ToString();
							}
						}
						switch (variableByName3.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (text2)
							{
							case "Equals":
								if (flag3)
								{
									a(variableByName3, ref result2);
								}
								else if (num6 == -1)
								{
									variableByName3.dtDateTime = Convert.ToDateTime(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = text7;
								}
								else
								{
									variableByName3.VarArray[num6] = Convert.ToDateTime(text7);
								}
								break;
							case "Add Days":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddDays(Convert.ToInt32(text7));
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = Convert.ToDateTime(((List<string>)variableByName3.VarArray[num6])[num7]).AddDays(Convert.ToInt32(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = ((DateTime)variableByName3.VarArray[num6]).AddDays(Convert.ToInt32(text7));
								}
								break;
							case "Add Hours":
							{
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7));
									break;
								}
								if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7)).ToString();
									break;
								}
								List<object> varArray = variableByName3.VarArray;
								object value = (variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7)));
								varArray[num6] = value;
								break;
							}
							case "Add Minutes":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7));
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7));
								}
								break;
							case "Add Seconds":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7));
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7));
								}
								break;
							case "Subtract Days":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddDays(Convert.ToInt32(text7) * -1);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddDays(Convert.ToInt32(text7) * -1).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddDays(Convert.ToInt32(text7) * -1);
								}
								break;
							case "Subtract Hours":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7) * -1);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7) * -1).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddHours(Convert.ToInt32(text7) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7) * -1);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7) * -1).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddMinutes(Convert.ToInt32(text7) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7) * -1);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7) * -1).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = variableByName3.dtDateTime.AddSeconds(Convert.ToInt32(text7) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, Convert.ToInt32(text7), variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, Convert.ToInt32(text7), variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, Convert.ToInt32(text7), variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, Convert.ToInt32(text7), variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, Convert.ToInt32(text7), variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, Convert.ToInt32(text7), variableByName3.dtDateTime.Minute, variableByName3.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, Convert.ToInt32(text7), variableByName3.dtDateTime.Second);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, Convert.ToInt32(text7), variableByName3.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, Convert.ToInt32(text7), variableByName3.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num6 == -1)
								{
									variableByName3.dtDateTime = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, Convert.ToInt32(text7));
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, Convert.ToInt32(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = new DateTime(variableByName3.dtDateTime.Year, variableByName3.dtDateTime.Month, variableByName3.dtDateTime.Day, variableByName3.dtDateTime.Hour, variableByName3.dtDateTime.Minute, Convert.ToInt32(text7));
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
									a(variableByName3, ref result2);
								}
								else if (num6 == -1)
								{
									variableByName3.dNumType = Convert.ToDouble(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = text7;
								}
								else
								{
									variableByName3.VarArray[num6] = Convert.ToDouble(text7);
								}
								break;
							case "Add":
								if (num6 == -1)
								{
									variableByName3.dNumType += Convert.ToDouble(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) + Convert.ToDouble(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = (double)variableByName3.VarArray[num6] + Convert.ToDouble(text7);
								}
								break;
							case "Subtract":
								if (num6 == -1)
								{
									variableByName3.dNumType -= Convert.ToDouble(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) - Convert.ToDouble(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = (double)variableByName3.VarArray[num6] - Convert.ToDouble(text7);
								}
								break;
							case "Multiply":
								if (num6 == -1)
								{
									variableByName3.dNumType *= Convert.ToDouble(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) * Convert.ToDouble(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = (double)variableByName3.VarArray[num6] * Convert.ToDouble(text7);
								}
								break;
							case "Divide":
								if (num6 == -1)
								{
									variableByName3.dNumType /= Convert.ToDouble(text7);
								}
								else if (num7 != -1)
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) / Convert.ToDouble(text7)).ToString();
								}
								else
								{
									variableByName3.VarArray[num6] = (double)variableByName3.VarArray[num6] / Convert.ToDouble(text7);
								}
								break;
							}
							if (!variableByName3.bEnforceRestrictions)
							{
								break;
							}
							if (num6 == -1)
							{
								if (variableByName3.dNumType < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMin, null)))
								{
									variableByName3.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMin, null));
								}
								if (variableByName3.dNumType > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMax, null)))
								{
									variableByName3.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMax, null));
								}
							}
							else if (num7 != -1)
							{
								if (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMin, null)))
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = this.m_d.PerformTextReplacements(variableByName3.dMin, null).ToString();
								}
								if (Convert.ToDouble(((List<string>)variableByName3.VarArray[num6])[num7]) > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMax, null)))
								{
									((List<string>)variableByName3.VarArray[num6])[num7] = this.m_d.PerformTextReplacements(variableByName3.dMax, null).ToString();
								}
							}
							else
							{
								if ((double)variableByName3.VarArray[num6] < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMin, null)))
								{
									variableByName3.VarArray[num6] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMin, null));
								}
								if ((double)variableByName3.VarArray[num6] > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMax, null)))
								{
									variableByName3.VarArray[num6] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName3.dMax, null));
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
								a(variableByName3, ref result2);
							}
							else if (num6 == -1)
							{
								variableByName3.sString = text4;
							}
							else if (num7 != -1)
							{
								((List<string>)variableByName3.VarArray[num6])[num7] = text4;
							}
							else
							{
								variableByName3.VarArray[num6] = text4;
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
					{
						GameVariable variableByName17 = this.m_d.GetVariableByName(text);
						GameVariable variableByName18 = this.m_d.GetVariableByName(text3);
						int num41 = d(text3);
						int num42 = c(text3);
						int num43 = 0;
						double num44 = 0.0;
						if (num41 == -1)
						{
							num43 = Convert.ToInt32(variableByName18.dNumType);
							num44 = Convert.ToDouble(variableByName18.dNumType);
						}
						else if (num42 != -1)
						{
							num43 = Convert.ToInt32(((List<string>)variableByName18.VarArray[num41])[num42]);
							num44 = Convert.ToDouble(((List<string>)variableByName18.VarArray[num41])[num42]);
						}
						else
						{
							num43 = Convert.ToInt32((double)variableByName18.VarArray[num41]);
							num44 = Convert.ToDouble((double)variableByName18.VarArray[num41]);
						}
						num41 = d(text);
						int num45 = c(text);
						if (variableByName17 == null)
						{
							break;
						}
						switch (variableByName17.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (text2)
							{
							case "Equals":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = Convert.ToDateTime(num43);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = num43.ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = Convert.ToDateTime(num43);
								}
								break;
							case "Add Days":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43));
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43)).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43));
								}
								break;
							case "Add Hours":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43));
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43)).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43));
								}
								break;
							case "Add Minutes":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43));
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43)).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43));
								}
								break;
							case "Add Seconds":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43));
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43)).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43));
								}
								break;
							case "Subtract Days":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43) * -1);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43) * -1).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddDays(Convert.ToInt32(num43) * -1);
								}
								break;
							case "Subtract Hours":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43) * -1);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43) * -1).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddHours(Convert.ToInt32(num43) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43) * -1);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43) * -1).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddMinutes(Convert.ToInt32(num43) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43) * -1);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43) * -1).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = variableByName17.dtDateTime.AddSeconds(Convert.ToInt32(num43) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, Convert.ToInt32(num43), variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, Convert.ToInt32(num43), variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, Convert.ToInt32(num43), variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, Convert.ToInt32(num43), variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, Convert.ToInt32(num43), variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, Convert.ToInt32(num43), variableByName17.dtDateTime.Minute, variableByName17.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, Convert.ToInt32(num43), variableByName17.dtDateTime.Second);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, Convert.ToInt32(num43), variableByName17.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, Convert.ToInt32(num43), variableByName17.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num41 == -1)
								{
									variableByName17.dtDateTime = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, Convert.ToInt32(num43));
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, Convert.ToInt32(num43)).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = new DateTime(variableByName17.dtDateTime.Year, variableByName17.dtDateTime.Month, variableByName17.dtDateTime.Day, variableByName17.dtDateTime.Hour, variableByName17.dtDateTime.Minute, Convert.ToInt32(num43));
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							switch (text2)
							{
							case "Equals":
								if (num41 == -1)
								{
									variableByName17.dNumType = num44;
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = num43.ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = num44;
								}
								break;
							case "Add":
								if (num41 == -1)
								{
									variableByName17.dNumType += num44;
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = ((double)variableByName17.VarArray[num41] + num44).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = (double)variableByName17.VarArray[num41] + num44;
								}
								break;
							case "Subtract":
								if (num41 == -1)
								{
									variableByName17.dNumType -= num44;
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = ((double)variableByName17.VarArray[num41] - num44).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = (double)variableByName17.VarArray[num41] - num44;
								}
								break;
							case "Multiply":
								if (num41 == -1)
								{
									variableByName17.dNumType *= Convert.ToDouble(num44);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = ((double)variableByName17.VarArray[num41] * num44).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = (double)variableByName17.VarArray[num41] * num44;
								}
								break;
							case "Divide":
								if (num41 == -1)
								{
									variableByName17.dNumType /= Convert.ToDouble(num43);
								}
								else if (num45 != -1)
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = ((double)variableByName17.VarArray[num41] / num44).ToString();
								}
								else
								{
									variableByName17.VarArray[num41] = (double)variableByName17.VarArray[num41] / num44;
								}
								break;
							}
							if (!variableByName17.bEnforceRestrictions)
							{
								break;
							}
							if (num41 == -1)
							{
								if (variableByName17.dNumType < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMin, null)))
								{
									variableByName17.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMin, null));
								}
								if (variableByName17.dNumType > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMax, null)))
								{
									variableByName17.dNumType = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMax, null));
								}
							}
							else if (num45 != -1)
							{
								double num46 = Convert.ToDouble(((List<string>)variableByName17.VarArray[num41])[num45]);
								if (num46 < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMin, null)))
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = this.m_d.PerformTextReplacements(variableByName17.dMin, null);
								}
								if (num46 > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMax, null)))
								{
									((List<string>)variableByName17.VarArray[num41])[num45] = this.m_d.PerformTextReplacements(variableByName17.dMax, null);
								}
							}
							else
							{
								if ((double)variableByName17.VarArray[num41] < Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMin, null)))
								{
									variableByName17.VarArray[num41] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMin, null));
								}
								if ((double)variableByName17.VarArray[num41] > Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMax, null)))
								{
									variableByName17.VarArray[num41] = Convert.ToDouble(this.m_d.PerformTextReplacements(variableByName17.dMax, null));
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
						GameVariable variableByName16 = this.m_d.GetVariableByName(text);
						int num39 = d(text);
						int num40 = c(text);
						if (variableByName16 == null)
						{
							break;
						}
						switch (variableByName16.vartype)
						{
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (num39 == -1)
							{
								break;
							}
							switch (text2)
							{
							case "Display Date & Time":
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName16.VarArray[num39])[num40].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName16.VarArray[num39]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") + "</br>");
								}
								break;
							case "Display Date Only":
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName16.VarArray[num39])[num40]).ToString("dddd, MMMM, dd yyyy") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName16.VarArray[num39]).ToString("dddd, MMMM, dd yyyy") + "</br>");
								}
								break;
							case "Display Time Only":
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName16.VarArray[num39])[num40]).ToString("hh:mm:ss tt") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName16.VarArray[num39]).ToString("hh:mm:ss tt") + "</br>");
								}
								break;
							case "Display Weekday Only":
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, Convert.ToDateTime(((List<string>)variableByName16.VarArray[num39])[num40]).ToString("dddd") + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((DateTime)variableByName16.VarArray[num39]).ToString("dddd") + "</br>");
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							switch (text2)
							{
							case "Display Date & Time":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") + "</br>");
								break;
							case "Display Date Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.dtDateTime.ToString("dddd, MMMM, dd yyyy") + "</br>");
								break;
							case "Display Time Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.dtDateTime.ToString("hh:mm:ss tt") + "</br>");
								break;
							case "Display Weekday Only":
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.dtDateTime.ToString("dddd") + "</br>");
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (num39 != -1)
							{
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName16.VarArray[num39])[num40].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, (double)variableByName16.VarArray[num39] + "</br>");
								}
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.dNumType + "</br>");
							break;
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num39 != -1)
							{
								if (num40 != -1)
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, ((List<string>)variableByName16.VarArray[num39])[num40].ToString() + "</br>");
								}
								else
								{
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.VarArray[num39].ToString() + "</br>");
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
							SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, variableByName16.sString + "</br>");
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
						c(text, A_1: false);
						break;
					case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
						if (text == "<None>")
						{
							text = "";
						}
						this.m_d.ThePlayer.PlayerLayeredImage = text;
						c(text, A_1: true);
						break;
					case Command.CommandType.CT_DISPLAYPICTURE:
						if (this.m_d.bHideMainPicDisplay)
						{
							_ = this.m_d.bUseInlineImages;
						}
						if (!this.m_d.bHideMainPicDisplay)
						{
							object pictureByName3 = SaveLoad.GetPictureByName(text, ref this.m_d);
							if (pictureByName3 != string.Empty)
							{
								this.w.Source = new Uri(pictureByName3 as string);
							}
						}
						break;
					case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
					{
						object pictureByName = SaveLoad.GetPictureByName(text, ref this.m_d);
						be.Source = new Uri(pictureByName as string);
						break;
					}
					case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
						be.Stop();
						break;
					case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
					{
						object pictureByName2 = SaveLoad.GetPictureByName(text, ref this.m_d);
						bf.Source = new Uri(pictureByName2 as string);
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
						string text27 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName4 = gameObject6.GetActionByName(actionname4);
						if (actionByName4 != null)
						{
							if (text27 == "Active")
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
						string text18 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName3 = characterByName3.GetActionByName(actionname3);
						if (actionByName3 != null)
						{
							if (text18 == "Active")
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
						Room room4 = null;
						try
						{
							room4 = this.m_d.GetRoomByID(new Guid(text));
						}
						catch
						{
							room4 = this.m_d.GetRoomByName(text);
						}
						if (room4 != null)
						{
							room4.SDesc = text3;
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
						string text12 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName2 = this.m_d.ThePlayer.GetActionByName(actionname2);
						if (actionByName2 != null)
						{
							if (text12 == "Active")
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
						string actionname = text2.Substring(0, text2.LastIndexOf('-'));
						string text5 = text2.Substring(text2.LastIndexOf('-') + 1);
						Rags.Action actionByName = room.GetActionByName(actionname);
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
						if (gameObject14 != null)
						{
							if (text2 == "Open")
							{
								gameObject14.bOpen = true;
							}
							else
							{
								gameObject14.bOpen = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETITEMTOWORN:
					{
						GameObject gameObject11 = null;
						if (text.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject11 = A_1;
							}
						}
						else
						{
							gameObject11 = this.m_d.GetObjectByName(text);
							if (gameObject11 == null)
							{
								gameObject11 = this.m_d.GetObjectByNameOld(text);
							}
						}
						if (gameObject11 != null)
						{
							if (text2 == "Worn")
							{
								gameObject11.bWorn = true;
							}
							else
							{
								gameObject11.bWorn = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYCHARDESC:
					{
						Character characterByName7 = this.m_d.GetCharacterByName(text);
						SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, characterByName7.Description + "</br>");
						bool flag10 = false;
						if (this.m_d.bTurnOffNotifications)
						{
							break;
						}
						foreach (GameObject object9 in this.m_d.ObjectList)
						{
							if (object9.locationtype == GameObject.LocationType.LT_CHARACTER && object9.locationname == text && object9.bWorn && object9.bVisible)
							{
								if (!flag10)
								{
									flag10 = true;
									SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, characterByName7.ToString() + " is wearing:</br>");
								}
								SaveLoad.AddTextToRTF(ref this.y, ref this.m_d, object9.GetDisplayString() + "</br>");
							}
						}
						flag10 = false;
						foreach (GameObject object10 in this.m_d.ObjectList)
						{
							if (object10.locationtype == GameObject.LocationType.LT_CHARACTER && object10.locationname == text && !object10.bWorn && object10.bVisible)
							{
								if (!flag10)
								{
									flag10 = true;
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
						string text31 = string.Empty;
						try
						{
							new Guid(text2);
							text31 = text2;
						}
						catch
						{
							Room roomByName = this.m_d.GetRoomByName(text2);
							if (roomByName != null)
							{
								text31 = roomByName.UniqueID.ToString();
								text2 = text31;
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
								text31 = text2;
							}
							catch
							{
								Room roomByName2 = this.m_d.GetRoomByName(text2);
								if (roomByName2 != null)
								{
									text31 = roomByName2.UniqueID.ToString();
								}
							}
							if (text31 == string.Empty)
							{
								MessageBox.Show("Error in command CT_MoveChar.  Could not locate a room called " + text2);
								break;
							}
							this.m_d.GetCharacterByName(text).CurrentRoom = text31;
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
							additionalInputWindow2 = new AdditionalInputWindow(actionInputType2, ref inv2, ref a9, ref bb);
							((Window)additionalInputWindow2).Owner = (Window)(object)this;
						}
						else
						{
							additionalInputWindow2 = new AdditionalInputWindow(actionInputType2, ref bd, ref a9, ref bb);
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
							Point val4 = ((UIElement)this.v).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this);
							val4 = ((Visual)this).PointToScreen(val4);
							((Window)additionalInputWindow2).Left = val4.X;
							((Window)additionalInputWindow2).Top = val4.Y;
							((FrameworkElement)additionalInputWindow2).Height = ((FrameworkElement)this.v).ActualHeight;
							((FrameworkElement)additionalInputWindow2).Width = ((FrameworkElement)this.v).ActualWidth;
							DoubleAnimation val5 = new DoubleAnimation();
							val5.From = 0.0;
							val5.To = 1.0;
							((Timeline)val5).Duration = new Duration(TimeSpan.FromSeconds(0.5));
							((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
							{
							}));
							object obj13 = this.y.InvokeScript("atbottom");
							bool flag6 = Convert.ToBoolean(obj13.ToString());
							while (!flag6)
							{
								((DispatcherObject)Application.Current).Dispatcher.Invoke((DispatcherPriority)4, (Delegate)(System.Action)(() =>
								{
								}));
								flag6 = Convert.ToBoolean(obj13.ToString());
							}
							((UIElement)additionalInputWindow2).BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val5);
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
						GameVariable variableByName8 = this.m_d.GetVariableByName(text2);
						int num17 = d(text2);
						int num18 = c(text2);
						if (variableByName8 == null)
						{
							break;
						}
						switch (actionInputType2)
						{
						case Rags.Action.ActionInputType.Custom:
						{
							string empty4 = string.Empty;
							variableByName8.sString = string.Empty;
							if (empty4 != string.Empty)
							{
								if (num17 == -1)
								{
									variableByName8.dNumType = a(variableByName8, empty4);
								}
								else if (num18 != -1)
								{
									((List<string>)variableByName8.VarArray[num17])[num18] = string.Empty;
									((List<string>)variableByName8.VarArray[num17])[num18] = a(variableByName8, empty4).ToString();
								}
								else
								{
									variableByName8.VarArray[num17] = string.Empty;
									variableByName8.VarArray[num17] = a(variableByName8, empty4).ToString();
								}
							}
							break;
						}
						case Rags.Action.ActionInputType.Text:
							if (num17 == -1)
							{
								variableByName8.dNumType = a(variableByName8, additionalInputWindow2.e.Text);
							}
							else if (num18 != -1)
							{
								((List<string>)variableByName8.VarArray[num17])[num18] = a(variableByName8, additionalInputWindow2.e.Text).ToString();
							}
							else
							{
								variableByName8.VarArray[num17] = a(variableByName8, additionalInputWindow2.e.Text).ToString();
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
							additionalInputWindow = new AdditionalInputWindow(actionInputType, ref inv, ref a9, ref bb);
							((Window)additionalInputWindow).Owner = (Window)(object)this;
						}
						else
						{
							additionalInputWindow = new AdditionalInputWindow(actionInputType, ref bd, ref a9, ref bb);
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
		((ItemsControl)bd).Items.Clear();
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
					((ItemsControl)bd).Items.Insert(0, (object)@object);
				}
				else
				{
					((ItemsControl)bd).Items.Add((object)@object);
				}
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref bd, a_);
				}
			}
		}
		for (int num = ((CollectionView)((ItemsControl)bd).Items).Count - 1; num >= 0; num--)
		{
			if (((ItemsControl)bd).Items[num] is GameObject { bImportant: not false } gameObject)
			{
				((ItemsControl)bd).Items.Remove((object)gameObject);
				((ItemsControl)bd).Items.Insert(0, (object)gameObject);
			}
		}
	}

	private void w()
	{
		GameObject a_ = null;
		((ItemsControl)a9).Items.Clear();
		if (this.m_d == null)
		{
			return;
		}
		foreach (GameObject @object in this.m_d.ObjectList)
		{
			if (this.m_d.ThePlayer.CurrentRoom != null && @object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString() && @object.bVisible)
			{
				((ItemsControl)a9).Items.Add((object)@object);
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref a9, a_);
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
			foreach (GameObject item in (IEnumerable)((ItemsControl)a9).Items)
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
				((ItemsControl)a9).Items.Add((object)gameObject3);
				if (gameObject3.bContainer && (!gameObject3.bOpenable || gameObject3.bOpen))
				{
					a(gameObject3, ref a9, a_);
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
		if (((Selector)bb).SelectedItem != null)
		{
			_ = ((Selector)bb).SelectedItem;
		}
		((ItemsControl)bb).Items.Clear();
		foreach (Character character in this.m_d.CharacterList)
		{
			if (this.m_d.ThePlayer.CurrentRoom == null || !(character.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			((ItemsControl)bb).Items.Add((object)character);
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
						((ItemsControl)bb).Items.Insert(0, (object)@object);
					}
					else
					{
						((ItemsControl)bb).Items.Add((object)@object);
					}
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
		((UIElement)a5).IsEnabled = false;
		((UIElement)a8).IsEnabled = false;
		((UIElement)ba).IsEnabled = false;
		((UIElement)bc).IsEnabled = false;
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
					((UIElement)av).Visibility = (Visibility)0;
					((FrameworkElement)av).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)av).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.South:
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
			case Exit.Directions.West:
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
			case Exit.Directions.East:
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
					((UIElement)az).Visibility = (Visibility)0;
					((FrameworkElement)az).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)az).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.NorthEast:
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
			case Exit.Directions.SouthWest:
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
			case Exit.Directions.SouthEast:
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
			case Exit.Directions.In:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)a3).Visibility = (Visibility)0;
					((FrameworkElement)a3).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)a3).Visibility = (Visibility)1;
				}
				break;
			case Exit.Directions.Out:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((UIElement)a4).Visibility = (Visibility)0;
					((FrameworkElement)a4).ToolTip = this.m_d.GetRoomByID(new Guid(exit.DestinationRoom)).GetName();
				}
				else
				{
					((UIElement)a4).Visibility = (Visibility)1;
				}
				break;
			}
		}
	}

	private void c(string A_0, bool A_1)
	{
		if (!(A_0 == string.Empty))
		{
			A_0 = this.m_d.PerformTextReplacements(A_0, null);
			object pictureByName = SaveLoad.GetPictureByName(A_0, ref this.m_d);
			if (pictureByName != null && pictureByName as string != "")
			{
				a7.Source = new Uri(pictureByName as string);
			}
		}
	}

	private void b(string A_0, bool A_1)
	{
		if (!(A_0 == string.Empty))
		{
			A_0 = this.m_d.PerformTextReplacements(A_0, null);
			object pictureByName = SaveLoad.GetPictureByName(A_0, ref this.m_d);
			if (pictureByName != null && pictureByName as string != "")
			{
				ao.Source = new Uri(pictureByName as string);
			}
		}
	}

	private void a(string A_0, bool A_1)
	{
		if (!(A_0 == string.Empty))
		{
			A_0 = this.m_d.PerformTextReplacements(A_0, null);
			object pictureByName = SaveLoad.GetPictureByName(A_0, ref this.m_d);
			if (pictureByName != null && pictureByName as string != "")
			{
				au.Source = new Uri(pictureByName as string);
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
		c(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
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
		if (((Selector)bb).SelectedItem != null)
		{
			_ = ((Selector)bb).SelectedItem;
		}
		((ItemsControl)bb).Items.Clear();
		foreach (Character character in this.m_d.CharacterList)
		{
			if (!(character.CurrentRoom == this.m_d.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			((ItemsControl)bb).Items.Add((object)character);
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
					((ItemsControl)bb).Items.Add((object)@object);
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
		for (int i = 0; i < ((CollectionView)((ItemsControl)bb).Items).Count; i++)
		{
			object obj = ((ItemsControl)bb).Items[i];
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

	private void p(object A_0, RoutedEventArgs A_1)
	{
		m();
		this.m_f = false;
		if (A_0 == av)
		{
			this.m_l = Exit.Directions.North;
		}
		else if (A_0 == aw)
		{
			this.m_l = Exit.Directions.South;
		}
		else if (A_0 == ax)
		{
			this.m_l = Exit.Directions.East;
		}
		else if (A_0 == ay)
		{
			this.m_l = Exit.Directions.West;
		}
		else if (A_0 == az)
		{
			this.m_l = Exit.Directions.NorthWest;
		}
		else if (A_0 == a0)
		{
			this.m_l = Exit.Directions.NorthEast;
		}
		else if (A_0 == a1)
		{
			this.m_l = Exit.Directions.SouthWest;
		}
		else if (A_0 == a2)
		{
			this.m_l = Exit.Directions.SouthEast;
		}
		else if (A_0 == a3)
		{
			this.m_l = Exit.Directions.In;
		}
		else if (A_0 == a4)
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
		if (((Selector)a9).SelectedItem is GameObject gameObject)
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
		Character character = ((Selector)bb).SelectedItem as Character;
		GameObject gameObject = ((Selector)bb).SelectedItem as GameObject;
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
		if (((Selector)bd).SelectedItem is GameObject gameObject)
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
			((UIElement)a5).IsEnabled = true;
			((UIElement)a8).IsEnabled = true;
			((UIElement)ba).IsEnabled = true;
			((UIElement)bc).IsEnabled = true;
			((UIElement)this.z).IsEnabled = false;
			aa();
			x();
			w();
			c(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
			c(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
			a(A_0: true, A_1: false);
			if (this.m_d.bgMusic != string.Empty)
			{
				object pictureByName = SaveLoad.GetPictureByName(this.m_d.bgMusic, ref this.m_d);
				if (pictureByName != null && pictureByName is string uriString)
				{
					be.Source = new Uri(uriString);
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

	private void o(object A_0, RoutedEventArgs A_1)
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
				o(null, null);
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
		s(null, null);
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
		((UIElement)a5).IsEnabled = true;
		((UIElement)a8).IsEnabled = true;
		((UIElement)ba).IsEnabled = true;
		((UIElement)bc).IsEnabled = true;
		((UIElement)this.z).IsEnabled = false;
		aa();
		x();
		w();
		c(this.m_d.ThePlayer.PlayerPortrait, A_1: false);
		c(this.m_d.ThePlayer.PlayerLayeredImage, A_1: true);
		a(A_0: true, A_1: false);
		if (this.m_d.bgMusic != string.Empty)
		{
			object pictureByName = SaveLoad.GetPictureByName(this.m_d.bgMusic, ref this.m_d);
			if (pictureByName != null && pictureByName is string uriString)
			{
				be.Source = new Uri(uriString);
			}
		}
		this.m_n = false;
		if (this.m_r != null)
		{
			this.m_r.Window_Loaded(null, null);
		}
	}

	private void n(object A_0, RoutedEventArgs A_1)
	{
		bool a_ = true;
		if (this.m_d == null)
		{
			a_ = false;
		}
		a(a_);
	}

	private void m(object A_0, RoutedEventArgs A_1)
	{
		AboutWindow aboutWindow = new AboutWindow();
		((Window)aboutWindow).Owner = (Window)(object)this;
		((Window)aboutWindow).ShowDialog();
	}

	private void l(object A_0, RoutedEventArgs A_1)
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
		g(null, null);
		h(null, null);
		j(null, null);
		k(null, null);
		i(null, null);
	}

	private void k(object A_0, RoutedEventArgs A_1)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.PlayerPortrait, ref this.m_d);
		if (gamePictureByName == null)
		{
			return;
		}
		if (((Panel)a5).Children.Count > 1)
		{
			((Panel)a5).Children.RemoveRange(1, ((Panel)a5).Children.Count - 1);
		}
		for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
		{
			Image val = new Image();
			string text = Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]);
			if (!File.Exists(text))
			{
				SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			}
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(text);
			((Panel)a5).Children.Add((UIElement)(object)val);
		}
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(Path.GetFileName(this.w.Source.ToString()), ref this.m_d);
		if (gamePictureByName == null)
		{
			return;
		}
		if (((Panel)this.u).Children.Count > 1)
		{
			((Panel)this.u).Children.RemoveRange(1, ((Panel)this.u).Children.Count - 1);
		}
		for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
		{
			Image val = new Image();
			string text = Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]);
			if (!File.Exists(text))
			{
				SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			}
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(text);
			((Panel)this.u).Children.Add((UIElement)(object)val);
		}
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(this.m_d.ThePlayer.CurrentRoom.Name, ref this.m_d);
		if (gamePictureByName == null)
		{
			return;
		}
		if (((Panel)this.aa).Children.Count > 1)
		{
			((Panel)this.aa).Children.RemoveRange(1, ((Panel)this.aa).Children.Count - 1);
		}
		for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
		{
			Image val = new Image();
			string text = Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]);
			if (!File.Exists(text))
			{
				SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			}
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(text);
			((Panel)this.aa).Children.Add((UIElement)(object)val);
		}
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		string path = au.Source.ToString();
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(Path.GetFileName(path), ref this.m_d);
		if (gamePictureByName == null)
		{
			return;
		}
		if (((Panel)an).Children.Count > 1)
		{
			((Panel)an).Children.RemoveRange(1, ((Panel)an).Children.Count - 1);
		}
		for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
		{
			SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			Image val = new Image();
			string text = Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]);
			if (!File.Exists(text))
			{
				SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			}
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(text);
			((Panel)an).Children.Add((UIElement)(object)val);
		}
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		string path = au.Source.ToString();
		GamePicture gamePictureByName = SaveLoad.GetGamePictureByName(Path.GetFileName(path), ref this.m_d);
		if (gamePictureByName == null)
		{
			return;
		}
		if (((Panel)@as).Children.Count > 1)
		{
			((Panel)@as).Children.RemoveRange(1, ((Panel)@as).Children.Count - 1);
		}
		for (int i = 0; i < gamePictureByName.LayeredImages.Count; i++)
		{
			Image val = new Image();
			string text = Path.Combine(Path.GetTempPath(), gamePictureByName.LayeredImages[i]);
			if (!File.Exists(text))
			{
				SaveLoad.GetPictureByName(gamePictureByName.LayeredImages[i], ref this.m_d);
			}
			val.Source = (ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(text);
			((Panel)@as).Children.Add((UIElement)(object)val);
		}
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		o();
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		n();
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		SaveLoad.CorrectCommandAndConditions(ref this.m_d);
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		bf.Play();
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		be.Play();
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		((Selector)a9).SelectedIndex = -1;
		((Selector)bd).SelectedIndex = -1;
		((Selector)bb).SelectedIndex = -1;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		GameInfoWindow gameInfoWindow = new GameInfoWindow(ref this.m_d);
		((Window)gameInfoWindow).ShowDialog();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected Obj, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Obj, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected Obj, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected Obj, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected Obj, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected Obj, but got Unknown
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
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Obj, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected Obj, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected Obj, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected Obj, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected Obj, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected Obj, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected Obj, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected Obj, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected Obj, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected Obj, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected Obj, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Obj, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected Obj, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected Obj, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected Obj, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected Obj, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected Obj, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected Obj, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected Obj, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected Obj, but got Unknown
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected Obj, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected Obj, but got Unknown
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
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected Obj, but got Unknown
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Expected Obj, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected Obj, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected Obj, but got Unknown
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Expected Obj, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected Obj, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected Obj, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected Obj, but got Unknown
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected Obj, but got Unknown
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected Obj, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected Obj, but got Unknown
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Expected Obj, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected Obj, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected Obj, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected Obj, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected Obj, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected Obj, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected Obj, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected Obj, but got Unknown
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Expected Obj, but got Unknown
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Expected Obj, but got Unknown
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Expected Obj, but got Unknown
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Expected Obj, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			((Window)(MainWindow)target).Closing += a;
			((Window)(MainWindow)target).Closed += a;
			((UIElement)(MainWindow)target).KeyDown += a;
			((FrameworkElement)(MainWindow)target).Loaded += l;
			break;
		case 2:
			this.s = (Grid)target;
			break;
		case 3:
			((MenuItem)target).Click += q;
			break;
		case 4:
			((MenuItem)target).Click += o;
			break;
		case 5:
			((MenuItem)target).Click += n;
			break;
		case 6:
			((MenuItem)target).Click += r;
			break;
		case 7:
			((MenuItem)target).Click += f;
			break;
		case 8:
			((MenuItem)target).Click += e;
			break;
		case 9:
			((MenuItem)target).Click += d;
			break;
		case 10:
			this.t = (MenuItem)target;
			break;
		case 11:
			((MenuItem)target).Click += m;
			break;
		case 12:
			((MenuItem)target).Click += a;
			break;
		case 13:
			this.u = (Grid)target;
			break;
		case 14:
			this.v = (Border)target;
			break;
		case 15:
			this.w = (MediaElement)target;
			this.w.MediaOpened += j;
			break;
		case 16:
			this.x = (Border)target;
			break;
		case 17:
			this.y = (WebBrowser)target;
			this.y.LoadCompleted += a;
			break;
		case 18:
			this.z = (Button)target;
			((ButtonBase)this.z).Click += s;
			break;
		case 19:
			this.aa = (Grid)target;
			((UIElement)this.aa).MouseDown += a;
			break;
		case 20:
			this.ab = (Border)target;
			break;
		case 21:
			ac = (MediaElement)target;
			ac.MediaOpened += i;
			break;
		case 22:
			ad = (Label)target;
			break;
		case 23:
			ae = (Border)target;
			break;
		case 24:
			af = (StatusBar)target;
			break;
		case 25:
			ag = (Grid)target;
			break;
		case 26:
			ah = (ColumnDefinition)target;
			break;
		case 27:
			ai = (ColumnDefinition)target;
			break;
		case 28:
			aj = (ColumnDefinition)target;
			break;
		case 29:
			ak = (ColumnDefinition)target;
			break;
		case 30:
			al = (ColumnDefinition)target;
			break;
		case 31:
			am = (ColumnDefinition)target;
			break;
		case 32:
			an = (Grid)target;
			break;
		case 33:
			ao = (MediaElement)target;
			ao.MediaOpened += h;
			break;
		case 34:
			ap = (Button)target;
			((ButtonBase)ap).Click += p;
			break;
		case 35:
			aq = (Button)target;
			((ButtonBase)aq).Click += p;
			break;
		case 36:
			ar = (Grid)target;
			break;
		case 37:
			@as = (Grid)target;
			break;
		case 38:
			at = (Border)target;
			break;
		case 39:
			au = (MediaElement)target;
			au.MediaOpened += g;
			break;
		case 40:
			av = (Button)target;
			((ButtonBase)av).Click += p;
			break;
		case 41:
			aw = (Button)target;
			((ButtonBase)aw).Click += p;
			break;
		case 42:
			ax = (Button)target;
			((ButtonBase)ax).Click += p;
			break;
		case 43:
			ay = (Button)target;
			((ButtonBase)ay).Click += p;
			break;
		case 44:
			az = (Button)target;
			((ButtonBase)az).Click += p;
			break;
		case 45:
			a0 = (Button)target;
			((ButtonBase)a0).Click += p;
			break;
		case 46:
			a1 = (Button)target;
			((ButtonBase)a1).Click += p;
			break;
		case 47:
			a2 = (Button)target;
			((ButtonBase)a2).Click += p;
			break;
		case 48:
			a3 = (Button)target;
			((ButtonBase)a3).Click += p;
			break;
		case 49:
			a4 = (Button)target;
			((ButtonBase)a4).Click += p;
			break;
		case 50:
			a5 = (Grid)target;
			((UIElement)a5).MouseDown += b;
			break;
		case 51:
			a6 = (Border)target;
			break;
		case 52:
			a7 = (MediaElement)target;
			a7.MediaOpened += k;
			break;
		case 53:
			a8 = (Grid)target;
			break;
		case 54:
			a9 = (ListBox)target;
			((Selector)a9).SelectionChanged += c;
			((UIElement)a9).MouseEnter += a;
			break;
		case 55:
			ba = (Grid)target;
			break;
		case 56:
			bb = (ListBox)target;
			((Selector)bb).SelectionChanged += b;
			((UIElement)bb).MouseEnter += a;
			break;
		case 57:
			bc = (Grid)target;
			break;
		case 58:
			bd = (ListBox)target;
			((Selector)bd).SelectionChanged += a;
			((UIElement)bd).MouseEnter += a;
			break;
		case 59:
			be = (MediaElement)target;
			((FrameworkElement)be).Loaded += b;
			break;
		case 60:
			bf = (MediaElement)target;
			((FrameworkElement)bf).Loaded += c;
			break;
		default:
			bg = true;
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
