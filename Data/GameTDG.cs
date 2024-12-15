using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using Data;

public static class GameTDG
{
    public static List<GameDTO> GetAll()
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games";
            return connection.Query<GameDTO>(request).ToList();
        }
    }

    public static GameDTO GetById(int gameId)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games WHERE GameId = @GameId";
            return connection.QuerySingleOrDefault<GameDTO>(request, new { GameId = gameId });
        }
    }

    public static List<GameDTO> GetNGames(int from, int to)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Games WHERE GameId BETWEEN @From AND @To";
            return connection.Query<GameDTO>(query, new { From = from, To = to }).ToList();
        }
    }

    public static GameDTO GetByTitle(string title)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games WHERE Title = @Title";
            return connection.QuerySingleOrDefault<GameDTO>(request, new { Title = title });
        }
    }

    public static void Insert(GameDTO data)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = @"
            INSERT INTO Games (Title, ReleaseDate, Publisher, Price, MinimumAge, GenreId, PlatformId) 
            VALUES (@Title, @ReleaseDate, @Publisher, @Price, @MinimumAge, @GenreId, @PlatformId)";
            connection.Execute(request, data);
        }
    }

    public static void Update(GameDTO data)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = @"
            UPDATE Games 
            SET Title = @Title, ReleaseDate = @ReleaseDate, Publisher = @Publisher, 
                Price = @Price, MinimumAge = @MinimumAge, GenreId = @GenreId, PlatformId = @PlatformId
            WHERE GameId = @GameId";
            connection.Execute(request, data);
        }
    }


    public static void Delete(int gameId)
    {
        using (var connection = new SQLiteConnection(ConnConfig._connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Games WHERE GameId = @GameId";
            connection.Execute(request, new { GameId = gameId });
        }
    }
}
