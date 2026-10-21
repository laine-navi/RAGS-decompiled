using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class AdditionalInputFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	public Label lblTitle;

	public TextBox txtInput;

	private Button cfb161b7d53a34ca465d546e89559aa86;

	public Button btnCancel;

	public DataGridView dgvItems;

	private DataGridViewTextBoxColumn c22708ba2ab3d5565a3989b288e68edfb;

	private ListBox c0205cf2c05cff6dd454b5aa2754c9f67;

	private ListBox c85775dd4034e99d4ad054288c65d275d;

	private Action.ActionInputType c8f50a9ac8cde979742f04ab36f7ff0a6;

	public bool bstarted;

	public AdditionalInputFrm(Action.ActionInputType intype, ref ListBox inv, ref ListBox rmobj, ref ListBox chars)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c8f50a9ac8cde979742f04ab36f7ff0a6 = intype;
		c0205cf2c05cff6dd454b5aa2754c9f67 = inv;
		c85775dd4034e99d4ad054288c65d275d = rmobj;
		switch (intype)
		{
		case Action.ActionInputType.Character:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1319);
			for (int l = 0; l < chars.Items.Count; l++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
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
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1372);
			for (int m = 0; m < c0205cf2c05cff6dd454b5aa2754c9f67.Items.Count; m++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)c0205cf2c05cff6dd454b5aa2754c9f67.Items[m]).GetDisplayName() });
			}
			for (int n = 0; n < c85775dd4034e99d4ad054288c65d275d.Items.Count; n++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)c85775dd4034e99d4ad054288c65d275d.Items[n]).GetDisplayName() });
			}
			for (int num8 = 0; num8 < chars.Items.Count; num8++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				if (!(chars.Items[num8] is GameObject gameObject2))
				{
					__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
					continue;
				}
				dgvItems.Rows.Add((object[])new string[1] { gameObject2.GetDisplayName() });
			}
			break;
		}
		case Action.ActionInputType.Inventory:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1372);
			for (int num9 = 0; num9 < c0205cf2c05cff6dd454b5aa2754c9f67.Items.Count; num9++)
			{
				dgvItems.Rows.Add((object[])new string[1] { ((GameObject)c0205cf2c05cff6dd454b5aa2754c9f67.Items[num9]).GetDisplayName() });
			}
			break;
		}
		case Action.ActionInputType.ObjectOrCharacter:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1372);
			for (int i = 0; i < c0205cf2c05cff6dd454b5aa2754c9f67.Items.Count; i++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				int num4 = dgvItems.Rows.Add((object[])new string[1] { ((GameObject)c0205cf2c05cff6dd454b5aa2754c9f67.Items[i]).GetDisplayName() });
				((DataGridViewBand)dgvItems.Rows[num4]).Tag = c0205cf2c05cff6dd454b5aa2754c9f67.Items[i];
			}
			for (int j = 0; j < c85775dd4034e99d4ad054288c65d275d.Items.Count; j++)
			{
				int num5 = dgvItems.Rows.Add((object[])new string[1] { ((GameObject)c85775dd4034e99d4ad054288c65d275d.Items[j]).GetDisplayName() });
				((DataGridViewBand)dgvItems.Rows[num5]).Tag = c85775dd4034e99d4ad054288c65d275d.Items[j];
			}
			for (int k = 0; k < chars.Items.Count; k++)
			{
				__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				Character character = chars.Items[k] as Character;
				if (!(chars.Items[k] is GameObject gameObject))
				{
					__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
					if (character == null)
					{
						__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
						continue;
					}
					dgvItems.Rows.Add((object[])new string[1] { character.Charname });
				}
				else
				{
					int num6 = dgvItems.Rows.Add((object[])new string[1] { gameObject.GetDisplayName() });
					((DataGridViewBand)dgvItems.Rows[num6]).Tag = gameObject;
				}
			}
			break;
		}
		case Action.ActionInputType.Text:
			((Control)dgvItems).Visible = false;
			((Control)txtInput).Visible = true;
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1421);
			break;
		case Action.ActionInputType.Custom:
		{
			((Control)dgvItems).Visible = true;
			((Control)txtInput).Visible = false;
			((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1478);
			IEnumerator enumerator = inv.Items.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
					string text = (string)enumerator.Current;
					string text2 = text;
					Color foreColor = default;
					for (int num = text2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1527), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1527), 0, StringComparison.OrdinalIgnoreCase))
					{
						__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
						int num2 = text2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1532), num);
						num += 2;
						string text3 = text2.Substring(num, num2 - num).Trim();
						if (text3 != string.Empty)
						{
							if (text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535)) <= -1)
							{
								__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
								foreColor = Color.FromName(text3);
							}
							else
							{
								int result = 0;
								string s = text3.Substring(0, text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535)));
								text3 = text3.Remove(0, text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535)) + 1).Trim();
								int.TryParse(s, out var result2);
								s = text3.Substring(0, text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535)));
								text3 = text3.Remove(0, text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535)) + 1).Trim();
								int.TryParse(s, out var result3);
								s = text3;
								int.TryParse(s, out result);
								foreColor = Color.FromArgb(result2, result3, result);
							}
						}
						num -= 2;
						text2 = text2.Remove(num, num2 - num + 1);
						num2 = text2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1538), num, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
						}
						else
						{
							text2 = text2.Remove(num2, 4);
						}
					}
					int num3 = dgvItems.Rows.Add((object[])new string[1] { text2 });
					((DataGridViewBand)dgvItems.Rows[num3]).DefaultCellStyle.ForeColor = foreColor;
				}
				break;
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(AdditionalInputFrm._002Ector(Action.ActionInputType, ref ListBox, ref ListBox, ref ListBox));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (c501c89bc63d55bb522eac228aeeebb18 == null)
			{
				__ldtoken(AdditionalInputFrm.Dispose(bool));
			}
			else
			{
				c501c89bc63d55bb522eac228aeeebb18.Dispose();
			}
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected Obj, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected Obj, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdditionalInputFrm));
		lblTitle = new Label();
		txtInput = new TextBox();
		cfb161b7d53a34ca465d546e89559aa86 = new Button();
		btnCancel = new Button();
		dgvItems = new DataGridView();
		c22708ba2ab3d5565a3989b288e68edfb = new DataGridViewTextBoxColumn();
		((ISupportInitialize)dgvItems).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblTitle).AutoSize = true;
		((Control)lblTitle).Location = new Point(12, 9);
		((Control)lblTitle).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1039);
		((Control)lblTitle).Size = new Size(116, 13);
		((Control)lblTitle).TabIndex = 0;
		((Control)lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1056);
		((Control)txtInput).Anchor = (AnchorStyles)15;
		((Control)txtInput).Location = new Point(15, 25);
		((TextBoxBase)txtInput).Multiline = true;
		((Control)txtInput).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1101);
		((Control)txtInput).Size = new Size(292, 265);
		((Control)txtInput).TabIndex = 1;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Anchor = (AnchorStyles)2;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Location = new Point(70, 308);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1118);
		((Control)cfb161b7d53a34ca465d546e89559aa86).Size = new Size(58, 23);
		((Control)cfb161b7d53a34ca465d546e89559aa86).TabIndex = 3;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1129);
		((ButtonBase)cfb161b7d53a34ca465d546e89559aa86).UseVisualStyleBackColor = true;
		((Control)cfb161b7d53a34ca465d546e89559aa86).Click += cae5d311ccae5f42a5309e3afd77dfd28;
		((Control)btnCancel).Anchor = (AnchorStyles)2;
		btnCancel.DialogResult = (DialogResult)2;
		((Control)btnCancel).Location = new Point(189, 308);
		((Control)btnCancel).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1134);
		((Control)btnCancel).Size = new Size(58, 23);
		((Control)btnCancel).TabIndex = 4;
		((Control)btnCancel).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153);
		((ButtonBase)btnCancel).UseVisualStyleBackColor = true;
		((Control)btnCancel).Click += ccf3da658dce1d38918f914da56805590;
		dgvItems.AllowUserToAddRows = false;
		dgvItems.AllowUserToDeleteRows = false;
		((Control)dgvItems).Anchor = (AnchorStyles)15;
		dgvItems.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		dgvItems.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		dgvItems.ColumnHeadersVisible = false;
		dgvItems.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb });
		((Control)dgvItems).Location = new Point(15, 25);
		dgvItems.MultiSelect = false;
		((Control)dgvItems).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1166);
		dgvItems.ReadOnly = true;
		dgvItems.RowHeadersWidth = 4;
		dgvItems.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)dgvItems).Size = new Size(294, 273);
		((Control)dgvItems).TabIndex = 5;
		((Control)dgvItems).DoubleClick += cc972ab1350d247a44d91f183a620dcc9;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)c22708ba2ab3d5565a3989b288e68edfb).DefaultCellStyle = val;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1183);
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1216);
		((DataGridViewBand)c22708ba2ab3d5565a3989b288e68edfb).ReadOnly = true;
		((Form)this).AcceptButton = (IButtonControl)(object)cfb161b7d53a34ca465d546e89559aa86;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)btnCancel;
		((Form)this).ClientSize = new Size(317, 343);
		((Control)this).Controls.Add((Control)(object)dgvItems);
		((Control)this).Controls.Add((Control)(object)btnCancel);
		((Control)this).Controls.Add((Control)(object)cfb161b7d53a34ca465d546e89559aa86);
		((Control)this).Controls.Add((Control)(object)txtInput);
		((Control)this).Controls.Add((Control)(object)lblTitle);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1231);
		((Form)this).StartPosition = (FormStartPosition)0;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1268);
		((Form)this).FormClosing += cd0a16fa019d6be3592c5221cff8116d2;
		((Form)this).Load += caecca9bdde36390d5b5bad7aaa600d8e;
		((Form)this).Shown += c762e2f9317ab0ad0664d4a495f37c58a;
		((ISupportInitialize)dgvItems).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void cae5d311ccae5f42a5309e3afd77dfd28(object P_0, EventArgs P_1)
	{
		bstarted = true;
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void ccf3da658dce1d38918f914da56805590(object P_0, EventArgs P_1)
	{
		bstarted = true;
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void c59377d07312e0336f49fa743da26cf22(object P_0, MouseEventArgs P_1)
	{
		cae5d311ccae5f42a5309e3afd77dfd28(null, null);
	}

	private void cc972ab1350d247a44d91f183a620dcc9(object P_0, EventArgs P_1)
	{
		cae5d311ccae5f42a5309e3afd77dfd28(null, null);
	}

	private void caecca9bdde36390d5b5bad7aaa600d8e(object P_0, EventArgs P_1)
	{
	}

	private void c762e2f9317ab0ad0664d4a495f37c58a(object P_0, EventArgs P_1)
	{
	}

	private void cd0a16fa019d6be3592c5221cff8116d2(object P_0, FormClosingEventArgs P_1)
	{
		if (!bstarted)
		{
			((Form)this).DialogResult = (DialogResult)4;
		}
	}
}
