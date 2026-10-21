using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Game : ISerializable
{
	public enum SortOrder
	{
		SO_NATURAL,
		SO_ALPHA,
		SO_LILO
	}

	private WaitDlg tempwaitdlg = new WaitDlg();

	public static int PercentageComplete = 0;

	private static object Lockobj = new object();

	public static SqlCeConnection TheCon = null;

	public Font GameFont = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f);

	public static DateTimeFormatInfo myDTFI = new CultureInfo(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(55602), useUserOverride: false).DateTimeFormat;

	public static bool bUpgrading = false;

	public static string ObjectVersionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();

	public static string CurrentObjectVersionNumber = string.Empty;

	public bool bPasswordProtected;

	public string GamePassword = string.Empty;

	public ArrayList RoomList = new ArrayList();

	public Player ThePlayer = new Player();

	public ArrayList PictureList = new ArrayList();

	public ArrayList ObjectList = new ArrayList();

	public ArrayList VariableList = new ArrayList();

	public ArrayList CharacterList = new ArrayList();

	public ArrayList TimerList = new ArrayList();

	public ArrayList StatusBarItems = new ArrayList();

	public ArrayList LayeredClothingZones = new ArrayList();

	public ArrayList RoomGroups = new ArrayList();

	public string Title = "";

	public string OpeningMessage = "";

	public string AdditionalData = "";

	public int TurnCount;

	public bool bHideMainPicDisplay;

	public bool bUseInlineImages;

	public bool bHidePortrait;

	public string bgMusic = string.Empty;

	public bool bRepeatbgMusic;

	public bool bTurnOffNotifications;

	public static bool bDoneWithWaitDlg = false;

	public SortOrder SortOrderRoomObjects;

	public SortOrder SortOrderCharacters;

	public SortOrder SortOrderInventory;

	public string AuthorName = string.Empty;

	public string GameVersion = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54612);

	public string GameInformation = string.Empty;

	private Timer checktimer = new Timer();

	public ArrayList QuickCommands = new ArrayList();

	private ArrayList HotKeys = new ArrayList();

	public static string DBName = string.Empty;

	public Game()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		c4a5c4a16bc4ac0d9335c815493a8998e();
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54619));
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54640));
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54657));
	}

	public Game(string dbname)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		c4a5c4a16bc4ac0d9335c815493a8998e();
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54619));
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54640));
		LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54657));
		DBName = dbname;
		tempwaitdlg = new WaitDlg();
		((Control)tempwaitdlg.label1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54678);
		Cursor.Current = Cursors.WaitCursor;
		bDoneWithWaitDlg = false;
		((Control)tempwaitdlg).Show();
		ThreadPool.QueueUserWorkItem(ThrdLoadData, this);
		checktimer.Interval = 500;
		checktimer.Tick += cc7dda0695f3c6418b59a7cfe9817a5a7;
		checktimer.Start();
	}

	protected Game(SerializationInfo info, StreamingContext context)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Obj, but got Unknown
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected Obj, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		if (info != null)
		{
			__ldtoken(Game._002Ector(SerializationInfo, StreamingContext));
			try
			{
				try
				{
					CurrentObjectVersionNumber = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46465), ObjectVersionNumber.GetType());
				}
				catch
				{
					CurrentObjectVersionNumber = ((double)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46465), ObjectVersionNumber.GetType())).ToString();
				}
				try
				{
					GameFont = (Font)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46504), ((object)GameFont).GetType());
				}
				catch
				{
					GameFont = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(15603), 8.25f);
				}
				Version version = new Version(CurrentObjectVersionNumber);
				Version version2 = new Version(ObjectVersionNumber);
				if (!(version < version2))
				{
					__ldtoken(Game._002Ector(SerializationInfo, StreamingContext));
					bUpgrading = false;
				}
				else
				{
					bUpgrading = true;
				}
				if (!(version > version2))
				{
					__ldtoken(Game._002Ector(SerializationInfo, StreamingContext));
					try
					{
						bPasswordProtected = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49674), bPasswordProtected.GetType());
						GamePassword = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46304), GamePassword.GetType());
						RoomList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49711), RoomList.GetType());
						ThePlayer = (Player)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49728), ThePlayer.GetType());
						try
						{
							PictureList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49747), PictureList.GetType());
						}
						catch
						{
							PictureList = new ArrayList();
						}
						ObjectList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49770), ObjectList.GetType());
						VariableList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49791), VariableList.GetType());
						CharacterList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49816), CharacterList.GetType());
						Title = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46019), Title.GetType());
						OpeningMessage = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46030), OpeningMessage.GetType());
						try
						{
							TimerList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49843), TimerList.GetType());
						}
						catch
						{
							TimerList = new ArrayList();
						}
						try
						{
							StatusBarItems = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49862), StatusBarItems.GetType());
						}
						catch
						{
							StatusBarItems = new ArrayList();
						}
						try
						{
							LayeredClothingZones = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49891), LayeredClothingZones.GetType());
						}
						catch
						{
							LayeredClothingZones = new ArrayList();
							LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54619));
							LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54640));
							LayeredClothingZones.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54657));
						}
						try
						{
							RoomGroups = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46521), RoomGroups.GetType());
						}
						catch
						{
							RoomGroups = new ArrayList();
						}
						try
						{
							bHideMainPicDisplay = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46059));
						}
						catch
						{
							bHideMainPicDisplay = false;
						}
						try
						{
							bUseInlineImages = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46096));
						}
						catch
						{
							bUseInlineImages = false;
						}
						try
						{
							bHidePortrait = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46127));
						}
						catch
						{
							bHidePortrait = false;
						}
						try
						{
							AuthorName = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46152));
						}
						catch
						{
							AuthorName = string.Empty;
						}
						try
						{
							GameVersion = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46173));
						}
						catch
						{
							GameVersion = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54612);
						}
						try
						{
							GameInformation = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196));
						}
						catch
						{
							GameInformation = string.Empty;
						}
						try
						{
							bgMusic = info.GetString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227));
						}
						catch
						{
							bgMusic = string.Empty;
						}
						try
						{
							bRepeatbgMusic = info.GetBoolean(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49932));
						}
						catch
						{
							bRepeatbgMusic = false;
						}
						c4a5c4a16bc4ac0d9335c815493a8998e();
						return;
					}
					catch
					{
						MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(55035) + CurrentObjectVersionNumber + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(55399));
						return;
					}
				}
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54709) + CurrentObjectVersionNumber.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54879) + ObjectVersionNumber.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54910));
				return;
			}
			catch (Exception ex)
			{
				throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(55557), ex.InnerException);
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetWindowsDirectoryA")]
	private static extern int c200cd13c1beaa1c7e74d3019ab22f3a7(StringBuilder P_0, int P_1);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentDirectoryA")]
	private static extern int c0dce99902c3b2668991d44677569add2(int P_0, StringBuilder P_1);

	public static SqlCeConnection GetDBConnection()
	{
		if (!(DBName == string.Empty))
		{
			__ldtoken(Game.GetDBConnection());
			try
			{
				EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23669));
				string connectionString = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23696) + DBName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23719) + EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23669));
				if (TheCon == null)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else if (!(DBName != TheCon.DataSource))
				{
					__ldtoken(Game.GetDBConnection());
				}
				else
				{
					TheCon.Close();
				}
				if (TheCon == null)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else if (TheCon.State != ConnectionState.Closed)
				{
					goto IL_00d6;
				}
				TheCon = new SqlCeConnection(connectionString);
				TheCon.Open();
				goto IL_00d6;
				IL_00d6:
				if (TheCon.State != ConnectionState.Broken)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else
				{
					TheCon.Close();
					TheCon.Open();
				}
			}
			catch (Exception)
			{
				EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23786));
				string connectionString2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23696) + DBName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23719) + EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23786));
				SqlCeEngine sqlCeEngine = new SqlCeEngine(connectionString2);
				sqlCeEngine.Compact(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23696) + DBName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23807) + EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23669)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23828));
				sqlCeEngine.Dispose();
				connectionString2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23696) + DBName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23719) + EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23669)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23828);
				if (TheCon == null)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else if (DBName != TheCon.DataSource)
				{
					TheCon.Close();
				}
				if (TheCon == null)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else if (TheCon.State != ConnectionState.Closed)
				{
					__ldtoken(Game.GetDBConnection());
					goto IL_0290;
				}
				TheCon = new SqlCeConnection(connectionString2);
				TheCon.Open();
				goto IL_0290;
				IL_0290:
				if (TheCon.State != ConnectionState.Broken)
				{
					__ldtoken(Game.GetDBConnection());
				}
				else
				{
					TheCon.Close();
					TheCon.Open();
				}
			}
			return TheCon;
		}
		return null;
	}

	public void CreateDatabase(string name)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (File.Exists(name))
		{
			if (TheCon == null)
			{
				__ldtoken(Game.CreateDatabase(string));
			}
			else
			{
				TheCon.Close();
			}
			try
			{
				File.Delete(name);
			}
			catch
			{
				MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23873));
				return;
			}
		}
		DBName = name;
		SqlCeEngine sqlCeEngine = new SqlCeEngine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23696) + name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23807) + EncDec.RagsZone(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23669)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23828));
		sqlCeEngine.CreateDatabase();
		sqlCeEngine.Dispose();
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23998), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(25462), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(26364), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(26678), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(27082), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(27674), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(29756), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(30070), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(30474), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(30824), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(31640), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(31990), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(33048), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(33280), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(33602), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(34434), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(34762), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(35180), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(36110), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(36524), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37202), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37514), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		c8b0f5a4d1050a2308ebe56982e4a6a78();
	}

	private static void c8b0f5a4d1050a2308ebe56982e4a6a78()
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(37926), dBConnection);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		bool flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int @int = sqlCeDataReader.GetInt32(0);
			if (@int != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(38124), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(38530), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int2 = sqlCeDataReader.GetInt32(0);
			if (int2 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(38774), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(38984), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int3 = sqlCeDataReader.GetInt32(0);
			if (int3 == 1)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(39228), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(39460), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int4 = sqlCeDataReader.GetInt32(0);
			if (int4 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(39712), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(39914), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int5 = sqlCeDataReader.GetInt32(0);
			if (int5 == 1)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(40182), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(40400), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int6 = sqlCeDataReader.GetInt32(0);
			if (int6 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(40664), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(40916), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int7 = sqlCeDataReader.GetInt32(0);
			if (int7 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(41174), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(41702), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int8 = sqlCeDataReader.GetInt32(0);
			if (int8 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(41946), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(42156), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int9 = sqlCeDataReader.GetInt32(0);
			if (int9 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(42352), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(42756), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int10 = sqlCeDataReader.GetInt32(0);
			if (int10 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(42960), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(43372), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int11 = sqlCeDataReader.GetInt32(0);
			if (int11 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(43624), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(43842), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int12 = sqlCeDataReader.GetInt32(0);
			if (int12 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(44046), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(44510), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int13 = sqlCeDataReader.GetInt32(0);
			if (int13 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(44768), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45014), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int14 = sqlCeDataReader.GetInt32(0);
			if (int14 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45274), dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45500), dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
		}
		else
		{
			int int15 = sqlCeDataReader.GetInt32(0);
			if (int15 != 1)
			{
				__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			__ldtoken(Game.c8b0f5a4d1050a2308ebe56982e4a6a78());
			return;
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45762), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
	}

	public static void ThrdLoadData(object stateinfo)
	{
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected Obj, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected Obj, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected Obj, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected Obj, but got Unknown
		Game game = stateinfo as Game;
		float num = 0f;
		PercentageComplete = 0;
		int num2 = 8;
		c8b0f5a4d1050a2308ebe56982e4a6a78();
		SqlCeConnection dBConnection = GetDBConnection();
		try
		{
			SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(45974), dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (!sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
			}
			else
			{
				game.Title = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46019)].ToString();
				game.OpeningMessage = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46030)].ToString();
				game.bHideMainPicDisplay = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46059)];
				game.bUseInlineImages = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46096)];
				game.bHidePortrait = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46127)];
				game.AuthorName = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46152)].ToString();
				game.GameVersion = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46173)].ToString();
				game.GameInformation = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196)].ToString();
				game.bgMusic = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227)].ToString();
				game.bRepeatbgMusic = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46242)];
				game.bPasswordProtected = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46269)];
				game.GamePassword = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46304)].ToString();
				game.bTurnOffNotifications = (bool)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46329)];
				game.SortOrderRoomObjects = (SortOrder)(int)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46362)];
				game.SortOrderCharacters = (SortOrder)(int)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46389)];
				game.SortOrderInventory = (SortOrder)(int)sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46428)];
				CurrentObjectVersionNumber = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46465)].ToString();
				TypeDescriptor.GetConverter(typeof(Font));
				string text = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46504)].ToString();
				string text2 = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46521)].ToString();
				string[] array = text2.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) }, StringSplitOptions.None);
				game.RoomGroups.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					__ldtoken(Game.ThrdLoadData(object));
					if (array[i] != string.Empty)
					{
						game.RoomGroups.Add(array[i]);
					}
				}
				string text3 = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46542)].ToString();
				string[] array2 = text3.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) }, StringSplitOptions.None);
				game.LayeredClothingZones.Clear();
				for (int j = 0; j < array2.Length; j++)
				{
					__ldtoken(Game.ThrdLoadData(object));
					if (!(array2[j] != string.Empty))
					{
						__ldtoken(Game.ThrdLoadData(object));
					}
					else
					{
						game.LayeredClothingZones.Add(array2[j]);
					}
				}
				try
				{
					FontConverter val = new FontConverter();
					game.GameFont = (Font)((TypeConverter)(object)val).ConvertFromString(text);
				}
				catch
				{
					string text4 = text.Substring(0, text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)));
					string text5 = text.Substring(text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)) + 1);
					if (text5.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46579)) <= -1)
					{
						__ldtoken(Game.ThrdLoadData(object));
					}
					else
					{
						text5 = text5.Remove(text5.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46579)));
					}
					text5 = text5.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313));
					if (text4.Length > 1)
					{
						game.GameFont = new Font(text4, (float)Convert.ToDouble(text5));
					}
					else
					{
						game.GameFont = new Font(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46584), 12f);
					}
				}
			}
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			bool lockTaken = false;
			object lockobj = default;
			try
			{
				Monitor.Enter(lockobj = Lockobj, ref lockTaken);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46615), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.StatusBarItems.Add(new StatusBarItem(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			bool lockTaken2 = false;
			object lockobj2 = default;
			try
			{
				Monitor.Enter(lockobj2 = Lockobj, ref lockTaken2);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken2)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj2);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46672), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.RoomList.Add(new Room(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			bool lockTaken3 = false;
			object lockobj3 = default;
			try
			{
				Monitor.Enter(lockobj3 = Lockobj, ref lockTaken3);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken3)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj3);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46711), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.ObjectList.Add(new GameObject(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46750), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.PictureList.Add(new GamePicture(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			bool lockTaken4 = false;
			object lockobj4 = default;
			try
			{
				Monitor.Enter(lockobj4 = Lockobj, ref lockTaken4);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken4)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj4);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47018), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (!sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
			}
			else
			{
				game.ThePlayer = new Player(sqlCeDataReader);
				try
				{
					game.ThePlayer.StartingRoom = game.GetRoomByID(new Guid(sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47059)].ToString()));
				}
				catch
				{
					game.ThePlayer.StartingRoom = null;
				}
				try
				{
					game.ThePlayer.CurrentRoom = game.GetRoomByID(new Guid(sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674)].ToString()));
				}
				catch
				{
					game.ThePlayer.CurrentRoom = null;
				}
			}
			num++;
			bool lockTaken5 = false;
			object lockobj5 = default;
			try
			{
				Monitor.Enter(lockobj5 = Lockobj, ref lockTaken5);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken5)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj5);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47084), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.CharacterList.Add(new Character(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47133), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.VariableList.Add(new GameVariable(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			bool lockTaken6 = false;
			object lockobj6 = default;
			try
			{
				Monitor.Enter(lockobj6 = Lockobj, ref lockTaken6);
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			finally
			{
				if (!lockTaken6)
				{
					__ldtoken(Game.ThrdLoadData(object));
				}
				else
				{
					Monitor.Exit(lockobj6);
				}
			}
			sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47180), dBConnection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				__ldtoken(Game.ThrdLoadData(object));
				game.TimerList.Add(new Timer(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
		}
		finally
		{
			if (dBConnection == null)
			{
				__ldtoken(Game.ThrdLoadData(object));
			}
			else
			{
				((IDisposable)dBConnection).Dispose();
			}
		}
		bDoneWithWaitDlg = true;
	}

	public static void ThrdUpdateDatabase(object stateinfo)
	{
		Game game = stateinfo as Game;
		float num = 0f;
		PercentageComplete = 0;
		int num2 = 8;
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47219), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47260), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48144), game.Title);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48157), game.OpeningMessage);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48188), game.bHideMainPicDisplay);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48227), game.bUseInlineImages);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48260), game.bHidePortrait);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48287), game.AuthorName);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48310), game.GameVersion);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48335), game.GameInformation);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48368), game.bgMusic);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48385), game.bRepeatbgMusic);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48414), game.bPasswordProtected);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48451), game.GamePassword);
		if (!(CurrentObjectVersionNumber == string.Empty))
		{
			__ldtoken(Game.ThrdUpdateDatabase(object));
		}
		else
		{
			CurrentObjectVersionNumber = ObjectVersionNumber;
		}
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48470), CurrentObjectVersionNumber);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48511), converter.ConvertToString(game.GameFont));
		string text = string.Empty;
		IEnumerator enumerator = game.RoomGroups.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string text2 = (string)enumerator.Current;
				if (!(text != string.Empty))
				{
					__ldtoken(Game.ThrdUpdateDatabase(object));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
				}
				text += text2;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable.Dispose();
			}
		}
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48530), text);
		string text3 = string.Empty;
		IEnumerator enumerator2 = game.LayeredClothingZones.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
				string text4 = (string)enumerator2.Current;
				if (!(text3 != string.Empty))
				{
					__ldtoken(Game.ThrdUpdateDatabase(object));
				}
				else
				{
					text3 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
				}
				text3 += text4;
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48553), text3);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48592), game.bTurnOffNotifications);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48627), game.SortOrderRoomObjects);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48656), game.SortOrderCharacters);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48697), game.SortOrderInventory);
		sqlCeCommand.ExecuteNonQuery();
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48736), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator3 = game.StatusBarItems.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
				StatusBarItem statusBarItem = (StatusBarItem)enumerator3.Current;
				statusBarItem.UpdateDatabase();
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		DateTime now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48789), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48824), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48871), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48924), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator4 = game.RoomList.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				Room room = (Room)enumerator4.Current;
				room.c99c4de57cc28b83b24000ba9447c3a36();
			}
		}
		finally
		{
			if (!(enumerator4 is IDisposable disposable4))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable4.Dispose();
			}
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(48967), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49002), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49049), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49102), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator5 = game.ObjectList.GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
				GameObject gameObject = (GameObject)enumerator5.Current;
				gameObject.c99c4de57cc28b83b24000ba9447c3a36();
			}
		}
		finally
		{
			if (!(enumerator5 is IDisposable disposable5))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable5.Dispose();
			}
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		bool lockTaken = false;
		object lockobj = default;
		try
		{
			Monitor.Enter(lockobj = Lockobj, ref lockTaken);
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		finally
		{
			if (!lockTaken)
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				Monitor.Exit(lockobj);
			}
		}
		game.ThePlayer.UpdateDatabase();
		num++;
		bool lockTaken2 = false;
		object lockobj2 = default;
		try
		{
			Monitor.Enter(lockobj2 = Lockobj, ref lockTaken2);
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		finally
		{
			if (!lockTaken2)
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				Monitor.Exit(lockobj2);
			}
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49169), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49214), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49271), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator6 = game.CharacterList.GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				Character character = (Character)enumerator6.Current;
				character.UpdateDatabase();
			}
		}
		finally
		{
			if (!(enumerator6 is IDisposable disposable6))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable6.Dispose();
			}
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49334), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49377), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator7 = game.VariableList.GetEnumerator();
		try
		{
			while (enumerator7.MoveNext())
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
				GameVariable gameVariable = (GameVariable)enumerator7.Current;
				gameVariable.UpdateDatabase();
			}
		}
		finally
		{
			if (!(enumerator7 is IDisposable disposable7))
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				disposable7.Dispose();
			}
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		bool lockTaken3 = false;
		object lockobj3 = default;
		try
		{
			Monitor.Enter(lockobj3 = Lockobj, ref lockTaken3);
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		finally
		{
			if (!lockTaken3)
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				Monitor.Exit(lockobj3);
			}
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49438), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49473), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49522), dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		IEnumerator enumerator8 = game.TimerList.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
				Timer timer = (Timer)enumerator8.Current;
				timer.UpdateDatabase();
			}
		}
		finally
		{
			IDisposable disposable8 = enumerator8 as IDisposable;
			if (disposable8 != null)
			{
				disposable8.Dispose();
			}
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		bool lockTaken4 = false;
		object lockobj4 = default;
		try
		{
			Monitor.Enter(lockobj4 = Lockobj, ref lockTaken4);
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		finally
		{
			if (!lockTaken4)
			{
				__ldtoken(Game.ThrdUpdateDatabase(object));
			}
			else
			{
				Monitor.Exit(lockobj4);
			}
		}
		dBConnection.Close();
		dBConnection.Dispose();
		num++;
		bDoneWithWaitDlg = true;
	}

	public void UpdateDatabase()
	{
		tempwaitdlg = new WaitDlg();
		((Control)tempwaitdlg.label1).Text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49577);
		Cursor.Current = Cursors.WaitCursor;
		bDoneWithWaitDlg = false;
		((Control)tempwaitdlg).Show();
		ThreadPool.QueueUserWorkItem(ThrdUpdateDatabase, this);
		checktimer.Interval = 500;
		checktimer.Tick += cc7dda0695f3c6418b59a7cfe9817a5a7;
		checktimer.Start();
	}

	private void cc7dda0695f3c6418b59a7cfe9817a5a7(object P_0, EventArgs P_1)
	{
		bool lockTaken = false;
		object lockobj = default;
		try
		{
			Monitor.Enter(lockobj = Lockobj, ref lockTaken);
			if (PercentageComplete > 100)
			{
				PercentageComplete = 100;
			}
			tempwaitdlg.progressBar1.Value = PercentageComplete;
			if (!bDoneWithWaitDlg)
			{
				__ldtoken(Game.cc7dda0695f3c6418b59a7cfe9817a5a7(object, EventArgs));
				return;
			}
			tempwaitdlg.progressBar1.Value = 100;
			Application.DoEvents();
			((Form)tempwaitdlg).Close();
			Cursor.Current = Cursors.Default;
			checktimer.Stop();
			bDoneWithWaitDlg = false;
		}
		finally
		{
			if (!lockTaken)
			{
				__ldtoken(Game.cc7dda0695f3c6418b59a7cfe9817a5a7(object, EventArgs));
			}
			else
			{
				Monitor.Exit(lockobj);
			}
		}
	}

	private void c4a5c4a16bc4ac0d9335c815493a8998e()
	{
		if (Application.ExecutablePath.ToUpper().IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49606)) <= -1)
		{
			__ldtoken(Game.c4a5c4a16bc4ac0d9335c815493a8998e());
			return;
		}
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
		if (Directory.Exists(text))
		{
			__ldtoken(Game.c4a5c4a16bc4ac0d9335c815493a8998e());
		}
		else
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49639));
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		if (File.Exists(path))
		{
			__ldtoken(Game.c4a5c4a16bc4ac0d9335c815493a8998e());
		}
		else
		{
			RestoreDefaults(ref QuickCommands);
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(path, FileMode.Create);
				binaryFormatter.Serialize(fileStream, QuickCommands);
			}
			finally
			{
				fileStream.Flush();
				fileStream.Close();
				fileStream.Dispose();
			}
		}
		StreamReader streamReader = null;
		try
		{
			streamReader = new StreamReader(path);
			streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			try
			{
				QuickCommands = (ArrayList)binaryFormatter.Deserialize(streamReader.BaseStream);
			}
			catch
			{
				QuickCommands = null;
			}
		}
		finally
		{
			if (streamReader != null)
			{
				streamReader.Close();
				streamReader.Dispose();
			}
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Game.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46465), ObjectVersionNumber, ObjectVersionNumber.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49674), bPasswordProtected, bPasswordProtected.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46304), GamePassword, GamePassword.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49711), RoomList, RoomList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49728), ThePlayer, ThePlayer.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49747), PictureList, PictureList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49770), ObjectList, ObjectList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49791), VariableList, VariableList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49816), CharacterList, CharacterList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46019), Title, Title.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46030), OpeningMessage, OpeningMessage.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49843), TimerList, TimerList.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49862), StatusBarItems, StatusBarItems.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49891), LayeredClothingZones, LayeredClothingZones.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46521), RoomGroups, RoomGroups.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46504), GameFont, ((object)GameFont).GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46059), bHideMainPicDisplay, bHideMainPicDisplay.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46096), bUseInlineImages, bUseInlineImages.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46127), bHidePortrait, bHidePortrait.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46152), AuthorName, AuthorName.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46173), GameVersion, GameVersion.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196), GameInformation, GameInformation.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227), bgMusic, bgMusic.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49932), bRepeatbgMusic, bRepeatbgMusic.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public void GetXMLData(ref StreamWriter CurDoc, bool bRooms, bool bCharacters, bool bObjects, bool bVariables, bool bTimers, bool bStatusBarItems, bool bPlayer, bool bImages)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49961));
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46019), Title);
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46030), OpeningMessage);
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46059), bHideMainPicDisplay.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46096), bUseInlineImages.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46127), bHidePortrait.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46152), AuthorName.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46173), GameVersion.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196), GameInformation.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227), bgMusic.ToString());
		AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49932), bRepeatbgMusic.ToString());
		if (!bRooms)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else if (RoomList.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49982));
			IEnumerator enumerator = RoomList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Room room = (Room)enumerator.Current;
					room.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49997));
		}
		if (!bPlayer)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else
		{
			ThePlayer.GetXMLData(ref CurDoc);
		}
		if (!bCharacters)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else if (CharacterList.Count <= 0)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50014));
			IEnumerator enumerator2 = CharacterList.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
					Character character = (Character)enumerator2.Current;
					character.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
				}
				else
				{
					disposable2.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50039));
		}
		if (!bObjects)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else if (ObjectList.Count <= 0)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50066));
			IEnumerator enumerator3 = ObjectList.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					GameObject gameObject = (GameObject)enumerator3.Current;
					gameObject.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator3 is IDisposable disposable3))
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
				}
				else
				{
					disposable3.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50085));
		}
		if (bVariables)
		{
			if (VariableList.Count <= 0)
			{
				__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
			}
			else
			{
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50106));
				foreach (GameVariable variable in VariableList)
				{
					variable.GetXMLData(ref CurDoc);
				}
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50129));
			}
		}
		if (bTimers)
		{
			if (TimerList.Count <= 0)
			{
				__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
			}
			else
			{
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50154));
				{
					IEnumerator enumerator5 = TimerList.GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
							Timer timer = (Timer)enumerator5.Current;
							timer.GetXMLData(ref CurDoc);
						}
					}
					finally
					{
						IDisposable disposable6 = enumerator5 as IDisposable;
						if (disposable6 != null)
						{
							disposable6.Dispose();
						}
					}
				}
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50171));
			}
		}
		if (!bStatusBarItems)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else if (StatusBarItems.Count <= 0)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50190));
			{
				IEnumerator enumerator6 = StatusBarItems.GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
						StatusBarItem statusBarItem = (StatusBarItem)enumerator6.Current;
						statusBarItem.GetXMLData(ref CurDoc);
					}
				}
				finally
				{
					IDisposable disposable7 = enumerator6 as IDisposable;
					if (disposable7 != null)
					{
						disposable7.Dispose();
					}
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50223));
		}
		if (bImages)
		{
			if (PictureList.Count <= 0)
			{
				__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
			}
			else
			{
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50258));
				IEnumerator enumerator7 = PictureList.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
						GamePicture gamePicture = (GamePicture)enumerator7.Current;
						gamePicture.GetXMLData(ref CurDoc);
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable4))
					{
						__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
					}
					else
					{
						disposable4.Dispose();
					}
				}
				CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50275));
			}
		}
		if (LayeredClothingZones.Count <= 0)
		{
			__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50294));
			foreach (string layeredClothingZone in LayeredClothingZones)
			{
				AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50339), layeredClothingZone);
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50378));
		}
		if (RoomGroups.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50425));
			IEnumerator enumerator9 = RoomGroups.GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
					string value2 = (string)enumerator9.Current;
					AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50450), value2);
				}
			}
			finally
			{
				if (!(enumerator9 is IDisposable disposable5))
				{
					__ldtoken(Game.GetXMLData(ref StreamWriter, bool, bool, bool, bool, bool, bool, bool, bool));
				}
				else
				{
					disposable5.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50469));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50496));
	}

	public static void AddXMLSection(ref StreamWriter CurDoc, string titlename, string value)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50519) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50522));
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50525), value));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50556) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50522));
	}

	public static void AddXMLSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50519) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50522));
		CurDoc.Append(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50525), value));
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50556) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50522));
	}

	public static void AddAdvSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50519) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50522));
		CurDoc.Append(value);
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50556) + titlename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50561));
	}

	public static XmlNode GetXMLSection(ref XmlNode node, string titlename)
	{
		XmlNode result = null;
		IEnumerator enumerator = node.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Game.GetXMLSection(ref XmlNode, string));
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode.Name == titlename)
				{
					result = xmlNode;
					break;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Game.GetXMLSection(ref XmlNode, string));
			}
			else
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46019));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			Title = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46030));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			OpeningMessage = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46059));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			bHideMainPicDisplay = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46096));
		if (xMLSection != null)
		{
			bUseInlineImages = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46127));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			bHidePortrait = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46152));
		if (xMLSection != null)
		{
			AuthorName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46173));
		if (xMLSection != null)
		{
			GameVersion = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46196));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			GameInformation = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46227));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			bgMusic = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49932));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			bRepeatbgMusic = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50568));
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Room room = new Room();
				room.SetXMLData(ref CurNode2, this);
				IEnumerator enumerator = RoomList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
						Room room2 = (Room)enumerator.Current;
						if (!(room2.UniqueID == room.UniqueID))
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							continue;
						}
						RoomList.Remove(room2);
						break;
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
					}
					else
					{
						disposable.Dispose();
					}
				}
				RoomList.Add(room);
				if (ThePlayer.StartingRoom == null)
				{
					__ldtoken(Game.SetXMLData(ref XmlNode));
				}
				else if (room.UniqueID == ThePlayer.StartingRoom.UniqueID)
				{
					ThePlayer.StartingRoom = room;
				}
			}
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Room room3 = new Room();
				room3.SetXMLData(ref CurNode3, this);
				IEnumerator enumerator2 = RoomList.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
						Room room4 = (Room)enumerator2.Current;
						if (room4.UniqueID == room3.UniqueID)
						{
							RoomList.Remove(room4);
							break;
						}
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable2))
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
					}
					else
					{
						disposable2.Dispose();
					}
				}
				RoomList.Add(room3);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50579));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			ThePlayer.SetXMLData(ref xMLSection, this);
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5692));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode node = xMLSection.ChildNodes[k];
				Character character = new Character(GetXMLSection(ref node, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)).InnerText);
				character.SetXMLData(ref node);
				{
					IEnumerator enumerator3 = CharacterList.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							Character character2 = (Character)enumerator3.Current;
							if (!(character2.Charname == character.Charname))
							{
								__ldtoken(Game.SetXMLData(ref XmlNode));
								continue;
							}
							CharacterList.Remove(character2);
							break;
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
				}
				CharacterList.Add(character);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(708));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode CurNode4 = xMLSection.ChildNodes[l];
				GameObject gameObject = new GameObject();
				gameObject.SetXMLData(ref CurNode4);
				IEnumerator enumerator4 = ObjectList.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
						GameObject gameObject2 = (GameObject)enumerator4.Current;
						if (!(gameObject2.name == gameObject.name))
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							continue;
						}
						ObjectList.Remove(gameObject2);
						break;
					}
				}
				finally
				{
					if (!(enumerator4 is IDisposable disposable3))
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
					}
					else
					{
						disposable3.Dispose();
					}
				}
				ObjectList.Add(gameObject);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(576));
		if (xMLSection != null)
		{
			for (int m = 0; m < xMLSection.ChildNodes.Count; m++)
			{
				XmlNode node2 = xMLSection.ChildNodes[m];
				GameVariable gameVariable = new GameVariable(GetXMLSection(ref node2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)).InnerText);
				gameVariable.SetXMLData(ref node2);
				IEnumerator enumerator5 = VariableList.GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						GameVariable gameVariable2 = (GameVariable)enumerator5.Current;
						if (!(gameVariable2.varname == gameVariable.varname))
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							continue;
						}
						VariableList.Remove(gameVariable2);
						break;
					}
				}
				finally
				{
					if (!(enumerator5 is IDisposable disposable4))
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
					}
					else
					{
						disposable4.Dispose();
					}
				}
				VariableList.Add(gameVariable);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50592));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int n = 0; n < xMLSection.ChildNodes.Count; n++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode CurNode5 = xMLSection.ChildNodes[n];
				Timer timer = new Timer();
				timer.SetXMLData(ref CurNode5);
				{
					IEnumerator enumerator6 = TimerList.GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							Timer timer2 = (Timer)enumerator6.Current;
							if (!(timer2.Name == timer.Name))
							{
								__ldtoken(Game.SetXMLData(ref XmlNode));
								continue;
							}
							TimerList.Remove(timer2);
							break;
						}
					}
					finally
					{
						IDisposable disposable7 = enumerator6 as IDisposable;
						if (disposable7 != null)
						{
							disposable7.Dispose();
						}
					}
				}
				TimerList.Add(timer);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49862));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int num = 0; num < xMLSection.ChildNodes.Count; num++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode CurNode6 = xMLSection.ChildNodes[num];
				StatusBarItem statusBarItem = new StatusBarItem();
				statusBarItem.SetXMLData(ref CurNode6);
				IEnumerator enumerator7 = StatusBarItems.GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
						StatusBarItem statusBarItem2 = (StatusBarItem)enumerator7.Current;
						if (!(statusBarItem2.Name == statusBarItem.Name))
						{
							__ldtoken(Game.SetXMLData(ref XmlNode));
							continue;
						}
						StatusBarItems.Remove(statusBarItem2);
						break;
					}
				}
				finally
				{
					if (!(enumerator7 is IDisposable disposable5))
					{
						__ldtoken(Game.SetXMLData(ref XmlNode));
					}
					else
					{
						disposable5.Dispose();
					}
				}
				StatusBarItems.Add(statusBarItem);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50605));
		if (xMLSection != null)
		{
			for (int num2 = 0; num2 < xMLSection.ChildNodes.Count; num2++)
			{
				XmlNode CurNode7 = xMLSection.ChildNodes[num2];
				GamePicture gamePicture = new GamePicture();
				gamePicture.SetXMLData(ref CurNode7);
				foreach (GamePicture picture in PictureList)
				{
					if (picture.TheName == gamePicture.TheName)
					{
						PictureList.Remove(picture);
						break;
					}
				}
				PictureList.Add(gamePicture);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(49891));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
		}
		else
		{
			LayeredClothingZones.Clear();
			for (int num3 = 0; num3 < xMLSection.ChildNodes.Count; num3++)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
				XmlNode xmlNode = xMLSection.ChildNodes[num3];
				if (xmlNode == null)
				{
					__ldtoken(Game.SetXMLData(ref XmlNode));
				}
				else
				{
					LayeredClothingZones.Add(xmlNode.InnerText);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(46521));
		if (xMLSection == null)
		{
			__ldtoken(Game.SetXMLData(ref XmlNode));
			return;
		}
		RoomGroups.Clear();
		for (int num4 = 0; num4 < xMLSection.ChildNodes.Count; num4++)
		{
			XmlNode xmlNode2 = xMLSection.ChildNodes[num4];
			if (xmlNode2 == null)
			{
				__ldtoken(Game.SetXMLData(ref XmlNode));
			}
			else
			{
				RoomGroups.Add(xmlNode2.InnerText);
			}
		}
	}

	public Room GetRoomForValidation(string rmid)
	{
		Room room = null;
		try
		{
			return GetRoomByID(new Guid(rmid));
		}
		catch
		{
			return null;
		}
	}

	public void RemoveRoomObject(Guid RoomID, string ObjectName)
	{
		Room roomByID = GetRoomByID(RoomID);
		if (roomByID == null)
		{
			__ldtoken(Game.RemoveRoomObject(Guid, string));
			return;
		}
		IEnumerator enumerator = ObjectList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Game.RemoveRoomObject(Guid, string));
				GameObject gameObject = (GameObject)enumerator.Current;
				if (gameObject.locationtype != GameObject.LocationType.LT_ROOM)
				{
					__ldtoken(Game.RemoveRoomObject(Guid, string));
				}
				else if (gameObject.locationname == RoomID.ToString() && gameObject.name == ObjectName)
				{
					gameObject.locationtype = GameObject.LocationType.LT_NULL;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Game.RemoveRoomObject(Guid, string));
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public GameVariable GetVariableByName(string varname)
	{
		if (varname.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)) <= -1)
		{
			__ldtoken(Game.GetVariableByName(string));
		}
		else
		{
			varname = varname.Substring(0, varname.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)));
		}
		for (int i = 0; i < VariableList.Count; i++)
		{
			if (string.Compare(varname, ((GameVariable)VariableList[i]).varname, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetVariableByName(string));
				continue;
			}
			return (GameVariable)VariableList[i];
		}
		return null;
	}

	public StatusBarItem GetStatusBarItemByName(string name)
	{
		for (int i = 0; i < StatusBarItems.Count; i++)
		{
			if (string.Compare(name, ((StatusBarItem)StatusBarItems[i]).Name, ignoreCase: true) == 0)
			{
				return (StatusBarItem)StatusBarItems[i];
			}
		}
		return null;
	}

	public Room GetRoomByName(ref string roomname)
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			__ldtoken(Game.GetRoomByName(ref string));
			if (string.Compare(roomname, ((Room)RoomList[i]).Name, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetRoomByName(ref string));
				continue;
			}
			return (Room)RoomList[i];
		}
		return null;
	}

	public Room GetRoomByID(Guid roomid)
	{
		IEnumerator enumerator = RoomList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Game.GetRoomByID(Guid));
				Room room = (Room)enumerator.Current;
				if (roomid.CompareTo(room.UniqueID) == 0)
				{
					return room;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public object GetPictureByName(string picname)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		for (int i = 0; i < PictureList.Count; i++)
		{
			__ldtoken(Game.GetPictureByName(string));
			if (string.Compare(picname, ((GamePicture)PictureList[i]).TheName, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetPictureByName(string));
				continue;
			}
			byte[] array = null;
			try
			{
				SqlCeConnection dBConnection = GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19504), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), ((GamePicture)PictureList[i]).TheName);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
				if (!sqlCeDataReader.Read())
				{
					__ldtoken(Game.GetPictureByName(string));
				}
				else
				{
					array = (byte[])sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)];
				}
			}
			catch
			{
				array = ((GamePicture)PictureList[i]).ImageData;
			}
			if (array == null)
			{
				__ldtoken(Game.GetPictureByName(string));
				continue;
			}
			MemoryStream memoryStream = new MemoryStream(array);
			try
			{
				Image val = Image.FromStream((Stream)memoryStream);
				FrameDimension val2 = new FrameDimension(val.FrameDimensionsList[0]);
				val.GetFrameCount(val2);
				return Image.FromStream((Stream)memoryStream);
			}
			catch
			{
				string tempPath = Path.GetTempPath();
				tempPath = Path.Combine(tempPath, picname);
				try
				{
					FileStream fileStream = new FileStream(tempPath, FileMode.Create);
					fileStream.Write(array, 0, array.Length);
					fileStream.Flush();
					fileStream.Close();
					fileStream.Dispose();
				}
				catch (Exception)
				{
					tempPath = Path.GetTempPath();
					tempPath = Path.Combine(tempPath, DateTime.Now.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50618)) + picname);
					FileStream fileStream2 = new FileStream(tempPath, FileMode.Create);
					fileStream2.Write(array, 0, array.Length);
					fileStream2.Flush();
					fileStream2.Close();
					fileStream2.Dispose();
				}
				return tempPath;
			}
		}
		return null;
	}

	public GamePicture GetGamePictureByName(string picname)
	{
		for (int i = 0; i < PictureList.Count; i++)
		{
			__ldtoken(Game.GetGamePictureByName(string));
			if (string.Compare(picname, ((GamePicture)PictureList[i]).TheName, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetGamePictureByName(string));
				continue;
			}
			return (GamePicture)PictureList[i];
		}
		return null;
	}

	public Character GetCharacterByName(string charname)
	{
		for (int i = 0; i < CharacterList.Count; i++)
		{
			if (string.Compare(charname, ((Character)CharacterList[i]).Charname, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetCharacterByName(string));
				continue;
			}
			return (Character)CharacterList[i];
		}
		return null;
	}

	public GameObject GetObjectByName(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			__ldtoken(Game.GetObjectByName(string));
			if (string.Compare(objectname, ((GameObject)ObjectList[i]).UniqueIdentifier.ToString(), ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetObjectByName(string));
				continue;
			}
			return (GameObject)ObjectList[i];
		}
		return null;
	}

	public GameObject GetObjectByNameOld(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			__ldtoken(Game.GetObjectByNameOld(string));
			if (string.Compare(objectname, ((GameObject)ObjectList[i]).name, ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetObjectByNameOld(string));
				continue;
			}
			return (GameObject)ObjectList[i];
		}
		return null;
	}

	public QuickMenuItem GetMenuItemByName(string mnuitemguid)
	{
		for (int i = 0; i < QuickCommands.Count; i++)
		{
			__ldtoken(Game.GetMenuItemByName(string));
			if (string.Compare(mnuitemguid, ((QuickMenuItem)QuickCommands[i]).UniqueID.ToString(), ignoreCase: true) != 0)
			{
				__ldtoken(Game.GetMenuItemByName(string));
				continue;
			}
			return (QuickMenuItem)QuickCommands[i];
		}
		return null;
	}

	public Timer GetTimerByName(string timername)
	{
		for (int i = 0; i < TimerList.Count; i++)
		{
			__ldtoken(Game.GetTimerByName(string));
			if (string.Compare(timername, ((Timer)TimerList[i]).Name, ignoreCase: true) == 0)
			{
				return (Timer)TimerList[i];
			}
		}
		return null;
	}

	public void MovePlayer(Exit.Directions dir)
	{
		for (int i = 0; i < ThePlayer.CurrentRoom.Exits.Count; i++)
		{
			__ldtoken(Game.MovePlayer(Exit.Directions));
			Exit exit = (Exit)ThePlayer.CurrentRoom.Exits[i];
			if (exit.Direction != dir)
			{
				__ldtoken(Game.MovePlayer(Exit.Directions));
				continue;
			}
			ThePlayer.CurrentRoom = GetRoomByID(new Guid(exit.DestinationRoom));
			break;
		}
	}

	private void c66d4d0d3b90fea1270adadb3abfcd994(ref Action P_0)
	{
		for (int i = 0; i < P_0.PassCommands.Count; i++)
		{
			Command command = P_0.PassCommands[i] as Command;
			Condition condition = P_0.PassCommands[i] as Condition;
			if (command != null)
			{
				c4f607d07e3e3d966c0b8dbba0b0b0689(ref command);
			}
			else if (condition == null)
			{
				__ldtoken(Game.c66d4d0d3b90fea1270adadb3abfcd994(ref Action));
			}
			else
			{
				c7a04f0391bb7a707dfac5a765bdc7123(ref condition);
			}
		}
		for (int j = 0; j < P_0.FailCommands.Count; j++)
		{
			__ldtoken(Game.c66d4d0d3b90fea1270adadb3abfcd994(ref Action));
			Command command2 = P_0.FailCommands[j] as Command;
			Condition condition2 = P_0.FailCommands[j] as Condition;
			if (command2 == null)
			{
				__ldtoken(Game.c66d4d0d3b90fea1270adadb3abfcd994(ref Action));
				if (condition2 != null)
				{
					c7a04f0391bb7a707dfac5a765bdc7123(ref condition2);
				}
			}
			else
			{
				c4f607d07e3e3d966c0b8dbba0b0b0689(ref command2);
			}
		}
		for (int k = 0; k < P_0.Conditions.Count; k++)
		{
			__ldtoken(Game.c66d4d0d3b90fea1270adadb3abfcd994(ref Action));
			Condition condition3 = (Condition)P_0.Conditions[k];
			c7a04f0391bb7a707dfac5a765bdc7123(ref condition3);
		}
	}

	private void c7a04f0391bb7a707dfac5a765bdc7123(ref Condition P_0)
	{
		for (int i = 0; i < P_0.Checks.Count; i++)
		{
			__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			Check check = (Check)P_0.Checks[i];
			c4cb7571be471e7ac4f35e3e94c42efde(ref check);
		}
		for (int j = 0; j < P_0.PassCommands.Count; j++)
		{
			__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			Command command = P_0.PassCommands[j] as Command;
			Condition condition = P_0.PassCommands[j] as Condition;
			if (command == null)
			{
				__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			}
			else
			{
				c4f607d07e3e3d966c0b8dbba0b0b0689(ref command);
			}
			if (condition == null)
			{
				__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			}
			else
			{
				c7a04f0391bb7a707dfac5a765bdc7123(ref condition);
			}
		}
		for (int k = 0; k < P_0.FailCommands.Count; k++)
		{
			__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			Command command2 = P_0.FailCommands[k] as Command;
			Condition condition2 = P_0.FailCommands[k] as Condition;
			if (command2 == null)
			{
				__ldtoken(Game.c7a04f0391bb7a707dfac5a765bdc7123(ref Condition));
			}
			else
			{
				c4f607d07e3e3d966c0b8dbba0b0b0689(ref command2);
			}
			if (condition2 != null)
			{
				c7a04f0391bb7a707dfac5a765bdc7123(ref condition2);
			}
		}
	}

	private void c4cb7571be471e7ac4f35e3e94c42efde(ref Check P_0)
	{
		switch (P_0.CondType)
		{
		case Condition.ConditionType.CT_Player_In_Room:
			__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
			try
			{
				new Guid(P_0.ConditionStep2);
				break;
			}
			catch
			{
				if (GetRoomByName(ref P_0.ConditionStep2) == null)
				{
					__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
				}
				else
				{
					P_0.ConditionStep2 = GetRoomByName(ref P_0.ConditionStep2).UniqueID.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_In_Room:
			try
			{
				new Guid(P_0.ConditionStep2);
			}
			catch
			{
				if (GetObjectByNameOld(P_0.ConditionStep2) == null)
				{
					__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
				}
				else
				{
					P_0.ConditionStep2 = GetObjectByNameOld(P_0.ConditionStep2).UniqueIdentifier.ToString();
				}
			}
			try
			{
				new Guid(P_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetRoomByName(ref P_0.ConditionStep3) != null)
				{
					P_0.ConditionStep3 = GetRoomByName(ref P_0.ConditionStep3).UniqueID.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_Held_By_Character:
			try
			{
				new Guid(P_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(P_0.ConditionStep3) == null)
				{
					__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
				}
				else
				{
					P_0.ConditionStep3 = GetObjectByNameOld(P_0.ConditionStep3).UniqueIdentifier.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_Held_By_Player:
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
		case Condition.ConditionType.CT_Item_State_Check:
			try
			{
				new Guid(P_0.ConditionStep2);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(P_0.ConditionStep2) != null)
				{
					P_0.ConditionStep2 = GetObjectByNameOld(P_0.ConditionStep2).UniqueIdentifier.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_In_Object:
			try
			{
				new Guid(P_0.ConditionStep2);
			}
			catch
			{
				if (GetObjectByNameOld(P_0.ConditionStep2) == null)
				{
					__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
				}
				else
				{
					P_0.ConditionStep2 = GetObjectByNameOld(P_0.ConditionStep2).UniqueIdentifier.ToString();
				}
			}
			try
			{
				new Guid(P_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(P_0.ConditionStep2) == null)
				{
					__ldtoken(Game.c4cb7571be471e7ac4f35e3e94c42efde(ref Check));
				}
				else
				{
					P_0.ConditionStep3 = GetObjectByNameOld(P_0.ConditionStep3).UniqueIdentifier.ToString();
				}
				break;
			}
		}
	}

	private void c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command P_0)
	{
		string roomname = P_0.CommandPart2;
		string roomname2 = P_0.CommandPart3;
		Command.CommandType cmdtype = P_0.cmdtype;
		if (cmdtype > Command.CommandType.CT_MOVEPLAYER)
		{
			__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
			switch (cmdtype)
			{
			case Command.CommandType.CT_SETROOMPIC:
				__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				break;
			case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
			case Command.CommandType.CT_DISPLAYROOMPICTURE:
			case Command.CommandType.CT_SETROOMACTION:
			case Command.CommandType.CT_SETROOMDESCRIPTION:
			case Command.CommandType.CT_SETEXIT:
				break;
			default:
				return;
			}
		}
		else
		{
			switch (cmdtype)
			{
			case Command.CommandType.CT_MOVECHAR:
				__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				if (P_0.CommandPart3 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943))
				{
					if (P_0.CommandPart3 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886))
					{
						try
						{
							new Guid(roomname2);
							return;
						}
						catch
						{
							try
							{
								P_0.CommandPart3 = GetRoomByName(ref roomname2).UniqueID.ToString();
								return;
							}
							catch
							{
								return;
							}
						}
					}
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				}
				if (!(P_0.CommandPart3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					if (!(P_0.CommandPart3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886)))
					{
						__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					}
					else
					{
						P_0.CommandPart3 = Room.VoidRoomGuid.ToString();
					}
				}
				else
				{
					P_0.CommandPart3 = Room.CurrentRoomGuid.ToString();
				}
				return;
			case Command.CommandType.CT_DISPLAYITEMDESC:
			case Command.CommandType.CT_MOVEITEMTOCHAR:
			case Command.CommandType.CT_MOVEITEMTOINV:
			case Command.CommandType.CT_SETOBJECTACTION:
			case Command.CommandType.CT_SETITEMDESC:
			case Command.CommandType.CT_SETLOCKEDUNLOCKED:
			case Command.CommandType.CT_SETOPENCLOSED:
			case Command.CommandType.CT_SETITEMTOWORN:
			case Command.CommandType.CT_ITEM_SET_VISIBILITY:
			case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
				if (P_0.CommandPart2 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029))
				{
					try
					{
						new Guid(roomname);
						return;
					}
					catch
					{
						try
						{
							P_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
							return;
						}
						catch
						{
							return;
						}
					}
				}
				if (!(P_0.CommandPart2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				}
				else
				{
					P_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
				}
				return;
			case Command.CommandType.CT_MOVEITEMTOOBJ:
				if (!(P_0.CommandPart2 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					if (!(P_0.CommandPart2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
					{
						__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					}
					else
					{
						P_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
					}
				}
				else
				{
					try
					{
						new Guid(roomname);
					}
					catch
					{
						try
						{
							P_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
						}
						catch
						{
						}
					}
				}
				if (!(P_0.CommandPart3 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					if (!(P_0.CommandPart3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029)))
					{
						__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					}
					else
					{
						P_0.CommandPart3 = GameObject.SelfObjectGuid.ToString();
					}
					return;
				}
				try
				{
					new Guid(roomname2);
					return;
				}
				catch
				{
					try
					{
						P_0.CommandPart3 = GetObjectByNameOld(roomname2).UniqueIdentifier.ToString();
						return;
					}
					catch
					{
						return;
					}
				}
			case Command.CommandType.CT_MOVEINVENTORYTOROOM:
			case Command.CommandType.CT_MOVEPLAYER:
				break;
			case Command.CommandType.CT_MOVEITEMTOROOM:
				if (P_0.CommandPart2 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029))
				{
					try
					{
						new Guid(roomname);
					}
					catch
					{
						try
						{
							P_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
						}
						catch
						{
						}
					}
				}
				else if (P_0.CommandPart2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5029))
				{
					P_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
				}
				if (!(P_0.CommandPart3 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				}
				else
				{
					if (P_0.CommandPart3 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886))
					{
						try
						{
							new Guid(roomname2);
							return;
						}
						catch
						{
							try
							{
								P_0.CommandPart3 = GetRoomByName(ref roomname2).UniqueID.ToString();
								return;
							}
							catch
							{
								return;
							}
						}
					}
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
				}
				if (!(P_0.CommandPart3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943)))
				{
					__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					if (!(P_0.CommandPart3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886)))
					{
						__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
					}
					else
					{
						P_0.CommandPart3 = Room.VoidRoomGuid.ToString();
					}
				}
				else
				{
					P_0.CommandPart3 = Room.CurrentRoomGuid.ToString();
				}
				return;
			default:
				return;
			}
		}
		if (!(P_0.CommandPart2 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943)))
		{
			__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
		}
		else
		{
			if (P_0.CommandPart2 != cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886))
			{
				try
				{
					new Guid(roomname);
					return;
				}
				catch
				{
					try
					{
						P_0.CommandPart2 = GetRoomByName(ref roomname).UniqueID.ToString();
						return;
					}
					catch
					{
						return;
					}
				}
			}
			__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
		}
		if (!(P_0.CommandPart2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2943)))
		{
			__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
			if (!(P_0.CommandPart2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(6886)))
			{
				__ldtoken(Game.c4f607d07e3e3d966c0b8dbba0b0b0689(ref Command));
			}
			else
			{
				P_0.CommandPart2 = Room.VoidRoomGuid.ToString();
			}
		}
		else
		{
			P_0.CommandPart2 = Room.CurrentRoomGuid.ToString();
		}
	}

	private string c98096a9737d31712ab1800429b9f189f(ref Action P_0, ref Game P_1)
	{
		string text = string.Empty;
		for (int i = 0; i < P_0.PassCommands.Count; i++)
		{
			Command tempcmd = P_0.PassCommands[i] as Command;
			Condition condition = P_0.PassCommands[i] as Condition;
			if (tempcmd == null)
			{
				__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
			}
			else
			{
				text += Command.ValidateCommand(ref tempcmd, ref P_1);
			}
		}
		for (int j = 0; j < P_0.FailCommands.Count; j++)
		{
			__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
			Command tempcmd2 = P_0.FailCommands[j] as Command;
			Condition condition2 = P_0.FailCommands[j] as Condition;
			if (tempcmd2 == null)
			{
				__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
			}
			else
			{
				text += Command.ValidateCommand(ref tempcmd2, ref P_1);
			}
		}
		for (int k = 0; k < P_0.Conditions.Count; k++)
		{
			bool flag = false;
			Condition condition3 = (Condition)P_0.Conditions[k];
			for (int l = 0; l < condition3.Checks.Count; l++)
			{
				__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
				Check tempcheck = (Check)condition3.Checks[l];
				string text2 = Check.ValidateCheck(ref tempcheck, ref P_1);
				if (text2.Length > 0)
				{
					if (flag)
					{
						__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
					}
					else
					{
						flag = true;
						text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50649) + condition3.conditionname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287);
					}
					text += text2;
				}
			}
			for (int m = 0; m < condition3.PassCommands.Count; m++)
			{
				__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
				Command tempcmd3 = condition3.PassCommands[m] as Command;
				Condition condition4 = condition3.PassCommands[m] as Condition;
				if (tempcmd3 == null)
				{
					continue;
				}
				string text3 = Command.ValidateCommand(ref tempcmd3, ref P_1);
				if (text3.Length <= 0)
				{
					__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
					continue;
				}
				if (flag)
				{
					__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
				}
				else
				{
					flag = true;
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50649) + condition3.conditionname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287);
				}
				text += text3;
			}
			for (int n = 0; n < condition3.FailCommands.Count; n++)
			{
				Command tempcmd4 = condition3.FailCommands[n] as Command;
				Condition condition5 = condition3.FailCommands[n] as Condition;
				if (tempcmd4 == null)
				{
					__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
					continue;
				}
				string text4 = Command.ValidateCommand(ref tempcmd4, ref P_1);
				if (text4.Length > 0)
				{
					if (flag)
					{
						__ldtoken(Game.c98096a9737d31712ab1800429b9f189f(ref Action, ref Game));
					}
					else
					{
						flag = true;
						text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50649) + condition3.conditionname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287);
					}
					text += text4;
				}
			}
		}
		return text;
	}

	public string ValidateCommandsAndConditions()
	{
		bool flag = false;
		string text = string.Empty;
		for (int i = 0; i < RoomList.Count; i++)
		{
			__ldtoken(Game.ValidateCommandsAndConditions());
			Room room = (Room)RoomList[i];
			flag = false;
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Action action = (Action)room.Actions[j];
				Game game = this;
				string text2 = c98096a9737d31712ab1800429b9f189f(ref action, ref game);
				if (text2.Length <= 0)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
					continue;
				}
				if (flag)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
				}
				else
				{
					flag = true;
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50696) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50733);
				}
				text += text2;
			}
			for (int k = 0; k < room.Exits.Count; k++)
			{
				if (!(room.Exits[k] is Exit exit))
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
				}
				else if (exit.bActive && exit.DestinationRoom == null)
				{
					exit.bActive = false;
				}
			}
		}
		for (int l = 0; l < ObjectList.Count; l++)
		{
			__ldtoken(Game.ValidateCommandsAndConditions());
			GameObject gameObject = (GameObject)ObjectList[l];
			flag = false;
			for (int m = 0; m < gameObject.Actions.Count; m++)
			{
				__ldtoken(Game.ValidateCommandsAndConditions());
				Action action2 = (Action)gameObject.Actions[m];
				Game game2 = this;
				string text3 = c98096a9737d31712ab1800429b9f189f(ref action2, ref game2);
				if (text3.Length <= 0)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
					continue;
				}
				if (flag)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
				}
				else
				{
					flag = true;
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50754) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50733);
				}
				text += text3;
			}
		}
		flag = false;
		for (int n = 0; n < ThePlayer.Actions.Count; n++)
		{
			__ldtoken(Game.ValidateCommandsAndConditions());
			Action action3 = (Action)ThePlayer.Actions[n];
			Game game3 = this;
			string text4 = c98096a9737d31712ab1800429b9f189f(ref action3, ref game3);
			if (text4.Length <= 0)
			{
				__ldtoken(Game.ValidateCommandsAndConditions());
				continue;
			}
			if (flag)
			{
				__ldtoken(Game.ValidateCommandsAndConditions());
			}
			else
			{
				flag = true;
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50795);
			}
			text += text4;
		}
		for (int num = 0; num < CharacterList.Count; num++)
		{
			__ldtoken(Game.ValidateCommandsAndConditions());
			Character character = (Character)CharacterList[num];
			flag = false;
			for (int num2 = 0; num2 < character.Actions.Count; num2++)
			{
				__ldtoken(Game.ValidateCommandsAndConditions());
				Action action4 = (Action)character.Actions[num2];
				Game game4 = this;
				string text5 = c98096a9737d31712ab1800429b9f189f(ref action4, ref game4);
				if (text5.Length <= 0)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
					continue;
				}
				if (flag)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
				}
				else
				{
					flag = true;
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50854) + character.Charname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50733);
				}
				text += text5;
			}
		}
		for (int num3 = 0; num3 < TimerList.Count; num3++)
		{
			__ldtoken(Game.ValidateCommandsAndConditions());
			Timer timer = (Timer)TimerList[num3];
			flag = false;
			for (int num4 = 0; num4 < timer.Actions.Count; num4++)
			{
				__ldtoken(Game.ValidateCommandsAndConditions());
				Action action5 = (Action)timer.Actions[num4];
				Game game5 = this;
				string text6 = c98096a9737d31712ab1800429b9f189f(ref action5, ref game5);
				if (text6.Length <= 0)
				{
					__ldtoken(Game.ValidateCommandsAndConditions());
					continue;
				}
				if (!flag)
				{
					flag = true;
					text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50901) + timer.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50733);
				}
				text += text6;
			}
		}
		return text;
	}

	public void CorrectCommandAndConditions()
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			__ldtoken(Game.CorrectCommandAndConditions());
			Room room = (Room)RoomList[i];
			if (room.Exits.Count == 10)
			{
				Exit exit = new Exit();
				exit.Direction = Exit.Directions.In;
				room.Exits.Add(exit);
				exit = new Exit();
				exit.Direction = Exit.Directions.Out;
				room.Exits.Add(exit);
			}
			for (int j = 0; j < room.Actions.Count; j++)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
				Action action = (Action)room.Actions[j];
				c66d4d0d3b90fea1270adadb3abfcd994(ref action);
			}
		}
		for (int k = 0; k < CharacterList.Count; k++)
		{
			Character character = (Character)CharacterList[k];
			bool flag = true;
			{
				IEnumerator enumerator = character.Actions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Game.CorrectCommandAndConditions());
						Action action2 = (Action)enumerator.Current;
						if (action2.name == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50940))
						{
							__ldtoken(Game.CorrectCommandAndConditions());
						}
						else if (!(action2.name == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50985)))
						{
							__ldtoken(Game.CorrectCommandAndConditions());
							continue;
						}
						flag = false;
						break;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (!flag)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
				continue;
			}
			Action action3 = new Action();
			character.Actions.Insert(0, action3);
			action3.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50985);
			action3 = new Action();
			character.Actions.Insert(0, action3);
			action3.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50940);
		}
		for (int l = 0; l < ObjectList.Count; l++)
		{
			GameObject gameObject = (GameObject)ObjectList[l];
			if (gameObject.locationtype != GameObject.LocationType.LT_IN_OBJECT)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
			}
			else
			{
				try
				{
					new Guid(gameObject.locationname);
				}
				catch
				{
					GameObject objectByNameOld = GetObjectByNameOld(gameObject.locationname);
					if (objectByNameOld == null)
					{
						__ldtoken(Game.CorrectCommandAndConditions());
						gameObject.locationtype = GameObject.LocationType.LT_NULL;
					}
					else
					{
						gameObject.locationname = objectByNameOld.UniqueIdentifier.ToString();
					}
				}
			}
			for (int m = 0; m < gameObject.Actions.Count; m++)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
				Action action4 = (Action)gameObject.Actions[m];
				c66d4d0d3b90fea1270adadb3abfcd994(ref action4);
			}
		}
		for (int n = 0; n < ThePlayer.Actions.Count; n++)
		{
			__ldtoken(Game.CorrectCommandAndConditions());
			Action action5 = (Action)ThePlayer.Actions[n];
			c66d4d0d3b90fea1270adadb3abfcd994(ref action5);
		}
		for (int num = 0; num < CharacterList.Count; num++)
		{
			Character character2 = (Character)CharacterList[num];
			for (int num2 = 0; num2 < character2.Actions.Count; num2++)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
				Action action6 = (Action)character2.Actions[num2];
				c66d4d0d3b90fea1270adadb3abfcd994(ref action6);
			}
		}
		for (int num3 = 0; num3 < TimerList.Count; num3++)
		{
			__ldtoken(Game.CorrectCommandAndConditions());
			Timer timer = (Timer)TimerList[num3];
			for (int num4 = 0; num4 < timer.Actions.Count; num4++)
			{
				__ldtoken(Game.CorrectCommandAndConditions());
				Action action7 = (Action)timer.Actions[num4];
				c66d4d0d3b90fea1270adadb3abfcd994(ref action7);
			}
		}
	}

	public void RefactorObject(string oldname, string newname)
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			__ldtoken(Game.RefactorObject(string, string));
			Room room = (Room)RoomList[i];
			for (int j = 0; j < room.Actions.Count; j++)
			{
				__ldtoken(Game.RefactorObject(string, string));
				Action tempact = (Action)room.Actions[j];
				RefactorAction(ref tempact, oldname, newname);
			}
		}
		for (int k = 0; k < ObjectList.Count; k++)
		{
			__ldtoken(Game.RefactorObject(string, string));
			GameObject gameObject = (GameObject)ObjectList[k];
			for (int l = 0; l < gameObject.Actions.Count; l++)
			{
				__ldtoken(Game.RefactorObject(string, string));
				Action tempact2 = (Action)gameObject.Actions[l];
				RefactorAction(ref tempact2, oldname, newname);
			}
		}
		for (int m = 0; m < ThePlayer.Actions.Count; m++)
		{
			__ldtoken(Game.RefactorObject(string, string));
			Action tempact3 = (Action)ThePlayer.Actions[m];
			RefactorAction(ref tempact3, oldname, newname);
		}
		for (int n = 0; n < CharacterList.Count; n++)
		{
			__ldtoken(Game.RefactorObject(string, string));
			Character character = (Character)CharacterList[n];
			for (int num = 0; num < character.Actions.Count; num++)
			{
				__ldtoken(Game.RefactorObject(string, string));
				Action tempact4 = (Action)character.Actions[num];
				RefactorAction(ref tempact4, oldname, newname);
			}
		}
		for (int num2 = 0; num2 < TimerList.Count; num2++)
		{
			Timer timer = (Timer)TimerList[num2];
			for (int num3 = 0; num3 < timer.Actions.Count; num3++)
			{
				Action tempact5 = (Action)timer.Actions[num3];
				RefactorAction(ref tempact5, oldname, newname);
			}
		}
	}

	public void RefactorAction(ref Action tempact, string oldname, string newname)
	{
		for (int i = 0; i < tempact.PassCommands.Count; i++)
		{
			__ldtoken(Game.RefactorAction(ref Action, string, string));
			Command command = tempact.PassCommands[i] as Command;
			Condition condition = tempact.PassCommands[i] as Condition;
			if (command == null)
			{
				__ldtoken(Game.RefactorAction(ref Action, string, string));
				c6be80191293e1209854f6480ffa5fc68(ref condition, oldname, newname);
			}
			else
			{
				c3c65c9ef67fc736dbe695fc16c8334ef(ref command, oldname, newname);
			}
		}
		for (int j = 0; j < tempact.FailCommands.Count; j++)
		{
			__ldtoken(Game.RefactorAction(ref Action, string, string));
			Command command2 = tempact.FailCommands[j] as Command;
			Condition condition2 = tempact.FailCommands[j] as Condition;
			if (command2 == null)
			{
				__ldtoken(Game.RefactorAction(ref Action, string, string));
				c6be80191293e1209854f6480ffa5fc68(ref condition2, oldname, newname);
			}
			else
			{
				c3c65c9ef67fc736dbe695fc16c8334ef(ref command2, oldname, newname);
			}
		}
		for (int k = 0; k < tempact.Conditions.Count; k++)
		{
			__ldtoken(Game.RefactorAction(ref Action, string, string));
			Condition condition3 = (Condition)tempact.Conditions[k];
			c6be80191293e1209854f6480ffa5fc68(ref condition3, oldname, newname);
		}
	}

	private void c6be80191293e1209854f6480ffa5fc68(ref Condition P_0, string P_1, string P_2)
	{
		for (int i = 0; i < P_0.Checks.Count; i++)
		{
			__ldtoken(Game.c6be80191293e1209854f6480ffa5fc68(ref Condition, string, string));
			Check check = (Check)P_0.Checks[i];
			c2b392940e9f791b3b46aa506ea5e49c9(ref check, P_1, P_2);
		}
		for (int j = 0; j < P_0.PassCommands.Count; j++)
		{
			Command command = P_0.PassCommands[j] as Command;
			Condition condition = P_0.PassCommands[j] as Condition;
			if (command == null)
			{
				__ldtoken(Game.c6be80191293e1209854f6480ffa5fc68(ref Condition, string, string));
				c6be80191293e1209854f6480ffa5fc68(ref condition, P_1, P_2);
			}
			else
			{
				c3c65c9ef67fc736dbe695fc16c8334ef(ref command, P_1, P_2);
			}
		}
		for (int k = 0; k < P_0.FailCommands.Count; k++)
		{
			__ldtoken(Game.c6be80191293e1209854f6480ffa5fc68(ref Condition, string, string));
			Command command2 = P_0.FailCommands[k] as Command;
			Condition condition2 = P_0.FailCommands[k] as Condition;
			if (command2 == null)
			{
				__ldtoken(Game.c6be80191293e1209854f6480ffa5fc68(ref Condition, string, string));
				c6be80191293e1209854f6480ffa5fc68(ref condition2, P_1, P_2);
			}
			else
			{
				c3c65c9ef67fc736dbe695fc16c8334ef(ref command2, P_1, P_2);
			}
		}
	}

	private void c2b392940e9f791b3b46aa506ea5e49c9(ref Check P_0, string P_1, string P_2)
	{
		if (!(P_0.ConditionStep2 == P_1))
		{
			__ldtoken(Game.c2b392940e9f791b3b46aa506ea5e49c9(ref Check, string, string));
		}
		else
		{
			P_0.ConditionStep2 = P_2;
		}
		if (P_0.ConditionStep3 == P_1)
		{
			P_0.ConditionStep3 = P_2;
		}
		if (!(P_0.ConditionStep4 == P_1))
		{
			__ldtoken(Game.c2b392940e9f791b3b46aa506ea5e49c9(ref Check, string, string));
		}
		else
		{
			P_0.ConditionStep4 = P_2;
		}
	}

	private void c3c65c9ef67fc736dbe695fc16c8334ef(ref Command P_0, string P_1, string P_2)
	{
		if (P_0.CommandPart2 == P_1)
		{
			P_0.CommandPart2 = P_2;
		}
		if (!(P_0.CommandPart3 == P_1))
		{
			__ldtoken(Game.c3c65c9ef67fc736dbe695fc16c8334ef(ref Command, string, string));
		}
		else
		{
			P_0.CommandPart3 = P_2;
		}
		if (!(P_0.CommandPart4 == P_1))
		{
			__ldtoken(Game.c3c65c9ef67fc736dbe695fc16c8334ef(ref Command, string, string));
		}
		else
		{
			P_0.CommandPart4 = P_2;
		}
		if (!(P_0.CommandText == P_1))
		{
			__ldtoken(Game.c3c65c9ef67fc736dbe695fc16c8334ef(ref Command, string, string));
		}
		else
		{
			P_0.CommandText = P_2;
		}
	}

	private string c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable P_0)
	{
		bool flag = false;
		bool flag2 = true;
		switch (P_0.vartype)
		{
		case GameVariable.VarType.VT_NUMBERARRAY:
			flag2 = false;
			flag = true;
			break;
		case GameVariable.VarType.VT_STRINGARRAY:
		case GameVariable.VarType.VT_DATETIMEARRAY:
			flag = true;
			break;
		}
		if (!flag)
		{
			return string.Empty;
		}
		string text = string.Empty;
		try
		{
			int num = -1;
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
			for (int i = 0; i < P_0.VarArray.Count; i++)
			{
				__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
				num++;
				if (num <= 0)
				{
					__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
				}
				if (!(P_0.VarArray[i] is ArrayList arrayList))
				{
					__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
					if (!flag2)
					{
						__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
						text += P_0.VarArray[i].ToString();
					}
					else
					{
						text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + P_0.VarArray[i].ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011);
					}
					continue;
				}
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
				int num2 = -1;
				{
					IEnumerator enumerator = arrayList.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
							object current = enumerator.Current;
							num2++;
							if (num2 <= 0)
							{
								__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
							}
							if (!flag2)
							{
								__ldtoken(Game.c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref GameVariable));
								text += current.ToString();
							}
							else
							{
								text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + current.ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011);
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
			}
			text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51035);
		}
		catch
		{
		}
		return text;
	}

	private void caac7109a78be18e2077a824724a7d693(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 3);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843), P_1, StringComparison.OrdinalIgnoreCase);
		if (num2 >= num)
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		else
		{
			if (num2 != -1)
			{
				int num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857), P_1, StringComparison.OrdinalIgnoreCase);
				if (num3 == -1)
				{
					return;
				}
				string text = P_0.Substring(P_1, num2 - P_1).Trim();
				if (num3 - (num2 + 1) < 0)
				{
					return;
				}
				__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				string text2 = P_0.Substring(num2 + 1, num3 - (num2 + 1)).Trim();
				int num4 = 0;
				try
				{
					num4 = Convert.ToInt32(PerformTextReplacements(text2, null));
				}
				catch
				{
					num4 = -1;
				}
				int num5 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857), num3 + 1, StringComparison.OrdinalIgnoreCase);
				int num6 = -1;
				if (num5 == -1)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				}
				else
				{
					try
					{
						string text3 = P_0.Substring(num3 + 2, num5 - (num3 + 2));
						num6 = Convert.ToInt32(PerformTextReplacements(text3, null));
					}
					catch
					{
						num6 = -1;
						num5 = -1;
					}
				}
				if (num4 <= -1)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
					return;
				}
				string text4 = string.Empty;
				if (text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) <= -1)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				}
				else
				{
					text4 = text.Substring(text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) + 1);
					text = text.Substring(0, text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)));
				}
				GameVariable variableByName = GetVariableByName(text);
				if (variableByName == null)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
					return;
				}
				int num7 = 0;
				if (num5 <= -1)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
					num7 = num3 - P_1 + 2;
				}
				else
				{
					num7 = num5 - P_1 + 2;
				}
				P_0 = P_0.Remove(P_1, num7);
				if (num4 >= variableByName.VarArray.Count)
				{
					return;
				}
				string value = string.Empty;
				switch (variableByName.vartype)
				{
				case GameVariable.VarType.VT_NUMBERARRAY:
				case GameVariable.VarType.VT_STRINGARRAY:
					if (num6 <= -1)
					{
						__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
						value = variableByName.VarArray[num4].ToString();
						if (!flag)
						{
							__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
						}
						else if (variableByName.vartype == GameVariable.VarType.VT_NUMBERARRAY)
						{
							variableByName.VarArray[num4] = Convert.ToDouble(P_2);
						}
						else
						{
							variableByName.VarArray[num4] = P_2;
						}
						break;
					}
					try
					{
						value = ((ArrayList)variableByName.VarArray[num4])[num6].ToString();
						if (flag)
						{
							((ArrayList)variableByName.VarArray[num4])[num6] = P_2;
						}
					}
					catch
					{
						value = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51040);
					}
					break;
				case GameVariable.VarType.VT_DATETIMEARRAY:
					if (num6 <= -1)
					{
						__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
						if (text4 != string.Empty)
						{
							value = ((DateTime)variableByName.VarArray[num4]).ToString(text4, myDTFI);
							if (flag)
							{
								try
								{
									variableByName.VarArray[num4] = Convert.ToDateTime(P_2);
								}
								catch
								{
									variableByName.VarArray[num4] = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51160);
								}
							}
						}
						else
						{
							value = ((DateTime)variableByName.VarArray[num4]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI);
						}
					}
					else
					{
						string value2 = ((ArrayList)variableByName.VarArray[num4])[num6].ToString();
						if (!flag)
						{
							__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
						}
						else
						{
							((ArrayList)variableByName.VarArray[num4])[num6] = P_2;
						}
						DateTime dateTime = Convert.ToDateTime(value2);
						value = ((!(text4 != string.Empty)) ? dateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI) : dateTime.ToString(text4, myDTFI));
					}
					break;
				}
				if (flag)
				{
					__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				}
				else
				{
					P_0 = P_0.Insert(P_1, value);
				}
				return;
			}
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		if (num <= -1)
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
			return;
		}
		string text5 = P_0.Substring(P_1, num - P_1).Trim();
		P_0 = P_0.Remove(P_1, num - P_1 + 1);
		string text6 = string.Empty;
		if (text5.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) <= -1)
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		else
		{
			text6 = text5.Substring(text5.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) + 1);
			text5 = text5.Substring(0, text5.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)));
		}
		GameVariable variableByName2 = GetVariableByName(text5);
		if (variableByName2 == null)
		{
			return;
		}
		string text7 = string.Empty;
		switch (variableByName2.vartype)
		{
		case GameVariable.VarType.VT_NUMBER:
			text7 = variableByName2.dNumType.ToString();
			if (!flag)
			{
				__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				break;
			}
			try
			{
				variableByName2.dNumType = Convert.ToDouble(P_2);
			}
			catch
			{
				variableByName2.dNumType = -1.0;
			}
			break;
		case GameVariable.VarType.VT_STRING:
			text7 = variableByName2.sString;
			if (!flag)
			{
				__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
			}
			else
			{
				variableByName2.sString = P_2;
			}
			break;
		case GameVariable.VarType.VT_DATETIME:
			if (!(text6 != string.Empty))
			{
				__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				text7 = variableByName2.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI);
				if (flag)
				{
					try
					{
						variableByName2.dtDateTime = Convert.ToDateTime(P_2);
					}
					catch
					{
						variableByName2.dtDateTime = DateTime.Now;
					}
				}
				break;
			}
			text7 = variableByName2.dtDateTime.ToString(text6, myDTFI);
			if (!flag)
			{
				__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
				break;
			}
			try
			{
				variableByName2.dtDateTime = Convert.ToDateTime(P_2);
			}
			catch
			{
				variableByName2.dtDateTime = DateTime.Now;
			}
			break;
		}
		if (!flag)
		{
			__ldtoken(Game.caac7109a78be18e2077a824724a7d693(ref string, int, string));
		}
		else
		{
			text7 = PerformTextReplacements(text7, null);
		}
		P_0 = P_0.Insert(P_1, text7);
	}

	private void c7be5186c9678dd0117a87e6b9a29096d(ref string P_0, int P_1, string P_2, ref object P_3)
	{
		if (P_1 >= 0 && P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51179)))
		{
			P_0 = P_0.Remove(P_1, 12);
			P_0 = P_0.Insert(P_1, ThePlayer.Name);
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51204), 0, StringComparison.OrdinalIgnoreCase);
		}
		if (P_1 >= 0 && P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51227)))
		{
			P_0 = P_0.Remove(P_1, 11);
			P_0 = P_0.Insert(P_1, AdditionalData);
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22448), 0, StringComparison.OrdinalIgnoreCase);
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51250)))
		{
			P_0 = P_0.Remove(P_1, 10);
			P_0 = P_0.Insert(P_1, ThePlayer.dWeightLimit.ToString());
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22471), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 >= 0 && P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51271)))
		{
			P_0 = P_0.Remove(P_1, 7);
			P_0 = P_0.Insert(P_1, TurnCount.ToString());
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22521), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 >= 0)
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51286)))
			{
				P_0 = P_0.Remove(P_1, 14);
				double num = 0.0;
				IEnumerator enumerator = ObjectList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
						GameObject gameObject = (GameObject)enumerator.Current;
						if (gameObject.locationtype == GameObject.LocationType.LT_PLAYER)
						{
							num += GetItemWeight(gameObject.UniqueIdentifier);
						}
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
					}
					else
					{
						disposable.Dispose();
					}
				}
				P_0 = P_0.Insert(P_1, num.ToString());
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22492), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51315)))
			{
				P_0 = P_0.Remove(P_1, 11);
				switch (ThePlayer.PlayerGender)
				{
				case Player.Gender.Female:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51338));
					break;
				case Player.Gender.Male:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51349));
					break;
				case Player.Gender.Other:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51356));
					break;
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22536), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51367)))
			{
				P_0 = P_0.Remove(P_1, 13);
				switch (ThePlayer.PlayerGender)
				{
				case Player.Gender.Female:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51394));
					break;
				case Player.Gender.Male:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51407));
					break;
				case Player.Gender.Other:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51416));
					break;
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22559), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51427)))
			{
				P_0 = P_0.Remove(P_1, 10);
				switch (ThePlayer.PlayerGender)
				{
				case Player.Gender.Female:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51448));
					break;
				case Player.Gender.Male:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51457));
					break;
				case Player.Gender.Other:
					P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51356));
					break;
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22586), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51464)))
		{
			P_1 = P_2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51464), 0, StringComparison.OrdinalIgnoreCase);
			GameVariable gameVariable = null;
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22897), P_1);
			if (num2 >= 0)
			{
				P_1 += 5;
				string varname = P_0.Substring(P_1, num2 - P_1);
				gameVariable = GetVariableByName(varname);
			}
			if (gameVariable == null)
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				P_0 = P_0.Remove(P_1, 5);
			}
			else
			{
				P_0 = P_0.Remove(P_1 - 5, num2 + 2 - (P_1 - 5));
				switch (gameVariable.vartype)
				{
				case GameVariable.VarType.VT_STRING:
					P_0 = P_0.Insert(P_1 - 5, gameVariable.sString.Length.ToString());
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
				case GameVariable.VarType.VT_STRINGARRAY:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					P_0 = P_0.Insert(P_1 - 5, gameVariable.VarArray.Count.ToString());
					break;
				}
			}
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51475), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 >= 0)
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51486)))
			{
				P_0 = P_0.Remove(P_1, 11);
				if (P_3 is Room room)
				{
					P_0 = P_0.Insert(P_1, room.Name);
				}
				else if (ThePlayer.CurrentRoom == null)
				{
					__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				}
				else
				{
					P_0 = P_0.Insert(P_1, ThePlayer.CurrentRoom.Name);
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22728), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51509)))
		{
			P_0 = P_0.Remove(P_1, 9);
			if (!(P_3 is Room room2))
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				if (ThePlayer.CurrentRoom == null)
				{
					__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				}
				else
				{
					P_0 = P_0.Insert(P_1, ThePlayer.CurrentRoom.UniqueID.ToString());
				}
			}
			else
			{
				P_0 = P_0.Insert(P_1, room2.UniqueID.ToString());
			}
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22751), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 >= 0)
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51528)))
			{
				P_0 = P_0.Remove(P_1, 13);
				if (P_3 is Exit exit)
				{
					string value = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51555);
					if (exit.bActive)
					{
						value = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51558);
					}
					P_0 = P_0.Insert(P_1, value);
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22770), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51561)))
			{
				P_0 = P_0.Remove(P_1, 16);
				if (!(P_3 is Exit exit2))
				{
					__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				}
				else
				{
					P_0 = P_0.Insert(P_1, exit2.Direction.ToString());
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22797), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51594)))
		{
			P_0 = P_0.Remove(P_1, 15);
			if (!(P_3 is Exit exit3))
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			}
			else
			{
				string empty = string.Empty;
				try
				{
					empty = GetRoomByID(new Guid(exit3.DestinationRoom)).GetName();
				}
				catch
				{
					empty = string.Empty;
				}
				P_0 = P_0.Insert(P_1, empty);
			}
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51625), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 >= 0)
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51656)))
			{
				P_0 = P_0.Remove(P_1, 13);
				if (!(P_3 is Exit exit4))
				{
					__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				}
				else
				{
					string empty2 = string.Empty;
					try
					{
						empty2 = exit4.DestinationRoom;
					}
					catch
					{
						empty2 = string.Empty;
					}
					P_0 = P_0.Insert(P_1, empty2);
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51683), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51710)))
			{
				P_0 = P_0.Remove(P_1, 11);
				if (!(P_3 is GameObject gameObject2))
				{
					__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				}
				else
				{
					P_0 = P_0.Insert(P_1, gameObject2.name);
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22686), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51733)))
		{
			P_0 = P_0.Remove(P_1, 9);
			if (!(P_3 is GameObject gameObject3))
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			}
			else
			{
				P_0 = P_0.Insert(P_1, gameObject3.UniqueIdentifier.ToString());
			}
			P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22709), 0, StringComparison.OrdinalIgnoreCase);
			return;
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51752)))
			{
				P_0 = P_0.Remove(P_1, 11);
				if (P_3 is Character character)
				{
					P_0 = P_0.Insert(P_1, character.Charname);
				}
				P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22663), 0, StringComparison.OrdinalIgnoreCase);
				return;
			}
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			return;
		}
		if (!P_2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51775)))
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			return;
		}
		P_0 = P_0.Remove(P_1, 6);
		string text = P_0.Substring(P_1).Trim();
		if (text.Length < 1)
		{
			__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
		}
		else
		{
			if (string.Compare(text[0].ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51788), ignoreCase: true) == 0)
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			}
			else if (string.Compare(text[0].ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51791), ignoreCase: true) == 0)
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			}
			else if (string.Compare(text[0].ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51794), ignoreCase: true) == 0)
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
			}
			else if (string.Compare(text[0].ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51797), ignoreCase: true) != 0 && string.Compare(text[0].ToString(), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51800), ignoreCase: true) != 0)
			{
				__ldtoken(Game.c7be5186c9678dd0117a87e6b9a29096d(ref string, int, string, ref object));
				P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51788));
				goto IL_0cb0;
			}
			P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51803));
		}
		goto IL_0cb0;
		IL_0cb0:
		P_1 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22650), 0, StringComparison.OrdinalIgnoreCase);
	}

	private void ce5427e7547e5b4dc50769dc8ffb3f644(ref string P_0, int P_1)
	{
		if (P_1 < 0)
		{
			return;
		}
		P_0 = P_0.Remove(P_1, 5);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.ce5427e7547e5b4dc50769dc8ffb3f644(ref string, int));
		}
		else
		{
			string varname = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			GameVariable variableByName = GetVariableByName(varname);
			if (variableByName != null)
			{
				string text = c7ee52cf6e2d0bf2a3ce55b4c09a672fd(ref variableByName);
				text = text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51808), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51811));
				text = text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51816));
				P_0 = P_0.Insert(P_1, text);
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51821), StringComparison.OrdinalIgnoreCase);
	}

	private void ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Room room = null;
			if (array.Length <= 1)
			{
				__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
			}
			else
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)) <= -1)
				{
					__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
					room = GetRoomByName(ref array[0]);
				}
				else
				{
					string g = array[0].Substring(0, array[0].IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)));
					room = GetRoomByID(new Guid(g));
				}
				if (room != null)
				{
					{
						IEnumerator enumerator = room.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
								CustomProperty customProperty = (CustomProperty)enumerator.Current;
								if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) != 0)
								{
									__ldtoken(Game.ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref string, int, string));
									continue;
								}
								P_0 = P_0.Insert(P_1, customProperty.Value);
								if (flag)
								{
									customProperty.Value = P_2;
								}
								break;
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51832), StringComparison.OrdinalIgnoreCase);
	}

	private void c1bc53a2f6561d073c9bb71f83d315a1c(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			GameObject gameObject = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)) <= -1)
				{
					__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
					gameObject = GetObjectByNameOld(array[0]);
				}
				else
				{
					string objectname = array[0].Substring(0, array[0].IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843)));
					gameObject = GetObjectByName(objectname);
				}
				if (gameObject == null)
				{
					__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
				}
				else
				{
					{
						IEnumerator enumerator = gameObject.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
								CustomProperty customProperty = (CustomProperty)enumerator.Current;
								if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
								{
									P_0 = P_0.Insert(P_1, customProperty.Value);
									if (!flag)
									{
										__ldtoken(Game.c1bc53a2f6561d073c9bb71f83d315a1c(ref string, int, string));
									}
									else
									{
										customProperty.Value = P_2;
									}
									break;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51841), StringComparison.OrdinalIgnoreCase);
	}

	private void c8fd9129f9a541a201b21c479bad52f6e(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
		}
		else
		{
			string strB = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			IEnumerator enumerator = ThePlayer.CustomProperties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
					CustomProperty customProperty = (CustomProperty)enumerator.Current;
					if (string.Compare(customProperty.Name, strB, ignoreCase: true) != 0)
					{
						__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
						continue;
					}
					P_0 = P_0.Insert(P_1, customProperty.Value);
					if (!flag)
					{
						__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
					}
					else
					{
						customProperty.Value = P_2;
					}
					break;
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Game.c8fd9129f9a541a201b21c479bad52f6e(ref string, int, string));
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51850), StringComparison.OrdinalIgnoreCase);
	}

	private void cfbab24a2237f785ec6b78f3fed73ae37(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Character character = null;
			if (array.Length <= 1)
			{
				__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
			}
			else
			{
				array[0] = array[0].Trim();
				character = GetCharacterByName(array[0]);
				if (character == null)
				{
					__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
				}
				else
				{
					{
						IEnumerator enumerator = character.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
								CustomProperty customProperty = (CustomProperty)enumerator.Current;
								if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) != 0)
								{
									__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
									continue;
								}
								P_0 = P_0.Insert(P_1, customProperty.Value);
								if (!flag)
								{
									__ldtoken(Game.cfbab24a2237f785ec6b78f3fed73ae37(ref string, int, string));
								}
								else
								{
									customProperty.Value = P_2;
								}
								break;
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51859), StringComparison.OrdinalIgnoreCase);
	}

	private void cc1f5ff23048a8c36936e8364a3aa679b(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (P_2 != "")
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			GameVariable gameVariable = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				gameVariable = GetVariableByName(array[0]);
				if (gameVariable == null)
				{
					__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
				}
				else
				{
					{
						IEnumerator enumerator = gameVariable.CustomProperties.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
								CustomProperty customProperty = (CustomProperty)enumerator.Current;
								if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) != 0)
								{
									__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
									continue;
								}
								P_0 = P_0.Insert(P_1, customProperty.Value);
								if (!flag)
								{
									__ldtoken(Game.cc1f5ff23048a8c36936e8364a3aa679b(ref string, int, string));
								}
								else
								{
									customProperty.Value = P_2;
								}
								break;
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51868), StringComparison.OrdinalIgnoreCase);
	}

	private void cb97307435acf495f4291c17b17754666(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer == null)
				{
					__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
				}
				else
				{
					IEnumerator enumerator = timer.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
							CustomProperty customProperty = (CustomProperty)enumerator.Current;
							if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) != 0)
							{
								__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
								continue;
							}
							P_0 = P_0.Insert(P_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = P_2;
							}
							break;
						}
					}
					finally
					{
						if (!(enumerator is IDisposable disposable))
						{
							__ldtoken(Game.cb97307435acf495f4291c17b17754666(ref string, int, string));
						}
						else
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51877), StringComparison.OrdinalIgnoreCase);
	}

	private void ce5e1dde0677f70dc4093b2b5287f4091(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer != null)
				{
					if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51886)))
					{
						__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
						if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51899)))
						{
							__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
							if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51908)))
							{
								__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
								if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51927)))
								{
									__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
									if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51940)))
									{
										__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
										if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51961)))
										{
											__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
											if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51986)))
											{
												__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
												if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52005)))
												{
													__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
												}
												else
												{
													Action tempact = timer.GetActionByName(array[2]);
													if (tempact != null)
													{
														P_0 = GetActionData(ref tempact, array[3], ref P_0, P_1, P_2);
													}
												}
											}
											else
											{
												P_0 = P_0.Insert(P_1, timer.LiveTimer.ToString());
												if (!flag)
												{
													__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
												}
												else
												{
													try
													{
														timer.LiveTimer = Convert.ToBoolean(P_2);
													}
													catch
													{
													}
												}
											}
										}
										else
										{
											P_0 = P_0.Insert(P_1, timer.TimerSeconds.ToString());
											if (flag)
											{
												try
												{
													timer.TimerSeconds = Convert.ToInt32(P_2);
												}
												catch
												{
												}
											}
										}
									}
									else
									{
										P_0 = P_0.Insert(P_1, timer.TurnNumber.ToString());
										if (flag)
										{
											try
											{
												timer.TurnNumber = Convert.ToInt32(P_2);
											}
											catch
											{
											}
										}
									}
								}
								else
								{
									P_0 = P_0.Insert(P_1, timer.Length.ToString());
									if (flag)
									{
										try
										{
											timer.Length = Convert.ToInt32(P_2);
										}
										catch
										{
										}
									}
								}
							}
							else
							{
								P_0 = P_0.Insert(P_1, timer.TType.ToString());
								if (!flag)
								{
									__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
								}
								else
								{
									try
									{
										timer.TType = (Timer.TimerType)Enum.Parse(typeof(Timer.TimerType), P_2);
									}
									catch
									{
									}
								}
							}
						}
						else
						{
							P_0 = P_0.Insert(P_1, timer.Name.ToString());
							if (!flag)
							{
								__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
							}
							else
							{
								timer.Name = P_2;
							}
						}
					}
					else
					{
						P_0 = P_0.Insert(P_1, timer.Active.ToString());
						if (!flag)
						{
							__ldtoken(Game.ce5e1dde0677f70dc4093b2b5287f4091(ref string, int, string));
						}
						else
						{
							try
							{
								timer.Active = Convert.ToBoolean(P_2);
							}
							catch
							{
							}
						}
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52018), StringComparison.OrdinalIgnoreCase);
	}

	private void c80ccd1e4cd609411c230bf09afdc6a23(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Room room = null;
			if (array.Length <= 1)
			{
				__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
			}
			else
			{
				array[0] = array[0].Trim();
				try
				{
					room = GetRoomByID(new Guid(array[0]));
				}
				catch
				{
					room = null;
				}
				if (room != null)
				{
					__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
				}
				else
				{
					room = GetRoomByName(ref array[0]);
				}
				if (room == null)
				{
					__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
				}
				else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51899)))
				{
					__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
					if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52027))
					{
						P_0 = P_0.Insert(P_1, room.Description.ToString());
						if (!flag)
						{
							__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
						}
						else
						{
							room.Description = P_2;
						}
					}
					else if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52050))
					{
						P_0 = P_0.Insert(P_1, room.SDesc.ToString());
						if (!flag)
						{
							__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
						}
						else
						{
							room.SDesc = P_2;
						}
					}
					else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52061)))
					{
						__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
						if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52076)))
						{
							__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
							if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52109)))
							{
								__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
								if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1271))
								{
									P_0 = P_0.Insert(P_1, room.UniqueID.ToString());
								}
								else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52005)))
								{
									__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
									if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52136)))
									{
										__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
									}
									else
									{
										Exit exit = null;
										try
										{
											exit = room.GetExit((Exit.Directions)Enum.Parse(typeof(Exit.Directions), array[2]));
										}
										catch
										{
											exit = null;
										}
										if (exit == null)
										{
											__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
										}
										else if (!(array[3].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51886)))
										{
											__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
											if (!(array[3].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52145)))
											{
												__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
												if (!(array[3].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52172)))
												{
													__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
													if (!(array[3].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52203)))
													{
														__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
													}
													else
													{
														P_0 = P_0.Insert(P_1, exit.PortalObjectName.ToString());
														if (!flag)
														{
															__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
														}
														else
														{
															exit.PortalObjectName = P_2;
														}
													}
												}
												else
												{
													try
													{
														P_0 = P_0.Insert(P_1, GetRoomByID(new Guid(exit.DestinationRoom)).Name);
													}
													catch
													{
														P_0 = P_0.Insert(P_1, exit.DestinationRoom.ToString());
													}
													if (flag)
													{
														try
														{
															exit.DestinationRoom = GetRoomByName(ref P_2).UniqueID.ToString();
														}
														catch
														{
														}
													}
												}
											}
											else
											{
												P_0 = P_0.Insert(P_1, exit.DestinationRoom.ToString());
												if (!flag)
												{
													__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
												}
												else
												{
													exit.DestinationRoom = P_2;
												}
											}
										}
										else
										{
											P_0 = P_0.Insert(P_1, exit.bActive.ToString());
											if (!flag)
											{
												__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
											}
											else
											{
												try
												{
													exit.bActive = Convert.ToBoolean(P_2);
												}
												catch
												{
												}
											}
										}
									}
								}
								else
								{
									Action tempact = room.GetActionByName(array[2]);
									if (tempact == null)
									{
										__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
									}
									else
									{
										P_0 = GetActionData(ref tempact, array[3], ref P_0, P_1, P_2);
									}
								}
							}
							else
							{
								P_0 = P_0.Insert(P_1, room.bLeaveFirstTime.ToString());
								if (!flag)
								{
									__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
								}
								else
								{
									try
									{
										room.bLeaveFirstTime = Convert.ToBoolean(P_2);
									}
									catch
									{
									}
								}
							}
						}
						else
						{
							P_0 = P_0.Insert(P_1, room.bEnterFirstTime.ToString());
							if (!flag)
							{
								__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
							}
							else
							{
								try
								{
									room.bEnterFirstTime = Convert.ToBoolean(P_2);
								}
								catch
								{
								}
							}
						}
					}
					else
					{
						P_0 = P_0.Insert(P_1, room.RoomPic.ToString());
						if (!flag)
						{
							__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
						}
						else
						{
							room.RoomPic = P_2;
						}
					}
				}
				else
				{
					P_0 = P_0.Insert(P_1, room.Name.ToString());
					if (!flag)
					{
						__ldtoken(Game.c80ccd1e4cd609411c230bf09afdc6a23(ref string, int, string));
					}
					else
					{
						room.Name = P_2;
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52216), StringComparison.OrdinalIgnoreCase);
	}

	private void c29abcf80927b3d196e06b94570def476(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			GameObject gameObject = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				try
				{
					gameObject = GetObjectByName(array[0]);
				}
				catch
				{
					gameObject = null;
				}
				if (gameObject != null)
				{
					__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
				}
				else
				{
					gameObject = GetObjectByNameOld(array[0]);
				}
				if (gameObject == null)
				{
					__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
				}
				else if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51899))
				{
					P_0 = P_0.Insert(P_1, gameObject.name.ToString());
					if (!flag)
					{
						__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
					}
					else
					{
						gameObject.name = P_2;
					}
				}
				else if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52225))
				{
					P_0 = P_0.Insert(P_1, gameObject.sdesc.ToString());
					if (flag)
					{
						gameObject.sdesc = P_2;
					}
				}
				else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52250)))
				{
					__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
					if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1271)))
					{
						__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
						if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52279)))
						{
							__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
							if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52027)))
							{
								__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
								if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52302)))
								{
									__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
									if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52321)))
									{
										__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
										if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52340))
										{
											P_0 = P_0.Insert(P_1, gameObject.bWearable.ToString());
											if (!flag)
											{
												__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
											}
											else
											{
												try
												{
													gameObject.bWearable = Convert.ToBoolean(P_2);
												}
												catch
												{
												}
											}
										}
										else if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52357))
										{
											P_0 = P_0.Insert(P_1, gameObject.bWorn.ToString());
											if (!flag)
											{
												__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
											}
											else
											{
												try
												{
													gameObject.bWorn = Convert.ToBoolean(P_2);
												}
												catch
												{
												}
											}
										}
										else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52366)))
										{
											__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
											if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52385)))
											{
												__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
												if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52402)))
												{
													__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
													if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52411)))
													{
														__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
														if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52428)))
														{
															__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
															if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52441))
															{
																P_0 = P_0.Insert(P_1, gameObject.bVisible.ToString());
																if (!flag)
																{
																	__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																}
																else
																{
																	try
																	{
																		gameObject.bVisible = Convert.ToBoolean(P_2);
																	}
																	catch
																	{
																	}
																}
															}
															else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52456)))
															{
																__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52475)))
																{
																	__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																	if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52492)))
																	{
																		__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																		if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52005)))
																		{
																			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																		}
																		else
																		{
																			Action tempact = gameObject.GetActionByName(array[2]);
																			if (tempact == null)
																			{
																				__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																			}
																			else
																			{
																				P_0 = GetActionData(ref tempact, array[3], ref P_0, P_1, P_2);
																			}
																		}
																	}
																	else
																	{
																		P_0 = P_0.Insert(P_1, gameObject.dWeight.ToString());
																		if (!flag)
																		{
																			__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																		}
																		else
																		{
																			try
																			{
																				gameObject.dWeight = Convert.ToDouble(P_2);
																			}
																			catch
																			{
																			}
																		}
																	}
																}
																else
																{
																	P_0 = P_0.Insert(P_1, gameObject.bReadable.ToString());
																	if (!flag)
																	{
																		__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
																	}
																	else
																	{
																		try
																		{
																			gameObject.bReadable = Convert.ToBoolean(P_2);
																		}
																		catch
																		{
																		}
																	}
																}
															}
															else
															{
																P_0 = P_0.Insert(P_1, gameObject.bEnterable.ToString());
																if (flag)
																{
																	try
																	{
																		gameObject.bEnterable = Convert.ToBoolean(P_2);
																	}
																	catch
																	{
																	}
																}
															}
														}
														else
														{
															P_0 = P_0.Insert(P_1, gameObject.bLocked.ToString());
															if (!flag)
															{
																__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
															}
															else
															{
																try
																{
																	gameObject.bLocked = Convert.ToBoolean(P_2);
																}
																catch
																{
																}
															}
														}
													}
													else
													{
														P_0 = P_0.Insert(P_1, gameObject.bLockable.ToString());
														if (!flag)
														{
															__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
														}
														else
														{
															try
															{
																gameObject.bLockable = Convert.ToBoolean(P_2);
															}
															catch
															{
															}
														}
													}
												}
												else
												{
													P_0 = P_0.Insert(P_1, gameObject.bOpen.ToString());
													if (flag)
													{
														try
														{
															gameObject.bOpen = Convert.ToBoolean(P_2);
														}
														catch
														{
														}
													}
												}
											}
											else
											{
												P_0 = P_0.Insert(P_1, gameObject.bOpenable.ToString());
												if (flag)
												{
													try
													{
														gameObject.bOpenable = Convert.ToBoolean(P_2);
													}
													catch
													{
													}
												}
											}
										}
										else
										{
											P_0 = P_0.Insert(P_1, gameObject.bContainer.ToString());
											if (flag)
											{
												try
												{
													gameObject.bContainer = Convert.ToBoolean(P_2);
												}
												catch
												{
												}
											}
										}
									}
									else
									{
										P_0 = P_0.Insert(P_1, gameObject.bCarryable.ToString());
										if (!flag)
										{
											__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
										}
										else
										{
											try
											{
												gameObject.bCarryable = Convert.ToBoolean(P_2);
											}
											catch
											{
											}
										}
									}
								}
								else
								{
									P_0 = P_0.Insert(P_1, gameObject.bImportant.ToString());
									if (!flag)
									{
										__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
									}
									else
									{
										try
										{
											gameObject.bImportant = Convert.ToBoolean(P_2);
										}
										catch
										{
										}
									}
								}
							}
							else
							{
								P_0 = P_0.Insert(P_1, gameObject.description.ToString());
								if (!flag)
								{
									__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
								}
								else
								{
									gameObject.description = P_2;
								}
							}
						}
						else
						{
							P_0 = P_0.Insert(P_1, gameObject.preposition.ToString());
							if (flag)
							{
								gameObject.preposition = P_2;
							}
						}
					}
					else
					{
						P_0 = P_0.Insert(P_1, gameObject.UniqueIdentifier.ToString());
					}
				}
				else
				{
					string text2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
					int num2 = 0;
					IEnumerator enumerator = gameObject.LayeredZoneLevels.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
							string text3 = (string)enumerator.Current;
							if (num2 > 0)
							{
								text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
							}
							num2++;
							text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
							string[] array2 = text3.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
							if (array2.Length <= 0)
							{
								__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
							}
							else
							{
								for (int i = 0; i < array2.Length; i++)
								{
									__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
									if (i > 0)
									{
										text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
									}
									text2 = text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + array2[i] + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011);
								}
							}
							text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
						}
					}
					finally
					{
						if (!(enumerator is IDisposable disposable))
						{
							__ldtoken(Game.c29abcf80927b3d196e06b94570def476(ref string, int, string));
						}
						else
						{
							disposable.Dispose();
						}
					}
					text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
					P_0 = P_0.Insert(P_1, text2);
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52505), StringComparison.OrdinalIgnoreCase);
	}

	private void c3e667d3bf1ee7123c5666850b87add86(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (!(P_2 != ""))
		{
			__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528))
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			Character character = null;
			if (array.Length <= 1)
			{
				__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
			}
			else
			{
				array[0] = array[0].Trim();
				try
				{
					character = GetCharacterByName(array[0]);
				}
				catch
				{
					character = null;
				}
				if (character == null)
				{
					__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
				}
				else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51899)))
				{
					__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
					if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52514)))
					{
						__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
						if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52539))
						{
							P_0 = P_0.Insert(P_1, character.CharGender.ToString());
							if (!flag)
							{
								__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
							}
							else
							{
								try
								{
									character.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), P_2);
								}
								catch
								{
								}
							}
						}
						else if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52552))
						{
							P_0 = P_0.Insert(P_1, character.CurrentRoom.ToString());
							if (!flag)
							{
								__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
							}
							else
							{
								character.CurrentRoom = P_2;
							}
						}
						else if (!(array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52575)))
						{
							__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
							if (array[1].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52005))
							{
								Action tempact = character.GetActionByName(array[2]);
								if (tempact == null)
								{
									__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
								}
								else
								{
									P_0 = GetActionData(ref tempact, array[3], ref P_0, P_1, P_2);
								}
							}
						}
						else
						{
							P_0 = P_0.Insert(P_1, character.bAllowInventoryInteraction.ToString());
							if (!flag)
							{
								__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
							}
							else
							{
								try
								{
									character.bAllowInventoryInteraction = Convert.ToBoolean(P_2);
								}
								catch
								{
								}
							}
						}
					}
					else
					{
						P_0 = P_0.Insert(P_1, character.CharnameOverride.ToString());
						if (flag)
						{
							character.CharnameOverride = P_2;
						}
					}
				}
				else
				{
					P_0 = P_0.Insert(P_1, character.Charname.ToString());
					if (!flag)
					{
						__ldtoken(Game.c3e667d3bf1ee7123c5666850b87add86(ref string, int, string));
					}
					else
					{
						character.Charname = P_2;
					}
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52614), StringComparison.OrdinalIgnoreCase);
	}

	private void cba569d4831b8a4781f3dfa9a2775dd0c(ref string P_0, int P_1, string P_2 = "")
	{
		bool flag = false;
		if (P_2 != "")
		{
			flag = true;
		}
		if (!(P_2 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528)))
		{
			__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
		}
		else
		{
			P_2 = "";
		}
		if (P_1 < 0)
		{
			__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
			return;
		}
		P_0 = P_0.Remove(P_1, 4);
		int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), P_1, StringComparison.OrdinalIgnoreCase);
		if (num <= -1)
		{
			__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
		}
		else
		{
			string text = P_0.Substring(P_1, num - P_1).Trim();
			P_0 = P_0.Remove(P_1, num - P_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) }, StringSplitOptions.None);
			if (array.Length < 1)
			{
				__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
			}
			else if (ThePlayer == null)
			{
				__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
			}
			else if (!(array[0].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51899)))
			{
				__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
				if (!(array[0].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52539)))
				{
					__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
					if (array[0].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52623))
					{
						if (ThePlayer.CurrentRoom == null)
						{
							__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
							P_0 = P_0.Insert(P_1, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52638));
						}
						else
						{
							P_0 = P_0.Insert(P_1, ThePlayer.CurrentRoom.ToString());
						}
						if (!flag)
						{
							__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
						}
						else
						{
							try
							{
								ThePlayer.CurrentRoom = GetRoomByName(ref P_2);
							}
							catch
							{
							}
						}
					}
					else if (!(array[0].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52651)))
					{
						__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
						if (!(array[0].ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52005)))
						{
							__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
						}
						else
						{
							Action tempact = ThePlayer.GetActionByName(array[1]);
							if (tempact != null)
							{
								P_0 = GetActionData(ref tempact, array[2], ref P_0, P_1, P_2);
							}
						}
					}
					else
					{
						P_0 = P_0.Insert(P_1, ThePlayer.PlayerPortrait.ToString());
						if (!flag)
						{
							__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
						}
						else
						{
							ThePlayer.PlayerPortrait = P_2;
						}
					}
				}
				else
				{
					P_0 = P_0.Insert(P_1, ThePlayer.PlayerGender.ToString());
					if (!flag)
					{
						__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
					}
					else
					{
						try
						{
							ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), P_2);
						}
						catch
						{
						}
					}
				}
			}
			else
			{
				P_0 = P_0.Insert(P_1, ThePlayer.Name.ToString());
				if (!flag)
				{
					__ldtoken(Game.cba569d4831b8a4781f3dfa9a2775dd0c(ref string, int, string));
				}
				else
				{
					ThePlayer.Name = P_2;
				}
			}
		}
		P_1 = P_0.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52674), StringComparison.OrdinalIgnoreCase);
	}

	public string GetActionData(ref Action tempact, string part3, ref string text, int tempindex, string replacementvalue = "")
	{
		bool flag = false;
		if (!(replacementvalue != ""))
		{
			__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
		}
		else
		{
			flag = true;
		}
		if (!(part3.ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51886)))
		{
			__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
			if (!(part3.ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52514)))
			{
				__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
				if (!(part3.ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52683)))
				{
					__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
					if (!(part3.ToUpper() == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52708)))
					{
						__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
					}
					else
					{
						text = text.Insert(tempindex, tempact.InputType.ToString());
						if (!flag)
						{
							__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
						}
						else
						{
							try
							{
								tempact.InputType = (Action.ActionInputType)Enum.Parse(typeof(Action.ActionInputType), replacementvalue);
							}
							catch
							{
							}
						}
					}
				}
				else
				{
					text = text.Insert(tempindex, tempact.actionparent.ToString());
					if (!flag)
					{
						__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
					}
					else
					{
						tempact.actionparent = replacementvalue;
					}
				}
			}
			else
			{
				text = text.Insert(tempindex, tempact.overridename.ToString());
				if (!flag)
				{
					__ldtoken(Game.GetActionData(ref Action, string, ref string, int, string));
				}
				else
				{
					tempact.overridename = replacementvalue;
				}
			}
		}
		else
		{
			text = text.Insert(tempindex, tempact.bActive.ToString());
			if (flag)
			{
				try
				{
					tempact.bActive = Convert.ToBoolean(replacementvalue);
				}
				catch
				{
				}
			}
		}
		return text;
	}

	public string PerformTextReplacements(string text, object loopobject, string newvalue = "")
	{
		bool flag = true;
		while (flag)
		{
			__ldtoken(Game.PerformTextReplacements(string, object, string));
			flag = false;
			int num = text.Length;
			int num2 = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), num, StringComparison.OrdinalIgnoreCase);
			List<int> list = new List<int>();
			while (num2 >= 0)
			{
				int num3 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num2);
				if (num3 != -1)
				{
					string text2 = text.Substring(num2, num3 - num2 + 1).ToUpper();
					int num4 = text2.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929), 0);
					if (num4 != -1)
					{
						flag = true;
						string text3 = text2.Substring(0, num4 + 1).ToUpper();
						if (text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52727))
						{
							caac7109a78be18e2077a824724a7d693(ref text, num2, newvalue);
						}
						else if (text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52734))
						{
							ce5427e7547e5b4dc50769dc8ffb3f644(ref text, num2);
						}
						else if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52745)))
						{
							__ldtoken(Game.PerformTextReplacements(string, object, string));
							if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52754)))
							{
								__ldtoken(Game.PerformTextReplacements(string, object, string));
								if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52763)))
								{
									__ldtoken(Game.PerformTextReplacements(string, object, string));
									if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52772)))
									{
										__ldtoken(Game.PerformTextReplacements(string, object, string));
										if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52781)))
										{
											__ldtoken(Game.PerformTextReplacements(string, object, string));
											if (text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52790))
											{
												cb97307435acf495f4291c17b17754666(ref text, num2, newvalue);
											}
											else if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52799)))
											{
												__ldtoken(Game.PerformTextReplacements(string, object, string));
												if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52808)))
												{
													__ldtoken(Game.PerformTextReplacements(string, object, string));
													if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52817)))
													{
														__ldtoken(Game.PerformTextReplacements(string, object, string));
														if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52826)))
														{
															__ldtoken(Game.PerformTextReplacements(string, object, string));
															if (!(text3 == cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52835)))
															{
																__ldtoken(Game.PerformTextReplacements(string, object, string));
																flag = false;
															}
															else
															{
																cba569d4831b8a4781f3dfa9a2775dd0c(ref text, num2, newvalue);
															}
														}
														else
														{
															c80ccd1e4cd609411c230bf09afdc6a23(ref text, num2, newvalue);
														}
													}
													else
													{
														c3e667d3bf1ee7123c5666850b87add86(ref text, num2, newvalue);
													}
												}
												else
												{
													ce5e1dde0677f70dc4093b2b5287f4091(ref text, num2, newvalue);
												}
											}
											else
											{
												c29abcf80927b3d196e06b94570def476(ref text, num2, newvalue);
											}
										}
										else
										{
											cc1f5ff23048a8c36936e8364a3aa679b(ref text, num2, newvalue);
										}
									}
									else
									{
										cfbab24a2237f785ec6b78f3fed73ae37(ref text, num2, newvalue);
									}
								}
								else
								{
									c8fd9129f9a541a201b21c479bad52f6e(ref text, num2, newvalue);
								}
							}
							else
							{
								c1bc53a2f6561d073c9bb71f83d315a1c(ref text, num2, newvalue);
							}
						}
						else
						{
							ca59fcd5b9259a64c02c1a7a3b0a6ccd0(ref text, num2, newvalue);
						}
					}
					else
					{
						if (text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22414)))
						{
							__ldtoken(Game.PerformTextReplacements(string, object, string));
						}
						else if (!text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52844)))
						{
							if (text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52853)))
							{
								__ldtoken(Game.PerformTextReplacements(string, object, string));
							}
							else if (!text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52862)) && !text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52871)))
							{
								if (text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52880)))
								{
									__ldtoken(Game.PerformTextReplacements(string, object, string));
								}
								else if (text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22407)))
								{
									__ldtoken(Game.PerformTextReplacements(string, object, string));
								}
								else if (!text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52899)) && !text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52906)))
								{
									if (text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52913)))
									{
										__ldtoken(Game.PerformTextReplacements(string, object, string));
									}
									else if (!text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52920)) && !text2.Contains(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52927)))
									{
										__ldtoken(Game.PerformTextReplacements(string, object, string));
										c7be5186c9678dd0117a87e6b9a29096d(ref text, num2, text2, ref loopobject);
										goto IL_045d;
									}
								}
							}
						}
						num = num2 - 1;
					}
				}
				goto IL_045d;
				IL_045d:
				if (num <= text.Length)
				{
					__ldtoken(Game.PerformTextReplacements(string, object, string));
					if (num != -1)
					{
						__ldtoken(Game.PerformTextReplacements(string, object, string));
						if (num2 != 0)
						{
							__ldtoken(Game.PerformTextReplacements(string, object, string));
							list.Add(num2);
							num2 = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), num2 - 1, StringComparison.OrdinalIgnoreCase);
							if (!list.Contains(num2))
							{
								__ldtoken(Game.PerformTextReplacements(string, object, string));
							}
							else
							{
								num2 = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), num2 - 1, StringComparison.OrdinalIgnoreCase);
							}
						}
						else
						{
							num2 = -1;
						}
					}
					else
					{
						num2 = -1;
					}
				}
				else if (num2 != 0)
				{
					__ldtoken(Game.PerformTextReplacements(string, object, string));
					list.Add(num2);
					num2 = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), num2 - 1, StringComparison.OrdinalIgnoreCase);
					if (!list.Contains(num2))
					{
						__ldtoken(Game.PerformTextReplacements(string, object, string));
					}
					else
					{
						num2 = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926), num2 - 1, StringComparison.OrdinalIgnoreCase);
					}
				}
				else
				{
					num2 = -1;
				}
			}
		}
		return text;
	}

	public void AssignHotKey(int index, object data)
	{
		if (HotKeys != null)
		{
			__ldtoken(Game.AssignHotKey(int, object));
		}
		else
		{
			HotKeys = new ArrayList();
		}
		if (HotKeys.Count == 10)
		{
			__ldtoken(Game.AssignHotKey(int, object));
		}
		else
		{
			HotKeys.Clear();
			for (int i = 0; i < 10; i++)
			{
				__ldtoken(Game.AssignHotKey(int, object));
				HotKeys.Add(null);
			}
		}
		HotKeys[index] = data;
	}

	public bool SetClipboardData(int index)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		bool result = false;
		if (HotKeys.Count == 10)
		{
			__ldtoken(Game.SetClipboardData(int));
			object obj = HotKeys[index];
			Command command = obj as Command;
			Condition condition = obj as Condition;
			Action action = obj as Action;
			if (command != null)
			{
				Clipboard.SetDataObject((object)new DataObject(ActionControl.CommandFormat.Name, (object)command));
				result = true;
			}
			else if (condition != null)
			{
				Clipboard.SetDataObject((object)new DataObject(ActionControl.ConditonFormat.Name, (object)condition));
				result = true;
			}
			else if (action == null)
			{
				__ldtoken(Game.SetClipboardData(int));
			}
			else
			{
				Clipboard.SetDataObject((object)new DataObject(ActionControl.ActionFormat.Name, (object)action));
				result = true;
			}
			return result;
		}
		return false;
	}

	public static void RestoreDefaults(ref ArrayList QuickCommands)
	{
		QuickCommands.Clear();
		QuickMenuItem quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		quickMenuItem.bCharacters = true;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		Action action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		action.bActive = true;
		Command command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10964);
		command.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52944);
		command.cmdtype = Command.CommandType.CT_CHAR_DISPLAYPORT;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10999);
		command.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = true;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11034);
		command.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = true;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(10949);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11087);
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11122);
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bOpenable = true;
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11155);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11391);
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(52981);
		action.PassCommands.Add(command);
		Condition condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11489));
		action.Conditions.Add(condition);
		Check check = condition.Checks[0] as Check;
		check.CondType = Condition.ConditionType.CT_Item_State_Check;
		check.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11518);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53020);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11594);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11605);
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3300);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53067);
		action.PassCommands.Add(command);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11673));
		action.Conditions.Add(condition);
		check = condition.Checks[0] as Check;
		check.CondType = Condition.ConditionType.CT_Item_State_Check;
		check.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11706);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53110);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bWearable = true;
		quickMenuItem.bCarryable = true;
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11823);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12124);
		action.bActive = true;
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12365));
		action.Conditions.Add(condition);
		Check check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12416);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53161);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12133);
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53214));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12166);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12193);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12220);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12245);
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12526);
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12539);
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12727));
		action.Conditions.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12782);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53251);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53306));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12578);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12601);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12653);
		condition.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bLockable = true;
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12856);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13094);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13103);
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53349);
		action.PassCommands.Add(command);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13171));
		action.Conditions.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13204);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53392);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13288);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13301);
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3313);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53443);
		action.PassCommands.Add(command);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13377));
		action.Conditions.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13414);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53490);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13506);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13746);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13755);
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53545);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13813);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13836);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13859);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13884);
		action.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13911);
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13920);
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53584);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53657);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13972);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13995);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14018);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14043);
		action.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		quickMenuItem.bWearable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53696);
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13746);
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13755);
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53545);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13813);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13836);
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13859);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13884);
		action.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13911);
		action.bActive = false;
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53739));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12539);
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		Condition condition2 = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53766));
		condition.PassCommands.Add(condition2);
		check2 = condition2.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12578);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12601);
		condition2.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12653);
		condition2.PassCommands.Add(command);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53827));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13920);
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53584);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13972);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13995);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14018);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(14043);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(11424);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53657);
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12124);
		action.bActive = true;
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53860));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12416);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53545);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		condition.FailCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13755);
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13813);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13836);
		condition.FailCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13859);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(13884);
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12133);
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53903));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12166);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12193);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12220);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12245);
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12526);
		action.bActive = false;
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12727));
		action.Conditions.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406);
		command = new Command();
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12782);
		command.CommandText = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53251);
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12539);
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		condition = new Condition(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53306));
		action.PassCommands.Add(condition);
		check2 = condition.Checks[0] as Check;
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		check2.ConditionStep3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3330);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12578);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12601);
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12624);
		command.CommandPart2 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7289);
		command.CommandPart3 = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12653);
		condition.PassCommands.Add(command);
	}

	public double GetItemWeight(Guid objid)
	{
		double num = 0.0;
		GameObject objectByName = GetObjectByName(objid.ToString());
		if (objectByName == null)
		{
			__ldtoken(Game.GetItemWeight(Guid));
		}
		else
		{
			num += objectByName.dWeight;
			if (!objectByName.bContainer)
			{
				__ldtoken(Game.GetItemWeight(Guid));
			}
			else
			{
				IEnumerator enumerator = ObjectList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Game.GetItemWeight(Guid));
						GameObject gameObject = (GameObject)enumerator.Current;
						if (gameObject.locationtype != GameObject.LocationType.LT_IN_OBJECT)
						{
							__ldtoken(Game.GetItemWeight(Guid));
						}
						else if (!(gameObject.locationname == objectByName.UniqueIdentifier.ToString()))
						{
							__ldtoken(Game.GetItemWeight(Guid));
						}
						else
						{
							num += GetItemWeight(gameObject.UniqueIdentifier);
						}
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(Game.GetItemWeight(Guid));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		return num;
	}

	public void ValidateText(string text)
	{
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		string text2 = string.Empty;
		text = PerformTextReplacements(text, null);
		bool flag = false;
		text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53946), StringComparison.OrdinalIgnoreCase);
		for (int num = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53951), StringComparison.OrdinalIgnoreCase); num >= 0; num = text.LastIndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53951), StringComparison.OrdinalIgnoreCase))
		{
			text = text.Remove(num, 3);
			int num2 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num, StringComparison.OrdinalIgnoreCase);
			int num3 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843), num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= num2)
			{
				__ldtoken(Game.ValidateText(string));
			}
			else if (num3 != -1)
			{
				int num4 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857), num, StringComparison.OrdinalIgnoreCase);
				if (num4 == -1)
				{
					__ldtoken(Game.ValidateText(string));
					continue;
				}
				string text3 = text.Substring(num, num3 - num).Trim();
				if (num4 - (num3 + 1) >= 0)
				{
					__ldtoken(Game.ValidateText(string));
					string text4 = text.Substring(num3 + 1, num4 - (num3 + 1)).Trim();
					int num5 = 0;
					try
					{
						num5 = Convert.ToInt32(text4);
					}
					catch
					{
						text2 = text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54051) + text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
						flag = true;
						num5 = -1;
					}
					int num6 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7857), num4 + 1, StringComparison.OrdinalIgnoreCase);
					int num7 = -1;
					if (num6 == -1)
					{
						__ldtoken(Game.ValidateText(string));
					}
					else
					{
						string text5 = string.Empty;
						try
						{
							text5 = text.Substring(num4 + 2, num6 - (num4 + 2));
							num7 = Convert.ToInt32(text5);
						}
						catch
						{
							text2 = text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54160) + text5 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
							flag = true;
							num5 = -1;
						}
					}
					if (num5 <= -1)
					{
						__ldtoken(Game.ValidateText(string));
						continue;
					}
					string text6 = string.Empty;
					if (text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) <= -1)
					{
						__ldtoken(Game.ValidateText(string));
					}
					else
					{
						text6 = text3.Substring(text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) + 1);
						text3 = text3.Substring(0, text3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)));
					}
					GameVariable variableByName = GetVariableByName(text3);
					if (variableByName != null)
					{
						__ldtoken(Game.ValidateText(string));
					}
					else
					{
						text2 = text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54332) + text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54371);
						flag = true;
					}
					if (variableByName == null)
					{
						__ldtoken(Game.ValidateText(string));
						continue;
					}
					int num8 = 0;
					if (num6 <= -1)
					{
						__ldtoken(Game.ValidateText(string));
						num8 = num4 - num + 2;
					}
					else
					{
						num8 = num6 - num + 2;
					}
					text = text.Remove(num, num8);
					if (num5 >= variableByName.VarArray.Count)
					{
						string text7 = text2;
						text2 = text7 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54416) + num5 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54455) + variableByName.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(12313);
						flag = true;
					}
					if (num5 >= variableByName.VarArray.Count)
					{
						__ldtoken(Game.ValidateText(string));
						continue;
					}
					string value = string.Empty;
					switch (variableByName.vartype)
					{
					case GameVariable.VarType.VT_NUMBERARRAY:
					case GameVariable.VarType.VT_STRINGARRAY:
						if (num7 <= -1)
						{
							__ldtoken(Game.ValidateText(string));
							value = variableByName.VarArray[num5].ToString();
							break;
						}
						try
						{
							value = ((ArrayList)variableByName.VarArray[num5])[num7].ToString();
						}
						catch
						{
							value = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51040);
						}
						break;
					case GameVariable.VarType.VT_DATETIMEARRAY:
					{
						if (num7 <= -1)
						{
							__ldtoken(Game.ValidateText(string));
							if (!(text6 != string.Empty))
							{
								__ldtoken(Game.ValidateText(string));
								value = ((DateTime)variableByName.VarArray[num5]).ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI);
							}
							else
							{
								value = ((DateTime)variableByName.VarArray[num5]).ToString(text6, myDTFI);
							}
							break;
						}
						string value2 = ((ArrayList)variableByName.VarArray[num5])[num7].ToString();
						DateTime dateTime = Convert.ToDateTime(value2);
						if (!(text6 != string.Empty))
						{
							__ldtoken(Game.ValidateText(string));
							value = dateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI);
						}
						else
						{
							value = dateTime.ToString(text6, myDTFI);
						}
						break;
					}
					}
					text = text.Insert(num, value);
					continue;
				}
				text2 += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53958);
				flag = true;
				break;
			}
			if (num2 <= -1)
			{
				__ldtoken(Game.ValidateText(string));
				continue;
			}
			string text8 = text.Substring(num, num2 - num).Trim();
			text = text.Remove(num, num2 - num + 1);
			string text9 = string.Empty;
			if (text8.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) > -1)
			{
				text9 = text8.Substring(text8.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)) + 1);
				text8 = text8.Substring(0, text8.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929)));
			}
			GameVariable variableByName2 = GetVariableByName(text8);
			if (variableByName2 != null)
			{
				__ldtoken(Game.ValidateText(string));
			}
			else
			{
				text2 = text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54332) + text8 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54371);
				flag = true;
			}
			if (variableByName2 == null)
			{
				__ldtoken(Game.ValidateText(string));
				continue;
			}
			string value3 = string.Empty;
			switch (variableByName2.vartype)
			{
			case GameVariable.VarType.VT_NUMBER:
				value3 = variableByName2.dNumType.ToString();
				break;
			case GameVariable.VarType.VT_STRING:
				value3 = variableByName2.sString;
				break;
			case GameVariable.VarType.VT_DATETIME:
				if (!(text9 != string.Empty))
				{
					__ldtoken(Game.ValidateText(string));
					value3 = variableByName2.dtDateTime.ToString(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51097), myDTFI);
				}
				else
				{
					value3 = variableByName2.dtDateTime.ToString(text9, myDTFI);
				}
				break;
			}
			text = text.Insert(num, value3);
		}
		if (!flag)
		{
			__ldtoken(Game.ValidateText(string));
		}
		else
		{
			MessageBox.Show(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54524) + text2, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(54579));
		}
	}
}
