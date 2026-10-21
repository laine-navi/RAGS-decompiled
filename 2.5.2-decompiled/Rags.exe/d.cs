using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class d : Form
{
	private IContainer a;

	private TableLayoutPanel b;

	private PictureBox c;

	private Label m_d;

	private Label e;

	private Label f;

	private Label m_g;

	private TextBox m_h;

	private Button m_i;

	public d()
	{
		g();
		((Control)this).Text = $"About {h()}";
		((Control)m_d).Text = k();
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
		if (disposing && a != null)
		{
			a.Dispose();
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
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected Obj, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected Obj, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected Obj, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Expected Obj, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(d));
		b = new TableLayoutPanel();
		c = new PictureBox();
		m_d = new Label();
		e = new Label();
		f = new Label();
		this.m_g = new Label();
		this.m_h = new TextBox();
		this.m_i = new Button();
		((Control)b).SuspendLayout();
		((ISupportInitialize)c).BeginInit();
		((Control)this).SuspendLayout();
		b.ColumnCount = 2;
		b.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33f));
		b.ColumnStyles.Add(new ColumnStyle((SizeType)2, 67f));
		b.Controls.Add((Control)(object)c, 0, 0);
		b.Controls.Add((Control)(object)m_d, 1, 0);
		b.Controls.Add((Control)(object)e, 1, 1);
		b.Controls.Add((Control)(object)f, 1, 2);
		b.Controls.Add((Control)(object)this.m_g, 1, 3);
		b.Controls.Add((Control)(object)this.m_h, 1, 4);
		b.Controls.Add((Control)(object)this.m_i, 1, 5);
		((Control)b).Dock = (DockStyle)5;
		((Control)b).Location = new Point(9, 9);
		((Control)b).Name = "tableLayoutPanel";
		b.RowCount = 6;
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		b.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		((Control)b).Size = new Size(417, 265);
		((Control)b).TabIndex = 0;
		((Control)c).Dock = (DockStyle)5;
		c.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
		((Control)c).Location = new Point(3, 3);
		((Control)c).Name = "logoPictureBox";
		b.SetRowSpan((Control)(object)c, 6);
		((Control)c).Size = new Size(131, 259);
		c.SizeMode = (PictureBoxSizeMode)4;
		c.TabIndex = 12;
		c.TabStop = false;
		((Control)m_d).Dock = (DockStyle)5;
		((Control)m_d).Location = new Point(143, 0);
		((Control)m_d).Margin = new Padding(6, 0, 3, 0);
		((Control)m_d).MaximumSize = new Size(0, 17);
		((Control)m_d).Name = "labelProductName";
		((Control)m_d).Size = new Size(271, 17);
		((Control)m_d).TabIndex = 19;
		((Control)m_d).Text = "Rags Player";
		m_d.TextAlign = (ContentAlignment)16;
		((Control)e).Dock = (DockStyle)5;
		((Control)e).Location = new Point(143, 26);
		((Control)e).Margin = new Padding(6, 0, 3, 0);
		((Control)e).MaximumSize = new Size(0, 17);
		((Control)e).Name = "labelVersion";
		((Control)e).Size = new Size(271, 17);
		((Control)e).TabIndex = 0;
		((Control)e).Text = "Version: 0.6";
		e.TextAlign = (ContentAlignment)16;
		((Control)f).Dock = (DockStyle)5;
		((Control)f).Location = new Point(143, 52);
		((Control)f).Margin = new Padding(6, 0, 3, 0);
		((Control)f).MaximumSize = new Size(0, 17);
		((Control)f).Name = "labelCopyright";
		((Control)f).Size = new Size(271, 17);
		((Control)f).TabIndex = 21;
		((Control)f).Text = "Copyright 2007";
		f.TextAlign = (ContentAlignment)16;
		((Control)this.m_g).Dock = (DockStyle)5;
		((Control)this.m_g).Location = new Point(143, 78);
		((Control)this.m_g).Margin = new Padding(6, 0, 3, 0);
		((Control)this.m_g).MaximumSize = new Size(0, 17);
		((Control)this.m_g).Name = "labelCompanyName";
		((Control)this.m_g).Size = new Size(271, 17);
		((Control)this.m_g).TabIndex = 22;
		((Control)this.m_g).Text = "Rags Game LLC";
		this.m_g.TextAlign = (ContentAlignment)16;
		((Control)this.m_h).Dock = (DockStyle)5;
		((Control)this.m_h).Location = new Point(143, 107);
		((Control)this.m_h).Margin = new Padding(6, 3, 3, 3);
		((TextBoxBase)this.m_h).Multiline = true;
		((Control)this.m_h).Name = "textBoxDescription";
		((TextBoxBase)this.m_h).ReadOnly = true;
		this.m_h.ScrollBars = (ScrollBars)3;
		((Control)this.m_h).Size = new Size(271, 126);
		((Control)this.m_h).TabIndex = 23;
		((Control)this.m_h).TabStop = false;
		((Control)this.m_h).Text = "Rags Player runs fun exciting interactive fiction games created by game designers.  To design your own Rags games, please run the Rags Designer.  For more information, visit http://www.ragsgame.com";
		((Control)this.m_i).Anchor = (AnchorStyles)10;
		this.m_i.DialogResult = (DialogResult)2;
		((Control)this.m_i).Location = new Point(339, 239);
		((Control)this.m_i).Name = "okButton";
		((Control)this.m_i).Size = new Size(75, 23);
		((Control)this.m_i).TabIndex = 24;
		((Control)this.m_i).Text = "&OK";
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_i;
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
