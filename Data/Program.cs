using System;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            DBControl.CreateDatabaseIfNotExists();

            PopulateTables();

            var games = GameTDG.GetNGames(0, 9);
            var players = PlayerTDG.GetAll();
            var platforms = PlatformTDG.GetAll();
            var purchases = PurchaseTDG.GetAll();
            var genres = GenreTDG.GetAll();

            foreach (var game in games)
            {
                Console.WriteLine($"GameId: {game.GameId}, Title: {game.Title}, ReleaseDate: {game.ReleaseDate}, Publisher: {game.Publisher}, Price: {game.Price}, MinimumAge: {game.MinimumAge}, GenreId: {game.GenreId}, PlatformId: {game.PlatformId}");
            }
            foreach(var player in players)
            {
                Console.WriteLine($"PlayerId: {player.PlayerId}, FirstName: {player.FirstName}, LastName: {player.LastName}, Email: {player.Email}, UserName: {player.UserName}, UserName: {player.UserName}, Password: {player.Password}");
            }
            foreach (var platform in platforms)
            {
                Console.WriteLine($"PlatformId: {platform.PlatformId}, Name: {platform.Name}, ParentCompany: {platform.ParentCompany}, Founded: {platform.Founded}, Website: {platform.Website}");
            }
            foreach (var purchase in purchases)
            {
                Console.WriteLine($"PurchaseId: {purchase.PurchaseId}, GameId: {purchase.GameId}, PlayerId: {purchase.PlayerId}, Price: {purchase.Price}, PurchaseDate: {purchase.PurchaseDate}");
            }
            foreach (var genre in genres)
            {
                Console.WriteLine($"GenreId: {genre.GenreId}, GenreNameShort: {genre.GenreNameShort}, GenreNameFull: {genre.GenreNameFull}");
            }
        }

        public static void PopulateTables()
        {
            Random random = new Random();

            // Populating Genres table
            for (int i = 0; i < 10; i++)
            {
                var genre = new GenreDTO
                {
                    GenreId = i + 1,
                    GenreNameShort = $"G{i + 1}",
                    GenreNameFull = $"Genre Full Name {i + 1}"
                };
                Console.WriteLine($"Populating Genre: {genre.GenreNameFull}");
                GenreTDG.Insert(genre);
            }

            // Populating Platforms table
            for (int i = 0; i < 10; i++)
            {
                var platform = new PlatformDTO
                {
                    PlatformId = i + 1,
                    Name = $"Platform {i + 1}",
                    ParentCompany = $"Company {i + 1}",
                    Founded = DateTime.Now.AddYears(-10 - i),
                    Website = $"https://platform{i + 1}.com"
                };
                Console.WriteLine($"Populating Platform: {platform.Name}");
                PlatformTDG.Insert(platform);
            }

            // Populating Games table
            for (int i = 0; i < 100; i++)
            {
                var game = new GameDTO
                {
                    GameId = i + 1,
                    Title = $"Game {i + 1}",
                    ReleaseDate = DateTime.Now.AddDays(-random.Next(1, 1000)), // Random release within ~3 years
                    Publisher = $"Publisher {random.Next(1, 20)}",
                    Price = (decimal)(random.Next(10, 101) + random.NextDouble()),
                    MinimumAge = random.Next(12, 18),
                    GenreId = random.Next(1, 11), 
                    PlatformId = random.Next(1, 11) 
                };
                Console.WriteLine($"Populating Game: {game.Title}, GenreId={game.GenreId}, Price={game.Price}");
                GameTDG.Insert(game);
            }

            // Populating Players table
            for (int i = 0; i < 10; i++)
            {
                var player = new PlayerDTO
                {
                    PlayerId = i + 1,
                    FirstName = $"PlayerFirst{i + 1}",
                    LastName = $"PlayerLast{i + 1}",
                    DateOfBirth = DateTime.Now.AddYears(-15 - i),
                    Email = $"player{i + 1}@example.com",
                    Gender = (i % 2 == 0) ? 'M' : 'F',
                    RegistrationDate = DateTime.Now.AddYears(-1).AddMonths(-i),
                    GameReviewer = i % 2 == 0,
                    UserName = $"Player{i + 1}",
                    Password = $"Password{i + 1}",
                    Role = i % 3 
                };
                Console.WriteLine($"Populating Player: {player.UserName}, {player.Email}");
                PlayerTDG.Insert(player);
            }

            // Populating Purchases table
            for (int i = 0; i < 100; i++)
            {
                var purchase = new PurchaseDTO
                {
                    PurchaseId = i + 1,
                    GameId = random.Next(1, 101), 
                    PlayerId = random.Next(1, 11), 
                    Price = (decimal)(random.Next(15, 101) + random.NextDouble()), 
                    PurchaseDate = DateTime.Now.AddDays(-random.Next(1, 365)) // Purchased within the last year
                };
                Console.WriteLine($"Populating Purchase: GameId={purchase.GameId}, PlayerId={purchase.PlayerId}");
                PurchaseTDG.Insert(purchase);
            }

            // Populating Reviews table
            for (int i = 0; i < 100; i++)
            {
                var review = new ReviewDTO
                {
                    ReviewId = i + 1,
                    Rating = random.Next(1, 6), 
                    Text = $"This is review {i + 1}",
                    ReviewDate = DateTime.Now.AddDays(-random.Next(1, 365)), // Reviewed within the last year
                    GameId = random.Next(1, 101), 
                    PlayerId = random.Next(1, 11)
                };
                Console.WriteLine($"Populating Review: GameId={review.GameId}, Rating={review.Rating}");
                ReviewTDG.Insert(review);
            }
        }

    }
}
