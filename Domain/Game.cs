using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int MinimumAge { get; set; }

        public Game(int GameID)
        {
            GameDTO game = GameTDG.GetById(GameID);

            if(game != null)
            {
                game.GameId = game.GameId;
                Title = game.Title;
                ReleaseDate = game.ReleaseDate;
                Publisher = game.Publisher;
                Price = game.Price;
                MinimumAge = game.MinimumAge;
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
                game.GameId = game.GameId;
                Title = game.Title;
                ReleaseDate = game.ReleaseDate;
                Publisher = game.Publisher;
                Price = game.Price;
                MinimumAge = game.MinimumAge;
            }
            else
            {
                throw new ArgumentException("Game not found");
            }
        }
    }
}
