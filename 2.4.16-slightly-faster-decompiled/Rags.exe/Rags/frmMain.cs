using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using A;
using AxWMPLib;
using Microsoft.JScript;
using Microsoft.Win32;
using Rags.ragsgame.com;

namespace Rags;

public sealed class frmMain : Form
{
	public sealed class myObjectSortClass : IComparer
	{
		private int c8de5e7a92d633cbbbe2938be203e1642(object P_0, object P_1)
		{
			GameObject gameObject = P_0 as GameObject;
			GameObject gameObject2 = P_1 as GameObject;
			if (gameObject != null)
			{
				if (gameObject2 != null)
				{
					return gameObject.ToString().CompareTo(gameObject2.ToString());
				}
				__ldtoken(myObjectSortClass.c8de5e7a92d633cbbbe2938be203e1642(object, object));
			}
			return 0;
		}

		int IComparer.Compare(object P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in c8de5e7a92d633cbbbe2938be203e1642
			return this.c8de5e7a92d633cbbbe2938be203e1642(P_0, P_1);
		}
	}

	public sealed class myCharacterSortClass : IComparer
	{
		private int c8de5e7a92d633cbbbe2938be203e1642(object P_0, object P_1)
		{
			Character character = P_0 as Character;
			Character character2 = P_1 as Character;
			if (character == null)
			{
				__ldtoken(myCharacterSortClass.c8de5e7a92d633cbbbe2938be203e1642(object, object));
			}
			else if (character2 != null)
			{
				try
				{
					return character.ToString().CompareTo(character2.ToString());
				}
				catch (Exception)
				{
					return 0;
				}
			}
			return 0;
		}

		int IComparer.Compare(object P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in c8de5e7a92d633cbbbe2938be203e1642
			return this.c8de5e7a92d633cbbbe2938be203e1642(P_0, P_1);
		}
	}

	private enum c5a1a94792ee68c127ca4e23531c9b032
	{
		c8c36b4ca0ce920efe7de82dba8b447cc,
		c157e191adcae76c450a8c82842c9666d
	}

	public delegate void LiveTimer(object sender);

	private enum c10b414d2e012eeb2ef0cc25b561b1549
	{
		c7d09946dbb22579280d3e849becda121,
		c4c08a3f00c9c0c5e2811fbf9e3f4dc18,
		cfbba04fc2eff86441089b369b8432706,
		cde26345c3892d2dd4757283560083496,
		c8bce6377505aef2547787d71a915b3b8
	}

	private static bool c1aed702d520ff4bdb6f08d5bfec063b0;

	private string c378defb8a060f85c4faae8445271e30a = string.Empty;

	private bool cdec29256e27e81fd403d83624067c843;

	private static bool c0de09ca3f6d361fe93749ff7d9785d96;

	private static string c42664cfaca433d70304c4fb46fa7cceb;

	private static bool c17c0ba435cecdc830fb1ba4c889283be;

	private static bool c58eb8f529a8b8e52b34a6d519eb0e31b;

	private bool c6896c15b2653af6fffd4ff8146d89e43;

	private DebugDataFrm c45335acf471afc831c5b4bad4cbe5394;

	private MainMenu cccafeee39ed6b951b8816bc368fae7fc;

	private MenuItem c903ab96a2f38fd76d56e2d0b895e82da;

	private MenuItem c966d3810fb167b50257139529f7b6f68;

	private MenuItem c78c1cfe92cb54383b2b6f58d027d3b8d;

	private MenuItem ce6360c84ba3e74eaea3de5533fd06d81;

	private IContainer c501c89bc63d55bb522eac228aeeebb18;

	private OpenFileDialog c65a80a92021b1ba189aaec42668c1427;

	private ContextMenuStrip c1e8a97c8afdf40dab745e3180f49333e;

	private SplitContainer cfdd28b747afbe52686772d0eed813027;

	private SplitContainer c98dd8245994cd868d7cdfd180f7f9422;

	private PictureBox cd431de8c0add2abbb6ebb8d63e4db3c0;

	private RichTextBox c00ef783f3ec99f0de8db7e2bfe179e24;

	private Label c2f58809c7a537a8db5556fb00eb4f8ae;

	public ListBox lbCharacters;

	private Label c4d1b70daaed2c3c985a3d99decf25e14;

	private Label c300c24b05030c9258d5792c1ed7c590d;

	public ListBox lbRoomObjects;

	public ListBox lbInventory;

	private PictureBox cb132670a816ec2a8a287804bae7180f0;

	private Panel cfd270873d0825c1e058bf1297e4314cf;

	private Panel c2fc43f4c034d52cfddc61854f46edf94;

	private SplitContainer ce5ffb7119f6a87128fa80a3d493311b2;

	private SplitContainer c2a161da002bb8cdd90af79c65bcd8c5f;

	private SplitContainer ce61fe8d9cdcafc2156cfec2a32c534a8;

	private SplitContainer ccce410b3d22b32644c265746b0aef4bc;

	private PictureBox c90c65c890556f98316961b88b452411c;

	private PictureBox cd4c5cd27cd40059e2a3eeabdc85952d6;

	private PictureBox c19001e7fd0fb0231ceafdb91b7fc553c;

	private PictureBox cecc2bca13f554623b27fef0a7612d89a;

	private PictureBox c8458b8759f70d83b69ed336abafed87d;

	private PictureBox cf4a085f96b5e3008906285bfac50d314;

	private PictureBox c40520cf7b831e6aa4bb0ebd41a9bed10;

	private PictureBox c380ea8b92cbdb7629b6ba12210334b71;

	private PictureBox c9e0726c3f64d9712d80f7f792ba03c24;

	private PictureBox cb16a9ba7ac8e9ac3aba347a7de4e234c;

	private string c33da7cbe080e8167115ce842f845e11f = string.Empty;

	private MenuItem c34661ddddc61545c61c89e239acd7746;

	private SaveFileDialog c6c063cbe11b4b6925518729f5693f83b;

	private OpenFileDialog c1b2228b412e398e163667e2f04172de6;

	private Panel c5e74b6ad19335af023c0fb124e8b9948;

	private Color c480af4d9d26cffd3c4b7d5da5b9cb646 = Color.ForestGreen;

	private MenuItem ceabb2e4a93e07159fcb9d404e0216183;

	private MenuItem ce78eed28670bde727b6a8407e890fde2;

	private RichTextBox cd344e2339dd47319fcd529e163903ab5;

	private StatusStrip c4653e9f9b7b30bfce0c551ce3f80d94b;

	private Timer c1a8600c9c68783a7d7d474cdb07a5e3a;

	private MenuItem c5af324321826c60eddbbe24509ba2c48;

	private MenuItem c0bb4beb7ba78f7e6293c3610221e13f1;

	private Label c568e1c3a8d35460b6f9f9e370d7f266a;

	private Button c7e94bd5608b35a111c3be9ab9ba47dea;

	private MenuItem cdd9f27c015ea1f4e819e1e03588247ad;

	private SaveData cb81363ccd4179ac7cc499a7f4777d871;

	private MemoryStream c12e4343a47854ab8ab1b03250f8b0518;

	private MenuItem cbd102ffe4907cabf702c370efba2f3ee;

	private SaveFileDialog c0ac8afaf8508709341f33bd2b7335b6d;

	private PictureBox c0970743bbfbc89b095632fb02680fc3b;

	private MenuItem c19e4c95adea495a2c8993ac23517f022;

	private ToolTip cc2b2196e6c009b5ea6d986a89947275c;

	private object c71f1ffa88f78e31ebea8163f6c76f6a8;

	private Random ce4ff3149cc29e541a54db79e809cbdbf = new Random();

	private bool c51279ee02a1043fe19c2f931ed627109;

	private Exit.Directions c780fb3b6ad9bc450e9847a471ce8438a;

	private PictureBox c550ba434b320f806a8f4645040b88e72;

	private PictureBox ce764cacadcb2bc3fd4bdd3b3355f0610;

	private MenuItem cd79b6ae674eb74b4fc90acf57afd0175;

	private string c6d6b6dce042e1f00ba882a716c6b9ad4 = string.Empty;

	private string ceeb96703a6f8cb4eca673e1d86effeff = string.Empty;

	private string c8f7702f4ce4645c290445315e222631e = string.Empty;

	private string ce1dd62a9561b11a074dea91d93c56cc4 = string.Empty;

	private string ce138afd2515492517555092d48124344 = string.Empty;

	private PictureBox c9c86181d01d6e5321a041362bffece16;

	private PictureBox c1126166f2cf1099faab31822dc11d274;

	private SaveData c8e46d07aa274d2f5d4b9a9d2a2a1dd6d;

	private MemoryStream c45a8f1ad7b2f5a62f3d0bb71126882ca = new MemoryStream();

	private MenuItem cdbd048f35472b8d6573068a21d2fcf17;

	private FontDialog cc8264b1067fe196be453410d7902dac7;

	private MenuItem c7a0eae8ab4f7ef78712f593022ef41d1;

	private MenuItem ca5e1a2dcb9943fdd2abf389556113d31;

	private List<RagsThread> ce87c8fe12e43ac45901f96c0d17b504e = new List<RagsThread>();

	private static Game c54f9a911545745b85ae6f74355697f8b;

	private AxWindowsMediaPlayer c3d3f592020623bcd70bc7878559e94cb;

	private AxWindowsMediaPlayer c4ed91464b45bf1f77c5ea95b0e4422c2;

	private AxWindowsMediaPlayer ce585e6a23b47a28be2fa67d1e95f4dae;

	private AxWindowsMediaPlayer c5722e0b047bf80ee8a41d6d5ca3a5b06;

	private bool c4f6995909cfad72aca98f8f9c47059c5;

	private AxWindowsMediaPlayer c33008150af74fd263d1c473a79b9a051;

	private Panel ca0822348910b5925d64c42ce17838058;

	private static Action c70e3f63edea81b518f72f230e2abb5b3;

	private MenuItem c2a03add0f614ccd21bf0d9caca8033e1;

	private MenuItem c78297ef98c3decc8a78a6d857cf555ac;

	private LiveTimer c5d5e7348cbfa67d0ba7b6eb31cc69199;

	private Thread c6ac5319de134e656a48bc2371c6aee73;

	private c10b414d2e012eeb2ef0cc25b561b1549 c3bf3a953472a12db8827db3f743d5429;

	public event LiveTimer OnLiveTimerEvent
	{
		add
		{
			LiveTimer liveTimer = c5d5e7348cbfa67d0ba7b6eb31cc69199;
			while (true)
			{
				LiveTimer liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Combine(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref c5d5e7348cbfa67d0ba7b6eb31cc69199, value2, liveTimer2);
				if ((object)liveTimer == liveTimer2)
				{
					break;
				}
				__ldtoken(frmMain.add_OnLiveTimerEvent(LiveTimer));
			}
		}
		remove
		{
			LiveTimer liveTimer = c5d5e7348cbfa67d0ba7b6eb31cc69199;
			while (true)
			{
				LiveTimer liveTimer2 = liveTimer;
				LiveTimer value2 = (LiveTimer)Delegate.Remove(liveTimer2, value);
				liveTimer = Interlocked.CompareExchange(ref c5d5e7348cbfa67d0ba7b6eb31cc69199, value2, liveTimer2);
				if ((object)liveTimer == liveTimer2)
				{
					break;
				}
				__ldtoken(frmMain.remove_OnLiveTimerEvent(LiveTimer));
			}
		}
	}

	public frmMain()
	{
		try
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13257));
			Thread.CurrentThread.CurrentCulture = new CultureInfo(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13257));
		}
		catch
		{
		}
		cffa44bb0cb8be4c595ec865afadbafa5();
		OnLiveTimerEvent += c4732d0506b698a1b2c8b4936bdb46b1b;
	}

	static frmMain()
	{
		c1aed702d520ff4bdb6f08d5bfec063b0 = false;
		c0de09ca3f6d361fe93749ff7d9785d96 = false;
		c42664cfaca433d70304c4fb46fa7cceb = string.Empty;
		c17c0ba435cecdc830fb1ba4c889283be = true;
		c58eb8f529a8b8e52b34a6d519eb0e31b = false;
		c54f9a911545745b85ae6f74355697f8b = null;
		c70e3f63edea81b518f72f230e2abb5b3 = null;
	}

	public void RunTestThread(object data)
	{
		RagsThread ragsThread = data as RagsThread;
		int num = 0;
		while (!ragsThread.bTerminate)
		{
			__ldtoken(frmMain.RunTestThread(object));
			Thread.Sleep(500);
			num += 500;
			if (num < ragsThread.CurTimer.TimerSeconds * 1000)
			{
				__ldtoken(frmMain.RunTestThread(object));
				continue;
			}
			num = 0;
			try
			{
				if (ragsThread.CurTimer.Active)
				{
					((Control)this).Invoke((Delegate)c5d5e7348cbfa67d0ba7b6eb31cc69199, new object[1] { ragsThread.CurTimer });
				}
			}
			catch
			{
				break;
			}
		}
	}

	private void c4732d0506b698a1b2c8b4936bdb46b1b(object P_0)
	{
		if (!(P_0 is Timer timer))
		{
			__ldtoken(frmMain.c4732d0506b698a1b2c8b4936bdb46b1b(object));
		}
		else
		{
			c05d5f4b15820ff69bf30a7a94fdd82fa(timer);
		}
		c16f20f19536af362c5e437fe3b72ea8b();
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cdb7eb588a870d047a196c0b2bc01bfdf();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			__ldtoken(frmMain.Dispose(bool));
		}
		else if (c501c89bc63d55bb522eac228aeeebb18 == null)
		{
			__ldtoken(frmMain.Dispose(bool));
		}
		else
		{
			c501c89bc63d55bb522eac228aeeebb18.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void cffa44bb0cb8be4c595ec865afadbafa5()
	{
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected Obj, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected Obj, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected Obj, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected Obj, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected Obj, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected Obj, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected Obj, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected Obj, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected Obj, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected Obj, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Obj, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Obj, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected Obj, but got Unknown
		//IL_0d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d78: Expected Obj, but got Unknown
		//IL_0e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2f: Expected Obj, but got Unknown
		//IL_0e61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6b: Expected Obj, but got Unknown
		//IL_0edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee5: Expected Obj, but got Unknown
		//IL_0fb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbf: Expected Obj, but got Unknown
		//IL_104e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1058: Expected Obj, but got Unknown
		//IL_1154: Unknown result type (might be due to invalid IL or missing references)
		//IL_115e: Expected Obj, but got Unknown
		//IL_116b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Expected Obj, but got Unknown
		//IL_1182: Unknown result type (might be due to invalid IL or missing references)
		//IL_118c: Expected Obj, but got Unknown
		//IL_1276: Unknown result type (might be due to invalid IL or missing references)
		//IL_1280: Expected Obj, but got Unknown
		//IL_12ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b8: Expected Obj, but got Unknown
		//IL_1367: Unknown result type (might be due to invalid IL or missing references)
		//IL_1371: Expected Obj, but got Unknown
		//IL_137e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1388: Expected Obj, but got Unknown
		//IL_13e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ed: Expected Obj, but got Unknown
		//IL_1643: Unknown result type (might be due to invalid IL or missing references)
		//IL_164d: Expected Obj, but got Unknown
		//IL_171b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1725: Expected Obj, but got Unknown
		//IL_1995: Unknown result type (might be due to invalid IL or missing references)
		//IL_199f: Expected Obj, but got Unknown
		//IL_19d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e3: Expected Obj, but got Unknown
		//IL_1a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Expected Obj, but got Unknown
		//IL_1c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c13: Expected Obj, but got Unknown
		//IL_1ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cef: Expected Obj, but got Unknown
		//IL_1dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc6: Expected Obj, but got Unknown
		//IL_1e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9e: Expected Obj, but got Unknown
		//IL_1f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f75: Expected Obj, but got Unknown
		//IL_205b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2065: Expected Obj, but got Unknown
		//IL_2130: Unknown result type (might be due to invalid IL or missing references)
		//IL_213a: Expected Obj, but got Unknown
		//IL_21fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2207: Expected Obj, but got Unknown
		//IL_240c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2416: Expected Obj, but got Unknown
		//IL_2423: Unknown result type (might be due to invalid IL or missing references)
		//IL_242d: Expected Obj, but got Unknown
		//IL_243a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2444: Expected Obj, but got Unknown
		//IL_252f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2539: Expected Obj, but got Unknown
		//IL_2567: Unknown result type (might be due to invalid IL or missing references)
		//IL_2571: Expected Obj, but got Unknown
		//IL_271d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2727: Expected Obj, but got Unknown
		//IL_2734: Unknown result type (might be due to invalid IL or missing references)
		//IL_273e: Expected Obj, but got Unknown
		//IL_274b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2755: Expected Obj, but got Unknown
		//IL_2923: Unknown result type (might be due to invalid IL or missing references)
		//IL_292d: Expected Obj, but got Unknown
		//IL_293a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2944: Expected Obj, but got Unknown
		//IL_2951: Unknown result type (might be due to invalid IL or missing references)
		//IL_295b: Expected Obj, but got Unknown
		//IL_2a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a47: Expected Obj, but got Unknown
		//IL_2a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a5e: Expected Obj, but got Unknown
		//IL_2a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a75: Expected Obj, but got Unknown
		//IL_2c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c65: Expected Obj, but got Unknown
		//IL_2ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cae: Expected Obj, but got Unknown
		//IL_2cec: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf6: Expected Obj, but got Unknown
		c501c89bc63d55bb522eac228aeeebb18 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
		cccafeee39ed6b951b8816bc368fae7fc = new MainMenu(c501c89bc63d55bb522eac228aeeebb18);
		c903ab96a2f38fd76d56e2d0b895e82da = new MenuItem();
		c966d3810fb167b50257139529f7b6f68 = new MenuItem();
		ce6360c84ba3e74eaea3de5533fd06d81 = new MenuItem();
		c34661ddddc61545c61c89e239acd7746 = new MenuItem();
		cbd102ffe4907cabf702c370efba2f3ee = new MenuItem();
		c78c1cfe92cb54383b2b6f58d027d3b8d = new MenuItem();
		cdd9f27c015ea1f4e819e1e03588247ad = new MenuItem();
		cdbd048f35472b8d6573068a21d2fcf17 = new MenuItem();
		c2a03add0f614ccd21bf0d9caca8033e1 = new MenuItem();
		c78297ef98c3decc8a78a6d857cf555ac = new MenuItem();
		c5af324321826c60eddbbe24509ba2c48 = new MenuItem();
		c0bb4beb7ba78f7e6293c3610221e13f1 = new MenuItem();
		cd79b6ae674eb74b4fc90acf57afd0175 = new MenuItem();
		c7a0eae8ab4f7ef78712f593022ef41d1 = new MenuItem();
		ceabb2e4a93e07159fcb9d404e0216183 = new MenuItem();
		ce78eed28670bde727b6a8407e890fde2 = new MenuItem();
		c19e4c95adea495a2c8993ac23517f022 = new MenuItem();
		ca5e1a2dcb9943fdd2abf389556113d31 = new MenuItem();
		c65a80a92021b1ba189aaec42668c1427 = new OpenFileDialog();
		c1e8a97c8afdf40dab745e3180f49333e = new ContextMenuStrip(c501c89bc63d55bb522eac228aeeebb18);
		cfdd28b747afbe52686772d0eed813027 = new SplitContainer();
		c98dd8245994cd868d7cdfd180f7f9422 = new SplitContainer();
		c7e94bd5608b35a111c3be9ab9ba47dea = new Button();
		c568e1c3a8d35460b6f9f9e370d7f266a = new Label();
		c2fc43f4c034d52cfddc61854f46edf94 = new Panel();
		c00ef783f3ec99f0de8db7e2bfe179e24 = new RichTextBox();
		cd344e2339dd47319fcd529e163903ab5 = new RichTextBox();
		c0970743bbfbc89b095632fb02680fc3b = new PictureBox();
		c9c86181d01d6e5321a041362bffece16 = new PictureBox();
		ce585e6a23b47a28be2fa67d1e95f4dae = new AxWindowsMediaPlayer();
		cd431de8c0add2abbb6ebb8d63e4db3c0 = new PictureBox();
		c3d3f592020623bcd70bc7878559e94cb = new AxWindowsMediaPlayer();
		ce5ffb7119f6a87128fa80a3d493311b2 = new SplitContainer();
		cfd270873d0825c1e058bf1297e4314cf = new Panel();
		ca0822348910b5925d64c42ce17838058 = new Panel();
		cb16a9ba7ac8e9ac3aba347a7de4e234c = new PictureBox();
		c9e0726c3f64d9712d80f7f792ba03c24 = new PictureBox();
		c5e74b6ad19335af023c0fb124e8b9948 = new Panel();
		c5722e0b047bf80ee8a41d6d5ca3a5b06 = new AxWindowsMediaPlayer();
		c4ed91464b45bf1f77c5ea95b0e4422c2 = new AxWindowsMediaPlayer();
		c550ba434b320f806a8f4645040b88e72 = new PictureBox();
		ce764cacadcb2bc3fd4bdd3b3355f0610 = new PictureBox();
		cecc2bca13f554623b27fef0a7612d89a = new PictureBox();
		cf4a085f96b5e3008906285bfac50d314 = new PictureBox();
		c19001e7fd0fb0231ceafdb91b7fc553c = new PictureBox();
		c40520cf7b831e6aa4bb0ebd41a9bed10 = new PictureBox();
		cd4c5cd27cd40059e2a3eeabdc85952d6 = new PictureBox();
		c380ea8b92cbdb7629b6ba12210334b71 = new PictureBox();
		c90c65c890556f98316961b88b452411c = new PictureBox();
		c8458b8759f70d83b69ed336abafed87d = new PictureBox();
		c2a161da002bb8cdd90af79c65bcd8c5f = new SplitContainer();
		cb132670a816ec2a8a287804bae7180f0 = new PictureBox();
		c1126166f2cf1099faab31822dc11d274 = new PictureBox();
		c33008150af74fd263d1c473a79b9a051 = new AxWindowsMediaPlayer();
		ce61fe8d9cdcafc2156cfec2a32c534a8 = new SplitContainer();
		c4d1b70daaed2c3c985a3d99decf25e14 = new Label();
		lbRoomObjects = new ListBox();
		ccce410b3d22b32644c265746b0aef4bc = new SplitContainer();
		c2f58809c7a537a8db5556fb00eb4f8ae = new Label();
		lbCharacters = new ListBox();
		c300c24b05030c9258d5792c1ed7c590d = new Label();
		lbInventory = new ListBox();
		c6c063cbe11b4b6925518729f5693f83b = new SaveFileDialog();
		c1b2228b412e398e163667e2f04172de6 = new OpenFileDialog();
		c4653e9f9b7b30bfce0c551ce3f80d94b = new StatusStrip();
		c1a8600c9c68783a7d7d474cdb07a5e3a = new Timer(c501c89bc63d55bb522eac228aeeebb18);
		c0ac8afaf8508709341f33bd2b7335b6d = new SaveFileDialog();
		cc2b2196e6c009b5ea6d986a89947275c = new ToolTip(c501c89bc63d55bb522eac228aeeebb18);
		cc8264b1067fe196be453410d7902dac7 = new FontDialog();
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).BeginInit();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).SuspendLayout();
		((Control)cfdd28b747afbe52686772d0eed813027).SuspendLayout();
		((ISupportInitialize)c98dd8245994cd868d7cdfd180f7f9422).BeginInit();
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).SuspendLayout();
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).SuspendLayout();
		((Control)c98dd8245994cd868d7cdfd180f7f9422).SuspendLayout();
		((Control)c2fc43f4c034d52cfddc61854f46edf94).SuspendLayout();
		((ISupportInitialize)c0970743bbfbc89b095632fb02680fc3b).BeginInit();
		((ISupportInitialize)c9c86181d01d6e5321a041362bffece16).BeginInit();
		((ISupportInitialize)ce585e6a23b47a28be2fa67d1e95f4dae).BeginInit();
		((ISupportInitialize)cd431de8c0add2abbb6ebb8d63e4db3c0).BeginInit();
		((ISupportInitialize)c3d3f592020623bcd70bc7878559e94cb).BeginInit();
		((ISupportInitialize)ce5ffb7119f6a87128fa80a3d493311b2).BeginInit();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel1).SuspendLayout();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel2).SuspendLayout();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).SuspendLayout();
		((Control)cfd270873d0825c1e058bf1297e4314cf).SuspendLayout();
		((Control)ca0822348910b5925d64c42ce17838058).SuspendLayout();
		((ISupportInitialize)cb16a9ba7ac8e9ac3aba347a7de4e234c).BeginInit();
		((ISupportInitialize)c9e0726c3f64d9712d80f7f792ba03c24).BeginInit();
		((Control)c5e74b6ad19335af023c0fb124e8b9948).SuspendLayout();
		((ISupportInitialize)c5722e0b047bf80ee8a41d6d5ca3a5b06).BeginInit();
		((ISupportInitialize)c4ed91464b45bf1f77c5ea95b0e4422c2).BeginInit();
		((ISupportInitialize)c550ba434b320f806a8f4645040b88e72).BeginInit();
		((ISupportInitialize)ce764cacadcb2bc3fd4bdd3b3355f0610).BeginInit();
		((ISupportInitialize)cecc2bca13f554623b27fef0a7612d89a).BeginInit();
		((ISupportInitialize)cf4a085f96b5e3008906285bfac50d314).BeginInit();
		((ISupportInitialize)c19001e7fd0fb0231ceafdb91b7fc553c).BeginInit();
		((ISupportInitialize)c40520cf7b831e6aa4bb0ebd41a9bed10).BeginInit();
		((ISupportInitialize)cd4c5cd27cd40059e2a3eeabdc85952d6).BeginInit();
		((ISupportInitialize)c380ea8b92cbdb7629b6ba12210334b71).BeginInit();
		((ISupportInitialize)c90c65c890556f98316961b88b452411c).BeginInit();
		((ISupportInitialize)c8458b8759f70d83b69ed336abafed87d).BeginInit();
		((ISupportInitialize)c2a161da002bb8cdd90af79c65bcd8c5f).BeginInit();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).SuspendLayout();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).SuspendLayout();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).SuspendLayout();
		((ISupportInitialize)cb132670a816ec2a8a287804bae7180f0).BeginInit();
		((ISupportInitialize)c1126166f2cf1099faab31822dc11d274).BeginInit();
		((ISupportInitialize)c33008150af74fd263d1c473a79b9a051).BeginInit();
		((ISupportInitialize)ce61fe8d9cdcafc2156cfec2a32c534a8).BeginInit();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel1).SuspendLayout();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel2).SuspendLayout();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).SuspendLayout();
		((ISupportInitialize)ccce410b3d22b32644c265746b0aef4bc).BeginInit();
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel1).SuspendLayout();
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel2).SuspendLayout();
		((Control)ccce410b3d22b32644c265746b0aef4bc).SuspendLayout();
		((Control)this).SuspendLayout();
		((Menu)cccafeee39ed6b951b8816bc368fae7fc).MenuItems.AddRange(new MenuItem[4] { c903ab96a2f38fd76d56e2d0b895e82da, cdd9f27c015ea1f4e819e1e03588247ad, c5af324321826c60eddbbe24509ba2c48, ceabb2e4a93e07159fcb9d404e0216183 });
		c903ab96a2f38fd76d56e2d0b895e82da.Index = 0;
		((Menu)c903ab96a2f38fd76d56e2d0b895e82da).MenuItems.AddRange(new MenuItem[5] { c966d3810fb167b50257139529f7b6f68, ce6360c84ba3e74eaea3de5533fd06d81, c34661ddddc61545c61c89e239acd7746, cbd102ffe4907cabf702c370efba2f3ee, c78c1cfe92cb54383b2b6f58d027d3b8d });
		c903ab96a2f38fd76d56e2d0b895e82da.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2393);
		c966d3810fb167b50257139529f7b6f68.Index = 0;
		c966d3810fb167b50257139529f7b6f68.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2404);
		c966d3810fb167b50257139529f7b6f68.Click += cc7d53f578f40839d8312e39c52dfe1e9;
		ce6360c84ba3e74eaea3de5533fd06d81.Index = 1;
		ce6360c84ba3e74eaea3de5533fd06d81.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2437);
		ce6360c84ba3e74eaea3de5533fd06d81.Click += c0ed19d03d655b038538119e8b019a50f;
		c34661ddddc61545c61c89e239acd7746.Index = 2;
		c34661ddddc61545c61c89e239acd7746.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2474);
		c34661ddddc61545c61c89e239acd7746.Click += c9cdd06ef68ce1d568947f5942b3eeb81;
		cbd102ffe4907cabf702c370efba2f3ee.Index = 3;
		cbd102ffe4907cabf702c370efba2f3ee.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2511);
		cbd102ffe4907cabf702c370efba2f3ee.Click += cc72ed556db2ad67868ce8d5c2e3a6c23;
		c78c1cfe92cb54383b2b6f58d027d3b8d.Index = 4;
		c78c1cfe92cb54383b2b6f58d027d3b8d.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2546);
		c78c1cfe92cb54383b2b6f58d027d3b8d.Click += c102b48b73d466a5baf7ab446bdde2988;
		cdd9f27c015ea1f4e819e1e03588247ad.Index = 1;
		((Menu)cdd9f27c015ea1f4e819e1e03588247ad).MenuItems.AddRange(new MenuItem[3] { cdbd048f35472b8d6573068a21d2fcf17, c2a03add0f614ccd21bf0d9caca8033e1, c78297ef98c3decc8a78a6d857cf555ac });
		cdd9f27c015ea1f4e819e1e03588247ad.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2557);
		cdbd048f35472b8d6573068a21d2fcf17.Index = 0;
		cdbd048f35472b8d6573068a21d2fcf17.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2568);
		cdbd048f35472b8d6573068a21d2fcf17.Click += ca12fb0d6a51a36ae97f9f54fc384e193;
		c2a03add0f614ccd21bf0d9caca8033e1.Index = 1;
		c2a03add0f614ccd21bf0d9caca8033e1.Shortcut = (Shortcut)119;
		c2a03add0f614ccd21bf0d9caca8033e1.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2591);
		c2a03add0f614ccd21bf0d9caca8033e1.Click += cdb3bb1abdb02abf0044da50b1a2f97b3;
		c78297ef98c3decc8a78a6d857cf555ac.Index = 2;
		c78297ef98c3decc8a78a6d857cf555ac.Shortcut = (Shortcut)120;
		c78297ef98c3decc8a78a6d857cf555ac.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2620);
		c78297ef98c3decc8a78a6d857cf555ac.Click += c697e2c5b66a8be8c144f57dd8dbcdda2;
		c5af324321826c60eddbbe24509ba2c48.Index = 2;
		((Menu)c5af324321826c60eddbbe24509ba2c48).MenuItems.AddRange(new MenuItem[3] { c0bb4beb7ba78f7e6293c3610221e13f1, cd79b6ae674eb74b4fc90acf57afd0175, c7a0eae8ab4f7ef78712f593022ef41d1 });
		c5af324321826c60eddbbe24509ba2c48.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2649);
		c0bb4beb7ba78f7e6293c3610221e13f1.Checked = true;
		c0bb4beb7ba78f7e6293c3610221e13f1.Index = 0;
		c0bb4beb7ba78f7e6293c3610221e13f1.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2662);
		c0bb4beb7ba78f7e6293c3610221e13f1.Click += c1b72005134c4f14e574c7d432793b95f;
		cd79b6ae674eb74b4fc90acf57afd0175.Index = 1;
		cd79b6ae674eb74b4fc90acf57afd0175.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2719);
		cd79b6ae674eb74b4fc90acf57afd0175.Click += ccfb1a20dd02bc858d11708b4c20ce125;
		c7a0eae8ab4f7ef78712f593022ef41d1.Index = 2;
		c7a0eae8ab4f7ef78712f593022ef41d1.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2764);
		c7a0eae8ab4f7ef78712f593022ef41d1.Click += c321c719912aa828d82aad7b6d9560568;
		ceabb2e4a93e07159fcb9d404e0216183.Index = 3;
		((Menu)ceabb2e4a93e07159fcb9d404e0216183).MenuItems.AddRange(new MenuItem[3] { ce78eed28670bde727b6a8407e890fde2, c19e4c95adea495a2c8993ac23517f022, ca5e1a2dcb9943fdd2abf389556113d31 });
		ceabb2e4a93e07159fcb9d404e0216183.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2815);
		ce78eed28670bde727b6a8407e890fde2.Index = 0;
		ce78eed28670bde727b6a8407e890fde2.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2826);
		ce78eed28670bde727b6a8407e890fde2.Click += c50437275bb962f79ed86c48b48ee00b7;
		c19e4c95adea495a2c8993ac23517f022.Index = 1;
		c19e4c95adea495a2c8993ac23517f022.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2839);
		c19e4c95adea495a2c8993ac23517f022.Click += c7dea9ee981604c89a531f27c4321ce22;
		ca5e1a2dcb9943fdd2abf389556113d31.Index = 2;
		ca5e1a2dcb9943fdd2abf389556113d31.Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2862);
		ca5e1a2dcb9943fdd2abf389556113d31.Click += c5f05f948b6dd5d73987a126226860558;
		((FileDialog)c65a80a92021b1ba189aaec42668c1427).DefaultExt = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2883);
		((FileDialog)c65a80a92021b1ba189aaec42668c1427).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2894);
		((FileDialog)c65a80a92021b1ba189aaec42668c1427).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2961);
		((Control)c1e8a97c8afdf40dab745e3180f49333e).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3002);
		((Control)c1e8a97c8afdf40dab745e3180f49333e).Size = new Size(61, 4);
		((Control)cfdd28b747afbe52686772d0eed813027).Anchor = (AnchorStyles)15;
		cfdd28b747afbe52686772d0eed813027.BorderStyle = (BorderStyle)1;
		((Control)cfdd28b747afbe52686772d0eed813027).Location = new Point(0, 0);
		((Control)cfdd28b747afbe52686772d0eed813027).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3021);
		cfdd28b747afbe52686772d0eed813027.Orientation = (Orientation)0;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).Controls.Add((Control)(object)c98dd8245994cd868d7cdfd180f7f9422);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).Controls.Add((Control)(object)ce5ffb7119f6a87128fa80a3d493311b2);
		((Control)cfdd28b747afbe52686772d0eed813027).Size = new Size(684, 400);
		cfdd28b747afbe52686772d0eed813027.SplitterDistance = 275;
		((Control)cfdd28b747afbe52686772d0eed813027).TabIndex = 7;
		c98dd8245994cd868d7cdfd180f7f9422.BorderStyle = (BorderStyle)1;
		c98dd8245994cd868d7cdfd180f7f9422.Dock = (DockStyle)5;
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Location = new Point(0, 0);
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3052);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c7e94bd5608b35a111c3be9ab9ba47dea);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c568e1c3a8d35460b6f9f9e370d7f266a);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c2fc43f4c034d52cfddc61854f46edf94);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c0970743bbfbc89b095632fb02680fc3b);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)c9c86181d01d6e5321a041362bffece16);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).Controls.Add((Control)(object)ce585e6a23b47a28be2fa67d1e95f4dae);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)cd431de8c0add2abbb6ebb8d63e4db3c0);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Controls.Add((Control)(object)c3d3f592020623bcd70bc7878559e94cb);
		((Control)c98dd8245994cd868d7cdfd180f7f9422).Size = new Size(684, 275);
		c98dd8245994cd868d7cdfd180f7f9422.SplitterDistance = 350;
		((Control)c98dd8245994cd868d7cdfd180f7f9422).TabIndex = 0;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Anchor = (AnchorStyles)10;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Enabled = false;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3083), 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).ForeColor = Color.Red;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Location = new Point(210, 241);
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3124);
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Size = new Size(129, 23);
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).TabIndex = 1;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3141);
		((ButtonBase)c7e94bd5608b35a111c3be9ab9ba47dea).UseVisualStyleBackColor = true;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Click += c6b3a3de4d57a8165b8fdcc3d9f422445;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Anchor = (AnchorStyles)6;
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).AutoSize = true;
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3083), 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Location = new Point(65, 242);
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3182);
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Size = new Size(121, 20);
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).TabIndex = 8;
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3211);
		((Control)c568e1c3a8d35460b6f9f9e370d7f266a).MouseDown += c2d4da1c23deb5fce0b180fa7696a90e4;
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Anchor = (AnchorStyles)15;
		c2fc43f4c034d52cfddc61854f46edf94.BorderStyle = (BorderStyle)1;
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Controls.Add((Control)(object)c00ef783f3ec99f0de8db7e2bfe179e24);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Controls.Add((Control)(object)cd344e2339dd47319fcd529e163903ab5);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Location = new Point(0, 0);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3236);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).Size = new Size(339, 224);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).TabIndex = 7;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).BackColor = SystemColors.Window;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Dock = (DockStyle)5;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3083), 8.5f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Location = new Point(0, 0);
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3255);
		((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Size = new Size(337, 222);
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).TabIndex = 0;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text = "";
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).TextChanged += ca8dff17164e2f3b19676a8a0156325bd;
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)cd344e2339dd47319fcd529e163903ab5).Location = new Point(0, 0);
		((Control)cd344e2339dd47319fcd529e163903ab5).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3268);
		((Control)cd344e2339dd47319fcd529e163903ab5).Size = new Size(10, 10);
		((Control)cd344e2339dd47319fcd529e163903ab5).TabIndex = 3;
		((Control)cd344e2339dd47319fcd529e163903ab5).Text = "";
		((Control)cd344e2339dd47319fcd529e163903ab5).Visible = false;
		((Control)c0970743bbfbc89b095632fb02680fc3b).Anchor = (AnchorStyles)6;
		((Control)c0970743bbfbc89b095632fb02680fc3b).BackgroundImageLayout = (ImageLayout)4;
		c0970743bbfbc89b095632fb02680fc3b.BorderStyle = (BorderStyle)1;
		((Control)c0970743bbfbc89b095632fb02680fc3b).Location = new Point(5, 231);
		((Control)c0970743bbfbc89b095632fb02680fc3b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3281);
		((Control)c0970743bbfbc89b095632fb02680fc3b).Size = new Size(56, 40);
		c0970743bbfbc89b095632fb02680fc3b.SizeMode = (PictureBoxSizeMode)4;
		c0970743bbfbc89b095632fb02680fc3b.TabIndex = 10;
		c0970743bbfbc89b095632fb02680fc3b.TabStop = false;
		((Control)c0970743bbfbc89b095632fb02680fc3b).Paint += c7a8f840b70167091e379aa0a104482ed;
		((Control)c0970743bbfbc89b095632fb02680fc3b).MouseDoubleClick += ce0b3045140769e1209118dd918a520fd;
		((Control)c0970743bbfbc89b095632fb02680fc3b).MouseDown += c355d591fa02d1e3066e11daae0af90a3;
		((Control)c9c86181d01d6e5321a041362bffece16).Anchor = (AnchorStyles)6;
		((Control)c9c86181d01d6e5321a041362bffece16).BackColor = Color.Green;
		c9c86181d01d6e5321a041362bffece16.BorderStyle = (BorderStyle)1;
		((Control)c9c86181d01d6e5321a041362bffece16).Location = new Point(1, 228);
		((Control)c9c86181d01d6e5321a041362bffece16).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(36);
		((Control)c9c86181d01d6e5321a041362bffece16).Size = new Size(64, 48);
		c9c86181d01d6e5321a041362bffece16.SizeMode = (PictureBoxSizeMode)4;
		c9c86181d01d6e5321a041362bffece16.TabIndex = 11;
		c9c86181d01d6e5321a041362bffece16.TabStop = false;
		((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Anchor = (AnchorStyles)6;
		((AxHost)ce585e6a23b47a28be2fa67d1e95f4dae).Enabled = true;
		((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Location = new Point(3, 231);
		((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3304);
		((AxHost)ce585e6a23b47a28be2fa67d1e95f4dae).OcxState = (State)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3327));
		((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Size = new Size(58, 40);
		((Control)ce585e6a23b47a28be2fa67d1e95f4dae).TabIndex = 12;
		ce585e6a23b47a28be2fa67d1e95f4dae.MouseDownEvent += c6b3e10c5156a41d98e598986f7829655;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImageLayout = (ImageLayout)4;
		cd431de8c0add2abbb6ebb8d63e4db3c0.BorderStyle = (BorderStyle)1;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Dock = (DockStyle)5;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Location = new Point(0, 0);
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3368);
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Size = new Size(328, 273);
		cd431de8c0add2abbb6ebb8d63e4db3c0.SizeMode = (PictureBoxSizeMode)4;
		cd431de8c0add2abbb6ebb8d63e4db3c0.TabIndex = 3;
		cd431de8c0add2abbb6ebb8d63e4db3c0.TabStop = false;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Click += c78be9cb96ee0d5dd29dd58aef0b08775;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Paint += c0e205563fe2e86b66afa10ecfd52e392;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).MouseMove += c1cefca45341657b47c05a74c9f5d1c53;
		((Control)c3d3f592020623bcd70bc7878559e94cb).Dock = (DockStyle)5;
		((AxHost)c3d3f592020623bcd70bc7878559e94cb).Enabled = true;
		((Control)c3d3f592020623bcd70bc7878559e94cb).Location = new Point(0, 0);
		((Control)c3d3f592020623bcd70bc7878559e94cb).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3387);
		((AxHost)c3d3f592020623bcd70bc7878559e94cb).OcxState = (State)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3430));
		((Control)c3d3f592020623bcd70bc7878559e94cb).Size = new Size(328, 273);
		((Control)c3d3f592020623bcd70bc7878559e94cb).TabIndex = 5;
		ce5ffb7119f6a87128fa80a3d493311b2.Dock = (DockStyle)5;
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).Location = new Point(0, 0);
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3491);
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel1).Controls.Add((Control)(object)cfd270873d0825c1e058bf1297e4314cf);
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel2).Controls.Add((Control)(object)c2a161da002bb8cdd90af79c65bcd8c5f);
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).Size = new Size(682, 119);
		ce5ffb7119f6a87128fa80a3d493311b2.SplitterDistance = 212;
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).TabIndex = 18;
		cfd270873d0825c1e058bf1297e4314cf.BorderStyle = (BorderStyle)1;
		((Control)cfd270873d0825c1e058bf1297e4314cf).Controls.Add((Control)(object)ca0822348910b5925d64c42ce17838058);
		((Control)cfd270873d0825c1e058bf1297e4314cf).Controls.Add((Control)(object)c5e74b6ad19335af023c0fb124e8b9948);
		((Control)cfd270873d0825c1e058bf1297e4314cf).Dock = (DockStyle)5;
		((Control)cfd270873d0825c1e058bf1297e4314cf).Location = new Point(0, 0);
		((Control)cfd270873d0825c1e058bf1297e4314cf).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3514);
		((Control)cfd270873d0825c1e058bf1297e4314cf).Size = new Size(212, 119);
		((Control)cfd270873d0825c1e058bf1297e4314cf).TabIndex = 10;
		((Control)ca0822348910b5925d64c42ce17838058).Anchor = (AnchorStyles)7;
		((Control)ca0822348910b5925d64c42ce17838058).BackgroundImage = (Image)(object)ce962106111336ae1961c57a8c1602a16._300px_Compass_Rose_UD;
		((Control)ca0822348910b5925d64c42ce17838058).BackgroundImageLayout = (ImageLayout)4;
		ca0822348910b5925d64c42ce17838058.BorderStyle = (BorderStyle)1;
		((Control)ca0822348910b5925d64c42ce17838058).Controls.Add((Control)(object)cb16a9ba7ac8e9ac3aba347a7de4e234c);
		((Control)ca0822348910b5925d64c42ce17838058).Controls.Add((Control)(object)c9e0726c3f64d9712d80f7f792ba03c24);
		((Control)ca0822348910b5925d64c42ce17838058).Location = new Point(0, 0);
		((Control)ca0822348910b5925d64c42ce17838058).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3527);
		((Control)ca0822348910b5925d64c42ce17838058).Size = new Size(60, 117);
		((Control)ca0822348910b5925d64c42ce17838058).TabIndex = 23;
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Anchor = (AnchorStyles)1;
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).BackColor = Color.Transparent;
		cb16a9ba7ac8e9ac3aba347a7de4e234c.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		cb16a9ba7ac8e9ac3aba347a7de4e234c.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3540));
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Location = new Point(14, 3);
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3573);
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Size = new Size(30, 30);
		cb16a9ba7ac8e9ac3aba347a7de4e234c.SizeMode = (PictureBoxSizeMode)4;
		cb16a9ba7ac8e9ac3aba347a7de4e234c.TabIndex = 20;
		cb16a9ba7ac8e9ac3aba347a7de4e234c.TabStop = false;
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Visible = false;
		((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Click += c78a0ed8b2d5c43d6cfea40c0e620bea4;
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Anchor = (AnchorStyles)2;
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).BackColor = Color.Transparent;
		c9e0726c3f64d9712d80f7f792ba03c24.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c9e0726c3f64d9712d80f7f792ba03c24.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3580));
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Location = new Point(14, 81);
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3613);
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Size = new Size(30, 30);
		c9e0726c3f64d9712d80f7f792ba03c24.SizeMode = (PictureBoxSizeMode)4;
		c9e0726c3f64d9712d80f7f792ba03c24.TabIndex = 21;
		c9e0726c3f64d9712d80f7f792ba03c24.TabStop = false;
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Visible = false;
		((Control)c9e0726c3f64d9712d80f7f792ba03c24).Click += cd51509c3a929c396af62c1b408d2b330;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Anchor = (AnchorStyles)15;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).BackgroundImage = (Image)(object)ce962106111336ae1961c57a8c1602a16._300px_Compass_Rose_English_North;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).BackgroundImageLayout = (ImageLayout)4;
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c5722e0b047bf80ee8a41d6d5ca3a5b06);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c4ed91464b45bf1f77c5ea95b0e4422c2);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c550ba434b320f806a8f4645040b88e72);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)ce764cacadcb2bc3fd4bdd3b3355f0610);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)cecc2bca13f554623b27fef0a7612d89a);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)cf4a085f96b5e3008906285bfac50d314);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c19001e7fd0fb0231ceafdb91b7fc553c);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c40520cf7b831e6aa4bb0ebd41a9bed10);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)cd4c5cd27cd40059e2a3eeabdc85952d6);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c380ea8b92cbdb7629b6ba12210334b71);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c90c65c890556f98316961b88b452411c);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Controls.Add((Control)(object)c8458b8759f70d83b69ed336abafed87d);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Location = new Point(60, 0);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3620);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).Size = new Size(149, 116);
		((Control)c5e74b6ad19335af023c0fb124e8b9948).TabIndex = 22;
		((AxHost)c5722e0b047bf80ee8a41d6d5ca3a5b06).Enabled = true;
		((Control)c5722e0b047bf80ee8a41d6d5ca3a5b06).Location = new Point(176, 79);
		((Control)c5722e0b047bf80ee8a41d6d5ca3a5b06).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3633);
		((AxHost)c5722e0b047bf80ee8a41d6d5ca3a5b06).OcxState = (State)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3668));
		((Control)c5722e0b047bf80ee8a41d6d5ca3a5b06).Size = new Size(75, 23);
		((Control)c5722e0b047bf80ee8a41d6d5ca3a5b06).TabIndex = 23;
		((Control)c5722e0b047bf80ee8a41d6d5ca3a5b06).Visible = false;
		c5722e0b047bf80ee8a41d6d5ca3a5b06.PlayStateChange += c39b78d2161705a2b7a602f0897aec4fa;
		((AxHost)c4ed91464b45bf1f77c5ea95b0e4422c2).Enabled = true;
		((Control)c4ed91464b45bf1f77c5ea95b0e4422c2).Location = new Point(176, 32);
		((Control)c4ed91464b45bf1f77c5ea95b0e4422c2).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3721);
		((AxHost)c4ed91464b45bf1f77c5ea95b0e4422c2).OcxState = (State)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3748));
		((Control)c4ed91464b45bf1f77c5ea95b0e4422c2).Size = new Size(75, 23);
		((Control)c4ed91464b45bf1f77c5ea95b0e4422c2).TabIndex = 21;
		((Control)c4ed91464b45bf1f77c5ea95b0e4422c2).Visible = false;
		((Control)c550ba434b320f806a8f4645040b88e72).Anchor = (AnchorStyles)10;
		((Control)c550ba434b320f806a8f4645040b88e72).BackColor = Color.Transparent;
		c550ba434b320f806a8f4645040b88e72.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.out_yes;
		((Control)c550ba434b320f806a8f4645040b88e72).Location = new Point(115, 97);
		((Control)c550ba434b320f806a8f4645040b88e72).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3793);
		((Control)c550ba434b320f806a8f4645040b88e72).Size = new Size(33, 18);
		c550ba434b320f806a8f4645040b88e72.SizeMode = (PictureBoxSizeMode)4;
		c550ba434b320f806a8f4645040b88e72.TabIndex = 20;
		c550ba434b320f806a8f4645040b88e72.TabStop = false;
		((Control)c550ba434b320f806a8f4645040b88e72).Click += c1ffb072babd0a99b470b40e0d57c5607;
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Anchor = (AnchorStyles)9;
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).BackColor = Color.Transparent;
		ce764cacadcb2bc3fd4bdd3b3355f0610.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.in_yes;
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Location = new Point(115, 1);
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3804);
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Size = new Size(33, 18);
		ce764cacadcb2bc3fd4bdd3b3355f0610.SizeMode = (PictureBoxSizeMode)4;
		ce764cacadcb2bc3fd4bdd3b3355f0610.TabIndex = 19;
		ce764cacadcb2bc3fd4bdd3b3355f0610.TabStop = false;
		((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Click += c86da970f77bed769ed9498f04d14cca1;
		((Control)cecc2bca13f554623b27fef0a7612d89a).Anchor = (AnchorStyles)8;
		((Control)cecc2bca13f554623b27fef0a7612d89a).BackColor = Color.Transparent;
		cecc2bca13f554623b27fef0a7612d89a.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		cecc2bca13f554623b27fef0a7612d89a.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3813));
		((Control)cecc2bca13f554623b27fef0a7612d89a).Location = new Point(117, 42);
		((Control)cecc2bca13f554623b27fef0a7612d89a).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3846);
		((Control)cecc2bca13f554623b27fef0a7612d89a).Size = new Size(30, 30);
		cecc2bca13f554623b27fef0a7612d89a.SizeMode = (PictureBoxSizeMode)4;
		cecc2bca13f554623b27fef0a7612d89a.TabIndex = 11;
		cecc2bca13f554623b27fef0a7612d89a.TabStop = false;
		((Control)cecc2bca13f554623b27fef0a7612d89a).Visible = false;
		((Control)cecc2bca13f554623b27fef0a7612d89a).Click += ca3371f019d49945be20fb7007425cba1;
		((Control)cf4a085f96b5e3008906285bfac50d314).Anchor = (AnchorStyles)10;
		((Control)cf4a085f96b5e3008906285bfac50d314).BackColor = Color.Transparent;
		cf4a085f96b5e3008906285bfac50d314.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		cf4a085f96b5e3008906285bfac50d314.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3853));
		((Control)cf4a085f96b5e3008906285bfac50d314).Location = new Point(95, 67);
		((Control)cf4a085f96b5e3008906285bfac50d314).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3888);
		((Control)cf4a085f96b5e3008906285bfac50d314).Size = new Size(30, 30);
		cf4a085f96b5e3008906285bfac50d314.SizeMode = (PictureBoxSizeMode)4;
		cf4a085f96b5e3008906285bfac50d314.TabIndex = 18;
		cf4a085f96b5e3008906285bfac50d314.TabStop = false;
		((Control)cf4a085f96b5e3008906285bfac50d314).Visible = false;
		((Control)cf4a085f96b5e3008906285bfac50d314).Click += c5f280b879521f714f8b5aa4febb03da7;
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Anchor = (AnchorStyles)4;
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).BackColor = Color.Transparent;
		c19001e7fd0fb0231ceafdb91b7fc553c.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c19001e7fd0fb0231ceafdb91b7fc553c.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3897));
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Location = new Point(3, 42);
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3930);
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Size = new Size(30, 30);
		c19001e7fd0fb0231ceafdb91b7fc553c.SizeMode = (PictureBoxSizeMode)4;
		c19001e7fd0fb0231ceafdb91b7fc553c.TabIndex = 12;
		c19001e7fd0fb0231ceafdb91b7fc553c.TabStop = false;
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Visible = false;
		((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Click += cb6b0e134e59bef02adee8a8232f5ac4d;
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Anchor = (AnchorStyles)6;
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).BackColor = Color.Transparent;
		c40520cf7b831e6aa4bb0ebd41a9bed10.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c40520cf7b831e6aa4bb0ebd41a9bed10.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3937));
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Location = new Point(21, 67);
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3972);
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Size = new Size(30, 30);
		c40520cf7b831e6aa4bb0ebd41a9bed10.SizeMode = (PictureBoxSizeMode)4;
		c40520cf7b831e6aa4bb0ebd41a9bed10.TabIndex = 17;
		c40520cf7b831e6aa4bb0ebd41a9bed10.TabStop = false;
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Visible = false;
		((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Click += c98b0d6e2d3e2f95dc20b0ef21fade4fc;
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Anchor = (AnchorStyles)1;
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).BackColor = Color.Transparent;
		cd4c5cd27cd40059e2a3eeabdc85952d6.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		cd4c5cd27cd40059e2a3eeabdc85952d6.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3981));
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Location = new Point(58, 3);
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4014);
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Size = new Size(30, 30);
		cd4c5cd27cd40059e2a3eeabdc85952d6.SizeMode = (PictureBoxSizeMode)4;
		cd4c5cd27cd40059e2a3eeabdc85952d6.TabIndex = 13;
		cd4c5cd27cd40059e2a3eeabdc85952d6.TabStop = false;
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Visible = false;
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Click += c1d8e4bd213ff6989c2d4e9f1a3429152;
		((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).MouseHover += c4d3f860e96fe43d6599bdd81b2f608fc;
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Anchor = (AnchorStyles)9;
		((Control)c380ea8b92cbdb7629b6ba12210334b71).BackColor = Color.Transparent;
		c380ea8b92cbdb7629b6ba12210334b71.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c380ea8b92cbdb7629b6ba12210334b71.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4021));
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Location = new Point(95, 19);
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4056);
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Size = new Size(30, 30);
		c380ea8b92cbdb7629b6ba12210334b71.SizeMode = (PictureBoxSizeMode)4;
		c380ea8b92cbdb7629b6ba12210334b71.TabIndex = 16;
		c380ea8b92cbdb7629b6ba12210334b71.TabStop = false;
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Visible = false;
		((Control)c380ea8b92cbdb7629b6ba12210334b71).Click += c3795d553a32d3287242f9de094167d49;
		((Control)c90c65c890556f98316961b88b452411c).Anchor = (AnchorStyles)2;
		((Control)c90c65c890556f98316961b88b452411c).BackColor = Color.Transparent;
		c90c65c890556f98316961b88b452411c.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c90c65c890556f98316961b88b452411c.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4065));
		((Control)c90c65c890556f98316961b88b452411c).Location = new Point(58, 83);
		((Control)c90c65c890556f98316961b88b452411c).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4098);
		((Control)c90c65c890556f98316961b88b452411c).Size = new Size(30, 30);
		c90c65c890556f98316961b88b452411c.SizeMode = (PictureBoxSizeMode)4;
		c90c65c890556f98316961b88b452411c.TabIndex = 14;
		c90c65c890556f98316961b88b452411c.TabStop = false;
		((Control)c90c65c890556f98316961b88b452411c).Visible = false;
		((Control)c90c65c890556f98316961b88b452411c).Click += c9ee62976d23275acb96584ca30167825;
		((Control)c8458b8759f70d83b69ed336abafed87d).BackColor = Color.Transparent;
		c8458b8759f70d83b69ed336abafed87d.Image = (Image)(object)ce962106111336ae1961c57a8c1602a16.transparent_gif_circleex2;
		c8458b8759f70d83b69ed336abafed87d.InitialImage = (Image)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4105));
		((Control)c8458b8759f70d83b69ed336abafed87d).Location = new Point(21, 19);
		((Control)c8458b8759f70d83b69ed336abafed87d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4140);
		((Control)c8458b8759f70d83b69ed336abafed87d).Size = new Size(30, 30);
		c8458b8759f70d83b69ed336abafed87d.SizeMode = (PictureBoxSizeMode)4;
		c8458b8759f70d83b69ed336abafed87d.TabIndex = 15;
		c8458b8759f70d83b69ed336abafed87d.TabStop = false;
		((Control)c8458b8759f70d83b69ed336abafed87d).Visible = false;
		((Control)c8458b8759f70d83b69ed336abafed87d).Click += c4cdd8c69b0fb57b72c6bbbd30ae74794;
		c2a161da002bb8cdd90af79c65bcd8c5f.BorderStyle = (BorderStyle)1;
		c2a161da002bb8cdd90af79c65bcd8c5f.Dock = (DockStyle)5;
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Location = new Point(0, 0);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4149);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)cb132670a816ec2a8a287804bae7180f0);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c1126166f2cf1099faab31822dc11d274);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Controls.Add((Control)(object)c33008150af74fd263d1c473a79b9a051);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).Controls.Add((Control)(object)ce61fe8d9cdcafc2156cfec2a32c534a8);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).Size = new Size(466, 119);
		c2a161da002bb8cdd90af79c65bcd8c5f.SplitterDistance = 135;
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).TabIndex = 0;
		((Control)cb132670a816ec2a8a287804bae7180f0).Anchor = (AnchorStyles)15;
		((Control)cb132670a816ec2a8a287804bae7180f0).BackgroundImageLayout = (ImageLayout)4;
		cb132670a816ec2a8a287804bae7180f0.BorderStyle = (BorderStyle)1;
		((Control)cb132670a816ec2a8a287804bae7180f0).Location = new Point(7, 6);
		((Control)cb132670a816ec2a8a287804bae7180f0).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4180);
		((Control)cb132670a816ec2a8a287804bae7180f0).Size = new Size(119, 106);
		cb132670a816ec2a8a287804bae7180f0.SizeMode = (PictureBoxSizeMode)4;
		cb132670a816ec2a8a287804bae7180f0.TabIndex = 11;
		cb132670a816ec2a8a287804bae7180f0.TabStop = false;
		((Control)cb132670a816ec2a8a287804bae7180f0).Paint += c7a8f840b70167091e379aa0a104482ed;
		((Control)cb132670a816ec2a8a287804bae7180f0).MouseDoubleClick += c213aae3ecccb7e5a64c5c9a34109a34b;
		((Control)cb132670a816ec2a8a287804bae7180f0).MouseDown += c6211da2da5bd7e3ad792ccac21e533f0;
		((Control)c1126166f2cf1099faab31822dc11d274).BackColor = Color.Green;
		c1126166f2cf1099faab31822dc11d274.BorderStyle = (BorderStyle)1;
		((Control)c1126166f2cf1099faab31822dc11d274).Dock = (DockStyle)5;
		((Control)c1126166f2cf1099faab31822dc11d274).Location = new Point(0, 0);
		((Control)c1126166f2cf1099faab31822dc11d274).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4199);
		((Control)c1126166f2cf1099faab31822dc11d274).Size = new Size(133, 117);
		c1126166f2cf1099faab31822dc11d274.SizeMode = (PictureBoxSizeMode)4;
		c1126166f2cf1099faab31822dc11d274.TabIndex = 12;
		c1126166f2cf1099faab31822dc11d274.TabStop = false;
		((Control)c33008150af74fd263d1c473a79b9a051).Anchor = (AnchorStyles)15;
		((AxHost)c33008150af74fd263d1c473a79b9a051).Enabled = true;
		((Control)c33008150af74fd263d1c473a79b9a051).Location = new Point(7, 6);
		((Control)c33008150af74fd263d1c473a79b9a051).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4222);
		((AxHost)c33008150af74fd263d1c473a79b9a051).OcxState = (State)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4255));
		((Control)c33008150af74fd263d1c473a79b9a051).Size = new Size(119, 106);
		((Control)c33008150af74fd263d1c473a79b9a051).TabIndex = 13;
		c33008150af74fd263d1c473a79b9a051.MouseDownEvent += c9ee0469dc7145e6f2a836d7121b068ad;
		ce61fe8d9cdcafc2156cfec2a32c534a8.BorderStyle = (BorderStyle)1;
		ce61fe8d9cdcafc2156cfec2a32c534a8.Dock = (DockStyle)5;
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).Location = new Point(0, 0);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4306);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel1).Controls.Add((Control)(object)c4d1b70daaed2c3c985a3d99decf25e14);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel1).Controls.Add((Control)(object)lbRoomObjects);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel2).Controls.Add((Control)(object)ccce410b3d22b32644c265746b0aef4bc);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).Size = new Size(327, 119);
		ce61fe8d9cdcafc2156cfec2a32c534a8.SplitterDistance = 106;
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).TabIndex = 12;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).AutoSize = true;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Location = new Point(4, -1);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2222);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Size = new Size(77, 13);
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).TabIndex = 15;
		((Control)c4d1b70daaed2c3c985a3d99decf25e14).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4337);
		((Control)lbRoomObjects).Anchor = (AnchorStyles)15;
		lbRoomObjects.HorizontalScrollbar = true;
		((Control)lbRoomObjects).Location = new Point(0, 16);
		((Control)lbRoomObjects).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4364);
		lbRoomObjects.ScrollAlwaysVisible = true;
		((Control)lbRoomObjects).Size = new Size(102, 95);
		((Control)lbRoomObjects).TabIndex = 2;
		((Control)lbRoomObjects).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)lbRoomObjects).MouseDoubleClick += c1fd2530a7bace5c536a8c0c733f33369;
		((Control)lbRoomObjects).MouseDown += c0d2ee82c2bc6a0e93db8e117c8f1d502;
		ccce410b3d22b32644c265746b0aef4bc.BorderStyle = (BorderStyle)1;
		ccce410b3d22b32644c265746b0aef4bc.Dock = (DockStyle)5;
		((Control)ccce410b3d22b32644c265746b0aef4bc).Location = new Point(0, 0);
		((Control)ccce410b3d22b32644c265746b0aef4bc).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4391);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel1).Controls.Add((Control)(object)c2f58809c7a537a8db5556fb00eb4f8ae);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel1).Controls.Add((Control)(object)lbCharacters);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel2).Controls.Add((Control)(object)c300c24b05030c9258d5792c1ed7c590d);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel2).Controls.Add((Control)(object)lbInventory);
		((Control)ccce410b3d22b32644c265746b0aef4bc).Size = new Size(217, 119);
		ccce410b3d22b32644c265746b0aef4bc.SplitterDistance = 108;
		((Control)ccce410b3d22b32644c265746b0aef4bc).TabIndex = 0;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).AutoSize = true;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Location = new Point(-1, -1);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2235);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Size = new Size(94, 13);
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).TabIndex = 17;
		((Control)c2f58809c7a537a8db5556fb00eb4f8ae).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4422);
		((Control)lbCharacters).Anchor = (AnchorStyles)15;
		lbCharacters.HorizontalScrollbar = true;
		((Control)lbCharacters).Location = new Point(0, 16);
		((Control)lbCharacters).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4461);
		lbCharacters.ScrollAlwaysVisible = true;
		((Control)lbCharacters).Size = new Size(103, 95);
		((Control)lbCharacters).TabIndex = 3;
		((Control)lbCharacters).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)lbCharacters).MouseDoubleClick += c957d2e476d59a2ea716b5e87364146f1;
		((Control)lbCharacters).MouseDown += cbfc47bcbda14ef93efc6bed196c42bf0;
		((Control)c300c24b05030c9258d5792c1ed7c590d).AutoSize = true;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Location = new Point(2, -1);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59);
		((Control)c300c24b05030c9258d5792c1ed7c590d).Size = new Size(54, 13);
		((Control)c300c24b05030c9258d5792c1ed7c590d).TabIndex = 14;
		((Control)c300c24b05030c9258d5792c1ed7c590d).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4486);
		((Control)lbInventory).Anchor = (AnchorStyles)15;
		lbInventory.HorizontalScrollbar = true;
		((Control)lbInventory).Location = new Point(3, 16);
		((Control)lbInventory).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4507);
		lbInventory.ScrollAlwaysVisible = true;
		((Control)lbInventory).Size = new Size(101, 95);
		((Control)lbInventory).TabIndex = 4;
		((Control)lbInventory).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)lbInventory).MouseDoubleClick += cc6b029b22b0e86a8b36405bab315d468;
		((Control)lbInventory).MouseDown += c99f21074ced9ed9c2686660d0583eaff;
		((FileDialog)c6c063cbe11b4b6925518729f5693f83b).DefaultExt = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4530);
		((FileDialog)c6c063cbe11b4b6925518729f5693f83b).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4537);
		((FileDialog)c6c063cbe11b4b6925518729f5693f83b).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4608);
		((FileDialog)c1b2228b412e398e163667e2f04172de6).DefaultExt = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4530);
		((FileDialog)c1b2228b412e398e163667e2f04172de6).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4537);
		((FileDialog)c1b2228b412e398e163667e2f04172de6).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4637);
		((FileDialog)c1b2228b412e398e163667e2f04172de6).FileOk += c6f15da1c4c76a69a0fbe9f20fb39fe5f;
		((Control)c4653e9f9b7b30bfce0c551ce3f80d94b).Location = new Point(0, 400);
		((Control)c4653e9f9b7b30bfce0c551ce3f80d94b).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4674);
		((Control)c4653e9f9b7b30bfce0c551ce3f80d94b).Size = new Size(684, 22);
		((Control)c4653e9f9b7b30bfce0c551ce3f80d94b).TabIndex = 24;
		((Control)c4653e9f9b7b30bfce0c551ce3f80d94b).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4674);
		c1a8600c9c68783a7d7d474cdb07a5e3a.Enabled = true;
		c1a8600c9c68783a7d7d474cdb07a5e3a.Interval = 30000;
		c1a8600c9c68783a7d7d474cdb07a5e3a.Tick += c6c81e57d710c9ddb0da56132be15a894;
		((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).DefaultExt = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4699);
		((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4706);
		((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4775);
		((Form)this).AutoScaleBaseSize = new Size(5, 13);
		((Control)this).BackColor = SystemColors.Control;
		((Form)this).ClientSize = new Size(684, 422);
		((Control)this).Controls.Add((Control)(object)c4653e9f9b7b30bfce0c551ce3f80d94b);
		((Control)this).Controls.Add((Control)(object)cfdd28b747afbe52686772d0eed813027);
		((Control)this).DoubleBuffered = true;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(95));
		((Form)this).Menu = cccafeee39ed6b951b8816bc368fae7fc;
		((Control)this).Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4816);
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4831);
		((Form)this).FormClosing += c23e9ff31cfc9f1f1112c8d642cac582e;
		((Form)this).Load += cb992719702982eef1744afbb3520579b;
		((Form)this).Shown += c5c4b79a4344c161f0e92b29e3a6d644e;
		((Control)this).Click += cc7d53f578f40839d8312e39c52dfe1e9;
		((Control)this).KeyDown += cf2814865aea5c42c5877a6fc75214d7f;
		((Control)cfdd28b747afbe52686772d0eed813027.Panel1).ResumeLayout(false);
		((Control)cfdd28b747afbe52686772d0eed813027.Panel2).ResumeLayout(false);
		((ISupportInitialize)cfdd28b747afbe52686772d0eed813027).EndInit();
		((Control)cfdd28b747afbe52686772d0eed813027).ResumeLayout(false);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).ResumeLayout(false);
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel1).PerformLayout();
		((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).ResumeLayout(false);
		((ISupportInitialize)c98dd8245994cd868d7cdfd180f7f9422).EndInit();
		((Control)c98dd8245994cd868d7cdfd180f7f9422).ResumeLayout(false);
		((Control)c2fc43f4c034d52cfddc61854f46edf94).ResumeLayout(false);
		((ISupportInitialize)c0970743bbfbc89b095632fb02680fc3b).EndInit();
		((ISupportInitialize)c9c86181d01d6e5321a041362bffece16).EndInit();
		((ISupportInitialize)ce585e6a23b47a28be2fa67d1e95f4dae).EndInit();
		((ISupportInitialize)cd431de8c0add2abbb6ebb8d63e4db3c0).EndInit();
		((ISupportInitialize)c3d3f592020623bcd70bc7878559e94cb).EndInit();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel1).ResumeLayout(false);
		((Control)ce5ffb7119f6a87128fa80a3d493311b2.Panel2).ResumeLayout(false);
		((ISupportInitialize)ce5ffb7119f6a87128fa80a3d493311b2).EndInit();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).ResumeLayout(false);
		((Control)cfd270873d0825c1e058bf1297e4314cf).ResumeLayout(false);
		((Control)ca0822348910b5925d64c42ce17838058).ResumeLayout(false);
		((ISupportInitialize)cb16a9ba7ac8e9ac3aba347a7de4e234c).EndInit();
		((ISupportInitialize)c9e0726c3f64d9712d80f7f792ba03c24).EndInit();
		((Control)c5e74b6ad19335af023c0fb124e8b9948).ResumeLayout(false);
		((ISupportInitialize)c5722e0b047bf80ee8a41d6d5ca3a5b06).EndInit();
		((ISupportInitialize)c4ed91464b45bf1f77c5ea95b0e4422c2).EndInit();
		((ISupportInitialize)c550ba434b320f806a8f4645040b88e72).EndInit();
		((ISupportInitialize)ce764cacadcb2bc3fd4bdd3b3355f0610).EndInit();
		((ISupportInitialize)cecc2bca13f554623b27fef0a7612d89a).EndInit();
		((ISupportInitialize)cf4a085f96b5e3008906285bfac50d314).EndInit();
		((ISupportInitialize)c19001e7fd0fb0231ceafdb91b7fc553c).EndInit();
		((ISupportInitialize)c40520cf7b831e6aa4bb0ebd41a9bed10).EndInit();
		((ISupportInitialize)cd4c5cd27cd40059e2a3eeabdc85952d6).EndInit();
		((ISupportInitialize)c380ea8b92cbdb7629b6ba12210334b71).EndInit();
		((ISupportInitialize)c90c65c890556f98316961b88b452411c).EndInit();
		((ISupportInitialize)c8458b8759f70d83b69ed336abafed87d).EndInit();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).ResumeLayout(false);
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel2).ResumeLayout(false);
		((ISupportInitialize)c2a161da002bb8cdd90af79c65bcd8c5f).EndInit();
		((Control)c2a161da002bb8cdd90af79c65bcd8c5f).ResumeLayout(false);
		((ISupportInitialize)cb132670a816ec2a8a287804bae7180f0).EndInit();
		((ISupportInitialize)c1126166f2cf1099faab31822dc11d274).EndInit();
		((ISupportInitialize)c33008150af74fd263d1c473a79b9a051).EndInit();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel1).ResumeLayout(false);
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel1).PerformLayout();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8.Panel2).ResumeLayout(false);
		((ISupportInitialize)ce61fe8d9cdcafc2156cfec2a32c534a8).EndInit();
		((Control)ce61fe8d9cdcafc2156cfec2a32c534a8).ResumeLayout(false);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel1).ResumeLayout(false);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel1).PerformLayout();
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel2).ResumeLayout(false);
		((Control)ccce410b3d22b32644c265746b0aef4bc.Panel2).PerformLayout();
		((ISupportInitialize)ccce410b3d22b32644c265746b0aef4bc).EndInit();
		((Control)ccce410b3d22b32644c265746b0aef4bc).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[STAThread]
	private static void cadd579457037731765088f25c6b29b99()
	{
		Application.Run((Form)(object)new frmMain());
	}

	private void cb6bf42077ef94e4a63840b4283588ed0()
	{
		c6896c15b2653af6fffd4ff8146d89e43 = true;
		bool flag = false;
		while (!flag)
		{
			flag = true;
			using (List<RagsThread>.Enumerator enumerator = ce87c8fe12e43ac45901f96c0d17b504e.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(frmMain.cb6bf42077ef94e4a63840b4283588ed0());
					RagsThread current = enumerator.Current;
					current.bTerminate = true;
					if (!current.TheThread.IsAlive)
					{
						__ldtoken(frmMain.cb6bf42077ef94e4a63840b4283588ed0());
						continue;
					}
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				Application.DoEvents();
				Thread.Sleep(50);
			}
		}
		ce87c8fe12e43ac45901f96c0d17b504e.Clear();
	}

	private void cc7d53f578f40839d8312e39c52dfe1e9(object P_0, EventArgs P_1)
	{
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Invalid comparison between Unknown and I4
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Invalid comparison between Unknown and I4
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Invalid comparison between Unknown and I4
		bool flag = true;
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = c33da7cbe080e8167115ce842f845e11f;
			saveData.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
			saveData.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
			saveData.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
			saveData.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
			saveData.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
			saveData.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
			saveData.StatusBarList = c54f9a911545745b85ae6f74355697f8b.StatusBarItems;
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, saveData);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			string strB = streamReader.ReadToEnd();
			if (string.Compare(ce138afd2515492517555092d48124344, strB) != 0)
			{
				__ldtoken(frmMain.cc7d53f578f40839d8312e39c52dfe1e9(object, EventArgs));
			}
			else
			{
				flag = false;
			}
			streamReader.Close();
			streamReader.Dispose();
			memoryStream.Close();
			memoryStream.Dispose();
		}
		else
		{
			flag = false;
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length >= 3 && commandLineArgs[2] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4890))
		{
			flag = false;
		}
		if (!flag)
		{
			__ldtoken(frmMain.cc7d53f578f40839d8312e39c52dfe1e9(object, EventArgs));
		}
		else
		{
			DialogResult val = MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4901), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4984), (MessageBoxButtons)3);
			if ((int)val != 6)
			{
				__ldtoken(frmMain.cc7d53f578f40839d8312e39c52dfe1e9(object, EventArgs));
				if ((int)val == 2)
				{
					return;
				}
				__ldtoken(frmMain.cc7d53f578f40839d8312e39c52dfe1e9(object, EventArgs));
				cdf909c325e9747ba13bd06e252281065();
				c6896c15b2653af6fffd4ff8146d89e43 = true;
				cb6bf42077ef94e4a63840b4283588ed0();
			}
			else
			{
				c0ed19d03d655b038538119e8b019a50f(null, null);
				c6896c15b2653af6fffd4ff8146d89e43 = true;
				cdf909c325e9747ba13bd06e252281065();
				c6896c15b2653af6fffd4ff8146d89e43 = true;
				cb6bf42077ef94e4a63840b4283588ed0();
			}
		}
		if ((int)((CommonDialog)c65a80a92021b1ba189aaec42668c1427).ShowDialog() != 1)
		{
			__ldtoken(frmMain.cc7d53f578f40839d8312e39c52dfe1e9(object, EventArgs));
			return;
		}
		c6896c15b2653af6fffd4ff8146d89e43 = true;
		cb6bf42077ef94e4a63840b4283588ed0();
		c6b3a3de4d57a8165b8fdcc3d9f422445(null, null);
		((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = true;
		c33da7cbe080e8167115ce842f845e11f = ((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName;
		cfd2619d4c79d66471f6028e1a52a2657(((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName);
	}

	private void cfc246fc898e127948f3219ddb6ca1a07()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.cfc246fc898e127948f3219ddb6ca1a07());
		((ToolStrip)c4653e9f9b7b30bfce0c551ce3f80d94b).Items.Clear();
		foreach (StatusBarItem statusBarItem in c54f9a911545745b85ae6f74355697f8b.StatusBarItems)
		{
			ToolStripStatusLabel val = new ToolStripStatusLabel(statusBarItem.Text);
			val.BorderSides = (ToolStripStatusLabelBorderSides)4;
			if (statusBarItem.Width != 0)
			{
				((ToolStripItem)val).AutoSize = false;
				((ToolStripItem)val).Width = statusBarItem.Width;
			}
			((ToolStrip)c4653e9f9b7b30bfce0c551ce3f80d94b).Items.Add((ToolStripItem)(object)val);
		}
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.TimerList.Count; i++)
		{
			__ldtoken(frmMain.cfc246fc898e127948f3219ddb6ca1a07());
			Timer atimer = c54f9a911545745b85ae6f74355697f8b.TimerList[i] as Timer;
			if (!atimer.LiveTimer)
			{
				__ldtoken(frmMain.cfc246fc898e127948f3219ddb6ca1a07());
				continue;
			}
			c6ac5319de134e656a48bc2371c6aee73 = new Thread(RunTestThread);
			bool flag = true;
			foreach (RagsThread item in ce87c8fe12e43ac45901f96c0d17b504e)
			{
				if (item.CurTimer.Name == atimer.Name)
				{
					flag = false;
					item.CurTimer = atimer;
					break;
				}
			}
			if (!flag)
			{
				__ldtoken(frmMain.cfc246fc898e127948f3219ddb6ca1a07());
				continue;
			}
			RagsThread ragsThread = new RagsThread(ref c6ac5319de134e656a48bc2371c6aee73, ref atimer);
			ce87c8fe12e43ac45901f96c0d17b504e.Add(ragsThread);
			c6ac5319de134e656a48bc2371c6aee73.Start(ragsThread);
		}
	}

	private void c7eea724ca39738cd6aab683af7fa33ca()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.c7eea724ca39738cd6aab683af7fa33ca());
		((ToolStrip)c4653e9f9b7b30bfce0c551ce3f80d94b).Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.StatusBarItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.c7eea724ca39738cd6aab683af7fa33ca());
				StatusBarItem statusBarItem = (StatusBarItem)enumerator.Current;
				if (!statusBarItem.bVisisble)
				{
					__ldtoken(frmMain.c7eea724ca39738cd6aab683af7fa33ca());
					continue;
				}
				ToolStripStatusLabel val = new ToolStripStatusLabel(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(statusBarItem.Text, null));
				val.BorderSides = (ToolStripStatusLabelBorderSides)4;
				if (statusBarItem.Width == 0)
				{
					__ldtoken(frmMain.c7eea724ca39738cd6aab683af7fa33ca());
				}
				else
				{
					((ToolStripItem)val).AutoSize = false;
					((ToolStripItem)val).Width = statusBarItem.Width;
				}
				((ToolStrip)c4653e9f9b7b30bfce0c551ce3f80d94b).Items.Add((ToolStripItem)(object)val);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.c7eea724ca39738cd6aab683af7fa33ca());
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c51568856233bbe7fbfdbfcb47e3ae567()
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Invalid comparison between Unknown and I4
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		if (c45a8f1ad7b2f5a62f3d0bb71126882ca != null)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			c45a8f1ad7b2f5a62f3d0bb71126882ca.Seek(0L, SeekOrigin.Begin);
			SaveData saveData = (SaveData)binaryFormatter.Deserialize(c45a8f1ad7b2f5a62f3d0bb71126882ca);
			c33da7cbe080e8167115ce842f845e11f = saveData.originalfilename;
			c54f9a911545745b85ae6f74355697f8b.CharacterList = saveData.CharacterList;
			c54f9a911545745b85ae6f74355697f8b.ObjectList = saveData.ObjectList;
			c54f9a911545745b85ae6f74355697f8b.RoomList = saveData.RoomList;
			c54f9a911545745b85ae6f74355697f8b.ThePlayer = saveData.ThePlayer;
			c54f9a911545745b85ae6f74355697f8b.VariableList = saveData.VariableList;
			c54f9a911545745b85ae6f74355697f8b.TimerList = saveData.TimerList;
		}
		cfc246fc898e127948f3219ddb6ca1a07();
		c7eea724ca39738cd6aab683af7fa33ca();
		if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.bPromptForGender)
		{
			__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
		}
		else
		{
			GetGenderFrm getGenderFrm = new GetGenderFrm();
			getGenderFrm.radioButton1.Checked = true;
			if ((int)((Form)getGenderFrm).ShowDialog() == 1)
			{
				if (getGenderFrm.radioButton1.Checked)
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Male;
				}
				if (!getGenderFrm.radioButton2.Checked)
				{
					__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
				}
				else
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Female;
				}
				if (!getGenderFrm.radioButton3.Checked)
				{
					__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
				}
				else
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Other;
				}
			}
		}
		if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.bPromptForName)
		{
			__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
		}
		else
		{
			AdditionalInputFrm additionalInputFrm = new AdditionalInputFrm(Action.ActionInputType.Text, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
			((Control)additionalInputFrm.lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4993);
			((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
			DialogResult val = ((Form)additionalInputFrm).ShowDialog();
			if ((int)val != 4)
			{
				__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
			}
			else
			{
				((Form)additionalInputFrm).ShowDialog();
			}
			while (((Control)additionalInputFrm.txtInput).Text == string.Empty)
			{
				__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5050));
				((Form)additionalInputFrm).ShowDialog();
			}
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.Name = ((Control)additionalInputFrm.txtInput).Text;
		}
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.Title + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.OpeningMessage + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
		c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(c54f9a911545745b85ae6f74355697f8b.ThePlayer.StartingRoom.UniqueID);
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait, false);
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerLayeredImage, true);
		c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5148));
		if (!(c54f9a911545745b85ae6f74355697f8b.bgMusic != string.Empty))
		{
			__ldtoken(frmMain.c51568856233bbe7fbfdbfcb47e3ae567());
			return;
		}
		object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.bgMusic);
		if (pictureByName != null && pictureByName is string uRL)
		{
			cc925b40132dfc5cb256f0913d0b3c35d(c5722e0b047bf80ee8a41d6d5ca3a5b06);
			c5722e0b047bf80ee8a41d6d5ca3a5b06.URL = uRL;
		}
	}

	private void cfd2619d4c79d66471f6028e1a52a2657(string P_0)
	{
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected Obj, but got Unknown
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected Obj, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected Obj, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0622: Invalid comparison between Unknown and I4
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Invalid comparison between Unknown and I4
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.CharacterList.Clear();
			c54f9a911545745b85ae6f74355697f8b.TimerList.Clear();
			c54f9a911545745b85ae6f74355697f8b.ObjectList.Clear();
			c54f9a911545745b85ae6f74355697f8b.PictureList.Clear();
			c54f9a911545745b85ae6f74355697f8b.RoomList.Clear();
			c54f9a911545745b85ae6f74355697f8b.StatusBarItems.Clear();
			c54f9a911545745b85ae6f74355697f8b.VariableList.Clear();
			c54f9a911545745b85ae6f74355697f8b = null;
		}
		bool flag = false;
		try
		{
			Game.DBName = P_0;
			Game.GetDBConnection();
			c54f9a911545745b85ae6f74355697f8b = new Game(P_0);
			while (!Game.bDoneWithWaitDlg)
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
				Application.DoEvents();
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d = new SaveData();
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.versionnumber = Game.ObjectVersionNumber;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.originalfilename = c33da7cbe080e8167115ce842f845e11f;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
			c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
			binaryFormatter.Serialize(c45a8f1ad7b2f5a62f3d0bb71126882ca, c8e46d07aa274d2f5d4b9a9d2a2a1dd6d);
		}
		catch
		{
			flag = true;
		}
		if (flag)
		{
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			EncDec.Decrypt(P_0, ref memst, ref cs, c378defb8a060f85c4faae8445271e30a);
			memst.Seek(0L, SeekOrigin.Begin);
			try
			{
				c54f9a911545745b85ae6f74355697f8b = null;
				BinaryFormatter binaryFormatter2 = new BinaryFormatter();
				if (c54f9a911545745b85ae6f74355697f8b != null)
				{
					__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
				}
				else
				{
					memst.Seek(0L, SeekOrigin.Begin);
					c54f9a911545745b85ae6f74355697f8b = (Game)binaryFormatter2.Deserialize(memst);
				}
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d = new SaveData();
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.versionnumber = Game.ObjectVersionNumber;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.originalfilename = c33da7cbe080e8167115ce842f845e11f;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
				c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
				binaryFormatter2.Serialize(c45a8f1ad7b2f5a62f3d0bb71126882ca, c8e46d07aa274d2f5d4b9a9d2a2a1dd6d);
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5183));
				return;
			}
			memst.Close();
			memst.Dispose();
			if (cs != null)
			{
				cs.Close();
				cs.Dispose();
			}
		}
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5266) + Path.GetFileName(P_0) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5327) + Game.CurrentObjectVersionNumber;
		if (Environment.GetCommandLineArgs().Length > 2)
		{
			if (!(Environment.GetCommandLineArgs()[2] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4890)))
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			}
			else
			{
				c45335acf471afc831c5b4bad4cbe5394 = new DebugDataFrm(ref c54f9a911545745b85ae6f74355697f8b);
				((Form)c45335acf471afc831c5b4bad4cbe5394).Show((IWin32Window)(object)this);
			}
		}
		if (!c7a0eae8ab4f7ef78712f593022ef41d1.Checked)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = c54f9a911545745b85ae6f74355697f8b.GameFont;
		}
		else
		{
			Font val = null;
			try
			{
				string text = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5330), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347));
				if (text != null)
				{
					__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
				}
				else
				{
					text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347);
				}
				if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347)))
				{
					__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
					string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
					val = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
				}
				else
				{
					val = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
				}
			}
			catch
			{
				val = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
			}
			((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = val;
		}
		GameObject.TheGame = c54f9a911545745b85ae6f74355697f8b;
		Character.TheGame = c54f9a911545745b85ae6f74355697f8b;
		if (c54f9a911545745b85ae6f74355697f8b.SortOrderCharacters != Game.SortOrder.SO_ALPHA)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			IComparer comparer = new myCharacterSortClass();
			c54f9a911545745b85ae6f74355697f8b.CharacterList.Sort(comparer);
		}
		if (c54f9a911545745b85ae6f74355697f8b.SortOrderInventory != Game.SortOrder.SO_ALPHA)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			IComparer comparer2 = new myObjectSortClass();
			c54f9a911545745b85ae6f74355697f8b.ObjectList.Sort(comparer2);
		}
		if (c54f9a911545745b85ae6f74355697f8b.SortOrderRoomObjects != Game.SortOrder.SO_ALPHA)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			IComparer comparer3 = new myObjectSortClass();
			c54f9a911545745b85ae6f74355697f8b.ObjectList.Sort(comparer3);
		}
		c89a684d1b6b2a5a8f4b503a9cc08dff5();
		c54f9a911545745b85ae6f74355697f8b.CorrectCommandAndConditions();
		cfc246fc898e127948f3219ddb6ca1a07();
		c7eea724ca39738cd6aab683af7fa33ca();
		if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Show();
			c98dd8245994cd868d7cdfd180f7f9422.Panel2Collapsed = false;
		}
		else
		{
			((Control)c98dd8245994cd868d7cdfd180f7f9422.Panel2).Hide();
			c98dd8245994cd868d7cdfd180f7f9422.Panel2Collapsed = true;
		}
		if (!c54f9a911545745b85ae6f74355697f8b.bHidePortrait)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Show();
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel1Collapsed = false;
		}
		else
		{
			((Control)c2a161da002bb8cdd90af79c65bcd8c5f.Panel1).Hide();
			c2a161da002bb8cdd90af79c65bcd8c5f.Panel1Collapsed = true;
		}
		if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.bPromptForGender)
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			GetGenderFrm getGenderFrm = new GetGenderFrm();
			getGenderFrm.radioButton1.Checked = true;
			if ((int)((Form)getGenderFrm).ShowDialog() != 1)
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			}
			else
			{
				if (getGenderFrm.radioButton1.Checked)
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Male;
				}
				if (!getGenderFrm.radioButton2.Checked)
				{
					__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
				}
				else
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Female;
				}
				if (getGenderFrm.radioButton3.Checked)
				{
					c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = Player.Gender.Other;
				}
			}
		}
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.bPromptForName)
		{
			AdditionalInputFrm additionalInputFrm = new AdditionalInputFrm(Action.ActionInputType.Text, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
			((Control)additionalInputFrm.lblTitle).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4993);
			((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
			DialogResult val2 = ((Form)additionalInputFrm).ShowDialog();
			if ((int)val2 == 4)
			{
				val2 = ((Form)additionalInputFrm).ShowDialog();
			}
			while (((Control)additionalInputFrm.txtInput).Text == string.Empty)
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5050));
				((Form)additionalInputFrm).ShowDialog();
			}
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.Name = ((Control)additionalInputFrm.txtInput).Text;
		}
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.Title + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.OpeningMessage + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
		c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(c54f9a911545745b85ae6f74355697f8b.ThePlayer.StartingRoom.UniqueID);
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait, false);
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerLayeredImage, true);
		c6896c15b2653af6fffd4ff8146d89e43 = false;
		c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cdb7eb588a870d047a196c0b2bc01bfdf();
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5148));
		if (!(c54f9a911545745b85ae6f74355697f8b.bgMusic != string.Empty))
		{
			__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
		}
		else
		{
			object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.bgMusic);
			if (pictureByName == null)
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			}
			else if (!(pictureByName is string uRL))
			{
				__ldtoken(frmMain.cfd2619d4c79d66471f6028e1a52a2657(string));
			}
			else
			{
				cc925b40132dfc5cb256f0913d0b3c35d(c5722e0b047bf80ee8a41d6d5ca3a5b06);
				c5722e0b047bf80ee8a41d6d5ca3a5b06.URL = uRL;
			}
		}
		c16f20f19536af362c5e437fe3b72ea8b();
	}

	private void c0c9975317d693fd5f4e3431f15ff3ea2()
	{
		try
		{
			c54f9a911545745b85ae6f74355697f8b.TurnCount++;
		}
		catch
		{
		}
	}

	private void c16f20f19536af362c5e437fe3b72ea8b()
	{
		bool flag = false;
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
				Action action = (Action)enumerator.Current;
				if (!(action.name.Substring(0, 2) != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5387)))
				{
					__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
				}
				else if (action.bActive)
				{
					flag = true;
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}
		if (flag)
		{
			((Control)c1126166f2cf1099faab31822dc11d274).Visible = true;
		}
		else
		{
			((Control)c1126166f2cf1099faab31822dc11d274).Visible = false;
		}
		flag = false;
		IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Actions.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
				Action action2 = (Action)enumerator2.Current;
				if (!(action2.name.Substring(0, 2) != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5387)))
				{
					__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
					continue;
				}
				if (!action2.bActive)
				{
					__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
					continue;
				}
				flag = true;
				break;
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable))
			{
				__ldtoken(frmMain.c16f20f19536af362c5e437fe3b72ea8b());
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (flag)
		{
			((Control)c9c86181d01d6e5321a041362bffece16).Visible = true;
		}
		else
		{
			((Control)c9c86181d01d6e5321a041362bffece16).Visible = false;
		}
	}

	private void ce200544896df1b6d0f0b8e63ec1c22bf()
	{
		try
		{
			c0de09ca3f6d361fe93749ff7d9785d96 = true;
			c17c0ba435cecdc830fb1ba4c889283be = false;
			c42664cfaca433d70304c4fb46fa7cceb = string.Empty;
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.ce200544896df1b6d0f0b8e63ec1c22bf());
			for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.TimerList.Count; i++)
			{
				__ldtoken(frmMain.ce200544896df1b6d0f0b8e63ec1c22bf());
				if (!(c54f9a911545745b85ae6f74355697f8b.TimerList[i] is Timer timer))
				{
					__ldtoken(frmMain.ce200544896df1b6d0f0b8e63ec1c22bf());
				}
				else
				{
					c42664cfaca433d70304c4fb46fa7cceb = timer.Name;
					bool flag = false;
					if (!timer.LiveTimer)
					{
						flag = c05d5f4b15820ff69bf30a7a94fdd82fa(timer);
						while (!flag)
						{
							__ldtoken(frmMain.ce200544896df1b6d0f0b8e63ec1c22bf());
							flag = c05d5f4b15820ff69bf30a7a94fdd82fa(timer);
						}
					}
				}
				if (c54f9a911545745b85ae6f74355697f8b == null)
				{
					return;
				}
			}
			if (c45335acf471afc831c5b4bad4cbe5394 == null)
			{
				__ldtoken(frmMain.ce200544896df1b6d0f0b8e63ec1c22bf());
			}
			else
			{
				c45335acf471afc831c5b4bad4cbe5394.RefreshVars();
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
		finally
		{
			c0de09ca3f6d361fe93749ff7d9785d96 = false;
		}
	}

	private bool c05d5f4b15820ff69bf30a7a94fdd82fa(Timer P_0)
	{
		bool result = true;
		c17c0ba435cecdc830fb1ba4c889283be = false;
		if (!P_0.Active)
		{
			__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
			goto IL_017a;
		}
		if (c45335acf471afc831c5b4bad4cbe5394 == null)
		{
			__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
		}
		else
		{
			c45335acf471afc831c5b4bad4cbe5394.AddExecutionData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5392) + P_0.Name, bBold: false);
		}
		P_0.TurnNumber++;
		if (P_0.TurnNumber > P_0.Length)
		{
			if (P_0.TType == Timer.TimerType.TT_LENGTH)
			{
				if (P_0.Restart)
				{
					__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
				}
				else
				{
					P_0.Active = false;
				}
				P_0.TurnNumber = 0;
				goto IL_0174;
			}
			__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
		}
		Action actionByName = P_0.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5407));
		if (actionByName == null)
		{
			__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
		}
		else
		{
			c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
		}
		if (!c17c0ba435cecdc830fb1ba4c889283be)
		{
			__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
			actionByName = P_0.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5440) + P_0.TurnNumber + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5461));
			if (actionByName == null)
			{
				__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
			}
			else
			{
				c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
			}
			if (c17c0ba435cecdc830fb1ba4c889283be)
			{
				return false;
			}
			if (P_0.TurnNumber == P_0.Length)
			{
				actionByName = P_0.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5466));
				if (actionByName == null)
				{
					__ldtoken(frmMain.c05d5f4b15820ff69bf30a7a94fdd82fa(Timer));
				}
				else
				{
					c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
				}
			}
			goto IL_0174;
		}
		return false;
		IL_0174:
		c7eea724ca39738cd6aab683af7fa33ca();
		goto IL_017a;
		IL_017a:
		return result;
	}

	private void c5386af86084f85e6ad20a73f6fe78b74()
	{
		GameObject gameObject = null;
		if (lbInventory.SelectedItem == null)
		{
			__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
		}
		else
		{
			gameObject = lbInventory.SelectedItem as GameObject;
		}
		lbInventory.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
				GameObject gameObject2 = (GameObject)enumerator.Current;
				if (gameObject2.locationtype != GameObject.LocationType.LT_PLAYER)
				{
					__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
					continue;
				}
				if (!gameObject2.bVisible)
				{
					__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
					continue;
				}
				if (!gameObject2.bImportant)
				{
					__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
					lbInventory.Items.Add((object)gameObject2);
				}
				else
				{
					lbInventory.Items.Insert(0, (object)gameObject2);
				}
				if (gameObject2 == gameObject)
				{
					lbInventory.SelectedItem = gameObject2;
				}
				if (!gameObject2.bContainer)
				{
					__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
				}
				else if (gameObject2.bOpenable && !gameObject2.bOpen)
				{
					__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
				}
				else
				{
					caec4ba08610d9a2df5c657f8c3139132(gameObject2, ref lbInventory, gameObject);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
			}
			else
			{
				disposable.Dispose();
			}
		}
		for (int num = lbInventory.Items.Count - 1; num >= 0; num--)
		{
			if (!(lbInventory.Items[num] is GameObject gameObject3))
			{
				__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
			}
			else if (!gameObject3.bImportant)
			{
				__ldtoken(frmMain.c5386af86084f85e6ad20a73f6fe78b74());
			}
			else
			{
				lbInventory.Items.Remove((object)gameObject3);
				lbInventory.Items.Insert(0, (object)gameObject3);
			}
		}
	}

	private void cbc7ad2fc50dfbe4191690a255afd70e4()
	{
		GameObject gameObject = null;
		if (lbRoomObjects.SelectedItem == null)
		{
			__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
		}
		else
		{
			gameObject = lbRoomObjects.SelectedItem as GameObject;
		}
		lbRoomObjects.Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
				GameObject gameObject2 = (GameObject)enumerator.Current;
				if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom == null)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					continue;
				}
				if (gameObject2.locationtype != GameObject.LocationType.LT_ROOM)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					continue;
				}
				if (!(gameObject2.locationname == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					continue;
				}
				if (!gameObject2.bVisible)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					continue;
				}
				lbRoomObjects.Items.Add((object)gameObject2);
				if (gameObject2 == gameObject)
				{
					lbRoomObjects.SelectedItem = gameObject2;
				}
				if (!gameObject2.bContainer)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
				}
				else if (!gameObject2.bOpenable || gameObject2.bOpen)
				{
					caec4ba08610d9a2df5c657f8c3139132(gameObject2, ref lbRoomObjects, gameObject);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
			}
			else
			{
				disposable.Dispose();
			}
		}
		for (int num = lbRoomObjects.Items.Count - 1; num >= 0; num--)
		{
			if (!(lbRoomObjects.Items[num] is GameObject gameObject3))
			{
				__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
			}
			else if (gameObject3.bImportant)
			{
				lbRoomObjects.Items.Remove((object)gameObject3);
				lbRoomObjects.Items.Insert(0, (object)gameObject3);
			}
		}
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom == null)
		{
			__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
			return;
		}
		IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Exits.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
				Exit exit = (Exit)enumerator2.Current;
				if (!(exit.PortalObjectName != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5499)))
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					continue;
				}
				bool flag = false;
				{
					IEnumerator enumerator3 = lbRoomObjects.Items.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
							GameObject gameObject4 = (GameObject)enumerator3.Current;
							if (gameObject4.name.IndexOf(exit.PortalObjectName) == 0)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						IDisposable disposable3 = enumerator3 as IDisposable;
						if (disposable3 != null)
						{
							disposable3.Dispose();
						}
					}
				}
				if (flag)
				{
					continue;
				}
				GameObject gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(exit.PortalObjectName);
				if (gameObject5 != null)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
				}
				else
				{
					gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(exit.PortalObjectName);
				}
				if (gameObject5 == null)
				{
					__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
				}
				else
				{
					if (!gameObject5.bVisible)
					{
						continue;
					}
					lbRoomObjects.Items.Add((object)gameObject5);
					if (gameObject5 != gameObject)
					{
						__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					}
					else
					{
						lbRoomObjects.SelectedItem = gameObject5;
					}
					if (!gameObject5.bContainer)
					{
						__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
						continue;
					}
					if (!gameObject5.bOpenable)
					{
						__ldtoken(frmMain.cbc7ad2fc50dfbe4191690a255afd70e4());
					}
					else if (!gameObject5.bOpen)
					{
						continue;
					}
					caec4ba08610d9a2df5c657f8c3139132(gameObject5, ref lbRoomObjects, gameObject);
				}
			}
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

	private void caec4ba08610d9a2df5c657f8c3139132(GameObject P_0, ref ListBox P_1, GameObject P_2)
	{
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
		{
			__ldtoken(frmMain.caec4ba08610d9a2df5c657f8c3139132(GameObject, ref ListBox, GameObject));
			GameObject gameObject = c54f9a911545745b85ae6f74355697f8b.ObjectList[i] as GameObject;
			if (gameObject.locationtype != GameObject.LocationType.LT_IN_OBJECT)
			{
				continue;
			}
			if (!(gameObject.locationname == P_0.UniqueIdentifier.ToString()))
			{
				__ldtoken(frmMain.caec4ba08610d9a2df5c657f8c3139132(GameObject, ref ListBox, GameObject));
				continue;
			}
			if (!gameObject.bVisible)
			{
				__ldtoken(frmMain.caec4ba08610d9a2df5c657f8c3139132(GameObject, ref ListBox, GameObject));
				continue;
			}
			P_1.Items.Add((object)gameObject);
			if (gameObject != P_2)
			{
				__ldtoken(frmMain.caec4ba08610d9a2df5c657f8c3139132(GameObject, ref ListBox, GameObject));
			}
			else
			{
				P_1.SelectedItem = gameObject;
			}
			if (gameObject.bOpenable)
			{
				if (!gameObject.bOpen)
				{
					__ldtoken(frmMain.caec4ba08610d9a2df5c657f8c3139132(GameObject, ref ListBox, GameObject));
				}
				else
				{
					caec4ba08610d9a2df5c657f8c3139132(gameObject, ref P_1, P_2);
				}
			}
		}
	}

	private void c00ed6bfb4a2d2788898016cf199cd52c()
	{
		int num = 0;
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
				GameObject gameObject = (GameObject)enumerator.Current;
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM)
				{
					continue;
				}
				if (!(gameObject.locationname == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
				}
				else if (gameObject.bVisible)
				{
					if (num != 0)
					{
						__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
					}
					else
					{
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5512), Color.Black, (FontStyle)0);
					}
					if (num > 0)
					{
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5537), c480af4d9d26cffd3c4b7d5da5b9cb646, (FontStyle)1);
					}
					if (gameObject.preposition.Trim().Length <= 0)
					{
						__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, gameObject.ToString(), c480af4d9d26cffd3c4b7d5da5b9cb646, (FontStyle)1);
					}
					else
					{
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, gameObject.preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5327) + gameObject.ToString(), c480af4d9d26cffd3c4b7d5da5b9cb646, (FontStyle)1);
					}
					num++;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (num <= 0)
		{
			__ldtoken(frmMain.c00ed6bfb4a2d2788898016cf199cd52c());
		}
		else
		{
			((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
		}
	}

	private void c6df55a7ba938a3b24d6b7592b94240ea(bool P_0, bool P_1)
	{
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		string text = string.Empty;
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom == null)
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		}
		else
		{
			text = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
		}
		((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom == null)
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		}
		else
		{
			object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
			if (pictureByName != null)
			{
				Image val = (Image)((pictureByName is Image) ? pictureByName : null);
				if (val == null)
				{
					__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
					((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Visible = true;
					((Control)c0970743bbfbc89b095632fb02680fc3b).Visible = false;
					ce585e6a23b47a28be2fa67d1e95f4dae.URL = pictureByName as string;
				}
				else
				{
					((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Visible = false;
					((Control)c0970743bbfbc89b095632fb02680fc3b).Visible = true;
					((Control)c0970743bbfbc89b095632fb02680fc3b).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
					((Control)c0970743bbfbc89b095632fb02680fc3b).BackgroundImage = val;
				}
				PictureBox val2 = c0970743bbfbc89b095632fb02680fc3b;
				object pictureByName2 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.LayeredRoomPic);
				val2.Image = (Image)((pictureByName2 is Image) ? pictureByName2 : null);
				if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
				{
					__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
				}
				else if (c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
				{
					((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
					Clipboard.SetDataObject(pictureByName);
					((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
					((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
					((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
				}
				if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
				{
					if (val != null)
					{
						((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = val;
					}
					else
					{
						((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
						c3d3f592020623bcd70bc7878559e94cb.URL = pictureByName as string;
					}
					object pictureByName3 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.LayeredRoomPic);
					cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
					if (pictureByName3 == null)
					{
						__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
					}
					else
					{
						Image val3 = (Image)((pictureByName3 is Image) ? pictureByName3 : null);
						if (val3 == null)
						{
							__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
							c3d3f592020623bcd70bc7878559e94cb.URL = pictureByName3 as string;
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							cd431de8c0add2abbb6ebb8d63e4db3c0.Image = val3;
						}
					}
				}
			}
			else
			{
				((Control)c0970743bbfbc89b095632fb02680fc3b).Tag = null;
				c0970743bbfbc89b095632fb02680fc3b.Image = null;
				((Control)c0970743bbfbc89b095632fb02680fc3b).BackgroundImage = null;
				cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
				((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = null;
				((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = null;
			}
			((Control)c568e1c3a8d35460b6f9f9e370d7f266a).Text = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.GetName();
		}
		Guid uniqueID = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID;
		if (!P_1)
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		}
		else
		{
			if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bEnterFirstTime)
			{
				c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bEnterFirstTime = true;
				c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5542));
			}
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603));
		}
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		if (text == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString())
		{
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Description + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
		}
		if (!(uniqueID == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID))
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
			return;
		}
		cbc7ad2fc50dfbe4191690a255afd70e4();
		if (c54f9a911545745b85ae6f74355697f8b.bTurnOffNotifications)
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		}
		else
		{
			c00ed6bfb4a2d2788898016cf199cd52c();
		}
		cb5f80821c1935214fc7dc85fce670316();
		cfbd5c34adeba9b31c9a5ce3808226478();
		if (!P_0)
		{
			__ldtoken(frmMain.c6df55a7ba938a3b24d6b7592b94240ea(bool, bool));
		}
		else
		{
			ce200544896df1b6d0f0b8e63ec1c22bf();
		}
		c7eea724ca39738cd6aab683af7fa33ca();
		c16f20f19536af362c5e437fe3b72ea8b();
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cdb7eb588a870d047a196c0b2bc01bfdf();
	}

	private void cb5f80821c1935214fc7dc85fce670316()
	{
		object obj = null;
		if (lbCharacters.SelectedItem == null)
		{
			__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
		}
		else
		{
			obj = lbCharacters.SelectedItem;
		}
		lbCharacters.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
				Character character = (Character)enumerator.Current;
				if (!(character.CurrentRoom == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
					continue;
				}
				lbCharacters.Items.Add((object)character);
				if (c54f9a911545745b85ae6f74355697f8b.bTurnOffNotifications)
				{
					__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
				}
				else
				{
					TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, character.ToString(), c480af4d9d26cffd3c4b7d5da5b9cb646, (FontStyle)1);
					TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5642), Color.Black, (FontStyle)0);
				}
				if (!character.bAllowInventoryInteraction)
				{
					__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
					continue;
				}
				IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						GameObject gameObject = (GameObject)enumerator2.Current;
						if (gameObject.locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
						}
						else if (!(gameObject.locationname == character.Charname))
						{
							__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
						}
						else if (!gameObject.bVisible)
						{
							__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
						}
						else
						{
							lbCharacters.Items.Add((object)gameObject);
						}
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
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
				__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		for (int num = lbCharacters.Items.Count - 1; num >= 0; num--)
		{
			__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
			if (lbCharacters.Items[num] is GameObject gameObject2)
			{
				if (!gameObject2.bImportant)
				{
					__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
				}
				else
				{
					lbCharacters.Items.Remove((object)gameObject2);
					lbCharacters.Items.Insert(0, (object)gameObject2);
				}
			}
		}
		for (int i = 0; i < lbCharacters.Items.Count; i++)
		{
			__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
			object obj2 = lbCharacters.Items[i];
			if (obj2 == null)
			{
				__ldtoken(frmMain.cb5f80821c1935214fc7dc85fce670316());
			}
			else if (obj2 == obj)
			{
				lbCharacters.SelectedItem = obj2;
			}
		}
	}

	private void cfbd5c34adeba9b31c9a5ce3808226478()
	{
		for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Exits.Count; i++)
		{
			__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
			Exit exit = (Exit)c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Exits[i];
			switch (exit.Direction)
			{
			case Exit.Directions.North:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else if (exit.DestinationRoom != string.Empty)
				{
					((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Visible = true;
					cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)cd4c5cd27cd40059e2a3eeabdc85952d6, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
					break;
				}
				((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Visible = false;
				break;
			case Exit.Directions.South:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else if (exit.DestinationRoom != string.Empty)
				{
					((Control)c90c65c890556f98316961b88b452411c).Visible = true;
					cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c90c65c890556f98316961b88b452411c, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
					((Control)c90c65c890556f98316961b88b452411c).Enabled = true;
					break;
				}
				((Control)c90c65c890556f98316961b88b452411c).Visible = false;
				((Control)c90c65c890556f98316961b88b452411c).Enabled = false;
				break;
			case Exit.Directions.West:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c19001e7fd0fb0231ceafdb91b7fc553c, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Visible = false;
				break;
			case Exit.Directions.East:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else if (exit.DestinationRoom != string.Empty)
				{
					((Control)cecc2bca13f554623b27fef0a7612d89a).Visible = true;
					cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)cecc2bca13f554623b27fef0a7612d89a, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
					break;
				}
				((Control)cecc2bca13f554623b27fef0a7612d89a).Visible = false;
				break;
			case Exit.Directions.Up:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)cb16a9ba7ac8e9ac3aba347a7de4e234c, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Visible = false;
				break;
			case Exit.Directions.Down:
				if (exit.bActive)
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)c9e0726c3f64d9712d80f7f792ba03c24).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c9e0726c3f64d9712d80f7f792ba03c24, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)c9e0726c3f64d9712d80f7f792ba03c24).Visible = false;
				break;
			case Exit.Directions.NorthWest:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)c8458b8759f70d83b69ed336abafed87d).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c8458b8759f70d83b69ed336abafed87d, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)c8458b8759f70d83b69ed336abafed87d).Visible = false;
				break;
			case Exit.Directions.NorthEast:
				if (exit.bActive)
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)c380ea8b92cbdb7629b6ba12210334b71).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c380ea8b92cbdb7629b6ba12210334b71, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)c380ea8b92cbdb7629b6ba12210334b71).Visible = false;
				break;
			case Exit.Directions.SouthWest:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else if (exit.DestinationRoom != string.Empty)
				{
					((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Visible = true;
					cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c40520cf7b831e6aa4bb0ebd41a9bed10, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
					break;
				}
				((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Visible = false;
				break;
			case Exit.Directions.SouthEast:
				if (exit.bActive && exit.DestinationRoom != string.Empty)
				{
					((Control)cf4a085f96b5e3008906285bfac50d314).Visible = true;
					cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)cf4a085f96b5e3008906285bfac50d314, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
				}
				else
				{
					((Control)cf4a085f96b5e3008906285bfac50d314).Visible = false;
				}
				break;
			case Exit.Directions.In:
				if (!exit.bActive)
				{
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				else
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)ce764cacadcb2bc3fd4bdd3b3355f0610, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Visible = false;
				break;
			case Exit.Directions.Out:
				if (exit.bActive)
				{
					if (exit.DestinationRoom != string.Empty)
					{
						((Control)c550ba434b320f806a8f4645040b88e72).Visible = true;
						cc2b2196e6c009b5ea6d986a89947275c.SetToolTip((Control)(object)c550ba434b320f806a8f4645040b88e72, c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(exit.DestinationRoom)).GetName());
						break;
					}
					__ldtoken(frmMain.cfbd5c34adeba9b31c9a5ce3808226478());
				}
				((Control)c550ba434b320f806a8f4645040b88e72).Visible = false;
				break;
			}
		}
	}

	private void cb3508e0b5ec36c577e13b6751353bed7(object P_0, EventArgs P_1)
	{
	}

	private void c4396f8f427ccc36a88d9c5559fc6269c(string P_0)
	{
		try
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
			Guid uniqueID = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID;
			Action actionByName = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.GetActionByName(P_0);
			if (actionByName != null)
			{
				c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
			}
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			actionByName = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(P_0);
			if (actionByName == null)
			{
				__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
			}
			else
			{
				c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
			}
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
			for (int i = 0; i < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; i++)
			{
				__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				GameObject gameObject = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[i];
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				if (!(gameObject.locationname == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					continue;
				}
				if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5665)) <= -1)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5690)) > -1)
					{
						if (gameObject.bLeaveFirstTime)
						{
							__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						}
						else
						{
							actionByName = gameObject.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
							gameObject.bLeaveFirstTime = true;
							if (actionByName == null)
							{
								__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
							}
							else
							{
								c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject);
							}
						}
					}
				}
				else if (gameObject.bEnterFirstTime)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				}
				else
				{
					actionByName = gameObject.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5542));
					gameObject.bEnterFirstTime = true;
					if (actionByName != null)
					{
						c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject);
					}
				}
				actionByName = gameObject.GetActionByName(P_0);
				if (actionByName == null)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				}
				else
				{
					if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					}
					else if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776)))
					{
						goto IL_025c;
					}
					if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
					{
						if (uniqueID == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID)
						{
							c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject);
						}
					}
					else
					{
						c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject);
					}
				}
				goto IL_025c;
				IL_025c:
				if (!gameObject.bContainer)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				if (!gameObject.bOpenable)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				}
				else if (!gameObject.bOpen)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				for (int j = 0; j < c54f9a911545745b85ae6f74355697f8b.ObjectList.Count; j++)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					GameObject gameObject2 = (GameObject)c54f9a911545745b85ae6f74355697f8b.ObjectList[j];
					if (gameObject2.locationtype != GameObject.LocationType.LT_IN_OBJECT)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						continue;
					}
					if (!(gameObject2.locationname == gameObject.UniqueIdentifier.ToString()))
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						continue;
					}
					if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5665)) <= -1)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5690)) > -1)
						{
							if (gameObject2.bLeaveFirstTime)
							{
								__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
							}
							else
							{
								actionByName = gameObject2.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
								gameObject2.bLeaveFirstTime = true;
								if (actionByName != null)
								{
									c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject2);
								}
							}
						}
					}
					else if (gameObject2.bEnterFirstTime)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					}
					else
					{
						actionByName = gameObject2.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5542));
						gameObject2.bEnterFirstTime = true;
						if (actionByName == null)
						{
							__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						}
						else
						{
							c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject2);
						}
					}
					actionByName = gameObject2.GetActionByName(P_0);
					if (actionByName == null)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						continue;
					}
					if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					}
					else if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776)))
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						continue;
					}
					if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
					{
						if (uniqueID == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID)
						{
							c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject2);
						}
					}
					else
					{
						c9cff05a07825c588d9efb7028802a05f(ref actionByName, gameObject2);
					}
				}
			}
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
			for (int k = 0; k < c54f9a911545745b85ae6f74355697f8b.CharacterList.Count; k++)
			{
				__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				Character character = (Character)c54f9a911545745b85ae6f74355697f8b.CharacterList[k];
				if (!(character.CurrentRoom == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5665)) > -1)
				{
					if (character.bEnterFirstTime)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					}
					else
					{
						actionByName = character.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5542));
						character.bEnterFirstTime = true;
						if (actionByName == null)
						{
							__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
						}
						else
						{
							c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
						}
					}
				}
				else if (P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5690)) > -1 && !character.bLeaveFirstTime)
				{
					actionByName = character.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
					character.bLeaveFirstTime = true;
					if (actionByName == null)
					{
						__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					}
					else
					{
						c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
					}
				}
				actionByName = character.GetActionByName(P_0);
				if (actionByName == null)
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				}
				else if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776)))
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					continue;
				}
				if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5603)))
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
					c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
				}
				else if (!(uniqueID == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID))
				{
					__ldtoken(frmMain.c4396f8f427ccc36a88d9c5559fc6269c(string));
				}
				else
				{
					c9cff05a07825c588d9efb7028802a05f(ref actionByName, null);
				}
			}
		}
		catch
		{
		}
	}

	private void c1d8e4bd213ff6989c2d4e9f1a3429152(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.North;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5815), Color.Black, (FontStyle)1);
		if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.c1d8e4bd213ff6989c2d4e9f1a3429152(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c1d8e4bd213ff6989c2d4e9f1a3429152(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.North);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c9ee62976d23275acb96584ca30167825(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.South;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5830), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c9ee62976d23275acb96584ca30167825(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (!c51279ee02a1043fe19c2f931ed627109)
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.South);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void cb6b0e134e59bef02adee8a8232f5ac4d(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.West;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5845), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.cb6b0e134e59bef02adee8a8232f5ac4d(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.cb6b0e134e59bef02adee8a8232f5ac4d(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.cb6b0e134e59bef02adee8a8232f5ac4d(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.West);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void ca3371f019d49945be20fb7007425cba1(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.East;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5858), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.ca3371f019d49945be20fb7007425cba1(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.ca3371f019d49945be20fb7007425cba1(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.ca3371f019d49945be20fb7007425cba1(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.East);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c98b0d6e2d3e2f95dc20b0ef21fade4fc(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.SouthWest;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5871), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c98b0d6e2d3e2f95dc20b0ef21fade4fc(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.c98b0d6e2d3e2f95dc20b0ef21fade4fc(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c98b0d6e2d3e2f95dc20b0ef21fade4fc(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.SouthWest);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c5f280b879521f714f8b5aa4febb03da7(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.SouthEast;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5894), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c5f280b879521f714f8b5aa4febb03da7(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (!c51279ee02a1043fe19c2f931ed627109)
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c5f280b879521f714f8b5aa4febb03da7(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.SouthEast);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c4cdd8c69b0fb57b72c6bbbd30ae74794(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.NorthWest;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5917), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c4cdd8c69b0fb57b72c6bbbd30ae74794(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.c4cdd8c69b0fb57b72c6bbbd30ae74794(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.NorthWest);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c3795d553a32d3287242f9de094167d49(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.NorthEast;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5940), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c3795d553a32d3287242f9de094167d49(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.c3795d553a32d3287242f9de094167d49(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c3795d553a32d3287242f9de094167d49(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.NorthEast);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c78a0ed8b2d5c43d6cfea40c0e620bea4(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Up;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5963), Color.Black, (FontStyle)1);
		if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			__ldtoken(frmMain.c78a0ed8b2d5c43d6cfea40c0e620bea4(object, EventArgs));
		}
		else
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (!c51279ee02a1043fe19c2f931ed627109)
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.c78a0ed8b2d5c43d6cfea40c0e620bea4(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.Up);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void cd51509c3a929c396af62c1b408d2b330(object P_0, EventArgs P_1)
	{
		c0c9975317d693fd5f4e3431f15ff3ea2();
		c51279ee02a1043fe19c2f931ed627109 = false;
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Down;
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5972), Color.Black, (FontStyle)1);
		if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
		{
			c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
		}
		c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
		if (c51279ee02a1043fe19c2f931ed627109)
		{
			__ldtoken(frmMain.cd51509c3a929c396af62c1b408d2b330(object, EventArgs));
		}
		else
		{
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				return;
			}
			__ldtoken(frmMain.cd51509c3a929c396af62c1b408d2b330(object, EventArgs));
			c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.Down);
			c6df55a7ba938a3b24d6b7592b94240ea(true, true);
		}
		c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
	}

	private void c1c7e722e9171a93d5f29b3f1a6c671a7(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		GameObject gameObject = null;
		string text = string.Empty;
		switch (c3bf3a953472a12db8827db3f743d5429)
		{
		case c10b414d2e012eeb2ef0cc25b561b1549.cde26345c3892d2dd4757283560083496:
			gameObject = lbCharacters.SelectedItem as GameObject;
			text = lbCharacters.SelectedItem.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143);
			break;
		case c10b414d2e012eeb2ef0cc25b561b1549.c8bce6377505aef2547787d71a915b3b8:
			gameObject = lbInventory.SelectedItem as GameObject;
			text = ce7ea9b14dc4bab43e4cb717b69560901(lbInventory.SelectedItem.ToString()) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143);
			break;
		case c10b414d2e012eeb2ef0cc25b561b1549.cfbba04fc2eff86441089b369b8432706:
			gameObject = lbRoomObjects.SelectedItem as GameObject;
			text = ce7ea9b14dc4bab43e4cb717b69560901(lbRoomObjects.SelectedItem.ToString()) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143);
			break;
		case c10b414d2e012eeb2ef0cc25b561b1549.c4c08a3f00c9c0c5e2811fbf9e3f4dc18:
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5992) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143);
			break;
		case c10b414d2e012eeb2ef0cc25b561b1549.c7d09946dbb22579280d3e849becda121:
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6011) + c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.GetName() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143);
			break;
		}
		Action action = ((ToolStripItem)val).Tag as Action;
		if (action == null)
		{
			__ldtoken(frmMain.c1c7e722e9171a93d5f29b3f1a6c671a7(object, EventArgs));
		}
		else
		{
			c0c9975317d693fd5f4e3431f15ff3ea2();
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text, Color.Black, (FontStyle)1);
			if (!c9cff05a07825c588d9efb7028802a05f(ref action, gameObject))
			{
				return;
			}
			__ldtoken(frmMain.c1c7e722e9171a93d5f29b3f1a6c671a7(object, EventArgs));
			if (c58eb8f529a8b8e52b34a6d519eb0e31b)
			{
				__ldtoken(frmMain.c1c7e722e9171a93d5f29b3f1a6c671a7(object, EventArgs));
				c58eb8f529a8b8e52b34a6d519eb0e31b = false;
			}
			else
			{
				ce200544896df1b6d0f0b8e63ec1c22bf();
				c7eea724ca39738cd6aab683af7fa33ca();
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
		((Control)c1e8a97c8afdf40dab745e3180f49333e).Hide();
	}

	private string ce7ea9b14dc4bab43e4cb717b69560901(string P_0)
	{
		string text = P_0;
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730));
		if (num <= -1)
		{
			__ldtoken(frmMain.ce7ea9b14dc4bab43e4cb717b69560901(string));
		}
		else
		{
			text = P_0.Substring(0, num);
		}
		return text.Trim();
	}

	private void c4507559406693ebe8dd5fbc5accac0d4(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		Action action = ((ToolStripItem)val).Tag as Action;
		if (action == null)
		{
			__ldtoken(frmMain.c4507559406693ebe8dd5fbc5accac0d4(object, EventArgs));
			return;
		}
		c0c9975317d693fd5f4e3431f15ff3ea2();
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5992) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		if (c9cff05a07825c588d9efb7028802a05f(ref action, null))
		{
			__ldtoken(frmMain.c4507559406693ebe8dd5fbc5accac0d4(object, EventArgs));
			if (c58eb8f529a8b8e52b34a6d519eb0e31b)
			{
				__ldtoken(frmMain.c4507559406693ebe8dd5fbc5accac0d4(object, EventArgs));
				c58eb8f529a8b8e52b34a6d519eb0e31b = false;
			}
			else
			{
				ce200544896df1b6d0f0b8e63ec1c22bf();
				c7eea724ca39738cd6aab683af7fa33ca();
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
	}

	private void cc3b3a99908ad9aeca1eb6d1cacbbc793(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		if (lbInventory.SelectedItem == null || !(lbInventory.SelectedItem is GameObject gameObject))
		{
			return;
		}
		__ldtoken(frmMain.cc3b3a99908ad9aeca1eb6d1cacbbc793(object, EventArgs));
		Action action = ((ToolStripItem)val).Tag as Action;
		if (action == null)
		{
			__ldtoken(frmMain.cc3b3a99908ad9aeca1eb6d1cacbbc793(object, EventArgs));
			return;
		}
		c0c9975317d693fd5f4e3431f15ff3ea2();
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ce7ea9b14dc4bab43e4cb717b69560901(lbInventory.SelectedItem.ToString()) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		if (c9cff05a07825c588d9efb7028802a05f(ref action, gameObject))
		{
			__ldtoken(frmMain.cc3b3a99908ad9aeca1eb6d1cacbbc793(object, EventArgs));
			if (!c58eb8f529a8b8e52b34a6d519eb0e31b)
			{
				ce200544896df1b6d0f0b8e63ec1c22bf();
				c7eea724ca39738cd6aab683af7fa33ca();
			}
			else
			{
				c58eb8f529a8b8e52b34a6d519eb0e31b = false;
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
	}

	private int c835c6acbec36e979a142e0cab9dccbf2(string P_0)
	{
		int result = -1;
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730));
		if (num <= -1)
		{
			__ldtoken(frmMain.c835c6acbec36e979a142e0cab9dccbf2(string));
		}
		else
		{
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738), num);
			if (num2 > -1)
			{
				string value = P_0.Substring(num + 1, num2 - (num + 1));
				try
				{
					result = Convert.ToInt32(value);
				}
				catch
				{
					result = -1;
				}
			}
		}
		return result;
	}

	private int c9f91498283773f610332946230356cc8(string P_0)
	{
		int result = -1;
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730));
		if (num <= -1)
		{
			__ldtoken(frmMain.c9f91498283773f610332946230356cc8(string));
		}
		else
		{
			num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(730), num + 1);
			if (num <= -1)
			{
				__ldtoken(frmMain.c9f91498283773f610332946230356cc8(string));
			}
			else
			{
				int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(738), num);
				if (num2 <= -1)
				{
					__ldtoken(frmMain.c9f91498283773f610332946230356cc8(string));
				}
				else
				{
					string value = P_0.Substring(num + 1, num2 - (num + 1));
					try
					{
						result = Convert.ToInt32(value);
					}
					catch
					{
						result = -1;
					}
				}
			}
		}
		return result;
	}

	private Action c7ad33b0f6a0935fd4394c957998fdb49(string P_0, string P_1, string P_2)
	{
		Action result = null;
		if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6024)))
		{
			result = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(P_1).GetActionByName(P_2);
		}
		else if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6031)))
		{
			__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
			if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(629)))
			{
				__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
				if (!P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6038)))
				{
					__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
					if (P_0.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6047)))
					{
						Timer timer = null;
						timer = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(P_1);
						if (timer == null)
						{
							__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
						}
						else
						{
							result = timer.GetActionByName(P_2);
						}
					}
				}
				else
				{
					Room room = null;
					try
					{
						room = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(P_1));
					}
					catch
					{
						room = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref P_1);
					}
					if (room != null)
					{
						result = room.GetActionByName(P_2);
					}
				}
			}
			else
			{
				result = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(P_2);
			}
		}
		else
		{
			GameObject gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(P_1);
			if (gameObject != null)
			{
				__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
			}
			else
			{
				gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(P_1);
			}
			if (gameObject == null)
			{
				__ldtoken(frmMain.c7ad33b0f6a0935fd4394c957998fdb49(string, string, string));
			}
			else
			{
				result = gameObject.GetActionByName(P_2);
			}
		}
		return result;
	}

	private void ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref object P_0)
	{
		object obj = P_0;
		ArrayObject val = (ArrayObject)((obj is ArrayObject) ? obj : null);
		if (val == null)
		{
			__ldtoken(frmMain.ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref object));
		}
		else
		{
			for (int i = 0; i < Convert.ToInt32(val.length); i++)
			{
				__ldtoken(frmMain.ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref object));
				object obj2 = ((ScriptObject)val)[i];
				ArrayObject val2 = (ArrayObject)((obj2 is ArrayObject) ? obj2 : null);
				if (val2 == null)
				{
					__ldtoken(frmMain.ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref object));
					continue;
				}
				string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6058) + ((ScriptObject)val2)[0].ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1532);
				string text2 = ((ScriptObject)val2)[1].ToString();
				if (!(text2 == string.Empty))
				{
					__ldtoken(frmMain.ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref object));
				}
				else
				{
					text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5327);
				}
				c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text, null, text2);
			}
		}
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait, false);
		cfbd5c34adeba9b31c9a5ce3808226478();
	}

	private void c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable P_0, ref object P_1)
	{
		try
		{
			if (P_0.VarArray.Count <= 0)
			{
				__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
			}
			else if (!(P_0.VarArray[0] is ArrayList arrayList))
			{
				__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
			}
			else
			{
				_ = arrayList.Count;
			}
			P_0.VarArray.Clear();
			object obj = P_1;
			ArrayObject val = (ArrayObject)((obj is ArrayObject) ? obj : null);
			if (val == null)
			{
				return;
			}
			for (int i = 0; i < Convert.ToInt32(val.length); i++)
			{
				__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
				object obj2 = ((ScriptObject)val)[i];
				ArrayObject val2 = (ArrayObject)((obj2 is ArrayObject) ? obj2 : null);
				if (val2 == null)
				{
					__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
					object value = null;
					switch (P_0.vartype)
					{
					case GameVariable.VarType.VT_DATETIMEARRAY:
						try
						{
							value = Convert.ToDateTime(((ScriptObject)val)[i].ToString());
						}
						catch
						{
							value = DateTime.MinValue;
						}
						break;
					case GameVariable.VarType.VT_NUMBERARRAY:
						try
						{
							value = Convert.ToDouble(((ScriptObject)val)[i].ToString());
						}
						catch
						{
							value = -1;
						}
						break;
					case GameVariable.VarType.VT_STRINGARRAY:
						value = ((ScriptObject)val)[i].ToString();
						break;
					}
					P_0.VarArray.Add(value);
					continue;
				}
				for (int j = 0; j < Convert.ToInt32(val2.length); j++)
				{
					__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
					if (j != 0)
					{
						__ldtoken(frmMain.c6dfae8dbd6f9ecaabac6b01194846c4e(GameVariable, ref object));
					}
					else
					{
						P_0.VarArray.Add(new ArrayList());
					}
					object obj5 = ((ScriptObject)val2)[j];
					((ArrayList)P_0.VarArray[i]).Add(obj5.ToString());
				}
			}
		}
		catch
		{
		}
	}

	private bool c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList P_0, GameObject P_1, string P_2, ref Action P_3, object P_4)
	{
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_97af: Unknown result type (might be due to invalid IL or missing references)
		//IL_97b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_9944: Unknown result type (might be due to invalid IL or missing references)
		//IL_9949: Unknown result type (might be due to invalid IL or missing references)
		//IL_a8c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_a8cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_a96f: Unknown result type (might be due to invalid IL or missing references)
		//IL_96f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_96fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_96ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_98e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_98ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_98ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_9907: Unknown result type (might be due to invalid IL or missing references)
		//IL_990c: Invalid comparison between Unknown and I4
		//IL_991d: Unknown result type (might be due to invalid IL or missing references)
		//IL_9922: Invalid comparison between Unknown and I4
		//IL_9912: Unknown result type (might be due to invalid IL or missing references)
		//IL_9917: Unknown result type (might be due to invalid IL or missing references)
		//IL_9919: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9766: Unknown result type (might be due to invalid IL or missing references)
		//IL_976b: Invalid comparison between Unknown and I4
		//IL_9953: Unknown result type (might be due to invalid IL or missing references)
		//IL_9958: Invalid comparison between Unknown and I4
		//IL_9782: Unknown result type (might be due to invalid IL or missing references)
		//IL_9787: Invalid comparison between Unknown and I4
		//IL_9777: Unknown result type (might be due to invalid IL or missing references)
		//IL_977c: Unknown result type (might be due to invalid IL or missing references)
		//IL_977e: Unknown result type (might be due to invalid IL or missing references)
		//IL_97be: Unknown result type (might be due to invalid IL or missing references)
		//IL_97c3: Invalid comparison between Unknown and I4
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Invalid comparison between Unknown and I4
		//IL_1a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a94: Invalid comparison between Unknown and I4
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Invalid comparison between Unknown and I4
		//IL_1ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab9: Invalid comparison between Unknown and I4
		//IL_a09f: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0a8: Expected Obj, but got Unknown
		//IL_9563: Unknown result type (might be due to invalid IL or missing references)
		//IL_956c: Expected Obj, but got Unknown
		//IL_1c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_a588: Unknown result type (might be due to invalid IL or missing references)
		//IL_a58d: Unknown result type (might be due to invalid IL or missing references)
		//IL_a591: Unknown result type (might be due to invalid IL or missing references)
		//IL_a596: Invalid comparison between Unknown and I4
		//IL_939d: Unknown result type (might be due to invalid IL or missing references)
		//IL_93a7: Expected Obj, but got Unknown
		//IL_a5b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5b6: Invalid comparison between Unknown and I4
		//IL_a5a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_a449: Unknown result type (might be due to invalid IL or missing references)
		//IL_a44e: Unknown result type (might be due to invalid IL or missing references)
		//IL_a451: Invalid comparison between Unknown and I4
		//IL_9edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_9ee9: Expected Obj, but got Unknown
		//IL_a22f: Unknown result type (might be due to invalid IL or missing references)
		//IL_a239: Expected Obj, but got Unknown
		bool result = false;
		for (int i = 0; i < P_0.Count; i++)
		{
			__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
			Command command = P_0[i] as Command;
			if (!(P_0[i] is Condition condition))
			{
				__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
				if (command == null)
				{
					continue;
				}
				if (c54f9a911545745b85ae6f74355697f8b == null)
				{
					return false;
				}
				__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
				string roomname = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(command.CommandPart2, P_4);
				string roomname2 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(command.CommandPart3, P_4);
				string roomname3 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(command.CommandPart4, P_4);
				string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(command.CommandText, P_4);
				if (c45335acf471afc831c5b4bad4cbe5394 != null)
				{
					c45335acf471afc831c5b4bad4cbe5394.AddExecutionData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6061) + command.cmdtype.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + roomname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + roomname2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + roomname3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6080), bBold: false);
				}
				try
				{
					AdditionalInputFrm additionalInputFrm2;
					Action.ActionInputType actionInputType2;
					AdditionalInputFrm additionalInputFrm;
					Action.ActionInputType actionInputType;
					bool flag;
					bool flag6;
					GameVariable variableByName5;
					int num9;
					int num10;
					GameVariable variableByName9;
					int num19;
					int num20;
					switch (command.cmdtype)
					{
					case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
					{
						GameVariable variableByName8 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName8 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						List<string> list2 = new List<string>();
						c58e5b13ce653faa93234bb8e406d83e6(ref list2, roomname2, c5a1a94792ee68c127ca4e23531c9b032.c8c36b4ca0ce920efe7de82dba8b447cc);
						if (list2.Count > 0)
						{
							variableByName8.sString = list2[ce4ff3149cc29e541a54db79e809cbdbf.Next(0, list2.Count)];
						}
						else
						{
							variableByName8.sString = string.Empty;
						}
						break;
					}
					case Command.CommandType.CT_MM_GETRANDOMGROUP:
					{
						GameVariable variableByName3 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						List<string> list = new List<string>();
						c58e5b13ce653faa93234bb8e406d83e6(ref list, roomname2, c5a1a94792ee68c127ca4e23531c9b032.c157e191adcae76c450a8c82842c9666d);
						if (list.Count <= 0)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							variableByName3.sString = string.Empty;
						}
						else
						{
							variableByName3.sString = list[ce4ff3149cc29e541a54db79e809cbdbf.Next(0, list.Count)];
						}
						break;
					}
					case Command.CommandType.CT_Status_ItemVisibleInvisible:
					{
						IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.StatusBarItems.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								StatusBarItem statusBarItem = (StatusBarItem)enumerator.Current;
								if (string.Compare(statusBarItem.Name, roomname, ignoreCase: true) != 0)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									continue;
								}
								if (string.Compare(roomname2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6101), ignoreCase: true) != 0)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									statusBarItem.bVisisble = false;
								}
								else
								{
									statusBarItem.bVisisble = true;
								}
								break;
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable4))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable4.Dispose();
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYITEMDESC:
						if (!(roomname == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							GameObject gameObject2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject2 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, gameObject2.Display(ref c54f9a911545745b85ae6f74355697f8b.ObjectList), Color.Black, (FontStyle)0);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, P_1.Display(ref c54f9a911545745b85ae6f74355697f8b.ObjectList), Color.Black, (FontStyle)0);
						}
						break;
					case Command.CommandType.CT_LOOP_BREAK:
						return true;
					case Command.CommandType.CT_EXPORTVARIABLE:
					{
						((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6189);
						((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6222);
						GameVariable variableByName17 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName17 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if ((int)((CommonDialog)c0ac8afaf8508709341f33bd2b7335b6d).ShowDialog() != 1)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							try
							{
								StreamWriter streamWriter = new StreamWriter(((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).FileName);
								BinaryFormatter binaryFormatter2 = new BinaryFormatter();
								binaryFormatter2.Serialize(streamWriter.BaseStream, variableByName17);
								streamWriter.Close();
							}
							catch
							{
								MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6285));
							}
						}
						((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4706);
						break;
					}
					case Command.CommandType.CT_IMPORTVARIABLE:
					{
						((FileDialog)c1b2228b412e398e163667e2f04172de6).Title = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6346);
						string filter = ((FileDialog)c1b2228b412e398e163667e2f04172de6).Filter;
						((FileDialog)c1b2228b412e398e163667e2f04172de6).Filter = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6222);
						if ((int)((CommonDialog)c1b2228b412e398e163667e2f04172de6).ShowDialog() != 1)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							try
							{
								StreamReader streamReader = new StreamReader(((FileDialog)c1b2228b412e398e163667e2f04172de6).FileName);
								streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
								BinaryFormatter binaryFormatter = new BinaryFormatter();
								GameVariable gameVariable3 = (GameVariable)binaryFormatter.Deserialize(streamReader.BaseStream);
								streamReader.Close();
								GameVariable variableByName13 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(gameVariable3.varname);
								if (variableByName13 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									c54f9a911545745b85ae6f74355697f8b.VariableList.Remove(variableByName13);
								}
								c54f9a911545745b85ae6f74355697f8b.VariableList.Add(gameVariable3);
							}
							catch
							{
								MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6379));
							}
						}
						((FileDialog)c1b2228b412e398e163667e2f04172de6).Filter = filter;
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
					{
						GameVariable variableByName11 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName11 != null)
						{
							int num23 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
							int num24 = c9f91498283773f610332946230356cc8(roomname);
							if (num23 == -1)
							{
								variableByName11.dNumType = Convert.ToDouble(ce4ff3149cc29e541a54db79e809cbdbf.Next(Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMin, null))), Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMax, null))) + 1));
							}
							else if (num24 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								variableByName11.VarArray[num23] = Convert.ToDouble(ce4ff3149cc29e541a54db79e809cbdbf.Next(Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMin, null))), Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMax, null))) + 1));
							}
							else
							{
								((ArrayList)variableByName11.VarArray[num23])[num24] = ce4ff3149cc29e541a54db79e809cbdbf.Next(Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMin, null))), Convert.ToInt32(Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName11.dMax, null))) + 1).ToString();
							}
						}
						break;
					}
					case Command.CommandType.CT_CANCELMOVE:
						c51279ee02a1043fe19c2f931ed627109 = true;
						break;
					case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
					{
						string text48 = roomname;
						string[] array15 = text48.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action2 = null;
						if (array15.Length <= 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (array15.Length != 2)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								action2 = c7ad33b0f6a0935fd4394c957998fdb49(array15[0], "", array15[1]);
							}
						}
						else
						{
							action2 = c7ad33b0f6a0935fd4394c957998fdb49(array15[0], array15[1], array15[2]);
						}
						if (action2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							action2.CustomChoices.Clear();
						}
						break;
					}
					case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
					{
						string text52 = roomname;
						string[] array17 = text52.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action3 = null;
						if (array17.Length <= 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (array17.Length != 2)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								action3 = c7ad33b0f6a0935fd4394c957998fdb49(array17[0], "", array17[1]);
							}
						}
						else
						{
							action3 = c7ad33b0f6a0935fd4394c957998fdb49(array17[0], array17[1], array17[2]);
						}
						if (action3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						bool flag12 = false;
						{
							IEnumerator enumerator2 = action3.CustomChoices.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									string text53 = (string)enumerator2.Current;
									if (!text53.Equals(text))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									flag12 = true;
									break;
								}
							}
							finally
							{
								IDisposable disposable21 = enumerator2 as IDisposable;
								if (disposable21 != null)
								{
									disposable21.Dispose();
								}
							}
						}
						if (flag12)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							action3.CustomChoices.Add(text);
						}
						break;
					}
					case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
					{
						string text12 = roomname;
						string[] array4 = text12.Split(new char[1] { ':' }, StringSplitOptions.None);
						Action action = null;
						if (array4.Length > 2)
						{
							action = c7ad33b0f6a0935fd4394c957998fdb49(array4[0], array4[1], array4[2]);
						}
						else if (array4.Length == 2)
						{
							action = c7ad33b0f6a0935fd4394c957998fdb49(array4[0], "", array4[1]);
						}
						if (action == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							action.CustomChoices.Remove(text);
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERGENDER:
						c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname, ignoreCase: true);
						break;
					case Command.CommandType.CT_PAUSEGAME:
						c6896c15b2653af6fffd4ff8146d89e43 = false;
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6440), Color.Black, (FontStyle)1);
						c18553bcfcde941590af10fb86b3e5ce1();
						if (!c6896c15b2653af6fffd4ff8146d89e43)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						return false;
					case Command.CommandType.CT_LAYEREDIMAGE_ADD:
					{
						GamePicture gamePictureByName7 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname);
						if (gamePictureByName7 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						gamePictureByName7.LayeredImages.Add(roomname2);
						cd7d9d5d3b1feaff767ec5064a8968dd4();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
					{
						GamePicture gamePictureByName6 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname);
						if (gamePictureByName6 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						using (List<string>.Enumerator enumerator5 = gamePictureByName6.LayeredImages.GetEnumerator())
						{
							while (enumerator5.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								string current2 = enumerator5.Current;
								if (!(current2 == roomname2))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									continue;
								}
								gamePictureByName6.LayeredImages.Remove(current2);
								break;
							}
						}
						cd7d9d5d3b1feaff767ec5064a8968dd4();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
					{
						GamePicture gamePictureByName3 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname);
						GamePicture gamePictureByName4 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname3);
						if (gamePictureByName3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (gamePictureByName4 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						int num6 = -1;
						bool flag4 = false;
						using (List<string>.Enumerator enumerator5 = gamePictureByName3.LayeredImages.GetEnumerator())
						{
							while (enumerator5.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								string current = enumerator5.Current;
								num6++;
								if (current == roomname2)
								{
									flag4 = true;
									gamePictureByName3.LayeredImages.Remove(current);
									break;
								}
							}
						}
						if (!flag4)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						gamePictureByName3.LayeredImages.Insert(num6, roomname3);
						cd7d9d5d3b1feaff767ec5064a8968dd4();
						break;
					}
					case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
					{
						GamePicture gamePictureByName5 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname);
						if (gamePictureByName5 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						gamePictureByName5.LayeredImages.Clear();
						cd7d9d5d3b1feaff767ec5064a8968dd4();
						break;
					}
					case Command.CommandType.CT_SETPLAYERNAME:
						c54f9a911545745b85ae6f74355697f8b.ThePlayer.Name = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						break;
					case Command.CommandType.CT_DISPLAYPLAYERDESC:
					{
						string text23 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(c54f9a911545745b85ae6f74355697f8b.ThePlayer.Description, null);
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text23 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
					{
						GameObject gameObject15 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
						if (gameObject15 != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject15 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
						}
						if (gameObject15 == null)
						{
							break;
						}
						GameObject.LocationType locationtype2 = gameObject15.locationtype;
						string locationname = gameObject15.locationname;
						bool flag8 = true;
						string text34 = string.Empty;
						IEnumerator enumerator = gameObject15.LayeredZoneLevels.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								string text35 = (string)enumerator.Current;
								string[] array11 = text35.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
								{
									IEnumerator enumerator6 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
									try
									{
										while (enumerator6.MoveNext())
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											GameObject gameObject16 = (GameObject)enumerator6.Current;
											if (!gameObject16.bWorn || gameObject16.locationtype != locationtype2)
											{
												continue;
											}
											if (locationtype2 == GameObject.LocationType.LT_CHARACTER && locationname != gameObject16.locationname)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												continue;
											}
											IEnumerator enumerator4 = gameObject16.LayeredZoneLevels.GetEnumerator();
											try
											{
												while (enumerator4.MoveNext())
												{
													string text36 = (string)enumerator4.Current;
													string[] array12 = text36.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
													if (!(gameObject15.UniqueIdentifier != gameObject16.UniqueIdentifier))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														continue;
													}
													if (!(array12[0] == array11[0]))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														continue;
													}
													if (Convert.ToInt32(array12[1]) < Convert.ToInt32(array11[1]))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														continue;
													}
													flag8 = false;
													if (text34.IndexOf(gameObject15.GetDisplayStringNameOnly()) != -1)
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													}
													else if (!(text34 == string.Empty))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														text34 = text34 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6672) + gameObject16.GetDisplayStringNameOnly();
													}
													else if (locationtype2 == GameObject.LocationType.LT_CHARACTER)
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														string text20 = text34;
														text34 = text20 + locationname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6591) + gameObject15.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6622) + locationname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6629) + gameObject16.GetDisplayStringNameOnly();
													}
													else
													{
														string text20 = text34;
														text34 = text20 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6509) + gameObject15.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6546) + gameObject16.GetDisplayStringNameOnly();
													}
												}
											}
											finally
											{
												if (!(enumerator4 is IDisposable disposable11))
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												}
												else
												{
													disposable11.Dispose();
												}
											}
										}
									}
									finally
									{
										IDisposable disposable22 = enumerator6 as IDisposable;
										if (disposable22 != null)
										{
											disposable22.Dispose();
										}
									}
								}
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable12))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable12.Dispose();
							}
						}
						if (!flag8)
						{
							text34 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6683);
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text34 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							break;
						}
						if (locationtype2 == GameObject.LocationType.LT_CHARACTER)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, locationname = locationname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6732) + gameObject15.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6725), Color.Black, (FontStyle)0);
						}
						else
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6698) + gameObject15.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6725), Color.Black, (FontStyle)0);
						}
						gameObject15.bWorn = false;
						break;
					}
					case Command.CommandType.CT_ITEM_LAYERED_WEAR:
					{
						GameObject gameObject9 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
						if (gameObject9 != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject9 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
						}
						if (gameObject9 == null)
						{
							break;
						}
						GameObject.LocationType locationtype = gameObject9.locationtype;
						string text15 = gameObject9.locationname;
						bool flag2 = true;
						string text16 = string.Empty;
						{
							IEnumerator enumerator2 = gameObject9.LayeredZoneLevels.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									string text17 = (string)enumerator2.Current;
									string[] array5 = text17.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
									IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
									try
									{
										while (enumerator3.MoveNext())
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											GameObject gameObject10 = (GameObject)enumerator3.Current;
											if (!gameObject10.bWorn)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												continue;
											}
											if (gameObject10.locationtype != locationtype)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												continue;
											}
											IEnumerator enumerator4 = gameObject10.LayeredZoneLevels.GetEnumerator();
											try
											{
												while (enumerator4.MoveNext())
												{
													string text18 = (string)enumerator4.Current;
													string[] array6 = text18.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
													if (!(array6[0] == array5[0]))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													}
													else
													{
														if (Convert.ToInt32(array6[1]) < Convert.ToInt32(array5[1]))
														{
															continue;
														}
														if (locationtype != GameObject.LocationType.LT_CHARACTER)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														}
														else if (text15 != gameObject10.locationname)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															continue;
														}
														flag2 = false;
														if (text16.IndexOf(gameObject9.GetDisplayStringNameOnly()) != -1)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														}
														else if (text16 == string.Empty)
														{
															if (locationtype == GameObject.LocationType.LT_CHARACTER)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																string text19 = text16;
																string text20 = text15;
																text16 = text19 + (text15 = text20 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6843) + gameObject9.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6622) + text15 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6629) + gameObject10.GetDisplayStringNameOnly());
															}
															else
															{
																string text20 = text16;
																text16 = text20 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6755) + gameObject9.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6788) + gameObject10.GetDisplayStringNameOnly();
															}
														}
														else
														{
															text16 = text16 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6672) + gameObject10.GetDisplayStringNameOnly();
														}
													}
												}
											}
											finally
											{
												if (!(enumerator4 is IDisposable disposable6))
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												}
												else
												{
													disposable6.Dispose();
												}
											}
										}
									}
									finally
									{
										if (!(enumerator3 is IDisposable disposable7))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										}
										else
										{
											disposable7.Dispose();
										}
									}
								}
							}
							finally
							{
								IDisposable disposable23 = enumerator2 as IDisposable;
								if (disposable23 != null)
								{
									disposable23.Dispose();
								}
							}
						}
						if (!flag2)
						{
							text16 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6683);
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text16 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							break;
						}
						if (locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6870) + gameObject9.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6725), Color.Black, (FontStyle)0);
						}
						else
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text15 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6893) + gameObject9.GetDisplayStringNameOnly() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6725), Color.Black, (FontStyle)0);
						}
						gameObject9.bWorn = true;
						break;
					}
					case Command.CommandType.CT_DEBUGTEXT:
					{
						string[] commandLineArgs = Environment.GetCommandLineArgs();
						if (commandLineArgs.Length < 3)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!(commandLineArgs[2] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4890)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYTEXT:
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						break;
					case Command.CommandType.CT_ENDGAME:
					{
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						EndGameDialog endGameDialog = new EndGameDialog();
						DialogResult val15 = ((Form)endGameDialog).ShowDialog();
						if ((int)val15 != 6)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if ((int)val15 != 5)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								c54f9a911545745b85ae6f74355697f8b = null;
								c33da7cbe080e8167115ce842f845e11f = "";
								((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = false;
							}
							else
							{
								c54f9a911545745b85ae6f74355697f8b = null;
								c33da7cbe080e8167115ce842f845e11f = "";
								((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = false;
								c9cdd06ef68ce1d568947f5942b3eeb81(null, null);
							}
							break;
						}
						c58eb8f529a8b8e52b34a6d519eb0e31b = true;
						c51568856233bbe7fbfdbfcb47e3ae567();
						return false;
					}
					case Command.CommandType.CT_MOVEITEMTOINV:
					{
						GameObject gameObject6 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject6 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject6 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject6 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 != null)
						{
							gameObject6 = P_1;
						}
						if (gameObject6 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.bEnforceWeight)
						{
							double num3 = 0.0;
							IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									GameObject gameObject7 = (GameObject)enumerator.Current;
									if (gameObject7.locationtype == GameObject.LocationType.LT_PLAYER)
									{
										num3 += c54f9a911545745b85ae6f74355697f8b.GetItemWeight(gameObject7.UniqueIdentifier);
									}
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable2))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									disposable2.Dispose();
								}
							}
							num3 += c54f9a911545745b85ae6f74355697f8b.GetItemWeight(gameObject6.UniqueIdentifier);
							if (num3 > c54f9a911545745b85ae6f74355697f8b.ThePlayer.dWeightLimit)
							{
								MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6912) + gameObject6.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6921));
								return false;
							}
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						gameObject6.locationtype = GameObject.LocationType.LT_PLAYER;
						break;
					}
					case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
					{
						GameObject gameObject20 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject20 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject20 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject20 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject20 = P_1;
						}
						GameObject gameObject21 = null;
						if (!roomname2.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject21 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname2);
							if (gameObject21 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject21 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname2);
							}
						}
						else if (P_1 != null)
						{
							gameObject21 = P_1;
						}
						if (gameObject20 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							if (gameObject21 == null)
							{
								break;
							}
							IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									GameObject gameObject22 = (GameObject)enumerator.Current;
									if (gameObject22.locationtype != GameObject.LocationType.LT_IN_OBJECT)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else if (!(gameObject22.locationname == gameObject20.UniqueIdentifier.ToString()))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										gameObject22.locationname = gameObject21.UniqueIdentifier.ToString();
									}
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable14))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									disposable14.Dispose();
								}
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_VISIBILITY:
					{
						GameObject gameObject13 = null;
						if (roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							if (P_1 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject13 = P_1;
							}
						}
						else
						{
							gameObject13 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject13 == null)
							{
								gameObject13 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						if (gameObject13 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (!roomname2.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6101)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject13.bVisible = false;
						}
						else
						{
							gameObject13.bVisible = true;
						}
						cbc7ad2fc50dfbe4191690a255afd70e4();
						break;
					}
					case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
					{
						IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								GameObject gameObject14 = (GameObject)enumerator.Current;
								if (gameObject14.locationtype != GameObject.LocationType.LT_PLAYER)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									continue;
								}
								gameObject14.locationtype = GameObject.LocationType.LT_CHARACTER;
								gameObject14.locationname = roomname;
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable10))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable10.Dispose();
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVEINVENTORYTOROOM:
					{
						IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								GameObject gameObject8 = (GameObject)enumerator.Current;
								if (gameObject8.locationtype != GameObject.LocationType.LT_PLAYER)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (!(roomname == Room.CurrentRoomGuid.ToString()))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!(roomname == Room.VoidRoomGuid.ToString()))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										gameObject8.locationtype = GameObject.LocationType.LT_ROOM;
										gameObject8.locationname = roomname;
									}
									else
									{
										gameObject8.locationtype = GameObject.LocationType.LT_NULL;
									}
								}
								else
								{
									gameObject8.locationtype = GameObject.LocationType.LT_ROOM;
									gameObject8.locationname = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
								}
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable3))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable3.Dispose();
							}
						}
						break;
					}
					case Command.CommandType.CT_MOVECHARINVTOPLAYER:
					{
						Character character5 = null;
						character5 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (character5 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								GameObject gameObject26 = (GameObject)enumerator.Current;
								if (gameObject26.locationtype != GameObject.LocationType.LT_CHARACTER)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (!(gameObject26.locationname == character5.Charname))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (gameObject26.bCarryable)
								{
									if (!gameObject26.bVisible)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										gameObject26.locationtype = GameObject.LocationType.LT_PLAYER;
									}
								}
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable18))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable18.Dispose();
							}
						}
						break;
					}
					case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
					{
						Room room13 = null;
						if (!(roomname == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							room13 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						else
						{
							room13 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
						}
						if (room13 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								GameObject gameObject27 = (GameObject)enumerator.Current;
								if (gameObject27.locationtype != GameObject.LocationType.LT_ROOM)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (!(gameObject27.locationname == room13.UniqueID.ToString()))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (!gameObject27.bCarryable)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (!gameObject27.bVisible)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									gameObject27.locationtype = GameObject.LocationType.LT_PLAYER;
								}
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable19))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								disposable19.Dispose();
							}
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
						if (!(roomname == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							Room room2 = null;
							try
							{
								room2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
							}
							if (room2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, room2.Description + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
						}
						else
						{
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Description + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						}
						break;
					case Command.CommandType.CT_CHAR_DISPLAYPORT:
					{
						Character character3 = null;
						character3 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (character3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
							Clipboard.SetDataObject(c54f9a911545745b85ae6f74355697f8b.GetPictureByName(character3.CharPortrait));
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							break;
						}
						cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
						object pictureByName11 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(character3.CharPortrait);
						object obj26 = ((pictureByName11 is Image) ? pictureByName11 : null);
						Image val11 = (Image)((obj26 is Image) ? obj26 : null);
						if (val11 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (obj26 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
								c3d3f592020623bcd70bc7878559e94cb.URL = obj26 as string;
							}
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(character3.CharPortrait);
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = val11;
						}
						object pictureByName12 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(character3.CharPortrait);
						obj26 = ((pictureByName12 is Image) ? pictureByName12 : null);
						val11 = (Image)((obj26 is Image) ? obj26 : null);
						if (val11 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (obj26 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
							c3d3f592020623bcd70bc7878559e94cb.URL = obj26 as string;
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							cd431de8c0add2abbb6ebb8d63e4db3c0.Image = val11;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYROOMPICTURE:
					{
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (!c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
								Clipboard.SetDataObject(c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
							}
							if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
							{
								break;
							}
							cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
							object pictureByName5 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
							object obj7 = ((pictureByName5 is Image) ? pictureByName5 : null);
							Image val5 = (Image)((obj7 is Image) ? obj7 : null);
							if (val5 != null)
							{
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = val5;
							}
							else if (obj7 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
								c3d3f592020623bcd70bc7878559e94cb.URL = obj7 as string;
							}
							object pictureByName6 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.LayeredRoomPic);
							obj7 = ((pictureByName6 is Image) ? pictureByName6 : null);
							val5 = (Image)((obj7 is Image) ? obj7 : null);
							if (val5 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (obj7 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									break;
								}
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
								c3d3f592020623bcd70bc7878559e94cb.URL = obj7 as string;
							}
							else
							{
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic);
								cd431de8c0add2abbb6ebb8d63e4db3c0.Image = val5;
							}
							break;
						}
						Room room4 = null;
						try
						{
							room4 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room4 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (room4 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							if (!c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
								Clipboard.SetDataObject(c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.RoomPic));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
							}
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
						object pictureByName7 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room4.RoomPic);
						object obj9 = ((pictureByName7 is Image) ? pictureByName7 : null);
						Image val6 = (Image)((obj9 is Image) ? obj9 : null);
						if (val6 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (obj9 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
								((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
								c3d3f592020623bcd70bc7878559e94cb.URL = obj9 as string;
							}
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(room4.RoomPic);
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = val6;
						}
						object pictureByName8 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room4.LayeredRoomPic);
						obj9 = ((pictureByName8 is Image) ? pictureByName8 : null);
						val6 = (Image)((obj9 is Image) ? obj9 : null);
						if (val6 != null)
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							cd431de8c0add2abbb6ebb8d63e4db3c0.Image = val6;
						}
						else if (obj9 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
							c3d3f592020623bcd70bc7878559e94cb.URL = obj9 as string;
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOROOM:
					{
						GameObject gameObject12 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject12 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject12 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject12 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject12 = P_1;
						}
						if (gameObject12 == null)
						{
							break;
						}
						gameObject12.locationtype = GameObject.LocationType.LT_ROOM;
						if (!(roomname2 == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (!(roomname2 == Room.VoidRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								string text28 = string.Empty;
								try
								{
									new Guid(roomname2);
									text28 = roomname2;
								}
								catch
								{
									Room roomByName = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname2);
									if (roomByName == null)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										text28 = roomByName.UniqueID.ToString();
									}
								}
								if (!(text28 == string.Empty))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									gameObject12.locationname = text28;
								}
								else
								{
									MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7046) + roomname2);
								}
							}
							else
							{
								gameObject12.locationtype = GameObject.LocationType.LT_NULL;
							}
						}
						else
						{
							gameObject12.locationname = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
						}
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOOBJ:
					{
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							GameObject gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject5 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject5 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							string text9 = string.Empty;
							try
							{
								text9 = new Guid(roomname2).ToString();
							}
							catch
							{
								GameObject objectByNameOld = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname2);
								if (objectByNameOld != null)
								{
									text9 = objectByNameOld.UniqueIdentifier.ToString();
								}
							}
							if (!(text9 != string.Empty))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							gameObject5.locationtype = GameObject.LocationType.LT_IN_OBJECT;
							gameObject5.locationname = text9;
							break;
						}
						if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string text10 = string.Empty;
						try
						{
							text10 = new Guid(roomname2).ToString();
						}
						catch
						{
							GameObject objectByNameOld2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname2);
							if (objectByNameOld2 != null)
							{
								text10 = objectByNameOld2.UniqueIdentifier.ToString();
							}
						}
						if (!(text10 != string.Empty))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						P_1.locationtype = GameObject.LocationType.LT_IN_OBJECT;
						P_1.locationname = text10;
						break;
					}
					case Command.CommandType.CT_MOVEITEMTOCHAR:
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							GameObject gameObject3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject3 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject3 != null)
							{
								gameObject3.locationtype = GameObject.LocationType.LT_CHARACTER;
								gameObject3.locationname = roomname2;
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							P_1.locationtype = GameObject.LocationType.LT_CHARACTER;
							P_1.locationname = roomname2;
						}
						break;
					case Command.CommandType.CT_SETEXIT:
					{
						Room room12 = null;
						try
						{
							room12 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room12 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (room12 == null)
						{
							break;
						}
						int num16 = roomname2.IndexOf('-');
						string text44 = roomname2.Substring(0, num16);
						int num17 = roomname2.IndexOf('-', num16 + 1);
						string empty3 = string.Empty;
						if (num17 <= -1)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							empty3 = roomname2.Substring(num16 + 1);
						}
						else
						{
							empty3 = roomname2.Substring(num16 + 1, num17 - num16 - 1);
						}
						empty3 = empty3.Trim();
						bool bActive = false;
						if (!(empty3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							bActive = true;
						}
						for (int num18 = 0; num18 < room12.Exits.Count; num18++)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (((Exit)room12.Exits[num18]).Direction.ToString() == text44)
							{
								((Exit)room12.Exits[num18]).bActive = bActive;
								break;
							}
						}
						cfbd5c34adeba9b31c9a5ce3808226478();
						break;
					}
					case Command.CommandType.CT_SETEXITDESTINATION:
					{
						Room room5 = null;
						try
						{
							room5 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room5 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (room5 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						Exit exit = null;
						for (int l = 0; l < room5.Exits.Count; l++)
						{
							if (((Exit)room5.Exits[l]).Direction.ToString() == roomname2)
							{
								exit = (Exit)room5.Exits[l];
								break;
							}
						}
						if (exit == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!(roomname3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5499)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							Room room6 = null;
							try
							{
								room6 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname3));
							}
							catch
							{
								room6 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname3);
							}
							if (room6 != null)
							{
								exit.DestinationRoom = room6.UniqueID.ToString();
								exit.bActive = true;
							}
						}
						else
						{
							exit.DestinationRoom = string.Empty;
							exit.bActive = false;
						}
						cfbd5c34adeba9b31c9a5ce3808226478();
						break;
					}
					case Command.CommandType.CT_EXECUTETIMER:
					{
						bool flag3 = c0de09ca3f6d361fe93749ff7d9785d96;
						string text24 = c42664cfaca433d70304c4fb46fa7cceb;
						c0de09ca3f6d361fe93749ff7d9785d96 = true;
						c17c0ba435cecdc830fb1ba4c889283be = false;
						c42664cfaca433d70304c4fb46fa7cceb = string.Empty;
						Timer timerByName2 = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(roomname);
						if (timerByName2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							c42664cfaca433d70304c4fb46fa7cceb = timerByName2.Name;
							Action actionByName2 = timerByName2.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5407));
							if (actionByName2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								c9cff05a07825c588d9efb7028802a05f(ref actionByName2, null);
								while (c17c0ba435cecdc830fb1ba4c889283be)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									c17c0ba435cecdc830fb1ba4c889283be = false;
									c9cff05a07825c588d9efb7028802a05f(ref actionByName2, null);
								}
							}
						}
						c0de09ca3f6d361fe93749ff7d9785d96 = flag3;
						c42664cfaca433d70304c4fb46fa7cceb = text24;
						break;
					}
					case Command.CommandType.CT_RESETTIMER:
					{
						Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(roomname);
						if (timerByName == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						timerByName.TurnNumber = 0;
						if (!c0de09ca3f6d361fe93749ff7d9785d96)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							if (c42664cfaca433d70304c4fb46fa7cceb == timerByName.Name)
							{
								c17c0ba435cecdc830fb1ba4c889283be = true;
								return false;
							}
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						c17c0ba435cecdc830fb1ba4c889283be = false;
						return false;
					}
					case Command.CommandType.CT_SETTIMER:
					{
						Timer timerByName3 = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(roomname);
						if (timerByName3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (string.Compare(roomname2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184), ignoreCase: true) == 0)
						{
							timerByName3.Active = true;
						}
						else
						{
							timerByName3.Active = false;
						}
						break;
					}
					case Command.CommandType.CT_SETITEMDESC:
					{
						GameObject gameObject18 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject18 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject18 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject18 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject18 = P_1;
						}
						if (gameObject18 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject18.description = text;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERDESC:
						c54f9a911545745b85ae6f74355697f8b.ThePlayer.Description = text;
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
					{
						GameVariable variableByName4 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName4 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string[] array8 = roomname2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						string text26 = string.Empty;
						if (array8.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							string roomname4 = array8[0];
							string text27 = array8[1];
							Room room10 = null;
							room10 = ((!(roomname4 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7197))) ? c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname4) : c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom);
							if (room10 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								IEnumerator enumerator = room10.CustomProperties.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										CustomProperty customProperty5 = (CustomProperty)enumerator.Current;
										if (!(customProperty5.Name == text27))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										text26 = customProperty5.Value;
										break;
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable9))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										disposable9.Dispose();
									}
								}
							}
						}
						int num7 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num8 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName4.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num7 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num8 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName4.VarArray[num7] = text26;
								}
								else
								{
									((ArrayList)variableByName4.VarArray[num7])[num8] = text26;
								}
							}
							else
							{
								variableByName4.sString = text26;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num7 == -1)
								{
									variableByName4.dNumType = Convert.ToDouble(text26);
								}
								else if (num8 != -1)
								{
									((ArrayList)variableByName4.VarArray[num7])[num8] = text26;
								}
								else
								{
									variableByName4.VarArray[num7] = text26;
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 != null)
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7224) + text26 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE:
					{
						GameVariable variableByName2 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string[] array7 = roomname2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						string text21 = string.Empty;
						if (array7.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							string timername = array7[0];
							string text22 = array7[1];
							Timer timer = null;
							timer = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(timername);
							if (timer == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								IEnumerator enumerator = timer.CustomProperties.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										CustomProperty customProperty4 = (CustomProperty)enumerator.Current;
										if (!(customProperty4.Name == text22))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										text21 = customProperty4.Value;
										break;
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable8))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										disposable8.Dispose();
									}
								}
							}
						}
						int num4 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num5 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName2.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num4 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num5 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName2.VarArray[num4] = text21;
								}
								else
								{
									((ArrayList)variableByName2.VarArray[num4])[num5] = text21;
								}
							}
							else
							{
								variableByName2.sString = text21;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num4 == -1)
								{
									variableByName2.dNumType = Convert.ToDouble(text21);
								}
								else if (num5 != -1)
								{
									((ArrayList)variableByName2.VarArray[num4])[num5] = text21;
								}
								else
								{
									variableByName2.VarArray[num4] = text21;
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 != null)
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7362) + text21 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE:
					{
						GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string[] array3 = roomname2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						string text7 = string.Empty;
						if (array3.Length == 2)
						{
							string varname = array3[0];
							string text8 = array3[1];
							GameVariable gameVariable = null;
							gameVariable = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(varname);
							if (gameVariable == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								IEnumerator enumerator = gameVariable.CustomProperties.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										CustomProperty customProperty3 = (CustomProperty)enumerator.Current;
										if (!(customProperty3.Name == text8))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										text7 = customProperty3.Value;
										break;
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										disposable.Dispose();
									}
								}
							}
						}
						int num = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num2 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num2 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName.VarArray[num] = text7;
								}
								else
								{
									((ArrayList)variableByName.VarArray[num])[num2] = text7;
								}
							}
							else
							{
								variableByName.sString = text7;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num2 != -1)
									{
										((ArrayList)variableByName.VarArray[num])[num2] = text7;
									}
									else
									{
										variableByName.VarArray[num] = text7;
									}
								}
								else
								{
									variableByName.dNumType = Convert.ToDouble(text7);
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7455) + text7 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
						if (!(roomname == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7554)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							object pictureByName4 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
							Image val4 = (Image)((pictureByName4 is Image) ? pictureByName4 : null);
							if (val4 != null)
							{
								((Control)c5e74b6ad19335af023c0fb124e8b9948).BackgroundImage = val4;
							}
						}
						else
						{
							((Control)c5e74b6ad19335af023c0fb124e8b9948).BackgroundImage = (Image)(object)ce962106111336ae1961c57a8c1602a16._300px_Compass_Rose_English_North;
						}
						break;
					case Command.CommandType.CT_MM_SET_UD_COMPASS:
						if (!(roomname == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7554)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							object pictureByName17 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
							Image val18 = (Image)((pictureByName17 is Image) ? pictureByName17 : null);
							if (val18 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((Control)ca0822348910b5925d64c42ce17838058).BackgroundImage = val18;
							}
						}
						else
						{
							((Control)ca0822348910b5925d64c42ce17838058).BackgroundImage = (Image)(object)ce962106111336ae1961c57a8c1602a16._300px_Compass_Rose_UD;
						}
						break;
					case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
					{
						GameVariable variableByName14 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName14 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string[] array16 = roomname2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						string text50 = string.Empty;
						if (array16.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							string charname2 = array16[0];
							string text51 = array16[1];
							Character character4 = null;
							character4 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(charname2);
							if (character4 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								IEnumerator enumerator = character4.CustomProperties.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										CustomProperty customProperty11 = (CustomProperty)enumerator.Current;
										if (customProperty11.Name == text51)
										{
											text50 = customProperty11.Value;
											break;
										}
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable17))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										disposable17.Dispose();
									}
								}
							}
						}
						int num28 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num29 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName14.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num28 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num29 != -1)
								{
									((ArrayList)variableByName14.VarArray[num28])[num29] = text50;
								}
								else
								{
									variableByName14.VarArray[num28] = text50;
								}
							}
							else
							{
								variableByName14.sString = text50;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num28 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num29 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName14.VarArray[num28] = text50;
									}
									else
									{
										((ArrayList)variableByName14.VarArray[num28])[num29] = text50;
									}
								}
								else
								{
									variableByName14.dNumType = Convert.ToDouble(text50);
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7573) + text50 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE:
					{
						GameVariable variableByName10 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName10 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string[] array14 = roomname2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						string text45 = string.Empty;
						if (array14.Length == 2)
						{
							string text46 = array14[0];
							string text47 = array14[1];
							GameObject gameObject19 = null;
							if (!(text46 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7674)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								gameObject19 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(text46);
							}
							else if (P_1 != null)
							{
								gameObject19 = P_1;
							}
							if (gameObject19 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								IEnumerator enumerator = gameObject19.CustomProperties.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										CustomProperty customProperty10 = (CustomProperty)enumerator.Current;
										if (!(customProperty10.Name == text47))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										text45 = customProperty10.Value;
										break;
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable13))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										disposable13.Dispose();
									}
								}
							}
						}
						int num21 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num22 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName10.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num21 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num22 != -1)
								{
									((ArrayList)variableByName10.VarArray[num21])[num22] = text45;
								}
								else
								{
									variableByName10.VarArray[num21] = text45;
								}
							}
							else
							{
								variableByName10.sString = text45;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num21 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num22 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName10.VarArray[num21] = text45;
									}
									else
									{
										((ArrayList)variableByName10.VarArray[num21])[num22] = text45;
									}
								}
								else
								{
									variableByName10.dNumType = Convert.ToDouble(text45);
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7687) + text45 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE:
					{
						GameVariable variableByName7 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName7 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string text42 = string.Empty;
						string text43 = roomname2;
						foreach (CustomProperty customProperty13 in c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties)
						{
							if (customProperty13.Name == text43)
							{
								text42 = customProperty13.Value;
								break;
							}
						}
						int num14 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num15 = c9f91498283773f610332946230356cc8(roomname);
						c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						switch (variableByName7.vartype)
						{
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num14 == -1)
							{
								variableByName7.sString = text42;
							}
							else if (num15 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								variableByName7.VarArray[num14] = text42;
							}
							else
							{
								((ArrayList)variableByName7.VarArray[num14])[num15] = text42;
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							try
							{
								if (num14 == -1)
								{
									variableByName7.dNumType = Convert.ToDouble(text42);
								}
								else if (num15 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName7.VarArray[num14] = text42;
								}
								else
								{
									((ArrayList)variableByName7.VarArray[num14])[num15] = text42;
								}
							}
							catch
							{
								if (c45335acf471afc831c5b4bad4cbe5394 != null)
								{
									c45335acf471afc831c5b4bad4cbe5394.AddErrorData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7778) + text42 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7315));
								}
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							break;
						}
						break;
					}
					case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
					{
						string text37 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string[] array13 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						if (array13.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string roomname5 = array13[0];
						string text38 = array13[1];
						Room room11 = null;
						if (!(roomname5 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7197)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							room11 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname5);
						}
						else
						{
							room11 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
						}
						if (room11 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						for (int num11 = 0; num11 < room11.CustomProperties.Count; num11++)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							CustomProperty customProperty8 = room11.CustomProperties[num11] as CustomProperty;
							if (customProperty8 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (!(customProperty8.Name == text38))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (command.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
							{
								object result7 = null;
								MathEval.EvaluateString(ref result7, text37);
								text37 = result7.ToString();
							}
							c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty8, roomname2, text37);
							break;
						}
						break;
					}
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
					{
						string text29 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string[] array9 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						if (array9.Length != 2)
						{
							break;
						}
						string timername2 = array9[0];
						string text30 = array9[1];
						Timer timer2 = null;
						timer2 = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(timername2);
						if (timer2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						for (int m = 0; m < timer2.CustomProperties.Count; m++)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							CustomProperty customProperty6 = timer2.CustomProperties[m] as CustomProperty;
							if (customProperty6 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (!(customProperty6.Name == text30))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (command.cmdtype != Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								object result5 = null;
								MathEval.EvaluateString(ref result5, text29);
								text29 = result5.ToString();
							}
							c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty6, roomname2, text29);
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
					{
						string text31 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string[] array10 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						if (array10.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string varname2 = array10[0];
						string text32 = array10[1];
						GameVariable gameVariable2 = null;
						gameVariable2 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(varname2);
						if (gameVariable2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						for (int n = 0; n < gameVariable2.CustomProperties.Count; n++)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							CustomProperty customProperty7 = gameVariable2.CustomProperties[n] as CustomProperty;
							if (customProperty7 != null && customProperty7.Name == text32)
							{
								if (command.cmdtype == Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS)
								{
									object result6 = null;
									MathEval.EvaluateString(ref result6, text31);
									text31 = result6.ToString();
								}
								c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty7, roomname2, text31);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
					{
						string text4 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string[] array2 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						if (array2.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string text5 = array2[0];
						string text6 = array2[1];
						GameObject gameObject4 = null;
						if (text5 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7674))
						{
							if (P_1 != null)
							{
								gameObject4 = P_1;
							}
						}
						else
						{
							gameObject4 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(text5);
						}
						if (gameObject4 == null)
						{
							break;
						}
						for (int k = 0; k < gameObject4.CustomProperties.Count; k++)
						{
							CustomProperty customProperty2 = gameObject4.CustomProperties[k] as CustomProperty;
							if (customProperty2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (!(customProperty2.Name == text6))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								continue;
							}
							if (command.cmdtype != Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								object result3 = null;
								MathEval.EvaluateString(ref result3, text4);
								text4 = result3.ToString();
							}
							c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty2, roomname2, text4);
							break;
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
					{
						string text2 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string[] array = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
						if (array.Length != 2)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string charname = array[0];
						string text3 = array[1];
						Character character = null;
						character = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(charname);
						if (character == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						for (int j = 0; j < character.CustomProperties.Count; j++)
						{
							CustomProperty customProperty = character.CustomProperties[j] as CustomProperty;
							if (customProperty == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (customProperty.Name == text3)
							{
								if (command.cmdtype != Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									object result2 = null;
									MathEval.EvaluateString(ref result2, text2);
									text2 = result2.ToString();
								}
								c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty, roomname2, text2);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
					case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
					{
						string text54 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						string text55 = roomname;
						for (int num35 = 0; num35 < c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties.Count; num35++)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							CustomProperty customProperty12 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties[num35] as CustomProperty;
							if (customProperty12 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (customProperty12.Name == text55)
							{
								if (command.cmdtype == Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS)
								{
									object result9 = null;
									MathEval.EvaluateString(ref result9, text54);
									text54 = result9.ToString();
								}
								c10cb6d3e4bc0a01021a6db1ccdc4b004(ref customProperty12, roomname2, text54);
								break;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETVARIABLE:
					case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
					{
						bool flag10 = false;
						if (command.cmdtype != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							flag10 = true;
						}
						bool flag11 = false;
						int num25 = roomname.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7873));
						if (num25 <= -1)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							flag11 = true;
							roomname = roomname.Remove(num25, 6);
						}
						GameVariable variableByName12 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						if (variableByName12 == null)
						{
							break;
						}
						int num26 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num27 = c9f91498283773f610332946230356cc8(roomname);
						string text49 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
						text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text, null);
						object result8 = null;
						if (!flag10)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							MathEval.EvaluateString(ref result8, text49);
							if (flag11)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (result8 != null)
							{
								text49 = result8.ToString();
							}
						}
						switch (variableByName12.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7899))
								{
									if (num26 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num27 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName12.VarArray[num26] = ((DateTime)variableByName12.VarArray[num26]).AddDays(Convert.ToInt32(text49));
										}
										else
										{
											((ArrayList)variableByName12.VarArray[num26])[num27] = Convert.ToDateTime(((ArrayList)variableByName12.VarArray[num26])[num27]).AddDays(Convert.ToInt32(text49)).ToString();
										}
									}
									else
									{
										variableByName12.dtDateTime = variableByName12.dtDateTime.AddDays(Convert.ToInt32(text49));
									}
								}
								else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7916))
								{
									if (num26 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num27 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											ArrayList varArray = variableByName12.VarArray;
											object value = (variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49)));
											varArray[num26] = value;
										}
										else
										{
											((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49)).ToString();
										}
									}
									else
									{
										variableByName12.dtDateTime = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49));
									}
								}
								else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7935)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7958))
									{
										if (num26 != -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											if (num27 == -1)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49));
											}
											else
											{
												((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49)).ToString();
											}
										}
										else
										{
											variableByName12.dtDateTime = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49));
										}
									}
									else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7981)))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8008)))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8037))
											{
												if (num26 == -1)
												{
													variableByName12.dtDateTime = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49) * -1);
												}
												else if (num27 == -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49) * -1);
												}
												else
												{
													((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49) * -1).ToString();
												}
											}
											else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8070)))
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8103)))
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8142))
													{
														if (num26 != -1)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															if (num27 == -1)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																variableByName12.VarArray[num26] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, Convert.ToInt32(text49), variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second);
															}
															else
															{
																((ArrayList)variableByName12.VarArray[num26])[num27] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, Convert.ToInt32(text49), variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second).ToString();
															}
														}
														else
														{
															variableByName12.dtDateTime = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, Convert.ToInt32(text49), variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second);
														}
													}
													else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8167)))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8196)))
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														}
														else if (num26 != -1)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															if (num27 != -1)
															{
																((ArrayList)variableByName12.VarArray[num26])[num27] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, Convert.ToInt32(text49)).ToString();
															}
															else
															{
																variableByName12.VarArray[num26] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, Convert.ToInt32(text49));
															}
														}
														else
														{
															variableByName12.dtDateTime = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, Convert.ToInt32(text49));
														}
													}
													else if (num26 != -1)
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														if (num27 != -1)
														{
															((ArrayList)variableByName12.VarArray[num26])[num27] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, Convert.ToInt32(text49), variableByName12.dtDateTime.Second).ToString();
														}
														else
														{
															variableByName12.VarArray[num26] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, Convert.ToInt32(text49), variableByName12.dtDateTime.Second);
														}
													}
													else
													{
														variableByName12.dtDateTime = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, variableByName12.dtDateTime.Day, variableByName12.dtDateTime.Hour, Convert.ToInt32(text49), variableByName12.dtDateTime.Second);
													}
												}
												else if (num26 != -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													if (num27 == -1)
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														variableByName12.VarArray[num26] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, Convert.ToInt32(text49), variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second);
													}
													else
													{
														((ArrayList)variableByName12.VarArray[num26])[num27] = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, Convert.ToInt32(text49), variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second).ToString();
													}
												}
												else
												{
													variableByName12.dtDateTime = new DateTime(variableByName12.dtDateTime.Year, variableByName12.dtDateTime.Month, Convert.ToInt32(text49), variableByName12.dtDateTime.Hour, variableByName12.dtDateTime.Minute, variableByName12.dtDateTime.Second);
												}
											}
											else if (num26 != -1)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												if (num27 == -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49) * -1);
												}
												else
												{
													((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49) * -1).ToString();
												}
											}
											else
											{
												variableByName12.dtDateTime = variableByName12.dtDateTime.AddSeconds(Convert.ToInt32(text49) * -1);
											}
										}
										else if (num26 != -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											if (num27 == -1)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49) * -1);
											}
											else
											{
												((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49) * -1).ToString();
											}
										}
										else
										{
											variableByName12.dtDateTime = variableByName12.dtDateTime.AddHours(Convert.ToInt32(text49) * -1);
										}
									}
									else if (num26 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num27 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddDays(Convert.ToInt32(text49) * -1);
										}
										else
										{
											((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddDays(Convert.ToInt32(text49) * -1).ToString();
										}
									}
									else
									{
										variableByName12.dtDateTime = variableByName12.dtDateTime.AddDays(Convert.ToInt32(text49) * -1);
									}
								}
								else if (num26 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num27 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName12.VarArray[num26] = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49));
									}
									else
									{
										((ArrayList)variableByName12.VarArray[num26])[num27] = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49)).ToString();
									}
								}
								else
								{
									variableByName12.dtDateTime = variableByName12.dtDateTime.AddMinutes(Convert.ToInt32(text49));
								}
							}
							else if (!flag11)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num26 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num27 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName12.VarArray[num26] = Convert.ToDateTime(text49, Game.myDTFI);
									}
									else
									{
										((ArrayList)variableByName12.VarArray[num26])[num27] = text49;
									}
								}
								else
								{
									variableByName12.dtDateTime = Convert.ToDateTime(text49, Game.myDTFI);
								}
							}
							else
							{
								c6dfae8dbd6f9ecaabac6b01194846c4e(variableByName12, ref result8);
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8225))
								{
									if (num26 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num27 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName12.VarArray[num26] = (double)variableByName12.VarArray[num26] + Convert.ToDouble(text49);
										}
										else
										{
											((ArrayList)variableByName12.VarArray[num26])[num27] = (Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) + Convert.ToDouble(text49)).ToString();
										}
									}
									else
									{
										variableByName12.dNumType += Convert.ToDouble(text49);
									}
								}
								else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8232)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8249)))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8266))
										{
											if (num26 != -1)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												if (num27 == -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													variableByName12.VarArray[num26] = (double)variableByName12.VarArray[num26] / Convert.ToDouble(text49);
												}
												else
												{
													((ArrayList)variableByName12.VarArray[num26])[num27] = (Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) / Convert.ToDouble(text49)).ToString();
												}
											}
											else
											{
												variableByName12.dNumType /= Convert.ToDouble(text49);
											}
										}
									}
									else if (num26 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num27 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName12.VarArray[num26] = (double)variableByName12.VarArray[num26] * Convert.ToDouble(text49);
										}
										else
										{
											((ArrayList)variableByName12.VarArray[num26])[num27] = (Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) * Convert.ToDouble(text49)).ToString();
										}
									}
									else
									{
										variableByName12.dNumType *= Convert.ToDouble(text49);
									}
								}
								else if (num26 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num27 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName12.VarArray[num26] = (double)variableByName12.VarArray[num26] - Convert.ToDouble(text49);
									}
									else
									{
										((ArrayList)variableByName12.VarArray[num26])[num27] = (Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) - Convert.ToDouble(text49)).ToString();
									}
								}
								else
								{
									variableByName12.dNumType -= Convert.ToDouble(text49);
								}
							}
							else if (!flag11)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num26 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num27 != -1)
									{
										((ArrayList)variableByName12.VarArray[num26])[num27] = text49;
									}
									else
									{
										variableByName12.VarArray[num26] = Convert.ToDouble(text49);
									}
								}
								else
								{
									variableByName12.dNumType = Convert.ToDouble(text49);
								}
							}
							else
							{
								c6dfae8dbd6f9ecaabac6b01194846c4e(variableByName12, ref result8);
							}
							if (!variableByName12.bEnforceRestrictions)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (num26 == -1)
							{
								if (!(variableByName12.dNumType < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null))))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									variableByName12.dNumType = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null));
								}
								if (variableByName12.dNumType > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null)))
								{
									variableByName12.dNumType = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null));
								}
							}
							else if (num27 != -1)
							{
								if (Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null)))
								{
									((ArrayList)variableByName12.VarArray[num26])[num27] = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null).ToString();
								}
								if (!(Convert.ToDouble(((ArrayList)variableByName12.VarArray[num26])[num27]) > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null))))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									((ArrayList)variableByName12.VarArray[num26])[num27] = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null).ToString();
								}
							}
							else
							{
								if ((double)variableByName12.VarArray[num26] < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null)))
								{
									variableByName12.VarArray[num26] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMin, null));
								}
								if (!((double)variableByName12.VarArray[num26] > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null))))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									variableByName12.VarArray[num26] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName12.dMax, null));
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							if (!flag10)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								MathEval.EvaluateString(ref result8, text);
								if (flag11)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (result8 == null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									text = result8.ToString();
								}
							}
							if (!flag11)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num26 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num27 != -1)
									{
										((ArrayList)variableByName12.VarArray[num26])[num27] = text;
									}
									else
									{
										variableByName12.VarArray[num26] = text;
									}
								}
								else
								{
									variableByName12.sString = text;
								}
							}
							else
							{
								c6dfae8dbd6f9ecaabac6b01194846c4e(variableByName12, ref result8);
							}
							break;
						}
						break;
					}
					case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
					{
						GameVariable variableByName15 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						GameVariable variableByName16 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname3);
						int num30 = c835c6acbec36e979a142e0cab9dccbf2(roomname3);
						int num31 = c9f91498283773f610332946230356cc8(roomname3);
						int num32 = 0;
						double num33 = 0.0;
						if (num30 != -1)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (num31 != -1)
							{
								num32 = Convert.ToInt32(((ArrayList)variableByName16.VarArray[num30])[num31]);
								num33 = Convert.ToDouble(((ArrayList)variableByName16.VarArray[num30])[num31]);
							}
							else
							{
								num32 = Convert.ToInt32((double)variableByName16.VarArray[num30]);
								num33 = Convert.ToDouble((double)variableByName16.VarArray[num30]);
							}
						}
						else
						{
							num32 = Convert.ToInt32(variableByName16.dNumType);
							num33 = Convert.ToDouble(variableByName16.dNumType);
						}
						num30 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num34 = c9f91498283773f610332946230356cc8(roomname);
						if (variableByName15 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						switch (variableByName15.vartype)
						{
						case GameVariable.VarType.VT_DATETIME:
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886))
							{
								if (num30 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num34 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName15.VarArray[num30] = Convert.ToDateTime(num32, Game.myDTFI);
									}
									else
									{
										((ArrayList)variableByName15.VarArray[num30])[num34] = num32.ToString();
									}
								}
								else
								{
									variableByName15.dtDateTime = Convert.ToDateTime(num32, Game.myDTFI);
								}
							}
							else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7899)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7916)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7935)))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7958)))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7981)))
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8008)))
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8037)))
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8070))
														{
															if (num30 != -1)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																if (num34 == -1)
																{
																	__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																	variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32) * -1);
																}
																else
																{
																	((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32) * -1).ToString();
																}
															}
															else
															{
																variableByName15.dtDateTime = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32) * -1);
															}
														}
														else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8103))
														{
															if (num30 != -1)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																if (num34 == -1)
																{
																	__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																	variableByName15.VarArray[num30] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, Convert.ToInt32(num32), variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
																}
																else
																{
																	((ArrayList)variableByName15.VarArray[num30])[num34] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, Convert.ToInt32(num32), variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
																}
															}
															else
															{
																variableByName15.dtDateTime = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, Convert.ToInt32(num32), variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
															}
														}
														else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8142))
														{
															if (num30 != -1)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																if (num34 != -1)
																{
																	((ArrayList)variableByName15.VarArray[num30])[num34] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, Convert.ToInt32(num32), variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
																}
																else
																{
																	variableByName15.VarArray[num30] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, Convert.ToInt32(num32), variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
																}
															}
															else
															{
																variableByName15.dtDateTime = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, Convert.ToInt32(num32), variableByName15.dtDateTime.Minute, variableByName15.dtDateTime.Second);
															}
														}
														else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8167)))
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8196)))
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															}
															else if (num30 != -1)
															{
																__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																if (num34 == -1)
																{
																	__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
																	variableByName15.VarArray[num30] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, Convert.ToInt32(num32));
																}
																else
																{
																	((ArrayList)variableByName15.VarArray[num30])[num34] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, Convert.ToInt32(num32));
																}
															}
															else
															{
																variableByName15.dtDateTime = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, variableByName15.dtDateTime.Minute, Convert.ToInt32(num32));
															}
														}
														else if (num30 != -1)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															if (num34 != -1)
															{
																((ArrayList)variableByName15.VarArray[num30])[num34] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, Convert.ToInt32(num32), variableByName15.dtDateTime.Second);
															}
															else
															{
																variableByName15.VarArray[num30] = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, Convert.ToInt32(num32), variableByName15.dtDateTime.Second);
															}
														}
														else
														{
															variableByName15.dtDateTime = new DateTime(variableByName15.dtDateTime.Year, variableByName15.dtDateTime.Month, variableByName15.dtDateTime.Day, variableByName15.dtDateTime.Hour, Convert.ToInt32(num32), variableByName15.dtDateTime.Second);
														}
													}
													else if (num30 != -1)
													{
														__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
														if (num34 == -1)
														{
															__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
															variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32) * -1);
														}
														else
														{
															((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32) * -1).ToString();
														}
													}
													else
													{
														variableByName15.dtDateTime = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32) * -1);
													}
												}
												else if (num30 == -1)
												{
													variableByName15.dtDateTime = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32) * -1);
												}
												else if (num34 == -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32) * -1);
												}
												else
												{
													((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32) * -1).ToString();
												}
											}
											else if (num30 != -1)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												if (num34 == -1)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32) * -1);
												}
												else
												{
													((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32) * -1).ToString();
												}
											}
											else
											{
												variableByName15.dtDateTime = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32) * -1);
											}
										}
										else if (num30 != -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											if (num34 != -1)
											{
												((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32)).ToString();
											}
											else
											{
												variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32));
											}
										}
										else
										{
											variableByName15.dtDateTime = variableByName15.dtDateTime.AddSeconds(Convert.ToInt32(num32));
										}
									}
									else if (num30 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num34 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32));
										}
										else
										{
											((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32)).ToString();
										}
									}
									else
									{
										variableByName15.dtDateTime = variableByName15.dtDateTime.AddMinutes(Convert.ToInt32(num32));
									}
								}
								else if (num30 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num34 == -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32));
									}
									else
									{
										((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32)).ToString();
									}
								}
								else
								{
									variableByName15.dtDateTime = variableByName15.dtDateTime.AddHours(Convert.ToInt32(num32));
								}
							}
							else if (num30 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num34 != -1)
								{
									((ArrayList)variableByName15.VarArray[num30])[num34] = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32)).ToString();
								}
								else
								{
									variableByName15.VarArray[num30] = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32));
								}
							}
							else
							{
								variableByName15.dtDateTime = variableByName15.dtDateTime.AddDays(Convert.ToInt32(num32));
							}
							break;
						case GameVariable.VarType.VT_NUMBER:
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8225)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8232))
									{
										if (num30 == -1)
										{
											variableByName15.dNumType -= num33;
										}
										else if (num34 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName15.VarArray[num30] = (double)variableByName15.VarArray[num30] - num33;
										}
										else
										{
											((ArrayList)variableByName15.VarArray[num30])[num34] = (double)variableByName15.VarArray[num30] - num33;
										}
									}
									else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8249)))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8266))
										{
											if (num30 == -1)
											{
												variableByName15.dNumType /= Convert.ToDouble(num32);
											}
											else if (num34 != -1)
											{
												((ArrayList)variableByName15.VarArray[num30])[num34] = (double)variableByName15.VarArray[num30] / num33;
											}
											else
											{
												variableByName15.VarArray[num30] = (double)variableByName15.VarArray[num30] / num33;
											}
										}
									}
									else if (num30 != -1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										if (num34 == -1)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											variableByName15.VarArray[num30] = (double)variableByName15.VarArray[num30] * num33;
										}
										else
										{
											((ArrayList)variableByName15.VarArray[num30])[num34] = (double)variableByName15.VarArray[num30] * num33;
										}
									}
									else
									{
										variableByName15.dNumType *= Convert.ToDouble(num33);
									}
								}
								else if (num30 != -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (num34 != -1)
									{
										((ArrayList)variableByName15.VarArray[num30])[num34] = (double)variableByName15.VarArray[num30] + num33;
									}
									else
									{
										variableByName15.VarArray[num30] = (double)variableByName15.VarArray[num30] + num33;
									}
								}
								else
								{
									variableByName15.dNumType += num33;
								}
							}
							else if (num30 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num34 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName15.VarArray[num30] = num33;
								}
								else
								{
									((ArrayList)variableByName15.VarArray[num30])[num34] = num32.ToString();
								}
							}
							else
							{
								variableByName15.dNumType = num33;
							}
							if (!variableByName15.bEnforceRestrictions)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (num30 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num34 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!((double)variableByName15.VarArray[num30] < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null))))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										variableByName15.VarArray[num30] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null));
									}
									if (!((double)variableByName15.VarArray[num30] > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null))))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										variableByName15.VarArray[num30] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null));
									}
								}
								else
								{
									if (!((double)((ArrayList)variableByName15.VarArray[num30])[num34] < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null))))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										((ArrayList)variableByName15.VarArray[num30])[num34] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null));
									}
									if ((double)((ArrayList)variableByName15.VarArray[num30])[num34] > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null)))
									{
										((ArrayList)variableByName15.VarArray[num30])[num34] = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null));
									}
								}
							}
							else
							{
								if (variableByName15.dNumType < Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null)))
								{
									variableByName15.dNumType = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMin, null));
								}
								if (!(variableByName15.dNumType > Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null))))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									variableByName15.dNumType = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(variableByName15.dMax, null));
								}
							}
							break;
						case GameVariable.VarType.VT_STRING:
						case GameVariable.VarType.VT_STRINGARRAY:
							break;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYVARIABLE:
					{
						GameVariable variableByName6 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
						int num12 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
						int num13 = c9f91498283773f610332946230356cc8(roomname);
						if (variableByName6 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						switch (variableByName6.vartype)
						{
						case GameVariable.VarType.VT_DATETIMEARRAY:
							if (num12 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8279))
							{
								if (num13 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((DateTime)variableByName6.VarArray[num12]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(667), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((ArrayList)variableByName6.VarArray[num12])[num13].ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
							}
							else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8318))
							{
								if (num13 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((DateTime)variableByName6.VarArray[num12]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8353), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, Convert.ToDateTime(((ArrayList)variableByName6.VarArray[num12])[num13]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8353), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
							}
							else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8392)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8450)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else if (num13 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((DateTime)variableByName6.VarArray[num12]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8491), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
								else
								{
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, Convert.ToDateTime(((ArrayList)variableByName6.VarArray[num12])[num13]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8491), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
							}
							else if (num13 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((DateTime)variableByName6.VarArray[num12]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8427), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, Convert.ToDateTime(((ArrayList)variableByName6.VarArray[num12])[num13]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8427), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							break;
						case GameVariable.VarType.VT_DATETIME:
							if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8279))
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(667), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8318)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8392))
								{
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8427), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
								else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8450)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8491), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8353), Game.myDTFI) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							break;
						case GameVariable.VarType.VT_NUMBERARRAY:
							if (num12 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							if (num13 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, (double)variableByName6.VarArray[num12] + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((ArrayList)variableByName6.VarArray[num12])[num13].ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Select(((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text.Length, 0);
							((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Focus();
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ScrollToCaret();
							break;
						case GameVariable.VarType.VT_NUMBER:
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.dNumType + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Select(((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text.Length, 0);
							((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Focus();
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ScrollToCaret();
							break;
						case GameVariable.VarType.VT_STRINGARRAY:
							if (num12 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							if (num13 == -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.VarArray[num12].ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							else
							{
								TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, ((ArrayList)variableByName6.VarArray[num12])[num13].ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							}
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Select(((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text.Length, 0);
							((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Focus();
							break;
						case GameVariable.VarType.VT_STRING:
							TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, variableByName6.sString + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Select(((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text.Length, 0);
							((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Focus();
							((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ScrollToCaret();
							break;
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SETPORT:
					{
						Character character2 = null;
						character2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (character2 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							character2.CharPortrait = roomname2;
						}
						break;
					}
					case Command.CommandType.CT_SETROOMPIC:
					{
						Room room7 = null;
						if (!(roomname == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							try
							{
								room7 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room7 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
							}
						}
						else
						{
							room7 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
						}
						if (room7 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						room7.RoomPic = roomname2;
						if (room7 != c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							if (!c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
								Clipboard.SetDataObject(c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room7.RoomPic));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
							}
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(room7.RoomPic);
						PictureBox val7 = cd431de8c0add2abbb6ebb8d63e4db3c0;
						object pictureByName9 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room7.RoomPic);
						((Control)val7).BackgroundImage = (Image)((pictureByName9 is Image) ? pictureByName9 : null);
						PictureBox val8 = cd431de8c0add2abbb6ebb8d63e4db3c0;
						object pictureByName10 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room7.LayeredRoomPic);
						val8.Image = (Image)((pictureByName10 is Image) ? pictureByName10 : null);
						break;
					}
					case Command.CommandType.CT_SETROOMLAYEREDPIC:
					{
						Room room = null;
						if (!(roomname == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							try
							{
								room = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
							}
						}
						else
						{
							room = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
						}
						if (room == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5499)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							roomname2 = "";
						}
						room.LayeredRoomPic = roomname2;
						if (room != c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							_ = c54f9a911545745b85ae6f74355697f8b.bUseInlineImages;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(room.RoomPic);
						PictureBox val = cd431de8c0add2abbb6ebb8d63e4db3c0;
						object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room.RoomPic);
						((Control)val).BackgroundImage = (Image)((pictureByName is Image) ? pictureByName : null);
						PictureBox val2 = cd431de8c0add2abbb6ebb8d63e4db3c0;
						object pictureByName2 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room.LayeredRoomPic);
						val2.Image = (Image)((pictureByName2 is Image) ? pictureByName2 : null);
						PictureBox val3 = c0970743bbfbc89b095632fb02680fc3b;
						object pictureByName3 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(room.LayeredRoomPic);
						val3.Image = (Image)((pictureByName3 is Image) ? pictureByName3 : null);
						break;
					}
					case Command.CommandType.CT_SETPLAYERPORTRAIT:
						c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait = roomname;
						cd1b65fe2bdd9970fe28973afcd9bb52e(roomname, false);
						break;
					case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
						if (roomname == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5499))
						{
							roomname = "";
						}
						c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerLayeredImage = roomname;
						cd1b65fe2bdd9970fe28973afcd9bb52e(roomname, true);
						break;
					case Command.CommandType.CT_DISPLAYPICTURE:
					{
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							if (!c54f9a911545745b85ae6f74355697f8b.bUseInlineImages)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = false;
								Clipboard.SetDataObject(c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Paste();
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).AppendText(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143));
								((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ReadOnly = true;
							}
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						cd431de8c0add2abbb6ebb8d63e4db3c0.Image = null;
						object pictureByName15 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
						Image val16 = (Image)((pictureByName15 is Image) ? pictureByName15 : null);
						if (val16 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = false;
							c3d3f592020623bcd70bc7878559e94cb.URL = pictureByName15 as string;
						}
						else
						{
							((Control)c3d3f592020623bcd70bc7878559e94cb).Visible = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Visible = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(roomname);
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = val16;
						}
						break;
					}
					case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
					{
						object pictureByName16 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
						Image val17 = (Image)((pictureByName16 is Image) ? pictureByName16 : null);
						if (val17 != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						cc925b40132dfc5cb256f0913d0b3c35d(c5722e0b047bf80ee8a41d6d5ca3a5b06);
						c5722e0b047bf80ee8a41d6d5ca3a5b06.URL = pictureByName16 as string;
						break;
					}
					case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
						cc925b40132dfc5cb256f0913d0b3c35d(c5722e0b047bf80ee8a41d6d5ca3a5b06);
						c5722e0b047bf80ee8a41d6d5ca3a5b06.Ctlcontrols.stop();
						break;
					case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
					{
						object pictureByName14 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
						Image val14 = (Image)((pictureByName14 is Image) ? pictureByName14 : null);
						if (val14 != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							c4ed91464b45bf1f77c5ea95b0e4422c2.URL = pictureByName14 as string;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
					{
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							_ = c54f9a911545745b85ae6f74355697f8b.bUseInlineImages;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						PictureBox val13 = cd431de8c0add2abbb6ebb8d63e4db3c0;
						object pictureByName13 = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(roomname);
						val13.Image = (Image)((pictureByName13 is Image) ? pictureByName13 : null);
						break;
					}
					case Command.CommandType.CT_SETOBJECTACTION:
					{
						GameObject gameObject17 = null;
						if (!(roomname == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject17 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject17 != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject17 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 != null)
						{
							gameObject17 = P_1;
						}
						if (gameObject17 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string actionname4 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text41 = roomname2.Substring(roomname2.LastIndexOf('-') + 1);
						Action actionByName8 = gameObject17.GetActionByName(actionname4);
						if (actionByName8 != null)
						{
							if (text41 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184))
							{
								actionByName8.bActive = true;
							}
							else
							{
								actionByName8.bActive = false;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETCHARACTION:
					{
						Character characterByName4 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (characterByName4 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string actionname3 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text39 = roomname2.Substring(roomname2.LastIndexOf('-') + 1);
						Action actionByName4 = characterByName4.GetActionByName(actionname3);
						if (actionByName4 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!(text39 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							actionByName4.bActive = false;
						}
						else
						{
							actionByName4.bActive = true;
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_GENDER:
					{
						Character characterByName6 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (characterByName6 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							characterByName6.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname2);
						}
						break;
					}
					case Command.CommandType.CT_CHAR_SET_NAME:
					{
						Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (characterByName == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							characterByName.CharnameOverride = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
					{
						Room room9 = null;
						try
						{
							room9 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room9 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (room9 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							room9.SDesc = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
					{
						GameObject gameObject11 = null;
						try
						{
							new Guid(roomname);
							gameObject11 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
						}
						catch
						{
							gameObject11 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
						}
						if (gameObject11 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject11.sdesc = roomname3;
						}
						break;
					}
					case Command.CommandType.CT_SETPLAYERACTION:
					{
						if (c54f9a911545745b85ae6f74355697f8b.ThePlayer == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						string actionname2 = roomname2.Substring(0, roomname2.LastIndexOf('-'));
						string text25 = roomname2.Substring(roomname2.LastIndexOf('-') + 1);
						Action actionByName3 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.GetActionByName(actionname2);
						if (actionByName3 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!(text25 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							actionByName3.bActive = false;
						}
						else
						{
							actionByName3.bActive = true;
						}
						break;
					}
					case Command.CommandType.CT_SETROOMACTION:
					{
						Room room3 = null;
						try
						{
							room3 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							room3 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (room3 != null)
						{
							string actionname = roomname2.Substring(0, roomname2.LastIndexOf('-'));
							string text11 = roomname2.Substring(roomname2.LastIndexOf('-') + 1);
							Action actionByName = room3.GetActionByName(actionname);
							if (actionByName == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (!(text11 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7184)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								actionByName.bActive = false;
							}
							else
							{
								actionByName.bActive = true;
							}
						}
						break;
					}
					case Command.CommandType.CT_SETLOCKEDUNLOCKED:
					{
						GameObject gameObject = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject != null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 != null)
						{
							gameObject = P_1;
						}
						if (gameObject == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8500))
						{
							gameObject.bLocked = true;
						}
						else
						{
							gameObject.bLocked = false;
						}
						break;
					}
					case Command.CommandType.CT_SETOPENCLOSED:
					{
						GameObject gameObject28 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject28 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject28 == null)
							{
								gameObject28 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject28 = P_1;
						}
						if (gameObject28 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8513)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject28.bOpen = false;
						}
						else
						{
							gameObject28.bOpen = true;
						}
						break;
					}
					case Command.CommandType.CT_SETITEMTOWORN:
					{
						GameObject gameObject25 = null;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6116)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							gameObject25 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject25 == null)
							{
								gameObject25 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
						}
						else if (P_1 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gameObject25 = P_1;
						}
						if (gameObject25 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8522))
						{
							gameObject25.bWorn = true;
						}
						else
						{
							gameObject25.bWorn = false;
						}
						break;
					}
					case Command.CommandType.CT_DISPLAYCHARDESC:
					{
						Character characterByName7 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, characterByName7.Description + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
						bool flag9 = false;
						if (c54f9a911545745b85ae6f74355697f8b.bTurnOffNotifications)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									GameObject gameObject23 = (GameObject)enumerator.Current;
									if (gameObject23.locationtype != GameObject.LocationType.LT_CHARACTER)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										if (!(gameObject23.locationname == roomname))
										{
											continue;
										}
										if (!gameObject23.bWorn)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										if (!gameObject23.bVisible)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											continue;
										}
										if (!flag9)
										{
											flag9 = true;
											TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, characterByName7.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8531), Color.Black, (FontStyle)0);
										}
										TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, gameObject23.GetDisplayString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
									}
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable15))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									disposable15.Dispose();
								}
							}
							flag9 = false;
							enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									GameObject gameObject24 = (GameObject)enumerator.Current;
									if (gameObject24.locationtype != GameObject.LocationType.LT_CHARACTER)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									if (!(gameObject24.locationname == roomname))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									if (gameObject24.bWorn)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									if (!gameObject24.bVisible)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									if (flag9)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										flag9 = true;
										TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, characterByName7.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8560), Color.Black, (FontStyle)0);
									}
									TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, gameObject24.GetDisplayString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)0);
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable16))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									disposable16.Dispose();
								}
							}
						}
						((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).Select(((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Text.Length, 0);
						((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Focus();
						((TextBoxBase)c00ef783f3ec99f0de8db7e2bfe179e24).ScrollToCaret();
						break;
					}
					case Command.CommandType.CT_MOVECHAR:
					{
						Character characterByName5 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
						if (!(characterByName5.CurrentRoom == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							Action actionByName5 = characterByName5.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8591));
							if (actionByName5 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								c9cff05a07825c588d9efb7028802a05f(ref actionByName5, null);
							}
						}
						string text40 = string.Empty;
						try
						{
							new Guid(roomname2);
							text40 = roomname2;
						}
						catch
						{
							Room roomByName2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname2);
							if (roomByName2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								text40 = roomByName2.UniqueID.ToString();
								roomname2 = text40;
							}
						}
						if (!(roomname2 == Room.CurrentRoomGuid.ToString()))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (!(roomname2 == Room.VoidRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								try
								{
									new Guid(roomname2);
									text40 = roomname2;
								}
								catch
								{
									Room roomByName3 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname2);
									if (roomByName3 == null)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										text40 = roomByName3.UniqueID.ToString();
									}
								}
								if (text40 == string.Empty)
								{
									MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8681) + roomname2);
									break;
								}
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname).CurrentRoom = text40;
								if (!(roomname2 == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									Action actionByName6 = characterByName5.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8636));
									if (actionByName6 == null)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										c9cff05a07825c588d9efb7028802a05f(ref actionByName6, null);
									}
								}
							}
							else
							{
								c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname).CurrentRoom = Room.VoidRoomGuid.ToString();
							}
						}
						else
						{
							characterByName5.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
							Action actionByName7 = characterByName5.GetActionByName(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8636));
							if (actionByName7 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								c9cff05a07825c588d9efb7028802a05f(ref actionByName7, null);
							}
						}
						cdb7eb588a870d047a196c0b2bc01bfdf();
						break;
					}
					case Command.CommandType.CT_MOVEPLAYER:
						try
						{
							c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
						}
						catch
						{
							c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
						}
						if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom != null)
						{
							c6df55a7ba938a3b24d6b7592b94240ea(false, true);
						}
						break;
					case Command.CommandType.CT_MOVETOCHAR:
						try
						{
							Character characterByName3 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
							if (characterByName3 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							if (!(characterByName3.CurrentRoom != Room.VoidRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (!(characterByName3.CurrentRoom != Room.CurrentRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(characterByName3.CurrentRoom));
							}
							if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom != null)
							{
								c6df55a7ba938a3b24d6b7592b94240ea(false, true);
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_MOVETOOBJ:
						try
						{
							GameObject objectByName2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (objectByName2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							if (objectByName2.locationtype != GameObject.LocationType.LT_ROOM)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(objectByName2.locationname));
							}
							if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom != null)
							{
								c6df55a7ba938a3b24d6b7592b94240ea(false, true);
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_CHAR_MOVETOOBJ:
						try
						{
							Character characterByName2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
							GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname2);
							if (objectByName == null)
							{
								break;
							}
							if (characterByName2 == null)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								break;
							}
							if (objectByName.locationtype != GameObject.LocationType.LT_ROOM)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								characterByName2.CurrentRoom = objectByName.locationname;
							}
							if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString() == objectByName.locationname)
							{
								c6df55a7ba938a3b24d6b7592b94240ea(false, false);
							}
						}
						catch
						{
						}
						break;
					case Command.CommandType.CT_SETCHARDESC:
						c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname).Description = text;
						break;
					case Command.CommandType.CT_SETROOMDESCRIPTION:
					{
						Room room8 = null;
						if (roomname == Room.CurrentRoomGuid.ToString())
						{
							room8 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
						}
						else
						{
							try
							{
								room8 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room8 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
							}
						}
						if (room8 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							room8.Description = text;
						}
						break;
					}
					case Command.CommandType.CT_JAVA_SET_RAGS:
					{
						text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text, null);
						object result4 = null;
						MathEval.EvaluateString(ref result4, text);
						ce5ac6e913be5c22ddb4dc7fbbba1c9f0(ref result4);
						break;
					}
					case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
						additionalInputFrm2 = null;
						actionInputType2 = Action.ActionInputType.None;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8806)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8815)))
							{
								actionInputType2 = Action.ActionInputType.Custom;
							}
						}
						else
						{
							actionInputType2 = Action.ActionInputType.Text;
						}
						if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (command.EnhInputData.bUseEnhancedGraphics)
						{
							GamePicture gamePicture7 = new GamePicture();
							gamePicture7.enhinputdata = command.EnhInputData;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePicture7;
							goto IL_92b4;
						}
						if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture gamePicture8)
						{
							gamePicture8.enhinputdata = command.EnhInputData;
						}
						goto IL_92b4;
					case Command.CommandType.CT_SETVARIABLEBYINPUT:
						additionalInputFrm = null;
						actionInputType = Action.ActionInputType.None;
						if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8806)))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							if (roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8935)))
							{
								actionInputType = Action.ActionInputType.Character;
							}
							else if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8956)))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9001)))
								{
									actionInputType = Action.ActionInputType.Object;
								}
								else if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8815)))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9016)))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										actionInputType = Action.ActionInputType.Inventory;
									}
								}
								else
								{
									actionInputType = Action.ActionInputType.Custom;
								}
							}
							else
							{
								actionInputType = Action.ActionInputType.ObjectOrCharacter;
							}
						}
						else
						{
							actionInputType = Action.ActionInputType.Text;
						}
						if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag != null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (command.EnhInputData.bUseEnhancedGraphics)
						{
							GamePicture gamePicture = new GamePicture();
							gamePicture.enhinputdata = command.EnhInputData;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePicture;
							goto IL_9dec;
						}
						if (!(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture gamePicture2))
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							gamePicture2.enhinputdata = command.EnhInputData;
						}
						goto IL_9dec;
					case Command.CommandType.CT_COMMENT:
						break;
						IL_9dec:
						flag = false;
						if (actionInputType == Action.ActionInputType.Custom)
						{
							if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag != null && ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture)
							{
								if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									if (command.EnhInputData.bUseEnhancedGraphics)
									{
										flag = true;
										GamePicture gamePicture3 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
										if (!(gamePicture3.enhinputdata.NewImage == string.Empty))
										{
											if (gamePicture3.enhinputdata.NewImage == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8828))
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											}
											else
											{
												cd431de8c0add2abbb6ebb8d63e4db3c0.Image = (Image)c54f9a911545745b85ae6f74355697f8b.GetPictureByName(gamePicture3.enhinputdata.NewImage);
												GamePicture gamePictureByName = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(gamePicture3.enhinputdata.NewImage);
												if (gamePictureByName == null)
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
												}
												else
												{
													((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = gamePictureByName.GetTheImage();
													gamePictureByName.enhinputdata = command.EnhInputData;
													gamePictureByName.Choices = gamePicture3.Choices;
													((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePictureByName;
												}
											}
										}
										gamePicture3.Choices.Clear();
										if (!(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null) != string.Empty))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											gamePicture3.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1478));
										}
										else
										{
											gamePicture3.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null));
										}
										{
											IEnumerator enumerator2 = command.CustomChoices.GetEnumerator();
											try
											{
												while (enumerator2.MoveNext())
												{
													__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
													string text13 = (string)enumerator2.Current;
													gamePicture3.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text13, null));
												}
											}
											finally
											{
												IDisposable disposable24 = enumerator2 as IDisposable;
												if (disposable24 != null)
												{
													disposable24.Dispose();
												}
											}
										}
										if (gamePicture3.enhinputdata.bAllowCancel)
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										}
										else if (gamePicture3.Choices.Count > 1)
										{
											goto IL_a388;
										}
										gamePicture3.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153));
										goto IL_a388;
									}
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
							}
							ListBox inv = new ListBox();
							IEnumerator enumerator = command.CustomChoices.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									string text14 = (string)enumerator.Current;
									inv.Items.Add((object)c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text14, null));
								}
							}
							finally
							{
								if (!(enumerator is IDisposable disposable5))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								}
								else
								{
									disposable5.Dispose();
								}
							}
							additionalInputFrm = new AdditionalInputFrm(actionInputType, ref inv, ref lbRoomObjects, ref lbCharacters);
						}
						else
						{
							if (!command.EnhInputData.bUseEnhancedGraphics)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								if (actionInputType != Action.ActionInputType.Text)
								{
									flag = true;
									GamePicture gamePicture4 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
									if (gamePicture4.enhinputdata.NewImage == string.Empty)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else if (gamePicture4.enhinputdata.NewImage == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8828))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										cd431de8c0add2abbb6ebb8d63e4db3c0.Image = (Image)c54f9a911545745b85ae6f74355697f8b.GetPictureByName(gamePicture4.enhinputdata.NewImage);
										GamePicture gamePictureByName2 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(gamePicture4.enhinputdata.NewImage);
										if (gamePictureByName2 != null)
										{
											((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = gamePictureByName2.GetTheImage();
											gamePictureByName2.enhinputdata = command.EnhInputData;
											gamePictureByName2.Choices = gamePicture4.Choices;
											((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePictureByName2;
										}
									}
									gamePicture4.Choices.Clear();
									if (c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null) != string.Empty)
									{
										gamePicture4.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null));
									}
									else
									{
										gamePicture4.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9035));
									}
									c084bed40766f8f61e8a9ffb3ea35855e(actionInputType, ref gamePicture4.Choices);
									if (gamePicture4.enhinputdata.bAllowCancel)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else if (gamePicture4.Choices.Count > 1)
									{
										goto IL_a388;
									}
									gamePicture4.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153));
									goto IL_a388;
								}
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							additionalInputFrm = new AdditionalInputFrm(actionInputType, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
						}
						goto IL_a388;
						IL_962a:
						if (additionalInputFrm2 != null)
						{
							((Control)additionalInputFrm2.lblTitle).Text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
							((Control)additionalInputFrm2.btnCancel).Enabled = command.EnhInputData.bAllowCancel;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							((Form)additionalInputFrm2).StartPosition = (FormStartPosition)4;
							bool flag5 = false;
							while (!flag5)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								DialogResult val9 = ((Form)additionalInputFrm2).ShowDialog();
								string text33 = ((Control)additionalInputFrm2.txtInput).Text;
								if ((int)val9 == 4)
								{
									val9 = ((Form)additionalInputFrm2).ShowDialog();
								}
								if ((int)val9 == 1)
								{
									try
									{
										Convert.ToDouble(text33);
										flag5 = true;
									}
									catch
									{
										MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8847));
										flag5 = false;
									}
								}
								else if ((int)val9 != 1)
								{
									return false;
								}
							}
						}
						else if (flag6)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							c71f1ffa88f78e31ebea8163f6c76f6a8 = null;
							((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
							((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = false;
							((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
							while (c71f1ffa88f78e31ebea8163f6c76f6a8 == null)
							{
								Application.DoEvents();
								Thread.Sleep(0);
							}
							GamePicture gamePicture5 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
							gamePicture5.Choices.Clear();
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
							((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
							((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = true;
							((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = true;
							if (c71f1ffa88f78e31ebea8163f6c76f6a8.ToString().ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8922))
							{
								return false;
							}
						}
						else
						{
							((Control)additionalInputFrm2).Width = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Width;
							((Control)additionalInputFrm2).Height = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Height;
							((Form)additionalInputFrm2).Location = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).PointToScreen(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Location);
							bool flag7 = false;
							while (!flag7)
							{
								DialogResult val10 = ((Form)additionalInputFrm2).ShowDialog((IWin32Window)(object)cd431de8c0add2abbb6ebb8d63e4db3c0);
								string empty = string.Empty;
								if (actionInputType2 != Action.ActionInputType.Custom)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									empty = ((Control)additionalInputFrm2.txtInput).Text;
								}
								else
								{
									empty = additionalInputFrm2.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
								}
								if ((int)val10 == 4)
								{
									val10 = ((Form)additionalInputFrm2).ShowDialog((IWin32Window)(object)cd431de8c0add2abbb6ebb8d63e4db3c0);
								}
								if ((int)val10 != 1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if ((int)val10 == 1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										continue;
									}
									return false;
								}
								try
								{
									Convert.ToDouble(empty);
									flag7 = true;
								}
								catch
								{
									MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8847));
									flag7 = false;
								}
							}
						}
						variableByName5 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname2);
						num9 = c835c6acbec36e979a142e0cab9dccbf2(roomname2);
						num10 = c9f91498283773f610332946230356cc8(roomname2);
						if (variableByName5 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						switch (actionInputType2)
						{
						case Action.ActionInputType.Custom:
						{
							string empty2 = string.Empty;
							if (!flag6)
							{
								empty2 = additionalInputFrm2.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
							}
							else if (!(c71f1ffa88f78e31ebea8163f6c76f6a8 is GameObject))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (!(c71f1ffa88f78e31ebea8163f6c76f6a8 is Character))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									empty2 = c71f1ffa88f78e31ebea8163f6c76f6a8.ToString();
								}
								else
								{
									empty2 = ((Character)c71f1ffa88f78e31ebea8163f6c76f6a8).Charname;
								}
							}
							else
							{
								empty2 = ((GameObject)c71f1ffa88f78e31ebea8163f6c76f6a8).name;
							}
							variableByName5.sString = string.Empty;
							if (!(empty2 != string.Empty))
							{
								break;
							}
							if (num9 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num10 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName5.VarArray[num9] = string.Empty;
									variableByName5.VarArray[num9] = c46bd9b8fde1a25f614f930b648557a08(variableByName5, empty2).ToString();
								}
								else
								{
									((ArrayList)variableByName5.VarArray[num9])[num10] = string.Empty;
									((ArrayList)variableByName5.VarArray[num9])[num10] = c46bd9b8fde1a25f614f930b648557a08(variableByName5, empty2).ToString();
								}
							}
							else
							{
								variableByName5.dNumType = c46bd9b8fde1a25f614f930b648557a08(variableByName5, empty2);
							}
							break;
						}
						case Action.ActionInputType.Text:
							if (num9 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num10 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName5.VarArray[num9] = c46bd9b8fde1a25f614f930b648557a08(variableByName5, ((Control)additionalInputFrm2.txtInput).Text).ToString();
								}
								else
								{
									((ArrayList)variableByName5.VarArray[num9])[num10] = c46bd9b8fde1a25f614f930b648557a08(variableByName5, ((Control)additionalInputFrm2.txtInput).Text).ToString();
								}
							}
							else
							{
								variableByName5.dNumType = c46bd9b8fde1a25f614f930b648557a08(variableByName5, ((Control)additionalInputFrm2.txtInput).Text);
							}
							break;
						}
						break;
						IL_a388:
						if (additionalInputFrm == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							((Control)additionalInputFrm.lblTitle).Text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null);
							((Control)additionalInputFrm.btnCancel).Enabled = false;
						}
						if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
							DialogResult val12 = ((Form)additionalInputFrm).ShowDialog();
							if ((int)val12 != 4)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else
							{
								val12 = ((Form)additionalInputFrm).ShowDialog();
							}
							if ((int)val12 != 1)
							{
								return false;
							}
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else if (flag)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							c71f1ffa88f78e31ebea8163f6c76f6a8 = null;
							((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
							((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = false;
							((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = false;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
							while (true)
							{
								if (c71f1ffa88f78e31ebea8163f6c76f6a8 != null)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									break;
								}
								if (c6896c15b2653af6fffd4ff8146d89e43)
								{
									break;
								}
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								Application.DoEvents();
								Thread.Sleep(0);
							}
							GamePicture gamePicture6 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
							gamePicture6.Choices.Clear();
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
							((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = true;
							((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
							((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = true;
							((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = true;
							if (c71f1ffa88f78e31ebea8163f6c76f6a8.ToString().ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8922))
							{
								return false;
							}
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						else
						{
							((Control)additionalInputFrm).Width = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Width;
							((Control)additionalInputFrm).Height = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Height;
							((Form)additionalInputFrm).Location = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).PointToScreen(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Location);
							if ((int)((Form)additionalInputFrm).ShowDialog((IWin32Window)(object)cd431de8c0add2abbb6ebb8d63e4db3c0) != 1)
							{
								return false;
							}
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						}
						variableByName9 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname2);
						num19 = c835c6acbec36e979a142e0cab9dccbf2(roomname2);
						num20 = c9f91498283773f610332946230356cc8(roomname2);
						if (variableByName9 == null)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							break;
						}
						switch (actionInputType)
						{
						case Action.ActionInputType.Object:
						case Action.ActionInputType.Character:
						case Action.ActionInputType.ObjectOrCharacter:
						case Action.ActionInputType.Custom:
						case Action.ActionInputType.Inventory:
						{
							string empty4 = string.Empty;
							if (flag)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (!(c71f1ffa88f78e31ebea8163f6c76f6a8 is GameObject))
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									if (!(c71f1ffa88f78e31ebea8163f6c76f6a8 is Character))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										empty4 = c71f1ffa88f78e31ebea8163f6c76f6a8.ToString();
									}
									else
									{
										empty4 = ((Character)c71f1ffa88f78e31ebea8163f6c76f6a8).Charname;
									}
								}
								else
								{
									empty4 = ((GameObject)c71f1ffa88f78e31ebea8163f6c76f6a8).name;
								}
							}
							else
							{
								empty4 = additionalInputFrm.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
							}
							variableByName9.sString = string.Empty;
							if (!(empty4 != string.Empty))
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							else if (num19 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num20 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName9.VarArray[num19] = string.Empty;
									variableByName9.VarArray[num19] = empty4;
								}
								else
								{
									((ArrayList)variableByName9.VarArray[num19])[num20] = string.Empty;
									((ArrayList)variableByName9.VarArray[num19])[num20] = empty4;
								}
							}
							else
							{
								variableByName9.sString = empty4;
							}
							break;
						}
						case Action.ActionInputType.Text:
							if (num19 != -1)
							{
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
								if (num20 == -1)
								{
									__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									variableByName9.VarArray[num19] = ((Control)additionalInputFrm.txtInput).Text;
								}
								else
								{
									((ArrayList)variableByName9.VarArray[num19])[num20] = ((Control)additionalInputFrm.txtInput).Text;
								}
							}
							else
							{
								variableByName9.sString = ((Control)additionalInputFrm.txtInput).Text;
							}
							break;
						}
						break;
						IL_92b4:
						flag6 = false;
						if (actionInputType2 != Action.ActionInputType.Custom)
						{
							__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							additionalInputFrm2 = new AdditionalInputFrm(actionInputType2, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
						}
						else
						{
							if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag != null && ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture && !c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
							{
								if (command.EnhInputData.bUseEnhancedGraphics)
								{
									flag6 = true;
									GamePicture gamePicture9 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
									if (!(gamePicture9.enhinputdata.NewImage == string.Empty))
									{
										if (gamePicture9.enhinputdata.NewImage == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8828))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										}
										else
										{
											cd431de8c0add2abbb6ebb8d63e4db3c0.Image = (Image)c54f9a911545745b85ae6f74355697f8b.GetPictureByName(gamePicture9.enhinputdata.NewImage);
											GamePicture gamePictureByName8 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(gamePicture9.enhinputdata.NewImage);
											if (gamePictureByName8 == null)
											{
												__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											}
											else
											{
												((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = gamePictureByName8.GetTheImage();
												gamePictureByName8.enhinputdata = command.EnhInputData;
												gamePictureByName8.Choices = gamePicture9.Choices;
												((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePictureByName8;
											}
										}
									}
									gamePicture9.Choices.Clear();
									if (!(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null) != string.Empty))
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										gamePicture9.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1478));
									}
									else
									{
										gamePicture9.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(roomname3, null));
									}
									IEnumerator enumerator = command.CustomChoices.GetEnumerator();
									try
									{
										while (enumerator.MoveNext())
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
											string text56 = (string)enumerator.Current;
											gamePicture9.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text56, null));
										}
									}
									finally
									{
										if (!(enumerator is IDisposable disposable20))
										{
											__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										}
										else
										{
											disposable20.Dispose();
										}
									}
									if (!gamePicture9.enhinputdata.bAllowCancel && gamePicture9.Choices.Count > 1)
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
									}
									else
									{
										gamePicture9.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153));
									}
									goto IL_962a;
								}
								__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
							}
							ListBox inv2 = new ListBox();
							{
								IEnumerator enumerator2 = command.CustomChoices.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
										string text57 = (string)enumerator2.Current;
										inv2.Items.Add((object)c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text57, null));
									}
								}
								finally
								{
									IDisposable disposable25 = enumerator2 as IDisposable;
									if (disposable25 != null)
									{
										disposable25.Dispose();
									}
								}
							}
							additionalInputFrm2 = new AdditionalInputFrm(actionInputType2, ref inv2, ref lbRoomObjects, ref lbCharacters);
						}
						goto IL_962a;
					}
				}
				catch
				{
					Version version = new Version(Game.CurrentObjectVersionNumber);
					Version version2 = new Version(Game.ObjectVersionNumber);
					if (version < version2)
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9082) + Game.CurrentObjectVersionNumber + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9362));
						MessageBox.Show(command.cmdtype.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + command.CommandPart2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + command.CommandPart3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + command.CommandPart4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) + command.CommandText);
					}
					else if (!c6896c15b2653af6fffd4ff8146d89e43)
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9522) + command.cmdtype);
					}
				}
			}
			else if (c448d02ca06796950af39b4042a46c8b7(condition, P_2, P_3.InputType, P_1, ref P_3, P_4))
			{
				if (condition.Checks.Count != 1)
				{
					__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
				}
				else
				{
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_While)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Rooms)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Characters || ((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Items)
					{
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Exits)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Char_Inventory)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Container)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Inventory)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Room)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
					if (((Check)condition.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Group)
					{
						__ldtoken(frmMain.c7a4079d71aa46fcc2e653352922cc41a(ref ArrayList, GameObject, string, ref Action, object));
						continue;
					}
				}
				result = c7a4079d71aa46fcc2e653352922cc41a(ref condition.PassCommands, P_1, P_2, ref P_3, P_4);
			}
			else
			{
				result = c7a4079d71aa46fcc2e653352922cc41a(ref condition.FailCommands, P_1, P_2, ref P_3, P_4);
			}
		}
		return result;
	}

	private void c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType P_0, ref List<object> P_1)
	{
		switch (P_0)
		{
		case Action.ActionInputType.Character:
		{
			for (int l = 0; l < lbCharacters.Items.Count; l++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				if (!(lbCharacters.Items[l] is Character item2))
				{
					__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				}
				else
				{
					P_1.Add(item2);
				}
			}
			break;
		}
		case Action.ActionInputType.Object:
		{
			for (int m = 0; m < lbInventory.Items.Count; m++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				P_1.Add((GameObject)lbInventory.Items[m]);
			}
			for (int n = 0; n < lbRoomObjects.Items.Count; n++)
			{
				P_1.Add((GameObject)lbRoomObjects.Items[n]);
			}
			for (int num = 0; num < lbCharacters.Items.Count; num++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				if (!(lbCharacters.Items[num] is GameObject item3))
				{
					__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				}
				else
				{
					P_1.Add(item3);
				}
			}
			break;
		}
		case Action.ActionInputType.Inventory:
		{
			for (int num2 = 0; num2 < lbInventory.Items.Count; num2++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				P_1.Add((GameObject)lbInventory.Items[num2]);
			}
			break;
		}
		case Action.ActionInputType.ObjectOrCharacter:
		{
			for (int i = 0; i < lbInventory.Items.Count; i++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				P_1.Add((GameObject)lbInventory.Items[i]);
			}
			for (int j = 0; j < lbRoomObjects.Items.Count; j++)
			{
				__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
				P_1.Add((GameObject)lbRoomObjects.Items[j]);
			}
			for (int k = 0; k < lbCharacters.Items.Count; k++)
			{
				Character character = lbCharacters.Items[k] as Character;
				if (!(lbCharacters.Items[k] is GameObject item))
				{
					__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
					if (character == null)
					{
						__ldtoken(frmMain.c084bed40766f8f61e8a9ffb3ea35855e(Action.ActionInputType, ref List<object>));
					}
					else
					{
						P_1.Add(character);
					}
				}
				else
				{
					P_1.Add(item);
				}
			}
			break;
		}
		case Action.ActionInputType.Text:
		case Action.ActionInputType.Custom:
			break;
		}
	}

	private void cdb7eb588a870d047a196c0b2bc01bfdf()
	{
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
		object obj = null;
		if (lbCharacters.SelectedItem == null)
		{
			__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
		}
		else
		{
			obj = lbCharacters.SelectedItem;
		}
		lbCharacters.Items.Clear();
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
				Character character = (Character)enumerator.Current;
				if (!(character.CurrentRoom == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString()))
				{
					__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
					continue;
				}
				lbCharacters.Items.Add((object)character);
				if (obj != character)
				{
					__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
				}
				else
				{
					lbCharacters.SelectedItem = character;
				}
				if (!character.bAllowInventoryInteraction)
				{
					continue;
				}
				IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						GameObject gameObject = (GameObject)enumerator2.Current;
						if (gameObject.locationtype != GameObject.LocationType.LT_CHARACTER)
						{
							continue;
						}
						if (!(gameObject.locationname == character.Charname))
						{
							__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
							continue;
						}
						if (!gameObject.bVisible)
						{
							__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
							continue;
						}
						if (!gameObject.bImportant)
						{
							__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
							lbCharacters.Items.Add((object)gameObject);
						}
						else
						{
							lbCharacters.Items.Insert(0, (object)gameObject);
						}
						if (obj == gameObject)
						{
							lbCharacters.SelectedItem = gameObject;
						}
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
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
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}
		for (int num = lbCharacters.Items.Count - 1; num >= 0; num--)
		{
			__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
			if (lbCharacters.Items[num] is GameObject gameObject2)
			{
				if (!gameObject2.bImportant)
				{
					__ldtoken(frmMain.cdb7eb588a870d047a196c0b2bc01bfdf());
				}
				else
				{
					lbCharacters.Items.Remove((object)gameObject2);
					lbCharacters.Items.Insert(0, (object)gameObject2);
				}
			}
		}
	}

	private bool c448d02ca06796950af39b4042a46c8b7(Condition P_0, string P_1, Action.ActionInputType P_2, GameObject P_3, ref Action P_4, object P_5)
	{
		//IL_1a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7f: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		int num = 0;
		IEnumerator enumerator = P_0.Checks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
				Check check = (Check)enumerator.Current;
				try
				{
					if (num <= 0)
					{
						__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
						goto IL_0071;
					}
					if (check.CkType != CheckType.Or)
					{
						__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
						if (check.CkType != CheckType.And)
						{
							__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							goto IL_0071;
						}
						if (flag)
						{
							goto IL_0071;
						}
						continue;
					}
					if (flag)
					{
						break;
					}
					__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
					goto IL_0071;
					IL_0071:
					num++;
					if (c54f9a911545745b85ae6f74355697f8b != null)
					{
						__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
						string roomname = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(check.ConditionStep2, P_5);
						string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(check.ConditionStep3, P_5);
						string text2 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(check.ConditionStep4, P_5);
						switch (check.CondType)
						{
						case Condition.ConditionType.CT_Item_InGroup:
							flag = c22456d6abebb614385d453e037b0ae33(roomname, text, c5a1a94792ee68c127ca4e23531c9b032.c8c36b4ca0ce920efe7de82dba8b447cc);
							break;
						case Condition.ConditionType.CT_MultiMedia_InGroup:
							flag = c22456d6abebb614385d453e037b0ae33(roomname, text, c5a1a94792ee68c127ca4e23531c9b032.c157e191adcae76c450a8c82842c9666d);
							break;
						case Condition.ConditionType.CT_Item_Held_By_Player:
						{
							GameObject gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject5 != null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								gameObject5 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject5 != null)
							{
								if (gameObject5.locationtype != GameObject.LocationType.LT_PLAYER)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									if (gameObject5.locationtype != GameObject.LocationType.LT_IN_OBJECT)
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										flag = false;
									}
									else
									{
										flag = cafb873e7a7764c34105fb90b87e6b67f(ref gameObject5);
									}
								}
								else
								{
									flag = true;
								}
							}
							else
							{
								flag = false;
							}
							break;
						}
						case Condition.ConditionType.CT_Player_Moving:
						{
							Exit.Directions directions = (Exit.Directions)Enum.Parse(typeof(Exit.Directions), roomname);
							flag = c780fb3b6ad9bc450e9847a471ce8438a == directions;
							break;
						}
						case Condition.ConditionType.CT_Player_Gender:
							if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1801)))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								if (!roomname.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1835)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender == Player.Gender.Other;
								}
								else
								{
									flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender == Player.Gender.Female;
								}
							}
							else
							{
								flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerGender == Player.Gender.Male;
							}
							break;
						case Condition.ConditionType.CT_Character_Gender:
						{
							Character characterByName2 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
							if (characterByName2 == null)
							{
								break;
							}
							if (!text.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1801)))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								if (!text.Equals(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1835)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									flag = characterByName2.CharGender == Player.Gender.Other;
								}
								else
								{
									flag = characterByName2.CharGender == Player.Gender.Female;
								}
							}
							else
							{
								flag = characterByName2.CharGender == Player.Gender.Male;
							}
							break;
						}
						case Condition.ConditionType.CT_Character_In_Room:
						{
							Character characterByName4 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
							if (!(text == Room.CurrentRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								flag = characterByName4.CurrentRoom == text;
							}
							else
							{
								flag = characterByName4.CurrentRoom == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
							}
							break;
						}
						case Condition.ConditionType.CT_Character_In_RoomGroup:
						{
							flag = false;
							Character characterByName3 = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
							Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(characterByName3.CurrentRoom));
							if (roomByID != null && roomByID.Group == text)
							{
								flag = true;
							}
							break;
						}
						case Condition.ConditionType.CT_Item_Held_By_Character:
						{
							GameObject gameObject15 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(text);
							if (gameObject15 != null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								gameObject15 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(text);
							}
							if (gameObject15 != null)
							{
								if (gameObject15.locationtype != GameObject.LocationType.LT_CHARACTER)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									if (gameObject15.locationname == roomname)
									{
										flag = true;
										break;
									}
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								flag = false;
							}
							else
							{
								flag = false;
							}
							break;
						}
						case Condition.ConditionType.CT_Item_Not_Held_By_Player:
						{
							GameObject gameObject4 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject4 != null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								gameObject4 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject4 == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								flag = false;
							}
							else
							{
								flag = gameObject4.locationtype != GameObject.LocationType.LT_PLAYER;
							}
							break;
						}
						case Condition.ConditionType.CT_Item_In_Object:
						{
							GameObject gameObject14 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject14 == null)
							{
								gameObject14 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject14 == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								flag = false;
							}
							else
							{
								flag = gameObject14.locationtype == GameObject.LocationType.LT_IN_OBJECT && gameObject14.locationname == text;
							}
							break;
						}
						case Condition.ConditionType.CT_Item_Not_In_Object:
						{
							GameObject gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject != null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								gameObject = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								flag = true;
								break;
							}
							int num2;
							if (gameObject.locationtype != GameObject.LocationType.LT_IN_OBJECT)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								num2 = 0;
							}
							else
							{
								num2 = ((gameObject.locationname == text) ? 1 : 0);
							}
							bool flag2 = (byte)num2 != 0;
							flag = !flag2;
							break;
						}
						case Condition.ConditionType.CT_Item_In_Room:
							if (!(text == Room.CurrentRoomGuid.ToString()))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								GameObject gameObject2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
								if (gameObject2 != null)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									gameObject2 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
								}
								if (gameObject2 == null)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									flag = false;
								}
								else
								{
									flag = gameObject2.locationtype == GameObject.LocationType.LT_ROOM && gameObject2.locationname == text;
								}
							}
							else
							{
								GameObject gameObject3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
								if (gameObject3 != null)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									gameObject3 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
								}
								if (gameObject3 == null)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									flag = false;
								}
								else
								{
									flag = gameObject3.locationtype == GameObject.LocationType.LT_ROOM && gameObject3.locationname == c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString();
								}
							}
							break;
						case Condition.ConditionType.CT_Item_In_RoomGroup:
						{
							flag = false;
							GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (objectByName == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							if (objectByName.locationtype != GameObject.LocationType.LT_ROOM)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							Room roomByID2 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(objectByName.locationname));
							if (roomByID2 == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else if (!(roomByID2.Group == text))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								flag = true;
							}
							break;
						}
						case Condition.ConditionType.CT_Player_In_Room:
							flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString() == roomname;
							break;
						case Condition.ConditionType.CT_Player_In_RoomGroup:
							flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Group == roomname;
							break;
						case Condition.ConditionType.CT_Player_In_Same_Room_As:
							flag = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.UniqueID.ToString() == c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname).CurrentRoom;
							break;
						case Condition.ConditionType.CT_Loop_While:
							while (c413256b67777545bf43b4e0344e56abf(roomname, text, text2))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, P_5) || c6896c15b2653af6fffd4ff8146d89e43)
								{
									break;
								}
							}
							break;
						case Condition.ConditionType.CT_Loop_Rooms:
						{
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.RoomList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									Room room2 = (Room)enumerator2.Current;
									if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, room2))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
									if (!c6896c15b2653af6fffd4ff8146d89e43)
									{
										continue;
									}
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable9))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable9.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Loop_Exits:
						{
							Room room3 = null;
							try
							{
								room3 = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(new Guid(roomname));
							}
							catch
							{
								room3 = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname);
							}
							if (room3 == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							IEnumerator enumerator2 = room3.Exits.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									Exit exit = (Exit)enumerator2.Current;
									if (!c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, exit))
									{
										if (!c6896c15b2653af6fffd4ff8146d89e43)
										{
											continue;
										}
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable11))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable11.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Loop_Characters:
						{
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.CharacterList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									Character character2 = (Character)enumerator2.Current;
									if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, character2))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
									if (!c6896c15b2653af6fffd4ff8146d89e43)
									{
										continue;
									}
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable10))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable10.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Loop_Item_Group:
							{
								IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
								try
								{
									while (enumerator3.MoveNext())
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										GameObject gameObject12 = (GameObject)enumerator3.Current;
										if (gameObject12.GroupName == roomname)
										{
											if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject12))
											{
												__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
												break;
											}
											if (c6896c15b2653af6fffd4ff8146d89e43)
											{
												break;
											}
										}
									}
								}
								finally
								{
									IDisposable disposable14 = enumerator3 as IDisposable;
									if (disposable14 != null)
									{
										disposable14.Dispose();
									}
								}
							}
							break;
						case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
							{
								IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
								try
								{
									while (enumerator3.MoveNext())
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										GameObject gameObject13 = (GameObject)enumerator3.Current;
										if (gameObject13.locationtype != GameObject.LocationType.LT_CHARACTER)
										{
											continue;
										}
										if (!(gameObject13.locationname == roomname))
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											continue;
										}
										if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject13))
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											break;
										}
										if (!c6896c15b2653af6fffd4ff8146d89e43)
										{
											continue;
										}
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
								}
								finally
								{
									IDisposable disposable15 = enumerator3 as IDisposable;
									if (disposable15 != null)
									{
										disposable15.Dispose();
									}
								}
							}
							break;
						case Condition.ConditionType.CT_Loop_Item_Container:
							{
								IEnumerator enumerator3 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
								try
								{
									while (enumerator3.MoveNext())
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										GameObject gameObject9 = (GameObject)enumerator3.Current;
										if (gameObject9.locationtype != GameObject.LocationType.LT_IN_OBJECT)
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											continue;
										}
										if (!(gameObject9.locationname == roomname))
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											continue;
										}
										if (!c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject9))
										{
											if (!c6896c15b2653af6fffd4ff8146d89e43)
											{
												continue;
											}
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											break;
										}
										break;
									}
								}
								finally
								{
									IDisposable disposable16 = enumerator3 as IDisposable;
									if (disposable16 != null)
									{
										disposable16.Dispose();
									}
								}
							}
							break;
						case Condition.ConditionType.CT_Loop_Item_Inventory:
						{
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									GameObject gameObject10 = (GameObject)enumerator2.Current;
									if (gameObject10.locationtype != GameObject.LocationType.LT_PLAYER)
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject10))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
									if (c6896c15b2653af6fffd4ff8146d89e43)
									{
										break;
									}
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable7))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable7.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Loop_Item_Room:
						{
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									GameObject gameObject6 = (GameObject)enumerator2.Current;
									if (gameObject6.locationtype == GameObject.LocationType.LT_ROOM && gameObject6.locationname == roomname && (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject6) || c6896c15b2653af6fffd4ff8146d89e43))
									{
										break;
									}
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable4))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable4.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Loop_Items:
						{
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									GameObject gameObject7 = (GameObject)enumerator2.Current;
									if (c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_3, P_1, ref P_4, gameObject7))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										break;
									}
									if (!c6896c15b2653af6fffd4ff8146d89e43)
									{
										continue;
									}
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable5))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable5.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Room_CustomPropertyCheck:
						{
							string[] array3 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
							if (array3.Length != 2)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							string roomname2 = array3[0];
							string text5 = array3[1];
							Room room = null;
							if (!(roomname2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7197)))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								room = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref roomname2);
							}
							else
							{
								room = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom;
							}
							if (room == null)
							{
								break;
							}
							IEnumerator enumerator2 = room.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									CustomProperty customProperty3 = (CustomProperty)enumerator2.Current;
									if (customProperty3.Name == text5)
									{
										flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty3.Value, text, text2);
										break;
									}
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable3))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable3.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Character_CustomPropertyCheck:
						{
							string[] array = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
							if (array.Length != 2)
							{
								break;
							}
							string charname = array[0];
							string text3 = array[1];
							Character character = null;
							character = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(charname);
							if (character == null)
							{
								break;
							}
							IEnumerator enumerator2 = character.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									CustomProperty customProperty = (CustomProperty)enumerator2.Current;
									if (!(customProperty.Name == text3))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty.Value, text, text2);
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
						{
							string[] array2 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
							if (array2.Length != 2)
							{
								break;
							}
							string timername = array2[0];
							string text4 = array2[1];
							Timer timer = null;
							timer = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(timername);
							if (timer == null)
							{
								break;
							}
							IEnumerator enumerator2 = timer.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									CustomProperty customProperty2 = (CustomProperty)enumerator2.Current;
									if (!(customProperty2.Name == text4))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty2.Value, text, text2);
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable2))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable2.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
						{
							string[] array5 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
							if (array5.Length != 2)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							string varname = array5[0];
							string text10 = array5[1];
							GameVariable gameVariable = null;
							gameVariable = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(varname);
							if (gameVariable == null)
							{
								break;
							}
							IEnumerator enumerator2 = gameVariable.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									CustomProperty customProperty6 = (CustomProperty)enumerator2.Current;
									if (!(customProperty6.Name == text10))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty6.Value, text, text2);
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable12))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable12.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Item_CustomPropertyCheck:
						{
							string[] array4 = roomname.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(752) }, StringSplitOptions.None);
							if (array4.Length != 2)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							string text6 = array4[0];
							string text7 = array4[1];
							GameObject gameObject8 = null;
							if (!(text6 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7674)))
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								gameObject8 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(text6);
							}
							else if (P_3 != null)
							{
								gameObject8 = P_3;
							}
							if (gameObject8 == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							IEnumerator enumerator2 = gameObject8.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									CustomProperty customProperty4 = (CustomProperty)enumerator2.Current;
									if (!(customProperty4.Name == text7))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty4.Value, text, text2);
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable6))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable6.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Player_CustomPropertyCheck:
						{
							string text9 = roomname;
							IEnumerator enumerator2 = c54f9a911545745b85ae6f74355697f8b.ThePlayer.CustomProperties.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									CustomProperty customProperty5 = (CustomProperty)enumerator2.Current;
									if (!(customProperty5.Name == text9))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										continue;
									}
									flag = c73b7c9f271ed16e445d2cefee70f6d3e(customProperty5.Value, text, text2);
									break;
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable8))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									disposable8.Dispose();
								}
							}
							break;
						}
						case Condition.ConditionType.CT_Variable_Comparison:
							flag = c413256b67777545bf43b4e0344e56abf(roomname, text, text2);
							break;
						case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
						{
							GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(roomname);
							GameVariable variableByName2 = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(text2);
							int num3 = c835c6acbec36e979a142e0cab9dccbf2(roomname);
							int num4 = c9f91498283773f610332946230356cc8(roomname);
							int num5 = c835c6acbec36e979a142e0cab9dccbf2(text2);
							int num6 = c9f91498283773f610332946230356cc8(text2);
							string text8 = string.Empty;
							switch (variableByName2.vartype)
							{
							case GameVariable.VarType.VT_NUMBER:
							case GameVariable.VarType.VT_NUMBERARRAY:
								if (num5 != -1)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									if (num6 == -1)
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										text8 = variableByName2.VarArray[num5].ToString();
									}
									else
									{
										text8 = ((ArrayList)variableByName2.VarArray[num5])[num6].ToString();
									}
								}
								else
								{
									text8 = variableByName2.dNumType.ToString();
								}
								break;
							case GameVariable.VarType.VT_STRING:
							case GameVariable.VarType.VT_STRINGARRAY:
								if (num5 != -1)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									text8 = ((num6 == -1) ? variableByName2.VarArray[num5].ToString() : ((ArrayList)variableByName2.VarArray[num5])[num6].ToString());
								}
								else
								{
									text8 = variableByName2.sString;
								}
								break;
							}
							if (variableByName == null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								break;
							}
							switch (variableByName.vartype)
							{
							case GameVariable.VarType.VT_NUMBER:
							case GameVariable.VarType.VT_NUMBERARRAY:
							{
								if (num3 == -1)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else if (num4 == -1)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									variableByName.dNumType = Convert.ToDouble(variableByName.VarArray[num3]);
								}
								else
								{
									variableByName.dNumType = Convert.ToDouble(((ArrayList)variableByName.VarArray[num3])[num4]);
								}
								double num7 = 0.0;
								double num8 = 0.0;
								try
								{
									num8 = Convert.ToDouble(text8);
								}
								catch
								{
									num8 = 0.0;
								}
								num7 = variableByName.dNumType;
								if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886))
								{
									flag = num7 == num8;
								}
								else if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9773))
									{
										flag = num7 > num8;
									}
									else if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9798)))
									{
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
										if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9843)))
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9862)))
											{
												__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											}
											else
											{
												flag = num7 <= num8;
											}
										}
										else
										{
											flag = num7 < num8;
										}
									}
									else
									{
										flag = num7 >= num8;
									}
								}
								else
								{
									flag = num7 != num8;
								}
								break;
							}
							case GameVariable.VarType.VT_STRING:
							case GameVariable.VarType.VT_STRINGARRAY:
							{
								string strB = TextHandlers.TextOnly(variableByName.sString);
								if (num3 == -1)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									strB = ((num4 == -1) ? TextHandlers.TextOnly(variableByName.VarArray[num3].ToString()) : TextHandlers.TextOnly(((ArrayList)variableByName.VarArray[num3])[num4].ToString()));
								}
								if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886))
								{
									flag = string.Compare(text8, strB, ignoreCase: true) == 0;
								}
								else if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = string.Compare(text8, strB, ignoreCase: true) != 0;
								}
								break;
							}
							case GameVariable.VarType.VT_DATETIME:
								break;
							}
							break;
						}
						case Condition.ConditionType.CT_Item_State_Check:
						{
							GameObject gameObject11 = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(roomname);
							if (gameObject11 != null)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
							}
							else
							{
								gameObject11 = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(roomname);
							}
							if (gameObject11 != null)
							{
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8513)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = gameObject11.bOpen;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9901)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = !gameObject11.bOpen;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8500)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = gameObject11.bLocked;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9914)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = !gameObject11.bLocked;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8522)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = gameObject11.bWorn;
								}
								if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9931))
								{
									flag = !gameObject11.bWorn;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9946)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = gameObject11.bRead;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9955)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = !gameObject11.bRead;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6101)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = gameObject11.bVisible;
								}
								if (!(text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9968)))
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								}
								else
								{
									flag = !gameObject11.bVisible;
								}
							}
							else
							{
								flag = false;
							}
							break;
						}
						case Condition.ConditionType.CT_AdditionalDataCheck:
							if (P_2 != Action.ActionInputType.Text)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								if (string.Compare(roomname, P_1, ignoreCase: true) != 0)
								{
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									GameObject objectByNameOld = c54f9a911545745b85ae6f74355697f8b.GetObjectByNameOld(P_1);
									Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(roomname);
									if (objectByNameOld != null)
									{
										flag = string.Compare(roomname, objectByNameOld.UniqueIdentifier.ToString(), ignoreCase: true) == 0;
										break;
									}
									__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									if (characterByName != null)
									{
										if (string.Compare(P_1, characterByName.ToString(), ignoreCase: true) != 0)
										{
											__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
											flag = false;
										}
										else
										{
											flag = true;
										}
										break;
									}
									objectByNameOld = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(P_1);
									if (objectByNameOld != null)
									{
										if (string.Compare(roomname, objectByNameOld.name, ignoreCase: true) == 0)
										{
											flag = true;
											break;
										}
										__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
									}
									flag = false;
								}
								else
								{
									flag = true;
								}
							}
							else if (string.Compare(text2, P_1.ToString(), ignoreCase: true) != 0)
							{
								__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
								flag = false;
							}
							else
							{
								flag = true;
							}
							break;
						}
						continue;
					}
					return false;
				}
				catch (Exception)
				{
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9987) + P_0.conditionname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10235) + check.CondType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + check.ConditionStep2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + check.ConditionStep3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + check.ConditionStep4);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable13))
			{
				__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
			}
			else
			{
				disposable13.Dispose();
			}
		}
		if (c45335acf471afc831c5b4bad4cbe5394 == null)
		{
			__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
		}
		else
		{
			string text11 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10250);
			if (flag)
			{
				__ldtoken(frmMain.c448d02ca06796950af39b4042a46c8b7(Condition, string, Action.ActionInputType, GameObject, ref Action, object));
			}
			else
			{
				text11 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10265);
			}
			c45335acf471afc831c5b4bad4cbe5394.AddExecutionData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10280) + P_0.conditionname + text11, bBold: false);
		}
		return flag;
	}

	private bool c22456d6abebb614385d453e037b0ae33(string P_0, string P_1, c5a1a94792ee68c127ca4e23531c9b032 P_2)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10303);
		string text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10314);
		if (P_2 != c5a1a94792ee68c127ca4e23531c9b032.c8c36b4ca0ce920efe7de82dba8b447cc)
		{
			__ldtoken(frmMain.c22456d6abebb614385d453e037b0ae33(string, string, c5a1a94792ee68c127ca4e23531c9b032));
		}
		else
		{
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10337);
			text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10348);
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10369) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10414), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10483), (object)P_0);
		SqlCeDataReader val2 = val.ExecuteReader();
		string text3 = string.Empty;
		if (((DbDataReader)(object)val2).Read())
		{
			text3 = ((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10494)].ToString();
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
		if (!(text3 == P_1))
		{
			__ldtoken(frmMain.c22456d6abebb614385d453e037b0ae33(string, string, c5a1a94792ee68c127ca4e23531c9b032));
			string empty = string.Empty;
			empty = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10513) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10548);
			val = new SqlCeCommand(empty, dBConnection);
			val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10641), (object)P_1);
			val2 = val.ExecuteReader();
			while (((DbDataReader)(object)val2).Read())
			{
				__ldtoken(frmMain.c22456d6abebb614385d453e037b0ae33(string, string, c5a1a94792ee68c127ca4e23531c9b032));
				bool flag = c22456d6abebb614385d453e037b0ae33(P_0, ((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205)].ToString(), P_2);
				if (!flag)
				{
					__ldtoken(frmMain.c22456d6abebb614385d453e037b0ae33(string, string, c5a1a94792ee68c127ca4e23531c9b032));
					continue;
				}
				return flag;
			}
			return false;
		}
		return true;
	}

	private void c58e5b13ce653faa93234bb8e406d83e6(ref List<string> P_0, string P_1, c5a1a94792ee68c127ca4e23531c9b032 P_2)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		string text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10303);
		string text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10314);
		if (P_2 != c5a1a94792ee68c127ca4e23531c9b032.c8c36b4ca0ce920efe7de82dba8b447cc)
		{
			__ldtoken(frmMain.c58e5b13ce653faa93234bb8e406d83e6(ref List<string>, string, c5a1a94792ee68c127ca4e23531c9b032));
		}
		else
		{
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10337);
			text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10348);
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10656) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10691), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10483), (object)P_1);
		SqlCeDataReader val2 = val.ExecuteReader();
		_ = string.Empty;
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(frmMain.c58e5b13ce653faa93234bb8e406d83e6(ref List<string>, string, c5a1a94792ee68c127ca4e23531c9b032));
			P_0.Add(((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205)].ToString());
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
		string empty = string.Empty;
		empty = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10513) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10548);
		val = new SqlCeCommand(empty, dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10641), (object)P_1);
		val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			c58e5b13ce653faa93234bb8e406d83e6(ref P_0, ((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205)].ToString(), P_2);
		}
	}

	private bool c73b7c9f271ed16e445d2cefee70f6d3e(string P_0, string P_1, string P_2)
	{
		bool result = true;
		string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_2, null);
		bool flag = false;
		double num = 0.0;
		double num2 = 0.0;
		try
		{
			num = Convert.ToDouble(P_0);
			num2 = Convert.ToDouble(text);
			flag = true;
		}
		catch
		{
			flag = false;
		}
		if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886))
		{
			if (!flag)
			{
				__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
				result = string.Compare(text, P_0, ignoreCase: true) == 0;
			}
			else
			{
				result = num2 == num;
			}
		}
		else if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
		{
			__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
			if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10770)))
			{
				__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
				if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9773))
				{
					if (!flag)
					{
						__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
						result = string.Compare(text, P_0, ignoreCase: true) > 0;
					}
					else
					{
						result = num > num2;
					}
				}
				else if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9798))
				{
					if (!flag)
					{
						__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
						result = string.Compare(text, P_0, ignoreCase: true) >= 0;
					}
					else
					{
						result = num >= num2;
					}
				}
				else if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9843)))
				{
					__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9862)))
					{
						__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
					}
					else if (!flag)
					{
						__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
						result = string.Compare(text, P_0, ignoreCase: true) <= 0;
					}
					else
					{
						result = num <= num2;
					}
				}
				else if (!flag)
				{
					__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
					result = string.Compare(text, P_0, ignoreCase: true) < 0;
				}
				else
				{
					result = num < num2;
				}
			}
			else
			{
				result = P_0.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
			}
		}
		else if (!flag)
		{
			__ldtoken(frmMain.c73b7c9f271ed16e445d2cefee70f6d3e(string, string, string));
			result = string.Compare(text, P_0, ignoreCase: true) != 0;
		}
		else
		{
			result = num2 != num;
		}
		return result;
	}

	private bool c413256b67777545bf43b4e0344e56abf(string P_0, string P_1, string P_2)
	{
		bool result = true;
		GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(P_0);
		if (variableByName == null)
		{
			__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
		}
		else
		{
			int num = c835c6acbec36e979a142e0cab9dccbf2(P_0);
			int num2 = c9f91498283773f610332946230356cc8(P_0);
			string text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_2, null);
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (num == -1)
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
				}
				else if (num2 == -1)
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
					variableByName.dtDateTime = (DateTime)variableByName.VarArray[num];
				}
				else
				{
					variableByName.dtDateTime = (DateTime)((ArrayList)variableByName.VarArray[num])[num2];
				}
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
					{
						__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
						if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9773)))
						{
							__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
							if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9798)))
							{
								__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
								if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9843))
								{
									result = variableByName.dtDateTime < Convert.ToDateTime(text, Game.myDTFI);
								}
								else if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9862)))
								{
									__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
									if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10787)))
									{
										__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
										if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10812)))
										{
											__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
											if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10835)))
											{
												__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
												if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10876)))
												{
													__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
													if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10911)))
													{
														__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
														if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10938)))
														{
															__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
															if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10983)))
															{
																__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
																if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11022)))
																{
																	__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
																	if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11051)))
																	{
																		__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
																		if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11098)))
																		{
																			__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
																		}
																		else
																		{
																			result = variableByName.dtDateTime.Second < Convert.ToInt32(text);
																		}
																	}
																	else
																	{
																		result = variableByName.dtDateTime.Second > Convert.ToInt32(text);
																	}
																}
																else
																{
																	result = variableByName.dtDateTime.Second == Convert.ToInt32(text);
																}
															}
															else
															{
																result = variableByName.dtDateTime.Minute < Convert.ToInt32(text);
															}
														}
														else
														{
															result = variableByName.dtDateTime.Minute > Convert.ToInt32(text);
														}
													}
													else
													{
														result = variableByName.dtDateTime.Minute == Convert.ToInt32(text);
													}
												}
												else
												{
													result = variableByName.dtDateTime.Hour < Convert.ToInt32(text);
												}
											}
											else
											{
												result = variableByName.dtDateTime.Hour > Convert.ToInt32(text);
											}
										}
										else
										{
											result = variableByName.dtDateTime.Hour == Convert.ToInt32(text);
										}
									}
									else
									{
										result = string.Compare(text, variableByName.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8491), Game.myDTFI), ignoreCase: true) == 0;
									}
								}
								else
								{
									result = variableByName.dtDateTime < Convert.ToDateTime(text, Game.myDTFI);
								}
							}
							else
							{
								result = variableByName.dtDateTime >= Convert.ToDateTime(text, Game.myDTFI);
							}
						}
						else
						{
							result = variableByName.dtDateTime > Convert.ToDateTime(text, Game.myDTFI);
						}
					}
					else
					{
						result = Convert.ToDateTime(text, Game.myDTFI) != variableByName.dtDateTime;
					}
				}
				else
				{
					result = Convert.ToDateTime(text, Game.myDTFI) == variableByName.dtDateTime;
				}
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
				if (num == -1)
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
				}
				else if (num2 == -1)
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
					variableByName.dNumType = (double)variableByName.VarArray[num];
				}
				else
				{
					variableByName.dNumType = Convert.ToDouble(((ArrayList)variableByName.VarArray[num])[num2]);
				}
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
					{
						__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
						if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9773)))
						{
							__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
							if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9798)))
							{
								__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
								if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9843))
								{
									result = variableByName.dNumType < Convert.ToDouble(text);
								}
								else if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9862))
								{
									result = variableByName.dNumType <= Convert.ToDouble(text);
								}
							}
							else
							{
								result = variableByName.dNumType >= Convert.ToDouble(text);
							}
						}
						else
						{
							result = variableByName.dNumType > Convert.ToDouble(text);
						}
					}
					else
					{
						result = Convert.ToDouble(text) != variableByName.dNumType;
					}
				}
				else
				{
					result = Convert.ToDouble(text) == variableByName.dNumType;
				}
				break;
			case GameVariable.VarType.VT_STRING:
			case GameVariable.VarType.VT_STRINGARRAY:
				if (num == -1)
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
				}
				else if (num2 != -1)
				{
					variableByName.sString = ((ArrayList)variableByName.VarArray[num])[num2].ToString();
				}
				else
				{
					variableByName.sString = variableByName.VarArray[num].ToString();
				}
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
				{
					__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
					if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9752)))
					{
						__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
						if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10770)))
						{
							__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
							if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9773)))
							{
								__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
								if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(9843)))
								{
									__ldtoken(frmMain.c413256b67777545bf43b4e0344e56abf(string, string, string));
								}
								else
								{
									result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) > 0;
								}
							}
							else
							{
								result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) < 0;
							}
						}
						else
						{
							result = TextHandlers.TextOnly(variableByName.sString).IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
						}
					}
					else
					{
						result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) != 0;
					}
				}
				else
				{
					result = string.Compare(text, TextHandlers.TextOnly(variableByName.sString), ignoreCase: true) == 0;
				}
				break;
			}
		}
		return result;
	}

	private bool c9cff05a07825c588d9efb7028802a05f(ref Action P_0, GameObject P_1)
	{
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected Obj, but got Unknown
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Invalid comparison between Unknown and I4
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Invalid comparison between Unknown and I4
		ce6360c84ba3e74eaea3de5533fd06d81.Enabled = false;
		try
		{
			string text;
			AdditionalInputFrm additionalInputFrm;
			bool flag;
			if (c54f9a911545745b85ae6f74355697f8b != null)
			{
				__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				if (c45335acf471afc831c5b4bad4cbe5394 == null)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				}
				else
				{
					c45335acf471afc831c5b4bad4cbe5394.AddExecutionData(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11139) + P_0.name, bBold: true);
				}
				text = "";
				c54f9a911545745b85ae6f74355697f8b.AdditionalData = "";
				additionalInputFrm = null;
				flag = false;
				if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag != null)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					if (!(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture gamePicture))
					{
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					}
					else
					{
						gamePicture.enhinputdata = P_0.EnhInputData;
					}
				}
				else
				{
					GamePicture gamePicture2 = new GamePicture();
					gamePicture2.enhinputdata = P_0.EnhInputData;
					((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePicture2;
				}
				if (P_0.InputType != Action.ActionInputType.None)
				{
					if (P_0.InputType != Action.ActionInputType.Custom)
					{
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						if (!P_0.EnhInputData.bUseEnhancedGraphics)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else
						{
							if (P_0.InputType != Action.ActionInputType.Text)
							{
								flag = true;
								GamePicture gamePicture3 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
								if (P_0.EnhInputData.NewImage == string.Empty)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else if (P_0.EnhInputData.NewImage == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8828))
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else
								{
									GamePicture gamePictureByName = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(P_0.EnhInputData.NewImage);
									if (gamePictureByName == null)
									{
										__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									}
									else
									{
										((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = gamePictureByName.GetTheImage();
										gamePictureByName.enhinputdata = P_0.EnhInputData;
										gamePictureByName.Choices = gamePicture3.Choices;
										((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePictureByName;
									}
								}
								gamePicture3.Choices.Clear();
								if (!(P_0.CustomChoiceTitle != string.Empty))
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									gamePicture3.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1478));
								}
								else
								{
									gamePicture3.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.CustomChoiceTitle, null));
								}
								c084bed40766f8f61e8a9ffb3ea35855e(P_0.InputType, ref gamePicture3.Choices);
								if (gamePicture3.enhinputdata.bAllowCancel)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else if (gamePicture3.Choices.Count > 1)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									goto IL_066e;
								}
								gamePicture3.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153));
								goto IL_066e;
							}
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						additionalInputFrm = new AdditionalInputFrm(P_0.InputType, ref lbInventory, ref lbRoomObjects, ref lbCharacters);
						if (!(P_0.CustomChoiceTitle != string.Empty))
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else
						{
							((Control)additionalInputFrm.lblTitle).Text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.CustomChoiceTitle, null);
						}
					}
					else
					{
						if (((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag == null)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else if (!(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture))
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else if (c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						else
						{
							if (P_0.EnhInputData.bUseEnhancedGraphics)
							{
								flag = true;
								GamePicture gamePicture4 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
								if (P_0.EnhInputData.NewImage == string.Empty)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else if (P_0.EnhInputData.NewImage == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8828))
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else
								{
									GamePicture gamePictureByName2 = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(P_0.EnhInputData.NewImage);
									if (gamePictureByName2 == null)
									{
										__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									}
									else
									{
										((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).BackgroundImage = gamePictureByName2.GetTheImage();
										gamePictureByName2.enhinputdata = P_0.EnhInputData;
										gamePictureByName2.Choices = gamePicture4.Choices;
										((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag = gamePictureByName2;
									}
								}
								gamePicture4.Choices.Clear();
								if (c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.CustomChoiceTitle, null) != string.Empty)
								{
									gamePicture4.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.CustomChoiceTitle, null));
								}
								else
								{
									gamePicture4.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1478));
								}
								IEnumerator enumerator = P_0.CustomChoices.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
										string text2 = (string)enumerator.Current;
										gamePicture4.Choices.Add(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text2, null));
									}
								}
								finally
								{
									if (!(enumerator is IDisposable disposable))
									{
										__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									}
									else
									{
										disposable.Dispose();
									}
								}
								if (gamePicture4.enhinputdata.bAllowCancel)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
								}
								else if (gamePicture4.Choices.Count > 1)
								{
									__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
									goto IL_066e;
								}
								gamePicture4.Choices.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1153));
								goto IL_066e;
							}
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						}
						ListBox inv = new ListBox();
						IEnumerator enumerator2 = P_0.CustomChoices.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								string text3 = (string)enumerator2.Current;
								inv.Items.Add((object)c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(text3, null));
							}
						}
						finally
						{
							if (!(enumerator2 is IDisposable disposable2))
							{
								__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							}
							else
							{
								disposable2.Dispose();
							}
						}
						additionalInputFrm = new AdditionalInputFrm(P_0.InputType, ref inv, ref lbRoomObjects, ref lbCharacters);
						((Control)additionalInputFrm.lblTitle).Text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.CustomChoiceTitle, null);
					}
					goto IL_066e;
				}
				goto IL_0a02;
			}
			return false;
			IL_0a02:
			bool flag2 = true;
			if (!P_0.bConditionFailOnFirst)
			{
				__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				flag2 = false;
				if (P_0.Conditions.Count != 0)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				}
				else
				{
					flag2 = true;
				}
				for (int i = 0; i < P_0.Conditions.Count; i++)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					Condition condition = (Condition)P_0.Conditions[i];
					bool flag3 = c448d02ca06796950af39b4042a46c8b7(condition, text, P_0.InputType, P_1, ref P_0, null);
					if (flag3)
					{
						flag2 = flag3;
						c7a4079d71aa46fcc2e653352922cc41a(ref condition.PassCommands, P_1, text, ref P_0, null);
					}
					else
					{
						c7a4079d71aa46fcc2e653352922cc41a(ref condition.FailCommands, P_1, text, ref P_0, null);
					}
				}
			}
			else
			{
				for (int j = 0; j < P_0.Conditions.Count; j++)
				{
					Condition condition2 = (Condition)P_0.Conditions[j];
					if (!c448d02ca06796950af39b4042a46c8b7(condition2, text, P_0.InputType, P_1, ref P_0, null))
					{
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						flag2 = false;
						c7a4079d71aa46fcc2e653352922cc41a(ref condition2.FailCommands, P_1, text, ref P_0, null);
						break;
					}
					if (condition2.Checks.Count != 1)
					{
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					}
					else
					{
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_While)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Rooms)
						{
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Characters)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Items)
						{
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Exits)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Char_Inventory)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Container)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Inventory)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Room)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
						if (((Check)condition2.Checks[0]).CondType == Condition.ConditionType.CT_Loop_Item_Group)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							continue;
						}
					}
					c7a4079d71aa46fcc2e653352922cc41a(ref condition2.PassCommands, P_1, text, ref P_0, null);
				}
			}
			if (flag2)
			{
				c7a4079d71aa46fcc2e653352922cc41a(ref P_0.PassCommands, P_1, text, ref P_0, null);
			}
			else
			{
				c7a4079d71aa46fcc2e653352922cc41a(ref P_0.FailCommands, P_1, text, ref P_0, null);
			}
			goto end_IL_000c;
			IL_066e:
			if (!c54f9a911545745b85ae6f74355697f8b.bHideMainPicDisplay)
			{
				if (flag)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					c71f1ffa88f78e31ebea8163f6c76f6a8 = null;
					((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = false;
					((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
					((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = false;
					((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = false;
					((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
					while (true)
					{
						if (c71f1ffa88f78e31ebea8163f6c76f6a8 != null)
						{
							__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
							break;
						}
						if (c6896c15b2653af6fffd4ff8146d89e43)
						{
							break;
						}
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						Application.DoEvents();
						Thread.Sleep(100);
					}
					GamePicture gamePicture5 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag as GamePicture;
					gamePicture5.Choices.Clear();
					((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
					((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = true;
					((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
					((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = true;
					((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = true;
					if (c71f1ffa88f78e31ebea8163f6c76f6a8 == null)
					{
						return false;
					}
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					string text4 = c71f1ffa88f78e31ebea8163f6c76f6a8.ToString();
					if (text4.ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8922))
					{
						return false;
					}
				}
				else
				{
					((Control)additionalInputFrm).Width = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Width;
					((Control)additionalInputFrm).Height = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Height;
					((Form)additionalInputFrm).Location = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).PointToScreen(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Location);
					if ((int)((Form)additionalInputFrm).ShowDialog((IWin32Window)(object)cd431de8c0add2abbb6ebb8d63e4db3c0) != 1)
					{
						return false;
					}
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				}
			}
			else
			{
				((Form)additionalInputFrm).StartPosition = (FormStartPosition)4;
				if ((int)((Form)additionalInputFrm).ShowDialog() != 1)
				{
					return false;
				}
				__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
			}
			text = string.Empty;
			switch (P_0.InputType)
			{
			case Action.ActionInputType.Object:
			case Action.ActionInputType.Character:
			case Action.ActionInputType.ObjectOrCharacter:
			case Action.ActionInputType.Custom:
			case Action.ActionInputType.Inventory:
			{
				if (flag)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					GameObject gameObject = c71f1ffa88f78e31ebea8163f6c76f6a8 as GameObject;
					Character character = c71f1ffa88f78e31ebea8163f6c76f6a8 as Character;
					if (gameObject == null)
					{
						text = ((character == null) ? c71f1ffa88f78e31ebea8163f6c76f6a8.ToString() : character.Charname);
					}
					else
					{
						text = gameObject.name;
					}
					break;
				}
				if (((BaseCollection)additionalInputFrm.dgvItems.SelectedRows).Count <= 0)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					break;
				}
				GameObject gameObject2 = ((DataGridViewBand)additionalInputFrm.dgvItems.SelectedRows[0]).Tag as GameObject;
				Character character2 = ((DataGridViewBand)additionalInputFrm.dgvItems.SelectedRows[0]).Tag as Character;
				if (gameObject2 == null)
				{
					__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
					if (character2 == null)
					{
						__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
						text = additionalInputFrm.dgvItems.SelectedRows[0].Cells[0].Value.ToString();
					}
					else
					{
						text = character2.Charname;
					}
				}
				else
				{
					text = gameObject2.name;
				}
				break;
			}
			case Action.ActionInputType.Text:
				text = ((Control)additionalInputFrm.txtInput).Text;
				break;
			}
			c54f9a911545745b85ae6f74355697f8b.AdditionalData = text;
			GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(text);
			string empty = string.Empty;
			if (objectByName == null)
			{
				__ldtoken(frmMain.c9cff05a07825c588d9efb7028802a05f(ref Action, GameObject));
				empty = text;
			}
			else
			{
				empty = objectByName.name;
			}
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, empty + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
			goto IL_0a02;
			end_IL_000c:;
		}
		finally
		{
			try
			{
				ce6360c84ba3e74eaea3de5533fd06d81.Enabled = true;
			}
			catch
			{
			}
		}
		return true;
	}

	private void c0d2ee82c2bc6a0e93db8e117c8f1d502(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 2097152)
		{
			__ldtoken(frmMain.c0d2ee82c2bc6a0e93db8e117c8f1d502(object, MouseEventArgs));
			return;
		}
		int num = lbRoomObjects.IndexFromPoint(P_1.X, P_1.Y);
		if (num == -1)
		{
			__ldtoken(frmMain.c0d2ee82c2bc6a0e93db8e117c8f1d502(object, MouseEventArgs));
			return;
		}
		((ListControl)lbRoomObjects).SelectedIndex = num;
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		GameObject gameObject = lbRoomObjects.Items[num] as GameObject;
		ce9033674910e3df8a0b419702d6f30be(gameObject.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.cfbba04fc2eff86441089b369b8432706;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbRoomObjects, P_1.X, P_1.Y);
	}

	private void ce9033674910e3df8a0b419702d6f30be(ArrayList P_0, string P_1, ToolStripMenuItem P_2)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		for (int i = 0; i < P_0.Count; i++)
		{
			__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
			Action action = (Action)P_0[i];
			if (!action.bActive)
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
				continue;
			}
			if (action.name.Length <= 2)
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
			}
			else if (action.name.Substring(0, 2) == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5387))
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
				continue;
			}
			if (!(action.actionparent == P_1))
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
				continue;
			}
			string text = action.name;
			if (!(action.overridename != string.Empty))
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
			}
			else
			{
				text = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(action.overridename, null);
			}
			ToolStripMenuItem val = new ToolStripMenuItem(text);
			((ToolStripItem)val).Tag = action;
			((ToolStripItem)val).Click += c1c7e722e9171a93d5f29b3f1a6c671a7;
			if (P_2 != null)
			{
				__ldtoken(frmMain.ce9033674910e3df8a0b419702d6f30be(ArrayList, string, ToolStripMenuItem));
				((ToolStripDropDownItem)P_2).DropDownItems.Add((ToolStripItem)(object)val);
			}
			else
			{
				((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Add((ToolStripItem)(object)val);
			}
			ce9033674910e3df8a0b419702d6f30be(P_0, action.name, val);
		}
	}

	private void c99f21074ced9ed9c2686660d0583eaff(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.Button == 2097152)
		{
			int num = lbInventory.IndexFromPoint(P_1.X, P_1.Y);
			if (num == -1)
			{
				__ldtoken(frmMain.c99f21074ced9ed9c2686660d0583eaff(object, MouseEventArgs));
				return;
			}
			((ListControl)lbInventory).SelectedIndex = num;
			((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
			GameObject gameObject = lbInventory.Items[num] as GameObject;
			ce9033674910e3df8a0b419702d6f30be(gameObject.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
			c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c8bce6377505aef2547787d71a915b3b8;
			((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbInventory, P_1.X, P_1.Y);
		}
	}

	private void cbfc47bcbda14ef93efc6bed196c42bf0(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 2097152)
		{
			__ldtoken(frmMain.cbfc47bcbda14ef93efc6bed196c42bf0(object, MouseEventArgs));
			return;
		}
		int num = lbCharacters.IndexFromPoint(P_1.X, P_1.Y);
		if (num == -1)
		{
			__ldtoken(frmMain.cbfc47bcbda14ef93efc6bed196c42bf0(object, MouseEventArgs));
			return;
		}
		((ListControl)lbCharacters).SelectedIndex = num;
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		Character character = lbCharacters.SelectedItem as Character;
		GameObject gameObject = lbCharacters.SelectedItem as GameObject;
		ArrayList arrayList = null;
		if (character != null)
		{
			arrayList = character.Actions;
		}
		else if (gameObject != null)
		{
			arrayList = gameObject.Actions;
		}
		if (arrayList != null)
		{
			ce9033674910e3df8a0b419702d6f30be(arrayList, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
			c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.cde26345c3892d2dd4757283560083496;
			((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbCharacters, P_1.X, P_1.Y);
		}
	}

	private void c35c8134a614cd8349dae8308818b1f43(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		Character character = lbCharacters.SelectedItem as Character;
		GameObject gameObject = lbCharacters.SelectedItem as GameObject;
		Action action = null;
		if (character == null)
		{
			__ldtoken(frmMain.c35c8134a614cd8349dae8308818b1f43(object, EventArgs));
			if (gameObject != null)
			{
				action = ((ToolStripItem)val).Tag as Action;
			}
		}
		else
		{
			action = ((ToolStripItem)val).Tag as Action;
		}
		if (action == null)
		{
			__ldtoken(frmMain.c35c8134a614cd8349dae8308818b1f43(object, EventArgs));
			return;
		}
		c0c9975317d693fd5f4e3431f15ff3ea2();
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, lbCharacters.SelectedItem.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		if (c9cff05a07825c588d9efb7028802a05f(ref action, null))
		{
			__ldtoken(frmMain.c35c8134a614cd8349dae8308818b1f43(object, EventArgs));
			if (c58eb8f529a8b8e52b34a6d519eb0e31b)
			{
				__ldtoken(frmMain.c35c8134a614cd8349dae8308818b1f43(object, EventArgs));
				c58eb8f529a8b8e52b34a6d519eb0e31b = false;
			}
			else
			{
				ce200544896df1b6d0f0b8e63ec1c22bf();
				c7eea724ca39738cd6aab683af7fa33ca();
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
	}

	private bool c3e3febb86a67269a738dbbf43c851fb4(Point P_0, Rectangle P_1)
	{
		bool result = false;
		if (P_0.X > P_1.Left)
		{
			if (P_0.X >= P_1.Right)
			{
				__ldtoken(frmMain.c3e3febb86a67269a738dbbf43c851fb4(Point, Rectangle));
			}
			else if (P_0.Y <= P_1.Top)
			{
				__ldtoken(frmMain.c3e3febb86a67269a738dbbf43c851fb4(Point, Rectangle));
			}
			else if (P_0.Y >= P_1.Bottom)
			{
				__ldtoken(frmMain.c3e3febb86a67269a738dbbf43c851fb4(Point, Rectangle));
			}
			else
			{
				result = true;
			}
		}
		return result;
	}

	private void c89a684d1b6b2a5a8f4b503a9cc08dff5()
	{
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject gameObject = (GameObject)enumerator.Current;
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM)
				{
					continue;
				}
				try
				{
					new Guid(gameObject.locationname);
				}
				catch
				{
					if (c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref gameObject.locationname) != null)
					{
						gameObject.locationname = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref gameObject.locationname).UniqueID.ToString();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.c89a684d1b6b2a5a8f4b503a9cc08dff5());
			}
			else
			{
				disposable.Dispose();
			}
		}
		foreach (Character character in c54f9a911545745b85ae6f74355697f8b.CharacterList)
		{
			if (!(character.CurrentRoom == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5499)))
			{
				__ldtoken(frmMain.c89a684d1b6b2a5a8f4b503a9cc08dff5());
				try
				{
					new Guid(character.CurrentRoom);
				}
				catch
				{
					if (!(character.CurrentRoom == string.Empty))
					{
						__ldtoken(frmMain.c89a684d1b6b2a5a8f4b503a9cc08dff5());
						if (c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref character.CurrentRoom) != null)
						{
							character.CurrentRoom = c54f9a911545745b85ae6f74355697f8b.GetRoomByName(ref character.CurrentRoom).UniqueID.ToString();
						}
					}
					else
					{
						character.CurrentRoom = Room.VoidRoomGuid.ToString();
					}
				}
			}
			else
			{
				character.CurrentRoom = Room.VoidRoomGuid.ToString();
			}
		}
	}

	private void c0ed19d03d655b038538119e8b019a50f(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)c6c063cbe11b4b6925518729f5693f83b).ShowDialog() == 2)
		{
			__ldtoken(frmMain.c0ed19d03d655b038538119e8b019a50f(object, EventArgs));
			return;
		}
		SaveData saveData = new SaveData();
		saveData.versionnumber = Game.ObjectVersionNumber;
		saveData.originalfilename = c33da7cbe080e8167115ce842f845e11f;
		saveData.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
		saveData.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
		saveData.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
		saveData.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
		saveData.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
		saveData.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
		saveData.StatusBarList = c54f9a911545745b85ae6f74355697f8b.StatusBarItems;
		string fileName = ((FileDialog)c6c063cbe11b4b6925518729f5693f83b).FileName;
		if (!File.Exists(fileName))
		{
			__ldtoken(frmMain.c0ed19d03d655b038538119e8b019a50f(object, EventArgs));
		}
		else
		{
			File.Copy(fileName, fileName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11156), overwrite: true);
			File.Delete(fileName);
		}
		string tempFileName = Path.GetTempFileName();
		StreamWriter streamWriter = new StreamWriter(tempFileName);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(streamWriter.BaseStream, saveData);
		streamWriter.Close();
		ce138afd2515492517555092d48124344 = File.ReadAllText(tempFileName);
		EncDec.Encrypt(tempFileName, fileName, c378defb8a060f85c4faae8445271e30a);
		File.Delete(tempFileName);
	}

	private void c88f06acab41e7a9f4773a240d3882bbb()
	{
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11165));
			if (Directory.Exists(text))
			{
				__ldtoken(frmMain.c88f06acab41e7a9f4773a240d3882bbb());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11174));
			SaveData saveData = new SaveData();
			saveData.versionnumber = Game.ObjectVersionNumber;
			saveData.originalfilename = c33da7cbe080e8167115ce842f845e11f;
			saveData.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
			saveData.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
			saveData.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
			saveData.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
			saveData.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
			saveData.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
			saveData.StatusBarList = c54f9a911545745b85ae6f74355697f8b.StatusBarItems;
			if (File.Exists(text2))
			{
				File.Copy(text2, text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11156), overwrite: true);
				File.Delete(text2);
			}
			string tempFileName = Path.GetTempFileName();
			StreamWriter streamWriter = new StreamWriter(tempFileName);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(streamWriter.BaseStream, saveData);
			streamWriter.Close();
			ce138afd2515492517555092d48124344 = File.ReadAllText(tempFileName);
			EncDec.Encrypt(tempFileName, text2, c378defb8a060f85c4faae8445271e30a);
			File.Delete(tempFileName);
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11201), Color.Black, (FontStyle)1);
		}
		catch (Exception ex)
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11230) + ex.Message);
		}
	}

	private void c9cdd06ef68ce1d568947f5942b3eeb81(object A_1, EventArgs A_2)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Invalid comparison between Unknown and I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Invalid comparison between Unknown and I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Invalid comparison between Unknown and I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected Obj, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected Obj, but got Unknown
		if ((int)((CommonDialog)c1b2228b412e398e163667e2f04172de6).ShowDialog() != 1)
		{
			return;
		}
		c6896c15b2653af6fffd4ff8146d89e43 = true;
		c6b3a3de4d57a8165b8fdcc3d9f422445(null, null);
		cb6bf42077ef94e4a63840b4283588ed0();
		MemoryStream memst = new MemoryStream();
		CryptoStream cs = null;
		EncDec.Decrypt(((FileDialog)c1b2228b412e398e163667e2f04172de6).FileName, ref memst, ref cs, c378defb8a060f85c4faae8445271e30a);
		memst.Seek(0L, SeekOrigin.Begin);
		StreamReader streamReader = new StreamReader(memst);
		ce138afd2515492517555092d48124344 = streamReader.ReadToEnd();
		streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
		SaveData saveData = (SaveData)new BinaryFormatter().Deserialize(streamReader.BaseStream);
		streamReader.Close();
		streamReader.Dispose();
		cs.Close();
		cs.Dispose();
		if (saveData.originalfilename != c33da7cbe080e8167115ce842f845e11f)
		{
			DialogResult val = (DialogResult)7;
			if (c33da7cbe080e8167115ce842f845e11f != string.Empty)
			{
				val = MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11267) + saveData.originalfilename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11354), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11488), (MessageBoxButtons)3);
			}
			if ((int)val == 2)
			{
				return;
			}
			if ((int)val == 7)
			{
				if (!File.Exists(saveData.originalfilename))
				{
					MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11525) + saveData.originalfilename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11580), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11665));
					((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName = Path.GetFileName(saveData.originalfilename);
					if ((int)((CommonDialog)c65a80a92021b1ba189aaec42668c1427).ShowDialog() != 1)
					{
						return;
					}
					saveData.originalfilename = ((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName;
				}
				bool flag = false;
				try
				{
					c33da7cbe080e8167115ce842f845e11f = saveData.originalfilename;
					Game.DBName = saveData.originalfilename;
					Game.GetDBConnection();
					c54f9a911545745b85ae6f74355697f8b = new Game(c33da7cbe080e8167115ce842f845e11f);
					while (!Game.bDoneWithWaitDlg)
					{
						Application.DoEvents();
					}
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d = new SaveData();
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.versionnumber = Game.ObjectVersionNumber;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.originalfilename = c33da7cbe080e8167115ce842f845e11f;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.CharacterList = c54f9a911545745b85ae6f74355697f8b.CharacterList;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ObjectList = c54f9a911545745b85ae6f74355697f8b.ObjectList;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.RoomList = c54f9a911545745b85ae6f74355697f8b.RoomList;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.ThePlayer = c54f9a911545745b85ae6f74355697f8b.ThePlayer;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.VariableList = c54f9a911545745b85ae6f74355697f8b.VariableList;
					c8e46d07aa274d2f5d4b9a9d2a2a1dd6d.TimerList = c54f9a911545745b85ae6f74355697f8b.TimerList;
					binaryFormatter.Serialize(c45a8f1ad7b2f5a62f3d0bb71126882ca, c8e46d07aa274d2f5d4b9a9d2a2a1dd6d);
				}
				catch
				{
					flag = true;
				}
				if (flag)
				{
					MemoryStream memst2 = new MemoryStream();
					CryptoStream cs2 = null;
					EncDec.Decrypt(saveData.originalfilename, ref memst2, ref cs2, c378defb8a060f85c4faae8445271e30a);
					memst2.Seek(0L, SeekOrigin.Begin);
					c54f9a911545745b85ae6f74355697f8b = null;
					if (c54f9a911545745b85ae6f74355697f8b == null)
					{
						memst2.Seek(0L, SeekOrigin.Begin);
						c54f9a911545745b85ae6f74355697f8b = (Game)new BinaryFormatter().Deserialize(memst2);
						GameObject.TheGame = c54f9a911545745b85ae6f74355697f8b;
						Character.TheGame = c54f9a911545745b85ae6f74355697f8b;
					}
					memst2.Close();
					memst2.Dispose();
					cs2.Close();
					cs2.Dispose();
				}
			}
			if (c7a0eae8ab4f7ef78712f593022ef41d1.Checked)
			{
				Font val2 = null;
				try
				{
					string text = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5330), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347));
					if (text == null)
					{
						text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347);
					}
					if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347))
					{
						val2 = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
					}
					else
					{
						string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
						val2 = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
					}
				}
				catch
				{
					val2 = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
				}
				((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = val2;
			}
			else
			{
				((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = c54f9a911545745b85ae6f74355697f8b.GameFont;
			}
			c89a684d1b6b2a5a8f4b503a9cc08dff5();
			c54f9a911545745b85ae6f74355697f8b.CorrectCommandAndConditions();
		}
		((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = true;
		if (saveData.originalfilename != c33da7cbe080e8167115ce842f845e11f)
		{
			cbdf4511b61938d6ccdac6d22c0aa287f(ref saveData);
		}
		else
		{
			c33da7cbe080e8167115ce842f845e11f = saveData.originalfilename;
			c54f9a911545745b85ae6f74355697f8b.CharacterList = saveData.CharacterList;
			c54f9a911545745b85ae6f74355697f8b.ObjectList = saveData.ObjectList;
			c54f9a911545745b85ae6f74355697f8b.RoomList = saveData.RoomList;
			c54f9a911545745b85ae6f74355697f8b.ThePlayer = saveData.ThePlayer;
			c54f9a911545745b85ae6f74355697f8b.VariableList = saveData.VariableList;
			c54f9a911545745b85ae6f74355697f8b.TimerList = saveData.TimerList;
			c54f9a911545745b85ae6f74355697f8b.StatusBarItems = saveData.StatusBarList;
		}
		((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5266) + Path.GetFileName(saveData.originalfilename) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5327) + Game.CurrentObjectVersionNumber;
		cfc246fc898e127948f3219ddb6ca1a07();
		c5386af86084f85e6ad20a73f6fe78b74();
		cbc7ad2fc50dfbe4191690a255afd70e4();
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait, false);
		cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerLayeredImage, true);
		c6df55a7ba938a3b24d6b7592b94240ea(true, false);
		if (c54f9a911545745b85ae6f74355697f8b.bgMusic != string.Empty)
		{
			object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.bgMusic);
			if (pictureByName != null && pictureByName is string uRL)
			{
				c5722e0b047bf80ee8a41d6d5ca3a5b06.URL = uRL;
			}
		}
		c6896c15b2653af6fffd4ff8146d89e43 = false;
	}

	private void c6477fea51cc2c450d5ed6371d10cf406()
	{
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected Obj, but got Unknown
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Invalid comparison between Unknown and I4
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected Obj, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected Obj, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Invalid comparison between Unknown and I4
		try
		{
			c6896c15b2653af6fffd4ff8146d89e43 = true;
			c6b3a3de4d57a8165b8fdcc3d9f422445(null, null);
			cb6bf42077ef94e4a63840b4283588ed0();
			MemoryStream memst = new MemoryStream();
			CryptoStream cs = null;
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11165));
			if (Directory.Exists(text))
			{
				__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string fileIn = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11174));
			EncDec.Decrypt(fileIn, ref memst, ref cs, c378defb8a060f85c4faae8445271e30a);
			memst.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memst);
			ce138afd2515492517555092d48124344 = streamReader.ReadToEnd();
			streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			SaveData saveData = (SaveData)binaryFormatter.Deserialize(streamReader.BaseStream);
			streamReader.Close();
			streamReader.Dispose();
			cs.Close();
			cs.Dispose();
			if (!(saveData.originalfilename != c33da7cbe080e8167115ce842f845e11f))
			{
				__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
			}
			else
			{
				DialogResult val = (DialogResult)7;
				if (!(c33da7cbe080e8167115ce842f845e11f != string.Empty))
				{
					__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
				}
				else
				{
					val = MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11267) + saveData.originalfilename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11354), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11488), (MessageBoxButtons)3);
				}
				if ((int)val == 2)
				{
					return;
				}
				__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
				if ((int)val != 7)
				{
					__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
				}
				else
				{
					if (File.Exists(saveData.originalfilename))
					{
						__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
					}
					else
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11525) + saveData.originalfilename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11580), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11665));
						((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName = Path.GetFileName(saveData.originalfilename);
						if ((int)((CommonDialog)c65a80a92021b1ba189aaec42668c1427).ShowDialog() != 1)
						{
							return;
						}
						saveData.originalfilename = ((FileDialog)c65a80a92021b1ba189aaec42668c1427).FileName;
					}
					bool flag = false;
					try
					{
						c33da7cbe080e8167115ce842f845e11f = saveData.originalfilename;
						Game.DBName = saveData.originalfilename;
						Game.GetDBConnection();
						c54f9a911545745b85ae6f74355697f8b = new Game(c33da7cbe080e8167115ce842f845e11f);
						GameObject.TheGame = c54f9a911545745b85ae6f74355697f8b;
						Character.TheGame = c54f9a911545745b85ae6f74355697f8b;
						while (!Game.bDoneWithWaitDlg)
						{
							__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
							Application.DoEvents();
						}
					}
					catch
					{
						flag = true;
					}
					if (flag)
					{
						MemoryStream memst2 = new MemoryStream();
						CryptoStream cs2 = null;
						EncDec.Decrypt(saveData.originalfilename, ref memst2, ref cs2, c378defb8a060f85c4faae8445271e30a);
						memst2.Seek(0L, SeekOrigin.Begin);
						c54f9a911545745b85ae6f74355697f8b = null;
						if (c54f9a911545745b85ae6f74355697f8b != null)
						{
							__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
						}
						else
						{
							memst2.Seek(0L, SeekOrigin.Begin);
							binaryFormatter = new BinaryFormatter();
							c54f9a911545745b85ae6f74355697f8b = (Game)binaryFormatter.Deserialize(memst2);
							GameObject.TheGame = c54f9a911545745b85ae6f74355697f8b;
							Character.TheGame = c54f9a911545745b85ae6f74355697f8b;
						}
						memst2.Close();
						memst2.Dispose();
						cs2.Close();
						cs2.Dispose();
					}
				}
				if (!c7a0eae8ab4f7ef78712f593022ef41d1.Checked)
				{
					__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
					((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = c54f9a911545745b85ae6f74355697f8b.GameFont;
				}
				else
				{
					Font val2 = null;
					try
					{
						string text2 = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5330), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347));
						if (text2 == null)
						{
							text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347);
						}
						if (!(text2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347)))
						{
							__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
							string[] array = text2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
							val2 = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
						}
						else
						{
							val2 = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
						}
					}
					catch
					{
						val2 = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
					}
					((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = val2;
				}
				c89a684d1b6b2a5a8f4b503a9cc08dff5();
				c54f9a911545745b85ae6f74355697f8b.CorrectCommandAndConditions();
			}
			((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = true;
			if (!(saveData.originalfilename != c33da7cbe080e8167115ce842f845e11f))
			{
				__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
				c33da7cbe080e8167115ce842f845e11f = saveData.originalfilename;
				c54f9a911545745b85ae6f74355697f8b.CharacterList = saveData.CharacterList;
				c54f9a911545745b85ae6f74355697f8b.ObjectList = saveData.ObjectList;
				c54f9a911545745b85ae6f74355697f8b.RoomList = saveData.RoomList;
				c54f9a911545745b85ae6f74355697f8b.ThePlayer = saveData.ThePlayer;
				c54f9a911545745b85ae6f74355697f8b.VariableList = saveData.VariableList;
				c54f9a911545745b85ae6f74355697f8b.TimerList = saveData.TimerList;
				c54f9a911545745b85ae6f74355697f8b.StatusBarItems = saveData.StatusBarList;
			}
			else
			{
				cbdf4511b61938d6ccdac6d22c0aa287f(ref saveData);
			}
			((Control)this).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5266) + Path.GetFileName(saveData.originalfilename) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5327) + Game.CurrentObjectVersionNumber;
			cfc246fc898e127948f3219ddb6ca1a07();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerPortrait, false);
			cd1b65fe2bdd9970fe28973afcd9bb52e(c54f9a911545745b85ae6f74355697f8b.ThePlayer.PlayerLayeredImage, true);
			c6df55a7ba938a3b24d6b7592b94240ea(true, false);
			if (!(c54f9a911545745b85ae6f74355697f8b.bgMusic != string.Empty))
			{
				__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
			}
			else
			{
				object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(c54f9a911545745b85ae6f74355697f8b.bgMusic);
				if (pictureByName != null)
				{
					if (!(pictureByName is string uRL))
					{
						__ldtoken(frmMain.c6477fea51cc2c450d5ed6371d10cf406());
					}
					else
					{
						c5722e0b047bf80ee8a41d6d5ca3a5b06.URL = uRL;
					}
				}
			}
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11712), Color.Black, (FontStyle)1);
			c6896c15b2653af6fffd4ff8146d89e43 = false;
		}
		catch (Exception ex)
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11745) + ex.Message);
		}
	}

	private void c6211da2da5bd7e3ad792ccac21e533f0(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 2097152)
		{
			__ldtoken(frmMain.c6211da2da5bd7e3ad792ccac21e533f0(object, MouseEventArgs));
			return;
		}
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.c6211da2da5bd7e3ad792ccac21e533f0(object, MouseEventArgs));
			return;
		}
		ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c4c08a3f00c9c0c5e2811fbf9e3f4dc18;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)cb132670a816ec2a8a287804bae7180f0, P_1.X, P_1.Y);
	}

	private void c50437275bb962f79ed86c48b48ee00b7(object P_0, EventArgs P_1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		c3f5f38119991c762ea85ad43a8e2974e c3f5f38119991c762ea85ad43a8e2974e2 = new c3f5f38119991c762ea85ad43a8e2974e();
		((Form)c3f5f38119991c762ea85ad43a8e2974e2).ShowDialog();
	}

	private void c102b48b73d466a5baf7ab446bdde2988(object P_0, EventArgs P_1)
	{
		((Form)this).Close();
	}

	private void c6f15da1c4c76a69a0fbe9f20fb39fe5f(object P_0, CancelEventArgs P_1)
	{
	}

	private void c4120afb9054a553bfa24e2e67ee3e547(object P_0, EventArgs P_1)
	{
	}

	private void c23e9ff31cfc9f1f1112c8d642cac582e(object A_1, FormClosingEventArgs A_2)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		cdf909c325e9747ba13bd06e252281065();
		DialogResult val = MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11798), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4984), (MessageBoxButtons)4, (MessageBoxIcon)32, (MessageBoxDefaultButton)256);
		if ((int)val == 6)
		{
			((CancelEventArgs)(object)A_2).Cancel = true;
		}
		else if ((int)val == 2)
		{
			((CancelEventArgs)(object)A_2).Cancel = true;
		}
		else
		{
			cdf909c325e9747ba13bd06e252281065();
			c6896c15b2653af6fffd4ff8146d89e43 = true;
			cb6bf42077ef94e4a63840b4283588ed0();
		}
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			return;
		}
		foreach (GamePicture picture in c54f9a911545745b85ae6f74355697f8b.PictureList)
		{
			string[] files = Directory.GetFiles(Path.GetTempPath(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11895) + picture.TheName);
			foreach (string path in files)
			{
				try
				{
					File.Delete(path);
				}
				catch
				{
				}
			}
		}
	}

	private void cb992719702982eef1744afbb3520579b(object P_0, EventArgs P_1)
	{
		c7e4fd81c04898c7b095bdea8a5d00176();
		c378defb8a060f85c4faae8445271e30a = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11898);
		string text = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11919), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950));
		if (text != null)
		{
			__ldtoken(frmMain.cb992719702982eef1744afbb3520579b(object, EventArgs));
		}
		else
		{
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950);
		}
		if (string.Compare(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950), ignoreCase: true) != 0)
		{
			__ldtoken(frmMain.cb992719702982eef1744afbb3520579b(object, EventArgs));
			c0bb4beb7ba78f7e6293c3610221e13f1.Checked = false;
		}
		else
		{
			ThreadPool.QueueUserWorkItem(cbd1628fa51f1ffb7a7e22c7466ebefd0, c54f9a911545745b85ae6f74355697f8b);
			c0bb4beb7ba78f7e6293c3610221e13f1.Checked = true;
		}
		text = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11959), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950));
		if (text != null)
		{
			__ldtoken(frmMain.cb992719702982eef1744afbb3520579b(object, EventArgs));
		}
		else
		{
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11992);
		}
		if (string.Compare(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950), ignoreCase: true) == 0)
		{
			c7a0eae8ab4f7ef78712f593022ef41d1.Checked = true;
		}
		else
		{
			c7a0eae8ab4f7ef78712f593022ef41d1.Checked = false;
		}
	}

	private static void cbd1628fa51f1ffb7a7e22c7466ebefd0(object P_0)
	{
		try
		{
			CheckUpdates checkUpdates = new CheckUpdates();
			string version = checkUpdates.CheckVersion();
			Version version2 = new Version(version);
			Version version3 = new Version(Game.ObjectVersionNumber);
			if (!(version2 > version3))
			{
				__ldtoken(frmMain.cbd1628fa51f1ffb7a7e22c7466ebefd0(object));
			}
			else
			{
				c1aed702d520ff4bdb6f08d5bfec063b0 = true;
			}
		}
		catch
		{
		}
	}

	private void c6c81e57d710c9ddb0da56132be15a894(object P_0, EventArgs P_1)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		if (c1aed702d520ff4bdb6f08d5bfec063b0)
		{
			c1aed702d520ff4bdb6f08d5bfec063b0 = false;
			if ((int)MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12003), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12173), (MessageBoxButtons)4) != 6)
			{
				__ldtoken(frmMain.c6c81e57d710c9ddb0da56132be15a894(object, EventArgs));
			}
			else
			{
				Process.Start(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12206), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12231));
			}
		}
	}

	private void c1b72005134c4f14e574c7d432793b95f(object P_0, EventArgs P_1)
	{
		c0bb4beb7ba78f7e6293c3610221e13f1.Checked = !c0bb4beb7ba78f7e6293c3610221e13f1.Checked;
		if (!c0bb4beb7ba78f7e6293c3610221e13f1.Checked)
		{
			__ldtoken(frmMain.c1b72005134c4f14e574c7d432793b95f(object, EventArgs));
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11919), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11992));
		}
		else
		{
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11919), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950));
		}
	}

	private void c18553bcfcde941590af10fb86b3e5ce1()
	{
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Enabled = true;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Focus();
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = false;
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = false;
		((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = false;
		((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = false;
		while (true)
		{
			if (!((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Enabled)
			{
				__ldtoken(frmMain.c18553bcfcde941590af10fb86b3e5ce1());
				break;
			}
			if (!c6896c15b2653af6fffd4ff8146d89e43)
			{
				Application.DoEvents();
				Thread.Sleep(50);
				continue;
			}
			break;
		}
	}

	private void c6b3a3de4d57a8165b8fdcc3d9f422445(object P_0, EventArgs P_1)
	{
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Enabled = true;
		((Control)c7e94bd5608b35a111c3be9ab9ba47dea).Enabled = false;
		((Control)ce5ffb7119f6a87128fa80a3d493311b2).Enabled = true;
		((Control)c0970743bbfbc89b095632fb02680fc3b).Enabled = true;
		((Control)cb132670a816ec2a8a287804bae7180f0).Enabled = true;
	}

	private void cd1b65fe2bdd9970fe28973afcd9bb52e(string P_0, bool P_1)
	{
		if (P_0 == string.Empty)
		{
			return;
		}
		__ldtoken(frmMain.cd1b65fe2bdd9970fe28973afcd9bb52e(string, bool));
		P_0 = c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0, null);
		object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(P_0);
		if (pictureByName != null)
		{
			Image val = (Image)((pictureByName is Image) ? pictureByName : null);
			if (val == null)
			{
				__ldtoken(frmMain.cd1b65fe2bdd9970fe28973afcd9bb52e(string, bool));
				((Control)c33008150af74fd263d1c473a79b9a051).Visible = true;
				((Control)cb132670a816ec2a8a287804bae7180f0).Visible = false;
				c33008150af74fd263d1c473a79b9a051.URL = pictureByName as string;
				return;
			}
			((Control)c33008150af74fd263d1c473a79b9a051).Visible = false;
			((Control)cb132670a816ec2a8a287804bae7180f0).Visible = true;
			if (!P_1)
			{
				__ldtoken(frmMain.cd1b65fe2bdd9970fe28973afcd9bb52e(string, bool));
				((Control)cb132670a816ec2a8a287804bae7180f0).Tag = c54f9a911545745b85ae6f74355697f8b.GetGamePictureByName(P_0);
				((Control)cb132670a816ec2a8a287804bae7180f0).BackgroundImage = val;
			}
			else
			{
				cb132670a816ec2a8a287804bae7180f0.Image = val;
			}
		}
		else
		{
			((Control)c33008150af74fd263d1c473a79b9a051).Visible = false;
			((Control)cb132670a816ec2a8a287804bae7180f0).Visible = true;
			cb132670a816ec2a8a287804bae7180f0.Image = null;
			((Control)cb132670a816ec2a8a287804bae7180f0).BackgroundImage = null;
		}
	}

	private void cc72ed556db2ad67868ce8d5c2e3a6c23(object P_0, EventArgs P_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)c0ac8afaf8508709341f33bd2b7335b6d).ShowDialog() != 1)
		{
			__ldtoken(frmMain.cc72ed556db2ad67868ce8d5c2e3a6c23(object, EventArgs));
		}
		else
		{
			c00ef783f3ec99f0de8db7e2bfe179e24.SaveFile(((FileDialog)c0ac8afaf8508709341f33bd2b7335b6d).FileName);
		}
	}

	private void c5c4b79a4344c161f0e92b29e3a6d644e(object P_0, EventArgs P_1)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length <= 1)
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
			return;
		}
		string text = Environment.GetCommandLineArgs()[1];
		if (text == null)
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
		}
		else
		{
			((Control)cfd270873d0825c1e058bf1297e4314cf).Enabled = true;
			c33da7cbe080e8167115ce842f845e11f = text;
			if (!File.Exists(text))
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12308) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12375));
				return;
			}
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
			cfd2619d4c79d66471f6028e1a52a2657(text);
			cfc246fc898e127948f3219ddb6ca1a07();
			c7eea724ca39738cd6aab683af7fa33ca();
		}
		if (commandLineArgs.Length <= 2)
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
			return;
		}
		if (!(Environment.GetCommandLineArgs()[2] == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(4890)))
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
			return;
		}
		if (c45335acf471afc831c5b4bad4cbe5394 == null)
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
			return;
		}
		if (!(ce1dd62a9561b11a074dea91d93c56cc4 != string.Empty))
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
		}
		else
		{
			((Control)c45335acf471afc831c5b4bad4cbe5394).Height = Convert.ToInt32(ce1dd62a9561b11a074dea91d93c56cc4);
		}
		if (!(ceeb96703a6f8cb4eca673e1d86effeff != string.Empty))
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
		}
		else
		{
			((Control)c45335acf471afc831c5b4bad4cbe5394).Left = Convert.ToInt32(ceeb96703a6f8cb4eca673e1d86effeff);
		}
		if (!(c6d6b6dce042e1f00ba882a716c6b9ad4 != string.Empty))
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
		}
		else
		{
			((Control)c45335acf471afc831c5b4bad4cbe5394).Top = Convert.ToInt32(c6d6b6dce042e1f00ba882a716c6b9ad4);
		}
		if (!(c8f7702f4ce4645c290445315e222631e != string.Empty))
		{
			__ldtoken(frmMain.c5c4b79a4344c161f0e92b29e3a6d644e(object, EventArgs));
		}
		else
		{
			((Control)c45335acf471afc831c5b4bad4cbe5394).Width = Convert.ToInt32(c8f7702f4ce4645c290445315e222631e);
		}
	}

	private void c355d591fa02d1e3066e11daae0af90a3(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.Button != 2097152)
		{
			__ldtoken(frmMain.c355d591fa02d1e3066e11daae0af90a3(object, MouseEventArgs));
			return;
		}
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.c355d591fa02d1e3066e11daae0af90a3(object, MouseEventArgs));
			return;
		}
		ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c7d09946dbb22579280d3e849becda121;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)c0970743bbfbc89b095632fb02680fc3b, P_1.X, P_1.Y);
	}

	private void c2d4da1c23deb5fce0b180fa7696a90e4(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if ((int)P_1.Button == 2097152)
		{
			((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				__ldtoken(frmMain.c2d4da1c23deb5fce0b180fa7696a90e4(object, MouseEventArgs));
				return;
			}
			ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
			c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c7d09946dbb22579280d3e849becda121;
			((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)c568e1c3a8d35460b6f9f9e370d7f266a, P_1.X, P_1.Y);
		}
	}

	private void c23288cf266da6377f6c5d709b4bf0623(object P_0, EventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		ToolStripMenuItem val = (ToolStripMenuItem)P_0;
		Action action = ((ToolStripItem)val).Tag as Action;
		if (action == null)
		{
			__ldtoken(frmMain.c23288cf266da6377f6c5d709b4bf0623(object, EventArgs));
			return;
		}
		c0c9975317d693fd5f4e3431f15ff3ea2();
		TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6011) + c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.GetName() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5985) + ((ToolStripItem)val).Text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5143), Color.Black, (FontStyle)1);
		if (c9cff05a07825c588d9efb7028802a05f(ref action, null))
		{
			__ldtoken(frmMain.c23288cf266da6377f6c5d709b4bf0623(object, EventArgs));
			if (!c58eb8f529a8b8e52b34a6d519eb0e31b)
			{
				ce200544896df1b6d0f0b8e63ec1c22bf();
				c7eea724ca39738cd6aab683af7fa33ca();
			}
			else
			{
				c58eb8f529a8b8e52b34a6d519eb0e31b = false;
			}
			c16f20f19536af362c5e437fe3b72ea8b();
			c5386af86084f85e6ad20a73f6fe78b74();
			cbc7ad2fc50dfbe4191690a255afd70e4();
			cdb7eb588a870d047a196c0b2bc01bfdf();
		}
	}

	private void c7dea9ee981604c89a531f27c4321ce22(object P_0, EventArgs P_1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		QuickHelp quickHelp = new QuickHelp();
		((Form)quickHelp).ShowDialog();
	}

	private void c4d3f860e96fe43d6599bdd81b2f608fc(object P_0, EventArgs P_1)
	{
	}

	private void c86da970f77bed769ed9498f04d14cca1(object P_0, EventArgs P_1)
	{
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			__ldtoken(frmMain.c86da970f77bed769ed9498f04d14cca1(object, EventArgs));
			c0c9975317d693fd5f4e3431f15ff3ea2();
			c51279ee02a1043fe19c2f931ed627109 = false;
			c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.In;
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12470), Color.Black, (FontStyle)1);
			if (!c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
			{
				c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
				c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
			}
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
			if (!c51279ee02a1043fe19c2f931ed627109)
			{
				c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.In);
				c6df55a7ba938a3b24d6b7592b94240ea(true, true);
			}
			c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
		}
	}

	private void c1ffb072babd0a99b470b40e0d57c5607(object P_0, EventArgs P_1)
	{
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			__ldtoken(frmMain.c1ffb072babd0a99b470b40e0d57c5607(object, EventArgs));
			c0c9975317d693fd5f4e3431f15ff3ea2();
			c51279ee02a1043fe19c2f931ed627109 = false;
			c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Out;
			TextHandlers.AddTextToRTF(ref c00ef783f3ec99f0de8db7e2bfe179e24, ref c54f9a911545745b85ae6f74355697f8b, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12479), Color.Black, (FontStyle)1);
			if (c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime)
			{
				__ldtoken(frmMain.c1ffb072babd0a99b470b40e0d57c5607(object, EventArgs));
			}
			else
			{
				c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.bLeaveFirstTime = true;
				c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5715));
			}
			c4396f8f427ccc36a88d9c5559fc6269c(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5776));
			if (!c51279ee02a1043fe19c2f931ed627109)
			{
				c54f9a911545745b85ae6f74355697f8b.MovePlayer(Exit.Directions.Out);
				c6df55a7ba938a3b24d6b7592b94240ea(true, true);
			}
			c780fb3b6ad9bc450e9847a471ce8438a = Exit.Directions.Empty;
		}
	}

	private void cf2814865aea5c42c5877a6fc75214d7f(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected I4, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected I4, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected I4, but got Unknown
		Keys keyData = P_1.KeyData;
		if ((int)keyData <= 46)
		{
			if ((int)keyData == 13)
			{
				__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				c6b3a3de4d57a8165b8fdcc3d9f422445(null, null);
				return;
			}
			switch (keyData - 33)
			{
			case 12:
				if (!((Control)ce764cacadcb2bc3fd4bdd3b3355f0610).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c86da970f77bed769ed9498f04d14cca1(null, null);
				}
				break;
			case 13:
				if (!((Control)c550ba434b320f806a8f4645040b88e72).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c1ffb072babd0a99b470b40e0d57c5607(null, null);
				}
				break;
			case 5:
				if (!((Control)cd4c5cd27cd40059e2a3eeabdc85952d6).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c1d8e4bd213ff6989c2d4e9f1a3429152(null, null);
				}
				break;
			case 7:
				if (!((Control)c90c65c890556f98316961b88b452411c).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c9ee62976d23275acb96584ca30167825(null, null);
				}
				break;
			case 4:
				if (!((Control)c19001e7fd0fb0231ceafdb91b7fc553c).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					cb6b0e134e59bef02adee8a8232f5ac4d(null, null);
				}
				break;
			case 6:
				if (!((Control)cecc2bca13f554623b27fef0a7612d89a).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					ca3371f019d49945be20fb7007425cba1(null, null);
				}
				break;
			case 3:
				if (((Control)c8458b8759f70d83b69ed336abafed87d).Visible)
				{
					c4cdd8c69b0fb57b72c6bbbd30ae74794(null, null);
				}
				break;
			case 0:
				if (!((Control)c380ea8b92cbdb7629b6ba12210334b71).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c3795d553a32d3287242f9de094167d49(null, null);
				}
				break;
			case 2:
				if (!((Control)c40520cf7b831e6aa4bb0ebd41a9bed10).Visible)
				{
					__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
				}
				else
				{
					c98b0d6e2d3e2f95dc20b0ef21fade4fc(null, null);
				}
				break;
			case 1:
				if (((Control)cf4a085f96b5e3008906285bfac50d314).Visible)
				{
					c5f280b879521f714f8b5aa4febb03da7(null, null);
				}
				break;
			case 8:
			case 9:
			case 10:
			case 11:
				break;
			}
			return;
		}
		switch (keyData - 107)
		{
		case 2:
			if (((Control)cb16a9ba7ac8e9ac3aba347a7de4e234c).Visible)
			{
				c78a0ed8b2d5c43d6cfea40c0e620bea4(null, null);
			}
			return;
		case 0:
			if (!((Control)c9e0726c3f64d9712d80f7f792ba03c24).Visible)
			{
				__ldtoken(frmMain.cf2814865aea5c42c5877a6fc75214d7f(object, KeyEventArgs));
			}
			else
			{
				cd51509c3a929c396af62c1b408d2b330(null, null);
			}
			return;
		case 1:
			return;
		}
		switch (keyData - 119)
		{
		case 0:
			c88f06acab41e7a9f4773a240d3882bbb();
			break;
		case 1:
			c6477fea51cc2c450d5ed6371d10cf406();
			break;
		}
	}

	private void ccfb1a20dd02bc858d11708b4c20ce125(object P_0, EventArgs P_1)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12490), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12513), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12538), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12581), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12667), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12710), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12753), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(877), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(900), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(925), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(952), "");
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12788), ((object)(FormWindowState)0).ToString());
			cdec29256e27e81fd403d83624067c843 = true;
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12811));
		}
		catch
		{
		}
	}

	private void cdf909c325e9747ba13bd06e252281065()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		if (cdec29256e27e81fd403d83624067c843)
		{
			__ldtoken(frmMain.cdf909c325e9747ba13bd06e252281065());
			return;
		}
		try
		{
			new List<string>();
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11165));
			if (Directory.Exists(text))
			{
				__ldtoken(frmMain.cdf909c325e9747ba13bd06e252281065());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13005));
			if (File.Exists(text2))
			{
				__ldtoken(frmMain.cdf909c325e9747ba13bd06e252281065());
			}
			else
			{
				string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13034);
				File.WriteAllText(text2, contents);
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text2);
			XmlNodeList xmlNodeList = null;
			XmlElement xmlElement = null;
			_ = string.Empty;
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13099));
			xmlElement = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13158));
			if ((int)((Form)this).WindowState == 0)
			{
				XmlElement xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13204));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ((Form)this).Size.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13213));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ((Form)this).Location.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12538));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), c98dd8245994cd868d7cdfd180f7f9422.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12581));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), cfdd28b747afbe52686772d0eed813027.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), c2a161da002bb8cdd90af79c65bcd8c5f.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12667));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ce61fe8d9cdcafc2156cfec2a32c534a8.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12710));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ccce410b3d22b32644c265746b0aef4bc.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
				xmlElement2 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12753));
				xmlElement2.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ce5ffb7119f6a87128fa80a3d493311b2.SplitterDistance.ToString());
				xmlElement.AppendChild(xmlElement2);
			}
			XmlElement xmlElement3 = xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13189));
			xmlElement3.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12788));
			xmlElement3.SetAttribute(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229), ((object)((Form)this).WindowState).ToString());
			xmlElement.AppendChild(xmlElement3);
			if (xmlNodeList[0] != null)
			{
				XmlNode xmlNode = xmlNodeList[0];
				xmlNode.ParentNode.ReplaceChild(xmlElement, xmlNode);
			}
			else
			{
				xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13230));
				if (xmlNodeList[0] == null)
				{
					__ldtoken(frmMain.cdf909c325e9747ba13bd06e252281065());
				}
				else
				{
					xmlNodeList[0].AppendChild(xmlElement);
				}
			}
			xmlDocument.Save(text2);
		}
		catch
		{
		}
	}

	private void c7e4fd81c04898c7b095bdea8a5d00176()
	{
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Form)this).StartPosition = (FormStartPosition)0;
			new List<string>();
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11165));
			if (Directory.Exists(text))
			{
				__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13005));
			if (File.Exists(text2))
			{
				__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
			}
			else
			{
				string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13034);
				File.WriteAllText(text2, contents);
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text2);
			XmlNodeList xmlNodeList = null;
			_ = string.Empty;
			xmlNodeList = xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13099));
			xmlDocument.CreateElement(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13158));
			if (xmlNodeList.Count <= 0)
			{
				return;
			}
			IEnumerator enumerator = xmlNodeList[0].ChildNodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string text3 = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(205)].Value.ToString();
					if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13213)))
					{
						__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
						if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13204)))
						{
							__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
							if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12788)))
							{
								__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
							}
							else
							{
								((Form)this).WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229)].Value.ToString());
							}
							continue;
						}
						string value = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229)].Value;
						string[] array = value.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
						if (array.Length != 2)
						{
							__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
							continue;
						}
						int width = Convert.ToInt32(array[0].Substring(7));
						int height = Convert.ToInt32(array[1].Substring(8, array[1].Length - 9));
						((Form)this).Size = new Size(width, height);
					}
					else
					{
						string value2 = xmlNode.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(229)].Value;
						string[] array2 = value2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
						if (array2.Length != 2)
						{
							__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
							continue;
						}
						int x = Convert.ToInt32(array2[0].Substring(3));
						int y = Convert.ToInt32(array2[1].Substring(2, array2[1].Length - 3));
						((Form)this).Location = new Point(x, y);
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(frmMain.c7e4fd81c04898c7b095bdea8a5d00176());
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		catch
		{
		}
	}

	private bool cafb873e7a7764c34105fb90b87e6b67f(ref GameObject P_0)
	{
		GameObject gameObject = null;
		IEnumerator enumerator = c54f9a911545745b85ae6f74355697f8b.ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject gameObject2 = (GameObject)enumerator.Current;
				if (!(gameObject2.name == P_0.locationname))
				{
					__ldtoken(frmMain.cafb873e7a7764c34105fb90b87e6b67f(ref GameObject));
					continue;
				}
				gameObject = gameObject2;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.cafb873e7a7764c34105fb90b87e6b67f(ref GameObject));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (gameObject != null)
		{
			if (gameObject.locationtype != GameObject.LocationType.LT_PLAYER)
			{
				__ldtoken(frmMain.cafb873e7a7764c34105fb90b87e6b67f(ref GameObject));
				if (gameObject.locationtype != GameObject.LocationType.LT_IN_OBJECT)
				{
					__ldtoken(frmMain.cafb873e7a7764c34105fb90b87e6b67f(ref GameObject));
					return false;
				}
				return cafb873e7a7764c34105fb90b87e6b67f(ref gameObject);
			}
			return true;
		}
		return false;
	}

	private void ca12fb0d6a51a36ae97f9f54fc384e193(object P_0, EventArgs P_1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			cc8264b1067fe196be453410d7902dac7.Font = c54f9a911545745b85ae6f74355697f8b.GameFont;
			if ((int)((CommonDialog)cc8264b1067fe196be453410d7902dac7).ShowDialog() != 1)
			{
				__ldtoken(frmMain.ca12fb0d6a51a36ae97f9f54fc384e193(object, EventArgs));
				return;
			}
			((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = cc8264b1067fe196be453410d7902dac7.Font;
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5330), cc8264b1067fe196be453410d7902dac7.Font);
		}
	}

	private void c321c719912aa828d82aad7b6d9560568(object P_0, EventArgs P_1)
	{
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		c7a0eae8ab4f7ef78712f593022ef41d1.Checked = !c7a0eae8ab4f7ef78712f593022ef41d1.Checked;
		if (!c7a0eae8ab4f7ef78712f593022ef41d1.Checked)
		{
			__ldtoken(frmMain.c321c719912aa828d82aad7b6d9560568(object, EventArgs));
			Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11959), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11992));
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				__ldtoken(frmMain.c321c719912aa828d82aad7b6d9560568(object, EventArgs));
			}
			else
			{
				((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = c54f9a911545745b85ae6f74355697f8b.GameFont;
			}
			return;
		}
		Registry.SetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11959), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11950));
		Font val = null;
		try
		{
			string text = (string)Registry.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(814), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5330), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347));
			if (text == null)
			{
				text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347);
			}
			if (text == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347))
			{
				val = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
			}
			else
			{
				string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1535) }, StringSplitOptions.None);
				val = new Font(array[0].Substring(12), (float)Convert.ToDouble(array[1].Substring(6)));
			}
		}
		catch
		{
			val = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5356), 12f);
		}
		((Control)c00ef783f3ec99f0de8db7e2bfe179e24).Font = val;
	}

	private void c5f05f948b6dd5d73987a126226860558(object P_0, EventArgs P_1)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			GameInfoFrm gameInfoFrm = new GameInfoFrm(c54f9a911545745b85ae6f74355697f8b.AuthorName, c54f9a911545745b85ae6f74355697f8b.GameVersion, c54f9a911545745b85ae6f74355697f8b.GameInformation);
			((Form)gameInfoFrm).ShowDialog();
		}
	}

	private void c56e83298800ce5f50e7fb1366a23f334(object P_0, EventArgs P_1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		RagsShare ragsShare = new RagsShare();
		((Form)ragsShare).ShowDialog();
	}

	private void c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty P_0, string P_1, string P_2)
	{
		bool flag = false;
		double num = 0.0;
		double num2 = 0.0;
		try
		{
			num2 = Convert.ToDouble(P_0.Value);
			num = Convert.ToDouble(P_2);
			flag = true;
		}
		catch
		{
			flag = false;
		}
		if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7886)))
		{
			__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
			if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8225)))
			{
				__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
				if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8232)))
				{
					__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
					if (P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8249))
					{
						if (!flag)
						{
							__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
						}
						else
						{
							P_0.Value = Convert.ToString(num * num2);
						}
					}
					else if (!(P_1 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(8266)))
					{
						__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
					}
					else if (!flag)
					{
						__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
					}
					else
					{
						P_0.Value = Convert.ToString(num2 / num);
					}
				}
				else
				{
					if (!flag)
					{
						__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
					}
					else
					{
						P_0.Value = Convert.ToString(num2 - num);
					}
					Convert.ToDouble(P_2);
				}
			}
			else if (!flag)
			{
				__ldtoken(frmMain.c10cb6d3e4bc0a01021a6db1ccdc4b004(ref CustomProperty, string, string));
			}
			else
			{
				P_0.Value = Convert.ToString(num + num2);
			}
		}
		else
		{
			P_0.Value = P_2;
		}
	}

	private void c6b3e10c5156a41d98e598986f7829655(object P_0, _WMPOCXEvents_MouseDownEvent P_1)
	{
		if (P_1.nButton != 2)
		{
			__ldtoken(frmMain.c6b3e10c5156a41d98e598986f7829655(object, _WMPOCXEvents_MouseDownEvent));
			return;
		}
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b != null)
		{
			ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
			c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c7d09946dbb22579280d3e849becda121;
			((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)ce585e6a23b47a28be2fa67d1e95f4dae, P_1.fX, ((Control)ce585e6a23b47a28be2fa67d1e95f4dae).Top + P_1.fY);
		}
	}

	private void c9ee0469dc7145e6f2a836d7121b068ad(object P_0, _WMPOCXEvents_MouseDownEvent P_1)
	{
		if (P_1.nButton == 2)
		{
			((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
			if (c54f9a911545745b85ae6f74355697f8b == null)
			{
				__ldtoken(frmMain.c9ee0469dc7145e6f2a836d7121b068ad(object, _WMPOCXEvents_MouseDownEvent));
				return;
			}
			ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
			c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c4c08a3f00c9c0c5e2811fbf9e3f4dc18;
			((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)c33008150af74fd263d1c473a79b9a051, P_1.fX, P_1.fY);
		}
	}

	private void c39b78d2161705a2b7a602f0897aec4fa(object P_0, _WMPOCXEvents_PlayStateChangeEvent P_1)
	{
		if (P_1.newState != 8)
		{
			__ldtoken(frmMain.c39b78d2161705a2b7a602f0897aec4fa(object, _WMPOCXEvents_PlayStateChangeEvent));
		}
		else
		{
			c4f6995909cfad72aca98f8f9c47059c5 = true;
		}
		if (P_1.newState == 1)
		{
			if (!c4f6995909cfad72aca98f8f9c47059c5)
			{
				__ldtoken(frmMain.c39b78d2161705a2b7a602f0897aec4fa(object, _WMPOCXEvents_PlayStateChangeEvent));
				return;
			}
			c5722e0b047bf80ee8a41d6d5ca3a5b06.Ctlcontrols.play();
			c4f6995909cfad72aca98f8f9c47059c5 = false;
		}
	}

	private void cc925b40132dfc5cb256f0913d0b3c35d(AxWindowsMediaPlayer P_0)
	{
		int volume = P_0.settings.volume;
		for (int num = volume; num >= 0; num--)
		{
			P_0.settings.volume = num;
			Thread.Sleep(15);
		}
		P_0.settings.volume = volume;
	}

	private void c0e205563fe2e86b66afa10ecfd52e392(object P_0, PaintEventArgs P_1)
	{
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected Obj, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected Obj, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected Obj, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected Obj, but got Unknown
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
		}
		else
		{
			if (P_0 == null)
			{
				return;
			}
			__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
			PictureBox val = (PictureBox)((P_0 is PictureBox) ? P_0 : null);
			if (val == null)
			{
				__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
			}
			else
			{
				if (((Control)val).Tag == null)
				{
					return;
				}
				object tag = ((Control)val).Tag;
				GamePicture gamePicture = tag as GamePicture;
				if (gamePicture == null)
				{
					__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
				}
				else
				{
					foreach (string layeredImage in gamePicture.LayeredImages)
					{
						object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(layeredImage);
						Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
						if (val2 == null)
						{
							__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
						}
						else
						{
							P_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
						}
					}
				}
				if (gamePicture == null)
				{
					__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
				}
				else
				{
					if (gamePicture.Choices.Count <= 0)
					{
						return;
					}
					int count = gamePicture.Choices.Count;
					float num = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Width;
					float num2 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Height;
					int num3 = 0;
					for (int num4 = count - 1; num4 >= 0; num4--)
					{
						__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
						Character character = gamePicture.Choices[num4] as Character;
						GameObject gameObject = gamePicture.Choices[num4] as GameObject;
						string empty = string.Empty;
						if (character != null)
						{
							empty = character.ToString();
						}
						else if (gameObject == null)
						{
							__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
							empty = gamePicture.Choices[num4].ToString();
						}
						else
						{
							empty = gameObject.GetDisplayName();
						}
						Font val3 = gamePicture.enhinputdata.TextFont;
						if (num4 != 0)
						{
							__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
						}
						else
						{
							val3 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
						}
						float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
						SizeF sizeF = new SizeF(num - 20f, height);
						SizeF sizeF2 = P_1.Graphics.MeasureString(empty, val3, sizeF);
						Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
						Point pt = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).PointToClient(Cursor.Position);
						if (gamePicture.enhinputdata.BackgroundColor.ToArgb() != 0)
						{
							__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
						}
						else
						{
							gamePicture.enhinputdata.BackgroundColor = Color.FromArgb(-1929379841);
						}
						P_1.Graphics.FillRectangle((Brush)new SolidBrush(gamePicture.enhinputdata.BackgroundColor), rectangle);
						if (rectangle.Contains(pt))
						{
							if (num4 == 0)
							{
								P_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Red), 3f), rectangle);
							}
							else
							{
								P_1.Graphics.DrawRectangle(new Pen(Color.FromArgb(140, Color.Green), 3f), rectangle);
							}
						}
						if (gamePicture.enhinputdata.TextColor.ToArgb() != 0)
						{
							__ldtoken(frmMain.c0e205563fe2e86b66afa10ecfd52e392(object, PaintEventArgs));
						}
						else
						{
							gamePicture.enhinputdata.TextColor = Color.FromArgb(-16777216);
						}
						P_1.Graphics.DrawString(empty, val3, (Brush)new SolidBrush(gamePicture.enhinputdata.TextColor), (RectangleF)rectangle);
						num3 += rectangle.Height + 5;
					}
				}
			}
		}
	}

	private void cd7d9d5d3b1feaff767ec5064a8968dd4()
	{
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
		((Control)cb132670a816ec2a8a287804bae7180f0).Invalidate();
		((Control)c0970743bbfbc89b095632fb02680fc3b).Invalidate();
	}

	private void cdb3bb1abdb02abf0044da50b1a2f97b3(object P_0, EventArgs P_1)
	{
		c88f06acab41e7a9f4773a240d3882bbb();
	}

	private void c697e2c5b66a8be8c144f57dd8dbcdda2(object P_0, EventArgs P_1)
	{
		c6477fea51cc2c450d5ed6371d10cf406();
	}

	private void c7a8f840b70167091e379aa0a104482ed(object P_0, PaintEventArgs P_1)
	{
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
		}
		else
		{
			if (P_0 == null)
			{
				return;
			}
			__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
			PictureBox val = (PictureBox)((P_0 is PictureBox) ? P_0 : null);
			if (val == null)
			{
				return;
			}
			__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
			object tag = ((Control)val).Tag;
			if (tag is GamePicture gamePicture)
			{
				using (List<string>.Enumerator enumerator = gamePicture.LayeredImages.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
						string current = enumerator.Current;
						object pictureByName = c54f9a911545745b85ae6f74355697f8b.GetPictureByName(current);
						Image val2 = (Image)((pictureByName is Image) ? pictureByName : null);
						if (val2 == null)
						{
							__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
						}
						else
						{
							P_1.Graphics.DrawImage(val2, TextHandlers.ScaleToFit(((Control)val).ClientRectangle, val2));
						}
					}
					return;
				}
			}
			__ldtoken(frmMain.c7a8f840b70167091e379aa0a104482ed(object, PaintEventArgs));
		}
	}

	private void c1cefca45341657b47c05a74c9f5d1c53(object P_0, MouseEventArgs P_1)
	{
		((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Invalidate();
	}

	private void c78be9cb96ee0d5dd29dd58aef0b08775(object P_0, EventArgs P_1)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected Obj, but got Unknown
		Graphics val = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).CreateGraphics();
		if (!(((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Tag is GamePicture gamePicture))
		{
			return;
		}
		__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
		if (gamePicture.Choices.Count <= 0)
		{
			return;
		}
		int count = gamePicture.Choices.Count;
		float num = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Width;
		float num2 = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).Height;
		int num3 = 0;
		int num4 = count - 1;
		while (num4 >= 0)
		{
			__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
			Character character = gamePicture.Choices[num4] as Character;
			GameObject gameObject = gamePicture.Choices[num4] as GameObject;
			object obj = null;
			string empty = string.Empty;
			if (character == null)
			{
				__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
				if (gameObject == null)
				{
					__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
					empty = gamePicture.Choices[num4].ToString();
					obj = empty;
				}
				else
				{
					empty = gameObject.GetDisplayName();
					obj = gameObject;
				}
			}
			else
			{
				empty = character.ToString();
				obj = character;
			}
			Font val2 = gamePicture.enhinputdata.TextFont;
			if (num4 != 0)
			{
				__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
			}
			else
			{
				val2 = new Font(gamePicture.enhinputdata.TextFont.Name, gamePicture.enhinputdata.TextFont.Size + 2f, gamePicture.enhinputdata.TextFont.Style);
			}
			float height = (num2 - (float)num3 - 5f) / (float)(num4 + 1);
			SizeF sizeF = new SizeF(num - 20f, height);
			SizeF sizeF2 = val.MeasureString(empty, val2, sizeF);
			Rectangle rectangle = new Rectangle(10, Convert.ToInt32(num2 - (float)num3 - sizeF2.Height - 5f), Convert.ToInt32(num - 20f), Convert.ToInt32(sizeF2.Height));
			Point pt = ((Control)cd431de8c0add2abbb6ebb8d63e4db3c0).PointToClient(Cursor.Position);
			if (!rectangle.Contains(pt))
			{
				__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
				num3 += rectangle.Height + 5;
				num4--;
				continue;
			}
			if (num4 != 0)
			{
				__ldtoken(frmMain.c78be9cb96ee0d5dd29dd58aef0b08775(object, EventArgs));
				c71f1ffa88f78e31ebea8163f6c76f6a8 = obj;
			}
			break;
		}
	}

	private void c957d2e476d59a2ea716b5e87364146f1(object P_0, MouseEventArgs P_1)
	{
		int num = lbCharacters.IndexFromPoint(P_1.X, P_1.Y);
		if (num == -1)
		{
			__ldtoken(frmMain.c957d2e476d59a2ea716b5e87364146f1(object, MouseEventArgs));
			return;
		}
		((ListControl)lbCharacters).SelectedIndex = num;
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		Character character = lbCharacters.SelectedItem as Character;
		GameObject gameObject = lbCharacters.SelectedItem as GameObject;
		ArrayList arrayList = null;
		if (character == null)
		{
			__ldtoken(frmMain.c957d2e476d59a2ea716b5e87364146f1(object, MouseEventArgs));
			if (gameObject == null)
			{
				__ldtoken(frmMain.c957d2e476d59a2ea716b5e87364146f1(object, MouseEventArgs));
			}
			else
			{
				arrayList = gameObject.Actions;
			}
		}
		else
		{
			arrayList = character.Actions;
		}
		if (arrayList == null)
		{
			__ldtoken(frmMain.c957d2e476d59a2ea716b5e87364146f1(object, MouseEventArgs));
			return;
		}
		ce9033674910e3df8a0b419702d6f30be(arrayList, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.cde26345c3892d2dd4757283560083496;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbCharacters, P_1.X, P_1.Y);
	}

	private void c1fd2530a7bace5c536a8c0c733f33369(object P_0, MouseEventArgs P_1)
	{
		int num = lbRoomObjects.IndexFromPoint(P_1.X, P_1.Y);
		if (num == -1)
		{
			__ldtoken(frmMain.c1fd2530a7bace5c536a8c0c733f33369(object, MouseEventArgs));
			return;
		}
		((ListControl)lbRoomObjects).SelectedIndex = num;
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		GameObject gameObject = lbRoomObjects.Items[num] as GameObject;
		ce9033674910e3df8a0b419702d6f30be(gameObject.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.cfbba04fc2eff86441089b369b8432706;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbRoomObjects, P_1.X, P_1.Y);
	}

	private void ce0b3045140769e1209118dd918a520fd(object P_0, MouseEventArgs P_1)
	{
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.ce0b3045140769e1209118dd918a520fd(object, MouseEventArgs));
			return;
		}
		ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.CurrentRoom.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c7d09946dbb22579280d3e849becda121;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)c0970743bbfbc89b095632fb02680fc3b, P_1.X, P_1.Y);
	}

	private void c213aae3ecccb7e5a64c5c9a34109a34b(object P_0, MouseEventArgs P_1)
	{
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		if (c54f9a911545745b85ae6f74355697f8b == null)
		{
			__ldtoken(frmMain.c213aae3ecccb7e5a64c5c9a34109a34b(object, MouseEventArgs));
			return;
		}
		ce9033674910e3df8a0b419702d6f30be(c54f9a911545745b85ae6f74355697f8b.ThePlayer.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c4c08a3f00c9c0c5e2811fbf9e3f4dc18;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)cb132670a816ec2a8a287804bae7180f0, P_1.X, P_1.Y);
	}

	private void cc6b029b22b0e86a8b36405bab315d468(object P_0, MouseEventArgs P_1)
	{
		int num = lbInventory.IndexFromPoint(P_1.X, P_1.Y);
		if (num == -1)
		{
			__ldtoken(frmMain.cc6b029b22b0e86a8b36405bab315d468(object, MouseEventArgs));
			return;
		}
		((ListControl)lbInventory).SelectedIndex = num;
		((ToolStrip)c1e8a97c8afdf40dab745e3180f49333e).Items.Clear();
		GameObject gameObject = lbInventory.Items[num] as GameObject;
		ce9033674910e3df8a0b419702d6f30be(gameObject.Actions, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5347), null);
		c3bf3a953472a12db8827db3f743d5429 = c10b414d2e012eeb2ef0cc25b561b1549.c8bce6377505aef2547787d71a915b3b8;
		((ToolStripDropDown)c1e8a97c8afdf40dab745e3180f49333e).Show((Control)(object)lbInventory, P_1.X, P_1.Y);
	}

	private void ca8dff17164e2f3b19676a8a0156325bd(object P_0, EventArgs P_1)
	{
	}

	private double c46bd9b8fde1a25f614f930b648557a08(GameVariable P_0, string P_1)
	{
		if (P_0.bEnforceRestrictions)
		{
			double num = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.dMin, null));
			double num2 = Convert.ToDouble(c54f9a911545745b85ae6f74355697f8b.PerformTextReplacements(P_0.dMax, null));
			if (!(Convert.ToDouble(P_1) < num))
			{
				__ldtoken(frmMain.c46bd9b8fde1a25f614f930b648557a08(GameVariable, string));
				if (Convert.ToDouble(P_1) > num2)
				{
					return num2;
				}
				return Convert.ToDouble(P_1);
			}
			return num;
		}
		return Convert.ToDouble(P_1);
	}

	private void cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData P_0)
	{
		c33da7cbe080e8167115ce842f845e11f = P_0.originalfilename;
		IEnumerator enumerator = P_0.CharacterList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Character character = (Character)enumerator.Current;
				Character characterByName = c54f9a911545745b85ae6f74355697f8b.GetCharacterByName(character.Charname);
				if (characterByName == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					characterByName.UpdateFromSave(character);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
			}
			else
			{
				disposable.Dispose();
			}
		}
		IEnumerator enumerator2 = P_0.ObjectList.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				GameObject gameObject = (GameObject)enumerator2.Current;
				GameObject objectByName = c54f9a911545745b85ae6f74355697f8b.GetObjectByName(gameObject.UniqueIdentifier.ToString());
				if (objectByName == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					objectByName.UpdateFromSave(gameObject);
				}
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = P_0.RoomList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				Room room = (Room)enumerator3.Current;
				Room roomByID = c54f9a911545745b85ae6f74355697f8b.GetRoomByID(room.UniqueID);
				if (roomByID == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					roomByID.UpdateFromSave(room);
				}
			}
		}
		finally
		{
			IDisposable disposable6 = enumerator3 as IDisposable;
			if (disposable6 != null)
			{
				disposable6.Dispose();
			}
		}
		c54f9a911545745b85ae6f74355697f8b.ThePlayer.UpdateFromSave(P_0.ThePlayer);
		IEnumerator enumerator4 = P_0.VariableList.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				GameVariable gameVariable = (GameVariable)enumerator4.Current;
				GameVariable variableByName = c54f9a911545745b85ae6f74355697f8b.GetVariableByName(gameVariable.varname);
				if (variableByName == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					variableByName.UpdateFromSave(gameVariable);
				}
			}
		}
		finally
		{
			if (!(enumerator4 is IDisposable disposable3))
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator5 = P_0.TimerList.GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				Timer timer = (Timer)enumerator5.Current;
				Timer timerByName = c54f9a911545745b85ae6f74355697f8b.GetTimerByName(timer.Name);
				if (timerByName == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					timerByName.UpdateFromSave(timer);
				}
			}
		}
		finally
		{
			if (!(enumerator5 is IDisposable disposable4))
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
			}
			else
			{
				disposable4.Dispose();
			}
		}
		IEnumerator enumerator6 = P_0.StatusBarList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				StatusBarItem statusBarItem = (StatusBarItem)enumerator6.Current;
				StatusBarItem statusBarItemByName = c54f9a911545745b85ae6f74355697f8b.GetStatusBarItemByName(statusBarItem.Name);
				if (statusBarItemByName == null)
				{
					__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
				}
				else
				{
					statusBarItemByName.UpdateFromSave(statusBarItem);
				}
			}
		}
		finally
		{
			if (!(enumerator6 is IDisposable disposable5))
			{
				__ldtoken(frmMain.cbdf4511b61938d6ccdac6d22c0aa287f(ref SaveData));
			}
			else
			{
				disposable5.Dispose();
			}
		}
	}
}
