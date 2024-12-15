using System.Data.SQLite;
using Dapper;

namespace Data
{
    public static class PurchaseTDG
    {
        public static List<PurchaseDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases";
                return connection.Query<PurchaseDTO>(request).ToList();
            }
        }

        public static PurchaseDTO GetById(int PurchaseId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases WHERE PurchaseId = @PurchaseId";
                return connection.QuerySingleOrDefault<PurchaseDTO>(request, new { PurchaseId = PurchaseId });
            }
        }

        public static List<PurchaseDTO> GetByPlayerId(int PlayerId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Purchases WHERE PlayerId = @PlayerId";
                return connection.Query<PurchaseDTO>(request, new { PlayerId = PlayerId }).ToList();
            }
        }

        public static float GetPriceSum()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT SUM(Price) FROM Purchases";
                return connection.QuerySingleOrDefault<float>(request);
            }
        }

        public static int GetPurchaseCount()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT COUNT(*) FROM Purchases";
                return connection.QuerySingleOrDefault<int>(request);
            }
        }

        public static float GetPriceSum(int GameId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT SUM(Price) FROM Purchases WHERE GameId = @GameId";
                return connection.QuerySingleOrDefault<float>(request, new { GameId = GameId });
            }
        }

        public static void Insert(PurchaseDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Purchases (GameId, PlayerId, Price, PurchaseDate) 
                               VALUES (@GameId, @PlayerId, @Price, @PurchaseDate)";
                connection.Execute(request, data);
            }
        }

        public static void Update(PurchaseDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
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
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "DELETE FROM Purchases WHERE PurchaseId = @PurchaseId";
                connection.Execute(request, new { PurchaseId = PurchaseId });
            }
        }
    }
}
