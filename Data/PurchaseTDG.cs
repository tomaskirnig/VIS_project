using System.Data.SQLite;
using Dapper;

namespace Data
{
    public static class PurchaseTDG
    {
        private static string _connectionString;
        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public static IEnumerable<PurchaseDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases";
                return connection.Query<PurchaseDTO>(request);
            }
        }

        public static PurchaseDTO GetById(int PurchaseId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases WHERE PurchaseId = @PurchaseId";
                return connection.QuerySingleOrDefault<PurchaseDTO>(request, new { PurchaseId = PurchaseId });
            }
        }

        public static void Insert(PurchaseDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Purchases (GameId, PlayerId, Price, PurchaseDate) 
                               VALUES (@GameId, @PlayerId, @Price, @PurchaseDate)";
                connection.Execute(request, data);
            }
        }

        public static void Update(PurchaseDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"UPDATE Purchases SET GameId = @GameId, PlayerId = @PlayerId, 
                               Price = @Price, PurchaseDate = @PurchaseDate 
                               WHERE PurchaseId = @PurchaseId";
                connection.Execute(request, data);
            }
        }

        public static void Delete(int PurchaseId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "DELETE FROM Purchases WHERE PurchaseId = @PurchaseId";
                connection.Execute(request, new { PurchaseId = PurchaseId });
            }
        }
    }
}
