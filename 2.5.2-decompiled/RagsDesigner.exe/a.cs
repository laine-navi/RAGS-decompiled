using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Rags;

internal class a : Form
{
	private IContainer m_a;

	private TableLayoutPanel b;

	private PictureBox c;

	private Label d;

	private Label e;

	private Label f;

	private Label m_g;

	private TextBox m_h;

	private Button m_i;

	private Label m_j;

	public a(string A_0)
	{
		g();
		((Control)this).Text = $"About {h()}";
		if (LockData.IsLicensed(bdisplay: false, A_0))
		{
			((Control)d).Text = k() + " Registered";
			((Control)this.m_j).Text = "Expires:" + LockData.GetExpirationDate();
		}
		else
		{
			((Control)d).Text = k() + " Trial Version";
		}
		((Control)e).Text = $"Version {i()}";
		((Control)f).Text = l();
		((Control)this.m_g).Text = m();
		((Control)this.m_h).Text = j();
	}

	[SpecialName]
	public string h()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
			if (assemblyTitleAttribute.Title != "")
			{
				return assemblyTitleAttribute.Title;
			}
		}
		return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
	}

	[SpecialName]
	public string i()
	{
		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}

	[SpecialName]
	public string j()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return "";
		}
		return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
	}

	[SpecialName]
	public string k()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return "";
		}
		return ((AssemblyProductAttribute)customAttributes[0]).Product;
	}

	[SpecialName]
	public string l()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return "";
		}
		return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
	}

	[SpecialName]
	public string m()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return "";
		}
		return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && m_a != null)
		{
			m_a.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void g()
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
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected Obj, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected Obj, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected Obj, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected Obj, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected Obj, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Obj, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected Obj, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Expected Obj, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(a));
		b = new TableLayoutPanel();
		c = new PictureBox();
		d = new Label();
		e = new Label();
		f = new Label();
		this.m_g = new Label();
		this.m_h = new TextBox();
		this.m_i = new Button();
		this.m_j = new Label();
		((Control)b).SuspendLayout();
		((ISupportInitialize)c).BeginInit();
		((Control)this).SuspendLayout();
		b.ColumnCount = 2;
		b.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33f));
		b.ColumnStyles.Add(new ColumnStyle((SizeType)2, 67f));
		b.Controls.Add((Control)(object)c, 0, 0);
		b.Controls.Add((Control)(object)d, 1, 0);
		b.Controls.Add((Control)(object)e, 1, 2);
		b.Controls.Add((Control)(object)f, 1, 3);
		b.Controls.Add((Control)(object)this.m_g, 1, 4);
		b.Controls.Add((Control)(object)this.m_h, 1, 5);
		b.Controls.Add((Control)(object)this.m_i, 1, 6);
		b.Controls.Add((Control)(object)this.m_j, 1, 1);
		((Control)b).Dock = (DockStyle)5;
		((Control)b).Location = new Point(9, 9);
		((Control)b).Name = "tableLayoutPanel";
		b.RowCount = 7;
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 40f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)b).Size = new Size(417, 265);
		((Control)b).TabIndex = 0;
		((Control)c).Dock = (DockStyle)5;
		c.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
		((Control)c).Location = new Point(3, 3);
		((Control)c).Name = "logoPictureBox";
		b.SetRowSpan((Control)(object)c, 7);
		((Control)c).Size = new Size(131, 259);
		c.SizeMode = (PictureBoxSizeMode)4;
		c.TabIndex = 12;
		c.TabStop = false;
		((Control)d).Dock = (DockStyle)5;
		((Control)d).Location = new Point(143, 0);
		((Control)d).Margin = new Padding(6, 0, 3, 0);
		((Control)d).MaximumSize = new Size(0, 17);
		((Control)d).Name = "labelProductName";
		((Control)d).Size = new Size(271, 17);
		((Control)d).TabIndex = 19;
		((Control)d).Text = "Rags Designer";
		d.TextAlign = (ContentAlignment)16;
		((Control)e).Dock = (DockStyle)5;
		((Control)e).Location = new Point(143, 52);
		((Control)e).Margin = new Padding(6, 0, 3, 0);
		((Control)e).MaximumSize = new Size(0, 17);
		((Control)e).Name = "labelVersion";
		((Control)e).Size = new Size(271, 17);
		((Control)e).TabIndex = 0;
		((Control)e).Text = "Version: 0.6";
		e.TextAlign = (ContentAlignment)16;
		((Control)f).Dock = (DockStyle)5;
		((Control)f).Location = new Point(143, 78);
		((Control)f).Margin = new Padding(6, 0, 3, 0);
		((Control)f).MaximumSize = new Size(0, 17);
		((Control)f).Name = "labelCopyright";
		((Control)f).Size = new Size(271, 17);
		((Control)f).TabIndex = 21;
		((Control)f).Text = "Copyright 2007";
		f.TextAlign = (ContentAlignment)16;
		((Control)this.m_g).Dock = (DockStyle)5;
		((Control)this.m_g).Location = new Point(143, 104);
		((Control)this.m_g).Margin = new Padding(6, 0, 3, 0);
		((Control)this.m_g).MaximumSize = new Size(0, 17);
		((Control)this.m_g).Name = "labelCompanyName";
		((Control)this.m_g).Size = new Size(271, 17);
		((Control)this.m_g).TabIndex = 22;
		((Control)this.m_g).Text = "Rags Game LLC";
		this.m_g.TextAlign = (ContentAlignment)16;
		((Control)this.m_h).Dock = (DockStyle)5;
		((Control)this.m_h).Location = new Point(143, 133);
		((Control)this.m_h).Margin = new Padding(6, 3, 3, 3);
		((TextBoxBase)this.m_h).Multiline = true;
		((Control)this.m_h).Name = "textBoxDescription";
		((TextBoxBase)this.m_h).ReadOnly = true;
		this.m_h.ScrollBars = (ScrollBars)3;
		((Control)this.m_h).Size = new Size(271, 100);
		((Control)this.m_h).TabIndex = 23;
		((Control)this.m_h).TabStop = false;
		((Control)this.m_h).Text = "Rags Game Designer creates fun exciting interactive fiction games.  For more information, visit http://www.ragsgame.com";
		((Control)this.m_i).Anchor = (AnchorStyles)10;
		this.m_i.DialogResult = (DialogResult)2;
		((Control)this.m_i).Location = new Point(339, 239);
		((Control)this.m_i).Name = "okButton";
		((Control)this.m_i).Size = new Size(75, 23);
		((Control)this.m_i).TabIndex = 24;
		((Control)this.m_i).Text = "&OK";
		((Control)this.m_j).AutoSize = true;
		((Control)this.m_j).Location = new Point(143, 26);
		((Control)this.m_j).Margin = new Padding(6, 0, 3, 0);
		((Control)this.m_j).Name = "labelExpirationDate";
		((Control)this.m_j).Size = new Size(82, 13);
		((Control)this.m_j).TabIndex = 25;
		((Control)this.m_j).Text = "Expiration Date:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(435, 283);
		((Control)this).Controls.Add((Control)(object)b);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AboutBox";
		((Control)this).Padding = new Padding(9);
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "AboutBox";
		((Control)b).ResumeLayout(false);
		((Control)b).PerformLayout();
		((ISupportInitialize)c).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
