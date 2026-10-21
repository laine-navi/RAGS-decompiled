using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using AxWMPLib;
using Microsoft.JScript;
using Microsoft.Win32;
using Rags.Properties;
using Rags.ragsgame.com;

namespace Rags;

public class frmMain : Form
{
	public class myObjectSortClass : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			GameObject gameObject = x as GameObject;
			GameObject gameObject2 = y as GameObject;
			if (gameObject != null && gameObject2 != null)
			{
				return gameObject.ToString().CompareTo(gameObject2.ToString());
			}
			return 0;
		}
	}

	public class myCharacterSortClass : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			Character character = x as Character;
			Character character2 = y as Character;
			if (character != null && character2 != null)
			{
				try
				{
					return character.ToString().CompareTo(character2.ToString());
				}
				catch (Exception)
				{
					return 0;
				}
			}
			return 0;
		}
	}

	private enum a
	{
		a,
		b
	}

	public delegate void LiveTimer(object sender);

	private enum b
	{
		a,
		b,
		c,
		d,
		e
	}

	private static bool m_a;

	private string m_b = string.Empty;

	private bool m_c;

	private static bool m_d;

	private static string m_e;

	private static bool m_f;

	private static bool m_g;

	private bool m_h;

	private DebugDataFrm m_i;

	private MainMenu m_j;

	private MenuItem m_k;

	private MenuItem m_l;

	private MenuItem m_m;

	private MenuItem m_n;

	private IContainer m_o;

	private OpenFileDialog m_p;

	private ContextMenuStrip m_q;

	private SplitContainer m_r;

	private SplitContainer m_s;

	private PictureBox m_t;

	private RichTextBox m_u;

	private Label m_v;

	public ListBox lbCharacters;

	private Label m_w;

	private Label m_x;

	public ListBox lbRoomObjects;

	public ListBox lbInventory;

	private PictureBox m_y;

	private Panel m_z;

	private Panel m_aa;

	private SplitContainer m_ab;

	private SplitContainer m_ac;

	private SplitContainer m_ad;

	private SplitContainer m_ae;

	private PictureBox m_af;

	private PictureBox m_ag;

	private PictureBox m_ah;

	private PictureBox m_ai;

	private PictureBox m_aj;

	private PictureBox m_ak;

	private PictureBox m_al;

	private PictureBox m_am;

	private PictureBox m_an;

	private PictureBox m_ao;

	private string ap = string.Empty;

	private MenuItem aq;

	private SaveFileDialog ar;

	private OpenFileDialog @as;

	private Panel at;

	private Color au = Color.ForestGreen;

	private MenuItem av;

	private MenuItem aw;

	private RichTextBox ax;

	private StatusStrip ay;

	private Timer az;

	private MenuItem a0;

	private MenuItem a1;

	private Label a2;

	private Button a3;

	private MenuItem a4;

	private SaveData a5;

	private MemoryStream a6;

	private MenuItem a7;

	private SaveFileDialog a8;

	private PictureBox a9;

	private MenuItem ba;

	private ToolTip bb;

	private object bc;

	private Random bd = new Random();

	private bool be;

	private Exit.Directions bf;

	private PictureBox bg;

	private PictureBox bh;

	private MenuItem bi;

	private string bj = string.Empty;

	private string bk = string.Empty;

	private string bl = string.Empty;

	private string bm = string.Empty;

	private string bn = string.Empty;

	private PictureBox bo;

	private PictureBox bp;

	private SaveData bq;

	private MemoryStream br = new MemoryStream();

	private MenuItem bs;

	private FontDialog bt;

	private MenuItem bu;

	private MenuItem bv;

	private List<RagsThread> bw = new List<RagsThread>();

	private static Game bx;

	private AxWindowsMediaPlayer by;

	private AxWindowsMediaPlayer bz;

	private AxWindowsMediaPlayer b0;

	private AxWindowsMediaPlayer b1;

	private bool b2;

	private AxWindowsMediaPlayer b3;

	private Panel b4;

	private static Action b5;

	private MenuItem b6;

	private MenuItem b7;

	[CompilerGenerated]
	private LiveTimer b8;

	private Thread b9;

	private b ca;

	public event LiveTimer OnLiveTimerEvent
	{
		[CompilerGenerated]
		add
		{
			LiveTimer liveTimer = b8;
			LiveTimer liveTimer2;
			do
			{
				liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Combine(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref b8, value2, liveTimer2);
			}
			while ((object)liveTimer != liveTimer2);
		}
		[CompilerGenerated]
		remove
		{
			LiveTimer liveTimer = b8;
			LiveTimer liveTimer2;
			do
			{
				liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Remove(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref b8, value2, liveTimer2);
			}
			while ((object)liveTimer != liveTimer2);
		}
	}

	public frmMain()
	{
		try
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
		}
		catch
		{
		}
		v();
		OnLiveTimerEvent += b;
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
					((Control)this).Invoke((Delegate)b8, new object[1] { ragsThread.CurTimer });
				}
			}
			catch
			{
				break;
			}
		}
	}

	private void b(object A_0)
	{
		if (A_0 is Timer a_)
		{
			a(a_);
		}
		o();
		m();
		l();
		h();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_o != null)
		{
			this.m_o.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void v()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected Obj, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected Obj, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected Obj, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected Obj, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected Obj, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected Obj, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected Obj, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Obj, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Obj, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected Obj, but got Unknown
		//IL_0c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c91: Expected Obj, but got Unknown
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Expected Obj, but got Unknown
		//IL_0d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6d: Expected Obj, but got Unknown
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Expected Obj, but got Unknown
		//IL_0e97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea1: Expected Obj, but got Unknown
		//IL_0f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f33: Expected Obj, but got Unknown
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Expected Obj, but got Unknown
		//IL_1038: Unknown result type (might be due to invalid IL or missing references)
		//IL_1042: Expected Obj, but got Unknown
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1059: Expected Obj, but got Unknown
		//IL_112f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1139: Expected Obj, but got Unknown
		//IL_1219: Unknown result type (might be due to invalid IL or missing references)
		//IL_1223: Expected Obj, but got Unknown
		//IL_1230: Unknown result type (might be due to invalid IL or missing references)
		//IL_123a: Expected Obj, but got Unknown
		//IL_1285: Unknown result type (might be due to invalid IL or missing references)
		//IL_128f: Expected Obj, but got Unknown
		//IL_14b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c1: Expected Obj, but got Unknown
		//IL_157d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1587: Expected Obj, but got Unknown
		//IL_17c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cd: Expected Obj, but got Unknown
		//IL_1855: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected Obj, but got Unknown
		//IL_1a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a14: Expected Obj, but got Unknown
		//IL_1ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1adc: Expected Obj, but got Unknown
		//IL_1b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba3: Expected Obj, but got Unknown
		//IL_1c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c69: Expected Obj, but got Unknown
		//IL_1d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d30: Expected Obj, but got Unknown
		//IL_1e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0e: Expected Obj, but got Unknown
		//IL_1ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Expected Obj, but got Unknown
		//IL_1f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f90: Expected Obj, but got Unknown
		//IL_2176: Unknown result type (might be due to invalid IL or missing references)
		//IL_2180: Expected Obj, but got Unknown
		//IL_218d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2197: Expected Obj, but got Unknown
		//IL_21a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ae: Expected Obj, but got Unknown
		//IL_2280: Unknown result type (might be due to invalid IL or missing references)
		//IL_228a: Expected Obj, but got Unknown
		//IL_2452: Unknown result type (might be due to invalid IL or missing references)
		//IL_245c: Expected Obj, but got Unknown
		//IL_2469: Unknown result type (might be due to invalid IL or missing references)
		//IL_2473: Expected Obj, but got Unknown
		//IL_2480: Unknown result type (might be due to invalid IL or missing references)
		//IL_248a: Expected Obj, but got Unknown
		//IL_2634: Unknown result type (might be due to invalid IL or missing references)
		//IL_263e: Expected Obj, but got Unknown
		//IL_264b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2655: Expected Obj, but got Unknown
		//IL_2662: Unknown result type (might be due to invalid IL or missing references)
		//IL_266c: Expected Obj, but got Unknown
		//IL_2740: Unknown result type (might be due to invalid IL or missing references)
		//IL_274a: Expected Obj, but got Unknown
		//IL_2757: Unknown result type (might be due to invalid IL or missing references)
		//IL_2761: Expected Obj, but got Unknown
		//IL_276e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2778: Expected Obj, but got Unknown
		//IL_290f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2919: Expected Obj, but got Unknown
		//IL_294a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2954: Expected Obj, but got Unknown
		//IL_2992: Unknown result type (might be due to invalid IL or missing references)
		//IL_299c: Expected Obj, but got Unknown
		this.m_o = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
		this.m_j = new MainMenu(this.m_o);
		this.m_k = new MenuItem();
		this.m_l = new MenuItem();
		this.m_n = new MenuItem();
		aq = new MenuItem();
		a7 = new MenuItem();
		this.m_m = new MenuItem();
		a4 = new MenuItem();
		bs = new MenuItem();
		b6 = new MenuItem();
		b7 = new MenuItem();
		a0 = new MenuItem();
		a1 = new MenuItem();
		bi = new MenuItem();
		bu = new MenuItem();
		av = new MenuItem();
		aw = new MenuItem();
		ba = new MenuItem();
		bv = new MenuItem();
		this.m_p = new OpenFileDialog();
		this.m_q = new ContextMenuStrip(this.m_o);
		this.m_r = new SplitContainer();
		this.m_s = new SplitContainer();
		a3 = new Button();
		a2 = new Label();
		this.m_aa = new Panel();
		this.m_u = new RichTextBox();
		ax = new RichTextBox();
		a9 = new PictureBox();
		bo = new PictureBox();
		b0 = new AxWindowsMediaPlayer();
		this.m_t = new PictureBox();
		by = new AxWindowsMediaPlayer();
		this.m_ab = new SplitContainer();
		this.m_z = new Panel();
		b4 = new Panel();
		this.m_ao = new PictureBox();
		this.m_an = new PictureBox();
		at = new Panel();
		b1 = new AxWindowsMediaPlayer();
		bz = new AxWindowsMediaPlayer();
		bg = new PictureBox();
		bh = new PictureBox();
		this.m_ai = new PictureBox();
		this.m_ak = new PictureBox();
		this.m_ah = new PictureBox();
		this.m_al = new PictureBox();
		this.m_ag = new PictureBox();
		this.m_am = new PictureBox();
		this.m_af = new PictureBox();
		this.m_aj = new PictureBox();
		this.m_ac = new SplitContainer();
		this.m_y = new PictureBox();
		bp = new PictureBox();
		b3 = new AxWindowsMediaPlayer();
		this.m_ad = new SplitContainer();
		this.m_w = new Label();
		lbRoomObjects = new ListBox();
		this.m_ae = new SplitContainer();
		this.m_v = new Label();
		lbCharacters = new ListBox();
		this.m_x = new Label();
		lbInventory = new ListBox();
		ar = new SaveFileDialog();
		@as = new OpenFileDialog();
		ay = new StatusStrip();
		az = new Timer(this.m_o);
		a8 = new SaveFileDialog();
		bb = new ToolTip(this.m_o);
		bt = new FontDialog();
		((ISupportInitialize)this.m_r).BeginInit();
		((Control)this.m_r.Panel1).SuspendLayout();
		((Control)this.m_r.Panel2).SuspendLayout();
		((Control)this.m_r).SuspendLayout();
		((ISupportInitialize)this.m_s).BeginInit();
		((Control)this.m_s.Panel1).SuspendLayout();
		((Control)this.m_s.Panel2).SuspendLayout();
		((Control)this.m_s).SuspendLayout();
		((Control)this.m_aa).SuspendLayout();
		((ISupportInitialize)a9).BeginInit();
		((ISupportInitialize)bo).BeginInit();
		((ISupportInitialize)b0).BeginInit();
		((ISupportInitialize)this.m_t).BeginInit();
		((ISupportInitialize)by).BeginInit();
		((ISupportInitialize)this.m_ab).BeginInit();
		((Control)this.m_ab.Panel1).SuspendLayout();
		((Control)this.m_ab.Panel2).SuspendLayout();
		((Control)this.m_ab).SuspendLayout();
		((Control)this.m_z).SuspendLayout();
		((Control)b4).SuspendLayout();
		((ISupportInitialize)this.m_ao).BeginInit();
		((ISupportInitialize)this.m_an).BeginInit();
		((Control)at).SuspendLayout();
		((ISupportInitialize)b1).BeginInit();
		((ISupportInitialize)bz).BeginInit();
		((ISupportInitialize)bg).BeginInit();
		((ISupportInitialize)bh).BeginInit();
		((ISupportInitialize)this.m_ai).BeginInit();
		((ISupportInitialize)this.m_ak).BeginInit();
		((ISupportInitialize)this.m_ah).BeginInit();
		((ISupportInitialize)this.m_al).BeginInit();
		((ISupportInitialize)this.m_ag).BeginInit();
		((ISupportInitialize)this.m_am).BeginInit();
		((ISupportInitialize)this.m_af).BeginInit();
		((ISupportInitialize)this.m_aj).BeginInit();
		((ISupportInitialize)this.m_ac).BeginInit();
		((Control)this.m_ac.Panel1).SuspendLayout();
		((Control)this.m_ac.Panel2).SuspendLayout();
		((Control)this.m_ac).SuspendLayout();
		((ISupportInitialize)this.m_y).BeginInit();
		((ISupportInitialize)bp).BeginInit();
		((ISupportInitialize)b3).BeginInit();
		((ISupportInitialize)this.m_ad).BeginInit();
		((Control)this.m_ad.Panel1).SuspendLayout();
		((Control)this.m_ad.Panel2).SuspendLayout();
		((Control)this.m_ad).SuspendLayout();
		((ISupportInitialize)this.m_ae).BeginInit();
		((Control)this.m_ae.Panel1).SuspendLayout();
		((Control)this.m_ae.Panel2).SuspendLayout();
		((Control)this.m_ae).SuspendLayout();
		((Control)this).SuspendLayout();
		((Menu)this.m_j).MenuItems.AddRange(new MenuItem[4] { this.m_k, a4, a0, av });
		this.m_k.Index = 0;
		((Menu)this.m_k).MenuItems.AddRange(new MenuItem[5] { this.m_l, this.m_n, aq, a7, this.m_m });
		this.m_k.Text = "&File";
		this.m_l.Index = 0;
		this.m_l.Text = "&Open A New Game";
		this.m_l.Click += ao;
		this.m_n.Index = 1;
		this.m_n.Text = "&Save Current Game";
		this.m_n.Click += y;
		aq.Index = 2;
		aq.Text = "&Load A Saved Game";
		aq.Click += x;
		a7.Index = 3;
		a7.Text = "Save A Transcript";
		a7.Click += p;
		this.m_m.Index = 4;
		this.m_m.Text = "E&xit";
		this.m_m.Click += v;
		a4.Index = 1;
		((Menu)a4).MenuItems.AddRange(new MenuItem[3] { bs, b6, b7 });
		a4.Text = "&Edit";
		bs.Index = 0;
		bs.Text = "Adjust Font";
		bs.Click += h;
		b6.Index = 1;
		b6.Shortcut = (Shortcut)119;
		b6.Text = "QuickSave - F8";
		b6.Click += d;
		b7.Index = 2;
		b7.Shortcut = (Shortcut)120;
		b7.Text = "QuickLoad - F9";
		b7.Click += c;
		a0.Index = 2;
		((Menu)a0).MenuItems.AddRange(new MenuItem[3] { a1, bi, bu });
		a0.Text = "&Tools";
		a1.Checked = true;
		a1.Index = 0;
		a1.Text = "Enable Upgrade Notifications";
		a1.Click += r;
		bi.Index = 1;
		bi.Text = "Reset Window Positions";
		bi.Click += i;
		bu.Index = 2;
		bu.Text = "Always Override Game Font";
		bu.Click += g;
		av.Index = 3;
		((Menu)av).MenuItems.AddRange(new MenuItem[3] { aw, ba, bv });
		av.Text = "&Help";
		aw.Index = 0;
		aw.Text = "A&bout";
		aw.Click += w;
		ba.Index = 1;
		ba.Text = "&Quick Help";
		ba.Click += m;
		bv.Index = 2;
		bv.Text = "&Game Info";
		bv.Click += f;
		((FileDialog)this.m_p).DefaultExt = "*.rag";
		((FileDialog)this.m_p).Filter = "RAG Game Files|*.rag|All File|*.*";
		((FileDialog)this.m_p).Title = "Load A New Rags Game";
		((Control)this.m_q).Name = "cmDynamic";
		((Control)this.m_q).Size = new Size(61, 4);
		((Control)this.m_r).Anchor = (AnchorStyles)15;
		this.m_r.BorderStyle = (BorderStyle)1;
		((Control)this.m_r).Location = new Point(0, 0);
		((Control)this.m_r).Name = "splitContainer1";
		this.m_r.Orientation = (Orientation)0;
		((Control)this.m_r.Panel1).Controls.Add((Control)(object)this.m_s);
		((Control)this.m_r.Panel2).Controls.Add((Control)(object)this.m_ab);
		((Control)this.m_r).Size = new Size(684, 400);
		this.m_r.SplitterDistance = 275;
		((Control)this.m_r).TabIndex = 7;
		this.m_s.BorderStyle = (BorderStyle)1;
		this.m_s.Dock = (DockStyle)5;
		((Control)this.m_s).Location = new Point(0, 0);
		((Control)this.m_s).Name = "splitContainer2";
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)a3);
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)a2);
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)this.m_aa);
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)a9);
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)bo);
		((Control)this.m_s.Panel1).Controls.Add((Control)(object)b0);
		((Control)this.m_s.Panel2).Controls.Add((Control)(object)this.m_t);
		((Control)this.m_s.Panel2).Controls.Add((Control)(object)by);
		((Control)this.m_s).Size = new Size(684, 275);
		this.m_s.SplitterDistance = 350;
		((Control)this.m_s).TabIndex = 0;
		((Control)a3).Anchor = (AnchorStyles)10;
		((Control)a3).Enabled = false;
		((Control)a3).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)a3).ForeColor = Color.Red;
		((Control)a3).Location = new Point(210, 241);
		((Control)a3).Name = "btnPause";
		((Control)a3).Size = new Size(129, 23);
		((Control)a3).TabIndex = 1;
		((Control)a3).Text = "Click To Continue...";
		((ButtonBase)a3).UseVisualStyleBackColor = true;
		((Control)a3).Click += q;
		((Control)a3).KeyDown += a;
		((Control)a2).Anchor = (AnchorStyles)6;
		((Control)a2).AutoSize = true;
		((Control)a2).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)a2).Location = new Point(65, 242);
		((Control)a2).Name = "lblCurrentRoom";
		((Control)a2).Size = new Size(121, 20);
		((Control)a2).TabIndex = 8;
		((Control)a2).Text = "Current Room";
		((Control)a2).MouseDown += g;
		((Control)this.m_aa).Anchor = (AnchorStyles)15;
		this.m_aa.BorderStyle = (BorderStyle)1;
		((Control)this.m_aa).Controls.Add((Control)(object)this.m_u);
		((Control)this.m_aa).Controls.Add((Control)(object)ax);
		((Control)this.m_aa).Location = new Point(0, 0);
		((Control)this.m_aa).Name = "TextPanel";
		((Control)this.m_aa).Size = new Size(339, 224);
		((Control)this.m_aa).TabIndex = 7;
		((Control)this.m_u).BackColor = SystemColors.Window;
		((Control)this.m_u).Dock = (DockStyle)5;
		((Control)this.m_u).Font = new Font("Microsoft Sans Serif", 8.5f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)this.m_u).Location = new Point(0, 0);
		((Control)this.m_u).Name = "rtMain";
		((TextBoxBase)this.m_u).ReadOnly = true;
		((Control)this.m_u).Size = new Size(337, 222);
		((Control)this.m_u).TabIndex = 0;
		((Control)this.m_u).Text = "";
		((Control)this.m_u).TextChanged += a;
		((Control)this.m_u).KeyDown += a;
		((Control)ax).Location = new Point(0, 0);
		((Control)ax).Name = "rtTemp";
		((Control)ax).Size = new Size(10, 10);
		((Control)ax).TabIndex = 3;
		((Control)ax).Text = "";
		((Control)ax).Visible = false;
		((Control)a9).Anchor = (AnchorStyles)6;
		((Control)a9).BackgroundImageLayout = (ImageLayout)4;
		a9.BorderStyle = (BorderStyle)1;
		((Control)a9).Location = new Point(5, 231);
		((Control)a9).Name = "pbRoomThumb";
		((Control)a9).Size = new Size(56, 40);
		a9.SizeMode = (PictureBoxSizeMode)4;
		a9.TabIndex = 10;
		a9.TabStop = false;
		((Control)a9).Paint += a;
		((Control)a9).MouseDoubleClick += c;
		((Control)a9).MouseDown += h;
		((Control)bo).Anchor = (AnchorStyles)6;
		((Control)bo).BackColor = Color.Green;
		bo.BorderStyle = (BorderStyle)1;
		((Control)bo).Location = new Point(1, 228);
		((Control)bo).Name = "pictureBox1";
		((Control)bo).Size = new Size(64, 48);
		bo.SizeMode = (PictureBoxSizeMode)4;
		bo.TabIndex = 11;
		bo.TabStop = false;
		((Control)b0).Anchor = (AnchorStyles)6;
		((AxHost)b0).Enabled = true;
		((Control)b0).Location = new Point(3, 231);
		((Control)b0).Name = "axRoomThumb";
		((AxHost)b0).OcxState = (State)componentResourceManager.GetObject("axRoomThumb.OcxState");
		((Control)b0).Size = new Size(58, 40);
		((Control)b0).TabIndex = 12;
		b0.MouseDownEvent += b;
		((Control)this.m_t).BackgroundImageLayout = (ImageLayout)4;
		this.m_t.BorderStyle = (BorderStyle)1;
		((Control)this.m_t).Dock = (DockStyle)5;
		((Control)this.m_t).Location = new Point(0, 0);
		((Control)this.m_t).Name = "pbMainPic";
		((Control)this.m_t).Size = new Size(328, 273);
		this.m_t.SizeMode = (PictureBoxSizeMode)4;
		this.m_t.TabIndex = 3;
		this.m_t.TabStop = false;
		((Control)this.m_t).Click += b;
		((Control)this.m_t).Paint += b;
		((Control)this.m_t).MouseMove += f;
		((Control)by).Dock = (DockStyle)5;
		((AxHost)by).Enabled = true;
		((Control)by).Location = new Point(0, 0);
		((Control)by).Name = "axWindowsMediaPlayer1";
		((AxHost)by).OcxState = (State)componentResourceManager.GetObject("axWindowsMediaPlayer1.OcxState");
		((Control)by).Size = new Size(328, 273);
		((Control)by).TabIndex = 5;
		this.m_ab.Dock = (DockStyle)5;
		((Control)this.m_ab).Location = new Point(0, 0);
		((Control)this.m_ab).Name = "scStatusBar";
		((Control)this.m_ab.Panel1).Controls.Add((Control)(object)this.m_z);
		((Control)this.m_ab.Panel2).Controls.Add((Control)(object)this.m_ac);
		((Control)this.m_ab).Size = new Size(682, 119);
		this.m_ab.SplitterDistance = 212;
		((Control)this.m_ab).TabIndex = 18;
		this.m_z.BorderStyle = (BorderStyle)1;
		((Control)this.m_z).Controls.Add((Control)(object)b4);
		((Control)this.m_z).Controls.Add((Control)(object)at);
		((Control)this.m_z).Dock = (DockStyle)5;
		((Control)this.m_z).Location = new Point(0, 0);
		((Control)this.m_z).Name = "panel4";
		((Control)this.m_z).Size = new Size(212, 119);
		((Control)this.m_z).TabIndex = 10;
		((Control)b4).Anchor = (AnchorStyles)7;
		((Control)b4).BackgroundImage = (Image)(object)Resources._300px_Compass_Rose_UD;
		((Control)b4).BackgroundImageLayout = (ImageLayout)4;
		b4.BorderStyle = (BorderStyle)1;
		((Control)b4).Controls.Add((Control)(object)this.m_ao);
		((Control)b4).Controls.Add((Control)(object)this.m_an);
		((Control)b4).Location = new Point(0, 0);
		((Control)b4).Name = "panel2";
		((Control)b4).Size = new Size(60, 117);
		((Control)b4).TabIndex = 23;
		((Control)this.m_ao).Anchor = (AnchorStyles)1;
		((Control)this.m_ao).BackColor = Color.Transparent;
		this.m_ao.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_ao.InitialImage = (Image)componentResourceManager.GetObject("pbU.InitialImage");
		((Control)this.m_ao).Location = new Point(14, 3);
		((Control)this.m_ao).Name = "pbU";
		((Control)this.m_ao).Size = new Size(30, 30);
		this.m_ao.SizeMode = (PictureBoxSizeMode)4;
		this.m_ao.TabIndex = 20;
		this.m_ao.TabStop = false;
		((Control)this.m_ao).Visible = false;
		((Control)this.m_ao).Click += ae;
		((Control)this.m_an).Anchor = (AnchorStyles)2;
		((Control)this.m_an).BackColor = Color.Transparent;
		this.m_an.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_an.InitialImage = (Image)componentResourceManager.GetObject("pbD.InitialImage");
		((Control)this.m_an).Location = new Point(14, 81);
		((Control)this.m_an).Name = "pbD";
		((Control)this.m_an).Size = new Size(30, 30);
		this.m_an.SizeMode = (PictureBoxSizeMode)4;
		this.m_an.TabIndex = 21;
		this.m_an.TabStop = false;
		((Control)this.m_an).Visible = false;
		((Control)this.m_an).Click += ad;
		((Control)at).Anchor = (AnchorStyles)15;
		((Control)at).BackgroundImage = (Image)(object)Resources._300px_Compass_Rose_English_North;
		((Control)at).BackgroundImageLayout = (ImageLayout)4;
		((Control)at).Controls.Add((Control)(object)b1);
		((Control)at).Controls.Add((Control)(object)bz);
		((Control)at).Controls.Add((Control)(object)bg);
		((Control)at).Controls.Add((Control)(object)bh);
		((Control)at).Controls.Add((Control)(object)this.m_ai);
		((Control)at).Controls.Add((Control)(object)this.m_ak);
		((Control)at).Controls.Add((Control)(object)this.m_ah);
		((Control)at).Controls.Add((Control)(object)this.m_al);
		((Control)at).Controls.Add((Control)(object)this.m_ag);
		((Control)at).Controls.Add((Control)(object)this.m_am);
		((Control)at).Controls.Add((Control)(object)this.m_af);
		((Control)at).Controls.Add((Control)(object)this.m_aj);
		((Control)at).Location = new Point(60, 0);
		((Control)at).Name = "panel1";
		((Control)at).Size = new Size(149, 116);
		((Control)at).TabIndex = 22;
		((AxHost)b1).Enabled = true;
		((Control)b1).Location = new Point(176, 79);
		((Control)b1).Name = "axBackgroundMusic";
		((AxHost)b1).OcxState = (State)componentResourceManager.GetObject("axBackgroundMusic.OcxState");
		((Control)b1).Size = new Size(75, 23);
		((Control)b1).TabIndex = 23;
		((Control)b1).Visible = false;
		b1.PlayStateChange += a;
		((AxHost)bz).Enabled = true;
		((Control)bz).Location = new Point(176, 32);
		((Control)bz).Name = "axSoundEffect";
		((AxHost)bz).OcxState = (State)componentResourceManager.GetObject("axSoundEffect.OcxState");
		((Control)bz).Size = new Size(75, 23);
		((Control)bz).TabIndex = 21;
		((Control)bz).Visible = false;
		((Control)bg).Anchor = (AnchorStyles)10;
		((Control)bg).BackColor = Color.Transparent;
		bg.Image = (Image)(object)Resources.out_yes;
		((Control)bg).Location = new Point(115, 97);
		((Control)bg).Name = "pbOut";
		((Control)bg).Size = new Size(33, 18);
		bg.SizeMode = (PictureBoxSizeMode)4;
		bg.TabIndex = 20;
		bg.TabStop = false;
		((Control)bg).Click += j;
		((Control)bh).Anchor = (AnchorStyles)9;
		((Control)bh).BackColor = Color.Transparent;
		bh.Image = (Image)(object)Resources.in_yes;
		((Control)bh).Location = new Point(115, 1);
		((Control)bh).Name = "pbIn";
		((Control)bh).Size = new Size(33, 18);
		bh.SizeMode = (PictureBoxSizeMode)4;
		bh.TabIndex = 19;
		bh.TabStop = false;
		((Control)bh).Click += k;
		((Control)this.m_ai).Anchor = (AnchorStyles)8;
		((Control)this.m_ai).BackColor = Color.Transparent;
		this.m_ai.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_ai.InitialImage = (Image)componentResourceManager.GetObject("pbE.InitialImage");
		((Control)this.m_ai).Location = new Point(117, 42);
		((Control)this.m_ai).Name = "pbE";
		((Control)this.m_ai).Size = new Size(30, 30);
		this.m_ai.SizeMode = (PictureBoxSizeMode)4;
		this.m_ai.TabIndex = 11;
		this.m_ai.TabStop = false;
		((Control)this.m_ai).Visible = false;
		((Control)this.m_ai).Click += aj;
		((Control)this.m_ak).Anchor = (AnchorStyles)10;
		((Control)this.m_ak).BackColor = Color.Transparent;
		this.m_ak.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_ak.InitialImage = (Image)componentResourceManager.GetObject("pbSE.InitialImage");
		((Control)this.m_ak).Location = new Point(95, 67);
		((Control)this.m_ak).Name = "pbSE";
		((Control)this.m_ak).Size = new Size(30, 30);
		this.m_ak.SizeMode = (PictureBoxSizeMode)4;
		this.m_ak.TabIndex = 18;
		this.m_ak.TabStop = false;
		((Control)this.m_ak).Visible = false;
		((Control)this.m_ak).Click += ah;
		((Control)this.m_ah).Anchor = (AnchorStyles)4;
		((Control)this.m_ah).BackColor = Color.Transparent;
		this.m_ah.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_ah.InitialImage = (Image)componentResourceManager.GetObject("pbW.InitialImage");
		((Control)this.m_ah).Location = new Point(3, 42);
		((Control)this.m_ah).Name = "pbW";
		((Control)this.m_ah).Size = new Size(30, 30);
		this.m_ah.SizeMode = (PictureBoxSizeMode)4;
		this.m_ah.TabIndex = 12;
		this.m_ah.TabStop = false;
		((Control)this.m_ah).Visible = false;
		((Control)this.m_ah).Click += ak;
		((Control)this.m_al).Anchor = (AnchorStyles)6;
		((Control)this.m_al).BackColor = Color.Transparent;
		this.m_al.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_al.InitialImage = (Image)componentResourceManager.GetObject("pbSW.InitialImage");
		((Control)this.m_al).Location = new Point(21, 67);
		((Control)this.m_al).Name = "pbSW";
		((Control)this.m_al).Size = new Size(30, 30);
		this.m_al.SizeMode = (PictureBoxSizeMode)4;
		this.m_al.TabIndex = 17;
		this.m_al.TabStop = false;
		((Control)this.m_al).Visible = false;
		((Control)this.m_al).Click += ai;
		((Control)this.m_ag).Anchor = (AnchorStyles)1;
		((Control)this.m_ag).BackColor = Color.Transparent;
		this.m_ag.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_ag.InitialImage = (Image)componentResourceManager.GetObject("pbN.InitialImage");
		((Control)this.m_ag).Location = new Point(58, 3);
		((Control)this.m_ag).Name = "pbN";
		((Control)this.m_ag).Size = new Size(30, 30);
		this.m_ag.SizeMode = (PictureBoxSizeMode)4;
		this.m_ag.TabIndex = 13;
		this.m_ag.TabStop = false;
		((Control)this.m_ag).Visible = false;
		((Control)this.m_ag).Click += am;
		((Control)this.m_ag).MouseHover += l;
		((Control)this.m_am).Anchor = (AnchorStyles)9;
		((Control)this.m_am).BackColor = Color.Transparent;
		this.m_am.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_am.InitialImage = (Image)componentResourceManager.GetObject("pbNE.InitialImage");
		((Control)this.m_am).Location = new Point(95, 19);
		((Control)this.m_am).Name = "pbNE";
		((Control)this.m_am).Size = new Size(30, 30);
		this.m_am.SizeMode = (PictureBoxSizeMode)4;
		this.m_am.TabIndex = 16;
		this.m_am.TabStop = false;
		((Control)this.m_am).Visible = false;
		((Control)this.m_am).Click += af;
		((Control)this.m_af).Anchor = (AnchorStyles)2;
		((Control)this.m_af).BackColor = Color.Transparent;
		this.m_af.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_af.InitialImage = (Image)componentResourceManager.GetObject("pbS.InitialImage");
		((Control)this.m_af).Location = new Point(58, 83);
		((Control)this.m_af).Name = "pbS";
		((Control)this.m_af).Size = new Size(30, 30);
		this.m_af.SizeMode = (PictureBoxSizeMode)4;
		this.m_af.TabIndex = 14;
		this.m_af.TabStop = false;
		((Control)this.m_af).Visible = false;
		((Control)this.m_af).Click += al;
		((Control)this.m_aj).BackColor = Color.Transparent;
		this.m_aj.Image = (Image)(object)Resources.transparent_gif_circleex2;
		this.m_aj.InitialImage = (Image)componentResourceManager.GetObject("pbNW.InitialImage");
		((Control)this.m_aj).Location = new Point(21, 19);
		((Control)this.m_aj).Name = "pbNW";
		((Control)this.m_aj).Size = new Size(30, 30);
		this.m_aj.SizeMode = (PictureBoxSizeMode)4;
		this.m_aj.TabIndex = 15;
		this.m_aj.TabStop = false;
		((Control)this.m_aj).Visible = false;
		((Control)this.m_aj).Click += ag;
		this.m_ac.BorderStyle = (BorderStyle)1;
		this.m_ac.Dock = (DockStyle)5;
		((Control)this.m_ac).Location = new Point(0, 0);
		((Control)this.m_ac).Name = "splitContainer3";
		((Control)this.m_ac.Panel1).Controls.Add((Control)(object)this.m_y);
		((Control)this.m_ac.Panel1).Controls.Add((Control)(object)bp);
		((Control)this.m_ac.Panel1).Controls.Add((Control)(object)b3);
		((Control)this.m_ac.Panel2).Controls.Add((Control)(object)this.m_ad);
		((Control)this.m_ac).Size = new Size(466, 119);
		this.m_ac.SplitterDistance = 135;
		((Control)this.m_ac).TabIndex = 0;
		((Control)this.m_y).Anchor = (AnchorStyles)15;
		((Control)this.m_y).BackgroundImageLayout = (ImageLayout)4;
		this.m_y.BorderStyle = (BorderStyle)1;
		((Control)this.m_y).Location = new Point(7, 6);
		((Control)this.m_y).Name = "picPlayer";
		((Control)this.m_y).Size = new Size(119, 106);
		this.m_y.SizeMode = (PictureBoxSizeMode)4;
		this.m_y.TabIndex = 11;
		this.m_y.TabStop = false;
		((Control)this.m_y).Paint += a;
		((Control)this.m_y).MouseDoubleClick += b;
		((Control)this.m_y).MouseDown += i;
		((Control)bp).BackColor = Color.Green;
		bp.BorderStyle = (BorderStyle)1;
		((Control)bp).Dock = (DockStyle)5;
		((Control)bp).Location = new Point(0, 0);
		((Control)bp).Name = "pictureBox2";
		((Control)bp).Size = new Size(133, 117);
		bp.SizeMode = (PictureBoxSizeMode)4;
		bp.TabIndex = 12;
		bp.TabStop = false;
		((Control)b3).Anchor = (AnchorStyles)15;
		((AxHost)b3).Enabled = true;
		((Control)b3).Location = new Point(7, 6);
		((Control)b3).Name = "axPlayerPortrait";
		((AxHost)b3).OcxState = (State)componentResourceManager.GetObject("axPlayerPortrait.OcxState");
		((Control)b3).Size = new Size(119, 106);
		((Control)b3).TabIndex = 13;
		b3.MouseDownEvent += a;
		this.m_ad.BorderStyle = (BorderStyle)1;
		this.m_ad.Dock = (DockStyle)5;
		((Control)this.m_ad).Location = new Point(0, 0);
		((Control)this.m_ad).Name = "splitContainer4";
		((Control)this.m_ad.Panel1).Controls.Add((Control)(object)this.m_w);
		((Control)this.m_ad.Panel1).Controls.Add((Control)(object)lbRoomObjects);
		((Control)this.m_ad.Panel2).Controls.Add((Control)(object)this.m_ae);
		((Control)this.m_ad).Size = new Size(327, 119);
		this.m_ad.SplitterDistance = 106;
		((Control)this.m_ad).TabIndex = 12;
		((Control)this.m_w).AutoSize = true;
		((Control)this.m_w).Location = new Point(4, -1);
		((Control)this.m_w).Name = "label2";
		((Control)this.m_w).Size = new Size(77, 13);
		((Control)this.m_w).TabIndex = 15;
		((Control)this.m_w).Text = "Room Objects:";
		((Control)lbRoomObjects).Anchor = (AnchorStyles)15;
		lbRoomObjects.HorizontalScrollbar = true;
		((Control)lbRoomObjects).Location = new Point(0, 16);
		((Control)lbRoomObjects).Name = "lbRoomObjects";
		lbRoomObjects.ScrollAlwaysVisible = true;
		((Control)lbRoomObjects).Size = new Size(102, 95);
		((Control)lbRoomObjects).TabIndex = 2;
		((Control)lbRoomObjects).KeyDown += a;
		((Control)lbRoomObjects).MouseDoubleClick += d;
		((Control)lbRoomObjects).MouseDown += l;
		this.m_ae.BorderStyle = (BorderStyle)1;
		this.m_ae.Dock = (DockStyle)5;
		((Control)this.m_ae).Location = new Point(0, 0);
		((Control)this.m_ae).Name = "splitContainer5";
		((Control)this.m_ae.Panel1).Controls.Add((Control)(object)this.m_v);
		((Control)this.m_ae.Panel1).Controls.Add((Control)(object)lbCharacters);
		((Control)this.m_ae.Panel2).Controls.Add((Control)(object)this.m_x);
		((Control)this.m_ae.Panel2).Controls.Add((Control)(object)lbInventory);
		((Control)this.m_ae).Size = new Size(217, 119);
		this.m_ae.SplitterDistance = 108;
		((Control)this.m_ae).TabIndex = 0;
		((Control)this.m_v).AutoSize = true;
		((Control)this.m_v).Location = new Point(-1, -1);
		((Control)this.m_v).Name = "label3";
		((Control)this.m_v).Size = new Size(94, 13);
		((Control)this.m_v).TabIndex = 17;
		((Control)this.m_v).Text = "Visible Characters:";
		((Control)lbCharacters).Anchor = (AnchorStyles)15;
		lbCharacters.HorizontalScrollbar = true;
		((Control)lbCharacters).Location = new Point(0, 16);
		((Control)lbCharacters).Name = "lbCharacters";
		lbCharacters.ScrollAlwaysVisible = true;
		((Control)lbCharacters).Size = new Size(103, 95);
		((Control)lbCharacters).TabIndex = 3;
		((Control)lbCharacters).KeyDown += a;
		((Control)lbCharacters).MouseDoubleClick += e;
		((Control)lbCharacters).MouseDown += j;
		((Control)this.m_x).AutoSize = true;
		((Control)this.m_x).Location = new Point(2, -1);
		((Control)this.m_x).Name = "label1";
		((Control)this.m_x).Size = new Size(54, 13);
		((Control)this.m_x).TabIndex = 14;
		((Control)this.m_x).Text = "Inventory:";
		((Control)lbInventory).Anchor = (AnchorStyles)15;
		lbInventory.HorizontalScrollbar = true;
		((Control)lbInventory).Location = new Point(3, 16);
		((Control)lbInventory).Name = "lbInventory";
		lbInventory.ScrollAlwaysVisible = true;
		((Control)lbInventory).Size = new Size(101, 95);
		((Control)lbInventory).TabIndex = 4;
		((Control)lbInventory).KeyDown += a;
		((Control)lbInventory).MouseDoubleClick += a;
		((Control)lbInventory).MouseDown += k;
		((FileDialog)ar).DefaultExt = "rsv";
		((FileDialog)ar).Filter = "Rags Save Files|*.rsv|All Files|*.*";
		((FileDialog)ar).Title = "Save your game";
		((FileDialog)@as).DefaultExt = "rsv";
		((FileDialog)@as).Filter = "Rags Save Files|*.rsv|All Files|*.*";
		((FileDialog)@as).Title = "Restore saved game";
		((FileDialog)@as).FileOk += a;
		((Control)ay).Location = new Point(0, 400);
		((Control)ay).Name = "statusStrip1";
		((Control)ay).Size = new Size(684, 22);
		((Control)ay).TabIndex = 24;
		((Control)ay).Text = "statusStrip1";
		az.Enabled = true;
		az.Interval = 30000;
		az.Tick += s;
		((FileDialog)a8).DefaultExt = "rtf";
		((FileDialog)a8).Filter = "Rich Text File|*.rtf|All Files|*.*";
		((FileDialog)a8).Title = "Save your transcript";
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Control)this).BackColor = SystemColors.Control;
		((Form)this).ClientSize = new Size(684, 422);
		((Control)this).Controls.Add((Control)(object)ay);
		((Control)this).Controls.Add((Control)(object)this.m_r);
		((Control)this).DoubleBuffered = true;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Menu = this.m_j;
		((Control)this).Name = "frmMain";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Rapid Game Development System";
		((Form)this).FormClosing += a;
		((Form)this).Load += t;
		((Form)this).Shown += o;
		((Control)this).Click += ao;
		((Control)this).KeyDown += a;
		((Control)this.m_r.Panel1).ResumeLayout(false);
		((Control)this.m_r.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_r).EndInit();
		((Control)this.m_r).ResumeLayout(false);
		((Control)this.m_s.Panel1).ResumeLayout(false);
		((Control)this.m_s.Panel1).PerformLayout();
		((Control)this.m_s.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_s).EndInit();
		((Control)this.m_s).ResumeLayout(false);
		((Control)this.m_aa).ResumeLayout(false);
		((ISupportInitialize)a9).EndInit();
		((ISupportInitialize)bo).EndInit();
		((ISupportInitialize)b0).EndInit();
		((ISupportInitialize)this.m_t).EndInit();
		((ISupportInitialize)by).EndInit();
		((Control)this.m_ab.Panel1).ResumeLayout(false);
		((Control)this.m_ab.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_ab).EndInit();
		((Control)this.m_ab).ResumeLayout(false);
		((Control)this.m_z).ResumeLayout(false);
		((Control)b4).ResumeLayout(false);
		((ISupportInitialize)this.m_ao).EndInit();
		((ISupportInitialize)this.m_an).EndInit();
		((Control)at).ResumeLayout(false);
		((ISupportInitialize)b1).EndInit();
		((ISupportInitialize)bz).EndInit();
		((ISupportInitialize)bg).EndInit();
		((ISupportInitialize)bh).EndInit();
		((ISupportInitialize)this.m_ai).EndInit();
		((ISupportInitialize)this.m_ak).EndInit();
		((ISupportInitialize)this.m_ah).EndInit();
		((ISupportInitialize)this.m_al).EndInit();
		((ISupportInitialize)this.m_ag).EndInit();
		((ISupportInitialize)this.m_am).EndInit();
		((ISupportInitialize)this.m_af).EndInit();
		((ISupportInitialize)this.m_aj).EndInit();
		((Control)this.m_ac.Panel1).ResumeLayout(false);
		((Control)this.m_ac.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_ac).EndInit();
		((Control)this.m_ac).ResumeLayout(false);
		((ISupportInitialize)this.m_y).EndInit();
		((ISupportInitialize)bp).EndInit();
		((ISupportInitialize)b3).EndInit();
		((Control)this.m_ad.Panel1).ResumeLayout(false);
		((Control)this.m_ad.Panel1).PerformLayout();
		((Control)this.m_ad.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_ad).EndInit();
		((Control)this.m_ad).ResumeLayout(false);
		((Control)this.m_ae.Panel1).ResumeLayout(false);
		((Control)this.m_ae.Panel1).PerformLayout();
		((Control)this.m_ae.Panel2).ResumeLayout(false);
		((Control)this.m_ae.Panel2).PerformLayout();
		((ISupportInitialize)this.m_ae).EndInit();
		((Control)this.m_ae).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[STAThread]
	private static void u()
	{
		Application.Run((Form)(object)new frmMain());
	}

	private void t()
	{
		this.m_h = true;
		bool flag = false;
		while (!flag)
		{
			flag = true;
			foreach (RagsThread item in bw)
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
				Application.DoEvents();
				Thread.Sleep(50);
			}
		}
		bw.Clear();
	}

	private void ao(object A_0, EventArgs A_1)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Invalid comparison between Unknown and I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Invalid comparison between Unknown and I4
		bool flag = true;
		if (bx != null)
		{
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = ap;
			saveData.CharacterList = bx.CharacterList;
			saveData.ObjectList = bx.ObjectList;
			saveData.RoomList = bx.RoomList;
			saveData.ThePlayer = bx.ThePlayer;
			saveData.VariableList = bx.VariableList;
			saveData.TimerList = bx.TimerList;
			saveData.StatusBarList = bx.StatusBarItems;
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, saveData);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			if (string.Compare(strB: streamReader.ReadToEnd(), strA: bn) == 0)
			{
				flag = false;
			}
			streamReader.Close();
			streamReader.Dispose();
			memoryStream.Close();
			memoryStream.Dispose();
		}
		else
		{
			flag = false;
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
		{
			flag = false;
		}
		if (flag)
		{
			DialogResult val = MessageBox.Show("Would you like to save your current game?", "Save", (MessageBoxButtons)3);
			if ((int)val == 6)
			{
				y(null, null);
				this.m_h = true;
				c();
				this.m_h = true;
				t();
			}
			else
			{
				if ((int)val == 2)
				{
					return;
				}
				c();
				this.m_h = true;
				t();
			}
		}
		if ((int)((CommonDialog)this.m_p).ShowDialog() == 1)
		{
			this.m_h = true;
			t();
			q(null, null);
			((Control)this.m_z).Enabled = true;
			ap = ((FileDialog)this.m_p).FileName;
			e(((FileDialog)this.m_p).FileName);
		}
	}

	private void s()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		if (bx == null)
		{
			return;
		}
		((ToolStrip)ay).Items.Clear();
		foreach (StatusBarItem statusBarItem in bx.StatusBarItems)
		{
			ToolStripStatusLabel val = new ToolStripStatusLabel(statusBarItem.Text);
			val.BorderSides = (ToolStripStatusLabelBorderSides)4;
			if (statusBarItem.Width != 0)
			{
				((ToolStripItem)val).AutoSize = false;
				((ToolStripItem)val).Width = statusBarItem.Width;
			}
			((ToolStrip)ay).Items.Add((ToolStripItem)(object)val);
		}
		for (int i = 0; i < bx.TimerList.Count; i++)
		{
			Timer atimer = bx.TimerList[i] as Timer;
			if (!atimer.LiveTimer)
			{
				continue;
			}
			b9 = new Thread(RunTestThread);
			bool flag = true;
			foreach (RagsThread item in bw)
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
				RagsThread ragsThread = new RagsThread(ref b9, ref atimer);
				bw.Add(ragsThread);
				b9.Start(ragsThread);
			}
		}
	}

	private void r()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		if (bx == null)
		{
			return;
		}
		((ToolStrip)ay).Items.Clear();
		foreach (StatusBarItem statusBarItem in bx.StatusBarItems)
		{
			if (statusBarItem.bVisisble)
			{
				ToolStripStatusLabel val = new ToolStripStatusLabel(bx.PerformTextReplacements(statusBarItem.Text, null));
				val.BorderSides = (ToolStripStatusLabelBorderSides)4;
				if (statusBarItem.Width != 0)
				{
					((ToolStripItem)val).AutoSize = false;
					((ToolStripItem)val).Width = statusBarItem.Width;
				}
				((ToolStrip)ay).Items.Add((ToolStripItem)(object)val);
			}
		}
	}

	private void q()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Invalid comparison between Unknown and I4
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Invalid comparison between Unknown and I4
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		if (br != null)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			br.Seek(0L, SeekOrigin.Begin);
			SaveData saveData = (SaveData)binaryFormatter.Deserialize(br);
			ap = saveData.originalfilename;
			bx.CharacterList = saveData.CharacterList;
			bx.ObjectList = saveData.ObjectList;
			bx.RoomList = saveData.RoomList;
			bx.ThePlayer = saveData.ThePlayer;
			bx.VariableList = saveData.VariableList;
			bx.TimerList = saveData.TimerList;
		}
		s();
		r();
		if (bx.ThePlayer.bPromptForGender)
		{
			GetGenderFrm getGenderFrm = new GetGenderFrm();
			getGenderFrm.radioButton1.Checked = true;
			if ((int)((Form)getGenderFrm).ShowDialog() == 1)
			{
				if (getGenderFrm.radioButton1.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Male;
				}
				if (getGenderFrm.radioButton2.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Female;
				}
				if (getGenderFrm.radioButton3.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Other;
				}
			}
		}
		if (bx.ThePlayer.bPromptForName)
		{
			AdditionalInputFrm additionalInputFrm = new AdditionalInputFrm(Action.ActionInputType.Text, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
			((Control)additionalInputFrm.lblTitle).Text = "Enter your character's name:";
			((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
			if ((int)((Form)additionalInputFrm).ShowDialog() == 4)
			{
				((Form)additionalInputFrm).ShowDialog();
			}
			while (((Control)additionalInputFrm.txtInput).Text == string.Empty)
			{
				MessageBox.Show("Sorry, you can not enter an empty player name.");
				((Form)additionalInputFrm).ShowDialog();
			}
			bx.ThePlayer.Name = ((Control)additionalInputFrm.txtInput).Text;
		}
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.Title + "\r\n", Color.Black, (FontStyle)1);
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.OpeningMessage + "\r\n", Color.Black, (FontStyle)0);
		bx.ThePlayer.CurrentRoom = bx.GetRoomByID(bx.ThePlayer.StartingRoom.UniqueID);
		m();
		l();
		a(bx.ThePlayer.PlayerPortrait, A_1: false);
		a(bx.ThePlayer.PlayerLayeredImage, A_1: true);
		a(A_0: true, A_1: true);
		d("<<On Game Start>>");
		if (bx.bgMusic != string.Empty)
		{
			object pictureByName = bx.GetPictureByName(bx.bgMusic);
			if (pictureByName != null && pictureByName is string uRL)
			{
				a(b1);
				b1.URL = uRL;
			}
		}
	}

	private void e(string A_0)
	{
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected Obj, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected Obj, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected Obj, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Invalid comparison between Unknown and I4
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Invalid comparison between Unknown and I4
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		if (bx != null)
		{
			bx.CharacterList.Clear();
			bx.TimerList.Clear();
			bx.ObjectList.Clear();
			bx.PictureList.Clear();
			bx.RoomList.Clear();
			bx.StatusBarItems.Clear();
			bx.VariableList.Clear();
			bx = null;
		}
		bool flag = false;
		try
		{
			Game.DBName = A_0;
			Game.GetDBConnection();
			bx = new Game(A_0);
			while (!Game.bDoneWithWaitDlg)
			{
				Application.DoEvents();
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			bq = new SaveData();
			bq.versionnumber = Game.ObjectVersionNumber;
			bq.originalfilename = ap;
			bq.CharacterList = bx.CharacterList;
			bq.ObjectList = bx.ObjectList;
			bq.RoomList = bx.RoomList;
			bq.ThePlayer = bx.ThePlayer;
			bq.VariableList = bx.VariableList;
			bq.TimerList = bx.TimerList;
			binaryFormatter.Serialize(br, bq);
		}
		catch
		{
			flag = true;
		}
		if (flag)
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			EncDec.Decrypt(A_0, ref memst, ref cs, this.m_b);
			memst.Seek(0L, SeekOrigin.Begin);
			try
			{
				bx = null;
				BinaryFormatter binaryFormatter2 = new BinaryFormatter();
				if (bx == null)
				{
					memst.Seek(0L, SeekOrigin.Begin);
					bx = (Game)binaryFormatter2.Deserialize(memst);
				}
				bq = new SaveData();
				bq.versionnumber = Game.ObjectVersionNumber;
				bq.originalfilename = ap;
				bq.CharacterList = bx.CharacterList;
				bq.ObjectList = bx.ObjectList;
				bq.RoomList = bx.RoomList;
				bq.ThePlayer = bx.ThePlayer;
				bq.VariableList = bx.VariableList;
				bq.TimerList = bx.TimerList;
				binaryFormatter2.Serialize(br, bq);
			}
			catch
			{
				MessageBox.Show("Sorry, this RAGS game file is unreadable.");
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
		((Control)this).Text = "Rapid Game Development System " + Path.GetFileName(A_0) + " " + Game.CurrentObjectVersionNumber;
		if (Environment.GetCommandLineArgs().Length > 2 && Environment.GetCommandLineArgs()[2] == "DEBUG")
		{
			this.m_i = new DebugDataFrm(ref bx);
			((Form)this.m_i).Show((IWin32Window)(object)this);
		}
		if (bu.Checked)
		{
			Font val = null;
			try
			{
				string text = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "GameFont", "None");
				if (text == null)
				{
					text = "None";
				}
				if (text == "None")
				{
					val = new Font("Times New Roman", 12f);
				}
				else
				{
					string[] array = text.Split(new string[1] { "," }, StringSplitOptions.None);
					val = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
				}
			}
			catch
			{
				val = new Font("Times New Roman", 12f);
			}
			((Control)this.m_u).Font = val;
		}
		else
		{
			((Control)this.m_u).Font = bx.GameFont;
		}
		GameObject.TheGame = bx;
		Character.TheGame = bx;
		if (bx.SortOrderCharacters == Game.SortOrder.SO_ALPHA)
		{
			IComparer comparer = new myCharacterSortClass();
			bx.CharacterList.Sort(comparer);
		}
		if (bx.SortOrderInventory == Game.SortOrder.SO_ALPHA)
		{
			IComparer comparer2 = new myObjectSortClass();
			bx.ObjectList.Sort(comparer2);
		}
		if (bx.SortOrderRoomObjects == Game.SortOrder.SO_ALPHA)
		{
			IComparer comparer3 = new myObjectSortClass();
			bx.ObjectList.Sort(comparer3);
		}
		g();
		bx.CorrectCommandAndConditions();
		s();
		r();
		if (bx.bHideMainPicDisplay)
		{
			((Control)this.m_s.Panel2).Hide();
			this.m_s.Panel2Collapsed = true;
		}
		else
		{
			((Control)this.m_s.Panel2).Show();
			this.m_s.Panel2Collapsed = false;
		}
		if (bx.bHidePortrait)
		{
			((Control)this.m_ac.Panel1).Hide();
			this.m_ac.Panel1Collapsed = true;
		}
		else
		{
			((Control)this.m_ac.Panel1).Show();
			this.m_ac.Panel1Collapsed = false;
		}
		if (bx.ThePlayer.bPromptForGender)
		{
			GetGenderFrm getGenderFrm = new GetGenderFrm();
			getGenderFrm.radioButton1.Checked = true;
			if ((int)((Form)getGenderFrm).ShowDialog() == 1)
			{
				if (getGenderFrm.radioButton1.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Male;
				}
				if (getGenderFrm.radioButton2.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Female;
				}
				if (getGenderFrm.radioButton3.Checked)
				{
					bx.ThePlayer.PlayerGender = Player.Gender.Other;
				}
			}
		}
		if (bx.ThePlayer.bPromptForName)
		{
			AdditionalInputFrm additionalInputFrm = new AdditionalInputFrm(Action.ActionInputType.Text, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
			((Control)additionalInputFrm.lblTitle).Text = "Enter your character's name:";
			((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
			if ((int)((Form)additionalInputFrm).ShowDialog() == 4)
			{
				((Form)additionalInputFrm).ShowDialog();
			}
			while (((Control)additionalInputFrm.txtInput).Text == string.Empty)
			{
				MessageBox.Show("Sorry, you can not enter an empty player name.");
				((Form)additionalInputFrm).ShowDialog();
			}
			bx.ThePlayer.Name = ((Control)additionalInputFrm.txtInput).Text;
		}
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.Title + "\r\n", Color.Black, (FontStyle)1);
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.OpeningMessage + "\r\n", Color.Black, (FontStyle)0);
		bx.ThePlayer.CurrentRoom = bx.GetRoomByID(bx.ThePlayer.StartingRoom.UniqueID);
		m();
		l();
		a(bx.ThePlayer.PlayerPortrait, A_1: false);
		a(bx.ThePlayer.PlayerLayeredImage, A_1: true);
		this.m_h = false;
		a(A_0: true, A_1: true);
		m();
		l();
		h();
		d("<<On Game Start>>");
		if (bx.bgMusic != string.Empty)
		{
			object pictureByName = bx.GetPictureByName(bx.bgMusic);
			if (pictureByName != null && pictureByName is string uRL)
			{
				a(b1);
				b1.URL = uRL;
			}
		}
		o();
	}

	private void p()
	{
		try
		{
			bx.TurnCount++;
		}
		catch
		{
		}
	}

	private void o()
	{
		bool flag = false;
		if (bx == null)
		{
			return;
		}
		foreach (Action action3 in bx.ThePlayer.Actions)
		{
			if (action3.name.Substring(0, 2) != "<<" && action3.bActive)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			((Control)bp).Visible = true;
		}
		else
		{
			((Control)bp).Visible = false;
		}
		flag = false;
		foreach (Action action4 in bx.ThePlayer.CurrentRoom.Actions)
		{
			if (action4.name.Substring(0, 2) != "<<" && action4.bActive)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			((Control)bo).Visible = true;
		}
		else
		{
			((Control)bo).Visible = false;
		}
	}

	private void n()
	{
		try
		{
			frmMain.m_d = true;
			frmMain.m_f = false;
			frmMain.m_e = string.Empty;
			if (bx == null)
			{
				return;
			}
			for (int i = 0; i < bx.TimerList.Count; i++)
			{
				if (bx.TimerList[i] is Timer timer)
				{
					frmMain.m_e = timer.Name;
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
				if (bx == null)
				{
					return;
				}
			}
			if (this.m_i != null)
			{
				this.m_i.RefreshVars();
			}
			o();
			m();
			l();
			h();
		}
		finally
		{
			frmMain.m_d = false;
		}
	}

	private bool a(Timer A_0)
	{
		bool result = true;
		frmMain.m_f = false;
		if (A_0.Active)
		{
			if (this.m_i != null)
			{
				this.m_i.AddExecutionData("TIMER: " + A_0.Name, bBold: false);
			}
			A_0.TurnNumber++;
			if (A_0.TurnNumber > A_0.Length && A_0.TType == Timer.TimerType.TT_LENGTH)
			{
				if (!A_0.Restart)
				{
					A_0.Active = false;
				}
				A_0.TurnNumber = 0;
			}
			else
			{
				Action A_1 = A_0.GetActionByName("<<On Each Turn>>");
				if (A_1 != null)
				{
					a(ref A_1, null);
				}
				if (frmMain.m_f)
				{
					return false;
				}
				A_1 = A_0.GetActionByName("<<On Turn " + A_0.TurnNumber + ">>");
				if (A_1 != null)
				{
					a(ref A_1, null);
				}
				if (frmMain.m_f)
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
			r();
		}
		return result;
	}

	private void m()
	{
		GameObject gameObject = null;
		if (lbInventory.SelectedItem != null)
		{
			gameObject = lbInventory.SelectedItem as GameObject;
		}
		lbInventory.Items.Clear();
		if (bx == null)
		{
			return;
		}
		foreach (GameObject @object in bx.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_PLAYER && @object.bVisible)
			{
				if (@object.bImportant)
				{
					lbInventory.Items.Insert(0, (object)@object);
				}
				else
				{
					lbInventory.Items.Add((object)@object);
				}
				if (@object == gameObject)
				{
					lbInventory.SelectedItem = @object;
				}
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref lbInventory, gameObject);
				}
			}
		}
		for (int num = lbInventory.Items.Count - 1; num >= 0; num--)
		{
			if (lbInventory.Items[num] is GameObject { bImportant: not false } gameObject3)
			{
				lbInventory.Items.Remove((object)gameObject3);
				lbInventory.Items.Insert(0, (object)gameObject3);
			}
		}
	}

	private void l()
	{
		GameObject gameObject = null;
		if (lbRoomObjects.SelectedItem != null)
		{
			gameObject = lbRoomObjects.SelectedItem as GameObject;
		}
		lbRoomObjects.Items.Clear();
		if (bx == null)
		{
			return;
		}
		foreach (GameObject @object in bx.ObjectList)
		{
			if (bx.ThePlayer.CurrentRoom != null && @object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == bx.ThePlayer.CurrentRoom.UniqueID.ToString() && @object.bVisible)
			{
				lbRoomObjects.Items.Add((object)@object);
				if (@object == gameObject)
				{
					lbRoomObjects.SelectedItem = @object;
				}
				if (@object.bContainer && (!@object.bOpenable || @object.bOpen))
				{
					a(@object, ref lbRoomObjects, gameObject);
				}
			}
		}
		for (int num = lbRoomObjects.Items.Count - 1; num >= 0; num--)
		{
			if (lbRoomObjects.Items[num] is GameObject { bImportant: not false } gameObject3)
			{
				lbRoomObjects.Items.Remove((object)gameObject3);
				lbRoomObjects.Items.Insert(0, (object)gameObject3);
			}
		}
		if (bx.ThePlayer.CurrentRoom == null)
		{
			return;
		}
		foreach (Exit exit in bx.ThePlayer.CurrentRoom.Exits)
		{
			if (!(exit.PortalObjectName != "<None>"))
			{
				continue;
			}
			bool flag = false;
			foreach (GameObject item in lbRoomObjects.Items)
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
			GameObject gameObject4 = bx.GetObjectByName(exit.PortalObjectName);
			if (gameObject4 == null)
			{
				gameObject4 = bx.GetObjectByNameOld(exit.PortalObjectName);
			}
			if (gameObject4 != null && gameObject4.bVisible)
			{
				lbRoomObjects.Items.Add((object)gameObject4);
				if (gameObject4 == gameObject)
				{
					lbRoomObjects.SelectedItem = gameObject4;
				}
				if (gameObject4.bContainer && (!gameObject4.bOpenable || gameObject4.bOpen))
				{
					a(gameObject4, ref lbRoomObjects, gameObject);
				}
			}
		}
	}

	private void a(GameObject A_0, ref ListBox A_1, GameObject A_2)
	{
		for (int i = 0; i < bx.ObjectList.Count; i++)
		{
			GameObject gameObject = bx.ObjectList[i] as GameObject;
			if (gameObject.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject.locationname == A_0.UniqueIdentifier.ToString() && gameObject.bVisible)
			{
				A_1.Items.Add((object)gameObject);
				if (gameObject == A_2)
				{
					A_1.SelectedItem = gameObject;
				}
				if (gameObject.bOpenable && gameObject.bOpen)
				{
					a(gameObject, ref A_1, A_2);
				}
			}
		}
	}

	private void k()
	{
		int num = 0;
		foreach (GameObject @object in bx.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == bx.ThePlayer.CurrentRoom.UniqueID.ToString() && @object.bVisible)
			{
				if (num == 0)
				{
					TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "You can see ", Color.Black, (FontStyle)0);
				}
				if (num > 0)
				{
					TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ", ", au, (FontStyle)1);
				}
				if (@object.preposition.Trim().Length > 0)
				{
					TextHandlers.AddTextToRTF(ref this.m_u, ref bx, @object.preposition + " " + @object.ToString(), au, (FontStyle)1);
				}
				else
				{
					TextHandlers.AddTextToRTF(ref this.m_u, ref bx, @object.ToString(), au, (FontStyle)1);
				}
				num++;
			}
		}
		if (num > 0)
		{
			((TextBoxBase)this.m_u).AppendText("\r\n");
		}
	}

	private void a(bool A_0, bool A_1)
	{
		if (bx == null)
		{
			return;
		}
		string text = string.Empty;
		if (bx.ThePlayer.CurrentRoom != null)
		{
			text = bx.ThePlayer.CurrentRoom.UniqueID.ToString();
		}
		((TextBoxBase)this.m_u).AppendText("\r\n");
		if (bx.ThePlayer.CurrentRoom != null)
		{
			object pictureByName = bx.GetPictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
			if (pictureByName != null)
			{
				Image val = (Image)((pictureByName is Image) ? pictureByName : null);
				if (val != null)
				{
					((Control)b0).Visible = false;
					((Control)a9).Visible = true;
					((Control)a9).Tag = bx.GetGamePictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
					((Control)a9).BackgroundImage = val;
				}
				else
				{
					((Control)b0).Visible = true;
					((Control)a9).Visible = false;
					b0.URL = pictureByName as string;
				}
				PictureBox val2 = a9;
				object pictureByName2 = bx.GetPictureByName(bx.ThePlayer.CurrentRoom.LayeredRoomPic);
				val2.Image = (Image)((pictureByName2 is Image) ? pictureByName2 : null);
				if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
				{
					((TextBoxBase)this.m_u).ReadOnly = false;
					Clipboard.SetDataObject(pictureByName);
					((TextBoxBase)this.m_u).Paste();
					((TextBoxBase)this.m_u).AppendText("\r\n");
					((TextBoxBase)this.m_u).ReadOnly = true;
				}
				if (!bx.bHideMainPicDisplay)
				{
					if (val != null)
					{
						((Control)by).Visible = false;
						((Control)this.m_t).Visible = true;
						((Control)this.m_t).Tag = bx.GetGamePictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
						((Control)this.m_t).BackgroundImage = val;
					}
					else
					{
						((Control)by).Visible = true;
						((Control)this.m_t).Visible = false;
						by.URL = pictureByName as string;
					}
					object pictureByName3 = bx.GetPictureByName(bx.ThePlayer.CurrentRoom.LayeredRoomPic);
					this.m_t.Image = null;
					if (pictureByName3 != null)
					{
						Image val3 = (Image)((pictureByName3 is Image) ? pictureByName3 : null);
						if (val3 != null)
						{
							((Control)by).Visible = false;
							((Control)this.m_t).Visible = true;
							this.m_t.Image = val3;
						}
						else
						{
							((Control)by).Visible = true;
							((Control)this.m_t).Visible = false;
							by.URL = pictureByName3 as string;
						}
					}
				}
			}
			else
			{
				((Control)a9).Tag = null;
				a9.Image = null;
				((Control)a9).BackgroundImage = null;
				this.m_t.Image = null;
				((Control)this.m_t).Tag = null;
				((Control)this.m_t).BackgroundImage = null;
			}
			((Control)a2).Text = bx.ThePlayer.CurrentRoom.GetName();
		}
		Guid uniqueID = bx.ThePlayer.CurrentRoom.UniqueID;
		if (A_1)
		{
			if (!bx.ThePlayer.CurrentRoom.bEnterFirstTime)
			{
				bx.ThePlayer.CurrentRoom.bEnterFirstTime = true;
				d("<<On Player Enter First Time>>");
			}
			d("<<On Player Enter>>");
		}
		if (bx == null)
		{
			return;
		}
		if (text == bx.ThePlayer.CurrentRoom.UniqueID.ToString())
		{
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.ThePlayer.CurrentRoom.Description + "\r\n", Color.Black, (FontStyle)0);
		}
		if (uniqueID == bx.ThePlayer.CurrentRoom.UniqueID)
		{
			l();
			if (!bx.bTurnOffNotifications)
			{
				k();
			}
			j();
			i();
			if (A_0)
			{
				n();
			}
			r();
			o();
			m();
			l();
			h();
		}
	}

	private void j()
	{
		object obj = null;
		if (lbCharacters.SelectedItem != null)
		{
			obj = lbCharacters.SelectedItem;
		}
		lbCharacters.Items.Clear();
		foreach (Character character in bx.CharacterList)
		{
			if (!(character.CurrentRoom == bx.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			lbCharacters.Items.Add((object)character);
			if (!bx.bTurnOffNotifications)
			{
				TextHandlers.AddTextToRTF(ref this.m_u, ref bx, character.ToString(), au, (FontStyle)1);
				TextHandlers.AddTextToRTF(ref this.m_u, ref bx, " is here.\r\n", Color.Black, (FontStyle)0);
			}
			if (!character.bAllowInventoryInteraction)
			{
				continue;
			}
			foreach (GameObject @object in bx.ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_CHARACTER && @object.locationname == character.Charname && @object.bVisible)
				{
					lbCharacters.Items.Add((object)@object);
				}
			}
		}
		for (int num = lbCharacters.Items.Count - 1; num >= 0; num--)
		{
			if (lbCharacters.Items[num] is GameObject { bImportant: not false } gameObject2)
			{
				lbCharacters.Items.Remove((object)gameObject2);
				lbCharacters.Items.Insert(0, (object)gameObject2);
			}
		}
		for (int i = 0; i < lbCharacters.Items.Count; i++)
		{
			object obj2 = lbCharacters.Items[i];
			if (obj2 != null && obj2 == obj)
			{
				lbCharacters.SelectedItem = obj2;
			}
		}
	}

	private void i()
	{
		for (int i = 0; i < bx.ThePlayer.CurrentRoom.Exits.Count; i++)
		{
			Exit exit = (Exit)bx.ThePlayer.CurrentRoom.Exits[i];
			switch (exit.Direction)
			{
			case Exit.Directions.North:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_ag).Visible = true;
					bb.SetToolTip((Control)(object)this.m_ag, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_ag).Visible = false;
				}
				break;
			case Exit.Directions.South:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_af).Visible = true;
					bb.SetToolTip((Control)(object)this.m_af, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
					((Control)this.m_af).Enabled = true;
				}
				else
				{
					((Control)this.m_af).Visible = false;
					((Control)this.m_af).Enabled = false;
				}
				break;
			case Exit.Directions.West:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_ah).Visible = true;
					bb.SetToolTip((Control)(object)this.m_ah, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_ah).Visible = false;
				}
				break;
			case Exit.Directions.East:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_ai).Visible = true;
					bb.SetToolTip((Control)(object)this.m_ai, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_ai).Visible = false;
				}
				break;
			case Exit.Directions.Up:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_ao).Visible = true;
					bb.SetToolTip((Control)(object)this.m_ao, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_ao).Visible = false;
				}
				break;
			case Exit.Directions.Down:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_an).Visible = true;
					bb.SetToolTip((Control)(object)this.m_an, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_an).Visible = false;
				}
				break;
			case Exit.Directions.NorthWest:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_aj).Visible = true;
					bb.SetToolTip((Control)(object)this.m_aj, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_aj).Visible = false;
				}
				break;
			case Exit.Directions.NorthEast:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_am).Visible = true;
					bb.SetToolTip((Control)(object)this.m_am, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_am).Visible = false;
				}
				break;
			case Exit.Directions.SouthWest:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_al).Visible = true;
					bb.SetToolTip((Control)(object)this.m_al, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_al).Visible = false;
				}
				break;
			case Exit.Directions.SouthEast:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)this.m_ak).Visible = true;
					bb.SetToolTip((Control)(object)this.m_ak, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)this.m_ak).Visible = false;
				}
				break;
			case Exit.Directions.In:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)bh).Visible = true;
					bb.SetToolTip((Control)(object)bh, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)bh).Visible = false;
				}
				break;
			case Exit.Directions.Out:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)bg).Visible = true;
					bb.SetToolTip((Control)(object)bg, bx.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)bg).Visible = false;
				}
				break;
			}
		}
	}

	private void an(object A_0, EventArgs A_1)
	{
	}

	private void d(string A_0)
	{
		try
		{
			if (bx == null)
			{
				return;
			}
			Guid uniqueID = bx.ThePlayer.CurrentRoom.UniqueID;
			Action A_1 = bx.ThePlayer.CurrentRoom.GetActionByName(A_0);
			if (A_1 != null)
			{
				a(ref A_1, null);
			}
			if (bx == null)
			{
				return;
			}
			A_1 = bx.ThePlayer.GetActionByName(A_0);
			if (A_1 != null)
			{
				a(ref A_1, null);
			}
			if (bx == null)
			{
				return;
			}
			for (int i = 0; i < bx.ObjectList.Count; i++)
			{
				GameObject gameObject = (GameObject)bx.ObjectList[i];
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM || !(gameObject.locationname == bx.ThePlayer.CurrentRoom.UniqueID.ToString()))
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
						if (uniqueID == bx.ThePlayer.CurrentRoom.UniqueID)
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
				for (int j = 0; j < bx.ObjectList.Count; j++)
				{
					GameObject gameObject2 = (GameObject)bx.ObjectList[j];
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
						if (uniqueID == bx.ThePlayer.CurrentRoom.UniqueID)
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
			if (bx == null)
			{
				return;
			}
			for (int k = 0; k < bx.CharacterList.Count; k++)
			{
				Character character = (Character)bx.CharacterList[k];
				if (!(character.CurrentRoom == bx.ThePlayer.CurrentRoom.UniqueID.ToString()))
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
					if (uniqueID == bx.ThePlayer.CurrentRoom.UniqueID)
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

	private void am(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.North;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "North\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.North);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void al(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.South;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "South\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.South);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ak(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.West;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "West\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.West);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void aj(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.East;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "East\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.East);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ai(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.SouthWest;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "SouthWest\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.SouthWest);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ah(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.SouthEast;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "SouthEast\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.SouthEast);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ag(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.NorthWest;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "NorthWest\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.NorthWest);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void af(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.NorthEast;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "NorthEast\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.NorthEast);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ae(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.Up;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Up\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.Up);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ad(object A_0, EventArgs A_1)
	{
		p();
		be = false;
		bf = Exit.Directions.Down;
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Down\r\n", Color.Black, (FontStyle)1);
		if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			d("<<On Player Leave First Time>>");
		}
		d("<<On Player Leave>>");
		if (!be)
		{
			if (bx == null)
			{
				return;
			}
			bx.MovePlayer(Exit.Directions.Down);
			a(A_0: true, A_1: true);
		}
		bf = Exit.Directions.Empty;
	}

	private void ac(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		GameObject a_ = null;
		string text = string.Empty;
		switch (ca)
		{
		case frmMain.b.d:
			a_ = lbCharacters.SelectedItem as GameObject;
			text = lbCharacters.SelectedItem.ToString() + " - " + ((ToolStripItem)val).Text + "\r\n";
			break;
		case frmMain.b.e:
			a_ = lbInventory.SelectedItem as GameObject;
			text = c(lbInventory.SelectedItem.ToString()) + " - " + ((ToolStripItem)val).Text + "\r\n";
			break;
		case frmMain.b.c:
			a_ = lbRoomObjects.SelectedItem as GameObject;
			text = c(lbRoomObjects.SelectedItem.ToString()) + " - " + ((ToolStripItem)val).Text + "\r\n";
			break;
		case frmMain.b.b:
			text = "Player - " + ((ToolStripItem)val).Text + "\r\n";
			break;
		case frmMain.b.a:
			text = "Room: " + bx.ThePlayer.CurrentRoom.GetName() + " - " + ((ToolStripItem)val).Text + "\r\n";
			break;
		}
		Action A_2 = ((ToolStripItem)val).Tag as Action;
		if (A_2 != null)
		{
			p();
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text, Color.Black, (FontStyle)1);
			if (!a(ref A_2, a_))
			{
				return;
			}
			if (!frmMain.m_g)
			{
				n();
				r();
			}
			else
			{
				frmMain.m_g = false;
			}
			o();
			m();
			l();
			h();
		}
		((Control)this.m_q).Hide();
	}

	private string c(string A_0)
	{
		string text = A_0;
		int num = A_0.IndexOf("(");
		if (num > -1)
		{
			text = A_0.Substring(0, num);
		}
		return text.Trim();
	}

	private void ab(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		Action A_2 = ((ToolStripItem)val).Tag as Action;
		if (A_2 == null)
		{
			return;
		}
		p();
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Player - " + ((ToolStripItem)val).Text + "\r\n", Color.Black, (FontStyle)1);
		if (a(ref A_2, null))
		{
			if (!frmMain.m_g)
			{
				n();
				r();
			}
			else
			{
				frmMain.m_g = false;
			}
			o();
			m();
			l();
			h();
		}
	}

	private void aa(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		if (lbInventory.SelectedItem == null || !(lbInventory.SelectedItem is GameObject a_))
		{
			return;
		}
		Action A_2 = ((ToolStripItem)val).Tag as Action;
		if (A_2 == null)
		{
			return;
		}
		p();
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, c(lbInventory.SelectedItem.ToString()) + " - " + ((ToolStripItem)val).Text + "\r\n", Color.Black, (FontStyle)1);
		if (a(ref A_2, a_))
		{
			if (!frmMain.m_g)
			{
				n();
				r();
			}
			else
			{
				frmMain.m_g = false;
			}
			o();
			m();
			l();
			h();
		}
	}

	private int b(string A_0)
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

	private int a(string A_0)
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

	private Action c(string A_0, string A_1, string A_2)
	{
		Action result = null;
		if (A_0.Equals("Chr"))
		{
			result = bx.GetCharacterByName(A_1).GetActionByName(A_2);
		}
		else if (A_0.Equals("Obj"))
		{
			GameObject gameObject = bx.GetObjectByName(A_1);
			if (gameObject == null)
			{
				gameObject = bx.GetObjectByNameOld(A_1);
			}
			if (gameObject != null)
			{
				result = gameObject.GetActionByName(A_2);
			}
		}
		else if (A_0.Equals("Player"))
		{
			result = bx.ThePlayer.GetActionByName(A_2);
		}
		else if (A_0.Equals("Room"))
		{
			Room room = null;
			try
			{
				room = bx.GetRoomByID(new Guid(A_1));
			}
			catch
			{
				room = bx.GetRoomByName(ref A_1);
			}
			if (room != null)
			{
				result = room.GetActionByName(A_2);
			}
		}
		else if (A_0.Equals("Timer"))
		{
			Timer timer = null;
			timer = bx.GetTimerByName(A_1);
			if (timer != null)
			{
				result = timer.GetActionByName(A_2);
			}
		}
		return result;
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
					bx.PerformTextReplacements(text, null, text2);
				}
			}
		}
		a(bx.ThePlayer.PlayerPortrait, A_1: false);
		this.i();
	}

	private void a(GameVariable A_0, ref object A_1)
	{
		try
		{
			if (A_0.VarArray.Count > 0 && A_0.VarArray[0] is ArrayList arrayList)
			{
				_ = arrayList.Count;
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
							A_0.VarArray.Add(new ArrayList());
						}
						object obj3 = ((ScriptObject)val2)[j];
						((ArrayList)A_0.VarArray[i]).Add(obj3.ToString());
					}
					continue;
				}
				object value = null;
				switch (A_0.vartype)
				{
				case GameVariable.VarType.VT_DATETIMEARRAY:
					try
					{
						value = Convert.ToDateTime(((ScriptObject)val)[i].ToString());
					}
					catch
					{
						value = DateTime.MinValue;
					}
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
					try
					{
						value = Convert.ToDouble(((ScriptObject)val)[i].ToString());
					}
					catch
					{
						value = -1;
					}
					break;
				case GameVariable.VarType.VT_STRINGARRAY:
					value = ((ScriptObject)val)[i].ToString();
					break;
				}
				A_0.VarArray.Add(value);
			}
		}
		catch
		{
		}
	}

	private bool a(ref ArrayList A_0, GameObject A_1, string A_2, ref Action A_3, object A_4)
	{
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_76dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_785e: Unknown result type (might be due to invalid IL or missing references)
		//IL_860b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8675: Unknown result type (might be due to invalid IL or missing references)
		//IL_7631: Unknown result type (might be due to invalid IL or missing references)
		//IL_7636: Unknown result type (might be due to invalid IL or missing references)
		//IL_77ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_7804: Unknown result type (might be due to invalid IL or missing references)
		//IL_7820: Unknown result type (might be due to invalid IL or missing references)
		//IL_7827: Invalid comparison between Unknown and I4
		//IL_86a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2075: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_783a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7841: Invalid comparison between Unknown and I4
		//IL_782f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7834: Unknown result type (might be due to invalid IL or missing references)
		//IL_7699: Unknown result type (might be due to invalid IL or missing references)
		//IL_76a0: Invalid comparison between Unknown and I4
		//IL_786d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7874: Invalid comparison between Unknown and I4
		//IL_76b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_76c0: Invalid comparison between Unknown and I4
		//IL_76ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_76b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_76ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_76f3: Invalid comparison between Unknown and I4
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Invalid comparison between Unknown and I4
		//IL_1397: Unknown result type (might be due to invalid IL or missing references)
		//IL_139c: Unknown result type (might be due to invalid IL or missing references)
		//IL_139e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a1: Invalid comparison between Unknown and I4
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Invalid comparison between Unknown and I4
		//IL_13b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ba: Invalid comparison between Unknown and I4
		//IL_7ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_7edd: Expected Obj, but got Unknown
		//IL_74b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_74bb: Expected Obj, but got Unknown
		//IL_1507: Unknown result type (might be due to invalid IL or missing references)
		//IL_831b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8320: Unknown result type (might be due to invalid IL or missing references)
		//IL_8326: Unknown result type (might be due to invalid IL or missing references)
		//IL_832d: Invalid comparison between Unknown and I4
		//IL_8340: Unknown result type (might be due to invalid IL or missing references)
		//IL_8347: Invalid comparison between Unknown and I4
		//IL_8335: Unknown result type (might be due to invalid IL or missing references)
		//IL_833a: Unknown result type (might be due to invalid IL or missing references)
		//IL_821d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8223: Invalid comparison between Unknown and I4
		//IL_8015: Unknown result type (might be due to invalid IL or missing references)
		//IL_801f: Expected Obj, but got Unknown
		//IL_7d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d4e: Expected Obj, but got Unknown
		//IL_7322: Unknown result type (might be due to invalid IL or missing references)
		//IL_732c: Expected Obj, but got Unknown
		bool result = false;
		for (int i = 0; i < A_0.Count; i++)
		{
			Command command = A_0[i] as Command;
			if (A_0[i] is Condition condition)
			{
				if (a(condition, A_2, A_3.InputType, A_1, ref A_3, A_4))
				{
					if (condition.Checks.Count != 1 || (((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_While && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Rooms && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Characters && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Items && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Exits && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Char_Inventory && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Container && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Inventory && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Room && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Group))
					{
						result = a(ref condition.PassCommands, A_1, A_2, ref A_3, A_4);
					}
				}
				else
				{
					result = a(ref condition.FailCommands, A_1, A_2, ref A_3, A_4);
				}
			}
			else
			{
				if (command == null)
				{
					continue;
				}
				if (bx == null)
				{
					return false;
				}
				string roomname = bx.PerformTextReplacements(command.CommandPart2, A_4);
				string roomname2 = bx.PerformTextReplacements(command.CommandPart3, A_4);
				string roomname3 = bx.PerformTextReplacements(command.CommandPart4, A_4);
				string text = bx.PerformTextReplacements(command.CommandText, A_4);
				if (this.m_i != null)
				{
					this.m_i.AddExecutionData("COMMAND: " + command.cmdtype.ToString() + ":" + roomname + ":" + roomname2 + ":" + roomname3 + " Executing", bBold: false);
				}
				try
				{
					switch (command.cmdtype)
					{
					case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
					{
						GameVariable variableByName7 = bx.GetVariableByName(roomname);
						if (variableByName7 != null)
						{
							List<string> A_15 = new List<string>();
							a(ref A_15, roomname2, frmMain.a.a);
							if (A_15.Count > 0)
							{
								variableByName7.sString = A_15[bd.Next(0, A_15.Count)];
							}
							else
							{
								variableByName7.sString = string.Empty;
							}
						}
						break;
					}
					case Command.CommandType.CT_MM_GETRANDOMGROUP:
					{
						GameVariable variableByName6 = bx.GetVariableByName(roomname);
						if (variableByName6 != null)
						{
							List<string> A_13 = new List<string>();
							a(ref A_13, roomname2, frmMain.a.b);
							if (A_13.Count > 0)
							{
								variableByName6.sString = A_13[bd.Next(0, A_13.Count)];
							}
							else
							{
								variableByName6.sString = string.Empty;
							}
						}
						break;
					}
					case Command.CommandType.CT_Status_ItemVisibleInvisible:
						foreach (StatusBarItem statusBarItem in bx.StatusBarItems)
						{
							if (string.Compare(statusBarItem.Name, roomname, ignoreCase: true) == 0)
							{
								if (string.Compare(roomname2, "Visible", ignoreCase: true) == 0)
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
						if (roomname == "00000000-0000-0000-0000-000000000004")
						{
							if (A_1 != null)
							{
								TextHandlers.AddTextToRTF(ref this.m_u, ref bx, A_1.Display(ref bx.ObjectList), Color.Black, (FontStyle)0);
							}
							break;
						}
						GameObject gameObject20 = bx.GetObjectByName(roomname);
						if (gameObject20 == null)
						{
							gameObject20 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject20 != null)
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, gameObject20.Display(ref bx.ObjectList), Color.Black, (FontStyle)0);
						}
						break;
					}
					case Command.CommandType.CT_LOOP_BREAK:
						return true;
					case Command.CommandType.CT_EXPORTVARIABLE:
					{
						((FileDialog)a8).Title = "Export Game Data";
						((FileDialog)a8).Filter = "Rags Export|*.rxp|All Files|*.*";
						GameVariable variableByName2 = bx.GetVariableByName(roomname);
						if (variableByName2 != null && (int)((CommonDialog)a8).ShowDialog() == 1)
						{
							try
							{
								StreamWriter streamWriter = new StreamWriter(((FileDialog)a8).FileName);
								new BinaryFormatter().Serialize(streamWriter.BaseStream, variableByName2);
								streamWriter.Close();
							}
							catch
							{
								MessageBox.Show("Unable to save your game data.");
							}
						}
						((FileDialog)a8).Filter = "Rich Text File|*.rtf|All Files|*.*";
						break;
					}
					case Command.CommandType.CT_IMPORTVARIABLE:
					{
						((FileDialog)@as).Title = "Import Game Data";
						string filter = ((FileDialog)@as).Filter;
						((FileDialog)@as).Filter = "Rags Export|*.rxp|All Files|*.*";
						if ((int)((CommonDialog)@as).ShowDialog() == 1)
						{
							try
							{
								StreamReader streamReader = new StreamReader(((FileDialog)@as).FileName);
								streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
								GameVariable gameVariable = (GameVariable)new BinaryFormatter().Deserialize(streamReader.BaseStream);
								streamReader.Close();
								GameVariable variableByName3 = bx.GetVariableByName(gameVariable.varname);
								if (variableByName3 != null)
								{
									bx.VariableList.Remove(variableByName3);
								}
								bx.VariableList.Add(gameVariable);
							}
							catch
							{
								MessageBox.Show("Unable to load your game data.");
							}
						}
						((FileDialog)@as).Filter = filter;
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
					{
						GameVariable variableByName13 = bx.GetVariableByName(roomname);
						if (variableByName13 != null)
						{
							int num24 = b(roomname);
							int num25 = a(roomname);
							if (num24 == -1)
							{
								variableByName13.dNumType = Convert.ToDouble(bd.Next(Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMax, null))) + 1));
							}
							else if (num25 != -1)
							{
								((ArrayList)variableByName13.VarArray[num24])[num25] = bd.Next(Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMax, null))) + 1).ToString();
							}
							else
							{
								variableByName13.VarArray[num24] = Convert.ToDouble(bd.Next(Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMin, null))), Convert.ToInt32(Convert.ToDouble(bx.PerformTextReplacements(variableByName13.dMax, null))) + 1));
							}
						}
						break;
					}
					case Command.CommandType.CT_CANCELMOVE:
						be = true;
						break;
					case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
					{
						string[] array3 = roomname.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action2 = null;
						if (array3.Length > 2)
						{
							action2 = c(array3[0], array3[1], array3[2]);
						}
						else if (array3.Length == 2)
						{
							action2 = c(array3[0], "", array3[1]);
						}
						action2?.CustomChoices.Clear();
						break;
					}
					case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
					{
						string[] array16 = roomname.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action3 = null;
						if (array16.Length > 2)
						{
							action3 = c(array16[0], array16[1], array16[2]);
						}
						else if (array16.Length == 2)
						{
							action3 = c(array16[0], "", array16[1]);
						}
						if (action3 == null)
						{
							break;
						}
						bool flag10 = false;
						foreach (string customChoice in action3.CustomChoices)
						{
							if (customChoice.Equals(text))
							{
								flag10 = true;
								break;
							}
						}
						if (!flag10)
						{
							action3.CustomChoices.Add(text);
						}
						break;
					}
					case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
					{
						string[] array2 = roomname.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action = null;
						if (array2.Length > 2)
						{
							action = c(array2[0], array2[1], array2[2]);
						}
						else if (array2.Length == 2)
						{
							action = c(array2[0], "", array2[1]);
						}
						action?.CustomChoices.Remove(text);
						break;
					}
					case Command.CommandType.CT_SETPLAYERGENDER:
						bx.ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname, ignoreCase: true);
						break;
					case Command.CommandType.CT_PAUSEGAME:
						this.m_h = false;
						TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "--------------------------------\r\n", Color.Black, (FontStyle)1);
						d();
						if (this.m_h)
						{
							return false;
						}
						break;
					case Command.CommandType.CT_LAYEREDIMAGE_ADD:
					{
						GamePicture gamePictureByName7 = bx.GetGamePictureByName(roomname);
						if (gamePictureByName7 != null)
						{
							gamePictureByName7.LayeredImages.Add(roomname2);
							a();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
					{
						GamePicture gamePictureByName6 = bx.GetGamePictureByName(roomname);
						if (gamePictureByName6 == null)
						{
							break;
						}
						foreach (string layeredImage in gamePictureByName6.LayeredImages)
						{
							if (layeredImage == roomname2)
							{
								gamePictureByName6.LayeredImages.Remove(layeredImage);
								break;
							}
						}
						a();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
					{
						GamePicture gamePictureByName4 = bx.GetGamePictureByName(roomname);
						GamePicture gamePictureByName5 = bx.GetGamePictureByName(roomname3);
						if (gamePictureByName4 == null || gamePictureByName5 == null)
						{
							break;
						}
						int num9 = -1;
						bool flag4 = false;
						foreach (string layeredImage2 in gamePictureByName4.LayeredImages)
						{
							num9++;
							if (layeredImage2 == roomname2)
							{
								flag4 = true;
								gamePictureByName4.LayeredImages.Remove(layeredImage2);
								break;
							}
						}
						if (flag4)
						{
							gamePictureByName4.LayeredImages.Insert(num9, roomname3);
							a();
						}
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
					{
						GamePicture gamePictureByName3 = bx.GetGamePictureByName(roomname);
						if (gamePictureByName3 != null)
						{
							gamePictureByName3.LayeredImages.Clear();
							a();
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERNAME:
						bx.ThePlayer.Name = bx.PerformTextReplacements(roomname3, null);
						break;
					case Command.CommandType.CT_DISPLAYPLAYERDESC:
					{
						string text13 = bx.PerformTextReplacements(bx.ThePlayer.Description, null);
						TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text13 + "\r\n", Color.Black, (FontStyle)0);
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
					{
						GameObject gameObject22 = bx.GetObjectByName(roomname);
						if (gameObject22 == null)
						{
							gameObject22 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject22 == null)
						{
							break;
						}
						GameObject.LocationType locationtype2 = gameObject22.locationtype;
						string locationname = gameObject22.locationname;
						bool flag8 = true;
						string text40 = string.Empty;
						foreach (string layeredZoneLevel in gameObject22.LayeredZoneLevels)
						{
							string[] array13 = layeredZoneLevel.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject @object in bx.ObjectList)
							{
								if (!@object.bWorn || @object.locationtype != locationtype2 || (locationtype2 == GameObject.LocationType.LT_CHARACTER && locationname != @object.locationname))
								{
									continue;
								}
								foreach (string layeredZoneLevel2 in @object.LayeredZoneLevels)
								{
									string[] array14 = layeredZoneLevel2.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (gameObject22.UniqueIdentifier != @object.UniqueIdentifier && array14[0] == array13[0] && Convert.ToInt32(array14[1]) >= Convert.ToInt32(array13[1]))
									{
										flag8 = false;
										if (text40.IndexOf(gameObject22.GetDisplayStringNameOnly()) == -1)
										{
											if (text40 == string.Empty)
											{
												text40 = ((locationtype2 == GameObject.LocationType.LT_CHARACTER) ? (text40 + locationname + " cannot remove " + gameObject22.GetDisplayStringNameOnly() + ".  " + locationname + " will need to remove " + @object.GetDisplayStringNameOnly()) : (text40 + "You cannot remove " + gameObject22.GetDisplayStringNameOnly() + ".  You need to remove " + @object.GetDisplayStringNameOnly()));
											}
											else
											{
												text40 = text40 + " and " + @object.GetDisplayStringNameOnly();
											}
										}
									}
								}
							}
						}
						if (!flag8)
						{
							text40 += " first.";
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text40 + "\r\n", Color.Black, (FontStyle)0);
							break;
						}
						if (locationtype2 != GameObject.LocationType.LT_CHARACTER)
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "You take off " + gameObject22.GetDisplayStringNameOnly() + ".\r\n", Color.Black, (FontStyle)0);
						}
						else
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, locationname = locationname + " takes off " + gameObject22.GetDisplayStringNameOnly() + ".\r\n", Color.Black, (FontStyle)0);
						}
						gameObject22.bWorn = false;
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_WEAR:
					{
						GameObject gameObject6 = bx.GetObjectByName(roomname);
						if (gameObject6 == null)
						{
							gameObject6 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject6 == null)
						{
							break;
						}
						GameObject.LocationType locationtype = gameObject6.locationtype;
						string text19 = gameObject6.locationname;
						bool flag2 = true;
						string text20 = string.Empty;
						foreach (string layeredZoneLevel3 in gameObject6.LayeredZoneLevels)
						{
							string[] array6 = layeredZoneLevel3.Split(new string[1] { ":" }, StringSplitOptions.None);
							foreach (GameObject object2 in bx.ObjectList)
							{
								if (!object2.bWorn || object2.locationtype != locationtype)
								{
									continue;
								}
								foreach (string layeredZoneLevel4 in object2.LayeredZoneLevels)
								{
									string[] array7 = layeredZoneLevel4.Split(new string[1] { ":" }, StringSplitOptions.None);
									if (array7[0] == array6[0] && Convert.ToInt32(array7[1]) >= Convert.ToInt32(array6[1]) && (locationtype != GameObject.LocationType.LT_CHARACTER || !(text19 != object2.locationname)))
									{
										flag2 = false;
										if (text20.IndexOf(gameObject6.GetDisplayStringNameOnly()) == -1)
										{
											if (text20 == string.Empty)
											{
												text20 = ((locationtype == GameObject.LocationType.LT_CHARACTER) ? (text20 + (text19 = text19 + " cannot wear " + gameObject6.GetDisplayStringNameOnly() + ".  " + text19 + " will need to remove " + object2.GetDisplayStringNameOnly())) : (text20 + "You cannot wear " + gameObject6.GetDisplayStringNameOnly() + ".  You will need to remove " + object2.GetDisplayStringNameOnly()));
											}
											else
											{
												text20 = text20 + " and " + object2.GetDisplayStringNameOnly();
											}
										}
									}
								}
							}
						}
						if (!flag2)
						{
							text20 += " first.";
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text20 + "\r\n", Color.Black, (FontStyle)0);
							break;
						}
						if (locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "You put on " + gameObject6.GetDisplayStringNameOnly() + ".\r\n", Color.Black, (FontStyle)0);
						}
						else
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text19 + " puts on " + gameObject6.GetDisplayStringNameOnly() + ".\r\n", Color.Black, (FontStyle)0);
						}
						gameObject6.bWorn = true;
						break;
					}
					case Command.CommandType.CT_DEBUGTEXT:
					{
						string[] commandLineArgs = Environment.GetCommandLineArgs();
						if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text + "\r\n", Color.Black, (FontStyle)0);
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYTEXT:
						TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text + "\r\n", Color.Black, (FontStyle)0);
						break;
					case Command.CommandType.CT_ENDGAME:
					{
						TextHandlers.AddTextToRTF(ref this.m_u, ref bx, text + "\r\n", Color.Black, (FontStyle)0);
						DialogResult val16 = ((Form)new EndGameDialog()).ShowDialog();
						if ((int)val16 == 6)
						{
							frmMain.m_g = true;
							q();
							return false;
						}
						if ((int)val16 == 5)
						{
							bx = null;
							ap = "";
							((Control)this.m_z).Enabled = false;
							x(null, null);
						}
						else
						{
							bx = null;
							ap = "";
							((Control)this.m_z).Enabled = false;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOINV:
					{
						GameObject gameObject15 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject15 = A_1;
							}
						}
						else
						{
							gameObject15 = bx.GetObjectByName(roomname);
							if (gameObject15 == null)
							{
								gameObject15 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject15 == null)
						{
							break;
						}
						if (bx.ThePlayer.bEnforceWeight)
						{
							double num14 = 0.0;
							foreach (GameObject object3 in bx.ObjectList)
							{
								if (object3.locationtype == GameObject.LocationType.LT_PLAYER)
								{
									num14 += bx.GetItemWeight(object3.UniqueIdentifier);
								}
							}
							num14 += bx.GetItemWeight(gameObject15.UniqueIdentifier);
							if (num14 > bx.ThePlayer.dWeightLimit)
							{
								MessageBox.Show("The " + gameObject15.name + " is too heavy to lift at the moment.  unload some stuff first.");
								return false;
							}
						}
						gameObject15.locationtype = GameObject.LocationType.LT_PLAYER;
						break;
					}
					case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
					{
						GameObject gameObject = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject = A_1;
							}
						}
						else
						{
							gameObject = bx.GetObjectByName(roomname);
							if (gameObject == null)
							{
								gameObject = bx.GetObjectByNameOld(roomname);
							}
						}
						GameObject gameObject2 = null;
						if (roomname2.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject2 = A_1;
							}
						}
						else
						{
							gameObject2 = bx.GetObjectByName(roomname2);
							if (gameObject2 == null)
							{
								gameObject2 = bx.GetObjectByNameOld(roomname2);
							}
						}
						if (gameObject == null || gameObject2 == null)
						{
							break;
						}
						foreach (GameObject object4 in bx.ObjectList)
						{
							if (object4.locationtype == GameObject.LocationType.LT_IN_OBJECT && object4.locationname == gameObject.UniqueIdentifier.ToString())
							{
								object4.locationname = gameObject2.UniqueIdentifier.ToString();
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_VISIBILITY:
					{
						GameObject gameObject27 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject27 = A_1;
							}
						}
						else
						{
							gameObject27 = bx.GetObjectByName(roomname);
							if (gameObject27 == null)
							{
								gameObject27 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject27 != null)
						{
							if (roomname2.Equals("Visible"))
							{
								gameObject27.bVisible = true;
							}
							else
							{
								gameObject27.bVisible = false;
							}
							this.l();
						}
						break;
					}
					case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
						foreach (GameObject object5 in bx.ObjectList)
						{
							if (object5.locationtype == GameObject.LocationType.LT_PLAYER)
							{
								object5.locationtype = GameObject.LocationType.LT_CHARACTER;
								object5.locationname = roomname;
							}
						}
						break;
					case Command.CommandType.CT_MOVEINVENTORYTOROOM:
						foreach (GameObject object6 in bx.ObjectList)
						{
							if (object6.locationtype == GameObject.LocationType.LT_PLAYER)
							{
								if (roomname == Room.CurrentRoomGuid.ToString())
								{
									object6.locationtype = GameObject.LocationType.LT_ROOM;
									object6.locationname = bx.ThePlayer.CurrentRoom.UniqueID.ToString();
								}
								else if (roomname == Room.VoidRoomGuid.ToString())
								{
									object6.locationtype = GameObject.LocationType.LT_NULL;
								}
								else
								{
									object6.locationtype = GameObject.LocationType.LT_ROOM;
									object6.locationname = roomname;
								}
							}
						}
						break;
					case Command.CommandType.CT_MOVECHARINVTOPLAYER:
					{
						Character character2 = null;
						character2 = bx.GetCharacterByName(roomname);
						if (character2 == null)
						{
							break;
						}
						foreach (GameObject object7 in bx.ObjectList)
						{
							if (object7.locationtype == GameObject.LocationType.LT_CHARACTER && object7.locationname == character2.Charname && object7.bCarryable && object7.bVisible)
							{
								object7.locationtype = GameObject.LocationType.LT_PLAYER;
							}
						}
						break;
					}
					case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
					{
						Room room7 = null;
						room7 = ((!(roomname == Room.CurrentRoomGuid.ToString())) ? bx.GetRoomByID(new Guid(roomname)) : bx.ThePlayer.CurrentRoom);
						if (room7 == null)
						{
							break;
						}
						foreach (GameObject object8 in bx.ObjectList)
						{
							if (object8.locationtype == GameObject.LocationType.LT_ROOM && object8.locationname == room7.UniqueID.ToString() && object8.bCarryable && object8.bVisible)
							{
								object8.locationtype = GameObject.LocationType.LT_PLAYER;
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
					{
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, bx.ThePlayer.CurrentRoom.Description + "\r\n", Color.Black, (FontStyle)0);
							break;
						}
						Room room4 = null;
						try
						{
							room4 = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room4 = bx.GetRoomByName(ref roomname);
						}
						if (room4 != null)
						{
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, room4.Description + "\r\n", Color.Black, (FontStyle)0);
						}
						break;
					}
					case Command.CommandType.CT_CHAR_DISPLAYPORT:
					{
						Character character5 = null;
						character5 = bx.GetCharacterByName(roomname);
						if (character5 == null)
						{
							break;
						}
						if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
						{
							((TextBoxBase)this.m_u).ReadOnly = false;
							Clipboard.SetDataObject(bx.GetPictureByName(character5.CharPortrait));
							((TextBoxBase)this.m_u).Paste();
							((TextBoxBase)this.m_u).AppendText("\r\n");
							((TextBoxBase)this.m_u).ReadOnly = true;
						}
						if (!bx.bHideMainPicDisplay)
						{
							this.m_t.Image = null;
							object pictureByName16 = bx.GetPictureByName(character5.CharPortrait);
							object obj32 = ((pictureByName16 is Image) ? pictureByName16 : null);
							Image val15 = (Image)((obj32 is Image) ? obj32 : null);
							if (val15 != null)
							{
								((Control)by).Visible = false;
								((Control)this.m_t).Visible = true;
								((Control)this.m_t).Tag = bx.GetGamePictureByName(character5.CharPortrait);
								((Control)this.m_t).BackgroundImage = val15;
							}
							else if (obj32 != null)
							{
								((Control)by).Visible = true;
								((Control)this.m_t).Visible = false;
								by.URL = obj32 as string;
							}
							object pictureByName17 = bx.GetPictureByName(character5.CharPortrait);
							obj32 = ((pictureByName17 is Image) ? pictureByName17 : null);
							val15 = (Image)((obj32 is Image) ? obj32 : null);
							if (val15 != null)
							{
								((Control)by).Visible = false;
								((Control)this.m_t).Visible = true;
								this.m_t.Image = val15;
							}
							else if (obj32 != null)
							{
								((Control)by).Visible = true;
								((Control)this.m_t).Visible = false;
								by.URL = obj32 as string;
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMPICTURE:
					{
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
							{
								((TextBoxBase)this.m_u).ReadOnly = false;
								Clipboard.SetDataObject(bx.GetPictureByName(bx.ThePlayer.CurrentRoom.RoomPic));
								((TextBoxBase)this.m_u).Paste();
								((TextBoxBase)this.m_u).AppendText("\r\n");
								((TextBoxBase)this.m_u).ReadOnly = true;
							}
							if (!bx.bHideMainPicDisplay)
							{
								this.m_t.Image = null;
								object pictureByName = bx.GetPictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
								object obj2 = ((pictureByName is Image) ? pictureByName : null);
								Image val2 = (Image)((obj2 is Image) ? obj2 : null);
								if (val2 != null)
								{
									((Control)by).Visible = false;
									((Control)this.m_t).Visible = true;
									((Control)this.m_t).Tag = bx.GetGamePictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
									((Control)this.m_t).BackgroundImage = val2;
								}
								else if (obj2 != null)
								{
									((Control)by).Visible = true;
									((Control)this.m_t).Visible = false;
									by.URL = obj2 as string;
								}
								object pictureByName2 = bx.GetPictureByName(bx.ThePlayer.CurrentRoom.LayeredRoomPic);
								obj2 = ((pictureByName2 is Image) ? pictureByName2 : null);
								val2 = (Image)((obj2 is Image) ? obj2 : null);
								if (val2 != null)
								{
									((Control)by).Visible = false;
									((Control)this.m_t).Visible = true;
									((Control)this.m_t).Tag = bx.GetGamePictureByName(bx.ThePlayer.CurrentRoom.RoomPic);
									this.m_t.Image = val2;
								}
								else if (obj2 != null)
								{
									((Control)by).Visible = true;
									((Control)this.m_t).Visible = false;
									by.URL = obj2 as string;
								}
							}
							break;
						}
						Room room2 = null;
						try
						{
							room2 = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room2 = bx.GetRoomByName(ref roomname);
						}
						if (room2 == null)
						{
							break;
						}
						if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
						{
							((TextBoxBase)this.m_u).ReadOnly = false;
							Clipboard.SetDataObject(bx.GetPictureByName(bx.ThePlayer.CurrentRoom.RoomPic));
							((TextBoxBase)this.m_u).Paste();
							((TextBoxBase)this.m_u).AppendText("\r\n");
							((TextBoxBase)this.m_u).ReadOnly = true;
						}
						if (!bx.bHideMainPicDisplay)
						{
							this.m_t.Image = null;
							object pictureByName3 = bx.GetPictureByName(room2.RoomPic);
							object obj4 = ((pictureByName3 is Image) ? pictureByName3 : null);
							Image val3 = (Image)((obj4 is Image) ? obj4 : null);
							if (val3 != null)
							{
								((Control)by).Visible = false;
								((Control)this.m_t).Visible = true;
								((Control)this.m_t).Tag = bx.GetGamePictureByName(room2.RoomPic);
								((Control)this.m_t).BackgroundImage = val3;
							}
							else if (obj4 != null)
							{
								((Control)by).Visible = true;
								((Control)this.m_t).Visible = false;
								by.URL = obj4 as string;
							}
							object pictureByName4 = bx.GetPictureByName(room2.LayeredRoomPic);
							obj4 = ((pictureByName4 is Image) ? pictureByName4 : null);
							val3 = (Image)((obj4 is Image) ? obj4 : null);
							if (val3 != null)
							{
								((Control)by).Visible = false;
								((Control)this.m_t).Visible = true;
								this.m_t.Image = val3;
							}
							else if (obj4 != null)
							{
								((Control)by).Visible = true;
								((Control)this.m_t).Visible = false;
								by.URL = obj4 as string;
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOROOM:
					{
						GameObject gameObject25 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject25 = A_1;
							}
						}
						else
						{
							gameObject25 = bx.GetObjectByName(roomname);
							if (gameObject25 == null)
							{
								gameObject25 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject25 == null)
						{
							break;
						}
						gameObject25.locationtype = GameObject.LocationType.LT_ROOM;
						if (roomname2 == Room.CurrentRoomGuid.ToString())
						{
							gameObject25.locationname = bx.ThePlayer.CurrentRoom.UniqueID.ToString();
							break;
						}
						if (roomname2 == Room.VoidRoomGuid.ToString())
						{
							gameObject25.locationtype = GameObject.LocationType.LT_NULL;
							break;
						}
						string text41 = string.Empty;
						try
						{
							new Guid(roomname2);
							text41 = roomname2;
						}
						catch
						{
							Room roomByName3 = bx.GetRoomByName(ref roomname2);
							if (roomByName3 != null)
							{
								text41 = roomByName3.UniqueID.ToString();
							}
						}
						if (text41 == string.Empty)
						{
							MessageBox.Show("Error in command CT_MoveItemToRoom.  Could not locate a room called " + roomname2);
						}
						else
						{
							gameObject25.locationname = text41;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOOBJ:
					{
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 == null)
							{
								break;
							}
							string text30 = string.Empty;
							try
							{
								text30 = new Guid(roomname2).ToString();
							}
							catch
							{
								GameObject objectByNameOld = bx.GetObjectByNameOld(roomname2);
								if (objectByNameOld != null)
								{
									text30 = objectByNameOld.UniqueIdentifier.ToString();
								}
							}
							if (text30 != string.Empty)
							{
								A_1.locationtype = GameObject.LocationType.LT_IN_OBJECT;
								A_1.locationname = text30;
							}
							break;
						}
						GameObject gameObject14 = bx.GetObjectByName(roomname);
						if (gameObject14 == null)
						{
							gameObject14 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject14 == null)
						{
							break;
						}
						string text31 = string.Empty;
						try
						{
							text31 = new Guid(roomname2).ToString();
						}
						catch
						{
							GameObject objectByNameOld2 = bx.GetObjectByNameOld(roomname2);
							if (objectByNameOld2 != null)
							{
								text31 = objectByNameOld2.UniqueIdentifier.ToString();
							}
						}
						if (text31 != string.Empty)
						{
							gameObject14.locationtype = GameObject.LocationType.LT_IN_OBJECT;
							gameObject14.locationname = text31;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOCHAR:
					{
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								A_1.locationtype = GameObject.LocationType.LT_CHARACTER;
								A_1.locationname = roomname2;
							}
							break;
						}
						GameObject gameObject5 = bx.GetObjectByName(roomname);
						if (gameObject5 == null)
						{
							gameObject5 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject5 != null)
						{
							gameObject5.locationtype = GameObject.LocationType.LT_CHARACTER;
							gameObject5.locationname = roomname2;
						}
						break;
					}
					case Command.CommandType.CT_SETEXIT:
					{
						Room room = null;
						try
						{
							room = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room = bx.GetRoomByName(ref roomname);
						}
						if (room == null)
						{
							break;
						}
						int num3 = roomname2.IndexOf('-');
						string text4 = roomname2.Substring(0, num3);
						int num4 = roomname2.IndexOf('-', num3 + 1);
						string empty2 = string.Empty;
						empty2 = ((num4 <= -1) ? roomname2.Substring(num3 + 1) : roomname2.Substring(num3 + 1, num4 - num3 - 1));
						empty2 = empty2.Trim();
						bool bActive = false;
						if (empty2 == "Active")
						{
							bActive = true;
						}
						for (int j = 0; j < room.Exits.Count; j++)
						{
							if (((Exit)room.Exits[j]).Direction.ToString() == text4)
							{
								((Exit)room.Exits[j]).bActive = bActive;
								break;
							}
						}
						this.i();
						break;
					}
					case Command.CommandType.CT_SETEXITDESTINATION:
					{
						Room room10 = null;
						try
						{
							room10 = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room10 = bx.GetRoomByName(ref roomname);
						}
						if (room10 == null)
						{
							break;
						}
						Exit exit = null;
						for (int num23 = 0; num23 < room10.Exits.Count; num23++)
						{
							if (((Exit)room10.Exits[num23]).Direction.ToString() == roomname2)
							{
								exit = (Exit)room10.Exits[num23];
								break;
							}
						}
						if (exit != null)
						{
							if (roomname3 == "<None>")
							{
								exit.DestinationRoom = string.Empty;
								exit.bActive = false;
							}
							else
							{
								Room room11 = null;
								try
								{
									room11 = bx.GetRoomByID(new Guid(roomname3));
								}
								catch
								{
									room11 = bx.GetRoomByName(ref roomname3);
								}
								if (room11 != null)
								{
									exit.DestinationRoom = room11.UniqueID.ToString();
									exit.bActive = true;
								}
							}
						}
						this.i();
						break;
					}
					case Command.CommandType.CT_EXECUTETIMER:
					{
						bool flag9 = frmMain.m_d;
						string text42 = frmMain.m_e;
						frmMain.m_d = true;
						frmMain.m_f = false;
						frmMain.m_e = string.Empty;
						Timer timerByName3 = bx.GetTimerByName(roomname);
						if (timerByName3 != null)
						{
							frmMain.m_e = timerByName3.Name;
							Action A_16 = timerByName3.GetActionByName("<<On Each Turn>>");
							if (A_16 != null)
							{
								a(ref A_16, null);
								while (frmMain.m_f)
								{
									frmMain.m_f = false;
									a(ref A_16, null);
								}
							}
						}
						frmMain.m_d = flag9;
						frmMain.m_e = text42;
						break;
					}
					case Command.CommandType.CT_RESETTIMER:
					{
						Timer timerByName2 = bx.GetTimerByName(roomname);
						if (timerByName2 != null)
						{
							timerByName2.TurnNumber = 0;
							if (frmMain.m_d && frmMain.m_e == timerByName2.Name)
							{
								frmMain.m_f = true;
								return false;
							}
							frmMain.m_f = false;
							return false;
						}
						break;
					}
					case Command.CommandType.CT_SETTIMER:
					{
						Timer timerByName = bx.GetTimerByName(roomname);
						if (timerByName != null)
						{
							if (string.Compare(roomname2, "Active", ignoreCase: true) == 0)
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
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject8 = A_1;
							}
						}
						else
						{
							gameObject8 = bx.GetObjectByName(roomname);
							if (gameObject8 == null)
							{
								gameObject8 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject8 != null)
						{
							gameObject8.description = text;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERDESC:
						bx.ThePlayer.Description = text;
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
					{
						GameVariable variableByName5 = bx.GetVariableByName(roomname);
						if (variableByName5 == null)
						{
							break;
						}
						string[] array5 = roomname2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text17 = string.Empty;
						if (array5.Length == 2)
						{
							string roomname4 = array5[0];
							string text18 = array5[1];
							Room room5 = null;
							room5 = ((!(roomname4 == "<CurrentRoom>")) ? bx.GetRoomByName(ref roomname4) : bx.ThePlayer.CurrentRoom);
							if (room5 != null)
							{
								foreach (CustomProperty customProperty7 in room5.CustomProperties)
								{
									if (customProperty7.Name == text18)
									{
										text17 = customProperty7.Value;
										break;
									}
								}
							}
						}
						int num7 = b(roomname);
						int num8 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName5.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num7 == -1)
							{
								variableByName5.sString = text17;
							}
							else if (num8 != -1)
							{
								((ArrayList)variableByName5.VarArray[num7])[num8] = text17;
							}
							else
							{
								variableByName5.VarArray[num7] = text17;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num7 == -1)
								{
									variableByName5.dNumType = Convert.ToDouble(text17);
								}
								else if (num8 != -1)
								{
									((ArrayList)variableByName5.VarArray[num7])[num8] = text17;
								}
								else
								{
									variableByName5.VarArray[num7] = text17;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Room Property Value " + text17 + " is not a valid number.");
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
						GameVariable variableByName4 = bx.GetVariableByName(roomname);
						if (variableByName4 == null)
						{
							break;
						}
						string[] array4 = roomname2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text14 = string.Empty;
						if (array4.Length == 2)
						{
							string timername = array4[0];
							string text15 = array4[1];
							Timer timer = null;
							timer = bx.GetTimerByName(timername);
							if (timer != null)
							{
								foreach (CustomProperty customProperty8 in timer.CustomProperties)
								{
									if (customProperty8.Name == text15)
									{
										text14 = customProperty8.Value;
										break;
									}
								}
							}
						}
						int num5 = b(roomname);
						int num6 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName4.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num5 == -1)
							{
								variableByName4.sString = text14;
							}
							else if (num6 != -1)
							{
								((ArrayList)variableByName4.VarArray[num5])[num6] = text14;
							}
							else
							{
								variableByName4.VarArray[num5] = text14;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num5 == -1)
								{
									variableByName4.dNumType = Convert.ToDouble(text14);
								}
								else if (num6 != -1)
								{
									((ArrayList)variableByName4.VarArray[num5])[num6] = text14;
								}
								else
								{
									variableByName4.VarArray[num5] = text14;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Timer Property Value " + text14 + " is not a valid number.");
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
						GameVariable variableByName15 = bx.GetVariableByName(roomname);
						if (variableByName15 == null)
						{
							break;
						}
						string[] array17 = roomname2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text48 = string.Empty;
						if (array17.Length == 2)
						{
							string varname2 = array17[0];
							string text49 = array17[1];
							GameVariable gameVariable3 = null;
							gameVariable3 = bx.GetVariableByName(varname2);
							if (gameVariable3 != null)
							{
								foreach (CustomProperty customProperty9 in gameVariable3.CustomProperties)
								{
									if (customProperty9.Name == text49)
									{
										text48 = customProperty9.Value;
										break;
									}
								}
							}
						}
						int num29 = b(roomname);
						int num30 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName15.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num29 == -1)
							{
								variableByName15.sString = text48;
							}
							else if (num30 != -1)
							{
								((ArrayList)variableByName15.VarArray[num29])[num30] = text48;
							}
							else
							{
								variableByName15.VarArray[num29] = text48;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num29 == -1)
								{
									variableByName15.dNumType = Convert.ToDouble(text48);
								}
								else if (num30 != -1)
								{
									((ArrayList)variableByName15.VarArray[num29])[num30] = text48;
								}
								else
								{
									variableByName15.VarArray[num29] = text48;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Variable Property Value " + text48 + " is not a valid number.");
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
					{
						if (roomname == "<Default>")
						{
							((Control)at).BackgroundImage = (Image)(object)Resources._300px_Compass_Rose_English_North;
							break;
						}
						object pictureByName15 = bx.GetPictureByName(roomname);
						Image val14 = (Image)((pictureByName15 is Image) ? pictureByName15 : null);
						if (val14 != null)
						{
							((Control)at).BackgroundImage = val14;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_UD_COMPASS:
					{
						if (roomname == "<Default>")
						{
							((Control)b4).BackgroundImage = (Image)(object)Resources._300px_Compass_Rose_UD;
							break;
						}
						object pictureByName14 = bx.GetPictureByName(roomname);
						Image val13 = (Image)((pictureByName14 is Image) ? pictureByName14 : null);
						if (val13 != null)
						{
							((Control)b4).BackgroundImage = val13;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
					{
						GameVariable variableByName12 = bx.GetVariableByName(roomname);
						if (variableByName12 == null)
						{
							break;
						}
						string[] array15 = roomname2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text43 = string.Empty;
						if (array15.Length == 2)
						{
							string charname2 = array15[0];
							string text44 = array15[1];
							Character character4 = null;
							character4 = bx.GetCharacterByName(charname2);
							if (character4 != null)
							{
								foreach (CustomProperty customProperty10 in character4.CustomProperties)
								{
									if (customProperty10.Name == text44)
									{
										text43 = customProperty10.Value;
										break;
									}
								}
							}
						}
						int num21 = b(roomname);
						int num22 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName12.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num21 == -1)
							{
								variableByName12.sString = text43;
							}
							else if (num22 != -1)
							{
								((ArrayList)variableByName12.VarArray[num21])[num22] = text43;
							}
							else
							{
								variableByName12.VarArray[num21] = text43;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num21 == -1)
								{
									variableByName12.dNumType = Convert.ToDouble(text43);
								}
								else if (num22 != -1)
								{
									((ArrayList)variableByName12.VarArray[num21])[num22] = text43;
								}
								else
								{
									variableByName12.VarArray[num21] = text43;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Character Property Value " + text43 + " is not a valid number.");
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
						GameVariable variableByName9 = bx.GetVariableByName(roomname);
						if (variableByName9 == null)
						{
							break;
						}
						string[] array12 = roomname2.Split(new string[1] { ":" }, StringSplitOptions.None);
						string text34 = string.Empty;
						if (array12.Length == 2)
						{
							string text35 = array12[0];
							string text36 = array12[1];
							GameObject gameObject18 = null;
							if (text35 == "<Self>")
							{
								if (A_1 != null)
								{
									gameObject18 = A_1;
								}
							}
							else
							{
								gameObject18 = bx.GetObjectByNameOld(text35);
							}
							if (gameObject18 != null)
							{
								foreach (CustomProperty customProperty11 in gameObject18.CustomProperties)
								{
									if (customProperty11.Name == text36)
									{
										text34 = customProperty11.Value;
										break;
									}
								}
							}
						}
						int num15 = b(roomname);
						int num16 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName9.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num15 == -1)
							{
								variableByName9.sString = text34;
							}
							else if (num16 != -1)
							{
								((ArrayList)variableByName9.VarArray[num15])[num16] = text34;
							}
							else
							{
								variableByName9.VarArray[num15] = text34;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num15 == -1)
								{
									variableByName9.dNumType = Convert.ToDouble(text34);
								}
								else if (num16 != -1)
								{
									((ArrayList)variableByName9.VarArray[num15])[num16] = text34;
								}
								else
								{
									variableByName9.VarArray[num15] = text34;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Item Property Value " + text34 + " is not a valid number.");
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
						GameVariable variableByName8 = bx.GetVariableByName(roomname);
						if (variableByName8 == null)
						{
							break;
						}
						string text32 = string.Empty;
						string text33 = roomname2;
						foreach (CustomProperty customProperty12 in bx.ThePlayer.CustomProperties)
						{
							if (customProperty12.Name == text33)
							{
								text32 = customProperty12.Value;
								break;
							}
						}
						int num12 = b(roomname);
						int num13 = a(roomname);
						bx.PerformTextReplacements(roomname3, null);
						switch (variableByName8.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num12 == -1)
							{
								variableByName8.sString = text32;
							}
							else if (num13 != -1)
							{
								((ArrayList)variableByName8.VarArray[num12])[num13] = text32;
							}
							else
							{
								variableByName8.VarArray[num12] = text32;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num12 == -1)
								{
									variableByName8.dNumType = Convert.ToDouble(text32);
								}
								else if (num13 != -1)
								{
									((ArrayList)variableByName8.VarArray[num12])[num13] = text32;
								}
								else
								{
									variableByName8.VarArray[num12] = text32;
								}
							}
							catch
							{
								if (this.m_i != null)
								{
									this.m_i.AddErrorData("ERROR: Set Variable with Player Property Value " + text32 + " is not a valid number.");
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
						string text25 = bx.PerformTextReplacements(roomname3, null);
						string[] array10 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array10.Length != 2)
						{
							break;
						}
						string roomname5 = array10[0];
						string text26 = array10[1];
						Room room6 = null;
						room6 = ((!(roomname5 == "<CurrentRoom>")) ? bx.GetRoomByName(ref roomname5) : bx.ThePlayer.CurrentRoom);
						if (room6 == null)
						{
							break;
						}
						for (int num10 = 0; num10 < room6.CustomProperties.Count; num10++)
						{
							CustomProperty A_12 = room6.CustomProperties[num10] as CustomProperty;
							if (A_12 != null && A_12.Name == text26)
							{
								if (command.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
								{
									object result7 = null;
									MathEval.EvaluateString(ref result7, text25);
									text25 = result7.ToString();
								}
								a(ref A_12, roomname2, text25);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
					{
						string text23 = bx.PerformTextReplacements(roomname3, null);
						string[] array9 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array9.Length != 2)
						{
							break;
						}
						string timername2 = array9[0];
						string text24 = array9[1];
						Timer timer2 = null;
						timer2 = bx.GetTimerByName(timername2);
						if (timer2 == null)
						{
							break;
						}
						for (int n = 0; n < timer2.CustomProperties.Count; n++)
						{
							CustomProperty A_11 = timer2.CustomProperties[n] as CustomProperty;
							if (A_11 != null && A_11.Name == text24)
							{
								if (command.cmdtype == Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS)
								{
									object result6 = null;
									MathEval.EvaluateString(ref result6, text23);
									text23 = result6.ToString();
								}
								a(ref A_11, roomname2, text23);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
					{
						string text21 = bx.PerformTextReplacements(roomname3, null);
						string[] array8 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array8.Length != 2)
						{
							break;
						}
						string varname = array8[0];
						string text22 = array8[1];
						GameVariable gameVariable2 = null;
						gameVariable2 = bx.GetVariableByName(varname);
						if (gameVariable2 == null)
						{
							break;
						}
						for (int m = 0; m < gameVariable2.CustomProperties.Count; m++)
						{
							CustomProperty A_10 = gameVariable2.CustomProperties[m] as CustomProperty;
							if (A_10 != null && A_10.Name == text22)
							{
								if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS)
								{
									object result5 = null;
									MathEval.EvaluateString(ref result5, text21);
									text21 = result5.ToString();
								}
								a(ref A_10, roomname2, text21);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
					{
						string text27 = bx.PerformTextReplacements(roomname3, null);
						string[] array11 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array11.Length != 2)
						{
							break;
						}
						string text28 = array11[0];
						string text29 = array11[1];
						GameObject gameObject13 = null;
						if (text28 == "<Self>")
						{
							if (A_1 != null)
							{
								gameObject13 = A_1;
							}
						}
						else
						{
							gameObject13 = bx.GetObjectByNameOld(text28);
						}
						if (gameObject13 == null)
						{
							break;
						}
						for (int num11 = 0; num11 < gameObject13.CustomProperties.Count; num11++)
						{
							CustomProperty A_14 = gameObject13.CustomProperties[num11] as CustomProperty;
							if (A_14 != null && A_14.Name == text29)
							{
								if (command.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
								{
									object result8 = null;
									MathEval.EvaluateString(ref result8, text27);
									text27 = result8.ToString();
								}
								a(ref A_14, roomname2, text27);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
					{
						string text9 = bx.PerformTextReplacements(roomname3, null);
						string[] array = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
						if (array.Length != 2)
						{
							break;
						}
						string charname = array[0];
						string text10 = array[1];
						Character character = null;
						character = bx.GetCharacterByName(charname);
						if (character == null)
						{
							break;
						}
						for (int l = 0; l < character.CustomProperties.Count; l++)
						{
							CustomProperty A_6 = character.CustomProperties[l] as CustomProperty;
							if (A_6 != null && A_6.Name == text10)
							{
								if (command.cmdtype == Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS)
								{
									object result3 = null;
									MathEval.EvaluateString(ref result3, text9);
									text9 = result3.ToString();
								}
								a(ref A_6, roomname2, text9);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
					{
						string text7 = bx.PerformTextReplacements(roomname3, null);
						string text8 = roomname;
						for (int k = 0; k < bx.ThePlayer.CustomProperties.Count; k++)
						{
							CustomProperty A_5 = bx.ThePlayer.CustomProperties[k] as CustomProperty;
							if (A_5 != null && A_5.Name == text8)
							{
								if (command.cmdtype == Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS)
								{
									object result2 = null;
									MathEval.EvaluateString(ref result2, text7);
									text7 = result2.ToString();
								}
								a(ref A_5, roomname2, text7);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETVARIABLE:
					case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
					{
						bool flag11 = false;
						if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
						{
							flag11 = true;
						}
						bool flag12 = false;
						int num26 = roomname.IndexOf("Array:");
						if (num26 > -1)
						{
							flag12 = true;
							roomname = roomname.Remove(num26, 6);
						}
						GameVariable variableByName14 = bx.GetVariableByName(roomname);
						if (variableByName14 == null)
						{
							break;
						}
						int num27 = b(roomname);
						int num28 = a(roomname);
						string text47 = bx.PerformTextReplacements(roomname3, null);
						text = bx.PerformTextReplacements(text, null);
						object result9 = null;
						if (flag11)
						{
							MathEval.EvaluateString(ref result9, text47);
							if (!flag12 && result9 != null)
							{
								text47 = result9.ToString();
							}
						}
						switch (variableByName14.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (roomname2)
							{
							case "Equals":
								if (flag12)
								{
									a(variableByName14, ref result9);
								}
								else if (num27 == -1)
								{
									variableByName14.dtDateTime = Convert.ToDateTime(text47, Game.myDTFI);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = text47;
								}
								else
								{
									variableByName14.VarArray[num27] = Convert.ToDateTime(text47, Game.myDTFI);
								}
								break;
							case "Add Days":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddDays(Convert.ToInt32(text47));
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = Convert.ToDateTime(((ArrayList)variableByName14.VarArray[num27])[num28]).AddDays(Convert.ToInt32(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = ((DateTime)variableByName14.VarArray[num27]).AddDays(Convert.ToInt32(text47));
								}
								break;
							case "Add Hours":
							{
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47));
									break;
								}
								if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47)).ToString();
									break;
								}
								ArrayList varArray = variableByName14.VarArray;
								object value = (variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47)));
								varArray[num27] = value;
								break;
							}
							case "Add Minutes":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47));
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47));
								}
								break;
							case "Add Seconds":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47));
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47));
								}
								break;
							case "Subtract Days":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddDays(Convert.ToInt32(text47) * -1);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddDays(Convert.ToInt32(text47) * -1).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddDays(Convert.ToInt32(text47) * -1);
								}
								break;
							case "Subtract Hours":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47) * -1);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47) * -1).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddHours(Convert.ToInt32(text47) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47) * -1);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47) * -1).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddMinutes(Convert.ToInt32(text47) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47) * -1);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47) * -1).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = variableByName14.dtDateTime.AddSeconds(Convert.ToInt32(text47) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, Convert.ToInt32(text47), variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, Convert.ToInt32(text47), variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, Convert.ToInt32(text47), variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, Convert.ToInt32(text47), variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, Convert.ToInt32(text47), variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, Convert.ToInt32(text47), variableByName14.dtDateTime.Minute, variableByName14.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, Convert.ToInt32(text47), variableByName14.dtDateTime.Second);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, Convert.ToInt32(text47), variableByName14.dtDateTime.Second).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, Convert.ToInt32(text47), variableByName14.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num27 == -1)
								{
									variableByName14.dtDateTime = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, Convert.ToInt32(text47));
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, Convert.ToInt32(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = new DateTime(variableByName14.dtDateTime.Year, variableByName14.dtDateTime.Month, variableByName14.dtDateTime.Day, variableByName14.dtDateTime.Hour, variableByName14.dtDateTime.Minute, Convert.ToInt32(text47));
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							switch (roomname2)
							{
							case "Equals":
								if (flag12)
								{
									a(variableByName14, ref result9);
								}
								else if (num27 == -1)
								{
									variableByName14.dNumType = Convert.ToDouble(text47);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = text47;
								}
								else
								{
									variableByName14.VarArray[num27] = Convert.ToDouble(text47);
								}
								break;
							case "Add":
								if (num27 == -1)
								{
									variableByName14.dNumType += Convert.ToDouble(text47);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) + Convert.ToDouble(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = (double)variableByName14.VarArray[num27] + Convert.ToDouble(text47);
								}
								break;
							case "Subtract":
								if (num27 == -1)
								{
									variableByName14.dNumType -= Convert.ToDouble(text47);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) - Convert.ToDouble(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = (double)variableByName14.VarArray[num27] - Convert.ToDouble(text47);
								}
								break;
							case "Multiply":
								if (num27 == -1)
								{
									variableByName14.dNumType *= Convert.ToDouble(text47);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) * Convert.ToDouble(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = (double)variableByName14.VarArray[num27] * Convert.ToDouble(text47);
								}
								break;
							case "Divide":
								if (num27 == -1)
								{
									variableByName14.dNumType /= Convert.ToDouble(text47);
								}
								else if (num28 != -1)
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) / Convert.ToDouble(text47)).ToString();
								}
								else
								{
									variableByName14.VarArray[num27] = (double)variableByName14.VarArray[num27] / Convert.ToDouble(text47);
								}
								break;
							}
							if (!variableByName14.bEnforceRestrictions)
							{
								break;
							}
							if (num27 == -1)
							{
								if (variableByName14.dNumType < Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMin, null)))
								{
									variableByName14.dNumType = Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMin, null));
								}
								if (variableByName14.dNumType > Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMax, null)))
								{
									variableByName14.dNumType = Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMax, null));
								}
							}
							else if (num28 != -1)
							{
								if (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) < Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMin, null)))
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = bx.PerformTextReplacements(variableByName14.dMin, null).ToString();
								}
								if (Convert.ToDouble(((ArrayList)variableByName14.VarArray[num27])[num28]) > Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMax, null)))
								{
									((ArrayList)variableByName14.VarArray[num27])[num28] = bx.PerformTextReplacements(variableByName14.dMax, null).ToString();
								}
							}
							else
							{
								if ((double)variableByName14.VarArray[num27] < Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMin, null)))
								{
									variableByName14.VarArray[num27] = Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMin, null));
								}
								if ((double)variableByName14.VarArray[num27] > Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMax, null)))
								{
									variableByName14.VarArray[num27] = Convert.ToDouble(bx.PerformTextReplacements(variableByName14.dMax, null));
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (flag11)
							{
								MathEval.EvaluateString(ref result9, text);
								if (!flag12 && result9 != null)
								{
									text = result9.ToString();
								}
							}
							if (flag12)
							{
								a(variableByName14, ref result9);
							}
							else if (num27 == -1)
							{
								variableByName14.sString = text;
							}
							else if (num28 != -1)
							{
								((ArrayList)variableByName14.VarArray[num27])[num28] = text;
							}
							else
							{
								variableByName14.VarArray[num27] = text;
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
					{
						GameVariable variableByName16 = bx.GetVariableByName(roomname);
						GameVariable variableByName17 = bx.GetVariableByName(roomname3);
						int num31 = b(roomname3);
						int num32 = a(roomname3);
						int num33 = 0;
						double num34 = 0.0;
						if (num31 == -1)
						{
							num33 = Convert.ToInt32(variableByName17.dNumType);
							num34 = Convert.ToDouble(variableByName17.dNumType);
						}
						else if (num32 != -1)
						{
							num33 = Convert.ToInt32(((ArrayList)variableByName17.VarArray[num31])[num32]);
							num34 = Convert.ToDouble(((ArrayList)variableByName17.VarArray[num31])[num32]);
						}
						else
						{
							num33 = Convert.ToInt32((double)variableByName17.VarArray[num31]);
							num34 = Convert.ToDouble((double)variableByName17.VarArray[num31]);
						}
						num31 = b(roomname);
						int num35 = a(roomname);
						if (variableByName16 == null)
						{
							break;
						}
						switch (variableByName16.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							switch (roomname2)
							{
							case "Equals":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = Convert.ToDateTime(num33, Game.myDTFI);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = num33.ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = Convert.ToDateTime(num33, Game.myDTFI);
								}
								break;
							case "Add Days":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33));
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33)).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33));
								}
								break;
							case "Add Hours":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33));
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33)).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33));
								}
								break;
							case "Add Minutes":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33));
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33)).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33));
								}
								break;
							case "Add Seconds":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33));
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33)).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33));
								}
								break;
							case "Subtract Days":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33) * -1);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33) * -1).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddDays(Convert.ToInt32(num33) * -1);
								}
								break;
							case "Subtract Hours":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33) * -1);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33) * -1).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddHours(Convert.ToInt32(num33) * -1);
								}
								break;
							case "Subtract Minutes":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33) * -1);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33) * -1).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddMinutes(Convert.ToInt32(num33) * -1);
								}
								break;
							case "Subtract Seconds":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33) * -1);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33) * -1).ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = variableByName16.dtDateTime.AddSeconds(Convert.ToInt32(num33) * -1);
								}
								break;
							case "Set Day Of Month To":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, Convert.ToInt32(num33), variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, Convert.ToInt32(num33), variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								else
								{
									variableByName16.VarArray[num31] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, Convert.ToInt32(num33), variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								break;
							case "Set Hours To":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, Convert.ToInt32(num33), variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, Convert.ToInt32(num33), variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								else
								{
									variableByName16.VarArray[num31] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, Convert.ToInt32(num33), variableByName16.dtDateTime.Minute, variableByName16.dtDateTime.Second);
								}
								break;
							case "Set Minutes To":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, Convert.ToInt32(num33), variableByName16.dtDateTime.Second);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, Convert.ToInt32(num33), variableByName16.dtDateTime.Second);
								}
								else
								{
									variableByName16.VarArray[num31] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, Convert.ToInt32(num33), variableByName16.dtDateTime.Second);
								}
								break;
							case "Set Seconds To":
								if (num31 == -1)
								{
									variableByName16.dtDateTime = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, Convert.ToInt32(num33));
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, Convert.ToInt32(num33));
								}
								else
								{
									variableByName16.VarArray[num31] = new DateTime(variableByName16.dtDateTime.Year, variableByName16.dtDateTime.Month, variableByName16.dtDateTime.Day, variableByName16.dtDateTime.Hour, variableByName16.dtDateTime.Minute, Convert.ToInt32(num33));
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							switch (roomname2)
							{
							case "Equals":
								if (num31 == -1)
								{
									variableByName16.dNumType = num34;
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = num33.ToString();
								}
								else
								{
									variableByName16.VarArray[num31] = num34;
								}
								break;
							case "Add":
								if (num31 == -1)
								{
									variableByName16.dNumType += num34;
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = (double)variableByName16.VarArray[num31] + num34;
								}
								else
								{
									variableByName16.VarArray[num31] = (double)variableByName16.VarArray[num31] + num34;
								}
								break;
							case "Subtract":
								if (num31 == -1)
								{
									variableByName16.dNumType -= num34;
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = (double)variableByName16.VarArray[num31] - num34;
								}
								else
								{
									variableByName16.VarArray[num31] = (double)variableByName16.VarArray[num31] - num34;
								}
								break;
							case "Multiply":
								if (num31 == -1)
								{
									variableByName16.dNumType *= Convert.ToDouble(num34);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = (double)variableByName16.VarArray[num31] * num34;
								}
								else
								{
									variableByName16.VarArray[num31] = (double)variableByName16.VarArray[num31] * num34;
								}
								break;
							case "Divide":
								if (num31 == -1)
								{
									variableByName16.dNumType /= Convert.ToDouble(num33);
								}
								else if (num35 != -1)
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = (double)variableByName16.VarArray[num31] / num34;
								}
								else
								{
									variableByName16.VarArray[num31] = (double)variableByName16.VarArray[num31] / num34;
								}
								break;
							}
							if (!variableByName16.bEnforceRestrictions)
							{
								break;
							}
							if (num31 == -1)
							{
								if (variableByName16.dNumType < Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null)))
								{
									variableByName16.dNumType = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null));
								}
								if (variableByName16.dNumType > Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null)))
								{
									variableByName16.dNumType = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null));
								}
							}
							else if (num35 != -1)
							{
								if ((double)((ArrayList)variableByName16.VarArray[num31])[num35] < Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null)))
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null));
								}
								if ((double)((ArrayList)variableByName16.VarArray[num31])[num35] > Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null)))
								{
									((ArrayList)variableByName16.VarArray[num31])[num35] = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null));
								}
							}
							else
							{
								if ((double)variableByName16.VarArray[num31] < Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null)))
								{
									variableByName16.VarArray[num31] = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMin, null));
								}
								if ((double)variableByName16.VarArray[num31] > Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null)))
								{
									variableByName16.VarArray[num31] = Convert.ToDouble(bx.PerformTextReplacements(variableByName16.dMax, null));
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
						GameVariable variableByName11 = bx.GetVariableByName(roomname);
						int num19 = b(roomname);
						int num20 = a(roomname);
						if (variableByName11 == null)
						{
							break;
						}
						switch (variableByName11.vartype)
						{
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (num19 == -1)
							{
								break;
							}
							switch (roomname2)
							{
							case "Display Date & Time":
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((ArrayList)variableByName11.VarArray[num19])[num20].ToString() + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((DateTime)variableByName11.VarArray[num19]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								break;
							case "Display Date Only":
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, Convert.ToDateTime(((ArrayList)variableByName11.VarArray[num19])[num20]).ToString("dddd, MMMM, dd yyyy", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((DateTime)variableByName11.VarArray[num19]).ToString("dddd, MMMM, dd yyyy", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								break;
							case "Display Time Only":
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, Convert.ToDateTime(((ArrayList)variableByName11.VarArray[num19])[num20]).ToString("hh:mm:ss tt", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((DateTime)variableByName11.VarArray[num19]).ToString("hh:mm:ss tt", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								break;
							case "Display Weekday Only":
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, Convert.ToDateTime(((ArrayList)variableByName11.VarArray[num19])[num20]).ToString("dddd", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((DateTime)variableByName11.VarArray[num19]).ToString("dddd", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								}
								break;
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							switch (roomname2)
							{
							case "Display Date & Time":
								TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								break;
							case "Display Date Only":
								TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.dtDateTime.ToString("dddd, MMMM, dd yyyy", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								break;
							case "Display Time Only":
								TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.dtDateTime.ToString("hh:mm:ss tt", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								break;
							case "Display Weekday Only":
								TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.dtDateTime.ToString("dddd", Game.myDTFI) + "\r\n", Color.Black, (FontStyle)0);
								break;
							}
							break;
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (num19 != -1)
							{
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((ArrayList)variableByName11.VarArray[num19])[num20].ToString() + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, (double)variableByName11.VarArray[num19] + "\r\n", Color.Black, (FontStyle)0);
								}
								((TextBoxBase)this.m_u).Select(((Control)this.m_u).Text.Length, 0);
								((Control)this.m_u).Focus();
								((TextBoxBase)this.m_u).ScrollToCaret();
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.dNumType + "\r\n", Color.Black, (FontStyle)0);
							((TextBoxBase)this.m_u).Select(((Control)this.m_u).Text.Length, 0);
							((Control)this.m_u).Focus();
							((TextBoxBase)this.m_u).ScrollToCaret();
							break;
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num19 != -1)
							{
								if (num20 != -1)
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, ((ArrayList)variableByName11.VarArray[num19])[num20].ToString() + "\r\n", Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.VarArray[num19].ToString() + "\r\n", Color.Black, (FontStyle)0);
								}
								((TextBoxBase)this.m_u).Select(((Control)this.m_u).Text.Length, 0);
								((Control)this.m_u).Focus();
							}
							break;
						case GameVariable.VarType.VT_STRING:
							TextHandlers.AddTextToRTF(ref this.m_u, ref bx, variableByName11.sString + "\r\n", Color.Black, (FontStyle)0);
							((TextBoxBase)this.m_u).Select(((Control)this.m_u).Text.Length, 0);
							((Control)this.m_u).Focus();
							((TextBoxBase)this.m_u).ScrollToCaret();
							break;
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SETPORT:
					{
						Character character3 = null;
						character3 = bx.GetCharacterByName(roomname);
						if (character3 != null)
						{
							character3.CharPortrait = roomname2;
						}
						break;
					}
					case Command.CommandType.CT_SETROOMPIC:
					{
						Room room8 = null;
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							room8 = bx.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room8 = bx.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room8 = bx.GetRoomByName(ref roomname);
							}
						}
						if (room8 == null)
						{
							break;
						}
						room8.RoomPic = roomname2;
						if (room8 == bx.ThePlayer.CurrentRoom)
						{
							if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
							{
								((TextBoxBase)this.m_u).ReadOnly = false;
								Clipboard.SetDataObject(bx.GetPictureByName(room8.RoomPic));
								((TextBoxBase)this.m_u).Paste();
								((TextBoxBase)this.m_u).AppendText("\r\n");
								((TextBoxBase)this.m_u).ReadOnly = true;
							}
							if (!bx.bHideMainPicDisplay)
							{
								((Control)this.m_t).Tag = bx.GetGamePictureByName(room8.RoomPic);
								PictureBox val6 = this.m_t;
								object pictureByName9 = bx.GetPictureByName(room8.RoomPic);
								((Control)val6).BackgroundImage = (Image)((pictureByName9 is Image) ? pictureByName9 : null);
								PictureBox val7 = this.m_t;
								object pictureByName10 = bx.GetPictureByName(room8.LayeredRoomPic);
								val7.Image = (Image)((pictureByName10 is Image) ? pictureByName10 : null);
							}
						}
						break;
					}
					case Command.CommandType.CT_SETROOMLAYEREDPIC:
					{
						Room room9 = null;
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							room9 = bx.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room9 = bx.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room9 = bx.GetRoomByName(ref roomname);
							}
						}
						if (room9 == null)
						{
							break;
						}
						if (roomname2 == "<None>")
						{
							roomname2 = "";
						}
						room9.LayeredRoomPic = roomname2;
						if (room9 == bx.ThePlayer.CurrentRoom)
						{
							if (bx.bHideMainPicDisplay)
							{
								_ = bx.bUseInlineImages;
							}
							if (!bx.bHideMainPicDisplay)
							{
								((Control)this.m_t).Tag = bx.GetGamePictureByName(room9.RoomPic);
								PictureBox val8 = this.m_t;
								object pictureByName11 = bx.GetPictureByName(room9.RoomPic);
								((Control)val8).BackgroundImage = (Image)((pictureByName11 is Image) ? pictureByName11 : null);
								PictureBox val9 = this.m_t;
								object pictureByName12 = bx.GetPictureByName(room9.LayeredRoomPic);
								val9.Image = (Image)((pictureByName12 is Image) ? pictureByName12 : null);
								PictureBox val10 = a9;
								object pictureByName13 = bx.GetPictureByName(room9.LayeredRoomPic);
								val10.Image = (Image)((pictureByName13 is Image) ? pictureByName13 : null);
							}
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERPORTRAIT:
						bx.ThePlayer.PlayerPortrait = roomname;
						a(roomname, A_1: false);
						break;
					case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
						if (roomname == "<None>")
						{
							roomname = "";
						}
						bx.ThePlayer.PlayerLayeredImage = roomname;
						a(roomname, A_1: true);
						break;
					case Command.CommandType.CT_DISPLAYPICTURE:
						if (bx.bHideMainPicDisplay && bx.bUseInlineImages)
						{
							((TextBoxBase)this.m_u).ReadOnly = false;
							Clipboard.SetDataObject(bx.GetPictureByName(roomname));
							((TextBoxBase)this.m_u).Paste();
							((TextBoxBase)this.m_u).AppendText("\r\n");
							((TextBoxBase)this.m_u).ReadOnly = true;
						}
						if (!bx.bHideMainPicDisplay)
						{
							this.m_t.Image = null;
							object pictureByName8 = bx.GetPictureByName(roomname);
							Image val5 = (Image)((pictureByName8 is Image) ? pictureByName8 : null);
							if (val5 != null)
							{
								((Control)by).Visible = false;
								((Control)this.m_t).Visible = true;
								((Control)this.m_t).Tag = bx.GetGamePictureByName(roomname);
								((Control)this.m_t).BackgroundImage = val5;
							}
							else
							{
								((Control)by).Visible = true;
								((Control)this.m_t).Visible = false;
								by.URL = pictureByName8 as string;
							}
						}
						break;
					case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
					{
						object pictureByName7 = bx.GetPictureByName(roomname);
						if (!(pictureByName7 is Image))
						{
							a(b1);
							b1.URL = pictureByName7 as string;
						}
						break;
					}
					case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
						a(b1);
						b1.Ctlcontrols.stop();
						break;
					case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
					{
						object pictureByName6 = bx.GetPictureByName(roomname);
						if (!(pictureByName6 is Image))
						{
							bz.URL = pictureByName6 as string;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
						if (bx.bHideMainPicDisplay)
						{
							_ = bx.bUseInlineImages;
						}
						if (!bx.bHideMainPicDisplay)
						{
							PictureBox val4 = this.m_t;
							object pictureByName5 = bx.GetPictureByName(roomname);
							val4.Image = (Image)((pictureByName5 is Image) ? pictureByName5 : null);
						}
						break;
					case Command.CommandType.CT_SETOBJECTACTION:
					{
						GameObject gameObject4 = null;
						if (roomname == "00000000-0000-0000-0000-000000000004")
						{
							if (A_1 != null)
							{
								gameObject4 = A_1;
							}
						}
						else
						{
							gameObject4 = bx.GetObjectByName(roomname);
							if (gameObject4 == null)
							{
								gameObject4 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject4 == null)
						{
							break;
						}
						string actionname = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text5 = roomname2;
						string text6 = text5.Substring(text5.LastIndexOf('-') + 1);
						Action actionByName = gameObject4.GetActionByName(actionname);
						if (actionByName != null)
						{
							if (text6 == "Active")
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
					case Command.CommandType.CT_SETCHARACTION:
					{
						Character characterByName2 = bx.GetCharacterByName(roomname);
						if (characterByName2 == null)
						{
							break;
						}
						string actionname2 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text11 = roomname2;
						string text12 = text11.Substring(text11.LastIndexOf('-') + 1);
						Action actionByName2 = characterByName2.GetActionByName(actionname2);
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
					case Command.CommandType.CT_CHAR_SET_GENDER:
					{
						Character characterByName = bx.GetCharacterByName(roomname);
						if (characterByName != null)
						{
							characterByName.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname2);
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_NAME:
					{
						Character characterByName7 = bx.GetCharacterByName(roomname);
						if (characterByName7 != null)
						{
							characterByName7.CharnameOverride = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
					{
						Room room12 = null;
						try
						{
							room12 = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room12 = bx.GetRoomByName(ref roomname);
						}
						if (room12 != null)
						{
							room12.SDesc = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
					{
						GameObject gameObject26 = null;
						try
						{
							new Guid(roomname);
							gameObject26 = bx.GetObjectByName(roomname);
						}
						catch
						{
							gameObject26 = bx.GetObjectByNameOld(roomname);
						}
						if (gameObject26 != null)
						{
							gameObject26.sdesc = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERACTION:
					{
						if (bx.ThePlayer == null)
						{
							break;
						}
						string actionname3 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text45 = roomname2;
						string text46 = text45.Substring(text45.LastIndexOf('-') + 1);
						Action actionByName3 = bx.ThePlayer.GetActionByName(actionname3);
						if (actionByName3 != null)
						{
							if (text46 == "Active")
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
					case Command.CommandType.CT_SETROOMACTION:
					{
						Room room13 = null;
						try
						{
							room13 = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room13 = bx.GetRoomByName(ref roomname);
						}
						if (room13 == null)
						{
							break;
						}
						string actionname4 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text50 = roomname2;
						string text51 = text50.Substring(text50.LastIndexOf('-') + 1);
						Action actionByName4 = room13.GetActionByName(actionname4);
						if (actionByName4 != null)
						{
							if (text51 == "Active")
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
					case Command.CommandType.CT_SETLOCKEDUNLOCKED:
					{
						GameObject gameObject24 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject24 = A_1;
							}
						}
						else
						{
							gameObject24 = bx.GetObjectByName(roomname);
							if (gameObject24 == null)
							{
								gameObject24 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject24 != null)
						{
							if (roomname2 == "Locked")
							{
								gameObject24.bLocked = true;
							}
							else
							{
								gameObject24.bLocked = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETOPENCLOSED:
					{
						GameObject gameObject17 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject17 = A_1;
							}
						}
						else
						{
							gameObject17 = bx.GetObjectByName(roomname);
							if (gameObject17 == null)
							{
								gameObject17 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject17 != null)
						{
							if (roomname2 == "Open")
							{
								gameObject17.bOpen = true;
							}
							else
							{
								gameObject17.bOpen = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETITEMTOWORN:
					{
						GameObject gameObject11 = null;
						if (roomname.Equals("00000000-0000-0000-0000-000000000004"))
						{
							if (A_1 != null)
							{
								gameObject11 = A_1;
							}
						}
						else
						{
							gameObject11 = bx.GetObjectByName(roomname);
							if (gameObject11 == null)
							{
								gameObject11 = bx.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject11 != null)
						{
							if (roomname2 == "Worn")
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
						Character characterByName6 = bx.GetCharacterByName(roomname);
						TextHandlers.AddTextToRTF(ref this.m_u, ref bx, characterByName6.Description + "\r\n", Color.Black, (FontStyle)0);
						bool flag3 = false;
						if (!bx.bTurnOffNotifications)
						{
							foreach (GameObject object9 in bx.ObjectList)
							{
								if (object9.locationtype == GameObject.LocationType.LT_CHARACTER && object9.locationname == roomname && object9.bWorn && object9.bVisible)
								{
									if (!flag3)
									{
										flag3 = true;
										TextHandlers.AddTextToRTF(ref this.m_u, ref bx, characterByName6.ToString() + " is wearing:\r\n", Color.Black, (FontStyle)0);
									}
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, object9.GetDisplayString() + "\r\n", Color.Black, (FontStyle)0);
								}
							}
							flag3 = false;
							foreach (GameObject object10 in bx.ObjectList)
							{
								if (object10.locationtype == GameObject.LocationType.LT_CHARACTER && object10.locationname == roomname && !object10.bWorn && object10.bVisible)
								{
									if (!flag3)
									{
										flag3 = true;
										TextHandlers.AddTextToRTF(ref this.m_u, ref bx, characterByName6.ToString() + " is carrying:\r\n", Color.Black, (FontStyle)0);
									}
									TextHandlers.AddTextToRTF(ref this.m_u, ref bx, object10.GetDisplayString() + "\r\n", Color.Black, (FontStyle)0);
								}
							}
						}
						((TextBoxBase)this.m_u).Select(((Control)this.m_u).Text.Length, 0);
						((Control)this.m_u).Focus();
						((TextBoxBase)this.m_u).ScrollToCaret();
						break;
					}
					case Command.CommandType.CT_MOVECHAR:
					{
						Character characterByName4 = bx.GetCharacterByName(roomname);
						if (characterByName4.CurrentRoom == bx.ThePlayer.CurrentRoom.UniqueID.ToString())
						{
							Action A_7 = characterByName4.GetActionByName("<<On Character Leave>>");
							if (A_7 != null)
							{
								a(ref A_7, null);
							}
						}
						string text16 = string.Empty;
						try
						{
							new Guid(roomname2);
							text16 = roomname2;
						}
						catch
						{
							Room roomByName = bx.GetRoomByName(ref roomname2);
							if (roomByName != null)
							{
								text16 = roomByName.UniqueID.ToString();
								roomname2 = text16;
							}
						}
						if (roomname2 == Room.CurrentRoomGuid.ToString())
						{
							characterByName4.CurrentRoom = bx.ThePlayer.CurrentRoom.UniqueID.ToString();
							Action A_8 = characterByName4.GetActionByName("<<On Character Enter>>");
							if (A_8 != null)
							{
								a(ref A_8, null);
							}
						}
						else if (roomname2 == Room.VoidRoomGuid.ToString())
						{
							bx.GetCharacterByName(roomname).CurrentRoom = Room.VoidRoomGuid.ToString();
						}
						else
						{
							try
							{
								new Guid(roomname2);
								text16 = roomname2;
							}
							catch
							{
								Room roomByName2 = bx.GetRoomByName(ref roomname2);
								if (roomByName2 != null)
								{
									text16 = roomByName2.UniqueID.ToString();
								}
							}
							if (text16 == string.Empty)
							{
								MessageBox.Show("Error in command CT_MoveChar.  Could not locate a room called " + roomname2);
								break;
							}
							bx.GetCharacterByName(roomname).CurrentRoom = text16;
							if (roomname2 == bx.ThePlayer.CurrentRoom.UniqueID.ToString())
							{
								Action A_9 = characterByName4.GetActionByName("<<On Character Enter>>");
								if (A_9 != null)
								{
									a(ref A_9, null);
								}
							}
						}
						h();
						break;
					}
					case Command.CommandType.CT_MOVEPLAYER:
						try
						{
							bx.ThePlayer.CurrentRoom = bx.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							bx.ThePlayer.CurrentRoom = bx.GetRoomByName(ref roomname);
						}
						if (bx.ThePlayer.CurrentRoom != null)
						{
							a(A_0: false, A_1: true);
						}
						break;
					case Command.CommandType.CT_MOVETOCHAR:
						try
						{
							Character characterByName3 = bx.GetCharacterByName(roomname);
							if (characterByName3 != null)
							{
								if (characterByName3.CurrentRoom != Room.VoidRoomGuid.ToString() && characterByName3.CurrentRoom != Room.CurrentRoomGuid.ToString())
								{
									bx.ThePlayer.CurrentRoom = bx.GetRoomByID(new Guid(characterByName3.CurrentRoom));
								}
								if (bx.ThePlayer.CurrentRoom != null)
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
							GameObject objectByName = bx.GetObjectByName(roomname);
							if (objectByName != null)
							{
								if (objectByName.locationtype == GameObject.LocationType.LT_ROOM)
								{
									bx.ThePlayer.CurrentRoom = bx.GetRoomByID(new Guid(objectByName.locationname));
								}
								if (bx.ThePlayer.CurrentRoom != null)
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
							Character characterByName5 = bx.GetCharacterByName(roomname);
							GameObject objectByName2 = bx.GetObjectByName(roomname2);
							if (objectByName2 != null && characterByName5 != null)
							{
								if (objectByName2.locationtype == GameObject.LocationType.LT_ROOM)
								{
									characterByName5.CurrentRoom = objectByName2.locationname;
								}
								if (bx.ThePlayer.CurrentRoom.UniqueID.ToString() == objectByName2.locationname)
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
						bx.GetCharacterByName(roomname).Description = text;
						break;
					case Command.CommandType.CT_SETROOMDESCRIPTION:
					{
						Room room3 = null;
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							room3 = bx.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room3 = bx.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room3 = bx.GetRoomByName(ref roomname);
							}
						}
						if (room3 != null)
						{
							room3.Description = text;
						}
						break;
					}
					case Command.CommandType.CT_JAVA_SET_RAGS:
					{
						text = bx.PerformTextReplacements(text, null);
						object result4 = null;
						MathEval.EvaluateString(ref result4, text);
						a(ref result4);
						break;
					}
					case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
					{
						AdditionalInputFrm additionalInputFrm2 = null;
						Action.ActionInputType actionInputType2 = Action.ActionInputType.None;
						if (roomname.Equals("Text"))
						{
							actionInputType2 = Action.ActionInputType.Text;
						}
						else if (roomname.Equals("Custom"))
						{
							actionInputType2 = Action.ActionInputType.Custom;
						}
						if (((Control)this.m_t).Tag == null && command.EnhInputData.bUseEnhancedGraphics)
						{
							GamePicture gamePicture5 = new GamePicture();
							gamePicture5.enhinputdata = command.EnhInputData;
							((Control)this.m_t).Tag = gamePicture5;
						}
						else if (((Control)this.m_t).Tag is GamePicture gamePicture6)
						{
							gamePicture6.enhinputdata = command.EnhInputData;
						}
						bool flag5 = false;
						if (actionInputType2 == Action.ActionInputType.Custom)
						{
							if (((Control)this.m_t).Tag != null && ((Control)this.m_t).Tag is GamePicture && !bx.bHideMainPicDisplay && command.EnhInputData.bUseEnhancedGraphics)
							{
								flag5 = true;
								GamePicture gamePicture7 = ((Control)this.m_t).Tag as GamePicture;
								if (!(gamePicture7.enhinputdata.NewImage == string.Empty) && !(gamePicture7.enhinputdata.NewImage == "No Change"))
								{
									this.m_t.Image = (Image)bx.GetPictureByName(gamePicture7.enhinputdata.NewImage);
									GamePicture gamePictureByName8 = bx.GetGamePictureByName(gamePicture7.enhinputdata.NewImage);
									if (gamePictureByName8 != null)
									{
										((Control)this.m_t).BackgroundImage = gamePictureByName8.GetTheImage();
										gamePictureByName8.enhinputdata = command.EnhInputData;
										gamePictureByName8.Choices = gamePicture7.Choices;
										((Control)this.m_t).Tag = gamePictureByName8;
									}
								}
								gamePicture7.Choices.Clear();
								if (bx.PerformTextReplacements(roomname3, null) != string.Empty)
								{
									gamePicture7.Choices.Add(bx.PerformTextReplacements(roomname3, null));
								}
								else
								{
									gamePicture7.Choices.Add("Please make a selection:");
								}
								foreach (string customChoice2 in command.CustomChoices)
								{
									gamePicture7.Choices.Add(bx.PerformTextReplacements(customChoice2, null));
								}
								if (gamePicture7.enhinputdata.bAllowCancel || gamePicture7.Choices.Count <= 1)
								{
									gamePicture7.Choices.Add("Cancel");
								}
							}
							else
							{
								ListBox inv2 = new ListBox();
								foreach (string customChoice3 in command.CustomChoices)
								{
									inv2.Items.Add((object)bx.PerformTextReplacements(customChoice3, null));
								}
								additionalInputFrm2 = new AdditionalInputFrm(actionInputType2, ref inv2, ref lbRoomObjects, ref lbCharacters);
							}
						}
						else
						{
							additionalInputFrm2 = new AdditionalInputFrm(actionInputType2, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
						}
						if (additionalInputFrm2 != null)
						{
							((Control)additionalInputFrm2.lblTitle).Text = bx.PerformTextReplacements(roomname3, null);
							((Control)additionalInputFrm2.btnCancel).Enabled = command.EnhInputData.bAllowCancel;
						}
						if (!bx.bHideMainPicDisplay)
						{
							if (!flag5)
							{
								((Control)additionalInputFrm2).Width = ((Control)this.m_t).Width;
								((Control)additionalInputFrm2).Height = ((Control)this.m_t).Height;
								((Form)additionalInputFrm2).Location = ((Control)this.m_t).PointToScreen(((Control)this.m_t).Location);
								bool flag6 = false;
								while (!flag6)
								{
									DialogResult val11 = ((Form)additionalInputFrm2).ShowDialog((IWin32Window)(object)this.m_t);
									string empty3 = string.Empty;
									empty3 = ((actionInputType2 != Action.ActionInputType.Custom) ? ((Control)additionalInputFrm2.txtInput).Text : additionalInputFrm2.dgvItems.SelectedRows[0].Cells[0].Value.ToString());
									if ((int)val11 == 4)
									{
										val11 = ((Form)additionalInputFrm2).ShowDialog((IWin32Window)(object)this.m_t);
									}
									if ((int)val11 == 1)
									{
										try
										{
											Convert.ToDouble(empty3);
											flag6 = true;
										}
										catch
										{
											MessageBox.Show("Sorry, you must enter a valid number.");
											flag6 = false;
										}
									}
									else if ((int)val11 != 1)
									{
										return false;
									}
								}
							}
							else
							{
								bc = null;
								((Control)this.m_ab).Enabled = false;
								((Control)this.m_t).Enabled = true;
								((Control)a9).Enabled = false;
								((Control)this.m_y).Enabled = false;
								((Control)this.m_t).Invalidate();
								while (bc == null)
								{
									Application.DoEvents();
									Thread.Sleep(100);
								}
								(((Control)this.m_t).Tag as GamePicture).Choices.Clear();
								((Control)this.m_t).Invalidate();
								((Control)this.m_ab).Enabled = true;
								((Control)this.m_t).Enabled = true;
								((Control)a9).Enabled = true;
								((Control)this.m_y).Enabled = true;
								if (bc.ToString().ToUpper() == "CANCEL")
								{
									return false;
								}
							}
						}
						else
						{
							((Form)additionalInputFrm2).StartPosition = (FormStartPosition)4;
							bool flag7 = false;
							while (!flag7)
							{
								DialogResult val12 = ((Form)additionalInputFrm2).ShowDialog();
								string text39 = ((Control)additionalInputFrm2.txtInput).Text;
								if ((int)val12 == 4)
								{
									val12 = ((Form)additionalInputFrm2).ShowDialog();
								}
								if ((int)val12 == 1)
								{
									try
									{
										Convert.ToDouble(text39);
										flag7 = true;
									}
									catch
									{
										MessageBox.Show("Sorry, you must enter a valid number.");
										flag7 = false;
									}
								}
								else if ((int)val12 != 1)
								{
									return false;
								}
							}
						}
						GameVariable variableByName10 = bx.GetVariableByName(roomname2);
						int num17 = b(roomname2);
						int num18 = a(roomname2);
						if (variableByName10 == null)
						{
							break;
						}
						switch (actionInputType2)
						{
						case Action.ActionInputType.Custom:
						{
							string empty4 = string.Empty;
							if (flag5)
							{
								if (bc is GameObject)
								{
									empty4 = ((GameObject)bc).name;
								}
								else
								{
									empty4 = ((!(bc is Character)) ? bc.ToString() : ((Character)bc).Charname);
								}
							}
							else
							{
								empty4 = additionalInputFrm2.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
							}
							variableByName10.sString = string.Empty;
							if (empty4 != string.Empty)
							{
								if (num17 == -1)
								{
									variableByName10.dNumType = a(variableByName10, empty4);
								}
								else if (num18 != -1)
								{
									((ArrayList)variableByName10.VarArray[num17])[num18] = string.Empty;
									((ArrayList)variableByName10.VarArray[num17])[num18] = a(variableByName10, empty4).ToString();
								}
								else
								{
									variableByName10.VarArray[num17] = string.Empty;
									variableByName10.VarArray[num17] = a(variableByName10, empty4).ToString();
								}
							}
							break;
						}
						case Action.ActionInputType.Text:
							if (num17 == -1)
							{
								variableByName10.dNumType = a(variableByName10, ((Control)additionalInputFrm2.txtInput).Text);
							}
							else if (num18 != -1)
							{
								((ArrayList)variableByName10.VarArray[num17])[num18] = a(variableByName10, ((Control)additionalInputFrm2.txtInput).Text).ToString();
							}
							else
							{
								variableByName10.VarArray[num17] = a(variableByName10, ((Control)additionalInputFrm2.txtInput).Text).ToString();
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_SETVARIABLEBYINPUT:
					{
						AdditionalInputFrm additionalInputFrm = null;
						Action.ActionInputType actionInputType = Action.ActionInputType.None;
						if (roomname.Equals("Text"))
						{
							actionInputType = Action.ActionInputType.Text;
						}
						else if (roomname.Equals("Characters"))
						{
							actionInputType = Action.ActionInputType.Character;
						}
						else if (roomname.Equals("Characters And Objects"))
						{
							actionInputType = Action.ActionInputType.ObjectOrCharacter;
						}
						else if (roomname.Equals("Objects"))
						{
							actionInputType = Action.ActionInputType.Object;
						}
						else if (roomname.Equals("Custom"))
						{
							actionInputType = Action.ActionInputType.Custom;
						}
						else if (roomname.Equals("Inventory"))
						{
							actionInputType = Action.ActionInputType.Inventory;
						}
						if (((Control)this.m_t).Tag == null && command.EnhInputData.bUseEnhancedGraphics)
						{
							GamePicture gamePicture = new GamePicture();
							gamePicture.enhinputdata = command.EnhInputData;
							((Control)this.m_t).Tag = gamePicture;
						}
						else if (((Control)this.m_t).Tag is GamePicture gamePicture2)
						{
							gamePicture2.enhinputdata = command.EnhInputData;
						}
						bool flag = false;
						if (actionInputType == Action.ActionInputType.Custom)
						{
							if (((Control)this.m_t).Tag != null && ((Control)this.m_t).Tag is GamePicture && !bx.bHideMainPicDisplay && command.EnhInputData.bUseEnhancedGraphics)
							{
								flag = true;
								GamePicture gamePicture3 = ((Control)this.m_t).Tag as GamePicture;
								if (!(gamePicture3.enhinputdata.NewImage == string.Empty) && !(gamePicture3.enhinputdata.NewImage == "No Change"))
								{
									this.m_t.Image = (Image)bx.GetPictureByName(gamePicture3.enhinputdata.NewImage);
									GamePicture gamePictureByName = bx.GetGamePictureByName(gamePicture3.enhinputdata.NewImage);
									if (gamePictureByName != null)
									{
										((Control)this.m_t).BackgroundImage = gamePictureByName.GetTheImage();
										gamePictureByName.enhinputdata = command.EnhInputData;
										gamePictureByName.Choices = gamePicture3.Choices;
										((Control)this.m_t).Tag = gamePictureByName;
									}
								}
								gamePicture3.Choices.Clear();
								if (bx.PerformTextReplacements(roomname3, null) != string.Empty)
								{
									gamePicture3.Choices.Add(bx.PerformTextReplacements(roomname3, null));
								}
								else
								{
									gamePicture3.Choices.Add("Please make a selection:");
								}
								foreach (string customChoice4 in command.CustomChoices)
								{
									gamePicture3.Choices.Add(bx.PerformTextReplacements(customChoice4, null));
								}
								if (gamePicture3.enhinputdata.bAllowCancel || gamePicture3.Choices.Count <= 1)
								{
									gamePicture3.Choices.Add("Cancel");
								}
							}
							else
							{
								ListBox inv = new ListBox();
								foreach (string customChoice5 in command.CustomChoices)
								{
									inv.Items.Add((object)bx.PerformTextReplacements(customChoice5, null));
								}
								additionalInputFrm = new AdditionalInputFrm(actionInputType, ref inv, ref lbRoomObjects, ref lbCharacters);
							}
						}
						else if (command.EnhInputData.bUseEnhancedGraphics && !bx.bHideMainPicDisplay && actionInputType != Action.ActionInputType.Text)
						{
							flag = true;
							GamePicture gamePicture4 = ((Control)this.m_t).Tag as GamePicture;
							if (!(gamePicture4.enhinputdata.NewImage == string.Empty) && !(gamePicture4.enhinputdata.NewImage == "No Change"))
							{
								this.m_t.Image = (Image)bx.GetPictureByName(gamePicture4.enhinputdata.NewImage);
								GamePicture gamePictureByName2 = bx.GetGamePictureByName(gamePicture4.enhinputdata.NewImage);
								if (gamePictureByName2 != null)
								{
									((Control)this.m_t).BackgroundImage = gamePictureByName2.GetTheImage();
									gamePictureByName2.enhinputdata = command.EnhInputData;
									gamePictureByName2.Choices = gamePicture4.Choices;
									((Control)this.m_t).Tag = gamePictureByName2;
								}
							}
							gamePicture4.Choices.Clear();
							if (bx.PerformTextReplacements(roomname3, null) != string.Empty)
							{
								gamePicture4.Choices.Add(bx.PerformTextReplacements(roomname3, null));
							}
							else
							{
								gamePicture4.Choices.Add("Please make a selection");
							}
							a(actionInputType, ref gamePicture4.Choices);
							if (gamePicture4.enhinputdata.bAllowCancel || gamePicture4.Choices.Count <= 1)
							{
								gamePicture4.Choices.Add("Cancel");
							}
						}
						else
						{
							additionalInputFrm = new AdditionalInputFrm(actionInputType, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
						}
						if (additionalInputFrm != null)
						{
							((Control)additionalInputFrm.lblTitle).Text = bx.PerformTextReplacements(roomname3, null);
							((Control)additionalInputFrm.btnCancel).Enabled = false;
						}
						if (!bx.bHideMainPicDisplay)
						{
							if (!flag)
							{
								((Control)additionalInputFrm).Width = ((Control)this.m_t).Width;
								((Control)additionalInputFrm).Height = ((Control)this.m_t).Height;
								((Form)additionalInputFrm).Location = ((Control)this.m_t).PointToScreen(((Control)this.m_t).Location);
								if ((int)((Form)additionalInputFrm).ShowDialog((IWin32Window)(object)this.m_t) != 1)
								{
									return false;
								}
							}
							else
							{
								bc = null;
								((Control)this.m_ab).Enabled = false;
								((Control)this.m_t).Enabled = true;
								((Control)a9).Enabled = false;
								((Control)this.m_y).Enabled = false;
								((Control)this.m_t).Invalidate();
								while (bc == null && !this.m_h)
								{
									Application.DoEvents();
									Thread.Sleep(100);
								}
								(((Control)this.m_t).Tag as GamePicture).Choices.Clear();
								((Control)this.m_t).Invalidate();
								((Control)this.m_ab).Enabled = true;
								((Control)this.m_t).Enabled = true;
								((Control)a9).Enabled = true;
								((Control)this.m_y).Enabled = true;
								if (bc.ToString().ToUpper() == "CANCEL")
								{
									return false;
								}
							}
						}
						else
						{
							((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
							DialogResult val = ((Form)additionalInputFrm).ShowDialog();
							if ((int)val == 4)
							{
								val = ((Form)additionalInputFrm).ShowDialog();
							}
							if ((int)val != 1)
							{
								return false;
							}
						}
						GameVariable variableByName = bx.GetVariableByName(roomname2);
						int num = b(roomname2);
						int num2 = a(roomname2);
						if (variableByName == null)
						{
							break;
						}
						switch (actionInputType)
						{
						case Action.ActionInputType.Object:
						case Action.ActionInputType.Character:
						case Action.ActionInputType.ObjectOrCharacter:
						case Action.ActionInputType.Custom:
						case Action.ActionInputType.Inventory:
						{
							string empty = string.Empty;
							if (flag)
							{
								if (bc is GameObject)
								{
									empty = ((GameObject)bc).name;
								}
								else
								{
									empty = ((!(bc is Character)) ? bc.ToString() : ((Character)bc).Charname);
								}
							}
							else
							{
								empty = additionalInputFrm.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
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
									((ArrayList)variableByName.VarArray[num])[num2] = string.Empty;
									((ArrayList)variableByName.VarArray[num])[num2] = empty;
								}
								else
								{
									variableByName.VarArray[num] = string.Empty;
									variableByName.VarArray[num] = empty;
								}
							}
							break;
						}
						case Action.ActionInputType.Text:
							if (num == -1)
							{
								variableByName.sString = ((Control)additionalInputFrm.txtInput).Text;
							}
							else if (num2 != -1)
							{
								((ArrayList)variableByName.VarArray[num])[num2] = ((Control)additionalInputFrm.txtInput).Text;
							}
							else
							{
								variableByName.VarArray[num] = ((Control)additionalInputFrm.txtInput).Text;
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
					Version version = new Version(Game.CurrentObjectVersionNumber);
					Version version2 = new Version(Game.ObjectVersionNumber);
					if (version < version2)
					{
						MessageBox.Show("Rags can not process the command correctly.  Please try running one of the RAGS legacy versions.  This game was created using Rags version " + Game.CurrentObjectVersionNumber + ".  Rags Legacy versions are available at http://www.ragsgame.com/downloads.aspx");
						MessageBox.Show(command.cmdtype.ToString() + ":" + command.CommandPart2 + ":" + command.CommandPart3 + ":" + command.CommandPart4 + ":" + command.CommandText);
					}
					else if (!this.m_h)
					{
						MessageBox.Show("Rags can not process the command correctly.  If you are the game author, please correct the error in this command:" + command.cmdtype);
					}
				}
			}
		}
		return result;
	}

	private void a(Action.ActionInputType A_0, ref List<object> A_1)
	{
		switch (A_0)
		{
		case Action.ActionInputType.Character:
		{
			for (int l = 0; l < lbCharacters.Items.Count; l++)
			{
				if (lbCharacters.Items[l] is Character item2)
				{
					A_1.Add(item2);
				}
			}
			break;
		}
		case Action.ActionInputType.Object:
		{
			for (int m = 0; m < lbInventory.Items.Count; m++)
			{
				A_1.Add((GameObject)lbInventory.Items[m]);
			}
			for (int n = 0; n < lbRoomObjects.Items.Count; n++)
			{
				A_1.Add((GameObject)lbRoomObjects.Items[n]);
			}
			for (int num = 0; num < lbCharacters.Items.Count; num++)
			{
				if (lbCharacters.Items[num] is GameObject item3)
				{
					A_1.Add(item3);
				}
			}
			break;
		}
		case Action.ActionInputType.Inventory:
		{
			for (int num2 = 0; num2 < lbInventory.Items.Count; num2++)
			{
				A_1.Add((GameObject)lbInventory.Items[num2]);
			}
			break;
		}
		case Action.ActionInputType.ObjectOrCharacter:
		{
			for (int i = 0; i < lbInventory.Items.Count; i++)
			{
				A_1.Add((GameObject)lbInventory.Items[i]);
			}
			for (int j = 0; j < lbRoomObjects.Items.Count; j++)
			{
				A_1.Add((GameObject)lbRoomObjects.Items[j]);
			}
			for (int k = 0; k < lbCharacters.Items.Count; k++)
			{
				Character character = lbCharacters.Items[k] as Character;
				if (lbCharacters.Items[k] is GameObject item)
				{
					A_1.Add(item);
				}
				else if (character != null)
				{
					A_1.Add(character);
				}
			}
			break;
		}
		case Action.ActionInputType.Text:
		case Action.ActionInputType.Custom:
			break;
		}
	}

	private void h()
	{
		if (bx == null)
		{
			return;
		}
		object obj = null;
		if (lbCharacters.SelectedItem != null)
		{
			obj = lbCharacters.SelectedItem;
		}
		lbCharacters.Items.Clear();
		foreach (Character character in bx.CharacterList)
		{
			if (!(character.CurrentRoom == bx.ThePlayer.CurrentRoom.UniqueID.ToString()))
			{
				continue;
			}
			lbCharacters.Items.Add((object)character);
			if (obj == character)
			{
				lbCharacters.SelectedItem = character;
			}
			if (!character.bAllowInventoryInteraction)
			{
				continue;
			}
			foreach (GameObject @object in bx.ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_CHARACTER && @object.locationname == character.Charname && @object.bVisible)
				{
					if (@object.bImportant)
					{
						lbCharacters.Items.Insert(0, (object)@object);
					}
					else
					{
						lbCharacters.Items.Add((object)@object);
					}
					if (obj == @object)
					{
						lbCharacters.SelectedItem = @object;
					}
				}
			}
		}
		for (int num = lbCharacters.Items.Count - 1; num >= 0; num--)
		{
			if (lbCharacters.Items[num] is GameObject { bImportant: not false } gameObject2)
			{
				lbCharacters.Items.Remove((object)gameObject2);
				lbCharacters.Items.Insert(0, (object)gameObject2);
			}
		}
	}

	private bool a(Condition A_0, string A_1, Action.ActionInputType A_2, GameObject A_3, ref Action A_4, object A_5)
	{
		//IL_13f7: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		int num = 0;
		foreach (Check check in A_0.Checks)
		{
			try
			{
				if (num <= 0)
				{
					goto IL_0047;
				}
				if (check.CkType == CheckType.Or)
				{
					if (flag)
					{
						break;
					}
					goto IL_0047;
				}
				if (check.CkType != CheckType.And || flag)
				{
					goto IL_0047;
				}
				goto end_IL_0021;
				IL_0047:
				num++;
				if (bx == null)
				{
					return false;
				}
				string roomname = bx.PerformTextReplacements(check.ConditionStep2, A_5);
				string text = bx.PerformTextReplacements(check.ConditionStep3, A_5);
				string text2 = bx.PerformTextReplacements(check.ConditionStep4, A_5);
				switch (check.CondType)
				{
				case Condition.ConditionType.CT_Item_InGroup:
					flag = a(roomname, text, frmMain.a.a);
					break;
				case Condition.ConditionType.CT_MultiMedia_InGroup:
					flag = a(roomname, text, frmMain.a.b);
					break;
				case Condition.ConditionType.CT_Item_Held_By_Player:
				{
					GameObject A_6 = bx.GetObjectByName(roomname);
					if (A_6 == null)
					{
						A_6 = bx.GetObjectByNameOld(roomname);
					}
					flag = A_6 != null && (A_6.locationtype == GameObject.LocationType.LT_PLAYER || (A_6.locationtype == GameObject.LocationType.LT_IN_OBJECT && a(ref A_6)));
					break;
				}
				case Condition.ConditionType.CT_Player_Moving:
				{
					Exit.Directions directions = (Exit.Directions)Enum.Parse(typeof(Exit.Directions), roomname);
					flag = bf == directions;
					break;
				}
				case Condition.ConditionType.CT_Player_Gender:
					if (roomname.Equals("Male"))
					{
						flag = bx.ThePlayer.PlayerGender == Player.Gender.Male;
					}
					else
					{
						flag = ((!roomname.Equals("Female")) ? (bx.ThePlayer.PlayerGender == Player.Gender.Other) : (bx.ThePlayer.PlayerGender == Player.Gender.Female));
					}
					break;
				case Condition.ConditionType.CT_Character_Gender:
				{
					Character characterByName3 = bx.GetCharacterByName(roomname);
					if (characterByName3 != null)
					{
						if (text.Equals("Male"))
						{
							flag = characterByName3.CharGender == Player.Gender.Male;
						}
						else
						{
							flag = ((!text.Equals("Female")) ? (characterByName3.CharGender == Player.Gender.Other) : (characterByName3.CharGender == Player.Gender.Female));
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Character_In_Room:
				{
					Character characterByName2 = bx.GetCharacterByName(roomname);
					flag = ((!(text == Room.CurrentRoomGuid.ToString())) ? (characterByName2.CurrentRoom == text) : (characterByName2.CurrentRoom == bx.ThePlayer.CurrentRoom.UniqueID.ToString()));
					break;
				}
				case Condition.ConditionType.CT_Character_In_RoomGroup:
				{
					flag = false;
					Character characterByName4 = bx.GetCharacterByName(roomname);
					Room roomByID2 = bx.GetRoomByID(new Guid(characterByName4.CurrentRoom));
					if (roomByID2 != null && roomByID2.Group == text)
					{
						flag = true;
					}
					break;
				}
				case Condition.ConditionType.CT_Item_Held_By_Character:
				{
					GameObject gameObject5 = bx.GetObjectByName(text);
					if (gameObject5 == null)
					{
						gameObject5 = bx.GetObjectByNameOld(text);
					}
					flag = gameObject5 != null && ((gameObject5.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject5.locationname == roomname) ? true : false);
					break;
				}
				case Condition.ConditionType.CT_Item_Not_Held_By_Player:
				{
					GameObject gameObject6 = bx.GetObjectByName(roomname);
					if (gameObject6 == null)
					{
						gameObject6 = bx.GetObjectByNameOld(roomname);
					}
					flag = gameObject6 != null && gameObject6.locationtype != GameObject.LocationType.LT_PLAYER;
					break;
				}
				case Condition.ConditionType.CT_Item_In_Object:
				{
					GameObject gameObject10 = bx.GetObjectByName(roomname);
					if (gameObject10 == null)
					{
						gameObject10 = bx.GetObjectByNameOld(roomname);
					}
					flag = gameObject10 != null && gameObject10.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject10.locationname == text;
					break;
				}
				case Condition.ConditionType.CT_Item_Not_In_Object:
				{
					GameObject gameObject9 = bx.GetObjectByName(roomname);
					if (gameObject9 == null)
					{
						gameObject9 = bx.GetObjectByNameOld(roomname);
					}
					flag = gameObject9 == null || gameObject9.locationtype != GameObject.LocationType.LT_IN_OBJECT || !(gameObject9.locationname == text);
					break;
				}
				case Condition.ConditionType.CT_Item_In_Room:
					if (text == Room.CurrentRoomGuid.ToString())
					{
						GameObject gameObject7 = bx.GetObjectByName(roomname);
						if (gameObject7 == null)
						{
							gameObject7 = bx.GetObjectByNameOld(roomname);
						}
						flag = gameObject7 != null && gameObject7.locationtype == GameObject.LocationType.LT_ROOM && gameObject7.locationname == bx.ThePlayer.CurrentRoom.UniqueID.ToString();
					}
					else
					{
						GameObject gameObject8 = bx.GetObjectByName(roomname);
						if (gameObject8 == null)
						{
							gameObject8 = bx.GetObjectByNameOld(roomname);
						}
						flag = gameObject8 != null && gameObject8.locationtype == GameObject.LocationType.LT_ROOM && gameObject8.locationname == text;
					}
					break;
				case Condition.ConditionType.CT_Item_In_RoomGroup:
				{
					flag = false;
					GameObject objectByName = bx.GetObjectByName(roomname);
					if (objectByName != null && objectByName.locationtype == GameObject.LocationType.LT_ROOM)
					{
						Room roomByID = bx.GetRoomByID(new Guid(objectByName.locationname));
						if (roomByID != null && roomByID.Group == text)
						{
							flag = true;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Player_In_Room:
					flag = bx.ThePlayer.CurrentRoom.UniqueID.ToString() == roomname;
					break;
				case Condition.ConditionType.CT_Player_In_RoomGroup:
					flag = bx.ThePlayer.CurrentRoom.Group == roomname;
					break;
				case Condition.ConditionType.CT_Player_In_Same_Room_As:
					flag = bx.ThePlayer.CurrentRoom.UniqueID.ToString() == bx.GetCharacterByName(roomname).CurrentRoom;
					break;
				case Condition.ConditionType.CT_Loop_While:
					while (a(roomname, text, text2) && !a(ref A_0.PassCommands, A_3, A_1, ref A_4, A_5) && !this.m_h)
					{
					}
					break;
				case Condition.ConditionType.CT_Loop_Rooms:
					foreach (Room room3 in bx.RoomList)
					{
						if (a(ref A_0.PassCommands, A_3, A_1, ref A_4, room3) || this.m_h)
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
						room = bx.GetRoomByID(new Guid(roomname));
					}
					catch
					{
						room = bx.GetRoomByName(ref roomname);
					}
					if (room == null)
					{
						break;
					}
					foreach (Exit exit in room.Exits)
					{
						if (a(ref A_0.PassCommands, A_3, A_1, ref A_4, exit) || this.m_h)
						{
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Loop_Characters:
					foreach (Character character2 in bx.CharacterList)
					{
						if (a(ref A_0.PassCommands, A_3, A_1, ref A_4, character2) || this.m_h)
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Group:
					foreach (GameObject @object in bx.ObjectList)
					{
						if (@object.GroupName == roomname && (a(ref A_0.PassCommands, A_3, A_1, ref A_4, @object) || this.m_h))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
					foreach (GameObject object2 in bx.ObjectList)
					{
						if (object2.locationtype == GameObject.LocationType.LT_CHARACTER && object2.locationname == roomname && (a(ref A_0.PassCommands, A_3, A_1, ref A_4, object2) || this.m_h))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Container:
					foreach (GameObject object3 in bx.ObjectList)
					{
						if (object3.locationtype == GameObject.LocationType.LT_IN_OBJECT && object3.locationname == roomname && (a(ref A_0.PassCommands, A_3, A_1, ref A_4, object3) || this.m_h))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Inventory:
					foreach (GameObject object4 in bx.ObjectList)
					{
						if (object4.locationtype == GameObject.LocationType.LT_PLAYER && (a(ref A_0.PassCommands, A_3, A_1, ref A_4, object4) || this.m_h))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Item_Room:
					foreach (GameObject object5 in bx.ObjectList)
					{
						if (object5.locationtype == GameObject.LocationType.LT_ROOM && object5.locationname == roomname && (a(ref A_0.PassCommands, A_3, A_1, ref A_4, object5) || this.m_h))
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Loop_Items:
					foreach (GameObject object6 in bx.ObjectList)
					{
						if (a(ref A_0.PassCommands, A_3, A_1, ref A_4, object6) || this.m_h)
						{
							break;
						}
					}
					break;
				case Condition.ConditionType.CT_Room_CustomPropertyCheck:
				{
					string[] array5 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array5.Length != 2)
					{
						break;
					}
					string roomname2 = array5[0];
					string text10 = array5[1];
					Room room2 = null;
					room2 = ((!(roomname2 == "<CurrentRoom>")) ? bx.GetRoomByName(ref roomname2) : bx.ThePlayer.CurrentRoom);
					if (room2 == null)
					{
						break;
					}
					foreach (CustomProperty customProperty6 in room2.CustomProperties)
					{
						if (customProperty6.Name == text10)
						{
							flag = b(customProperty6.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Character_CustomPropertyCheck:
				{
					string[] array4 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array4.Length != 2)
					{
						break;
					}
					string charname = array4[0];
					string text9 = array4[1];
					Character character = null;
					character = bx.GetCharacterByName(charname);
					if (character == null)
					{
						break;
					}
					foreach (CustomProperty customProperty7 in character.CustomProperties)
					{
						if (customProperty7.Name == text9)
						{
							flag = b(customProperty7.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
				{
					string[] array = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array.Length != 2)
					{
						break;
					}
					string timername = array[0];
					string text3 = array[1];
					Timer timer = null;
					timer = bx.GetTimerByName(timername);
					if (timer == null)
					{
						break;
					}
					foreach (CustomProperty customProperty8 in timer.CustomProperties)
					{
						if (customProperty8.Name == text3)
						{
							flag = b(customProperty8.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
				{
					string[] array3 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array3.Length != 2)
					{
						break;
					}
					string varname = array3[0];
					string text8 = array3[1];
					GameVariable gameVariable = null;
					gameVariable = bx.GetVariableByName(varname);
					if (gameVariable == null)
					{
						break;
					}
					foreach (CustomProperty customProperty9 in gameVariable.CustomProperties)
					{
						if (customProperty9.Name == text8)
						{
							flag = b(customProperty9.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Item_CustomPropertyCheck:
				{
					string[] array2 = roomname.Split(new string[1] { ":" }, StringSplitOptions.None);
					if (array2.Length != 2)
					{
						break;
					}
					string text6 = array2[0];
					string text7 = array2[1];
					GameObject gameObject3 = null;
					if (text6 == "<Self>")
					{
						if (A_3 != null)
						{
							gameObject3 = A_3;
						}
					}
					else
					{
						gameObject3 = bx.GetObjectByNameOld(text6);
					}
					if (gameObject3 == null)
					{
						break;
					}
					foreach (CustomProperty customProperty10 in gameObject3.CustomProperties)
					{
						if (customProperty10.Name == text7)
						{
							flag = b(customProperty10.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Player_CustomPropertyCheck:
				{
					string text5 = roomname;
					foreach (CustomProperty customProperty11 in bx.ThePlayer.CustomProperties)
					{
						if (customProperty11.Name == text5)
						{
							flag = b(customProperty11.Value, text, text2);
							break;
						}
					}
					break;
				}
				case Condition.ConditionType.CT_Variable_Comparison:
					flag = a(roomname, text, text2);
					break;
				case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
				{
					GameVariable variableByName = bx.GetVariableByName(roomname);
					GameVariable variableByName2 = bx.GetVariableByName(text2);
					int num2 = b(roomname);
					int num3 = a(roomname);
					int num4 = b(text2);
					int num5 = a(text2);
					string text4 = string.Empty;
					switch (variableByName2.vartype)
					{
					case GameVariable.VarType.VT_NUMBER:
					case GameVariable.VarType.VT_NUMBERARRAY:
						if (num4 != -1)
						{
							text4 = ((num5 == -1) ? variableByName2.VarArray[num4].ToString() : ((ArrayList)variableByName2.VarArray[num4])[num5].ToString());
						}
						else
						{
							text4 = variableByName2.dNumType.ToString();
						}
						break;
					case GameVariable.VarType.VT_STRING:
					case GameVariable.VarType.VT_STRINGARRAY:
						if (num4 != -1)
						{
							text4 = ((num5 == -1) ? variableByName2.VarArray[num4].ToString() : ((ArrayList)variableByName2.VarArray[num4])[num5].ToString());
						}
						else
						{
							text4 = variableByName2.sString;
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
								variableByName.dNumType = Convert.ToDouble(((ArrayList)variableByName.VarArray[num2])[num3]);
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
							num7 = Convert.ToDouble(text4);
						}
						catch
						{
							num7 = 0.0;
						}
						num6 = variableByName.dNumType;
						switch (text)
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
							strB = ((num3 == -1) ? TextHandlers.TextOnly(variableByName.VarArray[num2].ToString()) : TextHandlers.TextOnly(((ArrayList)variableByName.VarArray[num2])[num3].ToString()));
						}
						if (text == "Equals")
						{
							flag = string.Compare(text4, strB, ignoreCase: true) == 0;
						}
						else if (text == "Not Equals")
						{
							flag = string.Compare(text4, strB, ignoreCase: true) != 0;
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
					GameObject gameObject4 = bx.GetObjectByName(roomname);
					if (gameObject4 == null)
					{
						gameObject4 = bx.GetObjectByNameOld(roomname);
					}
					if (gameObject4 != null)
					{
						if (text == "Open")
						{
							flag = gameObject4.bOpen;
						}
						if (text == "Closed")
						{
							flag = !gameObject4.bOpen;
						}
						if (text == "Locked")
						{
							flag = gameObject4.bLocked;
						}
						if (text == "Unlocked")
						{
							flag = !gameObject4.bLocked;
						}
						if (text == "Worn")
						{
							flag = gameObject4.bWorn;
						}
						if (text == "Removed")
						{
							flag = !gameObject4.bWorn;
						}
						if (text == "Read")
						{
							flag = gameObject4.bRead;
						}
						if (text == "Unread")
						{
							flag = !gameObject4.bRead;
						}
						if (text == "Visible")
						{
							flag = gameObject4.bVisible;
						}
						if (text == "Invisible")
						{
							flag = !gameObject4.bVisible;
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
					if (A_2 == Action.ActionInputType.Text)
					{
						flag = string.Compare(text2, A_1.ToString(), ignoreCase: true) == 0;
						break;
					}
					if (string.Compare(roomname, A_1, ignoreCase: true) == 0)
					{
						flag = true;
						break;
					}
					GameObject objectByNameOld = bx.GetObjectByNameOld(A_1);
					Character characterByName = bx.GetCharacterByName(roomname);
					if (objectByNameOld != null)
					{
						flag = string.Compare(roomname, objectByNameOld.UniqueIdentifier.ToString(), ignoreCase: true) == 0;
						break;
					}
					if (characterByName != null)
					{
						flag = string.Compare(A_1, characterByName.ToString(), ignoreCase: true) == 0;
						break;
					}
					objectByNameOld = bx.GetObjectByName(A_1);
					flag = ((objectByNameOld != null && string.Compare(roomname, objectByNameOld.name, ignoreCase: true) == 0) ? true : false);
					break;
				}
				}
				end_IL_0021:;
			}
			catch (Exception)
			{
				MessageBox.Show("Rags can not process the condition check correctly.  If you are the game author, please correct the error in this conditon:" + A_0.conditionname + " check:" + check.CondType.ToString() + " - " + check.ConditionStep2 + " - " + check.ConditionStep3 + " - " + check.ConditionStep4);
			}
		}
		if (this.m_i != null)
		{
			string text11 = " Passed";
			if (!flag)
			{
				text11 = " Failed";
			}
			this.m_i.AddExecutionData("CONDITION: " + A_0.conditionname + text11, bBold: false);
		}
		return flag;
	}

	private bool a(string A_0, string A_1, a A_2)
	{
		string text = "Media";
		string text2 = "MediaGroups";
		if (A_2 == frmMain.a.a)
		{
			text = "Items";
			text2 = "ItemGroups";
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
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
		_ = string.Empty;
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("Select Name from " + text2 + " where\r\n                        parent=@parent", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@parent", A_1);
		sqlCeDataReader = sqlCeCommand2.ExecuteReader();
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

	private void a(ref List<string> A_0, string A_1, a A_2)
	{
		string text = "Media";
		string text2 = "MediaGroups";
		if (A_2 == frmMain.a.a)
		{
			text = "Items";
			text2 = "ItemGroups";
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
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
		_ = string.Empty;
		sqlCeCommand = new SqlCeCommand("Select Name from " + text2 + " where\r\n                        parent=@parent", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@parent", A_1);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			a(ref A_0, sqlCeDataReader["Name"].ToString(), A_2);
		}
	}

	private bool b(string A_0, string A_1, string A_2)
	{
		bool result = true;
		string text = bx.PerformTextReplacements(A_2, null);
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

	private bool a(string A_0, string A_1, string A_2)
	{
		bool result = true;
		GameVariable variableByName = bx.GetVariableByName(A_0);
		if (variableByName != null)
		{
			int num = b(A_0);
			int num2 = a(A_0);
			string text = bx.PerformTextReplacements(A_2, null);
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (num != -1)
				{
					if (num2 != -1)
					{
						variableByName.dtDateTime = (DateTime)((ArrayList)variableByName.VarArray[num])[num2];
					}
					else
					{
						variableByName.dtDateTime = (DateTime)variableByName.VarArray[num];
					}
				}
				switch (A_1)
				{
				case "Equals":
					result = Convert.ToDateTime(text, Game.myDTFI) == variableByName.dtDateTime;
					break;
				case "Not Equals":
					result = Convert.ToDateTime(text, Game.myDTFI) != variableByName.dtDateTime;
					break;
				case "Greater Than":
					result = variableByName.dtDateTime > Convert.ToDateTime(text, Game.myDTFI);
					break;
				case "Greater Than or Equals":
					result = variableByName.dtDateTime >= Convert.ToDateTime(text, Game.myDTFI);
					break;
				case "Less Than":
					result = variableByName.dtDateTime < Convert.ToDateTime(text, Game.myDTFI);
					break;
				case "Less Than or Equals":
					result = variableByName.dtDateTime < Convert.ToDateTime(text, Game.myDTFI);
					break;
				case "DayOfWeek Is":
					result = string.Compare(text, variableByName.dtDateTime.ToString("dddd", Game.myDTFI), ignoreCase: true) == 0;
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
						variableByName.dNumType = Convert.ToDouble(((ArrayList)variableByName.VarArray[num])[num2]);
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
						variableByName.sString = ((ArrayList)variableByName.VarArray[num])[num2].ToString();
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

	private bool a(ref Action A_0, GameObject A_1)
	{
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Invalid comparison between Unknown and I4
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Invalid comparison between Unknown and I4
		this.m_n.Enabled = false;
		try
		{
			if (bx == null)
			{
				return false;
			}
			if (this.m_i != null)
			{
				this.m_i.AddExecutionData("ACTION: " + A_0.name, bBold: true);
			}
			string text = "";
			bx.AdditionalData = "";
			AdditionalInputFrm additionalInputFrm = null;
			bool flag = false;
			if (((Control)this.m_t).Tag == null)
			{
				GamePicture gamePicture = new GamePicture();
				gamePicture.enhinputdata = A_0.EnhInputData;
				((Control)this.m_t).Tag = gamePicture;
			}
			else if (((Control)this.m_t).Tag is GamePicture gamePicture2)
			{
				gamePicture2.enhinputdata = A_0.EnhInputData;
			}
			if (A_0.InputType != Action.ActionInputType.None)
			{
				if (A_0.InputType == Action.ActionInputType.Custom)
				{
					if (((Control)this.m_t).Tag != null && ((Control)this.m_t).Tag is GamePicture && !bx.bHideMainPicDisplay && A_0.EnhInputData.bUseEnhancedGraphics)
					{
						flag = true;
						GamePicture gamePicture3 = ((Control)this.m_t).Tag as GamePicture;
						if (!(A_0.EnhInputData.NewImage == string.Empty) && !(A_0.EnhInputData.NewImage == "No Change"))
						{
							GamePicture gamePictureByName = bx.GetGamePictureByName(A_0.EnhInputData.NewImage);
							if (gamePictureByName != null)
							{
								((Control)this.m_t).BackgroundImage = gamePictureByName.GetTheImage();
								gamePictureByName.enhinputdata = A_0.EnhInputData;
								gamePictureByName.Choices = gamePicture3.Choices;
								((Control)this.m_t).Tag = gamePictureByName;
							}
						}
						gamePicture3.Choices.Clear();
						if (bx.PerformTextReplacements(A_0.CustomChoiceTitle, null) != string.Empty)
						{
							gamePicture3.Choices.Add(bx.PerformTextReplacements(A_0.CustomChoiceTitle, null));
						}
						else
						{
							gamePicture3.Choices.Add("Please make a selection:");
						}
						foreach (string customChoice in A_0.CustomChoices)
						{
							gamePicture3.Choices.Add(bx.PerformTextReplacements(customChoice, null));
						}
						if (gamePicture3.enhinputdata.bAllowCancel || gamePicture3.Choices.Count <= 1)
						{
							gamePicture3.Choices.Add("Cancel");
						}
					}
					else
					{
						ListBox inv = new ListBox();
						foreach (string customChoice2 in A_0.CustomChoices)
						{
							inv.Items.Add((object)bx.PerformTextReplacements(customChoice2, null));
						}
						additionalInputFrm = new AdditionalInputFrm(A_0.InputType, ref inv, ref lbRoomObjects, ref lbCharacters);
						((Control)additionalInputFrm.lblTitle).Text = bx.PerformTextReplacements(A_0.CustomChoiceTitle, null);
					}
				}
				else if (A_0.EnhInputData.bUseEnhancedGraphics && !bx.bHideMainPicDisplay && A_0.InputType != Action.ActionInputType.Text)
				{
					flag = true;
					GamePicture gamePicture4 = ((Control)this.m_t).Tag as GamePicture;
					if (!(A_0.EnhInputData.NewImage == string.Empty) && !(A_0.EnhInputData.NewImage == "No Change"))
					{
						GamePicture gamePictureByName2 = bx.GetGamePictureByName(A_0.EnhInputData.NewImage);
						if (gamePictureByName2 != null)
						{
							((Control)this.m_t).BackgroundImage = gamePictureByName2.GetTheImage();
							gamePictureByName2.enhinputdata = A_0.EnhInputData;
							gamePictureByName2.Choices = gamePicture4.Choices;
							((Control)this.m_t).Tag = gamePictureByName2;
						}
					}
					gamePicture4.Choices.Clear();
					if (A_0.CustomChoiceTitle != string.Empty)
					{
						gamePicture4.Choices.Add(bx.PerformTextReplacements(A_0.CustomChoiceTitle, null));
					}
					else
					{
						gamePicture4.Choices.Add("Please make a selection:");
					}
					a(A_0.InputType, ref gamePicture4.Choices);
					if (gamePicture4.enhinputdata.bAllowCancel || gamePicture4.Choices.Count <= 1)
					{
						gamePicture4.Choices.Add("Cancel");
					}
				}
				else
				{
					additionalInputFrm = new AdditionalInputFrm(A_0.InputType, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
					if (A_0.CustomChoiceTitle != string.Empty)
					{
						((Control)additionalInputFrm.lblTitle).Text = bx.PerformTextReplacements(A_0.CustomChoiceTitle, null);
					}
				}
				if (!bx.bHideMainPicDisplay)
				{
					if (!flag)
					{
						((Control)additionalInputFrm).Width = ((Control)this.m_t).Width;
						((Control)additionalInputFrm).Height = ((Control)this.m_t).Height;
						((Form)additionalInputFrm).Location = ((Control)this.m_t).PointToScreen(((Control)this.m_t).Location);
						if ((int)((Form)additionalInputFrm).ShowDialog((IWin32Window)(object)this.m_t) != 1)
						{
							return false;
						}
					}
					else
					{
						bc = null;
						((Control)this.m_ab).Enabled = false;
						((Control)this.m_t).Enabled = true;
						((Control)a9).Enabled = false;
						((Control)this.m_y).Enabled = false;
						((Control)this.m_t).Invalidate();
						while (bc == null && !this.m_h)
						{
							Application.DoEvents();
							Thread.Sleep(100);
						}
						(((Control)this.m_t).Tag as GamePicture).Choices.Clear();
						((Control)this.m_t).Invalidate();
						((Control)this.m_ab).Enabled = true;
						((Control)this.m_t).Enabled = true;
						((Control)a9).Enabled = true;
						((Control)this.m_y).Enabled = true;
						if (bc == null)
						{
							return false;
						}
						if (bc.ToString().ToUpper() == "CANCEL")
						{
							return false;
						}
					}
				}
				else
				{
					((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
					if ((int)((Form)additionalInputFrm).ShowDialog() != 1)
					{
						return false;
					}
				}
				text = string.Empty;
				switch (A_0.InputType)
				{
				case Action.ActionInputType.Object:
				case Action.ActionInputType.Character:
				case Action.ActionInputType.ObjectOrCharacter:
				case Action.ActionInputType.Custom:
				case Action.ActionInputType.Inventory:
					if (!flag)
					{
						if (((BaseCollection)additionalInputFrm.dgvItems.SelectedRows).Count > 0)
						{
							GameObject gameObject = ((DataGridViewBand)additionalInputFrm.dgvItems.SelectedRows[0]).Tag as GameObject;
							Character character = ((DataGridViewBand)additionalInputFrm.dgvItems.SelectedRows[0]).Tag as Character;
							if (gameObject == null)
							{
								text = ((character == null) ? additionalInputFrm.dgvItems.SelectedRows[0].Cells[0].Value.ToString() : character.Charname);
							}
							else
							{
								text = gameObject.name;
							}
						}
					}
					else
					{
						GameObject gameObject2 = bc as GameObject;
						Character character2 = bc as Character;
						if (gameObject2 == null)
						{
							text = ((character2 == null) ? bc.ToString() : character2.Charname);
						}
						else
						{
							text = gameObject2.name;
						}
					}
					break;
				case Action.ActionInputType.Text:
					text = ((Control)additionalInputFrm.txtInput).Text;
					break;
				}
				bx.AdditionalData = text;
				GameObject objectByName = bx.GetObjectByName(text);
				string empty = string.Empty;
				TextHandlers.AddTextToRTF(text: ((objectByName == null) ? text : objectByName.name) + "\r\n", rtcontrol: ref this.m_u, TheGame: ref bx, clr: Color.Black, fontst: (FontStyle)1);
			}
			bool flag2 = true;
			if (A_0.bConditionFailOnFirst)
			{
				for (int i = 0; i < A_0.Conditions.Count; i++)
				{
					Condition condition = (Condition)A_0.Conditions[i];
					if (a(condition, text, A_0.InputType, A_1, ref A_0, null))
					{
						if (condition.Checks.Count != 1 || (((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_While && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Rooms && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Characters && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Items && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Exits && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Char_Inventory && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Container && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Inventory && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Room && ((Check)condition.Checks[0]).CondType != Condition.ConditionType.CT_Loop_Item_Group))
						{
							a(ref condition.PassCommands, A_1, text, ref A_0, null);
						}
						continue;
					}
					flag2 = false;
					a(ref condition.FailCommands, A_1, text, ref A_0, null);
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
				for (int j = 0; j < A_0.Conditions.Count; j++)
				{
					Condition condition2 = (Condition)A_0.Conditions[j];
					bool flag3 = a(condition2, text, A_0.InputType, A_1, ref A_0, null);
					if (flag3)
					{
						flag2 = flag3;
						a(ref condition2.PassCommands, A_1, text, ref A_0, null);
					}
					else
					{
						a(ref condition2.FailCommands, A_1, text, ref A_0, null);
					}
				}
			}
			if (flag2)
			{
				a(ref A_0.PassCommands, A_1, text, ref A_0, null);
			}
			else
			{
				a(ref A_0.FailCommands, A_1, text, ref A_0, null);
			}
		}
		finally
		{
			try
			{
				this.m_n.Enabled = true;
			}
			catch
			{
			}
		}
		return true;
	}

	private void l(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 2097152)
		{
			int num = lbRoomObjects.IndexFromPoint(A_1.X, A_1.Y);
			if (num != -1)
			{
				((ListControl)lbRoomObjects).SelectedIndex = num;
				((ToolStrip)this.m_q).Items.Clear();
				GameObject gameObject = lbRoomObjects.Items[num] as GameObject;
				a(gameObject.Actions, "None", null);
				ca = frmMain.b.c;
				((ToolStripDropDown)this.m_q).Show((Control)(object)lbRoomObjects, A_1.X, A_1.Y);
			}
		}
	}

	private void a(ArrayList A_0, string A_1, ToolStripMenuItem A_2)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		for (int i = 0; i < A_0.Count; i++)
		{
			Action action = (Action)A_0[i];
			if (action.bActive && (action.name.Length <= 2 || !(action.name.Substring(0, 2) == "<<")) && action.actionparent == A_1)
			{
				string text = action.name;
				if (action.overridename != string.Empty)
				{
					text = bx.PerformTextReplacements(action.overridename, null);
				}
				ToolStripMenuItem val = new ToolStripMenuItem(text);
				((ToolStripItem)val).Tag = action;
				((ToolStripItem)val).Click += ac;
				if (A_2 == null)
				{
					((ToolStrip)this.m_q).Items.Add((ToolStripItem)(object)val);
				}
				else
				{
					((ToolStripDropDownItem)A_2).DropDownItems.Add((ToolStripItem)(object)val);
				}
				a(A_0, action.name, val);
			}
		}
	}

	private void k(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 2097152)
		{
			int num = lbInventory.IndexFromPoint(A_1.X, A_1.Y);
			if (num != -1)
			{
				((ListControl)lbInventory).SelectedIndex = num;
				((ToolStrip)this.m_q).Items.Clear();
				GameObject gameObject = lbInventory.Items[num] as GameObject;
				a(gameObject.Actions, "None", null);
				ca = frmMain.b.e;
				((ToolStripDropDown)this.m_q).Show((Control)(object)lbInventory, A_1.X, A_1.Y);
			}
		}
	}

	private void j(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button != 2097152)
		{
			return;
		}
		int num = lbCharacters.IndexFromPoint(A_1.X, A_1.Y);
		if (num != -1)
		{
			((ListControl)lbCharacters).SelectedIndex = num;
			((ToolStrip)this.m_q).Items.Clear();
			Character character = lbCharacters.SelectedItem as Character;
			GameObject gameObject = lbCharacters.SelectedItem as GameObject;
			ArrayList arrayList = null;
			if (character != null)
			{
				arrayList = character.Actions;
			}
			else if (gameObject != null)
			{
				arrayList = gameObject.Actions;
			}
			if (arrayList != null)
			{
				a(arrayList, "None", null);
				ca = frmMain.b.d;
				((ToolStripDropDown)this.m_q).Show((Control)(object)lbCharacters, A_1.X, A_1.Y);
			}
		}
	}

	private void z(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		Character obj = lbCharacters.SelectedItem as Character;
		GameObject gameObject = lbCharacters.SelectedItem as GameObject;
		Action A_2 = null;
		if (obj != null)
		{
			A_2 = ((ToolStripItem)val).Tag as Action;
		}
		else if (gameObject != null)
		{
			A_2 = ((ToolStripItem)val).Tag as Action;
		}
		if (A_2 == null)
		{
			return;
		}
		p();
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, lbCharacters.SelectedItem.ToString() + " - " + ((ToolStripItem)val).Text + "\r\n", Color.Black, (FontStyle)1);
		if (a(ref A_2, null))
		{
			if (!frmMain.m_g)
			{
				n();
				r();
			}
			else
			{
				frmMain.m_g = false;
			}
			o();
			m();
			l();
			h();
		}
	}

	private bool a(Point A_0, Rectangle A_1)
	{
		bool result = false;
		if (A_0.X > A_1.Left && A_0.X < A_1.Right && A_0.Y > A_1.Top && A_0.Y < A_1.Bottom)
		{
			result = true;
		}
		return result;
	}

	private void g()
	{
		foreach (GameObject @object in bx.ObjectList)
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
				if (bx.GetRoomByName(ref @object.locationname) != null)
				{
					@object.locationname = bx.GetRoomByName(ref @object.locationname).UniqueID.ToString();
				}
			}
		}
		foreach (Character character in bx.CharacterList)
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
				else if (bx.GetRoomByName(ref character.CurrentRoom) != null)
				{
					character.CurrentRoom = bx.GetRoomByName(ref character.CurrentRoom).UniqueID.ToString();
				}
			}
		}
	}

	private void y(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)ar).ShowDialog() != 2)
		{
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = ap;
			saveData.CharacterList = bx.CharacterList;
			saveData.ObjectList = bx.ObjectList;
			saveData.RoomList = bx.RoomList;
			saveData.ThePlayer = bx.ThePlayer;
			saveData.VariableList = bx.VariableList;
			saveData.TimerList = bx.TimerList;
			saveData.StatusBarList = bx.StatusBarItems;
			string fileName = ((FileDialog)ar).FileName;
			if (File.Exists(fileName))
			{
				File.Copy(fileName, fileName + ".bak", overwrite: true);
				File.Delete(fileName);
			}
			string tempFileName = Path.GetTempFileName();
			StreamWriter streamWriter = new StreamWriter(tempFileName);
			new BinaryFormatter().Serialize(streamWriter.BaseStream, saveData);
			streamWriter.Close();
			bn = File.ReadAllText(tempFileName);
			EncDec.Encrypt(tempFileName, fileName, this.m_b);
			File.Delete(tempFileName);
		}
	}

	private void f()
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
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
			saveData.originalfilename = ap;
			saveData.CharacterList = bx.CharacterList;
			saveData.ObjectList = bx.ObjectList;
			saveData.RoomList = bx.RoomList;
			saveData.ThePlayer = bx.ThePlayer;
			saveData.VariableList = bx.VariableList;
			saveData.TimerList = bx.TimerList;
			saveData.StatusBarList = bx.StatusBarItems;
			if (File.Exists(text2))
			{
				File.Copy(text2, text2 + ".bak", overwrite: true);
				File.Delete(text2);
			}
			string tempFileName = Path.GetTempFileName();
			StreamWriter streamWriter = new StreamWriter(tempFileName);
			new BinaryFormatter().Serialize(streamWriter.BaseStream, saveData);
			streamWriter.Close();
			bn = File.ReadAllText(tempFileName);
			EncDec.Encrypt(tempFileName, text2, this.m_b);
			File.Delete(tempFileName);
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Quicksave...\r\n", Color.Black, (FontStyle)1);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error saving game." + ex.Message);
		}
	}

	private void x(object A_0, EventArgs A_1)
	{
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Invalid comparison between Unknown and I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Invalid comparison between Unknown and I4
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected Obj, but got Unknown
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected Obj, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Invalid comparison between Unknown and I4
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Invalid comparison between Unknown and I4
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Invalid comparison between Unknown and I4
		bool flag = true;
		if (bx != null)
		{
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = ap;
			saveData.CharacterList = bx.CharacterList;
			saveData.ObjectList = bx.ObjectList;
			saveData.RoomList = bx.RoomList;
			saveData.ThePlayer = bx.ThePlayer;
			saveData.VariableList = bx.VariableList;
			saveData.TimerList = bx.TimerList;
			saveData.StatusBarList = bx.StatusBarItems;
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, saveData);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			if (string.Compare(strB: streamReader.ReadToEnd(), strA: bn) == 0)
			{
				flag = false;
			}
			streamReader.Close();
			streamReader.Dispose();
			memoryStream.Close();
			memoryStream.Dispose();
		}
		else
		{
			flag = false;
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
		{
			flag = false;
		}
		if (flag)
		{
			DialogResult val = MessageBox.Show("Would you like to save your current game?", "Save", (MessageBoxButtons)3);
			if ((int)val == 6)
			{
				y(null, null);
				this.m_h = true;
				c();
				this.m_h = true;
				t();
			}
			else
			{
				if ((int)val == 2)
				{
					return;
				}
				c();
				this.m_h = true;
				t();
			}
		}
		if ((int)((CommonDialog)@as).ShowDialog() != 1)
		{
			return;
		}
		this.m_h = true;
		q(null, null);
		t();
		MemoryStream memst = new MemoryStream();
		CryptoStream cs = null;
		EncDec.Decrypt(((FileDialog)@as).FileName, ref memst, ref cs, this.m_b);
		memst.Seek(0L, SeekOrigin.Begin);
		StreamReader streamReader2 = new StreamReader(memst);
		bn = streamReader2.ReadToEnd();
		streamReader2.BaseStream.Seek(0L, SeekOrigin.Begin);
		SaveData A_2 = (SaveData)new BinaryFormatter().Deserialize(streamReader2.BaseStream);
		streamReader2.Close();
		streamReader2.Dispose();
		cs.Close();
		cs.Dispose();
		if (A_2.originalfilename != ap)
		{
			DialogResult val2 = (DialogResult)7;
			if (ap != string.Empty)
			{
				val2 = MessageBox.Show("This save is associated with the game file " + A_2.originalfilename + ".  Would you like to load the save with the currently loaded game?", "Save file mismatch", (MessageBoxButtons)3);
			}
			if ((int)val2 == 2)
			{
				return;
			}
			if ((int)val2 == 7)
			{
				if (!File.Exists(A_2.originalfilename))
				{
					MessageBox.Show("Can not find the RAGS game " + A_2.originalfilename + ".  Please update the game file's location.", "Error loading RAGS game");
					((FileDialog)this.m_p).FileName = Path.GetFileName(A_2.originalfilename);
					if ((int)((CommonDialog)this.m_p).ShowDialog() != 1)
					{
						return;
					}
					A_2.originalfilename = ((FileDialog)this.m_p).FileName;
				}
				bool flag2 = false;
				try
				{
					ap = A_2.originalfilename;
					Game.DBName = A_2.originalfilename;
					Game.GetDBConnection();
					bx = new Game(ap);
					while (!Game.bDoneWithWaitDlg)
					{
						Application.DoEvents();
					}
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					bq = new SaveData();
					bq.versionnumber = Game.ObjectVersionNumber;
					bq.originalfilename = ap;
					bq.CharacterList = bx.CharacterList;
					bq.ObjectList = bx.ObjectList;
					bq.RoomList = bx.RoomList;
					bq.ThePlayer = bx.ThePlayer;
					bq.VariableList = bx.VariableList;
					bq.TimerList = bx.TimerList;
					binaryFormatter.Serialize(br, bq);
				}
				catch
				{
					flag2 = true;
				}
				if (flag2)
				{
					MemoryStream memst2 = new MemoryStream();
					CryptoStream cs2 = null;
					EncDec.Decrypt(A_2.originalfilename, ref memst2, ref cs2, this.m_b);
					memst2.Seek(0L, SeekOrigin.Begin);
					bx = null;
					if (bx == null)
					{
						memst2.Seek(0L, SeekOrigin.Begin);
						bx = (Game)new BinaryFormatter().Deserialize(memst2);
						GameObject.TheGame = bx;
						Character.TheGame = bx;
					}
					memst2.Close();
					memst2.Dispose();
					cs2.Close();
					cs2.Dispose();
				}
			}
			if (bu.Checked)
			{
				Font val3 = null;
				try
				{
					string text = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "GameFont", "None");
					if (text == null)
					{
						text = "None";
					}
					if (text == "None")
					{
						val3 = new Font("Times New Roman", 12f);
					}
					else
					{
						string[] array = text.Split(new string[1] { "," }, StringSplitOptions.None);
						val3 = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
					}
				}
				catch
				{
					val3 = new Font("Times New Roman", 12f);
				}
				((Control)this.m_u).Font = val3;
			}
			else
			{
				((Control)this.m_u).Font = bx.GameFont;
			}
			g();
			bx.CorrectCommandAndConditions();
		}
		((Control)this.m_z).Enabled = true;
		if (A_2.originalfilename != ap)
		{
			a(ref A_2);
		}
		else
		{
			ap = A_2.originalfilename;
			bx.CharacterList = A_2.CharacterList;
			bx.ObjectList = A_2.ObjectList;
			bx.RoomList = A_2.RoomList;
			bx.ThePlayer = A_2.ThePlayer;
			bx.VariableList = A_2.VariableList;
			bx.TimerList = A_2.TimerList;
			bx.StatusBarItems = A_2.StatusBarList;
		}
		((Control)this).Text = "Rapid Game Development System " + Path.GetFileName(A_2.originalfilename) + " " + Game.CurrentObjectVersionNumber;
		s();
		m();
		l();
		a(bx.ThePlayer.PlayerPortrait, A_1: false);
		a(bx.ThePlayer.PlayerLayeredImage, A_1: true);
		a(A_0: true, A_1: false);
		if (bx.bgMusic != string.Empty)
		{
			object pictureByName = bx.GetPictureByName(bx.bgMusic);
			if (pictureByName != null && pictureByName is string uRL)
			{
				b1.URL = uRL;
			}
		}
		this.m_h = false;
	}

	private void e()
	{
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected Obj, but got Unknown
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Invalid comparison between Unknown and I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Invalid comparison between Unknown and I4
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected Obj, but got Unknown
		try
		{
			this.m_h = true;
			q(null, null);
			t();
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			EncDec.Decrypt(Path.Combine(text, "QuickSave.rsv"), ref memst, ref cs, this.m_b);
			memst.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memst);
			bn = streamReader.ReadToEnd();
			streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			SaveData A_ = (SaveData)new BinaryFormatter().Deserialize(streamReader.BaseStream);
			streamReader.Close();
			streamReader.Dispose();
			cs.Close();
			cs.Dispose();
			if (A_.originalfilename != ap)
			{
				DialogResult val = (DialogResult)7;
				if (ap != string.Empty)
				{
					val = MessageBox.Show("This save is associated with the game file " + A_.originalfilename + ".  Would you like to load the save with the currently loaded game?", "Save file mismatch", (MessageBoxButtons)3);
				}
				if ((int)val == 2)
				{
					return;
				}
				if ((int)val == 7)
				{
					if (!File.Exists(A_.originalfilename))
					{
						MessageBox.Show("Can not find the RAGS game " + A_.originalfilename + ".  Please update the game file's location.", "Error loading RAGS game");
						((FileDialog)this.m_p).FileName = Path.GetFileName(A_.originalfilename);
						if ((int)((CommonDialog)this.m_p).ShowDialog() != 1)
						{
							return;
						}
						A_.originalfilename = ((FileDialog)this.m_p).FileName;
					}
					bool flag = false;
					try
					{
						ap = A_.originalfilename;
						Game.DBName = A_.originalfilename;
						Game.GetDBConnection();
						bx = new Game(ap);
						GameObject.TheGame = bx;
						Character.TheGame = bx;
						while (!Game.bDoneWithWaitDlg)
						{
							Application.DoEvents();
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
						EncDec.Decrypt(A_.originalfilename, ref memst2, ref cs2, this.m_b);
						memst2.Seek(0L, SeekOrigin.Begin);
						bx = null;
						if (bx == null)
						{
							memst2.Seek(0L, SeekOrigin.Begin);
							bx = (Game)new BinaryFormatter().Deserialize(memst2);
							GameObject.TheGame = bx;
							Character.TheGame = bx;
						}
						memst2.Close();
						memst2.Dispose();
						cs2.Close();
						cs2.Dispose();
					}
				}
				if (bu.Checked)
				{
					Font val2 = null;
					try
					{
						string text2 = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "GameFont", "None");
						if (text2 == null)
						{
							text2 = "None";
						}
						if (text2 == "None")
						{
							val2 = new Font("Times New Roman", 12f);
						}
						else
						{
							string[] array = text2.Split(new string[1] { "," }, StringSplitOptions.None);
							val2 = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
						}
					}
					catch
					{
						val2 = new Font("Times New Roman", 12f);
					}
					((Control)this.m_u).Font = val2;
				}
				else
				{
					((Control)this.m_u).Font = bx.GameFont;
				}
				g();
				bx.CorrectCommandAndConditions();
			}
			((Control)this.m_z).Enabled = true;
			if (A_.originalfilename != ap)
			{
				a(ref A_);
			}
			else
			{
				ap = A_.originalfilename;
				bx.CharacterList = A_.CharacterList;
				bx.ObjectList = A_.ObjectList;
				bx.RoomList = A_.RoomList;
				bx.ThePlayer = A_.ThePlayer;
				bx.VariableList = A_.VariableList;
				bx.TimerList = A_.TimerList;
				bx.StatusBarItems = A_.StatusBarList;
			}
			((Control)this).Text = "Rapid Game Development System " + Path.GetFileName(A_.originalfilename) + " " + Game.CurrentObjectVersionNumber;
			s();
			m();
			l();
			a(bx.ThePlayer.PlayerPortrait, A_1: false);
			a(bx.ThePlayer.PlayerLayeredImage, A_1: true);
			a(A_0: true, A_1: false);
			if (bx.bgMusic != string.Empty)
			{
				object pictureByName = bx.GetPictureByName(bx.bgMusic);
				if (pictureByName != null && pictureByName is string uRL)
				{
					b1.URL = uRL;
				}
			}
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Quickloaded...\r\n", Color.Black, (FontStyle)1);
			this.m_h = false;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error trying to quickload:" + ex.Message);
		}
	}

	private void i(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 2097152)
		{
			((ToolStrip)this.m_q).Items.Clear();
			if (bx != null)
			{
				a(bx.ThePlayer.Actions, "None", null);
				ca = frmMain.b.b;
				((ToolStripDropDown)this.m_q).Show((Control)(object)this.m_y, A_1.X, A_1.Y);
			}
		}
	}

	private void w(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new d()).ShowDialog();
	}

	private void v(object A_0, EventArgs A_1)
	{
		((Form)this).Close();
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
	}

	private void u(object A_0, EventArgs A_1)
	{
	}

	private void a(object A_0, FormClosingEventArgs A_1)
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Invalid comparison between Unknown and I4
		c();
		bool flag = true;
		if (bn != string.Empty)
		{
			if (bx != null)
			{
				SaveData saveData = new SaveData();
				saveData.versionnumber = Game.ObjectVersionNumber;
				saveData.originalfilename = ap;
				saveData.CharacterList = bx.CharacterList;
				saveData.ObjectList = bx.ObjectList;
				saveData.RoomList = bx.RoomList;
				saveData.ThePlayer = bx.ThePlayer;
				saveData.VariableList = bx.VariableList;
				saveData.TimerList = bx.TimerList;
				saveData.StatusBarList = bx.StatusBarItems;
				MemoryStream memoryStream = new MemoryStream();
				new BinaryFormatter().Serialize(memoryStream, saveData);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				StreamReader streamReader = new StreamReader(memoryStream);
				if (string.Compare(strB: streamReader.ReadToEnd(), strA: bn) == 0)
				{
					flag = false;
				}
				streamReader.Close();
				streamReader.Dispose();
				memoryStream.Close();
				memoryStream.Dispose();
			}
			else
			{
				flag = false;
			}
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length >= 3 && commandLineArgs[2] == "DEBUG")
		{
			flag = false;
		}
		if (flag)
		{
			DialogResult val = MessageBox.Show("Would you like to save your game before exiting?", "Save", (MessageBoxButtons)3);
			if ((int)val == 6)
			{
				y(null, null);
				this.m_h = true;
				this.m_h = true;
				t();
			}
			else if ((int)val == 2)
			{
				((CancelEventArgs)(object)A_1).Cancel = true;
			}
			else
			{
				c();
				this.m_h = true;
				t();
			}
		}
		else
		{
			t();
		}
		if (bx == null)
		{
			return;
		}
		foreach (GamePicture picture in bx.PictureList)
		{
			string[] files = Directory.GetFiles(Path.GetTempPath(), "*" + picture.TheName);
			foreach (string path in files)
			{
				try
				{
					File.Delete(path);
				}
				catch
				{
				}
			}
		}
	}

	private void t(object A_0, EventArgs A_1)
	{
		b();
		this.m_b = "²µ±±³àòå²²";
		string text = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "CheckForUpdates", "true");
		if (text == null)
		{
			text = "true";
		}
		if (string.Compare(text, "true", ignoreCase: true) == 0)
		{
			ThreadPool.QueueUserWorkItem(a, bx);
			a1.Checked = true;
		}
		else
		{
			a1.Checked = false;
		}
		text = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "OverrideGameFont", "true");
		if (text == null)
		{
			text = "false";
		}
		if (string.Compare(text, "true", ignoreCase: true) == 0)
		{
			bu.Checked = true;
		}
		else
		{
			bu.Checked = false;
		}
	}

	private static void a(object A_0)
	{
		try
		{
			Version version = new Version(new CheckUpdates().CheckVersion());
			Version version2 = new Version(Game.ObjectVersionNumber);
			if (version > version2)
			{
				frmMain.m_a = true;
			}
		}
		catch
		{
		}
	}

	private void s(object A_0, EventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		if (frmMain.m_a)
		{
			frmMain.m_a = false;
			if ((int)MessageBox.Show("There is a newer version of the Rags Suite available.  Would you like to update now?", "Update Available", (MessageBoxButtons)4) == 6)
			{
				Process.Start("IEXPLORE.EXE", "http://www.ragsgame.com/Downloads.aspx");
			}
		}
	}

	private void r(object A_0, EventArgs A_1)
	{
		a1.Checked = !a1.Checked;
		if (a1.Checked)
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "CheckForUpdates", "true");
		}
		else
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "CheckForUpdates", "false");
		}
	}

	private void d()
	{
		((Control)a3).Enabled = true;
		((Control)a3).Focus();
		((Control)this.m_ab).Enabled = false;
		((Control)this.m_t).Enabled = false;
		((Control)a9).Enabled = false;
		((Control)this.m_y).Enabled = false;
		while (((Control)a3).Enabled && !this.m_h)
		{
			Application.DoEvents();
			Thread.Sleep(50);
		}
	}

	private void q(object A_0, EventArgs A_1)
	{
		((Control)this.m_t).Enabled = true;
		((Control)a3).Enabled = false;
		((Control)this.m_ab).Enabled = true;
		((Control)a9).Enabled = true;
		((Control)this.m_y).Enabled = true;
	}

	private void a(string A_0, bool A_1)
	{
		if (A_0 == string.Empty)
		{
			return;
		}
		A_0 = bx.PerformTextReplacements(A_0, null);
		object pictureByName = bx.GetPictureByName(A_0);
		if (pictureByName != null)
		{
			Image val = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val != null)
			{
				((Control)b3).Visible = false;
				((Control)this.m_y).Visible = true;
				if (A_1)
				{
					this.m_y.Image = val;
					return;
				}
				((Control)this.m_y).Tag = bx.GetGamePictureByName(A_0);
				((Control)this.m_y).BackgroundImage = val;
			}
			else
			{
				((Control)b3).Visible = true;
				((Control)this.m_y).Visible = false;
				b3.URL = pictureByName as string;
			}
		}
		else
		{
			((Control)b3).Visible = false;
			((Control)this.m_y).Visible = true;
			this.m_y.Image = null;
			((Control)this.m_y).BackgroundImage = null;
		}
	}

	private void p(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)a8).ShowDialog() == 1)
		{
			this.m_u.SaveFile(((FileDialog)a8).FileName);
		}
	}

	private void o(object A_0, EventArgs A_1)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length <= 1)
		{
			return;
		}
		string text = Environment.GetCommandLineArgs()[1];
		if (text != null)
		{
			((Control)this.m_z).Enabled = true;
			ap = text;
			if (!File.Exists(text))
			{
				MessageBox.Show("Sorry, unable to locate the game " + text + ".  Please ensure the file exists and try again.");
				return;
			}
			e(text);
			s();
			r();
		}
		if (commandLineArgs.Length > 2 && Environment.GetCommandLineArgs()[2] == "DEBUG" && this.m_i != null)
		{
			if (bm != string.Empty)
			{
				((Control)this.m_i).Height = Convert.ToInt32(bm);
			}
			if (bk != string.Empty)
			{
				((Control)this.m_i).Left = Convert.ToInt32(bk);
			}
			if (bj != string.Empty)
			{
				((Control)this.m_i).Top = Convert.ToInt32(bj);
			}
			if (bl != string.Empty)
			{
				((Control)this.m_i).Width = Convert.ToInt32(bl);
			}
		}
	}

	private void h(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 2097152)
		{
			((ToolStrip)this.m_q).Items.Clear();
			if (bx != null)
			{
				a(bx.ThePlayer.CurrentRoom.Actions, "None", null);
				ca = frmMain.b.a;
				((ToolStripDropDown)this.m_q).Show((Control)(object)a9, A_1.X, A_1.Y);
			}
		}
	}

	private void g(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 2097152)
		{
			((ToolStrip)this.m_q).Items.Clear();
			if (bx != null)
			{
				a(bx.ThePlayer.CurrentRoom.Actions, "None", null);
				ca = frmMain.b.a;
				((ToolStripDropDown)this.m_q).Show((Control)(object)a2, A_1.X, A_1.Y);
			}
		}
	}

	private void n(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		Action A_2 = ((ToolStripItem)val).Tag as Action;
		if (A_2 == null)
		{
			return;
		}
		p();
		TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Room: " + bx.ThePlayer.CurrentRoom.GetName() + " - " + ((ToolStripItem)val).Text + "\r\n", Color.Black, (FontStyle)1);
		if (a(ref A_2, null))
		{
			if (!frmMain.m_g)
			{
				n();
				r();
			}
			else
			{
				frmMain.m_g = false;
			}
			o();
			m();
			l();
			h();
		}
	}

	private void m(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new QuickHelp()).ShowDialog();
	}

	private void l(object A_0, EventArgs A_1)
	{
	}

	private void k(object A_0, EventArgs A_1)
	{
		if (bx != null)
		{
			p();
			be = false;
			bf = Exit.Directions.In;
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "In\r\n", Color.Black, (FontStyle)1);
			if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
			{
				bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
				d("<<On Player Leave First Time>>");
			}
			d("<<On Player Leave>>");
			if (!be)
			{
				bx.MovePlayer(Exit.Directions.In);
				a(A_0: true, A_1: true);
			}
			bf = Exit.Directions.Empty;
		}
	}

	private void j(object A_0, EventArgs A_1)
	{
		if (bx != null)
		{
			p();
			be = false;
			bf = Exit.Directions.Out;
			TextHandlers.AddTextToRTF(ref this.m_u, ref bx, "Out\r\n", Color.Black, (FontStyle)1);
			if (!bx.ThePlayer.CurrentRoom.bLeaveFirstTime)
			{
				bx.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
				d("<<On Player Leave First Time>>");
			}
			d("<<On Player Leave>>");
			if (!be)
			{
				bx.MovePlayer(Exit.Directions.Out);
				a(A_0: true, A_1: true);
			}
			bf = Exit.Directions.Empty;
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected I4, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		Keys keyData = A_1.KeyData;
		if ((int)keyData <= 107)
		{
			if ((int)keyData != 13)
			{
				switch (keyData - 33)
				{
				default:
					if ((int)keyData == 107 && ((Control)this.m_an).Visible)
					{
						ad(null, null);
					}
					break;
				case 12:
					if (((Control)bh).Visible)
					{
						k((object)null, (EventArgs)null);
					}
					break;
				case 13:
					if (((Control)bg).Visible)
					{
						j((object)null, (EventArgs)null);
					}
					break;
				case 5:
					if (((Control)this.m_ag).Visible)
					{
						am(null, null);
					}
					break;
				case 7:
					if (((Control)this.m_af).Visible)
					{
						al(null, null);
					}
					break;
				case 4:
					if (((Control)this.m_ah).Visible)
					{
						ak(null, null);
					}
					break;
				case 6:
					if (((Control)this.m_ai).Visible)
					{
						aj(null, null);
					}
					break;
				case 3:
					if (((Control)this.m_aj).Visible)
					{
						ag(null, null);
					}
					break;
				case 0:
					if (((Control)this.m_am).Visible)
					{
						af(null, null);
					}
					break;
				case 2:
					if (((Control)this.m_al).Visible)
					{
						ai(null, null);
					}
					break;
				case 1:
					if (((Control)this.m_ak).Visible)
					{
						ah(null, null);
					}
					break;
				case 8:
				case 9:
				case 10:
				case 11:
					break;
				}
			}
			else
			{
				q(null, null);
			}
		}
		else if ((int)keyData != 109)
		{
			if ((int)keyData != 119)
			{
				if ((int)keyData == 120)
				{
					e();
				}
			}
			else
			{
				f();
			}
		}
		else if (((Control)this.m_ao).Visible)
		{
			ae(null, null);
		}
	}

	private void i(object A_0, EventArgs A_1)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerWidth", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerHeight", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSplitcontainer2", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSplitcontainer1", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSplitcontainer3", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSplitcontainer4", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSplitcontainer5", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "PlayerSCStatusBar", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmTop", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmLeft", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmWidth", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmHeight", "");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "WindowState", ((object)(FormWindowState)0/*cast due to constrained. prefix*/).ToString());
			this.m_c = true;
			MessageBox.Show("Window positions have been reset.  You will need to restart Rags for the changes to take effect.");
		}
		catch
		{
		}
	}

	private void c()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		if (this.m_c)
		{
			return;
		}
		try
		{
			new List<string>();
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "RagsConfig.xml");
			if (!File.Exists(text2))
			{
				string contents = "<Configuration> </Configuration>";
				File.WriteAllText(text2, contents);
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text2);
			XmlNodeList xmlNodeList = null;
			XmlElement xmlElement = null;
			_ = string.Empty;
			xmlNodeList = xmlDocument.SelectNodes("Configuration/DisplaySettings");
			xmlElement = xmlDocument.CreateElement("DisplaySettings");
			if ((int)((Form)this).WindowState == 0)
			{
				XmlElement xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "Size");
				xmlElement2.SetAttribute("Value", ((Form)this).Size.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "Location");
				xmlElement2.SetAttribute("Value", ((Form)this).Location.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSplitcontainer2");
				xmlElement2.SetAttribute("Value", this.m_s.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSplitcontainer1");
				xmlElement2.SetAttribute("Value", this.m_r.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSplitcontainer3");
				xmlElement2.SetAttribute("Value", this.m_ac.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSplitcontainer4");
				xmlElement2.SetAttribute("Value", this.m_ad.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSplitcontainer5");
				xmlElement2.SetAttribute("Value", this.m_ae.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement("Setting");
				xmlElement2.SetAttribute("Name", "PlayerSCStatusBar");
				xmlElement2.SetAttribute("Value", this.m_ab.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
			}
			XmlElement xmlElement3 = xmlDocument.CreateElement("Setting");
			xmlElement3.SetAttribute("Name", "WindowState");
			xmlElement3.SetAttribute("Value", ((object)((Form)this).WindowState/*cast due to constrained. prefix*/).ToString());
			xmlElement.AppendChild(xmlElement3);
			if (xmlNodeList[0] != null)
			{
				XmlNode xmlNode = xmlNodeList[0];
				xmlNode.ParentNode.ReplaceChild(xmlElement, xmlNode);
			}
			else
			{
				xmlNodeList = xmlDocument.SelectNodes("Configuration");
				if (xmlNodeList[0] != null)
				{
					xmlNodeList[0].AppendChild(xmlElement);
				}
			}
			xmlDocument.Save(text2);
		}
		catch
		{
		}
	}

	private void b()
	{
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Form)this).StartPosition = (FormStartPosition)0;
			new List<string>();
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "RagsConfig.xml");
			if (!File.Exists(text2))
			{
				string contents = "<Configuration> </Configuration>";
				File.WriteAllText(text2, contents);
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text2);
			XmlNodeList xmlNodeList = null;
			_ = string.Empty;
			xmlNodeList = xmlDocument.SelectNodes("Configuration/DisplaySettings");
			xmlDocument.CreateElement("DisplaySettings");
			if (xmlNodeList.Count <= 0)
			{
				return;
			}
			foreach (XmlNode childNode in xmlNodeList[0].ChildNodes)
			{
				switch (childNode.Attributes["Name"].Value.ToString())
				{
				case "Location":
				{
					string[] array2 = childNode.Attributes["Value"].Value.Split(new string[1] { "," }, StringSplitOptions.None);
					if (array2.Length == 2)
					{
						int num = Convert.ToInt32(array2[0].Substring(3));
						int num2 = Convert.ToInt32(array2[1].Substring(2, array2[1].Length - 3));
						((Form)this).Location = new Point(num, num2);
					}
					break;
				}
				case "Size":
				{
					string[] array = childNode.Attributes["Value"].Value.Split(new string[1] { "," }, StringSplitOptions.None);
					if (array.Length == 2)
					{
						int width = Convert.ToInt32(array[0].Substring(7));
						int height = Convert.ToInt32(array[1].Substring(8, array[1].Length - 9));
						((Form)this).Size = new Size(width, height);
					}
					break;
				}
				case "WindowState":
					((Form)this).WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), childNode.Attributes["Value"].Value.ToString());
					break;
				}
			}
		}
		catch
		{
		}
	}

	private bool a(ref GameObject A_0)
	{
		GameObject A_1 = null;
		foreach (GameObject @object in bx.ObjectList)
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

	private void h(object A_0, EventArgs A_1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		if (bx != null)
		{
			bt.Font = bx.GameFont;
			if ((int)((CommonDialog)bt).ShowDialog() == 1)
			{
				((Control)this.m_u).Font = bt.Font;
				Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "GameFont", bt.Font);
			}
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		bu.Checked = !bu.Checked;
		if (bu.Checked)
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "OverrideGameFont", "true");
			Font val = null;
			try
			{
				string text = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Rags", "GameFont", "None");
				if (text == null)
				{
					text = "None";
				}
				if (text == "None")
				{
					val = new Font("Times New Roman", 12f);
				}
				else
				{
					string[] array = text.Split(new string[1] { "," }, StringSplitOptions.None);
					val = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
				}
			}
			catch
			{
				val = new Font("Times New Roman", 12f);
			}
			((Control)this.m_u).Font = val;
		}
		else
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "OverrideGameFont", "false");
			if (bx != null)
			{
				((Control)this.m_u).Font = bx.GameFont;
			}
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (bx != null)
		{
			((Form)new GameInfoFrm(bx.AuthorName, bx.GameVersion, bx.GameInformation)).ShowDialog();
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new RagsShare()).ShowDialog();
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

	private void b(object A_0, _WMPOCXEvents_MouseDownEvent A_1)
	{
		if (A_1.nButton == 2)
		{
			((ToolStrip)this.m_q).Items.Clear();
			if (bx != null)
			{
				a(bx.ThePlayer.CurrentRoom.Actions, "None", null);
				ca = frmMain.b.a;
				((ToolStripDropDown)this.m_q).Show((Control)(object)b0, A_1.fX, ((Control)b0).Top + A_1.fY);
			}
		}
	}

	private void a(object A_0, _WMPOCXEvents_MouseDownEvent A_1)
	{
		if (A_1.nButton == 2)
		{
			((ToolStrip)this.m_q).Items.Clear();
			if (bx != null)
			{
				a(bx.ThePlayer.Actions, "None", null);
				ca = frmMain.b.b;
				((ToolStripDropDown)this.m_q).Show((Control)(object)b3, A_1.fX, A_1.fY);
			}
		}
	}

	private void a(object A_0, _WMPOCXEvents_PlayStateChangeEvent A_1)
	{
		if (A_1.newState == 8)
		{
			b2 = true;
		}
		if (A_1.newState == 1 && b2)
		{
			b1.Ctlcontrols.play();
			b2 = false;
		}
	}

	private void a(AxWindowsMediaPlayer A_0)
	{
		int volume = A_0.settings.volume;
		for (int num = volume; num >= 0; num--)
		{
			A_0.settings.volume = num;
			Thread.Sleep(15);
		}
		A_0.settings.volume = volume;
	}

	private void b(object A_0, PaintEventArgs A_1)
	{
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Obj, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected Obj, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected Obj, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected Obj, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected Obj, but got Unknown
		if (bx == null || A_0 == null)
		{
			return;
		}
		PictureBox val = (PictureBox)((A_0 is PictureBox) ? A_0 : null);
		if (val == null || ((Control)val).Tag == null)
		{
			return;
		}
		GamePicture gamePicture = ((Control)val).Tag as GamePicture;
		if (gamePicture != null)
		{
			foreach (string layeredImage in gamePicture.LayeredImages)
			{
				object pictureByName = bx.GetPictureByName(layeredImage);
				Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
				if (val2 != null)
				{
					A_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
				}
			}
		}
		if (gamePicture == null || gamePicture.Choices.Count <= 0)
		{
			return;
		}
		int count = gamePicture.Choices.Count;
		float num = ((Control)this.m_t).Width;
		float num2 = ((Control)this.m_t).Height;
		int num3 = 0;
		for (int num4 = count - 1; num4 >= 0; num4--)
		{
			Character character = gamePicture.Choices[num4] as Character;
			GameObject gameObject = gamePicture.Choices[num4] as GameObject;
			string empty = string.Empty;
			if (character != null)
			{
				empty = character.ToString();
			}
			else
			{
				empty = ((gameObject == null) ? gamePicture.Choices[num4].ToString() : gameObject.GetDisplayName());
			}
			Font val3 = gamePicture.enhinputdata.TextFont;
			if (num4 == 0)
			{
				val3 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
			}
			float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
			SizeF sizeF = new SizeF(num - 20f, height);
			SizeF sizeF2 = A_1.Graphics.MeasureString(empty, val3, sizeF);
			Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
			Point pt = ((Control)this.m_t).PointToClient(Cursor.Position);
			if (gamePicture.enhinputdata.BackgroundColor.ToArgb() == 0)
			{
				gamePicture.enhinputdata.BackgroundColor = Color.FromArgb(-1929379841);
			}
			A_1.Graphics.FillRectangle((Brush)new SolidBrush(gamePicture.enhinputdata.BackgroundColor), rectangle);
			if (rectangle.Contains(pt))
			{
				if (num4 == 0)
				{
					A_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Red), 3f), rectangle);
				}
				else
				{
					A_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Green), 3f), rectangle);
				}
			}
			if (gamePicture.enhinputdata.TextColor.ToArgb() == 0)
			{
				gamePicture.enhinputdata.TextColor = Color.FromArgb(-16777216);
			}
			A_1.Graphics.DrawString(empty, val3, (Brush)new SolidBrush(gamePicture.enhinputdata.TextColor), (RectangleF)rectangle);
			num3 += rectangle.Height + 5;
		}
	}

	private void a()
	{
		((Control)this.m_t).Invalidate();
		((Control)this.m_y).Invalidate();
		((Control)a9).Invalidate();
	}

	private void d(object A_0, EventArgs A_1)
	{
		f();
	}

	private void c(object A_0, EventArgs A_1)
	{
		e();
	}

	private void a(object A_0, PaintEventArgs A_1)
	{
		if (bx == null || A_0 == null)
		{
			return;
		}
		PictureBox val = (PictureBox)((A_0 is PictureBox) ? A_0 : null);
		if (val == null || !(((Control)val).Tag is GamePicture gamePicture))
		{
			return;
		}
		foreach (string layeredImage in gamePicture.LayeredImages)
		{
			object pictureByName = bx.GetPictureByName(layeredImage);
			Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val2 != null)
			{
				A_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
			}
		}
	}

	private void f(object A_0, MouseEventArgs A_1)
	{
		((Control)this.m_t).Invalidate();
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		Graphics val = ((Control)this.m_t).CreateGraphics();
		if (!(((Control)this.m_t).Tag is GamePicture gamePicture) || gamePicture.Choices.Count <= 0)
		{
			return;
		}
		int count = gamePicture.Choices.Count;
		float num = ((Control)this.m_t).Width;
		float num2 = ((Control)this.m_t).Height;
		int num3 = 0;
		for (int num4 = count - 1; num4 >= 0; num4--)
		{
			Character character = gamePicture.Choices[num4] as Character;
			GameObject gameObject = gamePicture.Choices[num4] as GameObject;
			object obj = null;
			string empty = string.Empty;
			if (character != null)
			{
				empty = character.ToString();
				obj = character;
			}
			else if (gameObject != null)
			{
				empty = gameObject.GetDisplayName();
				obj = gameObject;
			}
			else
			{
				empty = gamePicture.Choices[num4].ToString();
				obj = empty;
			}
			Font val2 = gamePicture.enhinputdata.TextFont;
			if (num4 == 0)
			{
				val2 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
			}
			float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
			SizeF sizeF = new SizeF(num - 20f, height);
			SizeF sizeF2 = val.MeasureString(empty, val2, sizeF);
			Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
			Point pt = ((Control)this.m_t).PointToClient(Cursor.Position);
			if (rectangle.Contains(pt))
			{
				if (num4 != 0)
				{
					bc = obj;
				}
				break;
			}
			num3 += rectangle.Height + 5;
		}
	}

	private void e(object A_0, MouseEventArgs A_1)
	{
		int num = lbCharacters.IndexFromPoint(A_1.X, A_1.Y);
		if (num != -1)
		{
			((ListControl)lbCharacters).SelectedIndex = num;
			((ToolStrip)this.m_q).Items.Clear();
			Character character = lbCharacters.SelectedItem as Character;
			GameObject gameObject = lbCharacters.SelectedItem as GameObject;
			ArrayList arrayList = null;
			if (character != null)
			{
				arrayList = character.Actions;
			}
			else if (gameObject != null)
			{
				arrayList = gameObject.Actions;
			}
			if (arrayList != null)
			{
				a(arrayList, "None", null);
				ca = frmMain.b.d;
				((ToolStripDropDown)this.m_q).Show((Control)(object)lbCharacters, A_1.X, A_1.Y);
			}
		}
	}

	private void d(object A_0, MouseEventArgs A_1)
	{
		int num = lbRoomObjects.IndexFromPoint(A_1.X, A_1.Y);
		if (num != -1)
		{
			((ListControl)lbRoomObjects).SelectedIndex = num;
			((ToolStrip)this.m_q).Items.Clear();
			GameObject gameObject = lbRoomObjects.Items[num] as GameObject;
			a(gameObject.Actions, "None", null);
			ca = frmMain.b.c;
			((ToolStripDropDown)this.m_q).Show((Control)(object)lbRoomObjects, A_1.X, A_1.Y);
		}
	}

	private void c(object A_0, MouseEventArgs A_1)
	{
		((ToolStrip)this.m_q).Items.Clear();
		if (bx != null)
		{
			a(bx.ThePlayer.CurrentRoom.Actions, "None", null);
			ca = frmMain.b.a;
			((ToolStripDropDown)this.m_q).Show((Control)(object)a9, A_1.X, A_1.Y);
		}
	}

	private void b(object A_0, MouseEventArgs A_1)
	{
		((ToolStrip)this.m_q).Items.Clear();
		if (bx != null)
		{
			a(bx.ThePlayer.Actions, "None", null);
			ca = frmMain.b.b;
			((ToolStripDropDown)this.m_q).Show((Control)(object)this.m_y, A_1.X, A_1.Y);
		}
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		int num = lbInventory.IndexFromPoint(A_1.X, A_1.Y);
		if (num != -1)
		{
			((ListControl)lbInventory).SelectedIndex = num;
			((ToolStrip)this.m_q).Items.Clear();
			GameObject gameObject = lbInventory.Items[num] as GameObject;
			a(gameObject.Actions, "None", null);
			ca = frmMain.b.e;
			((ToolStripDropDown)this.m_q).Show((Control)(object)lbInventory, A_1.X, A_1.Y);
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
	}

	private double a(GameVariable A_0, string A_1)
	{
		if (A_0.bEnforceRestrictions)
		{
			double num = Convert.ToDouble(bx.PerformTextReplacements(A_0.dMin, null));
			double num2 = Convert.ToDouble(bx.PerformTextReplacements(A_0.dMax, null));
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

	private void a(ref SaveData A_0)
	{
		ap = A_0.originalfilename;
		foreach (Character character in A_0.CharacterList)
		{
			bx.GetCharacterByName(character.Charname)?.UpdateFromSave(character);
		}
		foreach (GameObject @object in A_0.ObjectList)
		{
			bx.GetObjectByName(@object.UniqueIdentifier.ToString())?.UpdateFromSave(@object);
		}
		foreach (Room room in A_0.RoomList)
		{
			bx.GetRoomByID(room.UniqueID)?.UpdateFromSave(room);
		}
		bx.ThePlayer.UpdateFromSave(A_0.ThePlayer);
		foreach (GameVariable variable in A_0.VariableList)
		{
			bx.GetVariableByName(variable.varname)?.UpdateFromSave(variable);
		}
		foreach (Timer timer in A_0.TimerList)
		{
			bx.GetTimerByName(timer.Name)?.UpdateFromSave(timer);
		}
		foreach (StatusBarItem statusBar in A_0.StatusBarList)
		{
			bx.GetStatusBarItemByName(statusBar.Name)?.UpdateFromSave(statusBar);
		}
	}

	static frmMain()
	{
		frmMain.m_a = false;
		frmMain.m_d = false;
		frmMain.m_e = string.Empty;
		frmMain.m_f = true;
		frmMain.m_g = false;
		bx = null;
		b5 = null;
	}
}
