using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using A;
using TachyonLabs.SharpSpell;
using TachyonLabs.SharpSpell.UI;

namespace Rags;

public sealed class RagsEditor : Form
{
	private enum c18b701edbfa2c7e425723ba328be3d3a
	{
		c37fe68812c6df70f9ffa3abac5929ca8,
		c6cc2f23b75767ed7446cd58889955d9c,
		c9c7d271dc006f3bbe99851506567cfef,
		cad98d0efe683080712dc4f8d0afa900a,
		ca6dfb7a66c6a093c337493d390d39ca4
	}

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private RichTextBox cc0729005b502cc37c5f85802adf02a1f;

	private ToolStrip cf646fef84808e9c119ee9938412e8509;

	private ToolStripButton cac05af01102157bd3046ca8fd80ec66b;

	private ToolStripButton cc1c25956fc9ae13af685d6e3746c1a2d;

	private ToolStripButton cc0bd25647b275dbe430568cdf6e9ae35;

	private ToolStripSeparator ce9370b9cfd4cdfd0550e5275892b148d;

	private ToolStripButton c0ec5e791c10b36605a6c3acf2cecc5a7;

	private ToolStripButton cfdfba3a62727d7580b931eb4978dbb9f;

	private ColorDialog cb50e1b6024cdcdd498e9f83018fc0f18;

	private Button c9912dc5182d7219d9182dd331caae777;

	private Button cad062cb240d8f3ea2aa4cedf8f7b42c8;

	private ToolStripButton ce6e414f8fa7df0d24d1f2538cfff94a6;

	private Button cd0fca5dcac9a20b07d24381e7cf6b948;

	private FontDialog cc8264b1067fe196be453410d7902dac7;

	private ToolStripButton ccf6865be3b7ba4e4b90a5361030a29d0;

	private Button c88287a58c46e1b303bd5f5fbbb4bd0a6;

	private SharpSpellLive c1ef940cdb8be768145bbb7ae47e0f539;

	private Misspelling c7bb5165260e0c08dddb1e063c4ff940b;

	private c18b701edbfa2c7e425723ba328be3d3a cabb4ea3f275636e5e480474aff0a69d9;

	public object controlref;

	private string c0f22792252252f15b9fccc7fb865cdae = string.Empty;

	private Game c54f9a911545745b85ae6f74355697f8b;

	private Action c19eccfa624303fec4c7385f816c8f146;

