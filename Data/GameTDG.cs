using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using Data;

public static class GameTDG
{
    private static string _connectionString;

    public static void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public static List<GameDTO> GetAll()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games";
            return connection.Query<GameDTO>(request).ToList();
        }
    }

    public static GameDTO GetById(int gameId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games WHERE GameId = @GameId";
            return connection.QuerySingleOrDefault<GameDTO>(request, new { GameId = gameId });
        }
    }

    public static GameDTO GetByTitle(string title)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games WHERE Title = @title";
            return connection.QuerySingleOrDefault<GameDTO>(request, new { GameId = gameId });
        }
    }

    public static void Insert(GameDTO data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"INSERT INTO Games (Title, ReleaseDate, Publisher, Price, MinimumAge) 
                        VALUES (@Title, @ReleaseDate, @Publisher, @Price, @MinimumAge)";
            connection.Execute(request, data);
        }
    }

    public static void Update(GameDTO data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"UPDATE Games SET Title = @Title, ReleaseDate = @ReleaseDate, 
                        Publisher = @Publisher, Price = @Price, MinimumAge = @MinimumAge 
                        WHERE GameId = @GameId";
            connection.Execute(request, data);
        }
    }

    public static void Delete(int gameId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Games WHERE GameId = @GameId";
            connection.Execute(request, new { GameId = gameId });
        }
    }
}
