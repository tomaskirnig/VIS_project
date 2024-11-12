using System.Data.SQLite;
using Dapper;

namespace Data
{
    public static class ReviewTDG
    {
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public static IEnumerable<ReviewDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews";
                return connection.Query<ReviewDTO>(request);
            }
        }

        public static ReviewDTO GetById(int ReviewId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews WHERE ReviewId = @ReviewId";
                return connection.QuerySingleOrDefault<ReviewDTO>(request, new { ReviewId = ReviewId });
            }
        }

        public static void Insert(ReviewDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Reviews (Rating, Text, ReviewDate, GameId, PlayerId) 
                        VALUES (@Rating, @Text, @ReviewDate, @GameId, @PlayerId)";
                connection.Execute(request, data);
            }
        }

        public static void Update(ReviewDTO data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"UPDATE Reviews SET Rating = @Rating, Text = @Text, 
                        ReviewDate = @ReviewDate, GameId = @GameId, PlayerId = @PlayerId 
                        WHERE ReviewId = @ReviewId";
                connection.Execute(request, data);
            }
        }

        public static void Delete(int ReviewId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "DELETE FROM Reviews WHERE ReviewId = @ReviewId";
                connection.Execute(request, new { ReviewId = ReviewId });
            }
        }
    }
}
