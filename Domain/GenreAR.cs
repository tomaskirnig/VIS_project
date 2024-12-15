using System;
using System.Data;
using System.Data.SQLite;
using Dapper;
using Data;

namespace Domain
{
    public class GenreAR
    {
        public int GenreId { get; private set; }
        public string GenreNameShort { get; set; }
        public string GenreNameFull { get; set; }

        public static GenreAR FindById(int genreId)
        {
            using(var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                var sql = "SELECT * FROM Genres WHERE GenreId = @GenreId";
                return connection.QuerySingleOrDefault<GenreAR>(sql, new { GenreId = genreId });
            }
            
        }

        public void Save()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                if (GenreId == 0) 
                {
                    var sql = "INSERT INTO Genres (GenreNameShort, GenreNameFull) VALUES (@GenreNameShort, @GenreNameFull);" +
                              "SELECT CAST(last_insert_rowid() as int);";
                    GenreId = connection.ExecuteScalar<int>(sql, this);
                }
                else 
                {
                    var sql = "UPDATE Genres SET GenreNameShort = @GenreNameShort, GenreNameFull = @GenreNameFull WHERE GenreId = @GenreId";
                    connection.Execute(sql, this);
                }
            }
        }

        public void Delete()
        {
            if (GenreId == 0)
                throw new InvalidOperationException("This genre does not exist in the database.");
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                var sql = "DELETE FROM Genres WHERE GenreId = @GenreId";
                connection.Execute(sql, new { GenreId });
            }
            GenreId = 0;
        }
    }
}
