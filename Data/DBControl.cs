using System;
using System.Data.SQLite;
using System.IO;

namespace Data
{
    public static class DBControl
    {
        private static string _databaseFilePath;

        public static void setDatabaseFilePath(string databaseFilePath)
        {
            _databaseFilePath = databaseFilePath;
        }

        // Method to create the database if it doesn't exist
        public static void CreateDatabaseIfNotExists()
        {
            if (!File.Exists(_databaseFilePath))
            {
                SQLiteConnection.CreateFile(_databaseFilePath);
                Console.WriteLine("Database created successfully.");

                // Initialize database with tables
                InitializeDatabase();
            }
            else
            {
                Console.WriteLine("Database already exists.");
            }
        }

        // Method to initialize the database with required tables
        private static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection($"Data Source={_databaseFilePath};Version=3;"))
            {
                connection.Open();

                // Create tables
                CreateGenresTable(connection);
                CreatePlatformsTable(connection);
                CreateGamesTable(connection);
                CreatePlayersTable(connection);
                CreateReviewsTable(connection);
                CreatePurchasesTable(connection);
                CreateOldValuesTable(connection);

                Console.WriteLine("All tables created successfully.");
            }
        }

        private static void CreateGenresTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Genres (
                    GenreId INTEGER PRIMARY KEY AUTOINCREMENT,
                    GenreNameShort TEXT,
                    GenreNameFull TEXT
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreatePlatformsTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Platforms (
                    PlatformId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    ParentCompany TEXT,
                    Founded DATE,
                    Website TEXT
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreateGamesTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Games (
                    GameId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT,
                    ReleaseDate DATE,
                    Publisher TEXT,
                    Price DECIMAL,
                    MinimumAge INTEGER
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreatePlayersTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Players (
                    PlayerId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT,
                    LastName TEXT,
                    DateOfBirth DATE,
                    Email TEXT,
                    Gender CHAR,
                    RegistrationDate DATE,
                    Country TEXT,
                    GameReviewer BOOLEAN
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreateReviewsTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Reviews (
                    ReviewId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Rating INTEGER,
                    Text TEXT,
                    ReviewDate DATE,
                    GameId INTEGER,
                    PlayerId INTEGER,
                    FOREIGN KEY(GameId) REFERENCES Games(GameId),
                    FOREIGN KEY(PlayerId) REFERENCES Players(PlayerId)
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreatePurchasesTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Purchases (
                    PurchaseId INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameId INTEGER,
                    PlayerId INTEGER,
                    Price DECIMAL,
                    PurchaseDate DATE,
                    FOREIGN KEY(GameId) REFERENCES Games(GameId),
                    FOREIGN KEY(PlayerId) REFERENCES Players(PlayerId)
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void CreateOldValuesTable(SQLiteConnection connection)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS OldValues (
                    ChangeId INTEGER PRIMARY KEY AUTOINCREMENT,
                    ChangedDate DATE,
                    GameId INTEGER,
                    OldTitle TEXT,
                    OldReleaseDate DATE,
                    OldPrice DECIMAL,
                    OldPublisher TEXT,
                    FOREIGN KEY(GameId) REFERENCES Games(GameId)
                );";
            ExecuteNonQuery(sql, connection);
        }

        private static void ExecuteNonQuery(string sql, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Method to delete the database
        public static void DeleteDatabase()
        {
            if (File.Exists(_databaseFilePath))
            {
                File.Delete(_databaseFilePath);
                Console.WriteLine("Database deleted successfully.");
            }
            else
            {
                Console.WriteLine("Database does not exist.");
            }
        }
    }
}
