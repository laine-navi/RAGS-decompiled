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

namespace Rags;

[Serializable]
public class Game : ISerializable
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

	public Font GameFont = new Font("Microsoft Sans Serif", 8.25f);

	public static DateTimeFormatInfo myDTFI = new CultureInfo("en-US", useUserOverride: false).DateTimeFormat;

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

	public string GameVersion = "1.0";

	public string GameInformation = string.Empty;

	private Timer checktimer = new Timer();

	public ArrayList QuickCommands = new ArrayList();

	private ArrayList HotKeys = new ArrayList();

	public static string DBName = string.Empty;

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetWindowsDirectoryA")]
	private static extern int GetWindowsDirectory(StringBuilder A_0, int A_1);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentDirectoryA")]
	private static extern int GetCurrentDirectory(int A_0, StringBuilder A_1);

	public Game()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		a();
		LayeredClothingZones.Add("Upper Body");
		LayeredClothingZones.Add("Mid Body");
		LayeredClothingZones.Add("Lower Body");
	}

	public Game(string dbname)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		a();
		LayeredClothingZones.Add("Upper Body");
		LayeredClothingZones.Add("Mid Body");
		LayeredClothingZones.Add("Lower Body");
		DBName = dbname;
		tempwaitdlg = new WaitDlg();
		((Control)tempwaitdlg.label1).Text = "Loading data...";
		try
		{
			Cursor.Current = Cursors.WaitCursor;
			bDoneWithWaitDlg = false;
			((Control)tempwaitdlg).Show();
			ThreadPool.QueueUserWorkItem(ThrdLoadData, this);
			checktimer.Interval = 500;
			checktimer.Tick += a;
			checktimer.Start();
		}
		finally
		{
		}
	}

	public static SqlCeConnection GetDBConnection()
	{
		if (DBName == string.Empty)
		{
			return null;
		}
		try
		{
			EncDec.RagsZone("F1$asDDFHappy");
			string connectionString = "DataSource=" + DBName + ";Max Database Size=4024;Password=" + EncDec.RagsZone("F1$asDDFHappy");
			if (TheCon != null && DBName != TheCon.DataSource)
			{
				TheCon.Close();
			}
			if (TheCon == null || TheCon.State == ConnectionState.Closed)
			{
				TheCon = new SqlCeConnection(connectionString);
				TheCon.Open();
			}
			if (TheCon.State == ConnectionState.Broken)
			{
				TheCon.Close();
				TheCon.Open();
			}
		}
		catch (Exception)
		{
			EncDec.RagsZone("DBPassword");
			string connectionString2 = "DataSource=" + DBName + ";Max Database Size=4024;Password=" + EncDec.RagsZone("DBPassword");
			SqlCeEngine sqlCeEngine = new SqlCeEngine(connectionString2);
			sqlCeEngine.Compact("DataSource=" + DBName + ";Password=" + EncDec.RagsZone("F1$asDDFHappy") + ";encrypt database=TRUE");
			sqlCeEngine.Dispose();
			connectionString2 = "DataSource=" + DBName + ";Max Database Size=4024;Password=" + EncDec.RagsZone("F1$asDDFHappy") + ";encrypt database=TRUE";
			if (TheCon != null && DBName != TheCon.DataSource)
			{
				TheCon.Close();
			}
			if (TheCon == null || TheCon.State == ConnectionState.Closed)
			{
				TheCon = new SqlCeConnection(connectionString2);
				TheCon.Open();
			}
			if (TheCon.State == ConnectionState.Broken)
			{
				TheCon.Close();
				TheCon.Open();
			}
		}
		return TheCon;
	}

	public void CreateDatabase(string name)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (File.Exists(name))
		{
			if (TheCon != null)
			{
				TheCon.Close();
			}
			try
			{
				File.Delete(name);
			}
			catch
			{
				MessageBox.Show("Unable to overwrite the file.  Please choose a different name.");
				return;
			}
		}
		DBName = name;
		SqlCeEngine sqlCeEngine = new SqlCeEngine("DataSource=" + name + ";Password=" + EncDec.RagsZone("F1$asDDFHappy") + ";encrypt database=TRUE");
		sqlCeEngine.CreateDatabase();
		sqlCeEngine.Dispose();
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("create table GameData(Title nvarchar(250),\r\n                            OpeningMessage ntext,\r\n                            HideMainPicDisplay bit,\r\n                            UseInlineImages bit,\r\n                            HidePortrait bit,\r\n                            AuthorName nvarchar(250),\r\n                            GameVersion nvarchar(50),\r\n                            GameInformation ntext,\r\n                            bgMusic nvarchar(250),\r\n                            RepeatbgMusic bit,\r\n                            PasswordProtected bit,\r\n                            GamePassword nvarchar(250),\r\n                            ObjectVersionNumber nvarchar(250),\r\n                            GameFont nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		SqlCeCommand sqlCeCommand2 = new SqlCeCommand("create table Rooms(UniqueID nvarchar(250),\r\n                            Description ntext,\r\n                            SDesc nvarchar(250),\r\n                            Name nvarchar(250),\r\n                            RoomPic nvarchar(250),\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit,\r\n                            [Group] nvarchar(250),\r\n                            LayeredRoomPic nvarchar(250))", dBConnection);
		sqlCeCommand2.ExecuteNonQuery();
		sqlCeCommand2.Dispose();
		SqlCeCommand sqlCeCommand3 = new SqlCeCommand("CREATE TABLE RoomActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand3.ExecuteNonQuery();
		sqlCeCommand3.Dispose();
		SqlCeCommand sqlCeCommand4 = new SqlCeCommand("CREATE TABLE RoomProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand4.ExecuteNonQuery();
		sqlCeCommand4.Dispose();
		SqlCeCommand sqlCeCommand5 = new SqlCeCommand("CREATE TABLE RoomExits (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Direction int,\r\n                    Active bit,\r\n                    DestinationRoom nvarchar(250),\r\n                    PortalObjectName nvarchar(250))", dBConnection);
		sqlCeCommand5.ExecuteNonQuery();
		sqlCeCommand5.Dispose();
		SqlCeCommand sqlCeCommand6 = new SqlCeCommand("create table Items(UniqueID nvarchar(250),\r\n                            Name nvarchar(250),\r\n                            Description ntext,\r\n                            SDesc nvarchar(250),\r\n                            Preposition nvarchar(250),\r\n                            LocationName nvarchar(250),\r\n                            LocationType int,\r\n                            Carryable bit,\r\n                            Wearable bit,\r\n                            Openable bit,\r\n                            Lockable bit,\r\n                            Enterable bit,\r\n                            Readable bit,\r\n                            Container bit,\r\n                            Weight float,\r\n                            Worn bit,\r\n                            [Read] bit,\r\n                            Locked bit,\r\n                            [Open] bit,\r\n                            Entered bit,\r\n                            Visible bit,\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit)", dBConnection);
		sqlCeCommand6.ExecuteNonQuery();
		sqlCeCommand6.Dispose();
		SqlCeCommand sqlCeCommand7 = new SqlCeCommand("CREATE TABLE ItemActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand7.ExecuteNonQuery();
		sqlCeCommand7.Dispose();
		SqlCeCommand sqlCeCommand8 = new SqlCeCommand("CREATE TABLE ItemProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand8.ExecuteNonQuery();
		sqlCeCommand8.Dispose();
		SqlCeCommand sqlCeCommand9 = new SqlCeCommand("CREATE TABLE ItemLayeredZoneLevels (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Data nvarchar(250))", dBConnection);
		sqlCeCommand9.ExecuteNonQuery();
		sqlCeCommand9.Dispose();
		SqlCeCommand sqlCeCommand10 = new SqlCeCommand("create table Media(Name nvarchar(250),\r\n                            BackgroundColor nvarchar(250),\r\n                            TextColor nvarchar(250),\r\n                            TextFont nvarchar(250),\r\n                            ImageName nvarchar(250),\r\n                            UseEnhancedGraphics bit,\r\n                            NewImage nvarchar(250),\r\n                            Data image)", dBConnection);
		sqlCeCommand10.ExecuteNonQuery();
		sqlCeCommand10.Dispose();
		SqlCeCommand sqlCeCommand11 = new SqlCeCommand("CREATE TABLE MediaLayeredImages (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    MediaName nvarchar(250),\r\n                    Data nvarchar(250))", dBConnection);
		sqlCeCommand11.ExecuteNonQuery();
		sqlCeCommand11.Dispose();
		SqlCeCommand sqlCeCommand12 = new SqlCeCommand("CREATE TABLE Player (\r\n                    Name nvarchar(250),\r\n                    Description ntext,\r\n                    StartingRoom nvarchar(250),\r\n                    CurrentRoom nvarchar(250),\r\n                    PlayerLayeredImage nvarchar(250),\r\n                    PlayerGender int,\r\n                    PromptForName bit,\r\n                    PromptForGender bit,\r\n                    PlayerPortrait nvarchar(250),\r\n                    EnforceWeight bit,\r\n                    WeightLimit float\r\n                    )", dBConnection);
		sqlCeCommand12.ExecuteNonQuery();
		sqlCeCommand12.Dispose();
		SqlCeCommand sqlCeCommand13 = new SqlCeCommand("CREATE TABLE PlayerActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Data ntext)", dBConnection);
		sqlCeCommand13.ExecuteNonQuery();
		sqlCeCommand13.Dispose();
		SqlCeCommand sqlCeCommand14 = new SqlCeCommand("CREATE TABLE PlayerProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand14.ExecuteNonQuery();
		sqlCeCommand14.Dispose();
		SqlCeCommand sqlCeCommand15 = new SqlCeCommand("create table Characters(Charname nvarchar(250),\r\n                            CharnameOverride nvarchar(250),\r\n                            CharGender int,\r\n                            CurrentRoom nvarchar(250),\r\n                            Description ntext,\r\n                            AllowInventoryInteraction bit,\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit)", dBConnection);
		sqlCeCommand15.ExecuteNonQuery();
		sqlCeCommand15.Dispose();
		SqlCeCommand sqlCeCommand16 = new SqlCeCommand("CREATE TABLE CharacterActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Charname nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand16.ExecuteNonQuery();
		sqlCeCommand16.Dispose();
		SqlCeCommand sqlCeCommand17 = new SqlCeCommand("CREATE TABLE CharacterProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Charname nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand17.ExecuteNonQuery();
		sqlCeCommand17.Dispose();
		SqlCeCommand sqlCeCommand18 = new SqlCeCommand("create table Variables(VarName nvarchar(250),\r\n                            String ntext,\r\n                            NumType float,\r\n                            Min nvarchar(50),\r\n                            Max nvarchar(50),\r\n                            EnforceRestrictions bit,\r\n                            VarComment ntext,\r\n                            dtDateTime datetime,\r\n                            VarType int,\r\n                            VarArray ntext)", dBConnection);
		sqlCeCommand18.ExecuteNonQuery();
		sqlCeCommand18.Dispose();
		SqlCeCommand sqlCeCommand19 = new SqlCeCommand("CREATE TABLE VariableProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    VarName nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand19.ExecuteNonQuery();
		sqlCeCommand19.Dispose();
		SqlCeCommand sqlCeCommand20 = new SqlCeCommand("create table Timer(Name nvarchar(250),\r\n                            TType int,\r\n                            Active bit,\r\n                            Restart bit,\r\n                            TurnNumber int,\r\n                            Length int,\r\n                            LiveTimer bit,\r\n                            TimerSeconds int)", dBConnection);
		sqlCeCommand20.ExecuteNonQuery();
		sqlCeCommand20.Dispose();
		SqlCeCommand sqlCeCommand21 = new SqlCeCommand("CREATE TABLE TimerActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Name nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand21.ExecuteNonQuery();
		sqlCeCommand21.Dispose();
		SqlCeCommand sqlCeCommand22 = new SqlCeCommand("CREATE TABLE TimerProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    TimerName nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand22.ExecuteNonQuery();
		sqlCeCommand22.Dispose();
		b();
	}

	private static void b()
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeDataReader sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='MediaGroups'", dBConnection).ExecuteReader();
		bool flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("Create table MediaGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Items' and COLUMN_NAME='GroupName'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table Items Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Items' and COLUMN_NAME='Important'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table Items Add Column \r\n                        Important bit not null default (0)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='RoomGroups'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table GameData Add Column \r\n                        RoomGroups ntext\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='ClothingZoneLevels'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table GameData Add Column \r\n                        ClothingZoneLevels ntext\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='NotificationsOff'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table GameData Add Column \r\n                        NotificationsOff bit not null default (0)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='SortOrderRoom'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table GameData Add Column \r\n                        SortOrderRoom int not null default (0),\r\n                        SortOrderCharacters int not null default (0),\r\n                        SortOrderInventory int not null default (0)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Media' and COLUMN_NAME='GroupName'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table Media Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='ItemGroups'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("Create table ItemGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='VariableGroups'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("Create table VariableGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Variables' and COLUMN_NAME='GroupName'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table Variables Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='StatusBarItems'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("Create table StatusBarItems (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Text ntext,\r\n                        Width int\r\n                        )", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS\r\n                    where TABLE_NAME='StatusBarItems' and COLUMN_NAME='Visible'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table StatusBarItems Add Column \r\n                        Visible bit not null default (1)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Characters' and COLUMN_NAME='CharPortrait'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table Characters Add Column \r\n                        CharPortrait nvarchar(255)\r\n                        ", dBConnection).ExecuteNonQuery();
		}
		sqlCeDataReader = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='MediaLayeredImages' and COLUMN_NAME='Order'", dBConnection).ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read() && sqlCeDataReader.GetInt32(0) == 1)
		{
			flag = false;
		}
		if (flag)
		{
			new SqlCeCommand("alter table MediaLayeredImages Add Column \r\n                        [Order] int\r\n                        ", dBConnection).ExecuteNonQuery();
		}
	}

	public static void ThrdLoadData(object stateinfo)
	{
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected Obj, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected Obj, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		Game game = stateinfo as Game;
		float num = 0f;
		PercentageComplete = 0;
		int num2 = 8;
		b();
		using (SqlCeConnection connection = GetDBConnection())
		{
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from GameData", connection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				game.Title = sqlCeDataReader["Title"].ToString();
				game.OpeningMessage = sqlCeDataReader["OpeningMessage"].ToString();
				game.bHideMainPicDisplay = (bool)sqlCeDataReader["HideMainPicDisplay"];
				game.bUseInlineImages = (bool)sqlCeDataReader["UseInlineImages"];
				game.bHidePortrait = (bool)sqlCeDataReader["HidePortrait"];
				game.AuthorName = sqlCeDataReader["AuthorName"].ToString();
				game.GameVersion = sqlCeDataReader["GameVersion"].ToString();
				game.GameInformation = sqlCeDataReader["GameInformation"].ToString();
				game.bgMusic = sqlCeDataReader["bgMusic"].ToString();
				game.bRepeatbgMusic = (bool)sqlCeDataReader["RepeatbgMusic"];
				game.bPasswordProtected = (bool)sqlCeDataReader["PasswordProtected"];
				game.GamePassword = sqlCeDataReader["GamePassword"].ToString();
				game.bTurnOffNotifications = (bool)sqlCeDataReader["NotificationsOff"];
				game.SortOrderRoomObjects = (SortOrder)(int)sqlCeDataReader["SortOrderRoom"];
				game.SortOrderCharacters = (SortOrder)(int)sqlCeDataReader["SortOrderCharacters"];
				game.SortOrderInventory = (SortOrder)(int)sqlCeDataReader["SortOrderInventory"];
				CurrentObjectVersionNumber = sqlCeDataReader["ObjectVersionNumber"].ToString();
				TypeDescriptor.GetConverter(typeof(Font));
				string text = sqlCeDataReader["GameFont"].ToString();
				string[] array = sqlCeDataReader["RoomGroups"].ToString().Split(new string[1] { "," }, StringSplitOptions.None);
				game.RoomGroups.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != string.Empty)
					{
						game.RoomGroups.Add(array[i]);
					}
				}
				string[] array2 = sqlCeDataReader["ClothingZoneLevels"].ToString().Split(new string[1] { "," }, StringSplitOptions.None);
				game.LayeredClothingZones.Clear();
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] != string.Empty)
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
					string text2 = text.Substring(0, text.IndexOf(","));
					string text3 = text.Substring(text.IndexOf(",") + 1);
					if (text3.IndexOf("pt") > -1)
					{
						string text4 = text3;
						text3 = text4.Remove(text4.IndexOf("pt"));
					}
					text3 = text3.Replace(",", ".");
					if (text2.Length > 1)
					{
						game.GameFont = new Font(text2, (float)Convert.ToDouble(text3));
					}
					else
					{
						game.GameFont = new Font("Times New Roman", 12f);
					}
				}
			}
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("Select * from StatusBarItems", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.StatusBarItems.Add(new StatusBarItem(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("Select * from Rooms", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.RoomList.Add(new Room(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("Select * from Items", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
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
			sqlCeCommand = new SqlCeCommand("Select Name,BackgroundColor,TextColor,TextFont,\r\n                        ImageName, UseEnhancedGraphics,NewImage,GroupName from Media", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.PictureList.Add(new GamePicture(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("select * from Player", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				game.ThePlayer = new Player(sqlCeDataReader);
				try
				{
					game.ThePlayer.StartingRoom = game.GetRoomByID(new Guid(sqlCeDataReader["StartingRoom"].ToString()));
				}
				catch
				{
					game.ThePlayer.StartingRoom = null;
				}
				try
				{
					game.ThePlayer.CurrentRoom = game.GetRoomByID(new Guid(sqlCeDataReader["CurrentRoom"].ToString()));
				}
				catch
				{
					game.ThePlayer.CurrentRoom = null;
				}
			}
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("Select * from Characters", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
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
			sqlCeCommand = new SqlCeCommand("Select * from Variables", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.VariableList.Add(new GameVariable(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			lock (Lockobj)
			{
				PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			}
			sqlCeCommand = new SqlCeCommand("Select * from Timer", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.TimerList.Add(new Timer(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
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
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from GameData", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("insert into GameData values(@Title,@OpeningMessage,\r\n                        @HideMainPicDisplay,@UseInlineImages,@HidePortrait,\r\n                        @AuthorName,@GameVersion,@GameInformation,@bgMusic,@RepeatbgMusic,@PasswordProtected,@Password,@ObjectVersionNumber,\r\n                          @GameFont,@RoomGroups,@ClothingZoneLevels,@NotificationsOff,@SortOrderRoom,\r\n                        @SortOrderCharacters, @SortOrderInventory)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Title", game.Title);
		sqlCeCommand.Parameters.AddWithValue("@OpeningMessage", game.OpeningMessage);
		sqlCeCommand.Parameters.AddWithValue("@HideMainPicDisplay", game.bHideMainPicDisplay);
		sqlCeCommand.Parameters.AddWithValue("@UseInlineImages", game.bUseInlineImages);
		sqlCeCommand.Parameters.AddWithValue("@HidePortrait", game.bHidePortrait);
		sqlCeCommand.Parameters.AddWithValue("@AuthorName", game.AuthorName);
		sqlCeCommand.Parameters.AddWithValue("@GameVersion", game.GameVersion);
		sqlCeCommand.Parameters.AddWithValue("@GameInformation", game.GameInformation);
		sqlCeCommand.Parameters.AddWithValue("@bgMusic", game.bgMusic);
		sqlCeCommand.Parameters.AddWithValue("@RepeatbgMusic", game.bRepeatbgMusic);
		sqlCeCommand.Parameters.AddWithValue("@PasswordProtected", game.bPasswordProtected);
		sqlCeCommand.Parameters.AddWithValue("@Password", game.GamePassword);
		if (CurrentObjectVersionNumber == string.Empty)
		{
			CurrentObjectVersionNumber = ObjectVersionNumber;
		}
		sqlCeCommand.Parameters.AddWithValue("@ObjectVersionNumber", CurrentObjectVersionNumber);
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
		sqlCeCommand.Parameters.AddWithValue("@GameFont", converter.ConvertToString(game.GameFont));
		string text = string.Empty;
		foreach (string roomGroup in game.RoomGroups)
		{
			if (text != string.Empty)
			{
				text += ",";
			}
			text += roomGroup;
		}
		sqlCeCommand.Parameters.AddWithValue("@RoomGroups", text);
		string text3 = string.Empty;
		foreach (string layeredClothingZone in game.LayeredClothingZones)
		{
			if (text3 != string.Empty)
			{
				text3 += ",";
			}
			text3 += layeredClothingZone;
		}
		sqlCeCommand.Parameters.AddWithValue("@ClothingZoneLevels", text3);
		sqlCeCommand.Parameters.AddWithValue("@NotificationsOff", game.bTurnOffNotifications);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderRoom", game.SortOrderRoomObjects);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderCharacters", game.SortOrderCharacters);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderInventory", game.SortOrderInventory);
		sqlCeCommand.ExecuteNonQuery();
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		sqlCeCommand = new SqlCeCommand("delete from StatusBarItems", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (StatusBarItem statusBarItem in game.StatusBarItems)
		{
			statusBarItem.UpdateDatabase();
		}
		DateTime now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Rooms", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomExits", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Room room in game.RoomList)
		{
			room.a();
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Items", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemLayeredZoneLevels", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameObject @object in game.ObjectList)
		{
			@object.a();
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		game.ThePlayer.UpdateDatabase();
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Characters", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from CharacterActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from CharacterProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Character character in game.CharacterList)
		{
			character.UpdateDatabase();
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Variables", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from VariableProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameVariable variable in game.VariableList)
		{
			variable.UpdateDatabase();
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Timer", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from TimerActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from TimerProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Timer timer in game.TimerList)
		{
			timer.UpdateDatabase();
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		dBConnection.Close();
		dBConnection.Dispose();
		num++;
		bDoneWithWaitDlg = true;
	}

	public void UpdateDatabase()
	{
		tempwaitdlg = new WaitDlg();
		((Control)tempwaitdlg.label1).Text = "Saving data...";
		try
		{
			Cursor.Current = Cursors.WaitCursor;
			bDoneWithWaitDlg = false;
			((Control)tempwaitdlg).Show();
			ThreadPool.QueueUserWorkItem(ThrdUpdateDatabase, this);
			checktimer.Interval = 500;
			checktimer.Tick += a;
			checktimer.Start();
		}
		finally
		{
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		lock (Lockobj)
		{
			if (PercentageComplete > 100)
			{
				PercentageComplete = 100;
			}
			tempwaitdlg.progressBar1.Value = PercentageComplete;
			if (bDoneWithWaitDlg)
			{
				tempwaitdlg.progressBar1.Value = 100;
				Application.DoEvents();
				((Form)tempwaitdlg).Close();
				Cursor.Current = Cursors.Default;
				checktimer.Stop();
				bDoneWithWaitDlg = false;
			}
		}
	}

	private void a()
	{
		if (Application.ExecutablePath.ToUpper().IndexOf("RAGSDESIGNER.EXE") <= -1)
		{
			return;
		}
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "QuickCommands.bin");
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		if (!File.Exists(path))
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

	protected Game(SerializationInfo info, StreamingContext context)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected Obj, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			try
			{
				CurrentObjectVersionNumber = (string)info.GetValue("ObjectVersionNumber", ObjectVersionNumber.GetType());
			}
			catch
			{
				CurrentObjectVersionNumber = ((double)info.GetValue("ObjectVersionNumber", ObjectVersionNumber.GetType())).ToString();
			}
			try
			{
				GameFont = (Font)info.GetValue("GameFont", ((object)GameFont).GetType());
			}
			catch
			{
				GameFont = new Font("Microsoft Sans Serif", 8.25f);
			}
			Version version = new Version(CurrentObjectVersionNumber);
			Version version2 = new Version(ObjectVersionNumber);
			if (version < version2)
			{
				bUpgrading = true;
			}
			else
			{
				bUpgrading = false;
			}
			if (version > version2)
			{
				MessageBox.Show("This Rags Game was created with a newer version of the Rags designer. Game version: " + CurrentObjectVersionNumber.ToString() + " Your version: " + ObjectVersionNumber.ToString() + " Please go to http://www.ragsgame.com and update your version.");
				return;
			}
			try
			{
				bPasswordProtected = (bool)info.GetValue("bPasswordProtected", bPasswordProtected.GetType());
				GamePassword = (string)info.GetValue("GamePassword", GamePassword.GetType());
				RoomList = (ArrayList)info.GetValue("RoomList", RoomList.GetType());
				ThePlayer = (Player)info.GetValue("ThePlayer", ThePlayer.GetType());
				try
				{
					PictureList = (ArrayList)info.GetValue("PictureList", PictureList.GetType());
				}
				catch
				{
					PictureList = new ArrayList();
				}
				ObjectList = (ArrayList)info.GetValue("ObjectList", ObjectList.GetType());
				VariableList = (ArrayList)info.GetValue("VariableList", VariableList.GetType());
				CharacterList = (ArrayList)info.GetValue("CharacterList", CharacterList.GetType());
				Title = (string)info.GetValue("Title", Title.GetType());
				OpeningMessage = (string)info.GetValue("OpeningMessage", OpeningMessage.GetType());
				try
				{
					TimerList = (ArrayList)info.GetValue("TimerList", TimerList.GetType());
				}
				catch
				{
					TimerList = new ArrayList();
				}
				try
				{
					StatusBarItems = (ArrayList)info.GetValue("StatusBarItems", StatusBarItems.GetType());
				}
				catch
				{
					StatusBarItems = new ArrayList();
				}
				try
				{
					LayeredClothingZones = (ArrayList)info.GetValue("LayeredClothingZones", LayeredClothingZones.GetType());
				}
				catch
				{
					LayeredClothingZones = new ArrayList();
					LayeredClothingZones.Add("Upper Body");
					LayeredClothingZones.Add("Mid Body");
					LayeredClothingZones.Add("Lower Body");
				}
				try
				{
					RoomGroups = (ArrayList)info.GetValue("RoomGroups", RoomGroups.GetType());
				}
				catch
				{
					RoomGroups = new ArrayList();
				}
				try
				{
					bHideMainPicDisplay = info.GetBoolean("HideMainPicDisplay");
				}
				catch
				{
					bHideMainPicDisplay = false;
				}
				try
				{
					bUseInlineImages = info.GetBoolean("UseInlineImages");
				}
				catch
				{
					bUseInlineImages = false;
				}
				try
				{
					bHidePortrait = info.GetBoolean("HidePortrait");
				}
				catch
				{
					bHidePortrait = false;
				}
				try
				{
					AuthorName = info.GetString("AuthorName");
				}
				catch
				{
					AuthorName = string.Empty;
				}
				try
				{
					GameVersion = info.GetString("GameVersion");
				}
				catch
				{
					GameVersion = "1.0";
				}
				try
				{
					GameInformation = info.GetString("GameInformation");
				}
				catch
				{
					GameInformation = string.Empty;
				}
				try
				{
					bgMusic = info.GetString("bgMusic");
				}
				catch
				{
					bgMusic = string.Empty;
				}
				try
				{
					bRepeatbgMusic = info.GetBoolean("bRepeatbgMusic");
				}
				catch
				{
					bRepeatbgMusic = false;
				}
				a();
			}
			catch
			{
				MessageBox.Show("Sorry, this RAGS game file can not be upgraded.  Please visit RAGS downloads at http://www.ragsgame.com/downloads and download a legacy version.  This game was written with version:" + CurrentObjectVersionNumber + ".  Please download a legacy RAGS version as close to this version as possible.");
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in game!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("ObjectVersionNumber", ObjectVersionNumber, ObjectVersionNumber.GetType());
		info.AddValue("bPasswordProtected", bPasswordProtected, bPasswordProtected.GetType());
		info.AddValue("GamePassword", GamePassword, GamePassword.GetType());
		info.AddValue("RoomList", RoomList, RoomList.GetType());
		info.AddValue("ThePlayer", ThePlayer, ThePlayer.GetType());
		info.AddValue("PictureList", PictureList, PictureList.GetType());
		info.AddValue("ObjectList", ObjectList, ObjectList.GetType());
		info.AddValue("VariableList", VariableList, VariableList.GetType());
		info.AddValue("CharacterList", CharacterList, CharacterList.GetType());
		info.AddValue("Title", Title, Title.GetType());
		info.AddValue("OpeningMessage", OpeningMessage, OpeningMessage.GetType());
		info.AddValue("TimerList", TimerList, TimerList.GetType());
		info.AddValue("StatusBarItems", StatusBarItems, StatusBarItems.GetType());
		info.AddValue("LayeredClothingZones", LayeredClothingZones, LayeredClothingZones.GetType());
		info.AddValue("RoomGroups", RoomGroups, RoomGroups.GetType());
		info.AddValue("GameFont", GameFont, ((object)GameFont).GetType());
		info.AddValue("HideMainPicDisplay", bHideMainPicDisplay, bHideMainPicDisplay.GetType());
		info.AddValue("UseInlineImages", bUseInlineImages, bUseInlineImages.GetType());
		info.AddValue("HidePortrait", bHidePortrait, bHidePortrait.GetType());
		info.AddValue("AuthorName", AuthorName, AuthorName.GetType());
		info.AddValue("GameVersion", GameVersion, GameVersion.GetType());
		info.AddValue("GameInformation", GameInformation, GameInformation.GetType());
		info.AddValue("bgMusic", bgMusic, bgMusic.GetType());
		info.AddValue("bRepeatbgMusic", bRepeatbgMusic, bRepeatbgMusic.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc, bool bRooms, bool bCharacters, bool bObjects, bool bVariables, bool bTimers, bool bStatusBarItems, bool bPlayer, bool bImages)
	{
		CurDoc.WriteLine("<RAGSGAME>");
		AddXMLSection(ref CurDoc, "Title", Title);
		AddXMLSection(ref CurDoc, "OpeningMessage", OpeningMessage);
		AddXMLSection(ref CurDoc, "HideMainPicDisplay", bHideMainPicDisplay.ToString());
		AddXMLSection(ref CurDoc, "UseInlineImages", bUseInlineImages.ToString());
		AddXMLSection(ref CurDoc, "HidePortrait", bHidePortrait.ToString());
		AddXMLSection(ref CurDoc, "AuthorName", AuthorName.ToString());
		AddXMLSection(ref CurDoc, "GameVersion", GameVersion.ToString());
		AddXMLSection(ref CurDoc, "GameInformation", GameInformation.ToString());
		AddXMLSection(ref CurDoc, "bgMusic", bgMusic.ToString());
		AddXMLSection(ref CurDoc, "bRepeatbgMusic", bRepeatbgMusic.ToString());
		if (bRooms && RoomList.Count > 0)
		{
			CurDoc.WriteLine("<Rooms>");
			foreach (Room room in RoomList)
			{
				room.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Rooms>");
		}
		if (bPlayer)
		{
			ThePlayer.GetXMLData(ref CurDoc);
		}
		if (bCharacters && CharacterList.Count > 0)
		{
			CurDoc.WriteLine("<Characters>");
			foreach (Character character in CharacterList)
			{
				character.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Characters>");
		}
		if (bObjects && ObjectList.Count > 0)
		{
			CurDoc.WriteLine("<Objects>");
			foreach (GameObject @object in ObjectList)
			{
				@object.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Objects>");
		}
		if (bVariables && VariableList.Count > 0)
		{
			CurDoc.WriteLine("<Variables>");
			foreach (GameVariable variable in VariableList)
			{
				variable.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Variables>");
		}
		if (bTimers && TimerList.Count > 0)
		{
			CurDoc.WriteLine("<Timers>");
			foreach (Timer timer in TimerList)
			{
				timer.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Timers>");
		}
		if (bStatusBarItems && StatusBarItems.Count > 0)
		{
			CurDoc.WriteLine("<StatusBarItems>");
			foreach (StatusBarItem statusBarItem in StatusBarItems)
			{
				statusBarItem.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</StatusBarItems>");
		}
		if (bImages && PictureList.Count > 0)
		{
			CurDoc.WriteLine("<Images>");
			foreach (GamePicture picture in PictureList)
			{
				picture.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Images>");
		}
		if (LayeredClothingZones.Count > 0)
		{
			CurDoc.WriteLine("<LayeredClothingZones>");
			foreach (string layeredClothingZone in LayeredClothingZones)
			{
				AddXMLSection(ref CurDoc, "LayeredClothingZone", layeredClothingZone);
			}
			CurDoc.WriteLine("</LayeredClothingZones>");
		}
		if (RoomGroups.Count > 0)
		{
			CurDoc.WriteLine("<RoomGroups>");
			foreach (string roomGroup in RoomGroups)
			{
				AddXMLSection(ref CurDoc, "RoomGroup", roomGroup);
			}
			CurDoc.WriteLine("</RoomGroups>");
		}
		CurDoc.WriteLine("</RAGSGAME>");
	}

	public static void AddXMLSection(ref StreamWriter CurDoc, string titlename, string value)
	{
		CurDoc.WriteLine("<" + titlename + ">");
		CurDoc.WriteLine($"<![CDATA[{value}]]>");
		CurDoc.WriteLine("</" + titlename + ">");
	}

	public static void AddXMLSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append($"<![CDATA[{value}]]>");
		CurDoc.Append("</" + titlename + ">");
	}

	public static void AddAdvSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append(value);
		CurDoc.Append("</" + titlename + ">\r\n");
	}

	public static XmlNode GetXMLSection(ref XmlNode node, string titlename)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == titlename)
			{
				result = childNode;
				break;
			}
		}
		return result;
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Title");
		if (xMLSection != null)
		{
			Title = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "OpeningMessage");
		if (xMLSection != null)
		{
			OpeningMessage = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "HideMainPicDisplay");
		if (xMLSection != null)
		{
			bHideMainPicDisplay = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "UseInlineImages");
		if (xMLSection != null)
		{
			bUseInlineImages = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "HidePortrait");
		if (xMLSection != null)
		{
			bHidePortrait = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "AuthorName");
		if (xMLSection != null)
		{
			AuthorName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "GameVersion");
		if (xMLSection != null)
		{
			GameVersion = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "GameInformation");
		if (xMLSection != null)
		{
			GameInformation = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "bgMusic");
		if (xMLSection != null)
		{
			bgMusic = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "bRepeatbgMusic");
		if (xMLSection != null)
		{
			bRepeatbgMusic = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Rooms");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Room room = new Room();
				room.SetXMLData(ref CurNode2, this);
				foreach (Room room5 in RoomList)
				{
					if (room5.UniqueID == room.UniqueID)
					{
						RoomList.Remove(room5);
						break;
					}
				}
				RoomList.Add(room);
				if (ThePlayer.StartingRoom != null && room.UniqueID == ThePlayer.StartingRoom.UniqueID)
				{
					ThePlayer.StartingRoom = room;
				}
			}
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Room room3 = new Room();
				room3.SetXMLData(ref CurNode3, this);
				foreach (Room room6 in RoomList)
				{
					if (room6.UniqueID == room3.UniqueID)
					{
						RoomList.Remove(room6);
						break;
					}
				}
				RoomList.Add(room3);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Player");
		if (xMLSection != null)
		{
			ThePlayer.SetXMLData(ref xMLSection, this);
		}
		xMLSection = GetXMLSection(ref CurNode, "Characters");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode node = xMLSection.ChildNodes[k];
				Character character = new Character(GetXMLSection(ref node, "Name").InnerText);
				character.SetXMLData(ref node);
				foreach (Character character2 in CharacterList)
				{
					if (character2.Charname == character.Charname)
					{
						CharacterList.Remove(character2);
						break;
					}
				}
				CharacterList.Add(character);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Objects");
		if (xMLSection != null)
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[l];
				GameObject gameObject = new GameObject();
				gameObject.SetXMLData(ref CurNode4);
				foreach (GameObject @object in ObjectList)
				{
					if (@object.name == gameObject.name)
					{
						ObjectList.Remove(@object);
						break;
					}
				}
				ObjectList.Add(gameObject);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Variables");
		if (xMLSection != null)
		{
			for (int m = 0; m < xMLSection.ChildNodes.Count; m++)
			{
				XmlNode node2 = xMLSection.ChildNodes[m];
				GameVariable gameVariable = new GameVariable(GetXMLSection(ref node2, "Name").InnerText);
				gameVariable.SetXMLData(ref node2);
				foreach (GameVariable variable in VariableList)
				{
					if (variable.varname == gameVariable.varname)
					{
						VariableList.Remove(variable);
						break;
					}
				}
				VariableList.Add(gameVariable);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Timers");
		if (xMLSection != null)
		{
			for (int n = 0; n < xMLSection.ChildNodes.Count; n++)
			{
				XmlNode CurNode5 = xMLSection.ChildNodes[n];
				Timer timer = new Timer();
				timer.SetXMLData(ref CurNode5);
				foreach (Timer timer2 in TimerList)
				{
					if (timer2.Name == timer.Name)
					{
						TimerList.Remove(timer2);
						break;
					}
				}
				TimerList.Add(timer);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "StatusBarItems");
		if (xMLSection != null)
		{
			for (int num = 0; num < xMLSection.ChildNodes.Count; num++)
			{
				XmlNode CurNode6 = xMLSection.ChildNodes[num];
				StatusBarItem statusBarItem = new StatusBarItem();
				statusBarItem.SetXMLData(ref CurNode6);
				foreach (StatusBarItem statusBarItem2 in StatusBarItems)
				{
					if (statusBarItem2.Name == statusBarItem.Name)
					{
						StatusBarItems.Remove(statusBarItem2);
						break;
					}
				}
				StatusBarItems.Add(statusBarItem);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Images");
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
		xMLSection = GetXMLSection(ref CurNode, "LayeredClothingZones");
		if (xMLSection != null)
		{
			LayeredClothingZones.Clear();
			for (int num3 = 0; num3 < xMLSection.ChildNodes.Count; num3++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[num3];
				if (xmlNode != null)
				{
					LayeredClothingZones.Add(xmlNode.InnerText);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "RoomGroups");
		if (xMLSection == null)
		{
			return;
		}
		RoomGroups.Clear();
		for (int num4 = 0; num4 < xMLSection.ChildNodes.Count; num4++)
		{
			XmlNode xmlNode2 = xMLSection.ChildNodes[num4];
			if (xmlNode2 != null)
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
		if (GetRoomByID(RoomID) == null)
		{
			return;
		}
		foreach (GameObject @object in ObjectList)
		{
			if (@object.locationtype == GameObject.LocationType.LT_ROOM && @object.locationname == RoomID.ToString() && @object.name == ObjectName)
			{
				@object.locationtype = GameObject.LocationType.LT_NULL;
			}
		}
	}

	public GameVariable GetVariableByName(string varname)
	{
		if (varname.IndexOf("(") > -1)
		{
			varname = varname.Substring(0, varname.IndexOf("("));
		}
		for (int i = 0; i < VariableList.Count; i++)
		{
			if (string.Compare(varname, ((GameVariable)VariableList[i]).varname, ignoreCase: true) == 0)
			{
				return (GameVariable)VariableList[i];
			}
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
			if (string.Compare(roomname, ((Room)RoomList[i]).Name, ignoreCase: true) == 0)
			{
				return (Room)RoomList[i];
			}
		}
		return null;
	}

	public Room GetRoomByID(Guid roomid)
	{
		foreach (Room room in RoomList)
		{
			if (roomid.CompareTo(room.UniqueID) == 0)
			{
				return room;
			}
		}
		return null;
	}

	public object GetPictureByName(string picname)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		for (int i = 0; i < PictureList.Count; i++)
		{
			if (string.Compare(picname, ((GamePicture)PictureList[i]).TheName, ignoreCase: true) != 0)
			{
				continue;
			}
			byte[] array = null;
			try
			{
				SqlCeConnection dBConnection = GetDBConnection();
				SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
				sqlCeCommand.Parameters.AddWithValue("@Name", ((GamePicture)PictureList[i]).TheName);
				SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
				if (sqlCeDataReader.Read())
				{
					array = (byte[])sqlCeDataReader["Data"];
				}
			}
			catch
			{
				array = ((GamePicture)PictureList[i]).ImageData;
			}
			if (array == null)
			{
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
					tempPath = Path.Combine(tempPath, DateTime.Now.ToString("MMddyyhhmmssfff") + picname);
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
			if (string.Compare(picname, ((GamePicture)PictureList[i]).TheName, ignoreCase: true) == 0)
			{
				return (GamePicture)PictureList[i];
			}
		}
		return null;
	}

	public Character GetCharacterByName(string charname)
	{
		for (int i = 0; i < CharacterList.Count; i++)
		{
			if (string.Compare(charname, ((Character)CharacterList[i]).Charname, ignoreCase: true) == 0)
			{
				return (Character)CharacterList[i];
			}
		}
		return null;
	}

	public GameObject GetObjectByName(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			if (string.Compare(objectname, ((GameObject)ObjectList[i]).UniqueIdentifier.ToString(), ignoreCase: true) == 0)
			{
				return (GameObject)ObjectList[i];
			}
		}
		return null;
	}

	public GameObject GetObjectByNameOld(string objectname)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			if (string.Compare(objectname, ((GameObject)ObjectList[i]).name, ignoreCase: true) == 0)
			{
				return (GameObject)ObjectList[i];
			}
		}
		return null;
	}

	public QuickMenuItem GetMenuItemByName(string mnuitemguid)
	{
		for (int i = 0; i < QuickCommands.Count; i++)
		{
			if (string.Compare(mnuitemguid, ((QuickMenuItem)QuickCommands[i]).UniqueID.ToString(), ignoreCase: true) == 0)
			{
				return (QuickMenuItem)QuickCommands[i];
			}
		}
		return null;
	}

	public Timer GetTimerByName(string timername)
	{
		for (int i = 0; i < TimerList.Count; i++)
		{
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
			Exit exit = (Exit)ThePlayer.CurrentRoom.Exits[i];
			if (exit.Direction == dir)
			{
				ThePlayer.CurrentRoom = GetRoomByID(new Guid(exit.DestinationRoom));
				break;
			}
		}
	}

	private void a(ref Action A_0)
	{
		for (int i = 0; i < A_0.PassCommands.Count; i++)
		{
			Command A_1 = A_0.PassCommands[i] as Command;
			Condition A_2 = A_0.PassCommands[i] as Condition;
			if (A_1 != null)
			{
				a(ref A_1);
			}
			else if (A_2 != null)
			{
				a(ref A_2);
			}
		}
		for (int j = 0; j < A_0.FailCommands.Count; j++)
		{
			Command A_3 = A_0.FailCommands[j] as Command;
			Condition A_4 = A_0.FailCommands[j] as Condition;
			if (A_3 != null)
			{
				a(ref A_3);
			}
			else if (A_4 != null)
			{
				a(ref A_4);
			}
		}
		for (int k = 0; k < A_0.Conditions.Count; k++)
		{
			Condition A_5 = (Condition)A_0.Conditions[k];
			a(ref A_5);
		}
	}

	private void a(ref Condition A_0)
	{
		for (int i = 0; i < A_0.Checks.Count; i++)
		{
			Check A_1 = (Check)A_0.Checks[i];
			a(ref A_1);
		}
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command A_2 = A_0.PassCommands[j] as Command;
			Condition A_3 = A_0.PassCommands[j] as Condition;
			if (A_2 != null)
			{
				a(ref A_2);
			}
			if (A_3 != null)
			{
				a(ref A_3);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command A_4 = A_0.FailCommands[k] as Command;
			Condition A_5 = A_0.FailCommands[k] as Condition;
			if (A_4 != null)
			{
				a(ref A_4);
			}
			if (A_5 != null)
			{
				a(ref A_5);
			}
		}
	}

	private void a(ref Check A_0)
	{
		switch (A_0.CondType)
		{
		case Condition.ConditionType.CT_Item_In_Room:
			try
			{
				new Guid(A_0.ConditionStep2);
			}
			catch
			{
				if (GetObjectByNameOld(A_0.ConditionStep2) != null)
				{
					A_0.ConditionStep2 = GetObjectByNameOld(A_0.ConditionStep2).UniqueIdentifier.ToString();
				}
			}
			try
			{
				new Guid(A_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetRoomByName(ref A_0.ConditionStep3) != null)
				{
					A_0.ConditionStep3 = GetRoomByName(ref A_0.ConditionStep3).UniqueID.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Player_In_Room:
			try
			{
				new Guid(A_0.ConditionStep2);
				break;
			}
			catch
			{
				if (GetRoomByName(ref A_0.ConditionStep2) != null)
				{
					A_0.ConditionStep2 = GetRoomByName(ref A_0.ConditionStep2).UniqueID.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_Held_By_Character:
			try
			{
				new Guid(A_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(A_0.ConditionStep3) != null)
				{
					A_0.ConditionStep3 = GetObjectByNameOld(A_0.ConditionStep3).UniqueIdentifier.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_Held_By_Player:
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
		case Condition.ConditionType.CT_Item_State_Check:
			try
			{
				new Guid(A_0.ConditionStep2);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(A_0.ConditionStep2) != null)
				{
					A_0.ConditionStep2 = GetObjectByNameOld(A_0.ConditionStep2).UniqueIdentifier.ToString();
				}
				break;
			}
		case Condition.ConditionType.CT_Item_In_Object:
			try
			{
				new Guid(A_0.ConditionStep2);
			}
			catch
			{
				if (GetObjectByNameOld(A_0.ConditionStep2) != null)
				{
					A_0.ConditionStep2 = GetObjectByNameOld(A_0.ConditionStep2).UniqueIdentifier.ToString();
				}
			}
			try
			{
				new Guid(A_0.ConditionStep3);
				break;
			}
			catch
			{
				if (GetObjectByNameOld(A_0.ConditionStep2) != null)
				{
					A_0.ConditionStep3 = GetObjectByNameOld(A_0.ConditionStep3).UniqueIdentifier.ToString();
				}
				break;
			}
		}
	}

	private void a(ref Command A_0)
	{
		string roomname = A_0.CommandPart2;
		string roomname2 = A_0.CommandPart3;
		switch (A_0.cmdtype)
		{
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
			if (A_0.CommandPart2 != "<<Self>>")
			{
				try
				{
					new Guid(roomname);
					break;
				}
				catch
				{
					try
					{
						A_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
						break;
					}
					catch
					{
						break;
					}
				}
			}
			if (A_0.CommandPart2 == "<<Self>>")
			{
				A_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
			}
			break;
		case Command.CommandType.CT_MOVEITEMTOOBJ:
			if (A_0.CommandPart2 != "<<Self>>")
			{
				try
				{
					new Guid(roomname);
				}
				catch
				{
					try
					{
						A_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
					}
					catch
					{
					}
				}
			}
			else if (A_0.CommandPart2 == "<<Self>>")
			{
				A_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
			}
			if (A_0.CommandPart3 != "<<Self>>")
			{
				try
				{
					new Guid(roomname2);
					break;
				}
				catch
				{
					try
					{
						A_0.CommandPart3 = GetObjectByNameOld(roomname2).UniqueIdentifier.ToString();
						break;
					}
					catch
					{
						break;
					}
				}
			}
			if (A_0.CommandPart3 == "<<Self>>")
			{
				A_0.CommandPart3 = GameObject.SelfObjectGuid.ToString();
			}
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOROOM:
		case Command.CommandType.CT_MOVEPLAYER:
		case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
		case Command.CommandType.CT_DISPLAYROOMPICTURE:
		case Command.CommandType.CT_SETROOMACTION:
		case Command.CommandType.CT_SETROOMDESCRIPTION:
		case Command.CommandType.CT_SETEXIT:
		case Command.CommandType.CT_SETROOMPIC:
			if (A_0.CommandPart2 != "<CurrentRoom>" && A_0.CommandPart2 != "<Void>")
			{
				try
				{
					new Guid(roomname);
					break;
				}
				catch
				{
					try
					{
						A_0.CommandPart2 = GetRoomByName(ref roomname).UniqueID.ToString();
						break;
					}
					catch
					{
						break;
					}
				}
			}
			if (A_0.CommandPart2 == "<CurrentRoom>")
			{
				A_0.CommandPart2 = Room.CurrentRoomGuid.ToString();
			}
			else if (A_0.CommandPart2 == "<Void>")
			{
				A_0.CommandPart2 = Room.VoidRoomGuid.ToString();
			}
			break;
		case Command.CommandType.CT_MOVEITEMTOROOM:
			if (A_0.CommandPart2 != "<<Self>>")
			{
				try
				{
					new Guid(roomname);
				}
				catch
				{
					try
					{
						A_0.CommandPart2 = GetObjectByNameOld(roomname).UniqueIdentifier.ToString();
					}
					catch
					{
					}
				}
			}
			else if (A_0.CommandPart2 == "<<Self>>")
			{
				A_0.CommandPart2 = GameObject.SelfObjectGuid.ToString();
			}
			if (A_0.CommandPart3 != "<CurrentRoom>" && A_0.CommandPart3 != "<Void>")
			{
				try
				{
					new Guid(roomname2);
					break;
				}
				catch
				{
					try
					{
						A_0.CommandPart3 = GetRoomByName(ref roomname2).UniqueID.ToString();
						break;
					}
					catch
					{
						break;
					}
				}
			}
			if (A_0.CommandPart3 == "<CurrentRoom>")
			{
				A_0.CommandPart3 = Room.CurrentRoomGuid.ToString();
			}
			else if (A_0.CommandPart3 == "<Void>")
			{
				A_0.CommandPart3 = Room.VoidRoomGuid.ToString();
			}
			break;
		case Command.CommandType.CT_MOVECHAR:
			if (A_0.CommandPart3 != "<CurrentRoom>" && A_0.CommandPart3 != "<Void>")
			{
				try
				{
					new Guid(roomname2);
					break;
				}
				catch
				{
					try
					{
						A_0.CommandPart3 = GetRoomByName(ref roomname2).UniqueID.ToString();
						break;
					}
					catch
					{
						break;
					}
				}
			}
			if (A_0.CommandPart3 == "<CurrentRoom>")
			{
				A_0.CommandPart3 = Room.CurrentRoomGuid.ToString();
			}
			else if (A_0.CommandPart3 == "<Void>")
			{
				A_0.CommandPart3 = Room.VoidRoomGuid.ToString();
			}
			break;
		}
	}

	private string a(ref Action A_0, ref Game A_1)
	{
		string text = string.Empty;
		for (int i = 0; i < A_0.PassCommands.Count; i++)
		{
			Command tempcmd = A_0.PassCommands[i] as Command;
			Condition condition = A_0.PassCommands[i] as Condition;
			if (tempcmd != null)
			{
				text += Command.ValidateCommand(ref tempcmd, ref A_1);
			}
		}
		for (int j = 0; j < A_0.FailCommands.Count; j++)
		{
			Command tempcmd2 = A_0.FailCommands[j] as Command;
			Condition condition2 = A_0.FailCommands[j] as Condition;
			if (tempcmd2 != null)
			{
				text += Command.ValidateCommand(ref tempcmd2, ref A_1);
			}
		}
		for (int k = 0; k < A_0.Conditions.Count; k++)
		{
			bool flag = false;
			Condition condition3 = (Condition)A_0.Conditions[k];
			for (int l = 0; l < condition3.Checks.Count; l++)
			{
				Check tempcheck = (Check)condition3.Checks[l];
				string text2 = Check.ValidateCheck(ref tempcheck, ref A_1);
				if (text2.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
					}
					text += text2;
				}
			}
			for (int m = 0; m < condition3.PassCommands.Count; m++)
			{
				Command tempcmd3 = condition3.PassCommands[m] as Command;
				Condition condition4 = condition3.PassCommands[m] as Condition;
				if (tempcmd3 == null)
				{
					continue;
				}
				string text3 = Command.ValidateCommand(ref tempcmd3, ref A_1);
				if (text3.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
					}
					text += text3;
				}
			}
			for (int n = 0; n < condition3.FailCommands.Count; n++)
			{
				Command tempcmd4 = condition3.FailCommands[n] as Command;
				Condition condition5 = condition3.FailCommands[n] as Condition;
				if (tempcmd4 == null)
				{
					continue;
				}
				string text4 = Command.ValidateCommand(ref tempcmd4, ref A_1);
				if (text4.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in condition " + condition3.conditionname + "\r\n";
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
			Room room = (Room)RoomList[i];
			flag = false;
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Action A_ = (Action)room.Actions[j];
				Game A_2 = this;
				string text2 = a(ref A_, ref A_2);
				if (text2.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in room " + room.Name + " Actions\r\n";
					}
					text += text2;
				}
			}
			for (int k = 0; k < room.Exits.Count; k++)
			{
				if (room.Exits[k] is Exit { bActive: not false, DestinationRoom: null } exit)
				{
					exit.bActive = false;
				}
			}
		}
		for (int l = 0; l < ObjectList.Count; l++)
		{
			GameObject gameObject = (GameObject)ObjectList[l];
			flag = false;
			for (int m = 0; m < gameObject.Actions.Count; m++)
			{
				Action A_3 = (Action)gameObject.Actions[m];
				Game A_4 = this;
				string text3 = a(ref A_3, ref A_4);
				if (text3.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Object " + gameObject.name + " Actions\r\n";
					}
					text += text3;
				}
			}
		}
		flag = false;
		for (int n = 0; n < ThePlayer.Actions.Count; n++)
		{
			Action A_5 = (Action)ThePlayer.Actions[n];
			Game A_6 = this;
			string text4 = a(ref A_5, ref A_6);
			if (text4.Length > 0)
			{
				if (!flag)
				{
					flag = true;
					text += "Problem/s in Player Actions\r\n";
				}
				text += text4;
			}
		}
		for (int num = 0; num < CharacterList.Count; num++)
		{
			Character character = (Character)CharacterList[num];
			flag = false;
			for (int num2 = 0; num2 < character.Actions.Count; num2++)
			{
				Action A_7 = (Action)character.Actions[num2];
				Game A_8 = this;
				string text5 = a(ref A_7, ref A_8);
				if (text5.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Character " + character.Charname + " Actions\r\n";
					}
					text += text5;
				}
			}
		}
		for (int num3 = 0; num3 < TimerList.Count; num3++)
		{
			Timer timer = (Timer)TimerList[num3];
			flag = false;
			for (int num4 = 0; num4 < timer.Actions.Count; num4++)
			{
				Action A_9 = (Action)timer.Actions[num4];
				Game A_10 = this;
				string text6 = a(ref A_9, ref A_10);
				if (text6.Length > 0)
				{
					if (!flag)
					{
						flag = true;
						text = text + "Problem/s in Timer " + timer.Name + " Actions\r\n";
					}
					text += text6;
				}
			}
		}
		return text;
	}

	public void CorrectCommandAndConditions()
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
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
				Action A_ = (Action)room.Actions[j];
				a(ref A_);
			}
		}
		for (int k = 0; k < CharacterList.Count; k++)
		{
			Character character = (Character)CharacterList[k];
			bool flag = true;
			foreach (Action action3 in character.Actions)
			{
				if (action3.name == "<<On Character Enter>>" || action3.name == "<<On Character Leave>>")
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				Action action2 = new Action();
				character.Actions.Insert(0, action2);
				action2.name = "<<On Character Leave>>";
				action2 = new Action();
				character.Actions.Insert(0, action2);
				action2.name = "<<On Character Enter>>";
			}
		}
		for (int l = 0; l < ObjectList.Count; l++)
		{
			GameObject gameObject = (GameObject)ObjectList[l];
			if (gameObject.locationtype == GameObject.LocationType.LT_IN_OBJECT)
			{
				try
				{
					new Guid(gameObject.locationname);
				}
				catch
				{
					GameObject objectByNameOld = GetObjectByNameOld(gameObject.locationname);
					if (objectByNameOld != null)
					{
						gameObject.locationname = objectByNameOld.UniqueIdentifier.ToString();
					}
					else
					{
						gameObject.locationtype = GameObject.LocationType.LT_NULL;
					}
				}
			}
			for (int m = 0; m < gameObject.Actions.Count; m++)
			{
				Action A_2 = (Action)gameObject.Actions[m];
				a(ref A_2);
			}
		}
		for (int n = 0; n < ThePlayer.Actions.Count; n++)
		{
			Action A_3 = (Action)ThePlayer.Actions[n];
			a(ref A_3);
		}
		for (int num = 0; num < CharacterList.Count; num++)
		{
			Character character2 = (Character)CharacterList[num];
			for (int num2 = 0; num2 < character2.Actions.Count; num2++)
			{
				Action A_4 = (Action)character2.Actions[num2];
				a(ref A_4);
			}
		}
		for (int num3 = 0; num3 < TimerList.Count; num3++)
		{
			Timer timer = (Timer)TimerList[num3];
			for (int num4 = 0; num4 < timer.Actions.Count; num4++)
			{
				Action A_5 = (Action)timer.Actions[num4];
				a(ref A_5);
			}
		}
	}

	public void RefactorObject(string oldname, string newname)
	{
		for (int i = 0; i < RoomList.Count; i++)
		{
			Room room = (Room)RoomList[i];
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Action tempact = (Action)room.Actions[j];
				RefactorAction(ref tempact, oldname, newname);
			}
		}
		for (int k = 0; k < ObjectList.Count; k++)
		{
			GameObject gameObject = (GameObject)ObjectList[k];
			for (int l = 0; l < gameObject.Actions.Count; l++)
			{
				Action tempact2 = (Action)gameObject.Actions[l];
				RefactorAction(ref tempact2, oldname, newname);
			}
		}
		for (int m = 0; m < ThePlayer.Actions.Count; m++)
		{
			Action tempact3 = (Action)ThePlayer.Actions[m];
			RefactorAction(ref tempact3, oldname, newname);
		}
		for (int n = 0; n < CharacterList.Count; n++)
		{
			Character character = (Character)CharacterList[n];
			for (int num = 0; num < character.Actions.Count; num++)
			{
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
			Command A_ = tempact.PassCommands[i] as Command;
			Condition A_2 = tempact.PassCommands[i] as Condition;
			if (A_ != null)
			{
				a(ref A_, oldname, newname);
			}
			else
			{
				a(ref A_2, oldname, newname);
			}
		}
		for (int j = 0; j < tempact.FailCommands.Count; j++)
		{
			Command A_3 = tempact.FailCommands[j] as Command;
			Condition A_4 = tempact.FailCommands[j] as Condition;
			if (A_3 != null)
			{
				a(ref A_3, oldname, newname);
			}
			else
			{
				a(ref A_4, oldname, newname);
			}
		}
		for (int k = 0; k < tempact.Conditions.Count; k++)
		{
			Condition A_5 = (Condition)tempact.Conditions[k];
			a(ref A_5, oldname, newname);
		}
	}

	private void a(ref Condition A_0, string A_1, string A_2)
	{
		for (int i = 0; i < A_0.Checks.Count; i++)
		{
			Check A_3 = (Check)A_0.Checks[i];
			a(ref A_3, A_1, A_2);
		}
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command A_4 = A_0.PassCommands[j] as Command;
			Condition A_5 = A_0.PassCommands[j] as Condition;
			if (A_4 != null)
			{
				a(ref A_4, A_1, A_2);
			}
			else
			{
				a(ref A_5, A_1, A_2);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command A_6 = A_0.FailCommands[k] as Command;
			Condition A_7 = A_0.FailCommands[k] as Condition;
			if (A_6 != null)
			{
				a(ref A_6, A_1, A_2);
			}
			else
			{
				a(ref A_7, A_1, A_2);
			}
		}
	}

	private void a(ref Check A_0, string A_1, string A_2)
	{
		if (A_0.ConditionStep2 == A_1)
		{
			A_0.ConditionStep2 = A_2;
		}
		if (A_0.ConditionStep3 == A_1)
		{
			A_0.ConditionStep3 = A_2;
		}
		if (A_0.ConditionStep4 == A_1)
		{
			A_0.ConditionStep4 = A_2;
		}
	}

	private void a(ref Command A_0, string A_1, string A_2)
	{
		if (A_0.CommandPart2 == A_1)
		{
			A_0.CommandPart2 = A_2;
		}
		if (A_0.CommandPart3 == A_1)
		{
			A_0.CommandPart3 = A_2;
		}
		if (A_0.CommandPart4 == A_1)
		{
			A_0.CommandPart4 = A_2;
		}
		if (A_0.CommandText == A_1)
		{
			A_0.CommandText = A_2;
		}
	}

	private string a(ref GameVariable A_0)
	{
		bool flag = false;
		bool flag2 = true;
		switch (A_0.vartype)
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
			text = "[";
			for (int i = 0; i < A_0.VarArray.Count; i++)
			{
				num++;
				if (num > 0)
				{
					text += ",";
				}
				if (!(A_0.VarArray[i] is ArrayList arrayList))
				{
					text = ((!flag2) ? (text + A_0.VarArray[i].ToString()) : (text + "\"" + A_0.VarArray[i].ToString().Replace("\"", "\\\"") + "\""));
					continue;
				}
				text += "[";
				int num2 = -1;
				foreach (object item in arrayList)
				{
					num2++;
					if (num2 > 0)
					{
						text += ",";
					}
					text = ((!flag2) ? (text + item.ToString()) : (text + "\"" + item.ToString().Replace("\"", "\\\"") + "\""));
				}
				text += "]";
			}
			text += "];";
		}
		catch
		{
		}
		return text;
	}

	private void l(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 3);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		int num2 = A_0.IndexOf("(", A_1, StringComparison.OrdinalIgnoreCase);
		if (num2 < num && num2 != -1)
		{
			int num3 = A_0.IndexOf(")", A_1, StringComparison.OrdinalIgnoreCase);
			if (num3 == -1)
			{
				return;
			}
			string text = A_0.Substring(A_1, num2 - A_1).Trim();
			if (num3 - (num2 + 1) < 0)
			{
				return;
			}
			string text2 = A_0.Substring(num2 + 1, num3 - (num2 + 1)).Trim();
			int num4 = 0;
			try
			{
				num4 = Convert.ToInt32(PerformTextReplacements(text2, null));
			}
			catch
			{
				num4 = -1;
			}
			int num5 = A_0.IndexOf(")", num3 + 1, StringComparison.OrdinalIgnoreCase);
			int num6 = -1;
			if (num5 != -1)
			{
				try
				{
					string text3 = A_0.Substring(num3 + 2, num5 - (num3 + 2));
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
				return;
			}
			string text4 = string.Empty;
			if (text.IndexOf(":") > -1)
			{
				string text5 = text;
				text4 = text5.Substring(text5.IndexOf(":") + 1);
				text = text.Substring(0, text.IndexOf(":"));
			}
			GameVariable variableByName = GetVariableByName(text);
			if (variableByName == null)
			{
				return;
			}
			int num7 = 0;
			num7 = ((num5 <= -1) ? (num3 - A_1 + 2) : (num5 - A_1 + 2));
			A_0 = A_0.Remove(A_1, num7);
			if (num4 >= variableByName.VarArray.Count)
			{
				return;
			}
			string value = string.Empty;
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_NUMBERARRAY:
			case GameVariable.VarType.VT_STRINGARRAY:
				if (num6 > -1)
				{
					try
					{
						value = ((ArrayList)variableByName.VarArray[num4])[num6].ToString();
						if (flag)
						{
							((ArrayList)variableByName.VarArray[num4])[num6] = A_2;
						}
					}
					catch
					{
						value = "<invalid variable reference>";
					}
					break;
				}
				value = variableByName.VarArray[num4].ToString();
				if (flag)
				{
					if (variableByName.vartype == GameVariable.VarType.VT_NUMBERARRAY)
					{
						variableByName.VarArray[num4] = Convert.ToDouble(A_2);
					}
					else
					{
						variableByName.VarArray[num4] = A_2;
					}
				}
				break;
			case GameVariable.VarType.VT_DATETIMEARRAY:
				if (num6 > -1)
				{
					string? value2 = ((ArrayList)variableByName.VarArray[num4])[num6].ToString();
					if (flag)
					{
						((ArrayList)variableByName.VarArray[num4])[num6] = A_2;
					}
					DateTime dateTime = Convert.ToDateTime(value2);
					value = ((!(text4 != string.Empty)) ? dateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI) : dateTime.ToString(text4, myDTFI));
				}
				else if (text4 != string.Empty)
				{
					value = ((DateTime)variableByName.VarArray[num4]).ToString(text4, myDTFI);
					if (flag)
					{
						try
						{
							variableByName.VarArray[num4] = Convert.ToDateTime(A_2);
						}
						catch
						{
							variableByName.VarArray[num4] = "bad value";
						}
					}
				}
				else
				{
					value = ((DateTime)variableByName.VarArray[num4]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI);
				}
				break;
			}
			if (!flag)
			{
				A_0 = A_0.Insert(A_1, value);
			}
		}
		else
		{
			if (num <= -1)
			{
				return;
			}
			string text6 = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			string text7 = string.Empty;
			if (text6.IndexOf(":") > -1)
			{
				string text8 = text6;
				text7 = text8.Substring(text8.IndexOf(":") + 1);
				text6 = text6.Substring(0, text6.IndexOf(":"));
			}
			GameVariable variableByName2 = GetVariableByName(text6);
			if (variableByName2 == null)
			{
				return;
			}
			string text9 = string.Empty;
			switch (variableByName2.vartype)
			{
			case GameVariable.VarType.VT_NUMBER:
				text9 = variableByName2.dNumType.ToString();
				if (flag)
				{
					try
					{
						variableByName2.dNumType = Convert.ToDouble(A_2);
					}
					catch
					{
						variableByName2.dNumType = -1.0;
					}
				}
				break;
			case GameVariable.VarType.VT_STRING:
				text9 = variableByName2.sString;
				if (flag)
				{
					variableByName2.sString = A_2;
				}
				break;
			case GameVariable.VarType.VT_DATETIME:
				if (text7 != string.Empty)
				{
					text9 = variableByName2.dtDateTime.ToString(text7, myDTFI);
					if (flag)
					{
						try
						{
							variableByName2.dtDateTime = Convert.ToDateTime(A_2);
						}
						catch
						{
							variableByName2.dtDateTime = DateTime.Now;
						}
					}
					break;
				}
				text9 = variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI);
				if (flag)
				{
					try
					{
						variableByName2.dtDateTime = Convert.ToDateTime(A_2);
					}
					catch
					{
						variableByName2.dtDateTime = DateTime.Now;
					}
				}
				break;
			}
			if (flag)
			{
				text9 = PerformTextReplacements(text9, null);
			}
			A_0 = A_0.Insert(A_1, text9);
		}
	}

	private void a(ref string A_0, int A_1, string A_2, ref object A_3)
	{
		if (A_1 >= 0 && A_2.Contains("[PLAYERNAME]"))
		{
			A_0 = A_0.Remove(A_1, 12);
			A_0 = A_0.Insert(A_1, ThePlayer.Name);
			A_1 = A_0.IndexOf("[playername", 0, StringComparison.OrdinalIgnoreCase);
		}
		if (A_1 >= 0 && A_2.Contains("[INPUTDATA]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			A_0 = A_0.Insert(A_1, AdditionalData);
			A_1 = A_0.IndexOf("[inputdata]", 0, StringComparison.OrdinalIgnoreCase);
		}
		if (A_1 >= 0 && A_2.Contains("[MAXCARRY]"))
		{
			A_0 = A_0.Remove(A_1, 10);
			A_0 = A_0.Insert(A_1, ThePlayer.dWeightLimit.ToString());
			A_1 = A_0.IndexOf("[maxcarry]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[TURNS]"))
		{
			A_0 = A_0.Remove(A_1, 7);
			A_0 = A_0.Insert(A_1, TurnCount.ToString());
			A_1 = A_0.IndexOf("[turns]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[CURRENTCARRY]"))
		{
			A_0 = A_0.Remove(A_1, 14);
			double num = 0.0;
			foreach (GameObject @object in ObjectList)
			{
				if (@object.locationtype == GameObject.LocationType.LT_PLAYER)
				{
					num += GetItemWeight(@object.UniqueIdentifier);
				}
			}
			A_0 = A_0.Insert(A_1, num.ToString());
			A_1 = A_0.IndexOf("[currentcarry]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[MAN/WOMAN]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "woman");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "man");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "thing");
				break;
			}
			A_1 = A_0.IndexOf("[man/woman]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[MALE/FEMALE]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "female");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "male");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "other");
				break;
			}
			A_1 = A_0.IndexOf("[male/female]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[BOY/GIRL]"))
		{
			A_0 = A_0.Remove(A_1, 10);
			switch (ThePlayer.PlayerGender)
			{
			case Player.Gender.Female:
				A_0 = A_0.Insert(A_1, "girl");
				break;
			case Player.Gender.Male:
				A_0 = A_0.Insert(A_1, "boy");
				break;
			case Player.Gender.Other:
				A_0 = A_0.Insert(A_1, "thing");
				break;
			}
			A_1 = A_0.IndexOf("[boy/girl]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[LEN("))
		{
			A_1 = A_2.IndexOf("[LEN(", 0, StringComparison.OrdinalIgnoreCase);
			GameVariable gameVariable = null;
			int num2 = A_0.IndexOf(")]", A_1);
			if (num2 >= 0)
			{
				A_1 += 5;
				string varname = A_0.Substring(A_1, num2 - A_1);
				gameVariable = GetVariableByName(varname);
			}
			if (gameVariable != null)
			{
				A_0 = A_0.Remove(A_1 - 5, num2 + 2 - (A_1 - 5));
				switch (gameVariable.vartype)
				{
				case GameVariable.VarType.VT_STRING:
					A_0 = A_0.Insert(A_1 - 5, gameVariable.sString.Length.ToString());
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
				case GameVariable.VarType.VT_STRINGARRAY:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					A_0 = A_0.Insert(A_1 - 5, gameVariable.VarArray.Count.ToString());
					break;
				}
			}
			else
			{
				A_0 = A_0.Remove(A_1, 5);
			}
			A_1 = A_0.IndexOf("[len(", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ROOM.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is Room room)
			{
				A_0 = A_0.Insert(A_1, room.Name);
			}
			else if (ThePlayer.CurrentRoom != null)
			{
				A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.Name);
			}
			A_1 = A_0.IndexOf("[room.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ROOM.ID]"))
		{
			A_0 = A_0.Remove(A_1, 9);
			if (A_3 is Room room2)
			{
				A_0 = A_0.Insert(A_1, room2.UniqueID.ToString());
			}
			else if (ThePlayer.CurrentRoom != null)
			{
				A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.UniqueID.ToString());
			}
			A_1 = A_0.IndexOf("[room.id]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.ACTIVE]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			if (A_3 is Exit exit)
			{
				string value = "N";
				if (exit.bActive)
				{
					value = "Y";
				}
				A_0 = A_0.Insert(A_1, value);
			}
			A_1 = A_0.IndexOf("[exit.active]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DIRECTION]"))
		{
			A_0 = A_0.Remove(A_1, 16);
			if (A_3 is Exit exit2)
			{
				A_0 = A_0.Insert(A_1, exit2.Direction.ToString());
			}
			A_1 = A_0.IndexOf("[exit.direction]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DESTNAME]"))
		{
			A_0 = A_0.Remove(A_1, 15);
			if (A_3 is Exit exit3)
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
				A_0 = A_0.Insert(A_1, empty);
			}
			A_1 = A_0.IndexOf("[Exit.DestName]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[EXIT.DESTID]"))
		{
			A_0 = A_0.Remove(A_1, 13);
			if (A_3 is Exit exit4)
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
				A_0 = A_0.Insert(A_1, empty2);
			}
			A_1 = A_0.IndexOf("[Exit.DestID]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ITEM.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is GameObject gameObject2)
			{
				A_0 = A_0.Insert(A_1, gameObject2.name);
			}
			A_1 = A_0.IndexOf("[item.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[ITEM.ID]"))
		{
			A_0 = A_0.Remove(A_1, 9);
			if (A_3 is GameObject gameObject3)
			{
				A_0 = A_0.Insert(A_1, gameObject3.UniqueIdentifier.ToString());
			}
			A_1 = A_0.IndexOf("[item.id]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else if (A_1 >= 0 && A_2.Contains("[CHAR.NAME]"))
		{
			A_0 = A_0.Remove(A_1, 11);
			if (A_3 is Character character)
			{
				A_0 = A_0.Insert(A_1, character.Charname);
			}
			A_1 = A_0.IndexOf("[char.name]", 0, StringComparison.OrdinalIgnoreCase);
		}
		else
		{
			if (A_1 < 0 || !A_2.Contains("[A/AN]"))
			{
				return;
			}
			A_0 = A_0.Remove(A_1, 6);
			string text = A_0.Substring(A_1).Trim();
			if (text.Length >= 1)
			{
				if (string.Compare(text[0].ToString(), "a", ignoreCase: true) == 0 || string.Compare(text[0].ToString(), "e", ignoreCase: true) == 0 || string.Compare(text[0].ToString(), "i", ignoreCase: true) == 0 || string.Compare(text[0].ToString(), "o", ignoreCase: true) == 0 || string.Compare(text[0].ToString(), "u", ignoreCase: true) == 0)
				{
					A_0 = A_0.Insert(A_1, "an");
				}
				else
				{
					A_0 = A_0.Insert(A_1, "a");
				}
			}
			A_1 = A_0.IndexOf("[a/an]", 0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private void a(ref string A_0, int A_1)
	{
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 5);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string varname = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			GameVariable A_2 = GetVariableByName(varname);
			if (A_2 != null)
			{
				string text = a(ref A_2);
				text = text.Replace("\r", "\\r");
				text = text.Replace("\n", "\\n");
				A_0 = A_0.Insert(A_1, text);
			}
		}
		A_1 = A_0.LastIndexOf("[jsa:", StringComparison.OrdinalIgnoreCase);
	}

	private void k(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Room room = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf("(") > -1)
				{
					string text2 = array[0].Substring(0, array[0].IndexOf("("));
					room = GetRoomByID(new Guid(text2));
				}
				else
				{
					room = GetRoomByName(ref array[0]);
				}
				if (room != null)
				{
					foreach (CustomProperty customProperty in room.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[rp:", StringComparison.OrdinalIgnoreCase);
	}

	private void j(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			GameObject gameObject = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				if (array[0].IndexOf("(") > -1)
				{
					string objectname = array[0].Substring(0, array[0].IndexOf("("));
					gameObject = GetObjectByName(objectname);
				}
				else
				{
					gameObject = GetObjectByNameOld(array[0]);
				}
				if (gameObject != null)
				{
					foreach (CustomProperty customProperty in gameObject.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ip:", StringComparison.OrdinalIgnoreCase);
	}

	private void i(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string strB = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			foreach (CustomProperty customProperty in ThePlayer.CustomProperties)
			{
				if (string.Compare(customProperty.Name, strB, ignoreCase: true) == 0)
				{
					A_0 = A_0.Insert(A_1, customProperty.Value);
					if (flag)
					{
						customProperty.Value = A_2;
					}
					break;
				}
			}
		}
		A_1 = A_0.LastIndexOf("[pp:", StringComparison.OrdinalIgnoreCase);
	}

	private void h(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Character character = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				character = GetCharacterByName(array[0]);
				if (character != null)
				{
					foreach (CustomProperty customProperty in character.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[cp:", StringComparison.OrdinalIgnoreCase);
	}

	private void g(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			GameVariable gameVariable = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				gameVariable = GetVariableByName(array[0]);
				if (gameVariable != null)
				{
					foreach (CustomProperty customProperty in gameVariable.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[vp:", StringComparison.OrdinalIgnoreCase);
	}

	private void f(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer != null)
				{
					foreach (CustomProperty customProperty in timer.CustomProperties)
					{
						if (string.Compare(customProperty.Name, array[1].Trim(), ignoreCase: true) == 0)
						{
							A_0 = A_0.Insert(A_1, customProperty.Value);
							if (flag)
							{
								customProperty.Value = A_2;
							}
							break;
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[tp:", StringComparison.OrdinalIgnoreCase);
	}

	private void e(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Timer timer = null;
			if (array.Length > 1)
			{
				array[0] = array[0].Trim();
				timer = GetTimerByName(array[0]);
				if (timer != null)
				{
					if (array[1].ToUpper() == "ACTIVE")
					{
						A_0 = A_0.Insert(A_1, timer.Active.ToString());
						if (flag)
						{
							try
							{
								timer.Active = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, timer.Name.ToString());
						if (flag)
						{
							timer.Name = A_2;
						}
					}
					else if (array[1].ToUpper() == "TIMERTYPE")
					{
						A_0 = A_0.Insert(A_1, timer.TType.ToString());
						if (flag)
						{
							try
							{
								timer.TType = (Timer.TimerType)Enum.Parse(typeof(Timer.TimerType), A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LENGTH")
					{
						A_0 = A_0.Insert(A_1, timer.Length.ToString());
						if (flag)
						{
							try
							{
								timer.Length = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "TURNNUMBER")
					{
						A_0 = A_0.Insert(A_1, timer.TurnNumber.ToString());
						if (flag)
						{
							try
							{
								timer.TurnNumber = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "TIMERSECONDS")
					{
						A_0 = A_0.Insert(A_1, timer.TimerSeconds.ToString());
						if (flag)
						{
							try
							{
								timer.TimerSeconds = Convert.ToInt32(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LIVETIMER")
					{
						A_0 = A_0.Insert(A_1, timer.LiveTimer.ToString());
						if (flag)
						{
							try
							{
								timer.LiveTimer = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = timer.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ta:", StringComparison.OrdinalIgnoreCase);
	}

	private void d(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Room room = null;
			if (array.Length > 1)
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
				if (room == null)
				{
					room = GetRoomByName(ref array[0]);
				}
				if (room != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, room.Name.ToString());
						if (flag)
						{
							room.Name = A_2;
						}
					}
					else if (array[1].ToUpper() == "DESCRIPTION")
					{
						A_0 = A_0.Insert(A_1, room.Description.ToString());
						if (flag)
						{
							room.Description = A_2;
						}
					}
					else if (array[1].ToUpper() == "SDESC")
					{
						A_0 = A_0.Insert(A_1, room.SDesc.ToString());
						if (flag)
						{
							room.SDesc = A_2;
						}
					}
					else if (array[1].ToUpper() == "ROOMPIC")
					{
						A_0 = A_0.Insert(A_1, room.RoomPic.ToString());
						if (flag)
						{
							room.RoomPic = A_2;
						}
					}
					else if (array[1].ToUpper() == "ENTEREDFIRSTTIME")
					{
						A_0 = A_0.Insert(A_1, room.bEnterFirstTime.ToString());
						if (flag)
						{
							try
							{
								room.bEnterFirstTime = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LEFTFIRSTTIME")
					{
						A_0 = A_0.Insert(A_1, room.bLeaveFirstTime.ToString());
						if (flag)
						{
							try
							{
								room.bLeaveFirstTime = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ID")
					{
						A_0 = A_0.Insert(A_1, room.UniqueID.ToString());
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = room.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
					else if (array[1].ToUpper() == "EXIT")
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
						if (exit != null)
						{
							if (array[3].ToUpper() == "ACTIVE")
							{
								A_0 = A_0.Insert(A_1, exit.bActive.ToString());
								if (flag)
								{
									try
									{
										exit.bActive = Convert.ToBoolean(A_2);
									}
									catch
									{
									}
								}
							}
							else if (array[3].ToUpper() == "DESTINATIONID")
							{
								A_0 = A_0.Insert(A_1, exit.DestinationRoom.ToString());
								if (flag)
								{
									exit.DestinationRoom = A_2;
								}
							}
							else if (array[3].ToUpper() == "DESTINATIONNAME")
							{
								try
								{
									A_0 = A_0.Insert(A_1, GetRoomByID(new Guid(exit.DestinationRoom)).Name);
								}
								catch
								{
									A_0 = A_0.Insert(A_1, exit.DestinationRoom.ToString());
								}
								if (flag)
								{
									try
									{
										exit.DestinationRoom = GetRoomByName(ref A_2).UniqueID.ToString();
									}
									catch
									{
									}
								}
							}
							else if (array[3].ToUpper() == "PORTAL")
							{
								A_0 = A_0.Insert(A_1, exit.PortalObjectName.ToString());
								if (flag)
								{
									exit.PortalObjectName = A_2;
								}
							}
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ra:", StringComparison.OrdinalIgnoreCase);
	}

	private void c(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
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
				if (gameObject == null)
				{
					gameObject = GetObjectByNameOld(array[0]);
				}
				if (gameObject != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, gameObject.name.ToString());
						if (flag)
						{
							gameObject.name = A_2;
						}
					}
					else if (array[1].ToUpper() == "NAMEOVERRIDE")
					{
						A_0 = A_0.Insert(A_1, gameObject.sdesc.ToString());
						if (flag)
						{
							gameObject.sdesc = A_2;
						}
					}
					else if (array[1].ToUpper() == "CLOTHINGLAYERS")
					{
						string text2 = "[";
						int num2 = 0;
						foreach (string layeredZoneLevel in gameObject.LayeredZoneLevels)
						{
							if (num2 > 0)
							{
								text2 += ",";
							}
							num2++;
							text2 += "[";
							string[] array2 = layeredZoneLevel.Split(new string[1] { ":" }, StringSplitOptions.None);
							if (array2.Length != 0)
							{
								for (int i = 0; i < array2.Length; i++)
								{
									if (i > 0)
									{
										text2 += ",";
									}
									text2 = text2 + "\"" + array2[i] + "\"";
								}
							}
							text2 += "]";
						}
						text2 += "]";
						A_0 = A_0.Insert(A_1, text2);
					}
					else if (array[1].ToUpper() == "ID")
					{
						A_0 = A_0.Insert(A_1, gameObject.UniqueIdentifier.ToString());
					}
					else if (array[1].ToUpper() == "PREPOSITION")
					{
						A_0 = A_0.Insert(A_1, gameObject.preposition.ToString());
						if (flag)
						{
							gameObject.preposition = A_2;
						}
					}
					else if (array[1].ToUpper() == "DESCRIPTION")
					{
						A_0 = A_0.Insert(A_1, gameObject.description.ToString());
						if (flag)
						{
							gameObject.description = A_2;
						}
					}
					else if (array[1].ToUpper() == "IMPORTANT")
					{
						A_0 = A_0.Insert(A_1, gameObject.bImportant.ToString());
						if (flag)
						{
							try
							{
								gameObject.bImportant = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CARRYABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bCarryable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bCarryable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WEARABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bWearable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bWearable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WORN")
					{
						A_0 = A_0.Insert(A_1, gameObject.bWorn.ToString());
						if (flag)
						{
							try
							{
								gameObject.bWorn = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CONTAINER")
					{
						A_0 = A_0.Insert(A_1, gameObject.bContainer.ToString());
						if (flag)
						{
							try
							{
								gameObject.bContainer = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "OPENABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bOpenable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bOpenable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "OPEN")
					{
						A_0 = A_0.Insert(A_1, gameObject.bOpen.ToString());
						if (flag)
						{
							try
							{
								gameObject.bOpen = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LOCKABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bLockable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bLockable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "LOCKED")
					{
						A_0 = A_0.Insert(A_1, gameObject.bLocked.ToString());
						if (flag)
						{
							try
							{
								gameObject.bLocked = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "VISIBLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bVisible.ToString());
						if (flag)
						{
							try
							{
								gameObject.bVisible = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ENTERABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bEnterable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bEnterable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "READABLE")
					{
						A_0 = A_0.Insert(A_1, gameObject.bReadable.ToString());
						if (flag)
						{
							try
							{
								gameObject.bReadable = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "WEIGHT")
					{
						A_0 = A_0.Insert(A_1, gameObject.dWeight.ToString());
						if (flag)
						{
							try
							{
								gameObject.dWeight = Convert.ToDouble(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = gameObject.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ia:", StringComparison.OrdinalIgnoreCase);
	}

	private void b(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			Character character = null;
			if (array.Length > 1)
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
				if (character != null)
				{
					if (array[1].ToUpper() == "NAME")
					{
						A_0 = A_0.Insert(A_1, character.Charname.ToString());
						if (flag)
						{
							character.Charname = A_2;
						}
					}
					else if (array[1].ToUpper() == "OVERRIDENAME")
					{
						A_0 = A_0.Insert(A_1, character.CharnameOverride.ToString());
						if (flag)
						{
							character.CharnameOverride = A_2;
						}
					}
					else if (array[1].ToUpper() == "GENDER")
					{
						A_0 = A_0.Insert(A_1, character.CharGender.ToString());
						if (flag)
						{
							try
							{
								character.CharGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "CURRENTROOM")
					{
						A_0 = A_0.Insert(A_1, character.CurrentRoom.ToString());
						if (flag)
						{
							character.CurrentRoom = A_2;
						}
					}
					else if (array[1].ToUpper() == "ALLOWINVINTERACTION")
					{
						A_0 = A_0.Insert(A_1, character.bAllowInventoryInteraction.ToString());
						if (flag)
						{
							try
							{
								character.bAllowInventoryInteraction = Convert.ToBoolean(A_2);
							}
							catch
							{
							}
						}
					}
					else if (array[1].ToUpper() == "ACTION")
					{
						Action tempact = character.GetActionByName(array[2]);
						if (tempact != null)
						{
							A_0 = GetActionData(ref tempact, array[3], ref A_0, A_1, A_2);
						}
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[ca:", StringComparison.OrdinalIgnoreCase);
	}

	private void a(ref string A_0, int A_1, string A_2 = "")
	{
		bool flag = false;
		if (A_2 != "")
		{
			flag = true;
		}
		if (A_2 == " ")
		{
			A_2 = "";
		}
		if (A_1 < 0)
		{
			return;
		}
		A_0 = A_0.Remove(A_1, 4);
		int num = A_0.IndexOf("]", A_1, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			string text = A_0.Substring(A_1, num - A_1).Trim();
			A_0 = A_0.Remove(A_1, num - A_1 + 1);
			_ = string.Empty;
			string[] array = text.Split(new string[1] { ":" }, StringSplitOptions.None);
			if (array.Length >= 1 && ThePlayer != null)
			{
				if (array[0].ToUpper() == "NAME")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.Name.ToString());
					if (flag)
					{
						ThePlayer.Name = A_2;
					}
				}
				else if (array[0].ToUpper() == "GENDER")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.PlayerGender.ToString());
					if (flag)
					{
						try
						{
							ThePlayer.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), A_2);
						}
						catch
						{
						}
					}
				}
				else if (array[0].ToUpper() == "CURROOM")
				{
					if (ThePlayer.CurrentRoom != null)
					{
						A_0 = A_0.Insert(A_1, ThePlayer.CurrentRoom.ToString());
					}
					else
					{
						A_0 = A_0.Insert(A_1, "<Null>");
					}
					if (flag)
					{
						try
						{
							ThePlayer.CurrentRoom = GetRoomByName(ref A_2);
						}
						catch
						{
						}
					}
				}
				else if (array[0].ToUpper() == "CURPORTRAIT")
				{
					A_0 = A_0.Insert(A_1, ThePlayer.PlayerPortrait.ToString());
					if (flag)
					{
						ThePlayer.PlayerPortrait = A_2;
					}
				}
				else if (array[0].ToUpper() == "ACTION")
				{
					Action tempact = ThePlayer.GetActionByName(array[1]);
					if (tempact != null)
					{
						A_0 = GetActionData(ref tempact, array[2], ref A_0, A_1, A_2);
					}
				}
			}
		}
		A_1 = A_0.LastIndexOf("[pa:", StringComparison.OrdinalIgnoreCase);
	}

	public string GetActionData(ref Action tempact, string part3, ref string text, int tempindex, string replacementvalue = "")
	{
		bool flag = false;
		if (replacementvalue != "")
		{
			flag = true;
		}
		if (part3.ToUpper() == "ACTIVE")
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
		else if (part3.ToUpper() == "OVERRIDENAME")
		{
			text = text.Insert(tempindex, tempact.overridename.ToString());
			if (flag)
			{
				tempact.overridename = replacementvalue;
			}
		}
		else if (part3.ToUpper() == "ACTIONPARENT")
		{
			text = text.Insert(tempindex, tempact.actionparent.ToString());
			if (flag)
			{
				tempact.actionparent = replacementvalue;
			}
		}
		else if (part3.ToUpper() == "INPUTTYPE")
		{
			text = text.Insert(tempindex, tempact.InputType.ToString());
			if (flag)
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
		return text;
	}

	public string PerformTextReplacements(string text, object loopobject, string newvalue = "")
	{
		bool flag = true;
		while (flag)
		{
			flag = false;
			int num = text.Length;
			int num2 = text.LastIndexOf("[", num, StringComparison.OrdinalIgnoreCase);
			List<int> list = new List<int>();
			while (num2 >= 0)
			{
				int num3 = text.IndexOf("]", num2);
				if (num3 != -1)
				{
					string text2 = text.Substring(num2, num3 - num2 + 1).ToUpper();
					int num4 = text2.IndexOf(":", 0);
					if (num4 != -1)
					{
						flag = true;
						switch (text2.Substring(0, num4 + 1).ToUpper())
						{
						case "[V:":
							l(ref text, num2, newvalue);
							break;
						case "[JSA:":
							a(ref text, num2);
							break;
						case "[RP:":
							k(ref text, num2, newvalue);
							break;
						case "[IP:":
							j(ref text, num2, newvalue);
							break;
						case "[PP:":
							i(ref text, num2, newvalue);
							break;
						case "[CP:":
							h(ref text, num2, newvalue);
							break;
						case "[VP:":
							g(ref text, num2, newvalue);
							break;
						case "[TP:":
							f(ref text, num2, newvalue);
							break;
						case "[IA:":
							c(ref text, num2, newvalue);
							break;
						case "[TA:":
							e(ref text, num2, newvalue);
							break;
						case "[CA:":
							b(ref text, num2, newvalue);
							break;
						case "[RA:":
							d(ref text, num2, newvalue);
							break;
						case "[PA:":
							a(ref text, num2, newvalue);
							break;
						default:
							flag = false;
							break;
						}
					}
					else if (text2.Contains("[/B]") || text2.Contains("[/I]") || text2.Contains("[/U]") || text2.Contains("[/F]") || text2.Contains("[/C]") || text2.Contains("[/MIDDLE]") || text2.Contains("[B]") || text2.Contains("[I]") || text2.Contains("[U]") || text2.Contains("[F ") || text2.Contains("[C ") || text2.Contains("[MIDDLE]"))
					{
						num = num2 - 1;
					}
					else
					{
						a(ref text, num2, text2, ref loopobject);
					}
				}
				if (num > text.Length)
				{
					if (num2 == 0)
					{
						num2 = -1;
						continue;
					}
					list.Add(num2);
					num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					if (list.Contains(num2))
					{
						num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					}
				}
				else if (num == -1)
				{
					num2 = -1;
				}
				else if (num2 == 0)
				{
					num2 = -1;
				}
				else
				{
					list.Add(num2);
					num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					if (list.Contains(num2))
					{
						num2 = text.LastIndexOf("[", num2 - 1, StringComparison.OrdinalIgnoreCase);
					}
				}
			}
		}
		return text;
	}

	public void AssignHotKey(int index, object data)
	{
		if (HotKeys == null)
		{
			HotKeys = new ArrayList();
		}
		if (HotKeys.Count != 10)
		{
			HotKeys.Clear();
			for (int i = 0; i < 10; i++)
			{
				HotKeys.Add(null);
			}
		}
		HotKeys[index] = data;
	}

	public bool SetClipboardData(int index)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		bool result = false;
		if (HotKeys.Count != 10)
		{
			return false;
		}
		object? obj = HotKeys[index];
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
		else if (action != null)
		{
			Clipboard.SetDataObject((object)new DataObject(ActionControl.ActionFormat.Name, (object)action));
			result = true;
		}
		return result;
	}

	public static void RestoreDefaults(ref ArrayList QuickCommands)
	{
		QuickCommands.Clear();
		QuickMenuItem quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = true;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		Action action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		Command command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Char Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
		command.CommandPart2 = "[Self]";
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Char Image";
		command.cmdtype = Command.CommandType.CT_CHAR_DISPLAYPORT;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Item Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = true;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Player Description";
		command.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = true;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Room Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
		command.CommandPart2 = "[Self]";
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Room Pic";
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bOpenable = true;
		quickMenuItem.Name = "Open/Close";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Open";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Open";
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Open";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now open.";
		action.PassCommands.Add(command);
		Condition condition = new Condition("Check For Open");
		action.Conditions.Add(condition);
		Check obj = condition.Checks[0] as Check;
		obj.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj.ConditionStep2 = "[Self]";
		obj.ConditionStep3 = "Closed";
		command = new Command();
		command.CommandName = "Display already open";
		command.CommandText = "[Self] is already open.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Close";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Closed";
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Closed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now closed.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Closed");
		action.Conditions.Add(condition);
		Check obj2 = condition.Checks[0] as Check;
		obj2.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj2.ConditionStep2 = "[Self]";
		obj2.ConditionStep3 = "Open";
		command = new Command();
		command.CommandName = "Display already closed";
		command.CommandText = "[Self] is already closed.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bWearable = true;
		quickMenuItem.bCarryable = true;
		quickMenuItem.Name = "Wear/Remove";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Wear";
		action.bActive = true;
		condition = new Condition("Item must be in inventory");
		action.Conditions.Add(condition);
		Check obj3 = condition.Checks[0] as Check;
		obj3.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		obj3.ConditionStep2 = "[Self]";
		obj3.ConditionStep3 = "Open";
		command = new Command();
		command.CommandName = "Display not held";
		command.CommandText = "You must get [Self] first.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Worn";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Worn";
		condition = new Condition("Was the item worn?");
		action.PassCommands.Add(condition);
		Check obj4 = condition.Checks[0] as Check;
		obj4.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj4.ConditionStep2 = "[Self]";
		obj4.ConditionStep3 = "Worn";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Inactive";
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Remove";
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Removed";
		condition = new Condition("Item must be currently worn");
		action.Conditions.Add(condition);
		Check obj5 = condition.Checks[0] as Check;
		obj5.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj5.ConditionStep2 = "[Self]";
		obj5.ConditionStep3 = "Worn";
		command = new Command();
		command.CommandName = "Display not worn";
		command.CommandText = "You are not wearing [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		condition = new Condition("Was the item removed?");
		action.PassCommands.Add(condition);
		Check obj6 = condition.Checks[0] as Check;
		obj6.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj6.ConditionStep2 = "[Self]";
		obj6.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bLockable = true;
		quickMenuItem.Name = "Lock/Unlock";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Lock";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Locked";
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Locked";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now locked.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Locked");
		action.Conditions.Add(condition);
		Check obj7 = condition.Checks[0] as Check;
		obj7.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj7.ConditionStep2 = "[Self]";
		obj7.ConditionStep3 = "Unlocked";
		command = new Command();
		command.CommandName = "Display already locked";
		command.CommandText = "[Self] is already locked.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Unlock";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Unlocked";
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Unlocked";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now unlocked.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Unlocked");
		action.Conditions.Add(condition);
		Check obj8 = condition.Checks[0] as Check;
		obj8.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj8.ConditionStep2 = "[Self]";
		obj8.ConditionStep3 = "Locked";
		command = new Command();
		command.CommandName = "Display already unlocked";
		command.CommandText = "[Self] is already unlocked.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Take/Drop";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Take";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You pick up [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		action.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Drop";
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Drop Item";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "00000000-0000-0000-0000-000000000001";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You dropped [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Inactive";
		action.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		quickMenuItem.bWearable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Take/Drop/Wear/Remove";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Take";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You pick up [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		action.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Drop";
		action.bActive = false;
		condition = new Condition("Is Item Worn?");
		action.PassCommands.Add(condition);
		Check obj9 = condition.Checks[0] as Check;
		obj9.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj9.ConditionStep2 = "[Self]";
		obj9.ConditionStep3 = "Worn";
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		Condition condition2 = new Condition("Did we remove it successfully?");
		condition.PassCommands.Add(condition2);
		Check obj10 = condition2.Checks[0] as Check;
		obj10.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj10.ConditionStep2 = "[Self]";
		obj10.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition2.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition2.PassCommands.Add(command);
		condition = new Condition("Is Item Removed?");
		action.PassCommands.Add(condition);
		Check obj11 = condition.Checks[0] as Check;
		obj11.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj11.ConditionStep2 = "[Self]";
		obj11.ConditionStep3 = "Removed";
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = "Drop Item";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "00000000-0000-0000-0000-000000000001";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Inactive";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You dropped [Self].";
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Wear";
		action.bActive = true;
		condition = new Condition("Is Item In Inventory?");
		action.PassCommands.Add(condition);
		Check obj12 = condition.Checks[0] as Check;
		obj12.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		obj12.ConditionStep2 = "[Self]";
		command = new Command();
		command.CommandName = "Display not held";
		command.CommandText = "You pick up [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		condition.FailCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		condition.FailCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Worn";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = "[Self]";
		condition = new Condition("Did we wear the item?");
		action.PassCommands.Add(condition);
		Check obj13 = condition.Checks[0] as Check;
		obj13.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj13.ConditionStep2 = "[Self]";
		obj13.ConditionStep3 = "Worn";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Inactive";
		condition.PassCommands.Add(command);
		action = new Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Remove";
		action.bActive = false;
		condition = new Condition("Item must be currently worn");
		action.Conditions.Add(condition);
		Check obj14 = condition.Checks[0] as Check;
		obj14.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj14.ConditionStep2 = "[Self]";
		obj14.ConditionStep3 = "Worn";
		command = new Command();
		command.CommandName = "Display not worn";
		command.CommandText = "You are not wearing [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		condition = new Condition("Was the item removed?");
		action.PassCommands.Add(condition);
		Check obj15 = condition.Checks[0] as Check;
		obj15.CondType = Condition.ConditionType.CT_Item_State_Check;
		obj15.ConditionStep2 = "[Self]";
		obj15.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition.PassCommands.Add(command);
	}

	public double GetItemWeight(Guid objid)
	{
		double num = 0.0;
		GameObject objectByName = GetObjectByName(objid.ToString());
		if (objectByName != null)
		{
			num += objectByName.dWeight;
			if (objectByName.bContainer)
			{
				foreach (GameObject @object in ObjectList)
				{
					if (@object.locationtype == GameObject.LocationType.LT_IN_OBJECT && @object.locationname == objectByName.UniqueIdentifier.ToString())
					{
						num += GetItemWeight(@object.UniqueIdentifier);
					}
				}
			}
		}
		return num;
	}

	public void ValidateText(string text)
	{
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		string text2 = string.Empty;
		text = PerformTextReplacements(text, null);
		bool flag = false;
		text.LastIndexOf("[v", StringComparison.OrdinalIgnoreCase);
		for (int num = text.LastIndexOf("[v:", StringComparison.OrdinalIgnoreCase); num >= 0; num = text.LastIndexOf("[v:", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Remove(num, 3);
			int num2 = text.IndexOf("]", num, StringComparison.OrdinalIgnoreCase);
			int num3 = text.IndexOf("(", num, StringComparison.OrdinalIgnoreCase);
			if (num3 < num2 && num3 != -1)
			{
				int num4 = text.IndexOf(")", num, StringComparison.OrdinalIgnoreCase);
				if (num4 != -1)
				{
					string text3 = text.Substring(num, num3 - num).Trim();
					if (num4 - (num3 + 1) < 0)
					{
						text2 += "Missing a closing ] in the variable reference.";
						flag = true;
						break;
					}
					string text4 = text.Substring(num3 + 1, num4 - (num3 + 1)).Trim();
					int num5 = 0;
					try
					{
						num5 = Convert.ToInt32(text4);
					}
					catch
					{
						text2 = text2 + "An array index is not valid. Array index evaluated to " + text4 + ".";
						flag = true;
						num5 = -1;
					}
					int num6 = text.IndexOf(")", num4 + 1, StringComparison.OrdinalIgnoreCase);
					int num7 = -1;
					if (num6 != -1)
					{
						string text5 = string.Empty;
						try
						{
							text5 = text.Substring(num4 + 2, num6 - (num4 + 2));
							num7 = Convert.ToInt32(text5);
						}
						catch
						{
							text2 = text2 + "An array index is not valid. Array index in the multi dimensional array evaluated to " + text5 + ".";
							flag = true;
							num5 = -1;
						}
					}
					if (num5 > -1)
					{
						string text6 = string.Empty;
						if (text3.IndexOf(":") > -1)
						{
							string text7 = text3;
							text6 = text7.Substring(text7.IndexOf(":") + 1);
							text3 = text3.Substring(0, text3.IndexOf(":"));
						}
						GameVariable variableByName = GetVariableByName(text3);
						if (variableByName == null)
						{
							text2 = text2 + "The variable named " + text3 + " could not be located.";
							flag = true;
						}
						if (variableByName != null)
						{
							int num8 = 0;
							num8 = ((num6 <= -1) ? (num4 - num + 2) : (num6 - num + 2));
							text = text.Remove(num, num8);
							if (num5 >= variableByName.VarArray.Count)
							{
								text2 = text2 + "The array index of " + num5 + " exceeded the limits of the array " + variableByName.varname + ".";
								flag = true;
							}
							if (num5 < variableByName.VarArray.Count)
							{
								string value = string.Empty;
								switch (variableByName.vartype)
								{
								case GameVariable.VarType.VT_NUMBERARRAY:
								case GameVariable.VarType.VT_STRINGARRAY:
									if (num7 > -1)
									{
										try
										{
											value = ((ArrayList)variableByName.VarArray[num5])[num7].ToString();
										}
										catch
										{
											value = "<invalid variable reference>";
										}
									}
									else
									{
										value = variableByName.VarArray[num5].ToString();
									}
									break;
								case GameVariable.VarType.VT_DATETIMEARRAY:
									if (num7 > -1)
									{
										DateTime dateTime = Convert.ToDateTime(((ArrayList)variableByName.VarArray[num5])[num7].ToString());
										value = ((!(text6 != string.Empty)) ? dateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI) : dateTime.ToString(text6, myDTFI));
									}
									else
									{
										value = ((!(text6 != string.Empty)) ? ((DateTime)variableByName.VarArray[num5]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI) : ((DateTime)variableByName.VarArray[num5]).ToString(text6, myDTFI));
									}
									break;
								}
								text = text.Insert(num, value);
							}
						}
					}
				}
			}
			else if (num2 > -1)
			{
				string text8 = text.Substring(num, num2 - num).Trim();
				text = text.Remove(num, num2 - num + 1);
				string text9 = string.Empty;
				if (text8.IndexOf(":") > -1)
				{
					string text10 = text8;
					text9 = text10.Substring(text10.IndexOf(":") + 1);
					text8 = text8.Substring(0, text8.IndexOf(":"));
				}
				GameVariable variableByName2 = GetVariableByName(text8);
				if (variableByName2 == null)
				{
					text2 = text2 + "The variable named " + text8 + " could not be located.";
					flag = true;
				}
				if (variableByName2 != null)
				{
					string value2 = string.Empty;
					switch (variableByName2.vartype)
					{
					case GameVariable.VarType.VT_NUMBER:
						value2 = variableByName2.dNumType.ToString();
						break;
					case GameVariable.VarType.VT_STRING:
						value2 = variableByName2.sString;
						break;
					case GameVariable.VarType.VT_DATETIME:
						value2 = ((!(text9 != string.Empty)) ? variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt", myDTFI) : variableByName2.dtDateTime.ToString(text9, myDTFI));
						break;
					}
					text = text.Insert(num, value2);
				}
			}
		}
		if (flag)
		{
			MessageBox.Show("Formatting error detected: " + text2, "Formatting Error");
		}
	}
}
