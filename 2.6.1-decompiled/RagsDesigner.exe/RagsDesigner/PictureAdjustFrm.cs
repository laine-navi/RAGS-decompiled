using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class PictureAdjustFrm : Form
{
	private ArrayList m_a;

	private string m_b = string.Empty;

	private double m_c;

	private double m_d;

	private IntPtr m_e;

	private int m_f;

	private IContainer m_g;

	private NumericUpDown m_h;

	private Label m_i;

	private Button j;

	private Button k;

	private ListBox l;

	private Label m;

	private Label n;

	private NumericUpDown o;

	private ComboBox p;

	private Label q;

	private GroupBox r;

	private Label s;

	private Label t;

	private Label u;

	private Label v;

	private Label w;

	private Label x;

	private Button y;

	private PictureBox z;

	private SplitContainer aa;

	private PictureBox ab;

	private Label ac;

	private Label ad;

	private Label ae;

	public PictureAdjustFrm(ref ArrayList PictureList, string adjustname)
	{
		a();
		this.m_a = PictureList;
		this.m_b = adjustname;
	}

	private void i(object A_0, EventArgs A_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (l.SelectedItem is GamePicture gamePicture)
			{
				Image theImage = gamePicture.GetTheImage();
				z.Image = ResizeBitmap(theImage, Convert.ToInt32(o.Value));
				z.Image = a(z.Image, Convert.ToInt32(this.m_h.Value));
				((Control)s).Text = "Height: " + theImage.Height;
				((Control)t).Text = "Width: " + theImage.Width;
				((Control)v).Text = "Resized Width: " + z.Image.Width;
				((Control)u).Text = "Resized Height: " + z.Image.Height;
				byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
				byte[] array2 = (byte[])TypeDescriptor.GetConverter(z.Image).ConvertTo(z.Image, typeof(byte[]));
				_ = array.Length / 1024;
				((Control)x).Text = $"Orig Kbytes: {array.Length / 1024:####.##}";
				((Control)w).Text = $"New Kbytes:{array2.Length / 1024:####.##}";
			}
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private Image a(Image A_0, int A_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		if (A_0 == null)
		{
			return A_0;
		}
		if (A_1 >= 0)
		{
			_ = 100;
		}
		EncoderParameter val = new EncoderParameter(Encoder.Quality, (long)A_1);
		ImageCodecInfo val2 = null;
		string text = ImageFormat.Gif.Guid.ToString();
		string text2 = ImageFormat.Png.Guid.ToString();
		string text3 = ab.Image.RawFormat.Guid.ToString();
		((Control)ae).Visible = false;
		if (text3 == text)
		{
			return A_0;
		}
		if (text3 == text2)
		{
			val2 = a("image/png");
			if (val2 == null)
			{
				((Control)ae).Visible = true;
				((Control)ae).Text = "PNG format not adjustable";
			}
		}
		else
		{
			val2 = a("image/jpeg");
		}
		if (val2 != null)
		{
			EncoderParameters val3 = new EncoderParameters(1);
			val3.Param[0] = val;
			MemoryStream memoryStream = new MemoryStream();
			A_0.Save((Stream)memoryStream, val2, val3);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return Image.FromStream((Stream)memoryStream);
		}
		return A_0;
	}

	private ImageCodecInfo a(string A_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length; i++)
		{
			if (imageEncoders[i].MimeType == A_0)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	private void h(object A_0, EventArgs A_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (l.SelectedItem is GamePicture gamePicture)
			{
				Image theImage = gamePicture.GetTheImage();
				if (theImage != null)
				{
					ab.Image = theImage;
					z.Image = ResizeBitmap(theImage, Convert.ToInt32(o.Value));
					z.Image = a(z.Image, Convert.ToInt32(this.m_h.Value));
					((Control)s).Text = "Height: " + theImage.Height;
					((Control)t).Text = "Width: " + theImage.Width;
					((Control)v).Text = "Resized Width: " + z.Image.Width;
					((Control)u).Text = "Resized Height: " + z.Image.Height;
					byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
					byte[] array2 = (byte[])TypeDescriptor.GetConverter(z.Image).ConvertTo(z.Image, typeof(byte[]));
					_ = array.Length / 1024;
					((Control)x).Text = $"Orig Kbytes: {array.Length / 1024:####.##}";
					((Control)w).Text = $"New Kbytes:{array2.Length / 1024:####.##}";
				}
			}
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		b();
	}

	private void b()
	{
		((ListControl)p).SelectedIndex = 0;
		l.Items.Clear();
		for (int i = 0; i < this.m_a.Count; i++)
		{
			l.Items.Add(this.m_a[i]);
		}
		if (l.Items.Count > 0)
		{
			((ListControl)l).SelectedIndex = 0;
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		for (int i = 0; i < this.m_a.Count; i++)
		{
			if (this.m_a[i] is GamePicture gamePicture)
			{
				Image val = ResizeBitmap(gamePicture.GetTheImage(), Convert.ToInt32(o.Value));
				if (val != null)
				{
					val = a(val, Convert.ToInt32(this.m_h.Value));
					MemoryStream memoryStream = new MemoryStream();
					val.Save((Stream)memoryStream, val.RawFormat);
					SqlCeConnection dBConnection = Game.GetDBConnection();
					SqlCeCommand sqlCeCommand = new SqlCeCommand("update Media set Data=@Data where\r\n                            Name=@Name", dBConnection);
					sqlCeCommand.Parameters.AddWithValue("@Data", memoryStream.ToArray());
					sqlCeCommand.Parameters.AddWithValue("@Name", gamePicture.TheName);
					sqlCeCommand.ExecuteNonQuery();
					memoryStream.Close();
					memoryStream.Dispose();
				}
			}
		}
		o.Value = 100m;
	}

	private void e(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	public bool ThumbnailCallback()
	{
		return false;
	}

	public unsafe Image ResizeBitmap(Image b, int percentage)
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		if (b == null)
		{
			return b;
		}
		if ((int)b.PixelFormat != 198659)
		{
			try
			{
				Bitmap val = new Bitmap(Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)), b.PixelFormat);
				try
				{
					((Image)val).Palette = b.Palette;
				}
				catch
				{
				}
				Graphics val2 = Graphics.FromImage((Image)(object)val);
				try
				{
					val2.InterpolationMode = (InterpolationMode)7;
					val2.DrawImage(b, 0, 0, Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)));
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return (Image)(object)val;
			}
			catch
			{
				return b;
			}
		}
		Bitmap val3 = new Bitmap(Convert.ToInt32((double)b.Width * ((double)percentage * 0.01)), Convert.ToInt32((double)b.Height * ((double)percentage * 0.01)), b.PixelFormat);
		((Image)val3).Palette = b.Palette;
		BitmapData val4 = ((Bitmap)b).LockBits(new Rectangle(0, 0, b.Width, b.Height), (ImageLockMode)1, b.PixelFormat);
		try
		{
			BitmapData val5 = val3.LockBits(new Rectangle(0, 0, ((Image)val3).Width, ((Image)val3).Height), (ImageLockMode)2, ((Image)val3).PixelFormat);
			try
			{
				this.m_c = (double)b.Width / (double)((Image)val3).Width;
				this.m_d = (double)b.Height / (double)((Image)val3).Height;
				this.m_f = val4.Stride;
				this.m_e = val4.Scan0;
				int stride = val5.Stride;
				byte* ptr = (byte*)(void*)val5.Scan0;
				int num = stride - ((Image)val3).Width;
				int width = ((Image)val3).Width;
				for (int i = 0; i < ((Image)val3).Height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						*ptr = a(j, i);
						ptr++;
					}
					ptr += num;
				}
			}
			finally
			{
				val3.UnlockBits(val5);
			}
		}
		finally
		{
			((Bitmap)b).UnlockBits(val4);
		}
		return (Image)(object)val3;
	}

	private unsafe byte a(int A_0, int A_1)
	{
		return *(byte*)((int)this.m_e + (int)(Math.Floor((double)A_1 * this.m_d) * (double)this.m_f) + (int)Math.Floor((double)A_0 * this.m_c));
	}

	private void d(object A_0, EventArgs A_1)
	{
		if (((ListControl)p).SelectedIndex == 0)
		{
			((Control)z).Width = aa.Panel2.Width;
			((Control)z).Height = aa.Panel2.Height;
			((Control)z).Anchor = (AnchorStyles)15;
			z.SizeMode = (PictureBoxSizeMode)4;
			((Control)ab).Width = aa.Panel1.Width;
			((Control)ab).Height = aa.Panel1.Height;
			((Control)ab).Anchor = (AnchorStyles)15;
			ab.SizeMode = (PictureBoxSizeMode)4;
		}
		else
		{
			((Control)ab).Anchor = (AnchorStyles)5;
			((Control)z).Anchor = (AnchorStyles)5;
			z.SizeMode = (PictureBoxSizeMode)2;
			ab.SizeMode = (PictureBoxSizeMode)2;
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (l.SelectedItem is GamePicture gamePicture)
			{
				Image theImage = gamePicture.GetTheImage();
				z.Image = ResizeBitmap(theImage, Convert.ToInt32(o.Value));
				z.Image = a(z.Image, Convert.ToInt32(this.m_h.Value));
				((Control)s).Text = "Height: " + theImage.Height;
				((Control)t).Text = "Width: " + theImage.Width;
				((Control)v).Text = "Resized Width: " + z.Image.Width;
				((Control)u).Text = "Resized Height: " + z.Image.Height;
				byte[] array = (byte[])TypeDescriptor.GetConverter(theImage).ConvertTo(theImage, typeof(byte[]));
				byte[] array2 = (byte[])TypeDescriptor.GetConverter(z.Image).ConvertTo(z.Image, typeof(byte[]));
				_ = array.Length / 1024;
				((Control)x).Text = $"Orig Kbytes: {array.Length / 1024:####.##}";
				((Control)w).Text = $"New Kbytes:{array2.Length / 1024:####.##}";
			}
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		foreach (GamePicture selectedItem in l.SelectedItems)
		{
			if (selectedItem == null)
			{
				continue;
			}
			Image theImage = selectedItem.GetTheImage();
			if (theImage != null)
			{
				theImage = ResizeBitmap(theImage, Convert.ToInt32(o.Value));
				theImage = a(theImage, Convert.ToInt32(this.m_h.Value));
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					theImage.Save((Stream)memoryStream, theImage.RawFormat);
					SqlCeConnection dBConnection = Game.GetDBConnection();
					SqlCeCommand sqlCeCommand = new SqlCeCommand("update Media set Data=@Data where\r\n                            Name=@Name", dBConnection);
					sqlCeCommand.Parameters.AddWithValue("@Data", memoryStream.ToArray());
					sqlCeCommand.Parameters.AddWithValue("@Name", selectedItem.TheName);
					sqlCeCommand.ExecuteNonQuery();
					memoryStream.Close();
					memoryStream.Dispose();
				}
				catch
				{
				}
				theImage.Dispose();
			}
		}
		o.Value = 100m;
		this.m_h.Value = 80m;
		h(null, null);
	}

	private void a(object A_0, EventArgs A_1)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_g != null)
		{
			this.m_g.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
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
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Expected Obj, but got Unknown
		//IL_0ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaf: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PictureAdjustFrm));
		this.m_h = new NumericUpDown();
		this.m_i = new Label();
		j = new Button();
		k = new Button();
		l = new ListBox();
		m = new Label();
		n = new Label();
		o = new NumericUpDown();
		p = new ComboBox();
		q = new Label();
		r = new GroupBox();
		w = new Label();
		x = new Label();
		u = new Label();
		v = new Label();
		s = new Label();
		t = new Label();
		y = new Button();
		z = new PictureBox();
		aa = new SplitContainer();
		ad = new Label();
		ab = new PictureBox();
		ac = new Label();
		ae = new Label();
		((ISupportInitialize)this.m_h).BeginInit();
		((ISupportInitialize)o).BeginInit();
		((Control)r).SuspendLayout();
		((ISupportInitialize)z).BeginInit();
		((Control)aa.Panel1).SuspendLayout();
		((Control)aa.Panel2).SuspendLayout();
		((Control)aa).SuspendLayout();
		((ISupportInitialize)ab).BeginInit();
		((Control)this).SuspendLayout();
		((Control)this.m_h).Location = new Point(189, 22);
		this.m_h.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)this.m_h).Name = "udQuality";
		((Control)this.m_h).Size = new Size(91, 20);
		((Control)this.m_h).TabIndex = 2;
		this.m_h.Value = new decimal(new int[4] { 80, 0, 0, 0 });
		this.m_h.ValueChanged += i;
		((Control)this.m_i).AutoSize = true;
		((Control)this.m_i).Location = new Point(186, 6);
		((Control)this.m_i).Name = "label1";
		((Control)this.m_i).Size = new Size(42, 13);
		((Control)this.m_i).TabIndex = 3;
		((Control)this.m_i).Text = "Quality:";
		((Control)j).Anchor = (AnchorStyles)6;
		((Control)j).Location = new Point(12, 553);
		((Control)j).Name = "btnApply";
		((Control)j).Size = new Size(76, 23);
		((Control)j).TabIndex = 4;
		((Control)j).Text = "Apply To All";
		((ButtonBase)j).UseVisualStyleBackColor = true;
		((Control)j).Click += f;
		((Control)k).Anchor = (AnchorStyles)6;
		k.DialogResult = (DialogResult)2;
		((Control)k).Location = new Point(662, 553);
		((Control)k).Name = "btnCancel";
		((Control)k).Size = new Size(47, 23);
		((Control)k).TabIndex = 5;
		((Control)k).Text = "Done";
		((ButtonBase)k).UseVisualStyleBackColor = true;
		((Control)k).Click += e;
		((Control)l).Anchor = (AnchorStyles)7;
		((ListControl)l).FormattingEnabled = true;
		((Control)l).Location = new Point(11, 23);
		((Control)l).Name = "lbPictures";
		l.SelectionMode = (SelectionMode)3;
		((Control)l).Size = new Size(131, 524);
		((Control)l).TabIndex = 6;
		l.SelectedIndexChanged += h;
		((Control)m).AutoSize = true;
		((Control)m).Location = new Point(8, 6);
		((Control)m).Name = "label2";
		((Control)m).Size = new Size(48, 13);
		((Control)m).TabIndex = 7;
		((Control)m).Text = "Pictures:";
		((Control)n).AutoSize = true;
		((Control)n).Location = new Point(319, 6);
		((Control)n).Name = "label3";
		((Control)n).Size = new Size(137, 13);
		((Control)n).TabIndex = 9;
		((Control)n).Text = "Percentage size of original :";
		((Control)o).Location = new Point(322, 22);
		o.Maximum = new decimal(new int[4] { 200, 0, 0, 0 });
		o.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)o).Name = "udPercentage";
		((Control)o).Size = new Size(134, 20);
		((Control)o).TabIndex = 8;
		o.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		o.ValueChanged += c;
		p.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)p).FormattingEnabled = true;
		p.Items.AddRange(new object[2] { "Zoom Mode", "Actual Size" });
		((Control)p).Location = new Point(247, 64);
		((Control)p).Name = "cbViewMode";
		((Control)p).Size = new Size(121, 21);
		((Control)p).TabIndex = 10;
		p.SelectedIndexChanged += d;
		((Control)q).AutoSize = true;
		((Control)q).Location = new Point(247, 47);
		((Control)q).Name = "label4";
		((Control)q).Size = new Size(99, 13);
		((Control)q).TabIndex = 11;
		((Control)q).Text = "Picture View Mode:";
		((Control)r).Controls.Add((Control)(object)w);
		((Control)r).Controls.Add((Control)(object)x);
		((Control)r).Controls.Add((Control)(object)u);
		((Control)r).Controls.Add((Control)(object)v);
		((Control)r).Controls.Add((Control)(object)s);
		((Control)r).Controls.Add((Control)(object)t);
		((Control)r).Location = new Point(471, 3);
		((Control)r).Name = "groupBox1";
		((Control)r).Size = new Size(238, 82);
		((Control)r).TabIndex = 12;
		r.TabStop = false;
		((Control)r).Text = "Picture Stats:";
		((Control)w).AutoSize = true;
		((Control)w).Location = new Point(114, 61);
		((Control)w).Name = "lblNewKbytes";
		((Control)w).Size = new Size(67, 13);
		((Control)w).TabIndex = 5;
		((Control)w).Text = "New Kbytes:";
		((Control)x).AutoSize = true;
		((Control)x).Location = new Point(6, 61);
		((Control)x).Name = "lblOrigBytes";
		((Control)x).Size = new Size(64, 13);
		((Control)x).TabIndex = 4;
		((Control)x).Text = "Orig Kbytes:";
		((Control)u).AutoSize = true;
		((Control)u).Location = new Point(114, 41);
		((Control)u).Name = "lblRszHght";
		((Control)u).Size = new Size(82, 13);
		((Control)u).TabIndex = 3;
		((Control)u).Text = "Resized Height:";
		((Control)v).AutoSize = true;
		((Control)v).Location = new Point(114, 21);
		((Control)v).Name = "lblRszdWdth";
		((Control)v).Size = new Size(79, 13);
		((Control)v).TabIndex = 2;
		((Control)v).Text = "Resized Width:";
		((Control)s).AutoSize = true;
		((Control)s).Location = new Point(6, 41);
		((Control)s).Name = "lblPictureHeight";
		((Control)s).Size = new Size(41, 13);
		((Control)s).TabIndex = 1;
		((Control)s).Text = "Height:";
		((Control)t).AutoSize = true;
		((Control)t).Location = new Point(6, 21);
		((Control)t).Name = "lblPitctureWidth";
		((Control)t).Size = new Size(38, 13);
		((Control)t).TabIndex = 0;
		((Control)t).Text = "Width:";
		((Control)y).Anchor = (AnchorStyles)6;
		((Control)y).Location = new Point(319, 553);
		((Control)y).Name = "button1";
		((Control)y).Size = new Size(108, 23);
		((Control)y).TabIndex = 13;
		((Control)y).Text = "Apply To Selected";
		((ButtonBase)y).UseVisualStyleBackColor = true;
		((Control)y).Click += b;
		z.BorderStyle = (BorderStyle)1;
		((Control)z).Location = new Point(2, 16);
		((Control)z).Name = "picPreview";
		((Control)z).Size = new Size(274, 437);
		z.SizeMode = (PictureBoxSizeMode)4;
		z.TabIndex = 1;
		z.TabStop = false;
		((Control)z).Click += a;
		((Control)aa).Anchor = (AnchorStyles)15;
		((Control)aa).Location = new Point(148, 91);
		((Control)aa).Name = "splitContainer1";
		((ScrollableControl)aa.Panel1).AutoScroll = true;
		((Control)aa.Panel1).Controls.Add((Control)(object)ad);
		((Control)aa.Panel1).Controls.Add((Control)(object)ab);
		((ScrollableControl)aa.Panel2).AutoScroll = true;
		((Control)aa.Panel2).Controls.Add((Control)(object)ac);
		((Control)aa.Panel2).Controls.Add((Control)(object)z);
		((Control)aa).Size = new Size(561, 456);
		aa.SplitterDistance = 278;
		((Control)aa).TabIndex = 15;
		((Control)ad).AutoSize = true;
		((Control)ad).Location = new Point(3, -1);
		((Control)ad).Name = "label6";
		((Control)ad).Size = new Size(45, 13);
		((Control)ad).TabIndex = 3;
		((Control)ad).Text = "Original:";
		ab.BorderStyle = (BorderStyle)1;
		((Control)ab).Location = new Point(3, 16);
		((Control)ab).Name = "PicOriginal";
		((Control)ab).Size = new Size(272, 437);
		ab.SizeMode = (PictureBoxSizeMode)4;
		ab.TabIndex = 2;
		ab.TabStop = false;
		((Control)ac).AutoSize = true;
		((Control)ac).Location = new Point(3, -1);
		((Control)ac).Name = "label5";
		((Control)ac).Size = new Size(51, 13);
		((Control)ac).TabIndex = 2;
		((Control)ac).Text = "Adjusted:";
		((Control)ae).AutoSize = true;
		((Control)ae).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)ae).Location = new Point(151, 558);
		((Control)ae).Name = "lblUnsupportedFormat";
		((Control)ae).Size = new Size(130, 13);
		((Control)ae).TabIndex = 16;
		((Control)ae).Text = "lblUnsupportedFormat";
		((Control)ae).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(721, 579);
		((Control)this).Controls.Add((Control)(object)ae);
		((Control)this).Controls.Add((Control)(object)aa);
		((Control)this).Controls.Add((Control)(object)y);
		((Control)this).Controls.Add((Control)(object)r);
		((Control)this).Controls.Add((Control)(object)q);
		((Control)this).Controls.Add((Control)(object)p);
		((Control)this).Controls.Add((Control)(object)n);
		((Control)this).Controls.Add((Control)(object)o);
		((Control)this).Controls.Add((Control)(object)m);
		((Control)this).Controls.Add((Control)(object)l);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)this.m_i);
		((Control)this).Controls.Add((Control)(object)this.m_h);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "PictureAdjustFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "PictureAdjustFrm";
		((Form)this).Load += g;
		((ISupportInitialize)this.m_h).EndInit();
		((ISupportInitialize)o).EndInit();
		((Control)r).ResumeLayout(false);
		((Control)r).PerformLayout();
		((ISupportInitialize)z).EndInit();
		((Control)aa.Panel1).ResumeLayout(false);
		((Control)aa.Panel1).PerformLayout();
		((Control)aa.Panel2).ResumeLayout(false);
		((Control)aa.Panel2).PerformLayout();
		((Control)aa).ResumeLayout(false);
		((ISupportInitialize)ab).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
