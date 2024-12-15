using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using Data;

public static class GenreTDG
{
    public static List<GenreDTO> GetAll()
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Genres";
            return connection.Query<GenreDTO>(request).ToList();
        }
    }

    public static GenreDTO GetById(int genreId)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Genres WHERE GenreId = @GenreId";
            return connection.QuerySingleOrDefault<GenreDTO>(request, new { GenreId = genreId });
        }
    }

    public static GenreDTO GetByName(string genreName)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Genres WHERE GenreNameShort = @GenreName OR GenreNameFull = @GenreName";
            return connection.QuerySingleOrDefault<GenreDTO>(request, new { GenreName = genreName });
        }
    }

    public static void Insert(GenreDTO data)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = @"INSERT INTO Genres (GenreNameShort, GenreNameFull) 
                        VALUES (@GenreNameShort, @GenreNameFull)";
            connection.Execute(request, data);
        }
    }

    public static void Update(GenreDTO data)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = @"UPDATE Genres SET GenreNameShort = @GenreNameShort, GenreNameFull = @GenreNameFull 
                        WHERE GenreId = @GenreId";
            connection.Execute(request, data);
        }
    }

    public static void Delete(int genreId)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Genres WHERE GenreId = @GenreId";
            connection.Execute(request, new { GenreId = genreId });
        }
    }
}
