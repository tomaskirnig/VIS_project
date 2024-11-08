using System.Data.SQLite;
using Dapper;

namespace Data
{
    class ReviewTDG
    {
        private readonly string _connectionString;

        public ReviewTDG(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Review> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews";
                return connection.Query<Review>(request);
            }
        }

        public Review GetById(int ReviewId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Reviews WHERE ReviewId = @ReviewId";
                return connection.QuerySingleOrDefault<Review>(request, new { ReviewId = ReviewId });
            }
        }

        public void Insert(Review data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var request = @"INSERT INTO Reviews (Rating, Text, ReviewDate, GameId, PlayerId) 
                        VALUES (@Rating, @Text, @ReviewDate, @GameId, @PlayerId)";
                connection.Execute(request, data);
            }
        }

        public void Update(Review data)
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

        public void Delete(int ReviewId)
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
