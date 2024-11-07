using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OldValue
    {
        public int ChangeId { get; set; }
        public DateTime ChangedDate { get; set; }
        public int GameId { get; set; }
        public string OldTitle { get; set; }
        public DateTime OldReleaseDate { get; set; }
        public decimal OldPrice { get; set; }
        public string OldPublisher { get; set; }
    }
}
