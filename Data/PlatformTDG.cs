using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Data;

namespace Data
{
    public static class PlatformTDG
    {
        private static PlatformMapper _platformMapper = new PlatformMapper();

        public static PlatformDTO GetById(int platformId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Platforms WHERE PlatformId = @PlatformId";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PlatformId", platformId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Use the mapper to convert the reader data into a Platform object
                            return _platformMapper.MapPlatform(reader);
                        }
                    }
                }
            }
            return null; // Return null if no platform is found
        }

        public static List<PlatformDTO> GetAll()
        {
            var platforms = new List<PlatformDTO>();

            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Platforms";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Use the mapper to map each row to a Platform object
                        platforms.Add(_platformMapper.MapPlatform(reader));
                    }
                }
            }

            return platforms;
        }

        public static void Insert(PlatformDTO platform)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Platforms (Name, ParentCompany, Founded, Website) VALUES (@Name, @ParentCompany, @Founded, @Website)";
                connection.Execute(sql, platform); // Dapper maps Platform properties directly to SQL parameters
                platform.PlatformId = (int)connection.LastInsertRowId; // Set the generated PlatformId
            }
        }

        public static void Update(PlatformDTO platform)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var sql = "UPDATE Platforms SET Name = @Name, ParentCompany = @ParentCompany, Founded = @Founded, Website = @Website WHERE PlatformId = @PlatformId";
                connection.Execute(sql, platform); // Dapper maps Platform properties directly to SQL parameters
            }
        }

        public static void Delete(int platformId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Platforms WHERE PlatformId = @PlatformId";
                connection.Execute(sql, new { PlatformId = platformId });
            }
        }
    }
}
