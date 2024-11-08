using System.Data.SQLite;
using Dapper;

namespace Data
{
    internal class GenreRDG
    {
        private readonly string _connectionString;

        public int GenreId { get; private set; }
        public string GenreNameShort { get; set; }
        public string GenreNameFull { get; set; }

        public GenreRDG(string connectionString)
        {
            _connectionString = connectionString;

        }

        // Loads a single row into the instance
        public void Load(int genreId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Genres WHERE GenreId = @GenreId";
                var genre = connection.QuerySingleOrDefault<GenreRDG>(sql, new { GenreId = genreId });

                if (genre != null)
                {
                    GenreId = genre.GenreId;
                    GenreNameShort = genre.GenreNameShort;
                    GenreNameFull = genre.GenreNameFull;
                }
            }
        }

        // Saves changes for this row instance
        public void Save()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                if (GenreId == 0)
                {
                    var sql = "INSERT INTO Genres (GenreNameShort, GenreNameFull) VALUES (@GenreNameShort, @GenreNameFull)";
                    connection.Execute(sql, this);
                    GenreId = (int)connection.LastInsertRowId;
                }
                else
                {
                    var sql = "UPDATE Genres SET GenreNameShort = @GenreNameShort, GenreNameFull = @GenreNameFull WHERE GenreId = @GenreId";
                    connection.Execute(sql, this);
                }
            }
        }

        // Deletes this row from the database
        public void Delete()
        {
            if (GenreId == 0) throw new InvalidOperationException("Row must be loaded or saved before deletion.");

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Genres WHERE GenreId = @GenreId";
                connection.Execute(sql, new { GenreId });
                GenreId = 0;
            }
        }
    }
}
