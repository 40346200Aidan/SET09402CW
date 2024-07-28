using SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography.X509Certificates;


public static class DatabaseSetup
{
    public static string GetDatabasePath()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the database
        string relativePath = Path.Combine(baseDirectory, @"..\..\..\..\..\Database\Haulage.db");

        // Resolve to a full absolute path
        return Path.GetFullPath(relativePath);
    }

    public static string connectionString = $"Data Source={GetDatabasePath()};Version=3;";

    public static void InitializeDatabase()
    {
        if (File.Exists($@"{GetDatabasePath()}"))
        {
            using (var connection = new SQLiteConnection(GetDatabasePath()))
            {
               // DropTables(connection);
               // CreateTables(connection);   
               // GenerateData(connection);
            }
        }
    }

    //Drops all the tables inside the database 
    public static void DropTables(SQLiteConnection connection)
    {
        List<string> dropTableScripts = new List<string>
        {
            "DROP TABLE IF EXISTS [User]",
            "DROP TABLE IF EXISTS [Bill]",
            "DROP TABLE IF EXISTS [Event]",
            "DROP TABLE IF EXISTS [Expense]",
            "DROP TABLE IF EXISTS [Item]",
            "DROP TABLE IF EXISTS [Role]",
            "DROP TABLE IF EXISTS [Trip]",
            "DROP TABLE IF EXISTS [TripManifest]",
            "DROP TABLE IF EXISTS [Vehicle]"
        };

        foreach (string table in dropTableScripts)
        {
            var command = new SQLiteCommand(connection)
            {
                CommandText = table
            };
            command.ExecuteNonQuery();
        }
    }

    public static void GenerateData(SQLiteConnection connection)
    {
        //Vehicle data
        CreateVehicles(connection);
    }

    public static void CreateVehicles(SQLiteConnection connection)
    {
        List<string> dataScripts = new List<string>
        {
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (1, 1, 'test1', 1, 1, 1);",
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (2, 2, 'test2', 2, 2, 1);",
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (3, 3, 'test3', 3, 3, 3);",
            @"INSERT INTO [User] ([UserId], [RoleId], [Fullname], [Email], [PhoneNumber], [Role], [Address], [Qualification]) VALUES (9749274, 92742442424, 'John Smith', 'john.smith@gmail.com', '07908 923349', 'Driver', '26 Edinburgh Way', 'Fragile');",
            @"INSERT INTO [User] ([UserId], [RoleId], [Fullname], [Email], [PhoneNumber], [Role], [Address], [Qualification]) VALUES (9272482, 92742442424, 'Richard Caldwell', 'richard.caldwell@gmail.com', '07802 8248284', 'Driver', '22 ParkHill Avenue', 'Fragile');",
            @"INSERT INTO [User] ([UserId], [RoleId], [Fullname], [Email], [PhoneNumber], [Role], [Address], [Qualification]) VALUES (9826492, 94828458292, 'Abigail Park', 'abigail.park@gmail.com', '07908 729593', 'Administrator', '14 Roger Hill', 'N/A');",
             @"INSERT INTO [User] ([UserId], [RoleId], [Fullname], [Email], [PhoneNumber], [Role], [Address], [Qualification]) VALUES (8384838, 94828458292, 'Peter Hill', 'peter.hill@gmail.com', '04838 385929', 'Administrator', '17 Castle Road', 'N/A');",
        };

        foreach (string tableScript in dataScripts)
        {
            var command = new SQLiteCommand(connection)
            {
                CommandText = tableScript
            };
            command.ExecuteNonQuery();
        }
    }

    public static void CreateTables(SQLiteConnection connection)
    {
        //Create User Table for Haulage Data;
        List<string> createTableScripts = new List<string>
        {
            @"CREATE TABLE IF NOT EXISTS User (UserID INTEGER PRIMARY KEY AUTOINCREMENT, RoleID INTEGER NOT NULL, FullName TEXT NOT NULL, Email TEXT NOT NULL, PhoneNumber TEXT NOT NULL, Role TEXT NOT NULL, Address TEXT NOT NULL, Qualification TEXT);",
            @"CREATE TABLE IF NOT EXISTS Item (ItemID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Description TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Trip (TripId INTEGER PRIMARY KEY AUTOINCREMENT, StartLocation TEXT NOT NULL, EndLocation TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Role (RoleId INTEGER PRIMARY KEY AUTOINCREMENT, RoleDesc TEXT NOT NULL, FullName TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Vehicle (VehicleId INTEGER PRIMARY KEY AUTOINCREMENT, TripID INTEGER, LicensePlate TEXT UNIQUE NOT NULL, Capacity INTEGER NOT NULL, DriverId INTEGER NOT NULL, Status INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS TripManifest (ManifestId INTEGER PRIMARY KEY AUTOINCREMENT, TripId INTEGER NOT NULL, PickUpRequest INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Bill (BillId INTEGER PRIMARY KEY AUTOINCREMENT, Fullname TEXT NOT NULL, Email TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Expense (ExpenseId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL, VehicleId INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Event (EventId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL);"
        };

        foreach (string tableScript in createTableScripts)
        {
            var command = new SQLiteCommand(connection)
            {
                CommandText = tableScript
            };
            command.ExecuteNonQuery();
        }

    }

}
