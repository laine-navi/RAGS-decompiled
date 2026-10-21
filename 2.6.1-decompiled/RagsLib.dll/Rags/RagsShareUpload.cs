using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Rags.ragsgame.com;

namespace Rags;

public class RagsShareUpload : Form
{
	private bool m_a;

	private Rags.ragsgame.com.ShareData m_b;

	private IContainer m_c;

	private Label m_d;

	private TextBox m_e;

	private TextBox f;

	private Label g;

	private Label h;

	private ComboBox i;

	private CheckBox j;

	private Label k;

	private Button l;

	private Button m;

	private TextBox n;

	private Label o;

	private Button p;

	private OpenFileDialog q;

	private RichTextBox r;

	private Label s;

	private ProgressBar t;

	private Timer u;

	public RagsShareUpload(bool Update, Rags.ragsgame.com.ShareData thedata)
	{
		a();
		this.m_a = Update;
		this.m_b = thedata;
	}

	private void e(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void a(object A_0, AsyncCompletedEventArgs A_1)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		((Control)t).Enabled = false;
		Cursor.Current = Cursors.Default;
		if (A_1.Error != null)
		{
			MessageBox.Show("Upload error: " + A_1.Error.Message);
			return;
		}
		MessageBox.Show("Upload successful.");
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		string text = string.Empty;
		if (((Control)n).Text.Trim() != string.Empty)
		{
			text = b();
		}
		else if (this.m_b != null)
		{
			text = this.m_b.RagsVersion;
		}
		if (text == string.Empty)
		{
			return;
		}
		CheckUpdates checkUpdates = new CheckUpdates();
		checkUpdates.UploadShareCompleted += a;
		Rags.ragsgame.com.ShareData shareData = new Rags.ragsgame.com.ShareData();
		try
		{
			if (this.m_a)
			{
				shareData.index = this.m_b.index;
				shareData.useremail = LockData.GetEmail();
				shareData.usernickname = ((Control)f).Text;
				shareData.sharename = ((Control)this.m_e).Text;
				shareData.category = ((Control)i).Text;
				shareData.bexplicit = j.Checked;
				shareData.description = ((Control)r).Text;
				if (((Control)n).Text.Trim() == string.Empty)
				{
					((Control)t).Enabled = true;
					checkUpdates.UploadShareAsync(shareData, null, LockData.GetKey(), text);
				}
				else
				{
					((Control)t).Enabled = true;
					checkUpdates.UploadShareAsync(shareData, File.ReadAllBytes(((Control)n).Text), LockData.GetKey(), text);
				}
			}
			else
			{
				shareData.useremail = LockData.GetEmail();
				shareData.usernickname = ((Control)f).Text;
				shareData.sharename = ((Control)this.m_e).Text;
				shareData.category = ((Control)i).Text;
				shareData.bexplicit = j.Checked;
				shareData.description = ((Control)r).Text;
				((Control)t).Enabled = true;
				checkUpdates.UploadShareAsync(shareData, File.ReadAllBytes(((Control)n).Text), LockData.GetKey(), text);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error uploading your share.  Error text: " + ex.Message);
		}
	}

	private string b()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		string result = string.Empty;
		if (((Control)n).Text.Trim().Length > 0)
		{
			byte[] array = EncDec.Decrypt(File.ReadAllBytes(((Control)n).Text), "²µ±±³àòå²²");
			if (array == null)
			{
				MessageBox.Show("This appears to be an invalid RAGS game.");
				return string.Empty;
			}
			MemoryStream memoryStream = new MemoryStream(array);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				memoryStream.Seek(0L, SeekOrigin.Begin);
				_ = (Game)binaryFormatter.Deserialize(memoryStream);
				result = Game.CurrentObjectVersionNumber;
			}
			catch
			{
				MessageBox.Show("This appears to be an invalid RAGS game.");
				result = string.Empty;
			}
		}
		return result;
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((CommonDialog)q).ShowDialog() == 1)
		{
			if (Path.GetExtension(((FileDialog)q).FileName).ToUpper() != ".RAG")
			{
				MessageBox.Show("Sorry, you can only upload RAGS game files.");
			}
			else
			{
				((Control)n).Text = ((FileDialog)q).FileName;
			}
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (this.m_a && this.m_b != null)
		{
			((Control)this.m_e).Text = this.m_b.sharename;
			((Control)f).Text = this.m_b.usernickname;
			((Control)r).Text = this.m_b.description;
			((Control)i).Text = this.m_b.category;
			j.Checked = this.m_b.bexplicit;
			((Control)l).Text = "Update";
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		if (((Control)t).Enabled)
		{
			if (t.Value == 100)
			{
				t.Value = 1;
			}
			t.Increment(1);
		}
	}

	private void a(object A_0, FormClosingEventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)t).Enabled)
		{
			((CancelEventArgs)(object)A_1).Cancel = true;
			MessageBox.Show("Please wait for your upload to complete before exiting.");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_c != null)
		{
			this.m_c.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected Obj, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected Obj, but got Unknown
		this.m_c = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsShareUpload));
		this.m_d = new Label();
		this.m_e = new TextBox();
		f = new TextBox();
		g = new Label();
		h = new Label();
		i = new ComboBox();
		j = new CheckBox();
		k = new Label();
		l = new Button();
		m = new Button();
		n = new TextBox();
		o = new Label();
		p = new Button();
		q = new OpenFileDialog();
		r = new RichTextBox();
		s = new Label();
		t = new ProgressBar();
		u = new Timer(this.m_c);
		((Control)this).SuspendLayout();
		((Control)this.m_d).AutoSize = true;
		((Control)this.m_d).Location = new Point(12, 9);
		((Control)this.m_d).Name = "label1";
		((Control)this.m_d).Size = new Size(69, 13);
		((Control)this.m_d).TabIndex = 0;
		((Control)this.m_d).Text = "Share Name:";
		((Control)this.m_e).Location = new Point(118, 6);
		((Control)this.m_e).Name = "tbShareName";
		((Control)this.m_e).Size = new Size(212, 20);
		((Control)this.m_e).TabIndex = 1;
		((Control)f).Location = new Point(118, 32);
		((Control)f).Name = "tbNickName";
		((Control)f).Size = new Size(212, 20);
		((Control)f).TabIndex = 3;
		((Control)g).AutoSize = true;
		((Control)g).Location = new Point(12, 35);
		((Control)g).Name = "label2";
		((Control)g).Size = new Size(100, 13);
		((Control)g).TabIndex = 2;
		((Control)g).Text = "Your Display Name:";
		((Control)h).AutoSize = true;
		((Control)h).Location = new Point(12, 61);
		((Control)h).Name = "label3";
		((Control)h).Size = new Size(52, 13);
		((Control)h).TabIndex = 4;
		((Control)h).Text = "Category:";
		i.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)i).FormattingEnabled = true;
		i.Items.AddRange(new object[4] { "Code Snippet", "Timer/Functions", "Player Actions", "Game" });
		((Control)i).Location = new Point(118, 58);
		((Control)i).Name = "cbCategory";
		((Control)i).Size = new Size(212, 21);
		((Control)i).TabIndex = 5;
		((Control)j).AutoSize = true;
		((Control)j).Location = new Point(15, 86);
		((Control)j).Name = "cbExplicitContent";
		((Control)j).Size = new Size(142, 17);
		((Control)j).TabIndex = 6;
		((Control)j).Text = "Explicit Content Advisory";
		((ButtonBase)j).UseVisualStyleBackColor = true;
		((Control)k).AutoSize = true;
		((Control)k).Location = new Point(12, 135);
		((Control)k).Name = "label4";
		((Control)k).Size = new Size(63, 13);
		((Control)k).TabIndex = 7;
		((Control)k).Text = "Description:";
		((Control)l).Location = new Point(100, 378);
		((Control)l).Name = "button1";
		((Control)l).Size = new Size(75, 23);
		((Control)l).TabIndex = 9;
		((Control)l).Text = "Upload";
		((ButtonBase)l).UseVisualStyleBackColor = true;
		((Control)l).Click += d;
		m.DialogResult = (DialogResult)2;
		((Control)m).Location = new Point(337, 378);
		((Control)m).Name = "button2";
		((Control)m).Size = new Size(75, 23);
		((Control)m).TabIndex = 10;
		((Control)m).Text = "Cancel";
		((ButtonBase)m).UseVisualStyleBackColor = true;
		((Control)m).Click += e;
		((Control)n).Anchor = (AnchorStyles)13;
		((Control)n).Location = new Point(118, 109);
		((Control)n).Name = "tbGameFileName";
		((Control)n).Size = new Size(343, 20);
		((Control)n).TabIndex = 12;
		((Control)o).AutoSize = true;
		((Control)o).Location = new Point(12, 112);
		((Control)o).Name = "label5";
		((Control)o).Size = new Size(54, 13);
		((Control)o).TabIndex = 11;
		((Control)o).Text = "Rags File:";
		((Control)p).Anchor = (AnchorStyles)9;
		((Control)p).Location = new Point(467, 109);
		((Control)p).Name = "button3";
		((Control)p).Size = new Size(27, 20);
		((Control)p).TabIndex = 13;
		((Control)p).Text = "...";
		((ButtonBase)p).TextAlign = (ContentAlignment)2;
		((ButtonBase)p).UseVisualStyleBackColor = true;
		((Control)p).Click += c;
		((FileDialog)q).FileName = "openFileDialog1";
		((FileDialog)q).Filter = "Rags Files|*.rag";
		((Control)r).Anchor = (AnchorStyles)15;
		((Control)r).Location = new Point(118, 135);
		((Control)r).Name = "rtDescription";
		((Control)r).Size = new Size(376, 208);
		((Control)r).TabIndex = 14;
		((Control)r).Text = "";
		((Control)s).AutoSize = true;
		((Control)s).Location = new Point(117, 354);
		((Control)s).Name = "label7";
		((Control)s).Size = new Size(58, 13);
		((Control)s).TabIndex = 22;
		((Control)s).Text = "Uploading:";
		((Control)t).Anchor = (AnchorStyles)13;
		((Control)t).Enabled = false;
		((Control)t).Location = new Point(195, 349);
		((Control)t).Name = "progressBar1";
		((Control)t).Size = new Size(299, 23);
		t.Step = 1;
		((Control)t).TabIndex = 21;
		u.Enabled = true;
		u.Tick += a;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(506, 410);
		((Control)this).Controls.Add((Control)(object)s);
		((Control)this).Controls.Add((Control)(object)t);
		((Control)this).Controls.Add((Control)(object)r);
		((Control)this).Controls.Add((Control)(object)p);
		((Control)this).Controls.Add((Control)(object)n);
		((Control)this).Controls.Add((Control)(object)o);
		((Control)this).Controls.Add((Control)(object)m);
		((Control)this).Controls.Add((Control)(object)l);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "RagsShareUpload";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Rags Share Upload";
		((Form)this).Load += b;
		((Form)this).FormClosing += a;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