	public RagsEditor(ref TextBox control, Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cabb4ea3f275636e5e480474aff0a69d9 = c18b701edbfa2c7e425723ba328be3d3a.c37fe68812c6df70f9ffa3abac5929ca8;
		controlref = control;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)control).Text;
		c54f9a911545745b85ae6f74355697f8b = curgame;
	}

	public RagsEditor(ref Action curAction)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cabb4ea3f275636e5e480474aff0a69d9 = c18b701edbfa2c7e425723ba328be3d3a.ca6dfb7a66c6a093c337493d390d39ca4;
		c19eccfa624303fec4c7385f816c8f146 = curAction;
		StringBuilder CurDoc = new StringBuilder();
		c19eccfa624303fec4c7385f816c8f146.GetAdvancedText(ref CurDoc);
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = CurDoc.ToString();
	}

	public RagsEditor(ref RichTextBox control, Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cabb4ea3f275636e5e480474aff0a69d9 = c18b701edbfa2c7e425723ba328be3d3a.c9c7d271dc006f3bbe99851506567cfef;
		controlref = control;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)control).Text;
		c54f9a911545745b85ae6f74355697f8b = curgame;
	}

	public RagsEditor(ref ComboBox control, Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cabb4ea3f275636e5e480474aff0a69d9 = c18b701edbfa2c7e425723ba328be3d3a.c6cc2f23b75767ed7446cd58889955d9c;
		controlref = control;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)control).Text;
		c54f9a911545745b85ae6f74355697f8b = curgame;
	}

	public RagsEditor(ref DataGridViewCell control, Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cabb4ea3f275636e5e480474aff0a69d9 = c18b701edbfa2c7e425723ba328be3d3a.cad98d0efe683080712dc4f8d0afa900a;
		controlref = control;
		if (control.Value == null)
		{
			__ldtoken(RagsEditor._002Ector(ref DataGridViewCell, Game));
			((Control)cc0729005b502cc37c5f85802adf02a1f).Text = string.Empty;
		}
		else
		{
			((Control)cc0729005b502cc37c5f85802adf02a1f).Text = control.Value.ToString();
		}
		c54f9a911545745b85ae6f74355697f8b = curgame;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(RagsEditor.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(RagsEditor.Dispose(bool));
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
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected Obj, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected Obj, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected Obj, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected Obj, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected Obj, but got Unknown
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Expected Obj, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Expected Obj, but got Unknown
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Expected Obj, but got Unknown
		//IL_09c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cc: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RagsEditor));
		cc0729005b502cc37c5f85802adf02a1f = new RichTextBox();
		cf646fef84808e9c119ee9938412e8509 = new ToolStrip();
		cac05af01102157bd3046ca8fd80ec66b = new ToolStripButton();
		cc1c25956fc9ae13af685d6e3746c1a2d = new ToolStripButton();
		cc0bd25647b275dbe430568cdf6e9ae35 = new ToolStripButton();
		ce9370b9cfd4cdfd0550e5275892b148d = new ToolStripSeparator();
		c0ec5e791c10b36605a6c3acf2cecc5a7 = new ToolStripButton();
		cfdfba3a62727d7580b931eb4978dbb9f = new ToolStripButton();
		ce6e414f8fa7df0d24d1f2538cfff94a6 = new ToolStripButton();
		ccf6865be3b7ba4e4b90a5361030a29d0 = new ToolStripButton();
		cb50e1b6024cdcdd498e9f83018fc0f18 = new ColorDialog();
		c9912dc5182d7219d9182dd331caae777 = new Button();
		cad062cb240d8f3ea2aa4cedf8f7b42c8 = new Button();
		cd0fca5dcac9a20b07d24381e7cf6b948 = new Button();
		cc8264b1067fe196be453410d7902dac7 = new FontDialog();
		c88287a58c46e1b303bd5f5fbbb4bd0a6 = new Button();
		c1ef940cdb8be768145bbb7ae47e0f539 = new SharpSpellLive();
		((Control)cf646fef84808e9c119ee9938412e8509).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)cc0729005b502cc37c5f85802adf02a1f).Anchor = (AnchorStyles)15;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Location = new Point(12, 28);
		((Control)cc0729005b502cc37c5f85802adf02a1f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105240);
		((Control)cc0729005b502cc37c5f85802adf02a1f).Size = new Size(564, 394);
		((Control)cc0729005b502cc37c5f85802adf02a1f).TabIndex = 0;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = "";
		cf646fef84808e9c119ee9938412e8509.Items.AddRange(new ToolStripItem[8]
		{
			(ToolStripItem)cac05af01102157bd3046ca8fd80ec66b,
			(ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d,
			(ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35,
			(ToolStripItem)ce9370b9cfd4cdfd0550e5275892b148d,
			(ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7,
			(ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f,
			(ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6,
			(ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0
		});
		((Control)cf646fef84808e9c119ee9938412e8509).Location = new Point(0, 0);
		((Control)cf646fef84808e9c119ee9938412e8509).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105253);
		((Control)cf646fef84808e9c119ee9938412e8509).Size = new Size(588, 25);
		((Control)cf646fef84808e9c119ee9938412e8509).TabIndex = 1;
		((Control)cf646fef84808e9c119ee9938412e8509).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105253);
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105274));
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105319);
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).Size = new Size(31, 22);
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105352);
		((ToolStripItem)cac05af01102157bd3046ca8fd80ec66b).Click += c5cf8bc3536654c97fae1d12ea5d627df;
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105361));
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105406);
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).Size = new Size(34, 22);
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105439);
		((ToolStripItem)cc1c25956fc9ae13af685d6e3746c1a2d).Click += c6e0d7055c6d9bdd2e022ddf0cbfb359a;
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105452));
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105497);
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).Size = new Size(66, 22);
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105530);
		((ToolStripItem)cc0bd25647b275dbe430568cdf6e9ae35).Click += c93a21c9fe56c6b18e15fcbb6199d5040;
		((ToolStripItem)ce9370b9cfd4cdfd0550e5275892b148d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105551);
		((ToolStripItem)ce9370b9cfd4cdfd0550e5275892b148d).Size = new Size(6, 25);
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105590));
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105635);
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).Size = new Size(36, 22);
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105668);
		((ToolStripItem)c0ec5e791c10b36605a6c3acf2cecc5a7).Click += c0347e7f82cdb4c42d3829d8adce43c8b;
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105679));
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105724);
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).Size = new Size(33, 22);
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105757);
		((ToolStripItem)cfdfba3a62727d7580b931eb4978dbb9f).Click += c41b8f83f13c26607f1fc2981e51408ce;
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105766));
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105811);
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).Size = new Size(41, 22);
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105844);
		((ToolStripItem)ce6e414f8fa7df0d24d1f2538cfff94a6).Click += c7ca55656a2d87214bf77d656edcb94b4;
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).Image = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105857));
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105902);
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).Size = new Size(54, 22);
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105935);
		((ToolStripItem)ccf6865be3b7ba4e4b90a5361030a29d0).Click += ccfd0e822360be1db3268bc0d8ac5e1ba;
		((Control)c9912dc5182d7219d9182dd331caae777).Anchor = (AnchorStyles)2;
		((Control)c9912dc5182d7219d9182dd331caae777).Location = new Point(200, 429);
		((Control)c9912dc5182d7219d9182dd331caae777).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105956);
		((Control)c9912dc5182d7219d9182dd331caae777).Size = new Size(75, 23);
		((Control)c9912dc5182d7219d9182dd331caae777).TabIndex = 2;
		((Control)c9912dc5182d7219d9182dd331caae777).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105973);
		((ButtonBase)c9912dc5182d7219d9182dd331caae777).UseVisualStyleBackColor = true;
		((Control)c9912dc5182d7219d9182dd331caae777).Click += c4ae2942e8a8490f245d8e62e8457341c;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Anchor = (AnchorStyles)2;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Location = new Point(314, 429);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(511);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Size = new Size(75, 23);
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).TabIndex = 3;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(530);
		((ButtonBase)cad062cb240d8f3ea2aa4cedf8f7b42c8).UseVisualStyleBackColor = true;
		((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Click += ccf3da658dce1d38918f914da56805590;
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Anchor = (AnchorStyles)6;
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Location = new Point(12, 429);
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105984);
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Size = new Size(100, 23);
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).TabIndex = 4;
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106013);
		((ButtonBase)cd0fca5dcac9a20b07d24381e7cf6b948).UseVisualStyleBackColor = true;
		((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Click += caaa37a0912ccff1858a999f9f6a9c32b;
		cc8264b1067fe196be453410d7902dac7.ShowEffects = false;
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Anchor = (AnchorStyles)10;
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Enabled = false;
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Location = new Point(484, 428);
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106038);
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Size = new Size(91, 23);
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).TabIndex = 5;
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106057);
		((ButtonBase)c88287a58c46e1b303bd5f5fbbb4bd0a6).UseVisualStyleBackColor = true;
		((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Click += c7a8901f0fb02570860cc06617ead82e9;
		c1ef940cdb8be768145bbb7ae47e0f539.IgnoreXml = false;
		c1ef940cdb8be768145bbb7ae47e0f539.TextBox = (TextBoxBase)(object)cc0729005b502cc37c5f85802adf02a1f;
		c1ef940cdb8be768145bbb7ae47e0f539.DisplayMenu += cad9bf09f89721b295fdc85110a553076;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(588, 454);
		((Control)this).Controls.Add((Control)(object)c88287a58c46e1b303bd5f5fbbb4bd0a6);
		((Control)this).Controls.Add((Control)(object)cd0fca5dcac9a20b07d24381e7cf6b948);
		((Control)this).Controls.Add((Control)(object)cad062cb240d8f3ea2aa4cedf8f7b42c8);
		((Control)this).Controls.Add((Control)(object)c9912dc5182d7219d9182dd331caae777);
		((Control)this).Controls.Add((Control)(object)cf646fef84808e9c119ee9938412e8509);
		((Control)this).Controls.Add((Control)(object)cc0729005b502cc37c5f85802adf02a1f);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(306));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106088);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106109);
		((Control)cf646fef84808e9c119ee9938412e8509).ResumeLayout(false);
		((Control)cf646fef84808e9c119ee9938412e8509).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c5cf8bc3536654c97fae1d12ea5d627df(object P_0, EventArgs P_1)
	{
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + 3;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323));
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330));
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c4ae2942e8a8490f245d8e62e8457341c(object P_0, EventArgs P_1)
	{
		string text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text;
		text = text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287));
		switch (cabb4ea3f275636e5e480474aff0a69d9)
		{
		case c18b701edbfa2c7e425723ba328be3d3a.c37fe68812c6df70f9ffa3abac5929ca8:
		{
			object obj4 = controlref;
			((Control)((obj4 is TextBox) ? obj4 : null)).Text = text;
			break;
		}
		case c18b701edbfa2c7e425723ba328be3d3a.c6cc2f23b75767ed7446cd58889955d9c:
		{
			object obj3 = controlref;
			((Control)((obj3 is ComboBox) ? obj3 : null)).Text = text;
			break;
		}
		case c18b701edbfa2c7e425723ba328be3d3a.c9c7d271dc006f3bbe99851506567cfef:
		{
			object obj2 = controlref;
			((Control)((obj2 is RichTextBox) ? obj2 : null)).Text = text;
			break;
		}
		case c18b701edbfa2c7e425723ba328be3d3a.cad98d0efe683080712dc4f8d0afa900a:
		{
			object obj = controlref;
			((DataGridViewCell)((obj is DataGridViewCell) ? obj : null)).Value = text;
			break;
		}
		case c18b701edbfa2c7e425723ba328be3d3a.ca6dfb7a66c6a093c337493d390d39ca4:
			_ = c19eccfa624303fec4c7385f816c8f146;
			break;
		}
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void caaa37a0912ccff1858a999f9f6a9c32b(object P_0, EventArgs P_1)
	{
		if (!(((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106132)))
		{
			__ldtoken(RagsEditor.caaa37a0912ccff1858a999f9f6a9c32b(object, EventArgs));
			((Control)c9912dc5182d7219d9182dd331caae777).Enabled = false;
			((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Enabled = false;
			((Control)cf646fef84808e9c119ee9938412e8509).Enabled = false;
			((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Enabled = true;
			c0f22792252252f15b9fccc7fb865cdae = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text;
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).Clear();
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ReadOnly = true;
			TextHandlers.AddTextToRTF(ref cc0729005b502cc37c5f85802adf02a1f, ref c54f9a911545745b85ae6f74355697f8b, c0f22792252252f15b9fccc7fb865cdae, Color.Black, (FontStyle)0);
			((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106132);
		}
		else
		{
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).Clear();
			((Control)cc0729005b502cc37c5f85802adf02a1f).Text = c0f22792252252f15b9fccc7fb865cdae;
			((Control)cd0fca5dcac9a20b07d24381e7cf6b948).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106013);
			((Control)c9912dc5182d7219d9182dd331caae777).Enabled = true;
			((Control)cad062cb240d8f3ea2aa4cedf8f7b42c8).Enabled = true;
			((Control)cf646fef84808e9c119ee9938412e8509).Enabled = true;
			((Control)c88287a58c46e1b303bd5f5fbbb4bd0a6).Enabled = false;
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ReadOnly = false;
		}
	}

	private void c6e0d7055c6d9bdd2e022ddf0cbfb359a(object P_0, EventArgs P_1)
	{
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + 3;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339));
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346));
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c93a21c9fe56c6b18e15fcbb6199d5040(object P_0, EventArgs P_1)
	{
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + 3;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355));
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362));
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c0347e7f82cdb4c42d3829d8adce43c8b(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)cb50e1b6024cdcdd498e9f83018fc0f18).ShowDialog() != 1)
		{
			__ldtoken(RagsEditor.c0347e7f82cdb4c42d3829d8adce43c8b(object, EventArgs));
			return;
		}
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106151);
		if (!cb50e1b6024cdcdd498e9f83018fc0f18.Color.IsNamedColor)
		{
			__ldtoken(RagsEditor.c0347e7f82cdb4c42d3829d8adce43c8b(object, EventArgs));
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106151) + cb50e1b6024cdcdd498e9f83018fc0f18.Color.R + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) + cb50e1b6024cdcdd498e9f83018fc0f18.Color.G + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) + cb50e1b6024cdcdd498e9f83018fc0f18.Color.B + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
		}
		else
		{
			text = text + cb50e1b6024cdcdd498e9f83018fc0f18.Color.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
		}
		int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + text.Length;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, text);
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300));
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 4 - selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c7ca55656a2d87214bf77d656edcb94b4(object P_0, EventArgs P_1)
	{
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + 8;
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106158));
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106175));
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 9 - selectionStart;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c41b8f83f13c26607f1fc2981e51408ce(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)cc8264b1067fe196be453410d7902dac7).ShowDialog() == 1)
		{
			int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
			string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106194) + cc8264b1067fe196be453410d7902dac7.Font.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) + cc8264b1067fe196be453410d7902dac7.Font.Size + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
			int num = selectionStart + ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength + text.Length;
			((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart, text);
			((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(num, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314));
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart;
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionLength = num + 4 - selectionStart;
			((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
		}
	}

	private void ccfd0e822360be1db3268bc0d8ac5e1ba(object P_0, EventArgs P_1)
	{
		int selectionStart = ((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart;
		string text = TextHandlers.insertVariableToolStripMenuItem(c54f9a911545745b85ae6f74355697f8b);
		if (!(text != string.Empty))
		{
			__ldtoken(RagsEditor.ccfd0e822360be1db3268bc0d8ac5e1ba(object, EventArgs));
			return;
		}
		((Control)cc0729005b502cc37c5f85802adf02a1f).Text = ((Control)cc0729005b502cc37c5f85802adf02a1f).Text.Insert(selectionStart, text);
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).SelectionStart = selectionStart + text.Length;
		((TextBoxBase)cc0729005b502cc37c5f85802adf02a1f).ScrollToCaret();
	}

	private void c7a8901f0fb02570860cc06617ead82e9(object P_0, EventArgs P_1)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		MathEval.EvaluateString(ref result, ((Control)cc0729005b502cc37c5f85802adf02a1f).Text);
		MessageBox.Show(result.ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106201));
	}

	private void cad9bf09f89721b295fdc85110a553076(object P_0, DisplayMenuEventArgs P_1)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		c7bb5165260e0c08dddb1e063c4ff940b = P_1.Word;
		SharpSpellLive val = (SharpSpellLive)((P_0 is SharpSpellLive) ? P_0 : null);
		ContextMenu val2 = new ContextMenu();
		SuggestionCollection val3 = new SuggestionCollection(P_1.Dictionary, P_1.Word.Value);
		IEnumerator enumerator = val3.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(RagsEditor.cad9bf09f89721b295fdc85110a553076(object, DisplayMenuEventArgs));
				Suggestion val4 = (Suggestion)enumerator.Current;
				MenuItem val5 = ((Menu)val2).MenuItems.Add(val4.Value, (EventHandler)ca4e335072b967e9996ac5dca4004baf2);
				((Menu)val5).Tag = val.TextBox;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(RagsEditor.cad9bf09f89721b295fdc85110a553076(object, DisplayMenuEventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		((Menu)val2).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7796));
		((Menu)val2).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14544), (EventHandler)ccf9235c13e1467d8d55b264e625660af);
		((Menu)val2).MenuItems.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14579), (EventHandler)cef7c459267e17f22371448e7bfd608f9);
		val2.Show((Control)(object)val.TextBox, P_1.MousePosition);
	}

	private void ca4e335072b967e9996ac5dca4004baf2(object P_0, EventArgs P_1)
	{
		MenuItem val = (MenuItem)((P_0 is MenuItem) ? P_0 : null);
		string text = val.Text;
		object tag = ((Menu)val).Tag;
		TextBox val2 = (TextBox)((tag is TextBox) ? tag : null);
		object tag2 = ((Menu)val).Tag;
		RichTextBox val3 = (RichTextBox)((tag2 is RichTextBox) ? tag2 : null);
		if (val2 == null)
		{
			__ldtoken(RagsEditor.ca4e335072b967e9996ac5dca4004baf2(object, EventArgs));
			if (val3 == null)
			{
				__ldtoken(RagsEditor.ca4e335072b967e9996ac5dca4004baf2(object, EventArgs));
				return;
			}
			((TextBoxBase)val3).Select(c7bb5165260e0c08dddb1e063c4ff940b.Index, c7bb5165260e0c08dddb1e063c4ff940b.Value.Length);
			((TextBoxBase)val3).SelectedText = text;
		}
		else
		{
			((TextBoxBase)val2).Select(c7bb5165260e0c08dddb1e063c4ff940b.Index, c7bb5165260e0c08dddb1e063c4ff940b.Value.Length);
			((TextBoxBase)val2).SelectedText = text;
		}
	}

	private void ccf9235c13e1467d8d55b264e625660af(object P_0, EventArgs P_1)
	{
		c1ef940cdb8be768145bbb7ae47e0f539.Dictionary.CustomWordlist.Add(c7bb5165260e0c08dddb1e063c4ff940b.Value.ToLower(CultureInfo.CurrentCulture));
	}

	private void cef7c459267e17f22371448e7bfd608f9(object P_0, EventArgs P_1)
	{
		if (c7bb5165260e0c08dddb1e063c4ff940b == null)
		{
			__ldtoken(RagsEditor.cef7c459267e17f22371448e7bfd608f9(object, EventArgs));
		}
		else
		{
			c1ef940cdb8be768145bbb7ae47e0f539.Dictionary.IgnoreWordlist.Add(c7bb5165260e0c08dddb1e063c4ff940b.Value.ToLower(CultureInfo.CurrentCulture));
		}
	}
}
