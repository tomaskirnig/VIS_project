using System.Data.SQLite;
using Dapper;

namespace Data
{
    public static class OldValueTDG
    {
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public static IEnumerable<OldValueDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM OldValues";
                return connection.Query<OldValueDTO>(request);
            }
        }

        public static OldValueDTO GetById(int OldValueId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM OldValues WHERE OldValueId = @OldValueId";
                return connection.QuerySingleOrDefault<OldValueDTO>(request, new { OldValueId = OldValueId });
            }
        }

        public static void Insert(OldValueDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO OldValues (ChangedDate, GameId, OldTitle, OldReleaseDate, OldPrice, OldPublisher) 
                                VALUES (@ChangedDate, @GameId, @OldTitle, @OldReleaseDate, @OldPrice, @OldPublisher)";
                connection.Execute(request, data);
            }
        }

        public static void Update(OldValueDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"UPDATE OldValues SET ChangedDate = @ChangedDate, GameId = @GameId, OldTitle = @OldTitle, OldReleaseDate = @OldReleaseDate, OldPrice = @OldPrice, OldPublisher = @OldPublisher 
                                WHERE OldValueId = @OldValueId";
                connection.Execute(request, data);
            }
        }

        public static void Delete(int OldValueId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "DELETE FROM OldValues WHERE OldValueId = @OldValueId";
                connection.Execute(request, new { OldValueId = OldValueId });
            }
        }
    }
}
