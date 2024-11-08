using System.Data.SQLite;
using Dapper;

namespace Data
{
    internal class PurchaseTDG
    {
        private readonly string _connectionString;
        public PurchaseTDG(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Purchase> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases";
                return connection.Query<Purchase>(request);
            }
        }

        public Purchase GetById(int PurchaseId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases WHERE PurchaseId = @PurchaseId";
                return connection.QuerySingleOrDefault<Purchase>(request, new { PurchaseId = PurchaseId });
            }
        }

        public void Insert(Purchase data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Purchases (GameId, PlayerId, Price, PurchaseDate) 
                               VALUES (@GameId, @PlayerId, @Price, @PurchaseDate)";
                connection.Execute(request, data);
            }
        }

        public void Update(Purchase data)
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

        public void Delete(int PurchaseId)
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
