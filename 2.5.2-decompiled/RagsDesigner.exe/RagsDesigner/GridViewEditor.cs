using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class GridViewEditor : Form
{
	private Form1 m_a;

	private IContainer m_b;

	private Button c;

	public DataGridView dgvMultiDimensional;

	public GridViewEditor(Form1 pparent)
	{
		a();
		this.m_a = pparent;
		b();
	}

	private void a(object A_0, DataGridViewCellEventArgs A_1)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		if (A_1.RowIndex <= -1)
		{
			return;
		}
		ArrayList arrayList = null;
		GameVariable gameVariable = this.m_a.tvVariables.SelectedNode.Tag as GameVariable;
		if (A_1.RowIndex + 1 > gameVariable.VarArray.Count)
		{
			gameVariable.VarArray.Add(new ArrayList());
			arrayList = (ArrayList)gameVariable.VarArray[A_1.RowIndex];
			for (int i = 0; i < ((BaseCollection)dgvMultiDimensional.Columns).Count; i++)
			{
				arrayList.Add("");
			}
			((DataGridViewCell)dgvMultiDimensional.Rows[A_1.RowIndex].HeaderCell).Value = ((DataGridViewBand)dgvMultiDimensional.Rows[A_1.RowIndex]).Index.ToString();
		}
		if (A_1.ColumnIndex == -1)
		{
			return;
		}
		arrayList = (ArrayList)gameVariable.VarArray[A_1.RowIndex];
		if (gameVariable == null)
		{
			return;
		}
		switch (gameVariable.vartype)
		{
		case GameVariable.VarType.VT_DATETIMEARRAY:
			try
			{
				if (dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString().Trim() != string.Empty)
				{
					Convert.ToDateTime(dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show("You have entered an invalid date time value.  It has been defaulted.");
				dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value = DateTime.Now.ToString();
			}
			arrayList[A_1.ColumnIndex] = dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_NUMBERARRAY:
			try
			{
				if (dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString().Trim() != string.Empty)
				{
					Convert.ToDouble(dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				}
			}
			catch
			{
				MessageBox.Show("You have entered an invalid numeric value.  It has been defaulted.");
				dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value = 0;
			}
			arrayList[A_1.ColumnIndex] = dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
			break;
		case GameVariable.VarType.VT_STRINGARRAY:
			if (A_1.ColumnIndex > -1)
			{
				if (dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value == null)
				{
					arrayList[A_1.ColumnIndex] = string.Empty;
					break;
				}
				arrayList[A_1.ColumnIndex] = dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
				Form1.TheGame.ValidateText(dgvMultiDimensional[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
			}
			break;
		}
	}

	private void a(object A_0, DataGridViewRowsRemovedEventArgs A_1)
	{
		GameVariable gameVariable = this.m_a.tvVariables.SelectedNode.Tag as GameVariable;
		for (int i = 0; i < A_1.RowCount; i++)
		{
			gameVariable.VarArray.RemoveAt(A_1.RowIndex);
		}
	}

	private void b()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected Obj, but got Unknown
		if (!(this.m_a.tvVariables.SelectedNode.Tag is GameVariable gameVariable))
		{
			return;
		}
		ArrayList arrayList = null;
		if (gameVariable.VarArray.Count > 0)
		{
			arrayList = gameVariable.VarArray[0] as ArrayList;
		}
		if (gameVariable.VarArray.Count <= 0 || arrayList == null)
		{
			return;
		}
		dgvMultiDimensional.RowsRemoved -= a;
		dgvMultiDimensional.Columns.Clear();
		dgvMultiDimensional.Rows.Clear();
		dgvMultiDimensional.ColumnCount = arrayList.Count;
		for (int i = 0; i < arrayList.Count; i++)
		{
			dgvMultiDimensional.Columns[i].HeaderText = i.ToString();
			dgvMultiDimensional.Columns[i].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
			dgvMultiDimensional.Columns[i].FillWeight = 100 / dgvMultiDimensional.ColumnCount;
			dgvMultiDimensional.Columns[i].SortMode = (DataGridViewColumnSortMode)0;
		}
		dgvMultiDimensional.RowCount = gameVariable.VarArray.Count + 1;
		int num = -1;
		for (int j = 0; j < gameVariable.VarArray.Count; j++)
		{
			ArrayList arrayList2 = null;
			((DataGridViewCell)dgvMultiDimensional.Rows[j].HeaderCell).Value = j.ToString();
			arrayList2 = gameVariable.VarArray[j] as ArrayList;
			if (arrayList2 == null)
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
				object obj = arrayList2[l];
				dgvMultiDimensional[l, j].Value = obj.ToString();
			}
		}
		dgvMultiDimensional.RowsRemoved += a;
	}

	private void b(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		if (this.m_a.tvVariables.SelectedNode.Tag is GameVariable { vartype: GameVariable.VarType.VT_STRINGARRAY })
		{
			DataGridViewCell control = dgvMultiDimensional.SelectedCells[0];
			if (control.IsInEditMode)
			{
				dgvMultiDimensional.EndEdit();
			}
			if ((int)((Form)new RagsEditor(ref control, Form1.TheGame)).ShowDialog() == 1)
			{
				b();
			}
		}
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Obj, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Obj, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected Obj, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GridViewEditor));
		dgvMultiDimensional = new DataGridView();
		c = new Button();
		((ISupportInitialize)dgvMultiDimensional).BeginInit();
		((Control)this).SuspendLayout();
		((Control)dgvMultiDimensional).Anchor = (AnchorStyles)15;
		dgvMultiDimensional.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)6;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.ColumnHeadersDefaultCellStyle = val;
		dgvMultiDimensional.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.DefaultCellStyle = val2;
		((Control)dgvMultiDimensional).Location = new Point(12, 12);
		((Control)dgvMultiDimensional).Name = "dgvMultiDimensional";
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		dgvMultiDimensional.RowHeadersDefaultCellStyle = val3;
		((DataGridViewBand)dgvMultiDimensional.RowTemplate).DefaultCellStyle.WrapMode = (DataGridViewTriState)1;
		((DataGridViewBand)dgvMultiDimensional.RowTemplate).Resizable = (DataGridViewTriState)1;
		((Control)dgvMultiDimensional).Size = new Size(573, 427);
		((Control)dgvMultiDimensional).TabIndex = 11;
		dgvMultiDimensional.CellValueChanged += a;
		((Control)dgvMultiDimensional).DoubleClick += a;
		dgvMultiDimensional.RowsRemoved += a;
		((Control)c).Anchor = (AnchorStyles)2;
		((Control)c).Location = new Point(261, 445);
		((Control)c).Name = "btnDone";
		((Control)c).Size = new Size(75, 23);
		((Control)c).TabIndex = 12;
		((Control)c).Text = "Done";
		((ButtonBase)c).UseVisualStyleBackColor = true;
		((Control)c).Click += b;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(597, 471);
		((Control)this).Controls.Add((Control)(object)c);
		((Control)this).Controls.Add((Control)(object)dgvMultiDimensional);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "GridViewEditor";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Array Editor";
		((ISupportInitialize)dgvMultiDimensional).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
