using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int MinimumAge { get; set; }
        public int GenreId { get; set; }
        public int PlatformId { get; set; }
    }
}
