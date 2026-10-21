using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Rags.ragsgame.com;

namespace Rags;

public class RagsShare : Form
{
	private static bool m_a;

	private IContainer m_b;

	private TabControl m_c;

	private TabPage m_d;

	private TabPage m_e;

	private WebBrowser m_f;

	private SplitContainer m_g;

	private Label h;

	private DataGridView i;

	private Label j;

	private TextBox k;

	private Label l;

	private TextBox m;

	private Label n;

	private Button o;

	private Button p;

	private Button q;

	private RichTextBox r;

	private Label s;

	private Label t;

	private SaveFileDialog u;

	private Label v;

	private Label w;

	private TextBox x;

	private Label y;

	private Label z;

	private Label aa;

	private Button ab;

	private TextBox ac;

	private DataGridViewTextBoxColumn ad;

	private DataGridViewTextBoxColumn ae;

	private DataGridViewTextBoxColumn af;

	private DataGridViewTextBoxColumn ag;

	private DataGridViewTextBoxColumn ah;

	private DataGridViewCheckBoxColumn ai;

	private DataGridViewTextBoxColumn aj;

	private Label ak;

	private ProgressBar al;

	private Timer am;

	public RagsShare()
	{
		a();
	}

	private void g(object A_0, EventArgs A_1)
	{
		b();
		RagsShare.m_a = false;
	}

