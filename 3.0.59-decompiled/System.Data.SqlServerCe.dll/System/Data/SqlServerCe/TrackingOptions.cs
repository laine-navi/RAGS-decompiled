namespace System.Data.SqlServerCe;

[Flags]
public enum TrackingOptions
{
	None = 0,
	Insert = 1,
	Update = 2,
	Delete = 4,
	All = Insert | Update | Delete,
	Max = 8
}
