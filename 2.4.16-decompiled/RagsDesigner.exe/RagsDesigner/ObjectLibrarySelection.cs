using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using A;
using Rags;

namespace RagsDesigner;

public sealed class ObjectLibrarySelection : Form
{
	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private Button c1b0a6b02b446e7b314f7d993bed548ef;

	private Button cb4e261ca3b37fecaaeb4e6c758995d76;

	private Button cd06b5398b27d091d6962c9c9b75befc4;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	public ListBox lbLibraryItems;

	public ObjectLibrarySelection()
	{
		cffa44bb0cb8be4c595ec865afadbafa5();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(ObjectLibrarySelection.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(ObjectLibrarySelection.Dispose(bool));
		}
		else
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
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ObjectLibrarySelection));
		c1b0a6b02b446e7b314f7d993bed548ef = new Button();
		cb4e261ca3b37fecaaeb4e6c758995d76 = new Button();
		cd06b5398b27d091d6962c9c9b75befc4 = new Button();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		lbLibraryItems = new ListBox();
		((Control)this).SuspendLayout();
		c1b0a6b02b446e7b314f7d993bed548ef.DialogResult = (DialogResult)2;
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).Location = new Point(249, 347);
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72104);
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).Size = new Size(75, 23);
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).TabIndex = 15;
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50141);
		((ButtonBase)c1b0a6b02b446e7b314f7d993bed548ef).UseVisualStyleBackColor = true;
		((Control)c1b0a6b02b446e7b314f7d993bed548ef).Click += c37f17565b7171d31cb300dc6dd8c7807;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Location = new Point(115, 347);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50036);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Size = new Size(112, 23);
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).TabIndex = 14;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72121);
		((ButtonBase)cb4e261ca3b37fecaaeb4e6c758995d76).UseVisualStyleBackColor = true;
		((Control)cb4e261ca3b37fecaaeb4e6c758995d76).Click += c914b66ccd6698aa476f46de7f74982f0;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Location = new Point(10, 347);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50023);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Size = new Size(83, 23);
		((Control)cd06b5398b27d091d6962c9c9b75befc4).TabIndex = 13;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72160);
		((ButtonBase)cd06b5398b27d091d6962c9c9b75befc4).UseVisualStyleBackColor = true;
		((Control)cd06b5398b27d091d6962c9c9b75befc4).Click += c35f4c9b1f3471abe26d64adf521815be;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(7, 4);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1315);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(69, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 12;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72183);
		((ListControl)lbLibraryItems).FormattingEnabled = true;
		((Control)lbLibraryItems).Location = new Point(10, 20);
		((Control)lbLibraryItems).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72212);
		lbLibraryItems.SelectionMode = (SelectionMode)3;
		((Control)lbLibraryItems).Size = new Size(315, 316);
		((Control)lbLibraryItems).TabIndex = 11;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(334, 380);
		((Control)this).Controls.Add((Control)(object)c1b0a6b02b446e7b314f7d993bed548ef);
		((Control)this).Controls.Add((Control)(object)cb4e261ca3b37fecaaeb4e6c758995d76);
		((Control)this).Controls.Add((Control)(object)cd06b5398b27d091d6962c9c9b75befc4);
		((Control)this).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)this).Controls.Add((Control)(object)lbLibraryItems);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(377));
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72241);
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72286);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void c37f17565b7171d31cb300dc6dd8c7807(object P_0, EventArgs P_1)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c35f4c9b1f3471abe26d64adf521815be(object P_0, EventArgs P_1)
	{
		IEnumerator enumerator = lbLibraryItems.SelectedItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ObjectLibrarySelection.c35f4c9b1f3471abe26d64adf521815be(object, EventArgs));
				RoomComboItem roomComboItem = (RoomComboItem)enumerator.Current;
				Guid uniqueID = roomComboItem.UniqueID;
				IEnumerator enumerator2 = Form1.ObjectLibrary.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						GameObject gameObject = (GameObject)enumerator2.Current;
						if (!(gameObject.UniqueIdentifier == uniqueID))
						{
							__ldtoken(ObjectLibrarySelection.c35f4c9b1f3471abe26d64adf521815be(object, EventArgs));
							continue;
						}
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, gameObject);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						GameObject gameObject2 = (GameObject)binaryFormatter.Deserialize(memoryStream);
						gameObject2.UniqueIdentifier = Guid.NewGuid();
						binaryFormatter.Serialize(memoryStream, gameObject2);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						GameObject gameObject3 = (GameObject)binaryFormatter.Deserialize(memoryStream);
						gameObject3.UniqueIdentifier = Guid.NewGuid();
						for (int i = 0; i < gameObject3.Actions.Count; i++)
						{
							__ldtoken(ObjectLibrarySelection.c35f4c9b1f3471abe26d64adf521815be(object, EventArgs));
							Rags.Action tempact = (Rags.Action)gameObject3.Actions[i];
							Form1.TheGame.RefactorAction(ref tempact, gameObject.UniqueIdentifier.ToString(), gameObject3.UniqueIdentifier.ToString());
						}
						Form1.TheGame.ObjectList.Add(gameObject3);
						break;
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(ObjectLibrarySelection.c35f4c9b1f3471abe26d64adf521815be(object, EventArgs));
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
				__ldtoken(ObjectLibrarySelection.c35f4c9b1f3471abe26d64adf521815be(object, EventArgs));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void c914b66ccd6698aa476f46de7f74982f0(object P_0, EventArgs P_1)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		IEnumerator enumerator = lbLibraryItems.SelectedItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(ObjectLibrarySelection.c914b66ccd6698aa476f46de7f74982f0(object, EventArgs));
				RoomComboItem roomComboItem = (RoomComboItem)enumerator.Current;
				_ = roomComboItem.UniqueID;
				for (int i = 0; i < Form1.ObjectLibrary.Count; i++)
				{
					GameObject obj = (GameObject)Form1.ObjectLibrary[i];
					Form1.ObjectLibrary.Remove(obj);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(ObjectLibrarySelection.c914b66ccd6698aa476f46de7f74982f0(object, EventArgs));
			}
			else
			{
				disposable.Dispose();
			}
		}
		MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72315));
		((Form)this).DialogResult = (DialogResult)1;
	}
}
