using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using A;

namespace RagsDesigner;

public sealed class AutoSaveSettingsFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private CheckBox ca4c1d8a5e804ef372ef5c3cf27bfd0ce;

	private NumericUpDown c9a450bdb16c338ab59d04ee4f528c935;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private Button ce2761d6abd4d4150fc608452cc32c744;

	public AutoSaveSettingsFrm()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(AutoSaveSettingsFrm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(AutoSaveSettingsFrm.Dispose(bool));
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
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AutoSaveSettingsFrm));
		ca4c1d8a5e804ef372ef5c3cf27bfd0ce = new CheckBox();
		c9a450bdb16c338ab59d04ee4f528c935 = new NumericUpDown();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		ce2761d6abd4d4150fc608452cc32c744 = new Button();
		((ISupportInitialize)c9a450bdb16c338ab59d04ee4f528c935).BeginInit();
		((Control)this).SuspendLayout();
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).AutoSize = true;
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).Location = new Point(12, 12);
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1686);
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).Size = new Size(98, 17);
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).TabIndex = 0;
		((Control)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1711);
		((ButtonBase)ca4c1d8a5e804ef372ef5c3cf27bfd0ce).UseVisualStyleBackColor = true;
		((Control)c9a450bdb16c338ab59d04ee4f528c935).Location = new Point(12, 52);
		c9a450bdb16c338ab59d04ee4f528c935.Maximum = new decimal(new int[4] { 120, 0, 0, 0 });
		c9a450bdb16c338ab59d04ee4f528c935.Minimum = new decimal(new int[4] { 5, 0, 0, 0 });
		((Control)c9a450bdb16c338ab59d04ee4f528c935).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1738);
		((Control)c9a450bdb16c338ab59d04ee4f528c935).Size = new Size(71, 20);
		((Control)c9a450bdb16c338ab59d04ee4f528c935).TabIndex = 1;
		c9a450bdb16c338ab59d04ee4f528c935.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 36);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(211, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 2;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1757);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(43, 89);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(53, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 3;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(493);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Location = new Point(124, 89);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(498);
		((Control)ce2761d6abd4d4150fc608452cc32c744).Size = new Size(53, 23);
		((Control)ce2761d6abd4d4150fc608452cc32c744).TabIndex = 4;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(513);
		((ButtonBase)ce2761d6abd4d4150fc608452cc32c744).UseVisualStyleBackColor = true;
		((Control)ce2761d6abd4d4150fc608452cc32c744).Click += c7abee227c4ea05d5e309cce1e3d77c65;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(239, 123);
		((Control)this).Controls.Add((Control)(object)ce2761d6abd4d4150fc608452cc32c744);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)c9a450bdb16c338ab59d04ee4f528c935);
		((Control)this).Controls.Add((Control)(object)ca4c1d8a5e804ef372ef5c3cf27bfd0ce);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1838);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1877);
		((Form)this).Load += c79dc3b48e71714478ee46818fb35d4a9;
		((ISupportInitialize)c9a450bdb16c338ab59d04ee4f528c935).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		Form1.bUseAutoSave = ca4c1d8a5e804ef372ef5c3cf27bfd0ce.Checked;
		Form1.iAutoSaveMinutes = Convert.ToInt32(c9a450bdb16c338ab59d04ee4f528c935.Value);
		new List<string>();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(897));
		if (Directory.Exists(text))
		{
			__ldtoken(AutoSaveSettingsFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
		}
		else
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(906));
		if (!File.Exists(text2))
		{
			string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(935);
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		XmlElement xmlElement = null;
		_ = string.Empty;
		xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1896));
		xmlElement = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1973));
		XmlElement xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2022));
		xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2037), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2046));
		xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2069), Form1.bUseAutoSave.ToString());
		xmlElement.AppendChild(xmlElement2);
		xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2022));
		xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2037), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2080));
		xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2069), Form1.iAutoSaveMinutes.ToString());
		xmlElement.AppendChild(xmlElement2);
		if (xmlNodeList[0] == null)
		{
			__ldtoken(AutoSaveSettingsFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1231));
			if (xmlNodeList[0] == null)
			{
				__ldtoken(AutoSaveSettingsFrm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				xmlNodeList[0].AppendChild(xmlElement);
			}
		}
		else
		{
			XmlNode xmlNode = xmlNodeList[0];
			xmlNode.ParentNode.ReplaceChild(xmlElement, xmlNode);
		}
		xmlDocument.Save(text2);
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void c7abee227c4ea05d5e309cce1e3d77c65(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void c79dc3b48e71714478ee46818fb35d4a9(object P_0, EventArgs P_1)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(897));
		if (Directory.Exists(text))
		{
			__ldtoken(AutoSaveSettingsFrm.c79dc3b48e71714478ee46818fb35d4a9(object, EventArgs));
		}
		else
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(906));
		if (!File.Exists(text2))
		{
			string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(935);
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		_ = string.Empty;
		xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1896));
		xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1973));
		if (xmlNodeList.Count <= 0)
		{
			__ldtoken(AutoSaveSettingsFrm.c79dc3b48e71714478ee46818fb35d4a9(object, EventArgs));
			return;
		}
		IEnumerator enumerator = xmlNodeList[0].ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				string text3 = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2037)].Value.ToString();
				if (text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2046))
				{
					string value = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2069)].Value;
					try
					{
						ca4c1d8a5e804ef372ef5c3cf27bfd0ce.Checked = Convert.ToBoolean(value);
					}
					catch
					{
						ca4c1d8a5e804ef372ef5c3cf27bfd0ce.Checked = false;
					}
				}
				else if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2080)))
				{
					__ldtoken(AutoSaveSettingsFrm.c79dc3b48e71714478ee46818fb35d4a9(object, EventArgs));
				}
				else
				{
					string value2 = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2069)].Value;
					try
					{
						c9a450bdb16c338ab59d04ee4f528c935.Value = Convert.ToDecimal(value2);
					}
					catch
					{
						c9a450bdb16c338ab59d04ee4f528c935.Value = 5m;
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(AutoSaveSettingsFrm.c79dc3b48e71714478ee46818fb35d4a9(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}
