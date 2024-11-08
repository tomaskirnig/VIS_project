using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Data;

namespace Data
{
    public class PlatformTDG
    {
        private readonly string _connectionString;
        private readonly PlatformMapper _platformMapper;

        public PlatformTDG(string connectionString)
        {
            _connectionString = connectionString;
            _platformMapper = new PlatformMapper(); 
        }

        public Platform GetById(int platformId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
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

        public IEnumerable<Platform> GetAll()
        {
            var platforms = new List<Platform>();

            using (var connection = new SQLiteConnection(_connectionString))
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

        public void Insert(Platform platform)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Platforms (Name, ParentCompany, Founded, Website) VALUES (@Name, @ParentCompany, @Founded, @Website)";
                connection.Execute(sql, platform); // Dapper maps Platform properties directly to SQL parameters
                platform.PlatformId = (int)connection.LastInsertRowId; // Set the generated PlatformId
            }
        }

        public void Update(Platform platform)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "UPDATE Platforms SET Name = @Name, ParentCompany = @ParentCompany, Founded = @Founded, Website = @Website WHERE PlatformId = @PlatformId";
                connection.Execute(sql, platform); // Dapper maps Platform properties directly to SQL parameters
            }
        }

        public void Delete(int platformId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Platforms WHERE PlatformId = @PlatformId";
                connection.Execute(sql, new { PlatformId = platformId });
            }
        }
    }
}