	private void a(object A_0, GetShareDataSummaryCompletedEventArgs A_1)
	{
		this.i.Rows.Clear();
		if (A_1.Error != null)
		{
			this.i.Rows.Add(new object[1] { "Error:" + A_1.Error.Message });
			return;
		}
		if (A_1.Result == null)
		{
			this.i.Rows.Add(new object[1] { "Unable to contact the service.  Try again later." });
			return;
		}
		object[] result = A_1.Result;
		for (int i = 0; i < result.Length; i++)
		{
			Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)result[i];
			int num = this.i.Rows.Add(new object[7] { shareData.sharename, shareData.category, shareData.downloads, shareData.lastupdated, shareData.usernickname, shareData.bexplicit, shareData.RagsVersion });
			((DataGridViewBand)this.i.Rows[num]).Tag = shareData;
		}
		if (!RagsShare.m_a)
		{
			RagsShare.m_a = true;
			this.i.Sort(this.i.Columns[3], ListSortDirection.Descending);
		}
	}

	private void b()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		CheckUpdates checkUpdates = new CheckUpdates();
		try
		{
			checkUpdates.GetShareDataSummaryCompleted += a;
			checkUpdates.GetShareDataSummaryAsync();
		}
		catch
		{
			MessageBox.Show("Unable to connect with the RAGS Share service.  Please try again later.");
		}
		((Component)(object)checkUpdates).Dispose();
		d(null, null);
	}

	private void f(object A_0, EventArgs A_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (LockData.IsLicensed(bdisplay: false, "åòçê²µÀÅÒç¹\u00b8»ÍÊÍÊ»»»ÍÊËËÉ\u00a0¢¥"))
		{
			((Form)new RagsShareUpload(Update: false, null)).ShowDialog();
			b();
		}
		else
		{
			MessageBox.Show("Sorry, this feature is only available to registered RAGS users.");
		}
	}

	private void a(object A_0, DownloadShareCompletedEventArgs A_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		((Control)al).Enabled = false;
		if (A_1.Error != null)
		{
			MessageBox.Show("Download error: " + A_1.Error.Message);
			return;
		}
		if (A_1.Result == null)
		{
			MessageBox.Show("Unable to contact the service.  Try again later.");
			return;
		}
		byte[] result = A_1.Result;
		File.WriteAllBytes(A_1.UserState.ToString(), result);
		b();
		MessageBox.Show("Download successful.");
	}

	private void e(object A_0, EventArgs A_1)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		if (((BaseCollection)i.SelectedRows).Count == 1 && (int)MessageBox.Show("Rags LLC can not be held responsible for the content on the RAGS Share service.\r\nRags share files are publicly uploaded as a means to share information and coding tips.\r\nEvery effort has been made to insure no malicious software is uploaded to the RAGS share service, \r\nbut please take the necessary precautions to insure the files are scanned locally.  If interested, you can download \r\na free virus scanner from AVG.  If there is a problem with any content on the RAGS Share service, please\r\ninform me Steve@RagsGame.com as soon as possible.\r\nDo you agree to the terms of this disclaimer?", "Content Disclaimer", (MessageBoxButtons)4) == 6)
		{
			Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)i.SelectedRows[0]).Tag;
			((FileDialog)u).FileName = shareData.sharename + ".rag";
			if ((int)((CommonDialog)u).ShowDialog() == 1)
			{
				CheckUpdates checkUpdates = new CheckUpdates();
				checkUpdates.DownloadShareCompleted += a;
				checkUpdates.DownloadShareAsync(shareData.index, ((FileDialog)u).FileName);
				((Control)al).Enabled = true;
			}
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)i.SelectedRows).Count <= 0)
		{
			return;
		}
		Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)i.SelectedRows[0]).Tag;
		if (shareData != null)
		{
			((Control)m).Text = shareData.sharename;
			((Control)k).Text = shareData.usernickname;
			((Control)ac).Text = shareData.category;
			((Control)r).Text = shareData.description;
			((Control)v).Text = shareData.downloads.ToString();
			((Control)x).Text = shareData.lastupdated.ToString();
			((Control)z).Text = shareData.size / 1024 + " kb";
			if (shareData.useremail == LockData.GetEmail())
			{
				((Control)ab).Enabled = true;
				((Control)o).Enabled = true;
			}
			else
			{
				((Control)ab).Enabled = false;
				((Control)o).Enabled = false;
			}
			if (shareData.bexplicit)
			{
				((Control)t).Visible = true;
			}
			else
			{
				((Control)t).Visible = false;
			}
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		if (((BaseCollection)i.SelectedRows).Count > 0)
		{
			Rags.ragsgame.com.ShareData shareData = (Rags.ragsgame.com.ShareData)((DataGridViewBand)i.SelectedRows[0]).Tag;
			new CheckUpdates().RemoveShare(shareData.index, LockData.GetEmail(), LockData.GetKey());
			b();
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (LockData.IsLicensed(bdisplay: false, "åòçê²µÀÅÒç¹\u00b8»ÍÊÍÊ»»»ÍÊËËÉ\u00a0¢¥"))
		{
			((Form)new RagsShareUpload(Update: true, (Rags.ragsgame.com.ShareData)((DataGridViewBand)i.SelectedRows[0]).Tag)).ShowDialog();
			b();
		}
		else
		{
			MessageBox.Show("Sorry, this feature is only available to registered RAGS users.");
		}
	}

	private void a(object A_0, LinkClickedEventArgs A_1)
	{
		Process.Start(A_1.LinkText);
	}

	private void a(object A_0, EventArgs A_1)
	{
		if (((Control)al).Enabled)
		{
			if (al.Value == 100)
			{
				al.Value = 1;
			}
			al.Increment(1);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_b != null)
		{
			this.m_b.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
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
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Obj, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected Obj, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Obj, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected Obj, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected Obj, but got Unknown
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected Obj, but got Unknown
		//IL_0fc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcc: Expected Obj, but got Unknown
		//IL_145d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1467: Expected Obj, but got Unknown
		this.m_b = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsShare));
		this.m_c = new TabControl();
		this.m_d = new TabPage();
		this.m_f = new WebBrowser();
		this.m_e = new TabPage();
		this.m_g = new SplitContainer();
		h = new Label();
		i = new DataGridView();
		ad = new DataGridViewTextBoxColumn();
		ae = new DataGridViewTextBoxColumn();
		af = new DataGridViewTextBoxColumn();
		ag = new DataGridViewTextBoxColumn();
		ah = new DataGridViewTextBoxColumn();
		ai = new DataGridViewCheckBoxColumn();
		aj = new DataGridViewTextBoxColumn();
		ak = new Label();
		al = new ProgressBar();
		ab = new Button();
		z = new Label();
		aa = new Label();
		v = new Label();
		w = new Label();
		x = new TextBox();
		y = new Label();
		r = new RichTextBox();
		s = new Label();
		t = new Label();
		ac = new TextBox();
		j = new Label();
		k = new TextBox();
		l = new Label();
		m = new TextBox();
		n = new Label();
		o = new Button();
		p = new Button();
		q = new Button();
		u = new SaveFileDialog();
		am = new Timer(this.m_b);
		((Control)this.m_c).SuspendLayout();
		((Control)this.m_d).SuspendLayout();
		((Control)this.m_e).SuspendLayout();
		((Control)this.m_g.Panel1).SuspendLayout();
		((Control)this.m_g.Panel2).SuspendLayout();
		((Control)this.m_g).SuspendLayout();
		((ISupportInitialize)i).BeginInit();
		((Control)this).SuspendLayout();
		this.m_c.Alignment = (TabAlignment)1;
		((Control)this.m_c).Controls.Add((Control)(object)this.m_d);
		((Control)this.m_c).Controls.Add((Control)(object)this.m_e);
		((Control)this.m_c).Dock = (DockStyle)5;
		((Control)this.m_c).Location = new Point(0, 0);
		((Control)this.m_c).Name = "tabControl1";
		this.m_c.SelectedIndex = 0;
		((Control)this.m_c).Size = new Size(747, 498);
		((Control)this.m_c).TabIndex = 0;
		((Control)this.m_d).Controls.Add((Control)(object)this.m_f);
		this.m_d.Location = new Point(4, 4);
		((Control)this.m_d).Name = "tabPage1";
		((Control)this.m_d).Padding = new Padding(3);
		((Control)this.m_d).Size = new Size(739, 472);
		this.m_d.TabIndex = 0;
		((Control)this.m_d).Text = "Rags News";
		this.m_d.UseVisualStyleBackColor = true;
		((Control)this.m_f).Dock = (DockStyle)5;
		((Control)this.m_f).Location = new Point(3, 3);
		((Control)this.m_f).MinimumSize = new Size(20, 20);
		((Control)this.m_f).Name = "webBrowser1";
		((Control)this.m_f).Size = new Size(733, 466);
		((Control)this.m_f).TabIndex = 0;
		this.m_f.Url = new Uri("http://www.ragsgame.com/RagsNews.aspx", UriKind.Absolute);
		((Control)this.m_e).Controls.Add((Control)(object)this.m_g);
		this.m_e.Location = new Point(4, 4);
		((Control)this.m_e).Name = "tabPage2";
		((Control)this.m_e).Padding = new Padding(3);
		((Control)this.m_e).Size = new Size(739, 472);
		this.m_e.TabIndex = 1;
		((Control)this.m_e).Text = "Rags Share";
		this.m_e.UseVisualStyleBackColor = true;
		this.m_g.BorderStyle = (BorderStyle)1;
		this.m_g.Dock = (DockStyle)5;
		((Control)this.m_g).Location = new Point(3, 3);
		((Control)this.m_g).Name = "splitContainer1";
		this.m_g.Orientation = (Orientation)0;
		((Control)this.m_g.Panel1).Controls.Add((Control)(object)h);
		((Control)this.m_g.Panel1).Controls.Add((Control)(object)i);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)ak);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)al);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)ab);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)z);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)aa);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)v);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)w);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)x);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)y);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)r);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)s);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)t);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)ac);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)j);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)k);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)l);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)m);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)n);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)o);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)p);
		((Control)this.m_g.Panel2).Controls.Add((Control)(object)q);
		((Control)this.m_g).Size = new Size(733, 466);
		this.m_g.SplitterDistance = 248;
		((Control)this.m_g).TabIndex = 0;
		((Control)h).AutoSize = true;
		((Control)h).Location = new Point(4, 4);
		((Control)h).Name = "lblRagsShare";
		((Control)h).Size = new Size(71, 13);
		((Control)h).TabIndex = 1;
		((Control)h).Text = "Rags Shares:";
		i.AllowUserToAddRows = false;
		i.AllowUserToDeleteRows = false;
		((Control)i).Anchor = (AnchorStyles)15;
		i.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		i.Columns.AddRange(new DataGridViewColumn[7]
		{
			(DataGridViewColumn)ad,
			(DataGridViewColumn)ae,
			(DataGridViewColumn)af,
			(DataGridViewColumn)ag,
			(DataGridViewColumn)ah,
			(DataGridViewColumn)ai,
			(DataGridViewColumn)aj
		});
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Window;
		val.Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.ControlText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)2;
		i.DefaultCellStyle = val;
		((Control)i).Location = new Point(0, 23);
		i.MultiSelect = false;
		((Control)i).Name = "dataGridView1";
		i.ReadOnly = true;
		i.RowHeadersWidth = 4;
		i.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)i).Size = new Size(728, 223);
		((Control)i).TabIndex = 0;
		i.SelectionChanged += d;
		((DataGridViewColumn)ad).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ad).FillWeight = 20f;
		((DataGridViewColumn)ad).HeaderText = "Name";
		((DataGridViewColumn)ad).Name = "ShareName";
		((DataGridViewBand)ad).ReadOnly = true;
		((DataGridViewColumn)ad).Width = 60;
		((DataGridViewColumn)ae).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ae).FillWeight = 25f;
		((DataGridViewColumn)ae).HeaderText = "Category";
		((DataGridViewColumn)ae).Name = "Column1";
		((DataGridViewBand)ae).ReadOnly = true;
		((DataGridViewColumn)ae).Width = 74;
		((DataGridViewColumn)af).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)af).FillWeight = 17f;
		((DataGridViewColumn)af).HeaderText = "Downloads";
		((DataGridViewColumn)af).Name = "ShareDownloads";
		((DataGridViewBand)af).ReadOnly = true;
		((DataGridViewColumn)af).Width = 85;
		((DataGridViewColumn)ag).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ag).FillWeight = 33f;
		((DataGridViewColumn)ag).HeaderText = "Updated";
		((DataGridViewColumn)ag).Name = "sharedateupdated";
		((DataGridViewBand)ag).ReadOnly = true;
		((DataGridViewColumn)ag).Width = 73;
		((DataGridViewColumn)ah).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ah).HeaderText = "User";
		((DataGridViewColumn)ah).Name = "dgvUser";
		((DataGridViewBand)ah).ReadOnly = true;
		((DataGridViewColumn)ah).Width = 54;
		((DataGridViewColumn)ai).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ai).HeaderText = "Explicit";
		((DataGridViewColumn)ai).Name = "dgvExplicit";
		((DataGridViewBand)ai).ReadOnly = true;
		((DataGridViewColumn)ai).Width = 46;
		((DataGridViewColumn)aj).HeaderText = "RagsVersion";
		((DataGridViewColumn)aj).Name = "dgvragsver";
		((DataGridViewBand)aj).ReadOnly = true;
		((Control)ak).AutoSize = true;
		((Control)ak).Location = new Point(253, 191);
		((Control)ak).Name = "label7";
		((Control)ak).Size = new Size(72, 13);
		((Control)ak).TabIndex = 20;
		((Control)ak).Text = "Downloading:";
		((Control)al).Anchor = (AnchorStyles)13;
		((Control)al).Enabled = false;
		((Control)al).Location = new Point(331, 186);
		((Control)al).Name = "progressBar1";
		((Control)al).Size = new Size(299, 23);
		al.Step = 1;
		((Control)al).TabIndex = 19;
		((Control)ab).Anchor = (AnchorStyles)6;
		((Control)ab).Location = new Point(164, 186);
		((Control)ab).Name = "btnRemove";
		((Control)ab).Size = new Size(75, 23);
		((Control)ab).TabIndex = 18;
		((Control)ab).Text = "Remove";
		((ButtonBase)ab).UseVisualStyleBackColor = true;
		((Control)ab).Click += c;
		((Control)z).AutoSize = true;
		((Control)z).Location = new Point(103, 159);
		((Control)z).Name = "lblSize";
		((Control)z).Size = new Size(13, 13);
		((Control)z).TabIndex = 17;
		((Control)z).Text = "0";
		((Control)aa).AutoSize = true;
		((Control)aa).Location = new Point(7, 159);
		((Control)aa).Name = "label8";
		((Control)aa).Size = new Size(61, 13);
		((Control)aa).TabIndex = 16;
		((Control)aa).Text = "Share Size:";
		((Control)v).AutoSize = true;
		((Control)v).Location = new Point(103, 135);
		((Control)v).Name = "lblDownloads";
		((Control)v).Size = new Size(13, 13);
		((Control)v).TabIndex = 15;
		((Control)v).Text = "0";
		((Control)w).AutoSize = true;
		((Control)w).Location = new Point(7, 135);
		((Control)w).Name = "label6";
		((Control)w).Size = new Size(90, 13);
		((Control)w).TabIndex = 14;
		((Control)w).Text = "Total Downloads:";
		((Control)x).Location = new Point(79, 109);
		((Control)x).Name = "tbUpdatedDate";
		((TextBoxBase)x).ReadOnly = true;
		((Control)x).Size = new Size(177, 20);
		((Control)x).TabIndex = 13;
		((Control)y).AutoSize = true;
		((Control)y).Location = new Point(7, 112);
		((Control)y).Name = "label5";
		((Control)y).Size = new Size(68, 13);
		((Control)y).TabIndex = 12;
		((Control)y).Text = "Updated On:";
		((Control)r).Anchor = (AnchorStyles)15;
		((Control)r).Location = new Point(331, 8);
		((Control)r).Name = "rtDescription";
		((TextBoxBase)r).ReadOnly = true;
		((Control)r).Size = new Size(395, 172);
		((Control)r).TabIndex = 11;
		((Control)r).Text = "";
		r.LinkClicked += a;
		((Control)s).AutoSize = true;
		((Control)s).Location = new Point(262, 8);
		((Control)s).Name = "label4";
		((Control)s).Size = new Size(63, 13);
		((Control)s).TabIndex = 10;
		((Control)s).Text = "Description:";
		((Control)t).AutoSize = true;
		((Control)t).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)t).Location = new Point(7, 84);
		((Control)t).Name = "lblExplicitContent";
		((Control)t).Size = new Size(191, 17);
		((Control)t).TabIndex = 9;
		((Control)t).Text = "Explicit Content Advisory!";
		((Control)ac).Location = new Point(79, 57);
		((Control)ac).Name = "tbCategory";
		((TextBoxBase)ac).ReadOnly = true;
		((Control)ac).Size = new Size(177, 20);
		((Control)ac).TabIndex = 8;
		((Control)j).AutoSize = true;
		((Control)j).Location = new Point(7, 60);
		((Control)j).Name = "label3";
		((Control)j).Size = new Size(52, 13);
		((Control)j).TabIndex = 7;
		((Control)j).Text = "Category:";
		((Control)k).Location = new Point(79, 31);
		((Control)k).Name = "tbShareAuthor";
		((TextBoxBase)k).ReadOnly = true;
		((Control)k).Size = new Size(177, 20);
		((Control)k).TabIndex = 6;
		((Control)l).AutoSize = true;
		((Control)l).Location = new Point(7, 34);
		((Control)l).Name = "label2";
		((Control)l).Size = new Size(41, 13);
		((Control)l).TabIndex = 5;
		((Control)l).Text = "Author:";
		((Control)m).Location = new Point(79, 5);
		((Control)m).Name = "tbShareName";
		((TextBoxBase)m).ReadOnly = true;
		((Control)m).Size = new Size(177, 20);
		((Control)m).TabIndex = 4;
		((Control)n).AutoSize = true;
		((Control)n).Location = new Point(7, 8);
		((Control)n).Name = "label1";
		((Control)n).Size = new Size(69, 13);
		((Control)n).TabIndex = 3;
		((Control)n).Text = "Share Name:";
		((Control)o).Anchor = (AnchorStyles)10;
		((Control)o).Location = new Point(636, 186);
		((Control)o).Name = "btnUpdate";
		((Control)o).Size = new Size(90, 23);
		((Control)o).TabIndex = 2;
		((Control)o).Text = "Update";
		((ButtonBase)o).UseVisualStyleBackColor = true;
		((Control)o).Click += b;
		((Control)p).Anchor = (AnchorStyles)6;
		((Control)p).Location = new Point(85, 186);
		((Control)p).Name = "btnShare";
		((Control)p).Size = new Size(75, 23);
		((Control)p).TabIndex = 1;
		((Control)p).Text = "Share";
		((ButtonBase)p).UseVisualStyleBackColor = true;
		((Control)p).Click += f;
		((Control)q).Anchor = (AnchorStyles)6;
		((Control)q).Location = new Point(6, 186);
		((Control)q).Name = "btnDownload";
		((Control)q).Size = new Size(75, 23);
		((Control)q).TabIndex = 0;
		((Control)q).Text = "Download";
		((ButtonBase)q).UseVisualStyleBackColor = true;
		((Control)q).Click += e;
		((FileDialog)u).Filter = "Rags Files|*.rag";
		((FileDialog)u).Title = "Save Share As...";
		am.Enabled = true;
		am.Tick += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(747, 498);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "RagsShare";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Rags Share";
		((Form)this).Load += g;
		((Control)this.m_c).ResumeLayout(false);
		((Control)this.m_d).ResumeLayout(false);
		((Control)this.m_e).ResumeLayout(false);
		((Control)this.m_g.Panel1).ResumeLayout(false);
		((Control)this.m_g.Panel1).PerformLayout();
		((Control)this.m_g.Panel2).ResumeLayout(false);
		((Control)this.m_g.Panel2).PerformLayout();
		((Control)this.m_g).ResumeLayout(false);
		((ISupportInitialize)i).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
