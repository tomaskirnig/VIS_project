﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
