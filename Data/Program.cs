using System;

namespace Data
{
    class Program
    {
        public readonly static string _databaseFilePath = "myDB.db";
        public readonly static string _connectionString = $"Data Source={_databaseFilePath};Version=3;";
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

            PlatformTDG platformTDG = new PlatformTDG(_connectionString);

            //platformTDG.Insert(new Platform()
            //{
            //    PlatformId = 1,
            //    Name = "Platform1",
            //    ParentCompany = "ParentCompany1",
            //    Founded = new DateTime(2000, 1, 1),
            //    Website = "www.platform1.com"
            //});

            var games = gameTDG.GetAll();
            var platforms = platformTDG.GetAll();

            foreach (var game in games)
            {
                Console.WriteLine($"GameId: {game.GameId}, Title: {game.Title}, ReleaseDate: {game.ReleaseDate}, Publisher: {game.Publisher}, Price: {game.Price}, MinimumAge: {game.MinimumAge}");
            }
            foreach (var platform in platforms)
            {
                Console.WriteLine($"PlatformId: {platform.PlatformId}, Name: {platform.Name}, ParentCompany: {platform.ParentCompany}, Founded: {platform.Founded}, Website: {platform.Website}");
            }
        }
    }
}
