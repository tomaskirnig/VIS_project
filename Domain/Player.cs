using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

namespace Domain
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
        public bool GameReviewer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        private List<Purchase> _purchaseHistory;
        // Lazy-loaded PurchaseHistory
        public List<Purchase> PurchaseHistory
        {
            get
            {
                // If not loaded yet, load from DB
                if (_purchaseHistory == null)
                {
                    var purchasesDTO = PurchaseTDG.GetByPlayerId(PlayerId);
                    _purchaseHistory = purchasesDTO.Select(dto => new Purchase(dto)).ToList();
                }

                return _purchaseHistory;
            }
            set
            {
                _purchaseHistory = value;
            }
        }

        public Player(PlayerDTO playerDTO)
        {
            MapPlayer(playerDTO);
        }

        public Player(int playerId)
        {
            PlayerDTO player = PlayerTDG.GetById(playerId);

            if (player != null)
            {
                MapPlayer(player);
            }
            else
            {
                throw new ArgumentException("Player not found");
            }
        }

        // Map method to populate fields
        public void MapPlayer(PlayerDTO playerDTO)
        {
            PlayerId = playerDTO.PlayerId;
            FirstName = playerDTO.FirstName;
            LastName = playerDTO.LastName;
            DateOfBirth = playerDTO.DateOfBirth;
            Email = playerDTO.Email;
            Gender = playerDTO.Gender;
            RegistrationDate = playerDTO.RegistrationDate;
            GameReviewer = playerDTO.GameReviewer;
            UserName = playerDTO.UserName;
            Password = playerDTO.Password;
            Role = playerDTO.Role;
        }

        // Update method to save changes
        public void Update()
        {
            PlayerDTO player = new PlayerDTO
            {
                PlayerId = PlayerId,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Gender = Gender,
                RegistrationDate = RegistrationDate,
                GameReviewer = GameReviewer,
                UserName = UserName,
                Password = Password,
                Role = Role
            };

            PlayerTDG.Update(player);
        }

        public static void Create(PlayerDTO player)
        {
            PlayerTDG.Insert(player);
        }

        public static List<Player> GetAllPlayers()
        {
            List<PlayerDTO> playersDTO = PlayerTDG.GetAll();

            if (playersDTO != null)
            {
                return playersDTO.Select(dto => new Player(dto)).ToList();
            }
            else
            {
                throw new ArgumentException("No players found");
            }
        }
    }
}
