using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using A;
using Rags;

namespace RagsDesigner;

public sealed class CommandConditionFilter : Form
{
	private Game c9d0e9fb24a9737c01e151442c24f6405;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private ComboBox c1128a4542d709f6d2b8dfea83e7eeab0;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Panel c5e74b6ad19335af023c0fb124e8b9948;

	private CheckedListBox c22424369683af4896950bf0b2c795463;

	private Button c4684edf2f70d0a4c772b3fcba21d73a9;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	public CommandConditionFilter(ref Game curgame)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c9d0e9fb24a9737c01e151442c24f6405 = curgame;
	}

	private void cbcb4f6fc5c99d00b4187f68ac7b18f7d(object P_0, EventArgs P_1)
	{
		((ListControl)c1128a4542d709f6d2b8dfea83e7eeab0).SelectedIndex = 0;
	}

	private void c774aba273345fffcee97340bbdfb7971(object P_0, EventArgs P_1)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		if (((ObjectCollection)c22424369683af4896950bf0b2c795463.Items).Count <= 0)
		{
			__ldtoken(CommandConditionFilter.c774aba273345fffcee97340bbdfb7971(object, EventArgs));
		}
		else
		{
			c49604888089111a261a2b68cd8b2ce66();
		}
		((ObjectCollection)c22424369683af4896950bf0b2c795463.Items).Clear();
		if (((ListControl)c1128a4542d709f6d2b8dfea83e7eeab0).SelectedIndex == 0)
		{
			ComboBox val = new ComboBox();
			Command.PopulateComboWithCommands(val, bFilter: false);
			List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Command);
			{
				IEnumerator enumerator = val.Items.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(CommandConditionFilter.c774aba273345fffcee97340bbdfb7971(object, EventArgs));
						CommandConditionComboItem commandConditionComboItem = (CommandConditionComboItem)enumerator.Current;
						c22424369683af4896950bf0b2c795463.Items.Add((object)commandConditionComboItem, list.Contains(commandConditionComboItem.Name));
					}
					return;
				}
				finally
				{
					IDisposable disposable2 = enumerator as IDisposable;
					if (disposable2 != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		ComboBox val2 = new ComboBox();
		Condition.PopulateComboWithConditions(val2, bFilter: false);
		List<string> list2 = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Condition);
		IEnumerator enumerator2 = val2.Items.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(CommandConditionFilter.c774aba273345fffcee97340bbdfb7971(object, EventArgs));
				CommandConditionComboItem commandConditionComboItem2 = (CommandConditionComboItem)enumerator2.Current;
				c22424369683af4896950bf0b2c795463.Items.Add((object)commandConditionComboItem2, list2.Contains(commandConditionComboItem2.Name));
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable))
			{
				__ldtoken(CommandConditionFilter.c774aba273345fffcee97340bbdfb7971(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c49604888089111a261a2b68cd8b2ce66()
	{
		new List<string>();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(897));
		if (Directory.Exists(text))
		{
			__ldtoken(CommandConditionFilter.c49604888089111a261a2b68cd8b2ce66());
		}
		else
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(906));
		if (File.Exists(text2))
		{
			__ldtoken(CommandConditionFilter.c49604888089111a261a2b68cd8b2ce66());
		}
		else
		{
			string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(935);
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		XmlElement xmlElement = null;
		string empty = string.Empty;
		if (((CommandConditionComboItem)((ObjectCollection)c22424369683af4896950bf0b2c795463.Items)[0]).cndindex != Condition.ConditionType.CT_Uninitialized)
		{
			__ldtoken(CommandConditionFilter.c49604888089111a261a2b68cd8b2ce66());
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1105));
			xmlElement = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1168));
			empty = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1203);
		}
		else
		{
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1000));
			xmlElement = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1059));
			empty = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1090);
		}
		IEnumerator enumerator = c22424369683af4896950bf0b2c795463.CheckedItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CommandConditionComboItem commandConditionComboItem = (CommandConditionComboItem)enumerator.Current;
				XmlElement xmlElement2 = xmlDocument.CreateElement(empty);
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1222), commandConditionComboItem.Name);
				xmlElement.AppendChild(xmlElement2);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(CommandConditionFilter.c49604888089111a261a2b68cd8b2ce66());
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (xmlNodeList[0] != null)
		{
			XmlNode xmlNode = xmlNodeList[0];
			xmlNode.ParentNode.ReplaceChild(xmlElement, xmlNode);
		}
		else
		{
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1231));
			if (xmlNodeList[0] == null)
			{
				__ldtoken(CommandConditionFilter.c49604888089111a261a2b68cd8b2ce66());
			}
			else
			{
				xmlNodeList[0].AppendChild(xmlElement);
			}
		}
		xmlDocument.Save(text2);
	}

	private void c7f324705348fcc3390003b4be3497293(object P_0, EventArgs P_1)
	{
		c49604888089111a261a2b68cd8b2ce66();
		((Form)this).Close();
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < ((ObjectCollection)c22424369683af4896950bf0b2c795463.Items).Count; i++)
		{
			c22424369683af4896950bf0b2c795463.SetItemChecked(i, true);
		}
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < ((ObjectCollection)c22424369683af4896950bf0b2c795463.Items).Count; i++)
		{
			__ldtoken(CommandConditionFilter.c7abee227c4ea05d5e309cce1e3d77c65(object, EventArgs));
			c22424369683af4896950bf0b2c795463.SetItemChecked(i, false);
		}
	}

	private void cf6e18d491ff9efbfc316a9006da7ecdf(object P_0, EventArgs P_1)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(CommandConditionFilter.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(CommandConditionFilter.Dispose(bool));
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
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CommandConditionFilter));
		c1128a4542d709f6d2b8dfea83e7eeab0 = new ComboBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c5e74b6ad19335af023c0fb124e8b9948 = new Panel();
		c22424369683af4896950bf0b2c795463 = new CheckedListBox();
		c4684edf2f70d0a4c772b3fcba21d73a9 = new Button();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		((Control)c5e74b6ad19335af023c0fb124e8b9948).SuspendLayout();
		((Control)this).SuspendLayout();
		((ListControl)c1128a4542d709f6d2b8dfea83e7eeab0).FormattingEnabled = true;
		c1128a4542d709f6d2b8dfea83e7eeab0.Items.AddRange(new object[2]
		{
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1258),
			cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1275)
		});
		((Control)c1128a4542d709f6d2b8dfea83e7eeab0).Location = new Point(12, 25);
		((Control)c1128a4542d709f6d2b8dfea83e7eeab0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1296);
		((Control)c1128a4542d709f6d2b8dfea83e7eeab0).Size = new Size(203, 21);
		((Control)c1128a4542d709f6d2b8dfea83e7eeab0).TabIndex = 0;
		c1128a4542d709f6d2b8dfea83e7eeab0.SelectedIndexChanged += c774aba273345fffcee97340bbdfb7971;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(165, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 1;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Anchor = (AnchorStyles)15;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c22424369683af4896950bf0b2c795463);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Location = new Point(12, 65);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1389);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Size = new Size(568, 334);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).TabIndex = 2;
		((Control)c22424369683af4896950bf0b2c795463).Dock = (DockStyle)5;
		((ListControl)c22424369683af4896950bf0b2c795463).FormattingEnabled = true;
		((Control)c22424369683af4896950bf0b2c795463).Location = new Point(0, 0);
		((Control)c22424369683af4896950bf0b2c795463).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1402);
		((ListBox)c22424369683af4896950bf0b2c795463).ScrollAlwaysVisible = true;
		((Control)c22424369683af4896950bf0b2c795463).Size = new Size(568, 334);
		((Control)c22424369683af4896950bf0b2c795463).TabIndex = 0;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Location = new Point(12, 405);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(353);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Size = new Size(75, 23);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).TabIndex = 3;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1421);
		((ButtonBase)c4684edf2f70d0a4c772b3fcba21d73a9).UseVisualStyleBackColor = true;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Click += c7f324705348fcc3390003b4be3497293;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(12, 49);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1438);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(154, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 4;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Click += cf6e18d491ff9efbfc316a9006da7ecdf;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(176, 405);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 5;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1510);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(258, 406);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(75, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 6;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1529);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(592, 440);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)this).Controls.Add((Control)(object)c4684edf2f70d0a4c772b3fcba21d73a9);
		((Control)this).Controls.Add((Control)(object)c5e74b6ad19335af023c0fb124e8b9948);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c1128a4542d709f6d2b8dfea83e7eeab0);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1552);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1597);
		((Form)this).Load += cbcb4f6fc5c99d00b4187f68ac7b18f7d;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
