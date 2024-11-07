using System;

namespace Data
{
    class Program
    {
        readonly static string _databaseFilePath = "myDB.db";
        readonly static string _connectionString = $"Data Source={_databaseFilePath};Version=3;";
        static void Main(string[] args)
        {
           
            DBControl dbControl = new DBControl(_databaseFilePath);

            dbControl.CreateDatabaseIfNotExists();

            GameTDG gameTDG = new GameTDG(_connectionString);

            //gameTDG.Insert(new Game() 
            //{ 
            //    Title = "Game1",
            //    ReleaseDate = new DateTime(2021, 1, 1),
            //    Publisher = "Publisher1",
            //    Price = 10.0m,
            //    MinimumAge = 12
            //});

            //gameTDG.Insert(new Game()
            //{
            //    Title = "Game2",
            //    ReleaseDate = new DateTime(2023, 1, 1),
            //    Publisher = "Publisher2",
            //    Price = 10.0m,
            //    MinimumAge = 18
            //});

            var games = gameTDG.GetAll();

            foreach (var game in games)
            {
                Console.WriteLine($"GameId: {game.GameId}, Title: {game.Title}, ReleaseDate: {game.ReleaseDate}, Publisher: {game.Publisher}, Price: {game.Price}, MinimumAge: {game.MinimumAge}");
            }
        }
    }
}
