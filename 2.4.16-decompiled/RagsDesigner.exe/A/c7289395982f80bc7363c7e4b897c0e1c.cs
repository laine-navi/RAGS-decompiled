using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Rags;

namespace A;

internal sealed class c7289395982f80bc7363c7e4b897c0e1c : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private TableLayoutPanel ca15b744aabb1b4e49bfaafb61515c5de;

	private PictureBox ca0a3fe0deafb025517985a6a6652cefc;

	private Label c9eaf46f63008950a8f77221c05d81117;

	private Label c4c4bfc424b08d2ca30b673746be617af;

	private Label cb3b685c7c62563f9544d04be232cefd2;

	private Label cd15a156921fb8b68876df1bfdaafc83a;

	private TextBox c82088f60cab30732ff6dd78cac9c5f73;

	private Button c248c919acb4b5541e67f220d8f73c589;

	private Label c4f8c280e48b8ee5c6a488614fa83920d;

	public c7289395982f80bc7363c7e4b897c0e1c(string P_0)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		((Control)this).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47045), c1083f8b54de87c170548ee95c70ee032());
		if (!LockData.IsLicensed(bdisplay: false, P_0))
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c._002Ector(string));
			((Control)c9eaf46f63008950a8f77221c05d81117).Text = c46fc6c46646e8e6ac96084bb16a07033() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47104);
		}
		else
		{
			((Control)c9eaf46f63008950a8f77221c05d81117).Text = c46fc6c46646e8e6ac96084bb16a07033() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47064);
			((Control)c4f8c280e48b8ee5c6a488614fa83920d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47087) + LockData.GetExpirationDate();
		}
		((Control)c4c4bfc424b08d2ca30b673746be617af).Text = string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47133), cce0b8ac62984521b8671768f15017335());
		((Control)cb3b685c7c62563f9544d04be232cefd2).Text = ca5f1598f52e5a1d85773532a80ba2c95();
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Text = c62e0c7f46d9edef11610552726e4da02();
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Text = c78d011907dd339942a158bdedcaaa8da();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected Obj, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected Obj, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected Obj, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected Obj, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected Obj, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected Obj, but got Unknown
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(c7289395982f80bc7363c7e4b897c0e1c));
		ca15b744aabb1b4e49bfaafb61515c5de = new TableLayoutPanel();
		ca0a3fe0deafb025517985a6a6652cefc = new PictureBox();
		c9eaf46f63008950a8f77221c05d81117 = new Label();
		c4c4bfc424b08d2ca30b673746be617af = new Label();
		cb3b685c7c62563f9544d04be232cefd2 = new Label();
		cd15a156921fb8b68876df1bfdaafc83a = new Label();
		c82088f60cab30732ff6dd78cac9c5f73 = new TextBox();
		c248c919acb4b5541e67f220d8f73c589 = new Button();
		c4f8c280e48b8ee5c6a488614fa83920d = new Label();
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).SuspendLayout();
		((ISupportInitialize)ca0a3fe0deafb025517985a6a6652cefc).BeginInit();
		((Control)this).SuspendLayout();
		ca15b744aabb1b4e49bfaafb61515c5de.ColumnCount = 2;
		ca15b744aabb1b4e49bfaafb61515c5de.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33f));
		ca15b744aabb1b4e49bfaafb61515c5de.ColumnStyles.Add(new ColumnStyle((SizeType)2, 67f));
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)ca0a3fe0deafb025517985a6a6652cefc, 0, 0);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)c9eaf46f63008950a8f77221c05d81117, 1, 0);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)c4c4bfc424b08d2ca30b673746be617af, 1, 2);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)cb3b685c7c62563f9544d04be232cefd2, 1, 3);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)cd15a156921fb8b68876df1bfdaafc83a, 1, 4);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)c82088f60cab30732ff6dd78cac9c5f73, 1, 5);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)c248c919acb4b5541e67f220d8f73c589, 1, 6);
		ca15b744aabb1b4e49bfaafb61515c5de.Controls.Add((Control)(object)c4f8c280e48b8ee5c6a488614fa83920d, 1, 1);
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).Dock = (DockStyle)5;
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).Location = new Point(9, 9);
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46351);
		ca15b744aabb1b4e49bfaafb61515c5de.RowCount = 7;
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 40f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		ca15b744aabb1b4e49bfaafb61515c5de.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).Size = new Size(417, 265);
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).TabIndex = 0;
		((Control)ca0a3fe0deafb025517985a6a6652cefc).Dock = (DockStyle)5;
		ca0a3fe0deafb025517985a6a6652cefc.Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46384));
		((Control)ca0a3fe0deafb025517985a6a6652cefc).Location = new Point(3, 3);
		((Control)ca0a3fe0deafb025517985a6a6652cefc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46425);
		ca15b744aabb1b4e49bfaafb61515c5de.SetRowSpan((Control)(object)ca0a3fe0deafb025517985a6a6652cefc, 7);
		((Control)ca0a3fe0deafb025517985a6a6652cefc).Size = new Size(131, 259);
		ca0a3fe0deafb025517985a6a6652cefc.SizeMode = (PictureBoxSizeMode)4;
		ca0a3fe0deafb025517985a6a6652cefc.TabIndex = 12;
		ca0a3fe0deafb025517985a6a6652cefc.TabStop = false;
		((Control)c9eaf46f63008950a8f77221c05d81117).Dock = (DockStyle)5;
		((Control)c9eaf46f63008950a8f77221c05d81117).Location = new Point(143, 0);
		((Control)c9eaf46f63008950a8f77221c05d81117).Margin = new Padding(6, 0, 3, 0);
		((Control)c9eaf46f63008950a8f77221c05d81117).MaximumSize = new Size(0, 17);
		((Control)c9eaf46f63008950a8f77221c05d81117).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46454);
		((Control)c9eaf46f63008950a8f77221c05d81117).Size = new Size(271, 17);
		((Control)c9eaf46f63008950a8f77221c05d81117).TabIndex = 19;
		((Control)c9eaf46f63008950a8f77221c05d81117).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(26314);
		c9eaf46f63008950a8f77221c05d81117.TextAlign = (ContentAlignment)16;
		((Control)c4c4bfc424b08d2ca30b673746be617af).Dock = (DockStyle)5;
		((Control)c4c4bfc424b08d2ca30b673746be617af).Location = new Point(143, 52);
		((Control)c4c4bfc424b08d2ca30b673746be617af).Margin = new Padding(6, 0, 3, 0);
		((Control)c4c4bfc424b08d2ca30b673746be617af).MaximumSize = new Size(0, 17);
		((Control)c4c4bfc424b08d2ca30b673746be617af).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46487);
		((Control)c4c4bfc424b08d2ca30b673746be617af).Size = new Size(271, 17);
		((Control)c4c4bfc424b08d2ca30b673746be617af).TabIndex = 0;
		((Control)c4c4bfc424b08d2ca30b673746be617af).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46512);
		c4c4bfc424b08d2ca30b673746be617af.TextAlign = (ContentAlignment)16;
		((Control)cb3b685c7c62563f9544d04be232cefd2).Dock = (DockStyle)5;
		((Control)cb3b685c7c62563f9544d04be232cefd2).Location = new Point(143, 78);
		((Control)cb3b685c7c62563f9544d04be232cefd2).Margin = new Padding(6, 0, 3, 0);
		((Control)cb3b685c7c62563f9544d04be232cefd2).MaximumSize = new Size(0, 17);
		((Control)cb3b685c7c62563f9544d04be232cefd2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46537);
		((Control)cb3b685c7c62563f9544d04be232cefd2).Size = new Size(271, 17);
		((Control)cb3b685c7c62563f9544d04be232cefd2).TabIndex = 21;
		((Control)cb3b685c7c62563f9544d04be232cefd2).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46566);
		cb3b685c7c62563f9544d04be232cefd2.TextAlign = (ContentAlignment)16;
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Dock = (DockStyle)5;
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Location = new Point(143, 104);
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Margin = new Padding(6, 0, 3, 0);
		((Control)cd15a156921fb8b68876df1bfdaafc83a).MaximumSize = new Size(0, 17);
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46595);
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Size = new Size(271, 17);
		((Control)cd15a156921fb8b68876df1bfdaafc83a).TabIndex = 22;
		((Control)cd15a156921fb8b68876df1bfdaafc83a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46628);
		cd15a156921fb8b68876df1bfdaafc83a.TextAlign = (ContentAlignment)16;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Dock = (DockStyle)5;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Location = new Point(143, 133);
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Margin = new Padding(6, 3, 3, 3);
		((TextBoxBase)c82088f60cab30732ff6dd78cac9c5f73).Multiline = true;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46655);
		((TextBoxBase)c82088f60cab30732ff6dd78cac9c5f73).ReadOnly = true;
		c82088f60cab30732ff6dd78cac9c5f73.ScrollBars = (ScrollBars)3;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Size = new Size(271, 100);
		((Control)c82088f60cab30732ff6dd78cac9c5f73).TabIndex = 23;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).TabStop = false;
		((Control)c82088f60cab30732ff6dd78cac9c5f73).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46692);
		((Control)c248c919acb4b5541e67f220d8f73c589).Anchor = (AnchorStyles)10;
		c248c919acb4b5541e67f220d8f73c589.DialogResult = (DialogResult)2;
		((Control)c248c919acb4b5541e67f220d8f73c589).Location = new Point(339, 239);
		((Control)c248c919acb4b5541e67f220d8f73c589).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46932);
		((Control)c248c919acb4b5541e67f220d8f73c589).Size = new Size(75, 23);
		((Control)c248c919acb4b5541e67f220d8f73c589).TabIndex = 24;
		((Control)c248c919acb4b5541e67f220d8f73c589).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46949);
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).AutoSize = true;
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).Location = new Point(143, 26);
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).Margin = new Padding(6, 0, 3, 0);
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46956);
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).Size = new Size(82, 13);
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).TabIndex = 25;
		((Control)c4f8c280e48b8ee5c6a488614fa83920d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46995);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(435, 283);
		((Control)this).Controls.Add((Control)(object)ca15b744aabb1b4e49bfaafb61515c5de);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47028);
		((Control)this).Padding = new Padding(9);
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47028);
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).ResumeLayout(false);
		((Control)ca15b744aabb1b4e49bfaafb61515c5de).PerformLayout();
		((ISupportInitialize)ca0a3fe0deafb025517985a6a6652cefc).EndInit();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	public string c1083f8b54de87c170548ee95c70ee032()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
		if (customAttributes.Length <= 0)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.c1083f8b54de87c170548ee95c70ee032());
		}
		else
		{
			AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
			if (assemblyTitleAttribute.Title != "")
			{
				return assemblyTitleAttribute.Title;
			}
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.c1083f8b54de87c170548ee95c70ee032());
		}
		return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
	}

	[SpecialName]
	public string cce0b8ac62984521b8671768f15017335()
	{
		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}

	[SpecialName]
	public string c78d011907dd339942a158bdedcaaa8da()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.c78d011907dd339942a158bdedcaaa8da());
			return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
		}
		return "";
	}

	[SpecialName]
	public string c46fc6c46646e8e6ac96084bb16a07033()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.c46fc6c46646e8e6ac96084bb16a07033());
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}
		return "";
	}

	[SpecialName]
	public string ca5f1598f52e5a1d85773532a80ba2c95()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return "";
		}
		return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
	}

	[SpecialName]
	public string c62e0c7f46d9edef11610552726e4da02()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			__ldtoken(c7289395982f80bc7363c7e4b897c0e1c.c62e0c7f46d9edef11610552726e4da02());
			return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
		}
		return "";
	}
}
