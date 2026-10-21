using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rags;

public class AdditionalInputFrm : Form
{
	private ListBox m_a;

	private ListBox m_b;

	private Action.ActionInputType m_c;

	public bool bstarted;

	private IContainer m_d;

	public Label lblTitle;

	public TextBox txtInput;

	private Button m_e;

	public Button btnCancel;

	public DataGridView dgvItems;

	private DataGridViewTextBoxColumn f;

	public AdditionalInputFrm(Action.ActionInputType intype, ref ListBox inv, ref ListBox rmobj, ref ListBox chars)
	{
		a();
		this.m_c = intype;
		this.m_a = inv;
		this.m_b = rmobj;
		switch (intype)
		{
		case Action.ActionInputType.Character:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = "Please select a character:";
			for (int l = 0; l < chars.Items.Count; l++)
			{
				if (chars.Items[l] is Character character2)
				{
					int num7 = dgvItems.Rows.Add((object[])new string[1] { character2.ToString() });
					((DataGridViewBand)dgvItems.Rows[num7]).Tag = character2;
				}
			}
			break;
		}
		case Action.ActionInputType.Object:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = "Please select an object:";
			for (int m = 0; m < this.m_a.Items.Count; m++)
			{
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)this.m_a.Items[m]).GetDisplayName() });
			}
			for (int n = 0; n < this.m_b.Items.Count; n++)
			{
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)this.m_b.Items[n]).GetDisplayName() });
			}
			for (int num8 = 0; num8 < chars.Items.Count; num8++)
			{
				if (chars.Items[num8] is GameObject gameObject2)
				{
					dgvItems.Rows.Add((object[])new string[1] { gameObject2.GetDisplayName() });
				}
			}
			break;
		}
		case Action.ActionInputType.Inventory:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = "Please select an object:";
			for (int num9 = 0; num9 < this.m_a.Items.Count; num9++)
			{
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)this.m_a.Items[num9]).GetDisplayName() });
			}
			break;
		}
		case Action.ActionInputType.ObjectOrCharacter:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = "Please select an object:";
			for (int i = 0; i < this.m_a.Items.Count; i++)
			{
				int num4 = dgvItems.Rows.Add((object[])new string[1] { ((GameObject)this.m_a.Items[i]).GetDisplayName() });
				((DataGridViewBand)dgvItems.Rows[num4]).Tag = this.m_a.Items[i];
			}
			for (int j = 0; j < this.m_b.Items.Count; j++)
			{
				int num5 = dgvItems.Rows.Add((object[])new string[1] { ((GameObject)this.m_b.Items[j]).GetDisplayName() });
				((DataGridViewBand)dgvItems.Rows[num5]).Tag = this.m_b.Items[j];
			}
			for (int k = 0; k < chars.Items.Count; k++)
			{
				Character character = chars.Items[k] as Character;
				if (chars.Items[k] is GameObject gameObject)
				{
					int num6 = dgvItems.Rows.Add((object[])new string[1] { gameObject.GetDisplayName() });
					((DataGridViewBand)dgvItems.Rows[num6]).Tag = gameObject;
				}
				else if (character != null)
				{
					dgvItems.Rows.Add((object[])new string[1] { character.Charname });
				}
			}
			break;
		}
		case Action.ActionInputType.Text:
			((Control)dgvItems).Visible = false;
			((Control)txtInput).Visible = true;
			((Control)lblTitle).Text = "Please enter your text here:";
			break;
		case Action.ActionInputType.Custom:
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = "Please make a selection:";
			{
				foreach (string item in inv.Items)
				{
					string text = item;
					Color foreColor = default;
					for (int num = text.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
					{
						int num2 = text.IndexOf("]", num);
						num += 2;
						string text2 = text.Substring(num, num2 - num).Trim();
						if (text2 != string.Empty)
						{
							if (text2.IndexOf(",") > -1)
							{
								int result = 0;
								string s = text2.Substring(0, text2.IndexOf(","));
								text2 = text2.Remove(0, text2.IndexOf(",") + 1).Trim();
								int.TryParse(s, out var result2);
								string s2 = text2.Substring(0, text2.IndexOf(","));
								text2 = text2.Remove(0, text2.IndexOf(",") + 1).Trim();
								int.TryParse(s2, out var result3);
								int.TryParse(text2, out result);
								foreColor = Color.FromArgb(result2, result3, result);
							}
							else
							{
								foreColor = Color.FromName(text2);
							}
						}
						num -= 2;
						text = text.Remove(num, num2 - num + 1);
						num2 = text.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
						if (num2 >= 0)
						{
							text = text.Remove(num2, 4);
						}
					}
					int num3 = dgvItems.Rows.Add((object[])new string[1] { text });
					((DataGridViewBand)dgvItems.Rows[num3]).DefaultCellStyle.ForeColor = foreColor;
				}
				break;
			}
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		bstarted = true;
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void d(object A_0, EventArgs A_1)
	{
		bstarted = true;
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		e(null, null);
	}

	private void c(object A_0, EventArgs A_1)
	{
		e(null, null);
	}

	private void b(object A_0, EventArgs A_1)
	{
	}

	private void a(object A_0, EventArgs A_1)
	{
	}

	private void a(object A_0, FormClosingEventArgs A_1)
	{
		if (!bstarted)
		{
			((Form)this).DialogResult = (DialogResult)4;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_d != null)
		{
			this.m_d.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected Obj, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected Obj, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdditionalInputFrm));
		lblTitle = new Label();
		txtInput = new TextBox();
		this.m_e = new Button();
		btnCancel = new Button();
		dgvItems = new DataGridView();
		f = new DataGridViewTextBoxColumn();
		((ISupportInitialize)dgvItems).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblTitle).AutoSize = true;
		((Control)lblTitle).Location = new Point(12, 9);
		((Control)lblTitle).Name = "lblTitle";
		((Control)lblTitle).Size = new Size(116, 13);
		((Control)lblTitle).TabIndex = 0;
		((Control)lblTitle).Text = "Please Enter The Text:";
		((Control)txtInput).Anchor = (AnchorStyles)15;
		((Control)txtInput).Location = new Point(15, 25);
		((TextBoxBase)txtInput).Multiline = true;
		((Control)txtInput).Name = "txtInput";
		((Control)txtInput).Size = new Size(292, 265);
		((Control)txtInput).TabIndex = 1;
		((Control)this.m_e).Anchor = (AnchorStyles)2;
		((Control)this.m_e).Location = new Point(70, 308);
		((Control)this.m_e).Name = "btnOK";
		((Control)this.m_e).Size = new Size(58, 23);
		((Control)this.m_e).TabIndex = 3;
		((Control)this.m_e).Text = "OK";
		((ButtonBase)this.m_e).UseVisualStyleBackColor = true;
		((Control)this.m_e).Click += e;
		((Control)btnCancel).Anchor = (AnchorStyles)2;
		btnCancel.DialogResult = (DialogResult)2;
		((Control)btnCancel).Location = new Point(189, 308);
		((Control)btnCancel).Name = "btnCancel";
		((Control)btnCancel).Size = new Size(58, 23);
		((Control)btnCancel).TabIndex = 4;
		((Control)btnCancel).Text = "Cancel";
		((ButtonBase)btnCancel).UseVisualStyleBackColor = true;
		((Control)btnCancel).Click += d;
		dgvItems.AllowUserToAddRows = false;
		dgvItems.AllowUserToDeleteRows = false;
		((Control)dgvItems).Anchor = (AnchorStyles)15;
		dgvItems.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		dgvItems.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		dgvItems.ColumnHeadersVisible = false;
		dgvItems.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)f });
		((Control)dgvItems).Location = new Point(15, 25);
		dgvItems.MultiSelect = false;
		((Control)dgvItems).Name = "dgvItems";
		dgvItems.ReadOnly = true;
		dgvItems.RowHeadersWidth = 4;
		dgvItems.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)dgvItems).Size = new Size(294, 273);
		((Control)dgvItems).TabIndex = 5;
		((Control)dgvItems).DoubleClick += c;
		((DataGridViewColumn)f).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)f).DefaultCellStyle = val;
		((DataGridViewColumn)f).HeaderText = "Selection Choice";
		((DataGridViewColumn)f).Name = "Column1";
		((DataGridViewBand)f).ReadOnly = true;
		((Form)this).AcceptButton = (IButtonControl)(object)this.m_e;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)btnCancel;
		((Form)this).ClientSize = new Size(317, 343);
		((Control)this).Controls.Add((Control)(object)dgvItems);
		((Control)this).Controls.Add((Control)(object)btnCancel);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)txtInput);
		((Control)this).Controls.Add((Control)(object)lblTitle);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AdditionalInputFrm";
		((Form)this).StartPosition = (FormStartPosition)0;
		((Control)this).Text = "Additional Input Required";
		((Form)this).FormClosing += a;
		((Form)this).Load += b;
		((Form)this).Shown += a;
		((ISupportInitialize)dgvItems).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
