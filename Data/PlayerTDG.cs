using System.Data;
using System.Data.SQLite;
using Dapper;
using Data;

public static class PlayerTDG
{
    private static string _connectionString;

    public static void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public static List<PlayerDTO> GetAll()
    {
        using(var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Players";
            return connection.Query<PlayerDTO>(request).ToList();
        }
    }

    public static PlayerDTO GetById(int playerId)
    {
        using(var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "SELECT * FROM Players WHERE PlayerId = @PlayerId";
            return connection.QuerySingleOrDefault<PlayerDTO>(request, new { PlayerId = playerId });
        }
    }

    public static void Insert(PlayerDTO data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"INSERT INTO Players (FirstName, LastName, DateOfBirth, Email, Gender, RegistrationDate, Country, GameReviewer) 
                        VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Gender, @RegistrationDate, @Country, @GameReviewer)";
            connection.Execute(request, data);
        }
    }

    public static void Update(PlayerDTO data)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = @"UPDATE Players SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Email = @Email, Gender = @Gender, RegistrationDate = @RegistrationDate, Country = @Country, GameReviewer = @GameReviewer WHERE PlayerId = @PlayerId";
            connection.Execute(request, data);
        }
    }   
    public static void Delete(int playerId)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var request = "DELETE FROM Players WHERE PlayerId = @PlayerId";
            connection.Execute(request, new { PlayerId = playerId });
        }
    }
}
