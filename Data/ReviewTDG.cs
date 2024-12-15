using System.Data.SQLite;
using Dapper;

namespace Data
{
    public static class ReviewTDG
    {
        public static List<ReviewDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews";
                return connection.Query<ReviewDTO>(request).ToList();
            }
        }

        public static ReviewDTO GetById(int ReviewId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews WHERE ReviewId = @ReviewId";
                return connection.QuerySingleOrDefault<ReviewDTO>(request, new { ReviewId = ReviewId });
            }
        }

        public static float GetAverageRating(int GameId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT AVG(Rating) FROM Reviews WHERE GameId = @GameId";
                return connection.QuerySingleOrDefault<float>(request, new { GameId = GameId });
            }
        }

        public static List<(int GameId, float AverageRating)> GetTopNAverageRatings(int Count)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = @"
                    SELECT GameId, AVG(Rating) as AverageRating
                    FROM Reviews
                    GROUP BY GameId
                    ORDER BY AverageRating DESC
                    LIMIT @Count";
                return connection.Query<(int GameId, float AverageRating)>(request, new { Count = Count }).ToList();
            }
        }

        public static void Insert(ReviewDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Reviews (Rating, Text, ReviewDate, GameId, PlayerId) 
                        VALUES (@Rating, @Text, @ReviewDate, @GameId, @PlayerId)";
                connection.Execute(request, data);
            }
        }

        public static void Update(ReviewDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
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
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "DELETE FROM Reviews WHERE ReviewId = @ReviewId";
                connection.Execute(request, new { ReviewId = ReviewId });
            }
        }
    }
}
