using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class GridViewEditor : Form
{
	private Form1 c014f3939aef6747612c9dd1e19ed83c9;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c4684edf2f70d0a4c772b3fcba21d73a9;

	public DataGridView dgvMultiDimensional;

	public GridViewEditor(Form1 pparent)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		c014f3939aef6747612c9dd1e19ed83c9 = pparent;
		c600efd710ea726e17beaa3884a490dc7();
	}

	private void c436c2640bc3ca159d20797fe2bf6f62a(object P_0, DataGridViewCellEventArgs P_1)
	{
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		if (P_1.RowIndex <= -1)
		{
			return;
		}
		ArrayList arrayList = null;
		GameVariable gameVariable = c014f3939aef6747612c9dd1e19ed83c9.tvVariables.SelectedNode.Tag as GameVariable;
		if (P_1.RowIndex + 1 <= gameVariable.VarArray.Count)
		{
			__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
		}
		else
		{
			gameVariable.VarArray.Add(new ArrayList());
			arrayList = (ArrayList)gameVariable.VarArray[P_1.RowIndex];
			for (int i = 0; i < ((BaseCollection)dgvMultiDimensional.Columns).Count; i++)
			{
				__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
				arrayList.Add("");
			}
			((DataGridViewCell)dgvMultiDimensional.Rows[P_1.RowIndex].HeaderCell).Value = ((DataGridViewBand)dgvMultiDimensional.Rows[P_1.RowIndex]).Index.ToString();
		}
		if (P_1.ColumnIndex == -1)
		{
			return;
		}
		__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
		arrayList = (ArrayList)gameVariable.VarArray[P_1.RowIndex];
		if (gameVariable == null)
		{
			__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
			return;
		}
		switch (gameVariable.vartype)
		{
		case GameVariable.VarType.VT_DATETIMEARRAY:
			try
			{
				if (dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Trim() != string.Empty)
				{
					Convert.ToDateTime(dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1));
				dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value = DateTime.Now.ToString();
			}
			arrayList[P_1.ColumnIndex] = dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_NUMBERARRAY:
			try
			{
				if (!(dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Trim() != string.Empty))
				{
					__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
				}
				else
				{
					Convert.ToDouble(dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(139));
				dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value = 0;
			}
			arrayList[P_1.ColumnIndex] = dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_STRINGARRAY:
			if (P_1.ColumnIndex > -1)
			{
				if (dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value != null)
				{
					__ldtoken(GridViewEditor.c436c2640bc3ca159d20797fe2bf6f62a(object, DataGridViewCellEventArgs));
					arrayList[P_1.ColumnIndex] = dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString();
					Form1.TheGame.ValidateText(dgvMultiDimensional[P_1.ColumnIndex, P_1.RowIndex].Value.ToString());
				}
				else
				{
					arrayList[P_1.ColumnIndex] = string.Empty;
				}
			}
			break;
		}
	}

	private void c7cf6ecd65d834a4ca4b9de825b1913d8(object P_0, DataGridViewRowsRemovedEventArgs P_1)
	{
		GameVariable gameVariable = c014f3939aef6747612c9dd1e19ed83c9.tvVariables.SelectedNode.Tag as GameVariable;
		for (int i = 0; i < P_1.RowCount; i++)
		{
			__ldtoken(GridViewEditor.c7cf6ecd65d834a4ca4b9de825b1913d8(object, DataGridViewRowsRemovedEventArgs));
			gameVariable.VarArray.RemoveAt(P_1.RowIndex);
		}
	}

	private void c600efd710ea726e17beaa3884a490dc7()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		if (!(c014f3939aef6747612c9dd1e19ed83c9.tvVariables.SelectedNode.Tag is GameVariable gameVariable))
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			return;
		}
		ArrayList arrayList = null;
		if (gameVariable.VarArray.Count <= 0)
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
		}
		else
		{
			arrayList = gameVariable.VarArray[0] as ArrayList;
		}
		if (gameVariable.VarArray.Count <= 0)
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			return;
		}
		if (arrayList == null)
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			return;
		}
		dgvMultiDimensional.RowsRemoved -= c7cf6ecd65d834a4ca4b9de825b1913d8;
		dgvMultiDimensional.Columns.Clear();
		dgvMultiDimensional.Rows.Clear();
		dgvMultiDimensional.ColumnCount = arrayList.Count;
		for (int i = 0; i < arrayList.Count; i++)
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			dgvMultiDimensional.Columns[i].HeaderText = i.ToString();
			dgvMultiDimensional.Columns[i].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
			dgvMultiDimensional.Columns[i].FillWeight = 100 / dgvMultiDimensional.ColumnCount;
			dgvMultiDimensional.Columns[i].SortMode = (DataGridViewColumnSortMode)0;
		}
		dgvMultiDimensional.RowCount = gameVariable.VarArray.Count + 1;
		int num = -1;
		for (int j = 0; j < gameVariable.VarArray.Count; j++)
		{
			__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			ArrayList arrayList2 = null;
			((DataGridViewCell)dgvMultiDimensional.Rows[j].HeaderCell).Value = j.ToString();
			arrayList2 = gameVariable.VarArray[j] as ArrayList;
			if (arrayList2 != null)
			{
				__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
			}
			else
			{
				gameVariable.VarArray[j] = new ArrayList();
				arrayList2 = gameVariable.VarArray[j] as ArrayList;
				for (int k = 0; k < ((BaseCollection)dgvMultiDimensional.Columns).Count; k++)
				{
					arrayList2.Add("");
				}
			}
			num++;
			for (int l = 0; l < arrayList2.Count; l++)
			{
				__ldtoken(GridViewEditor.c600efd710ea726e17beaa3884a490dc7());
				object obj = arrayList2[l];
				dgvMultiDimensional[l, j].Value = obj.ToString();
			}
		}
		dgvMultiDimensional.RowsRemoved += c7cf6ecd65d834a4ca4b9de825b1913d8;
	}

	private void c7f324705348fcc3390003b4be3497293(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c8b871322ae8eeae456c43a9dadaa13b6(object P_0, EventArgs P_1)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		if (!(c014f3939aef6747612c9dd1e19ed83c9.tvVariables.SelectedNode.Tag is GameVariable gameVariable))
		{
			__ldtoken(GridViewEditor.c8b871322ae8eeae456c43a9dadaa13b6(object, EventArgs));
			return;
		}
		if (gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
		{
			__ldtoken(GridViewEditor.c8b871322ae8eeae456c43a9dadaa13b6(object, EventArgs));
			return;
		}
		DataGridViewCell control = dgvMultiDimensional.SelectedCells[0];
		if (!control.IsInEditMode)
		{
			__ldtoken(GridViewEditor.c8b871322ae8eeae456c43a9dadaa13b6(object, EventArgs));
		}
		else
		{
			dgvMultiDimensional.EndEdit();
		}
		RagsEditor ragsEditor = new RagsEditor(ref control, Form1.TheGame);
		if ((int)((Form)ragsEditor).ShowDialog() != 1)
		{
			__ldtoken(GridViewEditor.c8b871322ae8eeae456c43a9dadaa13b6(object, EventArgs));
		}
		else
		{
			c600efd710ea726e17beaa3884a490dc7();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(GridViewEditor.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected Obj, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected Obj, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected Obj, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GridViewEditor));
		dgvMultiDimensional = new DataGridView();
		c4684edf2f70d0a4c772b3fcba21d73a9 = new Button();
		((ISupportInitialize)dgvMultiDimensional).BeginInit();
		((Control)this).SuspendLayout();
		((Control)dgvMultiDimensional).Anchor = (AnchorStyles)15;
		dgvMultiDimensional.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)6;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Control;
		val.Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(273), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.ColumnHeadersDefaultCellStyle = val;
		dgvMultiDimensional.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(273), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.DefaultCellStyle = val2;
		((Control)dgvMultiDimensional).Location = new Point(12, 12);
		((Control)dgvMultiDimensional).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(314);
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(273), 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.RowHeadersDefaultCellStyle = val3;
		((DataGridViewBand)dgvMultiDimensional.RowTemplate).DefaultCellStyle.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)dgvMultiDimensional.RowTemplate).Resizable = (DataGridViewTriState)1;
		((Control)dgvMultiDimensional).Size = new Size(573, 427);
		((Control)dgvMultiDimensional).TabIndex = 11;
		dgvMultiDimensional.CellValueChanged += c436c2640bc3ca159d20797fe2bf6f62a;
		((Control)dgvMultiDimensional).DoubleClick += c8b871322ae8eeae456c43a9dadaa13b6;
		dgvMultiDimensional.RowsRemoved += c7cf6ecd65d834a4ca4b9de825b1913d8;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Anchor = (AnchorStyles)2;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Location = new Point(261, 445);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(353);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Size = new Size(75, 23);
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).TabIndex = 12;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(368);
		((ButtonBase)c4684edf2f70d0a4c772b3fcba21d73a9).UseVisualStyleBackColor = true;
		((Control)c4684edf2f70d0a4c772b3fcba21d73a9).Click += c7f324705348fcc3390003b4be3497293;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(597, 471);
		((Control)this).Controls.Add((Control)(object)c4684edf2f70d0a4c772b3fcba21d73a9);
		((Control)this).Controls.Add((Control)(object)dgvMultiDimensional);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(398);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(427);
		((ISupportInitialize)dgvMultiDimensional).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
