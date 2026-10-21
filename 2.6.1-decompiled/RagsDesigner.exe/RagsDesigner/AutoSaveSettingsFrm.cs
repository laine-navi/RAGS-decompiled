using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace RagsDesigner;

public class AutoSaveSettingsFrm : Form
{
	private IContainer m_a;

	private CheckBox m_b;

	private NumericUpDown m_c;

	private Label d;

	private Button e;

	private Button f;

	public AutoSaveSettingsFrm()
	{
		a();
	}

	private void c(object A_0, EventArgs A_1)
	{
		Form1.bUseAutoSave = this.m_b.Checked;
		Form1.iAutoSaveMinutes = Convert.ToInt32(this.m_c.Value);
		new List<string>();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, "RagsConfig.xml");
		if (!File.Exists(text2))
		{
			string contents = "<Configuration> </Configuration>";
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		XmlElement xmlElement = null;
		_ = string.Empty;
		xmlNodeList = xmlDocument.SelectNodes("Configuration/DesignerAutoSaveSettings");
		xmlElement = xmlDocument.CreateElement("DesignerAutoSaveSettings");
		XmlElement xmlElement2 = xmlDocument.CreateElement("Setting");
		xmlElement2.SetAttribute("Name", "UseAutoSave");
		xmlElement2.SetAttribute("Value", Form1.bUseAutoSave.ToString());
		xmlElement.AppendChild(xmlElement2);
		xmlElement2 = xmlDocument.CreateElement("Setting");
		xmlElement2.SetAttribute("Name", "Minutes");
		xmlElement2.SetAttribute("Value", Form1.iAutoSaveMinutes.ToString());
		xmlElement.AppendChild(xmlElement2);
		if (xmlNodeList[0] != null)
		{
			XmlNode xmlNode = xmlNodeList[0];
			xmlNode.ParentNode.ReplaceChild(xmlElement, xmlNode);
		}
		else
		{
			xmlNodeList = xmlDocument.SelectNodes("Configuration");
			if (xmlNodeList[0] != null)
			{
				xmlNodeList[0].AppendChild(xmlElement);
			}
		}
		xmlDocument.Save(text2);
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void a(object A_0, EventArgs A_1)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, "RagsConfig.xml");
		if (!File.Exists(text2))
		{
			string contents = "<Configuration> </Configuration>";
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		_ = string.Empty;
		xmlNodeList = xmlDocument.SelectNodes("Configuration/DesignerAutoSaveSettings");
		xmlDocument.CreateElement("DesignerAutoSaveSettings");
		if (xmlNodeList.Count <= 0)
		{
			return;
		}
		foreach (XmlNode childNode in xmlNodeList[0].ChildNodes)
		{
			string text3 = childNode.Attributes["Name"].Value.ToString();
			if (text3 == "UseAutoSave")
			{
				string value = childNode.Attributes["Value"].Value;
				try
				{
					this.m_b.Checked = Convert.ToBoolean(value);
				}
				catch
				{
					this.m_b.Checked = false;
				}
			}
			else if (text3 == "Minutes")
			{
				string value2 = childNode.Attributes["Value"].Value;
				try
				{
					this.m_c.Value = Convert.ToDecimal(value2);
				}
				catch
				{
					this.m_c.Value = 5m;
				}
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_a != null)
		{
			this.m_a.Dispose();
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
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AutoSaveSettingsFrm));
		this.m_b = new CheckBox();
		this.m_c = new NumericUpDown();
		d = new Label();
		e = new Button();
		f = new Button();
		((ISupportInitialize)this.m_c).BeginInit();
		((Control)this).SuspendLayout();
		((Control)this.m_b).AutoSize = true;
		((Control)this.m_b).Location = new Point(12, 12);
		((Control)this.m_b).Name = "cbAutoSaveOn";
		((Control)this.m_b).Size = new Size(98, 17);
		((Control)this.m_b).TabIndex = 0;
		((Control)this.m_b).Text = "Use Auto Save";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_c).Location = new Point(12, 52);
		this.m_c.Maximum = new decimal(new int[4] { 120, 0, 0, 0 });
		this.m_c.Minimum = new decimal(new int[4] { 5, 0, 0, 0 });
		((Control)this.m_c).Name = "udMinutes";
		((Control)this.m_c).Size = new Size(71, 20);
		((Control)this.m_c).TabIndex = 1;
		this.m_c.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		((Control)d).AutoSize = true;
		((Control)d).Location = new Point(12, 36);
		((Control)d).Name = "label1";
		((Control)d).Size = new Size(211, 13);
		((Control)d).TabIndex = 2;
		((Control)d).Text = "Auto Save Frequency (In Minutes 120 max)";
		((Control)e).Location = new Point(43, 89);
		((Control)e).Name = "button1";
		((Control)e).Size = new Size(53, 23);
		((Control)e).TabIndex = 3;
		((Control)e).Text = "OK";
		((ButtonBase)e).UseVisualStyleBackColor = true;
		((Control)e).Click += c;
		((Control)f).Location = new Point(124, 89);
		((Control)f).Name = "button2";
		((Control)f).Size = new Size(53, 23);
		((Control)f).TabIndex = 4;
		((Control)f).Text = "Cancel";
		((ButtonBase)f).UseVisualStyleBackColor = true;
		((Control)f).Click += b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(239, 123);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AutoSaveSettingsFrm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Auto Save";
		((Form)this).Load += a;
		((ISupportInitialize)this.m_c).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
