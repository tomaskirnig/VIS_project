using System.Data.SQLite;
using Dapper;

namespace Data
{
    internal class OldValueTDG
    {
        private readonly string _connectionString;

        public OldValueTDG(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<OldValue> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM OldValues";
                return connection.Query<OldValue>(request);
            }
        }

        public OldValue GetById(int OldValueId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM OldValues WHERE OldValueId = @OldValueId";
                return connection.QuerySingleOrDefault<OldValue>(request, new { OldValueId = OldValueId });
            }
        }

        public void Insert(OldValue data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO OldValues (ChangedDate, GameId, OldTitle, OldReleaseDate, OldPrice, OldPublisher) 
                                VALUES (@ChangedDate, @GameId, @OldTitle, @OldReleaseDate, @OldPrice, @OldPublisher)";
                connection.Execute(request, data);
            }
        }

        public void Update(OldValue data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"UPDATE OldValues SET ChangedDate = @ChangedDate, GameId = @GameId, OldTitle = @OldTitle, OldReleaseDate = @OldReleaseDate, OldPrice = @OldPrice, OldPublisher = @OldPublisher 
                                WHERE OldValueId = @OldValueId";
                connection.Execute(request, data);
            }
        }

        public void Delete(int OldValueId)
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
