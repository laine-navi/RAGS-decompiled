using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class AdvancedOverlayFrm : Form
{
	private EnhancedInputData m_a;

	private Game m_b;

	private IContainer m_c;

	private SplitContainer m_d;

	private Label m_e;

	private ComboBox m_f;

	private PictureBox m_g;

	private Button m_h;

	private FontDialog m_i;

	private ColorDialog m_j;

	private CheckBox k;

	private Button l;

	private Button m;

	private Button n;

	private Label o;

	private Label p;

	private NumericUpDown q;

	private NumericUpDown r;

	private CheckBox s;

	public AdvancedOverlayFrm()
	{
		a();
	}

	public AdvancedOverlayFrm(ref EnhancedInputData thedata, ref Game curgame)
	{
		a();
		this.m_a = thedata;
		this.m_b = curgame;
	}

	private void j(object A_0, EventArgs A_1)
	{
		k.Checked = this.m_a.bUseEnhancedGraphics;
		s.Checked = this.m_a.bAllowCancel;
		r.Value = Convert.ToDecimal(this.m_a.BackgroundColor.A);
		q.Value = Convert.ToDecimal(this.m_a.TextColor.A);
		this.m_f.Items.Clear();
		this.m_f.Items.Add((object)"No Change");
		foreach (GamePicture picture in this.m_b.PictureList)
		{
			this.m_f.Items.Add((object)picture.TheName);
		}
		if (this.m_a.NewImage != string.Empty && this.m_a.NewImage != "No Change")
		{
			this.m_f.SelectedItem = this.m_a.NewImage;
		}
		else
		{
			((ListControl)this.m_f).SelectedIndex = 0;
		}
	}

	private void i(object A_0, EventArgs A_1)
	{
		this.m_a.NewImage = this.m_f.SelectedItem.ToString();
		if (((ListControl)this.m_f).SelectedIndex > 0)
		{
			PictureBox val = this.m_g;
			object pictureByName = this.m_b.GetPictureByName(this.m_f.SelectedItem.ToString());
			val.Image = (Image)((pictureByName is Image) ? pictureByName : null);
			GamePicture gamePictureByName = this.m_b.GetGamePictureByName(this.m_f.SelectedItem.ToString());
			gamePictureByName.enhinputdata = this.m_a;
			((Control)this.m_g).Tag = gamePictureByName;
			gamePictureByName.Choices.Clear();
			gamePictureByName.Choices.Add("Test Title");
			gamePictureByName.Choices.Add("Choice 1");
			gamePictureByName.Choices.Add("Choice 2");
			gamePictureByName.Choices.Add("Choice 3");
			gamePictureByName.Choices.Add("Choice 4");
			if (this.m_a.bAllowCancel)
			{
				gamePictureByName.Choices.Add("Cancel");
			}
		}
		else
		{
			GamePicture gamePicture = new GamePicture();
			gamePicture.enhinputdata = this.m_a;
			((Control)this.m_g).Tag = gamePicture;
			gamePicture.Choices.Clear();
			gamePicture.Choices.Add("Test Title");
			gamePicture.Choices.Add("Choice 1");
			gamePicture.Choices.Add("Choice 2");
			gamePicture.Choices.Add("Choice 3");
			gamePicture.Choices.Add("Choice 4");
			if (this.m_a.bAllowCancel)
			{
				gamePicture.Choices.Add("Cancel");
			}
		}
	}

	private void a(object A_0, PaintEventArgs A_1)
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected Obj, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected Obj, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected Obj, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Obj, but got Unknown
		if (this.m_b == null || A_0 == null)
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
			object pictureByName = this.m_b.GetPictureByName(layeredImage);
			Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val2 != null)
			{
				A_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
			}
		}
		if (gamePicture.Choices.Count <= 0)
		{
			return;
		}
		int count = gamePicture.Choices.Count;
		float num = ((Control)this.m_g).Width;
		float num2 = ((Control)this.m_g).Height;
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
				try
				{
					val3 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
			SizeF sizeF = new SizeF(num - 20f, height);
			SizeF sizeF2 = A_1.Graphics.MeasureString(empty, val3, sizeF);
			Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
			Point pt = ((Control)this.m_g).PointToClient(Cursor.Position);
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
			A_1.Graphics.DrawString(empty, val3, (Brush)new SolidBrush(gamePicture.enhinputdata.TextColor), (RectangleF)rectangle);
			num3 += rectangle.Height + 5;
		}
	}

	private void h(object A_0, EventArgs A_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		this.m_j.Color = this.m_a.BackgroundColor;
		((CommonDialog)this.m_j).ShowDialog();
		this.m_a.BackgroundColor = this.m_j.Color;
		((Control)this.m_g).Invalidate();
	}

	private void g(object A_0, EventArgs A_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		this.m_j.Color = this.m_a.TextColor;
		((CommonDialog)this.m_j).ShowDialog();
		this.m_a.TextColor = this.m_j.Color;
		((Control)this.m_g).Invalidate();
	}

	private void f(object A_0, EventArgs A_1)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		this.m_i.Font = this.m_a.TextFont;
		((CommonDialog)this.m_i).ShowDialog();
		this.m_a.TextFont = this.m_i.Font;
		((Control)this.m_g).Invalidate();
	}

	private void e(object A_0, EventArgs A_1)
	{
		this.m_a.BackgroundColor = Color.FromArgb(Convert.ToInt32(r.Value), this.m_a.BackgroundColor.R, this.m_a.BackgroundColor.G, this.m_a.BackgroundColor.B);
		((Control)this.m_g).Invalidate();
	}

	private void d(object A_0, EventArgs A_1)
	{
		this.m_a.TextColor = Color.FromArgb(Convert.ToInt32(q.Value), this.m_a.TextColor.R, this.m_a.TextColor.G, this.m_a.TextColor.B);
		((Control)this.m_g).Invalidate();
	}

	private void c(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void b(object A_0, EventArgs A_1)
	{
		this.m_a.bUseEnhancedGraphics = k.Checked;
	}

	private void a(object A_0, EventArgs A_1)
	{
		this.m_a.bAllowCancel = s.Checked;
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
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected Obj, but got Unknown
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_098d: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvancedOverlayFrm));
		this.m_d = new SplitContainer();
		o = new Label();
		p = new Label();
		q = new NumericUpDown();
		r = new NumericUpDown();
		k = new CheckBox();
		l = new Button();
		m = new Button();
		n = new Button();
		this.m_e = new Label();
		this.m_f = new ComboBox();
		this.m_g = new PictureBox();
		this.m_h = new Button();
		this.m_i = new FontDialog();
		this.m_j = new ColorDialog();
		s = new CheckBox();
		((ISupportInitialize)this.m_d).BeginInit();
		((Control)this.m_d.Panel1).SuspendLayout();
		((Control)this.m_d.Panel2).SuspendLayout();
		((Control)this.m_d).SuspendLayout();
		((ISupportInitialize)q).BeginInit();
		((ISupportInitialize)r).BeginInit();
		((ISupportInitialize)this.m_g).BeginInit();
		((Control)this).SuspendLayout();
		this.m_d.BorderStyle = (BorderStyle)1;
		this.m_d.Dock = (DockStyle)5;
		((Control)this.m_d).Location = new Point(0, 0);
		((Control)this.m_d).Name = "splitContainer1";
		this.m_d.Orientation = (Orientation)0;
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)s);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)o);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)p);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)q);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)r);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)k);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)l);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)m);
		((Control)this.m_d.Panel1).Controls.Add((Control)(object)n);
		((Control)this.m_d.Panel2).Controls.Add((Control)(object)this.m_e);
		((Control)this.m_d.Panel2).Controls.Add((Control)(object)this.m_f);
		((Control)this.m_d.Panel2).Controls.Add((Control)(object)this.m_g);
		((Control)this.m_d.Panel2).Controls.Add((Control)(object)this.m_h);
		((Control)this.m_d).Size = new Size(506, 423);
		this.m_d.SplitterDistance = 99;
		((Control)this.m_d).TabIndex = 0;
		((Control)o).AutoSize = true;
		((Control)o).Location = new Point(166, 43);
		((Control)o).Name = "label3";
		((Control)o).Size = new Size(61, 13);
		((Control)o).TabIndex = 7;
		((Control)o).Text = "Text Alpha:";
		((Control)p).AutoSize = true;
		((Control)p).Location = new Point(3, 43);
		((Control)p).Name = "label2";
		((Control)p).Size = new Size(98, 13);
		((Control)p).TabIndex = 6;
		((Control)p).Text = "Background Alpha:";
		((Control)q).Location = new Point(233, 41);
		q.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		((Control)q).Name = "udTextAlpha";
		((Control)q).Size = new Size(55, 20);
		((Control)q).TabIndex = 5;
		q.ValueChanged += d;
		((Control)r).Location = new Point(103, 41);
		r.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		((Control)r).Name = "udBackgroundAlpha";
		((Control)r).Size = new Size(57, 20);
		((Control)r).TabIndex = 4;
		r.ValueChanged += e;
		((Control)k).AutoSize = true;
		((Control)k).Location = new Point(13, 13);
		((Control)k).Name = "cbUseOverlay";
		((Control)k).Size = new Size(129, 17);
		((Control)k).TabIndex = 3;
		((Control)k).Text = "Use Overlay Graphics";
		((ButtonBase)k).UseVisualStyleBackColor = true;
		k.CheckedChanged += b;
		((Control)l).Location = new Point(295, 62);
		((Control)l).Name = "button3";
		((Control)l).Size = new Size(78, 23);
		((Control)l).TabIndex = 2;
		((Control)l).Text = "Change Font";
		((ButtonBase)l).UseVisualStyleBackColor = true;
		((Control)l).Click += f;
		((Control)m).Location = new Point(169, 62);
		((Control)m).Name = "button2";
		((Control)m).Size = new Size(119, 23);
		((Control)m).TabIndex = 1;
		((Control)m).Text = "Change Text Color";
		((ButtonBase)m).UseVisualStyleBackColor = true;
		((Control)m).Click += g;
		((Control)n).Location = new Point(3, 62);
		((Control)n).Name = "button1";
		((Control)n).Size = new Size(157, 23);
		((Control)n).TabIndex = 0;
		((Control)n).Text = "Change Background Color";
		((ButtonBase)n).UseVisualStyleBackColor = true;
		((Control)n).Click += h;
		((Control)this.m_e).AutoSize = true;
		((Control)this.m_e).Location = new Point(3, 0);
		((Control)this.m_e).Name = "label1";
		((Control)this.m_e).Size = new Size(144, 13);
		((Control)this.m_e).TabIndex = 4;
		((Control)this.m_e).Text = "Change Displayed Image To:";
		((ListControl)this.m_f).FormattingEnabled = true;
		((Control)this.m_f).Location = new Point(3, 16);
		((Control)this.m_f).Name = "cbPicture";
		((Control)this.m_f).Size = new Size(169, 21);
		((Control)this.m_f).TabIndex = 3;
		this.m_f.SelectedIndexChanged += i;
		((Control)this.m_g).Anchor = (AnchorStyles)15;
		((Control)this.m_g).Location = new Point(3, 43);
		((Control)this.m_g).Name = "pbPreview";
		((Control)this.m_g).Size = new Size(498, 246);
		this.m_g.SizeMode = (PictureBoxSizeMode)4;
		this.m_g.TabIndex = 2;
		this.m_g.TabStop = false;
		((Control)this.m_g).Paint += a;
		((Control)this.m_h).Anchor = (AnchorStyles)6;
		((Control)this.m_h).Location = new Point(0, 295);
		((Control)this.m_h).Name = "btnApply";
		((Control)this.m_h).Size = new Size(75, 23);
		((Control)this.m_h).TabIndex = 0;
		((Control)this.m_h).Text = "Done";
		((ButtonBase)this.m_h).UseVisualStyleBackColor = true;
		((Control)this.m_h).Click += c;
		this.m_j.AnyColor = true;
		this.m_j.FullOpen = true;
		((Control)s).AutoSize = true;
		s.Checked = true;
		s.CheckState = (CheckState)1;
		((Control)s).Location = new Point(148, 13);
		((Control)s).Name = "cbAllowCancel";
		((Control)s).Size = new Size(87, 17);
		((Control)s).TabIndex = 8;
		((Control)s).Text = "Allow Cancel";
		((ButtonBase)s).UseVisualStyleBackColor = true;
		s.CheckedChanged += a;
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_h;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(506, 423);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AdvancedOverlayFrm";
		((Control)this).Text = "Advanced Overlay Form";
		((Form)this).Load += j;
		((Control)this.m_d.Panel1).ResumeLayout(false);
		((Control)this.m_d.Panel1).PerformLayout();
		((Control)this.m_d.Panel2).ResumeLayout(false);
		((Control)this.m_d.Panel2).PerformLayout();
		((ISupportInitialize)this.m_d).EndInit();
		((Control)this.m_d).ResumeLayout(false);
		((ISupportInitialize)q).EndInit();
		((ISupportInitialize)r).EndInit();
		((ISupportInitialize)this.m_g).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
