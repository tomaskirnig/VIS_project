using System.Data.SQLite;
using Dapper;
using Data;

public class GameTDG
{
    private readonly string _connectionString;

    public GameTDG(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Game> GetAll()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games";
            return connection.Query<Game>(request);
        }
    }

    public Game GetById(int gameId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Games WHERE GameId = @GameId";
            return connection.QuerySingleOrDefault<Game>(request, new { GameId = gameId });
        }
    }

    public void Insert(Game data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"INSERT INTO Games (Title, ReleaseDate, Publisher, Price, MinimumAge) 
                        VALUES (@Title, @ReleaseDate, @Publisher, @Price, @MinimumAge)";
            connection.Execute(request, data);
        }
    }

    public void Update(Game data)
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

    public void Delete(int gameId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Games WHERE GameId = @GameId";
            connection.Execute(request, new { GameId = gameId });
        }
    }
}

