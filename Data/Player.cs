using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Country { get; set; }
        public bool GameReviewer { get; set; }
    }
}