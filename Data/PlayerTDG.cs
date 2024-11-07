using System.Data;
using System.Data.SQLite;
using Dapper;
using Data;

public class PlayerTDG
{
    private readonly string _connectionString;

    public PlayerTDG(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Player> GetAll()
    {
        using(var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Players";
            return connection.Query<Player>(request);
        }
    }

    public Player GetById(int playerId)
    {
        using(var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Players WHERE PlayerId = @PlayerId";
            return connection.QuerySingleOrDefault<Player>(request, new { PlayerId = playerId });
        }
    }

    public void Insert(Player data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"INSERT INTO Players (FirstName, LastName, DateOfBirth, Email, Gender, RegistrationDate, Country, GameReviewer) 
                        VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Gender, @RegistrationDate, @Country, @GameReviewer)";
            connection.Execute(request, data);
        }
    }

    public void Update(Player data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"UPDATE Players SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Email = @Email, Gender = @Gender, RegistrationDate = @RegistrationDate, Country = @Country, GameReviewer = @GameReviewer WHERE PlayerId = @PlayerId";
            connection.Execute(request, data);
        }
    }   
    public void Delete(int playerId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Players WHERE PlayerId = @PlayerId";
            connection.Execute(request, new { PlayerId = playerId });
        }
    }
}
