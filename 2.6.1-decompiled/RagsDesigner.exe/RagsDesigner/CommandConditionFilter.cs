using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Rags;

namespace RagsDesigner;

public class CommandConditionFilter : Form
{
	private Game m_a;

	private IContainer m_b;

	private ComboBox m_c;

	private Label m_d;

	private Panel m_e;

	private CheckedListBox m_f;

	private Button g;

	private Label h;

	private Button i;

	private Button j;

	public CommandConditionFilter(ref Game curgame)
	{
		a();
		this.m_a = curgame;
	}

	private void f(object A_0, EventArgs A_1)
	{
		((ListControl)this.m_c).SelectedIndex = 0;
	}

	private void e(object A_0, EventArgs A_1)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		if (((ObjectCollection)this.m_f.Items).Count > 0)
		{
			b();
		}
		((ObjectCollection)this.m_f.Items).Clear();
		if (((ListControl)this.m_c).SelectedIndex == 0)
		{
			ComboBox val = new ComboBox();
			Command.PopulateComboWithCommands(val, bFilter: false);
			List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Command);
			{
				foreach (CommandConditionComboItem item in val.Items)
				{
					this.m_f.Items.Add((object)item, list.Contains(item.Name));
				}
				return;
			}
		}
		ComboBox val2 = new ComboBox();
		Condition.PopulateComboWithConditions(val2, bFilter: false);
		List<string> list2 = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Condition);
		foreach (CommandConditionComboItem item2 in val2.Items)
		{
			this.m_f.Items.Add((object)item2, list2.Contains(item2.Name));
		}
	}

	private void b()
	{
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
		string empty = string.Empty;
		if (((CommandConditionComboItem)((ObjectCollection)this.m_f.Items)[0]).cndindex == Condition.ConditionType.CT_Uninitialized)
		{
			xmlNodeList = xmlDocument.SelectNodes("Configuration/BlockedCommands");
			xmlElement = xmlDocument.CreateElement("BlockedCommands");
			empty = "Command";
		}
		else
		{
			xmlNodeList = xmlDocument.SelectNodes("Configuration/BlockedConditions");
			xmlElement = xmlDocument.CreateElement("BlockedConditions");
			empty = "Condition";
		}
		foreach (CommandConditionComboItem checkedItem in this.m_f.CheckedItems)
		{
			XmlElement xmlElement2 = xmlDocument.CreateElement(empty);
			xmlElement2.SetAttribute("name", checkedItem.Name);
			xmlElement.AppendChild(xmlElement2);
		}
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
	}

	private void d(object A_0, EventArgs A_1)
	{
		b();
		((Form)this).Close();
	}

	private void c(object A_0, EventArgs A_1)
	{
		for (int i = 0; i < ((ObjectCollection)this.m_f.Items).Count; i++)
		{
			this.m_f.SetItemChecked(i, true);
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		for (int i = 0; i < ((ObjectCollection)this.m_f.Items).Count; i++)
		{
			this.m_f.SetItemChecked(i, false);
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_b != null)
		{
			this.m_b.Dispose();
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
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CommandConditionFilter));
		this.m_c = new ComboBox();
		this.m_d = new Label();
		this.m_e = new Panel();
		this.m_f = new CheckedListBox();
		g = new Button();
		h = new Label();
		i = new Button();
		j = new Button();
		((Control)this.m_e).SuspendLayout();
		((Control)this).SuspendLayout();
		((ListControl)this.m_c).FormattingEnabled = true;
		this.m_c.Items.AddRange(new object[2] { "Commands", "Conditions" });
		((Control)this.m_c).Location = new Point(12, 25);
		((Control)this.m_c).Name = "cbComCond";
		((Control)this.m_c).Size = new Size(203, 21);
		((Control)this.m_c).TabIndex = 0;
		this.m_c.SelectedIndexChanged += e;
		((Control)this.m_d).AutoSize = true;
		((Control)this.m_d).Location = new Point(12, 9);
		((Control)this.m_d).Name = "label1";
		((Control)this.m_d).Size = new Size(165, 13);
		((Control)this.m_d).TabIndex = 1;
		((Control)this.m_d).Text = "Choose Commands or Conditions:";
		((Control)this.m_e).Anchor = (AnchorStyles)15;
		((Control)this.m_e).Controls.Add((Control)(object)this.m_f);
		((Control)this.m_e).Location = new Point(12, 65);
		((Control)this.m_e).Name = "panel1";
		((Control)this.m_e).Size = new Size(568, 334);
		((Control)this.m_e).TabIndex = 2;
		((Control)this.m_f).Dock = (DockStyle)5;
		((ListControl)this.m_f).FormattingEnabled = true;
		((Control)this.m_f).Location = new Point(0, 0);
		((Control)this.m_f).Name = "cbListBox";
		((ListBox)this.m_f).ScrollAlwaysVisible = true;
		((Control)this.m_f).Size = new Size(568, 334);
		((Control)this.m_f).TabIndex = 0;
		((Control)g).Location = new Point(12, 405);
		((Control)g).Name = "btnDone";
		((Control)g).Size = new Size(75, 23);
		((Control)g).TabIndex = 3;
		((Control)g).Text = "Finished";
		((ButtonBase)g).UseVisualStyleBackColor = true;
		((Control)g).Click += d;
		((Control)h).AutoSize = true;
		((Control)h).Location = new Point(12, 49);
		((Control)h).Name = "label2";
		((Control)h).Size = new Size(154, 13);
		((Control)h).TabIndex = 4;
		((Control)h).Text = "Checked Items Will Be Hidden:";
		((Control)h).Click += a;
		((Control)i).Location = new Point(176, 405);
		((Control)i).Name = "button1";
		((Control)i).Size = new Size(75, 23);
		((Control)i).TabIndex = 5;
		((Control)i).Text = "Check All";
		((ButtonBase)i).UseVisualStyleBackColor = true;
		((Control)i).Click += c;
		((Control)j).Location = new Point(258, 406);
		((Control)j).Name = "button2";
		((Control)j).Size = new Size(75, 23);
		((Control)j).TabIndex = 6;
		((Control)j).Text = "Uncheck All";
		((ButtonBase)j).UseVisualStyleBackColor = true;
		((Control)j).Click += b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(592, 440);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "CommandConditionFilter";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Command and Condition Filter";
		((Form)this).Load += f;
		((Control)this.m_e).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
