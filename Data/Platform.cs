using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string ParentCompany { get; set; }
        public DateTime Founded { get; set; }
        public string Website { get; set; }
    }
}
