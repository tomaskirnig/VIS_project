using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Data;

namespace Data
{
    public static class PlayerTDG
    {
        public static List<PlayerDTO> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Players";
                return connection.Query<PlayerDTO>(request).ToList();
            }
        }

        public static PlayerDTO GetById(int playerId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Players WHERE PlayerId = @PlayerId";
                return connection.QuerySingleOrDefault<PlayerDTO>(request, new { PlayerId = playerId });
            }
        }

        public static PlayerDTO GetByUsername(string username)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "SELECT * FROM Players WHERE UserName = @UserName";
                return connection.QuerySingleOrDefault<PlayerDTO>(request, new { UserName = username });
            }
        }

        public static void Insert(PlayerDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = @"
                    INSERT INTO Players 
                    (FirstName, LastName, DateOfBirth, Email, Gender, RegistrationDate, GameReviewer, UserName, Password, Role) 
                    VALUES 
                    (@FirstName, @LastName, @DateOfBirth, @Email, @Gender, @RegistrationDate, @GameReviewer, @UserName, @Password, @Role)";
                connection.Execute(request, data);
            }
        }

        public static void Update(PlayerDTO data)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = @"
                    UPDATE Players 
                    SET FirstName = @FirstName, 
                        LastName = @LastName, 
                        DateOfBirth = @DateOfBirth, 
                        Email = @Email, 
                        Gender = @Gender, 
                        RegistrationDate = @RegistrationDate, 
                        GameReviewer = @GameReviewer, 
                        UserName = @UserName, 
                        Password = @Password,
                        Role = @Role
                    WHERE PlayerId = @PlayerId";
                connection.Execute(request, data);
            }
        }

        public static void Delete(int playerId)
        {
            using (var connection = new SQLiteConnection(ConnConfig._connectionString))
            {
                connection.Open();
                var request = "DELETE FROM Players WHERE PlayerId = @PlayerId";
                connection.Execute(request, new { PlayerId = playerId });
            }
        }
    }
}
