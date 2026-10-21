using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Xml;
using AxWMPLib;
using Rags;
using RagsDesigner.Properties;
using RagsDesigner.ragsgame.com;

namespace RagsDesigner;

public class Form1 : Form
{
	private MemoryStream m_a;

	private string m_b = string.Empty;

	private string m_c = string.Empty;

	private static bool m_d;

	private static bool m_e;

	private OpenFileDialog m_f;

	private SaveFileDialog m_g;

	private bool m_h;

	private bool m_i;

	private bool m_j;

	private IContainer m_k;

	private bool m_l;

	private bool m_m;

	public static bool bUseAutoSave;

	public static int iAutoSaveMinutes;

	private string m_n = "";

	private OpenFileDialog m_o;

	private ContextMenu m_p;

	private MenuItem m_q;

	private MenuItem m_r;

	public TabControl tabControl1;

	private TabPage m_s;

	private TextBox m_t;

	private Label m_u;

	private TextBox m_v;

	private Label m_w;

	private TabPage m_x;

	public TabControl tabControl2;

	private TabPage m_y;

	public TextBox txtRoomName;

	public TextBox txtRoomSDesc;

	public TextBox txtRoomDescription;

	private Label m_z;

	private Label m_aa;

	private Label m_ab;

	private TabPage m_ac;

	private CheckBox m_ad;

	private ComboBox m_ae;

	private CheckBox m_af;

	private ComboBox m_ag;

	private CheckBox m_ah;

	private ComboBox m_ai;

	private CheckBox m_aj;

	private ComboBox m_ak;

	private CheckBox m_al;

	private ComboBox m_am;

	private CheckBox m_an;

	private ComboBox m_ao;

	private CheckBox m_ap;

	private ComboBox m_aq;

	private CheckBox m_ar;

	private ComboBox m_as;

	private CheckBox m_at;

	private ComboBox m_au;

	private Label m_av;

	private Label m_aw;

	private Label m_ax;

	private Label m_ay;

	private Label m_az;

	private Label m_a0;

	private Label m_a1;

	private Label m_a2;

	private Label m_a3;

	private Label m_a4;

	private CheckBox m_a5;

	private Label m_a6;

	private ComboBox m_a7;

	private Label m_a8;

	private TabPage m_a9;

	private Label m_ba;

	private ListBox m_bb;

	private Button m_bc;

	private TabPage m_bd;

	private PictureBox m_be;

	private ComboBox m_bf;

	private Label m_bg;

	private Label m_bh;

	private ComboBox m_bi;

	private GroupBox m_bj;

	private RadioButton m_bk;

	private RadioButton m_bl;

	private RadioButton m_bm;

	private CheckBox m_bn;

	private CheckBox m_bo;

	private TextBox m_bp;

	private Label m_bq;

	private TabPage m_br;

	private Panel m_bs;

	private Panel m_bt;

	private Label m_bu;

	private Splitter m_bv;

	private PictureBox m_bw;

	private Panel m_bx;

	private Label m_by;

	private Button m_bz;

	private ContextMenuStrip m_b0;

	private ToolStripMenuItem m_b1;

	private ToolStripMenuItem m_b2;

	private MenuStrip m_b3;

	private ToolStripMenuItem m_b4;

	private ToolStripMenuItem m_b5;

	private ToolStripMenuItem m_b6;

	private ToolStripMenuItem m_b7;

	private ToolStripMenuItem m_b8;

	private ContextMenuStrip m_b9;

	private Button m_ca;

	private Label m_cb;

	private ListBox m_cc;

	private ContextMenuStrip m_cd;

	private ContextMenuStrip m_ce;

	private ToolStripMenuItem m_cf;

	private ToolStripMenuItem m_cg;

	private ToolStripMenuItem m_ch;

	private ToolStripMenuItem m_ci;

	private TabPage m_cj;

	private GroupBox m_ck;

	private RadioButton m_cl;

	private RadioButton m_cm;

	private Button m_cn;

	private Label m_co;

	private GroupBox m_cp;

	private RichTextBox m_cq;

	private ContextMenuStrip m_cr;

	private ToolStripMenuItem m_cs;

	private ToolStripMenuItem m_ct;

	private TabPage m_cu;

	public TabControl tabControlCharData;

	private TabPage m_cv;

	private Label m_cw;

	private ListBox m_cx;

	private RadioButton m_cy;

	private RadioButton m_cz;

	private RadioButton m_c0;

	private Label m_c1;

	private ContextMenuStrip m_c2;

	private ToolStripMenuItem m_c3;

	private ToolStripMenuItem m_c4;

	private ContextMenuStrip m_c5;

	private ToolStripMenuItem m_c6;

	private ToolStripMenuItem m_c7;

	private GroupBox m_c8;

	private Button m_c9;

	private ToolStripMenuItem m_da;

	private ToolStripMenuItem m_db;

	private ContextMenuStrip m_dc;

	private ComboBox m_dd;

	private Label m_de;

	private TextBox m_df;

	private Label m_dg;

	public TabControl tabControl3;

	private TabPage m_dh;

	private Label m_di;

	private ListBox m_dj;

	private GroupBox m_dk;

	private GroupBox m_dl;

	private RadioButton m_dm;

	private RadioButton m_dn;

	private GroupBox m_do;

	private RadioButton m_dp;

	private RadioButton m_dq;

	private TextBox m_dr;

	private Label m_ds;

	private CheckBox m_dt;

	private CheckBox m_du;

	private CheckBox m_dv;

	private CheckBox m_dw;

	private CheckBox m_dx;

	private CheckBox m_dy;

	private TextBox m_dz;

	private Label m_d0;

	private TextBox m_d1;

	private Label m_d2;

	private TextBox m_d3;

	private Label m_d4;

	private Button m_d5;

	private TabPage m_d6;

	private TabPage m_d7;

	private TextBox m_d8;

	private Label m_d9;

	private Button m_ea;

	private ContextMenuStrip m_eb;

	private ToolStripMenuItem m_ec;

	private ToolStripMenuItem m_ed;

	private ContextMenuStrip m_ee;

	private ToolStripMenuItem m_ef;

	private ToolStripMenuItem m_eg;

	private Panel m_eh;

	private Button m_ei;

	private Button m_ej;

	private Label m_ek;

	private TextBox m_el;

	private CheckBox m_em;

	private SplitContainer m_en;

	private PictureBox m_eo;

	private Label m_ep;

	private ComboBox m_eq;

	private SplitContainer m_er;

	private SplitContainer m_es;

	public TabControl tabControl4;

	private TabPage m_et;

	private TabPage m_eu;

	private Label m_ev;

	private TextBox m_ew;

	private CheckBox m_ex;

	private GroupBox m_ey;

	private RadioButton m_ez;

	private RadioButton m_e0;

	private PictureBox m_e1;

	private PictureBox m_e2;

	private PictureBox m_e3;

	private PictureBox m_e4;

	private PictureBox m_e5;

	private PictureBox m_e6;

	private PictureBox m_e7;

	private PictureBox m_e8;

	private PictureBox m_e9;

	private PictureBox m_fa;

	private PictureBox m_fb;

	private PictureBox m_fc;

	private Label m_fd;

	private GroupBox m_fe;

	private Label m_ff;

	private Label m_fg;

	private TableLayoutPanel m_fh;

	private Label m_fi;

	private Label m_fj;

	private Label m_fk;

	private ToolStripMenuItem m_fl;

	private ToolStripMenuItem m_fm;

	private Label m_fn;

	private ComboBox m_fo;

	private ComboBox m_fp;

	private ComboBox m_fq;

	private ComboBox m_fr;

	private ComboBox m_fs;

	private ComboBox m_ft;

	private ComboBox m_fu;

	private ComboBox m_fv;

	private ComboBox m_fw;

	private ComboBox m_fx;

	private ToolStripMenuItem m_fy;

	private TabPage m_fz;

	public TabControl tabControl5;

	private TabPage m_f0;

	private PictureBox m_f1;

	private GroupBox m_f2;

	private RadioButton m_f3;

	private RadioButton m_f4;

	private Label m_f5;

	private Label m_f6;

	private PictureBox m_f7;

	private Label m_f8;

	private Button m_f9;

	private CheckBox m_ga;

	private GroupBox m_gb;

	private CheckBox m_gc;

	private TextBox m_gd;

	private Label m_ge;

	private ContextMenuStrip m_gf;

	private ToolStripMenuItem m_gg;

	private ToolStripMenuItem m_gh;

	private Timer m_gi;

	private ToolStripMenuItem m_gj;

	private Label m_gk;

	private Label m_gl;

	private ListBox m_gm;

	private GroupBox m_gn;

	private Label m_go;

	private Button m_gp;

	private Button m_gq;

	private TextBox m_gr;

	private TextBox m_gs;

	private Label m_gt;

	private ContextMenuStrip m_gu;

	private ToolStripMenuItem m_gv;

	private ToolStripMenuItem m_gw;

	private DateTimePicker m_gx;

	private RadioButton m_gy;

	private ToolStripMenuItem m_gz;

	private ToolStripMenuItem m_g0;

	private ToolStripMenuItem m_g1;

	private ToolStripMenuItem m_g2;

	private ToolStripMenuItem g3;

	private ToolStripMenuItem g4;

	private ToolStripMenuItem g5;

	private CheckBox g6;

	private GroupBox g7;

	private TextBox g8;

	private Label g9;

	private TextBox ha;

	private Label hb;

	private TextBox hc;

	private Label hd;

	private CheckBox he;

	private CheckBox hf;

	private GroupBox hg;

	private RadioButton hh;

	private RadioButton hi;

	public DataGridView dgvRoomList;

	private ContextMenuStrip hj;

	private ToolStripMenuItem hk;

	private ToolStripMenuItem hl;

	private MenuItem hm;

	private ToolStripMenuItem hn;

	public DataGridView dgvTimers;

	private Label ho;

	private NumericUpDown hp;

	private GroupBox hq;

	private CheckBox hr;

	public DataGridView dgvCharacters;

	private Button hs;

	private Button ht;

	private TextBox hu;

	private Label hv;

	private FontDialog hw;

	private RadioButton hx;

	private RadioButton hy;

	private RadioButton hz;

	private Button h0;

	private GroupBox h1;

	private Button h2;

	private ListBox h3;

	private Label h4;

	private TextBox h5;

	private Label h6;

	private CheckBox h7;

	private Button h8;

	private Label h9;

	private CheckBox ia;

	private ComboBox ib;

	private ComboBox ic;

	private CheckBox id;

	private Label ie;

	private ComboBox @if;

	private ComboBox ig;

	private ToolStripMenuItem ih;

	private ToolStripMenuItem ii;

	private SplitContainer ij;

	private DataGridViewTextBoxColumn ik;

	private SplitContainer il;

	private DataGridViewTextBoxColumn im;

	private SplitContainer @in;

	private SplitContainer io;

	private DataGridViewTextBoxColumn ip;

	private DataGridViewTextBoxColumn iq;

	private ToolStripMenuItem ir;

	private ToolStripMenuItem @is;

	private SaveFileDialog it;

	private OpenFileDialog iu;

	private MenuItem iv;

	private MenuItem iw;

	public static Game TheGame;

	private ToolStripMenuItem ix;

	private DataGridView iy;

	private CheckBox iz;

	private ToolStripMenuItem i0;

	private MenuItem i1;

	private MenuItem i2;

	private GameObject i3;

	private ToolStripMenuItem i4;

	private ToolStripMenuItem i5;

	private GroupBox i6;

	private TextBox i7;

	private TextBox i8;

	private Label i9;

	public TextBox tbRoomID;

	private Label ja;

	private ToolStripMenuItem jb;

	private TabPage jc;

	private Panel jd;

	private Label je;

	private PictureBox jf;

	private Label jg;

	private Label jh;

	private ListBox ji;

	private GroupBox jj;

	private Button jk;

	private Button jl;

	private Label jm;

	private ComboBox jn;

	private Label jo;

	private ComboBox jp;

	private GroupBox jq;

	private Button jr;

	private Button js;

	private ListBox jt;

	private RichTextBox ju;

	private Label jv;

	private PictureBox jw;

	private Label jx;

	private ComboBox jy;

	private Label jz;

	private ToolStripMenuItem j0;

	private ToolStripMenuItem j1;

	private SaveFileDialog j2;

	private GroupBox j3;

	private CheckBox j4;

	private CheckBox j5;

	private CheckBox j6;

	private Button j7;

	private Button j8;

	private TabControl j9;

	private TabPage ka;

	private TabPage kb;

	private PictureBox kc;

	private Label kd;

	private TextBox ke;

	private Label kf;

	private TextBox kg;

	private Label kh;

	private TextBox ki;

	private ToolStripMenuItem kj;

	private DataGridView kk;

	private GroupBox kl;

	private Button km;

	private Button kn;

	private DataGridViewTextBoxColumn ko;

	private DataGridViewTextBoxColumn kp;

	private Button kq;

	private Label kr;

	private TextBox ks;

	private Label kt;

	private TextBox ku;

	private TabPage kv;

	private GroupBox kw;

	private Label kx;

	private TextBox ky;

	private Label kz;

	private TextBox k0;

	private Button k1;

	private Button k2;

	private Button k3;

	private DataGridView k4;

	private DataGridViewTextBoxColumn k5;

	private DataGridViewTextBoxColumn k6;

	private TabPage k7;

	private GroupBox k8;

	private Label k9;

	private TextBox la;

	private Label lb;

	private TextBox lc;

	private Button ld;

	private Button le;

	private Button lf;

	private DataGridView lg;

	private DataGridViewTextBoxColumn lh;

	private DataGridViewTextBoxColumn li;

	private TabPage lj;

	private GroupBox lk;

	private Label ll;

	private TextBox lm;

	private Label ln;

	private TextBox lo;

	private Button lp;

	private Button lq;

	private Button lr;

	private DataGridView ls;

	private DataGridViewTextBoxColumn lt;

	private DataGridViewTextBoxColumn lu;

	private PictureBox lv;

	private PictureBox lw;

	private TabControl lx;

	private TabPage ly;

	private TabPage lz;

	private GroupBox l0;

	private Label l1;

	private TextBox l2;

	private Label l3;

	private TextBox l4;

	private Button l5;

	private Button l6;

	private Button l7;

	private DataGridView l8;

	private DataGridViewTextBoxColumn l9;

	private DataGridViewTextBoxColumn ma;

	private PictureBox mb;

	private PictureBox mc;

	private TabPage md;

	private PictureBox me;

	private GroupBox mf;

	private Label mg;

	private TextBox mh;

	private Label mi;

	private TextBox mj;

	private Button mk;

	private Button ml;

	private Button mm;

	private DataGridView mn;

	private DataGridViewTextBoxColumn mo;

	private DataGridViewTextBoxColumn mp;

	private ToolStripMenuItem mq;

	public TextBox tbCharacterNameOverride;

	private Label mr;

	private ContextMenuStrip ms;

	private ToolStripMenuItem mt;

	private GroupBox mu;

	private Label mv;

	private NumericUpDown mw;

	private CheckBox mx;

	private Panel my;

	private Panel mz;

	private SplitContainer m0;

	private Splitter m1;

	private Label m2;

	private ComboBox m3;

	private CheckBox m4;

	private TabPage m5;

	private SplitContainer m6;

	private DataGridView m7;

	private DataGridViewTextBoxColumn m8;

	private SplitContainer m9;

	private PictureBox na;

	private GroupBox nb;

	private ListBox nc;

	private Button nd;

	private Button ne;

	private Button nf;

	private ToolStripMenuItem ng;

	private ToolStripSeparator nh;

	private ToolStripMenuItem ni;

	private ToolStripSeparator nj;

	private ToolStripSeparator nk;

	private ToolStripSeparator nl;

	private SaveFileDialog nm;

	private OpenFileDialog nn;

	private ToolStripMenuItem no;

	private ToolStripMenuItem np;

	private ToolStripMenuItem nq;

	private TreeView nr;

	private ImageList ns;

	public TreeView tvItems;

	private MenuItem nt;

	private MenuItem nu;

	private MenuItem nv;

	private MenuItem nw;

	private ToolStripSeparator nx;

	private ToolStripSeparator ny;

	private ToolStripMenuItem nz;

	private ToolStripMenuItem n0;

	private ToolStripMenuItem n1;

	private CheckBox n2;

	private GroupBox n3;

	private Label n4;

	private ComboBox n5;

	private Label n6;

	private ComboBox n7;

	private Label n8;

	private ComboBox n9;

	private CheckBox oa;

	private CheckBox ob;

	public TreeView tvVariables;

	private ContextMenuStrip oc;

	private ToolStripMenuItem od;

	private ToolStripMenuItem oe;

	private ToolStripSeparator of;

	private ToolStripMenuItem og;

	private ToolStripMenuItem oh;

	private Label oi;

	private ToolStripMenuItem oj;

	private ToolStripMenuItem ok;

	private ToolStripMenuItem ol;

	private ToolStripMenuItem om;

	private Timer on;

	private Panel oo;

	private ComboBox op;

	private Label oq;

	private PictureBox or;

	private FolderBrowserDialog os;

	public ActionControl PlayerActions;

	public ActionControl RoomActions;

	public ActionControl CharacterActions;

	public ActionControl ObjectActions;

	public ActionControl TimerActions;

	private AxWindowsMediaPlayer ot;

	private AxWindowsMediaPlayer ou;

	private AxWindowsMediaPlayer ov;

	public static ArrayList ObjectLibrary;

	public Form1()
	{
		try
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
		}
		catch
		{
		}
		ap();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "ObjectLibrary.bin");
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		if (!File.Exists(path))
		{
			return;
		}
		StreamReader streamReader = null;
		try
		{
			streamReader = new StreamReader(path);
			streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			try
			{
				ObjectLibrary = (ArrayList)binaryFormatter.Deserialize(streamReader.BaseStream);
			}
			catch
			{
				ObjectLibrary = null;
			}
		}
		finally
		{
			if (streamReader != null)
			{
				streamReader.Close();
				streamReader.Dispose();
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_k != null)
		{
			this.m_k.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void ap()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected Obj, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected Obj, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected Obj, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected Obj, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected Obj, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected Obj, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected Obj, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected Obj, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected Obj, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected Obj, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected Obj, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected Obj, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected Obj, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected Obj, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected Obj, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected Obj, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected Obj, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected Obj, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected Obj, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected Obj, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected Obj, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected Obj, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected Obj, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected Obj, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected Obj, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected Obj, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected Obj, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected Obj, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected Obj, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected Obj, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected Obj, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected Obj, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected Obj, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected Obj, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected Obj, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected Obj, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected Obj, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected Obj, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected Obj, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected Obj, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected Obj, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected Obj, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected Obj, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected Obj, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected Obj, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected Obj, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected Obj, but got Unknown
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected Obj, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected Obj, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected Obj, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected Obj, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected Obj, but got Unknown
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected Obj, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected Obj, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected Obj, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected Obj, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected Obj, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected Obj, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected Obj, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected Obj, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected Obj, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected Obj, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected Obj, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected Obj, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected Obj, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Expected Obj, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected Obj, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected Obj, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected Obj, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected Obj, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected Obj, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected Obj, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected Obj, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected Obj, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected Obj, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected Obj, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected Obj, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected Obj, but got Unknown
		//IL_05af: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Expected Obj, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected Obj, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected Obj, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Expected Obj, but got Unknown
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected Obj, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected Obj, but got Unknown
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected Obj, but got Unknown
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected Obj, but got Unknown
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Expected Obj, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Expected Obj, but got Unknown
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Expected Obj, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Expected Obj, but got Unknown
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected Obj, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Expected Obj, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected Obj, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Expected Obj, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected Obj, but got Unknown
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected Obj, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected Obj, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected Obj, but got Unknown
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected Obj, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected Obj, but got Unknown
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected Obj, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected Obj, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected Obj, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected Obj, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected Obj, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected Obj, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected Obj, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Obj, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected Obj, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected Obj, but got Unknown
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Expected Obj, but got Unknown
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected Obj, but got Unknown
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected Obj, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected Obj, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected Obj, but got Unknown
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Expected Obj, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected Obj, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected Obj, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected Obj, but got Unknown
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected Obj, but got Unknown
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected Obj, but got Unknown
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected Obj, but got Unknown
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected Obj, but got Unknown
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Expected Obj, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected Obj, but got Unknown
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Expected Obj, but got Unknown
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Expected Obj, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected Obj, but got Unknown
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Expected Obj, but got Unknown
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected Obj, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Expected Obj, but got Unknown
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Expected Obj, but got Unknown
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Expected Obj, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected Obj, but got Unknown
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected Obj, but got Unknown
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected Obj, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected Obj, but got Unknown
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Expected Obj, but got Unknown
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Expected Obj, but got Unknown
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Expected Obj, but got Unknown
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Expected Obj, but got Unknown
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_086e: Expected Obj, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected Obj, but got Unknown
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected Obj, but got Unknown
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Expected Obj, but got Unknown
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Expected Obj, but got Unknown
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b0: Expected Obj, but got Unknown
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Expected Obj, but got Unknown
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c6: Expected Obj, but got Unknown
		//IL_08c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d1: Expected Obj, but got Unknown
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected Obj, but got Unknown
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Expected Obj, but got Unknown
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f2: Expected Obj, but got Unknown
		//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fd: Expected Obj, but got Unknown
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0908: Expected Obj, but got Unknown
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Expected Obj, but got Unknown
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Expected Obj, but got Unknown
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Expected Obj, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Expected Obj, but got Unknown
		//IL_0935: Unknown result type (might be due to invalid IL or missing references)
		//IL_093f: Expected Obj, but got Unknown
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Expected Obj, but got Unknown
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Expected Obj, but got Unknown
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Expected Obj, but got Unknown
		//IL_0961: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Expected Obj, but got Unknown
		//IL_096c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0976: Expected Obj, but got Unknown
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Expected Obj, but got Unknown
		//IL_0982: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected Obj, but got Unknown
		//IL_098d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0997: Expected Obj, but got Unknown
		//IL_0998: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Expected Obj, but got Unknown
		//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Expected Obj, but got Unknown
		//IL_09ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Expected Obj, but got Unknown
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c3: Expected Obj, but got Unknown
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Expected Obj, but got Unknown
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Expected Obj, but got Unknown
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e4: Expected Obj, but got Unknown
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected Obj, but got Unknown
		//IL_09f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Expected Obj, but got Unknown
		//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Expected Obj, but got Unknown
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a10: Expected Obj, but got Unknown
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Expected Obj, but got Unknown
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected Obj, but got Unknown
		//IL_0a27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Expected Obj, but got Unknown
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected Obj, but got Unknown
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected Obj, but got Unknown
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a52: Expected Obj, but got Unknown
		//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Expected Obj, but got Unknown
		//IL_0a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a68: Expected Obj, but got Unknown
		//IL_0a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a73: Expected Obj, but got Unknown
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected Obj, but got Unknown
		//IL_0a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Expected Obj, but got Unknown
		//IL_0a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Expected Obj, but got Unknown
		//IL_0a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Expected Obj, but got Unknown
		//IL_0aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaa: Expected Obj, but got Unknown
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab5: Expected Obj, but got Unknown
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac0: Expected Obj, but got Unknown
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Expected Obj, but got Unknown
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad6: Expected Obj, but got Unknown
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Expected Obj, but got Unknown
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Expected Obj, but got Unknown
		//IL_0aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Expected Obj, but got Unknown
		//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Expected Obj, but got Unknown
		//IL_0b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Expected Obj, but got Unknown
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Expected Obj, but got Unknown
		//IL_0b19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Expected Obj, but got Unknown
		//IL_0b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2e: Expected Obj, but got Unknown
		//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b39: Expected Obj, but got Unknown
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b44: Expected Obj, but got Unknown
		//IL_0b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Expected Obj, but got Unknown
		//IL_0b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Expected Obj, but got Unknown
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Expected Obj, but got Unknown
		//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Expected Obj, but got Unknown
		//IL_0b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7b: Expected Obj, but got Unknown
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b86: Expected Obj, but got Unknown
		//IL_0b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b91: Expected Obj, but got Unknown
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9c: Expected Obj, but got Unknown
		//IL_0b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba7: Expected Obj, but got Unknown
		//IL_0ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Expected Obj, but got Unknown
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbd: Expected Obj, but got Unknown
		//IL_0bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc8: Expected Obj, but got Unknown
		//IL_0bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Expected Obj, but got Unknown
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Expected Obj, but got Unknown
		//IL_0bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be9: Expected Obj, but got Unknown
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected Obj, but got Unknown
		//IL_0c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0a: Expected Obj, but got Unknown
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c15: Expected Obj, but got Unknown
		//IL_0c16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c20: Expected Obj, but got Unknown
		//IL_0c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2b: Expected Obj, but got Unknown
		//IL_0c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c36: Expected Obj, but got Unknown
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c41: Expected Obj, but got Unknown
		//IL_0c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4c: Expected Obj, but got Unknown
		//IL_0c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Expected Obj, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Expected Obj, but got Unknown
		//IL_0c63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6d: Expected Obj, but got Unknown
		//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Expected Obj, but got Unknown
		//IL_0c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Expected Obj, but got Unknown
		//IL_0c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8e: Expected Obj, but got Unknown
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Expected Obj, but got Unknown
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Expected Obj, but got Unknown
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Expected Obj, but got Unknown
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected Obj, but got Unknown
		//IL_0cbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc5: Expected Obj, but got Unknown
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd0: Expected Obj, but got Unknown
		//IL_0cd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdb: Expected Obj, but got Unknown
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Expected Obj, but got Unknown
		//IL_0ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf1: Expected Obj, but got Unknown
		//IL_0cf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfc: Expected Obj, but got Unknown
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d07: Expected Obj, but got Unknown
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d12: Expected Obj, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1d: Expected Obj, but got Unknown
		//IL_0d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d28: Expected Obj, but got Unknown
		//IL_0d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Expected Obj, but got Unknown
		//IL_0d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3e: Expected Obj, but got Unknown
		//IL_0d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d49: Expected Obj, but got Unknown
		//IL_0d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d54: Expected Obj, but got Unknown
		//IL_0d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Expected Obj, but got Unknown
		//IL_0d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6a: Expected Obj, but got Unknown
		//IL_0d6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Expected Obj, but got Unknown
		//IL_0d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d80: Expected Obj, but got Unknown
		//IL_0d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8b: Expected Obj, but got Unknown
		//IL_0d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d96: Expected Obj, but got Unknown
		//IL_0d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da1: Expected Obj, but got Unknown
		//IL_0da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dac: Expected Obj, but got Unknown
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected Obj, but got Unknown
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc2: Expected Obj, but got Unknown
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcd: Expected Obj, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected Obj, but got Unknown
		//IL_0dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de3: Expected Obj, but got Unknown
		//IL_0def: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Expected Obj, but got Unknown
		//IL_0dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e04: Expected Obj, but got Unknown
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Expected Obj, but got Unknown
		//IL_0e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1a: Expected Obj, but got Unknown
		//IL_0e1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e25: Expected Obj, but got Unknown
		//IL_0e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e30: Expected Obj, but got Unknown
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3b: Expected Obj, but got Unknown
		//IL_0e3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e46: Expected Obj, but got Unknown
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e51: Expected Obj, but got Unknown
		//IL_0e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5c: Expected Obj, but got Unknown
		//IL_0e5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Expected Obj, but got Unknown
		//IL_0e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e72: Expected Obj, but got Unknown
		//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7d: Expected Obj, but got Unknown
		//IL_0e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Expected Obj, but got Unknown
		//IL_0e89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e93: Expected Obj, but got Unknown
		//IL_0e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9e: Expected Obj, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Expected Obj, but got Unknown
		//IL_0eaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb4: Expected Obj, but got Unknown
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Expected Obj, but got Unknown
		//IL_0ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Expected Obj, but got Unknown
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed5: Expected Obj, but got Unknown
		//IL_0ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee0: Expected Obj, but got Unknown
		//IL_0ee1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Expected Obj, but got Unknown
		//IL_0eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Expected Obj, but got Unknown
		//IL_0ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f01: Expected Obj, but got Unknown
		//IL_0f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0c: Expected Obj, but got Unknown
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Expected Obj, but got Unknown
		//IL_0f18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f22: Expected Obj, but got Unknown
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2d: Expected Obj, but got Unknown
		//IL_0f2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f38: Expected Obj, but got Unknown
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Expected Obj, but got Unknown
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4e: Expected Obj, but got Unknown
		//IL_0f4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f59: Expected Obj, but got Unknown
		//IL_0f5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Expected Obj, but got Unknown
		//IL_0f65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6f: Expected Obj, but got Unknown
		//IL_0f70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7a: Expected Obj, but got Unknown
		//IL_0f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f85: Expected Obj, but got Unknown
		//IL_0f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f90: Expected Obj, but got Unknown
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9b: Expected Obj, but got Unknown
		//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa6: Expected Obj, but got Unknown
		//IL_0fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Expected Obj, but got Unknown
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Expected Obj, but got Unknown
		//IL_0fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Expected Obj, but got Unknown
		//IL_0fc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd2: Expected Obj, but got Unknown
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Expected Obj, but got Unknown
		//IL_0fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe8: Expected Obj, but got Unknown
		//IL_0fe9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff3: Expected Obj, but got Unknown
		//IL_0ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffe: Expected Obj, but got Unknown
		//IL_0fff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1009: Expected Obj, but got Unknown
		//IL_100a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1014: Expected Obj, but got Unknown
		//IL_1015: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Expected Obj, but got Unknown
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_102a: Expected Obj, but got Unknown
		//IL_102b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1035: Expected Obj, but got Unknown
		//IL_1036: Unknown result type (might be due to invalid IL or missing references)
		//IL_1040: Expected Obj, but got Unknown
		//IL_1041: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Expected Obj, but got Unknown
		//IL_104c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1056: Expected Obj, but got Unknown
		//IL_1057: Unknown result type (might be due to invalid IL or missing references)
		//IL_1061: Expected Obj, but got Unknown
		//IL_1062: Unknown result type (might be due to invalid IL or missing references)
		//IL_106c: Expected Obj, but got Unknown
		//IL_106d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1077: Expected Obj, but got Unknown
		//IL_1078: Unknown result type (might be due to invalid IL or missing references)
		//IL_1082: Expected Obj, but got Unknown
		//IL_1083: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Expected Obj, but got Unknown
		//IL_108e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1098: Expected Obj, but got Unknown
		//IL_1099: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Expected Obj, but got Unknown
		//IL_10a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ae: Expected Obj, but got Unknown
		//IL_10af: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b9: Expected Obj, but got Unknown
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c4: Expected Obj, but got Unknown
		//IL_10c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cf: Expected Obj, but got Unknown
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected Obj, but got Unknown
		//IL_10db: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e5: Expected Obj, but got Unknown
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f0: Expected Obj, but got Unknown
		//IL_10f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fb: Expected Obj, but got Unknown
		//IL_10fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1106: Expected Obj, but got Unknown
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_1111: Expected Obj, but got Unknown
		//IL_1112: Unknown result type (might be due to invalid IL or missing references)
		//IL_111c: Expected Obj, but got Unknown
		//IL_111d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Expected Obj, but got Unknown
		//IL_1128: Unknown result type (might be due to invalid IL or missing references)
		//IL_1132: Expected Obj, but got Unknown
		//IL_1133: Unknown result type (might be due to invalid IL or missing references)
		//IL_113d: Expected Obj, but got Unknown
		//IL_113e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1148: Expected Obj, but got Unknown
		//IL_1149: Unknown result type (might be due to invalid IL or missing references)
		//IL_1153: Expected Obj, but got Unknown
		//IL_115f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1169: Expected Obj, but got Unknown
		//IL_116a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1174: Expected Obj, but got Unknown
		//IL_1175: Unknown result type (might be due to invalid IL or missing references)
		//IL_117f: Expected Obj, but got Unknown
		//IL_1180: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Expected Obj, but got Unknown
		//IL_118b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1195: Expected Obj, but got Unknown
		//IL_1196: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a0: Expected Obj, but got Unknown
		//IL_11a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ab: Expected Obj, but got Unknown
		//IL_11ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b6: Expected Obj, but got Unknown
		//IL_11b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Expected Obj, but got Unknown
		//IL_11c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cc: Expected Obj, but got Unknown
		//IL_11cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d7: Expected Obj, but got Unknown
		//IL_11d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e2: Expected Obj, but got Unknown
		//IL_11e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ed: Expected Obj, but got Unknown
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f8: Expected Obj, but got Unknown
		//IL_11f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Expected Obj, but got Unknown
		//IL_1204: Unknown result type (might be due to invalid IL or missing references)
		//IL_120e: Expected Obj, but got Unknown
		//IL_120f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1219: Expected Obj, but got Unknown
		//IL_121a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1224: Expected Obj, but got Unknown
		//IL_1225: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Expected Obj, but got Unknown
		//IL_1230: Unknown result type (might be due to invalid IL or missing references)
		//IL_123a: Expected Obj, but got Unknown
		//IL_123b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Expected Obj, but got Unknown
		//IL_1246: Unknown result type (might be due to invalid IL or missing references)
		//IL_1250: Expected Obj, but got Unknown
		//IL_1251: Unknown result type (might be due to invalid IL or missing references)
		//IL_125b: Expected Obj, but got Unknown
		//IL_125c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1266: Expected Obj, but got Unknown
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Expected Obj, but got Unknown
		//IL_1272: Unknown result type (might be due to invalid IL or missing references)
		//IL_127c: Expected Obj, but got Unknown
		//IL_127d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1287: Expected Obj, but got Unknown
		//IL_1288: Unknown result type (might be due to invalid IL or missing references)
		//IL_1292: Expected Obj, but got Unknown
		//IL_1293: Unknown result type (might be due to invalid IL or missing references)
		//IL_129d: Expected Obj, but got Unknown
		//IL_129e: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a8: Expected Obj, but got Unknown
		//IL_12a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Expected Obj, but got Unknown
		//IL_12b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12be: Expected Obj, but got Unknown
		//IL_12bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c9: Expected Obj, but got Unknown
		//IL_12ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d4: Expected Obj, but got Unknown
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12df: Expected Obj, but got Unknown
		//IL_12e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ea: Expected Obj, but got Unknown
		//IL_12eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f5: Expected Obj, but got Unknown
		//IL_12f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Expected Obj, but got Unknown
		//IL_1301: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Expected Obj, but got Unknown
		//IL_130c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1316: Expected Obj, but got Unknown
		//IL_1317: Unknown result type (might be due to invalid IL or missing references)
		//IL_1321: Expected Obj, but got Unknown
		//IL_1322: Unknown result type (might be due to invalid IL or missing references)
		//IL_132c: Expected Obj, but got Unknown
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Expected Obj, but got Unknown
		//IL_1338: Unknown result type (might be due to invalid IL or missing references)
		//IL_1342: Expected Obj, but got Unknown
		//IL_1343: Unknown result type (might be due to invalid IL or missing references)
		//IL_134d: Expected Obj, but got Unknown
		//IL_134e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1358: Expected Obj, but got Unknown
		//IL_135f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1369: Expected Obj, but got Unknown
		//IL_136a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1374: Expected Obj, but got Unknown
		//IL_1375: Unknown result type (might be due to invalid IL or missing references)
		//IL_137f: Expected Obj, but got Unknown
		//IL_1380: Unknown result type (might be due to invalid IL or missing references)
		//IL_138a: Expected Obj, but got Unknown
		//IL_138b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1395: Expected Obj, but got Unknown
		//IL_1396: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a0: Expected Obj, but got Unknown
		//IL_13a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b1: Expected Obj, but got Unknown
		//IL_13b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bc: Expected Obj, but got Unknown
		//IL_13bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c7: Expected Obj, but got Unknown
		//IL_13c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d2: Expected Obj, but got Unknown
		//IL_13d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dd: Expected Obj, but got Unknown
		//IL_13de: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e8: Expected Obj, but got Unknown
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f3: Expected Obj, but got Unknown
		//IL_13f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fe: Expected Obj, but got Unknown
		//IL_13ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1409: Expected Obj, but got Unknown
		//IL_140a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1414: Expected Obj, but got Unknown
		//IL_1415: Unknown result type (might be due to invalid IL or missing references)
		//IL_141f: Expected Obj, but got Unknown
		//IL_1420: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Expected Obj, but got Unknown
		//IL_142b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1435: Expected Obj, but got Unknown
		//IL_1436: Unknown result type (might be due to invalid IL or missing references)
		//IL_1440: Expected Obj, but got Unknown
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_144b: Expected Obj, but got Unknown
		//IL_144c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1456: Expected Obj, but got Unknown
		//IL_1457: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Expected Obj, but got Unknown
		//IL_1462: Unknown result type (might be due to invalid IL or missing references)
		//IL_146c: Expected Obj, but got Unknown
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1477: Expected Obj, but got Unknown
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_1482: Expected Obj, but got Unknown
		//IL_1483: Unknown result type (might be due to invalid IL or missing references)
		//IL_148d: Expected Obj, but got Unknown
		//IL_148e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1498: Expected Obj, but got Unknown
		//IL_149f: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a9: Expected Obj, but got Unknown
		//IL_14aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b4: Expected Obj, but got Unknown
		//IL_14b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bf: Expected Obj, but got Unknown
		//IL_14c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ca: Expected Obj, but got Unknown
		//IL_14cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Expected Obj, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e0: Expected Obj, but got Unknown
		//IL_14e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14eb: Expected Obj, but got Unknown
		//IL_14ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f6: Expected Obj, but got Unknown
		//IL_14f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1501: Expected Obj, but got Unknown
		//IL_1502: Unknown result type (might be due to invalid IL or missing references)
		//IL_150c: Expected Obj, but got Unknown
		//IL_150d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1517: Expected Obj, but got Unknown
		//IL_1518: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Expected Obj, but got Unknown
		//IL_1523: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Expected Obj, but got Unknown
		//IL_152e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1538: Expected Obj, but got Unknown
		//IL_1539: Unknown result type (might be due to invalid IL or missing references)
		//IL_1543: Expected Obj, but got Unknown
		//IL_1544: Unknown result type (might be due to invalid IL or missing references)
		//IL_154e: Expected Obj, but got Unknown
		//IL_154f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Expected Obj, but got Unknown
		//IL_155a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1564: Expected Obj, but got Unknown
		//IL_1565: Unknown result type (might be due to invalid IL or missing references)
		//IL_156f: Expected Obj, but got Unknown
		//IL_1570: Unknown result type (might be due to invalid IL or missing references)
		//IL_157a: Expected Obj, but got Unknown
		//IL_157b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1585: Expected Obj, but got Unknown
		//IL_1586: Unknown result type (might be due to invalid IL or missing references)
		//IL_1590: Expected Obj, but got Unknown
		//IL_1591: Unknown result type (might be due to invalid IL or missing references)
		//IL_159b: Expected Obj, but got Unknown
		//IL_159c: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a6: Expected Obj, but got Unknown
		//IL_15a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Expected Obj, but got Unknown
		//IL_15b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Expected Obj, but got Unknown
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Expected Obj, but got Unknown
		//IL_15c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d2: Expected Obj, but got Unknown
		//IL_15d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15dd: Expected Obj, but got Unknown
		//IL_15de: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e8: Expected Obj, but got Unknown
		//IL_15e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f3: Expected Obj, but got Unknown
		//IL_15f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fe: Expected Obj, but got Unknown
		//IL_15ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1609: Expected Obj, but got Unknown
		//IL_160a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1614: Expected Obj, but got Unknown
		//IL_1615: Unknown result type (might be due to invalid IL or missing references)
		//IL_161f: Expected Obj, but got Unknown
		//IL_1620: Unknown result type (might be due to invalid IL or missing references)
		//IL_162a: Expected Obj, but got Unknown
		//IL_162b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1635: Expected Obj, but got Unknown
		//IL_1636: Unknown result type (might be due to invalid IL or missing references)
		//IL_1640: Expected Obj, but got Unknown
		//IL_1641: Unknown result type (might be due to invalid IL or missing references)
		//IL_164b: Expected Obj, but got Unknown
		//IL_164c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1656: Expected Obj, but got Unknown
		//IL_1657: Unknown result type (might be due to invalid IL or missing references)
		//IL_1661: Expected Obj, but got Unknown
		//IL_1662: Unknown result type (might be due to invalid IL or missing references)
		//IL_166c: Expected Obj, but got Unknown
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1677: Expected Obj, but got Unknown
		//IL_1678: Unknown result type (might be due to invalid IL or missing references)
		//IL_1682: Expected Obj, but got Unknown
		//IL_1683: Unknown result type (might be due to invalid IL or missing references)
		//IL_168d: Expected Obj, but got Unknown
		//IL_168e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1698: Expected Obj, but got Unknown
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a3: Expected Obj, but got Unknown
		//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ae: Expected Obj, but got Unknown
		//IL_16af: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b9: Expected Obj, but got Unknown
		//IL_16ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c4: Expected Obj, but got Unknown
		//IL_16c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cf: Expected Obj, but got Unknown
		//IL_16d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16da: Expected Obj, but got Unknown
		//IL_16db: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e5: Expected Obj, but got Unknown
		//IL_16e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f0: Expected Obj, but got Unknown
		//IL_16f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fb: Expected Obj, but got Unknown
		//IL_16fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1706: Expected Obj, but got Unknown
		//IL_1707: Unknown result type (might be due to invalid IL or missing references)
		//IL_1711: Expected Obj, but got Unknown
		//IL_1712: Unknown result type (might be due to invalid IL or missing references)
		//IL_171c: Expected Obj, but got Unknown
		//IL_171d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1727: Expected Obj, but got Unknown
		//IL_1728: Unknown result type (might be due to invalid IL or missing references)
		//IL_1732: Expected Obj, but got Unknown
		//IL_1733: Unknown result type (might be due to invalid IL or missing references)
		//IL_173d: Expected Obj, but got Unknown
		//IL_173e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1748: Expected Obj, but got Unknown
		//IL_1749: Unknown result type (might be due to invalid IL or missing references)
		//IL_1753: Expected Obj, but got Unknown
		//IL_1754: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Expected Obj, but got Unknown
		//IL_175f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1769: Expected Obj, but got Unknown
		//IL_176a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Expected Obj, but got Unknown
		//IL_1775: Unknown result type (might be due to invalid IL or missing references)
		//IL_177f: Expected Obj, but got Unknown
		//IL_1780: Unknown result type (might be due to invalid IL or missing references)
		//IL_178a: Expected Obj, but got Unknown
		//IL_178b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1795: Expected Obj, but got Unknown
		//IL_1796: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a0: Expected Obj, but got Unknown
		//IL_17a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ab: Expected Obj, but got Unknown
		//IL_17ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b6: Expected Obj, but got Unknown
		//IL_17b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c1: Expected Obj, but got Unknown
		//IL_17c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cc: Expected Obj, but got Unknown
		//IL_17cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d7: Expected Obj, but got Unknown
		//IL_17d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e2: Expected Obj, but got Unknown
		//IL_17e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ed: Expected Obj, but got Unknown
		//IL_17ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f8: Expected Obj, but got Unknown
		//IL_17f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1803: Expected Obj, but got Unknown
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_180e: Expected Obj, but got Unknown
		//IL_180f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1819: Expected Obj, but got Unknown
		//IL_181a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1824: Expected Obj, but got Unknown
		//IL_1825: Unknown result type (might be due to invalid IL or missing references)
		//IL_182f: Expected Obj, but got Unknown
		//IL_1830: Unknown result type (might be due to invalid IL or missing references)
		//IL_183a: Expected Obj, but got Unknown
		//IL_183b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1845: Expected Obj, but got Unknown
		//IL_1846: Unknown result type (might be due to invalid IL or missing references)
		//IL_1850: Expected Obj, but got Unknown
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Expected Obj, but got Unknown
		//IL_185c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1866: Expected Obj, but got Unknown
		//IL_1867: Unknown result type (might be due to invalid IL or missing references)
		//IL_1871: Expected Obj, but got Unknown
		//IL_1872: Unknown result type (might be due to invalid IL or missing references)
		//IL_187c: Expected Obj, but got Unknown
		//IL_187d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1887: Expected Obj, but got Unknown
		//IL_1888: Unknown result type (might be due to invalid IL or missing references)
		//IL_1892: Expected Obj, but got Unknown
		//IL_189e: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a8: Expected Obj, but got Unknown
		//IL_18a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b3: Expected Obj, but got Unknown
		//IL_18b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18be: Expected Obj, but got Unknown
		//IL_18bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c9: Expected Obj, but got Unknown
		//IL_18ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d4: Expected Obj, but got Unknown
		//IL_18db: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e5: Expected Obj, but got Unknown
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f0: Expected Obj, but got Unknown
		//IL_18fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1901: Expected Obj, but got Unknown
		//IL_1901: Unknown result type (might be due to invalid IL or missing references)
		//IL_1907: Expected Obj, but got Unknown
		//IL_2123: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_21db: Expected Obj, but got Unknown
		//IL_224f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2259: Expected Obj, but got Unknown
		//IL_22f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b1: Expected Obj, but got Unknown
		//IL_2422: Unknown result type (might be due to invalid IL or missing references)
		//IL_242c: Expected Obj, but got Unknown
		//IL_2e64: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e6e: Expected Obj, but got Unknown
		//IL_4699: Unknown result type (might be due to invalid IL or missing references)
		//IL_5289: Unknown result type (might be due to invalid IL or missing references)
		//IL_5293: Expected Obj, but got Unknown
		//IL_58cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_58d6: Expected Obj, but got Unknown
		//IL_590b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5915: Expected Obj, but got Unknown
		//IL_5b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b83: Expected Obj, but got Unknown
		//IL_5c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f81: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f8b: Expected Obj, but got Unknown
		//IL_6191: Unknown result type (might be due to invalid IL or missing references)
		//IL_619b: Expected Obj, but got Unknown
		//IL_622f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6239: Expected Obj, but got Unknown
		//IL_62c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_62ce: Expected Obj, but got Unknown
		//IL_6372: Unknown result type (might be due to invalid IL or missing references)
		//IL_637c: Expected Obj, but got Unknown
		//IL_6804: Unknown result type (might be due to invalid IL or missing references)
		//IL_680e: Expected Obj, but got Unknown
		//IL_6955: Unknown result type (might be due to invalid IL or missing references)
		//IL_695f: Expected Obj, but got Unknown
		//IL_6b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b34: Expected Obj, but got Unknown
		//IL_6b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b50: Expected Obj, but got Unknown
		//IL_6c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c7b: Expected Obj, but got Unknown
		//IL_6cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ce9: Expected Obj, but got Unknown
		//IL_6e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e89: Expected Obj, but got Unknown
		//IL_6f4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f58: Expected Obj, but got Unknown
		//IL_705d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7067: Expected Obj, but got Unknown
		//IL_7079: Unknown result type (might be due to invalid IL or missing references)
		//IL_7083: Expected Obj, but got Unknown
		//IL_7095: Unknown result type (might be due to invalid IL or missing references)
		//IL_709f: Expected Obj, but got Unknown
		//IL_70b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_70bb: Expected Obj, but got Unknown
		//IL_75f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_7603: Expected Obj, but got Unknown
		//IL_7615: Unknown result type (might be due to invalid IL or missing references)
		//IL_761f: Expected Obj, but got Unknown
		//IL_7631: Unknown result type (might be due to invalid IL or missing references)
		//IL_763b: Expected Obj, but got Unknown
		//IL_764d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7657: Expected Obj, but got Unknown
		//IL_7669: Unknown result type (might be due to invalid IL or missing references)
		//IL_7673: Expected Obj, but got Unknown
		//IL_7685: Unknown result type (might be due to invalid IL or missing references)
		//IL_768f: Expected Obj, but got Unknown
		//IL_76a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_76ab: Expected Obj, but got Unknown
		//IL_76bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_76c7: Expected Obj, but got Unknown
		//IL_76d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_76e3: Expected Obj, but got Unknown
		//IL_76f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_76ff: Expected Obj, but got Unknown
		//IL_7711: Unknown result type (might be due to invalid IL or missing references)
		//IL_771b: Expected Obj, but got Unknown
		//IL_772d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7737: Expected Obj, but got Unknown
		//IL_7749: Unknown result type (might be due to invalid IL or missing references)
		//IL_7753: Expected Obj, but got Unknown
		//IL_7fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7fe0: Expected Obj, but got Unknown
		//IL_80e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_80eb: Expected Obj, but got Unknown
		//IL_8365: Unknown result type (might be due to invalid IL or missing references)
		//IL_836f: Expected Obj, but got Unknown
		//IL_8404: Unknown result type (might be due to invalid IL or missing references)
		//IL_840e: Expected Obj, but got Unknown
		//IL_9194: Unknown result type (might be due to invalid IL or missing references)
		//IL_919e: Expected Obj, but got Unknown
		//IL_98c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_98d1: Expected Obj, but got Unknown
		//IL_9a1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_9a27: Expected Obj, but got Unknown
		//IL_9b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b1c: Expected Obj, but got Unknown
		//IL_9b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b33: Expected Obj, but got Unknown
		//IL_9b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c76: Expected Obj, but got Unknown
		//IL_9ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_9cf1: Expected Obj, but got Unknown
		//IL_a002: Unknown result type (might be due to invalid IL or missing references)
		//IL_a06c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a076: Expected Obj, but got Unknown
		//IL_a3ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3f8: Expected Obj, but got Unknown
		//IL_a4d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4df: Expected Obj, but got Unknown
		//IL_a4ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4f6: Expected Obj, but got Unknown
		//IL_a571: Unknown result type (might be due to invalid IL or missing references)
		//IL_a57b: Expected Obj, but got Unknown
		//IL_a665: Unknown result type (might be due to invalid IL or missing references)
		//IL_a66f: Expected Obj, but got Unknown
		//IL_aa60: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa6a: Expected Obj, but got Unknown
		//IL_aa77: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa81: Expected Obj, but got Unknown
		//IL_ad25: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad99: Expected Obj, but got Unknown
		//IL_b40c: Unknown result type (might be due to invalid IL or missing references)
		//IL_b4d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_b4e3: Expected Obj, but got Unknown
		//IL_b68d: Unknown result type (might be due to invalid IL or missing references)
		//IL_b697: Expected Obj, but got Unknown
		//IL_b9b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9c1: Expected Obj, but got Unknown
		//IL_babe: Unknown result type (might be due to invalid IL or missing references)
		//IL_bac8: Expected Obj, but got Unknown
		//IL_bafd: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb07: Expected Obj, but got Unknown
		//IL_bda1: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdab: Expected Obj, but got Unknown
		//IL_bdb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdc2: Expected Obj, but got Unknown
		//IL_bdcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdd9: Expected Obj, but got Unknown
		//IL_cc6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc76: Expected Obj, but got Unknown
		//IL_cea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf11: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf1b: Expected Obj, but got Unknown
		//IL_d58f: Unknown result type (might be due to invalid IL or missing references)
		//IL_e0a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_e0af: Expected Obj, but got Unknown
		//IL_e123: Unknown result type (might be due to invalid IL or missing references)
		//IL_e12d: Expected Obj, but got Unknown
		//IL_e1eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_e2ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_e2b7: Expected Obj, but got Unknown
		//IL_e32b: Unknown result type (might be due to invalid IL or missing references)
		//IL_e335: Expected Obj, but got Unknown
		//IL_e3c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_e5bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_e5c7: Expected Obj, but got Unknown
		//IL_e64f: Unknown result type (might be due to invalid IL or missing references)
		//IL_e659: Expected Obj, but got Unknown
		//IL_e6f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_e6fa: Expected Obj, but got Unknown
		//IL_e7bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7c9: Expected Obj, but got Unknown
		//IL_e7d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7e0: Expected Obj, but got Unknown
		//IL_ea4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_eca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_ecb3: Expected Obj, but got Unknown
		//IL_ed35: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed3f: Expected Obj, but got Unknown
		//IL_ee5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee68: Expected Obj, but got Unknown
		//IL_efd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_efdf: Expected Obj, but got Unknown
		//IL_f277: Unknown result type (might be due to invalid IL or missing references)
		//IL_f281: Expected Obj, but got Unknown
		//IL_f28e: Unknown result type (might be due to invalid IL or missing references)
		//IL_f298: Expected Obj, but got Unknown
		//IL_f488: Unknown result type (might be due to invalid IL or missing references)
		//IL_f492: Expected Obj, but got Unknown
		//IL_f53d: Unknown result type (might be due to invalid IL or missing references)
		//IL_f5a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_f5b1: Expected Obj, but got Unknown
		//IL_fc0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe55: Expected Obj, but got Unknown
		//IL_fe62: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe6c: Expected Obj, but got Unknown
		//IL_fe79: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe83: Expected Obj, but got Unknown
		//IL_fe90: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe9a: Expected Obj, but got Unknown
		//IL_fea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_feb1: Expected Obj, but got Unknown
		//IL_1008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10094: Expected Obj, but got Unknown
		//IL_102f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10369: Expected Obj, but got Unknown
		//IL_10df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e03: Expected Obj, but got Unknown
		//IL_10e7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e87: Expected Obj, but got Unknown
		//IL_10f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f11: Expected Obj, but got Unknown
		//IL_10fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fc7: Expected Obj, but got Unknown
		//IL_10fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fde: Expected Obj, but got Unknown
		//IL_10feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ff5: Expected Obj, but got Unknown
		//IL_11019: Unknown result type (might be due to invalid IL or missing references)
		//IL_11023: Expected Obj, but got Unknown
		//IL_1120e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11218: Expected Obj, but got Unknown
		//IL_11225: Unknown result type (might be due to invalid IL or missing references)
		//IL_1122f: Expected Obj, but got Unknown
		//IL_1123c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11246: Expected Obj, but got Unknown
		//IL_11253: Unknown result type (might be due to invalid IL or missing references)
		//IL_1125d: Expected Obj, but got Unknown
		//IL_1126a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11274: Expected Obj, but got Unknown
		//IL_1141a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11424: Expected Obj, but got Unknown
		//IL_1151d: Unknown result type (might be due to invalid IL or missing references)
		//IL_11527: Expected Obj, but got Unknown
		//IL_11814: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181e: Expected Obj, but got Unknown
		//IL_11853: Unknown result type (might be due to invalid IL or missing references)
		//IL_1185d: Expected Obj, but got Unknown
		//IL_11906: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f45: Expected Obj, but got Unknown
		//IL_11fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12162: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216c: Expected Obj, but got Unknown
		//IL_1220e: Unknown result type (might be due to invalid IL or missing references)
		//IL_12218: Expected Obj, but got Unknown
		//IL_122a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_122ae: Expected Obj, but got Unknown
		//IL_12349: Unknown result type (might be due to invalid IL or missing references)
		//IL_12353: Expected Obj, but got Unknown
		//IL_1264c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0a: Expected Obj, but got Unknown
		//IL_12edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ee6: Expected Obj, but got Unknown
		//IL_12f8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13002: Expected Obj, but got Unknown
		//IL_13631: Unknown result type (might be due to invalid IL or missing references)
		//IL_13959: Unknown result type (might be due to invalid IL or missing references)
		//IL_13963: Expected Obj, but got Unknown
		//IL_13c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c0e: Expected Obj, but got Unknown
		//IL_13c1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c25: Expected Obj, but got Unknown
		//IL_13e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e17: Expected Obj, but got Unknown
		//IL_13e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e2e: Expected Obj, but got Unknown
		//IL_13e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e45: Expected Obj, but got Unknown
		//IL_13e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e5c: Expected Obj, but got Unknown
		//IL_13e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e73: Expected Obj, but got Unknown
		//IL_1425c: Unknown result type (might be due to invalid IL or missing references)
		//IL_14266: Expected Obj, but got Unknown
		//IL_14273: Unknown result type (might be due to invalid IL or missing references)
		//IL_1427d: Expected Obj, but got Unknown
		//IL_1428a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14294: Expected Obj, but got Unknown
		//IL_142a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_142ab: Expected Obj, but got Unknown
		//IL_142b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_142c2: Expected Obj, but got Unknown
		//IL_1447d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14487: Expected Obj, but got Unknown
		//IL_14692: Unknown result type (might be due to invalid IL or missing references)
		//IL_1469c: Expected Obj, but got Unknown
		//IL_14727: Unknown result type (might be due to invalid IL or missing references)
		//IL_14731: Expected Obj, but got Unknown
		//IL_14762: Unknown result type (might be due to invalid IL or missing references)
		//IL_1476c: Expected Obj, but got Unknown
		//IL_147aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_147b4: Expected Obj, but got Unknown
		this.m_k = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		DataGridViewCellStyle val16 = new DataGridViewCellStyle();
		CharacterActions = new ActionControl();
		this.m_fj = new Label();
		this.m_fa = new PictureBox();
		TimerActions = new ActionControl();
		this.m_f6 = new Label();
		this.m_f7 = new PictureBox();
		this.m_c5 = new ContextMenuStrip(this.m_k);
		this.m_c6 = new ToolStripMenuItem();
		this.m_c7 = new ToolStripMenuItem();
		this.m_c2 = new ContextMenuStrip(this.m_k);
		this.m_c3 = new ToolStripMenuItem();
		this.m_c4 = new ToolStripMenuItem();
		this.m_f = new OpenFileDialog();
		this.m_g = new SaveFileDialog();
		this.m_o = new OpenFileDialog();
		this.m_p = new ContextMenu();
		this.m_q = new MenuItem();
		this.m_r = new MenuItem();
		hm = new MenuItem();
		nt = new MenuItem();
		nu = new MenuItem();
		nv = new MenuItem();
		nw = new MenuItem();
		iv = new MenuItem();
		iw = new MenuItem();
		i1 = new MenuItem();
		i2 = new MenuItem();
		this.m_ee = new ContextMenuStrip(this.m_k);
		this.m_ef = new ToolStripMenuItem();
		this.m_eg = new ToolStripMenuItem();
		nx = new ToolStripSeparator();
		np = new ToolStripMenuItem();
		nq = new ToolStripMenuItem();
		ny = new ToolStripSeparator();
		i4 = new ToolStripMenuItem();
		j1 = new ToolStripMenuItem();
		this.m_gu = new ContextMenuStrip(this.m_k);
		this.m_gv = new ToolStripMenuItem();
		this.m_gw = new ToolStripMenuItem();
		hj = new ContextMenuStrip(this.m_k);
		hk = new ToolStripMenuItem();
		hl = new ToolStripMenuItem();
		hn = new ToolStripMenuItem();
		j0 = new ToolStripMenuItem();
		this.m_b0 = new ContextMenuStrip(this.m_k);
		this.m_b1 = new ToolStripMenuItem();
		this.m_b2 = new ToolStripMenuItem();
		this.m_eb = new ContextMenuStrip(this.m_k);
		this.m_ec = new ToolStripMenuItem();
		this.m_ed = new ToolStripMenuItem();
		this.m_dc = new ContextMenuStrip(this.m_k);
		this.m_da = new ToolStripMenuItem();
		this.m_db = new ToolStripMenuItem();
		this.m_cr = new ContextMenuStrip(this.m_k);
		this.m_cs = new ToolStripMenuItem();
		this.m_ct = new ToolStripMenuItem();
		this.m_gf = new ContextMenuStrip(this.m_k);
		this.m_gg = new ToolStripMenuItem();
		this.m_gh = new ToolStripMenuItem();
		this.m_ce = new ContextMenuStrip(this.m_k);
		this.m_cf = new ToolStripMenuItem();
		this.m_cg = new ToolStripMenuItem();
		this.m_cd = new ContextMenuStrip(this.m_k);
		this.m_ch = new ToolStripMenuItem();
		this.m_ci = new ToolStripMenuItem();
		this.m_b3 = new MenuStrip();
		this.m_b4 = new ToolStripMenuItem();
		g3 = new ToolStripMenuItem();
		this.m_b5 = new ToolStripMenuItem();
		this.m_b6 = new ToolStripMenuItem();
		this.m_b7 = new ToolStripMenuItem();
		no = new ToolStripMenuItem();
		nh = new ToolStripSeparator();
		ng = new ToolStripMenuItem();
		ni = new ToolStripMenuItem();
		nj = new ToolStripSeparator();
		@is = new ToolStripMenuItem();
		ir = new ToolStripMenuItem();
		this.m_b8 = new ToolStripMenuItem();
		this.m_gz = new ToolStripMenuItem();
		this.m_g0 = new ToolStripMenuItem();
		this.m_g1 = new ToolStripMenuItem();
		g4 = new ToolStripMenuItem();
		this.m_g2 = new ToolStripMenuItem();
		nk = new ToolStripSeparator();
		g5 = new ToolStripMenuItem();
		ol = new ToolStripMenuItem();
		nl = new ToolStripSeparator();
		ii = new ToolStripMenuItem();
		i0 = new ToolStripMenuItem();
		i5 = new ToolStripMenuItem();
		jb = new ToolStripMenuItem();
		kj = new ToolStripMenuItem();
		ih = new ToolStripMenuItem();
		mq = new ToolStripMenuItem();
		n0 = new ToolStripMenuItem();
		om = new ToolStripMenuItem();
		n1 = new ToolStripMenuItem();
		this.m_fl = new ToolStripMenuItem();
		this.m_fm = new ToolStripMenuItem();
		this.m_fy = new ToolStripMenuItem();
		this.m_gj = new ToolStripMenuItem();
		ix = new ToolStripMenuItem();
		this.m_b9 = new ContextMenuStrip(this.m_k);
		this.m_gi = new Timer(this.m_k);
		hw = new FontDialog();
		it = new SaveFileDialog();
		iu = new OpenFileDialog();
		this.m_er = new SplitContainer();
		tabControl1 = new TabControl();
		this.m_s = new TabPage();
		j9 = new TabControl();
		ka = new TabPage();
		n3 = new GroupBox();
		n6 = new Label();
		n7 = new ComboBox();
		n8 = new Label();
		n9 = new ComboBox();
		n4 = new Label();
		n5 = new ComboBox();
		n2 = new CheckBox();
		m3 = new ComboBox();
		m4 = new CheckBox();
		m2 = new Label();
		this.m_gn = new GroupBox();
		ob = new CheckBox();
		j8 = new Button();
		j7 = new Button();
		this.m_go = new Label();
		this.m_gp = new Button();
		this.m_gl = new Label();
		this.m_gq = new Button();
		this.m_gr = new TextBox();
		this.m_gs = new TextBox();
		this.m_gt = new Label();
		this.m_gk = new Label();
		this.m_gm = new ListBox();
		ht = new Button();
		j3 = new GroupBox();
		j4 = new CheckBox();
		j5 = new CheckBox();
		j6 = new CheckBox();
		hu = new TextBox();
		this.m_u = new Label();
		hv = new Label();
		this.m_t = new TextBox();
		this.m_e1 = new PictureBox();
		this.m_em = new CheckBox();
		this.m_ek = new Label();
		this.m_w = new Label();
		this.m_el = new TextBox();
		this.m_v = new TextBox();
		kb = new TabPage();
		kf = new Label();
		kg = new TextBox();
		kh = new Label();
		ki = new TextBox();
		kd = new Label();
		ke = new TextBox();
		kc = new PictureBox();
		this.m_x = new TabPage();
		ij = new SplitContainer();
		dgvRoomList = new DataGridView();
		ik = new DataGridViewTextBoxColumn();
		this.m_bc = new Button();
		tabControl2 = new TabControl();
		this.m_y = new TabPage();
		jy = new ComboBox();
		jz = new Label();
		tbRoomID = new TextBox();
		ja = new Label();
		this.m_e2 = new PictureBox();
		txtRoomName = new TextBox();
		txtRoomSDesc = new TextBox();
		this.m_z = new Label();
		this.m_aa = new Label();
		this.m_en = new SplitContainer();
		this.m_ab = new Label();
		txtRoomDescription = new TextBox();
		ou = new AxWindowsMediaPlayer();
		this.m_ep = new Label();
		this.m_eq = new ComboBox();
		this.m_eo = new PictureBox();
		this.m_ac = new TabPage();
		this.m_ff = new Label();
		this.m_fe = new GroupBox();
		this.m_fh = new TableLayoutPanel();
		id = new CheckBox();
		ie = new Label();
		@if = new ComboBox();
		ig = new ComboBox();
		h9 = new Label();
		ia = new CheckBox();
		this.m_fo = new ComboBox();
		this.m_fp = new ComboBox();
		this.m_fq = new ComboBox();
		this.m_fr = new ComboBox();
		this.m_fs = new ComboBox();
		this.m_ft = new ComboBox();
		this.m_fu = new ComboBox();
		this.m_fv = new ComboBox();
		this.m_fw = new ComboBox();
		this.m_fx = new ComboBox();
		this.m_fn = new Label();
		this.m_ad = new CheckBox();
		this.m_a8 = new Label();
		this.m_a7 = new ComboBox();
		this.m_av = new Label();
		this.m_ag = new ComboBox();
		this.m_af = new CheckBox();
		this.m_a6 = new Label();
		this.m_fi = new Label();
		this.m_aw = new Label();
		this.m_ai = new ComboBox();
		this.m_ah = new CheckBox();
		this.m_a3 = new Label();
		this.m_a2 = new Label();
		this.m_ax = new Label();
		this.m_ak = new ComboBox();
		this.m_aj = new CheckBox();
		this.m_a1 = new Label();
		this.m_a0 = new Label();
		this.m_ay = new Label();
		this.m_al = new CheckBox();
		this.m_am = new ComboBox();
		this.m_az = new Label();
		this.m_a4 = new Label();
		this.m_a5 = new CheckBox();
		this.m_at = new CheckBox();
		this.m_au = new ComboBox();
		this.m_ar = new CheckBox();
		this.m_an = new CheckBox();
		this.m_ao = new ComboBox();
		this.m_as = new ComboBox();
		this.m_ap = new CheckBox();
		this.m_aq = new ComboBox();
		this.m_ae = new ComboBox();
		ib = new ComboBox();
		ic = new ComboBox();
		this.m_e3 = new PictureBox();
		this.m_a9 = new TabPage();
		kl = new GroupBox();
		kr = new Label();
		ks = new TextBox();
		kt = new Label();
		ku = new TextBox();
		kq = new Button();
		km = new Button();
		kn = new Button();
		kk = new DataGridView();
		ko = new DataGridViewTextBoxColumn();
		kp = new DataGridViewTextBoxColumn();
		this.m_fg = new Label();
		this.m_bz = new Button();
		this.m_ba = new Label();
		this.m_e4 = new PictureBox();
		this.m_bb = new ListBox();
		this.m_d7 = new TabPage();
		RoomActions = new ActionControl();
		this.m_fd = new Label();
		this.m_e5 = new PictureBox();
		this.m_bd = new TabPage();
		tabControl4 = new TabControl();
		this.m_eu = new TabPage();
		this.m_e6 = new PictureBox();
		this.m_ev = new Label();
		this.m_ew = new TextBox();
		this.m_ex = new CheckBox();
		this.m_es = new SplitContainer();
		this.m_d9 = new Label();
		this.m_d8 = new TextBox();
		this.m_eh = new Panel();
		this.m_bf = new ComboBox();
		this.m_bg = new Label();
		this.m_be = new PictureBox();
		this.m_ea = new Button();
		this.m_bj = new GroupBox();
		this.m_bk = new RadioButton();
		this.m_bl = new RadioButton();
		this.m_bm = new RadioButton();
		this.m_ca = new Button();
		this.m_bi = new ComboBox();
		this.m_cc = new ListBox();
		this.m_bo = new CheckBox();
		this.m_cb = new Label();
		this.m_bh = new Label();
		this.m_bq = new Label();
		this.m_bp = new TextBox();
		this.m_bn = new CheckBox();
		kv = new TabPage();
		mc = new PictureBox();
		kw = new GroupBox();
		kx = new Label();
		ky = new TextBox();
		kz = new Label();
		k0 = new TextBox();
		k1 = new Button();
		k2 = new Button();
		k3 = new Button();
		k4 = new DataGridView();
		k5 = new DataGridViewTextBoxColumn();
		k6 = new DataGridViewTextBoxColumn();
		this.m_et = new TabPage();
		PlayerActions = new ActionControl();
		this.m_e7 = new PictureBox();
		this.m_br = new TabPage();
		tabControl3 = new TabControl();
		this.m_dh = new TabPage();
		i8 = new TextBox();
		i9 = new Label();
		h5 = new TextBox();
		h6 = new Label();
		this.m_d1 = new TextBox();
		this.m_e8 = new PictureBox();
		this.m_ej = new Button();
		this.m_ei = new Button();
		this.m_di = new Label();
		this.m_dj = new ListBox();
		this.m_dk = new GroupBox();
		oa = new CheckBox();
		hg = new GroupBox();
		hh = new RadioButton();
		hi = new RadioButton();
		g6 = new CheckBox();
		this.m_ey = new GroupBox();
		this.m_ez = new RadioButton();
		this.m_e0 = new RadioButton();
		this.m_dl = new GroupBox();
		this.m_dm = new RadioButton();
		this.m_dn = new RadioButton();
		this.m_do = new GroupBox();
		this.m_dp = new RadioButton();
		this.m_dq = new RadioButton();
		this.m_dr = new TextBox();
		this.m_ds = new Label();
		this.m_dt = new CheckBox();
		this.m_du = new CheckBox();
		this.m_dv = new CheckBox();
		this.m_dw = new CheckBox();
		this.m_dx = new CheckBox();
		this.m_dy = new CheckBox();
		this.m_dz = new TextBox();
		this.m_d0 = new Label();
		this.m_d2 = new Label();
		this.m_d3 = new TextBox();
		this.m_d4 = new Label();
		this.m_d5 = new Button();
		k7 = new TabPage();
		lv = new PictureBox();
		k8 = new GroupBox();
		k9 = new Label();
		la = new TextBox();
		lb = new Label();
		lc = new TextBox();
		ld = new Button();
		le = new Button();
		lf = new Button();
		lg = new DataGridView();
		lh = new DataGridViewTextBoxColumn();
		li = new DataGridViewTextBoxColumn();
		jc = new TabPage();
		jd = new Panel();
		jx = new Label();
		jw = new PictureBox();
		jv = new Label();
		ju = new RichTextBox();
		jq = new GroupBox();
		jr = new Button();
		js = new Button();
		ji = new ListBox();
		jh = new Label();
		jj = new GroupBox();
		jk = new Button();
		jl = new Button();
		jm = new Label();
		jn = new ComboBox();
		jo = new Label();
		jp = new ComboBox();
		jt = new ListBox();
		jg = new Label();
		je = new Label();
		jf = new PictureBox();
		this.m_d6 = new TabPage();
		ObjectActions = new ActionControl();
		this.m_fk = new Label();
		this.m_e9 = new PictureBox();
		this.m_cu = new TabPage();
		il = new SplitContainer();
		hs = new Button();
		dgvCharacters = new DataGridView();
		im = new DataGridViewTextBoxColumn();
		tabControlCharData = new TabControl();
		this.m_cv = new TabPage();
		oo = new Panel();
		op = new ComboBox();
		oq = new Label();
		or = new PictureBox();
		tbCharacterNameOverride = new TextBox();
		mr = new Label();
		h7 = new CheckBox();
		this.m_fb = new PictureBox();
		this.m_dg = new Label();
		this.m_df = new TextBox();
		this.m_dd = new ComboBox();
		this.m_de = new Label();
		this.m_c9 = new Button();
		this.m_cw = new Label();
		this.m_cx = new ListBox();
		this.m_c8 = new GroupBox();
		this.m_cy = new RadioButton();
		this.m_cz = new RadioButton();
		this.m_c0 = new RadioButton();
		this.m_c1 = new Label();
		lj = new TabPage();
		lw = new PictureBox();
		lk = new GroupBox();
		ll = new Label();
		lm = new TextBox();
		ln = new Label();
		lo = new TextBox();
		lp = new Button();
		lq = new Button();
		lr = new Button();
		ls = new DataGridView();
		lt = new DataGridViewTextBoxColumn();
		lu = new DataGridViewTextBoxColumn();
		this.m_cj = new TabPage();
		@in = new SplitContainer();
		oi = new Label();
		tvVariables = new TreeView();
		oc = new ContextMenuStrip(this.m_k);
		od = new ToolStripMenuItem();
		oe = new ToolStripMenuItem();
		of = new ToolStripSeparator();
		og = new ToolStripMenuItem();
		oh = new ToolStripMenuItem();
		ns = new ImageList(this.m_k);
		this.m_cn = new Button();
		lx = new TabControl();
		ly = new TabPage();
		this.m_co = new Label();
		i6 = new GroupBox();
		i7 = new TextBox();
		this.m_ck = new GroupBox();
		hx = new RadioButton();
		hy = new RadioButton();
		hz = new RadioButton();
		this.m_gy = new RadioButton();
		this.m_cl = new RadioButton();
		this.m_cm = new RadioButton();
		this.m_cp = new GroupBox();
		h1 = new GroupBox();
		iz = new CheckBox();
		h8 = new Button();
		h4 = new Label();
		h2 = new Button();
		h0 = new Button();
		iy = new DataGridView();
		ms = new ContextMenuStrip(this.m_k);
		mt = new ToolStripMenuItem();
		oj = new ToolStripMenuItem();
		ok = new ToolStripMenuItem();
		h3 = new ListBox();
		g7 = new GroupBox();
		hr = new CheckBox();
		g8 = new TextBox();
		g9 = new Label();
		ha = new TextBox();
		hb = new Label();
		hd = new Label();
		hc = new TextBox();
		this.m_gx = new DateTimePicker();
		this.m_cq = new RichTextBox();
		this.m_fc = new PictureBox();
		lz = new TabPage();
		l0 = new GroupBox();
		l1 = new Label();
		l2 = new TextBox();
		l3 = new Label();
		l4 = new TextBox();
		l5 = new Button();
		l6 = new Button();
		l7 = new Button();
		l8 = new DataGridView();
		l9 = new DataGridViewTextBoxColumn();
		ma = new DataGridViewTextBoxColumn();
		mb = new PictureBox();
		this.m_fz = new TabPage();
		io = new SplitContainer();
		dgvTimers = new DataGridView();
		ip = new DataGridViewTextBoxColumn();
		iq = new DataGridViewTextBoxColumn();
		this.m_f9 = new Button();
		this.m_f8 = new Label();
		tabControl5 = new TabControl();
		this.m_f0 = new TabPage();
		mu = new GroupBox();
		mw = new NumericUpDown();
		mx = new CheckBox();
		mv = new Label();
		hq = new GroupBox();
		ho = new Label();
		hp = new NumericUpDown();
		this.m_ga = new CheckBox();
		this.m_gb = new GroupBox();
		this.m_gc = new CheckBox();
		this.m_gd = new TextBox();
		this.m_ge = new Label();
		this.m_f1 = new PictureBox();
		this.m_f2 = new GroupBox();
		this.m_f3 = new RadioButton();
		this.m_f4 = new RadioButton();
		this.m_f5 = new Label();
		md = new TabPage();
		me = new PictureBox();
		mf = new GroupBox();
		mg = new Label();
		mh = new TextBox();
		mi = new Label();
		mj = new TextBox();
		mk = new Button();
		ml = new Button();
		mm = new Button();
		mn = new DataGridView();
		mo = new DataGridViewTextBoxColumn();
		mp = new DataGridViewTextBoxColumn();
		m5 = new TabPage();
		m6 = new SplitContainer();
		m7 = new DataGridView();
		m8 = new DataGridViewTextBoxColumn();
		m9 = new SplitContainer();
		na = new PictureBox();
		nb = new GroupBox();
		nd = new Button();
		ne = new Button();
		nf = new Button();
		nc = new ListBox();
		this.m_bs = new Panel();
		this.m_bt = new Panel();
		tvItems = new TreeView();
		he = new CheckBox();
		this.m_bu = new Label();
		this.m_bv = new Splitter();
		mz = new Panel();
		m0 = new SplitContainer();
		this.m_bx = new Panel();
		nr = new TreeView();
		hf = new CheckBox();
		this.m_by = new Label();
		my = new Panel();
		ot = new AxWindowsMediaPlayer();
		this.m_bw = new PictureBox();
		m1 = new Splitter();
		j2 = new SaveFileDialog();
		nm = new SaveFileDialog();
		nn = new OpenFileDialog();
		on = new Timer(this.m_k);
		os = new FolderBrowserDialog();
		ov = new AxWindowsMediaPlayer();
		TabPage val17 = new TabPage();
		TabPage val18 = new TabPage();
		((Control)val17).SuspendLayout();
		((ISupportInitialize)this.m_fa).BeginInit();
		((Control)val18).SuspendLayout();
		((ISupportInitialize)this.m_f7).BeginInit();
		((Control)this.m_c5).SuspendLayout();
		((Control)this.m_c2).SuspendLayout();
		((Control)this.m_ee).SuspendLayout();
		((Control)this.m_gu).SuspendLayout();
		((Control)hj).SuspendLayout();
		((Control)this.m_b0).SuspendLayout();
		((Control)this.m_eb).SuspendLayout();
		((Control)this.m_dc).SuspendLayout();
		((Control)this.m_cr).SuspendLayout();
		((Control)this.m_gf).SuspendLayout();
		((Control)this.m_ce).SuspendLayout();
		((Control)this.m_cd).SuspendLayout();
		((Control)this.m_b3).SuspendLayout();
		((ISupportInitialize)this.m_er).BeginInit();
		((Control)this.m_er.Panel1).SuspendLayout();
		((Control)this.m_er.Panel2).SuspendLayout();
		((Control)this.m_er).SuspendLayout();
		((Control)tabControl1).SuspendLayout();
		((Control)this.m_s).SuspendLayout();
		((Control)j9).SuspendLayout();
		((Control)ka).SuspendLayout();
		((Control)n3).SuspendLayout();
		((Control)this.m_gn).SuspendLayout();
		((Control)j3).SuspendLayout();
		((ISupportInitialize)this.m_e1).BeginInit();
		((Control)kb).SuspendLayout();
		((ISupportInitialize)kc).BeginInit();
		((Control)this.m_x).SuspendLayout();
		((ISupportInitialize)ij).BeginInit();
		((Control)ij.Panel1).SuspendLayout();
		((Control)ij.Panel2).SuspendLayout();
		((Control)ij).SuspendLayout();
		((ISupportInitialize)dgvRoomList).BeginInit();
		((Control)tabControl2).SuspendLayout();
		((Control)this.m_y).SuspendLayout();
		((ISupportInitialize)this.m_e2).BeginInit();
		((ISupportInitialize)this.m_en).BeginInit();
		((Control)this.m_en.Panel1).SuspendLayout();
		((Control)this.m_en.Panel2).SuspendLayout();
		((Control)this.m_en).SuspendLayout();
		((ISupportInitialize)ou).BeginInit();
		((ISupportInitialize)this.m_eo).BeginInit();
		((Control)this.m_ac).SuspendLayout();
		((Control)this.m_fe).SuspendLayout();
		((Control)this.m_fh).SuspendLayout();
		((ISupportInitialize)this.m_e3).BeginInit();
		((Control)this.m_a9).SuspendLayout();
		((Control)kl).SuspendLayout();
		((ISupportInitialize)kk).BeginInit();
		((ISupportInitialize)this.m_e4).BeginInit();
		((Control)this.m_d7).SuspendLayout();
		((ISupportInitialize)this.m_e5).BeginInit();
		((Control)this.m_bd).SuspendLayout();
		((Control)tabControl4).SuspendLayout();
		((Control)this.m_eu).SuspendLayout();
		((ISupportInitialize)this.m_e6).BeginInit();
		((ISupportInitialize)this.m_es).BeginInit();
		((Control)this.m_es.Panel1).SuspendLayout();
		((Control)this.m_es.Panel2).SuspendLayout();
		((Control)this.m_es).SuspendLayout();
		((Control)this.m_eh).SuspendLayout();
		((ISupportInitialize)this.m_be).BeginInit();
		((Control)this.m_bj).SuspendLayout();
		((Control)kv).SuspendLayout();
		((ISupportInitialize)mc).BeginInit();
		((Control)kw).SuspendLayout();
		((ISupportInitialize)k4).BeginInit();
		((Control)this.m_et).SuspendLayout();
		((ISupportInitialize)this.m_e7).BeginInit();
		((Control)this.m_br).SuspendLayout();
		((Control)tabControl3).SuspendLayout();
		((Control)this.m_dh).SuspendLayout();
		((ISupportInitialize)this.m_e8).BeginInit();
		((Control)this.m_dk).SuspendLayout();
		((Control)hg).SuspendLayout();
		((Control)this.m_ey).SuspendLayout();
		((Control)this.m_dl).SuspendLayout();
		((Control)this.m_do).SuspendLayout();
		((Control)k7).SuspendLayout();
		((ISupportInitialize)lv).BeginInit();
		((Control)k8).SuspendLayout();
		((ISupportInitialize)lg).BeginInit();
		((Control)jc).SuspendLayout();
		((Control)jd).SuspendLayout();
		((ISupportInitialize)jw).BeginInit();
		((Control)jq).SuspendLayout();
		((Control)jj).SuspendLayout();
		((ISupportInitialize)jf).BeginInit();
		((Control)this.m_d6).SuspendLayout();
		((ISupportInitialize)this.m_e9).BeginInit();
		((Control)this.m_cu).SuspendLayout();
		((ISupportInitialize)il).BeginInit();
		((Control)il.Panel1).SuspendLayout();
		((Control)il.Panel2).SuspendLayout();
		((Control)il).SuspendLayout();
		((ISupportInitialize)dgvCharacters).BeginInit();
		((Control)tabControlCharData).SuspendLayout();
		((Control)this.m_cv).SuspendLayout();
		((Control)oo).SuspendLayout();
		((ISupportInitialize)or).BeginInit();
		((ISupportInitialize)this.m_fb).BeginInit();
		((Control)this.m_c8).SuspendLayout();
		((Control)lj).SuspendLayout();
		((ISupportInitialize)lw).BeginInit();
		((Control)lk).SuspendLayout();
		((ISupportInitialize)ls).BeginInit();
		((Control)this.m_cj).SuspendLayout();
		((ISupportInitialize)@in).BeginInit();
		((Control)@in.Panel1).SuspendLayout();
		((Control)@in.Panel2).SuspendLayout();
		((Control)@in).SuspendLayout();
		((Control)oc).SuspendLayout();
		((Control)lx).SuspendLayout();
		((Control)ly).SuspendLayout();
		((Control)i6).SuspendLayout();
		((Control)this.m_ck).SuspendLayout();
		((Control)this.m_cp).SuspendLayout();
		((Control)h1).SuspendLayout();
		((ISupportInitialize)iy).BeginInit();
		((Control)ms).SuspendLayout();
		((Control)g7).SuspendLayout();
		((ISupportInitialize)this.m_fc).BeginInit();
		((Control)lz).SuspendLayout();
		((Control)l0).SuspendLayout();
		((ISupportInitialize)l8).BeginInit();
		((ISupportInitialize)mb).BeginInit();
		((Control)this.m_fz).SuspendLayout();
		((ISupportInitialize)io).BeginInit();
		((Control)io.Panel1).SuspendLayout();
		((Control)io.Panel2).SuspendLayout();
		((Control)io).SuspendLayout();
		((ISupportInitialize)dgvTimers).BeginInit();
		((Control)tabControl5).SuspendLayout();
		((Control)this.m_f0).SuspendLayout();
		((Control)mu).SuspendLayout();
		((ISupportInitialize)mw).BeginInit();
		((Control)hq).SuspendLayout();
		((ISupportInitialize)hp).BeginInit();
		((Control)this.m_gb).SuspendLayout();
		((ISupportInitialize)this.m_f1).BeginInit();
		((Control)this.m_f2).SuspendLayout();
		((Control)md).SuspendLayout();
		((ISupportInitialize)me).BeginInit();
		((Control)mf).SuspendLayout();
		((ISupportInitialize)mn).BeginInit();
		((Control)m5).SuspendLayout();
		((ISupportInitialize)m6).BeginInit();
		((Control)m6.Panel1).SuspendLayout();
		((Control)m6.Panel2).SuspendLayout();
		((Control)m6).SuspendLayout();
		((ISupportInitialize)m7).BeginInit();
		((ISupportInitialize)m9).BeginInit();
		((Control)m9.Panel1).SuspendLayout();
		((Control)m9.Panel2).SuspendLayout();
		((Control)m9).SuspendLayout();
		((ISupportInitialize)na).BeginInit();
		((Control)nb).SuspendLayout();
		((Control)this.m_bs).SuspendLayout();
		((Control)this.m_bt).SuspendLayout();
		((Control)mz).SuspendLayout();
		((ISupportInitialize)m0).BeginInit();
		((Control)m0.Panel1).SuspendLayout();
		((Control)m0.Panel2).SuspendLayout();
		((Control)m0).SuspendLayout();
		((Control)this.m_bx).SuspendLayout();
		((Control)my).SuspendLayout();
		((ISupportInitialize)ot).BeginInit();
		((ISupportInitialize)this.m_bw).BeginInit();
		((ISupportInitialize)ov).BeginInit();
		((Control)this).SuspendLayout();
		((Control)val17).Controls.Add((Control)(object)CharacterActions);
		((Control)val17).Controls.Add((Control)(object)this.m_fj);
		((Control)val17).Controls.Add((Control)(object)this.m_fa);
		val17.Location = new Point(4, 4);
		((Control)val17).Name = "tabPageCharActions";
		((Control)val17).Padding = new Padding(3);
		((Control)val17).Size = new Size(522, 524);
		val17.TabIndex = 1;
		((Control)val17).Text = "Actions";
		val17.UseVisualStyleBackColor = true;
		((Control)CharacterActions).Anchor = (AnchorStyles)15;
		((Control)CharacterActions).Location = new Point(7, 39);
		((Control)CharacterActions).Name = "CharacterActions";
		((Control)CharacterActions).Size = new Size(512, 479);
		((Control)CharacterActions).TabIndex = 105;
		((Control)this.m_fj).AutoSize = true;
		((Control)this.m_fj).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fj).Location = new Point(3, 0);
		((Control)this.m_fj).Name = "lblCharName2";
		((Control)this.m_fj).Size = new Size(161, 24);
		((Control)this.m_fj).TabIndex = 104;
		((Control)this.m_fj).Text = "Character Name";
		((Control)this.m_fa).Anchor = (AnchorStyles)9;
		this.m_fa.Image = (Image)componentResourceManager.GetObject("pictureBox11.Image");
		((Control)this.m_fa).Location = new Point(422, 3);
		((Control)this.m_fa).Name = "pictureBox11";
		((Control)this.m_fa).Size = new Size(100, 30);
		this.m_fa.TabIndex = 103;
		this.m_fa.TabStop = false;
		((Control)val18).Controls.Add((Control)(object)TimerActions);
		((Control)val18).Controls.Add((Control)(object)this.m_f6);
		((Control)val18).Controls.Add((Control)(object)this.m_f7);
		val18.Location = new Point(4, 4);
		((Control)val18).Name = "tabPage13";
		((Control)val18).Padding = new Padding(3);
		((Control)val18).Size = new Size(499, 524);
		val18.TabIndex = 1;
		((Control)val18).Text = "Actions";
		val18.UseVisualStyleBackColor = true;
		((Control)TimerActions).Anchor = (AnchorStyles)15;
		((Control)TimerActions).Location = new Point(7, 39);
		((Control)TimerActions).Name = "TimerActions";
		((Control)TimerActions).Size = new Size(486, 479);
		((Control)TimerActions).TabIndex = 105;
		((Control)this.m_f6).AutoSize = true;
		((Control)this.m_f6).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_f6).Location = new Point(3, 0);
		((Control)this.m_f6).Name = "lbTimerActionName";
		((Control)this.m_f6).Size = new Size(125, 24);
		((Control)this.m_f6).TabIndex = 104;
		((Control)this.m_f6).Text = "Timer Name";
		((Control)this.m_f7).Anchor = (AnchorStyles)9;
		this.m_f7.Image = (Image)componentResourceManager.GetObject("pictureBox14.Image");
		((Control)this.m_f7).Location = new Point(399, 3);
		((Control)this.m_f7).Name = "pictureBox14";
		((Control)this.m_f7).Size = new Size(100, 30);
		this.m_f7.TabIndex = 103;
		this.m_f7.TabStop = false;
		((ToolStrip)this.m_c5).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_c6,
			(ToolStripItem)this.m_c7
		});
		((Control)this.m_c5).Name = "cntxFailCommands";
		((Control)this.m_c5).Size = new Size(168, 48);
		((ToolStripItem)this.m_c6).Name = "toolStripMenuItem3";
		((ToolStripItem)this.m_c6).Size = new Size(167, 22);
		((ToolStripItem)this.m_c6).Text = "Add Command";
		((ToolStripItem)this.m_c7).Name = "toolStripMenuItem4";
		((ToolStripItem)this.m_c7).Size = new Size(167, 22);
		((ToolStripItem)this.m_c7).Text = "Delete Command";
		((ToolStrip)this.m_c2).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_c3,
			(ToolStripItem)this.m_c4
		});
		((Control)this.m_c2).Name = "cntxPassCommands";
		((Control)this.m_c2).Size = new Size(168, 48);
		((ToolStripItem)this.m_c3).Name = "toolStripMenuItem1";
		((ToolStripItem)this.m_c3).Size = new Size(167, 22);
		((ToolStripItem)this.m_c3).Text = "Add Command";
		((ToolStripItem)this.m_c4).Name = "toolStripMenuItem2";
		((ToolStripItem)this.m_c4).Size = new Size(167, 22);
		((ToolStripItem)this.m_c4).Text = "Delete Command";
		((FileDialog)this.m_f).DefaultExt = "*.rag";
		((FileDialog)this.m_f).Filter = "Rag Files|*.rag|All files|*.*";
		((FileDialog)this.m_f).Title = "Open A Rags Game";
		((FileDialog)this.m_g).DefaultExt = "*.rag";
		((FileDialog)this.m_g).Filter = "Rag Files|*.rag|All files|*.*";
		((FileDialog)this.m_o).DefaultExt = "*.*";
		((FileDialog)this.m_o).Filter = "All Files|*.*";
		this.m_o.Multiselect = true;
		((FileDialog)this.m_o).Title = "Load Multimedia";
		((Menu)this.m_p).MenuItems.AddRange(new MenuItem[11]
		{
			this.m_q, this.m_r, hm, nt, nu, nv, nw, iv, iw, i1,
			i2
		});
		this.m_p.Popup += ca;
		this.m_q.Index = 0;
		this.m_q.Text = "&Add";
		this.m_q.Click += ft;
		this.m_r.Index = 1;
		this.m_r.Text = "&Delete";
		this.m_r.Click += ek;
		hm.Index = 2;
		hm.Text = "&Rename";
		hm.Click += cy;
		nt.Index = 3;
		nt.Text = "-";
		nu.Index = 4;
		nu.Text = "Add Group";
		nu.Click += v;
		nv.Index = 5;
		nv.Text = "Remove Group";
		nv.Click += u;
		nw.Index = 6;
		nw.Text = "-";
		iv.Index = 7;
		iv.Text = "&Copy";
		iv.Click += b8;
		iw.Index = 8;
		iw.Text = "&Paste";
		iw.Click += b9;
		i1.Index = 9;
		i1.Text = "Add To &Library";
		i1.Click += b4;
		i2.Index = 10;
		i2.Text = "Insert From Library";
		i2.Click += b3;
		((ToolStrip)this.m_ee).Items.AddRange(new ToolStripItem[8]
		{
			(ToolStripItem)this.m_ef,
			(ToolStripItem)this.m_eg,
			(ToolStripItem)nx,
			(ToolStripItem)np,
			(ToolStripItem)nq,
			(ToolStripItem)ny,
			(ToolStripItem)i4,
			(ToolStripItem)j1
		});
		((Control)this.m_ee).Name = "cntxPictureMenu";
		((Control)this.m_ee).Size = new Size(154, 148);
		((ToolStripDropDown)this.m_ee).Opening += c;
		((ToolStripItem)this.m_ef).Name = "addToolStripMenuItem1";
		((ToolStripItem)this.m_ef).Size = new Size(153, 22);
		((ToolStripItem)this.m_ef).Text = "&Add";
		((ToolStripItem)this.m_ef).Click += gs;
		((ToolStripItem)this.m_eg).Name = "deleteToolStripMenuItem1";
		((ToolStripItem)this.m_eg).Size = new Size(153, 22);
		((ToolStripItem)this.m_eg).Text = "&Delete";
		((ToolStripItem)this.m_eg).Click += gr;
		((ToolStripItem)nx).Name = "toolStripSeparator5";
		((ToolStripItem)nx).Size = new Size(150, 6);
		((ToolStripItem)np).Name = "addGroupToolStripMenuItem";
		((ToolStripItem)np).Size = new Size(153, 22);
		((ToolStripItem)np).Text = "Add Group";
		((ToolStripItem)np).Click += x;
		((ToolStripItem)nq).Name = "removeGroupToolStripMenuItem";
		((ToolStripItem)nq).Size = new Size(153, 22);
		((ToolStripItem)nq).Text = "Remove Group";
		((ToolStripItem)nq).Click += w;
		((ToolStripItem)ny).Name = "toolStripSeparator6";
		((ToolStripItem)ny).Size = new Size(150, 6);
		((ToolStripItem)i4).Name = "adjustQualityToolStripMenuItem";
		((ToolStripItem)i4).Size = new Size(153, 22);
		((ToolStripItem)i4).Text = "Adjust Quality";
		((ToolStripItem)i4).Click += b2;
		((ToolStripItem)j1).Name = "saveToDiskToolStripMenuItem";
		((ToolStripItem)j1).Size = new Size(153, 22);
		((ToolStripItem)j1).Text = "&Save To Disk";
		((ToolStripItem)j1).Click += br;
		((ToolStrip)this.m_gu).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_gv,
			(ToolStripItem)this.m_gw
		});
		((Control)this.m_gu).Name = "StatusBarItemsMenu";
		((Control)this.m_gu).Size = new Size(108, 48);
		((ToolStripItem)this.m_gv).Name = "addToolStripMenuItem2";
		((ToolStripItem)this.m_gv).Size = new Size(107, 22);
		((ToolStripItem)this.m_gv).Text = "Add";
		((ToolStripItem)this.m_gv).Click += @do;
		((ToolStripItem)this.m_gw).Name = "deleteToolStripMenuItem2";
		((ToolStripItem)this.m_gw).Size = new Size(107, 22);
		((ToolStripItem)this.m_gw).Text = "Delete";
		((ToolStripItem)this.m_gw).Click += dn;
		((ToolStrip)hj).Items.AddRange(new ToolStripItem[4]
		{
			(ToolStripItem)hk,
			(ToolStripItem)hl,
			(ToolStripItem)hn,
			(ToolStripItem)j0
		});
		((Control)hj).Name = "contextMnuRoom";
		((Control)hj).Size = new Size(181, 92);
		((ToolStripDropDown)hj).Opening += b;
		((ToolStripItem)hk).Name = "addToolStripMenuItem3";
		((ToolStripItem)hk).Size = new Size(180, 22);
		((ToolStripItem)hk).Text = "&Add";
		((ToolStripItem)hk).Click += gq;
		((ToolStripItem)hl).Name = "deleteToolStripMenuItem3";
		((ToolStripItem)hl).Size = new Size(180, 22);
		((ToolStripItem)hl).Text = "&Delete";
		((ToolStripItem)hl).Click += el;
		((ToolStripItem)hn).Name = "renameToolStripMenuItem";
		((ToolStripItem)hn).Size = new Size(180, 22);
		((ToolStripItem)hn).Text = "&Rename";
		((ToolStripItem)hn).Click += cx;
		((ToolStripItem)j0).Name = "assignRoomGroupToolStripMenuItem";
		((ToolStripItem)j0).Size = new Size(180, 22);
		((ToolStripItem)j0).Text = "Assign Room Group";
		((ToolStripDropDownItem)j0).DropDownItemClicked += a;
		((ToolStrip)this.m_b0).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_b1,
			(ToolStripItem)this.m_b2
		});
		((Control)this.m_b0).Name = "AssignRoomObjectMenu";
		((Control)this.m_b0).Size = new Size(208, 48);
		((ToolStripItem)this.m_b1).Name = "assignSelectedObjectsToolStripMenuItem";
		((ToolStripItem)this.m_b1).Size = new Size(207, 22);
		((ToolStripItem)this.m_b1).Text = "Assign Selected Objects";
		((ToolStripItem)this.m_b1).Click += ff;
		((ToolStripItem)this.m_b2).Name = "removeSelectedObjectsToolStripMenuItem";
		((ToolStripItem)this.m_b2).Size = new Size(207, 22);
		((ToolStripItem)this.m_b2).Text = "Remove Selected Objects";
		((ToolStripItem)this.m_b2).Click += fe;
		((ToolStrip)this.m_eb).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_ec,
			(ToolStripItem)this.m_ed
		});
		((Control)this.m_eb).Name = "AssignRoomObjectMenu";
		((Control)this.m_eb).Size = new Size(208, 48);
		((ToolStripItem)this.m_ec).Name = "toolStripMenuItem7";
		((ToolStripItem)this.m_ec).Size = new Size(207, 22);
		((ToolStripItem)this.m_ec).Text = "Assign Selected Objects";
		((ToolStripItem)this.m_ec).Click += et;
		((ToolStripItem)this.m_ed).Name = "toolStripMenuItem8";
		((ToolStripItem)this.m_ed).Size = new Size(207, 22);
		((ToolStripItem)this.m_ed).Text = "Remove Selected Objects";
		((ToolStripItem)this.m_ed).Click += es;
		((ToolStrip)this.m_dc).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_da,
			(ToolStripItem)this.m_db
		});
		((Control)this.m_dc).Name = "AssignRoomObjectMenu";
		((Control)this.m_dc).Size = new Size(208, 48);
		((ToolStripItem)this.m_da).Name = "toolStripMenuItem5";
		((ToolStripItem)this.m_da).Size = new Size(207, 22);
		((ToolStripItem)this.m_da).Text = "Assign Selected Objects";
		((ToolStripItem)this.m_da).Click += e0;
		((ToolStripItem)this.m_db).Name = "toolStripMenuItem6";
		((ToolStripItem)this.m_db).Size = new Size(207, 22);
		((ToolStripItem)this.m_db).Text = "Remove Selected Objects";
		((ToolStripItem)this.m_db).Click += ez;
		((ToolStrip)this.m_cr).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_cs,
			(ToolStripItem)this.m_ct
		});
		((Control)this.m_cr).Name = "cntVarAddDelete";
		((Control)this.m_cr).Size = new Size(108, 48);
		((ToolStripItem)this.m_cs).Name = "addToolStripMenuItem";
		((ToolStripItem)this.m_cs).Size = new Size(107, 22);
		((ToolStripItem)this.m_cs).Text = "Add";
		((ToolStripItem)this.m_cs).Click += fc;
		((ToolStripItem)this.m_ct).Name = "deleteToolStripMenuItem";
		((ToolStripItem)this.m_ct).Size = new Size(107, 22);
		((ToolStripItem)this.m_ct).Text = "Delete";
		((ToolStripItem)this.m_ct).Click += em;
		((ToolStrip)this.m_gf).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_gg,
			(ToolStripItem)this.m_gh
		});
		((Control)this.m_gf).Name = "cntxPassCommands";
		((Control)this.m_gf).Size = new Size(142, 48);
		((ToolStripItem)this.m_gg).Name = "toolStripMenuItem9";
		((ToolStripItem)this.m_gg).Size = new Size(141, 22);
		((ToolStripItem)this.m_gg).Text = "Add Timer";
		((ToolStripItem)this.m_gg).Click += dx;
		((ToolStripItem)this.m_gh).Name = "toolStripMenuItem10";
		((ToolStripItem)this.m_gh).Size = new Size(141, 22);
		((ToolStripItem)this.m_gh).Text = "Delete Timer";
		((ToolStripItem)this.m_gh).Click += dw;
		((ToolStrip)this.m_ce).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_cf,
			(ToolStripItem)this.m_cg
		});
		((Control)this.m_ce).Name = "cntxFailCommands";
		((Control)this.m_ce).Size = new Size(168, 48);
		((ToolStripItem)this.m_cf).Name = "addCommandToolStripMenuItem";
		((ToolStripItem)this.m_cf).Size = new Size(167, 22);
		((ToolStripItem)this.m_cf).Text = "Add Command";
		((ToolStripItem)this.m_cg).Name = "deleteCommandToolStripMenuItem";
		((ToolStripItem)this.m_cg).Size = new Size(167, 22);
		((ToolStripItem)this.m_cg).Text = "Delete Command";
		((ToolStrip)this.m_cd).Items.AddRange(new ToolStripItem[2]
		{
			(ToolStripItem)this.m_ch,
			(ToolStripItem)this.m_ci
		});
		((Control)this.m_cd).Name = "cntxPassCommands";
		((Control)this.m_cd).Size = new Size(168, 48);
		((ToolStripItem)this.m_ch).Name = "addCommandToolStripMenuItem1";
		((ToolStripItem)this.m_ch).Size = new Size(167, 22);
		((ToolStripItem)this.m_ch).Text = "Add Command";
		((ToolStripItem)this.m_ci).Name = "deleteCommandToolStripMenuItem1";
		((ToolStripItem)this.m_ci).Size = new Size(167, 22);
		((ToolStripItem)this.m_ci).Text = "Delete Command";
		((ToolStrip)this.m_b3).Items.AddRange(new ToolStripItem[3]
		{
			(ToolStripItem)this.m_b4,
			(ToolStripItem)this.m_gz,
			(ToolStripItem)this.m_fl
		});
		((Control)this.m_b3).Location = new Point(0, 0);
		((Control)this.m_b3).Name = "menuStrip1";
		((Control)this.m_b3).Size = new Size(893, 24);
		((Control)this.m_b3).TabIndex = 15;
		((Control)this.m_b3).Text = "menuStrip1";
		((ToolStripDropDownItem)this.m_b4).DropDownItems.AddRange(new ToolStripItem[12]
		{
			(ToolStripItem)g3,
			(ToolStripItem)this.m_b5,
			(ToolStripItem)this.m_b6,
			(ToolStripItem)this.m_b7,
			(ToolStripItem)no,
			(ToolStripItem)nh,
			(ToolStripItem)ng,
			(ToolStripItem)ni,
			(ToolStripItem)nj,
			(ToolStripItem)@is,
			(ToolStripItem)ir,
			(ToolStripItem)this.m_b8
		});
		((ToolStripItem)this.m_b4).Name = "fileToolStripMenuItem";
		((ToolStripItem)this.m_b4).Size = new Size(37, 20);
		((ToolStripItem)this.m_b4).Text = "&File";
		((ToolStripItem)g3).Name = "newToolStripMenuItem";
		((ToolStripItem)g3).Size = new Size(217, 22);
		((ToolStripItem)g3).Text = "&New";
		((ToolStripItem)g3).Click += de;
		((ToolStripItem)this.m_b5).Name = "loadToolStripMenuItem";
		((ToolStripItem)this.m_b5).Size = new Size(217, 22);
		((ToolStripItem)this.m_b5).Text = "&Load";
		((ToolStripItem)this.m_b5).Click += g2;
		((ToolStripItem)this.m_b6).Name = "saveToolStripMenuItem";
		((ToolStripItem)this.m_b6).Size = new Size(217, 22);
		((ToolStripItem)this.m_b6).Text = "&Save";
		((ToolStripItem)this.m_b6).Click += g1;
		((ToolStripItem)this.m_b7).Name = "saveAsToolStripMenuItem";
		((ToolStripItem)this.m_b7).Size = new Size(217, 22);
		((ToolStripItem)this.m_b7).Text = "Save &As";
		((ToolStripItem)this.m_b7).Click += g0;
		((ToolStripItem)no).Name = "saveToWebFormatToolStripMenuItem";
		((ToolStripItem)no).Size = new Size(217, 22);
		((ToolStripItem)no).Text = "Save To Web Format(BETA)";
		((ToolStripItem)no).Click += y;
		((ToolStripItem)nh).Name = "toolStripSeparator1";
		((ToolStripItem)nh).Size = new Size(214, 6);
		((ToolStripItem)ng).Name = "importPackageToolStripMenuItem";
		((ToolStripItem)ng).Size = new Size(217, 22);
		((ToolStripItem)ng).Text = "Import Package";
		((ToolStripItem)ng).Click += z;
		((ToolStripItem)ni).Name = "exportPackageToolStripMenuItem";
		((ToolStripItem)ni).Size = new Size(217, 22);
		((ToolStripItem)ni).Text = "Export Package";
		((ToolStripItem)ni).Click += aa;
		((ToolStripItem)nj).Name = "toolStripSeparator2";
		((ToolStripItem)nj).Size = new Size(214, 6);
		((ToolStripItem)@is).Name = "importXMLToolStripMenuItem";
		((ToolStripItem)@is).Size = new Size(217, 22);
		((ToolStripItem)@is).Text = "Import XML";
		((ToolStripItem)@is).Click += cb;
		((ToolStripItem)ir).Name = "exportXMLToolStripMenuItem";
		((ToolStripItem)ir).Size = new Size(217, 22);
		((ToolStripItem)ir).Text = "Export XML";
		((ToolStripItem)ir).Click += cc;
		((ToolStripItem)this.m_b8).Name = "exitToolStripMenuItem";
		((ToolStripItem)this.m_b8).Size = new Size(217, 22);
		((ToolStripItem)this.m_b8).Text = "E&xit";
		((ToolStripItem)this.m_b8).Click += gt;
		((ToolStripDropDownItem)this.m_gz).DropDownItems.AddRange(new ToolStripItem[18]
		{
			(ToolStripItem)this.m_g0,
			(ToolStripItem)this.m_g1,
			(ToolStripItem)g4,
			(ToolStripItem)this.m_g2,
			(ToolStripItem)nk,
			(ToolStripItem)g5,
			(ToolStripItem)ol,
			(ToolStripItem)nl,
			(ToolStripItem)ii,
			(ToolStripItem)i0,
			(ToolStripItem)i5,
			(ToolStripItem)jb,
			(ToolStripItem)kj,
			(ToolStripItem)ih,
			(ToolStripItem)mq,
			(ToolStripItem)n0,
			(ToolStripItem)om,
			(ToolStripItem)n1
		});
		((ToolStripItem)this.m_gz).Name = "toolsToolStripMenuItem";
		((ToolStripItem)this.m_gz).Size = new Size(47, 20);
		((ToolStripItem)this.m_gz).Text = "&Tools";
		this.m_g0.Checked = true;
		this.m_g0.CheckOnClick = true;
		this.m_g0.CheckState = (CheckState)1;
		((ToolStripItem)this.m_g0).Name = "enableUpgradeNotificationsToolStripMenuItem";
		((ToolStripItem)this.m_g0).Size = new Size(266, 22);
		((ToolStripItem)this.m_g0).Text = "Enable Upgrade Notifications";
		((ToolStripItem)this.m_g0).Click += dj;
		this.m_g1.Checked = true;
		this.m_g1.CheckOnClick = true;
		this.m_g1.CheckState = (CheckState)1;
		((ToolStripItem)this.m_g1).Name = "runGameCheckerAtSaveToolStripMenuItem";
		((ToolStripItem)this.m_g1).Size = new Size(266, 22);
		((ToolStripItem)this.m_g1).Text = "Run Game Checker At Save";
		((ToolStripItem)this.m_g1).Click += dh;
		g4.Checked = true;
		g4.CheckOnClick = true;
		g4.CheckState = (CheckState)1;
		((ToolStripItem)g4).Name = "displayNewGameDialogAtStartupToolStripMenuItem";
		((ToolStripItem)g4).Size = new Size(266, 22);
		((ToolStripItem)g4).Text = "Display New Game Dialog At Startup";
		((ToolStripItem)g4).Click += df;
		((ToolStripItem)this.m_g2).Name = "runGameCheckerNoToolStripMenuItem";
		((ToolStripItem)this.m_g2).Size = new Size(266, 22);
		((ToolStripItem)this.m_g2).Text = "Run Game Checker Now";
		((ToolStripItem)this.m_g2).Click += dg;
		((ToolStripItem)nk).Name = "toolStripSeparator3";
		((ToolStripItem)nk).Size = new Size(263, 6);
		((ToolStripItem)g5).Name = "debugCurrentGameToolStripMenuItem";
		((ToolStripItem)g5).Size = new Size(266, 22);
		((ToolStripItem)g5).Text = "Debug Current Game";
		((ToolStripItem)g5).Click += db;
		((ToolStripItem)ol).Name = "compressGameFileToolStripMenuItem";
		((ToolStripItem)ol).Size = new Size(266, 22);
		((ToolStripItem)ol).Text = "Compact Game File";
		((ToolStripItem)ol).Click += d;
		((ToolStripItem)nl).Name = "toolStripSeparator4";
		((ToolStripItem)nl).Size = new Size(263, 6);
		((ToolStripItem)ii).Name = "resetWindowPositionsToolStripMenuItem";
		((ToolStripItem)ii).Size = new Size(266, 22);
		((ToolStripItem)ii).Text = "Reset Window Positions";
		((ToolStripItem)ii).Click += cd;
		((ToolStripItem)i0).Name = "editQuickCommandsToolStripMenuItem";
		((ToolStripItem)i0).Size = new Size(266, 22);
		((ToolStripItem)i0).Text = "Edit Quick Action Commands";
		((ToolStripItem)i0).Click += b5;
		((ToolStripItem)i5).Name = "editObjectLibraryToolStripMenuItem";
		((ToolStripItem)i5).Size = new Size(266, 22);
		((ToolStripItem)i5).Text = "Edit Object Library";
		((ToolStripItem)i5).Click += b0;
		((ToolStripItem)jb).Name = "adjustPictureQualityToolStripMenuItem";
		((ToolStripItem)jb).Size = new Size(266, 22);
		((ToolStripItem)jb).Text = "Adjust Picture Quality";
		((ToolStripItem)jb).Click += b1;
		((ToolStripItem)kj).Name = "ragsShareToolStripMenuItem";
		((ToolStripItem)kj).Size = new Size(266, 22);
		((ToolStripItem)kj).Text = "Rags Share";
		((ToolStripItem)kj).Visible = false;
		((ToolStripItem)kj).Click += bf;
		((ToolStripItem)ih).Enabled = false;
		((ToolStripItem)ih).Name = "mapDesignerToolStripMenuItem";
		((ToolStripItem)ih).Size = new Size(266, 22);
		((ToolStripItem)ih).Text = "Map Designer";
		((ToolStripItem)ih).Click += ce;
		((ToolStripItem)mq).Name = "testPackageToolStripMenuItem";
		((ToolStripItem)mq).Size = new Size(266, 22);
		((ToolStripItem)mq).Text = "Test Package";
		((ToolStripItem)mq).Visible = false;
		((ToolStripItem)mq).Click += ap;
		((ToolStripItem)n0).Name = "commandConditionFilter";
		((ToolStripItem)n0).Size = new Size(266, 22);
		((ToolStripItem)n0).Text = "Command/Condition Filter";
		((ToolStripItem)n0).Click += r;
		((ToolStripItem)om).Name = "autoSaveSettingsToolStripMenuItem";
		((ToolStripItem)om).Size = new Size(266, 22);
		((ToolStripItem)om).Text = "Auto Save Settings";
		((ToolStripItem)om).Click += c;
		((ToolStripItem)n1).Name = "searchToolStripMenuItem";
		((ToolStripItem)n1).Size = new Size(266, 22);
		((ToolStripItem)n1).Text = "&Search";
		((ToolStripItem)n1).Click += q;
		((ToolStripDropDownItem)this.m_fl).DropDownItems.AddRange(new ToolStripItem[4]
		{
			(ToolStripItem)this.m_fm,
			(ToolStripItem)this.m_fy,
			(ToolStripItem)this.m_gj,
			(ToolStripItem)ix
		});
		((ToolStripItem)this.m_fl).Name = "helpToolStripMenuItem";
		((ToolStripItem)this.m_fl).Size = new Size(44, 20);
		((ToolStripItem)this.m_fl).Text = "&Help";
		((ToolStripItem)this.m_fm).Name = "aboutToolStripMenuItem";
		((ToolStripItem)this.m_fm).Size = new Size(165, 22);
		((ToolStripItem)this.m_fm).Text = "A&bout";
		((ToolStripItem)this.m_fm).Click += ee;
		((ToolStripItem)this.m_fy).Name = "viewOnlineHelpToolStripMenuItem";
		((ToolStripItem)this.m_fy).Size = new Size(165, 22);
		((ToolStripItem)this.m_fy).Text = "&View Online Help";
		((ToolStripItem)this.m_fy).Click += d3;
		((ToolStripItem)this.m_gj).Name = "registerToolStripMenuItem";
		((ToolStripItem)this.m_gj).Size = new Size(165, 22);
		((ToolStripItem)this.m_gj).Text = "&Register";
		((ToolStripItem)this.m_gj).Click += du;
		((ToolStripItem)ix).Name = "shortCutKeysToolStripMenuItem";
		((ToolStripItem)ix).Size = new Size(165, 22);
		((ToolStripItem)ix).Text = "ShortCut Keys";
		((ToolStripItem)ix).Click += b7;
		((Control)this.m_b9).Name = "cmActionsConditions";
		((Control)this.m_b9).Size = new Size(61, 4);
		this.m_gi.Enabled = true;
		this.m_gi.Interval = 30000;
		this.m_gi.Tick += dv;
		((FileDialog)it).DefaultExt = "*.xml";
		((FileDialog)it).Filter = "Xml Files|*.xml|All files|*.*";
		((FileDialog)iu).DefaultExt = "*.xml";
		((FileDialog)iu).Filter = "Xml Files|*.xml|All files|*.*";
		((FileDialog)iu).Title = "Open A Rags Game";
		this.m_er.BorderStyle = (BorderStyle)1;
		this.m_er.Dock = (DockStyle)5;
		((Control)this.m_er).Location = new Point(0, 24);
		((Control)this.m_er).Name = "splitContainer2";
		((Control)this.m_er.Panel1).Controls.Add((Control)(object)tabControl1);
		((Control)this.m_er.Panel2).Controls.Add((Control)(object)this.m_bs);
		((Control)this.m_er).Size = new Size(893, 586);
		this.m_er.SplitterDistance = 689;
		((Control)this.m_er).TabIndex = 16;
		tabControl1.Alignment = (TabAlignment)1;
		((Control)tabControl1).Controls.Add((Control)(object)this.m_s);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_x);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_bd);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_br);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_cu);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_cj);
		((Control)tabControl1).Controls.Add((Control)(object)this.m_fz);
		((Control)tabControl1).Controls.Add((Control)(object)m5);
		((Control)tabControl1).Dock = (DockStyle)5;
		((Control)tabControl1).Location = new Point(0, 0);
		((Control)tabControl1).Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(687, 584);
		((Control)tabControl1).TabIndex = 1;
		((Control)this.m_s).Controls.Add((Control)(object)j9);
		this.m_s.Location = new Point(4, 4);
		((Control)this.m_s).Name = "tabPage1";
		((Control)this.m_s).Size = new Size(679, 558);
		this.m_s.TabIndex = 0;
		((Control)this.m_s).Text = "General";
		this.m_s.UseVisualStyleBackColor = true;
		j9.Alignment = (TabAlignment)1;
		((Control)j9).Controls.Add((Control)(object)ka);
		((Control)j9).Controls.Add((Control)(object)kb);
		((Control)j9).Dock = (DockStyle)5;
		((Control)j9).Location = new Point(0, 0);
		((Control)j9).Name = "tabControl6";
		j9.SelectedIndex = 0;
		((Control)j9).Size = new Size(679, 558);
		((Control)j9).TabIndex = 24;
		((Control)ka).Controls.Add((Control)(object)n3);
		((Control)ka).Controls.Add((Control)(object)n2);
		((Control)ka).Controls.Add((Control)(object)m3);
		((Control)ka).Controls.Add((Control)(object)m4);
		((Control)ka).Controls.Add((Control)(object)m2);
		((Control)ka).Controls.Add((Control)(object)this.m_gn);
		((Control)ka).Controls.Add((Control)(object)ht);
		((Control)ka).Controls.Add((Control)(object)j3);
		((Control)ka).Controls.Add((Control)(object)hu);
		((Control)ka).Controls.Add((Control)(object)this.m_u);
		((Control)ka).Controls.Add((Control)(object)hv);
		((Control)ka).Controls.Add((Control)(object)this.m_t);
		((Control)ka).Controls.Add((Control)(object)this.m_e1);
		((Control)ka).Controls.Add((Control)(object)this.m_em);
		((Control)ka).Controls.Add((Control)(object)this.m_ek);
		((Control)ka).Controls.Add((Control)(object)this.m_w);
		((Control)ka).Controls.Add((Control)(object)this.m_el);
		((Control)ka).Controls.Add((Control)(object)this.m_v);
		ka.Location = new Point(4, 4);
		((Control)ka).Name = "tabPage15";
		((Control)ka).Padding = new Padding(3);
		((Control)ka).Size = new Size(671, 532);
		ka.TabIndex = 0;
		((Control)ka).Text = "Game Setup";
		ka.UseVisualStyleBackColor = true;
		((Control)n3).Anchor = (AnchorStyles)14;
		((Control)n3).Controls.Add((Control)(object)n6);
		((Control)n3).Controls.Add((Control)(object)n7);
		((Control)n3).Controls.Add((Control)(object)n8);
		((Control)n3).Controls.Add((Control)(object)n9);
		((Control)n3).Controls.Add((Control)(object)n4);
		((Control)n3).Controls.Add((Control)(object)n5);
		((Control)n3).Location = new Point(9, 275);
		((Control)n3).Name = "groupBox14";
		((Control)n3).Size = new Size(659, 40);
		((Control)n3).TabIndex = 10;
		n3.TabStop = false;
		((Control)n3).Text = "Default Item Sort Order";
		((Control)n6).AutoSize = true;
		((Control)n6).Location = new Point(494, 17);
		((Control)n6).Name = "label82";
		((Control)n6).Size = new Size(54, 13);
		((Control)n6).TabIndex = 8;
		((Control)n6).Text = "Inventory:";
		n7.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)n7).FormattingEnabled = true;
		n7.Items.AddRange(new object[2] { "Natural", "Alpha" });
		((Control)n7).Location = new Point(566, 14);
		((Control)n7).Name = "cbSortOrderInventory";
		((Control)n7).Size = new Size(72, 21);
		((Control)n7).TabIndex = 2;
		n7.SelectedIndexChanged += m;
		((Control)n8).AutoSize = true;
		((Control)n8).Location = new Point(249, 17);
		((Control)n8).Name = "label63";
		((Control)n8).Size = new Size(61, 13);
		((Control)n8).TabIndex = 6;
		((Control)n8).Text = "Characters:";
		n9.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)n9).FormattingEnabled = true;
		n9.Items.AddRange(new object[2] { "Natural", "Alpha" });
		((Control)n9).Location = new Point(321, 14);
		((Control)n9).Name = "cbSortOrderCharacters";
		((Control)n9).Size = new Size(72, 21);
		((Control)n9).TabIndex = 1;
		n9.SelectedIndexChanged += n;
		((Control)n4).AutoSize = true;
		((Control)n4).Location = new Point(10, 17);
		((Control)n4).Name = "label62";
		((Control)n4).Size = new Size(66, 13);
		((Control)n4).TabIndex = 4;
		((Control)n4).Text = "Room Items:";
		n5.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)n5).FormattingEnabled = true;
		n5.Items.AddRange(new object[2] { "Natural", "Alpha" });
		((Control)n5).Location = new Point(82, 14);
		((Control)n5).Name = "cbSortOrderRoomItem";
		((Control)n5).Size = new Size(72, 21);
		((Control)n5).TabIndex = 0;
		n5.SelectedIndexChanged += o;
		((Control)n2).AutoSize = true;
		((Control)n2).Location = new Point(341, 69);
		((Control)n2).Name = "cbTurnOffNotifications";
		((Control)n2).Size = new Size(172, 17);
		((Control)n2).TabIndex = 5;
		((Control)n2).Text = "Turn Off Notification Messages";
		((ButtonBase)n2).UseVisualStyleBackColor = true;
		n2.CheckedChanged += p;
		m3.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)m3).FormattingEnabled = true;
		((Control)m3).Location = new Point(135, 97);
		((Control)m3).Name = "cbBackGroundMusic";
		((Control)m3).Size = new Size(144, 21);
		((Control)m3).TabIndex = 6;
		m3.SelectedIndexChanged += ah;
		((Control)m4).AutoSize = true;
		((Control)m4).Location = new Point(286, 101);
		((Control)m4).Name = "cbLoopMusic";
		((Control)m4).Size = new Size(81, 17);
		((Control)m4).TabIndex = 7;
		((Control)m4).Text = "Loop Music";
		((ButtonBase)m4).UseVisualStyleBackColor = true;
		m4.CheckedChanged += ag;
		((Control)m2).AutoSize = true;
		((Control)m2).Location = new Point(3, 101);
		((Control)m2).Name = "label81";
		((Control)m2).Size = new Size(126, 13);
		((Control)m2).TabIndex = 24;
		((Control)m2).Text = "Initial Background Music:";
		((Control)this.m_gn).Anchor = (AnchorStyles)14;
		((Control)this.m_gn).Controls.Add((Control)(object)ob);
		((Control)this.m_gn).Controls.Add((Control)(object)j8);
		((Control)this.m_gn).Controls.Add((Control)(object)j7);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_go);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gp);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gl);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gq);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gr);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gs);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gt);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gk);
		((Control)this.m_gn).Controls.Add((Control)(object)this.m_gm);
		((Control)this.m_gn).Location = new Point(6, 321);
		((Control)this.m_gn).Name = "groupBox3";
		((Control)this.m_gn).Size = new Size(659, 205);
		((Control)this.m_gn).TabIndex = 11;
		this.m_gn.TabStop = false;
		((Control)this.m_gn).Text = "Status Bar Items";
		((Control)ob).AutoSize = true;
		((Control)ob).Enabled = false;
		((Control)ob).Location = new Point(12, 98);
		((Control)ob).Name = "cbStatusItemInitiallyVisible";
		((Control)ob).Size = new Size(90, 17);
		((Control)ob).TabIndex = 2;
		((Control)ob).Text = "Initially Visible";
		((ButtonBase)ob).UseVisualStyleBackColor = true;
		ob.CheckedChanged += k;
		((Control)j8).Location = new Point(335, 91);
		((Control)j8).Name = "btnStatusItemUp";
		((Control)j8).Size = new Size(43, 23);
		((Control)j8).TabIndex = 5;
		((Control)j8).Text = "Up";
		((ButtonBase)j8).UseVisualStyleBackColor = true;
		((Control)j8).Click += bk;
		((Control)j7).Location = new Point(335, 129);
		((Control)j7).Name = "btnStatusItemDown";
		((Control)j7).Size = new Size(43, 23);
		((Control)j7).TabIndex = 6;
		((Control)j7).Text = "Down";
		((ButtonBase)j7).UseVisualStyleBackColor = true;
		((Control)j7).Click += bj;
		((Control)this.m_go).Location = new Point(7, 118);
		((Control)this.m_go).Name = "label46";
		((Control)this.m_go).Size = new Size(322, 70);
		((Control)this.m_go).TabIndex = 19;
		((Control)this.m_go).Text = componentResourceManager.GetString("label46.Text");
		((Control)this.m_gp).Enabled = false;
		((Control)this.m_gp).Location = new Point(210, 70);
		((Control)this.m_gp).Name = "btnStatusItemDelete";
		((Control)this.m_gp).Size = new Size(115, 23);
		((Control)this.m_gp).TabIndex = 4;
		((Control)this.m_gp).Text = "Delete Status Item";
		((ButtonBase)this.m_gp).UseVisualStyleBackColor = true;
		((Control)this.m_gp).Click += dr;
		((Control)this.m_gl).AutoSize = true;
		((Control)this.m_gl).Location = new Point(379, 11);
		((Control)this.m_gl).Name = "label43";
		((Control)this.m_gl).Size = new Size(78, 13);
		((Control)this.m_gl).TabIndex = 12;
		((Control)this.m_gl).Text = "StatusBarItems";
		((Control)this.m_gq).Location = new Point(210, 30);
		((Control)this.m_gq).Name = "button2";
		((Control)this.m_gq).Size = new Size(115, 23);
		((Control)this.m_gq).TabIndex = 3;
		((Control)this.m_gq).Text = "Add Status Item";
		((ButtonBase)this.m_gq).UseVisualStyleBackColor = true;
		((Control)this.m_gq).Click += dt;
		((Control)this.m_gr).Enabled = false;
		((Control)this.m_gr).Location = new Point(10, 73);
		((Control)this.m_gr).Name = "tbStatusWidth";
		((Control)this.m_gr).Size = new Size(178, 20);
		((Control)this.m_gr).TabIndex = 1;
		((Control)this.m_gr).Text = "0";
		((Control)this.m_gr).Leave += dp;
		((Control)this.m_gs).Enabled = false;
		((Control)this.m_gs).Location = new Point(10, 33);
		((Control)this.m_gs).Name = "tbStatusText";
		((Control)this.m_gs).Size = new Size(178, 20);
		((Control)this.m_gs).TabIndex = 0;
		((Control)this.m_gs).DoubleClick += ao;
		((Control)this.m_gs).Enter += af;
		((Control)this.m_gs).KeyDown += e;
		((Control)this.m_gs).Leave += dq;
		((Control)this.m_gt).AutoSize = true;
		((Control)this.m_gt).Location = new Point(10, 57);
		((Control)this.m_gt).Name = "label45";
		((Control)this.m_gt).Size = new Size(178, 13);
		((Control)this.m_gt).TabIndex = 14;
		((Control)this.m_gt).Text = "Width in Pixels:(0 = automatic sizing)";
		((Control)this.m_gk).AutoSize = true;
		((Control)this.m_gk).Location = new Point(10, 17);
		((Control)this.m_gk).Name = "label44";
		((Control)this.m_gk).Size = new Size(64, 13);
		((Control)this.m_gk).TabIndex = 13;
		((Control)this.m_gk).Text = "Status Text:";
		((Control)this.m_gm).Anchor = (AnchorStyles)15;
		((Control)this.m_gm).ContextMenuStrip = this.m_gu;
		((ListControl)this.m_gm).FormattingEnabled = true;
		((Control)this.m_gm).Location = new Point(382, 28);
		((Control)this.m_gm).Name = "lbStatusBarItems";
		((Control)this.m_gm).Size = new Size(271, 134);
		((Control)this.m_gm).TabIndex = 7;
		this.m_gm.SelectedIndexChanged += ds;
		((Control)ht).Location = new Point(285, 66);
		((Control)ht).Name = "btnFont";
		((Control)ht).Size = new Size(29, 21);
		((Control)ht).TabIndex = 4;
		((Control)ht).Text = "...";
		((ButtonBase)ht).UseVisualStyleBackColor = true;
		((Control)ht).Click += cr;
		((Control)j3).Anchor = (AnchorStyles)14;
		((Control)j3).Controls.Add((Control)(object)j4);
		((Control)j3).Controls.Add((Control)(object)j5);
		((Control)j3).Controls.Add((Control)(object)j6);
		((Control)j3).Location = new Point(9, 229);
		((Control)j3).Name = "groupBox5";
		((Control)j3).Size = new Size(659, 40);
		((Control)j3).TabIndex = 9;
		j3.TabStop = false;
		((Control)j3).Text = "Player Display Options";
		((Control)j4).Anchor = (AnchorStyles)9;
		((Control)j4).AutoSize = true;
		((Control)j4).Location = new Point(506, 18);
		((Control)j4).Name = "cbHidePortraitDisplay";
		((Control)j4).Size = new Size(121, 17);
		((Control)j4).TabIndex = 2;
		((Control)j4).Text = "Hide Portrait Display";
		((ButtonBase)j4).UseVisualStyleBackColor = true;
		j4.CheckedChanged += bo;
		((Control)j4).Leave += bl;
		((Control)j5).Anchor = (AnchorStyles)1;
		((Control)j5).AutoSize = true;
		((Control)j5).Enabled = false;
		((Control)j5).Location = new Point(256, 18);
		((Control)j5).Name = "cbUseInlineImages";
		((Control)j5).Size = new Size(110, 17);
		((Control)j5).TabIndex = 1;
		((Control)j5).Text = "Use Inline Images";
		((ButtonBase)j5).UseVisualStyleBackColor = true;
		j5.CheckedChanged += bp;
		((Control)j5).Leave += bm;
		((Control)j6).AutoSize = true;
		((Control)j6).Location = new Point(7, 18);
		((Control)j6).Name = "cbHideMainPicDisplay";
		((Control)j6).Size = new Size(147, 17);
		((Control)j6).TabIndex = 0;
		((Control)j6).Text = "Hide Main Picture Display";
		((ButtonBase)j6).UseVisualStyleBackColor = true;
		j6.CheckedChanged += bq;
		((Control)j6).Leave += bn;
		((Control)hu).Location = new Point(135, 66);
		((Control)hu).Name = "tbFont";
		((TextBoxBase)hu).ReadOnly = true;
		((Control)hu).Size = new Size(144, 20);
		((Control)hu).TabIndex = 3;
		((Control)this.m_u).Location = new Point(3, 124);
		((Control)this.m_u).Name = "label4";
		((Control)this.m_u).Size = new Size(64, 66);
		((Control)this.m_u).TabIndex = 5;
		((Control)this.m_u).Text = "Opening Message:";
		((Control)hv).AutoSize = true;
		((Control)hv).Location = new Point(3, 69);
		((Control)hv).Name = "label3";
		((Control)hv).Size = new Size(62, 13);
		((Control)hv).TabIndex = 20;
		((Control)hv).Text = "Game Font:";
		((Control)this.m_t).Anchor = (AnchorStyles)15;
		((Control)this.m_t).Location = new Point(67, 124);
		((TextBoxBase)this.m_t).Multiline = true;
		((Control)this.m_t).Name = "txtGameOpening";
		((Control)this.m_t).Size = new Size(598, 99);
		((Control)this.m_t).TabIndex = 8;
		((Control)this.m_t).DoubleClick += ao;
		((Control)this.m_t).Enter += af;
		((Control)this.m_t).KeyDown += e;
		((Control)this.m_t).Leave += gu;
		((Control)this.m_e1).Anchor = (AnchorStyles)9;
		this.m_e1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		((Control)this.m_e1).Location = new Point(565, 3);
		((Control)this.m_e1).Name = "pictureBox1";
		((Control)this.m_e1).Size = new Size(100, 30);
		this.m_e1.TabIndex = 10;
		this.m_e1.TabStop = false;
		((Control)this.m_em).AutoSize = true;
		((Control)this.m_em).Location = new Point(6, 38);
		((Control)this.m_em).Name = "cbPasswordProtected";
		((Control)this.m_em).Size = new Size(169, 17);
		((Control)this.m_em).TabIndex = 1;
		((Control)this.m_em).Text = "Password Protect This Game?";
		((ButtonBase)this.m_em).UseVisualStyleBackColor = true;
		this.m_em.CheckedChanged += eo;
		((Control)this.m_ek).AutoSize = true;
		((Control)this.m_ek).Location = new Point(190, 39);
		((Control)this.m_ek).Name = "label31";
		((Control)this.m_ek).Size = new Size(56, 13);
		((Control)this.m_ek).TabIndex = 1;
		((Control)this.m_ek).Text = "Password:";
		((Control)this.m_w).Location = new Point(3, 6);
		((Control)this.m_w).Name = "label1";
		((Control)this.m_w).Size = new Size(64, 16);
		((Control)this.m_w).TabIndex = 2;
		((Control)this.m_w).Text = "Game Title:";
		((Control)this.m_el).Enabled = false;
		((Control)this.m_el).Location = new Point(252, 35);
		((Control)this.m_el).Name = "tbGamePassword";
		((Control)this.m_el).Size = new Size(147, 20);
		((Control)this.m_el).TabIndex = 2;
		((Control)this.m_el).Leave += en;
		((Control)this.m_v).Location = new Point(67, 6);
		((Control)this.m_v).Name = "txtGameTitle";
		((Control)this.m_v).Size = new Size(332, 20);
		((Control)this.m_v).TabIndex = 0;
		((Control)this.m_v).Enter += af;
		((Control)this.m_v).KeyDown += e;
		((Control)this.m_v).Leave += gv;
		((Control)kb).Controls.Add((Control)(object)kf);
		((Control)kb).Controls.Add((Control)(object)kg);
		((Control)kb).Controls.Add((Control)(object)kh);
		((Control)kb).Controls.Add((Control)(object)ki);
		((Control)kb).Controls.Add((Control)(object)kd);
		((Control)kb).Controls.Add((Control)(object)ke);
		((Control)kb).Controls.Add((Control)(object)kc);
		kb.Location = new Point(4, 4);
		((Control)kb).Name = "tabPage16";
		((Control)kb).Padding = new Padding(3);
		((Control)kb).Size = new Size(671, 532);
		kb.TabIndex = 1;
		((Control)kb).Text = "Author Info";
		kb.UseVisualStyleBackColor = true;
		((Control)kf).Location = new Point(4, 73);
		((Control)kf).Name = "label66";
		((Control)kf).Size = new Size(93, 38);
		((Control)kf).TabIndex = 16;
		((Control)kf).Text = "Game Information:";
		((Control)kg).Anchor = (AnchorStyles)15;
		((Control)kg).Location = new Point(103, 73);
		((TextBoxBase)kg).Multiline = true;
		((Control)kg).Name = "tbGameInformation";
		((Control)kg).Size = new Size(562, 474);
		((Control)kg).TabIndex = 2;
		((Control)kg).DoubleClick += ao;
		((Control)kg).Enter += af;
		((Control)kg).Leave += bg;
		((Control)kh).Location = new Point(6, 37);
		((Control)kh).Name = "label65";
		((Control)kh).Size = new Size(91, 20);
		((Control)kh).TabIndex = 14;
		((Control)kh).Text = "Game Version:";
		((Control)ki).Location = new Point(103, 37);
		((Control)ki).Name = "tbGameVersion";
		((Control)ki).Size = new Size(318, 20);
		((Control)ki).TabIndex = 1;
		((Control)ki).DoubleClick += ao;
		((Control)ki).Enter += af;
		((Control)ki).Leave += bh;
		((Control)kd).Location = new Point(6, 6);
		((Control)kd).Name = "label64";
		((Control)kd).Size = new Size(91, 20);
		((Control)kd).TabIndex = 12;
		((Control)kd).Text = "Author Name:";
		((Control)ke).Location = new Point(103, 6);
		((Control)ke).Name = "tbAuthorName";
		((Control)ke).Size = new Size(318, 20);
		((Control)ke).TabIndex = 0;
		((Control)ke).DoubleClick += ao;
		((Control)ke).Enter += af;
		((Control)ke).Leave += bi;
		((Control)kc).Anchor = (AnchorStyles)9;
		kc.Image = (Image)componentResourceManager.GetObject("pictureBox17.Image");
		((Control)kc).Location = new Point(565, 3);
		((Control)kc).Name = "pictureBox17";
		((Control)kc).Size = new Size(100, 30);
		kc.TabIndex = 11;
		kc.TabStop = false;
		((Control)this.m_x).Controls.Add((Control)(object)ij);
		this.m_x.Location = new Point(4, 4);
		((Control)this.m_x).Name = "Rooms";
		((Control)this.m_x).Size = new Size(679, 558);
		this.m_x.TabIndex = 2;
		((Control)this.m_x).Text = "Rooms";
		this.m_x.UseVisualStyleBackColor = true;
		this.m_x.Visible = false;
		ij.BorderStyle = (BorderStyle)1;
		ij.Dock = (DockStyle)5;
		((Control)ij).Location = new Point(0, 0);
		((Control)ij).Name = "splitContainer4";
		((Control)ij.Panel1).Controls.Add((Control)(object)dgvRoomList);
		((Control)ij.Panel1).Controls.Add((Control)(object)this.m_bc);
		((Control)ij.Panel2).Controls.Add((Control)(object)tabControl2);
		((Control)ij).Size = new Size(679, 558);
		ij.SplitterDistance = 134;
		((Control)ij).TabIndex = 53;
		dgvRoomList.AllowUserToAddRows = false;
		dgvRoomList.AllowUserToDeleteRows = false;
		dgvRoomList.AllowUserToResizeRows = false;
		((Control)dgvRoomList).Anchor = (AnchorStyles)15;
		dgvRoomList.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		dgvRoomList.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		dgvRoomList.ColumnHeadersDefaultCellStyle = val;
		dgvRoomList.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		dgvRoomList.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)ik });
		((Control)dgvRoomList).ContextMenuStrip = hj;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		dgvRoomList.DefaultCellStyle = val2;
		((Control)dgvRoomList).Location = new Point(3, 3);
		((Control)dgvRoomList).Name = "dgvRoomList";
		dgvRoomList.ReadOnly = true;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		dgvRoomList.RowHeadersDefaultCellStyle = val3;
		dgvRoomList.RowHeadersVisible = false;
		dgvRoomList.RowHeadersWidth = 4;
		dgvRoomList.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)dgvRoomList).Size = new Size(126, 517);
		((Control)dgvRoomList).TabIndex = 0;
		dgvRoomList.SelectionChanged += cz;
		dgvRoomList.SortCompare += d;
		((DataGridViewColumn)ik).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)ik).DefaultCellStyle = val4;
		((DataGridViewColumn)ik).HeaderText = "Room Name";
		((DataGridViewColumn)ik).MinimumWidth = 100;
		((DataGridViewColumn)ik).Name = "Column1";
		((DataGridViewBand)ik).ReadOnly = true;
		((DataGridViewBand)ik).Resizable = (DataGridViewTriState)2;
		((Control)this.m_bc).Anchor = (AnchorStyles)2;
		((Control)this.m_bc).Location = new Point(16, 526);
		((Control)this.m_bc).Name = "btnAddRoom";
		((Control)this.m_bc).Size = new Size(96, 23);
		((Control)this.m_bc).TabIndex = 1;
		((Control)this.m_bc).Text = "Add New Room";
		((Control)this.m_bc).Click += gp;
		tabControl2.Alignment = (TabAlignment)1;
		((Control)tabControl2).Controls.Add((Control)(object)this.m_y);
		((Control)tabControl2).Controls.Add((Control)(object)this.m_ac);
		((Control)tabControl2).Controls.Add((Control)(object)this.m_a9);
		((Control)tabControl2).Controls.Add((Control)(object)this.m_d7);
		((Control)tabControl2).Dock = (DockStyle)5;
		((Control)tabControl2).Location = new Point(0, 0);
		((Control)tabControl2).Name = "tabControl2";
		tabControl2.SelectedIndex = 0;
		((Control)tabControl2).Size = new Size(539, 556);
		((Control)tabControl2).TabIndex = 31;
		((Control)this.m_y).AllowDrop = true;
		((Control)this.m_y).Controls.Add((Control)(object)jy);
		((Control)this.m_y).Controls.Add((Control)(object)jz);
		((Control)this.m_y).Controls.Add((Control)(object)tbRoomID);
		((Control)this.m_y).Controls.Add((Control)(object)ja);
		((Control)this.m_y).Controls.Add((Control)(object)this.m_e2);
		((Control)this.m_y).Controls.Add((Control)(object)txtRoomName);
		((Control)this.m_y).Controls.Add((Control)(object)txtRoomSDesc);
		((Control)this.m_y).Controls.Add((Control)(object)this.m_z);
		((Control)this.m_y).Controls.Add((Control)(object)this.m_aa);
		((Control)this.m_y).Controls.Add((Control)(object)this.m_en);
		this.m_y.Location = new Point(4, 4);
		((Control)this.m_y).Name = "tabPage3";
		((Control)this.m_y).Size = new Size(531, 530);
		this.m_y.TabIndex = 0;
		((Control)this.m_y).Text = "General";
		jy.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)jy).FormattingEnabled = true;
		((Control)jy).Location = new Point(131, 77);
		((Control)jy).Name = "cbRoomGroup";
		((Control)jy).Size = new Size(262, 21);
		((Control)jy).TabIndex = 3;
		jy.SelectedIndexChanged += bs;
		((Control)jz).Location = new Point(3, 79);
		((Control)jz).Name = "label61";
		((Control)jz).Size = new Size(72, 18);
		((Control)jz).TabIndex = 52;
		((Control)jz).Text = "Room Group:";
		((Control)tbRoomID).Anchor = (AnchorStyles)13;
		((Control)tbRoomID).Location = new Point(131, 28);
		((Control)tbRoomID).Name = "tbRoomID";
		((TextBoxBase)tbRoomID).ReadOnly = true;
		((Control)tbRoomID).Size = new Size(291, 20);
		((Control)tbRoomID).TabIndex = 1;
		((Control)ja).Location = new Point(3, 30);
		((Control)ja).Name = "label54";
		((Control)ja).Size = new Size(64, 16);
		((Control)ja).TabIndex = 50;
		((Control)ja).Text = "Room ID:";
		((Control)this.m_e2).Anchor = (AnchorStyles)9;
		this.m_e2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
		((Control)this.m_e2).Location = new Point(428, 3);
		((Control)this.m_e2).Name = "pictureBox2";
		((Control)this.m_e2).Size = new Size(100, 30);
		this.m_e2.TabIndex = 49;
		this.m_e2.TabStop = false;
		((Control)txtRoomName).Anchor = (AnchorStyles)13;
		((Control)txtRoomName).Location = new Point(131, 5);
		((Control)txtRoomName).Name = "txtRoomName";
		((TextBoxBase)txtRoomName).ReadOnly = true;
		((Control)txtRoomName).Size = new Size(291, 20);
		((Control)txtRoomName).TabIndex = 0;
		((Control)txtRoomSDesc).Anchor = (AnchorStyles)13;
		((Control)txtRoomSDesc).Location = new Point(131, 51);
		((Control)txtRoomSDesc).Name = "txtRoomSDesc";
		((Control)txtRoomSDesc).Size = new Size(291, 20);
		((Control)txtRoomSDesc).TabIndex = 2;
		((Control)txtRoomSDesc).DoubleClick += ao;
		((Control)txtRoomSDesc).Enter += af;
		((Control)txtRoomSDesc).KeyDown += e;
		((Control)txtRoomSDesc).Leave += fv;
		((Control)this.m_z).Location = new Point(3, 7);
		((Control)this.m_z).Name = "label6";
		((Control)this.m_z).Size = new Size(72, 16);
		((Control)this.m_z).TabIndex = 42;
		((Control)this.m_z).Text = "Room Name:";
		((Control)this.m_aa).Location = new Point(3, 53);
		((Control)this.m_aa).Name = "label9";
		((Control)this.m_aa).Size = new Size(121, 18);
		((Control)this.m_aa).TabIndex = 36;
		((Control)this.m_aa).Text = "Room Name Override:";
		((Control)this.m_en).Anchor = (AnchorStyles)15;
		this.m_en.BorderStyle = (BorderStyle)1;
		((Control)this.m_en).Location = new Point(3, 109);
		((Control)this.m_en).Name = "splitContainer1";
		this.m_en.Orientation = (Orientation)0;
		((Control)this.m_en.Panel1).Controls.Add((Control)(object)this.m_ab);
		((Control)this.m_en.Panel1).Controls.Add((Control)(object)txtRoomDescription);
		((Control)this.m_en.Panel2).AllowDrop = true;
		((Control)this.m_en.Panel2).Controls.Add((Control)(object)ou);
		((Control)this.m_en.Panel2).Controls.Add((Control)(object)this.m_ep);
		((Control)this.m_en.Panel2).Controls.Add((Control)(object)this.m_eq);
		((Control)this.m_en.Panel2).Controls.Add((Control)(object)this.m_eo);
		((Control)this.m_en.Panel2).DragDrop += p;
		((Control)this.m_en.Panel2).DragOver += q;
		((Control)this.m_en).Size = new Size(528, 418);
		this.m_en.SplitterDistance = 112;
		((Control)this.m_en).TabIndex = 48;
		((Control)this.m_ab).Location = new Point(3, 5);
		((Control)this.m_ab).Name = "label10";
		((Control)this.m_ab).Size = new Size(64, 16);
		((Control)this.m_ab).TabIndex = 34;
		((Control)this.m_ab).Text = "Description:";
		((Control)txtRoomDescription).Anchor = (AnchorStyles)15;
		((Control)txtRoomDescription).Location = new Point(3, 21);
		((TextBoxBase)txtRoomDescription).Multiline = true;
		((Control)txtRoomDescription).Name = "txtRoomDescription";
		((Control)txtRoomDescription).Size = new Size(520, 84);
		((Control)txtRoomDescription).TabIndex = 4;
		((Control)txtRoomDescription).DoubleClick += ao;
		((Control)txtRoomDescription).Enter += af;
		((Control)txtRoomDescription).KeyDown += e;
		((Control)txtRoomDescription).Leave += fw;
		((Control)ou).Anchor = (AnchorStyles)15;
		((AxHost)ou).Enabled = true;
		((Control)ou).Location = new Point(0, 45);
		((Control)ou).Name = "axRoomPic";
		((AxHost)ou).OcxState = (State)componentResourceManager.GetObject("axRoomPic.OcxState");
		((Control)ou).Size = new Size(526, 255);
		((Control)ou).TabIndex = 53;
		((Control)ou).Visible = false;
		((Control)this.m_ep).Location = new Point(3, 5);
		((Control)this.m_ep).Name = "label11";
		((Control)this.m_ep).Size = new Size(148, 13);
		((Control)this.m_ep).TabIndex = 50;
		((Control)this.m_ep).Text = "Initial Room Pic: ";
		((Control)this.m_eq).Location = new Point(3, 21);
		((Control)this.m_eq).Name = "cbPicList";
		((Control)this.m_eq).Size = new Size(176, 21);
		this.m_eq.Sorted = true;
		((Control)this.m_eq).TabIndex = 5;
		((Control)this.m_eq).Text = "None";
		this.m_eq.SelectedIndexChanged += f3;
		((Control)this.m_eo).Anchor = (AnchorStyles)15;
		((Control)this.m_eo).BackgroundImageLayout = (ImageLayout)4;
		this.m_eo.BorderStyle = (BorderStyle)1;
		((Control)this.m_eo).Location = new Point(3, 45);
		((Control)this.m_eo).Name = "picRoom";
		((Control)this.m_eo).Size = new Size(520, 252);
		this.m_eo.SizeMode = (PictureBoxSizeMode)4;
		this.m_eo.TabIndex = 52;
		this.m_eo.TabStop = false;
		((Control)this.m_eo).Paint += a;
		((Control)this.m_ac).Controls.Add((Control)(object)this.m_ff);
		((Control)this.m_ac).Controls.Add((Control)(object)this.m_fe);
		((Control)this.m_ac).Controls.Add((Control)(object)this.m_e3);
		this.m_ac.Location = new Point(4, 4);
		((Control)this.m_ac).Name = "tabpageexit";
		((Control)this.m_ac).Size = new Size(531, 530);
		this.m_ac.TabIndex = 1;
		((Control)this.m_ac).Text = "Exits";
		this.m_ac.Visible = false;
		((Control)this.m_ff).AutoSize = true;
		((Control)this.m_ff).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_ff).Location = new Point(3, 0);
		((Control)this.m_ff).Name = "lblRoomName1";
		((Control)this.m_ff).Size = new Size(126, 24);
		((Control)this.m_ff).TabIndex = 95;
		((Control)this.m_ff).Text = "Room Name";
		((Control)this.m_fe).Anchor = (AnchorStyles)15;
		((Control)this.m_fe).Controls.Add((Control)(object)this.m_fh);
		((Control)this.m_fe).Location = new Point(3, 39);
		((Control)this.m_fe).Name = "gbRoomDirections";
		((Control)this.m_fe).Size = new Size(525, 509);
		((Control)this.m_fe).TabIndex = 96;
		this.m_fe.TabStop = false;
		((Control)this.m_fe).Text = "Directions";
		this.m_fh.CellBorderStyle = (TableLayoutPanelCellBorderStyle)1;
		this.m_fh.ColumnCount = 4;
		this.m_fh.ColumnStyles.Add(new ColumnStyle((SizeType)2, 15.2049f));
		this.m_fh.ColumnStyles.Add(new ColumnStyle((SizeType)2, 14.83404f));
		this.m_fh.ColumnStyles.Add(new ColumnStyle((SizeType)2, 34.98053f));
		this.m_fh.ColumnStyles.Add(new ColumnStyle((SizeType)2, 34.98053f));
		this.m_fh.Controls.Add((Control)(object)id, 0, 12);
		this.m_fh.Controls.Add((Control)(object)ie, 0, 12);
		this.m_fh.Controls.Add((Control)(object)@if, 0, 12);
		this.m_fh.Controls.Add((Control)(object)ig, 0, 12);
		this.m_fh.Controls.Add((Control)(object)h9, 0, 11);
		this.m_fh.Controls.Add((Control)(object)ia, 0, 11);
		this.m_fh.Controls.Add((Control)(object)this.m_fo, 3, 10);
		this.m_fh.Controls.Add((Control)(object)this.m_fp, 3, 9);
		this.m_fh.Controls.Add((Control)(object)this.m_fq, 3, 8);
		this.m_fh.Controls.Add((Control)(object)this.m_fr, 3, 7);
		this.m_fh.Controls.Add((Control)(object)this.m_fs, 3, 6);
		this.m_fh.Controls.Add((Control)(object)this.m_ft, 3, 5);
		this.m_fh.Controls.Add((Control)(object)this.m_fu, 3, 4);
		this.m_fh.Controls.Add((Control)(object)this.m_fv, 3, 3);
		this.m_fh.Controls.Add((Control)(object)this.m_fw, 3, 2);
		this.m_fh.Controls.Add((Control)(object)this.m_fx, 3, 1);
		this.m_fh.Controls.Add((Control)(object)this.m_fn, 3, 0);
		this.m_fh.Controls.Add((Control)(object)this.m_ad, 1, 10);
		this.m_fh.Controls.Add((Control)(object)this.m_a8, 0, 0);
		this.m_fh.Controls.Add((Control)(object)this.m_a7, 2, 1);
		this.m_fh.Controls.Add((Control)(object)this.m_av, 0, 10);
		this.m_fh.Controls.Add((Control)(object)this.m_ag, 2, 9);
		this.m_fh.Controls.Add((Control)(object)this.m_af, 1, 9);
		this.m_fh.Controls.Add((Control)(object)this.m_a6, 2, 0);
		this.m_fh.Controls.Add((Control)(object)this.m_fi, 1, 0);
		this.m_fh.Controls.Add((Control)(object)this.m_aw, 0, 9);
		this.m_fh.Controls.Add((Control)(object)this.m_ai, 2, 8);
		this.m_fh.Controls.Add((Control)(object)this.m_ah, 1, 8);
		this.m_fh.Controls.Add((Control)(object)this.m_a3, 0, 2);
		this.m_fh.Controls.Add((Control)(object)this.m_a2, 0, 3);
		this.m_fh.Controls.Add((Control)(object)this.m_ax, 0, 8);
		this.m_fh.Controls.Add((Control)(object)this.m_ak, 2, 7);
		this.m_fh.Controls.Add((Control)(object)this.m_aj, 1, 7);
		this.m_fh.Controls.Add((Control)(object)this.m_a1, 0, 4);
		this.m_fh.Controls.Add((Control)(object)this.m_a0, 0, 5);
		this.m_fh.Controls.Add((Control)(object)this.m_ay, 0, 7);
		this.m_fh.Controls.Add((Control)(object)this.m_al, 1, 6);
		this.m_fh.Controls.Add((Control)(object)this.m_am, 2, 6);
		this.m_fh.Controls.Add((Control)(object)this.m_az, 0, 6);
		this.m_fh.Controls.Add((Control)(object)this.m_a4, 0, 1);
		this.m_fh.Controls.Add((Control)(object)this.m_a5, 1, 1);
		this.m_fh.Controls.Add((Control)(object)this.m_at, 1, 2);
		this.m_fh.Controls.Add((Control)(object)this.m_au, 2, 2);
		this.m_fh.Controls.Add((Control)(object)this.m_ar, 1, 3);
		this.m_fh.Controls.Add((Control)(object)this.m_an, 1, 5);
		this.m_fh.Controls.Add((Control)(object)this.m_ao, 2, 5);
		this.m_fh.Controls.Add((Control)(object)this.m_as, 2, 3);
		this.m_fh.Controls.Add((Control)(object)this.m_ap, 1, 4);
		this.m_fh.Controls.Add((Control)(object)this.m_aq, 2, 4);
		this.m_fh.Controls.Add((Control)(object)this.m_ae, 2, 10);
		this.m_fh.Controls.Add((Control)(object)ib, 2, 11);
		this.m_fh.Controls.Add((Control)(object)ic, 3, 11);
		((Control)this.m_fh).Dock = (DockStyle)5;
		((Control)this.m_fh).Location = new Point(3, 16);
		((Control)this.m_fh).Name = "tableLayoutPanel1";
		this.m_fh.RowCount = 13;
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.692426f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.691658f));
		this.m_fh.RowStyles.Add(new RowStyle((SizeType)2, 7.691658f));
		((Control)this.m_fh).Size = new Size(519, 490);
		((Control)this.m_fh).TabIndex = 84;
		id.CheckAlign = (ContentAlignment)32;
		((Control)id).Dock = (DockStyle)5;
		((Control)id).Location = new Point(83, 448);
		((Control)id).Name = "ActiveExitOut";
		((Control)id).Size = new Size(70, 38);
		((Control)id).TabIndex = 33;
		((Control)id).Leave += ch;
		((Control)ie).Dock = (DockStyle)5;
		((Control)ie).Location = new Point(4, 445);
		((Control)ie).Name = "label52";
		((Control)ie).Size = new Size(72, 44);
		((Control)ie).TabIndex = 104;
		((Control)ie).Text = "Out";
		ie.TextAlign = (ContentAlignment)32;
		((Control)@if).Anchor = (AnchorStyles)12;
		@if.DropDownStyle = (ComboBoxStyle)2;
		((Control)@if).Location = new Point(340, 456);
		((Control)@if).Name = "cbOutPortal";
		((Control)@if).Size = new Size(175, 21);
		@if.Sorted = true;
		((Control)@if).TabIndex = 35;
		@if.SelectedIndexChanged += cj;
		((Control)ig).Anchor = (AnchorStyles)12;
		ig.DropDownStyle = (ComboBoxStyle)2;
		((Control)ig).Location = new Point(160, 456);
		((Control)ig).Name = "cbOutExit";
		((Control)ig).Size = new Size(173, 21);
		ig.Sorted = true;
		((Control)ig).TabIndex = 34;
		ig.SelectedIndexChanged += ck;
		((Control)h9).Dock = (DockStyle)5;
		((Control)h9).Location = new Point(4, 408);
		((Control)h9).Name = "label51";
		((Control)h9).Size = new Size(72, 36);
		((Control)h9).TabIndex = 97;
		((Control)h9).Text = "In";
		h9.TextAlign = (ContentAlignment)32;
		ia.CheckAlign = (ContentAlignment)32;
		((Control)ia).Dock = (DockStyle)5;
		((Control)ia).Location = new Point(83, 411);
		((Control)ia).Name = "ActiveExitIn";
		((Control)ia).Size = new Size(70, 30);
		((Control)ia).TabIndex = 30;
		((Control)ia).Leave += ci;
		((Control)this.m_fo).Anchor = (AnchorStyles)12;
		this.m_fo.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fo).Location = new Point(340, 378);
		((Control)this.m_fo).Name = "cbSouthEastPortal";
		((Control)this.m_fo).Size = new Size(175, 21);
		this.m_fo.Sorted = true;
		((Control)this.m_fo).TabIndex = 29;
		this.m_fo.SelectedIndexChanged += d4;
		((Control)this.m_fp).Anchor = (AnchorStyles)12;
		this.m_fp.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fp).Location = new Point(340, 341);
		((Control)this.m_fp).Name = "cbSouthWestPortal";
		((Control)this.m_fp).Size = new Size(175, 21);
		this.m_fp.Sorted = true;
		((Control)this.m_fp).TabIndex = 26;
		this.m_fp.SelectedIndexChanged += d5;
		((Control)this.m_fq).Anchor = (AnchorStyles)12;
		this.m_fq.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fq).Location = new Point(340, 304);
		((Control)this.m_fq).Name = "cbNorthEastPortal";
		((Control)this.m_fq).Size = new Size(175, 21);
		this.m_fq.Sorted = true;
		((Control)this.m_fq).TabIndex = 23;
		this.m_fq.SelectedIndexChanged += d6;
		((Control)this.m_fr).Anchor = (AnchorStyles)12;
		this.m_fr.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fr).Location = new Point(340, 267);
		((Control)this.m_fr).Name = "cbNorthWestPortal";
		((Control)this.m_fr).Size = new Size(175, 21);
		this.m_fr.Sorted = true;
		((Control)this.m_fr).TabIndex = 20;
		this.m_fr.SelectedIndexChanged += d7;
		((Control)this.m_fs).Anchor = (AnchorStyles)12;
		this.m_fs.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fs).Location = new Point(340, 230);
		((Control)this.m_fs).Name = "cbDownPortal";
		((Control)this.m_fs).Size = new Size(175, 21);
		this.m_fs.Sorted = true;
		((Control)this.m_fs).TabIndex = 17;
		this.m_fs.SelectedIndexChanged += d8;
		((Control)this.m_ft).Anchor = (AnchorStyles)12;
		this.m_ft.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ft).Location = new Point(340, 193);
		((Control)this.m_ft).Name = "cbUpPortal";
		((Control)this.m_ft).Size = new Size(175, 21);
		this.m_ft.Sorted = true;
		((Control)this.m_ft).TabIndex = 14;
		this.m_ft.SelectedIndexChanged += d9;
		((Control)this.m_fu).Anchor = (AnchorStyles)12;
		this.m_fu.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fu).Location = new Point(340, 156);
		((Control)this.m_fu).Name = "cbEastPortal";
		((Control)this.m_fu).Size = new Size(175, 21);
		this.m_fu.Sorted = true;
		((Control)this.m_fu).TabIndex = 11;
		this.m_fu.SelectedIndexChanged += ea;
		((Control)this.m_fv).Anchor = (AnchorStyles)12;
		this.m_fv.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fv).Location = new Point(340, 119);
		((Control)this.m_fv).Name = "cbWestPortal";
		((Control)this.m_fv).Size = new Size(175, 21);
		this.m_fv.Sorted = true;
		((Control)this.m_fv).TabIndex = 8;
		this.m_fv.SelectedIndexChanged += eb;
		((Control)this.m_fw).Anchor = (AnchorStyles)12;
		this.m_fw.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fw).Location = new Point(340, 82);
		((Control)this.m_fw).Name = "cbSouthPortal";
		((Control)this.m_fw).Size = new Size(175, 21);
		this.m_fw.Sorted = true;
		((Control)this.m_fw).TabIndex = 5;
		this.m_fw.SelectedIndexChanged += ec;
		((Control)this.m_fx).Anchor = (AnchorStyles)12;
		this.m_fx.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_fx).Location = new Point(340, 45);
		((Control)this.m_fx).Name = "cbNorthPortal";
		((Control)this.m_fx).Size = new Size(175, 21);
		this.m_fx.Sorted = true;
		((Control)this.m_fx).TabIndex = 2;
		this.m_fx.SelectedIndexChanged += ed;
		((Control)this.m_fn).Dock = (DockStyle)5;
		((Control)this.m_fn).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fn).Location = new Point(340, 1);
		((Control)this.m_fn).Name = "label33";
		((Control)this.m_fn).Size = new Size(175, 36);
		((Control)this.m_fn).TabIndex = 84;
		((Control)this.m_fn).Text = "Door/Portal Object";
		this.m_fn.TextAlign = (ContentAlignment)512;
		this.m_ad.CheckAlign = (ContentAlignment)32;
		((Control)this.m_ad).Dock = (DockStyle)5;
		((Control)this.m_ad).Location = new Point(83, 374);
		((Control)this.m_ad).Name = "ActiveExitSouthEast";
		((Control)this.m_ad).Size = new Size(70, 30);
		((Control)this.m_ad).TabIndex = 27;
		((Control)this.m_ad).Leave += f4;
		((Control)this.m_a8).Dock = (DockStyle)5;
		((Control)this.m_a8).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_a8).Location = new Point(4, 1);
		((Control)this.m_a8).Name = "label8";
		((Control)this.m_a8).Size = new Size(72, 36);
		((Control)this.m_a8).TabIndex = 50;
		((Control)this.m_a8).Text = "Exits";
		this.m_a8.TextAlign = (ContentAlignment)512;
		((Control)this.m_a7).Anchor = (AnchorStyles)12;
		this.m_a7.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_a7).Location = new Point(160, 45);
		((Control)this.m_a7).Name = "cbNorthExit";
		((Control)this.m_a7).Size = new Size(173, 21);
		this.m_a7.Sorted = true;
		((Control)this.m_a7).TabIndex = 1;
		this.m_a7.SelectedIndexChanged += fu;
		((Control)this.m_av).Dock = (DockStyle)5;
		((Control)this.m_av).Location = new Point(4, 371);
		((Control)this.m_av).Name = "label22";
		((Control)this.m_av).Size = new Size(72, 36);
		((Control)this.m_av).TabIndex = 65;
		((Control)this.m_av).Text = "SouthEast";
		this.m_av.TextAlign = (ContentAlignment)32;
		((Control)this.m_ag).Anchor = (AnchorStyles)12;
		this.m_ag.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ag).Location = new Point(160, 341);
		((Control)this.m_ag).Name = "cbSouthWestExit";
		((Control)this.m_ag).Size = new Size(173, 21);
		this.m_ag.Sorted = true;
		((Control)this.m_ag).TabIndex = 25;
		this.m_ag.SelectedIndexChanged += gm;
		this.m_af.CheckAlign = (ContentAlignment)32;
		((Control)this.m_af).Dock = (DockStyle)5;
		((Control)this.m_af).Location = new Point(83, 337);
		((Control)this.m_af).Name = "ActiveExitSouthWest";
		((Control)this.m_af).Size = new Size(70, 30);
		((Control)this.m_af).TabIndex = 24;
		((Control)this.m_af).Leave += f5;
		((Control)this.m_a6).Dock = (DockStyle)5;
		((Control)this.m_a6).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_a6).Location = new Point(160, 1);
		((Control)this.m_a6).Name = "label12";
		((Control)this.m_a6).Size = new Size(173, 36);
		((Control)this.m_a6).TabIndex = 53;
		((Control)this.m_a6).Text = "Destination Room";
		this.m_a6.TextAlign = (ContentAlignment)512;
		((Control)this.m_fi).AutoSize = true;
		((Control)this.m_fi).Dock = (DockStyle)5;
		((Control)this.m_fi).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fi).Location = new Point(83, 1);
		((Control)this.m_fi).Name = "label35";
		((Control)this.m_fi).Size = new Size(70, 36);
		((Control)this.m_fi).TabIndex = 54;
		((Control)this.m_fi).Text = "Initially Active";
		this.m_fi.TextAlign = (ContentAlignment)512;
		((Control)this.m_aw).Dock = (DockStyle)5;
		((Control)this.m_aw).Location = new Point(4, 334);
		((Control)this.m_aw).Name = "label21";
		((Control)this.m_aw).Size = new Size(72, 36);
		((Control)this.m_aw).TabIndex = 64;
		((Control)this.m_aw).Text = "SouthWest";
		this.m_aw.TextAlign = (ContentAlignment)32;
		((Control)this.m_ai).Anchor = (AnchorStyles)12;
		this.m_ai.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ai).Location = new Point(160, 304);
		((Control)this.m_ai).Name = "cbNorthEastExit";
		((Control)this.m_ai).Size = new Size(173, 21);
		this.m_ai.Sorted = true;
		((Control)this.m_ai).TabIndex = 22;
		this.m_ai.SelectedIndexChanged += gg;
		this.m_ah.CheckAlign = (ContentAlignment)32;
		((Control)this.m_ah).Dock = (DockStyle)5;
		((Control)this.m_ah).Location = new Point(83, 300);
		((Control)this.m_ah).Name = "ActiveExitNorthEast";
		((Control)this.m_ah).Size = new Size(70, 30);
		((Control)this.m_ah).TabIndex = 21;
		((Control)this.m_ah).Leave += f6;
		((Control)this.m_a3).Dock = (DockStyle)5;
		((Control)this.m_a3).Location = new Point(4, 75);
		((Control)this.m_a3).Name = "label14";
		((Control)this.m_a3).Size = new Size(72, 36);
		((Control)this.m_a3).TabIndex = 57;
		((Control)this.m_a3).Text = "South";
		this.m_a3.TextAlign = (ContentAlignment)32;
		((Control)this.m_a2).Dock = (DockStyle)5;
		((Control)this.m_a2).Location = new Point(4, 112);
		((Control)this.m_a2).Name = "label15";
		((Control)this.m_a2).Size = new Size(72, 36);
		((Control)this.m_a2).TabIndex = 58;
		((Control)this.m_a2).Text = "West";
		this.m_a2.TextAlign = (ContentAlignment)32;
		((Control)this.m_ax).Dock = (DockStyle)5;
		((Control)this.m_ax).Location = new Point(4, 297);
		((Control)this.m_ax).Name = "label20";
		((Control)this.m_ax).Size = new Size(72, 36);
		((Control)this.m_ax).TabIndex = 63;
		((Control)this.m_ax).Text = "NorthEast";
		this.m_ax.TextAlign = (ContentAlignment)32;
		((Control)this.m_ak).Anchor = (AnchorStyles)12;
		this.m_ak.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ak).Location = new Point(160, 267);
		((Control)this.m_ak).Name = "cbNorthWestExit";
		((Control)this.m_ak).Size = new Size(173, 21);
		this.m_ak.Sorted = true;
		((Control)this.m_ak).TabIndex = 19;
		this.m_ak.SelectedIndexChanged += gh;
		this.m_aj.CheckAlign = (ContentAlignment)32;
		((Control)this.m_aj).Dock = (DockStyle)5;
		((Control)this.m_aj).Location = new Point(83, 263);
		((Control)this.m_aj).Name = "ActiveExitNorthWest";
		((Control)this.m_aj).Size = new Size(70, 30);
		((Control)this.m_aj).TabIndex = 18;
		((Control)this.m_aj).Leave += f7;
		((Control)this.m_a1).Dock = (DockStyle)5;
		((Control)this.m_a1).Location = new Point(4, 149);
		((Control)this.m_a1).Name = "label16";
		((Control)this.m_a1).Size = new Size(72, 36);
		((Control)this.m_a1).TabIndex = 59;
		((Control)this.m_a1).Text = "East";
		this.m_a1.TextAlign = (ContentAlignment)32;
		((Control)this.m_a0).Dock = (DockStyle)5;
		((Control)this.m_a0).Location = new Point(4, 186);
		((Control)this.m_a0).Name = "label17";
		((Control)this.m_a0).Size = new Size(72, 36);
		((Control)this.m_a0).TabIndex = 60;
		((Control)this.m_a0).Text = "Up";
		this.m_a0.TextAlign = (ContentAlignment)32;
		((Control)this.m_ay).Dock = (DockStyle)5;
		((Control)this.m_ay).Location = new Point(4, 260);
		((Control)this.m_ay).Name = "label19";
		((Control)this.m_ay).Size = new Size(72, 36);
		((Control)this.m_ay).TabIndex = 62;
		((Control)this.m_ay).Text = "NorthWest";
		this.m_ay.TextAlign = (ContentAlignment)32;
		this.m_al.CheckAlign = (ContentAlignment)32;
		((Control)this.m_al).Dock = (DockStyle)5;
		((Control)this.m_al).Location = new Point(83, 226);
		((Control)this.m_al).Name = "ActiveExitDown";
		((Control)this.m_al).Size = new Size(70, 30);
		((Control)this.m_al).TabIndex = 15;
		((Control)this.m_al).Leave += f8;
		((Control)this.m_am).Anchor = (AnchorStyles)12;
		this.m_am.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_am).Location = new Point(160, 230);
		((Control)this.m_am).Name = "cbDownExit";
		((Control)this.m_am).Size = new Size(173, 21);
		this.m_am.Sorted = true;
		((Control)this.m_am).TabIndex = 16;
		this.m_am.SelectedIndexChanged += gl;
		((Control)this.m_az).Dock = (DockStyle)5;
		((Control)this.m_az).Location = new Point(4, 223);
		((Control)this.m_az).Name = "label18";
		((Control)this.m_az).Size = new Size(72, 36);
		((Control)this.m_az).TabIndex = 61;
		((Control)this.m_az).Text = "Down";
		this.m_az.TextAlign = (ContentAlignment)32;
		((Control)this.m_a4).Dock = (DockStyle)5;
		((Control)this.m_a4).Location = new Point(4, 38);
		((Control)this.m_a4).Name = "label13";
		((Control)this.m_a4).Size = new Size(72, 36);
		((Control)this.m_a4).TabIndex = 55;
		((Control)this.m_a4).Text = "North";
		this.m_a4.TextAlign = (ContentAlignment)32;
		this.m_a5.CheckAlign = (ContentAlignment)32;
		((Control)this.m_a5).Dock = (DockStyle)5;
		((Control)this.m_a5).Location = new Point(83, 41);
		((Control)this.m_a5).Name = "ActiveExitNorth";
		((Control)this.m_a5).Size = new Size(70, 30);
		((Control)this.m_a5).TabIndex = 0;
		((ButtonBase)this.m_a5).TextAlign = (ContentAlignment)32;
		((Control)this.m_a5).Leave += ge;
		this.m_at.CheckAlign = (ContentAlignment)32;
		((Control)this.m_at).Dock = (DockStyle)5;
		((Control)this.m_at).Location = new Point(83, 78);
		((Control)this.m_at).Name = "ActiveExitSouth";
		((Control)this.m_at).Size = new Size(70, 30);
		((Control)this.m_at).TabIndex = 3;
		((Control)this.m_at).Leave += gd;
		((Control)this.m_au).Anchor = (AnchorStyles)12;
		this.m_au.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_au).Location = new Point(160, 82);
		((Control)this.m_au).Name = "cbSouthExit";
		((Control)this.m_au).Size = new Size(173, 21);
		this.m_au.Sorted = true;
		((Control)this.m_au).TabIndex = 4;
		this.m_au.SelectedIndexChanged += gn;
		this.m_ar.CheckAlign = (ContentAlignment)32;
		((Control)this.m_ar).Dock = (DockStyle)5;
		((Control)this.m_ar).Location = new Point(83, 115);
		((Control)this.m_ar).Name = "ActiveExitWest";
		((Control)this.m_ar).Size = new Size(70, 30);
		((Control)this.m_ar).TabIndex = 6;
		((Control)this.m_ar).Leave += gc;
		this.m_an.CheckAlign = (ContentAlignment)32;
		((Control)this.m_an).Dock = (DockStyle)5;
		((Control)this.m_an).Location = new Point(83, 189);
		((Control)this.m_an).Name = "ActiveExitUp";
		((Control)this.m_an).Size = new Size(70, 30);
		((Control)this.m_an).TabIndex = 12;
		((Control)this.m_an).Leave += f9;
		((Control)this.m_ao).Anchor = (AnchorStyles)12;
		this.m_ao.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ao).Location = new Point(160, 193);
		((Control)this.m_ao).Name = "cbUpExit";
		((Control)this.m_ao).Size = new Size(173, 21);
		this.m_ao.Sorted = true;
		((Control)this.m_ao).TabIndex = 13;
		this.m_ao.SelectedIndexChanged += gk;
		((Control)this.m_as).Anchor = (AnchorStyles)12;
		this.m_as.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_as).Location = new Point(160, 119);
		((Control)this.m_as).Name = "cbWestExit";
		((Control)this.m_as).Size = new Size(173, 21);
		this.m_as.Sorted = true;
		((Control)this.m_as).TabIndex = 7;
		this.m_as.SelectedIndexChanged += gf;
		this.m_ap.CheckAlign = (ContentAlignment)32;
		((Control)this.m_ap).Dock = (DockStyle)5;
		((Control)this.m_ap).Location = new Point(83, 152);
		((Control)this.m_ap).Name = "ActiveExitEast";
		((Control)this.m_ap).Size = new Size(70, 30);
		((Control)this.m_ap).TabIndex = 9;
		((Control)this.m_ap).Leave += ga;
		((Control)this.m_aq).Anchor = (AnchorStyles)12;
		this.m_aq.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_aq).Location = new Point(160, 156);
		((Control)this.m_aq).Name = "cbEastExit";
		((Control)this.m_aq).Size = new Size(173, 21);
		this.m_aq.Sorted = true;
		((Control)this.m_aq).TabIndex = 10;
		this.m_aq.SelectedIndexChanged += gi;
		((Control)this.m_ae).Anchor = (AnchorStyles)12;
		this.m_ae.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_ae).Location = new Point(160, 378);
		((Control)this.m_ae).Name = "cbSouthEastExit";
		((Control)this.m_ae).Size = new Size(173, 21);
		this.m_ae.Sorted = true;
		((Control)this.m_ae).TabIndex = 28;
		this.m_ae.SelectedIndexChanged += gj;
		((Control)ib).Anchor = (AnchorStyles)12;
		ib.DropDownStyle = (ComboBoxStyle)2;
		((Control)ib).Location = new Point(160, 415);
		((Control)ib).Name = "cbInExit";
		((Control)ib).Size = new Size(173, 21);
		ib.Sorted = true;
		((Control)ib).TabIndex = 31;
		ib.SelectedIndexChanged += cg;
		((Control)ic).Anchor = (AnchorStyles)12;
		ic.DropDownStyle = (ComboBoxStyle)2;
		((Control)ic).Location = new Point(340, 415);
		((Control)ic).Name = "cbInPortal";
		((Control)ic).Size = new Size(175, 21);
		ic.Sorted = true;
		((Control)ic).TabIndex = 32;
		ic.SelectedIndexChanged += cf;
		((Control)this.m_e3).Anchor = (AnchorStyles)9;
		this.m_e3.Image = (Image)componentResourceManager.GetObject("pictureBox3.Image");
		((Control)this.m_e3).Location = new Point(428, 3);
		((Control)this.m_e3).Name = "pictureBox3";
		((Control)this.m_e3).Size = new Size(100, 30);
		this.m_e3.TabIndex = 84;
		this.m_e3.TabStop = false;
		((Control)this.m_a9).Controls.Add((Control)(object)kl);
		((Control)this.m_a9).Controls.Add((Control)(object)this.m_fg);
		((Control)this.m_a9).Controls.Add((Control)(object)this.m_bz);
		((Control)this.m_a9).Controls.Add((Control)(object)this.m_ba);
		((Control)this.m_a9).Controls.Add((Control)(object)this.m_e4);
		((Control)this.m_a9).Controls.Add((Control)(object)this.m_bb);
		this.m_a9.Location = new Point(4, 4);
		((Control)this.m_a9).Name = "tabPage5";
		((Control)this.m_a9).Size = new Size(531, 530);
		this.m_a9.TabIndex = 2;
		((Control)this.m_a9).Text = "Objects/Custom Properties";
		this.m_a9.Visible = false;
		((Control)kl).Anchor = (AnchorStyles)15;
		((Control)kl).Controls.Add((Control)(object)kr);
		((Control)kl).Controls.Add((Control)(object)ks);
		((Control)kl).Controls.Add((Control)(object)kt);
		((Control)kl).Controls.Add((Control)(object)ku);
		((Control)kl).Controls.Add((Control)(object)kq);
		((Control)kl).Controls.Add((Control)(object)km);
		((Control)kl).Controls.Add((Control)(object)kn);
		((Control)kl).Controls.Add((Control)(object)kk);
		((Control)kl).Location = new Point(179, 39);
		((Control)kl).Name = "groupBox6";
		((Control)kl).Size = new Size(349, 491);
		((Control)kl).TabIndex = 2;
		kl.TabStop = false;
		((Control)kl).Text = "Custom Properties";
		((Control)kr).Anchor = (AnchorStyles)6;
		((Control)kr).AutoSize = true;
		((Control)kr).Location = new Point(6, 420);
		((Control)kr).Name = "label69";
		((Control)kr).Size = new Size(79, 13);
		((Control)kr).TabIndex = 105;
		((Control)kr).Text = "Property Value:";
		((Control)ks).Anchor = (AnchorStyles)6;
		((Control)ks).Location = new Point(9, 436);
		((Control)ks).Name = "tbRoomPropVal";
		((Control)ks).Size = new Size(160, 20);
		((Control)ks).TabIndex = 2;
		((Control)ks).Enter += af;
		((Control)kt).Anchor = (AnchorStyles)6;
		((Control)kt).AutoSize = true;
		((Control)kt).Location = new Point(6, 376);
		((Control)kt).Name = "label68";
		((Control)kt).Size = new Size(80, 13);
		((Control)kt).TabIndex = 103;
		((Control)kt).Text = "Property Name:";
		((Control)ku).Anchor = (AnchorStyles)6;
		((Control)ku).Location = new Point(9, 392);
		((Control)ku).Name = "tbRoomPropName";
		((Control)ku).Size = new Size(160, 20);
		((Control)ku).TabIndex = 1;
		((Control)ku).Enter += af;
		((Control)kq).Anchor = (AnchorStyles)6;
		((Control)kq).Location = new Point(213, 462);
		((Control)kq).Name = "btnRoomDeleteCustProp";
		((Control)kq).Size = new Size(91, 23);
		((Control)kq).TabIndex = 5;
		((Control)kq).Text = "Delete Property";
		((ButtonBase)kq).UseVisualStyleBackColor = true;
		((Control)kq).Click += ba;
		((Control)km).Anchor = (AnchorStyles)6;
		((Control)km).Location = new Point(105, 462);
		((Control)km).Name = "btnRoomUpdateCustProp";
		((Control)km).Size = new Size(102, 23);
		((Control)km).TabIndex = 4;
		((Control)km).Text = "Update Property";
		((ButtonBase)km).UseVisualStyleBackColor = true;
		((Control)km).Click += bb;
		((Control)kn).Anchor = (AnchorStyles)6;
		((Control)kn).Location = new Point(16, 462);
		((Control)kn).Name = "btnRoomAddCustProp";
		((Control)kn).Size = new Size(83, 23);
		((Control)kn).TabIndex = 3;
		((Control)kn).Text = "Add Property";
		((ButtonBase)kn).UseVisualStyleBackColor = true;
		((Control)kn).Click += bd;
		kk.AllowUserToAddRows = false;
		kk.AllowUserToDeleteRows = false;
		((Control)kk).Anchor = (AnchorStyles)15;
		kk.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		kk.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)ko,
			(DataGridViewColumn)kp
		});
		((Control)kk).Location = new Point(9, 19);
		kk.MultiSelect = false;
		((Control)kk).Name = "dgvRoomCustProp";
		kk.ReadOnly = true;
		kk.RowHeadersWidth = 4;
		kk.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)kk).Size = new Size(334, 354);
		((Control)kk).TabIndex = 0;
		kk.SelectionChanged += bc;
		((DataGridViewColumn)ko).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ko).HeaderText = "Name";
		((DataGridViewColumn)ko).Name = "Column2";
		((DataGridViewBand)ko).ReadOnly = true;
		((DataGridViewColumn)kp).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)kp).HeaderText = "Value";
		((DataGridViewColumn)kp).Name = "Column3";
		((DataGridViewBand)kp).ReadOnly = true;
		((Control)this.m_fg).AutoSize = true;
		((Control)this.m_fg).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fg).Location = new Point(3, 0);
		((Control)this.m_fg).Name = "lblRoomName2";
		((Control)this.m_fg).Size = new Size(126, 24);
		((Control)this.m_fg).TabIndex = 95;
		((Control)this.m_fg).Text = "Room Name";
		((Control)this.m_bz).Anchor = (AnchorStyles)6;
		((Control)this.m_bz).Location = new Point(30, 501);
		((Control)this.m_bz).Name = "btnAssignRoomObjects";
		((Control)this.m_bz).Size = new Size(110, 23);
		((Control)this.m_bz).TabIndex = 1;
		((Control)this.m_bz).Text = "Assign Objects";
		((ButtonBase)this.m_bz).UseVisualStyleBackColor = true;
		((Control)this.m_bz).Click += fg;
		((Control)this.m_ba).Location = new Point(9, 39);
		((Control)this.m_ba).Name = "label7";
		((Control)this.m_ba).Size = new Size(100, 16);
		((Control)this.m_ba).TabIndex = 43;
		((Control)this.m_ba).Text = "Objects:";
		((Control)this.m_e4).Anchor = (AnchorStyles)9;
		this.m_e4.Image = (Image)componentResourceManager.GetObject("pictureBox4.Image");
		((Control)this.m_e4).Location = new Point(428, 3);
		((Control)this.m_e4).Name = "pictureBox4";
		((Control)this.m_e4).Size = new Size(100, 30);
		this.m_e4.TabIndex = 50;
		this.m_e4.TabStop = false;
		((Control)this.m_bb).AllowDrop = true;
		((Control)this.m_bb).Anchor = (AnchorStyles)7;
		((Control)this.m_bb).ContextMenuStrip = this.m_b0;
		this.m_bb.HorizontalScrollbar = true;
		((Control)this.m_bb).Location = new Point(12, 62);
		((Control)this.m_bb).Name = "lbRoomObjects";
		this.m_bb.ScrollAlwaysVisible = true;
		((Control)this.m_bb).Size = new Size(161, 433);
		((Control)this.m_bb).TabIndex = 0;
		((Control)this.m_bb).DragDrop += o;
		((Control)this.m_bb).DragOver += s;
		((Control)this.m_d7).Controls.Add((Control)(object)RoomActions);
		((Control)this.m_d7).Controls.Add((Control)(object)this.m_fd);
		((Control)this.m_d7).Controls.Add((Control)(object)this.m_e5);
		this.m_d7.Location = new Point(4, 4);
		((Control)this.m_d7).Name = "tabPage7";
		((Control)this.m_d7).Padding = new Padding(3);
		((Control)this.m_d7).Size = new Size(531, 530);
		this.m_d7.TabIndex = 3;
		((Control)this.m_d7).Text = "Actions";
		this.m_d7.UseVisualStyleBackColor = true;
		((Control)RoomActions).Anchor = (AnchorStyles)15;
		((Control)RoomActions).AutoSize = true;
		((Control)RoomActions).Location = new Point(7, 39);
		((Control)RoomActions).Name = "RoomActions";
		((Control)RoomActions).Size = new Size(518, 488);
		((Control)RoomActions).TabIndex = 95;
		((Control)this.m_fd).AutoSize = true;
		((Control)this.m_fd).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fd).Location = new Point(3, 0);
		((Control)this.m_fd).Name = "lblRoomName";
		((Control)this.m_fd).Size = new Size(126, 24);
		((Control)this.m_fd).TabIndex = 94;
		((Control)this.m_fd).Text = "Room Name";
		((Control)this.m_e5).Anchor = (AnchorStyles)9;
		this.m_e5.Image = (Image)componentResourceManager.GetObject("pictureBox5.Image");
		((Control)this.m_e5).Location = new Point(428, 3);
		((Control)this.m_e5).Name = "pictureBox5";
		((Control)this.m_e5).Size = new Size(100, 30);
		this.m_e5.TabIndex = 50;
		this.m_e5.TabStop = false;
		((Control)this.m_bd).Controls.Add((Control)(object)tabControl4);
		this.m_bd.Location = new Point(4, 4);
		((Control)this.m_bd).Name = "tabPage2";
		((Control)this.m_bd).Size = new Size(679, 558);
		this.m_bd.TabIndex = 1;
		((Control)this.m_bd).Text = "Player";
		this.m_bd.UseVisualStyleBackColor = true;
		this.m_bd.Visible = false;
		tabControl4.Alignment = (TabAlignment)1;
		((Control)tabControl4).Controls.Add((Control)(object)this.m_eu);
		((Control)tabControl4).Controls.Add((Control)(object)kv);
		((Control)tabControl4).Controls.Add((Control)(object)this.m_et);
		((Control)tabControl4).Dock = (DockStyle)5;
		((Control)tabControl4).Location = new Point(0, 0);
		((Control)tabControl4).Name = "tabControl4";
		tabControl4.SelectedIndex = 0;
		((Control)tabControl4).Size = new Size(679, 558);
		((Control)tabControl4).TabIndex = 92;
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_e6);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_ev);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_ew);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_ex);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_es);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_ea);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bj);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_ca);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bi);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_cc);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bo);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_cb);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bh);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bq);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bp);
		((Control)this.m_eu).Controls.Add((Control)(object)this.m_bn);
		this.m_eu.Location = new Point(4, 4);
		((Control)this.m_eu).Name = "tabPage9";
		((Control)this.m_eu).Padding = new Padding(3);
		((Control)this.m_eu).Size = new Size(671, 532);
		this.m_eu.TabIndex = 0;
		((Control)this.m_eu).Text = "General";
		this.m_eu.UseVisualStyleBackColor = true;
		((Control)this.m_e6).Anchor = (AnchorStyles)9;
		this.m_e6.Image = (Image)componentResourceManager.GetObject("pictureBox6.Image");
		((Control)this.m_e6).Location = new Point(568, 3);
		((Control)this.m_e6).Name = "pictureBox6";
		((Control)this.m_e6).Size = new Size(100, 30);
		this.m_e6.TabIndex = 95;
		this.m_e6.TabStop = false;
		((Control)this.m_ev).AutoSize = true;
		((Control)this.m_ev).Location = new Point(3, 203);
		((Control)this.m_ev).Name = "label32";
		((Control)this.m_ev).Size = new Size(127, 13);
		((Control)this.m_ev).TabIndex = 94;
		((Control)this.m_ev).Text = "Player Carry Weight Limit:";
		((Control)this.m_ew).Enabled = false;
		((Control)this.m_ew).Location = new Point(139, 199);
		((Control)this.m_ew).Name = "tbWeightLimit";
		((Control)this.m_ew).Size = new Size(76, 20);
		((Control)this.m_ew).TabIndex = 5;
		((Control)this.m_ew).Leave += eh;
		((Control)this.m_ex).AutoSize = true;
		((Control)this.m_ex).Location = new Point(6, 176);
		((Control)this.m_ex).Name = "cbWeightRestrictions";
		((Control)this.m_ex).Size = new Size(182, 17);
		((Control)this.m_ex).TabIndex = 4;
		((Control)this.m_ex).Text = "Enforce weight carry restrictions?";
		((ButtonBase)this.m_ex).UseVisualStyleBackColor = true;
		this.m_ex.CheckedChanged += ej;
		((Control)this.m_ex).Leave += ei;
		((Control)this.m_es).Anchor = (AnchorStyles)15;
		((Control)this.m_es).Location = new Point(244, 14);
		((Control)this.m_es).Name = "splitContainer3";
		this.m_es.Orientation = (Orientation)0;
		((Control)this.m_es.Panel1).Controls.Add((Control)(object)this.m_d9);
		((Control)this.m_es.Panel1).Controls.Add((Control)(object)this.m_d8);
		((Control)this.m_es.Panel2).Controls.Add((Control)(object)this.m_eh);
		((Control)this.m_es).Size = new Size(427, 515);
		this.m_es.SplitterDistance = 127;
		((Control)this.m_es).TabIndex = 91;
		((Control)this.m_d9).Location = new Point(3, 5);
		((Control)this.m_d9).Name = "label30";
		((Control)this.m_d9).Size = new Size(224, 14);
		((Control)this.m_d9).TabIndex = 87;
		((Control)this.m_d9).Text = "Initial Description:";
		((Control)this.m_d8).Anchor = (AnchorStyles)15;
		((Control)this.m_d8).Location = new Point(6, 22);
		((TextBoxBase)this.m_d8).Multiline = true;
		((Control)this.m_d8).Name = "tbPlayerDescription";
		((Control)this.m_d8).Size = new Size(418, 102);
		((Control)this.m_d8).TabIndex = 10;
		((Control)this.m_d8).DoubleClick += ao;
		((Control)this.m_d8).Enter += af;
		((Control)this.m_d8).KeyDown += e;
		((Control)this.m_d8).Leave += eu;
		((Control)this.m_eh).AllowDrop = true;
		((Control)this.m_eh).Controls.Add((Control)(object)ov);
		((Control)this.m_eh).Controls.Add((Control)(object)this.m_bf);
		((Control)this.m_eh).Controls.Add((Control)(object)this.m_bg);
		((Control)this.m_eh).Controls.Add((Control)(object)this.m_be);
		((Control)this.m_eh).Dock = (DockStyle)5;
		((Control)this.m_eh).Location = new Point(0, 0);
		((Control)this.m_eh).Name = "PlayerPortraitPanel";
		((Control)this.m_eh).Size = new Size(427, 384);
		((Control)this.m_eh).TabIndex = 90;
		((Control)this.m_eh).DragDrop += n;
		((Control)this.m_eh).DragOver += q;
		((Control)this.m_bf).Location = new Point(6, 21);
		((Control)this.m_bf).Name = "cbPlayerPortrait";
		((Control)this.m_bf).Size = new Size(176, 21);
		((Control)this.m_bf).TabIndex = 11;
		((Control)this.m_bf).Text = "None";
		this.m_bf.SelectedIndexChanged += fx;
		((Control)this.m_bf).KeyDown += e;
		((Control)this.m_bg).Location = new Point(3, 3);
		((Control)this.m_bg).Name = "label24";
		((Control)this.m_bg).Size = new Size(264, 16);
		((Control)this.m_bg).TabIndex = 81;
		((Control)this.m_bg).Text = "Initial Player Portrait:";
		((Control)this.m_be).Anchor = (AnchorStyles)15;
		((Control)this.m_be).BackgroundImageLayout = (ImageLayout)4;
		this.m_be.BorderStyle = (BorderStyle)1;
		((Control)this.m_be).Location = new Point(6, 48);
		((Control)this.m_be).Name = "PlayerPic";
		((Control)this.m_be).Size = new Size(420, 333);
		this.m_be.SizeMode = (PictureBoxSizeMode)4;
		this.m_be.TabIndex = 83;
		this.m_be.TabStop = false;
		((Control)this.m_be).Paint += a;
		((Control)this.m_ea).Anchor = (AnchorStyles)6;
		((Control)this.m_ea).Location = new Point(122, 503);
		((Control)this.m_ea).Name = "btnRemovePlayerObjects";
		((Control)this.m_ea).Size = new Size(102, 23);
		((Control)this.m_ea).TabIndex = 9;
		((Control)this.m_ea).Text = "Remove Objects";
		((ButtonBase)this.m_ea).UseVisualStyleBackColor = true;
		((Control)this.m_ea).Click += er;
		((Control)this.m_bj).Controls.Add((Control)(object)this.m_bk);
		((Control)this.m_bj).Controls.Add((Control)(object)this.m_bl);
		((Control)this.m_bj).Controls.Add((Control)(object)this.m_bm);
		((Control)this.m_bj).Location = new Point(6, 74);
		((Control)this.m_bj).Name = "GenderBox";
		((Control)this.m_bj).Size = new Size(120, 96);
		((Control)this.m_bj).TabIndex = 3;
		this.m_bj.TabStop = false;
		((Control)this.m_bj).Text = "Player Gender";
		((Control)this.m_bk).Location = new Point(8, 64);
		((Control)this.m_bk).Name = "radioButton3";
		((Control)this.m_bk).Size = new Size(104, 24);
		((Control)this.m_bk).TabIndex = 13;
		((Control)this.m_bk).Text = "Other";
		((Control)this.m_bk).Leave += fy;
		((Control)this.m_bl).Location = new Point(8, 40);
		((Control)this.m_bl).Name = "radioButton2";
		((Control)this.m_bl).Size = new Size(104, 24);
		((Control)this.m_bl).TabIndex = 12;
		((Control)this.m_bl).Text = "Female";
		((Control)this.m_bl).Leave += fy;
		((Control)this.m_bm).Location = new Point(8, 16);
		((Control)this.m_bm).Name = "radioButton1";
		((Control)this.m_bm).Size = new Size(104, 24);
		((Control)this.m_bm).TabIndex = 11;
		((Control)this.m_bm).Text = "Male";
		((Control)this.m_bm).Leave += fy;
		((Control)this.m_ca).Anchor = (AnchorStyles)6;
		((Control)this.m_ca).Location = new Point(6, 503);
		((Control)this.m_ca).Name = "btnAddInventory";
		((Control)this.m_ca).Size = new Size(100, 23);
		((Control)this.m_ca).TabIndex = 8;
		((Control)this.m_ca).Text = "Assign Objects";
		((ButtonBase)this.m_ca).UseVisualStyleBackColor = true;
		((Control)this.m_ca).Click += fd;
		((Control)this.m_bi).Location = new Point(6, 250);
		((Control)this.m_bi).Name = "cbPlayerStartRoom";
		((Control)this.m_bi).Size = new Size(121, 21);
		((Control)this.m_bi).TabIndex = 6;
		((Control)this.m_bi).Leave += f1;
		((Control)this.m_cc).AllowDrop = true;
		((Control)this.m_cc).Anchor = (AnchorStyles)7;
		((Control)this.m_cc).ContextMenuStrip = this.m_eb;
		this.m_cc.HorizontalScrollbar = true;
		((Control)this.m_cc).Location = new Point(6, 296);
		((Control)this.m_cc).Name = "lbPlayerInventory";
		this.m_cc.ScrollAlwaysVisible = true;
		this.m_cc.SelectionMode = (SelectionMode)3;
		((Control)this.m_cc).Size = new Size(218, 173);
		((Control)this.m_cc).TabIndex = 7;
		((Control)this.m_cc).DragDrop += r;
		((Control)this.m_cc).DragOver += s;
		((Control)this.m_bo).Location = new Point(6, 4);
		((Control)this.m_bo).Name = "cbPlayerPromptForName";
		((Control)this.m_bo).Size = new Size(224, 16);
		((Control)this.m_bo).TabIndex = 0;
		((Control)this.m_bo).Text = "Prompt For Player Name At Game Start";
		((Control)this.m_bo).Leave += f0;
		((Control)this.m_cb).Location = new Point(5, 277);
		((Control)this.m_cb).Name = "label36";
		((Control)this.m_cb).Size = new Size(100, 16);
		((Control)this.m_cb).TabIndex = 85;
		((Control)this.m_cb).Text = "Initial Inventory:";
		((Control)this.m_bh).Location = new Point(6, 234);
		((Control)this.m_bh).Name = "label23";
		((Control)this.m_bh).Size = new Size(117, 16);
		((Control)this.m_bh).TabIndex = 80;
		((Control)this.m_bh).Text = "Player Starting Room:";
		((Control)this.m_bq).Location = new Point(5, 28);
		((Control)this.m_bq).Name = "label2";
		((Control)this.m_bq).Size = new Size(74, 20);
		((Control)this.m_bq).TabIndex = 2;
		((Control)this.m_bq).Text = "Player Name:";
		((Control)this.m_bp).Location = new Point(79, 28);
		((Control)this.m_bp).Name = "txtPlayerName";
		((Control)this.m_bp).Size = new Size(145, 20);
		((Control)this.m_bp).TabIndex = 1;
		((Control)this.m_bp).Enter += af;
		((Control)this.m_bp).Leave += f2;
		((Control)this.m_bn).Location = new Point(6, 46);
		((Control)this.m_bn).Name = "cbPlayerPromptForGender";
		((Control)this.m_bn).Size = new Size(232, 32);
		((Control)this.m_bn).TabIndex = 2;
		((Control)this.m_bn).Text = "Prompt For Player Gender At Game Start";
		((Control)this.m_bn).Leave += fz;
		((Control)kv).Controls.Add((Control)(object)mc);
		((Control)kv).Controls.Add((Control)(object)kw);
		kv.Location = new Point(4, 4);
		((Control)kv).Name = "tabPage17";
		((Control)kv).Padding = new Padding(3);
		((Control)kv).Size = new Size(671, 532);
		kv.TabIndex = 2;
		((Control)kv).Text = "Custom Properties";
		kv.UseVisualStyleBackColor = true;
		((Control)mc).Anchor = (AnchorStyles)9;
		mc.Image = (Image)componentResourceManager.GetObject("pictureBox21.Image");
		((Control)mc).Location = new Point(565, 3);
		((Control)mc).Name = "pictureBox21";
		((Control)mc).Size = new Size(100, 30);
		mc.TabIndex = 101;
		mc.TabStop = false;
		((Control)kw).Anchor = (AnchorStyles)15;
		((Control)kw).Controls.Add((Control)(object)kx);
		((Control)kw).Controls.Add((Control)(object)ky);
		((Control)kw).Controls.Add((Control)(object)kz);
		((Control)kw).Controls.Add((Control)(object)k0);
		((Control)kw).Controls.Add((Control)(object)k1);
		((Control)kw).Controls.Add((Control)(object)k2);
		((Control)kw).Controls.Add((Control)(object)k3);
		((Control)kw).Controls.Add((Control)(object)k4);
		((Control)kw).Location = new Point(6, 39);
		((Control)kw).Name = "groupBox7";
		((Control)kw).Size = new Size(659, 493);
		((Control)kw).TabIndex = 0;
		kw.TabStop = false;
		((Control)kw).Text = "Custom Properties";
		((Control)kx).Anchor = (AnchorStyles)6;
		((Control)kx).AutoSize = true;
		((Control)kx).Location = new Point(6, 422);
		((Control)kx).Name = "label67";
		((Control)kx).Size = new Size(79, 13);
		((Control)kx).TabIndex = 105;
		((Control)kx).Text = "Property Value:";
		((Control)ky).Anchor = (AnchorStyles)6;
		((Control)ky).Location = new Point(9, 438);
		((Control)ky).Name = "tbPlayerPropertyValue";
		((Control)ky).Size = new Size(295, 20);
		((Control)ky).TabIndex = 3;
		((Control)ky).Enter += af;
		((Control)kz).Anchor = (AnchorStyles)6;
		((Control)kz).AutoSize = true;
		((Control)kz).Location = new Point(6, 378);
		((Control)kz).Name = "label70";
		((Control)kz).Size = new Size(80, 13);
		((Control)kz).TabIndex = 103;
		((Control)kz).Text = "Property Name:";
		((Control)k0).Anchor = (AnchorStyles)6;
		((Control)k0).Location = new Point(9, 394);
		((Control)k0).Name = "tbPlayerPropertyName";
		((Control)k0).Size = new Size(295, 20);
		((Control)k0).TabIndex = 2;
		((Control)k0).Enter += af;
		((Control)k1).Anchor = (AnchorStyles)6;
		((Control)k1).Location = new Point(206, 464);
		((Control)k1).Name = "btnDeletePlayerCustProp";
		((Control)k1).Size = new Size(91, 23);
		((Control)k1).TabIndex = 6;
		((Control)k1).Text = "Delete Property";
		((ButtonBase)k1).UseVisualStyleBackColor = true;
		((Control)k1).Click += a6;
		((Control)k2).Anchor = (AnchorStyles)6;
		((Control)k2).Location = new Point(98, 464);
		((Control)k2).Name = "btnUpdatePlayerCustProp";
		((Control)k2).Size = new Size(102, 23);
		((Control)k2).TabIndex = 5;
		((Control)k2).Text = "Update Property";
		((ButtonBase)k2).UseVisualStyleBackColor = true;
		((Control)k2).Click += a7;
		((Control)k3).Anchor = (AnchorStyles)6;
		((Control)k3).Location = new Point(9, 464);
		((Control)k3).Name = "btnAddPlayerCustProp";
		((Control)k3).Size = new Size(83, 23);
		((Control)k3).TabIndex = 4;
		((Control)k3).Text = "Add Property";
		((ButtonBase)k3).UseVisualStyleBackColor = true;
		((Control)k3).Click += a8;
		k4.AllowUserToAddRows = false;
		k4.AllowUserToDeleteRows = false;
		((Control)k4).Anchor = (AnchorStyles)15;
		k4.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		k4.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)k5,
			(DataGridViewColumn)k6
		});
		((Control)k4).Location = new Point(9, 19);
		k4.MultiSelect = false;
		((Control)k4).Name = "dgvPlayerCustomProperties";
		k4.ReadOnly = true;
		k4.RowHeadersWidth = 4;
		k4.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)k4).Size = new Size(644, 356);
		((Control)k4).TabIndex = 1;
		k4.SelectionChanged += a9;
		((DataGridViewColumn)k5).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)k5).HeaderText = "Name";
		((DataGridViewColumn)k5).Name = "dataGridViewTextBoxColumn3";
		((DataGridViewBand)k5).ReadOnly = true;
		((DataGridViewColumn)k6).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)k6).HeaderText = "Value";
		((DataGridViewColumn)k6).Name = "dataGridViewTextBoxColumn4";
		((DataGridViewBand)k6).ReadOnly = true;
		((Control)this.m_et).Controls.Add((Control)(object)PlayerActions);
		((Control)this.m_et).Controls.Add((Control)(object)this.m_e7);
		this.m_et.Location = new Point(4, 4);
		((Control)this.m_et).Name = "tabPage10";
		((Control)this.m_et).Padding = new Padding(3);
		((Control)this.m_et).Size = new Size(671, 532);
		this.m_et.TabIndex = 1;
		((Control)this.m_et).Text = "Actions";
		this.m_et.UseVisualStyleBackColor = true;
		((Control)PlayerActions).Anchor = (AnchorStyles)15;
		((Control)PlayerActions).AutoSize = true;
		((Control)PlayerActions).Location = new Point(3, 39);
		((Control)PlayerActions).Name = "PlayerActions";
		((Control)PlayerActions).Size = new Size(662, 490);
		((Control)PlayerActions).TabIndex = 97;
		((Control)this.m_e7).Anchor = (AnchorStyles)9;
		this.m_e7.Image = (Image)componentResourceManager.GetObject("pictureBox7.Image");
		((Control)this.m_e7).Location = new Point(568, 3);
		((Control)this.m_e7).Name = "pictureBox7";
		((Control)this.m_e7).Size = new Size(100, 30);
		this.m_e7.TabIndex = 96;
		this.m_e7.TabStop = false;
		((Control)this.m_br).Controls.Add((Control)(object)tabControl3);
		this.m_br.Location = new Point(4, 4);
		((Control)this.m_br).Name = "tabPage4";
		((Control)this.m_br).Size = new Size(679, 558);
		this.m_br.TabIndex = 3;
		((Control)this.m_br).Text = "Objects";
		this.m_br.UseVisualStyleBackColor = true;
		this.m_br.Visible = false;
		tabControl3.Alignment = (TabAlignment)1;
		((Control)tabControl3).Controls.Add((Control)(object)this.m_dh);
		((Control)tabControl3).Controls.Add((Control)(object)k7);
		((Control)tabControl3).Controls.Add((Control)(object)jc);
		((Control)tabControl3).Controls.Add((Control)(object)this.m_d6);
		((Control)tabControl3).Dock = (DockStyle)5;
		((Control)tabControl3).Location = new Point(0, 0);
		((Control)tabControl3).Name = "tabControl3";
		tabControl3.SelectedIndex = 0;
		((Control)tabControl3).Size = new Size(679, 558);
		((Control)tabControl3).TabIndex = 0;
		tabControl3.Selected += a;
		((Control)this.m_dh).Controls.Add((Control)(object)i8);
		((Control)this.m_dh).Controls.Add((Control)(object)i9);
		((Control)this.m_dh).Controls.Add((Control)(object)h5);
		((Control)this.m_dh).Controls.Add((Control)(object)h6);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d1);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_e8);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_ej);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_ei);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_di);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_dj);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_dk);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_dz);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d0);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d2);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d3);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d4);
		((Control)this.m_dh).Controls.Add((Control)(object)this.m_d5);
		this.m_dh.Location = new Point(4, 4);
		((Control)this.m_dh).Name = "tabPage6";
		((Control)this.m_dh).Size = new Size(671, 532);
		this.m_dh.TabIndex = 0;
		((Control)this.m_dh).Text = "General";
		this.m_dh.UseVisualStyleBackColor = true;
		((Control)i8).Anchor = (AnchorStyles)13;
		((Control)i8).Location = new Point(121, 53);
		((Control)i8).Name = "tbObjectID";
		((TextBoxBase)i8).ReadOnly = true;
		((Control)i8).Size = new Size(381, 20);
		((Control)i8).TabIndex = 2;
		((Control)i9).Location = new Point(4, 53);
		((Control)i9).Name = "label53";
		((Control)i9).Size = new Size(132, 20);
		((Control)i9).TabIndex = 99;
		((Control)i9).Text = "Object ID:";
		((Control)h5).Anchor = (AnchorStyles)13;
		((Control)h5).Location = new Point(121, 76);
		((Control)h5).Name = "tbObjectPreposition";
		((Control)h5).Size = new Size(381, 20);
		((Control)h5).TabIndex = 3;
		((Control)h5).DoubleClick += ao;
		((Control)h5).Enter += af;
		((Control)h5).KeyDown += e;
		((Control)h5).Leave += co;
		((Control)h6).Location = new Point(4, 76);
		((Control)h6).Name = "label40";
		((Control)h6).Size = new Size(132, 20);
		((Control)h6).TabIndex = 97;
		((Control)h6).Text = "Object Preposition:";
		((Control)this.m_d1).Anchor = (AnchorStyles)13;
		((Control)this.m_d1).Location = new Point(121, 99);
		((Control)this.m_d1).Name = "txtObjectSDesc";
		((Control)this.m_d1).Size = new Size(381, 20);
		((Control)this.m_d1).TabIndex = 4;
		((Control)this.m_d1).DoubleClick += ao;
		((Control)this.m_d1).Enter += af;
		((Control)this.m_d1).KeyDown += e;
		((Control)this.m_d1).Leave += fq;
		((Control)this.m_e8).Anchor = (AnchorStyles)9;
		this.m_e8.Image = (Image)componentResourceManager.GetObject("pictureBox8.Image");
		((Control)this.m_e8).Location = new Point(568, 3);
		((Control)this.m_e8).Name = "pictureBox8";
		((Control)this.m_e8).Size = new Size(100, 30);
		this.m_e8.TabIndex = 96;
		this.m_e8.TabStop = false;
		((Control)this.m_ej).Anchor = (AnchorStyles)10;
		((Control)this.m_ej).Enabled = false;
		((Control)this.m_ej).Location = new Point(508, 496);
		((Control)this.m_ej).Name = "btnRemoveContainedObjects";
		((Control)this.m_ej).Size = new Size(160, 24);
		((Control)this.m_ej).TabIndex = 9;
		((Control)this.m_ej).Text = "Remove Items From Object";
		((ButtonBase)this.m_ej).UseVisualStyleBackColor = true;
		((Control)this.m_ej).Click += ep;
		((Control)this.m_ei).Anchor = (AnchorStyles)10;
		((Control)this.m_ei).Enabled = false;
		((Control)this.m_ei).Location = new Point(508, 463);
		((Control)this.m_ei).Name = "btnAddContainedObjects";
		((Control)this.m_ei).Size = new Size(160, 24);
		((Control)this.m_ei).TabIndex = 8;
		((Control)this.m_ei).Text = "Put Items In Object";
		((ButtonBase)this.m_ei).UseVisualStyleBackColor = true;
		((Control)this.m_ei).Click += eq;
		((Control)this.m_di).Anchor = (AnchorStyles)9;
		((Control)this.m_di).AutoSize = true;
		((Control)this.m_di).Location = new Point(505, 39);
		((Control)this.m_di).Name = "label38";
		((Control)this.m_di).Size = new Size(97, 13);
		((Control)this.m_di).TabIndex = 9;
		((Control)this.m_di).Text = "Objects Contained:";
		((Control)this.m_dj).AllowDrop = true;
		((Control)this.m_dj).Anchor = (AnchorStyles)11;
		((Control)this.m_dj).Enabled = false;
		((ListControl)this.m_dj).FormattingEnabled = true;
		this.m_dj.HorizontalScrollbar = true;
		((Control)this.m_dj).Location = new Point(508, 55);
		((Control)this.m_dj).Name = "lbContainedObjects";
		this.m_dj.SelectionMode = (SelectionMode)3;
		((Control)this.m_dj).Size = new Size(161, 381);
		((Control)this.m_dj).TabIndex = 7;
		((Control)this.m_dj).DragDrop += m;
		((Control)this.m_dj).DragOver += s;
		((Control)this.m_dj).MouseDown += m;
		((Control)this.m_dj).MouseEnter += e4;
		((Control)this.m_dk).Anchor = (AnchorStyles)6;
		((Control)this.m_dk).Controls.Add((Control)(object)oa);
		((Control)this.m_dk).Controls.Add((Control)(object)hg);
		((Control)this.m_dk).Controls.Add((Control)(object)g6);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_ey);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dl);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_do);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dr);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_ds);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dt);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_du);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dv);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dw);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dx);
		((Control)this.m_dk).Controls.Add((Control)(object)this.m_dy);
		((Control)this.m_dk).Location = new Point(19, 292);
		((Control)this.m_dk).Name = "groupBox1";
		((Control)this.m_dk).Size = new Size(428, 237);
		((Control)this.m_dk).TabIndex = 6;
		this.m_dk.TabStop = false;
		((Control)this.m_dk).Text = "Attributes";
		((Control)oa).AutoSize = true;
		((Control)oa).Location = new Point(6, 19);
		((Control)oa).Name = "cbImportant";
		((Control)oa).Size = new Size(253, 17);
		((Control)oa).TabIndex = 0;
		((Control)oa).Text = "Important Item (Appear At The Top Of The Lists)";
		((ButtonBase)oa).UseVisualStyleBackColor = true;
		oa.CheckedChanged += l;
		((Control)hg).Controls.Add((Control)(object)hh);
		((Control)hg).Controls.Add((Control)(object)hi);
		((Control)hg).Location = new Point(111, 178);
		((Control)hg).Name = "groupBox2";
		((Control)hg).Size = new Size(293, 37);
		((Control)hg).TabIndex = 12;
		hg.TabStop = false;
		((Control)hg).Text = "Current Visible State:";
		((Control)hg).Leave += c0;
		((Control)hh).AutoSize = true;
		((Control)hh).Location = new Point(132, 15);
		((Control)hh).Name = "rbInvisible";
		((Control)hh).Size = new Size(63, 17);
		((Control)hh).TabIndex = 1;
		((Control)hh).Text = "Invisible";
		((ButtonBase)hh).UseVisualStyleBackColor = true;
		((Control)hi).AutoSize = true;
		hi.Checked = true;
		((Control)hi).Location = new Point(12, 15);
		((Control)hi).Name = "rbVisible";
		((Control)hi).Size = new Size(55, 17);
		((Control)hi).TabIndex = 0;
		hi.TabStop = true;
		((Control)hi).Text = "Visible";
		((ButtonBase)hi).UseVisualStyleBackColor = true;
		((Control)g6).AutoSize = true;
		((Control)g6).Location = new Point(6, 89);
		((Control)g6).Name = "cbObjectContainer";
		((Control)g6).RightToLeft = (RightToLeft)0;
		((Control)g6).Size = new Size(71, 17);
		((Control)g6).TabIndex = 3;
		((Control)g6).Text = "Container";
		((ButtonBase)g6).UseVisualStyleBackColor = true;
		g6.CheckedChanged += da;
		((Control)g6).Leave += c9;
		((Control)this.m_ey).Controls.Add((Control)(object)this.m_ez);
		((Control)this.m_ey).Controls.Add((Control)(object)this.m_e0);
		((Control)this.m_ey).Enabled = false;
		((Control)this.m_ey).Location = new Point(111, 87);
		((Control)this.m_ey).Name = "gbCurrentWornState";
		((Control)this.m_ey).Size = new Size(293, 37);
		((Control)this.m_ey).TabIndex = 10;
		this.m_ey.TabStop = false;
		((Control)this.m_ey).Text = "Current Wearable State:";
		((Control)this.m_ey).Leave += eg;
		((Control)this.m_ez).AutoSize = true;
		this.m_ez.Checked = true;
		((Control)this.m_ez).Location = new Point(132, 15);
		((Control)this.m_ez).Name = "rbRemoved";
		((Control)this.m_ez).Size = new Size(71, 17);
		((Control)this.m_ez).TabIndex = 1;
		this.m_ez.TabStop = true;
		((Control)this.m_ez).Text = "Removed";
		((ButtonBase)this.m_ez).UseVisualStyleBackColor = true;
		((Control)this.m_e0).AutoSize = true;
		((Control)this.m_e0).Location = new Point(12, 15);
		((Control)this.m_e0).Name = "rbWorn";
		((Control)this.m_e0).Size = new Size(51, 17);
		((Control)this.m_e0).TabIndex = 0;
		((Control)this.m_e0).Text = "Worn";
		((ButtonBase)this.m_e0).UseVisualStyleBackColor = true;
		((Control)this.m_dl).Controls.Add((Control)(object)this.m_dm);
		((Control)this.m_dl).Controls.Add((Control)(object)this.m_dn);
		((Control)this.m_dl).Enabled = false;
		((Control)this.m_dl).Location = new Point(111, 135);
		((Control)this.m_dl).Name = "gbCurrentLockState";
		((Control)this.m_dl).Size = new Size(293, 37);
		((Control)this.m_dl).TabIndex = 11;
		this.m_dl.TabStop = false;
		((Control)this.m_dl).Text = "Current Locked State:";
		((Control)this.m_dm).AutoSize = true;
		((Control)this.m_dm).Location = new Point(132, 15);
		((Control)this.m_dm).Name = "rbUnlocked";
		((Control)this.m_dm).Size = new Size(71, 17);
		((Control)this.m_dm).TabIndex = 1;
		((Control)this.m_dm).Text = "Unlocked";
		((ButtonBase)this.m_dm).UseVisualStyleBackColor = true;
		((Control)this.m_dn).AutoSize = true;
		this.m_dn.Checked = true;
		((Control)this.m_dn).Location = new Point(12, 15);
		((Control)this.m_dn).Name = "rbLocked";
		((Control)this.m_dn).Size = new Size(61, 17);
		((Control)this.m_dn).TabIndex = 0;
		this.m_dn.TabStop = true;
		((Control)this.m_dn).Text = "Locked";
		((ButtonBase)this.m_dn).UseVisualStyleBackColor = true;
		((Control)this.m_dn).Leave += e6;
		((Control)this.m_do).Controls.Add((Control)(object)this.m_dp);
		((Control)this.m_do).Controls.Add((Control)(object)this.m_dq);
		((Control)this.m_do).Enabled = false;
		((Control)this.m_do).Location = new Point(111, 39);
		((Control)this.m_do).Name = "gbCurrentOpenState";
		((Control)this.m_do).Size = new Size(293, 37);
		((Control)this.m_do).TabIndex = 9;
		this.m_do.TabStop = false;
		((Control)this.m_do).Text = "Current Open State:";
		((Control)this.m_dp).AutoSize = true;
		((Control)this.m_dp).Location = new Point(132, 15);
		((Control)this.m_dp).Name = "rbClosed";
		((Control)this.m_dp).Size = new Size(57, 17);
		((Control)this.m_dp).TabIndex = 1;
		((Control)this.m_dp).Text = "Closed";
		((ButtonBase)this.m_dp).UseVisualStyleBackColor = true;
		((Control)this.m_dp).Leave += e7;
		((Control)this.m_dq).AutoSize = true;
		this.m_dq.Checked = true;
		((Control)this.m_dq).Location = new Point(12, 15);
		((Control)this.m_dq).Name = "rbOpen";
		((Control)this.m_dq).Size = new Size(51, 17);
		((Control)this.m_dq).TabIndex = 0;
		this.m_dq.TabStop = true;
		((Control)this.m_dq).Text = "Open";
		((ButtonBase)this.m_dq).UseVisualStyleBackColor = true;
		((Control)this.m_dq).Leave += e7;
		((Control)this.m_dr).Location = new Point(49, 204);
		((Control)this.m_dr).Name = "txtWeight";
		((Control)this.m_dr).Size = new Size(45, 20);
		((Control)this.m_dr).TabIndex = 8;
		((Control)this.m_dr).Leave += fh;
		((Control)this.m_ds).AutoSize = true;
		((Control)this.m_ds).Location = new Point(5, 209);
		((Control)this.m_ds).Name = "label29";
		((Control)this.m_ds).Size = new Size(44, 13);
		((Control)this.m_ds).TabIndex = 6;
		((Control)this.m_ds).Text = "Weight:";
		((Control)this.m_dt).AutoSize = true;
		((Control)this.m_dt).Location = new Point(6, 181);
		((Control)this.m_dt).Name = "cbObjectReadable";
		((Control)this.m_dt).RightToLeft = (RightToLeft)0;
		((Control)this.m_dt).Size = new Size(72, 17);
		((Control)this.m_dt).TabIndex = 7;
		((Control)this.m_dt).Text = "Readable";
		((ButtonBase)this.m_dt).UseVisualStyleBackColor = true;
		((Control)this.m_dt).Leave += fi;
		((Control)this.m_du).AutoSize = true;
		((Control)this.m_du).Location = new Point(6, 158);
		((Control)this.m_du).Name = "cbObjectEnterable";
		((Control)this.m_du).RightToLeft = (RightToLeft)0;
		((Control)this.m_du).Size = new Size(71, 17);
		((Control)this.m_du).TabIndex = 6;
		((Control)this.m_du).Text = "Enterable";
		((ButtonBase)this.m_du).UseVisualStyleBackColor = true;
		((Control)this.m_du).Leave += fj;
		((Control)this.m_dv).AutoSize = true;
		((Control)this.m_dv).Location = new Point(6, 135);
		((Control)this.m_dv).Name = "cbObjectLockable";
		((Control)this.m_dv).RightToLeft = (RightToLeft)0;
		((Control)this.m_dv).Size = new Size(70, 17);
		((Control)this.m_dv).TabIndex = 5;
		((Control)this.m_dv).Text = "Lockable";
		((ButtonBase)this.m_dv).UseVisualStyleBackColor = true;
		this.m_dv.CheckedChanged += e8;
		((Control)this.m_dv).Leave += fk;
		((Control)this.m_dw).AutoSize = true;
		((Control)this.m_dw).Location = new Point(6, 112);
		((Control)this.m_dw).Name = "cbObjectOpenable";
		((Control)this.m_dw).RightToLeft = (RightToLeft)0;
		((Control)this.m_dw).Size = new Size(72, 17);
		((Control)this.m_dw).TabIndex = 4;
		((Control)this.m_dw).Text = "Openable";
		((ButtonBase)this.m_dw).UseVisualStyleBackColor = true;
		this.m_dw.CheckedChanged += e9;
		((Control)this.m_dw).Leave += fl;
		((Control)this.m_dx).AutoSize = true;
		((Control)this.m_dx).Location = new Point(6, 66);
		((Control)this.m_dx).Name = "cbObjectWearable";
		((Control)this.m_dx).RightToLeft = (RightToLeft)0;
		((Control)this.m_dx).Size = new Size(72, 17);
		((Control)this.m_dx).TabIndex = 2;
		((Control)this.m_dx).Text = "Wearable";
		((ButtonBase)this.m_dx).UseVisualStyleBackColor = true;
		this.m_dx.CheckedChanged += ef;
		((Control)this.m_dx).Leave += fm;
		((Control)this.m_dy).AutoSize = true;
		((Control)this.m_dy).Location = new Point(6, 43);
		((Control)this.m_dy).Name = "cbObjectCarryable";
		((Control)this.m_dy).RightToLeft = (RightToLeft)0;
		((Control)this.m_dy).Size = new Size(70, 17);
		((Control)this.m_dy).TabIndex = 1;
		((Control)this.m_dy).Text = "Carryable";
		((ButtonBase)this.m_dy).UseVisualStyleBackColor = true;
		((Control)this.m_dy).Leave += fn;
		((Control)this.m_dz).Anchor = (AnchorStyles)15;
		((Control)this.m_dz).Location = new Point(121, 122);
		((TextBoxBase)this.m_dz).Multiline = true;
		((Control)this.m_dz).Name = "txtObjectDescription";
		((Control)this.m_dz).Size = new Size(381, 164);
		((Control)this.m_dz).TabIndex = 5;
		((Control)this.m_dz).DoubleClick += ao;
		((Control)this.m_dz).Enter += af;
		((Control)this.m_dz).KeyDown += e;
		((Control)this.m_dz).Leave += fp;
		((Control)this.m_d0).Location = new Point(4, 122);
		((Control)this.m_d0).Name = "label28";
		((Control)this.m_d0).Size = new Size(104, 16);
		((Control)this.m_d0).TabIndex = 5;
		((Control)this.m_d0).Text = "Description:";
		((Control)this.m_d2).Location = new Point(4, 99);
		((Control)this.m_d2).Name = "label27";
		((Control)this.m_d2).Size = new Size(132, 20);
		((Control)this.m_d2).TabIndex = 3;
		((Control)this.m_d2).Text = "Display Name Override:";
		((Control)this.m_d3).Anchor = (AnchorStyles)13;
		((Control)this.m_d3).Location = new Point(121, 30);
		((Control)this.m_d3).Name = "txtObjectName";
		((TextBoxBase)this.m_d3).ReadOnly = true;
		((Control)this.m_d3).Size = new Size(381, 20);
		((Control)this.m_d3).TabIndex = 1;
		((Control)this.m_d4).Location = new Point(4, 32);
		((Control)this.m_d4).Name = "label26";
		((Control)this.m_d4).Size = new Size(80, 16);
		((Control)this.m_d4).TabIndex = 1;
		((Control)this.m_d4).Text = "Object Name:";
		((Control)this.m_d5).Location = new Point(4, 3);
		((Control)this.m_d5).Name = "button1";
		((Control)this.m_d5).Size = new Size(75, 23);
		((Control)this.m_d5).TabIndex = 0;
		((Control)this.m_d5).Text = "Add Object";
		((Control)this.m_d5).Click += fr;
		((Control)k7).Controls.Add((Control)(object)lv);
		((Control)k7).Controls.Add((Control)(object)k8);
		k7.Location = new Point(4, 4);
		((Control)k7).Name = "tabPage18";
		((Control)k7).Padding = new Padding(3);
		((Control)k7).Size = new Size(671, 532);
		k7.TabIndex = 4;
		((Control)k7).Text = "Custom Properties";
		k7.UseVisualStyleBackColor = true;
		((Control)lv).Anchor = (AnchorStyles)9;
		lv.Image = (Image)componentResourceManager.GetObject("pictureBox19.Image");
		((Control)lv).Location = new Point(568, 3);
		((Control)lv).Name = "pictureBox19";
		((Control)lv).Size = new Size(100, 30);
		lv.TabIndex = 102;
		lv.TabStop = false;
		((Control)k8).Anchor = (AnchorStyles)15;
		((Control)k8).Controls.Add((Control)(object)k9);
		((Control)k8).Controls.Add((Control)(object)la);
		((Control)k8).Controls.Add((Control)(object)lb);
		((Control)k8).Controls.Add((Control)(object)lc);
		((Control)k8).Controls.Add((Control)(object)ld);
		((Control)k8).Controls.Add((Control)(object)le);
		((Control)k8).Controls.Add((Control)(object)lf);
		((Control)k8).Controls.Add((Control)(object)lg);
		((Control)k8).Location = new Point(6, 39);
		((Control)k8).Name = "groupBox8";
		((Control)k8).Size = new Size(659, 490);
		((Control)k8).TabIndex = 0;
		k8.TabStop = false;
		((Control)k8).Text = "Custom Properties";
		((Control)k9).Anchor = (AnchorStyles)6;
		((Control)k9).AutoSize = true;
		((Control)k9).Location = new Point(6, 419);
		((Control)k9).Name = "label71";
		((Control)k9).Size = new Size(79, 13);
		((Control)k9).TabIndex = 105;
		((Control)k9).Text = "Property Value:";
		((Control)la).Anchor = (AnchorStyles)6;
		((Control)la).Location = new Point(9, 435);
		((Control)la).Name = "tbObjectValue";
		((Control)la).Size = new Size(295, 20);
		((Control)la).TabIndex = 2;
		((Control)la).DoubleClick += ao;
		((Control)la).Enter += af;
		((Control)lb).Anchor = (AnchorStyles)6;
		((Control)lb).AutoSize = true;
		((Control)lb).Location = new Point(6, 375);
		((Control)lb).Name = "label72";
		((Control)lb).Size = new Size(80, 13);
		((Control)lb).TabIndex = 103;
		((Control)lb).Text = "Property Name:";
		((Control)lc).Anchor = (AnchorStyles)6;
		((Control)lc).Location = new Point(9, 391);
		((Control)lc).Name = "tbObjectPropName";
		((Control)lc).Size = new Size(295, 20);
		((Control)lc).TabIndex = 1;
		((Control)lc).Enter += af;
		((Control)ld).Anchor = (AnchorStyles)6;
		((Control)ld).Location = new Point(206, 461);
		((Control)ld).Name = "btnObjectDeleteProperty";
		((Control)ld).Size = new Size(91, 23);
		((Control)ld).TabIndex = 5;
		((Control)ld).Text = "Delete Property";
		((ButtonBase)ld).UseVisualStyleBackColor = true;
		((Control)ld).Click += a3;
		((Control)le).Anchor = (AnchorStyles)6;
		((Control)le).Location = new Point(98, 461);
		((Control)le).Name = "btnObjectUpdateProperty";
		((Control)le).Size = new Size(102, 23);
		((Control)le).TabIndex = 4;
		((Control)le).Text = "Update Property";
		((ButtonBase)le).UseVisualStyleBackColor = true;
		((Control)le).Click += a4;
		((Control)lf).Anchor = (AnchorStyles)6;
		((Control)lf).Location = new Point(9, 461);
		((Control)lf).Name = "btnObjectAddProperty";
		((Control)lf).Size = new Size(83, 23);
		((Control)lf).TabIndex = 3;
		((Control)lf).Text = "Add Property";
		((ButtonBase)lf).UseVisualStyleBackColor = true;
		((Control)lf).Click += a5;
		lg.AllowUserToAddRows = false;
		lg.AllowUserToDeleteRows = false;
		((Control)lg).Anchor = (AnchorStyles)15;
		lg.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		lg.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)lh,
			(DataGridViewColumn)li
		});
		((Control)lg).Location = new Point(9, 19);
		lg.MultiSelect = false;
		((Control)lg).Name = "dgvObjectProperties";
		lg.ReadOnly = true;
		lg.RowHeadersWidth = 4;
		lg.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)lg).Size = new Size(644, 353);
		((Control)lg).TabIndex = 0;
		lg.SelectionChanged += a2;
		((DataGridViewColumn)lh).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)lh).HeaderText = "Name";
		((DataGridViewColumn)lh).Name = "dataGridViewTextBoxColumn5";
		((DataGridViewBand)lh).ReadOnly = true;
		((DataGridViewColumn)li).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)li).HeaderText = "Value";
		((DataGridViewColumn)li).Name = "dataGridViewTextBoxColumn6";
		((DataGridViewBand)li).ReadOnly = true;
		((Control)jc).Controls.Add((Control)(object)jd);
		jc.Location = new Point(4, 4);
		((Control)jc).Name = "tabPage14";
		((Control)jc).Padding = new Padding(3);
		((Control)jc).Size = new Size(671, 532);
		jc.TabIndex = 3;
		((Control)jc).Text = "Layered Clothing";
		jc.UseVisualStyleBackColor = true;
		((Control)jd).Controls.Add((Control)(object)jx);
		((Control)jd).Controls.Add((Control)(object)jw);
		((Control)jd).Controls.Add((Control)(object)jv);
		((Control)jd).Controls.Add((Control)(object)ju);
		((Control)jd).Controls.Add((Control)(object)jq);
		((Control)jd).Controls.Add((Control)(object)jj);
		((Control)jd).Controls.Add((Control)(object)je);
		((Control)jd).Controls.Add((Control)(object)jf);
		((Control)jd).Dock = (DockStyle)5;
		((Control)jd).Location = new Point(3, 3);
		((Control)jd).Name = "PanelLayeredClothing";
		((Control)jd).Size = new Size(665, 526);
		((Control)jd).TabIndex = 0;
		((Control)jx).Anchor = (AnchorStyles)15;
		((Control)jx).Location = new Point(347, 199);
		((Control)jx).Name = "label60";
		((Control)jx).Size = new Size(186, 324);
		((Control)jx).TabIndex = 110;
		((Control)jx).Text = componentResourceManager.GetString("label60.Text");
		((Control)jw).Anchor = (AnchorStyles)11;
		jw.Image = (Image)(object)Resources.testrender;
		((Control)jw).Location = new Point(539, 199);
		((Control)jw).Name = "pictureBox16";
		((Control)jw).Size = new Size(126, 324);
		jw.SizeMode = (PictureBoxSizeMode)4;
		jw.TabIndex = 109;
		jw.TabStop = false;
		((Control)jv).AutoSize = true;
		((Control)jv).Location = new Point(344, 18);
		((Control)jv).Name = "label59";
		((Control)jv).Size = new Size(146, 13);
		((Control)jv).TabIndex = 108;
		((Control)jv).Text = "Layered Clothing Instructions:";
		((Control)ju).Anchor = (AnchorStyles)13;
		((Control)ju).Location = new Point(344, 34);
		((Control)ju).Name = "richTextBox1";
		((TextBoxBase)ju).ReadOnly = true;
		((Control)ju).Size = new Size(318, 159);
		((Control)ju).TabIndex = 107;
		((Control)ju).Text = componentResourceManager.GetString("richTextBox1.Text");
		((Control)jq).Controls.Add((Control)(object)jr);
		((Control)jq).Controls.Add((Control)(object)js);
		((Control)jq).Controls.Add((Control)(object)ji);
		((Control)jq).Controls.Add((Control)(object)jh);
		((Control)jq).Location = new Point(7, 30);
		((Control)jq).Name = "gbDefinedZones";
		((Control)jq).Size = new Size(331, 163);
		((Control)jq).TabIndex = 0;
		jq.TabStop = false;
		((Control)jq).Text = "Defined Zones";
		((Control)jr).Anchor = (AnchorStyles)6;
		((Control)jr).Location = new Point(168, 134);
		((Control)jr).Name = "btnRemoveZone";
		((Control)jr).Size = new Size(116, 23);
		((Control)jr).TabIndex = 2;
		((Control)jr).Text = "Remove Zone";
		((ButtonBase)jr).UseVisualStyleBackColor = true;
		((Control)jr).Click += bv;
		((Control)js).Anchor = (AnchorStyles)6;
		((Control)js).Location = new Point(18, 134);
		((Control)js).Name = "btnAddZone";
		((Control)js).Size = new Size(116, 23);
		((Control)js).TabIndex = 1;
		((Control)js).Text = "Add Zone";
		((ButtonBase)js).UseVisualStyleBackColor = true;
		((Control)js).Click += bw;
		((ListControl)ji).FormattingEnabled = true;
		((Control)ji).Location = new Point(6, 33);
		((Control)ji).Name = "lbZones";
		((Control)ji).Size = new Size(319, 95);
		((Control)ji).TabIndex = 0;
		((Control)jh).AutoSize = true;
		((Control)jh).Location = new Point(6, 17);
		((Control)jh).Name = "label55";
		((Control)jh).Size = new Size(151, 13);
		((Control)jh).TabIndex = 101;
		((Control)jh).Text = "Currently Defined Body Zones:";
		((Control)jj).Anchor = (AnchorStyles)7;
		((Control)jj).Controls.Add((Control)(object)jk);
		((Control)jj).Controls.Add((Control)(object)jl);
		((Control)jj).Controls.Add((Control)(object)jm);
		((Control)jj).Controls.Add((Control)(object)jn);
		((Control)jj).Controls.Add((Control)(object)jo);
		((Control)jj).Controls.Add((Control)(object)jp);
		((Control)jj).Controls.Add((Control)(object)jt);
		((Control)jj).Controls.Add((Control)(object)jg);
		((Control)jj).Location = new Point(7, 199);
		((Control)jj).Name = "gbAssignedZones";
		((Control)jj).Size = new Size(331, 324);
		((Control)jj).TabIndex = 1;
		jj.TabStop = false;
		((Control)jj).Text = "Object's Assigned Layers";
		((Control)jk).Anchor = (AnchorStyles)6;
		((Control)jk).Location = new Point(180, 291);
		((Control)jk).Name = "btnRemoveZoneLevel";
		((Control)jk).Size = new Size(116, 23);
		((Control)jk).TabIndex = 4;
		((Control)jk).Text = "Remove Zone Level";
		((ButtonBase)jk).UseVisualStyleBackColor = true;
		((Control)jk).Click += bt;
		((Control)jl).Anchor = (AnchorStyles)6;
		((Control)jl).Location = new Point(30, 291);
		((Control)jl).Name = "btnAddZoneLevel";
		((Control)jl).Size = new Size(116, 23);
		((Control)jl).TabIndex = 3;
		((Control)jl).Text = "Add Zone Level";
		((ButtonBase)jl).UseVisualStyleBackColor = true;
		((Control)jl).Click += bu;
		((Control)jm).Anchor = (AnchorStyles)6;
		((Control)jm).AutoSize = true;
		((Control)jm).Location = new Point(177, 222);
		((Control)jm).Name = "label58";
		((Control)jm).Size = new Size(69, 13);
		((Control)jm).TabIndex = 107;
		((Control)jm).Text = "Select Level:";
		((Control)jm).Click += by;
		((Control)jn).Anchor = (AnchorStyles)6;
		jn.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)jn).FormattingEnabled = true;
		jn.Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		((Control)jn).Location = new Point(180, 238);
		((Control)jn).Name = "cbLevel";
		((Control)jn).Size = new Size(141, 21);
		((Control)jn).TabIndex = 2;
		jn.SelectedIndexChanged += bx;
		((Control)jo).Anchor = (AnchorStyles)6;
		((Control)jo).AutoSize = true;
		((Control)jo).Location = new Point(5, 222);
		((Control)jo).Name = "label57";
		((Control)jo).Size = new Size(68, 13);
		((Control)jo).TabIndex = 105;
		((Control)jo).Text = "Select Zone:";
		((Control)jp).Anchor = (AnchorStyles)6;
		jp.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)jp).FormattingEnabled = true;
		((Control)jp).Location = new Point(6, 238);
		((Control)jp).Name = "cbZone";
		((Control)jp).Size = new Size(142, 21);
		((Control)jp).TabIndex = 1;
		((Control)jt).Anchor = (AnchorStyles)15;
		((ListControl)jt).FormattingEnabled = true;
		((Control)jt).Location = new Point(6, 32);
		((Control)jt).Name = "lbZoneLevel";
		((Control)jt).Size = new Size(319, 160);
		((Control)jt).TabIndex = 0;
		((Control)jg).AutoSize = true;
		((Control)jg).Location = new Point(3, 16);
		((Control)jg).Name = "label56";
		((Control)jg).Size = new Size(123, 13);
		((Control)jg).TabIndex = 103;
		((Control)jg).Text = "Assigned Zones & Levels:";
		((Control)je).AutoSize = true;
		((Control)je).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)je).Location = new Point(3, 3);
		((Control)je).Name = "lblObjectName2";
		((Control)je).Size = new Size(132, 24);
		((Control)je).TabIndex = 99;
		((Control)je).Text = "Object Name";
		((Control)jf).Anchor = (AnchorStyles)9;
		jf.Image = (Image)componentResourceManager.GetObject("pictureBox15.Image");
		((Control)jf).Location = new Point(562, 3);
		((Control)jf).Name = "pictureBox15";
		((Control)jf).Size = new Size(100, 30);
		jf.TabIndex = 97;
		jf.TabStop = false;
		((Control)this.m_d6).Controls.Add((Control)(object)ObjectActions);
		((Control)this.m_d6).Controls.Add((Control)(object)this.m_fk);
		((Control)this.m_d6).Controls.Add((Control)(object)this.m_e9);
		this.m_d6.Location = new Point(4, 4);
		((Control)this.m_d6).Name = "tabPage8";
		((Control)this.m_d6).Padding = new Padding(3);
		((Control)this.m_d6).Size = new Size(671, 532);
		this.m_d6.TabIndex = 2;
		((Control)this.m_d6).Text = "Actions";
		this.m_d6.UseVisualStyleBackColor = true;
		((Control)ObjectActions).Anchor = (AnchorStyles)15;
		((Control)ObjectActions).Location = new Point(4, 39);
		((Control)ObjectActions).Name = "ObjectActions";
		((Control)ObjectActions).Size = new Size(664, 487);
		((Control)ObjectActions).TabIndex = 99;
		((Control)this.m_fk).AutoSize = true;
		((Control)this.m_fk).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_fk).Location = new Point(-1, 0);
		((Control)this.m_fk).Name = "lblObjectName";
		((Control)this.m_fk).Size = new Size(132, 24);
		((Control)this.m_fk).TabIndex = 98;
		((Control)this.m_fk).Text = "Object Name";
		((Control)this.m_e9).Anchor = (AnchorStyles)9;
		this.m_e9.Image = (Image)componentResourceManager.GetObject("pictureBox9.Image");
		((Control)this.m_e9).Location = new Point(568, 3);
		((Control)this.m_e9).Name = "pictureBox9";
		((Control)this.m_e9).Size = new Size(100, 30);
		this.m_e9.TabIndex = 97;
		this.m_e9.TabStop = false;
		((Control)this.m_cu).Controls.Add((Control)(object)il);
		this.m_cu.Location = new Point(4, 4);
		((Control)this.m_cu).Name = "tabPageCharacters";
		((Control)this.m_cu).Padding = new Padding(3);
		((Control)this.m_cu).Size = new Size(679, 558);
		this.m_cu.TabIndex = 5;
		((Control)this.m_cu).Text = "Characters";
		this.m_cu.UseVisualStyleBackColor = true;
		il.BorderStyle = (BorderStyle)1;
		il.Dock = (DockStyle)5;
		((Control)il).Location = new Point(3, 3);
		((Control)il).Name = "splitContainer5";
		((Control)il.Panel1).Controls.Add((Control)(object)hs);
		((Control)il.Panel1).Controls.Add((Control)(object)dgvCharacters);
		((Control)il.Panel2).Controls.Add((Control)(object)tabControlCharData);
		((Control)il).Size = new Size(673, 552);
		il.SplitterDistance = 137;
		((Control)il).TabIndex = 104;
		((Control)hs).Anchor = (AnchorStyles)2;
		((Control)hs).Location = new Point(19, 524);
		((Control)hs).Name = "bAddCharacter";
		((Control)hs).Size = new Size(89, 23);
		((Control)hs).TabIndex = 1;
		((Control)hs).Text = "Add Character";
		((ButtonBase)hs).UseVisualStyleBackColor = true;
		((Control)hs).Click += e1;
		dgvCharacters.AllowUserToAddRows = false;
		dgvCharacters.AllowUserToDeleteRows = false;
		((Control)dgvCharacters).Anchor = (AnchorStyles)15;
		dgvCharacters.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		dgvCharacters.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = SystemColors.Control;
		val5.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = SystemColors.WindowText;
		val5.SelectionBackColor = SystemColors.Highlight;
		val5.SelectionForeColor = SystemColors.HighlightText;
		val5.WrapMode = (DataGridViewTriState)1;
		dgvCharacters.ColumnHeadersDefaultCellStyle = val5;
		dgvCharacters.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		dgvCharacters.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)im });
		val6.Alignment = (DataGridViewContentAlignment)16;
		val6.BackColor = SystemColors.Window;
		val6.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = SystemColors.ControlText;
		val6.SelectionBackColor = SystemColors.Highlight;
		val6.SelectionForeColor = SystemColors.HighlightText;
		val6.WrapMode = (DataGridViewTriState)2;
		dgvCharacters.DefaultCellStyle = val6;
		((Control)dgvCharacters).Location = new Point(2, 2);
		dgvCharacters.MultiSelect = false;
		((Control)dgvCharacters).Name = "dgvCharacters";
		dgvCharacters.ReadOnly = true;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = SystemColors.WindowText;
		val7.SelectionBackColor = SystemColors.Highlight;
		val7.SelectionForeColor = SystemColors.HighlightText;
		val7.WrapMode = (DataGridViewTriState)1;
		dgvCharacters.RowHeadersDefaultCellStyle = val7;
		dgvCharacters.RowHeadersVisible = false;
		dgvCharacters.RowHeadersWidthSizeMode = (DataGridViewRowHeadersWidthSizeMode)2;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.WrapMode = (DataGridViewTriState)1;
		dgvCharacters.RowsDefaultCellStyle = val8;
		dgvCharacters.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)dgvCharacters).Size = new Size(129, 516);
		((Control)dgvCharacters).TabIndex = 0;
		dgvCharacters.SelectionChanged += ct;
		dgvCharacters.SortCompare += b;
		((Control)dgvCharacters).MouseDown += k;
		((DataGridViewColumn)im).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)im).DefaultCellStyle = val9;
		((DataGridViewColumn)im).HeaderText = "Character Name";
		((DataGridViewColumn)im).MinimumWidth = 100;
		((DataGridViewColumn)im).Name = "dataGridViewTextBoxColumn1";
		((DataGridViewBand)im).ReadOnly = true;
		((DataGridViewBand)im).Resizable = (DataGridViewTriState)2;
		tabControlCharData.Alignment = (TabAlignment)1;
		((Control)tabControlCharData).Controls.Add((Control)(object)this.m_cv);
		((Control)tabControlCharData).Controls.Add((Control)(object)lj);
		((Control)tabControlCharData).Controls.Add((Control)(object)val17);
		((Control)tabControlCharData).Dock = (DockStyle)5;
		((Control)tabControlCharData).Location = new Point(0, 0);
		((Control)tabControlCharData).Name = "tabControlCharData";
		tabControlCharData.SelectedIndex = 0;
		((Control)tabControlCharData).Size = new Size(530, 550);
		((Control)tabControlCharData).TabIndex = 0;
		((Control)this.m_cv).Controls.Add((Control)(object)oo);
		((Control)this.m_cv).Controls.Add((Control)(object)tbCharacterNameOverride);
		((Control)this.m_cv).Controls.Add((Control)(object)mr);
		((Control)this.m_cv).Controls.Add((Control)(object)h7);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_fb);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_dg);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_df);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_dd);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_de);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_c9);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_cw);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_cx);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_c8);
		((Control)this.m_cv).Controls.Add((Control)(object)this.m_c1);
		this.m_cv.Location = new Point(4, 4);
		((Control)this.m_cv).Name = "tabPageCharGeneral";
		((Control)this.m_cv).Padding = new Padding(3);
		((Control)this.m_cv).Size = new Size(522, 524);
		this.m_cv.TabIndex = 0;
		((Control)this.m_cv).Text = "General";
		this.m_cv.UseVisualStyleBackColor = true;
		((Control)oo).AllowDrop = true;
		((Control)oo).Anchor = (AnchorStyles)15;
		((Control)oo).Controls.Add((Control)(object)op);
		((Control)oo).Controls.Add((Control)(object)oq);
		((Control)oo).Controls.Add((Control)(object)or);
		((Control)oo).Location = new Point(194, 280);
		((Control)oo).Name = "panel4";
		((Control)oo).Size = new Size(322, 238);
		((Control)oo).TabIndex = 105;
		((Control)op).Enabled = false;
		((Control)op).Location = new Point(6, 21);
		((Control)op).Name = "cbCharPortName";
		((Control)op).Size = new Size(176, 21);
		((Control)op).TabIndex = 11;
		((Control)op).Text = "None";
		op.SelectedIndexChanged += a;
		((Control)oq).Location = new Point(3, 3);
		((Control)oq).Name = "label84";
		((Control)oq).Size = new Size(264, 16);
		((Control)oq).TabIndex = 81;
		((Control)oq).Text = "Initial Character Portrait:";
		((Control)or).Anchor = (AnchorStyles)15;
		((Control)or).BackgroundImageLayout = (ImageLayout)4;
		or.BorderStyle = (BorderStyle)1;
		((Control)or).Location = new Point(6, 48);
		((Control)or).Name = "pbCharPortrait";
		((Control)or).Size = new Size(315, 187);
		or.SizeMode = (PictureBoxSizeMode)4;
		or.TabIndex = 83;
		or.TabStop = false;
		((Control)or).Paint += a;
		((Control)tbCharacterNameOverride).Location = new Point(18, 52);
		((Control)tbCharacterNameOverride).Name = "tbCharacterNameOverride";
		((Control)tbCharacterNameOverride).Size = new Size(185, 20);
		((Control)tbCharacterNameOverride).TabIndex = 1;
		((Control)tbCharacterNameOverride).DoubleClick += ao;
		((Control)tbCharacterNameOverride).Enter += af;
		((Control)tbCharacterNameOverride).KeyDown += e;
		((Control)tbCharacterNameOverride).Leave += al;
		((Control)mr).Location = new Point(15, 31);
		((Control)mr).Name = "label79";
		((Control)mr).Size = new Size(149, 18);
		((Control)mr).TabIndex = 104;
		((Control)mr).Text = "Character Name Override:";
		((Control)h7).AutoSize = true;
		((Control)h7).Enabled = false;
		((Control)h7).Location = new Point(18, 127);
		((Control)h7).Name = "cbCharInventoryInteraction";
		((Control)h7).Size = new Size(151, 17);
		((Control)h7).TabIndex = 3;
		((Control)h7).Text = "Allow Inventory Interaction";
		((ButtonBase)h7).UseVisualStyleBackColor = true;
		((Control)h7).Leave += cn;
		((Control)this.m_fb).Anchor = (AnchorStyles)9;
		this.m_fb.Image = (Image)componentResourceManager.GetObject("pictureBox10.Image");
		((Control)this.m_fb).Location = new Point(422, 3);
		((Control)this.m_fb).Name = "pictureBox10";
		((Control)this.m_fb).Size = new Size(100, 30);
		this.m_fb.TabIndex = 102;
		this.m_fb.TabStop = false;
		((Control)this.m_dg).AutoSize = true;
		((Control)this.m_dg).Location = new Point(15, 154);
		((Control)this.m_dg).Name = "label42";
		((Control)this.m_dg).Size = new Size(63, 13);
		((Control)this.m_dg).TabIndex = 101;
		((Control)this.m_dg).Text = "Description:";
		((Control)this.m_df).Anchor = (AnchorStyles)13;
		((Control)this.m_df).Enabled = false;
		((Control)this.m_df).Location = new Point(18, 172);
		((TextBoxBase)this.m_df).Multiline = true;
		((Control)this.m_df).Name = "txtCharDesc";
		this.m_df.ScrollBars = (ScrollBars)2;
		((Control)this.m_df).Size = new Size(498, 102);
		((Control)this.m_df).TabIndex = 5;
		((Control)this.m_df).DoubleClick += ao;
		((Control)this.m_df).Enter += af;
		((Control)this.m_df).KeyDown += e;
		((Control)this.m_df).Leave += ev;
		this.m_dd.DropDownStyle = (ComboBoxStyle)2;
		((Control)this.m_dd).Enabled = false;
		((ListControl)this.m_dd).FormattingEnabled = true;
		((Control)this.m_dd).Location = new Point(18, 95);
		((Control)this.m_dd).Name = "cbCharInitialRoom";
		((Control)this.m_dd).Size = new Size(185, 21);
		this.m_dd.Sorted = true;
		((Control)this.m_dd).TabIndex = 2;
		((Control)this.m_dd).Leave += ew;
		((Control)this.m_de).AutoSize = true;
		((Control)this.m_de).Location = new Point(15, 79);
		((Control)this.m_de).Name = "label39";
		((Control)this.m_de).Size = new Size(65, 13);
		((Control)this.m_de).TabIndex = 98;
		((Control)this.m_de).Text = "Initial Room:";
		((Control)this.m_c9).Anchor = (AnchorStyles)10;
		((Control)this.m_c9).Enabled = false;
		((Control)this.m_c9).Location = new Point(34, 495);
		((Control)this.m_c9).Name = "btnCharAssignObjects";
		((Control)this.m_c9).Size = new Size(110, 23);
		((Control)this.m_c9).TabIndex = 7;
		((Control)this.m_c9).Text = "Assign Objects";
		((ButtonBase)this.m_c9).UseVisualStyleBackColor = true;
		((Control)this.m_c9).Click += ey;
		((Control)this.m_cw).Location = new Point(15, 278);
		((Control)this.m_cw).Name = "label41";
		((Control)this.m_cw).Size = new Size(100, 16);
		((Control)this.m_cw).TabIndex = 96;
		((Control)this.m_cw).Text = "Initial Inventory:";
		((Control)this.m_cx).AllowDrop = true;
		((Control)this.m_cx).Anchor = (AnchorStyles)7;
		((Control)this.m_cx).ContextMenuStrip = this.m_eb;
		((Control)this.m_cx).Enabled = false;
		this.m_cx.HorizontalScrollbar = true;
		((Control)this.m_cx).Location = new Point(18, 297);
		((Control)this.m_cx).Name = "lbCharacterInventory";
		this.m_cx.ScrollAlwaysVisible = true;
		((Control)this.m_cx).Size = new Size(170, 186);
		((Control)this.m_cx).TabIndex = 6;
		((Control)this.m_cx).DragDrop += l;
		((Control)this.m_cx).DragOver += k;
		((Control)this.m_c8).Controls.Add((Control)(object)this.m_cy);
		((Control)this.m_c8).Controls.Add((Control)(object)this.m_cz);
		((Control)this.m_c8).Controls.Add((Control)(object)this.m_c0);
		((Control)this.m_c8).Enabled = false;
		((Control)this.m_c8).Location = new Point(209, 48);
		((Control)this.m_c8).Name = "gbCharGender";
		((Control)this.m_c8).Size = new Size(120, 96);
		((Control)this.m_c8).TabIndex = 4;
		this.m_c8.TabStop = false;
		((Control)this.m_c8).Text = "Character Gender";
		((Control)this.m_c8).Leave += ex;
		((Control)this.m_cy).Location = new Point(8, 67);
		((Control)this.m_cy).Name = "rbCharOther";
		((Control)this.m_cy).Size = new Size(104, 24);
		((Control)this.m_cy).TabIndex = 13;
		((Control)this.m_cy).Text = "Other";
		((Control)this.m_cz).Anchor = (AnchorStyles)9;
		((Control)this.m_cz).Location = new Point(8, 43);
		((Control)this.m_cz).Name = "rbCharFemale";
		((Control)this.m_cz).Size = new Size(104, 24);
		((Control)this.m_cz).TabIndex = 12;
		((Control)this.m_cz).Text = "Female";
		((Control)this.m_c0).Location = new Point(8, 19);
		((Control)this.m_c0).Name = "rbCharMale";
		((Control)this.m_c0).Size = new Size(104, 24);
		((Control)this.m_c0).TabIndex = 11;
		((Control)this.m_c0).Text = "Male";
		((Control)this.m_c1).AutoSize = true;
		((Control)this.m_c1).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_c1).Location = new Point(3, 0);
		((Control)this.m_c1).Name = "lblCharName";
		((Control)this.m_c1).Size = new Size(161, 24);
		((Control)this.m_c1).TabIndex = 93;
		((Control)this.m_c1).Text = "Character Name";
		((Control)lj).Controls.Add((Control)(object)lw);
		((Control)lj).Controls.Add((Control)(object)lk);
		lj.Location = new Point(4, 4);
		((Control)lj).Name = "tabPage19";
		((Control)lj).Padding = new Padding(3);
		((Control)lj).Size = new Size(522, 524);
		lj.TabIndex = 2;
		((Control)lj).Text = "Custom Properties";
		lj.UseVisualStyleBackColor = true;
		((Control)lw).Anchor = (AnchorStyles)9;
		lw.Image = (Image)componentResourceManager.GetObject("pictureBox18.Image");
		((Control)lw).Location = new Point(413, 6);
		((Control)lw).Name = "pictureBox18";
		((Control)lw).Size = new Size(100, 30);
		lw.TabIndex = 104;
		lw.TabStop = false;
		((Control)lk).Anchor = (AnchorStyles)15;
		((Control)lk).Controls.Add((Control)(object)ll);
		((Control)lk).Controls.Add((Control)(object)lm);
		((Control)lk).Controls.Add((Control)(object)ln);
		((Control)lk).Controls.Add((Control)(object)lo);
		((Control)lk).Controls.Add((Control)(object)lp);
		((Control)lk).Controls.Add((Control)(object)lq);
		((Control)lk).Controls.Add((Control)(object)lr);
		((Control)lk).Controls.Add((Control)(object)ls);
		((Control)lk).Location = new Point(6, 42);
		((Control)lk).Name = "groupBox9";
		((Control)lk).Size = new Size(513, 482);
		((Control)lk).TabIndex = 1;
		lk.TabStop = false;
		((Control)lk).Text = "Custom Properties";
		((Control)ll).Anchor = (AnchorStyles)6;
		((Control)ll).AutoSize = true;
		((Control)ll).Location = new Point(6, 411);
		((Control)ll).Name = "label73";
		((Control)ll).Size = new Size(79, 13);
		((Control)ll).TabIndex = 105;
		((Control)ll).Text = "Property Value:";
		((Control)lm).Anchor = (AnchorStyles)6;
		((Control)lm).Location = new Point(9, 427);
		((Control)lm).Name = "tbCharPropValue";
		((Control)lm).Size = new Size(295, 20);
		((Control)lm).TabIndex = 2;
		((Control)lm).Enter += af;
		((Control)ln).Anchor = (AnchorStyles)6;
		((Control)ln).AutoSize = true;
		((Control)ln).Location = new Point(6, 367);
		((Control)ln).Name = "label74";
		((Control)ln).Size = new Size(80, 13);
		((Control)ln).TabIndex = 103;
		((Control)ln).Text = "Property Name:";
		((Control)lo).Anchor = (AnchorStyles)6;
		((Control)lo).Location = new Point(9, 383);
		((Control)lo).Name = "tbCharPropName";
		((Control)lo).Size = new Size(295, 20);
		((Control)lo).TabIndex = 1;
		((Control)lo).Enter += af;
		((Control)lp).Anchor = (AnchorStyles)6;
		((Control)lp).Location = new Point(206, 453);
		((Control)lp).Name = "btnCharDeleteProperty";
		((Control)lp).Size = new Size(91, 23);
		((Control)lp).TabIndex = 5;
		((Control)lp).Text = "Delete Property";
		((ButtonBase)lp).UseVisualStyleBackColor = true;
		((Control)lp).Click += ay;
		((Control)lq).Anchor = (AnchorStyles)6;
		((Control)lq).Location = new Point(98, 453);
		((Control)lq).Name = "btnCharUpdateProperty";
		((Control)lq).Size = new Size(102, 23);
		((Control)lq).TabIndex = 4;
		((Control)lq).Text = "Update Property";
		((ButtonBase)lq).UseVisualStyleBackColor = true;
		((Control)lq).Click += az;
		((Control)lr).Anchor = (AnchorStyles)6;
		((Control)lr).Location = new Point(9, 453);
		((Control)lr).Name = "btnCharAddProperty";
		((Control)lr).Size = new Size(83, 23);
		((Control)lr).TabIndex = 3;
		((Control)lr).Text = "Add Property";
		((ButtonBase)lr).UseVisualStyleBackColor = true;
		((Control)lr).Click += a0;
		ls.AllowUserToAddRows = false;
		ls.AllowUserToDeleteRows = false;
		((Control)ls).Anchor = (AnchorStyles)15;
		ls.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		ls.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)lt,
			(DataGridViewColumn)lu
		});
		((Control)ls).Location = new Point(9, 19);
		ls.MultiSelect = false;
		((Control)ls).Name = "dgvCharProperties";
		ls.ReadOnly = true;
		ls.RowHeadersWidth = 4;
		ls.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)ls).Size = new Size(498, 345);
		((Control)ls).TabIndex = 0;
		ls.SelectionChanged += a1;
		((DataGridViewColumn)lt).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)lt).HeaderText = "Name";
		((DataGridViewColumn)lt).Name = "dataGridViewTextBoxColumn7";
		((DataGridViewBand)lt).ReadOnly = true;
		((DataGridViewColumn)lu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)lu).HeaderText = "Value";
		((DataGridViewColumn)lu).Name = "dataGridViewTextBoxColumn8";
		((DataGridViewBand)lu).ReadOnly = true;
		((Control)this.m_cj).Controls.Add((Control)(object)@in);
		this.m_cj.Location = new Point(4, 4);
		((Control)this.m_cj).Name = "tabVariables";
		((Control)this.m_cj).Padding = new Padding(3);
		((Control)this.m_cj).Size = new Size(679, 558);
		this.m_cj.TabIndex = 4;
		((Control)this.m_cj).Text = "Variables";
		this.m_cj.UseVisualStyleBackColor = true;
		@in.BorderStyle = (BorderStyle)1;
		@in.Dock = (DockStyle)5;
		((Control)@in).Location = new Point(3, 3);
		((Control)@in).Name = "splitContainer6";
		((Control)@in.Panel1).Controls.Add((Control)(object)oi);
		((Control)@in.Panel1).Controls.Add((Control)(object)tvVariables);
		((Control)@in.Panel1).Controls.Add((Control)(object)this.m_cn);
		((Control)@in.Panel2).Controls.Add((Control)(object)lx);
		((Control)@in).Size = new Size(673, 552);
		@in.SplitterDistance = 164;
		((Control)@in).TabIndex = 106;
		((Control)oi).Location = new Point(3, 4);
		((Control)oi).Name = "label83";
		((Control)oi).Size = new Size(100, 16);
		((Control)oi).TabIndex = 107;
		((Control)oi).Text = "Variables:";
		((Control)tvVariables).AllowDrop = true;
		((Control)tvVariables).Anchor = (AnchorStyles)15;
		tvVariables.BorderStyle = (BorderStyle)1;
		((Control)tvVariables).ContextMenuStrip = oc;
		tvVariables.HideSelection = false;
		tvVariables.ImageIndex = 0;
		tvVariables.ImageList = ns;
		((Control)tvVariables).Location = new Point(4, 23);
		((Control)tvVariables).Name = "tvVariables";
		tvVariables.SelectedImageIndex = 0;
		((Control)tvVariables).Size = new Size(155, 494);
		((Control)tvVariables).TabIndex = 0;
		tvVariables.AfterSelect += a;
		((Control)tvVariables).DragDrop += b;
		((Control)tvVariables).DragOver += a;
		((Control)tvVariables).MouseDown += c;
		((Control)tvVariables).MouseMove += b;
		((ToolStrip)oc).Items.AddRange(new ToolStripItem[5]
		{
			(ToolStripItem)od,
			(ToolStripItem)oe,
			(ToolStripItem)of,
			(ToolStripItem)og,
			(ToolStripItem)oh
		});
		((Control)oc).Name = "cntxPictureMenu";
		((Control)oc).Size = new Size(154, 98);
		((ToolStripItem)od).Name = "toolStripMenuItem11";
		((ToolStripItem)od).Size = new Size(153, 22);
		((ToolStripItem)od).Text = "&Add";
		((ToolStripItem)od).Click += h;
		((ToolStripItem)oe).Name = "toolStripMenuItem12";
		((ToolStripItem)oe).Size = new Size(153, 22);
		((ToolStripItem)oe).Text = "&Delete";
		((ToolStripItem)oe).Click += g;
		((ToolStripItem)of).Name = "toolStripSeparator7";
		((ToolStripItem)of).Size = new Size(150, 6);
		((ToolStripItem)og).Name = "toolStripMenuItem13";
		((ToolStripItem)og).Size = new Size(153, 22);
		((ToolStripItem)og).Text = "Add Group";
		((ToolStripItem)og).Click += j;
		((ToolStripItem)oh).Name = "toolStripMenuItem14";
		((ToolStripItem)oh).Size = new Size(153, 22);
		((ToolStripItem)oh).Text = "Remove Group";
		((ToolStripItem)oh).Click += i;
		ns.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("ilTreeview.ImageStream");
		ns.TransparentColor = Color.Transparent;
		ns.Images.SetKeyName(0, "smalldot.png");
		ns.Images.SetKeyName(1, "cancel.JPG");
		ns.Images.SetKeyName(2, "question.jpg");
		ns.Images.SetKeyName(3, "TaskHS.png");
		ns.Images.SetKeyName(4, "runman.jpg");
		ns.Images.SetKeyName(5, "Flag_redHS.png");
		ns.Images.SetKeyName(6, "Flag_greenHS.png");
		((Control)this.m_cn).Anchor = (AnchorStyles)2;
		((Control)this.m_cn).Location = new Point(28, 523);
		((Control)this.m_cn).Name = "btnAddVariable";
		((Control)this.m_cn).Size = new Size(105, 23);
		((Control)this.m_cn).TabIndex = 1;
		((Control)this.m_cn).Text = "Add Variable";
		((ButtonBase)this.m_cn).UseVisualStyleBackColor = true;
		((Control)this.m_cn).Click += fb;
		lx.Alignment = (TabAlignment)1;
		((Control)lx).Controls.Add((Control)(object)ly);
		((Control)lx).Controls.Add((Control)(object)lz);
		((Control)lx).Dock = (DockStyle)5;
		((Control)lx).Location = new Point(0, 0);
		((Control)lx).Name = "tabControl7";
		lx.SelectedIndex = 0;
		((Control)lx).Size = new Size(503, 550);
		((Control)lx).TabIndex = 12;
		((Control)ly).Controls.Add((Control)(object)this.m_co);
		((Control)ly).Controls.Add((Control)(object)i6);
		((Control)ly).Controls.Add((Control)(object)this.m_ck);
		((Control)ly).Controls.Add((Control)(object)this.m_cp);
		((Control)ly).Controls.Add((Control)(object)this.m_fc);
		ly.Location = new Point(4, 4);
		((Control)ly).Name = "tabPage20";
		((Control)ly).Padding = new Padding(3);
		((Control)ly).Size = new Size(495, 524);
		ly.TabIndex = 0;
		((Control)ly).Text = "General";
		ly.UseVisualStyleBackColor = true;
		((Control)this.m_co).AutoSize = true;
		((Control)this.m_co).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_co).Location = new Point(6, 3);
		((Control)this.m_co).Name = "lblCurVarName";
		((Control)this.m_co).Size = new Size(148, 24);
		((Control)this.m_co).TabIndex = 4;
		((Control)this.m_co).Text = "Variable Name";
		((Control)i6).Anchor = (AnchorStyles)13;
		((Control)i6).Controls.Add((Control)(object)i7);
		((Control)i6).Location = new Point(10, 76);
		((Control)i6).Name = "groupBox4";
		((Control)i6).Size = new Size(479, 84);
		((Control)i6).TabIndex = 3;
		i6.TabStop = false;
		((Control)i6).Text = "Variable Comments";
		((Control)i7).Anchor = (AnchorStyles)13;
		((Control)i7).Location = new Point(6, 14);
		((TextBoxBase)i7).Multiline = true;
		((Control)i7).Name = "tbVarComments";
		i7.ScrollBars = (ScrollBars)2;
		((Control)i7).Size = new Size(467, 64);
		((Control)i7).TabIndex = 0;
		((Control)i7).DoubleClick += ao;
		((Control)i7).Enter += af;
		((Control)i7).Leave += bz;
		((Control)this.m_ck).Controls.Add((Control)(object)hx);
		((Control)this.m_ck).Controls.Add((Control)(object)hy);
		((Control)this.m_ck).Controls.Add((Control)(object)hz);
		((Control)this.m_ck).Controls.Add((Control)(object)this.m_gy);
		((Control)this.m_ck).Controls.Add((Control)(object)this.m_cl);
		((Control)this.m_ck).Controls.Add((Control)(object)this.m_cm);
		((Control)this.m_ck).Enabled = false;
		((Control)this.m_ck).Location = new Point(10, 32);
		((Control)this.m_ck).Name = "gbVarType";
		((Control)this.m_ck).Size = new Size(462, 38);
		((Control)this.m_ck).TabIndex = 2;
		this.m_ck.TabStop = false;
		((Control)this.m_ck).Text = "Variable Type";
		((Control)hx).AutoSize = true;
		((Control)hx).Location = new Point(359, 15);
		((Control)hx).Name = "rbDateTimeArray";
		((Control)hx).Size = new Size(98, 17);
		((Control)hx).TabIndex = 5;
		hx.TabStop = true;
		((Control)hx).Text = "DateTime Array";
		((ButtonBase)hx).UseVisualStyleBackColor = true;
		hx.CheckedChanged += dm;
		((Control)hy).AutoSize = true;
		((Control)hy).Location = new Point(208, 15);
		((Control)hy).Name = "rbTextArray";
		((Control)hy).Size = new Size(73, 17);
		((Control)hy).TabIndex = 3;
		hy.TabStop = true;
		((Control)hy).Text = "Text Array";
		((ButtonBase)hy).UseVisualStyleBackColor = true;
		hy.CheckedChanged += dm;
		((Control)hz).AutoSize = true;
		((Control)hz).Location = new Point(69, 15);
		((Control)hz).Name = "rbNumberArray";
		((Control)hz).Size = new Size(89, 17);
		((Control)hz).TabIndex = 1;
		hz.TabStop = true;
		((Control)hz).Text = "Number Array";
		((ButtonBase)hz).UseVisualStyleBackColor = true;
		hz.CheckedChanged += dm;
		((Control)this.m_gy).AutoSize = true;
		((Control)this.m_gy).Location = new Point(287, 15);
		((Control)this.m_gy).Name = "rbVarDateTime";
		((Control)this.m_gy).Size = new Size(71, 17);
		((Control)this.m_gy).TabIndex = 4;
		this.m_gy.TabStop = true;
		((Control)this.m_gy).Text = "DateTime";
		((ButtonBase)this.m_gy).UseVisualStyleBackColor = true;
		this.m_gy.CheckedChanged += dm;
		((Control)this.m_cl).AutoSize = true;
		((Control)this.m_cl).Location = new Point(161, 15);
		((Control)this.m_cl).Name = "rbVarTextType";
		((Control)this.m_cl).Size = new Size(46, 17);
		((Control)this.m_cl).TabIndex = 2;
		this.m_cl.TabStop = true;
		((Control)this.m_cl).Text = "Text";
		((ButtonBase)this.m_cl).UseVisualStyleBackColor = true;
		this.m_cl.CheckedChanged += dm;
		((Control)this.m_cm).AutoSize = true;
		((Control)this.m_cm).Location = new Point(7, 15);
		((Control)this.m_cm).Name = "rbVarNumberType";
		((Control)this.m_cm).Size = new Size(62, 17);
		((Control)this.m_cm).TabIndex = 0;
		this.m_cm.TabStop = true;
		((Control)this.m_cm).Text = "Number";
		((ButtonBase)this.m_cm).UseVisualStyleBackColor = true;
		this.m_cm.CheckedChanged += dm;
		((Control)this.m_cp).Anchor = (AnchorStyles)15;
		((Control)this.m_cp).Controls.Add((Control)(object)h1);
		((Control)this.m_cp).Controls.Add((Control)(object)g7);
		((Control)this.m_cp).Controls.Add((Control)(object)hd);
		((Control)this.m_cp).Controls.Add((Control)(object)hc);
		((Control)this.m_cp).Controls.Add((Control)(object)this.m_gx);
		((Control)this.m_cp).Controls.Add((Control)(object)this.m_cq);
		((Control)this.m_cp).Enabled = false;
		((Control)this.m_cp).Location = new Point(10, 166);
		((Control)this.m_cp).Name = "gbVarInitialValue";
		((Control)this.m_cp).Size = new Size(479, 352);
		((Control)this.m_cp).TabIndex = 4;
		this.m_cp.TabStop = false;
		((Control)this.m_cp).Text = "Initial Value";
		((Control)h1).Anchor = (AnchorStyles)15;
		((Control)h1).Controls.Add((Control)(object)iz);
		((Control)h1).Controls.Add((Control)(object)h8);
		((Control)h1).Controls.Add((Control)(object)h4);
		((Control)h1).Controls.Add((Control)(object)h2);
		((Control)h1).Controls.Add((Control)(object)h0);
		((Control)h1).Controls.Add((Control)(object)iy);
		((Control)h1).Controls.Add((Control)(object)h3);
		((Control)h1).Location = new Point(9, 118);
		((Control)h1).Name = "gbArray";
		((Control)h1).Size = new Size(466, 228);
		((Control)h1).TabIndex = 1;
		h1.TabStop = false;
		((Control)h1).Text = "Array";
		((Control)iz).AutoSize = true;
		((Control)iz).Location = new Point(360, 23);
		((Control)iz).Name = "cbVarMultiDimensional";
		((Control)iz).Size = new Size(106, 17);
		((Control)iz).TabIndex = 3;
		((Control)iz).Text = "Mult-Dimensional";
		((ButtonBase)iz).UseVisualStyleBackColor = true;
		iz.CheckedChanged += b6;
		((Control)h8).Enabled = false;
		((Control)h8).Location = new Point(94, 18);
		((Control)h8).Name = "btnUpdateArrayItem";
		((Control)h8).Size = new Size(79, 23);
		((Control)h8).TabIndex = 1;
		((Control)h8).Text = "Update Item";
		((ButtonBase)h8).UseVisualStyleBackColor = true;
		((Control)h8).Click += cl;
		((Control)h4).AutoSize = true;
		((Control)h4).Location = new Point(265, 23);
		((Control)h4).Name = "label37";
		((Control)h4).Size = new Size(88, 13);
		((Control)h4).TabIndex = 8;
		((Control)h4).Text = "(Array is 0 based)";
		((Control)h2).Location = new Point(9, 18);
		((Control)h2).Name = "btnAddArrayItem";
		((Control)h2).Size = new Size(79, 23);
		((Control)h2).TabIndex = 0;
		((Control)h2).Text = "Add Item";
		((ButtonBase)h2).UseVisualStyleBackColor = true;
		((Control)h2).Click += cq;
		((Control)h0).Location = new Point(179, 18);
		((Control)h0).Name = "btnRemoveArrayItem";
		((Control)h0).Size = new Size(79, 23);
		((Control)h0).TabIndex = 2;
		((Control)h0).Text = "Remove Item";
		((ButtonBase)h0).UseVisualStyleBackColor = true;
		((Control)h0).Click += cp;
		((Control)iy).Anchor = (AnchorStyles)15;
		iy.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)6;
		val10.Alignment = (DataGridViewContentAlignment)16;
		val10.BackColor = SystemColors.Control;
		val10.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = SystemColors.WindowText;
		val10.SelectionBackColor = SystemColors.Highlight;
		val10.SelectionForeColor = SystemColors.HighlightText;
		val10.WrapMode = (DataGridViewTriState)1;
		iy.ColumnHeadersDefaultCellStyle = val10;
		iy.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((Control)iy).ContextMenuStrip = ms;
		val11.Alignment = (DataGridViewContentAlignment)16;
		val11.BackColor = SystemColors.Window;
		val11.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = SystemColors.ControlText;
		val11.SelectionBackColor = SystemColors.Highlight;
		val11.SelectionForeColor = SystemColors.HighlightText;
		val11.WrapMode = (DataGridViewTriState)1;
		iy.DefaultCellStyle = val11;
		((Control)iy).Location = new Point(6, 50);
		((Control)iy).Name = "dgvMultiDimensional";
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = SystemColors.WindowText;
		val12.SelectionBackColor = SystemColors.Highlight;
		val12.SelectionForeColor = SystemColors.HighlightText;
		val12.WrapMode = (DataGridViewTriState)1;
		iy.RowHeadersDefaultCellStyle = val12;
		iy.RowHeadersWidth = 52;
		((DataGridViewBand)iy.RowTemplate).DefaultCellStyle.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)iy.RowTemplate).Resizable = (DataGridViewTriState)1;
		((Control)iy).Size = new Size(454, 172);
		((Control)iy).TabIndex = 4;
		((Control)iy).Visible = false;
		iy.CellContentClick += a;
		iy.CellValueChanged += b;
		iy.RowsRemoved += b;
		((Control)iy).DoubleClick += an;
		((Control)iy).MouseDown += a;
		((ToolStrip)ms).Items.AddRange(new ToolStripItem[3]
		{
			(ToolStripItem)mt,
			(ToolStripItem)oj,
			(ToolStripItem)ok
		});
		((Control)ms).Name = "cmDgvMultiDim";
		((Control)ms).Size = new Size(160, 70);
		((ToolStripDropDown)ms).Opening += a;
		((ToolStripItem)mt).Name = "adjustColumnsToolStripMenuItem";
		((ToolStripItem)mt).Size = new Size(159, 22);
		((ToolStripItem)mt).Text = "Adjust Columns";
		((ToolStripItem)mt).Click += ak;
		((ToolStripItem)oj).Name = "deleteRowToolStripMenuItem";
		((ToolStripItem)oj).Size = new Size(159, 22);
		((ToolStripItem)oj).Text = "Delete Row";
		((ToolStripItem)oj).Click += f;
		((ToolStripItem)ok).Name = "insertRowToolStripMenuItem";
		((ToolStripItem)ok).Size = new Size(159, 22);
		((ToolStripItem)ok).Text = "Insert Row";
		((ToolStripItem)ok).Click += e;
		((Control)h3).AllowDrop = true;
		((Control)h3).Anchor = (AnchorStyles)15;
		((ListControl)h3).FormattingEnabled = true;
		((Control)h3).Location = new Point(6, 50);
		((Control)h3).Name = "lbArrayItems";
		((Control)h3).Size = new Size(454, 173);
		((Control)h3).TabIndex = 5;
		h3.SelectedIndexChanged += cm;
		((Control)h3).DragDrop += i;
		((Control)h3).DragOver += j;
		((Control)h3).MouseDown += j;
		((Control)h3).MouseMove += i;
		((Control)h3).MouseUp += h;
		((Control)g7).Controls.Add((Control)(object)hr);
		((Control)g7).Controls.Add((Control)(object)g8);
		((Control)g7).Controls.Add((Control)(object)g9);
		((Control)g7).Controls.Add((Control)(object)ha);
		((Control)g7).Controls.Add((Control)(object)hb);
		((Control)g7).Location = new Point(7, 40);
		((Control)g7).Name = "gbMinMaxValues";
		((Control)g7).Size = new Size(355, 72);
		((Control)g7).TabIndex = 2;
		g7.TabStop = false;
		((Control)g7).Text = "Number Limits";
		((Control)hr).AutoSize = true;
		((Control)hr).Location = new Point(7, 18);
		((Control)hr).Name = "cbVarEnforceLimits";
		((Control)hr).Size = new Size(92, 17);
		((Control)hr).TabIndex = 4;
		((Control)hr).Text = "Enforce Limits";
		((ButtonBase)hr).UseVisualStyleBackColor = true;
		hr.CheckedChanged += cu;
		((Control)g8).Location = new Point(240, 36);
		((Control)g8).Name = "tbMaxValue";
		((Control)g8).Size = new Size(100, 20);
		((Control)g8).TabIndex = 3;
		((Control)g8).KeyDown += b;
		((Control)g8).Leave += c7;
		((Control)g8).Validating += e;
		((Control)g8).Validated += c4;
		((Control)g9).AutoSize = true;
		((Control)g9).Location = new Point(177, 43);
		((Control)g9).Name = "label49";
		((Control)g9).Size = new Size(60, 13);
		((Control)g9).TabIndex = 2;
		((Control)g9).Text = "Max Value:";
		((Control)ha).Location = new Point(69, 36);
		((Control)ha).Name = "tbMinValue";
		((Control)ha).Size = new Size(100, 20);
		((Control)ha).TabIndex = 1;
		((Control)ha).KeyDown += a;
		((Control)ha).Leave += c8;
		((Control)ha).Validating += f;
		((Control)ha).Validated += c3;
		((Control)hb).AutoSize = true;
		((Control)hb).Location = new Point(6, 43);
		((Control)hb).Name = "label48";
		((Control)hb).Size = new Size(57, 13);
		((Control)hb).TabIndex = 0;
		((Control)hb).Text = "Min Value:";
		((Control)hd).AutoSize = true;
		((Control)hd).Location = new Point(6, 23);
		((Control)hd).Name = "lblInitialValue";
		((Control)hd).Size = new Size(64, 13);
		((Control)hd).TabIndex = 3;
		((Control)hd).Text = "Initial Value:";
		((Control)hc).Location = new Point(72, 19);
		((Control)hc).Name = "tbInitialValue";
		((Control)hc).Size = new Size(100, 20);
		((Control)hc).TabIndex = 4;
		((Control)hc).Text = "0";
		((Control)hc).Leave += c6;
		((Control)hc).Validating += d;
		((Control)hc).Validated += c5;
		this.m_gx.CustomFormat = "dddd, MMMM, dd yyyy hh:mm:ss tt";
		this.m_gx.Format = (DateTimePickerFormat)8;
		((Control)this.m_gx).Location = new Point(7, 19);
		((Control)this.m_gx).Name = "dtVarInitialVal";
		((Control)this.m_gx).Size = new Size(252, 20);
		((Control)this.m_gx).TabIndex = 1;
		((Control)this.m_gx).Visible = false;
		this.m_gx.ValueChanged += di;
		((Control)this.m_gx).Leave += dl;
		((Control)this.m_cq).Anchor = (AnchorStyles)13;
		((Control)this.m_cq).Location = new Point(6, 14);
		((Control)this.m_cq).Name = "rtVarInitialVal";
		((Control)this.m_cq).Size = new Size(467, 98);
		((Control)this.m_cq).TabIndex = 0;
		((Control)this.m_cq).Text = "";
		((Control)this.m_cq).TextChanged += dk;
		((Control)this.m_cq).DoubleClick += am;
		((Control)this.m_cq).Enter += af;
		((Control)this.m_cq).KeyDown += d;
		((Control)this.m_cq).Leave += fa;
		((Control)this.m_fc).Anchor = (AnchorStyles)9;
		this.m_fc.Image = (Image)componentResourceManager.GetObject("pictureBox12.Image");
		((Control)this.m_fc).Location = new Point(396, -2);
		((Control)this.m_fc).Name = "pictureBox12";
		((Control)this.m_fc).Size = new Size(100, 30);
		this.m_fc.TabIndex = 103;
		this.m_fc.TabStop = false;
		((Control)lz).Controls.Add((Control)(object)l0);
		((Control)lz).Controls.Add((Control)(object)mb);
		lz.Location = new Point(4, 4);
		((Control)lz).Name = "tabPage21";
		((Control)lz).Padding = new Padding(3);
		((Control)lz).Size = new Size(495, 524);
		lz.TabIndex = 1;
		((Control)lz).Text = "Custom Properties";
		lz.UseVisualStyleBackColor = true;
		((Control)l0).Anchor = (AnchorStyles)15;
		((Control)l0).Controls.Add((Control)(object)l1);
		((Control)l0).Controls.Add((Control)(object)l2);
		((Control)l0).Controls.Add((Control)(object)l3);
		((Control)l0).Controls.Add((Control)(object)l4);
		((Control)l0).Controls.Add((Control)(object)l5);
		((Control)l0).Controls.Add((Control)(object)l6);
		((Control)l0).Controls.Add((Control)(object)l7);
		((Control)l0).Controls.Add((Control)(object)l8);
		((Control)l0).Location = new Point(6, 33);
		((Control)l0).Name = "groupBox10";
		((Control)l0).Size = new Size(483, 491);
		((Control)l0).TabIndex = 2;
		l0.TabStop = false;
		((Control)l0).Text = "Custom Properties";
		((Control)l1).Anchor = (AnchorStyles)6;
		((Control)l1).AutoSize = true;
		((Control)l1).Location = new Point(6, 420);
		((Control)l1).Name = "label75";
		((Control)l1).Size = new Size(79, 13);
		((Control)l1).TabIndex = 105;
		((Control)l1).Text = "Property Value:";
		((Control)l2).Anchor = (AnchorStyles)6;
		((Control)l2).Location = new Point(9, 436);
		((Control)l2).Name = "tbVarPropValue";
		((Control)l2).Size = new Size(295, 20);
		((Control)l2).TabIndex = 2;
		((Control)l2).Enter += af;
		((Control)l3).Anchor = (AnchorStyles)6;
		((Control)l3).AutoSize = true;
		((Control)l3).Location = new Point(6, 376);
		((Control)l3).Name = "label76";
		((Control)l3).Size = new Size(80, 13);
		((Control)l3).TabIndex = 103;
		((Control)l3).Text = "Property Name:";
		((Control)l4).Anchor = (AnchorStyles)6;
		((Control)l4).Location = new Point(9, 392);
		((Control)l4).Name = "tbVarPropName";
		((Control)l4).Size = new Size(295, 20);
		((Control)l4).TabIndex = 1;
		((Control)l4).Enter += af;
		((Control)l5).Anchor = (AnchorStyles)6;
		((Control)l5).Location = new Point(206, 462);
		((Control)l5).Name = "btnVarDeleteProperty";
		((Control)l5).Size = new Size(91, 23);
		((Control)l5).TabIndex = 5;
		((Control)l5).Text = "Delete Property";
		((ButtonBase)l5).UseVisualStyleBackColor = true;
		((Control)l5).Click += au;
		((Control)l6).Anchor = (AnchorStyles)6;
		((Control)l6).Location = new Point(98, 462);
		((Control)l6).Name = "btnVarUpdateProperty";
		((Control)l6).Size = new Size(102, 23);
		((Control)l6).TabIndex = 4;
		((Control)l6).Text = "Update Property";
		((ButtonBase)l6).UseVisualStyleBackColor = true;
		((Control)l6).Click += av;
		((Control)l7).Anchor = (AnchorStyles)6;
		((Control)l7).Location = new Point(9, 462);
		((Control)l7).Name = "btnVarAddProperty";
		((Control)l7).Size = new Size(83, 23);
		((Control)l7).TabIndex = 3;
		((Control)l7).Text = "Add Property";
		((ButtonBase)l7).UseVisualStyleBackColor = true;
		((Control)l7).Click += aw;
		l8.AllowUserToAddRows = false;
		l8.AllowUserToDeleteRows = false;
		((Control)l8).Anchor = (AnchorStyles)15;
		l8.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		l8.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)l9,
			(DataGridViewColumn)ma
		});
		((Control)l8).Location = new Point(9, 19);
		l8.MultiSelect = false;
		((Control)l8).Name = "dgvVarProperties";
		l8.ReadOnly = true;
		l8.RowHeadersWidth = 4;
		l8.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)l8).Size = new Size(468, 354);
		((Control)l8).TabIndex = 0;
		l8.SelectionChanged += ax;
		((DataGridViewColumn)l9).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)l9).HeaderText = "Name";
		((DataGridViewColumn)l9).Name = "dataGridViewTextBoxColumn9";
		((DataGridViewBand)l9).ReadOnly = true;
		((DataGridViewColumn)ma).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ma).HeaderText = "Value";
		((DataGridViewColumn)ma).Name = "dataGridViewTextBoxColumn10";
		((DataGridViewBand)ma).ReadOnly = true;
		((Control)mb).Anchor = (AnchorStyles)9;
		mb.Image = (Image)componentResourceManager.GetObject("pictureBox20.Image");
		((Control)mb).Location = new Point(397, -2);
		((Control)mb).Name = "pictureBox20";
		((Control)mb).Size = new Size(100, 30);
		mb.TabIndex = 104;
		mb.TabStop = false;
		((Control)this.m_fz).Controls.Add((Control)(object)io);
		this.m_fz.Location = new Point(4, 4);
		((Control)this.m_fz).Name = "tabPage11";
		((Control)this.m_fz).Padding = new Padding(3);
		((Control)this.m_fz).Size = new Size(679, 558);
		this.m_fz.TabIndex = 6;
		((Control)this.m_fz).Text = "Timers";
		this.m_fz.UseVisualStyleBackColor = true;
		io.BorderStyle = (BorderStyle)1;
		io.Dock = (DockStyle)5;
		((Control)io).Location = new Point(3, 3);
		((Control)io).Name = "splitContainer7";
		((Control)io.Panel1).Controls.Add((Control)(object)dgvTimers);
		((Control)io.Panel1).Controls.Add((Control)(object)this.m_f9);
		((Control)io.Panel1).Controls.Add((Control)(object)this.m_f8);
		((Control)io.Panel2).Controls.Add((Control)(object)tabControl5);
		((Control)io).Size = new Size(673, 552);
		io.SplitterDistance = 160;
		((Control)io).TabIndex = 106;
		dgvTimers.AllowUserToAddRows = false;
		dgvTimers.AllowUserToDeleteRows = false;
		dgvTimers.AllowUserToResizeRows = false;
		((Control)dgvTimers).Anchor = (AnchorStyles)15;
		dgvTimers.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Control;
		val13.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = SystemColors.WindowText;
		val13.SelectionBackColor = SystemColors.Highlight;
		val13.SelectionForeColor = SystemColors.HighlightText;
		val13.WrapMode = (DataGridViewTriState)1;
		dgvTimers.ColumnHeadersDefaultCellStyle = val13;
		dgvTimers.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		dgvTimers.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)ip,
			(DataGridViewColumn)iq
		});
		((Control)dgvTimers).ContextMenuStrip = this.m_gf;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = SystemColors.Window;
		val14.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.ControlText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)2;
		dgvTimers.DefaultCellStyle = val14;
		((Control)dgvTimers).Location = new Point(3, 20);
		((Control)dgvTimers).Name = "dgvTimers";
		dgvTimers.ReadOnly = true;
		val15.Alignment = (DataGridViewContentAlignment)16;
		val15.BackColor = SystemColors.Control;
		val15.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = SystemColors.WindowText;
		val15.SelectionBackColor = SystemColors.Highlight;
		val15.SelectionForeColor = SystemColors.HighlightText;
		val15.WrapMode = (DataGridViewTriState)1;
		dgvTimers.RowHeadersDefaultCellStyle = val15;
		dgvTimers.RowHeadersVisible = false;
		dgvTimers.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)dgvTimers).Size = new Size(152, 497);
		((Control)dgvTimers).TabIndex = 0;
		dgvTimers.SelectionChanged += cv;
		dgvTimers.SortCompare += c;
		((DataGridViewColumn)ip).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ip).FillWeight = 25f;
		((DataGridViewColumn)ip).HeaderText = "Exec Order";
		((DataGridViewColumn)ip).Name = "ExecOrder";
		((DataGridViewBand)ip).ReadOnly = true;
		((DataGridViewColumn)iq).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val16.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)iq).DefaultCellStyle = val16;
		((DataGridViewColumn)iq).FillWeight = 75f;
		((DataGridViewColumn)iq).HeaderText = "Name";
		((DataGridViewColumn)iq).Name = "TimerName";
		((DataGridViewBand)iq).ReadOnly = true;
		((Control)this.m_f9).Anchor = (AnchorStyles)2;
		((Control)this.m_f9).Location = new Point(32, 523);
		((Control)this.m_f9).Name = "btnAddTimer";
		((Control)this.m_f9).Size = new Size(89, 23);
		((Control)this.m_f9).TabIndex = 1;
		((Control)this.m_f9).Text = "Add Timer";
		((ButtonBase)this.m_f9).UseVisualStyleBackColor = true;
		((Control)this.m_f9).Click += dy;
		((Control)this.m_f8).AutoSize = true;
		((Control)this.m_f8).Location = new Point(5, 4);
		((Control)this.m_f8).Name = "label47";
		((Control)this.m_f8).Size = new Size(41, 13);
		((Control)this.m_f8).TabIndex = 95;
		((Control)this.m_f8).Text = "Timers:";
		tabControl5.Alignment = (TabAlignment)1;
		((Control)tabControl5).Controls.Add((Control)(object)this.m_f0);
		((Control)tabControl5).Controls.Add((Control)(object)md);
		((Control)tabControl5).Controls.Add((Control)(object)val18);
		((Control)tabControl5).Dock = (DockStyle)5;
		((Control)tabControl5).Location = new Point(0, 0);
		((Control)tabControl5).Name = "tabControl5";
		tabControl5.SelectedIndex = 0;
		((Control)tabControl5).Size = new Size(507, 550);
		((Control)tabControl5).TabIndex = 93;
		((Control)this.m_f0).Controls.Add((Control)(object)mu);
		((Control)this.m_f0).Controls.Add((Control)(object)hq);
		((Control)this.m_f0).Controls.Add((Control)(object)this.m_ga);
		((Control)this.m_f0).Controls.Add((Control)(object)this.m_gb);
		((Control)this.m_f0).Controls.Add((Control)(object)this.m_f1);
		((Control)this.m_f0).Controls.Add((Control)(object)this.m_f2);
		((Control)this.m_f0).Controls.Add((Control)(object)this.m_f5);
		this.m_f0.Location = new Point(4, 4);
		((Control)this.m_f0).Name = "tabPage12";
		((Control)this.m_f0).Padding = new Padding(3);
		((Control)this.m_f0).Size = new Size(499, 524);
		this.m_f0.TabIndex = 0;
		((Control)this.m_f0).Text = "General";
		this.m_f0.UseVisualStyleBackColor = true;
		((Control)mu).Controls.Add((Control)(object)mw);
		((Control)mu).Controls.Add((Control)(object)mx);
		((Control)mu).Controls.Add((Control)(object)mv);
		((Control)mu).Enabled = false;
		((Control)mu).Location = new Point(18, 289);
		((Control)mu).Name = "groupBox12";
		((Control)mu).Size = new Size(185, 72);
		((Control)mu).TabIndex = 5;
		mu.TabStop = false;
		((Control)mu).Text = "Live Action Timer";
		((Control)mw).Location = new Point(95, 46);
		mw.Maximum = new decimal(new int[4] { 3600, 0, 0, 0 });
		mw.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)mw).Name = "udSecondsToFire";
		((Control)mw).Size = new Size(41, 20);
		((Control)mw).TabIndex = 106;
		mw.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		mw.ValueChanged += ai;
		((Control)mx).AutoSize = true;
		((Control)mx).Location = new Point(8, 19);
		((Control)mx).Name = "cbLiveTimer";
		((Control)mx).Size = new Size(75, 17);
		((Control)mx).TabIndex = 105;
		((Control)mx).Text = "Live Timer";
		((ButtonBase)mx).UseVisualStyleBackColor = true;
		mx.CheckedChanged += aj;
		((Control)mv).AutoSize = true;
		((Control)mv).Location = new Point(8, 48);
		((Control)mv).Name = "label80";
		((Control)mv).Size = new Size(81, 13);
		((Control)mv).TabIndex = 0;
		((Control)mv).Text = "Seconds to fire:";
		((Control)hq).Controls.Add((Control)(object)ho);
		((Control)hq).Controls.Add((Control)(object)hp);
		((Control)hq).Location = new Point(18, 34);
		((Control)hq).Name = "gbExecutionOrder";
		((Control)hq).Size = new Size(185, 75);
		((Control)hq).TabIndex = 2;
		hq.TabStop = false;
		((Control)hq).Text = "Execution Order";
		((Control)ho).Location = new Point(7, 19);
		((Control)ho).Name = "label50";
		((Control)ho).Size = new Size(172, 22);
		((Control)ho).TabIndex = 2;
		((Control)ho).Text = "Timers run in order starting at 1.";
		((Control)hp).Location = new Point(8, 44);
		hp.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		((Control)hp).Name = "udTimerOrder";
		((UpDownBase)hp).ReadOnly = true;
		((Control)hp).Size = new Size(80, 20);
		((Control)hp).TabIndex = 1;
		hp.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		hp.ValueChanged += cw;
		((Control)this.m_ga).AutoSize = true;
		((Control)this.m_ga).Enabled = false;
		((Control)this.m_ga).Location = new Point(26, 378);
		((Control)this.m_ga).Name = "cbTimerInitiallyActive";
		((Control)this.m_ga).Size = new Size(90, 17);
		((Control)this.m_ga).TabIndex = 6;
		((Control)this.m_ga).Text = "Initially Active";
		((ButtonBase)this.m_ga).UseVisualStyleBackColor = true;
		this.m_ga.CheckedChanged += dz;
		((Control)this.m_gb).Controls.Add((Control)(object)this.m_gc);
		((Control)this.m_gb).Controls.Add((Control)(object)this.m_gd);
		((Control)this.m_gb).Controls.Add((Control)(object)this.m_ge);
		((Control)this.m_gb).Enabled = false;
		((Control)this.m_gb).Location = new Point(18, 211);
		((Control)this.m_gb).Name = "gbTimerDetail";
		((Control)this.m_gb).Size = new Size(185, 72);
		((Control)this.m_gb).TabIndex = 4;
		this.m_gb.TabStop = false;
		((Control)this.m_gb).Text = "Timer Detail";
		((Control)this.m_gc).AutoSize = true;
		((Control)this.m_gc).Location = new Point(8, 47);
		((Control)this.m_gc).Name = "cbRestartAutomatically";
		((Control)this.m_gc).Size = new Size(125, 17);
		((Control)this.m_gc).TabIndex = 105;
		((Control)this.m_gc).Text = "Restart Automatically";
		((ButtonBase)this.m_gc).UseVisualStyleBackColor = true;
		this.m_gc.CheckedChanged += d0;
		((Control)this.m_gd).Location = new Point(92, 21);
		((Control)this.m_gd).Name = "tbTimerLength";
		((Control)this.m_gd).Size = new Size(78, 20);
		((Control)this.m_gd).TabIndex = 1;
		((Control)this.m_gd).Leave += d1;
		((Control)this.m_ge).AutoSize = true;
		((Control)this.m_ge).Location = new Point(8, 23);
		((Control)this.m_ge).Name = "label34";
		((Control)this.m_ge).Size = new Size(85, 13);
		((Control)this.m_ge).TabIndex = 0;
		((Control)this.m_ge).Text = "Length In Turns:";
		((Control)this.m_f1).Anchor = (AnchorStyles)9;
		this.m_f1.Image = (Image)componentResourceManager.GetObject("pictureBox13.Image");
		((Control)this.m_f1).Location = new Point(399, 3);
		((Control)this.m_f1).Name = "pictureBox13";
		((Control)this.m_f1).Size = new Size(100, 30);
		this.m_f1.TabIndex = 102;
		this.m_f1.TabStop = false;
		((Control)this.m_f2).Controls.Add((Control)(object)this.m_f3);
		((Control)this.m_f2).Controls.Add((Control)(object)this.m_f4);
		((Control)this.m_f2).Enabled = false;
		((Control)this.m_f2).Location = new Point(18, 133);
		((Control)this.m_f2).Name = "gbTimerType";
		((Control)this.m_f2).Size = new Size(185, 72);
		((Control)this.m_f2).TabIndex = 3;
		this.m_f2.TabStop = false;
		((Control)this.m_f2).Text = "Timer Type";
		((Control)this.m_f3).Location = new Point(8, 43);
		((Control)this.m_f3).Name = "rbRunLength";
		((Control)this.m_f3).Size = new Size(147, 24);
		((Control)this.m_f3).TabIndex = 12;
		((Control)this.m_f3).Text = "Run A Specified Length";
		((Control)this.m_f4).Location = new Point(8, 19);
		((Control)this.m_f4).Name = "rbRunAlways";
		((Control)this.m_f4).Size = new Size(104, 24);
		((Control)this.m_f4).TabIndex = 11;
		((Control)this.m_f4).Text = "Run Always";
		this.m_f4.CheckedChanged += d2;
		((Control)this.m_f5).AutoSize = true;
		((Control)this.m_f5).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_f5).Location = new Point(3, 0);
		((Control)this.m_f5).Name = "lbTimerGeneralName";
		((Control)this.m_f5).Size = new Size(125, 24);
		((Control)this.m_f5).TabIndex = 93;
		((Control)this.m_f5).Text = "Timer Name";
		((Control)md).Controls.Add((Control)(object)me);
		((Control)md).Controls.Add((Control)(object)mf);
		md.Location = new Point(4, 4);
		((Control)md).Name = "tabPage22";
		((Control)md).Padding = new Padding(3);
		((Control)md).Size = new Size(499, 524);
		md.TabIndex = 2;
		((Control)md).Text = "Custom Properties";
		md.UseVisualStyleBackColor = true;
		((Control)me).Anchor = (AnchorStyles)9;
		me.Image = (Image)componentResourceManager.GetObject("pictureBox22.Image");
		((Control)me).Location = new Point(393, 3);
		((Control)me).Name = "pictureBox22";
		((Control)me).Size = new Size(100, 30);
		me.TabIndex = 107;
		me.TabStop = false;
		((Control)mf).Anchor = (AnchorStyles)15;
		((Control)mf).Controls.Add((Control)(object)mg);
		((Control)mf).Controls.Add((Control)(object)mh);
		((Control)mf).Controls.Add((Control)(object)mi);
		((Control)mf).Controls.Add((Control)(object)mj);
		((Control)mf).Controls.Add((Control)(object)mk);
		((Control)mf).Controls.Add((Control)(object)ml);
		((Control)mf).Controls.Add((Control)(object)mm);
		((Control)mf).Controls.Add((Control)(object)mn);
		((Control)mf).Location = new Point(6, 33);
		((Control)mf).Name = "groupBox11";
		((Control)mf).Size = new Size(490, 491);
		((Control)mf).TabIndex = 2;
		mf.TabStop = false;
		((Control)mf).Text = "Custom Properties";
		((Control)mg).Anchor = (AnchorStyles)6;
		((Control)mg).AutoSize = true;
		((Control)mg).Location = new Point(6, 420);
		((Control)mg).Name = "label77";
		((Control)mg).Size = new Size(79, 13);
		((Control)mg).TabIndex = 105;
		((Control)mg).Text = "Property Value:";
		((Control)mh).Anchor = (AnchorStyles)6;
		((Control)mh).Location = new Point(9, 436);
		((Control)mh).Name = "tbTimerPropVal";
		((Control)mh).Size = new Size(295, 20);
		((Control)mh).TabIndex = 2;
		((Control)mi).Anchor = (AnchorStyles)6;
		((Control)mi).AutoSize = true;
		((Control)mi).Location = new Point(6, 376);
		((Control)mi).Name = "label78";
		((Control)mi).Size = new Size(80, 13);
		((Control)mi).TabIndex = 103;
		((Control)mi).Text = "Property Name:";
		((Control)mj).Anchor = (AnchorStyles)6;
		((Control)mj).Location = new Point(9, 392);
		((Control)mj).Name = "tbTimerPropName";
		((Control)mj).Size = new Size(295, 20);
		((Control)mj).TabIndex = 1;
		((Control)mk).Anchor = (AnchorStyles)6;
		((Control)mk).Location = new Point(206, 462);
		((Control)mk).Name = "btnTimerDeleteProp";
		((Control)mk).Size = new Size(91, 23);
		((Control)mk).TabIndex = 5;
		((Control)mk).Text = "Delete Property";
		((ButtonBase)mk).UseVisualStyleBackColor = true;
		((Control)mk).Click += aq;
		((Control)ml).Anchor = (AnchorStyles)6;
		((Control)ml).Location = new Point(98, 462);
		((Control)ml).Name = "btnTimerUpdateProp";
		((Control)ml).Size = new Size(102, 23);
		((Control)ml).TabIndex = 4;
		((Control)ml).Text = "Update Property";
		((ButtonBase)ml).UseVisualStyleBackColor = true;
		((Control)ml).Click += ar;
		((Control)mm).Anchor = (AnchorStyles)6;
		((Control)mm).Location = new Point(9, 462);
		((Control)mm).Name = "btnTimerAddProp";
		((Control)mm).Size = new Size(83, 23);
		((Control)mm).TabIndex = 3;
		((Control)mm).Text = "Add Property";
		((ButtonBase)mm).UseVisualStyleBackColor = true;
		((Control)mm).Click += @as;
		mn.AllowUserToAddRows = false;
		mn.AllowUserToDeleteRows = false;
		((Control)mn).Anchor = (AnchorStyles)15;
		mn.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		mn.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)mo,
			(DataGridViewColumn)mp
		});
		((Control)mn).Location = new Point(9, 19);
		mn.MultiSelect = false;
		((Control)mn).Name = "dgvTimerProperties";
		mn.ReadOnly = true;
		mn.RowHeadersWidth = 4;
		mn.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)mn).Size = new Size(475, 354);
		((Control)mn).TabIndex = 0;
		mn.SelectionChanged += at;
		((DataGridViewColumn)mo).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)mo).HeaderText = "Name";
		((DataGridViewColumn)mo).Name = "dataGridViewTextBoxColumn11";
		((DataGridViewBand)mo).ReadOnly = true;
		((DataGridViewColumn)mp).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)mp).HeaderText = "Value";
		((DataGridViewColumn)mp).Name = "dataGridViewTextBoxColumn12";
		((DataGridViewBand)mp).ReadOnly = true;
		((Control)m5).Controls.Add((Control)(object)m6);
		m5.Location = new Point(4, 4);
		((Control)m5).Name = "tabPage23";
		((Control)m5).Padding = new Padding(3);
		((Control)m5).Size = new Size(679, 558);
		m5.TabIndex = 7;
		((Control)m5).Text = "Multimedia";
		m5.UseVisualStyleBackColor = true;
		m6.BorderStyle = (BorderStyle)1;
		m6.Dock = (DockStyle)5;
		((Control)m6).Location = new Point(3, 3);
		((Control)m6).Name = "splitContainer10";
		((Control)m6.Panel1).Controls.Add((Control)(object)m7);
		((Control)m6.Panel2).Controls.Add((Control)(object)m9);
		((Control)m6).Size = new Size(673, 552);
		m6.SplitterDistance = 138;
		((Control)m6).TabIndex = 0;
		m7.AllowUserToAddRows = false;
		m7.AllowUserToDeleteRows = false;
		m7.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		m7.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)m8 });
		((Control)m7).Dock = (DockStyle)5;
		((Control)m7).Location = new Point(0, 0);
		((Control)m7).Name = "dgvMultimedia";
		m7.ReadOnly = true;
		m7.SelectionMode = (DataGridViewSelectionMode)1;
		m7.ShowEditingIcon = false;
		((Control)m7).Size = new Size(136, 550);
		((Control)m7).TabIndex = 0;
		m7.SelectionChanged += ae;
		((DataGridViewColumn)m8).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)m8).HeaderText = "Multimedia";
		((DataGridViewColumn)m8).Name = "Column4";
		((DataGridViewBand)m8).ReadOnly = true;
		m9.BorderStyle = (BorderStyle)1;
		m9.Dock = (DockStyle)5;
		((Control)m9).Location = new Point(0, 0);
		((Control)m9).Name = "splitContainer11";
		m9.Orientation = (Orientation)0;
		((Control)m9.Panel1).Controls.Add((Control)(object)na);
		((Control)m9.Panel2).Controls.Add((Control)(object)nb);
		((Control)m9).Size = new Size(531, 552);
		m9.SplitterDistance = 358;
		((Control)m9).TabIndex = 0;
		((Control)na).Dock = (DockStyle)5;
		((Control)na).Location = new Point(0, 0);
		((Control)na).Name = "pbMediaPreview";
		((Control)na).Size = new Size(529, 356);
		na.SizeMode = (PictureBoxSizeMode)4;
		na.TabIndex = 0;
		na.TabStop = false;
		((Control)na).Paint += a;
		((Control)nb).Anchor = (AnchorStyles)7;
		((Control)nb).Controls.Add((Control)(object)nd);
		((Control)nb).Controls.Add((Control)(object)ne);
		((Control)nb).Controls.Add((Control)(object)nf);
		((Control)nb).Controls.Add((Control)(object)nc);
		((Control)nb).Location = new Point(3, 6);
		((Control)nb).Name = "groupBox13";
		((Control)nb).Size = new Size(257, 179);
		((Control)nb).TabIndex = 1;
		nb.TabStop = false;
		((Control)nb).Text = "Layered Images";
		((Control)nd).Location = new Point(133, 19);
		((Control)nd).Name = "btnRemoveLayeredImages";
		((Control)nd).Size = new Size(56, 23);
		((Control)nd).TabIndex = 1;
		((Control)nd).Text = "Remove";
		((ButtonBase)nd).UseVisualStyleBackColor = true;
		((Control)nd).Click += ad;
		((Control)ne).Location = new Point(132, 99);
		((Control)ne).Name = "btnDownLayeredImages";
		((Control)ne).Size = new Size(45, 23);
		((Control)ne).TabIndex = 3;
		((Control)ne).Text = "Down";
		((ButtonBase)ne).UseVisualStyleBackColor = true;
		((Control)ne).Click += ac;
		((Control)nf).Location = new Point(132, 69);
		((Control)nf).Name = "btnUpLayeredImages";
		((Control)nf).Size = new Size(45, 23);
		((Control)nf).TabIndex = 2;
		((Control)nf).Text = "Up";
		((ButtonBase)nf).UseVisualStyleBackColor = true;
		((Control)nf).Click += ab;
		((Control)nc).AllowDrop = true;
		((ListControl)nc).FormattingEnabled = true;
		((Control)nc).Location = new Point(6, 19);
		((Control)nc).Name = "lbLayeredImages";
		((Control)nc).Size = new Size(120, 160);
		((Control)nc).TabIndex = 0;
		((Control)nc).DragDrop += h;
		((Control)nc).DragOver += g;
		((Control)this.m_bs).Controls.Add((Control)(object)this.m_bt);
		((Control)this.m_bs).Controls.Add((Control)(object)this.m_bv);
		((Control)this.m_bs).Controls.Add((Control)(object)mz);
		((Control)this.m_bs).Dock = (DockStyle)5;
		((Control)this.m_bs).Location = new Point(0, 0);
		((Control)this.m_bs).Name = "panel1";
		((Control)this.m_bs).Size = new Size(198, 584);
		((Control)this.m_bs).TabIndex = 13;
		((Control)this.m_bt).Controls.Add((Control)(object)tvItems);
		((Control)this.m_bt).Controls.Add((Control)(object)he);
		((Control)this.m_bt).Controls.Add((Control)(object)this.m_bu);
		((Control)this.m_bt).Dock = (DockStyle)5;
		((Control)this.m_bt).Location = new Point(0, 363);
		((Control)this.m_bt).Name = "ObjectPanel";
		((Control)this.m_bt).Size = new Size(198, 221);
		((Control)this.m_bt).TabIndex = 17;
		((Control)tvItems).AllowDrop = true;
		((Control)tvItems).Anchor = (AnchorStyles)15;
		((Control)tvItems).ContextMenu = this.m_p;
		tvItems.HideSelection = false;
		tvItems.ImageIndex = 0;
		tvItems.ImageList = ns;
		((Control)tvItems).Location = new Point(4, 24);
		((Control)tvItems).Name = "tvItems";
		tvItems.SelectedImageIndex = 0;
		((Control)tvItems).Size = new Size(197, 194);
		((Control)tvItems).TabIndex = 34;
		tvItems.AfterSelect += b;
		((Control)tvItems).DragDrop += d;
		((Control)tvItems).DragOver += c;
		((Control)tvItems).MouseDown += e;
		((Control)tvItems).MouseMove += d;
		((Control)he).AutoSize = true;
		he.Checked = true;
		he.CheckState = (CheckState)1;
		((Control)he).Location = new Point(60, 108);
		((Control)he).Name = "cbSortObjects";
		((Control)he).Size = new Size(113, 17);
		((Control)he).TabIndex = 33;
		((Control)he).Text = "Sort Alphabetically";
		((ButtonBase)he).UseVisualStyleBackColor = true;
		he.CheckedChanged += c2;
		((Control)this.m_bu).Location = new Point(0, 8);
		((Control)this.m_bu).Name = "label25";
		((Control)this.m_bu).Size = new Size(100, 16);
		((Control)this.m_bu).TabIndex = 13;
		((Control)this.m_bu).Text = "Object Library:";
		this.m_bv.BorderStyle = (BorderStyle)1;
		((Control)this.m_bv).Dock = (DockStyle)1;
		((Control)this.m_bv).Location = new Point(0, 360);
		((Control)this.m_bv).Name = "splitter2";
		((Control)this.m_bv).Size = new Size(198, 3);
		((Control)this.m_bv).TabIndex = 16;
		this.m_bv.TabStop = false;
		((Control)mz).Controls.Add((Control)(object)m0);
		((Control)mz).Controls.Add((Control)(object)m1);
		((Control)mz).Dock = (DockStyle)1;
		((Control)mz).Location = new Point(0, 0);
		((Control)mz).Name = "PicturePanel";
		((Control)mz).Size = new Size(198, 360);
		((Control)mz).TabIndex = 14;
		m0.BorderStyle = (BorderStyle)1;
		m0.Dock = (DockStyle)5;
		((Control)m0).Location = new Point(0, 0);
		((Control)m0).Name = "splitContainer9";
		m0.Orientation = (Orientation)0;
		((Control)m0.Panel1).Controls.Add((Control)(object)this.m_bx);
		((Control)m0.Panel2).Controls.Add((Control)(object)my);
		((Control)m0).Size = new Size(198, 357);
		m0.SplitterDistance = 193;
		((Control)m0).TabIndex = 14;
		((Control)this.m_bx).Controls.Add((Control)(object)nr);
		((Control)this.m_bx).Controls.Add((Control)(object)hf);
		((Control)this.m_bx).Controls.Add((Control)(object)this.m_by);
		((Control)this.m_bx).Dock = (DockStyle)5;
		((Control)this.m_bx).Location = new Point(0, 0);
		((Control)this.m_bx).Name = "panel3";
		((Control)this.m_bx).Size = new Size(196, 191);
		((Control)this.m_bx).TabIndex = 14;
		((Control)nr).AllowDrop = true;
		((Control)nr).Anchor = (AnchorStyles)15;
		nr.BorderStyle = (BorderStyle)1;
		((Control)nr).ContextMenuStrip = this.m_ee;
		nr.HideSelection = false;
		nr.ImageIndex = 0;
		nr.ImageList = ns;
		((Control)nr).Location = new Point(3, 20);
		((Control)nr).Name = "tvMedia";
		nr.SelectedImageIndex = 0;
		((Control)nr).Size = new Size(190, 168);
		((Control)nr).TabIndex = 35;
		nr.AfterSelect += c;
		((Control)nr).DragDrop += f;
		((Control)nr).DragOver += e;
		((Control)nr).MouseDown += g;
		((Control)nr).MouseMove += f;
		((Control)hf).AutoSize = true;
		hf.Checked = true;
		hf.CheckState = (CheckState)1;
		((Control)hf).Location = new Point(29, 61);
		((Control)hf).Name = "cbSortPictures";
		((Control)hf).Size = new Size(113, 17);
		((Control)hf).TabIndex = 34;
		((Control)hf).Text = "Sort Alphabetically";
		((ButtonBase)hf).UseVisualStyleBackColor = true;
		hf.CheckedChanged += c1;
		((Control)this.m_by).Location = new Point(5, 3);
		((Control)this.m_by).Name = "label5";
		((Control)this.m_by).Size = new Size(100, 16);
		((Control)this.m_by).TabIndex = 13;
		((Control)this.m_by).Text = "Multimedia Library:";
		((Control)my).Controls.Add((Control)(object)ot);
		((Control)my).Controls.Add((Control)(object)this.m_bw);
		((Control)my).Dock = (DockStyle)5;
		((Control)my).Location = new Point(0, 0);
		((Control)my).Name = "panel2";
		((Control)my).Size = new Size(196, 158);
		((Control)my).TabIndex = 16;
		((Control)ot).Dock = (DockStyle)5;
		((AxHost)ot).Enabled = true;
		((Control)ot).Location = new Point(0, 0);
		((Control)ot).Name = "axPicPreview";
		((AxHost)ot).OcxState = (State)componentResourceManager.GetObject("axPicPreview.OcxState");
		((Control)ot).Size = new Size(196, 158);
		((Control)ot).TabIndex = 26;
		((Control)ot).Visible = false;
		this.m_bw.BorderStyle = (BorderStyle)1;
		((Control)this.m_bw).Dock = (DockStyle)5;
		((Control)this.m_bw).Location = new Point(0, 0);
		((Control)this.m_bw).Name = "picPreview";
		((Control)this.m_bw).Size = new Size(196, 158);
		this.m_bw.SizeMode = (PictureBoxSizeMode)4;
		this.m_bw.TabIndex = 11;
		this.m_bw.TabStop = false;
		((Control)this.m_bw).Click += fo;
		((Control)m1).Dock = (DockStyle)2;
		((Control)m1).Location = new Point(0, 357);
		((Control)m1).Name = "splitter3";
		((Control)m1).Size = new Size(198, 3);
		((Control)m1).TabIndex = 13;
		m1.TabStop = false;
		((FileDialog)j2).DefaultExt = "*.rag";
		((FileDialog)j2).Filter = "Rag Files|*.rag|All files|*.*";
		((FileDialog)j2).Title = "Save Picture File";
		((FileDialog)nm).DefaultExt = "*.rpk";
		((FileDialog)nm).Filter = "Rag Package|*.rpk|All files|*.*";
		((FileDialog)nm).Title = "Export Data As Package";
		((FileDialog)nn).DefaultExt = "*.rpk";
		((FileDialog)nn).Filter = "Rag Package|*.rpk|All files|*.*";
		((FileDialog)nn).Title = "Import a Rags Package";
		on.Tick += b;
		((AxHost)ov).Enabled = true;
		((Control)ov).Location = new Point(0, 48);
		((Control)ov).Name = "axPlayerPic";
		((AxHost)ov).OcxState = (State)componentResourceManager.GetObject("axPlayerPic.OcxState");
		((Control)ov).Size = new Size(427, 336);
		((Control)ov).TabIndex = 84;
		((Control)ov).Visible = false;
		((Control)this).AllowDrop = true;
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Form)this).ClientSize = new Size(893, 610);
		((Control)this).Controls.Add((Control)(object)this.m_er);
		((Control)this).Controls.Add((Control)(object)this.m_b3);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MainMenuStrip = this.m_b3;
		((Control)this).Name = "Form1";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Rags Designer";
		((Form)this).FormClosing += a;
		((Form)this).Load += gx;
		((Form)this).Shown += dd;
		((Control)this).LocationChanged += t;
		((Control)this).MouseUp += l;
		((Control)this).Resize += s;
		((Control)val17).ResumeLayout(false);
		((Control)val17).PerformLayout();
		((ISupportInitialize)this.m_fa).EndInit();
		((Control)val18).ResumeLayout(false);
		((Control)val18).PerformLayout();
		((ISupportInitialize)this.m_f7).EndInit();
		((Control)this.m_c5).ResumeLayout(false);
		((Control)this.m_c2).ResumeLayout(false);
		((Control)this.m_ee).ResumeLayout(false);
		((Control)this.m_gu).ResumeLayout(false);
		((Control)hj).ResumeLayout(false);
		((Control)this.m_b0).ResumeLayout(false);
		((Control)this.m_eb).ResumeLayout(false);
		((Control)this.m_dc).ResumeLayout(false);
		((Control)this.m_cr).ResumeLayout(false);
		((Control)this.m_gf).ResumeLayout(false);
		((Control)this.m_ce).ResumeLayout(false);
		((Control)this.m_cd).ResumeLayout(false);
		((Control)this.m_b3).ResumeLayout(false);
		((Control)this.m_b3).PerformLayout();
		((Control)this.m_er.Panel1).ResumeLayout(false);
		((Control)this.m_er.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_er).EndInit();
		((Control)this.m_er).ResumeLayout(false);
		((Control)tabControl1).ResumeLayout(false);
		((Control)this.m_s).ResumeLayout(false);
		((Control)j9).ResumeLayout(false);
		((Control)ka).ResumeLayout(false);
		((Control)ka).PerformLayout();
		((Control)n3).ResumeLayout(false);
		((Control)n3).PerformLayout();
		((Control)this.m_gn).ResumeLayout(false);
		((Control)this.m_gn).PerformLayout();
		((Control)j3).ResumeLayout(false);
		((Control)j3).PerformLayout();
		((ISupportInitialize)this.m_e1).EndInit();
		((Control)kb).ResumeLayout(false);
		((Control)kb).PerformLayout();
		((ISupportInitialize)kc).EndInit();
		((Control)this.m_x).ResumeLayout(false);
		((Control)ij.Panel1).ResumeLayout(false);
		((Control)ij.Panel2).ResumeLayout(false);
		((ISupportInitialize)ij).EndInit();
		((Control)ij).ResumeLayout(false);
		((ISupportInitialize)dgvRoomList).EndInit();
		((Control)tabControl2).ResumeLayout(false);
		((Control)this.m_y).ResumeLayout(false);
		((Control)this.m_y).PerformLayout();
		((ISupportInitialize)this.m_e2).EndInit();
		((Control)this.m_en.Panel1).ResumeLayout(false);
		((Control)this.m_en.Panel1).PerformLayout();
		((Control)this.m_en.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_en).EndInit();
		((Control)this.m_en).ResumeLayout(false);
		((ISupportInitialize)ou).EndInit();
		((ISupportInitialize)this.m_eo).EndInit();
		((Control)this.m_ac).ResumeLayout(false);
		((Control)this.m_ac).PerformLayout();
		((Control)this.m_fe).ResumeLayout(false);
		((Control)this.m_fh).ResumeLayout(false);
		((Control)this.m_fh).PerformLayout();
		((ISupportInitialize)this.m_e3).EndInit();
		((Control)this.m_a9).ResumeLayout(false);
		((Control)this.m_a9).PerformLayout();
		((Control)kl).ResumeLayout(false);
		((Control)kl).PerformLayout();
		((ISupportInitialize)kk).EndInit();
		((ISupportInitialize)this.m_e4).EndInit();
		((Control)this.m_d7).ResumeLayout(false);
		((Control)this.m_d7).PerformLayout();
		((ISupportInitialize)this.m_e5).EndInit();
		((Control)this.m_bd).ResumeLayout(false);
		((Control)tabControl4).ResumeLayout(false);
		((Control)this.m_eu).ResumeLayout(false);
		((Control)this.m_eu).PerformLayout();
		((ISupportInitialize)this.m_e6).EndInit();
		((Control)this.m_es.Panel1).ResumeLayout(false);
		((Control)this.m_es.Panel1).PerformLayout();
		((Control)this.m_es.Panel2).ResumeLayout(false);
		((ISupportInitialize)this.m_es).EndInit();
		((Control)this.m_es).ResumeLayout(false);
		((Control)this.m_eh).ResumeLayout(false);
		((ISupportInitialize)this.m_be).EndInit();
		((Control)this.m_bj).ResumeLayout(false);
		((Control)kv).ResumeLayout(false);
		((ISupportInitialize)mc).EndInit();
		((Control)kw).ResumeLayout(false);
		((Control)kw).PerformLayout();
		((ISupportInitialize)k4).EndInit();
		((Control)this.m_et).ResumeLayout(false);
		((Control)this.m_et).PerformLayout();
		((ISupportInitialize)this.m_e7).EndInit();
		((Control)this.m_br).ResumeLayout(false);
		((Control)tabControl3).ResumeLayout(false);
		((Control)this.m_dh).ResumeLayout(false);
		((Control)this.m_dh).PerformLayout();
		((ISupportInitialize)this.m_e8).EndInit();
		((Control)this.m_dk).ResumeLayout(false);
		((Control)this.m_dk).PerformLayout();
		((Control)hg).ResumeLayout(false);
		((Control)hg).PerformLayout();
		((Control)this.m_ey).ResumeLayout(false);
		((Control)this.m_ey).PerformLayout();
		((Control)this.m_dl).ResumeLayout(false);
		((Control)this.m_dl).PerformLayout();
		((Control)this.m_do).ResumeLayout(false);
		((Control)this.m_do).PerformLayout();
		((Control)k7).ResumeLayout(false);
		((ISupportInitialize)lv).EndInit();
		((Control)k8).ResumeLayout(false);
		((Control)k8).PerformLayout();
		((ISupportInitialize)lg).EndInit();
		((Control)jc).ResumeLayout(false);
		((Control)jd).ResumeLayout(false);
		((Control)jd).PerformLayout();
		((ISupportInitialize)jw).EndInit();
		((Control)jq).ResumeLayout(false);
		((Control)jq).PerformLayout();
		((Control)jj).ResumeLayout(false);
		((Control)jj).PerformLayout();
		((ISupportInitialize)jf).EndInit();
		((Control)this.m_d6).ResumeLayout(false);
		((Control)this.m_d6).PerformLayout();
		((ISupportInitialize)this.m_e9).EndInit();
		((Control)this.m_cu).ResumeLayout(false);
		((Control)il.Panel1).ResumeLayout(false);
		((Control)il.Panel2).ResumeLayout(false);
		((ISupportInitialize)il).EndInit();
		((Control)il).ResumeLayout(false);
		((ISupportInitialize)dgvCharacters).EndInit();
		((Control)tabControlCharData).ResumeLayout(false);
		((Control)this.m_cv).ResumeLayout(false);
		((Control)this.m_cv).PerformLayout();
		((Control)oo).ResumeLayout(false);
		((ISupportInitialize)or).EndInit();
		((ISupportInitialize)this.m_fb).EndInit();
		((Control)this.m_c8).ResumeLayout(false);
		((Control)lj).ResumeLayout(false);
		((ISupportInitialize)lw).EndInit();
		((Control)lk).ResumeLayout(false);
		((Control)lk).PerformLayout();
		((ISupportInitialize)ls).EndInit();
		((Control)this.m_cj).ResumeLayout(false);
		((Control)@in.Panel1).ResumeLayout(false);
		((Control)@in.Panel2).ResumeLayout(false);
		((ISupportInitialize)@in).EndInit();
		((Control)@in).ResumeLayout(false);
		((Control)oc).ResumeLayout(false);
		((Control)lx).ResumeLayout(false);
		((Control)ly).ResumeLayout(false);
		((Control)ly).PerformLayout();
		((Control)i6).ResumeLayout(false);
		((Control)i6).PerformLayout();
		((Control)this.m_ck).ResumeLayout(false);
		((Control)this.m_ck).PerformLayout();
		((Control)this.m_cp).ResumeLayout(false);
		((Control)this.m_cp).PerformLayout();
		((Control)h1).ResumeLayout(false);
		((Control)h1).PerformLayout();
		((ISupportInitialize)iy).EndInit();
		((Control)ms).ResumeLayout(false);
		((Control)g7).ResumeLayout(false);
		((Control)g7).PerformLayout();
		((ISupportInitialize)this.m_fc).EndInit();
		((Control)lz).ResumeLayout(false);
		((Control)l0).ResumeLayout(false);
		((Control)l0).PerformLayout();
		((ISupportInitialize)l8).EndInit();
		((ISupportInitialize)mb).EndInit();
		((Control)this.m_fz).ResumeLayout(false);
		((Control)io.Panel1).ResumeLayout(false);
		((Control)io.Panel1).PerformLayout();
		((Control)io.Panel2).ResumeLayout(false);
		((ISupportInitialize)io).EndInit();
		((Control)io).ResumeLayout(false);
		((ISupportInitialize)dgvTimers).EndInit();
		((Control)tabControl5).ResumeLayout(false);
		((Control)this.m_f0).ResumeLayout(false);
		((Control)this.m_f0).PerformLayout();
		((Control)mu).ResumeLayout(false);
		((Control)mu).PerformLayout();
		((ISupportInitialize)mw).EndInit();
		((Control)hq).ResumeLayout(false);
		((ISupportInitialize)hp).EndInit();
		((Control)this.m_gb).ResumeLayout(false);
		((Control)this.m_gb).PerformLayout();
		((ISupportInitialize)this.m_f1).EndInit();
		((Control)this.m_f2).ResumeLayout(false);
		((Control)md).ResumeLayout(false);
		((ISupportInitialize)me).EndInit();
		((Control)mf).ResumeLayout(false);
		((Control)mf).PerformLayout();
		((ISupportInitialize)mn).EndInit();
		((Control)m5).ResumeLayout(false);
		((Control)m6.Panel1).ResumeLayout(false);
		((Control)m6.Panel2).ResumeLayout(false);
		((ISupportInitialize)m6).EndInit();
		((Control)m6).ResumeLayout(false);
		((ISupportInitialize)m7).EndInit();
		((Control)m9.Panel1).ResumeLayout(false);
		((Control)m9.Panel2).ResumeLayout(false);
		((ISupportInitialize)m9).EndInit();
		((Control)m9).ResumeLayout(false);
		((ISupportInitialize)na).EndInit();
		((Control)nb).ResumeLayout(false);
		((Control)this.m_bs).ResumeLayout(false);
		((Control)this.m_bt).ResumeLayout(false);
		((Control)this.m_bt).PerformLayout();
		((Control)mz).ResumeLayout(false);
		((Control)m0.Panel1).ResumeLayout(false);
		((Control)m0.Panel2).ResumeLayout(false);
		((ISupportInitialize)m0).EndInit();
		((Control)m0).ResumeLayout(false);
		((Control)this.m_bx).ResumeLayout(false);
		((Control)this.m_bx).PerformLayout();
		((Control)my).ResumeLayout(false);
		((ISupportInitialize)ot).EndInit();
		((ISupportInitialize)this.m_bw).EndInit();
		((ISupportInitialize)ov).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[STAThread]
	private static void ao()
	{
		Application.Run((Form)(object)new Form1());
	}

	private void g2(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)this.m_f).ShowDialog() == 1)
		{
			c(((FileDialog)this.m_f).FileName);
		}
	}

	private void c(string A_0)
	{
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Invalid comparison between Unknown and I4
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Invalid comparison between Unknown and I4
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		((FileDialog)this.m_f).FileName = A_0;
		bool flag = false;
		try
		{
			Game.DBName = A_0;
			Game.GetDBConnection();
			TheGame = new Game(A_0);
			while (!Game.bDoneWithWaitDlg)
			{
				Application.DoEvents();
				Thread.Sleep(500);
			}
		}
		catch (Exception)
		{
			flag = true;
		}
		if (flag)
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cryptoStream = null;
			try
			{
				EncDec.Decrypt(A_0, ref memst, ref cryptoStream, this.m_b);
			}
			catch
			{
			}
			memst.Seek(0L, SeekOrigin.Begin);
			TheGame = null;
			try
			{
				TheGame = (Game)new BinaryFormatter().Deserialize(memst);
				cryptoStream.Close();
				cryptoStream.Dispose();
				MessageBox.Show("This game file must be updated to the new storage system.  We will rename your current file to " + A_0 + ".old  Please click OK to continue.");
				File.Copy(A_0, A_0 + ".old", overwrite: true);
				TheGame.CreateDatabase(A_0);
				foreach (GamePicture picture in TheGame.PictureList)
				{
					picture.InsertToDatabase();
				}
				TheGame.UpdateDatabase();
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
		if (!an())
		{
			MessageBox.Show("This game will be in read only mode due to trial limitations.");
		}
		if (TheGame.GameFont == null)
		{
			TheGame.GameFont = new Font("Microsoft Sans Serif", 8.25f);
		}
		((Control)hu).Text = TheGame.GameFont.Name.ToString() + " " + TheGame.GameFont.Size;
		m4.Checked = TheGame.bRepeatbgMusic;
		if (TheGame.bPasswordProtected)
		{
			int i = 0;
			bool flag2 = false;
			for (; i < 3; i++)
			{
				GetNameFrm getNameFrm = new GetNameFrm("Enter Password:");
				DialogResult val = ((Form)getNameFrm).ShowDialog();
				if ((int)val == 2)
				{
					val = ((Form)getNameFrm).ShowDialog();
				}
				if ((int)val == 2)
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
					if (((Control)getNameFrm.txtEntry).Text == TheGame.GamePassword)
					{
						flag2 = true;
						((Control)this.m_el).Text = ((Control)getNameFrm.txtEntry).Text;
						TheGame.GamePassword = EncDec.ComputeHash(((Control)getNameFrm.txtEntry).Text, "SHA1", null);
						break;
					}
				}
				else if (EncDec.VerifyHash(((Control)getNameFrm.txtEntry).Text, "SHA1", TheGame.GamePassword))
				{
					flag2 = true;
					((Control)this.m_el).Text = ((Control)getNameFrm.txtEntry).Text;
					break;
				}
				MessageBox.Show("Incorrect Password.  Please Try Again.");
			}
			if (!flag2)
			{
				TheGame = new Game();
			}
		}
		Game.bUpgrading = false;
		Game.CurrentObjectVersionNumber = Game.ObjectVersionNumber;
		am();
		if (TheGame != null)
		{
			m3.SelectedItem = TheGame.bgMusic;
		}
	}

	private bool an()
	{
		if (!LockData.IsLicensed(bdisplay: false, this.m_c))
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

	private void am()
	{
		if (TheGame != null)
		{
			o();
			ac();
			this.m_gm.Items.Clear();
			this.m_n = ((FileDialog)this.m_f).FileName;
			((Control)this).Text = "Rags Designer - " + this.m_n;
			ObjectActions.SetGameObject(ref TheGame);
			CharacterActions.SetGameObject(ref TheGame);
			RoomActions.SetGameObject(ref TheGame);
			PlayerActions.SetGameObject(ref TheGame);
			TimerActions.SetGameObject(ref TheGame);
			ad();
			ag();
			ah();
			af();
			aj();
			ak();
			f();
			x();
			u();
			e();
			t();
			c();
			d();
			PlayerActions.RefreshActions();
			if (dgvCharacters.Rows.Count > 0)
			{
				((DataGridViewBand)dgvCharacters.Rows[0]).Selected = true;
				((Control)CharacterActions).Enabled = true;
			}
			if (dgvRoomList.Rows.Count > 0 && ((BaseCollection)dgvRoomList.SelectedRows).Count < 1)
			{
				((DataGridViewBand)dgvRoomList.Rows[0]).Selected = true;
				dgvRoomList.FirstDisplayedScrollingRowIndex = 0;
			}
		}
		else
		{
			((Control)this).Text = "Rags Designer";
		}
	}

	private void al()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		tvItems.Nodes.Clear();
		TreeNode A_ = new TreeNode();
		a(ref A_, "Items");
		foreach (TreeNode node in A_.Nodes)
		{
			TreeNode val = node;
			tvItems.Nodes.Add(val);
		}
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i] as GameObject;
			if (gameObject.GroupName != string.Empty)
			{
				TreeNode[] array = tvItems.Nodes.Find(gameObject.GroupName, true);
				if (array.Length != 0)
				{
					array[0].Nodes.Add(gameObject.name, gameObject.name).Tag = gameObject;
				}
				else
				{
					tvItems.Nodes.Add(gameObject.name, gameObject.name).Tag = gameObject;
				}
			}
			else
			{
				tvItems.Nodes.Add(gameObject.name, gameObject.name).Tag = gameObject;
			}
		}
		tvItems.Sort();
	}

	private void ak()
	{
		al();
		b((object)null, (TreeViewEventArgs)null);
	}

	private void aj()
	{
		if (TheGame.ThePlayer.StartingRoom != null)
		{
			((Control)this.m_bi).Text = TheGame.ThePlayer.StartingRoom.Name;
		}
		this.m_bo.Checked = TheGame.ThePlayer.bPromptForName;
		this.m_bn.Checked = TheGame.ThePlayer.bPromptForGender;
		switch (TheGame.ThePlayer.PlayerGender)
		{
		case Player.Gender.Male:
			this.m_bm.Checked = true;
			break;
		case Player.Gender.Female:
			this.m_bl.Checked = true;
			break;
		case Player.Gender.Other:
			this.m_bk.Checked = true;
			break;
		}
		((Control)this.m_bp).Text = TheGame.ThePlayer.Name;
		((Control)this.m_bf).Text = TheGame.ThePlayer.PlayerPortrait;
		((Control)this.m_be).Tag = TheGame.GetGamePictureByName(TheGame.ThePlayer.PlayerPortrait);
		PictureBox val = this.m_be;
		object pictureByName = TheGame.GetPictureByName(TheGame.ThePlayer.PlayerPortrait);
		((Control)val).BackgroundImage = (Image)((pictureByName is Image) ? pictureByName : null);
		((Control)this.m_d8).Text = TheGame.ThePlayer.Description;
		this.m_ex.Checked = TheGame.ThePlayer.bEnforceWeight;
		((Control)this.m_ew).Text = TheGame.ThePlayer.dWeightLimit.ToString();
		k4.Rows.Clear();
		foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
		{
			int num = k4.Rows.Add((object[])new string[2] { customProperty.Name, customProperty.Value });
			((DataGridViewBand)k4.Rows[num]).Tag = customProperty;
		}
		s();
	}

	private void ai()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		if (dBConnection != null && dBConnection.State == ConnectionState.Open)
		{
			dBConnection.Close();
		}
		if (File.Exists(this.m_n))
		{
			File.Copy(this.m_n, this.m_n + ".bak", overwrite: true);
		}
		if (dBConnection != null && dBConnection.State == ConnectionState.Closed)
		{
			dBConnection.Open();
		}
	}

	private void g1(object A_0, EventArgs A_1)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((Control)tabControl1).Focus();
		if (!an())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
			return;
		}
		if (this.m_n != "")
		{
			try
			{
				ai();
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					TheGame.UpdateDatabase();
					DateTime now = DateTime.Now;
					while (!Game.bDoneWithWaitDlg)
					{
						Application.DoEvents();
						if ((DateTime.Now - now).Seconds > 30)
						{
							Game.bDoneWithWaitDlg = true;
						}
					}
				}
				catch
				{
				}
				((Control)this).Text = "Rags Designer - " + this.m_n;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving file " + this.m_n + ". Please try using save as and use a different name.\r\n" + ex.Message);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
			try
			{
				if (this.m_g1.Checked)
				{
					a(A_0: false);
				}
				return;
			}
			catch
			{
				MessageBox.Show("Game saved successfully.  Error running game validation.");
				return;
			}
		}
		g0(null, null);
	}

	private void g0(object A_0, EventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((Control)tabControl1).Focus();
		if (!an())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
		}
		else
		{
			if ((int)((CommonDialog)this.m_g).ShowDialog() == 2)
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.m_n = ((FileDialog)this.m_g).FileName;
				if (Game.DBName != string.Empty && File.Exists(Game.DBName))
				{
					File.Copy(Game.DBName, this.m_n, overwrite: true);
					Game.TheCon.Close();
					Game.DBName = this.m_n;
				}
				else
				{
					TheGame.CreateDatabase(this.m_n);
				}
				TheGame.UpdateDatabase();
				((Control)this).Text = "Rags Designer - " + this.m_n;
				if (this.m_g1.Checked)
				{
					a(A_0: false);
				}
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}

	private void gz(object A_0, EventArgs A_1)
	{
		TheGame.Title = ((Control)this.m_v).Text;
		TheGame.OpeningMessage = ((Control)this.m_t).Text;
	}

	private void gy(object A_0, EventArgs A_1)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		RoomDesigner roomDesigner = new RoomDesigner(null);
		if ((int)((Form)roomDesigner).ShowDialog() == 1)
		{
			Room room = null;
			room = ((roomDesigner.CurRoom == null) ? new Room() : roomDesigner.CurRoom);
			room.Description = ((Control)roomDesigner.txtDescription).Text;
			room.SDesc = ((Control)roomDesigner.txtSDesc).Text;
			room.Name = ((Control)roomDesigner.txtRoomName).Text;
			if (roomDesigner.CurRoom == null)
			{
				TheGame.RoomList.Add(room);
			}
		}
		ah();
	}

	private void ah()
	{
		dgvRoomList.Rows.Clear();
		this.m_a7.Items.Clear();
		this.m_au.Items.Clear();
		this.m_aq.Items.Clear();
		this.m_as.Items.Clear();
		this.m_ao.Items.Clear();
		this.m_am.Items.Clear();
		this.m_ai.Items.Clear();
		this.m_ak.Items.Clear();
		this.m_ag.Items.Clear();
		this.m_ae.Items.Clear();
		ib.Items.Clear();
		ig.Items.Clear();
		this.m_bi.Items.Clear();
		this.m_dd.Items.Clear();
		RoomComboItem roomComboItem = new RoomComboItem();
		roomComboItem.UniqueID = Room.VoidRoomGuid;
		roomComboItem.RoomName = "<None>";
		this.m_dd.Items.Add((object)roomComboItem);
		RoomComboItem roomComboItem2 = new RoomComboItem();
		roomComboItem2.UniqueID = Guid.Empty;
		roomComboItem2.RoomName = string.Empty;
		this.m_a7.Items.Add((object)roomComboItem2);
		this.m_au.Items.Add((object)roomComboItem2);
		this.m_aq.Items.Add((object)roomComboItem2);
		this.m_as.Items.Add((object)roomComboItem2);
		this.m_ao.Items.Add((object)roomComboItem2);
		this.m_am.Items.Add((object)roomComboItem2);
		this.m_ai.Items.Add((object)roomComboItem2);
		this.m_ak.Items.Add((object)roomComboItem2);
		this.m_ag.Items.Add((object)roomComboItem2);
		this.m_ae.Items.Add((object)roomComboItem2);
		ib.Items.Add((object)roomComboItem2);
		ig.Items.Add((object)roomComboItem2);
		foreach (Room room in TheGame.RoomList)
		{
			string empty = string.Empty;
			empty = ((!(room.SDesc == string.Empty)) ? (room.Name + " - " + room.SDesc) : room.Name);
			int num = dgvRoomList.Rows.Add((object[])new string[1] { empty });
			((DataGridViewBand)dgvRoomList.Rows[num]).Tag = room.UniqueID;
			dgvRoomList.Rows[num].Cells[0].Value = empty;
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = room.UniqueID;
			roomComboItem3.RoomName = empty;
			this.m_bi.Items.Add((object)roomComboItem3);
			this.m_a7.Items.Add((object)roomComboItem3);
			this.m_au.Items.Add((object)roomComboItem3);
			this.m_aq.Items.Add((object)roomComboItem3);
			this.m_as.Items.Add((object)roomComboItem3);
			this.m_ao.Items.Add((object)roomComboItem3);
			this.m_am.Items.Add((object)roomComboItem3);
			this.m_ai.Items.Add((object)roomComboItem3);
			this.m_ak.Items.Add((object)roomComboItem3);
			this.m_ag.Items.Add((object)roomComboItem3);
			this.m_ae.Items.Add((object)roomComboItem3);
			ib.Items.Add((object)roomComboItem3);
			ig.Items.Add((object)roomComboItem3);
			this.m_dd.Items.Add((object)roomComboItem3);
		}
		cz(null, null);
		if (TheGame.ThePlayer.StartingRoom != null)
		{
			this.m_bi.SelectedItem = TheGame.ThePlayer.StartingRoom.Name;
		}
	}

	private void ag()
	{
		this.m_gm.Items.Clear();
		((Control)this.m_t).Text = TheGame.OpeningMessage;
		((Control)this.m_v).Text = TheGame.Title;
		this.m_em.Checked = TheGame.bPasswordProtected;
		j6.Checked = TheGame.bHideMainPicDisplay;
		j5.Checked = TheGame.bUseInlineImages;
		j4.Checked = TheGame.bHidePortrait;
		((Control)kg).Text = TheGame.GameInformation;
		((Control)ki).Text = TheGame.GameVersion;
		((Control)ke).Text = TheGame.AuthorName;
		n2.Checked = TheGame.bTurnOffNotifications;
		((ListControl)n7).SelectedIndex = (int)TheGame.SortOrderInventory;
		((ListControl)n9).SelectedIndex = (int)TheGame.SortOrderCharacters;
		((ListControl)n5).SelectedIndex = (int)TheGame.SortOrderRoomObjects;
		foreach (StatusBarItem statusBarItem in TheGame.StatusBarItems)
		{
			this.m_gm.Items.Add((object)statusBarItem.Name);
		}
	}

	private void af()
	{
		ad();
	}

	private void gx(object A_0, EventArgs A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		((TextBoxBase)new TextBox()).SpellCheck.IsEnabled = true;
		k();
		l();
		((ListControl)n5).SelectedIndex = 0;
		((ListControl)n7).SelectedIndex = 0;
		((ListControl)n9).SelectedIndex = 0;
		dgvRoomList.Rows.Clear();
		this.m_b = "²µ±±³àòå²²";
		this.m_c = "åòçê²µÀÅÒç¹\u00b8»ÍÊÍÊ»»»ÍÊËËÉ\u00a0¢¥";
		((Control)hu).Text = TheGame.GameFont.Name.ToString() + " " + TheGame.GameFont.Size;
		m4.Checked = TheGame.bRepeatbgMusic;
		((Control)m3).Text = TheGame.bgMusic;
		ObjectActions.SetPageType(ActionControl.PageType.objects);
		CharacterActions.SetPageType(ActionControl.PageType.characters);
		RoomActions.SetPageType(ActionControl.PageType.room);
		PlayerActions.SetPageType(ActionControl.PageType.player);
		TimerActions.SetPageType(ActionControl.PageType.timers);
		ObjectActions.SetGameObject(ref TheGame);
		CharacterActions.SetGameObject(ref TheGame);
		RoomActions.SetGameObject(ref TheGame);
		PlayerActions.SetGameObject(ref TheGame);
		TimerActions.SetGameObject(ref TheGame);
		ah();
		((Control)CharacterActions).Enabled = false;
		((Control)ObjectActions).Enabled = false;
		((Control)RoomActions).Enabled = false;
		((Control)TimerActions).Enabled = false;
		PlayerActions.RefreshActions();
		Form1.m_d = LockData.IsLicensed(bdisplay: true, this.m_c);
		if (Form1.m_d)
		{
			((ToolStripItem)this.m_gj).Enabled = false;
		}
		if (Settings.Default.CheckForUpdates)
		{
			ThreadPool.QueueUserWorkItem(a, TheGame);
			this.m_g0.Checked = true;
		}
		else
		{
			this.m_g0.Checked = false;
		}
		if (Settings.Default.RunGameCheckOnSave)
		{
			this.m_g1.Checked = true;
		}
		else
		{
			this.m_g1.Checked = false;
		}
		if (Environment.GetCommandLineArgs().Length > 1)
		{
			string text = Environment.GetCommandLineArgs()[1];
			if (text != null)
			{
				c(text);
			}
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
				Form1.m_e = true;
			}
		}
		catch
		{
		}
	}

	private void gw(object A_0, EventArgs A_1)
	{
	}

	private void gv(object A_0, EventArgs A_1)
	{
		TheGame.Title = ((Control)this.m_v).Text;
		TheGame.ValidateText(((Control)this.m_v).Text);
	}

	private void gu(object A_0, EventArgs A_1)
	{
		TheGame.OpeningMessage = ((Control)this.m_t).Text;
		TheGame.ValidateText(((Control)this.m_t).Text);
	}

	private void gt(object A_0, EventArgs A_1)
	{
		((Form)this).Close();
	}

	private void gs(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((CommonDialog)this.m_o).ShowDialog() != 1)
		{
			return;
		}
		bool flag = LockData.IsLicensed(bdisplay: false, this.m_c);
		for (int i = 0; i < ((FileDialog)this.m_o).FileNames.Length; i++)
		{
			if (!flag && TheGame.PictureList.Count >= 10)
			{
				MessageBox.Show("Sorry, you've reached the trial limit for pictures.  Please register your copy of RAGS.");
				break;
			}
			if (Game.DBName == string.Empty)
			{
				MessageBox.Show("The game will now be saved to create your image repository.");
				while (Game.DBName == string.Empty)
				{
					g1(null, null);
					if (Game.DBName == string.Empty)
					{
						MessageBox.Show("Image insertion cancelled.");
						return;
					}
				}
			}
			TheGame.PictureList.Add(new GamePicture(Path.GetFileName(((FileDialog)this.m_o).FileNames[i]), ((FileDialog)this.m_o).FileNames[i]));
		}
		ad();
	}

	private void gr(object A_0, EventArgs A_1)
	{
		if (nr.SelectedNode == null || nr.SelectedNode.Tag == null)
		{
			return;
		}
		string text = nr.SelectedNode.Text;
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			if (string.Compare(((GamePicture)TheGame.PictureList[i]).TheName, text, ignoreCase: true) == 0)
			{
				TheGame.PictureList.Remove(TheGame.PictureList[i]);
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from Media where Name=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@name", text);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@name", dBConnection);
				sqlCeCommand2.Parameters.AddWithValue("@name", text);
				sqlCeCommand2.ExecuteNonQuery();
				sqlCeCommand2.Dispose();
				break;
			}
		}
		ad();
	}

	private void a(ref TreeNode A_0, string A_1)
	{
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
			SqlCeConnection dBConnection = Game.GetDBConnection();
			string empty = string.Empty;
			empty = ((!(A_0.Text == string.Empty)) ? ("Select Name from " + text + " where\r\n                        parent=@parent") : ("Select Name from " + text + " where\r\n                        parent is null or parent=@parent"));
			SqlCeCommand sqlCeCommand = new SqlCeCommand(empty, dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@parent", A_0.Text);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				TreeNode A_2 = A_0.Nodes.Add(sqlCeDataReader["Name"].ToString(), sqlCeDataReader["Name"].ToString(), 3, 3);
				a(ref A_2, A_1);
			}
		}
		catch
		{
		}
	}

	private void ae()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		nr.Nodes.Clear();
		TreeNode A_ = new TreeNode();
		a(ref A_, "Media");
		foreach (TreeNode node in A_.Nodes)
		{
			TreeNode val = node;
			nr.Nodes.Add(val);
		}
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			GamePicture gamePicture = (GamePicture)TheGame.PictureList[i];
			if (gamePicture.GroupName != string.Empty)
			{
				TreeNode[] array = nr.Nodes.Find(gamePicture.GroupName, true);
				if (array.Length != 0)
				{
					array[0].Nodes.Add(gamePicture.TheName).Tag = gamePicture;
				}
				else
				{
					nr.Nodes.Add(gamePicture.TheName).Tag = gamePicture;
				}
			}
			else
			{
				nr.Nodes.Add(gamePicture.TheName).Tag = gamePicture;
			}
		}
		nr.Sort();
	}

	private void ad()
	{
		ae();
		m7.Rows.Clear();
		this.m_eq.Items.Clear();
		this.m_bf.Items.Clear();
		op.Items.Clear();
		m3.Items.Clear();
		this.m_eq.Items.Add((object)"None");
		this.m_bf.Items.Add((object)"None");
		op.Items.Add((object)"None");
		m3.Items.Add((object)string.Empty);
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			m7.Rows.Add(new object[1] { ((GamePicture)TheGame.PictureList[i]).TheName });
			this.m_eq.Items.Add((object)((GamePicture)TheGame.PictureList[i]).TheName);
			this.m_bf.Items.Add((object)((GamePicture)TheGame.PictureList[i]).TheName);
			op.Items.Add((object)((GamePicture)TheGame.PictureList[i]).TheName);
			m3.Items.Add((object)((GamePicture)TheGame.PictureList[i]).TheName);
		}
	}

	private void gq(object A_0, EventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Invalid comparison between Unknown and I4
		if (!LockData.IsLicensed(bdisplay: false, this.m_c) && TheGame.RoomList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for rooms.  Please register your copy of RAGS.");
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please Enter Room Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1 || !(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty))
		{
			return;
		}
		Room room = new Room();
		room.Name = ((Control)getNameFrm.txtEntry).Text;
		if (TheGame.RoomList.Count > 0 && TheGame.RoomList[0] is Room room2)
		{
			foreach (CustomProperty customProperty in room2.CustomProperties)
			{
				room.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
			}
		}
		TheGame.RoomList.Add(room);
		ah();
		dgvRoomList.ClearSelection();
		((DataGridViewBand)dgvRoomList.Rows[dgvRoomList.Rows.Count - 1]).Selected = true;
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if ((int)dgvRoomList.Columns[0].HeaderCell.SortGlyphDirection == 0 || (int)dgvRoomList.Columns[0].HeaderCell.SortGlyphDirection == 2)
		{
			listSortDirection = ListSortDirection.Descending;
		}
		dgvRoomList.Sort(dgvRoomList.Columns[0], listSortDirection);
		dgvRoomList.FirstDisplayedScrollingRowIndex = dgvRoomList.Rows.Count - 1;
		a(room);
	}

	private void a(ref ComboBox A_0, Guid A_1)
	{
		foreach (RoomComboItem item in A_0.Items)
		{
			if (item.UniqueID == A_1)
			{
				A_0.SelectedItem = item;
				break;
			}
		}
	}

	private void a(Room A_0)
	{
		if (A_0.Exits.Count != 12)
		{
			A_0.FixExits();
		}
		this.m_a5.Checked = A_0.GetExit(Exit.Directions.North).bActive;
		this.m_at.Checked = A_0.GetExit(Exit.Directions.South).bActive;
		this.m_ap.Checked = A_0.GetExit(Exit.Directions.East).bActive;
		this.m_ar.Checked = A_0.GetExit(Exit.Directions.West).bActive;
		this.m_an.Checked = A_0.GetExit(Exit.Directions.Up).bActive;
		this.m_al.Checked = A_0.GetExit(Exit.Directions.Down).bActive;
		this.m_aj.Checked = A_0.GetExit(Exit.Directions.NorthWest).bActive;
		this.m_ah.Checked = A_0.GetExit(Exit.Directions.NorthEast).bActive;
		this.m_af.Checked = A_0.GetExit(Exit.Directions.SouthWest).bActive;
		this.m_ad.Checked = A_0.GetExit(Exit.Directions.SouthEast).bActive;
		ia.Checked = A_0.GetExit(Exit.Directions.In).bActive;
		id.Checked = A_0.GetExit(Exit.Directions.Out).bActive;
		d(ref this.m_fx);
		this.m_fx.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fw);
		this.m_fw.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fu);
		this.m_fu.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fv);
		this.m_fv.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_ft);
		this.m_ft.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fs);
		this.m_fs.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fq);
		this.m_fq.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fr);
		this.m_fr.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fp);
		this.m_fp.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref this.m_fo);
		this.m_fo.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref ic);
		ic.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		d(ref @if);
		@if.Items.Insert(0, (object)new RoomComboItem(Room.VoidRoomGuid, "<None>"));
		for (int i = 0; i < @if.Items.Count; i++)
		{
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.North).PortalObjectName)
			{
				((ListControl)this.m_fx).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.South).PortalObjectName)
			{
				((ListControl)this.m_fw).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.East).PortalObjectName)
			{
				((ListControl)this.m_fu).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.West).PortalObjectName)
			{
				((ListControl)this.m_fv).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Up).PortalObjectName)
			{
				((ListControl)this.m_ft).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Down).PortalObjectName)
			{
				((ListControl)this.m_fs).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.NorthWest).PortalObjectName)
			{
				((ListControl)this.m_fr).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.NorthEast).PortalObjectName)
			{
				((ListControl)this.m_fq).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.SouthWest).PortalObjectName)
			{
				((ListControl)this.m_fp).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.SouthEast).PortalObjectName)
			{
				((ListControl)this.m_fo).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.In).PortalObjectName)
			{
				((ListControl)ic).SelectedIndex = i;
			}
			if (((RoomComboItem)@if.Items[i]).UniqueID.ToString() == A_0.GetExit(Exit.Directions.Out).PortalObjectName)
			{
				((ListControl)@if).SelectedIndex = i;
			}
		}
		if (A_0.GetExit(Exit.Directions.North).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.North).DestinationRoom != null)
		{
			a(ref this.m_a7, new Guid(A_0.GetExit(Exit.Directions.North).DestinationRoom));
		}
		else
		{
			((Control)this.m_a7).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.South).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.South).DestinationRoom != null)
		{
			a(ref this.m_au, new Guid(A_0.GetExit(Exit.Directions.South).DestinationRoom));
		}
		else
		{
			((Control)this.m_au).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.East).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.East).DestinationRoom != null)
		{
			a(ref this.m_aq, new Guid(A_0.GetExit(Exit.Directions.East).DestinationRoom));
		}
		else
		{
			((Control)this.m_aq).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.West).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.West).DestinationRoom != null)
		{
			a(ref this.m_as, new Guid(A_0.GetExit(Exit.Directions.West).DestinationRoom));
		}
		else
		{
			((Control)this.m_as).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Up).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Up).DestinationRoom != null)
		{
			a(ref this.m_ao, new Guid(A_0.GetExit(Exit.Directions.Up).DestinationRoom));
		}
		else
		{
			((Control)this.m_ao).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Down).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Down).DestinationRoom != null)
		{
			a(ref this.m_am, new Guid(A_0.GetExit(Exit.Directions.Down).DestinationRoom));
		}
		else
		{
			((Control)this.m_am).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom != null)
		{
			a(ref this.m_ak, new Guid(A_0.GetExit(Exit.Directions.NorthWest).DestinationRoom));
		}
		else
		{
			((Control)this.m_ak).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom != null)
		{
			a(ref this.m_ai, new Guid(A_0.GetExit(Exit.Directions.NorthEast).DestinationRoom));
		}
		else
		{
			((Control)this.m_ai).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom != null)
		{
			a(ref this.m_ag, new Guid(A_0.GetExit(Exit.Directions.SouthWest).DestinationRoom));
		}
		else
		{
			((Control)this.m_ag).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom != null)
		{
			a(ref this.m_ae, new Guid(A_0.GetExit(Exit.Directions.SouthEast).DestinationRoom));
		}
		else
		{
			((Control)this.m_ae).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.In).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.In).DestinationRoom != null)
		{
			a(ref ib, new Guid(A_0.GetExit(Exit.Directions.In).DestinationRoom));
		}
		else
		{
			((Control)ib).Text = "";
		}
		if (A_0.GetExit(Exit.Directions.Out).DestinationRoom != string.Empty && A_0.GetExit(Exit.Directions.Out).DestinationRoom != null)
		{
			a(ref ig, new Guid(A_0.GetExit(Exit.Directions.Out).DestinationRoom));
		}
		else
		{
			((Control)ig).Text = "";
		}
	}

	private void gp(object A_0, EventArgs A_1)
	{
		gq(null, null);
	}

	private void go(object A_0, EventArgs A_1)
	{
		PictureBox val = this.m_bw;
		object pictureByName = TheGame.GetPictureByName(nr.SelectedNode.Text);
		val.Image = (Image)((pictureByName is Image) ? pictureByName : null);
	}

	private void w(object A_0, DragEventArgs A_1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (int)A_1.AllowedEffect == 1)
		{
			A_1.Effect = (DragDropEffects)1;
		}
		else
		{
			A_1.Effect = (DragDropEffects)2;
		}
	}

	private void gn(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.South, ((RoomComboItem)this.m_au.SelectedItem).UniqueID);
	}

	private void gm(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.SouthWest, ((RoomComboItem)this.m_ag.SelectedItem).UniqueID);
	}

	private void gl(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Down, ((RoomComboItem)this.m_am.SelectedItem).UniqueID);
	}

	private void gk(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Up, ((RoomComboItem)this.m_ao.SelectedItem).UniqueID);
	}

	private void gj(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.SouthEast, ((RoomComboItem)this.m_ae.SelectedItem).UniqueID);
	}

	private void gi(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.East, ((RoomComboItem)this.m_aq.SelectedItem).UniqueID);
	}

	private void gh(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.NorthWest, ((RoomComboItem)this.m_ak.SelectedItem).UniqueID);
	}

	private void gg(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.NorthEast, ((RoomComboItem)this.m_ai.SelectedItem).UniqueID);
	}

	private void gf(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.West, ((RoomComboItem)this.m_as.SelectedItem).UniqueID);
	}

	private void ge(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.North).bActive = this.m_a5.Checked;
	}

	private void gd(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.South).bActive = this.m_at.Checked;
	}

	private void gc(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.West).bActive = this.m_ar.Checked;
	}

	private void gb(object A_0, EventArgs A_1)
	{
	}

	private void ga(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.East).bActive = this.m_ap.Checked;
	}

	private void f9(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.Up).bActive = this.m_an.Checked;
	}

	private void f8(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.Down).bActive = this.m_al.Checked;
	}

	private void f7(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.NorthWest).bActive = this.m_aj.Checked;
	}

	private void f6(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.NorthEast).bActive = this.m_ah.Checked;
	}

	private void f5(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.SouthWest).bActive = this.m_af.Checked;
	}

	private void f4(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.SouthEast).bActive = this.m_ad.Checked;
	}

	private void ac()
	{
		ji.Items.Clear();
		jp.Items.Clear();
		foreach (string layeredClothingZone in TheGame.LayeredClothingZones)
		{
			ji.Items.Add((object)layeredClothingZone);
			jp.Items.Add((object)layeredClothingZone);
		}
		if (jp.Items.Count > 0)
		{
			((ListControl)jp).SelectedIndex = 0;
		}
		((ListControl)jn).SelectedIndex = 0;
	}

	private void f3(object A_0, EventArgs A_1)
	{
		if (string.Compare(this.m_eq.Items[((ListControl)this.m_eq).SelectedIndex].ToString(), "None", ignoreCase: true) != 0)
		{
			object pictureByName = TheGame.GetPictureByName(this.m_eq.SelectedItem.ToString());
			Image val = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val != null)
			{
				((Control)ou).Visible = false;
				((Control)this.m_eo).Visible = true;
				((Control)this.m_eo).Tag = TheGame.GetGamePictureByName(this.m_eq.SelectedItem.ToString());
				((Control)this.m_eo).BackgroundImage = val;
			}
			else
			{
				((Control)ou).Visible = true;
				((Control)this.m_eo).Visible = false;
				ou.URL = pictureByName as string;
			}
			Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			if (roomByID != null)
			{
				roomByID.RoomPic = this.m_eq.SelectedItem.ToString();
			}
		}
		else
		{
			((Control)this.m_eo).Tag = null;
			((Control)this.m_eo).BackgroundImage = null;
			Room roomByID2 = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			if (roomByID2 != null)
			{
				roomByID2.RoomPic = "None";
			}
		}
	}

	private void a(Exit.Directions A_0, Guid A_1)
	{
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Invalid comparison between Unknown and I4
		if (A_1 == Guid.Empty)
		{
			if (TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom != null && TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom != string.Empty)
			{
				string destinationRoom = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom;
				TheGame.GetRoomByID(new Guid(destinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
			}
			TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).PortalObjectName = "<None>";
			TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom = string.Empty;
			return;
		}
		if (A_1 == Guid.Empty)
		{
			TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom = string.Empty;
			return;
		}
		if (TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom != string.Empty && TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom != A_1.ToString())
		{
			Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			Room room = null;
			if (roomByID.GetExit(A_0).DestinationRoom != null)
			{
				room = TheGame.GetRoomByID(new Guid(roomByID.GetExit(A_0).DestinationRoom));
			}
			if (room != null)
			{
				room.GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
				room.GetExit(Exit.GetOppositeDir(A_0)).DestinationRoom = null;
			}
			roomByID.GetExit(A_0).PortalObjectName = "<None>";
			this.m_fx.SelectedItem = roomByID.GetExit(Exit.Directions.North).PortalObjectName;
			this.m_fw.SelectedItem = roomByID.GetExit(Exit.Directions.South).PortalObjectName;
			this.m_fu.SelectedItem = roomByID.GetExit(Exit.Directions.East).PortalObjectName;
			this.m_fv.SelectedItem = roomByID.GetExit(Exit.Directions.West).PortalObjectName;
			this.m_ft.SelectedItem = roomByID.GetExit(Exit.Directions.Up).PortalObjectName;
			this.m_fs.SelectedItem = roomByID.GetExit(Exit.Directions.Down).PortalObjectName;
			this.m_fr.SelectedItem = roomByID.GetExit(Exit.Directions.NorthWest).PortalObjectName;
			this.m_fq.SelectedItem = roomByID.GetExit(Exit.Directions.NorthEast).PortalObjectName;
			this.m_fp.SelectedItem = roomByID.GetExit(Exit.Directions.SouthWest).PortalObjectName;
			this.m_fo.SelectedItem = roomByID.GetExit(Exit.Directions.SouthEast).PortalObjectName;
			ic.SelectedItem = roomByID.GetExit(Exit.Directions.In).PortalObjectName;
			@if.SelectedItem = roomByID.GetExit(Exit.Directions.Out).PortalObjectName;
		}
		if (TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom == null || TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom != A_1.ToString())
		{
			TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).DestinationRoom = A_1.ToString();
			if ((int)MessageBox.Show("Would you like the destination room to link back to this room?", "Two way exit?", (MessageBoxButtons)4) == 6)
			{
				TheGame.GetRoomByID(A_1).GetExit(Exit.GetOppositeDir(A_0)).DestinationRoom = ((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag/*cast due to constrained. prefix*/).ToString();
				TheGame.GetRoomByID(A_1).GetExit(Exit.GetOppositeDir(A_0)).bActive = true;
			}
		}
	}

	private void f2(object A_0, EventArgs A_1)
	{
		TheGame.ThePlayer.Name = ((Control)this.m_bp).Text;
	}

	private void f1(object A_0, EventArgs A_1)
	{
		if (this.m_bi.SelectedItem != null && ((Control)this.m_bi).Text.Trim().Length > 0)
		{
			TheGame.ThePlayer.StartingRoom = TheGame.GetRoomByID(((RoomComboItem)this.m_bi.SelectedItem).UniqueID);
		}
	}

	private void f0(object A_0, EventArgs A_1)
	{
		TheGame.ThePlayer.bPromptForName = this.m_bo.Checked;
	}

	private void fz(object A_0, EventArgs A_1)
	{
		TheGame.ThePlayer.bPromptForGender = this.m_bn.Checked;
	}

	private void fy(object A_0, EventArgs A_1)
	{
		if (this.m_bm.Checked)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Male;
		}
		else if (this.m_bl.Checked)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Female;
		}
		else if (this.m_bk.Checked)
		{
			TheGame.ThePlayer.PlayerGender = Player.Gender.Other;
		}
	}

	private void fx(object A_0, EventArgs A_1)
	{
		if (this.m_bf.SelectedItem.ToString() == "None")
		{
			((Control)this.m_be).Tag = null;
			((Control)this.m_be).BackgroundImage = null;
			((Control)this.m_be).Invalidate();
			TheGame.ThePlayer.PlayerPortrait = "";
			return;
		}
		TheGame.ThePlayer.PlayerPortrait = this.m_bf.SelectedItem.ToString();
		object pictureByName = TheGame.GetPictureByName(this.m_bf.SelectedItem.ToString());
		Image val = (Image)((pictureByName is Image) ? pictureByName : null);
		if (val != null)
		{
			((Control)ov).Visible = false;
			((Control)this.m_be).Visible = true;
			((Control)this.m_be).Tag = TheGame.GetGamePictureByName(this.m_bf.SelectedItem.ToString());
			((Control)this.m_be).BackgroundImage = val;
		}
		else
		{
			((Control)ov).Visible = true;
			((Control)this.m_be).Visible = false;
			ov.URL = pictureByName as string;
		}
	}

	private void fw(object A_0, EventArgs A_1)
	{
		Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
		if (roomByID != null)
		{
			roomByID.Description = ((Control)txtRoomDescription).Text;
			TheGame.ValidateText(((Control)txtRoomDescription).Text);
		}
	}

	private void fv(object A_0, EventArgs A_1)
	{
		Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
		if (roomByID != null)
		{
			roomByID.SDesc = ((Control)txtRoomSDesc).Text;
			TheGame.ValidateText(((Control)txtRoomSDesc).Text);
		}
	}

	private void fu(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.North, ((RoomComboItem)this.m_a7.SelectedItem).UniqueID);
	}

	private void ft(object A_0, EventArgs A_1)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!LockData.IsLicensed(bdisplay: false, this.m_c) && TheGame.ObjectList.Count >= 10)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for objects.  Please register your copy of RAGS.");
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please enter object name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		GameObject gameObject = new GameObject();
		gameObject.name = ((Control)getNameFrm.txtEntry).Text;
		if (TheGame.ObjectList.Count > 0 && TheGame.ObjectList[0] is GameObject gameObject2)
		{
			foreach (CustomProperty customProperty in gameObject2.CustomProperties)
			{
				gameObject.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
			}
		}
		TheGame.ObjectList.Add(gameObject);
		tabControl1.SelectedIndex = 3;
		tabControl3.SelectedIndex = 0;
		ab();
		f();
		TreeNode[] array = tvItems.Nodes.Find(gameObject.name, true);
		if (array.Length != 0)
		{
			tvItems.SelectedNode = array[0];
			array[0].Expand();
		}
	}

	private void ab()
	{
		al();
	}

	private void fs(object A_0, EventArgs A_1)
	{
	}

	private void fr(object A_0, EventArgs A_1)
	{
		ft(null, null);
	}

	private void aa()
	{
		this.m_dj.Items.Clear();
		if (tvItems.SelectedNode == null || tvItems.SelectedNode.Tag == null)
		{
			return;
		}
		GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_IN_OBJECT && @object.locationname == gameObject.UniqueIdentifier.ToString())
			{
				this.m_dj.Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void fq(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			(tvItems.SelectedNode.Tag as GameObject).sdesc = ((Control)this.m_d1).Text;
			TheGame.ValidateText(((Control)this.m_d1).Text);
		}
	}

	private void fp(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			(tvItems.SelectedNode.Tag as GameObject).description = ((Control)this.m_dz).Text;
			TheGame.ValidateText(((Control)this.m_dz).Text);
		}
	}

	private void b(object A_0, PaintEventArgs A_1)
	{
	}

	private void fo(object A_0, EventArgs A_1)
	{
	}

	private void v(object A_0, DragEventArgs A_1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (int)A_1.AllowedEffect == 1)
		{
			A_1.Effect = (DragDropEffects)1;
		}
		else
		{
			A_1.Effect = (DragDropEffects)2;
		}
	}

	private void u(object A_0, DragEventArgs A_1)
	{
	}

	private void t(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			((Control)this.m_eq).Text = (string)A_1.Data.GetData(DataFormats.Text);
		}
	}

	private void fn(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bCarryable = this.m_dy.Checked;
		}
	}

	private void fm(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bWearable = this.m_dx.Checked;
		}
	}

	private void fl(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bOpenable = this.m_dw.Checked;
		}
	}

	private void fk(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bLockable = this.m_dv.Checked;
		}
	}

	private void fj(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bEnterable = this.m_du.Checked;
		}
	}

	private void fi(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bReadable = this.m_dt.Checked;
		}
	}

	private void fh(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).dWeight = Convert.ToDouble(((Control)this.m_dr).Text);
		}
	}

	private void fg(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
			if (this.m_bb.Items.IndexOf((object)gameObject.name) == -1)
			{
				((GameObject)tvItems.SelectedNode.Tag).locationtype = GameObject.LocationType.LT_ROOM;
				((GameObject)tvItems.SelectedNode.Tag).locationname = ((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag.ToString();
			}
		}
		s();
	}

	private void z()
	{
		this.m_bb.Items.Clear();
		if (((BaseCollection)dgvRoomList.SelectedRows).Count != 1)
		{
			return;
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			Guid result = default;
			if (Guid.TryParse(@object.locationname, out result) && @object.locationtype == GameObject.LocationType.LT_ROOM && new Guid(@object.locationname) == (Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag)
			{
				this.m_bb.Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void ff(object A_0, EventArgs A_1)
	{
		fg(null, null);
	}

	private void fe(object A_0, EventArgs A_1)
	{
		for (int num = this.m_bb.SelectedItems.Count - 1; num >= 0; num--)
		{
			TheGame.RemoveRoomObject((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag, this.m_bb.SelectedItems[num].ToString());
		}
		s();
	}

	private void j(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			A_0.Items.Add((object)((GamePicture)TheGame.PictureList[i]).TheName);
		}
	}

	private void i(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			A_0.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
		}
	}

	private void h(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (((GameObject)TheGame.ObjectList[i]).bCarryable)
			{
				A_0.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
			}
		}
	}

	private void g(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (((GameObject)TheGame.ObjectList[i]).bWearable)
			{
				A_0.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
			}
		}
	}

	private void f(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.CharacterList.Count; i++)
		{
			A_0.Items.Add((object)((Character)TheGame.CharacterList[i]).Charname);
		}
	}

	private void e(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (((GameObject)TheGame.ObjectList[i]).bLockable)
			{
				A_0.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
			}
		}
	}

	private void d(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (((GameObject)TheGame.ObjectList[i]).bOpenable)
			{
				A_0.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
			}
		}
	}

	private void c(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		A_0.Items.Add((object)"North-Active");
		A_0.Items.Add((object)"North-InActive");
		A_0.Items.Add((object)"South-Active");
		A_0.Items.Add((object)"South-InActive");
		A_0.Items.Add((object)"East-Active");
		A_0.Items.Add((object)"East-InActive");
		A_0.Items.Add((object)"West-Active");
		A_0.Items.Add((object)"West-InActive");
		A_0.Items.Add((object)"Up-Active");
		A_0.Items.Add((object)"Up-InActive");
		A_0.Items.Add((object)"Down-Active");
		A_0.Items.Add((object)"Down-InActive");
		A_0.Items.Add((object)"NorthEast-Active");
		A_0.Items.Add((object)"NorthEast-InActive");
		A_0.Items.Add((object)"NorthWest-Active");
		A_0.Items.Add((object)"NorthWest-InActive");
		A_0.Items.Add((object)"SouthEast-Active");
		A_0.Items.Add((object)"SouthEast-InActive");
		A_0.Items.Add((object)"SouthWest-Active");
		A_0.Items.Add((object)"SouthWest-InActive");
	}

	private void b(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.RoomList.Count; i++)
		{
			A_0.Items.Add((object)((Room)TheGame.RoomList[i]).Name);
		}
	}

	private void a(ref ComboBox A_0)
	{
		A_0.Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			A_0.Items.Add((object)((GameVariable)TheGame.VariableList[i]).varname);
		}
	}

	private void fd(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).locationtype = GameObject.LocationType.LT_PLAYER;
			((GameObject)tvItems.SelectedNode.Tag).locationname = "";
		}
		s();
	}

	private void y()
	{
		this.m_cc.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (((GameObject)TheGame.ObjectList[i]).locationtype == GameObject.LocationType.LT_PLAYER)
			{
				this.m_cc.Items.Add((object)new RoomComboItem(((GameObject)TheGame.ObjectList[i]).UniqueIdentifier, ((GameObject)TheGame.ObjectList[i]).name));
			}
		}
	}

	private void fc(object A_0, EventArgs A_1)
	{
		fb(null, null);
	}

	private void fb(object A_0, EventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		if (!LockData.IsLicensed(bdisplay: false, this.m_c) && TheGame.VariableList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for variables.  Please register your copy of RAGS.");
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please Enter Variable Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.varname == ((Control)getNameFrm.txtEntry).Text)
			{
				MessageBox.Show("Sorry, that variable name is already in use.");
				return;
			}
		}
		GameVariable gameVariable = new GameVariable(((Control)getNameFrm.txtEntry).Text);
		if (TheGame.VariableList.Count > 0 && TheGame.VariableList[0] is GameVariable gameVariable2)
		{
			foreach (CustomProperty customProperty in gameVariable2.CustomProperties)
			{
				gameVariable.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
			}
		}
		TheGame.VariableList.Add(gameVariable);
		gameVariable.vartype = GameVariable.VarType.VT_NUMBER;
		x();
		foreach (TreeNode node in tvVariables.Nodes)
		{
			TreeNode val = node;
			if (val.Tag == gameVariable)
			{
				tvVariables.SelectedNode = val;
				break;
			}
		}
	}

	private void x()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		tvVariables.Nodes.Clear();
		TreeNode A_ = new TreeNode();
		a(ref A_, "Variables");
		foreach (TreeNode node in A_.Nodes)
		{
			TreeNode val = node;
			tvVariables.Nodes.Add(val);
		}
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i] as GameVariable;
			if (gameVariable.GroupName != string.Empty)
			{
				TreeNode[] array = tvVariables.Nodes.Find(gameVariable.GroupName, true);
				if (array.Length != 0)
				{
					array[0].Nodes.Add(gameVariable.varname, gameVariable.varname).Tag = gameVariable;
				}
				else
				{
					tvVariables.Nodes.Add(gameVariable.varname, gameVariable.varname).Tag = gameVariable;
				}
			}
			else
			{
				tvVariables.Nodes.Add(gameVariable.varname, gameVariable.varname).Tag = gameVariable;
			}
		}
		tvVariables.Sort();
		tvVariables.ExpandAll();
	}

	private void fa(object A_0, EventArgs A_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (tvVariables.SelectedNode.Tag == null)
		{
			return;
		}
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		if (gameVariable.vartype == GameVariable.VarType.VT_NUMBER)
		{
			try
			{
				gameVariable.dNumType = Convert.ToDouble(((Control)this.m_cq).Text);
				return;
			}
			catch
			{
				MessageBox.Show("Please enter a valid number in the initial value box.");
				((Control)this.m_cq).Focus();
				return;
			}
		}
		gameVariable.sString = ((Control)this.m_cq).Text;
		TheGame.ValidateText(((Control)this.m_cq).Text);
	}

	private void e9(object A_0, EventArgs A_1)
	{
		((Control)this.m_do).Enabled = this.m_dw.Checked;
	}

	private void e8(object A_0, EventArgs A_1)
	{
		((Control)this.m_dl).Enabled = this.m_dv.Checked;
	}

	private void e7(object A_0, EventArgs A_1)
	{
		if (this.m_dq.Checked)
		{
			((GameObject)tvItems.SelectedNode.Tag).bOpen = true;
		}
		else
		{
			((GameObject)tvItems.SelectedNode.Tag).bOpen = false;
		}
	}

	private void e6(object A_0, EventArgs A_1)
	{
		if (this.m_dn.Checked)
		{
			((GameObject)tvItems.SelectedNode.Tag).bLocked = true;
		}
		else
		{
			((GameObject)tvItems.SelectedNode.Tag).bLocked = false;
		}
	}

	private void e5(object A_0, EventArgs A_1)
	{
	}

	private void e4(object A_0, EventArgs A_1)
	{
	}

	private void w()
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Invalid comparison between Unknown and I4
		ArrayList objectnames = new ArrayList();
		GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (gameObject.UniqueIdentifier != @object.UniqueIdentifier)
			{
				objectnames.Add(new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
		SelectObjectsFrm selectObjectsFrm = new SelectObjectsFrm(ref objectnames);
		if ((int)((Form)selectObjectsFrm).ShowDialog() == 1)
		{
			for (int i = 0; i < selectObjectsFrm.lbObjectsToAdd.SelectedItems.Count; i++)
			{
				GameObject objectByName = TheGame.GetObjectByName(((RoomComboItem)selectObjectsFrm.lbObjectsToAdd.SelectedItems[i]).UniqueID.ToString());
				if (objectByName != null)
				{
					objectByName.locationtype = GameObject.LocationType.LT_IN_OBJECT;
					objectByName.locationname = gameObject.UniqueIdentifier.ToString();
				}
			}
		}
		b((object)null, (TreeViewEventArgs)null);
	}

	private void v()
	{
		for (int i = 0; i < this.m_dj.SelectedItems.Count; i++)
		{
			_ = this.m_dj.SelectedItems[i];
			TheGame.GetObjectByName(((RoomComboItem)this.m_dj.SelectedItems[i]).UniqueID.ToString()).locationtype = GameObject.LocationType.LT_NULL;
		}
		b((object)null, (TreeViewEventArgs)null);
	}

	private void e3(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		if (((ToolStripItem)val).Text == "Add Objects")
		{
			w();
		}
		else if (((ToolStripItem)val).Text == "Remove Selected Objects")
		{
			v();
		}
	}

	private void m(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 2097152 && ((Control)this.m_dj).Enabled)
		{
			int num = this.m_dj.IndexFromPoint(A_1.X, A_1.Y);
			if (num != -1)
			{
				this.m_dj.SelectedItems.Add(this.m_dj.Items[num]);
			}
			ContextMenuStrip val = new ContextMenuStrip();
			ToolStripMenuItem val2 = new ToolStripMenuItem("Add Objects");
			((ToolStripItem)val2).Click += e3;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val2);
			val2 = new ToolStripMenuItem("Remove Selected Objects");
			((ToolStripItem)val2).Click += e3;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val2);
			((ToolStripDropDown)val).Show((Control)(object)this.m_dj, A_1.X, A_1.Y);
		}
	}

	private void e2(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Invalid comparison between Unknown and I4
		ToolStripMenuItem val = (ToolStripMenuItem)A_0;
		if (((ToolStripItem)val).Text == "Add Character")
		{
			e1(null, null);
		}
		else
		{
			if (!(((ToolStripItem)val).Text == "Remove Selected Characters"))
			{
				return;
			}
			foreach (DataGridViewRow item in (BaseCollection)dgvCharacters.SelectedRows)
			{
				DataGridViewRow val2 = item;
				TheGame.CharacterList.Remove(((DataGridViewBand)val2).Tag);
			}
			u();
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if ((int)dgvCharacters.Columns[0].HeaderCell.SortGlyphDirection == 0 || (int)dgvCharacters.Columns[0].HeaderCell.SortGlyphDirection == 2)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			dgvCharacters.Sort(dgvCharacters.Columns[0], listSortDirection);
		}
	}

	private void e1(object A_0, EventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Invalid comparison between Unknown and I4
		if (!LockData.IsLicensed(bdisplay: false, this.m_c) && TheGame.CharacterList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for characters.  Please register your copy of RAGS.");
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please enter character name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		foreach (Character character3 in TheGame.CharacterList)
		{
			if (character3.Charname.ToUpper() == ((Control)getNameFrm.txtEntry).Text.ToUpper())
			{
				MessageBox.Show("Sorry, you already have a character named " + ((Control)getNameFrm.txtEntry).Text + ".  Please use a unique character name.  If you need duplicate character names, please use the override name option in the character's general setup.");
				return;
			}
		}
		Character character = new Character(((Control)getNameFrm.txtEntry).Text);
		if (TheGame.CharacterList.Count > 0 && TheGame.CharacterList[0] is Character character2)
		{
			foreach (CustomProperty customProperty in character2.CustomProperties)
			{
				character.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
			}
		}
		TheGame.CharacterList.Add(character);
		u();
		dgvCharacters.ClearSelection();
		foreach (DataGridViewRow item in (IEnumerable)dgvCharacters.Rows)
		{
			DataGridViewRow val = item;
			character = (Character)((DataGridViewBand)val).Tag;
			if (character.Charname == ((Control)getNameFrm.txtEntry).Text)
			{
				((DataGridViewBand)val).Selected = true;
				dgvCharacters.FirstDisplayedScrollingRowIndex = ((DataGridViewBand)val).Index;
				break;
			}
		}
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if ((int)dgvCharacters.Columns[0].HeaderCell.SortGlyphDirection == 0 || (int)dgvCharacters.Columns[0].HeaderCell.SortGlyphDirection == 2)
		{
			listSortDirection = ListSortDirection.Descending;
		}
		dgvCharacters.Sort(dgvCharacters.Columns[0], listSortDirection);
		e();
	}

	private void u()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		dgvCharacters.Rows.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			DataGridViewRow val = new DataGridViewRow();
			DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
			((DataGridViewCell)val2).Value = character.Charname;
			val.Cells.Add((DataGridViewCell)(object)val2);
			((DataGridViewBand)val).Tag = character;
			dgvCharacters.Rows.Add(val);
		}
	}

	private void t()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Invalid comparison between Unknown and I4
		dgvTimers.Rows.Clear();
		for (int i = 0; i < TheGame.TimerList.Count; i++)
		{
			DataGridViewRow val = new DataGridViewRow();
			((DataGridViewBand)val).Tag = (Rags.Timer)TheGame.TimerList[i];
			DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
			val.Cells.Add((DataGridViewCell)(object)val2);
			((DataGridViewCell)val2).ReadOnly = true;
			((DataGridViewCell)val2).Value = (i + 1).ToString();
			val2 = new DataGridViewTextBoxCell();
			val.Cells.Add((DataGridViewCell)(object)val2);
			((DataGridViewCell)val2).ReadOnly = true;
			((DataGridViewCell)val2).Value = ((Rags.Timer)TheGame.TimerList[i]).Name;
			dgvTimers.Rows.Add(val);
		}
		hp.Minimum = 1m;
		hp.Maximum = TheGame.TimerList.Count + 1;
		DataGridViewColumn val3 = null;
		val3 = (((int)dgvTimers.Columns[0].HeaderCell.SortGlyphDirection == 0) ? dgvTimers.Columns[1] : dgvTimers.Columns[0]);
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if ((int)val3.HeaderCell.SortGlyphDirection == 0 || (int)val3.HeaderCell.SortGlyphDirection == 2)
		{
			listSortDirection = ListSortDirection.Descending;
		}
		dgvTimers.Sort(val3, listSortDirection);
	}

	private void e0(object A_0, EventArgs A_1)
	{
		ey(null, null);
	}

	private void ez(object A_0, EventArgs A_1)
	{
		foreach (RoomComboItem selectedItem in this.m_cx.SelectedItems)
		{
			for (int i = 0; i < TheGame.ObjectList.Count; i++)
			{
				GameObject gameObject = (GameObject)TheGame.ObjectList[i];
				if (gameObject.UniqueIdentifier == selectedItem.UniqueID && gameObject.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject.locationname == dgvCharacters.SelectedRows[0].Cells[0].Value.ToString())
				{
					gameObject.locationtype = GameObject.LocationType.LT_NULL;
				}
			}
		}
		s();
	}

	private void ey(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
			if (this.m_cx.Items.IndexOf((object)gameObject.name) == -1)
			{
				((GameObject)tvItems.SelectedNode.Tag).locationtype = GameObject.LocationType.LT_CHARACTER;
				((GameObject)tvItems.SelectedNode.Tag).locationname = dgvCharacters.SelectedRows[0].Cells[0].Value.ToString();
			}
		}
		s();
	}

	private void s()
	{
		r();
		aa();
		y();
		z();
	}

	private void r()
	{
		if (((BaseCollection)dgvCharacters.SelectedRows).Count <= 0)
		{
			return;
		}
		this.m_cx.Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = (GameObject)TheGame.ObjectList[i];
			if (gameObject.locationtype == GameObject.LocationType.LT_CHARACTER && gameObject.locationname == dgvCharacters.SelectedRows[0].Cells[0].Value.ToString())
			{
				this.m_cx.Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void ex(object A_0, EventArgs A_1)
	{
		Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
		if (character != null)
		{
			if (this.m_cz.Checked)
			{
				character.CharGender = Player.Gender.Female;
			}
			else if (this.m_c0.Checked)
			{
				character.CharGender = Player.Gender.Male;
			}
			else
			{
				character.CharGender = Player.Gender.Other;
			}
		}
	}

	private void ew(object A_0, EventArgs A_1)
	{
		Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
		if (character != null)
		{
			character.CurrentRoom = ((RoomComboItem)this.m_dd.SelectedItem).UniqueID.ToString();
		}
	}

	private void ev(object A_0, EventArgs A_1)
	{
		Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
		if (character != null)
		{
			character.Description = ((Control)this.m_df).Text;
			TheGame.ValidateText(((Control)this.m_df).Text);
		}
	}

	private void eu(object A_0, EventArgs A_1)
	{
		TheGame.ThePlayer.Description = ((Control)this.m_d8).Text;
		TheGame.ValidateText(((Control)this.m_d8).Text);
	}

	private void et(object A_0, EventArgs A_1)
	{
		fd(null, null);
	}

	private void es(object A_0, EventArgs A_1)
	{
		er(null, null);
	}

	private void er(object A_0, EventArgs A_1)
	{
		foreach (RoomComboItem selectedItem in this.m_cc.SelectedItems)
		{
			TheGame.GetObjectByName(selectedItem.UniqueID.ToString()).locationtype = GameObject.LocationType.LT_NULL;
		}
		s();
	}

	private void s(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "lbItems")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void r(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			fd(null, null);
		}
	}

	private void q(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "tvNode")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void p(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			if (nr.SelectedNode != null && nr.SelectedNode.Tag != null)
			{
				this.m_eq.SelectedItem = nr.SelectedNode.Text;
			}
		}
	}

	private void o(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			fg(null, null);
		}
	}

	private void n(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			if (nr.SelectedNode != null && nr.SelectedNode.Tag != null)
			{
				this.m_bf.SelectedItem = nr.SelectedNode.Text;
			}
		}
	}

	private void m(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			fg(null, null);
		}
	}

	private void l(object A_0, MouseEventArgs A_1)
	{
		this.m_h = false;
		this.m_j = false;
	}

	private void eq(object A_0, EventArgs A_1)
	{
		w();
	}

	private void ep(object A_0, EventArgs A_1)
	{
		v();
	}

	private void eo(object A_0, EventArgs A_1)
	{
		((Control)this.m_el).Enabled = this.m_em.Checked;
		TheGame.bPasswordProtected = this.m_em.Checked;
	}

	private void en(object A_0, EventArgs A_1)
	{
		TheGame.GamePassword = EncDec.ComputeHash(((Control)this.m_el).Text, "SHA1", null);
	}

	private void em(object A_0, EventArgs A_1)
	{
		if (tvVariables.SelectedNode != null)
		{
			if (tvVariables.SelectedNode.Tag is GameVariable obj)
			{
				TheGame.VariableList.Remove(obj);
			}
			x();
		}
	}

	private void el(object A_0, EventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between Unknown and I4
		foreach (DataGridViewRow item in (BaseCollection)dgvRoomList.SelectedRows)
		{
			DataGridViewRow val = item;
			TheGame.RoomList.Remove(TheGame.GetRoomByID((Guid)((DataGridViewBand)val).Tag));
		}
		ah();
		ListSortDirection listSortDirection = ListSortDirection.Ascending;
		if ((int)dgvRoomList.Columns[0].HeaderCell.SortGlyphDirection == 0 || (int)dgvRoomList.Columns[0].HeaderCell.SortGlyphDirection == 2)
		{
			listSortDirection = ListSortDirection.Descending;
		}
		dgvRoomList.Sort(dgvRoomList.Columns[0], listSortDirection);
	}

	private void ek(object A_0, EventArgs A_1)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
			if ((int)MessageBox.Show("Are you sure you want to delete " + gameObject.name + "?", "Delete Confirmation", (MessageBoxButtons)4) == 6)
			{
				TheGame.ObjectList.Remove(tvItems.SelectedNode.Tag);
				ab();
			}
		}
	}

	private void ej(object A_0, EventArgs A_1)
	{
		((Control)this.m_ew).Enabled = this.m_ex.Checked;
	}

	private void ei(object A_0, EventArgs A_1)
	{
		TheGame.ThePlayer.bEnforceWeight = this.m_ex.Checked;
	}

	private void eh(object A_0, EventArgs A_1)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		try
		{
			num = Convert.ToDouble(((Control)this.m_ew).Text);
		}
		catch
		{
			MessageBox.Show("Please Enter A Valid Number For Carry Weight Limit.");
			((Control)this.m_ew).Focus();
			return;
		}
		TheGame.ThePlayer.dWeightLimit = num;
	}

	private void a(object A_0, TabControlEventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null && ((Control)A_1.TabPage).Name == "tabPage6" && tvItems.SelectedNode.Tag is GameObject gameObject)
		{
			this.m_dy.Checked = gameObject.bCarryable;
			this.m_dx.Checked = gameObject.bWearable;
			this.m_dw.Checked = gameObject.bOpenable;
			((Control)this.m_dj).Enabled = gameObject.bContainer;
			this.m_dv.Checked = gameObject.bLockable;
			this.m_du.Checked = gameObject.bEnterable;
			this.m_dt.Checked = gameObject.bReadable;
		}
	}

	private void eg(object A_0, EventArgs A_1)
	{
		if (this.m_e0.Checked)
		{
			((GameObject)tvItems.SelectedNode.Tag).bWorn = true;
		}
		else
		{
			((GameObject)tvItems.SelectedNode.Tag).bWorn = false;
		}
	}

	private void ef(object A_0, EventArgs A_1)
	{
		((Control)this.m_ey).Enabled = this.m_dx.Checked;
	}

	private void a(object A_0, FormClosingEventArgs A_1)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Invalid comparison between Unknown and I4
		m();
		((SettingsBase)Settings.Default).Save();
		bool flag = true;
		if (this.m_n != string.Empty)
		{
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, TheGame);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			if (this.m_a != null && memoryStream.Length == this.m_a.Length)
			{
				flag = false;
			}
			memoryStream.Close();
			memoryStream.Dispose();
		}
		if (flag)
		{
			DialogResult val = MessageBox.Show("Would you like to save any changes before exiting?", "Save", (MessageBoxButtons)3);
			if ((int)val == 6)
			{
				g1(null, null);
				_ = DateTime.Now;
			}
			else if ((int)val == 2)
			{
				((CancelEventArgs)(object)A_1).Cancel = true;
			}
		}
		if (TheGame == null)
		{
			return;
		}
		foreach (GamePicture picture in TheGame.PictureList)
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

	private void ee(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Form)new a(this.m_c)).ShowDialog();
	}

	private void ed(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.North, ((RoomComboItem)this.m_fx.SelectedItem).UniqueID.ToString(), ref this.m_fx);
	}

	private void a(Exit.Directions A_0, string A_1, ref ComboBox A_2)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
		if (roomByID.GetExit(A_0).DestinationRoom == null && A_1 != Room.VoidRoomGuid.ToString())
		{
			MessageBox.Show("Sorry, you must specify a destination room before setting the door/portal object.");
			((ListControl)A_2).SelectedIndex = 0;
		}
		else if (A_1 == string.Empty || A_1 == Room.VoidRoomGuid.ToString())
		{
			roomByID.GetExit(A_0).PortalObjectName = "<None>";
			if (roomByID.GetExit(A_0).DestinationRoom != string.Empty)
			{
				TheGame.GetRoomByID(new Guid(roomByID.GetExit(A_0).DestinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = "<None>";
			}
		}
		else
		{
			TheGame.GetObjectByName(A_1).locationtype = GameObject.LocationType.LT_PORTAL;
			TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(A_0).PortalObjectName = A_1;
			TheGame.GetRoomByID(new Guid(roomByID.GetExit(A_0).DestinationRoom)).GetExit(Exit.GetOppositeDir(A_0)).PortalObjectName = A_1;
		}
	}

	private void ec(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.South, ((RoomComboItem)this.m_fw.SelectedItem).UniqueID.ToString(), ref this.m_fw);
	}

	private void eb(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.West, ((RoomComboItem)this.m_fv.SelectedItem).UniqueID.ToString(), ref this.m_fv);
	}

	private void ea(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.East, ((RoomComboItem)this.m_fu.SelectedItem).UniqueID.ToString(), ref this.m_fu);
	}

	private void d9(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Up, ((RoomComboItem)this.m_ft.SelectedItem).UniqueID.ToString(), ref this.m_ft);
	}

	private void d8(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Down, ((RoomComboItem)this.m_fs.SelectedItem).UniqueID.ToString(), ref this.m_fs);
	}

	private void d7(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.NorthWest, ((RoomComboItem)this.m_fr.SelectedItem).UniqueID.ToString(), ref this.m_fr);
	}

	private void d6(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.NorthEast, ((RoomComboItem)this.m_fq.SelectedItem).UniqueID.ToString(), ref this.m_fq);
	}

	private void d5(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.SouthWest, ((RoomComboItem)this.m_fp.SelectedItem).UniqueID.ToString(), ref this.m_fp);
	}

	private void d4(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.SouthEast, ((RoomComboItem)this.m_fo.SelectedItem).UniqueID.ToString(), ref this.m_fo);
	}

	private void d3(object A_0, EventArgs A_1)
	{
		Process.Start("http://www.ragsgame.com/phpBB2/viewforum.php?f=6&sid=d31bc944bbfc2db5adcb4d2206e9cd81");
	}

	private void d2(object A_0, EventArgs A_1)
	{
		((Control)this.m_gb).Enabled = !this.m_f4.Checked;
		if (this.m_f4.Checked)
		{
			((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).TType = Rags.Timer.TimerType.TT_RUNALWAYS;
			return;
		}
		if (mx.Checked)
		{
			mx.Checked = false;
		}
		((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).TType = Rags.Timer.TimerType.TT_LENGTH;
	}

	private void d1(object A_0, EventArgs A_1)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		int result = -1;
		if (int.TryParse(((Control)this.m_gd).Text, out result))
		{
			if (((BaseCollection)dgvTimers.SelectedRows).Count > 0)
			{
				((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).Length = result;
			}
		}
		else
		{
			MessageBox.Show("You must enter a valid number for the timer length.");
			((Control)this.m_gd).Text = "1";
			((Control)this.m_gd).Focus();
		}
	}

	private void d0(object A_0, EventArgs A_1)
	{
		((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).Restart = this.m_gc.Checked;
	}

	private void dz(object A_0, EventArgs A_1)
	{
		if (dgvTimers.SelectedRows[0] != null)
		{
			((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).Active = this.m_ga.Checked;
		}
	}

	private void dy(object A_0, EventArgs A_1)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		if (!LockData.IsLicensed(bdisplay: false, this.m_c) && TheGame.TimerList.Count >= 5)
		{
			MessageBox.Show("Sorry, you've reached the trial limit for timers.  Please register your copy of RAGS.");
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please enter a name for the timer:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		Rags.Timer timer = new Rags.Timer();
		timer.Name = ((Control)getNameFrm.txtEntry).Text;
		if (TheGame.TimerList.Count > 0 && TheGame.TimerList[0] is Rags.Timer timer2)
		{
			foreach (CustomProperty customProperty in timer2.CustomProperties)
			{
				timer.CustomProperties.Add(new CustomProperty(customProperty.Name, customProperty.Value));
			}
		}
		TheGame.TimerList.Add(timer);
		t();
		dgvTimers.ClearSelection();
		foreach (DataGridViewRow item in (IEnumerable)dgvTimers.Rows)
		{
			DataGridViewRow val = item;
			if (val.Cells[1].Value.ToString() == ((Control)getNameFrm.txtEntry).Text)
			{
				((DataGridViewBand)val).Selected = true;
				dgvTimers.FirstDisplayedScrollingRowIndex = ((DataGridViewBand)val).Index;
				break;
			}
		}
	}

	private void dx(object A_0, EventArgs A_1)
	{
		dy(null, null);
	}

	private void dw(object A_0, EventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		foreach (DataGridViewRow item in (BaseCollection)dgvTimers.SelectedRows)
		{
			DataGridViewRow val = item;
			TheGame.TimerList.Remove((Rags.Timer)((DataGridViewBand)val).Tag);
		}
		t();
	}

	private void dv(object A_0, EventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		if (Form1.m_e)
		{
			Form1.m_e = false;
			if ((int)MessageBox.Show("There is a newer version of the Rags Suite available.  Would you like to update now?", "Update Available", (MessageBoxButtons)4) == 6)
			{
				Process.Start("IEXPLORE.EXE", "http://www.ragsgame.com/Downloads.aspx");
			}
		}
	}

	private void du(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Form)new RegistrationForm(this.m_c)).ShowDialog();
		Form1.m_d = LockData.IsLicensed(bdisplay: false, this.m_c);
	}

	private void dt(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		GetNameFrm getNameFrm = new GetNameFrm("Add A New Status Item");
		if ((int)((Form)getNameFrm).ShowDialog() == 1)
		{
			StatusBarItem statusBarItem = new StatusBarItem();
			statusBarItem.Name = ((Control)getNameFrm.txtEntry).Text;
			TheGame.StatusBarItems.Add(statusBarItem);
			int selectedIndex = this.m_gm.Items.Add((object)((Control)getNameFrm.txtEntry).Text);
			((ListControl)this.m_gm).SelectedIndex = selectedIndex;
		}
	}

	private void ds(object A_0, EventArgs A_1)
	{
		if (this.m_gm.SelectedItems.Count == 1)
		{
			((Control)this.m_gr).Enabled = true;
			((Control)this.m_gs).Enabled = true;
			((Control)ob).Enabled = true;
			((Control)this.m_gp).Enabled = true;
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(this.m_gm.SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				((Control)this.m_gs).Text = statusBarItemByName.Text;
				((Control)this.m_gr).Text = statusBarItemByName.Width.ToString();
				ob.Checked = statusBarItemByName.bVisisble;
			}
		}
		else
		{
			((Control)this.m_gr).Enabled = false;
			((Control)this.m_gs).Enabled = false;
			((Control)this.m_gp).Enabled = false;
			((Control)ob).Enabled = false;
		}
	}

	private void dr(object A_0, EventArgs A_1)
	{
		StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(this.m_gm.SelectedItem.ToString());
		if (statusBarItemByName != null)
		{
			TheGame.StatusBarItems.Remove(statusBarItemByName);
			this.m_gm.Items.Remove(this.m_gm.SelectedItem);
			((Control)this.m_gs).Text = "";
			((Control)this.m_gr).Text = "0";
		}
	}

	private void dq(object A_0, EventArgs A_1)
	{
		if (this.m_gm.SelectedItems.Count == 1)
		{
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(this.m_gm.SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				statusBarItemByName.Text = ((Control)this.m_gs).Text;
				TheGame.ValidateText(((Control)this.m_gs).Text);
			}
		}
	}

	private void dp(object A_0, EventArgs A_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (this.m_gm.SelectedItems.Count == 1)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(((Control)this.m_gr).Text);
			}
			catch
			{
				MessageBox.Show("You must enter a valid number in the status width field.");
				((Control)this.m_gr).Focus();
				return;
			}
			StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(this.m_gm.SelectedItem.ToString());
			if (statusBarItemByName != null)
			{
				statusBarItemByName.Width = num;
			}
		}
	}

	private void @do(object A_0, EventArgs A_1)
	{
		dt(null, null);
	}

	private void dn(object A_0, EventArgs A_1)
	{
		dr(null, null);
	}

	private void dm(object A_0, EventArgs A_1)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Invalid comparison between Unknown and I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Invalid comparison between Unknown and I4
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Invalid comparison between Unknown and I4
		((Control)h1).Enabled = false;
		if (tvVariables.SelectedNode.Tag == null)
		{
			return;
		}
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		if (this.m_cl.Checked)
		{
			gameVariable.vartype = GameVariable.VarType.VT_STRING;
		}
		else if (this.m_cm.Checked)
		{
			gameVariable.vartype = GameVariable.VarType.VT_NUMBER;
		}
		else if (this.m_gy.Checked)
		{
			gameVariable.vartype = GameVariable.VarType.VT_DATETIME;
		}
		else if (hz.Checked)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButtons)4) == 7)
				{
					cs(null, null);
					return;
				}
				gameVariable.VarArray.Clear();
				n();
			}
			((Control)h1).Enabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_NUMBERARRAY;
		}
		else if (hy.Checked)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButtons)4) == 7)
				{
					cs(null, null);
					return;
				}
				gameVariable.VarArray.Clear();
				n();
			}
			((Control)h1).Enabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_STRINGARRAY;
		}
		else if (hx.Checked)
		{
			if (gameVariable.VarArray.Count > 0 && gameVariable.vartype != GameVariable.VarType.VT_DATETIMEARRAY)
			{
				if ((int)MessageBox.Show("Warning, this will clear out your current array.  Do you wish to continue?", "Warning", (MessageBoxButtons)4) == 7)
				{
					cs(null, null);
					return;
				}
				gameVariable.VarArray.Clear();
				n();
			}
			((Control)h1).Enabled = true;
			gameVariable.vartype = GameVariable.VarType.VT_DATETIMEARRAY;
		}
		switch (gameVariable.vartype)
		{
		case GameVariable.VarType.VT_DATETIME:
		case GameVariable.VarType.VT_DATETIMEARRAY:
			((Control)hd).Visible = false;
			((Control)hc).Visible = false;
			((Control)g7).Visible = false;
			((Control)this.m_cq).Visible = false;
			((Control)this.m_gx).Visible = true;
			this.m_gx.CustomFormat = "'" + this.m_gx.Value.ToString("dddd, MMMM, dd yyyy", Game.myDTFI) + "' hh:mm:ss '" + this.m_gx.Value.ToString("tt", Game.myDTFI) + "'";
			break;
		case GameVariable.VarType.VT_NUMBER:
		case GameVariable.VarType.VT_NUMBERARRAY:
			((Control)hd).Visible = true;
			((Control)hc).Visible = true;
			((Control)g7).Visible = true;
			((Control)this.m_cq).Visible = false;
			((Control)this.m_gx).Visible = false;
			break;
		case GameVariable.VarType.VT_STRING:
		case GameVariable.VarType.VT_STRINGARRAY:
			((Control)hd).Visible = false;
			((Control)hc).Visible = false;
			((Control)g7).Visible = false;
			((Control)this.m_cq).Visible = true;
			((Control)this.m_gx).Visible = false;
			break;
		}
	}

	private void dl(object A_0, EventArgs A_1)
	{
		((GameVariable)tvVariables.SelectedNode.Tag).dtDateTime = this.m_gx.Value;
	}

	private void dk(object A_0, EventArgs A_1)
	{
	}

	private void dj(object A_0, EventArgs A_1)
	{
		Settings.Default.CheckForUpdates = this.m_g0.Checked;
	}

	private void di(object A_0, EventArgs A_1)
	{
		this.m_gx.CustomFormat = "'" + this.m_gx.Value.ToString("dddd, MMMM, dd yyyy", Game.myDTFI) + "' hh:mm:ss '" + this.m_gx.Value.ToString("tt", Game.myDTFI) + "'";
	}

	private void dh(object A_0, EventArgs A_1)
	{
		Settings.Default.RunGameCheckOnSave = this.m_g1.Checked;
	}

	private void dg(object A_0, EventArgs A_1)
	{
		a(A_0: true);
	}

	private void a(bool A_0)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Current errors detected in your rags game:\r\n");
		if (TheGame.RoomList.Count == 0)
		{
			stringBuilder.Append("Rooms: You have no rooms in your game.  You should have at least one room.\r\n");
		}
		if (TheGame.ThePlayer.StartingRoom == null)
		{
			stringBuilder.Append("Player: Your player has not been assigned a starting room.\r\n");
		}
		if (!TheGame.ThePlayer.bPromptForName && TheGame.ThePlayer.Name == "")
		{
			stringBuilder.Append("Player: Your player has no name and is not set to prompt for name on startup.\r\n");
		}
		stringBuilder.Append(TheGame.ValidateCommandsAndConditions());
		if (stringBuilder.Length != 44)
		{
			if ((int)MessageBox.Show(stringBuilder.ToString(), "Game Check") == 7)
			{
				MessageBox.Show(stringBuilder.ToString(), "Game Check");
			}
			return;
		}
		stringBuilder.Append("No Serious Errors Detected.");
		if (A_0)
		{
			MessageBox.Show(stringBuilder.ToString(), "Game Check");
		}
	}

	private void df(object A_0, EventArgs A_1)
	{
		Settings.Default.displayNewGameDialogAtStartup = g4.Checked;
	}

	private void de(object A_0, EventArgs A_1)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		NewGameFrm newGameFrm = new NewGameFrm();
		newGameFrm.checkBox1.Checked = g4.Checked;
		if ((int)((Form)newGameFrm).ShowDialog() == 1)
		{
			((FileDialog)this.m_f).FileName = string.Empty;
			this.m_n = string.Empty;
			((Control)this).Text = "Rags Designer - " + this.m_n;
			TheGame = new Game();
			Game.DBName = string.Empty;
			if (newGameFrm.radioButton2.Checked)
			{
				q();
			}
			else if (newGameFrm.radioButton3.Checked)
			{
				p();
			}
			am();
		}
		g4.Checked = newGameFrm.checkBox1.Checked;
		df(null, null);
	}

	private void q()
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

	private void p()
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

	private void dd(object A_0, EventArgs A_1)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		if (g4.Checked)
		{
			NewGameFrm newGameFrm = new NewGameFrm();
			newGameFrm.checkBox1.Checked = g4.Checked;
			if ((int)((Form)newGameFrm).ShowDialog() == 1)
			{
				if (newGameFrm.radioButton2.Checked)
				{
					q();
				}
				else if (newGameFrm.radioButton3.Checked)
				{
					p();
				}
			}
			g4.Checked = newGameFrm.checkBox1.Checked;
			df(null, null);
		}
		am();
	}

	private void dc(object A_0, EventArgs A_1)
	{
	}

	private void l(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
			ey(null, null);
		}
	}

	private void k(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "lbItems")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void db(object A_0, EventArgs A_1)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		g1(null, null);
		DateTime now = DateTime.Now;
		while (!Game.bDoneWithWaitDlg && !((DateTime.Now - now).TotalSeconds > 5.0))
		{
			Thread.Sleep(30);
		}
		try
		{
			Game.TheCon.Close();
			Process.Start(Path.Combine(Application.StartupPath, "Rags.exe"), "\"" + this.m_n + "\" DEBUG");
		}
		catch
		{
			MessageBox.Show("Unable to start the Rags Game in debug mode.  You can try reinstalling the Rags Suite to correct this issue.");
		}
	}

	private void da(object A_0, EventArgs A_1)
	{
		((Control)this.m_dj).Enabled = g6.Checked;
		((Control)this.m_ei).Enabled = g6.Checked;
		((Control)this.m_ej).Enabled = g6.Checked;
	}

	private void c9(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bContainer = g6.Checked;
		}
	}

	private void f(object A_0, CancelEventArgs A_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Convert.ToDouble(TheGame.PerformTextReplacements(((Control)ha).Text, null));
		}
		catch
		{
			MessageBox.Show("You must enter a valid numeric value here.");
			((Control)ha).Focus();
			A_1.Cancel = true;
		}
	}

	private void e(object A_0, CancelEventArgs A_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Convert.ToDouble(TheGame.PerformTextReplacements(((Control)g8).Text, null));
		}
		catch
		{
			MessageBox.Show("You must enter a valid numeric value here.");
			((Control)g8).Focus();
			A_1.Cancel = true;
		}
	}

	private void c8(object A_0, EventArgs A_1)
	{
	}

	private void c7(object A_0, EventArgs A_1)
	{
	}

	private void d(object A_0, CancelEventArgs A_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Convert.ToDouble(TheGame.PerformTextReplacements(((Control)hc).Text, null));
		}
		catch
		{
			MessageBox.Show("You must enter a valid numeric value here.");
			((Control)hc).Focus();
			A_1.Cancel = true;
		}
	}

	private void c6(object A_0, EventArgs A_1)
	{
	}

	private void c5(object A_0, EventArgs A_1)
	{
		((GameVariable)tvVariables.SelectedNode.Tag).dNumType = Convert.ToDouble(((Control)hc).Text);
	}

	private void c4(object A_0, EventArgs A_1)
	{
		((GameVariable)tvVariables.SelectedNode.Tag).dMax = ((Control)g8).Text;
	}

	private void c3(object A_0, EventArgs A_1)
	{
		((GameVariable)tvVariables.SelectedNode.Tag).dMin = ((Control)ha).Text;
	}

	private void c2(object A_0, EventArgs A_1)
	{
	}

	private void c1(object A_0, EventArgs A_1)
	{
		ad();
	}

	private void c0(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			if (hi.Checked)
			{
				((GameObject)tvItems.SelectedNode.Tag).bVisible = true;
			}
			else
			{
				((GameObject)tvItems.SelectedNode.Tag).bVisible = false;
			}
		}
	}

	private void o()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		jy.Items.Clear();
		((ToolStripDropDownItem)j0).DropDownItems.Clear();
		foreach (string roomGroup in TheGame.RoomGroups)
		{
			jy.Items.Add((object)roomGroup);
			((ToolStripDropDownItem)j0).DropDownItems.Add(roomGroup);
		}
		jy.Items.Insert(0, (object)"None");
		((ToolStripDropDownItem)j0).DropDownItems.Insert(0, (ToolStripItem)new ToolStripMenuItem("None"));
		jy.Items.Add((object)"<Add New Group>");
		((ToolStripDropDownItem)j0).DropDownItems.Add("<Add New Group>");
	}

	private void cz(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)dgvRoomList.SelectedRows).Count == 1 && ((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag != null)
		{
			((Control)tabControl2).Enabled = true;
			RoomActions.SetObjectName(((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag.ToString());
			((Control)RoomActions).Enabled = true;
			((Control)txtRoomDescription).Enabled = true;
			((Control)txtRoomSDesc).Enabled = true;
			((Control)this.m_eq).Enabled = true;
			((Control)this.m_bb).Enabled = true;
			((Control)this.m_fe).Enabled = true;
			((Control)this.m_bz).Enabled = true;
			((Control)this.m_bb).Enabled = true;
			Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			if (roomByID == null)
			{
				return;
			}
			((Control)this.m_fd).Text = roomByID.Name;
			((Control)tbRoomID).Text = roomByID.UniqueID.ToString();
			((Control)this.m_fg).Text = roomByID.Name;
			((Control)this.m_ff).Text = roomByID.Name;
			((Control)txtRoomName).Text = roomByID.Name;
			((Control)txtRoomDescription).Text = roomByID.Description;
			((Control)txtRoomSDesc).Text = roomByID.SDesc;
			jy.SelectedItem = roomByID.Group;
			if (string.Compare(roomByID.RoomPic, "None", ignoreCase: true) != 0)
			{
				((Control)this.m_eo).Tag = TheGame.GetGamePictureByName(roomByID.RoomPic);
				PictureBox val = this.m_eo;
				object pictureByName = TheGame.GetPictureByName(roomByID.RoomPic);
				((Control)val).BackgroundImage = (Image)((pictureByName is Image) ? pictureByName : null);
				this.m_eq.SelectedItem = roomByID.RoomPic;
			}
			else
			{
				if (this.m_eq.Items.Count > 0)
				{
					this.m_eq.SelectedItem = "None";
				}
				((Control)this.m_eo).Tag = null;
				((Control)this.m_eo).BackgroundImage = null;
			}
			string.Compare(roomByID.LayeredRoomPic, "None", ignoreCase: true);
			a(roomByID);
			RoomActions.RefreshActions();
			g();
			z();
			bc(null, null);
		}
		else
		{
			((Control)tabControl2).Enabled = false;
		}
	}

	private void cy(object A_0, EventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		GameObject gameObject = (GameObject)tvItems.SelectedNode.Tag;
		if (gameObject == null)
		{
			return;
		}
		GetNameFrm getNameFrm = new GetNameFrm("Please enter object name:");
		if ((int)((Form)getNameFrm).ShowDialog() == 1)
		{
			_ = gameObject.name;
			_ = ((Control)getNameFrm.txtEntry).Text;
			gameObject.name = ((Control)getNameFrm.txtEntry).Text;
			ab();
			TreeNode[] array = tvItems.Nodes.Find(gameObject.name, true);
			if (array.Length != 0)
			{
				tvItems.SelectedNode = array[0];
				array[0].Expand();
			}
		}
	}

	private void cx(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		GetNameFrm getNameFrm = new GetNameFrm("Please Enter Room Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
		roomByID.Name = ((Control)getNameFrm.txtEntry).Text;
		ah();
		dgvRoomList.ClearSelection();
		foreach (DataGridViewRow item in (IEnumerable)dgvRoomList.Rows)
		{
			DataGridViewRow val = item;
			if ((Guid)((DataGridViewBand)val).Tag == roomByID.UniqueID)
			{
				((DataGridViewBand)val).Selected = true;
				dgvRoomList.FirstDisplayedScrollingRowIndex = ((DataGridViewBand)val).Index;
				break;
			}
		}
		a(roomByID);
	}

	private void d(object A_0, DataGridViewSortCompareEventArgs A_1)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		if ((int)dgvRoomList.Columns[0].HeaderCell.SortGlyphDirection == 2)
		{
			Guid guid = (Guid)((DataGridViewBand)dgvRoomList.Rows[A_1.RowIndex1]).Tag;
			Guid guid2 = (Guid)((DataGridViewBand)dgvRoomList.Rows[A_1.RowIndex2]).Tag;
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < TheGame.RoomList.Count; i++)
			{
				Room room = (Room)TheGame.RoomList[i];
				if (room.UniqueID == guid)
				{
					num = i;
				}
				if (room.UniqueID == guid2)
				{
					num2 = i;
				}
				if (num != -1 && num2 != -1)
				{
					break;
				}
			}
			A_1.SortResult = num2.CompareTo(num);
			((HandledEventArgs)(object)A_1).Handled = true;
		}
		else
		{
			A_1.SortResult = string.Compare(A_1.CellValue1.ToString(), A_1.CellValue2.ToString());
			((HandledEventArgs)(object)A_1).Handled = true;
		}
	}

	private void cw(object A_0, EventArgs A_1)
	{
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		if (TheGame == null || (TheGame != null && TheGame.TimerList.Count == 0))
		{
			return;
		}
		if (hp.Value > (decimal)TheGame.TimerList.Count)
		{
			hp.Value = TheGame.TimerList.Count;
			return;
		}
		int index = Convert.ToInt32(hp.Value) - 1;
		string text = dgvTimers.SelectedRows[0].Cells[1].Value.ToString();
		if (TheGame.TimerList[index] == ((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag)
		{
			return;
		}
		Rags.Timer timer = (Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag;
		TheGame.TimerList.Remove(timer);
		TheGame.TimerList.Insert(Convert.ToInt32(hp.Value) - 1, timer);
		t();
		dgvTimers.ClearSelection();
		foreach (DataGridViewRow item in (IEnumerable)dgvTimers.Rows)
		{
			DataGridViewRow val = item;
			if (val.Cells[1].Value.ToString() == text)
			{
				((DataGridViewBand)val).Selected = true;
				break;
			}
		}
	}

	private void cv(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)dgvTimers.SelectedRows).Count == 1)
		{
			Rags.Timer timer = (Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag;
			((Control)TimerActions).Enabled = true;
			if (timer == null)
			{
				return;
			}
			try
			{
				mx.CheckedChanged -= aj;
				hp.Value = Convert.ToInt32(dgvTimers.SelectedRows[0].Cells[0].Value.ToString());
				((Control)this.m_f5).Text = timer.Name;
				((Control)this.m_f6).Text = timer.Name;
				TimerActions.SetObjectName(timer.Name);
				mx.Checked = timer.LiveTimer;
				if (timer.TType == Rags.Timer.TimerType.TT_RUNALWAYS)
				{
					this.m_f4.Checked = true;
				}
				else
				{
					this.m_f3.Checked = true;
				}
				((Control)this.m_gd).Text = timer.Length.ToString();
				this.m_gc.Checked = timer.Restart;
				this.m_ga.Checked = timer.Active;
				mw.Value = timer.TimerSeconds;
				((Control)this.m_f2).Enabled = true;
				((Control)this.m_gb).Enabled = true;
				((Control)this.m_ga).Enabled = true;
				((Control)TimerActions).Enabled = true;
				((Control)hq).Enabled = true;
				((Control)this.m_gb).Enabled = !this.m_f4.Checked;
				((Control)mu).Enabled = true;
				TimerActions.RefreshActions();
				c();
				return;
			}
			finally
			{
				mx.CheckedChanged += aj;
			}
		}
		((Control)this.m_f2).Enabled = false;
		((Control)this.m_gb).Enabled = false;
		((Control)this.m_ga).Enabled = false;
		((Control)TimerActions).Enabled = false;
		((Control)hq).Enabled = false;
		((Control)mu).Enabled = false;
	}

	private void c(object A_0, DataGridViewSortCompareEventArgs A_1)
	{
		if (((DataGridViewBand)A_1.Column).Index == 0)
		{
			A_1.SortResult = Convert.ToInt32(A_1.CellValue1).CompareTo(Convert.ToInt32(A_1.CellValue2));
			((HandledEventArgs)(object)A_1).Handled = true;
		}
	}

	private void cu(object A_0, EventArgs A_1)
	{
		((Control)ha).Enabled = hr.Checked;
		((Control)g8).Enabled = hr.Checked;
		((GameVariable)tvVariables.SelectedNode.Tag).bEnforceRestrictions = hr.Checked;
	}

	private void k(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 2097152 && ((Control)dgvCharacters).Enabled)
		{
			ContextMenuStrip val = new ContextMenuStrip();
			ToolStripMenuItem val2 = new ToolStripMenuItem("Add Character");
			((ToolStripItem)val2).Click += e2;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val2);
			val2 = new ToolStripMenuItem("Remove Selected Characters");
			((ToolStripItem)val2).Click += e2;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val2);
			((ToolStripDropDown)val).Show((Control)(object)dgvCharacters, A_1.X, A_1.Y);
		}
	}

	private void ct(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)dgvCharacters.SelectedRows).Count == 1)
		{
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			((Control)this.m_c1).Text = character.Charname;
			((Control)this.m_fj).Text = character.Charname;
			CharacterActions.SetObjectName(character.Charname);
			h7.Checked = character.bAllowInventoryInteraction;
			if (character == null)
			{
				return;
			}
			foreach (RoomComboItem item in this.m_dd.Items)
			{
				if (item.UniqueID.ToString() == character.CurrentRoom)
				{
					this.m_dd.SelectedItem = item;
					break;
				}
			}
			((Control)op).Enabled = true;
			if (character.CharPortrait != string.Empty)
			{
				op.SelectedItem = character.CharPortrait;
			}
			else
			{
				op.SelectedItem = "None";
			}
			((Control)this.m_df).Text = character.Description;
			((Control)tbCharacterNameOverride).Text = character.CharnameOverride;
			if (character != null)
			{
				switch (character.CharGender)
				{
				case Player.Gender.Female:
					this.m_cz.Checked = true;
					break;
				case Player.Gender.Male:
					this.m_c0.Checked = true;
					break;
				case Player.Gender.Other:
					this.m_cy.Checked = true;
					break;
				}
				s();
				((Control)CharacterActions).Enabled = true;
				((Control)this.m_cx).Enabled = true;
				((Control)this.m_c8).Enabled = true;
				((Control)this.m_c9).Enabled = true;
				((Control)CharacterActions.tvActionsConditions).Enabled = true;
				((Control)this.m_df).Enabled = true;
				((Control)this.m_dd).Enabled = true;
				((Control)h7).Enabled = true;
				CharacterActions.RefreshActions();
				e();
			}
		}
		else
		{
			((Control)this.m_cx).Enabled = false;
			((Control)op).Enabled = false;
			((Control)this.m_c8).Enabled = false;
			((Control)this.m_c9).Enabled = false;
			((Control)CharacterActions).Enabled = false;
			((Control)this.m_dd).Enabled = false;
			((Control)this.m_df).Enabled = false;
			((Control)h7).Enabled = false;
		}
	}

	private void b(object A_0, DataGridViewSortCompareEventArgs A_1)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		if ((int)dgvCharacters.Columns[0].HeaderCell.SortGlyphDirection == 2)
		{
			string text = A_1.CellValue1.ToString();
			string text2 = A_1.CellValue2.ToString();
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < TheGame.CharacterList.Count; i++)
			{
				Character character = (Character)TheGame.CharacterList[i];
				if (character.Charname == text)
				{
					num = i;
				}
				if (character.Charname == text2)
				{
					num2 = i;
				}
				if (num != -1 && num2 != -1)
				{
					break;
				}
			}
			A_1.SortResult = num2.CompareTo(num);
			((HandledEventArgs)(object)A_1).Handled = true;
		}
		else
		{
			A_1.SortResult = string.Compare(A_1.CellValue1.ToString(), A_1.CellValue2.ToString());
			((HandledEventArgs)(object)A_1).Handled = true;
		}
	}

	private void cs(object A_0, EventArgs A_1)
	{
		h3.Items.Clear();
		if (tvVariables.SelectedNode.Tag != null)
		{
			iz.CheckedChanged -= b6;
			iz.Checked = false;
			iz.CheckedChanged += b6;
			((Control)this.m_cp).Enabled = true;
			((Control)this.m_ck).Enabled = true;
			GameVariable gameVariable = (GameVariable)tvVariables.SelectedNode.Tag;
			((Control)i7).Text = gameVariable.VarComment;
			((Control)this.m_co).Text = gameVariable.varname;
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_STRING:
				this.m_cl.Checked = true;
				((Control)this.m_cq).Text = gameVariable.sString;
				((Control)this.m_cq).Visible = true;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				hy.Checked = true;
				((Control)this.m_cq).Text = gameVariable.sString;
				((Control)this.m_cq).Visible = true;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				n();
				break;
			case GameVariable.VarType.VT_NUMBER:
				this.m_cm.Checked = true;
				((Control)hc).Text = gameVariable.dNumType.ToString();
				hr.Checked = gameVariable.bEnforceRestrictions;
				cu(null, null);
				((Control)ha).Text = gameVariable.dMin.ToString();
				((Control)g8).Text = gameVariable.dMax.ToString();
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = true;
				((Control)hc).Visible = true;
				((Control)g7).Visible = true;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				hz.Checked = true;
				((Control)hc).Text = gameVariable.dNumType.ToString();
				hr.Checked = gameVariable.bEnforceRestrictions;
				cu(null, null);
				((Control)ha).Text = gameVariable.dMin.ToString();
				((Control)g8).Text = gameVariable.dMax.ToString();
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = true;
				((Control)hc).Visible = true;
				((Control)g7).Visible = true;
				n();
				break;
			case GameVariable.VarType.VT_DATETIME:
				this.m_gy.Checked = true;
				this.m_gx.Value = gameVariable.dtDateTime;
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = true;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_DATETIMEARRAY:
				hx.Checked = true;
				this.m_gx.Value = gameVariable.dtDateTime;
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = true;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				n();
				break;
			}
			d();
		}
		else
		{
			((Control)this.m_co).Text = "";
			((Control)this.m_cq).Text = "";
			((Control)this.m_cp).Enabled = false;
			((Control)this.m_ck).Enabled = false;
		}
	}

	private void a(object A_0, DataGridViewSortCompareEventArgs A_1)
	{
	}

	private void cr(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)hw).ShowDialog() == 1)
		{
			TheGame.GameFont = hw.Font;
			((Control)hu).Text = TheGame.GameFont.Name.ToString() + " " + TheGame.GameFont.Size;
		}
	}

	private void n()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected Obj, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected Obj, but got Unknown
		int num = ((ListControl)h3).SelectedIndex;
		h3.Items.Clear();
		if (!(tvVariables.SelectedNode.Tag is GameVariable gameVariable))
		{
			return;
		}
		ArrayList arrayList = null;
		if (gameVariable.VarArray.Count > 0)
		{
			arrayList = gameVariable.VarArray[0] as ArrayList;
		}
		if (gameVariable.VarArray.Count > 0 && arrayList != null)
		{
			((Control)iy).Visible = true;
			((Control)h3).Visible = false;
			iz.CheckedChanged -= b6;
			iz.Checked = true;
			iz.CheckedChanged += b6;
			iy.RowsRemoved -= b;
			iy.Columns.Clear();
			iy.Rows.Clear();
			iy.ColumnCount = arrayList.Count;
			for (int i = 0; i < arrayList.Count; i++)
			{
				iy.Columns[i].HeaderText = i.ToString();
				iy.Columns[i].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
				iy.Columns[i].FillWeight = 100 / iy.ColumnCount;
				iy.Columns[i].SortMode = (DataGridViewColumnSortMode)0;
			}
			iy.RowCount = gameVariable.VarArray.Count + 1;
			int num2 = -1;
			for (int j = 0; j < gameVariable.VarArray.Count; j++)
			{
				ArrayList arrayList2 = null;
				((DataGridViewCell)iy.Rows[j].HeaderCell).Value = j.ToString("000");
				arrayList2 = gameVariable.VarArray[j] as ArrayList;
				if (arrayList2 == null)
				{
					gameVariable.VarArray[j] = new ArrayList();
					arrayList2 = gameVariable.VarArray[j] as ArrayList;
					for (int k = 0; k < ((BaseCollection)iy.Columns).Count; k++)
					{
						arrayList2.Add("");
					}
				}
				num2++;
				for (int l = 0; l < arrayList2.Count; l++)
				{
					object obj = arrayList2[l];
					iy[l, j].Value = obj.ToString();
				}
			}
			iy.RowsRemoved += b;
		}
		else
		{
			iz.CheckedChanged -= b6;
			iz.Checked = false;
			iz.CheckedChanged += b6;
			((Control)iy).Visible = false;
			((Control)h3).Visible = true;
			GameVariable.VarType vartype = gameVariable.vartype;
			if (vartype == GameVariable.VarType.VT_DATETIMEARRAY)
			{
				foreach (DateTime item in gameVariable.VarArray)
				{
					h3.Items.Add((object)(h3.Items.Count.ToString("000") + " : " + item.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI)));
				}
			}
			else
			{
				foreach (object item2 in gameVariable.VarArray)
				{
					h3.Items.Add((object)(h3.Items.Count.ToString("000") + " : " + item2.ToString()));
				}
			}
		}
		if (num != -1)
		{
			if (num > h3.Items.Count - 1)
			{
				num = h3.Items.Count - 1;
			}
			((ListControl)h3).SelectedIndex = num;
		}
	}

	private void cq(object A_0, EventArgs A_1)
	{
		if (tvVariables.SelectedNode.Tag is GameVariable gameVariable)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIMEARRAY:
				gameVariable.VarArray.Add(this.m_gx.Value);
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				gameVariable.VarArray.Add(Convert.ToDouble(((Control)hc).Text));
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				gameVariable.VarArray.Add(((Control)this.m_cq).Text);
				break;
			}
			n();
			((ListControl)h3).SelectedIndex = h3.Items.Count - 1;
		}
	}

	private void cp(object A_0, EventArgs A_1)
	{
		if (((ListControl)h3).SelectedIndex != -1 && tvVariables.SelectedNode.Tag is GameVariable gameVariable)
		{
			gameVariable.VarArray.RemoveAt(((ListControl)h3).SelectedIndex);
			n();
		}
	}

	private void co(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null && tvItems.SelectedNode.Tag is GameObject gameObject)
		{
			gameObject.preposition = ((Control)h5).Text;
			TheGame.ValidateText(((Control)h5).Text);
		}
	}

	private void e(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = val2.SelectionStart;
		}
		if (val != null)
		{
			startIndex = ((TextBoxBase)val).SelectionStart;
		}
		string text = insertVariableToolStripMenuItem();
		if (text != string.Empty)
		{
			if (val != null)
			{
				((Control)val).Text = ((Control)val).Text.Insert(startIndex, text);
			}
			else if (val2 != null)
			{
				((Control)val2).Text = ((Control)val2).Text.Insert(startIndex, text);
			}
		}
	}

	public string insertVariableToolStripMenuItem()
	{
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref TheGame);
		TextHandlers.PopulateVariableMenu(ref tempfrm, ref TheGame);
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[playername]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[inputdata]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[maxcarry]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[currentcarry]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[turns]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[man/woman]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[male/female]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[boy/girl]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[len(<variablename>)]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[a/an]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[char.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[item.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[item.id]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[room.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[room.id]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.active]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.direction]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.destname]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.destid]");
		if ((int)((Form)tempfrm).ShowDialog() == 1)
		{
			switch (tempfrm.tabControl1.SelectedIndex)
			{
			case 0:
				if (tempfrm.lbSysVariables.SelectedItem != null)
				{
					result = tempfrm.lbSysVariables.SelectedItem.ToString();
				}
				break;
			case 1:
				if (tempfrm.lbVariables.SelectedItem != null)
				{
					result = tempfrm.lbVariables.SelectedItem.ToString();
				}
				break;
			case 2:
				if (tempfrm.lbCustProp.SelectedItem != null)
				{
					result = tempfrm.lbCustProp.SelectedItem.ToString();
				}
				break;
			case 3:
				result = ((Control)tempfrm.tbText).Text;
				break;
			}
		}
		return result;
	}

	private void d(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		RichTextBox val = (RichTextBox)((A_0 is RichTextBox) ? A_0 : null);
		if (val != null)
		{
			int selectionStart = ((TextBoxBase)val).SelectionStart;
			string text = insertVariableToolStripMenuItem();
			if (text != string.Empty)
			{
				((Control)val).Text = ((Control)val).Text.Insert(selectionStart, text);
			}
		}
	}

	private void cn(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)dgvCharacters.SelectedRows).Count > 0)
		{
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			if (character != null)
			{
				character.bAllowInventoryInteraction = h7.Checked;
			}
		}
	}

	private void j(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			if (((ListControl)h3).SelectedIndex != -1)
			{
				cm(null, null);
			}
			this.m_i = true;
		}
	}

	private void cm(object A_0, EventArgs A_1)
	{
		((Control)h8).Enabled = false;
		if (h3.SelectedItem != null)
		{
			((Control)h8).Enabled = true;
			GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				this.m_gx.Value = (DateTime)gameVariable.VarArray[((ListControl)h3).SelectedIndex];
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
			{
				string text2 = h3.SelectedItem.ToString();
				((Control)hc).Text = text2.Substring(text2.IndexOf(":") + 1).Trim();
				break;
			}
			case GameVariable.VarType.VT_STRING:
			case GameVariable.VarType.VT_STRINGARRAY:
			{
				string text = h3.SelectedItem.ToString();
				((Control)this.m_cq).Text = text.Substring(text.IndexOf(":") + 1).Trim();
				break;
			}
			}
		}
	}

	private void i(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_i && h3.SelectedItems.Count > 0)
		{
			((Control)this).DoDragDrop((object)"lbVarArray", (DragDropEffects)(-2147483645));
		}
	}

	private void h(object A_0, MouseEventArgs A_1)
	{
		this.m_i = false;
	}

	private void j(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "lbVarArray")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void i(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		int num = h3.IndexFromPoint(((Control)h3).PointToClient(new Point(A_1.X, A_1.Y)));
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		int selectedIndex = ((ListControl)h3).SelectedIndex;
		object obj = gameVariable.VarArray[selectedIndex];
		if (num > -1)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIMEARRAY:
			{
				DateTime dateTime = (DateTime)obj;
				gameVariable.VarArray.RemoveAt(selectedIndex);
				gameVariable.VarArray.Insert(num, dateTime);
				break;
			}
			case GameVariable.VarType.VT_NUMBERARRAY:
			{
				double num2 = (double)obj;
				gameVariable.VarArray.RemoveAt(selectedIndex);
				gameVariable.VarArray.Insert(num, num2);
				break;
			}
			case GameVariable.VarType.VT_STRINGARRAY:
			{
				string value = obj.ToString();
				gameVariable.VarArray.RemoveAt(selectedIndex);
				gameVariable.VarArray.Insert(num, value);
				break;
			}
			}
			cs(null, null);
		}
	}

	private void cl(object A_0, EventArgs A_1)
	{
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		int selectedIndex = ((ListControl)h3).SelectedIndex;
		if (selectedIndex > -1 && gameVariable != null)
		{
			gameVariable.VarArray.RemoveAt(selectedIndex);
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIMEARRAY:
				gameVariable.VarArray.Insert(selectedIndex, this.m_gx.Value);
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				gameVariable.VarArray.Insert(selectedIndex, Convert.ToDouble(((Control)hc).Text));
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				gameVariable.VarArray.Insert(selectedIndex, ((Control)this.m_cq).Text);
				break;
			}
			n();
		}
	}

	private void ck(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Out, ((RoomComboItem)ig.SelectedItem).UniqueID);
	}

	private void cj(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.Out, ((RoomComboItem)@if.SelectedItem).UniqueID.ToString(), ref @if);
	}

	private void ci(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.In).bActive = ia.Checked;
	}

	private void ch(object A_0, EventArgs A_1)
	{
		TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag).GetExit(Exit.Directions.Out).bActive = id.Checked;
	}

	private void cg(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.In, ((RoomComboItem)ib.SelectedItem).UniqueID);
	}

	private void cf(object A_0, EventArgs A_1)
	{
		a(Exit.Directions.In, ((RoomComboItem)ic.SelectedItem).UniqueID.ToString(), ref ic);
	}

	private void ce(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		MapFrm mapFrm = new MapFrm(ref TheGame);
		((Form)mapFrm).ShowDialog();
		((Component)(object)mapFrm).Dispose();
	}

	private void cd(object A_0, EventArgs A_1)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		Settings.Default.Splitcontainer2 = 0;
		Settings.Default.Splitter2Height = 0;
		Settings.Default.Splitter3Height = 0;
		Settings.Default.Splitcontainer4 = 0;
		Settings.Default.Splitcontainer5 = 0;
		Settings.Default.Splitcontainer6 = 0;
		Settings.Default.Splitcontainer7 = 0;
		this.m_l = true;
		MessageBox.Show("Window positions have been reset.  You will need to restart Rags for the changes to take effect.");
	}

	private void m()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
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
		xmlNodeList = xmlDocument.SelectNodes("Configuration/DesignerDisplaySettings");
		xmlElement = xmlDocument.CreateElement("DesignerDisplaySettings");
		if ((int)((Form)this).WindowState == 0)
		{
			XmlElement xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerLocation");
			xmlElement2.SetAttribute("Value", ((Form)this).Location.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSize");
			xmlElement2.SetAttribute("Value", ((Form)this).Size.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitcontainer2");
			xmlElement2.SetAttribute("Value", this.m_er.SplitterDistance.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitter2Height");
			xmlElement2.SetAttribute("Value", this.m_bv.SplitPosition.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitter3Height");
			xmlElement2.SetAttribute("Value", m1.SplitPosition.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitcontainer4");
			xmlElement2.SetAttribute("Value", ij.SplitterDistance.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitcontainer5");
			xmlElement2.SetAttribute("Value", il.SplitterDistance.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitcontainer6");
			xmlElement2.SetAttribute("Value", @in.SplitterDistance.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "DesignerSplitcontainer7");
			xmlElement2.SetAttribute("Value", io.SplitterDistance.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Setting");
			xmlElement2.SetAttribute("Name", "NewGameMenuStartup");
			xmlElement2.SetAttribute("Value", g4.Checked.ToString());
			xmlElement.AppendChild(xmlElement2);
		}
		XmlElement xmlElement3 = xmlDocument.CreateElement("Setting");
		xmlElement3.SetAttribute("Name", "DesignerWindowState");
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

	private void l()
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Invalid comparison between Unknown and I4
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
		xmlNodeList = xmlDocument.SelectNodes("Configuration/DesignerAutoSaveSettings");
		xmlDocument.CreateElement("DesignerAutoSaveSettings");
		if (xmlNodeList.Count > 0)
		{
			foreach (XmlNode childNode in xmlNodeList[0].ChildNodes)
			{
				string text3 = childNode.Attributes["Name"].Value.ToString();
				if (text3 == "UseAutoSave")
				{
					string value = childNode.Attributes["Value"].Value;
					try
					{
						bUseAutoSave = Convert.ToBoolean(value);
					}
					catch
					{
						bUseAutoSave = false;
					}
				}
				else if (text3 == "Minutes")
				{
					string value2 = childNode.Attributes["Value"].Value;
					try
					{
						iAutoSaveMinutes = Convert.ToInt32(value2);
					}
					catch
					{
						iAutoSaveMinutes = 5;
					}
				}
			}
		}
		else
		{
			MessageBox.Show("It appears your auto save settings have not been configured.  You will now be prompted to configure them.");
			if ((int)((Form)new AutoSaveSettingsFrm()).ShowDialog() == 1)
			{
				a();
			}
		}
		if (bUseAutoSave)
		{
			a();
		}
	}

	private void k()
	{
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
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
		xmlNodeList = xmlDocument.SelectNodes("Configuration/DesignerDisplaySettings");
		xmlDocument.CreateElement("DesignerDisplaySettings");
		if (xmlNodeList.Count <= 0)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNodeList[0].ChildNodes)
		{
			switch (childNode.Attributes["Name"].Value.ToString())
			{
			case "DesignerLocation":
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
			case "DesignerSize":
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
			case "NewGameMenuStartup":
			{
				string value = childNode.Attributes["Value"].Value;
				g4.Checked = Convert.ToBoolean(value);
				break;
			}
			case "DesignerWindowState":
				((Form)this).WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), childNode.Attributes["Value"].Value.ToString());
				break;
			}
		}
	}

	private void cc(object A_0, EventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		if (!an())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  It can not be exported.");
			return;
		}
		ExportXMLSelectionFrm exportXMLSelectionFrm = new ExportXMLSelectionFrm();
		if ((int)((Form)exportXMLSelectionFrm).ShowDialog() == 1 && (int)((CommonDialog)it).ShowDialog() == 1)
		{
			StreamWriter CurDoc = new StreamWriter(((FileDialog)it).FileName);
			TheGame.GetXMLData(ref CurDoc, exportXMLSelectionFrm.cbRooms.Checked, exportXMLSelectionFrm.cbCharacters.Checked, exportXMLSelectionFrm.cbObjects.Checked, exportXMLSelectionFrm.cbVariables.Checked, exportXMLSelectionFrm.cbTimers.Checked, exportXMLSelectionFrm.cbStatusBarItems.Checked, exportXMLSelectionFrm.cbPlayer.Checked, exportXMLSelectionFrm.cbImages.Checked);
			CurDoc.Close();
		}
	}

	private void cb(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((CommonDialog)iu).ShowDialog() != 1)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(File.ReadAllText(((FileDialog)iu).FileName));
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("RAGSGAME");
		if (xmlNodeList.Count > 0)
		{
			XmlNode CurNode = xmlNodeList[0];
			TheGame.SetXMLData(ref CurNode);
			if (!an())
			{
				MessageBox.Show("This game will be in read only mode due to trial limitations.");
			}
		}
		am();
	}

	private void ca(object A_0, EventArgs A_1)
	{
	}

	private void b9(object A_0, EventArgs A_1)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Invalid comparison between Unknown and I4
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		if (i3 == null)
		{
			return;
		}
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		MemoryStream memoryStream = new MemoryStream();
		binaryFormatter.Serialize(memoryStream, i3);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		GameObject gameObject = (GameObject)binaryFormatter.Deserialize(memoryStream);
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
			if ((int)MessageBox.Show("There is already an object named " + i3.name + ".  Would you like to rename this object?", "Duplicate Name", (MessageBoxButtons)4) != 6)
			{
				return;
			}
			GetNameFrm getNameFrm = new GetNameFrm("Please Enter Object Name:");
			if ((int)((Form)getNameFrm).ShowDialog() != 1)
			{
				return;
			}
			flag = false;
			gameObject.name = ((Control)getNameFrm.txtEntry).Text;
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
				ab();
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
				Rags.Action tempact = (Rags.Action)gameObject.Actions[i];
				TheGame.RefactorAction(ref tempact, i3.UniqueIdentifier.ToString(), gameObject.UniqueIdentifier.ToString());
			}
			ab();
		}
	}

	private void b8(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null && tvItems.SelectedNode.Tag is GameObject graph)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, graph);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			i3 = (GameObject)binaryFormatter.Deserialize(memoryStream);
		}
	}

	private void c(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData == 131158)
		{
			b9(null, null);
		}
		else if ((int)A_1.KeyData == 131139)
		{
			b8(null, null);
		}
	}

	private void b7(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		MessageBox.Show("There are a variety of shortcut keys to speed up your development of RAGS games.\r\nAlt-V: Insert a variable\r\nCtrl-C: Copy an Object, Action, Condition, or Command\r\nCtrl-V: Paste an Object, Action, Condition, or Command\r\nCtrl-X: Cut an Action, Condition, or Command\r\nCtrl-Shift-[0-9]: Copy an Action, Condition, or Command into a Macro slot\r\nCtrl-[0-9]: Paste an Action, Condition, or Command from a Macro slot\r\n");
	}

	private void b6(object A_0, EventArgs A_1)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Obj, but got Unknown
		if (iz.Checked)
		{
			GetDimensionWidthFrm getDimensionWidthFrm = new GetDimensionWidthFrm();
			GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
			if (gameVariable.VarArray.Count > 0 && gameVariable.VarArray[0] is ArrayList)
			{
				return;
			}
			if ((int)((Form)getDimensionWidthFrm).ShowDialog() == 1)
			{
				iy.RowsRemoved -= b;
				iy.Columns.Clear();
				iy.Rows.Clear();
				gameVariable.VarArray.Clear();
				((Control)iy).Visible = true;
				((Control)h3).Visible = false;
				iy.ColumnCount = Convert.ToInt32(getDimensionWidthFrm.udWidth.Value);
				for (int i = 0; i < iy.ColumnCount; i++)
				{
					iy.Columns[i].HeaderText = i.ToString();
					iy.Columns[i].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
					iy.Columns[i].FillWeight = 100 / iy.ColumnCount;
					iy.Columns[i].SortMode = (DataGridViewColumnSortMode)0;
				}
				iy.Rows.Add();
				iy.RowsRemoved += b;
			}
			else
			{
				iz.CheckedChanged -= b6;
				iz.Checked = false;
				iz.CheckedChanged += b6;
			}
			return;
		}
		GameVariable gameVariable2 = tvVariables.SelectedNode.Tag as GameVariable;
		if (gameVariable2.VarArray.Count > 0 && gameVariable2.VarArray[0] is ArrayList)
		{
			if ((int)MessageBox.Show("Warning, this may result in loss of data.  Do you wish to continue?", "Warning", (MessageBoxButtons)4, (MessageBoxIcon)48) == 6)
			{
				((Control)h3).Visible = true;
				((Control)iy).Visible = false;
				gameVariable2.VarArray.Clear();
				cs(null, null);
			}
			else
			{
				iz.CheckedChanged -= b6;
				iz.Checked = true;
				iz.CheckedChanged += b6;
			}
		}
		else
		{
			((Control)h3).Visible = true;
			((Control)iy).Visible = false;
			gameVariable2.VarArray.Clear();
			cs(null, null);
		}
	}

	private void b(object A_0, DataGridViewCellEventArgs A_1)
	{
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		if (A_1.RowIndex <= -1)
		{
			return;
		}
		ArrayList arrayList = null;
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		if (gameVariable.VarArray.Count == 0)
		{
			gameVariable.VarArray.Add(new ArrayList());
			arrayList = (ArrayList)gameVariable.VarArray[0];
			for (int i = 0; i < ((BaseCollection)iy.Columns).Count; i++)
			{
				arrayList.Add("");
			}
			((DataGridViewCell)iy.Rows[0].HeaderCell).Value = ((DataGridViewBand)iy.Rows[0]).Index.ToString();
		}
		if (A_1.RowIndex + 1 > gameVariable.VarArray.Count)
		{
			gameVariable.VarArray.Add(new ArrayList());
			arrayList = (ArrayList)gameVariable.VarArray[A_1.RowIndex];
			for (int j = 0; j < ((BaseCollection)iy.Columns).Count; j++)
			{
				arrayList.Add("");
			}
			((DataGridViewCell)iy.Rows[A_1.RowIndex].HeaderCell).Value = ((DataGridViewBand)iy.Rows[A_1.RowIndex]).Index.ToString();
		}
		if (A_1.ColumnIndex == -1)
		{
			return;
		}
		arrayList = (ArrayList)gameVariable.VarArray[A_1.RowIndex];
		if (gameVariable == null)
		{
			return;
		}
		switch (gameVariable.vartype)
		{
		case GameVariable.VarType.VT_DATETIMEARRAY:
			try
			{
				if (iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString().Trim() != string.Empty)
				{
					Convert.ToDateTime(iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show("You have entered an invalid date time value.  It has been defaulted.");
				iy[A_1.ColumnIndex, A_1.RowIndex].Value = DateTime.Now.ToString();
			}
			arrayList[A_1.ColumnIndex] = iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_NUMBERARRAY:
			try
			{
				if (iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString().Trim() != string.Empty)
				{
					Convert.ToDouble(iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show("You have entered an invalid numeric value.  It has been defaulted.");
				iy[A_1.ColumnIndex, A_1.RowIndex].Value = 0;
			}
			arrayList[A_1.ColumnIndex] = iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_STRINGARRAY:
			if (A_1.ColumnIndex > -1)
			{
				if (iy[A_1.ColumnIndex, A_1.RowIndex].Value == null)
				{
					arrayList[A_1.ColumnIndex] = string.Empty;
					break;
				}
				arrayList[A_1.ColumnIndex] = iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
				TheGame.ValidateText(iy[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
			}
			break;
		}
	}

	private void b(object A_0, DataGridViewRowsRemovedEventArgs A_1)
	{
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		for (int i = 0; i < A_1.RowCount; i++)
		{
			gameVariable.VarArray.RemoveAt(A_1.RowIndex);
		}
	}

	private void a(object A_0, DataGridViewRowsRemovedEventArgs A_1)
	{
		_ = 0;
	}

	private void b5(object A_0, EventArgs A_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		QuickMenuitemsFrm quickMenuitemsFrm = new QuickMenuitemsFrm(ref TheGame.QuickCommands);
		((Form)quickMenuitemsFrm).ShowDialog();
		((Component)(object)quickMenuitemsFrm).Dispose();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "QuickCommands.bin");
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			binaryFormatter.Serialize(fileStream, TheGame.QuickCommands);
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

	private void j()
	{
	}

	private void b4(object A_0, EventArgs A_1)
	{
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Invalid comparison between Unknown and I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Invalid comparison between Unknown and I4
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		if (tvItems.SelectedNode == null || tvItems.SelectedNode.Tag == null)
		{
			return;
		}
		GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		MemoryStream memoryStream = new MemoryStream();
		binaryFormatter.Serialize(memoryStream, gameObject);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		i3 = (GameObject)binaryFormatter.Deserialize(memoryStream);
		i3.UniqueIdentifier = Guid.NewGuid();
		binaryFormatter.Serialize(memoryStream, i3);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		GameObject gameObject2 = (GameObject)binaryFormatter.Deserialize(memoryStream);
		gameObject2.UniqueIdentifier = Guid.NewGuid();
		for (int i = 0; i < gameObject2.Actions.Count; i++)
		{
			Rags.Action tempact = (Rags.Action)gameObject2.Actions[i];
			TheGame.RefactorAction(ref tempact, gameObject.UniqueIdentifier.ToString(), gameObject2.UniqueIdentifier.ToString());
		}
		if (!a(gameObject.name))
		{
			if ((int)MessageBox.Show("There is already an object named " + gameObject.name + " in the object library.  Would you like to rename this object?", "Duplicate Name", (MessageBoxButtons)4) != 6)
			{
				return;
			}
			GetNameFrm getNameFrm = new GetNameFrm("Please Enter Object Name:");
			if ((int)((Form)getNameFrm).ShowDialog() == 1)
			{
				gameObject2.name = ((Control)getNameFrm.txtEntry).Text;
				if (a(((Control)getNameFrm.txtEntry).Text))
				{
					ObjectLibrary.Add(gameObject2);
					this.i();
					MessageBox.Show("The " + gameObject2.name + " has been added to the library successfully.");
				}
				else
				{
					MessageBox.Show("Sorry, that object already exists.");
				}
			}
		}
		else
		{
			ObjectLibrary.Add(gameObject2);
			this.i();
			MessageBox.Show("The " + gameObject2.name + " has been added to the library successfully.");
		}
	}

	private void a(ref GamePicture A_0, int A_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		if (A_1 >= 0)
		{
			_ = 100;
		}
		EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)A_1);
		ImageCodecInfo val2 = b("image/jpeg");
		EncoderParameters val3 = new EncoderParameters(1);
		val3.Param[0] = val;
		MemoryStream memoryStream = new MemoryStream();
		A_0.TheImage.Save((Stream)memoryStream, val2, val3);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		A_0.TheImage = Image.FromStream((Stream)memoryStream);
	}

	private ImageCodecInfo b(string A_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length - 1; i++)
		{
			if (imageEncoders[i].MimeType == A_0)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	private bool a(string A_0)
	{
		foreach (GameObject item in ObjectLibrary)
		{
			if (string.Compare(item.name, A_0, ignoreCase: true) == 0)
			{
				return false;
			}
		}
		return true;
	}

	private void i()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "ObjectLibrary.bin");
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			binaryFormatter.Serialize(fileStream, ObjectLibrary);
		}
		finally
		{
			fileStream.Flush();
			fileStream.Close();
			fileStream.Dispose();
		}
	}

	private void b3(object A_0, EventArgs A_1)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		ObjectLibrarySelection objectLibrarySelection = new ObjectLibrarySelection();
		foreach (GameObject item in ObjectLibrary)
		{
			objectLibrarySelection.lbLibraryItems.Items.Add((object)new RoomComboItem(item.UniqueIdentifier, item.name));
		}
		((Form)objectLibrarySelection).ShowDialog();
		ab();
		((Component)(object)objectLibrarySelection).Dispose();
		i();
	}

	private void c(object A_0, CancelEventArgs A_1)
	{
	}

	private void b2(object A_0, EventArgs A_1)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (nr.SelectedNode != null)
		{
			PictureAdjustFrm pictureAdjustFrm = new PictureAdjustFrm(ref TheGame.PictureList, nr.SelectedNode.Text);
			((Form)pictureAdjustFrm).ShowDialog();
			((Component)(object)pictureAdjustFrm).Dispose();
		}
	}

	private void b1(object A_0, EventArgs A_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		PictureAdjustFrm pictureAdjustFrm = new PictureAdjustFrm(ref TheGame.PictureList, "all");
		((Form)pictureAdjustFrm).ShowDialog();
		((Component)(object)pictureAdjustFrm).Dispose();
	}

	private void b0(object A_0, EventArgs A_1)
	{
		b3(null, null);
	}

	private void bz(object A_0, EventArgs A_1)
	{
		if (tvVariables.SelectedNode.Tag is GameVariable gameVariable)
		{
			gameVariable.VarComment = ((Control)i7).Text;
		}
	}

	private void by(object A_0, EventArgs A_1)
	{
	}

	private void bx(object A_0, EventArgs A_1)
	{
	}

	private void bw(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm("Name Of The New Zone:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		bool flag = false;
		foreach (string layeredClothingZone in TheGame.LayeredClothingZones)
		{
			if (string.Compare(layeredClothingZone, ((Control)getNameFrm.txtEntry).Text, ignoreCase: true) == 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			MessageBox.Show("Sorry, there is a zone named " + ((Control)getNameFrm.txtEntry).Text + " already in the zone list.");
			return;
		}
		TheGame.LayeredClothingZones.Add(((Control)getNameFrm.txtEntry).Text);
		ac();
	}

	private void bv(object A_0, EventArgs A_1)
	{
		if (ji.SelectedItem != null)
		{
			TheGame.LayeredClothingZones.Remove(ji.SelectedItem.ToString());
			ac();
		}
	}

	private void bu(object A_0, EventArgs A_1)
	{
		if (jp.SelectedItem != null && tvItems.SelectedNode.Tag is GameObject gameObject)
		{
			gameObject.LayeredZoneLevels.Add(jp.SelectedItem.ToString() + ":" + jn.SelectedItem.ToString());
			h();
		}
	}

	private void h()
	{
		jt.Items.Clear();
		if (!(tvItems.SelectedNode.Tag is GameObject gameObject))
		{
			return;
		}
		foreach (string layeredZoneLevel in gameObject.LayeredZoneLevels)
		{
			jt.Items.Add((object)layeredZoneLevel);
		}
	}

	private void bt(object A_0, EventArgs A_1)
	{
		if (jt.SelectedItem != null && tvItems.SelectedNode.Tag is GameObject gameObject)
		{
			gameObject.LayeredZoneLevels.Remove(jt.SelectedItem.ToString());
			h();
		}
	}

	private void bs(object A_0, EventArgs A_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		if (((ListControl)jy).SelectedIndex == jy.Items.Count - 1)
		{
			GetNameFrm getNameFrm = new GetNameFrm("Enter new room group name:");
			if ((int)((Form)getNameFrm).ShowDialog() == 1)
			{
				if (((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty && ((Control)getNameFrm.txtEntry).Text.Trim() != "<Add New Room>")
				{
					TheGame.RoomGroups.Add(((Control)getNameFrm.txtEntry).Text);
					o();
					jy.SelectedItem = ((Control)getNameFrm.txtEntry).Text;
					Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
					if (roomByID != null)
					{
						roomByID.Group = ((Control)getNameFrm.txtEntry).Text;
					}
				}
			}
			else
			{
				jy.SelectedItem = "None";
			}
		}
		else
		{
			Room roomByID2 = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			if (roomByID2 != null)
			{
				roomByID2.Group = jy.SelectedItem.ToString();
			}
		}
	}

	private void a(object A_0, ToolStripItemClickedEventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		if (A_1.ClickedItem.Text == "<Add New Group>")
		{
			GetNameFrm getNameFrm = new GetNameFrm("Enter new room group name:");
			if ((int)((Form)getNameFrm).ShowDialog() != 1 || !(((Control)getNameFrm.txtEntry).Text.Trim() != string.Empty) || !(((Control)getNameFrm.txtEntry).Text.Trim() != "<Add New Group>"))
			{
				return;
			}
			TheGame.RoomGroups.Add(((Control)getNameFrm.txtEntry).Text);
			o();
			jy.SelectedItem = ((Control)getNameFrm.txtEntry).Text;
			{
				foreach (DataGridViewRow item in (BaseCollection)dgvRoomList.SelectedRows)
				{
					DataGridViewRow val = item;
					Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)val).Tag);
					if (roomByID != null)
					{
						roomByID.Group = ((Control)getNameFrm.txtEntry).Text;
					}
				}
				return;
			}
		}
		foreach (DataGridViewRow item2 in (BaseCollection)dgvRoomList.SelectedRows)
		{
			DataGridViewRow val2 = item2;
			Room roomByID2 = TheGame.GetRoomByID((Guid)((DataGridViewBand)val2).Tag);
			if (roomByID2 != null)
			{
				roomByID2.Group = A_1.ClickedItem.Text;
			}
		}
		jy.SelectedItem = A_1.ClickedItem.Text;
	}

	private void b(object A_0, CancelEventArgs A_1)
	{
		if (((BaseCollection)dgvRoomList.SelectedRows).Count > 1)
		{
			((ToolStripItem)hl).Enabled = false;
			((ToolStripItem)hn).Enabled = false;
		}
		else
		{
			((ToolStripItem)hl).Enabled = true;
			((ToolStripItem)hn).Enabled = true;
		}
	}

	private void br(object A_0, EventArgs A_1)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		GamePicture gamePictureByName = TheGame.GetGamePictureByName(nr.SelectedNode.Text);
		if (gamePictureByName == null)
		{
			return;
		}
		((FileDialog)j2).FileName = gamePictureByName.TheName;
		if ((int)((CommonDialog)j2).ShowDialog() == 1)
		{
			byte[] bytes = null;
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", gamePictureByName.TheName);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				bytes = (byte[])sqlCeDataReader["Data"];
			}
			File.WriteAllBytes(((FileDialog)j2).FileName, bytes);
		}
	}

	private void bq(object A_0, EventArgs A_1)
	{
		((Control)j5).Enabled = j6.Checked;
	}

	private void bp(object A_0, EventArgs A_1)
	{
	}

	private void bo(object A_0, EventArgs A_1)
	{
	}

	private void bn(object A_0, EventArgs A_1)
	{
		TheGame.bHideMainPicDisplay = j6.Checked;
	}

	private void bm(object A_0, EventArgs A_1)
	{
		TheGame.bUseInlineImages = j5.Checked;
	}

	private void bl(object A_0, EventArgs A_1)
	{
		TheGame.bHidePortrait = j4.Checked;
	}

	private void bk(object A_0, EventArgs A_1)
	{
		if (((ListControl)this.m_gm).SelectedIndex != -1)
		{
			int selectedIndex = ((ListControl)this.m_gm).SelectedIndex;
			if (selectedIndex != 0)
			{
				StatusBarItem statusBarItem = (StatusBarItem)TheGame.StatusBarItems[((ListControl)this.m_gm).SelectedIndex];
				TheGame.StatusBarItems.Remove(statusBarItem);
				TheGame.StatusBarItems.Insert(selectedIndex - 1, statusBarItem);
				ag();
			}
		}
	}

	private void bj(object A_0, EventArgs A_1)
	{
		if (((ListControl)this.m_gm).SelectedIndex != -1)
		{
			int selectedIndex = ((ListControl)this.m_gm).SelectedIndex;
			if (selectedIndex != this.m_gm.Items.Count - 1)
			{
				StatusBarItem statusBarItem = (StatusBarItem)TheGame.StatusBarItems[((ListControl)this.m_gm).SelectedIndex];
				TheGame.StatusBarItems.Remove(statusBarItem);
				TheGame.StatusBarItems.Insert(selectedIndex + 1, statusBarItem);
				ag();
			}
		}
	}

	private void bi(object A_0, EventArgs A_1)
	{
		if (TheGame != null)
		{
			TheGame.AuthorName = ((Control)ke).Text;
			TheGame.ValidateText(((Control)ke).Text);
		}
	}

	private void bh(object A_0, EventArgs A_1)
	{
		if (TheGame != null)
		{
			TheGame.GameVersion = ((Control)ki).Text;
			TheGame.ValidateText(((Control)ki).Text);
		}
	}

	private void bg(object A_0, EventArgs A_1)
	{
		if (TheGame != null)
		{
			TheGame.GameInformation = ((Control)kg).Text;
			TheGame.ValidateText(((Control)kg).Text);
		}
	}

	private void bf(object A_0, EventArgs A_1)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		ap(null, null);
		((Form)new RagsShare()).ShowDialog();
	}

	private void be(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((Form)new RagsShare()).ShowDialog();
	}

	private void b(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		if (val != null)
		{
			int selectionStart = ((TextBoxBase)val).SelectionStart;
			string text = insertVariableToolStripMenuItem();
			if (text != string.Empty)
			{
				((Control)val).Text = ((Control)val).Text.Insert(selectionStart, text);
			}
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.KeyData != 262230)
		{
			return;
		}
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		if (val != null)
		{
			int selectionStart = ((TextBoxBase)val).SelectionStart;
			string text = insertVariableToolStripMenuItem();
			if (text != string.Empty)
			{
				((Control)val).Text = ((Control)val).Text.Insert(selectionStart, text);
			}
		}
	}

	private void bd(object A_0, EventArgs A_1)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)ku).Text.Trim() != string.Empty)
		{
			Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
			if (roomByID == null)
			{
				return;
			}
			foreach (CustomProperty customProperty in roomByID.CustomProperties)
			{
				if (customProperty.Name == ((Control)ku).Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + ((Control)ku).Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (Room room in TheGame.RoomList)
				{
					room.CustomProperties.Add(new CustomProperty(((Control)ku).Text, ((Control)ks).Text));
					g();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void g()
	{
		kk.Rows.Clear();
		Room roomByID = TheGame.GetRoomByID((Guid)((DataGridViewBand)dgvRoomList.SelectedRows[0]).Tag);
		if (roomByID == null)
		{
			return;
		}
		foreach (CustomProperty customProperty in roomByID.CustomProperties)
		{
			int num = kk.Rows.Add(new object[2] { customProperty.Name, customProperty.Value });
			((DataGridViewBand)kk.Rows[num]).Tag = customProperty;
		}
	}

	private void f()
	{
		lg.Rows.Clear();
		if (tvItems.SelectedNode == null || tvItems.SelectedNode.Tag == null || !(tvItems.SelectedNode.Tag is GameObject gameObject))
		{
			return;
		}
		foreach (CustomProperty customProperty in gameObject.CustomProperties)
		{
			int num = lg.Rows.Add(new object[2] { customProperty.Name, customProperty.Value });
			((DataGridViewBand)lg.Rows[num]).Tag = customProperty;
		}
	}

	private void e()
	{
		ls.Rows.Clear();
		if (((BaseCollection)dgvCharacters.SelectedRows).Count > 0)
		{
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			if (character != null)
			{
				foreach (CustomProperty customProperty in character.CustomProperties)
				{
					int num = ls.Rows.Add(new object[2] { customProperty.Name, customProperty.Value });
					((DataGridViewBand)ls.Rows[num]).Tag = customProperty;
				}
			}
		}
		a1(null, null);
	}

	private void bc(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)kk.SelectedRows).Count == 1 && ((DataGridViewBand)kk.SelectedRows[0]).Tag != null && ((DataGridViewBand)kk.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)ku).Text = customProperty.Name;
			((Control)ks).Text = customProperty.Value;
		}
	}

	private void bb(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)kk.SelectedRows).Count == 1 && ((DataGridViewBand)kk.SelectedRows[0]).Tag != null && ((DataGridViewBand)kk.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)ks).Text;
			g();
		}
	}

	private void ba(object A_0, EventArgs A_1)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Invalid comparison between Unknown and I4
		if (((BaseCollection)kk.SelectedRows).Count != 1 || ((DataGridViewBand)kk.SelectedRows[0]).Tag == null || !(((DataGridViewBand)kk.SelectedRows[0]).Tag is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all rooms. Do you wish to continue?", "Warning", (MessageBoxButtons)4) != 6)
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
		g();
	}

	private void a9(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)k4.SelectedRows).Count == 1 && ((DataGridViewBand)k4.SelectedRows[0]).Tag != null && ((DataGridViewBand)k4.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)k0).Text = customProperty.Name;
			((Control)ky).Text = customProperty.Value;
		}
	}

	private void a8(object A_0, EventArgs A_1)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)k0).Text.Trim() != string.Empty)
		{
			foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
			{
				if (customProperty.Name == ((Control)k0).Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + ((Control)k0).Text + " is already in the custom properties list.");
					return;
				}
			}
			TheGame.ThePlayer.CustomProperties.Add(new CustomProperty(((Control)k0).Text, ((Control)ky).Text));
			aj();
		}
		else
		{
			MessageBox.Show("Please fill in a valid property name before clicking the add button.");
		}
	}

	private void a7(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)k4.SelectedRows).Count == 1 && ((DataGridViewBand)k4.SelectedRows[0]).Tag != null && ((DataGridViewBand)k4.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)ky).Text;
			aj();
		}
	}

	private void a6(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)k4.SelectedRows).Count != 1 || ((DataGridViewBand)k4.SelectedRows[0]).Tag == null || !(((DataGridViewBand)k4.SelectedRows[0]).Tag is CustomProperty customProperty))
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
		aj();
	}

	private void a5(object A_0, EventArgs A_1)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		if (tvItems.SelectedNode == null)
		{
			return;
		}
		if (((Control)lc).Text.Trim() != string.Empty)
		{
			if (!(tvItems.SelectedNode.Tag is GameObject gameObject))
			{
				return;
			}
			foreach (CustomProperty customProperty in gameObject.CustomProperties)
			{
				if (customProperty.Name == ((Control)lc).Text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + ((Control)ku).Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (GameObject @object in TheGame.ObjectList)
				{
					@object.CustomProperties.Add(new CustomProperty(((Control)lc).Text, ((Control)la).Text));
					f();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void a4(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)lg.SelectedRows).Count == 1 && ((DataGridViewBand)lg.SelectedRows[0]).Tag != null && ((DataGridViewBand)lg.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)la).Text;
			f();
		}
	}

	private void a3(object A_0, EventArgs A_1)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Invalid comparison between Unknown and I4
		if (((BaseCollection)lg.SelectedRows).Count != 1 || ((DataGridViewBand)lg.SelectedRows[0]).Tag == null || !(((DataGridViewBand)lg.SelectedRows[0]).Tag is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all objects. Do you wish to continue?", "Warning", (MessageBoxButtons)4) != 6)
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
		f();
	}

	private void a2(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)lg.SelectedRows).Count == 1 && ((DataGridViewBand)lg.SelectedRows[0]).Tag != null && ((DataGridViewBand)lg.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)lc).Text = customProperty.Name;
			((Control)la).Text = customProperty.Value;
		}
	}

	private void a1(object A_0, EventArgs A_1)
	{
		((Control)lm).Text = string.Empty;
		((Control)lo).Text = string.Empty;
		if (((BaseCollection)ls.SelectedRows).Count == 1 && ((DataGridViewBand)ls.SelectedRows[0]).Tag != null && ((DataGridViewBand)ls.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)lo).Text = customProperty.Name;
			((Control)lm).Text = customProperty.Value;
		}
	}

	private void a0(object A_0, EventArgs A_1)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		string text = ((Control)lo).Text;
		string text2 = ((Control)lm).Text;
		if (text.Trim() != string.Empty)
		{
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			if (character == null)
			{
				return;
			}
			foreach (CustomProperty customProperty in character.CustomProperties)
			{
				if (customProperty.Name == text)
				{
					MessageBox.Show("Please select a unique property name.  The name " + ((Control)lo).Text + " is already in the custom properties list.");
					return;
				}
			}
			{
				foreach (Character character2 in TheGame.CharacterList)
				{
					character2.CustomProperties.Add(new CustomProperty(text, text2));
					e();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void az(object A_0, EventArgs A_1)
	{
		if ((Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag != null && ((DataGridViewBand)ls.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)lm).Text;
			e();
		}
	}

	private void ay(object A_0, EventArgs A_1)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		if ((Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag == null || !(((DataGridViewBand)ls.SelectedRows[0]).Tag is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all characters. Do you wish to continue?", "Warning", (MessageBoxButtons)4) != 6)
		{
			return;
		}
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (CustomProperty customProperty2 in character.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					character.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		e();
	}

	private void ax(object A_0, EventArgs A_1)
	{
		((Control)l4).Text = string.Empty;
		((Control)l2).Text = string.Empty;
		if (((BaseCollection)l8.SelectedRows).Count == 1 && ((DataGridViewBand)l8.SelectedRows[0]).Tag != null && ((DataGridViewBand)l8.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)l4).Text = customProperty.Name;
			((Control)l2).Text = customProperty.Value;
		}
	}

	private void d()
	{
		l8.Rows.Clear();
		if (tvVariables.SelectedNode == null)
		{
			return;
		}
		if (tvVariables.SelectedNode.Tag is GameVariable gameVariable)
		{
			foreach (CustomProperty customProperty in gameVariable.CustomProperties)
			{
				int num = l8.Rows.Add(new object[2] { customProperty.Name, customProperty.Value });
				((DataGridViewBand)l8.Rows[num]).Tag = customProperty;
			}
		}
		ax(null, null);
	}

	private void aw(object A_0, EventArgs A_1)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		string text = ((Control)l4).Text;
		string text2 = ((Control)l2).Text;
		if (text.Trim() != string.Empty)
		{
			if (!(tvVariables.SelectedNode.Tag is GameVariable gameVariable))
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
					d();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void av(object A_0, EventArgs A_1)
	{
		if (tvVariables.SelectedNode.Tag is GameVariable && ((DataGridViewBand)l8.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)l2).Text;
			d();
		}
	}

	private void au(object A_0, EventArgs A_1)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		if (!(tvVariables.SelectedNode.Tag is GameVariable) || !(((DataGridViewBand)l8.SelectedRows[0]).Tag is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all variables. Do you wish to continue?", "Warning", (MessageBoxButtons)4) != 6)
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
		d();
	}

	private void at(object A_0, EventArgs A_1)
	{
		((Control)mj).Text = string.Empty;
		((Control)mh).Text = string.Empty;
		if (((BaseCollection)mn.SelectedRows).Count == 1 && ((DataGridViewBand)mn.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			((Control)mj).Text = customProperty.Name;
			((Control)mh).Text = customProperty.Value;
		}
	}

	private void c()
	{
		mn.Rows.Clear();
		if (((BaseCollection)dgvTimers.SelectedRows).Count > 0)
		{
			Rags.Timer timer = (Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag;
			if (timer != null)
			{
				foreach (CustomProperty customProperty in timer.CustomProperties)
				{
					int num = mn.Rows.Add(new object[2] { customProperty.Name, customProperty.Value });
					((DataGridViewBand)mn.Rows[num]).Tag = customProperty;
				}
			}
		}
		at(null, null);
	}

	private void @as(object A_0, EventArgs A_1)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		string text = ((Control)mj).Text;
		string text2 = ((Control)mh).Text;
		if (text.Trim() != string.Empty)
		{
			Rags.Timer timer = (Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag;
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
					c();
				}
				return;
			}
		}
		MessageBox.Show("Please fill in a valid property name before clicking the add button.");
	}

	private void ar(object A_0, EventArgs A_1)
	{
		if ((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag != null && ((DataGridViewBand)mn.SelectedRows[0]).Tag is CustomProperty customProperty)
		{
			customProperty.Value = ((Control)mh).Text;
			c();
		}
	}

	private void aq(object A_0, EventArgs A_1)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		if ((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag == null || !(((DataGridViewBand)mn.SelectedRows[0]).Tag is CustomProperty customProperty) || (int)MessageBox.Show("Warning: This will delete this custom property from all timers. Do you wish to continue?", "Warning", (MessageBoxButtons)4) != 6)
		{
			return;
		}
		foreach (Rags.Timer timer in TheGame.TimerList)
		{
			foreach (CustomProperty customProperty2 in timer.CustomProperties)
			{
				if (customProperty.Name == customProperty2.Name)
				{
					timer.CustomProperties.Remove(customProperty2);
					break;
				}
			}
		}
		c();
	}

	private void ap(object A_0, EventArgs A_1)
	{
	}

	private void ao(object A_0, EventArgs A_1)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		TextBox control = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox control2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		RagsEditor ragsEditor = null;
		if (control != null)
		{
			ragsEditor = new RagsEditor(ref control, TheGame);
		}
		else if (control2 != null)
		{
			ragsEditor = new RagsEditor(ref control2, TheGame);
		}
		if (ragsEditor != null)
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void an(object A_0, EventArgs A_1)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		iy.EndEdit();
		b(null, new DataGridViewCellEventArgs(iy.SelectedCells[0].ColumnIndex, iy.SelectedCells[0].RowIndex));
		((Form)new GridViewEditor(this)).ShowDialog();
		n();
	}

	private void am(object A_0, EventArgs A_1)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		RichTextBox control = (RichTextBox)((A_0 is RichTextBox) ? A_0 : null);
		RagsEditor ragsEditor = null;
		if (control != null)
		{
			ragsEditor = new RagsEditor(ref control, TheGame);
		}
		if (ragsEditor != null)
		{
			((Form)ragsEditor).ShowDialog();
		}
	}

	private void al(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)dgvCharacters.SelectedRows).Count > 0)
		{
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			if (character != null)
			{
				character.CharnameOverride = ((Control)tbCharacterNameOverride).Text;
				TheGame.ValidateText(((Control)tbCharacterNameOverride).Text);
			}
		}
	}

	private void ak(object A_0, EventArgs A_1)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		GetDimensionWidthFrm getDimensionWidthFrm = new GetDimensionWidthFrm();
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		if ((int)((Form)getDimensionWidthFrm).ShowDialog() != 1)
		{
			return;
		}
		if (Convert.ToInt32(getDimensionWidthFrm.udWidth.Value) < iy.ColumnCount)
		{
			if ((int)MessageBox.Show("This may result in a loss of data.  Are you sure you wish to remove some columns?", "Warning", (MessageBoxButtons)4) == 6)
			{
				foreach (ArrayList item in gameVariable.VarArray)
				{
					for (int i = Convert.ToInt32(getDimensionWidthFrm.udWidth.Value) - 1; i < item.Count; i++)
					{
						item.RemoveAt(Convert.ToInt32(getDimensionWidthFrm.udWidth.Value));
					}
				}
			}
		}
		else
		{
			foreach (ArrayList item2 in gameVariable.VarArray)
			{
				for (int j = item2.Count; j < Convert.ToInt32(getDimensionWidthFrm.udWidth.Value); j++)
				{
					item2.Add("");
				}
			}
		}
		iy.ColumnCount = Convert.ToInt32(getDimensionWidthFrm.udWidth.Value);
	}

	private void aj(object A_0, EventArgs A_1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		bool flag = true;
		if (this.m_f3.Checked)
		{
			if ((int)MessageBox.Show("Live Timer must be set to run always.  This timer is currently set to run a specific length of time.  Would you like to proceed?", "Run Always", (MessageBoxButtons)4) == 7)
			{
				flag = false;
			}
			else
			{
				this.m_f4.Checked = true;
			}
		}
		if (flag)
		{
			((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).LiveTimer = mx.Checked;
		}
	}

	private void ai(object A_0, EventArgs A_1)
	{
		((Rags.Timer)((DataGridViewBand)dgvTimers.SelectedRows[0]).Tag).TimerSeconds = Convert.ToInt32(mw.Value);
	}

	private void ah(object A_0, EventArgs A_1)
	{
		TheGame.bgMusic = m3.SelectedItem.ToString();
	}

	private void ag(object A_0, EventArgs A_1)
	{
		TheGame.bRepeatbgMusic = m4.Checked;
	}

	private void af(object A_0, EventArgs A_1)
	{
	}

	private void h(object A_0, DragEventArgs A_1)
	{
		if (((BaseCollection)m7.SelectedRows).Count <= 0 || !A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		string text = (string)A_1.Data.GetData(DataFormats.StringFormat);
		if (!(text == "tvNode") || nr.SelectedNode == null || nr.SelectedNode.Tag == null)
		{
			return;
		}
		string text2 = nr.SelectedNode.Text;
		bool flag = false;
		foreach (string item in nc.Items)
		{
			if (item == text)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			nc.Items.Add((object)text2);
			GamePicture gamePictureByName = TheGame.GetGamePictureByName(m7.SelectedRows[0].Cells[0].Value.ToString());
			if (gamePictureByName != null)
			{
				gamePictureByName.LayeredImages.Add(text2);
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
				sqlCeCommand.Parameters.AddWithValue("@data", text2);
				sqlCeCommand.Parameters.AddWithValue("@order", gamePictureByName.LayeredImages.Count);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
				((Control)na).Invalidate();
			}
		}
	}

	private void a(object A_0, PaintEventArgs A_1)
	{
		if (TheGame == null || A_0 == null)
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
			object pictureByName = TheGame.GetPictureByName(layeredImage);
			Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val2 != null)
			{
				A_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
			}
		}
	}

	private void ae(object A_0, EventArgs A_1)
	{
		b();
	}

	private void b()
	{
		nc.Items.Clear();
		if (m7.Rows.Count <= 0 || ((BaseCollection)m7.SelectedRows).Count <= 0)
		{
			return;
		}
		GamePicture gamePictureByName = TheGame.GetGamePictureByName(m7.SelectedRows[0].Cells[0].Value.ToString());
		if (gamePictureByName == null)
		{
			return;
		}
		object pictureByName = TheGame.GetPictureByName(gamePictureByName.TheName);
		Image val = (Image)((pictureByName is Image) ? pictureByName : null);
		if (val == null)
		{
			return;
		}
		foreach (string layeredImage in gamePictureByName.LayeredImages)
		{
			nc.Items.Add((object)layeredImage);
		}
		((Control)na).Tag = gamePictureByName;
		na.Image = val;
	}

	private void g(object A_0, DragEventArgs A_1)
	{
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "tvNode")
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void ad(object A_0, EventArgs A_1)
	{
		if (nc.SelectedItem == null || ((BaseCollection)m7.SelectedRows).Count <= 0)
		{
			return;
		}
		GamePicture gamePictureByName = TheGame.GetGamePictureByName(m7.SelectedRows[0].Cells[0].Value.ToString());
		if (gamePictureByName == null)
		{
			return;
		}
		foreach (string layeredImage in gamePictureByName.LayeredImages)
		{
			if (!(layeredImage == nc.SelectedItem.ToString()))
			{
				continue;
			}
			gamePictureByName.LayeredImages.Remove(layeredImage);
			SqlCeConnection dBConnection = Game.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
			int num = 0;
			foreach (string layeredImage2 in gamePictureByName.LayeredImages)
			{
				num++;
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
				sqlCeCommand2.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
				sqlCeCommand2.Parameters.AddWithValue("@data", layeredImage2);
				sqlCeCommand2.Parameters.AddWithValue("@order", num);
				sqlCeCommand2.ExecuteNonQuery();
				sqlCeCommand2.Dispose();
			}
			break;
		}
		b();
	}

	private void ac(object A_0, EventArgs A_1)
	{
		if (nc.Items.Count <= 1 || ((ListControl)nc).SelectedIndex == nc.Items.Count - 1 || ((BaseCollection)m7.SelectedRows).Count == 0)
		{
			return;
		}
		GamePicture gamePictureByName = TheGame.GetGamePictureByName(m7.SelectedRows[0].Cells[0].Value.ToString());
		if (gamePictureByName == null)
		{
			return;
		}
		int selectedIndex = ((ListControl)nc).SelectedIndex;
		string text = nc.Items[selectedIndex].ToString();
		gamePictureByName.LayeredImages.RemoveAt(selectedIndex);
		gamePictureByName.LayeredImages.Insert(selectedIndex + 1, text);
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		int num = 0;
		foreach (string layeredImage in gamePictureByName.LayeredImages)
		{
			num++;
			SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
			sqlCeCommand2.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
			sqlCeCommand2.Parameters.AddWithValue("@data", layeredImage);
			sqlCeCommand2.Parameters.AddWithValue("@order", num);
			sqlCeCommand2.ExecuteNonQuery();
			sqlCeCommand2.Dispose();
		}
		b();
		nc.SelectedItem = text;
	}

	private void ab(object A_0, EventArgs A_1)
	{
		if (nc.Items.Count <= 1 || ((ListControl)nc).SelectedIndex == 0 || ((BaseCollection)m7.SelectedRows).Count == 0)
		{
			return;
		}
		GamePicture gamePictureByName = TheGame.GetGamePictureByName(m7.SelectedRows[0].Cells[0].Value.ToString());
		if (gamePictureByName == null)
		{
			return;
		}
		int selectedIndex = ((ListControl)nc).SelectedIndex;
		string text = nc.Items[selectedIndex].ToString();
		gamePictureByName.LayeredImages.RemoveAt(selectedIndex);
		gamePictureByName.LayeredImages.Insert(selectedIndex - 1, text);
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from MediaLayeredImages where MediaName=@medianame", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		int num = 0;
		foreach (string layeredImage in gamePictureByName.LayeredImages)
		{
			num++;
			SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into MediaLayeredImages (MediaName,Data,[Order]) values (@medianame,@data,@order)", dBConnection);
			sqlCeCommand2.Parameters.AddWithValue("@medianame", m7.SelectedRows[0].Cells[0].Value.ToString());
			sqlCeCommand2.Parameters.AddWithValue("@data", layeredImage);
			sqlCeCommand2.Parameters.AddWithValue("@order", num);
			sqlCeCommand2.ExecuteNonQuery();
			sqlCeCommand2.Dispose();
		}
		b();
		nc.SelectedItem = text;
	}

	private void aa(object A_0, EventArgs A_1)
	{
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		((Control)tabControl1).Focus();
		if (!an())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
		}
		else
		{
			if ((int)((CommonDialog)nm).ShowDialog() == 2)
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.m_n = ((FileDialog)nm).FileName;
				MemoryStream memoryStream = new MemoryStream();
				new BinaryFormatter().Serialize(memoryStream, TheGame);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				this.m_a = new MemoryStream(memoryStream.ToArray());
				memoryStream.Seek(0L, SeekOrigin.Begin);
				EncDec.Encrypt(memoryStream, this.m_n, this.m_b);
				try
				{
					memoryStream = new MemoryStream();
					CryptoStream cryptoStream = null;
					EncDec.Decrypt(this.m_n, ref memoryStream, ref cryptoStream, this.m_b);
					memoryStream.Close();
					memoryStream.Dispose();
					cryptoStream.Close();
					cryptoStream.Dispose();
				}
				catch
				{
					memoryStream = new MemoryStream();
					new BinaryFormatter().Serialize(memoryStream, TheGame);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					EncDec.Encrypt(memoryStream, this.m_n + ".001.RPK", this.m_b);
					try
					{
						memoryStream.Seek(0L, SeekOrigin.Begin);
						CryptoStream cryptoStream2 = null;
						EncDec.Decrypt(this.m_n + ".001.RPK", ref memoryStream, ref cryptoStream2, this.m_b);
						MessageBox.Show("Your initial save failed.  Your file was saved as " + this.m_n + ".001.RAG successfully.");
						memoryStream.Close();
						memoryStream.Dispose();
						cryptoStream2.Close();
						cryptoStream2.Dispose();
					}
					catch
					{
						MessageBox.Show("Unable to save " + this.m_n + " successfully.  Please try saving under a different name.");
					}
				}
				((Control)this).Text = "Rags Designer - " + this.m_n;
				memoryStream.Close();
				memoryStream.Dispose();
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}

	private void z(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Invalid comparison between Unknown and I4
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((CommonDialog)nn).ShowDialog() == 2)
		{
			return;
		}
		string fileName = ((FileDialog)nn).FileName;
		MemoryStream memst = new MemoryStream();
		CryptoStream cryptoStream = null;
		EncDec.Decrypt(fileName, ref memst, ref cryptoStream, this.m_b);
		memst.Seek(0L, SeekOrigin.Begin);
		Game game = new Game();
		try
		{
			game = (Game)new BinaryFormatter().Deserialize(memst);
		}
		catch
		{
			MessageBox.Show("Sorry, This RAGS Game file is unreadable.", "Unreadable game");
			return;
		}
		memst.Close();
		memst.Dispose();
		cryptoStream.Close();
		cryptoStream.Dispose();
		foreach (GameObject @object in game.ObjectList)
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
				Room roomByName = game.GetRoomByName(ref @object.locationname);
				if (roomByName != null)
				{
					@object.locationname = roomByName.UniqueID.ToString();
				}
			}
		}
		foreach (Character character in game.CharacterList)
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
				else if (game.GetRoomByName(ref character.CurrentRoom) != null)
				{
					character.CurrentRoom = game.GetRoomByName(ref character.CurrentRoom).UniqueID.ToString();
				}
			}
		}
		game.CorrectCommandAndConditions();
		if (game.bPasswordProtected)
		{
			int i = 0;
			bool flag = false;
			for (; i < 3; i++)
			{
				GetNameFrm getNameFrm = new GetNameFrm("Enter Password:");
				if ((int)((Form)getNameFrm).ShowDialog() == 2)
				{
					game = new Game();
					break;
				}
				Version version = new Version(Game.CurrentObjectVersionNumber);
				Version version2 = new Version("1.0.9.0");
				if (version <= version2)
				{
					if (((Control)getNameFrm.txtEntry).Text == game.GamePassword)
					{
						flag = true;
						((Control)this.m_el).Text = ((Control)getNameFrm.txtEntry).Text;
						game.GamePassword = EncDec.ComputeHash(((Control)getNameFrm.txtEntry).Text, "SHA1", null);
						break;
					}
				}
				else if (EncDec.VerifyHash(((Control)getNameFrm.txtEntry).Text, "SHA1", game.GamePassword))
				{
					flag = true;
					((Control)this.m_el).Text = ((Control)getNameFrm.txtEntry).Text;
					break;
				}
				MessageBox.Show("Incorrect Password.  Please Try Again.");
			}
			if (!flag)
			{
				game = new Game();
			}
		}
		if (game != null)
		{
			a(ref game);
		}
	}

	private void a(ref Game A_0)
	{
		foreach (Room room in A_0.RoomList)
		{
			TheGame.RoomList.Insert(0, room);
		}
		foreach (CustomProperty customProperty in A_0.ThePlayer.CustomProperties)
		{
			if (!TheGame.ThePlayer.CustomProperties.Contains(customProperty))
			{
				TheGame.ThePlayer.CustomProperties.Add(customProperty);
			}
		}
		a(ref A_0.ThePlayer.Actions, ref TheGame.ThePlayer.Actions);
		foreach (GameObject @object in A_0.ObjectList)
		{
			TheGame.ObjectList.Insert(0, @object);
		}
		foreach (Character character in A_0.CharacterList)
		{
			TheGame.CharacterList.Insert(0, character);
		}
		foreach (GameVariable variable in A_0.VariableList)
		{
			TheGame.VariableList.Insert(0, variable);
		}
		foreach (Rags.Timer timer in A_0.TimerList)
		{
			TheGame.TimerList.Insert(0, timer);
		}
		foreach (GamePicture picture in A_0.PictureList)
		{
			TheGame.PictureList.Insert(0, picture);
		}
		am();
	}

	private bool b(ref ArrayList A_0, string A_1)
	{
		bool result = false;
		foreach (Rags.Action item in A_0)
		{
			if (item.name == A_1)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private Rags.Action a(ref ArrayList A_0, string A_1)
	{
		foreach (Rags.Action item in A_0)
		{
			if (item.name == A_1)
			{
				return item;
			}
		}
		return null;
	}

	private void a(ref ArrayList A_0, ref ArrayList A_1)
	{
		foreach (Rags.Action item in A_0)
		{
			if (!b(ref A_1, item.name))
			{
				A_1.Add(item);
				continue;
			}
			Rags.Action action2 = a(ref A_1, item.name);
			if (action2 == null)
			{
				continue;
			}
			foreach (Condition condition in item.Conditions)
			{
				action2.Conditions.Add(condition);
			}
			foreach (object passCommand in item.PassCommands)
			{
				action2.PassCommands.Add(passCommand);
			}
			foreach (object failCommand in item.FailCommands)
			{
				action2.FailCommands.Add(failCommand);
			}
		}
	}

	private void a(string A_0, string A_1)
	{
		Stream? manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RagsDesigner.Resources." + A_0);
		FileStream fileStream = new FileStream(Path.Combine(A_1, A_0), FileMode.Create);
		byte[] array = new byte[manifestResourceStream.Length + 1];
		manifestResourceStream.Read(array, 0, array.Length - 1);
		fileStream.Write(array, 0, array.Length - 1);
		fileStream.Flush();
		fileStream.Close();
	}

	private void y(object A_0, EventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((Control)tabControl1).Focus();
		if (!an())
		{
			MessageBox.Show("This game is in read only mode due to trial limitations.  Your changes can not be saved.");
		}
		else
		{
			if ((int)((CommonDialog)os).ShowDialog() == 2)
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				if (!Directory.Exists(Path.Combine(os.SelectedPath, "images")))
				{
					Directory.CreateDirectory(Path.Combine(os.SelectedPath, "images"));
				}
				string text = Path.Combine(os.SelectedPath, "images");
				a("300px-Compass_Rose_UD.png", text);
				a("300px-Compass_Rose_English_North.png", text);
				a("North.png", text);
				a("South.png", text);
				a("East.png", text);
				a("West.png", text);
				a("NorthWest.png", text);
				a("NorthEast.png", text);
				a("SouthWest.png", text);
				a("SouthEast.png", text);
				string text2 = Path.Combine(os.SelectedPath, "css");
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				Stream? manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RagsDesigner.Resources.style.css");
				FileStream fileStream = new FileStream(Path.Combine(text2, "style.css"), FileMode.Create);
				byte[] array = new byte[manifestResourceStream.Length + 1];
				manifestResourceStream.Read(array, 0, array.Length - 1);
				fileStream.Write(array, 0, array.Length - 1);
				fileStream.Flush();
				fileStream.Close();
				Stream? manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("RagsDesigner.Resources.html5reset.css");
				fileStream = new FileStream(Path.Combine(text2, "html5reset.css"), FileMode.Create);
				array = new byte[manifestResourceStream2.Length + 1];
				manifestResourceStream2.Read(array, 0, array.Length - 1);
				fileStream.Write(array, 0, array.Length - 1);
				fileStream.Flush();
				fileStream.Close();
				string text3 = Path.Combine(os.SelectedPath, "js");
				if (!Directory.Exists(text3))
				{
					Directory.CreateDirectory(text3);
				}
				a("Action.js", text3);
				a("Characters.js", text3);
				a("Check.js", text3);
				a("Command.js", text3);
				a("Condition.js", text3);
				a("CustomProperty.js", text3);
				a("EnhancedInputData.js", text3);
				a("Exit.js", text3);
				a("jquery-1.5.1.min.js", text3);
				a("modernizr-2.0.6.js", text3);
				a("objects.js", text3);
				a("Player.js", text3);
				a("RagsImage.js", text3);
				a("Room.js", text3);
				a("StatusBarItem.js", text3);
				a("testing.js", text3);
				a("TextHandler.js", text3);
				a("Timer.js", text3);
				a("Utilities.js", text3);
				a("Variable.js", text3);
				byte[] bytes = null;
				string text4 = "[";
				using (SqlCeConnection connection = Game.GetDBConnection())
				{
					int num = 0;
					foreach (GamePicture picture in TheGame.PictureList)
					{
						if (num > 0)
						{
							text4 += ",";
						}
						num++;
						text4 += picture.GetJSData();
						SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", connection);
						sqlCeCommand.Parameters.AddWithValue("@Name", picture.TheName);
						SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
						if (sqlCeDataReader.Read())
						{
							bytes = (byte[])sqlCeDataReader["Data"];
						}
						File.WriteAllBytes(Path.Combine(text, picture.TheName), bytes);
						sqlCeDataReader.Close();
						sqlCeDataReader.Dispose();
						sqlCeCommand.Dispose();
					}
				}
				text4 += "]";
				string text5 = TheGame.Title;
				char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
				foreach (char c2 in invalidFileNameChars)
				{
					text5 = text5.Replace(c2.ToString(), "");
				}
				File.WriteAllText(Path.Combine(os.SelectedPath, text5 + ".html"), string.Format(global::b.a, TheGame.Title));
				int num2 = 0;
				string text6 = "[";
				foreach (Room room in TheGame.RoomList)
				{
					if (num2 > 0)
					{
						text6 += ",";
					}
					num2++;
					text6 += room.GetJSData();
				}
				text6 += "]";
				string jSData = TheGame.ThePlayer.GetJSData();
				num2 = 0;
				string text7 = "[";
				foreach (Character character in TheGame.CharacterList)
				{
					if (num2 > 0)
					{
						text7 += ",";
					}
					num2++;
					text7 += character.GetJSData();
				}
				text7 += "]";
				num2 = 0;
				string text8 = "[";
				foreach (GameObject @object in TheGame.ObjectList)
				{
					if (num2 > 0)
					{
						text8 += ",";
					}
					num2++;
					text8 += @object.GetJSData();
				}
				text8 += "]";
				num2 = 0;
				string text9 = "[";
				foreach (GameVariable variable in TheGame.VariableList)
				{
					if (num2 > 0)
					{
						text9 += ",";
					}
					num2++;
					text9 += variable.GetJSData();
				}
				text9 += "]";
				num2 = 0;
				string text10 = "[";
				foreach (Rags.Timer timer in TheGame.TimerList)
				{
					if (num2 > 0)
					{
						text10 += ",";
					}
					num2++;
					text10 += timer.GetJSData();
				}
				text10 += "]";
				num2 = 0;
				string text11 = "[";
				foreach (StatusBarItem statusBarItem in TheGame.StatusBarItems)
				{
					if (num2 > 0)
					{
						text11 += ",";
					}
					num2++;
					text11 += statusBarItem.GetJSData();
				}
				text11 += "]";
				num2 = 0;
				string text12 = "[";
				foreach (string layeredClothingZone in TheGame.LayeredClothingZones)
				{
					if (num2 > 0)
					{
						text12 += ",";
					}
					num2++;
					text12 = text12 + "\"" + layeredClothingZone + "\"";
				}
				text12 += "]";
				File.WriteAllText(Path.Combine(text3, "Game.js"), global::b.c + string.Format(global::b.b, new object[19]
				{
					TheGame.Title,
					TheGame.OpeningMessage.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
						.Replace("\n", "<br>"),
					TheGame.bHideMainPicDisplay.ToString().ToLower(),
					TheGame.bUseInlineImages.ToString().ToLower(),
					TheGame.bHidePortrait.ToString().ToLower(),
					TheGame.AuthorName,
					TheGame.GameVersion,
					TheGame.GameInformation.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>"),
					TheGame.bgMusic,
					TheGame.bRepeatbgMusic.ToString().ToLower(),
					text4,
					text6,
					jSData,
					text7,
					text8,
					text9,
					text10,
					text11,
					text12
				}) + global::b.d);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}

	private void x(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm("Enter Group Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = ((Control)getNameFrm.txtEntry).Text;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from MediaGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		if (sqlCeCommand.ExecuteReader().Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		TreeNode selectedNode = nr.SelectedNode;
		if (selectedNode == null)
		{
			nr.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else if (selectedNode.Tag == null)
		{
			selectedNode.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else
		{
			TreeNode parent = selectedNode.Parent;
			if (parent == null)
			{
				nr.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
			}
			else
			{
				parent.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
				value = parent.Text;
			}
		}
		dBConnection = Game.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			g1(null, null);
			dBConnection = Game.GetDBConnection();
		}
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into MediaGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@name", empty);
		sqlCeCommand2.Parameters.AddWithValue("@parent", value);
		sqlCeCommand2.ExecuteNonQuery();
		ae();
	}

	private void w(object A_0, EventArgs A_1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (nr.SelectedNode == null || nr.SelectedNode.Tag != null || (int)MessageBox.Show("Are you sure you want to remove group " + nr.SelectedNode.Text + "?", "Delete Group Confirmation", (MessageBoxButtons)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update MediaGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (nr.SelectedNode.Parent != null)
		{
			value = nr.SelectedNode.Parent.Text;
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", nr.SelectedNode.Text);
		sqlCeCommand.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Media set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand2.Parameters.AddWithValue("@curparent", nr.SelectedNode.Text);
		sqlCeCommand2.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand3 = new SqlCeCommand("delete from MediaGroups where name=@curparent", dBConnection);
		sqlCeCommand3.Parameters.AddWithValue("@curparent", nr.SelectedNode.Text);
		sqlCeCommand3.ExecuteNonQuery();
		foreach (GamePicture picture in TheGame.PictureList)
		{
			picture.UpdatePictureGroup();
		}
		ae();
	}

	private void f(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		TreeViewHitTestInfo val = nr.HitTest(((Control)nr).PointToClient(new Point(A_1.X, A_1.Y)));
		TreeNode val2 = val.Node;
		if (val2.Tag != null)
		{
			val2 = val2.Parent;
		}
		GamePicture gamePicture = nr.SelectedNode.Tag as GamePicture;
		_ = string.Empty;
		if (gamePicture != null)
		{
			if (val.Node.Text == nr.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update media set GroupName=@Groupname\r\n                            where Name=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", val2.Text);
				sqlCeCommand.Parameters.AddWithValue("@name", gamePicture.TheName);
				sqlCeCommand.ExecuteNonQuery();
				gamePicture.GroupName = val2.Text;
			}
			else
			{
				SqlCeConnection dBConnection2 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update media set GroupName=@Groupname\r\n                            where Name=@name", dBConnection2);
				sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
				sqlCeCommand2.Parameters.AddWithValue("@name", gamePicture.TheName);
				sqlCeCommand2.ExecuteNonQuery();
				gamePicture.GroupName = string.Empty;
			}
			ae();
		}
		else
		{
			if (val2 != null && val2.Text == nr.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				if (val2.Text == nr.SelectedNode.Text)
				{
					return;
				}
				SqlCeConnection dBConnection3 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from MediaGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", val2.Text);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text = sqlCeDataReader.GetString(0);
				}
				if (text.Equals(nr.SelectedNode.Text))
				{
					SqlCeCommand sqlCeCommand4 = new SqlCeCommand("select Parent from MediaGroups where Name=@name", dBConnection3);
					sqlCeCommand4.Parameters.AddWithValue("@name", nr.SelectedNode.Text);
					sqlCeDataReader = sqlCeCommand4.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					SqlCeCommand sqlCeCommand5 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand5.Parameters.AddWithValue("@parent", value);
					sqlCeCommand5.Parameters.AddWithValue("@name", val2.Text);
					sqlCeCommand5.ExecuteNonQuery();
				}
				dBConnection3 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand6 = new SqlCeCommand("update MediaGroups set Parent=@newparent where Parent=@name\r\n                            and Name=@Parent", dBConnection3);
				sqlCeCommand6.Parameters.AddWithValue("@newparent", string.Empty);
				sqlCeCommand6.Parameters.AddWithValue("@parent", val2.Text);
				sqlCeCommand6.Parameters.AddWithValue("@name", nr.SelectedNode.Text);
				sqlCeCommand6.ExecuteNonQuery();
				SqlCeCommand sqlCeCommand7 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand7.Parameters.AddWithValue("@parent", val2.Text);
				sqlCeCommand7.Parameters.AddWithValue("@name", nr.SelectedNode.Text);
				sqlCeCommand7.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand8 = new SqlCeCommand("update MediaGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand8.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand8.Parameters.AddWithValue("@name", nr.SelectedNode.Text);
				sqlCeCommand8.ExecuteNonQuery();
			}
			ae();
		}
		if (val2 != null)
		{
			TreeNode[] array = nr.Nodes.Find(val2.Text, true);
			if (array.Length != 0)
			{
				nr.SelectedNode = array[0];
				nr.SelectedNode.Expand();
			}
		}
	}

	private void g(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			TreeViewHitTestInfo val = nr.HitTest(A_1.X, A_1.Y);
			if (val.Node != null)
			{
				nr.SelectedNode = val.Node;
			}
			this.m_m = true;
		}
	}

	private void f(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_m && nr.SelectedNode != null)
		{
			((Control)this).DoDragDrop((object)"tvNode", (DragDropEffects)(-2147483645));
		}
	}

	private void e(object A_0, DragEventArgs A_1)
	{
		A_1.Effect = (DragDropEffects)0;
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "tvNode" && nr.HitTest(((Control)nr).PointToClient(new Point(A_1.X, A_1.Y))).Node != null)
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void c(object A_0, TreeViewEventArgs A_1)
	{
		if (nr.SelectedNode != null && nr.SelectedNode.Tag != null)
		{
			object pictureByName = TheGame.GetPictureByName(nr.SelectedNode.Text);
			Image val = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val != null)
			{
				((Control)ot).Visible = false;
				((Control)this.m_bw).Visible = true;
				this.m_bw.Image = val;
			}
			else
			{
				((Control)ot).Visible = true;
				((Control)this.m_bw).Visible = false;
				ot.URL = pictureByName as string;
			}
		}
	}

	private void b(object A_0, TreeViewEventArgs A_1)
	{
		if (tvItems.SelectedNode != null && tvItems.SelectedNode.Tag != null)
		{
			GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
			((Control)ObjectActions).Enabled = true;
			if (gameObject != null)
			{
				((Control)this.m_fk).Text = gameObject.name;
				((Control)je).Text = gameObject.name;
				((Control)i8).Text = gameObject.UniqueIdentifier.ToString();
				ObjectActions.SetObjectName(gameObject.UniqueIdentifier.ToString());
				((Control)this.m_d3).Text = gameObject.name;
				((Control)this.m_dz).Text = gameObject.description;
				((Control)this.m_d1).Text = gameObject.sdesc;
				((Control)h5).Text = gameObject.preposition;
				this.m_dy.Checked = gameObject.bCarryable;
				g6.Checked = gameObject.bContainer;
				this.m_dx.Checked = gameObject.bWearable;
				this.m_dw.Checked = gameObject.bOpenable;
				((Control)this.m_dj).Enabled = gameObject.bContainer;
				this.m_dv.Checked = gameObject.bLockable;
				this.m_du.Checked = gameObject.bEnterable;
				this.m_dt.Checked = gameObject.bReadable;
				((Control)this.m_dr).Text = gameObject.dWeight.ToString();
				s();
				h();
				((Control)jd).Enabled = true;
				if (gameObject.bVisible)
				{
					hi.Checked = true;
				}
				else
				{
					hh.Checked = true;
				}
				if (gameObject.bOpen)
				{
					this.m_dq.Checked = true;
				}
				else
				{
					this.m_dp.Checked = true;
				}
				if (gameObject.bLocked)
				{
					this.m_dn.Checked = true;
				}
				else
				{
					this.m_dm.Checked = true;
				}
				if (gameObject.bWorn)
				{
					this.m_e0.Checked = true;
				}
				else
				{
					this.m_ez.Checked = true;
				}
				oa.Checked = gameObject.bImportant;
				((Control)this.m_dz).Enabled = true;
				((Control)this.m_d3).Enabled = true;
				((Control)this.m_d1).Enabled = true;
				ObjectActions.RefreshActions();
				f();
			}
		}
		else
		{
			((Control)jd).Enabled = false;
			((Control)this.m_dz).Enabled = false;
			((Control)this.m_d3).Enabled = false;
			((Control)this.m_d1).Enabled = false;
			((Control)ObjectActions).Enabled = false;
		}
	}

	private void d(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		TreeViewHitTestInfo val = tvItems.HitTest(((Control)tvItems).PointToClient(new Point(A_1.X, A_1.Y)));
		TreeNode val2 = val.Node;
		if (val2.Tag != null)
		{
			val2 = val2.Parent;
		}
		GameObject gameObject = tvItems.SelectedNode.Tag as GameObject;
		_ = string.Empty;
		if (gameObject != null)
		{
			if (val.Node.Text == tvItems.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update Items set GroupName=@Groupname\r\n                            where UniqueID=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", val2.Text);
				sqlCeCommand.Parameters.AddWithValue("@name", gameObject.UniqueIdentifier.ToString());
				sqlCeCommand.ExecuteNonQuery();
				gameObject.GroupName = val2.Text;
			}
			else
			{
				SqlCeConnection dBConnection2 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Items set GroupName=@Groupname\r\n                            where UniqueID=@name", dBConnection2);
				sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
				sqlCeCommand2.Parameters.AddWithValue("@name", gameObject.UniqueIdentifier.ToString());
				sqlCeCommand2.ExecuteNonQuery();
				gameObject.GroupName = string.Empty;
			}
			al();
		}
		else
		{
			if (val2 != null && val2.Text == tvItems.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				SqlCeConnection dBConnection3 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from ItemGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", val2.Text);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text = sqlCeDataReader.GetString(0);
				}
				if (text.Equals(tvItems.SelectedNode.Text))
				{
					SqlCeCommand sqlCeCommand4 = new SqlCeCommand("select Parent from ItemGroups where Name=@name", dBConnection3);
					sqlCeCommand4.Parameters.AddWithValue("@name", tvItems.SelectedNode.Text);
					sqlCeDataReader = sqlCeCommand4.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					SqlCeCommand sqlCeCommand5 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand5.Parameters.AddWithValue("@parent", value);
					sqlCeCommand5.Parameters.AddWithValue("@name", val2.Text);
					sqlCeCommand5.ExecuteNonQuery();
				}
				SqlCeCommand sqlCeCommand6 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand6.Parameters.AddWithValue("@parent", val2.Text);
				sqlCeCommand6.Parameters.AddWithValue("@name", tvItems.SelectedNode.Text);
				sqlCeCommand6.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand7 = new SqlCeCommand("update ItemGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand7.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand7.Parameters.AddWithValue("@name", tvItems.SelectedNode.Text);
				sqlCeCommand7.ExecuteNonQuery();
			}
			al();
		}
		if (val2 != null)
		{
			TreeNode[] array = tvItems.Nodes.Find(val2.Text, true);
			if (array.Length != 0)
			{
				tvItems.SelectedNode = array[0];
				tvItems.SelectedNode.Expand();
			}
		}
	}

	private void c(object A_0, DragEventArgs A_1)
	{
		A_1.Effect = (DragDropEffects)0;
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "tvItems" && tvItems.HitTest(((Control)tvItems).PointToClient(new Point(A_1.X, A_1.Y))).Node != null)
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void e(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			TreeViewHitTestInfo val = tvItems.HitTest(A_1.X, A_1.Y);
			if (val.Node != null)
			{
				tvItems.SelectedNode = val.Node;
			}
			this.m_m = true;
		}
	}

	private void d(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_m && tvItems.SelectedNode != null)
		{
			((Control)this).DoDragDrop((object)"tvItems", (DragDropEffects)(-2147483645));
		}
	}

	private void v(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm("Enter Group Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		if (Game.DBName == string.Empty)
		{
			MessageBox.Show("The game will now be saved to create your item repository.");
			while (Game.DBName == string.Empty)
			{
				g1(null, null);
				if (Game.DBName == string.Empty)
				{
					MessageBox.Show("Item insertion cancelled.");
					return;
				}
			}
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = ((Control)getNameFrm.txtEntry).Text;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from ItemGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		if (sqlCeCommand.ExecuteReader().Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		TreeNode selectedNode = tvItems.SelectedNode;
		if (selectedNode == null)
		{
			tvItems.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else if (selectedNode.Tag == null)
		{
			selectedNode.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else
		{
			TreeNode parent = selectedNode.Parent;
			if (parent == null)
			{
				tvItems.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
			}
			else
			{
				parent.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
				value = parent.Text;
			}
		}
		dBConnection = Game.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			g1(null, null);
			dBConnection = Game.GetDBConnection();
		}
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into ItemGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@name", empty);
		sqlCeCommand2.Parameters.AddWithValue("@parent", value);
		sqlCeCommand2.ExecuteNonQuery();
		al();
	}

	private void u(object A_0, EventArgs A_1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (tvItems.SelectedNode == null || tvItems.SelectedNode.Tag != null || (int)MessageBox.Show("Are you sure you want to remove group " + tvItems.SelectedNode.Text + "?", "Delete Group Confirmation", (MessageBoxButtons)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update ItemGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (tvItems.SelectedNode.Parent != null)
		{
			value = tvItems.SelectedNode.Parent.Text;
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", tvItems.SelectedNode.Text);
		sqlCeCommand.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Items set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand2.Parameters.AddWithValue("@curparent", tvItems.SelectedNode.Text);
		sqlCeCommand2.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand3 = new SqlCeCommand("delete from ItemGroups where name=@curparent", dBConnection);
		sqlCeCommand3.Parameters.AddWithValue("@curparent", tvItems.SelectedNode.Text);
		sqlCeCommand3.ExecuteNonQuery();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			@object.UpdateGroupName();
		}
		al();
	}

	private void t(object A_0, EventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Form)this).WindowState == 0)
		{
			Settings.Default.Location = ((Form)this).Location;
		}
	}

	private void s(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Settings.Default.State = ((Form)this).WindowState;
		if ((int)((Form)this).WindowState == 0)
		{
			Settings.Default.Size = ((Form)this).Size;
		}
	}

	private void r(object A_0, EventArgs A_1)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		((Form)new CommandConditionFilter(ref TheGame)).ShowDialog();
		Command.PopulateComboWithCommands(RoomActions.cbCommandStep1, bFilter: true);
		Condition.PopulateComboWithConditions(RoomActions.cbConditionStep1, bFilter: true);
		Command.PopulateComboWithCommands(PlayerActions.cbCommandStep1, bFilter: true);
		Condition.PopulateComboWithConditions(PlayerActions.cbConditionStep1, bFilter: true);
		Command.PopulateComboWithCommands(ObjectActions.cbCommandStep1, bFilter: true);
		Condition.PopulateComboWithConditions(ObjectActions.cbConditionStep1, bFilter: true);
		Command.PopulateComboWithCommands(TimerActions.cbCommandStep1, bFilter: true);
		Condition.PopulateComboWithConditions(TimerActions.cbConditionStep1, bFilter: true);
	}

	private void q(object A_0, EventArgs A_1)
	{
		((Control)new SearchForm(this)).Show();
	}

	private void p(object A_0, EventArgs A_1)
	{
		TheGame.bTurnOffNotifications = n2.Checked;
	}

	private void o(object A_0, EventArgs A_1)
	{
		TheGame.SortOrderRoomObjects = (Game.SortOrder)((ListControl)n5).SelectedIndex;
	}

	private void n(object A_0, EventArgs A_1)
	{
		TheGame.SortOrderCharacters = (Game.SortOrder)((ListControl)n9).SelectedIndex;
	}

	private void m(object A_0, EventArgs A_1)
	{
		TheGame.SortOrderInventory = (Game.SortOrder)((ListControl)n7).SelectedIndex;
	}

	private void l(object A_0, EventArgs A_1)
	{
		if (tvItems.SelectedNode != null)
		{
			((GameObject)tvItems.SelectedNode.Tag).bImportant = oa.Checked;
		}
	}

	private void k(object A_0, EventArgs A_1)
	{
		StatusBarItem statusBarItemByName = TheGame.GetStatusBarItemByName(this.m_gm.SelectedItem.ToString());
		if (statusBarItemByName != null)
		{
			statusBarItemByName.bVisisble = ob.Checked;
		}
	}

	private void a(object A_0, DataGridViewCellEventArgs A_1)
	{
	}

	private void b(object A_0, DragEventArgs A_1)
	{
		if (!A_1.Data.GetDataPresent(DataFormats.StringFormat))
		{
			return;
		}
		_ = (string)A_1.Data.GetData(DataFormats.StringFormat);
		TreeViewHitTestInfo val = tvVariables.HitTest(((Control)tvVariables).PointToClient(new Point(A_1.X, A_1.Y)));
		TreeNode val2 = val.Node;
		if (val2.Tag != null)
		{
			val2 = val2.Parent;
		}
		GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
		_ = string.Empty;
		if (gameVariable != null)
		{
			if (val.Node.Text == tvVariables.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				SqlCeConnection dBConnection = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("update Variables set GroupName=@Groupname\r\n                            where VarName=@name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Groupname", val2.Text);
				sqlCeCommand.Parameters.AddWithValue("@name", gameVariable.varname.ToString());
				sqlCeCommand.ExecuteNonQuery();
				gameVariable.GroupName = val2.Text;
			}
			else
			{
				SqlCeConnection dBConnection2 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Variables set GroupName=@Groupname\r\n                            where VarName=@name", dBConnection2);
				sqlCeCommand2.Parameters.AddWithValue("@Groupname", string.Empty);
				sqlCeCommand2.Parameters.AddWithValue("@name", gameVariable.varname.ToString());
				sqlCeCommand2.ExecuteNonQuery();
				gameVariable.GroupName = string.Empty;
			}
			x();
		}
		else
		{
			if (val2 != null && val2.Text == tvVariables.SelectedNode.Text)
			{
				return;
			}
			if (val2 != null)
			{
				SqlCeConnection dBConnection3 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand3 = new SqlCeCommand("select Parent from VariableGroups where Name=@name", dBConnection3);
				sqlCeCommand3.Parameters.AddWithValue("@name", val2.Text);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand3.ExecuteReader();
				string text = string.Empty;
				if (sqlCeDataReader.Read())
				{
					text = sqlCeDataReader.GetString(0);
				}
				if (text.Equals(tvVariables.SelectedNode.Text))
				{
					SqlCeCommand sqlCeCommand4 = new SqlCeCommand("select Parent from VariableGroups where Name=@name", dBConnection3);
					sqlCeCommand4.Parameters.AddWithValue("@name", tvVariables.SelectedNode.Text);
					sqlCeDataReader = sqlCeCommand4.ExecuteReader();
					string value = string.Empty;
					if (sqlCeDataReader.Read())
					{
						value = sqlCeDataReader.GetString(0);
					}
					SqlCeCommand sqlCeCommand5 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
					sqlCeCommand5.Parameters.AddWithValue("@parent", value);
					sqlCeCommand5.Parameters.AddWithValue("@name", val2.Text);
					sqlCeCommand5.ExecuteNonQuery();
				}
				dBConnection3 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand6 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection3);
				sqlCeCommand6.Parameters.AddWithValue("@parent", val2.Text);
				sqlCeCommand6.Parameters.AddWithValue("@name", tvVariables.SelectedNode.Text);
				sqlCeCommand6.ExecuteNonQuery();
			}
			else
			{
				SqlCeConnection dBConnection4 = Game.GetDBConnection();
				SqlCeCommand sqlCeCommand7 = new SqlCeCommand("update VariableGroups set Parent=@Parent\r\n                            where Name=@name", dBConnection4);
				sqlCeCommand7.Parameters.AddWithValue("@Parent", string.Empty);
				sqlCeCommand7.Parameters.AddWithValue("@name", tvVariables.SelectedNode.Text);
				sqlCeCommand7.ExecuteNonQuery();
			}
			x();
		}
		if (val2 != null)
		{
			TreeNode[] array = tvVariables.Nodes.Find(val2.Text, true);
			if (array.Length != 0)
			{
				tvVariables.SelectedNode = array[0];
				tvVariables.SelectedNode.Expand();
			}
		}
	}

	private void a(object A_0, DragEventArgs A_1)
	{
		A_1.Effect = (DragDropEffects)0;
		if (A_1.Data.GetDataPresent(DataFormats.StringFormat) && (string)A_1.Data.GetData(DataFormats.StringFormat) == "tvVariables" && tvVariables.HitTest(((Control)tvVariables).PointToClient(new Point(A_1.X, A_1.Y))).Node != null)
		{
			A_1.Effect = (DragDropEffects)(-2147483645);
		}
	}

	private void c(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)A_1.Button == 1048576)
		{
			TreeViewHitTestInfo val = tvVariables.HitTest(A_1.X, A_1.Y);
			if (val.Node != null)
			{
				tvVariables.SelectedNode = val.Node;
			}
			this.m_m = true;
		}
	}

	private void b(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button == 1048576 && this.m_m && tvVariables.SelectedNode != null)
		{
			((Control)this).DoDragDrop((object)"tvVariables", (DragDropEffects)(-2147483645));
		}
	}

	private void j(object A_0, EventArgs A_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		GetNameFrm getNameFrm = new GetNameFrm("Enter Group Name:");
		if ((int)((Form)getNameFrm).ShowDialog() != 1)
		{
			return;
		}
		if (Game.DBName == string.Empty)
		{
			MessageBox.Show("The game will now be saved to create your item repository.");
			while (Game.DBName == string.Empty)
			{
				g1(null, null);
				if (Game.DBName == string.Empty)
				{
					MessageBox.Show("Variable insertion cancelled.");
					return;
				}
			}
		}
		string empty = string.Empty;
		string value = string.Empty;
		empty = ((Control)getNameFrm.txtEntry).Text;
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from VariableGroups\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", empty);
		if (sqlCeCommand.ExecuteReader().Read())
		{
			MessageBox.Show("Sorry, a group with that name already exists.  Please use a different name.");
			return;
		}
		TreeNode selectedNode = tvVariables.SelectedNode;
		if (selectedNode == null)
		{
			tvVariables.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else if (selectedNode.Tag == null)
		{
			selectedNode.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
		}
		else
		{
			TreeNode parent = selectedNode.Parent;
			if (parent == null)
			{
				tvVariables.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
			}
			else
			{
				parent.Nodes.Add(((Control)getNameFrm.txtEntry).Text, ((Control)getNameFrm.txtEntry).Text, 3, 3);
				value = parent.Text;
			}
		}
		dBConnection = Game.GetDBConnection();
		if (dBConnection == null)
		{
			MessageBox.Show("The game must be created before we can proceed.  Please select a filename.");
			g1(null, null);
			dBConnection = Game.GetDBConnection();
		}
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("insert into VariableGroups (Name,Parent)\r\n                            values (@name,@parent)", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@name", empty);
		sqlCeCommand2.Parameters.AddWithValue("@parent", value);
		sqlCeCommand2.ExecuteNonQuery();
		x();
	}

	private void i(object A_0, EventArgs A_1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		if (tvVariables.SelectedNode == null || tvVariables.SelectedNode.Tag != null || (int)MessageBox.Show("Are you sure you want to remove group " + tvVariables.SelectedNode.Text + "?", "Delete Group Confirmation", (MessageBoxButtons)4) != 6)
		{
			return;
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update VariableGroups set Parent=@newparent\r\n                        where Parent=@curparent", dBConnection);
		string value = string.Empty;
		if (tvVariables.SelectedNode.Parent != null)
		{
			value = tvVariables.SelectedNode.Parent.Text;
		}
		sqlCeCommand.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand.Parameters.AddWithValue("@curparent", tvVariables.SelectedNode.Text);
		sqlCeCommand.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("update Variables set GroupName=@newparent\r\n                        where GroupName=@curparent", dBConnection);
		sqlCeCommand2.Parameters.AddWithValue("@newparent", value);
		sqlCeCommand2.Parameters.AddWithValue("@curparent", tvVariables.SelectedNode.Text);
		sqlCeCommand2.ExecuteNonQuery();
		SqlCeCommand sqlCeCommand3 = new SqlCeCommand("delete from VariableGroups where name=@curparent", dBConnection);
		sqlCeCommand3.Parameters.AddWithValue("@curparent", tvVariables.SelectedNode.Text);
		sqlCeCommand3.ExecuteNonQuery();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			variable.UpdateGroupName();
		}
		x();
	}

	private void h(object A_0, EventArgs A_1)
	{
		fb(null, null);
	}

	private void g(object A_0, EventArgs A_1)
	{
		em(null, null);
	}

	private void a(object A_0, TreeViewEventArgs A_1)
	{
		h3.Items.Clear();
		if (tvVariables.SelectedNode.Tag != null)
		{
			iz.CheckedChanged -= b6;
			((Control)this.m_cq).Text = "";
			iz.Checked = false;
			iz.CheckedChanged += b6;
			((Control)this.m_cp).Enabled = true;
			((Control)this.m_ck).Enabled = true;
			GameVariable gameVariable = tvVariables.SelectedNode.Tag as GameVariable;
			((Control)i7).Text = gameVariable.VarComment;
			((Control)this.m_co).Text = gameVariable.varname;
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_STRING:
				this.m_cl.Checked = true;
				((Control)this.m_cq).Text = gameVariable.sString;
				((Control)this.m_cq).Visible = true;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_STRINGARRAY:
				hy.Checked = true;
				((Control)this.m_cq).Text = gameVariable.sString;
				((Control)this.m_cq).Visible = true;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				n();
				break;
			case GameVariable.VarType.VT_NUMBER:
				this.m_cm.Checked = true;
				((Control)hc).Text = gameVariable.dNumType.ToString();
				hr.Checked = gameVariable.bEnforceRestrictions;
				cu(null, null);
				((Control)ha).Text = gameVariable.dMin.ToString();
				((Control)g8).Text = gameVariable.dMax.ToString();
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = true;
				((Control)hc).Visible = true;
				((Control)g7).Visible = true;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_NUMBERARRAY:
				hz.Checked = true;
				((Control)hc).Text = gameVariable.dNumType.ToString();
				hr.Checked = gameVariable.bEnforceRestrictions;
				cu(null, null);
				((Control)ha).Text = gameVariable.dMin.ToString();
				((Control)g8).Text = gameVariable.dMax.ToString();
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = false;
				((Control)hd).Visible = true;
				((Control)hc).Visible = true;
				((Control)g7).Visible = true;
				n();
				break;
			case GameVariable.VarType.VT_DATETIME:
				this.m_gy.Checked = true;
				this.m_gx.Value = gameVariable.dtDateTime;
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = true;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				((Control)iy).Visible = false;
				((Control)h3).Visible = true;
				break;
			case GameVariable.VarType.VT_DATETIMEARRAY:
				hx.Checked = true;
				this.m_gx.Value = gameVariable.dtDateTime;
				((Control)this.m_cq).Visible = false;
				((Control)this.m_gx).Visible = true;
				((Control)hd).Visible = false;
				((Control)hc).Visible = false;
				((Control)g7).Visible = false;
				n();
				break;
			}
			d();
		}
		else
		{
			((Control)this.m_co).Text = "";
			((Control)this.m_cq).Text = "";
			((Control)this.m_cp).Enabled = false;
			((Control)this.m_ck).Enabled = false;
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		DataGridViewRow val = iy.SelectedRows[0];
		if (val != null)
		{
			_ = ((DataGridViewBand)val).Index;
			if (!val.IsNewRow)
			{
				_ = tvVariables.SelectedNode.Tag;
				iy.Rows.Remove(val);
				n();
			}
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		DataGridViewRow val = iy.SelectedRows[0];
		if (val != null)
		{
			int index = ((DataGridViewBand)val).Index;
			ArrayList arrayList = null;
			GameVariable obj = tvVariables.SelectedNode.Tag as GameVariable;
			obj.VarArray.Insert(index, new ArrayList());
			arrayList = (ArrayList)obj.VarArray[index];
			for (int i = 0; i < ((BaseCollection)iy.Columns).Count; i++)
			{
				arrayList.Add("");
			}
			((DataGridViewCell)iy.Rows[index].HeaderCell).Value = ((DataGridViewBand)iy.Rows[index]).Index.ToString("###");
			n();
		}
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Button != 2097152)
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)iy.Rows)
		{
			((DataGridViewBand)item).Selected = false;
		}
		HitTestInfo val = iy.HitTest(A_1.X, A_1.Y);
		if (val != null && val.RowIndex != -1)
		{
			((DataGridViewBand)iy.Rows[val.RowIndex]).Selected = true;
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Cursor.Current = Cursors.WaitCursor;
			Game.GetDBConnection().Close();
			if (File.Exists(this.m_n + ".bak"))
			{
				File.Delete(this.m_n + ".bak");
			}
			File.Move(this.m_n, this.m_n + ".bak");
			using SqlCeEngine sqlCeEngine = new SqlCeEngine("DataSource=" + this.m_n + ".bak;Password=" + EncDec.RagsZone("F1$asDDFHappy"));
			sqlCeEngine.Compact("DataSource=" + this.m_n + ";Password=" + EncDec.RagsZone("F1$asDDFHappy") + ";encrypt database=TRUE");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)((Form)new AutoSaveSettingsFrm()).ShowDialog() == 1)
		{
			a();
		}
	}

	private void a()
	{
		on.Enabled = bUseAutoSave;
		on.Interval = iAutoSaveMinutes * 60000;
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (TheGame != null)
		{
			g1(null, null);
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		if (op.SelectedItem.ToString() == "None")
		{
			((Control)or).Tag = null;
			((Control)or).BackgroundImage = null;
			((Control)or).Invalidate();
			Character character = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
			if (character != null)
			{
				character.CharPortrait = "";
			}
			return;
		}
		Character character2 = (Character)((DataGridViewBand)dgvCharacters.SelectedRows[0]).Tag;
		if (character2 != null)
		{
			character2.CharPortrait = op.SelectedItem.ToString();
			object pictureByName = TheGame.GetPictureByName(op.SelectedItem.ToString());
			Image val = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val != null)
			{
				((Control)or).Visible = true;
				((Control)or).Tag = TheGame.GetGamePictureByName(op.SelectedItem.ToString());
				((Control)or).BackgroundImage = val;
			}
		}
	}

	static Form1()
	{
		Form1.m_d = false;
		Form1.m_e = false;
		bUseAutoSave = false;
		iAutoSaveMinutes = 5;
		TheGame = new Game();
		ObjectLibrary = new ArrayList();
	}
}
