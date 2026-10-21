using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using A;
using Microsoft.Win32;

namespace Rags;

public sealed class DebugDataFrm : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private DataGridView cc000b59048a39691e1e7202b5754b681;

	private DataGridViewTextBoxColumn cf80aaf1548cbd2d0100cdce6d55ae47b;

	private DataGridViewTextBoxColumn cda5a1eaa87490425ac829f37d314f477;

	private TabControl cff3baebe1925c32e759a585f1b66b4f9;

	private TabPage c8056e03901b460fdcab42036504c5ecb;

	private TabPage c684d59c2456e3f93a0e2883ff138ecf7;

	private TabPage c5f7350fd3246fdffb78d62e89539b883;

	private DataGridView c52cf6582b3381833277008b305280868;

	private DataGridViewTextBoxColumn c3090844d732f5a421f34e103b413422c;

	private TabPage cd17d0986f8a2a1d498ee138a6487eb60;

	private DataGridView c09d0c5a7f06fd72afb27e623fc0af81d;

	private DataGridViewTextBoxColumn c184bb4f23109e8bb4c080caa67123a47;

	private DataGridViewTextBoxColumn cddcf08875f36909b42302fc663c9cb30;

	private Game c54f9a911545745b85ae6f74355697f8b;

	public DebugDataFrm(ref Game curgame)
	{
		c54f9a911545745b85ae6f74355697f8b = curgame;
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && c501c89bc63d55bb522eac228aeeebb18 != null)
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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected Obj, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected Obj, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Expected Obj, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DebugDataFrm));
		cc000b59048a39691e1e7202b5754b681 = new DataGridView();
		cf80aaf1548cbd2d0100cdce6d55ae47b = new DataGridViewTextBoxColumn();
		cda5a1eaa87490425ac829f37d314f477 = new DataGridViewTextBoxColumn();
		cff3baebe1925c32e759a585f1b66b4f9 = new TabControl();
		c5f7350fd3246fdffb78d62e89539b883 = new TabPage();
		c52cf6582b3381833277008b305280868 = new DataGridView();
		c3090844d732f5a421f34e103b413422c = new DataGridViewTextBoxColumn();
		c8056e03901b460fdcab42036504c5ecb = new TabPage();
		cd17d0986f8a2a1d498ee138a6487eb60 = new TabPage();
		c09d0c5a7f06fd72afb27e623fc0af81d = new DataGridView();
		c184bb4f23109e8bb4c080caa67123a47 = new DataGridViewTextBoxColumn();
		cddcf08875f36909b42302fc663c9cb30 = new DataGridViewTextBoxColumn();
		c684d59c2456e3f93a0e2883ff138ecf7 = new TabPage();
		((ISupportInitialize)cc000b59048a39691e1e7202b5754b681).BeginInit();
		((Control)cff3baebe1925c32e759a585f1b66b4f9).SuspendLayout();
		((Control)c5f7350fd3246fdffb78d62e89539b883).SuspendLayout();
		((ISupportInitialize)c52cf6582b3381833277008b305280868).BeginInit();
		((Control)c8056e03901b460fdcab42036504c5ecb).SuspendLayout();
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).SuspendLayout();
		((ISupportInitialize)c09d0c5a7f06fd72afb27e623fc0af81d).BeginInit();
		((Control)this).SuspendLayout();
		cc000b59048a39691e1e7202b5754b681.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		cc000b59048a39691e1e7202b5754b681.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)cf80aaf1548cbd2d0100cdce6d55ae47b,
			(DataGridViewColumn)cda5a1eaa87490425ac829f37d314f477
		});
		((Control)cc000b59048a39691e1e7202b5754b681).Dock = (DockStyle)5;
		((Control)cc000b59048a39691e1e7202b5754b681).Location = new Point(3, 3);
		((Control)cc000b59048a39691e1e7202b5754b681).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(180);
		cc000b59048a39691e1e7202b5754b681.RowHeadersWidth = 4;
		((Control)cc000b59048a39691e1e7202b5754b681).Size = new Size(569, 351);
		((Control)cc000b59048a39691e1e7202b5754b681).TabIndex = 1;
		cc000b59048a39691e1e7202b5754b681.CellEndEdit += cb0228abeabd7f05bb857080068221aad;
		((DataGridViewColumn)cf80aaf1548cbd2d0100cdce6d55ae47b).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)cf80aaf1548cbd2d0100cdce6d55ae47b).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205);
		((DataGridViewColumn)cf80aaf1548cbd2d0100cdce6d55ae47b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(214);
		((DataGridViewBand)cf80aaf1548cbd2d0100cdce6d55ae47b).ReadOnly = true;
		((DataGridViewColumn)cda5a1eaa87490425ac829f37d314f477).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)cda5a1eaa87490425ac829f37d314f477).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229);
		((DataGridViewColumn)cda5a1eaa87490425ac829f37d314f477).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(240);
		cff3baebe1925c32e759a585f1b66b4f9.Alignment = (TabAlignment)1;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)c5f7350fd3246fdffb78d62e89539b883);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)c8056e03901b460fdcab42036504c5ecb);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)cd17d0986f8a2a1d498ee138a6487eb60);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Controls.Add((Control)(object)c684d59c2456e3f93a0e2883ff138ecf7);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Dock = (DockStyle)5;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Location = new Point(0, 0);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(257);
		cff3baebe1925c32e759a585f1b66b4f9.SelectedIndex = 0;
		((Control)cff3baebe1925c32e759a585f1b66b4f9).Size = new Size(583, 383);
		((Control)cff3baebe1925c32e759a585f1b66b4f9).TabIndex = 2;
		((Control)c5f7350fd3246fdffb78d62e89539b883).Controls.Add((Control)(object)c52cf6582b3381833277008b305280868);
		c5f7350fd3246fdffb78d62e89539b883.Location = new Point(4, 4);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(280);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Padding = new Padding(3);
		((Control)c5f7350fd3246fdffb78d62e89539b883).Size = new Size(575, 357);
		c5f7350fd3246fdffb78d62e89539b883.TabIndex = 2;
		((Control)c5f7350fd3246fdffb78d62e89539b883).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(297);
		c5f7350fd3246fdffb78d62e89539b883.UseVisualStyleBackColor = true;
		c52cf6582b3381833277008b305280868.AllowUserToAddRows = false;
		c52cf6582b3381833277008b305280868.AllowUserToDeleteRows = false;
		c52cf6582b3381833277008b305280868.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		c52cf6582b3381833277008b305280868.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		c52cf6582b3381833277008b305280868.Columns.AddRange(new DataGridViewColumn[1] { (DataGridViewColumn)c3090844d732f5a421f34e103b413422c });
		((Control)c52cf6582b3381833277008b305280868).Dock = (DockStyle)5;
		((Control)c52cf6582b3381833277008b305280868).Location = new Point(3, 3);
		((Control)c52cf6582b3381833277008b305280868).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(324);
		c52cf6582b3381833277008b305280868.ReadOnly = true;
		c52cf6582b3381833277008b305280868.RowHeadersWidth = 4;
		c52cf6582b3381833277008b305280868.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)c52cf6582b3381833277008b305280868).Size = new Size(569, 351);
		((Control)c52cf6582b3381833277008b305280868).TabIndex = 1;
		((DataGridViewColumn)c3090844d732f5a421f34e103b413422c).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)c3090844d732f5a421f34e103b413422c).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(357);
		((DataGridViewColumn)c3090844d732f5a421f34e103b413422c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(386);
		((DataGridViewBand)c3090844d732f5a421f34e103b413422c).ReadOnly = true;
		((Control)c8056e03901b460fdcab42036504c5ecb).Controls.Add((Control)(object)cc000b59048a39691e1e7202b5754b681);
		c8056e03901b460fdcab42036504c5ecb.Location = new Point(4, 4);
		((Control)c8056e03901b460fdcab42036504c5ecb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(395);
		((Control)c8056e03901b460fdcab42036504c5ecb).Padding = new Padding(3);
		((Control)c8056e03901b460fdcab42036504c5ecb).Size = new Size(575, 357);
		c8056e03901b460fdcab42036504c5ecb.TabIndex = 0;
		((Control)c8056e03901b460fdcab42036504c5ecb).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(412);
		c8056e03901b460fdcab42036504c5ecb.UseVisualStyleBackColor = true;
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Controls.Add((Control)(object)c09d0c5a7f06fd72afb27e623fc0af81d);
		cd17d0986f8a2a1d498ee138a6487eb60.Location = new Point(4, 4);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(431);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Padding = new Padding(3);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Size = new Size(575, 357);
		cd17d0986f8a2a1d498ee138a6487eb60.TabIndex = 3;
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(448);
		cd17d0986f8a2a1d498ee138a6487eb60.UseVisualStyleBackColor = true;
		c09d0c5a7f06fd72afb27e623fc0af81d.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		c09d0c5a7f06fd72afb27e623fc0af81d.Columns.AddRange(new DataGridViewColumn[2]
		{
			(DataGridViewColumn)c184bb4f23109e8bb4c080caa67123a47,
			(DataGridViewColumn)cddcf08875f36909b42302fc663c9cb30
		});
		((Control)c09d0c5a7f06fd72afb27e623fc0af81d).Dock = (DockStyle)5;
		((Control)c09d0c5a7f06fd72afb27e623fc0af81d).Location = new Point(3, 3);
		((Control)c09d0c5a7f06fd72afb27e623fc0af81d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(483);
		c09d0c5a7f06fd72afb27e623fc0af81d.RowHeadersWidth = 4;
		((Control)c09d0c5a7f06fd72afb27e623fc0af81d).Size = new Size(569, 351);
		((Control)c09d0c5a7f06fd72afb27e623fc0af81d).TabIndex = 2;
		c09d0c5a7f06fd72afb27e623fc0af81d.CellEndEdit += cec52b9b98d603d30f5acfcf5393bbf87;
		((DataGridViewColumn)c184bb4f23109e8bb4c080caa67123a47).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)c184bb4f23109e8bb4c080caa67123a47).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205);
		((DataGridViewColumn)c184bb4f23109e8bb4c080caa67123a47).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(506);
		((DataGridViewBand)c184bb4f23109e8bb4c080caa67123a47).ReadOnly = true;
		((DataGridViewColumn)cddcf08875f36909b42302fc663c9cb30).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)cddcf08875f36909b42302fc663c9cb30).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229);
		((DataGridViewColumn)cddcf08875f36909b42302fc663c9cb30).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(559);
		c684d59c2456e3f93a0e2883ff138ecf7.Location = new Point(4, 4);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(612);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Padding = new Padding(3);
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Size = new Size(575, 357);
		c684d59c2456e3f93a0e2883ff138ecf7.TabIndex = 1;
		((Control)c684d59c2456e3f93a0e2883ff138ecf7).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(629);
		c684d59c2456e3f93a0e2883ff138ecf7.UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(583, 383);
		((Control)this).Controls.Add((Control)(object)cff3baebe1925c32e759a585f1b66b4f9);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(642);
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(642);
		((Form)this).Load += c3a778498f4b5580ee0514d51a82930ab;
		((Form)this).FormClosing += cc509de8403deb120f2a5608171534747;
		((ISupportInitialize)cc000b59048a39691e1e7202b5754b681).EndInit();
		((Control)cff3baebe1925c32e759a585f1b66b4f9).ResumeLayout(false);
		((Control)c5f7350fd3246fdffb78d62e89539b883).ResumeLayout(false);
		((ISupportInitialize)c52cf6582b3381833277008b305280868).EndInit();
		((Control)c8056e03901b460fdcab42036504c5ecb).ResumeLayout(false);
		((Control)cd17d0986f8a2a1d498ee138a6487eb60).ResumeLayout(false);
		((ISupportInitialize)c09d0c5a7f06fd72afb27e623fc0af81d).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void c3a778498f4b5580ee0514d51a82930ab(object P_0, EventArgs P_1)
	{
		RefreshVars();
	}

	public void RefreshVars()
	{
		try
		{
			cc000b59048a39691e1e7202b5754b681.Rows.Clear();
			IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.VariableList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(DebugDataFrm.RefreshVars());
					GameVariable gameVariable = (GameVariable)enumerator.Current;
					string empty = string.Empty;
					switch (gameVariable.vartype)
					{
					case GameVariable.VarType.VT_DATETIME:
						empty = gameVariable.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(667), Game.myDTFI);
						cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2] { gameVariable.varname, empty });
						break;
					case GameVariable.VarType.VT_NUMBER:
						empty = gameVariable.dNumType.ToString();
						cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2] { gameVariable.varname, empty });
						break;
					case GameVariable.VarType.VT_STRING:
						empty = gameVariable.sString;
						cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2] { gameVariable.varname, empty });
						break;
					case GameVariable.VarType.VT_DATETIMEARRAY:
					{
						for (int k = 0; k < gameVariable.VarArray.Count; k++)
						{
							if (gameVariable.VarArray[k] is ArrayList arrayList3)
							{
								int num3 = 0;
								IEnumerator enumerator4 = arrayList3.GetEnumerator();
								try
								{
									while (enumerator4.MoveNext())
									{
										string value = (string)enumerator4.Current;
										empty = Convert.ToDateTime(value).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(667), Game.myDTFI);
										cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
										{
											gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + k + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(733) + num3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
											empty
										});
										num3++;
									}
								}
								finally
								{
									if (!(enumerator4 is IDisposable disposable3))
									{
										__ldtoken(DebugDataFrm.RefreshVars());
									}
									else
									{
										disposable3.Dispose();
									}
								}
							}
							else
							{
								empty = ((DateTime)gameVariable.VarArray[k]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(667), Game.myDTFI);
								cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
								{
									gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + k + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
									empty
								});
							}
						}
						break;
					}
					case GameVariable.VarType.VT_NUMBERARRAY:
					{
						for (int j = 0; j < gameVariable.VarArray.Count; j++)
						{
							if (!(gameVariable.VarArray[j] is ArrayList arrayList2))
							{
								__ldtoken(DebugDataFrm.RefreshVars());
								empty = ((double)gameVariable.VarArray[j]).ToString();
								cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
								{
									gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
									empty
								});
								continue;
							}
							int num2 = 0;
							IEnumerator enumerator3 = arrayList2.GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									__ldtoken(DebugDataFrm.RefreshVars());
									string text2 = (string)enumerator3.Current;
									cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
									{
										gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(733) + num2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
										text2
									});
									num2++;
								}
							}
							finally
							{
								if (!(enumerator3 is IDisposable disposable2))
								{
									__ldtoken(DebugDataFrm.RefreshVars());
								}
								else
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					case GameVariable.VarType.VT_STRINGARRAY:
					{
						for (int i = 0; i < gameVariable.VarArray.Count; i++)
						{
							__ldtoken(DebugDataFrm.RefreshVars());
							if (!(gameVariable.VarArray[i] is ArrayList arrayList))
							{
								__ldtoken(DebugDataFrm.RefreshVars());
								empty = gameVariable.VarArray[i].ToString();
								cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
								{
									gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
									empty
								});
								continue;
							}
							int num = 0;
							IEnumerator enumerator2 = arrayList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									string text = (string)enumerator2.Current;
									cc000b59048a39691e1e7202b5754b681.Rows.Add((object[])new string[2]
									{
										gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730) + i + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(733) + num + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738),
										text
									});
									num++;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable))
								{
									__ldtoken(DebugDataFrm.RefreshVars());
								}
								else
								{
									disposable.Dispose();
								}
							}
						}
						break;
					}
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable4))
				{
					__ldtoken(DebugDataFrm.RefreshVars());
				}
				else
				{
					disposable4.Dispose();
				}
			}
			cef2535b1b84b4600a24768127c8d8c15();
		}
		catch
		{
		}
	}

	private void cef2535b1b84b4600a24768127c8d8c15()
	{
		c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
				Room room = (Room)enumerator.Current;
				IEnumerator enumerator2 = room.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
						CustomProperty customProperty = (CustomProperty)enumerator2.Current;
						int num = c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
						{
							cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(741) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + customProperty.Name,
							customProperty.Value
						});
						((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[num]).Tag = room.UniqueID;
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				CustomProperty customProperty2 = (CustomProperty)enumerator3.Current;
				c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
				{
					cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(755) + customProperty2.Name,
					customProperty2.Value
				});
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
			}
			else
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator4 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
				GameObject gameObject = (GameObject)enumerator4.Current;
				foreach (CustomProperty customProperty7 in gameObject.CustomProperties)
				{
					int num2 = c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
					{
						cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(770) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + customProperty7.Name,
						customProperty7.Value
					});
					((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[num2]).Tag = gameObject.UniqueIdentifier;
				}
			}
		}
		finally
		{
			IDisposable disposable8 = enumerator4 as IDisposable;
			if (disposable8 != null)
			{
				disposable8.Dispose();
			}
		}
		IEnumerator enumerator6 = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
				Character character = (Character)enumerator6.Current;
				IEnumerator enumerator7 = character.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
						CustomProperty customProperty4 = (CustomProperty)enumerator7.Current;
						c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
						{
							cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(781) + character.Charname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + customProperty4.Name,
							customProperty4.Value
						});
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable4))
					{
						__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
					}
					else
					{
						disposable4.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator6 is IDisposable disposable5))
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
			}
			else
			{
				disposable5.Dispose();
			}
		}
		foreach (GameVariable variable in c54f9a911545745b85ae6f74355697f8b.VariableList)
		{
			IEnumerator enumerator9 = variable.CustomProperties.GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					CustomProperty customProperty5 = (CustomProperty)enumerator9.Current;
					c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
					{
						cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(792) + variable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + customProperty5.Name,
						customProperty5.Value
					});
				}
			}
			finally
			{
				if (!(enumerator9 is IDisposable disposable6))
				{
					__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
				}
				else
				{
					disposable6.Dispose();
				}
			}
		}
		IEnumerator enumerator10 = c54f9a911545745b85ae6f74355697f8b.TimerList.GetEnumerator();
		try
		{
			while (enumerator10.MoveNext())
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
				Timer timer = (Timer)enumerator10.Current;
				{
					IEnumerator enumerator11 = timer.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator11.MoveNext())
						{
							__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
							CustomProperty customProperty6 = (CustomProperty)enumerator11.Current;
							c09d0c5a7f06fd72afb27e623fc0af81d.Rows.Add((object[])new string[2]
							{
								cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(801) + timer.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + customProperty6.Name,
								customProperty6.Value
							});
						}
					}
					finally
					{
						IDisposable disposable9 = enumerator11 as IDisposable;
						if (disposable9 != null)
						{
							disposable9.Dispose();
						}
					}
				}
			}
		}
		finally
		{
			if (!(enumerator10 is IDisposable disposable7))
			{
				__ldtoken(DebugDataFrm.cef2535b1b84b4600a24768127c8d8c15());
			}
			else
			{
				disposable7.Dispose();
			}
		}
	}

	private void cb0228abeabd7f05bb857080068221aad(object P_0, DataGridViewCellEventArgs P_1)
	{
		GameVariable gameVariable = null;
		string text = cc000b59048a39691e1e7202b5754b681[0, P_1.RowIndex].Value.ToString();
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.VariableList.Count; i++)
		{
			if (!(((GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i]).varname == text))
			{
				__ldtoken(DebugDataFrm.cb0228abeabd7f05bb857080068221aad(object, DataGridViewCellEventArgs));
				continue;
			}
			gameVariable = (GameVariable)c54f9a911545745b85ae6f74355697f8b.VariableList[i];
			break;
		}
		if (gameVariable != null)
		{
			switch (gameVariable.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				gameVariable.dtDateTime = Convert.ToDateTime(cc000b59048a39691e1e7202b5754b681[P_1.ColumnIndex, P_1.RowIndex].Value.ToString());
				break;
			case GameVariable.VarType.VT_NUMBER:
				gameVariable.dNumType = Convert.ToDouble(cc000b59048a39691e1e7202b5754b681[P_1.ColumnIndex, P_1.RowIndex].Value.ToString());
				break;
			case GameVariable.VarType.VT_STRING:
				gameVariable.sString = cc000b59048a39691e1e7202b5754b681[P_1.ColumnIndex, P_1.RowIndex].Value.ToString();
				break;
			}
		}
	}

	private void cc509de8403deb120f2a5608171534747(object P_0, FormClosingEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Form)this).WindowState != 0)
		{
			__ldtoken(DebugDataFrm.cc509de8403deb120f2a5608171534747(object, FormClosingEventArgs));
			return;
		}
		Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(877), ((Control)this).Top.ToString());
		Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(900), ((Control)this).Left.ToString());
		Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(925), ((Control)this).Width.ToString());
		Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(952), ((Control)this).Height.ToString());
	}

	public void AddExecutionData(string str, bool bBold)
	{
		if (((BaseCollection)c52cf6582b3381833277008b305280868.Columns).Count <= 0)
		{
			__ldtoken(DebugDataFrm.AddExecutionData(string, bool));
			return;
		}
		int num = c52cf6582b3381833277008b305280868.Rows.Add((object[])new string[1] { str });
		if (bBold)
		{
			((DataGridViewBand)c52cf6582b3381833277008b305280868.Rows[num]).DefaultCellStyle.BackColor = Color.Yellow;
		}
		c52cf6582b3381833277008b305280868.FirstDisplayedScrollingRowIndex = num;
	}

	public void AddErrorData(string str)
	{
		if (((BaseCollection)c52cf6582b3381833277008b305280868.Columns).Count <= 0)
		{
			__ldtoken(DebugDataFrm.AddErrorData(string));
			return;
		}
		int num = c52cf6582b3381833277008b305280868.Rows.Add((object[])new string[1] { str });
		((DataGridViewBand)c52cf6582b3381833277008b305280868.Rows[num]).DefaultCellStyle.BackColor = Color.Red;
		c52cf6582b3381833277008b305280868.FirstDisplayedScrollingRowIndex = num;
	}

	private void cec52b9b98d603d30f5acfcf5393bbf87(object P_0, DataGridViewCellEventArgs P_1)
	{
		string[] array = c09d0c5a7f06fd72afb27e623fc0af81d[0, P_1.RowIndex].Value.ToString().Split(new char[1] { ':' });
		if (array.Length < 2)
		{
			__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
			return;
		}
		string value = c09d0c5a7f06fd72afb27e623fc0af81d[P_1.ColumnIndex, P_1.RowIndex].Value.ToString();
		if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(981)))
		{
			__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
			if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(990)))
			{
				__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
				if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1003)))
				{
					__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
					if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1012)))
					{
						__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
						if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1021)))
						{
							__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
							if (!(array[0] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1028)))
							{
								__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
								return;
							}
							Timer timer = null;
							timer = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(array[1]);
							if (timer == null)
							{
								__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
								return;
							}
							{
								foreach (CustomProperty customProperty7 in timer.CustomProperties)
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
						GameVariable gameVariable = null;
						gameVariable = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(array[1]);
						if (gameVariable == null)
						{
							__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
							return;
						}
						IEnumerator enumerator2 = gameVariable.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								CustomProperty customProperty2 = (CustomProperty)enumerator2.Current;
								if (customProperty2.Name == array[2])
								{
									customProperty2.Value = value;
									break;
								}
							}
							return;
						}
						finally
						{
							if (!(enumerator2 is IDisposable disposable))
							{
								__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
							}
							else
							{
								disposable.Dispose();
							}
						}
					}
					Character character = null;
					character = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(array[1]);
					if (character == null)
					{
						__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
						return;
					}
					IEnumerator enumerator3 = character.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							CustomProperty customProperty3 = (CustomProperty)enumerator3.Current;
							if (!(customProperty3.Name == array[2]))
							{
								__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
								continue;
							}
							customProperty3.Value = value;
							break;
						}
						return;
					}
					finally
					{
						if (!(enumerator3 is IDisposable disposable2))
						{
							__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
						}
						else
						{
							disposable2.Dispose();
						}
					}
				}
				GameObject gameObject = null;
				if (((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[P_1.RowIndex]).Tag == null)
				{
					__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
				}
				else
				{
					gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[P_1.RowIndex]).Tag.ToString());
				}
				if (gameObject == null)
				{
					__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
					return;
				}
				IEnumerator enumerator4 = gameObject.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						CustomProperty customProperty4 = (CustomProperty)enumerator4.Current;
						if (!(customProperty4.Name == array[2]))
						{
							__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
							continue;
						}
						customProperty4.Value = value;
						break;
					}
					return;
				}
				finally
				{
					if (!(enumerator4 is IDisposable disposable3))
					{
						__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
					}
					else
					{
						disposable3.Dispose();
					}
				}
			}
			IEnumerator enumerator5 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties.GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
					CustomProperty customProperty5 = (CustomProperty)enumerator5.Current;
					if (customProperty5.Name == array[1])
					{
						customProperty5.Value = value;
						break;
					}
				}
				return;
			}
			finally
			{
				if (!(enumerator5 is IDisposable disposable4))
				{
					__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
				}
				else
				{
					disposable4.Dispose();
				}
			}
		}
		Room room = null;
		if (((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[P_1.RowIndex]).Tag == null)
		{
			__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
		}
		else
		{
			room = c54f9a911545745b85ae6f74355697f8b.GetRoomByID((Guid)((DataGridViewBand)c09d0c5a7f06fd72afb27e623fc0af81d.Rows[P_1.RowIndex]).Tag);
		}
		if (room == null)
		{
			__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
			return;
		}
		foreach (CustomProperty customProperty8 in room.CustomProperties)
		{
			if (!(customProperty8.Name == array[2]))
			{
				__ldtoken(DebugDataFrm.cec52b9b98d603d30f5acfcf5393bbf87(object, DataGridViewCellEventArgs));
				continue;
			}
			customProperty8.Value = value;
			break;
		}
	}
}
