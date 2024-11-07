using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime ReviewDate { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
    }
}
