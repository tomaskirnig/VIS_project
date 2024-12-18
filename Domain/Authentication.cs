using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public static class Authentication
    {
        // In-memory storage of players (Identity map)
        private static List<Player> Users = new List<Player>();

        // Session variables
        private static string currentSessionToken = null;
        private static Player currentSessionUser = null;

        public static bool Register(string firstName, string lastName, DateTime dateOfBirth, string email, string gender, string username, string password, int role)
        {
            // Check if a user with the same username is in memory
            if (Users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false; 
            }

            // Check if a user with the same username already exists in the database
            var existingPlayer = PlayerTDG.GetByUsername(username);
            if (existingPlayer != null)
            {
                return false; 
            }

            DateTime registrationDate = DateTime.Now;
            char genderChar = string.IsNullOrEmpty(gender) ? 'U' : gender[0];

            var newPlayer = new PlayerDTO
            {
                PlayerId = 0, // Will be assigned by DB (AUTOINCREMENT)
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                Gender = genderChar,
                RegistrationDate = registrationDate,
                GameReviewer = false,
                UserName = username,
                Password = password, // EncryptPassword(password) - not used for simplucity when populating tables
                Role = role
            };

            PlayerTDG.Insert(newPlayer);

            var insertedPlayer = PlayerTDG.GetByUsername(username);
            if (insertedPlayer == null)
            {
                return false; 
            }

            var playerObj = new Player(insertedPlayer);
            Users.Add(playerObj);

            currentSessionUser = playerObj;
            currentSessionToken = insertedPlayer.UserName; 

            return true;
        }

        public static bool Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.UserName.Equals(username));

            if (user == null)
            {
                var userDTO = PlayerTDG.GetByUsername(username);
                if (userDTO != null)
                {
                    user = new Player(userDTO);
                    Users.Add(user);
                }
                else {
                    return false; 
                }
            }
            
            if (user != null && ValidatePassword(password, user.Password))
            {
                string sessionToken = user.UserName; // Used username for simplicity

                currentSessionToken = sessionToken;
                currentSessionUser = user;

                return true;
            }
            else return false;
        }

        public static void Logout(string sessionToken)
        {
            if (IsAuthenticated(sessionToken))
            {
                currentSessionUser = null;
                currentSessionToken = null;
            }
        }

        public static bool IsAuthenticated(string sessionToken) // username as session token input
        {
            return currentSessionToken != null && currentSessionToken == sessionToken;
        }

        public static Player GetCurrentUser()
        {
            return currentSessionUser;
        }

        public static string GetSessionToken()
        {
            return currentSessionToken;
        }

        public static bool IsAdmin(string sessionToken)
        {
            var user = GetCurrentUser();
            return user != null && user.Role == 1;
        }

        public static string EncryptPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public static bool ValidatePassword(string inputPassword, string storedHash)
        {
            //var inputHash = EncryptPassword(inputPassword); // Showcase of encrypting password 
            return storedHash == inputPassword;
        }
    }
}
