using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Rags;

namespace RagsDesigner;

public class SearchForm : Form
{
	private Form1 m_a;

	private IContainer m_b;

	private Label c;

	private TextBox d;

	private Button e;

	private DataGridView f;

	private DataGridViewTextBoxColumn g;

	private DataGridViewTextBoxColumn h;

	private DataGridViewTextBoxColumn i;

	public SearchForm(Form1 tempparent)
	{
		a();
		this.m_a = tempparent;
	}

	private void b(object A_0, EventArgs A_1)
	{
		f.Rows.Clear();
		if (Game.GetDBConnection() == null)
		{
			return;
		}
		foreach (Room room in Form1.TheGame.RoomList)
		{
			foreach (Rags.Action action6 in room.Actions)
			{
				StringBuilder CurDoc = new StringBuilder();
				action6.GetXMLData(ref CurDoc);
				if (CurDoc.ToString().IndexOf(((Control)d).Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(CurDoc.ToString());
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Action/Name");
					string text = "Unknown";
					if (xmlNodeList.Count > 0)
					{
						text = "Action: " + xmlNodeList[0].InnerText;
					}
					f.Rows.Add(new object[3] { "Room", room.Name, text });
				}
			}
		}
		foreach (Rags.Action action7 in Form1.TheGame.ThePlayer.Actions)
		{
			StringBuilder CurDoc2 = new StringBuilder();
			action7.GetXMLData(ref CurDoc2);
			if (CurDoc2.ToString().IndexOf(((Control)d).Text, StringComparison.CurrentCultureIgnoreCase) > -1)
			{
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadXml(CurDoc2.ToString());
				XmlNodeList xmlNodeList2 = xmlDocument2.SelectNodes("Action/Name");
				string text2 = "Unknown";
				if (xmlNodeList2.Count > 0)
				{
					text2 = "Action: " + xmlNodeList2[0].InnerText;
				}
				f.Rows.Add(new object[3] { "Player", "Player Actions", text2 });
			}
		}
		foreach (GameObject @object in Form1.TheGame.ObjectList)
		{
			foreach (Rags.Action action8 in @object.Actions)
			{
				StringBuilder CurDoc3 = new StringBuilder();
				action8.GetXMLData(ref CurDoc3);
				if (CurDoc3.ToString().IndexOf(((Control)d).Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument3 = new XmlDocument();
					xmlDocument3.LoadXml(CurDoc3.ToString());
					XmlNodeList xmlNodeList3 = xmlDocument3.SelectNodes("Action/Name");
					string text3 = "Unknown";
					if (xmlNodeList3.Count > 0)
					{
						text3 = "Action: " + xmlNodeList3[0].InnerText;
					}
					f.Rows.Add(new object[3] { "Item", @object.name, text3 });
				}
			}
		}
		foreach (Character character in Form1.TheGame.CharacterList)
		{
			foreach (Rags.Action action9 in character.Actions)
			{
				StringBuilder CurDoc4 = new StringBuilder();
				action9.GetXMLData(ref CurDoc4);
				if (CurDoc4.ToString().IndexOf(((Control)d).Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument4 = new XmlDocument();
					xmlDocument4.LoadXml(CurDoc4.ToString());
					XmlNodeList xmlNodeList4 = xmlDocument4.SelectNodes("Action/Name");
					string text4 = "Unknown";
					if (xmlNodeList4.Count > 0)
					{
						text4 = "Action: " + xmlNodeList4[0].InnerText;
					}
					f.Rows.Add(new object[3] { "Character", character.Charname, text4 });
				}
			}
		}
		foreach (Timer timer in Form1.TheGame.TimerList)
		{
			foreach (Rags.Action action10 in timer.Actions)
			{
				StringBuilder CurDoc5 = new StringBuilder();
				action10.GetXMLData(ref CurDoc5);
				if (CurDoc5.ToString().IndexOf(((Control)d).Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument5 = new XmlDocument();
					xmlDocument5.LoadXml(CurDoc5.ToString());
					XmlNodeList xmlNodeList5 = xmlDocument5.SelectNodes("Action/Name");
					string text5 = "Unknown";
					if (xmlNodeList5.Count > 0)
					{
						text5 = "Action: " + xmlNodeList5[0].InnerText;
					}
					f.Rows.Add(new object[3] { "Timer", timer.Name, text5 });
				}
			}
		}
	}

	private void a(SqlCeDataReader A_0, string A_1, string A_2)
	{
		while (A_0.Read())
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(A_0["Data"].ToString());
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Action/Name");
			string text = "Unknown";
			if (xmlNodeList.Count > 0)
			{
				text = "Action: " + xmlNodeList[0].InnerText;
			}
			f.Rows.Add(new object[3]
			{
				A_1,
				A_0[A_2],
				text
			});
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected Obj, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected Obj, but got Unknown
		if (((BaseCollection)f.SelectedRows).Count <= 0)
		{
			return;
		}
		int index = ((DataGridViewBand)f.SelectedRows[0]).Index;
		if (index < 0 || f.Rows[index].Cells[0].Value == null)
		{
			return;
		}
		string text = f.Rows[index].Cells[0].Value.ToString();
		string text2 = f.Rows[index].Cells[1].Value.ToString();
		string a_ = f.Rows[index].Cells[2].Value.ToString();
		switch (text)
		{
		case "Room":
			this.m_a.tabControl1.SelectedIndex = 1;
			this.m_a.tabControl2.SelectedIndex = 3;
			this.m_a.dgvRoomList.ClearSelection();
			foreach (DataGridViewRow item in (IEnumerable)this.m_a.dgvRoomList.Rows)
			{
				DataGridViewRow val3 = item;
				if (val3.Cells[0].Value.ToString() == text2)
				{
					((DataGridViewBand)this.m_a.dgvRoomList.Rows[((DataGridViewBand)val3).Index]).Selected = true;
					break;
				}
			}
			a(a_, this.m_a.RoomActions);
			break;
		case "Item":
		{
			this.m_a.tabControl1.SelectedIndex = 3;
			this.m_a.tabControl3.SelectedIndex = 3;
			TreeNode[] array = this.m_a.tvItems.Nodes.Find(text2, true);
			if (array.Length != 0)
			{
				this.m_a.tvItems.SelectedNode = array[0];
			}
			else
			{
				foreach (TreeNode node in this.m_a.tvItems.Nodes)
				{
					TreeNode a_2 = node;
					if (a(a_2, this.m_a.tvItems, text2))
					{
						break;
					}
				}
			}
			a(a_, this.m_a.ObjectActions);
			break;
		}
		case "Character":
			this.m_a.tabControl1.SelectedIndex = 4;
			this.m_a.tabControlCharData.SelectedIndex = 2;
			this.m_a.dgvCharacters.ClearSelection();
			foreach (DataGridViewRow item2 in (IEnumerable)this.m_a.dgvCharacters.Rows)
			{
				DataGridViewRow val2 = item2;
				if (val2.Cells[0].Value.ToString() == text2)
				{
					((DataGridViewBand)this.m_a.dgvCharacters.Rows[((DataGridViewBand)val2).Index]).Selected = true;
					break;
				}
			}
			a(a_, this.m_a.CharacterActions);
			break;
		case "Player":
			this.m_a.tabControl1.SelectedIndex = 2;
			this.m_a.tabControl4.SelectedIndex = 2;
			a(a_, this.m_a.PlayerActions);
			break;
		case "Timer":
			this.m_a.tabControl1.SelectedIndex = 6;
			this.m_a.tabControl5.SelectedIndex = 2;
			this.m_a.dgvTimers.ClearSelection();
			foreach (DataGridViewRow item3 in (IEnumerable)this.m_a.dgvTimers.Rows)
			{
				DataGridViewRow val = item3;
				if (val.Cells[1].Value.ToString() == text2)
				{
					((DataGridViewBand)this.m_a.dgvTimers.Rows[((DataGridViewBand)val).Index]).Selected = true;
					break;
				}
			}
			a(a_, this.m_a.TimerActions);
			break;
		}
	}

	private bool a(TreeNode A_0, TreeView A_1, string A_2)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		bool flag = false;
		Command command = A_0.Tag as Command;
		Condition condition = A_0.Tag as Condition;
		if (command != null)
		{
			flag = command.ContainsValue(((Control)d).Text);
			if (flag)
			{
				A_1.SelectedNode = A_0;
			}
		}
		else if (condition != null)
		{
			flag = condition.ContainsValue(((Control)d).Text);
			if (flag)
			{
				A_1.SelectedNode = A_0;
			}
		}
		if (!flag)
		{
			foreach (TreeNode node in A_0.Nodes)
			{
				TreeNode a_ = node;
				flag = a(a_, A_1, A_2);
				if (flag)
				{
					break;
				}
			}
		}
		return flag;
	}

	private void a(string A_0, ActionControl A_1)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		string text = A_0.Split(new string[1] { ":" }, StringSplitOptions.None)[1].Trim();
		foreach (TreeNode node in A_1.tvActionsConditions.Nodes)
		{
			TreeNode val = node;
			if (!(val.Text == text))
			{
				continue;
			}
			A_1.tvActionsConditions.SelectedNode = val;
			val.ExpandAll();
			{
				foreach (TreeNode node2 in val.Nodes)
				{
					TreeNode a_ = node2;
					if (a(a_, A_1))
					{
						break;
					}
				}
				break;
			}
		}
	}

	private bool a(TreeNode A_0, ActionControl A_1)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		bool flag = false;
		Command command = A_0.Tag as Command;
		Condition condition = A_0.Tag as Condition;
		if (command != null)
		{
			flag = command.ContainsValue(((Control)d).Text);
			if (flag)
			{
				A_1.tvActionsConditions.SelectedNode = A_0;
			}
		}
		else if (condition != null)
		{
			flag = condition.ContainsValue(((Control)d).Text);
			if (flag)
			{
				A_1.tvActionsConditions.SelectedNode = A_0;
			}
		}
		if (!flag)
		{
			foreach (TreeNode node in A_0.Nodes)
			{
				TreeNode a_ = node;
				flag = a(a_, A_1);
				if (flag)
				{
					break;
				}
			}
		}
		return flag;
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
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SearchForm));
		c = new Label();
		d = new TextBox();
		e = new Button();
		f = new DataGridView();
		g = new DataGridViewTextBoxColumn();
		h = new DataGridViewTextBoxColumn();
		i = new DataGridViewTextBoxColumn();
		((ISupportInitialize)f).BeginInit();
		((Control)this).SuspendLayout();
		((Control)c).AutoSize = true;
		((Control)c).Location = new Point(12, 9);
		((Control)c).Name = "label1";
		((Control)c).Size = new Size(68, 13);
		((Control)c).TabIndex = 0;
		((Control)c).Text = "Search Term";
		((Control)d).Anchor = (AnchorStyles)13;
		((Control)d).Location = new Point(12, 25);
		((Control)d).Name = "textBox1";
		((Control)d).Size = new Size(419, 20);
		((Control)d).TabIndex = 1;
		((Control)e).Anchor = (AnchorStyles)9;
		((Control)e).Location = new Point(437, 25);
		((Control)e).Name = "button1";
		((Control)e).Size = new Size(75, 23);
		((Control)e).TabIndex = 2;
		((Control)e).Text = "Search...";
		((ButtonBase)e).UseVisualStyleBackColor = true;
		((Control)e).Click += b;
		((Control)f).Anchor = (AnchorStyles)15;
		f.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		f.Columns.AddRange(new DataGridViewColumn[3]
		{
			(DataGridViewColumn)g,
			(DataGridViewColumn)h,
			(DataGridViewColumn)i
		});
		((Control)f).Location = new Point(12, 51);
		f.MultiSelect = false;
		((Control)f).Name = "dgResults";
		f.RowHeadersWidth = 4;
		f.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)f).Size = new Size(500, 342);
		((Control)f).TabIndex = 3;
		f.SelectionChanged += a;
		((DataGridViewColumn)g).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)g).FillWeight = 25f;
		((DataGridViewColumn)g).HeaderText = "Object Type";
		((DataGridViewColumn)g).Name = "Column1";
		((DataGridViewColumn)h).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)h).FillWeight = 25f;
		((DataGridViewColumn)h).HeaderText = "Name";
		((DataGridViewColumn)h).Name = "Column2";
		((DataGridViewColumn)i).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)i).FillWeight = 50f;
		((DataGridViewColumn)i).HeaderText = "Data";
		((DataGridViewColumn)i).Name = "Column3";
		((Form)this).AcceptButton = (IButtonControl)(object)e;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(524, 405);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)c);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "SearchForm";
		((Control)this).Text = "Search Form";
		((Form)this).TopMost = true;
		((ISupportInitialize)f).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
