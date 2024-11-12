using System;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Domain
{
    public class GenreAR
    {
        public int GenreId { get; private set; }
        public string GenreNameShort { get; set; }
        public string GenreNameFull { get; set; }

        // Static method to load a Genre by ID
        public static GenreAR FindById(int genreId, string _connectionString)
        {
            using(var connection = new SQLiteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Genres WHERE GenreId = @GenreId";
                return connection.QuerySingleOrDefault<GenreAR>(sql, new { GenreId = genreId });
            }
            
        }

        // Saves changes to the current instance (insert if new, update if existing)
        public void Save(string _connectionString)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                if (GenreId == 0) // Insert new record
                {
                    var sql = "INSERT INTO Genres (GenreNameShort, GenreNameFull) VALUES (@GenreNameShort, @GenreNameFull);" +
                              "SELECT CAST(last_insert_rowid() as int);";
                    GenreId = connection.ExecuteScalar<int>(sql, this);
                }
                else // Update existing record
                {
                    var sql = "UPDATE Genres SET GenreNameShort = @GenreNameShort, GenreNameFull = @GenreNameFull WHERE GenreId = @GenreId";
                    connection.Execute(sql, this);
                }
            }
        }

        // Deletes the current instance from the database
        public void Delete(string _connectionString)
        {
            if (GenreId == 0)
                throw new InvalidOperationException("This genre does not exist in the database.");
            using (var connection = new SQLiteConnection(_connectionString))
            {
                var sql = "DELETE FROM Genres WHERE GenreId = @GenreId";
                connection.Execute(sql, new { GenreId });
            }
            GenreId = 0; // Reset ID to indicate it’s no longer in the database
        }
    }
}
