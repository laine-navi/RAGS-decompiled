using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Rags;

public class DebugDataFrm : Form
{
	private Game m_a;

	private IContainer m_b;

	private DataGridView c;

	private DataGridViewTextBoxColumn d;

	private DataGridViewTextBoxColumn e;

	private TabControl f;

	private TabPage g;

	private TabPage h;

	private TabPage i;

	private DataGridView j;

	private DataGridViewTextBoxColumn k;

	private TabPage l;

	private DataGridView m;

	private DataGridViewTextBoxColumn n;

	private DataGridViewTextBoxColumn o;

	public DebugDataFrm(ref Game curgame)
	{
		this.m_a = curgame;
		a();
	}

	private void a(object A_0, EventArgs A_1)
	{
		RefreshVars();
	}

	public void RefreshVars()
	{
		try
		{
			c.Rows.Clear();
			foreach (GameVariable variable in this.m_a.VariableList)
			{
				string empty = string.Empty;
				switch (variable.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
					empty = variable.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI);
					c.Rows.Add((object[])new string[2] { variable.varname, empty });
					break;
				case GameVariable.VarType.VT_NUMBER:
					empty = variable.dNumType.ToString();
					c.Rows.Add((object[])new string[2] { variable.varname, empty });
					break;
				case GameVariable.VarType.VT_STRING:
					empty = variable.sString;
					c.Rows.Add((object[])new string[2] { variable.varname, empty });
					break;
				case GameVariable.VarType.VT_DATETIMEARRAY:
				{
					for (int k = 0; k < variable.VarArray.Count; k++)
					{
						if (variable.VarArray[k] is ArrayList arrayList3)
						{
							int num3 = 0;
							foreach (string item in arrayList3)
							{
								empty = Convert.ToDateTime(item).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI);
								c.Rows.Add((object[])new string[2]
								{
									variable.varname + "(" + k + ")(" + num3 + ")",
									empty
								});
								num3++;
							}
						}
						else
						{
							empty = ((DateTime)variable.VarArray[k]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", Game.myDTFI);
							c.Rows.Add((object[])new string[2]
							{
								variable.varname + "(" + k + ")",
								empty
							});
						}
					}
					break;
				}
				case GameVariable.VarType.VT_NUMBERARRAY:
				{
					for (int j = 0; j < variable.VarArray.Count; j++)
					{
						if (variable.VarArray[j] is ArrayList arrayList2)
						{
							int num2 = 0;
							foreach (string item2 in arrayList2)
							{
								c.Rows.Add((object[])new string[2]
								{
									variable.varname + "(" + j + ")(" + num2 + ")",
									item2
								});
								num2++;
							}
						}
						else
						{
							empty = ((double)variable.VarArray[j]).ToString();
							c.Rows.Add((object[])new string[2]
							{
								variable.varname + "(" + j + ")",
								empty
							});
						}
					}
					break;
				}
				case GameVariable.VarType.VT_STRINGARRAY:
				{
					for (int i = 0; i < variable.VarArray.Count; i++)
					{
						if (variable.VarArray[i] is ArrayList arrayList)
						{
							int num = 0;
							foreach (string item3 in arrayList)
							{
								c.Rows.Add((object[])new string[2]
								{
									variable.varname + "(" + i + ")(" + num + ")",
									item3
								});
								num++;
							}
						}
						else
						{
							empty = variable.VarArray[i].ToString();
							c.Rows.Add((object[])new string[2]
							{
								variable.varname + "(" + i + ")",
								empty
							});
						}
					}
					break;
				}
				}
			}
			b();
		}
		catch
		{
		}
	}

	private void b()
	{
		m.Rows.Clear();
		foreach (Room room in this.m_a.RoomList)
		{
			foreach (CustomProperty customProperty7 in room.CustomProperties)
			{
				int num = m.Rows.Add((object[])new string[2]
				{
					"ROOM:" + room.Name + ":" + customProperty7.Name,
					customProperty7.Value
				});
				((DataGridViewBand)m.Rows[num]).Tag = room.UniqueID;
			}
		}
		foreach (CustomProperty customProperty8 in this.m_a.ThePlayer.CustomProperties)
		{
			m.Rows.Add((object[])new string[2]
			{
				"PLAYER:" + customProperty8.Name,
				customProperty8.Value
			});
		}
		foreach (GameObject @object in this.m_a.ObjectList)
		{
			foreach (CustomProperty customProperty9 in @object.CustomProperties)
			{
				int num2 = m.Rows.Add((object[])new string[2]
				{
					"ITEM:" + @object.name + ":" + customProperty9.Name,
					customProperty9.Value
				});
				((DataGridViewBand)m.Rows[num2]).Tag = @object.UniqueIdentifier;
			}
		}
		foreach (Character character in this.m_a.CharacterList)
		{
			foreach (CustomProperty customProperty10 in character.CustomProperties)
			{
				m.Rows.Add((object[])new string[2]
				{
					"CHAR:" + character.Charname + ":" + customProperty10.Name,
					customProperty10.Value
				});
			}
		}
		foreach (GameVariable variable in this.m_a.VariableList)
		{
			foreach (CustomProperty customProperty11 in variable.CustomProperties)
			{
				m.Rows.Add((object[])new string[2]
				{
					"VAR:" + variable.varname + ":" + customProperty11.Name,
					customProperty11.Value
				});
			}
		}
		foreach (Timer timer in this.m_a.TimerList)
		{
			foreach (CustomProperty customProperty12 in timer.CustomProperties)
			{
				m.Rows.Add((object[])new string[2]
				{
					"TIMER:" + timer.Name + ":" + customProperty12.Name,
					customProperty12.Value
				});
			}
		}
	}

	private void b(object A_0, DataGridViewCellEventArgs A_1)
	{
		GameVariable gameVariable = null;
		string text = c[0, A_1.RowIndex].Value.ToString();
		for (int i = 0; i < this.m_a.VariableList.Count; i++)
		{
			if (((GameVariable)this.m_a.VariableList[i]).varname == text)
			{
				gameVariable = (GameVariable)this.m_a.VariableList[i];
				break;
			}
		}
		if (gameVariable != null)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				gameVariable.dtDateTime = Convert.ToDateTime(c[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				break;
			case GameVariable.VarType.VT_NUMBER:
				gameVariable.dNumType = Convert.ToDouble(c[A_1.ColumnIndex, A_1.RowIndex].Value.ToString());
				break;
			case GameVariable.VarType.VT_STRING:
				gameVariable.sString = c[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
				break;
			}
		}
	}

	private void a(object A_0, FormClosingEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Form)this).WindowState == 0)
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmTop", ((Control)this).Top.ToString());
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmLeft", ((Control)this).Left.ToString());
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmWidth", ((Control)this).Width.ToString());
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Rags", "DebugFrmHeight", ((Control)this).Height.ToString());
		}
	}

	public void AddExecutionData(string str, bool bBold)
	{
		if (((BaseCollection)j.Columns).Count > 0)
		{
			int num = j.Rows.Add((object[])new string[1] { str });
			if (bBold)
			{
				((DataGridViewBand)j.Rows[num]).DefaultCellStyle.BackColor = Color.Yellow;
			}
			j.FirstDisplayedScrollingRowIndex = num;
		}
	}

	public void AddErrorData(string str)
	{
		if (((BaseCollection)j.Columns).Count > 0)
		{
			int num = j.Rows.Add((object[])new string[1] { str });
			((DataGridViewBand)j.Rows[num]).DefaultCellStyle.BackColor = Color.Red;
			j.FirstDisplayedScrollingRowIndex = num;
		}
	}

	private void a(object A_0, DataGridViewCellEventArgs A_1)
	{
		string[] array = m[0, A_1.RowIndex].Value.ToString().Split(new char[1] { ':' });
		if (array.Length < 2)
		{
			return;
		}
		string value = m[A_1.ColumnIndex, A_1.RowIndex].Value.ToString();
		if (array[0] == "ROOM")
		{
			Room room = null;
			if (((DataGridViewBand)m.Rows[A_1.RowIndex]).Tag != null)
			{
				room = this.m_a.GetRoomByID((Guid)((DataGridViewBand)m.Rows[A_1.RowIndex]).Tag);
			}
			if (room == null)
			{
				return;
			}
			{
				foreach (CustomProperty customProperty7 in room.CustomProperties)
				{
					if (customProperty7.Name == array[2])
					{
						customProperty7.Value = value;
						break;
					}
				}
				return;
			}
		}
		if (array[0] == "PLAYER")
		{
			foreach (CustomProperty customProperty8 in this.m_a.ThePlayer.CustomProperties)
			{
				if (customProperty8.Name == array[1])
				{
					customProperty8.Value = value;
					break;
				}
			}
			return;
		}
		if (array[0] == "ITEM")
		{
			GameObject gameObject = null;
			if (((DataGridViewBand)m.Rows[A_1.RowIndex]).Tag != null)
			{
				gameObject = this.m_a.GetObjectByName(((DataGridViewBand)m.Rows[A_1.RowIndex]).Tag.ToString());
			}
			if (gameObject == null)
			{
				return;
			}
			{
				foreach (CustomProperty customProperty9 in gameObject.CustomProperties)
				{
					if (customProperty9.Name == array[2])
					{
						customProperty9.Value = value;
						break;
					}
				}
				return;
			}
		}
		if (array[0] == "CHAR")
		{
			Character character = null;
			character = this.m_a.GetCharacterByName(array[1]);
			if (character == null)
			{
				return;
			}
			{
				foreach (CustomProperty customProperty10 in character.CustomProperties)
				{
					if (customProperty10.Name == array[2])
					{
						customProperty10.Value = value;
						break;
					}
				}
				return;
			}
		}
		if (array[0] == "VAR")
		{
			GameVariable gameVariable = null;
			gameVariable = this.m_a.GetVariableByName(array[1]);
			if (gameVariable == null)
			{
				return;
			}
			{
				foreach (CustomProperty customProperty11 in gameVariable.CustomProperties)
				{
					if (customProperty11.Name == array[2])
					{
						customProperty11.Value = value;
						break;
					}
				}
				return;
			}
		}
		if (!(array[0] == "TIMER"))
		{
			return;
		}
		Timer timer = null;
		timer = this.m_a.GetTimerByName(array[1]);
		if (timer == null)
		{
			return;
		}
		foreach (CustomProperty customProperty12 in timer.CustomProperties)
		{
			if (customProperty12.Name == array[2])
			{
				customProperty12.Value = value;
				break;
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
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Expected Obj, but got Unknown
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected Obj, but got Unknown
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DebugDataFrm));
		c = new DataGridView();
		d = new DataGridViewTextBoxColumn();
		e = new DataGridViewTextBoxColumn();
		f = new TabControl();
		i = new TabPage();
		j = new DataGridView();
		k = new DataGridViewTextBoxColumn();
		g = new TabPage();
		l = new TabPage();
		m = new DataGridView();
		n = new DataGridViewTextBoxColumn();
		o = new DataGridViewTextBoxColumn();
		h = new TabPage();
		((ISupportInitialize)c).BeginInit();
		((Control)f).SuspendLayout();
		((Control)i).SuspendLayout();
		((ISupportInitialize)j).BeginInit();
		((Control)g).SuspendLayout();
		((Control)l).SuspendLayout();
		((ISupportInitialize)m).BeginInit();
		((Control)this).SuspendLayout();
		c.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		c.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)d,
			(DataGridViewColumn)e
		});
		((Control)c).Dock = (DockStyle)5;
		((Control)c).Location = new Point(3, 3);
		((Control)c).Name = "dgvVariables";
		c.RowHeadersWidth = 4;
		((Control)c).Size = new Size(569, 351);
		((Control)c).TabIndex = 1;
		c.CellEndEdit += b;
		((DataGridViewColumn)d).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)d).HeaderText = "Name";
		((DataGridViewColumn)d).Name = "VarName";
		((DataGridViewBand)d).ReadOnly = true;
		((DataGridViewColumn)e).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)e).HeaderText = "Value";
		((DataGridViewColumn)e).Name = "VarValue";
		f.Alignment = (TabAlignment)1;
		((Control)f).Controls.Add((Control)(object)i);
		((Control)f).Controls.Add((Control)(object)g);
		((Control)f).Controls.Add((Control)(object)l);
		((Control)f).Controls.Add((Control)(object)h);
		((Control)f).Dock = (DockStyle)5;
		((Control)f).Location = new Point(0, 0);
		((Control)f).Name = "tabControl1";
		f.SelectedIndex = 0;
		((Control)f).Size = new Size(583, 383);
		((Control)f).TabIndex = 2;
		((Control)i).Controls.Add((Control)(object)j);
		i.Location = new Point(4, 4);
		((Control)i).Name = "tabPage3";
		((Control)i).Padding = new Padding(3);
		((Control)i).Size = new Size(575, 357);
		i.TabIndex = 2;
		((Control)i).Text = "Execution Log";
		i.UseVisualStyleBackColor = true;
		j.AllowUserToAddRows = false;
		j.AllowUserToDeleteRows = false;
		j.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		j.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		j.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)k });
		((Control)j).Dock = (DockStyle)5;
		((Control)j).Location = new Point(3, 3);
		((Control)j).Name = "dgvExecutionList";
		j.ReadOnly = true;
		j.RowHeadersWidth = 4;
		j.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)j).Size = new Size(569, 351);
		((Control)j).TabIndex = 1;
		((DataGridViewColumn)k).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)k).HeaderText = "Execution Data";
		((DataGridViewColumn)k).Name = "Data";
		((DataGridViewBand)k).ReadOnly = true;
		((Control)g).Controls.Add((Control)(object)c);
		g.Location = new Point(4, 4);
		((Control)g).Name = "tabPage1";
		((Control)g).Padding = new Padding(3);
		((Control)g).Size = new Size(575, 357);
		g.TabIndex = 0;
		((Control)g).Text = "Variables";
		g.UseVisualStyleBackColor = true;
		((Control)l).Controls.Add((Control)(object)m);
		l.Location = new Point(4, 4);
		((Control)l).Name = "tabPage4";
		((Control)l).Padding = new Padding(3);
		((Control)l).Size = new Size(575, 357);
		l.TabIndex = 3;
		((Control)l).Text = "Custom Properties";
		l.UseVisualStyleBackColor = true;
		m.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		m.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)n,
			(DataGridViewColumn)o
		});
		((Control)m).Dock = (DockStyle)5;
		((Control)m).Location = new Point(3, 3);
		((Control)m).Name = "dgvCustProp";
		m.RowHeadersWidth = 4;
		((Control)m).Size = new Size(569, 351);
		((Control)m).TabIndex = 2;
		m.CellEndEdit += a;
		((DataGridViewColumn)n).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)n).HeaderText = "Name";
		((DataGridViewColumn)n).Name = "dataGridViewTextBoxColumn1";
		((DataGridViewBand)n).ReadOnly = true;
		((DataGridViewColumn)o).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)o).HeaderText = "Value";
		((DataGridViewColumn)o).Name = "dataGridViewTextBoxColumn2";
		h.Location = new Point(4, 4);
		((Control)h).Name = "tabPage2";
		((Control)h).Padding = new Padding(3);
		((Control)h).Size = new Size(575, 357);
		h.TabIndex = 1;
		((Control)h).Text = "Player";
		h.UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(583, 383);
		((Control)this).Controls.Add((Control)(object)f);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "DebugDataFrm";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "DebugDataFrm";
		((Form)this).Load += a;
		((Form)this).FormClosing += a;
		((ISupportInitialize)c).EndInit();
		((Control)f).ResumeLayout(false);
		((Control)i).ResumeLayout(false);
		((ISupportInitialize)j).EndInit();
		((Control)g).ResumeLayout(false);
		((Control)l).ResumeLayout(false);
		((ISupportInitialize)m).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
