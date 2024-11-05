using System;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Collections.Generic;

namespace Data
{
    public class GameData
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int MinimumAge { get; set; }
    }

    internal class GameTDG
    {
        private readonly string _connectionString;

        public GameTDG(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<GameData> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Games";
                return connection.Query<GameData>(sql);
            }
        }

        public GameData GetById(int gameId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Games WHERE GameId = @GameId";
                return connection.QuerySingleOrDefault<GameData>(sql, new { GameId = gameId });
            }
        }

        public void Insert(GameData data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = @"INSERT INTO Games (Title, ReleaseDate, Publisher, Price, MinimumAge) 
                            VALUES (@Title, @ReleaseDate, @Publisher, @Price, @MinimumAge)";
                connection.Execute(sql, data);
            }
        }

        public void Update(GameData data)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = @"UPDATE Games SET Title = @Title, ReleaseDate = @ReleaseDate, 
                            Publisher = @Publisher, Price = @Price, MinimumAge = @MinimumAge 
                            WHERE GameId = @GameId";
                connection.Execute(sql, data);
            }
        }

        public void Delete(int gameId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Games WHERE GameId = @GameId";
                connection.Execute(sql, new { GameId = gameId });
            }
        }
    }
}
