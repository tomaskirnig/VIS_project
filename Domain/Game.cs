using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int MinimumAge { get; set; }
        public int GenreId { get; set; }
        public int PlatformId { get; set; }

        public Game(GameDTO gameDTO)
        {
            MapGame(gameDTO);
        }

        public Game(int GameID)
        {
            GameDTO game = GameTDG.GetById(GameID);

            if(game != null)
            {
                MapGame(game);
            }
            else
            {
                throw new ArgumentException("Game not found");
            }
        }

        public Game(string title)
        {
            GameDTO game = GameTDG.GetByTitle(title);

            if (game != null)
            {
                MapGame(game);
            }
            else
            {
                throw new ArgumentException("Game not found");
            }
        }

        public void MapGame(GameDTO gameDTO)
        {
            GameId = gameDTO.GameId;
            Title = gameDTO.Title;
            ReleaseDate = gameDTO.ReleaseDate;
            Publisher = gameDTO.Publisher;
            Price = gameDTO.Price;
            MinimumAge = gameDTO.MinimumAge;
            GenreId = gameDTO.GenreId;
            PlatformId = gameDTO.PlatformId;
        }

        public void Update()
        {
            GameDTO game = new GameDTO
            {
                GameId = GameId,
                Title = Title,
                ReleaseDate = ReleaseDate,
                Publisher = Publisher,
                Price = Price,
                MinimumAge = MinimumAge,
                GenreId = GenreId,
                PlatformId = PlatformId
            };

            GameTDG.Update(game);
        }

        public static List<Game> GetAllGames()
        {
            List<GameDTO> gamesDTOs = GameTDG.GetAll();

            if (gamesDTOs != null)
            {
                return gamesDTOs.Select(gameDTO => new Game(gameDTO)).ToList();
            }
            else
            {
                throw new ArgumentException("No games found");
            }
        }

        public static List<Game> GetNGames(int from, int to)
        {
            List<GameDTO> gamesDTOs = GameTDG.GetNGames(from, to);

            if (gamesDTOs != null)
            {
                List<Game> gameList = gamesDTOs.Select(gameDTO => new Game(gameDTO)).ToList();

                return gameList;
            }
            else
            {
                throw new ArgumentException("No games found");
            }
        }
    }
}
