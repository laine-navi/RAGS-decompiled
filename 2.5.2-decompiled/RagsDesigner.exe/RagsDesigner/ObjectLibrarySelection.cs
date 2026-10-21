using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Rags;

namespace RagsDesigner;

public class ObjectLibrarySelection : Form
{
	private IContainer m_a;

	private Button m_b;

	private Button m_c;

	private Button d;

	private Label e;

	public ListBox lbLibraryItems;

	public ObjectLibrarySelection()
	{
		a();
	}

	private void c(object A_0, EventArgs A_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void b(object A_0, EventArgs A_1)
	{
		foreach (RoomComboItem selectedItem in lbLibraryItems.SelectedItems)
		{
			Guid uniqueID = selectedItem.UniqueID;
			foreach (GameObject item in Form1.ObjectLibrary)
			{
				if (item.UniqueIdentifier == uniqueID)
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, item);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					GameObject gameObject2 = (GameObject)binaryFormatter.Deserialize(memoryStream);
					gameObject2.UniqueIdentifier = Guid.NewGuid();
					binaryFormatter.Serialize(memoryStream, gameObject2);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					GameObject gameObject3 = (GameObject)binaryFormatter.Deserialize(memoryStream);
					gameObject3.UniqueIdentifier = Guid.NewGuid();
					for (int i = 0; i < gameObject3.Actions.Count; i++)
					{
						Rags.Action tempact = (Rags.Action)gameObject3.Actions[i];
						Form1.TheGame.RefactorAction(ref tempact, item.UniqueIdentifier.ToString(), gameObject3.UniqueIdentifier.ToString());
					}
					Form1.TheGame.ObjectList.Add(gameObject3);
					break;
				}
			}
		}
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		foreach (RoomComboItem selectedItem in lbLibraryItems.SelectedItems)
		{
			_ = selectedItem.UniqueID;
			for (int i = 0; i < Form1.ObjectLibrary.Count; i++)
			{
				GameObject obj = (GameObject)Form1.ObjectLibrary[i];
				Form1.ObjectLibrary.Remove(obj);
			}
		}
		MessageBox.Show("Deleted from library successfully.");
		((Form)this).DialogResult = (DialogResult)1;
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
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ObjectLibrarySelection));
		this.m_b = new Button();
		this.m_c = new Button();
		d = new Button();
		e = new Label();
		lbLibraryItems = new ListBox();
		((Control)this).SuspendLayout();
		this.m_b.DialogResult = (DialogResult)2;
		((Control)this.m_b).Location = new Point(249, 347);
		((Control)this.m_b).Name = "btnClose";
		((Control)this.m_b).Size = new Size(75, 23);
		((Control)this.m_b).TabIndex = 15;
		((Control)this.m_b).Text = "Close";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_b).Click += c;
		((Control)this.m_c).Location = new Point(115, 347);
		((Control)this.m_c).Name = "btnDelete";
		((Control)this.m_c).Size = new Size(112, 23);
		((Control)this.m_c).TabIndex = 14;
		((Control)this.m_c).Text = "Delete From Library";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += a;
		((Control)d).Location = new Point(10, 347);
		((Control)d).Name = "btnAdd";
		((Control)d).Size = new Size(83, 23);
		((Control)d).TabIndex = 13;
		((Control)d).Text = "Add To Game";
		((ButtonBase)d).UseVisualStyleBackColor = true;
		((Control)d).Click += b;
		((Control)e).AutoSize = true;
		((Control)e).Location = new Point(7, 4);
		((Control)e).Name = "label1";
		((Control)e).Size = new Size(69, 13);
		((Control)e).TabIndex = 12;
		((Control)e).Text = "Library Items:";
		((ListControl)lbLibraryItems).FormattingEnabled = true;
		((Control)lbLibraryItems).Location = new Point(10, 20);
		((Control)lbLibraryItems).Name = "lbLibraryItems";
		lbLibraryItems.SelectionMode = (SelectionMode)3;
		((Control)lbLibraryItems).Size = new Size(315, 316);
		((Control)lbLibraryItems).TabIndex = 11;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(334, 380);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)lbLibraryItems);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "ObjectLibrarySelection";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "Object Library";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
