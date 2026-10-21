using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using A;
using Rags;

namespace RagsDesigner;

public sealed class SearchForm : Form
{
	private Form1 cc55b812a2b1834b6147b00cfb95db764;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	private TextBox cedf1ed49a7b7ed2065f81247fcb39a2c;

	private Button c79769badd3b3f4571a08b51317e02dcc;

	private DataGridView caa329b4b7f9e76dd41fe0fe3342919e9;

	private DataGridViewTextBoxColumn c22708ba2ab3d5565a3989b288e68edfb;

	private DataGridViewTextBoxColumn c8704de44a7c31426ee25f857b8e9fe5e;

	private DataGridViewTextBoxColumn c8303633d94e75b0fc7b087348d313165;

	public SearchForm(Form1 tempparent)
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
		cc55b812a2b1834b6147b00cfb95db764 = tempparent;
	}

	private void c014c4a1d229a3d5152a7b938833b02a5(object P_0, EventArgs P_1)
	{
		caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Clear();
		SqlCeConnection dBConnection = Game.GetDBConnection();
		if (dBConnection == null)
		{
			return;
		}
		__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
		IEnumerator enumerator = Form1.TheGame.RoomList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
				Room room = (Room)enumerator.Current;
				foreach (Rags.Action action6 in room.Actions)
				{
					StringBuilder CurDoc = new StringBuilder();
					action6.GetXMLData(ref CurDoc);
					if (CurDoc.ToString().IndexOf(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text, StringComparison.CurrentCultureIgnoreCase) <= -1)
					{
						__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
						continue;
					}
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(CurDoc.ToString());
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
					string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
					if (xmlNodeList.Count <= 0)
					{
						__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
					}
					else
					{
						text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList[0].InnerText;
					}
					caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
					{
						cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72841),
						room.Name,
						text
					});
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		IEnumerator enumerator3 = Form1.TheGame.ThePlayer.Actions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Rags.Action action2 = (Rags.Action)enumerator3.Current;
				StringBuilder CurDoc2 = new StringBuilder();
				action2.GetXMLData(ref CurDoc2);
				if (CurDoc2.ToString().IndexOf(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text, StringComparison.CurrentCultureIgnoreCase) <= -1)
				{
					__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
					continue;
				}
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadXml(CurDoc2.ToString());
				XmlNodeList xmlNodeList2 = xmlDocument2.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
				string text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
				if (xmlNodeList2.Count <= 0)
				{
					__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
				}
				else
				{
					text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList2[0].InnerText;
				}
				caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
				{
					cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(593),
					cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72850),
					text2
				});
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable2))
			{
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator4 = Form1.TheGame.ObjectList.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
				GameObject gameObject = (GameObject)enumerator4.Current;
				IEnumerator enumerator5 = gameObject.Actions.GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
						Rags.Action action3 = (Rags.Action)enumerator5.Current;
						StringBuilder CurDoc3 = new StringBuilder();
						action3.GetXMLData(ref CurDoc3);
						if (CurDoc3.ToString().IndexOf(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text, StringComparison.CurrentCultureIgnoreCase) <= -1)
						{
							__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
							continue;
						}
						XmlDocument xmlDocument3 = new XmlDocument();
						xmlDocument3.LoadXml(CurDoc3.ToString());
						XmlNodeList xmlNodeList3 = xmlDocument3.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
						string text3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
						if (xmlNodeList3.Count <= 0)
						{
							__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
						}
						else
						{
							text3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList3[0].InnerText;
						}
						caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
						{
							cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72879),
							gameObject.name,
							text3
						});
					}
				}
				finally
				{
					if (!(enumerator5 is IDisposable disposable3))
					{
						__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
					}
					else
					{
						disposable3.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable7 = enumerator4 as IDisposable;
			if (disposable7 != null)
			{
				disposable7.Dispose();
			}
		}
		IEnumerator enumerator6 = Form1.TheGame.CharacterList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				Character character = (Character)enumerator6.Current;
				IEnumerator enumerator7 = character.Actions.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						Rags.Action action4 = (Rags.Action)enumerator7.Current;
						StringBuilder CurDoc4 = new StringBuilder();
						action4.GetXMLData(ref CurDoc4);
						if (CurDoc4.ToString().IndexOf(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text, StringComparison.CurrentCultureIgnoreCase) <= -1)
						{
							__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
							continue;
						}
						XmlDocument xmlDocument4 = new XmlDocument();
						xmlDocument4.LoadXml(CurDoc4.ToString());
						XmlNodeList xmlNodeList4 = xmlDocument4.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
						string text4 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
						if (xmlNodeList4.Count > 0)
						{
							text4 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList4[0].InnerText;
						}
						caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
						{
							cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72888),
							character.Charname,
							text4
						});
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable4))
					{
						__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
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
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				disposable5.Dispose();
			}
		}
		IEnumerator enumerator8 = Form1.TheGame.TimerList.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				Timer timer = (Timer)enumerator8.Current;
				{
					IEnumerator enumerator9 = timer.Actions.GetEnumerator();
					try
					{
						while (enumerator9.MoveNext())
						{
							__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
							Rags.Action action5 = (Rags.Action)enumerator9.Current;
							StringBuilder CurDoc5 = new StringBuilder();
							action5.GetXMLData(ref CurDoc5);
							if (CurDoc5.ToString().IndexOf(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text, StringComparison.CurrentCultureIgnoreCase) <= -1)
							{
								__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
								continue;
							}
							XmlDocument xmlDocument5 = new XmlDocument();
							xmlDocument5.LoadXml(CurDoc5.ToString());
							XmlNodeList xmlNodeList5 = xmlDocument5.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
							string text5 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
							if (xmlNodeList5.Count > 0)
							{
								text5 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList5[0].InnerText;
							}
							caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
							{
								cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72907),
								timer.Name,
								text5
							});
						}
					}
					finally
					{
						IDisposable disposable8 = enumerator9 as IDisposable;
						if (disposable8 != null)
						{
							disposable8.Dispose();
						}
					}
				}
			}
		}
		finally
		{
			if (!(enumerator8 is IDisposable disposable6))
			{
				__ldtoken(SearchForm.c014c4a1d229a3d5152a7b938833b02a5(object, EventArgs));
			}
			else
			{
				disposable6.Dispose();
			}
		}
	}

	private void cedebdb6501a76bdc0b712e03301d54bc(SqlCeDataReader P_0, string P_1, string P_2)
	{
		while (P_0.Read())
		{
			__ldtoken(SearchForm.cedebdb6501a76bdc0b712e03301d54bc(SqlCeDataReader, string, string));
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(P_0[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37621)].ToString());
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72786));
			string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72809);
			if (xmlNodeList.Count <= 0)
			{
				__ldtoken(SearchForm.cedebdb6501a76bdc0b712e03301d54bc(SqlCeDataReader, string, string));
			}
			else
			{
				text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72824) + xmlNodeList[0].InnerText;
			}
			caa329b4b7f9e76dd41fe0fe3342919e9.Rows.Add(new object[3]
			{
				P_1,
				P_0[P_2],
				text
			});
		}
	}

	private void c65883e91d73a43ad7e62086fe09379c0(object P_0, EventArgs P_1)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected Obj, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected Obj, but got Unknown
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected Obj, but got Unknown
		if (((BaseCollection)caa329b4b7f9e76dd41fe0fe3342919e9.SelectedRows).Count <= 0)
		{
			return;
		}
		__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
		int index = ((DataGridViewBand)caa329b4b7f9e76dd41fe0fe3342919e9.SelectedRows[0]).Index;
		if (index < 0)
		{
			__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
		}
		else
		{
			if (caa329b4b7f9e76dd41fe0fe3342919e9.Rows[index].Cells[0].Value == null)
			{
				return;
			}
			string text = caa329b4b7f9e76dd41fe0fe3342919e9.Rows[index].Cells[0].Value.ToString();
			string text2 = caa329b4b7f9e76dd41fe0fe3342919e9.Rows[index].Cells[1].Value.ToString();
			string text3 = caa329b4b7f9e76dd41fe0fe3342919e9.Rows[index].Cells[2].Value.ToString();
			if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72841)))
			{
				__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
				if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72879))
				{
					cc55b812a2b1834b6147b00cfb95db764.tabControl1.SelectedIndex = 3;
					cc55b812a2b1834b6147b00cfb95db764.tabControl3.SelectedIndex = 3;
					TreeNode[] array = cc55b812a2b1834b6147b00cfb95db764.tvItems.Nodes.Find(text2, true);
					if (array.Length <= 0)
					{
						__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
						{
							IEnumerator enumerator = cc55b812a2b1834b6147b00cfb95db764.tvItems.Nodes.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
									TreeNode val = (TreeNode)enumerator.Current;
									if (!c2e9a27fa412ccda834dbdb7e941f055f(val, cc55b812a2b1834b6147b00cfb95db764.tvItems, text2))
									{
										continue;
									}
									__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
									break;
								}
							}
							finally
							{
								IDisposable disposable3 = enumerator as IDisposable;
								if (disposable3 != null)
								{
									disposable3.Dispose();
								}
							}
						}
					}
					else
					{
						cc55b812a2b1834b6147b00cfb95db764.tvItems.SelectedNode = array[0];
					}
					c0246229eab1529afc62b444fd5789851(text3, cc55b812a2b1834b6147b00cfb95db764.ObjectActions);
					return;
				}
				if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72888)))
				{
					__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
					if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(593)))
					{
						__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
						if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72907)))
						{
							__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
							return;
						}
						cc55b812a2b1834b6147b00cfb95db764.tabControl1.SelectedIndex = 6;
						cc55b812a2b1834b6147b00cfb95db764.tabControl5.SelectedIndex = 2;
						cc55b812a2b1834b6147b00cfb95db764.dgvTimers.ClearSelection();
						IEnumerator enumerator2 = ((IEnumerable)cc55b812a2b1834b6147b00cfb95db764.dgvTimers.Rows).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								DataGridViewRow val2 = (DataGridViewRow)enumerator2.Current;
								if (!(val2.Cells[1].Value.ToString() == text2))
								{
									__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
									continue;
								}
								((DataGridViewBand)cc55b812a2b1834b6147b00cfb95db764.dgvTimers.Rows[((DataGridViewBand)val2).Index]).Selected = true;
								break;
							}
						}
						finally
						{
							if (!(enumerator2 is IDisposable disposable))
							{
								__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
							}
							else
							{
								disposable.Dispose();
							}
						}
						c0246229eab1529afc62b444fd5789851(text3, cc55b812a2b1834b6147b00cfb95db764.TimerActions);
					}
					else
					{
						cc55b812a2b1834b6147b00cfb95db764.tabControl1.SelectedIndex = 2;
						cc55b812a2b1834b6147b00cfb95db764.tabControl4.SelectedIndex = 2;
						c0246229eab1529afc62b444fd5789851(text3, cc55b812a2b1834b6147b00cfb95db764.PlayerActions);
					}
					return;
				}
				cc55b812a2b1834b6147b00cfb95db764.tabControl1.SelectedIndex = 4;
				cc55b812a2b1834b6147b00cfb95db764.tabControlCharData.SelectedIndex = 2;
				cc55b812a2b1834b6147b00cfb95db764.dgvCharacters.ClearSelection();
				IEnumerator enumerator3 = ((IEnumerable)cc55b812a2b1834b6147b00cfb95db764.dgvCharacters.Rows).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
						DataGridViewRow val3 = (DataGridViewRow)enumerator3.Current;
						if (!(val3.Cells[0].Value.ToString() == text2))
						{
							__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
							continue;
						}
						((DataGridViewBand)cc55b812a2b1834b6147b00cfb95db764.dgvCharacters.Rows[((DataGridViewBand)val3).Index]).Selected = true;
						break;
					}
				}
				finally
				{
					if (!(enumerator3 is IDisposable disposable2))
					{
						__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
					}
					else
					{
						disposable2.Dispose();
					}
				}
				c0246229eab1529afc62b444fd5789851(text3, cc55b812a2b1834b6147b00cfb95db764.CharacterActions);
				return;
			}
			cc55b812a2b1834b6147b00cfb95db764.tabControl1.SelectedIndex = 1;
			cc55b812a2b1834b6147b00cfb95db764.tabControl2.SelectedIndex = 3;
			cc55b812a2b1834b6147b00cfb95db764.dgvRoomList.ClearSelection();
			{
				IEnumerator enumerator4 = ((IEnumerable)cc55b812a2b1834b6147b00cfb95db764.dgvRoomList.Rows).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
						DataGridViewRow val4 = (DataGridViewRow)enumerator4.Current;
						if (!(val4.Cells[0].Value.ToString() == text2))
						{
							__ldtoken(SearchForm.c65883e91d73a43ad7e62086fe09379c0(object, EventArgs));
							continue;
						}
						((DataGridViewBand)cc55b812a2b1834b6147b00cfb95db764.dgvRoomList.Rows[((DataGridViewBand)val4).Index]).Selected = true;
						break;
					}
				}
				finally
				{
					IDisposable disposable4 = enumerator4 as IDisposable;
					if (disposable4 != null)
					{
						disposable4.Dispose();
					}
				}
			}
			c0246229eab1529afc62b444fd5789851(text3, cc55b812a2b1834b6147b00cfb95db764.RoomActions);
		}
	}

	private bool c2e9a27fa412ccda834dbdb7e941f055f(TreeNode P_0, TreeView P_1, string P_2)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		bool flag = false;
		Command command = P_0.Tag as Command;
		Condition condition = P_0.Tag as Condition;
		if (command == null)
		{
			__ldtoken(SearchForm.c2e9a27fa412ccda834dbdb7e941f055f(TreeNode, TreeView, string));
			if (condition != null)
			{
				flag = condition.ContainsValue(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text);
				if (flag)
				{
					P_1.SelectedNode = P_0;
				}
			}
		}
		else
		{
			flag = command.ContainsValue(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text);
			if (!flag)
			{
				__ldtoken(SearchForm.c2e9a27fa412ccda834dbdb7e941f055f(TreeNode, TreeView, string));
			}
			else
			{
				P_1.SelectedNode = P_0;
			}
		}
		if (!flag)
		{
			IEnumerator enumerator = P_0.Nodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TreeNode val = (TreeNode)enumerator.Current;
					flag = c2e9a27fa412ccda834dbdb7e941f055f(val, P_1, P_2);
					if (flag)
					{
						break;
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(SearchForm.c2e9a27fa412ccda834dbdb7e941f055f(TreeNode, TreeView, string));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		return flag;
	}

	private void c0246229eab1529afc62b444fd5789851(string P_0, ActionControl P_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		string[] array = P_0.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(34458) }, StringSplitOptions.None);
		string text = array[1].Trim();
		IEnumerator enumerator = P_1.tvActionsConditions.Nodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TreeNode val = (TreeNode)enumerator.Current;
				if (!(val.Text == text))
				{
					continue;
				}
				P_1.tvActionsConditions.SelectedNode = val;
				val.ExpandAll();
				{
					IEnumerator enumerator2 = val.Nodes.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							__ldtoken(SearchForm.c0246229eab1529afc62b444fd5789851(string, ActionControl));
							TreeNode val2 = (TreeNode)enumerator2.Current;
							if (c0ae31cced0babc8aafd972ce138eba89(val2, P_1))
							{
								break;
							}
						}
						break;
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						if (disposable2 != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(SearchForm.c0246229eab1529afc62b444fd5789851(string, ActionControl));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private bool c0ae31cced0babc8aafd972ce138eba89(TreeNode P_0, ActionControl P_1)
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		bool flag = false;
		Command command = P_0.Tag as Command;
		Condition condition = P_0.Tag as Condition;
		if (command != null)
		{
			flag = command.ContainsValue(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text);
			if (!flag)
			{
				__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
			}
			else
			{
				P_1.tvActionsConditions.SelectedNode = P_0;
			}
		}
		else if (condition == null)
		{
			__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
		}
		else
		{
			flag = condition.ContainsValue(((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Text);
			if (!flag)
			{
				__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
			}
			else
			{
				P_1.tvActionsConditions.SelectedNode = P_0;
			}
		}
		if (flag)
		{
			__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
		}
		else
		{
			IEnumerator enumerator = P_0.Nodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
					TreeNode val = (TreeNode)enumerator.Current;
					flag = c0ae31cced0babc8aafd972ce138eba89(val, P_1);
					if (flag)
					{
						break;
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(SearchForm.c0ae31cced0babc8aafd972ce138eba89(TreeNode, ActionControl));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		return flag;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(SearchForm.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 != null)
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
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
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SearchForm));
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		cedf1ed49a7b7ed2065f81247fcb39a2c = new TextBox();
		c79769badd3b3f4571a08b51317e02dcc = new Button();
		caa329b4b7f9e76dd41fe0fe3342919e9 = new DataGridView();
		c22708ba2ab3d5565a3989b288e68edfb = new DataGridViewTextBoxColumn();
		c8704de44a7c31426ee25f857b8e9fe5e = new DataGridViewTextBoxColumn();
		c8303633d94e75b0fc7b087348d313165 = new DataGridViewTextBoxColumn();
		((ISupportInitialize)caa329b4b7f9e76dd41fe0fe3342919e9).BeginInit();
		((Control)this).SuspendLayout();
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(12, 9);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(68, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72918);
		((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Anchor = (AnchorStyles)13;
		((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Location = new Point(12, 25);
		((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72941);
		((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).Size = new Size(419, 20);
		((Control)cedf1ed49a7b7ed2065f81247fcb39a2c).TabIndex = 1;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Anchor = (AnchorStyles)9;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Location = new Point(437, 25);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(478);
		((Control)c79769badd3b3f4571a08b51317e02dcc).Size = new Size(75, 23);
		((Control)c79769badd3b3f4571a08b51317e02dcc).TabIndex = 2;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72958);
		((ButtonBase)c79769badd3b3f4571a08b51317e02dcc).UseVisualStyleBackColor = true;
		((Control)c79769badd3b3f4571a08b51317e02dcc).Click += c014c4a1d229a3d5152a7b938833b02a5;
		((Control)caa329b4b7f9e76dd41fe0fe3342919e9).Anchor = (AnchorStyles)15;
		caa329b4b7f9e76dd41fe0fe3342919e9.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		caa329b4b7f9e76dd41fe0fe3342919e9.Columns.AddRange(new DataGridViewColumn[3]
		{
			(DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb,
			(DataGridViewColumn)c8704de44a7c31426ee25f857b8e9fe5e,
			(DataGridViewColumn)c8303633d94e75b0fc7b087348d313165
		});
		((Control)caa329b4b7f9e76dd41fe0fe3342919e9).Location = new Point(12, 51);
		caa329b4b7f9e76dd41fe0fe3342919e9.MultiSelect = false;
		((Control)caa329b4b7f9e76dd41fe0fe3342919e9).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72977);
		caa329b4b7f9e76dd41fe0fe3342919e9.RowHeadersWidth = 4;
		caa329b4b7f9e76dd41fe0fe3342919e9.SelectionMode = (DataGridViewSelectionMode)1;
		((Control)caa329b4b7f9e76dd41fe0fe3342919e9).Size = new Size(500, 342);
		((Control)caa329b4b7f9e76dd41fe0fe3342919e9).TabIndex = 3;
		caa329b4b7f9e76dd41fe0fe3342919e9.SelectionChanged += c65883e91d73a43ad7e62086fe09379c0;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).FillWeight = 25f;
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72996);
		((DataGridViewColumn)c22708ba2ab3d5565a3989b288e68edfb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10615);
		((DataGridViewColumn)c8704de44a7c31426ee25f857b8e9fe5e).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)c8704de44a7c31426ee25f857b8e9fe5e).FillWeight = 25f;
		((DataGridViewColumn)c8704de44a7c31426ee25f857b8e9fe5e).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2037);
		((DataGridViewColumn)c8704de44a7c31426ee25f857b8e9fe5e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13463);
		((DataGridViewColumn)c8303633d94e75b0fc7b087348d313165).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)c8303633d94e75b0fc7b087348d313165).FillWeight = 50f;
		((DataGridViewColumn)c8303633d94e75b0fc7b087348d313165).HeaderText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37621);
		((DataGridViewColumn)c8303633d94e75b0fc7b087348d313165).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13478);
		((Form)this).AcceptButton = (IButtonControl)(object)c79769badd3b3f4571a08b51317e02dcc;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(524, 405);
		((Control)this).Controls.Add((Control)(object)caa329b4b7f9e76dd41fe0fe3342919e9);
		((Control)this).Controls.Add((Control)(object)c79769badd3b3f4571a08b51317e02dcc);
		((Control)this).Controls.Add((Control)(object)cedf1ed49a7b7ed2065f81247fcb39a2c);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73019);
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73040);
		((Form)this).TopMost = true;
		((ISupportInitialize)caa329b4b7f9e76dd41fe0fe3342919e9).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
